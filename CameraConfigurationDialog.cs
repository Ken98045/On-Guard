using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace SAAI
{

/// <summary>
/// This Dialog contain tab pages that define the camera (and camera state)
/// It is a bit of a jumble because it
/// 1.  Allows you to create a camera (and delete one).  The camera contains a prefix (for the images) and a path to the images
/// 2.  Define the contact information for a camera "Live" (really on demand) view
/// 3.  Turn on and off monitoring of the camera.  When a camera is created monitoring is on
/// 
/// TODO: maybe use databinding
/// </summary>

  // Note: In this class/dialog the availableCamerasList each item has CameraData tags.
  // This acts as a local list of the cameras.
  // In this dialog we return a list of AllCameraData and the CurrentCam(era)
  public partial class CameraConfigurationDialog : Form
  {
    public CameraData CurrentCam { get; set; }
    public AllCameras AllCameraData { get; set; }

    public CameraConfigurationDialog(AllCameras allCameras)
    {
      InitializeComponent();
      AllCameraData = new AllCameras(allCameras); // we need a deep copy so we can avoid makinge changes to the current camera data in case the dialog is canceled


      foreach (var page in configurationTabControl.TabPages.Cast<TabPage>())
      {
        page.CausesValidation = true;
        page.Validating += new CancelEventHandler(OnTabPageValidating);
      }

      if (AllCameraData.CameraDictionary.Count > 0)
      {
        removeCameraButton.Enabled = true;
      }

      CurrentCam = AllCameraData.CurrentCamera;  // just a reference to the item in the new list.  May be null.  It is a  very convenient shortcut
      PopulateControls();
    }

    void OnTabPageValidating(object sender, CancelEventArgs e)
    {
      if (!(sender is TabPage page))
        return;

      if (page.Name == "imagesTab")
      {

        if (availableCamerasList.SelectedItems.Count == 0)
        {
          MessageBox.Show("You must select a camera/and or add a camera.");
          e.Cancel = true;
        }
        else
        {
          UpdateControlsFromCamera(); // may have added/removed cameras.  The current camera may have changed too
        }
      }
      else if (page.Name == "liveCameraTab")
      {
        // Any time we leave this tab we save the data to the current camera.
        // Unless I implement some separate confirmation button (nah) this is the only good way to do it.
        // This will be hit on the OK button as well.
        // ??????
        UpdateCurrentCameraFromLiveView();
      }
    }

    void UpdateCurrentCameraFromLiveView()
    {
      // Any time we leave this tab we save the data to the current camera.
      // Unless I implement some separate confirmation button (nah) this is the only good way to do it.
      // This will be hit on the OK button as well.
      CurrentCam.LiveContactData.CameraIPAddress = cameraIPAddressText.Text;
      CurrentCam.LiveContactData.Port = (int)portNumeric.Value;
      CurrentCam.LiveContactData.ShortCameraName = cameraNameText.Text;
      CurrentCam.LiveContactData.CameraUserName = cameraUserText.Text;
      CurrentCam.LiveContactData.CameraPassword = cameraPasswordText.Text;
      CurrentCam.LiveContactData.CameraXResolution = (int)cameraXResolutionNumeric.Value;
      CurrentCam.LiveContactData.CameraYResolution = (int)cameraYResolutionNumeric.Value;
    }

    void UpdateControlsFromCamera()
    {
      if (null != CurrentCam)
      { }
      cameraIPAddressText.Text = CurrentCam.LiveContactData.CameraIPAddress;
      portNumeric.Value = CurrentCam.LiveContactData.Port;
      cameraNameText.Text = CurrentCam.LiveContactData.ShortCameraName;
      cameraUserText.Text = CurrentCam.LiveContactData.CameraUserName;
      cameraPasswordText.Text = CurrentCam.LiveContactData.CameraPassword;
      cameraXResolutionNumeric.Value = CurrentCam.LiveContactData.CameraXResolution;
      cameraYResolutionNumeric.Value = CurrentCam.LiveContactData.CameraYResolution;
      currentCameraLabel.Text = "Current Camera: " + CurrentCam.CameraPrefix + " at: " + CurrentCam.Path;

      monitorListView.Items.Clear();
      foreach (ListViewItem camItem in availableCamerasList.Items)
      {
        CameraData data = (CameraData)camItem.Tag;
        ListViewItem monitorItem = new ListViewItem(new string[] { data.CameraPrefix, data.Path })
        {
          Tag = data
        };
        monitorListView.Items.Add(monitorItem);

        if (data.Monitoring)
        {
          monitorItem.Checked = true;
        }
      }
    }

    // Only called at startup to load the camera data into the listview
    void PopulateControls()
    {
      availableCamerasList.Items.Clear();
      foreach (var cam in AllCameraData.CameraDictionary.Values)
      {
        // Add the camera to the list currently available
        ListViewItem availableItem = new ListViewItem(new string[] { cam.CameraPrefix, cam.Path })
        {
          Tag = cam
        };

        availableCamerasList.Items.Add(availableItem);

        ListViewItem monitorItem = new ListViewItem(new string[] { cam.CameraPrefix, cam.Path })
        {
          Tag = cam
        };
        monitorListView.Items.Add(monitorItem);

        if (cam.Monitoring)
        {
          monitorItem.Checked = true;
        }

      }

      if (CurrentCam != null)
      {
        cameraIPAddressText.Text = CurrentCam.LiveContactData.CameraIPAddress;
        cameraPasswordText.Text = CurrentCam.LiveContactData.CameraPassword;
        cameraUserText.Text = CurrentCam.LiveContactData.CameraUserName;
        cameraXResolutionNumeric.Value = CurrentCam.LiveContactData.CameraXResolution;
        cameraYResolutionNumeric.Value = CurrentCam.LiveContactData.CameraYResolution;
        cameraNameText.Text = CurrentCam.LiveContactData.ShortCameraName;

      }

      if (null != CurrentCam)
      {
        int currentIndex = CameraFromList(CameraData.PathAndPrefix(CurrentCam));
        Debug.Assert(currentIndex >= 0);
        availableCamerasList.Items[currentIndex].Focused = true;
        availableCamerasList.Items[currentIndex].Selected = true;
        availableCamerasList.Select();
      }

    }

    private void OkButton_Click(object sender, EventArgs e)
    {
      if (null != CurrentCam)
      {
        AllCameraData.CameraDictionary.Clear();   // the data is no longer valid
        foreach (ListViewItem item in availableCamerasList.Items)
        {
          AllCameraData.AddCamera((CameraData)item.Tag);
        }

        AllCameraData.CurrentCameraPath = CameraData.PathAndPrefix(CurrentCam);


        // AllCameraData only tracks it by the path, but it is a valid reference to an item on the list
        UpdateCurrentCameraFromLiveView();
      }

      DialogResult = DialogResult.OK;
    }

    private void CancelButton_Click(object sender, EventArgs e)
    {
      DialogResult = DialogResult.Cancel;
    }

    private void LiveCameraTab_Click(object sender, EventArgs e)
    {

    }

    private int CameraFromList(string key)
    {
      int result = -1;
      key = key.ToLower();

      for (int i = 0; i < availableCamerasList.Items.Count; i++)
      {
        string target = string.Format("{0}\\{1}", availableCamerasList.Items[i].SubItems[1].Text, availableCamerasList.Items[i].SubItems[0].Text).ToLower();
        if (target == key)
        {
          result = i;
          break;
        }

      }

      return result;
    }


    private void AddCameraButton_Click(object sender, EventArgs e)
    {
      using (AddCameraDialog dlg = new AddCameraDialog())
      {
        if (dlg.ShowDialog() == DialogResult.OK)
        {
          string cameraID = string.Format("{0}\\{1}", dlg.CameraFilePath, dlg.CameraPrefix).ToLower();
          if (CameraFromList(cameraID) >= 0)
          {
            MessageBox.Show("This camera file path and camera prefix already exists. Please select it or add a different camera.");
          }
          else
          {
            CurrentCam = new CameraData(dlg.CameraPrefix, dlg.CameraFilePath);

            ListViewItem item = new ListViewItem(new string[] { CurrentCam.CameraPrefix, CurrentCam.Path })
            {
              Tag = CurrentCam
            };
            availableCamerasList.Items.Add(item);
            item.Selected = true;
            item.Focused = true;
            availableCamerasList.Select();
            removeCameraButton.Enabled = true;

            UpdateControlsFromCamera();
          }
        }
      }
    }

    private void OnCameraSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
    {
      if (e.IsSelected) // there can be only one
      {
        CurrentCam = (CameraData)e.Item.Tag;
        UpdateControlsFromCamera();
      }
    }

    private void RemoveCameraButton_Click(object sender, EventArgs e)
    {
      CurrentCam = null;  // The current camera is the one selected.  We need to select an item to delete it, so we always delete the "current" on

      var cam = (CameraData) availableCamerasList.SelectedItems[0].Tag;
      cam.Dispose();
      availableCamerasList.Items.RemoveAt(availableCamerasList.SelectedIndices[0]);

      if (availableCamerasList.Items.Count > 0)
      {
        // Well, we got rid of the current camera (and it wa, but we might as well use the first one left
        // Do that by selecting it.
        availableCamerasList.Items[0].Selected = true;
        availableCamerasList.Items[0].Focused = true;
        availableCamerasList.Select();
      }
      else
      {
        removeCameraButton.Enabled = false;
      }

      UpdateControlsFromCamera();

    }

    private void OnMonitorCheck(object sender, ItemCheckEventArgs e)
    {
      CameraData data = (CameraData)monitorListView.Items[e.Index].Tag;
      data.Monitoring = (e.NewValue == CheckState.Checked);
    }

    private void OnCameraDoubleClick(object sender, EventArgs e)
    {
      int index = availableCamerasList.SelectedIndices[0];
      if (index >= 0)
      {
        CurrentCam = (CameraData)availableCamerasList.Items[index].Tag;
        OkButton_Click(sender, e);
      }
    }

    private void OnTabPageSelected(object sender, TabControlEventArgs e)
    {
      if (e.TabPage.Name == "imagesTab")
      {
        availableCamerasList.Select();
      }
    }
  }
}

