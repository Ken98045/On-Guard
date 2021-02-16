using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace OnGuardCore
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
    readonly int _bitmapXResolution;
    readonly int _bitmapYResolution;

    List<InterestingObject> InterestingObjects { get; set; }
    public FrameAnalyzer(AreasOfInterestCollection areas, List<ImageObject> imageObjects, int bitmapXResolution, int bitmapYResolution)
    {
      InterestingObjects = new List<InterestingObject>();
      _areas = areas;
      _imageObjects = imageObjects;
      _bitmapXResolution = bitmapXResolution;
      _bitmapYResolution = bitmapYResolution;
    }

    // because we will probably do this async
    public AnalysisResult AnalyzeFrame()
    {
      AnalysisResult result = new AnalysisResult();
      InterestingObjects.Clear();
      HashSet<string> failureReasons = new HashSet<string>();
      string reason = string.Empty;

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
              if (area.IsItemOfAreaInterest(imageObject.Label))
              {
                // The search critera defines whether we are looking for people, vehicles, animals, etc.
                if (null != area.SearchCriteria)
                {
                  foreach (ObjectCharacteristics criteria in area.SearchCriteria)
                  {
                    // First find out what type of object the AI thinks this is.
                    // If this is a type of object we generally might care about for security purposes
                    // then we compare the overlap to to minimum overlap to see if we still care
                    // (and yes, there are more elegant ways to do this, but it is easier to debug like this

                    if (MatchesSpecialTag(criteria, imageObject.Label) || criteria.ObjectType == imageObject.Label)
                    {

                      int percentOverlap = ObjectToAreaOverlap(imageObject, area, _bitmapXResolution, _bitmapYResolution);

                      if (percentOverlap >= criteria.MinPercentOverlap)
                      {
                        if (area.AOIType == AOIType.IgnoreObjects)
                        {
                          reason = area.AOIName + ": Object in ignored area - " + imageObject.Label;
                          failureReasons.Add(reason);
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
                                Dbg.Trace("Adding interesting object before 2nd chance ignore: " + interesting.FoundObject.Label);

                              }
                              else
                              {
                                reason = area.AOIName + ": Minimum height - too low - " + imageObject.Label;
                                failureReasons.Add(reason);
                              }
                            }
                            else
                            {
                              reason = area.AOIName + ": Minimum width too low - " + imageObject.Label;
                              failureReasons.Add(reason);
                            }
                          }
                          else
                          {
                            reason = area.AOIName + ": Confidence level too low: " + (imageObject.Confidence * 100).ToString() + " - " + imageObject.Label;
                            failureReasons.Add(reason);
                          }
                        }
                      }
                      else
                      {
                        reason = area.AOIName + ": Less than minimum overlap: " + percentOverlap.ToString() + " - " + imageObject.Label;
                        failureReasons.Add(reason);
                      }
                    }
                    else
                    {
                      if (!MatchesSpecialTag(criteria, imageObject.Label) && criteria.ObjectType != imageObject.Label)
                      {
                        reason = area.AOIName + ": Object mismatch: " + criteria.ObjectType + " - " + imageObject.Label;
                        failureReasons.Add(reason);
                      }
                    }
                  }
                }
                else
                {
                  reason = "No search critera";
                  failureReasons.Add(reason);
                }
              }
              else
              {
                reason = "Object: " + imageObject.Label + " does not match any searh criteria for area: " + area.AOIName;
                failureReasons.Add(reason);
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
                    if (MatchesSpecialTag(criteria, imageObject.Label) ||  criteria.ObjectType == imageObject.Label)
                    {
                      // Yes, it is the type of object we ignore
                      int ignoreOverlap = ObjectToAreaOverlap(imageObject, ignore, _bitmapXResolution, _bitmapYResolution); // Does it overlap
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
                              reason = ignore.AOIName + ": Ignore area second pass validation - Object: " + io.FoundObject.Label;
                              failureReasons.Add(reason);
                              Dbg.Trace("Removing object on second pass ignore area validation: " + io.FoundObject.Label);
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
      else { failureReasons.Add("No areas defined"); }

      result.InterestingObjects = InterestingObjects;
      result.FailureReasons = failureReasons;

      foreach (var failure in failureReasons)
      {
        Dbg.Trace(failure);
      }

      return result;
    }

    // TODO Not currently used.
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


    public static bool IsMammal(string label)
    {
      bool result = false;

      switch (label)
      {
        case "dog":
        case "bear":
        case "cat":
        case "horse":
        case "sheep":
        case "cow":
        case "elephant":
        case "zebra":
        case "giraffe":
          result = true;
          break;
      }

      return result;
    }

    public static bool MatchesSpecialTag(ObjectCharacteristics objChar, string label)
    {
      bool result = false;

      switch (objChar.ObjectType)
      {
        case "* Any Vehicle":
          result = IsVehicle(label);
          break;

        case "* Any Mammal":
          result = IsMammal(label);
          break;
      }


      return result;
    }

    public static bool IsVehicle(string label)
    {
      bool result = false;

      switch(label)
      {
        case "car":
        case "truck":
        case "bicycle":
        case "motorbike":
        case "bus":
        case "train": // ?
        case "boat":
        case "aeroplane":
          result = true;
          break;
      }

      return result;
    }


    // As people (or other animals) walk in front of a car it can change the outline of the car
    // However, if the car is close enough to be recognized as a car, it would be somewhat rare for one person/animal
    // to change both the left and right edges of the car.  This can easily happen with multiple people,
    // and rarely may happen with one person.  While the outline of the car can be changed enough that
    // it is no longer recognized as a car, not much we can do about that.  
    // So, here we do the best we can
    static bool AnimalOverlapsVehicleEdge(ImageObject vehicle, List<ImageObject> foundObjects)
    {
      bool result = false;
      // For now we just return false since thi feature is still bing worked on!
      return result;
    }

    public static ImageObjectType ObjectTypeFromLabel(string label)
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

    static int ObjectToAreaOverlap(ImageObject imageObject, AreaOfInterest area, int xResolution, int yResolution)
    {
      int overlap;

      Rectangle adjRect = new Rectangle(area.AreaRect.X, area.AreaRect.Y, area.AreaRect.Width, area.AreaRect.Height);
      adjRect.X = (int)((double)adjRect.X * ((double)(xResolution) / (double)area.OriginalXResolution));
      adjRect.Y = (int)((double)adjRect.Y * ((double)(yResolution) / (double)(area.OriginalYResolution)));
      adjRect.Width = (int)((double)adjRect.Width * ((double)(BitmapResolution.XResolution) / (double)area.OriginalXResolution));
      adjRect.Height = (int)((double)adjRect.Height * ((double)(yResolution) / (double)area.OriginalYResolution));

      int objectArea = imageObject.ObjectRectangle.Width * imageObject.ObjectRectangle.Height;
      _ = area.GetRect().Width * area.GetRect().Height;
      Rectangle intersect = Rectangle.Intersect(imageObject.ObjectRectangle, adjRect);
      int intersectArea = intersect.Width * intersect.Height;

      double percentage = (100.0 * intersectArea) / objectArea;
      overlap = (int)Math.Round(percentage);
      return overlap;
    }


  }
}
