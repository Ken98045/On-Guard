using System;
using System.Collections.Generic;

namespace SAAI
{

/// <summary>
/// A class to hold email addresses and the notification options for
/// each email address.  In the future the notification options may be
/// related to the Area of Interest rather than the email address.
/// </summary>
  [Serializable]
  public class EmailOptions
  {
    public bool Active { get; set; }          // Currently does nothing - may be used to turn on/off email activations
    public string EmailAddress { get; set; }
    public int NumberOfImages { get; set; }
    public bool AllTheTime { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public bool[] DaysOfWeek;
    public int SizeDownToPercent { get; set; }  // Reduce the sizeof any images

    public EmailCooldown CoolDown { get; set; }

    public EmailOptions(string emailAddress, int coolDown)
    {
      EmailAddress = emailAddress;
      CoolDown = new EmailCooldown(coolDown);
      StartTime = new DateTime(2020, 1, 1, 0, 0, 0); // the value is a place holder so the first occurs
      EndTime = new DateTime(2020, 1, 1, 0, 0, 0);  // the value is a place holder so the first occurs.
      DaysOfWeek = new bool[7];

      SizeDownToPercent = 100;
    }

    public EmailOptions()
    {
      EmailAddress = string.Empty;
      CoolDown = new EmailCooldown(1);
      StartTime = new DateTime(2020, 1, 1, 0, 0, 0);  // the value is a place holder so the first occurs
      EndTime = new DateTime(2020, 1, 1, 0, 0, 0);    // the value is a place holder so the first occurs
      DaysOfWeek = new bool[7];
      SizeDownToPercent = 100;
    }

  }

  /// <summary>
  /// Url options just keeps the url and a flage whether the URL is "active"
  /// Right now URLs can be active or inactive. 
  /// </summary>
  [Serializable]
  public class UrlOptions
  {
    public string Url { get; set; }
    public bool Active { get; set; }

    public UrlCooldown CoolDown { get; set; }

    public UrlOptions(string url, int coolDown)
    {
      Url = url;
      CoolDown = new UrlCooldown(coolDown);
    }
  }


  /// <summary>
  /// AreaNotificationOption holds lists of both
  /// URL and Email options for an Area of Interest
  /// </summary>
  [Serializable]
  public class AreaNotificationOption
  {
    public List<UrlOptions> Urls { get; }
    public List<string> Email { get; }

    public AreaNotificationOption()
    {
      Urls = new List<UrlOptions>();
      Email = new List<string>();
    }
  }
}
