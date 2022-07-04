using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


using Mictlanix.DotNet.Onvif;
using Mictlanix.DotNet.Onvif.Common;
using Mictlanix.DotNet.Onvif.Ptz;



namespace OnGuardCore
{
  public partial class PTZMovement : Form
  {
    CameraData _camera;
    OnVIFSupport _onvif;
    ManualResetEvent _stop = new (false);


    public PTZMovement(CameraData camera)
    {
      InitializeComponent();
      _camera = camera;
      labelCameraName.Text = "Current Camera: " + _camera.CameraPrefix;

      if (_camera.Contact.PTZContactMethod == PTZMethod.OnVIF)
      {
        InitOnVIF();
      }
    }

    private async void InitOnVIF()
    {
      CameraContactData data = _camera.Contact;
      if (data.ONVIF == null)
      {
        camLeftButton.Enabled = false;
        camRightButton.Enabled = false;
        camUpButton.Enabled = false;
        camDownButton.Enabled = false;
        zoomInButton.Enabled = false;
        zoomOutButton.Enabled = false;

        _onvif = new OnVIFSupport();
        await _onvif.Init(data.CameraIPAddress, data.OnVIFPort, data.CameraUserName, data.CameraPassword).ConfigureAwait(true);

        camLeftButton.Enabled = true;
        camRightButton.Enabled = true;
        camUpButton.Enabled = true;
        camDownButton.Enabled = true;
        zoomInButton.Enabled = true;
        zoomOutButton.Enabled = true;
      }
      else
      {
        _onvif = data.ONVIF;
      }

      NumericPanTime.Value = (decimal)_camera.Contact.PanTime;
      NumericPanSpeed.Value = (decimal)_camera.Contact.PanSpeed;
      NumericTiltSpeed.Value = (decimal)_camera.Contact.TiltSpeed;
      NumericTiltTime.Value = (decimal)_camera.Contact.TiltTime;
      NumericZoomSpeed.Value = (decimal)_camera.Contact.ZoomSpeed;
      NumericZoomTime.Value = (decimal)_camera.Contact.ZoomTime;

      Task.Run(() => DisplayLiveImagesAsync()).ConfigureAwait(true);
    }

    private void PTZMovement_Load(object sender, EventArgs e)
    {

    }

    private void OKButton_Click(object sender, EventArgs e)
    {
      CameraContactData data = _camera.Contact;
      data.PanSpeed = (double)NumericPanSpeed.Value;
      data.TiltSpeed = (double)NumericTiltSpeed.Value;
      data.ZoomSpeed = (double)NumericZoomSpeed.Value;

      data.PanTime = (double)NumericPanTime.Value;
      data.TiltTime = (double)NumericTiltTime.Value;
      data.ZoomTime = (double)NumericZoomTime.Value;
      data.ONVIF = _onvif;

      DialogResult = DialogResult.OK;
    }

    private void CancelButton_Click(object sender, EventArgs e)
    {
      DialogResult = DialogResult.Cancel;
    }

    PTZSpeed GetSpeed(CameraDirections dir)
    {
      PTZSpeed speed = new ();

      Vector2D pan = new ();
      Vector1D zoom = new ();

      switch (dir)
      {
        case CameraDirections.left:
          pan.x = -1.0f * (float)NumericPanSpeed.Value;
          pan.y = 0;
          zoom.x = 0;
          break;

        case CameraDirections.right:
          pan.x = (float)NumericPanSpeed.Value;
          pan.y = 0;
          zoom.x = 0;
          break;

        case CameraDirections.up:
          pan.x = 0;
          pan.y = (float)NumericTiltSpeed.Value;
          zoom.x = 0;
          break;

        case CameraDirections.down:
          pan.x = 0;
          pan.y = -1.0f * (float)NumericTiltSpeed.Value;
          zoom.x = 0;
          break;

        case CameraDirections.zoomIn:
          pan.x = 0;
          pan.y = 0;
          zoom.x = (float)NumericTiltSpeed.Value;
          break;

        case CameraDirections.zoomOut:
          pan.x = 0;
          pan.y = 0;
          zoom.x = -1.0f * (float)NumericTiltSpeed.Value;
          break;
      }

      speed.PanTilt = pan;
      speed.Zoom = zoom;
      return speed;
    }

