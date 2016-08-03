//<summary>
//  Title   : Server context menu component
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
using System.ComponentModel;
using System.Windows.Forms;
using CAS.Lib.OPCClient.Da;
using CAS.Lib.OPCClientControlsLib.TreeNodes.Session;

namespace CAS.Lib.OPCClientControlsLib
{
  /// <summary>
  /// Server context menu component
  /// </summary>
  internal partial class ContextMenuServer: Component
  {
    #region constructors
    /// <summary>
    /// Initializes a new instance of the <see cref="ContextMenuServer"/> class.
    /// </summary>
    public ContextMenuServer()
    {
      InitializeComponent();
    }
    /// <summary>
    /// Initializes a new instance of the <see cref="ContextMenuServer"/> class.
    /// </summary>
    /// <param name="container">The container.</param>
    public ContextMenuServer( IContainer container )
    {
      container.Add( this );
      InitializeComponent();
    }
    /// <summary>
    /// Initializes a new instance of the <see cref="ContextMenuServer"/> class.
    /// </summary>
    /// <param name="node">The node.</param>
    internal ContextMenuServer( OPCSessionServer node )
      : this()
    {
      m_Node = node;
    }
    #endregion
    #region public
    internal ContextMenuStrip Menu { get { return m_ContextMenu; } }
    #endregion
    #region private
    private OPCSessionServer m_Node;
    #region TSMI event handlers
    /// <summary>
    /// Handles the Click event of the TSMI_Server_Connect control.
    /// Connects to the Server.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    private void TSMI_Connect_Click( object sender, EventArgs e )
    {
      m_Node.Connect();
    }
    /// <summary>
    /// Displays the server status in a modal dialog.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    private void TSMI_ViewStatus_Click( object sender, EventArgs e )
    {
      if ( !m_Node.IsConnected )
        return;
      using ( ServerStatusDlg dial = new ServerStatusDlg() ) { dial.ShowDialog( m_Node.MyServer ); }
    }
    /// <summary>
    /// Edit the default options for the server.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    private void TSMI_EditOptions_Click( object sender, EventArgs e )
    {
      m_Node.EditOptions();
    }
    /// <summary>
    /// Disconnects and removes a server from the tree.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    private void TSMI_Disconnect_Click( object sender, EventArgs e )
    {
      m_Node.Disconnect();
    }
    /// <summary>
    /// Handles the Click event of the TSMI_Server_Delete control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    private void TSMI_Delete_Click( object sender, EventArgs e )
    {
      m_Node.Remove();
      m_Node.Dispose();
    }
    /// <summary>
    /// Creates a new subscription and adds it to the tree.
    /// Handles the Click event of the m_TSMI_CS_BrowseDictionary control. 
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    private void TSMI_CreateSubscription_Click( object sender, EventArgs e )
    {
      m_Node.CreateSubscription();
    }
    /// <summary>
    /// Reads a set of items for the server.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    private void TSMI_Read_Click( object sender, EventArgs e )
    {
      using ( ReadItemsDlg dial = new ReadItemsDlg() ) { dial.ShowDialog( m_Node.MyServer.Duplicate() ); }
    }
    /// <summary>
    /// Writes a set of items to the server.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    private void TSMI_Write_Click( object sender, EventArgs e )
    {
      using ( WriteItemsDlg dial = new WriteItemsDlg() ) { dial.ShowDialog( m_Node.MyServer.Duplicate() ); }
    }
    /// <summary>
    /// Displays the address space of the server in a modal dialog.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    private void TSMI_BrowseItems_Click( object sender, EventArgs e )
    {
      DictionaryDialog.OpenDioctionaryDialog( (Server)m_Node.MyServer.Duplicate(), null );
    }
    /// <summary>
    /// Handles the Click event of the ContextMenu control.
    /// Setup context menu.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.ComponentModel.CancelEventArgs"/> instance containing the event data.</param>
    private void m_ContextMenu_Opening( object sender, CancelEventArgs e )
    {
      m_TSMI_Connect.Enabled = !m_Node.IsConnected;
      m_TSMI_ViewStatus.Enabled = m_Node.IsConnected;
      m_TSMI_Disconnect.Enabled = m_Node.IsConnected;
      m_TSMI_CS_BrowseDictionary.Enabled = !m_Node.IsConnected;
      m_TSMI_CS_BrowseServer.Enabled = m_Node.IsConnected;
    }
    #endregion
    #endregion
  }
}
