using SAAI.Properties;
using System;

namespace SAAI
{
  /// <summary>
  /// CameraData holds all of the data related to a camera.
  /// This includes the camera data prefix and the path to the files.
  /// It also includes areas of interest and data to allow access to the Blue Iris camera live data.
  /// </summary>
  [Serializable]
  public class CameraData : IDisposable
  {
    public Guid ID { get; }
    public string CameraPrefix { get; }     // prefix and path can identify the camera
    public string Path { get; }

    // The registration marks allow for slight adjustment of the Areas of Interest if the camera moves.  It also 
    // Allows you to put the camera back at the correct position if you move the camera (accidently or on purpose)
    public int RegistrationX { get; set; }
    public int RegistrationY { get; set; }

    public bool Monitoring { get; set; }  // Monitor the camera path for new images created by motion.

    public CameraContactData LiveContactData { get; set; }


    [NonSerialized]
    public AreasOfInterestCollection AOI;   // Each camera has its own collection of areas

    [field: NonSerializedAttribute()]
    public DirectoryMonitor Monitor { get; set; } // monitor the directory for motion images

    [field: NonSerializedAttribute()]
    public bool Accumulating { get; set; }      // we are accumulating photos for email purposes

    [field: NonSerializedAttribute()]
    public EmailAccumulator CameraEmailAccumulator { get; set; }  // the accumulator that is doing it.

    [field: NonSerializedAttribute()]
    public DateTime TimeLastAccumulatorCompleted { get; set; }  // when did the last accumulator complete - implement interval between events
    [field: NonSerializedAttribute()]

    // When accumulating we track the last area type so we can prioritize door events.  
    // This is global for the camera because objects (people) can move between areas

    public AOIType LastAccumulateType { get; set; }


    [field: NonSerializedAttribute()]
    public object AccumulateLock { get; set; } = new object();

    [field: NonSerializedAttribute()]
    public History FrameHistory { get; set; }


    public CameraData(string prefix, string path)
    {
      ID = Guid.NewGuid();
      FrameHistory =  new History(600);
      LiveContactData = new CameraContactData();
      CameraPrefix = prefix;
      Path = path;
      Monitoring = true;
      AOI = new AreasOfInterestCollection(CameraPrefix);
    }

    public CameraData(CameraData src)
    {
      ID = Guid.NewGuid();
      FrameHistory = new History(600);
      CameraPrefix = src.CameraPrefix;
      Path = src.Path;
      RegistrationX = src.RegistrationX;
      RegistrationY = src.RegistrationY;
      Monitoring = src.Monitoring;
      LiveContactData = new CameraContactData(src.LiveContactData);
      AOI = new AreasOfInterestCollection(src.AOI);
      Monitor = null;
    }

    public override string ToString()
    {
      return CameraPrefix;
    }

    public void Init()
    {
      AccumulateLock = new object();
      if (null == FrameHistory)
      {
        FrameHistory = new History(600);
      }

      AOI = new AreasOfInterestCollection(CameraPrefix);
      CameraEmailAccumulator = new EmailAccumulator(Settings.Default.MaxEventTime);
      if (Monitoring)
      {
        Monitor = new DirectoryMonitor(this);
      }
    }

    // PathAndPrefix allows us to monitor the directory for motion images.  It also identifies the camera 
    public static string PathAndPrefix(CameraData camera)
    {
      return string.Format("{0}\\{1}", camera.Path, camera.CameraPrefix).ToLower();
    }

    // The actual path for monitoring motion images
    public static string WildcardPath(CameraData camera)
    {
      return CameraData.PathAndPrefix(camera) + "\\*.jpg";
    }


    private bool disposedValue = false;

    protected virtual void Dispose(bool disposing)
    {
      if (!disposedValue)
      {
        if (disposing)
        {
         if (null != Monitor) Monitor.Dispose();
          if (null != CameraEmailAccumulator) CameraEmailAccumulator.Dispose();

          foreach (AreaOfInterest area in AOI)
          {
            area.Dispose();
          }

          AOI.Dispose();
          FrameHistory.Dispose();
        }

        disposedValue = true;
      }
    }

    ~CameraData()
    {
      Dispose(false);
    }

    public void Dispose()
    {
      Dispose(true);
      GC.SuppressFinalize(this);
    }
  }


}
