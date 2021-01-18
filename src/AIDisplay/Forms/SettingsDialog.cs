using SAAI.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using System.Windows.Media.Imaging;

namespace SAAI
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
      string ipAddress;
      int aiPort = Storage.GetGlobalInt("DeepStackPort");

      if (!string.IsNullOrEmpty("ipAddress") && aiPort != 0)
      {
        ipAddress = Storage.GetGlobalString("DeepStackIPAddress");
        if (string.IsNullOrEmpty(ipAddress))
        {
          ipAddress = Settings.Default.AIIPAddress;

        }
        ipAddressText.Text = ipAddress;

        int port = Storage.GetGlobalInt("DeepStackPort");
        if (port == 0)
        {
          port = Settings.Default.AIPort;
        }
        portNumeric.Value = port;

        double snapshot = Storage.GetGlobalDouble("FrameInterval");
        if (snapshot == 0.0)
        {
          snapshot = (double)Settings.Default.TimePerFrame;
        }
        snapshotNumeric.Value = (decimal)snapshot;

        int maxEvent = Storage.GetGlobalInt("MaxEventTime");
        if (maxEvent == 0)
        {
          maxEvent = Settings.Default.MaxEventTime;
        }
        maxEventNumeric.Value = maxEvent;

        int eventInterval = Storage.GetGlobalInt("EventInterval");
        if (eventInterval == 0)
        {
          eventInterval = Settings.Default.EventInterval;
        }
        eventIntervalNumeric.Value = eventInterval;
      }

    }

    private void OkButton_Click(object sender, EventArgs e)
    {
      if (!string.IsNullOrEmpty(ipAddressText.Text))
      {
        if (ipAddressText.Text.Contains("http") || ipAddressText.Text.Contains("//"))
        {
          MessageBox.Show("The IP Address or machine name must not include \"http\" or \"//\"");
        }
        else
        {
          Storage.SetGlobalString("DeepStackIPAddress", ipAddressText.Text);
          Storage.SetGlobalInt("DeepStackPort", (int)portNumeric.Value);
          Storage.SetGlobalDouble("FrameInterval", (double) snapshotNumeric.Value);
          Storage.SetGlobalInt("MaxEventTime", (int)maxEventNumeric.Value);
          Storage.SetGlobalInt("EventInterval", (int)eventIntervalNumeric.Value);
          DialogResult = DialogResult.OK;
        }
      }
      else
      {
        MessageBox.Show("The IP Address or computer name must not be empty.");
      }

    }

    private void CancelButton_Click(object sender, EventArgs e)
    {
      DialogResult = DialogResult.Cancel;

    }

    private async void TestButton_Click(object sender, EventArgs e)
    {
      // Create source.
      object O = Resources.ResourceManager.GetObject("OnGuard"); //Return an object from the image chan1.png in the project
      using (Bitmap bm = (Bitmap)O)
      {
        using (MemoryStream mem = new MemoryStream())
        {
          bm.Save(mem, ImageFormat.Jpeg);
          mem.Position = 0;
          try
          {
            AIAnalyzer ai = new AIAnalyzer(ipAddressText.Text, (int)portNumeric.Value);
            List<ImageObject> imageObjects = await ai.ProcessVideoImageViaAI(mem, "Test Image").ConfigureAwait(false);
            if (imageObjects != null && imageObjects.Count > 0)
            {
              MessageBox.Show(this, "Successfully processed a picture via DeepStack", "Success!");
            }
            else
            {
              MessageBox.Show(this, "The AI Test FAILED!. DeepStack was found, but the image was not processed successfully.  Check your DeepStack startup to make sure --VISION-DETECTION True is set!", "Test Failure!");
            }
          }
          catch (AiNotFoundException ex)
          {
            MessageBox.Show(this, "The AI Test FAILED!. Check the IP Address and port.  Make sure DeepStack is running.", "Test Failed!");
          }
        }
      }
    }
  }
}
