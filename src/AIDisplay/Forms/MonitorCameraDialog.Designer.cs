namespace DeepStackDisplay
{
  partial class MonitorCameraDialog
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
      this.camerasListView = new System.Windows.Forms.ListView();
      this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.okButton = new System.Windows.Forms.Button();
      this.cancelButton = new System.Windows.Forms.Button();
      this.label1 = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // camerasListView
      // 
      this.camerasListView.CheckBoxes = true;
      this.camerasListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
      this.camerasListView.GridLines = true;
      this.camerasListView.HideSelection = false;
      this.camerasListView.Location = new System.Drawing.Point(25, 27);
      this.camerasListView.Name = "camerasListView";
      this.camerasListView.Size = new System.Drawing.Size(357, 184);
      this.camerasListView.TabIndex = 0;
      this.camerasListView.UseCompatibleStateImageBehavior = false;
      this.camerasListView.View = System.Windows.Forms.View.Details;
      this.camerasListView.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.OnItemCheck);
      // 
      // columnHeader1
      // 
      this.columnHeader1.Text = "Camera Name";
      this.columnHeader1.Width = 128;
      // 
      // columnHeader2
      // 
      this.columnHeader2.Text = "Path to Files";
      this.columnHeader2.Width = 210;
      // 
      // okButton
      // 
      this.okButton.Location = new System.Drawing.Point(115, 253);
      this.okButton.Name = "okButton";
      this.okButton.Size = new System.Drawing.Size(75, 23);
      this.okButton.TabIndex = 1;
      this.okButton.Text = "OK";
      this.okButton.UseVisualStyleBackColor = true;
      this.okButton.Click += new System.EventHandler(this.OkButton_Click);
      // 
      // cancelButton
      // 
      this.cancelButton.Location = new System.Drawing.Point(216, 253);
      this.cancelButton.Name = "cancelButton";
      this.cancelButton.Size = new System.Drawing.Size(75, 23);
      this.cancelButton.TabIndex = 2;
      this.cancelButton.Text = "Cancel";
      this.cancelButton.UseVisualStyleBackColor = true;
      this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(68, 218);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(270, 13);
      this.label1.TabIndex = 3;
      this.label1.Text = "Check cameras in the list to start monitoring the camera.";
      // 
      // MonitorCameraDialog
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(407, 297);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.cancelButton);
      this.Controls.Add(this.okButton);
      this.Controls.Add(this.camerasListView);
      this.Name = "MonitorCameraDialog";
      this.Text = "Manage Camera Monitoring";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

        #endregion

        private System.Windows.Forms.ListView camerasListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label label1;
    }
}