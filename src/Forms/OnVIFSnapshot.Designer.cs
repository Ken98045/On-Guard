
namespace OnGuardCore
{
  partial class OnVIFSnapshot
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
      this.profileListBox = new System.Windows.Forms.ListBox();
      this.okButton = new System.Windows.Forms.Button();
      this.cancelButton = new System.Windows.Forms.Button();
      this.SnapshotTextBox = new System.Windows.Forms.TextBox();
      this.label5 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.FormHelpButton = new System.Windows.Forms.Button();
      this.label3 = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.label1.Location = new System.Drawing.Point(262, 23);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(276, 16);
      this.label1.TabIndex = 26;
      this.label1.Text = "OnVIF Camera Snapshot (.jpg) Settings";
      // 
      // profileListBox
      // 
      this.profileListBox.FormattingEnabled = true;
      this.profileListBox.ItemHeight = 15;
      this.profileListBox.Location = new System.Drawing.Point(257, 92);
      this.profileListBox.Name = "profileListBox";
      this.profileListBox.Size = new System.Drawing.Size(268, 64);
      this.profileListBox.TabIndex = 0;
      this.profileListBox.SelectedIndexChanged += new System.EventHandler(this.OnSelectedIndexChanged);
      // 
      // okButton
      // 
      this.okButton.Location = new System.Drawing.Point(310, 216);
      this.okButton.Name = "okButton";
      this.okButton.Size = new System.Drawing.Size(75, 23);
      this.okButton.TabIndex = 2;
      this.okButton.Text = "OK";
      this.okButton.UseVisualStyleBackColor = true;
      this.okButton.Click += new System.EventHandler(this.OkButton_Click);
      // 
      // cancelButton
      // 
      this.cancelButton.Location = new System.Drawing.Point(404, 216);
      this.cancelButton.Name = "cancelButton";
      this.cancelButton.Size = new System.Drawing.Size(75, 23);
      this.cancelButton.TabIndex = 3;
      this.cancelButton.Text = "Cancel";
      this.cancelButton.UseVisualStyleBackColor = true;
      this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
      // 
      // SnapshotTextBox
      // 
      this.SnapshotTextBox.Location = new System.Drawing.Point(257, 169);
      this.SnapshotTextBox.Name = "SnapshotTextBox";
      this.SnapshotTextBox.Size = new System.Drawing.Size(334, 23);
      this.SnapshotTextBox.TabIndex = 1;
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.label5.Location = new System.Drawing.Point(50, 171);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(180, 16);
      this.label5.TabIndex = 39;
      this.label5.Text = "OnVIF Snapshot Request";
      this.label5.Click += new System.EventHandler(this.Label5_Click);
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(601, 172);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(132, 15);
      this.label2.TabIndex = 40;
      this.label2.Text = "Edit if Desired (unusual)";
      // 
      // FormHelpButton
      // 
      this.FormHelpButton.Location = new System.Drawing.Point(659, 216);
      this.FormHelpButton.Name = "FormHelpButton";
      this.FormHelpButton.Size = new System.Drawing.Size(75, 23);
      this.FormHelpButton.TabIndex = 4;
      this.FormHelpButton.Text = "Help!";
      this.FormHelpButton.UseVisualStyleBackColor = true;
      this.FormHelpButton.Click += new System.EventHandler(this.HelpButton_Click);
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.label3.Location = new System.Drawing.Point(319, 61);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(163, 16);
      this.label3.TabIndex = 42;
      this.label3.Text = "Select Stream (Profile)";
      // 
      // OnVIFSnapshot
      // 
      this.AcceptButton = this.okButton;
      this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
      this.AutoScroll = true;
      this.CancelButton = this.cancelButton;
      this.ClientSize = new System.Drawing.Size(746, 245);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.FormHelpButton);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label5);
      this.Controls.Add(this.SnapshotTextBox);
      this.Controls.Add(this.cancelButton);
      this.Controls.Add(this.okButton);
      this.Controls.Add(this.profileListBox);
      this.Controls.Add(this.label1);
      this.Name = "OnVIFSnapshot";
      this.Text = "OnVIF Snapshot";
      this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OnClosed);
      this.LocationChanged += new System.EventHandler(this.OnLocationChanged);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.ListBox profileListBox;
    private System.Windows.Forms.Button okButton;
    private System.Windows.Forms.Button cancelButton;
    private System.Windows.Forms.TextBox SnapshotTextBox;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Button FormHelpButton;
    private System.Windows.Forms.Label label3;
  }
}