namespace CAS.Lib.OPCClientControlsLib
{
  partial class UpdatesViewCtrl
  {
    /// <summary> 
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary> 
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose( bool disposing )
    {
      if ( disposing && ( components != null ) )
      {
        components.Dispose();
      }
      base.Dispose( disposing );
    }

    #region Component Designer generated code

    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
      this.m_ItemListLV = new System.Windows.Forms.ListView();
      this.m_PopupMenu = new System.Windows.Forms.ContextMenuStrip( this.components );
      this.m_CMS_View = new System.Windows.Forms.ToolStripMenuItem();
      this.m_CMS_ShowErrorText = new System.Windows.Forms.ToolStripMenuItem();
      this.m_CMS_KeepValues = new System.Windows.Forms.ToolStripMenuItem();
      this.m_CMS_Clear = new System.Windows.Forms.ToolStripMenuItem();
      this.m_ImageListLibrary = new CAS.Lib.ControlLibrary.ImageListLibrary();
      toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
      this.m_PopupMenu.SuspendLayout();
      this.SuspendLayout();
      // 
      // toolStripSeparator1
      // 
      toolStripSeparator1.Name = "toolStripSeparator1";
      toolStripSeparator1.Size = new System.Drawing.Size( 160, 6 );
      // 
      // m_ItemListLV
      // 
      this.m_ItemListLV.ContextMenuStrip = this.m_PopupMenu;
      this.m_ItemListLV.Dock = System.Windows.Forms.DockStyle.Fill;
      this.m_ItemListLV.Location = new System.Drawing.Point( 0, 0 );
      this.m_ItemListLV.MultiSelect = false;
      this.m_ItemListLV.Name = "m_ItemListLV";
      this.m_ItemListLV.ShowItemToolTips = true;
      this.m_ItemListLV.Size = new System.Drawing.Size( 432, 272 );
      this.m_ItemListLV.TabIndex = 0;
      this.m_ItemListLV.UseCompatibleStateImageBehavior = false;
      this.m_ItemListLV.View = System.Windows.Forms.View.Details;
      this.m_ItemListLV.DoubleClick += new System.EventHandler( this.m_CMS_View_Click );
      this.m_ItemListLV.MouseDown += new System.Windows.Forms.MouseEventHandler( this.m_ItemListLV_MouseDown );
      this.m_ItemListLV.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler( SortHandler.listView_ColumnClick );
      // 
      // m_PopupMenu
      // 
      this.m_PopupMenu.Items.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.m_CMS_View,
            this.m_CMS_ShowErrorText,
            toolStripSeparator1,
            this.m_CMS_KeepValues,
            this.m_CMS_Clear} );
      this.m_PopupMenu.Name = "m_PopupMenu";
      this.m_PopupMenu.Size = new System.Drawing.Size( 164, 98 );
      // 
      // m_CMS_View
      // 
      this.m_CMS_View.Name = "m_CMS_View";
      this.m_CMS_View.Size = new System.Drawing.Size( 163, 22 );
      this.m_CMS_View.Text = "&View...";
      this.m_CMS_View.Visible = false;
      this.m_CMS_View.Click += new System.EventHandler( this.m_CMS_View_Click );
      // 
      // m_CMS_ShowErrorText
      // 
      this.m_CMS_ShowErrorText.CheckOnClick = true;
      this.m_CMS_ShowErrorText.Name = "m_CMS_ShowErrorText";
      this.m_CMS_ShowErrorText.Size = new System.Drawing.Size( 163, 22 );
      this.m_CMS_ShowErrorText.Text = "&Show Error Text";
      // 
      // m_CMS_KeepValues
      // 
      this.m_CMS_KeepValues.CheckOnClick = true;
      this.m_CMS_KeepValues.Name = "m_CMS_KeepValues";
      this.m_CMS_KeepValues.Size = new System.Drawing.Size( 163, 22 );
      this.m_CMS_KeepValues.Text = "&Keep Old Values";
      // 
      // m_CMS_Clear
      // 
      this.m_CMS_Clear.Name = "m_CMS_Clear";
      this.m_CMS_Clear.Size = new System.Drawing.Size( 163, 22 );
      this.m_CMS_Clear.Text = "&Clear";
      this.m_CMS_Clear.Click += new System.EventHandler( this.m_CMS_Clear_Click );
      // 
      // UpdatesViewCtrl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add( this.m_ItemListLV );
      this.Name = "UpdatesViewCtrl";
      this.Size = new System.Drawing.Size( 432, 272 );
      this.m_PopupMenu.ResumeLayout( false );
      this.ResumeLayout( false );

    }

    #endregion

    private System.Windows.Forms.ListView m_ItemListLV;
    private System.Windows.Forms.ContextMenuStrip m_PopupMenu;
    private System.Windows.Forms.ToolStripMenuItem m_CMS_Clear;
    private System.Windows.Forms.ToolStripMenuItem m_CMS_KeepValues;
    private System.Windows.Forms.ToolStripMenuItem m_CMS_ShowErrorText;
    private System.Windows.Forms.ToolStripMenuItem m_CMS_View;
    private CAS.Lib.ControlLibrary.ImageListLibrary m_ImageListLibrary;
  }
}
