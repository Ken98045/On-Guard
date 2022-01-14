using System;
using System.Collections.Concurrent;
using System.Threading;
using System.IO;
using System.Diagnostics;

namespace OnGuardCore
{

  /// <summary>
  /// A class for writing debug information.  We queue the string (with date and time)
  /// We write it out on a different thread.  We may add the ability to write it to a file.
  /// </summary>

  public static class Dbg
  {
    static readonly ConcurrentQueue<string> q = new ();
    static readonly ManualResetEvent activity = new (false);
    static public ManualResetEvent Stop { get; } = new (false);
    static readonly Thread processThread = new (ProcessOutput);
    static TextWriter s_LogWriter;
    public static int LogLevel { get; set; }
    static string s_path;
    static bool s_logIsClosed;
    static DateTime s_lastWrite;

    // DebugWriter.Write
    static Dbg()
    {
      LogLevel = 0;
      s_path = Storage.GetFilePath("OnGuard.txt");
      s_LogWriter = new StreamWriter(s_path, true);
      s_lastWrite = DateTime.Now;
      processThread.Start();
    }

    static public void Write(string debugString)
    {
      string str = string.Format("{0} - {1}", DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss:ffff"), debugString);
      q.Enqueue(str);
      activity.Set();
    }

    static public void Trace(string debugString)
    {
      if (LogLevel > 0)
      {
        Write("(Trace) " + debugString);
      }
    }

    static public bool DeleteLogFile()
    {
      bool result = false;
      int tryCount = 0;

      s_logIsClosed = true;

      while (tryCount < 5)
      {
        try
        {
          s_LogWriter.Close();
          File.Delete(s_path);
          result = true;
          break;
        }
        catch (Exception)
        {
          Thread.Sleep(200);
          ++tryCount;
        }
      }

      s_LogWriter = new StreamWriter(s_path, true);
      s_LogWriter.WriteLine("The log file was reset at: " + DateTime.Now.ToString());
      s_LogWriter.Flush();
      s_logIsClosed = false;
      return result;
    }

    static void ProcessOutput()
    {
      WaitHandle[] waits = new WaitHandle[2];
      waits[0] = Stop;
      waits[1] = activity;

      while (!Stop.WaitOne(0))
      {
        while (WaitHandle.WaitAny(waits) != 0)
        {
          if (q.TryDequeue(out string output))
          {

            Debug.WriteLine(output);
            try
            {
              WaitForFile();
              s_LogWriter.WriteLine(output);
              TimeSpan diff = DateTime.Now - s_lastWrite;

              if (diff.TotalSeconds > 30)
              {
                s_LogWriter.Flush();
                s_lastWrite = DateTime.Now;
              }
            }
            catch { }
          }
          else
          {
            activity.Reset();
          }
        }
      }
    }


    static void WaitForFile()
    {
      while (s_logIsClosed)
      {
        if (Stop.WaitOne(200))
        {
          break;
        }
      }
    }

    public static void PauseLogFile(bool pauseIt)
    {
      if (pauseIt)
      {
        s_logIsClosed = true;
        s_LogWriter.Close();
      }
      else
      {
        s_LogWriter = new StreamWriter(s_path, true);
        s_logIsClosed = false;
      }
    }
  }
}
