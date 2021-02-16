using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using OnGuardCore.Properties;

namespace OnGuardCore
{

  /// <summary>
  /// A collection wrapping a SortedDictionary with added persistence. 
  /// There is one collection per camera.  
  /// TODO: Replace with a Dictionary?
  /// </summary>
  public class AreasOfInterestCollection : IEnumerable<AreaOfInterest>, IDisposable
  {
    SortedDictionary<Guid, AreaOfInterest> _areas;

    readonly string _cameraPrefix;
    readonly string _cameraPath;

    public AreasOfInterestCollection(string cameraPath, string cameraPrefix)
    {
      Debug.Assert(!string.IsNullOrEmpty(cameraPrefix));
      _areas = new SortedDictionary<Guid, AreaOfInterest>();
      _cameraPath = cameraPath;
      _cameraPrefix = cameraPrefix;
      Load();
    }

    public AreasOfInterestCollection(AreasOfInterestCollection src)
    {
      Debug.Assert(src != null);
      if (src != null)
      {
        _cameraPath = src._cameraPath;
        _cameraPrefix = src._cameraPrefix;
        _areas = new SortedDictionary<Guid, AreaOfInterest>();

        foreach (AreaOfInterest area in src._areas.Values)
        {
          AreaOfInterest newArea = new AreaOfInterest(area);  // not sure if we need a copy or a reference
          _areas.Add(newArea.ID, newArea);
        }
      }
    }


    public AreaOfInterest this[Guid areaID]
    {
      get { return _areas[areaID]; }
    }

    public void UpdateArea(AreaOfInterest area)
    {
      if (area != null)
      {
        _areas[area.ID] = area;
      }
    }

    public IEnumerator<AreaOfInterest> GetEnumerator()
    {
      return _areas.Values.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return this.GetEnumerator();
    }

    public void AddArea(AreaOfInterest area)
    {
      Debug.Assert(area != null);
      if (area != null)
      {
        _areas[area.ID] = area;
      }
    }

    public int Count()
    {
      return _areas.Values.Count;
    }

    public void Save()
    {
      Debug.Assert(_cameraPath != null);
      Debug.Assert(_cameraPath != null);
      Storage.Instance.SaveAllAreas(_cameraPath, _cameraPrefix, this);
    }

    private void Load()
    {
      _areas = Storage.Instance.GetAllAreas(_cameraPath, _cameraPrefix);

      // There is only one cooldown for the MQTT per area - kept in Notifications for now
      foreach (var area in _areas.Values)
      {
        area.Notifications.mqttCooldown = new MQTTCoolDown(Storage.Instance.GetGlobalInt("MQTTCoolDown"));
      }
    }

    public void Remove(Guid id)
    {
      _areas.Remove(id);
      Save();
    }

    #region IDisposable Support
    private bool disposedValue = false; // To detect redundant calls

    protected virtual void Dispose(bool disposing)
    {
      if (!disposedValue)
      {
        if (disposing)
        {
          foreach (AreaOfInterest area in _areas.Values)
          {
            area.Dispose(); // probably not necessary, but...
          }
        }

        // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
        // TODO: set large fields to null.

        disposedValue = true;
      }
    }

    // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
    // ~AreasOfInterestCollection()
    // {
    //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
    //   Dispose(false);
    // }

    // This code added to correctly implement the disposable pattern.
    public void Dispose()
    {
      // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
      Dispose(true);
      GC.SuppressFinalize(this);
    }
    #endregion

  }
}
