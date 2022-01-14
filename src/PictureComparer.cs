using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnGuardCore
{
  public class PictureComparer : IComparer<string>
  {
    public PictureOrder Order { get; set; }

    public PictureComparer()
    {
      Order = PictureOrder.Decending;
    }

    public void Reverse()
    {
      if (Order == PictureOrder.Ascending)
      {
        Order = PictureOrder.Decending;
      }
      else
      {
        Order = PictureOrder.Ascending;
      }
    }

    public int Compare(string first, string second)
    {
      int result = string.Compare(first, second);

      if (Order == PictureOrder.Decending)
      {
        result = 0 - result;
      }

      return result;
    }

  }

  public enum PictureOrder
  {
    Ascending,
    Decending
  }
}


