using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnGuardCore
{
  static class Program
  {
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
      MainWindow main = null;

      Application.SetHighDpiMode(HighDpiMode.DpiUnawareGdiScaled);
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);

      try
      {
        Application.Run(main = new MainWindow());
      }
#if !DEBUG
      catch (ObjectDisposedException)
      {
      }
      
      catch (Exception ex)
      {
        MessageBox.Show("There was an unexpected error in On Guard.  Please report the following information: " + ex.Message, "Unexpected Error!");
      }
#endif
      finally
      {
        main?.Dispose();
      }

    }
  }
}
