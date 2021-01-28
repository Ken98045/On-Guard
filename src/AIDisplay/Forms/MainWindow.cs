
using SAAI.Properties;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.Media;
using MQTTnet.Client;
using MQTTnet.Client.Connecting;
using MQTTnet.Client.Disconnecting;
using MQTTnet.Client.Publishing;
using MQTTnet.Client.Options;
using MQTTnet.Client.Receiving;
using MQTTnet.Client.Subscribing;
using MQTTnet.Client.Unsubscribing;
using System.Drawing.Imaging;
using System.Resources;
using System.Collections;
using System.Globalization;

namespace SAAI
{

  public partial class MainWindow : Form
  {
    AIAnalyzer _analyzer;
    List<string> _fileNames;

    int _current = 0;
    bool _showObjects = true;
    Bitmap _screenBitmap;
    Bitmap _areaBackgroundBitmap;
    //double _xScale;
    //double _yScale;
    bool _showingLiveView;
    int _imagesBeingProcessed;
    int _numberOfImagesProcessed;
    string _connectionString;

    readonly MostRecentCollection _recentTimes = new MostRecentCollection(10);
    readonly object _fileLock = new object();

    static Frame _test;

    CameraCollection _allCameras;

    bool _modifyingArea = false;    // Flag that we are modifying an area
    ZoneBox _modifyBox;
    Guid _modifyingAreaID = Guid.Empty;

    List<ImageObject> _frameObjects = new List<ImageObject>();
    readonly Color aoiColor = Color.FromArgb(80, Color.DarkOrange);
    readonly Color aoiRegistrationColor = Color.FromArgb(120, Color.Purple);
    readonly ConcurrentQueue<PendingItem> _fileQueue = new ConcurrentQueue<PendingItem>();
    readonly AutoResetEvent _wakeFileQueue = new AutoResetEvent(false);
    readonly Thread _monitorQueueThread;
    readonly double _timePerFrame = 1.0;
    System.Windows.Forms.Timer _liveTimer;
    bool _directionUp = false;  // direction is down because we start up at the last (most recent) picture
    long _lastMotionTime = long.MaxValue; // so we can go "down in the time for motion


    readonly ConcurrentDictionary<string, string> _filesPendingProcessing = new ConcurrentDictionary<string, string>(); // very short period of time where the file has been removed from the queue yet still hasn't been opened
    readonly ManualResetEvent _stopEvent = new ManualResetEvent(false);  // set to shut down the MonitorQueue thread (and anything else)

    CameraData CurrentCam
    {
      get
      {
        return _allCameras.CurrentCamera;
      }
    }

    readonly private PerformanceCounter theCPUCounter =
       new PerformanceCounter("Processor", "% Processor Time", "_Total");

    public MainWindow()
    {

      if (!Debugger.IsAttached)
      {
        Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);
        AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
      }

      InitializeComponent();
      _monitorQueueThread = new Thread(MonitorQueue);

      Focus();
      Dbg.Write("On Guard started at: " + DateTime.Now.ToString());

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

