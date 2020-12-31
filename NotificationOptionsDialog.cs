using System;
using System.Windows.Forms;

namespace SAAI
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
        foreach (var url in area.Notifications.Urls)
        {
          ListViewItem urlItem = new ListViewItem(new string[] { url.Url, url.CoolDown.CooldownTime.ToString() });
          urlsList.Items.Add(urlItem);
          urlItem.Checked = url.Active;
          urlItem.Tag = url;

          ++count;
        }

        if (urlsList.Items.Count > 0)
        {
          urlsList.Items[0].Selected = true;
          urlsList.Select();
        }

        NoMotionUrlNotify.Text = area.Notifications.NoMotionUrlNotify;
        NoMotionMQTTCheck.Checked = area.Notifications.NoMotionMQTTNotify;

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

        foreach (ListViewItem url in urlsList.Items)
        {
          UrlOptions option = (UrlOptions)url.Tag;
          option.Active = url.Checked;
          option.Url = url.Text;
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
      AddEditURL(string.Empty, 0);
    }

    private void OnActivateURL(object sender, EventArgs e)
    {
      ListViewItem item = urlsList.Items[urlsList.SelectedIndices[0]];
      AddEditURL(item.SubItems[0].Text, int.Parse(item.SubItems[1].Text));
    }

    private void AddEditURL(string url, int cooldown)
    {
      using (AddUrlDialog dlg = new AddUrlDialog(url, cooldown))
      {
        if (dlg.ShowDialog() == DialogResult.OK)
        {
          ListViewItem item;
          int index = 0;
          if (string.IsNullOrEmpty(url))
          {
            item = new ListViewItem(new string[] { dlg.Url, dlg.CoolDown.ToString() })
            {
              Checked = true
            };

            urlsList.Items.Add(item);
            index = item.Index;
          }
          else
          {
            item = urlsList.Items[urlsList.SelectedIndices[0]];
            index = item.Index;
            item.SubItems[0].Text = dlg.Url;  // update the stuff
            item.SubItems[1].Text = dlg.CoolDown.ToString();
          }

          // item.Tag = opt;

          if (string.IsNullOrEmpty(url))
          {
          }

          urlsList.Items[index].Tag = new UrlOptions(item.SubItems[0].Text, int.Parse(item.SubItems[1].Text));

          urlsList.Items[index].Focused = true;
          urlsList.Items[index].Selected = true;

        }
      }

    }


    private void RemoveUrlButton_Click(object sender, EventArgs e)
    {
      if (!(urlsList.SelectedIndices.Count > 0))
      {
        MessageBox.Show("You must select a row in order to delete it");
      }
      else
      {
        urlsList.Items.RemoveAt(urlsList.SelectedIndices[0]);
      }
    }

    private void AddEmailButton_Click(object sender, EventArgs e)
    {
      using (AddEmailDlg dlg = new AddEmailDlg())
      {
        if (dlg.ShowDialog() == DialogResult.OK)
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

    private void RemoveEmailButton_Click(object sender, EventArgs e)
    {
      if (!(emailsList.SelectedIndices.Count > 0))
      {
        MessageBox.Show("You must select a row in order to delete it");
      }
      else
      {
        emailsList.Items.RemoveAt(emailsList.SelectedIndices[0]);
      }

    }

    private void Check247_Checked(object sender, EventArgs e)
    {
    }

    private void bs_CurrentChanged(object sender, EventArgs e)
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
