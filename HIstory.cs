using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;

// In general using old style threading seems a more natural model for what the History collection needs to do.
// Similarly, none of the pre-defined concurrent collections seem appropriate either.

namespace SAAI
{
  public class History : IDisposable
  {
    readonly int _historyLength;
    readonly Thread _thread;
    readonly ManualResetEvent _stopEvent = new ManualResetEvent(false);
    readonly object _lock = new object();
    private bool disposedValue;
    readonly SortedList<DateTime, Frame> _historyList = new SortedList<DateTime, Frame>();

    public History(int historyInSeconds)
    {
      _historyLength = historyInSeconds;
      _thread = new Thread(CleanupOldFrames);
      _thread.IsBackground = true;
      _thread.Start();
    }

    protected virtual void Dispose(bool disposing)
    {
      if (!disposedValue)
      {
        if (disposing)
        {
          _stopEvent.Set();
          _thread.Join(2000);
          _stopEvent.Dispose();
        }

        disposedValue = true;
      }
    }

    public void Dispose()
    {
      // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
      Dispose(disposing: true);
      GC.SuppressFinalize(this);
    }

    public void Add(Frame frame)
    {
      lock (_lock)
      {
        DateTime createTime = File.GetCreationTime(frame.Item.PendingFile);
        _historyList[createTime] = frame;
      }
    }

    public List<Frame> GetFramesInTimespan(TimeSpan span, DateTime target, TimeDirection direction)
    {
      List<Frame> result = new List<Frame>();

      lock (_historyList)
      {

        IEnumerable<DateTime> selectResult = null;
        switch (direction)
        {
          case TimeDirection.Before:
            selectResult = _historyList.Keys.Where(fileTime => fileTime < target && ((target - fileTime).TotalSeconds < span.TotalSeconds));
            break;

          case TimeDirection.After:
            selectResult = _historyList.Keys.Where(fileTime => fileTime > target && ((fileTime - target).TotalSeconds < span.TotalSeconds));
            break;

          case TimeDirection.Both:
            selectResult = _historyList.Keys.Where(fileTime => (fileTime < target && ((target - fileTime).TotalSeconds < span.TotalSeconds)) || (fileTime > target && ((fileTime - target).TotalSeconds < span.TotalSeconds)));
            break;
        }

        foreach (var ft in selectResult)
        {
          result.Add(_historyList[ft]);
        }

      }

      return result;
    }

    void CleanupOldFrames()
    {

      while (true)
      {
        bool waitResult = _stopEvent.WaitOne(500);
        if (waitResult)
        {
          break;  // history is disposing, exit immediately
        }

        // remove old frames as determined by the history length.
        lock (_lock)
        {
          while (_historyList.Count > 0)
          {
            TimeSpan span = DateTime.Now - _historyList.Keys[0];
            if (span.TotalSeconds >= _historyLength)
            {
              _historyList.RemoveAt(0);
              Thread.Sleep(0);  // don't be hog, not really a problem, but....
            }
            else
            {
              break;
            }  
          }
        }
      }

    }
  }

  public enum TimeDirection
  {
    Both = 0,
    Before = 1,
    After = 2
  }
}
