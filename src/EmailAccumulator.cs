using OnGuardCore.Src.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Collections;

namespace OnGuardCore
{

  /// <summary>
  /// A class to accumulate pictures over time in order to be able to send multiple pictures
  /// with one email and to allow multiple Area of Interest descriptions in on email.
  /// </summary>
  public class EmailAccumulator : FrameAccumulator
  {

    static AwaitableQueue<EmailInfo> _emailQueue = new(0);

    public EmailAccumulator(int timeToAccumulate)
    {
      Init(timeToAccumulate);
      EmailInit();
    }


    public void EmailInit()
    {
      Task.Run(() => SendEmailFromQueueAsync());
    }


    // Here we have a list of frames (sorted in picture date/time).
    // We have all the information necessary to actually send the emails, so we
    // might as well do it here.
    // We may have multiple email recipients.  Each email recipient may want 0 to many pictures attached.
    // We may have many more frames than the recipient wants.  In that case we first sort out the 
    // interesting ones.  We always start an email with the first interesting picture.  From there
    // the following ones may or may not be interesting.  The ones with the highest priority (type Door)
    // are included before others (in the limited email space).  From there we prefer interesting
    // pictures.  If we have room we include the others..
    // Note type frames list is in sorted order since it was copied from a SortedList
    public override void ProcessAccumulatedFrames(List<Frame> frames)
    {
      // The priority and interesting list contain indexes into the frames list
      List<int> priority = new();     // door events have high priority, everything else, not
      List<int> interesting = new();  // frames with objects but not "priority

      Dbg.Trace("EmailAccumulator - Done accumulating email frames with: " + frames.Count.ToString());

      // The collection of area descriptions does not depend on the number of outgoing pictures.
      // It depends on all the pictures.  Each picture may have zero or more than, each object may
      // be in a different area. Only frames with Interesting Objects have areas, and therefore descriptions
      HashSet<string> descriptions = new();

      // First, let's get lists of priority and interesting indexes
      int i = 0;
      foreach (var frame in frames)
      {
        if (frame.Interesting != null && frame.Interesting.Count > 0)
        {
          foreach (var io in frame.Interesting)
          {
            descriptions.Add(io.Area.AOIName + ": " + io.Label);
            if (io.Area.AOIType == AOIType.Door)
            {
              priority.Add(i);
              break;
            }
            else
            {
              if (!priority.Contains(i))  // a frame may have interesting and priority objects, but only add it to one list
              {
                descriptions.Add(io.Area.AOIName + ": " + io.Label);
                interesting.Add(i);
              }
            }
          }
        }

        i++;
      }

      // This is out of place codewise, but....
      if (priority.Count > 0)
      {
        // signal the camera to wait the full interval regardless of door events in following frame since we already reported a door object
        frames[0].Item.CamData.LastAccumulateType = AOIType.Door;
      }
      else
      {
        frames[0].Item.CamData.LastAccumulateType = AOIType.IgnoreObjects; // respect the email interval
      }

      // Now, let's get the list of email addresses to send to based on time of day, day of week, normally just 1 to a small number
      Dictionary<string, string> emailAddresses = new();

      // Yes, these could be combined, but for debugging we look at them separately
      // Go through the "priority"/door frames we already selected and add the related email addresses

      foreach (int index in priority)
      {
        foreach (var ii in frames[index].Interesting)
        {
          if (null != ii.Area.Notifications && null != ii.Area.Notifications.Email)
          {
            foreach (var email in ii.Area.Notifications.Email)
            {
              emailAddresses[email] = email;
            }
          }
        }
      }

      // Go through the "interesting "non-door" frames we already selected and add the related email addresses
      foreach (int index in interesting)
      {
        foreach (var ii in frames[index].Interesting)
        {
          foreach (var email in ii.Area.Notifications.Email)
          {
            emailAddresses[email] = email;
          }
        }
      }


      // Now, go through all email addresses to see if we are in a period we would at least consider sending emails to
      bool removedOne;
      do
      {
        removedOne = false;

        foreach (string emailAddress in emailAddresses.Values)
        {
          bool timeOK = CheckEmailTODDOW(emailAddress);
          if (!timeOK)
          {
            emailAddresses.Remove(emailAddress);
            removedOne = true;
            break;  // go through the entire list again - it may have changed (not the most efficient, but a small list so....
          }
        }

      } while (emailAddresses.Count > 0 && removedOne);

      Dbg.Trace("EmailAccumulator - Email address count before cooldown check: " + emailAddresses.Count.ToString());

      // ok, we know that we MAY want to notify some email address, but each
      // address may have a different cool down time, so we cull the list further (yes we could do it differently)
      do
      {
        removedOne = false;

        foreach (string emailAddress in emailAddresses.Values)
        {
          EmailOptions option = EmailAddresses.GetEmailOptions(emailAddress);
          if (null != option)
          {
            TimeSpan span = DateTime.Now - option.CoolDown.LastSent;
            if (span.TotalMinutes < option.CoolDown.CooldownTime)
            {
              Dbg.Write("Email address in cool down: " + emailAddress);
              emailAddresses.Remove(emailAddress);
              removedOne = true;
              break;  // go through the entire list again - it may have changed (not the most efficient, but a small list so....)
            }
          }
        }

      } while (emailAddresses.Count > 0 && removedOne);

      Dbg.Trace("EmailAccumulator - Email address count after cooldown check: " + emailAddresses.Count.ToString());

      // OK, we have FINALLY culled the list of email addreses to send to.
      // Now, we need to go through email recipients and then select the frames we want to send and then
      // send them.
      SortedList<DateTime, Frame> outgoing = new();

      foreach (string addr in emailAddresses.Values)
      {
        Dbg.Trace("EmailAccumulator - ProcessAccumlatedFrames - Getting frames for email address: " + addr + " -- total frames: " + frames.Count.ToString());
        outgoing.Clear();

        EmailOptions opt = EmailAddresses.GetEmailOptions(addr);
        if (null != opt)
        {

          // The follwing is done the way it is done for debugging.  
          int maxPic = opt.NumberOfImages;
          if (priority.Count >= maxPic)
          {

            // No decisions to make, just use priority until reached the max (debugging)
            for (i = 0; i < maxPic; i++)
            {
              outgoing.Add(frames[priority[i]].Timestamp, frames[priority[i]]);
            }
          }
          else
          {

            // Here we have some decisions to make.  First add priority frames
            for (i = 0; i < priority.Count; i++)
            {
              outgoing[frames[priority[i]].Timestamp] = frames[priority[i]];
            }


            // In addition to the priority, add frames with "interesting" objects
            for (i = 0; i < interesting.Count && outgoing.Count < maxPic; i++)
            {
              outgoing[frames[interesting[i]].Timestamp] = frames[interesting[i]];
            }


            // OK, we had some space left after the priority and interesting frames
            // If there ares some frames remaining, add from the beginning of the frames.
            // Note that the ones at the beginning of the frame list that aren't priority or
            // interesting will be favored over the ones later in the list.  This may or may not be 
            // good thing.  That is, you may want to favor picures of people approaching the door
            // over pictures of them leaving.  You are more likely to get faces for one.
            for (i = 0; i < frames.Count && outgoing.Count < maxPic; i++)
            {
              if (!(priority.Contains(i)) && !(interesting.Contains(i)))  // No duplication of the ones we added
              {
                outgoing.Add(frames[i].Timestamp, frames[i]);
              }

            }
          } // end else
        } // end we do have an option (which we should)

        Dbg.Trace("EmailAccumulator - ProcessAccumlatedFrames - Number of frames to send: " + outgoing.Count.ToString());

        // We copy off the list of files and the list of descriptions because we are
        // going to clear these lists for the next email address
        string[] theFiles = new string[outgoing.Count]; // also, we may be resizing the images
        int count = 0;
        foreach (Frame frame in outgoing.Values)
        {
          theFiles[count] = frame.Item.PendingFile;
          ++count;
        }

        string[] theDescriptions = new string[descriptions.Count];
        descriptions.CopyTo(theDescriptions);


        // OK, here we have collected all the frames for this email address.
        // It is time to resize the pictures if necessary.  Resizing is based on the email
        // address since photos going to a phone should be smaller than those going to a PC, etc.

        count = 0;
        double totalSize = 0;
        List<string> outputFiles = new();

        foreach (string file in theFiles)
        {
          string outFile = theFiles[count];
          if (opt.SizeDownToPercent != 100)
          {
            outFile = ResizeImage(theFiles[count], opt.SizeDownToPercent);
          }

          if (null != outFile)
          {
            FileInfo fi = new(outFile);
            totalSize += fi.Length;

            if (totalSize < (double)opt.MaximumAttachmentSize * 1000.0 * 1000.0)
            {
              outputFiles.Add(outFile);
              ++count;
            }
            else
            {
              Dbg.Write("EmailAccumulator - ProcessAccumulatedFrames - Email attachement size limit reached" + outFile + " " + count.ToString());
              break;
            }
          }
          else
          {
            Dbg.Write("EmailAccumulator - ProcessAccumulatedFrames - Unable to create resized picture for: " + file);
          }
        }

        // the files has both resized and not resized files
        Task.Run(() => SendEmail(addr, outputFiles.ToArray(), theDescriptions));
      }
    }


