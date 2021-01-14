using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace SAAI
{
/// <summary>
/// Just a wrapper that holds a list of the available email addresses (along with the related time/dow restrictions
/// Provides a wrapper for persistence.
/// </summary>
  [Serializable]
  public sealed class EmailAddresses
  {

    public static List<EmailOptions> EmailAddressList { get; set; }

    static EmailAddresses()
    {
      EmailAddressList = new List<EmailOptions>();
      Load();
    }

    static public EmailOptions GetEmailOptions(string emailAddress)
    {
      EmailOptions opt = null;
      opt = EmailAddressList.Find(x => emailAddress == x.EmailAddress);
      return opt;
    }

    public static void Save()
    {
      Storage.SaveEmailAddresses(EmailAddressList);
    }

    public static void Load()
    {
      EmailAddressList = Storage.GetEmailAddresses();
    }
  }
}
