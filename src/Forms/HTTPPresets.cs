using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnGuardCore
{
  public partial class HTTPPresets : Form
  {
    CameraData _camera;
    public HTTPPresets(CameraData camera)
    {
      _camera = camera;
      InitializeComponent();

      labelCurrentCamera.Text = "Current Camera: " + _camera.CameraPrefix;
      if (camera.Contact.PresetSettings.PresetList.Count > 0)
      {
        string str = camera.Contact.PresetSettings.PresetList[0].Command;
        if (str.Contains("[ADDRESS]"))  // It should
        {
          int offset = str.IndexOf("[ADDRESS]");
          offset += "[ADDRESS]".Length;
          str = str.Remove(0, offset);
          textBoxUrl.Text = str;
        }
      }
    }


    private void OKButton_Click(object sender, EventArgs e)
    {

      if (textBoxUrl.Text.Contains("http") || textBoxUrl.Text.Contains("[ADDRESS]"))
      {
        MessageBox.Show("Your URL must NOT contain either http or [ADDRESS].  These values will be added automatically", "Invalid URL Format!");
      }
      else
      {

        if (textBoxUrl.Text.Contains("[PRESET]") || textBoxUrl.Text.Contains("[OFFSET="))
        {

          if (!(textBoxUrl.Text.Contains("[PRESET]") && textBoxUrl.Text.Contains("[OFFSET=")))
          {

            DialogResult = DialogResult.OK;
            _camera.Contact.PresetSettings.PresetMethod = PTZMethod.HTTP;
            _camera.Contact.PresetSettings.PresetList.Clear();
            _camera.Contact.PresetSettings.CameraMake = _camera.CameraPrefix.ToLower();

            string str = textBoxUrl.Text;
            if (!textBoxUrl.Text.Contains("[ADDRESS]"))
            {
              str = "http://[ADDRESS]" + textBoxUrl.Text;
            }

            // Yes, each preset has the same contents -- there can be only one!
            for (int i = 0; i < 256; i++)
            {
              Preset preset = new ();
              preset.Name = "Preset " + i.ToString();
              preset.Command = str;
              _camera.Contact.PresetSettings.PresetList.Add(preset);
            }
          }
          else
          {
            MessageBox.Show(this, "Your URL CANNOT contain BOTH [PRESET] OR [OFFSET=", "Invalid URL format");
          }
        }
        else
        {
          MessageBox.Show(this, "Your URL must contain either [PRESET] OR [OFFSET=", "Invalid URL format");
        }
      }

    }

    private void CancelButton_Click(object sender, EventArgs e)
    {
      DialogResult = DialogResult.Cancel;
    }
  }
}
