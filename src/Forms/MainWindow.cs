using OnGuardCore.Src.Properties;
using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Media;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Resources;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;


namespace OnGuardCore
{

  public partial class MainWindow : Form
  {
    AIAnalyzer _analyzer;
    SortedList<string, PictureInfo> _fileNames;

    int _current = 0;
    bool _showObjects = true;
    volatile Picture _displayedPicture;

    int _imagesBeingProcessed;
    int _numberOfImagesProcessed;

    readonly MostRecentCollection _recentTimes = new(10);
    readonly object _fileLock = new();
    readonly object _aiNotFoundLock = new();

    const int _originalImageWidth = 1280;
    const int _originalImageHeight = 960;
    int _originalPicturePanelWidth = 0;
    int _originalPicturePanelHeight = 0;

    private delegate void SetProgressDelegate(int cpuLoad);

    static Frame _test;

    CameraCollection _allCameras;

    bool _modifyingArea = false;    // Flag that we are modifying an area
    bool _definingFace = false;   // flag that we are doing a face definition
    bool _loading = false;    // set during the startup/load process
    DefinitionType _definitionType;

    ZoneBox _modifyBox;
    GridDefinition _areaDefinition = new(GlobalData.AreaGridX, GlobalData.AreaGridY);
    int _defineBrushSize = 1;
    Guid _modifyingAreaID = Guid.Empty;
    MainWindow _main;

    MovementDirection _moveDirection = MovementDirection.Still; // So we know what direction the user intended if a file goes missing (it happens)

    List<InterestingObject> _frameObjects = new();
    readonly ConcurrentQueue<PendingItem> _fileQueue = new();
    readonly AutoResetEvent _wakeFileQueue = new(false);
    readonly Thread _monitorQueueThread;
    System.Windows.Forms.Timer _liveTimer;
    bool _continueLiveVideo = false;
    bool _directionUp = false;  // direction is down because we start up at the last (most recent) picture
    string _lastPictureRequested = string.Empty;  // When moving up/down we need the last one we requested, which may be well behind what is displayed
    ModelessMessageWindow _startMsg;
    ConcurrentDictionary<Guid, Picture> _pendingPictures = new();
    readonly Guid NextPicture = new("B684676E-094E-4ED1-8949-97125AC7D330");
    Guid _cancelAfterPicture = Guid.Empty;  // When empty we don't cancel. When NextPicture we cancel on after the next is processed.  When a specific GUID, only cancel when we hit that specific one

    readonly ConcurrentDictionary<string, string> _filesPendingProcessing = new(); // very short period of time where the file has been removed from the queue yet still hasn't been opened
    readonly ManualResetEvent _stopEvent = new(false);  // set to shut down the MonitorQueue thread (and anything else)

    CameraData CurrentCam
    {
      get
      {
        if (_allCameras != null)
        {
          return _allCameras.CurrentCamera;
        }
        else
        {
          return null;
        }
      }
    }


    readonly private PerformanceCounter theCPUCounter = new("Processor", "% Processor Time", "_Total");

    public MainWindow()
    {

      _main = this;

      //if (!Debugger.IsAttached)
      //{

      Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);
      AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
      //}

      Settings.Default.SettingsKey = "OnGuard";
      Settings.Default.Reload();

      _loading = true;

      InitializeComponent();
      _originalPicturePanelWidth = picturePanel.Width;
      _originalPicturePanelHeight = picturePanel.Height;

      _startMsg = new ModelessMessageWindow(this, "Starting Up", "Please wait while On Guard starts!", true);
      _monitorQueueThread = new Thread(MonitorQueue);

      Focus();


    }

    private void AIStateChanged(bool aiState)
    {
      if (this.InvokeRequired)
      {
        BeginInvoke(new BoolDelegate(AIStateChanged), new object[] { aiState });
        return;
      }

      if (aiState)
      {
        AIStatus.Text = "Connected";
        AIStatus.BackColor = Color.LightGreen;
      }
      else
      {
        AIStatus.Text = "Disconnected";
        AIStatus.BackColor = Color.Red;
      }
    }

    static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
    {
      // Log the exception, display it, etc
      Exception ex = (Exception)e.Exception;
      Dbg.Write(ex.Message);
      MessageBox.Show("There was an unexpected error.  Please report it: " + ex.Message + Environment.NewLine + Environment.NewLine + ex.StackTrace, "Unexpected Error (1)");
    }

    static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
    {
      // Log the exception, display it, etc
      Exception ex = (Exception)e.ExceptionObject;
      Dbg.Write(ex.Message);
      MessageBox.Show("There was an unexpected error.  Please report it: " + ex.Message + Environment.NewLine + Environment.NewLine + ex.StackTrace, "Unexpected Error (2)");
    }

    private async void Form1_Load(object sender, EventArgs e)
    {
      this.Focus();
      CreateErrorPicture();
      await InitAsync();
    }

    private async Task InitAsync()
    {
      this.menuStrip2.Enabled = false;
      this.ToolsPanel.Enabled = false;
      timeLine.Enabled = false;

      await StartupAsync().ConfigureAwait(true);
      this.menuStrip2.Enabled = true;
      this.ToolsPanel.Enabled = true;
      timeLine.Enabled = true;
    }

    private delegate Task NoParmDelegate();
    async Task StartupAsync()
    {

      if (this.InvokeRequired)
      {
        this.BeginInvoke(new NoParmDelegate(StartupAsync));
        return;
      }

      AppDomain domain = AppDomain.CurrentDomain;
      string dataDirectory = (string)domain.GetData("DataDirectory"); // might be set by the installer
      if (!string.IsNullOrEmpty(dataDirectory))
      {
        Dbg.Write("MainWindow - Startup - The DataDirectory value was found as: " + dataDirectory);
        DBConnection.SetDatabasePath(dataDirectory);
      }

      if (!Storage.DoesDataDirectoryExist() || !Storage.Instance.GetGlobalBool("SetupComplete"))
      {
        _startMsg.Hide();
        await InitialSetupAsync().ConfigureAwait(true);
      }


      if (!AI.IsAIRunning())
      {
        if (Storage.Instance.GetGlobalBool("AutoStartDeepStack"))
        {
          if (!AI.RestartAI(false))
          {
            MessageBox.Show("(1) The DeepStack AI is NOT Running (2) You have requested that the AI start automatically (3) An attempt to start the AI FAILED", "DeepStack AI");
          }
        }
        else
        {
          string deepStackParameters = Storage.Instance.GetGlobalString("DeepStackParameters");
          if (!string.IsNullOrEmpty(deepStackParameters)) // Indicates whether ApplicationSetting has been run
          {
            MessageBox.Show("(1) The DeepStack AI is NOT Running (2) You have requested that the AI NOT start automatically (3) You MUST manually start the DeepStack AI (4) On Guard will now stop");
            Application.Exit();
          }
        }
      }

      bool logDetail = Storage.Instance.GetGlobalBool("LogDetailedInformation");
      if (logDetail)
      {
        Dbg.LogLevel = 1;
        UpdateMenuItem(logDetailedInformationToolStripMenuItem, string.Empty, 1);
      }


      AI.OnAIStateChange += AIStateChanged;
      Picture.OnPictureAvailable += PictureAvailable;
      Picture.OnObjectsDetected += OnObjectsDetected;
      AITimeUpdater.OnFrameTimeUpdate += UpdateFrameProgressBar;
      AITimeUpdater.OnAITimeUpdate += UpdateAIProgressBar;

      int currentCPU = (int)theCPUCounter.NextValue();
      currentCPU = (int)theCPUCounter.NextValue();
      _monitorQueueThread.Start();

      _analyzer = new AIAnalyzer();
      _allCameras = CameraCollection.Load();
      await _allCameras.InitAsync();

      if (CurrentCam != null)
      {
        Storage.Instance.SetGlobalString("CurrentCameraPath", CurrentCam.CameraPath);
        Storage.Instance.SetGlobalString("CurrentCameraPrefix", CurrentCam.CameraPrefix);
        Storage.Instance.Update();

        await InitAnalyzerAsync(CurrentCam.CameraPrefix, CurrentCam.CameraPath, CurrentCam.MonitorSubdirectories).ConfigureAwait(true);
        SetPresetList();
        EnablePTZ();
      }

      foreach (var cam in _allCameras.CameraDictionary.Values)
      {
        if (cam.Monitoring)
        {
          cam.Monitor.OnNewImage += OnCameraImage;
        }
      }


      string urlString = string.Empty;

      foreach (CameraData cam in _allCameras.CameraDictionary.Values)
      {
        cameraCombo.Items.Add(cam);
      }

      if (null != CurrentCam)
      {
        cameraCombo.SelectedItem = CurrentCam;
      }

      KeyPreview = true;

      await FaceDetection.RegisterAllFacesAsync();
      _loading = false;

      Dbg.Write("On Guard started at: " + DateTime.Now.ToString());

    }


    /// <summary>
    /// Called only once when they first start the application.
    /// It does all the required setup steps, one after the other.
    /// </summary>
    async Task InitialSetupAsync()
    {

      MessageBox.Show("In order to use the application you must first go through some steps to setup the application.  This is a one time only requirement.");

      DialogResult result = DialogResult.Cancel;
      DialogResult cancelResult;

      while (result == DialogResult.Cancel)
      {
        using (SettingsDialog dlg = new())
        {
          result = dlg.ShowDialog();   // AI and other application settings
          if (result == DialogResult.OK)
          {
          }
        }

        if (result != DialogResult.OK)
        {
          cancelResult = MessageBox.Show("In order to keep using this application you must continue the setup process.  Do you wisht to exit the application?", "Setup Incomplete!", MessageBoxButtons.YesNo);
          if (cancelResult == DialogResult.Yes)
          {
            Close();
            return;
          }
        }
      }

      // The camera setup 
      result = DialogResult.Cancel;
      _allCameras = CameraCollection.Load();

      while (result == DialogResult.Cancel)
      {
        using (CameraConfigurationDialog cameraDialog = new(_allCameras))
        {
          result = cameraDialog.ShowDialog();
          _allCameras = cameraDialog.AllCameraData;  // regardless of the OK/Cancel in the dialog we just copy the reference

          if (result == DialogResult.OK)
          {
            _allCameras = cameraDialog.AllCameraData;    // the list has been copied and returned
            CameraCollection.Save(_allCameras);

            if (null == cameraDialog.SelectedCamera)
            {
              Storage.Instance.SetGlobalString("CurrentCameraPath", string.Empty);
              Storage.Instance.SetGlobalString("CurrentCameraPrefix", string.Empty);
              Storage.Instance.Update();
            }
          }
        }

        if (result != DialogResult.OK)
        {
          cancelResult = MessageBox.Show("In order to keep using this application you must continue the setup process.  Do you wisht to exit the application?", "Setup Incomplete!", MessageBoxButtons.YesNo);
          if (cancelResult == DialogResult.Yes)
          {
            Application.Exit();
            return;
          }
        }
      }

      result = DialogResult.Cancel;

      while (result == DialogResult.Cancel)
      {
        using (OutgoingEmailDialog outgoingDlg = new())
        {
          result = outgoingDlg.ShowDialog();
        }

        if (result != DialogResult.OK)
        {
          cancelResult = MessageBox.Show("In order to keep using this application you must continue the setup process.  Do you wisht to exit the application?", "Setup Incomplete!", MessageBoxButtons.YesNo);
          if (cancelResult == DialogResult.Yes)
          {
            Application.Exit();
          }
        }
      }

      result = DialogResult.Cancel;

      while (result == DialogResult.Cancel)
      {
        using (EmailAddressesDialog dlg = new(EmailAddresses.EmailAddressList))
        {
          result = dlg.ShowDialog();
          if (result == DialogResult.OK)
          {
            EmailAddresses.Save();
          }
        }

        if (result != DialogResult.OK)
        {
          cancelResult = MessageBox.Show("In order to keep using this application you must continue the setup process.  Do you wisht to exit the application?", "Setup Incomplete!", MessageBoxButtons.YesNo);
          if (cancelResult == DialogResult.Yes)
          {
            Application.Exit();
          }
        }
      }

      Storage.Instance.SetGlobalBool("SetupComplete", true);
      Storage.Instance.Update();

      MessageBox.Show("The application will now exit.  Please restart it to continue", "Setup Complete!");
      Dispose();

    }

    // If the file name is in fact new the we start the load of desired file.
    // Once it loads it becomes the _displayedPicutre
    private Picture CreatePicture(string fileName)
    {
      Picture picture = null;
      if (!string.IsNullOrEmpty(fileName))
      {
        picture = new(fileName);
        Dbg.Trace("Creating new picture: " + picture.ID.ToString() + " File: " + fileName);
        _pendingPictures.TryAdd(picture.ID, picture);
        picture.AnalyzeIt = _showObjects;
        picture.PictureType = PictureTypes.File;
        Task.Run(() => Picture.LoadAsync(picture)).ConfigureAwait(false);
      }
      else
      {
        Dbg.Write("MainWindow - CreateDesiredPicture - the file name was null or empty!");
      }

      return picture;
    }

    private void CancelAllPendingPictures()
    {
      _moveDirection = MovementDirection.Still;
      foreach (var p in _pendingPictures.Values)
      {
        try
        {
          p.Cancel();
        }
        catch { }
      }
    }

    void CreateErrorPicture()
    {
      Picture p = new((Bitmap)pictureImage.ErrorImage, PictureTypes.Error); // will cause the to be created and will cause the callback into the UI thread
      Picture.LoadComplete(p);
    }


    private void CreatePictureFromBitmap(Bitmap bitmap, PictureTypes pictureType)
    {
      Picture p = new(bitmap);
      p.PictureType = pictureType;
      _pendingPictures.TryAdd(p.ID, p);
      Picture.LoadComplete(p);  // tell Picture to trigger the PictureAvailable event
    }

    public void UpdateLastPictureRequested(Picture picture)
    {
      if (null != picture && picture.State == PictureState.PictureLoaded)
      {
        string key = picture.GetKey();
        UpdateRequestedKey(key);
      }
    }

    public void UpdateRequestedKey(string fileKey)
    {
      if (!string.IsNullOrEmpty(fileKey))
      {
        _lastPictureRequested = fileKey;
      }
    }

    public void UpdateRequestedPictureFromFile(string fileName)
    {
      if (!string.IsNullOrEmpty(fileName))
      {
        string key = GlobalFunctions.GetUniqueFileName(fileName);
        _lastPictureRequested = key;
      }
    }

