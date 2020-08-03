using System;
using System.IO;
using System.Windows.Forms;

namespace SAAI
{

/// <summary>
/// A simple dialog to get a camera path & prefix.  
/// Nothing to see here
/// </summary>
  public partial class AddCameraDialog : Form
  {

    public string CameraFilePath { get; set; }
    public string CameraPrefix { get; set; }
    public AddCameraDialog()
    {
      InitializeComponent();
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
        MessageBox.Show("The camera file path must not be empty!");
      }
      else
      {
        if (Directory.Exists(pathText.Text))
        {
          if (string.IsNullOrEmpty(prefixText.Text))
          {
            MessageBox.Show("The camera prefix must not be empty!");
          }
          else
          {
            CameraFilePath = pathText.Text;
            CameraPrefix = prefixText.Text;
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
  }
}
