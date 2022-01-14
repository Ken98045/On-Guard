
namespace OnGuardCore
{
  partial class FacialDefinitionDialog
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FacialDefinitionDialog));
      System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
            "unknown",
            "50"}, -1);
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.label5 = new System.Windows.Forms.Label();
      this.label6 = new System.Windows.Forms.Label();
      this.ConfidenceNumeric = new System.Windows.Forms.NumericUpDown();
      this.overlapNumeric = new System.Windows.Forms.NumericUpDown();
      this.minWidthNumeric = new System.Windows.Forms.NumericUpDown();
      this.minHeightNumeric = new System.Windows.Forms.NumericUpDown();
      this.panel1 = new System.Windows.Forms.Panel();
      this.label8 = new System.Windows.Forms.Label();
      this.personTextBox = new System.Windows.Forms.TextBox();
      this.label12 = new System.Windows.Forms.Label();
      this.label11 = new System.Windows.Forms.Label();
      this.label10 = new System.Windows.Forms.Label();
      this.label9 = new System.Windows.Forms.Label();
      this.OKButton = new System.Windows.Forms.Button();
      this.FormCancelButton = new System.Windows.Forms.Button();
      this.label7 = new System.Windows.Forms.Label();
      this.panel2 = new System.Windows.Forms.Panel();
      this.label13 = new System.Windows.Forms.Label();
      this.RemoveButton = new System.Windows.Forms.Button();
      this.EditButton = new System.Windows.Forms.Button();
      this.AddButton = new System.Windows.Forms.Button();
      this.FacesListView = new System.Windows.Forms.ListView();
      this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
      this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
      ((System.ComponentModel.ISupportInitialize)(this.ConfidenceNumeric)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.overlapNumeric)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.minWidthNumeric)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.minHeightNumeric)).BeginInit();
      this.panel1.SuspendLayout();
      this.panel2.SuspendLayout();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.label1.Location = new System.Drawing.Point(314, 22);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(102, 15);
      this.label1.TabIndex = 0;
      this.label1.Text = "Face Selection";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.label2.Location = new System.Drawing.Point(128, 44);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(86, 15);
      this.label2.TabIndex = 1;
      this.label2.Text = "Object Type:";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.label3.Location = new System.Drawing.Point(93, 78);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(121, 15);
      this.label3.TabIndex = 2;
      this.label3.Text = "Confidence Level:";
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.label4.Location = new System.Drawing.Point(25, 118);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(189, 15);
      this.label4.TabIndex = 3;
      this.label4.Text = "Minimum Overlap onto Area:";
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.label5.Location = new System.Drawing.Point(103, 157);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(111, 15);
      this.label5.TabIndex = 4;
      this.label5.Text = "Minimum Width:";
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.label6.Location = new System.Drawing.Point(97, 195);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(117, 15);
      this.label6.TabIndex = 5;
      this.label6.Text = "Minimum Height:";
      // 
      // ConfidenceNumeric
      // 
      this.ConfidenceNumeric.Location = new System.Drawing.Point(235, 80);
      this.ConfidenceNumeric.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
      this.ConfidenceNumeric.Minimum = new decimal(new int[] {
            40,
            0,
            0,
            0});
      this.ConfidenceNumeric.Name = "ConfidenceNumeric";
      this.ConfidenceNumeric.Size = new System.Drawing.Size(74, 23);
      this.ConfidenceNumeric.TabIndex = 1;
      this.ConfidenceNumeric.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      this.ConfidenceNumeric.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
      // 
      // overlapNumeric
      // 
      this.overlapNumeric.Location = new System.Drawing.Point(235, 118);
      this.overlapNumeric.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
      this.overlapNumeric.Name = "overlapNumeric";
      this.overlapNumeric.Size = new System.Drawing.Size(74, 23);
      this.overlapNumeric.TabIndex = 2;
      this.overlapNumeric.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      this.overlapNumeric.Value = new decimal(new int[] {
            75,
            0,
            0,
            0});
      // 
      // minWidthNumeric
      // 
      this.minWidthNumeric.Location = new System.Drawing.Point(235, 156);
      this.minWidthNumeric.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
      this.minWidthNumeric.Name = "minWidthNumeric";
      this.minWidthNumeric.Size = new System.Drawing.Size(74, 23);
      this.minWidthNumeric.TabIndex = 3;
      this.minWidthNumeric.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      // 
      // minHeightNumeric
      // 
      this.minHeightNumeric.Location = new System.Drawing.Point(235, 194);
      this.minHeightNumeric.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
      this.minHeightNumeric.Name = "minHeightNumeric";
      this.minHeightNumeric.Size = new System.Drawing.Size(74, 23);
      this.minHeightNumeric.TabIndex = 4;
      this.minHeightNumeric.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      // 
      // panel1
      // 
      this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.panel1.Controls.Add(this.label8);
      this.panel1.Controls.Add(this.personTextBox);
      this.panel1.Controls.Add(this.label12);
      this.panel1.Controls.Add(this.label11);
      this.panel1.Controls.Add(this.label10);
      this.panel1.Controls.Add(this.label9);
      this.panel1.Controls.Add(this.label4);
      this.panel1.Controls.Add(this.label2);
      this.panel1.Controls.Add(this.minHeightNumeric);
      this.panel1.Controls.Add(this.label3);
      this.panel1.Controls.Add(this.minWidthNumeric);
      this.panel1.Controls.Add(this.label5);
      this.panel1.Controls.Add(this.overlapNumeric);
      this.panel1.Controls.Add(this.label6);
      this.panel1.Controls.Add(this.ConfidenceNumeric);
      this.panel1.Location = new System.Drawing.Point(13, 120);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(676, 246);
      this.panel1.TabIndex = 13;
      // 
      // label8
      // 
      this.label8.AutoSize = true;
      this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.label8.Location = new System.Drawing.Point(317, 9);
      this.label8.Name = "label8";
      this.label8.Size = new System.Drawing.Size(128, 15);
      this.label8.TabIndex = 19;
      this.label8.Text = "\"Person\" Definition";
      // 
      // personTextBox
      // 
      this.personTextBox.Location = new System.Drawing.Point(235, 42);
      this.personTextBox.Name = "personTextBox";
      this.personTextBox.ReadOnly = true;
      this.personTextBox.Size = new System.Drawing.Size(100, 23);
      this.personTextBox.TabIndex = 18;
      this.personTextBox.Text = "person";
      // 
      // label12
      // 
      this.label12.AutoSize = true;
      this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.label12.Location = new System.Drawing.Point(334, 119);
      this.label12.Name = "label12";
      this.label12.Size = new System.Drawing.Size(139, 15);
      this.label12.TabIndex = 17;
      this.label12.Text = "Percentage (1 - 100)";
      // 
      // label11
      // 
      this.label11.AutoSize = true;
      this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.label11.Location = new System.Drawing.Point(334, 195);
      this.label11.Name = "label11";
      this.label11.Size = new System.Drawing.Size(241, 15);
      this.label11.TabIndex = 16;
      this.label11.Text = "Height in Pixels (0 = Don\'t Consider)";
      // 
      // label10
      // 
      this.label10.AutoSize = true;
      this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.label10.Location = new System.Drawing.Point(334, 157);
      this.label10.Name = "label10";
      this.label10.Size = new System.Drawing.Size(235, 15);
      this.label10.TabIndex = 15;
      this.label10.Text = "Width in Pixels (0 = Don\'t Consider)";
      // 
      // label9
      // 
      this.label9.AutoSize = true;
      this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.label9.Location = new System.Drawing.Point(334, 81);
      this.label9.Name = "label9";
      this.label9.Size = new System.Drawing.Size(139, 15);
      this.label9.TabIndex = 14;
      this.label9.Text = "Percentage (40 - 99)";
      // 
      // OKButton
      // 
      this.OKButton.Location = new System.Drawing.Point(269, 592);
      this.OKButton.Name = "OKButton";
      this.OKButton.Size = new System.Drawing.Size(75, 23);
      this.OKButton.TabIndex = 0;
      this.OKButton.Text = "OK";
      this.OKButton.UseVisualStyleBackColor = true;
      this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
      // 
      // CancelButton
      // 
      this.FormCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.FormCancelButton.Location = new System.Drawing.Point(358, 592);
      this.FormCancelButton.Name = "CancelButton";
      this.FormCancelButton.Size = new System.Drawing.Size(75, 23);
      this.FormCancelButton.TabIndex = 1;
      this.FormCancelButton.Text = "Cancel";
      this.FormCancelButton.UseVisualStyleBackColor = true;
      this.FormCancelButton.Click += new System.EventHandler(this.CancelButton_Click);
      // 
      // label7
      // 
      this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.label7.Location = new System.Drawing.Point(12, 54);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(676, 58);
      this.label7.TabIndex = 14;
      this.label7.Text = resources.GetString("label7.Text");
      // 
      // panel2
      // 
      this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.panel2.Controls.Add(this.label13);
      this.panel2.Controls.Add(this.RemoveButton);
      this.panel2.Controls.Add(this.EditButton);
      this.panel2.Controls.Add(this.AddButton);
      this.panel2.Controls.Add(this.FacesListView);
      this.panel2.Location = new System.Drawing.Point(125, 382);
      this.panel2.Name = "panel2";
      this.panel2.Size = new System.Drawing.Size(453, 196);
      this.panel2.TabIndex = 15;
      // 
      // label13
      // 
      this.label13.AutoSize = true;
      this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.label13.Location = new System.Drawing.Point(171, 6);
      this.label13.Name = "label13";
      this.label13.Size = new System.Drawing.Size(102, 15);
      this.label13.TabIndex = 4;
      this.label13.Text = "Face Selection";
      // 
      // RemoveButton
      // 
      this.RemoveButton.Enabled = false;
      this.RemoveButton.Location = new System.Drawing.Point(351, 127);
      this.RemoveButton.Name = "RemoveButton";
      this.RemoveButton.Size = new System.Drawing.Size(75, 23);
      this.RemoveButton.TabIndex = 3;
      this.RemoveButton.Text = "Remove";
      this.RemoveButton.UseVisualStyleBackColor = true;
      this.RemoveButton.Click += new System.EventHandler(this.RemoveButton_Click);
      // 
      // EditButton
      // 
      this.EditButton.Enabled = false;
      this.EditButton.Location = new System.Drawing.Point(354, 90);
      this.EditButton.Name = "EditButton";
      this.EditButton.Size = new System.Drawing.Size(75, 23);
      this.EditButton.TabIndex = 2;
      this.EditButton.Text = "Edit";
      this.EditButton.UseVisualStyleBackColor = true;
      this.EditButton.Click += new System.EventHandler(this.EditButton_Click);
      // 
      // AddButton
      // 
      this.AddButton.Location = new System.Drawing.Point(351, 53);
      this.AddButton.Name = "AddButton";
      this.AddButton.Size = new System.Drawing.Size(75, 23);
      this.AddButton.TabIndex = 1;
      this.AddButton.Text = "Add";
      this.AddButton.UseVisualStyleBackColor = true;
      this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
      // 
      // FacesListView
      // 
      this.FacesListView.CheckBoxes = true;
      this.FacesListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
      this.FacesListView.FullRowSelect = true;
      this.FacesListView.GridLines = true;
      this.FacesListView.HideSelection = false;
      listViewItem1.StateImageIndex = 0;
      this.FacesListView.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
      this.FacesListView.Location = new System.Drawing.Point(28, 35);
      this.FacesListView.MultiSelect = false;
      this.FacesListView.Name = "FacesListView";
      this.FacesListView.Size = new System.Drawing.Size(317, 144);
      this.FacesListView.TabIndex = 0;
      this.FacesListView.UseCompatibleStateImageBehavior = false;
      this.FacesListView.View = System.Windows.Forms.View.Details;
      this.FacesListView.SelectedIndexChanged += new System.EventHandler(this.OnFaceSelectionChanged);
      // 
      // columnHeader1
      // 
      this.columnHeader1.Text = "Person";
      this.columnHeader1.Width = 200;
      // 
      // columnHeader2
      // 
      this.columnHeader2.Text = "Confidence";
      this.columnHeader2.Width = 100;
      // 
      // FacialDefinitionDialog
      // 
      this.AcceptButton = this.OKButton;
      this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
      this.AutoScroll = true;
      this.AutoSize = true;
      this.ClientSize = new System.Drawing.Size(702, 626);
      this.Controls.Add(this.panel2);
      this.Controls.Add(this.label7);
      this.Controls.Add(this.FormCancelButton);
      this.Controls.Add(this.OKButton);
      this.Controls.Add(this.panel1);
      this.Controls.Add(this.label1);
      this.Name = "FacialDefinitionDialog";
      this.Text = "Create a  Recognized Object";
      ((System.ComponentModel.ISupportInitialize)(this.ConfidenceNumeric)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.overlapNumeric)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.minWidthNumeric)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.minHeightNumeric)).EndInit();
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.panel2.ResumeLayout(false);
      this.panel2.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.NumericUpDown ConfidenceNumeric;
    private System.Windows.Forms.NumericUpDown overlapNumeric;
    private System.Windows.Forms.NumericUpDown minWidthNumeric;
    private System.Windows.Forms.NumericUpDown minHeightNumeric;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Label label12;
    private System.Windows.Forms.Label label11;
    private System.Windows.Forms.Label label10;
    private System.Windows.Forms.Label label9;
    private System.Windows.Forms.Button OKButton;
    private System.Windows.Forms.Button FormCancelButton;
    private System.Windows.Forms.TextBox personTextBox;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.Panel panel2;
    private System.Windows.Forms.Button RemoveButton;
    private System.Windows.Forms.Button EditButton;
    private System.Windows.Forms.Button AddButton;
    private System.Windows.Forms.ListView FacesListView;
    private System.Windows.Forms.ColumnHeader columnHeader1;
    private System.Windows.Forms.ColumnHeader columnHeader2;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.Label label13;
  }
}