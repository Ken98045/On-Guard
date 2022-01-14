using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Http;
using System.Xml;

namespace OnGuardCore
{
  public partial class ISpySnapshot : Form
  {
    CameraData _camera;

    Dictionary<string, CameraMake> _makes = new ();

    string EditedUrl { get; set; }
    // public string SnapshotUri { get => _snapshotUri; set => _snapshotUri = value; }

    public ISpySnapshot(CameraData camera)
    {
      _camera = camera;

      InitializeComponent();

      string path = Storage.GetFilePath("Sources.xml");
      if (File.Exists(path))
      {
        ReadXml(path);
      }

      if (!string.IsNullOrEmpty(_camera.Contact.JpgCameraMake) && !string.IsNullOrEmpty(_camera.Contact.JpgCameraModel))
      {
        int makeIndex = MakeCombo.Items.IndexOf(_camera.Contact.JpgCameraMake);
        if (makeIndex >= 0)
        {
          MakeCombo.SelectedIndex = makeIndex;
        }

        int modelIndex = ModelCombo.Items.IndexOf(_camera.Contact.JpgCameraModel);
        ModelCombo.SelectedIndex = modelIndex;

      }

    }

    private void OkButton_Click(object sender, EventArgs e)
    {
      if (MakeCombo.SelectedIndex >= 0 && ModelCombo.SelectedIndex >= 0)
      {
        _camera.Contact.JpgCameraMake = (string)MakeCombo.Items[MakeCombo.SelectedIndex];
        _camera.Contact.JpgCameraModel = (string)ModelCombo.Items[ModelCombo.SelectedIndex];
        _camera.Contact.JpgContactMethod = PTZMethod.iSpy;

        if (!string.IsNullOrEmpty(uriTextBox.Text))
        {

          _camera.Contact.JPGSnapshotURL = uriTextBox.Text;
        }
        else
        {
          if (ListBoxURLs.Items.Count > 0)
          {
            _camera.Contact.JPGSnapshotURL = (string)ListBoxURLs.Items[0];
          }
        }

        DialogResult = DialogResult.OK;
      }
      else
      {
        MessageBox.Show(this, "Either Select a Make and Model or Press Cancel to Exit", "NO Selections Made!");
      }

    }

    private void CancelButton_Click(object sender, EventArgs e)
    {
      DialogResult = DialogResult.Cancel;
    }

    private void ReadXml(string path)
    {
      XmlDocument doc = new ();

      doc.Load(path);
      XmlNode root = doc.DocumentElement;
      XmlNodeList nodes = root.SelectNodes("Manufacturer");
      foreach (XmlNode node in nodes)
      {
        string makeName = node.Attributes["name"].Value;

        CameraMake make;
        if (!_makes.TryGetValue(makeName, out make))
        {
          make = new ();
          make.MakeName = makeName;
          _makes[makeName] = make;
        }

        XmlNodeList urls = node.SelectNodes("url");

        foreach (XmlNode url in urls)
        {
          var attributes = url.Attributes;
          if (null != attributes)
          {
            if (null != attributes)
            {
              if (null != attributes["Source"])
              {
                string src = attributes["Source"].Value;
                if (src == "JPEG")
                {
                  if (null != attributes["version"])
                  {
                    string model = attributes["version"].Value;
                    string prefix = attributes["prefix"].Value;
                    string uri = prefix + "[ADDRESS]/" + attributes["url"].Value;

                    CameraModel cameraModel;
                    if (!make.models.TryGetValue(model, out cameraModel))
                    {
                      cameraModel = new ();
                      cameraModel.ModelName = model;
                      make.models[model] = cameraModel;
                    }

                    cameraModel.urls[uri] = uri;

                  }
                }
              }
            }
          }
        }

        // If there are no urls for a model, remove the model
        List<string> removeModels = new ();

        foreach (var mod in make.models.Values)
        {
          if (mod.urls.Count == 0)
          {
            removeModels.Add(mod.ModelName);
            break;
          }
        }

        foreach (string modelToRemove in removeModels)
        {
          make.models.Remove(modelToRemove);
        }

        // If there are no (remaining models, remove the make

        if (make.models.Values.Count == 0)
        {
          _makes.Remove(make.MakeName);
        }
      } // end make

      MakeCombo.Items.Clear();

      foreach (CameraMake make in _makes.Values)
      {
        int item = MakeCombo.Items.Add(make.MakeName);
      }
    }

