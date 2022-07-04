using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;

using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;

namespace OnGuardCore
{
  public partial class AutoFindCamera : Form
  {

    Dictionary<string, CameraMake> _makes;
    CameraData _camera;
    Dictionary<string, string> _urlsTried = new ();
    private volatile bool _stop = false;
    private volatile int _bestXRes;
    private volatile int _searchCount;
    private volatile int _alreadyTried = 0;
    private volatile string _lastUrl = string.Empty;

    public string FoundModel { get; set; }
    public string FoundMake { get; set; }

    public AutoFindCamera(CameraData camera, Dictionary<string, CameraMake> makes)
    {
      _camera = camera;
      _makes = makes;
      InitializeComponent();
    }

    private void OKButton_Click(object sender, EventArgs e)
    {
      FoundMake = MakeTextBox.Text;
      FoundModel = ModelTextBox.Text;
      DialogResult = DialogResult.OK;
    }

    private void CancelButton_Click(object sender, EventArgs e)
    {
      _stop = true;
      DialogResult = DialogResult.Cancel;
    }

    private void NumericUpDown1_ValueChanged(object sender, EventArgs e)
    {

    }

    private void UpdateTextBox(TextBox textBox, string text)
    {
      if (this.InvokeRequired)
      {
        this.BeginInvoke(new Action(() =>
        {
          textBox.Text = text;
        }));
      }
      else
      {
        textBox.Text = text;
      }
    }

    private void SetPictureBitmap(Bitmap bitmap)
    {
      if (this.InvokeRequired)
      {
        this.BeginInvoke(new Action(() =>
        {
          pictureImage.Image = bitmap;
          pictureImage.Refresh();
        }));
      }
      else
      {
        pictureImage.Image = bitmap;
        pictureImage.Refresh();
      }
    }


    private async void SearchButton_Click(object sender, EventArgs e)
    {
      _searchCount = 0;
      _alreadyTried = 0;
      _bestXRes = 0;
      _stop = false;
      ModelTextBox.Text = string.Empty;
      MakeTextBox.Text = string.Empty;
      pictureImage.Image = null;
      _urlsTried.Clear();
      try
      {
        await TryAllUrls().ConfigureAwait(true);
      }
      catch (Exception ex)
      {
        Dbg.Write(LogLevel.DetailedInfo, "AutoFindCamera - SearchButton_Click: " + ex.Message);
      }
      MessageBox.Show("Search Complete!", "Done");
    }

    async Task TryAllUrls()
    {
      foreach (var make in _makes)
      {
        foreach (var model in make.Value.models)
        {
          foreach (string url in model.Value.urls.Values)
          {
            if (_stop)
            {
              return;
            }

            // Try it only once, may repeat many, many times
            string urlString = url;
            urlString = _camera.Contact.ReplaceParmeters(urlString);

            if (!_urlsTried.ContainsKey(urlString))
            {
              await Task.Delay(100);  // avoid overloading the camera and getting false negatives
              _urlsTried[urlString] = urlString;
              ImageResult result = await ShowImage(urlString);
              Interlocked.Increment(ref _searchCount);
              UpdateTextBox(TriedCountTextBox, _searchCount.ToString());

              if (result.Result)
              {
                if (result.XRes >= (int)NumericMinRes.Value && result.XRes <= NumericMaxRes.Value)
                {
                  if (result.XRes > _bestXRes)
                  {
                    _bestXRes = result.XRes;
                    _lastUrl = url; // the raw url
                    UpdateTextBox(MakeTextBox, make.Value.MakeName);
                    UpdateTextBox(ModelTextBox, model.Value.ModelName);
                    UpdateTextBox(WidthTextBox, result.XRes.ToString());
                    UpdateTextBox(HeightTextBox, result.YRes.ToString());
                    if (result.bitmap != null)
                    {
                      pictureImage.Image = new Bitmap(result.bitmap);
                    }
                    else
                    {

                    }
                  }
                  else
                  {
                    // we prefer an url without an embedded password
                    if (result.XRes == _bestXRes)
                    {
                      if (_lastUrl.Contains("[PASSWORD]"))
                      {
                        if (!url.Contains("[PASSWORD]"))
                        {
                          _lastUrl = url; // the raw url
                          UpdateTextBox(MakeTextBox, make.Value.MakeName);
                          UpdateTextBox(ModelTextBox, model.Value.ModelName);
                        }
                      }
                    }
                  }
                }

                result.bitmap.Dispose();
              }
              else
              {
                Interlocked.Increment(ref _alreadyTried);
              }
            }
          }

        }
      }

      async Task<ImageResult> ShowImage(string urlString)
      {
        ImageResult result = new ();

        CameraContactData data = _camera.Contact;  // for clarity
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
          webRequest.Timeout = 2000;

          using WebResponse webResponse = await webRequest.GetResponseAsync().ConfigureAwait(true);
          using var stream = webResponse.GetResponseStream();
          using MemoryStream memStream = new ();
          await stream.CopyToAsync(memStream);

          Bitmap bitmap = new (memStream);
          {

            if (null == bitmap)
            {
              result.Result = false; // clarity
            }
            else
            {
              result.Result = true;
              result.XRes = bitmap.Width;
              result.YRes = bitmap.Height;
              result.bitmap = bitmap;
            }
          }
        }
        catch (Exception ex)
        {
          result.bitmap = null;
          result.Result = false;
        }

        return result;
      }
    }
    void StopButton_Click(object sender, EventArgs e)
    {
      _stop = true;
    }
  }

  public struct ImageResult
  {
    public bool Result { get; set; }
    public int XRes { get; set; }
    public int YRes { get; set; }
    public Bitmap bitmap { get; set; }
  }
}
