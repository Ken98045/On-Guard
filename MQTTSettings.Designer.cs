
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
      this.label1.Text = resources.GetString("label1.Text");
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label2.Location = new System.Drawing.Point(33, 152);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(200, 20);
      this.label2.TabIndex = 1;
      this.label2.Text = "Server/Broker Address: ";
      // 
      // ServerText
      // 
      this.ServerText.Location = new System.Drawing.Point(245, 154);
      this.ServerText.Name = "ServerText";
      this.ServerText.Size = new System.Drawing.Size(308, 20);
      this.ServerText.TabIndex = 0;
      this.ServerText.Text = "localhost";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label3.Location = new System.Drawing.Point(181, 202);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(52, 20);
      this.label3.TabIndex = 3;
      this.label3.Text = "Port: ";
      // 
      // PortNumeric
      // 
      this.PortNumeric.Location = new System.Drawing.Point(245, 200);
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
      this.label4.Location = new System.Drawing.Point(125, 248);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(108, 20);
      this.label4.TabIndex = 5;
      this.label4.Text = "User Name: ";
      // 
      // UserText
      // 
      this.UserText.Location = new System.Drawing.Point(245, 246);
      this.UserText.Name = "UserText";
      this.UserText.Size = new System.Drawing.Size(197, 20);
      this.UserText.TabIndex = 2;
      // 
      // PasswordText
      // 
      this.PasswordText.Location = new System.Drawing.Point(245, 292);
      this.PasswordText.Name = "PasswordText";
      this.PasswordText.Size = new System.Drawing.Size(197, 20);
      this.PasswordText.TabIndex = 3;
      this.PasswordText.UseSystemPasswordChar = true;
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label5.Location = new System.Drawing.Point(125, 296);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(96, 20);
      this.label5.TabIndex = 7;
      this.label5.Text = "Password: ";
      // 
      // OKButton
      // 
      this.OKButton.Location = new System.Drawing.Point(204, 394);
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
      this.cancelButton.Location = new System.Drawing.Point(301, 394);
      this.cancelButton.Name = "cancelButton";
      this.cancelButton.Size = new System.Drawing.Size(75, 23);
      this.cancelButton.TabIndex = 5;
      this.cancelButton.Text = "Cancel";
      this.cancelButton.UseVisualStyleBackColor = true;
      this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
      // 
      // CoolDownNumeric
      // 
      this.CoolDownNumeric.Location = new System.Drawing.Point(245, 338);
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
      this.label6.Location = new System.Drawing.Point(28, 335);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(193, 20);
      this.label6.TabIndex = 9;
      this.label6.Text = "Cool Down Time (sec): ";
      // 
      // label7
      // 
      this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label7.Location = new System.Drawing.Point(14, 330);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(557, 47);
      this.label7.TabIndex = 10;
      this.label7.Text = "If both the User Name and Password entries are NOT blank then On Guard will use a" +
    " secure connection to the MQTT server.\r\n";
      // 
      // MQTTSettings
      // 
      this.AcceptButton = this.OKButton;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.cancelButton;
      this.ClientSize = new System.Drawing.Size(581, 426);
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
  }
}