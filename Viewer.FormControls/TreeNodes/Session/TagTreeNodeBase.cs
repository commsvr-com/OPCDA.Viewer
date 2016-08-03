//<summary>
//  Title   : The base class of TreeNode representing a tag
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

using CAS.Lib.ControlLibrary;

namespace CAS.Lib.OPCClientControlsLib.TreeNodes.Session
{
  /// <summary>
  /// The base class of TreeNode representing a tag
  /// </summary>
  /// <typeparam name="ObjectType">The type of the object.</typeparam>
  /// <typeparam name="ParentType">The type of the parent.</typeparam>
  internal abstract class TagTreeNodeBase<ObjectType, ParentType>: SessionTreeNode<ObjectType, ParentType>
    where ObjectType: class
    where ParentType: class, ISession
  {
    #region constructor
    /// <summary>
    /// Initializes a new instance of the <see cref="TagTreeNode"/> class with the specified label text.
    /// </summary>
    /// <param name="text">The text.</param>
    /// <param name="obj">The obj.</param>
    /// <param name="view">The <see cref="OPCTreeView"/> to add new item.</param>
    internal TagTreeNodeBase( string text, ObjectType obj, ParentType view )
      : base( text, obj, view )
    { } 
    #endregion
    #region public
    /// <summary>
    /// Gets or sets a value indicating whether the item is active.
    /// </summary>
    /// <value><c>true</c> if active; otherwise <c>false</c>.</value>
    internal abstract bool Active { get; set; }
    #endregion
    #region private
    /// <summary>
    /// Gets a value indicating whether this <see cref="TagTreeNodeBase&lt;ObjectType, ParentType&gt;"/> is an error state.
    /// </summary>
    /// <value><c>true</c> if error; otherwise, <c>false</c>.</value>
    protected abstract bool Error { get; }
    /// <summary>
    /// Gets  the image list index and ToolTipText values of the image displayed .
    /// </summary>
    /// <value>Standard icon if true, standby if false</value>
    protected override void AssignImageIndex()
    {
      if ( Error )
      {
        SelectedImageIndex = base.ImageIndex = (int)ImageListLibrary.Icons.IMAGE_TAG_FAIL;
        base.ToolTipText = this.ToolTipText = Properties.Resources.TagTreeNodeToolTipError;
      }
      else if ( Active )
      {
        SelectedImageIndex = base.ImageIndex = (int)ImageListLibrary.Icons.IMAGE_TAG;
        base.ToolTipText = this.ToolTipText = Properties.Resources.TagTreeNodeToolTipActive;
      }
      else
      {
        SelectedImageIndex = base.ImageIndex = (int)ImageListLibrary.Icons.IMAGE_TAG_SB;
        base.ToolTipText = this.ToolTipText = Properties.Resources.TagTreeNodeToolTipNotActive;
      }
    } 
    #endregion
  }
}
