using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SAAI
{
  public partial class AnalysisSettingsDialog : Form
  {
    public AnalysisSettingsDialog()
    {
      InitializeComponent();
      ParkedCarsOverlapCheckbox.Checked = Storage.GetGlobalBool("ExcludeParkedUsingOverlap", true);
      ExcludeParkedCornersCheckbox.Checked = Storage.GetGlobalBool("ExcludeParkedUsingCorners", true);
      BumpVehicleConfidenceCheck.Checked = Storage.GetGlobalBool("BumpMultiVehicleConfidence", true);
    }

    private void OKButton_Click(object sender, EventArgs e)
    {
      Storage.SetGlobalBool("ExcludeParkedUsingOverlap", ParkedCarsOverlapCheckbox.Checked);
      Storage.SetGlobalBool("ExcludeParkedUsingCorners", ExcludeParkedCornersCheckbox.Checked);
      Storage.SetGlobalBool("BumpMultiVehicleConfidence", BumpVehicleConfidenceCheck.Checked);
      DialogResult = DialogResult.OK;
    }

    private void CancelButton_Click(object sender, EventArgs e)
    {
      DialogResult = DialogResult.Cancel;
    }
  }
}
