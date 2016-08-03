using System.Windows.Forms;
namespace CAS.Lib.OPCClientControlsLib
{
  partial class ContextMenuServer
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
      System.Windows.Forms.ToolStripSeparator m_TSMI_Separator1;
      System.Windows.Forms.ToolStripSeparator m_TSMI_Separator2;
      System.Windows.Forms.ToolStripSeparator m_TSMI_Separator3;
      System.Windows.Forms.ToolStripMenuItem m_TSMI_Read;
      System.Windows.Forms.ToolStripMenuItem m_TSMI_Write;
      this.m_ContextMenu = new System.Windows.Forms.ContextMenuStrip( this.components );
      this.m_TSMI_Connect = new System.Windows.Forms.ToolStripMenuItem();
      this.m_TSMI_ViewStatus = new System.Windows.Forms.ToolStripMenuItem();
      this.m_TSMI_EditOptions = new System.Windows.Forms.ToolStripMenuItem();
      this.m_TSMI_Disconnect = new System.Windows.Forms.ToolStripMenuItem();
      this.m_TSM_Delete = new System.Windows.Forms.ToolStripMenuItem();
      this.m_TSMI_BrowseItems = new System.Windows.Forms.ToolStripMenuItem();
      this.m_TSMI_CreateSubscription = new System.Windows.Forms.ToolStripMenuItem();
      this.m_TSMI_CS_BrowseServer = new System.Windows.Forms.ToolStripMenuItem();
      this.m_TSMI_CS_BrowseDictionary = new System.Windows.Forms.ToolStripMenuItem();
      m_TSMI_Separator1 = new System.Windows.Forms.ToolStripSeparator();
      m_TSMI_Separator2 = new System.Windows.Forms.ToolStripSeparator();
      m_TSMI_Separator3 = new System.Windows.Forms.ToolStripSeparator();
      m_TSMI_Read = new System.Windows.Forms.ToolStripMenuItem();
      m_TSMI_Write = new System.Windows.Forms.ToolStripMenuItem();
      this.m_ContextMenu.SuspendLayout();
      // 
      // m_TSMI_Separator1
      // 
      m_TSMI_Separator1.Name = "m_TSMI_Separator1";
      m_TSMI_Separator1.Size = new System.Drawing.Size( 188, 6 );
      // 
      // m_TSMI_Separator2
      // 
      m_TSMI_Separator2.Name = "m_TSMI_Separator2";
      m_TSMI_Separator2.Size = new System.Drawing.Size( 188, 6 );
      // 
      // m_TSMI_Separator3
      // 
      m_TSMI_Separator3.Name = "m_TSMI_Separator3";
      m_TSMI_Separator3.Size = new System.Drawing.Size( 188, 6 );
      // 
      // m_TSMI_Read
      // 
      m_TSMI_Read.Image = global::CAS.Lib.OPCClientControlsLib.ImagesResources.serwer_opc_read_48;
      m_TSMI_Read.Name = "m_TSMI_Read";
      m_TSMI_Read.Size = new System.Drawing.Size( 191, 22 );
      m_TSMI_Read.Text = "&Read...";
      m_TSMI_Read.ToolTipText = "Reads a set of items for the server.";
      m_TSMI_Read.Click += new System.EventHandler( this.TSMI_Read_Click );
      // 
      // m_TSMI_Write
      // 
      m_TSMI_Write.Image = global::CAS.Lib.OPCClientControlsLib.ImagesResources.serwer_opc_write_48;
      m_TSMI_Write.Name = "m_TSMI_Write";
      m_TSMI_Write.Size = new System.Drawing.Size( 191, 22 );
      m_TSMI_Write.Text = "&Write...";
      m_TSMI_Write.ToolTipText = "Writes a set of items to the server.";
      m_TSMI_Write.Click += new System.EventHandler( this.TSMI_Write_Click );
      // 
      // m_ContextMenu
      // 
      this.m_ContextMenu.Items.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.m_TSMI_Connect,
            this.m_TSMI_ViewStatus,
            this.m_TSMI_EditOptions,
            this.m_TSMI_Disconnect,
            m_TSMI_Separator1,
            this.m_TSM_Delete,
            m_TSMI_Separator2,
            this.m_TSMI_BrowseItems,
            this.m_TSMI_CreateSubscription,
            m_TSMI_Separator3,
            m_TSMI_Read,
            m_TSMI_Write} );
      this.m_ContextMenu.Name = "m_Server_PopupMenu";
      this.m_ContextMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
      this.m_ContextMenu.Size = new System.Drawing.Size( 192, 220 );
      this.m_ContextMenu.Opening += new System.ComponentModel.CancelEventHandler( this.m_ContextMenu_Opening );
      // 
      // m_TSMI_Connect
      // 
      this.m_TSMI_Connect.Image = global::CAS.Lib.OPCClientControlsLib.ImagesResources.serwer_opc_connect_48;
      this.m_TSMI_Connect.Name = "m_TSMI_Connect";
      this.m_TSMI_Connect.Size = new System.Drawing.Size( 191, 22 );
      this.m_TSMI_Connect.Text = "Connect";
      this.m_TSMI_Connect.ToolTipText = "Connects to Server";
      this.m_TSMI_Connect.Click += new System.EventHandler( this.TSMI_Connect_Click );
      // 
      // m_TSMI_ViewStatus
      // 
      this.m_TSMI_ViewStatus.Image = global::CAS.Lib.OPCClientControlsLib.ImagesResources.serwer_opc_info_48;
      this.m_TSMI_ViewStatus.Name = "m_TSMI_ViewStatus";
      this.m_TSMI_ViewStatus.Size = new System.Drawing.Size( 191, 22 );
      this.m_TSMI_ViewStatus.Text = "&View Status";
      this.m_TSMI_ViewStatus.ToolTipText = "Displays the server status in a modal dialog.";
      this.m_TSMI_ViewStatus.Click += new System.EventHandler( this.TSMI_ViewStatus_Click );
      // 
      // m_TSMI_EditOptions
      // 
      this.m_TSMI_EditOptions.Name = "m_TSMI_EditOptions";
      this.m_TSMI_EditOptions.Size = new System.Drawing.Size( 191, 22 );
      this.m_TSMI_EditOptions.Text = "Edit &Options...";
      this.m_TSMI_EditOptions.ToolTipText = "Allows to edit the default options for the server.";
      this.m_TSMI_EditOptions.Click += new System.EventHandler( this.TSMI_EditOptions_Click );
      // 
      // m_TSMI_Disconnect
      // 
      this.m_TSMI_Disconnect.Image = global::CAS.Lib.OPCClientControlsLib.ImagesResources.serwer_opc_disconnect_48;
      this.m_TSMI_Disconnect.Name = "m_TSMI_Disconnect";
      this.m_TSMI_Disconnect.Size = new System.Drawing.Size( 191, 22 );
      this.m_TSMI_Disconnect.Text = "&Disconnect";
      this.m_TSMI_Disconnect.ToolTipText = "Disconnects the server";
      this.m_TSMI_Disconnect.Click += new System.EventHandler( this.TSMI_Disconnect_Click );
      // 
      // m_TSM_Delete
      // 
      this.m_TSM_Delete.Image = global::CAS.Lib.OPCClientControlsLib.ImagesResources.delete;
      this.m_TSM_Delete.Name = "m_TSM_Delete";
      this.m_TSM_Delete.Size = new System.Drawing.Size( 191, 22 );
      this.m_TSM_Delete.Text = "Delete";
      this.m_TSM_Delete.ToolTipText = "Disconnect from and delete the selected Server";
      this.m_TSM_Delete.Click += new System.EventHandler( this.TSMI_Delete_Click );
      // 
      // m_TSMI_BrowseItems
      // 
      this.m_TSMI_BrowseItems.Image = global::CAS.Lib.OPCClientControlsLib.ImagesResources.search;
      this.m_TSMI_BrowseItems.Name = "m_TSMI_BrowseItems";
      this.m_TSMI_BrowseItems.Size = new System.Drawing.Size( 191, 22 );
      this.m_TSMI_BrowseItems.Text = "&Browse Items...";
      this.m_TSMI_BrowseItems.ToolTipText = "Displays the address space of the server in a modal dialog.";
      this.m_TSMI_BrowseItems.Click += new System.EventHandler( this.TSMI_BrowseItems_Click );
      // 
      // m_TSMI_CreateSubscription
      // 
      this.m_TSMI_CreateSubscription.DropDownItems.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.m_TSMI_CS_BrowseServer,
            this.m_TSMI_CS_BrowseDictionary} );
      this.m_TSMI_CreateSubscription.Image = global::CAS.Lib.OPCClientControlsLib.ImagesResources.blok_danych_48;
      this.m_TSMI_CreateSubscription.Name = "m_TSMI_CreateSubscription";
      this.m_TSMI_CreateSubscription.Size = new System.Drawing.Size( 191, 22 );
      this.m_TSMI_CreateSubscription.Text = "&Create Subscription...";
      this.m_TSMI_CreateSubscription.ToolTipText = "Creates a new subscription and adds it to the tree.";
      // 
      // m_TSMI_CS_BrowseServer
      // 
      this.m_TSMI_CS_BrowseServer.Image = global::CAS.Lib.OPCClientControlsLib.ImagesResources.serwer_opc_48;
      this.m_TSMI_CS_BrowseServer.Name = "m_TSMI_CS_BrowseServer";
      this.m_TSMI_CS_BrowseServer.Size = new System.Drawing.Size( 182, 22 );
      this.m_TSMI_CS_BrowseServer.Text = "Browse server...";
      this.m_TSMI_CS_BrowseServer.ToolTipText = "Create a new subscription and add it to the tree. Browse address space of the sel" +
          "ected server.";
      this.m_TSMI_CS_BrowseServer.Click += new System.EventHandler( this.TSMI_CreateSubscription_Click );
      // 
      // m_TSMI_CS_BrowseDictionary
      // 
      this.m_TSMI_CS_BrowseDictionary.Image = global::CAS.Lib.OPCClientControlsLib.ImagesResources.dictionary;
      this.m_TSMI_CS_BrowseDictionary.Name = "m_TSMI_CS_BrowseDictionary";
      this.m_TSMI_CS_BrowseDictionary.Size = new System.Drawing.Size( 182, 22 );
      this.m_TSMI_CS_BrowseDictionary.Text = "Browse dictionary...";
      this.m_TSMI_CS_BrowseDictionary.ToolTipText = "Create a new subscription and add it to the tree. Browse address space from a sel" +
          "ected dictionary XML file.";
      this.m_TSMI_CS_BrowseDictionary.Click += new System.EventHandler( this.TSMI_CreateSubscription_Click );
      this.m_ContextMenu.ResumeLayout( false );

    }
    #endregion
    private ContextMenuStrip m_ContextMenu;
    private ToolStripMenuItem m_TSMI_Connect;
    private ToolStripMenuItem m_TSMI_ViewStatus;
    private ToolStripMenuItem m_TSMI_EditOptions;
    private ToolStripMenuItem m_TSMI_Disconnect;
    private ToolStripMenuItem m_TSM_Delete;
    private ToolStripMenuItem m_TSMI_CreateSubscription;
    private ToolStripMenuItem m_TSMI_BrowseItems;
    private ToolStripMenuItem m_TSMI_CS_BrowseServer;
    private ToolStripMenuItem m_TSMI_CS_BrowseDictionary;
  }
}
