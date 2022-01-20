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
      this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
      this.doneButton = new System.Windows.Forms.Button();
      this.DeleteButton = new System.Windows.Forms.Button();
      this.EditButton = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // areasListView
      // 
      this.areasListView.Activation = System.Windows.Forms.ItemActivation.TwoClick;
      this.areasListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
      this.areasListView.FullRowSelect = true;
      this.areasListView.GridLines = true;
      this.areasListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
      this.areasListView.Location = new System.Drawing.Point(12, 12);
      this.areasListView.Name = "areasListView";
      this.areasListView.Size = new System.Drawing.Size(304, 275);
      this.areasListView.TabIndex = 0;
      this.areasListView.UseCompatibleStateImageBehavior = false;
      this.areasListView.View = System.Windows.Forms.View.Details;
      this.areasListView.ItemActivate += new System.EventHandler(this.OnActivate);
      this.areasListView.SelectedIndexChanged += new System.EventHandler(this.AreasListView_SelectedIndexChanged);
      // 
      // columnHeader1
      // 
      this.columnHeader1.Text = "Area Name";
      this.columnHeader1.Width = 300;
      // 
      // doneButton
      // 
      this.doneButton.Location = new System.Drawing.Point(209, 297);
      this.doneButton.Name = "doneButton";
      this.doneButton.Size = new System.Drawing.Size(75, 23);
      this.doneButton.TabIndex = 2;
      this.doneButton.Text = "Exit";
      this.doneButton.UseVisualStyleBackColor = true;
      this.doneButton.Click += new System.EventHandler(this.DoneButton_Click);
      // 
      // DeleteButton
      // 
      this.DeleteButton.Enabled = false;
      this.DeleteButton.Location = new System.Drawing.Point(127, 297);
      this.DeleteButton.Name = "DeleteButton";
      this.DeleteButton.Size = new System.Drawing.Size(75, 23);
      this.DeleteButton.TabIndex = 1;
      this.DeleteButton.Text = "Delete";
      this.DeleteButton.UseVisualStyleBackColor = true;
      this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
      // 
      // EditButton
      // 
      this.EditButton.Enabled = false;
      this.EditButton.Location = new System.Drawing.Point(45, 297);
      this.EditButton.Name = "EditButton";
      this.EditButton.Size = new System.Drawing.Size(75, 23);
      this.EditButton.TabIndex = 0;
      this.EditButton.Text = "Edit";
      this.EditButton.UseVisualStyleBackColor = true;
      this.EditButton.Click += new System.EventHandler(this.EditButton_Click);
      // 
      // EditAreasOfInterest
      // 
      this.AcceptButton = this.doneButton;
      this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
      this.ClientSize = new System.Drawing.Size(328, 334);
      this.Controls.Add(this.EditButton);
      this.Controls.Add(this.DeleteButton);
      this.Controls.Add(this.doneButton);
      this.Controls.Add(this.areasListView);
      this.Name = "EditAreasOfInterest";
      this.Text = "Edit Areas of Interest";
      this.ResumeLayout(false);

    }

        #endregion

        private System.Windows.Forms.ListView areasListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Button doneButton;
    private System.Windows.Forms.Button DeleteButton;
    private System.Windows.Forms.Button EditButton;
  }
}