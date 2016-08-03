//<summary>
//  Title   : TreeNode representing a tag for Read/write operations
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
using System.Collections.Generic;
using System.Text;
using OpcDa = Opc.Da;
using CAS.Lib.ControlLibrary;
using System.Windows.Forms;

namespace CAS.Lib.OPCClientControlsLib.TreeNodes.Session
{
  /// <summary>
  /// TreeNode representing a tag for Read/write operations
  /// </summary>
  class TagTreeNode4RW: TagTreeNodeBase<OpcDa.Item, SubscriptionTreeNode4RW>
  {
    #region constructor
    /// <summary>
    /// Initializes a new instance of the <see cref="TagTreeNode"/> class with the specified label text.
    /// </summary>
    /// <param name="text">The text.</param>
    /// <param name="obj">The obj.</param>
    /// <param name="view">The <see cref="SubscriptionTreeNode"/> to add new item.</param>
    internal TagTreeNode4RW( OpcDa.Item obj, SubscriptionTreeNode4RW view )
      : base( obj.ItemName, obj, view )
    { }
    #endregion
    #region ITreeNodeInterface
    /// <summary>
    /// Gets or sets a value indicating whether the item is active.
    /// </summary>
    /// <value><c>true</c> if active; otherwise <c>false</c>.</value>
    internal override bool Active
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
    #region PRIVATE
    /// <summary>
    /// Gets a value indicating whether this <see cref="TagTreeNodeBase&lt;ObjectType, ParentType&gt;"/> is an error state.
    /// </summary>
    /// <value><c>true</c> if error; otherwise, <c>false</c>.</value>
    protected override bool Error
    {
      get { return false; }
    }
    #endregion
  }
}
