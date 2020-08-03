using System;

namespace SAAI
{

/// <summary>
/// A class to define the way to contact a camera (via BlueIris or otherwise)
/// </summary>
  [Serializable]
  public class CameraContactData
  {
    public string CameraIPAddress { get; set; }
    public int Port { get; set; }
    public string ShortCameraName { get; set; } // used by Blue Iris (not by direct, but it shouldn't matter)
    public string CameraUserName { get; set; } 
    public string CameraPassword { get; set; }

    // The Blue Iris returns an image at this resolution.  The default resolution that BlueIris
    // returns is not necessarily the full camera reasolution.  This allows you to set the value.
    // Setting the value lower may reduce AI object recognition time.
    public int CameraXResolution { get; set; } 
    public int CameraYResolution { get; set; }

    public CameraContactData()
    {
      CameraIPAddress = "localhost";
      Port = 80;
      ShortCameraName = "myCameraName";
      CameraUserName = "me";
      CameraPassword = "password";
      CameraXResolution = 0;
      CameraYResolution = 0;

    }

    public CameraContactData(CameraContactData src)
    {
      CameraIPAddress = src.CameraIPAddress;
      Port = src.Port;
      ShortCameraName = src.ShortCameraName;
      CameraUserName = src.CameraUserName;
      CameraPassword = src.CameraPassword;
      CameraXResolution = src.CameraXResolution;
      CameraYResolution = src.CameraYResolution;
    }

  }
}
