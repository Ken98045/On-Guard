using Microsoft;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using OnGuardCore.Src.Properties;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using System.Resources;
using System.IO;
using System.Reflection;

namespace OnGuardCore
{
  public partial class HelpBox : Form
  {
    public HelpBox(string title, Size size, string helpFileName)
    {
      InitializeComponent();

      this.Size = size;

      // Microsoft Sans Serif; bold 10
      Font font = new ("Microsoft Sans Serif", 10.0F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      Size strSize = TextRenderer.MeasureText(title, font);
      TitleLabel.Location = new Point(this.Width/2 - (strSize.Width)/2, 20);
      TitleLabel.Text = title;
      OKButton.Location = new Point(size.Width / 2 - OKButton.Width / 2, ClientRectangle.Height - OKButton.Height - 5);

      richTextBoxHelp.SelectAll();

      this.richTextBoxHelp.SelectAll();

      string resName = "OnGuardCore.Resources.HelpFiles." + helpFileName;
      var assembly = Assembly.GetExecutingAssembly();

      using Stream stream = assembly.GetManifestResourceStream(resName);
      using StreamReader reader = new (stream);
      richTextBoxHelp.SelectedRtf = reader.ReadToEnd();

    }
  }
}
