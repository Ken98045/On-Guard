
namespace OnGuardCore
{
  partial class ISpyPTZ
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ISpyPTZ));
      this.label1 = new System.Windows.Forms.Label();
      this.label6 = new System.Windows.Forms.Label();
      this.uriTextBox = new System.Windows.Forms.TextBox();
      this.label5 = new System.Windows.Forms.Label();
      this.ModelCombo = new System.Windows.Forms.ComboBox();
      this.MakeCombo = new System.Windows.Forms.ComboBox();
      this.label4 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.DownloadButton = new System.Windows.Forms.Button();
      this.cancelButton = new System.Windows.Forms.Button();
      this.okButton = new System.Windows.Forms.Button();
      this.DirectionsListView = new System.Windows.Forms.ListView();
      this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
      this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
      this.label2 = new System.Windows.Forms.Label();
      this.FormHelpButton = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.label1.Location = new System.Drawing.Point(285, 20);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(231, 16);
      this.label1.TabIndex = 30;
      this.label1.Text = "iSpy PTZ  Movement Commands";
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Location = new System.Drawing.Point(706, 311);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(82, 15);
      this.label6.TabIndex = 49;
      this.label6.Text = "Edit as desired";
      // 
      // uriTextBox
      // 
      this.uriTextBox.Location = new System.Drawing.Point(75, 308);
      this.uriTextBox.Name = "uriTextBox";
      this.uriTextBox.Size = new System.Drawing.Size(618, 23);
      this.uriTextBox.TabIndex = 48;
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.label5.Location = new System.Drawing.Point(28, 310);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(37, 16);
      this.label5.TabIndex = 47;
      this.label5.Text = "URL";
      // 
      // ModelCombo
      // 
      this.ModelCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.ModelCombo.FormattingEnabled = true;
      this.ModelCombo.Location = new System.Drawing.Point(587, 74);
      this.ModelCombo.Name = "ModelCombo";
      this.ModelCombo.Size = new System.Drawing.Size(157, 23);
      this.ModelCombo.TabIndex = 45;
      this.ModelCombo.SelectedIndexChanged += new System.EventHandler(this.ModelSelectionChanged);
      // 
      // MakeCombo
      // 
      this.MakeCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.MakeCombo.FormattingEnabled = true;
      this.MakeCombo.Location = new System.Drawing.Point(294, 77);
      this.MakeCombo.Name = "MakeCombo";
      this.MakeCombo.Size = new System.Drawing.Size(157, 23);
      this.MakeCombo.TabIndex = 44;
      this.MakeCombo.SelectedIndexChanged += new System.EventHandler(this.MakeSelectionChanged);
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.label4.Location = new System.Drawing.Point(470, 76);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(108, 16);
      this.label4.TabIndex = 43;
      this.label4.Text = "Camera Model";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.label3.Location = new System.Drawing.Point(178, 79);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(103, 16);
      this.label3.TabIndex = 42;
      this.label3.Text = "Camera Make";
      // 
      // DownloadButton
      // 
      this.DownloadButton.Location = new System.Drawing.Point(45, 76);
      this.DownloadButton.Name = "DownloadButton";
      this.DownloadButton.Size = new System.Drawing.Size(112, 23);
      this.DownloadButton.TabIndex = 41;
      this.DownloadButton.Text = "Download";
      this.DownloadButton.UseVisualStyleBackColor = true;
      this.DownloadButton.Click += new System.EventHandler(this.DownloadButton_Click);
      // 
      // cancelButton
      // 
      this.cancelButton.Location = new System.Drawing.Point(431, 403);
      this.cancelButton.Name = "cancelButton";
      this.cancelButton.Size = new System.Drawing.Size(75, 23);
      this.cancelButton.TabIndex = 51;
      this.cancelButton.Text = "Cancel";
      this.cancelButton.UseVisualStyleBackColor = true;
      this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
      // 
      // okButton
      // 
      this.okButton.Location = new System.Drawing.Point(336, 403);
      this.okButton.Name = "okButton";
      this.okButton.Size = new System.Drawing.Size(75, 23);
      this.okButton.TabIndex = 50;
      this.okButton.Text = "OK";
      this.okButton.UseVisualStyleBackColor = true;
      this.okButton.Click += new System.EventHandler(this.OkButton_Click);
      // 
      // DirectionsListView
      // 
      this.DirectionsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
      this.DirectionsListView.FullRowSelect = true;
      this.DirectionsListView.GridLines = true;
      this.DirectionsListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
      this.DirectionsListView.Location = new System.Drawing.Point(32, 105);
      this.DirectionsListView.MultiSelect = false;
      this.DirectionsListView.Name = "DirectionsListView";
      this.DirectionsListView.Size = new System.Drawing.Size(785, 184);
      this.DirectionsListView.TabIndex = 52;
      this.DirectionsListView.UseCompatibleStateImageBehavior = false;
      this.DirectionsListView.View = System.Windows.Forms.View.Details;
      this.DirectionsListView.SelectedIndexChanged += new System.EventHandler(this.DirectionSelectionChanged);
      // 
      // columnHeader1
      // 
      this.columnHeader1.Text = "Direction";
      this.columnHeader1.Width = 100;
      // 
      // columnHeader2
      // 
      this.columnHeader2.Text = "URL";
      this.columnHeader2.Width = 650;
      // 
      // label2
      // 
      this.label2.Location = new System.Drawing.Point(75, 338);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(618, 41);
      this.label2.TabIndex = 53;
      this.label2.Text = resources.GetString("label2.Text");
      // 
      // FormHelpButton
      // 
      this.FormHelpButton.Location = new System.Drawing.Point(756, 403);
      this.FormHelpButton.Name = "FormHelpButton";
      this.FormHelpButton.Size = new System.Drawing.Size(75, 23);
      this.FormHelpButton.TabIndex = 54;
      this.FormHelpButton.Text = "Help!";
      this.FormHelpButton.UseVisualStyleBackColor = true;
      this.FormHelpButton.Click += new System.EventHandler(this.HelpButton_Click);
      // 
      // ISpyPTZ
      // 
      this.AcceptButton = this.okButton;
      this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
      this.AutoScroll = true;
      this.CancelButton = this.cancelButton;
      this.ClientSize = new System.Drawing.Size(843, 432);
      this.Controls.Add(this.FormHelpButton);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.DirectionsListView);
      this.Controls.Add(this.cancelButton);
      this.Controls.Add(this.okButton);
      this.Controls.Add(this.label6);
      this.Controls.Add(this.uriTextBox);
      this.Controls.Add(this.label5);
      this.Controls.Add(this.ModelCombo);
      this.Controls.Add(this.MakeCombo);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.DownloadButton);
      this.Controls.Add(this.label1);
      this.Name = "ISpyPTZ";
      this.Text = "iSpy PTZ Movement Commands";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.TextBox uriTextBox;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.ComboBox ModelCombo;
    private System.Windows.Forms.ComboBox MakeCombo;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Button DownloadButton;
    private System.Windows.Forms.Button cancelButton;
    private System.Windows.Forms.Button okButton;
    private System.Windows.Forms.ListView DirectionsListView;
    private System.Windows.Forms.ColumnHeader columnHeader1;
    private System.Windows.Forms.ColumnHeader columnHeader2;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Button FormHelpButton;
  }
}