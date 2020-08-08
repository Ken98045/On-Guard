using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace SAAI
{

  public class SemiTransparentBox : Panel
  {
    internal int WS_EX_TRANSPARENT = 0x00000020;
    readonly Color _aoiColor = Color.FromArgb(80, Color.DarkOrange);
    public SemiTransparentBox() : base()
    {
      this.SetStyle(ControlStyles.Opaque |
                            ControlStyles.ResizeRedraw |
                            ControlStyles.SupportsTransparentBackColor, true);
      this.SetStyle(ControlStyles.OptimizedDoubleBuffer, false);
      this.BorderStyle = BorderStyle.None;

      BringToFront();
    }

    protected override CreateParams CreateParams
    {
      get
      {
        CreateParams parameters = base.CreateParams;
        parameters.ExStyle |= WS_EX_TRANSPARENT;
        return parameters;
      }
    }

    protected override void OnLocationChanged(EventArgs e)
    {
      Parent.Invalidate();
      Invalidate();
    }

    protected override void OnPaint(PaintEventArgs e)
    {
      //base.OnPaint(e);
      e.Graphics.SetClip(new Rectangle(0, 0, Width, Height));
      using (SolidBrush brush = new SolidBrush(_aoiColor))
      {
        e.Graphics.FillRectangle(brush, 0, 0, this.Width, this.Height);
      }
    }

    protected override void OnPaintBackground(PaintEventArgs e)
    {
      e.Graphics.SetClip(new Rectangle(0, 0, Width, Height));
      using (SolidBrush brush = new SolidBrush(_aoiColor))
      {
        e.Graphics.FillRectangle(brush, 0, 0, this.Width, this.Height);
      }
    }

  }
}
