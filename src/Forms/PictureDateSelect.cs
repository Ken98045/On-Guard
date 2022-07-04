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
  public partial class PictureDateSelect : Form
  {
    public DateTime SearchDateTime { get; set; }
    public bool KeepDateTime { get; set; }
    DateTime _currentPicture;
    TimeOnly _timeOnly;

    public PictureDateSelect(DateTime dateTime, DateTime currentPicture)
    {
      InitializeComponent();

      _currentPicture = currentPicture;
      if (dateTime != DateTime.MinValue)
      {
        SearchDateTime = dateTime;
      }
      else
      {
        SearchDateTime = DateTime.Now;
      }

      PictureDate.Value = SearchDateTime.Date;
      PictureTime.Value = SearchDateTime;

    }

    private void CancelButton_Click(object sender, EventArgs e)
    {
      DialogResult = DialogResult.Cancel;
      this.Close();
    }

    private void OKButton_Click(object sender, EventArgs e)
    {
      SearchDateTime = new DateTime(PictureDate.Value.Year, PictureDate.Value.Month, PictureDate.Value.Day, PictureTime.Value.Hour, PictureTime.Value.Minute, PictureTime.Value.Second); ;
      KeepDateTime = KeepDateCheckbox.Checked;
      DialogResult = DialogResult.OK;
      this.Close();
    }

    private void CurrentPictureButton_Click(object sender, EventArgs e)
    {
      PictureDate.Value = _currentPicture.Date;
     PictureTime.Value = _currentPicture.ToLocalTime();
    }
  }
}
