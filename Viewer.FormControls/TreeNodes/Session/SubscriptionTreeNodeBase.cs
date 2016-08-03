//<summary>
//  Title   : Subscription Tree Node Base abstract class
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

namespace CAS.Lib.OPCClientControlsLib.TreeNodes.Session
{

  using ControlLibrary;

  /// <summary>
  /// Subscription Tree Node Base abstract class
  /// </summary>
  /// <typeparam name="ObjectType">The type of the bject type.</typeparam>
  /// <typeparam name="ParentType">The type of the arent type.</typeparam>
  internal abstract class SubscriptionTreeNodeBase<ObjectType, ParentType>: SessionTreeNode<ObjectType, ParentType>
    where ObjectType: class
    where ParentType: class, ISession
  {
    #region public
    #region constructors
    /// <summary>
    /// Initializes a new instance of the <see cref="SessionTreeNode&lt;ObjectType, ParentType&gt;"/> class.
    /// </summary>
    /// <param name="text">The label <see cref="System.Windows.Forms.TreeNode.Text"/> of the new tree node.</param>
    /// <param name="obj">The object coupled with the node.</param>
    /// <param name="node">The node to add new object.</param>
    public SubscriptionTreeNodeBase( string text, ObjectType obj, ParentType node )
      : base( text, obj, node )
    { }
    /// <summary>
    /// Initializes a new instance of the  class.
    /// </summary>
    /// <param name="text">The label <see cref="System.Windows.Forms.TreeNode.Text"/> of the new tree node.</param>
    /// <param name="obj">The object coupled with the node.</param>
    public SubscriptionTreeNodeBase( string text, ObjectType obj )
      : base( text, obj )
    { }
    #endregion constructors
    internal protected abstract bool Active { get; set; }
    internal protected abstract bool Enabled { get; set; }
    #endregion
    #region private
    private int SetImageIndex
    {
      set { ImageIndex = SelectedImageIndex = value; }
    }
    protected override void AssignImageIndex()
    {
      if ( Tag == null || !Active )
      {
        SetImageIndex = (int)ImageListLibrary.Icons.IMAGE_SUBSCRIPTION_SB;
        this.ToolTipText = Properties.Resources.SubscriptionTreeNodeToolTipNotActive;
      }
      else if ( Enabled )
      {
        SetImageIndex = (int)ImageListLibrary.Icons.IMAGE_SUBSCRIPTION;
        this.ToolTipText = Properties.Resources.SubscriptionTreeNodeToolTipActive;
      }
      else
      {
        SetImageIndex = (int)ImageListLibrary.Icons.IMAGE_SUBSCRIPTION_DISABLED;
        this.ToolTipText = Properties.Resources.SubscriptionTreeNodeToolTipDisabled;
      }
    }
    #endregion
  }
}
