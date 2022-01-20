
namespace OnGuardCore
{
  partial class StartRestartAI
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
      this.label6 = new System.Windows.Forms.Label();
      this.label7 = new System.Windows.Forms.Label();
      this.StatusLabel = new System.Windows.Forms.Label();
      this.StartButton = new System.Windows.Forms.Button();
      this.DoneButton = new System.Windows.Forms.Button();
      this.StopButton = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.label6.Location = new System.Drawing.Point(49, 23);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(259, 18);
      this.label6.TabIndex = 16;
      this.label6.Text = "Start or Restart the DeepStack AI";
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      this.label7.Location = new System.Drawing.Point(42, 78);
      this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(107, 16);
      this.label7.TabIndex = 21;
      this.label7.Text = "Current AI Status:";
      // 
      // StatusLabel
      // 
      this.StatusLabel.AutoSize = true;
      this.StatusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      this.StatusLabel.Location = new System.Drawing.Point(150, 78);
      this.StatusLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.StatusLabel.Name = "StatusLabel";
      this.StatusLabel.Size = new System.Drawing.Size(56, 16);
      this.StatusLabel.TabIndex = 22;
      this.StatusLabel.Text = "Running";
      // 
      // StartButton
      // 
      this.StartButton.Location = new System.Drawing.Point(43, 115);
      this.StartButton.Name = "StartButton";
      this.StartButton.Size = new System.Drawing.Size(129, 23);
      this.StartButton.TabIndex = 0;
      this.StartButton.Text = "Start";
      this.StartButton.UseVisualStyleBackColor = true;
      this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
      // 
      // DoneButton
      // 
      this.DoneButton.Location = new System.Drawing.Point(141, 165);
      this.DoneButton.Name = "DoneButton";
      this.DoneButton.Size = new System.Drawing.Size(75, 23);
      this.DoneButton.TabIndex = 2;
      this.DoneButton.Text = "Done";
      this.DoneButton.UseVisualStyleBackColor = true;
      this.DoneButton.Click += new System.EventHandler(this.DoneButton_Click);
      // 
      // StopButton
      // 
      this.StopButton.Location = new System.Drawing.Point(184, 115);
      this.StopButton.Name = "StopButton";
      this.StopButton.Size = new System.Drawing.Size(129, 23);
      this.StopButton.TabIndex = 1;
      this.StopButton.Text = "Stop";
      this.StopButton.UseVisualStyleBackColor = true;
      this.StopButton.Click += new System.EventHandler(this.StopButton_Click);
      // 
      // StartRestartAI
      // 
      this.AcceptButton = this.DoneButton;
      this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
      this.CancelButton = this.DoneButton;
      this.ClientSize = new System.Drawing.Size(357, 209);
      this.Controls.Add(this.StopButton);
      this.Controls.Add(this.DoneButton);
      this.Controls.Add(this.StartButton);
      this.Controls.Add(this.StatusLabel);
      this.Controls.Add(this.label7);
      this.Controls.Add(this.label6);
      this.Name = "StartRestartAI";
      this.Text = "Start/Restart DeepStack AI";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.Label StatusLabel;
    private System.Windows.Forms.Button StartButton;
    private System.Windows.Forms.Button DoneButton;
    private System.Windows.Forms.Button StopButton;
  }
}