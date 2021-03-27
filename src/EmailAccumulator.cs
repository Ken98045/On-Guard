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

namespace OnGuardCore
{

  /// <summary>
  /// A class to accumulate pictures over time in order to be able to send multiple pictures
  /// with one email and to allow multiple Area of Interest descriptions in on email.
  /// </summary>
  public class EmailAccumulator : FrameAccumulator
  {

    static AwaitableQueue<EmailInfo> _emailQueue = new AwaitableQueue<EmailInfo>(0);

    public EmailAccumulator(int timeToAccumulate)
    {
      Init(timeToAccumulate);
      EmailInit();
    }


    public async Task EmailInit()
    {
      Task.Run(() => SendEmailFromQueue());
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
    public override async Task ProcessAccumulatedFrames(List<Frame> frames)
    {
      // The priority and interesting list contain indexes into the frames list
      List<int> priority = new List<int>();     // door events have high priority, everything else, not
      List<int> interesting = new List<int>();  // frames with objects but not "priority

      Dbg.Trace("EmailAccumulator - Done accumulating email frames with: " + frames.Count.ToString());

      // The collection of area descriptions does not depend on the number of outgoing pictures.
      // It depends on all the pictures.  Each picture may have zero or more than, each object may
      // be in a different area. Only frames with Interesting Objects have areas, and therefore descriptions
      HashSet<string> descriptions = new HashSet<string>();

      // First, let's get lists of priority and interesting indexes
      int i = 0;
      foreach (var frame in frames)
      {
        if (frame.Interesting != null && frame.Interesting.Count > 0)
        {
          foreach (var io in frame.Interesting)
          {
            descriptions.Add(io.Area.AOIName + ": " + io.FoundObject.Label);
            if (io.Area.AOIType == AOIType.Door)
            {
              priority.Add(i);
              break;
            }
            else
            {
              if (!priority.Contains(i))  // a frame may have interesting and priority objects, but only add it to one list
              {
                descriptions.Add(io.Area.AOIName + ": " + io.FoundObject.Label);
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
      Dictionary<string, string> emailAddresses = new Dictionary<string, string>();

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
      SortedList<DateTime, Frame> outgoing = new SortedList<DateTime, Frame>();

      foreach (string addr in emailAddresses.Values)
      {
        Dbg.Trace("EmailAccumulator - ProcessAccumlatedFrames - Getting frames for email address: " + addr + " -- total frames: " + frames.Count.ToString());
        outgoing.Clear();

        EmailOptions opt = EmailAddresses.GetEmailOptions(addr);
        if (null != opt)
        {

          // The follwing is done the way it is done for debugging.  
          // TODO: Reorganize
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
        Dbg.Trace("EmailAccumulator - ProcessAccumulatedFrames - Before resizing");

        count = 0;
        double totalSize = 0;
        List<string> outputFiles = new List<string>();

        foreach (string file in theFiles)
        {
          string outFile = theFiles[count];
          if (opt.SizeDownToPercent != 100)
          {
            outFile = ResizeImage(theFiles[count], opt.SizeDownToPercent);
          }

          FileInfo fi = new FileInfo(outFile);
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

        Dbg.Trace("EmailAccumulator - ProcessAccumulatedFrames - Before SendEmail - address: " + addr + " output files: " + outputFiles.Count.ToString());

        // theFiles has both resized and not resized files
        SendEmail(addr, outputFiles.ToArray(), theDescriptions);
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

    public static string ResizeImage(string fileName, int scaleFactor)
    {
      string destFile = string.Empty;
      try
      {
        if (File.Exists(fileName))
        {

          destFile = Path.GetDirectoryName(fileName) + "\\Resized-" + DateTime.Now.Ticks.ToString() + ".jpg"; ;
          using (Image image = Bitmap.FromFile(fileName))
          {

            int width = (int)(image.Width * (double)scaleFactor / 100.0);
            int height = (int)(image.Height * (double)scaleFactor / 100.0);

            var destRect = new Rectangle(0, 0, width, height);
            using (var destImage = new Bitmap(width, height))
            {

              destImage.SetResolution(width, height);

              using (var graphics = Graphics.FromImage(destImage))
              {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                  wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                  graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
              }

              destImage.Save(destFile);
            }
          }
        }
      }
      catch (Exception ex)
      {
        MessageBox.Show("EmailAccumulator - There was an error attempting to create a resized image for file: " + fileName + " at scale factor: " + scaleFactor.ToString() + Environment.NewLine + ex.Message, "Error Resizing Picture!"); 
      }

      return destFile;

    }


    // Sends an email to a recipient with attached pictures & descriptions.
    // No longer sending async because some email servers choke when multiple requests are submitted.
    // Thanks Comcast!  (They say you can have 25 open requests, but more than 3 results in an error).
    private static async Task SendEmail(string emailRecipient, string[] frames, string[] activityDesc)
    {

      MailMessage mail = null;

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

      EmailInfo emailInfo = new EmailInfo(mail, frames);
      Dbg.Trace("Enqueued for sending email to: " + emailRecipient);
      _emailQueue.Add(emailInfo);
    }

    static MailMessage BuildAttachmentMessage(string[] frames, string[] activityDesc)
    {
      MailMessage mail = new MailMessage();
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
      MailMessage mail = new MailMessage();
      mail.BodyEncoding = Encoding.UTF8;
      mail.IsBodyHtml = true;

      string htmlOut = "<!DOCTYPE HTML PUBLIC \"-//W3C//DTD HTML 4.0 Transitional//EN\">";
      htmlOut += "<HTML><HEAD><META http-equiv=Content-Type content=\"text/html; charset=iso-8859-1\"></HEAD>";
      htmlOut += "<BODY>";

      foreach (var desc in activityDesc)
      {
        htmlOut += desc + "<br>";
      }

      htmlOut += "<b>";
      htmlOut += "</b><br><br>";

      System.Net.Mail.Attachment attachment;
      int i = 0;

      foreach (var frame in frames)
      {
        attachment = new System.Net.Mail.Attachment(frame);
        attachment.ContentDisposition.DispositionType = DispositionTypeNames.Attachment;
        attachment.ContentType.Name = Path.GetFileName(frame);
        attachment.ContentDisposition.FileName = Path.GetFileName(frame);
        string contentID = string.Format("Picture{0}", i);
        attachment.ContentId = contentID;
        attachment.ContentType.MediaType = "image/jpg";
        mail.Attachments.Add(attachment);
        htmlOut += string.Format("<img src=\"cid:{0}\" alt=\"\"><br><br>", contentID);
        i++;
      }

      byte[] buffer;
      MemoryStream mem = null;

      buffer = Encoding.ASCII.GetBytes(htmlOut);
      mem = new MemoryStream(buffer);
      mem.Position = 0;
      AlternateView alternate = new AlternateView(mem, MediaTypeNames.Text.Html);
      mail.AlternateViews.Add(alternate);
      return mail;
    }

    private static async Task SendEmailFromQueue()
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

          using (SmtpClient SmtpServer = new SmtpClient(Storage.Instance.GetGlobalString("EmailServer")))
          {

            mail.From = new MailAddress(emailUserName);
            mail.Subject = "Security Camera Alert";   // todo get via ui
            SmtpServer.Port = Storage.Instance.GetGlobalInt("EmailPort");

            if (!string.IsNullOrEmpty(emailUserName))
            {
              SmtpServer.Credentials = new System.Net.NetworkCredential(emailUserName, emailPassword);
            }

            SmtpServer.EnableSsl = Storage.Instance.GetGlobalBool("EmailSSL");
            SmtpServer.Timeout = 120 * 1000;
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

