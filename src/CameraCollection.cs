using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;

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

    public static CameraCollection CopyFactory(CameraCollection src)
    {

      CameraCollection copy = new ();
      if (null != src && null != src.CameraDictionary && null != src.CameraDictionary.Values)
      {
        foreach (var cam in src.CameraDictionary.Values)
        {
          CameraData newCam = CameraData.CameraCopyFactory(cam);
          copy.CameraDictionary.Add(CameraData.PathAndPrefix(newCam), newCam);
        }
      }

      copy.CurrentCameraPath = src.CurrentCameraPath;

      return copy;
    }

    public async Task InitAsync()
    {
      List<string> badCameras = new();

      foreach (var cam in CameraDictionary.Values)
      {
        try
        {
          await cam.InitAsync();
        }
        catch (Exception ex)
        {
          string err = "Error Initializing Camera: " + cam.CameraPrefix + " " + ex.Message;
          Dbg.Write(LogLevel.Error, err);
          badCameras.Add(CameraData.PathAndPrefix(cam));
        }
      }

      if (badCameras.Count > 0)
      {
        CameraStartupException ex = new CameraStartupException(badCameras);
        throw ex; 
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
      foreach (var cam in CameraDictionary.Values)
      {
        if (cam.Monitoring)
        {
          cam.Monitor?.Dispose();
          cam.Monitor = null;
          // cam.Monitoring = false;
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

  public class CameraStartupException : Exception
  {
    public List<string> FailedCameras {get; set;}

    public CameraStartupException(List<string> cameras) : base("One or more cameraa could not startup Ensure that all cameras are online!")
    {
      FailedCameras = cameras;
    }

    public CameraStartupException() : base() 
    {
      FailedCameras = new();
    }

    public CameraStartupException(string message, System.Exception inner) : base(message, inner) { }

    protected CameraStartupException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }

  }

}