    private void Form1_Load(object sender, EventArgs e)
    {
      int currentCPU = (int)theCPUCounter.NextValue();
      currentCPU = (int)theCPUCounter.NextValue();
      _monitorQueueThread.Start();

      Settings.Default.SettingsKey = "OnGuard";
      Settings.Default.Reload();
      Settings.Default.SettingChanging += Default_SettingChanging;


      _connectionString = Storage.GetGlobalString("DBConnectionString");
      if (string.IsNullOrEmpty(_connectionString))  // only completely empty on first app use!
      {
        // First use settings
        string dbLocation = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        dbLocation = Path.Combine(dbLocation, "OnGuardDatabase");
        _connectionString = Settings.Default.DBMotionFramesConnectionString;
        _connectionString = string.Format(_connectionString, dbLocation);
        Storage.SetGlobalString("DBConnectionString", _connectionString);
      }


      if (!Storage.GetGlobalBool("SetupComplete"))
      {
        InitialSetup();
      }

      _analyzer = new AIAnalyzer();

      _allCameras = CameraCollection.Load();    // which also inits the camera

      if (CurrentCam != null)
      {
        Storage.SetGlobalString("CurrentCameraPath", CurrentCam.Path);            // TODO: Eliminate?
        Storage.SetGlobalString("CurrentCameraPrefix", CurrentCam.CameraPrefix);
        InitAnalyzer(CurrentCam.CameraPrefix, CurrentCam.Path);
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

      this.Focus();
    }



    private void Default_SettingChanging(object sender, SettingChangingEventArgs e)
    {
      // Dbg.Write("Settings changing: " + e.SettingName + " value: " + e.NewValue.ToString());
    }

    /// <summary>
    /// Called only once when they first start the application.
    /// It does all the required setup steps, one after the other.
    /// </summary>
    void InitialSetup()
    {

      MessageBox.Show("In order to use the application you must first go through some steps to setup the application.  This is a one time only requirement.");

      DialogResult result = DialogResult.Cancel;
      DialogResult cancelResult;

      while (result == DialogResult.Cancel)
      {
        using (SettingsDialog dlg = new SettingsDialog())
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
        using (CameraConfigurationDialog cameraDialog = new CameraConfigurationDialog(_allCameras))
        {

          result = cameraDialog.ShowDialog();
          _allCameras = cameraDialog.AllCameraData;  // regardless of the OK/Cancel in the dialog we just copy the reference

          if (result == DialogResult.OK)
          {
            _allCameras = cameraDialog.AllCameraData;    // the list has been copied and returned
            CameraCollection.Save(_allCameras);

            if (null == cameraDialog.SelectedCamera)
            {
              Storage.SetGlobalString("CurrentCameraPath", string.Empty);   // TODO: Remove?
              Storage.SetGlobalString("CurrentCameraPrefix", string.Empty);
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
        using (OutgoingEmailDialog outgoingDlg = new OutgoingEmailDialog())
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
        using (EmailAddressesDialog dlg = new EmailAddressesDialog(EmailAddresses.EmailAddressList))
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

      Storage.SetGlobalBool("SetupComplete", true);

      MessageBox.Show("The application will now exit.  Please restart it to continue", "Setup Complete!");
      Dispose();

    }


    void InitAnalyzer(string cameraNamePrefix, string path)
    {
      if (null != _fileNames)
      {
        _fileNames.Clear();
      }

      _current = 0;

      // pictureImage.Image = null;
      _showObjects = true;
      showAreasOfInterestCheck.Checked = false;

      if (null != _screenBitmap)
      {
        _screenBitmap.Dispose();
        _screenBitmap = null;
      }

      if (null != _areaBackgroundBitmap)
      {
        _areaBackgroundBitmap.Dispose();
        _areaBackgroundBitmap = null;
      }

      if (null != _fileNames)
      {
        _fileNames.Clear();
      }
      _fileNames = _analyzer.Init(cameraNamePrefix, path);
      numberOfFilesTextBox.Text = _fileNames.Count.ToString();
      if (_fileNames.Count > 0)
      {
        LoadImage(_fileNames[_current]);
      }
      else
      {
        pictureImage.Image = pictureImage.ErrorImage;
      }

      fileNumberUpDown.Maximum = _fileNames.Count;
      fileNumberUpDown.Minimum = (int)1;
    }

    /// <summary>
    /// Move to the next picture in sequence or next motion
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ButtonRight_Click(object sender, EventArgs e)
    {
      int lastPosition = _current;

      using (WaitCursor _ = new WaitCursor())
      {
        lock (_fileLock)
        {
          while (true)  // handle the case where the "next" item was deleted external to the UI (Blue Iris, etc)
          {

            if (motionOnlyCheckbox.Checked)
            {
              GetNextMotion(_directionUp); // sets _current;
              if (lastPosition == _current)
              {
                SystemSounds.Beep.Play();
              }

            }
            else
            {
              ++_current;
            }

            if (_fileNames != null && _current < _fileNames.Count - 1)
            {
              try
              {
                LoadImage(_fileNames[_current]);
                break;
              }
              catch (FileNotFoundException)
              {
                _fileNames.RemoveAt(_current);
                numberOfFilesTextBox.Text = _fileNames.Count.ToString();
              }
            }
            else
            {
              SystemSounds.Beep.Play();

              --_current;
              if (_current < 0)
              {
                _current = 0;
              }
              break;
            }
          }
        }
      }


    }

    /// <summary>
    /// Move to the previous picture in sequence or in motion.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ButtonLeft_Click(object sender, EventArgs e)
    {
      int lastPosition = _current;
      using (WaitCursor _ = new WaitCursor())
      {
        lock (_fileLock)
        {
          while (true)
          {
            if (motionOnlyCheckbox.Checked)
            {
              GetNextMotion(!_directionUp); // sets _current;
              if (lastPosition == _current)
              {
                SystemSounds.Beep.Play();
              }
            }
            else
            {
              if (_current > 0)
              {

                --_current;
              }
              else
              {
                SystemSounds.Beep.Play();
              }
            }

            if (_current >= 0)
            {
              try
              {
                if (_fileNames != null && _current >= 0)
                {
                  if (_fileNames.Count > 0)
                  {
                    LoadImage(_fileNames[_current]);
                  }
                  break;
                }
              }
              catch (FileNotFoundException)
              {
                _fileNames.RemoveAt(_current);
                numberOfFilesTextBox.Text = _fileNames.Count.ToString();
              }
            }
            else
            {
              SystemSounds.Beep.Play();
            }
          }
        }
      }
    }

    private List<ImageObject> LoadImage(string file)
    {
      List<ImageObject> result = new List<ImageObject>();

      bool continueTrying;
      int count = 0;

      do
      {
        try
        {
          continueTrying = false;
          if (File.Exists(file))
          {
            using (FileStream stream = new FileStream(file, FileMode.Open))
            {
              result = ProcessImage(stream, file);
              if (!motionOnlyCheckbox.Checked)  // If the box is checked and we are loading the image then we know it is in the DB
              {
                if (result != null && result.Count > 0)
                {

                  FrameAnalyzer analyzer = new FrameAnalyzer(CurrentCam.AOI, result);
                  AnalysisResult analysisResult = analyzer.AnalyzeFrame();
                  if (analysisResult.InterestingObjects.Count > 0)
                  {
                    InsertMotionIfNecessary(file);
                  }
                }
              }

              currentNumberTextBox.Text = (_fileNames.IndexOf(file) + 1).ToString();
              fileNameTextBox.Text = file;
              _showingLiveView = false;
              FileInfo fi = new FileInfo(file);
              _lastMotionTime = fi.CreationTime.ToFileTime();
            }
          }
          else
          {
            pictureImage.Image = pictureImage.ErrorImage;
            currentNumberTextBox.Text = string.Empty;
            fileNameTextBox.Text = string.Empty;
            throw new FileNotFoundException("The image file was not found!", file);
          }
        }
        catch (FileNotFoundException ex)
        {
          continueTrying = false;
          throw ex;
        }
        catch (IOException)
        {
          continueTrying = true;
          ++count;
          Task.Delay(100);
        }
      } while (continueTrying && count < 3); // primarily to avoid a file in use. There are much more elegant (and correct) ways to do this, but I'm tired of this

      return result;
    }


    private List<ImageObject> ProcessImage(Stream stream, string imageName)
    {

      if (_frameObjects != null)
      {
        _frameObjects.Clear();
      }

      objectListView.Items.Clear();
      // pictureImage.Image = null;

      Bitmap tmp = new Bitmap(stream);  // We don't know the width & height so we can't use a method that defines pixel format
      _screenBitmap = new Bitmap(tmp);  // The bitmap from the disk is 24bpp,the copy is 32bpp (and, yes, it matters)
      tmp.Dispose();
      BitmapResolution.XResolution = _screenBitmap.Width;
      BitmapResolution.YResolution = _screenBitmap.Height;
      if (null == pictureImage)
      {
        BitmapResolution.XScale = 1.0;
        BitmapResolution.YScale = 1.0;
      }
      else
      {
        BitmapResolution.XScale = (double)_screenBitmap.Width / (double)pictureImage.Width;
        BitmapResolution.YScale = (double)_screenBitmap.Height / (double)pictureImage.Height;
      }

      stream.Position = 0;
      if (_showObjects)
      {
        try
        {
          _frameObjects = _analyzer.ProcessVideoImageViaAI(stream, imageName).Result;
        }
        catch (AggregateException ex)
        {
          ex.Handle((x) =>
          {
            if (x is AiNotFoundException) // This we know how to handle.
            {
              MessageBox.Show(x.Message + Environment.NewLine + "Either start the DeepStack AI or change the location and port of that application.", "Setup Error!");
              using (SettingsDialog dlg = new SettingsDialog())
              {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                  _frameObjects = null;
                }
              }

              return true;
            }
            else
            {
              return false;
            }
          });

          return null;
        }


        if (_frameObjects != null)
        {
          string[] subItems = new string[6];
          foreach (ImageObject obj in _frameObjects)
          {
            if (CurrentCam.IsItemOfCameraInterest(obj.Label))
            {
              subItems[0] = obj.Label;
              subItems[1] = obj.Confidence.ToString();
              subItems[2] = obj.ObjectRectangle.X.ToString();
              subItems[3] = obj.ObjectRectangle.Y.ToString();
              subItems[4] = obj.ObjectRectangle.Width.ToString();
              subItems[5] = obj.ObjectRectangle.Height.ToString();
              ListViewItem item = new ListViewItem(subItems);
              objectListView.Items.Add(item);

              using (Pen redPen = new Pen(Color.Red, 2))
              {
                using (var graphics = Graphics.FromImage(_screenBitmap))
                {
                  Rectangle rect = obj.ObjectRectangle;
                  graphics.DrawRectangle(redPen, rect);
                }
              }
            }
          }
        }
      }


      goToFileTextBox.Text = "";

      if (showAreasOfInterestCheck.Checked)
      {
        ShowAreasOfInterest();
      }

      if (!(CurrentCam.RegistrationX == 0 && CurrentCam.RegistrationY == 0))
      {
        using (SolidBrush registrationBrush = new SolidBrush(aoiRegistrationColor))
        {
          using (var graphics = Graphics.FromImage(_screenBitmap))
          {
            int x = (int)((((double)BitmapResolution.XResolution / (double)CurrentCam.RegistrationXResolution)) * (double)CurrentCam.RegistrationX);
            int y = (int)((((double)BitmapResolution.YResolution / (double)CurrentCam.RegistrationYResolution)) * (double)CurrentCam.RegistrationY);
            Rectangle rect = Rectangle.FromLTRB(x - 10, y - 10,
                                              x + 10, y + 10);

            graphics.FillRectangle(registrationBrush, rect);

          }
        }
      }

      pictureImage.Image = _screenBitmap;
      XResLabel.Text = BitmapResolution.XResolution.ToString();
      YResLabel.Text = BitmapResolution.YResolution.ToString();

      return _frameObjects;
    }


    private void GoToFileButton_Click(object sender, EventArgs e)
    {
      using (WaitCursor _ = new WaitCursor())
      {
        lock (_fileLock)
        {
          motionOnlyCheckbox.Checked = false;
          if (_fileNames.Count > 0)
          {
            if (_fileNames.Count > (int)(fileNumberUpDown.Value))
            {
              LoadImage(_fileNames[(int)fileNumberUpDown.Value - 1]);
              _current = (int)fileNumberUpDown.Value - 1;
            }
          }
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
      using (WaitCursor _ = new WaitCursor())
      {
        motionOnlyCheckbox.Checked = false;
        lock (_fileLock)
        {
          if (!string.IsNullOrEmpty(goToFileTextBox.Text) && File.Exists(goToFileTextBox.Text))
          {
            LoadImage(goToFileTextBox.Text);
          }
          else
          {
            MessageBox.Show(this, "You must enter the complete file name/path of a valid picture to view/go to it", "Entry Required!");
          }
        }
      }
    }


    private void OnReverseListButton(object sender, EventArgs e)
    {
      using (WaitCursor _ = new WaitCursor())
      {
        lock (_fileLock)
        {
          motionOnlyCheckbox.Checked = false;
          _fileNames.Reverse();
          _current = 0;
          LoadImage(_fileNames[0]);
          _directionUp = !_directionUp;
        }
      }
    }

    private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Application.Exit();
    }

    private void ShowObjectRectangelsToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (!_modifyingArea)
      {
        lock (_fileLock)
        {
          ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;
          if (_fileNames != null && _fileNames.Count > 0 && _showObjects != menuItem.Checked)
          {
            _showObjects = menuItem.Checked;
            LoadImage(_fileNames[_current]);
          }
        }
      }
    }

    private void OnKeyDown(object sender, KeyEventArgs e)
    {
      switch (e.KeyCode)
      {
        case Keys.PageUp:
          if (!_modifyingArea)
          {
            e.Handled = true;
            ButtonRight_Click(sender, e);
          }
          break;
        case Keys.PageDown:
          if (!_modifyingArea)
          {
            e.Handled = true;
            ButtonLeft_Click(sender, e);
          }
          break;

        case Keys.Escape:
          if (null != _modifyBox)
          {
            _modifyingArea = false;
            ControlMoverOrResizer.Stop(_modifyBox);
            _modifyBox.Dispose();
            _modifyBox = null;
            StopEditingEnvironment();
          }
          break;

        case Keys.F1:
          if (null != _modifyBox)
          {
            AcceptAreaOfInterest();
          }
          break;
      }
    }

    void AcceptAreaOfInterest()
    {
      Rectangle rect = new Rectangle(_modifyBox.Location.X, _modifyBox.Location.Y, _modifyBox.Width, _modifyBox.Height);
      Point zoneFocus = _modifyBox.ZoneFocus;
      Rectangle scaledRect = BitmapResolution.ScaleScreenToData(rect);

      _modifyingArea = false;
      ControlMoverOrResizer.Stop(_modifyBox);
      StopEditingEnvironment();
      _modifyBox.Dispose();
      _modifyBox = null;

      if (_modifyingAreaID == Guid.Empty)
      {

        using (CreateAOI dlg = new CreateAOI(scaledRect, zoneFocus, BitmapResolution.XResolution, BitmapResolution.YResolution))
        {
          DialogResult result = dlg.ShowDialog(pictureImage);

          switch (result)
          {
            case DialogResult.OK:
              if (_modifyingAreaID == Guid.Empty)
              {
                CurrentCam.AOI.AddArea(dlg.Area);
                CurrentCam.AOI.Save();
              }
              else
              {
                CurrentCam.AOI[_modifyingAreaID].AreaRect = scaledRect; // just update the area (does not need to be adjusted)
                CurrentCam.AOI.Save();
                MessageBox.Show(pictureImage, "The Area of Interest was saved with new boundaries!", "Area Saved");
                _modifyingAreaID = Guid.Empty;
              }
              break;

            case DialogResult.Yes:
              // An artificial response saying "edit this area".  This only happen when the area
              // there is a request to modify an area that has come from the initial area creation
              // It does not happen here when the area is modified via the EditAreasOfInterest box
              CurrentCam.AOI.AddArea(dlg.Area); // Even if we are modifying an area bounds we still save it
              StartEditingArea(dlg.Area.ID);
              break;
          }
        }
      }
      else
      {
        // If we are already modifying an area all we do is update the rectangle
        CurrentCam.AOI[_modifyingAreaID].AreaRect = scaledRect; // does not need to be adjusted
        CurrentCam.AOI[_modifyingAreaID].ZoneFocus = zoneFocus;
        CurrentCam.AOI.Save();
        MessageBox.Show(pictureImage, "The boundaries of the current Area of Interest have been modified", "Area of Interest Changed!");
      }

    }

    private void OnMouseMove(object sender, MouseEventArgs e)
    {
      int mouseX = (int)Math.Round((e.Location.X * BitmapResolution.XScale));
      int mouseY = (int)Math.Round(e.Location.Y * BitmapResolution.YScale);
      xPosLabel.Text = mouseX.ToString();
      yPosLabel.Text = mouseY.ToString();
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

      DialogResult shiftResult = MessageBox.Show(this, "You have the option to shift your areas with respect to the registration mark shift.  Do you want to do this?", "Shift Areas?", MessageBoxButtons.YesNo);

      if (shiftResult == DialogResult.Yes)
      {
        Dbg.Write("Adjusting Areas with respect to registration point");

        // If this area is of type registration then adjust everybody's x & Y
        // BUT, only if there was already a registration point
        if (CurrentCam.RegistrationX > 0 && CurrentCam.RegistrationY > 0)
        {
          foreach (var area in CurrentCam.AOI)
          {
            area.AdjustRect(-offsetX, -offsetY);
            if (area.AreaRect.X < 0)
            {
              area.AreaRect.X = 0;
            }

            if (area.AreaRect.Y < 0)
            {
              area.AreaRect.Y = 0;
            }
          }
        }

        CameraCollection.Save(_allCameras);
      }

      CameraCollection.Save(_allCameras);

      if (_showingLiveView)
      {
        LiveCameraButton_Click(null, null);
      }
      else
      {
        lock (_fileLock)
        {
          LoadImage(_fileNames[_current]);
        }
      }
    }

    private void OnMouseDown(object sender, MouseEventArgs e)
    {
      if (!_modifyingArea)
      {
        if (e.Button == MouseButtons.Right)
        {
          _modifyingArea = true;
          _modifyingAreaID = Guid.Empty;  // signal that this is a new area not a mods

          _modifyBox = new ZoneBox()
          {
            Parent = pictureImage,
            Location = new Point(e.X, e.Y),
            Size = new Size(100, 100)
          };
          _modifyBox.Show();
          ControlMoverOrResizer.Start(_modifyBox);
          SetupEditingEnvironment();
        }
        else
        {
          if ((Control.ModifierKeys & Keys.Control) == Keys.Control)
          {
            if (MessageBox.Show("You are about to set the registration point for this camera.  This helps you ensure that your camera is in the right position.  If the registration point has already been set, then you have the option to adjust any existing areas of interest with respect to this shift.  Are you sure you want to do this?", "Reset Camera Registration Point", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
              AdjustAreasOfInterest(e.X, e.Y);
            }
          }
        }
      }
    }

    private void OnMouseUp(object sender, MouseEventArgs e)
    {

      if (CurrentCam.RegistrationX == 0 || CurrentCam.RegistrationY == 0)
      {
        if ((Control.ModifierKeys & Keys.Control) != Keys.Control)
        {
          MessageBox.Show("You can create areas of interest by using a mouse click down and drag.  However, before you can do this you must set a camera registration point so that you can ensure that your camera is always position correctly.  You do this by holding the control key and then clicking in the desired position for the registration point.  That point should be on a spot that is easily recoginzed when viewing the camera.", "Set Camera Registration Point First!");
        }
      }

    }


    private void OnMouseLeave(object sender, EventArgs e)
    {
    }

    private void OnMouseEnter(object sender, EventArgs e)
    {
    }

    private void ShowAreasOfInterestCheckChanged(object sender, EventArgs e)
    {
      lock (_fileLock)
      {
        if (_fileNames != null && _fileNames.Count > 0)
        {
          if (showAreasOfInterestCheck.Checked)
          {
            ShowAreasOfInterest();
          }
          else
          {
            LoadImage(_fileNames[_current]);
          }
        }
      }
    }

    private void ShowAreasOfInterest()
    {
      if (!_modifyingArea)
      {
        using (var graphics = Graphics.FromImage(_screenBitmap))
        {
          using (SolidBrush brush = new SolidBrush(aoiColor))
          {

            foreach (AreaOfInterest area in CurrentCam.AOI)
            {

              Rectangle rect = area.GetRect();
              graphics.FillRectangle(brush, rect);
            }
          }
        }

        pictureImage.Invalidate();
      }
    }

    private void EditAreasOfInterestToolStripMenuItem_Click(object sender, EventArgs e)
    {
      using (EditAreasOfInterest edit = new EditAreasOfInterest(CurrentCam.AOI)) // handles any changes in registration
      {
        DialogResult result = edit.ShowDialog();
        if (result == DialogResult.Yes)
        {
          // An artificial response showing that we have an Area of Interest boundary to change
          StartEditingArea(edit.EditAreaID);
        }
        else
        {
          lock (_fileLock)
          {
            if (_fileNames != null && _fileNames.Count > 0)
            {
              LoadImage(_fileNames[_current]);
            }
          }
        }
      }
    }

    void StartEditingArea(Guid areaID)
    {
      _modifyingAreaID = areaID;
      _modifyingArea = true;
      _modifyBox = new ZoneBox()
      {
        Parent = pictureImage
      };
      Rectangle screenRect = ScaleDataToScreen(CurrentCam.AOI[_modifyingAreaID].GetRect());
      Point zoneFocus = CurrentCam.AOI[_modifyingAreaID].ZoneFocus;
      _modifyBox.Location = new Point(screenRect.X, screenRect.Y);
      _modifyBox.ZoneFocus = zoneFocus;
      _modifyBox.Size = screenRect.Size;
      SetupEditingEnvironment();
      _modifyBox.Show();
      ControlMoverOrResizer.Start(_modifyBox);
    }

    void SetupEditingEnvironment()
    {
      toolsPanel.BackColor = SystemColors.ControlDarkDark;
      toolsPanel.Enabled = false;
      menuStrip2.Enabled = false;
      Text = "On Guard ****** Creating/Modifying Area of Interest - Escape to Quit, F1 to Accept ******";
    }

    void StopEditingEnvironment()
    {
      toolsPanel.BackColor = SystemColors.Control;
      toolsPanel.Enabled = true;
      menuStrip2.Enabled = true;
      Text = "On Guard";

    }



    // Currently unused, but it may be in the future
    int EqualPriorityOverlap(ImageObject imageObject, AreaOfInterest area)
    {
      int overlap;
      Rectangle intersect = Rectangle.Intersect(imageObject.ObjectRectangle, area.GetRect());
      var percentage = (((intersect.Width * intersect.Height) * 2) * 100f) / ((imageObject.ObjectRectangle.Width * imageObject.ObjectRectangle.Height) + (area.GetRect().Width * area.GetRect().Height));
      overlap = (int)percentage;

      return overlap;
    }

    // Currently unused, but it may be inthe future
    int ObjectToAreaOverlap(ImageObject imageObject, AreaOfInterest area)
    {
      int objectArea = imageObject.ObjectRectangle.Width * imageObject.ObjectRectangle.Height;
      int areaArea = area.GetRect().Width * area.GetRect().Height;
      Rectangle intersect = Rectangle.Intersect(imageObject.ObjectRectangle, area.GetRect());
      int intersectArea = intersect.Width * intersect.Height;

      double percentage = (100.0 * intersectArea) / objectArea;
      int overlap = (int)Math.Round(percentage);
      return overlap;
    }



    public static Rectangle ScaleDataToScreen(Rectangle rect)
    {
      Rectangle result = new Rectangle((int)Math.Round(rect.X / BitmapResolution.XScale), (int)Math.Round(rect.Y / BitmapResolution.YScale), (int)Math.Round(rect.Width / BitmapResolution.XScale), (int)Math.Round(rect.Height / BitmapResolution.YScale));
      return result;
    }

    public static Point ScaleDataToScreen(Point point)
    {
      Point result = new Point((int)Math.Round(point.X / BitmapResolution.XScale), (int)Math.Round(point.Y / BitmapResolution.YScale));
      return result;
    }

    private void AnalyzeButton_Click(object sender, EventArgs e)
    {
      if (!_showObjects)
      {
        showObjectRectanglesToolStripMenuItem.Checked = true;
        ShowObjectRectangelsToolStripMenuItem_Click(showObjectRectanglesToolStripMenuItem, null);
      }

      if (null != _frameObjects)
      {
        List<ImageObject> frameObjects = LoadImage(_fileNames[_current]);
        AIAnalyzer.RemoveDuplicateVehiclesInImage(frameObjects);
        FrameAnalyzer analyzer = new FrameAnalyzer(CurrentCam.AOI, frameObjects);
        AnalysisResult result = analyzer.AnalyzeFrame();
        using (InterestingItemsDialog dlg = new InterestingItemsDialog(result))
        {
          dlg.ShowDialog();
        }
      }
      else
      {
        MessageBox.Show(this, "There are no objects on this picture to analyze", "Nothing Here!");
      }
    }


    private async void LiveCameraButton_Click(object sender, EventArgs e)
    {
      string urlString;

      motionOnlyCheckbox.Checked = false;
      CameraContactData data = CurrentCam.LiveContactData;  // for clarity
      if (data.CameraXResolution > 0 && data.CameraYResolution > 0)
      {
        urlString = string.Format("http://{0}:{1}/image/{2}?q=100&w={3}&h={4}&user={5}&pw={6}",
          data.CameraIPAddress, data.Port.ToString(), data.ShortCameraName,
          data.CameraXResolution, data.CameraYResolution, data.CameraUserName, data.CameraPassword);
      }
      else
      {
        urlString = string.Format("http://{0}:{1}/image/{2}?q=100&user={3}&pw={4}",
          data.CameraIPAddress, data.Port.ToString(), data.ShortCameraName,
          data.CameraUserName, data.CameraPassword);
      }

      try
      {
        Uri uri = new Uri(urlString);
        System.Net.HttpWebRequest webRequest = (System.Net.HttpWebRequest)HttpWebRequest.Create(uri);
        webRequest.AllowWriteStreamBuffering = true;
        webRequest.Timeout = 30000;

        using (WebResponse webResponse = await webRequest.GetResponseAsync().ConfigureAwait(true))
        {
          using (var stream = webResponse.GetResponseStream())
          {
            using (MemoryStream memStream = new MemoryStream())
            {
              stream.CopyTo(memStream);
              //bitmap = new Bitmap(stream);

              ProcessImage(memStream, "Live Image");
            }
          }
        }

      }
      catch (HttpException ex)
      {
        Dbg.Write("MainWindow - LiveCameraButton_Click = Error  snapshot/live image: " + ex.Message);
        MessageBox.Show("There was an error attempting to get a snapshot.  Please check your camera Live Camera tab and make sure the settings for your camera are correct: " + ex.Message, "Error obtaining snapshot - Application Exit");
        Application.Exit();
      }
      catch (WebException ex)
      {
        Dbg.Write("MainWindow - There was an error attempting to get a snapshot.  Please check your camera Live Camera tab and make sure the settings for your camera are correct: " + ex.Message);
        if (sender is System.Windows.Forms.Timer)
        {
          Application.Exit();
        }
        MessageBox.Show("There was an error attempting to get a snapshot.  Please check your camera Live Camera tab and make sure the settings for your camera are correct: " + ex.Message, "Error obtaining snapshot - Application Exit");
        Application.Exit();
      }

      fileNameTextBox.Text = "Live Image";
      _showingLiveView = true;

    }

    // /cam/{cam-short-name}/pos=x Performs a PTZ command on the specified camera, where x= 0=left, 1=right, 2=up, 3=down, 4=home, 5=zoom in, 6=zoom out

    enum CameraDirections
    {
      left = 0,
      right = 1,
      up = 2,
      down = 3,
      home = 4,
      zoomIn = 5,
      zoomOut = 6
    }



    async void CameraDirectionButton(CameraDirections direction)
    {
      motionOnlyCheckbox.Checked = false;
      string urlString = string.Format("http://{0}:{1}/cam/{2}/pos={3}&user={4}&pw={5}", CurrentCam.LiveContactData.CameraIPAddress,
         CurrentCam.LiveContactData.Port.ToString(),
        CurrentCam.LiveContactData.ShortCameraName, (int)direction,
        CurrentCam.LiveContactData.CameraUserName,
        CurrentCam.LiveContactData.CameraPassword);
      try
      {
        System.Net.HttpWebRequest webRequest = (HttpWebRequest)HttpWebRequest.Create(new Uri(urlString));
        webRequest.AllowWriteStreamBuffering = true;
        webRequest.Timeout = 30000;

        System.Net.WebResponse webResponse = await webRequest.GetResponseAsync().ConfigureAwait(true);

        var stream = webResponse.GetResponseStream();
        using (MemoryStream memStream = new MemoryStream())
        {
          stream.CopyTo(memStream);
          //bitmap = new Bitmap(stream);
        }

        webResponse.Close();
      }
      catch (HttpException ex)
      {
        Dbg.Write("MainWindow - CameraDirectionButton - HttpException: " + ex.Message);
      }

      await Task.Delay(1000 * 1).ConfigureAwait(true);
      LiveCameraButton_Click(null, null);
    }

    private void CamZoomOut_Click(object sender, EventArgs e)
    {
      CameraDirectionButton(CameraDirections.zoomOut);
    }

    private void CamDownButton_Click(object sender, EventArgs e)
    {
      CameraDirectionButton(CameraDirections.down);
    }

    private void ZoomInButton_Click(object sender, EventArgs e)
    {
      CameraDirectionButton(CameraDirections.zoomIn);
    }

    private void CamUpButton_Click(object sender, EventArgs e)
    {
      CameraDirectionButton(CameraDirections.up);
    }

    private void CamLeftButton_Click(object sender, EventArgs e)
    {
      CameraDirectionButton(CameraDirections.left);
    }

    private void CamRightButton_Click(object sender, EventArgs e)
    {
      CameraDirectionButton(CameraDirections.right);
    }


    private void SettingsToolStripMenuItem_Click(object sender, EventArgs e)
    {
      using (SettingsDialog dlg = new SettingsDialog())
      {
        if (dlg.ShowDialog() == DialogResult.OK)
        {
        }
      }
    }


    /// <summary>
    /// Events for all cameras come in here as a file is changed in the directory we are watching
    /// Just put it in the queue and we will process it in a different thread 
    /// </summary>
    /// <param name="camData"></param>
    /// <param name="fileName"></param>
    void OnCameraImage(CameraData camData, string fileName)
    {
      lock (_fileLock)  // Since the check on the files processed/processing check/add must be attomic with respect to the queue
      {
        if (!_filesPendingProcessing.ContainsKey(fileName)) // So we won't get double adds like the FileSystemWatcher does
        {
          _filesPendingProcessing.TryAdd(fileName, fileName);
          _fileQueue.Enqueue(new PendingItem(camData, fileName));
          _wakeFileQueue.Set(); // Wake up the queue monitoring thread.  Maybe it can process it right now
        }
      }

    }

    // Here we passed all of the tests from the AI and have compared the objects to the AOIs.
    // Now, we need to figure out who to notify and notify them

    static async void Notify(Frame frame)
    {
      // Url notification is (right now)  oriented toward notifying BlueIris cameras to record.
      // So, there is no sense notifying it multiple times.  However, different areas
      // may have different cool down times, etc.  
      // So, we go through the list and take note of all urls to notify
      // The hashset will not accept duplicates.
      string fileName = frame.Item.PendingFile;

      List<UrlOptions> urlsToNotify = new List<UrlOptions>();
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
          await MQTTPublish.Publish(frame.Item.CamData.CameraPrefix, ooi.Area, frame).ConfigureAwait(false);
          /*}*/
        }

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

      foreach (var notify in urlsToNotify)
      {
        string urlStr;
        string confirmStr = string.Empty;

        if (notify.Url.Contains("{Auto Fill"))
        {
          // "http://jasdfsafjifia.com/jasf";
          urlStr = string.Format("http://{0}:{1}/admin?trigger&camera={2}&user={3}&pw={4}&jpeg={5}&memo={6}",
            frame.Item.CamData.LiveContactData.CameraIPAddress,
            frame.Item.CamData.LiveContactData.Port,
            HttpUtility.UrlEncode(frame.Item.CamData.LiveContactData.ShortCameraName),
            HttpUtility.UrlEncode(frame.Item.CamData.LiveContactData.CameraUserName),
            HttpUtility.UrlEncode(frame.Item.CamData.LiveContactData.CameraPassword),
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
            frame.Item.CamData.LiveContactData.CameraIPAddress,
            frame.Item.CamData.LiveContactData.Port,
            HttpUtility.UrlEncode(frame.Item.CamData.LiveContactData.ShortCameraName),
            HttpUtility.UrlEncode(frame.Item.CamData.LiveContactData.CameraUserName),
            HttpUtility.UrlEncode(frame.Item.CamData.LiveContactData.CameraPassword),
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
          await Task.Delay(1000 * notify.WaitTime).ConfigureAwait(false);
        }

        // Do the standard notify
        await NotifyUrl(urlStr).ConfigureAwait(false);
        Dbg.Trace("Sent URL Notification: " + urlStr);

        if (!string.IsNullOrEmpty(confirmStr))
        {
          await NotifyUrl(confirmStr).ConfigureAwait(false);
          Dbg.Trace("Sent BI Notification: " + confirmStr);
        }
      }

    }


    static async Task NotifyUrl(string urlStr)
    {
      using (HttpClient client = new HttpClient())
      {
        try
        {
          client.Timeout = TimeSpan.FromSeconds(20.0);
          Uri url = new Uri(urlStr);
          HttpResponseMessage response = await client.GetAsync(url).ConfigureAwait(false);
          if (response.IsSuccessStatusCode)
          {
            Dbg.Write("Successfully notified URL: " + urlStr);
          }
          else
          {
            Dbg.Write("Error notifying URL: " + urlStr + " -- Reponse Code: " + response.StatusCode.ToString());
          }

          response.Dispose();
        }
        catch (HttpRequestException ex)
        {
          Dbg.Write("MainWindow - NotifyUrl - Exception caught in NotifyUrl: " + ex.Message + " --- " + urlStr);
        }
        catch (HttpException ex)
        {
          Dbg.Write("MainWindow - NotifyUrl - Exception caught in NotifyUrl: " + ex.Message);
        }
        catch (Exception ex)
        {
          Dbg.Write("MainWindow - NotifyUrl - Unknown Exception caught in NotifyUrl: " + ex.Message);
        }

      }
    }

    // Currently unused, but it may be in the future
    static async Task NotifyViaEmail(string emailRecipients, HashSet<string> acvityDesc, string fileName)
    {

      try
      {
        using (MailMessage mail = new MailMessage())
        {
          using (SmtpClient SmtpServer = new SmtpClient(Storage.GetGlobalString("EmailServer")))
          {
            mail.BodyEncoding = Encoding.UTF8;
            mail.IsBodyHtml = true;
            mail.From = new MailAddress(Storage.GetGlobalString("EmailUser"));
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

            SmtpServer.Port = Storage.GetGlobalInt("EmailPort");

            SmtpServer.Port = Storage.GetGlobalInt("EmailPort");
            string emailUserName = Storage.GetGlobalString("EmailUser");
            string emailPassword = Storage.GetGlobalString("EmailPassword");

            if (!string.IsNullOrEmpty(emailUserName))
            {
              SmtpServer.Credentials = new System.Net.NetworkCredential(emailUserName, emailPassword);
            }

            SmtpServer.EnableSsl = Storage.GetGlobalBool("EmailSSL");

            await SmtpServer.SendMailAsync(mail).ConfigureAwait(false);
          }
        }
      }
      catch (SmtpException ex)
      {
        Dbg.Write("MainWindow - NotifyViaEmail - Email exception: " + ex.ToString());
      }
    }




    private async void PresetButton_Click(object sender, EventArgs e)
    {
      using (WaitCursor _ = new WaitCursor())
      {
        motionOnlyCheckbox.Checked = false;
        string urlString = string.Format("http://{0}:{1}/admin?camera={2}&preset={3}&user={4}&pw={5}",
        CurrentCam.LiveContactData.CameraIPAddress,
        CurrentCam.LiveContactData.Port.ToString(),
        CurrentCam.LiveContactData.ShortCameraName,
        (int)presetNumeric.Value,
        CurrentCam.LiveContactData.CameraUserName,
        CurrentCam.LiveContactData.CameraPassword);

        try
        {
          System.Net.HttpWebRequest webRequest = (HttpWebRequest)HttpWebRequest.Create(new Uri(urlString));
          webRequest.AllowWriteStreamBuffering = true;
          webRequest.Timeout = 30000;

          using (System.Net.WebResponse webResponse = await webRequest.GetResponseAsync().ConfigureAwait(true))
          {
            var stream = webResponse.GetResponseStream();
            using (MemoryStream memStream = new MemoryStream())
            {
              stream.CopyTo(memStream);
              //bitmap = new Bitmap(stream);
            }
          }
        }
        catch (HttpRequestException ex)
        {
          Dbg.Write("MainWindow - PresetButton_Click - HttpWebRequest - " + ex.Message);
        }
        catch (Exception ex)
        {
          Dbg.Write("MainWindow - PresetButton_Click - HttpWebRequest - " + ex.Message);
        }

        await Task.Delay(1000 * 5).ConfigureAwait(true);
        LiveCameraButton_Click(null, null);
      }
    }

    private void NotificationOptionsToolStripMenuItem_Click(object sender, EventArgs e)
    {
      //NotificationOptionsDialog dlg = new NotificationOptionsDialog(_areaNotifications);
      //DialogResult result = dlg.ShowDialog();
    }

    private void CameraSettingsToolStripMenuItem_Click(object sender, EventArgs e)
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
      }

      using (CameraCollection tmp = new CameraCollection(_allCameras))
      {
        tmp.StopMonitoring();

        _allCameras.Dispose();  // This cleans up the directory monitoring, and a lot of other stuff
        _allCameras = null;
        cameraCombo.Items.Clear();

        using (CameraConfigurationDialog dlg = new CameraConfigurationDialog(tmp))  // This makes a deep copy of the cameras collection
        {
          DialogResult result = dlg.ShowDialog();

          if (result == DialogResult.OK)
          {
            _allCameras = dlg.AllCameraData;  // a reference, not a copy (since the dialog does a deep copy, and we want the altered one)

            if (null == dlg.SelectedCamera)
            {
              Storage.SetGlobalString("CurrentCameraPath", string.Empty);    // we don't need to do this if we canceled the dlg
              Storage.SetGlobalString("CurrentCameraPrefix", string.Empty);
            }
            else
            {
              SetCurrentCamera(dlg.SelectedCamera);   // The one set by the dialog
            }
          }
          else
          {
            _allCameras = new CameraCollection(tmp);
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

        _allCameras.StartMonitoring();

        // And reconnnect all cameras to this form for new images
        foreach (var cam in _allCameras.CameraDictionary.Values)
        {
          if (cam.Monitoring)
          {
            cam.Monitor.OnNewImage += OnCameraImage;
          }
        }
      }
    }

    private void SetCurrentCamera(CameraData cam)
    {
      _allCameras.CurrentCameraPath = CameraData.PathAndPrefix(cam);    // which sets the current camera in _allCameras
      Storage.SetGlobalString("CurrentCameraPath", cam.Path);
      Storage.SetGlobalString("CurrentCameraPrefix", cam.CameraPrefix);
      // _allCameras.CameraDictionary[CameraData.PathAndPrefix(cam)] = cam;
      CameraCollection.Save(_allCameras);
      InitAnalyzer(cam.CameraPrefix, cam.Path);

    }

    private void OutgoingEmailServerToolStripMenuItem_Click(object sender, EventArgs e)
    {
      using (OutgoingEmailDialog dlg = new OutgoingEmailDialog())
      {
        dlg.ShowDialog();
      }
    }

    delegate void RefreshDelegate(object sender, EventArgs e);
    private void Refresh_Click(object sender, EventArgs e)
    {
      if (!this.InvokeRequired)
      {
        using (WaitCursor _ = new WaitCursor())
        {
          lock (_fileLock)
          {
            _current = 0;
            InitAnalyzer(CurrentCam.CameraPrefix, CurrentCam.Path);
          }
        }
      }
      else
      {
        BeginInvoke(new RefreshDelegate(Refresh_Click), new object[] { null, null });
      }
    }

    private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
    {
      using (AboutDialog dlg = new AboutDialog())
      {
        dlg.ShowDialog();
      }
    }


    private delegate void SetProgressDelegate(int cpuLoad);

    private void UpdateCPULoad(int cpuLoad)
    {
      if (cpuProgress.InvokeRequired)
      {
        BeginInvoke(new SetProgressDelegate(UpdateCPULoad), new object[] { cpuLoad });
        return;

      }

      cpuProgress.Value = cpuLoad;

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

      List<Task> taskList = new List<Task>();

      while (!stopIt)
      {
        stopIt = _stopEvent.WaitOne(0);
        if (stopIt) break;

        DateTime startLoop = DateTime.Now;
        theCPUCounter.NextValue();
        if (!keepgoing) // Only wait if there was nothing in the queue
        {
          var waitResult = WaitHandle.WaitAny(waitFor, 200);  // Monitor the queue 5 times per second
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
          if (currentCPU < 95 || (_recentTimes.Avg() < (1250.0 * _timePerFrame)))
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
                var myTask = Task.Run(() => StartAIAnalysis(pendingItem));
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


    async Task StartAIAnalysis(PendingItem pendingItem)
    {
      Dbg.Trace("Starting AI analysis of file: " + pendingItem.PendingFile);
      FileStream stream;

      bool continueTrying;
      do

      {
        try
        {
          continueTrying = false;
          using (stream = File.OpenRead(pendingItem.PendingFile)) // May fail if the file is still open.  There is no other (good) way to tell if the file is still being written to
          {
            if (!continueTrying)
            {
              // We were able to open the file so it has been closed
              _filesPendingProcessing.TryRemove(pendingItem.PendingFile, out string f);

              AIResult result = await AIAnalyzer.DetectObjectsAsync(stream, pendingItem).ConfigureAwait(false); //really do it async

              if (null == _allCameras)
              {
                // we went into camera setup, we can't process any further
                return;
              }

              Interlocked.Increment(ref _numberOfImagesProcessed);
              UpdateNumberProcessed(_numberOfImagesProcessed);
              _recentTimes.AddValue(result.Item.TotalProcessingTime().TotalMilliseconds);
              Interlocked.Decrement(ref _imagesBeingProcessed);
              List<InterestingObject> interesting = null;
              Frame frame = new Frame(pendingItem, interesting);


              if (null != result.ObjectsFound)  // Did we find any objects the AI could recognize?
              {
                // Analyze the frame with respect to the areas of interest for this camera only.
                // However, note (currently) that you can in theory have multiple "cameras" using the same prefix but different file paths.
                // In that case we use the same AOI

                if (null != pendingItem.CamData)
                {
                  _analyzer.RemoveInvalidObjects(pendingItem.CamData, result.ObjectsFound);  // This may remove items from the list, and may zero it out

                  if (result.ObjectsFound.Count > 0)
                  {
                    Dbg.Trace("Starting FRAME analysis of file: " + pendingItem.PendingFile + " with: " + result.ObjectsFound.Count.ToString() + " objects");
                    FrameAnalyzer frameAnalyzer = new FrameAnalyzer(pendingItem.CamData.AOI, result.ObjectsFound);
                    interesting = frameAnalyzer.AnalyzeFrame().InterestingObjects;  // find if the objects we did find are interesting (relatively fast)

                    frame.Interesting = interesting;
                    Dbg.Write(interesting.Count.ToString() + " interesting objects found in file: " + pendingItem.PendingFile);


                    if (interesting.Count > 0)
                    {
                      StartMotionTimeout(pendingItem);
                    }

                    frame.Item.CamData.FrameHistory.Add(frame);
                    if (frame.Interesting.Count > 0)
                    {
                      var myTask = Task.Run(() => AddToMotionFramesTable(pendingItem));
                    }

                    Notify(frame);
                  }
                }
              }

              ProcessAccumulation(frame);
            }
          }
        }
        catch (IOException)
        {
          continueTrying = true;
          await Task.Delay(100).ConfigureAwait(false);
        }

      } while (continueTrying);

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

    async void MotionStoppedNotify(object camObj)
    {
      CameraData camera = (CameraData)camObj;

      lock (camera)
      {
        camera.MotionStoppedTimer.Dispose();
        camera.Monitor = null;
        camera.MotionStoppedTimer = null;
      }

      foreach (var area in camera.AOI)
      {
        if (area.Notifications.NoMotionMQTTNotify)
        {
          Dbg.Write("Motion Stopped MQTT - " + camera.CameraPrefix + " - " + area.AOIName);
          string topic = Storage.GetGlobalString("MQTTStoppedTopic");
          topic = topic.Replace("{Camera}", camera.CameraPrefix);
          topic = topic.Replace("{Motion}", camera.CameraPrefix);

          string payload = Storage.GetGlobalString("MQTTStoppedPayload");
          payload = payload.Replace("{Motion}", "off");
          await MQTTPublish.Publish(topic, payload).ConfigureAwait(false);
        }

        if (!string.IsNullOrEmpty(area.Notifications.NoMotionUrlNotify))
        {
          Dbg.Write("Motion Stopped HTTP - " + camera.CameraPrefix + " - " + area.AOIName);
          await NotifyUrl(area.Notifications.NoMotionUrlNotify).ConfigureAwait(false);
        }
      }
    }


    #region SqlStuff

    async void AddToMotionFramesTable(PendingItem pending)
    {
      FileInfo fi = new FileInfo(pending.PendingFile);

      try
      {
        using (SqlConnection con = new SqlConnection(_connectionString))
        {
          con.Open();

          try
          {
            using (SqlCommand cmd = new SqlCommand("INSERT into tblMotionFiles (CreationTime, FileName, Path, Camera) VALUES (@creationTime, @fileName, @path, @camera)", con))
            {
              cmd.Parameters.AddWithValue("@creationTime", fi.CreationTime.ToFileTime());
              cmd.Parameters.AddWithValue("@fileName", fi.Name);
              cmd.Parameters.AddWithValue("@path", pending.CamData.Path);
              cmd.Parameters.AddWithValue("@camera", pending.CamData.CameraPrefix);
              Dbg.Trace("Adding to Motion table: " + fi.Name);
              int rowsAdded = await cmd.ExecuteNonQueryAsync().ConfigureAwait(false);
            }
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
      }
      catch (SqlException ex)
      {
        Dbg.Write("MainWindow - SQL Exception opeinging connection for adding motion file to database: " + ex.Message);
      }
      catch (InvalidOperationException ex)
      {
        Dbg.Write("MainWindow - InvalidOperation Exception opeinging connection for adding motion file to database: " + ex.Message);
      }
    }

    string GetNextMotion(bool directionUp)
    {
      string result = string.Empty;
      string q;
      long fileTime = _lastMotionTime;
      bool readSuccess = false;
      string path;
      string file = string.Empty;


      if (directionUp)
      {
        q = "SELECT TOP 1 * FROM tblMotionFiles WHERE CreationTime > @lastTime AND Path = @path AND Camera = @camera ORDER BY CreationTime ASC";
      }
      else
      {
        q = "SELECT TOP 1  * FROM tblMotionFiles WHERE CreationTime < @lastTime AND Path = @path AND Camera = @camera";
      }

      try
      {
        using (SqlConnection con = new SqlConnection(_connectionString))
        {
          con.Open();

          while (true)  // If a file has been deleted we may need to look for the next file multiple times
          {
            result = string.Empty;

            using (SqlCommand cmd = new SqlCommand(q, con))
            {

              cmd.Parameters.AddWithValue("@lastTime", fileTime);
              DateTime lastReadable;
              try
              {
                lastReadable = DateTime.FromFileTime(fileTime);  // debug only
              }
              catch (ArgumentOutOfRangeException)
              {
                lastReadable = DateTime.Now - TimeSpan.FromDays(10000);
              }

              cmd.Parameters.AddWithValue("@path", CurrentCam.Path);
              cmd.Parameters.AddWithValue("@camera", CurrentCam.CameraPrefix);

              try
              {

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                  if (reader.HasRows)
                  {
                    reader.Read();
                    fileTime = reader.GetInt64(1);
                    DateTime dt = DateTime.FromFileTime(fileTime);  // debug only
                    path = reader.GetString(3);
                    path = path.Trim();
                    file = reader.GetString(2);
                    file = file.Trim();
                    result = Path.Combine(path, file);
                    readSuccess = true;
                  }
                  else
                  {
                    break;
                  }
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
                int index = _fileNames.IndexOf(result);
                if (index > -1)
                {
                  _current = _fileNames.IndexOf(result);
                  break;  // done
                }
                else
                {
                  // The file does not exist in the working set
                  DeleteMissingMotion(file);  // and we will repeat the process until we find another or none exist
                }
              }
              else
              {
                result = string.Empty;
                break;  // done, but with no file result
              }

            }
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

      return result;
    }


    /// <summary>
    /// If the motion frame does not exist, add it.
    /// This is called when browsing notices that there is interesting motion.
    /// Since we've done the hard work if analyzing the frame we just add it if ncessary.
    /// </summary>
    /// <param name="directionUp"></param>
    /// <returns></returns>
    async void InsertMotionIfNecessary(string fileName)
    {
      string q = "IF NOT EXISTS(SELECT CreationTime FROM tblMotionFiles WHERE CreationTime = @creationTime AND FileName = @fileName)" +
        "INSERT INTO tblMotionFiles(CreationTime, FileName, Path, Camera) VALUES(@creationTime, @fileName, @path, @camera)";

      using (SqlConnection con = new SqlConnection(_connectionString))
      {
        try
        {
          await con.OpenAsync().ConfigureAwait(false);
        }
        catch (SqlException ex)
        {
          Dbg.Write("MainWindow -  InsertMotionIfNecessary - Sql Exception on opening database connection: " + ex.Message);
          return;
        }
        catch (InvalidOperationException ex)
        {
          Dbg.Write("MainWindow -  InsertMotionIfNecessary - InvalidOperation Exception on opening database connection: " + ex.Message);
          return;

        }

        using (SqlCommand cmd = new SqlCommand(q, con))
        {
          FileInfo fi = new FileInfo(fileName);

          try
          {
            cmd.Parameters.AddWithValue("@creationTime", fi.CreationTime.ToFileTime());
            cmd.Parameters.AddWithValue("@fileName", fi.Name);
            cmd.Parameters.AddWithValue("@path", CurrentCam.Path);
            cmd.Parameters.AddWithValue("@camera", CurrentCam.CameraPrefix);
            await cmd.ExecuteScalarAsync().ConfigureAwait(false);
          }
          catch (DbException ex)
          {
            Dbg.Write("MainWindow - InsertMotionIfNecessary - DbException: " + ex.Message);
          }
          catch (Exception ex)
          {
            Dbg.Write("MainWindow - InsertMotionIfNecessary - Exception: " + ex.Message);
          }
        }
      }
    }


    /// <summary>
    /// DeleteMissingMotion - When there is a motion file entry in the DB, but the file
    /// is no longer a valid file, remove it from the DB.
    /// This happens frequently when BlueIris or the user deletes the picture.
    /// </summary>
    /// <param name="fileName"></param>
    async void DeleteMissingMotion(string fileName)
    {

      try
      {
        using (SqlConnection con = new SqlConnection(_connectionString))
        {
          await con.OpenAsync().ConfigureAwait(false);


          try
          {
            string q = "DELETE FROM tblMotionFiles WHERE Path = @path AND Camera = @camera AND FileName = @fileName";


            using (SqlCommand cmd = new SqlCommand(q, con))
            {
              cmd.Parameters.AddWithValue("@path", CurrentCam.Path);
              cmd.Parameters.AddWithValue("@camera", CurrentCam.CameraPrefix);
              cmd.Parameters.AddWithValue("@fileName", fileName);
              Dbg.Trace("Removing motion from table - file missing: " + fileName);
              await cmd.ExecuteNonQueryAsync().ConfigureAwait(false);
            }
          }
          catch (DbException ex)
          {
            Dbg.Write("MainWindow - DeleteMissingMotion - DbException: " + ex.Message);
          }
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
          if (timeSinceLast < Storage.GetGlobalInt("EventInterval"))
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
      using (EmailAddressesDialog dlg = new EmailAddressesDialog(EmailAddresses.EmailAddressList))
      {
        if (dlg.ShowDialog() == DialogResult.OK)
        {
          EmailAddresses.Save();
        }
      }
    }

    private void OnCameraSelected(object sender, EventArgs e)
    {
      if (cameraCombo.SelectedItem != CurrentCam)
      {
        motionOnlyCheckbox.Checked = false;
        SetCurrentCamera((CameraData)cameraCombo.SelectedItem);
      }
    }

    private void OnSizeChanged(object sender, EventArgs e)
    {
      BitmapResolution.XScale = (double)BitmapResolution.XResolution / (double)pictureImage.Width;
      BitmapResolution.YScale = (double)BitmapResolution.YResolution / (double)pictureImage.Height;

    }


    private async void CleanupButton_Click(object sender, EventArgs e)
    {
      using (CleanupDialog dlg = new CleanupDialog(_allCameras, CurrentCam.Path, CurrentCam.CameraPrefix))
      {
        DialogResult result = dlg.ShowDialog();
        if (result == DialogResult.OK)
        {
          MessageBox.Show("You may continue working, but the working set will be refreshed upon completion!", "File Deletion About to Start!");
          await Task.Run(() => CleanupAsync(dlg.ExpiredFiles, dlg.ExcludeMotion)).ConfigureAwait(false);
          Refresh_Click(sender, e);
          MessageBox.Show("The working set was refreshed!", "Updated!");
        }
      }
    }


    bool IsMotionFile(SqlConnection con, string fileName)
    {
      bool result = false;
      string q;

      q = "SELECT FileName FROM tblMotionFiles WHERE FileName = @fileName and @Path = @path";

      using (SqlCommand cmd = new SqlCommand(q, con))
      {
        cmd.Parameters.AddWithValue("@fileName", Path.GetFileName(fileName));
        cmd.Parameters.AddWithValue("@path", Path.GetDirectoryName(fileName));
        try
        {
          using (SqlDataReader reader = cmd.ExecuteReader())
          {
            if (reader.HasRows)
            {
              result = true;
            }
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
      using (SqlConnection con = new SqlConnection(_connectionString))
      {
        con.Open();
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
              File.Delete(info.FullName);
            }

            Thread.Sleep(0);  // avoid choking the UI
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

    }

    private void AreasOfInterestToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (!_modifyingArea)
      {
        ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;
        showAreasOfInterestCheck.Checked = menuItem.Checked;
        ShowAreasOfInterestCheckChanged(null, null);
      }

    }

    private void OnLiveImageTimer(Object o, EventArgs e)
    {
      LiveCameraButton_Click(o, e);
    }

    private void LiveCheck_CheckedChanged(object sender, EventArgs e)
    {
      motionOnlyCheckbox.Checked = false;
      if (liveCheck.Checked)
      {
        showObjectRectanglesToolStripMenuItem.Checked = false;
        showAreasOfInterestCheck.Checked = false;
        _showObjects = false;
        _liveTimer = new System.Windows.Forms.Timer
        {
          Interval = 100
        };
        _liveTimer.Tick += OnLiveImageTimer;
        _liveTimer.Start();
      }
      else
      {
        _liveTimer.Dispose();
        _liveTimer = null;
      }

    }


    private void NotifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
    {
      Show();
      this.WindowState = FormWindowState.Normal;
      notifyIcon.Visible = false;
    }

    private void OnResize(object sender, EventArgs e)
    {
      if (this.WindowState == FormWindowState.Minimized)
      {
        Hide();
        notifyIcon.Visible = true;
        notifyIcon.ShowBalloonTip(1200);
      }
    }

    private void LogFileToolStripMenuItem_Click(object sender, EventArgs e)
    {
      string path = Storage.GetFilePath("OnGuard.txt");
      if (File.Exists(path))
      {
        Process.Start(path);
      }
      else
      {
        MessageBox.Show("The log file does not exist.  Did you delete it?", "No Log File!");
      }
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

      using (MQTTSettings mqttSettings = new MQTTSettings())
      {
        DialogResult result = mqttSettings.ShowDialog();
        if (result == DialogResult.OK)
        {
          Dbg.Write("MQTT Settings Saved");
        }
      }
    }


    private void Button1_Click(object sender, EventArgs e)
    {
      _test.Item.CamData.FrameHistory.GetFramesInTimespan(TimeSpan.FromSeconds(200), _test.Item.TimeEnqueued, TimeDirection.Before);
      _test.Item.CamData.FrameHistory.GetFramesInTimespan(TimeSpan.FromSeconds(200), _test.Item.TimeEnqueued, TimeDirection.After);
      _test.Item.CamData.FrameHistory.GetFramesInTimespan(TimeSpan.FromSeconds(200), _test.Item.TimeEnqueued, TimeDirection.Both);
    }

    private async void TestImagesToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (MessageBox.Show(this, "You are about to send test images to all cameras.  There is no guarantee that this images will match your Areas of Interest.  After the test pictures are saved your workspace will refresh.  Proceed?", "Send Test Images", MessageBoxButtons.YesNo) == DialogResult.Yes)
      {
        foreach (var cam in _allCameras.CameraDictionary)
        {
          string path = cam.Value.Path;
          string[] pics = new string[7];
          pics[0] = "Street1";
          pics[1] = "Street2";
          pics[2] = "Street3";
          pics[3] = "Street4";
          pics[4] = "Street5";
          pics[5] = "Street6";
          pics[6] = "Street7";


          ResourceManager MyResourceClass = new ResourceManager(typeof(Resources));

          ResourceSet resourceSet = MyResourceClass.GetResourceSet(CultureInfo.CurrentUICulture, true, true);
          foreach (DictionaryEntry entry in resourceSet)
          {
            string resourceKey = entry.Key.ToString();
            object resource = entry.Value;
          }

          foreach (string pic in pics)
          {
            object O = Resources.ResourceManager.GetObject(pic); //Return an object from the image chan1.png in the project
            using (Bitmap bm = (Bitmap)O)
            {
              using (MemoryStream mem = new MemoryStream())
              {
                string fullPath = Path.Combine(path, cam.Value.CameraPrefix);
                fullPath += pic;
                fullPath += DateTime.Now.Ticks.ToString() + ".jpg";
                bm.Save(fullPath, ImageFormat.Jpeg);
                // bm.Save(mem, ImageFormat.Jpeg);
              }
            }
          }
        }
      }

      await Task.Delay(1000 * 3).ConfigureAwait(false);
      Refresh_Click(null, null);
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
  }

}
