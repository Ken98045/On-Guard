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
    public string Url { get; set; }
    public int CoolDown { get; set; }
    public AddUrlDialog()
    {
      InitializeComponent();
    }

    private void OkButton_Click(object sender, EventArgs e)
    {
      Url = urlText.Text;
      CoolDown = (int)urlCoolDownNumeric.Value;
      DialogResult = DialogResult.OK;

    }

    private void CancelButton_Click(object sender, EventArgs e)
    {
      DialogResult = DialogResult.Cancel;
    }

    private void AutoFillButton_Click(object sender, EventArgs e)
    {
      urlText.Text = "{Auto Fill}";
    }

  }
}
