
namespace OnGuardCore
{
  partial class PTZMovement
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PTZMovement));
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.NumericPanTime = new System.Windows.Forms.NumericUpDown();
      this.NumericTiltTime = new System.Windows.Forms.NumericUpDown();
      this.NumericZoomTime = new System.Windows.Forms.NumericUpDown();
      this.label5 = new System.Windows.Forms.Label();
      this.label7 = new System.Windows.Forms.Label();
      this.NumericZoomSpeed = new System.Windows.Forms.NumericUpDown();
      this.NumericTiltSpeed = new System.Windows.Forms.NumericUpDown();
      this.NumericPanSpeed = new System.Windows.Forms.NumericUpDown();
      this.OKButton = new System.Windows.Forms.Button();
      this.FormCancelButton = new System.Windows.Forms.Button();
      this.panel1 = new System.Windows.Forms.Panel();
      this.label9 = new System.Windows.Forms.Label();
      this.zoomOutButton = new System.Windows.Forms.Button();
      this.zoomInButton = new System.Windows.Forms.Button();
      this.camDownButton = new System.Windows.Forms.Button();
      this.camRightButton = new System.Windows.Forms.Button();
      this.camLeftButton = new System.Windows.Forms.Button();
      this.camUpButton = new System.Windows.Forms.Button();
      this.label8 = new System.Windows.Forms.Label();
      this.panel2 = new System.Windows.Forms.Panel();
      this.PictureImageBox = new System.Windows.Forms.PictureBox();
      this.labelCameraName = new System.Windows.Forms.Label();
      this.FormHelpButton = new System.Windows.Forms.Button();
      this.label6 = new System.Windows.Forms.Label();
      ((System.ComponentModel.ISupportInitialize)(this.NumericPanTime)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.NumericTiltTime)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.NumericZoomTime)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.NumericZoomSpeed)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.NumericTiltSpeed)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.NumericPanSpeed)).BeginInit();
      this.panel1.SuspendLayout();
      this.panel2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.PictureImageBox)).BeginInit();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.label1.Location = new System.Drawing.Point(265, 24);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(208, 16);
      this.label1.TabIndex = 29;
      this.label1.Text = "Pan Tilt and Zoom Movement";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.label2.Location = new System.Drawing.Point(147, 21);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(114, 16);
      this.label2.TabIndex = 31;
      this.label2.Text = "Left/Right (Pan)";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.label3.Location = new System.Drawing.Point(325, 21);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(106, 16);
      this.label3.TabIndex = 32;
      this.label3.Text = "Up/Down (Tilt)";
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.label4.Location = new System.Drawing.Point(495, 21);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(100, 16);
      this.label4.TabIndex = 33;
      this.label4.Text = "In/Out (Zoom)";
      // 
      // NumericPanTime
      // 
      this.NumericPanTime.DecimalPlaces = 3;
      this.NumericPanTime.Location = new System.Drawing.Point(141, 49);
      this.NumericPanTime.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
      this.NumericPanTime.Name = "NumericPanTime";
      this.NumericPanTime.Size = new System.Drawing.Size(120, 23);
      this.NumericPanTime.TabIndex = 34;
      this.NumericPanTime.Value = new decimal(new int[] {
            10,
            0,
            0,
            65536});
      // 
      // NumericTiltTime
      // 
      this.NumericTiltTime.DecimalPlaces = 3;
      this.NumericTiltTime.Location = new System.Drawing.Point(325, 49);
      this.NumericTiltTime.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
      this.NumericTiltTime.Name = "NumericTiltTime";
      this.NumericTiltTime.Size = new System.Drawing.Size(120, 23);
      this.NumericTiltTime.TabIndex = 35;
      this.NumericTiltTime.Value = new decimal(new int[] {
            10,
            0,
            0,
            65536});
      // 
      // NumericZoomTime
      // 
      this.NumericZoomTime.DecimalPlaces = 3;
      this.NumericZoomTime.Location = new System.Drawing.Point(495, 49);
      this.NumericZoomTime.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
      this.NumericZoomTime.Name = "NumericZoomTime";
      this.NumericZoomTime.Size = new System.Drawing.Size(120, 23);
      this.NumericZoomTime.TabIndex = 36;
      this.NumericZoomTime.Value = new decimal(new int[] {
            10,
            0,
            0,
            65536});
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.label5.Location = new System.Drawing.Point(50, 56);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(42, 16);
      this.label5.TabIndex = 37;
      this.label5.Text = "Time";
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.label7.Location = new System.Drawing.Point(50, 81);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(59, 16);
      this.label7.TabIndex = 41;
      this.label7.Text = "Speed*";
      // 
      // NumericZoomSpeed
      // 
      this.NumericZoomSpeed.DecimalPlaces = 3;
      this.NumericZoomSpeed.Location = new System.Drawing.Point(495, 80);
      this.NumericZoomSpeed.Name = "NumericZoomSpeed";
      this.NumericZoomSpeed.Size = new System.Drawing.Size(120, 23);
      this.NumericZoomSpeed.TabIndex = 40;
      this.NumericZoomSpeed.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
      // 
      // NumericTiltSpeed
      // 
      this.NumericTiltSpeed.DecimalPlaces = 3;
      this.NumericTiltSpeed.Location = new System.Drawing.Point(325, 80);
      this.NumericTiltSpeed.Name = "NumericTiltSpeed";
      this.NumericTiltSpeed.Size = new System.Drawing.Size(120, 23);
      this.NumericTiltSpeed.TabIndex = 39;
      this.NumericTiltSpeed.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
      // 
      // NumericPanSpeed
      // 
      this.NumericPanSpeed.DecimalPlaces = 3;
      this.NumericPanSpeed.Location = new System.Drawing.Point(141, 80);
      this.NumericPanSpeed.Name = "NumericPanSpeed";
      this.NumericPanSpeed.Size = new System.Drawing.Size(120, 23);
      this.NumericPanSpeed.TabIndex = 38;
      this.NumericPanSpeed.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
      // 
      // OKButton
      // 
      this.OKButton.Location = new System.Drawing.Point(158, 445);
      this.OKButton.Name = "OKButton";
      this.OKButton.Size = new System.Drawing.Size(75, 23);
      this.OKButton.TabIndex = 42;
      this.OKButton.Text = "OK";
      this.OKButton.UseVisualStyleBackColor = true;
      this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
      // 
      // FormCancelButton
      // 
      this.FormCancelButton.Location = new System.Drawing.Point(248, 445);
      this.FormCancelButton.Name = "FormCancelButton";
      this.FormCancelButton.Size = new System.Drawing.Size(75, 23);
      this.FormCancelButton.TabIndex = 43;
      this.FormCancelButton.Text = "Cancel";
      this.FormCancelButton.UseVisualStyleBackColor = true;
      this.FormCancelButton.Click += new System.EventHandler(this.CancelButton_Click);
      // 
      // panel1
      // 
      this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.panel1.Controls.Add(this.label9);
      this.panel1.Controls.Add(this.zoomOutButton);
      this.panel1.Controls.Add(this.zoomInButton);
      this.panel1.Controls.Add(this.camDownButton);
      this.panel1.Controls.Add(this.camRightButton);
      this.panel1.Controls.Add(this.camLeftButton);
      this.panel1.Controls.Add(this.camUpButton);
      this.panel1.Controls.Add(this.label8);
      this.panel1.Location = new System.Drawing.Point(120, 256);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(253, 150);
      this.panel1.TabIndex = 44;
      // 
      // label9
      // 
      this.label9.AutoSize = true;
      this.label9.Location = new System.Drawing.Point(71, 119);
      this.label9.Name = "label9";
      this.label9.Size = new System.Drawing.Size(108, 15);
      this.label9.TabIndex = 37;
      this.label9.Text = "(Deliberately Slow!)";
      // 
      // zoomOutButton
      // 
      this.zoomOutButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
      this.zoomOutButton.Image = ((System.Drawing.Image)(resources.GetObject("zoomOutButton.Image")));
      this.zoomOutButton.Location = new System.Drawing.Point(86, 79);
      this.zoomOutButton.Name = "zoomOutButton";
      this.zoomOutButton.Size = new System.Drawing.Size(25, 25);
      this.zoomOutButton.TabIndex = 36;
      this.zoomOutButton.UseVisualStyleBackColor = true;
      this.zoomOutButton.Click += new System.EventHandler(this.CamZoomOut_Click);
      // 
      // zoomInButton
      // 
      this.zoomInButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
      this.zoomInButton.Image = ((System.Drawing.Image)(resources.GetObject("zoomInButton.Image")));
      this.zoomInButton.Location = new System.Drawing.Point(140, 29);
      this.zoomInButton.Name = "zoomInButton";
      this.zoomInButton.Size = new System.Drawing.Size(25, 25);
      this.zoomInButton.TabIndex = 35;
      this.zoomInButton.UseVisualStyleBackColor = true;
      this.zoomInButton.Click += new System.EventHandler(this.ZoomInButton_Click);
      // 
      // camDownButton
      // 
      this.camDownButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
      this.camDownButton.Image = ((System.Drawing.Image)(resources.GetObject("camDownButton.Image")));
      this.camDownButton.Location = new System.Drawing.Point(114, 78);
      this.camDownButton.Name = "camDownButton";
      this.camDownButton.Size = new System.Drawing.Size(25, 25);
      this.camDownButton.TabIndex = 32;
      this.camDownButton.UseVisualStyleBackColor = true;
      this.camDownButton.Click += new System.EventHandler(this.CamDownButton_Click);
      // 
      // camRightButton
      // 
      this.camRightButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
      this.camRightButton.Image = ((System.Drawing.Image)(resources.GetObject("camRightButton.Image")));
      this.camRightButton.Location = new System.Drawing.Point(140, 54);
      this.camRightButton.Name = "camRightButton";
      this.camRightButton.Size = new System.Drawing.Size(25, 25);
      this.camRightButton.TabIndex = 34;
      this.camRightButton.UseVisualStyleBackColor = true;
      this.camRightButton.Click += new System.EventHandler(this.CamRightButton_Click);
      // 
      // camLeftButton
      // 
      this.camLeftButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
      this.camLeftButton.Image = ((System.Drawing.Image)(resources.GetObject("camLeftButton.Image")));
      this.camLeftButton.Location = new System.Drawing.Point(86, 54);
      this.camLeftButton.Name = "camLeftButton";
      this.camLeftButton.Size = new System.Drawing.Size(25, 25);
      this.camLeftButton.TabIndex = 33;
      this.camLeftButton.UseVisualStyleBackColor = true;
      this.camLeftButton.Click += new System.EventHandler(this.CamLeftButton_Click);
      // 
      // camUpButton
      // 
      this.camUpButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
      this.camUpButton.Image = ((System.Drawing.Image)(resources.GetObject("camUpButton.Image")));
      this.camUpButton.Location = new System.Drawing.Point(114, 32);
      this.camUpButton.Name = "camUpButton";
      this.camUpButton.Size = new System.Drawing.Size(25, 25);
      this.camUpButton.TabIndex = 31;
      this.camUpButton.UseVisualStyleBackColor = true;
      this.camUpButton.Click += new System.EventHandler(this.CamUpButton_Click);
      // 
      // label8
      // 
      this.label8.Anchor = System.Windows.Forms.AnchorStyles.Top;
      this.label8.AutoSize = true;
      this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.label8.Location = new System.Drawing.Point(43, 6);
      this.label8.Name = "label8";
      this.label8.Size = new System.Drawing.Size(165, 16);
      this.label8.TabIndex = 30;
      this.label8.Text = "Test Movement Values";
      // 
      // panel2
      // 
      this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.panel2.Controls.Add(this.label6);
      this.panel2.Controls.Add(this.label3);
      this.panel2.Controls.Add(this.label2);
      this.panel2.Controls.Add(this.label4);
      this.panel2.Controls.Add(this.NumericPanTime);
      this.panel2.Controls.Add(this.label7);
      this.panel2.Controls.Add(this.NumericTiltTime);
      this.panel2.Controls.Add(this.NumericZoomSpeed);
      this.panel2.Controls.Add(this.NumericZoomTime);
      this.panel2.Controls.Add(this.NumericTiltSpeed);
      this.panel2.Controls.Add(this.label5);
      this.panel2.Controls.Add(this.NumericPanSpeed);
      this.panel2.Location = new System.Drawing.Point(23, 92);
      this.panel2.Name = "panel2";
      this.panel2.Size = new System.Drawing.Size(667, 146);
      this.panel2.TabIndex = 45;
      // 
      // PictureImageBox
      // 
      this.PictureImageBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.PictureImageBox.Location = new System.Drawing.Point(395, 256);
      this.PictureImageBox.Name = "PictureImageBox";
      this.PictureImageBox.Size = new System.Drawing.Size(320, 240);
      this.PictureImageBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
      this.PictureImageBox.TabIndex = 46;
      this.PictureImageBox.TabStop = false;
      // 
      // labelCameraName
      // 
      this.labelCameraName.AutoSize = true;
      this.labelCameraName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.labelCameraName.Location = new System.Drawing.Point(308, 53);
      this.labelCameraName.Name = "labelCameraName";
      this.labelCameraName.Size = new System.Drawing.Size(122, 16);
      this.labelCameraName.TabIndex = 47;
      this.labelCameraName.Text = "Current Camera: ";
      // 
      // FormHelpButton
      // 
      this.FormHelpButton.Location = new System.Drawing.Point(640, 510);
      this.FormHelpButton.Name = "FormHelpButton";
      this.FormHelpButton.Size = new System.Drawing.Size(75, 23);
      this.FormHelpButton.TabIndex = 48;
      this.FormHelpButton.Text = "Help!";
      this.FormHelpButton.UseVisualStyleBackColor = true;
      this.FormHelpButton.Click += new System.EventHandler(this.HelpButton_Click);
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Location = new System.Drawing.Point(50, 117);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(233, 15);
      this.label6.TabIndex = 42;
      this.label6.Text = "*Many cameras do not have speed settings";
      // 
      // PTZMovement
      // 
      this.AcceptButton = this.OKButton;
      this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
      this.AutoScroll = true;
      this.ClientSize = new System.Drawing.Size(738, 538);
      this.Controls.Add(this.FormHelpButton);
      this.Controls.Add(this.labelCameraName);
      this.Controls.Add(this.PictureImageBox);
      this.Controls.Add(this.panel2);
      this.Controls.Add(this.panel1);
      this.Controls.Add(this.FormCancelButton);
      this.Controls.Add(this.OKButton);
      this.Controls.Add(this.label1);
      this.Name = "PTZMovement";
      this.Text = "PTZ  Movement";
      this.Load += new System.EventHandler(this.PTZMovement_Load);
      ((System.ComponentModel.ISupportInitialize)(this.NumericPanTime)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.NumericTiltTime)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.NumericZoomTime)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.NumericZoomSpeed)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.NumericTiltSpeed)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.NumericPanSpeed)).EndInit();
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.panel2.ResumeLayout(false);
      this.panel2.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.PictureImageBox)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.NumericUpDown NumericPanTime;
    private System.Windows.Forms.NumericUpDown NumericTiltTime;
    private System.Windows.Forms.NumericUpDown NumericZoomTime;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.NumericUpDown NumericZoomSpeed;
    private System.Windows.Forms.NumericUpDown NumericTiltSpeed;
    private System.Windows.Forms.NumericUpDown NumericPanSpeed;
    private System.Windows.Forms.Button OKButton;
    private System.Windows.Forms.Button FormCancelButton;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.Button zoomOutButton;
    private System.Windows.Forms.Button zoomInButton;
    private System.Windows.Forms.Button camDownButton;
    private System.Windows.Forms.Button camRightButton;
    private System.Windows.Forms.Button camLeftButton;
    private System.Windows.Forms.Button camUpButton;
    private System.Windows.Forms.Panel panel2;
    private System.Windows.Forms.PictureBox PictureImageBox;
    private System.Windows.Forms.Label label9;
    private System.Windows.Forms.Label labelCameraName;
    private System.Windows.Forms.Button FormHelpButton;
    private System.Windows.Forms.Label label6;
  }
}