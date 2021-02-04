
namespace SAAI
{
  partial class AILocationDialog
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AILocationDialog));
      this.OKButton = new System.Windows.Forms.Button();
      this.CancelButton = new System.Windows.Forms.Button();
      this.label12 = new System.Windows.Forms.Label();
      this.testButton = new System.Windows.Forms.Button();
      this.portNumeric = new System.Windows.Forms.NumericUpDown();
      this.label3 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.ipAddressText = new System.Windows.Forms.TextBox();
      this.label4 = new System.Windows.Forms.Label();
      ((System.ComponentModel.ISupportInitialize)(this.portNumeric)).BeginInit();
      this.SuspendLayout();
      // 
      // OKButton
      // 
      this.OKButton.Location = new System.Drawing.Point(217, 264);
      this.OKButton.Name = "OKButton";
      this.OKButton.Size = new System.Drawing.Size(75, 23);
      this.OKButton.TabIndex = 0;
      this.OKButton.Text = "OK";
      this.OKButton.UseVisualStyleBackColor = true;
      this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
      // 
      // CancelButton
      // 
      this.CancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.CancelButton.Location = new System.Drawing.Point(310, 264);
      this.CancelButton.Name = "CancelButton";
      this.CancelButton.Size = new System.Drawing.Size(75, 23);
      this.CancelButton.TabIndex = 1;
      this.CancelButton.Text = "Cancel";
      this.CancelButton.UseVisualStyleBackColor = true;
      // 
      // label12
      // 
      this.label12.AutoSize = true;
      this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label12.Location = new System.Drawing.Point(346, 218);
      this.label12.Name = "label12";
      this.label12.Size = new System.Drawing.Size(108, 16);
      this.label12.TabIndex = 16;
      this.label12.Text = "<---- Important!";
      // 
      // testButton
      // 
      this.testButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
      this.testButton.Location = new System.Drawing.Point(149, 212);
      this.testButton.Name = "testButton";
      this.testButton.Size = new System.Drawing.Size(191, 28);
      this.testButton.TabIndex = 12;
      this.testButton.Text = "Test DeepStack Connection";
      this.testButton.UseVisualStyleBackColor = false;
      this.testButton.Click += new System.EventHandler(this.TestButton_Click);
      // 
      // portNumeric
      // 
      this.portNumeric.Location = new System.Drawing.Point(216, 111);
      this.portNumeric.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
      this.portNumeric.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
      this.portNumeric.Name = "portNumeric";
      this.portNumeric.Size = new System.Drawing.Size(89, 20);
      this.portNumeric.TabIndex = 11;
      this.portNumeric.Value = new decimal(new int[] {
            8090,
            0,
            0,
            0});
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(89, 113);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(121, 13);
      this.label3.TabIndex = 15;
      this.label3.Text = "Port Number fof the AI:  ";
      // 
      // label2
      // 
      this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label2.Location = new System.Drawing.Point(358, 47);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(235, 155);
      this.label2.TabIndex = 14;
      this.label2.Text = resources.GetString("label2.Text");
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(12, 64);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(198, 13);
      this.label1.TabIndex = 13;
      this.label1.Text = "IP Address or computer name  of the  AI:";
      // 
      // ipAddressText
      // 
      this.ipAddressText.Location = new System.Drawing.Point(216, 61);
      this.ipAddressText.Name = "ipAddressText";
      this.ipAddressText.Size = new System.Drawing.Size(134, 20);
      this.ipAddressText.TabIndex = 10;
      this.ipAddressText.Text = "localhost";
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label4.Location = new System.Drawing.Point(197, 21);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(208, 16);
      this.label4.TabIndex = 17;
      this.label4.Text = "Location of the DeepStack AI";
      // 
      // AILocationDialog
      // 
      this.AcceptButton = this.OKButton;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(602, 300);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.label12);
      this.Controls.Add(this.testButton);
      this.Controls.Add(this.portNumeric);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.ipAddressText);
      this.Controls.Add(this.CancelButton);
      this.Controls.Add(this.OKButton);
      this.Name = "AILocationDialog";
      this.Text = "Set AI Location";
      ((System.ComponentModel.ISupportInitialize)(this.portNumeric)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button OKButton;
    private System.Windows.Forms.Button CancelButton;
    private System.Windows.Forms.Label label12;
    private System.Windows.Forms.Button testButton;
    private System.Windows.Forms.NumericUpDown portNumeric;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox ipAddressText;
    private System.Windows.Forms.Label label4;
  }
}