using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnGuardCore.Src.Properties;

namespace OnGuardCore
{
  public static class DBConnection
  {
    /// <summary>
    /// Get either the custom connection string or the default one.
    /// </summary>
    /// <returns></returns>
    public static string GetConnectionString()
    {
      string connectionString = string.Empty;
      connectionString = Storage.Instance.GetGlobalString("CustomDatabaseConnectionString");

      if (string.IsNullOrEmpty(connectionString))
      {
        // This the normal case where there is no custom string
        connectionString = GetDefaultConnectionString();

        /*
        string currentString = Storage.Instance.GetGlobalString("DBConnectionString");
        connectionString = GetDefaultConnectionString();
        if (currentString != connectionString)
        {
          Dbg.Write("DBConnection - GetConnectionString - Unexpected location difference");
          Storage.Instance.SetGlobalString("DBConnectionString", connectionString);
          Storage.Instance.Update();
        }
        */
      }

      return connectionString;
    }

    /// <summary>
    /// Store the path (only) to the database
    /// </summary>
    /// <param name="path"></param>
    public static void SetDatabasePath(string path)
    {
      Storage.Instance.SetGlobalString("DatabasePath", path);
      Storage.Instance.Update();
    }

    public static string GetDatabasePath()
    {
      string path = Storage.Instance.GetGlobalString("DatabasePath");
      if (string.IsNullOrEmpty(path))
      {
        AppDomain domain = AppDomain.CurrentDomain;
        string dataDirectory = (string)domain.GetData("DataDirectory"); // might be set by the installer
        if (!string.IsNullOrEmpty(dataDirectory))
        {
          Storage.Instance.SetGlobalInt("DBLocationType", 1); // an absolute path
          Dbg.Write("DBConnection - GetDatabasePath - The path was set by DataDirectory - " + dataDirectory);
          path = dataDirectory;
        }
        else
        {
          path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
          path = Path.Combine(path, "OnGuard");   // where the installer puts things TODO: Double Check this!
          Storage.Instance.SetGlobalInt("DBLocationType", 0);   // the user directory
        }
      }
      else
      {
        Storage.Instance.SetGlobalInt("DBLocationType", 1); // Now an absolut path regardless of what it was
      }

      return path;
    }

    /// <summary>
    /// The  settings connection string is the minimal connection string without a path.  Instead it has a {0] for the path that is then filled in here.
    /// If we have already set the database path in the xml file we use that.  Otherwise we use the user directory where the installer should have
    /// put the database.
    /// No luck using |DataDirectory
    /// </summary>
    /// <returns></returns>
    public static string GetDefaultConnectionString()
    {
      // Since we are getting the value we need to format it
      string baseConnectionString = Settings.Default.DBMotionFramesConnectionString;  // the base string with {0} in place of the file location
      string dbLocation = GetDatabasePath();
      string connectionString = string.Format(baseConnectionString, dbLocation);   // insert the localdb path
      return connectionString;
    }

  }
}
