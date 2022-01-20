
namespace OnGuardCore
{
  partial class ScheduledPreset
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
      this.FormCancelButton = new System.Windows.Forms.Button();
      this.PresetNameTextBox = new System.Windows.Forms.TextBox();
      this.PresetNumeric = new System.Windows.Forms.NumericUpDown();
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.TriggerTime = new System.Windows.Forms.DateTimePicker();
      this.label3 = new System.Windows.Forms.Label();
      this.panel1 = new System.Windows.Forms.Panel();
      this.label4 = new System.Windows.Forms.Label();
      this.TimeRadio = new System.Windows.Forms.RadioButton();
      this.SunsetRadio = new System.Windows.Forms.RadioButton();
      this.SunriseRadio = new System.Windows.Forms.RadioButton();
      this.label5 = new System.Windows.Forms.Label();
      this.label6 = new System.Windows.Forms.Label();
      ((System.ComponentModel.ISupportInitialize)(this.PresetNumeric)).BeginInit();
      this.panel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // OKButton
      // 
      this.OKButton.Location = new System.Drawing.Point(66, 317);
      this.OKButton.Name = "OKButton";
      this.OKButton.Size = new System.Drawing.Size(75, 23);
      this.OKButton.TabIndex = 0;
      this.OKButton.Text = "OK";
      this.OKButton.UseVisualStyleBackColor = true;
      this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
      // 
      // FormCancelButton
      // 
      this.FormCancelButton.Location = new System.Drawing.Point(151, 317);
      this.FormCancelButton.Name = "FormCancelButton";
      this.FormCancelButton.Size = new System.Drawing.Size(75, 23);
      this.FormCancelButton.TabIndex = 1;
      this.FormCancelButton.Text = "Cancel";
      this.FormCancelButton.UseVisualStyleBackColor = true;
      this.FormCancelButton.Click += new System.EventHandler(this.CancelButton_Click);
      // 
      // PresetNameTextBox
      // 
      this.PresetNameTextBox.Location = new System.Drawing.Point(124, 51);
      this.PresetNameTextBox.Name = "PresetNameTextBox";
      this.PresetNameTextBox.Size = new System.Drawing.Size(129, 23);
      this.PresetNameTextBox.TabIndex = 0;
      // 
      // PresetNumeric
      // 
      this.PresetNumeric.Location = new System.Drawing.Point(124, 80);
      this.PresetNumeric.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
      this.PresetNumeric.Name = "PresetNumeric";
      this.PresetNumeric.Size = new System.Drawing.Size(45, 23);
      this.PresetNumeric.TabIndex = 1;
      this.PresetNumeric.Value = new decimal(new int[] {
            128,
            0,
            0,
            0});
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(69, 54);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(39, 15);
      this.label1.TabIndex = 4;
      this.label1.Text = "Name";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(22, 80);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(86, 15);
      this.label2.TabIndex = 5;
      this.label2.Text = "Preset Number";
      // 
      // TriggerTime
      // 
      this.TriggerTime.CustomFormat = "hh:mm tt";
      this.TriggerTime.Enabled = false;
      this.TriggerTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
      this.TriggerTime.Location = new System.Drawing.Point(122, 131);
      this.TriggerTime.Name = "TriggerTime";
      this.TriggerTime.ShowUpDown = true;
      this.TriggerTime.Size = new System.Drawing.Size(81, 23);
      this.TriggerTime.TabIndex = 3;
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(33, 137);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(72, 15);
      this.label3.TabIndex = 7;
      this.label3.Text = "Trigger Time";
      // 
      // panel1
      // 
      this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.panel1.Controls.Add(this.label4);
      this.panel1.Controls.Add(this.TimeRadio);
      this.panel1.Controls.Add(this.label3);
      this.panel1.Controls.Add(this.SunsetRadio);
      this.panel1.Controls.Add(this.TriggerTime);
      this.panel1.Controls.Add(this.SunriseRadio);
      this.panel1.Location = new System.Drawing.Point(14, 116);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(265, 177);
      this.panel1.TabIndex = 8;
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.label4.Location = new System.Drawing.Point(84, 15);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(119, 15);
      this.label4.TabIndex = 8;
      this.label4.Text = "Set Trigger Condition";
      // 
      // TimeRadio
      // 
      this.TimeRadio.AutoSize = true;
      this.TimeRadio.Location = new System.Drawing.Point(33, 93);
      this.TimeRadio.Name = "TimeRadio";
      this.TimeRadio.Size = new System.Drawing.Size(66, 19);
      this.TimeRadio.TabIndex = 2;
      this.TimeRadio.Text = "At Time";
      this.TimeRadio.UseVisualStyleBackColor = true;
      this.TimeRadio.CheckedChanged += new System.EventHandler(this.OnRadioChanged);
      // 
      // SunsetRadio
      // 
      this.SunsetRadio.AutoSize = true;
      this.SunsetRadio.Location = new System.Drawing.Point(33, 68);
      this.SunsetRadio.Name = "SunsetRadio";
      this.SunsetRadio.Size = new System.Drawing.Size(60, 19);
      this.SunsetRadio.TabIndex = 1;
      this.SunsetRadio.Text = "Sunset";
      this.SunsetRadio.UseVisualStyleBackColor = true;
      this.SunsetRadio.CheckedChanged += new System.EventHandler(this.OnRadioChanged);
      // 
      // SunriseRadio
      // 
      this.SunriseRadio.AutoSize = true;
      this.SunriseRadio.Checked = true;
      this.SunriseRadio.Location = new System.Drawing.Point(33, 43);
      this.SunriseRadio.Name = "SunriseRadio";
      this.SunriseRadio.Size = new System.Drawing.Size(63, 19);
      this.SunriseRadio.TabIndex = 0;
      this.SunriseRadio.TabStop = true;
      this.SunriseRadio.Text = "Sunrise";
      this.SunriseRadio.UseVisualStyleBackColor = true;
      this.SunriseRadio.CheckedChanged += new System.EventHandler(this.OnRadioChanged);
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.label5.Location = new System.Drawing.Point(39, 10);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(214, 17);
      this.label5.TabIndex = 9;
      this.label5.Text = "Scheduled Camera Preset Activity";
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Location = new System.Drawing.Point(175, 82);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(73, 15);
      this.label6.TabIndex = 10;
      this.label6.Text = "(Zero Based)";
      // 
      // ScheduledPreset
      // 
      this.AcceptButton = this.OKButton;
      this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
      this.ClientSize = new System.Drawing.Size(292, 345);
      this.Controls.Add(this.label6);
      this.Controls.Add(this.label5);
      this.Controls.Add(this.panel1);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.PresetNumeric);
      this.Controls.Add(this.PresetNameTextBox);
      this.Controls.Add(this.FormCancelButton);
      this.Controls.Add(this.OKButton);
      this.Name = "ScheduledPreset";
      this.Text = "Scheduled Preset";
      ((System.ComponentModel.ISupportInitialize)(this.PresetNumeric)).EndInit();
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button OKButton;
    private System.Windows.Forms.Button FormCancelButton;
    private System.Windows.Forms.TextBox PresetNameTextBox;
    private System.Windows.Forms.NumericUpDown PresetNumeric;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.DateTimePicker TriggerTime;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.RadioButton TimeRadio;
    private System.Windows.Forms.RadioButton SunsetRadio;
    private System.Windows.Forms.RadioButton SunriseRadio;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Label label6;
  }
}