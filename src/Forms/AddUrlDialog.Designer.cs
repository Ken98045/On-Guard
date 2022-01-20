namespace OnGuardCore
{
  partial class AddUrlDialog
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
      this.urlText = new System.Windows.Forms.TextBox();
      this.urlCoolDownNumeric = new System.Windows.Forms.NumericUpDown();
      this.label2 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.panel1 = new System.Windows.Forms.Panel();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.ConfirmCheckBox = new System.Windows.Forms.CheckBox();
      this.label5 = new System.Windows.Forms.Label();
      this.AutoFillButton = new System.Windows.Forms.Button();
      this.ResetCheckBox = new System.Windows.Forms.CheckBox();
      this.FlagCheckBox = new System.Windows.Forms.CheckBox();
      this.label6 = new System.Windows.Forms.Label();
      this.WaitTimeNumeric = new System.Windows.Forms.NumericUpDown();
      this.label7 = new System.Windows.Forms.Label();
      ((System.ComponentModel.ISupportInitialize)(this.urlCoolDownNumeric)).BeginInit();
      this.panel1.SuspendLayout();
      this.groupBox1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.WaitTimeNumeric)).BeginInit();
      this.SuspendLayout();
      // 
      // okButton
      // 
      this.okButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.okButton.Location = new System.Drawing.Point(186, 376);
      this.okButton.Name = "okButton";
      this.okButton.Size = new System.Drawing.Size(75, 23);
      this.okButton.TabIndex = 0;
      this.okButton.Text = "OK";
      this.okButton.UseVisualStyleBackColor = true;
      this.okButton.Click += new System.EventHandler(this.OkButton_Click);
      // 
      // cancelButton
      // 
      this.cancelButton.Location = new System.Drawing.Point(282, 376);
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
      this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.label1.Location = new System.Drawing.Point(172, 10);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(172, 15);
      this.label1.TabIndex = 2;
      this.label1.Text = "Trigger URL Sent Via Http";
      // 
      // urlText
      // 
      this.urlText.Location = new System.Drawing.Point(44, 38);
      this.urlText.Name = "urlText";
      this.urlText.Size = new System.Drawing.Size(421, 23);
      this.urlText.TabIndex = 0;
      // 
      // urlCoolDownNumeric
      // 
      this.urlCoolDownNumeric.Location = new System.Drawing.Point(181, 290);
      this.urlCoolDownNumeric.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
      this.urlCoolDownNumeric.Name = "urlCoolDownNumeric";
      this.urlCoolDownNumeric.Size = new System.Drawing.Size(75, 23);
      this.urlCoolDownNumeric.TabIndex = 2;
      this.urlCoolDownNumeric.Value = new decimal(new int[] {
            300,
            0,
            0,
            0});
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(276, 290);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(268, 15);
      this.label2.TabIndex = 28;
      this.label2.Text = "Minimum Time Between Notifications in Seconds";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(72, 292);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(101, 15);
      this.label3.TabIndex = 29;
      this.label3.Text = "Cool Down Time: ";
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(12, 41);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(28, 15);
      this.label4.TabIndex = 30;
      this.label4.Text = "URL";
      // 
      // panel1
      // 
      this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.panel1.Controls.Add(this.groupBox1);
      this.panel1.Controls.Add(this.label6);
      this.panel1.Controls.Add(this.WaitTimeNumeric);
      this.panel1.Controls.Add(this.label7);
      this.panel1.Controls.Add(this.urlText);
      this.panel1.Controls.Add(this.label4);
      this.panel1.Controls.Add(this.label1);
      this.panel1.Controls.Add(this.label3);
      this.panel1.Controls.Add(this.urlCoolDownNumeric);
      this.panel1.Controls.Add(this.label2);
      this.panel1.Location = new System.Drawing.Point(12, 24);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(519, 333);
      this.panel1.TabIndex = 31;
      // 
      // groupBox1
      // 
      this.groupBox1.BackColor = System.Drawing.Color.LightBlue;
      this.groupBox1.Controls.Add(this.ConfirmCheckBox);
      this.groupBox1.Controls.Add(this.label5);
      this.groupBox1.Controls.Add(this.AutoFillButton);
      this.groupBox1.Controls.Add(this.ResetCheckBox);
      this.groupBox1.Controls.Add(this.FlagCheckBox);
      this.groupBox1.Location = new System.Drawing.Point(16, 76);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(485, 142);
      this.groupBox1.TabIndex = 41;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "For Blue Iris ONLY!";
      // 
      // ConfirmCheckBox
      // 
      this.ConfirmCheckBox.AutoSize = true;
      this.ConfirmCheckBox.Location = new System.Drawing.Point(6, 58);
      this.ConfirmCheckBox.Name = "ConfirmCheckBox";
      this.ConfirmCheckBox.Size = new System.Drawing.Size(173, 19);
      this.ConfirmCheckBox.TabIndex = 1;
      this.ConfirmCheckBox.Text = "Mark Confirmed by Blue Iris";
      this.ConfirmCheckBox.UseVisualStyleBackColor = true;
      this.ConfirmCheckBox.CheckedChanged += new System.EventHandler(this.ConfirmOnCheckChanged);
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(87, 29);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(246, 15);
      this.label5.TabIndex = 31;
      this.label5.Text = "Automatically Fill From Camera Contact Data\r\n";
      // 
      // AutoFillButton
      // 
      this.AutoFillButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.AutoFillButton.Location = new System.Drawing.Point(6, 21);
      this.AutoFillButton.Name = "AutoFillButton";
      this.AutoFillButton.Size = new System.Drawing.Size(75, 26);
      this.AutoFillButton.TabIndex = 0;
      this.AutoFillButton.Text = "Auto Fill";
      this.AutoFillButton.UseVisualStyleBackColor = true;
      this.AutoFillButton.Click += new System.EventHandler(this.AutoFillButton_Click);
      // 
      // ResetCheckBox
      // 
      this.ResetCheckBox.AutoSize = true;
      this.ResetCheckBox.Location = new System.Drawing.Point(6, 110);
      this.ResetCheckBox.Name = "ResetCheckBox";
      this.ResetCheckBox.Size = new System.Drawing.Size(271, 19);
      this.ResetCheckBox.TabIndex = 3;
      this.ResetCheckBox.Text = "Reset Confirmed and Flagged State by Blue Iris\r\n";
      this.ResetCheckBox.UseVisualStyleBackColor = true;
      this.ResetCheckBox.CheckedChanged += new System.EventHandler(this.ResetCheckBox_CheckedChanged);
      // 
      // FlagCheckBox
      // 
      this.FlagCheckBox.AutoSize = true;
      this.FlagCheckBox.Location = new System.Drawing.Point(6, 84);
      this.FlagCheckBox.Name = "FlagCheckBox";
      this.FlagCheckBox.Size = new System.Drawing.Size(158, 19);
      this.FlagCheckBox.TabIndex = 2;
      this.FlagCheckBox.Text = "Mark Flagged by Blue Iris";
      this.FlagCheckBox.UseVisualStyleBackColor = true;
      this.FlagCheckBox.CheckedChanged += new System.EventHandler(this.FlagCheckChanged);
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Location = new System.Drawing.Point(12, 247);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(161, 15);
      this.label6.TabIndex = 40;
      this.label6.Text = "Wait Time Before Send (Sec): ";
      // 
      // WaitTimeNumeric
      // 
      this.WaitTimeNumeric.Location = new System.Drawing.Point(181, 247);
      this.WaitTimeNumeric.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
      this.WaitTimeNumeric.Name = "WaitTimeNumeric";
      this.WaitTimeNumeric.Size = new System.Drawing.Size(75, 23);
      this.WaitTimeNumeric.TabIndex = 1;
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.Location = new System.Drawing.Point(276, 249);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(192, 15);
      this.label7.TabIndex = 39;
      this.label7.Text = "Always Sent  (Overrides Cooldown)";
      // 
      // AddUrlDialog
      // 
      this.AcceptButton = this.okButton;
      this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
      this.CancelButton = this.okButton;
      this.ClientSize = new System.Drawing.Size(543, 411);
      this.Controls.Add(this.panel1);
      this.Controls.Add(this.cancelButton);
      this.Controls.Add(this.okButton);
      this.Name = "AddUrlDialog";
      this.Text = "Add URL for Http Notifications";
      ((System.ComponentModel.ISupportInitialize)(this.urlCoolDownNumeric)).EndInit();
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.WaitTimeNumeric)).EndInit();
      this.ResumeLayout(false);

    }

        #endregion

        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox urlText;
        private System.Windows.Forms.NumericUpDown urlCoolDownNumeric;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button AutoFillButton;
        private System.Windows.Forms.Label label5;
    private System.Windows.Forms.CheckBox FlagCheckBox;
    private System.Windows.Forms.CheckBox ConfirmCheckBox;
    private System.Windows.Forms.CheckBox ResetCheckBox;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.NumericUpDown WaitTimeNumeric;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.GroupBox groupBox1;
  }
}