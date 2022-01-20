
namespace OnGuardCore
{
  partial class CleanupDialog
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
      this.label2 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.DaysNumeric = new System.Windows.Forms.NumericUpDown();
      this.HoursNumeric = new System.Windows.Forms.NumericUpDown();
      this.OKButton = new System.Windows.Forms.Button();
      this.CancelButton = new System.Windows.Forms.Button();
      this.label4 = new System.Windows.Forms.Label();
      this.AllCamerasCheckbox = new System.Windows.Forms.CheckBox();
      this.DoNotDeleteMotionCheckbox = new System.Windows.Forms.CheckBox();
      ((System.ComponentModel.ISupportInitialize)(this.DaysNumeric)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.HoursNumeric)).BeginInit();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.label1.Location = new System.Drawing.Point(67, 62);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(385, 18);
      this.label1.TabIndex = 0;
      this.label1.Text = "Retain Pictures Under This Time - Delete All Older\r\n";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.label2.Location = new System.Drawing.Point(91, 103);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(51, 18);
      this.label2.TabIndex = 1;
      this.label2.Text = "Days:";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.label3.Location = new System.Drawing.Point(88, 140);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(54, 18);
      this.label3.TabIndex = 2;
      this.label3.Text = "Hours";
      // 
      // DaysNumeric
      // 
      this.DaysNumeric.Location = new System.Drawing.Point(166, 106);
      this.DaysNumeric.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
      this.DaysNumeric.Name = "DaysNumeric";
      this.DaysNumeric.Size = new System.Drawing.Size(68, 23);
      this.DaysNumeric.TabIndex = 0;
      this.DaysNumeric.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
      // 
      // HoursNumeric
      // 
      this.HoursNumeric.Location = new System.Drawing.Point(166, 143);
      this.HoursNumeric.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
      this.HoursNumeric.Name = "HoursNumeric";
      this.HoursNumeric.Size = new System.Drawing.Size(68, 23);
      this.HoursNumeric.TabIndex = 1;
      // 
      // OKButton
      // 
      this.OKButton.Location = new System.Drawing.Point(180, 259);
      this.OKButton.Name = "OKButton";
      this.OKButton.Size = new System.Drawing.Size(75, 23);
      this.OKButton.TabIndex = 4;
      this.OKButton.Text = "OK";
      this.OKButton.UseVisualStyleBackColor = true;
      this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
      // 
      // CancelButton
      // 
      this.CancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.CancelButton.Location = new System.Drawing.Point(263, 259);
      this.CancelButton.Name = "CancelButton";
      this.CancelButton.Size = new System.Drawing.Size(75, 23);
      this.CancelButton.TabIndex = 5;
      this.CancelButton.Text = "Cancel";
      this.CancelButton.UseVisualStyleBackColor = true;
      this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.label4.Location = new System.Drawing.Point(171, 19);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(177, 20);
      this.label4.TabIndex = 7;
      this.label4.Text = "Cleanup Old Pictures\r\n";
      // 
      // AllCamerasCheckbox
      // 
      this.AllCamerasCheckbox.AutoSize = true;
      this.AllCamerasCheckbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.AllCamerasCheckbox.Location = new System.Drawing.Point(92, 185);
      this.AllCamerasCheckbox.Name = "AllCamerasCheckbox";
      this.AllCamerasCheckbox.Size = new System.Drawing.Size(371, 20);
      this.AllCamerasCheckbox.TabIndex = 2;
      this.AllCamerasCheckbox.Text = "All Cameras  (If Not Checked Current CameraOnly)\r\n";
      this.AllCamerasCheckbox.UseVisualStyleBackColor = true;
      // 
      // DoNotDeleteMotionCheckbox
      // 
      this.DoNotDeleteMotionCheckbox.AutoSize = true;
      this.DoNotDeleteMotionCheckbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.DoNotDeleteMotionCheckbox.Location = new System.Drawing.Point(91, 219);
      this.DoNotDeleteMotionCheckbox.Name = "DoNotDeleteMotionCheckbox";
      this.DoNotDeleteMotionCheckbox.Size = new System.Drawing.Size(342, 20);
      this.DoNotDeleteMotionCheckbox.TabIndex = 3;
      this.DoNotDeleteMotionCheckbox.Text = "Do Not Delete Files with Motion (can be slow!)\r\n";
      this.DoNotDeleteMotionCheckbox.UseVisualStyleBackColor = true;
      // 
      // CleanupDialog
      // 
      this.AcceptButton = this.OKButton;
      this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
      this.ClientSize = new System.Drawing.Size(518, 291);
      this.Controls.Add(this.DoNotDeleteMotionCheckbox);
      this.Controls.Add(this.AllCamerasCheckbox);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.CancelButton);
      this.Controls.Add(this.OKButton);
      this.Controls.Add(this.HoursNumeric);
      this.Controls.Add(this.DaysNumeric);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Name = "CleanupDialog";
      this.Text = "Cleanup Old Pictuers";
      ((System.ComponentModel.ISupportInitialize)(this.DaysNumeric)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.HoursNumeric)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.NumericUpDown DaysNumeric;
    private System.Windows.Forms.NumericUpDown HoursNumeric;
    private System.Windows.Forms.Button OKButton;
    new private System.Windows.Forms.Button CancelButton;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.CheckBox AllCamerasCheckbox;
    private System.Windows.Forms.CheckBox DoNotDeleteMotionCheckbox;
  }
}