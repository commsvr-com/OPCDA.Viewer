//<summary>
//  Title   : TreeNode representing an OPC server in the browse tree
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

using System;
using System.Windows.Forms;
using CAS.Lib.ControlLibrary;
using CAS.Lib.OPC.AddressSpace;
using CAS.Lib.OPCClient.Da;
using OpcDa = Opc.Da;

namespace CAS.Lib.OPCClientControlsLib.TreeNodes.Browse
{
  /// <summary>
  /// TreeNode representing an OPC server in the browse tree
  /// </summary>
  internal class OPCBrowseServer: ConnectDataNode<Server, ComputerTreeNodes>
  {
    #region private
    //private OpcDa.ResultFilter m_Filter = global::Opc.Da.ResultFilter.Minimal;
    private string m_Locale = null;
    private string[] m_SupportedLocales = null;
    private enum state { connected, disconnectd, dictionary, failed };
    private state State
    {
      set
      {
        switch ( value )
        {
          case state.connected:
            this.ImageIndex = this.SelectedImageIndex = (int)ImageListLibrary.Icons.IMAGE_OPC_SERVER;
            this.ToolTipText = Properties.Resources.OPCServerTreeNodesToolTipConected;
            break;
          case state.disconnectd:
            this.ImageIndex = this.SelectedImageIndex = (int)ImageListLibrary.Icons.IMAGE_OPC_SERVER_SB;
            this.ToolTipText = Properties.Resources.OPCServerTreeNodesToolTipNotConnected;
            break;
          case state.dictionary:
            this.ImageIndex = this.SelectedImageIndex = (int)ImageListLibrary.Icons.IMAGE_DICTIONARY;
            this.ToolTipText = Properties.Resources.OPCServerTreeNodesToolTipDictionary;
            break;
          case state.failed:
            this.ImageIndex = this.SelectedImageIndex = (int)ImageListLibrary.Icons.IMAGE_OPC_SERVER_FAIL;
            this.ToolTipText = Properties.Resources.OPCServerTreeNodesToolTipFailed + CreatedEception.Message;
            break;
        }
      }
    }
    protected override void AssignImageIndex() { }
    /// <summary>
    /// Helper class to browse dictionary.
    /// </summary>
    private class mBrowseServer: BrowseServer
    {
      #region private
      private OPCBrowseServer mParent;
      /// <summary>
      /// Adds the browse element.
      /// </summary>
      /// <param name="element">The element.</param>
      protected override void AddBrowseElement( OpcDa.BrowseElement element )
      {
        new BrowseElementNode( element, mParent );
      }
      #endregion
      #region constructor
      /// <summary>
      /// Initializes a new instance of the <see cref="mBrowseServer"/> class.
      /// </summary>
      /// <param name="parent">The <see cref="OPCServerTreeNodes"/> parent.</param>
      /// <param name="itemID">The item ID.</param>
      /// <param name="filters">The filters.</param>
      internal mBrowseServer( OPCBrowseServer parent, OpcDa::BrowseFilters filters )
        : base( parent.Tag )
      {
        mParent = parent;
        Browse( null, filters );
      }
      #endregion
    }
    /// <summary>
    /// Helper class to browse dictionary
    /// </summary>
    private class mBrowseDictionary: BrowseDictionary
    {
      #region private
      private OPCBrowseServer mParent;
      /// <summary>
      /// Adds the browse element.
      /// </summary>
      /// <param name="element">The element.</param>
      protected override void AddBrowseElement( AddressSpaceDataBase.TagsTableRow element )
      {
        new BrowseElementNode( element, mParent );
      }
      #endregion
      #region constructor
      /// <summary>
      /// Initializes a new instance of the <see cref="mBrowseServer"/> class.
      /// </summary>
      /// <param name="parent">The <see cref="OPCServerTreeNodes"/> parent.</param>
      /// <param name="filters">The filters.</param>
      internal mBrowseDictionary( OPCBrowseServer parent, OpcDa::BrowseFilters filters )
        : base( (AddressSpaceDataBase)parent.m_ServerDictionaryDescription.Table.DataSet )
      {
        mParent = parent;
        Browse( null, filters );
      }
      #endregion
    }
    private AddressSpaceDataBase.ServersTableRow m_ServerDictionaryDescription = null;
    private OpcDa::ServerStatus m_Status { get; set; }
    protected override void Dispose( bool disposing )
    {
      System.Diagnostics.Debug.Assert( disposing );
      Disconnect();
      base.Dispose( disposing );
      if ( Tag.IsConnected )
        Tag.Disconnect();
      Tag.Dispose();
    }
    protected override void BranchBrowse()
    {
      if ( this.Tag.IsConnected )
      {
        m_Status = Tag.GetStatus();
        new mBrowseServer( this, this.DefaultBrowseFilters );
      }
      else if ( m_ServerDictionaryDescription != null )
      {
        m_Status = m_ServerDictionaryDescription.Status;
        new mBrowseDictionary( this, this.DefaultBrowseFilters );
      }
    }
    private void ReportException( Exception ex )
    {
      this.CreatedEception = ex;
      MessageBox.Show( ex.Message );
      State = state.failed;
    }
    #region Event handlers
    /// <summary>
    /// Called when the server sends a shutdown event.
    /// </summary>
    private void server_ServerShutdown( string reason )
    {
      if ( ServerShutdown != null )
        ServerShutdown( this, new ServerShutdownEventArgs( reason ) );
      this.Dispose();
      this.Remove();
    }
    #endregion
    #endregion
    #region constructors
    /// <summary>
    /// Initializes a new instance of the <see cref="OPCServerTreeNodes"/> class with the specified label text.
    /// </summary>
    /// <param name="server">The server to add.</param>
    /// <param name="filters">The filters.</param>
    /// <param name="view">The <see cref="OPCTreeView"/> to add new object..</param>
    internal OPCBrowseServer( Server server, OpcDa::BrowseFilters filters )
      : base( server.Name, server, filters, server.PreferedSpecyfication )
    {
      CreatedEception = null;
      State = Tag.IsConnected ? state.connected : state.disconnectd;
      if ( Tag.IsConnected )
      {
        this.Browse( true );
        this.Expand();
      }
    }
    internal OPCBrowseServer( Server server, ComputerTreeNodes computerNode )
      : base( server.Name, server, computerNode )
    {
      CreatedEception = null;
      State = Tag.IsConnected ? state.connected : state.disconnectd;
    }
    internal OPCBrowseServer( AddressSpaceDataBase.ServersTableRow server, OpcDa::BrowseFilters filters ) :
      base( server.URLString, null, filters, Opc.Specification.NONE )
    {
      CreatedEception = null;
      m_ServerDictionaryDescription = server;
      try
      {
        DefaultSpecification = server.Specification;
        Tag = (Server)Factory.GetServerForURL( server.URL, DefaultSpecification );
        m_SupportedLocales = server.Locales;
        State = state.dictionary;
        this.Browse( true );
        this.Expand();
      }
      catch ( Exception ex ) { ReportException( ex ); }
    }
    #endregion
    #region internal
    /// <summary>
    /// Gets or sets the eception throwh during server connectioning.
    /// </summary>
    /// <value>The created eception.</value>
    internal Exception CreatedEception { get; private set; }
    /// <summary>
    /// Occurs when server shutdown.
    /// </summary>
    internal event EventHandler<ServerShutdownEventArgs> ServerShutdown = null;
    /// <summary>
    /// Connects to the server and browses for top level nodes.
    /// </summary>
    /// <param name="addSubscriptions">if set to <c>true</c> add subscriptions.</param>
    internal void Connect()
    {
      // connect to server if not already connected.
      if ( Tag.IsConnected )
        return;
      try
      {
        Tag.Connect( ConnectDataObject );
        Tag.ServerShutdown += new Opc.ServerShutdownEventHandler( server_ServerShutdown );
        m_SupportedLocales = Tag.GetSupportedLocales();
        if ( !string.IsNullOrEmpty( m_Locale ) )
          Tag.SetLocale( m_Locale );
        Refresh();
        m_ServerDictionaryDescription = null;
        CreatedEception = null;
        State = state.connected;
      }
      catch ( Exception ex ) { ReportException( ex ); }
    }
    /// <summary>
    /// Disconnects from the server and clear all children.
    /// </summary>
    internal void Disconnect()
    {
      if ( !Tag.IsConnected )
        return;
      try
      {
        m_Locale = Tag.GetLocale();
        Tag.ServerShutdown -= new Opc.ServerShutdownEventHandler( server_ServerShutdown );
        Tag.Disconnect();
        State = state.disconnectd;
      }
      catch ( Exception ex ) { ReportException( ex ); }
    }
    /// <summary>
    /// Gets a value indicating whether browsing of the address space is allowed.
    /// </summary>
    /// <value><c>true</c> if [browse allowed]; otherwise, <c>false</c>.</value>
    internal bool BrowseAllowed
    {
      get
      {
        return Tag.IsConnected || m_ServerDictionaryDescription != null;
      }
    }
    /// <summary>
    /// Gets the suported by the server locales.
    /// </summary>
    /// <value>The suported locales.</value>
    internal string[] SuportedLocales
    {
      get
      {
        if ( Tag.IsConnected )
          try
          {
            m_SupportedLocales = Tag.GetSupportedLocales();
            return m_SupportedLocales;
          }
          catch ( Exception ex ) { ReportException( ex ); return null; }
        else
          return m_SupportedLocales;
      }
    }
    /// <summary>
    /// Gets my server.
    /// </summary>
    /// <value>My server.</value>
    internal Server MyServer { get { return Tag; } }

