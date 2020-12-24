
namespace SAAI
{
  partial class MQTTSettings
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MQTTSettings));
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.ServerText = new System.Windows.Forms.TextBox();
      this.label3 = new System.Windows.Forms.Label();
      this.PortNumeric = new System.Windows.Forms.NumericUpDown();
      this.label4 = new System.Windows.Forms.Label();
      this.UserText = new System.Windows.Forms.TextBox();
      this.PasswordText = new System.Windows.Forms.TextBox();
      this.label5 = new System.Windows.Forms.Label();
      this.OKButton = new System.Windows.Forms.Button();
      this.cancelButton = new System.Windows.Forms.Button();
      this.CoolDownNumeric = new System.Windows.Forms.NumericUpDown();
      this.label6 = new System.Windows.Forms.Label();
      this.label7 = new System.Windows.Forms.Label();
      this.label8 = new System.Windows.Forms.Label();
      this.UseSecureLinkCheck = new System.Windows.Forms.CheckBox();
      this.label9 = new System.Windows.Forms.Label();
      this.label10 = new System.Windows.Forms.Label();
      this.label11 = new System.Windows.Forms.Label();
      this.MotionActivityText = new System.Windows.Forms.TextBox();
      this.label12 = new System.Windows.Forms.Label();
      this.StoppedActivityTopicText = new System.Windows.Forms.TextBox();
      this.MotionActivityPayloadText = new System.Windows.Forms.TextBox();
      this.label13 = new System.Windows.Forms.Label();
      this.StoppedPayloadText = new System.Windows.Forms.TextBox();
      this.label14 = new System.Windows.Forms.Label();
      ((System.ComponentModel.ISupportInitialize)(this.PortNumeric)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.CoolDownNumeric)).BeginInit();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label1.Location = new System.Drawing.Point(12, 22);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(557, 106);
      this.label1.TabIndex = 0;
      this.label1.Text = "MQTT allows you to use On Guard with user defined home automation.   Setting up a" +
    "nd using MQTT is strictly optional.  If you don\'t know what MQTT is then Google " +
    "is your friend.\r\n";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label2.Location = new System.Drawing.Point(34, 101);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(200, 20);
      this.label2.TabIndex = 1;
      this.label2.Text = "Server/Broker Address: ";
      // 
      // ServerText
      // 
      this.ServerText.Location = new System.Drawing.Point(245, 103);
      this.ServerText.Name = "ServerText";
      this.ServerText.Size = new System.Drawing.Size(308, 20);
      this.ServerText.TabIndex = 0;
      this.ServerText.Text = "localhost";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label3.Location = new System.Drawing.Point(182, 151);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(52, 20);
      this.label3.TabIndex = 3;
      this.label3.Text = "Port: ";
      // 
      // PortNumeric
      // 
      this.PortNumeric.Location = new System.Drawing.Point(245, 149);
      this.PortNumeric.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
      this.PortNumeric.Name = "PortNumeric";
      this.PortNumeric.Size = new System.Drawing.Size(97, 20);
      this.PortNumeric.TabIndex = 1;
      this.PortNumeric.Value = new decimal(new int[] {
            1883,
            0,
            0,
            0});
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label4.Location = new System.Drawing.Point(126, 197);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(108, 20);
      this.label4.TabIndex = 5;
      this.label4.Text = "User Name: ";
      // 
      // UserText
      // 
      this.UserText.Location = new System.Drawing.Point(245, 195);
      this.UserText.Name = "UserText";
      this.UserText.Size = new System.Drawing.Size(197, 20);
      this.UserText.TabIndex = 2;
      // 
      // PasswordText
      // 
      this.PasswordText.Location = new System.Drawing.Point(245, 241);
      this.PasswordText.Name = "PasswordText";
      this.PasswordText.Size = new System.Drawing.Size(197, 20);
      this.PasswordText.TabIndex = 3;
      this.PasswordText.UseSystemPasswordChar = true;
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label5.Location = new System.Drawing.Point(138, 245);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(96, 20);
      this.label5.TabIndex = 7;
      this.label5.Text = "Password: ";
      // 
      // OKButton
      // 
      this.OKButton.Location = new System.Drawing.Point(189, 770);
      this.OKButton.Name = "OKButton";
      this.OKButton.Size = new System.Drawing.Size(75, 23);
      this.OKButton.TabIndex = 4;
      this.OKButton.Text = "OK";
      this.OKButton.UseVisualStyleBackColor = true;
      this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
      // 
      // cancelButton
      // 
      this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.cancelButton.Location = new System.Drawing.Point(286, 770);
      this.cancelButton.Name = "cancelButton";
      this.cancelButton.Size = new System.Drawing.Size(75, 23);
      this.cancelButton.TabIndex = 5;
      this.cancelButton.Text = "Cancel";
      this.cancelButton.UseVisualStyleBackColor = true;
      this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
      // 
      // CoolDownNumeric
      // 
      this.CoolDownNumeric.Location = new System.Drawing.Point(245, 327);
      this.CoolDownNumeric.Maximum = new decimal(new int[] {
            3600,
            0,
            0,
            0});
      this.CoolDownNumeric.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
      this.CoolDownNumeric.Name = "CoolDownNumeric";
      this.CoolDownNumeric.Size = new System.Drawing.Size(97, 20);
      this.CoolDownNumeric.TabIndex = 8;
      this.CoolDownNumeric.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label6.Location = new System.Drawing.Point(41, 327);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(193, 20);
      this.label6.TabIndex = 9;
      this.label6.Text = "Cool Down Time (sec): ";
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label7.Location = new System.Drawing.Point(348, 327);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(120, 16);
      this.label7.TabIndex = 10;
      this.label7.Text = "Not Currently Used";
      // 
      // label8
      // 
      this.label8.AutoSize = true;
      this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label8.Location = new System.Drawing.Point(88, 285);
      this.label8.Name = "label8";
      this.label8.Size = new System.Drawing.Size(146, 20);
      this.label8.TabIndex = 11;
      this.label8.Text = "Use Secure Link:";
      // 
      // UseSecureLinkCheck
      // 
      this.UseSecureLinkCheck.AutoSize = true;
      this.UseSecureLinkCheck.Location = new System.Drawing.Point(245, 287);
      this.UseSecureLinkCheck.Name = "UseSecureLinkCheck";
      this.UseSecureLinkCheck.Size = new System.Drawing.Size(15, 14);
      this.UseSecureLinkCheck.TabIndex = 12;
      this.UseSecureLinkCheck.UseVisualStyleBackColor = true;
      // 
      // label9
      // 
      this.label9.AutoSize = true;
      this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label9.Location = new System.Drawing.Point(167, 395);
      this.label9.Name = "label9";
      this.label9.Size = new System.Drawing.Size(208, 20);
      this.label9.TabIndex = 13;
      this.label9.Text = "Topic and Payload Setup\r\n";
      // 
      // label10
      // 
      this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label10.Location = new System.Drawing.Point(68, 430);
      this.label10.Name = "label10";
      this.label10.Size = new System.Drawing.Size(363, 174);
      this.label10.TabIndex = 14;
      this.label10.Text = resources.GetString("label10.Text");
      // 
      // label11
      // 
      this.label11.AutoSize = true;
      this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label11.Location = new System.Drawing.Point(38, 627);
      this.label11.Name = "label11";
      this.label11.Size = new System.Drawing.Size(116, 20);
      this.label11.TabIndex = 15;
      this.label11.Text = "Motion Topic:";
      // 
      // MotionActivityText
      // 
      this.MotionActivityText.Location = new System.Drawing.Point(160, 627);
      this.MotionActivityText.Name = "MotionActivityText";
      this.MotionActivityText.Size = new System.Drawing.Size(404, 20);
      this.MotionActivityText.TabIndex = 16;
      this.MotionActivityText.Text = "OnGuard/{Camera}/{Area}/{Object}";
      // 
      // label12
      // 
      this.label12.AutoSize = true;
      this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label12.Location = new System.Drawing.Point(24, 694);
      this.label12.Name = "label12";
      this.label12.Size = new System.Drawing.Size(130, 20);
      this.label12.TabIndex = 17;
      this.label12.Text = "Stopped Topic:";
      // 
      // StoppedActivityTopicText
      // 
      this.StoppedActivityTopicText.Location = new System.Drawing.Point(160, 696);
      this.StoppedActivityTopicText.Name = "StoppedActivityTopicText";
      this.StoppedActivityTopicText.Size = new System.Drawing.Size(404, 20);
      this.StoppedActivityTopicText.TabIndex = 18;
      this.StoppedActivityTopicText.Text = "OnGuard/{Camera}/Stopped";
      // 
      // MotionActivityPayloadText
      // 
      this.MotionActivityPayloadText.Location = new System.Drawing.Point(160, 659);
      this.MotionActivityPayloadText.Name = "MotionActivityPayloadText";
      this.MotionActivityPayloadText.Size = new System.Drawing.Size(404, 20);
      this.MotionActivityPayloadText.TabIndex = 20;
      this.MotionActivityPayloadText.Text = "{Picture}";
      // 
      // label13
      // 
      this.label13.AutoSize = true;
      this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label13.Location = new System.Drawing.Point(6, 726);
      this.label13.Name = "label13";
      this.label13.Size = new System.Drawing.Size(150, 20);
      this.label13.TabIndex = 21;
      this.label13.Text = "Stopped Payload:";
      // 
      // StoppedPayloadText
      // 
      this.StoppedPayloadText.Location = new System.Drawing.Point(162, 728);
      this.StoppedPayloadText.Name = "StoppedPayloadText";
      this.StoppedPayloadText.Size = new System.Drawing.Size(404, 20);
      this.StoppedPayloadText.TabIndex = 22;
      this.StoppedPayloadText.Text = "{Motion}";
      // 
      // label14
      // 
      this.label14.AutoSize = true;
      this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label14.Location = new System.Drawing.Point(18, 657);
      this.label14.Name = "label14";
      this.label14.Size = new System.Drawing.Size(136, 20);
      this.label14.TabIndex = 23;
      this.label14.Text = "Motion Payload:";
      // 
      // MQTTSettings
      // 
      this.AcceptButton = this.OKButton;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.cancelButton;
      this.ClientSize = new System.Drawing.Size(581, 802);
      this.Controls.Add(this.label14);
      this.Controls.Add(this.StoppedPayloadText);
      this.Controls.Add(this.label13);
      this.Controls.Add(this.MotionActivityPayloadText);
      this.Controls.Add(this.StoppedActivityTopicText);
      this.Controls.Add(this.label12);
      this.Controls.Add(this.MotionActivityText);
      this.Controls.Add(this.label11);
      this.Controls.Add(this.label10);
      this.Controls.Add(this.label9);
      this.Controls.Add(this.UseSecureLinkCheck);
      this.Controls.Add(this.label8);
      this.Controls.Add(this.label7);
      this.Controls.Add(this.CoolDownNumeric);
      this.Controls.Add(this.label6);
      this.Controls.Add(this.cancelButton);
      this.Controls.Add(this.OKButton);
      this.Controls.Add(this.PasswordText);
      this.Controls.Add(this.label5);
      this.Controls.Add(this.UserText);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.PortNumeric);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.ServerText);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Name = "MQTTSettings";
      this.Text = "MQTT Settings";
      ((System.ComponentModel.ISupportInitialize)(this.PortNumeric)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.CoolDownNumeric)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox ServerText;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.NumericUpDown PortNumeric;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.TextBox UserText;
    private System.Windows.Forms.TextBox PasswordText;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Button OKButton;
    private System.Windows.Forms.Button cancelButton;
    private System.Windows.Forms.NumericUpDown CoolDownNumeric;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.CheckBox UseSecureLinkCheck;
    private System.Windows.Forms.Label label9;
    private System.Windows.Forms.Label label10;
    private System.Windows.Forms.Label label11;
    private System.Windows.Forms.TextBox MotionActivityText;
    private System.Windows.Forms.Label label12;
    private System.Windows.Forms.TextBox StoppedActivityTopicText;
    private System.Windows.Forms.TextBox MotionActivityPayloadText;
    private System.Windows.Forms.Label label13;
    private System.Windows.Forms.TextBox StoppedPayloadText;
    private System.Windows.Forms.Label label14;
  }
}