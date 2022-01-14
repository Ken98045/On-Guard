using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Drawing;
using System.Drawing.Imaging;

namespace OnGuardCore
{
  public class AIDetection
  {
    // This is called by the UI connection test function directly.  It uses an AI not in the list
    public static async Task<bool> ProcessTestImageAsync(string ipAddress, int port, Bitmap pictureImage, string imageName)
    {
      bool result = false;

      string url = string.Format("http://{0}:{1}/v1/vision/detection", ipAddress, port);

      using (var request = new MultipartFormDataContent())
      {
        using MemoryStream memStream = new ();
        pictureImage.Save(memStream, ImageFormat.Jpeg);
        memStream.Position = 0;
        request.Add(new StreamContent(memStream), "image", "test");

        using HttpClient client = new();

        try
        {
          HttpResponseMessage output = await client.PostAsync(url, request).ConfigureAwait(true);
          if (output.IsSuccessStatusCode)
          {
            var jsonString = await output.Content.ReadAsStringAsync().ConfigureAwait(true);
            output.Dispose();

            JsonSerializerOptions opt = new();
            opt.PropertyNameCaseInsensitive = true;

            Response response = null;

            try
            {
              response = (Response)JsonSerializer.Deserialize(jsonString, typeof(Response), opt);
            }
            catch (Exception)
            {

            }

            if (response.Predictions != null && response.Predictions.Length > 0)
            {
              result = true;
            }
          }
        }
        catch (Exception ex)
        {
          Dbg.Write("AIDetection - ProcessTestImage - The AI could not be found - exception: " + ex.Message);
        }
      }

      return result;
    }

    // Called by the AI to navigate through the working set UI
    public static async Task<List<InterestingObject>> AIProcessFromUIAsync(Bitmap pictureImage, string pictureName)
    {
      List<InterestingObject> result = null;

      try
      {
        result = await AIFindObjectsAsync(pictureImage, pictureName).ConfigureAwait(true);
      }
      catch (HttpRequestException)
      {
        Dbg.Write("The AI Died Or Was Not Found ");
      }
      catch (AggregateException ex)
      {
        Dbg.Write("The AI Died Or Was Not Found");
      }
      catch (AiNotFoundException)
      {
        Dbg.Write("The AI Died Or Was Not Found");
        throw;
      }
      catch (Exception ex)
      {
        Dbg.Write("The AI Died Or Was Not Found");
      }
      return result;
    }

    // This function is used by the (semi) live data, not the UI
    public static async Task<AIResult> DetectObjectsAsync(PendingItem pending)
    {
      List<InterestingObject> objectsFound = null;
      AIResult aiResult = null;

      Dbg.Trace("AIDetection - DetectObjectsAsync starting analysis of: " + pending.PendingFile);

      try
      {
        pending.TimeToDispatch();
        objectsFound = await AIFindObjectsAsync(pending.PictureImage, pending.PendingFile).ConfigureAwait(true);  // throws if ai not available
        pending.SetTimeProcessingByAI();
        string dbg = "AIDetection - DetectObjectsAsync ending analysis of : " + pending.PendingFile + " Time: " + pending.TotalProcessingTime().TotalSeconds.ToString();
        if (null != objectsFound)
        {
          dbg += " with: " + objectsFound.Count.ToString() + " objects";
        }
        Dbg.Trace(dbg);

        aiResult = new ();
        aiResult.ObjectsFound = objectsFound;
        aiResult.Item = pending;

        if (aiResult.ObjectsFound != null)
        {
          foreach (var result in aiResult.ObjectsFound)
          {
            string o = string.Format("{0}\t{1}\t{2}\t{3}\t{4}\t{5}", result.Label, result.Confidence, result.X_min, result.Y_min, result.X_max, result.Y_max);
            Dbg.Trace(o);
          }
        }
      }
      catch (AggregateException ex)
      {
        Dbg.Write("An AI Died Or Was Not Found - Remaining: " + AI.AICount.ToString());
      }
      catch (AiNotFoundException ex)
      {
        Dbg.Write("The AI Died Or Was Not Found: " + ex.Message);
        throw;
      }

      return aiResult;
    }


    // Main processing of objects through the AI
    public async static Task<List<InterestingObject>> AIFindObjectsAsync(Bitmap pictureImage, string imageName)
    {
      List<InterestingObject> objects = null;

      using (MemoryStream stream = new())  // we have a bitmap, but we need a stream for the analysis
      {
        pictureImage.Save(stream, ImageFormat.Jpeg);
        stream.Position = 0;


        using HttpClient client = new();
        client.Timeout = TimeSpan.FromSeconds(90);

        using StreamContent content = new(stream);
        using var request = new MultipartFormDataContent { { content, "image", imageName } };
        HttpResponseMessage output = await AI.PostAIRequestAsync(client, "v1/vision/detection", request); // may throw!

        var jsonString = await output.Content.ReadAsStringAsync();
        output.Dispose();

        JsonSerializerOptions opt = new();
        opt.PropertyNameCaseInsensitive = true;

        Response response = null;

        try
        {
          response = (Response)JsonSerializer.Deserialize(jsonString, typeof(Response), opt);
        }
        catch (Exception ex)
        {

        }

        if (response.Predictions != null && response.Predictions.Length > 0)
        {

          foreach (var result in response.Predictions)
          {
            if (objects == null)
            {
              objects = new List<InterestingObject>();
            }

            result.Success = true;

            // Windows likes Rectangles, so it is easier to create one now
            result.ObjectRectangle = Rectangle.FromLTRB(result.X_min, result.Y_min, result.X_max, result.Y_max);
            result.ID = Guid.NewGuid(); // Keep an ID around for the life of the object
            objects.Add(result);

          }
        }
      }

      return objects;

    }
  }

}