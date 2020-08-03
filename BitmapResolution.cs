using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAAI
{

  /// <summary>
  /// Just a class to hold a global that has the resolution of the source bitmap
  /// We need to access it from multiple files.
  /// </summary>
  public static class BitmapResolution
  {
    static public int XResolution { get; set; } = 1024;
    static public int YResolution { get; set; } = 768;
  }
}
