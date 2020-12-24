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

      List<ImageObject> intestingImages = new List<ImageObject>();

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
      List<ImageObject> vehicles = new List<ImageObject>();

      if (objectList != null && objectList.Count > 0)
      {

        foreach (ImageObject obj in objectList)
        {
          if (IsVehicle(obj))
          {
            if (obj.Confidence > 0.45)
            {
              vehicles.Add(obj);
            }
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

                if (overlap > 90)
                {
                  // OK, here we assume that they are the same object.
                  // We add which ever has the highest confidence level to the result;

                  if (vehicles[i].Confidence > vehicles[j].Confidence)
                  {
                    vehicles[i].Confidence = vehicles[i].Confidence + (vehicles[i].Confidence - vehicles[j].Confidence) / 2.0;
                    if (vehicles[i].Confidence >= 1.0)
                    {
                      vehicles[i].Confidence = 0.9999999;
                    }
                    objectList.RemoveAll(obj => obj.ID == vehicles[j].ID);  // and remove it from the passed list
                    vehicles.RemoveAt(j);
                    removedOne = true;
                    break;
                  }
                  else
                  {
                    vehicles[j].Confidence = vehicles[j].Confidence + (vehicles[j].Confidence - vehicles[i].Confidence) / 2.0;
                    if (vehicles[j].Confidence >= 1.0)
                    {
                      vehicles[j].Confidence = 0.9999999;
                    }

                    objectList.RemoveAll(obj => obj.ID == vehicles[i].ID);  // and remove it from the passed list
                    vehicles.RemoveAt(i);
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
    }


    void RemoveUnmovedVehicles(List<ImageObject> objectList)
    {
      List<ImageObject> vehicles = new List<ImageObject>();

      // Yes, once again we get a list of vehicles
      if (objectList != null && objectList.Count > 0)
      {

        foreach (ImageObject obj in objectList)
        {
          if (IsVehicle(obj))
          {
            if (obj.Confidence > 0.45)
            {
              vehicles.Add(obj);
            }
          }
        }

        List<ImageObject> allFoundVehicles = new List<ImageObject>(vehicles);


        int i = 0;

        while (i < vehicles.Count)
        {

          bool removedOne = false;

          for (int j = 0; j < _previousVehicles.Count; j++)
          {

            if (vehicles[i].Label == vehicles[j].Label)    // In this case we only remove  objects that are the same - A = car, B = car (not 100%, but what can we do?)
            {
              int overlap = GetOverlap(vehicles[i], _previousVehicles[j]);

              if (overlap > 90)
              {
                // OK, here we assume that they are the same object.
                // We add which ever has the highest confidence level to the result;

                objectList.RemoveAll(obj => obj.ID == vehicles[i].ID);  // and remove it from the passed list
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
        _previousVehicles = new List<ImageObject>(allFoundVehicles);  // because all vehicles we found are now "previous"

      }


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
              output = await client.PostAsync(new Uri(url), request).ConfigureAwait(false);
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

            DateTime beforeRead = DateTime.Now;
            var jsonString = await output.Content.ReadAsStringAsync().ConfigureAwait(false);
            TimeSpan readTime = DateTime.Now - beforeRead;
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
                // Dbg.Write(o);
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
