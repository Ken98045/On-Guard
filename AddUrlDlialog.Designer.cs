namespace SAAI
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
      this.label5 = new System.Windows.Forms.Label();
      this.AutoFillButton = new System.Windows.Forms.Button();
      ((System.ComponentModel.ISupportInitialize)(this.urlCoolDownNumeric)).BeginInit();
      this.panel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // okButton
      // 
      this.okButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.okButton.Location = new System.Drawing.Point(186, 207);
      this.okButton.Name = "okButton";
      this.okButton.Size = new System.Drawing.Size(75, 23);
      this.okButton.TabIndex = 0;
      this.okButton.Text = "OK";
      this.okButton.UseVisualStyleBackColor = true;
      this.okButton.Click += new System.EventHandler(this.OkButton_Click);
      // 
      // cancelButton
      // 
      this.cancelButton.Location = new System.Drawing.Point(282, 207);
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
      this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label1.Location = new System.Drawing.Point(216, 10);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(91, 15);
      this.label1.TabIndex = 2;
      this.label1.Text = "URL to Notify";
      // 
      // urlText
      // 
      this.urlText.Location = new System.Drawing.Point(44, 38);
      this.urlText.Name = "urlText";
      this.urlText.Size = new System.Drawing.Size(421, 20);
      this.urlText.TabIndex = 2;
      // 
      // urlCoolDownNumeric
      // 
      this.urlCoolDownNumeric.Location = new System.Drawing.Point(133, 118);
      this.urlCoolDownNumeric.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
      this.urlCoolDownNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.urlCoolDownNumeric.Name = "urlCoolDownNumeric";
      this.urlCoolDownNumeric.Size = new System.Drawing.Size(75, 20);
      this.urlCoolDownNumeric.TabIndex = 1;
      this.urlCoolDownNumeric.Value = new decimal(new int[] {
            300,
            0,
            0,
            0});
      this.urlCoolDownNumeric.ValueChanged += new System.EventHandler(this.urlCoolDownNumeric_ValueChanged);
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(216, 120);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(236, 13);
      this.label2.TabIndex = 28;
      this.label2.Text = "Minimum Time Between Notifications in Seconds";
      this.label2.Click += new System.EventHandler(this.label2_Click);
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(33, 120);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(86, 13);
      this.label3.TabIndex = 29;
      this.label3.Text = "Cooldown Time: ";
      this.label3.Click += new System.EventHandler(this.label3_Click);
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(12, 41);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(26, 13);
      this.label4.TabIndex = 30;
      this.label4.Text = "Url: ";
      // 
      // panel1
      // 
      this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.panel1.Controls.Add(this.label5);
      this.panel1.Controls.Add(this.AutoFillButton);
      this.panel1.Controls.Add(this.urlText);
      this.panel1.Controls.Add(this.label4);
      this.panel1.Controls.Add(this.label1);
      this.panel1.Controls.Add(this.label3);
      this.panel1.Controls.Add(this.urlCoolDownNumeric);
      this.panel1.Controls.Add(this.label2);
      this.panel1.Location = new System.Drawing.Point(12, 26);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(519, 166);
      this.panel1.TabIndex = 31;
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(125, 83);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(323, 13);
      this.label5.TabIndex = 31;
      this.label5.Text = "Automatically Fill From Camera Contact Data (Usually you want this)";
      // 
      // AutoFillButton
      // 
      this.AutoFillButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.AutoFillButton.Location = new System.Drawing.Point(44, 75);
      this.AutoFillButton.Name = "AutoFillButton";
      this.AutoFillButton.Size = new System.Drawing.Size(75, 26);
      this.AutoFillButton.TabIndex = 0;
      this.AutoFillButton.Text = "Auto Fill";
      this.AutoFillButton.UseVisualStyleBackColor = true;
      this.AutoFillButton.Click += new System.EventHandler(this.AutoFillButton_Click);
      // 
      // AddUrlDialog
      // 
      this.AcceptButton = this.okButton;
      this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
      this.CancelButton = this.okButton;
      this.ClientSize = new System.Drawing.Size(543, 242);
      this.Controls.Add(this.panel1);
      this.Controls.Add(this.cancelButton);
      this.Controls.Add(this.okButton);
      this.Name = "AddUrlDialog";
      this.Text = "Add URL for Notifications";
      ((System.ComponentModel.ISupportInitialize)(this.urlCoolDownNumeric)).EndInit();
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
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
    }
}