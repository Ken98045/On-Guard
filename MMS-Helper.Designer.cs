namespace SAAI
{
  partial class MMSHelper
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MMSHelper));
      this.mmsListView = new System.Windows.Forms.ListView();
      this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.HelperCancelButton = new System.Windows.Forms.Button();
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // mmsListView
      // 
      this.mmsListView.CausesValidation = false;
      this.mmsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
      this.mmsListView.GridLines = true;
      this.mmsListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
      this.mmsListView.HideSelection = false;
      this.mmsListView.Location = new System.Drawing.Point(13, 405);
      this.mmsListView.MultiSelect = false;
      this.mmsListView.Name = "mmsListView";
      this.mmsListView.Size = new System.Drawing.Size(463, 322);
      this.mmsListView.Sorting = System.Windows.Forms.SortOrder.Ascending;
      this.mmsListView.TabIndex = 0;
      this.mmsListView.UseCompatibleStateImageBehavior = false;
      this.mmsListView.View = System.Windows.Forms.View.Details;
      this.mmsListView.ItemActivate += new System.EventHandler(this.OnActiveate);
      // 
      // columnHeader1
      // 
      this.columnHeader1.Text = "Cellular Provider";
      this.columnHeader1.Width = 153;
      // 
      // columnHeader2
      // 
      this.columnHeader2.Text = "Number Format";
      this.columnHeader2.Width = 240;
      // 
      // HelperCancelButton
      // 
      this.HelperCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.HelperCancelButton.Location = new System.Drawing.Point(207, 792);
      this.HelperCancelButton.Name = "HelperCancelButton";
      this.HelperCancelButton.Size = new System.Drawing.Size(75, 23);
      this.HelperCancelButton.TabIndex = 1;
      this.HelperCancelButton.Text = "Cancel";
      this.HelperCancelButton.UseVisualStyleBackColor = true;
      this.HelperCancelButton.Click += new System.EventHandler(this.CancelButton_Click);
      // 
      // label1
      // 
      this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label1.Location = new System.Drawing.Point(92, 741);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(304, 41);
      this.label1.TabIndex = 2;
      this.label1.Text = "Double Click a Carrier to Select It.\r\nClick Cancel to Exit Without a Selection";
      // 
      // label2
      // 
      this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label2.Location = new System.Drawing.Point(13, 13);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(463, 365);
      this.label2.TabIndex = 3;
      this.label2.Text = resources.GetString("label2.Text");
      // 
      // MMSHelper
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
      this.AutoScroll = true;
      this.ClientSize = new System.Drawing.Size(488, 827);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.HelperCancelButton);
      this.Controls.Add(this.mmsListView);
      this.Name = "MMSHelper";
      this.Text = "MMS_Helper";
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.ListView mmsListView;
    private System.Windows.Forms.Button HelperCancelButton;
    private System.Windows.Forms.ColumnHeader columnHeader1;
    private System.Windows.Forms.ColumnHeader columnHeader2;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
  }
}