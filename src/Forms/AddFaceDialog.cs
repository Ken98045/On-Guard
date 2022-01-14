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



namespace OnGuardCore
{
  public partial class AddFaceDialog : Form
  {

    public string FaceName { get; set; }
    public int Confidence { get; set; }

    public AddFaceDialog(FaceID face)
    {
      InitializeComponent();

      string basePath = Storage.GetFilePath(string.Empty);
      basePath = Path.Combine(basePath, "Faces");
      if (!Directory.Exists(basePath))
      {
        Directory.CreateDirectory(basePath);
      }

      string[] existingNames = Directory.GetDirectories(basePath);
      foreach (string nameDir in existingNames)
      {
        if (basePath.Length < nameDir.Length)
        {
          string subDir = nameDir[(basePath.Length + 1)..];
          FacesComboBox.Items.Add(subDir);
        }
      }

      if (FacesComboBox.Items.Count > 0)
      {
        if (null != face)
        {
          FacesComboBox.SelectedItem = face.Name;
        }
      }
    }

    private void CancelButton_Click(object sender, EventArgs e)
    {
      DialogResult = DialogResult.Cancel;
    }

    private void OKButton_Click(object sender, EventArgs e)
    {
      if (FacesComboBox.SelectedIndex != -1)
      {
        FaceName = (string)FacesComboBox.Items[FacesComboBox.SelectedIndex];
        Confidence = (int)ConfidenceNumeric.Value;
        DialogResult = DialogResult.OK;
      }
    }
  }

  public class FaceID
  {
    public string Name { get; set; }
    public int Confidence { get; set; }
    public bool Selected { get; set; }
  }
}
