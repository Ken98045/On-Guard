using OnGuardCore.Src.Properties;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Collections.Generic;
using System.Threading.Tasks;
using Innovative.SolarCalculator;
using System.Net;
using System.Net.Http;
using System.IO;

namespace OnGuardCore
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
    public string CameraPrefix { get; set; }     // prefix and path can identify the camera
    public string TriggerPrefix { get; set; }   // The prefix used for the FTP server
    public string CameraPath { get; set; }
    public bool MonitorSubdirectories { get; set; }

    public CameraMethod CameraInputMethod { get; set; }
    public double OnGuardScanIterval { get; set; } // On Guard method ONLY! Get an image and check it this often
    public bool StorePicturesInAreaOnly { get; set; } // On Guard Method ONLY! If set pictures of types the user cares about, otherwise they must also be in an AOI
    public double TriggerInterval { get; set; }   // The time between frames when we are manually recording
    public double RecordTime { get; set; }  // The time to record based on the trigger
    public double RecordInterval { get; set; } // The time between recordings (avoid recording too much)
    public DateTime TimeOfLastRecordedFrame { get; set; }  // based on the triggered recording, when did we stop recording?
    public List<PresetTrigger> ScheduledPresets { get; set; }
    public Double Longitude { get; set; }
    public Double Latitude { get; set; }
    public DateTime Sunrise { get; set; }
    public DateTime Sunset { get; set; }

    public OnGuardScanner Scanner { get; set; } // NOT copied via copy constructor
    public TriggerCamera CameraTrigger { get; set; } // NOT copied via copy constructor

    // The registration marks allow for slight adjustment of the Areas of Interest if the camera moves.  It also 
    // Allows you to put the camera back at the correct position if you move the camera (accidently or on purpose)
    private int _registrationXResolution;
    private int _registrationYResolution;
    public int RegistrationXResolution
    {
      get
      {
        return _registrationXResolution;
      }
      set
      {
        _registrationXResolution = value;
      }
    }

    public int RegistrationYResolution
    {
      get
      {
        return _registrationYResolution;
      }
      set
      {
        _registrationYResolution = value;
      }
    }

    public int Channel { get; set; }

    private int registrationX;
    private int registrationY;

    public int RegistrationX
    {
      get
      {
        return registrationX;
      }
      set
      {
        registrationX = value;
      }
    }
    public int RegistrationY
    {
      get
      {
        return registrationY;
      }
      set
      {
        registrationY = value;
      }
    }


    public bool Monitoring { get; set; }  // Monitor the camera path for new images created by motion.

    public CameraContactData Contact { get; set; }
    public int NoMotionTimeout { get; set; }

    public DisplayOption CameraView { get; set; }


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


    public CameraData(Guid id, string prefix, string path)
    {
      ID = id;
      Contact = new CameraContactData();
      CameraPrefix = prefix;
      CameraPath = path;
      Monitoring = true;
      AOI = new AreasOfInterestCollection(CameraPath, CameraPrefix);
      NoMotionTimeout = 90;
      ScheduledPresets = new List<PresetTrigger>();
      CameraView = DisplayOption.FilledHorizontally;

    }

    public static CameraData CameraCopyFactory(CameraData src)
    {
      CameraData dest = new (src);
      return dest;
    }

    public CameraData(CameraData src)
    {
      if (null == src)
      {
        ArgumentNullException argumentNull = new("src in CameraData copy constructor");
        throw argumentNull;
      }
      else
      {
        ID = Guid.NewGuid();
        CameraPrefix = src.CameraPrefix;
        CameraPath = src.CameraPath;

        RegistrationX = src.RegistrationX;
        RegistrationY = src.RegistrationY;
        RegistrationXResolution = src.RegistrationXResolution;
        RegistrationYResolution = src.RegistrationYResolution;
        Monitoring = src.Monitoring;
        Contact = new CameraContactData(src.Contact);
        AOI = new AreasOfInterestCollection(src.AOI);
        Monitor = null;
        NoMotionTimeout = src.NoMotionTimeout;
        MonitorSubdirectories = src.MonitorSubdirectories;
        CameraInputMethod = src.CameraInputMethod;
        OnGuardScanIterval = src.OnGuardScanIterval;
        StorePicturesInAreaOnly = src.StorePicturesInAreaOnly;
        TriggerInterval = src.TriggerInterval;
        RecordTime = src.RecordTime;
        RecordInterval = src.RecordInterval;
        CameraView = src.CameraView;
        TimeOfLastRecordedFrame = src.TimeOfLastRecordedFrame;
        TriggerPrefix = src.TriggerPrefix;

        Longitude = src.Longitude;
        Latitude = src.Latitude;
        Sunrise = src.Sunrise;
        Sunset = src.Sunset;

        ScheduledPresets = new List<PresetTrigger>();
        foreach (var preset in src.ScheduledPresets)
        {
          ScheduledPresets.Add(new PresetTrigger(preset));
        }
      }
    }

    public override string ToString()
    {
      return CameraPrefix;
    }

    public async Task InitAsync()
    {
      await Contact.InitAsync();

      AccumulateLock = new object();
      // AOI = new AreasOfInterestCollection(Path, CameraPrefix);
      CameraEmailAccumulator = new EmailAccumulator(Storage.Instance.GetGlobalInt("MaxEventTime"));
      if (Monitoring)
      {
        Monitor = new DirectoryMonitor(this);
      }

      switch (CameraInputMethod)
      {
        case CameraMethod.OnGuard:
          Scanner = new OnGuardScanner(this);
          break;

        case CameraMethod.CameraTriggered:
          CameraTrigger = new TriggerCamera(this);
          break;
      }

      if (Longitude != 0 && Latitude != 0)
      {
        try
        {
          Innovative.Geometry.Angle lat = new (Latitude);
          Innovative.Geometry.Angle lon = new (Longitude);

          SolarTimes solarTimes = new (DateTime.Now, new Innovative.Geometry.Angle(Latitude), new Innovative.Geometry.Angle(Longitude));
          Sunset = solarTimes.Sunset;
          Sunrise = solarTimes.Sunrise;
        }
        catch (Exception ex)
        {
          Dbg.Write(LogLevel.Warning, "CameraData - Init - Error getting sunrise/sunset: " + ex.Message);
          return;
        }

        DateTime midnight = TimeTrigger.GetHourMinute(0, 1);
        TimeTrigger.AddTimer(midnight, ID);   // 
        TimeTrigger.OnTimeTriggered += OnUpdateSolar;
        TimeTrigger.OnTimeTriggered += OnScheduledPreset;

        foreach (var sched in ScheduledPresets)
        {
          switch (sched.TriggerType)
          {
            case PresetTriggerType.AtTime:
              TimeTrigger.AddTimer(sched.TriggerTime, sched.ID);
              break;

            case PresetTriggerType.Sunrise:
              TimeTrigger.AddTimer(Sunrise, sched.ID);
              break;

            case PresetTriggerType.Sunset:
              TimeTrigger.AddTimer(Sunset, sched.ID);
              break;
          }
        }
      }
    }

    private async void OnScheduledPreset(Guid id)
    {
      PresetTrigger preset = ScheduledPresets.Find(x => x.ID == id);
      if (null != preset)
      {
        if (Contact.PresetSettings.PresetMethod != PTZMethod.None)
        {
          try
          {
            await MoveToPresetAsync(preset.PresetNumber);
          }
          catch (Exception ex)
          {
            Dbg.Write(LogLevel.Info, "CameraData - OnScheduledPreset - " + ex.Message);
          }
        }
      }
    }

    private async Task MoveToPresetAsync(int presetNumber)
    {
      CameraContactData data = new (Contact);

      if (data.PresetSettings.PresetList.Count > 0)
      {
        string urlString;

        if (data.PresetSettings.PresetMethod == PTZMethod.OnVIF)
        {
          await data.ONVIF.Ptz.GotoPresetAsync(
            data.ONVIF.SelectedProfile,
            data.PresetSettings.PresetList[presetNumber].Command,
            null);
        }
        else
        {
          if (data.PresetSettings.PresetMethod == PTZMethod.BlueIris)
          {

            urlString = $"http://[ADDRESS]/admin?camera=[SHORTNAME]&preset={data.PresetSettings.PresetList[presetNumber].Command}&user=[USERNAME]&pw=[PASSWORD]";

            urlString = data.ReplaceParmeters(urlString);
          }
          else if (data.PresetSettings.PresetMethod == PTZMethod.HTTP)
          {
            urlString = data.PresetSettings.PresetList[0].Command;
            urlString = GetHttpParam(urlString, presetNumber);
          }
          else
          {
            urlString = data.PresetSettings.PresetList[presetNumber].Command;
          }

          try
          {
            urlString = data.ReplaceParmeters(urlString);
            System.Net.HttpWebRequest webRequest = (HttpWebRequest)HttpWebRequest.Create(new Uri(urlString));

            if (data.JpgContactMethod != PTZMethod.BlueIris)
            {
              webRequest.Credentials = new System.Net.NetworkCredential(data.CameraUserName, data.CameraPassword);
            }

            webRequest.Timeout = 5000;

            using System.Net.WebResponse webResponse = await webRequest.GetResponseAsync().ConfigureAwait(true);
          }
          catch (HttpRequestException ex)
          {
            Dbg.Write(LogLevel.Warning, "MainWindow - PresetButton_Click - HttpWebRequest - " + ex.Message);
          }
          catch (Exception ex)
          {
            Dbg.Write(LogLevel.Error, "MainWindow - PresetButton_Click - HttpWebRequest - " + ex.Message);
          }

        }
      }
    }


    private void OnUpdateSolar(Guid id)
    {
      if (id == ID) // only if it is the camera asking for a solar time update
      {
        SolarTimes solarTimes = new (DateTime.Now, Latitude, Longitude);
        Sunset = solarTimes.Sunset;
        Sunrise = solarTimes.Sunrise;
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

    public bool IsItemOfCameraInterest(string label)
    {
      bool result = false;

      foreach (var area in AOI)
      {
        if (area.IsItemOfAreaInterest(label))
        {
          result = true;
          break;
        }
      }

      return result;
    }

    // PathAndPrefix allows us to monitor the directory for motion images.  It also identifies the camera 
    public static string PathAndPrefix(CameraData camera)
    {
      Debug.Assert(camera != null);
      if (camera != null)
      {
        return Path.Combine(camera.CameraPath, camera.CameraPrefix.ToLower());
      }
      else
      {
        return string.Empty;
      }
    }

    // The actual path for monitoring motion images
    public static string WildcardPath(CameraData camera)
    {
      return CameraData.PathAndPrefix(camera) + "\\*.jpg";
    }


    private bool disposedValue = false;

    public static string GetHttpParam(string command, int index)
    {
      string result = command;
      int offsetLoc = command.IndexOf("[OFFSET=");
      if (offsetLoc != -1)
      {
        int tagLen = "[OFFSET=".Length;
        // TODO: Replace with RegularExpression
        // abc[OFFSET=123]
        int offsetEnd = result.IndexOf(']', offsetLoc + tagLen);
        string offsetStr = result[(offsetLoc + tagLen)..offsetEnd];
        int offset = index + int.Parse(offsetStr);
        // get rid of the entire tag
        result = result.Remove(offsetLoc, offsetEnd - offsetLoc + 1);
        result = result.Insert(offsetLoc, offset.ToString()); // now, just replace the string with the desired value
      }
      else
      {
        result = command.Replace("[PRESET]", index.ToString());
      }

      return result;
    }


    protected virtual void Dispose(bool disposing)
    {
      if (!disposedValue)
      {
        if (disposing)
        {
          MotionStoppedTimer?.Dispose();
          Scanner?.Dispose();
          CameraTrigger?.Dispose();
          Monitor?.Dispose();
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

  public enum CameraMethod
  {
    Application,
    OnGuard,
    CameraTriggered
  }

}
