//<summary>
//  Title   : A tree control use to navigate the address space of an OPC DA server.
//  System  : Microsoft Visual C# .NET 2008
//  $LastChangedDate$
//  $Rev$
//  $LastChangedBy$
//  $URL$
//  $Id$
//
//  Copyright (C)2008, CAS LODZ POLAND.
//  TEL: +48 (42) 686 25 47
//  mailto://techsupp@cas.eu
//  http://www.cas.eu
//</summary>
//============================================================================
// TITLE: BrowseTreeCtrl.cs
//
// CONTENTS:
// 
// A tree control use to navigate the address space of an OPC DA server.
//
// (c) Copyright 2002-2003 The OPC Foundation
// ALL RIGHTS RESERVED.
//
// DISCLAIMER:
//  This code is provided by the OPC Foundation solely to assist in 
//  understanding and use of the appropriate OPC Specification(s) and may be 
//  used as set forth in the License Grant section of the OPC Specification.
//  This code is provided as-is and without warranty or support of any sort
//  and is subject to the Warranty and Liability Disclaimers which appear
//  in the printed OPC Specification.
//
// MODIFICATION LOG:
//
// Date       By    Notes
// ---------- ---   -----
// 2002/11/16 RSA   First release.
// 2003/03/23 RSA   Add support for complex data type property viewing.
// 2003/06/11 RSA   Updated to support unified DA interface.

using System;
using System.Net;
using System.Windows.Forms;
using OpcDa = global::Opc.Da;

namespace CAS.Lib.OPCClientControlsLib
{
  using ControlLibrary;
  using OPC.AddressSpace;
  using OPCClient.Da;
  using TreeNodes.Browse;

