//<summary>
//  Title   : A dialog used to edit the default options for a server or subscription.
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
using System.Windows.Forms;
using CAS.DataPorter.Configurator;
using OpcDa = Opc.Da;
namespace CAS.Lib.OPCClientControlsLib.Common
{
  /// <summary>
  /// A dialog used to edit the default options for a server or subscription.
  /// </summary>
  public partial class OptionsEditDlg: Form
  {
    #region constructor
    /// <summary>
    /// Initializes a new instance of the <see cref="OptionsEditDlg"/> class.
    /// </summary>
    /// <param name="supportedLocales">The supported locales.</param>
    /// <param name="locale">The locale.</param>
    /// <param name="filters">The filters.</param>
    internal OptionsEditDlg()
    {
      InitializeComponent();
    } 
    #endregion
    #region internal
    /// <summary>
    /// Shows the dialog.
    /// </summary>
    /// <param name="supportedLocales">The supported locales.</param>
    /// <param name="options">The options.</param>
    internal void ShowDialog( string[] supportedLocales, IOptions options )
    {
      // init supported locales.
      LocaleCTRL.SetSupportedLocales( supportedLocales );
      // set locale.
      LocaleCTRL.Locale = options.Locale;
      LocaleSpecifiedCB.Checked = !string.IsNullOrEmpty( options.Locale );
      // get filters.
      OpcDa.ResultFilter filters = options.Filter;
      ItemNameCB.Checked = ( ( filters & OpcDa::ResultFilter.ItemName ) != 0 );
      ItemPathCB.Checked = ( ( filters & OpcDa::ResultFilter.ItemPath ) != 0 );
      ClientHandleCB.Checked = ( ( filters & OpcDa::ResultFilter.ClientHandle ) != 0 );
      ItemTimeCB.Checked = ( ( filters & OpcDa::ResultFilter.ItemTime ) != 0 );
      ErrorTextCB.Checked = ( ( filters & OpcDa::ResultFilter.ErrorText ) != 0 );
      DiagnosticInfoCB.Checked = ( ( filters & OpcDa::ResultFilter.DiagnosticInfo ) != 0 );
      ShowDialog();
      if ( DialogResult != DialogResult.OK )
        return;
      if ( LocaleSpecifiedCB.Checked )
        options.Locale = LocaleCTRL.Locale;
      // update filters.
      filters = 0;
      filters |= ( ItemNameCB.Checked ) ? OpcDa::ResultFilter.ItemName : 0;
      filters |= ( ItemPathCB.Checked ) ? OpcDa::ResultFilter.ItemPath : 0;
      filters |= ( ClientHandleCB.Checked ) ? OpcDa::ResultFilter.ClientHandle : 0;
      filters |= ( ItemTimeCB.Checked ) ? OpcDa::ResultFilter.ItemTime : 0;
      filters |= ( ErrorTextCB.Checked ) ? OpcDa::ResultFilter.ErrorText : 0;
      filters |= ( DiagnosticInfoCB.Checked ) ? OpcDa::ResultFilter.DiagnosticInfo : 0;
      options.Filter = filters;
    } 
    #endregion
    #region private
    /// <summary>
    /// Toggles the state of the locale selection control.
    /// </summary>
    private void LocaleSpecifiedCB_CheckedChanged( object sender, System.EventArgs e )
    {
      LocaleCTRL.Enabled = LocaleSpecifiedCB.Checked;
    }
    private void m_TSB_OK_Click( object sender, System.EventArgs e )
    {
      DialogResult = DialogResult.OK;
    }
    private void m_TSM_Cancel_Click( object sender, System.EventArgs e )
    {
      DialogResult = DialogResult.Cancel;
    } 
    #endregion
  }
}
