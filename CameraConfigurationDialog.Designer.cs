namespace SAAI
{
  partial class CameraConfigurationDialog
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CameraConfigurationDialog));
      this.configurationTabControl = new System.Windows.Forms.TabControl();
      this.imagesTab = new System.Windows.Forms.TabPage();
      this.label18 = new System.Windows.Forms.Label();
      this.availableCamerasList = new System.Windows.Forms.ListView();
      this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.removeCameraButton = new System.Windows.Forms.Button();
      this.addCameraButton = new System.Windows.Forms.Button();
      this.label22 = new System.Windows.Forms.Label();
      this.label19 = new System.Windows.Forms.Label();
      this.label21 = new System.Windows.Forms.Label();
      this.liveCameraTab = new System.Windows.Forms.TabPage();
      this.currentCameraLabel = new System.Windows.Forms.Label();
      this.label10 = new System.Windows.Forms.Label();
      this.label15 = new System.Windows.Forms.Label();
      this.label14 = new System.Windows.Forms.Label();
      this.label13 = new System.Windows.Forms.Label();
      this.label12 = new System.Windows.Forms.Label();
      this.label11 = new System.Windows.Forms.Label();
      this.label9 = new System.Windows.Forms.Label();
      this.cameraYResolutionNumeric = new System.Windows.Forms.NumericUpDown();
      this.label8 = new System.Windows.Forms.Label();
      this.cameraXResolutionNumeric = new System.Windows.Forms.NumericUpDown();
      this.label7 = new System.Windows.Forms.Label();
      this.cameraPasswordText = new System.Windows.Forms.TextBox();
      this.cameraUserText = new System.Windows.Forms.TextBox();
      this.cameraNameText = new System.Windows.Forms.TextBox();
      this.portNumeric = new System.Windows.Forms.NumericUpDown();
      this.cameraIPAddressText = new System.Windows.Forms.TextBox();
      this.label6 = new System.Windows.Forms.Label();
      this.label5 = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.monitorTab = new System.Windows.Forms.TabPage();
      this.label17 = new System.Windows.Forms.Label();
      this.label16 = new System.Windows.Forms.Label();
      this.monitorListView = new System.Windows.Forms.ListView();
      this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.okButton = new System.Windows.Forms.Button();
      this.cancelButton = new System.Windows.Forms.Button();
      this.configurationTabControl.SuspendLayout();
      this.imagesTab.SuspendLayout();
      this.liveCameraTab.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.cameraYResolutionNumeric)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.cameraXResolutionNumeric)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.portNumeric)).BeginInit();
      this.monitorTab.SuspendLayout();
      this.SuspendLayout();
      // 
      // configurationTabControl
      // 
      this.configurationTabControl.Controls.Add(this.imagesTab);
      this.configurationTabControl.Controls.Add(this.liveCameraTab);
      this.configurationTabControl.Controls.Add(this.monitorTab);
      this.configurationTabControl.Location = new System.Drawing.Point(15, 14);
      this.configurationTabControl.Name = "configurationTabControl";
      this.configurationTabControl.SelectedIndex = 0;
      this.configurationTabControl.Size = new System.Drawing.Size(734, 454);
      this.configurationTabControl.TabIndex = 0;
      this.configurationTabControl.Selected += new System.Windows.Forms.TabControlEventHandler(this.OnTabPageSelected);
      // 
      // imagesTab
      // 
      this.imagesTab.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.imagesTab.Controls.Add(this.label18);
      this.imagesTab.Controls.Add(this.availableCamerasList);
      this.imagesTab.Controls.Add(this.removeCameraButton);
      this.imagesTab.Controls.Add(this.addCameraButton);
      this.imagesTab.Controls.Add(this.label22);
      this.imagesTab.Controls.Add(this.label19);
      this.imagesTab.Controls.Add(this.label21);
      this.imagesTab.Location = new System.Drawing.Point(4, 22);
      this.imagesTab.Name = "imagesTab";
      this.imagesTab.Padding = new System.Windows.Forms.Padding(3);
      this.imagesTab.Size = new System.Drawing.Size(726, 428);
      this.imagesTab.TabIndex = 1;
      this.imagesTab.Text = "Select Current Camera";
      this.imagesTab.UseVisualStyleBackColor = true;
      // 
      // label18
      // 
      this.label18.AutoSize = true;
      this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label18.Location = new System.Drawing.Point(96, 260);
      this.label18.Name = "label18";
      this.label18.Size = new System.Drawing.Size(126, 15);
      this.label18.TabIndex = 18;
      this.label18.Text = "Available Cameras";
      // 
      // availableCamerasList
      // 
      this.availableCamerasList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4});
      this.availableCamerasList.FullRowSelect = true;
      this.availableCamerasList.GridLines = true;
      this.availableCamerasList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
      this.availableCamerasList.HideSelection = false;
      this.availableCamerasList.Location = new System.Drawing.Point(17, 278);
      this.availableCamerasList.MultiSelect = false;
      this.availableCamerasList.Name = "availableCamerasList";
      this.availableCamerasList.Size = new System.Drawing.Size(398, 112);
      this.availableCamerasList.TabIndex = 0;
      this.availableCamerasList.UseCompatibleStateImageBehavior = false;
      this.availableCamerasList.View = System.Windows.Forms.View.Details;
      this.availableCamerasList.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.OnCameraSelectionChanged);
      this.availableCamerasList.DoubleClick += new System.EventHandler(this.OnCameraDoubleClick);
      // 
      // columnHeader3
      // 
      this.columnHeader3.Text = "Camera Prefix";
      this.columnHeader3.Width = 101;
      // 
      // columnHeader4
      // 
      this.columnHeader4.Text = "Camera File Path";
      this.columnHeader4.Width = 293;
      // 
      // removeCameraButton
      // 
      this.removeCameraButton.Enabled = false;
      this.removeCameraButton.Location = new System.Drawing.Point(421, 335);
      this.removeCameraButton.Name = "removeCameraButton";
      this.removeCameraButton.Size = new System.Drawing.Size(113, 23);
      this.removeCameraButton.TabIndex = 2;
      this.removeCameraButton.Text = "Remove Camera";
      this.removeCameraButton.UseVisualStyleBackColor = true;
      this.removeCameraButton.Click += new System.EventHandler(this.RemoveCameraButton_Click);
      // 
      // addCameraButton
      // 
      this.addCameraButton.Location = new System.Drawing.Point(421, 306);
      this.addCameraButton.Name = "addCameraButton";
      this.addCameraButton.Size = new System.Drawing.Size(113, 23);
      this.addCameraButton.TabIndex = 1;
      this.addCameraButton.Text = "Add Camera";
      this.addCameraButton.UseVisualStyleBackColor = true;
      this.addCameraButton.Click += new System.EventHandler(this.AddCameraButton_Click);
      // 
      // label22
      // 
      this.label22.AutoSize = true;
      this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label22.Location = new System.Drawing.Point(268, 14);
      this.label22.Name = "label22";
      this.label22.Size = new System.Drawing.Size(188, 16);
      this.label22.TabIndex = 15;
      this.label22.Text = "Select the Current Camera";
      // 
      // label19
      // 
      this.label19.Location = new System.Drawing.Point(6, 159);
      this.label19.Name = "label19";
      this.label19.Size = new System.Drawing.Size(681, 92);
      this.label19.TabIndex = 10;
      this.label19.Text = resources.GetString("label19.Text");
      // 
      // label21
      // 
      this.label21.Location = new System.Drawing.Point(6, 40);
      this.label21.Name = "label21";
      this.label21.Size = new System.Drawing.Size(681, 106);
      this.label21.TabIndex = 8;
      this.label21.Text = resources.GetString("label21.Text");
      // 
      // liveCameraTab
      // 
      this.liveCameraTab.Controls.Add(this.currentCameraLabel);
      this.liveCameraTab.Controls.Add(this.label10);
      this.liveCameraTab.Controls.Add(this.label15);
      this.liveCameraTab.Controls.Add(this.label14);
      this.liveCameraTab.Controls.Add(this.label13);
      this.liveCameraTab.Controls.Add(this.label12);
      this.liveCameraTab.Controls.Add(this.label11);
      this.liveCameraTab.Controls.Add(this.label9);
      this.liveCameraTab.Controls.Add(this.cameraYResolutionNumeric);
      this.liveCameraTab.Controls.Add(this.label8);
      this.liveCameraTab.Controls.Add(this.cameraXResolutionNumeric);
      this.liveCameraTab.Controls.Add(this.label7);
      this.liveCameraTab.Controls.Add(this.cameraPasswordText);
      this.liveCameraTab.Controls.Add(this.cameraUserText);
      this.liveCameraTab.Controls.Add(this.cameraNameText);
      this.liveCameraTab.Controls.Add(this.portNumeric);
      this.liveCameraTab.Controls.Add(this.cameraIPAddressText);
      this.liveCameraTab.Controls.Add(this.label6);
      this.liveCameraTab.Controls.Add(this.label5);
      this.liveCameraTab.Controls.Add(this.label4);
      this.liveCameraTab.Controls.Add(this.label3);
      this.liveCameraTab.Controls.Add(this.label2);
      this.liveCameraTab.Controls.Add(this.label1);
      this.liveCameraTab.Location = new System.Drawing.Point(4, 22);
      this.liveCameraTab.Name = "liveCameraTab";
      this.liveCameraTab.Size = new System.Drawing.Size(726, 428);
      this.liveCameraTab.TabIndex = 2;
      this.liveCameraTab.Text = "Live Camera";
      this.liveCameraTab.UseVisualStyleBackColor = true;
      this.liveCameraTab.Click += new System.EventHandler(this.LiveCameraTab_Click);
      // 
      // currentCameraLabel
      // 
      this.currentCameraLabel.AutoSize = true;
      this.currentCameraLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.currentCameraLabel.Location = new System.Drawing.Point(95, 51);
      this.currentCameraLabel.Name = "currentCameraLabel";
      this.currentCameraLabel.Size = new System.Drawing.Size(170, 16);
      this.currentCameraLabel.TabIndex = 42;
      this.currentCameraLabel.Text = "The Current Camera is: ";
      // 
      // label10
      // 
      this.label10.AutoSize = true;
      this.label10.Location = new System.Drawing.Point(332, 296);
      this.label10.Name = "label10";
      this.label10.Size = new System.Drawing.Size(255, 13);
      this.label10.TabIndex = 41;
      this.label10.Text = "Zero for Not Se/Defaultt.  From your camera manual.";
      // 
      // label15
      // 
      this.label15.AutoSize = true;
      this.label15.Location = new System.Drawing.Point(332, 226);
      this.label15.Name = "label15";
      this.label15.Size = new System.Drawing.Size(283, 13);
      this.label15.TabIndex = 40;
      this.label15.Text = "This is from the Blue Iris main settings (not camera specific)";
      // 
      // label14
      // 
      this.label14.AutoSize = true;
      this.label14.Location = new System.Drawing.Point(332, 191);
      this.label14.Name = "label14";
      this.label14.Size = new System.Drawing.Size(283, 13);
      this.label14.TabIndex = 39;
      this.label14.Text = "This is from the Blue Iris main settings (not camera specific)";
      // 
      // label13
      // 
      this.label13.AutoSize = true;
      this.label13.Location = new System.Drawing.Point(332, 156);
      this.label13.Name = "label13";
      this.label13.Size = new System.Drawing.Size(218, 13);
      this.label13.TabIndex = 38;
      this.label13.Text = "Obtain this from the Blue Iris Camera Settings";
      // 
      // label12
      // 
      this.label12.AutoSize = true;
      this.label12.Location = new System.Drawing.Point(332, 121);
      this.label12.Name = "label12";
      this.label12.Size = new System.Drawing.Size(300, 13);
      this.label12.TabIndex = 37;
      this.label12.Text = "This is often 80.  However port 80 may conflict with the AI port";
      // 
      // label11
      // 
      this.label11.AutoSize = true;
      this.label11.Location = new System.Drawing.Point(332, 86);
      this.label11.Name = "label11";
      this.label11.Size = new System.Drawing.Size(161, 13);
      this.label11.TabIndex = 36;
      this.label11.Text = "This is often/typically \"localhost\"";
      // 
      // label9
      // 
      this.label9.AutoSize = true;
      this.label9.Location = new System.Drawing.Point(332, 261);
      this.label9.Name = "label9";
      this.label9.Size = new System.Drawing.Size(255, 13);
      this.label9.TabIndex = 34;
      this.label9.Text = "Zero for Not Se/Defaultt.  From your camera manual.";
      // 
      // cameraYResolutionNumeric
      // 
      this.cameraYResolutionNumeric.Location = new System.Drawing.Point(231, 294);
      this.cameraYResolutionNumeric.Maximum = new decimal(new int[] {
            65553,
            0,
            0,
            0});
      this.cameraYResolutionNumeric.Name = "cameraYResolutionNumeric";
      this.cameraYResolutionNumeric.Size = new System.Drawing.Size(58, 20);
      this.cameraYResolutionNumeric.TabIndex = 33;
      this.cameraYResolutionNumeric.Value = new decimal(new int[] {
            1920,
            0,
            0,
            0});
      // 
      // label8
      // 
      this.label8.AutoSize = true;
      this.label8.Location = new System.Drawing.Point(97, 296);
      this.label8.Name = "label8";
      this.label8.Size = new System.Drawing.Size(106, 13);
      this.label8.TabIndex = 32;
      this.label8.Text = "Camera Y Resolution";
      // 
      // cameraXResolutionNumeric
      // 
      this.cameraXResolutionNumeric.Location = new System.Drawing.Point(235, 259);
      this.cameraXResolutionNumeric.Maximum = new decimal(new int[] {
            65553,
            0,
            0,
            0});
      this.cameraXResolutionNumeric.Name = "cameraXResolutionNumeric";
      this.cameraXResolutionNumeric.Size = new System.Drawing.Size(58, 20);
      this.cameraXResolutionNumeric.TabIndex = 31;
      this.cameraXResolutionNumeric.Value = new decimal(new int[] {
            2560,
            0,
            0,
            0});
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.Location = new System.Drawing.Point(97, 261);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(106, 13);
      this.label7.TabIndex = 30;
      this.label7.Text = "Camera X Resolution";
      // 
      // cameraPasswordText
      // 
      this.cameraPasswordText.Location = new System.Drawing.Point(231, 223);
      this.cameraPasswordText.Name = "cameraPasswordText";
      this.cameraPasswordText.Size = new System.Drawing.Size(87, 20);
      this.cameraPasswordText.TabIndex = 29;
      this.cameraPasswordText.UseSystemPasswordChar = true;
      // 
      // cameraUserText
      // 
      this.cameraUserText.Location = new System.Drawing.Point(231, 188);
      this.cameraUserText.Name = "cameraUserText";
      this.cameraUserText.Size = new System.Drawing.Size(87, 20);
      this.cameraUserText.TabIndex = 28;
      // 
      // cameraNameText
      // 
      this.cameraNameText.Location = new System.Drawing.Point(231, 153);
      this.cameraNameText.Name = "cameraNameText";
      this.cameraNameText.Size = new System.Drawing.Size(87, 20);
      this.cameraNameText.TabIndex = 27;
      // 
      // portNumeric
      // 
      this.portNumeric.Location = new System.Drawing.Point(231, 119);
      this.portNumeric.Maximum = new decimal(new int[] {
            65553,
            0,
            0,
            0});
      this.portNumeric.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
      this.portNumeric.Name = "portNumeric";
      this.portNumeric.Size = new System.Drawing.Size(58, 20);
      this.portNumeric.TabIndex = 26;
      this.portNumeric.Value = new decimal(new int[] {
            80,
            0,
            0,
            0});
      // 
      // cameraIPAddressText
      // 
      this.cameraIPAddressText.Location = new System.Drawing.Point(231, 83);
      this.cameraIPAddressText.Name = "cameraIPAddressText";
      this.cameraIPAddressText.Size = new System.Drawing.Size(87, 20);
      this.cameraIPAddressText.TabIndex = 25;
      this.cameraIPAddressText.Text = "localhost";
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label6.Location = new System.Drawing.Point(108, 25);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(510, 16);
      this.label6.TabIndex = 24;
      this.label6.Text = "Enter the Data to Contact the CURRENT Blue Iris Camera for Live Images";
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(110, 226);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(93, 13);
      this.label5.TabIndex = 23;
      this.label5.Text = "Blue Iris Password";
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(103, 191);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(100, 13);
      this.label4.TabIndex = 22;
      this.label4.Text = "Blue Iris User Name";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(95, 156);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(108, 13);
      this.label3.TabIndex = 21;
      this.label3.Text = "Short Camera Name: ";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(121, 121);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(82, 13);
      this.label2.TabIndex = 20;
      this.label2.Text = "Port (Often 80): ";
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(19, 86);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(184, 13);
      this.label1.TabIndex = 19;
      this.label1.Text = "Camera IP Address/Computer Name: ";
      // 
      // monitorTab
      // 
      this.monitorTab.Controls.Add(this.label17);
      this.monitorTab.Controls.Add(this.label16);
      this.monitorTab.Controls.Add(this.monitorListView);
      this.monitorTab.Location = new System.Drawing.Point(4, 22);
      this.monitorTab.Name = "monitorTab";
      this.monitorTab.Size = new System.Drawing.Size(726, 428);
      this.monitorTab.TabIndex = 3;
      this.monitorTab.Text = "Monitor Camera(s)";
      this.monitorTab.UseVisualStyleBackColor = true;
      // 
      // label17
      // 
      this.label17.AutoSize = true;
      this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label17.Location = new System.Drawing.Point(3, 51);
      this.label17.Name = "label17";
      this.label17.Size = new System.Drawing.Size(486, 16);
      this.label17.TabIndex = 6;
      this.label17.Text = "You can select Any camera.  This is not specific to the current camera";
      // 
      // label16
      // 
      this.label16.AutoSize = true;
      this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label16.Location = new System.Drawing.Point(35, 32);
      this.label16.Name = "label16";
      this.label16.Size = new System.Drawing.Size(392, 16);
      this.label16.TabIndex = 5;
      this.label16.Text = "Check cameras in the list to start monitoring the camera.";
      // 
      // monitorListView
      // 
      this.monitorListView.CheckBoxes = true;
      this.monitorListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
      this.monitorListView.GridLines = true;
      this.monitorListView.HideSelection = false;
      this.monitorListView.Location = new System.Drawing.Point(0, 86);
      this.monitorListView.Name = "monitorListView";
      this.monitorListView.Size = new System.Drawing.Size(541, 184);
      this.monitorListView.TabIndex = 4;
      this.monitorListView.UseCompatibleStateImageBehavior = false;
      this.monitorListView.View = System.Windows.Forms.View.Details;
      this.monitorListView.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.OnMonitorCheck);
      // 
      // columnHeader1
      // 
      this.columnHeader1.Text = "Camera Name";
      this.columnHeader1.Width = 150;
      // 
      // columnHeader2
      // 
      this.columnHeader2.Text = "Path to Files";
      this.columnHeader2.Width = 337;
      // 
      // okButton
      // 
      this.okButton.Location = new System.Drawing.Point(281, 474);
      this.okButton.Name = "okButton";
      this.okButton.Size = new System.Drawing.Size(75, 23);
      this.okButton.TabIndex = 0;
      this.okButton.Text = "OK";
      this.okButton.UseVisualStyleBackColor = true;
      this.okButton.Click += new System.EventHandler(this.OkButton_Click);
      // 
      // cancelButton
      // 
      this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.cancelButton.Location = new System.Drawing.Point(373, 474);
      this.cancelButton.Name = "cancelButton";
      this.cancelButton.Size = new System.Drawing.Size(75, 23);
      this.cancelButton.TabIndex = 1;
      this.cancelButton.Text = "Cancel";
      this.cancelButton.UseVisualStyleBackColor = true;
      this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
      // 
      // CameraConfigurationDialog
      // 
      this.AcceptButton = this.okButton;
      this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
      this.CancelButton = this.cancelButton;
      this.ClientSize = new System.Drawing.Size(765, 504);
      this.Controls.Add(this.cancelButton);
      this.Controls.Add(this.okButton);
      this.Controls.Add(this.configurationTabControl);
      this.Name = "CameraConfigurationDialog";
      this.Text = "Camera Configuration";
      this.configurationTabControl.ResumeLayout(false);
      this.imagesTab.ResumeLayout(false);
      this.imagesTab.PerformLayout();
      this.liveCameraTab.ResumeLayout(false);
      this.liveCameraTab.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.cameraYResolutionNumeric)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.cameraXResolutionNumeric)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.portNumeric)).EndInit();
      this.monitorTab.ResumeLayout(false);
      this.monitorTab.PerformLayout();
      this.ResumeLayout(false);

    }

        #endregion

        private System.Windows.Forms.TabControl configurationTabControl;
        private System.Windows.Forms.TabPage imagesTab;
        private System.Windows.Forms.TabPage liveCameraTab;
        private System.Windows.Forms.TabPage monitorTab;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
    private System.Windows.Forms.Label label10;
    private System.Windows.Forms.Label label15;
    private System.Windows.Forms.Label label14;
    private System.Windows.Forms.Label label13;
    private System.Windows.Forms.Label label12;
    private System.Windows.Forms.Label label11;
    private System.Windows.Forms.Label label9;
    private System.Windows.Forms.NumericUpDown cameraYResolutionNumeric;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.NumericUpDown cameraXResolutionNumeric;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.TextBox cameraPasswordText;
    private System.Windows.Forms.TextBox cameraUserText;
    private System.Windows.Forms.TextBox cameraNameText;
    private System.Windows.Forms.NumericUpDown portNumeric;
    private System.Windows.Forms.TextBox cameraIPAddressText;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label17;
    private System.Windows.Forms.Label label16;
    private System.Windows.Forms.ListView monitorListView;
    private System.Windows.Forms.ColumnHeader columnHeader1;
    private System.Windows.Forms.ColumnHeader columnHeader2;
    private System.Windows.Forms.Label label22;
    private System.Windows.Forms.Label label19;
    private System.Windows.Forms.Label label21;
        private System.Windows.Forms.ListView availableCamerasList;
        private System.Windows.Forms.Button removeCameraButton;
        private System.Windows.Forms.Button addCameraButton;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Label currentCameraLabel;
    }
}