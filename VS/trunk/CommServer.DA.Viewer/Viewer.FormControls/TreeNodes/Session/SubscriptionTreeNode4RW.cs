//<summary>
//  Title   : TreeNode representing a subscription redicated for read write opertaions
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
using CAS.Lib.OPCClient.Da;
using OpcDa = global::Opc.Da;

namespace CAS.Lib.OPCClientControlsLib.TreeNodes.Session
{
  /// <summary>
  ///  TreeNode representing a subscription redicated for read write opertaions
  /// </summary>
  internal class SubscriptionTreeNode4RW: SubscriptionTreeNodeBase<Subscription, OPCSessionServer>
  {
    #region constructor
    /// <summary>
    /// Initializes a new instance of the <see cref="SubscriptionTreeNode"/> class with the specified label text.
    /// </summary>
    /// <param name="subscription">The subscription <see cref="Subscription"/>to add.</param>
    internal SubscriptionTreeNode4RW( Subscription subscription )
      : base( subscription.Name, subscription )
    {
      Clear();
      foreach ( OpcDa::Item item in subscription.Items )
        new TagTreeNode4RW( item, this );
      this.Expand();
      AssignImageIndex();
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
      get { return null; }
    } 
    #endregion
    #region private
    protected internal override bool Active
    {
      get
      {
        return true;
      }
      set
      {
        throw new NotImplementedException();
      }
    }
    protected internal override bool Enabled
    {
      get
      {
        return true;
      }
      set
      {
        throw new NotImplementedException();
      }
    } 
    #endregion
  }
}
