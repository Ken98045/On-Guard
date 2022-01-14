using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.Linq;

using System.Xml.XPath;

namespace OnGuardCore
{
  public class XMLStorage : IStorage
  {
    const string _fileName = "OnGuardStorage.xml";
    XmlDocument _doc;
    XmlNode _base;
    XmlNode _cameras;
    XmlNode _root;
    object _lock = new ();

    public XMLStorage()
    {
      CreateBaseTree();
    }

    public string SearchInnerDown(string nameName, string seachFor)
    {
      string result = string.Format(".//{0}[text() = '{1}']", nameName, seachFor);
      return result;
    }

    public string FindElementNameDown(string nodeName)
    {
      string result = string.Format(".//{0}", nodeName);
      return result;
    }

    public string SearchAttributeDown(string nodeName, string attributeName, string searchForAttribute)
    {
      string result = string.Format(".//{0}[@{1} = '{2}']", nodeName, attributeName, searchForAttribute);
      return result;
    }

    public void AddUpdateAttribute(XmlNode node, string name, string val)
    {
      if (string.IsNullOrEmpty(val))
      {
        val = string.Empty; // Even though there is no value, we still want the attribute
      }

      if (node.Attributes[name] != null)
      {
        node.Attributes[name].Value = val;
      }
      else
      {
        XmlAttribute attr = _doc.CreateAttribute(name);
        attr.Value = val;
        node.Attributes.Append(attr);
      }
    }

    public string GetAttribute(XmlNode node, string key)
    {
      string result;
      var attributes = node.Attributes;
      if (null != attributes)
      {
        if (null != attributes[key])
        {
          result = attributes[key].Value;
        }
        else
        {
          result = string.Empty;
        }
      }
      else
      {
        result = string.Empty;
      }

      return result;
    }


    public void CreateBaseTree()
    {
      _doc = new XmlDocument();

      try
      {
        _doc.Load(Storage.GetFilePath(_fileName));
        _root = _doc.DocumentElement;
        _base = _root.FirstChild;
        _cameras = _base.SelectSingleNode(FindElementNameDown("Cameras"));
        if (null == _cameras)
        {
          _cameras = _doc.CreateElement("Cameras");
          _base.AppendChild(_cameras);
        }

      }
      catch (XmlException ex)
      {
        XmlNode docNode = _doc.CreateXmlDeclaration("1.0", "UTF-8", null);
        _doc.AppendChild(docNode);
        XmlElement root = _doc.CreateElement("K2Software"); // for compat sake
        XmlNode publisher = _doc.AppendChild(root);
        XmlElement app = _doc.CreateElement("OnGuard");
        _base = publisher.AppendChild(app);
        XmlElement camera = _doc.CreateElement("Cameras");
        _cameras = _base.AppendChild(camera);

        try
        {
          SetGlobalBool("SentAIGoneEmail", false);
          Update();
        }
        catch (XmlException xmlEx)
        {
          Dbg.Write("Error writing OnGuardStorage.xml");

        }
      }
      catch (IOException)
      {
        XmlElement root = _doc.CreateElement("K2Software"); // for compat sake
        XmlNode publisher = _doc.AppendChild(root);
        XmlElement app = _doc.CreateElement("OnGuard");
        _base = publisher.AppendChild(app);
        XmlElement camera = _doc.CreateElement("Cameras");
        _cameras = _base.AppendChild(camera);
        Update();
      }
    }

    public void Update()
    {
      lock (_lock)
      {
        try
        {
          _doc.Save(Storage.GetFilePath(_fileName));
        }
        catch (Exception ex)
        {
          Dbg.Write("XMLStorage - Exception Saving XML Document: " + ex.Message);
        }
      }
    }

    public string FormQuery(string label, string val)
    {
      string result = string.Format("./{0}[{0}='{1}']", label, val);
      return result;
    }

    void SetGlobal(string name, string val)
    {
      AddUpdateAttribute(_base, name, val);
    }

    public string GetGlobal(string name)
    {
      return ((XmlElement)(_base)).GetAttribute(name);
    }

    // defaults to zero, which may not always be desired
    public int GetGlobalInt(string name)
    {
      string strResult = GetGlobal(name);
      int result = (int)SafeParse.Parse(typeof(int), strResult);
      return result;
    }

    public double GetGlobalDouble(string name)
    {
      string strResult = GetGlobal(name);
      double result = (double)SafeParse.Parse(typeof(double), strResult);
      return result;
    }

    public bool GetGlobalBool(string name, bool useDefault)
    {
      bool result = useDefault;
      string strResult = GetGlobal(name);
      if (!string.IsNullOrEmpty(strResult))
      {
        result = (bool)SafeParse.Parse(typeof(bool), strResult);
      }

      return result;
    }

    public bool GetGlobalBool(string name)
    {
      bool result = GetGlobalBool(name, false);
      return result;
    }

    public int GetGlobalIntExcept(string keyName)
    {
      int result = 0;
      string strResult = GetGlobal(keyName);
      result = (int)SafeParse.Parse(typeof(int), strResult);
      return result;
    }

    public string GetGlobalString(string keyName)
    {
      return GetGlobal(keyName);
    }

    public void DeleteArea(string cameraPath, string cameraPrefix, AreaOfInterest area)
    {
      XmlNode node = FindCamera(cameraPath, cameraPrefix);
      XmlNode? areaNode = node.SelectSingleNode(SearchAttributeDown("Area", "ID", area.ID.ToString()));
      if (null != areaNode)
      {
        node.RemoveChild(areaNode);
      }
    }

