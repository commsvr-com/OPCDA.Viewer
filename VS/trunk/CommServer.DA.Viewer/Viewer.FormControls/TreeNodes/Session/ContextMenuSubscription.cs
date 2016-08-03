//<summary>
//  Title   : Subscription Context Menu
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

namespace CAS.Lib.OPCClientControlsLib
{

  using TreeNodes.Session;

  /// <summary>
  /// Context Menu for the Subscription
  /// </summary>
  public partial class ContextMenuSubscription: UserControl
  {
    #region constructor
    public ContextMenuSubscription()
    {
      InitializeComponent();
    }
    internal ContextMenuSubscription( SubscriptionTreeNodeSession node )
      : this()
    {
      m_Node = node;
    }
    #endregion
    #region public
    /// <summary>
    /// Gets the <see cref="ContextMenuStrip"/>.
    /// </summary>
    /// <value>The menu.</value>
    internal ContextMenuStrip Menu
    {
      get { return m_ContextMenu; }
    }
    #endregion
    #region private
    private SubscriptionTreeNodeSession m_Node;
    #region Subscription functionality
    /// <summary>
    /// Prompts the user to select a set of items and reads them from the server.
    /// </summary>
    /// <param name="synchronous">if set to <c>true</c> synchronous operation.</param>
    private void ReadItems( bool synchronous )
    {
      new ReadItemsDlg().ShowDialog( m_Node.Tag, synchronous );
    }
    /// <summary>
    /// Prompts the user to specify a set of item values and writes them to the server.
    /// </summary>
    /// <param name="synchronous">if set to <c>true</c> synchronous operation.</param>
    private void WriteItems( bool synchronous )
    {
      new WriteItemsDlg().ShowDialog( m_Node.Tag, synchronous );
    }
    #endregion
    #region Subscription menu handlers
    /// <summary>
    /// Edits the state of a subscription.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    private void TSMI_EditState_Click( object sender, EventArgs e )
    {
      m_Node.EditSubscriptions();
    }
    /// <summary>
    /// Called when the Subscription | Edit Options menu item is clicked.
    /// Edits options of a subscription.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    private void TSMI_EditOptions_Click( object sender, EventArgs e )
    {
      m_Node.EditOptions();
    }
    /// <summary>
    /// Removes a subscription.
    /// </summary>
    private void TSMI_Delete_Click( object sender, EventArgs e )
    {
      m_Node.Remove();
      m_Node.Dispose();
    }
    /// <summary>
    /// Add items to a subscription.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    private void TSMI_AddItems_Click( object sender, EventArgs e )
    {
      m_Node.AddItems();
    }
    /// <summary>
    /// Edits items in a subscription.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    private void TSMI_EditItems_Click( object sender, EventArgs e )
    {
      m_Node.EditItems();
    }
    /// <summary>
    /// Toggles the active state of a subscription.
    /// </summary>
    /// <param name="sender">The source <see cref="ToolStripMenuItem"/> of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    private void TSMI_Active_Click( object sender, EventArgs e )
    {
      ToolStripMenuItem mi = sender as ToolStripMenuItem;
      m_Node.Active = mi.Checked;
      m_TSMI_Enabled.Enabled = mi.Checked;
    }
    /// <summary>
    /// Toggles the enabled state of a subscription.
    /// </summary>
    private void TSMI_Enabled_Click( object sender, EventArgs e )
    {
      m_Node.Enabled = ( (ToolStripMenuItem)sender ).Checked;
    }
    /// <summary>
    /// Handles the Click event of the readToolStripMenuItem1 control.
    /// Select a set of items and read them synchronously from the server.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    /// <summary>
    private void TSMI_Read_Click( object sender, EventArgs e )
    {
      ReadItems( true );
    }
    /// <summary>
    /// Handles the Click event of the writeToolStripMenuItem1 control.
    /// Select a set of items and write them synchronously from the server.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    private void TSMI_Write_Click( object sender, EventArgs e )
    {
      WriteItems( true );
    }
    /// <summary>
    /// Handles the Click event of the asyncReadToolStripMenuItem control.
    /// Select a set of items and read them asynchronously from the server.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    private void TSMI_AsyncRead_Click( object sender, EventArgs e )
    {
      ReadItems( false );
    }
    /// <summary>
    /// Handles the Click event of the asyncWriteToolStripMenuItem control.
    /// Select a set of items and write them asynchronously from the server.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    private void TSMI_AsyncWrite_Click( object sender, EventArgs e )
    {
      WriteItems( false );
    }
    /// <summary>
    /// Handles the Click event of the refreshToolStripMenuItem control.
    /// Refresh the items of a subscription.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    private void TSMI_Refresh_Click( object sender, EventArgs e )
    {
      m_Node.RefreshSubscription();
    }
    /// <summary>
    /// Handles the Opening event of the m_ContextMenu control to setup the menu.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.ComponentModel.CancelEventArgs"/> instance containing the event data.</param>
    private void m_ContextMenu_Opening( object sender, CancelEventArgs e )
    {
      //TODO check it - no idea why it is assigned.
      m_TSMI_EditOptions.Enabled = true;
      m_TSMI_Active.Checked = m_Node.Active;
      m_TSMI_Enabled.Checked = m_Node.Enabled;
      m_TSMI_Read.Enabled = m_Node.Tag != null;
      m_TSMI_Write.Enabled = m_Node.Tag != null;
      m_TSMI_AsyncRead.Enabled = m_Node.Tag != null;
      m_TSMI_AsyncWrite.Enabled = m_Node.Tag != null;
    }
    #endregion
    #endregion
  }
}
