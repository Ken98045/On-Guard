using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace SAAI
{

  // We use this class because we need a reference to the X and Y scale values.
  // The Form1 class needs these values, and this is the easiest place to update them.
  // This is pending a re-design that might make more sense.
  public class Scale
  {
    public double ScaleX { get; set; }
    public double ScaleY { get; set; }
  }

  class ScaledPictureBox : PictureBox
  {
    Bitmap _sourceBitmap;
    Scale _scale;

    ScaledPictureBox(Scale scale)
    {
      _scale = scale;
    }

    void UpdateSource(Bitmap sourceBitmap)
    {
      _sourceBitmap = sourceBitmap;
      _scale.ScaleX = Image.Width / _sourceBitmap.Width;
      _scale.ScaleX = Image.Height / _sourceBitmap.Height;
      this.Image = ResizeImage(_sourceBitmap);
      this.Invalidate();
    }

    protected override void OnPaint(PaintEventArgs e)
    {
      Rectangle rect = e.ClipRectangle;
      _scale.ScaleX = rect.Width / _sourceBitmap.Width;    // ??
      _scale.ScaleX = rect.Height / _sourceBitmap.Height;


      // Call the OnPaint method of the base class.  
      base.OnPaint(e);

      // Call methods of the System.Drawing.Graphics object.  
    }

    public Bitmap ResizeImage(Bitmap original)
    {
      Bitmap destImage;
      int width = this.Width;
      int height = this.Height;

      var destRect = new Rectangle(0, 0, width, height);
      destImage = new Bitmap(width, height);
      destImage.SetResolution(width, height);

      using (var graphics = Graphics.FromImage(destImage))
      {
        graphics.CompositingMode = CompositingMode.SourceCopy;
        graphics.CompositingQuality = CompositingQuality.HighQuality;
        graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
        graphics.SmoothingMode = SmoothingMode.HighQuality;
        graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

        using (var wrapMode = new ImageAttributes())
        {
          wrapMode.SetWrapMode(WrapMode.TileFlipXY);
          graphics.DrawImage(original, destRect, 0, 0, original.Width, original.Height, GraphicsUnit.Pixel, wrapMode);
        }

      }

      return destImage;

    }

  }
}
