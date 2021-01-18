using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SAAI;

namespace DeepStackDisplay
{

  public partial class NotificationOptionsDialog : Form
  {
    readonly AreaOfInterest _area;

    public NotificationOptionsDialog(AreaOfInterest area)

    {
      _area = area;
      InitializeComponent();

      int count = 0;
      foreach (var url in area.Notifications.Urls)
      {
        ListViewItem urlItem = new ListViewItem(new string[] { url.Url, url.CoolDown.CooldownTime.ToString() });
        urlsList.Items.Add(urlItem);
        urlItem.Checked = url.Active;
        urlItem.Tag = url;

        ++count;
      }

      count = 0;
      foreach (var option in area.Notifications.Email)
      {
        ListViewItem emailItem = new ListViewItem(new string[] { option.EmailAddress, option.CoolDown.CooldownTime.ToString() });
        emailsList.Items.Add(emailItem);
        emailItem.Tag = option;
        emailItem.Checked = option.Active;
        ++count;
      }

      if (emailsList.Items.Count > 0)
      {
        emailsList.Items[0].Selected = true;
        emailsList.Select();
      }

      if (urlsList.Items.Count > 0)
      {
        urlsList.Items[0].Selected = true;
        urlsList.Select();
      }
    }


    private void OkButton_Click(object sender, EventArgs e)
    {
      _area.Notifications.Email.Clear();
      _area.Notifications.Urls.Clear();

      foreach (ListViewItem url in urlsList.Items)
      {
        UrlOptions option = (UrlOptions)url.Tag;
        option.Active = url.Checked;
        option.Url = url.Text;
        _area.Notifications.Urls.Add(option);
      }


      foreach (ListViewItem email in emailsList.Items)
      {
        EmailOptions option = (EmailOptions)email.Tag;
        option.Active = email.Checked;
        option.EmailAddress = email.Text;
        _area.Notifications.Email.Add(option);
      }

      DialogResult = DialogResult.OK;
    }

    private void CancelButton_Click(object sender, EventArgs e)
    {
      DialogResult = DialogResult.Cancel;
    }

