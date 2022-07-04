using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnGuardCore
{
  public class MotionDBContext : DbContext
  {
    static string s_connectionString;
    static bool s_setWalMode = false;

    public static void SetupDatabase(string dbPath)
    {
      s_connectionString = $@"Data Source={dbPath}\MotionInfo.db";

      bool exists = DoesMotionDatabaseExist($@"{dbPath}\MotionInfo.db");
      if (!exists)
      {
        CreateMotionDatabase();
      }
    }

    public MotionDBContext()
    {
      if (!s_setWalMode)
      {
        using var connection = this.Database.GetDbConnection();
        connection.Open();
        using (var command = connection.CreateCommand())
        {
          command.CommandText = "PRAGMA journal_mode=WAL;";
          command.ExecuteNonQuery();
        }
      }
    }


    protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
    {
      dbContextOptionsBuilder.UseSqlite(s_connectionString);
    }

    public DbSet<PictureMotionInfo> MotionInfo { get; set; }

    public static void CreateMotionDatabase()
    {
      try
      {
        using SqliteConnection con = new(s_connectionString);
        con.Open();
        using SqliteCommand cmd = con.CreateCommand();

        cmd.CommandText = "CREATE TABLE MotionInfo " +
        "(UniqueName VARCHAR(100) PRIMARY KEY DESC, " +
        "FileName VARCHAR(256), " +
        "Path VARCHAR(2056), " +
        "Camera VARCHAR(100), " +
        "PictureTime DATETIME);";

        cmd.ExecuteNonQuery();

        cmd.CommandText = "CREATE UNIQUE INDEX idxReverseUniqueName on  MotionInfo (UniqueName ASC);";
        cmd.ExecuteNonQuery();
      }
      catch (Exception ex)
      {
        Dbg.Write(LogLevel.Error, "Exception - MotionDatabase - CreateMotionDatabase: " + ex.Message);
      }
    }

    public static bool DoesMotionDatabaseExist(string dbPath)
    {
      bool result = false;

      if (System.IO.File.Exists(dbPath))
      {
        result = true;

        using SqliteConnection con = new(s_connectionString);
        con.Open();

        try
        {
          string query = "SELECT name FROM sqlite_master WHERE type='table' AND name='MotionInfo';";
          using SqliteCommand cmd = con.CreateCommand();
          cmd.CommandText = query;
          var queryResult = cmd.ExecuteScalar();
          if (null != queryResult)
          {
            result = true;
          }
        }
        catch (Exception ex)
        {
          result = false;
        }
      }
      return result;
    }
  }
}


