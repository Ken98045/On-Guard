
namespace OnGuardCore
{
  partial class iSpyPreset
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
      this.components = new System.ComponentModel.Container();
      this.ModelCombo = new System.Windows.Forms.ComboBox();
      this.MakeCombo = new System.Windows.Forms.ComboBox();
      this.label4 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.DownloadPresetsButton = new System.Windows.Forms.Button();
      this.label1 = new System.Windows.Forms.Label();
      this.cancelButton = new System.Windows.Forms.Button();
      this.okButton = new System.Windows.Forms.Button();
      this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
      this.PresetsListView = new System.Windows.Forms.ListView();
      this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
      this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
      this.FormHelpButton = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // ModelCombo
      // 
      this.ModelCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.ModelCombo.FormattingEnabled = true;
      this.ModelCombo.Location = new System.Drawing.Point(569, 56);
      this.ModelCombo.Name = "ModelCombo";
      this.ModelCombo.Size = new System.Drawing.Size(157, 23);
      this.ModelCombo.TabIndex = 51;
      this.ModelCombo.SelectedIndexChanged += new System.EventHandler(this.OnModelChanged);
      // 
      // MakeCombo
      // 
      this.MakeCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.MakeCombo.FormattingEnabled = true;
      this.MakeCombo.Location = new System.Drawing.Point(276, 59);
      this.MakeCombo.Name = "MakeCombo";
      this.MakeCombo.Size = new System.Drawing.Size(157, 23);
      this.MakeCombo.TabIndex = 50;
      this.MakeCombo.SelectedIndexChanged += new System.EventHandler(this.OnMakeChanged);
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.label4.Location = new System.Drawing.Point(453, 58);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(108, 16);
      this.label4.TabIndex = 49;
      this.label4.Text = "Camera Model";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.label3.Location = new System.Drawing.Point(165, 61);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(103, 16);
      this.label3.TabIndex = 48;
      this.label3.Text = "Camera Make";
      // 
      // DownloadPresetsButton
      // 
      this.DownloadPresetsButton.Location = new System.Drawing.Point(32, 58);
      this.DownloadPresetsButton.Name = "DownloadPresetsButton";
      this.DownloadPresetsButton.Size = new System.Drawing.Size(112, 23);
      this.DownloadPresetsButton.TabIndex = 47;
      this.DownloadPresetsButton.Text = "Download";
      this.DownloadPresetsButton.UseVisualStyleBackColor = true;
      this.DownloadPresetsButton.Click += new System.EventHandler(this.DownloadPresetsButton_Click);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.label1.Location = new System.Drawing.Point(267, 19);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(243, 16);
      this.label1.TabIndex = 46;
      this.label1.Text = "iSpy Preset Movement Commands";
      // 
      // cancelButton
      // 
      this.cancelButton.Location = new System.Drawing.Point(414, 404);
      this.cancelButton.Name = "cancelButton";
      this.cancelButton.Size = new System.Drawing.Size(75, 23);
      this.cancelButton.TabIndex = 53;
      this.cancelButton.Text = "Cancel";
      this.cancelButton.UseVisualStyleBackColor = true;
      this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
      // 
      // okButton
      // 
      this.okButton.Location = new System.Drawing.Point(319, 404);
      this.okButton.Name = "okButton";
      this.okButton.Size = new System.Drawing.Size(75, 23);
      this.okButton.TabIndex = 52;
      this.okButton.Text = "OK";
      this.okButton.UseVisualStyleBackColor = true;
      this.okButton.Click += new System.EventHandler(this.OkButton_Click);
      // 
      // PresetsListView
      // 
      this.PresetsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
      this.PresetsListView.FullRowSelect = true;
      this.PresetsListView.GridLines = true;
      this.PresetsListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
      this.PresetsListView.Location = new System.Drawing.Point(20, 97);
      this.PresetsListView.MultiSelect = false;
      this.PresetsListView.Name = "PresetsListView";
      this.PresetsListView.Size = new System.Drawing.Size(720, 289);
      this.PresetsListView.TabIndex = 54;
      this.PresetsListView.UseCompatibleStateImageBehavior = false;
      this.PresetsListView.View = System.Windows.Forms.View.Details;
      // 
      // columnHeader1
      // 
      this.columnHeader1.Text = "Preset Name";
      this.columnHeader1.Width = 100;
      // 
      // columnHeader2
      // 
      this.columnHeader2.Text = "Preset URL";
      this.columnHeader2.Width = 600;
      // 
      // FormHelpButton
      // 
      this.FormHelpButton.Location = new System.Drawing.Point(665, 404);
      this.FormHelpButton.Name = "FormHelpButton";
      this.FormHelpButton.Size = new System.Drawing.Size(75, 23);
      this.FormHelpButton.TabIndex = 55;
      this.FormHelpButton.Text = "Help!";
      this.FormHelpButton.UseVisualStyleBackColor = true;
      this.FormHelpButton.Click += new System.EventHandler(this.HelpButton_Click);
      // 
      // iSpyPreset
      // 
      this.AcceptButton = this.okButton;
      this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
      this.AutoScroll = true;
      this.CancelButton = this.cancelButton;
      this.ClientSize = new System.Drawing.Size(760, 439);
      this.Controls.Add(this.FormHelpButton);
      this.Controls.Add(this.PresetsListView);
      this.Controls.Add(this.cancelButton);
      this.Controls.Add(this.okButton);
      this.Controls.Add(this.ModelCombo);
      this.Controls.Add(this.MakeCombo);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.DownloadPresetsButton);
      this.Controls.Add(this.label1);
      this.Name = "iSpyPreset";
      this.Text = "iSpy Preset Commands";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.ComboBox ModelCombo;
    private System.Windows.Forms.ComboBox MakeCombo;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Button DownloadPresetsButton;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Button cancelButton;
    private System.Windows.Forms.Button okButton;
    private System.Windows.Forms.ToolTip toolTip1;
    private System.Windows.Forms.ListView PresetsListView;
    private System.Windows.Forms.ColumnHeader columnHeader1;
    public System.Windows.Forms.ColumnHeader columnHeader2;
    private System.Windows.Forms.Button FormHelpButton;
  }
}