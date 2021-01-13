namespace DeepStackDisplay
{
  partial class NotificationOptionsDialog
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
      this.components = new System.ComponentModel.Container();
      this.urlsList = new System.Windows.Forms.ListView();
      this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.label2 = new System.Windows.Forms.Label();
      this.emailsList = new System.Windows.Forms.ListView();
      this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.label3 = new System.Windows.Forms.Label();
      this.okButton = new System.Windows.Forms.Button();
      this.cancelButton = new System.Windows.Forms.Button();
      this.label4 = new System.Windows.Forms.Label();
      this.addUrlButton = new System.Windows.Forms.Button();
      this.addEmailButton = new System.Windows.Forms.Button();
      this.removeUrlButton = new System.Windows.Forms.Button();
      this.removeEmailButton = new System.Windows.Forms.Button();
      this.numberOfImages = new System.Windows.Forms.NumericUpDown();
      this.label5 = new System.Windows.Forms.Label();
      this.check247 = new System.Windows.Forms.CheckBox();
      this.fromTime = new System.Windows.Forms.DateTimePicker();
      this.label6 = new System.Windows.Forms.Label();
      this.label7 = new System.Windows.Forms.Label();
      this.label8 = new System.Windows.Forms.Label();
      this.toTime = new System.Windows.Forms.DateTimePicker();
      this.label9 = new System.Windows.Forms.Label();
      this.daysOfWeekList = new System.Windows.Forms.CheckedListBox();
      this.panel1 = new System.Windows.Forms.Panel();
      this.panel2 = new System.Windows.Forms.Panel();
      this.label11 = new System.Windows.Forms.Label();
      this.sizeImageToNumeric = new System.Windows.Forms.NumericUpDown();
      this.bs = new System.Windows.Forms.BindingSource(this.components);
      ((System.ComponentModel.ISupportInitialize)(this.numberOfImages)).BeginInit();
      this.panel1.SuspendLayout();
      this.panel2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.sizeImageToNumeric)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.bs)).BeginInit();
      this.SuspendLayout();
      // 
      // urlsList
      // 
      this.urlsList.CheckBoxes = true;
      this.urlsList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader1});
      this.urlsList.GridLines = true;
      this.urlsList.HideSelection = false;
      this.urlsList.LabelEdit = true;
      this.urlsList.Location = new System.Drawing.Point(8, 16);
      this.urlsList.MultiSelect = false;
      this.urlsList.Name = "urlsList";
      this.urlsList.Size = new System.Drawing.Size(420, 186);
      this.urlsList.TabIndex = 2;
      this.urlsList.UseCompatibleStateImageBehavior = false;
      this.urlsList.View = System.Windows.Forms.View.Details;
      // 
      // columnHeader3
      // 
      this.columnHeader3.Text = "Urls to Notify";
      this.columnHeader3.Width = 310;
      // 
      // columnHeader1
      // 
      this.columnHeader1.Text = "Cool Down";
      this.columnHeader1.Width = 78;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label2.Location = new System.Drawing.Point(121, 9);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(132, 16);
      this.label2.TabIndex = 3;
      this.label2.Text = "Notification URL s";
      // 
      // emailsList
      // 
      this.emailsList.CheckBoxes = true;
      this.emailsList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader2});
      this.emailsList.FullRowSelect = true;
      this.emailsList.GridLines = true;
      this.emailsList.HideSelection = false;
      this.emailsList.LabelEdit = true;
      this.emailsList.Location = new System.Drawing.Point(14, 16);
      this.emailsList.MultiSelect = false;
      this.emailsList.Name = "emailsList";
      this.emailsList.Size = new System.Drawing.Size(288, 186);
      this.emailsList.TabIndex = 5;
      this.emailsList.UseCompatibleStateImageBehavior = false;
      this.emailsList.View = System.Windows.Forms.View.Details;
      this.emailsList.SelectedIndexChanged += new System.EventHandler(this.SelectionChanged);
      // 
      // columnHeader4
      // 
      this.columnHeader4.Text = "Recipients";
      this.columnHeader4.Width = 160;
      // 
      // columnHeader2
      // 
      this.columnHeader2.Text = "Cool Down";
      this.columnHeader2.Width = 77;
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label3.Location = new System.Drawing.Point(517, 9);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(253, 16);
      this.label3.TabIndex = 6;
      this.label3.Text = "Email To (Check to include images)";
      // 
      // okButton
      // 
      this.okButton.Location = new System.Drawing.Point(219, 321);
      this.okButton.Name = "okButton";
      this.okButton.Size = new System.Drawing.Size(75, 23);
      this.okButton.TabIndex = 7;
      this.okButton.Text = "OK";
      this.okButton.UseVisualStyleBackColor = true;
      this.okButton.Click += new System.EventHandler(this.OkButton_Click);
      // 
      // cancelButton
      // 
      this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.cancelButton.Location = new System.Drawing.Point(304, 321);
      this.cancelButton.Name = "cancelButton";
      this.cancelButton.Size = new System.Drawing.Size(75, 23);
      this.cancelButton.TabIndex = 8;
      this.cancelButton.Text = "Cancel";
      this.cancelButton.UseVisualStyleBackColor = true;
      this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label4.Location = new System.Drawing.Point(8, 253);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(125, 15);
      this.label4.TabIndex = 10;
      this.label4.Text = "Number of Images";
      // 
      // addUrlButton
      // 
      this.addUrlButton.Location = new System.Drawing.Point(141, 209);
      this.addUrlButton.Name = "addUrlButton";
      this.addUrlButton.Size = new System.Drawing.Size(75, 23);
      this.addUrlButton.TabIndex = 11;
      this.addUrlButton.Text = "Add";
      this.addUrlButton.UseVisualStyleBackColor = true;
      this.addUrlButton.Click += new System.EventHandler(this.AddUrlButton_Click);
      // 
      // addEmailButton
      // 
      this.addEmailButton.Location = new System.Drawing.Point(42, 208);
      this.addEmailButton.Name = "addEmailButton";
      this.addEmailButton.Size = new System.Drawing.Size(75, 23);
      this.addEmailButton.TabIndex = 12;
      this.addEmailButton.Text = "Add";
      this.addEmailButton.UseVisualStyleBackColor = true;
      this.addEmailButton.Click += new System.EventHandler(this.AddEmailButton_Click);
      // 
      // removeUrlButton
      // 
      this.removeUrlButton.Location = new System.Drawing.Point(229, 209);
      this.removeUrlButton.Name = "removeUrlButton";
      this.removeUrlButton.Size = new System.Drawing.Size(75, 23);
      this.removeUrlButton.TabIndex = 13;
      this.removeUrlButton.Text = "Remove";
      this.removeUrlButton.UseVisualStyleBackColor = true;
      this.removeUrlButton.Click += new System.EventHandler(this.RemoveUrlButton_Click);
      // 
      // removeEmailButton
      // 
      this.removeEmailButton.Location = new System.Drawing.Point(123, 210);
      this.removeEmailButton.Name = "removeEmailButton";
      this.removeEmailButton.Size = new System.Drawing.Size(75, 23);
      this.removeEmailButton.TabIndex = 14;
      this.removeEmailButton.Text = "Remove";
      this.removeEmailButton.UseVisualStyleBackColor = true;
      this.removeEmailButton.Click += new System.EventHandler(this.RemoveEmailButton_Click);
      // 
      // numberOfImages
      // 
      this.numberOfImages.Location = new System.Drawing.Point(149, 253);
      this.numberOfImages.Name = "numberOfImages";
      this.numberOfImages.Size = new System.Drawing.Size(75, 20);
      this.numberOfImages.TabIndex = 15;
      this.numberOfImages.ValueChanged += new System.EventHandler(this.NumberOfImages_ValueChanged);
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label5.Location = new System.Drawing.Point(325, 10);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(92, 16);
      this.label5.TabIndex = 16;
      this.label5.Text = "Time of Day";
      // 
      // check247
      // 
      this.check247.AutoSize = true;
      this.check247.Location = new System.Drawing.Point(346, 35);
      this.check247.Name = "check247";
      this.check247.Size = new System.Drawing.Size(49, 17);
      this.check247.TabIndex = 17;
      this.check247.Text = "24/7";
      this.check247.UseVisualStyleBackColor = true;
      this.check247.CheckedChanged += new System.EventHandler(this.Check247_Checked);
      // 
      // fromTime
      // 
      this.fromTime.CustomFormat = "hh:mmtt";
      this.fromTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
      this.fromTime.Location = new System.Drawing.Point(315, 101);
      this.fromTime.Name = "fromTime";
      this.fromTime.Size = new System.Drawing.Size(90, 20);
      this.fromTime.TabIndex = 18;
      this.fromTime.Value = new System.DateTime(2020, 6, 2, 0, 0, 0, 0);
      this.fromTime.ValueChanged += new System.EventHandler(this.FromTime_ValueChanged);
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label6.Location = new System.Drawing.Point(313, 64);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(92, 16);
      this.label6.TabIndex = 19;
      this.label6.Text = "Time of Day";
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label7.Location = new System.Drawing.Point(341, 85);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(34, 13);
      this.label7.TabIndex = 20;
      this.label7.Text = "From";
      // 
      // label8
      // 
      this.label8.AutoSize = true;
      this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label8.Location = new System.Drawing.Point(341, 125);
      this.label8.Name = "label8";
      this.label8.Size = new System.Drawing.Size(22, 13);
      this.label8.TabIndex = 21;
      this.label8.Text = "To";
      // 
      // toTime
      // 
      this.toTime.CustomFormat = "hh:mmtt";
      this.toTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
      this.toTime.Location = new System.Drawing.Point(315, 142);
      this.toTime.Name = "toTime";
      this.toTime.Size = new System.Drawing.Size(90, 20);
      this.toTime.TabIndex = 22;
      this.toTime.Value = new System.DateTime(2020, 6, 2, 23, 59, 0, 0);
      this.toTime.ValueChanged += new System.EventHandler(this.ToTime_ValueChanged);
      // 
      // label9
      // 
      this.label9.AutoSize = true;
      this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label9.Location = new System.Drawing.Point(308, 181);
      this.label9.Name = "label9";
      this.label9.Size = new System.Drawing.Size(130, 16);
      this.label9.TabIndex = 23;
      this.label9.Text = "Days of the Week";
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
      this.daysOfWeekList.Location = new System.Drawing.Point(312, 209);
      this.daysOfWeekList.Name = "daysOfWeekList";
      this.daysOfWeekList.Size = new System.Drawing.Size(120, 109);
      this.daysOfWeekList.TabIndex = 24;
      this.daysOfWeekList.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.OnItemCheckChanged);
      // 
      // panel1
      // 
      this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.panel1.Controls.Add(this.urlsList);
      this.panel1.Controls.Add(this.addUrlButton);
      this.panel1.Controls.Add(this.removeUrlButton);
      this.panel1.Location = new System.Drawing.Point(15, 37);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(447, 250);
      this.panel1.TabIndex = 29;
      // 
      // panel2
      // 
      this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.panel2.Controls.Add(this.label11);
      this.panel2.Controls.Add(this.sizeImageToNumeric);
      this.panel2.Controls.Add(this.emailsList);
      this.panel2.Controls.Add(this.addEmailButton);
      this.panel2.Controls.Add(this.daysOfWeekList);
      this.panel2.Controls.Add(this.label9);
      this.panel2.Controls.Add(this.toTime);
      this.panel2.Controls.Add(this.removeEmailButton);
      this.panel2.Controls.Add(this.label8);
      this.panel2.Controls.Add(this.label4);
      this.panel2.Controls.Add(this.label7);
      this.panel2.Controls.Add(this.numberOfImages);
      this.panel2.Controls.Add(this.label6);
      this.panel2.Controls.Add(this.label5);
      this.panel2.Controls.Add(this.fromTime);
      this.panel2.Controls.Add(this.check247);
      this.panel2.Location = new System.Drawing.Point(485, 37);
      this.panel2.Name = "panel2";
      this.panel2.Size = new System.Drawing.Size(450, 336);
      this.panel2.TabIndex = 30;
      // 
      // label11
      // 
      this.label11.AutoSize = true;
      this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label11.Location = new System.Drawing.Point(23, 282);
      this.label11.Name = "label11";
      this.label11.Size = new System.Drawing.Size(111, 15);
      this.label11.TabIndex = 29;
      this.label11.Text = "Size Down To %";
      // 
      // sizeImageToNumeric
      // 
      this.sizeImageToNumeric.Location = new System.Drawing.Point(150, 282);
      this.sizeImageToNumeric.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
      this.sizeImageToNumeric.Name = "sizeImageToNumeric";
      this.sizeImageToNumeric.Size = new System.Drawing.Size(75, 20);
      this.sizeImageToNumeric.TabIndex = 30;
      this.sizeImageToNumeric.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
      this.sizeImageToNumeric.ValueChanged += new System.EventHandler(this.SizeImageToNumeric_ValueChanged);
      // 
      // bs
      // 
      this.bs.CurrentChanged += new System.EventHandler(this.bs_CurrentChanged);
      // 
      // NotificationOptionsDialog
      // 
      this.AcceptButton = this.okButton;
      this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
      this.CancelButton = this.cancelButton;
      this.ClientSize = new System.Drawing.Size(947, 380);
      this.Controls.Add(this.panel2);
      this.Controls.Add(this.panel1);
      this.Controls.Add(this.cancelButton);
      this.Controls.Add(this.okButton);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.label2);
      this.Name = "NotificationOptionsDialog";
      this.Text = "Define Notification Options for Activity";
      ((System.ComponentModel.ISupportInitialize)(this.numberOfImages)).EndInit();
      this.panel1.ResumeLayout(false);
      this.panel2.ResumeLayout(false);
      this.panel2.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.sizeImageToNumeric)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.bs)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

        #endregion
        private System.Windows.Forms.ListView urlsList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView emailsList;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button addUrlButton;
        private System.Windows.Forms.Button addEmailButton;
        private System.Windows.Forms.Button removeUrlButton;
        private System.Windows.Forms.Button removeEmailButton;
        private System.Windows.Forms.NumericUpDown numberOfImages;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox check247;
        private System.Windows.Forms.DateTimePicker fromTime;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker toTime;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckedListBox daysOfWeekList;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.BindingSource bs;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Panel panel2;
    private System.Windows.Forms.Label label11;
    private System.Windows.Forms.NumericUpDown sizeImageToNumeric;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
    }
}