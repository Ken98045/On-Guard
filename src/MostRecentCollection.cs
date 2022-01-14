using System.Collections.Generic;
using System.Linq;

namespace OnGuardCore
{

/// <summary>
/// A class to clollect a list of recent values.
/// In this case it is used to track AI processing time
/// so we can average them out.
/// </summary>
  public class MostRecentCollection : List<double>
  {
    public int MaxItems { get; }
    readonly object _lock = new object();

    public MostRecentCollection(int numberOfItems)
    {
      MaxItems = numberOfItems;
    }

    public void AddValue(double v)
    {
      lock (_lock)
      {
        if (Count == MaxItems)
        {
          RemoveAt(0);
        }

        Add(v);
      }
    }

    public double Avg()
    {
      double result;

      lock (_lock)
      {
        result = 0.0;

        if (Count > 0)
        {
          result = this.Average();
        }

      }
      return result;
    }

  }
}
