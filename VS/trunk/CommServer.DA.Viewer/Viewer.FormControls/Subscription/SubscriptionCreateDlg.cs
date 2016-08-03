//<summary>
//  Title   : A dialog used to create a new subscription.
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
using CAS.DataPorter.Configurator;
using OpcDa = global::Opc.Da;

/// <summary>
/// A dialog used to create a new subscription.
/// </summary>
namespace CAS.Lib.OPCClientControlsLib
{

  /// <summary>
  /// A dialog used to create a new subscription.
  /// </summary>
  public class SubscriptionCreateDlg: SubscriptionManagementDlg
  {
    #region constructor
    public SubscriptionCreateDlg()
      : base()
    { }
    #endregion
    #region public

    /// <summary>
    /// The subscription being created <see cref="OpcDa::SubscriptionState"/>.
    /// </summary>
    /// <value>The state of the new subscription.</value>
    internal OpcDa::SubscriptionState State { get; private set; }
    #endregion
    #region private
    protected override void ShowDialog( string[] supportedLocales, IOptions options )
    {
      State = null;
      m_SubscriptionCTRL.Visible = true;
      OptionsBTN.Visible = false;
      m_BrowseCTRL.Visible = false;
      base.ShowDialog( supportedLocales, options );
    }
    /// <summary>
    /// Creates a subscription with the specified parameters.
    /// </summary>
    private void DoCreate()
    {
      // assign a globally unique handle to the subscription.
      State = m_SubscriptionCTRL.Get();
      State.ClientHandle = Guid.NewGuid().ToString();
      // move to add items panel.
      BackBTN.Enabled = true;
      NextBTN.Visible = true;
      OptionsBTN.Visible = true;
      m_SubscriptionCTRL.Visible = false;
      m_BrowseCTRL.Visible = true;
      m_ItemsCTRL.Visible = true;
      m_ResultsCTRL.Visible = false;
    }
    /// <summary>
    /// Removes a previously created subscription.
    /// </summary>
    private void UndoCreate()
    {
      BackBTN.Enabled = false;
      NextBTN.Visible = true;
      CancelBTN.Visible = true;
      DoneBTN.Visible = false;
      OptionsBTN.Visible = false;
      m_BrowseCTRL.Visible = false;
      m_ItemsCTRL.Visible = true;
      m_ResultsCTRL.Visible = false;
      State = null;
      m_SubscriptionCTRL.Visible = true;
    }
    /// <summary>
    /// Adds a set of items to a subscription.
    /// </summary>
    protected override void DoAddItems()
    {
      base.DoAddItems();
      m_SubscriptionCTRL.Set( State );
      m_SubscriptionCTRL.Visible = true;
    }
    /// <summary>
    /// Removes a previously added items from a subscription.
    /// </summary>
    protected override void UndoAddItems()
    {
      base.UndoAddItems();
      BackBTN.Enabled = true;
      m_SubscriptionCTRL.Visible = false;
    }
    #region buttons click hndlers
    /// <summary>
    /// Called when the back button is clicked.
    /// </summary>
    protected override void BTN_Back_Click( object sender, System.EventArgs e )
    {
      if ( GetItems != null ) { UndoAddItems(); return; }
      if ( State != null ) { UndoCreate(); return; }
    }
    /// <summary>
    /// Called when the next button is clicked.
    /// </summary>
    protected override void BTN_Next_Click( object sender, System.EventArgs e )
    {
      if ( State == null ) { DoCreate(); return; }
      if ( GetItems == null ) { DoAddItems(); return; }
    }
    /// <summary>
    /// Handles the Click event of the Cancel button.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    protected override void CancelBTN_Click( object sender, EventArgs e )
    {
      State = null;
      base.CancelBTN_Click( sender, e );
    }
    #endregion
    #endregion
  }
}
