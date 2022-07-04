using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Drawing;
using System.IO;
using System.Resources;

using System.Drawing.Imaging;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnGuardCore
{
  public class Picture : IDisposable
  {
    public PictureTypes PictureType { get; set; }

    CancellationTokenSource _source = new ();
    CancellationTokenSource Source { get => _source; }

    Bitmap _pictureBitmap;
    public Bitmap PictureBitmap { get => _pictureBitmap; }
    Bitmap _originalBitmap;
    public Bitmap OriginalBitmap { get => _originalBitmap; }

    string _fileName;
    public string FileName { get => _fileName; set => _fileName = value; }

    PictureState _state;
    public PictureState State { get => _state; set => _state = value; }

    List<InterestingObject> _interestingObjects = new ();
    public List<InterestingObject> InterestingObjects { get => _interestingObjects; set => _interestingObjects = value; }

    bool _analyzeIt;
    public bool AnalyzeIt { get => _analyzeIt; set => _analyzeIt = value; }


    readonly Color _registrationMarkColor = Color.FromArgb(120, Color.Purple);


    Guid _id = Guid.NewGuid();
    public Guid ID { get => _id; set => _id = value; }

    private bool disposedValue;

    public static event PictureHandlerDelegate OnPictureAvailable = delegate { };
    public static event InterestingObjectsProcessedDelegate OnObjectsDetected = delegate { };
    static SemaphoreSlim _loadFileSemaphore = new (1);

    public Picture(Bitmap bitmap, PictureTypes  pictureType)
    {
      if (bitmap != null)
      {
        _pictureBitmap = new Bitmap(bitmap);
        _originalBitmap = new Bitmap(bitmap);
        PictureType = pictureType;
        State = PictureState.PictureLoaded;
      }
    }

    public Picture(Bitmap bitmap)
    {
      if (bitmap != null)
      {
        _pictureBitmap = new Bitmap(bitmap);
        _originalBitmap = new Bitmap(bitmap);
        State = PictureState.PictureLoaded; // we won't load it so it is loaded
      }
    }

    public Picture(string fileName)
    {
      _fileName = fileName;
    }

    public string GetKey()
    {
      string result = GlobalFunctions.GetUniqueFileName(_fileName);
      return result;
    }

    public void SetBitmap(Bitmap bitmap)
    {
      _pictureBitmap = new Bitmap(bitmap);  // The bitmap from the disk is 24bpp,the copy is 32bpp (and, yes, it matters)
      _originalBitmap = new Bitmap(bitmap);  // We need an original copy because we are possibly drawing into it (object rectangles for one)
      State = PictureState.PictureLoaded; // even if it might be the "not available" picture;
    }

    public static void LoadComplete(Picture p)
    {
      p._state = PictureState.PictureLoaded;
      PictureAvailable(p);
    }

    public static async Task LoadAsync(Picture picture)
    {
      string fileName = picture.FileName;
      picture.State = PictureState.LoadingPicture;
      bool continueTrying = false;
      int count = 0;

      try
      {
        await _loadFileSemaphore.WaitAsync();       // Only let the pictures be loaded/analyzed in order or things get FUBARED

        do
        {

          if (File.Exists(fileName))
          {
            try
            {
              Bitmap fromDisk = null;

              using (FileStream stream = new (fileName, FileMode.Open, FileAccess.Read, FileShare.None))
              {

                if (!picture.Source.IsCancellationRequested)
                {
                  fromDisk = new Bitmap(stream);      // 24bpp
                }
                else
                {
                  picture.State = PictureState.Canceled;
                }
              }

              if (null != fromDisk)
              {
                picture.SetBitmap(fromDisk);
                fromDisk.Dispose();
                break;
              }

            }
            catch (IOException ex)
            {
              ++count;  // could be slow to get exclusive access to the bitmap
              continueTrying = true;
              try
              {
                await Task.Delay(50, picture.Source.Token);
              }
              catch (TaskCanceledException)
              {
                picture.State = PictureState.Canceled;
                continueTrying = false;
                break;
              }
            }
            catch (Exception ex)
            {
              Type t = ex.GetType();
              Dbg.Write(LogLevel.Error, "Picture -- Load -- Unexpected Exception: " + ex.Message);
            }
          }
          else
          {
            picture.State = PictureState.FileDoesNotExist;
            break;
          }
        } while (!picture.Source.IsCancellationRequested && continueTrying && count < 100);  // timeout after 10 seconds max (slow FTP might be here)

        if (picture.State == PictureState.PictureLoaded && picture.AnalyzeIt)
        {
          await picture.DetectObjectsAsync();
        }
      }
      catch (AiNotFoundException ex)
      {
        picture.State = PictureState.AINotFound; ;
      }
      finally
      {
        _loadFileSemaphore.Release();
      }

      if (null == picture.PictureBitmap)
      {
        if (count >= 100 && picture.State != PictureState.Canceled)
        {
          picture.State = PictureState.LoadFailed;
        }
      }

      PictureAvailable(picture);
    }

    /// <summary>
    /// Restore the original bitmap (as loaded) because we may have draw to the PictureBitmap
    /// </summary>
    public void RestoreBitmap()
    {
      _pictureBitmap = new Bitmap(OriginalBitmap);
    }

    public void Cancel()
    {
      _source?.Cancel();
    }

    public bool WasCanceled()
    {
      bool result = false;
      if (null == _source)
      {
        result = true;
      }
      else
      {
        result = _source.IsCancellationRequested;
      }

      return result;
    }

    public async Task DetectObjectsAsync()
    {
      State = PictureState.AnalyzingPicture;

      try
      {
        DateTime start = DateTime.Now;
        _interestingObjects = await AIDetection.AIProcessFromUIAsync(PictureBitmap, FileName).ConfigureAwait(true);
        AITimeUpdater.UpdateFrameTime(DateTime.Now - start);
        State = PictureState.PictureLoaded;
      }
      catch (AggregateException ex)
      {
        if (ex.InnerException is AiNotFoundException) // This we know how to handle.
        {
          State = PictureState.AINotFound;
          _interestingObjects = null;
        }
      }
      catch (TaskCanceledException)
      {
        _interestingObjects = null;
        State = PictureState.Canceled;
      }
      catch (AiNotFoundException)
      {
        throw;
      }

    }

    public void DrawRegistrationMark(int x, int y)
    {
      using SolidBrush registrationBrush = new(_registrationMarkColor);
      using var graphics = Graphics.FromImage(PictureBitmap);
      int regSize = 10;
      if (BitmapResolution.XResolution < 1024)
      {
        regSize = 7;
      }
      else if (BitmapResolution.XResolution > 2560)
      {
        regSize = 30;
      }
      else if (BitmapResolution.XResolution >= 1500)
      {
        regSize = 20;
      }

      Rectangle rect = Rectangle.FromLTRB(x - regSize, y - regSize,
                                        x + regSize + 1, y + regSize + 1);

      graphics.FillRectangle(registrationBrush, rect);
    }

    public void DrawObjectRectangles()
    {
      if (InterestingObjects != null && InterestingObjects.Count > 0)
      {

        using var graphics = Graphics.FromImage(PictureBitmap);
        using Pen redPen = new (Color.Red, 2);
        foreach (InterestingObject obj in InterestingObjects)
        {

          Rectangle rect = obj.ObjectRectangle;
          graphics.DrawRectangle(redPen, rect);

          Label label = new ();
          label.AutoSize = false;
          label.BackColor = Color.White;
          label.ForeColor = Color.Black;
          label.Height = 70;
          label.Font = new Font("Microsoft Sans Serif", 16, FontStyle.Bold);
          label.AutoSize = false;
          string confidence = $"{(100.0 * obj.Confidence),0:0.##}";

          label.Text = obj.Label + Environment.NewLine + confidence + Environment.NewLine;
          var labelSize = TextRenderer.MeasureText(obj.Label, label.Font);
          var confidenceSize = TextRenderer.MeasureText(confidence.ToString(), label.Font);
          if (confidenceSize.Width > labelSize.Width)
          {
            labelSize.Width = confidenceSize.Width;
          }

          label.Width = (int)labelSize.Width + 5;
          label.Height = (int)(labelSize.Height * 2.25);

          Rectangle labelRect = new (rect.X + 10, rect.Top - (label.Height - 5), label.Width, label.Height);
          if (labelRect.Y < 0)
          {
            labelRect.Y = 0;
          }

          if (labelRect.X < 0)
          {
            labelRect.X = 0;
          }

          label.DrawToBitmap(PictureBitmap, labelRect);
        }
      }
    }

    /*public void DrawAreaDefinitions(List<GridDefinition> areas)
    {

      int xStride = PictureBitmap.Width / areas[0].XDim;  // the same for all areas 
      int yStride = PictureBitmap.Height / areas[0].YDim;

      using (SolidBrush brush = new SolidBrush(Color.FromArgb(80, Color.DarkOrange)))
      {
        using (Graphics graphics = Graphics.FromImage(PictureBitmap))
        {
          foreach (var area in areas)
          {
            for (int col = 0; col < area.XDim; col++)
            {
              for (int row = 0; row < area.YDim; row++)
              {
                if (area.Get(col, row))
                {
                  Rectangle rect = new Rectangle(col * xStride, row * yStride, xStride + 1, yStride + 1);
                  graphics.FillRectangle(brush, rect);
                }
              }
            }
          }
        }
      }
    }*/


    /// <summary>
    /// Causes an event to be set back to the MainWindow via the event
    /// </summary>
    private static void PictureAvailable(Picture p)
    {
      try
      {
        OnPictureAvailable(p);
      }
      catch (Exception ex)
      {
        Dbg.Write(LogLevel.Error, "Picure = PictureAvailable - Exception: " + ex.Message);
      }
    }


    protected virtual void Dispose(bool disposing)
    {
      if (!disposedValue)
      {
        disposedValue = true;

        if (disposing)
        {
          _source?.Cancel();
          PictureBitmap?.Dispose();
          OriginalBitmap?.Dispose();
        }
      }
    }

    public void Dispose()
    {
      // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
      Dispose(disposing: true);
      GC.SuppressFinalize(this);
    }

  }

  public delegate void PictureHandlerDelegate(Picture p);
  public delegate void InterestingObjectsProcessedDelegate(Picture p);

  public enum PictureState
  {
    LoadingPicture,
    PictureLoaded,
    FileDoesNotExist,
    RedrawBitmap,
    LoadFailed,
    AnalyzingPicture,
    AINotFound,
    PictureAnalyzed,
    Canceled
  }

  public enum PictureTypes
  {
    File,
    Scanned,  // when scanning camera for motion
    Snapshot, // snapshot & continous (never analyzed)
    Error     // no pictures available
  }




}
