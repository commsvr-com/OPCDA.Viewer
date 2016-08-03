namespace CAS.Lib.OPCClientControlsLib
{
  partial class ContextMenuSubscription
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
      System.Windows.Forms.ToolStripMenuItem m_TSMI_EditState;
      System.Windows.Forms.ToolStripMenuItem m_TSMI_AddItems;
      this.m_TSMI_Refresh = new System.Windows.Forms.ToolStripMenuItem();
      this.m_TSMI_Delete = new System.Windows.Forms.ToolStripMenuItem();
      this.m_EditItems = new System.Windows.Forms.ToolStripMenuItem();
      this.m_TSMI_Separator1 = new System.Windows.Forms.ToolStripSeparator();
      this.m_TSMI_Separator2 = new System.Windows.Forms.ToolStripSeparator();
      this.m_TSMI_Read = new System.Windows.Forms.ToolStripMenuItem();
      this.m_TSMI_Write = new System.Windows.Forms.ToolStripMenuItem();
      this.m_TSMI_Separator3 = new System.Windows.Forms.ToolStripSeparator();
      this.m_TSMI_AsyncRead = new System.Windows.Forms.ToolStripMenuItem();
      this.m_TSMI_AsyncWrite = new System.Windows.Forms.ToolStripMenuItem();
      this.m_ContextMenu = new System.Windows.Forms.ContextMenuStrip( this.components );
      this.m_TSMI_EditOptions = new System.Windows.Forms.ToolStripMenuItem();
      this.m_TSMI_Active = new System.Windows.Forms.ToolStripMenuItem();
      this.m_TSMI_Enabled = new System.Windows.Forms.ToolStripMenuItem();
      m_TSMI_EditState = new System.Windows.Forms.ToolStripMenuItem();
      m_TSMI_AddItems = new System.Windows.Forms.ToolStripMenuItem();
      this.m_ContextMenu.SuspendLayout();
      this.SuspendLayout();
      // 
      // m_TSMI_EditState
      // 
      m_TSMI_EditState.Name = "m_TSMI_EditState";
      m_TSMI_EditState.Size = new System.Drawing.Size( 155, 22 );
      m_TSMI_EditState.Text = "&Edit State...";
      m_TSMI_EditState.ToolTipText = "Edit the state of a subscription.";
      m_TSMI_EditState.Click += new System.EventHandler( this.TSMI_EditState_Click );
      // 
      // m_TSMI_AddItems
      // 
      m_TSMI_AddItems.Image = global::CAS.Lib.OPCClientControlsLib.ImagesResources.tag_element_48;
      m_TSMI_AddItems.Name = "m_TSMI_AddItems";
      m_TSMI_AddItems.Size = new System.Drawing.Size( 155, 22 );
      m_TSMI_AddItems.Text = "&Add Items...";
      m_TSMI_AddItems.ToolTipText = "Add items to a subscription.";
      m_TSMI_AddItems.Click += new System.EventHandler( this.TSMI_AddItems_Click );
      // 
      // m_TSMI_Refresh
      // 
      this.m_TSMI_Refresh.Image = global::CAS.Lib.OPCClientControlsLib.ImagesResources.reload_all_tabs;
      this.m_TSMI_Refresh.Name = "m_TSMI_Refresh";
      this.m_TSMI_Refresh.Size = new System.Drawing.Size( 155, 22 );
      this.m_TSMI_Refresh.Text = "Refre&sh";
      this.m_TSMI_Refresh.ToolTipText = "Refresh the items of a subscription.";
      this.m_TSMI_Refresh.Click += new System.EventHandler( this.TSMI_Refresh_Click );
      // 
      // m_TSMI_Delete
      // 
      this.m_TSMI_Delete.Image = global::CAS.Lib.OPCClientControlsLib.ImagesResources.delete;
      this.m_TSMI_Delete.Name = "m_TSMI_Delete";
      this.m_TSMI_Delete.Size = new System.Drawing.Size( 155, 22 );
      this.m_TSMI_Delete.Text = "&Delete";
      this.m_TSMI_Delete.ToolTipText = " Removes a subscription.";
      this.m_TSMI_Delete.Click += new System.EventHandler( this.TSMI_Delete_Click );
      // 
      // m_EditItems
      // 
      this.m_EditItems.Name = "m_EditItems";
      this.m_EditItems.Size = new System.Drawing.Size( 155, 22 );
      this.m_EditItems.Text = "E&dit Items...";
      this.m_EditItems.ToolTipText = "Edit items in a subscription.";
      this.m_EditItems.Click += new System.EventHandler( this.TSMI_EditItems_Click );
      // 
      // m_TSMI_Separator1
      // 
      this.m_TSMI_Separator1.Name = "m_TSMI_Separator1";
      this.m_TSMI_Separator1.Size = new System.Drawing.Size( 152, 6 );
      // 
      // m_TSMI_Separator2
      // 
      this.m_TSMI_Separator2.Name = "m_TSMI_Separator2";
      this.m_TSMI_Separator2.Size = new System.Drawing.Size( 152, 6 );
      // 
      // m_TSMI_Read
      // 
      this.m_TSMI_Read.Image = global::CAS.Lib.OPCClientControlsLib.ImagesResources.serwer_opc_read_48;
      this.m_TSMI_Read.Name = "m_TSMI_Read";
      this.m_TSMI_Read.Size = new System.Drawing.Size( 155, 22 );
      this.m_TSMI_Read.Text = "&Read...";
      this.m_TSMI_Read.ToolTipText = "Select a set of items and read them synchronously from the server.";
      this.m_TSMI_Read.Click += new System.EventHandler( this.TSMI_Read_Click );
      // 
      // m_TSMI_Write
      // 
      this.m_TSMI_Write.Image = global::CAS.Lib.OPCClientControlsLib.ImagesResources.serwer_opc_write_48;
      this.m_TSMI_Write.Name = "m_TSMI_Write";
      this.m_TSMI_Write.Size = new System.Drawing.Size( 155, 22 );
      this.m_TSMI_Write.Text = "&Write...";
      this.m_TSMI_Write.ToolTipText = "Select a set of items and write them synchronously from the server.";
      this.m_TSMI_Write.Click += new System.EventHandler( this.TSMI_Write_Click );
      // 
      // m_TSMI_Separator3
      // 
      this.m_TSMI_Separator3.Name = "m_TSMI_Separator3";
      this.m_TSMI_Separator3.Size = new System.Drawing.Size( 152, 6 );
      // 
      // m_TSMI_AsyncRead
      // 
      this.m_TSMI_AsyncRead.Image = global::CAS.Lib.OPCClientControlsLib.ImagesResources.serwer_opc_read_48;
      this.m_TSMI_AsyncRead.Name = "m_TSMI_AsyncRead";
      this.m_TSMI_AsyncRead.Size = new System.Drawing.Size( 155, 22 );
      this.m_TSMI_AsyncRead.Text = "Async Read...";
      this.m_TSMI_AsyncRead.ToolTipText = "Select a set of items and read them asynchronously from the server.";
      this.m_TSMI_AsyncRead.Click += new System.EventHandler( this.TSMI_AsyncRead_Click );
      // 
      // m_TSMI_AsyncWrite
      // 
      this.m_TSMI_AsyncWrite.Image = global::CAS.Lib.OPCClientControlsLib.ImagesResources.serwer_opc_write_48;
      this.m_TSMI_AsyncWrite.Name = "m_TSMI_AsyncWrite";
      this.m_TSMI_AsyncWrite.Size = new System.Drawing.Size( 155, 22 );
      this.m_TSMI_AsyncWrite.Text = "Async Write...";
      this.m_TSMI_AsyncWrite.ToolTipText = "Select a set of items and write them asynchronously from the server.";
      this.m_TSMI_AsyncWrite.Click += new System.EventHandler( this.TSMI_AsyncWrite_Click );
      // 
      // m_ContextMenu
      // 
      this.m_ContextMenu.Items.AddRange( new System.Windows.Forms.ToolStripItem[] {
            m_TSMI_EditState,
            this.m_TSMI_EditOptions,
            this.m_TSMI_Refresh,
            this.m_TSMI_Delete,
            m_TSMI_AddItems,
            this.m_EditItems,
            this.m_TSMI_Separator1,
            this.m_TSMI_Active,
            this.m_TSMI_Enabled,
            this.m_TSMI_Separator2,
            this.m_TSMI_Read,
            this.m_TSMI_Write,
            this.m_TSMI_Separator3,
            this.m_TSMI_AsyncRead,
            this.m_TSMI_AsyncWrite} );
      this.m_ContextMenu.Name = "m_Subscription_PopupMenu";
      this.m_ContextMenu.Size = new System.Drawing.Size( 156, 308 );
      this.m_ContextMenu.Opening += new System.ComponentModel.CancelEventHandler( this.m_ContextMenu_Opening );
      // 
      // m_TSMI_EditOptions
      // 
      this.m_TSMI_EditOptions.Name = "m_TSMI_EditOptions";
      this.m_TSMI_EditOptions.Size = new System.Drawing.Size( 155, 22 );
      this.m_TSMI_EditOptions.Text = "Edit &Options...";
      this.m_TSMI_EditOptions.ToolTipText = "Edit options of a subscription.";
      this.m_TSMI_EditOptions.Click += new System.EventHandler( this.TSMI_EditOptions_Click );
      // 
      // m_TSMI_Active
      // 
      this.m_TSMI_Active.CheckOnClick = true;
      this.m_TSMI_Active.Name = "m_TSMI_Active";
      this.m_TSMI_Active.Size = new System.Drawing.Size( 155, 22 );
      this.m_TSMI_Active.Text = "Acti&ve";
      this.m_TSMI_Active.ToolTipText = "Toggle the active state of a subscription.";
      this.m_TSMI_Active.Click += new System.EventHandler( this.TSMI_Active_Click );
      // 
      // m_TSMI_Enabled
      // 
      this.m_TSMI_Enabled.CheckOnClick = true;
      this.m_TSMI_Enabled.Name = "m_TSMI_Enabled";
      this.m_TSMI_Enabled.Size = new System.Drawing.Size( 155, 22 );
      this.m_TSMI_Enabled.Tag = "Toggle the enabled state of a subscription.";
      this.m_TSMI_Enabled.Text = "E&nabled";
      this.m_TSMI_Enabled.ToolTipText = "Toggle the enabled (controls the operation of OnDataChange) state of a subscripti" +
          "on. ";
      this.m_TSMI_Enabled.Click += new System.EventHandler( this.TSMI_Enabled_Click );
      // 
      // SubscriptionContextMenu
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Name = "SubscriptionContextMenu";
      this.m_ContextMenu.ResumeLayout( false );
      this.ResumeLayout( false );

    }

    #endregion
    private System.Windows.Forms.ContextMenuStrip m_ContextMenu;
    private System.Windows.Forms.ToolStripMenuItem m_TSMI_EditOptions;
    private System.Windows.Forms.ToolStripMenuItem m_TSMI_Active;
    private System.Windows.Forms.ToolStripMenuItem m_TSMI_Enabled;
    private System.Windows.Forms.ToolStripMenuItem m_TSMI_Refresh;
    private System.Windows.Forms.ToolStripMenuItem m_TSMI_Delete;
    private System.Windows.Forms.ToolStripMenuItem m_EditItems;
    private System.Windows.Forms.ToolStripSeparator m_TSMI_Separator1;
    private System.Windows.Forms.ToolStripSeparator m_TSMI_Separator2;
    private System.Windows.Forms.ToolStripMenuItem m_TSMI_Read;
    private System.Windows.Forms.ToolStripMenuItem m_TSMI_Write;
    private System.Windows.Forms.ToolStripSeparator m_TSMI_Separator3;
    private System.Windows.Forms.ToolStripMenuItem m_TSMI_AsyncRead;
    private System.Windows.Forms.ToolStripMenuItem m_TSMI_AsyncWrite;
  }
}
