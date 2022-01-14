namespace OnGuardCore
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
      this.objectListView = new System.Windows.Forms.ListView();
      this.label = new System.Windows.Forms.ColumnHeader();
      this.confidence = new System.Windows.Forms.ColumnHeader();
      this.xPosition = new System.Windows.Forms.ColumnHeader();
      this.yPosition = new System.Windows.Forms.ColumnHeader();
      this.width = new System.Windows.Forms.ColumnHeader();
      this.height = new System.Windows.Forms.ColumnHeader();
      this.label1 = new System.Windows.Forms.Label();
      this.numberOfFilesTextBox = new System.Windows.Forms.TextBox();
      this.fileNumberUpDown = new System.Windows.Forms.NumericUpDown();
      this.goToFileButton = new System.Windows.Forms.Button();
      this.label5 = new System.Windows.Forms.Label();
      this.goToFileTextBox = new System.Windows.Forms.TextBox();
      this.goToFileNameButton = new System.Windows.Forms.Button();
      this.label6 = new System.Windows.Forms.Label();
      this.label7 = new System.Windows.Forms.Label();
      this.xPosLabel = new System.Windows.Forms.Label();
      this.yPosLabel = new System.Windows.Forms.Label();
      this.reverseListButton = new System.Windows.Forms.Button();
      this.analyzeButton = new System.Windows.Forms.Button();
      this.liveCameraButton = new System.Windows.Forms.Button();
      this.presetButton = new System.Windows.Forms.Button();
      this.LiveOnDemandGroup = new System.Windows.Forms.GroupBox();
      this.PresetsCombo = new System.Windows.Forms.ComboBox();
      this.liveCheck = new System.Windows.Forms.CheckBox();
      this.camZoomOut = new System.Windows.Forms.Button();
      this.camZoomIn = new System.Windows.Forms.Button();
      this.camDownButton = new System.Windows.Forms.Button();
      this.camRightButton = new System.Windows.Forms.Button();
      this.camLeftButton = new System.Windows.Forms.Button();
      this.camUpButton = new System.Windows.Forms.Button();
      this.refreshButton = new System.Windows.Forms.Button();
      this.label8 = new System.Windows.Forms.Label();
      this.cameraCombo = new System.Windows.Forms.ComboBox();
      this.ToolsPanel = new System.Windows.Forms.Panel();
      this.panel4 = new System.Windows.Forms.Panel();
      this.FullAnalysisButton = new System.Windows.Forms.Button();
      this.panel3 = new System.Windows.Forms.Panel();
      this.label2 = new System.Windows.Forms.Label();
      this.motionOnlyCheckbox = new System.Windows.Forms.CheckBox();
      this.buttonLeft = new System.Windows.Forms.Button();
      this.buttonRight = new System.Windows.Forms.Button();
      this.panel2 = new System.Windows.Forms.Panel();
      this.label13 = new System.Windows.Forms.Label();
      this.FPSProgress = new OnGuardCore.EnhancedProgressBar();
      this.cpuProgress = new OnGuardCore.EnhancedProgressBar();
      this.label15 = new System.Windows.Forms.Label();
      this.AIProgressBar = new OnGuardCore.EnhancedProgressBar();
      this.panel1 = new System.Windows.Forms.Panel();
      this.timeLine = new OnGuardCore.TimeLine();
      this.mainPanel = new System.Windows.Forms.Panel();
      this.picturePanel = new System.Windows.Forms.Panel();
      this.pictureImage = new OnGuardCore.CameraImage();
      this.StatusPanel = new System.Windows.Forms.Panel();
      this.numberOfImagesLabel = new System.Windows.Forms.Label();
      this.YResLabel = new System.Windows.Forms.Label();
      this.label10 = new System.Windows.Forms.Label();
      this.AIStatus = new System.Windows.Forms.Label();
      this.label12 = new System.Windows.Forms.Label();
      this.XResLabel = new System.Windows.Forms.Label();
      this.label14 = new System.Windows.Forms.Label();
      this.label11 = new System.Windows.Forms.Label();
      this.xTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.menuStrip2 = new System.Windows.Forms.MenuStrip();
      this.fileToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
      this.exitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
      this.showToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
      this.showObjectRectanglesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.showAreasOfInterestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.pictureDisplayOptionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.AreasOfInterestToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
      this.editAreaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.createAreaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.cleanupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.cleanupOldPicturesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.syncToDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
      this.applicationSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.cameraSettingsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
      this.ImageCaptureMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.outgoingEmailServerToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
      this.addEditEmailAddressesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
      this.mQTTSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.analysisSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.aiAlertMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.testImagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.startRestartAIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.helpToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
      this.aboutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
      this.logFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.logDetailedInformationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.deleteLogFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
      ((System.ComponentModel.ISupportInitialize)(this.fileNumberUpDown)).BeginInit();
      this.LiveOnDemandGroup.SuspendLayout();
      this.ToolsPanel.SuspendLayout();
      this.panel4.SuspendLayout();
      this.panel3.SuspendLayout();
      this.panel2.SuspendLayout();
      this.panel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.timeLine)).BeginInit();
      this.mainPanel.SuspendLayout();
      this.picturePanel.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pictureImage)).BeginInit();
      this.StatusPanel.SuspendLayout();
      this.menuStrip2.SuspendLayout();
      this.SuspendLayout();
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
      this.objectListView.Location = new System.Drawing.Point(5, 5);
      this.objectListView.MultiSelect = false;
      this.objectListView.Name = "objectListView";
      this.objectListView.Size = new System.Drawing.Size(407, 114);
      this.objectListView.TabIndex = 3;
      this.objectListView.UseCompatibleStateImageBehavior = false;
      this.objectListView.View = System.Windows.Forms.View.Details;
      // 
      // label
      // 
      this.label.Name = "label";
      this.label.Text = "Type";
      this.label.Width = 75;
      // 
      // confidence
      // 
      this.confidence.Name = "confidence";
      this.confidence.Text = "Confidence";
      this.confidence.Width = 75;
      // 
      // xPosition
      // 
      this.xPosition.Name = "xPosition";
      this.xPosition.Text = "X Position";
      this.xPosition.Width = 70;
      // 
      // yPosition
      // 
      this.yPosition.Name = "yPosition";
      this.yPosition.Text = "Y Position";
      this.yPosition.Width = 70;
      // 
      // width
      // 
      this.width.Name = "width";
      this.width.Text = "Width";
      this.width.Width = 55;
      // 
      // height
      // 
      this.height.Name = "height";
      this.height.Text = "Height";
      this.height.Width = 55;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.BackColor = System.Drawing.SystemColors.InactiveCaption;
      this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.label1.Location = new System.Drawing.Point(669, 3);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(131, 13);
      this.label1.TabIndex = 4;
      this.label1.Text = "Working Set Pictures:";
      // 
      // numberOfFilesTextBox
      // 
      this.numberOfFilesTextBox.BackColor = System.Drawing.SystemColors.InactiveCaption;
      this.numberOfFilesTextBox.Enabled = false;
      this.numberOfFilesTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.numberOfFilesTextBox.Location = new System.Drawing.Point(807, 1);
      this.numberOfFilesTextBox.Name = "numberOfFilesTextBox";
      this.numberOfFilesTextBox.Size = new System.Drawing.Size(69, 21);
      this.numberOfFilesTextBox.TabIndex = 5;
      // 
      // fileNumberUpDown
      // 
      this.fileNumberUpDown.Location = new System.Drawing.Point(36, 37);
      this.fileNumberUpDown.Name = "fileNumberUpDown";
      this.fileNumberUpDown.Size = new System.Drawing.Size(57, 23);
      this.fileNumberUpDown.TabIndex = 7;
      // 
      // goToFileButton
      // 
      this.goToFileButton.Location = new System.Drawing.Point(99, 36);
      this.goToFileButton.Name = "goToFileButton";
      this.goToFileButton.Size = new System.Drawing.Size(39, 23);
      this.goToFileButton.TabIndex = 8;
      this.goToFileButton.Text = "Go!";
      this.goToFileButton.UseVisualStyleBackColor = true;
      this.goToFileButton.Click += new System.EventHandler(this.GoToFileButton_Click);
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(3, 8);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(25, 15);
      this.label5.TabIndex = 13;
      this.label5.Text = "File";
      // 
      // goToFileTextBox
      // 
      this.goToFileTextBox.Location = new System.Drawing.Point(33, 5);
      this.goToFileTextBox.Name = "goToFileTextBox";
      this.goToFileTextBox.Size = new System.Drawing.Size(232, 23);
      this.goToFileTextBox.TabIndex = 14;
      // 
      // goToFileNameButton
      // 
      this.goToFileNameButton.Location = new System.Drawing.Point(271, 5);
      this.goToFileNameButton.Name = "goToFileNameButton";
      this.goToFileNameButton.Size = new System.Drawing.Size(39, 23);
      this.goToFileNameButton.TabIndex = 15;
      this.goToFileNameButton.Text = "Go!";
      this.goToFileNameButton.UseVisualStyleBackColor = true;
      this.goToFileNameButton.Click += new System.EventHandler(this.GoToFileNameButton_Click);
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.BackColor = System.Drawing.SystemColors.InactiveCaption;
      this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.label6.Location = new System.Drawing.Point(406, 3);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(24, 15);
      this.label6.TabIndex = 16;
      this.label6.Text = "X: ";
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.BackColor = System.Drawing.SystemColors.InactiveCaption;
      this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.label7.Location = new System.Drawing.Point(480, 3);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(23, 15);
      this.label7.TabIndex = 17;
      this.label7.Text = "Y: ";
      // 
      // xPosLabel
      // 
      this.xPosLabel.AutoSize = true;
      this.xPosLabel.BackColor = System.Drawing.SystemColors.InactiveCaption;
      this.xPosLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.xPosLabel.Location = new System.Drawing.Point(434, 3);
      this.xPosLabel.Name = "xPosLabel";
      this.xPosLabel.Size = new System.Drawing.Size(35, 15);
      this.xPosLabel.TabIndex = 18;
      this.xPosLabel.Text = "0     ";
      // 
      // yPosLabel
      // 
      this.yPosLabel.AutoSize = true;
      this.yPosLabel.BackColor = System.Drawing.SystemColors.InactiveCaption;
      this.yPosLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.yPosLabel.Location = new System.Drawing.Point(507, 3);
      this.yPosLabel.Name = "yPosLabel";
      this.yPosLabel.Size = new System.Drawing.Size(35, 15);
      this.yPosLabel.TabIndex = 19;
      this.yPosLabel.Text = "0     ";
      // 
      // reverseListButton
      // 
      this.reverseListButton.Location = new System.Drawing.Point(3, 70);
      this.reverseListButton.Name = "reverseListButton";
      this.reverseListButton.Size = new System.Drawing.Size(95, 23);
      this.reverseListButton.TabIndex = 20;
      this.reverseListButton.Text = "Reverse!";
      this.reverseListButton.UseVisualStyleBackColor = true;
      this.reverseListButton.Click += new System.EventHandler(this.OnReverseListButton);
      // 
      // analyzeButton
      // 
      this.analyzeButton.Location = new System.Drawing.Point(18, 5);
      this.analyzeButton.Name = "analyzeButton";
      this.analyzeButton.Size = new System.Drawing.Size(132, 23);
      this.analyzeButton.TabIndex = 23;
      this.analyzeButton.Text = "Area Analysis";
      this.analyzeButton.UseVisualStyleBackColor = true;
      this.analyzeButton.Click += new System.EventHandler(this.AnalyzeButton_Click);
      // 
      // liveCameraButton
      // 
      this.liveCameraButton.Location = new System.Drawing.Point(5, 32);
      this.liveCameraButton.Name = "liveCameraButton";
      this.liveCameraButton.Size = new System.Drawing.Size(82, 23);
      this.liveCameraButton.TabIndex = 24;
      this.liveCameraButton.Text = "Snapshot";
      this.liveCameraButton.UseVisualStyleBackColor = true;
      this.liveCameraButton.Click += new System.EventHandler(this.LiveCameraButton_Click);
      // 
      // presetButton
      // 
      this.presetButton.Location = new System.Drawing.Point(5, 60);
      this.presetButton.Name = "presetButton";
      this.presetButton.Size = new System.Drawing.Size(82, 23);
      this.presetButton.TabIndex = 31;
      this.presetButton.Text = "Go to Preset";
      this.presetButton.UseVisualStyleBackColor = true;
      this.presetButton.Click += new System.EventHandler(this.PresetButton_Click);
      // 
      // LiveOnDemandGroup
      // 
      this.LiveOnDemandGroup.Anchor = System.Windows.Forms.AnchorStyles.Left;
      this.LiveOnDemandGroup.BackColor = System.Drawing.SystemColors.ControlDark;
      this.LiveOnDemandGroup.Controls.Add(this.PresetsCombo);
      this.LiveOnDemandGroup.Controls.Add(this.liveCheck);
      this.LiveOnDemandGroup.Controls.Add(this.presetButton);
      this.LiveOnDemandGroup.Controls.Add(this.camZoomOut);
      this.LiveOnDemandGroup.Controls.Add(this.camZoomIn);
      this.LiveOnDemandGroup.Controls.Add(this.camDownButton);
      this.LiveOnDemandGroup.Controls.Add(this.camRightButton);
      this.LiveOnDemandGroup.Controls.Add(this.liveCameraButton);
      this.LiveOnDemandGroup.Controls.Add(this.camLeftButton);
      this.LiveOnDemandGroup.Controls.Add(this.camUpButton);
      this.LiveOnDemandGroup.Location = new System.Drawing.Point(1007, 5);
      this.LiveOnDemandGroup.Name = "LiveOnDemandGroup";
      this.LiveOnDemandGroup.Size = new System.Drawing.Size(273, 113);
      this.LiveOnDemandGroup.TabIndex = 33;
      this.LiveOnDemandGroup.TabStop = false;
      // 
      // PresetsCombo
      // 
      this.PresetsCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.PresetsCombo.FormattingEnabled = true;
      this.PresetsCombo.Location = new System.Drawing.Point(88, 60);
      this.PresetsCombo.Name = "PresetsCombo";
      this.PresetsCombo.Size = new System.Drawing.Size(96, 23);
      this.PresetsCombo.TabIndex = 34;
      // 
      // liveCheck
      // 
      this.liveCheck.Appearance = System.Windows.Forms.Appearance.Button;
      this.liveCheck.BackColor = System.Drawing.SystemColors.Control;
      this.liveCheck.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
      this.liveCheck.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.liveCheck.Location = new System.Drawing.Point(88, 31);
      this.liveCheck.Name = "liveCheck";
      this.liveCheck.Size = new System.Drawing.Size(96, 25);
      this.liveCheck.TabIndex = 33;
      this.liveCheck.Text = "Video";
      this.liveCheck.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      this.liveCheck.UseVisualStyleBackColor = false;
      this.liveCheck.CheckedChanged += new System.EventHandler(this.LiveCheck_CheckedChanged);
      // 
      // camZoomOut
      // 
      this.camZoomOut.Image = ((System.Drawing.Image)(resources.GetObject("camZoomOut.Image")));
      this.camZoomOut.Location = new System.Drawing.Point(188, 73);
      this.camZoomOut.Name = "camZoomOut";
      this.camZoomOut.Size = new System.Drawing.Size(25, 25);
      this.camZoomOut.TabIndex = 30;
      this.camZoomOut.UseVisualStyleBackColor = true;
      this.camZoomOut.Click += new System.EventHandler(this.CamZoomOut_Click);
      // 
      // camZoomIn
      // 
      this.camZoomIn.Image = ((System.Drawing.Image)(resources.GetObject("camZoomIn.Image")));
      this.camZoomIn.Location = new System.Drawing.Point(242, 23);
      this.camZoomIn.Name = "camZoomIn";
      this.camZoomIn.Size = new System.Drawing.Size(25, 25);
      this.camZoomIn.TabIndex = 29;
      this.camZoomIn.UseVisualStyleBackColor = true;
      this.camZoomIn.Click += new System.EventHandler(this.ZoomInButton_Click);
      // 
      // camDownButton
      // 
      this.camDownButton.Image = ((System.Drawing.Image)(resources.GetObject("camDownButton.Image")));
      this.camDownButton.Location = new System.Drawing.Point(216, 72);
      this.camDownButton.Name = "camDownButton";
      this.camDownButton.Size = new System.Drawing.Size(25, 25);
      this.camDownButton.TabIndex = 26;
      this.camDownButton.UseVisualStyleBackColor = true;
      this.camDownButton.Click += new System.EventHandler(this.CamDownButton_Click);
      // 
      // camRightButton
      // 
      this.camRightButton.Image = ((System.Drawing.Image)(resources.GetObject("camRightButton.Image")));
      this.camRightButton.Location = new System.Drawing.Point(242, 48);
      this.camRightButton.Name = "camRightButton";
      this.camRightButton.Size = new System.Drawing.Size(25, 25);
      this.camRightButton.TabIndex = 28;
      this.camRightButton.UseVisualStyleBackColor = true;
      this.camRightButton.Click += new System.EventHandler(this.CamRightButton_Click);
      // 
      // camLeftButton
      // 
      this.camLeftButton.Image = ((System.Drawing.Image)(resources.GetObject("camLeftButton.Image")));
      this.camLeftButton.Location = new System.Drawing.Point(188, 48);
      this.camLeftButton.Name = "camLeftButton";
      this.camLeftButton.Size = new System.Drawing.Size(25, 25);
      this.camLeftButton.TabIndex = 27;
      this.camLeftButton.UseVisualStyleBackColor = true;
      this.camLeftButton.Click += new System.EventHandler(this.CamLeftButton_Click);
      // 
      // camUpButton
      // 
      this.camUpButton.Image = ((System.Drawing.Image)(resources.GetObject("camUpButton.Image")));
      this.camUpButton.Location = new System.Drawing.Point(216, 26);
      this.camUpButton.Name = "camUpButton";
      this.camUpButton.Size = new System.Drawing.Size(25, 25);
      this.camUpButton.TabIndex = 25;
      this.camUpButton.UseVisualStyleBackColor = true;
      this.camUpButton.Click += new System.EventHandler(this.CamUpButton_Click);
      // 
      // refreshButton
      // 
      this.refreshButton.Location = new System.Drawing.Point(3, 38);
      this.refreshButton.Name = "refreshButton";
      this.refreshButton.Size = new System.Drawing.Size(95, 23);
      this.refreshButton.TabIndex = 33;
      this.refreshButton.Text = "Refresh";
      this.refreshButton.UseVisualStyleBackColor = true;
      this.refreshButton.Click += new System.EventHandler(this.Refresh_Click);
      // 
      // label8
      // 
      this.label8.AutoSize = true;
      this.label8.Location = new System.Drawing.Point(5, 80);
      this.label8.Name = "label8";
      this.label8.Size = new System.Drawing.Size(59, 15);
      this.label8.TabIndex = 35;
      this.label8.Text = "CPU Load";
      // 
      // cameraCombo
      // 
      this.cameraCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cameraCombo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.cameraCombo.FormattingEnabled = true;
      this.cameraCombo.Location = new System.Drawing.Point(3, 8);
      this.cameraCombo.Name = "cameraCombo";
      this.cameraCombo.Size = new System.Drawing.Size(95, 21);
      this.cameraCombo.TabIndex = 37;
      this.cameraCombo.SelectedIndexChanged += new System.EventHandler(this.cameraCombo_SelectedIndexChanged);
      this.cameraCombo.SelectionChangeCommitted += new System.EventHandler(this.OnCameraSelected);
      // 
      // ToolsPanel
      // 
      this.ToolsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.ToolsPanel.AutoScroll = true;
      this.ToolsPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.ToolsPanel.Controls.Add(this.panel4);
      this.ToolsPanel.Controls.Add(this.panel3);
      this.ToolsPanel.Controls.Add(this.panel2);
      this.ToolsPanel.Controls.Add(this.panel1);
      this.ToolsPanel.Controls.Add(this.timeLine);
      this.ToolsPanel.Controls.Add(this.objectListView);
      this.ToolsPanel.Controls.Add(this.LiveOnDemandGroup);
      this.ToolsPanel.Location = new System.Drawing.Point(-1, 32);
      this.ToolsPanel.Name = "ToolsPanel";
      this.ToolsPanel.Size = new System.Drawing.Size(1288, 153);
      this.ToolsPanel.TabIndex = 38;
      // 
      // panel4
      // 
      this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.panel4.Controls.Add(this.FullAnalysisButton);
      this.panel4.Controls.Add(this.analyzeButton);
      this.panel4.Location = new System.Drawing.Point(418, 84);
      this.panel4.Name = "panel4";
      this.panel4.Size = new System.Drawing.Size(318, 34);
      this.panel4.TabIndex = 51;
      // 
      // FullAnalysisButton
      // 
      this.FullAnalysisButton.Location = new System.Drawing.Point(166, 5);
      this.FullAnalysisButton.Name = "FullAnalysisButton";
      this.FullAnalysisButton.Size = new System.Drawing.Size(132, 23);
      this.FullAnalysisButton.TabIndex = 48;
      this.FullAnalysisButton.Text = "Full Analysis";
      this.FullAnalysisButton.UseVisualStyleBackColor = true;
      this.FullAnalysisButton.Click += new System.EventHandler(this.FullAnalysisButton_Click);
      // 
      // panel3
      // 
      this.panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
      this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.panel3.Controls.Add(this.label2);
      this.panel3.Controls.Add(this.motionOnlyCheckbox);
      this.panel3.Controls.Add(this.goToFileButton);
      this.panel3.Controls.Add(this.buttonLeft);
      this.panel3.Controls.Add(this.buttonRight);
      this.panel3.Controls.Add(this.fileNumberUpDown);
      this.panel3.Controls.Add(this.goToFileTextBox);
      this.panel3.Controls.Add(this.label5);
      this.panel3.Controls.Add(this.goToFileNameButton);
      this.panel3.Location = new System.Drawing.Point(418, 5);
      this.panel3.Name = "panel3";
      this.panel3.Size = new System.Drawing.Size(318, 69);
      this.panel3.TabIndex = 50;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(14, 39);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(14, 15);
      this.label2.TabIndex = 40;
      this.label2.Text = "#";
      // 
      // motionOnlyCheckbox
      // 
      this.motionOnlyCheckbox.Appearance = System.Windows.Forms.Appearance.Button;
      this.motionOnlyCheckbox.AutoSize = true;
      this.motionOnlyCheckbox.Location = new System.Drawing.Point(251, 34);
      this.motionOnlyCheckbox.Name = "motionOnlyCheckbox";
      this.motionOnlyCheckbox.Size = new System.Drawing.Size(59, 25);
      this.motionOnlyCheckbox.TabIndex = 39;
      this.motionOnlyCheckbox.Text = "Motion!";
      this.motionOnlyCheckbox.UseVisualStyleBackColor = true;
      this.motionOnlyCheckbox.CheckedChanged += new System.EventHandler(this.MotionOnlyCheckbox_CheckedChanged);
      this.motionOnlyCheckbox.CheckStateChanged += new System.EventHandler(this.OnMotionCheckChanged);
      // 
      // buttonLeft
      // 
      this.buttonLeft.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
      this.buttonLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.buttonLeft.Image = ((System.Drawing.Image)(resources.GetObject("buttonLeft.Image")));
      this.buttonLeft.Location = new System.Drawing.Point(174, 35);
      this.buttonLeft.Name = "buttonLeft";
      this.buttonLeft.Size = new System.Drawing.Size(31, 23);
      this.buttonLeft.TabIndex = 2;
      this.buttonLeft.UseVisualStyleBackColor = true;
      this.buttonLeft.Click += new System.EventHandler(this.ButtonLeft_Click);
      // 
      // buttonRight
      // 
      this.buttonRight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
      this.buttonRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.buttonRight.Image = ((System.Drawing.Image)(resources.GetObject("buttonRight.Image")));
      this.buttonRight.Location = new System.Drawing.Point(212, 35);
      this.buttonRight.Name = "buttonRight";
      this.buttonRight.Size = new System.Drawing.Size(31, 23);
      this.buttonRight.TabIndex = 1;
      this.buttonRight.UseVisualStyleBackColor = true;
      this.buttonRight.Click += new System.EventHandler(this.ButtonRight_Click);
      // 
      // panel2
      // 
      this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.panel2.Controls.Add(this.label13);
      this.panel2.Controls.Add(this.label8);
      this.panel2.Controls.Add(this.FPSProgress);
      this.panel2.Controls.Add(this.cpuProgress);
      this.panel2.Controls.Add(this.label15);
      this.panel2.Controls.Add(this.AIProgressBar);
      this.panel2.Location = new System.Drawing.Point(852, 5);
      this.panel2.Name = "panel2";
      this.panel2.Size = new System.Drawing.Size(152, 113);
      this.panel2.TabIndex = 49;
      // 
      // label13
      // 
      this.label13.AutoSize = true;
      this.label13.Location = new System.Drawing.Point(1, 16);
      this.label13.Name = "label13";
      this.label13.Size = new System.Drawing.Size(69, 15);
      this.label13.TabIndex = 41;
      this.label13.Text = "Frame Time";
      // 
      // FPSProgress
      // 
      this.FPSProgress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.FPSProgress.Location = new System.Drawing.Point(75, 16);
      this.FPSProgress.Name = "FPSProgress";
      this.FPSProgress.Size = new System.Drawing.Size(73, 15);
      this.FPSProgress.TabIndex = 42;
      this.FPSProgress.Load += new System.EventHandler(this.EnhancedProgressBar1_Load);
      // 
      // cpuProgress
      // 
      this.cpuProgress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.cpuProgress.Location = new System.Drawing.Point(74, 80);
      this.cpuProgress.Name = "cpuProgress";
      this.cpuProgress.Size = new System.Drawing.Size(73, 15);
      this.cpuProgress.TabIndex = 43;
      // 
      // label15
      // 
      this.label15.AutoSize = true;
      this.label15.Location = new System.Drawing.Point(17, 48);
      this.label15.Name = "label15";
      this.label15.Size = new System.Drawing.Size(47, 15);
      this.label15.TabIndex = 46;
      this.label15.Text = "AI Time";
      // 
      // AIProgressBar
      // 
      this.AIProgressBar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.AIProgressBar.Location = new System.Drawing.Point(75, 48);
      this.AIProgressBar.Name = "AIProgressBar";
      this.AIProgressBar.Size = new System.Drawing.Size(73, 15);
      this.AIProgressBar.TabIndex = 45;
      // 
      // panel1
      // 
      this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.panel1.Controls.Add(this.reverseListButton);
      this.panel1.Controls.Add(this.refreshButton);
      this.panel1.Controls.Add(this.cameraCombo);
      this.panel1.Location = new System.Drawing.Point(743, 5);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(103, 113);
      this.panel1.TabIndex = 48;
      // 
      // timeLine
      // 
      this.timeLine.Anchor = System.Windows.Forms.AnchorStyles.Left;
      this.timeLine.AutoSize = false;
      this.timeLine.BackColor = System.Drawing.SystemColors.ControlDark;
      this.timeLine.Location = new System.Drawing.Point(5, 127);
      this.timeLine.Maximum = 1000000;
      this.timeLine.Name = "timeLine";
      this.timeLine.Pause = true;
      this.timeLine.Size = new System.Drawing.Size(1280, 20);
      this.timeLine.TabIndex = 41;
      this.timeLine.TickStyle = System.Windows.Forms.TickStyle.None;
      this.timeLine.ValueChanged += new System.EventHandler(this.LocationTrackBar_ValueChanged);
      this.timeLine.KeyUp += new System.Windows.Forms.KeyEventHandler(this.OnTimelineKeyUp);
      // 
      // mainPanel
      // 
      this.mainPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.mainPanel.BackColor = System.Drawing.SystemColors.Control;
      this.mainPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
      this.mainPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.mainPanel.Controls.Add(this.picturePanel);
      this.mainPanel.Controls.Add(this.StatusPanel);
      this.mainPanel.Controls.Add(this.ToolsPanel);
      this.mainPanel.Location = new System.Drawing.Point(1, 23);
      this.mainPanel.Name = "mainPanel";
      this.mainPanel.Size = new System.Drawing.Size(1302, 1166);
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
      this.picturePanel.Location = new System.Drawing.Point(2, 189);
      this.picturePanel.Name = "picturePanel";
      this.picturePanel.Size = new System.Drawing.Size(1288, 970);
      this.picturePanel.TabIndex = 39;
      // 
      // pictureImage
      // 
      this.pictureImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
      this.pictureImage.ErrorImage = ((System.Drawing.Image)(resources.GetObject("pictureImage.ErrorImage")));
      this.pictureImage.GridsSelected = null;
      this.pictureImage.Location = new System.Drawing.Point(0, 0);
      this.pictureImage.Name = "pictureImage";
      this.pictureImage.Size = new System.Drawing.Size(1280, 960);
      this.pictureImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
      this.pictureImage.TabIndex = 0;
      this.pictureImage.TabStop = false;
      this.pictureImage.SizeChanged += new System.EventHandler(this.OnSizeChanged);
      this.pictureImage.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnMouseDown);
      this.pictureImage.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OnMouseMove);
      this.pictureImage.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnMouseUp);
      // 
      // StatusPanel
      // 
      this.StatusPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.StatusPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.StatusPanel.Controls.Add(this.numberOfImagesLabel);
      this.StatusPanel.Controls.Add(this.YResLabel);
      this.StatusPanel.Controls.Add(this.label10);
      this.StatusPanel.Controls.Add(this.AIStatus);
      this.StatusPanel.Controls.Add(this.numberOfFilesTextBox);
      this.StatusPanel.Controls.Add(this.label12);
      this.StatusPanel.Controls.Add(this.label1);
      this.StatusPanel.Controls.Add(this.yPosLabel);
      this.StatusPanel.Controls.Add(this.XResLabel);
      this.StatusPanel.Controls.Add(this.label7);
      this.StatusPanel.Controls.Add(this.xPosLabel);
      this.StatusPanel.Controls.Add(this.label14);
      this.StatusPanel.Controls.Add(this.label6);
      this.StatusPanel.Controls.Add(this.label11);
      this.StatusPanel.Location = new System.Drawing.Point(2, 4);
      this.StatusPanel.Name = "StatusPanel";
      this.StatusPanel.Size = new System.Drawing.Size(1288, 24);
      this.StatusPanel.TabIndex = 40;
      // 
      // numberOfImagesLabel
      // 
      this.numberOfImagesLabel.AutoSize = true;
      this.numberOfImagesLabel.BackColor = System.Drawing.SystemColors.InactiveCaption;
      this.numberOfImagesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.numberOfImagesLabel.Location = new System.Drawing.Point(1080, 3);
      this.numberOfImagesLabel.Name = "numberOfImagesLabel";
      this.numberOfImagesLabel.Size = new System.Drawing.Size(35, 15);
      this.numberOfImagesLabel.TabIndex = 40;
      this.numberOfImagesLabel.Text = "0     ";
      // 
      // YResLabel
      // 
      this.YResLabel.AutoSize = true;
      this.YResLabel.BackColor = System.Drawing.SystemColors.InactiveCaption;
      this.YResLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.YResLabel.Location = new System.Drawing.Point(348, 3);
      this.YResLabel.Name = "YResLabel";
      this.YResLabel.Size = new System.Drawing.Size(39, 15);
      this.YResLabel.TabIndex = 6;
      this.YResLabel.Text = "1920";
      this.YResLabel.Click += new System.EventHandler(this.YResLabel_Click);
      // 
      // label10
      // 
      this.label10.BackColor = System.Drawing.SystemColors.InactiveCaption;
      this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.label10.Location = new System.Drawing.Point(891, 3);
      this.label10.Name = "label10";
      this.label10.Size = new System.Drawing.Size(180, 15);
      this.label10.TabIndex = 39;
      this.label10.Text = "Number of Images Processed: ";
      // 
      // AIStatus
      // 
      this.AIStatus.AutoSize = true;
      this.AIStatus.BackColor = System.Drawing.Color.LightGreen;
      this.AIStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.AIStatus.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
      this.AIStatus.Location = new System.Drawing.Point(78, 3);
      this.AIStatus.Name = "AIStatus";
      this.AIStatus.Size = new System.Drawing.Size(75, 15);
      this.AIStatus.TabIndex = 6;
      this.AIStatus.Text = "Connected";
      // 
      // label12
      // 
      this.label12.AutoSize = true;
      this.label12.BackColor = System.Drawing.SystemColors.InactiveCaption;
      this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.label12.Location = new System.Drawing.Point(298, 3);
      this.label12.Name = "label12";
      this.label12.Size = new System.Drawing.Size(44, 15);
      this.label12.TabIndex = 6;
      this.label12.Text = "Y Res";
      // 
      // XResLabel
      // 
      this.XResLabel.AutoSize = true;
      this.XResLabel.BackColor = System.Drawing.SystemColors.InactiveCaption;
      this.XResLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.XResLabel.Location = new System.Drawing.Point(247, 3);
      this.XResLabel.Name = "XResLabel";
      this.XResLabel.Size = new System.Drawing.Size(39, 15);
      this.XResLabel.TabIndex = 6;
      this.XResLabel.Text = "2560";
      // 
      // label14
      // 
      this.label14.AutoSize = true;
      this.label14.BackColor = System.Drawing.SystemColors.InactiveCaption;
      this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.label14.Location = new System.Drawing.Point(9, 3);
      this.label14.Name = "label14";
      this.label14.Size = new System.Drawing.Size(63, 15);
      this.label14.TabIndex = 42;
      this.label14.Text = "AI Status";
      // 
      // label11
      // 
      this.label11.AutoSize = true;
      this.label11.BackColor = System.Drawing.SystemColors.InactiveCaption;
      this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.label11.Location = new System.Drawing.Point(196, 3);
      this.label11.Name = "label11";
      this.label11.Size = new System.Drawing.Size(45, 15);
      this.label11.TabIndex = 5;
      this.label11.Text = "X Res";
      // 
      // xTestToolStripMenuItem
      // 
      this.xTestToolStripMenuItem.Name = "xTestToolStripMenuItem";
      this.xTestToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
      // 
      // menuStrip2
      // 
      this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem1,
            this.showToolStripMenuItem1,
            this.AreasOfInterestToolStripMenuItem1,
            this.cleanupToolStripMenuItem,
            this.toolsToolStripMenuItem1,
            this.helpToolStripMenuItem1});
      this.menuStrip2.Location = new System.Drawing.Point(0, 0);
      this.menuStrip2.Name = "menuStrip2";
      this.menuStrip2.Size = new System.Drawing.Size(1306, 24);
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
      this.showToolStripMenuItem1.CheckOnClick = true;
      this.showToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showObjectRectanglesToolStripMenuItem,
            this.showAreasOfInterestToolStripMenuItem,
            this.pictureDisplayOptionToolStripMenuItem});
      this.showToolStripMenuItem1.Name = "showToolStripMenuItem1";
      this.showToolStripMenuItem1.Size = new System.Drawing.Size(44, 20);
      this.showToolStripMenuItem1.Text = "&View";
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
      this.showAreasOfInterestToolStripMenuItem.Size = new System.Drawing.Size(241, 22);
      this.showAreasOfInterestToolStripMenuItem.Text = "Show Areas of Interest";
      this.showAreasOfInterestToolStripMenuItem.CheckedChanged += new System.EventHandler(this.ShowAreasOfInterestCheckChanged);
      this.showAreasOfInterestToolStripMenuItem.Click += new System.EventHandler(this.AreasOfInterestToolStripMenuItem_Click);
      // 
      // pictureDisplayOptionToolStripMenuItem
      // 
      this.pictureDisplayOptionToolStripMenuItem.Name = "pictureDisplayOptionToolStripMenuItem";
      this.pictureDisplayOptionToolStripMenuItem.Size = new System.Drawing.Size(241, 22);
      this.pictureDisplayOptionToolStripMenuItem.Text = "Picture Display Option";
      this.pictureDisplayOptionToolStripMenuItem.Click += new System.EventHandler(this.OnPictureDisplayOption);
      // 
      // AreasOfInterestToolStripMenuItem1
      // 
      this.AreasOfInterestToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editAreaToolStripMenuItem,
            this.createAreaToolStripMenuItem});
      this.AreasOfInterestToolStripMenuItem1.Name = "AreasOfInterestToolStripMenuItem1";
      this.AreasOfInterestToolStripMenuItem1.Size = new System.Drawing.Size(104, 20);
      this.AreasOfInterestToolStripMenuItem1.Text = "Areas of Interest";
      this.AreasOfInterestToolStripMenuItem1.Click += new System.EventHandler(this.EditAreasOfInterestToolStripMenuItem_Click);
      // 
      // editAreaToolStripMenuItem
      // 
      this.editAreaToolStripMenuItem.Name = "editAreaToolStripMenuItem";
      this.editAreaToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
      this.editAreaToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
      this.editAreaToolStripMenuItem.Text = "Edit Area";
      this.editAreaToolStripMenuItem.Click += new System.EventHandler(this.editAreaToolStripMenuItem_Click);
      // 
      // createAreaToolStripMenuItem
      // 
      this.createAreaToolStripMenuItem.Name = "createAreaToolStripMenuItem";
      this.createAreaToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
      this.createAreaToolStripMenuItem.Text = "Create Area";
      this.createAreaToolStripMenuItem.Click += new System.EventHandler(this.createAreaToolStripMenuItem_Click);
      // 
      // cleanupToolStripMenuItem
      // 
      this.cleanupToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cleanupOldPicturesToolStripMenuItem,
            this.syncToDatabaseToolStripMenuItem});
      this.cleanupToolStripMenuItem.Name = "cleanupToolStripMenuItem";
      this.cleanupToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
      this.cleanupToolStripMenuItem.Text = "Cleanup";
      // 
      // cleanupOldPicturesToolStripMenuItem
      // 
      this.cleanupOldPicturesToolStripMenuItem.Name = "cleanupOldPicturesToolStripMenuItem";
      this.cleanupOldPicturesToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
      this.cleanupOldPicturesToolStripMenuItem.Text = "Cleanup Old Pictures";
      this.cleanupOldPicturesToolStripMenuItem.Click += new System.EventHandler(this.CleanupButton_Click);
      // 
      // syncToDatabaseToolStripMenuItem
      // 
      this.syncToDatabaseToolStripMenuItem.CheckOnClick = true;
      this.syncToDatabaseToolStripMenuItem.Name = "syncToDatabaseToolStripMenuItem";
      this.syncToDatabaseToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
      this.syncToDatabaseToolStripMenuItem.Text = "Sync Motion To Database";
      this.syncToDatabaseToolStripMenuItem.Click += new System.EventHandler(this.SyncToDatabase);
      // 
      // toolsToolStripMenuItem1
      // 
      this.toolsToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.applicationSettingsToolStripMenuItem,
            this.cameraSettingsToolStripMenuItem1,
            this.ImageCaptureMenuItem,
            this.outgoingEmailServerToolStripMenuItem1,
            this.addEditEmailAddressesToolStripMenuItem1,
            this.mQTTSettingsToolStripMenuItem,
            this.analysisSettingsToolStripMenuItem,
            this.aiAlertMenuItem,
            this.testImagesToolStripMenuItem,
            this.startRestartAIToolStripMenuItem});
      this.toolsToolStripMenuItem1.Name = "toolsToolStripMenuItem1";
      this.toolsToolStripMenuItem1.Size = new System.Drawing.Size(46, 20);
      this.toolsToolStripMenuItem1.Text = "&Tools";
      // 
      // applicationSettingsToolStripMenuItem
      // 
      this.applicationSettingsToolStripMenuItem.Name = "applicationSettingsToolStripMenuItem";
      this.applicationSettingsToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
      this.applicationSettingsToolStripMenuItem.Text = "Application Settings";
      this.applicationSettingsToolStripMenuItem.Click += new System.EventHandler(this.SettingsToolStripMenuItem_Click);
      // 
      // cameraSettingsToolStripMenuItem1
      // 
      this.cameraSettingsToolStripMenuItem1.Name = "cameraSettingsToolStripMenuItem1";
      this.cameraSettingsToolStripMenuItem1.Size = new System.Drawing.Size(234, 22);
      this.cameraSettingsToolStripMenuItem1.Text = "Camera Settings";
      this.cameraSettingsToolStripMenuItem1.Click += new System.EventHandler(this.CameraSettingsToolStripMenuItem_Click);
      // 
      // ImageCaptureMenuItem
      // 
      this.ImageCaptureMenuItem.Name = "ImageCaptureMenuItem";
      this.ImageCaptureMenuItem.Size = new System.Drawing.Size(234, 22);
      this.ImageCaptureMenuItem.Text = "Global Image Capture Settings";
      this.ImageCaptureMenuItem.Click += new System.EventHandler(this.ImageCaptureMenuItem_Click);
      // 
      // outgoingEmailServerToolStripMenuItem1
      // 
      this.outgoingEmailServerToolStripMenuItem1.Name = "outgoingEmailServerToolStripMenuItem1";
      this.outgoingEmailServerToolStripMenuItem1.Size = new System.Drawing.Size(234, 22);
      this.outgoingEmailServerToolStripMenuItem1.Text = "Outgoing Email Server";
      this.outgoingEmailServerToolStripMenuItem1.Click += new System.EventHandler(this.OutgoingEmailServerToolStripMenuItem_Click);
      // 
      // addEditEmailAddressesToolStripMenuItem1
      // 
      this.addEditEmailAddressesToolStripMenuItem1.Name = "addEditEmailAddressesToolStripMenuItem1";
      this.addEditEmailAddressesToolStripMenuItem1.Size = new System.Drawing.Size(234, 22);
      this.addEditEmailAddressesToolStripMenuItem1.Text = "Add/Edit Email Addresses";
      this.addEditEmailAddressesToolStripMenuItem1.Click += new System.EventHandler(this.AddEditEmailAddressesToolStripMenuItem_Click);
      // 
      // mQTTSettingsToolStripMenuItem
      // 
      this.mQTTSettingsToolStripMenuItem.Name = "mQTTSettingsToolStripMenuItem";
      this.mQTTSettingsToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
      this.mQTTSettingsToolStripMenuItem.Text = "MQTT Settings";
      this.mQTTSettingsToolStripMenuItem.Click += new System.EventHandler(this.MQTTSettingsToolStripMenuItem_Click);
      // 
      // analysisSettingsToolStripMenuItem
      // 
      this.analysisSettingsToolStripMenuItem.Name = "analysisSettingsToolStripMenuItem";
      this.analysisSettingsToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
      this.analysisSettingsToolStripMenuItem.Text = "Analysis Settings";
      this.analysisSettingsToolStripMenuItem.Click += new System.EventHandler(this.AnalysisSettingsToolStripMenuItem_Click);
      // 
      // aiAlertMenuItem
      // 
      this.aiAlertMenuItem.Name = "aiAlertMenuItem";
      this.aiAlertMenuItem.Size = new System.Drawing.Size(234, 22);
      this.aiAlertMenuItem.Text = "AI Alert Settings";
      this.aiAlertMenuItem.Click += new System.EventHandler(this.AIAlertMenuItemClicked);
      // 
      // testImagesToolStripMenuItem
      // 
      this.testImagesToolStripMenuItem.Name = "testImagesToolStripMenuItem";
      this.testImagesToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
      this.testImagesToolStripMenuItem.Text = "Test Images";
      this.testImagesToolStripMenuItem.Click += new System.EventHandler(this.TestImagesToolStripMenuItem_Click);
      // 
      // startRestartAIToolStripMenuItem
      // 
      this.startRestartAIToolStripMenuItem.Name = "startRestartAIToolStripMenuItem";
      this.startRestartAIToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
      this.startRestartAIToolStripMenuItem.Text = "Start/Restart AI";
      this.startRestartAIToolStripMenuItem.Click += new System.EventHandler(this.startRestartAIToolStripMenuItem_Click);
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
      // logDetailedInformationToolStripMenuItem
      // 
      this.logDetailedInformationToolStripMenuItem.CheckOnClick = true;
      this.logDetailedInformationToolStripMenuItem.Name = "logDetailedInformationToolStripMenuItem";
      this.logDetailedInformationToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
      this.logDetailedInformationToolStripMenuItem.Text = "Log Detailed Information";
      this.logDetailedInformationToolStripMenuItem.Click += new System.EventHandler(this.LogDetailedInformationToolStripMenuItem_Click);
      // 
      // deleteLogFileToolStripMenuItem
      // 
      this.deleteLogFileToolStripMenuItem.Name = "deleteLogFileToolStripMenuItem";
      this.deleteLogFileToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
      this.deleteLogFileToolStripMenuItem.Text = "Delete Log File";
      this.deleteLogFileToolStripMenuItem.Click += new System.EventHandler(this.DeleteLogFileToolStripMenuItem_Click);
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
      // MainWindow
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
      this.BackColor = System.Drawing.SystemColors.Control;
      this.ClientSize = new System.Drawing.Size(1306, 1193);
      this.Controls.Add(this.mainPanel);
      this.Controls.Add(this.menuStrip2);
      this.DoubleBuffered = true;
      this.MainMenuStrip = this.menuStrip2;
      this.Name = "MainWindow";
      this.Text = "On Guard";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnClosing);
      this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OnClosed);
      this.Load += new System.EventHandler(this.Form1_Load);
      this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnKeyDown);
      this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.OnKeyUp);
      this.Resize += new System.EventHandler(this.OnResize);
      ((System.ComponentModel.ISupportInitialize)(this.fileNumberUpDown)).EndInit();
      this.LiveOnDemandGroup.ResumeLayout(false);
      this.ToolsPanel.ResumeLayout(false);
      this.panel4.ResumeLayout(false);
      this.panel3.ResumeLayout(false);
      this.panel3.PerformLayout();
      this.panel2.ResumeLayout(false);
      this.panel2.PerformLayout();
      this.panel1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.timeLine)).EndInit();
      this.mainPanel.ResumeLayout(false);
      this.picturePanel.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.pictureImage)).EndInit();
      this.StatusPanel.ResumeLayout(false);
      this.StatusPanel.PerformLayout();
      this.menuStrip2.ResumeLayout(false);
      this.menuStrip2.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private CameraImage pictureImage;
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
    private System.Windows.Forms.NumericUpDown fileNumberUpDown;
    private System.Windows.Forms.Button goToFileButton;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.TextBox goToFileTextBox;
    private System.Windows.Forms.Button goToFileNameButton;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.Label xPosLabel;
    private System.Windows.Forms.Label yPosLabel;
    private System.Windows.Forms.Button reverseListButton;
    private System.Windows.Forms.Button analyzeButton;
    private System.Windows.Forms.Button liveCameraButton;
    private System.Windows.Forms.Button camUpButton;
    private System.Windows.Forms.Button camDownButton;
    private System.Windows.Forms.Button camLeftButton;
    private System.Windows.Forms.Button camRightButton;
    private System.Windows.Forms.Button camZoomIn;
    private System.Windows.Forms.Button camZoomOut;
    private System.Windows.Forms.Button presetButton;
    private System.Windows.Forms.GroupBox LiveOnDemandGroup;
    private System.Windows.Forms.Button refreshButton;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.ComboBox cameraCombo;
    private System.Windows.Forms.Panel ToolsPanel;
    private System.Windows.Forms.Panel mainPanel;
    private System.Windows.Forms.ToolStripMenuItem xTestToolStripMenuItem;
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
    private System.Windows.Forms.ToolStripMenuItem AreasOfInterestToolStripMenuItem1;
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
    private System.Windows.Forms.ToolStripMenuItem testImagesToolStripMenuItem;
    private System.Windows.Forms.Label label13;
    private EnhancedProgressBar FPSProgress;
    private EnhancedProgressBar cpuProgress;
    private System.Windows.Forms.ToolStripMenuItem analysisSettingsToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem aiAlertMenuItem;
    private System.Windows.Forms.Label label14;
    private System.Windows.Forms.Label AIStatus;
    private System.Windows.Forms.Panel StatusPanel;
    private TimeLine timeLine;
    private System.Windows.Forms.ToolStripMenuItem ImageCaptureMenuItem;
    private System.Windows.Forms.ComboBox PresetsCombo;
    private System.Windows.Forms.ToolStripMenuItem startRestartAIToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem editAreaToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem createAreaToolStripMenuItem;
    private System.Windows.Forms.Label label15;
    private EnhancedProgressBar AIProgressBar;
    private System.Windows.Forms.ToolStripMenuItem cleanupToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem cleanupOldPicturesToolStripMenuItem;
    private System.Windows.Forms.Panel panel4;
    private System.Windows.Forms.Button FullAnalysisButton;
    private System.Windows.Forms.Panel panel3;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Panel panel2;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.ToolStripMenuItem syncToDatabaseToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem pictureDisplayOptionToolStripMenuItem;
  }
}

