//<summary>
//  Title   : Item Context Menu
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

namespace CAS.Lib.OPCClientControlsLib
{
 
  using TreeNodes.Session;
  
  public partial class ContextMenuTag: UserControl
  {
    #region constructors
    /// <summary>
    /// Initializes a new instance of the <see cref="ItemContextMenu"/> class.
    /// </summary>
    public ContextMenuTag()
    {
      InitializeComponent();
    }
    /// <summary>
    /// Initializes a new instance of the <see cref="ItemContextMenu"/> class.
    /// </summary>
    /// <param name="node">The node.</param>
    internal ContextMenuTag( TagTreeNode node )
      : this()
    {
      m_Node = node;
    }
    #endregion
    #region public
    /// <summary>
    /// Gets the menu.
    /// </summary>
    /// <value>The menu.</value>
    internal ContextMenuStrip Menu { get { return m_ContextMenu; } }
    #endregion
    #region private
    private TagTreeNode m_Node;
    #endregion
    #region ContextMenu handlers
    /// <summary>
    /// Handles the Click event of the editToolStripMenuItem control.
    /// Edit items in the specified subscription.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    private void TSMI_ItemEdit_Click( object sender, EventArgs e )
    {
      m_Node.Edit();
    }
    /// <summary>
    /// Handles the Click event of the m_TSMI_Dlete control.
    /// Remove an item in the specified subscription.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    private void TSMI_ItemDelete_Click( object sender, EventArgs e )
    {
      SubscriptionTreeNodeSession sb = m_Node.Parent;
      sb.RemoveItemNode( m_Node );
    }
    /// <summary>
    /// Handles the Click event of the m_TSMI_Active control.
    /// Toggle the active state of the selected item.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    private void TSMI_ItemActive_Click( object sender, EventArgs e )
    {
      m_Node.Active = ( (ToolStripMenuItem)sender ).Checked;
    }
    /// <summary>
    /// Handles the Opening event of the m_Item_PopupMenu control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.ComponentModel.CancelEventArgs"/> instance containing the event data.</param>
    private void m_Item_PopupMenu_Opening( object sender, System.ComponentModel.CancelEventArgs e )
    {
      m_TSMI_Active.Checked = m_Node.Active;
    }
    #endregion
  }
}
