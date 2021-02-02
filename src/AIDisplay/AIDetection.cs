using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Drawing;


namespace SAAI
{
  public class AIDetection
  {
    // This is called by the UI connection test function directly.  It uses an AI not in the list
    public static async Task<List<ImageObject>> ProcessTestImage(AILocation ai, Stream stream, string imageName)
    {
      List<ImageObject> objectList;

      try
      {
        objectList = AIFindObjects(ai, stream, imageName, false).Result;
      }
      catch (AiNotFoundException ex)
      {
        throw ex;
      }

      return objectList;
    }

    // Called by the AI to navigate through the working set UI
    public static async Task<List<ImageObject>> AIProcessFromUI(Stream stream, string imageName)
    {
      List<ImageObject> result = null;
      AILocation ai = null;

      do
      {
        try
        {
          ai = await AILocation.GetAI().ConfigureAwait(false);
        }
        catch (AggregateException ex)
        {
          // The list is empty
          throw ex.InnerException;  // which is an AINotFound exception
        }
        catch (AiNotFoundException ex)
        {
          // the list is empty
          throw;
        }

        try
        {
          result = AIFindObjects(ai, stream, imageName, false).Result;

          await AILocation.ReturnToList(ai).ConfigureAwait(false);

        }
        catch (AggregateException ex)
        {
          AILocation.AICount--;
          ai = null;
        }
        catch (AiNotFoundException)
        {
          AILocation.AICount--;
          ai = null;
        }

      } while (ai == null);

      return result;
    }


    // Main processing of objects through the AI
    public async static Task<List<ImageObject>> AIFindObjects(AILocation aiLocation, Stream stream, string imageName, bool doAsync)
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
            string url = string.Format("http://{0}:{1}/v1/vision/detection", aiLocation.IPAddress, aiLocation.Port);

            HttpResponseMessage output = null;
            try
            {
              if (doAsync)
              {
                output = await client.PostAsync(new Uri(url), request).ConfigureAwait(false);
              }
              else
              {
                output = client.PostAsync(new Uri(url), request).Result;
              }
            }
            catch (HttpRequestException)
            {
              throw new AiNotFoundException(url);
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
            output.Dispose();

            JsonSerializerOptions opt = new JsonSerializerOptions();
            opt.PropertyNameCaseInsensitive = true;

            Response response = (Response)JsonSerializer.Deserialize(jsonString, typeof(Response), opt);

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
    public static async Task<AIResult> DetectObjectsAsync(Stream stream, PendingItem pending)
    {
      List<ImageObject> objectsFound = null;
      AILocation ai = null;
      AIResult aiResult = null;

      do
      {
        // Get an available AI. If there are none it throws
        try
        {
          ai = await AILocation.GetAI().ConfigureAwait(false);
        }
        catch (AggregateException ex)
        {
          throw ex;
        }
        catch (AiNotFoundException)
        {
          throw;
        }

        // Do the AI Detection (async)
        try
        {
          pending.TimeDispatched = DateTime.Now;
          objectsFound = await AIFindObjects(ai, stream, pending.PendingFile, true).ConfigureAwait(false);

          aiResult = new AIResult();
          aiResult.ObjectsFound = objectsFound;
          aiResult.Item = pending;
          aiResult.Item.TimeProcessingByAI();
          await AILocation.ReturnToList(ai).ConfigureAwait(false);  // put it back for re-use

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
          AILocation.AICount--;
          ai = null;
        }
        catch (AiNotFoundException)
        {
          AILocation.AICount--;
          ai = null;
        }

      } while (ai == null);

      return aiResult;
    }
  }
}
