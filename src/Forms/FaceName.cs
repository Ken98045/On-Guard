using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnGuardCore
{
  public partial class FaceName : Form
  {
    public String NameOfPerson { get; set; }
    public string Person { get; set; }

    string _basePath;

    public FaceName()
    {
      InitializeComponent();

      _basePath = Storage.GetFilePath(string.Empty);
      _basePath = Path.Combine(_basePath, "Faces");
      if (!Directory.Exists(_basePath))
      {
        Directory.CreateDirectory(_basePath);
      }

      string[] existingNames = Directory.GetDirectories(_basePath);
      foreach (string nameDir in existingNames)
      {
        if (_basePath.Length < nameDir.Length)
        {
          string subDir = nameDir[(_basePath.Length + 1)..];
          FacesComboBox.Items.Add(subDir);
        }
      }

      if (FacesComboBox.Items.Count > 0)
      {
        FacesComboBox.SelectedIndex = 0;
      }

    }

    private void OKButton_Click(object sender, EventArgs e)
    {

      string person = string.Empty;
      if (FacesComboBox.SelectedIndex != -1)
      {
        person = (string)FacesComboBox.SelectedItem;
      }
      else if (!string.IsNullOrEmpty(FacesComboBox.Text))
      {
        person = (string)FacesComboBox.Text;
      }

      if (!string.IsNullOrEmpty(person))
      {
        string fullPath = Path.Combine(_basePath, person);
        if (!Directory.Exists(fullPath))
        {
          Directory.CreateDirectory(fullPath);
        }

        NameOfPerson = Path.Combine(fullPath, person + DateTime.Now.Ticks.ToString() + ".jpg");
        Person = person;

        DialogResult = DialogResult.OK;
      }
      else
      {
        MessageBox.Show(this, "You must enter the name of the person!", "Name is Invalid!");
      }
    }


    private void CancelButton_Click(object sender, EventArgs e)
    {
      NameOfPerson = string.Empty;
      DialogResult = DialogResult.Cancel;
    }

    private void AddButton_Click(object sender, EventArgs e)
    {
      FacesComboBox.Items.Add(FacesComboBox.Text);
      Directory.CreateDirectory(Path.Combine(_basePath, FacesComboBox.Text));
      FacesComboBox.SelectedItem = FacesComboBox.Text;

    }
  }
}
