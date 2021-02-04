using SAAI.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SAAI
{


  class Response
  {
    public bool Success { get; set; }
    public ImageObject[] Predictions { get; set; }
  }



  /// <summary>
  /// AIAnalyzer is the class that contacts the AI to analyze the picture.
  /// 
  /// /// </summary>
  class AIAnalyzer
  {
    List<ImageObject> _previousVehicles = new List<ImageObject>();
    // readonly List<ImageObject> _previousPeople = new List<ImageObject>();  // The usually do move, but
    readonly private object _fileLock = new object();

    const int MultiDefinitionOverlap = 95;
    const int ParkedOverlap = 97;
    const double minVehicleConfidence = 0.45;
    const double parkedTargetDistance = 0.04;
    const double parkedTargetMax = 10.0;

    public AIAnalyzer()
    {
    }


    public SortedList<DateTime, string> Init(string cameraNamePrefix, string cameraFilePath)
    {
      SortedList<DateTime, string> fileNames = new SortedList<DateTime, string>(new FileTimeComparer());

      lock (_fileLock)
      {
        SortedDictionary<DateTime, string> dateSortedList = new SortedDictionary<DateTime, string>();
        string fileSearch = string.Format("{0}*.jpg", cameraNamePrefix);
        string[] files = Directory.GetFiles(cameraFilePath, fileSearch, SearchOption.TopDirectoryOnly);
        foreach (string file in files)
        {
          dateSortedList[File.GetCreationTime(file)] = file;
        }

        foreach (var fileName in files.Reverse())
        {
          FileInfo fi = new FileInfo(fileName);
          fileNames[fi.LastWriteTime] = fileName;
        }
      }

      return fileNames;
    }


    /*public async void AnalyzeAllImages(string path)
    {
      int count = 0;

      DateTime start = DateTime.Now;
      SortedDictionary<DateTime, string> dateSortedList = new SortedDictionary<DateTime, string>();

      string[] files = Directory.GetFiles(path, "*.jpg", SearchOption.TopDirectoryOnly);
      foreach (string file in files)
      {
        dateSortedList.Add(File.GetCreationTime(file), file);
      }


      DebugWriter.Write("Files to be processed: " + files.Length.ToString());

      foreach (var file in dateSortedList)
      {
        ++count;
        DebugWriter.Write("File: " + count.ToString() + " -- " +  file.Value);
        // List<ImageObject> objectList = ProcessVideoImageViaAI(file.Value).Result;
        // AnalyzeImage(objectList);
      }

      var elapsed = DateTime.Now - start;
      DebugWriter.Write(elapsed.ToString());

      Thread.Sleep(Timeout.Infinite);

    }*/



    public void RemoveInvalidObjects(CameraData camera, List<ImageObject> images)
    {
      if (images != null && camera != null)
      {
        RemoveItemsOfNoInterest(camera, images);  // weed out objects no areas are interested in

        //First, weed out any vehicles that are overlapps within this picture
        // This often happens when the same vehicles is identified as both a car and a truck (SUV, pickup, cars/trucks at an angle)
        RemoveDuplicateVehiclesInImage(images);
        RemoveUnmovedVehicles(camera, images);  // Now, remove vehicles that haven't moved
      }
    }


    /// <summary>
    /// Goes through the list of areas for this camera and determines if ANY area finds this at all interesting
    /// </summary>
    /// <param name="camera"></param>
    /// <param name="images"></param>
    public static void RemoveItemsOfNoInterest(CameraData camera, List<ImageObject> images)
    {
      List<ImageObject> result = new List<ImageObject>();

      bool addedOne = false;
      foreach (ImageObject io in images)
      {
        foreach (AreaOfInterest area in camera.AOI)
        {
          if (null != area.SearchCriteria)
          {
            foreach (ObjectCharacteristics objectCritera in area.SearchCriteria)
            {
              if (objectCritera.ObjectType == io.Label || FrameAnalyzer.MatchesSpecialTag(objectCritera, io.Label))
              {
                result.Add(io);
                addedOne = true;
                break;  // only add each object once
              }
            }
            if (addedOne)
            {
              break;
            }
          }
        }

        if (!addedOne)
        {
          Dbg.Trace("AIAnalyzer - RemoveItemsOfNoInterest - Camera: " + camera.CameraPrefix + " - Weeded out: " + io.Label);
        }
      }

      images.Clear();
      images.AddRange(result);

    }



    // This returns a list of vehicles that are unique to this frame.  
    // However, it has an intended side effect: If 2 separate vehicles share the same space but are classified differently (car/truck/etc.)
    // then we ARTIFICIALLY boost the confidence level of the one we select. 
    // For instance the same object (almost the same outline) may be .50 confident of being a car and 65% confident of being a truck.
    // The AI isn't sure which it is but it is pretty damn sure it IS a vehicle of some sort.  
    // I really dislike doing this, but with the way the AI is now it is better to cheat an be accurate than not cheat and give a misleading result;
    public static void RemoveDuplicateVehiclesInImage(List<ImageObject> objectList)
    {

      List<ImageObject> vehicles = new List<ImageObject>();
      int nonVehicleObjects = 0;

      if (objectList != null && objectList.Count > 0)
      {

        foreach (ImageObject obj in objectList)
        {
          if (IsVehicle(obj))
          {
            if (obj.Confidence > minVehicleConfidence)
            {
              vehicles.Add(obj);
            }
          }
          else
          {
            ++nonVehicleObjects;
          }
        }

        if (vehicles.Count == 1)
        {
          // nothing to do, just a little clearer
        }
        else
        {
          int i = 0;


          // Almost always you won't see more than 2 definitions for one real object, but it can happen
          while (i < vehicles.Count - 1)
          {

            bool removedOne = false;

            for (int j = i + 1; j < vehicles.Count; j++)
            {

              if (vehicles[i].Label != vehicles[j].Label)    // If A == car && B == car we never weed them
              {
                int overlap = GetOverlap(vehicles[i], vehicles[j]);

                if (overlap > MultiDefinitionOverlap)
                {
                  // OK, here we assume that they are the same object.
                  // We add which ever has the highest confidence level to the result;

                  if (vehicles[i].Confidence > vehicles[j].Confidence)
                  {
                    // This case is for the earlier > later
                    double beforeConfidence = vehicles[i].Confidence;
                    vehicles[i].Confidence = vehicles[i].Confidence + ((vehicles[i].Confidence - vehicles[j].Confidence) * 4.0);
                    if (vehicles[i].Confidence >= 1.0)
                    {
                      vehicles[i].Confidence = 0.9999;  // this number is below 1 and is magic in the sense that it can be recognized by the user
                    }

                    Dbg.Trace("Boosting vehicle confidence from: " + beforeConfidence.ToString() + " After: " + vehicles[i].Confidence.ToString());

                    Dbg.Trace("Removing duplicate vehicle (1) " + vehicles[j].Label);
                    // Since there was an overlap, remove the lower confidence vehicle
                    objectList.RemoveAll(obj => obj.ID == vehicles[j].ID);  // and remove it from the passed list
                    vehicles.RemoveAt(j);
                    removedOne = true;
                    break;
                  }
                  else
                  {
                    // This case is for the later > earlier
                    double beforeConfidence = vehicles[j].Confidence;
                    vehicles[j].Confidence = vehicles[j].Confidence + ((vehicles[j].Confidence - vehicles[i].Confidence) * 4.0);
                    if (vehicles[j].Confidence >= 1.0)
                    {
                      vehicles[j].Confidence = 0.9999;  // this number is below 1 and is magic in the sense that it can be recognized by the user
                    }

                    Dbg.Trace("Boosting vehicle confidence from: " + beforeConfidence.ToString() + " After: " + vehicles[j].Confidence.ToString());

                    Dbg.Trace("Removing duplicate vehicle (2): " + vehicles[i].Label);
                    objectList.RemoveAll(obj => obj.ID == vehicles[i].ID);  // and remove it from the passed list
                    vehicles.RemoveAt(i);   // We only do the vehicle once.
                    removedOne = true;
                    break;
                  }
                }
              }
            }

            if (removedOne)
            {
              i = 0; // Since we removed on we need to start over
            }
            else
            {
              i++;  // and on to the next
            }
          }
        }
      }

      Dbg.Trace("Objects after duplicate vehicle check: " + objectList.Count.ToString());
    }

    // I am assuming that if there are people then there is motion.
    // We could further refine this by comparing movement by tracking people in the last image set
    // and comparing there rectangles.  BUT the AI is REALLY good at identifying people
    static List<ImageObject> GetPeople(List<ImageObject> imageObjects)
    {
      List<ImageObject> people = new List<ImageObject>();

      foreach (ImageObject image in imageObjects)
      {
        if (image.Success && image.Confidence > .075) // Again, the AI is good at this (plus we normally look at more than 1 image
        {
          if (image.Label == "person")
          {
            people.Add(image);
          }
        }
      }

      return people;
    }


    void RemoveUnmovedVehicles(CameraData camera, List<ImageObject> objectList)
    {
      Dbg.Trace("Object count before removing parked: " + objectList.Count.ToString());

      List<ImageObject> vehicles = new List<ImageObject>();
      int nonVehicleObjects = 0;

      if (objectList != null && objectList.Count > 0)
      {

        foreach (ImageObject obj in objectList)
        {
          if (IsVehicle(obj))
          {
            if (obj.Confidence > minVehicleConfidence)
            {
              vehicles.Add(new ImageObject(obj));
            }
          }
          else
          {
            ++nonVehicleObjects;
          }
        }

        Dbg.Trace("non-vehicle objects before parking check: " + nonVehicleObjects.ToString());

        List<ImageObject> allFoundVehicles = new List<ImageObject>(vehicles);

        int i = 0;

        /*List<Frame> recentFrames = null;  
        if (vehicles.Count > 0)
        {
          recentFrames = camera.FrameHistory.GetFramesInTimespan(TimeSpan.FromSeconds(5), DateTime.Now, TimeDirection.Before);
        }*/

        while (i < vehicles.Count)
        {

          bool removedOne = false;

          lock (_previousVehicles)
          {

            for (int j = 0; j < _previousVehicles.Count; j++)
            {

              if (vehicles[i].Label == vehicles[j].Label)    // In this case we only remove  objects that are the same - A = car, B = car (not 100%, but what can we do?)
              {
                int targetOverlap = ParkedOverlap;

                bool foundParked = false;
                int overlap = AIAnalyzer.GetOverlap(vehicles[i], _previousVehicles[j]);
                if (overlap >= targetOverlap)   // Shadows, etc. do cause event parked vehicles to shift in outline
                {
                  Dbg.Trace("Vehicle found parked using area overlap");
                  foundParked = true;
                }
                else
                {
                  // Now we consider 2 points on both the parked and the subject vehicle.  If they are close we consider it parked.
                  // This is because people walking in front of a car may change the outlines.
                  // This is far from perfect, but it is worth trying.
                  // Note that this assumes only one edge of the vehicle is covered at a time, but for now is better than nothing.
                  // If the vehicle is still moving the next frame should tell via the overlap test so that is not a concern
                  // TODO: keep the parked vehicle locations in a db table?
                  // TODO: Parked vehicles that are covered by people/animals at both corners (we know where people are) will not be 
                  // removed from the parked list?  We probably don't care about vehicles covered by vehicles because the moving vehicles are
                  // movement in themselves, unless we care specifically what kind of vehicles we are concerned with.
                  Point pPreviousUL = new Point(_previousVehicles[j].ObjectRectangle.Left, _previousVehicles[j].ObjectRectangle.Top);
                  Point pPreviousLR = new Point(_previousVehicles[j].ObjectRectangle.Right, _previousVehicles[j].ObjectRectangle.Bottom);
                  Point pVehicleUL = new Point(vehicles[i].ObjectRectangle.Left, vehicles[i].ObjectRectangle.Top);
                  Point pVehicleLR = new Point(vehicles[i].ObjectRectangle.Right, vehicles[i].ObjectRectangle.Bottom);

                  double ulDistance = GetPointDistance(pPreviousUL, pVehicleUL);
                  double lrDistance = GetPointDistance(pPreviousLR, pVehicleLR);
                  double parkedSize = pVehicleLR.X - pVehicleUL.X;  // the width in pixels of the parked vehicle, to get a rough idea of its size
                  double targetSize = parkedTargetDistance * parkedSize;
                  if (targetSize > parkedTargetMax)
                  {
                    targetSize = parkedTargetMax; // just a WAG pending test data
                  }

                  if (ulDistance < targetSize || lrDistance < targetSize)
                  {
                    Dbg.Trace("Parked Target Size: " + targetSize.ToString());
                    Dbg.Trace("Parked ULDistance: " + ulDistance.ToString());
                    Dbg.Trace("Parked LRDistance: " + lrDistance.ToString());
                    Dbg.Trace("Vehicle found parked using corners");
                    foundParked = true;
                  }
                }

                if (foundParked)
                {
                  // OK, here we assume that they are the same object.
                  // TODO: In high frame rate situations this could be a problem.
                  // We add which ever has the highest confidence level to the result;

                  objectList.RemoveAll(obj => obj.ID == vehicles[i].ID);  // and remove it from the passed list
                  Dbg.Trace("Removing parked vehicle: " + vehicles[i].Label);
                  vehicles.RemoveAt(i);   // we are done with this vehicle
                  removedOne = true;
                  break;
                }
              }
            }

            if (removedOne)
            {
              i = 0; // Since we removed on we need to start over
            }
            else
            {
              i++;  // and on to the next
            }
          }

          // if we have any remaining vehicles add them to the list of previously seen ones
          _previousVehicles.Clear();
          _previousVehicles = new List<ImageObject>(allFoundVehicles);  // because ALL vehicles we found are now "previous"
        }
      }

      Dbg.Trace("Total objects after parked vehicle check: " + objectList.Count.ToString() + " Vehicles remaining: " + vehicles.Count.ToString());
    }

    public static double GetPointDistance(Point p1, Point p2)
    {
      double result;
      double dw = Math.Pow((p1.X - p2.X), 2);
      double dh = Math.Pow((p1.Y - p2.Y), 2);
      result = Math.Sqrt(dw + dh);
      return result;
    }




    static bool IsVehicle(ImageObject obj)
    {
      bool isVehicle;
      switch (obj.Label)
      {
        case "car":
          isVehicle = true;
          break;

        case "truck":
          isVehicle = true;
          break;

        case "bus":
          isVehicle = true;
          break;

        case "motorbike":
          isVehicle = true;
          break;

        default:
          isVehicle = false;
          break;

      }
      return isVehicle;

    }


    /*
     * rect.Intersect(secondRectangle);
  var percentage = (rect.Width * rect.Height) * 100f/(firstRect.Width * firstRect.Height);*/

    public static int GetOverlap(ImageObject obj1, ImageObject obj2)
    {
      int overlap;
      Rectangle intersect = Rectangle.Intersect(obj1.ObjectRectangle, obj2.ObjectRectangle); ;

      var percentage = (((intersect.Width * intersect.Height) * 2) * 100f) / ((obj2.ObjectRectangle.Width * obj2.ObjectRectangle.Height) + (obj2.ObjectRectangle.Width * obj1.ObjectRectangle.Height));
      overlap = (int)percentage;

      return overlap;
    }

  }

  public class AIResult
  {
    public PendingItem Item { get; set; }
    public List<ImageObject> ObjectsFound { get; set; }
  }

  public class Frame
  {
    public DateTime Timestamp { get; }
    public PendingItem Item { get; set; }
    public List<InterestingObject> Interesting { get; set; }

    public Frame(PendingItem item, List<InterestingObject> interesting)
    {
      Timestamp = item.TimeEnqueued;  // handy to have it
      Item = item;
      Interesting = interesting;
    }

    public Frame(Frame src)
    {
      Debug.Assert(src != null);
      if (src != null)
      {
        Timestamp = src.Timestamp;
        Item = src.Item;
        Interesting = src.Interesting;
      }
    }
  }

  [Serializable]
  public class AiNotFoundException : Exception
  {
    public AiNotFoundException(string url) : base("The AI Detection process was not found at: " + url + ".  Ensure that the AI program is running that this location.")
    {
    }

    public AiNotFoundException() : base() { }

    public AiNotFoundException(string message, System.Exception inner) : base(message, inner) { }

    protected AiNotFoundException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }

  }
}