    public AILocation GetAILocation()
    {
      AILocation result = null;

      XmlNode? ai = _base.SelectSingleNode(FindElementNameDown("AILocation"));
      if (ai == null)
      {
        ai = _doc.CreateElement("AILocations");
        _base.AppendChild(ai);
      }

      string adddress = GetAttribute(ai, "IPAddress");
      string portStr = GetAttribute(ai, "Port");


      if (!string.IsNullOrEmpty(adddress) && !string.IsNullOrEmpty(portStr))
      {
        int port = (int)SafeParse.Parse(typeof(int), portStr);
        result = new AILocation(adddress, port);
      }

      return result;
    }


    AreaOfInterest GetArea(XmlNode node, Guid areaID)
    {
      AreaOfInterest area = new ();

      XmlNode? areaNode = node.SelectSingleNode(SearchAttributeDown("Area", "ID", areaID.ToString()));

      if (null != areaNode)
      {
        area.AOIName = GetAttribute(areaNode, "AreaName");
        if (!area.Grid.Load(area.AOIName))
        {
          area.Grid = new GridDefinition(GlobalData.AreaGridX, GlobalData.AreaGridY);
        }

        area.ID = (Guid)SafeParse.Parse(typeof(Guid), GetAttribute(areaNode, "ID"));
        string str = GetAttribute(areaNode, "AOIType");
        if (!string.IsNullOrEmpty(str))
        {
          area.AOIType = (AOIType)SafeParse.Parse(typeof(AOIType), str);
        }

        area.Notifications = GetNotificationOption(areaNode);
        area.SearchCriteria = GetCharacteristics(areaNode);
      }

      return area;
    }


    List<ObjectCharacteristics> GetCharacteristics(XmlNode areaNode)
    {
      List<ObjectCharacteristics> result = new ();

      // Get the Search critera node parten
      XmlNode? searchCriteria = areaNode.SelectSingleNode(FindElementNameDown("SearchCriteria"));
      if (null == searchCriteria)
      {
        searchCriteria = _doc.CreateElement("SearchCriteria");
        areaNode.AppendChild(searchCriteria);
      }

      if (null != searchCriteria.ChildNodes)
      {
        foreach (XmlNode objNode in searchCriteria.ChildNodes)
        {
          ObjectCharacteristics obj = new ();
          obj.ID = (Guid)SafeParse.Parse(typeof(Guid), GetAttribute(objNode, "ID"));
          obj.ObjectType = GetAttribute(objNode, "InterestingObjectType");
          obj.Confidence = (int)SafeParse.Parse(typeof(int), GetAttribute(objNode, "Confidence"));
          obj.MinPercentOverlap = (int)SafeParse.Parse(typeof(int), GetAttribute(objNode, "Overlap"));
          obj.TimeFrame = (int)SafeParse.Parse(typeof(int), GetAttribute(objNode, "TimeFrame"));
          obj.MinimumXSize = (int)SafeParse.Parse(typeof(int), GetAttribute(objNode, "MinimumXSize"));
          obj.MinimumYSize = (int)SafeParse.Parse(typeof(int), GetAttribute(objNode, "MinimumYSize"));

          XmlNode? faces = objNode.SelectSingleNode("Faces");
          if (null != faces)
          {
            foreach (XmlNode faceNode in faces.ChildNodes)
            {
              FaceID face = new ();
              face.Name = GetAttribute(faceNode, "Name");
              face.Confidence = (int)SafeParse.Parse(typeof(int), GetAttribute(faceNode, "Confidence"));
              face.Selected = (bool)SafeParse.Parse(typeof(bool), GetAttribute(faceNode, "Selected"));
              obj.Faces.Add(face);
            }
          }
          result.Add(obj);
        }
      }

      return result;
    }

    AreaNotificationOption GetNotificationOption(XmlNode node)
    {
      AreaNotificationOption options = new ();

      options.UseMQTT = (bool)SafeParse.Parse(typeof(bool), GetAttribute(node, "UseMQTT"));
      options.mqttCooldown.CooldownTime = (int)SafeParse.Parse(typeof(int), GetAttribute(node, "MQTTCooldown"));
      options.NoMotionMQTTNotify = (bool)SafeParse.Parse(typeof(bool), GetAttribute(node, "MQTTMotionStopped"));
      options.NoMotionUrlNotify = GetAttribute(node, "MotionStoppedURL");

      XmlNode? urlsNode = node.SelectSingleNode(FindElementNameDown("Urls"));
      if (null == urlsNode)
      {
        urlsNode = _doc.CreateElement("Urls");  // TODO: ?
        node.AppendChild(urlsNode);
      }

      if (null != urlsNode.ChildNodes)
      {
        foreach (XmlNode urlNode in urlsNode.ChildNodes)
        {
          UrlOptions urlOption = new (
            GetAttribute(urlNode, "URL"),
            (int)SafeParse.Parse(typeof(int), GetAttribute(urlNode, "WaitTime")),
            (int)SafeParse.Parse(typeof(int), GetAttribute(urlNode, "CoolDown")),
            (int)SafeParse.Parse(typeof(int), GetAttribute(urlNode, "BIFlags")));

          options.Urls.Add(urlOption);
        }
      }

      XmlNode? emailNodes = node.SelectSingleNode(FindElementNameDown("Emails"));
      if (emailNodes != null)
      {
        if (null != emailNodes.ChildNodes)
        {
          foreach (XmlNode email in emailNodes.ChildNodes)
          {
            options.Email.Add(email.InnerText);
          }
        }
      }

      return options;
    }


