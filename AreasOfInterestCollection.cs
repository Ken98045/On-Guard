using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using SAAI.Properties;

namespace SAAI
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

    public AreasOfInterestCollection(string cameraPrefix)
    {
      Debug.Assert(!string.IsNullOrEmpty(cameraPrefix));
      _cameraPrefix = cameraPrefix;
      Load();
    }

    public AreasOfInterestCollection(AreasOfInterestCollection src)
    {
      _areas = new SortedDictionary<Guid, AreaOfInterest>();
      foreach (AreaOfInterest area in src._areas.Values)
      {
        AreaOfInterest newArea = new AreaOfInterest(area);  // not sure if we need a copy or a reference
        _areas.Add(newArea.ID, newArea);
      }
    }


    public AreaOfInterest this[Guid areaID]
    {
      get { return _areas[areaID]; }
    }

    public void UpdateArea(AreaOfInterest area)
    {
      _areas[area.ID] = area;
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
      _areas[area.ID] = area;
      Save();
    }

    public int Count()
    {
      return _areas.Values.Count;
    }

    public void Save()
    {

      BinaryFormatter serializer = new BinaryFormatter();
      using (Stream stream = new FileStream(Storage.GetFilePath(_cameraPrefix + "-AreasOfInterest.bin"), FileMode.Create))
      {
        serializer.Serialize(stream, _areas);
      }
    }

    private void Load()
    {
      string fileName = _cameraPrefix + "-AreasOfInterest.bin";
      string path = Storage.GetFilePath(fileName);
      bool exists = false;

      if (File.Exists(path))
      {
        exists = true;
      }

      if (exists)
      { 
        BinaryFormatter serializer = new BinaryFormatter();
        using (Stream reader = new FileStream(path, FileMode.Open))
        {
          _areas = (SortedDictionary<Guid, AreaOfInterest>)serializer.Deserialize(reader);
        }
      }
      else
      {
        _areas = new SortedDictionary<Guid, AreaOfInterest>();
      }

      // There is only one cooldown for the MQTT per area - kept in Notifications for now
      foreach (var area in _areas.Values)
      {
        area.Notifications.mqttCooldown = new MQTTCoolDown(Settings.Default.MQTTCoolDown);
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
