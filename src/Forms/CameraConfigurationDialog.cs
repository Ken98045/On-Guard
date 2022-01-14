using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnGuardCore
{

  /// <summary>
  /// This Dialog contain tab pages that define the camera (and camera state)
  /// It is a bit of a jumble because it
  /// 1.  Allows you to create a camera (and delete one).  The camera contains a prefix (for the images) and a path to the images
  /// 2.  Define the contact information for a camera "Live" (really on demand) view
  /// 3.  Turn on and off monitoring of the camera.  When a camera is created monitoring is on
  /// 4.  Determine the time period before a motion timeout event
  /// 
  /// TODO: maybe use databinding
  /// </summary>

  // Note: In this class/dialog the availableCamerasList each item has CameraData tags.
  // This acts as a local list of the cameras.
  // In this dialog we return a list of AllCameraData and the CurrentCam(era)
  public partial class CameraConfigurationDialog : Form
  {
    public CameraData SelectedCamera { get; set; }
    public CameraCollection AllCameraData { get; set; }

    public CameraConfigurationDialog(CameraCollection allCameras)
    {
      InitializeComponent();

      // we need a deep copy so we can avoid makinge changes to the current camera data in case the dialog is canceled
      // Also, we do not want the collection inited
      AllCameraData = CameraCollection.CopyFactory(allCameras);
      foreach (var page in configurationTabControl.TabPages.Cast<TabPage>())
      {
        page.CausesValidation = true;
        page.Validating += new CancelEventHandler(OnTabPageValidating);
      }

      SelectedCamera = AllCameraData.CurrentCamera;  // just a reference to the item in the new list.  May be null.  It is a  very convenient shortcut
      PopulateControls();
      if (allCameras.CameraDictionary.Count > 0)
      {
        availableCamerasList.Items[0].Selected = true;
      }
    }


    void OnTabPageValidating(object sender, CancelEventArgs e)
    {
      if (sender is not TabPage page)
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
          UpdateUIFromCamera(); // may have added/removed cameras.  The current camera may have changed too
        }
      }
      else if (page.Name == "liveCameraTab")
      {
        // Any time we leave this tab we save the data to the current camera.
        // Unless I implement some separate confirmation button (nah) this is the only good way to do it.
        // This will be hit on the OK button as well.
        // ??????
        UpdateCameraFromUI();
      }
      else if (page.Name == "PTZTab")
      {

      }
    }

    void UpdateCameraFromUI()
    {
      // Any time we leave this tab we save the data to the current camera.
      // This will also be hit on the OK button.
      if (null != SelectedCamera)
      {
        SelectedCamera.Contact.CameraIPAddress = cameraIPAddressText.Text;
        SelectedCamera.Contact.Port = (int)portNumeric.Value;
        SelectedCamera.Contact.OnVIFPort = (int)OnVIFPortNumeric.Value;
        SelectedCamera.Contact.CameraShortName = textBoxShortCameraName.Text;
        SelectedCamera.Contact.CameraUserName = cameraUserText.Text;
        SelectedCamera.Contact.CameraPassword = cameraPasswordText.Text;
        SelectedCamera.Contact.CameraXResolution = (int)cameraXResolutionNumeric.Value;
        SelectedCamera.Contact.CameraYResolution = (int)cameraYResolutionNumeric.Value;
        SelectedCamera.Contact.CameraChannel = (int)ChannelNumeric.Value;
        SelectedCamera.Contact.CameraShortName = textBoxShortCameraName.Text;
        SelectedCamera.Contact.JPGSnapshotURL = uriTextBox.Text;
        SelectedCamera.NoMotionTimeout = (int)MotionTimeoutNumeric.Value;
        SelectedCamera.NoMotionTimeout = (int)MotionTimeoutNumeric.Value;
        SelectedCamera.MonitorSubdirectories = MonitorSubFoldersCheckbox.Checked;

        foreach (ListViewItem item in availableCamerasList.Items)
        {
          CameraData data = (CameraData)item.Tag;
          data.Monitoring = item.Checked;
        }

        SelectedCamera.Longitude = (double) Longitude.Value;
        SelectedCamera.Latitude = (double)Latitude.Value;
        SelectedCamera.ScheduledPresets.Clear();
        foreach (ListViewItem item in PresetsListView.Items)
        {
          PresetTrigger trigger = (PresetTrigger)item.Tag;
          SelectedCamera.ScheduledPresets.Add(trigger);
        }
      }
    }

    void UpdateUIFromCamera()
    {
      if (null != SelectedCamera)
      {
        cameraIPAddressText.Text = SelectedCamera.Contact.CameraIPAddress;
        portNumeric.Value = SelectedCamera.Contact.Port;
        OnVIFPortNumeric.Value = SelectedCamera.Contact.OnVIFPort;
        textBoxShortCameraName.Text = SelectedCamera.Contact.CameraShortName;
        uriTextBox.Text = SelectedCamera.Contact.JPGSnapshotURL;
        cameraUserText.Text = SelectedCamera.Contact.CameraUserName;
        cameraPasswordText.Text = SelectedCamera.Contact.CameraPassword;
        cameraXResolutionNumeric.Value = SelectedCamera.Contact.CameraXResolution;
        cameraYResolutionNumeric.Value = SelectedCamera.Contact.CameraYResolution;
        ChannelNumeric.Value = SelectedCamera.Contact.CameraChannel;
        MotionTimeoutNumeric.Value = SelectedCamera.NoMotionTimeout;
        MonitorSubFoldersCheckbox.Checked = SelectedCamera.MonitorSubdirectories;
        PopulateScheduledPresets(SelectedCamera);

        AddressCameraLabel.Text = "Current Camera: " + SelectedCamera.CameraPrefix;
        LiveCameraLabel.Text = "Current Camera: " + SelectedCamera.CameraPrefix;
        PTZCameraLabel.Text = "Current Camera: " + SelectedCamera.CameraPrefix;
        PresetsCameraLabel.Text = "Current Camera: " + SelectedCamera.CameraPrefix;
        MotionTimeoutCameraLabel.Text = "Current Camera: " + SelectedCamera.CameraPrefix;

        if (SelectedCamera.NoMotionTimeout > 0)
        {
          MotionTimeoutNumeric.Value = SelectedCamera.NoMotionTimeout;
        }

        switch (SelectedCamera.Contact.JpgContactMethod)
        {
          case PTZMethod.BlueIris:
            radioBlueIris.Checked = true;
            break;
          case PTZMethod.OnVIF:
            radioOnVIF.Checked = true;
            break;
          case PTZMethod.iSpy:
            radioiSpy.Checked = true;
            break;
          case PTZMethod.HTTP:
            radioHTTP.Checked = true;
            break;
          default:
            break;
        }

        switch (SelectedCamera.Contact.PTZContactMethod)
        {
          case PTZMethod.BlueIris:
            radioButtonPTZBlueIris.Checked = true;
            break;

          case PTZMethod.OnVIF:
            radioButtonPTZOnVIF.Checked = true;
            break;

          case PTZMethod.iSpy:
            radioButtonPTZiSpy.Checked = true;
            break;

          case PTZMethod.HTTP:
            radioButtonPTZHTTP.Checked = true;
            break;

          case PTZMethod.None:
            radioButtonPTZNone.Checked = true;
            break;

        }

        switch (SelectedCamera.Contact.PresetSettings.PresetMethod)
        {
          case PTZMethod.BlueIris:
            radioPresetBlueIris.Checked = true;
            break;
          case PTZMethod.OnVIF:
            radioPresetOnvif.Checked = true;
            break;
          case PTZMethod.iSpy:
            radioPresetiSpy.Checked = true;
            break;
          case PTZMethod.HTTP:
            radioPresetHttp.Checked = true;
            break;
          default:
            radioPresetNone.Checked = true;
            break;
        }
      }

    }

    void PopulateScheduledPresets(CameraData camera)
    {
      PresetsListView.Items.Clear();

      foreach (PresetTrigger trigger in camera.ScheduledPresets)
      {
        ListViewItem item = new (trigger.Name);
        item.SubItems.Add(trigger.PresetNumber.ToString());
        string str = string.Empty;

        switch (trigger.TriggerType)
        {
          case PresetTriggerType.Sunrise:
            str = "Sunrise";
            break;

          case PresetTriggerType.Sunset:
            str = "Sunset";
            break;

          case PresetTriggerType.AtTime:
            str = trigger.TriggerTime.ToShortTimeString();
            break;

        }

        item.SubItems.Add(str);
        item.Tag = new PresetTrigger(trigger);
        PresetsListView.Items.Add(item);
      }

      Longitude.Value = (decimal) camera.Longitude;
      Latitude.Value = (decimal) camera.Latitude;

    }


    // Only called at startup to load the camera data into the listview
    void PopulateControls()
    {
      availableCamerasList.Items.Clear();
      foreach (var cam in AllCameraData.CameraDictionary.Values)
      {
        // Add the camera to the list currently available
        ListViewItem availableItem = new (new string[] { cam.CameraPrefix, cam.CameraPath })
        {
          Tag = cam
        };

        if (cam.Monitoring)
        {
          availableItem.Checked = true;
        }

        availableCamerasList.Items.Add(availableItem);
      }

      if (SelectedCamera != null)
      {
        cameraIPAddressText.Text = SelectedCamera.Contact.CameraIPAddress;
        cameraPasswordText.Text = SelectedCamera.Contact.CameraPassword;
        cameraUserText.Text = SelectedCamera.Contact.CameraUserName;
        cameraXResolutionNumeric.Value = SelectedCamera.Contact.CameraXResolution;
        cameraYResolutionNumeric.Value = SelectedCamera.Contact.CameraYResolution;
        textBoxShortCameraName.Text = SelectedCamera.Contact.CameraShortName;
        uriTextBox.Text = SelectedCamera.Contact.JPGSnapshotURL;
        if (SelectedCamera.NoMotionTimeout > 0)
        {
          MotionTimeoutNumeric.Value = SelectedCamera.NoMotionTimeout;
        }

      }

      if (null != SelectedCamera)
      {
        int currentIndex = CameraFromList(CameraData.PathAndPrefix(SelectedCamera));
        Debug.Assert(currentIndex >= 0);
        availableCamerasList.Items[currentIndex].Focused = true;
        availableCamerasList.Items[currentIndex].Selected = true;
        availableCamerasList.Select();
      }

    }

    private void OkButton_Click(object sender, EventArgs e)
    {
      if (null != SelectedCamera)
      {
        AllCameraData.CameraDictionary.Clear();   // the data is no longer valid
        foreach (ListViewItem item in availableCamerasList.Items)
        {
          AllCameraData.AddCamera((CameraData)item.Tag);
        }

        AllCameraData.CurrentCameraPath = CameraData.PathAndPrefix(SelectedCamera);
        UpdateCameraFromUI();
      }
      else
      {
        if (AllCameraData.CameraDictionary.Count > 0)
        {
          AllCameraData.CurrentCameraPath = Path.Combine(AllCameraData.CameraDictionary.Values.First().CameraPath, AllCameraData.CameraDictionary.Values.First().CameraPrefix);
        }
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
        string target = string.Format("{0}\\{1}", availableCamerasList.Items[i].SubItems[1].Text, availableCamerasList.Items[i].SubItems[0].Text);
        if (target.ToLower() == key)
        {
          result = i;
          break;
        }

      }

      return result;
    }


    private void AddCameraButton_Click(object sender, EventArgs e)
    {
      using AddCameraDialog dlg = new(null);
      if (dlg.ShowDialog() == DialogResult.OK)
      {
        string cameraID = string.Format("{0}\\{1}", dlg.CameraFilePath, dlg.CameraPrefix);
        if (CameraFromList(cameraID) >= 0)
        {
          MessageBox.Show("This camera file path and camera prefix already exists. Please select it or add a different camera.");
        }
        else
        {
          SelectedCamera = dlg.Camera;  // new or old camera definition

          ListViewItem item = new (new string[] { SelectedCamera.CameraPrefix, SelectedCamera.CameraPath })
          {
            Tag = SelectedCamera
          };
          availableCamerasList.Items.Add(item);
          item.Selected = true;
          item.Focused = true;
          item.Checked = true;
          availableCamerasList.Select();
          removeCameraButton.Enabled = true;

          UpdateUIFromCamera();
        }
      }
    }

    private void OnCameraSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
    {
      if (e.IsSelected) // there can be only one
      {
        SelectedCamera = (CameraData)e.Item.Tag;
        UpdateUIFromCamera();
      }
    }

    private void RemoveCameraButton_Click(object sender, EventArgs e)
    {
      SelectedCamera = null;  // The current camera is the one selected.  We need to select an item to delete it, so we always delete the "current" on
      int index = availableCamerasList.SelectedIndices[0];
      var cam = (CameraData)availableCamerasList.Items[index].Tag;
      cam.Dispose();

      addCameraButton.Focus();
      availableCamerasList.Items.RemoveAt(index);

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
        EnableDiableTabs(false);
      }

      UpdateUIFromCamera();

    }


    private void OnCameraDoubleClick(object sender, EventArgs e)
    {
      int index = availableCamerasList.SelectedIndices[0];
      if (index >= 0)
      {
        SelectedCamera = (CameraData)availableCamerasList.Items[index].Tag;
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

    private void OnMotionTimeoutChanged(object sender, EventArgs e)
    {
      if (null != SelectedCamera) SelectedCamera.NoMotionTimeout = (int)MotionTimeoutNumeric.Value;
    }

    private void Label13_Click(object sender, EventArgs e)
    {

    }

    private async void SelectButton_Click(object sender, EventArgs e)
    {
      bool keepGoing = false;
      string urlString = string.Empty;

      if (string.IsNullOrEmpty(cameraIPAddressText.Text))
      {
        MessageBox.Show(this, "IP Address Missing!", "You must enter an IP Address!", MessageBoxButtons.OK);
      }
      else
      {

        if (string.IsNullOrEmpty(cameraUserText.Text) || string.IsNullOrEmpty(cameraPasswordText.Text))
        {
          if (MessageBox.Show(this, "In most cases you should enter a user name and password for the camera.  Continue?", "Warning!", MessageBoxButtons.YesNo) == DialogResult.Yes)
          {
            keepGoing = true;
          }
        }
        else
        {
          keepGoing = true;
        }

        if (keepGoing)
        {
          // We need to copy stuff to the camera because we pass the camera to various methods 
          // The contents of the camera may be changed by those methods
          UpdateCameraFromUI();

          DialogResult dlgResult = DialogResult.Cancel;

          if (radioBlueIris.Checked)
          {
            using BlueIrisSnapshot dlg = new (SelectedCamera);
            dlgResult = dlg.ShowDialog();
            if (dlgResult == DialogResult.OK)
            {
              textBoxShortCameraName.Text = dlg.ShortCameraName;
              SelectedCamera.Contact.CameraShortName = dlg.ShortCameraName;
              if (cameraXResolutionNumeric.Value > 0 && cameraYResolutionNumeric.Value > 0)
              {
                urlString = "http://[ADDRESS]/image/[SHORTNAME]?q=100&w=[WIDTH]&h=[HEIGHT]&user=[USERNAME]&pw=[PASSWORD]";
              }
              else
              {
                urlString = "http://[ADDRESS]/image/[SHORTNAME]?q=100&user=[USERNAME]&pw=[PASSWORD]";
              }

              SelectedCamera.Contact.JpgContactMethod = PTZMethod.BlueIris;
            }
          }

          else if (radioOnVIF.Checked)
          {
            using OnVIFSnapshot dlg = new (SelectedCamera);
            await dlg.InitAsync();

            dlgResult = dlg.ShowDialog();
            if (dlgResult == DialogResult.OK)
            {
              urlString = SelectedCamera.Contact.JPGSnapshotURL;   // no user & password cause the http request will do that
              SelectedCamera.Contact.JpgContactMethod = PTZMethod.OnVIF;
            }
          }
          else if (radioiSpy.Checked)
          {
            using ISpySnapshot dlg = new (SelectedCamera);
            dlgResult = dlg.ShowDialog();
            if (dlgResult == DialogResult.OK)
            {
              urlString = SelectedCamera.Contact.JPGSnapshotURL;
              SelectedCamera.Contact.JpgContactMethod = PTZMethod.iSpy;
            }
          }
          else if (radioHTTP.Checked)
          {
            using HttpSnapshot dlg = new (SelectedCamera);
            dlgResult = dlg.ShowDialog();
            if (dlgResult == DialogResult.OK)
            {
              urlString = SelectedCamera.Contact.JPGSnapshotURL;
              SelectedCamera.Contact.JpgContactMethod = PTZMethod.HTTP;
            }
          }

          // and format the string with the ip address and port if not OnVIF
          if (dlgResult == DialogResult.OK)
          {
            if (!radioOnVIF.Checked)
            {
            }

            uriTextBox.Text = urlString;
            SelectedCamera.Contact.JPGSnapshotURL = urlString;
          }
        }

      }
    }

    private void SelectPTZMethod(object sender, EventArgs e)
    {

      bool keepGoing = true;

      if (string.IsNullOrEmpty(SelectedCamera.Contact.CameraUserName) || string.IsNullOrEmpty(SelectedCamera.Contact.CameraPassword) || SelectedCamera.Contact.JpgContactMethod == PTZMethod.None)
      {
        DialogResult okResult = MessageBox.Show(this, "In most cases you will want/need to select a camera contact method and enter a camera user name and password.  Do you want to keep going?", "Proceed?", MessageBoxButtons.YesNo);
        if (okResult == DialogResult.No)
        {
          keepGoing = false;
        }
      }

      if (keepGoing)
      {
        if (radioButtonPTZNone.Checked)
        {
          SelectedCamera.Contact.PTZContactMethod = PTZMethod.None;
        }
        else if (radioButtonPTZBlueIris.Checked == false)
        {
          ConfigureMovementButton.Enabled = true;

          if (radioButtonPTZiSpy.Checked)
          {
            GetPTZDefaults(SelectedCamera);

            using ISpyPTZ dlg = new (SelectedCamera);
            if (dlg.ShowDialog() == DialogResult.OK)
            {
            }
          }
          else if (radioButtonPTZHTTP.Checked)
          {
            using HTTPptz dlg = new (SelectedCamera);
            if (dlg.ShowDialog() == DialogResult.OK)
            {
              SelectedCamera.Contact.PTZContactMethod = PTZMethod.HTTP;
            }
          }
          else if (radioButtonPTZOnVIF.Checked)
          {
            SelectedCamera.Contact.PTZContactMethod = PTZMethod.OnVIF;
          }
        }
        else
        {
          SelectedCamera.Contact.PTZContactMethod = PTZMethod.BlueIris;
        }

      }

      DialogResult = DialogResult.None; // don't prop to this dialog
    }

    // most likely the PTZ and snapshot share a make.
    // They don't typically share a model (IME)
    private void GetPTZDefaults(CameraData camera)
    {
      if (string.IsNullOrEmpty(camera.Contact.PTZCameraMake))
      {
        camera.Contact.PTZCameraMake = camera.Contact.JpgCameraMake;  /// which could be empty
      }

      // Handle the case of the user doing presets before ptz for the left handed
      if (string.IsNullOrEmpty(camera.Contact.PTZCameraMake))
      {
        // still nothing, try the preset make
        if (!string.IsNullOrEmpty(camera.Contact.PresetSettings.CameraMake))
        {
          camera.Contact.PTZCameraMake = camera.Contact.PresetSettings.CameraMake;
        }
      }
    }

    private void ConfigureMovementButton_Click(object sender, EventArgs e)
    {
      using PTZMovement dlg = new (SelectedCamera);
      dlg.ShowDialog(); // result values set or not in the SelectedCamera 
    }

    private void ButtonSelectPresetMethod_Click(object sender, EventArgs e)
    {
      DialogResult dlgResult = DialogResult.None;
      CameraContactData data = SelectedCamera.Contact;

      if (radioPresetNone.Checked)
      {
        data.PresetSettings.PresetMethod = PTZMethod.None;
      }
      else if (radioPresetiSpy.Checked)
      {
        GetMakeAndModelPresetDefaults(SelectedCamera);

        using iSpyPreset dlg = new (SelectedCamera);
        dlgResult = dlg.ShowDialog();
        if (dlgResult == DialogResult.OK)
        {
          data.PresetSettings.PresetMethod = PTZMethod.iSpy;
        }
      }
      else if (radioPresetHttp.Checked)
      {
        using HTTPPresets dlg = new (SelectedCamera);
        dlgResult = dlg.ShowDialog();
        if (dlgResult == DialogResult.OK)
        {
          data.PresetSettings.PresetMethod = PTZMethod.HTTP;
        }
      }
      else if (radioPresetOnvif.Checked)
      {
        data.PresetSettings.CameraMake = "OnVIF";
        data.PresetSettings.PresetMethod = PTZMethod.OnVIF;
        data.PresetSettings.PresetList.Clear();
        foreach (var preset in data.ONVIF.PresetsResponse.Preset)
        {
          Preset p = new ();
          p.Name = preset.Name;
          p.Command = preset.token;
          data.PresetSettings.PresetList.Add(p);
        }
      }
      else if (radioPresetBlueIris.Checked)
      {
        data.PresetSettings.PresetList.Clear();
        data.PresetSettings.CameraMake = "Blue Iris";
        data.PresetSettings.PresetMethod = PTZMethod.BlueIris;
        for (int i = 1; i < 128; i++)
        {
          Preset p = new ();
          p.Name = "Preset" + i;
          p.Command = p.Name;
          data.PresetSettings.PresetList.Add(p);
        }
      }
    }

    // Most likely the presets make & model = ptz camera make and model.
    // If not, at least use the make from the snapshot data (likely the same)
    // This assumes that the user is going left to right in the tabs
    private void GetMakeAndModelPresetDefaults(CameraData camera)
    {
      string make = string.Empty;
      if (string.IsNullOrEmpty(camera.Contact.PresetSettings.CameraMake))
      {
        if (!string.IsNullOrEmpty(camera.Contact.PTZCameraMake))
        {
          make = camera.Contact.PTZCameraMake;  // most like preset & ptz are the same
        }
        else
        {
          make = camera.Contact.JpgCameraMake;  // which may be empty, may be what we want, maybe not but a good guess
        }
      }

      camera.Contact.PresetSettings.CameraMake = make;

      string model = string.Empty;
      if (string.IsNullOrEmpty(camera.Contact.PresetSettings.CameraModel) && camera.Contact.PTZCameraMake == make)
      {
        model = camera.Contact.PresetSettings.CameraModel = camera.Contact.PTZCameraModel;  // again, most likely the same if the make is the same
      }

      camera.Contact.PresetSettings.CameraModel = model;
    }

    private void ButtonTestPresets_Click(object sender, EventArgs e)
    {
      using TestPresets dlg = new(SelectedCamera);
      dlg.ShowDialog();
    }

    private void AddCameraButtonClick(object sender, EventArgs e)
    {
      using HelpBox help = new ("Camera Definition", new System.Drawing.Size(620, 460), "AddCameraHelp.rtf");
      help.ShowDialog();
    }

    private void label19_Click(object sender, EventArgs e)
    {

    }

    private void button1_Click(object sender, EventArgs e)
    {
      using HelpBox dlg = new ("Camera Address", new System.Drawing.Size(640, 480), "CameraAddressHelp.rtf");
      dlg.ShowDialog();
    }

    private void CameraContactHelpButton_Click(object sender, EventArgs e)
    {
      using HelpBox dlg = new ("Camera Contact Method", new System.Drawing.Size(800, 650), "SnapshotMethodHelp.rtf");
      dlg.ShowDialog();

    }

    private void PictureQualityHelpButton_Click(object sender, EventArgs e)
    {
      using HelpBox dlg = new ("Picture Quality/Resolution", new System.Drawing.Size(500, 340), "SnapshotResolutionHelp.rtf");
      dlg.ShowDialog();
    }

    private void PTZHelpButton_Click(object sender, EventArgs e)
    {
      using HelpBox dlg = new("Pan, Tilt, Zoom (PTZ)", new System.Drawing.Size(800, 600), "PTZHelp.rtf");
      dlg.ShowDialog();
    }

    private void PresetsHelpButton_Click(object sender, EventArgs e)
    {
      using HelpBox dlg = new ("Preset Positions", new System.Drawing.Size(800, 600), "PresetsHelp.rtf");
      dlg.ShowDialog();
    }

    private void CameraAddressHelpButton_Click(object sender, EventArgs e)
    {
      using HelpBox dlg = new ("Camera Address", new System.Drawing.Size(500, 370), "CameraAddressHelp.rtf");
      dlg.ShowDialog();
    }

    private void EditCameraButton_Click(object sender, EventArgs e)
    {
      var cam = (CameraData)availableCamerasList.SelectedItems[0].Tag;
      ListViewItem item = availableCamerasList.SelectedItems[0];

      string originalID = string.Format("{0}\\{1}", cam.CameraPath, cam.CameraPrefix);

      using AddCameraDialog dlg = new(cam);
      DialogResult result = dlg.ShowDialog();

      string cameraID = string.Format("{0}\\{1}", dlg.CameraFilePath, dlg.CameraPrefix);
      if (cameraID != originalID)
      {
        item.SubItems[0].Text = cam.CameraPrefix;
        item.SubItems[1].Text = cam.CameraPath;
        UpdateUIFromCamera();
      }
    }
    private void OnCameraSelectionChanged(object sender, EventArgs e)
    {
      bool cameraSelected = availableCamerasList.SelectedIndices.Count > 0;
      removeCameraButton.Enabled = cameraSelected;
      EditCameraButton.Enabled = cameraSelected;
      EnableDiableTabs(cameraSelected);
    }

    private void OnContactChanged(object sender, EventArgs e)
    {
    }

    private void EnableDiableTabs(bool enable)
    {
      CameraAddressPanel.Enabled = enable;
      CameraMethodPanel.Enabled = enable;
      CameraQualityGroupbox.Enabled = enable;
      CameraPTZPanel.Enabled = enable;
      CameraPresetPanel.Enabled = enable;
      MotionTimeoutPanel.Enabled = enable;
      MonitorSubFoldersPanel.Enabled = enable;
    }

    private void OnTabIndexChanged(object sender, EventArgs e)
    {

    }

    private void OnTabPageDeselected(object sender, TabControlCancelEventArgs e)
    {
      if (e.TabPage.Name == "liveCameraTab")
      {
        CameraContactData data = SelectedCamera.Contact;
        if (data.CameraXResolution != 0 || data.CameraYResolution != 0)
        {
          if (!data.JPGSnapshotURL.Contains("[WIDTH") || !data.JPGSnapshotURL.Contains("[HEIGHT]"))
          {
            e.Cancel = true;
            MessageBox.Show(this, "If you specify a camera x or y resolution your camera URL must contain the values '[WIDTH]' and '[HEIGHT]'", "Configuration Error!");
          }
        }
      }
    }

    private void AddPresetButton_Click(object sender, EventArgs e)
    {
      using ScheduledPreset dlg = new ();
      if (dlg.ShowDialog() == DialogResult.OK)
      {
        UpdatePresetListView(dlg.TriggerInfo);
      }
    }

    private void UpdatePresetListView(PresetTrigger trigger)
    {
      {
        ListViewItem item = new (trigger.Name);
        item.SubItems.Add((trigger.PresetNumber).ToString()); // Zero Based

        string timeText = string.Empty;
        switch (trigger.TriggerType)
        {
          case PresetTriggerType.Sunrise:
            timeText = "Sunrise";
            break;

          case PresetTriggerType.Sunset:
            timeText = "Sunset";
            break;

          case PresetTriggerType.AtTime:
            timeText = trigger.TriggerTime.ToShortTimeString();  
            break;
        }

        item.SubItems.Add(timeText);
        item.Tag = trigger;
        PresetsListView.Items.Add(item);
      }
    }

    private void EditPresetButton_Click(object sender, EventArgs e)
    {
      int index = PresetsListView.SelectedIndices[0];
      ListViewItem item = PresetsListView.Items[index];

      using ScheduledPreset dlg = new((PresetTrigger)item.Tag);
      if (dlg.ShowDialog() == DialogResult.OK)
      {
        int existingIndex = PresetsListView.SelectedIndices[0];
        PresetsListView.Items.RemoveAt(index);
        UpdatePresetListView(dlg.TriggerInfo);
      }
    }

    private void RemovePresetButton_Click(object sender, EventArgs e)
    {
      if (PresetsListView.SelectedIndices.Count > 0)  // should be, but double check
      {
        int index = PresetsListView.SelectedIndices[0];
        PresetTrigger trigger = (PresetTrigger)PresetsListView.Items[index].Tag;
        AddPresetButton.Focus();
        TimeTrigger.Remove(trigger.ID);
        PresetsListView.Items[index].Remove();
      }
    }

    private void OnPresetIndexChanged(object sender, EventArgs e)
    {
      if (PresetsListView.SelectedIndices.Count > 0)
      {
        EditPresetButton.Enabled = true;
        RemovePresetButton.Enabled = true;
      }
      else
      {
        EditPresetButton.Enabled = false;
        RemovePresetButton.Enabled = false;
      }
    }

    private void OnItemActivate(object sender, EventArgs e)
    {
      EditPresetButton_Click(null, null);
    }
  }
}