    public SortedDictionary<Guid, AreaOfInterest> GetAllAreas(string cameraPath, string cameraPrefix)
    {
      SortedDictionary<Guid, AreaOfInterest> result = new ();

      XmlNode? cameraNode = FindCamera(cameraPath, cameraPrefix);

      if (null != cameraNode)
      {
        XmlNode? areas = cameraNode.SelectSingleNode(FindElementNameDown("Areas"));
        if (areas != null)
        {
          if (null != areas.ChildNodes)
          {
            foreach (XmlNode areaNode in areas.ChildNodes)
            {
              Guid id = (Guid)SafeParse.Parse(typeof(Guid), GetAttribute(areaNode, "ID"));
              AreaOfInterest aoi = GetArea(cameraNode, id);
              result[id] = aoi;
            }
          }
        }
        else
        {
          XmlNode newAreasNode = _doc.CreateElement("Areas");
          cameraNode.AppendChild(newAreasNode);
        }
      }

      return result;
    }


    private CameraContactData GetCameraContactData(XmlNode cameraNode)
    {
      CameraContactData data = new ();

      data.CameraIPAddress = GetAttribute(cameraNode, "IPAddress");
      data.CameraPassword = GetAttribute(cameraNode, "CameraPassword");
      data.CameraUserName = GetAttribute(cameraNode, "UserName");
      data.CameraXResolution = (int)SafeParse.Parse(typeof(int), GetAttribute(cameraNode, "XResolution"));
      data.CameraYResolution = (int)SafeParse.Parse(typeof(int), GetAttribute(cameraNode, "YResolution"));
      data.CameraChannel = (int)SafeParse.Parse(typeof(int), GetAttribute(cameraNode, "Channel"));
      data.Port = (int)SafeParse.Parse(typeof(int), GetAttribute(cameraNode, "Port"));
      data.OnVIFPort = (int)SafeParse.Parse(typeof(int), GetAttribute(cameraNode, "OnVIFPort"));
      if (data.OnVIFPort == 0)
      {
        data.OnVIFPort = 8080;
      }

      data.JPGSnapshotURL = GetAttribute(cameraNode, "SnapshotURL");
      data.CameraShortName = GetAttribute(cameraNode, "CameraName");

      data.JpgContactMethod = (PTZMethod)SafeParse.Parse(typeof(PTZMethod), GetAttribute(cameraNode, "SnapshotMethod"));
      data.JpgCameraMake = GetAttribute(cameraNode, "JpgCameraMake");
      data.JpgCameraModel = GetAttribute(cameraNode, "JpgCameraModel");
      data.PTZCameraMake = GetAttribute(cameraNode, "PTZCameraMake");
      data.PTZCameraModel = GetAttribute(cameraNode, "PTZCameraModel");

      // PTZ
      data.PTZContactMethod = (PTZMethod)SafeParse.Parse(typeof(PTZMethod), GetAttribute(cameraNode, "PTZContactMethod"));
      data.HTTPPanLeft = GetAttribute(cameraNode, "HttpLeft");
      data.HTTPPanRight = GetAttribute(cameraNode, "HttpRight");
      data.HTTPPanUp = GetAttribute(cameraNode, "HttpUp");
      data.HTTPPanDown = GetAttribute(cameraNode, "HttpDown");
      data.HTTPZoomIn = GetAttribute(cameraNode, "HttpZoomIn");
      data.HTTPZoomOut = GetAttribute(cameraNode, "HttpZoomOut");
      data.HTTPStop = GetAttribute(cameraNode, "HttpStop");

      data.PanTime = (double)SafeParse.Parse(typeof(double), GetAttribute(cameraNode, "PanXTime"));
      if (data.PanTime == 0)
      {
        data.PanTime = 1;
      }

      data.TiltTime = (double)SafeParse.Parse(typeof(double), GetAttribute(cameraNode, "PanYTime"));
      if (data.TiltTime == 0)
      {
        data.TiltTime = 1;
      }

      data.ZoomTime = (double)SafeParse.Parse(typeof(double), GetAttribute(cameraNode, "ZoomTime"));
      if (data.ZoomTime == 0)
      {
        data.ZoomTime = 0.5;
      }

      data.PanSpeed = (double)SafeParse.Parse(typeof(double), GetAttribute(cameraNode, "PanXSpeed"));
      if (data.PanSpeed == 0.0)
      {
        data.PanSpeed = 0.1;
      }

      data.TiltSpeed = (double)SafeParse.Parse(typeof(double), GetAttribute(cameraNode, "PanYSpeed"));
      if (data.TiltSpeed == 0.0)
      {
        data.TiltSpeed = 0.1;
      }

      data.ZoomSpeed = (double)SafeParse.Parse(typeof(double), GetAttribute(cameraNode, "ZoomSpeed"));
      if (data.ZoomSpeed == 0.0)
      {
        data.ZoomSpeed = 0.1;
      }

      data.PresetSettings.PresetMethod = (PTZMethod)SafeParse.Parse(typeof(PTZMethod), GetAttribute(cameraNode, "PresetMethod"));
      data.PresetSettings.CameraMake = GetAttribute(cameraNode, "PresetCameraMake");
      data.PresetSettings.CameraModel = GetAttribute(cameraNode, "PresetCameraModel");

      // And presets
      XmlNodeList presetNodes = null;
      XmlNode? presetsParent = cameraNode.SelectSingleNode(FindElementNameDown("Presets"));
      if (null != presetsParent)
      {
        presetNodes = presetsParent.SelectNodes("*");
      }


      if (presetNodes != null)
      {
        foreach (XmlNode presetNode in presetNodes)
        {
          Preset preset = new ();
          preset.Command = presetNode.InnerText;
          preset.Name = GetAttribute(presetNode, "Name");
          data.PresetSettings.PresetList.Add(preset);
        }
      }


      return data;

    }


