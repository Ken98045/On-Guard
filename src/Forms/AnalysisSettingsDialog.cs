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
  public partial class AnalysisSettingsDialog : Form
  {
    public AnalysisSettingsDialog()
    {
      InitializeComponent();
      ParkedCarsOverlapCheckbox.Checked = Storage.Instance.GetGlobalBool("ExcludeParkedUsingOverlap", true);
      ExcludeParkedCornersCheckbox.Checked = Storage.Instance.GetGlobalBool("ExcludeParkedUsingCorners", true);
      BumpVehicleConfidenceCheck.Checked = Storage.Instance.GetGlobalBool("BumpMultiVehicleConfidence", true);
    }

    private void OKButton_Click(object sender, EventArgs e)
    {
      Storage.Instance.SetGlobalBool("ExcludeParkedUsingOverlap", ParkedCarsOverlapCheckbox.Checked);
      Storage.Instance.SetGlobalBool("ExcludeParkedUsingCorners", ExcludeParkedCornersCheckbox.Checked);
      Storage.Instance.SetGlobalBool("BumpMultiVehicleConfidence", BumpVehicleConfidenceCheck.Checked);
      Storage.Instance.Update();
      DialogResult = DialogResult.OK;
    }

    private void CancelButton_Click(object sender, EventArgs e)
    {
      DialogResult = DialogResult.Cancel;
    }
  }
}
