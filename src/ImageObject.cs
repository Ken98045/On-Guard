using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnGuardCore
{
  public class ImageObject
  {
    public ImageObject()
    {

      Label = "none";

      // Some unnecessary initializations, but...
      Success = false;
      InMotion = false;
      Confidence = 0.0;
      X_min = 0;
      Y_min = 0;
      X_max = 0;
      Y_max = 0;
    }

    public bool Success { get; set; }
    public string Label { get; set; }
    public double Confidence { get; set; }
    public int Y_min { get; set; }
    public int X_min { get; set; }
    public int Y_max { get; set; }
    public int X_max { get; set; }
    public Rectangle ObjectRectangle { get; set; }
    public bool InMotion { get; set; }
    public Guid ID { get; set; }

    public ImageObject(ImageObject src)
    {
      if (src != null)
      {
        Label = src.Label;
        Success = src.Success;
        Confidence = src.Confidence;
        Y_max = src.Y_max;
        Y_min = src.Y_min;
        X_max = src.X_max;
        X_min = src.Y_min;
        ObjectRectangle = src.ObjectRectangle;
        InMotion = src.InMotion;
        ID = src.ID;
      }
    }
  }

}
