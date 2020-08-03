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
      try
      {
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new MainWindow());
      }
      catch (ObjectDisposedException)
      {
      }

     }
  }
}
