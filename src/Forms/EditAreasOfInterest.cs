using System;
using System.Windows.Forms;


namespace OnGuardCore
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
        ListViewItem item = new ListViewItem(area.AOIName)
        {
          Tag = area
        };

        areasListView.Items.Add(item);
      }
    }

    private void AreasListView_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (areasListView.SelectedItems.Count > 0)
      {
        DeleteButton.Enabled = true;
        EditButton.Enabled = true;
      }
      else
      {
        DeleteButton.Enabled = false;
        EditButton.Enabled = false;
      }
    }

    private void OnActivate(object sender, EventArgs e)
    {
      ListViewItem item = areasListView.SelectedItems[0];
      AreaOfInterest area = (AreaOfInterest)item.Tag;
      AreaOfInterest adjustedArea = new AreaOfInterest(area);

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

    private void DeleteButton_Click(object sender, EventArgs e)
    {
      if (areasListView.SelectedItems.Count > 0)
      {
        int index = areasListView.SelectedIndices[0];
        ListViewItem item = areasListView.Items[index];
        AreaOfInterest area = (AreaOfInterest)item.Tag;
        _areas.Remove(area.ID);
        area.Dispose();
        doneButton.Focus();
        areasListView.Items.RemoveAt(index);

        if (areasListView.SelectedItems.Count > 0)
        {
          areasListView.Items[0].Selected = true;
        }
        else
        {
          DeleteButton.Enabled = false; // redundent, but
          EditButton.Enabled = false;
        }
      }
    }

    private void EditButton_Click(object sender, EventArgs e)
    {
      OnActivate(null, null);
    }
  }
}
