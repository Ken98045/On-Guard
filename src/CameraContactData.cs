using System;
using System.Threading.Tasks;
using System.Web;

namespace OnGuardCore
{

  public enum PTZMethod
  {
    None,
    BlueIris,
    OnVIF,
    iSpy,
    HTTP
  }


  /// <summary>
  /// A class to define the way to contact a camera (via BlueIris or otherwise)
  /// </summary>
  [Serializable]
  public class CameraContactData
  {
    public string CameraIPAddress { get; set; }
    public int Port { get; set; }
    public int OnVIFPort { get; set; }
    // public string SnapshotURL { get; set; } 
    public string CameraShortName { get; set; }     // used by Blue Iris only
    public string CameraUserName { get; set; }
    public string CameraPassword { get; set; }
    public string JPGSnapshotURL { get; set; }


    // New (3.0) contact data
    public PTZMethod JpgContactMethod { get; set; }
    public PTZMethod PTZContactMethod { get; set; }

    public string JpgCameraMake { get; set; }
    public string JpgCameraModel { get; set; }
    public string PTZCameraMake { get; set; }
    public string PTZCameraModel { get; set; }

    public string HTTPPanRight { get; set; }
    public string HTTPPanLeft { get; set; }
    public string HTTPPanUp { get; set; }
    public string HTTPPanDown { get; set; }
    public string HTTPZoomIn { get; set; }
    public string HTTPZoomOut { get; set; }
    public string HTTPStop { get; set; }
    public double PanTime { get; set; }
    public double TiltTime { get; set; }
    public double ZoomTime { get; set; }
    public double PanSpeed { get; set; }
    public double TiltSpeed { get; set; }
    public double ZoomSpeed { get; set; }

    public PresetInfo PresetSettings { get; set; }

    // The Blue Iris (maybe HTTP, iSpy) returns an image at this resolution.  The default resolution that BlueIris
    // returns is not necessarily the full camera reasolution.  This allows you to set the value.
    // Setting the value lower may reduce AI object recognition time.
    public int CameraXResolution { get; set; } 
    public int CameraYResolution { get; set; }
    public int CameraChannel { get; set; }

    public OnVIFSupport ONVIF { get; set; }

    public CameraContactData()
    {
      CameraIPAddress = "localhost";
      Port = 80;
      OnVIFPort = 8080;
      JPGSnapshotURL = string.Empty;
      CameraUserName = "me";
      CameraPassword = "password";
      CameraXResolution = 0;
      CameraYResolution = 0;
      CameraChannel = 0;
      CameraShortName = string.Empty;
      JpgCameraMake = string.Empty;
      JpgCameraModel = string.Empty;
      PTZCameraMake = string.Empty;
      PTZCameraModel = string.Empty;

      JPGSnapshotURL = string.Empty;
      HTTPPanDown = string.Empty;
      HTTPPanUp = string.Empty;
      HTTPPanLeft = string.Empty;
      HTTPPanRight = string.Empty;
      HTTPZoomIn = string.Empty;
      HTTPZoomOut = string.Empty;
      HTTPStop = string.Empty;
      ONVIF = new OnVIFSupport(); // placeholder for ONVIF stuff until the init



      JpgContactMethod = PTZMethod.BlueIris;
      PTZContactMethod = PTZMethod.BlueIris;


      PresetSettings = new PresetInfo(PTZMethod.BlueIris);

    }

    public CameraContactData(CameraContactData src)
    {
      if (null != src)
      {
        CameraIPAddress = src.CameraIPAddress;
        Port = src.Port;
        OnVIFPort = src.OnVIFPort;
        JPGSnapshotURL = src.JPGSnapshotURL;
        CameraShortName = src.CameraShortName;
        CameraUserName = src.CameraUserName;
        CameraPassword = src.CameraPassword;
        CameraXResolution = src.CameraXResolution;
        CameraYResolution = src.CameraYResolution;
        CameraChannel = src.CameraChannel;

        JpgContactMethod = src.JpgContactMethod;
        JpgCameraMake = src.JpgCameraMake;
        JpgCameraModel = src.JpgCameraModel;
        PTZCameraMake = src.PTZCameraMake;
        PTZCameraModel = src.PTZCameraModel;
        JPGSnapshotURL = src.JPGSnapshotURL;

        PresetSettings = src.PresetSettings;

        PTZContactMethod = src.PTZContactMethod;
        HTTPPanDown = src.HTTPPanDown;
        HTTPPanLeft = src.HTTPPanLeft;
        HTTPPanRight = src.HTTPPanRight;
        HTTPPanUp = src.HTTPPanUp;
        HTTPZoomIn = src.HTTPZoomIn;
        HTTPZoomOut = src.HTTPZoomOut;
        HTTPStop = src.HTTPStop;

        PanSpeed = src.PanSpeed;
        TiltSpeed = src.TiltSpeed;
        ZoomSpeed = src.ZoomSpeed;

        PanTime = src.PanTime;
        TiltTime = src.TiltTime;
        ZoomTime = src.ZoomTime;
        ONVIF = src.ONVIF;

      }
    }

    public async Task InitAsync()
    {
      if (JpgContactMethod == PTZMethod.OnVIF || PTZContactMethod == PTZMethod.OnVIF || PresetSettings.PresetMethod == PTZMethod.OnVIF)
      {
        await ONVIF.Init(CameraIPAddress, OnVIFPort, CameraUserName, CameraPassword).ConfigureAwait(true); ;
      }
    }

    public string ReplaceParmeters(string url)
    {
      string result = url;
      string addr = CameraIPAddress + ":" + Port.ToString();
      result = result.Replace("[ADDRESS]", addr);
      result = result.Replace("[USERNAME]", HttpUtility.UrlEncode(CameraUserName));
      result = result.Replace("[PASSWORD]", HttpUtility.UrlEncode(CameraPassword));
      result = result.Replace("[WIDTH]", CameraXResolution.ToString());
      result = result.Replace("[HEIGHT]", CameraYResolution.ToString());
      result = result.Replace("[CHANNEL]", CameraChannel.ToString());
      result = result.Replace("[SHORTNAME]", HttpUtility.UrlEncode(CameraShortName));
      return result;
    }

  }
}
