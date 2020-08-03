
using SAAI.Properties;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
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
using System.Windows.Forms.VisualStyles;

namespace SAAI
{

  public partial class MainWindow : Form
  {
    readonly AIAnalyzer _analyzer;
    List<string> _fileNames;

    int _current = 0;
    bool _showObjects = true;
    bool _mouseIsDown = false;
    bool _mouseInBounds = false;
    Point _upperLeft = new Point();
    Point _lowerRight = new Point();
    Bitmap _screenBitmap;
    Bitmap _rectBackground;
    double _xScale;
    double _yScale;
    bool _showingLiveView;
    int _imagesBeingProcessed;
    int _numberOfImagesProcessed;

    readonly MostRecentCollection _recentTimes = new MostRecentCollection(10);
    readonly object _fileLock = new object();

    AllCameras _allCameras;

    Rectangle _previousRectangle = new Rectangle(0, 0, 0, 0);
    List<ImageObject> _frameObjects = new List<ImageObject>();
    readonly Color aoiColor = Color.FromArgb(80, Color.DarkOrange);
    readonly Color aoiRegistrationColor = Color.FromArgb(120, Color.Purple);
    readonly ConcurrentQueue<PendingItem> _fileQueue = new ConcurrentQueue<PendingItem>();
    readonly AutoResetEvent _wakeFileQueue = new AutoResetEvent(false);
    readonly Thread _monitorQueueThread;
    readonly double _timePerFrame = 1.0;
    System.Windows.Forms.Timer _liveTimer;


    readonly ConcurrentDictionary<string, string> _filesPendingProcessing = new ConcurrentDictionary<string, string>(); // very short period of time where the file has been removed from the queue yet still hasn't been opened
    readonly ManualResetEvent _stopEvent = new ManualResetEvent(false);  // set to shut down the MonitorQueue thread (and anything else)

    CameraData _currentCamera;  // This is only a reference to the data in the AllCamera collection.  It saves a lot of typing and adds clarity
    readonly private PerformanceCounter theCPUCounter =
       new PerformanceCounter("Processor", "% Processor Time", "_Total");


