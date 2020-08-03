using SAAI.Properties;
using System;
using System.Windows.Forms;

namespace SAAI
{

/// <summary>
/// SettingsDialog allows the user to enter/edit the application wide settings.
/// This includes the ip address/port of the AI.
/// </summary>
  public partial class SettingsDialog : Form
  {

    public SettingsDialog()
    {
      InitializeComponent();
      if (Settings.Default.AIIPAddress != null && Settings.Default.AIPort != 0)
      {
        ipAddresText.Text = Settings.Default.AIIPAddress;
        portNumeric.Value = Settings.Default.AIPort;
        snapshotNumeric.Value = (decimal)Settings.Default.TimePerFrame;
        maxEventNumeric.Value = Settings.Default.MaxEventTime;
        eventIntervalNumeric.Value = Settings.Default.EventInterval;
      }

    }

    private void OkButton_Click(object sender, EventArgs e)
    {
      if (!string.IsNullOrEmpty(ipAddresText.Text))
      {
        if (ipAddresText.Text.Contains("http") || ipAddresText.Text.Contains("//"))
        {
          MessageBox.Show("The IP Address or machine name must not include \"http\" or \"//\"");
        }
        else
        {
          Settings.Default.AIIPAddress = ipAddresText.Text;
          Settings.Default.AIPort = (int)portNumeric.Value;
          Settings.Default.TimePerFrame = (double)snapshotNumeric.Value;
          Settings.Default.MaxEventTime = (int)maxEventNumeric.Value;
          Settings.Default.EventInterval = (int)eventIntervalNumeric.Value;
          Settings.Default.AISetup = true;
          Settings.Default.Save();
          DialogResult = DialogResult.OK;
        }
      }
      else
      {
        MessageBox.Show("The IP Address or computer name must not be empty.");
      }

    }

    private void CancelButton_Click(object sender, EventArgs e)
    {
      DialogResult = DialogResult.Cancel;

    }
  }
}
