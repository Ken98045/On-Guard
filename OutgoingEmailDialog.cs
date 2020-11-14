using SAAI.Properties;
using System;
using System.Net.Mail;
using System.Text;
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

    private void TestButton_Click(object sender, EventArgs e)
    {
      if (string.IsNullOrEmpty(serverText.Text))
      {
        MessageBox.Show("You must enter a a server address before testing!", "Server Empty!");
        return;
      }

      DialogResult destinationResult;
      string destination = string.Empty;

      using (Test_Email_Address dlg = new Test_Email_Address())
      {
        destinationResult = dlg.ShowDialog();
        if (destinationResult == DialogResult.OK)
        {
          destination = dlg.emailAddressText.Text;
        }
      }

      if (!string.IsNullOrEmpty(destination))
      {

        try
        {
          using (MailMessage mail = new MailMessage())
          {
            using (SmtpClient SmtpServer = new SmtpClient(serverText.Text))
            {
              mail.BodyEncoding = Encoding.UTF8;
              mail.IsBodyHtml = true;
              mail.From = new MailAddress(userText.Text);
              mail.To.Add(destination);
              mail.Subject = "Security Camera Test";   // todo get via ui
              mail.Body = "This is a test of your email server settings<br />";

              SmtpServer.Port = (int)portNumeric.Value;
              SmtpServer.Credentials = new System.Net.NetworkCredential(userText.Text, passwordText.Text);
              SmtpServer.EnableSsl = sslCheck.Checked ;

              SmtpServer.Send(mail);
            }
          }
        }
        catch (SmtpException ex)
        {
          MessageBox.Show("There was an error sending a test email to your email address", "Email Error!");
          Dbg.Write("Email exception: " + ex.ToString());
          return;
        }


        MessageBox.Show("Your test email was sent successfully!");
      }
      else
      {
        MessageBox.Show("You must enter a destination email address in order to run this test", "Error!");
      }


    }
  }
}
