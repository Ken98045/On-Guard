using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net;
using System.IO;
using System.Drawing;

namespace OnGuardCore
{
  public class TriggerCamera : IDisposable
  {
    CameraData _camera;
    DateTime _lastTrigger;
    DateTime _firstTrigger;
    DateTime _startSequence;
    DateTime _lastSequenceEnd;
    private bool disposedValue;
    private ManualResetEvent _stopEvent = new (false);
    private AutoResetEvent _triggerEvent = new (false);

    public TriggerCamera(CameraData camera)
    {
      Dbg.Write("TriggerCamera - Created");
      _camera = camera;

      _firstTrigger = DateTime.MinValue;
      _lastSequenceEnd = DateTime.MinValue;

      Task.Run(() => HandleTriggers());
    }


    async Task HandleTriggers()
    {
      WaitHandle[] waitEvents = new WaitHandle[2];
      waitEvents[0] = _stopEvent;
      waitEvents[1] = _triggerEvent;

      while (true)
      {
        int waitResult = WaitHandle.WaitAny(waitEvents);
        if (waitResult == 0)
        {
          break;
        }

        // here we are triggered with a new (typically FTP file)
        _startSequence = DateTime.Now;
        while ((DateTime.Now - _startSequence).TotalSeconds < _camera.RecordTime)
        {
          DateTime beforePic = DateTime.Now;
          await Task.Delay((int)(1000 * _camera.TriggerInterval));
          DateTime afterDelay = DateTime.Now;
          SavePicture();  // don't await because this can take a while

          if (_stopEvent.WaitOne(0))
          {
            break;
          }
          DateTime afterSavedPicture = DateTime.Now;

        }

        _lastSequenceEnd = DateTime.Now;
        _firstTrigger = DateTime.MinValue;
      }
    }

    private async Task SavePicture()
    {
      CameraContactData data = _camera.Contact;  // for clarity
      string urlString = data.ReplaceParmeters(data.JPGSnapshotURL);

      HttpWebRequest webRequest = (HttpWebRequest)HttpWebRequest.Create(urlString);

      if (_camera.Contact.JpgContactMethod != PTZMethod.BlueIris)
      {
        webRequest.Credentials = new System.Net.NetworkCredential(data.CameraUserName, data.CameraPassword);
      }

      webRequest.AllowWriteStreamBuffering = true;
      webRequest.Timeout = 5000;

      using WebResponse webResponse = await webRequest.GetResponseAsync().ConfigureAwait(true);
      using var stream = webResponse.GetResponseStream();
      using MemoryStream memStream = new();
      stream.CopyTo(memStream);

      using Bitmap bitmap = new(memStream);

      if (null == bitmap)
      {
        return;
      }

      string path = Path.Combine(_camera.CameraPath, _camera.CameraPrefix);
      path += DateTime.Now.Ticks.ToString() + ".jpg";
      bitmap.Save(path);

    }

    public bool Trigger()
    {
      bool result = false;

      DateTime now = DateTime.Now;

      if (result = CanTrigger())
      {
        _lastTrigger = DateTime.Now;
        _triggerEvent.Set();
        result = true;
      }

      return result;
    }

    public bool CanTrigger()
    {
      bool result = false;

      DateTime now = DateTime.Now;

      if (_firstTrigger == DateTime.MinValue) // are we triggered now?
      {
        // how long has it been since the last sequence?
        TimeSpan sinceLast = now - _lastSequenceEnd;
        if (sinceLast.TotalSeconds > _camera.RecordInterval)
        {
          result = true;
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
          Dbg.Write("TriggerCamera - Dispose");
          _stopEvent.Set();
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
