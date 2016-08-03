//<summary>
//  Title   : A dialog used to edit a new subscription.
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
using CAS.DataPorter.Configurator;
using OpcDa = global::Opc.Da;

/// <summary>
/// A dialog used to create a new subscription.
/// </summary>
namespace CAS.Lib.OPCClientControlsLib
{
  using OPCClient.Da;

  /// <summary>
  /// A dialog used to create a new subscription.
  /// </summary>
  public abstract partial class SubscriptionManagementDlg: Form, IOptions
  {
    #region constructor
    public SubscriptionManagementDlg()
    {
      InitializeComponent();
      m_SubscriptionCTRL.Visible = false;
      m_BrowseCTRL.ItemPicked += new ItemPicked_EventHandler( OnItemPicked );
    }
    #endregion
    #region public
    /// <summary>
    /// Prompts a user to create a new subscription with a modal dialog.
    /// </summary>
    /// <param name="server">The server.</param>
    /// <param name="filters">The filters.</param>
    /// <param name="supportedLocales">The supported locales.</param>
    /// <param name="options">The options.</param>
    public void ShowDialog( Server server, OpcDa::BrowseFilters filters, string[] supportedLocales, IOptions options )
    {
      if ( server == null )
        throw new ArgumentNullException( "server" );
      if ( server.IsConnected )
        m_BrowseCTRL.ShowSingleServer( (Server)server.Duplicate(), (OpcDa::BrowseFilters)filters.Clone(), true );
      else
      {
        m_Dictionary.DefaultFileName = server.Name;
        if ( !m_Dictionary.Open() )
          return;
        if ( m_Dictionary.Dictionary.ServersTable.Count > 0 )
          supportedLocales = m_Dictionary.Dictionary.ServersTable[ 0 ].Locales;
        m_BrowseCTRL.ShowSingleServer( m_Dictionary.Dictionary, filters, true );
      }
      ShowDialog( supportedLocales, options );
    }
    /// <summary>
    /// Gets or sets the collection of selected items.
    /// </summary>
    /// <value>The collection of items items <see cref="global::Opc.Da.Item"/>.</value>
    internal global::Opc.Da.Item[] GetItems { get; private set; }
    #region IOptions Members
    /// <summary>
    /// Gets or sets the filter <see cref="Opc.Da.ResultFilter"/>. Filters are
    /// applied by the server before returning item results.
    /// </summary>
    /// <value>The filter.</value>
    public OpcDa.ResultFilter Filter { get; set; }
    /// <summary>
    /// Gets or sets the locale. The locale is used for any error
    /// messages or results returned to the client.
    /// </summary>
    /// <value>The locale.</value>
    public string Locale { get; set; }
    #endregion
    #endregion
    #region private
    protected string[] m_supportedLocales = null;
    protected virtual void ShowDialog( string[] supportedLocales, IOptions options )
    {
      m_supportedLocales = supportedLocales;
      if ( options != null )
      {
        Locale = options.Locale;
        Filter = options.Filter;
      }
      else
      {
        Locale = null;
        Filter = OpcDa.ResultFilter.Minimal;
      }
      GetItems = null;
      BackBTN.Enabled = false;
      NextBTN.Visible = true;
      CancelBTN.Visible = true;
      DoneBTN.Visible = false;
      m_ItemsCTRL.Visible = true;
      m_ResultsCTRL.Visible = false;
      m_SubscriptionCTRL.Initialize( supportedLocales, Locale );
      m_SubscriptionCTRL.Set( null );
      m_ItemsCTRL.Initialize( null );
      ShowDialog();
      // ensure server connection in the browse control are closed.
      m_BrowseCTRL.Clear();
    }
    /// <summary>
    /// Adds a set of items to a subscription.
    /// </summary>
    protected virtual void DoAddItems()
    {
      // assign globally unique client handle.
      OpcDa.Item[] items = m_ItemsCTRL.GetItems();
      OpcDa.ItemResult[] results = new OpcDa.ItemResult[ items.Length ];
      for ( int ix = 0; ix < items.Length; ix++ )
      {
        items[ ix ].ClientHandle = Guid.NewGuid();
        results[ ix ] = new global::Opc.Da.ItemResult( items[ ix ] );
        results[ ix ].ResultID = Opc.ResultID.S_OK;
      }
      GetItems = items;
      // move to add items panel.
      BackBTN.Enabled = true;
      NextBTN.Visible = false;
      DoneBTN.Visible = true;
      OptionsBTN.Visible = false;
      m_BrowseCTRL.Visible = false;
      m_ItemsCTRL.Visible = false;
      m_ResultsCTRL.Visible = true;
      // update controls with actual values.
      m_ResultsCTRL.Initialize( results );
    }
    /// <summary>
    /// Removes a previously added items from a subscription.
    /// </summary>
    protected virtual void UndoAddItems()
    {
      GetItems = null;
      // move to add items panel.
      BackBTN.Enabled = false;
      NextBTN.Visible = true;
      DoneBTN.Visible = false;
      OptionsBTN.Visible = true;
      m_BrowseCTRL.Visible = true;
      m_ItemsCTRL.Visible = true;
      m_ResultsCTRL.Visible = false;
    }
    /// <summary>
    /// Called when an item <see cref="ItemIdentifier"/> is picked in the browse control.
    /// </summary>
    /// <param name="itemID">The item ID <see cref="ItemIdentifier"/>.</param>
    private void OnItemPicked( Opc.ItemIdentifier itemID )
    {
      m_ItemsCTRL.AddItem( new OpcDa::Item( itemID ) );
    }

    #region buttons click hndlers
    /// <summary>
    /// Called when the back button is clicked.
    /// </summary>
    protected abstract void BTN_Back_Click( object sender, System.EventArgs e );
    /// <summary>
    /// Called when the next button is clicked.
    /// </summary>
    protected abstract void BTN_Next_Click( object sender, System.EventArgs e );
    /// <summary>
    /// Called when the Done button is clicked.
    /// </summary>
    protected virtual void BTN_Done_Click( object sender, System.EventArgs e )
    {
      DialogResult = DialogResult.OK;
    }
    /// <summary>
    /// Handles the Click event of the Cancel button.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    protected virtual void CancelBTN_Click( object sender, EventArgs e )
    {
      GetItems = null;
      DialogResult = DialogResult.Cancel;
    }
    /// <summary>
    /// Updates the result filters used for the request.
    /// </summary>
    protected virtual void BTN_Options_Click( object sender, System.EventArgs e )
    {
      //TODO implement parameters - have to be taken from server or dictionary
      using ( var dial = new Common.OptionsEditDlg() )
        dial.ShowDialog( m_supportedLocales, this );
    }

    /// <summary>
    /// Handles the HelpButtonClicked event of the SubscriptionManagementDlg control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.ComponentModel.CancelEventArgs"/> instance containing the event data.</param>
    private void SubscriptionManagementDlg_HelpButtonClicked( object sender, System.ComponentModel.CancelEventArgs e )
    {
      System.Diagnostics.Process.Start( Properties.Resources.Help_CreateSubscription );
    }
    #endregion

    
    #endregion
  }
}
