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
        path = Settings.Default.DataFileLocation;
        Storage.Instance.SetGlobalInt("DBLocationType", 0);   // the user directory
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
