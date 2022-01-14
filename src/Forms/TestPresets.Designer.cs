
namespace OnGuardCore
{
  partial class TestPresets
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
      this.pictureBox = new System.Windows.Forms.PictureBox();
      this.ComboBoxPresets = new System.Windows.Forms.ComboBox();
      this.labelCurrentCamera = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
      this.SuspendLayout();
      // 
      // OKButton
      // 
      this.OKButton.Location = new System.Drawing.Point(284, 327);
      this.OKButton.Name = "OKButton";
      this.OKButton.Size = new System.Drawing.Size(75, 23);
      this.OKButton.TabIndex = 0;
      this.OKButton.Text = "OK";
      this.OKButton.UseVisualStyleBackColor = true;
      this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
      // 
      // pictureBox
      // 
      this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.pictureBox.Location = new System.Drawing.Point(255, 69);
      this.pictureBox.Name = "pictureBox";
      this.pictureBox.Size = new System.Drawing.Size(320, 240);
      this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
      this.pictureBox.TabIndex = 1;
      this.pictureBox.TabStop = false;
      // 
      // ComboBoxPresets
      // 
      this.ComboBoxPresets.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.ComboBoxPresets.FormattingEnabled = true;
      this.ComboBoxPresets.Location = new System.Drawing.Point(35, 161);
      this.ComboBoxPresets.Name = "ComboBoxPresets";
      this.ComboBoxPresets.Size = new System.Drawing.Size(147, 23);
      this.ComboBoxPresets.TabIndex = 2;
      this.ComboBoxPresets.SelectedIndexChanged += new System.EventHandler(this.OnPresetChanged);
      // 
      // labelCurrentCamera
      // 
      this.labelCurrentCamera.AutoSize = true;
      this.labelCurrentCamera.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.labelCurrentCamera.Location = new System.Drawing.Point(251, 35);
      this.labelCurrentCamera.Name = "labelCurrentCamera";
      this.labelCurrentCamera.Size = new System.Drawing.Size(114, 16);
      this.labelCurrentCamera.TabIndex = 60;
      this.labelCurrentCamera.Text = "Current Camera";
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.label1.Location = new System.Drawing.Point(274, 9);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(95, 16);
      this.label1.TabIndex = 59;
      this.label1.Text = "Test Presets";
      // 
      // label2
      // 
      this.label2.Location = new System.Drawing.Point(35, 69);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(214, 67);
      this.label2.TabIndex = 61;
      this.label2.Text = "Select the Preset to test from the box below.  Note that not all cameras can hand" +
    "le moving to a second Preset while the first move is in progress.";
      // 
      // TestPresets
      // 
      this.AcceptButton = this.OKButton;
      this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
      this.AutoScroll = true;
      this.ClientSize = new System.Drawing.Size(643, 352);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.labelCurrentCamera);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.ComboBoxPresets);
      this.Controls.Add(this.pictureBox);
      this.Controls.Add(this.OKButton);
      this.Name = "TestPresets";
      this.Text = "Test Presets";
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button OKButton;
    private System.Windows.Forms.PictureBox pictureBox;
    private System.Windows.Forms.ComboBox ComboBoxPresets;
    private System.Windows.Forms.Label labelCurrentCamera;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
  }
}