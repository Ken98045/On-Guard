

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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsDialog));
      this.okButton = new System.Windows.Forms.Button();
      this.cancelButton = new System.Windows.Forms.Button();
      this.label4 = new System.Windows.Forms.Label();
      this.label5 = new System.Windows.Forms.Label();
      this.snapshotNumeric = new System.Windows.Forms.NumericUpDown();
      this.label6 = new System.Windows.Forms.Label();
      this.panel1 = new System.Windows.Forms.Panel();
      this.label10 = new System.Windows.Forms.Label();
      this.RefreshButton = new System.Windows.Forms.Button();
      this.RemoveButton = new System.Windows.Forms.Button();
      this.AddButton = new System.Windows.Forms.Button();
      this.aiLocationListView = new System.Windows.Forms.ListView();
      this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
      this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
      this.panel2 = new System.Windows.Forms.Panel();
      this.label13 = new System.Windows.Forms.Label();
      this.label11 = new System.Windows.Forms.Label();
      this.eventIntervalNumeric = new System.Windows.Forms.NumericUpDown();
      this.label8 = new System.Windows.Forms.Label();
      this.label9 = new System.Windows.Forms.Label();
      this.maxEventNumeric = new System.Windows.Forms.NumericUpDown();
      this.label7 = new System.Windows.Forms.Label();
      this.panel3 = new System.Windows.Forms.Panel();
      this.UseCustomButton = new System.Windows.Forms.Button();
      this.GetDefaultButton = new System.Windows.Forms.Button();
      this.ConnectionStringText = new System.Windows.Forms.TextBox();
      this.label3 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.panel4 = new System.Windows.Forms.Panel();
      this.label12 = new System.Windows.Forms.Label();
      this.label14 = new System.Windows.Forms.Label();
      this.LogViewerText = new System.Windows.Forms.TextBox();
      this.label15 = new System.Windows.Forms.Label();
      ((System.ComponentModel.ISupportInitialize)(this.snapshotNumeric)).BeginInit();
      this.panel1.SuspendLayout();
      this.panel2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.eventIntervalNumeric)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.maxEventNumeric)).BeginInit();
      this.panel3.SuspendLayout();
      this.panel4.SuspendLayout();
      this.SuspendLayout();
      // 
      // okButton
      // 
      this.okButton.Location = new System.Drawing.Point(293, 838);
      this.okButton.Name = "okButton";
      this.okButton.Size = new System.Drawing.Size(85, 23);
      this.okButton.TabIndex = 0;
      this.okButton.Text = "OK";
      this.okButton.UseVisualStyleBackColor = true;
      this.okButton.Click += new System.EventHandler(this.OkButton_Click);
      // 
      // cancelButton
      // 
      this.cancelButton.Location = new System.Drawing.Point(390, 838);
      this.cancelButton.Name = "cancelButton";
      this.cancelButton.Size = new System.Drawing.Size(85, 23);
      this.cancelButton.TabIndex = 1;
      this.cancelButton.Text = "Cancel";
      this.cancelButton.UseVisualStyleBackColor = true;
      this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.label4.Location = new System.Drawing.Point(244, 10);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(225, 16);
      this.label4.TabIndex = 7;
      this.label4.Text = "Location of the DeepStack AI(s)";
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(31, 45);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(104, 15);
      this.label5.TabIndex = 0;
      this.label5.Text = "Snapshot Interval: ";
      // 
      // snapshotNumeric
      // 
      this.snapshotNumeric.DecimalPlaces = 2;
      this.snapshotNumeric.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
      this.snapshotNumeric.Location = new System.Drawing.Point(133, 43);
      this.snapshotNumeric.Maximum = new decimal(new int[] {
            120,
            0,
            0,
            0});
      this.snapshotNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
      this.snapshotNumeric.Name = "snapshotNumeric";
      this.snapshotNumeric.Size = new System.Drawing.Size(55, 23);
      this.snapshotNumeric.TabIndex = 0;
      this.snapshotNumeric.Value = new decimal(new int[] {
            10,
            0,
            0,
            65536});
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Location = new System.Drawing.Point(198, 47);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(420, 15);
      this.label6.TabIndex = 10;
      this.label6.Text = "Seconds -  Typically from Blue Iris Camera Settings.  The time between pictures";
      // 
      // panel1
      // 
      this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.panel1.Controls.Add(this.label10);
      this.panel1.Controls.Add(this.RefreshButton);
      this.panel1.Controls.Add(this.RemoveButton);
      this.panel1.Controls.Add(this.AddButton);
      this.panel1.Controls.Add(this.aiLocationListView);
      this.panel1.Controls.Add(this.label4);
      this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.panel1.Location = new System.Drawing.Point(12, -7);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(717, 285);
      this.panel1.TabIndex = 11;
      // 
      // label10
      // 
      this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.label10.Location = new System.Drawing.Point(562, 44);
      this.label10.Name = "label10";
      this.label10.Size = new System.Drawing.Size(150, 187);
      this.label10.TabIndex = 11;
      this.label10.Text = resources.GetString("label10.Text");
      // 
      // RefreshButton
      // 
      this.RefreshButton.Location = new System.Drawing.Point(399, 245);
      this.RefreshButton.Name = "RefreshButton";
      this.RefreshButton.Size = new System.Drawing.Size(62, 23);
      this.RefreshButton.TabIndex = 2;
      this.RefreshButton.Text = "Refresh";
      this.RefreshButton.UseVisualStyleBackColor = true;
      this.RefreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
      // 
      // RemoveButton
      // 
      this.RemoveButton.Location = new System.Drawing.Point(326, 245);
      this.RemoveButton.Name = "RemoveButton";
      this.RemoveButton.Size = new System.Drawing.Size(62, 23);
      this.RemoveButton.TabIndex = 1;
      this.RemoveButton.Text = "Remove";
      this.RemoveButton.UseVisualStyleBackColor = true;
      this.RemoveButton.Click += new System.EventHandler(this.RemoveButton_Click);
      // 
      // AddButton
      // 
      this.AddButton.Location = new System.Drawing.Point(253, 245);
      this.AddButton.Name = "AddButton";
      this.AddButton.Size = new System.Drawing.Size(62, 23);
      this.AddButton.TabIndex = 0;
      this.AddButton.Text = "Add";
      this.AddButton.UseVisualStyleBackColor = true;
      this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
      // 
      // aiLocationListView
      // 
      this.aiLocationListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
      this.aiLocationListView.FullRowSelect = true;
      this.aiLocationListView.HideSelection = false;
      this.aiLocationListView.Location = new System.Drawing.Point(166, 44);
      this.aiLocationListView.Name = "aiLocationListView";
      this.aiLocationListView.Size = new System.Drawing.Size(383, 187);
      this.aiLocationListView.TabIndex = 10;
      this.aiLocationListView.UseCompatibleStateImageBehavior = false;
      this.aiLocationListView.View = System.Windows.Forms.View.Details;
      this.aiLocationListView.ItemActivate += new System.EventHandler(this.OnActivate);
      // 
      // columnHeader1
      // 
      this.columnHeader1.Name = "columnHeader1";
      this.columnHeader1.Text = "IP Address";
      this.columnHeader1.Width = 242;
      // 
      // columnHeader2
      // 
      this.columnHeader2.Name = "columnHeader2";
      this.columnHeader2.Text = "Port";
      this.columnHeader2.Width = 120;
      // 
      // panel2
      // 
      this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.panel2.Controls.Add(this.label13);
      this.panel2.Controls.Add(this.label11);
      this.panel2.Controls.Add(this.eventIntervalNumeric);
      this.panel2.Controls.Add(this.label8);
      this.panel2.Controls.Add(this.label9);
      this.panel2.Controls.Add(this.maxEventNumeric);
      this.panel2.Controls.Add(this.label7);
      this.panel2.Controls.Add(this.label6);
      this.panel2.Controls.Add(this.label5);
      this.panel2.Controls.Add(this.snapshotNumeric);
      this.panel2.Location = new System.Drawing.Point(12, 491);
      this.panel2.Name = "panel2";
      this.panel2.Size = new System.Drawing.Size(717, 178);
      this.panel2.TabIndex = 0;
      // 
      // label13
      // 
      this.label13.Location = new System.Drawing.Point(198, 133);
      this.label13.Name = "label13";
      this.label13.Size = new System.Drawing.Size(479, 39);
      this.label13.TabIndex = 16;
      this.label13.Text = resources.GetString("label13.Text");
      // 
      // label11
      // 
      this.label11.AutoSize = true;
      this.label11.Location = new System.Drawing.Point(10, 140);
      this.label11.Name = "label11";
      this.label11.Size = new System.Drawing.Size(124, 15);
      this.label11.TabIndex = 1;
      this.label11.Text = "Time Between Events: ";
      // 
      // eventIntervalNumeric
      // 
      this.eventIntervalNumeric.Location = new System.Drawing.Point(133, 138);
      this.eventIntervalNumeric.Maximum = new decimal(new int[] {
            120,
            0,
            0,
            0});
      this.eventIntervalNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.eventIntervalNumeric.Name = "eventIntervalNumeric";
      this.eventIntervalNumeric.Size = new System.Drawing.Size(55, 23);
      this.eventIntervalNumeric.TabIndex = 2;
      this.eventIntervalNumeric.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
      // 
      // label8
      // 
      this.label8.Location = new System.Drawing.Point(198, 76);
      this.label8.Name = "label8";
      this.label8.Size = new System.Drawing.Size(499, 47);
      this.label8.TabIndex = 13;
      this.label8.Text = resources.GetString("label8.Text");
      // 
      // label9
      // 
      this.label9.AutoSize = true;
      this.label9.Location = new System.Drawing.Point(13, 89);
      this.label9.Name = "label9";
      this.label9.Size = new System.Drawing.Size(129, 15);
      this.label9.TabIndex = 12;
      this.label9.Text = "Maximum Event Time: ";
      // 
      // maxEventNumeric
      // 
      this.maxEventNumeric.Location = new System.Drawing.Point(133, 87);
      this.maxEventNumeric.Maximum = new decimal(new int[] {
            120,
            0,
            0,
            0});
      this.maxEventNumeric.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
      this.maxEventNumeric.Name = "maxEventNumeric";
      this.maxEventNumeric.Size = new System.Drawing.Size(55, 23);
      this.maxEventNumeric.TabIndex = 1;
      this.maxEventNumeric.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.label7.Location = new System.Drawing.Point(252, 13);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(210, 16);
      this.label7.TabIndex = 8;
      this.label7.Text = "Image Capture and Reporting";
      // 
      // panel3
      // 
      this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.panel3.Controls.Add(this.UseCustomButton);
      this.panel3.Controls.Add(this.GetDefaultButton);
      this.panel3.Controls.Add(this.ConnectionStringText);
      this.panel3.Controls.Add(this.label3);
      this.panel3.Controls.Add(this.label2);
      this.panel3.Controls.Add(this.label1);
      this.panel3.Location = new System.Drawing.Point(12, 310);
      this.panel3.Name = "panel3";
      this.panel3.Size = new System.Drawing.Size(717, 173);
      this.panel3.TabIndex = 12;
      // 
      // UseCustomButton
      // 
      this.UseCustomButton.Location = new System.Drawing.Point(363, 138);
      this.UseCustomButton.Name = "UseCustomButton";
      this.UseCustomButton.Size = new System.Drawing.Size(128, 23);
      this.UseCustomButton.TabIndex = 2;
      this.UseCustomButton.Text = "Use Custom Setting";
      this.UseCustomButton.UseVisualStyleBackColor = true;
      this.UseCustomButton.Click += new System.EventHandler(this.UseCustomButton_Click);
      // 
      // GetDefaultButton
      // 
      this.GetDefaultButton.Location = new System.Drawing.Point(223, 138);
      this.GetDefaultButton.Name = "GetDefaultButton";
      this.GetDefaultButton.Size = new System.Drawing.Size(128, 23);
      this.GetDefaultButton.TabIndex = 1;
      this.GetDefaultButton.Text = "Get Default Setting";
      this.GetDefaultButton.UseVisualStyleBackColor = true;
      this.GetDefaultButton.Click += new System.EventHandler(this.GetDefaultButton_Click);
      // 
      // ConnectionStringText
      // 
      this.ConnectionStringText.Location = new System.Drawing.Point(133, 106);
      this.ConnectionStringText.Name = "ConnectionStringText";
      this.ConnectionStringText.Size = new System.Drawing.Size(477, 23);
      this.ConnectionStringText.TabIndex = 0;
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(34, 109);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(103, 15);
      this.label3.TabIndex = 11;
      this.label3.Text = "Connection String";
      // 
      // label2
      // 
      this.label2.Location = new System.Drawing.Point(16, 35);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(681, 55);
      this.label2.TabIndex = 10;
      this.label2.Text = resources.GetString("label2.Text");
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
      // panel4
      // 
      this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.panel4.Controls.Add(this.label15);
      this.panel4.Controls.Add(this.LogViewerText);
      this.panel4.Controls.Add(this.label14);
      this.panel4.Controls.Add(this.label12);
      this.panel4.Location = new System.Drawing.Point(12, 683);
      this.panel4.Name = "panel4";
      this.panel4.Size = new System.Drawing.Size(717, 132);
      this.panel4.TabIndex = 13;
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
      // label14
      // 
      this.label14.Location = new System.Drawing.Point(17, 36);
      this.label14.Name = "label14";
      this.label14.Size = new System.Drawing.Size(681, 36);
      this.label14.TabIndex = 11;
      this.label14.Text = "Specify the executable file that you would like to use for your log file viewer. " +
    " For Windows \"Notepad.exe\" works well.  For Linux you may need to specify the fu" +
    "ll path to the executable.\r\n";
      // 
      // LogViewerText
      // 
      this.LogViewerText.Location = new System.Drawing.Point(82, 80);
      this.LogViewerText.Name = "LogViewerText";
      this.LogViewerText.Size = new System.Drawing.Size(615, 23);
      this.LogViewerText.TabIndex = 12;
      this.LogViewerText.Text = "Notepad.exe";
      // 
      // label15
      // 
      this.label15.AutoSize = true;
      this.label15.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      this.label15.Location = new System.Drawing.Point(22, 81);
      this.label15.Name = "label15";
      this.label15.Size = new System.Drawing.Size(54, 17);
      this.label15.TabIndex = 13;
      this.label15.Text = "Viewer: ";
      // 
      // SettingsDialog
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
      this.AutoScroll = true;
      this.ClientSize = new System.Drawing.Size(750, 876);
      this.Controls.Add(this.panel4);
      this.Controls.Add(this.panel3);
      this.Controls.Add(this.panel2);
      this.Controls.Add(this.panel1);
      this.Controls.Add(this.cancelButton);
      this.Controls.Add(this.okButton);
      this.Name = "SettingsDialog";
      this.Text = "Application Settings";
      ((System.ComponentModel.ISupportInitialize)(this.snapshotNumeric)).EndInit();
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.panel2.ResumeLayout(false);
      this.panel2.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.eventIntervalNumeric)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.maxEventNumeric)).EndInit();
      this.panel3.ResumeLayout(false);
      this.panel3.PerformLayout();
      this.panel4.ResumeLayout(false);
      this.panel4.PerformLayout();
      this.ResumeLayout(false);

    }

        #endregion

        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown snapshotNumeric;
        private System.Windows.Forms.Label label6;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Panel panel2;
    private System.Windows.Forms.Label label11;
    private System.Windows.Forms.NumericUpDown eventIntervalNumeric;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.Label label9;
    private System.Windows.Forms.NumericUpDown maxEventNumeric;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.Label label13;
    private System.Windows.Forms.Button RemoveButton;
    private System.Windows.Forms.Button AddButton;
    private System.Windows.Forms.ListView aiLocationListView;
    private System.Windows.Forms.ColumnHeader columnHeader1;
    private System.Windows.Forms.ColumnHeader columnHeader2;
    private System.Windows.Forms.Panel panel3;
    private System.Windows.Forms.Button UseCustomButton;
    private System.Windows.Forms.Button GetDefaultButton;
    private System.Windows.Forms.TextBox ConnectionStringText;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Button RefreshButton;
    private System.Windows.Forms.Label label10;
    private System.Windows.Forms.Panel panel4;
    private System.Windows.Forms.Label label15;
    private System.Windows.Forms.TextBox LogViewerText;
    private System.Windows.Forms.Label label14;
    private System.Windows.Forms.Label label12;
  }
}