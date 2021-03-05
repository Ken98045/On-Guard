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


using System;
using System.Collections.Generic;
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
    object _lock = new object();

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

    public int GetGlobalInt(string name)
    {
      int result = 0;

      string strResult = GetGlobal(name);
      if (!string.IsNullOrEmpty(strResult))
      {
        result = int.Parse(strResult);
      }

      return result;
    }

    public double GetGlobalDouble(string name)
    {
      double result = 0;

      string strResult = GetGlobal(name);
      if (!string.IsNullOrEmpty(strResult))
      {
        result = double.Parse(strResult);
      }

      return result;
    }

    public bool GetGlobalBool(string name, bool useDefault)
    {
      bool result = useDefault;

      string strResult = GetGlobal(name);
      if (!string.IsNullOrEmpty(strResult))
      {
        result = bool.Parse(strResult);
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


      if (!string.IsNullOrEmpty(strResult))
      {
        result = int.Parse(strResult);
      }
      else
      {
        //TODO: throw
      }

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

    public List<AILocation> GetAILocations()
    {
      List<AILocation> result = new List<AILocation>();

      XmlNode? aiLocations = _base.SelectSingleNode(FindElementNameDown("AILocations"));
      if (aiLocations == null)
      {
        aiLocations = _doc.CreateElement("AILocations");
        _base.AppendChild(aiLocations);
      }

      if (null != aiLocations.ChildNodes)
      {
        foreach (XmlNode ai in aiLocations.ChildNodes)
        {
          AILocation aiLocation = new AILocation(Guid.Parse(GetAttribute(ai, "ID")), GetAttribute(ai, "IPAddress"), int.Parse(GetAttribute(ai, "Port")));
          result.Add(aiLocation);
        }
      }

      return result;
    }

    public void SaveAILocations(List<AILocation> locations)
    {
      foreach (var ai in locations)
      {
        SetAILocation(ai);
      }

      Update();
    }

    AreaOfInterest GetArea(XmlNode node, Guid areaID)
    {
      AreaOfInterest area = new AreaOfInterest();

      XmlNode? areaNode = node.SelectSingleNode(SearchAttributeDown("Area", "ID", areaID.ToString()));

      if (null != areaNode)
      {
        area.AOIName = GetAttribute(areaNode, "AreaName");
        area.AreaRect.X = int.Parse(GetAttribute(areaNode, "X"));
        area.AreaRect.Y = int.Parse(GetAttribute(areaNode, "Y"));
        area.AreaRect.Width = int.Parse(GetAttribute(areaNode, "Width"));
        area.AreaRect.Height = int.Parse(GetAttribute(areaNode, "Height"));
        area.OriginalXResolution = int.Parse(GetAttribute(areaNode, "OriginalXRes"));
        area.OriginalYResolution = int.Parse(GetAttribute(areaNode, "OriginalYRes"));
        area.ID = Guid.Parse(GetAttribute(areaNode, "ID"));
        area.MovementType = (MovementType)Enum.Parse(typeof(MovementType), GetAttribute(areaNode, "Movement"));
        area.AOIType = (AOIType)Enum.Parse(typeof(AOIType), GetAttribute(areaNode, "AOIType"));

        area.Notifications = GetNotificationOption(areaNode);
        area.SearchCriteria = GetCharacteristics(areaNode);
      }

      return area;
    }


    List<ObjectCharacteristics> GetCharacteristics(XmlNode areaNode)
    {
      List<ObjectCharacteristics> result = new List<ObjectCharacteristics>();

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
          ObjectCharacteristics obj = new ObjectCharacteristics();
          obj.ID = Guid.Parse(GetAttribute(objNode, "ID"));
          obj.ObjectType = GetAttribute(objNode, "ImageObjectType");
          obj.Confidence = int.Parse(GetAttribute(objNode, "Confidence"));
          obj.MinPercentOverlap = int.Parse(GetAttribute(objNode, "Overlap"));
          obj.TimeFrame = int.Parse(GetAttribute(objNode, "TimeFrame"));
          obj.MinimumXSize = int.Parse(GetAttribute(objNode, "MinimumXSize"));
          obj.MinimumYSize = int.Parse(GetAttribute(objNode, "MinimumYSize"));
          result.Add(obj);
        }
      }

      return result;
    }

    AreaNotificationOption GetNotificationOption(XmlNode node)
    {
      AreaNotificationOption options = new AreaNotificationOption();

      options.UseMQTT = bool.Parse(GetAttribute(node, "UseMQTT"));
      options.mqttCooldown.CooldownTime = int.Parse(GetAttribute(node, "MQTTCooldown"));
      options.NoMotionMQTTNotify = bool.Parse(GetAttribute(node, "MQTTMotionStopped"));
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
          UrlOptions urlOption = new UrlOptions(
            GetAttribute(urlNode, "URL"),
            int.Parse(GetAttribute(urlNode, "WaitTime")),
            int.Parse(GetAttribute(urlNode, "CoolDown")),
            int.Parse(GetAttribute(urlNode, "BIFlags")));

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
      SortedDictionary<Guid, AreaOfInterest> result = new SortedDictionary<Guid, AreaOfInterest>();

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
              Guid id = Guid.Parse(GetAttribute(areaNode, "ID"));
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
      CameraContactData data = new CameraContactData();

      data.CameraIPAddress = GetAttribute(cameraNode, "IPAddress");
      data.CameraPassword = GetAttribute(cameraNode, "CameraPassword");
      data.CameraUserName = GetAttribute(cameraNode, "UserName");
      data.CameraXResolution = int.Parse(GetAttribute(cameraNode, "XResolution"));
      data.CameraYResolution = int.Parse(GetAttribute(cameraNode, "YResolution"));
      data.Port = int.Parse(GetAttribute(cameraNode, "Port"));
      data.ShortCameraName = GetAttribute(cameraNode, "CameraName");
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
        camera.NoMotionTimeout = int.Parse(GetAttribute(cameraNode, "MotionStoppedTimeout"));
        camera.RegistrationX = int.Parse(GetAttribute(cameraNode, "RegistrationX"));
        camera.RegistrationY = int.Parse(GetAttribute(cameraNode, "RegistrationY"));
        camera.RegistrationXResolution = int.Parse(GetAttribute(cameraNode, "RegistrationXResolution"));
        camera.RegistrationYResolution = int.Parse(GetAttribute(cameraNode, "RegistrationYResolution"));
        camera.Monitoring = bool.Parse(GetAttribute(cameraNode, "Monitoring"));

        camera.LiveContactData = GetCameraContactData(cameraNode);
        SortedDictionary<Guid, AreaOfInterest> areas = GetAllAreas(camera.Path, camera.CameraPrefix);
        foreach (var area in areas.Values)
        {
          camera.AOI.AddArea(area);
        }
      }

      return camera;
    }

    public CameraCollection GetAllCameras()
    {
      CameraCollection allCameras = new CameraCollection();

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
      List<EmailOptions> result = new List<EmailOptions>();

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

    public void SetAILocation(AILocation location)
    {
      // First, search for and if necessary form the node for AILocations
      string aiLocationQuery = FindElementNameDown("AILocations");
      XmlNode? aiLocations = _base.SelectSingleNode(aiLocationQuery);
      if (aiLocations == null)
      {
        aiLocations = _doc.CreateElement("AILocations");
        _base.AppendChild(aiLocations);
      }

      // Now, look and see if this one exists
      XmlNode? node;
      string aiQuery = SearchAttributeDown("AI", "ID", location.ID.ToString());
      node = aiLocations.SelectSingleNode(aiQuery);
      if (node == null)
      {
        try
        {
          node = _doc.CreateElement("AI");
          aiLocations.AppendChild(node);
        }
        catch (Exception ex)
        {

        }
      }

      AddUpdateAttribute(node, "ID", location.ID.ToString());
      AddUpdateAttribute(node, "IPAddress", location.IPAddress);
      AddUpdateAttribute(node, "Port", location.Port.ToString());
      Update();
    }

    public void RemoveAILocation(string id)
    {
      XmlNode? aiLocations = _base.SelectSingleNode("AILocations");
      if (aiLocations == null)
      {
        XmlElement element = _doc.CreateElement("AILocations");
        _base.AppendChild(element);
      }
      else
      {
        XmlNode? node = aiLocations.SelectSingleNode(SearchAttributeDown("AI", "ID", id));
        if (node != null)
        {
          aiLocations.RemoveChild(node);
          Update();
        }
      }
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
        AddUpdateAttribute(areaNode, "X", area.AreaRect.X.ToString());
        AddUpdateAttribute(areaNode, "Y", area.AreaRect.Y.ToString());
        AddUpdateAttribute(areaNode, "Width", area.AreaRect.Width.ToString());
        AddUpdateAttribute(areaNode, "Height", area.AreaRect.Height.ToString());
        AddUpdateAttribute(areaNode, "OriginalXRes", area.OriginalXResolution.ToString());
        AddUpdateAttribute(areaNode, "OriginalYRes", area.OriginalYResolution.ToString());
        AddUpdateAttribute(areaNode, "Movement", area.MovementType.ToString());
        AddUpdateAttribute(areaNode, "AOIType", area.AOIType.ToString());

        SaveNotificationOption(areaNode, area.Notifications);
        SaveCharacteristcs(areaNode, area.SearchCriteria);
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
        AddUpdateAttribute(objNode, "ImageObjectType", obj.ObjectType);
        AddUpdateAttribute(objNode, "Confidence", obj.Confidence.ToString());
        AddUpdateAttribute(objNode, "Overlap", obj.MinPercentOverlap.ToString());
        AddUpdateAttribute(objNode, "TimeFrame", obj.TimeFrame.ToString());
        AddUpdateAttribute(objNode, "MinimumXSize", obj.MinimumXSize.ToString());
        AddUpdateAttribute(objNode, "MinimumYSize", obj.MinimumYSize.ToString());
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
      SaveArea(cam.Path, cam.CameraPrefix, area);
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
      XmlNode? cameraNode = FindCamera(camera.Path, camera.CameraPrefix);

      if (null == cameraNode)
      {
        cameraNode = _doc.CreateElement("Camera");
        _cameras.AppendChild(cameraNode);
      }


      AddUpdateAttribute(cameraNode, "ID", camera.ID.ToString());
      string fullPath = Path.Combine(camera.Path, camera.CameraPrefix);
      AddUpdateAttribute(cameraNode, "FullPath", fullPath);
      AddUpdateAttribute(cameraNode, "Prefix", camera.CameraPrefix);
      AddUpdateAttribute(cameraNode, "Path", camera.Path);
      AddUpdateAttribute(cameraNode, "MotionStoppedTimeout", camera.NoMotionTimeout.ToString());
      AddUpdateAttribute(cameraNode, "RegistrationX", camera.RegistrationX.ToString());
      AddUpdateAttribute(cameraNode, "RegistrationY", camera.RegistrationY.ToString());
      AddUpdateAttribute(cameraNode, "RegistrationXResolution", camera.RegistrationXResolution.ToString());
      AddUpdateAttribute(cameraNode, "RegistrationYResolution", camera.RegistrationYResolution.ToString());
      AddUpdateAttribute(cameraNode, "Monitoring", camera.Monitoring.ToString());

      SetCameraContactData(cameraNode, camera.LiveContactData);

      foreach (AreaOfInterest area in camera.AOI)
      {
        SaveArea(camera.Path, camera.CameraPrefix, area);
      }
    }

    void SetCameraContactData(XmlNode cameraNode, CameraContactData data)
    {
      AddUpdateAttribute(cameraNode, "IPAddress", data.CameraIPAddress);
      AddUpdateAttribute(cameraNode, "CameraPassword", data.CameraPassword);
      AddUpdateAttribute(cameraNode, "UserName", data.CameraUserName);
      AddUpdateAttribute(cameraNode, "XResolution", data.CameraXResolution.ToString());
      AddUpdateAttribute(cameraNode, "YResolution", data.CameraYResolution.ToString());
      AddUpdateAttribute(cameraNode, "Port", data.Port.ToString());
      AddUpdateAttribute(cameraNode, "CameraName", data.ShortCameraName);
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