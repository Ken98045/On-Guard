using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SAAI
{
  public partial class EmailAddressesDialog : Form
  {
    List<EmailOptions> Options { get; }
    public EmailAddressesDialog(List<EmailOptions> options)
    {
      InitializeComponent();
      Options = options;

      if (options != null)
      {
        foreach (EmailOptions option in Options)
        {
          ListViewItem item = emailAddressList.Items.Add(option.EmailAddress);
          item.Tag = option;
        }
      }
    }

    private void OKButton_Click(object sender, EventArgs e)
    {
      Options.Clear();
      foreach (ListViewItem item in emailAddressList.Items)
      {
        Options.Add((EmailOptions)item.Tag);
      }

      DialogResult = DialogResult.OK;
    }

    private void CancelButton_Click(object sender, EventArgs e)
    {
      DialogResult = DialogResult.Cancel;
    }

    private void AddButton_Click(object sender, EventArgs e)
    {
      using (CreateEmailAddressDialog dlg = new CreateEmailAddressDialog())
      {
        DialogResult result = dlg.ShowDialog();
        if (result == DialogResult.OK)
        {
          ListViewItem item = new ListViewItem(dlg.Email.EmailAddress)
          {
            Tag = dlg.Email
          };
          emailAddressList.Items.Add(item);
        }
      }
    }

    private void EditButton_Click(object sender, EventArgs e)
    {
      using (CreateEmailAddressDialog dlg = new CreateEmailAddressDialog((EmailOptions)emailAddressList.Items[emailAddressList.SelectedIndices[0]].Tag))
      {
        DialogResult result = dlg.ShowDialog();
        if (result == DialogResult.OK)
        {
          emailAddressList.Items[emailAddressList.SelectedIndices[0]].Tag = dlg.Email;
        }
      }
    }

    private void DeleteButton_Click(object sender, EventArgs e)
    {
      emailAddressList.Items.RemoveAt(emailAddressList.SelectedIndices[0]);
    }

    private void OnSelectedIndexChanged(object sender, EventArgs e)
    {
      if (emailAddressList.SelectedIndices.Count > 0)
      {
        EditButton.Enabled = true;
        DeleteButton.Enabled = true;
      }
      else
      {
        EditButton.Enabled = false;
        DeleteButton.Enabled = false;
      }
    }
  }
}