    private CameraData GetCamera(XmlNode cameraNode)
    {
      CameraData camera = null;
      string path = GetAttribute(cameraNode, "Path");
      if (!string.IsNullOrEmpty(path))
      {

        string prefix = GetAttribute(cameraNode, "Prefix");
        Guid id = Guid.Parse(GetAttribute(cameraNode, "ID"));
        camera = new CameraData(id, prefix, path);
        camera.NoMotionTimeout = (int)SafeParse.Parse(typeof(int), GetAttribute(cameraNode, "MotionStoppedTimeout"));
        camera.MonitorSubdirectories = (bool)SafeParse.Parse(typeof(bool), GetAttribute(cameraNode, "MonitorSubdirectories"));
        camera.RegistrationX = (int)SafeParse.Parse(typeof(int), GetAttribute(cameraNode, "RegistrationX"));
        camera.RegistrationY = (int)SafeParse.Parse(typeof(int), GetAttribute(cameraNode, "RegistrationY"));
        camera.RegistrationXResolution = (int)SafeParse.Parse(typeof(int), GetAttribute(cameraNode, "RegistrationXResolution"));
        camera.RegistrationYResolution = (int)SafeParse.Parse(typeof(int), GetAttribute(cameraNode, "RegistrationYResolution"));
        camera.Monitoring = (bool)SafeParse.Parse(typeof(bool), GetAttribute(cameraNode, "Monitoring"));

        camera.CameraInputMethod = (CameraMethod)SafeParse.Parse(typeof(CameraMethod), GetAttribute(cameraNode, "CameraMethod"));
        camera.OnGuardScanIterval = (double)SafeParse.Parse(typeof(double), GetAttribute(cameraNode, "CheckInterval"));
        camera.StorePicturesInAreaOnly = (bool)SafeParse.Parse(typeof(bool), GetAttribute(cameraNode, "StoreOnlyInArea"));
        camera.TriggerInterval = (double)SafeParse.Parse(typeof(double), GetAttribute(cameraNode, "RecordFrameInterval"));
        camera.RecordTime = (double)SafeParse.Parse(typeof(double), GetAttribute(cameraNode, "RecordTime"));
        camera.RecordInterval = (double)SafeParse.Parse(typeof(double), GetAttribute(cameraNode, "RecordInterval"));
        camera.TriggerPrefix = GetAttribute(cameraNode, "TriggerPrefix");

        camera.Contact = GetCameraContactData(cameraNode);
        camera.Contact.ONVIF.SelectedProfile = GetAttribute(cameraNode, "OnVIFProfile");

        SortedDictionary<Guid, AreaOfInterest> areas = GetAllAreas(camera.CameraPath, camera.CameraPrefix);
        foreach (var area in areas.Values)
        {
          camera.AOI.AddArea(area);
        }

        LoadScheduledPresets(cameraNode, camera);
      }

      return camera;
    }

    public CameraCollection GetAllCameras()
    {
      CameraCollection allCameras = new ();

      allCameras.CurrentCameraPath = GetAttribute(_cameras, "CurrentCamera");

      if (_cameras.ChildNodes != null)
      {
        foreach (XmlNode node in _cameras.ChildNodes)
        {
          CameraData cam = GetCamera(node);
          allCameras.AddCamera(cam);
        }
      }
      return allCameras;
    }

    public string GetAppVersion()
    {
      string result = string.Empty;

      return result;
    }

    public int GetCameraInt(string cameraPath, string cameraPrefix, string keyName)
    {
      int result = 0;


      return result;
    }

    /*string GetCameraPath(string key)
    {
      string result = string.Empty;

      return result;
    }*/


    string GetCameraPrefix(string reg)
    {
      string result = string.Empty;


      return result;

    }


