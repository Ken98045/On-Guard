
namespace OnGuardCore
{
  partial class ISpySnapshot
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
      this.DownloadButton = new System.Windows.Forms.Button();
      this.label3 = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.MakeCombo = new System.Windows.Forms.ComboBox();
      this.ModelCombo = new System.Windows.Forms.ComboBox();
      this.ListBoxURLs = new System.Windows.Forms.ListBox();
      this.okButton = new System.Windows.Forms.Button();
      this.cancelButton = new System.Windows.Forms.Button();
      this.label5 = new System.Windows.Forms.Label();
      this.uriTextBox = new System.Windows.Forms.TextBox();
      this.label6 = new System.Windows.Forms.Label();
      this.label7 = new System.Windows.Forms.Label();
      this.ISpySnapshotHelp = new System.Windows.Forms.Button();
      this.PictureImageBox = new System.Windows.Forms.PictureBox();
      this.label2 = new System.Windows.Forms.Label();
      this.label8 = new System.Windows.Forms.Label();
      this.label9 = new System.Windows.Forms.Label();
      this.XResolutionLabel = new System.Windows.Forms.Label();
      this.YResolutionLabel = new System.Windows.Forms.Label();
      this.AutoFindButton = new System.Windows.Forms.Button();
      this.label10 = new System.Windows.Forms.Label();
      this.panel1 = new System.Windows.Forms.Panel();
      ((System.ComponentModel.ISupportInitialize)(this.PictureImageBox)).BeginInit();
      this.panel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.label1.Location = new System.Drawing.Point(268, 19);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(265, 16);
      this.label1.TabIndex = 27;
      this.label1.Text = "iSpy Camera Snapshot (.jpg) Settings";
      // 
      // DownloadButton
      // 
      this.DownloadButton.Location = new System.Drawing.Point(50, 62);
      this.DownloadButton.Name = "DownloadButton";
      this.DownloadButton.Size = new System.Drawing.Size(112, 23);
      this.DownloadButton.TabIndex = 29;
      this.DownloadButton.Text = "Download";
      this.DownloadButton.UseVisualStyleBackColor = true;
      this.DownloadButton.Click += new System.EventHandler(this.DownloadButton_Click);
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.label3.Location = new System.Drawing.Point(187, 65);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(103, 16);
      this.label3.TabIndex = 31;
      this.label3.Text = "Camera Make";
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.label4.Location = new System.Drawing.Point(473, 62);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(108, 16);
      this.label4.TabIndex = 32;
      this.label4.Text = "Camera Model";
      // 
      // MakeCombo
      // 
      this.MakeCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.MakeCombo.FormattingEnabled = true;
      this.MakeCombo.Location = new System.Drawing.Point(294, 63);
      this.MakeCombo.Name = "MakeCombo";
      this.MakeCombo.Size = new System.Drawing.Size(157, 23);
      this.MakeCombo.TabIndex = 33;
      this.MakeCombo.SelectedIndexChanged += new System.EventHandler(this.MakeSelectionChanged);
      // 
      // ModelCombo
      // 
      this.ModelCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.ModelCombo.FormattingEnabled = true;
      this.ModelCombo.Location = new System.Drawing.Point(599, 60);
      this.ModelCombo.Name = "ModelCombo";
      this.ModelCombo.Size = new System.Drawing.Size(157, 23);
      this.ModelCombo.TabIndex = 34;
      this.ModelCombo.SelectedIndexChanged += new System.EventHandler(this.ModelSelectionChanged);
      // 
      // ListBoxURLs
      // 
      this.ListBoxURLs.FormattingEnabled = true;
      this.ListBoxURLs.ItemHeight = 15;
      this.ListBoxURLs.Location = new System.Drawing.Point(50, 92);
      this.ListBoxURLs.Name = "ListBoxURLs";
      this.ListBoxURLs.Size = new System.Drawing.Size(702, 124);
      this.ListBoxURLs.TabIndex = 35;
      this.ListBoxURLs.SelectedIndexChanged += new System.EventHandler(this.OnDefinitionSelected);
      // 
      // okButton
      // 
      this.okButton.Location = new System.Drawing.Point(318, 487);
      this.okButton.Name = "okButton";
      this.okButton.Size = new System.Drawing.Size(75, 23);
      this.okButton.TabIndex = 36;
      this.okButton.Text = "OK";
      this.okButton.UseVisualStyleBackColor = true;
      this.okButton.Click += new System.EventHandler(this.OkButton_Click);
      // 
      // cancelButton
      // 
      this.cancelButton.Location = new System.Drawing.Point(408, 487);
      this.cancelButton.Name = "cancelButton";
      this.cancelButton.Size = new System.Drawing.Size(75, 23);
      this.cancelButton.TabIndex = 37;
      this.cancelButton.Text = "Cancel";
      this.cancelButton.UseVisualStyleBackColor = true;
      this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.label5.Location = new System.Drawing.Point(13, 290);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(99, 16);
      this.label5.TabIndex = 38;
      this.label5.Text = "Request URL";
      // 
      // uriTextBox
      // 
      this.uriTextBox.Location = new System.Drawing.Point(118, 288);
      this.uriTextBox.Name = "uriTextBox";
      this.uriTextBox.Size = new System.Drawing.Size(583, 23);
      this.uriTextBox.TabIndex = 39;
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Location = new System.Drawing.Point(706, 291);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(82, 15);
      this.label6.TabIndex = 40;
      this.label6.Text = "Edit as desired";
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      this.label7.Location = new System.Drawing.Point(148, 223);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(504, 32);
      this.label7.TabIndex = 41;
      this.label7.Text = "If there is more than one URL listed for the camera select the URL desired.\r\nNote" +
    " that a different URL may give a different result (resolution) or may not work a" +
    "t all.";
      this.label7.Click += new System.EventHandler(this.label7_Click);
      // 
      // ISpySnapshotHelp
      // 
      this.ISpySnapshotHelp.Location = new System.Drawing.Point(715, 494);
      this.ISpySnapshotHelp.Name = "ISpySnapshotHelp";
      this.ISpySnapshotHelp.Size = new System.Drawing.Size(75, 23);
      this.ISpySnapshotHelp.TabIndex = 42;
      this.ISpySnapshotHelp.Text = "Help!";
      this.ISpySnapshotHelp.UseVisualStyleBackColor = true;
      this.ISpySnapshotHelp.Click += new System.EventHandler(this.ISpySnapshotHelp_Click);
      // 
      // PictureImageBox
      // 
      this.PictureImageBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.PictureImageBox.Location = new System.Drawing.Point(381, 331);
      this.PictureImageBox.Name = "PictureImageBox";
      this.PictureImageBox.Size = new System.Drawing.Size(240, 141);
      this.PictureImageBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
      this.PictureImageBox.TabIndex = 47;
      this.PictureImageBox.TabStop = false;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.label2.Location = new System.Drawing.Point(314, 394);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(51, 16);
      this.label2.TabIndex = 48;
      this.label2.Text = "Result";
      // 
      // label8
      // 
      this.label8.AutoSize = true;
      this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.label8.Location = new System.Drawing.Point(631, 365);
      this.label8.Name = "label8";
      this.label8.Size = new System.Drawing.Size(98, 16);
      this.label8.TabIndex = 49;
      this.label8.Text = "X Resolution:";
      // 
      // label9
      // 
      this.label9.AutoSize = true;
      this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.label9.Location = new System.Drawing.Point(631, 394);
      this.label9.Name = "label9";
      this.label9.Size = new System.Drawing.Size(99, 16);
      this.label9.TabIndex = 50;
      this.label9.Text = "Y Resolution:";
      // 
      // XResolutionLabel
      // 
      this.XResolutionLabel.AutoSize = true;
      this.XResolutionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      this.XResolutionLabel.Location = new System.Drawing.Point(735, 365);
      this.XResolutionLabel.Name = "XResolutionLabel";
      this.XResolutionLabel.Size = new System.Drawing.Size(0, 16);
      this.XResolutionLabel.TabIndex = 51;
      // 
      // YResolutionLabel
      // 
      this.YResolutionLabel.AutoSize = true;
      this.YResolutionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      this.YResolutionLabel.Location = new System.Drawing.Point(736, 394);
      this.YResolutionLabel.Name = "YResolutionLabel";
      this.YResolutionLabel.Size = new System.Drawing.Size(0, 16);
      this.YResolutionLabel.TabIndex = 52;
      // 
      // AutoFindButton
      // 
      this.AutoFindButton.Location = new System.Drawing.Point(90, 107);
      this.AutoFindButton.Name = "AutoFindButton";
      this.AutoFindButton.Size = new System.Drawing.Size(97, 23);
      this.AutoFindButton.TabIndex = 53;
      this.AutoFindButton.Text = "Auto Find";
      this.AutoFindButton.UseVisualStyleBackColor = true;
      this.AutoFindButton.Click += new System.EventHandler(this.AutoFindButton_Click);
      // 
      // label10
      // 
      this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      this.label10.Location = new System.Drawing.Point(7, 8);
      this.label10.Name = "label10";
      this.label10.Size = new System.Drawing.Size(260, 84);
      this.label10.TabIndex = 54;
      this.label10.Text = "If you are having trouble finding a camera definition, or your camera definition " +
    "doesn\'t do what you expect/want you can try to automatically search for a camera" +
    " definition that \"just works\".";
      // 
      // panel1
      // 
      this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.panel1.Controls.Add(this.label10);
      this.panel1.Controls.Add(this.AutoFindButton);
      this.panel1.Location = new System.Drawing.Point(12, 331);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(278, 141);
      this.panel1.TabIndex = 55;
      // 
      // ISpySnapshot
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
      this.AutoScroll = true;
      this.ClientSize = new System.Drawing.Size(800, 521);
      this.Controls.Add(this.panel1);
      this.Controls.Add(this.YResolutionLabel);
      this.Controls.Add(this.XResolutionLabel);
      this.Controls.Add(this.label9);
      this.Controls.Add(this.label8);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.PictureImageBox);
      this.Controls.Add(this.ISpySnapshotHelp);
      this.Controls.Add(this.label7);
      this.Controls.Add(this.label6);
      this.Controls.Add(this.uriTextBox);
      this.Controls.Add(this.label5);
      this.Controls.Add(this.cancelButton);
      this.Controls.Add(this.okButton);
      this.Controls.Add(this.ListBoxURLs);
      this.Controls.Add(this.ModelCombo);
      this.Controls.Add(this.MakeCombo);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.DownloadButton);
      this.Controls.Add(this.label1);
      this.Name = "ISpySnapshot";
      this.Text = "ISpy Snapshot";
      this.Load += new System.EventHandler(this.ISpySnapshot_Load);
      ((System.ComponentModel.ISupportInitialize)(this.PictureImageBox)).EndInit();
      this.panel1.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Button DownloadButton;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.ComboBox MakeCombo;
    private System.Windows.Forms.ComboBox ModelCombo;
    private System.Windows.Forms.ListBox ListBoxURLs;
    private System.Windows.Forms.Button okButton;
    private System.Windows.Forms.Button cancelButton;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.TextBox uriTextBox;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.Button ISpySnapshotHelp;
    private System.Windows.Forms.PictureBox PictureImageBox;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.Label label9;
    private System.Windows.Forms.Label XResolutionLabel;
    private System.Windows.Forms.Label YResolutionLabel;
    private System.Windows.Forms.Button AutoFindButton;
    private System.Windows.Forms.Label label10;
    private System.Windows.Forms.Panel panel1;
  }
}