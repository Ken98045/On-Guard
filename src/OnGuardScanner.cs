using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;
using System.IO;
using System.Drawing;

namespace OnGuardCore
{
  public delegate void BitmapHandler(Bitmap bitmap);
  public delegate void TimeSpanHandler(TimeSpan span);
  public class OnGuardScanner : IDisposable
  {
    private bool disposedValue;
    ManualResetEvent _stopEvent = new (false);
    CameraData _camera;
    AIAnalyzer _analyzer;
    int sequence = 0;
    readonly MostRecentCollection _recentTimes = new (20);

    public event BitmapHandler OnCameraBitmap = delegate { };
    public event TimeSpanHandler OnAITime = delegate { };

    public OnGuardScanner(CameraData camera)
    {
      Dbg.Write("OnGuardScanner - Constructor");
      _camera = camera;
      _analyzer = new AIAnalyzer();
      Task.Run(() => ScanCamera());
    }

    async Task ScanCamera()
    {
      CameraContactData data = _camera.Contact;  // for clarity
      string urlString = data.ReplaceParmeters(data.JPGSnapshotURL);
      string imageName = "OnGuardScanner-" + _camera.CameraPrefix;
      TimeSpan lastElapsed = TimeSpan.FromSeconds(0);

      int originalWaitTime = (int)((double)_camera.OnGuardScanIterval * 1000);
      int modifiedWaitTime = originalWaitTime;
      int maxWaitTime = originalWaitTime * 5;

      while (!_stopEvent.WaitOne(modifiedWaitTime))
      {
        try
        {
          DateTime start = DateTime.Now;

          HttpWebRequest webRequest = (HttpWebRequest)HttpWebRequest.Create(urlString);
          webRequest.KeepAlive = true;

          if (_camera.Contact.JpgContactMethod != PTZMethod.BlueIris)
          {
            webRequest.Credentials = new System.Net.NetworkCredential(data.CameraUserName, data.CameraPassword);
          }

          webRequest.AllowWriteStreamBuffering = true;
          webRequest.Timeout = 10000;

          using WebResponse webResponse = await webRequest.GetResponseAsync().ConfigureAwait(true);
          using var stream = webResponse.GetResponseStream();
          using MemoryStream memStream = new ();
          await stream.CopyToAsync(memStream);
          TimeSpan pictureTime = DateTime.Now - start;

          using Bitmap bitmap = new(memStream);

          if (null == bitmap)
          {
            Dbg.Write("OnGuardStreamer - There was an error obtaining the snapshot/video.  Please check your Live Camera settings");
            break;
          }


          BitmapAvailable(bitmap);

          DateTime startAI  = DateTime.Now;

          await CheckForObjectsAsync(bitmap).ConfigureAwait(false);
          TimeSpan aiTime = DateTime.Now - startAI;
          lastElapsed = DateTime.Now - start;

          // Check to see if we need to adjust the wait time between passes
          _recentTimes.AddValue(lastElapsed.TotalMilliseconds);

          if (_recentTimes.Count == _recentTimes.MaxItems)
          {
            // we don't start adjusting unless we have some history to go by

            double avg = (int)_recentTimes.Avg();

            int previousWaitTime = modifiedWaitTime;
            // make some WAG regarding appropriate adjustments
            if (avg > 1.5 * modifiedWaitTime)
            {
              modifiedWaitTime = (int)(1.25 * modifiedWaitTime);
            }
            else if (avg < 0.75 * modifiedWaitTime)
            {
              modifiedWaitTime = (int)(0.6 * modifiedWaitTime);
            }

            if (modifiedWaitTime < originalWaitTime)
            {
              modifiedWaitTime = originalWaitTime;
            }
            else if (modifiedWaitTime > maxWaitTime)
            {
              modifiedWaitTime = maxWaitTime;
            }

            if (modifiedWaitTime != previousWaitTime)
            {
              Dbg.Trace("OnGuardScanner - Modified wait time to: " + modifiedWaitTime.ToString());
            }
          }
        }
        catch (Exception ex)
        {
          Dbg.Write("OnGuardScanner - ScanCamera: " + ex.Message);
        }
      }
    }

