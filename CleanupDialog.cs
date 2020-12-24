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

namespace SAAI
{
  public partial class CleanupDialog : Form
  {
    string _path;
    string _prefix;

    public CleanupDialog(string path, string prefix)
    {
      _path = path;
      _prefix = prefix;
      InitializeComponent();
    }


    private void CleanupFiles()
    {
      // possibly notify the UI via event, maybe ask permission
      List<FileInfo> expiredFiles = null;

      TimeSpan span = TimeSpan.FromDays((int)DaysNumeric.Value) + TimeSpan.FromHours((int)HoursNumeric.Value);

      using (WaitCursor _ = new WaitCursor())
      {
        DirectoryInfo dir = new DirectoryInfo(_path);
        expiredFiles = dir.EnumerateFiles(_prefix + "*.jpg", SearchOption.TopDirectoryOnly)
            .Where(fi => fi.CreationTime + span < DateTime.Now).ToList();
      }

      if (MessageBox.Show(this, "You are about to delete: " + expiredFiles.Count.ToString() + " files - Proceed?", "Delete Old Pictures?", MessageBoxButtons.YesNo) == DialogResult.Yes)
      {
        using (WaitCursor _ = new WaitCursor())
        {
          foreach (var info in expiredFiles)
          {
            try
            {
              File.Delete(info.FullName);
            }
            catch (UnauthorizedAccessException ex)
            {
              MessageBox.Show("Unable to delete file: " + info.FullName + Environment.NewLine + "This is probably due to your anti-virus software." +
                Environment.NewLine + "Exiting Cleanup!");
              break;
            }
          }
        }
      }
    }

    private void OKButton_Click(object sender, EventArgs e)
    {
      CleanupFiles();
      DialogResult = DialogResult.Cancel;
      this.Close();
    }

    private void CancelButton_Click(object sender, EventArgs e)
    {
      DialogResult = DialogResult.Cancel;
      this.Close();
    }
  }
}
