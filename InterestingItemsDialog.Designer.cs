namespace SAAI
{
  partial class InterestingItemsDialog
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
      this.doneButton = new System.Windows.Forms.Button();
      this.interestingListView = new System.Windows.Forms.ListView();
      this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.AreaType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.failuresList = new System.Windows.Forms.ListBox();
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // doneButton
      // 
      this.doneButton.Location = new System.Drawing.Point(366, 542);
      this.doneButton.Name = "doneButton";
      this.doneButton.Size = new System.Drawing.Size(75, 23);
      this.doneButton.TabIndex = 0;
      this.doneButton.Text = "Done";
      this.doneButton.UseVisualStyleBackColor = true;
      this.doneButton.Click += new System.EventHandler(this.DoneButton_Click);
      // 
      // interestingListView
      // 
      this.interestingListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.AreaType,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader7,
            this.columnHeader8});
      this.interestingListView.FullRowSelect = true;
      this.interestingListView.GridLines = true;
      this.interestingListView.HideSelection = false;
      this.interestingListView.Location = new System.Drawing.Point(32, 45);
      this.interestingListView.Name = "interestingListView";
      this.interestingListView.Size = new System.Drawing.Size(742, 158);
      this.interestingListView.TabIndex = 1;
      this.interestingListView.UseCompatibleStateImageBehavior = false;
      this.interestingListView.View = System.Windows.Forms.View.Details;
      // 
      // columnHeader1
      // 
      this.columnHeader1.Text = "Area Name";
      this.columnHeader1.Width = 167;
      // 
      // AreaType
      // 
      this.AreaType.Text = "Area Type";
      this.AreaType.Width = 144;
      // 
      // columnHeader2
      // 
      this.columnHeader2.Text = "Image Type";
      this.columnHeader2.Width = 105;
      // 
      // columnHeader3
      // 
      this.columnHeader3.Text = "Confidence";
      this.columnHeader3.Width = 93;
      // 
      // columnHeader4
      // 
      this.columnHeader4.Text = "Overlap";
      this.columnHeader4.Width = 69;
      // 
      // columnHeader7
      // 
      this.columnHeader7.Text = "Width";
      this.columnHeader7.Width = 70;
      // 
      // columnHeader8
      // 
      this.columnHeader8.Text = "Height";
      this.columnHeader8.Width = 70;
      // 
      // failuresList
      // 
      this.failuresList.FormattingEnabled = true;
      this.failuresList.Location = new System.Drawing.Point(32, 251);
      this.failuresList.Name = "failuresList";
      this.failuresList.Size = new System.Drawing.Size(742, 277);
      this.failuresList.TabIndex = 2;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label1.Location = new System.Drawing.Point(371, 229);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(64, 16);
      this.label1.TabIndex = 3;
      this.label1.Text = "Failures";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label2.Location = new System.Drawing.Point(370, 17);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(67, 16);
      this.label2.TabIndex = 4;
      this.label2.Text = "Success";
      // 
      // InterestingItemsDialog
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
      this.ClientSize = new System.Drawing.Size(807, 582);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.failuresList);
      this.Controls.Add(this.interestingListView);
      this.Controls.Add(this.doneButton);
      this.Name = "InterestingItemsDialog";
      this.Text = "Interesting Items";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

        #endregion

        private System.Windows.Forms.Button doneButton;
        private System.Windows.Forms.ListView interestingListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader AreaType;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
    private System.Windows.Forms.ColumnHeader columnHeader4;
    private System.Windows.Forms.ColumnHeader columnHeader7;
    private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ListBox failuresList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}