using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace OnGuardCore
{
  public static class GlobalData
  {
    public static int AreaGridX { get => 64; }  // may be settable in the future
    public static int AreaGridY { get => 64; }

  }

  public static class GlobalFunctions
  {
    public static string GetUniqueFileName(string fileName)
    {
      string result = string.Empty;
      if (!string.IsNullOrEmpty(fileName))
      {
        FileInfo fi = new FileInfo(fileName);
        if (fi.Exists)
        {
          long fileTime = fi.CreationTime.ToFileTime();
          result = GetFileKey(fi, fileName);
        }
      }

      return result;
    }

    public static string GetFileKey(FileInfo fi, string fileName)
    {
      string result = string.Empty;
      if (!string.IsNullOrEmpty(fileName))
      {
        long fileTime = fi.CreationTime.ToFileTime();
        result = $"{fileTime,0:0000000000000000000}-{Path.GetFileName(fileName).ToLower()}";
        result = result.ToLower();
      }

      return result;
    }

    public static string GetComparisonKey(DateTime compTime)
    {
      string result = string.Empty;
      long fileTime = compTime.ToFileTime();
      result = $"{fileTime,0:0000000000000000000}-";
      return result;
    }


  }
}
