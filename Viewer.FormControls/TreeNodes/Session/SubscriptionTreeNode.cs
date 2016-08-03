//<summary>
//  Title   : TreeNode representing a subscription
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
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using CAS.DataPorter.Configurator;
using CAS.Lib.OPCClient.Da;
using OpcDa = global::Opc.Da;

namespace CAS.Lib.OPCClientControlsLib.TreeNodes.Session
{
  /// <summary>
  /// TreeNode representing a subscription
  /// </summary>
  internal class SubscriptionTreeNodeSession: SubscriptionTreeNodeBase<Subscription, OPCSessionServer>, IOptions
  {
    #region private
    private ContextMenuSubscription m_Menu;
    private class SubscriptionItems
    {
      #region constructors
      public SubscriptionItems( SubscriptionTreeNodeSession node )
      {
        foreach ( TagTreeNode item in node.Nodes )
          myChildren.Add( (Guid)item.Tag.ClientHandle, item.Tag );
        srcItems = new OpcDa.Item[ myChildren.Count ];
        for ( int ii = 0; ii < srcItems.Length; ii++ )
        {
          srcItems[ ii ] = myChildren.Values[ ii ].GetItem;
          myChildren.Values[ ii ].Invalidate();
        }
      }
      #endregion
      #region public
      //public SortedList<Guid, ItemWrapper> Children { get { return myChildren; } }
      public OpcDa::Item[] Items { get { return srcItems; } }
      public Opc.ItemIdentifier[] CreateIdentifiers
      {
        get
        {
          Opc.ItemIdentifier[] itemIDs = new Opc.ItemIdentifier[ myChildren.Count ];
          for ( int ii = 0; ii < itemIDs.Length; ii++ )
            itemIDs[ ii ] = new Opc.ItemIdentifier( srcItems[ ii ] );
          return itemIDs;
        }
      }
      /// <summary>
      /// Matches the children and results.
      /// </summary>
      /// <param name="modifiedItems">The modified items.</param>
      public void MatchChildren( OpcDa.ItemResult[] modifiedItems )
      {
        foreach ( var item in modifiedItems )
          //TODO There is an error in the .NET API
          if ( item.ClientHandle.GetType().Equals( typeof( Guid ) ) )
            myChildren[ (Guid)item.ClientHandle ].SetItemResult = item;
      }
      #endregion
      #region private
      private SortedList<Guid, ItemWrapper> myChildren = new SortedList<Guid, ItemWrapper>();
      private OpcDa::Item[] srcItems;
      #endregion
    }
    private OpcDa::SubscriptionState h_State = new global::Opc.Da.SubscriptionState() { Active = false };
    private OpcDa.SubscriptionState State
    {
      get { return Tag == null ? h_State : Tag.State; }
      set { h_State = value; }
    }
    private bool h_Enabled = true;
    private bool m_Disposed = false;
    private OpcDa.ResultFilter m_Filters;
    private static ushort m_SumscriptionNum;
    private void NormalizeSubscriptionName( global::Opc.Da.SubscriptionState subscription )
    {
      if ( String.IsNullOrEmpty( subscription.Name ) )
        subscription.Name = "OffLineSubscription" + ( m_SumscriptionNum++ ).ToString();
    }
    #region IDisposable
    protected override void Dispose( bool disposing )
    {
      if ( m_Disposed )
        return;
      if ( disposing && Tag != null )
        Unsubscribe();
      m_Disposed = true;
      base.Dispose( disposing );
    }
    #endregion
    #endregion
    #region constructors
    /// <summary>
    /// Initializes a new instance of the <see cref="SubscriptionTreeNode"/> class.
    /// </summary>
    /// <param name="subscription">The subscription <see cref="OpcDa::SubscriptionState"/>.</param>
    /// <param name="items">The items <see cref="OpcDa::Item"/>.</param>
    /// <param name="parent">The parent <see cref="OPCSessionServer"/>.</param>
    internal SubscriptionTreeNodeSession( OpcDa::SubscriptionState subscription, OpcDa::Item[] items, OPCSessionServer parent )
      : base( "", null, parent )
    {
      NormalizeSubscriptionName( subscription );
      Text = subscription.Name;
      m_Menu = new ContextMenuSubscription( this );
      State = subscription;
      Clear();
      foreach ( OpcDa::Item item in items )
        new TagTreeNode( item, this );
      this.Expand();
      AssignImageIndex();
    }
    /// <summary>
    /// Initializes a new instance of the <see cref="SubscriptionTreeNode"/> class.
    /// </summary>
    /// <param name="subscription">The subscription <see cref="OPCCliConfiguration.SubscriptionsRow"/>.</param>
    /// <param name="parent">The parent tree node  <see cref="OPCSessionServer"/>.</param>
    internal SubscriptionTreeNodeSession( OPCCliConfiguration.SubscriptionsRow subscription, OPCSessionServer parent ) :
      base( "", null, parent )
    {
      Text = subscription.Name;
      m_Menu = new ContextMenuSubscription( this );
      Enabled = subscription.Enabled;
      State = subscription.CreateSubscriptionState;
      foreach ( var item in subscription.GetItemsRows() )
        new TagTreeNode( item, this );
      AssignImageIndex();
    }
    #endregion
    #region public
    /// <summary>
    /// Open a dialog to add new items to an existing subscription.
    /// </summary>
    internal void AddItems()
    {
      using ( var dial = new SubscriptionAddItemsDlg() )
      {
        dial.ShowDialog( Parent.MyServer, DefaultBrowseFilters, null, null );
        if ( dial.DialogResult != DialogResult.OK )
          return;
        // update tree with new items.
        if ( dial.GetItems.Length == 0 )
          return;
        if ( Tag != null )
        {
          try
          {
            OpcDa.ResultFilter filtr = (OpcDa.ResultFilter)Tag.GetResultFilters();
            Tag.SetResultFilters( (int)OpcDa.ResultFilter.All );
            OpcDa.ItemResult[] results = Tag.AddItems( dial.GetItems );
            foreach ( var item in results )
              new TagTreeNode( item, this );
            Tag.SetResultFilters( (int)filtr );
          }
          catch ( Exception ex )
          {
            MessageBox.Show( ex.Message, "Add new items", MessageBoxButtons.OK, MessageBoxIcon.Error );
          }
        }
        else
          foreach ( OpcDa::Item item in dial.GetItems )
            new TagTreeNode( item, this );
      }
      Expand();
    }
    /// <summary>
    /// Adds the provided items to the subscription.
    /// </summary>
    /// <param name="items">The items <see cref="OpcDa::ItemResult"/>.</param>
    /// <returns>
    /// Array of <see cref="ItemResult"/> with results
    /// </returns>
    internal OpcDa::ItemResult[] AddItems( OpcDa::Item[] items )
    {
      if ( Tag != null )
      {
        Tag.SetResultFilters( (int)OpcDa.ResultFilter.All ); //TODO clean up ResultFilter usage
        return Tag.AddItems( items );
      }
      else
      {
        OpcDa::ItemResult[] res = new OpcDa::ItemResult[ items.Length ];
        for ( int ix = 0; ix < items.Length; ix++ )
          res[ ix ] = new OpcDa::ItemResult( items[ ix ] ) { ResultID = Opc.ResultID.S_OK };
        return res;
      }
    }
    /// <summary>
    /// Removes the item.
    /// </summary>
    /// <param name="item">The item.</param>
    internal void RemoveItemNode( TagTreeNode item )
    {
      if ( Tag != null )
        RemoveItem( item.MyItemIdentifier );
      item.Remove();
      item.Dispose();
      //remove all items from the update control
      Subscription.RaiseSubscriptionModified( Tag, true );
      //add all items to the update control
      Subscription.RaiseSubscriptionModified( Tag, false );
    }
    /// <summary>
    /// Removes the items.
    /// </summary>
    /// <param name="itemIdentifier">The item identifier.</param>
    internal void RemoveItem( Opc.ItemIdentifier itemIdentifier )
    {
      try
      {
        if ( Tag != null )
          Tag.RemoveItems( new Opc.ItemIdentifier[] { itemIdentifier } );
      }
      catch ( Exception exc )
      {
        MessageBox.Show( exc.Message );
      }
    }
    /// <summary>
    /// Open a dialog to display and edit a list of the subscription item objects.
    /// </summary>
    internal void EditItems()
    {
      try
      {
        SubscriptionItems myItems = new SubscriptionItems( this );
        // edit the items.
        OpcDa::Item[] modifiedItems;
        using ( ItemListEditDlg dial = new ItemListEditDlg() )
        {
          modifiedItems = dial.ShowDialog( myItems.Items, false, false );
          if ( dial.DialogResult != DialogResult.OK || modifiedItems == null )
            return;
        }
        if ( Tag != null )
        {
          // separate the items in lists depending on whether item id changed.
          ArrayList insertItems = new ArrayList();
          ArrayList updateItems = new ArrayList();
          ArrayList deleteItems = new ArrayList();
          // save item ids to detect item id changes.
          Opc.ItemIdentifier[] itemIDs = myItems.CreateIdentifiers;
          for ( int ii = 0; ii < itemIDs.Length; ii++ )
          {
            if ( modifiedItems[ ii ].Key != itemIDs[ ii ].Key )
            {
              insertItems.Add( modifiedItems[ ii ] );
              deleteItems.Add( itemIDs[ ii ] );
            }
            else
              updateItems.Add( modifiedItems[ ii ] );
          }
          Tag.SetResultFilters( (int)OpcDa.ResultFilter.All );
          // delete old items.
          if ( deleteItems.Count > 0 )
            Tag.RemoveItems( (Opc.ItemIdentifier[])deleteItems.ToArray( typeof( Opc.ItemIdentifier ) ) );
          // update existing items.
          if ( updateItems.Count > 0 )
            myItems.MatchChildren( Tag.ModifyItems( (int)OpcDa::StateMask.All, (OpcDa::Item[])updateItems.ToArray( typeof( OpcDa::Item ) ) ) );
          // insert new items.
          if ( insertItems.Count > 0 )
            myItems.MatchChildren( Tag.AddItems( (OpcDa::Item[])insertItems.ToArray( typeof( OpcDa::Item ) ) ) );
        }
      }
      catch ( Exception exp )
      {
        MessageBox.Show( exp.Message, "Edit Items", MessageBoxButtons.OK, MessageBoxIcon.Error );
      }
    }
    /// <summary>
    /// Create subscription at the server.
    /// </summary>
    internal void Subscribe()
    {
      try
      {
        State.ClientHandle = Guid.NewGuid();
        Tag = (Subscription)FindServer().CreateSubscription( State );
        SubscriptionItems myItems = new SubscriptionItems( this );
        //force to set subscription state
        Tag.SetResultFilters( (int)OpcDa.ResultFilter.All );
        myItems.MatchChildren( Tag.AddItems( myItems.Items ) );
        Subscription.RaiseSubscriptionModified( Tag, false );
      }
      catch ( Exception ex ) { MessageBox.Show( ex.Message, "Subscribe", MessageBoxButtons.OK, MessageBoxIcon.Error ); }
      finally { AssignImageIndex(); }
    }
    /// <summary>
    /// Modifies the items.
    /// </summary>
    /// <param name="masks">The masks.</param>
    /// <param name="items">The items.</param>
    /// <returns>Results <see cref="OpcDa.ItemResult"/></returns>
    internal OpcDa.ItemResult[] ModifyItems( OpcDa::StateMask masks, OpcDa::Item[] items )
    {
      if ( Tag != null )
      {
        Tag.SetResultFilters( (int)OpcDa.ResultFilter.All );
        return Tag.ModifyItems( (int)masks, items );
      }
      else
      {
        OpcDa.ItemResult[] ret = new OpcDa.ItemResult[ items.Length ];
        for ( int i = 0; i < items.Length; i++ )
          ret[ i ] = new OpcDa.ItemResult( items[ 0 ] ) { ResultID = Opc.ResultID.S_OK };
        return ret;
      }
    }
    /// <summary>
    /// Unsubscribe this instance - remove the subscription from the server.
    /// </summary>
    internal void Unsubscribe()
    {
      try
      {
        //save in lokals fields the current state of the subscription
        h_State = Tag.GetState();
        h_Enabled = Tag.Enabled;
      }
      catch ( Exception ex ) { MessageBox.Show( ex.Message, "Unsubscribe", MessageBoxButtons.OK, MessageBoxIcon.Error ); }
      finally 
      {
        Subscription.RaiseSubscriptionModified( Tag, true );
        Tag.Dispose();
        Tag = null;
        AssignImageIndex(); 
      }
    }
    /// <summary>
    /// Edits items in the subscription.
    /// </summary>
    internal void EditSubscriptions()
    {
      using ( SubscriptionListEditDlg dial = new SubscriptionListEditDlg() )
      {
        OpcDa.SubscriptionState ss = dial.ShowDialog( Parent.SuportedLocales, Parent.Locale, State );
        if ( dial.DialogResult != DialogResult.OK || ss == null )
          return;
        Text = ss.Name;
        State = ss;
      }
      try
      {
        if ( Tag != null )
        {
          Tag.ModifyState( (int)OpcDa::StateMask.All, h_State );
          Subscription.RaiseSubscriptionModified( Tag, !h_State.Active );
        }
        State = h_State;
      }
      catch ( Exception ex )
      {
        MessageBox.Show( ex.Message, "Edit Subscriptions", MessageBoxButtons.OK, MessageBoxIcon.Error );
      }
      AssignImageIndex();
    }
    /// <summary>
    /// Refreshes this subscription.
    /// </summary>
    internal void RefreshSubscription()
    {
      try
      {
        if ( Tag != null )
          Tag.Refresh();
      }
      catch ( Exception exc )
      {
        MessageBox.Show( exc.Message, "Refresh Subscription", MessageBoxButtons.OK, MessageBoxIcon.Error );
      }
    }
    /// <summary>
    /// Gets and sets a value indicating whether this <see cref="Subscription"/> is active.
    /// </summary>
    /// <value><c>true</c> if active; otherwise, <c>false</c>.</value>
    internal protected override bool Active
    {
      get { return State.Active; }
      set
      {
        try
        {
          if ( Tag != null )
          {
            OpcDa::SubscriptionState state = new OpcDa::SubscriptionState() { Active = value };
            Tag.ModifyState( (int)OpcDa::StateMask.Active, state );
            Subscription.RaiseSubscriptionModified( Tag, !value );
          }
          else
            State.Active = value;
        }
        catch ( Exception exc )
        {
          MessageBox.Show( exc.Message );
        }
        AssignImageIndex();
      }
    }
    /// <summary>
    ///  Toggles the enabled state of a subscription - whether data callbacks are enabled.
    /// </summary>
    /// <value><c>true</c> if enabled; otherwise, <c>false</c>.</value>
    internal protected override bool Enabled
    {
      get { return Tag == null ? h_Enabled : Tag.Enabled; }
      set
      {
        try
        {
          h_Enabled = value;
          if ( Tag != null )
            Tag.SetEnabled( value );
          AssignImageIndex();
        }
        catch ( Exception exc )
        {
          MessageBox.Show( exc.Message, "SetEnabled", MessageBoxButtons.OK, MessageBoxIcon.Error );
        }
        AssignImageIndex();
      }
    }
    /// <summary>
    /// Opens a dialog <see cref="Common.OptionsEditDlg"/> to edits the subscription options.
    /// </summary>
    internal void EditOptions()
    {
      using ( var dial = new Common.OptionsEditDlg() )
        dial.ShowDialog( Parent.SuportedLocales, this );
    }
    /// <summary>
    /// Restores the enabled.
    /// </summary>
    internal void RestoreEnabled()
    {
      Enabled = h_Enabled;
    }
    /// <summary>
    /// Gets my subscription.
    /// </summary>
    /// <value>My <see cref="Subscription"/>.</value>
    internal Subscription MySubscription { get { return Tag; } }
    /// <summary>
    /// Gets or sets the object that contains data about the tree node.
    /// </summary>
    /// <value><see cref="Subscription"/></value>
    /// <returns>An uset OPCType object that contains data about the tree node. The default is null.</returns>
    public override Subscription Tag
    {
      get { return base.Tag; }
      set
      {
        base.Tag = value;
        this.Text = State.Name;
      }
    }
    #endregion
    #region IOptions Members
    public string Locale
    {
      get
      {
        if ( Tag == null )
          return State.Locale;
        return Tag.Locale;
      }
      set
      {
        State.Locale = value;
        if ( Tag != null )
          try
          {
            Tag.ModifyState( (int)OpcDa.StateMask.Locale, State );
          }
          catch ( Exception exc )
          {
            MessageBox.Show( exc.Message );
          }
      }
    }
    public OpcDa.ResultFilter Filter
    {
      get
      {
        if ( Tag == null )
          return m_Filters;
        else
          return (OpcDa.ResultFilter)Tag.GetResultFilters();
      }
      set
      {
        if ( Tag == null )
          m_Filters = value;
        else
          Tag.SetResultFilters( (int)value );
      }
    }
    #endregion
    #region ISave
    /// <summary>
    /// Saves the current configuration in the <see cref="OPCCliConfiguration"/>.
    /// </summary>
    /// <param name="configuration">The current configuration.</param>
    /// <param name="parentKey">The parent key.</param>
    public override void Save( OPCCliConfiguration configuration, long parentKey )
    {
      long pk = configuration.Subscriptions.Save( State, Enabled, true, parentKey );
      base.Save( configuration, pk );
    }
    #endregion
    #region ITreeNodeInterface
    /// <summary>
    /// Gets the menu.
    /// </summary>
    /// <value>The menu <see cref="ContextMenuStrip"/>.</value>
    public override ContextMenuStrip Menu
    {
      get { return m_Menu.Menu; }
    }
    #endregion
  }
}
