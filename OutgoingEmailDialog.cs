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

    private void testButton_Click(object sender, EventArgs e)
    {
      if (string.IsNullOrEmpty(serverText.Text))
      {
        MessageBox.Show("You must enter a a server address before testing!", "Server Empty!");
        return;
      }

      if (string.IsNullOrEmpty(userText.Text))
      {
        MessageBox.Show("The test email will be sent to the email user name.  This name is now empty.  Even if you do not use a user name for sending email, you must have one here.", "You must enter a user name!");
      }

      try
      {
        using (MailMessage mail = new MailMessage())
        {
          using (SmtpClient SmtpServer = new SmtpClient(Settings.Default.EmailServer))
          {
            mail.BodyEncoding = Encoding.UTF8;
            mail.IsBodyHtml = true;
            mail.From = new MailAddress(Settings.Default.EmailUser);
            string rec = userText.Text;
            mail.To.Add(rec);
            mail.Subject = "Security Camera Test";   // todo get via ui
            mail.Body = "This is a test of your email server settings<br />";

            SmtpServer.Port = (int) portNumeric.Value;
            SmtpServer.Credentials = new System.Net.NetworkCredential(Settings.Default.EmailUser, Settings.Default.EmailPassword);
            SmtpServer.EnableSsl = Settings.Default.EmailSSL;

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
  }
}
