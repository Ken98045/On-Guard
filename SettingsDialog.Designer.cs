namespace SAAI
{
  partial class SettingsDialog
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsDialog));
      this.okButton = new System.Windows.Forms.Button();
      this.cancelButton = new System.Windows.Forms.Button();
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.ipAddresText = new System.Windows.Forms.TextBox();
      this.portNumeric = new System.Windows.Forms.NumericUpDown();
      this.label3 = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.label5 = new System.Windows.Forms.Label();
      this.snapshotNumeric = new System.Windows.Forms.NumericUpDown();
      this.label6 = new System.Windows.Forms.Label();
      this.panel1 = new System.Windows.Forms.Panel();
      this.panel2 = new System.Windows.Forms.Panel();
      this.label13 = new System.Windows.Forms.Label();
      this.label10 = new System.Windows.Forms.Label();
      this.label11 = new System.Windows.Forms.Label();
      this.eventIntervalNumeric = new System.Windows.Forms.NumericUpDown();
      this.label8 = new System.Windows.Forms.Label();
      this.label9 = new System.Windows.Forms.Label();
      this.maxEventNumeric = new System.Windows.Forms.NumericUpDown();
      this.label7 = new System.Windows.Forms.Label();
      this.testButton = new System.Windows.Forms.Button();
      this.label12 = new System.Windows.Forms.Label();
      ((System.ComponentModel.ISupportInitialize)(this.portNumeric)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.snapshotNumeric)).BeginInit();
      this.panel1.SuspendLayout();
      this.panel2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.eventIntervalNumeric)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.maxEventNumeric)).BeginInit();
      this.SuspendLayout();
      // 
      // okButton
      // 
      this.okButton.Location = new System.Drawing.Point(260, 482);
      this.okButton.Name = "okButton";
      this.okButton.Size = new System.Drawing.Size(75, 23);
      this.okButton.TabIndex = 0;
      this.okButton.Text = "OK";
      this.okButton.UseVisualStyleBackColor = true;
      this.okButton.Click += new System.EventHandler(this.OkButton_Click);
      // 
      // cancelButton
      // 
      this.cancelButton.Location = new System.Drawing.Point(350, 482);
      this.cancelButton.Name = "cancelButton";
      this.cancelButton.Size = new System.Drawing.Size(75, 23);
      this.cancelButton.TabIndex = 1;
      this.cancelButton.Text = "Cancel";
      this.cancelButton.UseVisualStyleBackColor = true;
      this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(47, 54);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(238, 13);
      this.label1.TabIndex = 2;
      this.label1.Text = "IP Address or computer name  of the  AI:";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(432, 54);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(218, 13);
      this.label2.TabIndex = 3;
      this.label2.Text = "For this computer leave it \"localhost\"";
      // 
      // ipAddresText
      // 
      this.ipAddresText.Location = new System.Drawing.Point(300, 51);
      this.ipAddresText.Name = "ipAddresText";
      this.ipAddresText.Size = new System.Drawing.Size(134, 20);
      this.ipAddresText.TabIndex = 0;
      this.ipAddresText.Text = "localhost";
      // 
      // portNumeric
      // 
      this.portNumeric.Location = new System.Drawing.Point(300, 93);
      this.portNumeric.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
      this.portNumeric.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
      this.portNumeric.Name = "portNumeric";
      this.portNumeric.Size = new System.Drawing.Size(89, 20);
      this.portNumeric.TabIndex = 1;
      this.portNumeric.Value = new decimal(new int[] {
            80,
            0,
            0,
            0});
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(143, 93);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(142, 13);
      this.label3.TabIndex = 6;
      this.label3.Text = "Port Number fo the AI:  ";
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label4.Location = new System.Drawing.Point(205, 10);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(208, 16);
      this.label4.TabIndex = 7;
      this.label4.Text = "Location of the DeepStack AI";
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(31, 54);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(96, 13);
      this.label5.TabIndex = 8;
      this.label5.Text = "Snapshot Interval: ";
      // 
      // snapshotNumeric
      // 
      this.snapshotNumeric.DecimalPlaces = 1;
      this.snapshotNumeric.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
      this.snapshotNumeric.Location = new System.Drawing.Point(133, 52);
      this.snapshotNumeric.Maximum = new decimal(new int[] {
            120,
            0,
            0,
            0});
      this.snapshotNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
      this.snapshotNumeric.Name = "snapshotNumeric";
      this.snapshotNumeric.Size = new System.Drawing.Size(55, 20);
      this.snapshotNumeric.TabIndex = 0;
      this.snapshotNumeric.Value = new decimal(new int[] {
            10,
            0,
            0,
            65536});
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Location = new System.Drawing.Point(198, 59);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(379, 13);
      this.label6.TabIndex = 10;
      this.label6.Text = "Seconds -  Typically from Blue Iris Camera Settings.  The time between pictures";
      // 
      // panel1
      // 
      this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.panel1.Controls.Add(this.label12);
      this.panel1.Controls.Add(this.testButton);
      this.panel1.Controls.Add(this.portNumeric);
      this.panel1.Controls.Add(this.label4);
      this.panel1.Controls.Add(this.label3);
      this.panel1.Controls.Add(this.label2);
      this.panel1.Controls.Add(this.label1);
      this.panel1.Controls.Add(this.ipAddresText);
      this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.panel1.Location = new System.Drawing.Point(23, 13);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(629, 173);
      this.panel1.TabIndex = 11;
      // 
      // panel2
      // 
      this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.panel2.Controls.Add(this.label13);
      this.panel2.Controls.Add(this.label10);
      this.panel2.Controls.Add(this.label11);
      this.panel2.Controls.Add(this.eventIntervalNumeric);
      this.panel2.Controls.Add(this.label8);
      this.panel2.Controls.Add(this.label9);
      this.panel2.Controls.Add(this.maxEventNumeric);
      this.panel2.Controls.Add(this.label7);
      this.panel2.Controls.Add(this.label6);
      this.panel2.Controls.Add(this.label5);
      this.panel2.Controls.Add(this.snapshotNumeric);
      this.panel2.Location = new System.Drawing.Point(23, 207);
      this.panel2.Name = "panel2";
      this.panel2.Size = new System.Drawing.Size(629, 258);
      this.panel2.TabIndex = 12;
      // 
      // label13
      // 
      this.label13.Location = new System.Drawing.Point(198, 178);
      this.label13.Name = "label13";
      this.label13.Size = new System.Drawing.Size(382, 53);
      this.label13.TabIndex = 16;
      this.label13.Text = resources.GetString("label13.Text");
      // 
      // label10
      // 
      this.label10.Location = new System.Drawing.Point(198, 185);
      this.label10.Name = "label10";
      this.label10.Size = new System.Drawing.Size(382, 32);
      this.label10.TabIndex = 16;
      this.label10.Text = "Minutes -  When motion is detected capture pictures this long.  Used primarily fo" +
    "r email.\r\n";
      // 
      // label11
      // 
      this.label11.AutoSize = true;
      this.label11.Location = new System.Drawing.Point(10, 185);
      this.label11.Name = "label11";
      this.label11.Size = new System.Drawing.Size(117, 13);
      this.label11.TabIndex = 15;
      this.label11.Text = "Time Between Events: ";
      // 
      // eventIntervalNumeric
      // 
      this.eventIntervalNumeric.Location = new System.Drawing.Point(133, 183);
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
      this.eventIntervalNumeric.Size = new System.Drawing.Size(55, 20);
      this.eventIntervalNumeric.TabIndex = 2;
      this.eventIntervalNumeric.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
      // 
      // label8
      // 
      this.label8.Location = new System.Drawing.Point(198, 92);
      this.label8.Name = "label8";
      this.label8.Size = new System.Drawing.Size(386, 72);
      this.label8.TabIndex = 13;
      this.label8.Text = resources.GetString("label8.Text");
      // 
      // label9
      // 
      this.label9.AutoSize = true;
      this.label9.Location = new System.Drawing.Point(13, 98);
      this.label9.Name = "label9";
      this.label9.Size = new System.Drawing.Size(114, 13);
      this.label9.TabIndex = 12;
      this.label9.Text = "Maximum Event Time: ";
      // 
      // maxEventNumeric
      // 
      this.maxEventNumeric.Location = new System.Drawing.Point(133, 96);
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
      this.maxEventNumeric.Size = new System.Drawing.Size(55, 20);
      this.maxEventNumeric.TabIndex = 1;
      this.maxEventNumeric.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label7.Location = new System.Drawing.Point(198, 13);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(211, 16);
      this.label7.TabIndex = 8;
      this.label7.Text = "Image Capture and Reporting";
      // 
      // testButton
      // 
      this.testButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
      this.testButton.Location = new System.Drawing.Point(218, 130);
      this.testButton.Name = "testButton";
      this.testButton.Size = new System.Drawing.Size(191, 28);
      this.testButton.TabIndex = 8;
      this.testButton.Text = "Test DeepStack Connection";
      this.testButton.UseVisualStyleBackColor = false;
      this.testButton.Click += new System.EventHandler(this.testButton_Click);
      // 
      // label12
      // 
      this.label12.AutoSize = true;
      this.label12.Location = new System.Drawing.Point(414, 138);
      this.label12.Name = "label12";
      this.label12.Size = new System.Drawing.Size(91, 13);
      this.label12.TabIndex = 9;
      this.label12.Text = "<---- Important!";
      // 
      // SettingsDialog
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
      this.ClientSize = new System.Drawing.Size(684, 515);
      this.Controls.Add(this.panel2);
      this.Controls.Add(this.panel1);
      this.Controls.Add(this.cancelButton);
      this.Controls.Add(this.okButton);
      this.Name = "SettingsDialog";
      this.Text = "Application Settings";
      ((System.ComponentModel.ISupportInitialize)(this.portNumeric)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.snapshotNumeric)).EndInit();
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.panel2.ResumeLayout(false);
      this.panel2.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.eventIntervalNumeric)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.maxEventNumeric)).EndInit();
      this.ResumeLayout(false);

    }

        #endregion

        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ipAddresText;
        private System.Windows.Forms.NumericUpDown portNumeric;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown snapshotNumeric;
        private System.Windows.Forms.Label label6;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Panel panel2;
    private System.Windows.Forms.Label label10;
    private System.Windows.Forms.Label label11;
    private System.Windows.Forms.NumericUpDown eventIntervalNumeric;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.Label label9;
    private System.Windows.Forms.NumericUpDown maxEventNumeric;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.Label label13;
    private System.Windows.Forms.Button testButton;
    private System.Windows.Forms.Label label12;
  }
}