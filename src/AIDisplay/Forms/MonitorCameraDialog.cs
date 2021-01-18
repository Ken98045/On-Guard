using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeepStackDisplay
{
  public partial class MonitorCameraDialog : Form
  {
    public AllCameras Cameras { get; set; }
    public MonitorCameraDialog(AllCameras cameras)
    {
      Cameras = cameras;

      InitializeComponent();
      foreach (var camera in cameras.CameraDictionary.Values)
      {
        ListViewItem item = new ListViewItem(new string[] { camera.cameraPrefix, camera.path })
        {
          Checked = camera.Monitoring
        };
        camerasListView.Items.Add(item);
      }
    }

    private void OnItemCheck(object sender, ItemCheckEventArgs e)
    {
      if (e.NewValue == CheckState.Checked)
      {
        string key = string.Format("{0}\\{1}", camerasListView.Items[e.Index].SubItems[1].Text, camerasListView.Items[e.Index].Text).ToLower();
        Cameras.CameraDictionary[key].Monitoring = (e.NewValue == CheckState.Checked);
      }
    }

    private void OkButton_Click(object sender, EventArgs e)
    {
      DialogResult = DialogResult.OK;
    }

    private void CancelButton_Click(object sender, EventArgs e)
    {
      DialogResult = DialogResult.Cancel;
    }
  }
}
