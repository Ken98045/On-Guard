using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAAI
{
  public class FileTimeComparer : IComparer<DateTime>
  {
    public DateOrder Order { get; set; }

    public FileTimeComparer()
    {
      Order = DateOrder.Decending;
    }

    public void Reverse()
    {
      if (Order == DateOrder.Ascending)
      {
        Order = DateOrder.Decending;
      }
      else
      {
        Order = DateOrder.Ascending;
      }
    }

    public int Compare(DateTime first, DateTime second)
    {
      int result = Comparer<DateTime>.Default.Compare(first, second);

      if (Order == DateOrder.Decending)
      {
        result = 0 - result;
      }

      return result;
    }

  }

  public enum DateOrder
  {
    Ascending,
    Decending
  }
}


