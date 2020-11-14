namespace SAAI
{
  partial class CreateEmailAddressDialog
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
      this.label1 = new System.Windows.Forms.Label();
      this.emailText = new System.Windows.Forms.TextBox();
      this.label11 = new System.Windows.Forms.Label();
      this.sizeImageToNumeric = new System.Windows.Forms.NumericUpDown();
      this.label4 = new System.Windows.Forms.Label();
      this.numberOfImages = new System.Windows.Forms.NumericUpDown();
      this.label2 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.coolDownNumeric = new System.Windows.Forms.NumericUpDown();
      this.label5 = new System.Windows.Forms.Label();
      this.panel1 = new System.Windows.Forms.Panel();
      this.label12 = new System.Windows.Forms.Label();
      this.daysOfWeekList = new System.Windows.Forms.CheckedListBox();
      this.label9 = new System.Windows.Forms.Label();
      this.toTime = new System.Windows.Forms.DateTimePicker();
      this.label8 = new System.Windows.Forms.Label();
      this.label7 = new System.Windows.Forms.Label();
      this.label6 = new System.Windows.Forms.Label();
      this.label10 = new System.Windows.Forms.Label();
      this.fromTime = new System.Windows.Forms.DateTimePicker();
      this.check247 = new System.Windows.Forms.CheckBox();
      this.okButton = new System.Windows.Forms.Button();
      this.cancelButton = new System.Windows.Forms.Button();
      this.mmsHelperButton = new System.Windows.Forms.Button();
      ((System.ComponentModel.ISupportInitialize)(this.sizeImageToNumeric)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.numberOfImages)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.coolDownNumeric)).BeginInit();
      this.panel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label1.Location = new System.Drawing.Point(119, 31);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(107, 15);
      this.label1.TabIndex = 0;
      this.label1.Text = "Email Address: ";
      // 
      // emailText
      // 
      this.emailText.Location = new System.Drawing.Point(242, 30);
      this.emailText.Name = "emailText";
      this.emailText.Size = new System.Drawing.Size(158, 20);
      this.emailText.TabIndex = 0;
      // 
      // label11
      // 
      this.label11.AutoSize = true;
      this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label11.Location = new System.Drawing.Point(115, 108);
      this.label11.Name = "label11";
      this.label11.Size = new System.Drawing.Size(111, 15);
      this.label11.TabIndex = 33;
      this.label11.Text = "Size Down To %";
      // 
      // sizeImageToNumeric
      // 
      this.sizeImageToNumeric.Location = new System.Drawing.Point(242, 108);
      this.sizeImageToNumeric.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
      this.sizeImageToNumeric.Name = "sizeImageToNumeric";
      this.sizeImageToNumeric.Size = new System.Drawing.Size(75, 20);
      this.sizeImageToNumeric.TabIndex = 2;
      this.sizeImageToNumeric.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label4.Location = new System.Drawing.Point(29, 69);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(197, 15);
      this.label4.TabIndex = 31;
      this.label4.Text = "Maximum Number of Pictures";
      // 
      // numberOfImages
      // 
      this.numberOfImages.Location = new System.Drawing.Point(242, 69);
      this.numberOfImages.Name = "numberOfImages";
      this.numberOfImages.Size = new System.Drawing.Size(75, 20);
      this.numberOfImages.TabIndex = 1;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label2.Location = new System.Drawing.Point(336, 108);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(84, 15);
      this.label2.TabIndex = 35;
      this.label2.Text = "100 is full size";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label3.Location = new System.Drawing.Point(16, 147);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(210, 15);
      this.label3.TabIndex = 36;
      this.label3.Text = "Minimum Time Between Emails";
      // 
      // coolDownNumeric
      // 
      this.coolDownNumeric.Location = new System.Drawing.Point(240, 147);
      this.coolDownNumeric.Maximum = new decimal(new int[] {
            120,
            0,
            0,
            0});
      this.coolDownNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.coolDownNumeric.Name = "coolDownNumeric";
      this.coolDownNumeric.Size = new System.Drawing.Size(75, 20);
      this.coolDownNumeric.TabIndex = 3;
      this.coolDownNumeric.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
      // 
      // label5
      // 
      this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label5.Location = new System.Drawing.Point(327, 138);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(176, 49);
      this.label5.TabIndex = 38;
      this.label5.Text = "In Minutes - This prevents you from being flooded with emails";
      // 
      // panel1
      // 
      this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.panel1.Controls.Add(this.label12);
      this.panel1.Controls.Add(this.daysOfWeekList);
      this.panel1.Controls.Add(this.label9);
      this.panel1.Controls.Add(this.toTime);
      this.panel1.Controls.Add(this.label8);
      this.panel1.Controls.Add(this.label7);
      this.panel1.Controls.Add(this.label6);
      this.panel1.Controls.Add(this.label10);
      this.panel1.Controls.Add(this.fromTime);
      this.panel1.Controls.Add(this.check247);
      this.panel1.Location = new System.Drawing.Point(64, 196);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(374, 308);
      this.panel1.TabIndex = 39;
      // 
      // label12
      // 
      this.label12.AutoSize = true;
      this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label12.Location = new System.Drawing.Point(55, 14);
      this.label12.Name = "label12";
      this.label12.Size = new System.Drawing.Size(273, 16);
      this.label12.TabIndex = 34;
      this.label12.Text = "Specify When Emails Should be Sent";
      // 
      // daysOfWeekList
      // 
      this.daysOfWeekList.FormattingEnabled = true;
      this.daysOfWeekList.Items.AddRange(new object[] {
            "Sunday",
            "Monday",
            "Tuesday",
            "Wednesday",
            "Thursday",
            "Friday",
            "Saturday"});
      this.daysOfWeekList.Location = new System.Drawing.Point(175, 169);
      this.daysOfWeekList.Name = "daysOfWeekList";
      this.daysOfWeekList.Size = new System.Drawing.Size(120, 109);
      this.daysOfWeekList.TabIndex = 3;
      // 
      // label9
      // 
      this.label9.AutoSize = true;
      this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label9.Location = new System.Drawing.Point(33, 214);
      this.label9.Name = "label9";
      this.label9.Size = new System.Drawing.Size(117, 15);
      this.label9.TabIndex = 32;
      this.label9.Text = "Days of the Week";
      // 
      // toTime
      // 
      this.toTime.CustomFormat = "hh:mmtt";
      this.toTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
      this.toTime.Location = new System.Drawing.Point(208, 118);
      this.toTime.Name = "toTime";
      this.toTime.Size = new System.Drawing.Size(90, 20);
      this.toTime.TabIndex = 2;
      this.toTime.Value = new System.DateTime(2020, 6, 2, 0, 0, 0, 0);
      // 
      // label8
      // 
      this.label8.AutoSize = true;
      this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label8.Location = new System.Drawing.Point(172, 124);
      this.label8.Name = "label8";
      this.label8.Size = new System.Drawing.Size(22, 13);
      this.label8.TabIndex = 30;
      this.label8.Text = "To";
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label7.Location = new System.Drawing.Point(20, 124);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(34, 13);
      this.label7.TabIndex = 29;
      this.label7.Text = "From";
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label6.Location = new System.Drawing.Point(143, 88);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(83, 15);
      this.label6.TabIndex = 28;
      this.label6.Text = "Time of Day";
      // 
      // label10
      // 
      this.label10.AutoSize = true;
      this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label10.Location = new System.Drawing.Point(205, -24);
      this.label10.Name = "label10";
      this.label10.Size = new System.Drawing.Size(95, 16);
      this.label10.TabIndex = 25;
      this.label10.Text = "Time of Day";
      // 
      // fromTime
      // 
      this.fromTime.CustomFormat = "hh:mm:tt";
      this.fromTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
      this.fromTime.Location = new System.Drawing.Point(60, 118);
      this.fromTime.Name = "fromTime";
      this.fromTime.Size = new System.Drawing.Size(90, 20);
      this.fromTime.TabIndex = 1;
      this.fromTime.Value = new System.DateTime(2020, 6, 2, 0, 0, 0, 0);
      // 
      // check247
      // 
      this.check247.AutoSize = true;
      this.check247.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.check247.Location = new System.Drawing.Point(19, 51);
      this.check247.Name = "check247";
      this.check247.Size = new System.Drawing.Size(226, 19);
      this.check247.TabIndex = 0;
      this.check247.Text = "24 Hours a Day, 7 Days a Week";
      this.check247.UseVisualStyleBackColor = true;
      this.check247.CheckedChanged += new System.EventHandler(this.OnCheckChanged);
      // 
      // okButton
      // 
      this.okButton.Location = new System.Drawing.Point(131, 522);
      this.okButton.Name = "okButton";
      this.okButton.Size = new System.Drawing.Size(75, 23);
      this.okButton.TabIndex = 4;
      this.okButton.Text = "OK";
      this.okButton.UseVisualStyleBackColor = true;
      this.okButton.Click += new System.EventHandler(this.OkButton_Click);
      // 
      // cancelButton
      // 
      this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.cancelButton.Location = new System.Drawing.Point(224, 522);
      this.cancelButton.Name = "cancelButton";
      this.cancelButton.Size = new System.Drawing.Size(75, 23);
      this.cancelButton.TabIndex = 5;
      this.cancelButton.Text = "Cancel";
      this.cancelButton.UseVisualStyleBackColor = true;
      this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
      // 
      // mmsHelperButton
      // 
      this.mmsHelperButton.Location = new System.Drawing.Point(416, 28);
      this.mmsHelperButton.Name = "mmsHelperButton";
      this.mmsHelperButton.Size = new System.Drawing.Size(112, 23);
      this.mmsHelperButton.TabIndex = 40;
      this.mmsHelperButton.Text = "MMS/SMS Helper";
      this.mmsHelperButton.UseVisualStyleBackColor = true;
      this.mmsHelperButton.Click += new System.EventHandler(this.MMSHelperButton_Click);
      // 
      // CreateEmailAddressDialog
      // 
      this.AcceptButton = this.okButton;
      this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
      this.CancelButton = this.cancelButton;
      this.ClientSize = new System.Drawing.Size(547, 569);
      this.Controls.Add(this.mmsHelperButton);
      this.Controls.Add(this.cancelButton);
      this.Controls.Add(this.okButton);
      this.Controls.Add(this.panel1);
      this.Controls.Add(this.label5);
      this.Controls.Add(this.coolDownNumeric);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label11);
      this.Controls.Add(this.sizeImageToNumeric);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.numberOfImages);
      this.Controls.Add(this.emailText);
      this.Controls.Add(this.label1);
      this.Name = "CreateEmailAddressDialog";
      this.Text = "Create and Configure an Email Recipient";
      ((System.ComponentModel.ISupportInitialize)(this.sizeImageToNumeric)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.numberOfImages)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.coolDownNumeric)).EndInit();
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox emailText;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown sizeImageToNumeric;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numberOfImages;
        private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.NumericUpDown coolDownNumeric;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.CheckedListBox daysOfWeekList;
    private System.Windows.Forms.Label label9;
    private System.Windows.Forms.DateTimePicker toTime;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.Label label10;
    private System.Windows.Forms.DateTimePicker fromTime;
    private System.Windows.Forms.CheckBox check247;
    private System.Windows.Forms.Label label12;
    private System.Windows.Forms.Button okButton;
    private System.Windows.Forms.Button cancelButton;
    private System.Windows.Forms.Button mmsHelperButton;
  }
}