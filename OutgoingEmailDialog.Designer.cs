namespace SAAI
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
      ((System.ComponentModel.ISupportInitialize)(this.portNumeric)).BeginInit();
      this.SuspendLayout();
      // 
      // okButton
      // 
      this.okButton.Location = new System.Drawing.Point(132, 233);
      this.okButton.Name = "okButton";
      this.okButton.Size = new System.Drawing.Size(75, 23);
      this.okButton.TabIndex = 5;
      this.okButton.Text = "OK";
      this.okButton.UseVisualStyleBackColor = true;
      this.okButton.Click += new System.EventHandler(this.OkButton_Click);
      // 
      // cancelButton
      // 
      this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.cancelButton.Location = new System.Drawing.Point(224, 233);
      this.cancelButton.Name = "cancelButton";
      this.cancelButton.Size = new System.Drawing.Size(75, 23);
      this.cancelButton.TabIndex = 6;
      this.cancelButton.Text = "Cancel";
      this.cancelButton.UseVisualStyleBackColor = true;
      this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label1.Location = new System.Drawing.Point(55, 31);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(170, 15);
      this.label1.TabIndex = 2;
      this.label1.Text = "Outgoing Server (SMTP): ";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label2.Location = new System.Drawing.Point(97, 66);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(128, 15);
      this.label2.TabIndex = 3;
      this.label2.Text = "Email User Name: ";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label3.Location = new System.Drawing.Point(107, 101);
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
      this.sslCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.sslCheck.Location = new System.Drawing.Point(20, 136);
      this.sslCheck.Name = "sslCheck";
      this.sslCheck.Size = new System.Drawing.Size(205, 17);
      this.sslCheck.TabIndex = 3;
      this.sslCheck.Text = "Use SSL (Normally you want to)";
      this.sslCheck.UseVisualStyleBackColor = true;
      // 
      // serverText
      // 
      this.serverText.Location = new System.Drawing.Point(238, 30);
      this.serverText.Name = "serverText";
      this.serverText.Size = new System.Drawing.Size(176, 20);
      this.serverText.TabIndex = 0;
      // 
      // userText
      // 
      this.userText.Location = new System.Drawing.Point(238, 65);
      this.userText.Name = "userText";
      this.userText.Size = new System.Drawing.Size(176, 20);
      this.userText.TabIndex = 1;
      // 
      // passwordText
      // 
      this.passwordText.Location = new System.Drawing.Point(238, 100);
      this.passwordText.Name = "passwordText";
      this.passwordText.PasswordChar = '*';
      this.passwordText.Size = new System.Drawing.Size(176, 20);
      this.passwordText.TabIndex = 2;
      this.passwordText.UseSystemPasswordChar = true;
      // 
      // portNumeric
      // 
      this.portNumeric.Location = new System.Drawing.Point(238, 173);
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
      this.portNumeric.Size = new System.Drawing.Size(120, 20);
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
      this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label4.Location = new System.Drawing.Point(139, 173);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(86, 15);
      this.label4.TabIndex = 12;
      this.label4.Text = "Server Port: ";
      // 
      // OutgoingEmailDialog
      // 
      this.AcceptButton = this.okButton;
      this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
      this.CancelButton = this.cancelButton;
      this.ClientSize = new System.Drawing.Size(431, 289);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.portNumeric);
      this.Controls.Add(this.passwordText);
      this.Controls.Add(this.userText);
      this.Controls.Add(this.serverText);
      this.Controls.Add(this.sslCheck);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.cancelButton);
      this.Controls.Add(this.okButton);
      this.Name = "OutgoingEmailDialog";
      this.Text = "Outgoing Email Server";
      ((System.ComponentModel.ISupportInitialize)(this.portNumeric)).EndInit();
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
    }
}