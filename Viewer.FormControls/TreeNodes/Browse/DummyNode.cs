//<summary>
//  Title   : Dummy Node - browse terminator
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
namespace CAS.Lib.OPCClientControlsLib.TreeNodes.Browse
{
  /// <summary>
  /// Dummy Node - browse terminator
  /// </summary>
  internal class DummyNode: BrowseTreeNode<object, IBrowse>
  {
    #region private
    /// <summary>
    /// It is terminator, browse cannot be used for this object.
    /// </summary>
    /// <param name="shallowBrowse">if set to <c>true</c> stop browsing at this level.</param>
    /// <exception cref="NotImplementedException"
    protected override void BranchBrowse()
    {
      throw new NotImplementedException();
    }
    protected override void AssignImageIndex()
    {
      this.ToolTipText = Properties.Resources.TreeNodeToolTipDummy;
    }
    #endregion
    #region creator
    internal DummyNode( IBrowse node ) : base( Properties.Resources.TreeNodeToolTipDummy, null, node ) { }
    #endregion
    #region internal
    /// <summary>
    /// Gets the type of the node.
    /// </summary>
    /// <value>The type of the Node.</value>
    public override NodeType GetNodeType { get {  return NodeType.DummyNode; }}
    #endregion

    public override System.Windows.Forms.ContextMenuStrip Menu
    {
      get { throw new NotImplementedException(); }
    }
  }
}
