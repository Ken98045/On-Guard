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
  public partial class ObjectDefinitionDialog : Form
  {
    public string ObjectType { get; set; }
    public int Confidence { get; set; }
    public int Overlap { get; set; }
    public int MinX { get; set; }
    public int MinY { get; set; }

    public ObjectDefinitionDialog()
    {
      InitializeComponent();
    }

    public ObjectDefinitionDialog(ObjectCharacteristics src)
    {
      InitializeComponent();

      if (null != src)
      {
        int index = ObjectCombo.FindString(src.ObjectType);
        ObjectCombo.SelectedIndex = index;
        ConfidenceNumeric.Value = src.Confidence;
        overlapNumeric.Value = src.MinPercentOverlap;
        minWidthNumeric.Value = src.MinimumXSize;
        minHeightNumeric.Value = src.MinimumYSize;
      }

    }

    private void OKButton_Click(object sender, EventArgs e)
    {
      if (ObjectCombo.SelectedIndex >= 0)
      {
        ObjectType = ObjectCombo.SelectedItem.ToString();
        Confidence = (int)ConfidenceNumeric.Value;
        Overlap = (int)overlapNumeric.Value;
        MinX = (int)minWidthNumeric.Value;
        MinY = (int)minHeightNumeric.Value;
        DialogResult = DialogResult.OK;
      }
      else
      {
        MessageBox.Show(this, "You must select an item from the Object Type list!", "Select an Object!");
        DialogResult = DialogResult.None;
      }  
    }

    private void CancelButton_Click(object sender, EventArgs e)
    {
      DialogResult = DialogResult.Cancel;
    }
  }
}
