
using OnGuardCore.Src.
  Properties;
using System;
using System.Drawing;
using System.Windows.Forms;


namespace OnGuardCore
{


  /// <summary>
  /// A dialog for creating and AreaOfInterest
  /// </summary>
  public partial class CreateAOI : Form
  {
    public AreaOfInterest Area { get; set; }
    public int OriginalXResolution { get; set; }
    public int OriginalYResolution { get; set; }

    public bool DeleteItem { get; set; }


    public CreateAOI(GridDefinition areaDefine) // The area on the actual image, not the display image
    {
      InitializeComponent();
      Area = new AreaOfInterest(areaDefine);
      doorButton.Checked = true;


      if (!Storage.Instance.GetGlobalBool("EmailSetup"))
      {
        MessageBox.Show("In order to set Areas of Interest you must first set your email contact information.  This is a one time only requirement.");
        using OutgoingEmailDialog dlg = new ();
        dlg.ShowDialog();
      }

    }

    public CreateAOI(AreaOfInterest area) // The area on the actual image, not the display image
    {
      InitializeComponent();
      Area = area;

      if (area != null)
      {
        aoiNameText.Text = area.AOIName;

        switch (area.AOIType)
        {
          case AOIType.Door:
            doorButton.Checked = true;
            break;

          case AOIType.PeopleWalking:
            peopleWalkingButton.Checked = true;
            break;

          case AOIType.FacialRecognition:
            facialButton.Checked = true;
            break;

          case AOIType.GarageDoor:
            garageButton.Checked = true;
            break;

          case AOIType.Driveway:
            drivewayButton.Checked = true;
            break;

          case AOIType.IgnoreObjects:
            ignoreButton.Checked = true;
            break;
        }


        if (null != area.SearchCriteria)
        {
          foreach (ObjectCharacteristics obj in area.SearchCriteria)
          {
            ListViewItem item = new (new string[]
              { obj.ObjectType.ToString(),
                obj.Confidence.ToString(),
                obj.MinPercentOverlap.ToString(),
                obj.MinimumXSize.ToString(),
                obj.MinimumYSize.ToString(),
                obj.TimeFrame.ToString() });

            ObjectsListView.Items.Add(item);

            item.Tag = obj;
          }
        }
      }
    }

    private bool SaveAreaData()
    {
      bool result = true;
      if (string.IsNullOrEmpty(aoiNameText.Text))
      {
        MessageBox.Show("You must provide a name for this area!");
        result = false;
      }
      else
      {

        Area.AOIName = aoiNameText.Text;

        // Set the area type
        if (doorButton.Checked)
        {
          Area.AOIType = AOIType.Door;
        }
        else if (garageButton.Checked)
        {
          Area.AOIType = AOIType.GarageDoor;
        }
        else if (drivewayButton.Checked)
        {
          Area.AOIType = AOIType.Driveway;
        }
        else if (peopleWalkingButton.Checked)
        {
          Area.AOIType = AOIType.PeopleWalking;
        }
        else if (facialButton.Checked)
        {
          Area.AOIType = AOIType.FacialRecognition;
        }
        else if (ignoreButton.Checked)
        {
          Area.AOIType = AOIType.IgnoreObjects;
        }


        if (Area.SearchCriteria != null)
        {
          Area.SearchCriteria.Clear();
        }

        foreach (ListViewItem item in ObjectsListView.Items)
        {
          Area.SearchCriteria.Add((ObjectCharacteristics)item.Tag);
        }

        Storage.Instance.SaveArea(Area);

      }

      return result;
    }

    private void OKButton_Click(object sender, EventArgs e)
    {
      if (SaveAreaData())
      {
        DialogResult = DialogResult.OK;
        Close();
      }
      else
      {
        DialogResult = DialogResult.None;
      }
    }

    private void CancelButton_Click(object sender, EventArgs e)
    {
      DialogResult = DialogResult.Cancel;
      Close();
    }

    private void DeleteAOIButton_Click(object sender, EventArgs e)
    {
      DeleteItem = true;
      Close();
    }

    private void NotificationsButton_Click(object sender, EventArgs e)
    {
      using NotificationOptionsDialog dlg = new (Area);
      dlg.ShowDialog(this);
      DialogResult = DialogResult.None;
    }

    private void AreaAdjustButton_Click(object sender, EventArgs e)
    {
      if (MessageBox.Show(this, "Adjusting an area size/shape automatically saves any changes.  Proceed?", "Adjusting Area Size/Shape", MessageBoxButtons.YesNo) == DialogResult.Yes)
      {
        if (SaveAreaData())
        {
          DialogResult = DialogResult.Yes;
          Close();
        }
        else
        {
          DialogResult = DialogResult.None;
        }
      }
      else
      {
        DialogResult = DialogResult.None;
      }
    }


