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
  public partial class DisplayMode : Form
  {
    public DisplayOption DisplayType { get; set; }
    public DisplayMode(DisplayOption display)
    {
      InitializeComponent();

      if (display == DisplayOption.FilledHorizontally)
      {
        HorizontalFillRadio.Checked = true;
      }
      else if (display == DisplayOption.FilledVertically)
      {
        VerticalFillRadio.Checked = true;
      }
      else if (display == DisplayOption.FilledBoth)
      {
        FilledRadio.Checked = true;
      }
      else if (display == DisplayOption.Fixed)
      {
        FixedRadio.Checked = true;
      }

    }

    private void OKButton_Click(object sender, EventArgs e)
    {
      if (HorizontalFillRadio.Checked)
      {
        DisplayType = DisplayOption.FilledHorizontally;
      }
      else if (VerticalFillRadio.Checked)
      {
        DisplayType = DisplayOption.FilledVertically;
      }
      else if (FilledRadio.Checked)
      {
        DisplayType = DisplayOption.FilledBoth;
      }
      else if (FixedRadio.Checked)
      {
        DisplayType |= DisplayOption.Fixed;
      }

      DialogResult = DialogResult.OK;
    }

    private void CancelButton_Click(object sender, EventArgs e)
    {
      DialogResult = DialogResult.Cancel;
    }
  }

  public enum DisplayOption
  {
    FilledHorizontally,
    FilledBoth,
    Fixed,
    FilledVertically
  }
}