    private void AddUrlButton_Click(object sender, EventArgs e)
    {
      using (AddUrlDialog dlg = new AddUrlDialog())
      {
        if (dlg.ShowDialog() == DialogResult.OK)
        {
          UrlOptions opt = new UrlOptions(dlg.Url, dlg.CoolDown);
          opt.Active = true;

          ListViewItem item = new ListViewItem(new string [] { dlg.Url, dlg.CoolDown.ToString()})
          {
            Checked = true
          };

          item.Tag = opt;   // we don't really track changes here because there is nothing to track, but....
          urlsList.Items.Add(item);
          int index = item.Index;
          urlsList.Items[index].Tag = new UrlOptions(opt.Url,opt.CoolDown.CooldownTime);

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
        _area.Notifications.Urls.RemoveAt(urlsList.SelectedIndices[0]);
        urlsList.Items.RemoveAt(urlsList.SelectedIndices[0]);
      }
    }

    private void AddEmailButton_Click(object sender, EventArgs e)
    {
      using (AddEmailDialog dlg = new AddEmailDialog())
      {
        if (dlg.ShowDialog() == DialogResult.OK)
        {
          EmailOptions options = new EmailOptions(dlg.EmailAddress, dlg.CooldownTime) // We do need to track changes here because each email has numerous properties
          {
            EndTime = new DateTime(2020, 1, 1, 23, 59, 59),
            StartTime = new DateTime(2020, 1, 1, 0, 0, 0),
            Active = true,
            NumberOfImages = 1
          };

          _area.Notifications.Email.Add(options);

          ListViewItem item = new ListViewItem(new string[] { dlg.EmailAddress, dlg.CooldownTime.ToString() });
          emailsList.Items.Add(item);
          int index = item.Index;
          emailsList.Items[index].Tag = options;
          emailsList.Items[index].Focused = true;
          emailsList.Items[index].Selected = true;

          SetEmailControls(options);
          item.Checked = true;
          emailsList.Select();

        }
      }
    }

    void SetEmailControls(EmailOptions opt)
    {
      numberOfImages.Value = opt.NumberOfImages;
      check247.Checked = opt.AllTheTime;
      fromTime.Value = opt.StartTime; ;
      toTime.Value = opt.EndTime;
      for (int i = 0; i < 7; i++)
      {
        daysOfWeekList.SetItemChecked(i, opt.DaysOfWeek[i]);
      }

      sizeImageToNumeric.Value = opt.SizeDownToPercent;


    }

    private void RemoveEmailButton_Click(object sender, EventArgs e)
    {
      if (!(emailsList.SelectedIndices.Count > 0))
      {
        MessageBox.Show("You must select a row in order to delete it");
      }
      else
      {
        _area.Notifications.Email.RemoveAt(emailsList.SelectedIndices[0]);
        emailsList.Items.RemoveAt(emailsList.SelectedIndices[0]);
      }

    }

    private void Check247_Checked(object sender, EventArgs e)
    {
      if (emailsList.SelectedIndices.Count > 0)
      {
        if (check247.Checked)
        {
          for (int i = 0; i < 7; i++)
          {
            daysOfWeekList.SetItemChecked(i, true);
          }
        }
        _area.Notifications.Email[emailsList.SelectedIndices[0]].AllTheTime = check247.Checked;
      }
    }

    private void bs_CurrentChanged(object sender, EventArgs e)
    {

    }

    private void SelectionChanged(object sender, EventArgs e)
    {
      if (emailsList.SelectedItems.Count > 0)
      {
        EmailOptions opt = (EmailOptions)emailsList.SelectedItems[0].Tag;  // to avoid clutter
        SetEmailControls(opt);
      }
    }

    private void OnItemCheckChanged(object sender, ItemCheckEventArgs e)
    {
      if (emailsList.SelectedIndices.Count > 0)
      {
        if (emailsList.SelectedIndices.Count > 0)
        {
          EmailOptions opt = (EmailOptions)emailsList.Items[emailsList.SelectedIndices[0]].Tag;
          if (e.NewValue == CheckState.Checked)
          {
            opt.DaysOfWeek[e.Index] = true;
          }
          else
          {
            opt.DaysOfWeek[e.Index] = false;
            check247.Checked = false; // can't be 24/7 if we aren't 7
          }
        }
      }
    }

    private void FromTime_ValueChanged(object sender, EventArgs e)
    {
      if (emailsList.SelectedIndices.Count > 0)
      {
        EmailOptions opt = (EmailOptions)emailsList.Items[emailsList.SelectedIndices[0]].Tag;
        opt.StartTime = fromTime.Value;
        check247.Checked = false; // can't be 24/7 if we aren't 24
      }
    }

    private void ToTime_ValueChanged(object sender, EventArgs e)
    {
      if (emailsList.SelectedIndices.Count > 0)
      {
        EmailOptions opt = (EmailOptions)emailsList.Items[emailsList.SelectedIndices[0]].Tag;
        opt.EndTime = toTime.Value;
        check247.Checked = false; // can't be 24/7 if we aren't 24
      }
    }

    private void NumberOfImages_ValueChanged(object sender, EventArgs e)
    {
      if (emailsList.SelectedIndices.Count > 0)
      {
        EmailOptions opt = (EmailOptions)emailsList.Items[emailsList.SelectedIndices[0]].Tag;
        opt.NumberOfImages = (int)numberOfImages.Value;
      }

    }

    private void SizeImageToNumeric_ValueChanged(object sender, EventArgs e)
    {
      if (emailsList.SelectedIndices.Count > 0)
      {
        EmailOptions opt = (EmailOptions)emailsList.Items[emailsList.SelectedIndices[0]].Tag;
        opt.SizeDownToPercent = (int)sizeImageToNumeric.Value;
      }
    }

  }

}
