using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnGuardCore
{

  /// <summary>
  /// When defining an Area of Interest each object type in an area has optional 
  /// characteristics that define when an object on the screen is consdiered
  /// "Interesting"
  /// </summary>
  [Serializable]
  public class ObjectCharacteristics
  {
    private string objectType;
    public int Confidence { get; set; }       // Confidence values are very good in defining "people". 
    public int MinPercentOverlap { get; set; }  // A measurement for how much of an object must overlap the Area of Interest to be considered Interesting
    public int TimeFrame { get; set; } // Currently not implemented.  When we determine movement direction this will define how many frames we look in
    public int MinimumXSize { get; set; }   //In part this regulates how close the object is to the camera.  I don't see a reason for maximum size
    public int MinimumYSize { get; set; }   //In part this regulates how close the object is to the camera.  I don't see a reason for maximum size

    public List<FaceID> Faces {get; set;}

    public string ObjectType { get => objectType; set => objectType = value; } 

    public Guid ID { get; set; }

    public ObjectCharacteristics()
    {
      ID = Guid.NewGuid();
      objectType = "person";
      Confidence = 90;
      MinPercentOverlap = 50;
      TimeFrame = 1;
      MinimumXSize = 0;
      MinimumYSize = 0;
      Faces = new List<FaceID>();
    }

    public ObjectCharacteristics(ObjectCharacteristics src)
    {
      ID = src.ID;
      objectType = src.objectType;
      Confidence = src.Confidence;
      MinPercentOverlap = src.MinPercentOverlap;
      TimeFrame = src.TimeFrame;
      MinimumXSize = src.MinimumXSize;
      MinimumYSize = src.MinimumYSize;
      Faces = src.Faces;
    }
  }
}
