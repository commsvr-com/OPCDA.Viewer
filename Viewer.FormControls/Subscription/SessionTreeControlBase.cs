//<summary>
//  Title   : Subscriptions dedicated Tree Control
//  System  : Microsoft Visual C# .NET 2005
//  $LastChangedDate$
//  $Rev$
//  $LastChangedBy$
//  $URL$
//  $Id$
//  History :
//    20080515: mzbrzezny: ProcessingEnvironment is added, event EventHandler<ServerEventArgs> SelectServer is removed and moved to generic session tree node
//    20080226: mpostol: created
//
//  Copyright (C)2006, CAS LODZ POLAND.
//  TEL: +48 (42) 686 25 47
//  mailto:techsupp@cas.com.pl
//  http://www.cas.eu
//</summary>

using System.Windows.Forms;

namespace CAS.Lib.OPCClientControlsLib
{
  using CAS.Lib.ControlLibrary;

  /// <summary>
  /// Subscriptions dedicated Tree Control
  /// </summary>
  public partial class SessionTreeControlBase: UserControl
  {
    #region creator
    public SessionTreeControlBase()
    {
      InitializeComponent();
    }
    #endregion
    #region private
    /// <summary>
    /// Updates the state of context menu.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.Windows.Forms.MouseEventArgs"/> instance containing the event data.</param>
    private void m_SubscriptionTreeView_MouseDown( object sender, MouseEventArgs e )
    {
      // ignore left button actions.
      if ( e.Button != MouseButtons.Right )
        return;
      SubscriptionTreeView mTree = sender as SubscriptionTreeView;
      System.Diagnostics.Debug.Assert( mTree != null );
      // selects the item that was right clicked on.
      var clickedNode = mTree.GetNodeAt( e.X, e.Y ) as ITreeNodeInterface;
      // no item clicked on - do nothing.
      if ( clickedNode == null )
      {
        mTree.ContextMenuStrip = null;
        return;
      }
      mTree.ContextMenuStrip = clickedNode.Menu;
      // force selection to clicked node.
      clickedNode.MakeSelected();
    }
    private void m_SubscriptionTreeView_AfterSelect( object sender, TreeViewEventArgs e )
    {
      ( (ITreeNodeInterface)e.Node ).MakeSelected();
    }
    #endregion
  }
}