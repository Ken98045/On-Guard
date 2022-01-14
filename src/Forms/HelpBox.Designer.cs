
namespace OnGuardCore
{
  partial class HelpBox
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
      this.OKButton = new System.Windows.Forms.Button();
      this.richTextBoxHelp = new System.Windows.Forms.RichTextBox();
      this.TitleLabel = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // OKButton
      // 
      this.OKButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
      this.OKButton.Location = new System.Drawing.Point(303, 405);
      this.OKButton.Name = "OKButton";
      this.OKButton.Size = new System.Drawing.Size(75, 23);
      this.OKButton.TabIndex = 0;
      this.OKButton.Text = "OK";
      this.OKButton.UseVisualStyleBackColor = true;
      // 
      // richTextBoxHelp
      // 
      this.richTextBoxHelp.AcceptsTab = true;
      this.richTextBoxHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.richTextBoxHelp.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      this.richTextBoxHelp.Location = new System.Drawing.Point(13, 39);
      this.richTextBoxHelp.Name = "richTextBoxHelp";
      this.richTextBoxHelp.Size = new System.Drawing.Size(659, 354);
      this.richTextBoxHelp.TabIndex = 1;
      this.richTextBoxHelp.Text = "";
      // 
      // TitleLabel
      // 
      this.TitleLabel.AutoSize = true;
      this.TitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.TitleLabel.Location = new System.Drawing.Point(261, 13);
      this.TitleLabel.Name = "TitleLabel";
      this.TitleLabel.Size = new System.Drawing.Size(173, 16);
      this.TitleLabel.TabIndex = 76;
      this.TitleLabel.Text = "Placeholder for the Title";
      // 
      // HelpBox
      // 
      this.AcceptButton = this.OKButton;
      this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
      this.AutoScroll = true;
      this.CancelButton = this.OKButton;
      this.ClientSize = new System.Drawing.Size(684, 434);
      this.Controls.Add(this.TitleLabel);
      this.Controls.Add(this.richTextBoxHelp);
      this.Controls.Add(this.OKButton);
      this.MaximumSize = new System.Drawing.Size(700, 475);
      this.MinimumSize = new System.Drawing.Size(500, 300);
      this.Name = "HelpBox";
      this.Text = "Help!";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button OKButton;
    private System.Windows.Forms.RichTextBox richTextBoxHelp;
    private System.Windows.Forms.Label TitleLabel;
  }
}