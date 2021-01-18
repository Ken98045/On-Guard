using System;
using System.Windows.Forms;

namespace SAAI
{
  static class Program
  {
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
      Application.EnableVisualStyles();
      MainWindow main = null;
      try
      {
        Application.SetCompatibleTextRenderingDefault(false);
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
