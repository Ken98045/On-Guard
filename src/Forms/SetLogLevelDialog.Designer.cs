namespace OnGuardCore
{
  partial class SetLogLevelDialog
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SetLogLevelDialog));
      this.panel1 = new System.Windows.Forms.Panel();
      this.label8 = new System.Windows.Forms.Label();
      this.radioDetailedInfo = new System.Windows.Forms.RadioButton();
      this.label4 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.radioError = new System.Windows.Forms.RadioButton();
      this.radioWarning = new System.Windows.Forms.RadioButton();
      this.radioInfo = new System.Windows.Forms.RadioButton();
      this.radioVerbose = new System.Windows.Forms.RadioButton();
      this.ButtonOK = new System.Windows.Forms.Button();
      this.ButtonCancel = new System.Windows.Forms.Button();
      this.label6 = new System.Windows.Forms.Label();
      this.label7 = new System.Windows.Forms.Label();
      this.panel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // panel1
      // 
      this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.panel1.Controls.Add(this.label8);
      this.panel1.Controls.Add(this.radioDetailedInfo);
      this.panel1.Controls.Add(this.label4);
      this.panel1.Controls.Add(this.label3);
      this.panel1.Controls.Add(this.label2);
      this.panel1.Controls.Add(this.label1);
      this.panel1.Controls.Add(this.radioError);
      this.panel1.Controls.Add(this.radioWarning);
      this.panel1.Controls.Add(this.radioInfo);
      this.panel1.Controls.Add(this.radioVerbose);
      this.panel1.Location = new System.Drawing.Point(13, 75);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(706, 295);
      this.panel1.TabIndex = 0;
      // 
      // label8
      // 
      this.label8.Location = new System.Drawing.Point(116, 68);
      this.label8.Name = "label8";
      this.label8.Size = new System.Drawing.Size(571, 51);
      this.label8.TabIndex = 11;
      this.label8.Text = resources.GetString("label8.Text");
      // 
      // radioDetailedInfo
      // 
      this.radioDetailedInfo.AutoSize = true;
      this.radioDetailedInfo.Location = new System.Drawing.Point(18, 74);
      this.radioDetailedInfo.Name = "radioDetailedInfo";
      this.radioDetailedInfo.Size = new System.Drawing.Size(92, 19);
      this.radioDetailedInfo.TabIndex = 10;
      this.radioDetailedInfo.TabStop = true;
      this.radioDetailedInfo.Text = "Detailed Info";
      this.radioDetailedInfo.UseVisualStyleBackColor = true;
      // 
      // label4
      // 
      this.label4.Location = new System.Drawing.Point(116, 246);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(571, 41);
      this.label4.TabIndex = 8;
      this.label4.Text = "Includes information related to errors in picture processing and/or camera setup " +
    "problems.  It may include serious application bugs.";
      // 
      // label3
      // 
      this.label3.Location = new System.Drawing.Point(116, 186);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(571, 51);
      this.label3.TabIndex = 7;
      this.label3.Text = resources.GetString("label3.Text");
      // 
      // label2
      // 
      this.label2.Location = new System.Drawing.Point(116, 132);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(571, 31);
      this.label2.TabIndex = 6;
      this.label2.Text = "Includes more general information that typically shows the normal processing of p" +
    "ictures. ";
      // 
      // label1
      // 
      this.label1.Location = new System.Drawing.Point(116, 10);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(571, 33);
      this.label1.TabIndex = 5;
      this.label1.Text = "Includes very detailed and often very technical information.  This setting will r" +
    "esult in a LOT of information in the log file.  A large part of this information" +
    " is not useful to the typical user.";
      // 
      // radioError
      // 
      this.radioError.AutoSize = true;
      this.radioError.Location = new System.Drawing.Point(18, 251);
      this.radioError.Name = "radioError";
      this.radioError.Size = new System.Drawing.Size(50, 19);
      this.radioError.TabIndex = 3;
      this.radioError.TabStop = true;
      this.radioError.Text = "Error";
      this.radioError.UseVisualStyleBackColor = true;
      // 
      // radioWarning
      // 
      this.radioWarning.AutoSize = true;
      this.radioWarning.Location = new System.Drawing.Point(18, 192);
      this.radioWarning.Name = "radioWarning";
      this.radioWarning.Size = new System.Drawing.Size(70, 19);
      this.radioWarning.TabIndex = 2;
      this.radioWarning.TabStop = true;
      this.radioWarning.Text = "Warning";
      this.radioWarning.UseVisualStyleBackColor = true;
      // 
      // radioInfo
      // 
      this.radioInfo.AutoSize = true;
      this.radioInfo.Location = new System.Drawing.Point(18, 133);
      this.radioInfo.Name = "radioInfo";
      this.radioInfo.Size = new System.Drawing.Size(46, 19);
      this.radioInfo.TabIndex = 1;
      this.radioInfo.TabStop = true;
      this.radioInfo.Text = "Info";
      this.radioInfo.UseVisualStyleBackColor = true;
      // 
      // radioVerbose
      // 
      this.radioVerbose.AutoSize = true;
      this.radioVerbose.Location = new System.Drawing.Point(18, 15);
      this.radioVerbose.Name = "radioVerbose";
      this.radioVerbose.Size = new System.Drawing.Size(66, 19);
      this.radioVerbose.TabIndex = 0;
      this.radioVerbose.TabStop = true;
      this.radioVerbose.Text = "Verbose";
      this.radioVerbose.UseVisualStyleBackColor = true;
      // 
      // ButtonOK
      // 
      this.ButtonOK.Location = new System.Drawing.Point(288, 378);
      this.ButtonOK.Name = "ButtonOK";
      this.ButtonOK.Size = new System.Drawing.Size(75, 23);
      this.ButtonOK.TabIndex = 1;
      this.ButtonOK.Text = "OK";
      this.ButtonOK.UseVisualStyleBackColor = true;
      this.ButtonOK.Click += new System.EventHandler(this.OK_Click);
      // 
      // ButtonCancel
      // 
      this.ButtonCancel.Location = new System.Drawing.Point(369, 378);
      this.ButtonCancel.Name = "ButtonCancel";
      this.ButtonCancel.Size = new System.Drawing.Size(75, 23);
      this.ButtonCancel.TabIndex = 2;
      this.ButtonCancel.Text = "Cancel";
      this.ButtonCancel.UseVisualStyleBackColor = true;
      this.ButtonCancel.Click += new System.EventHandler(this.CancelButton_Click);
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.label6.Location = new System.Drawing.Point(289, 7);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(155, 17);
      this.label6.TabIndex = 3;
      this.label6.Text = "Set the Log Detail Level";
      // 
      // label7
      // 
      this.label7.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.label7.Location = new System.Drawing.Point(76, 34);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(581, 32);
      this.label7.TabIndex = 4;
      this.label7.Text = "The higer detail levels (Verbose etc.) also include messages for the lower detail" +
    " level (more serious) issues \r\n(Warning, Error etc.)";
      // 
      // SetLogLevelDialog
      // 
      this.AcceptButton = this.ButtonOK;
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.ButtonCancel;
      this.ClientSize = new System.Drawing.Size(733, 411);
      this.Controls.Add(this.label7);
      this.Controls.Add(this.label6);
      this.Controls.Add(this.ButtonCancel);
      this.Controls.Add(this.ButtonOK);
      this.Controls.Add(this.panel1);
      this.Name = "SetLogLevelDialog";
      this.Text = "Set Log Detail Level";
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radioError;
        private System.Windows.Forms.RadioButton radioWarning;
        private System.Windows.Forms.RadioButton radioInfo;
        private System.Windows.Forms.RadioButton radioVerbose;
        private System.Windows.Forms.Button ButtonOK;
        private System.Windows.Forms.Button ButtonCancel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.RadioButton radioDetailedInfo;
  }
}