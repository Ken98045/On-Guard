using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Drawing;
using System.Drawing.Imaging;

namespace OnGuardCore
{

  public class Face
  {

    public string userid { get; set; }
    public float confidence { get; set; }
    public int y_min { get; set; }
    public int x_min { get; set; }
    public int y_max { get; set; }
    public int x_max { get; set; }
  }

  class FaceResponse
  {
    public bool success { get; set; }
    public Face[] predictions { get; set; }
  }


  public class FaceDetection
  {

    public static async Task RegisterAllFacesAsync()
    {
      // return;

      List<string> existing = await GetAllFacesAsync();
      await DeleteFacesAsync(existing);

      string path = Storage.GetFilePath(string.Empty);
      path = Path.Combine(path, "Faces");
      if (!Directory.Exists(path))
      {
        Directory.CreateDirectory(path);
      }

      string[] people = Directory.GetDirectories(path);

      foreach (string person in people)
      {
        string subDir = person[(path.Length + 1)..];
        await RegisterFaceAsync(subDir);
      }

    }

    // A person can have multiple pictures.  
    // When adding a picture of a face we need to re-build all pictures for the person since they all must be loaded at once
    public static async Task<bool> RegisterFaceAsync(string person)
    {
      bool success = false;

      // registerFace("User Name ","userimage-path").Wait();
      string path = Storage.GetFilePath(string.Empty);
      path = Path.Combine(path, @"Faces\" + person);
      if (Directory.Exists(path))
      {

        string[] pictures = Directory.GetFiles(path);

        using HttpClient client = new ();
        using MultipartFormDataContent request = new ();
        request.Add(new StringContent(person), "userid");

        // Add each picture for the user
        for (int i = 0; i < pictures.Length; ++i)
        {
          var image_data = File.OpenRead(pictures[i]);
          request.Add(new StreamContent(image_data), "image" + i.ToString(), Path.GetFileName(pictures[i]));
        }

        HttpResponseMessage output = await AI.PostAIRequestAsync(client, "v1/vision/face/register", request).ConfigureAwait(true);
        success = output.IsSuccessStatusCode;
      }

      return success;
    }

    public static async Task RecognizeFaceAsync(string imagePath)
    {
      bool success = false;

      // recognizeFace("test-image2.jpg").Wait();
      using MultipartFormDataContent request = new ();
      var image_data = File.OpenRead(imagePath);
      request.Add(new StreamContent(image_data), "image", Path.GetFileName(imagePath));

      using HttpClient client = new ();
      var output = await AI.PostAIRequestAsync(client, "v1/vision/face/recognize", request);

      success = true;
      var jsonString = await output.Content.ReadAsStringAsync();
      JsonSerializerOptions opt = new ();
      opt.PropertyNameCaseInsensitive = true;

      FaceResponse response = (FaceResponse)JsonSerializer.Deserialize(jsonString, typeof(FaceResponse), opt);


      foreach (var user in response.predictions)
      {
        Console.WriteLine(user.userid);
      }
    }

    public static async Task<InterestingObject> LookForFaceAsync(Bitmap bitmap, InterestingObject person, bool doAsync)
    {
      InterestingObject face = null;
      bool success = false;
      PixelFormat format = bitmap.PixelFormat;
      using (Bitmap personBitmap = bitmap.Clone(person.ObjectRectangle, format))
      {
        using HttpClient client = new ();
        using var request = new MultipartFormDataContent();
        using Stream memStream = new MemoryStream();
        personBitmap.Save(memStream, ImageFormat.Jpeg);
        memStream.Position = 0;
        request.Add(new StreamContent(memStream), "image", "test");
        HttpResponseMessage output;

        if (doAsync)
        {
          output = await AI.PostAIRequestAsync(client, "v1/vision/face/recognize", request);
        }
        else
        {
          output = await AI.PostAIRequestAsync(client, "v1/vision/face/recognize", request);

          if (output.IsSuccessStatusCode)
          {
            JsonSerializerOptions opt = new ();
            opt.PropertyNameCaseInsensitive = true;

            var jsonString = await output.Content.ReadAsStringAsync();

            FaceResponse response = null;
            response = (FaceResponse)JsonSerializer.Deserialize(jsonString, typeof(FaceResponse), opt);
            if (response.success && response.predictions.Length > 0)
            {
              face = new InterestingObject();

              foreach (var result in response.predictions)
              {
                face.Confidence = result.confidence;
                face.Label = result.userid;
                face.ObjectRectangle = Rectangle.FromLTRB(result.x_min + person.ObjectRectangle.X,
                  result.y_min + person.ObjectRectangle.Y,
                  result.x_max + person.ObjectRectangle.X,
                  result.y_max + person.ObjectRectangle.Y);

                face.ID = Guid.NewGuid();
                face.IsFace = true;
                if (face.Label == "unknown")
                {
                  face.Confidence = 0.50001; // arbitrary to allow "unknown" faces through rather than dropping them
                }

              }

              success = true;
            }
          }
        }
      }
      return face;
    }

    public static async Task<List<string>> GetAllFacesAsync()
    {
      List<string> faces = new ();

      using (HttpClient client = new ())
      {
        var output = await AI.PostAIRequestAsync(client, "v1/vision/face/list", null);

        if (output.IsSuccessStatusCode)
        {
          var jsonString = await output.Content.ReadAsStringAsync();

          JsonSerializerOptions opt = new ();
          opt.PropertyNameCaseInsensitive = true;

          GetFacesResponse response = null;
          response = (GetFacesResponse)JsonSerializer.Deserialize(jsonString, typeof(GetFacesResponse), opt);
          if (response.success)
          {
            foreach (var face in response.Faces)
            {
              faces.Add(face);
            }
          }
        }
      }

      return faces;
    }

    public static async Task DeleteFacesAsync(List<string> faces)
    {
      foreach (string face in faces)
      {
        using HttpClient client = new();
        using var request = new MultipartFormDataContent();
        request.Add(new StringContent(face), "userid");
        var output = await AI.PostAIRequestAsync(client, "v1/vision/face/delete", request).ConfigureAwait(true);
        var jsonString = await output.Content.ReadAsStringAsync();
      }
    }
  }

  public class GetFacesResponse
  {
    public bool success { get; set; }
    public string[] Faces { get; set; }
  }
}
