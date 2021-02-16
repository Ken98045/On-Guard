﻿using OnGuardCore.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;


namespace OnGuardCore
{

  /// <summary>
  /// SettingsDialog allows the user to enter/edit the application wide settings.
  /// This includes the ip address/port of the AI.
  /// </summary>
  public partial class SettingsDialog : Form
  {
    public SettingsDialog()
    {
      InitializeComponent();


      aiLocationListView.Sorting = SortOrder.Ascending;

      // The older (pre 1-6-1) version may have used the old registry format.
      // If so, get it, but delete it.
      string oldIPAddress = Storage.Instance.GetGlobalString("DeepStackIPAddress");
      if (!string.IsNullOrEmpty(oldIPAddress))
      {
        int aiPort = Storage.Instance.GetGlobalInt("DeepStackPort");
        AILocation location = new AILocation(Guid.NewGuid(), oldIPAddress, aiPort);
        Storage.Instance.RemoveGlobalValue("DeepStackIPAddress");  // get rid of the old format
        Storage.Instance.RemoveGlobalValue("DeepStackPort");

      }

      string logViewer = Storage.Instance.GetGlobalString("LogViewer");
      if (!string.IsNullOrEmpty(logViewer))
      {
        LogViewerText.Text = logViewer;
      }


      List<AILocation> locations = Storage.Instance.GetAILocations();
      foreach (var location in locations)
      {
        ListViewItem item = new ListViewItem(new string[] { location.IPAddress, location.Port.ToString() });
        aiLocationListView.Items.Add(item);
        item.Tag = location;
      }

      double snapshot = Storage.Instance.GetGlobalDouble("FrameInterval");
      if (snapshot != 0.0)
      {
        snapshotNumeric.Value = (decimal)snapshot;
      }
      

      int maxEvent = Storage.Instance.GetGlobalInt("MaxEventTime");
      if (maxEvent != 0)
      {
        maxEventNumeric.Value = maxEvent;
      }

      int eventInterval = Storage.Instance.GetGlobalInt("EventInterval");
      if (eventInterval != 0)
      {
        eventIntervalNumeric.Value = eventInterval;
      }
      

      // Database Stuff
      string customConnectionString = Storage.Instance.GetGlobalString("CustomDatabaseConnectionString");
      if (string.IsNullOrEmpty(customConnectionString))
      {
        ConnectionStringText.Text = Storage.Instance.GetGlobalString("DBConnectionString");  // the fully formatted one that is in use!
      }
    }

    private void OkButton_Click(object sender, EventArgs e)
    {
      Storage.Instance.SetGlobalDouble("FrameInterval", (double)snapshotNumeric.Value);
      Storage.Instance.SetGlobalInt("MaxEventTime", (int)maxEventNumeric.Value);
      Storage.Instance.SetGlobalInt("EventInterval", (int)eventIntervalNumeric.Value);
      Storage.Instance.SetGlobalString("LogViewer", LogViewerText.Text);
      DialogResult = DialogResult.OK;

    }

    private void CancelButton_Click(object sender, EventArgs e)
    {
      DialogResult = DialogResult.Cancel;
    }

    private void AddButton_Click(object sender, EventArgs e)
    {
      using (AILocationDialog dlg = new AILocationDialog())
      {
        DialogResult result = dlg.ShowDialog();
        if (result == DialogResult.OK)
        {
          ListViewItem item = new ListViewItem(new string[] { dlg.Location.IPAddress, dlg.Location.Port.ToString() });
          item.Tag = dlg.Location;
          aiLocationListView.Items.Add(item);
        }
      }

      DialogResult = DialogResult.None;
    }

    private void RemoveButton_Click(object sender, EventArgs e)
    {
      if (aiLocationListView.SelectedItems.Count > 0)
      {
        int index = aiLocationListView.SelectedIndices[0];
        AILocation location = (AILocation) aiLocationListView.Items[index].Tag;
        Storage.Instance.RemoveAILocation(location.ID.ToString());
        AILocation.Refresh();
        aiLocationListView.Items.RemoveAt(index);
      }
    }

    private void OnActivate(object sender, EventArgs e)
    {
      if (aiLocationListView.SelectedItems.Count > 0)
      {
        int index = aiLocationListView.SelectedIndices[0];
        ListViewItem item = aiLocationListView.Items[index];
        AILocation location = (AILocation)item.Tag;
        using (AILocationDialog dlg = new AILocationDialog(location))
        {
          DialogResult result = dlg.ShowDialog();
          if (result == DialogResult.OK)
          {
            aiLocationListView.Items[index].SubItems[0].Text = dlg.Location.IPAddress;
            aiLocationListView.Items[index].SubItems[1].Text = dlg.Location.Port.ToString();
          }
        }
      }

    }


    // This does not just get the exiting value, it reforms it from the base components!
    private void GetDefaultButton_Click(object sender, EventArgs e)
    {
      ConnectionStringText.Text = Storage.Instance.GetGlobalString("DBConnectionString");  // the one we use
      Storage.Instance.RemoveGlobalValue("CustomDatabaseConnectionString");  // nuke any custom stuff the user set.
    }

    private void UseCustomButton_Click(object sender, EventArgs e)
    {
      if (!string.IsNullOrEmpty(ConnectionStringText.Text))
      {
        Storage.Instance.SetGlobalString("CustomDatabaseConnectionString", ConnectionStringText.Text); // His custom string stored here so we can get it back (unless nuked)!
        Storage.Instance.SetGlobalString("DBConnectionString", ConnectionStringText.Text);   // This is the one actually used!
      }
    }

    private void RefreshButton_Click(object sender, EventArgs e)
    {
      DialogResult result = MessageBox.Show(this, "This button re-reads the AI information from Storage.Instance.  This can be useful if the status of your AI server(s) has changed", "Refresh AI Information", MessageBoxButtons.YesNo);
      if (result == DialogResult.Yes)
      {
        AILocation.Refresh();
      }
    }
  }
}