    public List<EmailOptions> GetEmailAddresses()
    {
      List<EmailOptions> result = new ();

      XmlNode? emailNode = _base.SelectSingleNode("EmailAddresses");
      if (null != emailNode)
      {
        foreach (XmlNode element in emailNode.ChildNodes)
        {
          EmailOptions emailOptions = new EmailOptions();
          emailOptions.EmailAddress = GetAttribute(element, "Address");
          emailOptions.NumberOfImages = int.Parse(GetAttribute(element, "NumberOfImages"));
          emailOptions.AllTheTime = bool.Parse(GetAttribute(element, "AllTheTime"));
          emailOptions.StartTime = DateTime.Parse(GetAttribute(element, "StartTime"));
          emailOptions.EndTime = DateTime.Parse(GetAttribute(element, "EndTime"));
          emailOptions.SizeDownToPercent = int.Parse(GetAttribute(element, "SizeDownPercent"));

          string maxAttachmentSize = GetAttribute(element, "MaximumAttachmentSize");
          if (string.IsNullOrEmpty(maxAttachmentSize))
          {
            emailOptions.MaximumAttachmentSize = (decimal)5.0;
          }
          else
          {
            emailOptions.MaximumAttachmentSize = decimal.Parse(maxAttachmentSize);
          }

          string inlinePictures = GetAttribute(element, "InlinePictures");
          if (string.IsNullOrEmpty(inlinePictures))
          {
            emailOptions.InlinePictures = true; // the default is to inline pictures
          }
          else
          {
            emailOptions.InlinePictures = bool.Parse(inlinePictures);
          }


          emailOptions.CoolDown.CooldownTime = int.Parse(GetAttribute(element, "CooldownTime"));
          emailOptions.DaysOfWeek[0] = bool.Parse(GetAttribute(element, "Sunday"));
          emailOptions.DaysOfWeek[1] = bool.Parse(GetAttribute(element, "Monday"));
          emailOptions.DaysOfWeek[2] = bool.Parse(GetAttribute(element, "Tuesday"));
          emailOptions.DaysOfWeek[3] = bool.Parse(GetAttribute(element, "Wednesday"));
          emailOptions.DaysOfWeek[4] = bool.Parse(GetAttribute(element, "Thursday"));
          emailOptions.DaysOfWeek[5] = bool.Parse(GetAttribute(element, "Friday"));
          emailOptions.DaysOfWeek[6] = bool.Parse(GetAttribute(element, "Saturday"));
          result.Add(emailOptions);
        }
      }


      return result;
    }
    static public string GetFilePath(string fileName)
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

    public object GetValue(string keyName)
    {
      object result = new object();

      return result;
    }

    public string GetGlobalStringNull(string keyName)
    {
      string result = GetGlobal(keyName);
      return result;

    }

    public void SetGlobalBool(string keyName, bool val)
    {
      SetGlobal(keyName, val.ToString());
    }

    public void SetGlobalDouble(string keyName, double val)
    {
      SetGlobal(keyName, val.ToString());
    }

    public void SetGlobalInt(string keyName, int val)
    {
      SetGlobal(keyName, val.ToString());
    }
    public void SetGlobalString(string keyName, string val)
    {
      SetGlobal(keyName, val.ToString());
    }

    public void RemoveGlobalValue(string name)
    {
      ((XmlElement)(_base)).RemoveAttribute(name);
    }

    public void SetAppVersion(string version)
    {
      SetGlobal("CurrentVersion", version);
    }

    XmlNode FindCamera(string cameraPath, string cameraPrefix)
    {
      string fullPath = Path.Combine(cameraPath, cameraPrefix);

      XmlNode? result = _cameras.SelectSingleNode(SearchAttributeDown("Camera", "FullPath", fullPath));
      return result;
    }


    public void SaveEmailAddresses(List<EmailOptions> addresses)
    {
      XmlNode? emailNode = _base.SelectSingleNode("EmailAddresses");
      if (null == emailNode)
      {
        emailNode = _doc.CreateElement("EmailAddresses");
        _base.AppendChild(emailNode);
      }
      else
      {
        emailNode.RemoveAll();  // Because we are saving all email addresses and don't know which may have been deleted
      }

      foreach (var address in addresses)
      {
        XmlElement element = _doc.CreateElement("OutgoingEmail");
        emailNode.AppendChild(element);
        AddUpdateAttribute(element, "Address", address.EmailAddress);
        AddUpdateAttribute(element, "NumberOfImages", address.NumberOfImages.ToString());
        AddUpdateAttribute(element, "AllTheTime", address.AllTheTime.ToString());
        AddUpdateAttribute(element, "StartTime", address.StartTime.ToString());
        AddUpdateAttribute(element, "EndTime", address.EndTime.ToString());
        AddUpdateAttribute(element, "SizeDownPercent", address.SizeDownToPercent.ToString());
        AddUpdateAttribute(element, "MaximumAttachmentSize", address.MaximumAttachmentSize.ToString());
        AddUpdateAttribute(element, "InlinePictures", address.InlinePictures.ToString());
        AddUpdateAttribute(element, "CooldownTime", address.CoolDown.CooldownTime.ToString());
        AddUpdateAttribute(element, "Sunday", address.DaysOfWeek[0].ToString());
        AddUpdateAttribute(element, "Monday", address.DaysOfWeek[1].ToString());
        AddUpdateAttribute(element, "Tuesday", address.DaysOfWeek[2].ToString());
        AddUpdateAttribute(element, "Wednesday", address.DaysOfWeek[3].ToString());
        AddUpdateAttribute(element, "Thursday", address.DaysOfWeek[4].ToString());
        AddUpdateAttribute(element, "Friday", address.DaysOfWeek[5].ToString());
        AddUpdateAttribute(element, "Saturday", address.DaysOfWeek[6].ToString());
      }

      Update();
    }

    public void SetAILocation(string ipAddress, int port)
    {
      // First, search for and if necessary form the node for AILocations
      string aiLocationQuery = FindElementNameDown("AILocation");
      XmlNode? aiNode = _base.SelectSingleNode(aiLocationQuery);
      if (aiNode == null)
      {
        aiNode = _doc.CreateElement("AILocation");
        _base.AppendChild(aiNode);
      }

      AddUpdateAttribute(aiNode, "IPAddress", ipAddress);
      AddUpdateAttribute(aiNode, "Port", port.ToString());
      Update();

    }


    public void SetCameraInt(string cameraPath, string cameraPrefix, string keyName, int theValue)
    {
      XmlNode node = FindCamera(cameraPath, cameraPrefix);
      if (node != null)
      {
        AddUpdateAttribute(node, keyName, theValue.ToString());
      }

      Update();
    }

