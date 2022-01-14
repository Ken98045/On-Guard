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
  public partial class HTTPptz : Form
  {
    CameraData _camera;
    public HTTPptz(CameraData camera)
    {
      _camera = camera;
      InitializeComponent();

      textBoxLeft.Text = _camera.Contact.HTTPPanLeft;
      textBoxRight.Text = _camera.Contact.HTTPPanRight;
      textBoxUp.Text = _camera.Contact.HTTPPanUp;
      textBoxDown.Text = _camera.Contact.HTTPPanDown;
      textBoxZoomIn.Text = _camera.Contact.HTTPZoomIn;
      textBoxZoomOut.Text = _camera.Contact.HTTPZoomOut;
      textBoxStop.Text = _camera.Contact.HTTPStop;
    }

    private void OKButton_Click(object sender, EventArgs e)
    {
      if (!string.IsNullOrEmpty(textBoxLeft.Text) && !string.IsNullOrEmpty(textBoxRight.Text))
      {
        _camera.Contact.HTTPPanLeft = textBoxLeft.Text;
        _camera.Contact.HTTPPanRight = textBoxRight.Text;
        _camera.Contact.HTTPPanUp = textBoxUp.Text;
        _camera.Contact.HTTPPanDown = textBoxDown.Text;
        _camera.Contact.HTTPZoomIn = textBoxZoomIn.Text;
        _camera.Contact.HTTPZoomOut = textBoxZoomOut.Text;
        _camera.Contact.HTTPStop = textBoxStop.Text;
        _camera.Contact.PTZContactMethod = PTZMethod.HTTP;
        DialogResult = DialogResult.OK;
      }
      else
      {
        MessageBox.Show(this, "At a minimum you must provide a definition for Left and Right", "Missing Values!");
      }
    }

    private void CancelButton_Click(object sender, EventArgs e)
    {

      if (!string.IsNullOrEmpty(textBoxLeft.Text) && !string.IsNullOrEmpty(textBoxRight.Text))
      {
        if (MessageBox.Show(this, "You have made entries.  Are you sure you wish to exit?", "Exit?", MessageBoxButtons.YesNo) == DialogResult.Yes)
        {
          DialogResult = DialogResult.Cancel;
        }
      }
    }
  }
}
