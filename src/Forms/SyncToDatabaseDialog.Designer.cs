
namespace OnGuardCore
{
  partial class SyncToDatabaseDialog
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SyncToDatabaseDialog));
      this.label1 = new System.Windows.Forms.Label();
      this.okButton = new System.Windows.Forms.Button();
      this.cancelButton = new System.Windows.Forms.Button();
      this.panel1 = new System.Windows.Forms.Panel();
      this.panel2 = new System.Windows.Forms.Panel();
      this.label4 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.IntervalNumeric = new System.Windows.Forms.NumericUpDown();
      this.label2 = new System.Windows.Forms.Label();
      this.panel1.SuspendLayout();
      this.panel2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.IntervalNumeric)).BeginInit();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.label1.Location = new System.Drawing.Point(12, 10);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(486, 317);
      this.label1.TabIndex = 0;
      this.label1.Text = resources.GetString("label1.Text");
      // 
      // okButton
      // 
      this.okButton.Location = new System.Drawing.Point(199, 496);
      this.okButton.Name = "okButton";
      this.okButton.Size = new System.Drawing.Size(75, 23);
      this.okButton.TabIndex = 1;
      this.okButton.Text = "OK";
      this.okButton.UseVisualStyleBackColor = true;
      this.okButton.Click += new System.EventHandler(this.OkButton_Click);
      // 
      // cancelButton
      // 
      this.cancelButton.Location = new System.Drawing.Point(282, 496);
      this.cancelButton.Name = "cancelButton";
      this.cancelButton.Size = new System.Drawing.Size(75, 23);
      this.cancelButton.TabIndex = 2;
      this.cancelButton.Text = "Cancel";
      this.cancelButton.UseVisualStyleBackColor = true;
      this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
      // 
      // panel1
      // 
      this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.panel1.Controls.Add(this.label1);
      this.panel1.Location = new System.Drawing.Point(12, 12);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(523, 341);
      this.panel1.TabIndex = 3;
      // 
      // panel2
      // 
      this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.panel2.Controls.Add(this.label4);
      this.panel2.Controls.Add(this.label3);
      this.panel2.Controls.Add(this.IntervalNumeric);
      this.panel2.Controls.Add(this.label2);
      this.panel2.Location = new System.Drawing.Point(12, 368);
      this.panel2.Name = "panel2";
      this.panel2.Size = new System.Drawing.Size(523, 111);
      this.panel2.TabIndex = 4;
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.label4.Location = new System.Drawing.Point(336, 77);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(60, 15);
      this.label4.TabIndex = 3;
      this.label4.Text = "(Seconds)";
      // 
      // label3
      // 
      this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.label3.Location = new System.Drawing.Point(12, 14);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(486, 49);
      this.label3.TabIndex = 2;
      this.label3.Text = resources.GetString("label3.Text");
      // 
      // IntervalNumeric
      // 
      this.IntervalNumeric.DecimalPlaces = 2;
      this.IntervalNumeric.Location = new System.Drawing.Point(263, 75);
      this.IntervalNumeric.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
      this.IntervalNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            196608});
      this.IntervalNumeric.Name = "IntervalNumeric";
      this.IntervalNumeric.Size = new System.Drawing.Size(66, 23);
      this.IntervalNumeric.TabIndex = 1;
      this.IntervalNumeric.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.label2.Location = new System.Drawing.Point(124, 77);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(127, 15);
      this.label2.TabIndex = 0;
      this.label2.Text = "Time Between Pictures";
      // 
      // SyncToDatabaseDialog
      // 
      this.AcceptButton = this.okButton;
      this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
      this.AutoScroll = true;
      this.CancelButton = this.okButton;
      this.ClientSize = new System.Drawing.Size(547, 524);
      this.Controls.Add(this.panel2);
      this.Controls.Add(this.panel1);
      this.Controls.Add(this.cancelButton);
      this.Controls.Add(this.okButton);
      this.Name = "SyncToDatabaseDialog";
      this.Text = "Sync To Database";
      this.panel1.ResumeLayout(false);
      this.panel2.ResumeLayout(false);
      this.panel2.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.IntervalNumeric)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Button okButton;
    private System.Windows.Forms.Button cancelButton;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Panel panel2;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.NumericUpDown IntervalNumeric;
    private System.Windows.Forms.Label label2;
  }
}