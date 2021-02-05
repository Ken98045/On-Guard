
namespace SAAI
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
      this.CancelButton = new System.Windows.Forms.Button();
      this.BumpVehicleConfidenceCheck = new System.Windows.Forms.CheckBox();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label1.Location = new System.Drawing.Point(197, 33);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(127, 16);
      this.label1.TabIndex = 0;
      this.label1.Text = "Analysis Settings";
      // 
      // ParkedCarsOverlapCheckbox
      // 
      this.ParkedCarsOverlapCheckbox.AutoSize = true;
      this.ParkedCarsOverlapCheckbox.Checked = true;
      this.ParkedCarsOverlapCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
      this.ParkedCarsOverlapCheckbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.ParkedCarsOverlapCheckbox.Location = new System.Drawing.Point(31, 80);
      this.ParkedCarsOverlapCheckbox.Name = "ParkedCarsOverlapCheckbox";
      this.ParkedCarsOverlapCheckbox.Size = new System.Drawing.Size(368, 20);
      this.ParkedCarsOverlapCheckbox.TabIndex = 1;
      this.ParkedCarsOverlapCheckbox.Text = "Exclude  Parked Cars From Motion Using Overlap";
      this.ParkedCarsOverlapCheckbox.UseVisualStyleBackColor = true;
      // 
      // ExcludeParkedCornersCheckbox
      // 
      this.ExcludeParkedCornersCheckbox.AutoSize = true;
      this.ExcludeParkedCornersCheckbox.Checked = true;
      this.ExcludeParkedCornersCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
      this.ExcludeParkedCornersCheckbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.ExcludeParkedCornersCheckbox.Location = new System.Drawing.Point(31, 119);
      this.ExcludeParkedCornersCheckbox.Name = "ExcludeParkedCornersCheckbox";
      this.ExcludeParkedCornersCheckbox.Size = new System.Drawing.Size(456, 20);
      this.ExcludeParkedCornersCheckbox.TabIndex = 2;
      this.ExcludeParkedCornersCheckbox.Text = "Exclude  Parked Cars From Motion Using Corners (Secondary)";
      this.ExcludeParkedCornersCheckbox.UseVisualStyleBackColor = true;
      // 
      // OKButton
      // 
      this.OKButton.Location = new System.Drawing.Point(178, 202);
      this.OKButton.Name = "OKButton";
      this.OKButton.Size = new System.Drawing.Size(75, 23);
      this.OKButton.TabIndex = 3;
      this.OKButton.Text = "OK";
      this.OKButton.UseVisualStyleBackColor = true;
      this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
      // 
      // CancelButton
      // 
      this.CancelButton.Location = new System.Drawing.Point(268, 202);
      this.CancelButton.Name = "CancelButton";
      this.CancelButton.Size = new System.Drawing.Size(75, 23);
      this.CancelButton.TabIndex = 4;
      this.CancelButton.Text = "Cancel";
      this.CancelButton.UseVisualStyleBackColor = true;
      this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
      // 
      // BumpVehicleConfidenceCheck
      // 
      this.BumpVehicleConfidenceCheck.AutoSize = true;
      this.BumpVehicleConfidenceCheck.Checked = true;
      this.BumpVehicleConfidenceCheck.CheckState = System.Windows.Forms.CheckState.Checked;
      this.BumpVehicleConfidenceCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.BumpVehicleConfidenceCheck.Location = new System.Drawing.Point(31, 158);
      this.BumpVehicleConfidenceCheck.Name = "BumpVehicleConfidenceCheck";
      this.BumpVehicleConfidenceCheck.Size = new System.Drawing.Size(444, 20);
      this.BumpVehicleConfidenceCheck.TabIndex = 5;
      this.BumpVehicleConfidenceCheck.Text = "Increase Confidence in Multi-Vehicle Overlapping Definitions";
      this.BumpVehicleConfidenceCheck.UseVisualStyleBackColor = true;
      // 
      // AnalysisSettingsDialog
      // 
      this.AcceptButton = this.OKButton;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.CancelButton;
      this.ClientSize = new System.Drawing.Size(521, 241);
      this.Controls.Add(this.BumpVehicleConfidenceCheck);
      this.Controls.Add(this.CancelButton);
      this.Controls.Add(this.OKButton);
      this.Controls.Add(this.ExcludeParkedCornersCheckbox);
      this.Controls.Add(this.ParkedCarsOverlapCheckbox);
      this.Controls.Add(this.label1);
      this.Name = "AnalysisSettingsDialog";
      this.Text = "Analysis Settings";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.CheckBox ParkedCarsOverlapCheckbox;
    private System.Windows.Forms.CheckBox ExcludeParkedCornersCheckbox;
    private System.Windows.Forms.Button OKButton;
    private System.Windows.Forms.Button CancelButton;
    private System.Windows.Forms.CheckBox BumpVehicleConfidenceCheck;
  }
}