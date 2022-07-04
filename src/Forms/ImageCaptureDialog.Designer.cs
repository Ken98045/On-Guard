
namespace OnGuardCore
{
  partial class ImageCaptureDialog
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImageCaptureDialog));
      this.panel2 = new System.Windows.Forms.Panel();
      this.label13 = new System.Windows.Forms.Label();
      this.label11 = new System.Windows.Forms.Label();
      this.eventIntervalNumeric = new System.Windows.Forms.NumericUpDown();
      this.label8 = new System.Windows.Forms.Label();
      this.label9 = new System.Windows.Forms.Label();
      this.maxEventNumeric = new System.Windows.Forms.NumericUpDown();
      this.label6 = new System.Windows.Forms.Label();
      this.label5 = new System.Windows.Forms.Label();
      this.snapshotNumeric = new System.Windows.Forms.NumericUpDown();
      this.label7 = new System.Windows.Forms.Label();
      this.OKButton = new System.Windows.Forms.Button();
      this.FormCancelButton = new System.Windows.Forms.Button();
      this.panel2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.eventIntervalNumeric)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.maxEventNumeric)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.snapshotNumeric)).BeginInit();
      this.SuspendLayout();
      // 
      // panel2
      // 
      this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.panel2.Controls.Add(this.label13);
      this.panel2.Controls.Add(this.label11);
      this.panel2.Controls.Add(this.eventIntervalNumeric);
      this.panel2.Controls.Add(this.label8);
      this.panel2.Controls.Add(this.label9);
      this.panel2.Controls.Add(this.maxEventNumeric);
      this.panel2.Controls.Add(this.label6);
      this.panel2.Controls.Add(this.label5);
      this.panel2.Controls.Add(this.snapshotNumeric);
      this.panel2.Location = new System.Drawing.Point(12, 42);
      this.panel2.Name = "panel2";
      this.panel2.Size = new System.Drawing.Size(765, 206);
      this.panel2.TabIndex = 1;
      // 
      // label13
      // 
      this.label13.Location = new System.Drawing.Point(233, 127);
      this.label13.Name = "label13";
      this.label13.Size = new System.Drawing.Size(479, 52);
      this.label13.TabIndex = 16;
      this.label13.Text = resources.GetString("label13.Text");
      // 
      // label11
      // 
      this.label11.AutoSize = true;
      this.label11.Location = new System.Drawing.Point(21, 138);
      this.label11.Name = "label11";
      this.label11.Size = new System.Drawing.Size(124, 15);
      this.label11.TabIndex = 1;
      this.label11.Text = "Time Between Events: ";
      // 
      // eventIntervalNumeric
      // 
      this.eventIntervalNumeric.Location = new System.Drawing.Point(160, 136);
      this.eventIntervalNumeric.Maximum = new decimal(new int[] {
            120,
            0,
            0,
            0});
      this.eventIntervalNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.eventIntervalNumeric.Name = "eventIntervalNumeric";
      this.eventIntervalNumeric.Size = new System.Drawing.Size(55, 23);
      this.eventIntervalNumeric.TabIndex = 2;
      this.eventIntervalNumeric.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
      // 
      // label8
      // 
      this.label8.Location = new System.Drawing.Point(233, 54);
      this.label8.Name = "label8";
      this.label8.Size = new System.Drawing.Size(499, 60);
      this.label8.TabIndex = 13;
      this.label8.Text = resources.GetString("label8.Text");
      // 
      // label9
      // 
      this.label9.AutoSize = true;
      this.label9.Location = new System.Drawing.Point(16, 67);
      this.label9.Name = "label9";
      this.label9.Size = new System.Drawing.Size(129, 15);
      this.label9.TabIndex = 12;
      this.label9.Text = "Maximum Event Time: ";
      // 
      // maxEventNumeric
      // 
      this.maxEventNumeric.Location = new System.Drawing.Point(160, 65);
      this.maxEventNumeric.Maximum = new decimal(new int[] {
            120,
            0,
            0,
            0});
      this.maxEventNumeric.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
      this.maxEventNumeric.Name = "maxEventNumeric";
      this.maxEventNumeric.Size = new System.Drawing.Size(55, 23);
      this.maxEventNumeric.TabIndex = 1;
      this.maxEventNumeric.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Location = new System.Drawing.Point(233, 23);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(267, 15);
      this.label6.TabIndex = 10;
      this.label6.Text = "Seconds -  The Interval Between Snapshot Images\r\n";
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(41, 23);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(104, 15);
      this.label5.TabIndex = 0;
      this.label5.Text = "Snapshot Interval: ";
      // 
      // snapshotNumeric
      // 
      this.snapshotNumeric.DecimalPlaces = 2;
      this.snapshotNumeric.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
      this.snapshotNumeric.Location = new System.Drawing.Point(160, 21);
      this.snapshotNumeric.Maximum = new decimal(new int[] {
            120,
            0,
            0,
            0});
      this.snapshotNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
      this.snapshotNumeric.Name = "snapshotNumeric";
      this.snapshotNumeric.Size = new System.Drawing.Size(55, 23);
      this.snapshotNumeric.TabIndex = 0;
      this.snapshotNumeric.Value = new decimal(new int[] {
            10,
            0,
            0,
            65536});
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.label7.Location = new System.Drawing.Point(240, 14);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(320, 16);
      this.label7.TabIndex = 8;
      this.label7.Text = "Image Capture and Reporting Global Settings";
      // 
      // OKButton
      // 
      this.OKButton.Location = new System.Drawing.Point(322, 267);
      this.OKButton.Name = "OKButton";
      this.OKButton.Size = new System.Drawing.Size(75, 23);
      this.OKButton.TabIndex = 0;
      this.OKButton.Text = "OK";
      this.OKButton.UseVisualStyleBackColor = true;
      this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
      // 
      // FormCancelButton
      // 
      this.FormCancelButton.Location = new System.Drawing.Point(403, 267);
      this.FormCancelButton.Name = "FormCancelButton";
      this.FormCancelButton.Size = new System.Drawing.Size(75, 23);
      this.FormCancelButton.TabIndex = 1;
      this.FormCancelButton.Text = "Cancel";
      this.FormCancelButton.UseVisualStyleBackColor = true;
      this.FormCancelButton.Click += new System.EventHandler(this.CancelButton_Click);
      // 
      // ImageCaptureDialog
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
      this.AutoScroll = true;
      this.ClientSize = new System.Drawing.Size(800, 308);
      this.Controls.Add(this.FormCancelButton);
      this.Controls.Add(this.OKButton);
      this.Controls.Add(this.panel2);
      this.Controls.Add(this.label7);
      this.Name = "ImageCaptureDialog";
      this.Text = "Global Image Capture Settings";
      this.panel2.ResumeLayout(false);
      this.panel2.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.eventIntervalNumeric)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.maxEventNumeric)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.snapshotNumeric)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Panel panel2;
    private System.Windows.Forms.Label label13;
    private System.Windows.Forms.Label label11;
    private System.Windows.Forms.NumericUpDown eventIntervalNumeric;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.Label label9;
    private System.Windows.Forms.NumericUpDown maxEventNumeric;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.NumericUpDown snapshotNumeric;
    private System.Windows.Forms.Button OKButton;
    private System.Windows.Forms.Button FormCancelButton;
  }
}