    public MainWindow()
    {

      // Settings.Default.Reset();   // Only uncomment this when you want to clear out the stored settings

      int currentCPU = (int)theCPUCounter.NextValue(); // aways returns 0 on the first go around?
      currentCPU = (int)theCPUCounter.NextValue();

      InitializeComponent();

      _monitorQueueThread = new Thread(MonitorQueue);
      _monitorQueueThread.Start();

      Settings.Default.SettingsKey = "OnGuard";
      Settings.Default.Reload();
      Settings.Default.SettingChanging += Default_SettingChanging;
      if (!Settings.Default.AISetup)
      {
        InitialSetup();
      }

      _analyzer = new AIAnalyzer();
      _allCameras = AllCameras.Load();    // which also inits the camera
      _currentCamera = _allCameras.CurrentCamera;

      if (_currentCamera != null)
      {
        Settings.Default.CurrentCameraPath = _currentCamera.Path;
        Settings.Default.CurrentCameraPrefix = _currentCamera.CameraPrefix;
        InitAnalyzer(_currentCamera.CameraPrefix, _currentCamera.Path);
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

      if (null != _currentCamera)
      {
        cameraCombo.SelectedItem = _currentCamera;
      }


      KeyPreview = true;
      Focus();
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

      while (result == DialogResult.Cancel)
      {
        using (CameraConfigurationDialog cameraDialog = new CameraConfigurationDialog(_allCameras))
        {

          result = cameraDialog.ShowDialog();
          _allCameras = cameraDialog.AllCameraData;  // regardless of the OK/Cancel in the dialog we just copy the reference

          if (result == DialogResult.OK)
          {
            _allCameras = cameraDialog.AllCameraData;    // the list has been copied and returned
            AllCameras.Save(_allCameras);

            if (null == cameraDialog.CurrentCam)
            {

              Settings.Default.CurrentCameraPath = string.Empty;
              Settings.Default.CurrentCameraPrefix = string.Empty;
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
          if (result == DialogResult.Yes)
          {
            Application.Exit();
          }
        }
      }

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

      pictureImage.Image = null;
      _showObjects = true;
      showAreasOfInterestCheck.Checked = false;
      _upperLeft = Point.Empty;
      _lowerRight = Point.Empty;

      if (null != _screenBitmap)
      {
        _screenBitmap.Dispose();
        _screenBitmap = null;
      }

      if (null != _rectBackground)
      {
        _rectBackground.Dispose();
        _rectBackground = null;
        _previousRectangle = Rectangle.Empty;
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

      fileNumberUpDown.Maximum = _fileNames.Count;
      fileNumberUpDown.Minimum = (int)1;
    }

    private void ButtonRight_Click(object sender, EventArgs e)
    {
      using (WaitCursor _ = new WaitCursor())
      {
        lock (_fileLock)
        {
          if (_fileNames != null && _current < _fileNames.Count - 1)
          {
            ++_current;
            LoadImage(_fileNames[_current]);
          }
        }
      }
    }

    private void ButtonLeft_Click(object sender, EventArgs e)
    {
      using (WaitCursor _ = new WaitCursor())
      {

        lock (_fileLock)
        {
          if (_fileNames != null && _current > 0)
          {
            --_current;
            LoadImage(_fileNames[_current]);
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
          using (FileStream stream = new FileStream(file, FileMode.Open))
          {
            result = ProcessImage(stream, file);

            currentNumberTextBox.Text = (_fileNames.IndexOf(file) + 1).ToString();
            fileNameTextBox.Text = file;
            _showingLiveView = false;
          }
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

    readonly string[] _itemsOfSecurityInterest = new string[15] {"person",
                                                            "car",
                                                            "truck",
                                                            "bicycle",
                                                            "motorbike",
                                                            "bus",
                                                            "train",
                                                            "boat",
                                                            "cat",
                                                            "dog",
                                                            "horse",
                                                            "sheep",
                                                            "cow",
                                                            "elephant",
                                                            "bear"
                                          };

    private List<ImageObject> ProcessImage(Stream stream, string imageName)
    {

      if (_frameObjects != null)
      {
        _frameObjects.Clear();
      }

      objectListView.Items.Clear();
      pictureImage.Image = null;

      Bitmap tmp = new Bitmap(stream);  // We don't know the width & height so we can't use a method that defines pixel format
      _screenBitmap = new Bitmap(tmp);  // The bitmap from the disk is 24bpp,the copy is 32bpp (and, yes, it matters)
      tmp.Dispose();
      BitmapResolution.XResolution = _screenBitmap.Width;
      BitmapResolution.YResolution = _screenBitmap.Height;
      _xScale = (double)_screenBitmap.Width / (double)pictureImage.Width;
      _yScale = (double)_screenBitmap.Height / (double)pictureImage.Height;
      stream.Position = 0;


      if (_showObjects)
      {
        try
        {
          _frameObjects = _analyzer.ProcessVideoImageViaAI(stream, imageName).Result;
        }
        catch (AiNotFoundException ex)
        {
          MessageBox.Show(ex.Message + Environment.NewLine + "Either start the AI or change the locaton and port of that application.", "Startup Error!");
          using (SettingsDialog dlg = new SettingsDialog())
          {
            if (dlg.ShowDialog() == DialogResult.OK)
            {
              _frameObjects = null;
              MessageBox.Show("You must now restart this application!", "Exit Now!");
              Application.Exit();
            }
          }

          return null;
        }


        if (_frameObjects != null)
        {
          string[] subItems = new string[6];
          foreach (ImageObject obj in _frameObjects)
          {
            if (_itemsOfSecurityInterest.Contains(obj.Label))
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

      if (!(_currentCamera.RegistrationX == 0 && _currentCamera.RegistrationY == 0))
      {
        using (SolidBrush registrationBrush = new SolidBrush(aoiRegistrationColor))
        {
          using (var graphics = Graphics.FromImage(_screenBitmap))
          {
            Rectangle rect = Rectangle.FromLTRB(_currentCamera.RegistrationX - 10, _currentCamera.RegistrationY - 10,
                                              _currentCamera.RegistrationX + 10, _currentCamera.RegistrationY + 10);

            graphics.FillRectangle(registrationBrush, rect);

          }
        }
      }

      pictureImage.Image = _screenBitmap;

      return _frameObjects;
    }


    private async void GoToFileButton_Click(object sender, EventArgs e)
    {
      lock (_fileLock)
      {
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

    private async void GoToFileNameButton_Click(object sender, EventArgs e)
    {
      lock (_fileLock)
      {
        if (!string.IsNullOrEmpty(goToFileTextBox.Text) && File.Exists(goToFileTextBox.Text))
        {
          LoadImage(goToFileTextBox.Text);
        }
      }
    }


    private async void OnReverseListButton(object sender, EventArgs e)
    {
      lock (_fileLock)
      {
        _fileNames.Reverse();
        _current = 0;
        LoadImage(_fileNames[0]);
      }
    }

    private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Application.Exit();
    }

    private void ShowObjectRectangelsToolStripMenuItem_Click(object sender, EventArgs e)
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

    private void OnKeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.PageUp)
      {
        e.Handled = true;
        ButtonRight_Click(sender, e);
      }
      else if (e.KeyCode == Keys.PageDown)
      {
        e.Handled = true;
        ButtonLeft_Click(sender, e);
      }
    }

    private void Form1_Load(object sender, EventArgs e)
    {
      this.Focus();
    }

    private void OnMouseMove(object sender, MouseEventArgs e)
    {
      int mouseX = (int)Math.Round((e.Location.X * _xScale));
      int mouseY = (int)Math.Round(e.Location.Y * _yScale);
      xPosLabel.Text = mouseX.ToString();
      yPosLabel.Text = mouseY.ToString();


      if (_mouseIsDown && _mouseInBounds)
      {

        if (mouseX != 0 && mouseY != 0)
        {
          if (!(mouseX > _upperLeft.X && mouseY > _upperLeft.Y))
          { }
          else
          {
            // Here we have a valid mouse position that is greater than the previous one
            _lowerRight = new Point();

            if (e.X >= pictureImage.Width - 1)
            {
              _lowerRight.X = BitmapResolution.XResolution - 2;
            }
            else
            {
              _lowerRight.X = mouseX;
            }

            if (mouseY >= BitmapResolution.YResolution - 1)
            {
              _lowerRight.Y = _screenBitmap.Height - 2;
            }
            else
            {
              _lowerRight.Y = mouseY;
            }

            Rectangle newRectangle = new Rectangle(_upperLeft.X, _upperLeft.Y, _lowerRight.X - _upperLeft.X, _lowerRight.Y - _upperLeft.Y);

            using (var graphics = Graphics.FromImage(_screenBitmap))
            {
              RestoreBackgroundImage(graphics);
              SaveBackgroundImage(newRectangle);
              newRectangle = Rectangle.Intersect(newRectangle, new Rectangle(0, 0, _screenBitmap.Width, _screenBitmap.Height)); // ensure it is cropped

              // Now we can finally draw the rectangle we want
              using (SolidBrush brush = new SolidBrush(aoiColor))
              {
                graphics.FillRectangle(brush, newRectangle);
                pictureImage.Invalidate();

              }
            }
          }
        }

      }
    }

    // newRectangle is in bitmap coordinates, not screen
    void SaveBackgroundImage(Rectangle newRectangle)
    {
      _previousRectangle = new Rectangle(Math.Max(newRectangle.X - 1, 0), Math.Max(newRectangle.Y - 1, 0), newRectangle.Width + 3, newRectangle.Height + 3);
      _previousRectangle = Rectangle.Intersect(_previousRectangle, new Rectangle(0, 0, _screenBitmap.Width, _screenBitmap.Height));

      if (_screenBitmap == null)
      {
        Dbg.Write("MainWindows.SaveBackgroundImage - _screenBitmap is null");
      }

      if (null != _rectBackground)
      {
        _rectBackground.Dispose();
      }

      try
      {
        _rectBackground = _screenBitmap.Clone(_previousRectangle, _screenBitmap.PixelFormat);
      }
      catch (OutOfMemoryException ex)
      {
        Dbg.Write("MainWindows.SaveBackgroundImage - Invalid bitmap rectangle " + ex.Message);
      }
    }

    void RestoreBackgroundImage(Graphics graphics)
    {
      // We need to restore the background of the previous rectangle
      if (_previousRectangle.Width > 0 && _previousRectangle.Height > 0) // our old value of the rectangle exists?
      {
        graphics.DrawImage(_rectBackground, _previousRectangle, new Rectangle(0, 0, _rectBackground.Width, _rectBackground.Height), GraphicsUnit.Pixel);
        _rectBackground.Dispose();
      }
    }

    void AdjustAreasOfInterest(int clickX, int clickY)
    {

      int newX = (int)Math.Round(clickX * _xScale);
      int newY = (int)Math.Round(clickY * _yScale);

      int offsetX = _currentCamera.RegistrationX - newX;
      int offsetY = _currentCamera.RegistrationY - newY;

      // If this area is of type registration then adjust everybody's x & Y
      // BUT, only if there was already a registration point
      if (_currentCamera.RegistrationX > 0 && _currentCamera.RegistrationY > 0)
      {
        foreach (var x in _currentCamera.AOI)
        {
          x.AreaRect.X -= offsetX;
          x.AreaRect.Y -= offsetY;

        }

        AllCameras.Save(_allCameras);
      }

      _currentCamera.RegistrationX = newX;
      _currentCamera.RegistrationY = newY;
      _currentCamera.RegistrationX = _currentCamera.RegistrationX;
      _currentCamera.RegistrationY = _currentCamera.RegistrationY;
      _allCameras.CameraDictionary[CameraData.PathAndPrefix(_currentCamera)].RegistrationX = _currentCamera.RegistrationX;
      _allCameras.CameraDictionary[CameraData.PathAndPrefix(_currentCamera)].RegistrationY = _currentCamera.RegistrationY;
      AllCameras.Save(_allCameras);

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
      if ((Control.ModifierKeys & Keys.Control) == Keys.Control)
      {
        if (MessageBox.Show("You are about to set the registration point for this camera.  This helps you ensure that your camera is in the right position.  If the registration point has already been set, then any existing areas of interest will be shifted accordingly.  Are you sure you want to do this?", "Reset Camera Registration Point", MessageBoxButtons.YesNo) == DialogResult.Yes)
        {
          AdjustAreasOfInterest(e.X, e.Y);
        }
      }
      else
      {

        if (_mouseInBounds)
        {
          if (!_mouseIsDown)
          {
            _mouseIsDown = true;
            _upperLeft = new Point((int)Math.Round(e.X * _xScale), (int)Math.Round(e.Y * _yScale));
            _previousRectangle = new Rectangle(0, 0, 0, 0);
            if (null != _rectBackground)
            {
              _rectBackground.Dispose();
            }
          }
          else
          {
          }
        }
      }
    }

    private void OnMouseUp(object sender, MouseEventArgs e)
    {
      _mouseIsDown = false;
      Rectangle areaRect = Rectangle.FromLTRB(_upperLeft.X, _upperLeft.Y, _lowerRight.X, _lowerRight.Y);
      if (areaRect.Width > 0 && areaRect.Height > 0)
      {
        if (_currentCamera.RegistrationX == 0 || _currentCamera.RegistrationY == 0)
        {
          if ((Control.ModifierKeys & Keys.Control) != Keys.Control)
          {
            MessageBox.Show("You can create areas of interest by using a mouse click down and drag.  However, before you can do this you must set a camera registration point so that you can ensure that your camera is always position correctly.  You do this by holding the control key and then clicking in the desired position for the registration point.  That point should be on a spot that is easily recoginzed when viewing the camera.", "Set Camera Registration Point First!");
          }
        }
        else
        {
          using (CreateAOI dlg = new CreateAOI(areaRect))
          {

            DialogResult result = dlg.ShowDialog();

            if (result == DialogResult.Cancel)
            {
              using (var graphics = Graphics.FromImage(_screenBitmap))
              {
                RestoreBackgroundImage(graphics);
                if (null != _rectBackground)
                {
                  _rectBackground.Dispose();
                }

                _previousRectangle = Rectangle.Empty;
                _lowerRight = Point.Empty;
                pictureImage.Invalidate();

              }
            }
            else
            {

              _currentCamera.AOI.AddArea(dlg.Area);
            }
          }
        }
      }
    }

    private void OnMouseLeave(object sender, EventArgs e)
    {
      _mouseInBounds = false;

    }

    private void OnMouseEnter(object sender, EventArgs e)
    {
      _mouseInBounds = true;
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
      using (var graphics = Graphics.FromImage(_screenBitmap))
      {
        using (SolidBrush brush = new SolidBrush(aoiColor))
        {

          foreach (AreaOfInterest area in _currentCamera.AOI)
          {

            Rectangle rect = area.AreaRect;
            graphics.FillRectangle(brush, rect);
          }
        }
      }

      pictureImage.Invalidate();
    }

    private void EditAreasOfInterestToolStripMenuItem_Click(object sender, EventArgs e)
    {
      using (EditAreasOfInterest edit = new EditAreasOfInterest(_currentCamera.AOI)) // handles any changes in registration
      {
        edit.ShowDialog();
      }
      lock (_fileLock)
      {
        if (_fileNames != null && _fileNames.Count > 0)
        {
          LoadImage(_fileNames[_current]);
        }
      }
    }


    // Currently unused, but it may be in the future
    int EqualPriorityOverlap(ImageObject imageObject, AreaOfInterest area)
    {
      int overlap;
      Rectangle intersect = Rectangle.Intersect(imageObject.ObjectRectangle, area.AreaRect);
      var percentage = (((intersect.Width * intersect.Height) * 2) * 100f) / ((imageObject.ObjectRectangle.Width * imageObject.ObjectRectangle.Height) + (area.AreaRect.Width * area.AreaRect.Height));
      overlap = (int)percentage;

      return overlap;
    }

    // Currently unused, but it may be inthe future
    int ObjectToAreaOverlap(ImageObject imageObject, AreaOfInterest area)
    {
      int objectArea = imageObject.ObjectRectangle.Width * imageObject.ObjectRectangle.Height;
      int areaArea = area.AreaRect.Width * area.AreaRect.Height;
      Rectangle intersect = Rectangle.Intersect(imageObject.ObjectRectangle, area.AreaRect);
      int intersectArea = intersect.Width * intersect.Height;

      double percentage = (100.0 * intersectArea) / objectArea;
      int overlap = (int)Math.Round(percentage);
      return overlap;
    }


    public Rectangle ScaleScreenToData(Rectangle rect)
    {
      Rectangle result = new Rectangle((int)Math.Round(rect.X * _xScale), (int)Math.Round(rect.Y * _yScale), (int)Math.Round(rect.Width * _xScale), (int)Math.Round(rect.Height * _yScale));
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
        FrameAnalyzer analyzer = new FrameAnalyzer(_currentCamera.AOI, frameObjects);
        AnalysisResult result = analyzer.AnalyzeFrame();
        using (InterestingItemsDialog dlg = new InterestingItemsDialog(result))
        {
          dlg.ShowDialog();
        }
      }
    }


    private async void LiveCameraButton_Click(object sender, EventArgs e)
    {
      string urlString;

      CameraContactData data = _currentCamera.LiveContactData;  // for clarity
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

        WebResponse webResponse = await webRequest.GetResponseAsync().ConfigureAwait(true);

        var stream = webResponse.GetResponseStream();
        using (MemoryStream memStream = new MemoryStream())
        {
          stream.CopyTo(memStream);
          //bitmap = new Bitmap(stream);

          ProcessImage(memStream, "Live Image");
        }

        webResponse.Close();
      }
      catch (Exception ex)
      {
        Dbg.Write("Error requestion snapshot/live image: " + ex.Message);
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
      string urlString = string.Format("http://{0}:{1}/cam/{2}/pos={3}&user={4}&pw={5}", _currentCamera.LiveContactData.CameraIPAddress,
         _currentCamera.LiveContactData.Port.ToString(),
        _currentCamera.LiveContactData.ShortCameraName, (int)direction,
        _currentCamera.LiveContactData.CameraUserName,
        _currentCamera.LiveContactData.CameraPassword);
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
      catch (Exception ex)
      {

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
      // may have different cool down times, etc. .  
      // So, we go through the list and take note of all urls to notify
      // The hashset will not accept duplicates.
      string fileName = frame.Item.PendingFile;

      HashSet<string> urlsToNotify = new HashSet<string>();
      //HashSet<string> activityType = new HashSet<string>();

      foreach (var ooi in frame.Interesting)
      {
        foreach (var notifyUrl in ooi.Area.Notifications.Urls)
        {
          if (notifyUrl.Active)
          {

            if (notifyUrl.CoolDown.CooldownExpired())
            {
              notifyUrl.CoolDown.Reset();
              urlsToNotify.Add(notifyUrl.Url);
            }
            else
            {
            }
          }
        }
      }


      foreach (var url in urlsToNotify)
      {
        string urlStr;
        if (url == "{Auto Fill}")
        {
          urlStr = string.Format("http://{0}:{1}/admin?trigger&camera={2}&user={3}&pw={4}",
            frame.Item.CamData.LiveContactData.CameraIPAddress,
            frame.Item.CamData.LiveContactData.Port,
            HttpUtility.UrlEncode(frame.Item.CamData.LiveContactData.ShortCameraName),
            HttpUtility.UrlEncode(frame.Item.CamData.LiveContactData.CameraUserName),
            HttpUtility.UrlEncode(frame.Item.CamData.LiveContactData.CameraPassword));
        }
        else
        {
          urlStr = url;
        }
        await NotifyUrl(urlStr).ConfigureAwait(false);
      }

      /*
      if (!string.IsNullOrEmpty(emailRecipients))
      {
        await NotifyViaEmail(emailRecipients, activityType, fileName).ConfigureAwait(false);
      }*/

    }


    static async Task NotifyUrl(string urlStr)
    {
      using (HttpClient client = new HttpClient())
      {
        try
        {
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
        }
        catch (Exception ex)
        {
          Dbg.Write("Exception caught in NotifyUrl: " + ex.Message);

        }
      }
    }

    // Currently unused, but it may bein the future
    static async Task NotifyViaEmail(string emailRecipients, HashSet<string> acvityDesc, string fileName)
    {

      try
      {
        using (MailMessage mail = new MailMessage())
        {
          using (SmtpClient SmtpServer = new SmtpClient(Settings.Default.EmailServer))
          {
            mail.BodyEncoding = Encoding.UTF8;
            mail.IsBodyHtml = true;
            mail.From = new MailAddress(Settings.Default.EmailUser);
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

            SmtpServer.Port = (int)Settings.Default.EmailPort;
            SmtpServer.Credentials = new System.Net.NetworkCredential(Settings.Default.EmailUser, Settings.Default.EmailPassword);
            SmtpServer.EnableSsl = Settings.Default.EmailSSL;

            await SmtpServer.SendMailAsync(mail).ConfigureAwait(false);
          }
        }
      }
      catch (SmtpException ex)
      {
        Dbg.Write("Email exception: " + ex.ToString());
      }
    }




    private async void PresetButton_Click(object sender, EventArgs e)
    {
      using (WaitCursor _ = new WaitCursor())
      {

        string urlString = string.Format("http://{0}:{1}/admin?camera={2}&preset={3}&user={4}&pw={5}",
        _currentCamera.LiveContactData.CameraIPAddress,
        _currentCamera.LiveContactData.Port.ToString(),
        _currentCamera.LiveContactData.ShortCameraName,
        (int)presetNumeric.Value,
        _currentCamera.LiveContactData.CameraUserName,
        _currentCamera.LiveContactData.CameraPassword);

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
        catch (Exception ex)
        {
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
      CameraData oldCamera = _currentCamera;  // which may be null - we need to track if the camera changed
      using (CameraConfigurationDialog dlg = new CameraConfigurationDialog(_allCameras))
      {

        // First, we must stop monitoring al cameras at least temporarily.
        // We can't have the camera disappear on us
        foreach (var cam in _allCameras.CameraDictionary.Values)
        {
          if (cam.Monitoring && null != cam.Monitor)
          {
            // Note that we do NOT turn the Monitoring flag off
            cam.Monitor.OnNewImage -= OnCameraImage; // unhook for new images       
          }
        }

        _allCameras.Dispose();  // get rid of this list since we made a copy of it in the dialog contructor (TODO: maybe before)
        _allCameras = null;

        DialogResult result = dlg.ShowDialog();
        _allCameras = dlg.AllCameraData;  // regardless of the OK/Cancel in the dialog we just copy the reference

        if (result == DialogResult.OK)
        {
          cameraCombo.Items.Clear();
          _allCameras = dlg.AllCameraData;    // the list has been copied and returned

          if (null == dlg.CurrentCam)
          {

            Settings.Default.CurrentCameraPath = string.Empty;
            Settings.Default.CurrentCameraPrefix = string.Empty;
          }
          else
          {
            SetCurrentCamera(dlg.CurrentCam);
          }

          foreach (var cam in _allCameras.CameraDictionary.Values)
          {
            cameraCombo.Items.Add(cam);
          }

          if (null != _currentCamera && !string.IsNullOrEmpty(_currentCamera.CameraPrefix))
          {
            cameraCombo.SelectedItem = _currentCamera;
          }

        }

        // This happens regardless of whether we OK'd the dialog because we turned off monitoring above
        foreach (var cam in _allCameras.CameraDictionary.Values)
        {
          if (cam.Monitoring)
          {
            cam.Monitor = new DirectoryMonitor(cam);
            cam.Monitor.OnNewImage += OnCameraImage;
          }
        }
      }

    }

    private void SetCurrentCamera(CameraData cam)
    {
      _currentCamera = cam;

      Settings.Default.CurrentCameraPath = cam.Path;
      Settings.Default.CurrentCameraPrefix = cam.CameraPrefix;
      Settings.Default.AISetup = true;
      Settings.Default.Save();
      _allCameras.CameraDictionary[CameraData.PathAndPrefix(cam)] = cam;
      AllCameras.Save(_allCameras);
      InitAnalyzer(cam.CameraPrefix, cam.Path);

    }

    private void OutgoingEmailServerToolStripMenuItem_Click(object sender, EventArgs e)
    {
      using (OutgoingEmailDialog dlg = new OutgoingEmailDialog())
      {
        dlg.ShowDialog();
      }
    }

    private void Refresh_Click(object sender, EventArgs e)
    {
      lock (_fileLock)
      {
        _current = 0;
        InitAnalyzer(_currentCamera.CameraPrefix, _currentCamera.Path);
      }
    }

    private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
    {
      using (AboutDlg dlg = new AboutDlg())
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
              var myTask = Task.Run(() => StartAIAnalysis(pendingItem));
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

              AIResult result = await _analyzer.DetectObjectsAsync(stream, pendingItem).ConfigureAwait(false); //really do it async
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
                  FrameAnalyzer analyzer = new FrameAnalyzer(pendingItem.CamData.AOI, result.ObjectsFound);
                  interesting = analyzer.AnalyzeFrame().InterestingObjects;  // find if the objects we did find are interesting (relatively fast)
                  frame.Interesting = interesting;
                  Dbg.Write(interesting.Count.ToString() + " interesting objects found");
                  Notify(frame);
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

    /// <summary>
    /// This method is a bit complex.  The goal is to start an interval for email accumulation if necessary.
    /// The reasons for this are documented below.
    /// </summary>
    /// <param name="cam"></param>
    /// <param name="interesting"></param>
    /// <param name="pendingItem"></param>
    private static void ProcessAccumulation(Frame frame)
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
          if (timeSinceLast < Settings.Default.EventInterval)
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

    private async void OnEmailsAccumulated(HashSet<string> emailAddresses, HashSet<string> files, HashSet<string> areaDescription)
    {

      foreach (string emailAddress in emailAddresses)
      {
        Task.Run(() => SendEmail(emailAddress, files, areaDescription));
      }
    }

    private static async Task SendEmail(string emailRecipients, HashSet<string> fileNames, HashSet<string> activityDesc)
    {
      try
      {
        using (MailMessage mail = new MailMessage())
        {
          using (SmtpClient SmtpServer = new SmtpClient(Settings.Default.EmailServer))
          {
            mail.BodyEncoding = Encoding.UTF8;
            mail.IsBodyHtml = true;
            mail.From = new MailAddress(Settings.Default.EmailUser);
            string rec = emailRecipients.TrimEnd(new char[] { ';', ' ' });
            mail.To.Add(rec);
            mail.Subject = "Security Camera Alert";   // todo get via ui
            mail.Body = "Your security camera noticed the following activity:<br />";

            foreach (var desc in activityDesc)
            {
              mail.Body += desc + "<br/>";
            }

            System.Net.Mail.Attachment attachment;

            foreach (string fileName in fileNames)
            {
              attachment = new System.Net.Mail.Attachment(fileName);
              mail.Attachments.Add(attachment);
            }

            SmtpServer.Port = (int)Settings.Default.EmailPort;
            SmtpServer.Credentials = new System.Net.NetworkCredential(Settings.Default.EmailUser, Settings.Default.EmailPassword);
            SmtpServer.EnableSsl = Settings.Default.EmailSSL;

            await SmtpServer.SendMailAsync(mail).ConfigureAwait(false);
            Dbg.Write("Email sent to: " + emailRecipients);
          }
        }
      }
      catch (SmtpException ex)
      {
        Dbg.Write("Email exception: " + ex.ToString());
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

      if (cameraCombo.SelectedItem != _currentCamera)
      {
        SetCurrentCamera((CameraData)cameraCombo.SelectedItem);
      }
    }

    private void OnSizeChanged(object sender, EventArgs e)
    {
      _xScale = (double)BitmapResolution.XResolution / (double)pictureImage.Width;
      _yScale = (double)BitmapResolution.YResolution / (double)pictureImage.Height;

    }

    private void CleanupFiles(string path)
    {
      // possibly notify the UI via event, maybe ask permission

      DirectoryInfo dir = new DirectoryInfo(path);
      var expiredFiles = dir.EnumerateFiles("*.jpg", SearchOption.TopDirectoryOnly)
          .Where(fi => fi.CreationTime + TimeSpan.FromHours(24) < DateTime.Now).ToList();


      DialogResult result = MessageBox.Show("You are about to delete " + expiredFiles.Count.ToString() + " pictures over 24 hours old.  Proceed?", "Delete Old Pictures", MessageBoxButtons.YesNo);
      if (result == DialogResult.Yes)
      {
        using (WaitCursor _ = new WaitCursor())
        {

          foreach (var info in expiredFiles)
          {
            try
            {
              File.Delete(info.FullName);
            }
            catch (UnauthorizedAccessException ex)
            {
              MessageBox.Show("Unable to delete file: " + info.FullName + Environment.NewLine + "This is probably due to your anti-virus software." +
                Environment.NewLine + "Exiting Cleanup!");
              break;
            }
          }
        }
      }

    }

    private void CleanupButton_Click(object sender, EventArgs e)
    {
      CleanupFiles(_currentCamera.Path);
      Refresh_Click(sender, e);
    }

    private void AreasOfInterestToolStripMenuItem_Click(object sender, EventArgs e)
    {
      ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;
      showAreasOfInterestCheck.Checked = menuItem.Checked;
      ShowAreasOfInterestCheckChanged(null, null);

    }

    private void OnLiveImageTimer(Object o, EventArgs e)
    {
      LiveCameraButton_Click(o, e);
    }

    private void LiveCheck_CheckedChanged(object sender, EventArgs e)
    {
      if (liveCheck.Checked)
      {
        showObjectRectanglesToolStripMenuItem.Checked = false;
        showAreasOfInterestCheck.Checked = false;
        _showObjects = false;
        _liveTimer = new System.Windows.Forms.Timer();
        _liveTimer.Interval = 100;
        _liveTimer.Tick += OnLiveImageTimer;
        _liveTimer.Start();
      }
      else
      {
        _liveTimer.Dispose();
        _liveTimer = null;
      }

    }

    private void showToolStripMenuItem_Click(object sender, EventArgs e)
    {

    }

    private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
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

    private void logFileToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Process.Start("OnGuard.txt");
    }
  }

}
