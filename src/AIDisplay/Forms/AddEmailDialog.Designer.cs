namespace SAAI
{
  partial class AddEmailDialog
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
      this.zdsf = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.emailAddressList = new System.Windows.Forms.ListBox();
      this.SuspendLayout();
      // 
      // okButton
      // 
      this.okButton.Location = new System.Drawing.Point(131, 163);
      this.okButton.Name = "okButton";
      this.okButton.Size = new System.Drawing.Size(75, 23);
      this.okButton.TabIndex = 2;
      this.okButton.Text = "OK";
      this.okButton.UseVisualStyleBackColor = true;
      this.okButton.Click += new System.EventHandler(this.OkButton_Click);
      // 
      // cancelButton
      // 
      this.cancelButton.Location = new System.Drawing.Point(224, 163);
      this.cancelButton.Name = "cancelButton";
      this.cancelButton.Size = new System.Drawing.Size(75, 23);
      this.cancelButton.TabIndex = 3;
      this.cancelButton.Text = "Cancel";
      this.cancelButton.UseVisualStyleBackColor = true;
      this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
      // 
      // zdsf
      // 
      this.zdsf.AutoSize = true;
      this.zdsf.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.zdsf.Location = new System.Drawing.Point(104, 22);
      this.zdsf.Name = "zdsf";
      this.zdsf.Size = new System.Drawing.Size(223, 15);
      this.zdsf.TabIndex = 3;
      this.zdsf.Text = "Select the Email Address to Notify";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(3, 89);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(79, 13);
      this.label2.TabIndex = 32;
      this.label2.Text = "Email Address: ";
      // 
      // emailAddressList
      // 
      this.emailAddressList.FormattingEnabled = true;
      this.emailAddressList.Location = new System.Drawing.Point(92, 54);
      this.emailAddressList.Name = "emailAddressList";
      this.emailAddressList.Size = new System.Drawing.Size(246, 95);
      this.emailAddressList.TabIndex = 33;
      this.emailAddressList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.OnMouseDoubleClick);
      // 
      // AddEmailDialog
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
      this.ClientSize = new System.Drawing.Size(431, 198);
      this.Controls.Add(this.emailAddressList);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.zdsf);
      this.Controls.Add(this.cancelButton);
      this.Controls.Add(this.okButton);
      this.Name = "AddEmailDialog";
      this.Text = "Add Email Address to Notify";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

        #endregion

        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label zdsf;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox emailAddressList;
    }
}