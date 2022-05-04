

namespace OnGuardCore
{
  partial class SettingsDialog
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
      this.okButton = new System.Windows.Forms.Button();
      this.cancelButton = new System.Windows.Forms.Button();
      this.SQLPanel = new System.Windows.Forms.Panel();
      this.FormHelpButton = new System.Windows.Forms.Button();
      this.UseCustomButton = new System.Windows.Forms.Button();
      this.GetDefaultButton = new System.Windows.Forms.Button();
      this.ConnectionStringText = new System.Windows.Forms.TextBox();
      this.label3 = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.LogPanel = new System.Windows.Forms.Panel();
      this.label15 = new System.Windows.Forms.Label();
      this.LogViewerText = new System.Windows.Forms.TextBox();
      this.label14 = new System.Windows.Forms.Label();
      this.label12 = new System.Windows.Forms.Label();
      this.label5 = new System.Windows.Forms.Label();
      this.label6 = new System.Windows.Forms.Label();
      this.SetDataFolderButton = new System.Windows.Forms.Button();
      this.panel2 = new System.Windows.Forms.Panel();
      this.label11 = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.ipAddressText = new System.Windows.Forms.TextBox();
      this.label7 = new System.Windows.Forms.Label();
      this.portNumeric = new System.Windows.Forms.NumericUpDown();
      this.testButton = new System.Windows.Forms.Button();
      this.label2 = new System.Windows.Forms.Label();
      this.label8 = new System.Windows.Forms.Label();
      this.AutoStartDeepStackCheck = new System.Windows.Forms.CheckBox();
      this.FaceCheckbox = new System.Windows.Forms.CheckBox();
      this.AIPanel = new System.Windows.Forms.Panel();
      this.threadCountNumeric = new System.Windows.Forms.NumericUpDown();
      this.label16 = new System.Windows.Forms.Label();
      this.AutoStopDeepStackCheck = new System.Windows.Forms.CheckBox();
      this.StartAIButton = new System.Windows.Forms.Button();
      this.ButtonCustom = new System.Windows.Forms.Button();
      this.FinalDeepStackTextBox = new System.Windows.Forms.TextBox();
      this.label13 = new System.Windows.Forms.Label();
      this.CustomTextBox = new System.Windows.Forms.TextBox();
      this.label10 = new System.Windows.Forms.Label();
      this.OutputVisibleCheckbox = new System.Windows.Forms.CheckBox();
      this.panel5 = new System.Windows.Forms.Panel();
      this.ModeMediumRadio = new System.Windows.Forms.RadioButton();
      this.ModeLowRadio = new System.Windows.Forms.RadioButton();
      this.ModeHighRadio = new System.Windows.Forms.RadioButton();
      this.label9 = new System.Windows.Forms.Label();
      this.SQLPanel.SuspendLayout();
      this.LogPanel.SuspendLayout();
      this.panel2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.portNumeric)).BeginInit();
      this.AIPanel.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.threadCountNumeric)).BeginInit();
      this.panel5.SuspendLayout();
      this.SuspendLayout();
      // 
      // okButton
      // 
      this.okButton.Enabled = false;
      this.okButton.Location = new System.Drawing.Point(274, 713);
      this.okButton.Name = "okButton";
      this.okButton.Size = new System.Drawing.Size(85, 23);
      this.okButton.TabIndex = 0;
      this.okButton.Text = "OK";
      this.okButton.UseVisualStyleBackColor = true;
      this.okButton.Click += new System.EventHandler(this.OkButton_Click);
      // 
      // cancelButton
      // 
      this.cancelButton.Location = new System.Drawing.Point(366, 713);
      this.cancelButton.Name = "cancelButton";
      this.cancelButton.Size = new System.Drawing.Size(85, 23);
      this.cancelButton.TabIndex = 1;
      this.cancelButton.Text = "Cancel";
      this.cancelButton.UseVisualStyleBackColor = true;
      this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
      // 
      // SQLPanel
      // 
      this.SQLPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.SQLPanel.Controls.Add(this.FormHelpButton);
      this.SQLPanel.Controls.Add(this.UseCustomButton);
      this.SQLPanel.Controls.Add(this.GetDefaultButton);
      this.SQLPanel.Controls.Add(this.ConnectionStringText);
      this.SQLPanel.Controls.Add(this.label3);
      this.SQLPanel.Controls.Add(this.label1);
      this.SQLPanel.Enabled = false;
      this.SQLPanel.Location = new System.Drawing.Point(26, 463);
      this.SQLPanel.Name = "SQLPanel";
      this.SQLPanel.Size = new System.Drawing.Size(678, 101);
      this.SQLPanel.TabIndex = 12;
      // 
      // FormHelpButton
      // 
      this.FormHelpButton.Location = new System.Drawing.Point(582, 67);
      this.FormHelpButton.Name = "FormHelpButton";
      this.FormHelpButton.Size = new System.Drawing.Size(75, 23);
      this.FormHelpButton.TabIndex = 3;
      this.FormHelpButton.Text = "Help!";
      this.FormHelpButton.UseVisualStyleBackColor = true;
      this.FormHelpButton.Click += new System.EventHandler(this.HelpButton_Click);
      // 
      // UseCustomButton
      // 
      this.UseCustomButton.Location = new System.Drawing.Point(344, 67);
      this.UseCustomButton.Name = "UseCustomButton";
      this.UseCustomButton.Size = new System.Drawing.Size(128, 23);
      this.UseCustomButton.TabIndex = 2;
      this.UseCustomButton.Text = "Use Custom Setting";
      this.UseCustomButton.UseVisualStyleBackColor = true;
      this.UseCustomButton.Click += new System.EventHandler(this.UseCustomButton_Click);
      // 
      // GetDefaultButton
      // 
      this.GetDefaultButton.Location = new System.Drawing.Point(204, 67);
      this.GetDefaultButton.Name = "GetDefaultButton";
      this.GetDefaultButton.Size = new System.Drawing.Size(128, 23);
      this.GetDefaultButton.TabIndex = 1;
      this.GetDefaultButton.Text = "Get Default Setting";
      this.GetDefaultButton.UseVisualStyleBackColor = true;
      this.GetDefaultButton.Click += new System.EventHandler(this.GetDefaultButton_Click);
      // 
      // ConnectionStringText
      // 
      this.ConnectionStringText.Location = new System.Drawing.Point(145, 31);
      this.ConnectionStringText.Name = "ConnectionStringText";
      this.ConnectionStringText.Size = new System.Drawing.Size(512, 23);
      this.ConnectionStringText.TabIndex = 0;
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(22, 34);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(103, 15);
      this.label3.TabIndex = 11;
      this.label3.Text = "Connection String";
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.label1.Location = new System.Drawing.Point(248, 10);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(161, 16);
      this.label1.TabIndex = 9;
      this.label1.Text = "SQL Connection String";
      // 
      // LogPanel
      // 
      this.LogPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.LogPanel.Controls.Add(this.label15);
      this.LogPanel.Controls.Add(this.LogViewerText);
      this.LogPanel.Controls.Add(this.label14);
      this.LogPanel.Controls.Add(this.label12);
      this.LogPanel.Enabled = false;
      this.LogPanel.Location = new System.Drawing.Point(26, 570);
      this.LogPanel.Name = "LogPanel";
      this.LogPanel.Size = new System.Drawing.Size(678, 131);
      this.LogPanel.TabIndex = 13;
      // 
      // label15
      // 
      this.label15.AutoSize = true;
      this.label15.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      this.label15.Location = new System.Drawing.Point(136, 89);
      this.label15.Name = "label15";
      this.label15.Size = new System.Drawing.Size(54, 17);
      this.label15.TabIndex = 13;
      this.label15.Text = "Viewer: ";
      // 
      // LogViewerText
      // 
      this.LogViewerText.Location = new System.Drawing.Point(202, 88);
      this.LogViewerText.Name = "LogViewerText";
      this.LogViewerText.Size = new System.Drawing.Size(332, 23);
      this.LogViewerText.TabIndex = 0;
      this.LogViewerText.Text = "Notepad.exe";
      // 
      // label14
      // 
      this.label14.Location = new System.Drawing.Point(34, 38);
      this.label14.Name = "label14";
      this.label14.Size = new System.Drawing.Size(609, 39);
      this.label14.TabIndex = 11;
      this.label14.Text = "Specify the executable file that you would like to use for your log file viewer. " +
    " Usually \"Notepad.exe\" works well.\r\n";
      // 
      // label12
      // 
      this.label12.AutoSize = true;
      this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.label12.Location = new System.Drawing.Point(300, 11);
      this.label12.Name = "label12";
      this.label12.Size = new System.Drawing.Size(114, 16);
      this.label12.TabIndex = 9;
      this.label12.Text = "Log File Viewer";
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.label5.Location = new System.Drawing.Point(20, 18);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(333, 16);
      this.label5.TabIndex = 14;
      this.label5.Text = "On Guard Data File Folder Location (Required!)";
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.label6.Location = new System.Drawing.Point(305, 9);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(156, 18);
      this.label6.TabIndex = 15;
      this.label6.Text = "Application Settings";
      // 
      // SetDataFolderButton
      // 
      this.SetDataFolderButton.BackColor = System.Drawing.Color.Salmon;
      this.SetDataFolderButton.Location = new System.Drawing.Point(358, 9);
      this.SetDataFolderButton.Name = "SetDataFolderButton";
      this.SetDataFolderButton.Size = new System.Drawing.Size(137, 34);
      this.SetDataFolderButton.TabIndex = 0;
      this.SetDataFolderButton.Text = "Set Data Folder";
      this.SetDataFolderButton.UseVisualStyleBackColor = false;
      this.SetDataFolderButton.Click += new System.EventHandler(this.SetDataFolderButton_Click);
      // 
      // panel2
      // 
      this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.panel2.Controls.Add(this.label11);
      this.panel2.Controls.Add(this.SetDataFolderButton);
      this.panel2.Controls.Add(this.label5);
      this.panel2.Location = new System.Drawing.Point(26, 42);
      this.panel2.Name = "panel2";
      this.panel2.Size = new System.Drawing.Size(684, 52);
      this.panel2.TabIndex = 16;
      // 
      // label11
      // 
      this.label11.AutoSize = true;
      this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.label11.Location = new System.Drawing.Point(500, 18);
      this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label11.Name = "label11";
      this.label11.Size = new System.Drawing.Size(145, 16);
      this.label11.TabIndex = 22;
      this.label11.Text = "<---- Do This FIRST!";
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.label4.Location = new System.Drawing.Point(258, 11);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(160, 16);
      this.label4.TabIndex = 12;
      this.label4.Text = "Deepstack AI Settings";
      // 
      // ipAddressText
      // 
      this.ipAddressText.Location = new System.Drawing.Point(297, 43);
      this.ipAddressText.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
      this.ipAddressText.Name = "ipAddressText";
      this.ipAddressText.Size = new System.Drawing.Size(156, 20);
      this.ipAddressText.TabIndex = 0;
      this.ipAddressText.Text = "localhost";
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.Location = new System.Drawing.Point(68, 81);
      this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(146, 13);
      this.label7.TabIndex = 20;
      this.label7.Text = "Port Number fof the AI:  ";
      // 
      // portNumeric
      // 
      this.portNumeric.Location = new System.Drawing.Point(229, 79);
      this.portNumeric.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
      this.portNumeric.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
      this.portNumeric.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
      this.portNumeric.Name = "portNumeric";
      this.portNumeric.Size = new System.Drawing.Size(67, 20);
      this.portNumeric.TabIndex = 1;
      this.portNumeric.Value = new decimal(new int[] {
            8090,
            0,
            0,
            0});
      this.portNumeric.ValueChanged += new System.EventHandler(this.OnPortChanged);
      // 
      // testButton
      // 
      this.testButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
      this.testButton.Location = new System.Drawing.Point(270, 297);
      this.testButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
      this.testButton.Name = "testButton";
      this.testButton.Size = new System.Drawing.Size(223, 32);
      this.testButton.TabIndex = 11;
      this.testButton.Text = "Test DeepStack Connection";
      this.testButton.UseVisualStyleBackColor = false;
      this.testButton.Click += new System.EventHandler(this.testButton_Click);
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.label2.Location = new System.Drawing.Point(499, 305);
      this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(107, 16);
      this.label2.TabIndex = 21;
      this.label2.Text = "<---- Important!";
      // 
      // label8
      // 
      this.label8.AutoSize = true;
      this.label8.Location = new System.Drawing.Point(44, 46);
      this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label8.Name = "label8";
      this.label8.Size = new System.Drawing.Size(238, 13);
      this.label8.TabIndex = 22;
      this.label8.Text = "IP Address or computer name  of the  AI:";
      // 
      // AutoStartDeepStackCheck
      // 
      this.AutoStartDeepStackCheck.AutoSize = true;
      this.AutoStartDeepStackCheck.Checked = true;
      this.AutoStartDeepStackCheck.CheckState = System.Windows.Forms.CheckState.Checked;
      this.AutoStartDeepStackCheck.Location = new System.Drawing.Point(295, 120);
      this.AutoStartDeepStackCheck.Name = "AutoStartDeepStackCheck";
      this.AutoStartDeepStackCheck.Size = new System.Drawing.Size(166, 17);
      this.AutoStartDeepStackCheck.TabIndex = 4;
      this.AutoStartDeepStackCheck.Text = "Auto Start DeepStack AI";
      this.AutoStartDeepStackCheck.UseVisualStyleBackColor = true;
      // 
      // FaceCheckbox
      // 
      this.FaceCheckbox.AutoSize = true;
      this.FaceCheckbox.Location = new System.Drawing.Point(295, 189);
      this.FaceCheckbox.Name = "FaceCheckbox";
      this.FaceCheckbox.Size = new System.Drawing.Size(139, 17);
      this.FaceCheckbox.TabIndex = 7;
      this.FaceCheckbox.Text = "Use Face Detection";
      this.FaceCheckbox.UseVisualStyleBackColor = true;
      this.FaceCheckbox.CheckedChanged += new System.EventHandler(this.OnFaceCheckChanged);
      // 
      // AIPanel
      // 
      this.AIPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.AIPanel.Controls.Add(this.threadCountNumeric);
      this.AIPanel.Controls.Add(this.label16);
      this.AIPanel.Controls.Add(this.AutoStopDeepStackCheck);
      this.AIPanel.Controls.Add(this.StartAIButton);
      this.AIPanel.Controls.Add(this.ButtonCustom);
      this.AIPanel.Controls.Add(this.FinalDeepStackTextBox);
      this.AIPanel.Controls.Add(this.label13);
      this.AIPanel.Controls.Add(this.CustomTextBox);
      this.AIPanel.Controls.Add(this.label10);
      this.AIPanel.Controls.Add(this.OutputVisibleCheckbox);
      this.AIPanel.Controls.Add(this.panel5);
      this.AIPanel.Controls.Add(this.FaceCheckbox);
      this.AIPanel.Controls.Add(this.AutoStartDeepStackCheck);
      this.AIPanel.Controls.Add(this.label8);
      this.AIPanel.Controls.Add(this.label2);
      this.AIPanel.Controls.Add(this.testButton);
      this.AIPanel.Controls.Add(this.portNumeric);
      this.AIPanel.Controls.Add(this.label7);
      this.AIPanel.Controls.Add(this.ipAddressText);
      this.AIPanel.Controls.Add(this.label4);
      this.AIPanel.Enabled = false;
      this.AIPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.AIPanel.Location = new System.Drawing.Point(26, 107);
      this.AIPanel.Name = "AIPanel";
      this.AIPanel.Size = new System.Drawing.Size(678, 343);
      this.AIPanel.TabIndex = 11;
      // 
      // threadCountNumeric
      // 
      this.threadCountNumeric.Location = new System.Drawing.Point(427, 79);
      this.threadCountNumeric.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
      this.threadCountNumeric.Maximum = new decimal(new int[] {
            128,
            0,
            0,
            0});
      this.threadCountNumeric.Name = "threadCountNumeric";
      this.threadCountNumeric.Size = new System.Drawing.Size(48, 20);
      this.threadCountNumeric.TabIndex = 33;
      // 
      // label16
      // 
      this.label16.AutoSize = true;
      this.label16.Location = new System.Drawing.Point(314, 81);
      this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label16.Name = "label16";
      this.label16.Size = new System.Drawing.Size(100, 13);
      this.label16.TabIndex = 34;
      this.label16.Text = "AI Thread Count";
      // 
      // AutoStopDeepStackCheck
      // 
      this.AutoStopDeepStackCheck.AutoSize = true;
      this.AutoStopDeepStackCheck.Checked = true;
      this.AutoStopDeepStackCheck.CheckState = System.Windows.Forms.CheckState.Checked;
      this.AutoStopDeepStackCheck.Location = new System.Drawing.Point(295, 143);
      this.AutoStopDeepStackCheck.Name = "AutoStopDeepStackCheck";
      this.AutoStopDeepStackCheck.Size = new System.Drawing.Size(165, 17);
      this.AutoStopDeepStackCheck.TabIndex = 5;
      this.AutoStopDeepStackCheck.Text = "Auto Stop DeepStack AI";
      this.AutoStopDeepStackCheck.UseVisualStyleBackColor = true;
      // 
      // StartAIButton
      // 
      this.StartAIButton.BackColor = System.Drawing.Color.LightGreen;
      this.StartAIButton.Location = new System.Drawing.Point(71, 297);
      this.StartAIButton.Name = "StartAIButton";
      this.StartAIButton.Size = new System.Drawing.Size(182, 32);
      this.StartAIButton.TabIndex = 10;
      this.StartAIButton.Text = "Start/Restart DeepStack AI";
      this.StartAIButton.UseVisualStyleBackColor = false;
      this.StartAIButton.Click += new System.EventHandler(this.StartAIButton_Click);
      // 
      // ButtonCustom
      // 
      this.ButtonCustom.Location = new System.Drawing.Point(417, 223);
      this.ButtonCustom.Name = "ButtonCustom";
      this.ButtonCustom.Size = new System.Drawing.Size(144, 23);
      this.ButtonCustom.TabIndex = 9;
      this.ButtonCustom.Text = "Apply Custom Settings";
      this.ButtonCustom.UseVisualStyleBackColor = true;
      this.ButtonCustom.Click += new System.EventHandler(this.ButtonCustom_Click);
      // 
      // FinalDeepStackTextBox
      // 
      this.FinalDeepStackTextBox.Location = new System.Drawing.Point(148, 262);
      this.FinalDeepStackTextBox.Name = "FinalDeepStackTextBox";
      this.FinalDeepStackTextBox.ReadOnly = true;
      this.FinalDeepStackTextBox.Size = new System.Drawing.Size(509, 20);
      this.FinalDeepStackTextBox.TabIndex = 32;
      // 
      // label13
      // 
      this.label13.AutoSize = true;
      this.label13.Location = new System.Drawing.Point(7, 265);
      this.label13.Name = "label13";
      this.label13.Size = new System.Drawing.Size(129, 13);
      this.label13.TabIndex = 31;
      this.label13.Text = "Final Startup Settings";
      // 
      // CustomTextBox
      // 
      this.CustomTextBox.Location = new System.Drawing.Point(161, 225);
      this.CustomTextBox.Name = "CustomTextBox";
      this.CustomTextBox.Size = new System.Drawing.Size(248, 20);
      this.CustomTextBox.TabIndex = 8;
      // 
      // label10
      // 
      this.label10.AutoSize = true;
      this.label10.Location = new System.Drawing.Point(7, 228);
      this.label10.Name = "label10";
      this.label10.Size = new System.Drawing.Size(143, 13);
      this.label10.TabIndex = 28;
      this.label10.Text = "Custom Startup Settings";
      // 
      // OutputVisibleCheckbox
      // 
      this.OutputVisibleCheckbox.AutoSize = true;
      this.OutputVisibleCheckbox.Checked = true;
      this.OutputVisibleCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
      this.OutputVisibleCheckbox.Location = new System.Drawing.Point(295, 166);
      this.OutputVisibleCheckbox.Name = "OutputVisibleCheckbox";
      this.OutputVisibleCheckbox.Size = new System.Drawing.Size(163, 17);
      this.OutputVisibleCheckbox.TabIndex = 6;
      this.OutputVisibleCheckbox.Text = "DeepStack AI  is Visible";
      this.OutputVisibleCheckbox.UseVisualStyleBackColor = true;
      // 
      // panel5
      // 
      this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.panel5.Controls.Add(this.ModeMediumRadio);
      this.panel5.Controls.Add(this.ModeLowRadio);
      this.panel5.Controls.Add(this.ModeHighRadio);
      this.panel5.Controls.Add(this.label9);
      this.panel5.Location = new System.Drawing.Point(127, 109);
      this.panel5.Name = "panel5";
      this.panel5.Size = new System.Drawing.Size(147, 100);
      this.panel5.TabIndex = 3;
      // 
      // ModeMediumRadio
      // 
      this.ModeMediumRadio.AutoSize = true;
      this.ModeMediumRadio.Location = new System.Drawing.Point(14, 52);
      this.ModeMediumRadio.Name = "ModeMediumRadio";
      this.ModeMediumRadio.Size = new System.Drawing.Size(68, 17);
      this.ModeMediumRadio.TabIndex = 24;
      this.ModeMediumRadio.Text = "Medium";
      this.ModeMediumRadio.UseVisualStyleBackColor = true;
      this.ModeMediumRadio.CheckedChanged += new System.EventHandler(this.OnModeChanged);
      // 
      // ModeLowRadio
      // 
      this.ModeLowRadio.AutoSize = true;
      this.ModeLowRadio.Location = new System.Drawing.Point(14, 74);
      this.ModeLowRadio.Name = "ModeLowRadio";
      this.ModeLowRadio.Size = new System.Drawing.Size(84, 17);
      this.ModeLowRadio.TabIndex = 1;
      this.ModeLowRadio.Text = "Low (Fast)";
      this.ModeLowRadio.UseVisualStyleBackColor = true;
      this.ModeLowRadio.CheckedChanged += new System.EventHandler(this.OnModeChanged);
      // 
      // ModeHighRadio
      // 
      this.ModeHighRadio.AutoSize = true;
      this.ModeHighRadio.Checked = true;
      this.ModeHighRadio.Location = new System.Drawing.Point(14, 30);
      this.ModeHighRadio.Name = "ModeHighRadio";
      this.ModeHighRadio.Size = new System.Drawing.Size(132, 17);
      this.ModeHighRadio.TabIndex = 22;
      this.ModeHighRadio.TabStop = true;
      this.ModeHighRadio.Text = "High (Best/Slower)";
      this.ModeHighRadio.UseVisualStyleBackColor = true;
      this.ModeHighRadio.CheckedChanged += new System.EventHandler(this.OnModeChanged);
      // 
      // label9
      // 
      this.label9.AutoSize = true;
      this.label9.Location = new System.Drawing.Point(20, 7);
      this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label9.Name = "label9";
      this.label9.Size = new System.Drawing.Size(105, 13);
      this.label9.TabIndex = 0;
      this.label9.Text = "Detection Mode  ";
      // 
      // SettingsDialog
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
      this.AutoScroll = true;
      this.ClientSize = new System.Drawing.Size(724, 743);
      this.Controls.Add(this.panel2);
      this.Controls.Add(this.label6);
      this.Controls.Add(this.LogPanel);
      this.Controls.Add(this.SQLPanel);
      this.Controls.Add(this.AIPanel);
      this.Controls.Add(this.cancelButton);
      this.Controls.Add(this.okButton);
      this.Name = "SettingsDialog";
      this.Text = "Application Settings";
      this.SQLPanel.ResumeLayout(false);
      this.SQLPanel.PerformLayout();
      this.LogPanel.ResumeLayout(false);
      this.LogPanel.PerformLayout();
      this.panel2.ResumeLayout(false);
      this.panel2.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.portNumeric)).EndInit();
      this.AIPanel.ResumeLayout(false);
      this.AIPanel.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.threadCountNumeric)).EndInit();
      this.panel5.ResumeLayout(false);
      this.panel5.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

        #endregion

        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
    private System.Windows.Forms.Panel SQLPanel;
    private System.Windows.Forms.Button UseCustomButton;
    private System.Windows.Forms.Button GetDefaultButton;
    private System.Windows.Forms.TextBox ConnectionStringText;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Panel LogPanel;
    private System.Windows.Forms.Label label15;
    private System.Windows.Forms.TextBox LogViewerText;
    private System.Windows.Forms.Label label14;
    private System.Windows.Forms.Label label12;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.Button SetDataFolderButton;
    private System.Windows.Forms.Panel panel2;
    private System.Windows.Forms.Button FormHelpButton;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.TextBox ipAddressText;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.NumericUpDown portNumeric;
    private System.Windows.Forms.Button testButton;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.CheckBox AutoStartDeepStackCheck;
    private System.Windows.Forms.CheckBox FaceCheckbox;
    private System.Windows.Forms.Panel AIPanel;
    private System.Windows.Forms.Panel panel5;
    private System.Windows.Forms.RadioButton ModeMediumRadio;
    private System.Windows.Forms.RadioButton ModeLowRadio;
    private System.Windows.Forms.RadioButton ModeHighRadio;
    private System.Windows.Forms.Label label9;
    private System.Windows.Forms.TextBox CustomTextBox;
    private System.Windows.Forms.Label label10;
    private System.Windows.Forms.CheckBox OutputVisibleCheckbox;
    private System.Windows.Forms.Button ButtonCustom;
    private System.Windows.Forms.TextBox FinalDeepStackTextBox;
    private System.Windows.Forms.Label label13;
    private System.Windows.Forms.Button StartAIButton;
    private System.Windows.Forms.CheckBox AutoStopDeepStackCheck;
    private System.Windows.Forms.Label label11;
    private System.Windows.Forms.NumericUpDown threadCountNumeric;
    private System.Windows.Forms.Label label16;
  }
}