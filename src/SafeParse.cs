using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnGuardCore
{
  // There are a LOT of cases where we are parsing values from various sources, primarily settings
  // in these cases we are getting strings and we need to parse them into the approriate type.
  // It is generally safe to leave them as the default (but not always which is why we log it)

  public static class SafeParse
  {
    public static object Parse(Type t, string str)
    {
      object o = null;

      try
      {
        if (!string.IsNullOrEmpty(str))
        {

          if (t.BaseType.Name == "Enum")
          {
            o = 0;
            object ee = Enum.Parse(t, str);
            o = ee;
          }
          else
          {

            switch (t.Name)
            {
              case "Int32":
                o = 0;
                int ii = int.Parse(str);
                o = ii;
                break;

              case "Double":
                o = 0.0;
                double dd = double.Parse(str);
                o = dd;
                break;

              case "Boolean":
                o = false;
                object oo = bool.Parse(str);
                o = oo;
                break;

              case "Guid":
                o = Guid.Empty;
                Guid gg = Guid.Parse(str);
                o = gg;
                break;

              default:
                o = null;
                break;

            }
          }
        }
        else
        {

          if (t.BaseType.Name == "Enum")
          {
            o = 0;  // a reasonable default?
          }
          else
          {

            switch (t.Name)
            {
              case "Int32":
                o = 0;
                break;

              case "Double":
                o = 0.0;
                break;

              case "Boolean":
                o = false;
                break;

              case "Guid":
                o = Guid.Empty;
                break;

              default:
                o = null;
                break;

            }
          }

        }
      }
      catch (Exception ex)
      {
        Dbg.Write(LogLevel.Error, "SafeParse - Unexpected exception: " + ex.Message);
      }

      return o;
    }
  }
}
