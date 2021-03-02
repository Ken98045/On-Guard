using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace OnGuardCore
{
  public class AILocation
  {

    static readonly object s_lock;
    // static BufferBlock<AILocation> aiList;
    static AwaitableQueue<AILocation> aiList;

    private static int _aiCount;
    public static int AICount
    {
      get => _aiCount; set => _aiCount = value;
    }   // So we know whether to EXPECT an AI

    // as a global

    // Static Constructor used to get the global values
    static AILocation()
    {
      s_lock = new object();
      List<AILocation> result = new List<AILocation>();
      aiList = new AwaitableQueue<AILocation>(30);
      Refresh();
    }

    public AILocation(Guid id, string ipAddress, int port)
    {
      ID = id;
      IPAddress = ipAddress;
      Port = port;
    }

    public async static Task ReturnToList(AILocation ai)
    {
      aiList.Add(ai);
    }

    public async static Task<AILocation> GetAI()
    {
      AILocation ai = null;
      try
      {
        ai = await aiList.GetAsync();
      }
      catch (TaskCanceledException)
      {
        // just let it return null
      }
      return ai;  // which may be null

    }


    public Guid ID { get; set; }
    public string IPAddress { get; set; }
    public int Port { get; set; }
    static private int Next { get; set; }

    public static void Decrement()
    {
      Interlocked.Decrement(ref _aiCount);
    }

    
    public static void Refresh()
    {
      lock (s_lock)
      {
        AICount = 0;
        List<AILocation> locations = Storage.Instance.GetAILocations(); // get the list from the registry
        foreach (var ai in locations)
        {
          aiList.Add(ai);
          AICount++;
        }
      }
    }

  }

}
