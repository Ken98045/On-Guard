using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.VisualStudio.Threading;

using Mictlanix.DotNet.Onvif;
using Mictlanix.DotNet.Onvif.Common;
using Mictlanix.DotNet.Onvif.Ptz;


namespace OnGuardCore
{
  public class OnVIFSupport
  {
    string _userName;
    string _password;

    AsyncManualResetEvent _initComplete;

    List<ProfileData> _profiles = new ();
    List<string> _snapshotUri = new ();

    volatile public bool _moving;

    private PTZClient ptz;

    private bool continuous_move = false;
    private float panMinRange;
    private float panMaxRange;
    private float tiltMinRange;
    private float tiltMaxRange;
    private float zoomMinRange;
    private float zoomMaxRange;
    private float panSpeedX;
    private float panSpeedY;
    private float zoomSpeed;
    private string selectedProfile;
    private int selectedProfileIndex;
    private string ipAddress;
    private GetPresetsResponse _presetsResponse;

    public PTZClient Ptz { get => ptz; set => ptz = value; }
    public bool Continuous_move { get => continuous_move; set => continuous_move = value; }
    public float PanMinRange { get => panMinRange; set => panMinRange = value; }
    public float PanMaxRange { get => panMaxRange; set => panMaxRange = value; }
    public float TiltMinRange { get => tiltMinRange; set => tiltMinRange = value; }
    public float TiltMaxRange { get => tiltMaxRange; set => tiltMaxRange = value; }
    public float ZoomMinRange { get => zoomMinRange; set => zoomMinRange = value; }
    public float ZoomMaxRange { get => zoomMaxRange; set => zoomMaxRange = value; }
    public float PanSpeedX { get => panSpeedX; set => panSpeedX = value; }
    public float PanSpeedY { get => panSpeedY; set => panSpeedY = value; }
    public float ZoomSpeed { get => zoomSpeed; set => zoomSpeed = value; }
    public string UserName { get => _userName; set => _userName = value; }
    public string Password { get => _password; set => _password = value; }
    public AsyncManualResetEvent InitComplete { get => _initComplete; set => _initComplete = value; }
    public string SelectedProfile { get => selectedProfile; set => selectedProfile = value; }
    public List<ProfileData> Profiles { get => _profiles; set => _profiles = value; }
    public string IpAddress { get => ipAddress; set => ipAddress = value; }
    public List<string> SnapshotUri { get => _snapshotUri; set => _snapshotUri = value; }
    public int SelectedProfileIndex { get => selectedProfileIndex; set => selectedProfileIndex = value; }
    public GetPresetsResponse PresetsResponse { get => _presetsResponse; set => _presetsResponse = value; }

    Mictlanix.DotNet.Onvif.Device.DeviceClient _device;

    public OnVIFSupport()
    {
      InitComplete = new AsyncManualResetEvent(false);
    }

    public async Task Init(string address, int port, string userName, string password)
    {
      IpAddress = string.Format("{0}:{1}", address, port);
      UserName = userName;
      Password = password;


      try
      {
        _device = await OnvifClientFactory.CreateDeviceClientAsync(IpAddress, UserName, Password).ConfigureAwait(true);
        var media = await OnvifClientFactory.CreateMediaClientAsync(IpAddress, UserName, Password);
        Ptz = await OnvifClientFactory.CreatePTZClientAsync(IpAddress, UserName, Password).ConfigureAwait(true);
        var imaging = await OnvifClientFactory.CreateImagingClientAsync(IpAddress, UserName, Password).ConfigureAwait(true);
        var caps = await _device.GetCapabilitiesAsync(new CapabilityCategory[] { CapabilityCategory.All }).ConfigureAwait(true);

        var profiles = await media.GetProfilesAsync().ConfigureAwait(true);

        Debug.WriteLine("Profiles count :" + profiles.Profiles.Length);

        foreach (var profile in profiles.Profiles)
        {
          string profile_token = profile.token;
          ProfileData profileData = new ProfileData
          {
            Name = profile.Name,
            Token = profile.token,
            Width = profile.VideoEncoderConfiguration.Resolution.Width,
            Height = profile.VideoEncoderConfiguration.Resolution.Height
          };
          Profiles.Add(profileData);

          Debug.WriteLine($"Profile: {profile.token}");


          if (Profiles.Count == 1)
          {
            Continuous_move = !string.IsNullOrWhiteSpace(profile.PTZConfiguration.DefaultContinuousPanTiltVelocitySpace);

            if (Continuous_move)
            {
              if (!string.IsNullOrWhiteSpace(profile.PTZConfiguration.DefaultContinuousPanTiltVelocitySpace))
              {
                var pan = profile.PTZConfiguration.PanTiltLimits.Range.XRange;
                if (null != pan)
                {
                  PanMinRange = pan.Min;
                  PanMaxRange = pan.Max;
                }
                var tilt = profile.PTZConfiguration.PanTiltLimits.Range.YRange;
                if (null != tilt)
                {
                  TiltMinRange = tilt.Min;
                  TiltMaxRange = tilt.Max;
                }

                var zoom = profile.PTZConfiguration.ZoomLimits.Range.XRange;
                if (null != zoom)
                {
                  ZoomMinRange = zoom.Min;
                  ZoomMaxRange = zoom.Max;
                }

                var speed = profile.PTZConfiguration.DefaultPTZSpeed;
                if (null != speed)
                {
                  PanSpeedX = speed.PanTilt.x;
                  PanSpeedY = speed.PanTilt.y;
                  ZoomSpeed = speed.Zoom.x;
                }
              }
            }

          }

          PresetsResponse = await ptz.GetPresetsAsync(profile_token).ConfigureAwait(true);
          var snapshot = await media.GetSnapshotUriAsync(profile_token).ConfigureAwait(true);
          SnapshotUri.Add(snapshot.Uri);
        }
      }
      catch (System.ServiceModel.CommunicationException ex)
      {
        Type type = ex.GetType();
        throw ex;
      }
      catch (Exception ex)
      {
        Dbg.Write("OnVIFSupport - Init - Exception: " + ex.Message);
      }


      SelectedProfile = Profiles[0].Token;
      InitComplete.Set();
    }

    public string GetSnapshotUri()
    {
      return SnapshotUri[SelectedProfileIndex];
    }

  }

    public class ProfileData
  {
    string _name;
    string _token;
    int _width;
    int _height;

    public string Name { get => _name; set => _name = value; }
    public string Token { get => _token; set => _token = value; }
    public int Width { get => _width; set => _width = value; }
    public int Height { get => _height; set => _height = value; }
  }


}
