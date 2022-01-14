using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using OnGuardCore.Src.Properties;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace OnGuardCore
{
  public partial class OnGuardDataDialog : Form
  {
    public string FolderLocation { get; set; }
    private string _originalDBPath = string.Empty;    // So we know if we need to copy the DB files
    public string DatabaseFolderLocation { get; set; }

    public OnGuardDataDialog()
    {
      InitializeComponent();


      string storagePath = Settings.Default.DataFileLocation; // a setting that must come from the settings.settings for the app in order to find the xml settings file
      string existingLocation = string.Empty;

      FileText.Text = storagePath;

      if (Directory.Exists(storagePath) && File.Exists(Path.Combine(storagePath, "OnGuardStorage.xml")))
      {
      }

      _originalDBPath = DBConnection.GetDatabasePath();
      pathDatabaseText.Text = _originalDBPath;

    }


    private void OKButton_Click(object sender, EventArgs e)
    {
      if (string.IsNullOrEmpty(FileText.Text))
      {
        MessageBox.Show("You must either browse to the data files location or press 'Use Default'", "Configuration Error!");
      }

      if (string.IsNullOrEmpty(pathDatabaseText.Text))
      {
        MessageBox.Show("You must either browse to the database file location or press 'Use Default'", "Configuration Error!");
      }

      // First, save the data files location and create the folder if necessary
      Settings.Default.DataFileLocation = FileText.Text;
      try
      {
        if (!Directory.Exists(FileText.Text))
        {
          Directory.CreateDirectory(FileText.Text);
        }
      }
      catch (Exception ex)
      {
        MessageBox.Show(this, "There was an error attempting to create the settings data folder: " + FileText.Text + " Exception: " + ex.Message, "Invalid Folder Path");
        return;
      }

      Settings.Default.Save();

      // Now we need to handle the DB location.  This is more complex because you can't just set it
      // If the location has changed we need to copy the DB files over to the new location and change the
      // DBConnection path
      string destPath = pathDatabaseText.Text;
      destPath = Path.Combine(destPath, "DBNewMotionFrames.mdf");
      if (!File.Exists(destPath))
      {
        string srcPath = _originalDBPath;
        srcPath = Path.Combine(srcPath, "DBNewMotionFrames.mdf");

        if (File.Exists(srcPath))
        {
          if (MessageBox.Show("The database files do not exist in the new location.  Copy them?", "Copy Files?", MessageBoxButtons.YesNo) == DialogResult.Yes)
          {
            File.Copy(srcPath, destPath);
            srcPath = Path.Combine(_originalDBPath, "DBNewMotionFrames_log.ldf");
            destPath = Path.Combine(pathDatabaseText.Text, "DBNewMotionFrames_log.ldf");
            File.Copy(srcPath, destPath);
          }
        }
        else
        {
          AppDomain domain = AppDomain.CurrentDomain;
          string baseLocation = domain.BaseDirectory;
          if (!string.IsNullOrEmpty(baseLocation))
          {
            srcPath = Path.Combine(baseLocation, "DBNewMotionFrames.mdf");
            if (File.Exists(srcPath))
            {
              destPath = Path.Combine(pathDatabaseText.Text, "DBNewMotionFrames.mdf");
              File.Copy(srcPath, destPath);
              srcPath = Path.Combine(baseLocation, "DBNewMotionFrames_log.ldf");
              destPath = Path.Combine(pathDatabaseText.Text, "DBNewMotionFrames_log.ldf");
              File.Copy(srcPath, destPath);
            }

          }
        }
      }

      FolderLocation = pathDatabaseText.Text;
      DBConnection.SetDatabasePath(pathDatabaseText.Text);
      DialogResult = DialogResult.OK;
    }

    private void HelpButton_Click(object sender, EventArgs e)
    {
      using HelpBox dlg = new ("Set Data File Location", new Size(500, 400), "DataFilesHelp.rtf");
      dlg.ShowDialog();
    }

    private void CancelButton_Click(object sender, EventArgs e)
    {
      DialogResult = DialogResult.Cancel;
    }

    private void FileBrowseClick(object sender, EventArgs e)
    {
      using FolderBrowserDialog folderBrowserDialog1 = new()
      {
        ShowNewFolderButton = true
      };

      folderBrowserDialog1.RootFolder = Environment.SpecialFolder.MyComputer;
      DialogResult pathResult = folderBrowserDialog1.ShowDialog();
      if (pathResult == DialogResult.OK)
      {
        FileText.Text = folderBrowserDialog1.SelectedPath;
      }
    }

    private void BrowseDatabaseClick(object sender, EventArgs e)
    {
      using FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog
      {
        ShowNewFolderButton = true
      };

      folderBrowserDialog1.RootFolder = Environment.SpecialFolder.MyComputer;
      DialogResult pathResult = folderBrowserDialog1.ShowDialog();
      if (pathResult == DialogResult.OK)
      {
        pathDatabaseText.Text = folderBrowserDialog1.SelectedPath;
      }

    }

    private void DefaultDataButton_Click(object sender, EventArgs e)
    {
      string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
      path += "OnGuard";
      FileText.Text = path;
    }

    private void DefaultDBButton_Click(object sender, EventArgs e)
    {
      string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
      path += "OnGuard";
      pathDatabaseText.Text = path;

    }
  }
}

