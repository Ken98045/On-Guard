namespace OnGuardCore
{
  partial class CreateAOI
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
      this.cancelButton = new System.Windows.Forms.Button();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.facialButton = new System.Windows.Forms.RadioButton();
      this.label1 = new System.Windows.Forms.Label();
      this.ignoreButton = new System.Windows.Forms.RadioButton();
      this.peopleWalkingButton = new System.Windows.Forms.RadioButton();
      this.drivewayButton = new System.Windows.Forms.RadioButton();
      this.garageButton = new System.Windows.Forms.RadioButton();
      this.doorButton = new System.Windows.Forms.RadioButton();
      this.deleteAOIButton = new System.Windows.Forms.Button();
      this.areaNameLabel = new System.Windows.Forms.Label();
      this.aoiNameText = new System.Windows.Forms.TextBox();
      this.notificationsButton = new System.Windows.Forms.Button();
      this.groupBox3 = new System.Windows.Forms.GroupBox();
      this.EditButton = new System.Windows.Forms.Button();
      this.RemoveButton = new System.Windows.Forms.Button();
      this.AddButton = new System.Windows.Forms.Button();
      this.ObjectsListView = new System.Windows.Forms.ListView();
      this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
      this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
      this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
      this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
      this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
      this.areaAdjustButton = new System.Windows.Forms.Button();
      this.groupBox1.SuspendLayout();
      this.groupBox3.SuspendLayout();
      this.SuspendLayout();
      // 
      // OKButton
      // 
      this.OKButton.Location = new System.Drawing.Point(98, 409);
      this.OKButton.Name = "OKButton";
      this.OKButton.Size = new System.Drawing.Size(107, 23);
      this.OKButton.TabIndex = 0;
      this.OKButton.Text = "OK";
      this.OKButton.UseVisualStyleBackColor = true;
      this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
      // 
      // cancelButton
      // 
      this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.cancelButton.Location = new System.Drawing.Point(217, 409);
      this.cancelButton.Name = "cancelButton";
      this.cancelButton.Size = new System.Drawing.Size(117, 23);
      this.cancelButton.TabIndex = 1;
      this.cancelButton.Text = "Cancel";
      this.cancelButton.UseVisualStyleBackColor = true;
      this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
      // 
      // groupBox1
      // 
      this.groupBox1.BackColor = System.Drawing.SystemColors.ControlDark;
      this.groupBox1.Controls.Add(this.facialButton);
      this.groupBox1.Controls.Add(this.label1);
      this.groupBox1.Controls.Add(this.ignoreButton);
      this.groupBox1.Controls.Add(this.peopleWalkingButton);
      this.groupBox1.Controls.Add(this.drivewayButton);
      this.groupBox1.Controls.Add(this.garageButton);
      this.groupBox1.Controls.Add(this.doorButton);
      this.groupBox1.Location = new System.Drawing.Point(12, 26);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(197, 335);
      this.groupBox1.TabIndex = 2;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Select Area Type";
      // 
      // facialButton
      // 
      this.facialButton.AutoSize = true;
      this.facialButton.Location = new System.Drawing.Point(11, 245);
      this.facialButton.Name = "facialButton";
      this.facialButton.Size = new System.Drawing.Size(127, 19);
      this.facialButton.TabIndex = 6;
      this.facialButton.TabStop = true;
      this.facialButton.Text = "Facial Recognition*";
      this.facialButton.UseVisualStyleBackColor = true;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(11, 297);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(82, 15);
      this.label1.TabIndex = 5;
      this.label1.Text = "* High Priority";
      // 
      // ignoreButton
      // 
      this.ignoreButton.AutoSize = true;
      this.ignoreButton.Location = new System.Drawing.Point(11, 203);
      this.ignoreButton.Name = "ignoreButton";
      this.ignoreButton.Size = new System.Drawing.Size(164, 19);
      this.ignoreButton.TabIndex = 4;
      this.ignoreButton.TabStop = true;
      this.ignoreButton.Text = "Ignore Objects in this Area";
      this.ignoreButton.UseVisualStyleBackColor = true;
      // 
      // peopleWalkingButton
      // 
      this.peopleWalkingButton.AutoSize = true;
      this.peopleWalkingButton.Location = new System.Drawing.Point(11, 161);
      this.peopleWalkingButton.Name = "peopleWalkingButton";
      this.peopleWalkingButton.Size = new System.Drawing.Size(107, 19);
      this.peopleWalkingButton.TabIndex = 3;
      this.peopleWalkingButton.TabStop = true;
      this.peopleWalkingButton.Text = "People Walking";
      this.peopleWalkingButton.UseVisualStyleBackColor = true;
      // 
      // drivewayButton
      // 
      this.drivewayButton.AutoSize = true;
      this.drivewayButton.Location = new System.Drawing.Point(11, 119);
      this.drivewayButton.Name = "drivewayButton";
      this.drivewayButton.Size = new System.Drawing.Size(100, 19);
      this.drivewayButton.TabIndex = 2;
      this.drivewayButton.TabStop = true;
      this.drivewayButton.Text = "Driveway Area";
      this.drivewayButton.UseVisualStyleBackColor = true;
      // 
      // garageButton
      // 
      this.garageButton.AutoSize = true;
      this.garageButton.Location = new System.Drawing.Point(11, 77);
      this.garageButton.Name = "garageButton";
      this.garageButton.Size = new System.Drawing.Size(91, 19);
      this.garageButton.TabIndex = 1;
      this.garageButton.TabStop = true;
      this.garageButton.Text = "Garage Door";
      this.garageButton.UseVisualStyleBackColor = true;
      // 
      // doorButton
      // 
      this.doorButton.AutoSize = true;
      this.doorButton.Location = new System.Drawing.Point(11, 35);
      this.doorButton.Name = "doorButton";
      this.doorButton.Size = new System.Drawing.Size(86, 19);
      this.doorButton.TabIndex = 0;
      this.doorButton.TabStop = true;
      this.doorButton.Text = "Entry Door*";
      this.doorButton.UseVisualStyleBackColor = true;
      // 
      // deleteAOIButton
      // 
      this.deleteAOIButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.deleteAOIButton.Location = new System.Drawing.Point(342, 409);
      this.deleteAOIButton.Name = "deleteAOIButton";
      this.deleteAOIButton.Size = new System.Drawing.Size(117, 23);
      this.deleteAOIButton.TabIndex = 2;
      this.deleteAOIButton.Text = "Delete AOI";
      this.deleteAOIButton.UseVisualStyleBackColor = true;
      this.deleteAOIButton.Click += new System.EventHandler(this.DeleteAOIButton_Click);
      // 
      // areaNameLabel
      // 
      this.areaNameLabel.AutoSize = true;
      this.areaNameLabel.Location = new System.Drawing.Point(213, 377);
      this.areaNameLabel.Name = "areaNameLabel";
      this.areaNameLabel.Size = new System.Drawing.Size(80, 15);
      this.areaNameLabel.TabIndex = 9;
      this.areaNameLabel.Text = "Name of Area";
      // 
      // aoiNameText
      // 
      this.aoiNameText.Location = new System.Drawing.Point(308, 374);
      this.aoiNameText.Name = "aoiNameText";
      this.aoiNameText.Size = new System.Drawing.Size(225, 23);
      this.aoiNameText.TabIndex = 3;
      // 
      // notificationsButton
      // 
      this.notificationsButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.notificationsButton.Location = new System.Drawing.Point(467, 409);
      this.notificationsButton.Name = "notificationsButton";
      this.notificationsButton.Size = new System.Drawing.Size(117, 23);
      this.notificationsButton.TabIndex = 3;
      this.notificationsButton.Text = "Set Notifications";
      this.notificationsButton.UseVisualStyleBackColor = true;
      this.notificationsButton.Click += new System.EventHandler(this.NotificationsButton_Click);
      // 
      // groupBox3
      // 
      this.groupBox3.BackColor = System.Drawing.SystemColors.ControlDark;
      this.groupBox3.Controls.Add(this.EditButton);
      this.groupBox3.Controls.Add(this.RemoveButton);
      this.groupBox3.Controls.Add(this.AddButton);
      this.groupBox3.Controls.Add(this.ObjectsListView);
      this.groupBox3.Location = new System.Drawing.Point(215, 26);
      this.groupBox3.Name = "groupBox3";
      this.groupBox3.Size = new System.Drawing.Size(541, 335);
      this.groupBox3.TabIndex = 0;
      this.groupBox3.TabStop = false;
      this.groupBox3.Text = "Objects of Interest";
      // 
      // EditButton
      // 
      this.EditButton.Enabled = false;
      this.EditButton.Location = new System.Drawing.Point(229, 297);
      this.EditButton.Name = "EditButton";
      this.EditButton.Size = new System.Drawing.Size(75, 23);
      this.EditButton.TabIndex = 40;
      this.EditButton.Text = "Edit";
      this.EditButton.UseVisualStyleBackColor = true;
      this.EditButton.Click += new System.EventHandler(this.EditButton_Click);
      // 
      // RemoveButton
      // 
      this.RemoveButton.Enabled = false;
      this.RemoveButton.Location = new System.Drawing.Point(315, 297);
      this.RemoveButton.Name = "RemoveButton";
      this.RemoveButton.Size = new System.Drawing.Size(75, 23);
      this.RemoveButton.TabIndex = 39;
      this.RemoveButton.Text = "Remove";
      this.RemoveButton.UseVisualStyleBackColor = true;
      this.RemoveButton.Click += new System.EventHandler(this.RemoveButton_Click);
      // 
      // AddButton
      // 
      this.AddButton.Location = new System.Drawing.Point(143, 297);
      this.AddButton.Name = "AddButton";
      this.AddButton.Size = new System.Drawing.Size(75, 23);
      this.AddButton.TabIndex = 38;
      this.AddButton.Text = "Add";
      this.AddButton.UseVisualStyleBackColor = true;
      this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
      // 
      // ObjectsListView
      // 
      this.ObjectsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
      this.ObjectsListView.FullRowSelect = true;
      this.ObjectsListView.GridLines = true;
      this.ObjectsListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
      this.ObjectsListView.Location = new System.Drawing.Point(14, 24);
      this.ObjectsListView.Name = "ObjectsListView";
      this.ObjectsListView.Size = new System.Drawing.Size(510, 267);
      this.ObjectsListView.TabIndex = 37;
      this.ObjectsListView.UseCompatibleStateImageBehavior = false;
      this.ObjectsListView.View = System.Windows.Forms.View.Details;
      this.ObjectsListView.ItemActivate += new System.EventHandler(this.ObjectsListView_ItemActivate);
      this.ObjectsListView.SelectedIndexChanged += new System.EventHandler(this.OnObjectSelectionChanged);
      // 
      // columnHeader1
      // 
      this.columnHeader1.Name = "columnHeader1";
      this.columnHeader1.Text = "Object";
      this.columnHeader1.Width = 100;
      // 
      // columnHeader2
      // 
      this.columnHeader2.Name = "columnHeader2";
      this.columnHeader2.Text = "Confidence";
      this.columnHeader2.Width = 100;
      // 
      // columnHeader3
      // 
      this.columnHeader3.Name = "columnHeader3";
      this.columnHeader3.Text = "Overlap";
      this.columnHeader3.Width = 100;
      // 
      // columnHeader4
      // 
      this.columnHeader4.Name = "columnHeader4";
      this.columnHeader4.Text = "Width";
      this.columnHeader4.Width = 100;
      // 
      // columnHeader5
      // 
      this.columnHeader5.Name = "columnHeader5";
      this.columnHeader5.Text = "Height";
      this.columnHeader5.Width = 100;
      // 
      // areaAdjustButton
      // 
      this.areaAdjustButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.areaAdjustButton.Location = new System.Drawing.Point(592, 409);
      this.areaAdjustButton.Name = "areaAdjustButton";
      this.areaAdjustButton.Size = new System.Drawing.Size(117, 23);
      this.areaAdjustButton.TabIndex = 19;
      this.areaAdjustButton.Text = "Adjust Area";
      this.areaAdjustButton.UseVisualStyleBackColor = true;
      this.areaAdjustButton.Click += new System.EventHandler(this.AreaAdjustButton_Click);
      // 
      // CreateAOI
      // 
      this.AcceptButton = this.OKButton;
      this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
      this.CancelButton = this.cancelButton;
      this.ClientSize = new System.Drawing.Size(778, 442);
      this.Controls.Add(this.areaAdjustButton);
      this.Controls.Add(this.groupBox3);
      this.Controls.Add(this.notificationsButton);
      this.Controls.Add(this.aoiNameText);
      this.Controls.Add(this.areaNameLabel);
      this.Controls.Add(this.deleteAOIButton);
      this.Controls.Add(this.groupBox1);
      this.Controls.Add(this.cancelButton);
      this.Controls.Add(this.OKButton);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.Name = "CreateAOI";
      this.Text = "Create Area of Interest";
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.groupBox3.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

        #endregion

        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton ignoreButton;
        private System.Windows.Forms.RadioButton peopleWalkingButton;
        private System.Windows.Forms.RadioButton drivewayButton;
        private System.Windows.Forms.RadioButton garageButton;
        private System.Windows.Forms.RadioButton doorButton;
        private System.Windows.Forms.Button deleteAOIButton;
        private System.Windows.Forms.Label areaNameLabel;
        private System.Windows.Forms.TextBox aoiNameText;
        private System.Windows.Forms.Button notificationsButton;
        private System.Windows.Forms.GroupBox groupBox3;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Button areaAdjustButton;
    private System.Windows.Forms.Button RemoveButton;
    private System.Windows.Forms.Button AddButton;
    private System.Windows.Forms.ListView ObjectsListView;
    private System.Windows.Forms.ColumnHeader columnHeader1;
    private System.Windows.Forms.ColumnHeader columnHeader2;
    private System.Windows.Forms.ColumnHeader columnHeader3;
    private System.Windows.Forms.ColumnHeader columnHeader4;
    private System.Windows.Forms.ColumnHeader columnHeader5;
    private System.Windows.Forms.RadioButton facialButton;
    private System.Windows.Forms.Button EditButton;
  }
}