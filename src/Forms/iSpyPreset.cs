using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;

namespace OnGuardCore
{
  public partial class iSpyPreset : Form
  {

    SortedDictionary<string, CameraPresetMake> _makes = new ();
    CameraData _camera;

    public iSpyPreset(CameraData camera)
    {
      _camera = camera;
      InitializeComponent();

      string path = Storage.GetFilePath("PTZ2.xml");

      if (File.Exists(path))
      {
        ReadXml(path);
      }
      else
      {
        MessageBox.Show(this, "The first time you use this function you must download the iSpy presets definition file.", "Download Required");
      }


      if (_camera.Contact.PresetSettings.PresetMethod == PTZMethod.iSpy && !string.IsNullOrEmpty(_camera.Contact.PresetSettings.CameraMake))
      {
        int makeIndex = MakeCombo.Items.IndexOf(_camera.Contact.PresetSettings.CameraMake);
        if (makeIndex >= 0)
        {
          MakeCombo.SelectedIndex = makeIndex;
        }

        if (!string.IsNullOrEmpty(_camera.Contact.PresetSettings.CameraModel))
        {
          int modelIndex = ModelCombo.Items.IndexOf(_camera.Contact.PresetSettings.CameraModel);
          ModelCombo.SelectedIndex = modelIndex;
        }
      }
    }


    private void ReadXml(string path)
    {

      XmlDocument doc = new();

      if (File.Exists(path))
      {
        doc.Load(path);
      }
      else
      {

      }

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

          CameraPresetMake make;
          if (!_makes.TryGetValue(makeName, out make))
          {
            make = new CameraPresetMake(makeName);
            _makes[makeName] = make;
          }

          CameraPresetModel model;
          if (!make.Models.TryGetValue(modelName, out model))
          {
            model = new CameraPresetModel(modelName);
          }

          XmlNode commandUrlNode = cameraNode.SelectSingleNode("CommandURL");
          string commandUrl = "http://[ADDRESS]" + commandUrlNode.InnerText;

          XmlNodeList commands = cameraNode.SelectNodes("ExtendedCommands");

          foreach (XmlNode command in commands)
          {
            XmlNodeList allCommands = command.SelectNodes("*");

            foreach (XmlNode selectedNode in allCommands)
            {
              string commandName;
              if (selectedNode.Attributes["Name"] != null)
              {
                commandName = selectedNode.Attributes["Name"].Value;
              }
              else
              {
                commandName = "None";
              }


              if (commandName.StartsWith("Go Preset"))
              {
                if (!make.Models.ContainsKey(modelName))
                {
                  model.ModelName = modelName;
                  make.Models[modelName] = model;
                }

                string preset = selectedNode.InnerText;
                Preset p = new ();
                p.Name = commandName[3..];
                p.Command = commandUrl + preset;
                model.Presets.Add(p);

              }
            }
          }
        }

      }


      // Now, go through the models and eliminate any models without presets
      // (and yes there are more elegant ways to do this
      List<string> toDelete = new ();

      foreach (CameraPresetMake make in _makes.Values)
      {
        foreach (CameraPresetModel m in make.Models.Values)
        {
          if (m.Presets.Count == 0)
          {
            toDelete.Add(m.ModelName);
          }
        }

        foreach (string modName in toDelete)
        {
          make.Models.Remove(modName);
        }
      }

      // Now, go through the makes and delete those with no models
      toDelete.Clear();
      foreach (CameraPresetMake make in _makes.Values)
      {
        if (make.Models.Count == 0)
        {
          toDelete.Add(make.MakeName);
        }
      }

      foreach (string makeName in toDelete)
      {
        _makes.Remove(makeName);
      }

      // Now, add the makes remaining to the makes combo
      foreach (var m in _makes.Values)
      {
        MakeCombo.Items.Add(m.MakeName);
      }

      if (MakeCombo.Items.Count > 0)
      {
        MakeCombo.SelectedIndex = 0;
      }

    }

    private async void DownloadPresetsButton_Click(object sender, EventArgs e)
    {
      string path = Storage.GetFilePath("PTZ2.xml");
      try
      {
        using HttpClient client = new();
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


      ReadXml(path);
    }

    private void OnMakeChanged(object sender, EventArgs e)
    {
      CameraPresetMake make = _makes[(string)MakeCombo.SelectedItem];
      ModelCombo.Items.Clear();

      foreach (var model in make.Models)
      {
        ModelCombo.Items.Add(model.Value.ModelName);
      }

      if (ModelCombo.Items.Count > 0)
      {
        ModelCombo.SelectedIndex = 0;
      }

    }

    private void OnModelChanged(object sender, EventArgs e)
    {
      CameraPresetMake make = _makes[(string)MakeCombo.SelectedItem];
      CameraPresetModel model = make.Models[(string)ModelCombo.SelectedItem];
      PresetsListView.Items.Clear();

      foreach (var preset in model.Presets)
      {
        ListViewItem item = new (new string[] { preset.Name, preset.Command });
        PresetsListView.Items.Add(item);

      }

      if (PresetsListView.Items.Count > 0)
      {
        PresetsListView.Items[0].Selected = true;
        PresetsListView.Items[0].Focused = true;
      }
    }

    private void OkButton_Click(object sender, EventArgs e)
    {

      _camera.Contact.PresetSettings.PresetMethod = PTZMethod.iSpy;
      if (MakeCombo.SelectedIndex >= 0)
      {
        _camera.Contact.PresetSettings.CameraMake = (string)MakeCombo.SelectedItem;
        _camera.Contact.PresetSettings.CameraModel = (string)ModelCombo.SelectedItem;
        CameraPresetMake make = _makes[(string)MakeCombo.SelectedItem];
        CameraPresetModel model = make.Models[(string)ModelCombo.SelectedItem];
        _camera.Contact.PresetSettings.PresetList = new List<Preset>(model.Presets);
        DialogResult = DialogResult.OK;
      }
    }

    private void CancelButton_Click(object sender, EventArgs e)
    {
      DialogResult = DialogResult.Cancel;
    }

    private void HelpButton_Click(object sender, EventArgs e)
    {
      using HelpBox dlg = new("iSpy Presets", new Size(800, 600), "ISpySnapshotHelp.rtf");
      dlg.ShowDialog();
    }
  }



  class CameraPresetModel
  {
    public string ModelName { get; set; }
    public List<Preset> Presets { get; set; }

    public CameraPresetModel(string modelName)
    {
      ModelName = modelName;
      Presets = new List<Preset>();
    }

  }

  class CameraPresetMake
  {
    public string MakeName { get; set; }
    public Dictionary<string, CameraPresetModel> Models { get; set; }

    public CameraPresetMake(string make)
    {
      MakeName = make;
      Models = new Dictionary<string, CameraPresetModel>();
    }
  }

  public class Preset
  {
    public string Name { get; set; }
    public string Command { get; set; } // For OnVIF the token name, http the URL
  }

  public class PresetInfo
  {
    public string CameraMake { get; set; }
    public string CameraModel { get; set; }
    public PTZMethod PresetMethod { get; set; }
    public List<Preset> PresetList { get; set; }

    public PresetInfo(PTZMethod method)
    {
      PresetMethod = method;
      PresetList = new List<Preset>();
    }

    PresetInfo(PresetInfo src)
    {
      PresetMethod = src.PresetMethod;
      CameraMake = src.CameraMake;
      CameraModel = src.CameraModel;
      PresetList = new List<Preset>(src.PresetList);
    }

  }
}
