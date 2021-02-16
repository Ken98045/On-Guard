namespace OnGuardCore
{
  partial class EditAreasOfInterest
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
      this.areasListView = new System.Windows.Forms.ListView();
      this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.doneButton = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // areasListView
      // 
      this.areasListView.Activation = System.Windows.Forms.ItemActivation.TwoClick;
      this.areasListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
      this.areasListView.FullRowSelect = true;
      this.areasListView.GridLines = true;
      this.areasListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
      this.areasListView.HideSelection = false;
      this.areasListView.Location = new System.Drawing.Point(12, 12);
      this.areasListView.Name = "areasListView";
      this.areasListView.Size = new System.Drawing.Size(531, 345);
      this.areasListView.TabIndex = 0;
      this.areasListView.UseCompatibleStateImageBehavior = false;
      this.areasListView.View = System.Windows.Forms.View.Details;
      this.areasListView.ItemActivate += new System.EventHandler(this.OnActivate);
      this.areasListView.SelectedIndexChanged += new System.EventHandler(this.AreasListView_SelectedIndexChanged);
      // 
      // columnHeader1
      // 
      this.columnHeader1.Text = "Area Name";
      this.columnHeader1.Width = 250;
      // 
      // columnHeader2
      // 
      this.columnHeader2.Text = "X";
      // 
      // columnHeader3
      // 
      this.columnHeader3.Text = "Y";
      // 
      // columnHeader4
      // 
      this.columnHeader4.Text = "Width";
      this.columnHeader4.Width = 70;
      // 
      // columnHeader5
      // 
      this.columnHeader5.Text = "Height";
      this.columnHeader5.Width = 50;
      // 
      // doneButton
      // 
      this.doneButton.Location = new System.Drawing.Point(240, 373);
      this.doneButton.Name = "doneButton";
      this.doneButton.Size = new System.Drawing.Size(75, 23);
      this.doneButton.TabIndex = 1;
      this.doneButton.Text = "Done";
      this.doneButton.UseVisualStyleBackColor = true;
      this.doneButton.Click += new System.EventHandler(this.DoneButton_Click);
      // 
      // EditAreasOfInterest
      // 
      this.AcceptButton = this.doneButton;
      this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
      this.ClientSize = new System.Drawing.Size(555, 412);
      this.Controls.Add(this.doneButton);
      this.Controls.Add(this.areasListView);
      this.Name = "EditAreasOfInterest";
      this.Text = "Edit Areas of Interest";
      this.ResumeLayout(false);

    }

        #endregion

        private System.Windows.Forms.ListView areasListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.Button doneButton;
    }
}