    /// <summary>
    /// Check the email agains the time of day and day of week criteria
    /// </summary>
    /// <returns></returns>
    static bool CheckEmailTODDOW(string emailAddress)
    {
      bool result = false;
      EmailOptions option = EmailAddresses.GetEmailOptions(emailAddress);

      if (null != option)
      {
        DateTime now = DateTime.Now;

        if (option.AllTheTime)
        {
          result = true;
        }
        else
        {
          // First check the day of week
          int day;
          for (day = 0; day < 7; day++)
          {
            if (option.DaysOfWeek[day])
            {
              if (day == (int)now.DayOfWeek)
              {
                break;
              }
            }
          }

          if (day < 7)
          {
            // OK, the day was correct.  Let's look at the time.  Can't just compare DateTime because we never look at the date
            if (now.Hour == option.StartTime.Hour)
            {
              // need to check minutes too
              if (now.Minute >= option.StartTime.Minute)
              {
                result = true;  // tentative
              }

              if (option.EndTime.Minute > now.Minute)
              {
                result = false; // It was greater than start, but also greater than end - unusual, but....
              }
            }
            else if (now.Hour > option.StartTime.Hour)
            {
              result = true;
            }
            else { } // less than remains false

          }
        }
      }

      Dbg.Trace("EmailAccumulator - CheckEmailTODDOW - EmailAddress: " + emailAddress + " Result: " + result.ToString());

      return result;
    }


