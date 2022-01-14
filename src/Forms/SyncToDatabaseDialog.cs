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
  public partial class SyncToDatabaseDialog : Form
  {
    private double _interval;
    public double Interval { get => _interval; }

    public SyncToDatabaseDialog()
    {
      InitializeComponent();
    }

    private void OkButton_Click(object sender, EventArgs e)
    {
      _interval = (double)IntervalNumeric.Value;
      DialogResult = DialogResult.OK;
    }

    private void CancelButton_Click(object sender, EventArgs e)
    {
      DialogResult = DialogResult.Cancel;
    }
  }
}
