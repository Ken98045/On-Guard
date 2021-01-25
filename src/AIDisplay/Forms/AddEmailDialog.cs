using System;
using System.Windows.Forms;

namespace SAAI
{

/// <summary>
/// A simple dialog to add email addresses to the AOI notifications dialog
/// </summary>
  public partial class AddEmailDialog : Form
  {
    public string EmailAddress { get; set; }
    public AddEmailDialog()
    {
      InitializeComponent();
      foreach (var options in EmailAddresses.EmailAddressList)
      {
        emailAddressList.Items.Add(options.EmailAddress);
      }
    }

    private void OkButton_Click(object sender, EventArgs e)
    {
      if (null != emailAddressList.SelectedItem)
      {
        EmailAddress = (string)emailAddressList.SelectedItem;
        DialogResult = DialogResult.OK;
      }
      else
      {
        MessageBox.Show("You must select an email address or press Cancel");
      }
    }

    private void CancelButton_Click(object sender, EventArgs e)
    {
      DialogResult = DialogResult.Cancel;
    }

    private void OnMouseDoubleClick(object sender, MouseEventArgs e)
    {
      if (null != emailAddressList.SelectedItem)
      {
        EmailAddress = (string)emailAddressList.SelectedItem;
      }
      DialogResult = DialogResult.OK;
    }
  }
}