    /// <summary>
    /// Gets or sets the locale. The locale is used for any error
    /// messages or results returned to the client.
    /// </summary>
    /// <value>The locale.</value>
    internal string Locale
    {
      get
      {
        if ( Tag.IsConnected )
          try
          {
            return Tag.GetLocale();
          }
          catch ( Exception ex )
          {
            ReportException( ex );
            return null;
          }
        else
          return m_Locale;
      }
      set
      {
        m_Locale = value;
        if ( Tag.IsConnected )
          try { Tag.SetLocale( value ); }
          catch ( Exception ex ) { ReportException( ex ); }
      }
    }
    #endregion
    #region ITreeNodeInterface
    /// <summary>
    /// Gets the tree current context menu.
    /// </summary>
    /// <value>The menu <see cref="ContextMenuStrip"/>.</value>
    /// <remarks>Implements <see cref="ITreeNodeInterface"/></remarks>
    public override ContextMenuStrip Menu
    {
      get { throw new NotImplementedException(); }
    } 
    #endregion
    #region IBrowse
    /// <summary>
    /// Finds the server.
    /// </summary>
    /// <returns>The server at the top of this tree</returns>
    public override Server FindServer() { return Tag; }
    /// <summary>
    /// Gets the type of the node.
    /// </summary>
    /// <value>The type of the node.</value>
    public override NodeType GetNodeType { get { return NodeType.OPCServer; } }
    #endregion
    #region ISave
    /// <summary>
    /// Saves this instance and all children in the address space.
    /// </summary>
    /// <param name="addressSpace">The address space.</param>
    /// <param name="parentKey">The parent key.</param>
    /// <param name="root">if set to <c>true</c> it is root browe element.</param>
    public override void Save( AddressSpaceDataBase addressSpace, int parentKey, bool root )
    {
      if ( Tag.IsConnected )
      {
        try
        {
          m_ServerDictionaryDescription =
            addressSpace.ServersTable.AddRow( ConnectDataObject, Tag );
        }
        catch ( Exception ex ) { ReportException( ex ); }
      }
      else
        m_ServerDictionaryDescription =
              addressSpace.ServersTable.AddRow( ConnectDataObject, m_Status, Tag.PreferedSpecyfication, Tag.Url, SuportedLocales );
      base.Save( addressSpace, m_ServerDictionaryDescription.ID, root );
    }
    #endregion
  }
}
