using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
using System.Data.Common;


namespace OnGuardCore
{
  public partial class CleanupDialog : Form
  {
    readonly string _path;
    readonly string _prefix;
    readonly CameraCollection _allCameras;
    public List<FileInfo> ExpiredFiles { get; set; }
    public bool ExcludeMotion { get; set; }

    public CleanupDialog(CameraCollection theCams, string path, string prefix)
    {
      _allCameras = theCams;
      _path = path;
      _prefix = prefix;
      InitializeComponent();
    }


    private void CleanupFiles(bool all)
    {
      // possibly notify the UI via event, maybe ask permission
      TimeSpan span = TimeSpan.FromDays((int)DaysNumeric.Value) + TimeSpan.FromHours((int)HoursNumeric.Value);

      using (WaitCursor _ = new WaitCursor())
      {
        if (all)
        {
          ExpiredFiles = new List<FileInfo>();
          foreach (var cam in _allCameras.CameraDictionary.Values)
          {
            DirectoryInfo dir = new DirectoryInfo(cam.CameraPath);
            List<FileInfo> expiredForCamera = dir.EnumerateFiles(cam.CameraPrefix + "*.jpg", SearchOption.TopDirectoryOnly)
                .Where(fi => fi.CreationTime + span < DateTime.Now).ToList();

            if (null != expiredForCamera)
            {
              ExpiredFiles.AddRange(expiredForCamera);
            }
          }
        }
        else
        {
          DirectoryInfo dir = new DirectoryInfo(_path);
          ExpiredFiles = dir.EnumerateFiles(_prefix + "*.jpg", SearchOption.TopDirectoryOnly)
              .Where(fi => fi.CreationTime + span < DateTime.Now).ToList();
        }
      }

      if (MessageBox.Show(this, "You are about to delete: " + ExpiredFiles.Count.ToString() + " files - Proceed? The picture deletion will occur in the background.", "Delete Old Pictures?", MessageBoxButtons.YesNo) == DialogResult.Yes)
      {
        DialogResult = DialogResult.Yes;
      }
      else
      {
        DialogResult = DialogResult.No;
      }
    }

    private void OKButton_Click(object sender, EventArgs e)
    {
      ExcludeMotion = DoNotDeleteMotionCheckbox.Checked;
      CleanupFiles(AllCamerasCheckbox.Checked);
      DialogResult = DialogResult.OK;
      this.Close();
    }

    private void CancelButton_Click(object sender, EventArgs e)
    {
      DialogResult = DialogResult.Cancel;
      this.Close();
    }

  }
}
