using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace OnGuardCore
{
  public class PictureInfo
  {
    public string FileName { get; }
    public string PictureKey { get; }
    public DateTime FileTime { get; set; }

    public PictureInfo(string fileName)
    {
      FileName = fileName.ToLower();
      FileInfo fi = new FileInfo(fileName);
      PictureKey = GlobalFunctions.GetFileKey(fi, fileName);
      FileTime = fi.CreationTime;
    }

    public override string ToString()
    {
      return FileName;
    }
  }
}
