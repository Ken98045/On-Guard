using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;

namespace OnGuardCore
{

  [Serializable]
  public enum AOIType
  {
    IgnoreObjects = 0,
    Door,
    GarageDoor,
    Driveway,
    PeopleWalking,
    FacialRecognition
  }

  [Serializable]
  public enum InterestingObjectType
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
    public List<ObjectCharacteristics> SearchCriteria { get; set; }  // Defines the characteristic for each object type - confidence, overlap, minimum size, ...

    GridDefinition _areaDefinition;
    public GridDefinition Grid
    {
      get
      {
        return _areaDefinition;
      }
      set
      {
        _areaDefinition = value;
      }
    }

    public AreaNotificationOption Notifications { get; set; } // URL and Email notifications, maybe others in the future

    public Guid ID { get; set; }   // a unique id for the area

    public AreaOfInterest()
    {
      Grid = new GridDefinition(GlobalData.AreaGridX, GlobalData.AreaGridY);
      ID = Guid.NewGuid();
      SearchCriteria = new List<ObjectCharacteristics>();
      Notifications = new AreaNotificationOption();
    }

    public AreaOfInterest(GridDefinition area)
    {
      Grid = new GridDefinition(area);
      ID = Guid.NewGuid();
      SearchCriteria = new List<ObjectCharacteristics>();
      Notifications = new AreaNotificationOption();
    }


    public AreaOfInterest

    (
      Guid id,
      string name,
      AOIType areaType,
      Rectangle areaRect,
      int originalXResolution,
      int originalYResolution,
      Point Focus,
      AreaNotificationOption notifications,
      List<ObjectCharacteristics> searchCritera
      )

    {
      ID = id;
      AOIName = name;
      AOIType = areaType;
      Notifications = notifications;
      SearchCriteria = searchCritera;
    }


    // Copy constructor for an area.
    public AreaOfInterest(AreaOfInterest src)
    {
      Debug.Assert(src != null);
      if (src != null)
      {
        ID = src.ID;              // 
        AOIName = src.AOIName;
        AOIType = src.AOIType;
        Notifications = new AreaNotificationOption(src.Notifications);
        SearchCriteria = new List<ObjectCharacteristics>(src.SearchCriteria);
        Grid = new GridDefinition(src.Grid);
        }
    }

    public bool IsItemOfAreaInterest(string label)
    {
      bool result = false;

      if (null != SearchCriteria)
      {
        foreach (var searchCriteria in SearchCriteria)
        {
          foreach (var face in searchCriteria.Faces)
          {
            if (face.Selected && face.Name == label)
            {
              result = true;
              break;
            }
          }

          if (searchCriteria.ObjectType == label || FrameAnalyzer.MatchesSpecialTag(searchCriteria, label))
          {
            result = true;
            break;
          }
        }
      }

      return result;
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
