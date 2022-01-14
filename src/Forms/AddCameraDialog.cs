using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace OnGuardCore
{

  /// <summary>
  /// A simple dialog to get a camera path & prefix.  
  /// Nothing to see here
  /// </summary>
  public partial class AddCameraDialog : Form
  {

    public string CameraFilePath { get; set; }
    public string CameraPrefix { get; set; }
    public CameraData Camera { get => _camera; set => _camera = value; }

    CameraData _camera;

    public AddCameraDialog(CameraData camera)
    {
      Camera = camera;
      InitializeComponent();

      if (Camera != null)
      {

        pathText.Text = camera.CameraPath;
        prefixText.Text = camera.CameraPrefix;

        switch (camera.CameraInputMethod)
        {
          case CameraMethod.Application:
            radioSoftware.Checked = true;
            break;

          case CameraMethod.OnGuard:
            radioScanImages.Checked = true;
            break;

          case CameraMethod.CameraTriggered:
            radioTrigger.Checked = true;
            break;
        }

        if ((decimal)camera.OnGuardScanIterval >= CheckIntervalNumeric.Minimum)
        {
          CheckIntervalNumeric.Value = (decimal)camera.OnGuardScanIterval;
        }

        OnlyInAreasCheckbox.Checked = camera.StorePicturesInAreaOnly;

        if ((decimal)camera.TriggerInterval >= (decimal)RecordTimeNumeric.Minimum)
        {
          RecordFrameIntervalNumeric.Value = (decimal)camera.TriggerInterval;
        }

        if ((decimal)camera.RecordTime >= RecordTimeNumeric.Minimum)
        {
          RecordTimeNumeric.Value = (decimal)camera.RecordTime;
        }

        if ((decimal)camera.RecordInterval >= (decimal)NoRecordNumeric.Minimum)
        {
          NoRecordNumeric.Value = (decimal)camera.RecordInterval;
        }

        triggerPrefixText.Text = camera.TriggerPrefix;

      }
    }



    private void BrowseButton_Click(object sender, EventArgs e)
    {
      using (FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog
      {
        ShowNewFolderButton = false
      })
      {

        folderBrowserDialog1.RootFolder = Environment.SpecialFolder.MyComputer;
        DialogResult pathResult = folderBrowserDialog1.ShowDialog();
        if (pathResult == DialogResult.OK)
        {
          pathText.Text = folderBrowserDialog1.SelectedPath;
        }
      }
    }

    private void OkButton_Click(object sender, EventArgs e)
    {
      if (string.IsNullOrEmpty(pathText.Text))
      {
        MessageBox.Show("The camera file path must not be empty!", "Settings Error!");
      }
      else
      {
        if (Directory.Exists(pathText.Text))
        {
          if (string.IsNullOrEmpty(prefixText.Text))
          {
            MessageBox.Show("The camera prefix must not be empty!", "Settings Error!");
          }
          else
          {
            if (radioTrigger.Checked)
            {
              if (string.IsNullOrEmpty(triggerPrefixText.Text))
              {
                MessageBox.Show("If you wish to create a Camera Triggered camera, the Trigger Prefix must not be empty", "Settings Error!");
                return;
              }
            }

            if (null == Camera)
            {
              Camera = new CameraData(Guid.NewGuid(), prefixText.Text, pathText.Text);
            }

            if (!string.IsNullOrEmpty(triggerPrefixText.Text))
            {
              bool subset = false;

              if (prefixText.Text.ToLower() == triggerPrefixText.Text.ToLower())
              {
                subset = true;
              }
              else if (triggerPrefixText.Text.Length < prefixText.Text.Length)
              {
                if (triggerPrefixText.Text.ToLower() == prefixText.Text.Substring(0, triggerPrefixText.Text.Length).ToLower())
                {
                  subset = true;
                }
              }
              else
              {
                if (prefixText.Text == triggerPrefixText.Text.Substring(0, prefixText.Text.Length))
                {
                  subset = true;
                }
              }

              if (subset)
              {
                MessageBox.Show("The Trigger Prefix may not be a subset of the camera prefix!", "Invalid Trigger Prefix");
                return;
              }

              Camera.TriggerPrefix = triggerPrefixText.Text;

            }

            CameraFilePath = pathText.Text;
            CameraPrefix = prefixText.Text;

            if (null != Camera)
            {
              Camera.OnGuardScanIterval = (double)CheckIntervalNumeric.Value;
              Camera.StorePicturesInAreaOnly = OnlyInAreasCheckbox.Checked;
              Camera.TriggerInterval = (double)RecordFrameIntervalNumeric.Value;
              Camera.RecordTime = (double)RecordTimeNumeric.Value;
              Camera.RecordInterval = (double)NoRecordNumeric.Value;
              Camera.CameraPath = pathText.Text;
              Camera.CameraPrefix = prefixText.Text;

              if (radioSoftware.Checked)
              {
                Camera.CameraInputMethod = CameraMethod.Application;
              }
              else if (radioScanImages.Checked)
              {
                Camera.CameraInputMethod = CameraMethod.OnGuard;
              }
              else
              {
                Camera.CameraInputMethod = CameraMethod.CameraTriggered;
              }

            }

            DialogResult = DialogResult.OK;
          }
        }
        else
        {
          MessageBox.Show("The camera file path directory is not valid!");
        }
      }

    }

    private void CancelButton_Click(object sender, EventArgs e)
    {
      DialogResult = DialogResult.Cancel;
    }

    private void OnMethodChanged(object sender, EventArgs e)
    {
      if (radioSoftware.Checked)
      {
        OnGuardPanel.Enabled = false;
        CameraTriggerPanel.Enabled = false;
      }
      else if (radioScanImages.Checked)
      {
        OnGuardPanel.Enabled = true;
        CameraTriggerPanel.Enabled = false;
      }
      else if (radioTrigger.Checked)
      {
        OnGuardPanel.Enabled = false;
        CameraTriggerPanel.Enabled = true;
      }

    }


    private void HelpMethodButton_Click(object sender, EventArgs e)
    {
      using (HelpBox dlg = new HelpBox("Image Input Method", new Size(600, 640), "AddCameraHelp.rtf"))
      {
        dlg.ShowDialog();
      }

    }

    private void AddCameraDialog_Load(object sender, EventArgs e)
    {

    }

    private void FolderPrefixHelp_Click(object sender, EventArgs e)
    {
      using (HelpBox dlg = new HelpBox("Folder and Prefix", new Size(600, 600), "FolderPrefixHelp.rtf"))
      {
        dlg.ShowDialog();
      }
    }

    private void OnGuardScanHelpButton_Click(object sender, EventArgs e)
    {
      using (HelpBox dlg = new HelpBox("On Guard Scan", new Size(600, 600), "OnGuardCaptureHelp.rtf"))
      {
        dlg.ShowDialog();
      }

    }

    private void CameraTriggeredHelpButton_Click(object sender, EventArgs e)
    {
      using (HelpBox dlg = new HelpBox("On Guard Scan", new Size(600, 600), "CameraTriggeredHelp.rtf"))
      {
        dlg.ShowDialog();
      }

    }

    private void Label2_Click(object sender, EventArgs e)
    {

    }
  }
}
