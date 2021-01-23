using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Win32;
using System.Drawing;

namespace SAAI
{
  static public class Storage
  {
    static Storage()
    {
      CreateRegistryTree();
    }

    public static string GetFilePath(string fileName)
    {
      string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
      path = Path.Combine(path, "OnGuard");

      if (!Directory.Exists(path))
      {
        Directory.CreateDirectory(path);
      }

      path = Path.Combine(path, fileName);
      return path;
    }

    static RegistryKey s_base;
    static RegistryKey s_cameras;

    public static void CreateRegistryTree()
    {
      RegistryKey key = Registry.CurrentUser;

      try
      {
        s_base = Registry.CurrentUser;
        key.CreateSubKey(@"Software\K2Software\OnGuard\Cameras", true); // creates the full tree if necessary
        s_base = s_base.OpenSubKey(@"Software\K2Software\OnGuard", true);   // The base area used for global stuff
        s_base.CreateSubKey("AILocations");
        s_cameras = s_base.OpenSubKey("Cameras", true);
        string ver = GetAppVersion();
        if (!string.IsNullOrEmpty(ver))
        {
          SetAppVersion("1-5-2");
        }

      }
      catch (Exception)
      {
      }
    }

    public static void SetAppVersion(string version)
    {
      s_base.SetValue("CurrentVersion", version, RegistryValueKind.String);
    }

    public static string GetAppVersion()
    {
      string result = (string)s_base.GetValue("CurrentVersion", string.Empty);
      return result;
    }

    public static List<EmailOptions> GetEmailAddresses()
    {
      List<EmailOptions> addresses = new List<EmailOptions>();

      using (RegistryKey key = s_base.OpenSubKey("EmailAddresses"))
      {
        if (null != key)
        {
          foreach (string address in key.GetSubKeyNames())
          {
            using (RegistryKey option = key.OpenSubKey(address))
            {
              EmailOptions opt = new EmailOptions();
              {
                opt.EmailAddress = address;
                opt.NumberOfImages = (int)option.GetValue("NumberOfImages", 0);
                opt.AllTheTime = bool.Parse((string)(option.GetValue("AllTheTime")));
                opt.StartTime = DateTime.Parse((string)option.GetValue("StartTime", "12:00am"));
                opt.EndTime = DateTime.Parse((string)option.GetValue("EndTime", "11:59:59pm"));
                opt.SizeDownToPercent = (int)option.GetValue("SizeDownPercent", 20);
                opt.CoolDown = new EmailCooldown((int)option.GetValue("CooldownTime"));
                opt.DaysOfWeek[0] = bool.Parse((string)option.GetValue("Sunday"));
                opt.DaysOfWeek[1] = bool.Parse((string)option.GetValue("Monday"));
                opt.DaysOfWeek[2] = bool.Parse((string)option.GetValue("Tuesday"));
                opt.DaysOfWeek[3] = bool.Parse((string)option.GetValue("Wednesday"));
                opt.DaysOfWeek[4] = bool.Parse((string)option.GetValue("Thursday"));
                opt.DaysOfWeek[5] = bool.Parse((string)option.GetValue("Friday"));
                opt.DaysOfWeek[6] = bool.Parse((string)option.GetValue("Saturday"));
              }

              addresses.Add(opt);
            }
          }
        }
      }

      return addresses;
    }

