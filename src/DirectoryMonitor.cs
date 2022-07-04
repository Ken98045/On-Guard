using System;
using System.IO;
using System.Threading.Tasks;
using System.Management;

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
    public event CameraEventHandler OnNewImage = delegate { };

    CameraData _camera;
    bool _handledError = false;

    public DirectoryMonitor(CameraData camera)
    {
      string path = ConvertMappedDrive(camera.CameraPath);
      if (camera == null || string.IsNullOrEmpty(path))
      {
        string msg = "DirectoryMonitor constructor: The camera is null or the path is null/empty";
        _handledError = true;
        Dbg.Write(LogLevel.Error, msg);
        ArgumentException ex = new(msg);
        throw ex;
      }

      if (!Directory.Exists(path))
      {
        string msg = "DirectoryMonitor constructor: The directory being monitored does not exist: " + path + "  Check your camera settings!";
        _handledError = true;
        Dbg.Write(LogLevel.Error, msg);
        ArgumentException ex = new(msg);
        throw ex;

      }

      _camera = camera;

      Watcher = new FileSystemWatcher(path);
      CreateWatcher(Watcher, path, camera.CameraPrefix);

      if (_camera.CameraInputMethod == CameraMethod.CameraTriggered && !string.IsNullOrEmpty(camera.TriggerPrefix))
      {
        TriggerWatcher = new FileSystemWatcher(path);
        CreateWatcher(TriggerWatcher, path, camera.TriggerPrefix);
        _handledError |= false;
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
        _handledError = true;
        Dbg.Write(LogLevel.Error, "DirectoryMonitor CreateWatcher exception: " + ex.Message);
      }
    }

    private void Watcher_Created(object sender, FileSystemEventArgs e)
    {
      _handledError = false;
      OnNewImage(_camera, e.FullPath);
    }

    private void Watcher_Error(object sender, ErrorEventArgs e)
    {
      string path = ConvertMappedDrive(_camera.CameraPath);
      if (!_handledError)
      {
        _handledError = true;
        Dbg.Write(LogLevel.Error, "DirectoryMonitory - File System Watcher Error! " + e.GetException().Message);
        if (!disposedValue)
        {
          Dbg.Write(LogLevel.Warning, "Attempting to recreate the DirectoryMonitor");
          try
          {
            Watcher?.Dispose();
          }
          catch (Exception ex)
          {
            Dbg.Write(LogLevel.Error, "DirectoryMonitor - Watcher_Error - " + ex.Message);
          }

          try
          {
            TriggerWatcher?.Dispose();
          }
          catch (Exception ex)
          {
            Dbg.Write(LogLevel.Error, "DirectoryMonitor - Watcher_Error - " + ex.Message);
          }


          Watcher = new FileSystemWatcher(path);
          CreateWatcher(Watcher, path, _camera.CameraPrefix);
          if (null != TriggerWatcher)
          {
            TriggerWatcher.Dispose();
            TriggerWatcher = new FileSystemWatcher(_camera.CameraPath);
            CreateWatcher(TriggerWatcher, _camera.CameraPath, _camera.TriggerPrefix);
          }
        }
      }

    }

    // You can get at least 2 notifications for each new image file.  One when it is 
    // created and on when it is written to.  The client (main UI) must be able to handle that.
    private void FileChanged(object sender, FileSystemEventArgs e)
    {
    }

    // If the user has passed in a mapped drive it may be necessary to convert the path to something FileWatcher can handle.
    // Note that only windows directories can be watched
    static string ConvertMappedDrive(string path)
    {
      string result = path;
      string drivePrefix = path.Substring(0, 2);
      string unc;

      if (drivePrefix != "\\")
      {
        ManagementObject mo = new ManagementObject();
        try
        {
          mo.Path = new ManagementPath($"Win32_LogicalDisk='{drivePrefix}'");
          unc = (string)mo["ProviderName"];
          if (!string.IsNullOrEmpty(unc))
          {
            result = path.Replace(drivePrefix, unc);
          }
        }
        catch
        {
          throw;
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
