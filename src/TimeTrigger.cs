using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OnGuardCore
{
  public delegate void GuidDelegate(Guid id);
  public class TimeTrigger
  {
    static Dictionary<Guid, Timer> _timers = new Dictionary<Guid, Timer>();
    public static event GuidDelegate OnTimeTriggered = delegate { };

    // The trigger passed in is not a full date/time.
    // Rather, it is a time such as 4:46pm where the time might be today/tomorrow -- we ignore the year/month/day/seconds
    public static void AddTimer(DateTime trigger, Guid id)
    {
      DateTime now = DateTime.Now;

      // Get some easy comparison for the requested vs now.
      int totalNowMin = (now.Hour * 60) + now.Minute;
      int totalTriggerMin = (trigger.Hour * 60) + trigger.Minute;
      DateTime realTrigger = now;

      if (totalNowMin >= totalTriggerMin)
      {
        // we are dealing with tomorrow, not today
        realTrigger = new DateTime(now.Year, now.Month, now.Day, trigger.Hour, trigger.Minute, 0);
        realTrigger = realTrigger.AddDays(1);
      }
      else
      {
        realTrigger = new DateTime(now.Year, now.Month, now.Day, trigger.Hour, trigger.Minute, 0);  // today
      }

      TimeSpan span = realTrigger - now;

      Timer timer = new Timer(OnTimer, id, span, TimeSpan.FromMilliseconds(-1));
      _timers[id] = timer;

    }


    private static void OnTimer(object obj)
    {
      Guid id = (Guid)obj;
      OnTimeTriggered(id);
      _timers[id].Change(TimeSpan.FromDays(1), TimeSpan.FromMilliseconds(-1));  // reset for tomorrow
    }

    public static void Remove(Guid id)
    {
      if (_timers.ContainsKey(id))
      {
        Timer t = _timers[id];
        t.Dispose();
        _timers.Remove(id);
      }

    }

    public static  void ClearAll()
    {
      foreach (var timer in _timers.Values)
      {
        timer.Dispose();
      }

      _timers.Clear();
    }

    public static DateTime GetHourMinute(int hour, int minute)
    {
      DateTime newDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, hour, minute, 0);
      return newDate;
    }
  }

}