    public static void SaveEmailAddresses(List<EmailOptions> addresses)
    {
      if (addresses != null)
      {
        s_base.DeleteSubKeyTree("EmailAddresses", false);

        using (RegistryKey key = s_base.CreateSubKey("EmailAddresses"))
        {
          foreach (var address in addresses)
          {
            using (RegistryKey addr = key.CreateSubKey(address.EmailAddress, true))
            {
              addr.SetValue("NumberOfImages", address.NumberOfImages, RegistryValueKind.DWord);
              addr.SetValue("AllTheTime", address.AllTheTime.ToString(), RegistryValueKind.String);
              addr.SetValue("StartTime", address.StartTime.ToString(), RegistryValueKind.String);
              addr.SetValue("EndTime", address.EndTime.ToString(), RegistryValueKind.String);
              addr.SetValue("SizeDownPercent", address.SizeDownToPercent, RegistryValueKind.DWord);
              addr.SetValue("CooldownTime", address.CoolDown.CooldownTime, RegistryValueKind.DWord);
              addr.SetValue("Sunday", address.DaysOfWeek[0].ToString(), RegistryValueKind.String);
              addr.SetValue("Monday", address.DaysOfWeek[1].ToString(), RegistryValueKind.String);
              addr.SetValue("Tuesday", address.DaysOfWeek[2].ToString(), RegistryValueKind.String);
              addr.SetValue("Wednesday", address.DaysOfWeek[3].ToString(), RegistryValueKind.String);
              addr.SetValue("Thursday", address.DaysOfWeek[4].ToString(), RegistryValueKind.String);
              addr.SetValue("Friday", address.DaysOfWeek[5].ToString(), RegistryValueKind.String);
              addr.SetValue("Saturday", address.DaysOfWeek[6].ToString(), RegistryValueKind.String);
            }
          }
        }
      }
    }


    public static SortedDictionary<Guid, AreaOfInterest> GetAllAreas(string cameraPath, string cameraPrefix)
    {
      SortedDictionary<Guid, AreaOfInterest> areas = new SortedDictionary<Guid, AreaOfInterest>();

      using (RegistryKey camKey = FindCameraKey(cameraPath, cameraPrefix))
      {
        if (null != camKey)
        {
          foreach (var areaID in camKey.GetSubKeyNames()) // A GUID
          {
            AreaOfInterest area = GetArea(camKey, Guid.Parse(areaID));
            areas.Add(area.ID, area);
          }
        }
      }

      return areas;
    }

    public static AreaOfInterest GetArea(RegistryKey camKey, Guid areaID)
    {
      using (RegistryKey key = camKey.OpenSubKey(areaID.ToString()))
      {
        int x = (int)key.GetValue("x");
        int y = (int)key.GetValue("y");
        int width = (int)key.GetValue("width");
        int height = (int)key.GetValue("height");
        Rectangle rect = new Rectangle(x, y, width, height);

        AreaOfInterest area = new AreaOfInterest(
        areaID,
        (string)key.GetValue("AreaName"),
        (AOIType)Enum.Parse(typeof(AOIType), (string)key.GetValue("AOIType")),
        rect,
        (int)key.GetValue("OriginalXResolution"),
        (int)key.GetValue("OriginalYResolution"),
        (MovementType)Enum.Parse(typeof(MovementType), (string)key.GetValue("MovementType")),
        GetNotificationOption(key),
        GetCharacteristics(key)
        );

        return area;
      }
    }

    public static void SaveArea(RegistryKey camKey, AreaOfInterest area)
    {
      camKey.DeleteSubKeyTree(area.ID.ToString(), false);

      using (RegistryKey key = camKey.CreateSubKey(area.ID.ToString(), true))
      {
        key.SetValue("x", area.AreaRect.X, RegistryValueKind.DWord);
        key.SetValue("y", area.AreaRect.Y, RegistryValueKind.DWord);
        key.SetValue("width", area.AreaRect.Width, RegistryValueKind.DWord);
        key.SetValue("height", area.AreaRect.Height, RegistryValueKind.DWord);
        key.SetValue("AreaName", area.AOIName, RegistryValueKind.String);
        key.SetValue("AOIType", area.AOIType.ToString(), RegistryValueKind.String);
        key.SetValue("OriginalXResolution", area.OriginalXResolution, RegistryValueKind.DWord);
        key.SetValue("OriginalYResolution", area.OriginalYResolution, RegistryValueKind.DWord);
        key.SetValue("MovementType", area.MovementType.ToString(), RegistryValueKind.String);
        SaveNotificationOption(key, area.Notifications);
        SaveCharacteristcs(key, area.SearchCriteria);
      }
    }

