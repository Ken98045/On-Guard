using SAAI.Properties;
using System;
using System.Drawing;

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
    public int RegistrationXResolution { get; set; }      // You can keep the same camera but you might change the resolution on pictures
    public int RegistrationYResolution { get; set; }      // "" and both of these never change until you change the registration mark
    private int registrationX;
    private int registrationY;

    public int RegistrationX
    {
      get
      {
        int adjX = registrationX;
        if (registrationX > 0)
        {
          if (BitmapResolution.XResolution != RegistrationXResolution)
          {
            adjX = (int)((double)adjX * ((double)(BitmapResolution.XResolution) / (double)(RegistrationXResolution)));
          }
        }

        return adjX;
      }
      set 
      {
        if (BitmapResolution.XResolution != RegistrationXResolution)
        {
          RegistrationXResolution = BitmapResolution.XResolution;
        }

        registrationX = value;
      }
    }
    public int RegistrationY
    {
      get
      {
        int adjY = registrationY;
        if (adjY > 0)
        {
          if (BitmapResolution.YResolution != RegistrationYResolution)
          {
            adjY = (int)((double)adjY * ((double)(BitmapResolution.YResolution) / (double)(RegistrationYResolution)));
          }
        }

        return adjY;
      }
      set
      {
        if (BitmapResolution.YResolution != RegistrationYResolution)
        {
          RegistrationYResolution = BitmapResolution.YResolution;
        }

        registrationY = value;
      }
    }


    public bool Monitoring { get; set; }  // Monitor the camera path for new images created by motion.

    public CameraContactData LiveContactData { get; set; }
    public int NoMotionTimeout { get; set; }


    [NonSerialized]
    public AreasOfInterestCollection AOI;   // Each camera has its own collection of areas

    [field: NonSerializedAttribute()]
    public DirectoryMonitor Monitor { get; set; } // monitor the directory for motion images

    [field: NonSerializedAttribute()]
    public bool Accumulating { get; set; }      // we are accumulating photos for email purposes

    [field: NonSerializedAttribute()]
    public EmailAccumulator CameraEmailAccumulator { get; set; }  // the accumulator that is doing it.

    [field: NonSerializedAttribute()]
    public System.Threading.Timer MotionStoppedTimer { get; set; }

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
      FrameHistory = new History(300);
      LiveContactData = new CameraContactData();
      CameraPrefix = prefix;
      Path = path;
      Monitoring = true;
      AOI = new AreasOfInterestCollection(Path, CameraPrefix);
      NoMotionTimeout = 90;
    }

    public CameraData(CameraData src)
    {
      if (null == src)
      {
        ArgumentNullException argumentNullException = new ArgumentNullException("src in CameraData copy constructor");
        throw argumentNullException;
      }

      ID = Guid.NewGuid();
      FrameHistory = new History(300);
      CameraPrefix = src.CameraPrefix;
      Path = src.Path;
      RegistrationX = src.RegistrationX;
      RegistrationY = src.RegistrationY;
      Monitoring = src.Monitoring;
      LiveContactData = new CameraContactData(src.LiveContactData);
      AOI = new AreasOfInterestCollection(src.AOI);
      Monitor = null;
      NoMotionTimeout = src.NoMotionTimeout;
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
        FrameHistory = new History(300);
      }

      // AOI = new AreasOfInterestCollection(Path, CameraPrefix);
      CameraEmailAccumulator = new EmailAccumulator(Settings.Default.MaxEventTime);
      if (Monitoring)
      {
        Monitor = new DirectoryMonitor(this);
      }
    }

    public void StopMonitoring()
    {
      if (Monitoring)
      {
        Monitor.Dispose();
        Monitor = null;
      }
    }

    public void StartMonitoring()
    {
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
          disposing = true;
          MotionStoppedTimer?.Dispose();
          Monitor?.Dispose();
          FrameHistory?.Dispose();

          CameraEmailAccumulator?.Dispose();

          foreach (AreaOfInterest area in AOI)
          {
            area.Dispose();
          }

          AOI.Dispose();

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
