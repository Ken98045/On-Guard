using OnGuardCore.Src.Properties;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace OnGuardCore
{
  public class GridDefinition
  {
    public Guid ID { get; }
    private BitArray _array;
    public int XDim { get; set; }
    public int YDim { get; set; }
    public BitArray Bits { get => _array; set => _array = value; }

    public GridDefinition(int dimension1, int dimension2)
    {
      XDim = dimension1 > 0 ? dimension1 : throw new ArgumentOutOfRangeException(nameof(dimension1), dimension1, string.Empty);
      YDim = dimension2 > 0 ? dimension2 : throw new ArgumentOutOfRangeException(nameof(dimension2), dimension2, string.Empty);
      Bits = new BitArray(dimension1 * dimension2);
      ID = Guid.NewGuid();
    }

    public GridDefinition(GridDefinition src)
    {
      XDim = src.XDim;
      YDim = src.YDim;
      Bits = new BitArray(src.Bits);
      ID = src.ID;
    }

    // returns a new AreaDefinition with all of the set bits merged together.
    // This is primarily used for the display of all areas in an image
    public static GridDefinition MergeAreas(GridDefinition area1, GridDefinition area2)
    {
      GridDefinition merged = new GridDefinition(area1.XDim, area1.YDim);
      merged.Bits = area1.Bits;
      merged.Bits.Or(area2.Bits);
      return merged;
    }

    public bool Get(int x, int y) { CheckBounds(x, y); return Bits[y * XDim + x]; }
    public bool Set(int x, int y, bool val) { CheckBounds(x, y); return Bits[y * XDim + x] = val; }
    public bool this[int x, int y] { get { return Get(x, y); } set { Set(x, y, value); } }

    private void CheckBounds(int x, int y)
    {
      if (x < 0 || x >= XDim)
      {
        throw new IndexOutOfRangeException();
      }
      if (y < 0 || y >= YDim)
      {
        throw new IndexOutOfRangeException();
      }
    }

    public void Clear()
    {
      for (int row = 0; row < YDim; row++)
      {
        for (int col = 0; col < XDim; col++)
        {
          Set(col, row, false);
        }
      }
    }

    private static string BuildPath(string fileName)
    {
      string path = Settings.Default.DataFileLocation;
      if (!string.IsNullOrEmpty(path))
      {
        path = Path.Combine(path, "AreaDefinitions");

        if (!Directory.Exists(path))
        {
          Directory.CreateDirectory(path);
        }

        // Change problematic file names into something reasonable
        fileName = Regex.Replace(fileName, @"[<>:/\\|?*""]", "-");
        path = Path.Combine(path, fileName + ".dat");
      }
      else
      {
        throw new Exception("AreaDefinition - The default file location was not set.  Check your Application Settings!");
      }

      return path;
    }

    public void Save(string fileName)
    {
      string path = BuildPath(fileName);

      byte[] byteArray = new byte[Bits.Length / 8 + 1];
      Bits.CopyTo(byteArray, 0);

      using (BinaryWriter writer = new BinaryWriter(File.OpenWrite(path)))
      {
        writer.Write(XDim);
        writer.Write(YDim);
        writer.Write(byteArray);
      }
    }


    public static void Delete(string fileName)
    {
      string path = BuildPath(fileName);

      if (!string.IsNullOrEmpty(path))
      {
        if (File.Exists(path))
        {
          File.Delete(path);
        }
      }
    }

    // Load the area definition file.
    public bool Load(string fileName)
    {
      bool result = false;
      string path = BuildPath(fileName);

      if (File.Exists(path))
      {
        using (BinaryReader reader = new BinaryReader(File.OpenRead(path)))
        {
          XDim = reader.ReadInt32();
          YDim = reader.ReadInt32();

          FileInfo fi = new FileInfo(path);
          byte[] fileBytes = reader.ReadBytes((int)fi.Length - sizeof(int) * 2);
          Bits = new BitArray(fileBytes);
        }

        result = true;
      }

      return result;
    }

  }
}
