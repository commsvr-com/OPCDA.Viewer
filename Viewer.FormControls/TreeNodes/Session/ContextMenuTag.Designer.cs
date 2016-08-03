using System.Windows.Forms;
namespace CAS.Lib.OPCClientControlsLib
{
  partial class ContextMenuTag
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
      System.Windows.Forms.ToolStripMenuItem m_TSMI_Edit;
      System.Windows.Forms.ToolStripMenuItem m_TSMI_Dlete;
      System.Windows.Forms.ToolStripSeparator m_TSMI_Separator;
      this.m_ContextMenu = new System.Windows.Forms.ContextMenuStrip( this.components );
      this.m_TSMI_Active = new System.Windows.Forms.ToolStripMenuItem();
      m_TSMI_Edit = new System.Windows.Forms.ToolStripMenuItem();
      m_TSMI_Dlete = new System.Windows.Forms.ToolStripMenuItem();
      m_TSMI_Separator = new System.Windows.Forms.ToolStripSeparator();
      this.m_ContextMenu.SuspendLayout();
      this.SuspendLayout();
      // 
      // m_TSMI_Edit
      // 
      m_TSMI_Edit.Name = "m_TSMI_Edit";
      m_TSMI_Edit.Size = new System.Drawing.Size( 152, 22 );
      m_TSMI_Edit.Text = "&Edit...";
      m_TSMI_Edit.ToolTipText = "Edit items in the specified subscription.";
      m_TSMI_Edit.Click += new System.EventHandler( this.TSMI_ItemEdit_Click );
      // 
      // m_TSMI_Dlete
      // 
      m_TSMI_Dlete.Image = global::CAS.Lib.OPCClientControlsLib.ImagesResources.delete;
      m_TSMI_Dlete.Name = "m_TSMI_Dlete";
      m_TSMI_Dlete.Size = new System.Drawing.Size( 152, 22 );
      m_TSMI_Dlete.Text = "&Delete";
      m_TSMI_Dlete.ToolTipText = "Remove an item in the specified subscription.";
      m_TSMI_Dlete.Click += new System.EventHandler( this.TSMI_ItemDelete_Click );
      // 
      // m_TSMI_Separator
      // 
      m_TSMI_Separator.Name = "m_TSMI_Separator";
      m_TSMI_Separator.Size = new System.Drawing.Size( 149, 6 );
      // 
      // m_ContextMenu
      // 
      this.m_ContextMenu.Items.AddRange( new System.Windows.Forms.ToolStripItem[] {
            m_TSMI_Edit,
            m_TSMI_Dlete,
            m_TSMI_Separator,
            this.m_TSMI_Active} );
      this.m_ContextMenu.Name = "m_Item_PopupMenu";
      this.m_ContextMenu.Size = new System.Drawing.Size( 153, 98 );
      this.m_ContextMenu.Opening += new System.ComponentModel.CancelEventHandler( this.m_Item_PopupMenu_Opening );
      // 
      // m_TSMI_Active
      // 
      this.m_TSMI_Active.CheckOnClick = true;
      this.m_TSMI_Active.Name = "m_TSMI_Active";
      this.m_TSMI_Active.Size = new System.Drawing.Size( 152, 22 );
      this.m_TSMI_Active.Text = "&Active";
      this.m_TSMI_Active.ToolTipText = "Toggle the active state of the selected item.";
      this.m_TSMI_Active.Click += new System.EventHandler( this.TSMI_ItemActive_Click );
      // 
      // ItemContextMenu
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Name = "ItemContextMenu";
      this.m_ContextMenu.ResumeLayout( false );
      this.ResumeLayout( false );

    }
    #endregion
    private ContextMenuStrip m_ContextMenu;
    private ToolStripMenuItem m_TSMI_Active;
  }
}
