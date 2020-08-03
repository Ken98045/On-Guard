using System;
using System.IO;

namespace SAAI
{

  public delegate void CameraEventHandler(CameraData cameraData, string eventInfo);

  /// <summary>
  /// A class to monitor a directory for new files that have motion identified by Blue Iris
  /// It then notifies the main UI of the new file. 
  /// </summary>
  public class DirectoryMonitor : IDisposable
  {
    public FileSystemWatcher Watcher { get; }
    public String Path() { return CameraData.PathAndPrefix(cameraData); }
    public event CameraEventHandler OnNewImage;

    readonly CameraData cameraData;
    public DirectoryMonitor(CameraData location)
    {
      Watcher = new FileSystemWatcher(location.Path, location.CameraPrefix + "*.jpg");
      cameraData = location;
      Watcher.Changed += FileChanged;
      Watcher.NotifyFilter = NotifyFilters.LastWrite;
      Watcher.EnableRaisingEvents = true;
    }

    // You can get at least 2 notifications for each new image file.  One when it is 
    // created and on when it is written to.  The client (main UI) must be able to handle that.
    private void FileChanged(object sender, FileSystemEventArgs e)
    {
      if (e.ChangeType == WatcherChangeTypes.Changed)
      {
        if (null != OnNewImage)
        {
          OnNewImage.Invoke(cameraData, e.FullPath);
        }
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
        }

        // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
        // TODO: set large fields to null.
        disposedValue = true;
      }
    }

    // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
    // ~DirectoryMonitor()
    // {
    //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
    //   Dispose(false);
    // }

    // This code added to correctly implement the disposable pattern.
    public void Dispose()
    {
      // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
      Dispose(true);
      // TODO: uncomment the following line if the finalizer is overridden above.
      GC.SuppressFinalize(this);
    }
    #endregion
  }
}
