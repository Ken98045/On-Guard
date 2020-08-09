using SAAI.Properties;
using System;
using System.Windows.Forms;

namespace SAAI
{

  /// <summary>
  /// In order to send email we need the outgoing email server address.  
  /// This dialog gets that information.
  /// </summary>
  public partial class OutgoingEmailDialog : Form
  {
    public OutgoingEmailDialog()
    {
      InitializeComponent();
      serverText.Text = Settings.Default.EmailServer;
      userText.Text = Settings.Default.EmailUser;
      passwordText.Text = Settings.Default.EmailPassword;
      sslCheck.Checked = Settings.Default.EmailSSL;
      portNumeric.Value = Settings.Default.EmailPort;
    }

    private void OkButton_Click(object sender, EventArgs e)
    {
      if (string.IsNullOrEmpty(serverText.Text))
      {
        MessageBox.Show("You must fill out the email server, the user name, and the password.");
      }
      else
      {
        Settings.Default.EmailServer = serverText.Text;
        Settings.Default.EmailUser = userText.Text;
        Settings.Default.EmailPassword = passwordText.Text;
        Settings.Default.EmailSSL = sslCheck.Checked;
        Settings.Default.EmailPort = (uint)portNumeric.Value;
        Settings.Default.EmailSetup = true;
        Settings.Default.AISetup = true;
        Settings.Default.Save();
        DialogResult = DialogResult.OK;
      }

    }

    private void CancelButton_Click(object sender, EventArgs e)
    {
      DialogResult = DialogResult.Cancel;
    }
  }
}
