//<summary>
//  Title   : Browse Element Node
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
using CAS.Lib.OPCClient.Da;
using OpcDa = global::Opc.Da;

namespace CAS.Lib.OPCClientControlsLib.TreeNodes.Browse
{
  /// <summary>
  /// Browse Element Node
  /// </summary>
  internal class BrowseElementNode: BrowseTreeNode<OpcDa::BrowseElement, IBrowse>
  {
    #region private
    private AddressSpaceDataBase.TagsTableRow m_TableRow;
    private class mBrowseServer: BrowseServer
    {
      #region private
      private BrowseElementNode m_Parent;
      protected override void AddBrowseElement( OpcDa::BrowseElement element )
      {
        new BrowseElementNode( element, m_Parent );
      }
      #endregion
      #region constructor
      /// <summary>
      /// Initializes a new instance of the <see cref="mBrowseServer"/> class.
      /// </summary>
      /// <param name="parent">The <see cref="Server"/> parent.</param>
      /// <param name="itemID">The <see cref="ItemIdentifier"/> in the address space to browse .</param>
      /// <param name="filters">The filters.</param>
      internal mBrowseServer( BrowseElementNode parent, Opc.ItemIdentifier itemID, OpcDa::BrowseFilters filters )
        : base( parent.FindServer() )
      {
        m_Parent = parent;
        base.Browse( itemID, filters );
      }
      #endregion
    }
    private class mBrowseDictionary: BrowseDictionary
    {
      #region private
      private BrowseElementNode m_Parent;
      protected override void AddBrowseElement( AddressSpaceDataBase.TagsTableRow element )
      {
        new BrowseElementNode( element, m_Parent );
      }
      #endregion
      #region constructor
      /// <summary>
      /// Initializes a new instance of the <see cref="mBrowseDictionary"/> class.
      /// </summary>
      /// <param name="parent">The parent.</param>
      /// <param name="itemID">The item ID.</param>
      /// <param name="filters">The filters.</param>
      internal mBrowseDictionary( BrowseElementNode parent, OpcDa::BrowseFilters filters )
        : base( (AddressSpaceDataBase)parent.m_TableRow.Table.DataSet )
      {
        m_Parent = parent;
        base.Browse( parent.m_TableRow, filters );
      }
      #endregion
    }
    private void AddItemProperty( OpcDa::ItemProperty property )
    {
      if ( property.ResultID.Succeeded() )
        new PropertyTreeNode<IBrowse>( property, this );
    }
    //TODO Use it for refresh
    private void GetProperties()
    {
      try
      {
        // can only get properties for an item.
        if ( !Tag.IsItem )
          return;
        // get the server for the current node.
        Server server = FindServer();
        // get the current element to use for a get properties.
        //BrowseElement element = null;
        //if ( node.Tag != null && node.Tag.GetType() == typeof( BrowseElement ) )
        //  element = (BrowseElement)node.Tag;
        // clear the node children.
        //Clear();
        // begin a browse.			
        Opc.ItemIdentifier itemID = new Opc.ItemIdentifier( Tag.ItemPath, Tag.ItemName );
        OpcDa::ItemPropertyCollection[] propertyLists =
          server.GetProperties
          ( new Opc.ItemIdentifier[] { itemID }, DefaultBrowseFilters.PropertyIDs, DefaultBrowseFilters.ReturnPropertyValues );
        if ( propertyLists != null )
        {
          foreach ( OpcDa::ItemPropertyCollection propertyList in propertyLists )
          {
            foreach ( OpcDa::ItemProperty property in propertyList )
              AddItemProperty( property );
            // update element properties.
            Tag.Properties = (OpcDa::ItemProperty[])propertyList.ToArray( typeof( OpcDa::ItemProperty ) );
          }
        }
        //TODO implement
        // send notification that property list changed.
        //if ( ElementSelected != null )
        //  ElementSelected( element );
      }
      catch ( Exception e )
      {
        MessageBox.Show( e.Message );
      }
    }
    protected override void AssignImageIndex()
    {
      if ( Tag.IsItem )
      {
        ImageIndex = SelectedImageIndex = (int)ImageListLibrary.Icons.IMAGE_TAG;
        ToolTipText = Properties.Resources.BrowseElementNodeTag;
      }
      else
      {
        ImageIndex = SelectedImageIndex = (int)ImageListLibrary.Icons.IMAGE_OPEN_YELLOW_FOLDER;
        ToolTipText = Properties.Resources.BrowseElementNodeFolder;
      }
    }
    protected override void BranchBrowse()
    {
      if ( !Tag.IsItem )
      {
        if ( FindServer().IsConnected )
        {
          Opc.ItemIdentifier itemID = new Opc.ItemIdentifier( Tag.ItemPath, Tag.ItemName );
          new mBrowseServer( this, itemID, this.DefaultBrowseFilters );
        }
        else
          new mBrowseDictionary( this, this.DefaultBrowseFilters );
      }
      // add properties
      if ( Tag.Properties != null )
        foreach ( OpcDa::ItemProperty property in Tag.Properties )
          AddItemProperty( property );
      //TODO MP: if Refresh we should use this
      //  GetProperties();
    }
    #endregion
    #region constructor
    /// <summary>
    /// Initializes a new instance of the <see cref="BrowseElementNode"/> class.
    /// </summary>
    /// <param name="element">The element to start with.</param>
    /// <param name="parent">The parent.</param>
    internal BrowseElementNode( AddressSpaceDataBase.TagsTableRow element, IBrowse parent )
      : this( element.GetBrowseElement(), parent )
    {
      m_TableRow = element;
    }
    /// <summary>
    /// Initializes a new instance of the <see cref="BrowseElementNode"/> class.
    /// </summary>
    /// <param name="element">The element to start with.</param>
    /// <param name="parent">The parent.</param>
    internal BrowseElementNode( OpcDa::BrowseElement element, IBrowse parent )
      : base( element.Name, element, parent )
    {
      // add a dummy node to force display of '+' symbol.
      if ( ( Tag.HasChildren ) || ( Tag.Properties != null ) )
        AddDummyNode();
    }
    #endregion
    #region internal
    /// <summary>
    /// Gets my browse element.
    /// </summary>
    /// <value>My browse element <see cref="OpcDa.BrowseElement"/>.</value>
    internal OpcDa.BrowseElement MyBrowseElement { get { return Tag; } }
    /// <summary>
    /// Gets my <see cref="ItemIdentifier"/>.
    /// </summary>
    /// <value>My item identifier.</value>
    internal Opc.ItemIdentifier MyItemIdentifier { get { return new Opc.ItemIdentifier( Tag.ItemPath, Tag.ItemName ); } }
    #endregion
    #region IBrowse
    /// <summary>
    /// Gets the type of the node.
    /// </summary>
    /// <value>The type of the node.</value>
    public override NodeType GetNodeType { get { return Tag.IsItem ? NodeType.Item : NodeType.BrowseElement; } }
    #endregion
    #region ISave
    /// <summary>
    /// Saves the specified repository.
    /// </summary>
    /// <param name="repository">The repository.</param>
    /// <param name="parentKey">The parent key.</param>
    /// <param name="root">if set to <c>true</c> it is root browse element.</param>
    public override void Save( AddressSpaceDataBase repository, int parentKey, bool root )
    {
      m_TableRow = repository.TagsTable.AddRow( this.Tag, parentKey, root );
      base.Save( repository, m_TableRow.ID, false );
    }
    #endregion

    public override ContextMenuStrip Menu
    {
      get { throw new NotImplementedException(); }
    }
  }//BrowseElementNode
}
