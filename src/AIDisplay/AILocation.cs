using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAAI
{
  public class AILocation
  {

    static readonly object s_lock;
    static List<AILocation> aiLocations;
    // as a global

    public static List<AILocation> AILocations
    { 
      get
      {
        lock (s_lock)
        {
          return aiLocations;
        }
      }

      set
      {
        lock (s_lock)
        {
          aiLocations = value;
        }
      }
    }

    public Guid ID { get; set; }
    public string IPAddress { get; set; }
    public int Port { get; set; }
    static private int Next { get; set; }

    // Static Constructor used to get the global values
    static AILocation()
    {
      s_lock = new object();
      Refresh();
    }

    public static void Refresh()
    {
      lock (s_lock)
      {
        AILocations = Storage.GetAILocations(); // get the list from the registry
      }
    }


    public AILocation(Guid id, string ipAddress, int port)
    {
      ID = id;
      IPAddress = ipAddress;
      Port = port;
    }

    static public AILocation GetAvailableAI()
    {
      AILocation result = null;
      lock (s_lock)
      {

        // The global list may have changed since the last call!
        int useItem = 0;
        if (AILocation.Next < AILocation.AILocations.Count)
        {
          useItem = AILocation.Next;  
        }
        else
        {
          AILocation.Next = 0;  // start at the zero position, but still may not exist!
          useItem = 0;  // yeah we will try it
        }

        if (useItem < AILocation.AILocations.Count) // which also accounts for the empty list possiblity
        {
          result = AILocation.AILocations[useItem];
        }

        // Now, change the next one! 
        ++Next;
        if (Next >= AILocation.AILocations.Count)
        {
          Next = 0; // start the list over (which may only have one (usually))
        }
      }

      if (null == result)
      {
        Dbg.Trace("No AI Locations were found!");
        throw new AiNotFoundException("No AI Locations were found! Please define at least one!");
      }

      return result;
    }

  }
}
