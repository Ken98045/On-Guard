namespace OnGuardCore
{
  partial class PictureDateSelect
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
      this.CurrentPictureButton = new System.Windows.Forms.Button();
      this.KeepDateCheckbox = new System.Windows.Forms.CheckBox();
      this.label3 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.PictureTime = new System.Windows.Forms.DateTimePicker();
      this.PictureDate = new System.Windows.Forms.DateTimePicker();
      this.OKButton = new System.Windows.Forms.Button();
      this.CancelButton = new System.Windows.Forms.Button();
      this.panel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // panel1
      // 
      this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.panel1.Controls.Add(this.CurrentPictureButton);
      this.panel1.Controls.Add(this.KeepDateCheckbox);
      this.panel1.Controls.Add(this.label3);
      this.panel1.Controls.Add(this.label2);
      this.panel1.Controls.Add(this.label1);
      this.panel1.Controls.Add(this.PictureTime);
      this.panel1.Controls.Add(this.PictureDate);
      this.panel1.Location = new System.Drawing.Point(7, 12);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(501, 187);
      this.panel1.TabIndex = 0;
      // 
      // CurrentPictureButton
      // 
      this.CurrentPictureButton.Location = new System.Drawing.Point(25, 95);
      this.CurrentPictureButton.Name = "CurrentPictureButton";
      this.CurrentPictureButton.Size = new System.Drawing.Size(176, 23);
      this.CurrentPictureButton.TabIndex = 5;
      this.CurrentPictureButton.Text = "Current Picture Date/Time";
      this.CurrentPictureButton.UseVisualStyleBackColor = true;
      this.CurrentPictureButton.Click += new System.EventHandler(this.CurrentPictureButton_Click);
      // 
      // KeepDateCheckbox
      // 
      this.KeepDateCheckbox.AutoSize = true;
      this.KeepDateCheckbox.Checked = true;
      this.KeepDateCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
      this.KeepDateCheckbox.Location = new System.Drawing.Point(217, 98);
      this.KeepDateCheckbox.Name = "KeepDateCheckbox";
      this.KeepDateCheckbox.Size = new System.Drawing.Size(259, 19);
      this.KeepDateCheckbox.TabIndex = 2;
      this.KeepDateCheckbox.Text = "Keep Date/Time on Camera Change/Refresh";
      this.KeepDateCheckbox.UseVisualStyleBackColor = true;
      // 
      // label3
      // 
      this.label3.Location = new System.Drawing.Point(33, 135);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(432, 40);
      this.label3.TabIndex = 4;
      this.label3.Text = "The first picture on or after the entered date/time will be selected.  If there a" +
    "re no mathing pictures the last picture will be selected.";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.label2.Location = new System.Drawing.Point(154, 18);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(191, 17);
      this.label2.TabIndex = 3;
      this.label2.Text = "Select a Picture by Date/Time";
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.label1.Location = new System.Drawing.Point(57, 63);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(139, 15);
      this.label1.TabIndex = 2;
      this.label1.Text = "Select Picture Date/Time";
      // 
      // PictureTime
      // 
      this.PictureTime.CustomFormat = "hh:mm:ss tt";
      this.PictureTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
      this.PictureTime.Location = new System.Drawing.Point(340, 57);
      this.PictureTime.Name = "PictureTime";
      this.PictureTime.ShowUpDown = true;
      this.PictureTime.Size = new System.Drawing.Size(102, 23);
      this.PictureTime.TabIndex = 1;
      // 
      // PictureDate
      // 
      this.PictureDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
      this.PictureDate.Location = new System.Drawing.Point(226, 57);
      this.PictureDate.Name = "PictureDate";
      this.PictureDate.Size = new System.Drawing.Size(102, 23);
      this.PictureDate.TabIndex = 0;
      // 
      // OKButton
      // 
      this.OKButton.Location = new System.Drawing.Point(178, 212);
      this.OKButton.Name = "OKButton";
      this.OKButton.Size = new System.Drawing.Size(75, 23);
      this.OKButton.TabIndex = 0;
      this.OKButton.Text = "OK";
      this.OKButton.UseVisualStyleBackColor = true;
      this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
      // 
      // CancelButton
      // 
      this.CancelButton.Location = new System.Drawing.Point(262, 212);
      this.CancelButton.Name = "CancelButton";
      this.CancelButton.Size = new System.Drawing.Size(75, 23);
      this.CancelButton.TabIndex = 1;
      this.CancelButton.Text = "Cancel";
      this.CancelButton.UseVisualStyleBackColor = true;
      this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
      // 
      // PictureDateSelect
      // 
      this.AcceptButton = this.OKButton;
      this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
      this.ClientSize = new System.Drawing.Size(515, 246);
      this.Controls.Add(this.CancelButton);
      this.Controls.Add(this.OKButton);
      this.Controls.Add(this.panel1);
      this.Name = "PictureDateSelect";
      this.Text = "Select a Picture by Date/Time";
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.DateTimePicker PictureTime;
    private System.Windows.Forms.DateTimePicker PictureDate;
    private System.Windows.Forms.Button OKButton;
    private System.Windows.Forms.Button CancelButton;
    private System.Windows.Forms.CheckBox KeepDateCheckbox;
        private System.Windows.Forms.Button CurrentPictureButton;
    }
}