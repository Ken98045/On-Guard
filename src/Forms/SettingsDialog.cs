using OnGuardCore.Src.Properties;
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

      if (Storage.DoesSettingsFileExist())
      {
        string logViewer = Storage.Instance.GetGlobalString("LogViewer");
        if (!string.IsNullOrEmpty(logViewer))
        {
          LogViewerText.Text = logViewer;
        }

        AILocation location = AI.GetAILocation();
        ipAddressText.Text = location.IPAddress;
        portNumeric.Value = location.Port;


        // Database Stuff
        string customConnectionString = Storage.Instance.GetGlobalString("CustomDatabaseConnectionString");
        if (string.IsNullOrEmpty(customConnectionString))
        {
          ConnectionStringText.Text = Storage.Instance.GetGlobalString("DBConnectionString");  // the fully formatted one that is in use!
        }

        Storage.Instance.SetGlobalString("LogViewer", LogViewerText.Text);

        // DeepStack startup stuff
        AutoStartDeepStackCheck.Checked = Storage.Instance.GetGlobalBool("AutoStartDeepStack", true);
        AutoStopDeepStackCheck.Checked = Storage.Instance.GetGlobalBool("AutoStopDeepStack", true);
        OutputVisibleCheckbox.Checked = Storage.Instance.GetGlobalBool("DeepStackVisible", true);
        FaceCheckbox.Checked = Storage.Instance.GetGlobalBool("UseFaceAPI", false);
        CustomTextBox.Text = Storage.Instance.GetGlobalString("CustomDeepStackParameters");

        int deepStackMode = Storage.Instance.GetGlobalInt("DeepStackMode");
        switch (deepStackMode)
        {
          case 2:
            ModeHighRadio.Checked = true;
            break;

          case 1:
            ModeMediumRadio.Checked = true;
            break;

          case 0:
            ModeLowRadio.Checked = true;
            break;

        }

        BuildFinalSettings();

        Storage.Instance.SetGlobalString("FinalDeepStackParmeters", FinalDeepStackTextBox.Text);

        Storage.Instance.Update();
        okButton.Enabled = true;
        AIPanel.Enabled = true;
        SQLPanel.Enabled = true;
        LogPanel.Enabled = true;
      }
    }

    private void CancelButton_Click(object sender, EventArgs e)
    {
      DialogResult = DialogResult.Cancel;
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
        Storage.Instance.Update();
      }
    }


    private void OkButton_Click(object sender, EventArgs e)
    {
      Storage.Instance.SetGlobalString("LogViewer", LogViewerText.Text);
      SaveDeepStackSettings();
      Storage.Instance.Update();
      DialogResult = DialogResult.OK;
    }

    private void SetDataFolderButton_Click(object sender, EventArgs e)
    {
      using OnGuardDataDialog dlg = new ();
      if (dlg.ShowDialog() == DialogResult.OK)
      {
        okButton.Enabled = true;
        AIPanel.Enabled = true;
        SQLPanel.Enabled = true;
        LogPanel.Enabled = true;
      }
    }

    private void HelpButton_Click(object sender, EventArgs e)
    {
      using HelpBox dlg = new ("Database Connection String", new Size(500, 300), "SQLConnectionHelp.rtf");
      dlg.ShowDialog();
    }

    private async void testButton_Click(object sender, EventArgs e)
    {
      SaveDeepStackSettings();
      using Bitmap bm = Resource.OnGuard;
      try
      {
        if (await AIDetection.ProcessTestImageAsync(ipAddressText.Text, (int)portNumeric.Value, bm, "Test Image").ConfigureAwait(true))
        {
          MessageBox.Show(this, "Successfully processed a picture via DeepStack", "Success!");
        }
        else
        {
          MessageBox.Show(this, "The AI Test FAILED!. Either the DeepStack AI was not found or the image was not processed successfully.  Check your DeepStack AI to make sure that it started!", "Test Failure!");
        }
      }
      catch (Exception ex)
      {
        MessageBox.Show(this, "The AI Test FAILED!. Check the IP Address and port.  Make sure DeepStack is running.", "Test Failed!");
      }
    }

    private void OnFaceCheckChanged(object sender, EventArgs e)
    {
      BuildFinalSettings();
    }

    void BuildFinalSettings()
    {
      // deepstack --VISION-DETECTION True --VISION-FACE True --PORT 18099 --MODE High
      string face = string.Empty;
      if (FaceCheckbox.Checked)
      {
        face = "--VISION-FACE True ";
      }

      string mode = "--MODE ";
      if (ModeHighRadio.Checked)
      {
        mode += "High ";
      }
      else if (ModeMediumRadio.Checked)
      {
        mode += "Medium ";
      }
      else
      {
        mode += "Low ";
      }

      FinalDeepStackTextBox.Text =  string.Format("--VISION-DETECTION True {0} {1} {2} {3}",
        face,
        "--PORT " + ((int)portNumeric.Value).ToString() + " ",
        mode,
        CustomTextBox.Text);
    }

    private void SaveDeepStackSettings()
    {
      BuildFinalSettings();

      Storage.Instance.SetGlobalBool("AutoStartDeepStack", AutoStartDeepStackCheck.Checked);
      Storage.Instance.SetGlobalBool("AutoStopDeepStack", AutoStopDeepStackCheck.Checked);
      Storage.Instance.SetGlobalBool("DeepStackVisible", OutputVisibleCheckbox.Checked);
      Storage.Instance.SetGlobalBool("UseFaceAPI", FaceCheckbox.Checked);
      Storage.Instance.SetGlobalString("CustomDeepStackParameters", CustomTextBox.Text);

      int mode = 0;
      if (ModeHighRadio.Checked)
      {
        mode = 2;
      }
      else if (ModeMediumRadio.Checked)
      {
        mode = 1;
      }

      Storage.Instance.SetGlobalInt("DeepStackMode", mode);
      Storage.Instance.SetGlobalString("DeepStackParameters", FinalDeepStackTextBox.Text);
      Storage.Instance.SetAILocation(ipAddressText.Text, (int) portNumeric.Value);
    }

    private void OnModeChanged(object sender, EventArgs e)
    {
      BuildFinalSettings();
    }

    private void ButtonCustom_Click(object sender, EventArgs e)
    {
      BuildFinalSettings();
    }

    private void OnPortChanged(object sender, EventArgs e)
    {
      BuildFinalSettings();
    }

    private void StartAIButton_Click(object sender, EventArgs e)
    {
      SaveDeepStackSettings();
      if (!AI.RestartAI(true))
      {
        MessageBox.Show(this, "The DeepStackAI could not be started with these settings!", "AI Startup Failed!");
      }
    }
  }
}
