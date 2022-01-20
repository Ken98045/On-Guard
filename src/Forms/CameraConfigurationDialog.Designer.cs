namespace OnGuardCore
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
        AllCameraData.Dispose();
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
      this.EditCameraButton = new System.Windows.Forms.Button();
      this.AddCameraHelpButton = new System.Windows.Forms.Button();
      this.label22 = new System.Windows.Forms.Label();
      this.label18 = new System.Windows.Forms.Label();
      this.availableCamerasList = new System.Windows.Forms.ListView();
      this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
      this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
      this.removeCameraButton = new System.Windows.Forms.Button();
      this.addCameraButton = new System.Windows.Forms.Button();
      this.label21 = new System.Windows.Forms.Label();
      this.tabPageCameraContact = new System.Windows.Forms.TabPage();
      this.button1 = new System.Windows.Forms.Button();
      this.CameraAddressPanel = new System.Windows.Forms.Panel();
      this.CameraAddressHelpButton = new System.Windows.Forms.Button();
      this.label17 = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.OnVIFPortNumeric = new System.Windows.Forms.NumericUpDown();
      this.label5 = new System.Windows.Forms.Label();
      this.label16 = new System.Windows.Forms.Label();
      this.cameraIPAddressText = new System.Windows.Forms.TextBox();
      this.label15 = new System.Windows.Forms.Label();
      this.portNumeric = new System.Windows.Forms.NumericUpDown();
      this.label14 = new System.Windows.Forms.Label();
      this.cameraUserText = new System.Windows.Forms.TextBox();
      this.label12 = new System.Windows.Forms.Label();
      this.cameraPasswordText = new System.Windows.Forms.TextBox();
      this.label11 = new System.Windows.Forms.Label();
      this.AddressCameraLabel = new System.Windows.Forms.Label();
      this.liveCameraTab = new System.Windows.Forms.TabPage();
      this.CameraQualityGroupbox = new System.Windows.Forms.GroupBox();
      this.PictureQualityHelpButton = new System.Windows.Forms.Button();
      this.label41 = new System.Windows.Forms.Label();
      this.label7 = new System.Windows.Forms.Label();
      this.ChannelNumeric = new System.Windows.Forms.NumericUpDown();
      this.cameraXResolutionNumeric = new System.Windows.Forms.NumericUpDown();
      this.label39 = new System.Windows.Forms.Label();
      this.label8 = new System.Windows.Forms.Label();
      this.label40 = new System.Windows.Forms.Label();
      this.cameraYResolutionNumeric = new System.Windows.Forms.NumericUpDown();
      this.label9 = new System.Windows.Forms.Label();
      this.CameraMethodPanel = new System.Windows.Forms.Panel();
      this.CameraContactHelpButton = new System.Windows.Forms.Button();
      this.label13 = new System.Windows.Forms.Label();
      this.textBoxShortCameraName = new System.Windows.Forms.TextBox();
      this.label3 = new System.Windows.Forms.Label();
      this.uriTextBox = new System.Windows.Forms.TextBox();
      this.label25 = new System.Windows.Forms.Label();
      this.selectButton = new System.Windows.Forms.Button();
      this.radioHTTP = new System.Windows.Forms.RadioButton();
      this.radioiSpy = new System.Windows.Forms.RadioButton();
      this.radioOnVIF = new System.Windows.Forms.RadioButton();
      this.radioBlueIris = new System.Windows.Forms.RadioButton();
      this.LiveCameraLabel = new System.Windows.Forms.Label();
      this.label6 = new System.Windows.Forms.Label();
      this.PTZTab = new System.Windows.Forms.TabPage();
      this.CameraPTZPanel = new System.Windows.Forms.Panel();
      this.PTZHelpButton = new System.Windows.Forms.Button();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.label33 = new System.Windows.Forms.Label();
      this.label34 = new System.Windows.Forms.Label();
      this.label35 = new System.Windows.Forms.Label();
      this.label36 = new System.Windows.Forms.Label();
      this.radioButtonPTZNone = new System.Windows.Forms.RadioButton();
      this.label37 = new System.Windows.Forms.Label();
      this.radioButtonPTZHTTP = new System.Windows.Forms.RadioButton();
      this.radioButtonPTZiSpy = new System.Windows.Forms.RadioButton();
      this.radioButtonPTZOnVIF = new System.Windows.Forms.RadioButton();
      this.radioButtonPTZBlueIris = new System.Windows.Forms.RadioButton();
      this.ConfigureMovementButton = new System.Windows.Forms.Button();
      this.SelectPTZMethodButton = new System.Windows.Forms.Button();
      this.PTZCameraLabel = new System.Windows.Forms.Label();
      this.PresetsTab = new System.Windows.Forms.TabPage();
      this.PresetsCameraLabel = new System.Windows.Forms.Label();
      this.CameraPresetPanel = new System.Windows.Forms.Panel();
      this.PresetsHelpButton = new System.Windows.Forms.Button();
      this.groupBox2 = new System.Windows.Forms.GroupBox();
      this.label26 = new System.Windows.Forms.Label();
      this.label27 = new System.Windows.Forms.Label();
      this.label28 = new System.Windows.Forms.Label();
      this.label29 = new System.Windows.Forms.Label();
      this.radioPresetNone = new System.Windows.Forms.RadioButton();
      this.label31 = new System.Windows.Forms.Label();
      this.radioPresetHttp = new System.Windows.Forms.RadioButton();
      this.radioPresetiSpy = new System.Windows.Forms.RadioButton();
      this.radioPresetOnvif = new System.Windows.Forms.RadioButton();
      this.radioPresetBlueIris = new System.Windows.Forms.RadioButton();
      this.buttonTestPresets = new System.Windows.Forms.Button();
      this.buttonSelectPresetMethod = new System.Windows.Forms.Button();
      this.PresetCameraLabel = new System.Windows.Forms.Label();
      this.motionPage = new System.Windows.Forms.TabPage();
      this.panel1 = new System.Windows.Forms.Panel();
      this.Latitude = new System.Windows.Forms.NumericUpDown();
      this.Longitude = new System.Windows.Forms.NumericUpDown();
      this.label38 = new System.Windows.Forms.Label();
      this.label32 = new System.Windows.Forms.Label();
      this.label30 = new System.Windows.Forms.Label();
      this.label19 = new System.Windows.Forms.Label();
      this.RemovePresetButton = new System.Windows.Forms.Button();
      this.EditPresetButton = new System.Windows.Forms.Button();
      this.AddPresetButton = new System.Windows.Forms.Button();
      this.PresetsListView = new System.Windows.Forms.ListView();
      this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
      this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
      this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
      this.label10 = new System.Windows.Forms.Label();
      this.MonitorSubFoldersPanel = new System.Windows.Forms.Panel();
      this.MonitorSubFoldersCheckbox = new System.Windows.Forms.CheckBox();
      this.label42 = new System.Windows.Forms.Label();
      this.MotionTimeoutPanel = new System.Windows.Forms.Panel();
      this.label24 = new System.Windows.Forms.Label();
      this.label23 = new System.Windows.Forms.Label();
      this.label20 = new System.Windows.Forms.Label();
      this.MotionTimeoutNumeric = new System.Windows.Forms.NumericUpDown();
      this.MotionTimeoutCameraLabel = new System.Windows.Forms.Label();
      this.okButton = new System.Windows.Forms.Button();
      this.cancelButton = new System.Windows.Forms.Button();
      this.configurationTabControl.SuspendLayout();
      this.imagesTab.SuspendLayout();
      this.tabPageCameraContact.SuspendLayout();
      this.CameraAddressPanel.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.OnVIFPortNumeric)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.portNumeric)).BeginInit();
      this.liveCameraTab.SuspendLayout();
      this.CameraQualityGroupbox.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.ChannelNumeric)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.cameraXResolutionNumeric)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.cameraYResolutionNumeric)).BeginInit();
      this.CameraMethodPanel.SuspendLayout();
      this.PTZTab.SuspendLayout();
      this.CameraPTZPanel.SuspendLayout();
      this.groupBox1.SuspendLayout();
      this.PresetsTab.SuspendLayout();
      this.CameraPresetPanel.SuspendLayout();
      this.groupBox2.SuspendLayout();
      this.motionPage.SuspendLayout();
      this.panel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.Latitude)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.Longitude)).BeginInit();
      this.MonitorSubFoldersPanel.SuspendLayout();
      this.MotionTimeoutPanel.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.MotionTimeoutNumeric)).BeginInit();
      this.SuspendLayout();
      // 
      // configurationTabControl
      // 
      this.configurationTabControl.Controls.Add(this.imagesTab);
      this.configurationTabControl.Controls.Add(this.tabPageCameraContact);
      this.configurationTabControl.Controls.Add(this.liveCameraTab);
      this.configurationTabControl.Controls.Add(this.PTZTab);
      this.configurationTabControl.Controls.Add(this.PresetsTab);
      this.configurationTabControl.Controls.Add(this.motionPage);
      this.configurationTabControl.Location = new System.Drawing.Point(8, 11);
      this.configurationTabControl.Name = "configurationTabControl";
      this.configurationTabControl.SelectedIndex = 0;
      this.configurationTabControl.Size = new System.Drawing.Size(726, 456);
      this.configurationTabControl.TabIndex = 0;
      this.configurationTabControl.Selected += new System.Windows.Forms.TabControlEventHandler(this.OnTabPageSelected);
      this.configurationTabControl.Deselecting += new System.Windows.Forms.TabControlCancelEventHandler(this.OnTabPageDeselected);
      this.configurationTabControl.TabIndexChanged += new System.EventHandler(this.OnTabIndexChanged);
      // 
      // imagesTab
      // 
      this.imagesTab.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.imagesTab.Controls.Add(this.EditCameraButton);
      this.imagesTab.Controls.Add(this.AddCameraHelpButton);
      this.imagesTab.Controls.Add(this.label22);
      this.imagesTab.Controls.Add(this.label18);
      this.imagesTab.Controls.Add(this.availableCamerasList);
      this.imagesTab.Controls.Add(this.removeCameraButton);
      this.imagesTab.Controls.Add(this.addCameraButton);
      this.imagesTab.Controls.Add(this.label21);
      this.imagesTab.Location = new System.Drawing.Point(4, 24);
      this.imagesTab.Name = "imagesTab";
      this.imagesTab.Padding = new System.Windows.Forms.Padding(3);
      this.imagesTab.Size = new System.Drawing.Size(718, 428);
      this.imagesTab.TabIndex = 1;
      this.imagesTab.Text = "Select Current Camera";
      this.imagesTab.UseVisualStyleBackColor = true;
      // 
      // EditCameraButton
      // 
      this.EditCameraButton.Enabled = false;
      this.EditCameraButton.Location = new System.Drawing.Point(540, 113);
      this.EditCameraButton.Name = "EditCameraButton";
      this.EditCameraButton.Size = new System.Drawing.Size(113, 23);
      this.EditCameraButton.TabIndex = 1;
      this.EditCameraButton.Text = "Edit Camera";
      this.EditCameraButton.UseVisualStyleBackColor = true;
      this.EditCameraButton.Click += new System.EventHandler(this.EditCameraButton_Click);
      // 
      // AddCameraHelpButton
      // 
      this.AddCameraHelpButton.Location = new System.Drawing.Point(625, 392);
      this.AddCameraHelpButton.Name = "AddCameraHelpButton";
      this.AddCameraHelpButton.Size = new System.Drawing.Size(75, 23);
      this.AddCameraHelpButton.TabIndex = 2;
      this.AddCameraHelpButton.Text = "Help!";
      this.AddCameraHelpButton.UseVisualStyleBackColor = true;
      this.AddCameraHelpButton.Click += new System.EventHandler(this.AddCameraButtonClick);
      // 
      // label22
      // 
      this.label22.Location = new System.Drawing.Point(46, 210);
      this.label22.Name = "label22";
      this.label22.Size = new System.Drawing.Size(641, 142);
      this.label22.TabIndex = 19;
      this.label22.Text = resources.GetString("label22.Text");
      // 
      // label18
      // 
      this.label18.AutoSize = true;
      this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.label18.Location = new System.Drawing.Point(294, 21);
      this.label18.Name = "label18";
      this.label18.Size = new System.Drawing.Size(126, 15);
      this.label18.TabIndex = 18;
      this.label18.Text = "Available Cameras";
      // 
      // availableCamerasList
      // 
      this.availableCamerasList.CheckBoxes = true;
      this.availableCamerasList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4});
      this.availableCamerasList.FullRowSelect = true;
      this.availableCamerasList.GridLines = true;
      this.availableCamerasList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
      this.availableCamerasList.Location = new System.Drawing.Point(46, 53);
      this.availableCamerasList.MultiSelect = false;
      this.availableCamerasList.Name = "availableCamerasList";
      this.availableCamerasList.Size = new System.Drawing.Size(488, 144);
      this.availableCamerasList.TabIndex = 0;
      this.availableCamerasList.UseCompatibleStateImageBehavior = false;
      this.availableCamerasList.View = System.Windows.Forms.View.Details;
      this.availableCamerasList.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.OnCameraSelectionChanged);
      this.availableCamerasList.SelectedIndexChanged += new System.EventHandler(this.OnCameraSelectionChanged);
      this.availableCamerasList.DoubleClick += new System.EventHandler(this.OnCameraDoubleClick);
      // 
      // columnHeader3
      // 
      this.columnHeader3.Text = "Camera Prefix";
      this.columnHeader3.Width = 125;
      // 
      // columnHeader4
      // 
      this.columnHeader4.Text = "Camera File Path";
      this.columnHeader4.Width = 293;
      // 
      // removeCameraButton
      // 
      this.removeCameraButton.Enabled = false;
      this.removeCameraButton.Location = new System.Drawing.Point(540, 150);
      this.removeCameraButton.Name = "removeCameraButton";
      this.removeCameraButton.Size = new System.Drawing.Size(113, 23);
      this.removeCameraButton.TabIndex = 2;
      this.removeCameraButton.Text = "Remove Camera";
      this.removeCameraButton.UseVisualStyleBackColor = true;
      this.removeCameraButton.Click += new System.EventHandler(this.RemoveCameraButton_Click);
      // 
      // addCameraButton
      // 
      this.addCameraButton.Location = new System.Drawing.Point(540, 76);
      this.addCameraButton.Name = "addCameraButton";
      this.addCameraButton.Size = new System.Drawing.Size(113, 23);
      this.addCameraButton.TabIndex = 0;
      this.addCameraButton.Text = "Add Camera";
      this.addCameraButton.UseVisualStyleBackColor = true;
      this.addCameraButton.Click += new System.EventHandler(this.AddCameraButton_Click);
      // 
      // label21
      // 
      this.label21.Location = new System.Drawing.Point(6, 25);
      this.label21.Name = "label21";
      this.label21.Size = new System.Drawing.Size(681, 127);
      this.label21.TabIndex = 8;
      // 
      // tabPageCameraContact
      // 
      this.tabPageCameraContact.Controls.Add(this.button1);
      this.tabPageCameraContact.Controls.Add(this.CameraAddressPanel);
      this.tabPageCameraContact.Controls.Add(this.AddressCameraLabel);
      this.tabPageCameraContact.Location = new System.Drawing.Point(4, 24);
      this.tabPageCameraContact.Name = "tabPageCameraContact";
      this.tabPageCameraContact.Size = new System.Drawing.Size(718, 428);
      this.tabPageCameraContact.TabIndex = 7;
      this.tabPageCameraContact.Text = "Camera Address";
      this.tabPageCameraContact.UseVisualStyleBackColor = true;
      // 
      // button1
      // 
      this.button1.Location = new System.Drawing.Point(635, 495);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(75, 23);
      this.button1.TabIndex = 77;
      this.button1.Text = "Help!";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new System.EventHandler(this.button1_Click);
      // 
      // CameraAddressPanel
      // 
      this.CameraAddressPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.CameraAddressPanel.Controls.Add(this.CameraAddressHelpButton);
      this.CameraAddressPanel.Controls.Add(this.label17);
      this.CameraAddressPanel.Controls.Add(this.label1);
      this.CameraAddressPanel.Controls.Add(this.label2);
      this.CameraAddressPanel.Controls.Add(this.label4);
      this.CameraAddressPanel.Controls.Add(this.OnVIFPortNumeric);
      this.CameraAddressPanel.Controls.Add(this.label5);
      this.CameraAddressPanel.Controls.Add(this.label16);
      this.CameraAddressPanel.Controls.Add(this.cameraIPAddressText);
      this.CameraAddressPanel.Controls.Add(this.label15);
      this.CameraAddressPanel.Controls.Add(this.portNumeric);
      this.CameraAddressPanel.Controls.Add(this.label14);
      this.CameraAddressPanel.Controls.Add(this.cameraUserText);
      this.CameraAddressPanel.Controls.Add(this.label12);
      this.CameraAddressPanel.Controls.Add(this.cameraPasswordText);
      this.CameraAddressPanel.Controls.Add(this.label11);
      this.CameraAddressPanel.Enabled = false;
      this.CameraAddressPanel.Location = new System.Drawing.Point(16, 38);
      this.CameraAddressPanel.Name = "CameraAddressPanel";
      this.CameraAddressPanel.Size = new System.Drawing.Size(687, 275);
      this.CameraAddressPanel.TabIndex = 76;
      // 
      // CameraAddressHelpButton
      // 
      this.CameraAddressHelpButton.Location = new System.Drawing.Point(593, 238);
      this.CameraAddressHelpButton.Name = "CameraAddressHelpButton";
      this.CameraAddressHelpButton.Size = new System.Drawing.Size(75, 23);
      this.CameraAddressHelpButton.TabIndex = 74;
      this.CameraAddressHelpButton.Text = "Help!";
      this.CameraAddressHelpButton.UseVisualStyleBackColor = true;
      this.CameraAddressHelpButton.Click += new System.EventHandler(this.CameraAddressHelpButton_Click);
      // 
      // label17
      // 
      this.label17.Location = new System.Drawing.Point(288, 115);
      this.label17.Name = "label17";
      this.label17.Size = new System.Drawing.Size(380, 49);
      this.label17.TabIndex = 73;
      this.label17.Text = "For cameras that support OnVIF, otherwise safe to ignore\r\nPorts 8080, 8090, and 8" +
    "999 are common but varies by camera";
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(47, 28);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(106, 15);
      this.label1.TabIndex = 50;
      this.label1.Text = "Camera IP Address";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(24, 83);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(129, 15);
      this.label2.TabIndex = 51;
      this.label2.Text = "HTTP Port (usually 80): ";
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(88, 164);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(65, 15);
      this.label4.TabIndex = 52;
      this.label4.Text = "User Name";
      // 
      // OnVIFPortNumeric
      // 
      this.OnVIFPortNumeric.Location = new System.Drawing.Point(187, 121);
      this.OnVIFPortNumeric.Maximum = new decimal(new int[] {
            65553,
            0,
            0,
            0});
      this.OnVIFPortNumeric.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
      this.OnVIFPortNumeric.Name = "OnVIFPortNumeric";
      this.OnVIFPortNumeric.Size = new System.Drawing.Size(58, 23);
      this.OnVIFPortNumeric.TabIndex = 2;
      this.OnVIFPortNumeric.Value = new decimal(new int[] {
            8080,
            0,
            0,
            0});
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(96, 204);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(57, 15);
      this.label5.TabIndex = 53;
      this.label5.Text = "Password";
      // 
      // label16
      // 
      this.label16.AutoSize = true;
      this.label16.Location = new System.Drawing.Point(17, 123);
      this.label16.Name = "label16";
      this.label16.Size = new System.Drawing.Size(136, 15);
      this.label16.TabIndex = 71;
      this.label16.Text = "OnVIF Port (often 8080): ";
      // 
      // cameraIPAddressText
      // 
      this.cameraIPAddressText.Location = new System.Drawing.Point(187, 25);
      this.cameraIPAddressText.Name = "cameraIPAddressText";
      this.cameraIPAddressText.Size = new System.Drawing.Size(87, 23);
      this.cameraIPAddressText.TabIndex = 0;
      this.cameraIPAddressText.Text = "localhost";
      // 
      // label15
      // 
      this.label15.AutoSize = true;
      this.label15.Location = new System.Drawing.Point(288, 204);
      this.label15.Name = "label15";
      this.label15.Size = new System.Drawing.Size(260, 15);
      this.label15.TabIndex = 66;
      this.label15.Text = "Either the camera password or the Blue Iris login";
      // 
      // portNumeric
      // 
      this.portNumeric.Location = new System.Drawing.Point(187, 81);
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
      this.portNumeric.Size = new System.Drawing.Size(58, 23);
      this.portNumeric.TabIndex = 1;
      this.portNumeric.Value = new decimal(new int[] {
            80,
            0,
            0,
            0});
      // 
      // label14
      // 
      this.label14.AutoSize = true;
      this.label14.Location = new System.Drawing.Point(288, 164);
      this.label14.Name = "label14";
      this.label14.Size = new System.Drawing.Size(220, 15);
      this.label14.TabIndex = 65;
      this.label14.Text = "From the camera setup or Blue Iris  login";
      // 
      // cameraUserText
      // 
      this.cameraUserText.Location = new System.Drawing.Point(187, 161);
      this.cameraUserText.Name = "cameraUserText";
      this.cameraUserText.Size = new System.Drawing.Size(87, 23);
      this.cameraUserText.TabIndex = 3;
      this.cameraUserText.Text = "admin";
      // 
      // label12
      // 
      this.label12.Location = new System.Drawing.Point(288, 83);
      this.label12.Name = "label12";
      this.label12.Size = new System.Drawing.Size(380, 15);
      this.label12.TabIndex = 64;
      this.label12.Text = "This port is used to take snapshots and PTZ and Presets\r\n";
      // 
      // cameraPasswordText
      // 
      this.cameraPasswordText.Location = new System.Drawing.Point(187, 201);
      this.cameraPasswordText.Name = "cameraPasswordText";
      this.cameraPasswordText.Size = new System.Drawing.Size(87, 23);
      this.cameraPasswordText.TabIndex = 4;
      this.cameraPasswordText.Text = "admin";
      this.cameraPasswordText.UseSystemPasswordChar = true;
      // 
      // label11
      // 
      this.label11.Location = new System.Drawing.Point(288, 26);
      this.label11.Name = "label11";
      this.label11.Size = new System.Drawing.Size(380, 46);
      this.label11.TabIndex = 63;
      this.label11.Text = "\"localhost\" refers to the computer On Guard is running on.  This is often used fo" +
    "r devices/Blue Iris or similar applications\r\n";
      // 
      // AddressCameraLabel
      // 
      this.AddressCameraLabel.AutoSize = true;
      this.AddressCameraLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.AddressCameraLabel.Location = new System.Drawing.Point(281, 10);
      this.AddressCameraLabel.Name = "AddressCameraLabel";
      this.AddressCameraLabel.Size = new System.Drawing.Size(169, 16);
      this.AddressCameraLabel.TabIndex = 75;
      this.AddressCameraLabel.Text = "The Current Camera is: ";
      // 
      // liveCameraTab
      // 
      this.liveCameraTab.Controls.Add(this.CameraQualityGroupbox);
      this.liveCameraTab.Controls.Add(this.CameraMethodPanel);
      this.liveCameraTab.Controls.Add(this.LiveCameraLabel);
      this.liveCameraTab.Controls.Add(this.label6);
      this.liveCameraTab.Location = new System.Drawing.Point(4, 24);
      this.liveCameraTab.Name = "liveCameraTab";
      this.liveCameraTab.Size = new System.Drawing.Size(718, 428);
      this.liveCameraTab.TabIndex = 2;
      this.liveCameraTab.Text = "Snapshots/Live";
      this.liveCameraTab.UseVisualStyleBackColor = true;
      this.liveCameraTab.Click += new System.EventHandler(this.LiveCameraTab_Click);
      // 
      // CameraQualityGroupbox
      // 
      this.CameraQualityGroupbox.Controls.Add(this.PictureQualityHelpButton);
      this.CameraQualityGroupbox.Controls.Add(this.label41);
      this.CameraQualityGroupbox.Controls.Add(this.label7);
      this.CameraQualityGroupbox.Controls.Add(this.ChannelNumeric);
      this.CameraQualityGroupbox.Controls.Add(this.cameraXResolutionNumeric);
      this.CameraQualityGroupbox.Controls.Add(this.label39);
      this.CameraQualityGroupbox.Controls.Add(this.label8);
      this.CameraQualityGroupbox.Controls.Add(this.label40);
      this.CameraQualityGroupbox.Controls.Add(this.cameraYResolutionNumeric);
      this.CameraQualityGroupbox.Controls.Add(this.label9);
      this.CameraQualityGroupbox.Enabled = false;
      this.CameraQualityGroupbox.Location = new System.Drawing.Point(3, 279);
      this.CameraQualityGroupbox.Name = "CameraQualityGroupbox";
      this.CameraQualityGroupbox.Size = new System.Drawing.Size(712, 148);
      this.CameraQualityGroupbox.TabIndex = 80;
      this.CameraQualityGroupbox.TabStop = false;
      this.CameraQualityGroupbox.Text = "Picture Quality";
      // 
      // PictureQualityHelpButton
      // 
      this.PictureQualityHelpButton.Location = new System.Drawing.Point(602, 116);
      this.PictureQualityHelpButton.Name = "PictureQualityHelpButton";
      this.PictureQualityHelpButton.Size = new System.Drawing.Size(75, 23);
      this.PictureQualityHelpButton.TabIndex = 83;
      this.PictureQualityHelpButton.Text = "Help!";
      this.PictureQualityHelpButton.UseVisualStyleBackColor = true;
      this.PictureQualityHelpButton.Click += new System.EventHandler(this.PictureQualityHelpButton_Click);
      // 
      // label41
      // 
      this.label41.AutoSize = true;
      this.label41.Location = new System.Drawing.Point(265, 57);
      this.label41.Name = "label41";
      this.label41.Size = new System.Drawing.Size(290, 15);
      this.label41.TabIndex = 82;
      this.label41.Text = "Zero for Not Set/Defaultt.  From your camera manual.";
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.Location = new System.Drawing.Point(8, 24);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(156, 15);
      this.label7.TabIndex = 71;
      this.label7.Text = "Picture X Resolution (Width)";
      // 
      // ChannelNumeric
      // 
      this.ChannelNumeric.Location = new System.Drawing.Point(195, 86);
      this.ChannelNumeric.Maximum = new decimal(new int[] {
            65553,
            0,
            0,
            0});
      this.ChannelNumeric.Name = "ChannelNumeric";
      this.ChannelNumeric.Size = new System.Drawing.Size(63, 23);
      this.ChannelNumeric.TabIndex = 2;
      // 
      // cameraXResolutionNumeric
      // 
      this.cameraXResolutionNumeric.Location = new System.Drawing.Point(195, 22);
      this.cameraXResolutionNumeric.Maximum = new decimal(new int[] {
            65553,
            0,
            0,
            0});
      this.cameraXResolutionNumeric.Name = "cameraXResolutionNumeric";
      this.cameraXResolutionNumeric.Size = new System.Drawing.Size(63, 23);
      this.cameraXResolutionNumeric.TabIndex = 0;
      this.cameraXResolutionNumeric.Value = new decimal(new int[] {
            2560,
            0,
            0,
            0});
      // 
      // label39
      // 
      this.label39.Location = new System.Drawing.Point(265, 88);
      this.label39.Name = "label39";
      this.label39.Size = new System.Drawing.Size(441, 21);
      this.label39.TabIndex = 78;
      this.label39.Text = "When used by a camera, usually 0 or 1. Usually this is safe to ignore.\r\n";
      // 
      // label8
      // 
      this.label8.AutoSize = true;
      this.label8.Location = new System.Drawing.Point(4, 56);
      this.label8.Name = "label8";
      this.label8.Size = new System.Drawing.Size(160, 15);
      this.label8.TabIndex = 73;
      this.label8.Text = "Picture Y Resolution (Height)";
      // 
      // label40
      // 
      this.label40.AutoSize = true;
      this.label40.Location = new System.Drawing.Point(27, 88);
      this.label40.Name = "label40";
      this.label40.Size = new System.Drawing.Size(137, 15);
      this.label40.TabIndex = 77;
      this.label40.Text = "Camera Channel/Stream";
      // 
      // cameraYResolutionNumeric
      // 
      this.cameraYResolutionNumeric.Location = new System.Drawing.Point(195, 54);
      this.cameraYResolutionNumeric.Maximum = new decimal(new int[] {
            65553,
            0,
            0,
            0});
      this.cameraYResolutionNumeric.Name = "cameraYResolutionNumeric";
      this.cameraYResolutionNumeric.Size = new System.Drawing.Size(63, 23);
      this.cameraYResolutionNumeric.TabIndex = 1;
      this.cameraYResolutionNumeric.Value = new decimal(new int[] {
            1920,
            0,
            0,
            0});
      // 
      // label9
      // 
      this.label9.AutoSize = true;
      this.label9.Location = new System.Drawing.Point(265, 24);
      this.label9.Name = "label9";
      this.label9.Size = new System.Drawing.Size(290, 15);
      this.label9.TabIndex = 75;
      this.label9.Text = "Zero for Not Set/Defaultt.  From your camera manual.";
      // 
      // CameraMethodPanel
      // 
      this.CameraMethodPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.CameraMethodPanel.Controls.Add(this.CameraContactHelpButton);
      this.CameraMethodPanel.Controls.Add(this.label13);
      this.CameraMethodPanel.Controls.Add(this.textBoxShortCameraName);
      this.CameraMethodPanel.Controls.Add(this.label3);
      this.CameraMethodPanel.Controls.Add(this.uriTextBox);
      this.CameraMethodPanel.Controls.Add(this.label25);
      this.CameraMethodPanel.Controls.Add(this.selectButton);
      this.CameraMethodPanel.Controls.Add(this.radioHTTP);
      this.CameraMethodPanel.Controls.Add(this.radioiSpy);
      this.CameraMethodPanel.Controls.Add(this.radioOnVIF);
      this.CameraMethodPanel.Controls.Add(this.radioBlueIris);
      this.CameraMethodPanel.Enabled = false;
      this.CameraMethodPanel.Location = new System.Drawing.Point(3, 105);
      this.CameraMethodPanel.Name = "CameraMethodPanel";
      this.CameraMethodPanel.Size = new System.Drawing.Size(712, 163);
      this.CameraMethodPanel.TabIndex = 43;
      // 
      // CameraContactHelpButton
      // 
      this.CameraContactHelpButton.Location = new System.Drawing.Point(601, 130);
      this.CameraContactHelpButton.Name = "CameraContactHelpButton";
      this.CameraContactHelpButton.Size = new System.Drawing.Size(75, 23);
      this.CameraContactHelpButton.TabIndex = 46;
      this.CameraContactHelpButton.Text = "Help!";
      this.CameraContactHelpButton.UseVisualStyleBackColor = true;
      this.CameraContactHelpButton.Click += new System.EventHandler(this.CameraContactHelpButton_Click);
      // 
      // label13
      // 
      this.label13.AutoSize = true;
      this.label13.Location = new System.Drawing.Point(317, 126);
      this.label13.Name = "label13";
      this.label13.Size = new System.Drawing.Size(76, 15);
      this.label13.TabIndex = 45;
      this.label13.Text = "Blue Iris Only";
      // 
      // textBoxShortCameraName
      // 
      this.textBoxShortCameraName.Location = new System.Drawing.Point(107, 123);
      this.textBoxShortCameraName.Name = "textBoxShortCameraName";
      this.textBoxShortCameraName.ReadOnly = true;
      this.textBoxShortCameraName.Size = new System.Drawing.Size(197, 23);
      this.textBoxShortCameraName.TabIndex = 44;
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(3, 126);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(86, 15);
      this.label3.TabIndex = 25;
      this.label3.Text = "Camera Name:";
      // 
      // uriTextBox
      // 
      this.uriTextBox.Location = new System.Drawing.Point(107, 92);
      this.uriTextBox.Name = "uriTextBox";
      this.uriTextBox.Size = new System.Drawing.Size(498, 23);
      this.uriTextBox.TabIndex = 5;
      // 
      // label25
      // 
      this.label25.AutoSize = true;
      this.label25.Location = new System.Drawing.Point(21, 95);
      this.label25.Name = "label25";
      this.label25.Size = new System.Drawing.Size(50, 15);
      this.label25.TabIndex = 23;
      this.label25.Text = "Full URI:";
      // 
      // selectButton
      // 
      this.selectButton.Location = new System.Drawing.Point(270, 58);
      this.selectButton.Name = "selectButton";
      this.selectButton.Size = new System.Drawing.Size(171, 23);
      this.selectButton.TabIndex = 4;
      this.selectButton.Text = "Select Contact Method";
      this.selectButton.UseVisualStyleBackColor = true;
      this.selectButton.Click += new System.EventHandler(this.SelectButton_Click);
      // 
      // radioHTTP
      // 
      this.radioHTTP.AutoSize = true;
      this.radioHTTP.Location = new System.Drawing.Point(343, 30);
      this.radioHTTP.Name = "radioHTTP";
      this.radioHTTP.Size = new System.Drawing.Size(102, 19);
      this.radioHTTP.TabIndex = 3;
      this.radioHTTP.TabStop = true;
      this.radioHTTP.Text = "HTTP Message";
      this.radioHTTP.UseVisualStyleBackColor = true;
      this.radioHTTP.CheckedChanged += new System.EventHandler(this.OnContactChanged);
      // 
      // radioiSpy
      // 
      this.radioiSpy.AutoSize = true;
      this.radioiSpy.Location = new System.Drawing.Point(169, 30);
      this.radioiSpy.Name = "radioiSpy";
      this.radioiSpy.Size = new System.Drawing.Size(123, 19);
      this.radioiSpy.TabIndex = 2;
      this.radioiSpy.TabStop = true;
      this.radioiSpy.Text = "iSpy Definition File";
      this.radioiSpy.UseVisualStyleBackColor = true;
      this.radioiSpy.CheckedChanged += new System.EventHandler(this.OnContactChanged);
      // 
      // radioOnVIF
      // 
      this.radioOnVIF.AutoSize = true;
      this.radioOnVIF.Location = new System.Drawing.Point(343, 5);
      this.radioOnVIF.Name = "radioOnVIF";
      this.radioOnVIF.Size = new System.Drawing.Size(171, 19);
      this.radioOnVIF.TabIndex = 1;
      this.radioOnVIF.TabStop = true;
      this.radioOnVIF.Text = "OnVIF Compatible Cameras";
      this.radioOnVIF.UseVisualStyleBackColor = true;
      this.radioOnVIF.CheckedChanged += new System.EventHandler(this.OnContactChanged);
      // 
      // radioBlueIris
      // 
      this.radioBlueIris.AutoSize = true;
      this.radioBlueIris.Location = new System.Drawing.Point(169, 5);
      this.radioBlueIris.Name = "radioBlueIris";
      this.radioBlueIris.Size = new System.Drawing.Size(66, 19);
      this.radioBlueIris.TabIndex = 0;
      this.radioBlueIris.TabStop = true;
      this.radioBlueIris.Text = "Blue Iris";
      this.radioBlueIris.UseVisualStyleBackColor = true;
      this.radioBlueIris.CheckedChanged += new System.EventHandler(this.OnContactChanged);
      // 
      // LiveCameraLabel
      // 
      this.LiveCameraLabel.AutoSize = true;
      this.LiveCameraLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.LiveCameraLabel.Location = new System.Drawing.Point(281, 10);
      this.LiveCameraLabel.Name = "LiveCameraLabel";
      this.LiveCameraLabel.Size = new System.Drawing.Size(169, 16);
      this.LiveCameraLabel.TabIndex = 42;
      this.LiveCameraLabel.Text = "The Current Camera is: ";
      // 
      // label6
      // 
      this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.label6.Location = new System.Drawing.Point(22, 33);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(687, 72);
      this.label6.TabIndex = 24;
      this.label6.Text = "Select the Method Used to Contact this Camera for Snapshot/Live (.jpg) Images.\r\n\r" +
    "\nYou can choose to use: Blue Iris, OnVIF, iSpy, or HTTP depending on your camera" +
    " and/or your preferences.\r\n\r\n";
      // 
      // PTZTab
      // 
      this.PTZTab.Controls.Add(this.CameraPTZPanel);
      this.PTZTab.Controls.Add(this.PTZCameraLabel);
      this.PTZTab.Location = new System.Drawing.Point(4, 24);
      this.PTZTab.Name = "PTZTab";
      this.PTZTab.Size = new System.Drawing.Size(718, 428);
      this.PTZTab.TabIndex = 5;
      this.PTZTab.Text = "PTZ";
      this.PTZTab.UseVisualStyleBackColor = true;
      // 
      // CameraPTZPanel
      // 
      this.CameraPTZPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.CameraPTZPanel.Controls.Add(this.PTZHelpButton);
      this.CameraPTZPanel.Controls.Add(this.groupBox1);
      this.CameraPTZPanel.Controls.Add(this.ConfigureMovementButton);
      this.CameraPTZPanel.Controls.Add(this.SelectPTZMethodButton);
      this.CameraPTZPanel.Enabled = false;
      this.CameraPTZPanel.Location = new System.Drawing.Point(9, 42);
      this.CameraPTZPanel.Name = "CameraPTZPanel";
      this.CameraPTZPanel.Size = new System.Drawing.Size(701, 252);
      this.CameraPTZPanel.TabIndex = 44;
      // 
      // PTZHelpButton
      // 
      this.PTZHelpButton.Location = new System.Drawing.Point(613, 212);
      this.PTZHelpButton.Name = "PTZHelpButton";
      this.PTZHelpButton.Size = new System.Drawing.Size(75, 23);
      this.PTZHelpButton.TabIndex = 16;
      this.PTZHelpButton.Text = "Help!";
      this.PTZHelpButton.UseVisualStyleBackColor = true;
      this.PTZHelpButton.Click += new System.EventHandler(this.PTZHelpButton_Click);
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.label33);
      this.groupBox1.Controls.Add(this.label34);
      this.groupBox1.Controls.Add(this.label35);
      this.groupBox1.Controls.Add(this.label36);
      this.groupBox1.Controls.Add(this.radioButtonPTZNone);
      this.groupBox1.Controls.Add(this.label37);
      this.groupBox1.Controls.Add(this.radioButtonPTZHTTP);
      this.groupBox1.Controls.Add(this.radioButtonPTZiSpy);
      this.groupBox1.Controls.Add(this.radioButtonPTZOnVIF);
      this.groupBox1.Controls.Add(this.radioButtonPTZBlueIris);
      this.groupBox1.Location = new System.Drawing.Point(57, 13);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(585, 172);
      this.groupBox1.TabIndex = 15;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "PTZ Selection Method";
      // 
      // label33
      // 
      this.label33.AutoSize = true;
      this.label33.Location = new System.Drawing.Point(205, 138);
      this.label33.Name = "label33";
      this.label33.Size = new System.Drawing.Size(195, 15);
      this.label33.TabIndex = 24;
      this.label33.Text = "Movement Configuration Required!";
      // 
      // label34
      // 
      this.label34.AutoSize = true;
      this.label34.Location = new System.Drawing.Point(205, 110);
      this.label34.Name = "label34";
      this.label34.Size = new System.Drawing.Size(195, 15);
      this.label34.TabIndex = 23;
      this.label34.Text = "Movement Configuration Required!";
      // 
      // label35
      // 
      this.label35.AutoSize = true;
      this.label35.Location = new System.Drawing.Point(205, 82);
      this.label35.Name = "label35";
      this.label35.Size = new System.Drawing.Size(330, 15);
      this.label35.TabIndex = 22;
      this.label35.Text = "No Further Selection, but Movement Configuration Required!";
      // 
      // label36
      // 
      this.label36.AutoSize = true;
      this.label36.Location = new System.Drawing.Point(205, 56);
      this.label36.Name = "label36";
      this.label36.Size = new System.Drawing.Size(152, 15);
      this.label36.TabIndex = 21;
      this.label36.Text = "No Further Action Required";
      // 
      // radioButtonPTZNone
      // 
      this.radioButtonPTZNone.AutoSize = true;
      this.radioButtonPTZNone.Location = new System.Drawing.Point(16, 25);
      this.radioButtonPTZNone.Name = "radioButtonPTZNone";
      this.radioButtonPTZNone.Size = new System.Drawing.Size(54, 19);
      this.radioButtonPTZNone.TabIndex = 0;
      this.radioButtonPTZNone.TabStop = true;
      this.radioButtonPTZNone.Text = "None";
      this.radioButtonPTZNone.UseVisualStyleBackColor = true;
      // 
      // label37
      // 
      this.label37.AutoSize = true;
      this.label37.Location = new System.Drawing.Point(205, 27);
      this.label37.Name = "label37";
      this.label37.Size = new System.Drawing.Size(161, 15);
      this.label37.TabIndex = 19;
      this.label37.Text = "Movement Controls Disabled";
      // 
      // radioButtonPTZHTTP
      // 
      this.radioButtonPTZHTTP.AutoSize = true;
      this.radioButtonPTZHTTP.Location = new System.Drawing.Point(16, 136);
      this.radioButtonPTZHTTP.Name = "radioButtonPTZHTTP";
      this.radioButtonPTZHTTP.Size = new System.Drawing.Size(102, 19);
      this.radioButtonPTZHTTP.TabIndex = 4;
      this.radioButtonPTZHTTP.TabStop = true;
      this.radioButtonPTZHTTP.Text = "HTTP Message";
      this.radioButtonPTZHTTP.UseVisualStyleBackColor = true;
      // 
      // radioButtonPTZiSpy
      // 
      this.radioButtonPTZiSpy.AutoSize = true;
      this.radioButtonPTZiSpy.Location = new System.Drawing.Point(16, 108);
      this.radioButtonPTZiSpy.Name = "radioButtonPTZiSpy";
      this.radioButtonPTZiSpy.Size = new System.Drawing.Size(123, 19);
      this.radioButtonPTZiSpy.TabIndex = 3;
      this.radioButtonPTZiSpy.TabStop = true;
      this.radioButtonPTZiSpy.Text = "iSpy Definition File";
      this.radioButtonPTZiSpy.UseVisualStyleBackColor = true;
      // 
      // radioButtonPTZOnVIF
      // 
      this.radioButtonPTZOnVIF.AutoSize = true;
      this.radioButtonPTZOnVIF.Location = new System.Drawing.Point(16, 80);
      this.radioButtonPTZOnVIF.Name = "radioButtonPTZOnVIF";
      this.radioButtonPTZOnVIF.Size = new System.Drawing.Size(106, 19);
      this.radioButtonPTZOnVIF.TabIndex = 2;
      this.radioButtonPTZOnVIF.TabStop = true;
      this.radioButtonPTZOnVIF.Text = "OnVIF Cameras";
      this.radioButtonPTZOnVIF.UseVisualStyleBackColor = true;
      // 
      // radioButtonPTZBlueIris
      // 
      this.radioButtonPTZBlueIris.AutoSize = true;
      this.radioButtonPTZBlueIris.Location = new System.Drawing.Point(16, 52);
      this.radioButtonPTZBlueIris.Name = "radioButtonPTZBlueIris";
      this.radioButtonPTZBlueIris.Size = new System.Drawing.Size(66, 19);
      this.radioButtonPTZBlueIris.TabIndex = 1;
      this.radioButtonPTZBlueIris.TabStop = true;
      this.radioButtonPTZBlueIris.Text = "Blue Iris";
      this.radioButtonPTZBlueIris.UseVisualStyleBackColor = true;
      // 
      // ConfigureMovementButton
      // 
      this.ConfigureMovementButton.Enabled = false;
      this.ConfigureMovementButton.Location = new System.Drawing.Point(357, 211);
      this.ConfigureMovementButton.Name = "ConfigureMovementButton";
      this.ConfigureMovementButton.Size = new System.Drawing.Size(143, 23);
      this.ConfigureMovementButton.TabIndex = 1;
      this.ConfigureMovementButton.Text = "Configure Movement";
      this.ConfigureMovementButton.UseVisualStyleBackColor = true;
      this.ConfigureMovementButton.Click += new System.EventHandler(this.ConfigureMovementButton_Click);
      // 
      // SelectPTZMethodButton
      // 
      this.SelectPTZMethodButton.Location = new System.Drawing.Point(198, 211);
      this.SelectPTZMethodButton.Name = "SelectPTZMethodButton";
      this.SelectPTZMethodButton.Size = new System.Drawing.Size(143, 23);
      this.SelectPTZMethodButton.TabIndex = 0;
      this.SelectPTZMethodButton.Text = "Select";
      this.SelectPTZMethodButton.UseVisualStyleBackColor = true;
      this.SelectPTZMethodButton.Click += new System.EventHandler(this.SelectPTZMethod);
      // 
      // PTZCameraLabel
      // 
      this.PTZCameraLabel.AutoSize = true;
      this.PTZCameraLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.PTZCameraLabel.Location = new System.Drawing.Point(275, 10);
      this.PTZCameraLabel.Name = "PTZCameraLabel";
      this.PTZCameraLabel.Size = new System.Drawing.Size(169, 16);
      this.PTZCameraLabel.TabIndex = 44;
      this.PTZCameraLabel.Text = "The Current Camera is: ";
      // 
      // PresetsTab
      // 
      this.PresetsTab.Controls.Add(this.PresetsCameraLabel);
      this.PresetsTab.Controls.Add(this.CameraPresetPanel);
      this.PresetsTab.Controls.Add(this.PresetCameraLabel);
      this.PresetsTab.Location = new System.Drawing.Point(4, 24);
      this.PresetsTab.Name = "PresetsTab";
      this.PresetsTab.Size = new System.Drawing.Size(718, 428);
      this.PresetsTab.TabIndex = 6;
      this.PresetsTab.Text = "Presets";
      this.PresetsTab.UseVisualStyleBackColor = true;
      // 
      // PresetsCameraLabel
      // 
      this.PresetsCameraLabel.AutoSize = true;
      this.PresetsCameraLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.PresetsCameraLabel.Location = new System.Drawing.Point(281, 10);
      this.PresetsCameraLabel.Name = "PresetsCameraLabel";
      this.PresetsCameraLabel.Size = new System.Drawing.Size(169, 16);
      this.PresetsCameraLabel.TabIndex = 48;
      this.PresetsCameraLabel.Text = "The Current Camera is: ";
      // 
      // CameraPresetPanel
      // 
      this.CameraPresetPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.CameraPresetPanel.Controls.Add(this.PresetsHelpButton);
      this.CameraPresetPanel.Controls.Add(this.groupBox2);
      this.CameraPresetPanel.Controls.Add(this.buttonTestPresets);
      this.CameraPresetPanel.Controls.Add(this.buttonSelectPresetMethod);
      this.CameraPresetPanel.Enabled = false;
      this.CameraPresetPanel.Location = new System.Drawing.Point(9, 47);
      this.CameraPresetPanel.Name = "CameraPresetPanel";
      this.CameraPresetPanel.Size = new System.Drawing.Size(701, 258);
      this.CameraPresetPanel.TabIndex = 47;
      // 
      // PresetsHelpButton
      // 
      this.PresetsHelpButton.Location = new System.Drawing.Point(611, 223);
      this.PresetsHelpButton.Name = "PresetsHelpButton";
      this.PresetsHelpButton.Size = new System.Drawing.Size(75, 23);
      this.PresetsHelpButton.TabIndex = 84;
      this.PresetsHelpButton.Text = "Help!";
      this.PresetsHelpButton.UseVisualStyleBackColor = true;
      this.PresetsHelpButton.Click += new System.EventHandler(this.PresetsHelpButton_Click);
      // 
      // groupBox2
      // 
      this.groupBox2.Controls.Add(this.label26);
      this.groupBox2.Controls.Add(this.label27);
      this.groupBox2.Controls.Add(this.label28);
      this.groupBox2.Controls.Add(this.label29);
      this.groupBox2.Controls.Add(this.radioPresetNone);
      this.groupBox2.Controls.Add(this.label31);
      this.groupBox2.Controls.Add(this.radioPresetHttp);
      this.groupBox2.Controls.Add(this.radioPresetiSpy);
      this.groupBox2.Controls.Add(this.radioPresetOnvif);
      this.groupBox2.Controls.Add(this.radioPresetBlueIris);
      this.groupBox2.Location = new System.Drawing.Point(73, 9);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new System.Drawing.Size(551, 172);
      this.groupBox2.TabIndex = 0;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "Presets Selection Method";
      // 
      // label26
      // 
      this.label26.AutoSize = true;
      this.label26.Location = new System.Drawing.Point(205, 144);
      this.label26.Name = "label26";
      this.label26.Size = new System.Drawing.Size(169, 15);
      this.label26.TabIndex = 24;
      this.label26.Text = "Preset Configuration Required!";
      // 
      // label27
      // 
      this.label27.AutoSize = true;
      this.label27.Location = new System.Drawing.Point(205, 116);
      this.label27.Name = "label27";
      this.label27.Size = new System.Drawing.Size(165, 15);
      this.label27.TabIndex = 23;
      this.label27.Text = "Peset Configuration Required!";
      // 
      // label28
      // 
      this.label28.AutoSize = true;
      this.label28.Location = new System.Drawing.Point(205, 88);
      this.label28.Name = "label28";
      this.label28.Size = new System.Drawing.Size(115, 15);
      this.label28.TabIndex = 22;
      this.label28.Text = "No Further Selection";
      // 
      // label29
      // 
      this.label29.AutoSize = true;
      this.label29.Location = new System.Drawing.Point(205, 62);
      this.label29.Name = "label29";
      this.label29.Size = new System.Drawing.Size(152, 15);
      this.label29.TabIndex = 21;
      this.label29.Text = "No Further Action Required";
      // 
      // radioPresetNone
      // 
      this.radioPresetNone.AutoSize = true;
      this.radioPresetNone.Location = new System.Drawing.Point(16, 31);
      this.radioPresetNone.Name = "radioPresetNone";
      this.radioPresetNone.Size = new System.Drawing.Size(54, 19);
      this.radioPresetNone.TabIndex = 0;
      this.radioPresetNone.TabStop = true;
      this.radioPresetNone.Text = "None";
      this.radioPresetNone.UseVisualStyleBackColor = true;
      // 
      // label31
      // 
      this.label31.AutoSize = true;
      this.label31.Location = new System.Drawing.Point(205, 33);
      this.label31.Name = "label31";
      this.label31.Size = new System.Drawing.Size(135, 15);
      this.label31.TabIndex = 19;
      this.label31.Text = "Preset Controls Disabled";
      // 
      // radioPresetHttp
      // 
      this.radioPresetHttp.AutoSize = true;
      this.radioPresetHttp.Location = new System.Drawing.Point(16, 142);
      this.radioPresetHttp.Name = "radioPresetHttp";
      this.radioPresetHttp.Size = new System.Drawing.Size(102, 19);
      this.radioPresetHttp.TabIndex = 3;
      this.radioPresetHttp.TabStop = true;
      this.radioPresetHttp.Text = "HTTP Message";
      this.radioPresetHttp.UseVisualStyleBackColor = true;
      // 
      // radioPresetiSpy
      // 
      this.radioPresetiSpy.AutoSize = true;
      this.radioPresetiSpy.Location = new System.Drawing.Point(16, 114);
      this.radioPresetiSpy.Name = "radioPresetiSpy";
      this.radioPresetiSpy.Size = new System.Drawing.Size(123, 19);
      this.radioPresetiSpy.TabIndex = 17;
      this.radioPresetiSpy.TabStop = true;
      this.radioPresetiSpy.Text = "iSpy Definition File";
      this.radioPresetiSpy.UseVisualStyleBackColor = true;
      // 
      // radioPresetOnvif
      // 
      this.radioPresetOnvif.AutoSize = true;
      this.radioPresetOnvif.Location = new System.Drawing.Point(16, 86);
      this.radioPresetOnvif.Name = "radioPresetOnvif";
      this.radioPresetOnvif.Size = new System.Drawing.Size(106, 19);
      this.radioPresetOnvif.TabIndex = 2;
      this.radioPresetOnvif.TabStop = true;
      this.radioPresetOnvif.Text = "OnVIF Cameras";
      this.radioPresetOnvif.UseVisualStyleBackColor = true;
      // 
      // radioPresetBlueIris
      // 
      this.radioPresetBlueIris.AutoSize = true;
      this.radioPresetBlueIris.Location = new System.Drawing.Point(16, 58);
      this.radioPresetBlueIris.Name = "radioPresetBlueIris";
      this.radioPresetBlueIris.Size = new System.Drawing.Size(66, 19);
      this.radioPresetBlueIris.TabIndex = 1;
      this.radioPresetBlueIris.TabStop = true;
      this.radioPresetBlueIris.Text = "Blue Iris";
      this.radioPresetBlueIris.UseVisualStyleBackColor = true;
      // 
      // buttonTestPresets
      // 
      this.buttonTestPresets.Location = new System.Drawing.Point(357, 211);
      this.buttonTestPresets.Name = "buttonTestPresets";
      this.buttonTestPresets.Size = new System.Drawing.Size(143, 23);
      this.buttonTestPresets.TabIndex = 2;
      this.buttonTestPresets.Text = "Test Presets";
      this.buttonTestPresets.UseVisualStyleBackColor = true;
      this.buttonTestPresets.Click += new System.EventHandler(this.ButtonTestPresets_Click);
      // 
      // buttonSelectPresetMethod
      // 
      this.buttonSelectPresetMethod.Location = new System.Drawing.Point(198, 211);
      this.buttonSelectPresetMethod.Name = "buttonSelectPresetMethod";
      this.buttonSelectPresetMethod.Size = new System.Drawing.Size(143, 23);
      this.buttonSelectPresetMethod.TabIndex = 1;
      this.buttonSelectPresetMethod.Text = "Select";
      this.buttonSelectPresetMethod.UseVisualStyleBackColor = true;
      this.buttonSelectPresetMethod.Click += new System.EventHandler(this.ButtonSelectPresetMethod_Click);
      // 
      // PresetCameraLabel
      // 
      this.PresetCameraLabel.AutoSize = true;
      this.PresetCameraLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.PresetCameraLabel.Location = new System.Drawing.Point(191, 257);
      this.PresetCameraLabel.Name = "PresetCameraLabel";
      this.PresetCameraLabel.Size = new System.Drawing.Size(169, 16);
      this.PresetCameraLabel.TabIndex = 46;
      this.PresetCameraLabel.Text = "The Current Camera is: ";
      // 
      // motionPage
      // 
      this.motionPage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.motionPage.Controls.Add(this.panel1);
      this.motionPage.Controls.Add(this.MonitorSubFoldersPanel);
      this.motionPage.Controls.Add(this.MotionTimeoutPanel);
      this.motionPage.Controls.Add(this.MotionTimeoutCameraLabel);
      this.motionPage.Location = new System.Drawing.Point(4, 24);
      this.motionPage.Name = "motionPage";
      this.motionPage.Padding = new System.Windows.Forms.Padding(3);
      this.motionPage.Size = new System.Drawing.Size(718, 428);
      this.motionPage.TabIndex = 4;
      this.motionPage.Text = "Other Options";
      this.motionPage.UseVisualStyleBackColor = true;
      // 
      // panel1
      // 
      this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.panel1.Controls.Add(this.Latitude);
      this.panel1.Controls.Add(this.Longitude);
      this.panel1.Controls.Add(this.label38);
      this.panel1.Controls.Add(this.label32);
      this.panel1.Controls.Add(this.label30);
      this.panel1.Controls.Add(this.label19);
      this.panel1.Controls.Add(this.RemovePresetButton);
      this.panel1.Controls.Add(this.EditPresetButton);
      this.panel1.Controls.Add(this.AddPresetButton);
      this.panel1.Controls.Add(this.PresetsListView);
      this.panel1.Controls.Add(this.label10);
      this.panel1.Location = new System.Drawing.Point(29, 234);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(676, 172);
      this.panel1.TabIndex = 50;
      // 
      // Latitude
      // 
      this.Latitude.DecimalPlaces = 3;
      this.Latitude.Location = new System.Drawing.Point(89, 135);
      this.Latitude.Maximum = new decimal(new int[] {
            180,
            0,
            0,
            0});
      this.Latitude.Minimum = new decimal(new int[] {
            179999,
            0,
            0,
            -2147287040});
      this.Latitude.Name = "Latitude";
      this.Latitude.Size = new System.Drawing.Size(79, 23);
      this.Latitude.TabIndex = 1;
      // 
      // Longitude
      // 
      this.Longitude.DecimalPlaces = 3;
      this.Longitude.Location = new System.Drawing.Point(89, 106);
      this.Longitude.Maximum = new decimal(new int[] {
            180,
            0,
            0,
            0});
      this.Longitude.Minimum = new decimal(new int[] {
            179999,
            0,
            0,
            -2147287040});
      this.Longitude.Name = "Longitude";
      this.Longitude.Size = new System.Drawing.Size(79, 23);
      this.Longitude.TabIndex = 0;
      // 
      // label38
      // 
      this.label38.AutoSize = true;
      this.label38.Location = new System.Drawing.Point(15, 137);
      this.label38.Name = "label38";
      this.label38.Size = new System.Drawing.Size(50, 15);
      this.label38.TabIndex = 8;
      this.label38.Text = "Latitude";
      // 
      // label32
      // 
      this.label32.AutoSize = true;
      this.label32.Location = new System.Drawing.Point(15, 108);
      this.label32.Name = "label32";
      this.label32.Size = new System.Drawing.Size(61, 15);
      this.label32.TabIndex = 7;
      this.label32.Text = "Longitude";
      // 
      // label30
      // 
      this.label30.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      this.label30.Location = new System.Drawing.Point(8, 32);
      this.label30.Name = "label30";
      this.label30.Size = new System.Drawing.Size(243, 71);
      this.label30.TabIndex = 6;
      this.label30.Text = "In order to know Sunrise/Sunset On Guard needs the camera location. This value is" +
    " in degrees (ex: -123.456)";
      // 
      // label19
      // 
      this.label19.AutoSize = true;
      this.label19.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.label19.Location = new System.Drawing.Point(78, 8);
      this.label19.Name = "label19";
      this.label19.Size = new System.Drawing.Size(99, 15);
      this.label19.TabIndex = 5;
      this.label19.Text = "Camera Location";
      // 
      // RemovePresetButton
      // 
      this.RemovePresetButton.Enabled = false;
      this.RemovePresetButton.Location = new System.Drawing.Point(572, 110);
      this.RemovePresetButton.Name = "RemovePresetButton";
      this.RemovePresetButton.Size = new System.Drawing.Size(75, 23);
      this.RemovePresetButton.TabIndex = 4;
      this.RemovePresetButton.Text = "Remove";
      this.RemovePresetButton.UseVisualStyleBackColor = true;
      this.RemovePresetButton.Click += new System.EventHandler(this.RemovePresetButton_Click);
      // 
      // EditPresetButton
      // 
      this.EditPresetButton.Enabled = false;
      this.EditPresetButton.Location = new System.Drawing.Point(572, 81);
      this.EditPresetButton.Name = "EditPresetButton";
      this.EditPresetButton.Size = new System.Drawing.Size(75, 23);
      this.EditPresetButton.TabIndex = 3;
      this.EditPresetButton.Text = "Edit";
      this.EditPresetButton.UseVisualStyleBackColor = true;
      this.EditPresetButton.Click += new System.EventHandler(this.EditPresetButton_Click);
      // 
      // AddPresetButton
      // 
      this.AddPresetButton.Location = new System.Drawing.Point(572, 52);
      this.AddPresetButton.Name = "AddPresetButton";
      this.AddPresetButton.Size = new System.Drawing.Size(75, 23);
      this.AddPresetButton.TabIndex = 2;
      this.AddPresetButton.Text = "Add";
      this.AddPresetButton.UseVisualStyleBackColor = true;
      this.AddPresetButton.Click += new System.EventHandler(this.AddPresetButton_Click);
      // 
      // PresetsListView
      // 
      this.PresetsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader5});
      this.PresetsListView.FullRowSelect = true;
      this.PresetsListView.GridLines = true;
      this.PresetsListView.Location = new System.Drawing.Point(257, 32);
      this.PresetsListView.MultiSelect = false;
      this.PresetsListView.Name = "PresetsListView";
      this.PresetsListView.Size = new System.Drawing.Size(302, 131);
      this.PresetsListView.TabIndex = 1;
      this.PresetsListView.UseCompatibleStateImageBehavior = false;
      this.PresetsListView.View = System.Windows.Forms.View.Details;
      this.PresetsListView.ItemActivate += new System.EventHandler(this.OnItemActivate);
      this.PresetsListView.SelectedIndexChanged += new System.EventHandler(this.OnPresetIndexChanged);
      // 
      // columnHeader1
      // 
      this.columnHeader1.Text = "Name";
      this.columnHeader1.Width = 125;
      // 
      // columnHeader2
      // 
      this.columnHeader2.Text = "Preset";
      // 
      // columnHeader5
      // 
      this.columnHeader5.Text = "AtTime";
      this.columnHeader5.Width = 100;
      // 
      // label10
      // 
      this.label10.AutoSize = true;
      this.label10.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.label10.Location = new System.Drawing.Point(336, 8);
      this.label10.Name = "label10";
      this.label10.Size = new System.Drawing.Size(154, 15);
      this.label10.TabIndex = 0;
      this.label10.Text = "Scheduled Camera Presets";
      // 
      // MonitorSubFoldersPanel
      // 
      this.MonitorSubFoldersPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.MonitorSubFoldersPanel.Controls.Add(this.MonitorSubFoldersCheckbox);
      this.MonitorSubFoldersPanel.Controls.Add(this.label42);
      this.MonitorSubFoldersPanel.Enabled = false;
      this.MonitorSubFoldersPanel.Location = new System.Drawing.Point(29, 136);
      this.MonitorSubFoldersPanel.Name = "MonitorSubFoldersPanel";
      this.MonitorSubFoldersPanel.Size = new System.Drawing.Size(676, 92);
      this.MonitorSubFoldersPanel.TabIndex = 49;
      // 
      // MonitorSubFoldersCheckbox
      // 
      this.MonitorSubFoldersCheckbox.AutoSize = true;
      this.MonitorSubFoldersCheckbox.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.MonitorSubFoldersCheckbox.Location = new System.Drawing.Point(251, 59);
      this.MonitorSubFoldersCheckbox.Name = "MonitorSubFoldersCheckbox";
      this.MonitorSubFoldersCheckbox.Size = new System.Drawing.Size(175, 21);
      this.MonitorSubFoldersCheckbox.TabIndex = 0;
      this.MonitorSubFoldersCheckbox.Text = "Monitor All Sub-Folders";
      this.MonitorSubFoldersCheckbox.UseVisualStyleBackColor = true;
      // 
      // label42
      // 
      this.label42.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.label42.Location = new System.Drawing.Point(16, 14);
      this.label42.Name = "label42";
      this.label42.Size = new System.Drawing.Size(643, 43);
      this.label42.TabIndex = 1;
      this.label42.Text = "Some cameras save all images stored via FTP in one folder.  Other cameras may put" +
    " images in year, month, and day sub-folders.  This option allows you to monitor " +
    "these sub-folders.\r\n\r\n";
      // 
      // MotionTimeoutPanel
      // 
      this.MotionTimeoutPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.MotionTimeoutPanel.Controls.Add(this.label24);
      this.MotionTimeoutPanel.Controls.Add(this.label23);
      this.MotionTimeoutPanel.Controls.Add(this.label20);
      this.MotionTimeoutPanel.Controls.Add(this.MotionTimeoutNumeric);
      this.MotionTimeoutPanel.Enabled = false;
      this.MotionTimeoutPanel.Location = new System.Drawing.Point(29, 33);
      this.MotionTimeoutPanel.Name = "MotionTimeoutPanel";
      this.MotionTimeoutPanel.Size = new System.Drawing.Size(676, 95);
      this.MotionTimeoutPanel.TabIndex = 48;
      // 
      // label24
      // 
      this.label24.AutoSize = true;
      this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.label24.Location = new System.Drawing.Point(421, 63);
      this.label24.Name = "label24";
      this.label24.Size = new System.Drawing.Size(86, 15);
      this.label24.TabIndex = 3;
      this.label24.Text = "(in seconds)\r\n";
      // 
      // label23
      // 
      this.label23.AutoSize = true;
      this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.label23.Location = new System.Drawing.Point(162, 63);
      this.label23.Name = "label23";
      this.label23.Size = new System.Drawing.Size(161, 15);
      this.label23.TabIndex = 1;
      this.label23.Text = "Motion Timeout Period: ";
      // 
      // label20
      // 
      this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.label20.Location = new System.Drawing.Point(17, 22);
      this.label20.Name = "label20";
      this.label20.Size = new System.Drawing.Size(643, 39);
      this.label20.TabIndex = 0;
      this.label20.Text = "The Motion Timeout is the timeout period before any motion is considered stopped." +
    "  This applies to all areas for the camera.\r\n";
      // 
      // MotionTimeoutNumeric
      // 
      this.MotionTimeoutNumeric.Location = new System.Drawing.Point(337, 62);
      this.MotionTimeoutNumeric.Maximum = new decimal(new int[] {
            600,
            0,
            0,
            0});
      this.MotionTimeoutNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.MotionTimeoutNumeric.Name = "MotionTimeoutNumeric";
      this.MotionTimeoutNumeric.Size = new System.Drawing.Size(77, 23);
      this.MotionTimeoutNumeric.TabIndex = 0;
      this.MotionTimeoutNumeric.Value = new decimal(new int[] {
            90,
            0,
            0,
            0});
      this.MotionTimeoutNumeric.ValueChanged += new System.EventHandler(this.OnMotionTimeoutChanged);
      // 
      // MotionTimeoutCameraLabel
      // 
      this.MotionTimeoutCameraLabel.AutoSize = true;
      this.MotionTimeoutCameraLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.MotionTimeoutCameraLabel.Location = new System.Drawing.Point(281, 10);
      this.MotionTimeoutCameraLabel.Name = "MotionTimeoutCameraLabel";
      this.MotionTimeoutCameraLabel.Size = new System.Drawing.Size(169, 16);
      this.MotionTimeoutCameraLabel.TabIndex = 47;
      this.MotionTimeoutCameraLabel.Text = "The Current Camera is: ";
      // 
      // okButton
      // 
      this.okButton.Location = new System.Drawing.Point(305, 477);
      this.okButton.Name = "okButton";
      this.okButton.Size = new System.Drawing.Size(67, 23);
      this.okButton.TabIndex = 0;
      this.okButton.Text = "OK";
      this.okButton.UseVisualStyleBackColor = true;
      this.okButton.Click += new System.EventHandler(this.OkButton_Click);
      // 
      // cancelButton
      // 
      this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.cancelButton.Location = new System.Drawing.Point(383, 478);
      this.cancelButton.Name = "cancelButton";
      this.cancelButton.Size = new System.Drawing.Size(67, 23);
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
      this.AutoScroll = true;
      this.CancelButton = this.cancelButton;
      this.ClientSize = new System.Drawing.Size(742, 525);
      this.Controls.Add(this.cancelButton);
      this.Controls.Add(this.okButton);
      this.Controls.Add(this.configurationTabControl);
      this.Name = "CameraConfigurationDialog";
      this.Text = "Camera Configuration";
      this.configurationTabControl.ResumeLayout(false);
      this.imagesTab.ResumeLayout(false);
      this.imagesTab.PerformLayout();
      this.tabPageCameraContact.ResumeLayout(false);
      this.tabPageCameraContact.PerformLayout();
      this.CameraAddressPanel.ResumeLayout(false);
      this.CameraAddressPanel.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.OnVIFPortNumeric)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.portNumeric)).EndInit();
      this.liveCameraTab.ResumeLayout(false);
      this.liveCameraTab.PerformLayout();
      this.CameraQualityGroupbox.ResumeLayout(false);
      this.CameraQualityGroupbox.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.ChannelNumeric)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.cameraXResolutionNumeric)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.cameraYResolutionNumeric)).EndInit();
      this.CameraMethodPanel.ResumeLayout(false);
      this.CameraMethodPanel.PerformLayout();
      this.PTZTab.ResumeLayout(false);
      this.PTZTab.PerformLayout();
      this.CameraPTZPanel.ResumeLayout(false);
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.PresetsTab.ResumeLayout(false);
      this.PresetsTab.PerformLayout();
      this.CameraPresetPanel.ResumeLayout(false);
      this.groupBox2.ResumeLayout(false);
      this.groupBox2.PerformLayout();
      this.motionPage.ResumeLayout(false);
      this.motionPage.PerformLayout();
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.Latitude)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.Longitude)).EndInit();
      this.MonitorSubFoldersPanel.ResumeLayout(false);
      this.MonitorSubFoldersPanel.PerformLayout();
      this.MotionTimeoutPanel.ResumeLayout(false);
      this.MotionTimeoutPanel.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.MotionTimeoutNumeric)).EndInit();
      this.ResumeLayout(false);

    }

        #endregion

        private System.Windows.Forms.TabControl configurationTabControl;
        private System.Windows.Forms.TabPage imagesTab;
        private System.Windows.Forms.TabPage liveCameraTab;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.Label label21;
        private System.Windows.Forms.ListView availableCamerasList;
        private System.Windows.Forms.Button removeCameraButton;
        private System.Windows.Forms.Button addCameraButton;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Label LiveCameraLabel;
    private System.Windows.Forms.TabPage motionPage;
    private System.Windows.Forms.Label label24;
    private System.Windows.Forms.NumericUpDown MotionTimeoutNumeric;
    private System.Windows.Forms.Label label23;
    private System.Windows.Forms.Label label20;
    private System.Windows.Forms.Panel CameraMethodPanel;
    private System.Windows.Forms.Button selectButton;
    private System.Windows.Forms.RadioButton radioHTTP;
    private System.Windows.Forms.RadioButton radioiSpy;
    private System.Windows.Forms.RadioButton radioOnVIF;
    private System.Windows.Forms.RadioButton radioBlueIris;
    private System.Windows.Forms.TextBox uriTextBox;
    private System.Windows.Forms.Label label25;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label13;
    private System.Windows.Forms.TextBox textBoxShortCameraName;
    private System.Windows.Forms.TabPage PTZTab;
    private System.Windows.Forms.Panel CameraPTZPanel;
    private System.Windows.Forms.Button SelectPTZMethodButton;
    private System.Windows.Forms.Label PTZCameraLabel;
    private System.Windows.Forms.Button ConfigureMovementButton;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.Label label33;
    private System.Windows.Forms.Label label34;
    private System.Windows.Forms.Label label35;
    private System.Windows.Forms.Label label36;
    private System.Windows.Forms.RadioButton radioButtonPTZNone;
    private System.Windows.Forms.Label label37;
    private System.Windows.Forms.RadioButton radioButtonPTZHTTP;
    private System.Windows.Forms.RadioButton radioButtonPTZiSpy;
    private System.Windows.Forms.RadioButton radioButtonPTZOnVIF;
    private System.Windows.Forms.RadioButton radioButtonPTZBlueIris;
    private System.Windows.Forms.TabPage PresetsTab;
    private System.Windows.Forms.Panel CameraPresetPanel;
    private System.Windows.Forms.GroupBox groupBox2;
    private System.Windows.Forms.Label label26;
    private System.Windows.Forms.Label label27;
    private System.Windows.Forms.Label label28;
    private System.Windows.Forms.Label label29;
    private System.Windows.Forms.RadioButton radioPresetNone;
    private System.Windows.Forms.Label label31;
    private System.Windows.Forms.RadioButton radioPresetHttp;
    private System.Windows.Forms.RadioButton radioPresetiSpy;
    private System.Windows.Forms.RadioButton radioPresetOnvif;
    private System.Windows.Forms.RadioButton radioPresetBlueIris;
    private System.Windows.Forms.Button buttonTestPresets;
    private System.Windows.Forms.Button buttonSelectPresetMethod;
    private System.Windows.Forms.Label PresetCameraLabel;
    private System.Windows.Forms.Label MotionTimeoutCameraLabel;
    private System.Windows.Forms.Label label22;
    private System.Windows.Forms.TabPage tabPageCameraContact;
    private System.Windows.Forms.Panel CameraAddressPanel;
    private System.Windows.Forms.Label label17;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.NumericUpDown OnVIFPortNumeric;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Label label16;
    private System.Windows.Forms.TextBox cameraIPAddressText;
    private System.Windows.Forms.Label label15;
    private System.Windows.Forms.NumericUpDown portNumeric;
    private System.Windows.Forms.Label label14;
    private System.Windows.Forms.TextBox cameraUserText;
    private System.Windows.Forms.Label label12;
    private System.Windows.Forms.TextBox cameraPasswordText;
    private System.Windows.Forms.Label label11;
    private System.Windows.Forms.Label AddressCameraLabel;
    private System.Windows.Forms.GroupBox CameraQualityGroupbox;
    private System.Windows.Forms.Label label41;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.NumericUpDown ChannelNumeric;
    private System.Windows.Forms.NumericUpDown cameraXResolutionNumeric;
    private System.Windows.Forms.Label label39;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.Label label40;
    private System.Windows.Forms.NumericUpDown cameraYResolutionNumeric;
    private System.Windows.Forms.Label label9;
    private System.Windows.Forms.Label PresetsCameraLabel;
    private System.Windows.Forms.Panel MonitorSubFoldersPanel;
    private System.Windows.Forms.CheckBox MonitorSubFoldersCheckbox;
    private System.Windows.Forms.Label label42;
    private System.Windows.Forms.Panel MotionTimeoutPanel;
    private System.Windows.Forms.Button AddCameraHelpButton;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.Button PictureQualityHelpButton;
    private System.Windows.Forms.Button CameraContactHelpButton;
    private System.Windows.Forms.Button PTZHelpButton;
    private System.Windows.Forms.Button PresetsHelpButton;
    private System.Windows.Forms.Button CameraAddressHelpButton;
    private System.Windows.Forms.Button EditCameraButton;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Button RemovePresetButton;
    private System.Windows.Forms.Button EditPresetButton;
    private System.Windows.Forms.Button AddPresetButton;
    private System.Windows.Forms.ListView PresetsListView;
    private System.Windows.Forms.ColumnHeader columnHeader1;
    private System.Windows.Forms.ColumnHeader columnHeader2;
    private System.Windows.Forms.ColumnHeader columnHeader5;
    private System.Windows.Forms.Label label10;
    private System.Windows.Forms.NumericUpDown Latitude;
    private System.Windows.Forms.NumericUpDown Longitude;
    private System.Windows.Forms.Label label38;
    private System.Windows.Forms.Label label32;
    private System.Windows.Forms.Label label30;
    private System.Windows.Forms.Label label19;
  }
}