    private delegate void PictureAvailableDelegate(Picture p);
    private async void PictureAvailable(Picture picture)
    {
      if (this.InvokeRequired)
      {
        this.BeginInvoke(new PictureAvailableDelegate(PictureAvailable), new object[] { picture });
        return;
      }

      Picture pictureToDispose = null;

      int index = 0;
      objectListView.Items.Clear();

      if (!string.IsNullOrEmpty(picture.FileName))
      {
        index = PictureIndex(picture);
      }


      // Display ANY picture that has been loaded AND not canceled

      if (!picture.WasCanceled())
      {
        if (picture.State == PictureState.PictureLoaded)
        {
          BitmapResolution.XResolution = picture.PictureBitmap.Width;
          BitmapResolution.YResolution = picture.PictureBitmap.Height;
          XResLabel.Text = BitmapResolution.XResolution.ToString();
          YResLabel.Text = BitmapResolution.YResolution.ToString();
          BitmapResolution.XScale = (double)picture.PictureBitmap.Width / (double)pictureImage.Width;
          BitmapResolution.YScale = (double)picture.PictureBitmap.Height / (double)pictureImage.Height;
          AdjustPictureImageSize(picture);
          DrawRegistrationMark(picture);
          DrawAreasOfInterest(picture);

          pictureImage.SetImage(picture.PictureBitmap);

          if (picture.AnalyzeIt && picture.State == PictureState.PictureLoaded)
          {
            if (CurrentCam != null && picture.InterestingObjects != null && picture.InterestingObjects.Count > 0 && picture.PictureType != PictureTypes.Error)
            {
              _analyzer.RemoveInvalidObjects(CurrentCam, picture.InterestingObjects);
              await AnalyzePictureAsync(picture);
              UpdateObjectList(picture);
              picture.DrawObjectRectangles();
              pictureImage.SetImage(picture.PictureBitmap); // the second set, but rather than lag the picture/reg mark draw...

            }
          }

          pictureToDispose = _displayedPicture;
          _displayedPicture = picture;  // At this point it really is displayed, but maybe move it up.

          pictureImage.Refresh();
          if (picture.PictureType == PictureTypes.Error)
          {
            UpdateNumericValue(fileNumberUpDown, 1);
            UpdateControlText(goToFileTextBox, string.Empty);
          }
          else
          {
            UpdateNumericValue(fileNumberUpDown, index + 1);
            UpdateControlText(goToFileTextBox, picture.FileName);
            if (index >= 0)
            {
              timeLine.SetCurrentPosition(index);
            }
          }
        }
        else if (picture.State == PictureState.AINotFound)
        {
          Task.Run(() => NotifyAIGone()).ConfigureAwait(false);
          return;
        }
        else if (picture.State == PictureState.FileDoesNotExist)
        {
          await HandleMissingPictureAsync(picture);
        }
      }
      else
      {
        pictureToDispose = picture;  // it was canceled, we don't need it.
      }

      Picture removed;
      if (_pendingPictures.Count > 0 && !_pendingPictures.TryRemove(picture.ID, out removed))
      {
        Dbg.Trace("MainWindow - PictureAvailable - Could not remove picture: " + picture.ID.ToString());
      }

      // The _cancelAfterNextPiture is (1) empty, do nothing (2) the special next picture guid (3) we are looking for a partictular picture
      if (_cancelAfterPicture == NextPicture || picture.ID == _cancelAfterPicture)
      {
        CancelAllPendingPictures(); // clear the list since we got the one we wanted
        UpdateNumericValue(fileNumberUpDown, index + 1);
        UpdateControlText(goToFileTextBox, picture.FileName);
        UpdateLastPictureRequested(picture);  // because we are canceling everything where we are is where we want to be
        _cancelAfterPicture = Guid.Empty;
      }

      pictureToDispose?.Dispose();  // either the old displayed picture or one that has been canceled

    }

    // In cases using high resolution cameras the actual camera image is larger than the available space available to display it.
    // There are basically 3 scenarios here depending on user preferences
    // 1.  The width/height of the picture is fixed - if necessary use the scroll bars for vertical AND horizontal as necessary.
    // 2.  The aspect ratio is fixed using the picture width to height ratio.  The width always has priority over the height.  This avoids picture distortion. Vertical scroll bar is frequently required, never horizontal
    // 3.  The picture is always adjusted to fit within the borders - the picture may be visually distorted depending on the width to height ratio of the image and the window.  No picture scroll bars ever required
    private void AdjustPictureImageSize(Picture picture)
    {
      double ratio = (double)picture.PictureBitmap.Height / (double)picture.PictureBitmap.Width;  // the aspect ratio
      int pictureToPanelHeight = _originalPicturePanelHeight - _originalImageHeight;
      int pictureToPanelWidth = _originalPicturePanelWidth - _originalImageWidth;

      int y = 0;
      int x = 0;

      switch (CurrentCam.CameraView)
      {
        case DisplayOption.Fixed:
          x = _originalImageWidth;
          y = Convert.ToInt32((double)x * ratio);
          break;

        case DisplayOption.FilledHorizontally:

          x = picturePanel.Width - pictureToPanelWidth;
          x -= SystemInformation.VerticalScrollBarWidth;
          y = Convert.ToInt32((double)x * ratio);
          break;

        case DisplayOption.FilledBoth:
          x = picturePanel.Width - pictureToPanelWidth;
          y = picturePanel.Height - pictureToPanelHeight;
          break;

        case DisplayOption.FilledVertically:
          y = picturePanel.Height - pictureToPanelHeight;
          y -= SystemInformation.HorizontalScrollBarHeight;
          x = Convert.ToInt32((double)y / ratio);
          break;
      }

      SuspendLayout();
      pictureImage.Width = x;
      pictureImage.Height = y;
      ResumeLayout();
    }

    private void DrawRegistrationMark(Picture picture)
    {
      if (picture.PictureType != PictureTypes.Error)
      {
        if (CurrentCam != null && !(CurrentCam.RegistrationX == 0 && CurrentCam.RegistrationY == 0))
        {
          int x = (int)((((double)BitmapResolution.XResolution / (double)CurrentCam.RegistrationXResolution)) * (double)CurrentCam.RegistrationX);
          int y = (int)((((double)BitmapResolution.YResolution / (double)CurrentCam.RegistrationYResolution)) * (double)CurrentCam.RegistrationY);
          picture.DrawRegistrationMark(x, y);
        }
      }
    }

    // Ideally we'd like to do this in the picture, and maybe in the future.  We'd need to pass the AOI, and maybe that doesn't belong there?
    private async Task AnalyzePictureAsync(Picture picture)
    {
      FrameAnalyzer analyzer = new(CurrentCam.AOI, picture.InterestingObjects, picture.PictureBitmap.Width, picture.PictureBitmap.Height);
      AnalysisResult ar = await analyzer.AnalyzeFrameAsync(picture.PictureBitmap);
      picture.InterestingObjects = ar.InterestingObjects;
    }

    private void UpdateObjectList(Picture picture)
    {
      if (null != picture.InterestingObjects && picture.InterestingObjects.Count > 0)
      {
        objectListView.Items.Clear();

        string[] subItems = new string[6];
        foreach (InterestingObject io in picture.InterestingObjects)
        {
          subItems[0] = io.Label;
          subItems[1] = (100.0 * io.Confidence).ToString();
          subItems[2] = io.ObjectRectangle.X.ToString();
          subItems[3] = io.ObjectRectangle.Y.ToString();

          double screenWidthPercent = Math.Round((100.0 * io.ObjectRectangle.Width)/ BitmapResolution.XResolution, 1, MidpointRounding.AwayFromZero);
          double screenHeightPercent = Math.Round((100.0 * io.ObjectRectangle.Height) / BitmapResolution.YResolution, 1, MidpointRounding.AwayFromZero);

          subItems[4] = screenWidthPercent.ToString();
          subItems[5] = screenHeightPercent.ToString();
          ListViewItem item = new(subItems);
          objectListView.Items.Add(item);
        }
      }
    }


    private async Task HandleMissingPictureAsync(Picture picture)
    {

      if (!string.IsNullOrEmpty(picture.FileName))
      {
        Dbg.Write("MainWindows -- PictureAvailable - The file does not exist or could not be loaded in time: " + picture.FileName);

        // 
        string key = GlobalFunctions.GetUniqueFileName(picture.FileName);
        if (_fileNames.Remove(key))
        {
          ControlTextUpdate(numberOfFilesTextBox, _fileNames.Count.ToString()); // the ONLY time this happens
        }
      }

      // Note that the current pictures still has the filename to use as the basis for the next/previous
      if (_fileNames.Count > 0)
      {
        string nextPicture = await GetPostionAsync(true);
        if (!string.IsNullOrEmpty(nextPicture))
        {
          CreatePicture(nextPicture);
        }
        else
        {
          CreateErrorPicture();
        }
      }

    }


    void DisplayMessage(string msg, string title)
    {
      if (this.InvokeRequired)
      {
        this.BeginInvoke(new Action(() =>
        {
          MessageBox.Show(msg, title);  // This may be changed in the future
        }));
      }
      else
      {
        MessageBox.Show(msg, title);  // This may be changed in the future
      }
    }

    private async void OnObjectsDetected(Picture picture)
    {

      if (!picture.WasCanceled())
      {
        if (picture.State == PictureState.AINotFound)
        {
          DisplayMessage("The DeepStack AI was not found. Either start the DeepStack AI or change the location and port of that application.", "Setup Error!");
          return;
        }
        else
        {
          AIAnalyzer.RemoveItemsOfNoInterest(CurrentCam, picture.InterestingObjects);
          FrameAnalyzer analyzer = new(CurrentCam.AOI, picture.InterestingObjects, picture.PictureBitmap.Width, picture.PictureBitmap.Height);
          AnalysisResult ar = await analyzer.AnalyzeFrameAsync(picture.PictureBitmap).ConfigureAwait(true); // This does face detection that can be relatively slow


          CameraData data = CurrentCam;
          for (int i = 0; i < ar.InterestingObjects.Count; i++)
          {
            InterestingObject io = ar.InterestingObjects[i];
            io.IsOfCameraInterest = data.IsItemOfCameraInterest(ar.InterestingObjects[i].Label);
          }

        }
      }

    }


    private void PictureFromScanner(Bitmap bitmap)
    {
      CreatePictureFromBitmap(bitmap, PictureTypes.Scanned);
    }

    /// <summary>
    /// This happens just when we are startinng a new camera (startup or switch)
    /// </summary>
    /// <param name="cameraNamePrefix"></param>
    /// <param name="path"></param>
    /// <param name="subDirectories"></param>
    /// <returns></returns>
    async Task InitAnalyzerAsync(string cameraNamePrefix, string path, bool subDirectories)
    {
      _displayedPicture?.Dispose();
      CreateErrorPicture();

      if (null != _fileNames)
      {
        _fileNames.Clear();
      }

      _current = 0;
      _showObjects = true;
      UpdateMenuItem(showAreasOfInterestToolStripMenuItem, string.Empty, 0);

      if (null != _fileNames)
      {
        _fileNames.Clear();
      }

      _startMsg.SetLabel("Please Wait", "Loading Working Set Picture Names");
      _fileNames = _analyzer.Init(cameraNamePrefix, path, subDirectories);
      timeLine.Init(_fileNames);
      numberOfFilesTextBox.Text = _fileNames.Count.ToString();
      if (_fileNames.Count > 0)
      {
        _moveDirection = MovementDirection.Still;
        CreatePicture(_fileNames.Values[0].FileName);
      }

      fileNumberUpDown.Maximum = _fileNames.Count;
      fileNumberUpDown.Minimum = (int)1;
      _startMsg.Hide();
    }


    private void GetPictureAtPosition(int index)
    {

      if (index > 0)
      {
        if (_fileNames != null && index >= 0 && index < _fileNames.Count)
        {

          CreatePicture(_fileNames.Values[index].FileName);
        }
      }
    }

    Picture PictureFromFileName(string fileName)
    {
      Picture result = null;
      if (!string.IsNullOrEmpty(fileName))
      {
        string key = GlobalFunctions.GetUniqueFileName(fileName);
        if (_fileNames.Keys.Contains(key))
        {
          result = CreatePicture(fileName);
        }
        else
        {
          MessageBox.Show(@"The picture file path\name must exist in the working set!", "Invalid Picture Name");
        }
      }

      return result;
    }


    int PictureIndex(string fileName)
    {
      int index = -1;
      if (!string.IsNullOrEmpty(fileName))
      {
        string key = GlobalFunctions.GetUniqueFileName(fileName);
        index = _fileNames.IndexOfKey(key);
      }

      if (index == -1)
      {
        Dbg.Write("PictureIndex =- -1");
      }

      return index;
    }

    int PictureIndex(Picture picture)
    {
      return PictureIndex(picture.FileName);
    }

    string FileNameFromIndex(int index)
    {
      string pic = string.Empty;

      if (index != -1)
      {
        if (index < _fileNames.Count)
        {
          string key = _fileNames.Keys[index];
          pic = _fileNames[key].FileName;
        }
      }

      return pic;
    }



    // all this does is get the correct index into the file list when moving next.
    // this depends on whether we are looking for motion only or not.
    // This can take a while, particularly if a lot of files have been deleted that are in the working set

    private async Task<string> GetPostionAsync(bool next) // next is page up, right click
    {
      string fileName = string.Empty;
      int lastRequestedPosition = 0;
      int currentlyRequestedPosition = 0;

      if (!string.IsNullOrEmpty(_lastPictureRequested))
      {
        lastRequestedPosition = _fileNames.IndexOfKey(_lastPictureRequested);
      }

      using (WaitCursor _ = new())
      {
        if (motionOnlyCheckbox.Checked)
        {
          if (string.IsNullOrEmpty(_lastPictureRequested))
          {
            if (_displayedPicture != null && _displayedPicture.PictureType != PictureTypes.Error)
            {
              Dbg.Trace("MainWindow - GetPositionAsync - _lastPictureRequested is empty - Defaulting to displayed picture: " + _displayedPicture.FileName);
              UpdateLastPictureRequested(_displayedPicture);
            }
            else
            {
              return string.Empty;
            }
          }

          string nextKey = await GetNextMotionAsync(_lastPictureRequested, next);
          if (!string.IsNullOrEmpty(nextKey))
          {
            UpdateRequestedKey(nextKey);     // the key, not the file name itself.
            currentlyRequestedPosition = _fileNames.IndexOfKey(nextKey);
            fileName = _fileNames[nextKey].FileName;
          }
          else
          {
            fileName = string.Empty;
          }
        }
        else
        {

          if (next)
          {
            currentlyRequestedPosition = lastRequestedPosition + 1;
          }
          else
          {
            currentlyRequestedPosition = lastRequestedPosition - 1;
          }

          if (currentlyRequestedPosition < 0)
          {
            currentlyRequestedPosition = 0;
          }
          else if (currentlyRequestedPosition >= _fileNames.Count)
          {
            currentlyRequestedPosition = _fileNames.Count - 1; // which can go negative if there are no pictues
          }

          if (currentlyRequestedPosition >= 0)
          {
            fileName = FileNameFromIndex(currentlyRequestedPosition);
            UpdateRequestedPictureFromFile(fileName);
          }
        }
      }

      return fileName;
    }


    // Either with the page-up/down or the right left arrow keys we
    // would like to move in the direction indicated
    private async Task<Picture> MoveInDirectionAsync(bool right)
    {
      Picture nextPicture = null;

      if (_pendingPictures.Count > 5)
      {
        // If there is a backlog of pending pictures it does no good to add another request.
        // Note that we allow 5 because the AI (time consuming operation) can handle about 4 or 5
        // pictures at once (GPU version) with relative ease.
        return null;
      }

      string nextPictureName = await GetPostionAsync(right);
      if (!string.IsNullOrEmpty(nextPictureName))
      {
        if (right)
        {
          _moveDirection = MovementDirection.Right;
        }
        else
        {
          _moveDirection = MovementDirection.Left;
        }

        nextPicture = CreatePicture(nextPictureName);
      }

      return nextPicture;
    }

    private async void ButtonLeft_Click(object sender, EventArgs e)
    {
      Picture p = await MoveInDirectionAsync(false).ConfigureAwait(true);
      if (null != p)
      {
        _cancelAfterPicture = NextPicture; // allow the requested to complete, but only one
      }
    }

    private async void ButtonRight_Click(object sender, EventArgs e)
    {
      Picture p = await MoveInDirectionAsync(true).ConfigureAwait(true);
      if (null != p)
      {
        _cancelAfterPicture = NextPicture;// allow the requested to complete, but only one
      }
    }