    public static void SaveArea(AreaOfInterest area)
    {
      using (RegistryKey key = FindCameraKey(GetGlobalString("CurrentCameraPath"), GetGlobalString("CurrentCameraPrefix")))
      {
        SaveArea(key, area);
      }
    }

    public static void SaveArea(string cameraPath, string cameraPrefix, AreaOfInterest area)
    {
      using (RegistryKey camKey = FindCameraKey(cameraPath, cameraPrefix))
      {
        SaveArea(camKey, area);
      }
    }

    public static void DeleteArea(string cameraPath, string cameraPrefix, AreaOfInterest area)
    {
      using (RegistryKey camKey = FindCameraKey(cameraPath, cameraPrefix))
      {
        camKey.DeleteSubKey(area.ID.ToString());
      }
    }

    static RegistryKey FindCameraKey(string cameraPath, string cameraPrefix)
    {
      RegistryKey camKey;

      foreach (var cameraID in s_cameras.GetSubKeyNames())
      {
        camKey = s_cameras.OpenSubKey(cameraID, true);
        string path = (string)camKey.GetValue("Path");
        string prefix = (string)camKey.GetValue("Prefix");

        if (path == cameraPath && prefix == cameraPrefix)
        {
          return camKey;
        }
      }

      return null;
    }

    public static void SaveArea(CameraData cam, AreaOfInterest area)
    {
      using (RegistryKey cameraKey = FindCameraKey(cam.Path, cam.CameraPrefix))
      {
        if (null != cameraKey)
        {
          SaveArea(cameraKey, area);
        }
      }
    }

    // Temporarily just mimic the old file based one.
    // TODO: Just save each area individually
    public static void SaveAllAreas(string cameraPath, string cameraPrefix, AreasOfInterestCollection areas)
    {
      using (RegistryKey cameraKey = FindCameraKey(cameraPath, cameraPrefix))
      {
        if (null != cameraKey)
        {
          foreach (AreaOfInterest area in areas)
          {
            SaveArea(cameraKey, area);
          }
        }
      }
    }

    public static void SaveCharacteristcs(RegistryKey key, List<ObjectCharacteristics> objectChar)
    {
      using (RegistryKey searchCritera = key.CreateSubKey("SearchCriteria"))
      {
        foreach (var obj in objectChar)
        {
          using (RegistryKey objKey = searchCritera.CreateSubKey(obj.ID.ToString(), true))
          {
            objKey.SetValue("ImageObjectType", obj.ObjectType.ToString());
            objKey.SetValue("Confidence", obj.Confidence, RegistryValueKind.DWord);
            objKey.SetValue("Overlap", obj.MinPercentOverlap, RegistryValueKind.DWord);
            objKey.SetValue("TimeFrame", obj.TimeFrame, RegistryValueKind.DWord);
            objKey.SetValue("MinimumXSize", obj.MinimumXSize, RegistryValueKind.DWord);
            objKey.SetValue("MinimumYSize", obj.MinimumYSize, RegistryValueKind.DWord);
          }
        }
      }
    }

    public static List<ObjectCharacteristics> GetCharacteristics(RegistryKey key)
    {
      List<ObjectCharacteristics> list = new List<ObjectCharacteristics>();
      using (RegistryKey searchCriteria = key.OpenSubKey("SearchCriteria"))
      {
        if (null != searchCriteria)
        {
          foreach (string objectID in searchCriteria.GetSubKeyNames())
          {
            ObjectCharacteristics obj = new ObjectCharacteristics();

            using (RegistryKey optionKey = searchCriteria.OpenSubKey(objectID))
            {
              obj.ID = Guid.Parse(objectID);
              string objType = (string)optionKey.GetValue("ImageObjectType");
              obj.ObjectType = objType;
              obj.Confidence = (int)optionKey.GetValue("Confidence");
              obj.MinPercentOverlap = (int)optionKey.GetValue("Overlap");
              obj.TimeFrame = (int)optionKey.GetValue("TimeFrame");
              obj.MinimumXSize = (int)optionKey.GetValue("MinimumXSize");
              obj.MinimumYSize = (int)optionKey.GetValue("MinimumYSize");
            }

            list.Add(obj);
          }
        }
      }

      return list;
    }