    // The picture may not have been closed yet.  So, get the bitmap if possible, if not, wait a bit and try again
    private static Bitmap GetBitmap(string fileName)
    {
      bool continueTrying;
      const int maxTries = 200;
      int tryCount = 0;

      Bitmap bitmap = null;

      do
      {
        continueTrying = true;

        try
        {
          // We need to open the file anyway, sow we might as well make a bitmap and get the resolution of the underlying file
          bitmap = new Bitmap(fileName); // May fail if the file is still open.  There is no other (good) way to tell if the file is still being written to
          continueTrying = false;
        }
        catch (IOException)
        {
          continueTrying = true;
          Thread.Sleep(50);

          tryCount++;
          if (tryCount > maxTries)
          {
            continueTrying = false;
          }

        }
        catch (Exception ex)
        {
          Dbg.Write("EmailAccumulator - GetBitmap Unexpected Exception: " + ex.Message);
          continueTrying = false;
        }
      } while (continueTrying);

      return bitmap;
    }


    public static string ResizeImage(string fileName, int scaleFactor)
    {
      string destFile = string.Empty;
      try
      {
        if (File.Exists(fileName))
        {

          destFile = Path.GetDirectoryName(fileName) + "\\Resized-" + DateTime.Now.Ticks.ToString() + ".jpg"; ;
          using Image image = GetBitmap(fileName);
          if (null != image)
          {

            int width = (int)(image.Width * (double)scaleFactor / 100.0);
            int height = (int)(image.Height * (double)scaleFactor / 100.0);

            var destRect = new Rectangle(0, 0, width, height);
            using var destImage = new Bitmap(width, height);

            destImage.SetResolution(width, height);

            using (var graphics = Graphics.FromImage(destImage))
            {
              graphics.CompositingMode = CompositingMode.SourceCopy;
              graphics.CompositingQuality = CompositingQuality.HighQuality;
              graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
              graphics.SmoothingMode = SmoothingMode.HighQuality;
              graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

              using var wrapMode = new ImageAttributes();
              wrapMode.SetWrapMode(WrapMode.TileFlipXY);
              graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
            }

            destImage.Save(destFile);
          }
        }
      }
      catch (Exception ex)
      {
        string err = "EmailAccumulator - There was an error attempting to create a resized image for file: " + fileName + " at scale factor: " + scaleFactor.ToString() + Environment.NewLine + ex.Message;
        Dbg.Write(err);
      }

      return destFile;

    }


    // Sends an email to a recipient with attached pictures & descriptions.
    // No longer sending async because some email servers choke when multiple requests are submitted.
    // Thanks Comcast!  (They say you can have 25 open requests, but more than 3 results in an error).
    private static void SendEmail(string emailRecipient, string[] frames, string[] activityDesc)
    {

      MailMessage mail;

      EmailOptions option = EmailAddresses.GetEmailOptions(emailRecipient);

      // There area 2 different email formats we use.  
      if (option.InlinePictures)
      {
        // This format puts the pictures in the body of the email using an HTML format.
        // Most email clients can display these
        mail = BuildInlineMessage(frames, activityDesc);
      }
      else
      {
        // MMS clients (and others) may not be able to handle HTML fomattted mail message.
        // For these we just attach the images and hope for the best.
        mail = BuildAttachmentMessage(frames, activityDesc);
      }

      mail.To.Add(emailRecipient);

      EmailInfo emailInfo = new(mail, frames);
      Dbg.Trace("Enqueued for sending email to: " + emailRecipient);
      _emailQueue.Add(emailInfo);
    }