    private void GoToFileButton_Click(object sender, EventArgs e)
    {
      using WaitCursor _ = new();
      _moveDirection = MovementDirection.Still;
      motionOnlyCheckbox.Checked = false;
      if (_fileNames.Count > 0)
      {
        if (_fileNames.Count > (int)((fileNumberUpDown.Value) - 1))
        {
          CancelAllPendingPictures(); // get rid of ALL pending pictures
          string key = _fileNames.Keys[(int)fileNumberUpDown.Value - 1];
          PictureInfo pi = _fileNames[key];
          CreatePicture(pi.FileName);
          UpdateRequestedKey(pi.PictureKey);
        }
      }
    }


    /// <summary>
    /// Got to a specific file named in the text box
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void GoToFileNameButton_Click(object sender, EventArgs e)
    {
      using WaitCursor _ = new();
      _moveDirection = MovementDirection.Still;
      motionOnlyCheckbox.Checked = false;

      if (!string.IsNullOrEmpty(goToFileTextBox.Text) && PictureIndex(goToFileTextBox.Text) != -1)
      {
        CreatePicture(goToFileTextBox.Text);
        UpdateRequestedPictureFromFile(goToFileTextBox.Text);
      }
      else
      {
        MessageBox.Show(this, @"You must enter the complete file path\name of a valid picture to view/go to it", "Valid Entry Required!");
      }
    }


    private void OnReverseListButton(object sender, EventArgs e)
    {
      CancelAllPendingPictures();

      using WaitCursor _ = new();
      motionOnlyCheckbox.Checked = false;
      PictureComparer comp = (PictureComparer)_fileNames.Comparer;
      comp.Reverse();
      _fileNames = new SortedList<string, PictureInfo>(_fileNames, comp);

      SetCurrent(0);
      if (_fileNames.Count > 0)
      {
        CreatePicture(_fileNames.Values[0].FileName);
        UpdateRequestedPictureFromFile(_fileNames.Values[0].FileName);
      }
      _directionUp = !_directionUp;
    }