    private async void CamUpButton_Click(object sender, EventArgs e)
    {

      if (null != _onvif)
      {
        PTZSpeed speed = GetSpeed(CameraDirections.up);
        await _onvif.Ptz.ContinuousMoveAsync(_onvif.Profiles[0].Token, speed, null);
        await Task.Delay((int)(1000 * NumericTiltTime.Value)).ConfigureAwait(true);
        await _onvif.Ptz.StopAsync(_onvif.Profiles[0].Token, true, true);
      }
      else
      {
        string url = _camera.Contact.HTTPPanUp;
        await MoveToPresetAsync(url).ConfigureAwait(true);

        if (!string.IsNullOrEmpty(_camera.Contact.HTTPStop))
        {
          await Task.Delay((int)(1000 * NumericTiltTime.Value)).ConfigureAwait(true);
          await MoveToPresetAsync(_camera.Contact.HTTPStop).ConfigureAwait(true);
        }

      }
    }

    private async void CamRightButton_Click(object sender, EventArgs e)
    {
      if (null != _onvif)
      {
        PTZSpeed speed = GetSpeed(CameraDirections.right);
        await _onvif.Ptz.ContinuousMoveAsync(_onvif.Profiles[0].Token, speed, null);
        await Task.Delay((int)(1000 * NumericTiltTime.Value)).ConfigureAwait(true);
        await _onvif.Ptz.StopAsync(_onvif.Profiles[0].Token, true, true);
      }
      else
      {
        string url = _camera.Contact.HTTPPanRight;
        await MoveToPresetAsync(url).ConfigureAwait(true);

        if (!string.IsNullOrEmpty(_camera.Contact.HTTPStop))
        {
          await Task.Delay((int)(1000 * NumericTiltTime.Value)).ConfigureAwait(true);
          await MoveToPresetAsync(_camera.Contact.HTTPStop).ConfigureAwait(true);
        }

      }
    }

    private async void CamDownButton_Click(object sender, EventArgs e)
    {
      if (null != _onvif)
      {
        PTZSpeed speed = GetSpeed(CameraDirections.down);
        await _onvif.Ptz.ContinuousMoveAsync(_onvif.Profiles[0].Token, speed, null);
        await Task.Delay((int)(1000 * NumericTiltTime.Value)).ConfigureAwait(true);
        await _onvif.Ptz.StopAsync(_onvif.Profiles[0].Token, true, true);
      }
      else
      {

        string url = _camera.Contact.HTTPPanDown;
        await MoveToPresetAsync(url).ConfigureAwait(true);

        if (!string.IsNullOrEmpty(_camera.Contact.HTTPStop))
        {
          await Task.Delay((int)(1000 * NumericTiltTime.Value)).ConfigureAwait(true);
          await MoveToPresetAsync(_camera.Contact.HTTPStop).ConfigureAwait(true);
        }
      }
    }

    private async void CamLeftButton_Click(object sender, EventArgs e)
    {
      if (null != _onvif)
      {
        PTZSpeed speed = GetSpeed(CameraDirections.left);
        await _onvif.Ptz.ContinuousMoveAsync(_onvif.Profiles[0].Token, speed, null);
        await Task.Delay((int)(1000 * NumericTiltTime.Value)).ConfigureAwait(true);
        await _onvif.Ptz.StopAsync(_onvif.Profiles[0].Token, true, true);
      }
      else
      {

        string url = _camera.Contact.HTTPPanLeft;
        await MoveToPresetAsync(url).ConfigureAwait(true);

        if (!string.IsNullOrEmpty(_camera.Contact.HTTPStop))
        {
          await Task.Delay((int)(1000 * NumericTiltTime.Value)).ConfigureAwait(true);
          await MoveToPresetAsync(_camera.Contact.HTTPStop).ConfigureAwait(true);
        }
      }

    }

    private async void ZoomInButton_Click(object sender, EventArgs e)
    {
      if (null != _onvif)
      {
        PTZSpeed speed = GetSpeed(CameraDirections.zoomIn);
        await _onvif.Ptz.ContinuousMoveAsync(_onvif.Profiles[0].Token, speed, null);
        await Task.Delay((int)(1000 * NumericTiltTime.Value)).ConfigureAwait(true);
        await _onvif.Ptz.StopAsync(_onvif.Profiles[0].Token, true, true);
      }
      else
      {

        string url = _camera.Contact.HTTPZoomIn;
        await MoveToPresetAsync(url).ConfigureAwait(true);

        if (!string.IsNullOrEmpty(_camera.Contact.HTTPStop))
        {
          await Task.Delay((int)(1000 * NumericTiltTime.Value)).ConfigureAwait(true);
          await MoveToPresetAsync(_camera.Contact.HTTPStop).ConfigureAwait(true);
        }
      }

    }

