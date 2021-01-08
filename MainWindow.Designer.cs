namespace SAAI
{
  partial class MainWindow
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
      if (disposing)
      {
        Dbg.Stop.Set();
        _stopEvent.Set(); // shut down the MonitorQueue thread (and any other waits)
        _wakeFileQueue.Dispose();
        theCPUCounter.Dispose();
        _modifyBox?.Dispose();
        _liveTimer?.Dispose();
        if (null != _screenBitmap) _screenBitmap.Dispose();
        if (null != _areaBackgroundBitmap) _areaBackgroundBitmap.Dispose();
        if (components != null)
        {
          components.Dispose();
        }

        if (null != _allCameras)
        {
          _allCameras.Dispose();
        }
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
      this.buttonRight = new System.Windows.Forms.Button();
      this.buttonLeft = new System.Windows.Forms.Button();
      this.objectListView = new System.Windows.Forms.ListView();
      this.label = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.confidence = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.xPosition = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.yPosition = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.width = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.height = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.label1 = new System.Windows.Forms.Label();
      this.numberOfFilesTextBox = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.fileNumberUpDown = new System.Windows.Forms.NumericUpDown();
      this.goToFileButton = new System.Windows.Forms.Button();
      this.label3 = new System.Windows.Forms.Label();
      this.currentNumberTextBox = new System.Windows.Forms.TextBox();
      this.label4 = new System.Windows.Forms.Label();
      this.fileNameTextBox = new System.Windows.Forms.TextBox();
      this.label5 = new System.Windows.Forms.Label();
      this.goToFileTextBox = new System.Windows.Forms.TextBox();
      this.goToFileNameButton = new System.Windows.Forms.Button();
      this.label6 = new System.Windows.Forms.Label();
      this.label7 = new System.Windows.Forms.Label();
      this.xPosLabel = new System.Windows.Forms.Label();
      this.yPosLabel = new System.Windows.Forms.Label();
      this.reverseListButton = new System.Windows.Forms.Button();
      this.showAreasOfInterestCheck = new System.Windows.Forms.CheckBox();
      this.analyzeButton = new System.Windows.Forms.Button();
      this.liveCameraButton = new System.Windows.Forms.Button();
      this.presetButton = new System.Windows.Forms.Button();
      this.presetNumeric = new System.Windows.Forms.NumericUpDown();
      this.LiveOnDemandGroup = new System.Windows.Forms.GroupBox();
      this.liveCheck = new System.Windows.Forms.CheckBox();
      this.camZoomOut = new System.Windows.Forms.Button();
      this.zoomInButton = new System.Windows.Forms.Button();
      this.camDownButton = new System.Windows.Forms.Button();
      this.camRightButton = new System.Windows.Forms.Button();
      this.camLeftButton = new System.Windows.Forms.Button();
      this.camUpButton = new System.Windows.Forms.Button();
      this.refreshButton = new System.Windows.Forms.Button();
      this.pictureImage = new System.Windows.Forms.PictureBox();
      this.cpuProgress = new System.Windows.Forms.ProgressBar();
      this.label8 = new System.Windows.Forms.Label();
      this.label9 = new System.Windows.Forms.Label();
      this.cameraCombo = new System.Windows.Forms.ComboBox();
      this.toolsPanel = new System.Windows.Forms.Panel();
      this.motionOnlyCheckbox = new System.Windows.Forms.CheckBox();
      this.CleanupButton = new System.Windows.Forms.Button();
      this.mainPanel = new System.Windows.Forms.Panel();
      this.picturePanel = new System.Windows.Forms.Panel();
      this.xTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.label10 = new System.Windows.Forms.Label();
      this.numberOfImagesLabel = new System.Windows.Forms.Label();
      this.menuStrip2 = new System.Windows.Forms.MenuStrip();
      this.fileToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
      this.exitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
      this.showToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
      this.showObjectRectanglesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.showAreasOfInterestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.editAreasOfInterestToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
      this.toolsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
      this.applicationSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.cameraSettingsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
      this.outgoingEmailServerToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
      this.addEditEmailAddressesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
      this.mQTTSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.helpToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
      this.aboutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
      this.logFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
      this.label11 = new System.Windows.Forms.Label();
      this.label12 = new System.Windows.Forms.Label();
      this.XResLabel = new System.Windows.Forms.Label();
      this.YResLabel = new System.Windows.Forms.Label();
      this.logDetailedInformationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.deleteLogFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      ((System.ComponentModel.ISupportInitialize)(this.fileNumberUpDown)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.presetNumeric)).BeginInit();
      this.LiveOnDemandGroup.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pictureImage)).BeginInit();
      this.toolsPanel.SuspendLayout();
      this.mainPanel.SuspendLayout();
      this.picturePanel.SuspendLayout();
      this.menuStrip2.SuspendLayout();
      this.SuspendLayout();
      // 
      // buttonRight
      // 
      this.buttonRight.Anchor = System.Windows.Forms.AnchorStyles.Left;
      this.buttonRight.BackgroundImage = global::SAAI.Properties.Resources.arrow_right;
      this.buttonRight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
      this.buttonRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.buttonRight.Location = new System.Drawing.Point(696, 102);
      this.buttonRight.Name = "buttonRight";
      this.buttonRight.Size = new System.Drawing.Size(31, 23);
      this.buttonRight.TabIndex = 1;
      this.buttonRight.Text = "---->";
      this.buttonRight.UseVisualStyleBackColor = true;
      this.buttonRight.Click += new System.EventHandler(this.ButtonRight_Click);
      // 
      // buttonLeft
      // 
      this.buttonLeft.Anchor = System.Windows.Forms.AnchorStyles.Left;
      this.buttonLeft.BackgroundImage = global::SAAI.Properties.Resources.arrow_left;
      this.buttonLeft.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
      this.buttonLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.buttonLeft.Location = new System.Drawing.Point(654, 102);
      this.buttonLeft.Name = "buttonLeft";
      this.buttonLeft.Size = new System.Drawing.Size(31, 23);
      this.buttonLeft.TabIndex = 2;
      this.buttonLeft.Text = "<---";
      this.buttonLeft.UseVisualStyleBackColor = true;
      this.buttonLeft.Click += new System.EventHandler(this.ButtonLeft_Click);
      // 
      // objectListView
      // 
      this.objectListView.Anchor = System.Windows.Forms.AnchorStyles.Left;
      this.objectListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.label,
            this.confidence,
            this.xPosition,
            this.yPosition,
            this.width,
            this.height});
      this.objectListView.FullRowSelect = true;
      this.objectListView.GridLines = true;
      this.objectListView.HideSelection = false;
      this.objectListView.Location = new System.Drawing.Point(3, 4);
      this.objectListView.MultiSelect = false;
      this.objectListView.Name = "objectListView";
      this.objectListView.Size = new System.Drawing.Size(397, 128);
      this.objectListView.TabIndex = 3;
      this.objectListView.UseCompatibleStateImageBehavior = false;
      this.objectListView.View = System.Windows.Forms.View.Details;
      // 
      // label
      // 
      this.label.Text = "Type";
      this.label.Width = 80;
      // 
      // confidence
      // 
      this.confidence.Text = "Confidence";
      this.confidence.Width = 70;
      // 
      // xPosition
      // 
      this.xPosition.Text = "X Position";
      // 
      // yPosition
      // 
      this.yPosition.Text = "Y Position";
      // 
      // width
      // 
      this.width.Text = "Width";
      // 
      // height
      // 
      this.height.Text = "Height";
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.BackColor = System.Drawing.SystemColors.InactiveCaption;
      this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label1.Location = new System.Drawing.Point(746, 7);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(123, 13);
      this.label1.TabIndex = 4;
      this.label1.Text = "Number of Pictures: ";
      // 
      // numberOfFilesTextBox
      // 
      this.numberOfFilesTextBox.BackColor = System.Drawing.SystemColors.InactiveCaption;
      this.numberOfFilesTextBox.Enabled = false;
      this.numberOfFilesTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.numberOfFilesTextBox.Location = new System.Drawing.Point(877, 3);
      this.numberOfFilesTextBox.Name = "numberOfFilesTextBox";
      this.numberOfFilesTextBox.Size = new System.Drawing.Size(69, 21);
      this.numberOfFilesTextBox.TabIndex = 5;
      // 
      // label2
      // 
      this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(511, 78);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(72, 13);
      this.label2.TabIndex = 6;
      this.label2.Text = "Go To File: # ";
      // 
      // fileNumberUpDown
      // 
      this.fileNumberUpDown.Anchor = System.Windows.Forms.AnchorStyles.Left;
      this.fileNumberUpDown.Location = new System.Drawing.Point(605, 76);
      this.fileNumberUpDown.Name = "fileNumberUpDown";
      this.fileNumberUpDown.Size = new System.Drawing.Size(57, 20);
      this.fileNumberUpDown.TabIndex = 7;
      // 
      // goToFileButton
      // 
      this.goToFileButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
      this.goToFileButton.Location = new System.Drawing.Point(677, 73);
      this.goToFileButton.Name = "goToFileButton";
      this.goToFileButton.Size = new System.Drawing.Size(58, 23);
      this.goToFileButton.TabIndex = 8;
      this.goToFileButton.Text = "Go!";
      this.goToFileButton.UseVisualStyleBackColor = true;
      this.goToFileButton.Click += new System.EventHandler(this.GoToFileButton_Click);
      // 
      // label3
      // 
      this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(418, 79);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(47, 13);
      this.label3.TabIndex = 9;
      this.label3.Text = "Number:";
      // 
      // currentNumberTextBox
      // 
      this.currentNumberTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
      this.currentNumberTextBox.Location = new System.Drawing.Point(471, 74);
      this.currentNumberTextBox.Name = "currentNumberTextBox";
      this.currentNumberTextBox.ReadOnly = true;
      this.currentNumberTextBox.Size = new System.Drawing.Size(40, 20);
      this.currentNumberTextBox.TabIndex = 10;
      // 
      // label4
      // 
      this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(439, 19);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(26, 13);
      this.label4.TabIndex = 11;
      this.label4.Text = "File:";
      // 
      // fileNameTextBox
      // 
      this.fileNameTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
      this.fileNameTextBox.Location = new System.Drawing.Point(471, 16);
      this.fileNameTextBox.Name = "fileNameTextBox";
      this.fileNameTextBox.ReadOnly = true;
      this.fileNameTextBox.Size = new System.Drawing.Size(264, 20);
      this.fileNameTextBox.TabIndex = 12;
      // 
      // label5
      // 
      this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(425, 47);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(40, 13);
      this.label5.TabIndex = 13;
      this.label5.Text = "Go To:";
      // 
      // goToFileTextBox
      // 
      this.goToFileTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
      this.goToFileTextBox.Location = new System.Drawing.Point(471, 45);
      this.goToFileTextBox.Name = "goToFileTextBox";
      this.goToFileTextBox.Size = new System.Drawing.Size(264, 20);
      this.goToFileTextBox.TabIndex = 14;
      // 
      // goToFileNameButton
      // 
      this.goToFileNameButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
      this.goToFileNameButton.Location = new System.Drawing.Point(752, 42);
      this.goToFileNameButton.Name = "goToFileNameButton";
      this.goToFileNameButton.Size = new System.Drawing.Size(58, 23);
      this.goToFileNameButton.TabIndex = 15;
      this.goToFileNameButton.Text = "Go!";
      this.goToFileNameButton.UseVisualStyleBackColor = true;
      this.goToFileNameButton.Click += new System.EventHandler(this.GoToFileNameButton_Click);
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.BackColor = System.Drawing.SystemColors.InactiveCaption;
      this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label6.Location = new System.Drawing.Point(556, 7);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(24, 15);
      this.label6.TabIndex = 16;
      this.label6.Text = "X: ";
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.BackColor = System.Drawing.SystemColors.InactiveCaption;
      this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label7.Location = new System.Drawing.Point(648, 7);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(23, 15);
      this.label7.TabIndex = 17;
      this.label7.Text = "Y: ";
      // 
      // xPosLabel
      // 
      this.xPosLabel.AutoSize = true;
      this.xPosLabel.BackColor = System.Drawing.SystemColors.InactiveCaption;
      this.xPosLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.xPosLabel.Location = new System.Drawing.Point(584, 7);
      this.xPosLabel.Name = "xPosLabel";
      this.xPosLabel.Size = new System.Drawing.Size(35, 15);
      this.xPosLabel.TabIndex = 18;
      this.xPosLabel.Text = "0     ";
      // 
      // yPosLabel
      // 
      this.yPosLabel.AutoSize = true;
      this.yPosLabel.BackColor = System.Drawing.SystemColors.InactiveCaption;
      this.yPosLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.yPosLabel.Location = new System.Drawing.Point(675, 7);
      this.yPosLabel.Name = "yPosLabel";
      this.yPosLabel.Size = new System.Drawing.Size(35, 15);
      this.yPosLabel.TabIndex = 19;
      this.yPosLabel.Text = "0     ";
      // 
      // reverseListButton
      // 
      this.reverseListButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
      this.reverseListButton.Location = new System.Drawing.Point(752, 14);
      this.reverseListButton.Name = "reverseListButton";
      this.reverseListButton.Size = new System.Drawing.Size(58, 23);
      this.reverseListButton.TabIndex = 20;
      this.reverseListButton.Text = "Reverse!";
      this.reverseListButton.UseVisualStyleBackColor = true;
      this.reverseListButton.Click += new System.EventHandler(this.OnReverseListButton);
      // 
      // showAreasOfInterestCheck
      // 
      this.showAreasOfInterestCheck.Anchor = System.Windows.Forms.AnchorStyles.Left;
      this.showAreasOfInterestCheck.AutoSize = true;
      this.showAreasOfInterestCheck.Location = new System.Drawing.Point(421, 103);
      this.showAreasOfInterestCheck.Name = "showAreasOfInterestCheck";
      this.showAreasOfInterestCheck.Size = new System.Drawing.Size(133, 17);
      this.showAreasOfInterestCheck.TabIndex = 22;
      this.showAreasOfInterestCheck.Text = "Show Areas of Interest";
      this.showAreasOfInterestCheck.UseVisualStyleBackColor = true;
      this.showAreasOfInterestCheck.CheckedChanged += new System.EventHandler(this.ShowAreasOfInterestCheckChanged);
      // 
      // analyzeButton
      // 
      this.analyzeButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
      this.analyzeButton.Location = new System.Drawing.Point(752, 102);
      this.analyzeButton.Name = "analyzeButton";
      this.analyzeButton.Size = new System.Drawing.Size(58, 23);
      this.analyzeButton.TabIndex = 23;
      this.analyzeButton.Text = "Analyze!";
      this.analyzeButton.UseVisualStyleBackColor = true;
      this.analyzeButton.Click += new System.EventHandler(this.AnalyzeButton_Click);
      // 
      // liveCameraButton
      // 
      this.liveCameraButton.Location = new System.Drawing.Point(13, 25);
      this.liveCameraButton.Name = "liveCameraButton";
      this.liveCameraButton.Size = new System.Drawing.Size(75, 23);
      this.liveCameraButton.TabIndex = 24;
      this.liveCameraButton.Text = "Snapshot";
      this.liveCameraButton.UseVisualStyleBackColor = true;
      this.liveCameraButton.Click += new System.EventHandler(this.LiveCameraButton_Click);
      // 
      // presetButton
      // 
      this.presetButton.Location = new System.Drawing.Point(13, 53);
      this.presetButton.Name = "presetButton";
      this.presetButton.Size = new System.Drawing.Size(75, 23);
      this.presetButton.TabIndex = 31;
      this.presetButton.Text = "Go to Preset";
      this.presetButton.UseVisualStyleBackColor = true;
      this.presetButton.Click += new System.EventHandler(this.PresetButton_Click);
      // 
      // presetNumeric
      // 
      this.presetNumeric.Location = new System.Drawing.Point(100, 56);
      this.presetNumeric.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
      this.presetNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.presetNumeric.Name = "presetNumeric";
      this.presetNumeric.Size = new System.Drawing.Size(46, 20);
      this.presetNumeric.TabIndex = 32;
      this.presetNumeric.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
      // 
      // LiveOnDemandGroup
      // 
      this.LiveOnDemandGroup.Anchor = System.Windows.Forms.AnchorStyles.Left;
      this.LiveOnDemandGroup.BackColor = System.Drawing.SystemColors.ControlDark;
      this.LiveOnDemandGroup.Controls.Add(this.liveCheck);
      this.LiveOnDemandGroup.Controls.Add(this.presetButton);
      this.LiveOnDemandGroup.Controls.Add(this.camZoomOut);
      this.LiveOnDemandGroup.Controls.Add(this.presetNumeric);
      this.LiveOnDemandGroup.Controls.Add(this.zoomInButton);
      this.LiveOnDemandGroup.Controls.Add(this.camDownButton);
      this.LiveOnDemandGroup.Controls.Add(this.camRightButton);
      this.LiveOnDemandGroup.Controls.Add(this.liveCameraButton);
      this.LiveOnDemandGroup.Controls.Add(this.camLeftButton);
      this.LiveOnDemandGroup.Controls.Add(this.camUpButton);
      this.LiveOnDemandGroup.Location = new System.Drawing.Point(995, 8);
      this.LiveOnDemandGroup.Name = "LiveOnDemandGroup";
      this.LiveOnDemandGroup.Size = new System.Drawing.Size(261, 112);
      this.LiveOnDemandGroup.TabIndex = 33;
      this.LiveOnDemandGroup.TabStop = false;
      this.LiveOnDemandGroup.Text = "Live Image - On Demand";
      // 
      // liveCheck
      // 
      this.liveCheck.Appearance = System.Windows.Forms.Appearance.Button;
      this.liveCheck.AutoSize = true;
      this.liveCheck.BackColor = System.Drawing.SystemColors.Control;
      this.liveCheck.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
      this.liveCheck.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.liveCheck.Location = new System.Drawing.Point(94, 25);
      this.liveCheck.Name = "liveCheck";
      this.liveCheck.Size = new System.Drawing.Size(70, 23);
      this.liveCheck.TabIndex = 33;
      this.liveCheck.Text = "Continuous";
      this.liveCheck.UseVisualStyleBackColor = false;
      this.liveCheck.CheckedChanged += new System.EventHandler(this.LiveCheck_CheckedChanged);
      // 
      // camZoomOut
      // 
      this.camZoomOut.Image = global::SAAI.Properties.Resources.zoom_out;
      this.camZoomOut.Location = new System.Drawing.Point(167, 71);
      this.camZoomOut.Name = "camZoomOut";
      this.camZoomOut.Size = new System.Drawing.Size(25, 25);
      this.camZoomOut.TabIndex = 30;
      this.camZoomOut.UseVisualStyleBackColor = true;
      this.camZoomOut.Click += new System.EventHandler(this.CamZoomOut_Click);
      // 
      // zoomInButton
      // 
      this.zoomInButton.Image = global::SAAI.Properties.Resources.zoom_in;
      this.zoomInButton.Location = new System.Drawing.Point(229, 21);
      this.zoomInButton.Name = "zoomInButton";
      this.zoomInButton.Size = new System.Drawing.Size(25, 25);
      this.zoomInButton.TabIndex = 29;
      this.zoomInButton.UseVisualStyleBackColor = true;
      this.zoomInButton.Click += new System.EventHandler(this.ZoomInButton_Click);
      // 
      // camDownButton
      // 
      this.camDownButton.Image = global::SAAI.Properties.Resources.arrow_down;
      this.camDownButton.Location = new System.Drawing.Point(199, 70);
      this.camDownButton.Name = "camDownButton";
      this.camDownButton.Size = new System.Drawing.Size(25, 25);
      this.camDownButton.TabIndex = 26;
      this.camDownButton.UseVisualStyleBackColor = true;
      this.camDownButton.Click += new System.EventHandler(this.CamDownButton_Click);
      // 
      // camRightButton
      // 
      this.camRightButton.Image = global::SAAI.Properties.Resources.arrow_right;
      this.camRightButton.Location = new System.Drawing.Point(229, 46);
      this.camRightButton.Name = "camRightButton";
      this.camRightButton.Size = new System.Drawing.Size(25, 25);
      this.camRightButton.TabIndex = 28;
      this.camRightButton.UseVisualStyleBackColor = true;
      this.camRightButton.Click += new System.EventHandler(this.CamRightButton_Click);
      // 
      // camLeftButton
      // 
      this.camLeftButton.Image = global::SAAI.Properties.Resources.arrow_left;
      this.camLeftButton.Location = new System.Drawing.Point(169, 46);
      this.camLeftButton.Name = "camLeftButton";
      this.camLeftButton.Size = new System.Drawing.Size(25, 25);
      this.camLeftButton.TabIndex = 27;
      this.camLeftButton.UseVisualStyleBackColor = true;
      this.camLeftButton.Click += new System.EventHandler(this.CamLeftButton_Click);
      // 
      // camUpButton
      // 
      this.camUpButton.Image = global::SAAI.Properties.Resources.arrow_up;
      this.camUpButton.Location = new System.Drawing.Point(199, 24);
      this.camUpButton.Name = "camUpButton";
      this.camUpButton.Size = new System.Drawing.Size(25, 25);
      this.camUpButton.TabIndex = 25;
      this.camUpButton.UseVisualStyleBackColor = true;
      this.camUpButton.Click += new System.EventHandler(this.CamUpButton_Click);
      // 
      // refreshButton
      // 
      this.refreshButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
      this.refreshButton.Location = new System.Drawing.Point(752, 72);
      this.refreshButton.Name = "refreshButton";
      this.refreshButton.Size = new System.Drawing.Size(58, 23);
      this.refreshButton.TabIndex = 33;
      this.refreshButton.Text = "Refresh";
      this.refreshButton.UseVisualStyleBackColor = true;
      this.refreshButton.Click += new System.EventHandler(this.Refresh_Click);
      // 
      // pictureImage
      // 
      this.pictureImage.Location = new System.Drawing.Point(1, 1);
      this.pictureImage.Name = "pictureImage";
      this.pictureImage.Size = new System.Drawing.Size(1280, 960);
      this.pictureImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
      this.pictureImage.TabIndex = 0;
      this.pictureImage.TabStop = false;
      this.pictureImage.SizeChanged += new System.EventHandler(this.OnSizeChanged);
      this.pictureImage.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnMouseDown);
      this.pictureImage.MouseEnter += new System.EventHandler(this.OnMouseEnter);
      this.pictureImage.MouseLeave += new System.EventHandler(this.OnMouseLeave);
      this.pictureImage.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OnMouseMove);
      this.pictureImage.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnMouseUp);
      // 
      // cpuProgress
      // 
      this.cpuProgress.Anchor = System.Windows.Forms.AnchorStyles.Left;
      this.cpuProgress.Location = new System.Drawing.Point(903, 67);
      this.cpuProgress.MarqueeAnimationSpeed = 300;
      this.cpuProgress.Name = "cpuProgress";
      this.cpuProgress.Size = new System.Drawing.Size(73, 15);
      this.cpuProgress.TabIndex = 34;
      this.cpuProgress.Value = 50;
      // 
      // label8
      // 
      this.label8.Anchor = System.Windows.Forms.AnchorStyles.Left;
      this.label8.AutoSize = true;
      this.label8.Location = new System.Drawing.Point(841, 69);
      this.label8.Name = "label8";
      this.label8.Size = new System.Drawing.Size(56, 13);
      this.label8.TabIndex = 35;
      this.label8.Text = "CPU Load";
      // 
      // label9
      // 
      this.label9.Anchor = System.Windows.Forms.AnchorStyles.Left;
      this.label9.AutoSize = true;
      this.label9.Location = new System.Drawing.Point(865, 0);
      this.label9.Name = "label9";
      this.label9.Size = new System.Drawing.Size(76, 13);
      this.label9.TabIndex = 36;
      this.label9.Text = "Select Camera";
      // 
      // cameraCombo
      // 
      this.cameraCombo.Anchor = System.Windows.Forms.AnchorStyles.Left;
      this.cameraCombo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.cameraCombo.FormattingEnabled = true;
      this.cameraCombo.Location = new System.Drawing.Point(844, 20);
      this.cameraCombo.Name = "cameraCombo";
      this.cameraCombo.Size = new System.Drawing.Size(132, 21);
      this.cameraCombo.TabIndex = 37;
      this.cameraCombo.SelectionChangeCommitted += new System.EventHandler(this.OnCameraSelected);
      // 
      // toolsPanel
      // 
      this.toolsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.toolsPanel.AutoScroll = true;
      this.toolsPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.toolsPanel.Controls.Add(this.motionOnlyCheckbox);
      this.toolsPanel.Controls.Add(this.CleanupButton);
      this.toolsPanel.Controls.Add(this.objectListView);
      this.toolsPanel.Controls.Add(this.LiveOnDemandGroup);
      this.toolsPanel.Controls.Add(this.cameraCombo);
      this.toolsPanel.Controls.Add(this.label9);
      this.toolsPanel.Controls.Add(this.label4);
      this.toolsPanel.Controls.Add(this.label8);
      this.toolsPanel.Controls.Add(this.fileNameTextBox);
      this.toolsPanel.Controls.Add(this.cpuProgress);
      this.toolsPanel.Controls.Add(this.goToFileTextBox);
      this.toolsPanel.Controls.Add(this.label5);
      this.toolsPanel.Controls.Add(this.refreshButton);
      this.toolsPanel.Controls.Add(this.goToFileButton);
      this.toolsPanel.Controls.Add(this.label2);
      this.toolsPanel.Controls.Add(this.analyzeButton);
      this.toolsPanel.Controls.Add(this.fileNumberUpDown);
      this.toolsPanel.Controls.Add(this.reverseListButton);
      this.toolsPanel.Controls.Add(this.showAreasOfInterestCheck);
      this.toolsPanel.Controls.Add(this.currentNumberTextBox);
      this.toolsPanel.Controls.Add(this.label3);
      this.toolsPanel.Controls.Add(this.buttonRight);
      this.toolsPanel.Controls.Add(this.goToFileNameButton);
      this.toolsPanel.Controls.Add(this.buttonLeft);
      this.toolsPanel.Location = new System.Drawing.Point(16, 809);
      this.toolsPanel.Name = "toolsPanel";
      this.toolsPanel.Size = new System.Drawing.Size(1256, 155);
      this.toolsPanel.TabIndex = 38;
      // 
      // motionOnlyCheckbox
      // 
      this.motionOnlyCheckbox.Anchor = System.Windows.Forms.AnchorStyles.Left;
      this.motionOnlyCheckbox.Appearance = System.Windows.Forms.Appearance.Button;
      this.motionOnlyCheckbox.AutoSize = true;
      this.motionOnlyCheckbox.Location = new System.Drawing.Point(572, 102);
      this.motionOnlyCheckbox.Name = "motionOnlyCheckbox";
      this.motionOnlyCheckbox.Size = new System.Drawing.Size(76, 23);
      this.motionOnlyCheckbox.TabIndex = 39;
      this.motionOnlyCheckbox.Text = "Motion Only!";
      this.motionOnlyCheckbox.UseVisualStyleBackColor = true;
      this.motionOnlyCheckbox.CheckedChanged += new System.EventHandler(this.MotionOnlyCheckbox_CheckedChanged);
      this.motionOnlyCheckbox.CheckStateChanged += new System.EventHandler(this.OnMotionCheckChanged);
      // 
      // CleanupButton
      // 
      this.CleanupButton.Location = new System.Drawing.Point(844, 106);
      this.CleanupButton.Name = "CleanupButton";
      this.CleanupButton.Size = new System.Drawing.Size(122, 23);
      this.CleanupButton.TabIndex = 38;
      this.CleanupButton.Text = "Cleanup Old Pictures";
      this.CleanupButton.UseVisualStyleBackColor = true;
      this.CleanupButton.Click += new System.EventHandler(this.CleanupButton_Click);
      // 
      // mainPanel
      // 
      this.mainPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.mainPanel.AutoScroll = true;
      this.mainPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
      this.mainPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.mainPanel.Controls.Add(this.picturePanel);
      this.mainPanel.Controls.Add(this.toolsPanel);
      this.mainPanel.Location = new System.Drawing.Point(0, 28);
      this.mainPanel.Name = "mainPanel";
      this.mainPanel.Size = new System.Drawing.Size(1270, 974);
      this.mainPanel.TabIndex = 39;
      // 
      // picturePanel
      // 
      this.picturePanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.picturePanel.AutoScroll = true;
      this.picturePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.picturePanel.Controls.Add(this.pictureImage);
      this.picturePanel.Location = new System.Drawing.Point(1, 1);
      this.picturePanel.Name = "picturePanel";
      this.picturePanel.Size = new System.Drawing.Size(1257, 794);
      this.picturePanel.TabIndex = 39;
      // 
      // xTestToolStripMenuItem
      // 
      this.xTestToolStripMenuItem.Name = "xTestToolStripMenuItem";
      this.xTestToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
      // 
      // label10
      // 
      this.label10.BackColor = System.Drawing.SystemColors.InactiveCaption;
      this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label10.Location = new System.Drawing.Point(997, 7);
      this.label10.Name = "label10";
      this.label10.Size = new System.Drawing.Size(180, 15);
      this.label10.TabIndex = 39;
      this.label10.Text = "Number of Images Processed: ";
      // 
      // numberOfImagesLabel
      // 
      this.numberOfImagesLabel.AutoSize = true;
      this.numberOfImagesLabel.BackColor = System.Drawing.SystemColors.InactiveCaption;
      this.numberOfImagesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.numberOfImagesLabel.Location = new System.Drawing.Point(1192, 7);
      this.numberOfImagesLabel.Name = "numberOfImagesLabel";
      this.numberOfImagesLabel.Size = new System.Drawing.Size(35, 15);
      this.numberOfImagesLabel.TabIndex = 40;
      this.numberOfImagesLabel.Text = "0     ";
      // 
      // menuStrip2
      // 
      this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem1,
            this.showToolStripMenuItem1,
            this.editAreasOfInterestToolStripMenuItem1,
            this.toolsToolStripMenuItem1,
            this.helpToolStripMenuItem1});
      this.menuStrip2.Location = new System.Drawing.Point(0, 0);
      this.menuStrip2.Name = "menuStrip2";
      this.menuStrip2.Size = new System.Drawing.Size(1284, 24);
      this.menuStrip2.TabIndex = 41;
      this.menuStrip2.Text = "menuStrip2";
      // 
      // fileToolStripMenuItem1
      // 
      this.fileToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem1});
      this.fileToolStripMenuItem1.Name = "fileToolStripMenuItem1";
      this.fileToolStripMenuItem1.Size = new System.Drawing.Size(37, 20);
      this.fileToolStripMenuItem1.Text = "&File";
      // 
      // exitToolStripMenuItem1
      // 
      this.exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
      this.exitToolStripMenuItem1.Size = new System.Drawing.Size(93, 22);
      this.exitToolStripMenuItem1.Text = "Exit";
      this.exitToolStripMenuItem1.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
      // 
      // showToolStripMenuItem1
      // 
      this.showToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showObjectRectanglesToolStripMenuItem,
            this.showAreasOfInterestToolStripMenuItem});
      this.showToolStripMenuItem1.Name = "showToolStripMenuItem1";
      this.showToolStripMenuItem1.Size = new System.Drawing.Size(48, 20);
      this.showToolStripMenuItem1.Text = "&Show";
      // 
      // showObjectRectanglesToolStripMenuItem
      // 
      this.showObjectRectanglesToolStripMenuItem.Checked = true;
      this.showObjectRectanglesToolStripMenuItem.CheckOnClick = true;
      this.showObjectRectanglesToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
      this.showObjectRectanglesToolStripMenuItem.Name = "showObjectRectanglesToolStripMenuItem";
      this.showObjectRectanglesToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
      this.showObjectRectanglesToolStripMenuItem.Size = new System.Drawing.Size(241, 22);
      this.showObjectRectanglesToolStripMenuItem.Text = "Show Object Rectangles";
      this.showObjectRectanglesToolStripMenuItem.Click += new System.EventHandler(this.ShowObjectRectangelsToolStripMenuItem_Click);
      // 
      // showAreasOfInterestToolStripMenuItem
      // 
      this.showAreasOfInterestToolStripMenuItem.CheckOnClick = true;
      this.showAreasOfInterestToolStripMenuItem.Name = "showAreasOfInterestToolStripMenuItem";
      this.showAreasOfInterestToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
      this.showAreasOfInterestToolStripMenuItem.Size = new System.Drawing.Size(241, 22);
      this.showAreasOfInterestToolStripMenuItem.Text = "Show Areas of Interest";
      this.showAreasOfInterestToolStripMenuItem.Click += new System.EventHandler(this.AreasOfInterestToolStripMenuItem_Click);
      // 
      // editAreasOfInterestToolStripMenuItem1
      // 
      this.editAreasOfInterestToolStripMenuItem1.Name = "editAreasOfInterestToolStripMenuItem1";
      this.editAreasOfInterestToolStripMenuItem1.Size = new System.Drawing.Size(127, 20);
      this.editAreasOfInterestToolStripMenuItem1.Text = "&Edit Areas of Interest";
      this.editAreasOfInterestToolStripMenuItem1.Click += new System.EventHandler(this.EditAreasOfInterestToolStripMenuItem_Click);
      // 
      // toolsToolStripMenuItem1
      // 
      this.toolsToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.applicationSettingsToolStripMenuItem,
            this.cameraSettingsToolStripMenuItem1,
            this.outgoingEmailServerToolStripMenuItem1,
            this.addEditEmailAddressesToolStripMenuItem1,
            this.mQTTSettingsToolStripMenuItem});
      this.toolsToolStripMenuItem1.Name = "toolsToolStripMenuItem1";
      this.toolsToolStripMenuItem1.Size = new System.Drawing.Size(46, 20);
      this.toolsToolStripMenuItem1.Text = "&Tools";
      // 
      // applicationSettingsToolStripMenuItem
      // 
      this.applicationSettingsToolStripMenuItem.Name = "applicationSettingsToolStripMenuItem";
      this.applicationSettingsToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
      this.applicationSettingsToolStripMenuItem.Text = "Application Settings";
      this.applicationSettingsToolStripMenuItem.Click += new System.EventHandler(this.SettingsToolStripMenuItem_Click);
      // 
      // cameraSettingsToolStripMenuItem1
      // 
      this.cameraSettingsToolStripMenuItem1.Name = "cameraSettingsToolStripMenuItem1";
      this.cameraSettingsToolStripMenuItem1.Size = new System.Drawing.Size(209, 22);
      this.cameraSettingsToolStripMenuItem1.Text = "Camera Settings";
      this.cameraSettingsToolStripMenuItem1.Click += new System.EventHandler(this.CameraSettingsToolStripMenuItem_Click);
      // 
      // outgoingEmailServerToolStripMenuItem1
      // 
      this.outgoingEmailServerToolStripMenuItem1.Name = "outgoingEmailServerToolStripMenuItem1";
      this.outgoingEmailServerToolStripMenuItem1.Size = new System.Drawing.Size(209, 22);
      this.outgoingEmailServerToolStripMenuItem1.Text = "Outgoing Email Server";
      this.outgoingEmailServerToolStripMenuItem1.Click += new System.EventHandler(this.OutgoingEmailServerToolStripMenuItem_Click);
      // 
      // addEditEmailAddressesToolStripMenuItem1
      // 
      this.addEditEmailAddressesToolStripMenuItem1.Name = "addEditEmailAddressesToolStripMenuItem1";
      this.addEditEmailAddressesToolStripMenuItem1.Size = new System.Drawing.Size(209, 22);
      this.addEditEmailAddressesToolStripMenuItem1.Text = "Add/Edit Email Addresses";
      this.addEditEmailAddressesToolStripMenuItem1.Click += new System.EventHandler(this.AddEditEmailAddressesToolStripMenuItem_Click);
      // 
      // mQTTSettingsToolStripMenuItem
      // 
      this.mQTTSettingsToolStripMenuItem.Name = "mQTTSettingsToolStripMenuItem";
      this.mQTTSettingsToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
      this.mQTTSettingsToolStripMenuItem.Text = "MQTT Settings";
      this.mQTTSettingsToolStripMenuItem.Click += new System.EventHandler(this.MQTTSettingsToolStripMenuItem_Click);
      // 
      // helpToolStripMenuItem1
      // 
      this.helpToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem1,
            this.logFileToolStripMenuItem,
            this.logDetailedInformationToolStripMenuItem,
            this.deleteLogFileToolStripMenuItem});
      this.helpToolStripMenuItem1.Name = "helpToolStripMenuItem1";
      this.helpToolStripMenuItem1.Size = new System.Drawing.Size(44, 20);
      this.helpToolStripMenuItem1.Text = "&Help";
      // 
      // aboutToolStripMenuItem1
      // 
      this.aboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1";
      this.aboutToolStripMenuItem1.Size = new System.Drawing.Size(206, 22);
      this.aboutToolStripMenuItem1.Text = "About";
      this.aboutToolStripMenuItem1.Click += new System.EventHandler(this.AboutToolStripMenuItem_Click);
      // 
      // logFileToolStripMenuItem
      // 
      this.logFileToolStripMenuItem.Name = "logFileToolStripMenuItem";
      this.logFileToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
      this.logFileToolStripMenuItem.Text = "Log File";
      this.logFileToolStripMenuItem.Click += new System.EventHandler(this.LogFileToolStripMenuItem_Click);
      // 
      // notifyIcon
      // 
      this.notifyIcon.BalloonTipText = "On Guard minimized - double Click the icon in the system tray (near clock) to  re" +
    "-open";
      this.notifyIcon.BalloonTipTitle = "On Guard";
      this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
      this.notifyIcon.Text = "On Guard";
      this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.NotifyIcon_MouseDoubleClick);
      // 
      // label11
      // 
      this.label11.AutoSize = true;
      this.label11.BackColor = System.Drawing.SystemColors.InactiveCaption;
      this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label11.Location = new System.Drawing.Point(334, 7);
      this.label11.Name = "label11";
      this.label11.Size = new System.Drawing.Size(41, 15);
      this.label11.TabIndex = 5;
      this.label11.Text = "XRes";
      // 
      // label12
      // 
      this.label12.AutoSize = true;
      this.label12.BackColor = System.Drawing.SystemColors.InactiveCaption;
      this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label12.Location = new System.Drawing.Point(437, 7);
      this.label12.Name = "label12";
      this.label12.Size = new System.Drawing.Size(41, 15);
      this.label12.TabIndex = 6;
      this.label12.Text = "XRes";
      // 
      // XResLabel
      // 
      this.XResLabel.AutoSize = true;
      this.XResLabel.BackColor = System.Drawing.SystemColors.InactiveCaption;
      this.XResLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.XResLabel.Location = new System.Drawing.Point(377, 7);
      this.XResLabel.Name = "XResLabel";
      this.XResLabel.Size = new System.Drawing.Size(39, 15);
      this.XResLabel.TabIndex = 6;
      this.XResLabel.Text = "2560";
      // 
      // YResLabel
      // 
      this.YResLabel.AutoSize = true;
      this.YResLabel.BackColor = System.Drawing.SystemColors.InactiveCaption;
      this.YResLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.YResLabel.Location = new System.Drawing.Point(488, 7);
      this.YResLabel.Name = "YResLabel";
      this.YResLabel.Size = new System.Drawing.Size(39, 15);
      this.YResLabel.TabIndex = 6;
      this.YResLabel.Text = "1920";
      // 
      // logDetailedInformationToolStripMenuItem
      // 
      this.logDetailedInformationToolStripMenuItem.CheckOnClick = true;
      this.logDetailedInformationToolStripMenuItem.Name = "logDetailedInformationToolStripMenuItem";
      this.logDetailedInformationToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
      this.logDetailedInformationToolStripMenuItem.Text = "Log Detailed Information";
      this.logDetailedInformationToolStripMenuItem.Click += new System.EventHandler(this.logDetailedInformationToolStripMenuItem_Click);
      // 
      // deleteLogFileToolStripMenuItem
      // 
      this.deleteLogFileToolStripMenuItem.Name = "deleteLogFileToolStripMenuItem";
      this.deleteLogFileToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
      this.deleteLogFileToolStripMenuItem.Text = "Delete Log File";
      this.deleteLogFileToolStripMenuItem.Click += new System.EventHandler(this.deleteLogFileToolStripMenuItem_Click);
      // 
      // MainWindow
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
      this.ClientSize = new System.Drawing.Size(1284, 1005);
      this.Controls.Add(this.YResLabel);
      this.Controls.Add(this.XResLabel);
      this.Controls.Add(this.label12);
      this.Controls.Add(this.label11);
      this.Controls.Add(this.numberOfImagesLabel);
      this.Controls.Add(this.label10);
      this.Controls.Add(this.numberOfFilesTextBox);
      this.Controls.Add(this.yPosLabel);
      this.Controls.Add(this.xPosLabel);
      this.Controls.Add(this.label6);
      this.Controls.Add(this.label7);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.mainPanel);
      this.Controls.Add(this.menuStrip2);
      this.DoubleBuffered = true;
      this.MainMenuStrip = this.menuStrip2;
      this.Name = "MainWindow";
      this.Text = "On Guard";
      this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OnClosed);
      this.Load += new System.EventHandler(this.Form1_Load);
      this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnKeyDown);
      this.Resize += new System.EventHandler(this.OnResize);
      ((System.ComponentModel.ISupportInitialize)(this.fileNumberUpDown)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.presetNumeric)).EndInit();
      this.LiveOnDemandGroup.ResumeLayout(false);
      this.LiveOnDemandGroup.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pictureImage)).EndInit();
      this.toolsPanel.ResumeLayout(false);
      this.toolsPanel.PerformLayout();
      this.mainPanel.ResumeLayout(false);
      this.picturePanel.ResumeLayout(false);
      this.menuStrip2.ResumeLayout(false);
      this.menuStrip2.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.PictureBox pictureImage;
    private System.Windows.Forms.Button buttonRight;
    private System.Windows.Forms.Button buttonLeft;
    private System.Windows.Forms.ListView objectListView;
    private System.Windows.Forms.ColumnHeader label;
    private System.Windows.Forms.ColumnHeader confidence;
    private System.Windows.Forms.ColumnHeader xPosition;
    private System.Windows.Forms.ColumnHeader yPosition;
    private System.Windows.Forms.ColumnHeader width;
    private System.Windows.Forms.ColumnHeader height;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox numberOfFilesTextBox;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.NumericUpDown fileNumberUpDown;
    private System.Windows.Forms.Button goToFileButton;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.TextBox currentNumberTextBox;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.TextBox fileNameTextBox;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.TextBox goToFileTextBox;
    private System.Windows.Forms.Button goToFileNameButton;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.Label xPosLabel;
    private System.Windows.Forms.Label yPosLabel;
    private System.Windows.Forms.Button reverseListButton;
    private System.Windows.Forms.CheckBox showAreasOfInterestCheck;
    private System.Windows.Forms.Button analyzeButton;
    private System.Windows.Forms.Button liveCameraButton;
    private System.Windows.Forms.Button camUpButton;
    private System.Windows.Forms.Button camDownButton;
    private System.Windows.Forms.Button camLeftButton;
    private System.Windows.Forms.Button camRightButton;
    private System.Windows.Forms.Button zoomInButton;
    private System.Windows.Forms.Button camZoomOut;
    private System.Windows.Forms.Button presetButton;
    private System.Windows.Forms.NumericUpDown presetNumeric;
    private System.Windows.Forms.GroupBox LiveOnDemandGroup;
    private System.Windows.Forms.Button refreshButton;
    private System.Windows.Forms.ProgressBar cpuProgress;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.Label label9;
    private System.Windows.Forms.ComboBox cameraCombo;
    private System.Windows.Forms.Panel toolsPanel;
    private System.Windows.Forms.Panel mainPanel;
    private System.Windows.Forms.ToolStripMenuItem xTestToolStripMenuItem;
    private System.Windows.Forms.Button CleanupButton;
    private System.Windows.Forms.Label label10;
    private System.Windows.Forms.Label numberOfImagesLabel;
    private System.Windows.Forms.CheckBox liveCheck;
    private System.Windows.Forms.Panel picturePanel;
    private System.Windows.Forms.MenuStrip menuStrip2;
    private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem1;
    private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem1;
    private System.Windows.Forms.ToolStripMenuItem showToolStripMenuItem1;
    private System.Windows.Forms.ToolStripMenuItem showObjectRectanglesToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem showAreasOfInterestToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem editAreasOfInterestToolStripMenuItem1;
    private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem1;
    private System.Windows.Forms.ToolStripMenuItem applicationSettingsToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem cameraSettingsToolStripMenuItem1;
    private System.Windows.Forms.ToolStripMenuItem outgoingEmailServerToolStripMenuItem1;
    private System.Windows.Forms.ToolStripMenuItem addEditEmailAddressesToolStripMenuItem1;
    private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem1;
    private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem1;
    private System.Windows.Forms.NotifyIcon notifyIcon;
    private System.Windows.Forms.ToolStripMenuItem logFileToolStripMenuItem;
    private System.Windows.Forms.CheckBox motionOnlyCheckbox;
    private System.Windows.Forms.ToolStripMenuItem mQTTSettingsToolStripMenuItem;
    private System.Windows.Forms.Label label11;
    private System.Windows.Forms.Label label12;
    private System.Windows.Forms.Label XResLabel;
    private System.Windows.Forms.Label YResLabel;
    private System.Windows.Forms.ToolStripMenuItem logDetailedInformationToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem deleteLogFileToolStripMenuItem;
  }
}

