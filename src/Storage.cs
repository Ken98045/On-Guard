using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using OnGuardCore.Src.Properties;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Drawing;

namespace OnGuardCore
{
  public class Storage
  {
    private static IStorage _xmlStore = new XMLStorage();
    Storage()
    {

    }

    public static bool DoesDataDirectoryExist()
    {
      bool result = false;

      string path = Settings.Default.DataFileLocation;
      if (Directory.Exists(path))
      {
        result = true;
      }
      return result;
    }

    public static bool DoesSettingsFileExist()
    {
      bool result = false;

      if (DoesDataDirectoryExist())
      {
        string path = GetFilePath("OnGuardStorage.xml");
        if (File.Exists(path))
        {
        result=true;
        }
      }

      return result;
    }

    static public string GetFilePath(string fileName)
    {
      string path = Settings.Default.DataFileLocation;
      if (string.IsNullOrEmpty(path))
      {
        using OnGuardDataDialog dlg = new ();
        if (DialogResult.OK == dlg.ShowDialog())
        {
          path = dlg.FolderLocation;
          Settings.Default.DataFileLocation = path;
          Settings.Default.DatabaseFileLocation = dlg.DatabaseFolderLocation;
          Settings.Default.Save();
        }
        else
        {
          MessageBox.Show("You must set a data file folder.  The application will now exit", "Exiting!");
          Application.Exit();
        }
      }

      if (!Directory.Exists(path))
      {
        Directory.CreateDirectory(path);
      }

      if (!string.IsNullOrEmpty(fileName))
      {
        path = Path.Combine(path, fileName);
      }

      return path;
    }


    public static IStorage Instance
    {
      get
      {
        return _xmlStore;
      }
    }

  }


}

