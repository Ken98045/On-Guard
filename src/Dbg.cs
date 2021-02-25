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
    static readonly ConcurrentQueue<string> q = new ConcurrentQueue<string>();
    static readonly ManualResetEvent activity = new ManualResetEvent(false);
    static public ManualResetEvent Stop { get; } = new ManualResetEvent(false);
    static readonly Thread processThread = new Thread(ProcessOutput);
    static TextWriter s_LogWriter;
    public static int LogLevel { get; set; }
    static string s_path;

    // DebugWriter.Write
    static Dbg()
    {
      LogLevel = 0;
      s_path = Storage.GetFilePath("OnGuard.txt");
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

      while (tryCount < 5)
      {
        try
        {
          if (null == s_LogWriter)
          {
            File.Delete(s_path);
            s_LogWriter = null;
          }

          result = true;
          break;
        }
        catch (IOException)
        {
          Thread.Sleep(100);
          ++tryCount;
        }
      }

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
            if (s_LogWriter == null)
            {
              s_LogWriter = new StreamWriter(s_path, true);
            }

            s_LogWriter.WriteLine(output);
            s_LogWriter.Flush();
          }
          else
          {
            activity.Reset();
            if (s_LogWriter != null)
            {
              try
              {
                s_LogWriter.Close();
              }
              catch { }
            }
            s_LogWriter = null;
          }
        }
      }

      if (s_LogWriter != null)
      {
        s_LogWriter.Close();
      }
    }
  }
}
