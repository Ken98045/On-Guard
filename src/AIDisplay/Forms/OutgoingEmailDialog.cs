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
      serverText.Text = Storage.GetGlobalString("EmailServer");
      userText.Text = Storage.GetGlobalString("EmailUser");
      passwordText.Text = Storage.GetGlobalString("EmailPassword");
      sslCheck.Checked = Storage.GetGlobalBool("EmailSSL");
      int emailPort = Storage.GetGlobalInt("EmailPort");
      if (emailPort == 0)
      {
        emailPort = (int)Settings.Default.EmailPort;
      }
      portNumeric.Value = emailPort;
    }

    private void OkButton_Click(object sender, EventArgs e)
    {
      if (string.IsNullOrEmpty(serverText.Text))
      {
        if (!userText.Text.Contains("@"))
        {
          MessageBox.Show(this, "In almost all cases you should include '@' plus the domain in your email user name. For example: 'Jonn.Smith@foo.bar'", "Email Sender Format Error");
        }
      }

      Storage.SetGlobalString("EmailServer", serverText.Text);
      Storage.SetGlobalString("EmailUser", userText.Text);
      Storage.SetGlobalString("EmailPassword", passwordText.Text);
      Storage.SetGlobalBool("EmailSSL", sslCheck.Checked);
      Storage.SetGlobalInt("EmailPort", (int)portNumeric.Value);
      Storage.SetGlobalBool("EmailSetup", true);
      DialogResult = DialogResult.OK;
    }

    private void CancelButton_Click(object sender, EventArgs e)
    {
      DialogResult = DialogResult.Cancel;
    }

    private void TestButton_Click(object sender, EventArgs e)
    {
      if (string.IsNullOrEmpty(serverText.Text))
      {
        MessageBox.Show(this, "You must enter a a server address before testing!", "Server Empty!");
        return;
      }

      if (!userText.Text.Contains("@"))
      {
        MessageBox.Show(this, "You must include '@' plus the domain in your email user name. For example: 'Jonn.Smith@foo.bar'", "Email Sender Format Error");
        return;
      }

      DialogResult destinationResult;
      string destination = string.Empty;

      using (TestEmailAddress dlg = new TestEmailAddress())
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
              SmtpServer.Port = Storage.GetGlobalInt("EmailPort");

              string emailUserName = Storage.GetGlobalString("EmailUser");
              string emailPassword = Storage.GetGlobalString("EmailPassword");
              if (!string.IsNullOrEmpty(emailUserName))
              {
                SmtpServer.Credentials = new System.Net.NetworkCredential(emailUserName, emailPassword);
              }
              SmtpServer.EnableSsl = sslCheck.Checked;

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
