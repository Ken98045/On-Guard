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
                                      area.AreaRect.X.ToString(),
                                      area.AreaRect.Y.ToString(),
                                      area.AreaRect.Width.ToString(),
                                      area.AreaRect.Height.ToString()
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
      using (CreateAOI dlg = new CreateAOI(area))
      {

        DialogResult result = dlg.ShowDialog();

        if (dlg.DeleteItem)
        {
          _areas.Remove(area.ID);
          areasListView.Items.RemoveAt(areasListView.SelectedIndices[0]);
        }
        else if (result == DialogResult.OK)
        {
          item.Text = dlg.Area.AOIName; // it may have changed.
          item.Tag = dlg.Area;
          area.AreaRect = dlg.Area.AreaRect;
          item.SubItems[1].Text = dlg.Area.AreaRect.X.ToString();
          item.SubItems[2].Text = dlg.Area.AreaRect.Y.ToString();
          item.SubItems[3].Text = dlg.Area.AreaRect.Width.ToString();
          item.SubItems[4].Text = dlg.Area.AreaRect.Height.ToString();

          _areas.UpdateArea(dlg.Area);
          _areas.Save();
        }
        else if (result == DialogResult.Yes)
        {
          // An artificial response indicating we should edit an area of interest
          EditAreaID = dlg.Area.ID;
          _areas.UpdateArea(dlg.Area);
          _areas.Save();
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
