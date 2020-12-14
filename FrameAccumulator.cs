using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAAI
{

  public abstract class FrameAccumulator : IDisposable
  {

    public delegate void EmailAccumulated(SortedList<DateTime, Frame> frames);

    SortedList<DateTime, Frame> Frames { get; set; }

    protected readonly object _lock = new object();
    public int TimeToAccumulate { get; set; }
    protected bool DisposedValue { get => disposedValue; set => disposedValue = value; }

    protected System.Threading.Timer _timer;
    private bool disposedValue = false; // To detect redundant calls


    public void Init(int timeToAccumulate)
    {
      TimeToAccumulate = timeToAccumulate;
      Frames = new SortedList<DateTime, Frame>();

    }

    public void Add(Frame frame)
    {
      lock (_lock)
      {
        Frames.Add(frame.Item.TimeEnqueued, frame);
        if (null == _timer)
        {
          _timer = new System.Threading.Timer(DoneAccumulating, null, TimeToAccumulate * 1000, 0);
        }
      }

    }

    // This triggers when the timer expires or when we have the number of frames we were expecting
    void DoneAccumulating(object obj)
    {
      lock (_lock)
      {
        _timer = null;

        if (Frames.Values.Count > 0)
        {
          lock (Frames.Values[0].Item.CamData.AccumulateLock)
          {
            Frames.Values[0].Item.CamData.Accumulating = false;  // no longer accumulating
            Frames.Values[0].Item.CamData.TimeLastAccumulatorCompleted = DateTime.Now;
          }
        }

        List<Frame> aCopy = new List<Frame>();

        foreach (Frame frame in Frames.Values)
        {
          Frame cpy = new Frame(frame);
          aCopy.Add(cpy);
        }

        ProcessAccumulatedFrames(aCopy);
        Frames.Clear();
      }
    }



    protected virtual void Dispose(bool disposing)
    {
      if (!DisposedValue)
      {
        if (disposing)
        {
          lock (_lock)
          {
            if (_timer != null) _timer.Dispose();
          }
        }

        DisposedValue = true;
      }
    }


    public void Dispose()
    {
      Dispose(true);
      GC.SuppressFinalize(this);
    }

    public abstract void ProcessAccumulatedFrames(List<Frame> frames);


  }

}
