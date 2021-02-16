using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
using System.Xml;
using System.Xml.Serialization;

using System;
using System.Collections.Generic;


namespace OnGuardCore
{
  public class XMLStorage
  {
    const string _fileName = "OnGuard.xml";
    XmlDocument _doc;
    XmlNode _base;
    XmlNode _cameras;

    public XMLStorage()
    {
      CreateBaseTree();
    }

    void CreateBaseTree()
    {
      _doc = new XmlDocument();

      try
      {
        _doc.LoadXml(_fileName);
        XmlElement _root = _doc.DocumentElement;
        XmlNode publisher = _root.FirstChild;
        _base = publisher.FirstChild;
        _cameras = _base.SelectSingleNode("Cameras");
      }
      catch (IOException)
      {
        XmlElement root = _doc.CreateElement("K2Software"); // for compat sake
        XmlNode publisher = _doc.AppendChild(root);
        XmlElement app = _doc.CreateElement("OnGuard");
        _base = publisher.AppendChild(app);
        XmlElement camera = _doc.CreateElement("Cameras");
        _cameras = _base.AppendChild(camera);
        _doc.Save(_fileName);
      }
    }

    void SetGlobal(string name, string val)
    {

      ((XmlElement)(_base)).SetAttribute(name, val);
    }

    string GetGlobal(string name)
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

    int GetGlobalIntExcept(string keyName)
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



    void DeleteArea(string cameraPath, string cameraPrefix, AreaOfInterest area)
    {

    }

    List<AILocation> GetAILocations()
    {
      List<AILocation> result = new List<AILocation>();


      return result;
    }

    SortedDictionary<Guid, AreaOfInterest> GetAllAreas(string cameraPath, string cameraPrefix)
    {
      SortedDictionary<Guid, AreaOfInterest> result = new SortedDictionary<Guid, AreaOfInterest>();


      return result;

    }

    CameraCollection GetAllCameras()
    {
      CameraCollection result = new CameraCollection();


      return result;
    }

    string GetAppVersion()
    {
      string result = string.Empty;

      return result;
    }
    AreaOfInterest GetArea(string camKey, Guid areaID)
    {
      AreaOfInterest result = new AreaOfInterest();


      return result;
    }

    int GetCameraInt(string cameraPath, string cameraPrefix, string keyName)
    {
      int result = 0;


      return result;
    }

    string GetCameraPath(string key)
    {
      string result = string.Empty;

      return result;
    }

    string GetCameraPrefix(string reg)
    {
      string result = string.Empty;


      return result;

    }


    List<ObjectCharacteristics> GetCharacteristics(string key)
    {
      List<ObjectCharacteristics> result = new List<ObjectCharacteristics>();

      return result;
    }

    CameraContactData GetContactData(string key)
    {
      CameraContactData result = new CameraContactData();

      return result;

    }

    List<EmailOptions> GetEmailAddresses()
    {
      List<EmailOptions> result = new List<EmailOptions>();

      return result;
    }
    string GetFilePath(string fileName)
    {
      string result = string.Empty;

      return result;
    }

    object GetGetValue(string keyName)
    {
      object result = new object();

      return result;
    }

    string GetGlobalStringNull(string keyName)
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

    void SetAppVersion(string version)
    {
      SetGlobal("CurrentVersion", version);
    }


    AreaNotificationOption GetNotificationOption(string key)
    {
      AreaNotificationOption result = new AreaNotificationOption();


      return result;
    }

    void RemoveAILocation(string id)
    {

    }

    void SaveAllAreas(string cameraPath, string cameraPrefix, AreasOfInterestCollection areas)
    {

    }
    void SaveArea(AreaOfInterest area)
    {

    }

    void SaveArea(CameraData cam, AreaOfInterest area)
    {

    }
    void SaveArea(string camKey, AreaOfInterest area)
    {

    }

    void SaveArea(string cameraPath, string cameraPrefix, AreaOfInterest area)
    {

    }

    void SaveCamera(string camKey, CameraData camera)
    {

    }

    void SaveCameras(CameraCollection allCameras)
    {

    }

    void SaveCharacteristcs(string key, List<ObjectCharacteristics> objectChar)
    {

    }

    void SaveEmailAddresses(List<EmailOptions> addresses)
    {

    }

    void SaveNotificationOption(string key, AreaNotificationOption options)
    {

    }

    void SetAILocation(AILocation location)
    {

    }

    void SetCameraContactData(string key, CameraContactData data)
    {

    }
    void SetCameraInt(string cameraPath, string cameraPrefix, string keyName, int theValue)
    {

    }

  }
}