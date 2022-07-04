using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnGuardCore
{
  public class PictureMotionInfo
  {
    public PictureMotionInfo(string uniqueName, string fileName, string path, string camera, DateTime pictureTime)
    {
      UniqueName = uniqueName;
      FileName = fileName;
      Path = path;
      Camera = camera;
      PictureTime = pictureTime;
    }

    [Key]
    [Required]
    public string UniqueName { get; set; }

    [Required]
    [MaxLength(256)]
    public string FileName { get; set; }  // The name of the file without path

    [Required]
    [MaxLength(2056)]
    public string Path { get; set; }  // The path without name

    [Required]
    [MaxLength(100)]
    public string Camera { get; set; }

    [Required]
    public DateTime PictureTime { get; set; }
  }
}
