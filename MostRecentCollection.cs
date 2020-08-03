using System.Collections.Generic;
using System.Linq;

namespace SAAI
{

/// <summary>
/// A class to clollect a list of recent values.
/// In this case it is used to track AI processing time
/// so we can average them out.
/// </summary>
  public class MostRecentCollection : List<double>
  {
    readonly int _numberOfItems;
    readonly object _lock = new object();

    public MostRecentCollection(int numberOfItems)
    {
      _numberOfItems = numberOfItems;
    }

    public void AddValue(double v)
    {
      lock (_lock)
      {
        if (Count == _numberOfItems)
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
