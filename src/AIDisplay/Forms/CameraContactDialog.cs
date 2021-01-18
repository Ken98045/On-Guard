using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SAAI;


namespace DeepStackDisplay
{
  public partial class CameraContactDialog : Form
  {
    public CameraContactData Data { get; set; }
    public CameraContactDialog(CameraContactData data)
    {
      Data = data;
      InitializeComponent();

      cameraIPAddressText.Text = data.CameraIPAddress;
      portNumeric.Value = data.Port;
      cameraNameText.Text = data.ShortCameraName;
      cameraUserText.Text = data.CameraUserName;
      cameraPasswordText.Text = data.CameraPassword;
      cameraXResolutionNumeric.Value = data.CameraXResolution;
      cameraYResolutionNumeric.Value = data.CameraYResolution;
    }

    private void OkButton_Click(object sender, EventArgs e)
    {
      Data.CameraIPAddress = cameraIPAddressText.Text;
      Data.Port = (int) portNumeric.Value;
      Data.ShortCameraName = cameraNameText.Text;
      Data.CameraUserName = cameraUserText.Text;
      Data.CameraPassword = cameraPasswordText.Text;
      Data.CameraXResolution = (int) cameraXResolutionNumeric.Value;
      Data.CameraYResolution = (int) cameraYResolutionNumeric.Value;
      DialogResult = DialogResult.OK;
    }

    private void CancelButton_Click(object sender, EventArgs e)
    {
      DialogResult = DialogResult.Cancel;
    }
  }
}
