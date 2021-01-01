using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAAI
{

/// <summary>
/// When defining an Area of Interest each object type in an area has optional 
/// characteristics that define when an object on the screen is consdiered
/// "Interesting"
/// </summary>
  [Serializable]
  public class ObjectCharacteristics
  {
    private ImageObjectType objectType;
    public int Confidence { get; set; }       // Confidence values are very good in defining "people". 
    public int MinPercentOverlap { get; set; }  // A measurement for how much of an object must overlap the Area of Interest to be considered Interesting
    public int NumberOfFrames { get; set; } // Currently not implemented.  When we determine movement direction this will define how many frames we look in
    public int MinimumXSize { get; set; }   //In part this regulates how close the object is to the camera.  I don't see a reason for maximum size
    public int MinimumYSize { get; set; }   //In part this regulates how close the object is to the camera.  I don't see a reason for maximum size

    public ImageObjectType ObjectType { get => objectType; set => objectType = value; } // people, animals, cars, etc.

    public ObjectCharacteristics()
    {
      objectType = ImageObjectType.People;
      Confidence = 90;
      MinPercentOverlap = 50;
      NumberOfFrames = 1;
      MinimumXSize = 0;
      MinimumYSize = 0;

    }

    public ObjectCharacteristics(ObjectCharacteristics src)
    {
      objectType = src.objectType;
      Confidence = src.Confidence;
      MinPercentOverlap = src.MinPercentOverlap;
      NumberOfFrames = src.NumberOfFrames;
      MinimumXSize = src.MinimumXSize;
      MinimumYSize = src.MinimumYSize;
    }
  }
}
