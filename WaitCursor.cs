using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SAAI
{
  public class WaitCursor : IDisposable
  {
    Cursor m_cursorOld;
    bool _disposedValue = false; // To detect redundant call 

    /// <summary>
    /// .cteur
    /// </summary>
    public WaitCursor()
    {
      m_cursorOld = Cursor.Current;
      Cursor.Current = Cursors.WaitCursor;
    }

    /// <summary>
    /// Dispose
    /// </summary>
    public void Dispose()
    {
      Dispose(true);
      GC.SuppressFinalize(this);
    }


    /// <summary>
    /// Dispose
    /// </summary>
    /// <param name="disposing"></param>
    protected virtual void Dispose(bool disposing)
    {
      if (!_disposedValue)
        Cursor.Current = m_cursorOld;
      _disposedValue = true;
    }

  }
}
