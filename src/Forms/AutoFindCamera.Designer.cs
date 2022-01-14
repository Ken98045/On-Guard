
namespace OnGuardCore
{
  partial class AutoFindCamera
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AutoFindCamera));
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.OKButton = new System.Windows.Forms.Button();
      this.FormCancelButton = new System.Windows.Forms.Button();
      this.label3 = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.NumericMinRes = new System.Windows.Forms.NumericUpDown();
      this.NumericMaxRes = new System.Windows.Forms.NumericUpDown();
      this.SearchButton = new System.Windows.Forms.Button();
      this.pictureImage = new System.Windows.Forms.PictureBox();
      this.label5 = new System.Windows.Forms.Label();
      this.label6 = new System.Windows.Forms.Label();
      this.MakeTextBox = new System.Windows.Forms.TextBox();
      this.ModelTextBox = new System.Windows.Forms.TextBox();
      this.label7 = new System.Windows.Forms.Label();
      this.label8 = new System.Windows.Forms.Label();
      this.WidthTextBox = new System.Windows.Forms.TextBox();
      this.HeightTextBox = new System.Windows.Forms.TextBox();
      this.StopButton = new System.Windows.Forms.Button();
      this.label9 = new System.Windows.Forms.Label();
      this.TriedCountTextBox = new System.Windows.Forms.TextBox();
      ((System.ComponentModel.ISupportInitialize)(this.NumericMinRes)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.NumericMaxRes)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureImage)).BeginInit();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.label1.Location = new System.Drawing.Point(243, 23);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(216, 16);
      this.label1.TabIndex = 28;
      this.label1.Text = "Auto Find a Camera Defiinition";
      // 
      // label2
      // 
      this.label2.Location = new System.Drawing.Point(2, 57);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(668, 108);
      this.label2.TabIndex = 29;
      this.label2.Text = resources.GetString("label2.Text");
      // 
      // OKButton
      // 
      this.OKButton.Location = new System.Drawing.Point(277, 439);
      this.OKButton.Name = "OKButton";
      this.OKButton.Size = new System.Drawing.Size(66, 23);
      this.OKButton.TabIndex = 30;
      this.OKButton.Text = "OK";
      this.OKButton.UseVisualStyleBackColor = true;
      this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
      // 
      // FormCancelButton
      // 
      this.FormCancelButton.Location = new System.Drawing.Point(358, 439);
      this.FormCancelButton.Name = "FormCancelButton";
      this.FormCancelButton.Size = new System.Drawing.Size(66, 23);
      this.FormCancelButton.TabIndex = 31;
      this.FormCancelButton.Text = "Cancel";
      this.FormCancelButton.UseVisualStyleBackColor = true;
      this.FormCancelButton.Click += new System.EventHandler(this.CancelButton_Click);
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.label3.Location = new System.Drawing.Point(45, 208);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(219, 16);
      this.label3.TabIndex = 33;
      this.label3.Text = "Minimum Horizontal Resolution";
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.label4.Location = new System.Drawing.Point(37, 246);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(227, 16);
      this.label4.TabIndex = 34;
      this.label4.Text = "Maximum Horizontal Resolution:";
      // 
      // NumericMinRes
      // 
      this.NumericMinRes.Location = new System.Drawing.Point(286, 207);
      this.NumericMinRes.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
      this.NumericMinRes.Name = "NumericMinRes";
      this.NumericMinRes.Size = new System.Drawing.Size(120, 23);
      this.NumericMinRes.TabIndex = 37;
      this.NumericMinRes.Value = new decimal(new int[] {
            320,
            0,
            0,
            0});
      // 
      // NumericMaxRes
      // 
      this.NumericMaxRes.Location = new System.Drawing.Point(286, 246);
      this.NumericMaxRes.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
      this.NumericMaxRes.Name = "NumericMaxRes";
      this.NumericMaxRes.Size = new System.Drawing.Size(120, 23);
      this.NumericMaxRes.TabIndex = 38;
      this.NumericMaxRes.Value = new decimal(new int[] {
            9999,
            0,
            0,
            0});
      this.NumericMaxRes.ValueChanged += new System.EventHandler(this.NumericUpDown1_ValueChanged);
      // 
      // SearchButton
      // 
      this.SearchButton.Location = new System.Drawing.Point(91, 399);
      this.SearchButton.Name = "SearchButton";
      this.SearchButton.Size = new System.Drawing.Size(97, 23);
      this.SearchButton.TabIndex = 39;
      this.SearchButton.Text = "Search";
      this.SearchButton.UseVisualStyleBackColor = true;
      this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
      // 
      // pictureImage
      // 
      this.pictureImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.pictureImage.Location = new System.Drawing.Point(450, 195);
      this.pictureImage.Name = "pictureImage";
      this.pictureImage.Size = new System.Drawing.Size(220, 178);
      this.pictureImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
      this.pictureImage.TabIndex = 47;
      this.pictureImage.TabStop = false;
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.label5.Location = new System.Drawing.Point(114, 287);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(150, 16);
      this.label5.TabIndex = 48;
      this.label5.Text = "Found Camera Make";
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.label6.Location = new System.Drawing.Point(109, 326);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(155, 16);
      this.label6.TabIndex = 49;
      this.label6.Text = "Found Camera Model";
      // 
      // MakeTextBox
      // 
      this.MakeTextBox.Location = new System.Drawing.Point(286, 285);
      this.MakeTextBox.Name = "MakeTextBox";
      this.MakeTextBox.ReadOnly = true;
      this.MakeTextBox.Size = new System.Drawing.Size(120, 23);
      this.MakeTextBox.TabIndex = 50;
      // 
      // ModelTextBox
      // 
      this.ModelTextBox.Location = new System.Drawing.Point(286, 324);
      this.ModelTextBox.Name = "ModelTextBox";
      this.ModelTextBox.ReadOnly = true;
      this.ModelTextBox.Size = new System.Drawing.Size(120, 23);
      this.ModelTextBox.TabIndex = 51;
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.Location = new System.Drawing.Point(454, 383);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(39, 15);
      this.label7.TabIndex = 52;
      this.label7.Text = "Width";
      // 
      // label8
      // 
      this.label8.AutoSize = true;
      this.label8.Location = new System.Drawing.Point(553, 383);
      this.label8.Name = "label8";
      this.label8.Size = new System.Drawing.Size(43, 15);
      this.label8.TabIndex = 53;
      this.label8.Text = "Height";
      // 
      // WidthTextBox
      // 
      this.WidthTextBox.Location = new System.Drawing.Point(499, 380);
      this.WidthTextBox.Name = "WidthTextBox";
      this.WidthTextBox.ReadOnly = true;
      this.WidthTextBox.Size = new System.Drawing.Size(43, 23);
      this.WidthTextBox.TabIndex = 54;
      // 
      // HeightTextBox
      // 
      this.HeightTextBox.Location = new System.Drawing.Point(602, 380);
      this.HeightTextBox.Name = "HeightTextBox";
      this.HeightTextBox.ReadOnly = true;
      this.HeightTextBox.Size = new System.Drawing.Size(43, 23);
      this.HeightTextBox.TabIndex = 55;
      // 
      // StopButton
      // 
      this.StopButton.Location = new System.Drawing.Point(200, 399);
      this.StopButton.Name = "StopButton";
      this.StopButton.Size = new System.Drawing.Size(97, 23);
      this.StopButton.TabIndex = 56;
      this.StopButton.Text = "Stop";
      this.StopButton.UseVisualStyleBackColor = true;
      this.StopButton.Click += new System.EventHandler(this.StopButton_Click);
      // 
      // label9
      // 
      this.label9.AutoSize = true;
      this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.label9.Location = new System.Drawing.Point(55, 365);
      this.label9.Name = "label9";
      this.label9.Size = new System.Drawing.Size(209, 16);
      this.label9.TabIndex = 57;
      this.label9.Text = "Unique Camera URLs Tested";
      // 
      // TriedCountTextBox
      // 
      this.TriedCountTextBox.Location = new System.Drawing.Point(286, 363);
      this.TriedCountTextBox.Name = "TriedCountTextBox";
      this.TriedCountTextBox.ReadOnly = true;
      this.TriedCountTextBox.Size = new System.Drawing.Size(65, 23);
      this.TriedCountTextBox.TabIndex = 58;
      // 
      // AutoFindCamera
      // 
      this.AcceptButton = this.OKButton;
      this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
      this.ClientSize = new System.Drawing.Size(701, 466);
      this.Controls.Add(this.TriedCountTextBox);
      this.Controls.Add(this.label9);
      this.Controls.Add(this.StopButton);
      this.Controls.Add(this.HeightTextBox);
      this.Controls.Add(this.WidthTextBox);
      this.Controls.Add(this.label8);
      this.Controls.Add(this.label7);
      this.Controls.Add(this.ModelTextBox);
      this.Controls.Add(this.MakeTextBox);
      this.Controls.Add(this.label6);
      this.Controls.Add(this.label5);
      this.Controls.Add(this.pictureImage);
      this.Controls.Add(this.SearchButton);
      this.Controls.Add(this.NumericMaxRes);
      this.Controls.Add(this.NumericMinRes);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.FormCancelButton);
      this.Controls.Add(this.OKButton);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Name = "AutoFindCamera";
      this.Text = "Auto Find Camera";
      ((System.ComponentModel.ISupportInitialize)(this.NumericMinRes)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.NumericMaxRes)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureImage)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Button OKButton;
    private System.Windows.Forms.Button FormCancelButton;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.NumericUpDown NumericMinRes;
    private System.Windows.Forms.NumericUpDown NumericMaxRes;
    private System.Windows.Forms.Button SearchButton;
    private System.Windows.Forms.PictureBox pictureImage;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.TextBox MakeTextBox;
    private System.Windows.Forms.TextBox ModelTextBox;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.TextBox WidthTextBox;
    private System.Windows.Forms.TextBox HeightTextBox;
    private System.Windows.Forms.Button StopButton;
    private System.Windows.Forms.Label label9;
    private System.Windows.Forms.TextBox TriedCountTextBox;
  }
}