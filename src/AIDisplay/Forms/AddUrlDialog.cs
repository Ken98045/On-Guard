using System;
using System.Windows.Forms;

namespace SAAI
{

  /// <summary>
  /// A simple dialog to an an URL with a Cooldown.
  /// We could make the URLs global like the email addresses, but not for now
  /// </summary>
  public partial class AddUrlDialog : Form
  {

    public UrlOptions Options { get; }

    public AddUrlDialog(UrlOptions options)
    {
      InitializeComponent();
      Options = options;
      if (null == options)
      {
        Options = new UrlOptions(string.Empty, 0, 300, 0);
      }
      else
      {
        urlText.Text = Options.Url;
        urlCoolDownNumeric.Value = Options.CoolDown.CooldownTime;
        WaitTimeNumeric.Value = Options.WaitTime;

        if ((Options.BIFlags & (int) BIFLAGS.Flagged) > 0)
        {
          FlagCheckBox.Checked = true;
        }

        if ((Options.BIFlags & (int) BIFLAGS.Confirmed) > 0)
        {
          ConfirmCheckBox.Checked = true;
        }

        if ((Options.BIFlags & (int) BIFLAGS.Reset) > 0)
        {
          ResetCheckBox.Checked = true;
        }
      }

    }

    private void OkButton_Click(object sender, EventArgs e)
    {
      if (string.IsNullOrEmpty(urlText.Text))
      {
        MessageBox.Show(this, "You must enter an URL to notify (or we can't get there from here)!", "The URL Cannot be Empty!");
        DialogResult = DialogResult.None;
      }
      else
      {
        Options.BIFlags = 0;
        Options.Url = urlText.Text;
        if (FlagCheckBox.Checked) Options.BIFlags |= (int) BIFLAGS.Flagged;
        if (ConfirmCheckBox.Checked) Options.BIFlags |= (int) BIFLAGS.Confirmed;
        if (ResetCheckBox.Checked) Options.BIFlags |= (int) BIFLAGS.Reset;
        Options.CoolDown.CooldownTime = (int) urlCoolDownNumeric.Value;
        Options.WaitTime = (int)WaitTimeNumeric.Value;
        DialogResult = DialogResult.OK;
      }
    }

    private void CancelButton_Click(object sender, EventArgs e)
    {
      DialogResult = DialogResult.Cancel;
    }

    private void AutoFillButton_Click(object sender, EventArgs e)
    {
      urlText.Text = "{Auto Fill}";
    }

    private void ConfirmOnCheckChanged(object sender, EventArgs e)
    {
    }


    private void FlagCheckChanged(object sender, EventArgs e)
    {
    }


    private void ResetCheckBox_CheckedChanged(object sender, EventArgs e)
    {
      if (ResetCheckBox.Checked)
      {
        FlagCheckBox.Checked = false;
        ConfirmCheckBox.Checked = false;
      }
    }
  }

  [Flags]
  public enum BIFLAGS
  {
    Uncomfirmed = 0,
    Flagged = 1,
    Confirmed = 2,
    Reset = 4
  }

}