  #region public delegates
  /// <summary>
  /// Use to receive notifications when a server node is 'picked'.
  /// </summary>
  public delegate void ServerPicked_EventHandler( Server server );
  /// <summary>
  /// Use to receive notifications when a item node is 'picked'.
  /// </summary>
  public delegate void ItemPicked_EventHandler( Opc.ItemIdentifier itemID );
  /// <summary>
  /// Use to receive notifications when a tree node is selected.
  /// </summary>
  public delegate void ElementSelected_EventHandler( OpcDa::BrowseElement element );
  #endregion
  /// <summary>
  /// A tree control use to navigate the address space of an OPC DA server.
  /// </summary>
  public class BrowseTreeCtrl: System.Windows.Forms.UserControl
  {
    #region private designers filds
    private System.Windows.Forms.ToolStripMenuItem m_TSM_ConnectMI;
    private System.Windows.Forms.ToolStripMenuItem m_TSM_DisconnectMI;
    private System.Windows.Forms.ToolStripMenuItem m_TSM_RefreshMI;
    private System.Windows.Forms.ToolStripMenuItem m_TSM_EditFiltersMI;
    private System.Windows.Forms.ToolStripMenuItem m_TSM_SetLoginMI;
    private System.Windows.Forms.ToolStripMenuItem m_TSM_PickMI;
    private System.Windows.Forms.ToolStripMenuItem m_TSM_PickChildrenMI;
    private System.Windows.Forms.ToolStripMenuItem m_TSM_ViewComplexTypeMI;
    private ContextMenuStrip m_PopupMenu;
    private ToolStripMenuItem m_TSM_RemoveFilters;
    private ToolStripMenuItem m_TSM_ResetLogin;
    private OPCTreeView m_BrowseTV;
    private System.ComponentModel.IContainer components;
    private bool m_SelectContextMenuIsEnabled = true;
    #endregion
    #region constructor
    public BrowseTreeCtrl()
    {
      // This call is required by the Windows.Forms Form Designer.
      InitializeComponent();
      //m_BrowseTV.ImageList = m_ImageListLibrary.ProjectImageList;
      Clear();
    }
    #endregion
    #region Component Designer generated code
    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
      System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
      System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
      this.m_PopupMenu = new System.Windows.Forms.ContextMenuStrip( this.components );
      this.m_TSM_PickMI = new System.Windows.Forms.ToolStripMenuItem();
      this.m_TSM_PickChildrenMI = new System.Windows.Forms.ToolStripMenuItem();
      this.m_TSM_EditFiltersMI = new System.Windows.Forms.ToolStripMenuItem();
      this.m_TSM_RemoveFilters = new System.Windows.Forms.ToolStripMenuItem();
      this.m_TSM_RefreshMI = new System.Windows.Forms.ToolStripMenuItem();
      this.m_TSM_SetLoginMI = new System.Windows.Forms.ToolStripMenuItem();
      this.m_TSM_ResetLogin = new System.Windows.Forms.ToolStripMenuItem();
      this.m_TSM_ConnectMI = new System.Windows.Forms.ToolStripMenuItem();
      this.m_TSM_DisconnectMI = new System.Windows.Forms.ToolStripMenuItem();
      this.m_TSM_ViewComplexTypeMI = new System.Windows.Forms.ToolStripMenuItem();
      this.m_BrowseTV = new CAS.Lib.ControlLibrary.OPCTreeView();
      toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
      toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
      toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
      this.m_PopupMenu.SuspendLayout();
      this.SuspendLayout();
      // 
      // toolStripSeparator1
      // 
      toolStripSeparator1.Name = "toolStripSeparator1";
      toolStripSeparator1.Size = new System.Drawing.Size( 187, 6 );
      // 
      // toolStripSeparator2
      // 
      toolStripSeparator2.Name = "toolStripSeparator2";
      toolStripSeparator2.Size = new System.Drawing.Size( 187, 6 );
      // 
      // toolStripSeparator3
      // 
      toolStripSeparator3.Name = "toolStripSeparator3";
      toolStripSeparator3.Size = new System.Drawing.Size( 187, 6 );
      toolStripSeparator3.Visible = false;
      // 
      // m_PopupMenu
      // 
      this.m_PopupMenu.Items.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.m_TSM_PickMI,
            this.m_TSM_PickChildrenMI,
            toolStripSeparator1,
            this.m_TSM_EditFiltersMI,
            this.m_TSM_RemoveFilters,
            this.m_TSM_RefreshMI,
            toolStripSeparator2,
            this.m_TSM_SetLoginMI,
            this.m_TSM_ResetLogin,
            this.m_TSM_ConnectMI,
            this.m_TSM_DisconnectMI,
            toolStripSeparator3,
            this.m_TSM_ViewComplexTypeMI} );
      this.m_PopupMenu.Name = "contextMenuStrip1";
      this.m_PopupMenu.Size = new System.Drawing.Size( 191, 242 );
      // 
      // m_TSM_PickMI
      // 
      this.m_TSM_PickMI.Name = "m_TSM_PickMI";
      this.m_TSM_PickMI.Size = new System.Drawing.Size( 190, 22 );
      this.m_TSM_PickMI.Text = "&Select";
      this.m_TSM_PickMI.ToolTipText = "Select item";
      this.m_TSM_PickMI.Click += new System.EventHandler( this.TSM_Pick_Click );
      // 
      // m_TSM_PickChildrenMI
      // 
      this.m_TSM_PickChildrenMI.Name = "m_TSM_PickChildrenMI";
      this.m_TSM_PickChildrenMI.Size = new System.Drawing.Size( 190, 22 );
      this.m_TSM_PickChildrenMI.Text = "Select Chil&dren";
      this.m_TSM_PickChildrenMI.ToolTipText = "Select all items ";
      this.m_TSM_PickChildrenMI.Click += new System.EventHandler( this.TSM_PickChildren_Click );
      // 
      // m_TSM_EditFiltersMI
      // 
      this.m_TSM_EditFiltersMI.Image = global::CAS.Lib.OPCClientControlsLib.ImagesResources.Filter;
      this.m_TSM_EditFiltersMI.Name = "m_TSM_EditFiltersMI";
      this.m_TSM_EditFiltersMI.Size = new System.Drawing.Size( 190, 22 );
      this.m_TSM_EditFiltersMI.Text = "Set &Filters...";
      this.m_TSM_EditFiltersMI.ToolTipText = "Set filters";
      this.m_TSM_EditFiltersMI.Click += new System.EventHandler( this.EditFiltersMI_Click );
      // 
      // m_TSM_RemoveFilters
      // 
      this.m_TSM_RemoveFilters.Image = global::CAS.Lib.OPCClientControlsLib.ImagesResources.filter_remove;
      this.m_TSM_RemoveFilters.Name = "m_TSM_RemoveFilters";
      this.m_TSM_RemoveFilters.Size = new System.Drawing.Size( 190, 22 );
      this.m_TSM_RemoveFilters.Text = "Remove Filters";
      this.m_TSM_RemoveFilters.ToolTipText = "Remove filters";
      this.m_TSM_RemoveFilters.Click += new System.EventHandler( this.TSM_RemoveFilters_Click );
      // 
      // m_TSM_RefreshMI
      // 
      this.m_TSM_RefreshMI.Image = global::CAS.Lib.OPCClientControlsLib.ImagesResources.reload_all_tabs;
      this.m_TSM_RefreshMI.Name = "m_TSM_RefreshMI";
      this.m_TSM_RefreshMI.Size = new System.Drawing.Size( 190, 22 );
      this.m_TSM_RefreshMI.Text = "&Refresh";
      this.m_TSM_RefreshMI.ToolTipText = "Refresh the selected branch ";
      this.m_TSM_RefreshMI.Click += new System.EventHandler( this.RefreshMI_Click );
      // 
      // m_TSM_SetLoginMI
      // 
      this.m_TSM_SetLoginMI.Image = global::CAS.Lib.OPCClientControlsLib.ImagesResources.SecurityLock;
      this.m_TSM_SetLoginMI.Name = "m_TSM_SetLoginMI";
      this.m_TSM_SetLoginMI.Size = new System.Drawing.Size( 190, 22 );
      this.m_TSM_SetLoginMI.Text = "Set &Login...";
      this.m_TSM_SetLoginMI.ToolTipText = "Set OPC security custom interface credentials ";
      this.m_TSM_SetLoginMI.Click += new System.EventHandler( this.TSM_SetLogin_Click );
      // 
      // m_TSM_ResetLogin
      // 
      this.m_TSM_ResetLogin.Image = global::CAS.Lib.OPCClientControlsLib.ImagesResources.SecurityUnlock;
      this.m_TSM_ResetLogin.Name = "m_TSM_ResetLogin";
      this.m_TSM_ResetLogin.Size = new System.Drawing.Size( 190, 22 );
      this.m_TSM_ResetLogin.Text = "Reset Login";
      this.m_TSM_ResetLogin.ToolTipText = "Remove default OPC security custom interface credentials";
      this.m_TSM_ResetLogin.Click += new System.EventHandler( this.TSM_ResetLogin_Click );
      // 
      // m_TSM_ConnectMI
      // 
      this.m_TSM_ConnectMI.Image = global::CAS.Lib.OPCClientControlsLib.ImagesResources.serwer_opc_start_48;
      this.m_TSM_ConnectMI.Name = "m_TSM_ConnectMI";
      this.m_TSM_ConnectMI.Size = new System.Drawing.Size( 190, 22 );
      this.m_TSM_ConnectMI.Text = "&Connect...";
      this.m_TSM_ConnectMI.ToolTipText = "Connect to Server";
      this.m_TSM_ConnectMI.Click += new System.EventHandler( this.ConnectMI_Click );
      // 
      // m_TSM_DisconnectMI
      // 
      this.m_TSM_DisconnectMI.Image = global::CAS.Lib.OPCClientControlsLib.ImagesResources.serwer_opc_stop_48;
      this.m_TSM_DisconnectMI.Name = "m_TSM_DisconnectMI";
      this.m_TSM_DisconnectMI.Size = new System.Drawing.Size( 190, 22 );
      this.m_TSM_DisconnectMI.Text = "&Disconnect";
      this.m_TSM_DisconnectMI.ToolTipText = "Disconnect from Server";
      this.m_TSM_DisconnectMI.Click += new System.EventHandler( this.DisconnectMI_Click );
      // 
      // m_TSM_ViewComplexTypeMI
      // 
      this.m_TSM_ViewComplexTypeMI.Name = "m_TSM_ViewComplexTypeMI";
      this.m_TSM_ViewComplexTypeMI.Size = new System.Drawing.Size( 190, 22 );
      this.m_TSM_ViewComplexTypeMI.Text = "&View Complex Type...";
      this.m_TSM_ViewComplexTypeMI.Visible = false;
      this.m_TSM_ViewComplexTypeMI.Click += new System.EventHandler( this.TSM_ViewComplexType_Click );
      // 
      // m_BrowseTV
      // 
      this.m_BrowseTV.ContextMenuStrip = this.m_PopupMenu;
      this.m_BrowseTV.Dock = System.Windows.Forms.DockStyle.Fill;
      this.m_BrowseTV.ImageIndex = 0;
      this.m_BrowseTV.Location = new System.Drawing.Point( 0, 0 );
      this.m_BrowseTV.Name = "m_BrowseTV";
      this.m_BrowseTV.SelectedImageIndex = 0;
      this.m_BrowseTV.ShowNodeToolTips = true;
      this.m_BrowseTV.Size = new System.Drawing.Size( 400, 400 );
      this.m_BrowseTV.TabIndex = 1;
      this.m_BrowseTV.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler( this.BrowseTV_BeforeExpand );
      this.m_BrowseTV.DoubleClick += new System.EventHandler( this.m_BrowseTV_DoubleClick );
      this.m_BrowseTV.AfterSelect += new System.Windows.Forms.TreeViewEventHandler( this.BrowseTV_AfterSelect );
      this.m_BrowseTV.MouseDown += new System.Windows.Forms.MouseEventHandler( this.BrowseTV_MouseDown );
      // 
      // BrowseTreeCtrl
      // 
      this.ContextMenuStrip = this.m_PopupMenu;
      this.Controls.Add( this.m_BrowseTV );
      this.Name = "BrowseTreeCtrl";
      this.Size = new System.Drawing.Size( 400, 400 );
      this.m_PopupMenu.ResumeLayout( false );
      this.ResumeLayout( false );

    }
    #endregion
    #region public methods
    /// <summary>
    /// The underlying tree view. 
    /// </summary>
    public TreeView View { get { return m_BrowseTV; } }
    /// <summary>
    /// The server associated with the currently selected node.
    /// </summary>
    public Server SelectedServer
    {
      get
      {
        if ( m_BrowseTV.SelectedNode == null )
          return null;
        Server server = ( (IBrowse)m_BrowseTV.SelectedNode ).FindServer();
        if ( server == null )
          return null;
        return server.Duplicate();
      }
    }
    /// <summary>
    /// Displays all servers that support the specified specification.
    /// </summary>
    /// <param name="discovery">The discovery.</param>
    /// <param name="specification">The specification.</param>
    /// <param name="filters">The filters.</param>
    /// <param name="SelectContextMenuIsEnabled">if set to <c>true</c> context menu: select is enabled.</param>
    public void ShowAllServers( Opc.IDiscovery discovery, Opc.Specification specification, OpcDa::BrowseFilters filters, bool SelectContextMenuIsEnabled )
    {
      if ( discovery == null )
        throw new ArgumentNullException( "Discovery cannot be null" );
      this.Cursor = Cursors.AppStarting;
      Clear();
      this.m_SelectContextMenuIsEnabled = SelectContextMenuIsEnabled;
      m_discovery = discovery;
      OpcDa::BrowseFilters m_filters = ( filters == null ) ? new OpcDa::BrowseFilters() : filters;
      //My computer
      ComputerTreeNodes m_localServers = new Computer( this, "localhost", m_filters, specification );
      m_BrowseTV.Nodes.Add( m_localServers );
      m_BrowseTV.SelectedNode = m_localServers;
      m_localServers.Browse( true );
      m_localServers.Expand();
      //Network
      NetworkTreeNode m_localNetwork = new Network( this, "Local Network", m_filters, specification );
      m_BrowseTV.Nodes.Add( m_localNetwork );
      m_BrowseTV.SelectedNode = m_localNetwork;
      m_localNetwork.Browse( true );
      m_localNetwork.Expand();
      this.Cursor = Cursors.Default;
    }
    /// <summary>
    /// Connect and browses the address space for a single server. The server is disposed while disposing this control.
    /// </summary>
    /// <param name="server">The server to show.</param>
    /// <param name="filters">The filters to apply.</param>
    /// <param name="SelectContextMenuIsEnabled">if set to <c>true</c> context menu: select is enabled.</param>
    //TODO define filters while caling
    public void ShowSingleServer( Server server, OpcDa::BrowseFilters filters, bool SelectContextMenuIsEnabled )
    {
      this.Cursor = Cursors.WaitCursor;
      this.m_SelectContextMenuIsEnabled = SelectContextMenuIsEnabled;
      System.Diagnostics.Debug.Assert( !server.IsConnected );
      if ( ( server == null ) || ( server.IsConnected ) )
        throw new ArgumentNullException( "server" );
      if ( filters == null )
        filters = new OpcDa::BrowseFilters();
      Clear();
      var m_singleServer = new OPCBrowseServer( server, filters );
      m_BrowseTV.Nodes.Add( m_singleServer );
      m_BrowseTV.SelectedNode = m_singleServer;
      m_singleServer.Connect();
      this.Cursor = Cursors.Default;
    }
    /// <summary>
    /// Shows the single server.
    /// </summary>
    /// <param name="dictionary">The dictionary.</param>
    /// <param name="filters">The filters.</param>
    /// <param name="SelectContextMenuIsEnabled">if set to <c>true</c> context menu: select is enabled.</param>
    public void ShowSingleServer( AddressSpaceDataBase dictionary, OpcDa::BrowseFilters filters, bool SelectContextMenuIsEnabled )
    {
      if ( dictionary == null )
        throw new ArgumentNullException( "Dictionary cannot be null" );
      if ( filters == null )
        filters = new OpcDa::BrowseFilters();
      this.m_SelectContextMenuIsEnabled = SelectContextMenuIsEnabled;
      Clear();
      if ( dictionary.ServersTable.Count > 0 )
        m_BrowseTV.Nodes.Add( new OPCBrowseServer( dictionary.ServersTable[ 0 ], filters ) );
    }
    /// <summary>
    /// Removes all nodes and releases all resources.
    /// </summary>
    public void Clear()
    {
      // recursively searches the tree and free objects.
      foreach ( IBrowse child in m_BrowseTV.Nodes )
        child.Dispose();
      // clear the tree.
      m_BrowseTV.Nodes.Clear();
      // release the discovery server.
      if ( m_discovery != null )
        m_discovery.Dispose();
      m_discovery = null;
    }
    /// <summary>
    /// Exports the current address space to a dictionary.
    /// </summary>
    /// <param name="dictionary">The dictionary to be used as a repository for the address space.</param>
    internal void ExportDictionary( AddressSpaceDataBase dictionary )
    {
      Application.UseWaitCursor = true;
      Browse( false );
      dictionary.Clear();
      foreach ( ISave node in m_BrowseTV.Nodes )
        node.Save( dictionary );
      Application.UseWaitCursor = false;
    }
    internal void Browse( bool shallow )
    {
      Application.UseWaitCursor = true;
      foreach ( IBrowse node in m_BrowseTV.Nodes )
        node.Browse( shallow );
      Application.UseWaitCursor = false;
    }
    #endregion
    #region public events
    /// <summary>
    /// Use to receive notifications when a server node is 'picked'.
    /// </summary>
    public event ServerPicked_EventHandler ServerPicked;
    /// <summary>
    /// Use to receive notifications when a item node is 'picked'.
    /// </summary>
    public event ItemPicked_EventHandler ItemPicked;
    /// <summary>
    /// Use to receive notifications when an element is selected.
    /// </summary>
    public event ElementSelected_EventHandler ElementSelected;
    #endregion
    #region private
    #region classes
    private class Computer: ComputerTreeNodes
    {
      private BrowseTreeCtrl m_Parent;
      protected override Opc.IDiscovery DiscoveryObject
      {
        get { return m_Parent.m_discovery; }
      }
      /// <summary>
      /// Initializes a new instance of the <see cref="Computer"/> class.
      /// </summary>
      /// <param name="parent">The parent.</param>
      /// <param name="computerName">Name of the computer.</param>
      /// <param name="filters">The filters.</param>
      /// <param name="specification">The specification.</param>
      internal Computer
        ( BrowseTreeCtrl parent, string computerName, OpcDa::BrowseFilters filters, Opc.Specification specification )
        : base( computerName, filters, specification )
      {
        m_Parent = parent;
      }
      /// <summary>
      /// Gets the tree current context menu.
      /// </summary>
      /// <value>The menu <see cref="ContextMenuStrip"/>.</value>
      /// <remarks>Implements <see cref="ITreeNodeInterface"/></remarks>
      public override ContextMenuStrip Menu
      {
        get { throw new NotImplementedException(); }
      }
    }
    private class Network: NetworkTreeNode
    {
      private BrowseTreeCtrl m_Parent;
      protected override Opc.IDiscovery DiscoveryObject
      {
        get { return m_Parent.m_discovery; }
      }
      /// <summary>
      /// Initializes a new instance of the <see cref="Network"/> class.
      /// </summary>
      /// <param name="parent">The parent.</param>
      /// <param name="computerName">Name of the computer.</param>
      /// <param name="filters">The filters.</param>
      /// <param name="specification">The specification.</param>
      internal Network
        ( BrowseTreeCtrl parent, string computerName, OpcDa::BrowseFilters filters, Opc.Specification specification )
        : base( computerName, filters, specification )
      {
        m_Parent = parent;
      }
      /// <summary>
      /// Gets the tree current context menu.
      /// </summary>
      /// <value>The menu <see cref="ContextMenuStrip"/>.</value>
      /// <remarks>Implements <see cref="ITreeNodeInterface"/></remarks>
      public override ContextMenuStrip Menu
      {
        get { throw new NotImplementedException(); }
      }
    }
    #endregion
    #region fields
    /// <summary>
    /// The discovery service used to locate computers and servers.
    /// </summary>
    private Opc.IDiscovery m_discovery = null;
    #endregion
    #region methods
    /// <summary>
    /// Raise <see cref="ServerPicked"/> event.
    /// </summary>
    /// <param name="server">The picked server.</param>
    private void OnServerPick( Server server )
    {
      if ( ServerPicked == null )
        return;
      ServerPicked( server );
    }
    /// <summary>
    ///Raise <see cref="ItemPicked"/> event.
    /// </summary>
    /// <param name="itemID">The picked <see cref="ItemIdentifier"/> object.</param>
    private void OnItemPicked( Opc.ItemIdentifier itemID )
    {
      if ( ItemPicked == null )
        return;
      ItemPicked( itemID );
    }
    /// <summary>
    /// Raise a server or item event depending on the slected node.
    /// </summary>
    private void PickNode( IBrowse node )
    {
      switch ( node.GetNodeType )
      {
        case NodeType.OPCServer:
          OnServerPick( ( (OPCBrowseServer)node ).MyServer );
          break;
        case NodeType.Item:
          var benNode = node as BrowseElementNode;
          OnItemPicked( benNode.MyItemIdentifier );
          break;
        default:
          break;
      }
    }
    //TODO:uncomment and implement complex types.
    /// <summary>
    /// Displays a dialog with the complex type information.
    /// </summary>
    //private void ViewComplexType(  BrowseElementNode node )
    //{
    //  try
    //  {
    //    ComplexItem complexItem = ComplexTypeCache.GetComplexItem( node.Tag );
    //    if ( complexItem != null )
    //      new EditComplexValueDlg().ShowDialog( complexItem, null, true, true );
    //  }
    //  catch ( Exception e )
    //  {
    //    MessageBox.Show( e.Message );
    //  }
    //}
    #endregion
    #region event handlers
    #region TreeView handlers
    /// <summary>
    /// Called before a node is about to expand.
    /// </summary>
    private void BrowseTV_BeforeExpand( object sender, System.Windows.Forms.TreeViewCancelEventArgs e )
    {
      this.Cursor = Cursors.AppStarting;
      var node = e.Node as IBrowse;
      System.Diagnostics.Debug.Assert( node != null );
      node.Browse( true );
      Cursor = Cursors.Default;
    }
    /// <summary>
    /// Updates the state of context menus based on the current selection.
    /// </summary>
    private void BrowseTV_MouseDown( object sender, System.Windows.Forms.MouseEventArgs e )
    {
      // ignore left button actions.
      if ( e.Button != MouseButtons.Right )
        return;
      // selects the item that was right clicked on.
      var clickedNode = m_BrowseTV.GetNodeAt( e.X, e.Y ) as IBrowse;
      // no item clicked on - do nothing.
      if ( clickedNode == null )
        return;
      // force selection to clicked node.
      clickedNode.MakeSelected();
      // disable everything.
      foreach ( ToolStripItem mi in m_BrowseTV.ContextMenuStrip.Items )
        mi.Enabled = false;
      switch ( clickedNode.GetNodeType )
      {
        case NodeType.OPCServer:
          m_TSM_PickMI.Enabled = m_SelectContextMenuIsEnabled;
          m_TSM_ConnectMI.Enabled = !( (OPCBrowseServer)clickedNode ).MyServer.IsConnected;
          m_TSM_DisconnectMI.Enabled = ( (OPCBrowseServer)clickedNode ).MyServer.IsConnected;
          m_TSM_EditFiltersMI.Enabled = true;
          m_TSM_RemoveFilters.Enabled = true;
          m_TSM_RefreshMI.Enabled = ( (OPCBrowseServer)clickedNode ).BrowseAllowed;
          m_TSM_EditFiltersMI.Enabled = true;
          m_TSM_SetLoginMI.Enabled = true;
          m_TSM_ResetLogin.Enabled = ( (OPCBrowseServer)clickedNode ).ConnectionDataIsSet;
          break;
        case NodeType.Computer:
          m_TSM_RefreshMI.Enabled = true;
          m_TSM_SetLoginMI.Enabled = true;
          m_TSM_ResetLogin.Enabled = ( (ComputerTreeNodes)clickedNode ).ConnectionDataIsSet;
          break;
        case NodeType.Network:
          m_TSM_RefreshMI.Enabled = true;
          m_TSM_SetLoginMI.Enabled = true;
          m_TSM_ResetLogin.Enabled = ( (Network)clickedNode ).ConnectionDataIsSet;
          break;
        case NodeType.BrowseElement:
          m_TSM_PickChildrenMI.Enabled = m_SelectContextMenuIsEnabled;
          m_TSM_EditFiltersMI.Enabled = true;
          m_TSM_RemoveFilters.Enabled = true;
          m_TSM_RefreshMI.Enabled = true;
          break;
        case NodeType.Item:
          //TODO cleanup complex type editing.
          //if ( ComplexTypeCache.Server != null )
          //  m_TSM_ViewComplexTypeMI.Enabled = ( ComplexTypeCache.GetComplexItem( (BrowseElement)clickedNode.Tag ) != null );
          m_TSM_PickMI.Enabled = m_SelectContextMenuIsEnabled;
          //m_TSM_EditFiltersMI.Enabled = true;
          //m_TSM_RefreshMI.Enabled = true;
          break;
        default:
          break;
      }
    }
    /// <summary>
    /// Handles the DoubleClick event of the m_BrowseTV control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    private void m_BrowseTV_DoubleClick( object sender, EventArgs e )
    {
      var clickedNode = m_BrowseTV.SelectedNode as IBrowse;
      if ( clickedNode != null && clickedNode.GetNodeType == NodeType.Item )
        PickNode( clickedNode );
    }
    /// <summary>
    /// Called when a tree node is selected.
    /// </summary>
    private void BrowseTV_AfterSelect( object sender, System.Windows.Forms.TreeViewEventArgs e )
    {
      //OnElementSelect 
      if ( ElementSelected == null )
        return;
      BrowseElementNode node = m_BrowseTV.SelectedNode as BrowseElementNode;
      if ( node != null )
        ElementSelected( node.MyBrowseElement );
    }
    #endregion
    /// <summary>
    /// Feedback event hamdler: called when the browse filters have changed in an external dialog.
    /// </summary>
    /// <param name="filters">The new filters.</param>
    private void OnBrowseFiltersChanged( OpcDa::BrowseFilters filters )
    {
      //TODO: how to clear filters?
      IBrowse cn = (IBrowse)m_BrowseTV.SelectedNode;
      cn.DefaultBrowseFilters = filters;
    }
    #endregion
    #region Menu handlers
    /// <summary>
    /// Connects to the selected server.
    /// </summary>
    private void ConnectMI_Click( object sender, System.EventArgs e )
    {
      Cursor = Cursors.WaitCursor;
      var server = m_BrowseTV.SelectedNode as OPCBrowseServer;
      if ( server == null )
        return;
      server.Connect();
      Cursor = Cursors.Default;
    }
    /// <summary>
    /// Connects to the selected server.
    /// </summary>
    private void DisconnectMI_Click( object sender, System.EventArgs e )
    {
      var server = m_BrowseTV.SelectedNode as OPCBrowseServer;
      if ( server == null )
        return;
      server.Disconnect();
      server.Clear();
    }
    /// <summary>
    /// Displays the edit browse filters dialog.
    /// </summary>
    private void EditFiltersMI_Click( object sender, System.EventArgs e )
    {
      var sn = m_BrowseTV.SelectedNode as IBrowse;
      OpcDa::BrowseFilters cf = sn.DefaultBrowseFilters;
      using ( BrowseFiltersDlg cd = new BrowseFiltersDlg() )
      {
        cd.Show( Form.ActiveForm, cf, new BrowseFiltersChangedCallback( OnBrowseFiltersChanged ) );
        //TODO remove applay buton and event handler and assigne result after returning.
      }
    }
    /// <summary>
    /// Updates the contents of the current selection.
    /// </summary>
    private void RefreshMI_Click( object sender, System.EventArgs e )
    {
      var node = m_BrowseTV.SelectedNode as IBrowse;
      node.Refresh();
    }
    /// <summary>
    /// Prompts the user to set the network connectData for the node.
    /// </summary>
    private void TSM_SetLogin_Click( object sender, System.EventArgs e )
    {
      var node = m_BrowseTV.SelectedNode as IConnectDataNode;
      switch ( node.GetNodeType )
      {
        case NodeType.Computer:
        case NodeType.Network:
        case NodeType.OPCServer:
          Opc.ConnectData cd = node.ConnectDataObject == null ? new Opc.ConnectData( null ) : node.ConnectDataObject;
          using ( NetworkCredentialsDlg dial = new NetworkCredentialsDlg() )
          {
            NetworkCredential res = dial.ShowDialog( cd.Credentials );
            if ( dial.DialogResult == DialogResult.OK )
              node.ConnectDataObject = new Opc.ConnectData( res );
          }
          break;
        default:
          break;
      }
    }
    /// <summary>
    /// Sends a server or item selected event.
    /// </summary>
    private void TSM_Pick_Click( object sender, System.EventArgs e )
    {
      var node = m_BrowseTV.SelectedNode as IBrowse;
      if ( node != null )
        PickNode( node );
    }
    /// <summary>
    /// Sends a server or item selected event for all node children.
    /// </summary>
    private void TSM_PickChildren_Click( object sender, System.EventArgs e )
    {
      var node = m_BrowseTV.SelectedNode as IBrowse;
      if ( node == null )
        return;
      foreach ( IBrowse child in node.Nodes )
        PickNode( child );
    }
    /// <summary>
    /// Called to view complex type information for an item.
    /// </summary>
    private void TSM_ViewComplexType_Click( object sender, System.EventArgs e )
    {
      throw new NotImplementedException();
      // BrowseTreeNode node = m_BrowseTV.SelectedNode as  BrowseTreeNode;
      //if ( node == null || node.GetNOdeType !=  BrowseTreeNode.NodeType.Item )
      //  return;
      //ViewComplexType( ( BrowseElementNode)node );
    }
    /// <summary>
    /// Handles the Click event of the Remove Filters menu item.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    private void TSM_RemoveFilters_Click( object sender, EventArgs e )
    {
      var node = m_BrowseTV.SelectedNode as IBrowse;
      if ( node != null )
        node.DefaultBrowseFilters = null;
    }
    private void TSM_ResetLogin_Click( object sender, EventArgs e )
    {
      var node = m_BrowseTV.SelectedNode as IConnectDataNode;
      if ( node != null )
        node.ConnectDataObject = null;
    }
    #endregion
    #endregion
    #region IDisposable
    /// <summary> 
    /// Clean up any resources being used.
    /// </summary>
    protected override void Dispose( bool disposing )
    {
      if ( disposing )
      {
        // release all server objects.
        Clear();
        if ( components != null )
        {
          components.Dispose();
        }
      }
      base.Dispose( disposing );
    }
    #endregion

  }
}
