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

    public bool DeleteItem { get; set; }


    public CreateAOI(Rectangle imageRect, Point zoneFocus) // The area on the actual image, not the display image
    {
      InitializeComponent();
      Area = new AreaOfInterest
      {
        ZoneFocus = zoneFocus
      };

      _rectangle = imageRect;
      doorButton.Checked = true;
      anyActivityButton.Checked = true;

      xNumeric.Value = imageRect.X;
      yNumeric.Value = imageRect.Y;
      widthNumeric.Value = imageRect.Width;
      heighNumeric.Value = imageRect.Height;


      if (!Settings.Default.EmailSetup )
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
      _rectangle = area.AreaRect;
      Area.ZoneFocus = area.ZoneFocus;
      Rectangle rect = area.AreaRect;
      doorButton.Checked = true;
      anyActivityButton.Checked = true;

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
          switch (obj.ObjectType)
          {
            case ImageObjectType.People:
              peopleCheck.Checked = true;
              peopleConfidenceNumeric.Value = obj.Confidence;
              peopleMinimumOverlap.Value = obj.MinPercentOverlap;
              peopleFramesNumeric.Value = obj.NumberOfFrames;
              peopleMinXNumeric.Value = obj.MinimumXSize;
              peopleMinYNumeric.Value = obj.MinimumYSize;
              break;

            case ImageObjectType.Cars:
              carsCheck.Checked = true;
              carsConfidenceNumeric.Value = obj.Confidence;
              carsOverlapNumeric.Value = obj.MinPercentOverlap;
              carsFramesNumeric.Value = obj.NumberOfFrames;
              carsMinXNumeric.Value = obj.MinimumXSize;
              carsMinYNumeric.Value = obj.MinimumYSize;
              break;

            case ImageObjectType.Motorcycles:
              motorcycleCheck.Checked = true;
              motorcyclesConfidenceNumeric.Value = obj.Confidence;
              motorcyclesOverlapNumeric.Value = obj.MinPercentOverlap;
              motorcyclesFramesNumeric.Value = obj.NumberOfFrames;
              motorcyclesMinXNumeric.Value = obj.MinimumXSize;
              motorcyclesMinYNumeric.Value = obj.MinimumYSize;
              break;

            case ImageObjectType.Trucks:
              truckCheck.Checked = true;
              trucksConfidenceNumeric.Value = obj.Confidence;
              trucksOverlapNumeric.Value = obj.MinPercentOverlap;
              trucksFramesNumeric.Value = obj.NumberOfFrames;
              trucksMinXNumeric.Value = obj.MinimumXSize;
              trucksMinYNumeric.Value = obj.MinimumYSize;
              break;

            case ImageObjectType.Bikes:
              bikeCheck.Checked = true;
              bikesConfidenceNumeric.Value = obj.Confidence;
              bikesOverlapNumeric.Value = obj.MinPercentOverlap;
              bikesFramesNumeric.Value = obj.NumberOfFrames;
              bikesMinXNumeric.Value = obj.MinimumXSize;
              bikesMinYNumeric.Value = obj.MinimumYSize;
              break;

            case ImageObjectType.Bears:
              bearsCheck.Checked = true;
              bearsConfidenceNumeric.Value = obj.Confidence;
              bearsOverlapNumeric.Value = obj.MinPercentOverlap;
              bearsFramesNumeric.Value = obj.NumberOfFrames;
              bearsMinXNumeric.Value = obj.MinimumXSize;
              bearsMinYNumeric.Value = obj.MinimumXSize;
              break;

            case ImageObjectType.Animals:
              animalsCheck.Checked = true;
              animalsConfidenceNumeric.Value = obj.Confidence;
              animalsOverlapNumeric.Value = obj.MinPercentOverlap;
              animalsFramesNumeric.Value = obj.NumberOfFrames;
              animalsMinXNumeric.Value = obj.MinimumXSize;
              animalsMinYNumeric.Value = obj.MinimumXSize;
              break;

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
        if (Area.SearchCriteria != null)
        {
          Area.SearchCriteria.Clear();
        }

        Area.AOIName = aoiNameText.Text;
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

        if (peopleCheck.Checked)
        {
          ObjectCharacteristics c = new ObjectCharacteristics
          {
            ObjectType = ImageObjectType.People,
            Confidence = (int)peopleConfidenceNumeric.Value,
            MinPercentOverlap = (int)peopleMinimumOverlap.Value,
            NumberOfFrames = (int)peopleFramesNumeric.Value,
            MinimumXSize = (int)peopleMinXNumeric.Value,
            MinimumYSize = (int)peopleMinYNumeric.Value,


          };
          Area.SearchCriteria.Add(c);
        }

        if (carsCheck.Checked)
        {
          ObjectCharacteristics c = new ObjectCharacteristics
          {
            ObjectType = ImageObjectType.Cars,
            Confidence = (int)carsConfidenceNumeric.Value,
            MinPercentOverlap = (int)carsOverlapNumeric.Value,
            NumberOfFrames = (int)carsFramesNumeric.Value,
            MinimumXSize = (int)carsMinXNumeric.Value,
            MinimumYSize = (int)carsMinYNumeric.Value,

          };
          Area.SearchCriteria.Add(c);
        }

        if (truckCheck.Checked)
        {
          ObjectCharacteristics c = new ObjectCharacteristics
          {
            ObjectType = ImageObjectType.Trucks,
            Confidence = (int)trucksConfidenceNumeric.Value,
            MinPercentOverlap = (int)trucksOverlapNumeric.Value,
            NumberOfFrames = (int)trucksFramesNumeric.Value,
            MinimumXSize = (int)trucksMinXNumeric.Value,
            MinimumYSize = (int)trucksMinYNumeric.Value,
          };
          Area.SearchCriteria.Add(c);
        }

        if (motorcycleCheck.Checked)
        {
          ObjectCharacteristics c = new ObjectCharacteristics
          {
            ObjectType = ImageObjectType.Motorcycles,
            Confidence = (int)motorcyclesConfidenceNumeric.Value,
            MinPercentOverlap = (int)motorcyclesOverlapNumeric.Value,
            NumberOfFrames = (int)motorcyclesFramesNumeric.Value,
            MinimumXSize = (int)motorcyclesMinXNumeric.Value,
            MinimumYSize = (int)motorcyclesMinYNumeric.Value,
          };
          Area.SearchCriteria.Add(c);
        }

        if (bikeCheck.Checked)
        {
          ObjectCharacteristics c = new ObjectCharacteristics
          {
            ObjectType = ImageObjectType.Bikes,
            Confidence = (int)bikesConfidenceNumeric.Value,
            MinPercentOverlap = (int)bikesOverlapNumeric.Value,
            NumberOfFrames = (int)bikesFramesNumeric.Value,
            MinimumXSize = (int)bikesMinXNumeric.Value,
            MinimumYSize = (int)bikesMinYNumeric.Value,
          };
          Area.SearchCriteria.Add(c);
        }

        if (bearsCheck.Checked)
        {
          ObjectCharacteristics c = new ObjectCharacteristics
          {
            ObjectType = ImageObjectType.Bears,
            Confidence = (int)bearsConfidenceNumeric.Value,
            MinPercentOverlap = (int)bearsOverlapNumeric.Value,
            NumberOfFrames = (int)bearsFramesNumeric.Value,
            MinimumXSize = (int)bearsMinXNumeric.Value,
            MinimumYSize = (int)bearsMinYNumeric.Value,
          };
          Area.SearchCriteria.Add(c);
        }

        if (animalsCheck.Checked)
        {
          ObjectCharacteristics c = new ObjectCharacteristics
          {
            ObjectType = ImageObjectType.Animals,
            Confidence = (int)animalsConfidenceNumeric.Value,
            MinPercentOverlap = (int)animalsOverlapNumeric.Value,
            NumberOfFrames = (int)animalsFramesNumeric.Value,
            MinimumXSize = (int)animalsMinXNumeric.Value,
            MinimumYSize = (int)animalsMinYNumeric.Value,
          };
          Area.SearchCriteria.Add(c);
        }

        _rectangle = new Rectangle((int)xNumeric.Value, (int)yNumeric.Value, (int)widthNumeric.Value, (int)heighNumeric.Value);
        Rectangle beforeIntersect = _rectangle;
        _rectangle = Rectangle.Intersect(_rectangle, new Rectangle(0, 0, BitmapResolution.XResolution, BitmapResolution.YResolution));  // ensure that what the user entered was sane
        if (beforeIntersect != _rectangle)
        {
          MessageBox.Show("The area of the Area of Interest has been adjusted to fit onto the screen.", "Area Adjusted!");
        }
        Area.AreaRect = _rectangle;
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
  }
}
