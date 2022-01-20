
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AIAlertDialog));
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.EmailListBox = new System.Windows.Forms.ListBox();
      this.OKButton = new System.Windows.Forms.Button();
      this.FormCancelButton = new System.Windows.Forms.Button();
      this.RemoveButton = new System.Windows.Forms.Button();
      this.label3 = new System.Windows.Forms.Label();
      this.label14 = new System.Windows.Forms.Label();
      this.AIDiedPayloadText = new System.Windows.Forms.TextBox();
      this.label11 = new System.Windows.Forms.Label();
      this.AIDiedTopicText = new System.Windows.Forms.TextBox();
      this.sendAIDiedMQTTCheckbox = new System.Windows.Forms.CheckBox();
      this.panel1 = new System.Windows.Forms.Panel();
      this.label4 = new System.Windows.Forms.Label();
      this.panel2 = new System.Windows.Forms.Panel();
      this.panel1.SuspendLayout();
      this.panel2.SuspendLayout();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.label1.Location = new System.Drawing.Point(157, 16);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(133, 21);
      this.label1.TabIndex = 0;
      this.label1.Text = "AI Alert Settings";
      // 
      // label2
      // 
      this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.label2.Location = new System.Drawing.Point(12, 50);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(423, 69);
      this.label2.TabIndex = 1;
      this.label2.Text = resources.GetString("label2.Text");
      // 
      // EmailListBox
      // 
      this.EmailListBox.FormattingEnabled = true;
      this.EmailListBox.ItemHeight = 15;
      this.EmailListBox.Location = new System.Drawing.Point(77, 50);
      this.EmailListBox.Name = "EmailListBox";
      this.EmailListBox.Size = new System.Drawing.Size(276, 94);
      this.EmailListBox.TabIndex = 0;
      // 
      // OKButton
      // 
      this.OKButton.Location = new System.Drawing.Point(143, 565);
      this.OKButton.Name = "OKButton";
      this.OKButton.Size = new System.Drawing.Size(75, 23);
      this.OKButton.TabIndex = 0;
      this.OKButton.Text = "OK";
      this.OKButton.UseVisualStyleBackColor = true;
      this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
      // 
      // FormCancelButton
      // 
      this.FormCancelButton.Location = new System.Drawing.Point(228, 565);
      this.FormCancelButton.Name = "FormCancelButton";
      this.FormCancelButton.Size = new System.Drawing.Size(75, 23);
      this.FormCancelButton.TabIndex = 1;
      this.FormCancelButton.Text = "Cancel";
      this.FormCancelButton.UseVisualStyleBackColor = true;
      this.FormCancelButton.Click += new System.EventHandler(this.CancelButton_Click);
      // 
      // RemoveButton
      // 
      this.RemoveButton.Location = new System.Drawing.Point(141, 158);
      this.RemoveButton.Name = "RemoveButton";
      this.RemoveButton.Size = new System.Drawing.Size(117, 23);
      this.RemoveButton.TabIndex = 1;
      this.RemoveButton.Text = "Remove Selection";
      this.RemoveButton.UseVisualStyleBackColor = true;
      this.RemoveButton.Click += new System.EventHandler(this.RemoveButton_Click);
      // 
      // label3
      // 
      this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.label3.Location = new System.Drawing.Point(25, 14);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(384, 43);
      this.label3.TabIndex = 6;
      this.label3.Text = "Enter any MQTT Topic and Payload you wish to send when your AIs die.\r\n\r\n";
      // 
      // label14
      // 
      this.label14.AutoSize = true;
      this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.label14.Location = new System.Drawing.Point(3, 122);
      this.label14.Name = "label14";
      this.label14.Size = new System.Drawing.Size(124, 16);
      this.label14.TabIndex = 26;
      this.label14.Text = "AI Died Payload:";
      // 
      // AIDiedPayloadText
      // 
      this.AIDiedPayloadText.Location = new System.Drawing.Point(138, 120);
      this.AIDiedPayloadText.Name = "AIDiedPayloadText";
      this.AIDiedPayloadText.Size = new System.Drawing.Size(211, 23);
      this.AIDiedPayloadText.TabIndex = 1;
      // 
      // label11
      // 
      this.label11.AutoSize = true;
      this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.label11.Location = new System.Drawing.Point(25, 79);
      this.label11.Name = "label11";
      this.label11.Size = new System.Drawing.Size(102, 16);
      this.label11.TabIndex = 24;
      this.label11.Text = "AI Died Topic";
      // 
      // AIDiedTopicText
      // 
      this.AIDiedTopicText.Location = new System.Drawing.Point(138, 77);
      this.AIDiedTopicText.Name = "AIDiedTopicText";
      this.AIDiedTopicText.Size = new System.Drawing.Size(211, 23);
      this.AIDiedTopicText.TabIndex = 0;
      this.AIDiedTopicText.Text = "OnGuard/AI Died";
      // 
      // sendAIDiedMQTTCheckbox
      // 
      this.sendAIDiedMQTTCheckbox.AutoSize = true;
      this.sendAIDiedMQTTCheckbox.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.sendAIDiedMQTTCheckbox.Location = new System.Drawing.Point(115, 167);
      this.sendAIDiedMQTTCheckbox.Name = "sendAIDiedMQTTCheckbox";
      this.sendAIDiedMQTTCheckbox.Size = new System.Drawing.Size(168, 21);
      this.sendAIDiedMQTTCheckbox.TabIndex = 2;
      this.sendAIDiedMQTTCheckbox.Text = "Send MQTT on AI Died";
      this.sendAIDiedMQTTCheckbox.UseVisualStyleBackColor = true;
      // 
      // panel1
      // 
      this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.panel1.Controls.Add(this.label4);
      this.panel1.Controls.Add(this.EmailListBox);
      this.panel1.Controls.Add(this.RemoveButton);
      this.panel1.Location = new System.Drawing.Point(22, 133);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(401, 195);
      this.panel1.TabIndex = 30;
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.label4.Location = new System.Drawing.Point(132, 15);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(135, 17);
      this.label4.TabIndex = 7;
      this.label4.Text = "Select Email Address";
      // 
      // panel2
      // 
      this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.panel2.Controls.Add(this.sendAIDiedMQTTCheckbox);
      this.panel2.Controls.Add(this.label3);
      this.panel2.Controls.Add(this.AIDiedPayloadText);
      this.panel2.Controls.Add(this.label14);
      this.panel2.Controls.Add(this.AIDiedTopicText);
      this.panel2.Controls.Add(this.label11);
      this.panel2.Location = new System.Drawing.Point(22, 349);
      this.panel2.Name = "panel2";
      this.panel2.Size = new System.Drawing.Size(401, 205);
      this.panel2.TabIndex = 31;
      // 
      // AIAlertDialog
      // 
      this.AcceptButton = this.OKButton;
      this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
      this.AutoScroll = true;
      this.ClientSize = new System.Drawing.Size(447, 596);
      this.Controls.Add(this.panel2);
      this.Controls.Add(this.panel1);
      this.Controls.Add(this.FormCancelButton);
      this.Controls.Add(this.OKButton);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Name = "AIAlertDialog";
      this.Text = "AI Alert Settings";
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.panel2.ResumeLayout(false);
      this.panel2.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.ListBox EmailListBox;
    private System.Windows.Forms.Button OKButton;
    private System.Windows.Forms.Button FormCancelButton;
    private System.Windows.Forms.Button RemoveButton;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label14;
    private System.Windows.Forms.TextBox AIDiedPayloadText;
    private System.Windows.Forms.Label label11;
    private System.Windows.Forms.TextBox AIDiedTopicText;
    private System.Windows.Forms.CheckBox sendAIDiedMQTTCheckbox;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Panel panel2;
  }
}