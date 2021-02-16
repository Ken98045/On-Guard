using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace OnGuardCore
{
  public partial class InterestingItemsDialog : Form
  {
    public InterestingItemsDialog(AnalysisResult analysisResult)
    {
      InitializeComponent();

      foreach (var interest in analysisResult.InterestingObjects)
      {
        ListViewItem item = new ListViewItem
        {
          Text = interest.Area.AOIName
        };
        item.SubItems.Add(interest.Area.AOIType.ToString());
        item.SubItems.Add(interest.FoundObject.Label);
        item.SubItems.Add(interest.FoundObject.Confidence.ToString());
        item.SubItems.Add(interest.Overlap.ToString());
        item.SubItems.Add(interest.FoundObject.ObjectRectangle.Width.ToString());
        item.SubItems.Add(interest.FoundObject.ObjectRectangle.Height.ToString());

        interestingListView.Items.Add(item);

      }

      foreach (string item in analysisResult.FailureReasons)
      {
        failuresList.Items.Add(item);
      }


    }

    private void DoneButton_Click(object sender, EventArgs e)
    {
      DialogResult = DialogResult.OK;
    }

   
  }
}
