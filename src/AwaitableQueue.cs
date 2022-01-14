using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.Threading;

namespace OnGuardCore
{

  public class AwaitableQueue<T> : IDisposable
  {
    int _waitTime;
    bool _stop;

    ConcurrentQueue<T> _q = new ();
    AsyncAutoResetEvent _available = new (true);
    private bool disposedValue;

    public AwaitableQueue(int waitTimeInSeconds)
    {
      _waitTime = waitTimeInSeconds;  // 0 - no timeout
    }

    public void Add(T addIt)
    {
      _q.Enqueue(addIt);
      _available.Set();
    }

    public async Task<T> GetAsync()
    {
      T result = default;

      while (!_stop)
      {
        if (_q.TryDequeue(out result))
        {
          break;
        }
        else
        {
          CancellationTokenSource source = new ();
          if (_waitTime > 0)
          {
            source.CancelAfter(_waitTime * 1000);
          }

          DateTime startAIWaitTime = DateTime.Now;

          CancellationToken token = source.Token;
          await _available.WaitAsync(token).ConfigureAwait(true);
          if (token.IsCancellationRequested)
          {
            TimeSpan span = DateTime.Now - startAIWaitTime;
            Dbg.Trace("AIDetection - Timeout trying to get an AI instance with time: " + span.TotalSeconds.ToString());
            break;
          }
        }
      }

      return result;
    }

    protected virtual void Dispose(bool disposing)
    {
      if (!disposedValue)
      {
        if (disposing)
        {
          _stop = true;
          _available.Set();
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
  }
}
