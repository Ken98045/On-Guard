using System;
using System.Windows.Forms;

namespace OnGuardCore
{

  public partial class NotificationOptionsDialog : Form
  {
    readonly AreaOfInterest _area;

    public NotificationOptionsDialog(AreaOfInterest area)

    {
      _area = area;
      InitializeComponent();

      int count = 0;

      if (area.Notifications != null && area.Notifications.Urls != null)
      {
        foreach (var urlOptions in area.Notifications.Urls)
        {
          ListViewItem urlItem = new ListViewItem(new string[] { urlOptions.Url, urlOptions.WaitTime.ToString(), urlOptions.CoolDown.CooldownTime.ToString() });
          urlsList.Items.Add(urlItem);
          urlItem.Tag = urlOptions;

          ++count;
        }

        if (urlsList.Items.Count > 0)
        {
          urlsList.Items[0].Selected = true;
          urlsList.Select();
        }

        NoMotionUrlNotify.Text = area.Notifications.NoMotionUrlNotify;
        NoMotionMQTTCheck.Checked = area.Notifications.NoMotionMQTTNotify;
        UseMQTTBox.Checked = area.Notifications.UseMQTT;

      }

      count = 0;
      if (area.Notifications.Email != null)
      {
        foreach (var address in area.Notifications.Email)
        {
          ListViewItem emailItem = new ListViewItem(address);
          emailsList.Items.Add(emailItem);
          ++count;
        }

        if (emailsList.Items.Count > 0)
        {
          emailsList.Items[0].Selected = true;
          emailsList.Select();
        }
      }

      UseMQTTBox.Checked = area.Notifications.UseMQTT;
    }


    private void OkButton_Click(object sender, EventArgs e)
    {
      _area.Notifications.Email.Clear();

      if (_area.Notifications.Urls != null)
      {
        _area.Notifications.Urls.Clear();

        _area.Notifications.Urls.Clear();

        foreach (ListViewItem url in urlsList.Items)
        {
          UrlOptions option = (UrlOptions)url.Tag;
          _area.Notifications.Urls.Add(option);
        }
      }

      if (emailsList.Items != null)
      {
        foreach (ListViewItem email in emailsList.Items)
        {
          _area.Notifications.Email.Add(email.Text);
        }
      }

      _area.Notifications.NoMotionMQTTNotify = NoMotionMQTTCheck.Checked;
      _area.Notifications.NoMotionUrlNotify = NoMotionUrlNotify.Text;

      _area.Notifications.UseMQTT = UseMQTTBox.Checked;

      DialogResult = DialogResult.OK;
    }

    private void CancelButton_Click(object sender, EventArgs e)
    {
      DialogResult = DialogResult.Cancel;
    }

    private void AddUrlButton_Click(object sender, EventArgs e)
    {
      AddEditURL(null);
    }

    private void OnActivateURL(object sender, EventArgs e)
    {
      ListViewItem item = urlsList.Items[urlsList.SelectedIndices[0]];
      UrlOptions options = (UrlOptions)item.Tag;
      AddEditURL(options);
    }

    private void AddEditURL(UrlOptions options)
    {
      bool added = false;
      if (null == options)
      {
        added = true;
      }

      using (AddUrlDialog dlg = new AddUrlDialog(options))
      {
        if (dlg.ShowDialog() == DialogResult.OK)
        {
          ListViewItem item;
          int index;

          if (added)  
          {
            item = new ListViewItem(new string[] { dlg.Options.Url, dlg.Options.WaitTime.ToString(), dlg.Options.CoolDown.CooldownTime.ToString() });

            urlsList.Items.Add(item);
            index = item.Index;
          }
          else
          {
            // editing
            item = urlsList.Items[urlsList.SelectedIndices[0]];
            index = item.Index;
            item.SubItems[0].Text = dlg.Options.Url;  // update the stuff
            item.SubItems[1].Text = dlg.Options.WaitTime.ToString();
            item.SubItems[2].Text = dlg.Options.CoolDown.CooldownTime.ToString();
          }

          urlsList.Items[index].Tag = dlg.Options;
          urlsList.Items[index].Focused = true;
          urlsList.Items[index].Selected = true;

        }
      }

    }


    private void RemoveUrlButton_Click(object sender, EventArgs e)
    {
      if (urlsList.SelectedIndices.Count == 0)
      {
        MessageBox.Show("You must select a row in order to delete it");
      }
      else
      {
        int index = urlsList.SelectedIndices[0];
        addUrlButton.Focus();
        urlsList.Items.RemoveAt(index);
      }
    }

    private void AddEmailButton_Click(object sender, EventArgs e)
    {
      using (AddEmailDialog dlg = new AddEmailDialog())
      {
        if (dlg.ShowDialog() == DialogResult.OK)
        {
          bool duplicate = false;

          foreach (ListViewItem anItem in emailsList.Items)
          {
            if (anItem.SubItems[0].Text == dlg.EmailAddress)
            {
              duplicate = true;
              break;
            }
          }

          if (duplicate)
          {
            MessageBox.Show(this, "Every email address must be unique", "Duplicate Found!");
          }
          else
          {

            ListViewItem item;
            ListViewItem[] items = emailsList.Items.Find(dlg.EmailAddress, false);
            if (items.Length == 0)
            {
              item = emailsList.Items.Add(dlg.EmailAddress);
            }
            else
            {
              item = items[0];
            }

            item.Checked = true;
            item.Selected = true;
            emailsList.Select();
          }
        }
      }
    }

    private void RemoveEmailButton_Click(object sender, EventArgs e)
    {
      if (emailsList.SelectedIndices.Count == 0)
      {
        MessageBox.Show("You must select a row in order to delete it");
      }
      else
      {
        int index = emailsList.SelectedIndices[0];
        addEmailButton.Focus();
        emailsList.Items.RemoveAt(index);
      }

    }

    private void Check247_Checked(object sender, EventArgs e)
    {
    }


    private void SelectionChanged(object sender, EventArgs e)
    {
    }

    private void OnItemCheckChanged(object sender, ItemCheckEventArgs e)
    {
    }

    private void NumberOfImages_ValueChanged(object sender, EventArgs e)
    {
    }

    private void SizeImageToNumeric_ValueChanged(object sender, EventArgs e)
    {
    }

  }

}
