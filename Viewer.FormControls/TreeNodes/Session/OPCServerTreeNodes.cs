//<summary>
//  Title   : OPC Server TreeNodes
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
using CAS.DataPorter.Configurator;
using CAS.Lib.ControlLibrary;
using CAS.Lib.OPCClient.Da;
using OpcDa = Opc.Da;

namespace CAS.Lib.OPCClientControlsLib.TreeNodes.Session
{
  /// <summary>
  /// TreeNode representing an OPC server
  /// </summary>
  public class OPCSessionServer: SessionTreeNode<Server, OPCEnvironment>, IOptions
  {
    #region private
    private ContextMenuServer m_Menu;
    private Opc.ConnectData m_ConnectData = null;
    private OpcDa.ResultFilter m_Filter = global::Opc.Da.ResultFilter.Minimal;
    private string m_Locale = null;
    private string[] m_SupportedLocales = null;
    private Opc.Specification m_Spcification;
    private enum state { connected, disconnectd, failed };
    private state State
    {
      set
      {
        RaiseSelectServer( Tag );
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
          case state.failed:
            this.ImageIndex = this.SelectedImageIndex = (int)ImageListLibrary.Icons.IMAGE_OPC_SERVER_FAIL;
            this.ToolTipText = Properties.Resources.OPCServerTreeNodesToolTipFailed + LastEception.Message;
            break;
        }
      }
    }
    protected override void AssignImageIndex() { }
    private OpcDa::ServerStatus m_Status { get; set; }
    /// <summary>
    /// Called when the server sends a shutdown event.
    /// </summary>
    private void server_ServerShutdown( string reason )
    {
      Disconnect();
      MessageBox.Show( reason, "Server Shutdown",  MessageBoxButtons.OK, MessageBoxIcon.Information  );
    }
    private void ReportException( Exception ex )
    {
      this.LastEception = ex;
      MessageBox.Show( ex.Message );
      State = state.failed;
    }
    private static void RaiseSelectServer( Server server )
    {
      EventHandler<GenericEventArgs<Server>> handler = SelectServer;
      if ( handler == null )
        return;
      handler( server, new GenericEventArgs<Server>( server ) );
    }
    #region IDisposable
    protected override void Dispose( bool disposing )
    {
      System.Diagnostics.Debug.Assert( disposing );
      base.Dispose( disposing );
      if ( Tag.IsConnected )
        Tag.Disconnect();
      Tag.Dispose();
    }
    #endregion
    #endregion
    #region constructors
    /// <summary>
    /// Initializes a new instance of the <see cref="OPCServerTreeNodes"/> class with the specified label text.
    /// </summary>
    /// <param name="server">The server to add.</param>
    /// <param name="view">The <see cref="TreeView"/> to add new object..</param>
    internal OPCSessionServer( Server server, OPCEnvironment node )
      : base( server.Name, server, node )
    {
      m_Menu = new ContextMenuServer( this );
      m_Spcification = server.PreferedSpecyfication;
      LastEception = null;
      if ( server.IsConnected )
      {
        foreach ( Subscription sbscrptn in server.Subscriptions )
          new SubscriptionTreeNodeSession( sbscrptn.State, sbscrptn.Items, this );
        State = state.connected;
      }
      else
        State = state.disconnectd;
      Expand();
    }
    internal OPCSessionServer( OPCCliConfiguration.ServersRow server, OpcDa::BrowseFilters filters, OPCEnvironment node ) :
      base( server.Name, null, node )
    {
      LastEception = null;
      try
      {
        m_Menu = new ContextMenuServer( this );
        Opc.URL url = new Opc.URL( server.URL );
        if ( server.GetConnectDataRows().Length > 0 )
          m_ConnectData = server.GetConnectDataRows()[ 0 ].GetConnectData();
        m_Spcification = new Opc.Specification() { ID = server.PreferedSpecyficationID, Description = server.PreferedSpecyficationDsc };
        Tag = (Server)Factory.GetServerForURL( url, m_Spcification );
        server.GetOptions( this );
        foreach ( OPCCliConfiguration.SubscriptionsRow rw in server.GetSubscriptionsRows() )
          new SubscriptionTreeNodeSession( rw, this );
        State = state.disconnectd;
      }
      catch ( Exception ex ) { ReportException( ex ); }
    }
    #endregion
    #region public
    /// <summary>
    /// Occurs when a server node is selected.
    /// </summary>
    public static event EventHandler<GenericEventArgs<Server>> SelectServer;
    /// <summary>
    /// Makes selected the current node .
    /// </summary>
    public override void MakeSelected()
    {
      RaiseSelectServer( Tag );
      base.MakeSelected();
    }
    #endregion
    #region internal
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
        Application.UseWaitCursor = true;
        Tag.Connect( m_ConnectData );
        Tag.ServerShutdown += new Opc.ServerShutdownEventHandler( server_ServerShutdown );
        m_SupportedLocales = Tag.GetSupportedLocales();
        if ( !string.IsNullOrEmpty( m_Locale ) )
          Tag.SetLocale( m_Locale );
        Tag.SetResultFilters( (int)m_Filter );
        foreach ( SubscriptionTreeNodeSession node in Nodes )
          node.Subscribe();
        LastEception = null;
        State = state.connected;
        Application.UseWaitCursor = false;
      }
      catch ( Exception ex ) 
      {
        Application.UseWaitCursor = false;
        ReportException( ex ); 
      }
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
        foreach ( SubscriptionTreeNodeSession node in Nodes )
          node.Unsubscribe();
        Tag.ServerShutdown -= new Opc.ServerShutdownEventHandler( server_ServerShutdown );
        Tag.Disconnect();
      }
      catch ( Exception ex ) { ReportException( ex ); }
      finally
      {
        Server svr = Tag;
        Tag = (Server)svr.Clone();
        svr.Dispose();
        State = state.disconnectd;
      }
    }
    /// <summary>
    /// Prompts the user to create a new subscription.
    /// </summary>
    internal void CreateSubscription()
    {
      OpcDa.SubscriptionState subscription;
      SubscriptionTreeNodeSession node;
      using ( SubscriptionCreateDlg dial = new SubscriptionCreateDlg() )
      {
        dial.ShowDialog( Tag, DefaultBrowseFilters, m_SupportedLocales, this );
        if ( dial.DialogResult != DialogResult.OK )
          return;
        subscription = dial.State;
        if ( subscription == null )
          return;
        node = new SubscriptionTreeNodeSession( subscription, dial.GetItems, this );
        if ( !string.IsNullOrEmpty( dial.Locale ) )
          node.Locale = dial.Locale;
        node.Filter = dial.Filter;
      }
      if ( Tag.IsConnected )
      {
        node.Subscribe();
      }
    }
    /// <summary>
    /// Sets the enabled state of the server subscriptions.
    /// </summary>
    internal void SetEnabled()
    {
      foreach ( SubscriptionTreeNodeSession node in this.Nodes )
        node.RestoreEnabled();
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
    /// Edits the options.
    /// </summary>
    internal void EditOptions()
    {
      using ( var dial = new Common.OptionsEditDlg() )
        dial.ShowDialog( SuportedLocales, this );
    }
    /// <summary>
    /// Gets a value indicating whether this coupled server is connected.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if the server is connected; otherwise, <c>false</c>.
    /// </value>
    internal bool IsConnected { get { return Tag.IsConnected; } }
    /// <summary>
    /// Gets my server.
    /// </summary>
    /// <value>My server.</value>
    internal Server MyServer { get { return Tag; } }
    /// <summary>
    /// Gets or sets the last eception thrown by the server.
    /// </summary>
    /// <value>The last eception.</value>
    internal Exception LastEception { get; private set; }
    #endregion
    #region IOptions Members
    /// <summary>
    /// Gets or sets the locale. The locale is used for any error
    /// messages or results returned to the client.
    /// </summary>
    /// <value>The locale.</value>
    public string Locale
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
    /// <summary>
    /// Gets or sets the filter <see cref="OpcDa.ResultFilter"/>. Filters are
    /// applied by the server before returning item results.
    /// </summary>
    /// <value>The filter.</value>
    public OpcDa.ResultFilter Filter
    {
      get
      {
        if ( Tag.IsConnected )
          return (OpcDa.ResultFilter)Tag.GetResultFilters();
        else
          return m_Filter;
      }
      set
      {
        m_Filter = value;
        if ( Tag.IsConnected )
          Tag.SetResultFilters( (int)value );
      }
    }
    #endregion
    #region ITreeNodeCommon
    /// <summary>
    /// Finds the server.
    /// </summary>
    /// <returns>The server at the top of this tree</returns>
    public override Server FindServer() { return Tag; }
    #endregion
    #region ISave
    /// <summary>
    /// Saves the current configuration in the <see cref="OPCCliConfiguration"/>.
    /// </summary>
    /// <param name="configuration">The current configuration.</param>
    /// <param name="parentKey">The parent key.</param>
    public override void Save( OPCCliConfiguration configuration, long parentKey )
    {
      long pk = configuration.Servers.Save( Tag, this.m_ConnectData, m_Locale, m_Filter );
      base.Save( configuration, pk );
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
      get { return m_Menu.Menu; }
    }
    #endregion
  }
}