    public void SaveArea(string cameraPath, string cameraPrefix, AreaOfInterest area)
    {
      XmlNode cameraNode = FindCamera(cameraPath, cameraPrefix);
      if (cameraNode != null)
      {
        XmlNode? allAreas = cameraNode.SelectSingleNode(FindElementNameDown("Areas"));
        if (null == allAreas)
        {
          allAreas = _doc.CreateElement("Areas");
          cameraNode.AppendChild(allAreas);
        }

        XmlNode areaNode = allAreas.SelectSingleNode(SearchAttributeDown("Area", "ID", area.ID.ToString()));
        if (null == areaNode)
        {
          areaNode = _doc.CreateElement("Area");
          allAreas.AppendChild(areaNode);
        }

        AddUpdateAttribute(areaNode, "ID", area.ID.ToString());
        AddUpdateAttribute(areaNode, "AreaName", area.AOIName);
        AddUpdateAttribute(areaNode, "AOIType", area.AOIType.ToString());
        SaveNotificationOption(areaNode, area.Notifications);
        SaveCharacteristcs(areaNode, area.SearchCriteria);
        area.Grid.Save(area.AOIName); // save the grid in a binary format (not XML!)
      }

    }

    private void SaveNotificationOption(XmlNode node, AreaNotificationOption options)
    {

      AddUpdateAttribute(node, "UseMQTT", options.UseMQTT.ToString());
      AddUpdateAttribute(node, "MQTTCooldown", options.mqttCooldown.CooldownTime.ToString());
      AddUpdateAttribute(node, "MQTTMotionStopped", options.NoMotionMQTTNotify.ToString());
      AddUpdateAttribute(node, "MotionStoppedURL", options.NoMotionUrlNotify);

      XmlNode? urlsNode = node.SelectSingleNode("Urls");
      if (null == urlsNode)
      {
        urlsNode = _doc.CreateElement("Urls");
        node.AppendChild(urlsNode);
      }
      else
      {
        urlsNode.RemoveAll();
      }

      foreach (var notifyOption in options.Urls)
      {
        if (!string.IsNullOrEmpty(notifyOption.Url))
        {
          XmlNode url = _doc.CreateElement("Url");
          urlsNode.AppendChild(url);
          AddUpdateAttribute(url, "ID", notifyOption.ID.ToString());
          AddUpdateAttribute(url, "URL", notifyOption.Url);
          AddUpdateAttribute(url, "CoolDown", notifyOption.CoolDown.CooldownTime.ToString());
          AddUpdateAttribute(url, "WaitTime", notifyOption.WaitTime.ToString());
          AddUpdateAttribute(url, "BIFlags", notifyOption.BIFlags.ToString());
        }
      }

      XmlNode? emailsNode = node.SelectSingleNode("Emails");
      if (emailsNode == null)
      {
        emailsNode = _doc.CreateElement("Emails");
        node.AppendChild(emailsNode);
      }
      else
      {
        emailsNode.RemoveAll();
      }

      foreach (var email in options.Email)
      {
        XmlNode emailNode = _doc.CreateElement("Email");
        emailNode.InnerText = email;
        emailsNode.AppendChild(emailNode);
      }

      Update();
    }

    private void SaveCharacteristcs(XmlNode node, List<ObjectCharacteristics> objectChar)
    {
      // Get the search critera parent
      XmlNode? searchCriteria = node.SelectSingleNode("SearchCriteria");
      if (null == searchCriteria)
      {
        searchCriteria = _doc.CreateElement("SearchCriteria");
        node.AppendChild(searchCriteria);
      }
      else
      {
        searchCriteria.RemoveAll(); // empty the list we are rebuilding it
      }

      foreach (var obj in objectChar)
      {
        XmlNode objNode = _doc.CreateElement("Criteria");
        AddUpdateAttribute(objNode, "ID", obj.ID.ToString());
        AddUpdateAttribute(objNode, "InterestingObjectType", obj.ObjectType);
        AddUpdateAttribute(objNode, "Confidence", obj.Confidence.ToString());
        AddUpdateAttribute(objNode, "Overlap", obj.MinPercentOverlap.ToString());
        AddUpdateAttribute(objNode, "TimeFrame", obj.TimeFrame.ToString());
        AddUpdateAttribute(objNode, "MinimumXSize", obj.MinimumXSize.ToString());
        AddUpdateAttribute(objNode, "MinimumYSize", obj.MinimumYSize.ToString());

        if (obj.Faces.Count > 0)
        {
          XmlNode faceNodes = _doc.CreateElement("Faces");
          objNode.AppendChild(faceNodes);

          foreach (FaceID face in obj.Faces)
          {
            XmlNode faceNode = _doc.CreateElement("Face");
            AddUpdateAttribute(faceNode, "Name", face.Name);
            AddUpdateAttribute(faceNode, "Confidence", face.Confidence.ToString());
            AddUpdateAttribute(faceNode, "Selected", face.Selected.ToString());
            faceNodes.AppendChild(faceNode);
          }
        }

        searchCriteria.AppendChild(objNode);
      }
    }


    public void SaveArea(AreaOfInterest area)
    {
      SaveArea(GetGlobalString("CurrentCameraPath"), GetGlobalString("CurrentCameraPrefix"), area);
      Update();
    }

    public void SaveArea(CameraData cam, AreaOfInterest area)
    {
      SaveArea(cam.CameraPath, cam.CameraPrefix, area);
      Update();

    }

