﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Win32;
using System.Drawing;


namespace OnGuardCore
{
  public class RegistryStorage : IStorage
  {
    public RegistryStorage()
    {
      CreateBaseTree();
    }


    RegistryKey _base;
    RegistryKey _cameras;

    public void CreateBaseTree()
    {
      RegistryKey key = Registry.CurrentUser;

      try
      {
        _base = Registry.CurrentUser;
        key.CreateSubKey(@"Software\K2Software\OnGuard\Cameras", true); // creates the full tree if necessary
        _base = _base.OpenSubKey(@"Software\K2Software\OnGuard", true);   // The base area used for global stuff
        _base.CreateSubKey("AILocations");
        _cameras = _base.OpenSubKey("Cameras", true);
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

    public void SetAppVersion(string version)
    {
      _base.SetValue("CurrentVersion", version, RegistryValueKind.String);
    }

    public string GetAppVersion()
    {
      string result = (string)_base.GetValue("CurrentVersion", string.Empty);
      return result;
    }

    public List<EmailOptions> GetEmailAddresses()
    {
      List<EmailOptions> addresses = new List<EmailOptions>();

      using (RegistryKey key = _base.OpenSubKey("EmailAddresses"))
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

    public void SaveEmailAddresses(List<EmailOptions> addresses)
    {
      if (addresses != null)
      {
        _base.DeleteSubKeyTree("EmailAddresses", false);

        using (RegistryKey key = _base.CreateSubKey("EmailAddresses"))
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


    public SortedDictionary<Guid, AreaOfInterest> GetAllAreas(string cameraPath, string cameraPrefix)
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

    private AreaOfInterest GetArea(RegistryKey camKey, Guid areaID)
    {
      if (camKey != null && areaID != Guid.Empty)
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
      else
      {
        return null;
      }
    }

    private void SaveArea(RegistryKey camKey, AreaOfInterest area)
    {
      if (camKey != null && area != null)
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
    }

    public void SaveArea(AreaOfInterest area)
    {
      using (RegistryKey key = FindCameraKey(GetGlobalString("CurrentCameraPath"), GetGlobalString("CurrentCameraPrefix")))
      {
        SaveArea(key, area);
      }
    }

    public void SaveArea(string cameraPath, string cameraPrefix, AreaOfInterest area)
    {
      using (RegistryKey camKey = FindCameraKey(cameraPath, cameraPrefix))
      {
        SaveArea(camKey, area);
      }
    }

    public void DeleteArea(string cameraPath, string cameraPrefix, AreaOfInterest area)
    {
      if (!string.IsNullOrEmpty(cameraPath) && !string.IsNullOrEmpty(cameraPrefix) && area != null)
      {
        using (RegistryKey camKey = FindCameraKey(cameraPath, cameraPrefix))
        {
          camKey.DeleteSubKey(area.ID.ToString());
        }
      }
    }

    RegistryKey FindCameraKey(string cameraPath, string cameraPrefix)
    {
      RegistryKey camKey;

      foreach (var cameraID in _cameras.GetSubKeyNames())
      {
        camKey = _cameras.OpenSubKey(cameraID, true);
        string path = (string)camKey.GetValue("Path");
        string prefix = (string)camKey.GetValue("Prefix");

        if (path == cameraPath && prefix == cameraPrefix)
        {
          return camKey;
        }
      }

      return null;
    }

    public void SaveArea(CameraData cam, AreaOfInterest area)
    {
      if (cam != null && area != null)
      {
        using (RegistryKey cameraKey = FindCameraKey(cam.Path, cam.CameraPrefix))
        {
          if (null != cameraKey)
          {
            SaveArea(cameraKey, area);
          }
        }
      }

    }

    // Temporarily just mimic the old file based one.
    // TODO: Just save each area individually
    public void SaveAllAreas(string cameraPath, string cameraPrefix, AreasOfInterestCollection areas)
    {
      if (!string.IsNullOrEmpty(cameraPath) && !string.IsNullOrEmpty(cameraPrefix) && areas != null)
      {
        using (RegistryKey cameraKey = FindCameraKey(cameraPath, cameraPrefix))
        {
          if (null != cameraKey)
          {
            // First delete the areas to account for area deletion
            foreach (string areaKeyName in cameraKey.GetSubKeyNames())
            {
              cameraKey.DeleteSubKeyTree(areaKeyName, false);
            }

            foreach (AreaOfInterest area in areas)
            {
              SaveArea(cameraKey, area);
            }
          }
        }
      }

    }

    private void SaveCharacteristcs(RegistryKey key, List<ObjectCharacteristics> objectChar)
    {
      if (key != null && objectChar != null)
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

    }

    private List<ObjectCharacteristics> GetCharacteristics(RegistryKey key)
    {
      List<ObjectCharacteristics> list = new List<ObjectCharacteristics>();
      if (key != null)
      {
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
      }
      return list;
    }

    private void SaveNotificationOption(RegistryKey key, AreaNotificationOption options)
    {
      if (key != null && options != null)
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
    }

    private AreaNotificationOption GetNotificationOption(RegistryKey key)
    {
      AreaNotificationOption notify = null;
      if (key != null)
      {
        notify = new AreaNotificationOption
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
      }
      return notify;
    }

    public List<AILocation> GetAILocations()
    {
      List<AILocation> result = new List<AILocation>();
      using (RegistryKey key = _base.OpenSubKey("AILocations"))
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

    public void SetAILocation(AILocation location)
    {
      if (location != null)
      {
        using (RegistryKey key = _base.OpenSubKey("AILocations", true))
        {
          using (RegistryKey aiKey = key.CreateSubKey(location.ID.ToString(), true))
          {
            aiKey.SetValue("IPAddress", location.IPAddress, RegistryValueKind.String);
            aiKey.SetValue("Port", location.Port, RegistryValueKind.DWord);
          }
        }
      }

    }

    public void RemoveAILocation(string id)
    {
      using (RegistryKey key = _base.OpenSubKey("AILocations", true))
      {
        key.DeleteSubKey(id, false);
      }
    }

    public void RemoveGlobalValue(string valueName)
    {
      _base.DeleteValue(valueName, false);
    }

    private string GetCameraPrefix(RegistryKey reg)
    {
      string prefix = string.Empty;
      if (reg != null)
      {
        prefix = (string)reg.GetValue("Prefix");
      }
      return prefix;
    }

    private string GetCameraPath(RegistryKey key)
    {
      string path = string.Empty;
      if (key != null)
      {
        path = (string)key.GetValue("Path");
      }
      return path;
    }

    private CameraContactData GetContactData(RegistryKey key)
    {
      if (key != null)
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
      else
      {
        return null;
      }

    }

    public CameraCollection GetAllCameras()
    {
      CameraCollection cameras = new CameraCollection
      {
        CurrentCameraPath = (string)_cameras.GetValue("CurrentCamera")
      };

      foreach (var camKeyName in _cameras.GetSubKeyNames())
      {
        using (RegistryKey camKey = _cameras.OpenSubKey(camKeyName, true))
        {
          string cameraPrefix = GetCameraPrefix(camKey);
          string cameraPath = GetCameraPath(camKey);  // contains path + prefix
          int registrationX = (int)camKey.GetValue("RegistrationX", 500);
          int registrationY = (int)camKey.GetValue("RegistrationY", 500);

          CameraData cam = new CameraData(Guid.Parse(camKeyName), cameraPrefix, cameraPath);
          cam.RegistrationX = registrationX;
          cam.RegistrationY = registrationY;
          cam.RegistrationXResolution = (int)camKey.GetValue("RegistrationXResolution", 1280);
          cam.RegistrationYResolution = (int)camKey.GetValue("RegistrationYResolution", 1024);
          cam.Monitoring = bool.Parse((string)camKey.GetValue("Monitoring", "true"));
          cam.NoMotionTimeout = (int)camKey.GetValue("MotionStoppedTimeout", 90);
          cam.LiveContactData = GetContactData(camKey);

          cameras.AddCamera(cam);
        }
      }

      return cameras;
    }

    public int GetCameraInt(string cameraPath, string cameraPrefix, string keyName)
    {
      int result = 0;

      using (RegistryKey key = FindCameraKey(cameraPath, cameraPrefix))
      {
        result = (int)key.GetValue(keyName, 0);
      }

      return result;
    }

    public void SetCameraInt(string cameraPath, string cameraPrefix, string keyName, int theValue)
    {
      using (RegistryKey key = FindCameraKey(cameraPath, cameraPrefix))
      {
        key.SetValue(keyName, theValue, RegistryValueKind.DWord);
      }

    }


    private void SetCameraContactData(RegistryKey key, CameraContactData data)
    {
      if (key != null && data != null)
      {
        key.SetValue("IPAddress", data.CameraIPAddress, RegistryValueKind.String);
        key.SetValue("CameraPassword", data.CameraPassword, RegistryValueKind.String);
        key.SetValue("UserName", data.CameraUserName, RegistryValueKind.String);
        key.SetValue("XResolution", data.CameraXResolution, RegistryValueKind.DWord);
        key.SetValue("YResolution", data.CameraYResolution, RegistryValueKind.DWord);
        key.SetValue("Port", data.Port, RegistryValueKind.DWord);
        key.SetValue("CameraName", data.ShortCameraName, RegistryValueKind.String);
      }
    }


    private void SaveCamera(RegistryKey camKey, CameraData camera)
    {
      if (camKey != null && camera != null)
      {
        camKey.SetValue("Prefix", camera.CameraPrefix);
        camKey.SetValue("Path", camera.Path);
        SetCameraContactData(camKey, camera.LiveContactData);
        camKey.SetValue("MotionStoppedTimeout", camera.NoMotionTimeout, RegistryValueKind.DWord);


        camKey.SetValue("RegistrationX", camera.RegistrationX, RegistryValueKind.DWord);
        camKey.SetValue("RegistrationY", camera.RegistrationY, RegistryValueKind.DWord);
        camKey.SetValue("RegistrationXResolution", camera.RegistrationXResolution, RegistryValueKind.DWord);
        camKey.SetValue("RegistrationYResolution", camera.RegistrationYResolution, RegistryValueKind.DWord);
        camKey.SetValue("Monitoring", camera.Monitoring.ToString(), RegistryValueKind.String);

        foreach (AreaOfInterest area in camera.AOI)
        {
          SaveArea(camKey, area);
        }
      }

    }

    public void SaveCameras(CameraCollection allCameras)
    {
      if (null != allCameras)
      {
        // Since we are saving everything we need to get rid of the old data
        foreach (string keyName in _cameras.GetSubKeyNames())
        {
          _cameras.DeleteSubKeyTree(keyName, false);
        }

        // Now we can save the new data
        _cameras.SetValue("CurrentCamera", allCameras.CurrentCameraPath, RegistryValueKind.String);

        foreach (CameraData camera in allCameras.CameraDictionary.Values)
        {
          using (RegistryKey camKey = _cameras.CreateSubKey(camera.ID.ToString(), true))
          {
            SaveCamera(camKey, camera);
          }
        }
      }

    }

    public string GetGlobalString(string keyName)
    {
      return (string)_base.GetValue(keyName, string.Empty);
    }

    public string GetGlobalStringNull(string keyName)
    {
      return (string)_base.GetValue(keyName);
    }

    public object GetValue(string keyName)
    {
      return _base.GetValue(keyName);
    }


    public int GetGlobalInt(string keyName)
    {
      return (int)_base.GetValue(keyName, 0);
    }

    public int GetGlobalIntExcept(string keyName)
    {
      return (int)_base.GetValue(keyName);
    }


    public void SetGlobalString(string keyName, string value)
    {
      _base.SetValue(keyName, value, RegistryValueKind.String);
    }

    public void SetGlobalInt(string keyName, int value)
    {
      _base.SetValue(keyName, value, RegistryValueKind.DWord);
    }

    public void SetGlobalBool(string keyName, bool value)
    {
      SetGlobalString(keyName, value.ToString());
    }

    public bool GetGlobalBool(string keyName)
    {
      bool result = false;
      string str = GetGlobalString(keyName);
      if (!string.IsNullOrEmpty(str))
      {
        result = bool.Parse(str);
      }

      return result;
    }

    public bool GetGlobalBool(string keyName, bool useDefault)
    {
      bool result = false;
      string str = GetGlobalString(keyName);
      if (!string.IsNullOrEmpty(str))
      {
        result = bool.Parse(str);
      }
      else
      {
        return useDefault;
      }

      return result;
    }


    public void SetGlobalDouble(string keyName, double value)
    {
      _base.SetValue(keyName, value.ToString(), RegistryValueKind.String);
    }

    public double GetGlobalDouble(string keyName)
    {
      double result = 0;
      string str = (string)_base.GetValue(keyName, string.Empty);
      if (!string.IsNullOrEmpty(str))
      {
        result = double.Parse(str);
      }

      return result;
    }

    public void Update() { }

  }
}