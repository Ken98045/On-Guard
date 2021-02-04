
using SAAI.Properties;
using System;
using System.Drawing;
using System.Windows.Forms;


namespace SAAI
{


  /// <summary>
  /// A dialog for creating and AreaOfInterest
  /// </summary>
  public partial class CreateAOI : Form
  {
    public AreaOfInterest Area { get; set; }
    Rectangle _rectangle;
    public int OriginalXResolution { get; set; }
    public int OriginalYResolution { get; set; }

    public bool DeleteItem { get; set; }


    public CreateAOI(Rectangle imageRect, Point zoneFocus, int xResolution, int yResolution) // The area on the actual image, not the display image
    {
      InitializeComponent();
      Area = new AreaOfInterest
      {
        ZoneFocus = zoneFocus,
        OriginalXResolution = xResolution,
        OriginalYResolution = yResolution,
      };

      _rectangle = imageRect;
      doorButton.Checked = true;
      anyActivityButton.Checked = true;

      if (imageRect.X < -5000)
      {
        imageRect.X = -5000;
      }

      if (imageRect.Y < -5000)
      {
        imageRect.Y = -5000;
      }

      xNumeric.Value = imageRect.X;
      yNumeric.Value = imageRect.Y;
      widthNumeric.Value = imageRect.Width;
      heighNumeric.Value = imageRect.Height;
      OriginalXResolution = xResolution;
      OriginalYResolution = yResolution;


      if (!Storage.GetGlobalBool("EmailSetup"))
      {
        MessageBox.Show("In order to set Areas of Interest you must first set your email contact information.  This is a one time only requirement.");
        using (OutgoingEmailDialog dlg = new OutgoingEmailDialog())
        {
          dlg.ShowDialog();
        }
      }

    }

    public CreateAOI(AreaOfInterest area) // The area on the actual image, not the display image
    {
      InitializeComponent();
      Area = area;

      if (area != null)
      {
        _rectangle = area.AreaRect;
        Area.ZoneFocus = area.ZoneFocus;
        Rectangle rect = area.AreaRect;
        doorButton.Checked = true;
        anyActivityButton.Checked = true;
        OriginalXResolution = area.OriginalXResolution;
        OriginalYResolution = area.OriginalYResolution;

        if (rect.X > 5000)
        {
          rect.X = 5000;
        }

        if (rect.Y > 3000)
        {
          rect.Y = 3000;
        }

        if (rect.X < -5000)
        {
          rect.X = -5000;
        }


        if (rect.Y < -5000)
        {
          rect.Y = -5000;
        }


        xNumeric.Value = rect.X;
        yNumeric.Value = rect.Y;
        widthNumeric.Value = rect.Width;
        heighNumeric.Value = rect.Height;

        aoiNameText.Text = area.AOIName;

        switch (area.AOIType)
        {
          case AOIType.Door:
            doorButton.Checked = true;
            break;

          case AOIType.PeopleWalking:
            peopleWalkingButton.Checked = true;
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


        switch (area.MovementType)
        {
          case MovementType.AnyActivity:
            anyActivityButton.Checked = true;
            break;

          case MovementType.Arrival:
            arrivingButton.Checked = true;
            break;

          case MovementType.Departure:
            departingButton.Checked = true;
            break;
        }

        if (null != area.SearchCriteria)
        {
          foreach (ObjectCharacteristics obj in area.SearchCriteria)
          {
            ListViewItem item = new ListViewItem(new string[]
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
        else if (ignoreButton.Checked)
        {
          Area.AOIType = AOIType.IgnoreObjects;
        }

        // Set the Movement type
        if (anyActivityButton.Checked)
        {
          Area.MovementType = MovementType.AnyActivity;
        }
        else if (arrivingButton.Checked)
        {
          Area.MovementType = MovementType.Arrival;
        }
        else if (departingButton.Checked)
        {
          Area.MovementType = MovementType.Departure;
        }

        if (Area.SearchCriteria != null)
        {
          Area.SearchCriteria.Clear();
        }

        foreach (ListViewItem item in ObjectsListView.Items)
        {
          Area.SearchCriteria.Add((ObjectCharacteristics)item.Tag);
        }

        _rectangle = new Rectangle((int)xNumeric.Value, (int)yNumeric.Value, (int)widthNumeric.Value, (int)heighNumeric.Value);
        Area.AreaRect = _rectangle;
        Area.OriginalXResolution = BitmapResolution.XResolution;
        Area.OriginalYResolution = BitmapResolution.YResolution;

        Storage.SaveArea(Area);

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
      using (NotificationOptionsDialog dlg = new NotificationOptionsDialog(Area))
      {
        dlg.ShowDialog(this);
        DialogResult = DialogResult.None;
      }
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
      using (ObjectDefinitionDialog dlg = new ObjectDefinitionDialog())
      {
        DialogResult result = dlg.ShowDialog();
        if (result == DialogResult.OK)
        {
          ListViewItem item = new ListViewItem(new string[] { dlg.ObjectType, dlg.Confidence.ToString(), dlg.Overlap.ToString(), dlg.MinX.ToString(), dlg.MinY.ToString(), dlg.History.ToString() });
          item = ObjectsListView.Items.Add(item);
          ObjectCharacteristics objChar = new ObjectCharacteristics();
          objChar.ObjectType = dlg.ObjectType;
          objChar.Confidence = dlg.Confidence;
          objChar.MinPercentOverlap = dlg.Overlap;
          objChar.MinimumXSize = dlg.MinX;
          objChar.MinimumYSize = dlg.MinY;
          objChar.TimeFrame = dlg.History;

          item.Tag = objChar;
        }

      }
    }

    // Editing ObjectCharacteristics
    private void ObjectsListView_ItemActivate(object sender, EventArgs e)
    {
      ListViewItem item = ObjectsListView.SelectedItems[0];
      ObjectCharacteristics objChar = (ObjectCharacteristics)item.Tag;
      using (ObjectDefinitionDialog dlg = new ObjectDefinitionDialog(objChar))
      {
        DialogResult result = dlg.ShowDialog();
        if (result == DialogResult.OK)
        {
          objChar.ObjectType = dlg.ObjectType;
          objChar.Confidence = dlg.Confidence;
          objChar.MinPercentOverlap = dlg.Overlap;
          objChar.MinimumXSize = dlg.MinX;
          objChar.MinimumYSize = dlg.MinY;
          objChar.TimeFrame = dlg.History;
          item.SubItems[0].Text = dlg.ObjectType;
          item.SubItems[1].Text = dlg.Confidence.ToString();
          item.SubItems[2].Text = dlg.Overlap.ToString();
          item.SubItems[3].Text = dlg.MinX.ToString();
          item.SubItems[4].Text = dlg.MinY.ToString();
          item.SubItems[5].Text = dlg.History.ToString();
        }
      }

    }

    private void RemoveButton_Click(object sender, EventArgs e)
    {
      if(ObjectsListView.SelectedItems.Count > 0)
      {
        ObjectsListView.Items.RemoveAt(ObjectsListView.SelectedIndices[0]);
      }
    }
  }
}
