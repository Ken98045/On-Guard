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
    private string _originalSettingsPath = string.Empty;
    public string DatabaseFolderLocation { get; set; }

    public OnGuardDataDialog()
    {
      InitializeComponent();

      FileText.Text = Settings.Default.DataFileLocation; // a setting that must come from the settings.settings for the app in order to find the xml settings file (or use app.config, which isn't happening now)
      _originalSettingsPath = FileText.Text;

      if (Directory.Exists(FileText.Text) && File.Exists(Path.Combine(FileText.Text, "OnGuardStorage.xml")))
      {
        _originalDBPath = Storage.Instance.GetGlobalString("DatabasePath");
      }

      // If the datbase path was not found, make it the same as the file path
      if (string.IsNullOrEmpty(_originalDBPath))
      {
        _originalDBPath = _originalSettingsPath;
      }

      pathDatabaseText.Text = _originalDBPath;
    }


    private void OKButton_Click(object sender, EventArgs e)
    {
      bool exitRequired = false;

      if (string.IsNullOrEmpty(FileText.Text))
      {
        MessageBox.Show("You must either browse to the data files location or press 'Use Default'", "Configuration Error!");
      }

      if (string.IsNullOrEmpty(pathDatabaseText.Text))
      {
        MessageBox.Show("You must either browse to the database file location or press 'Use Default'", "Configuration Error!");
      }

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

      if (_originalSettingsPath != FileText.Text)
      {
        DialogResult confirm = MessageBox.Show(this, "The Data Files Folder location has changed.  On Guard must exit if you continue.  You may then restart it.  Continue? ", "Data Files Folder Changed!", MessageBoxButtons.YesNo);
        if (confirm == DialogResult.Yes)
        {
          // First, save the data files location and create the folder if necessary
          Settings.Default.DataFileLocation = FileText.Text;

          Settings.Default.Save();
          exitRequired = true;
        }
      }

      if (_originalDBPath != pathDatabaseText.Text)
      {
        DialogResult confirm = MessageBox.Show(this, "The Motion Database Files Folder location has changed.  On Guard must exit if you continue.  You may then restart it.  Continue? ", "Motion Database Folder Changed!", MessageBoxButtons.YesNo);
        if (confirm == DialogResult.Yes)
        {
          DBConnection.SetDatabasePath(pathDatabaseText.Text);
          MotionDBContext.SetupDatabase(pathDatabaseText.Text);
          exitRequired = true;
        }
      }

      if (exitRequired)
      {
        Application.Exit();
      }

      DialogResult = DialogResult.OK;
      this.Close();
    }

    private void HelpButton_Click(object sender, EventArgs e)
    {
      using HelpBox dlg = new("Set Data File Location", new Size(500, 400), "DataFilesHelp.rtf");
      dlg.ShowDialog();
    }

    private void CancelButton_Click(object sender, EventArgs e)
    {
      DialogResult = DialogResult.Cancel;
      this.Close();
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

