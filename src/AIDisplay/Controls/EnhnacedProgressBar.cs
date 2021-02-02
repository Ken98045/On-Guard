using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SAAI.Controls
{
  public partial class EnhnacedProgressBar : UserControl
  {
    SolidBrush eraseBrush;
    public EnhnacedProgressBar()
    {
      InitializeComponent();
      eraseBrush = new SolidBrush(this.BackColor);
      
    }

    public void SetContents(Color color, double percent, string text)
    {
      using (Graphics g = this.CreateGraphics())
      {
        Rectangle clientRect = this.ClientRectangle;
        g.FillRectangle(eraseBrush, clientRect);

        using (SolidBrush barBrush = new SolidBrush(color))
        {
          Rectangle barRect = clientRect;
          barRect.Width = (int)((double)clientRect.Width * percent / 100.0);
          g.FillRectangle(barBrush, barRect);

          g.SmoothingMode = SmoothingMode.AntiAlias;
          g.InterpolationMode = InterpolationMode.HighQualityBicubic;
          g.PixelOffsetMode = PixelOffsetMode.HighQuality;

          using (Font f = new Font("Tahoma", 8, FontStyle.Bold))
          {
            SizeF stringWidth = g.MeasureString(text, f);
            int left = clientRect.Width / 2 - (int) stringWidth.Width / 2;
            Rectangle textRect = clientRect;
            textRect.X = left;
            g.DrawString(text, f, Brushes.Black, textRect);
          }
        }

      }
    }
  }
}
