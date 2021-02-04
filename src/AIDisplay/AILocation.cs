using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace SAAI
{
  public class AILocation
  {

    static readonly object s_lock;
    static BufferBlock<AILocation> aiList;

    public static int AICount { get; set; }   // So we know whether to EXPECT an AI
    
    // as a global

    // Static Constructor used to get the global values
    static AILocation()
    {
      s_lock = new object();
      List<AILocation> result = new List<AILocation>();
      aiList = new BufferBlock<AILocation>();
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
      await aiList.SendAsync(ai).ConfigureAwait(false);
    }

    public async static Task<AILocation> GetAI()
    {
      AILocation ai = null;
      try
      {
        if (AICount == 0)
        {
          throw new AiNotFoundException("No available AIs are defined"); 
        }
        ai = await aiList.ReceiveAsync(TimeSpan.FromSeconds(30)).ConfigureAwait(false);
      }
      catch (InvalidOperationException)
      {
      }

      return ai;  // which may be null

    }


    public Guid ID { get; set; }
    public string IPAddress { get; set; }
    public int Port { get; set; }
    static private int Next { get; set; }

    
    public static void Refresh()
    {
      lock (s_lock)
      {
        AICount = 0;
        IList<AILocation> tmp;
        aiList.TryReceiveAll(out tmp);  // to empty the list;
        List<AILocation> locations = Storage.GetAILocations(); // get the list from the registry
        foreach (var ai in locations)
        {
          aiList.Post(ai);
          AICount++;
        }
      }
    }

  }

}
