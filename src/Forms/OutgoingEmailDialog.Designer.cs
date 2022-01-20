namespace OnGuardCore
{
  partial class OutgoingEmailDialog
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
      this.sslCheck = new System.Windows.Forms.CheckBox();
      this.serverText = new System.Windows.Forms.TextBox();
      this.userText = new System.Windows.Forms.TextBox();
      this.passwordText = new System.Windows.Forms.TextBox();
      this.portNumeric = new System.Windows.Forms.NumericUpDown();
      this.label4 = new System.Windows.Forms.Label();
      this.testButton = new System.Windows.Forms.Button();
      this.label5 = new System.Windows.Forms.Label();
      this.label6 = new System.Windows.Forms.Label();
      this.panel1 = new System.Windows.Forms.Panel();
      ((System.ComponentModel.ISupportInitialize)(this.portNumeric)).BeginInit();
      this.panel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // okButton
      // 
      this.okButton.Location = new System.Drawing.Point(238, 249);
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
      this.cancelButton.Location = new System.Drawing.Point(322, 249);
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
      this.label1.Location = new System.Drawing.Point(5, 20);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(170, 15);
      this.label1.TabIndex = 2;
      this.label1.Text = "Outgoing Server (SMTP): ";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.label2.Location = new System.Drawing.Point(47, 57);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(128, 15);
      this.label2.TabIndex = 3;
      this.label2.Text = "Email User Name: ";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.label3.Location = new System.Drawing.Point(57, 94);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(118, 15);
      this.label3.TabIndex = 4;
      this.label3.Text = "Email Password: ";
      // 
      // sslCheck
      // 
      this.sslCheck.AutoSize = true;
      this.sslCheck.Checked = true;
      this.sslCheck.CheckState = System.Windows.Forms.CheckState.Checked;
      this.sslCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.sslCheck.Location = new System.Drawing.Point(184, 129);
      this.sslCheck.Name = "sslCheck";
      this.sslCheck.Size = new System.Drawing.Size(346, 17);
      this.sslCheck.TabIndex = 3;
      this.sslCheck.Text = "Use SSL (Normally you want to if your server supports it)";
      this.sslCheck.UseVisualStyleBackColor = true;
      // 
      // serverText
      // 
      this.serverText.Location = new System.Drawing.Point(184, 18);
      this.serverText.Name = "serverText";
      this.serverText.Size = new System.Drawing.Size(176, 23);
      this.serverText.TabIndex = 0;
      // 
      // userText
      // 
      this.userText.Location = new System.Drawing.Point(184, 55);
      this.userText.Name = "userText";
      this.userText.Size = new System.Drawing.Size(176, 23);
      this.userText.TabIndex = 1;
      // 
      // passwordText
      // 
      this.passwordText.Location = new System.Drawing.Point(184, 92);
      this.passwordText.Name = "passwordText";
      this.passwordText.PasswordChar = '*';
      this.passwordText.Size = new System.Drawing.Size(176, 23);
      this.passwordText.TabIndex = 2;
      this.passwordText.UseSystemPasswordChar = true;
      // 
      // portNumeric
      // 
      this.portNumeric.Location = new System.Drawing.Point(184, 160);
      this.portNumeric.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
      this.portNumeric.Minimum = new decimal(new int[] {
            19,
            0,
            0,
            0});
      this.portNumeric.Name = "portNumeric";
      this.portNumeric.Size = new System.Drawing.Size(120, 23);
      this.portNumeric.TabIndex = 4;
      this.portNumeric.Value = new decimal(new int[] {
            587,
            0,
            0,
            0});
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.label4.Location = new System.Drawing.Point(89, 161);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(86, 15);
      this.label4.TabIndex = 12;
      this.label4.Text = "Server Port: ";
      // 
      // testButton
      // 
      this.testButton.Location = new System.Drawing.Point(406, 249);
      this.testButton.Name = "testButton";
      this.testButton.Size = new System.Drawing.Size(75, 23);
      this.testButton.TabIndex = 2;
      this.testButton.Text = "Test";
      this.testButton.UseVisualStyleBackColor = true;
      this.testButton.Click += new System.EventHandler(this.TestButton_Click);
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.label5.Location = new System.Drawing.Point(366, 57);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(287, 15);
      this.label5.TabIndex = 14;
      this.label5.Text = "Must be in the format \"John.Smith@foo.bar\"";
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.label6.Location = new System.Drawing.Point(227, 14);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(265, 18);
      this.label6.TabIndex = 15;
      this.label6.Text = "Setup Your Outgoing Email Server";
      // 
      // panel1
      // 
      this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.panel1.Controls.Add(this.userText);
      this.panel1.Controls.Add(this.label1);
      this.panel1.Controls.Add(this.label5);
      this.panel1.Controls.Add(this.label2);
      this.panel1.Controls.Add(this.label3);
      this.panel1.Controls.Add(this.label4);
      this.panel1.Controls.Add(this.sslCheck);
      this.panel1.Controls.Add(this.portNumeric);
      this.panel1.Controls.Add(this.serverText);
      this.panel1.Controls.Add(this.passwordText);
      this.panel1.Location = new System.Drawing.Point(17, 43);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(670, 196);
      this.panel1.TabIndex = 16;
      // 
      // OutgoingEmailDialog
      // 
      this.AcceptButton = this.okButton;
      this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
      this.AutoScroll = true;
      this.CancelButton = this.cancelButton;
      this.ClientSize = new System.Drawing.Size(718, 279);
      this.Controls.Add(this.panel1);
      this.Controls.Add(this.label6);
      this.Controls.Add(this.testButton);
      this.Controls.Add(this.cancelButton);
      this.Controls.Add(this.okButton);
      this.Name = "OutgoingEmailDialog";
      this.Text = "Outgoing Email Server";
      ((System.ComponentModel.ISupportInitialize)(this.portNumeric)).EndInit();
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

        #endregion

        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox sslCheck;
        private System.Windows.Forms.TextBox serverText;
        private System.Windows.Forms.TextBox userText;
        private System.Windows.Forms.TextBox passwordText;
        private System.Windows.Forms.NumericUpDown portNumeric;
        private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Button testButton;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.Panel panel1;
  }
}