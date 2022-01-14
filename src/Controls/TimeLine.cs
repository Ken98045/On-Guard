using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnGuardCore
{
  public partial class TimeLine : TrackBar
  {
    public bool Pause { get; set; }
    SortedList<string, PictureInfo> _pictureInfo;
    private bool _moving;
    ToolTip _locationTip = new ToolTip();


    public TimeLine()
    {
      InitializeComponent();
      Pause = true;
      Minimum = 0;
      Value = 0;
    }

    public void Init(SortedList<string, PictureInfo> pictureInfo)
    {
      _pictureInfo = pictureInfo;

      this.Maximum = pictureInfo.Count  - 1;
      this.SmallChange = this.Maximum / 100;
      if (this.SmallChange < 1)
      {
        this.SmallChange = 1;
      }

      this.LargeChange = this.Maximum / 20;
      if (this.LargeChange < 5)
      {
        this.LargeChange = 5;
      }
    }

    public void SetCurrentPosition(int position)
    {
      if (position < _pictureInfo.Count && position >= 0)
      {
        if (!_moving)
        {
          Dbg.Trace("timeline setting to: " + position.ToString());
          Value = position;
        }
      }
    }

    protected override void OnMouseMove(MouseEventArgs e)
    {
      base.OnMouseMove(e);
      if (_moving && Value < _pictureInfo.Count)
      {
        ShowLocationToolTip(_pictureInfo.Values[Value].FileTime.ToString(), e.Location);
      }
    }

    private void ShowLocationToolTip(string str, Point point)
    {
      if (!string.IsNullOrEmpty(str) && _pictureInfo.Count > 0)
      {
        Size strSize = TextRenderer.MeasureText(str, System.Drawing.SystemFonts.SmallCaptionFont);
        _locationTip.Show(str, this, point.X - (strSize.Width + 15), point.Y - (15 + strSize.Height / 2));
      }

    }

    protected override void OnMouseDown(MouseEventArgs e)
    {
      _moving = true;
      base.OnMouseDown(e);
    }

    protected override void OnMouseUp(MouseEventArgs e)
    {
      _moving = false;
      Pause = false;
      base.OnMouseUp(e);
      OnValueChanged(e);
      Pause = true;
      _locationTip.Hide(this);
    }


    protected override void OnKeyDown(KeyEventArgs e)
    {
      if (this.Focused)
      {
        e.Handled = true;
        base.OnKeyDown(e);
        _moving = true;

        // TODO: we shouldn't have to do this manually, but for now
        if (e.KeyCode == Keys.Up)
        {
          int diff = (_pictureInfo.Count - Value) - 1;  // how many are available to go up (usually no problem, but...)
          if (diff > SmallChange)
          {
            Value += SmallChange;
          }
          else
          {
            Value += diff;
          }
        }
        else if (e.KeyCode == Keys.Down)
        {
          int newValue = Value - SmallChange;
          if (newValue < 0)
          {
            Value = 0;
          }
          else
          {
            Value = newValue;
          }
        }

        Pause = false;
        Dbg.Write("Key Down: " + Value.ToString());
        OnValueChanged(null);
        Pause = true;
      }
    }

    protected override void OnKeyUp(KeyEventArgs e)
    {
      if (_moving)
      {
        base.OnKeyUp(e);
        _moving = false;
      }
    }


    protected override void OnValueChanged(EventArgs e)
    {
      if (!Pause)
      {
        base.OnValueChanged(e);
      }
    }

    protected override void OnPaint(PaintEventArgs pe)
    {
      base.OnPaint(pe);
    }
  }
}
