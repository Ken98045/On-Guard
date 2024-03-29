﻿namespace OnGuardCore
{
  partial class DisplayMode
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
      this.panel1 = new System.Windows.Forms.Panel();
      this.VerticalFillRadio = new System.Windows.Forms.RadioButton();
      this.FixedRadio = new System.Windows.Forms.RadioButton();
      this.FilledRadio = new System.Windows.Forms.RadioButton();
      this.HorizontalFillRadio = new System.Windows.Forms.RadioButton();
      this.OKButton = new System.Windows.Forms.Button();
      this.CancelButton = new System.Windows.Forms.Button();
      this.LiveCameraLabel = new System.Windows.Forms.Label();
      this.panel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // panel1
      // 
      this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.panel1.Controls.Add(this.VerticalFillRadio);
      this.panel1.Controls.Add(this.FixedRadio);
      this.panel1.Controls.Add(this.FilledRadio);
      this.panel1.Controls.Add(this.HorizontalFillRadio);
      this.panel1.Location = new System.Drawing.Point(7, 35);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(658, 168);
      this.panel1.TabIndex = 0;
      // 
      // VerticalFillRadio
      // 
      this.VerticalFillRadio.AutoSize = true;
      this.VerticalFillRadio.Location = new System.Drawing.Point(7, 57);
      this.VerticalFillRadio.Name = "VerticalFillRadio";
      this.VerticalFillRadio.Size = new System.Drawing.Size(442, 19);
      this.VerticalFillRadio.TabIndex = 1;
      this.VerticalFillRadio.TabStop = true;
      this.VerticalFillRadio.Text = "Fill Vertically.  The Picture is Not Distorted.  Horizontal Scroll Bar Often Requ" +
    "ired";
      this.VerticalFillRadio.UseVisualStyleBackColor = true;
      // 
      // FixedRadio
      // 
      this.FixedRadio.AutoSize = true;
      this.FixedRadio.Location = new System.Drawing.Point(7, 123);
      this.FixedRadio.Name = "FixedRadio";
      this.FixedRadio.Size = new System.Drawing.Size(569, 19);
      this.FixedRadio.TabIndex = 3;
      this.FixedRadio.TabStop = true;
      this.FixedRadio.Text = "Fixed Width (1280x960), Variable Height.  Not Distorted.  Vertical/Horizontal Scr" +
    "oll Bars May Be Required";
      this.FixedRadio.UseVisualStyleBackColor = true;
      // 
      // FilledRadio
      // 
      this.FilledRadio.AutoSize = true;
      this.FilledRadio.Location = new System.Drawing.Point(7, 90);
      this.FilledRadio.Name = "FilledRadio";
      this.FilledRadio.Size = new System.Drawing.Size(460, 19);
      this.FilledRadio.TabIndex = 2;
      this.FilledRadio.TabStop = true;
      this.FilledRadio.Text = "Fill Horizontally and Vertically. Often the Picture is Distorted.  No Picture Scr" +
    "oll Bars";
      this.FilledRadio.UseVisualStyleBackColor = true;
      this.FilledRadio.CheckedChanged += new System.EventHandler(this.FilledRadio_CheckedChanged);
      // 
      // HorizontalFillRadio
      // 
      this.HorizontalFillRadio.AutoSize = true;
      this.HorizontalFillRadio.Location = new System.Drawing.Point(7, 24);
      this.HorizontalFillRadio.Name = "HorizontalFillRadio";
      this.HorizontalFillRadio.Size = new System.Drawing.Size(442, 19);
      this.HorizontalFillRadio.TabIndex = 0;
      this.HorizontalFillRadio.TabStop = true;
      this.HorizontalFillRadio.Text = "Fill Horizontally.  The Picture is Not Distorted.  Vertical Scroll Bar Often Requ" +
    "ired";
      this.HorizontalFillRadio.UseVisualStyleBackColor = true;
      // 
      // OKButton
      // 
      this.OKButton.Location = new System.Drawing.Point(285, 212);
      this.OKButton.Name = "OKButton";
      this.OKButton.Size = new System.Drawing.Size(75, 23);
      this.OKButton.TabIndex = 0;
      this.OKButton.Text = "OK";
      this.OKButton.UseVisualStyleBackColor = true;
      this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
      // 
      // CancelButton
      // 
      this.CancelButton.Location = new System.Drawing.Point(366, 212);
      this.CancelButton.Name = "CancelButton";
      this.CancelButton.Size = new System.Drawing.Size(75, 23);
      this.CancelButton.TabIndex = 1;
      this.CancelButton.Text = "Cancel";
      this.CancelButton.UseVisualStyleBackColor = true;
      this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
      // 
      // LiveCameraLabel
      // 
      this.LiveCameraLabel.AutoSize = true;
      this.LiveCameraLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.LiveCameraLabel.Location = new System.Drawing.Point(272, 9);
      this.LiveCameraLabel.Name = "LiveCameraLabel";
      this.LiveCameraLabel.Size = new System.Drawing.Size(182, 16);
      this.LiveCameraLabel.TabIndex = 44;
      this.LiveCameraLabel.Text = "Select The Display Mode";
      // 
      // DisplayMode
      // 
      this.AcceptButton = this.OKButton;
      this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
      this.ClientSize = new System.Drawing.Size(672, 242);
      this.Controls.Add(this.LiveCameraLabel);
      this.Controls.Add(this.CancelButton);
      this.Controls.Add(this.OKButton);
      this.Controls.Add(this.panel1);
      this.Name = "DisplayMode";
      this.Text = "Camera Display Mode";
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.RadioButton HorizontalFillRadio;
    private System.Windows.Forms.Button OKButton;
    private System.Windows.Forms.Button CancelButton;
    private System.Windows.Forms.Label LiveCameraLabel;
    private System.Windows.Forms.RadioButton FixedRadio;
    private System.Windows.Forms.RadioButton FilledRadio;
    private System.Windows.Forms.RadioButton VerticalFillRadio;
  }
}