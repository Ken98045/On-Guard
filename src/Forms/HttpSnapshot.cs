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
  public partial class HttpSnapshot : Form
  {
    CameraData _camera;

    public HttpSnapshot(CameraData camera)
    {
      _camera = camera;
      InitializeComponent();
    }

    private void OKButton_Click(object sender, EventArgs e)
    {
      _camera.Contact.JPGSnapshotURL = textBoxURL.Text;
      _camera.Contact.JpgContactMethod = PTZMethod.HTTP;
      DialogResult = DialogResult.OK;
    }

    private void CancelButton_Click(object sender, EventArgs e)
    {
      DialogResult = DialogResult.Cancel;
    }
  }
}