    private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Application.Exit();
    }

    private void ShowObjectRectangelsToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (!_modifyingArea)
      {
        ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;
        if (_fileNames != null && _fileNames.Count > 0 && _showObjects != menuItem.Checked)
        {
          _showObjects = menuItem.Checked;
          if (_displayedPicture.PictureType == PictureTypes.File && !string.IsNullOrEmpty(_displayedPicture.FileName))
          {
            CreatePicture(_displayedPicture.FileName);
          }
        }
      }
    }

    private async void OnKeyDown(object sender, KeyEventArgs e)
    {
      if (!_loading)
      {
        switch (e.KeyCode)
        {
          case Keys.PageUp:
            if (!_modifyingArea)
            {
              e.Handled = true;
              await MoveInDirectionAsync(true);
            }
            break;
          case Keys.PageDown:
            if (!_modifyingArea)
            {
              e.Handled = true;
              await MoveInDirectionAsync(false);
            }
            break;

          case Keys.Escape:
            e.Handled = true;

            _areaDefinition.Clear();
            SetScreenAreaDefinition(_areaDefinition);
            if (_modifyingArea)
            {
              StopEditingEnvironment();
            }

            break;

          case Keys.F1:

            if (_definitionType == DefinitionType.Face)
            {
              if (_definingFace)
              {
                _definingFace = false;
                await CreateFaceAsync().ConfigureAwait(true);
              }
            }
            if (_definitionType == DefinitionType.AOI)
            {
              if (_modifyingArea)
              {
                AcceptAreaOfInterest();
                // _areaDefinition.Clear();
                // SetScreenAreaDefinition(_areaDefinition);
              }
            }
            break;

          case Keys.NumPad1:
          case Keys.D1:
            if (_modifyingArea)
            {
              _defineBrushSize = 1;
            }
            break;

          case Keys.NumPad2:
          case Keys.D2:
            if (_modifyingArea)
            {
              _defineBrushSize = 2;
            }
            break;


          case Keys.NumPad3:
          case Keys.D3:
            if (_modifyingArea)
            {
              _defineBrushSize = 4;
            }
            break;

          case Keys.NumPad4:
          case Keys.D4:
            if (_modifyingArea)
            {
              _defineBrushSize = 8;
            }
            break;

          case Keys.NumPad5:
          case Keys.D5:
            if (_modifyingArea)
            {
              _defineBrushSize = 16;
            }
            break;

          case Keys.NumPad6:
          case Keys.D6:
            if (_modifyingArea)
            {
              _defineBrushSize = 32;
            }
            break;

          case Keys.NumPad7:
          case Keys.D7:
            if (_modifyingArea)
            {
              _defineBrushSize = 64;
            }
            break;

          case Keys.F7:
            break;
        }
      }
    }

    // If the Key goes up and the background is moving to the next image (key held down)
    // eat any remainging keys
    private void OnKeyUp(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.PageUp)
      {
        _moveDirection = MovementDirection.Still;
        _cancelAfterPicture = NextPicture;   // still allow the "next" one to complete
      }
      else if (e.KeyCode == Keys.PageDown)
      {
        _moveDirection = MovementDirection.Still;
        _cancelAfterPicture = NextPicture;
      }
    }

    void AcceptAreaOfInterest()
    {

      if (_modifyingAreaID == Guid.Empty)
      {
        StopEditingEnvironment();

        using CreateAOI dlg = new(_areaDefinition);
        DialogResult result = dlg.ShowDialog(pictureImage);

        switch (result)
        {
          case DialogResult.OK:
            _areaDefinition.Clear();
            SetScreenAreaDefinition(_areaDefinition);

            if (_modifyingAreaID == Guid.Empty)
            {
              CurrentCam.AOI.AddArea(dlg.Area);
              CurrentCam.AOI.Save();
            }
            else
            {
              CurrentCam.AOI.Save();
              MessageBox.Show(pictureImage, "The Area of Interest was saved with a new definition!", "Area Saved");
              _modifyingAreaID = Guid.Empty;
            }
            break;

          case DialogResult.Yes:
            // An artificial response saying "edit this area".  This only happens when
            // there is a request to modify an area that has come from the initial area creation
            // It does not happen here when the area is modified via the EditAreasOfInterest box
            CurrentCam.AOI.AddArea(dlg.Area); // Even if we are modifying an area bounds we still save it
            CurrentCam.AOI.Save();
            StartEditingArea(dlg.Area.ID);
            break;
        }
      }
      else
      {
        // If we are already modifying an area all we do is update the area
        CurrentCam.AOI[_modifyingAreaID].Grid = new GridDefinition(_areaDefinition);
        _areaDefinition.Clear();
        SetScreenAreaDefinition(_areaDefinition);
        CurrentCam.AOI.Save();
        MessageBox.Show(pictureImage, "The Area of Interest was saved with a new definition!", "Area Changed!");
        StopEditingEnvironment();
      }

    }


    private void OnMouseMove(object sender, MouseEventArgs e)
    {
      int mouseX = (int)Math.Round((e.Location.X * BitmapResolution.XScale));
      int mouseY = (int)Math.Round(e.Location.Y * BitmapResolution.YScale);
      xPosLabel.Text = mouseX.ToString();
      yPosLabel.Text = mouseY.ToString();

      if (_modifyingArea)
      {
        if (e.Button == MouseButtons.Left || e.Button == MouseButtons.Right)
        {
          DefineArea(e.Location, MouseButtons.Left == e.Button);
        }
      }
    }

    void DefineArea(Point mousePoint, bool setArea)
    {
      Point pt = ScreenToArea(mousePoint);

      for (int row = 0; row < _defineBrushSize; row++)
      {
        if (pt.Y + row >= _areaDefinition.YDim)
        {
          break;
        }

        for (int col = 0; col < _defineBrushSize; col++)
        {
          if (pt.X + col >= _areaDefinition.XDim)
          {
            break;
          }

          _areaDefinition.Set(pt.X + col, pt.Y + row, setArea);
        }
      }

      SetScreenAreaDefinition(_areaDefinition);
    }



    void AdjustAreasOfInterest(int clickX, int clickY)
    {

      int newX = (int)Math.Round(clickX * BitmapResolution.XScale);
      int newY = (int)Math.Round(clickY * BitmapResolution.YScale);

      int offsetX = CurrentCam.RegistrationX - newX;
      int offsetY = CurrentCam.RegistrationY - newY;

      Dbg.Write("Setting Registration Point");
      CurrentCam.RegistrationX = newX;
      CurrentCam.RegistrationY = newY;
      CurrentCam.RegistrationXResolution = BitmapResolution.XResolution;
      CurrentCam.RegistrationYResolution = BitmapResolution.YResolution;
      _allCameras.CameraDictionary[CameraData.PathAndPrefix(CurrentCam)].RegistrationX = CurrentCam.RegistrationX;
      _allCameras.CameraDictionary[CameraData.PathAndPrefix(CurrentCam)].RegistrationY = CurrentCam.RegistrationY;

      CameraCollection.Save(_allCameras);
    }

    private void OnMouseDown(object sender, MouseEventArgs e)
    {

      if ((Control.ModifierKeys & Keys.Control) == Keys.Control)
      {

        if (e.Button == MouseButtons.Right)
        {
          // color = Color.FromArgb(80, Color.LightCyan);
          string caption = "On Guard ****** Defining Face - Escape to Quit, F1 to Accept ******";
          _displayedPicture.RestoreBitmap();
          pictureImage.SetImage(_displayedPicture.PictureBitmap);
          pictureImage.Refresh();
          SetupEditingEnvironment(caption);
          _definingFace = true;
          _modifyingAreaID = Guid.Empty;  // signal that this is a new area not a mods
          _modifyBox = new ZoneBox(Color.FromArgb(80, Color.LightCyan))
          {
            Parent = pictureImage,
            Location = new Point(e.X, e.Y),
            Size = new Size(100, 100)
          };
          _modifyBox.Show();
          ControlMoverOrResizer.Start(_modifyBox);
          _definitionType = DefinitionType.Face;
        }
        else if (e.Button == MouseButtons.Left)
        {
          if (MessageBox.Show("You are about to set the registration point for this camera.  This helps you ensure that your camera is in the right position. Are you sure you want to do this?", "Reset Camera Registration Point", MessageBoxButtons.YesNo) == DialogResult.Yes)
          {
            AdjustAreasOfInterest(e.X, e.Y);
            if (null != _displayedPicture)
            {
              CreatePictureFromBitmap(_displayedPicture.OriginalBitmap, PictureTypes.Snapshot);
            }
          }
        }
      }
      else if (e.Button == MouseButtons.Left || e.Button == MouseButtons.Right)
      {
        if (_modifyingArea)
        {
          DefineArea(e.Location, MouseButtons.Left == e.Button);
        }
      }
    }

    private void OnMouseUp(object sender, MouseEventArgs e)
    {
      if (null != CurrentCam)
      {
        if (CurrentCam.RegistrationX == 0 || CurrentCam.RegistrationY == 0)
        {
          if ((Control.ModifierKeys & Keys.Control) != Keys.Control)
          {
            MessageBox.Show("You must set a camera registration point so that you can ensure that your camera is always position correctly.  You do this by holding the control key and then clicking in the desired position for the registration point.  That point should be on a spot that is easily recoginzed when viewing the camera.", "Set Camera Registration Point First!");
          }
        }
      }
    }

    private async void ShowAreasOfInterestCheckChanged(object sender, EventArgs e)
    {
      if (_fileNames != null && _fileNames.Count > 0)
      {
        CancelAllPendingPictures();
        _moveDirection = MovementDirection.Still;

        if (showAreasOfInterestToolStripMenuItem.Checked)
        {
          if (null != _displayedPicture)
          {
            DrawAreasOfInterest(_displayedPicture);
            pictureImage.SetImage(_displayedPicture.PictureBitmap);
            pictureImage.Refresh();
          }
        }
        else
        {
          pictureImage.GridsSelected = null;
          _displayedPicture.RestoreBitmap();
          pictureImage.SetImage(_displayedPicture.PictureBitmap);
          pictureImage.Refresh();
        }
      }
    }

    // TODO: Just draw into the pictureImage? Move to Picture?
    private void DrawAreasOfInterest(Picture picture)
    {
      if (picture.PictureType != PictureTypes.Error)
      {
        if (showAreasOfInterestToolStripMenuItem.Checked && CurrentCam.AOI.Count() > 0)
        {
          List<GridDefinition> definitionList = new();
          foreach (AreaOfInterest area in CurrentCam.AOI)
          {
            definitionList.Add(area.Grid);
          }

          pictureImage.GridsSelected = definitionList;
          pictureImage.Invalidate();
        }
      }
    }

    private void EditAreasOfInterestToolStripMenuItem_Click(object sender, EventArgs e)
    {
    }

    void StartEditingArea(Guid areaID)
    {
      _modifyingAreaID = areaID;
      _modifyingArea = true;
      // _displayedPicture.DrawArea(CurrentCam.AOI[_modifyingAreaID].Area);
      _areaDefinition = new GridDefinition(CurrentCam.AOI[_modifyingAreaID].Grid);
      SetScreenAreaDefinition(_areaDefinition);
      pictureImage.Refresh();
      SetupEditingEnvironment("****** Creating/Modifying Area of Interest - Escape to Quit, F1 to Accept -  Number Keys (1-7) Control Brush Size ******");
    }

    void SetupEditingEnvironment(string caption)
    {
      _modifyingArea = true;
      _defineBrushSize = 1;
      ToolsPanel.BackColor = SystemColors.ControlDarkDark;
      ToolsPanel.Enabled = false;
      menuStrip2.Enabled = false;
      Text = caption;
    }

    void StopEditingEnvironment()
    {
      ToolsPanel.BackColor = SystemColors.Control;
      ToolsPanel.Enabled = true;
      menuStrip2.Enabled = true;

      _displayedPicture.RestoreBitmap();
      pictureImage.SetImage(_displayedPicture.PictureBitmap);   // TODO:
      pictureImage.Refresh();

      Text = "On Guard";
      _modifyingArea = false;
      _modifyingAreaID = Guid.Empty;

      if (_definingFace)
      {
        _modifyBox.Dispose();
        _definingFace = false;
      }


    }


    public static Rectangle ScaleDataToScreen(Rectangle rect)
    {
      Rectangle result = new((int)Math.Round(rect.X / BitmapResolution.XScale), (int)Math.Round(rect.Y / BitmapResolution.YScale), (int)Math.Round(rect.Width / BitmapResolution.XScale), (int)Math.Round(rect.Height / BitmapResolution.YScale));
      return result;
    }

    public static Point ScaleDataToScreen(Point point)
    {
      Point result = new((int)Math.Round(point.X / BitmapResolution.XScale), (int)Math.Round(point.Y / BitmapResolution.YScale));
      return result;
    }

    private async void AnalyzeButton_Click(object sender, EventArgs e)
    {
      try
      {
        await Analyze(false);
      }
      catch (Exception ex)
      { }
    }

    private async Task Analyze(bool showEverything)
    {
      if (_displayedPicture.PictureType != PictureTypes.File || string.IsNullOrEmpty(_displayedPicture.FileName))
      {
        SystemSounds.Beep.Play();
        MessageBox.Show("The currently displayed picture is not a file based picture (snapshot/error)", "Invalid Picture");
        return;
      }

      CancelAllPendingPictures();

      if (null != CurrentCam && null != _displayedPicture)
      {
        if (!_showObjects)
        {
          showObjectRectanglesToolStripMenuItem.Checked = true;
          ShowObjectRectangelsToolStripMenuItem_Click(showObjectRectanglesToolStripMenuItem, null);
        }

        List<InterestingObject> result = await AIDetection.AIFindObjectsAsync(_displayedPicture.PictureBitmap, _displayedPicture.FileName);

        if (null != result && result.Count > 0)
        {
          if (!showEverything)
          {
            AIAnalyzer.RemoveItemsOfNoInterest(CurrentCam, result);
            AIAnalyzer.RemoveDuplicateVehiclesInImage(result);
          }

          _displayedPicture.InterestingObjects = result;
          UpdateObjectList(_displayedPicture);
          _displayedPicture.DrawObjectRectangles();
          pictureImage.SetImage(_displayedPicture.PictureBitmap); // the second set, but rather than lag the picture/reg mark draw...


          if (result.Count > 0) // we may have removed some
          {
            FrameAnalyzer frameAnalyzer = new(CurrentCam.AOI, result, _displayedPicture.PictureBitmap.Width, _displayedPicture.PictureBitmap.Height);
            AnalysisResult frameResult = await frameAnalyzer.AnalyzeFrameAsync(_displayedPicture.PictureBitmap);
            using InterestingItemsDialog dlg = new(frameResult);
            dlg.ShowDialog();
          }
        }
        else
        {
          MessageBox.Show(this, "There are no objects on this picture to analyze", "Nothing Here!");
        }
      }
    }

    private async void FullAnalysisButton_Click(object sender, EventArgs e)
    {
      try
      {
        await Analyze(true);
      }
      catch (Exception ex)
      {
      }
    }


    private async Task GetLiveImageAsync(bool fromVideo)
    {
      string urlString;
      Bitmap bitmap = null;

      _continueLiveVideo = false; // dont't try again unless success

      motionOnlyCheckbox.Checked = false;

      if (CurrentCam == null)
      {
        Dbg.Write("The Current Camera was not set when getting the snapshot image");
      }
      else
      {
        CameraContactData data = CurrentCam.Contact;  // for clarity
        urlString = data.JPGSnapshotURL;

        try
        {
          urlString = CurrentCam.Contact.ReplaceParmeters(CurrentCam.Contact.JPGSnapshotURL);
          Uri uri = new(urlString);

          System.Net.HttpWebRequest webRequest = (System.Net.HttpWebRequest)HttpWebRequest.Create(uri);

          if (CurrentCam.Contact.JpgContactMethod != PTZMethod.BlueIris)
          {
            webRequest.Credentials = new System.Net.NetworkCredential(data.CameraUserName, data.CameraPassword);
          }

          webRequest.AllowWriteStreamBuffering = true;
          webRequest.Timeout = 10000;

          using (WebResponse webResponse = await webRequest.GetResponseAsync().ConfigureAwait(true))
          {
            _continueLiveVideo = true;  // allow live video to proceed since we succeeded
            using var stream = webResponse.GetResponseStream();
            using MemoryStream memStream = new();
            await stream.CopyToAsync(memStream);

            bitmap = new Bitmap(memStream);
            CreatePictureFromBitmap(bitmap, PictureTypes.Snapshot);


            if (null == bitmap)
            {
              MessageBox.Show(this, "There was an error obtaining the snapshot/video.  Please check your Live Camera settings", "Error Contacting the Camera");
              CancelAllPendingPictures();
            }
          }


          // DrawRegistrationMark();

          goToFileTextBox.Text = "Live Image";
          XResLabel.Text = bitmap.Width.ToString();
          YResLabel.Text = bitmap.Height.ToString();


        }
        catch (HttpRequestException ex)
        {
          Dbg.Write("MainWindow - LiveCameraButton_Click = Error  snapshot/live image: " + ex.Message);
          MessageBox.Show("There was an error attempting to get a snapshot.  Please check your camera Live Camera tab and make sure the settings for your camera are correct: " + ex.Message, "Error obtaining snapshot");
        }
        catch (WebException ex)
        {
          if (null != _liveTimer)
          {
            _liveTimer.Stop();
            _liveTimer.Dispose();
            _liveTimer = null;
            liveCheck.Checked = false;
          }
          Dbg.Write("MainWindow - There was an error attempting to get a snapshot or continuous video.  Please check your camera Live Camera tab and make sure the settings for your camera are correct: " + ex.Message);
          if (fromVideo)
          {
            MessageBox.Show("There was an error attempting to access your camera for continuous video.  Please check your camera Live Camera tab and make sure the settings for your camera are correct: " + ex.Message, "Error Getting Video");
          }
          else
          {
            MessageBox.Show("There was an error attempting to get a snapshot.  Please check your camera Live Camera tab and make sure the settings for your camera are correct: " + ex.Message, "Error obtaining snapshot");
          }
        }
      }
    }



    private async void LiveCameraButton_Click(object sender, EventArgs e)
    {
      await GetLiveImageAsync(false);
    }

    private async void OnLiveImageTimer(Object o, EventArgs e)
    {
      if (_continueLiveVideo)
      {
        try
        {
          await GetLiveImageAsync(true);
        }
        catch (IOException ex)
        {
          // Just do nothing.  Sometimes the camera does this
        }
      }
    }

    private void LiveCheck_CheckedChanged(object sender, EventArgs e)
    {
      motionOnlyCheckbox.Checked = false;
      if (liveCheck.Checked)
      {
        showObjectRectanglesToolStripMenuItem.Checked = false;
        showAreasOfInterestToolStripMenuItem.Checked = false;
        _showObjects = false;
        _liveTimer = new System.Windows.Forms.Timer
        {
          Interval = 100
        };
        _liveTimer.Tick += OnLiveImageTimer;
        _continueLiveVideo = true;
        _liveTimer.Start();
      }
      else
      {
        CancelAllPendingPictures();
        _continueLiveVideo = false;
        _liveTimer?.Dispose();
        _liveTimer = null;
      }
    }



    async Task CameraDirectionButtonAsync(CameraDirections direction)
    {
      bool success = false;
      int stopDelay = 0;
      string urlString = string.Empty;

      if (null != CurrentCam)
      {
        CameraContactData data = CurrentCam.Contact;


        motionOnlyCheckbox.Checked = false;

        if (data.PTZContactMethod == PTZMethod.OnVIF)
        {
          try
          {
            Mictlanix.DotNet.Onvif.Common.PTZSpeed speed = new();
            Mictlanix.DotNet.Onvif.Common.Vector2D vector = new();
            Mictlanix.DotNet.Onvif.Common.Vector1D zoomVector = new();
            int t = 0;

            switch (direction)
            {
              case CameraDirections.left:

                vector.x = (float)(-1.0 * data.PanSpeed);
                t = (int)(1000 * data.PanTime);
                break;

              case CameraDirections.right:
                vector.x = (float)(data.PanSpeed);
                t = (int)(1000 * data.PanTime);
                break;

              case CameraDirections.up:
                vector.y = (float)(data.TiltSpeed);
                t = (int)(1000.0 * data.TiltTime);
                break;

              case CameraDirections.down:
                vector.y = (float)(-1 * data.TiltSpeed);
                t = (int)(1000 * data.TiltTime);
                break;

              case CameraDirections.zoomIn:
                zoomVector.x = (float)(data.ZoomSpeed);
                break;

              case CameraDirections.zoomOut:
                zoomVector.x = (float)(-1.0 * data.ZoomSpeed);
                t = (int)(1000 * data.ZoomTime);
                break;
            }

            speed.PanTilt = vector;
            speed.Zoom = zoomVector;

            await data.ONVIF.Ptz.ContinuousMoveAsync(data.ONVIF.SelectedProfile, speed, 3000.ToString());
            await Task.Delay(t).ConfigureAwait(true);
            await data.ONVIF.Ptz.StopAsync(data.ONVIF.SelectedProfile, true, true);
            LiveCameraButton_Click(null, null);
          }
          catch (Exception ex)
          {
            Dbg.Write("CameraDirectionButton - OnVIF - Exception: " + ex.Message);
          }
        }
        else
        {

          if (data.PTZContactMethod == PTZMethod.BlueIris)
          {
            string pw = data.CameraPassword;
            pw = HttpUtility.UrlEncode(pw);


            urlString = string.Format("http://{0}:{1}/cam/{2}/pos={3}&user={4}&pw={5}", data.CameraIPAddress,
                     data.Port.ToString(),
                    HttpUtility.UrlEncode(data.CameraShortName), (int)direction,
                    data.CameraUserName,
                    pw);

          }
          else
          {
            // Both iSpy and HTTP methods use http directions
            switch (direction)
            {
              case CameraDirections.left:
                urlString = data.HTTPPanLeft;
                stopDelay = (int)(data.PanTime * 1000.0);
                break;

              case CameraDirections.right:
                urlString = data.HTTPPanRight;
                stopDelay = (int)(data.PanTime * 1000.0);
                break;

              case CameraDirections.up:
                urlString = data.HTTPPanUp;
                stopDelay = (int)(data.TiltTime * 1000.0);
                break;

              case CameraDirections.down:
                urlString = data.HTTPPanDown;
                stopDelay = (int)(data.TiltTime * 1000.0);
                break;

              case CameraDirections.zoomIn:
                urlString = data.HTTPZoomIn;
                stopDelay = (int)(data.ZoomTime * 1000.0);
                break;

              case CameraDirections.zoomOut:
                urlString = data.HTTPZoomOut;
                stopDelay = (int)(data.ZoomTime * 1000.0);
                break;
            }

            urlString = data.ReplaceParmeters(urlString);
          }
        }

        try
        {
          System.Net.HttpWebRequest webRequest = (HttpWebRequest)HttpWebRequest.Create(new Uri(urlString));

          if (data.JpgContactMethod != PTZMethod.BlueIris)
          {
            // Blue Iris uses the Blue Iris user/password, which is not the same as the blue iris machine user/pawword
            webRequest.Credentials = new System.Net.NetworkCredential(data.CameraUserName, data.CameraPassword);
          }

          webRequest.AllowWriteStreamBuffering = true;
          webRequest.Timeout = 5000;

          System.Net.WebResponse webResponse = await webRequest.GetResponseAsync().ConfigureAwait(true);

          var stream = webResponse.GetResponseStream();
          webResponse.Close();
          success = true;

        }
        catch (HttpRequestException ex)
        {
          Dbg.Write("MainWindow - CameraDirectionButton - HttpRequestException: " + ex.Message);
        }
        catch (Exception ex)
        {
          Dbg.Write("MainWindow - CameraDirectionButton - Unexpected Exception: " + ex.Message);
        }

        if (success)
        {
          // PTZ was started.  However, we may need to stop it after the set time
          if (data.PTZContactMethod == PTZMethod.OnVIF)
          {
            await Task.Delay(stopDelay).ConfigureAwait(true);
          }
          else if (data.PTZContactMethod == PTZMethod.HTTP || data.PTZContactMethod == PTZMethod.iSpy)
          {
            if (!string.IsNullOrEmpty(data.HTTPStop))
            {
              await Task.Delay(stopDelay).ConfigureAwait(true);

              System.Net.HttpWebRequest webRequest = (HttpWebRequest)HttpWebRequest.Create(new Uri(urlString));

              if (data.JpgContactMethod != PTZMethod.BlueIris)
              {
                webRequest.Credentials = new System.Net.NetworkCredential(data.CameraUserName, data.CameraPassword);
              }

              webRequest.AllowWriteStreamBuffering = true;
              webRequest.Timeout = 30000;

              System.Net.WebResponse webResponse = await webRequest.GetResponseAsync().ConfigureAwait(true);

              var stream = webResponse.GetResponseStream();
              webResponse.Close();
            }

          }

          // Now, display the image (which may or may not have been fully updated)
          await Task.Delay(1000 * 2).ConfigureAwait(true);
          LiveCameraButton_Click(null, null);
        }
      }
    }

    private async void CamZoomOut_Click(object sender, EventArgs e)
    {
      await CameraDirectionButtonAsync(CameraDirections.zoomOut).ConfigureAwait(true);
    }

    private async void CamDownButton_Click(object sender, EventArgs e)
    {
      await CameraDirectionButtonAsync(CameraDirections.down).ConfigureAwait(true);
    }

    private async void ZoomInButton_Click(object sender, EventArgs e)
    {
      await CameraDirectionButtonAsync(CameraDirections.zoomIn).ConfigureAwait(true);
    }

    private async void CamUpButton_Click(object sender, EventArgs e)
    {
      await CameraDirectionButtonAsync(CameraDirections.up).ConfigureAwait(true);
    }

    private async void CamLeftButton_Click(object sender, EventArgs e)
    {
      await CameraDirectionButtonAsync(CameraDirections.left).ConfigureAwait(true);
    }

    private async void CamRightButton_Click(object sender, EventArgs e)
    {
      await CameraDirectionButtonAsync(CameraDirections.right).ConfigureAwait(true);
    }


    private void SettingsToolStripMenuItem_Click(object sender, EventArgs e)
    {
      using SettingsDialog dlg = new();
      if (dlg.ShowDialog() == DialogResult.OK)
      {
      }
    }


    /// <summary>
    /// Events for all cameras come in here as a file is changed in the directory we are watching
    /// Just put it in the queue and we will process it in a different thread 
    /// </summary>
    /// <param name="camera"></param>
    /// <param name="fileName"></param>
    void OnCameraImage(CameraData camera, string fileName)
    {
      if (_filesPendingProcessing.TryAdd(fileName, fileName))
      {
        _fileQueue.Enqueue(new PendingItem(camera, fileName));
        _wakeFileQueue.Set(); // Wake up the queue monitoring thread.  Maybe it can process it right now
      }

    }

    // Here we passed all of the tests from the AI and have compared the objects to the AOIs.
    // Now, we need to figure out who to notify and notify them

    async Task NotifyAsync(Frame frame)
    {
      // Url notification is (right now)  oriented toward notifying BlueIris cameras to record.
      // So, there is no sense notifying it multiple times.  However, different areas
      // may have different cool down times, etc.  
      // So, we go through the list and take note of all urls to notify
      // The hashset will not accept duplicates.
      string fileName = frame.Item.PendingFile;

      List<UrlOptions> urlsToNotify = new();
      string objectsFound = string.Empty;

      bool first = true;
      foreach (var ooi in frame.Interesting)
      {
        if (!first)
        {
          objectsFound += ", ";
        }

        first = false;

        objectsFound += ooi.Area.AOIName;

        if (ooi.Area.Notifications.UseMQTT)
        {
          /*if (ooi.Area.Notifications.mqttCooldown.CooldownExpired())
          {*/
          await MQTTPublish.Publish(frame.Item.CamData.CameraPrefix, ooi.Area, frame, ooi).ConfigureAwait(true);
          /*}*/
        }

        if (null != ooi.Area.Notifications)
        {
          foreach (var notifyUrl in ooi.Area.Notifications.Urls)
          {
            if (notifyUrl.CoolDown.CooldownExpired())
            {
              urlsToNotify.Add(notifyUrl);
            }
            else
            {
              Dbg.Trace("In cooldown: " + ooi.Area.AOIName + " - " + frame.Item.PendingFile);
            }
          }
        }
      }

      foreach (var notify in urlsToNotify)
      {
        string urlStr;
        string confirmStr = string.Empty;

        if (notify.Url.Contains("{Auto Fill"))
        {
            urlStr = string.Format("http://{0}:{1}/admin?trigger&camera={2}&user={3}&pw={4}&jpeg={5}&memo={6}",
            frame.Item.CamData.Contact.CameraIPAddress,
            frame.Item.CamData.Contact.Port,
            HttpUtility.UrlEncode(frame.Item.CamData.Contact.CameraShortName),
            HttpUtility.UrlEncode(frame.Item.CamData.Contact.CameraUserName),
            HttpUtility.UrlEncode(frame.Item.CamData.Contact.CameraPassword),
            HttpUtility.UrlEncode(fileName),
            objectsFound);


          if ((int)notify.BIFlags > 0)
          {
            int flags = (int)notify.BIFlags;
            if (notify.BIFlags == (int)BIFLAGS.Reset)
            {
              flags = -1; // just clearer
            }

            confirmStr = string.Format("http://{0}:{1}/admin?camera={2}&user={3}&pw={4}&flagalert={5}&jpeg={6}&flagclip",
            frame.Item.CamData.Contact.CameraIPAddress,
            frame.Item.CamData.Contact.Port,
            HttpUtility.UrlEncode(frame.Item.CamData.Contact.CameraShortName),
            HttpUtility.UrlEncode(frame.Item.CamData.Contact.CameraUserName),
            HttpUtility.UrlEncode(frame.Item.CamData.Contact.CameraPassword),
            flags,
            HttpUtility.UrlEncode(fileName));

          }
        }
        else
        {
          urlStr = notify.Url;
        }


        _test = frame;

        if (notify.WaitTime > 0)
        {
          Dbg.Trace("Delaying: " + notify.WaitTime.ToString() + " before sending url " + urlStr);
          await Task.Delay(1000 * notify.WaitTime).ConfigureAwait(true);
        }

        // Do the standard notify
        await NotifyUrlAsync(urlStr).ConfigureAwait(true);
        Dbg.Trace("Sent URL Notification: " + urlStr);

        if (!string.IsNullOrEmpty(confirmStr))
        {
          await NotifyUrlAsync(confirmStr).ConfigureAwait(true);
          Dbg.Trace("Sent BI Notification: " + confirmStr);
        }
      }

    }


    static async Task NotifyUrlAsync(string urlStr)
    {
      using HttpClient client = new();
      try
      {
        client.Timeout = TimeSpan.FromSeconds(20.0);
        Uri url = new(urlStr);
        HttpResponseMessage response = await client.GetAsync(url).ConfigureAwait(true);
        if (response.IsSuccessStatusCode)
        {
          Dbg.Trace("Successfully notified URL: " + urlStr);
        }
        else
        {
          Dbg.Write("Error notifying URL: " + urlStr + " -- Reponse Code: " + response.StatusCode.ToString());
        }

        response.Dispose();
      }
      catch (HttpRequestException ex)
      {
        Dbg.Write("MainWindow - NotifyUrl - Exception caught in NotifyUrl: " + ex.Message);
      }
      catch (Exception ex)
      {
        Dbg.Write("MainWindow - NotifyUrl - Unknown Exception caught in NotifyUrl: " + ex.Message);
      }
    }

    // Currently unused, but it may be in the future
    static async Task NotifyViaEmailAsync(string emailRecipients, HashSet<string> acvityDesc, string fileName)
    {

      try
      {
        using MailMessage mail = new();
        using SmtpClient SmtpServer = new(Storage.Instance.GetGlobalString("EmailServer"));
        mail.BodyEncoding = Encoding.UTF8;
        mail.IsBodyHtml = true;
        mail.From = new MailAddress(Storage.Instance.GetGlobalString("EmailUser"));
        string rec = emailRecipients.TrimEnd(new char[] { ';', ' ' });
        mail.To.Add(rec);
        mail.Subject = "Security Camera Alert";   // todo get via ui
        mail.Body = "Your security camera noticed the following activity:<br />";

        foreach (var desc in acvityDesc)
        {
          mail.Body += desc + "<br/>";
        }

        System.Net.Mail.Attachment attachment;
        attachment = new System.Net.Mail.Attachment(fileName);
        mail.Attachments.Add(attachment);

        SmtpServer.Port = Storage.Instance.GetGlobalInt("EmailPort");

        SmtpServer.Port = Storage.Instance.GetGlobalInt("EmailPort");
        string emailUserName = Storage.Instance.GetGlobalString("EmailUser");
        string emailPassword = Storage.Instance.GetGlobalString("EmailPassword");

        if (!string.IsNullOrEmpty(emailUserName))
        {
          SmtpServer.Credentials = new System.Net.NetworkCredential(emailUserName, emailPassword);
        }

        SmtpServer.EnableSsl = Storage.Instance.GetGlobalBool("EmailSSL");

        await SmtpServer.SendMailAsync(mail).ConfigureAwait(true);
      }
      catch (SmtpException ex)
      {
        Dbg.Write("MainWindow - NotifyViaEmail - Email exception: " + ex.ToString());
      }
    }


    private async void PresetButton_Click(object sender, EventArgs e)
    {
      if (null != CurrentCam)
      {
        CameraContactData data = new(CurrentCam.Contact);

        if (PresetsCombo.Items.Count > 0)
        {
          string urlString = string.Empty;
          int preset = PresetsCombo.SelectedIndex;

          using WaitCursor _ = new();
          motionOnlyCheckbox.Checked = false;

          if (CurrentCam.Contact.PresetSettings.PresetMethod == PTZMethod.OnVIF)
          {
            await data.ONVIF.Ptz.GotoPresetAsync(
              data.ONVIF.SelectedProfile,
              data.PresetSettings.PresetList[preset].Command,
              null);

            await Task.Delay(1000 * 5).ConfigureAwait(true);
            LiveCameraButton_Click(null, null);

          }
          else
          {
            if (CurrentCam.Contact.PresetSettings.PresetMethod == PTZMethod.BlueIris)
            {

              urlString = string.Format("http://[ADDRESS]/admin?camera=[SHORTNAME]&preset={0}&user=[USERNAME]&pw=[PASSWORD]",
                CurrentCam.Contact.PresetSettings.PresetList[preset].Command);

              urlString = CurrentCam.Contact.ReplaceParmeters(urlString);
            }
            else if (CurrentCam.Contact.PresetSettings.PresetMethod == PTZMethod.HTTP)
            {
              urlString = CurrentCam.Contact.PresetSettings.PresetList[0].Command;  // always use the first preset because we sub in the preset;
              urlString = CameraData.GetHttpParam(urlString, preset);
            }
            else
            {
              urlString = CurrentCam.Contact.PresetSettings.PresetList[preset].Command;
            }

            try
            {
              urlString = CurrentCam.Contact.ReplaceParmeters(urlString);
              System.Net.HttpWebRequest webRequest = (HttpWebRequest)HttpWebRequest.Create(new Uri(urlString));

              if (CurrentCam.Contact.JpgContactMethod != PTZMethod.BlueIris)
              {
                webRequest.Credentials = new System.Net.NetworkCredential(CurrentCam.Contact.CameraUserName, CurrentCam.Contact.CameraPassword);
              }

              webRequest.Timeout = 30000;

              using System.Net.WebResponse webResponse = await webRequest.GetResponseAsync().ConfigureAwait(true);
            }
            catch (HttpRequestException ex)
            {
              Dbg.Write("MainWindow - PresetButton_Click - HttpWebRequest - " + ex.Message);
            }
            catch (Exception ex)
            {
              Dbg.Write("MainWindow - PresetButton_Click - HttpWebRequest - " + ex.Message);
            }

          }
          await Task.Delay(1000 * 5).ConfigureAwait(true);
          LiveCameraButton_Click(null, null);
        }
      }
    }

    private void NotificationOptionsToolStripMenuItem_Click(object sender, EventArgs e)
    {
      //NotificationOptionsDialog dlg = new NotificationOptionsDialog(_areaNotifications);
      //DialogResult result = dlg.ShowDialog();
    }

    private async void CameraSettingsToolStripMenuItem_Click(object sender, EventArgs e)
    {
      // Disconnect the monitoring from all monitoring cameras.
      foreach (var cam in _allCameras.CameraDictionary.Values)
      {
        if (cam.Monitoring)
        {
          if (null != cam.Monitor)
          {
            cam.Monitor.OnNewImage -= OnCameraImage;
          }
        }

        switch (cam.CameraInputMethod)
        {
          case CameraMethod.OnGuard:
            cam.Scanner.Dispose();
            cam.Scanner = null;
            break;

          case CameraMethod.CameraTriggered:
            cam.CameraTrigger?.Dispose();
            cam.CameraTrigger = null;
            break;
        }

      }

      using CameraCollection tmp = CameraCollection.CopyFactory(_allCameras);
      tmp.StopMonitoring();

      _allCameras.Dispose();  // This cleans up the directory monitoring, and a lot of other stuff
      _allCameras = null;
      cameraCombo.Items.Clear();

      using (CameraConfigurationDialog dlg = new(tmp))  // This makes a deep copy of the cameras collection
      {
        DialogResult result = dlg.ShowDialog();

        if (result == DialogResult.OK)
        {
          _allCameras = dlg.AllCameraData;  // a reference, not a copy (since the dialog does a deep copy, and we want the altered one)
          Storage.Instance.SaveCameras(_allCameras);

          if (null == dlg.SelectedCamera)
          {
            Storage.Instance.SetGlobalString("CurrentCameraPath", string.Empty);    // we don't need to do this if we canceled the dlg
            Storage.Instance.SetGlobalString("CurrentCameraPrefix", string.Empty);
            Storage.Instance.Update();
          }
          else
          {
            await SetCurrentCameraAsync(dlg.SelectedCamera);   // The one set by the dialog
          }
        }
        else
        {
          _allCameras = CameraCollection.CopyFactory(tmp);
        }
      }

      // Restore the camera selection dropdown
      foreach (var cam in _allCameras.CameraDictionary.Values)
      {
        cameraCombo.Items.Add(cam);
      }

      if (null != CurrentCam && !string.IsNullOrEmpty(CurrentCam.CameraPrefix))
      {
        cameraCombo.SelectedItem = CurrentCam;
      }

      await _allCameras.InitAsync();

      // And reconnnect all cameras to this form for new images
      foreach (var cam in _allCameras.CameraDictionary.Values)
      {
        if (cam.Monitoring)
        {
          cam.Monitor.OnNewImage += OnCameraImage;
        }
      }
    }

    private async Task SetCurrentCameraAsync(CameraData cam)
    {
      _allCameras.CurrentCameraPath = CameraData.PathAndPrefix(cam);    // which sets the current camera in _allCameras
      Storage.Instance.SetGlobalString("CurrentCameraPath", cam.CameraPath);
      Storage.Instance.SetGlobalString("CurrentCameraPrefix", cam.CameraPrefix);
      Storage.Instance.Update();
      await InitAnalyzerAsync(cam.CameraPrefix, cam.CameraPath, cam.MonitorSubdirectories).ConfigureAwait(true);
      SetPresetList();
      timeLine.Init(_fileNames);
      EnablePTZ();

    }

    private void OutgoingEmailServerToolStripMenuItem_Click(object sender, EventArgs e)
    {
      using OutgoingEmailDialog dlg = new();
      dlg.ShowDialog();
    }

    private async void SyncToDatabase(object sender, EventArgs e)
    {
      if (!syncToDatabaseToolStripMenuItem.Checked)
      {
        syncToDatabaseToolStripMenuItem.Text = "Sync Motion to Database";
        SyncToDB.StopSync();
      }
      else
      {
        using SyncToDatabaseDialog dlg = new();
        DialogResult result = dlg.ShowDialog();
        if (result == DialogResult.OK)
        {
          syncToDatabaseToolStripMenuItem.Text = "Stop Sync to Database";
          await Task.Run(() => SyncToDB.PerformSyncDBAsync(CurrentCam, dlg.Interval, _directionUp, DBConnection.GetConnectionString(), _stopEvent)).ConfigureAwait(false);
          UpdateMenuItem(syncToDatabaseToolStripMenuItem, "Sync Motion to Database", 0);
        }
        else
        {
          syncToDatabaseToolStripMenuItem.Checked = false;
        }
      }
    }

    delegate void RefreshDelegate(object sender, EventArgs e);
    private async void Refresh_Click(object sender, EventArgs e)
    {
      _moveDirection = MovementDirection.Still;
      if (!this.InvokeRequired)
      {
        using WaitCursor _ = new();
        _loading = true;
        await InitAnalyzerAsync(CurrentCam.CameraPrefix, CurrentCam.CameraPath, CurrentCam.MonitorSubdirectories).ConfigureAwait(true);
        timeLine.Init(_fileNames);
        SetCurrent(0);
        _loading = false;
      }
      else
      {
        BeginInvoke(new RefreshDelegate(Refresh_Click), new object[] { null, null });
      }
    }

    private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
    {
      using AboutDialog dlg = new();
      dlg.ShowDialog();
    }


    private void UpdateCPULoad(int cpuLoad)
    {
      if (cpuProgress.InvokeRequired)
      {
        BeginInvoke(new SetProgressDelegate(UpdateCPULoad), new object[] { cpuLoad });
        return;

      }

      Color barColor;
      if (cpuLoad < 50)
      {
        barColor = Color.LightGreen;
      }
      else if (cpuLoad < 75)
      {
        barColor = Color.DarkOrange;
      }
      else
      {
        barColor = Color.Red;
      }

      cpuProgress.SetContents(barColor, cpuLoad, cpuLoad.ToString());

    }



    // The purpose of this thread is to periodically examine the queue of files waiting to
    // be processed by the AI.  The AI is by no means fast (Windows -Linux is fine if you have an NVidia and setup the GPU for processing)
    // If there is an item to be processed, and IF the AI is not too far behind we dispatch the file to the AI.
    // The thread will wake up when an item is added to the queue.
    void MonitorQueue()
    {

      bool stopIt = false;
      WaitHandle[] waitFor = new WaitHandle[2];
      waitFor[0] = _stopEvent;
      waitFor[1] = _wakeFileQueue;
      bool keepgoing = false;
      int yieldCount = 0;
      DateTime lastCPUUpdate = DateTime.Now;
      double snapshotInterval = Storage.Instance.GetGlobalDouble("FrameInterval");
      const int tryInterval = 200;  // time in ms to wait for the next try
      const int maxYield = 0 * 1000 / tryInterval;

      List<Task> taskList = new();

      while (!stopIt)
      {
        stopIt = _stopEvent.WaitOne(0);
        if (stopIt) break;

        DateTime startLoop = DateTime.Now;
        theCPUCounter.NextValue();
        if (!keepgoing) // Only wait if there was nothing in the queue
        {
          var waitResult = WaitHandle.WaitAny(waitFor, tryInterval);  // Monitor the queue 5 times per second

          if (waitResult == 0)
          {
            stopIt = true;
            break; // The stop event was triggered
          }
        }

        // Here we either have an item added (waitResut = 1) or we timed out
        // Either way we just see if there are any items ready to go.

        int currentCPU = (int)theCPUCounter.NextValue(); // This needs to be called twice (1 above).  If the wait times out the interval may be minimal, but...
        if ((DateTime.Now - lastCPUUpdate).TotalSeconds >= 3)
        {
          UpdateCPULoad(currentCPU);
          lastCPUUpdate = DateTime.Now;
        }


        int countOfPending = _fileQueue.Count;

        if (countOfPending > 0)
        {

          // we have a file, but how busy are things?
          if (0 == currentCPU)
          {
            Thread.Sleep(1);
            currentCPU = (int)theCPUCounter.NextValue();  /// sometimes not valid (0 is suspect) ?
          }

          // If we have CPU time, or failing that if our recent times are within reason of our target, then start processing.
          // Ideally we would like to process as many frames per second as the target fps.  However,
          // the AI can be slow.  So, if we have CPU and we are within a reasonable percentage of the
          // target fps then we go ahead and start processing one.  If we wait for CPU we might not process anything
          // because other processes might kick us around (take up time we could be using).  If we shove too many frames down
          // the AI pipleline then processing on the rest of the computer may get very bogged down/unresponsive.  So, we
          // make a reasonable guess at how often to process things.  For starters the average times 1.25 times fps is a good guess
          // Note that the AI may be on a different machine.  In that case the CPU usage is (mostly) irrelevant.
          // TODO: Check to see if the AI is on this machine.  In that case rely solely on the fps factor.
          // Note that in many cases processing a new saved frame instantly may not be too important because
          // other frames may give us the photo we want and/or you can tell Blue Iris to start recording a few seconds
          // (or more) ahead of the trigger we send it.
          double recent = _recentTimes.Avg();   // so we can see it debugging
          if (yieldCount > maxYield || (recent < (10.0 * snapshotInterval)))
          {

            yieldCount = 0;
            if (_fileQueue.TryDequeue(out PendingItem pendingItem))
            {
              TimeSpan inLoop = DateTime.Now - startLoop;
              keepgoing = true;
              DateTime beginStart = DateTime.Now;
              pendingItem.TimeDispatched = beginStart;
              Interlocked.Increment(ref _imagesBeingProcessed);

              if (null != _allCameras)  // If we are going into camera setup we do not process more files
              {
                var myTask = Task.Run(() => StartAIAnalysisAsync(pendingItem)).ConfigureAwait(true);
              }
            }
          }
          else
          {
            keepgoing = false;
            ++yieldCount;
          }
        }
        else
        {
          keepgoing = false;
        }
      }

    }

    private delegate void UpdateProcessedDelegate(int processed);
    void UpdateNumberProcessed(int processed)
    {
      if (numberOfImagesLabel.InvokeRequired)
      {
        BeginInvoke(new UpdateProcessedDelegate(UpdateNumberProcessed), new object[] { processed });
        return;
      }

      numberOfImagesLabel.Text = processed.ToString();
    }



    // The FileWatcher stuff gives us a file name, but the file may not have completed writing
    private async Task<Tuple<int, int>> WaitForFileReadyAsync(PendingItem pending)
    {
      bool continueTrying;
      Tuple<int, int> result = null;

      do
      {
        continueTrying = true;

        try
        {
          pending.PictureImage = new Bitmap(pending.PendingFile);
          result = new Tuple<int, int>(pending.PictureImage.Width, pending.PictureImage.Height);
          continueTrying = false;
        }
        catch (IOException)
        {
          continueTrying = true;
          await Task.Delay(10).ConfigureAwait(true);
        }
        catch (ArgumentException ex)
        {
          continueTrying = true;
          await Task.Delay(10).ConfigureAwait(true);
        }
        catch (Exception ex)
        {
          Type t = ex.GetType();
          Dbg.Trace("WaitForFileRead exception of type  " + t.ToString());
        }
      } while (continueTrying);

      return result;
    }

    async Task StartAIAnalysisAsync(PendingItem pendingItem)
    {
      int xRes = 0;
      int yRes = 0;

      if (await HandleTriggerFilesAsync(pendingItem))
      {
        return;
      }

      if (_filesPendingProcessing.ContainsKey(pendingItem.PendingFile))
      {
        // By definition it should be in this list, but ....
        Dbg.Trace("StartAIAnalysis - Starting ready check for file: " + pendingItem.PendingFile);
        Tuple<int, int> waitResult = await WaitForFileReadyAsync(pendingItem).ConfigureAwait(true);
        xRes = waitResult.Item1;
        yRes = waitResult.Item2;
      }
      else
      {
        Dbg.Trace("StartAIAnalysis - File not in queue for analysis - already processed?");
        return;
      }

      if (!_filesPendingProcessing.TryRemove(pendingItem.PendingFile, out string f))
      {
        Dbg.Trace("MainWindow StartAIAnalysis - failed to remove from pending file list: " + pendingItem.PendingFile);
      }

      AIResult result;
      try
      {
        result = await AIDetection.DetectObjectsAsync(pendingItem).ConfigureAwait(true);
        lock (_aiNotFoundLock)
        {
          if (Storage.Instance.GetGlobalBool("SentAIGoneEmail"))
          {
            Storage.Instance.SetGlobalBool("SentAIGoneEmail", false);
            Storage.Instance.Update();
            UpdateControlText(AIStatus, "Connected");
            UpdateControlColor(AIStatus, Color.LightGreen);
          }
        }
      }
      catch (AggregateException ex)
      {
        return;
      }
      catch (AiNotFoundException ex)
      {
        Task.Run(() => NotifyAIGone()).ConfigureAwait(false); ;
        return;
      }
      UpdateFrameProgressBar(DateTime.Now - pendingItem.TimeDispatched);

      if (null == result)
      {
        return;
      }


      if (null == _allCameras)
      {
        // we went into camera setup, we can't process any further
        return;
      }

      Interlocked.Increment(ref _numberOfImagesProcessed);
      UpdateNumberProcessed(_numberOfImagesProcessed);
      _recentTimes.AddValue(result.Item.AIProcessingTime().TotalMilliseconds);

      Interlocked.Decrement(ref _imagesBeingProcessed);
      List<InterestingObject> interesting = null;
      Frame frame = new(pendingItem, interesting);

      if (null != result.ObjectsFound)  // Did we find any objects the AI could recognize?
      {
        // Analyze the frame with respect to the areas of interest for this camera only.
        // However, note (currently) that you can in theory have multiple "cameras" using the same prefix but different file paths.
        // In that case we use the same AOI

        if (null != pendingItem.CamData)
        {
          Dbg.Trace("The AI Found: " + result.ObjectsFound.Count.ToString() + " Total Objects");
          _analyzer.RemoveInvalidObjects(pendingItem.CamData, result.ObjectsFound);  // This may remove items from the list, and may zero it out

          if (result.ObjectsFound.Count > 0)
          {
            Dbg.Trace("Starting FRAME analysis of file: " + pendingItem.PendingFile + " with: " + result.ObjectsFound.Count.ToString() + " objects");

            FrameAnalyzer frameAnalyzer = new(pendingItem.CamData.AOI, result.ObjectsFound, xRes, yRes);
            AnalysisResult analysisResult = await frameAnalyzer.AnalyzeFrameAsync(pendingItem.PictureImage);
            interesting = analysisResult.InterestingObjects;  // find if the objects we did find are interesting (relatively fast)

            frame.Interesting = interesting;
            Dbg.Write(interesting.Count.ToString() + " interesting objects found in file: " + pendingItem.PendingFile);


            if (interesting.Count > 0)
            {
              StartMotionTimeout(pendingItem);
            }

            if (frame.Interesting.Count > 0)
            {
              var myTask = Task.Run(() => AddToMotionFramesTableAsync(pendingItem)).ConfigureAwait(true);
            }

            await NotifyAsync(frame);
          }
        }
      }

      pendingItem.PictureImage.Dispose();
      pendingItem.PictureImage = null;

      ProcessAccumulation(frame);
    }

    private async Task<bool> HandleTriggerFilesAsync(PendingItem pending)
    {
      bool isTriggerImage = false;
      bool usedAsTrigger = false;
      try
      {
        if (pending.CamData.CameraInputMethod == CameraMethod.CameraTriggered)
        {
          string pictureName = Path.GetFileName(pending.PendingFile);
          if (pictureName.Length > pending.CamData.TriggerPrefix.Length)
          {
            if (pictureName[..pending.CamData.TriggerPrefix.Length] == pending.CamData.TriggerPrefix)
            {
              isTriggerImage = true;
            }
          }

          if (isTriggerImage)
          {
            if (null != pending.CamData.CameraTrigger)
            {
              isTriggerImage = true;
              // This picture is on a trigger type camera and the file name is the type we are interested in.
              PendingItem item = new(pending.CamData, pending.PendingFile);
              await WaitForFileReadyAsync(item); // just wait for the file to be done downloading from the camera
              item.PictureImage.Dispose();  // we created a bitmap we don't need (now) TODO: some other wait that doesn't create a bitmap may be worth it
              if (pending.CamData.CameraTrigger.CanTrigger())
              {
                // so we pickup the picture the camera sent us, we rename it to the prefix we use;
                pictureName = pictureName.Replace(pending.CamData.TriggerPrefix, pending.CamData.CameraPrefix);  // change prefixes
                string outputPath = Path.Combine(pending.CamData.CameraPath, pictureName);
                try
                {
                  File.Move(pending.PendingFile, outputPath);  // rename (and maybe really move) the file so that we can pick it up as a normal camera file.
                }
                catch (Exception ex)
                {
                  Dbg.Write("MainWindow - OnCameraImage - Exception renaming trigger file: " + ex.Message);
                }

                usedAsTrigger = true;
                pending.CamData.CameraTrigger.Trigger();
              }
              else
              {
                File.Delete(pending.PendingFile);  // TODO: really delete the camera download
              }
            }
          }
        }

        if (!usedAsTrigger)
        {
        }
      }
      catch (Exception ex)
      {
        Dbg.Write("MainWindow - OnCameraImage - Exception: " + ex.Message);
      }

      return usedAsTrigger;

    }

    private delegate void UpdateNumericDelgate(NumericUpDown control, int value);
    private void UpdateNumericValue(NumericUpDown control, int value)
    {
      if (this.InvokeRequired)
      {
        BeginInvoke(new UpdateNumericDelgate(UpdateNumericValue), new object[] { control, value });
        return;
      }

      control.Value = value;
    }


    private delegate void UpdateControlTextDelgate(Control control, string text);
    private void UpdateControlText(Control control, string text)
    {
      if (this.InvokeRequired)
      {
        BeginInvoke(new UpdateControlTextDelgate(UpdateControlText), new object[] { control, text });
        return;
      }

      control.Text = text;
    }

    private delegate void UpdateControlColorDelgate(Control control, Color color);
    private void UpdateControlColor(Control control, Color color)
    {
      if (this.InvokeRequired)
      {
        BeginInvoke(new UpdateControlColorDelgate(UpdateControlColor), new object[] { control, color });
        return;
      }

      control.BackColor = color;
    }

    private delegate Task TaskDelegate();
    private async Task NotifyAIGone()
    {
      if (this.InvokeRequired)
      {
        this.BeginInvoke(new TaskDelegate(NotifyAIGone));
        return;
      }

      AIStatus.Text = "Disconnected";
      AIStatus.BackColor = Color.Red;

      string emailRecipient = Storage.Instance.GetGlobalString("NotifyAIGoneEmail");
      bool sentEmailGone;

      lock (_aiNotFoundLock)  // because it may take a while to update the state
      {
        sentEmailGone = Storage.Instance.GetGlobalBool("SentAIGoneEmail");
        if (!sentEmailGone)
        {
          Storage.Instance.SetGlobalBool("SentAIGoneEmail", true);
          Storage.Instance.Update();
        }
      }

      if (!sentEmailGone)
      {
        if (!string.IsNullOrEmpty(emailRecipient))
        {
          try
          {
            using MailMessage mail = new();
            using SmtpClient SmtpServer = new(Storage.Instance.GetGlobalString("EmailServer"));
            mail.BodyEncoding = Encoding.UTF8;
            mail.IsBodyHtml = true;
            mail.From = new MailAddress(Storage.Instance.GetGlobalString("EmailUser"));
            mail.To.Add(emailRecipient);
            mail.Subject = "Security Camera AI Gone!";   // todo get via ui
            mail.Body = "Your security camera AI Servers are Dead!";

            SmtpServer.Port = Storage.Instance.GetGlobalInt("EmailPort");
            string emailUserName = Storage.Instance.GetGlobalString("EmailUser");
            string emailPassword = Storage.Instance.GetGlobalString("EmailPassword");

            if (!string.IsNullOrEmpty(emailUserName))
            {
              SmtpServer.Credentials = new System.Net.NetworkCredential(emailUserName, emailPassword);
            }

            SmtpServer.EnableSsl = Storage.Instance.GetGlobalBool("EmailSSL");
            await SmtpServer.SendMailAsync(mail).ConfigureAwait(true);
            Dbg.Write("MainWindow - NotifyAIGone - Email Sent!");

            bool mqttSendAIDied = Storage.Instance.GetGlobalBool("MQTTSendAIDied");
            if (mqttSendAIDied)
            {
              string mqttAIDiedTopic = Storage.Instance.GetGlobalString("MQTTaiDiedTopic");
              string mqttAIDiedPayload = Storage.Instance.GetGlobalString("MQTTaiDiedPayload");
              await MQTTPublish.SendToServer(mqttAIDiedTopic, mqttAIDiedPayload).ConfigureAwait(false);
              Dbg.Write("AI Died MQTT message sent");
            }
          }
          catch (SmtpException ex)
          {
            Dbg.Write("MainWindow - NotifyEmailGone - Email exception: " + ex.ToString());
          }
        }
      }
    }

    void StartMotionTimeout(PendingItem pending)
    {
      lock (pending.CamData)
      {
        if (null == pending.CamData.MotionStoppedTimer)
        {
          try
          {
            pending.CamData.MotionStoppedTimer = new System.Threading.Timer(MotionStoppedNotify, pending.CamData, pending.CamData.NoMotionTimeout * 1000, -1);
          }
          catch { }
        }
        else
        {
          try
          {
            pending.CamData.MotionStoppedTimer.Dispose();
            pending.CamData.MotionStoppedTimer = new System.Threading.Timer(MotionStoppedNotify, pending.CamData, pending.CamData.NoMotionTimeout * 1000, -1);
          }
          catch { }
        }
      }
    }

    private delegate void SetProgressSpanDelegate(TimeSpan span);
    void UpdateFrameProgressBar(TimeSpan span)
    {
      if (this.InvokeRequired)
      {
        BeginInvoke(new SetProgressSpanDelegate(UpdateFrameProgressBar), new object[] { span });
        return;
      }

      int percent = (int)(span.TotalSeconds * 100.0);
      if (percent > 100)
      {
        percent = 100;
      }

      string timeStr = string.Format("{0:0.000}", span.TotalSeconds);
      Color barColor;
      if (percent <= 40)
      {
        barColor = Color.LightGreen;
      }
      else if (percent < 75)
      {
        barColor = Color.DarkOrange;
      }
      else
      {
        barColor = Color.Red;
      }
      FPSProgress.SetContents(barColor, percent, timeStr);
    }

    void UpdateAIProgressBar(TimeSpan span)
    {
      if (this.InvokeRequired)
      {
        BeginInvoke(new SetProgressSpanDelegate(UpdateAIProgressBar), new object[] { span });
        return;
      }

      int percent = (int)(span.TotalSeconds * 100.0);
      if (percent > 100)
      {
        percent = 100;
      }

      string timeStr = string.Format("{0:0.000}", span.TotalSeconds);
      Color barColor;
      if (percent <= 40)
      {
        barColor = Color.LightGreen;
      }
      else if (percent < 75)
      {
        barColor = Color.DarkOrange;
      }
      else
      {
        barColor = Color.Red;
      }
      AIProgressBar.SetContents(barColor, percent, timeStr);
    }


    async void MotionStoppedNotify(object camObj)
    {
      CameraData camera = (CameraData)camObj;

      lock (camera)
      {
        camera.MotionStoppedTimer.Dispose();
        camera.MotionStoppedTimer = null;
      }

      foreach (var area in camera.AOI)
      {
        if (area.Notifications.NoMotionMQTTNotify)
        {
          Dbg.Write("Motion Stopped MQTT - " + camera.CameraPrefix + " - " + area.AOIName);
          string topic = Storage.Instance.GetGlobalString("MQTTStoppedTopic");
          topic = topic.Replace("{Camera}", camera.CameraPrefix);
          topic = topic.Replace("{Motion}", camera.CameraPrefix);

          string payload = Storage.Instance.GetGlobalString("MQTTStoppedPayload");
          payload = payload.Replace("{Motion}", "off");
          await MQTTPublish.SendToServer(topic, payload).ConfigureAwait(true);
        }

        if (!string.IsNullOrEmpty(area.Notifications.NoMotionUrlNotify))
        {
          Dbg.Write("Motion Stopped HTTP - " + camera.CameraPrefix + " - " + area.AOIName);
          await NotifyUrlAsync(area.Notifications.NoMotionUrlNotify).ConfigureAwait(true);
        }
      }
    }


    #region SqlStuff


    async Task AddToMotionFramesTableAsync(PendingItem pending)
    {
      try
      {
        using SqlConnection con = new(DBConnection.GetConnectionString());
        await con.OpenAsync();

        try
        {
          using SqlCommand cmd = new("INSERT into NewMotionTable (CreationTime, FileName, Path, Camera, pictureTime) VALUES (@creationTime, @fileName, @path, @camera, @pictureTime)", con);
          string adjustedStr = GlobalFunctions.GetUniqueFileName(pending.PendingFile);

          cmd.Parameters.AddWithValue("@creationTime", adjustedStr);
          cmd.Parameters.AddWithValue("@fileName", Path.GetFileName(pending.PendingFile));
          cmd.Parameters.AddWithValue("@path", pending.CamData.CameraPath);
          cmd.Parameters.AddWithValue("@camera", pending.CamData.CameraPrefix);
          FileInfo fi = new(pending.PendingFile);
          cmd.Parameters.AddWithValue("@pictureTime", fi.CreationTime);
          int rowsAdded = await cmd.ExecuteNonQueryAsync().ConfigureAwait(true);
        }
        catch (SqlException ex)
        {
          Dbg.Write("MainWindow - AddMotionFramesTable SQL Exception - " + ex.Message);
        }
        catch (InvalidOperationException ex)
        {
          Dbg.Write("MainWindow - AddMotionFramesTable Invalid Operation Exception - " + ex.Message);
        }
      }
      catch (SqlException ex)
      {
        Dbg.Write("MainWindow - SQL Exception opening connection for adding motion file to database: " + ex.Message);
      }
      catch (InvalidOperationException ex)
      {
        Dbg.Write("MainWindow - InvalidOperation Exception opening connection for adding motion file to database: " + ex.Message);
      }
    }

    // based on the passed picture we get the next/previous picture name. 
    // note that is it remotely possible that the "current" picture changes out from under us, but this is OK (probably)
    // Note that his function returns the key to the next picture, not the picture name.
    async Task<string> GetNextMotionAsync(string lastFile, bool nextDirection)
    {
      string q;
      bool readSuccess = false;
      string key = string.Empty;

      // TODO: string keyOfCurrentPicture = Gl
      bool direction = nextDirection == _directionUp; // what is next depends on the order of the sorted list of file names (asscending/descending)

      if (direction)
      {
        q = "SELECT TOP 1 * FROM NewMotionTable WHERE CreationTime > @lastTime AND Path = @path AND Camera = @camera ORDER BY CreationTime ASC";
      }
      else
      {
        q = "SELECT TOP 1 * FROM NewMotionTable WHERE CreationTime < @lastTime AND Path = @path AND Camera = @camera ORDER BY CreationTime DESC";
      }

      try
      {
        string conStr = DBConnection.GetConnectionString();
        using SqlConnection con = new(conStr);
        await con.OpenAsync();

        while (true)  // If a file has been deleted we may need to look for the next file multiple times
        {
          key = string.Empty;
          using SqlCommand cmd = new(q, con);
          cmd.Parameters.AddWithValue("@lastTime", lastFile);
          cmd.Parameters.AddWithValue("@path", CurrentCam.CameraPath);
          cmd.Parameters.AddWithValue("@camera", CurrentCam.CameraPrefix);

          try
          {
            using SqlDataReader reader = await cmd.ExecuteReaderAsync();
            if (reader.HasRows)
            {
              await reader.ReadAsync();
              key = reader.GetString(0);
              key = key.Trim();
              readSuccess = true;
            }
            else
            {
              break;
            }
          }
          catch (SqlException ex)
          {
            Dbg.Write("MainWindow - GetNextMotion - SQL Exception: " + ex.Message);
          }
          catch (InvalidOperationException ex)
          {
            Dbg.Write("MainWindow - GetNextMotion - InvalidOperation Exception: " + ex.Message);
          }

          if (readSuccess)
          {
            // OK, here we have the file name, now get the "current" picture index -- it may not exist
            int index = _fileNames.Keys.IndexOf(key);
            if (index > -1)
            {
              break;  // done
            }
            else
            {
              // The file does not exist in the working set (index -1)
              await DeleteMissingMotionAsync(key);  // and we will repeat the process until we find another or none exist
            }
          }
          else
          {
            key = string.Empty;
            break;  // done, but with no file result
          }
        }
      }
      catch (SqlException ex)
      {
        Dbg.Write("MainWindow - SQLException - GetNextMotion - Opening Connection: " + ex.Message);
      }
      catch (InvalidOperationException ex)
      {
        Dbg.Write("MainWindow - InvalidOperationException - GetNextMotion - Opening Connection: " + ex.Message);
      }
      catch (Exception ex)
      {
        Dbg.Write("MainWindow - Unexpected Exception - GetNextMotion - Opening Connection: " + ex.Message);
      }


      return key;
    }


    /// <summary>
    /// If the motion frame does not exist, add it.
    /// This is called when browsing notices that there is interesting motion.
    /// Since we've done the hard work if analyzing the frame we just add it if ncessary.
    /// </summary>
    /// <param name="directionUp"></param>
    /// <returns></returns>
    public static async Task<int> InsertMotionIfNecessaryAsync(CameraData cam, string fileName)
    {
      int result = 1;
      try
      {
        string q = "SELECT CreationTime FROM NewMotionTable WHERE CreationTime = @creationTime AND FileName = @fileName";
        using SqlConnection con = new(DBConnection.GetConnectionString());
        try
        {
          await con.OpenAsync().ConfigureAwait(true);
        }
        catch (SqlException ex)
        {
          Dbg.Write("MainWindow -  InsertMotionIfNecessary - Sql Exception on opening database connection: " + ex.Message);
          return result;
        }
        catch (InvalidOperationException ex)
        {
          Dbg.Write("MainWindow -  InsertMotionIfNecessary - InvalidOperation Exception on opening database connection: " + ex.Message);
          return result;

        }

        using (SqlCommand cmd = new(q, con))
        {

          string adjustedStr = GlobalFunctions.GetUniqueFileName(fileName);
          cmd.Parameters.AddWithValue("@creationTime", adjustedStr);
          cmd.Parameters.AddWithValue("@fileName", Path.GetFileName(fileName.ToLower()));

          using SqlDataReader reader = await cmd.ExecuteReaderAsync().ConfigureAwait(true);
          if (reader.HasRows)
          {
            result = 0;
          }
        }

        if (result != 0)
        {
          q = "INSERT INTO NewMotionTable(CreationTime, FileName, Path, Camera, pictureTime) VALUES(@creationTime, @fileName, @path, @camera, @pictureTime)";
          // It didn't exist, insert it.
          // Yes, I could do that with one action, but I want the result
          using SqlCommand insertCmd = new(q, con);
          string adjustedStr = GlobalFunctions.GetUniqueFileName(fileName); //  GetMotionAdjusted(fi.FullName, fi.CreationTime.ToFileTime());
          insertCmd.Parameters.AddWithValue("@creationTime", adjustedStr);
          insertCmd.Parameters.AddWithValue("fileName", Path.GetFileName(fileName.ToLower()));
          insertCmd.Parameters.AddWithValue("@path", cam.CameraPath);
          insertCmd.Parameters.AddWithValue("@camera", cam.CameraPrefix);
          FileInfo fi = new(fileName);
          insertCmd.Parameters.AddWithValue("@pictureTime", fi.CreationTime);
          result = await insertCmd.ExecuteNonQueryAsync().ConfigureAwait(true);
        }
      }
      catch (DbException ex)
      {
        Dbg.Write("MainWindow - InsertMotionIfNecessary - DbException: " + ex.Message);
      }
      catch (Exception ex)
      {
        Dbg.Write("MainWindow - InsertMotionIfNecessary - Exception: " + ex.Message);
      }

      return result;
    }


    /// <summary>
    /// DeleteMissingMotion - When there is a motion file entry in the DB, but the file
    /// is no longer a valid file, remove it from the DB.
    /// This happens frequently when BlueIris or the user deletes the picture.
    /// </summary>
    /// <param name="fileName"></param>
    public static async Task<int> DeleteMissingMotionAsync(string fileName)
    {
      int result = 0;
      string fileKey = GlobalFunctions.GetUniqueFileName(fileName);
      try
      {
        using SqlConnection con = new(DBConnection.GetConnectionString());
        await con.OpenAsync().ConfigureAwait(true);
        try
        {
          string q = "DELETE FROM NewMotionTable WHERE creationTime = @creationTime";
          using SqlCommand cmd = new(q, con);
          cmd.Parameters.AddWithValue("@creationTime", fileKey);
          result = await cmd.ExecuteNonQueryAsync().ConfigureAwait(true);
          if (result > 0)
          {
            Dbg.Trace("MainWindow-DeleteMissingMotionAsync-Deleted File: " + fileName);
          }
        }
        catch (DbException ex)
        {
          Dbg.Write("MainWindow - DeleteMissingMotion - DbException: " + ex.Message);
        }
      }
      catch (SqlException ex)
      {
        Dbg.Write("MainWindow - DeleteMissingMotion - Sql exception opening connection: " + ex.Message);
      }
      catch (InvalidOperationException ex)
      {
        Dbg.Write("MainWindow - DeleteMissingMotion - InvaidOperation exception opening connection: " + ex.Message);
      }

      return result;
    }

    #endregion SqlStuff

    /// <summary>
    /// This method is a bit complex.  The goal is to start an interval for email accumulation if necessary.
    /// The reasons for this are documented below.
    /// </summary>
    /// <param name="cam"></param>
    /// <param name="interesting"></param>
    /// <param name="pendingItem"></param>
    static void ProcessAccumulation(Frame frame)
    {
      bool accumulate = false;
      bool doorOverride = false;
      bool inInterval = false;


      // First, decide if we need to accumulate emails
      if (frame.Item.CamData.Accumulating)
      {
        accumulate = true;
      }

      // We only trigger the start of accumulating on an interesting object.
      // However, once triggered (already above) we still accumulate.
      // Later we may filter out the uninteresting ones (depending on how many intersting we have)
      if (!accumulate && frame.Interesting != null)
      {
        // We haven't been accumulating but we might want to if any of the interesting objects are in an area with emails with attachments
        foreach (var interestingObject in frame.Interesting)
        {

          if (interestingObject.Area.Notifications.Email.Count > 0)
          {
            // we may be sending an email, but it might not have attachements
            foreach (string addr in interestingObject.Area.Notifications.Email)
            {
              EmailOptions option = EmailAddresses.GetEmailOptions(addr);
              if (option != null)
              {
                if (option.NumberOfImages > 0)
                {
                  accumulate = true;
                  break;
                }
              }
              if (accumulate) break;
            }
            if (accumulate) break;
          }
          if (accumulate) break;
        }

        // At this point we may be interested in accumulating, but we may be in an interval between emails.
        if (accumulate)
        {
          int timeSinceLast = (int)(DateTime.Now - frame.Item.CamData.TimeLastAccumulatorCompleted).TotalMinutes;
          if (timeSinceLast < Storage.Instance.GetGlobalInt("EventInterval"))
          {
            inInterval = true;
          }
        }
        // However, even if we are in a between event interval we still may want to accumulate emails if
        // the AreaOfIntererst for this picture is a "Door" event AND the last accumulation was not of that type
        // This is true because door events are of much higher priority than non-door ones
        if (inInterval)
        {
          accumulate = false; // may be temporary
          if (frame.Item.CamData.LastAccumulateType != AOIType.Door)
          {
            // OK, the last type was not of type door so we will violate the interval if any of our objects are of that type
            foreach (var interestingObject in frame.Interesting)
            {
              if (interestingObject.Area.AOIType == AOIType.Door)
              {
                // Well yes we might want to override, but only if any of the emails has attachments
                foreach (string addr in interestingObject.Area.Notifications.Email)
                {
                  EmailOptions email = EmailAddresses.GetEmailOptions(addr);
                  if (email != null)
                  {
                    if (email.NumberOfImages > 0)
                    {
                      doorOverride = true;
                      accumulate = true;
                      break;
                    }
                  }

                  if (doorOverride) break;
                }
                if (doorOverride) break;
              }
              if (doorOverride) break;
            }
          }
        }
      }

      if (accumulate)
      {
        if (!inInterval || doorOverride)
        {
          // OK, we do generall want to accumulate, we are not in an interval, or if we were in an interval we are in door
          // override.  So, we finally add this item to the camera specific list of recent pictures.
          // That still doesn't mean an email will be sent because we may be in an individual AOI/email address cooldown.
          // We can't check that until after the accumulation time is up, so we can't do it here
          lock (frame.Item.CamData.AccumulateLock)
          {
            Dbg.Trace("MainWindow - ProcessAccumulation - Starting Email Accumulation");
            frame.Item.CamData.Accumulating = true;
            frame.Item.CamData.CameraEmailAccumulator.Add(frame);
          }

        }
      }
    }

    private void OnClosed(object sender, FormClosedEventArgs e)
    {
    }

    private void AddEditEmailAddressesToolStripMenuItem_Click(object sender, EventArgs e)
    {
      using EmailAddressesDialog dlg = new(EmailAddresses.EmailAddressList);
      if (dlg.ShowDialog() == DialogResult.OK)
      {
        EmailAddresses.Save();
      }
    }

    private void OnCameraSelected(object sender, EventArgs e)
    {
      if (cameraCombo.SelectedItem != CurrentCam)
      {
        CancelAllPendingPictures();
        motionOnlyCheckbox.Checked = false;
        SetCurrentCameraAsync((CameraData)cameraCombo.SelectedItem);
      }
    }

    private void OnSizeChanged(object sender, EventArgs e)
    {
      BitmapResolution.XScale = (double)BitmapResolution.XResolution / (double)pictureImage.Width;
      BitmapResolution.YScale = (double)BitmapResolution.YResolution / (double)pictureImage.Height;

    }


    private async void CleanupButton_Click(object sender, EventArgs e)
    {
      using CleanupDialog dlg = new(_allCameras, CurrentCam.CameraPath, CurrentCam.CameraPrefix);
      DialogResult result = dlg.ShowDialog();
      if (result == DialogResult.OK)
      {
        await Task.Run(() => CleanupAsync(dlg.ExpiredFiles, dlg.ExcludeMotion)).ConfigureAwait(true);
        Refresh_Click(null, null);
        MessageBox.Show(this, "The working set has been refreshed after cleanup", "Cleanup Done!");
      }
    }


    bool IsMotionFile(SqlConnection con, string fileName)
    {
      bool result = false;
      string q;

      q = "SELECT FileName FROM NewMotionTable WHERE FileName = @fileName and @Path = @path";

      using (SqlCommand cmd = new(q, con))
      {
        cmd.Parameters.AddWithValue("@fileName", Path.GetFileName(fileName));
        cmd.Parameters.AddWithValue("@path", Path.GetDirectoryName(fileName));
        try
        {
          using SqlDataReader reader = cmd.ExecuteReader();
          if (reader.HasRows)
          {
            result = true;
          }
        }
        catch (SqlException ex)
        {
          Dbg.Write("MainWindow - GetNextMotion - SQL Exception: " + ex.Message);
        }
        catch (InvalidOperationException ex)
        {
          Dbg.Write("MainWindow - GetNextMotion - InvalidOperation Exception: " + ex.Message);
        }

      }

      return result;
    }


    private async Task CleanupAsync(List<FileInfo> expiredFiles, bool keepMotionFiles)
    {
      using SqlConnection con = new(DBConnection.GetConnectionString());
      await con.OpenAsync();
      foreach (var info in expiredFiles)
      {
        try
        {
          bool deleteIt = true;

          if (keepMotionFiles)
          {
            if (IsMotionFile(con, info.FullName))
            {
              deleteIt = false;
            }
          }

          if (deleteIt)
          {
            string key = GlobalFunctions.GetUniqueFileName(info.FullName);
            File.Delete(info.FullName);
            await DeleteMissingMotionAsync(key);
          }
        }
        catch (UnauthorizedAccessException ex)
        {
          MessageBox.Show("Unable to delete file: " + info.FullName + Environment.NewLine + "This is probably due to your anti-virus software." +
            Environment.NewLine + "Exiting Cleanup!");
          break;
        }
        catch (IOException)
        {
          Dbg.Write("Unable to find file: " + info.FullName + " when attempting deletion.");
        }
      }

    }

    private void AreasOfInterestToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (!_modifyingArea)
      {
        ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;
        showAreasOfInterestToolStripMenuItem.Checked = menuItem.Checked;
      }

    }


    private void NotifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
    {
      Show();
      this.WindowState = FormWindowState.Normal;
      notifyIcon.Visible = false;
    }


    private void LogFileToolStripMenuItem_Click(object sender, EventArgs e)
    {
      string path = Storage.GetFilePath("OnGuard.txt");
      string logViewer = Storage.Instance.GetGlobalString("LogViewer");
      if (string.IsNullOrEmpty(logViewer))
      {
        logViewer = "notepad.exe";
      }

      Dbg.PauseLogFile(true);

      if (File.Exists(path))
      {
        try
        {
          Process.Start(logViewer, path);
        }
        catch (Exception ex)
        {
          Type t = ex.GetType();
          MessageBox.Show(this, "The application you specified for the log viewer was unable to startup", "Log Viewer Error");
        }
      }
      else
      {
        MessageBox.Show("The log file does not exist.  Did you delete it?", "No Log File!");
      }

      Dbg.PauseLogFile(false);
    }


    private void OnMotionCheckChanged(object sender, EventArgs e)
    {
      if (motionOnlyCheckbox.Checked)
      {
        buttonRight.BackColor = Color.LightGreen;
        buttonLeft.BackColor = Color.LightGreen;
      }
      else
      {
        buttonRight.BackColor = SystemColors.Control;
        buttonLeft.BackColor = SystemColors.Control;
      }
    }

    private void MotionOnlyCheckbox_CheckedChanged(object sender, EventArgs e)
    {
      if (motionOnlyCheckbox.Checked)
      {
        motionOnlyCheckbox.BackColor = Color.LightGreen;
      }
      else
      {
        motionOnlyCheckbox.BackColor = SystemColors.Control;
      }
    }

    private void MQTTSettingsToolStripMenuItem_Click(object sender, EventArgs e)
    {

      using MQTTSettings mqttSettings = new();
      DialogResult result = mqttSettings.ShowDialog();
      if (result == DialogResult.OK)
      {
        Dbg.Write("MQTT Settings Saved");
      }
    }


    private void Button1_Click(object sender, EventArgs e)
    {
      /*_test.Item.CamData.FrameHistory.GetFramesInTimespan(TimeSpan.FromSeconds(200), _test.Item.TimeEnqueued, TimeDirection.Before);
      _test.Item.CamData.FrameHistory.GetFramesInTimespan(TimeSpan.FromSeconds(200), _test.Item.TimeEnqueued, TimeDirection.After);
      _test.Item.CamData.FrameHistory.GetFramesInTimespan(TimeSpan.FromSeconds(200), _test.Item.TimeEnqueued, TimeDirection.Both);
      */
    }

    private async void TestImagesToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (MessageBox.Show(this, "You are about to send test images to all cameras.  There is no guarantee that this images will match your Areas of Interest.  After the test pictures are saved your workspace will refresh.  Proceed?", "Send Test Images", MessageBoxButtons.YesNo) == DialogResult.Yes)
      {

        ResourceSet allPics = SamplePictureResources.ResourceManager.GetResourceSet(CultureInfo.InvariantCulture, true, true);

        foreach (var cam in _allCameras.CameraDictionary)
        {
          string path = cam.Value.CameraPath;
          IDictionaryEnumerator dict = allPics.GetEnumerator();

          while (dict.MoveNext())
          {
            Bitmap bm = (Bitmap)dict.Value;
            using MemoryStream mem = new();
            string fullPath = Path.Combine(path, cam.Value.CameraPrefix);
            fullPath += dict.Key;
            fullPath += DateTime.Now.Ticks.ToString() + ".jpg";
            bm.Save(fullPath, ImageFormat.Jpeg);
          }
        }
      }

    }

    private void LogDetailedInformationToolStripMenuItem_Click(object sender, EventArgs e)
    {
      ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;
      if (menuItem.Checked)
      {
        Dbg.LogLevel = 1;
      }
      else
      {
        Dbg.LogLevel = 0;
      }

      Storage.Instance.SetGlobalBool("LogDetailedInformation", menuItem.Checked);
      Storage.Instance.Update();
    }

    private void DeleteLogFileToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (File.Exists(Storage.GetFilePath("OnGuard.txt")))
      {
        if (!Dbg.DeleteLogFile())
        {
          MessageBox.Show("Unable to delete the log file - It is probably busy. Try again later", "Unable to Delete the log file!");
        }
      }
      else
      {
        MessageBox.Show("Unable to delete the log file - It does not currently exist.", "No Log File!");
      }
    }

    private void EnhancedProgressBar1_Load(object sender, EventArgs e)
    {

    }

    private void AnalysisSettingsToolStripMenuItem_Click(object sender, EventArgs e)
    {
      using AnalysisSettingsDialog dlg = new();
      dlg.ShowDialog();
    }


    private void AIAlertMenuItemClicked(object sender, EventArgs e)
    {
      using AIAlertDialog dlg = new();
      dlg.ShowDialog();
    }



    private void YResLabel_Click(object sender, EventArgs e)
    {

    }

    // This should ONLY be called when the track bar is causing the change
    // since we filter calls in the control.
    private void LocationTrackBar_ValueChanged(object sender, EventArgs e)
    {
      if (!_modifyingArea)
      {
        int location = timeLine.Value;
        if (location < _fileNames.Count)
        {
          string key = _fileNames.Keys[location];

          if (key != _lastPictureRequested)
          {
            CancelAllPendingPictures(); // we don't care about anything queued.
            Picture p = CreatePicture(_fileNames[key].FileName);
            UpdateRequestedKey(key);
          }
        }
      }
    }



    private void SetCurrent(int current)
    {
      if (current < _fileNames.Count && current >= 0)
      {
        timeLine.SetCurrentPosition(current);
        _current = current;
        int pictureIndex = PictureIndex(_displayedPicture);
      }
    }

    private void ImageCaptureMenuItem_Click(object sender, EventArgs e)
    {
      using ImageCaptureDialog dlg = new(CurrentCam);
      dlg.ShowDialog();
    }

    void SetPresetList()
    {
      if (_allCameras != null && CurrentCam != null)
      {
        PresetsCombo.Items.Clear();

        if (CurrentCam.Contact.PresetSettings.PresetMethod == PTZMethod.None)
        {
          presetButton.Enabled = false;
          PresetsCombo.Enabled = false;
        }
        else
        {
          presetButton.Enabled = true;
          PresetsCombo.Enabled = true;

          foreach (var preset in CurrentCam.Contact.PresetSettings.PresetList)
          {
            PresetsCombo.Items.Add(preset.Name);
          }

          if (PresetsCombo.Items.Count > 0)
          {
            PresetsCombo.SelectedIndex = 0;
          }
        }
      }
    }

    void EnablePTZ()
    {
      if (_allCameras != null)
      {
        if (CurrentCam != null)
        {
          bool usePTZ = (CurrentCam.Contact.PTZContactMethod != PTZMethod.None);
          camRightButton.Enabled = usePTZ;
          camLeftButton.Enabled = usePTZ;
          camUpButton.Enabled = usePTZ;
          camDownButton.Enabled = usePTZ;
          camZoomOut.Enabled = usePTZ;
          camZoomIn.Enabled = usePTZ;
        }
      }

    }



    private void cameraCombo_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    async Task CreateFaceAsync()
    {
      Rectangle rect = new(_modifyBox.Location.X, _modifyBox.Location.Y, _modifyBox.Width, _modifyBox.Height);
      Rectangle scaledRect = BitmapResolution.ScaleScreenToData(rect);

      _modifyingArea = false;
      ControlMoverOrResizer.Stop(_modifyBox);
      StopEditingEnvironment();
      _modifyBox.Dispose();
      _modifyBox = null;

      PixelFormat format = _displayedPicture.PictureBitmap.PixelFormat;
      using Bitmap faceBitmap = _displayedPicture.PictureBitmap.Clone(scaledRect, format);
      using FaceName dlg = new();
      DialogResult result = dlg.ShowDialog();
      if (result == DialogResult.OK)
      {
        faceBitmap.Save(dlg.NameOfPerson);

        bool registerResult = await FaceDetection.RegisterFaceAsync(dlg.Person);
        if (!registerResult)
        {
          MessageBox.Show("The AI was unable to detect this picture as a face.  Try another picture!", "Face Detection Error!");
        }
      }
    }

    private void startRestartAIToolStripMenuItem_Click(object sender, EventArgs e)
    {
      using StartRestartAI dlg = new();
      dlg.ShowDialog();
    }

    private void OnClosing(object sender, FormClosingEventArgs e)
    {
      if (Storage.Instance.GetGlobalBool("AutoStopDeepStack"))
      {
        AI.StopAI();
      }
    }

    private Point ScreenToArea(Point pt)
    {
      Point result = new();
      if (pt.Y >= pictureImage.Height)
      {
        pt.Y = pictureImage.Height - 1;
      }

      if (pt.X >= pictureImage.Width)
      {
        pt.X = pictureImage.Width - 1;
      }

      if (pt.Y < 0)
      {
        pt.Y = 0;
      }

      if (pt.X < 0)
      {
        pt.X = 0;
      }

      // Get the bitmap x and y based on the mouse x & y
      int x = (int)Math.Round((double)pt.X * BitmapResolution.XScale);
      int y = (int)Math.Round((double)pt.Y * BitmapResolution.YScale);

      int pixelsPerX = BitmapResolution.XResolution / _areaDefinition.XDim;
      int pixelsPerY = BitmapResolution.YResolution / _areaDefinition.YDim;

      result.X = x / pixelsPerX;
      result.Y = y / pixelsPerY;

      /*result.Y = (int)Math.Round(((double)y / (double)_areaDefinition.YDim));
      result.X = (int)Math.Round(((double)x / (double)_areaDefinition.XDim));
      */

      return result;
    }

    private void createAreaToolStripMenuItem_Click(object sender, EventArgs e)
    {
      string caption = "****** Creating/Modifying Area of Interest - Escape to Quit, F1 to Accept -  Number Keys (1 - 7) Control Rectangle Size ******";
      _definitionType = DefinitionType.AOI;
      _areaDefinition.Clear();
      SetScreenAreaDefinition(_areaDefinition);
      SetupEditingEnvironment(caption);
    }

    private async void editAreaToolStripMenuItem_Click(object sender, EventArgs e)
    {
      using EditAreasOfInterest edit = new(CurrentCam.AOI); // handles any changes in registration
      DialogResult result = edit.ShowDialog();
      if (result == DialogResult.Yes)
      {
        // An artificial response showing that we have an Area of Interest boundary to change
        StartEditingArea(edit.EditAreaID);
      }
      else
      {
        if (_fileNames != null && _fileNames.Count > 0)
        {
          CreatePicture(_displayedPicture.FileName);
        }
      }
    }

    private void SetPictureBitmap(Bitmap bitmap)
    {
      if (this.InvokeRequired)
      {
        this.BeginInvoke(new Action(() =>
          {
            pictureImage.SetImage(bitmap);
            pictureImage.Refresh();
          }));
      }
      else
      {
        pictureImage.SetImage(bitmap);
        pictureImage.Refresh();
      }
    }

    private void SetScreenAreaDefinition(GridDefinition grid)
    {
      List<GridDefinition> grids = new();
      grids.Add(grid);
      pictureImage.GridsSelected = grids;
      pictureImage.Refresh();
    }


    delegate void ControlTextUpdateDelgate(Control control, string text);
    private void ControlTextUpdate(Control control, string text)
    {
      if (control.InvokeRequired)
      {
        control.BeginInvoke(new ControlTextUpdateDelgate(ControlTextUpdate), new object[] { control, text });
        return;
      }

      control.Text = text;
    }

    delegate void NumericValueUpdateDelgate(NumericUpDown control, int val);
    private void NumericValueUpdate(NumericUpDown control, int val)
    {
      if (control.InvokeRequired)
      {
        control.BeginInvoke(new NumericValueUpdateDelgate(NumericValueUpdate), new object[] { control, val });
        return;
      }

      control.Value = val;
    }

    delegate void UpdateMenuItemDelegate(ToolStripMenuItem item, string text, int setChecked);
    private void UpdateMenuItem(ToolStripMenuItem item, string text, int setChecked)
    {
      if (this.InvokeRequired)
      {
        this.BeginInvoke(new UpdateMenuItemDelegate(UpdateMenuItem), new object[] { item, text, setChecked });
        return;
      }

      if (!string.IsNullOrEmpty(text))
      {
        item.Text = text;
      }

      if (setChecked >= 0)
      {
        item.Checked = Convert.ToBoolean(setChecked);
      }
    }

    private void Button1_Click_1(object sender, EventArgs e)
    {
      GC.Collect();
    }

    private void OnTimelineKeyUp(object sender, KeyEventArgs e)
    {
      if (!_modifyingArea)
      {
        int position = timeLine.Value;
        Dbg.Write("timeLine position when up: " + position.ToString());
        CancelAllPendingPictures();
        string key = _fileNames.Keys[position];
        Picture p = CreatePicture(_fileNames[key].FileName);
        _cancelAfterPicture = p.ID;
      }
    }

    private void OnSizeToFrameChecked(object sender, EventArgs e)
    {

    }

    private void OnResize(object sender, EventArgs e)
    {
      if (this.WindowState == FormWindowState.Minimized)
      {
        Hide();
        notifyIcon.Visible = true;
        notifyIcon.ShowBalloonTip(800);
      }

      if (!_loading && _displayedPicture != null)
      {
        AdjustPictureImageSize(_displayedPicture);
      }

    }


    private void sizePictureToFrameMenuItem_Click(object sender, EventArgs e)
    {
      if (_displayedPicture != null)
      {
        AdjustPictureImageSize(_displayedPicture);
      }
    }

    private void OnPictureDisplayOption(object sender, EventArgs e)
    {
      using (DisplayMode dlg = new DisplayMode(CurrentCam.CameraView))
      {
        DialogResult result = dlg.ShowDialog();
        if (result == DialogResult.OK)
        {
          CurrentCam.CameraView = dlg.DisplayType;
          Storage.Instance.SaveCameras(_allCameras);
          Storage.Instance.Update();
          
          if (_displayedPicture != null)
          {
            AdjustPictureImageSize(_displayedPicture);
          }
        }
      }
    }
  }

  public enum CameraDirections
  {
    left = 0,
    right = 1,
    up = 2,
    down = 3,
    home = 4,
    zoomIn = 5,
    zoomOut = 6
  }

  public enum MovementDirection
  {
    Still,
    Right,
    Left
  }

  public enum DefinitionType
  {
    AOI,
    Face
  }

}