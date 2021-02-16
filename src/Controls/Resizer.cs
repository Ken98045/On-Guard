using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace OnGuardCore
{
  internal class ControlMoverOrResizer
  {
    private static bool _moving;
    private static Point _cursorStartPoint;
    private static bool _moveIsInterNal;
    private static bool _resizing;
    private static Size _currentControlStartSize;
    internal static bool MouseIsInLeftEdge { get; set; }
    internal static bool MouseIsInRightEdge { get; set; }
    internal static bool MouseIsInTopEdge { get; set; }
    internal static bool MouseIsInBottomEdge { get; set; }

    internal const int EdgeMargin = 6;

    internal enum MoveOrResize
    {
      Move,
      Resize,
      MoveAndResize,
      None
    }

    internal static MoveOrResize WorkType { get; set; }


    internal static void Start(Control control)
    {
      _moving = false;
      _resizing = false;
      _moveIsInterNal = false;
      _cursorStartPoint = Point.Empty;
      MouseIsInLeftEdge = false;
      MouseIsInLeftEdge = false;
      MouseIsInRightEdge = false;
      MouseIsInTopEdge = false;
      MouseIsInBottomEdge = false;
      WorkType = MoveOrResize.MoveAndResize;
      control.MouseDown += (sender, e) => StartMovingOrResizing(control, e);
      control.MouseUp += (sender, e) => StopDragOrResizing(control);
      control.MouseMove += (sender, e) => MoveControl(control, e);
    }

    internal static void Stop(Control control)
    {
      control.MouseDown -= (sender, e) => StartMovingOrResizing(control, e);
      control.MouseUp -= (sender, e) => StopDragOrResizing(control);
      control.MouseMove -= (sender, e) => MoveControl(control, e);
      WorkType = MoveOrResize.None;
      UpdateMouseCursor(control);
    }

    private static void UpdateMouseEdgeProperties(Control control, Point mouseLocationInControl)
    {
      if (WorkType == MoveOrResize.Move)
      {
        return;
      }
      MouseIsInLeftEdge = Math.Abs(mouseLocationInControl.X) <= EdgeMargin;
      MouseIsInRightEdge = Math.Abs(mouseLocationInControl.X - control.Width) <= EdgeMargin;
      MouseIsInTopEdge = Math.Abs(mouseLocationInControl.Y) <= EdgeMargin;
      MouseIsInBottomEdge = Math.Abs(mouseLocationInControl.Y - control.Height) <= EdgeMargin;
    }

    private static void UpdateMouseCursor(Control control)
    {
      if (WorkType == MoveOrResize.Move)
      {
        return;
      }
      if (MouseIsInLeftEdge)
      {
        if (MouseIsInTopEdge)
        {
          control.Cursor = Cursors.SizeNWSE;
        }
        else if (MouseIsInBottomEdge)
        {
          control.Cursor = Cursors.SizeNESW;
        }
        else
        {
          control.Cursor = Cursors.SizeWE;
        }
      }
      else if (MouseIsInRightEdge)
      {
        if (MouseIsInTopEdge)
        {
          control.Cursor = Cursors.SizeNESW;
        }
        else if (MouseIsInBottomEdge)
        {
          control.Cursor = Cursors.SizeNWSE;
        }
        else
        {
          control.Cursor = Cursors.SizeWE;
        }
      }
      else if (MouseIsInTopEdge || MouseIsInBottomEdge)
      {
        control.Cursor = Cursors.SizeNS;
      }
      else
      {
        control.Cursor = Cursors.Default;
      }
    }

    private static void StartMovingOrResizing(Control control, MouseEventArgs e)
    {
      if (_moving || _resizing)
      {
        return;
      }
      if (WorkType != MoveOrResize.Move &&
          (MouseIsInRightEdge || MouseIsInLeftEdge || MouseIsInTopEdge || MouseIsInBottomEdge))
      {
        _resizing = true;
        _currentControlStartSize = control.Size;
      }
      else if (WorkType != MoveOrResize.Resize)
      {
        _moving = true;
        control.Cursor = Cursors.Hand;
      }
      _cursorStartPoint = new Point(e.X, e.Y);
      control.Capture = true;
    }

    private static void MoveControl(Control control, MouseEventArgs e)
    {
      if (!_resizing && !_moving)
      {
        UpdateMouseEdgeProperties(control, new Point(e.X, e.Y));
        UpdateMouseCursor(control);
      }
      if (_resizing)
      {
        if (MouseIsInLeftEdge)
        {
          if (MouseIsInTopEdge)
          {
            control.Width -= (e.X - _cursorStartPoint.X);
            control.Left += (e.X - _cursorStartPoint.X);
            control.Height -= (e.Y - _cursorStartPoint.Y);
            control.Top += (e.Y - _cursorStartPoint.Y);
          }
          else if (MouseIsInBottomEdge)
          {
            control.Width -= (e.X - _cursorStartPoint.X);
            control.Left += (e.X - _cursorStartPoint.X);
            control.Height = (e.Y - _cursorStartPoint.Y) + _currentControlStartSize.Height;
          }
          else
          {
            control.Width -= (e.X - _cursorStartPoint.X);
            control.Left += (e.X - _cursorStartPoint.X);
          }
        }
        else if (MouseIsInRightEdge)
        {
          if (MouseIsInTopEdge)
          {
            control.Width = (e.X - _cursorStartPoint.X) + _currentControlStartSize.Width;
            control.Height -= (e.Y - _cursorStartPoint.Y);
            control.Top += (e.Y - _cursorStartPoint.Y);

          }
          else if (MouseIsInBottomEdge)
          {
            control.Width = (e.X - _cursorStartPoint.X) + _currentControlStartSize.Width;
            control.Height = (e.Y - _cursorStartPoint.Y) + _currentControlStartSize.Height;
          }
          else
          {
            control.Width = (e.X - _cursorStartPoint.X) + _currentControlStartSize.Width;
          }
        }
        else if (MouseIsInTopEdge)
        {
          control.Height -= (e.Y - _cursorStartPoint.Y);
          control.Top += (e.Y - _cursorStartPoint.Y);
        }
        else if (MouseIsInBottomEdge)
        {
          control.Height = (e.Y - _cursorStartPoint.Y) + _currentControlStartSize.Height;
        }
        else
        {
          StopDragOrResizing(control);
        }
      }
      else if (_moving)
      {
        _moveIsInterNal = !_moveIsInterNal;
        if (!_moveIsInterNal)
        {
          int x = (e.X - _cursorStartPoint.X) + control.Left;
          int y = (e.Y - _cursorStartPoint.Y) + control.Top;
          control.Location = new Point(x, y);
        }
      }
    }

    private static void StopDragOrResizing(Control control)
    {
      _resizing = false;
      _moving = false;
      control.Capture = false;
      UpdateMouseCursor(control);
    }
 
  }
}