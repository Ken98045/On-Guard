using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace OnGuardCore
{

  /// <summary>
  /// Mainly a wrapper around the dictionary holding all the cameras.
  /// However, it also keeps track of the current camera and adds some helper methods.
  /// It also allow for persistence through the Load and Save methods.
  /// </summary>

  [Serializable]
  public class CameraCollection : IDisposable
  {

    public Dictionary<string, CameraData> CameraDictionary { get; }
    public string CurrentCameraPath { get; set; }

    public CameraCollection()
    {
      CameraDictionary = new Dictionary<string, CameraData>();
      CurrentCameraPath = string.Empty;
    }

    public CameraCollection(CameraCollection src)
    {
      CameraDictionary = new Dictionary<string, CameraData>();
      if (null != src && null != src.CameraDictionary && null != src.CameraDictionary.Values)
      {
        foreach (var cam in src.CameraDictionary.Values)
        {
          CameraData newCam = new CameraData(cam);
          CameraDictionary.Add(CameraData.PathAndPrefix(newCam), newCam);
          newCam.Init();
        }

        CurrentCameraPath = src.CurrentCameraPath;
      }
    }


    public CameraData this[string cameraPath]
    {
      get
      {
        if (string.IsNullOrEmpty(cameraPath))
        {
          return null;
        }
        else
        {
          if (CameraDictionary.TryGetValue(cameraPath.ToLower(), out CameraData cam))
          {
            return cam;
          }
          else
          {
            return null;
          }
        }
      }
    }


    public CameraData CurrentCamera
    {
      get
      {
        if (string.IsNullOrEmpty(CurrentCameraPath))
        {
          return null;
        }
        else
        {
          if (CameraDictionary.TryGetValue(CurrentCameraPath, out CameraData camData))
          {
            return camData;
          }
          else
          {
            return null;
          }
        }
      }
    }

    public void AddCamera(CameraData camData)
    {
      CameraDictionary.Add(CameraData.PathAndPrefix(camData), camData);
    }

    public void DeleteCamera(CameraData camData)
    {
      CameraDictionary.Remove(CameraData.PathAndPrefix(camData));
    }

    public void StopMonitoring()
    {
      foreach(var cam in CameraDictionary.Values)
      {
        if (cam.Monitoring)
        {
          cam.Monitor?.Dispose();
          cam.Monitor = null;
          cam.Monitoring = false;
        }
      }
    }

    public void StartMonitoring()
    {
      foreach (var cam in CameraDictionary.Values)
      {
        if (cam.Monitoring)
        {
          cam.Monitor = new DirectoryMonitor(cam);
        }
      }

    }

    /// <summary>
    /// All camera data is stored in separate files.
    /// It is binary serialized due to the fact that the
    /// dictionary can't be XML serialized.  
    /// </summary>
    /// <returns></returns>
    public static CameraCollection Load()
    {
      CameraCollection all = Storage.Instance.GetAllCameras();
      foreach (var cam in all.CameraDictionary.Values)
      {
        cam.Init();
      }


      return all;
    }

    public static void Save(CameraCollection allCameras)
    {
      Storage.Instance.SaveCameras(allCameras);
    }

    #region IDisposable Support
    private bool disposedValue = false; // To detect redundant calls

    protected virtual void Dispose(bool disposing)
    {
      if (!disposedValue)
      {
        if (disposing)
        {
          foreach (var cam in CameraDictionary.Values)
          {
            cam.Dispose();
          }

        }

        // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
        // TODO: set large fields to null.

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
