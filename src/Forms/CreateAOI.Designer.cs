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
      this.label1 = new System.Windows.Forms.Label();
      this.ignoreButton = new System.Windows.Forms.RadioButton();
      this.peopleWalkingButton = new System.Windows.Forms.RadioButton();
      this.drivewayButton = new System.Windows.Forms.RadioButton();
      this.garageButton = new System.Windows.Forms.RadioButton();
      this.doorButton = new System.Windows.Forms.RadioButton();
      this.label5 = new System.Windows.Forms.Label();
      this.deleteAOIButton = new System.Windows.Forms.Button();
      this.areaNameLabel = new System.Windows.Forms.Label();
      this.aoiNameText = new System.Windows.Forms.TextBox();
      this.movementDirectionGroup = new System.Windows.Forms.GroupBox();
      this.label3 = new System.Windows.Forms.Label();
      this.departingButton = new System.Windows.Forms.RadioButton();
      this.arrivingButton = new System.Windows.Forms.RadioButton();
      this.anyActivityButton = new System.Windows.Forms.RadioButton();
      this.label4 = new System.Windows.Forms.Label();
      this.label6 = new System.Windows.Forms.Label();
      this.label7 = new System.Windows.Forms.Label();
      this.label8 = new System.Windows.Forms.Label();
      this.notificationsButton = new System.Windows.Forms.Button();
      this.groupBox3 = new System.Windows.Forms.GroupBox();
      this.RemoveButton = new System.Windows.Forms.Button();
      this.AddButton = new System.Windows.Forms.Button();
      this.ObjectsListView = new System.Windows.Forms.ListView();
      this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
      this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
      this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
      this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
      this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
      this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
      this.xNumeric = new System.Windows.Forms.NumericUpDown();
      this.yNumeric = new System.Windows.Forms.NumericUpDown();
      this.widthNumeric = new System.Windows.Forms.NumericUpDown();
      this.heighNumeric = new System.Windows.Forms.NumericUpDown();
      this.areaAdjustButton = new System.Windows.Forms.Button();
      this.label9 = new System.Windows.Forms.Label();
      this.groupBox1.SuspendLayout();
      this.movementDirectionGroup.SuspendLayout();
      this.groupBox3.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.xNumeric)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.yNumeric)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.widthNumeric)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.heighNumeric)).BeginInit();
      this.SuspendLayout();
      // 
      // OKButton
      // 
      this.OKButton.Location = new System.Drawing.Point(173, 457);
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
      this.cancelButton.Location = new System.Drawing.Point(292, 457);
      this.cancelButton.Name = "cancelButton";
      this.cancelButton.Size = new System.Drawing.Size(107, 23);
      this.cancelButton.TabIndex = 1;
      this.cancelButton.Text = "Cancel";
      this.cancelButton.UseVisualStyleBackColor = true;
      this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
      // 
      // groupBox1
      // 
      this.groupBox1.BackColor = System.Drawing.SystemColors.ControlDark;
      this.groupBox1.Controls.Add(this.label1);
      this.groupBox1.Controls.Add(this.ignoreButton);
      this.groupBox1.Controls.Add(this.peopleWalkingButton);
      this.groupBox1.Controls.Add(this.drivewayButton);
      this.groupBox1.Controls.Add(this.garageButton);
      this.groupBox1.Controls.Add(this.doorButton);
      this.groupBox1.Location = new System.Drawing.Point(12, 26);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(183, 170);
      this.groupBox1.TabIndex = 2;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Select Area Type";
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(10, 145);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(82, 15);
      this.label1.TabIndex = 5;
      this.label1.Text = "* High Priority";
      // 
      // ignoreButton
      // 
      this.ignoreButton.AutoSize = true;
      this.ignoreButton.Location = new System.Drawing.Point(7, 116);
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
      this.peopleWalkingButton.Location = new System.Drawing.Point(7, 93);
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
      this.drivewayButton.Location = new System.Drawing.Point(7, 70);
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
      this.garageButton.Location = new System.Drawing.Point(7, 47);
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
      this.doorButton.Location = new System.Drawing.Point(7, 24);
      this.doorButton.Name = "doorButton";
      this.doorButton.Size = new System.Drawing.Size(86, 19);
      this.doorButton.TabIndex = 0;
      this.doorButton.TabStop = true;
      this.doorButton.Text = "Entry Door*";
      this.doorButton.UseVisualStyleBackColor = true;
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(6, 90);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(163, 15);
      this.label5.TabIndex = 9;
      this.label5.Text = "*Requires 2 Frames Minimum";
      // 
      // deleteAOIButton
      // 
      this.deleteAOIButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.deleteAOIButton.Location = new System.Drawing.Point(411, 457);
      this.deleteAOIButton.Name = "deleteAOIButton";
      this.deleteAOIButton.Size = new System.Drawing.Size(107, 23);
      this.deleteAOIButton.TabIndex = 2;
      this.deleteAOIButton.Text = "Delete AOI";
      this.deleteAOIButton.UseVisualStyleBackColor = true;
      this.deleteAOIButton.Click += new System.EventHandler(this.DeleteAOIButton_Click);
      // 
      // areaNameLabel
      // 
      this.areaNameLabel.AutoSize = true;
      this.areaNameLabel.Location = new System.Drawing.Point(166, 382);
      this.areaNameLabel.Name = "areaNameLabel";
      this.areaNameLabel.Size = new System.Drawing.Size(80, 15);
      this.areaNameLabel.TabIndex = 9;
      this.areaNameLabel.Text = "Name of Area";
      // 
      // aoiNameText
      // 
      this.aoiNameText.Location = new System.Drawing.Point(244, 379);
      this.aoiNameText.Name = "aoiNameText";
      this.aoiNameText.Size = new System.Drawing.Size(225, 23);
      this.aoiNameText.TabIndex = 3;
      // 
      // movementDirectionGroup
      // 
      this.movementDirectionGroup.BackColor = System.Drawing.SystemColors.ControlDark;
      this.movementDirectionGroup.Controls.Add(this.label3);
      this.movementDirectionGroup.Controls.Add(this.departingButton);
      this.movementDirectionGroup.Controls.Add(this.label5);
      this.movementDirectionGroup.Controls.Add(this.arrivingButton);
      this.movementDirectionGroup.Controls.Add(this.anyActivityButton);
      this.movementDirectionGroup.Location = new System.Drawing.Point(12, 215);
      this.movementDirectionGroup.Name = "movementDirectionGroup";
      this.movementDirectionGroup.Size = new System.Drawing.Size(186, 141);
      this.movementDirectionGroup.TabIndex = 10;
      this.movementDirectionGroup.TabStop = false;
      this.movementDirectionGroup.Text = "Movement Direction";
      // 
      // label3
      // 
      this.label3.ForeColor = System.Drawing.SystemColors.Highlight;
      this.label3.Location = new System.Drawing.Point(25, 108);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(148, 27);
      this.label3.TabIndex = 37;
      this.label3.Text = "Movement Direction not  implemented";
      // 
      // departingButton
      // 
      this.departingButton.AutoSize = true;
      this.departingButton.Location = new System.Drawing.Point(10, 66);
      this.departingButton.Name = "departingButton";
      this.departingButton.Size = new System.Drawing.Size(85, 19);
      this.departingButton.TabIndex = 2;
      this.departingButton.TabStop = true;
      this.departingButton.Text = "Departing *";
      this.departingButton.UseVisualStyleBackColor = true;
      // 
      // arrivingButton
      // 
      this.arrivingButton.AutoSize = true;
      this.arrivingButton.Location = new System.Drawing.Point(10, 43);
      this.arrivingButton.Name = "arrivingButton";
      this.arrivingButton.Size = new System.Drawing.Size(75, 19);
      this.arrivingButton.TabIndex = 1;
      this.arrivingButton.TabStop = true;
      this.arrivingButton.Text = "Arriving *";
      this.arrivingButton.UseVisualStyleBackColor = true;
      // 
      // anyActivityButton
      // 
      this.anyActivityButton.AutoSize = true;
      this.anyActivityButton.Location = new System.Drawing.Point(10, 20);
      this.anyActivityButton.Name = "anyActivityButton";
      this.anyActivityButton.Size = new System.Drawing.Size(89, 19);
      this.anyActivityButton.TabIndex = 0;
      this.anyActivityButton.TabStop = true;
      this.anyActivityButton.Text = "Any Activity";
      this.anyActivityButton.UseVisualStyleBackColor = true;
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(218, 412);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(20, 15);
      this.label4.TabIndex = 11;
      this.label4.Text = "X: ";
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Location = new System.Drawing.Point(328, 412);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(20, 15);
      this.label6.TabIndex = 12;
      this.label6.Text = "Y: ";
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.Location = new System.Drawing.Point(430, 412);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(45, 15);
      this.label7.TabIndex = 13;
      this.label7.Text = "Width: ";
      // 
      // label8
      // 
      this.label8.AutoSize = true;
      this.label8.Location = new System.Drawing.Point(540, 412);
      this.label8.Name = "label8";
      this.label8.Size = new System.Drawing.Size(49, 15);
      this.label8.TabIndex = 14;
      this.label8.Text = "Height: ";
      // 
      // notificationsButton
      // 
      this.notificationsButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.notificationsButton.Location = new System.Drawing.Point(530, 457);
      this.notificationsButton.Name = "notificationsButton";
      this.notificationsButton.Size = new System.Drawing.Size(107, 23);
      this.notificationsButton.TabIndex = 3;
      this.notificationsButton.Text = "Set Notifications";
      this.notificationsButton.UseVisualStyleBackColor = true;
      this.notificationsButton.Click += new System.EventHandler(this.NotificationsButton_Click);
      // 
      // groupBox3
      // 
      this.groupBox3.BackColor = System.Drawing.SystemColors.ControlDark;
      this.groupBox3.Controls.Add(this.RemoveButton);
      this.groupBox3.Controls.Add(this.AddButton);
      this.groupBox3.Controls.Add(this.ObjectsListView);
      this.groupBox3.Location = new System.Drawing.Point(215, 26);
      this.groupBox3.Name = "groupBox3";
      this.groupBox3.Size = new System.Drawing.Size(634, 335);
      this.groupBox3.TabIndex = 0;
      this.groupBox3.TabStop = false;
      this.groupBox3.Text = "Objects of Interest";
      // 
      // RemoveButton
      // 
      this.RemoveButton.Location = new System.Drawing.Point(322, 297);
      this.RemoveButton.Name = "RemoveButton";
      this.RemoveButton.Size = new System.Drawing.Size(75, 23);
      this.RemoveButton.TabIndex = 39;
      this.RemoveButton.Text = "Remove";
      this.RemoveButton.UseVisualStyleBackColor = true;
      this.RemoveButton.Click += new System.EventHandler(this.RemoveButton_Click);
      // 
      // AddButton
      // 
      this.AddButton.Location = new System.Drawing.Point(237, 297);
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
            this.columnHeader5,
            this.columnHeader6});
      this.ObjectsListView.FullRowSelect = true;
      this.ObjectsListView.GridLines = true;
      this.ObjectsListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
      this.ObjectsListView.HideSelection = false;
      this.ObjectsListView.Location = new System.Drawing.Point(14, 24);
      this.ObjectsListView.Name = "ObjectsListView";
      this.ObjectsListView.Size = new System.Drawing.Size(604, 267);
      this.ObjectsListView.TabIndex = 37;
      this.ObjectsListView.UseCompatibleStateImageBehavior = false;
      this.ObjectsListView.View = System.Windows.Forms.View.Details;
      this.ObjectsListView.ItemActivate += new System.EventHandler(this.ObjectsListView_ItemActivate);
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
      // columnHeader6
      // 
      this.columnHeader6.Name = "columnHeader6";
      this.columnHeader6.Text = "History";
      this.columnHeader6.Width = 100;
      // 
      // xNumeric
      // 
      this.xNumeric.Location = new System.Drawing.Point(243, 410);
      this.xNumeric.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
      this.xNumeric.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
      this.xNumeric.Name = "xNumeric";
      this.xNumeric.Size = new System.Drawing.Size(57, 23);
      this.xNumeric.TabIndex = 15;
      this.xNumeric.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
      // 
      // yNumeric
      // 
      this.yNumeric.Location = new System.Drawing.Point(350, 410);
      this.yNumeric.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
      this.yNumeric.Minimum = new decimal(new int[] {
            100000,
            0,
            0,
            -2147483648});
      this.yNumeric.Name = "yNumeric";
      this.yNumeric.Size = new System.Drawing.Size(57, 23);
      this.yNumeric.TabIndex = 16;
      this.yNumeric.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
      // 
      // widthNumeric
      // 
      this.widthNumeric.Location = new System.Drawing.Point(469, 410);
      this.widthNumeric.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
      this.widthNumeric.Name = "widthNumeric";
      this.widthNumeric.Size = new System.Drawing.Size(57, 23);
      this.widthNumeric.TabIndex = 17;
      this.widthNumeric.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
      // 
      // heighNumeric
      // 
      this.heighNumeric.Location = new System.Drawing.Point(585, 410);
      this.heighNumeric.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
      this.heighNumeric.Name = "heighNumeric";
      this.heighNumeric.Size = new System.Drawing.Size(57, 23);
      this.heighNumeric.TabIndex = 18;
      this.heighNumeric.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
      // 
      // areaAdjustButton
      // 
      this.areaAdjustButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.areaAdjustButton.Location = new System.Drawing.Point(649, 457);
      this.areaAdjustButton.Name = "areaAdjustButton";
      this.areaAdjustButton.Size = new System.Drawing.Size(107, 23);
      this.areaAdjustButton.TabIndex = 19;
      this.areaAdjustButton.Text = "Adjust Area";
      this.areaAdjustButton.UseVisualStyleBackColor = true;
      this.areaAdjustButton.Click += new System.EventHandler(this.AreaAdjustButton_Click);
      // 
      // label9
      // 
      this.label9.AutoSize = true;
      this.label9.Location = new System.Drawing.Point(80, 412);
      this.label9.Name = "label9";
      this.label9.Size = new System.Drawing.Size(147, 15);
      this.label9.TabIndex = 20;
      this.label9.Text = "Area Location/Dimensions";
      // 
      // CreateAOI
      // 
      this.AcceptButton = this.OKButton;
      this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
      this.CancelButton = this.cancelButton;
      this.ClientSize = new System.Drawing.Size(865, 498);
      this.Controls.Add(this.label9);
      this.Controls.Add(this.areaAdjustButton);
      this.Controls.Add(this.heighNumeric);
      this.Controls.Add(this.widthNumeric);
      this.Controls.Add(this.yNumeric);
      this.Controls.Add(this.xNumeric);
      this.Controls.Add(this.groupBox3);
      this.Controls.Add(this.notificationsButton);
      this.Controls.Add(this.label8);
      this.Controls.Add(this.label7);
      this.Controls.Add(this.label6);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.movementDirectionGroup);
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
      this.movementDirectionGroup.ResumeLayout(false);
      this.movementDirectionGroup.PerformLayout();
      this.groupBox3.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.xNumeric)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.yNumeric)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.widthNumeric)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.heighNumeric)).EndInit();
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
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label areaNameLabel;
        private System.Windows.Forms.TextBox aoiNameText;
        private System.Windows.Forms.GroupBox movementDirectionGroup;
        private System.Windows.Forms.RadioButton departingButton;
        private System.Windows.Forms.RadioButton arrivingButton;
        private System.Windows.Forms.RadioButton anyActivityButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button notificationsButton;
        private System.Windows.Forms.GroupBox groupBox3;
    private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown xNumeric;
        private System.Windows.Forms.NumericUpDown yNumeric;
        private System.Windows.Forms.NumericUpDown widthNumeric;
        private System.Windows.Forms.NumericUpDown heighNumeric;
    private System.Windows.Forms.Button areaAdjustButton;
    private System.Windows.Forms.Label label9;
    private System.Windows.Forms.Button RemoveButton;
    private System.Windows.Forms.Button AddButton;
    private System.Windows.Forms.ListView ObjectsListView;
    private System.Windows.Forms.ColumnHeader columnHeader1;
    private System.Windows.Forms.ColumnHeader columnHeader2;
    private System.Windows.Forms.ColumnHeader columnHeader3;
    private System.Windows.Forms.ColumnHeader columnHeader4;
    private System.Windows.Forms.ColumnHeader columnHeader5;
    private System.Windows.Forms.ColumnHeader columnHeader6;
  }
}