using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace SAAI
{

  public struct InterestingObject
  {
    public InterestingObject(AreaOfInterest area, ImageObject found, int overlap)
    {
      Area = area;
      FoundObject = found;
      Overlap = overlap;
    }

    public AreaOfInterest Area { get; set; }
    public ImageObject FoundObject { get; set; }
    public int Overlap { get; set; }
  }

  public struct AnalysisResult
  {
    public List<InterestingObject> InterestingObjects { get; set; }
    public HashSet<string> FailureReasons { get; set; }
  }


  internal class FrameAnalyzer
  {

    readonly AreasOfInterestCollection _areas;
    readonly List<ImageObject> _imageObjects;

    List<InterestingObject> InterestingObjects { get; set; }
    public FrameAnalyzer(AreasOfInterestCollection areas, List<ImageObject> imageObjects)
    {
      InterestingObjects = new List<InterestingObject>();
      _areas = areas;
      _imageObjects = imageObjects;
    }

    // because we will probably do this async
    public AnalysisResult AnalyzeFrame()
    {
      AnalysisResult result = new AnalysisResult();
      InterestingObjects.Clear();
      HashSet<string> failureReasons = new HashSet<string>();

      if (null != _areas && _areas.Count() > 0)
      {
        if (null != _imageObjects)
        {
          foreach (ImageObject imageObject in _imageObjects)
          {

            // Each area cares about specific types of objects.
            // The overlap for each type varies as does the confidences.
            // Right now we don't care about the number of frames the object is in or whether
            // the object is moving into or out of the area. 


            foreach (AreaOfInterest area in _areas)
            {

              // The search critera defines whether we are looking for people, vehicles, animals, etc.
              if (null != area.SearchCriteria)
              {
                foreach (ObjectCharacteristics criteria in area.SearchCriteria)
                {
                  // First find out what type of object the AI thinks this is.
                  ImageObjectType objectType = ObjectTypeFromLabel(imageObject.Label);

                  if (criteria.ObjectType != ImageObjectType.Irrelevant)
                  {
                    // If this is a type of object we generally might care about for security purposes
                    // then we compare the overlap to to minimum overlap to see if we still care
                    // (and yes, there are more elegant ways to do this, but it is easier to debug like this

                    if (criteria.ObjectType == objectType)
                    {

                      int percentOverlap = ObjectToAreaOverlap(imageObject, area);

                      if (percentOverlap >= criteria.MinPercentOverlap)
                      {
                        if (area.AOIType == AOIType.IgnoreObjects)
                        {
                          failureReasons.Add(area.AOIName + ": Object in ignored area - " + imageObject.Label);
                          // yes, it met all of our critera, but the critera was to ignore it.
                          // It still may also be in an area we do care about, but we worry about that
                          // in the next loop
                        }
                        else
                        {
                          // OK, we probably care, but how confident are we that this object is something we care about
                          if ((int)Math.Round(imageObject.Confidence * 100) >= criteria.Confidence)
                          {
                            // BUT WAIT, THERE'S MORE!
                            if (criteria.MinimumXSize == 0 || imageObject.ObjectRectangle.Width > criteria.MinimumXSize)
                            {
                              if (criteria.MinimumYSize == 0 || imageObject.ObjectRectangle.Height > criteria.MinimumYSize)
                              {
                                InterestingObject interesting = new InterestingObject(area, imageObject, percentOverlap);
                                InterestingObjects.Add(interesting);

                              }
                              else { failureReasons.Add(area.AOIName + ": Minimum height - too low - " + imageObject.Label); }
                            }
                            else { failureReasons.Add(area.AOIName + ": Minimum width too low - " + imageObject.Label); }
                          }
                          else { failureReasons.Add(area.AOIName + ": Confidence level too low: " + (imageObject.Confidence * 100).ToString() + " - " + imageObject.Label); }
                        }
                      }
                      else { failureReasons.Add(area.AOIName + ": Less than minimum overlap: " + percentOverlap.ToString() + " - " + imageObject.Label); }
                    }
                    else
                    {
                      if (objectType != ImageObjectType.Irrelevant)
                      {
                        failureReasons.Add(area.AOIName + ": Object mismatch: " + criteria.ObjectType.ToString() + " - " + objectType.ToString() + " - " + imageObject.Label);
                      }
                    }
                  }
                  else { /*failureReasons.Add(area.AOIName + ": Object Irrelevant -  " + imageObject.Label); */}
                }
              }
              else 
              {
                failureReasons.Add("No search critera"); 
              }
            }

            // Double check the object to be sure it isn't in a ignore zone.
            // This is a little screwy -- we added one, then we delete the one we just added.
            // However, there are few good ways to do it since an object may be in several areas,
            // yet we dont't want it if it really should be ignored
            foreach (var ignore in _areas)
            {
              if (ignore.AOIType == AOIType.IgnoreObjects)
              {
                // Again, we look at the search criteria to see if it was the type of object we ignore
                if (null != ignore.SearchCriteria)
                {
                  foreach (var criteria in ignore.SearchCriteria)
                  {
                    ImageObjectType objectType = ObjectTypeFromLabel(imageObject.Label);
                    if (criteria.ObjectType == objectType)
                    {
                      // Yes, it is the type of object we ignore
                      int ignoreOverlap = ObjectToAreaOverlap(imageObject, ignore); // Does it overlap
                      {
                        if (ignoreOverlap > criteria.MinPercentOverlap) //
                        {
                          bool foundOne = false;
                          do
                          {
                            var io = InterestingObjects.FirstOrDefault(x => x.FoundObject.ID == imageObject.ID);
                            if (io.FoundObject != null)
                            {
                              foundOne = true;
                              failureReasons.Add(ignore.AOIName + ": Ignore area second pass validation - Object: " + io.FoundObject.Label);
                              InterestingObjects.Remove(io);

                            }
                            else
                            {
                              foundOne = false;
                            }
                          } while (foundOne);
                        }
                      }
                    }
                  }
                }
                else
                {
                  Dbg.Write("FrameAnalyzer.AnalyzeFrame - On double check ignore areas no search critera found ");
                }
              }
            }

          }
        }
        else { failureReasons.Add("No Interesting Objects"); }

        // InterestingObjects = RemoveDuplicateAreas(InterestingObjects);
      }
      else { failureReasons.Add("No areas define"); }

      result.InterestingObjects = InterestingObjects;
      result.FailureReasons = failureReasons;
      return result;
    }

    static List<InterestingObject> RemoveDuplicateAreas(List<InterestingObject> objects)
    {
      if (objects.Count > 1)
      {

        bool foundDuplicate;
        do
        {
          foundDuplicate = false;

          int i;
          for (i = 0; i < objects.Count - 1; i++)
          {
            Rectangle r1 = objects[i].FoundObject.ObjectRectangle;

            for (int j = i + 1; j < objects.Count; j++)
            {
              Rectangle r2 = objects[j].FoundObject.ObjectRectangle;

              if (r1 == r2 && objects[i].FoundObject.Label == objects[j].FoundObject.Label)
              {
                if (objects[i].Overlap > objects[j].Overlap)
                {
                  // They were the same type of object, the same object rectangle
                  // So, if the overlap on one is greater than the other we delete the other
                  objects.RemoveAt(j);
                }
                else
                {
                  objects.RemoveAt(i);
                }

                i = 0;  // start over again
                foundDuplicate = true;
                break;
              }
            }
          }

        } while (foundDuplicate && objects.Count > 1);
      }

      return objects;
    }


    static ImageObjectType ObjectTypeFromLabel(string label)
    {
      ImageObjectType result;

      switch (label)
      {
        case "person":
          result = ImageObjectType.People;
          break;

        case "car":
          result = ImageObjectType.Cars;
          break;

        case "truck":
          result = ImageObjectType.Trucks;
          break;

        case "motorbike":
          result = ImageObjectType.Motorcycles;
          break;

        case "bicycle":
          result = ImageObjectType.Bikes;
          break;

        case "bear":
          result = ImageObjectType.Bears;
          break;

        case "dog":
        case "cat":
        case "horse":
        case "sheep":
        case "cow:":
          result = ImageObjectType.Animals;
          break;

        default:
          result = ImageObjectType.Irrelevant;
          break;
      }

      return result;
    }

    static int ObjectToAreaOverlap(ImageObject imageObject, AreaOfInterest area)
    {
      int overlap;
      int objectArea = imageObject.ObjectRectangle.Width * imageObject.ObjectRectangle.Height;
      _ = area.AreaRect.Width * area.AreaRect.Height;
      Rectangle intersect = Rectangle.Intersect(imageObject.ObjectRectangle, area.AreaRect);
      int intersectArea = intersect.Width * intersect.Height;

      double percentage = (100.0 * intersectArea) / objectArea;
      overlap = (int)Math.Round(percentage);
      return overlap;
    }


  }
}
