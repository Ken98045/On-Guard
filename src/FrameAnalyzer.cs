using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace OnGuardCore
{


  public class AnalysisResult
  {
    public AnalysisResult()
    {
      InterestingObjects = new();
      FailureReasons = new();
    }
    public List<InterestingObject> InterestingObjects { get; set; }
    public HashSet<string> FailureReasons { get; set; }
  }

  internal class FrameAnalyzer
  {

    readonly AreasOfInterestCollection _areas;

    readonly int _bitmapXResolution;
    readonly int _bitmapYResolution;
    Bitmap _pictureImage;
    List<InterestingObject> PotentialObjects { get; set; }
    List<InterestingObject> InterestingObjects { get; set; }


    public FrameAnalyzer(AreasOfInterestCollection areas, List<InterestingObject> potentialObjects, int bitmapXResolution, int bitmapYResolution)
    {
      InterestingObjects = new List<InterestingObject>();
      PotentialObjects = potentialObjects;
      _areas = areas;
      _bitmapXResolution = bitmapXResolution;
      _bitmapYResolution = bitmapYResolution;
    }

    public async Task<AnalysisResult> AnalyzeFrameAsync(Bitmap pictureImage)
    {
      _pictureImage = pictureImage;
      AnalysisResult result = new();

      var areas = _areas.ToList();

      string reason = string.Empty;

      if (null != _areas && _areas.Count() > 0)
      {
        if (null != PotentialObjects)
        {
          for (int i = 0; i < PotentialObjects.Count; i++)
          {
            InterestingObject pi = PotentialObjects[i];  // shortcut, saves typing

            // Each area cares about specific types of objects.
            // The overlap for each type varies as does the confidences.
            // Right now we don't care about the number of frames the object is in or whether
            // the object is moving into or out of the area. 
            for (int areaNumber = 0; areaNumber < areas.Count; areaNumber++)
            {
              AreaOfInterest area = areas[areaNumber];

              if (area.IsItemOfAreaInterest(pi.Label))
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

                    if (MatchesSpecialTag(criteria, pi.Label) || criteria.ObjectType == pi.Label)
                    {

                      int percentOverlap = ObjectToAreaOverlap(pi, area, _bitmapXResolution, _bitmapYResolution);

                      if (percentOverlap >= criteria.MinPercentOverlap)
                      {
                        if (area.AOIType == AOIType.IgnoreObjects)
                        {
                          reason = area.AOIName + ": Object in ignored area - " + pi.Label;
                          result.FailureReasons.Add(reason);
                          // yes, it met all of our critera, but the critera was to ignore it.
                          // It still may also be in an area we do care about, but we worry about that
                          // in the next loop
                        }
                        else
                        {
                          // OK, we probably care, but how confident are we that this object is something we care about
                          if ((int)Math.Round(pi.Confidence * 100) >= criteria.Confidence)
                          {
                            // BUT WAIT, THERE'S MORE!
                            double screenWidthPercent = Math.Round((100.0 * pi.ObjectRectangle.Width) / BitmapResolution.XResolution, 1, MidpointRounding.AwayFromZero);
                            double screenHeightPercent = Math.Round((100.0 * pi.ObjectRectangle.Height) / BitmapResolution.YResolution, 1, MidpointRounding.AwayFromZero);

                            if (criteria.MinimumXSize == 0 || screenWidthPercent > criteria.MinimumXSize)
                            {
                              if (criteria.MinimumYSize == 0 || screenHeightPercent > criteria.MinimumYSize)
                              {
                                pi.Overlap = percentOverlap;

                                InterestingObject added = new(pi);
                                added.Overlap = percentOverlap;       // so far, the only thing different
                                added.Area = area;
                                result.InterestingObjects.Add(added);
                                Dbg.Write(LogLevel.Verbose, "Adding interesting object before 2nd chance ignore: " + pi.Label);

                              }
                              else
                              {
                                reason = area.AOIName + ": Minimum height - too low - " + pi.Label;
                                result.FailureReasons.Add(reason);
                              }
                            }
                            else
                            {
                              reason = area.AOIName + ": Minimum width too low - " + pi.Label;
                              result.FailureReasons.Add(reason);
                            }
                          }
                          else
                          {
                            reason = area.AOIName + ": Confidence level too low: " + (pi.Confidence * 100).ToString() + " - " + pi.Label;
                            result.FailureReasons.Add(reason);
                          }
                        }
                      }
                      else
                      {
                        reason = area.AOIName + ": Less than minimum overlap: " + percentOverlap.ToString() + " - " + pi.Label;
                        result.FailureReasons.Add(reason);
                      }
                    }
                    else
                    {
                      if (!MatchesSpecialTag(criteria, pi.Label) && criteria.ObjectType != pi.Label)
                      {
                        reason = area.AOIName + ": Object mismatch: " + criteria.ObjectType + " - " + pi.Label;
                        result.FailureReasons.Add(reason);
                      }
                    }
                  }
                }
                else
                {
                  reason = "No search critera";
                  result.FailureReasons.Add(reason);
                }
              }
              else
              {
                reason = "Object: " + pi.Label + " does not match any search criteria for area: " + area.AOIName;
                result.FailureReasons.Add(reason);
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
                    if (MatchesSpecialTag(criteria, pi.Label) || criteria.ObjectType == pi.Label)
                    {
                      // Yes, it is the type of object we ignore
                      int ignoreOverlap = ObjectToAreaOverlap(pi, ignore, _bitmapXResolution, _bitmapYResolution); // Does it overlap
                      {
                        if (ignoreOverlap > criteria.MinPercentOverlap) //
                        {
                          bool foundOne = false;
                          do
                          {
                            var io = result.InterestingObjects.FirstOrDefault(x => x.ID == pi.ID);
                            if (io != null)
                            {
                              foundOne = true;
                              reason = ignore.AOIName + ": Ignore area second pass validation - Object: " + io.Label;
                              result.FailureReasons.Add(reason);
                              try
                              {
                                Dbg.Write(LogLevel.Verbose, "Removing object on second pass ignore area validation: " + io.Label);
                                result.InterestingObjects.Remove(io);
                              }
                              catch (Exception ex)
                              {
                                Dbg.Write(LogLevel.Verbose, "FrameAnalyzer-AnalyzeFrameAsync- exception removing object in remove from interesting objects : " + ex.Message);
                              }

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
                  Dbg.Write(LogLevel.Verbose, "FrameAnalyzer.AnalyzeFrame - On double check ignore areas no search critera found ");
                }
              }
            }

          }
        }
        else { result.FailureReasons.Add("No Interesting Objects"); }

      }
      else { result.FailureReasons.Add("No areas defined"); }

      if (result.InterestingObjects.Count > 0)
      {
        await CheckForFaces(result).ConfigureAwait(true); // may delete people if we were looking for a face
      }

      InterestingObjects = RemoveDuplicateAreas(InterestingObjects);

      foreach (var failure in result.FailureReasons)
      {
        Dbg.Write(LogLevel.DetailedInfo, failure);
      }


      return result;
    }


    // Here we have a fully validated list of interesting objects.
    // Go through the people and IF we need to try to recognize a face.
    // If there is a face we are interested in then add it to the result list
    async Task CheckForFaces(AnalysisResult result)
    {
      Dictionary<string, InterestingObject> peopleToDelete = new();
      Dictionary<string, InterestingObject> peopleNotToDelete = new();
      List<InterestingObject> InterestingFaces = new();

      foreach (InterestingObject obj in result.InterestingObjects)
      {
        if (obj.Label == "person")
        {
          if (obj.Area.AOIType == AOIType.FacialRecognition)
          {
            foreach (ObjectCharacteristics searchCriteria in obj.Area.SearchCriteria)
            {
              int selectedFaces = 0;
              if (searchCriteria.Faces.Count > 0)
              {
                foreach (FaceID face in searchCriteria.Faces)
                {
                  if (face.Selected)
                  {
                    selectedFaces++;
                  }
                }

                if (selectedFaces > 0)
                {
                  // OK, here we know we are looking for at least one face
                  InterestingObject aiFaceObject = await FaceDetection.LookForFaceAsync(_pictureImage, obj, false);

                  if (aiFaceObject != null)
                  {
                    // So, we have a face, but is it one we are interested in?
                    foreach (FaceID face in searchCriteria.Faces)
                    {
                      if (face.Name == aiFaceObject.Label)
                      {
                        if (face.Selected)
                        {
                          if (aiFaceObject.Confidence * 100.0 >= face.Confidence)
                          {
                            InterestingObject interestingFace = new InterestingObject
                            {
                              IsFace = true,
                              Label = face.Name,
                              Area = obj.Area,
                              ObjectRectangle = aiFaceObject.ObjectRectangle,

                              Confidence = aiFaceObject.Confidence
                            };
                            InterestingFaces.Add(interestingFace);
                          }
                          else
                          {
                            result.FailureReasons.Add("The confidence for face: " + aiFaceObject.Label + " was too low: " + aiFaceObject.Confidence.ToString());
                          }
                        }
                        else
                        {
                          result.FailureReasons.Add(" The face " + aiFaceObject.Label + " was not a selected critera.");
                        }
                      }
                      else
                      {
                        result.FailureReasons.Add("Face: " + face.Name + " does not match found face " + aiFaceObject.Label);
                      }
                    }

                  }
                }
              }

            }

            peopleToDelete[obj.ID.ToString()] = obj;
          }
          else
          {
            peopleNotToDelete[obj.ID.ToString()] = obj;
          }

        }
      }

      foreach (InterestingObject io in InterestingFaces)
      {
        result.InterestingObjects.Add(io);
      }

      // OK This was a facial recognition area, and it was a person. 
      // Regardless of the fact that there was a face we recognized, we delete the "person" 
      // because we don't care about "people", only faces.
      // However, if it was also in another area type that WAS LOOKING FOR PEOPLE, then
      // we keep it.

      foreach (var toDel in peopleToDelete.Values)
      {
        if (!peopleNotToDelete.ContainsKey(toDel.ID.ToString()))
        {
          result.InterestingObjects.Remove(toDel);
          result.FailureReasons.Add("person deleted since this area looks only for faces");
        }
      }

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
            Rectangle r1 = objects[i].ObjectRectangle;

            for (int j = i + 1; j < objects.Count; j++)
            {
              Rectangle r2 = objects[j].ObjectRectangle;

              if (r1 == r2 && objects[i].Label == objects[j].Label)
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

      switch (label)
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
    static bool AnimalOverlapsVehicleEdge(InterestingObject vehicle, List<InterestingObject> foundObjects)
    {
      bool result = false;
      // For now we just return false since thi feature is still bing worked on!
      return result;
    }

    public static InterestingObjectType ObjectTypeFromLabel(string label)
    {
      InterestingObjectType result;

      switch (label)
      {
        case "person":
          result = InterestingObjectType.People;
          break;

        case "car":
          result = InterestingObjectType.Cars;
          break;

        case "truck":
          result = InterestingObjectType.Trucks;
          break;

        case "motorbike":
          result = InterestingObjectType.Motorcycles;
          break;

        case "bicycle":
          result = InterestingObjectType.Bikes;
          break;

        case "bear":
          result = InterestingObjectType.Bears;
          break;

        case "dog":
        case "cat":
        case "horse":
        case "sheep":
        case "cow:":
          result = InterestingObjectType.Animals;
          break;

        default:
          result = InterestingObjectType.Irrelevant;
          break;
      }


      return result;
    }

    static int ObjectToAreaOverlap(InterestingObject InterestingObject, AreaOfInterest area, int xResolution, int yResolution)
    {
      int overlap;

      int totalGrids = 0;
      int gridsOverlapped = 0;
      int totalAreaOverlapped = 0;
      int xStride = xResolution / area.Grid.XDim;
      int yStride = yResolution / area.Grid.YDim;

      int objectArea = (InterestingObject.X_max - InterestingObject.X_min) * (InterestingObject.Y_max - InterestingObject.Y_min);


      for (int row = 0; row < area.Grid.YDim; row++)
      {
        for (int col = 0; col < area.Grid.XDim; col++)
        {
          if (area.Grid.Get(col, row))
          {
            ++totalGrids;

            Rectangle gridRect = new Rectangle(col * xStride, row * yStride, xStride, yStride);
            Rectangle overlapRect = Rectangle.Intersect(gridRect, InterestingObject.ObjectRectangle);
            int gridArea = gridRect.Width * gridRect.Height;
            int overlapArea = overlapRect.Width * overlapRect.Height;
            totalAreaOverlapped += overlapArea;
          }
        }
      }


      double percentage = 100.0 * ((double)totalAreaOverlapped) / (double)objectArea;
      overlap = (int)Math.Round(percentage);
      return overlap;
    }


  }
}
