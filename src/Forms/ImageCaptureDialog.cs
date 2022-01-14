using OnGuardCore;
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
  public partial class ImageCaptureDialog : Form
  {
    CameraData _camera;
    public ImageCaptureDialog(CameraData camera)
    {
      _camera = camera;
      InitializeComponent();

      int maxEvent = Storage.Instance.GetGlobalInt("MaxEventTime");
      if (maxEvent != 0)
      {
        maxEventNumeric.Value = maxEvent;
      }

      int eventInterval = Storage.Instance.GetGlobalInt("EventInterval");
      if (eventInterval != 0)
      {
        eventIntervalNumeric.Value = eventInterval;
      }

      double snapshot = Storage.Instance.GetGlobalDouble("FrameInterval");
      if (snapshot != 0.0)
      {
        snapshotNumeric.Value = (decimal)snapshot;
      }

    }
    private void OKButton_Click(object sender, EventArgs e)
    {
      Storage.Instance.SetGlobalDouble("FrameInterval", (double)snapshotNumeric.Value);
      Storage.Instance.SetGlobalInt("MaxEventTime", (int)maxEventNumeric.Value);
      Storage.Instance.SetGlobalInt("EventInterval", (int)eventIntervalNumeric.Value);
      Storage.Instance.Update();
      DialogResult = DialogResult.OK;
    }

    private void CancelButton_Click(object sender, EventArgs e)
    {
      DialogResult = DialogResult.Cancel;
    }
  }
}
