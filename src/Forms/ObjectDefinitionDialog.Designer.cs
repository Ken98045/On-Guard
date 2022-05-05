
namespace OnGuardCore
{
  partial class ObjectDefinitionDialog
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
      this.label2 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.label5 = new System.Windows.Forms.Label();
      this.label6 = new System.Windows.Forms.Label();
      this.ObjectCombo = new System.Windows.Forms.ComboBox();
      this.ConfidenceNumeric = new System.Windows.Forms.NumericUpDown();
      this.overlapNumeric = new System.Windows.Forms.NumericUpDown();
      this.minWidthNumeric = new System.Windows.Forms.NumericUpDown();
      this.minHeightNumeric = new System.Windows.Forms.NumericUpDown();
      this.panel1 = new System.Windows.Forms.Panel();
      this.label12 = new System.Windows.Forms.Label();
      this.label11 = new System.Windows.Forms.Label();
      this.label10 = new System.Windows.Forms.Label();
      this.label9 = new System.Windows.Forms.Label();
      this.label8 = new System.Windows.Forms.Label();
      this.OKButton = new System.Windows.Forms.Button();
      this.FormCancelButton = new System.Windows.Forms.Button();
      ((System.ComponentModel.ISupportInitialize)(this.ConfidenceNumeric)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.overlapNumeric)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.minWidthNumeric)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.minHeightNumeric)).BeginInit();
      this.panel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.label1.Location = new System.Drawing.Point(196, 22);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(338, 15);
      this.label1.TabIndex = 0;
      this.label1.Text = "Setup Object Definitions That On Guard Recognizes";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.label2.Location = new System.Drawing.Point(128, 39);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(86, 15);
      this.label2.TabIndex = 1;
      this.label2.Text = "Object Type:";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.label3.Location = new System.Drawing.Point(89, 90);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(121, 15);
      this.label3.TabIndex = 2;
      this.label3.Text = "Confidence Level:";
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.label4.Location = new System.Drawing.Point(25, 137);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(189, 15);
      this.label4.TabIndex = 3;
      this.label4.Text = "Minimum Overlap onto Area:";
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.label5.Location = new System.Drawing.Point(103, 184);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(111, 15);
      this.label5.TabIndex = 4;
      this.label5.Text = "Minimum Width:";
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.label6.Location = new System.Drawing.Point(97, 231);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(117, 15);
      this.label6.TabIndex = 5;
      this.label6.Text = "Minimum Height:";
      // 
      // ObjectCombo
      // 
      this.ObjectCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.ObjectCombo.FormattingEnabled = true;
      this.ObjectCombo.Items.AddRange(new object[] {
            "person",
            "* Any Vehicle",
            "* Any Mammal",
            "car",
            "truck",
            "bicycle",
            "motorbike",
            "dog",
            "bear",
            "bus",
            "train",
            "boat",
            "cat",
            "bird",
            "horse",
            "sheep",
            "cow",
            "elephant",
            "zebra",
            "giraffe",
            "backpack",
            "umbrella",
            "aeroplane",
            "suitcase",
            "traffic light",
            "fire hydrant",
            "stop sign",
            "parking meter",
            "bench",
            "handbag",
            "tie",
            "frisbee",
            "skis",
            "snowboard",
            "sports ball",
            "kite",
            "baseball bat",
            "baseball glove",
            "skateboard",
            "surfboard",
            "tennis racket",
            "bottle",
            "wine glass",
            "cup",
            "fork",
            "knife",
            "spoon",
            "bowl",
            "banana",
            "apple",
            "sandwich",
            "orange",
            "broccoli",
            "carrot",
            "hot dog",
            "pizza",
            "donut",
            "cake",
            "chair",
            "sofa",
            "pottedplant",
            "bed",
            "diningtable",
            "toilet",
            "tvmonitor",
            "laptop",
            "mouse",
            "remote",
            "keyboard",
            "cell phone",
            "microwave",
            "oven",
            "toaster",
            "sink",
            "refrigerator",
            "book",
            "clock",
            "vase",
            "scissors",
            "teddy bear",
            "hair drier",
            "toothbrush"});
      this.ObjectCombo.Location = new System.Drawing.Point(235, 38);
      this.ObjectCombo.Name = "ObjectCombo";
      this.ObjectCombo.Size = new System.Drawing.Size(121, 23);
      this.ObjectCombo.TabIndex = 0;
      // 
      // ConfidenceNumeric
      // 
      this.ConfidenceNumeric.Location = new System.Drawing.Point(235, 90);
      this.ConfidenceNumeric.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
      this.ConfidenceNumeric.Minimum = new decimal(new int[] {
            40,
            0,
            0,
            0});
      this.ConfidenceNumeric.Name = "ConfidenceNumeric";
      this.ConfidenceNumeric.Size = new System.Drawing.Size(74, 23);
      this.ConfidenceNumeric.TabIndex = 1;
      this.ConfidenceNumeric.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      this.ConfidenceNumeric.Value = new decimal(new int[] {
            80,
            0,
            0,
            0});
      // 
      // overlapNumeric
      // 
      this.overlapNumeric.Location = new System.Drawing.Point(235, 137);
      this.overlapNumeric.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
      this.overlapNumeric.Name = "overlapNumeric";
      this.overlapNumeric.Size = new System.Drawing.Size(74, 23);
      this.overlapNumeric.TabIndex = 2;
      this.overlapNumeric.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      this.overlapNumeric.Value = new decimal(new int[] {
            75,
            0,
            0,
            0});
      // 
      // minWidthNumeric
      // 
      this.minWidthNumeric.DecimalPlaces = 1;
      this.minWidthNumeric.Location = new System.Drawing.Point(235, 184);
      this.minWidthNumeric.Name = "minWidthNumeric";
      this.minWidthNumeric.Size = new System.Drawing.Size(74, 23);
      this.minWidthNumeric.TabIndex = 3;
      this.minWidthNumeric.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      // 
      // minHeightNumeric
      // 
      this.minHeightNumeric.DecimalPlaces = 1;
      this.minHeightNumeric.Location = new System.Drawing.Point(235, 226);
      this.minHeightNumeric.Name = "minHeightNumeric";
      this.minHeightNumeric.Size = new System.Drawing.Size(74, 23);
      this.minHeightNumeric.TabIndex = 4;
      this.minHeightNumeric.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      // 
      // panel1
      // 
      this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.panel1.Controls.Add(this.label12);
      this.panel1.Controls.Add(this.label11);
      this.panel1.Controls.Add(this.label10);
      this.panel1.Controls.Add(this.label9);
      this.panel1.Controls.Add(this.label8);
      this.panel1.Controls.Add(this.label4);
      this.panel1.Controls.Add(this.label2);
      this.panel1.Controls.Add(this.minHeightNumeric);
      this.panel1.Controls.Add(this.label3);
      this.panel1.Controls.Add(this.minWidthNumeric);
      this.panel1.Controls.Add(this.label5);
      this.panel1.Controls.Add(this.overlapNumeric);
      this.panel1.Controls.Add(this.label6);
      this.panel1.Controls.Add(this.ConfidenceNumeric);
      this.panel1.Controls.Add(this.ObjectCombo);
      this.panel1.Location = new System.Drawing.Point(27, 58);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(676, 278);
      this.panel1.TabIndex = 13;
      // 
      // label12
      // 
      this.label12.AutoSize = true;
      this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.label12.Location = new System.Drawing.Point(371, 137);
      this.label12.Name = "label12";
      this.label12.Size = new System.Drawing.Size(139, 15);
      this.label12.TabIndex = 17;
      this.label12.Text = "Percentage (1 - 100)";
      // 
      // label11
      // 
      this.label11.AutoSize = true;
      this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.label11.Location = new System.Drawing.Point(371, 226);
      this.label11.Name = "label11";
      this.label11.Size = new System.Drawing.Size(279, 15);
      this.label11.TabIndex = 16;
      this.label11.Text = "Height in % of Screen (0 = Don\'t Consider)";
      // 
      // label10
      // 
      this.label10.AutoSize = true;
      this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.label10.Location = new System.Drawing.Point(377, 184);
      this.label10.Name = "label10";
      this.label10.Size = new System.Drawing.Size(273, 15);
      this.label10.TabIndex = 15;
      this.label10.Text = "Width in % of Screen (0 = Don\'t Consider)";
      // 
      // label9
      // 
      this.label9.AutoSize = true;
      this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.label9.Location = new System.Drawing.Point(371, 90);
      this.label9.Name = "label9";
      this.label9.Size = new System.Drawing.Size(139, 15);
      this.label9.TabIndex = 14;
      this.label9.Text = "Percentage (40 - 99)";
      // 
      // label8
      // 
      this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.label8.Location = new System.Drawing.Point(371, 26);
      this.label8.Name = "label8";
      this.label8.Size = new System.Drawing.Size(266, 47);
      this.label8.TabIndex = 13;
      this.label8.Text = "All Objects Recognized by DeepStack\r\nThey are Listed in Estimated Order of Securi" +
    "ty Camera Relevance\r\n";
      // 
      // OKButton
      // 
      this.OKButton.Location = new System.Drawing.Point(281, 348);
      this.OKButton.Name = "OKButton";
      this.OKButton.Size = new System.Drawing.Size(75, 23);
      this.OKButton.TabIndex = 0;
      this.OKButton.Text = "OK";
      this.OKButton.UseVisualStyleBackColor = true;
      this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
      // 
      // FormCancelButton
      // 
      this.FormCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.FormCancelButton.Location = new System.Drawing.Point(374, 348);
      this.FormCancelButton.Name = "FormCancelButton";
      this.FormCancelButton.Size = new System.Drawing.Size(75, 23);
      this.FormCancelButton.TabIndex = 1;
      this.FormCancelButton.Text = "Cancel";
      this.FormCancelButton.UseVisualStyleBackColor = true;
      this.FormCancelButton.Click += new System.EventHandler(this.CancelButton_Click);
      // 
      // ObjectDefinitionDialog
      // 
      this.AcceptButton = this.OKButton;
      this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
      this.AutoScroll = true;
      this.ClientSize = new System.Drawing.Size(730, 378);
      this.Controls.Add(this.FormCancelButton);
      this.Controls.Add(this.OKButton);
      this.Controls.Add(this.panel1);
      this.Controls.Add(this.label1);
      this.Name = "ObjectDefinitionDialog";
      this.Text = "Create a  Recognized Object";
      ((System.ComponentModel.ISupportInitialize)(this.ConfidenceNumeric)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.overlapNumeric)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.minWidthNumeric)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.minHeightNumeric)).EndInit();
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.ComboBox ObjectCombo;
    private System.Windows.Forms.NumericUpDown ConfidenceNumeric;
    private System.Windows.Forms.NumericUpDown overlapNumeric;
    private System.Windows.Forms.NumericUpDown minWidthNumeric;
    private System.Windows.Forms.NumericUpDown minHeightNumeric;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Label label12;
    private System.Windows.Forms.Label label11;
    private System.Windows.Forms.Label label10;
    private System.Windows.Forms.Label label9;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.Button OKButton;
    private System.Windows.Forms.Button FormCancelButton;
  }
}