    private async void CamZoomOut_Click(object sender, EventArgs e)
    {
      if (null != _onvif)
      {
        PTZSpeed speed = GetSpeed(CameraDirections.zoomOut);
        await _onvif.Ptz.ContinuousMoveAsync(_onvif.Profiles[0].Token, speed, null);
        await Task.Delay((int)(1000 * NumericTiltTime.Value)).ConfigureAwait(true);
        await _onvif.Ptz.StopAsync(_onvif.Profiles[0].Token, true, true);
      }
      else
      {

        string url = _camera.Contact.HTTPZoomOut;
        await MoveToPresetAsync(url).ConfigureAwait(true);

        if (!string.IsNullOrEmpty(_camera.Contact.HTTPStop))
        {
          await Task.Delay((int)(1000 * NumericTiltTime.Value)).ConfigureAwait(true);
          await MoveToPresetAsync(_camera.Contact.HTTPStop).ConfigureAwait(true);
        }
      }
    }

    async Task MoveToPresetAsync(string moveUrl)
    {

      try
      {
        CameraContactData data = _camera.Contact;
        moveUrl = data.ReplaceParmeters(moveUrl);
        System.Net.HttpWebRequest webRequest = (HttpWebRequest)HttpWebRequest.Create(new Uri(moveUrl));

        if (data.JpgContactMethod != PTZMethod.BlueIris)
        {
          webRequest.Credentials = new System.Net.NetworkCredential(data.CameraUserName, data.CameraPassword);
        }

        webRequest.AllowWriteStreamBuffering = true;
        webRequest.Timeout = 30000;

        try
        {
          using System.Net.WebResponse webResponse = await webRequest.GetResponseAsync().ConfigureAwait(true);
        }
        catch (WebException ex)
        {
          Dbg.Write(LogLevel.Warning, "PTZMovement - Move - Exception: " + ex.Message);
        }
      }
      catch (Exception ex)
      {
        Dbg.Write(LogLevel.Warning, "PTZMovement - Move - Exception: " + ex.Message);
      }
    }

    async Task DisplayLiveView()
    {
      camLeftButton.Enabled = false;
      camRightButton.Enabled = false;
      camUpButton.Enabled = false;
      camDownButton.Enabled = false;
      zoomInButton.Enabled = false;
      zoomOutButton.Enabled = false;


      camLeftButton.Enabled = true;
      camRightButton.Enabled = true;
      camUpButton.Enabled = true;
      camDownButton.Enabled = true;
      zoomInButton.Enabled = true;
      zoomOutButton.Enabled = true;

    }

    async Task DisplayLiveImagesAsync()
    {
      while (true)
      {
        await ShowPTZImage().ConfigureAwait(true);
        if (_stop.WaitOne(200))
        {
          break;
        }
      }
    }

    async Task ShowPTZImage()

    {

      CameraContactData data = _camera.Contact;  // for clarity
      string urlString = data.JPGSnapshotURL;
      urlString = data.ReplaceParmeters(urlString);

      try
      {
        Uri uri = new (urlString);

        System.Net.HttpWebRequest webRequest = (System.Net.HttpWebRequest)HttpWebRequest.Create(uri);
        if (data.JpgContactMethod != PTZMethod.BlueIris)
        {
          webRequest.Credentials = new System.Net.NetworkCredential(data.CameraUserName, data.CameraPassword);
        }

        webRequest.AllowWriteStreamBuffering = true;
        webRequest.Timeout = 3000;

        using WebResponse webResponse = await webRequest.GetResponseAsync().ConfigureAwait(true);
        using var stream = webResponse.GetResponseStream();
        using MemoryStream memStream = new ();
        await stream.CopyToAsync(memStream);

        Bitmap bitmap = new (memStream);
        {

          if (null == bitmap)
          {
            MessageBox.Show(this, "There was an error obtaining the snapshot/video.  Please check your Live Camera settings", "Error Contacting the Camera");
          }
          else
          {
            PictureImageBox.Image = bitmap;
          }
        }
      }
      catch (Exception ex)
      {
        MessageBox.Show(this, "There was an error obtaining the snapshot/video.  Please check your PTZ settings", "Error Contacting the Camera");
      }

    }

    private void HelpButton_Click(object sender, EventArgs e)
    {
      using HelpBox dlg = new ("Test Pan/Tilt/Zoom Movement", new Size(640, 480), "PTZMovementHelp.rtf");
      dlg.ShowDialog();
    }
  }
}