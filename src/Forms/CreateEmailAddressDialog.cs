using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace OnGuardCore
{

  /// <summary>
  /// A dialog for creating an email adddress for use through out the applicaton.
  /// We also associate start time, end time, and days of week for the email address.
  /// later we may associate that start/end time with an area rather than the email address.
  /// </summary>
  public partial class CreateEmailAddressDialog : Form
  {
    public EmailOptions Email { get; set; }

    public CreateEmailAddressDialog()
    {
      InitializeComponent();
    }

    public CreateEmailAddressDialog(EmailOptions options)
    {
      InitializeComponent();
      Debug.Assert(options != null);

      Email = options;
      if (options != null)
      {
        emailText.Text = Email.EmailAddress;
        numberOfImages.Value = Email.NumberOfImages;
        sizeImageToNumeric.Value = Email.SizeDownToPercent;
        htmlFormatCheckbox.Checked = Email.InlinePictures;
        coolDownNumeric.Value = Email.CoolDown.CooldownTime;
        check247.Checked = Email.AllTheTime;
        fromTime.Value = Email.StartTime;
        toTime.Value = Email.EndTime;
        MaximumAttachmentSizeNumeric.Value = Email.MaximumAttachmentSize;

        for (int i = 0; i < 7; i++)
        {
          daysOfWeekList.SetItemChecked(i, Email.DaysOfWeek[i]);
        }
      }
    }


    private void OkButton_Click(object sender, EventArgs e)
    {
      if (null == Email)
      {
        Email = new EmailOptions(emailText.Text, (int)coolDownNumeric.Value);
      }

      Email.EmailAddress = this.emailText.Text;
      Email.NumberOfImages = (int)this.numberOfImages.Value;
      Email.SizeDownToPercent = (int)this.sizeImageToNumeric.Value;
      Email.MaximumAttachmentSize = MaximumAttachmentSizeNumeric.Value;
      Email.InlinePictures = htmlFormatCheckbox.Checked;
      Email.CoolDown.CooldownTime = (int)this.coolDownNumeric.Value;
      Email.AllTheTime = check247.Checked;
      Email.StartTime = this.fromTime.Value;
      Email.EndTime = this.toTime.Value;

      for (int i = 0; i < 7; i++)
      {
        Email.DaysOfWeek[i] = this.daysOfWeekList.GetItemChecked(i);
      }

      DialogResult = DialogResult.OK;
      Close();
    }

    private void CancelButton_Click(object sender, EventArgs e)
    {
      DialogResult = DialogResult.Cancel;
      Close();
    }

    private void OnCheckChanged(object sender, EventArgs e)
    {
      if (check247.Checked)
      {
        for (int i = 0; i < 7; i++)
        {
          daysOfWeekList.SetItemChecked(i, true);
        }
      }
    }

    private void MMSHelperButton_Click(object sender, EventArgs e)
    {
      using (MMSHelper dlg = new MMSHelper())
      {
        DialogResult result = dlg.ShowDialog();
        if (DialogResult != DialogResult.Cancel)
        {
          emailText.Text = dlg.SelectedMMS;
        }
      }
    }

    private void NumberOfImages_ValueChanged(object sender, EventArgs e)
    {

    }

    private void HtmlFormatCheckbox_CheckedChanged(object sender, EventArgs e)
    {

    }

    private void CoolDownNumeric_ValueChanged(object sender, EventArgs e)
    {

    }

    private void EmailText_TextChanged(object sender, EventArgs e)
    {

    }

    private void Label13_Click(object sender, EventArgs e)
    {

    }
  }
}
