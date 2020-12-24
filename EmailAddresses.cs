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
      BinaryFormatter serializer = new BinaryFormatter();
      using (Stream stream = new FileStream(Storage.GetFilePath("EmailAddresses.bin"), FileMode.Create))
      {
        serializer.Serialize(stream, EmailAddressList);
      }

    }

    public static void Load()
    {
      string fileName = "EmailAddresses.bin";
      string path = Storage.GetFilePath(fileName);
      bool exists = false;
      bool redirected = false;

      if (File.Exists(path))
      {
        exists = true;
      }
      else if (File.Exists(fileName))
      {
        exists = true;  // The old file location
        redirected = true;
        path = fileName;
      }

      if (exists)
      { 
        BinaryFormatter serializer = new BinaryFormatter();
        using (Stream reader = new FileStream(path, FileMode.Open))
        {
          EmailAddressList = (List<EmailOptions>)serializer.Deserialize(reader);
        }

        if (redirected)
        {
          Save(); // Re-save in the new location
        }
      }
    }

  }
}
