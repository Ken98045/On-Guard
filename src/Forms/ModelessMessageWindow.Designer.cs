
namespace OnGuardCore
{
  partial class ModelessMessageWindow
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
        _timer?.Dispose();
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
      this.LabelMessage = new System.Windows.Forms.Label();
      this.DismissButton = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // LabelMessage
      // 
      this.LabelMessage.AutoSize = true;
      this.LabelMessage.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.LabelMessage.Location = new System.Drawing.Point(87, 51);
      this.LabelMessage.Name = "LabelMessage";
      this.LabelMessage.Size = new System.Drawing.Size(57, 21);
      this.LabelMessage.TabIndex = 0;
      this.LabelMessage.Text = "label1";
      // 
      // DismissButton
      // 
      this.DismissButton.Enabled = false;
      this.DismissButton.Location = new System.Drawing.Point(154, 98);
      this.DismissButton.Name = "DismissButton";
      this.DismissButton.Size = new System.Drawing.Size(75, 23);
      this.DismissButton.TabIndex = 1;
      this.DismissButton.Text = "Dismiss";
      this.DismissButton.UseVisualStyleBackColor = true;
      this.DismissButton.Visible = false;
      this.DismissButton.Click += new System.EventHandler(this.Button_Click);
      // 
      // ModelessMessageWindow
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
      this.ClientSize = new System.Drawing.Size(383, 129);
      this.ControlBox = false;
      this.Controls.Add(this.DismissButton);
      this.Controls.Add(this.LabelMessage);
      this.Name = "ModelessMessageWindow";
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Information";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnClosing);
      this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OnClosed);
      this.VisibleChanged += new System.EventHandler(this.OnVisibleChanged);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label LabelMessage;
    private System.Windows.Forms.Button DismissButton;
  }
}