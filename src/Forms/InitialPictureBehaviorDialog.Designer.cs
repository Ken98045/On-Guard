namespace OnGuardCore
{
  partial class InitialPictureBehaviorDialog
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InitialPictureBehaviorDialog));
      this.panel1 = new System.Windows.Forms.Panel();
      this.radioButtonLastViewed = new System.Windows.Forms.RadioButton();
      this.radioButtonEnteredDateTime = new System.Windows.Forms.RadioButton();
      this.radioButtonPicture1 = new System.Windows.Forms.RadioButton();
      this.label1 = new System.Windows.Forms.Label();
      this.buttonOK = new System.Windows.Forms.Button();
      this.ButtonCancel = new System.Windows.Forms.Button();
      this.label3 = new System.Windows.Forms.Label();
      this.panel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // panel1
      // 
      this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.panel1.Controls.Add(this.radioButtonLastViewed);
      this.panel1.Controls.Add(this.radioButtonEnteredDateTime);
      this.panel1.Controls.Add(this.radioButtonPicture1);
      this.panel1.Location = new System.Drawing.Point(71, 65);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(298, 123);
      this.panel1.TabIndex = 0;
      // 
      // radioButtonLastViewed
      // 
      this.radioButtonLastViewed.AutoSize = true;
      this.radioButtonLastViewed.Location = new System.Drawing.Point(26, 81);
      this.radioButtonLastViewed.Name = "radioButtonLastViewed";
      this.radioButtonLastViewed.Size = new System.Drawing.Size(205, 19);
      this.radioButtonLastViewed.TabIndex = 2;
      this.radioButtonLastViewed.TabStop = true;
      this.radioButtonLastViewed.Text = "Go To Last View Picture Date/Time";
      this.radioButtonLastViewed.UseVisualStyleBackColor = true;
      // 
      // radioButtonEnteredDateTime
      // 
      this.radioButtonEnteredDateTime.AutoSize = true;
      this.radioButtonEnteredDateTime.Location = new System.Drawing.Point(26, 47);
      this.radioButtonEnteredDateTime.Name = "radioButtonEnteredDateTime";
      this.radioButtonEnteredDateTime.Size = new System.Drawing.Size(225, 19);
      this.radioButtonEnteredDateTime.TabIndex = 1;
      this.radioButtonEnteredDateTime.TabStop = true;
      this.radioButtonEnteredDateTime.Text = "Go To Entered Date/Time (If Available)";
      this.radioButtonEnteredDateTime.UseVisualStyleBackColor = true;
      // 
      // radioButtonPicture1
      // 
      this.radioButtonPicture1.AutoSize = true;
      this.radioButtonPicture1.Location = new System.Drawing.Point(26, 13);
      this.radioButtonPicture1.Name = "radioButtonPicture1";
      this.radioButtonPicture1.Size = new System.Drawing.Size(104, 19);
      this.radioButtonPicture1.TabIndex = 0;
      this.radioButtonPicture1.TabStop = true;
      this.radioButtonPicture1.Text = "Go To Picture 1";
      this.radioButtonPicture1.UseVisualStyleBackColor = true;
      // 
      // label1
      // 
      this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.label1.Location = new System.Drawing.Point(44, 9);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(353, 46);
      this.label1.TabIndex = 1;
      this.label1.Text = "Select the Desired Picture Selection Behavior When Changing Cameras and the Refre" +
    "shing Working Set";
      // 
      // buttonOK
      // 
      this.buttonOK.Location = new System.Drawing.Point(141, 301);
      this.buttonOK.Name = "buttonOK";
      this.buttonOK.Size = new System.Drawing.Size(75, 23);
      this.buttonOK.TabIndex = 0;
      this.buttonOK.Text = "OK";
      this.buttonOK.UseVisualStyleBackColor = true;
      this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
      // 
      // ButtonCancel
      // 
      this.ButtonCancel.Location = new System.Drawing.Point(224, 301);
      this.ButtonCancel.Name = "ButtonCancel";
      this.ButtonCancel.Size = new System.Drawing.Size(75, 23);
      this.ButtonCancel.TabIndex = 1;
      this.ButtonCancel.Text = "Cancel";
      this.ButtonCancel.UseVisualStyleBackColor = true;
      this.ButtonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
      // 
      // label3
      // 
      this.label3.Location = new System.Drawing.Point(11, 201);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(418, 87);
      this.label3.TabIndex = 5;
      this.label3.Text = resources.GetString("label3.Text");
      // 
      // InitialPictureBehaviorDialog
      // 
      this.AcceptButton = this.buttonOK;
      this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
      this.CancelButton = this.ButtonCancel;
      this.ClientSize = new System.Drawing.Size(440, 339);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.ButtonCancel);
      this.Controls.Add(this.buttonOK);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.panel1);
      this.Name = "InitialPictureBehaviorDialog";
      this.Text = "Fixed Picture Date";
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.ResumeLayout(false);

    }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button ButtonCancel;
        private System.Windows.Forms.RadioButton radioButtonLastViewed;
        private System.Windows.Forms.RadioButton radioButtonEnteredDateTime;
        private System.Windows.Forms.RadioButton radioButtonPicture1;
    private System.Windows.Forms.Label label3;
  }
}