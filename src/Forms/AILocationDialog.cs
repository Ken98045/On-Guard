using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Resources;
using System.Drawing.Imaging;
using OnGuardCore.Src.Properties;
using System.Globalization;

namespace OnGuardCore
{
  public partial class AILocationDialog : Form
  {
    public AILocation Location { get; set; }
    public AILocationDialog()
    {
      InitializeComponent();
    }

    public AILocationDialog(AILocation location)
    {
      if (location != null)
      {
        Location = location;
        InitializeComponent();
        ipAddressText.Text = Location.IPAddress;
        portNumeric.Value = Location.Port;
      }
      else
      {
        throw new ArgumentNullException();
      }
    }

    private void OKButton_Click(object sender, EventArgs e)
    {
      if (!string.IsNullOrEmpty(ipAddressText.Text))
      {
        if (ipAddressText.Text.Contains("http") || ipAddressText.Text.Contains("//"))
        {
          MessageBox.Show("The IP Address or machine name must not include \"http\" or \"//\"");
        }
        else
        {
          if (Location == null)
          {
            Location = new AILocation(Guid.NewGuid(), ipAddressText.Text, (int)portNumeric.Value);
          }
          else
          {
            Location.IPAddress = ipAddressText.Text;
            Location.Port = (int)portNumeric.Value;
          }

          Storage.Instance.SetAILocation(Location);
          AILocation.Refresh();
          DialogResult = DialogResult.OK;
        }
      }
    }

    private async void TestButton_Click(object sender, EventArgs e)
    {
      
      using (Bitmap bm = Resource.OnGuard)
      {
        using (MemoryStream mem = new MemoryStream())
        {
          bm.Save(mem, ImageFormat.Jpeg);
          mem.Position = 0;
          try
          {
            AILocation location = new AILocation(Guid.NewGuid(), ipAddressText.Text, (int)portNumeric.Value);
            List<ImageObject> imageObjects = AIDetection.ProcessTestImage(location, mem, "Test Image").Result;
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