    void SaveArea(string camKey, AreaOfInterest area)
    {

    }


    public void SaveAllAreas(string cameraPath, string cameraPrefix, AreasOfInterestCollection areas)
    {
      XmlNode? cameraNode = FindCamera(cameraPath, cameraPrefix);
      if (null != cameraNode)
      {
        XmlNode? areasNode = cameraNode.SelectSingleNode(FindElementNameDown("Areas"));
        // First delete the areas to account for area deletion
        areasNode.RemoveAll();

        foreach (AreaOfInterest area in areas)
        {
          SaveArea(cameraPath, cameraPrefix, area);
        }
      }

    }


    void SaveCamera(CameraData camera)
    {
      XmlNode? cameraNode = FindCamera(camera.CameraPath, camera.CameraPrefix);

      if (null == cameraNode)
      {
        cameraNode = _doc.CreateElement("Camera");
        _cameras.AppendChild(cameraNode);
      }


      AddUpdateAttribute(cameraNode, "ID", camera.ID.ToString());
      string fullPath = Path.Combine(camera.CameraPath, camera.CameraPrefix);
      AddUpdateAttribute(cameraNode, "FullPath", fullPath);
      AddUpdateAttribute(cameraNode, "Prefix", camera.CameraPrefix);
      AddUpdateAttribute(cameraNode, "Path", camera.CameraPath);
      AddUpdateAttribute(cameraNode, "MotionStoppedTimeout", camera.NoMotionTimeout.ToString());
      AddUpdateAttribute(cameraNode, "MonitorSubdirectories", camera.MonitorSubdirectories.ToString());
      AddUpdateAttribute(cameraNode, "RegistrationX", camera.RegistrationX.ToString());
      AddUpdateAttribute(cameraNode, "RegistrationY", camera.RegistrationY.ToString());
      AddUpdateAttribute(cameraNode, "RegistrationXResolution", camera.RegistrationXResolution.ToString());
      AddUpdateAttribute(cameraNode, "RegistrationYResolution", camera.RegistrationYResolution.ToString());
      AddUpdateAttribute(cameraNode, "Monitoring", camera.Monitoring.ToString());
      AddUpdateAttribute(cameraNode, "CameraMethod", camera.CameraInputMethod.ToString());
      AddUpdateAttribute(cameraNode, "StoreOnlyInArea", camera.StorePicturesInAreaOnly.ToString());
      AddUpdateAttribute(cameraNode, "CheckInterval", camera.OnGuardScanIterval.ToString());
      AddUpdateAttribute(cameraNode, "RecordFrameInterval", camera.TriggerInterval.ToString());
      AddUpdateAttribute(cameraNode, "RecordTime", camera.RecordTime.ToString());
      AddUpdateAttribute(cameraNode, "RecordInterval", camera.RecordInterval.ToString());
      AddUpdateAttribute(cameraNode, "TriggerPrefix", camera.TriggerPrefix);

      if (camera.Contact.ONVIF != null)
      {
        AddUpdateAttribute(cameraNode, "OnVIFProfile", camera.Contact.ONVIF.SelectedProfile);
      }

      SetCameraContactData(cameraNode, camera.Contact);

      foreach (AreaOfInterest area in camera.AOI)
      {
        SaveArea(camera.CameraPath, camera.CameraPrefix, area);
      }

      SaveScheduledPresets(cameraNode, camera);
    }

    void SaveScheduledPresets(XmlNode cameraNode, CameraData camera)
    {
      // Long/lat doesn't really belong here, but since they are so closely related...
      AddUpdateAttribute(cameraNode, "Longitude", camera.Longitude.ToString());
      AddUpdateAttribute(cameraNode, "Latitude", camera.Latitude.ToString());

      XmlNode? presetNodes = cameraNode.SelectSingleNode("SchedulePresets");
      if (null == presetNodes)
      {
        presetNodes = _doc.CreateElement("SchedulePresets");
        cameraNode.AppendChild(presetNodes);
      }
      else
      {
        presetNodes.RemoveAll();
      }

      int i = 1;
      foreach (var preset in camera.ScheduledPresets)
      {
        XmlNode pNode = _doc.CreateElement("ScheduledPreset" + i.ToString());
        presetNodes.AppendChild(pNode);
        AddUpdateAttribute(pNode, "ID", preset.ID.ToString());
        AddUpdateAttribute(pNode, "Name", preset.Name);
        AddUpdateAttribute(pNode, "PresetNumber", preset.PresetNumber.ToString());
        AddUpdateAttribute(pNode, "TriggerType", preset.TriggerType.ToString());
        AddUpdateAttribute(pNode, "TriggerTime", preset.TriggerTime.ToString());
        ++i;
      }
    }

