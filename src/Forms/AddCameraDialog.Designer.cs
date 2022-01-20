namespace OnGuardCore
{
  partial class AddCameraDialog
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddCameraDialog));
      this.okButton = new System.Windows.Forms.Button();
      this.cancelButton = new System.Windows.Forms.Button();
      this.label18 = new System.Windows.Forms.Label();
      this.tabTriggered = new System.Windows.Forms.TabPage();
      this.CameraTriggerPanel = new System.Windows.Forms.Panel();
      this.triggerPrefixText = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.label14 = new System.Windows.Forms.Label();
      this.CameraTriggeredHelpButton = new System.Windows.Forms.Button();
      this.label16 = new System.Windows.Forms.Label();
      this.label15 = new System.Windows.Forms.Label();
      this.NoRecordNumeric = new System.Windows.Forms.NumericUpDown();
      this.RecordFrameIntervalNumeric = new System.Windows.Forms.NumericUpDown();
      this.label13 = new System.Windows.Forms.Label();
      this.label12 = new System.Windows.Forms.Label();
      this.RecordTimeNumeric = new System.Windows.Forms.NumericUpDown();
      this.label4 = new System.Windows.Forms.Label();
      this.label11 = new System.Windows.Forms.Label();
      this.tabImage = new System.Windows.Forms.TabPage();
      this.panel1 = new System.Windows.Forms.Panel();
      this.HelpMethodButton = new System.Windows.Forms.Button();
      this.radioTrigger = new System.Windows.Forms.RadioButton();
      this.radioScanImages = new System.Windows.Forms.RadioButton();
      this.radioSoftware = new System.Windows.Forms.RadioButton();
      this.label3 = new System.Windows.Forms.Label();
      this.tabControlCameraMethod = new System.Windows.Forms.TabControl();
      this.tabPageLocation = new System.Windows.Forms.TabPage();
      this.panel4 = new System.Windows.Forms.Panel();
      this.FolderPrefixHelp = new System.Windows.Forms.Button();
      this.label17 = new System.Windows.Forms.Label();
      this.pathText = new System.Windows.Forms.TextBox();
      this.label19 = new System.Windows.Forms.Label();
      this.BrowseButton = new System.Windows.Forms.Button();
      this.label20 = new System.Windows.Forms.Label();
      this.prefixText = new System.Windows.Forms.TextBox();
      this.label21 = new System.Windows.Forms.Label();
      this.label22 = new System.Windows.Forms.Label();
      this.tabPageOnGuard = new System.Windows.Forms.TabPage();
      this.OnGuardPanel = new System.Windows.Forms.Panel();
      this.OnGuardScanHelpButton = new System.Windows.Forms.Button();
      this.label1 = new System.Windows.Forms.Label();
      this.OnlyInAreasCheckbox = new System.Windows.Forms.CheckBox();
      this.CheckIntervalNumeric = new System.Windows.Forms.NumericUpDown();
      this.label5 = new System.Windows.Forms.Label();
      this.label6 = new System.Windows.Forms.Label();
      this.tabTriggered.SuspendLayout();
      this.CameraTriggerPanel.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.NoRecordNumeric)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.RecordFrameIntervalNumeric)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.RecordTimeNumeric)).BeginInit();
      this.tabImage.SuspendLayout();
      this.panel1.SuspendLayout();
      this.tabControlCameraMethod.SuspendLayout();
      this.tabPageLocation.SuspendLayout();
      this.panel4.SuspendLayout();
      this.tabPageOnGuard.SuspendLayout();
      this.OnGuardPanel.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.CheckIntervalNumeric)).BeginInit();
      this.SuspendLayout();
      // 
      // okButton
      // 
      this.okButton.Location = new System.Drawing.Point(204, 335);
      this.okButton.Name = "okButton";
      this.okButton.Size = new System.Drawing.Size(76, 23);
      this.okButton.TabIndex = 0;
      this.okButton.Text = "OK";
      this.okButton.UseVisualStyleBackColor = true;
      this.okButton.Click += new System.EventHandler(this.OkButton_Click);
      // 
      // cancelButton
      // 
      this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.cancelButton.Location = new System.Drawing.Point(289, 335);
      this.cancelButton.Name = "cancelButton";
      this.cancelButton.Size = new System.Drawing.Size(76, 23);
      this.cancelButton.TabIndex = 1;
      this.cancelButton.Text = "Cancel";
      this.cancelButton.UseVisualStyleBackColor = true;
      this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
      // 
      // label18
      // 
      this.label18.AutoSize = true;
      this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.label18.Location = new System.Drawing.Point(160, 9);
      this.label18.Name = "label18";
      this.label18.Size = new System.Drawing.Size(125, 16);
      this.label18.TabIndex = 19;
      this.label18.Text = "Add/Edit Camera";
      // 
      // tabTriggered
      // 
      this.tabTriggered.Controls.Add(this.CameraTriggerPanel);
      this.tabTriggered.Location = new System.Drawing.Point(4, 24);
      this.tabTriggered.Name = "tabTriggered";
      this.tabTriggered.Size = new System.Drawing.Size(548, 264);
      this.tabTriggered.TabIndex = 2;
      this.tabTriggered.Text = "Camera Triggered";
      this.tabTriggered.UseVisualStyleBackColor = true;
      // 
      // CameraTriggerPanel
      // 
      this.CameraTriggerPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.CameraTriggerPanel.Controls.Add(this.triggerPrefixText);
      this.CameraTriggerPanel.Controls.Add(this.label2);
      this.CameraTriggerPanel.Controls.Add(this.label14);
      this.CameraTriggerPanel.Controls.Add(this.CameraTriggeredHelpButton);
      this.CameraTriggerPanel.Controls.Add(this.label16);
      this.CameraTriggerPanel.Controls.Add(this.label15);
      this.CameraTriggerPanel.Controls.Add(this.NoRecordNumeric);
      this.CameraTriggerPanel.Controls.Add(this.RecordFrameIntervalNumeric);
      this.CameraTriggerPanel.Controls.Add(this.label13);
      this.CameraTriggerPanel.Controls.Add(this.label12);
      this.CameraTriggerPanel.Controls.Add(this.RecordTimeNumeric);
      this.CameraTriggerPanel.Controls.Add(this.label4);
      this.CameraTriggerPanel.Controls.Add(this.label11);
      this.CameraTriggerPanel.Enabled = false;
      this.CameraTriggerPanel.Location = new System.Drawing.Point(53, 20);
      this.CameraTriggerPanel.Name = "CameraTriggerPanel";
      this.CameraTriggerPanel.Size = new System.Drawing.Size(441, 192);
      this.CameraTriggerPanel.TabIndex = 9;
      // 
      // triggerPrefixText
      // 
      this.triggerPrefixText.Location = new System.Drawing.Point(190, 36);
      this.triggerPrefixText.Name = "triggerPrefixText";
      this.triggerPrefixText.Size = new System.Drawing.Size(120, 23);
      this.triggerPrefixText.TabIndex = 23;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.label2.ForeColor = System.Drawing.Color.Red;
      this.label2.Location = new System.Drawing.Point(32, 37);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(129, 17);
      this.label2.TabIndex = 22;
      this.label2.Text = "Trigger Prefix (FTP)";
      this.label2.Click += new System.EventHandler(this.Label2_Click);
      // 
      // label14
      // 
      this.label14.AutoSize = true;
      this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.label14.Location = new System.Drawing.Point(86, 8);
      this.label14.Name = "label14";
      this.label14.Size = new System.Drawing.Size(231, 15);
      this.label14.TabIndex = 21;
      this.label14.Text = "Camera Picture Triggers Sequence";
      // 
      // CameraTriggeredHelpButton
      // 
      this.CameraTriggeredHelpButton.BackColor = System.Drawing.Color.LightGreen;
      this.CameraTriggeredHelpButton.Location = new System.Drawing.Point(335, 160);
      this.CameraTriggeredHelpButton.Name = "CameraTriggeredHelpButton";
      this.CameraTriggeredHelpButton.Size = new System.Drawing.Size(75, 23);
      this.CameraTriggeredHelpButton.TabIndex = 12;
      this.CameraTriggeredHelpButton.Text = "Help!";
      this.CameraTriggeredHelpButton.UseVisualStyleBackColor = false;
      this.CameraTriggeredHelpButton.Click += new System.EventHandler(this.CameraTriggeredHelpButton_Click);
      // 
      // label16
      // 
      this.label16.AutoSize = true;
      this.label16.Location = new System.Drawing.Point(329, 133);
      this.label16.Name = "label16";
      this.label16.Size = new System.Drawing.Size(51, 15);
      this.label16.TabIndex = 11;
      this.label16.Text = "Seconds";
      // 
      // label15
      // 
      this.label15.AutoSize = true;
      this.label15.Location = new System.Drawing.Point(33, 133);
      this.label15.Name = "label15";
      this.label15.Size = new System.Drawing.Size(128, 15);
      this.label15.TabIndex = 10;
      this.label15.Text = "Don\'t Record Again for";
      // 
      // NoRecordNumeric
      // 
      this.NoRecordNumeric.Location = new System.Drawing.Point(201, 130);
      this.NoRecordNumeric.Maximum = new decimal(new int[] {
            3600,
            0,
            0,
            0});
      this.NoRecordNumeric.Name = "NoRecordNumeric";
      this.NoRecordNumeric.Size = new System.Drawing.Size(120, 23);
      this.NoRecordNumeric.TabIndex = 9;
      this.NoRecordNumeric.Value = new decimal(new int[] {
            120,
            0,
            0,
            0});
      // 
      // RecordFrameIntervalNumeric
      // 
      this.RecordFrameIntervalNumeric.DecimalPlaces = 3;
      this.RecordFrameIntervalNumeric.Location = new System.Drawing.Point(201, 68);
      this.RecordFrameIntervalNumeric.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
      this.RecordFrameIntervalNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
      this.RecordFrameIntervalNumeric.Name = "RecordFrameIntervalNumeric";
      this.RecordFrameIntervalNumeric.Size = new System.Drawing.Size(120, 23);
      this.RecordFrameIntervalNumeric.TabIndex = 1;
      this.RecordFrameIntervalNumeric.Value = new decimal(new int[] {
            5,
            0,
            0,
            65536});
      // 
      // label13
      // 
      this.label13.AutoSize = true;
      this.label13.Location = new System.Drawing.Point(329, 101);
      this.label13.Name = "label13";
      this.label13.Size = new System.Drawing.Size(51, 15);
      this.label13.TabIndex = 8;
      this.label13.Text = "Seconds";
      // 
      // label12
      // 
      this.label12.AutoSize = true;
      this.label12.Location = new System.Drawing.Point(44, 101);
      this.label12.Name = "label12";
      this.label12.Size = new System.Drawing.Size(117, 15);
      this.label12.TabIndex = 7;
      this.label12.Text = "Stop Recording After";
      // 
      // RecordTimeNumeric
      // 
      this.RecordTimeNumeric.DecimalPlaces = 3;
      this.RecordTimeNumeric.Location = new System.Drawing.Point(201, 99);
      this.RecordTimeNumeric.Maximum = new decimal(new int[] {
            120,
            0,
            0,
            0});
      this.RecordTimeNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
      this.RecordTimeNumeric.Name = "RecordTimeNumeric";
      this.RecordTimeNumeric.Size = new System.Drawing.Size(120, 23);
      this.RecordTimeNumeric.TabIndex = 6;
      this.RecordTimeNumeric.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(11, 70);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(150, 15);
      this.label4.TabIndex = 4;
      this.label4.Text = "Record Image to Disk Every";
      // 
      // label11
      // 
      this.label11.AutoSize = true;
      this.label11.Location = new System.Drawing.Point(329, 70);
      this.label11.Name = "label11";
      this.label11.Size = new System.Drawing.Size(51, 15);
      this.label11.TabIndex = 5;
      this.label11.Text = "Seconds";
      // 
      // tabImage
      // 
      this.tabImage.Controls.Add(this.panel1);
      this.tabImage.Location = new System.Drawing.Point(4, 24);
      this.tabImage.Name = "tabImage";
      this.tabImage.Padding = new System.Windows.Forms.Padding(3);
      this.tabImage.Size = new System.Drawing.Size(548, 264);
      this.tabImage.TabIndex = 0;
      this.tabImage.Text = "Input Method";
      this.tabImage.UseVisualStyleBackColor = true;
      // 
      // panel1
      // 
      this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.panel1.Controls.Add(this.HelpMethodButton);
      this.panel1.Controls.Add(this.radioTrigger);
      this.panel1.Controls.Add(this.radioScanImages);
      this.panel1.Controls.Add(this.radioSoftware);
      this.panel1.Controls.Add(this.label3);
      this.panel1.Location = new System.Drawing.Point(97, 33);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(354, 157);
      this.panel1.TabIndex = 20;
      // 
      // HelpMethodButton
      // 
      this.HelpMethodButton.BackColor = System.Drawing.Color.LightGreen;
      this.HelpMethodButton.Location = new System.Drawing.Point(264, 124);
      this.HelpMethodButton.Name = "HelpMethodButton";
      this.HelpMethodButton.Size = new System.Drawing.Size(75, 23);
      this.HelpMethodButton.TabIndex = 24;
      this.HelpMethodButton.Text = "Help!";
      this.HelpMethodButton.UseVisualStyleBackColor = false;
      this.HelpMethodButton.Click += new System.EventHandler(this.HelpMethodButton_Click);
      // 
      // radioTrigger
      // 
      this.radioTrigger.AutoSize = true;
      this.radioTrigger.Location = new System.Drawing.Point(25, 96);
      this.radioTrigger.Name = "radioTrigger";
      this.radioTrigger.Size = new System.Drawing.Size(189, 19);
      this.radioTrigger.TabIndex = 3;
      this.radioTrigger.Text = "Camera Triggered (Usually FTP)";
      this.radioTrigger.UseVisualStyleBackColor = true;
      this.radioTrigger.CheckedChanged += new System.EventHandler(this.OnMethodChanged);
      // 
      // radioScanImages
      // 
      this.radioScanImages.AutoSize = true;
      this.radioScanImages.Location = new System.Drawing.Point(25, 68);
      this.radioScanImages.Name = "radioScanImages";
      this.radioScanImages.Size = new System.Drawing.Size(140, 19);
      this.radioScanImages.TabIndex = 2;
      this.radioScanImages.Text = "On Guard Image Scan";
      this.radioScanImages.UseVisualStyleBackColor = true;
      this.radioScanImages.CheckedChanged += new System.EventHandler(this.OnMethodChanged);
      // 
      // radioSoftware
      // 
      this.radioSoftware.AutoSize = true;
      this.radioSoftware.Checked = true;
      this.radioSoftware.Location = new System.Drawing.Point(25, 40);
      this.radioSoftware.Name = "radioSoftware";
      this.radioSoftware.Size = new System.Drawing.Size(246, 19);
      this.radioSoftware.TabIndex = 1;
      this.radioSoftware.TabStop = true;
      this.radioSoftware.Text = "Application Filtered/Saved  (Blue Iris/iSpy)";
      this.radioSoftware.UseVisualStyleBackColor = true;
      this.radioSoftware.CheckedChanged += new System.EventHandler(this.OnMethodChanged);
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.label3.Location = new System.Drawing.Point(56, 8);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(201, 15);
      this.label3.TabIndex = 20;
      this.label3.Text = "Select Image Creation Method";
      // 
      // tabControlCameraMethod
      // 
      this.tabControlCameraMethod.Controls.Add(this.tabImage);
      this.tabControlCameraMethod.Controls.Add(this.tabPageLocation);
      this.tabControlCameraMethod.Controls.Add(this.tabPageOnGuard);
      this.tabControlCameraMethod.Controls.Add(this.tabTriggered);
      this.tabControlCameraMethod.Location = new System.Drawing.Point(6, 33);
      this.tabControlCameraMethod.Name = "tabControlCameraMethod";
      this.tabControlCameraMethod.SelectedIndex = 0;
      this.tabControlCameraMethod.Size = new System.Drawing.Size(556, 292);
      this.tabControlCameraMethod.TabIndex = 3;
      // 
      // tabPageLocation
      // 
      this.tabPageLocation.Controls.Add(this.panel4);
      this.tabPageLocation.Location = new System.Drawing.Point(4, 24);
      this.tabPageLocation.Name = "tabPageLocation";
      this.tabPageLocation.Size = new System.Drawing.Size(548, 264);
      this.tabPageLocation.TabIndex = 3;
      this.tabPageLocation.Text = "Location";
      this.tabPageLocation.UseVisualStyleBackColor = true;
      // 
      // panel4
      // 
      this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.panel4.Controls.Add(this.FolderPrefixHelp);
      this.panel4.Controls.Add(this.label17);
      this.panel4.Controls.Add(this.pathText);
      this.panel4.Controls.Add(this.label19);
      this.panel4.Controls.Add(this.BrowseButton);
      this.panel4.Controls.Add(this.label20);
      this.panel4.Controls.Add(this.prefixText);
      this.panel4.Controls.Add(this.label21);
      this.panel4.Controls.Add(this.label22);
      this.panel4.Location = new System.Drawing.Point(12, 12);
      this.panel4.Name = "panel4";
      this.panel4.Size = new System.Drawing.Size(524, 238);
      this.panel4.TabIndex = 25;
      // 
      // FolderPrefixHelp
      // 
      this.FolderPrefixHelp.BackColor = System.Drawing.Color.LightGreen;
      this.FolderPrefixHelp.Location = new System.Drawing.Point(440, 207);
      this.FolderPrefixHelp.Name = "FolderPrefixHelp";
      this.FolderPrefixHelp.Size = new System.Drawing.Size(75, 23);
      this.FolderPrefixHelp.TabIndex = 29;
      this.FolderPrefixHelp.Text = "Help!";
      this.FolderPrefixHelp.UseVisualStyleBackColor = false;
      this.FolderPrefixHelp.Click += new System.EventHandler(this.FolderPrefixHelp_Click);
      // 
      // label17
      // 
      this.label17.Location = new System.Drawing.Point(17, 156);
      this.label17.Name = "label17";
      this.label17.Size = new System.Drawing.Size(498, 50);
      this.label17.TabIndex = 28;
      this.label17.Text = "For all image generation methods, it is necessary to specify the directory that O" +
    "n Guard monitors and/or places motion image files.";
      // 
      // pathText
      // 
      this.pathText.Location = new System.Drawing.Point(132, 127);
      this.pathText.Name = "pathText";
      this.pathText.Size = new System.Drawing.Size(289, 23);
      this.pathText.TabIndex = 25;
      // 
      // label19
      // 
      this.label19.AutoSize = true;
      this.label19.Location = new System.Drawing.Point(36, 131);
      this.label19.Name = "label19";
      this.label19.Size = new System.Drawing.Size(74, 15);
      this.label19.TabIndex = 26;
      this.label19.Text = "Camera Files";
      // 
      // BrowseButton
      // 
      this.BrowseButton.Location = new System.Drawing.Point(429, 123);
      this.BrowseButton.Name = "BrowseButton";
      this.BrowseButton.Size = new System.Drawing.Size(75, 23);
      this.BrowseButton.TabIndex = 27;
      this.BrowseButton.Text = "Browse";
      this.BrowseButton.UseVisualStyleBackColor = true;
      this.BrowseButton.Click += new System.EventHandler(this.BrowseButton_Click);
      // 
      // label20
      // 
      this.label20.AutoSize = true;
      this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.label20.Location = new System.Drawing.Point(181, 7);
      this.label20.Name = "label20";
      this.label20.Size = new System.Drawing.Size(199, 15);
      this.label20.TabIndex = 24;
      this.label20.Text = "Camera File Prefix and Folder";
      // 
      // prefixText
      // 
      this.prefixText.Location = new System.Drawing.Point(230, 31);
      this.prefixText.Name = "prefixText";
      this.prefixText.Size = new System.Drawing.Size(151, 23);
      this.prefixText.TabIndex = 21;
      // 
      // label21
      // 
      this.label21.Location = new System.Drawing.Point(16, 63);
      this.label21.Name = "label21";
      this.label21.Size = new System.Drawing.Size(499, 55);
      this.label21.TabIndex = 23;
      this.label21.Text = resources.GetString("label21.Text");
      // 
      // label22
      // 
      this.label22.AutoSize = true;
      this.label22.Location = new System.Drawing.Point(136, 34);
      this.label22.Name = "label22";
      this.label22.Size = new System.Drawing.Size(74, 15);
      this.label22.TabIndex = 22;
      this.label22.Text = "Prefix/Name";
      // 
      // tabPageOnGuard
      // 
      this.tabPageOnGuard.Controls.Add(this.OnGuardPanel);
      this.tabPageOnGuard.Location = new System.Drawing.Point(4, 24);
      this.tabPageOnGuard.Name = "tabPageOnGuard";
      this.tabPageOnGuard.Size = new System.Drawing.Size(548, 264);
      this.tabPageOnGuard.TabIndex = 4;
      this.tabPageOnGuard.Text = "On Guard Scan";
      this.tabPageOnGuard.UseVisualStyleBackColor = true;
      // 
      // OnGuardPanel
      // 
      this.OnGuardPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.OnGuardPanel.Controls.Add(this.OnGuardScanHelpButton);
      this.OnGuardPanel.Controls.Add(this.label1);
      this.OnGuardPanel.Controls.Add(this.OnlyInAreasCheckbox);
      this.OnGuardPanel.Controls.Add(this.CheckIntervalNumeric);
      this.OnGuardPanel.Controls.Add(this.label5);
      this.OnGuardPanel.Controls.Add(this.label6);
      this.OnGuardPanel.Enabled = false;
      this.OnGuardPanel.Location = new System.Drawing.Point(70, 42);
      this.OnGuardPanel.Name = "OnGuardPanel";
      this.OnGuardPanel.Size = new System.Drawing.Size(409, 148);
      this.OnGuardPanel.TabIndex = 0;
      // 
      // OnGuardScanHelpButton
      // 
      this.OnGuardScanHelpButton.BackColor = System.Drawing.Color.LightGreen;
      this.OnGuardScanHelpButton.Location = new System.Drawing.Point(322, 114);
      this.OnGuardScanHelpButton.Name = "OnGuardScanHelpButton";
      this.OnGuardScanHelpButton.Size = new System.Drawing.Size(75, 23);
      this.OnGuardScanHelpButton.TabIndex = 23;
      this.OnGuardScanHelpButton.Text = "Help!";
      this.OnGuardScanHelpButton.UseVisualStyleBackColor = false;
      this.OnGuardScanHelpButton.Click += new System.EventHandler(this.OnGuardScanHelpButton_Click);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.label1.Location = new System.Drawing.Point(168, 17);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(132, 15);
      this.label1.TabIndex = 22;
      this.label1.Text = "On Guard Scanning";
      // 
      // OnlyInAreasCheckbox
      // 
      this.OnlyInAreasCheckbox.AutoSize = true;
      this.OnlyInAreasCheckbox.Location = new System.Drawing.Point(27, 91);
      this.OnlyInAreasCheckbox.Name = "OnlyInAreasCheckbox";
      this.OnlyInAreasCheckbox.Size = new System.Drawing.Size(227, 19);
      this.OnlyInAreasCheckbox.TabIndex = 7;
      this.OnlyInAreasCheckbox.Text = "Only Save Pictures in Areas of Interest ";
      this.OnlyInAreasCheckbox.UseVisualStyleBackColor = true;
      // 
      // CheckIntervalNumeric
      // 
      this.CheckIntervalNumeric.DecimalPlaces = 3;
      this.CheckIntervalNumeric.Location = new System.Drawing.Point(193, 56);
      this.CheckIntervalNumeric.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
      this.CheckIntervalNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            196608});
      this.CheckIntervalNumeric.Name = "CheckIntervalNumeric";
      this.CheckIntervalNumeric.Size = new System.Drawing.Size(120, 23);
      this.CheckIntervalNumeric.TabIndex = 4;
      this.CheckIntervalNumeric.Value = new decimal(new int[] {
            500,
            0,
            0,
            196608});
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(22, 58);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(148, 15);
      this.label5.TabIndex = 5;
      this.label5.Text = "AI Check for Motion Every ";
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Location = new System.Drawing.Point(321, 58);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(51, 15);
      this.label6.TabIndex = 6;
      this.label6.Text = "Seconds";
      // 
      // AddCameraDialog
      // 
      this.AcceptButton = this.okButton;
      this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
      this.CancelButton = this.cancelButton;
      this.ClientSize = new System.Drawing.Size(569, 367);
      this.Controls.Add(this.tabControlCameraMethod);
      this.Controls.Add(this.label18);
      this.Controls.Add(this.cancelButton);
      this.Controls.Add(this.okButton);
      this.Name = "AddCameraDialog";
      this.Text = "Add a New Camera";
      this.Load += new System.EventHandler(this.AddCameraDialog_Load);
      this.tabTriggered.ResumeLayout(false);
      this.CameraTriggerPanel.ResumeLayout(false);
      this.CameraTriggerPanel.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.NoRecordNumeric)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.RecordFrameIntervalNumeric)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.RecordTimeNumeric)).EndInit();
      this.tabImage.ResumeLayout(false);
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.tabControlCameraMethod.ResumeLayout(false);
      this.tabPageLocation.ResumeLayout(false);
      this.panel4.ResumeLayout(false);
      this.panel4.PerformLayout();
      this.tabPageOnGuard.ResumeLayout(false);
      this.OnGuardPanel.ResumeLayout(false);
      this.OnGuardPanel.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.CheckIntervalNumeric)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

        #endregion

        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
    private System.Windows.Forms.Label label18;
    private System.Windows.Forms.TabPage tabTriggered;
    private System.Windows.Forms.Panel CameraTriggerPanel;
    private System.Windows.Forms.Label label14;
    private System.Windows.Forms.Button CameraTriggeredHelpButton;
    private System.Windows.Forms.Label label16;
    private System.Windows.Forms.Label label15;
    private System.Windows.Forms.NumericUpDown NoRecordNumeric;
    private System.Windows.Forms.NumericUpDown RecordFrameIntervalNumeric;
    private System.Windows.Forms.Label label13;
    private System.Windows.Forms.Label label12;
    private System.Windows.Forms.NumericUpDown RecordTimeNumeric;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label11;
    private System.Windows.Forms.TabPage tabImage;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Button HelpMethodButton;
    private System.Windows.Forms.RadioButton radioTrigger;
    private System.Windows.Forms.RadioButton radioScanImages;
    private System.Windows.Forms.RadioButton radioSoftware;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.TabControl tabControlCameraMethod;
    private System.Windows.Forms.TabPage tabPageLocation;
    private System.Windows.Forms.Panel panel4;
    private System.Windows.Forms.Label label17;
    private System.Windows.Forms.TextBox pathText;
    private System.Windows.Forms.Label label19;
    private System.Windows.Forms.Button BrowseButton;
    private System.Windows.Forms.Label label20;
    private System.Windows.Forms.TextBox prefixText;
    private System.Windows.Forms.Label label21;
    private System.Windows.Forms.Label label22;
    private System.Windows.Forms.TabPage tabPageOnGuard;
    private System.Windows.Forms.Panel OnGuardPanel;
    private System.Windows.Forms.Button OnGuardScanHelpButton;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.CheckBox OnlyInAreasCheckbox;
    private System.Windows.Forms.NumericUpDown CheckIntervalNumeric;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.Button FolderPrefixHelp;
    private System.Windows.Forms.TextBox triggerPrefixText;
    private System.Windows.Forms.Label label2;
  }
}