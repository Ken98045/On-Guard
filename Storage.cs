using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Win32;


namespace SAAI
{
  static public class Storage
  {
    public static string GetFilePath(string fileName)
    {
      string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
      path = Path.Combine(path, "OnGuard");

      if (!Directory.Exists(path))
      {
        Directory.CreateDirectory(path);
      }

      path = Path.Combine(path, fileName);
      return path;
    }

  }
}
