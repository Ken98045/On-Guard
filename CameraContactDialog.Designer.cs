namespace DeepStackDisplay
{
  partial class CameraContactDialog
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
      this.okButton = new System.Windows.Forms.Button();
      this.cancelButton = new System.Windows.Forms.Button();
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.label5 = new System.Windows.Forms.Label();
      this.label6 = new System.Windows.Forms.Label();
      this.cameraIPAddressText = new System.Windows.Forms.TextBox();
      this.portNumeric = new System.Windows.Forms.NumericUpDown();
      this.cameraNameText = new System.Windows.Forms.TextBox();
      this.cameraUserText = new System.Windows.Forms.TextBox();
      this.cameraPasswordText = new System.Windows.Forms.TextBox();
      this.label7 = new System.Windows.Forms.Label();
      this.cameraXResolutionNumeric = new System.Windows.Forms.NumericUpDown();
      this.label8 = new System.Windows.Forms.Label();
      this.cameraYResolutionNumeric = new System.Windows.Forms.NumericUpDown();
      this.label9 = new System.Windows.Forms.Label();
      this.label10 = new System.Windows.Forms.Label();
      ((System.ComponentModel.ISupportInitialize)(this.portNumeric)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.cameraXResolutionNumeric)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.cameraYResolutionNumeric)).BeginInit();
      this.SuspendLayout();
      // 
      // okButton
      // 
      this.okButton.Location = new System.Drawing.Point(180, 333);
      this.okButton.Name = "okButton";
      this.okButton.Size = new System.Drawing.Size(75, 23);
      this.okButton.TabIndex = 0;
      this.okButton.Text = "OK";
      this.okButton.UseVisualStyleBackColor = true;
      this.okButton.Click += new System.EventHandler(this.OkButton_Click);
      // 
      // cancelButton
      // 
      this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.cancelButton.Location = new System.Drawing.Point(274, 333);
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
      this.label1.Location = new System.Drawing.Point(12, 70);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(247, 13);
      this.label1.TabIndex = 2;
      this.label1.Text = "Camera IP Address (or localhost for this computer): ";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(177, 105);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(82, 13);
      this.label2.TabIndex = 3;
      this.label2.Text = "Port (Often 80): ";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(151, 140);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(108, 13);
      this.label3.TabIndex = 4;
      this.label3.Text = "Short Camera Name: ";
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(154, 175);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(105, 13);
      this.label4.TabIndex = 5;
      this.label4.Text = "Camera User Name: ";
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(161, 210);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(98, 13);
      this.label5.TabIndex = 6;
      this.label5.Text = "Camera Password: ";
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Location = new System.Drawing.Point(136, 26);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(221, 13);
      this.label6.TabIndex = 7;
      this.label6.Text = "Enter the data to contact the Blue Iris camera";
      // 
      // cameraIPAddressText
      // 
      this.cameraIPAddressText.Location = new System.Drawing.Point(274, 67);
      this.cameraIPAddressText.Name = "cameraIPAddressText";
      this.cameraIPAddressText.Size = new System.Drawing.Size(100, 20);
      this.cameraIPAddressText.TabIndex = 8;
      this.cameraIPAddressText.Text = "localhost";
      // 
      // portNumeric
      // 
      this.portNumeric.Location = new System.Drawing.Point(274, 103);
      this.portNumeric.Maximum = new decimal(new int[] {
            65553,
            0,
            0,
            0});
      this.portNumeric.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
      this.portNumeric.Name = "portNumeric";
      this.portNumeric.Size = new System.Drawing.Size(71, 20);
      this.portNumeric.TabIndex = 9;
      this.portNumeric.Value = new decimal(new int[] {
            80,
            0,
            0,
            0});
      // 
      // cameraNameText
      // 
      this.cameraNameText.Location = new System.Drawing.Point(274, 137);
      this.cameraNameText.Name = "cameraNameText";
      this.cameraNameText.Size = new System.Drawing.Size(100, 20);
      this.cameraNameText.TabIndex = 10;
      // 
      // cameraUserText
      // 
      this.cameraUserText.Location = new System.Drawing.Point(274, 172);
      this.cameraUserText.Name = "cameraUserText";
      this.cameraUserText.Size = new System.Drawing.Size(100, 20);
      this.cameraUserText.TabIndex = 11;
      // 
      // cameraPasswordText
      // 
      this.cameraPasswordText.Location = new System.Drawing.Point(274, 207);
      this.cameraPasswordText.Name = "cameraPasswordText";
      this.cameraPasswordText.Size = new System.Drawing.Size(100, 20);
      this.cameraPasswordText.TabIndex = 12;
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.Location = new System.Drawing.Point(153, 245);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(106, 13);
      this.label7.TabIndex = 13;
      this.label7.Text = "Camera X Resolution";
      // 
      // cameraXResolutionNumeric
      // 
      this.cameraXResolutionNumeric.Location = new System.Drawing.Point(278, 243);
      this.cameraXResolutionNumeric.Maximum = new decimal(new int[] {
            65553,
            0,
            0,
            0});
      this.cameraXResolutionNumeric.Name = "cameraXResolutionNumeric";
      this.cameraXResolutionNumeric.Size = new System.Drawing.Size(71, 20);
      this.cameraXResolutionNumeric.TabIndex = 14;
      this.cameraXResolutionNumeric.Value = new decimal(new int[] {
            2560,
            0,
            0,
            0});
      // 
      // label8
      // 
      this.label8.AutoSize = true;
      this.label8.Location = new System.Drawing.Point(153, 280);
      this.label8.Name = "label8";
      this.label8.Size = new System.Drawing.Size(106, 13);
      this.label8.TabIndex = 15;
      this.label8.Text = "Camera Y Resolution";
      // 
      // cameraYResolutionNumeric
      // 
      this.cameraYResolutionNumeric.Location = new System.Drawing.Point(274, 278);
      this.cameraYResolutionNumeric.Maximum = new decimal(new int[] {
            65553,
            0,
            0,
            0});
      this.cameraYResolutionNumeric.Name = "cameraYResolutionNumeric";
      this.cameraYResolutionNumeric.Size = new System.Drawing.Size(71, 20);
      this.cameraYResolutionNumeric.TabIndex = 16;
      this.cameraYResolutionNumeric.Value = new decimal(new int[] {
            1920,
            0,
            0,
            0});
      // 
      // label9
      // 
      this.label9.AutoSize = true;
      this.label9.Location = new System.Drawing.Point(375, 245);
      this.label9.Name = "label9";
      this.label9.Size = new System.Drawing.Size(83, 13);
      this.label9.TabIndex = 17;
      this.label9.Text = "Zero for Not Set";
      // 
      // label10
      // 
      this.label10.AutoSize = true;
      this.label10.Location = new System.Drawing.Point(375, 280);
      this.label10.Name = "label10";
      this.label10.Size = new System.Drawing.Size(83, 13);
      this.label10.TabIndex = 18;
      this.label10.Text = "Zero for Not Set";
      // 
      // CameraContactDialog
      // 
      this.AcceptButton = this.okButton;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.cancelButton;
      this.ClientSize = new System.Drawing.Size(493, 370);
      this.Controls.Add(this.label10);
      this.Controls.Add(this.label9);
      this.Controls.Add(this.cameraYResolutionNumeric);
      this.Controls.Add(this.label8);
      this.Controls.Add(this.cameraXResolutionNumeric);
      this.Controls.Add(this.label7);
      this.Controls.Add(this.cameraPasswordText);
      this.Controls.Add(this.cameraUserText);
      this.Controls.Add(this.cameraNameText);
      this.Controls.Add(this.portNumeric);
      this.Controls.Add(this.cameraIPAddressText);
      this.Controls.Add(this.label6);
      this.Controls.Add(this.label5);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.cancelButton);
      this.Controls.Add(this.okButton);
      this.Name = "CameraContactDialog";
      this.Text = "Get Camera Contact Information";
      ((System.ComponentModel.ISupportInitialize)(this.portNumeric)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.cameraXResolutionNumeric)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.cameraYResolutionNumeric)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

        #endregion

        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox cameraIPAddressText;
        private System.Windows.Forms.NumericUpDown portNumeric;
        private System.Windows.Forms.TextBox cameraNameText;
        private System.Windows.Forms.TextBox cameraUserText;
        private System.Windows.Forms.TextBox cameraPasswordText;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown cameraXResolutionNumeric;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown cameraYResolutionNumeric;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
    }
}