using System;
using System.Drawing;
using System.Windows.Forms;

namespace SAAI
{

  public class ZoneBox : Panel
  {
    internal int WS_EX_TRANSPARENT = 0x00000020;
    readonly Color _aoiColor = Color.FromArgb(80, Color.DarkOrange);
    readonly Color _focusColor = Color.FromArgb(200, Color.MediumAquamarine);
    Rectangle _focusRect = Rectangle.Empty;
    Point _focusPoint = Point.Empty;

    public Point ZoneFocus
    {
      get 
      {
        return _focusPoint; 
      }
      set
      {
        _focusPoint = value;
        _focusRect = new Rectangle(ZoneFocus.X - 5, ZoneFocus.Y - 5, 10, 10);  
      }
    }

    public ZoneBox() : base()
    {
      InitializeComponent();
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
        if (_focusRect != Rectangle.Empty)
        {
          using (SolidBrush focusBrush = new SolidBrush(_focusColor))
          {
            e.Graphics.FillRectangle(focusBrush, _focusRect);
          }
        }
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

    private void InitializeComponent()
    {
      this.SuspendLayout();
      // 
      // ZoneBox
      // 
      this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnMouseDown);
      this.ResumeLayout(false);

    }

    private void OnMouseDown(object sender, MouseEventArgs e)
    {
      if ((Control.ModifierKeys & Keys.Shift) == Keys.Shift)
      {
        _focusRect = BitmapResolution.ScaleScreenToData(new Rectangle(e.X - 5, e.Y - 5, 10, 10));
        ZoneFocus = e.Location;
      }

      Parent.Invalidate();
      this.Invalidate();
    }

  }
}