    public static void SaveNotificationOption(RegistryKey key, AreaNotificationOption options)
    {
      key.SetValue("UseMQTT", options.UseMQTT.ToString(), RegistryValueKind.String);
      key.SetValue("MQTTCooldown", options.mqttCooldown.CooldownTime, RegistryValueKind.DWord);
      key.SetValue("MQTTMotionStopped", options.NoMotionMQTTNotify.ToString(), RegistryValueKind.String);

      if (!string.IsNullOrEmpty(options.NoMotionUrlNotify))
      {
        key.SetValue("MotionStoppedURL", options.NoMotionUrlNotify, RegistryValueKind.String);
      }

      key.DeleteSubKeyTree("URLs", false);  // we are recreating it.

      using (RegistryKey urls = key.CreateSubKey("URLs", true))
      {
        foreach (var notifyOption in options.Urls)
        {
          if (!string.IsNullOrEmpty(notifyOption.Url))
          {
            using (RegistryKey urlKey = urls.CreateSubKey(notifyOption.ID.ToString(), true))
            {
              urlKey.SetValue("URL", notifyOption.Url, RegistryValueKind.String);
              urlKey.SetValue("CoolDown", notifyOption.CoolDown.CooldownTime, RegistryValueKind.DWord);
              urlKey.SetValue("WaitTime", notifyOption.WaitTime, RegistryValueKind.DWord);
              urlKey.SetValue("BIFlags", notifyOption.BIFlags, RegistryValueKind.DWord);
            }
          }
        }
      }

      using (RegistryKey emails = key.CreateSubKey("Emails", true))
      {
        foreach (var email in options.Email)
        {
          emails.CreateSubKey(email, true);
        }
      }
    }

    public static AreaNotificationOption GetNotificationOption(RegistryKey key)
    {
      AreaNotificationOption notify = new AreaNotificationOption
      {
        UseMQTT = bool.Parse((string)key.GetValue("UseMQTT")),   // save true/false as string to make it more readable
        mqttCooldown = new MQTTCoolDown((int)key.GetValue("MQTTCooldown")),
        NoMotionMQTTNotify = bool.Parse((string)key.GetValue("MQTTMotionStopped")),
        NoMotionUrlNotify = (string)key.GetValue("MotionStoppedURL")
      };

      using (RegistryKey urls = key.OpenSubKey("URLs"))
      {
        foreach (var urlID in urls.GetSubKeyNames())
        {
          using (RegistryKey optionKey = urls.OpenSubKey(urlID))
          {
            UrlOptions opt = new UrlOptions((string)optionKey.GetValue("URL"), (int)optionKey.GetValue("WaitTime"), (int)optionKey.GetValue("CoolDown"), (int)optionKey.GetValue("BIFlags"))
            {
              ID = Guid.Parse(urlID) // to keep it the same for debug otherwise not necessary
            };
            notify.Urls.Add(opt);
          }
        }
      }

      using (RegistryKey emails = key.OpenSubKey("Emails"))
      {
        if (null != emails)
        {
          foreach (var email in emails.GetSubKeyNames())
          {
            notify.Email.Add(email);  // for email (the key name is the email name
          }
        }
      }
      return notify;
    }