    private async void DownloadButton_Click(object sender, EventArgs e)
    {
      _makes.Clear();
      MakeCombo.Items.Clear();
      ModelCombo.Items.Clear();
      ListBoxURLs.Items.Clear();

      using HttpClient client = new ();
      string path = Storage.GetFilePath("Sources.xml");
      var response = await client.GetAsync("https://raw.githubusercontent.com/ispysoftware/iSpy/master/XML/Sources.xml");
      try
      {
        response.EnsureSuccessStatusCode();
        using (var ms = await response.Content.ReadAsStreamAsync())
        {
          using var fs = File.Create(path);
          ms.Seek(0, SeekOrigin.Begin);
          ms.CopyTo(fs);
        }

        ReadXml(path);
      }
      catch (Exception ex)
      {
        MessageBox.Show(this, "Unable to download the camera data source file", "Download Error!");
      }
    }


    private void MakeSelectionChanged(object sender, EventArgs e)
    {
      ListBoxURLs.Items.Clear();


      CameraMake make = _makes[(string)MakeCombo.SelectedItem];
      ModelCombo.Items.Clear();
      MakeCombo.Text = string.Empty;

      foreach (var model in make.models)
      {
        ModelCombo.Items.Add(model.Value.ModelName);
      }
    }

    private void ModelSelectionChanged(object sender, EventArgs e)
    {
      string modelName = (string)ModelCombo.SelectedItem;
      CameraMake make = _makes[(string)MakeCombo.SelectedItem];
      CameraModel model = make.models[(modelName)];

      ListBoxURLs.Items.Clear();

      foreach (var url in model.urls)
      {
        ListBoxURLs.Items.Add(url.Value);
      }
    }

    private async void OnDefinitionSelected(object sender, EventArgs e)
    {
      if (ListBoxURLs.SelectedIndex >= 0)
      {
        EditedUrl = (string)ListBoxURLs.Items[ListBoxURLs.SelectedIndex];
        uriTextBox.Text = EditedUrl;
        await ShowImageAsync(uriTextBox.Text);
      }
    }


    async Task ShowImageAsync(string urlString)
    {

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
        webRequest.Timeout = 3000;

        using WebResponse webResponse = await webRequest.GetResponseAsync().ConfigureAwait(true);
        using var stream = webResponse.GetResponseStream();
        using MemoryStream memStream = new();
        await stream.CopyToAsync(memStream);

        Bitmap bitmap = new (memStream);
        {

          if (null == bitmap)
          {
            MessageBox.Show(this, "There was an error obtaining the snapshot/video.  Please check your Live Camera settings", "Error Contacting the Camera");
            XResolutionLabel.Text = string.Empty;
            YResolutionLabel.Text = string.Empty;
          }
          else
          {
            XResolutionLabel.Text = bitmap.Width.ToString();
            YResolutionLabel.Text = bitmap.Height.ToString();
            PictureImageBox.Image = bitmap;
          }
        }
      }
      catch (Exception ex)
      {
        XResolutionLabel.Text = string.Empty;
        YResolutionLabel.Text = string.Empty;
        PictureImageBox.Image = null;
      }
    }


      private void ISpySnapshotHelp_Click(object sender, EventArgs e)
    {
      using HelpBox dlg = new("iSpy Snapshots", new Size(800, 600), "ISpySnapshotHelp.rtf");
      dlg.ShowDialog();
    }

    private void label7_Click(object sender, EventArgs e)
    {

    }

    private void AutoFindButton_Click(object sender, EventArgs e)
    {
      using AutoFindCamera dlg = new(_camera, _makes);
      DialogResult result = dlg.ShowDialog();

      if (result == DialogResult.OK)
      {
        int makeIndex = MakeCombo.Items.IndexOf(dlg.FoundMake);
        if (makeIndex >= 0)
        {
          MakeCombo.SelectedIndex = makeIndex;
        }

        int modelIndex = ModelCombo.Items.IndexOf(dlg.FoundModel);
        if (modelIndex >= 0)
        {
          ModelCombo.SelectedIndex = modelIndex;
        }
      }
    }

    private void ISpySnapshot_Load(object sender, EventArgs e)
    {

    }
  }

  public class CameraMake
  {
    public string MakeName;
    public Dictionary<string, CameraModel> models = new ();
  }

  public class CameraModel
  {
    public string ModelName;
    public Dictionary<string, string> urls = new ();
  }

}

