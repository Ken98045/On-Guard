namespace OnGuardCore
{
  partial class TestPIcturesDialog
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
      this.checkedListBoxCameras = new System.Windows.Forms.CheckedListBox();
      this.ButtonOK = new System.Windows.Forms.Button();
      this.ButtonCancel = new System.Windows.Forms.Button();
      this.label1 = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // checkedListBoxCameras
      // 
      this.checkedListBoxCameras.FormattingEnabled = true;
      this.checkedListBoxCameras.Location = new System.Drawing.Point(49, 59);
      this.checkedListBoxCameras.Name = "checkedListBoxCameras";
      this.checkedListBoxCameras.Size = new System.Drawing.Size(257, 148);
      this.checkedListBoxCameras.TabIndex = 0;
      // 
      // ButtonOK
      // 
      this.ButtonOK.Location = new System.Drawing.Point(100, 215);
      this.ButtonOK.Name = "ButtonOK";
      this.ButtonOK.Size = new System.Drawing.Size(75, 23);
      this.ButtonOK.TabIndex = 1;
      this.ButtonOK.Text = "OK";
      this.ButtonOK.UseVisualStyleBackColor = true;
      this.ButtonOK.Click += new System.EventHandler(this.ButtonOK_Click);
      // 
      // ButtonCancel
      // 
      this.ButtonCancel.Location = new System.Drawing.Point(180, 215);
      this.ButtonCancel.Name = "ButtonCancel";
      this.ButtonCancel.Size = new System.Drawing.Size(75, 23);
      this.ButtonCancel.TabIndex = 2;
      this.ButtonCancel.Text = "Cancel";
      this.ButtonCancel.UseVisualStyleBackColor = true;
      this.ButtonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.label1.Location = new System.Drawing.Point(8, 27);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(307, 17);
      this.label1.TabIndex = 3;
      this.label1.Text = "Select the Cameras that Will Receive Test Pictures";
      // 
      // TestPIcturesDialog
      // 
      this.AcceptButton = this.ButtonOK;
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.ButtonCancel;
      this.ClientSize = new System.Drawing.Size(354, 246);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.ButtonCancel);
      this.Controls.Add(this.ButtonOK);
      this.Controls.Add(this.checkedListBoxCameras);
      this.Name = "TestPIcturesDialog";
      this.Text = "Create Test Pictuers";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.CheckedListBox checkedListBoxCameras;
    private System.Windows.Forms.Button ButtonOK;
    private System.Windows.Forms.Button ButtonCancel;
    private System.Windows.Forms.Label label1;
  }
}