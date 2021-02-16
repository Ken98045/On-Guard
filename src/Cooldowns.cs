using System;

namespace OnGuardCore
{

  [Serializable]
  public class CooldownTracker
  {
    public int CooldownTime { get; set; }  // Copied from AOI 

    public DateTime LastSent { get; set; }

    internal object _lock = new object();

    // Determies whether you should notify or not.
    // AND, since we wouldn't be asking whether we should notify unless we intend to notify
    // we also set the LastSent time.  
    public virtual bool CooldownExpired()
    {
      bool notify = false;

      lock (_lock)
      {
        TimeSpan elapsed = DateTime.Now - LastSent;
        if (elapsed.TotalSeconds >= CooldownTime)
        {
          // Dbg.Write("CooldownTracker CountdownExpired: " + elapsed.TotalSeconds.ToString());
          notify = true;
          Reset();
        }
        else
        {
          // Dbg.Write("CooldownTracker CooldownExpired - NOT Expired: " + elapsed.TotalSeconds.ToString());
        }
      }

      return notify;
    }

    public virtual void Reset()
    {
      // Dbg.Write("Cooldown reset");
      lock (_lock)
      {
        LastSent = DateTime.Now - TimeSpan.FromSeconds(1);  // put it in the past just a bit to prevent resend
      }
    }

  }

  /// <summary>
  /// There is only one cooldown timer per camera, per area of interest.  We do keep a dictionary of them
  /// because it is cheap to do so, and easier.
  /// The UrlCooldown isn't as critical as email because it doesn't hurt much to have notifications
  /// as each AOI is triggered.
  /// </summary>
  /// 

  [Serializable]
  public class UrlCooldown : CooldownTracker
  {

    public UrlCooldown(int cooldown)
    {
      CooldownTime = cooldown;
      LastSent = DateTime.Now - TimeSpan.FromHours(1);  // make it far in the past to ensure the first trigger
    }

    public UrlCooldown(UrlCooldown src)
    {
      CooldownTime = src.CooldownTime;
      LastSent = src.LastSent;  // make it far in the past to ensure the first trigger
    }

    public int TimeSinceSend()
    {
      TimeSpan rem = DateTime.Now - LastSent;
      return (int)rem.TotalSeconds;
    }
  }


  /// <summary>
  /// There is only one MQTT cooldown timer per camera, per area of interest.  We do keep a dictionary of them
  /// because it is cheap to do so, and easier.
  /// </summary>
  /// 

  [Serializable]
  public class MQTTCoolDown : CooldownTracker
  {

    public MQTTCoolDown(int cooldown)
    {
      CooldownTime = cooldown;
      LastSent = DateTime.Now - TimeSpan.FromHours(2);  // make it far in the past to ensure the first trigger
    }

    public MQTTCoolDown(UrlCooldown src)
    {
      CooldownTime = src.CooldownTime;
      LastSent = src.LastSent - TimeSpan.FromHours(2);  // make it far in the past to ensure the first trigger
    }

    public int TimeSinceSend()
    {
      TimeSpan rem = DateTime.Now - LastSent;
      return (int)rem.TotalSeconds;
    }
  }



  /// <summary>
  /// The Email and Url cooldown classes are separate because the functionality may change
  /// </summary>
  /// 

  [Serializable]
  public class EmailCooldown : CooldownTracker
  {

    public EmailCooldown(int cooldown)
    {
      CooldownTime = cooldown;
      LastSent = DateTime.Now - TimeSpan.FromHours(2);
    }

    public EmailCooldown(EmailCooldown src)
    {
      CooldownTime = src.CooldownTime;
      LastSent = src.LastSent - TimeSpan.FromHours(2);  // make it far in the past to ensure the first trigger
    }


    public double TimeSinceSend()
    {
      TimeSpan rem = DateTime.Now - LastSent;
      return rem.TotalMinutes;
    }

    public override bool CooldownExpired()
    {
      bool notify = false;

      lock (_lock)
      {
        TimeSpan elapsed = DateTime.Now - LastSent;
        if (elapsed.TotalMinutes >= CooldownTime)
        {
          notify = true;
          Reset();
        }
        else
        {
        }
      }
      return notify;
    }
  }
}
