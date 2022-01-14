
namespace OnGuardCore
{
  partial class AnalysisSettingsDialog
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
      this.label1 = new System.Windows.Forms.Label();
      this.ParkedCarsOverlapCheckbox = new System.Windows.Forms.CheckBox();
      this.ExcludeParkedCornersCheckbox = new System.Windows.Forms.CheckBox();
      this.OKButton = new System.Windows.Forms.Button();
      this.FormCancelButton = new System.Windows.Forms.Button();
      this.BumpVehicleConfidenceCheck = new System.Windows.Forms.CheckBox();
      this.panel1 = new System.Windows.Forms.Panel();
      this.panel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.label1.Location = new System.Drawing.Point(230, 12);
      this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(126, 16);
      this.label1.TabIndex = 0;
      this.label1.Text = "Analysis Settings";
      // 
      // ParkedCarsOverlapCheckbox
      // 
      this.ParkedCarsOverlapCheckbox.AutoSize = true;
      this.ParkedCarsOverlapCheckbox.Checked = true;
      this.ParkedCarsOverlapCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
      this.ParkedCarsOverlapCheckbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.ParkedCarsOverlapCheckbox.Location = new System.Drawing.Point(16, 29);
      this.ParkedCarsOverlapCheckbox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
      this.ParkedCarsOverlapCheckbox.Name = "ParkedCarsOverlapCheckbox";
      this.ParkedCarsOverlapCheckbox.Size = new System.Drawing.Size(367, 20);
      this.ParkedCarsOverlapCheckbox.TabIndex = 1;
      this.ParkedCarsOverlapCheckbox.Text = "Exclude  Parked Cars From Motion Using Overlap";
      this.ParkedCarsOverlapCheckbox.UseVisualStyleBackColor = true;
      // 
      // ExcludeParkedCornersCheckbox
      // 
      this.ExcludeParkedCornersCheckbox.AutoSize = true;
      this.ExcludeParkedCornersCheckbox.Checked = true;
      this.ExcludeParkedCornersCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
      this.ExcludeParkedCornersCheckbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.ExcludeParkedCornersCheckbox.Location = new System.Drawing.Point(16, 74);
      this.ExcludeParkedCornersCheckbox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
      this.ExcludeParkedCornersCheckbox.Name = "ExcludeParkedCornersCheckbox";
      this.ExcludeParkedCornersCheckbox.Size = new System.Drawing.Size(455, 20);
      this.ExcludeParkedCornersCheckbox.TabIndex = 2;
      this.ExcludeParkedCornersCheckbox.Text = "Exclude  Parked Cars From Motion Using Corners (Secondary)";
      this.ExcludeParkedCornersCheckbox.UseVisualStyleBackColor = true;
      // 
      // OKButton
      // 
      this.OKButton.Location = new System.Drawing.Point(169, 218);
      this.OKButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
      this.OKButton.Name = "OKButton";
      this.OKButton.Size = new System.Drawing.Size(88, 27);
      this.OKButton.TabIndex = 3;
      this.OKButton.Text = "OK";
      this.OKButton.UseVisualStyleBackColor = true;
      this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
      // 
      // CancelButton
      // 
      this.FormCancelButton.Location = new System.Drawing.Point(268, 218);
      this.FormCancelButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
      this.FormCancelButton.Name = "CancelButton";
      this.FormCancelButton.Size = new System.Drawing.Size(88, 27);
      this.FormCancelButton.TabIndex = 4;
      this.FormCancelButton.Text = "Cancel";
      this.FormCancelButton.UseVisualStyleBackColor = true;
      this.FormCancelButton.Click += new System.EventHandler(this.CancelButton_Click);
      // 
      // BumpVehicleConfidenceCheck
      // 
      this.BumpVehicleConfidenceCheck.AutoSize = true;
      this.BumpVehicleConfidenceCheck.Checked = true;
      this.BumpVehicleConfidenceCheck.CheckState = System.Windows.Forms.CheckState.Checked;
      this.BumpVehicleConfidenceCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.BumpVehicleConfidenceCheck.Location = new System.Drawing.Point(16, 119);
      this.BumpVehicleConfidenceCheck.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
      this.BumpVehicleConfidenceCheck.Name = "BumpVehicleConfidenceCheck";
      this.BumpVehicleConfidenceCheck.Size = new System.Drawing.Size(443, 20);
      this.BumpVehicleConfidenceCheck.TabIndex = 5;
      this.BumpVehicleConfidenceCheck.Text = "Increase Confidence in Multi-Vehicle Overlapping Definitions";
      this.BumpVehicleConfidenceCheck.UseVisualStyleBackColor = true;
      // 
      // panel1
      // 
      this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.panel1.Controls.Add(this.ParkedCarsOverlapCheckbox);
      this.panel1.Controls.Add(this.BumpVehicleConfidenceCheck);
      this.panel1.Controls.Add(this.ExcludeParkedCornersCheckbox);
      this.panel1.Location = new System.Drawing.Point(17, 38);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(491, 170);
      this.panel1.TabIndex = 6;
      // 
      // AnalysisSettingsDialog
      // 
      this.AcceptButton = this.OKButton;
      this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
      this.ClientSize = new System.Drawing.Size(524, 253);
      this.Controls.Add(this.panel1);
      this.Controls.Add(this.FormCancelButton);
      this.Controls.Add(this.OKButton);
      this.Controls.Add(this.label1);
      this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
      this.Name = "AnalysisSettingsDialog";
      this.Text = "Analysis Settings";
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.CheckBox ParkedCarsOverlapCheckbox;
    private System.Windows.Forms.CheckBox ExcludeParkedCornersCheckbox;
    private System.Windows.Forms.Button OKButton;
    private System.Windows.Forms.Button FormCancelButton;
    private System.Windows.Forms.CheckBox BumpVehicleConfidenceCheck;
    private System.Windows.Forms.Panel panel1;
  }
}