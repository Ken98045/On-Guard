using System;
using System.Collections.Generic;
using Microsoft.Win32;

namespace OnGuardCore
{
  public interface IStorage
  {
    void CreateBaseTree();
    void DeleteArea(string cameraPath, string cameraPrefix, AreaOfInterest area);
    AILocation GetAILocation();
    SortedDictionary<Guid, AreaOfInterest> GetAllAreas(string cameraPath, string cameraPrefix);
    CameraCollection GetAllCameras();
    string GetAppVersion();
    int GetCameraInt(string cameraPath, string cameraPrefix, string keyName);
    List<EmailOptions> GetEmailAddresses();
    object GetValue(string keyName);
    bool GetGlobalBool(string keyName);
    bool GetGlobalBool(string keyName, bool useDefault);
    double GetGlobalDouble(string keyName);
    int GetGlobalInt(string keyName);
    int GetGlobalIntExcept(string keyName);
    string GetGlobalString(string keyName);
    string GetGlobalStringNull(string keyName);
    void RemoveGlobalValue(string valueName);
    void SaveAllAreas(string cameraPath, string cameraPrefix, AreasOfInterestCollection areas);
    void SaveArea(AreaOfInterest area);
    void SaveArea(CameraData cam, AreaOfInterest area);
    void SaveArea(string cameraPath, string cameraPrefix, AreaOfInterest area);
    void SaveCameras(CameraCollection allCameras);
    void SaveEmailAddresses(List<EmailOptions> addresses);
    void SetAILocation(string ipAddress, int port);
    void SetAppVersion(string version);
    void SetCameraInt(string cameraPath, string cameraPrefix, string keyName, int theValue);
    void SetGlobalBool(string keyName, bool value);
    void SetGlobalDouble(string keyName, double value);
    void SetGlobalInt(string keyName, int value);
    void SetGlobalString(string keyName, string value);
    void Update();
  }
}