    private void AddButton_Click(object sender, EventArgs e)
    {
      if (facialButton.Checked)
      {
        using FacialDefinitionDialog dlg = new ();
        DialogResult result = dlg.ShowDialog();
        if (result == DialogResult.OK)
        {
          ListViewItem item = new (new string[] { dlg.ObjectType, dlg.Confidence.ToString(), dlg.Overlap.ToString(), dlg.MinX.ToString(), dlg.MinY.ToString() });
          item = ObjectsListView.Items.Add(item);
          ObjectCharacteristics objChar = new ();
          objChar.ObjectType = dlg.ObjectType;
          objChar.Confidence = dlg.Confidence;
          objChar.MinPercentOverlap = dlg.Overlap;
          objChar.MinimumXSize = dlg.MinX;
          objChar.MinimumYSize = dlg.MinY;
          objChar.Faces = dlg.Faces;

          item.Tag = objChar;
        }
      }
      else
      {
        using ObjectDefinitionDialog dlg = new();
        DialogResult result = dlg.ShowDialog();
        if (result == DialogResult.OK)
        {
          ListViewItem item = new (new string[] { dlg.ObjectType, dlg.Confidence.ToString(), dlg.Overlap.ToString(), dlg.MinX.ToString(), dlg.MinY.ToString() });
          item = ObjectsListView.Items.Add(item);
          ObjectCharacteristics objChar = new();
          objChar.ObjectType = dlg.ObjectType;
          objChar.Confidence = dlg.Confidence;
          objChar.MinPercentOverlap = dlg.Overlap;
          objChar.MinimumXSize = dlg.MinX;
          objChar.MinimumYSize = dlg.MinY;

          item.Tag = objChar;
        }
      }
    }

    // Editing ObjectCharacteristics
    private void ObjectsListView_ItemActivate(object sender, EventArgs e)
    {
      ListViewItem item = ObjectsListView.SelectedItems[0];

      if (facialButton.Checked)
      {
        ObjectCharacteristics objChar = (ObjectCharacteristics)item.Tag;
        using FacialDefinitionDialog dlg = new (objChar);
        DialogResult result = dlg.ShowDialog();
        if (result == DialogResult.OK)
        {
          objChar.ObjectType = dlg.ObjectType;
          objChar.Confidence = dlg.Confidence;
          objChar.MinPercentOverlap = dlg.Overlap;
          objChar.MinimumXSize = dlg.MinX;
          objChar.MinimumYSize = dlg.MinY;
          objChar.Faces = dlg.Faces;
          item.SubItems[0].Text = dlg.ObjectType;
          item.SubItems[1].Text = dlg.Confidence.ToString();
          item.SubItems[2].Text = dlg.Overlap.ToString();
          item.SubItems[3].Text = dlg.MinX.ToString();
          item.SubItems[4].Text = dlg.MinY.ToString();

          item.Tag = objChar;
        }
      }
      else
      {

        ObjectCharacteristics objChar = (ObjectCharacteristics)item.Tag;
        using ObjectDefinitionDialog dlg = new (objChar);
        DialogResult result = dlg.ShowDialog();
        if (result == DialogResult.OK)
        {
          objChar.ObjectType = dlg.ObjectType;
          objChar.Confidence = dlg.Confidence;
          objChar.MinPercentOverlap = dlg.Overlap;
          objChar.MinimumXSize = dlg.MinX;
          objChar.MinimumYSize = dlg.MinY;
          item.SubItems[0].Text = dlg.ObjectType;
          item.SubItems[1].Text = dlg.Confidence.ToString();
          item.SubItems[2].Text = dlg.Overlap.ToString();
          item.SubItems[3].Text = dlg.MinX.ToString();
          item.SubItems[4].Text = dlg.MinY.ToString();
        }
      }

    }

    private void RemoveButton_Click(object sender, EventArgs e)
    {
      if (ObjectsListView.SelectedItems.Count > 0)
      {
        int index = ObjectsListView.SelectedIndices[0];
        AddButton.Focus();
        ObjectsListView.Items.RemoveAt(index);
      }
    }

    private void OnObjectSelectionChanged(object sender, EventArgs e)
    {
      if (ObjectsListView.SelectedIndices.Count > 0)
      {
        EditButton.Enabled = true;
        RemoveButton.Enabled = true;
      }
      else
      {
        EditButton.Enabled = false;
        RemoveButton.Enabled = false;
      }
    }

    private void EditButton_Click(object sender, EventArgs e)
    {
      ObjectsListView_ItemActivate(null, null);
    }
  }
}

