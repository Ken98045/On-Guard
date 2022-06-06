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
  public partial class ModelessMessageWindow : Form
  {
    Timer _timer;
    public ModelessMessageWindow(Control parent, string title, string message, bool button)
    {

      _timer = new Timer();
      _timer.Interval = 100;
      _timer.Tick += _timer_Tick;


      InitializeComponent();
      SetLabel(title, message);
      if (button)
      {
        DismissButton.Visible = true;
        DismissButton.Enabled = true;
      }

      _timer.Start();
    }

    private void _timer_Tick(object sender, EventArgs e)
    {
      if (this.WindowState == FormWindowState.Normal)
      {
        this.BringToFront();
        this.Update();
      }
    }


    private void Button_Click(object sender, EventArgs e)
    {
      _timer?.Stop();
      this.Hide();
    }

    public void SetLabel(string title, string message)
    {
      LabelMessage.Text = message;
      this.Text = title;
      var size = TextRenderer.MeasureText(message, LabelMessage.Font);
      if (size.Width > this.ClientRectangle.Width - 10)
      {
        this.Width = size.Width + 12;
        DismissButton.Left = (Width / 2) - DismissButton.Width / 2;
      }

      LabelMessage.Left = this.Width / 2 - size.Width / 2;
      this.Show();
      this.BringToFront();
      this.Update();
    }

    public void Destroy()
    {
      DialogResult = DialogResult.None;
      this.Close();
    }

    private void OnClosed(object sender, FormClosedEventArgs e)
    {
      DialogResult = DialogResult.None;
    }

    private void OnClosing(object sender, FormClosingEventArgs e)
    {
      DialogResult = DialogResult.None;
    }

    private void OnVisibleChanged(object sender, EventArgs e)
    {
      if (this.Visible)
      {
        this.BringToFront();
        _timer?.Start();
      }
      else
      {
        _timer?.Stop();
      }
    }
  }
}
