namespace SAAI
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
      this.columnHeader0 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.coolDownHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.label2 = new System.Windows.Forms.Label();
      this.emailsList = new System.Windows.Forms.ListView();
      this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.label3 = new System.Windows.Forms.Label();
      this.okButton = new System.Windows.Forms.Button();
      this.cancelButton = new System.Windows.Forms.Button();
      this.addUrlButton = new System.Windows.Forms.Button();
      this.addEmailButton = new System.Windows.Forms.Button();
      this.removeUrlButton = new System.Windows.Forms.Button();
      this.removeEmailButton = new System.Windows.Forms.Button();
      this.panel1 = new System.Windows.Forms.Panel();
      this.panel2 = new System.Windows.Forms.Panel();
      this.UseMQTTBox = new System.Windows.Forms.CheckBox();
      this.bs = new System.Windows.Forms.BindingSource(this.components);
      this.panel3 = new System.Windows.Forms.Panel();
      this.label5 = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.NoMotionUrlNotify = new System.Windows.Forms.TextBox();
      this.NoMotionMQTTCheck = new System.Windows.Forms.CheckBox();
      this.label1 = new System.Windows.Forms.Label();
      this.waitTimeHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.panel1.SuspendLayout();
      this.panel2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.bs)).BeginInit();
      this.panel3.SuspendLayout();
      this.SuspendLayout();
      // 
      // urlsList
      // 
      this.urlsList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader0,
            this.waitTimeHeader,
            this.coolDownHeader});
      this.urlsList.FullRowSelect = true;
      this.urlsList.GridLines = true;
      this.urlsList.HideSelection = false;
      this.urlsList.LabelEdit = true;
      this.urlsList.Location = new System.Drawing.Point(8, 16);
      this.urlsList.MultiSelect = false;
      this.urlsList.Name = "urlsList";
      this.urlsList.Size = new System.Drawing.Size(420, 154);
      this.urlsList.TabIndex = 2;
      this.urlsList.UseCompatibleStateImageBehavior = false;
      this.urlsList.View = System.Windows.Forms.View.Details;
      this.urlsList.ItemActivate += new System.EventHandler(this.OnActivateURL);
      // 
      // columnHeader0
      // 
      this.columnHeader0.Text = "Urls to Notify";
      this.columnHeader0.Width = 258;
      // 
      // waitTimeHeader
      // 
      this.waitTimeHeader.DisplayIndex = 1;
      this.waitTimeHeader.Text = "Wait Time";
      this.waitTimeHeader.Width = 74;
      // 
      // coolDownHeader
      // 
      this.coolDownHeader.DisplayIndex = 2;
      this.coolDownHeader.Text = "Cool Down";
      this.coolDownHeader.Width = 78;
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
      this.emailsList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4});
      this.emailsList.FullRowSelect = true;
      this.emailsList.GridLines = true;
      this.emailsList.HideSelection = false;
      this.emailsList.LabelEdit = true;
      this.emailsList.Location = new System.Drawing.Point(14, 16);
      this.emailsList.MultiSelect = false;
      this.emailsList.Name = "emailsList";
      this.emailsList.Size = new System.Drawing.Size(288, 154);
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
      this.okButton.Location = new System.Drawing.Point(328, 484);
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
      this.cancelButton.Location = new System.Drawing.Point(414, 484);
      this.cancelButton.Name = "cancelButton";
      this.cancelButton.Size = new System.Drawing.Size(75, 23);
      this.cancelButton.TabIndex = 1;
      this.cancelButton.Text = "Cancel";
      this.cancelButton.UseVisualStyleBackColor = true;
      this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
      // 
      // addUrlButton
      // 
      this.addUrlButton.Location = new System.Drawing.Point(141, 185);
      this.addUrlButton.Name = "addUrlButton";
      this.addUrlButton.Size = new System.Drawing.Size(75, 23);
      this.addUrlButton.TabIndex = 0;
      this.addUrlButton.Text = "Add";
      this.addUrlButton.UseVisualStyleBackColor = true;
      this.addUrlButton.Click += new System.EventHandler(this.AddUrlButton_Click);
      // 
      // addEmailButton
      // 
      this.addEmailButton.Location = new System.Drawing.Point(71, 187);
      this.addEmailButton.Name = "addEmailButton";
      this.addEmailButton.Size = new System.Drawing.Size(75, 23);
      this.addEmailButton.TabIndex = 0;
      this.addEmailButton.Text = "Add";
      this.addEmailButton.UseVisualStyleBackColor = true;
      this.addEmailButton.Click += new System.EventHandler(this.AddEmailButton_Click);
      // 
      // removeUrlButton
      // 
      this.removeUrlButton.Location = new System.Drawing.Point(229, 185);
      this.removeUrlButton.Name = "removeUrlButton";
      this.removeUrlButton.Size = new System.Drawing.Size(75, 23);
      this.removeUrlButton.TabIndex = 1;
      this.removeUrlButton.Text = "Remove";
      this.removeUrlButton.UseVisualStyleBackColor = true;
      this.removeUrlButton.Click += new System.EventHandler(this.RemoveUrlButton_Click);
      // 
      // removeEmailButton
      // 
      this.removeEmailButton.Location = new System.Drawing.Point(161, 187);
      this.removeEmailButton.Name = "removeEmailButton";
      this.removeEmailButton.Size = new System.Drawing.Size(75, 23);
      this.removeEmailButton.TabIndex = 1;
      this.removeEmailButton.Text = "Remove";
      this.removeEmailButton.UseVisualStyleBackColor = true;
      this.removeEmailButton.Click += new System.EventHandler(this.RemoveEmailButton_Click);
      // 
      // panel1
      // 
      this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.panel1.Controls.Add(this.urlsList);
      this.panel1.Controls.Add(this.addUrlButton);
      this.panel1.Controls.Add(this.removeUrlButton);
      this.panel1.Location = new System.Drawing.Point(15, 37);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(447, 220);
      this.panel1.TabIndex = 29;
      // 
      // panel2
      // 
      this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.panel2.Controls.Add(this.emailsList);
      this.panel2.Controls.Add(this.addEmailButton);
      this.panel2.Controls.Add(this.removeEmailButton);
      this.panel2.Location = new System.Drawing.Point(483, 37);
      this.panel2.Name = "panel2";
      this.panel2.Size = new System.Drawing.Size(319, 220);
      this.panel2.TabIndex = 30;
      // 
      // UseMQTTBox
      // 
      this.UseMQTTBox.Appearance = System.Windows.Forms.Appearance.Button;
      this.UseMQTTBox.AutoSize = true;
      this.UseMQTTBox.BackColor = System.Drawing.SystemColors.Control;
      this.UseMQTTBox.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
      this.UseMQTTBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.UseMQTTBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.UseMQTTBox.Location = new System.Drawing.Point(310, 433);
      this.UseMQTTBox.Name = "UseMQTTBox";
      this.UseMQTTBox.Size = new System.Drawing.Size(197, 26);
      this.UseMQTTBox.TabIndex = 0;
      this.UseMQTTBox.Text = "Notify Using MQTT On Activity";
      this.UseMQTTBox.UseVisualStyleBackColor = false;
      // 
      // panel3
      // 
      this.panel3.BackColor = System.Drawing.SystemColors.Control;
      this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.panel3.Controls.Add(this.label5);
      this.panel3.Controls.Add(this.label4);
      this.panel3.Controls.Add(this.NoMotionUrlNotify);
      this.panel3.Controls.Add(this.NoMotionMQTTCheck);
      this.panel3.Location = new System.Drawing.Point(15, 315);
      this.panel3.Name = "panel3";
      this.panel3.Size = new System.Drawing.Size(787, 100);
      this.panel3.TabIndex = 31;
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label5.Location = new System.Drawing.Point(120, 20);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(547, 15);
      this.label5.TabIndex = 34;
      this.label5.Text = "Action on Motion Stopped (Timeout is per camera and is set via the camera setting" +
    "s)";
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label4.Location = new System.Drawing.Point(6, 58);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(91, 15);
      this.label4.TabIndex = 33;
      this.label4.Text = "URL to Notify";
      // 
      // NoMotionUrlNotify
      // 
      this.NoMotionUrlNotify.Location = new System.Drawing.Point(111, 57);
      this.NoMotionUrlNotify.Name = "NoMotionUrlNotify";
      this.NoMotionUrlNotify.Size = new System.Drawing.Size(404, 20);
      this.NoMotionUrlNotify.TabIndex = 2;
      // 
      // NoMotionMQTTCheck
      // 
      this.NoMotionMQTTCheck.Appearance = System.Windows.Forms.Appearance.Button;
      this.NoMotionMQTTCheck.AutoSize = true;
      this.NoMotionMQTTCheck.BackColor = System.Drawing.SystemColors.Control;
      this.NoMotionMQTTCheck.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
      this.NoMotionMQTTCheck.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.NoMotionMQTTCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.NoMotionMQTTCheck.Location = new System.Drawing.Point(537, 53);
      this.NoMotionMQTTCheck.Name = "NoMotionMQTTCheck";
      this.NoMotionMQTTCheck.Size = new System.Drawing.Size(230, 26);
      this.NoMotionMQTTCheck.TabIndex = 1;
      this.NoMotionMQTTCheck.Text = "Notify Using MQTT Motion Stopped";
      this.NoMotionMQTTCheck.UseVisualStyleBackColor = false;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label1.Location = new System.Drawing.Point(305, 287);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(207, 16);
      this.label1.TabIndex = 32;
      this.label1.Text = "Motion Stopped Notifications";
      // 
      // NotificationOptionsDialog
      // 
      this.AcceptButton = this.okButton;
      this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
      this.CancelButton = this.cancelButton;
      this.ClientSize = new System.Drawing.Size(816, 517);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.panel3);
      this.Controls.Add(this.UseMQTTBox);
      this.Controls.Add(this.panel2);
      this.Controls.Add(this.panel1);
      this.Controls.Add(this.cancelButton);
      this.Controls.Add(this.okButton);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.label2);
      this.Name = "NotificationOptionsDialog";
      this.Text = "Notification Optoins";
      this.panel1.ResumeLayout(false);
      this.panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.bs)).EndInit();
      this.panel3.ResumeLayout(false);
      this.panel3.PerformLayout();
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
        private System.Windows.Forms.Button addUrlButton;
        private System.Windows.Forms.Button addEmailButton;
        private System.Windows.Forms.Button removeUrlButton;
        private System.Windows.Forms.Button removeEmailButton;
        private System.Windows.Forms.ColumnHeader columnHeader0;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.BindingSource bs;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ColumnHeader coolDownHeader;
    private System.Windows.Forms.CheckBox UseMQTTBox;
    private System.Windows.Forms.Panel panel3;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.TextBox NoMotionUrlNotify;
    private System.Windows.Forms.CheckBox NoMotionMQTTCheck;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.ColumnHeader waitTimeHeader;
  }
}