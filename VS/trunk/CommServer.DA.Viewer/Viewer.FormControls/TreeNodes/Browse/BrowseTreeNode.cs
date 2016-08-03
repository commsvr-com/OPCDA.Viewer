//<summary>
//  Title   : Browse Tree Node
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

using System.Drawing;
using CAS.Lib.OPC.AddressSpace;
using CAS.Lib.OPCClient.Da;
using OpcDa = Opc.Da;

namespace CAS.Lib.OPCClientControlsLib.TreeNodes.Browse
{
  /// <summary>
  /// Represents dedicated to address space management TreeNode
  /// </summary>
  /// <typeparam name="ObjectType">The type of the object type.</typeparam>
  /// <typeparam name="ParentType">The type of the parent type.</typeparam>
  internal abstract class BrowseTreeNode<ObjectType, ParentType>: SaveableTreeNode<ObjectType, ParentType>, IBrowse
    where ObjectType: class
    where ParentType: class, IBrowse
  {
    #region private
    private static Color cFilterApplied = Color.Red;
    private static Color cNormal = Color.Green;
    private bool pBrowseCompleted = false;
    private OpcDa::BrowseFilters pfilters = null;
    protected abstract void BranchBrowse();
    private void SetForeColor()
    {
      if ( pfilters != null )
        this.ForeColor = cFilterApplied;
      else
        this.ForeColor = cNormal;
    }
    protected void AddDummyNode() { new DummyNode( this ); }
    #endregion
    #region Constructors
    /// <summary>
    /// Initializes a new instance of the <see cref="BrowseTreeNode"/> class.
    /// </summary>
    /// <param name="text">The label <see cref="System.Windows.Forms.TreeNode.Text"/> of the new tree node.</param>
    /// <param name="obj">The object coupled with the node.</param>
    /// <param name="node">The node to add new object.</param>
    internal BrowseTreeNode( string text, ObjectType obj, ParentType node )
      : base( text, obj, node )
    { }
    /// <summary>
    /// Initializes a new instance of the <see cref="BrowseTreeNode"/> class.
    /// </summary>
    /// <param name="text">The label <see cref="System.Windows.Forms.TreeNode.Text"/> of the new tree node.</param>
    /// <param name="obj">The object coupled with the node.</param>
    /// <param name="filters">The filters to apply.</param>
    internal BrowseTreeNode( string text, ObjectType obj, OpcDa::BrowseFilters filters )
      : base( text, obj )
    {
      pfilters = filters;
      SetForeColor();
    }
    #endregion
    #region IBrowse Members
    /// <summary>
    /// Refreshes this instance.
    /// </summary>
    public void Refresh()
    {
      pBrowseCompleted = false;
      Browse( true );
    }
    /// <summary>
    /// Browses the address space.
    /// </summary>
    /// <param name="shallow">if set to <c>true</c> shallow stop at this level, otherwise browse up to the bottom..</param>
    public void Browse( bool shallow )
    {
      if ( shallow && pBrowseCompleted )
        return;
      DisposeChildren();
      BranchBrowse();
      pBrowseCompleted = true;
      if ( shallow )
        return;
      foreach ( IBrowse node in Nodes )
        node.Browse( shallow );
    }

    #endregion
    #region ITreeNodeCommon Members
    /// <summary>
    /// Gets or sets the default browse filters.
    /// </summary>
    /// <value>The default browse filters.</value>
    public virtual OpcDa::BrowseFilters DefaultBrowseFilters
    {
      get
      {
        if ( pfilters != null )
          return pfilters;
        if ( Parent == null )
          return new OpcDa::BrowseFilters();
        return Parent.DefaultBrowseFilters;
      }
      set
      {
        pfilters = value;
        SetForeColor();
        pBrowseCompleted = false;
        this.Browse( true );
      }
    }
    #endregion
    #region ISave
    /// <summary>
    /// Saves this instance and all children in the address space.
    /// </summary>
    /// <param name="addressSpace">The address space.</param>
    /// <param name="parentKey">The parent key.</param>
    /// <param name="root">if set to <c>true</c> it is root browe element.</param>
    public override void Save( AddressSpaceDataBase addressSpace, int parentKey, bool root )
    {
      System.Diagnostics.Debug.Assert( pBrowseCompleted );
      base.Save( addressSpace, parentKey, root );
    }
    #endregion
    #region IBrowse
    /// <summary>
    /// Get the type of the node.
    /// </summary>
    /// <value>The type of the Node.</value>
    public abstract NodeType GetNodeType { get; }
    /// <summary>
    /// Finds the server.
    /// </summary>
    /// <returns>The server at the top of this tree</returns>
    public virtual Server FindServer()
    {
      if ( Parent == null )
        return null;
      return Parent.FindServer();
    }
    #endregion
  }
}