    void LoadScheduledPresets(XmlNode cameraNode, CameraData camera)
    {
      string str;
      str = GetAttribute(cameraNode, "Longitude");
      if (!string.IsNullOrEmpty(str))
      {
        camera.Longitude = (double)SafeParse.Parse(typeof(double), str);
      }

      str = GetAttribute(cameraNode, "Latitude");
      if (!string.IsNullOrEmpty(str))
      {
        camera.Latitude = (double)SafeParse.Parse(typeof(double), str);
      }


      XmlNode? presetNodes = cameraNode.SelectSingleNode("SchedulePresets");
      if (null != presetNodes)
      {
        var presets = presetNodes.SelectNodes("*");

        foreach (XmlNode presetNode in presets)
        {
          PresetTrigger p = new ();
          str = GetAttribute(presetNode, "ID");
          if (string.IsNullOrEmpty(str))
          {
            str = Guid.NewGuid().ToString();
          }

          p.ID = (Guid)SafeParse.Parse(typeof(Guid), str);
          p.Name = GetAttribute(presetNode, "Name");
          str = GetAttribute(presetNode, "PresetNumber");
          p.PresetNumber = (int)SafeParse.Parse(typeof(int), str);
          str = GetAttribute(presetNode, "TriggerType");
          p.TriggerType = (PresetTriggerType)SafeParse.Parse(typeof(PresetTriggerType), str);
          str = GetAttribute(presetNode, "TriggerTime");
          p.TriggerTime = DateTime.Parse(str);
          camera.ScheduledPresets.Add(p);
        }
      }
    }

    void SetCameraContactData(XmlNode cameraNode, CameraContactData data)
    {
      AddUpdateAttribute(cameraNode, "IPAddress", data.CameraIPAddress);
      AddUpdateAttribute(cameraNode, "CameraPassword", data.CameraPassword);
      AddUpdateAttribute(cameraNode, "UserName", data.CameraUserName);
      AddUpdateAttribute(cameraNode, "XResolution", data.CameraXResolution.ToString());
      AddUpdateAttribute(cameraNode, "YResolution", data.CameraYResolution.ToString());
      AddUpdateAttribute(cameraNode, "Channel", data.CameraChannel.ToString());
      AddUpdateAttribute(cameraNode, "Port", data.Port.ToString());
      AddUpdateAttribute(cameraNode, "OnVIFPort", data.OnVIFPort.ToString());
      AddUpdateAttribute(cameraNode, "CameraName", data.CameraShortName);
      AddUpdateAttribute(cameraNode, "SnapshotURL", data.JPGSnapshotURL);

      AddUpdateAttribute(cameraNode, "SnapshotMethod", data.JpgContactMethod.ToString());
      AddUpdateAttribute(cameraNode, "JpgCameraMake", data.JpgCameraMake);
      AddUpdateAttribute(cameraNode, "JpgCameraModel", data.JpgCameraModel);
      AddUpdateAttribute(cameraNode, "PTZCameraMake", data.PTZCameraMake);
      AddUpdateAttribute(cameraNode, "PTZCameraModel", data.PTZCameraModel);

      // PTZ
      AddUpdateAttribute(cameraNode, "PTZContactMethod", data.PTZContactMethod.ToString());

      // Http, iSpy only
      AddUpdateAttribute(cameraNode, "HttpLeft", data.HTTPPanLeft);
      AddUpdateAttribute(cameraNode, "HttpRight", data.HTTPPanRight);
      AddUpdateAttribute(cameraNode, "HttpUp", data.HTTPPanUp);
      AddUpdateAttribute(cameraNode, "HttpDown", data.HTTPPanDown);
      AddUpdateAttribute(cameraNode, "HttpZoomIn", data.HTTPZoomIn);
      AddUpdateAttribute(cameraNode, "HttpZoomOut", data.HTTPZoomOut);
      AddUpdateAttribute(cameraNode, "HttpStop", data.HTTPStop);

      AddUpdateAttribute(cameraNode, "PanXTime", data.PanTime.ToString());
      AddUpdateAttribute(cameraNode, "PanYTime", data.TiltTime.ToString());
      AddUpdateAttribute(cameraNode, "ZoomTime", data.ZoomTime.ToString());
      AddUpdateAttribute(cameraNode, "PanXSpeed", data.PanSpeed.ToString());
      AddUpdateAttribute(cameraNode, "PanYSpeed", data.TiltSpeed.ToString());
      AddUpdateAttribute(cameraNode, "ZoomSpeed", data.ZoomSpeed.ToString());
      AddUpdateAttribute(cameraNode, "ZoomSpeed", data.ZoomSpeed.ToString());

      AddUpdateAttribute(cameraNode, "PresetMethod", data.PresetSettings.PresetMethod.ToString());
      AddUpdateAttribute(cameraNode, "PresetCameraMake", data.PresetSettings.CameraMake);
      AddUpdateAttribute(cameraNode, "PresetCameraModel", data.PresetSettings.CameraModel);

      XmlNode? presetsParent = cameraNode.SelectSingleNode(FindElementNameDown("Presets"));
      if (null == presetsParent)
      {
        presetsParent = _doc.CreateElement("Presets");
        cameraNode.AppendChild(presetsParent);
      }
      else
      {
        presetsParent.RemoveAll();    // Need to clear them out because if they changed....
      }

      int presetCount = 1;
      foreach (var preset in data.PresetSettings.PresetList)
      {
        string name = "Preset" + presetCount.ToString();
        XmlNode presetNode = _doc.CreateElement(name);
        presetsParent.AppendChild(presetNode);
        presetNode.InnerText = preset.Command;
        AddUpdateAttribute(presetNode, "Name", preset.Name);
        ++presetCount;
      }

    }


    public void SaveCameras(CameraCollection allCameras)
    {
      // Since we are saving everything we need to get rid of the old data
      _cameras.RemoveAll();

      // Now we can save the new data
      AddUpdateAttribute(_cameras, "CurrentCamera", allCameras.CurrentCameraPath);

      foreach (CameraData camera in allCameras.CameraDictionary.Values)
      {
        SaveCamera(camera);
      }

      Update();
    }

  }
}