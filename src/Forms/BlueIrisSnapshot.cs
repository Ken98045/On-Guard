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
  public partial class BlueIrisSnapshot : Form
  {
    string _shortCameraName;
    CameraData _camera;
    public string ShortCameraName { get => _shortCameraName; set => _shortCameraName = value; }

    public BlueIrisSnapshot(CameraData camera)
    {
      _camera = camera;
      InitializeComponent();
      textBoxCameraName.Text = camera.Contact.CameraShortName;
    }

    private void OkButton_Click(object sender, EventArgs e)
    {
      ShortCameraName = textBoxCameraName.Text;
      DialogResult = DialogResult.OK;
    }

    private void CancelButton_Click(object sender, EventArgs e)
    {
      DialogResult = DialogResult.Cancel;
    }
  }
}
