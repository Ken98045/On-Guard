using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnGuardCore
{
  public static class AITimeUpdater
  {
    public delegate void AIProcessTimeDelegate(TimeSpan timespan);
    public static event AIProcessTimeDelegate OnAITimeUpdate = delegate {};
    public static event AIProcessTimeDelegate OnFrameTimeUpdate = delegate { };

    public static void UpdateFrameTime(TimeSpan span)
    {
      OnFrameTimeUpdate(span);
    }

    public static void UpdateAITime(TimeSpan span)
    {
      OnAITimeUpdate(span);
    }
  }
}
