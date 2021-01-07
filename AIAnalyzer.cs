using SAAI.Properties;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace SAAI
{


  class Response
  {

    public bool Success { get; set; }
    public ImageObject[] Predictions { get; set; }

  }

  public class ImageObject
  {
    public ImageObject()
    {

      Label = "none";

      // Some unnecessary initializations, but...
      Success = false;
      InMotion = false;
      Confidence = 0.0;
      X_min = 0;
      Y_min = 0;
      X_max = 0;
      Y_max = 0;
    }

    public bool Success { get; set; }
    public string Label { get; set; }
    public double Confidence { get; set; }
    public int Y_min { get; set; }
    public int X_min { get; set; }
    public int Y_max { get; set; }
    public int X_max { get; set; }
    public Rectangle ObjectRectangle { get; set; }
    public bool InMotion { get; set; }
    public Guid ID { get; set; }

    public ImageObject(ImageObject src)
    {
      Label = src.Label;
      Success = src.Success;
      Confidence = src.Confidence;
      Y_max = src.Y_max;
      Y_min = src.Y_min;
      X_max = src.X_max;
      X_min = src.Y_min;
      ObjectRectangle = src.ObjectRectangle;
      InMotion = src.InMotion;
      ID = src.ID;
    }


  }


  /// <summary>
  /// AIAnalyzer is the class that contacts the AI to analyze the picture.
  /// 
  /// /// </summary>
  class AIAnalyzer
  {
    List<ImageObject> _previousVehicles = new List<ImageObject>();  // The often don't move (parked)
    readonly List<ImageObject> _previousPeople = new List<ImageObject>();  // The usually do move, but
    readonly private object _fileLock = new object();

    readonly string _AILocation;
    readonly int _AIPort;
    const int MultiDefinitionOverlap = 92;
    const int ParkedOverlap = 95;
    const double minVehicleConfidence = 0.40;


    public AIAnalyzer()
    {
      _AILocation = Settings.Default.AIIPAddress;
      _AIPort = Settings.Default.AIPort;
    }

    public AIAnalyzer(string aiAddress, int port)
    {
      _AILocation = aiAddress;
      _AIPort = port;
    }


    public List<string> Init(string cameraNamePrefix, string cameraFilePath)
    {
      List<string> fileNames = new List<string>();

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
          fileNames.Add(fileName);
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



    public void RemoveInvalidObjects(List<ImageObject> images)
    {

      if (images != null)
      {

        //First, weed out any vehicles that are overlapps within this picture
        // This often happens when the same vehicles is identified as both a car and a truck (SUV, pickup, cars/trucks at an angle)
        RemoveDuplicateVehiclesInImage(images);
        RemoveUnmovedVehicles(images);  // Now, remove vehicles that haven't moved
      }

    }



    // This returns a list of vehicles that are unique to this frame.  
    // However, it has an intended side effect: If 2 separate vehicles share the same space but are classified differently (car/truck/etc.)
    // then we ARTIFICIALLY boost the confidence level of the one we select. 
    // For instance the same object (almost the same outline) may be .50 confident of being a car and 65% confident of being a truck.
    // The AI isn't sure which it is but it is pretty damn sure it IS a vehicle of some sort.  
    // I really dislike doing this, but with the way the AI is now it is better to cheat an be accurate than not cheat and give a misleading result;
    public static void RemoveDuplicateVehiclesInImage(List<ImageObject> objectList)
    {
      Dbg.Trace("Objects before removing duplicate vehicles: " + objectList.Count.ToString());

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

        Dbg.Trace("Non-vehicle Objects before duplicate check: " + nonVehicleObjects.ToString());

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


    void RemoveUnmovedVehicles(List<ImageObject> objectList)
    {
      Dbg.Trace("Object count before removing parked: " + objectList.Count.ToString());

      List<ImageObject> vehicles = new List<ImageObject>();
      int nonVehicleObjects = 0;

      // Yes, once again we get a list of vehicles
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
                if (AnimalOverlapsVehicleEdge(vehicles[i], objectList) || AnimalOverlapsVehicleEdge(_previousVehicles[j], objectList))
                {
                  targetOverlap = 85; // this throws off the object outline
                }

                bool foundParked = false;
                int overlap = GetOverlap(vehicles[i], _previousVehicles[j]);
                if (overlap >= targetOverlap)   // Shadows, etc. do cause event parked vehicles to shift in outline
                {
                  Dbg.Trace("Vehicle found parked using area overlap");
                  foundParked = true;
                }
                else
                {
                  // Now we consider 2 points on both the parked and the subject vehicle.  If they match we consider it parked.
                  // This is because people walking in front of a car may change the outlines.  (well, cars, etc could too, but...)
                  // This is far from perfect, but it is worth trying.
                  Point pPreviousUL = new Point(_previousVehicles[j].ObjectRectangle.Left, _previousVehicles[j].ObjectRectangle.Top);
                  Point pPreviousLR = new Point(_previousVehicles[j].ObjectRectangle.Right, _previousVehicles[j].ObjectRectangle.Bottom);
                  Point pVehicleUL = new Point(vehicles[i].ObjectRectangle.Left, vehicles[i].ObjectRectangle.Top);
                  Point pVehicleLR = new Point(vehicles[i].ObjectRectangle.Right, vehicles[i].ObjectRectangle.Bottom);

                  double ulDistance = GetPointDistance(pPreviousUL, pVehicleUL);
                  double lrDistance = GetPointDistance(pPreviousLR, pVehicleLR);
                  double parkedSize = pVehicleUL.X - pVehicleLR.X;  // the width in pixels of the parked vehicle, to get a rough idea of its size
                  double targetSize = .05 * parkedSize;

                  if (ulDistance < targetSize || lrDistance > targetSize)
                  {
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

    double GetPointDistance(Point p1, Point p2)
    {
    double result = 0.0;
    double dw = Math.Pow((p1.X - p2.X), 2);
    double dh = Math.Pow((p1.Y - p2.Y), 2);
    result = Math.Sqrt(dw + dh);
      return result;
  }

    // As people (or other animals) walk in front of a car it can change the outline of the car
    // However, if the car is close enough to be recognized as a car, it would be somewhat rare for one person/animal
    // to change both the left and right edges of the car.  This can easily happen with multiple people,
    // and rarely may happen with one person.  While the outline of the car can be changed enough that
    // it is no longer recognized as a car, not much we can do about that.  
    // So, here we do the best we can
    bool AnimalOverlapsVehicleEdge(ImageObject vehicle, List<ImageObject> foundObjects)
    {
      bool result = false;
      // For now we just return false since thi feature is still bing worked on!
      return result;
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


    // TODO:
    bool IsThereMotion()
    {
      bool isMotion = false;
      return isMotion;

    }



    /*
     * 
     *      using (HttpClient client = new HttpClient())
      {

        var request = new MultipartFormDataContent();
        var image_data = File.OpenRead(image_path);
        request.Add(new StreamContent(image_data), "image", Path.GetFileName(image_path));
        var output = 

     * 
     */

    public async Task<List<ImageObject>> ProcessVideoImageViaAI(Stream stream, string imageName)
    {
      List<ImageObject> objectList;

      try
      {
        objectList = await DetectObjects(stream, imageName).ConfigureAwait(true);
      }
      catch (AiNotFoundException ex)
      {
        throw ex;
      }

      return objectList;

    }

    // This function is used by the UI to detect objects.  It is not currently
    // used async, but may be in the future
    public async Task<List<ImageObject>> DetectObjects(Stream stream, string imageName)
    {
      List<ImageObject> objects = null;

      using (HttpClient client = new HttpClient())
      {

        using (StreamContent content = new StreamContent(stream))
        {
          using (var request = new MultipartFormDataContent
        {
          { content, "image", imageName }
        })
          {
            string url = string.Format("http://{0}:{1}/v1/vision/detection", _AILocation, _AIPort);

            HttpResponseMessage output = null;
            try
            {
              output = /*await*/ client.PostAsync(new Uri(url), request).Result;
            }
            catch (AggregateException ex)
            {
              throw new AiNotFoundException(url);
            }
            catch (Exception ex)
            {
              throw new AiNotFoundException(url);
            }

            if (!output.IsSuccessStatusCode)
            {
              throw new AiNotFoundException(url);
            }

            var jsonString = /*await*/ output.Content.ReadAsStringAsync().Result;
            Response response = JsonConvert.DeserializeObject<Response>(jsonString);

            if (response.Predictions != null && response.Predictions.Length > 0)
            {

              foreach (var result in response.Predictions)
              {
                if (objects == null)
                {
                  objects = new List<ImageObject>();
                }

                result.Success = true;

                // Windows likes Rectangles, so it is easier to create one now
                result.ObjectRectangle = Rectangle.FromLTRB(result.X_min, result.Y_min, result.X_max, result.Y_max);
                result.ID = Guid.NewGuid(); // Keep an ID around for the life of the object

                objects.Add(result);

              }
            }
          }
        }
      }
      return objects;
    }

    // This function is used by the (semi) live data, not the UI
    public async Task<AIResult> DetectObjectsAsync(Stream stream, PendingItem pending)
    {
      List<ImageObject> objects = null;
      AIResult aiResult = new AIResult
      {
        ObjectsFound = objects,
        Item = pending
      };


      using (HttpClient client = new HttpClient())
      {

        using (StreamContent content = new StreamContent(stream))
        {

          using (var request = new MultipartFormDataContent
        {
          { content, "image", pending.PendingFile }
        })
          {
            string url = string.Format("http://{0}:{1}/v1/vision/detection", _AILocation, _AIPort);

            HttpResponseMessage output = null;
            try
            {
              DateTime startPost = DateTime.Now;
              pending.TimeDispatched = startPost;

              output = await client.PostAsync(new Uri(url), request).ConfigureAwait(false);
              pending.TimeProcessingByAI();
              TimeSpan postTime = DateTime.Now - startPost;
            }
            catch (AggregateException ex)
            {
              throw new AiNotFoundException(url);
            }
            catch (Exception ex)
            {
              throw new AiNotFoundException(url);
            }

            if (!output.IsSuccessStatusCode)
            {
              throw new AiNotFoundException(url);
            }

            var jsonString = await output.Content.ReadAsStringAsync().ConfigureAwait(false);
            TimeSpan processTime = pending.TimeProcessingByAI();
            // Console.WriteLine("Process Time: " + processTime.TotalMilliseconds.ToString());
            Response response = JsonConvert.DeserializeObject<Response>(jsonString);

            if (response.Predictions != null && response.Predictions.Length > 0)
            {

              foreach (var result in response.Predictions)
              {
                if (objects == null)
                {
                  objects = new List<ImageObject>();
                }

                result.Success = true;

                // Windows likes Rectangles, so it is easier to create one now
                result.ObjectRectangle = Rectangle.FromLTRB(result.X_min, result.Y_min, result.X_max, result.Y_max);
                result.ID = Guid.NewGuid();

                objects.Add(result);

                string o = string.Format("{0}\t{1}\t{2}\t{3}\t{4}\t{5}", result.Label, result.Confidence, result.X_min, result.Y_min, result.X_max, result.Y_max);
                Dbg.Trace(o);
              }
            }
            // DebugWriter.Write(jsonString);
          }
        }
      }

      aiResult.ObjectsFound = objects;
      return aiResult;
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

    static int GetOverlap(ImageObject obj1, ImageObject obj2)
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
      Timestamp = src.Timestamp;
      Item = src.Item;
      Interesting = src.Interesting;
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
