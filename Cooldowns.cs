using System;

namespace SAAI
{

  [Serializable]
  public class CooldownTracker
  {
    public int CooldownTime { get; set; }  // Copied from AOI (changeable from UI?

    public DateTime LastSent { get; set; }

    // Determies whether you should notify or not.
    // AND, since we wouldn't be asking whether we should notify unless we intend to notify
    // we also set the LastSent time.  
    public virtual bool CooldownExpired()
    {
      bool notify = false;

      TimeSpan elapsed = DateTime.Now - LastSent;
      if (elapsed.TotalSeconds >= CooldownTime)
      {
        notify = true;
      }
      return notify;
    }

    public virtual void Reset()
    {
      LastSent = DateTime.Now;
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
      LastSent = DateTime.Now - TimeSpan.FromHours(1);
    }

    public UrlCooldown(UrlCooldown src)
    {
      CooldownTime = src.CooldownTime;
      LastSent = src.LastSent;  // TODO: remove
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
      LastSent = DateTime.Now - TimeSpan.FromHours(1);
    }

    public EmailCooldown(EmailCooldown src)
    {
      CooldownTime = src.CooldownTime;
      LastSent = src.LastSent;
    }


    public double TimeSinceSend()
    {
      TimeSpan rem = DateTime.Now - LastSent;
      return rem.TotalMinutes;
    }

    public override bool CooldownExpired()
    {
      bool notify = false;

      TimeSpan elapsed = DateTime.Now - LastSent;
      if (elapsed.TotalMinutes >= CooldownTime)
      {
        notify = true;
      }
      return notify;
    }
  }
}
