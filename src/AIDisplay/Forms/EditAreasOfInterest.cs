using System;
using System.Windows.Forms;


namespace SAAI
{

/// <summary>
/// This dialog just lists the available areas of interest and
/// allows you to launch another dialog to modify/remove it.
/// </summary>
  public partial class EditAreasOfInterest : Form
  {
    readonly AreasOfInterestCollection _areas;
    public Guid EditAreaID { get; set; }
    public EditAreasOfInterest(AreasOfInterestCollection areas)
    {
      _areas = areas;

      InitializeComponent();

      foreach (var area in _areas)
      {
        string[] row = new string[5] {area.AOIName,
                                      area.GetRect().X.ToString(),
                                      area.GetRect().Y.ToString(),
                                      area.GetRect().Width.ToString(),
                                      area.GetRect().Height.ToString()
                                      };

        ListViewItem item = new ListViewItem(row)
        {
          Tag = area
        };

        areasListView.Items.Add(item);
      }
    }

    private void AreasListView_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    private void OnActivate(object sender, EventArgs e)
    {
      ListViewItem item = areasListView.SelectedItems[0];
      AreaOfInterest area = (AreaOfInterest)item.Tag;
      AreaOfInterest adjustedArea = new AreaOfInterest(area);

      if (area.OriginalXResolution != BitmapResolution.XResolution || area.OriginalYResolution != BitmapResolution.YResolution)
      {
        // OK, we are editing an area at a resolution we did not create it at.  
        // Therefore, we need to adjust the area so we can edit it.

        adjustedArea.AreaRect = area.GetRect();
        adjustedArea.OriginalXResolution = BitmapResolution.XResolution;
        adjustedArea.OriginalYResolution = BitmapResolution.YResolution;
      }

      using (CreateAOI dlg = new CreateAOI(adjustedArea))
      {

        DialogResult result = dlg.ShowDialog();

        if (dlg.DeleteItem)
        {
          _areas.Remove(area.ID);
          areasListView.Items.RemoveAt(areasListView.SelectedIndices[0]);
          area.Dispose();         // the original area
          adjustedArea.Dispose(); // the copy
        }
        else if (result == DialogResult.OK)
        {
          
          item.Text = adjustedArea.AOIName; // it may have changed.
          item.Tag = adjustedArea;
          area.AreaRect = adjustedArea.GetRect();
          item.SubItems[1].Text = adjustedArea.GetRect().X.ToString();
          item.SubItems[2].Text = adjustedArea.GetRect().Y.ToString();
          item.SubItems[3].Text = adjustedArea.GetRect().Width.ToString();
          item.SubItems[4].Text = adjustedArea.GetRect().Height.ToString();

          _areas.UpdateArea(adjustedArea);
          area.Dispose();   // the original, unmodified one
          _areas.Save();
        }
        else if (result == DialogResult.Yes)
        {
          // An artificial response indicating we should edit an area of interest
          EditAreaID = adjustedArea.ID;
          _areas.UpdateArea(adjustedArea);
          _areas.Save();
          area.Dispose();     // the original unmodified one
          DialogResult = DialogResult.Yes;
          Close();

        }
      }
    }

    private void DoneButton_Click(object sender, EventArgs e)
    {
      DialogResult = DialogResult.OK;
      Close();
    }
  }
}