    public static List<AILocation> GetAILocations()
    {
      List<AILocation> result = new List<AILocation>();

      using (RegistryKey key = s_base.OpenSubKey("AILocations"))
      {
        foreach (string locationID in key.GetSubKeyNames())
        {
          using (RegistryKey locationKey = key.OpenSubKey(locationID))
          {
            AILocation location = new AILocation(Guid.Parse(locationID), (string)locationKey.GetValue("IPAddress"), (int)locationKey.GetValue("Port"));
            result.Add(location);
          }
        }
      }

      return result;
    }

    public static void SetAILocation(AILocation location)
    {
      using (RegistryKey key = s_base.OpenSubKey("AILocations", true))
      {
        using (RegistryKey aiKey = key.CreateSubKey(location.ID.ToString(), true))
        {
          aiKey.SetValue("IPAddress", location.IPAddress, RegistryValueKind.String);
          aiKey.SetValue("Port", location.Port, RegistryValueKind.DWord);
        }
      }
    }

    public static void RemoveAILocation(string id)
    {
      using (RegistryKey key = s_base.OpenSubKey("AILocations", true))
      {
        key.DeleteSubKey(id, false);
      }
    }

    public static void RemoveGlobalValue(string valueName)
    {
      s_base.DeleteValue(valueName, false);
    }

    public static string GetCameraPrefix(RegistryKey reg)
    {
      string prefix = (string)reg.GetValue("Prefix");
      return prefix;
    }

    public static string GetCameraPath(RegistryKey key, string pathAndPrefix)
    {
      string path = (string)key.GetValue("Path");
      return path;
    }

    public static CameraContactData GetContactData(RegistryKey key)
    {
      CameraContactData data = new CameraContactData
      {
        CameraIPAddress = (string)key.GetValue("IPAddress"),
        CameraPassword = (string)key.GetValue("CameraPassword"),
        CameraUserName = (string)key.GetValue("UserName"),
        CameraXResolution = (int)key.GetValue("XResolution"),
        CameraYResolution = (int)key.GetValue("YResolution"),
        Port = (int)key.GetValue("Port"),
        ShortCameraName = (string)key.GetValue("CameraName")
      };

      return data;
    }

    public static CameraCollection GetAllCameras()
    {
      CameraCollection cameras = new CameraCollection
      {
        CurrentCameraPath = (string)s_cameras.GetValue("CurrentCamera")
      };

      foreach (var camKeyName in s_cameras.GetSubKeyNames())
      {
        using (RegistryKey camKey = s_cameras.OpenSubKey(camKeyName))
        {
          string cameraPrefix = GetCameraPrefix(camKey);
          string cameraPath = GetCameraPath(camKey, camKeyName);  // contains path + prefix
          CameraData cam = new CameraData(cameraPrefix, cameraPath)
          {
            RegistrationX = (int)camKey.GetValue("RegistrationX", 500),
            RegistrationY = (int)camKey.GetValue("RegistrationY", 500),
            RegistrationXResolution = (int)camKey.GetValue("RegistrationXResolution", 1280),
            RegistrationYResolution = (int)camKey.GetValue("RegistrationYResolution", 1024),
            Monitoring = bool.Parse((string)camKey.GetValue("Monitoring", "true")),
            NoMotionTimeout = (int)camKey.GetValue("MotionStoppedTimeout", 90),
            LiveContactData = GetContactData(camKey)
          }; // GetCamera(

          if (cam.RegistrationX > 5000 || cam.RegistrationX < -1000)
          {
            Dbg.Write("Bad Read on Registration X");
          }

          if (cam.RegistrationY < -500 || cam.RegistrationY > 3000)
          {
            Dbg.Write("Bad Read on Registraion Y");
          }

          cameras.AddCamera(cam);
        }
      }

      return cameras;
    }

