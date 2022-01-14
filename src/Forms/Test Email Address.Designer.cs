namespace OnGuardCore
{
  partial class TestEmailAddress
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
      this.label1 = new System.Windows.Forms.Label();
      this.okButton = new System.Windows.Forms.Button();
      this.emailAddressText = new System.Windows.Forms.TextBox();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(14, 38);
      this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(147, 15);
      this.label1.TabIndex = 0;
      this.label1.Text = "Destination Email Address:";
      // 
      // okButton
      // 
      this.okButton.Location = new System.Drawing.Point(166, 85);
      this.okButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
      this.okButton.Name = "okButton";
      this.okButton.Size = new System.Drawing.Size(88, 27);
      this.okButton.TabIndex = 1;
      this.okButton.Text = "OK";
      this.okButton.UseVisualStyleBackColor = true;
      this.okButton.Click += new System.EventHandler(this.OKButton_Click);
      // 
      // emailAddressText
      // 
      this.emailAddressText.Location = new System.Drawing.Point(175, 35);
      this.emailAddressText.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
      this.emailAddressText.Name = "emailAddressText";
      this.emailAddressText.Size = new System.Drawing.Size(215, 23);
      this.emailAddressText.TabIndex = 0;
      // 
      // TestEmailAddress
      // 
      this.AcceptButton = this.okButton;
      this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
      this.ClientSize = new System.Drawing.Size(418, 129);
      this.Controls.Add(this.emailAddressText);
      this.Controls.Add(this.okButton);
      this.Controls.Add(this.label1);
      this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
      this.Name = "TestEmailAddress";
      this.Text = "Enter the email address for the test";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Button okButton;
    public System.Windows.Forms.TextBox emailAddressText;
  }
}