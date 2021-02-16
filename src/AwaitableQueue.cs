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

  public class AwaitableQueue<T>
  {
    int _waitTime;

    ConcurrentQueue<T> _q = new ConcurrentQueue<T>();
    AsyncAutoResetEvent _available = new AsyncAutoResetEvent(true);

    public AwaitableQueue(int waitTimeInSeconds)
    {
      _waitTime = waitTimeInSeconds;
    }

    public void Add(T addIt)
    {
      _q.Enqueue(addIt);
      _available.Set();
    }

    public async Task<T> GetAsync()
    {
      T result = default(T);

      while (true)
      {
        if (_q.TryDequeue(out result))
        {
          break;
        }
        else
        {
          CancellationTokenSource source = new CancellationTokenSource();
          source.CancelAfter(_waitTime * 1000);
          CancellationToken token = source.Token;
          await _available.WaitAsync(token).ConfigureAwait(false);
          if (token.IsCancellationRequested)
          {
            break;
          }
        }
      }

      return result;
    }

  }
}
