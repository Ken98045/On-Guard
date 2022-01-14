using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Xml;

using System.Windows.Forms;

namespace OnGuardCore
{
  public partial class ISpyPTZ : Form
  {
    int LastIndex { get; set; }
    public CameraData Camera { get => _camera; set => _camera = value; }

    CameraData _camera;


    SortedDictionary<string, CameraMakePTZ> _makes = new ();

    public ISpyPTZ(CameraData camera)
    {
      Camera = camera;
      InitializeComponent();


      string path = Storage.GetFilePath("PTZ2.xml");
      if (File.Exists(path))
      {
        ReadXml(path);
      }


      if (_makes.Count > 0)
      {
        if (!string.IsNullOrEmpty(Camera.Contact.PTZCameraMake))
        {
          MakeCombo.SelectedItem = Camera.Contact.PTZCameraMake;
        }

        if (!string.IsNullOrEmpty(Camera.Contact.PTZCameraModel))
        {
          ModelCombo.SelectedItem = Camera.Contact.PTZCameraModel;
        }

      }

      LastIndex = -1;
    }

    private void ReadXml(string path)
    {
      XmlDocument doc = new ();

      doc.Load(path);
      XmlNode root = doc.DocumentElement;
      XmlNodeList nodes = root.SelectNodes("Camera");

      foreach (XmlNode cameraNode in nodes) // Returns Camera (that can have many make/models)
      {
        string auth = string.Empty;
        if (cameraNode.Attributes["AppendAuth"] != null)
        {
          auth = "&" + cameraNode.Attributes["AppendAuth"].Value;
        }

        string id = cameraNode.Attributes["id"].Value;
        XmlNode ptzMakesNode = cameraNode.SelectSingleNode("Makes");  // to get the Makes parent

        XmlNodeList ptzMakes = ptzMakesNode.SelectNodes("*"); // to get the Makes children

        foreach (XmlNode makeNode in ptzMakes)
        {
          string makeName = makeNode.Attributes["Name"].Value;

          string modelName = "Default";
          if (null != makeNode.Attributes["Model"] && !string.IsNullOrEmpty(makeNode.Attributes["Model"].Value))
          {
            modelName = makeNode.Attributes["Model"].Value;
          }

          CameraMakePTZ make;
          if (!_makes.TryGetValue(makeName, out make))
          {
            make = new ();
            make.MakeName = makeName;
            _makes[makeName] = make;
          }

          CameraModelPTZ model;
          if (!make.models.TryGetValue(modelName, out model))
          {
            model = new ();
            model.ModelName = modelName;
          }

          XmlNode commandUrlNode = cameraNode.SelectSingleNode("CommandURL");
          string commandUrl = "http://[ADDRESS]" + commandUrlNode.InnerText;

          XmlNodeList commands = cameraNode.SelectNodes("Commands");

          foreach (XmlNode command in commands)
          {
            XmlNodeList allCommands = command.SelectNodes("*");

            foreach (XmlNode selectedNode in allCommands)
            {
              string commandName = selectedNode.Name;

              switch (commandName)
              {
                case "Left":
                  model.directions.Left = commandUrl + selectedNode.InnerText + auth;
                  break;

                case "Right":
                  model.directions.Right = commandUrl + selectedNode.InnerText + auth;
                  break;

                case "Up":
                  model.directions.Up = commandUrl + selectedNode.InnerText + auth;
                  break;

                case "Down":
                  model.directions.Down = commandUrl + selectedNode.InnerText + auth;
                  break;

                case "ZoomIn":
                  model.directions.ZoomIn = commandUrl + selectedNode.InnerText + auth;
                  break;

                case "ZoomOut":
                  model.directions.ZoomOut = commandUrl + selectedNode.InnerText + auth;
                  break;

                case "Stop":
                  model.directions.Stop = commandUrl + selectedNode.InnerText + auth;
                  break;
              }
            }

          }

          // Our minimum requirement is Left, Right
          // I suppose that it is remotely possible that a camera could pan but not tilt?
          if (!string.IsNullOrEmpty(model.directions.Left) &&
            !string.IsNullOrEmpty(model.directions.Right))
          {
            model.directions.Make = make.MakeName;
            model.directions.Model = model.ModelName;
            make.models[modelName] = model;
          }
        }
      }


      foreach (CameraMakePTZ make in _makes.Values)
      {
        int item = MakeCombo.Items.Add(make.MakeName);
      }

      if (MakeCombo.Items.Count > 0)
      {
        MakeCombo.SelectedIndex = 0;
      }
    }


    private async void DownloadButton_Click(object sender, EventArgs e)
    {
      _makes.Clear();
      MakeCombo.Items.Clear();
      ModelCombo.Items.Clear();
      DirectionsListView.Items.Clear();

      try
      {
        using HttpClient client = new ();
        string path = Storage.GetFilePath("PTZ2.xml");
        var response = await client.GetAsync("https://raw.githubusercontent.com/ispysoftware/iSpy/master/XML/PTZ2.xml");
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
          MessageBox.Show(this, "Unable to download the camera data source file", "Download Error! - " + ex.Message);
        }
      }
      catch (Exception ex)
      {
        MessageBox.Show(this, "Unable to download the camera data source file", "Download Error! - " + ex.Message);
      }
    }

