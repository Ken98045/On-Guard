using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Web;

namespace OnGuardCore
{
  public partial class TestPresets : Form
  {
    CameraData _camera;
    ManualResetEvent _stop = new (false);

    public TestPresets(CameraData camera)
    {
      _camera = camera;
      InitializeComponent();

      switch (_camera.Contact.PresetSettings.PresetMethod)
      {
        case PTZMethod.HTTP:
        case PTZMethod.iSpy:
          BuildHttpPresets();
          break;

        case PTZMethod.BlueIris:
          BuildBlueIrisPresets();
          break;

        case PTZMethod.OnVIF:
          BuildOnVIFPresets();
          break;

        case PTZMethod.None:
          ComboBoxPresets.Enabled = false;
          break;

      }


      labelCurrentCamera.Text = "Current Camera: " + camera.CameraPrefix;
      Task.Run(() => DisplayLiveImagesAsync()).ConfigureAwait(true);
    }

    void BuildBlueIrisPresets()
    {
      for (int i = 1; i < 100; ++i)
      {
        ComboboxItem item = new ("Preset" + i.ToString(), i.ToString());
        ComboBoxPresets.Items.Add(item);
      }
    }

    void BuildOnVIFPresets()
    {
      foreach (var p in _camera.Contact.ONVIF.PresetsResponse.Preset)
      {
        ComboboxItem item = new (p.Name, p.token);
        ComboBoxPresets.Items.Add(item);
      }

    }

    void BuildHttpPresets()
    {
      foreach (Preset preset in _camera.Contact.PresetSettings.PresetList)
      {
        ComboboxItem item = new (preset.Name, preset.Command);
        ComboBoxPresets.Items.Add(item);
      }
    }

    async Task DisplayLiveImagesAsync()
    {
      while (true)
      {
        await ShowPresetImageAsync().ConfigureAwait(true);
        if (_stop.WaitOne(200))
        {
          break;
        }
      }
    }

    private async void OnPresetChanged(object sender, EventArgs e)
    {
      ComboboxItem item = (ComboboxItem)ComboBoxPresets.SelectedItem;
      int selectedIndex = ComboBoxPresets.SelectedIndex;

      switch (_camera.Contact.PresetSettings.PresetMethod)
      {
        case PTZMethod.iSpy:
          await MoveToPreset(item.Value);
          break;

        case PTZMethod.HTTP:
          string command = CameraData.GetHttpParam(item.Value, selectedIndex);
          await MoveToPreset(command);
          break;

        case PTZMethod.OnVIF:
          await OnVIFMoveAsync(item.Value);
          break;

        case PTZMethod.BlueIris:
          BlueIrisMove(item.Value);
          break;

      }
    }


    private async Task OnVIFMoveAsync(string name)
    {
      await _camera.Contact.ONVIF.Ptz.GotoPresetAsync(_camera.Contact.ONVIF.SelectedProfile, name, null);
    }

    private async Task BlueIrisMove(string preset)
    {
      string urlString = $"http://{_camera.Contact.CameraIPAddress}:{_camera.Contact.Port}/admin?camera={HttpUtility.UrlEncode(_camera.Contact.CameraShortName)}&preset={preset}&user={HttpUtility.UrlEncode(_camera.Contact.CameraUserName)}&pw={HttpUtility.UrlEncode(_camera.Contact.CameraPassword)}";

      try
      {
        System.Net.HttpWebRequest webRequest = (HttpWebRequest)HttpWebRequest.Create(new Uri(urlString));
        webRequest.AllowWriteStreamBuffering = true;
        webRequest.Timeout = 30000;

        using System.Net.WebResponse webResponse = await webRequest.GetResponseAsync().ConfigureAwait(true);
        var stream = webResponse.GetResponseStream();
        using MemoryStream memStream = new ();
        await stream.CopyToAsync(memStream);
      }
      catch (HttpRequestException ex)
      {
        Dbg.Write(LogLevel.Warning, "MainWindow - PresetButton_Click - HttpWebRequest - " + ex.Message);
      }
      catch (Exception ex)
      {
        Dbg.Write(LogLevel.Error, "MainWindow - PresetButton_Click - HttpWebRequest - " + ex.Message);
      }

    }


    private async Task<bool> MoveToPreset(string command)
    {
      bool result = false;

      CameraContactData data = new (_camera.Contact);  // for clarity
      command = data.ReplaceParmeters(command);

      try
      {
        Uri uri = new (data.ReplaceParmeters(command));

          System.Net.HttpWebRequest webRequest = (System.Net.HttpWebRequest)HttpWebRequest.Create(uri);


        if (data.JpgContactMethod != PTZMethod.BlueIris)
        {
          webRequest.Credentials = new System.Net.NetworkCredential(data.CameraUserName, data.CameraPassword);
        }

        webRequest.AllowWriteStreamBuffering = true;
        webRequest.Timeout = 3000;

        using WebResponse webResponse = await webRequest.GetResponseAsync().ConfigureAwait(true);
        result = true;
      }
      catch (Exception ex)
      {
        MessageBox.Show(this, "There was an error attempting to move to the preset.  Please check your preset settings", "Preset Error!");
      }

      return result;
    }

    async Task ShowPresetImageAsync()
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
        webRequest.Timeout = 5000;

        using WebResponse webResponse = await webRequest.GetResponseAsync().ConfigureAwait(true);
        using var stream = webResponse.GetResponseStream();
        using MemoryStream memStream = new ();
        await stream.CopyToAsync(memStream);

        Bitmap bitmap = new (memStream);
        {

          if (null == bitmap)
          {
            MessageBox.Show(this, "There was an error obtaining the snapshot/video.  Please check your Live Camera settings", "Error Contacting the Camera");
            this.Close();
          }
          else
          {
            pictureBox.Image = bitmap;
          }
        }
      }
      catch (Exception ex)
      {
        MessageBox.Show(this, "There was an error obtaining the snapshot/video.  Please check your PTZ settings", "Error Contacting the Camera");
        this.Close();
      }

    }

    private async void ButtonRefresh_Click(object sender, EventArgs e)
    {
      await ShowPresetImageAsync().ConfigureAwait(true);
    }

    private void OKButton_Click(object sender, EventArgs e)
    {
      DialogResult = DialogResult.OK;
    }
  }

  public class ComboboxItem
  {
    public string Text { get; set; }
    public string Value { get; set; }

    public ComboboxItem(string text, string value)
    {
      Text = text;
      Value = value;
    }

    public override string ToString()
    {
      return Text;
    }
  }
}
