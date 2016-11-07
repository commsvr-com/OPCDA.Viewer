﻿//<summary>
//  Title   : A control used to display a set of data updates from a server.
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

using global::Opc.Cpx;
using System.Collections;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using OpcDa = global::Opc.Da;

namespace CAS.Lib.OPCClientControlsLib
{
  using ControlLibrary;
  using OPCClient.Da;
  /// <summary>
  /// Used to receive trace/debug output during data update processing.
  /// </summary>
  public delegate void UpdateEvent_EventHandler( object subscriptionHandle, object args );
  /// <summary>
  /// Class UpdatesViewCtrl.
  /// </summary>
  /// <seealso cref="System.Windows.Forms.UserControl" />
  public partial class UpdatesViewCtrl: UserControl
  {
    #region constructor
    public UpdatesViewCtrl()
    {
      InitializeComponent();
      m_ItemListLV.SmallImageList = m_ImageListLibrary.ProjectImageList;
      SetColumns( ColumnNames );
    }
    #endregion
    #region public
    /// <summary>
    /// Used to receive trace/debug events generated by the control.
    /// </summary>
    public event UpdateEvent_EventHandler UpdateEvent = null;
    /// <summary>
    /// Called when a subscription is added or removed from the control.
    /// </summary>
    public void OnSubscriptionModified( Subscription subscription, bool deleted )
    {
      if ( subscription == null )
        return;
      if ( !deleted )
      {
        // check if the subscription is already added to the control.
        if ( m_items.Contains( subscription.ClientHandle ) )
          return;
        // register for data updates.
        subscription.DataChanged += new OpcDa::DataChangedEventHandler( OnDataChange );
        subscription.DeleteSubscription += new System.EventHandler( subscription_DeleteSubscription );
        // add to subscription list.
        m_subscriptions.Add( subscription.ClientHandle, subscription );
        m_items.Add( subscription.ClientHandle, new ArrayList() );
      }
      else
      {
        // check if the subscription is already removed from the control.
        if ( !m_items.Contains( subscription.ClientHandle ) )
          return;
        // unregister for data updates.
        try
        {
          subscription.DataChanged -= new OpcDa::DataChangedEventHandler( OnDataChange );
        }
        catch ( System.Exception )
        {
          //Now we can do nothig abou it
        }
        subscription.DeleteSubscription -= new System.EventHandler( subscription_DeleteSubscription );
        // remove all items for the subscription.
        ArrayList existingItemList = (ArrayList)m_items[ subscription.ClientHandle ];
        foreach ( ListViewItem listItem in existingItemList )
        {
          EditComplexValueDlg dialog = (EditComplexValueDlg)m_viewers[ listItem ];
          if ( dialog != null )
          {
            dialog.Close();
            m_viewers.Remove( listItem );
          }
          listItem.Remove();
        }
        // remove from subscription list.
        m_subscriptions.Remove( subscription.ClientHandle );
        m_items.Remove( subscription.ClientHandle );
      }
    }
    #endregion
    #region private
    /// <summary>
    /// Constants used to identify the list view columns.
    /// </summary>
    private const int ITEMID = 0;
    private const int ITEM_PATH = 1;
    private const int VALUE = 2;
    private const int DATATYPE = 3;
    private const int QUALITY = 4;
    private const int TIMESTAMP = 5;
    private const int ERROR = 6;
    /// <summary>
    /// The list view column names.
    /// </summary>
    private readonly string[] ColumnNames = new string[]
		{
			"Item ID",
			"Item Path",
			"Value",
			"Data Type",
			"Quality",
			"Timestamp",
			"Result"
		};
    /// <summary>
    /// A table subscriptions indexed by handle.
    /// </summary>
    private Hashtable m_subscriptions = new Hashtable();
    /// <summary>
    /// A table of list items indexed by subscription.
    /// </summary>
    private Hashtable m_items = new Hashtable();
    /// <summary>
    /// A table of dialog displaying detailed views of an item.
    /// </summary>
    private Hashtable m_viewers = new Hashtable();
    private void subscription_DeleteSubscription( object sender, System.EventArgs e )
    {
      OnSubscriptionModified( (Subscription)sender, true );
    }
    /// <summary>
    /// Called when a data update event is raised by a subscription.
    /// </summary>
    private void OnDataChange( object subscriptionHandle, object requestHandle, OpcDa::ItemValueResult[] values )
    {
      // ensure processing is done on the control's main thread.
      if ( InvokeRequired )
      {
        BeginInvoke( new OpcDa::DataChangedEventHandler( OnDataChange ), new object[] { subscriptionHandle, requestHandle, values } );
        return;
      }
      try
      {
        // find subscription.
        ArrayList existingItemList = (ArrayList)m_items[ subscriptionHandle ];
        // check if subscription is still valid.
        if ( existingItemList == null )
          return;
        // change all existing item values for the subscription to 'grey'.
        // this indicates an update arrived but the value did not change.
        foreach ( ListViewItem listItem in existingItemList )
          if ( listItem.ForeColor != Color.Gray ) { listItem.ForeColor = Color.Gray; }
        // do nothing more if only a keep alive callback.
        if ( values == null || values.Length == 0 )
        {
          OnKeepAlive( subscriptionHandle );
          return;
        }
        if ( UpdateEvent != null )
          UpdateEvent( subscriptionHandle, values );
        // update list view.
        ArrayList newListItems = new ArrayList();
        foreach ( OpcDa::ItemValueResult value in values )
        {
          // item value should never have a null client handle.
          if ( value.ClientHandle == null )
            continue;
          // this item can be updated with new values instead of inserting/removing items.
          ListViewItem replacableItem = null;
          // remove existing items.
          if ( !m_CMS_KeepValues.Checked )
          {
            // search list of existing items for previous values for this item.
            ArrayList updatedItemList = new ArrayList( existingItemList.Count );
            foreach ( ListViewItem listItem in existingItemList )
            {
              OpcDa::ItemValueResult previous = (OpcDa::ItemValueResult)listItem.Tag;
              if ( !value.ClientHandle.Equals( previous.ClientHandle ) )
              {
                updatedItemList.Add( listItem );
                continue;
              }
              if ( replacableItem != null )
              {
                EditComplexValueDlg dialog = (EditComplexValueDlg)m_viewers[ replacableItem ];
                if ( dialog != null )
                {
                  dialog.Close();
                  m_viewers.Remove( replacableItem );
                }
                replacableItem.Remove();
              }
              replacableItem = listItem;
            }
            // the updated list has all values for the current item removed.
            existingItemList = updatedItemList;
          }
          // add value to list.
          AddValue( subscriptionHandle, value, ref replacableItem );
          // save new list item.
          if ( replacableItem != null ) { newListItems.Add( replacableItem ); }
        }
        // add new items to existing item list.
        existingItemList.AddRange( newListItems );
        m_items[ subscriptionHandle ] = existingItemList;
        // adjust column widths.
        for ( int ii = 0; ii < m_ItemListLV.Columns.Count; ii++ )
          if ( ii != VALUE && ii != QUALITY )
            m_ItemListLV.Columns[ ii ].Width = -2;
      }
      catch ( System.Exception e )
      {
        OnException( subscriptionHandle, e );
      }
    }
    /// <summary>
    /// Posts a message when an exception occurs.
    /// </summary>
    private void OnException( object subscription, System.Exception e )
    {
      if ( UpdateEvent != null )
        UpdateEvent( subscription, e.Message );
    }
    /// <summary>
    /// Posts a message when a keep alive callback arrives.
    /// </summary>
    private void OnKeepAlive( object subscription )
    {
      if ( UpdateEvent != null )
      {
        string message = "";
        message += Opc.Convert.ToString( System.DateTime.Now );
        message += "\t";
        message += "Keep alive callback received.";
        UpdateEvent( subscription, message );
      }
    }
    /// <summary>
    /// Sets the columns shown in the list view.
    /// </summary>
    private void SetColumns( string[] columns )
    {
      m_ItemListLV.Clear();
      for ( int ii = 0; ii < columns.Length; ii++ )
      {
        ColumnHeader header = new ColumnHeader();
        header.Text = columns[ ii ];
        //To autosize to the width of the column heading, set the Width property to -2.
        header.Width = ( ii != VALUE && ii != QUALITY ) ? -2 : 120;
        m_ItemListLV.Columns.Add( header );
      }
    }
    /// <summary>
    /// Adds an item to the list view.
    /// </summary>
    /// <param name="subscriptionHandle">The subscription handle.</param>
    /// <param name="item">The item.</param>
    /// <param name="replaceableItem">The replaceable item.</param>
    private void AddValue( object subscriptionHandle, OpcDa::ItemValueResult item, ref ListViewItem replaceableItem )
    {
      string quality = "";
      // format quality.
      if ( item.QualitySpecified )
      {
        quality += item.Quality.QualityBits.ToString();
        if ( item.Quality.LimitBits != OpcDa::limitBits.none )
        {
          quality += ", ";
          quality += item.Quality.LimitBits.ToString();
        }
        if ( item.Quality.VendorBits != 0 )
          quality += System.String.Format( ", {0:X}", item.Quality.VendorBits );
      }
      // format columns.
      string[] columns = new string[]
			{
				item.ItemName,
				item.ItemPath,
				Opc.Convert.ToString(item.Value),
				(item.Value != null)?Opc.Convert.ToString(item.Value.GetType()):"",
				quality,
				(item.TimestampSpecified)?Opc.Convert.ToString(item.Timestamp):"",
				GetErrorText(subscriptionHandle, item.ResultID)
			};
      // update an existing item.
      if ( replaceableItem != null )
      {
        for ( int ii = 0; ii < replaceableItem.SubItems.Count; ii++ )
          replaceableItem.SubItems[ ii ].Text = columns[ ii ];
        replaceableItem.Tag = item;
        replaceableItem.ForeColor = Color.Empty;
        // update detail view dialog.
        EditComplexValueDlg dialog = (EditComplexValueDlg)m_viewers[ replaceableItem ];
        if ( dialog != null )
          dialog.UpdateValue( item.Value );
        return;
      }
      // create a new list view item.
      replaceableItem = new ListViewItem( columns, (int)ImageListLibrary.Icons.IMAGE_TAG );
      replaceableItem.Tag = item;
      // insert after any existing item value with the same client handle.
      for ( int ii = m_ItemListLV.Items.Count - 1; ii >= 0; ii-- )
      {
        OpcDa::ItemValueResult previous = (OpcDa::ItemValueResult)m_ItemListLV.Items[ ii ].Tag;
        if ( previous.ClientHandle != null && previous.ClientHandle.Equals( item.ClientHandle ) )
        {
          m_ItemListLV.Items.Insert( ii + 1, replaceableItem );
          return;
        }
      }
      m_ItemListLV.Items.Add( replaceableItem );
    }
    /// <summary>
    /// Lookups the error text for the specified error id.
    /// </summary>
    private string GetErrorText( object subscriptionHandle, Opc.ResultID resultID )
    {
      if ( m_CMS_ShowErrorText.Checked )
      {
        // display nothing for ok results.
        if ( resultID == Opc.ResultID.S_OK )
          return "";
        // fetch the error text from the server.	
        string errorText = null;
        try
        {
          Subscription subscription = (Subscription)m_subscriptions[ subscriptionHandle ];
          string locale = ( subscription != null ) ? subscription.Locale : CultureInfo.CurrentCulture.Name;
          errorText = subscription.Server.GetErrorText( locale, resultID );
        }
        catch
        {
          errorText = null;
        }
        // return the result;
        return ( errorText != null ) ? errorText : "";
      }
      // return the result id as a string.
      return resultID.ToString();
    }
    /// <summary>
    /// Removes a reference to the detail viewer dialog when it is closed.
    /// </summary>
    private void OnViewerClosed( object sender, System.EventArgs e )
    {
      IDictionaryEnumerator enumerator = m_viewers.GetEnumerator();
      while ( enumerator.MoveNext() )
      {
        if ( enumerator.Value == sender )
        {
          m_viewers.Remove( enumerator.Key );
          break;
        }
      }
    }
    #region Context menu strip item handlers
    /// <summary>
    /// Shows a detailed view for array values.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    //TODO make it visible after implementing complex values.
    private void m_CMS_View_Click( object sender, System.EventArgs e )
    {
      if ( m_ItemListLV.SelectedItems.Count > 0 )
      {
        ListViewItem listItem = m_ItemListLV.SelectedItems[ 0 ];
        object tag = listItem.Tag;
        if ( tag != null && tag.GetType() == typeof( OpcDa::ItemValueResult ) )
        {
          OpcDa::ItemValueResult item = (OpcDa::ItemValueResult)tag;
          if ( item.Value != null )
          {
            ComplexItem complexItem = ComplexTypeCache.GetComplexItem( item );
            if ( complexItem != null )
            {
              EditComplexValueDlg dialog = (EditComplexValueDlg)m_viewers[ listItem ];
              if ( dialog == null )
              {
                m_viewers[ listItem ] = dialog = new EditComplexValueDlg();
                dialog.Disposed += new System.EventHandler( OnViewerClosed );
              }
              dialog.ShowDialog( complexItem, item.Value, true, false );
            }
            else if ( item.Value.GetType().IsArray )
              new EditArrayDlg().ShowDialog( item.Value, true );
          }
        }
      }
    }
    /// <summary>
    /// Clears the contents of the view.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    private void m_CMS_Clear_Click( object sender, System.EventArgs e )
    {
      // clear items.
      m_ItemListLV.Items.Clear();
      // clear subscription item list.
      foreach ( ArrayList items in m_items.Values )
        items.Clear();
    }
    #endregion
    #region Control event handlers
    /// <summary>
    /// Handles the MouseDown event of the m_ItemListLV control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.Windows.Forms.MouseEventArgs"/> instance containing the event data.</param>
    private void m_ItemListLV_MouseDown( object sender, MouseEventArgs e )
    {
      // ignore left button actions.
      if ( e.Button != MouseButtons.Right )
        return;
      // disable everything.
      m_CMS_View.Enabled = false;
      // selects the item that was right clicked on.
      ListViewItem clickedItem = m_ItemListLV.GetItemAt( e.X, e.Y );
      // no item clicked on - do nothing.
      if ( clickedItem == null )
        return;
      // force selection to clicked node.
      clickedItem.Selected = true;
      return;
      //TODO implement complex data and remove above return 
      if ( m_ItemListLV.SelectedItems.Count == 1 )
      {
        if ( clickedItem.Tag != null && clickedItem.Tag.GetType() == typeof( OpcDa::ItemValueResult ) )
        {
          OpcDa::ItemValueResult item = (OpcDa::ItemValueResult)clickedItem.Tag;
          if ( item.Value != null )
            m_CMS_View.Enabled = ( ( ComplexTypeCache.GetComplexItem( item ) != null ) || ( item.Value.GetType().IsArray ) );
        }
      }
    }
    #endregion
    #endregion
  }
}