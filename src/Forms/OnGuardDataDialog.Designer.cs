
namespace OnGuardCore
{
  partial class OnGuardDataDialog
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
      this.FormCancelButton = new System.Windows.Forms.Button();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.DefaultDataButton = new System.Windows.Forms.Button();
      this.BrowseButton = new System.Windows.Forms.Button();
      this.FileText = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.groupBox2 = new System.Windows.Forms.GroupBox();
      this.DefaultDBButton = new System.Windows.Forms.Button();
      this.buttonBrowseDatabase = new System.Windows.Forms.Button();
      this.pathDatabaseText = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.LiveCameraLabel = new System.Windows.Forms.Label();
      this.FormHelpButton = new System.Windows.Forms.Button();
      this.groupBox1.SuspendLayout();
      this.groupBox2.SuspendLayout();
      this.SuspendLayout();
      // 
      // OKButton
      // 
      this.OKButton.Location = new System.Drawing.Point(335, 217);
      this.OKButton.Name = "OKButton";
      this.OKButton.Size = new System.Drawing.Size(75, 23);
      this.OKButton.TabIndex = 0;
      this.OKButton.Text = "OK";
      this.OKButton.UseVisualStyleBackColor = true;
      this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
      // 
      // FormCancelButton
      // 
      this.FormCancelButton.Location = new System.Drawing.Point(416, 217);
      this.FormCancelButton.Name = "FormCancelButton";
      this.FormCancelButton.Size = new System.Drawing.Size(75, 23);
      this.FormCancelButton.TabIndex = 1;
      this.FormCancelButton.Text = "Cancel";
      this.FormCancelButton.UseVisualStyleBackColor = true;
      this.FormCancelButton.Click += new System.EventHandler(this.CancelButton_Click);
      // 
      // groupBox1
      // 
      this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
      this.groupBox1.Controls.Add(this.DefaultDataButton);
      this.groupBox1.Controls.Add(this.BrowseButton);
      this.groupBox1.Controls.Add(this.FileText);
      this.groupBox1.Controls.Add(this.label1);
      this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.groupBox1.Location = new System.Drawing.Point(4, 44);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(800, 72);
      this.groupBox1.TabIndex = 2;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Specify Settings/Log Files Location";
      // 
      // DefaultDataButton
      // 
      this.DefaultDataButton.Location = new System.Drawing.Point(684, 33);
      this.DefaultDataButton.Name = "DefaultDataButton";
      this.DefaultDataButton.Size = new System.Drawing.Size(91, 23);
      this.DefaultDataButton.TabIndex = 2;
      this.DefaultDataButton.Text = "Use Default";
      this.DefaultDataButton.UseVisualStyleBackColor = true;
      this.DefaultDataButton.Click += new System.EventHandler(this.DefaultDataButton_Click);
      // 
      // BrowseButton
      // 
      this.BrowseButton.Location = new System.Drawing.Point(603, 33);
      this.BrowseButton.Name = "BrowseButton";
      this.BrowseButton.Size = new System.Drawing.Size(75, 23);
      this.BrowseButton.TabIndex = 1;
      this.BrowseButton.Text = "Browse";
      this.BrowseButton.UseVisualStyleBackColor = true;
      this.BrowseButton.Click += new System.EventHandler(this.FileBrowseClick);
      // 
      // FileText
      // 
      this.FileText.Location = new System.Drawing.Point(199, 33);
      this.FileText.Name = "FileText";
      this.FileText.Size = new System.Drawing.Size(394, 23);
      this.FileText.TabIndex = 0;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.label1.Location = new System.Drawing.Point(59, 36);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(127, 16);
      this.label1.TabIndex = 44;
      this.label1.Text = "Data Fille Folder:";
      // 
      // groupBox2
      // 
      this.groupBox2.BackColor = System.Drawing.SystemColors.Control;
      this.groupBox2.Controls.Add(this.DefaultDBButton);
      this.groupBox2.Controls.Add(this.buttonBrowseDatabase);
      this.groupBox2.Controls.Add(this.pathDatabaseText);
      this.groupBox2.Controls.Add(this.label2);
      this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.groupBox2.Location = new System.Drawing.Point(4, 128);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new System.Drawing.Size(800, 74);
      this.groupBox2.TabIndex = 47;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "Specify Database Location";
      // 
      // DefaultDBButton
      // 
      this.DefaultDBButton.Location = new System.Drawing.Point(684, 34);
      this.DefaultDBButton.Name = "DefaultDBButton";
      this.DefaultDBButton.Size = new System.Drawing.Size(91, 23);
      this.DefaultDBButton.TabIndex = 2;
      this.DefaultDBButton.Text = "Use Default";
      this.DefaultDBButton.UseVisualStyleBackColor = true;
      this.DefaultDBButton.Click += new System.EventHandler(this.DefaultDBButton_Click);
      // 
      // buttonBrowseDatabase
      // 
      this.buttonBrowseDatabase.Location = new System.Drawing.Point(603, 35);
      this.buttonBrowseDatabase.Name = "buttonBrowseDatabase";
      this.buttonBrowseDatabase.Size = new System.Drawing.Size(75, 23);
      this.buttonBrowseDatabase.TabIndex = 1;
      this.buttonBrowseDatabase.Text = "Browse";
      this.buttonBrowseDatabase.UseVisualStyleBackColor = true;
      this.buttonBrowseDatabase.Click += new System.EventHandler(this.BrowseDatabaseClick);
      // 
      // pathDatabaseText
      // 
      this.pathDatabaseText.Location = new System.Drawing.Point(199, 35);
      this.pathDatabaseText.Name = "pathDatabaseText";
      this.pathDatabaseText.Size = new System.Drawing.Size(394, 23);
      this.pathDatabaseText.TabIndex = 0;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.label2.Location = new System.Drawing.Point(8, 37);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(178, 16);
      this.label2.TabIndex = 47;
      this.label2.Text = "Motion Database Folder:";
      // 
      // LiveCameraLabel
      // 
      this.LiveCameraLabel.AutoSize = true;
      this.LiveCameraLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.LiveCameraLabel.Location = new System.Drawing.Point(317, 14);
      this.LiveCameraLabel.Name = "LiveCameraLabel";
      this.LiveCameraLabel.Size = new System.Drawing.Size(193, 16);
      this.LiveCameraLabel.TabIndex = 48;
      this.LiveCameraLabel.Text = "Set the Data Files Location";
      // 
      // FormHelpButton
      // 
      this.FormHelpButton.Location = new System.Drawing.Point(740, 217);
      this.FormHelpButton.Name = "FormHelpButton";
      this.FormHelpButton.Size = new System.Drawing.Size(75, 23);
      this.FormHelpButton.TabIndex = 2;
      this.FormHelpButton.Text = "Help!";
      this.FormHelpButton.UseVisualStyleBackColor = true;
      this.FormHelpButton.Click += new System.EventHandler(this.HelpButton_Click);
      // 
      // OnGuardDataDialog
      // 
      this.AcceptButton = this.OKButton;
      this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
      this.AutoScroll = true;
      this.BackColor = System.Drawing.SystemColors.Control;
      this.ClientSize = new System.Drawing.Size(827, 254);
      this.Controls.Add(this.FormHelpButton);
      this.Controls.Add(this.LiveCameraLabel);
      this.Controls.Add(this.groupBox2);
      this.Controls.Add(this.groupBox1);
      this.Controls.Add(this.FormCancelButton);
      this.Controls.Add(this.OKButton);
      this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      this.Name = "OnGuardDataDialog";
      this.Text = "Set the Location for On Guard Data  Files";
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.groupBox2.ResumeLayout(false);
      this.groupBox2.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button OKButton;
    private System.Windows.Forms.Button FormCancelButton;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox FileText;
    private System.Windows.Forms.Button BrowseButton;
    private System.Windows.Forms.GroupBox groupBox2;
    private System.Windows.Forms.Button buttonBrowseDatabase;
    private System.Windows.Forms.TextBox pathDatabaseText;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label LiveCameraLabel;
    private System.Windows.Forms.Button FormHelpButton;
    private System.Windows.Forms.Button DefaultDataButton;
    private System.Windows.Forms.Button DefaultDBButton;
  }
}