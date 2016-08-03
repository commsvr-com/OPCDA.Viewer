//<summary>
//  Title   : Session Tree Control
//  System  : Microsoft Visual C# .NET 2008
//  $LastChangedDate$
//  $Rev$
//  $LastChangedBy$
//  $URL$
//  $Id$
//
//  20080616 - mzbrzezny: m_ProcessingEnvironment.Clear() is called before clearing the subscription and items. (this is becuse operation should not use on remove item event)
//  2008 - mpostol: created
//
//  Copyright (C)2008, CAS LODZ POLAND.
//  TEL: +48 (42) 686 25 47
//  mailto://techsupp@cas.eu
//  http://www.cas.eu
//</summary>

using System;
using System.Windows.Forms;
using CAS.DataPorter.Configurator;
using CAS.DataPorter.Configurator.HMI;
using CAS.Lib.OPCClient.Da;
using CAS.Lib.OPCClientControlsLib.TreeNodes.Session;
using OpcDa = global::Opc.Da;

namespace CAS.Lib.OPCClientControlsLib
{
  /// <summary>
  /// Session Tree Control
  /// </summary>
  public class SessionTreeControl: SessionTreeControlBase
  {
    #region constructor
    /// <summary>
    /// Initializes a new instance of the <see cref="SessionTreeControl"/> class.
    /// </summary>
    public SessionTreeControl()
      : base()
    {
      InitializeComponent();
      m_ConfigurationManagement.ConfigurationChnged += new EventHandler<ConfigurationManagement.ConfigurationEventArg>( OnConfigurationChnged );
      m_ConfigurationManagement.ConfigurationSaving += new EventHandler<ConfigurationManagement.ConfigurationEventArg>( OnConfigurationSaving );
    }
    #endregion
    #region public
    /// <summary>
    /// Initializes the session.
    /// </summary>
    /// <param name="licenseOK">if set to <c>true</c> program is licensed.</param>
    public void InitializeSession()
    {
      m_OPCEnvironment = new OPCEnvironment();
      m_SubscriptionTreeView.Nodes.Add( m_OPCEnvironment );
      m_SubscriptionTreeView.SelectedNode = m_OPCEnvironment;
      m_OPCEnvironment.Expand();
      try
      {
        m_ProcessingEnvironment = new TransactionEnvironmentNode();
        m_SubscriptionTreeView.Nodes.Add( m_ProcessingEnvironment );
        m_SubscriptionTreeView.SelectedNode = m_ProcessingEnvironment;
        m_ProcessingEnvironment.Expand();
      }
      catch ( System.ComponentModel.LicenseException ) { }
    }
    public void Clear()
    {
      this.DisconnectAll(); //we have to disconnect all connected servers before clear
      if ( m_ProcessingEnvironment != null )
        m_ProcessingEnvironment.Clear();
      m_OPCEnvironment.Clear();
    }
    /// <summary>
    /// Saves the session.
    /// </summary>
    public void SaveSession() { m_ConfigurationManagement.Save( false ); }
    /// <summary>
    /// Opens the session.
    /// </summary>
    public void OpenSession() { m_ConfigurationManagement.Open(); }
    /// <summary>
    /// Opens the session.
    /// </summary>
    /// <param name="FileName">Name of the file to be opened.</param>
    public void OpenSession( string FileName ) { m_ConfigurationManagement.Open( FileName ); }
    /// <summary>
    /// Gets the configuration menu.
    /// </summary>
    /// <value>The configuration menu.</value>
    public ToolStripItem[] ConfigurationMenu { get { return m_ConfigurationManagement.Menu; } }
    public bool IsProcessingEnvironmentEnabled
    {
      get
      {
        return m_ProcessingEnvironment != null;
      }
    }
    /// <summary>
    /// Add server to the tree.
    /// </summary>
    /// <param name="server">The server.</param>
    /// <param name="filters">The filters <see cref="OpcDa::BrowseFilters"/>.</param>
    public void AddServer( Server server, OpcDa::BrowseFilters filters )
    {
      var node = new OPCSessionServer( server, m_OPCEnvironment );
      node.DefaultBrowseFilters = filters;
      m_OPCEnvironment.Expand();
    }
    /// <summary>
    /// Gets the selected server.
    /// </summary>
    /// <value>The selected server.</value>
    public Server SelectedServer { get { return m_SubscriptionTreeView.SelectedServer; } }
    /// <summary>
    /// Disconnect default server.
    /// </summary>
    public void DisconnectAll() { m_OPCEnvironment.DisconnectAll(); }
    /// <summary>
    /// Disconnects the selected node.
    /// </summary>
    public void Disconnect()
    {
      OPCSessionServer node = m_SubscriptionTreeView.SelectedNode as OPCSessionServer;
      if ( node == null || !node.IsConnected )
        return;
      node.Disconnect();
    }
    /// <summary>
    /// Connect to the selected server.
    /// </summary>
    public void Connect()
    {
      OPCSessionServer node = m_SubscriptionTreeView.SelectedNode as OPCSessionServer;
      if ( node == null || node.IsConnected )
        return;
      Cursor = Cursors.WaitCursor;
      node.Connect();
      node.SetEnabled();
      Cursor = Cursors.Default;
    }
    #endregion
    #region private
    private void OnConfigurationSaving( object sender, ConfigurationManagement.ConfigurationEventArg e )
    {
      m_OPCEnvironment.Save( e.Configuration );
      if ( m_ProcessingEnvironment != null )
        m_ProcessingEnvironment.Save( e.Configuration );
    }
    private void OnConfigurationChnged( object sender, ConfigurationManagement.ConfigurationEventArg e )
    {
      Clear();
      m_OPCEnvironment.CreateChildren( e.Configuration );
      m_OPCEnvironment.Expand();
      if ( m_ProcessingEnvironment != null )
      {
        m_ProcessingEnvironment.CreateChildren( e.Configuration );
        m_ProcessingEnvironment.Expand();
      }
    }
    private OPCEnvironment m_OPCEnvironment = null;
    private TransactionEnvironmentNode m_ProcessingEnvironment = null;
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      this.m_ConfigurationManagement = new CAS.DataPorter.Configurator.ConfigurationManagement( this.components );
      this.SuspendLayout();
      // 
      // SessionTreeControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
      this.Name = "SessionTreeControl";
      this.ResumeLayout( false );
    }
    private ConfigurationManagement m_ConfigurationManagement;
    private System.ComponentModel.IContainer components;
    #endregion
    #region IDisposable
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
    #endregion
  }
}