    public static void SetCameraContactData(RegistryKey key, CameraContactData data)
    {
      key.SetValue("IPAddress", data.CameraIPAddress, RegistryValueKind.String);
      key.SetValue("CameraPassword", data.CameraPassword, RegistryValueKind.String);
      key.SetValue("UserName", data.CameraUserName, RegistryValueKind.String);
      key.SetValue("XResolution", data.CameraXResolution, RegistryValueKind.DWord);
      key.SetValue("YResolution", data.CameraYResolution, RegistryValueKind.DWord);
      key.SetValue("Port", data.Port, RegistryValueKind.DWord);
      key.SetValue("CameraName", data.ShortCameraName, RegistryValueKind.String);
    }


    public static void SaveCamera(RegistryKey camKey, CameraData camera)
    {
      camKey.SetValue("Prefix", camera.CameraPrefix);
      camKey.SetValue("Path", camera.Path);
      SetCameraContactData(camKey, camera.LiveContactData);
      camKey.SetValue("MotionStoppedTimeout", camera.NoMotionTimeout, RegistryValueKind.DWord);
      if (camera.RegistrationX > 5000 || camera.RegistrationX < -1000)
      {
        Dbg.Write("Bad X registration value on Write");
      }
      camKey.SetValue("RegistrationX", camera.RegistrationX, RegistryValueKind.DWord);
      if (camera.RegistrationY > 3000 || camera.RegistrationY < -500)
      {
        Dbg.Write("Bad Y registration value on Write");
      }
      camKey.SetValue("RegistrationY", camera.RegistrationY, RegistryValueKind.DWord);
      camKey.SetValue("RegistrationXResolution", camera.RegistrationXResolution, RegistryValueKind.DWord);
      camKey.SetValue("RegistrationYResolution", camera.RegistrationYResolution, RegistryValueKind.DWord);
      camKey.SetValue("Monitoring", camera.Monitoring.ToString(), RegistryValueKind.String);

      foreach (AreaOfInterest area in camera.AOI)
      {
        SaveArea(camKey, area);
      }

    }

    public static void SaveCameras(CameraCollection allCameras)
    {
      // Since we are saving everything we need to get rid of the old data
      foreach (string keyName in s_cameras.GetSubKeyNames())
      {
        s_cameras.DeleteSubKeyTree(keyName, false);
      }

      // Now we can save the new data
      s_cameras.SetValue("CurrentCamera", allCameras.CurrentCameraPath, RegistryValueKind.String);

      foreach (CameraData camera in allCameras.CameraDictionary.Values)
      {
        using (RegistryKey camKey = s_cameras.CreateSubKey(camera.ID.ToString(), true))
        {
          SaveCamera(camKey, camera);
        }
      }
    }

    public static string GetGlobalString(string keyName)
    {
      return (string)s_base.GetValue(keyName, string.Empty);
    }

    public static int GetGlobalInt(string keyName)
    {
      return (int)s_base.GetValue(keyName, 0);
    }

    public static void SetGlobalString(string keyName, string value)
    {
      s_base.SetValue(keyName, value, RegistryValueKind.String);
    }

    public static void SetGlobalInt(string keyName, int value)
    {
      s_base.SetValue(keyName, value, RegistryValueKind.DWord);
    }

    public static void SetGlobalBool(string keyName, bool value)
    {
      SetGlobalString(keyName, value.ToString());
    }

    public static bool GetGlobalBool(string keyName)
    {
      bool result = false;
      string str = GetGlobalString(keyName);
      if (!string.IsNullOrEmpty(str))
      {
        result = bool.Parse(str);
      }
      return result;
    }

    public static void SetGlobalDouble(string keyName, double value)
    {
      s_base.SetValue(keyName, value.ToString(), RegistryValueKind.String);
    }

    public static double GetGlobalDouble(string keyName)
    {
      double result = 0;
      string str = (string)s_base.GetValue(keyName, string.Empty);
      if (!string.IsNullOrEmpty(str))
      {
        result = double.Parse(str);
      }

      return result;
    }


  }
}

