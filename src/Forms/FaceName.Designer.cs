
namespace OnGuardCore
{
  partial class FaceName
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
      this.LiveCameraLabel = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.FacesComboBox = new System.Windows.Forms.ComboBox();
      this.AddButton = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // OKButton
      // 
      this.OKButton.Location = new System.Drawing.Point(85, 108);
      this.OKButton.Name = "OKButton";
      this.OKButton.Size = new System.Drawing.Size(75, 23);
      this.OKButton.TabIndex = 0;
      this.OKButton.Text = "Add Face";
      this.OKButton.UseVisualStyleBackColor = true;
      this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
      // 
      // FormCancelButton
      // 
      this.FormCancelButton.Location = new System.Drawing.Point(169, 108);
      this.FormCancelButton.Name = "FormCancelButton";
      this.FormCancelButton.Size = new System.Drawing.Size(75, 23);
      this.FormCancelButton.TabIndex = 1;
      this.FormCancelButton.Text = "Cancel";
      this.FormCancelButton.UseVisualStyleBackColor = true;
      this.FormCancelButton.Click += new System.EventHandler(this.CancelButton_Click);
      // 
      // LiveCameraLabel
      // 
      this.LiveCameraLabel.AutoSize = true;
      this.LiveCameraLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.LiveCameraLabel.Location = new System.Drawing.Point(90, 8);
      this.LiveCameraLabel.Name = "LiveCameraLabel";
      this.LiveCameraLabel.Size = new System.Drawing.Size(112, 16);
      this.LiveCameraLabel.TabIndex = 43;
      this.LiveCameraLabel.Text = "Name the Face";
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.label1.Location = new System.Drawing.Point(27, 51);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(45, 15);
      this.label1.TabIndex = 44;
      this.label1.Text = "Name";
      // 
      // FacesComboBox
      // 
      this.FacesComboBox.FormattingEnabled = true;
      this.FacesComboBox.Location = new System.Drawing.Point(83, 49);
      this.FacesComboBox.Name = "FacesComboBox";
      this.FacesComboBox.Size = new System.Drawing.Size(121, 23);
      this.FacesComboBox.TabIndex = 45;
      // 
      // AddButton
      // 
      this.AddButton.Location = new System.Drawing.Point(210, 48);
      this.AddButton.Name = "AddButton";
      this.AddButton.Size = new System.Drawing.Size(89, 23);
      this.AddButton.TabIndex = 46;
      this.AddButton.Text = "Add Person";
      this.AddButton.UseVisualStyleBackColor = true;
      this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
      // 
      // FaceName
      // 
      this.AcceptButton = this.OKButton;
      this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
      this.ClientSize = new System.Drawing.Size(329, 143);
      this.Controls.Add(this.AddButton);
      this.Controls.Add(this.FacesComboBox);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.LiveCameraLabel);
      this.Controls.Add(this.FormCancelButton);
      this.Controls.Add(this.OKButton);
      this.Name = "FaceName";
      this.Text = "Name the Face";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button OKButton;
    private System.Windows.Forms.Button FormCancelButton;
    private System.Windows.Forms.Label LiveCameraLabel;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.ComboBox FacesComboBox;
    private System.Windows.Forms.Button AddButton;
  }
}