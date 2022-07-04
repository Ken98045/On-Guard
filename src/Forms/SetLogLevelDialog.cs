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
  public partial class SetLogLevelDialog : Form
  {
    public SetLogLevelDialog()
    {
      InitializeComponent();

      switch (Dbg.Level)
      {
        case (int)LogLevel.Verbose:
          radioVerbose.Checked = true;
          break;

        case (int)LogLevel.DetailedInfo:
          radioDetailedInfo.Checked = true;
          break;

        case (int)LogLevel.Info:
          radioInfo.Checked = true;
          break;

        case (int)LogLevel.Warning:
          radioWarning.Checked = true;
          break;

        case (int)(LogLevel.Error):
          radioError.Checked = true;
          break;

      }
    }

    private void OK_Click(object sender, EventArgs e)
    {
      if (radioVerbose.Checked)
      {
        Dbg.SetLogLevel(LogLevel.Verbose);
      }
      else if (radioDetailedInfo.Checked)
      {
        Dbg.SetLogLevel(LogLevel.DetailedInfo);
      }
      else if (radioInfo.Checked)
      {
        Dbg.SetLogLevel(LogLevel.Info);
      }
      else if (radioWarning.Checked)
      {
        Dbg.SetLogLevel(LogLevel.Warning);
      }
      else if (radioError.Checked)
      {
        Dbg.SetLogLevel(LogLevel.Error);
      }

      Storage.Instance.SetGlobalInt("LogLevel", (int)Dbg.Level);  // yes, we just set it
      Storage.Instance.Update();
      this.Close();
    }

    private void CancelButton_Click(object sender, EventArgs e)
    {
      this.Close();
    }
  }
}
