using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Win32;
using System.Drawing;

namespace OnGuardCore
{
  public class Storage
  {
    private static  bool useRegistry = true;
    private static IStorage _registryStore = new RegistryStorage();
    private static IStorage _xmlStore = new XMLStorage();
    Storage()
    {
      
    }

    static public string GetFilePath(string fileName)
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


    public static IStorage Instance
    {
      get
      {
        if (UseRegistry)
        {
          return _registryStore;
        }
        else
        {
          return _xmlStore;
        }
      }
    }

    public static bool UseRegistry { get => useRegistry; set => useRegistry = value; }

  }


}

