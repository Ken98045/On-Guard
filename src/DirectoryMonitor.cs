using System;
using System.IO;
using System.Threading.Tasks;

namespace OnGuardCore
{

  public delegate void CameraEventHandler(CameraData cameraData, string eventInfo);

  /// <summary>
  /// A class to monitor a directory for new files that have motion identified by Blue Iris
  /// It then notifies the main UI of the new file. 
  /// </summary>
  public class DirectoryMonitor : IDisposable
  {
    public FileSystemWatcher Watcher { get; set; }
    public FileSystemWatcher TriggerWatcher { get; set; }
    public event CameraEventHandler OnNewImage = delegate {};

    CameraData _camera;

    public DirectoryMonitor(CameraData camera)
    {
      if (camera == null || string.IsNullOrEmpty(camera.CameraPath))
      {
        string msg = "DirectoryMonitor constructor: The camera is null or the path is null/empty";

        Dbg.Write(msg);
        ArgumentException ex = new (msg);
        throw ex;
      }

      if (!Directory.Exists(camera.CameraPath))
      {
        string msg = "DirectoryMonitor constructor: The directory being monitored does not exist: " + camera.CameraPath + "  Check your camera settings!";
        Dbg.Write(msg);
        ArgumentException ex = new (msg);
        throw ex;

      }

      _camera = camera;

      Watcher = new FileSystemWatcher(camera.CameraPath);
      CreateWatcher(Watcher, camera.CameraPath, camera.CameraPrefix);

      if (_camera.CameraInputMethod == CameraMethod.CameraTriggered && !string.IsNullOrEmpty(camera.TriggerPrefix))
      {
        TriggerWatcher = new FileSystemWatcher(camera.CameraPath);
        CreateWatcher(TriggerWatcher, camera.CameraPath, camera.TriggerPrefix);
      }
    }

    private void CreateWatcher(FileSystemWatcher aWatcher, string dir, string prefix)
    {
      try
      {

        aWatcher.NotifyFilter =
                                 NotifyFilters.CreationTime
                                 | NotifyFilters.FileName
                                 | NotifyFilters.LastAccess
                                 | NotifyFilters.LastWrite
                                 | NotifyFilters.Size;

        aWatcher.Changed += FileChanged;
        aWatcher.Created += Watcher_Created;
        aWatcher.Renamed += Watcher_Created;
        aWatcher.Error += Watcher_Error;

        aWatcher.IncludeSubdirectories = _camera.MonitorSubdirectories;
        aWatcher.InternalBufferSize = 1024 * 63;
        aWatcher.Filter = prefix + "*.jpg";

        aWatcher.EnableRaisingEvents = true;
      }
      catch (Exception ex)
      {
        Dbg.Write("DirectoryMonitor CreateWatcher exception: " + ex.Message);
      }
    }

    private void Watcher_Created(object sender, FileSystemEventArgs e)
    {
      OnNewImage(_camera, e.FullPath);
    }

    private void Watcher_Error(object sender, ErrorEventArgs e)
    {
      Dbg.Write("DirectoryMonitory - File System Watcher Error! " + e.GetException().Message);
      if (!disposedValue)
      {
        Dbg.Write("Attempting to recreate the DirectoryMonitor");
        try
        {
          Watcher?.Dispose();
        }
        catch (Exception ex)
        {
          Dbg.Write("DirectoryMonitor - Watcher_Error - " + ex.Message);
        }

        try
        {
          TriggerWatcher?.Dispose();
        }
        catch (Exception ex)
        {
          Dbg.Write("DirectoryMonitor - Watcher_Error - " + ex.Message);
        }

        Watcher = new FileSystemWatcher(_camera.CameraPath);
        CreateWatcher(Watcher, _camera.CameraPath, _camera.CameraPrefix);
        if (null != TriggerWatcher)
        {
          TriggerWatcher.Dispose();
          TriggerWatcher = new FileSystemWatcher(_camera.CameraPath);
          CreateWatcher(TriggerWatcher, _camera.CameraPath, _camera.TriggerPrefix);
        }
      }

    }

    // You can get at least 2 notifications for each new image file.  One when it is 
    // created and on when it is written to.  The client (main UI) must be able to handle that.
    private void FileChanged(object sender, FileSystemEventArgs e)
    {
      if (e.ChangeType == WatcherChangeTypes.Changed)
      {/*
        if (null != OnNewImage)
        {
          OnNewImage.Invoke(cameraData, e.FullPath);
        }*/
      }
    }


    #region IDisposable Support
    private bool disposedValue = false; // To detect redundant calls

    protected virtual void Dispose(bool disposing)
    {
      if (!disposedValue)
      {
        if (disposing)
        {
          Watcher.EnableRaisingEvents = false;
          Watcher.Changed -= FileChanged;
          Watcher.Dispose();

          if (null != TriggerWatcher)
          {
            TriggerWatcher.Changed -= FileChanged;
            TriggerWatcher.Dispose();
            TriggerWatcher = null;
          }
        }

        disposedValue = true;
      }
    }

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
