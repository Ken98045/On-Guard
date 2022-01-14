using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnGuardCore
{ 
  public partial class FacialDefinitionDialog : Form
  {
    public string ObjectType { get; set; }
    public int Confidence { get; set; }
    public int Overlap { get; set; }
    public int MinX { get; set; }
    public int MinY { get; set; }

    public List<FaceID> Faces = new List<FaceID>();

    public FacialDefinitionDialog()
    {
      InitializeComponent();
    }

    public FacialDefinitionDialog(ObjectCharacteristics src)
    {
      InitializeComponent();

      if (null != src)
      {
        ConfidenceNumeric.Value = src.Confidence;
        overlapNumeric.Value = src.MinPercentOverlap;
        minWidthNumeric.Value = src.MinimumXSize;
        minHeightNumeric.Value = src.MinimumYSize;
        Faces = src.Faces;

        foreach (var face in src.Faces)
        {
          ListViewItem item;
          if (face.Name == "unknown")
          {
            item = FacesListView.Items[0];
          }
          else
          {
            item = new ListViewItem(new string[] { face.Name, face.Confidence.ToString() });
            FacesListView.Items.Add(item);
          }

          item.Checked = face.Selected;
        }
      }
    }

    private void OKButton_Click(object sender, EventArgs e)
    {
      ObjectType = "person";
      Confidence = (int)ConfidenceNumeric.Value;
      Overlap = (int)overlapNumeric.Value;
      MinX = (int)minWidthNumeric.Value;
      MinY = (int)minHeightNumeric.Value;

      int checkCount = 0;
      for (int i = 0; i < FacesListView.Items.Count; i++)
      {
        if (FacesListView.Items[i].Checked)
        {
          ++checkCount;
        }
      }

      if (checkCount > 0)
      {
        Faces.Clear();
        for (int i = 0; i < FacesListView.Items.Count; i++)
        {
          FaceID face = new FaceID();
          face.Name = FacesListView.Items[i].Text;
          face.Confidence = int.Parse(FacesListView.Items[i].SubItems[1].Text);
          face.Selected = FacesListView.Items[i].Checked;
          Faces.Add(face);
        }
        DialogResult = DialogResult.OK;
      }
      else
      {
        MessageBox.Show(this, "You must check/select at least one face (or 'unrecognized'", "No Faces Selected");
      }
    }

    private void CancelButton_Click(object sender, EventArgs e)
    {
      DialogResult = DialogResult.Cancel;
    }

    private void AddButton_Click(object sender, EventArgs e)
    {
      using (AddFaceDialog dlg = new AddFaceDialog(null))
      {
        if (dlg.ShowDialog() == DialogResult.OK)
        {
          if (!FacesListView.Items.ContainsKey(dlg.FaceName))
          {
            ListViewItem item = new ListViewItem(new string[] { dlg.FaceName, dlg.Confidence.ToString() });
            FacesListView.Items.Add(item);
            item.Checked = true;
          }
          else
          {
            MessageBox.Show(this, "This individual already exists in the faces list!", "Already Exists!");
          }
        }
      }
    }

    private void EditButton_Click(object sender, EventArgs e)
    {
      int index = FacesListView.SelectedIndices[0];
      ListViewItem item = FacesListView.Items[index];

      FaceID face = new FaceID();
      face.Name = item.Text;
      face.Confidence = int.Parse(item.SubItems[1].Text);

      using (AddFaceDialog dlg = new AddFaceDialog(face))
      {
        if (dlg.ShowDialog() == DialogResult.OK)
        {
          item.Text = dlg.FaceName;
          item.SubItems[1].Text = dlg.Confidence.ToString();
          item.Checked = true;
        }
      }
    }

    private void RemoveButton_Click(object sender, EventArgs e)
    {
      int index = FacesListView.SelectedIndices[0];
      FacesListView.Items.RemoveAt(index);
    }

    private void OnFaceSelectionChanged(object sender, EventArgs e)
    {
      if (FacesListView.SelectedIndices.Count > 0)
      {
        int index = FacesListView.SelectedIndices[0];
        if (index > 0)
        {
          EditButton.Enabled = true;
          RemoveButton.Enabled = true;
        }
        else
        {
          EditButton.Enabled = false;
          RemoveButton.Enabled = false;
        }
      }
    }
  }
}
