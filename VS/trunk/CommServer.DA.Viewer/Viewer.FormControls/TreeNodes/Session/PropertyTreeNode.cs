//<summary>
//  Title   : Property Tree Node Class
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
using CAS.Lib.OPC.AddressSpace;
using OpcDa = Opc.Da;

namespace CAS.Lib.OPCClientControlsLib.TreeNodes.Browse
{
  /// <summary>
  /// Property Tree Node Class
  /// </summary>
  internal class PropertyTreeNode<ParentType>: BrowseTreeNode<OpcDa::ItemProperty, ParentType>
    where ParentType: class, IBrowse
  {
    #region private
    private class PropertyValueNode<PropertyParentType>: BrowseTreeNode<object, PropertyParentType>
      where PropertyParentType: class, IBrowse
    {
      #region private
      protected override void BranchBrowse()
      {
        if ( Tag == null || !Tag.GetType().IsArray )
          return;
        foreach ( object element in (Array)Tag )
          new PropertyValueNode<PropertyValueNode<PropertyParentType>>( Opc.Convert.ToString( element ), element, this );
      }
      protected override void AssignImageIndex()
      {
        ImageIndex = SelectedImageIndex = (int)ImageListLibrary.Icons.IMAGE_TAG_WOR;
        ToolTipText = Properties.Resources.PropertyValueNodeToolTip;
      }
      #endregion
      #region constructor
      internal PropertyValueNode( string text, object value, PropertyParentType node )
        : base( text, value, node )
      {
        AssignImageIndex();
        if ( value != null && value.GetType().IsArray )
          AddDummyNode();
      }
      #endregion
      #region IBrowse
      public override NodeType GetNodeType { get { return NodeType.PropertyValue; } }
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
    }
    protected override void BranchBrowse()
    {
      new PropertyValueNode<PropertyTreeNode<ParentType>>( Opc.Convert.ToString( Tag.Value ), Tag.Value, this );
    }
    protected override void AssignImageIndex()
    {
      ToolTipText = Properties.Resources.PropertyNodeToolTip;
      if ( Tag.ResultID.Failed() )
        ImageIndex = SelectedImageIndex = (int)ImageListLibrary.Icons.IMAGE_PROPERTY_FAIL;
      if ( string.IsNullOrEmpty( Tag.ItemName ) )
        //TODO Select appropriate icon
        ImageIndex = SelectedImageIndex = (int)ImageListLibrary.Icons.IMAGE_PROPERTY;
      else
        ImageIndex = SelectedImageIndex = (int)ImageListLibrary.Icons.IMAGE_PROPERTY_WOR;
    }
    #endregion
    #region constructor
    /// <summary>
    /// Initializes a new instance of the <see cref="PropertyTreeNode&lt;ParentType&gt;"/> class.
    /// </summary>
    /// <param name="property">The property.</param>
    /// <param name="node">The parent node.</param>
    internal PropertyTreeNode( OpcDa::ItemProperty property, ParentType node )
      : base( property.ID.ToString(), property, node )
    {
      if ( property.Value == null )
        return;
      AddDummyNode();
    }
    #endregion
    #region IBrowse
    /// <summary>
    /// Get the type of the node.
    /// </summary>
    /// <value>The type of the Node.</value>
    public override NodeType GetNodeType { get { return NodeType.Property; } }
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
      int key = addressSpace.ItemPropertiesTable.AddRow( this.Tag, parentKey );
      base.Save( addressSpace, key, root );
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
  }
}
