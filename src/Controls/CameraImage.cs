using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace OnGuardCore
{
  public partial class CameraImage : PictureBox
  {
    private object _lock = new object();

    internal int WS_EX_TRANSPARENT = 0x00000020;
    Color _color = Color.FromArgb(80, Color.DarkOrange);

    private List<GridDefinition> _grids;
    public CameraImage()
    {
      InitializeComponent();
    }

    public void SetImage(Bitmap bitmap)
    {
      Bitmap oldBitmap = (Bitmap)Image;  // can't dispose until we have set the new one
      this.Image = new Bitmap(bitmap);
      oldBitmap?.Dispose();
    }

    public List<GridDefinition> GridsSelected
    {
      get
      {
        lock (_lock)
        {
          return _grids;
        }
      }
      set
      {
        lock (_lock)
        {
          _grids = value;
        }
      }
    }


    protected override void OnPaint(PaintEventArgs pe)
    {
      try
      {

        // _semaphore.Wait();
        base.OnPaint(pe);

        if (GridsSelected != null && GridsSelected.Count > 0)
        {
          double xSpan = (double) this.Width / (double)GridsSelected[0].XDim;
          double ySpan = (double) this.Height / (double) GridsSelected[0].YDim;

          using (SolidBrush brush = new SolidBrush(_color))
          {
            foreach (var grid in GridsSelected)
            {
              for (int row = 0; row < grid.YDim; row++)
              {
                for (int col = 0; col < grid.XDim; col++)
                {
                  if (grid.Get(col, row))
                  {
                    pe.Graphics.FillRectangle(brush, (int) Math.Round(col * xSpan), (int) Math.Round(row * ySpan), (int) xSpan + 1, (int) ySpan + 1);
                  }
                }
              }
            }
          }
        }
      }
      finally
      {
        //_semaphore.Release();
      }
    }

  }

}
