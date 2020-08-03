using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Security.Policy;
using System.Configuration;
using DeepStackDisplay.Properties;

namespace DeepStackDisplay
{
  
[Serializable]
  public class AiNotFoundException : Exception
  {
    public AiNotFoundException(string url) : base("The AI Detection process was not found at: " + url + ".  Ensure that the DeepStack AI program is running that this location.")
    {
    }

    public AiNotFoundException() : base() {}

    public AiNotFoundException(string message, System.Exception inner) : base(message, inner) { }

    protected AiNotFoundException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
  }


  public class AISettings
  {
    public string AILocation { get; set; }
    public int AiPort { get; set; }
    public double TimePerFrame { get; set; }
    public string CurrentCameraPath { get; set; }
    public string CurrentCameraPrefix { get; set; }
    public int MaxEventTime { get; set; }
    public int EventInterval { get; set; }


    public static AISettings Load()
    {
      AISettings foundSettings = new AISettings();
      {
        foundSettings.AILocation = Settings.Default.DeepStackIPAddress;
        foundSettings.AiPort = Settings.Default.DeepStackPort;
        foundSettings.TimePerFrame = Settings.Default.TimePerFrame;
        foundSettings.MaxEventTime = Settings.Default.MaxEventTime;
        foundSettings.EventInterval = Settings.Default.EventInterval;
        foundSettings.CurrentCameraPath = Settings.Default.CurrentCameraPath;
        foundSettings.CurrentCameraPrefix = Settings.Default.CurrentCameraPrefix;
      };


      return foundSettings;
    }

    public static void Save(AISettings newSettings)
    {
      Settings.Default.DeepStackIPAddress = newSettings.AILocation;
      Settings.Default.DeepStackPort = newSettings.AiPort;
      Settings.Default.TimePerFrame = newSettings.TimePerFrame;
      Settings.Default.MaxEventTime = newSettings.MaxEventTime;
      Settings.Default.EventInterval = newSettings.EventInterval;
      Settings.Default.CurrentCameraPath = newSettings.CurrentCameraPath;
      Settings.Default.CurrentCameraPrefix = newSettings.CurrentCameraPrefix;
      Settings.Default.DeepstackSetup = true;
      Settings.Default.Save();
    }
  }
}
