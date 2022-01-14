
namespace OnGuardCore
{
  partial class AddFaceDialog
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
      this.OKButton = new System.Windows.Forms.Button();
      this.FormCancelButton = new System.Windows.Forms.Button();
      this.label2 = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.label9 = new System.Windows.Forms.Label();
      this.ConfidenceNumeric = new System.Windows.Forms.NumericUpDown();
      this.FacesComboBox = new System.Windows.Forms.ComboBox();
      ((System.ComponentModel.ISupportInitialize)(this.ConfidenceNumeric)).BeginInit();
      this.SuspendLayout();
      // 
      // OKButton
      // 
      this.OKButton.Location = new System.Drawing.Point(101, 123);
      this.OKButton.Name = "OKButton";
      this.OKButton.Size = new System.Drawing.Size(75, 23);
      this.OKButton.TabIndex = 0;
      this.OKButton.Text = "OK";
      this.OKButton.UseVisualStyleBackColor = true;
      this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
      // 
      // CancelButton
      // 
      this.FormCancelButton.Location = new System.Drawing.Point(186, 123);
      this.FormCancelButton.Name = "CancelButton";
      this.FormCancelButton.Size = new System.Drawing.Size(75, 23);
      this.FormCancelButton.TabIndex = 1;
      this.FormCancelButton.Text = "Cancel";
      this.FormCancelButton.UseVisualStyleBackColor = true;
      this.FormCancelButton.Click += new System.EventHandler(this.CancelButton_Click);
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.label2.Location = new System.Drawing.Point(39, 34);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(49, 15);
      this.label2.TabIndex = 3;
      this.label2.Text = "Name:";
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.label1.Location = new System.Drawing.Point(5, 73);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(83, 15);
      this.label1.TabIndex = 4;
      this.label1.Text = "Confidence:";
      // 
      // label9
      // 
      this.label9.AutoSize = true;
      this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.label9.Location = new System.Drawing.Point(205, 73);
      this.label9.Name = "label9";
      this.label9.Size = new System.Drawing.Size(139, 15);
      this.label9.TabIndex = 15;
      this.label9.Text = "Percentage (40 - 99)";
      // 
      // ConfidenceNumeric
      // 
      this.ConfidenceNumeric.Location = new System.Drawing.Point(98, 72);
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
      this.ConfidenceNumeric.Size = new System.Drawing.Size(101, 23);
      this.ConfidenceNumeric.TabIndex = 16;
      this.ConfidenceNumeric.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
      // 
      // FacesComboBox
      // 
      this.FacesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.FacesComboBox.FormattingEnabled = true;
      this.FacesComboBox.Location = new System.Drawing.Point(112, 32);
      this.FacesComboBox.Name = "FacesComboBox";
      this.FacesComboBox.Size = new System.Drawing.Size(121, 23);
      this.FacesComboBox.TabIndex = 17;
      // 
      // AddFaceDialog
      // 
      this.AcceptButton = this.OKButton;
      this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
      this.ClientSize = new System.Drawing.Size(362, 159);
      this.Controls.Add(this.FacesComboBox);
      this.Controls.Add(this.ConfidenceNumeric);
      this.Controls.Add(this.label9);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.FormCancelButton);
      this.Controls.Add(this.OKButton);
      this.FaceName = "AddFaceDialog";
      this.Text = "Add Face";
      ((System.ComponentModel.ISupportInitialize)(this.ConfidenceNumeric)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button OKButton;
    private System.Windows.Forms.Button FormCancelButton;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label9;
    private System.Windows.Forms.NumericUpDown ConfidenceNumeric;
    private System.Windows.Forms.ComboBox FacesComboBox;
  }
}