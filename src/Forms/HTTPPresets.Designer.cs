
namespace OnGuardCore
{
  partial class HTTPPresets
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HTTPPresets));
      this.cancelButton = new System.Windows.Forms.Button();
      this.OKButton = new System.Windows.Forms.Button();
      this.label1 = new System.Windows.Forms.Label();
      this.labelCurrentCamera = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.textBoxUrl = new System.Windows.Forms.TextBox();
      this.label3 = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // cancelButton
      // 
      this.cancelButton.Location = new System.Drawing.Point(485, 537);
      this.cancelButton.Name = "cancelButton";
      this.cancelButton.Size = new System.Drawing.Size(75, 23);
      this.cancelButton.TabIndex = 2;
      this.cancelButton.Text = "Cancel";
      this.cancelButton.UseVisualStyleBackColor = true;
      this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
      // 
      // OKButton
      // 
      this.OKButton.Location = new System.Drawing.Point(404, 537);
      this.OKButton.Name = "OKButton";
      this.OKButton.Size = new System.Drawing.Size(75, 23);
      this.OKButton.TabIndex = 1;
      this.OKButton.Text = "OK";
      this.OKButton.UseVisualStyleBackColor = true;
      this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.label1.Location = new System.Drawing.Point(393, 13);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(178, 16);
      this.label1.TabIndex = 48;
      this.label1.Text = "HTTP Preset Commands";
      // 
      // labelCurrentCamera
      // 
      this.labelCurrentCamera.AutoSize = true;
      this.labelCurrentCamera.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.labelCurrentCamera.Location = new System.Drawing.Point(393, 42);
      this.labelCurrentCamera.Name = "labelCurrentCamera";
      this.labelCurrentCamera.Size = new System.Drawing.Size(114, 16);
      this.labelCurrentCamera.TabIndex = 58;
      this.labelCurrentCamera.Text = "Current Camera";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.label2.Location = new System.Drawing.Point(68, 85);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(37, 16);
      this.label2.TabIndex = 490;
      this.label2.Text = "URL";
      // 
      // textBoxUrl
      // 
      this.textBoxUrl.Location = new System.Drawing.Point(119, 83);
      this.textBoxUrl.Name = "textBoxUrl";
      this.textBoxUrl.Size = new System.Drawing.Size(790, 23);
      this.textBoxUrl.TabIndex = 0;
      // 
      // label3
      // 
      this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      this.label3.Location = new System.Drawing.Point(12, 124);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(868, 390);
      this.label3.TabIndex = 491;
      this.label3.Text = resources.GetString("label3.Text");
      // 
      // HTTPPresets
      // 
      this.AcceptButton = this.OKButton;
      this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
      this.CancelButton = this.cancelButton;
      this.ClientSize = new System.Drawing.Size(964, 581);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.labelCurrentCamera);
      this.Controls.Add(this.cancelButton);
      this.Controls.Add(this.OKButton);
      this.Controls.Add(this.textBoxUrl);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Name = "HTTPPresets";
      this.Text = "HTTPPresets";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button cancelButton;
    private System.Windows.Forms.Button OKButton;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label labelCurrentCamera;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox textBoxUrl;
    private System.Windows.Forms.Label label3;
  }
}