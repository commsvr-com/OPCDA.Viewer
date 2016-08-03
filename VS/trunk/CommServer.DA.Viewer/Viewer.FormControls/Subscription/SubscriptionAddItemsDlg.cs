//<summary>
//  Title   :  A dialog used to add new items to an existing subscription.
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

namespace CAS.Lib.OPCClientControlsLib
{
  /// <summary>
  /// A dialog used to add new items to an existing subscription.
  /// </summary>
  public class SubscriptionAddItemsDlg: SubscriptionManagementDlg
  {
    #region constructor
    public SubscriptionAddItemsDlg():base()
    {}
    #endregion
    #region public
    #endregion
    #region private
    protected override void ShowDialog( string[] supportedLocales, IOptions options )
    {
      OptionsBTN.Visible = false;
      m_BrowseCTRL.Visible = true;
      base.ShowDialog( supportedLocales, options );
    }
    /// <summary>
    /// Called when the back button is clicked.
    /// </summary>
    protected override void BTN_Back_Click( object sender, EventArgs e )
    {
      UndoAddItems();
    }
    /// <summary>
    /// Called when the next button is clicked.
    /// </summary>
    protected override void BTN_Next_Click( object sender, EventArgs e )
    {
      DoAddItems();
    }
    #endregion
  }
}
