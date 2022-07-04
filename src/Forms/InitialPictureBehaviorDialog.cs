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
  public partial class InitialPictureBehaviorDialog : Form
  {
    public PictureDateBehavior Behavior { get; set; }

    public InitialPictureBehaviorDialog(PictureDateBehavior behavior, DateTime searchDate)
    {
      Behavior = behavior;
      InitializeComponent();

      switch (Behavior)
      {
        case PictureDateBehavior.Picture1:
          radioButtonPicture1.Checked = true;
          break;

        case PictureDateBehavior.SearchDate:
          radioButtonEnteredDateTime.Checked = true;
          break;

        case PictureDateBehavior.LastViewed:
          radioButtonLastViewed.Checked = true;
          break;
      }

      if (searchDate == DateTime.MinValue)
      {
        radioButtonEnteredDateTime.Enabled = false; // You can't select this if there isn't one.
      }
    }


    private void ButtonCancel_Click(object sender, EventArgs e)
    {
      DialogResult = DialogResult.Cancel;
      this.Close();
    }

    private void buttonOK_Click(object sender, EventArgs e)
    {
      DialogResult = DialogResult.OK;

      if (radioButtonPicture1.Checked)
      {
        Behavior = PictureDateBehavior.Picture1;
      }
      else if (radioButtonEnteredDateTime.Checked)
      {
        Behavior = PictureDateBehavior.SearchDate;
      }
      else
      {
        Behavior = PictureDateBehavior.LastViewed;
      }

      this.Close();
    }
  }

  public enum PictureDateBehavior
  {
    Picture1,
    SearchDate,
    LastViewed
  }
}
