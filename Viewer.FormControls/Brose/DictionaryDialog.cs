//<summary>
//  Title   : Dictionary Management Dialog 
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
using CAS.Lib.OPCClient.Da;
using OpcDa = global::Opc.Da;

namespace CAS.Lib.OPCClientControlsLib
{
  /// <summary>
  /// Dictionary Management Dialog 
  /// </summary>
  public partial class DictionaryDialog: Form
  {
    #region public
    /// <summary>
    /// Opens the dioctionary dialog.
    /// </summary>
    /// <param name="server">The server.</param>
    /// <param name="filters">The filters.</param>
    public static void OpenDioctionaryDialog( Server server, OpcDa::BrowseFilters filters )
    {
      if ( server == null )
        return;
      using ( DictionaryDialog dic = new DictionaryDialog() )
      {
        if ( filters == null )
        {
          filters = new OpcDa::BrowseFilters();
          filters.ReturnAllProperties = true;
          filters.ReturnPropertyValues = true;
        }
        dic.ShowSingleServer( server, filters );
        dic.ShowDialog();
        dic.m_BrowseTreeCtrl.Clear();
      }
    }
    /// <summary>
    /// Opens the dioctionary dialog.
    /// </summary>
    public static void OpenDioctionaryDialog()
    {
      using ( DictionaryDialog dic = new DictionaryDialog() )
      {
        if ( !dic.OnOpenDictionary() )
          return;
        dic.ShowDialog();
        dic.m_BrowseTreeCtrl.Clear();
      }
    }
    #endregion
    #region private
    private void ShowSingleServer( Server server, OpcDa::BrowseFilters filters )
    {
      m_PropertiesCTRL.Initialize( null );
      m_Dictionary.DefaultFileName = server.Name;
      m_BrowseTreeCtrl.ShowSingleServer( server, filters, false );
    }
    private bool OnOpenDictionary()
    {
      if ( !m_Dictionary.Open() )
        return false;
      m_PropertiesCTRL.Initialize( null );
      m_BrowseTreeCtrl.ShowSingleServer( m_Dictionary.Dictionary, null, false );
      return true;
    }
    #region cnstructor
    public DictionaryDialog()
    {
      InitializeComponent();
      m_BrowseTreeCtrl.ElementSelected += new ElementSelected_EventHandler( OnElementSelected );
      m_BrowseTreeCtrl.ItemPicked += new ItemPicked_EventHandler( BrowseCTRL_ItemPicked );
      m_BrowseTreeCtrl.ContextMenuStrip = m_Dictionary.ContextMenuStrip;
    }
    #endregion
    #region event handlers
    private void OnElementSelected( OpcDa::BrowseElement element )
    {
      m_PropertiesCTRL.Initialize( element );
    }
    /// <summary>
    /// Called when an item is explicitly picked.
    /// </summary>
    private void BrowseCTRL_ItemPicked( Opc.ItemIdentifier itemID )
    {
      //m_itemID = itemID;
    }
    #endregion
    #region button events handlers
    private void m_TSB_Save_Click( object sender, EventArgs e )
    {
      m_BrowseTreeCtrl.ExportDictionary( m_Dictionary.Dictionary );
      m_Dictionary.Save( false );
    }
    private void m_TSB_SaveAs_Click( object sender, EventArgs e )
    {
      m_BrowseTreeCtrl.ExportDictionary( m_Dictionary.Dictionary );
      m_Dictionary.Save( true );
    }
    private void m_TSB_OpenDictionary_Click( object sender, EventArgs e )
    {
      OnOpenDictionary();
    }
    private void m_TSB_Cancel_Click( object sender, EventArgs e )
    {
      DialogResult = DialogResult.Cancel;
    }
    private void m_TSB_Connect_Click( object sender, EventArgs e )
    {
      Server svr = null;
      using ( SelectServerDlg dial = new SelectServerDlg() )
        svr = (Server)dial.ShowDialog( Opc.Specification.COM_DA_30 );
      if ( svr == null )
        return;
      m_Dictionary.DefaultFileName = svr.Name;
      ShowSingleServer( svr, null );
    }
    /// <summary>
    /// Handles the HelpButtonClicked event of the DictionaryDialog control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.ComponentModel.CancelEventArgs"/> instance containing the event data.</param>
    private void DictionaryDialog_HelpButtonClicked( object sender, System.ComponentModel.CancelEventArgs e )
    {
      System.Diagnostics.Process.Start( Properties.Resources.Help_Default );
      //TODO change link to Dictionary descryption when added
    }
    #endregion

    
    #endregion
  }
}
