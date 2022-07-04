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

        Storage.Instance.SetGlobalString("LogViewer", LogViewerText.Text);

        // DeepStack startup stuff
        AutoStartDeepStackCheck.Checked = Storage.Instance.GetGlobalBool("AutoStartDeepStack", true);
        AutoStopDeepStackCheck.Checked = Storage.Instance.GetGlobalBool("AutoStopDeepStack", true);
        OutputVisibleCheckbox.Checked = Storage.Instance.GetGlobalBool("DeepStackVisible", true);
        FaceCheckbox.Checked = Storage.Instance.GetGlobalBool("UseFaceAPI", false);
        CustomTextBox.Text = Storage.Instance.GetGlobalString("CustomDeepStackParameters");
        threadCountNumeric.Value = Storage.Instance.GetGlobalIntWithDefault("AIThreadCount", 0);

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
        LogPanel.Enabled = true;
      }
    }

    private void CancelButton_Click(object sender, EventArgs e)
    {
      DialogResult = DialogResult.Cancel;
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
        LogPanel.Enabled = true;
      }
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

      string threadCount = "";
      if (threadCountNumeric.Value > 0)
      {
        threadCount = string.Format("--THREADCOUNT {0}", threadCountNumeric.Value);
      }

      FinalDeepStackTextBox.Text = $"--VISION-DETECTION True {face} --PORT {portNumeric.Value} {mode} {CustomTextBox.Text} {threadCount}";
    }

    private void SaveDeepStackSettings()
    {
      BuildFinalSettings();

      Storage.Instance.SetGlobalBool("AutoStartDeepStack", AutoStartDeepStackCheck.Checked);
      Storage.Instance.SetGlobalBool("AutoStopDeepStack", AutoStopDeepStackCheck.Checked);
      Storage.Instance.SetGlobalBool("DeepStackVisible", OutputVisibleCheckbox.Checked);
      Storage.Instance.SetGlobalBool("UseFaceAPI", FaceCheckbox.Checked);
      Storage.Instance.SetGlobalString("CustomDeepStackParameters", CustomTextBox.Text);
      Storage.Instance.SetGlobalInt("AIThreadCount", Convert.ToInt32(threadCountNumeric.Value));

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
