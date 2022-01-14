using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Data.SqlClient;

using System.Threading.Tasks;
using System.Drawing;
using System.Threading;

namespace OnGuardCore
{
  public class SyncToDB
  {
    static bool _stopSync;
    public static void StopSync()
    {
      _stopSync = true;
    }

    public static async Task PerformSyncDBAsync(CameraData currentCamera, double interval, bool currentDirection, string connectionString, ManualResetEvent stopEvent)
    {
      _stopSync = false;

      AIAnalyzer analyzer = new ();
      CameraData cam = new (currentCamera);
      SortedList<string, PictureInfo> fileList = analyzer.Init(cam.CameraPrefix, cam.CameraPath, cam.MonitorSubdirectories);
      List<string> syncFiles;

      if (currentDirection == false)
      {
        syncFiles = fileList.Keys.Reverse().ToList<string>();
      }
      else
      {
        syncFiles = fileList.Keys.ToList<string>();
      }

      double snapshotInterval = interval;

      using SqlConnection con = new (connectionString);
      try
      {
        await con.OpenAsync().ConfigureAwait(true);
      }
      catch (SqlException ex)
      {
        Dbg.Write("MainWindow -  PerformMotionSync - Sql Exception on opening database connection: " + ex.Message);
        return;
      }
      catch (InvalidOperationException ex)
      {
        Dbg.Write("MainWindow -  PerformMotionSync - InvalidOperation Exception on opening database connection: " + ex.Message);
        return;

      }

      Dbg.Write("Starting Sync to Motion Database");

      double lastAITime = (double)0.0;
      double multiplier = 2.0;

      try
      {
        foreach (string key in syncFiles)
        {
          if (_stopSync)
          {
            break;
          }

          PictureInfo pi = fileList[key];

          if (!stopEvent.WaitOne(0))
          {
            string fileName = pi.FileName;

            // First, delay if necessary.
            if (lastAITime > multiplier * snapshotInterval)
            {
              // Wait for a while to avoid overloading the AI
              if (stopEvent.WaitOne((int)(1000.0 * multiplier * snapshotInterval)))
              {
                break;
              }

              // and bump the multiplier for the delay, but don't let it get TOO large
              multiplier *= 1.2;
              if (multiplier > 20)
              {
                multiplier = 20.0; // for now
              }
            }
            else
            {
              multiplier /= 1.75;
              if (multiplier < 0.25)
              {
                multiplier = 0.25;
              }
            }

            // OK, not in the database, check for motion
            DateTime start = DateTime.Now;
            using Bitmap bitmap = new (fileName);
            DateTime startAI = DateTime.Now;
            List<InterestingObject> imageList = await AIDetection.AIFindObjectsAsync(bitmap, fileName).ConfigureAwait(true);
            TimeSpan elapsed = DateTime.Now - start;
            AITimeUpdater.UpdateFrameTime(DateTime.Now - startAI);
            lastAITime = elapsed.TotalSeconds;

            if (null != imageList)
            {
              if (imageList.Count > 0)
              {
                analyzer.RemoveInvalidObjects(cam, imageList);

                int xRes, yRes; //need the x,y res for frame analyzer
                xRes = bitmap.Width;
                yRes = bitmap.Height;

                FrameAnalyzer frameAnalyzer = new (cam.AOI, imageList, xRes, yRes);
                AnalysisResult analysisReult = await frameAnalyzer.AnalyzeFrameAsync(bitmap);
                List<InterestingObject> interesting = analysisReult.InterestingObjects;  // find if the objects we did find are interesting (relatively fast)
                if (interesting.Count > 0)
                {
                  int result = await MainWindow.InsertMotionIfNecessaryAsync(cam, fileName);
                  if (result > 0)
                  {
                    // Dbg.Trace("PerformMotionSync - Inserted file into motion database: " + fileName);
                  }
                }
                else
                {
                  int removed = await MainWindow.DeleteMissingMotionAsync(fileName).ConfigureAwait(true);
                  if (removed > 0)
                  {
                    Dbg.Trace("PerformMotionSync - Removed file from motion list: " + fileName);
                  }
                }
              }
            }

          }

          if (stopEvent.WaitOne(0))
          {
            break;
          }
        }
      }
      catch (Exception ex)
      {
        Dbg.Write("MainWindow - PerformMotionSync - Exception: " + ex.Message);
      }

      Dbg.Write("Ending Sync to Motion Database");
    }

  }
}
