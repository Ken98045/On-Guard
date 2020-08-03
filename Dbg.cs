using System;
using System.Collections.Concurrent;
using System.Threading;
using System.IO;

namespace SAAI
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
    static readonly TextWriter s_LogWriter;

    // DebugWriter.Write
    static Dbg()
    {
      s_LogWriter = new StreamWriter("OnGuard.txt", true);
      processThread.Start();
    }

    static public void Write(string debugString)
    {
      string str = string.Format("{0} - {1}", DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss:ffff"), debugString);
      q.Enqueue(str);
      activity.Set();
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

            Console.WriteLine(output);
            s_LogWriter.WriteLine(output);
            s_LogWriter.Flush();
          }
          else
          {
            activity.Reset();
          }
        }
      }

      s_LogWriter.Close();
    }
  }
}