    private async Task CheckForObjectsAsync(Bitmap bitmap)
    {

      try
      {
        PendingItem pendingItem = new (_camera, "ScannedImage" + DateTime.Now.Ticks.ToString());
        pendingItem.TimeDispatched = DateTime.Now;
        pendingItem.TimeEnqueued = pendingItem.TimeDispatched;

        List<InterestingObject> objectsFound = await AIDetection.AIFindObjectsAsync(bitmap, "ScannedImage").ConfigureAwait(true);  // throws if ai not available
        pendingItem.TimeCompleted = DateTime.Now;
        AITimeUpdater.UpdateFrameTime(pendingItem.TimeCompleted - pendingItem.TimeDispatched);

        if (null != objectsFound)
        {

          Dbg.Trace("OnGuardScanner - CheckForObjects - Objects found: " + objectsFound.Count.ToString());
          AIResult result = new ();
          result.Item = pendingItem;
          result.ObjectsFound = objectsFound;

          if (null != result.ObjectsFound && result.ObjectsFound.Count > 0)  // Did we find any objects the AI could recognize?
          {
            List<InterestingObject> interesting = null;
            // Analyze the frame with respect to the areas of interest for this camera only.

            if (null != pendingItem.CamData)
            {
              _analyzer.RemoveInvalidObjects(pendingItem.CamData, result.ObjectsFound);  // This may remove items from the list, and may zero it out

              if (result.ObjectsFound.Count > 0)
              {

                if (!_camera.StorePicturesInAreaOnly)
                {
                  // Write the bitmap if this is the kind of object the user cares about.  Might not be in an area we care about (anyplace in the picture)
                  Dbg.Write("OnGuardScanner-CheckForObjectsAsync-About to write bitmap (1) - Object count: " + result.ObjectsFound.Count.ToString());
                  WriteBitmapToFile(bitmap);
                }

                FrameAnalyzer frameAnalyzer = new (pendingItem.CamData.AOI, result.ObjectsFound, bitmap.Width, bitmap.Height);
                AnalysisResult analysisResult = await frameAnalyzer.AnalyzeFrameAsync(pendingItem.PictureImage);  // find if the objects we did find are interesting (relatively fast)
                interesting = analysisResult.InterestingObjects;

                if (_camera.StorePicturesInAreaOnly && interesting.Count > 0)
                {
                  // In this case we only write a bitmap if it has objects in an AOI
                  Dbg.Write("OnGuardScanner-CheckForObjectsAsync-About to write bitmap (2) - Object count: " + interesting.Count.ToString());
                  WriteBitmapToFile(bitmap);
                }

                // and here (in interesting) we have objects we care about
              }
            }
          }
        }
      }
      catch (AggregateException ex)
      {
        Dbg.Write("OnGuardScanner - An AI Died Or Was Not Found - Remaining: " + AI.AICount.ToString());
      }
      catch (AiNotFoundException)
      {
        Dbg.Write("OnGuardScanner - The AI Died Or Was Not Found");
      }

    }

    // Up until now everything has been in memory.  Now we need to write the bitmap to a file
    // TODO: MAYBE this is a non-monitored file name since we have already analyzed the bitmap (don't do it twice)
    // BUT we haven't done other things the normal process does.
    private void WriteBitmapToFile(Bitmap bitmap)
    {
      string path = _camera.CameraPath;
      DateTime now = DateTime.Now;
      path = Path.Combine(path, _camera.CameraPrefix.ToLower());
      Interlocked.Increment(ref sequence);
      string unique = string.Format("_{0}{1:00}{2:00}{3:00}{4:00}{5:00}{6:0000000}.jpg",
          now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second, sequence);
      path += unique;

      Dbg.Write("OnGuardScanner - WriteBitmapToFile - " + path);

      bitmap.Save(path);

    }

    private void BitmapAvailable(Bitmap bitmap)
    {
      OnCameraBitmap(new Bitmap(bitmap));
    }

    protected virtual void Dispose(bool disposing)
    {
      if (!disposedValue)
      {
        if (disposing)
        {
          Dbg.Write("OnGuardScanner - Dispose");
          _stopEvent.Set();
        }

        disposedValue = true;
      }
    }

    public void Dispose()
    {
      // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
      Dispose(disposing: true);
      GC.SuppressFinalize(this);
    }
  }
}
