using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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
    static public double XScale { get; set; } = 1.0;
    static public double YScale { get; set; } = 1.0;

    public static Rectangle ScaleScreenToData(Rectangle rect)
    {
      Rectangle result = new Rectangle((int)Math.Round(rect.X * XScale), (int)Math.Round(rect.Y * YScale), (int)Math.Round(rect.Width * XScale), (int)Math.Round(rect.Height * YScale));
      return result;
    }

    public static Point ScaleScreenToData(Point point)
    {
      Point result = new Point((int)Math.Round(point.X * XScale), (int)Math.Round(point.Y * YScale));
      return result;
    }

  }

}
