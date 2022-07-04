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
using Microsoft.EntityFrameworkCore;


namespace OnGuardCore
{
  public partial class CleanupDialog : Form
  {
    readonly string _path;
    readonly string _prefix;
    readonly CameraCollection _allCameras;
    readonly CameraData _currentCamera;
    public List<FileInfo> ExpiredFiles { get; set; }
    public bool ExcludeMotion { get; set; }
    public DateTime DeleteTime { get; set; }
    public bool Cancel { get; set; }

    public CleanupDialog(CameraCollection theCams, string path, string prefix)
    {
      _allCameras = theCams;
      _path = path;
      _prefix = prefix;
      InitializeComponent();
    }


    private DialogResult CleanupFiles(bool all)
    {
      DialogResult result = DialogResult.Cancel;

      // possibly notify the UI via event, maybe ask permission
      TimeSpan span = TimeSpan.FromDays((int)DaysNumeric.Value) + TimeSpan.FromHours((int)HoursNumeric.Value);
      DeleteTime = DateTime.Now - span; // for the database query

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

          if (ExcludeMotion)
          {
            using MotionDBContext dbContext = new();
            IList<PictureMotionInfo> motionDBList = null;

            motionDBList = dbContext.MotionInfo.Where(c => c.PictureTime <= DeleteTime).ToList(); // get the list from the database (all cameras)
            var filesToExclude = motionDBList.Join(ExpiredFiles, f => f.FileName, e => e.Name.ToLower(), (aMotion, anExpired) => anExpired).ToList(); // (all cameras) convert from the db list to a FileInfo list for the DB files
            ExpiredFiles = ExpiredFiles.Except(filesToExclude).ToList();  // remove the DB files from those that are expired.
          }
        }
        else
        {
          DirectoryInfo dir = new DirectoryInfo(_path);
          ExpiredFiles = dir.EnumerateFiles(_prefix + "*.jpg", SearchOption.TopDirectoryOnly)
              .Where(fi => fi.CreationTime + span < DateTime.Now).ToList();


          if (ExcludeMotion)
          {
            using MotionDBContext dbContext = new();
            IList<PictureMotionInfo> motionDBList = null;

            motionDBList = dbContext.MotionInfo.Where(c => c.Camera.ToLower() == _prefix.ToLower() && c.PictureTime <= DeleteTime).ToList(); // get the list from the database
            var filesToExclude = motionDBList.Join(ExpiredFiles, f => f.FileName, e => e.Name.ToLower(), (aMotion, anExpired) => anExpired).ToList(); // convert from the db list to a FileInfo list for the DB files
            ExpiredFiles = ExpiredFiles.Except(filesToExclude).ToList();  // remove the DB files from those that are expired.
          }
        }
      }

      if (ExpiredFiles.Count > 0)
      {
        if (MessageBox.Show(this, "You are about to delete: " + ExpiredFiles.Count.ToString() + " files - Proceed? The picture deletion will occur in the background.", "Delete Old Pictures?", MessageBoxButtons.YesNo) == DialogResult.Yes)
        {
          result = DialogResult.OK;
        }
        else
        {
          Cancel = true;
          result = DialogResult.Cancel;
        }
      }
      else
      {
        MessageBox.Show(this, "There are currently no qualifying pictures to delete!", "Delete Old Pictures?");
        result = DialogResult.Cancel;
      }

      return result;
    }

    private void OKButton_Click(object sender, EventArgs e)
    {
      ExcludeMotion = DoNotDeleteMotionCheckbox.Checked;
      DialogResult = CleanupFiles(AllCamerasCheckbox.Checked);
      this.Close();
    }

    private void CancelButton_Click(object sender, EventArgs e)
    {
      DialogResult = DialogResult.Cancel;
      this.Close();
    }

  }
}
