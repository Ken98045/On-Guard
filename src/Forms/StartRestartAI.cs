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
  public partial class StartRestartAI : Form
  {
    public bool AIRunning { get; set; }
    public StartRestartAI()
    {
      InitializeComponent();

      if (!AI.IsAIRunning())
      {
        StatusLabel.Text = "NOT Running";
        StopButton.Enabled = false;
        StartButton.Text = "Start";
      }
      else
      {
        AIRunning = true;
        StartButton.Text = "Restart";
        StopButton.Enabled = true;
      }
    }

    private void DoneButton_Click(object sender, EventArgs e)
    {
      DialogResult = DialogResult.OK;
    }

    private void StartButton_Click(object sender, EventArgs e)
    {
      if (MessageBox.Show(this, "Starting/Restarting/Stopping the DeepStack AI may result in application instability.  Proceeed?", "Warning!", MessageBoxButtons.YesNo) == DialogResult.Yes)
      {
        AIRunning = AI.RestartAI(true, true);

        if (AIRunning)
        {
          StatusLabel.Text = "Running";
          StopButton.Enabled = true;
        }
        else
        {
          StatusLabel.Text = "NOT Running - Start/Restart Failed";
          StopButton.Enabled = false;
          StartButton.Text = "Start";
        }
      }
    }

    private void StopButton_Click(object sender, EventArgs e)
    {
      if (MessageBox.Show(this, "Starting/Restarting/Stopping the DeepStack AI may result in application instability.  Proceeed?", "Warning!", MessageBoxButtons.YesNo) == DialogResult.Yes)
      {
        AIRunning = false;
        AI.StopAI();
        StatusLabel.Text = "NOT Running";
        StopButton.Enabled = false;
        StartButton.Text = "Start";
      }
    }
  }
}