    private void MakeSelectionChanged(object sender, EventArgs e)
    {
      DirectionsListView.Items.Clear();


      CameraMakePTZ make = _makes[(string)MakeCombo.SelectedItem];
      ModelCombo.Items.Clear();
      MakeCombo.Text = string.Empty;

      foreach (var model in make.models)
      {
        ModelCombo.Items.Add(model.Value.ModelName);
      }

      if (ModelCombo.Items.Count > 0)
      {
        ModelCombo.SelectedIndex = 0;
      }

      uriTextBox.Text = string.Empty;
    }

    private void ModelSelectionChanged(object sender, EventArgs e)
    {
      string modelName = (string)ModelCombo.SelectedItem;
      CameraMakePTZ make = _makes[(string)MakeCombo.SelectedItem];
      CameraModelPTZ model = make.models[(modelName)];
      uriTextBox.Text = string.Empty;

      DirectionsListView.Items.Clear();
      DirectionsListView.Items.Add(new ListViewItem(new string[] { "Left", model.directions.Left }));
      DirectionsListView.Items.Add(new ListViewItem(new string[] { "Right ", model.directions.Right }));
      DirectionsListView.Items.Add(new ListViewItem(new string[] { "Up", model.directions.Up }));
      DirectionsListView.Items.Add(new ListViewItem(new string[] { "Down", model.directions.Down }));
      DirectionsListView.Items.Add(new ListViewItem(new string[] { "Zoom In", model.directions.ZoomIn }));
      DirectionsListView.Items.Add(new ListViewItem(new string[] { "Zoom Out", model.directions.ZoomOut }));
      DirectionsListView.Items.Add(new ListViewItem(new string[] { "Stop", model.directions.Stop }));
    }

    private void DirectionSelectionChanged(object sender, EventArgs e)
    {
      if (DirectionsListView.SelectedIndices.Count > 0)
      {
        int index = DirectionsListView.SelectedIndices[0];
        if (LastIndex > 0)
        {
          DirectionsListView.Items[LastIndex].SubItems[1].Text = uriTextBox.Text;
        }

        LastIndex = index;
        uriTextBox.Text = DirectionsListView.Items[index].SubItems[1].Text;
      }

    }


    private void OkButton_Click(object sender, EventArgs e)
    {
      if (MakeCombo.SelectedIndex < 0)
      {
        MessageBox.Show(this, "You have not made any selection yet!", "No Selection Made!");
      }
      else
      {
        Camera.Contact.HTTPPanLeft = DirectionsListView.Items[(int)DirectionIndex.Left].SubItems[1].Text;
        Camera.Contact.HTTPPanRight = DirectionsListView.Items[(int)DirectionIndex.Right].SubItems[1].Text;
        Camera.Contact.HTTPPanUp = DirectionsListView.Items[(int)DirectionIndex.Up].SubItems[1].Text;
        Camera.Contact.HTTPPanDown = DirectionsListView.Items[(int)DirectionIndex.Down].SubItems[1].Text;
        Camera.Contact.HTTPZoomIn = DirectionsListView.Items[(int)DirectionIndex.ZoomIn].SubItems[1].Text;
        Camera.Contact.HTTPZoomOut = DirectionsListView.Items[(int)DirectionIndex.ZoomOut].SubItems[1].Text;
        Camera.Contact.HTTPStop = DirectionsListView.Items[(int)DirectionIndex.Stop].SubItems[1].Text;
        Camera.Contact.PTZCameraMake = (string)MakeCombo.Items[MakeCombo.SelectedIndex];
        Camera.Contact.PTZCameraModel = (string)ModelCombo.Items[ModelCombo.SelectedIndex];
        Camera.Contact.PTZContactMethod = PTZMethod.iSpy;


        DialogResult = DialogResult.OK;
      }
    }

    private void CancelButton_Click(object sender, EventArgs e)
    {
      DialogResult = DialogResult.Cancel;
    }

    private void HelpButton_Click(object sender, EventArgs e)
    {
      using HelpBox dlg = new("iSpy Pan/Tilt/Zoom", new Size(800, 600), "ISpySnapshotHelp.rtf");
      dlg.ShowDialog();
    }
  }

  class CameraMakePTZ
  {
    public string MakeName;
    public Dictionary<string, CameraModelPTZ> models = new ();
  }

  class CameraModelPTZ
  {
    public string ModelName;
    public DirectionUri directions = new ();

    public CameraModelPTZ()
    {
    }
  }

  public class DirectionUri
  {
    public string Left { get; set; }
    public string Right { get; set; }
    public string Up { get; set; }
    public string Down { get; set; }
    public string ZoomIn { get; set; }
    public string ZoomOut { get; set; }
    public string Stop { get; set; }
    public string Make { get; set; }
    public string Model { get; set; }
    public PTZMethod Method { get; set; }
    public PTZMethod PresetMethod { get; set; }

  }

  enum DirectionIndex
  {
    Left,
    Right,
    Up,
    Down,
    ZoomIn,
    ZoomOut,
    Stop

  }
}


