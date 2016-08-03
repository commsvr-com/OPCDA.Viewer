//<summary>
//  Title   : Subscription dedicated TreeView
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

using System.Windows.Forms;

namespace CAS.Lib.OPCClientControlsLib
{
  using ControlLibrary;
  using OPCClient.Da;
  using TreeNodes.Session;

  /// <summary>
  /// Subscription dedicated <see cref="TreeView"/> 
  /// </summary>
  public partial class SubscriptionTreeView: OPCTreeView
  {
    #region constructor
    /// <summary>
    /// Initializes a new instance of the <see cref="SubscriptionTreeView"/> class.
    /// </summary>
    public SubscriptionTreeView()
    {
      InitializeComponent();
    }
    #endregion
    #region public
    /// <summary>
    /// Gets the selected server.
    /// </summary>
    /// <value>The selected server.</value>
    internal Server SelectedServer
    {
      get
      {
        ISession node = this.SelectedNode as ISession;
        if ( node == null )
          return null;
        return node.FindServer();
      }
    }
    /// <summary>
    /// Gets the selected  tree node interface.
    /// </summary>
    /// <value>The selected  tree node interface.</value>
    internal ITreeNodeInterface SelectedITreeNodeInterface
    {
      get
      {
        return this.SelectedNode as ITreeNodeInterface;
      }
    }
    #endregion
  }
}
