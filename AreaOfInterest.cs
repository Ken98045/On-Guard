using System;
using System.Collections.Generic;
using System.Drawing;

namespace SAAI
{

  [Serializable]
  public enum AOIType
  {
    IgnoreObjects = 0,
    Door,
    GarageDoor,
    Driveway,
    PeopleWalking
  }


  [Serializable]
  public enum MovementType
  {
    AnyActivity = 1,
    Arrival,
    Departure
  }

  [Serializable]
  public enum ImageObjectType
  {
    Irrelevant,
    People = 1,
    Cars,
    Trucks,
    Motorcycles,
    Bikes,
    Animals,
    Bears
  }

  /// <summary>
  /// An Area of Interest is a key concept for the application.  Objects found by the AI area
  /// only "Interesting" if they are in an AreaOfInterest. 
  /// AreasOfInterest can also be used to define areas in which we ignore objects.
  /// You can have as many areas as you like
  /// </summary>

  [Serializable]
  public class AreaOfInterest : IDisposable
  {
    public string AOIName { get; set; }             // The name to identify the area.  Also sent in any email notifications
    public AOIType AOIType { get; set; }            // Ignore, Door, Garage Door, Driveway.  Door has priority characteristincs
    public MovementType MovementType { get; set; }  // Not yet implemented.  In the future you can optionally notify for objects moving to or away from the area
    public List<ObjectCharacteristics> SearchCriteria { get; set; }  // Defines the characteristic for each object type - confidence, overlap, minimum size, ...
    public Rectangle AreaRect;      // The area for the AOI, in original bitmap pixels, not screen pixels
    public int OriginalXResolution { get; set; }    // Because if the camera images change resolution we need to adjust the virtual area
    public int OriginalYResolution { get; set; }    // ""
    public Point ZoneFocus { get; set; }  // The point in the area used to determine motion to/from the MovementType - Always relative to the area
    public AreaNotificationOption Notifications { get; set; } // URL and Email notifications, maybe others in the future

    public Guid ID { get; }   // a unique id for the area

    public AreaOfInterest()
    {
      ID = Guid.NewGuid();
      SearchCriteria = new List<ObjectCharacteristics>();
      Notifications = new AreaNotificationOption();
    }

    // Copy constructor for an area.
    public AreaOfInterest(AreaOfInterest src)
    {
      ID = src.ID;              // Guid.NewGuid();      // unsure if we always want this
      AOIName = src.AOIName;
      AOIType = src.AOIType;
      AreaRect = src.AreaRect;
      OriginalYResolution = src.OriginalXResolution;
      OriginalYResolution = src.OriginalYResolution;
      MovementType = src.MovementType;
      ID = src.ID;
      Notifications = new AreaNotificationOption(src.Notifications);
      

      SearchCriteria = new List<ObjectCharacteristics>(src.SearchCriteria);
    }

    // Get a rectangle that is adjusted according to the resolution when the area was created.
    // The resolution of bitmaps actually processed may not be the same as the resolution when the area was created
    public Rectangle GetRect()
    {
      Rectangle adjRect = new Rectangle(AreaRect.X, AreaRect.Y, AreaRect.Width, AreaRect.Height);

      adjRect.X = (int)((double)AreaRect.X * ((double)(BitmapResolution.XResolution) / (double)( OriginalXResolution)));
      adjRect.Y = (int)((double)AreaRect.Y * ((double)(BitmapResolution.YResolution ) / (double)(OriginalYResolution)));
      adjRect.Width = (int)((double)AreaRect.Width * ((double)(BitmapResolution.XResolution) / (double)OriginalXResolution));
      adjRect.Height = (int)((double)AreaRect.Height * ((double)(BitmapResolution.YResolution) / (double)OriginalYResolution));

      return adjRect;
    }

    public void SetRect(Rectangle rect)
    {
      
    }

    public void AdjustRect(int xOffset, int yOffset)
    {
      double xRatio = (double)BitmapResolution.XResolution / (double)OriginalXResolution;
      double yRatio = (double)BitmapResolution.YResolution / (double)OriginalYResolution ;
      AreaRect.X = AreaRect.X - (int) (xRatio * (double)xOffset);
      AreaRect.Y = AreaRect.Y - (int)(yRatio * (double)yOffset);

    }

    #region IDisposable Support
    private bool disposedValue = false; // To detect redundant calls

    protected virtual void Dispose(bool disposing)
    {
      if (!disposedValue)
      {
        if (disposing)
        {
          Notifications = null;
          SearchCriteria = null;
        }


        disposedValue = true;
      }
    }


    public void Dispose()
    {
      Dispose(true);
      GC.SuppressFinalize(this);
    }
    #endregion
  }
}