    static MailMessage BuildAttachmentMessage(string[] frames, string[] activityDesc)
    {
      MailMessage mail = new();
      mail.BodyEncoding = Encoding.UTF8;
      mail.IsBodyHtml = true;

      foreach (var desc in activityDesc)
      {
        mail.Body += desc + Environment.NewLine;
      }

      System.Net.Mail.Attachment attachment;
      foreach (var frame in frames)
      {
        attachment = new System.Net.Mail.Attachment(frame);
        mail.Attachments.Add(attachment);
      }

      return mail;
    }

    static MailMessage BuildInlineMessage(string[] frames, string[] activityDesc)
    {
      MailMessage mail = new();
      mail.BodyEncoding = Encoding.UTF8;
      mail.IsBodyHtml = true;

      string htmlOut = "<html><body>";

      foreach (var desc in activityDesc)
      {
        htmlOut += desc + "<br>";
      }

      htmlOut += "<br>";

      System.Net.Mail.Attachment attachment;
      // Create the HTML view

      // Form the inline html
      int j = 0;
      foreach (var frame in frames)
      {
        string imageStr = string.Format(@"<img src='cid:Picture{0}' <br><br>", j);  // width={1} height={2}  , resize.width, resize.height)
        htmlOut += imageStr;
        j++;
      }

      htmlOut += @"</body> </html>";


      AlternateView htmlView = AlternateView.CreateAlternateViewFromString(
                                                   htmlOut,
                                                   Encoding.UTF8,
                                                   System.Net.Mime.MediaTypeNames.Text.Html);


      int i = 0;
      string mediaType = MediaTypeNames.Image.Jpeg;

      foreach (var frame in frames)
      {
        LinkedResource img = new LinkedResource(frame, mediaType);
        img.ContentId = string.Format("Picture{0}", i);
        img.ContentType.Name = img.ContentId;
        img.ContentLink = new Uri("cid:" + img.ContentId);
        img.ContentType.MediaType = mediaType;
        img.TransferEncoding = TransferEncoding.Base64;
        htmlView.LinkedResources.Add(img);
        i++;
      }

      mail.AlternateViews.Add(htmlView);
      mail.IsBodyHtml = true;


      return mail;
    }

    private static async Task SendEmailFromQueueAsync()
    {
      string emailUserName = Storage.Instance.GetGlobalString("EmailUser");
      string emailPassword = Storage.Instance.GetGlobalString("EmailPassword");

      while (true)
      {
        EmailInfo emailInfo = await _emailQueue.GetAsync();
        MailMessage mail = emailInfo.Mail;
        if (mail == null)
        {
          break;
        }

        try
        {

          EmailOptions option = EmailAddresses.GetEmailOptions(mail.To[0].Address);

          Dbg.Trace("EmailAccumulator - Starting email send to: " + mail.To[0].Address);

          using (SmtpClient SmtpServer = new(Storage.Instance.GetGlobalString("EmailServer")))
          {
            mail.From = new MailAddress(emailUserName);
            mail.Subject = "Security Camera Alert";   // todo get via ui
            SmtpServer.Port = Storage.Instance.GetGlobalInt("EmailPort");

            if (!string.IsNullOrEmpty(emailUserName))
            {
              SmtpServer.Credentials = new System.Net.NetworkCredential(emailUserName, emailPassword);
            }

            SmtpServer.EnableSsl = Storage.Instance.GetGlobalBool("EmailSSL");
            SmtpServer.Timeout = 180 * 1000;
            SmtpServer.Send(mail);
            Dbg.Write("Email sent to: " + mail.To[0].Address);
          }
        }
        catch (SmtpException ex)
        {
          Dbg.Write("Email exception: " + ex.ToString());
        }

        mail.Dispose();


        foreach (var file in emailInfo.Frames)
        {
          try
          {
            File.Delete(file);  // get rid of the temporary files
          }
          catch (Exception ex)
          {
            Dbg.Write("EmailAccumulator - Error deleting email temporary file: " + file);
          }
        }

        Thread.Sleep(10_000);
      }
    }
  }

  internal class EmailInfo
  {
    public EmailInfo(MailMessage mail, string[] frames)
    {
      Mail = mail;
      Frames = frames;
    }

    public MailMessage Mail { get; }
    public string[] Frames { get; }
  }

}

