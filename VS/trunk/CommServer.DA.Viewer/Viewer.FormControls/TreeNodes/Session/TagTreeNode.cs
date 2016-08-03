//<summary>
//  Title   : TreeNode representing a tag
//  System  : Microsoft Visual C# .NET 2008
//  $LastChangedDate$
//  $Rev$
//  $LastChangedBy$
//  $URL$
//  $Id$
//
//  20080616 - mzbrzezny: TagTreeNode: subscription name is passed to itemwrapper
//  2008 - mpostol: created
//
//  Copyright (C)2008, CAS LODZ POLAND.
//  TEL: +48 (42) 686 25 47
//  mailto://techsupp@cas.eu
//  http://www.cas.eu
//</summary>

using System;
using System.Windows.Forms;
using CAS.DataPorter.Configurator;
using CAS.Lib.ControlLibrary;
using OpcDa = Opc.Da;

namespace CAS.Lib.OPCClientControlsLib.TreeNodes.Session
{
  /// <summary>
  /// TreeNode representing a tag
  /// </summary>
  internal class TagTreeNode: TagTreeNodeBase<ItemWrapper, SubscriptionTreeNodeSession>
  {
    #region creators and destructors
    /// <summary>
    /// Initializes a new instance of the <see cref="TagTreeNode"/> class with the specified label text.
    /// </summary>
    /// <param name="item">The item.</param>
    /// <param name="parentNode">The parent node.</param>
    internal TagTreeNode( OpcDa.Item item, SubscriptionTreeNodeSession parentNode )
      : base( item.ItemName, null, parentNode )
    {
      Tag = new MyItem( new OpcDa.ItemResult( item ) { ResultID = Opc.ResultID.S_OK }, this);
      InitializeObject();
    }
    /// <summary>
    /// Initializes a new instance of the <see cref="TagTreeNode"/> class.
    /// </summary>
    /// <param name="item">The item.</param>
    /// <param name="parentNode">The parent node.</param>
    internal TagTreeNode( OpcDa.ItemResult item, SubscriptionTreeNodeSession parentNode )
      : base( item.ItemName, null, parentNode )
    {
      Tag = new MyItem( item, this);
      InitializeObject();
    }
    /// <summary>
    /// Initializes a new instance of the <see cref="TagTreeNode"/> class.
    /// </summary>
    /// <param name="row">The description row <see cref="OPCCliConfiguration.ItemsRow"/>.</param>
    /// <param name="parentNode">The parent node.</param>
    internal TagTreeNode( OPCCliConfiguration.ItemsRow row, SubscriptionTreeNodeSession parentNode )
      : base( row.Name, null, parentNode )
    {
      Tag = new MyItem( row, this);
      InitializeObject();
    }
    #endregion creators and destructors
    #region internal
    /// <summary>
    /// Gets or sets a value indicating whether this <see cref="TagTreeNode"/> is active.
    /// </summary>
    /// <value><c>true</c> if active; otherwise <c>false</c>.</value>
    internal override bool Active
    {
      get { return Tag.Active.HasValue ? Tag.Active.Value : true; }
      set
      {
        try
        {
          Tag.Active = value;
          Parent.ModifyItems( OpcDa::StateMask.Active, new OpcDa.Item[] { Tag.GetItem } );
        }
        catch ( Exception exc )
        {
          MessageBox.Show( exc.Message );
        }
        AssignImageIndex();
      }
    }
    /// <summary>
    /// Edits this instance.
    /// </summary>
    internal void Edit()
    {
      try
      {
        // save existing item id.
        OpcDa::Item[] modifiedItems;
        OpcDa.Item itemID = Tag.GetItem;
        using ( ItemListEditDlg dial = new ItemListEditDlg() )
        {
          modifiedItems = dial.ShowDialog( new OpcDa.Item[] { itemID }, false, false );
          if ( dial.DialogResult != DialogResult.OK || modifiedItems == null )
            return;
        }
        // modify an existing item.
        OpcDa::ItemResult[] resItems;
        if ( itemID.Key == modifiedItems[ 0 ].Key )
          resItems = Parent.ModifyItems( OpcDa::StateMask.All, modifiedItems );
        else // add/remove item because the item id changed.
        {
          Parent.RemoveItem( itemID );
          resItems = Parent.AddItems( modifiedItems );
        }
        Text = resItems[ 0 ].ItemName;
        Tag.SetItemResult = resItems[ 0 ];
      }
      catch ( Exception exc )
      {
        MessageBox.Show( exc.Message );
      }
      AssignImageIndex();
    }
    /// <summary>
    /// Gets my item identifier <see cref="ItemIdentifier"/>.
    /// </summary>
    /// <value>Created item identifier <see cref="ItemIdentifier"/>.</value>
    internal Opc.ItemIdentifier MyItemIdentifier { get { return Tag.GetItem; } }
    #endregion
    #region ISave
    /// <summary>
    /// Saves the current item in the <see cref="OPCCliConfiguration"/>.
    /// </summary>
    /// <param name="configuration">The current configuration.</param>
    /// <param name="parentKey">The parent key.</param>
    public override void Save( OPCCliConfiguration configuration, long parentKey )
    {
      long pk = Tag.Save( configuration, parentKey );
      base.Save( configuration, pk );
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
      get { return m_Menu.Menu; }
    }
    #endregion
    #region IDisposable
    /// <summary>
    /// Recursively searches the tree and free objects.
    /// </summary>
    /// <param name="disposing"><c>true</c> if called programaticaly.</param>
    protected override void Dispose( bool disposing )
    {
      if ( disposing )
        Tag.Dispose();
      base.Dispose( disposing );
    }
    #endregion
    #region private
    /// <summary>
    /// Class representing my item.
    /// </summary>
    private class MyItem: ItemWrapper
    {
      private TagTreeNode m_Parent;
      protected override string ParentName
      {
        get { return m_Parent.Parent.Text; }
      }
      public MyItem( OPCCliConfiguration.ItemsRow row, TagTreeNode parent )
        : base( row )
      {
        m_Parent = parent;
      }
      public MyItem( OpcDa.ItemResult item, TagTreeNode parent )
        : base( item )
      {
        m_Parent = parent;
      }
    }
    private ContextMenuTag m_Menu;
    private void OnResuldChanged( object sender, EventArgs e )
    {
      AssignImageIndex();
    }
    private void InitializeObject()
    {
      Tag.ResuldChanged += OnResuldChanged;
      m_Menu = new ContextMenuTag( this );
      AssignImageIndex();
    }
    /// <summary>
    /// Gets a value indicating whether this <see cref="TagTreeNodeBase&lt;ObjectType, ParentType&gt;"/> is in an error state.
    /// </summary>
    /// <value><c>true</c> if error; otherwise, <c>false</c>.</value>
    protected override bool Error { get { return !Tag.Succeeded; } }
    #endregion
  }
}
