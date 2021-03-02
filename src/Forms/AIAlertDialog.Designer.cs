
namespace OnGuardCore
{
  partial class AIAlertDialog
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
      this.label2 = new System.Windows.Forms.Label();
      this.EmailListBox = new System.Windows.Forms.ListBox();
      this.OKButton = new System.Windows.Forms.Button();
      this.CancelButton = new System.Windows.Forms.Button();
      this.RemoveButton = new System.Windows.Forms.Button();
      this.label3 = new System.Windows.Forms.Label();
      this.label14 = new System.Windows.Forms.Label();
      this.AIDiedPayloadText = new System.Windows.Forms.TextBox();
      this.label11 = new System.Windows.Forms.Label();
      this.AIDiedTopicText = new System.Windows.Forms.TextBox();
      this.sendAIDiedMQTTCheckbox = new System.Windows.Forms.CheckBox();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.label1.Location = new System.Drawing.Point(131, 26);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(133, 21);
      this.label1.TabIndex = 0;
      this.label1.Text = "AI Alert Settings";
      // 
      // label2
      // 
      this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.label2.Location = new System.Drawing.Point(5, 68);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(384, 84);
      this.label2.TabIndex = 1;
      this.label2.Text = "When/if your AI server(s) die you may receive a notification via email and/or MQT" +
    "T.  At the moment this notification is limited to one (and only one) email addre" +
    "ss.\r\n";
      // 
      // EmailListBox
      // 
      this.EmailListBox.FormattingEnabled = true;
      this.EmailListBox.ItemHeight = 15;
      this.EmailListBox.Location = new System.Drawing.Point(59, 174);
      this.EmailListBox.Name = "EmailListBox";
      this.EmailListBox.Size = new System.Drawing.Size(276, 94);
      this.EmailListBox.TabIndex = 2;
      // 
      // OKButton
      // 
      this.OKButton.Location = new System.Drawing.Point(117, 530);
      this.OKButton.Name = "OKButton";
      this.OKButton.Size = new System.Drawing.Size(75, 23);
      this.OKButton.TabIndex = 3;
      this.OKButton.Text = "OK";
      this.OKButton.UseVisualStyleBackColor = true;
      this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
      // 
      // CancelButton
      // 
      this.CancelButton.Location = new System.Drawing.Point(202, 530);
      this.CancelButton.Name = "CancelButton";
      this.CancelButton.Size = new System.Drawing.Size(75, 23);
      this.CancelButton.TabIndex = 4;
      this.CancelButton.Text = "Cancel";
      this.CancelButton.UseVisualStyleBackColor = true;
      this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
      // 
      // RemoveButton
      // 
      this.RemoveButton.Location = new System.Drawing.Point(160, 283);
      this.RemoveButton.Name = "RemoveButton";
      this.RemoveButton.Size = new System.Drawing.Size(75, 23);
      this.RemoveButton.TabIndex = 5;
      this.RemoveButton.Text = "Remove";
      this.RemoveButton.UseVisualStyleBackColor = true;
      this.RemoveButton.Click += new System.EventHandler(this.RemoveButton_Click);
      // 
      // label3
      // 
      this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.label3.Location = new System.Drawing.Point(5, 348);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(384, 57);
      this.label3.TabIndex = 6;
      this.label3.Text = "Enter any MQTT Topic and Payload you wish to send when your AIs die.\r\n\r\n";
      // 
      // label14
      // 
      this.label14.AutoSize = true;
      this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.label14.Location = new System.Drawing.Point(12, 438);
      this.label14.Name = "label14";
      this.label14.Size = new System.Drawing.Size(124, 16);
      this.label14.TabIndex = 26;
      this.label14.Text = "AI Died Payload:";
      // 
      // AIDiedPayloadText
      // 
      this.AIDiedPayloadText.Location = new System.Drawing.Point(142, 439);
      this.AIDiedPayloadText.Name = "AIDiedPayloadText";
      this.AIDiedPayloadText.Size = new System.Drawing.Size(211, 23);
      this.AIDiedPayloadText.TabIndex = 25;
      // 
      // label11
      // 
      this.label11.AutoSize = true;
      this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.label11.Location = new System.Drawing.Point(34, 405);
      this.label11.Name = "label11";
      this.label11.Size = new System.Drawing.Size(102, 16);
      this.label11.TabIndex = 24;
      this.label11.Text = "AI Died Topic";
      // 
      // AIDiedTopicText
      // 
      this.AIDiedTopicText.Location = new System.Drawing.Point(142, 401);
      this.AIDiedTopicText.Name = "AIDiedTopicText";
      this.AIDiedTopicText.Size = new System.Drawing.Size(211, 23);
      this.AIDiedTopicText.TabIndex = 27;
      this.AIDiedTopicText.Text = "OnGuard/AI Died";
      // 
      // sendAIDiedMQTTCheckbox
      // 
      this.sendAIDiedMQTTCheckbox.AutoSize = true;
      this.sendAIDiedMQTTCheckbox.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.sendAIDiedMQTTCheckbox.Location = new System.Drawing.Point(142, 477);
      this.sendAIDiedMQTTCheckbox.Name = "sendAIDiedMQTTCheckbox";
      this.sendAIDiedMQTTCheckbox.Size = new System.Drawing.Size(168, 21);
      this.sendAIDiedMQTTCheckbox.TabIndex = 28;
      this.sendAIDiedMQTTCheckbox.Text = "Send MQTT on AI Died";
      this.sendAIDiedMQTTCheckbox.UseVisualStyleBackColor = true;
      // 
      // AIAlertDialog
      // 
      this.AcceptButton = this.OKButton;
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(395, 577);
      this.Controls.Add(this.sendAIDiedMQTTCheckbox);
      this.Controls.Add(this.AIDiedTopicText);
      this.Controls.Add(this.label14);
      this.Controls.Add(this.AIDiedPayloadText);
      this.Controls.Add(this.label11);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.RemoveButton);
      this.Controls.Add(this.CancelButton);
      this.Controls.Add(this.OKButton);
      this.Controls.Add(this.EmailListBox);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Name = "AIAlertDialog";
      this.Text = "AI Alert Settings";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.ListBox EmailListBox;
    private System.Windows.Forms.Button OKButton;
    private System.Windows.Forms.Button CancelButton;
    private System.Windows.Forms.Button RemoveButton;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label14;
    private System.Windows.Forms.TextBox AIDiedPayloadText;
    private System.Windows.Forms.Label label11;
    private System.Windows.Forms.TextBox AIDiedTopicText;
    private System.Windows.Forms.CheckBox sendAIDiedMQTTCheckbox;
  }
}