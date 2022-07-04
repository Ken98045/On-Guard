using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace OnGuardCore
{
  public delegate void BoolDelegate(bool aiState);

  public class AILocation
  {
    public AILocation(string ipAddress, int port)
    {
      IPAddress = ipAddress;
      Port = port;
    }

    public string IPAddress { get; }
    public int Port { get; }
  }

  public class AI
  {
    public static event BoolDelegate OnAIStateChange =  delegate { };
    static string IPAddress { get; set; }
    static int Port { get; set; }


    static readonly object s_lock;
    // static BufferBlock<AILocation> aiList;
    static DateTime s_timeLastSuccess;
    static DateTime s_timeOfLastRestart;
    static bool s_AIDead;

    readonly static int s_maxInstances = 4;

    private static int _aiCount;
    private static SemaphoreSlim s_semaphore;
    public static int AICount
    {
      get => _aiCount; set => _aiCount = value;
    }   // So we know whether to EXPECT an AI

    // as a global

    // Static Constructor used to get the global values
    static AI()
    {
      s_lock = new object();
      lock (s_lock)
      {
        if (null != Storage.Instance)
        {
          AILocation location = Storage.Instance.GetAILocation();
          IPAddress = location.IPAddress;
          Port = location.Port;
          s_semaphore = new SemaphoreSlim(s_maxInstances, s_maxInstances);
        }
      }
    }

    public static void SetAILocation(string ipAddress, int port)
    {
      IPAddress = ipAddress;
      Port = port;
      Storage.Instance.SetAILocation(ipAddress, port);
    }

    public static AILocation GetAILocation()
    {
      AILocation location = new(IPAddress, Port);
      return location;
    }

    public static bool IsAIDead()
    {
      lock (s_lock)
      {
        if (!s_AIDead)
        {
          return false;
        }
        else
        {
          return RestartAI(false);
        }
      }
    }


    // We can ONLY restart the AI if the user has setup auto start or if the user is calling this directly
    public static bool RestartAI(bool forceStart)
    {
      lock (s_lock)
      {
        return RestartAI(false, forceStart);
      }
    }

    public static bool RestartAI(bool ignoreRestartTime, bool forceStart)
    {
      bool result = false;

      lock (s_lock)
      {

        Dbg.Write(LogLevel.Warning, "AILocation - Atttempting to restart the AI");

        TimeSpan timeSinceRestart = DateTime.Now - s_timeOfLastRestart;
        if (ignoreRestartTime || timeSinceRestart.TotalMinutes > 1)
        {

          bool canRestart = false;
          if (forceStart)
          {
            canRestart = true;
          }
          else
          {
            canRestart = Storage.Instance.GetGlobalBool("AutoStartDeepStack");
          }

          if (canRestart)
          {
            s_timeOfLastRestart = DateTime.Now;

            // First, if it currently exists then kill it.
            // Note that with the current (9/1/21) DeepStack there can be only one
            foreach (var process in Process.GetProcessesByName("deepstack"))
            {
              Dbg.Write(LogLevel.Warning, "AILocation - Restart AI - Killing off the existing AI");
              process.Kill(true);
              Thread.Sleep(1000);
              break;
            }


            string startParameters = Storage.Instance.GetGlobalString("DeepStackParameters");
            ProcessStartInfo startInfo = new("deepstack", startParameters);
            startInfo.UseShellExecute = true;

            bool visible = Storage.Instance.GetGlobalBool("DeepStackVisible");
            if (!visible)
            {
              startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            }
            else
            {
              startInfo.WindowStyle = ProcessWindowStyle.Minimized;
            }

            startInfo.LoadUserProfile = true;

            Process p = Process.Start(startInfo);
            Thread.Sleep(1000 * 2); // just to be sure
            if (p != null)
            {
              p.Refresh();
              Thread.Sleep(500);
              if (!p.HasExited)
              {
                // At this point we will assume that we have a fresh copy of the AI that is good to go!
                s_AIDead = false;
                AIStateChange(true);
                Dbg.Write(LogLevel.Info, "AILocation - RestartAI - The restart was successful!");
                s_timeLastSuccess = DateTime.Now;

                if ((s_maxInstances - s_semaphore.CurrentCount) > 0)
                {
                  try
                  {
                    s_semaphore.Release(s_maxInstances - s_semaphore.CurrentCount);  // reset the counter so we can proceeed!
                  }
                  catch (SemaphoreFullException)
                  {
                    // possibly a race condition
                  }
                }
                result = true;
              }
              else
              {
                Dbg.Write(LogLevel.Error, "AILocation - RestartAI - The DeepStack process started and then stopped!");
              }
            }
          }
          else
          {
            Dbg.Write(LogLevel.Warning, "AILocation - Restart AI - The current settings do not allow for an AI restart");
            s_timeOfLastRestart = DateTime.Now;
          }
        }
        else
        {
          Dbg.Write(LogLevel.Warning, "AILocation - RestartAI - We are attempting to restart the AI too frequently");
        }
      }

      return result;
    }

    public static bool IsAIRunning()
    {
      bool result = false;

      AILocation location = Storage.Instance.GetAILocation();
      bool isRemote = false;

      if (location.IPAddress.ToLower() != "localhost")
      {
        isRemote = true;
        // possibly the AI is located remotely
        // However, the address could be on this machine (just with a real address)
        var host = Dns.GetHostEntry(Dns.GetHostName());
        foreach (var ip in host.AddressList)
        {
          if (ip.AddressFamily == AddressFamily.InterNetwork)
          {
            
            if (ip.ToString() == location.IPAddress.ToLower())
            {
              isRemote = false;
              break;
            }
          }
        }
      }

      if (isRemote)
      {
        result = true;
      }
      else
      {
        Process[] deepStackProcesses = Process.GetProcessesByName("deepstack");
        if (null != deepStackProcesses && deepStackProcesses.Length > 0)
        {
          result = true;
        }
      }

      return result;
    }

    public static void StopAI()
    {
      foreach (var process in Process.GetProcessesByName("deepstack"))
      {
        Dbg.Write(LogLevel.Warning, "AILocation - StopAI - Killing off the existing AI");
        process.Kill(true);
        Thread.Sleep(1000);
        break;
      }
    }

    public static async Task<HttpResponseMessage> PostAIRequestAsync(HttpClient client, string url, MultipartFormDataContent requestData)
    {

      HttpResponseMessage output = null;
      bool waitResult;
      url = $"http://{IPAddress}:{Port}/{url}";

      if (IsAIDead())
      {
        throw new AiNotFoundException(url);
      }


      // The first thing we do is to limit the number of outstanding requests to the AI.
      // In therory the new DeepStack model shouldn't get overloaded, but not counting on that
      waitResult = await s_semaphore.WaitAsync(120 * 1000);

      if (!waitResult)
      {
        // maybe some other request determined that the AI is dead.
        if (IsAIDead())
        {
          throw new AiNotFoundException(url);
        }

        // OK, here things were very slow, possibly the AI is dead.
        // We determine which by looking at whether the AI has returned ANY results recently (1 min for now)
        TimeSpan timeSinceLastResult = DateTime.Now - s_timeLastSuccess;
        if (timeSinceLastResult.TotalSeconds > 60)
        {
          // OK, the AI hasn't done anything recently, now error out
          AIStateChange(false);
          throw new AiNotFoundException(url);
        }
        else
        {
          // well, the AI is doing something (or did recently even though it may now be dead)
        }
      }

      try
      {

        int retryCount = 0;
        client.Timeout = TimeSpan.FromSeconds(70);

        do
        {
          try
          {
            DateTime postStart = DateTime.Now;
            output = await client.PostAsync(new Uri(url), requestData);

            AITimeUpdater.UpdateAITime(DateTime.Now - postStart);

            retryCount = 0; // don't need no retry do we
          }
          catch (HttpRequestException)
          {
            ++retryCount;
          }
          catch (AggregateException)
          {
            ++retryCount;
          }
          catch (Exception )
          {
            ++retryCount;
          }

          if (null != output && !output.IsSuccessStatusCode)
          {
            return output;  // early out
          }

          if (retryCount == 1)  // once and only one try restarting the ai
          {
            if (RestartAI(false) == false)
            {
              // the AI failed to start (or the user doesn't allow it)
              AIStateChange(false);
              throw new AiNotFoundException(url);
            }
            else
            {
              // do the one retry
            }
          }
          else if (retryCount > 1)
          {
            // The AI restarted, but we couldn't reach it or there was some other failure (maybe some other exception, but....
            s_AIDead = true;
            AIStateChange(false);
            throw new AiNotFoundException(url);
          }

        } while (retryCount > 0);

        s_timeLastSuccess = DateTime.Now;

      }
      finally
      {
        try
        {
          s_semaphore.Release();
        }
        catch (SemaphoreFullException)
        {
        }

      }

      return output;
    }

    static void AIStateChange(bool aiAlive)
    {
      s_AIDead = !aiAlive;
      OnAIStateChange(aiAlive);
    }
  }

}
