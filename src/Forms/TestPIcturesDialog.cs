using OnGuardCore.Src.Properties;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnGuardCore
{
  public partial class TestPIcturesDialog : Form
  {
    CameraCollection _cameras;
    public TestPIcturesDialog(CameraCollection cameras)
    {
      _cameras = cameras;
      InitializeComponent();
      CameraData cam;

      ((ListBox)this.checkedListBoxCameras).DataSource = _cameras.CameraDictionary.Values.ToArray();
      ((ListBox)this.checkedListBoxCameras).DisplayMember = "CameraPrefix";
      
      for (int i = 0; i < checkedListBoxCameras.Items.Count; i++)
      {
        checkedListBoxCameras.SetItemChecked(i, true);
      }
    }

    private void ButtonOK_Click(object sender, EventArgs e)
    {

      ResourceSet allPics = SamplePictureResources.ResourceManager.GetResourceSet(CultureInfo.InvariantCulture, true, true);

      foreach (int itemChecked in checkedListBoxCameras.CheckedIndices)
      {
        CameraData camera = (CameraData)(checkedListBoxCameras.Items[itemChecked]);

        IDictionaryEnumerator dict = allPics.GetEnumerator();

        while (dict.MoveNext())
        {
          Bitmap bm = (Bitmap)dict.Value;
          using MemoryStream mem = new();
          string fullPath = CameraData.PathAndPrefix(camera);
          fullPath += DateTime.Now.Ticks.ToString() + ".jpg";
          bm.Save(fullPath, ImageFormat.Jpeg);
        }
      }

        DialogResult = DialogResult.OK;
      this.Close();
    }

    private void ButtonCancel_Click(object sender, EventArgs e)
    {

      DialogResult = DialogResult.Cancel;
      this.Close();
    }
  }
}
