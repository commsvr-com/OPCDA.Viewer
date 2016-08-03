//<summary>
//  Title   : Select Server Strip
//  System  : Microsoft Visual C# .NET 2008
//  $LastChangedDate$
//  $Rev$
//  $LastChangedBy$
//  $URL$
//  $Id$
//
//  Copyright (C)2008, CAS LODZ POLAND.
//  TEL: +48 (42) 686 25 47
//  mailto:\\techsupp@cas.com.pl
//  http:\\www.cas.eu
//</summary>
using System;
using System.Collections;
using System.Diagnostics;
using System.Windows.Forms;
using Opc;
namespace CAS.Lib.OPCClientControlsLib
{
  /// <summary>
  /// Use to receive notifications when a the connect server button is clicked.
  /// </summary>
  public delegate void ConnectServer_EventHandler( Server server );
  /// <summary>
  /// Select Server Strip
  /// </summary>
  public class SelectServerStrip: ToolStrip
  {
    #region private
    private class EndOfList
    {
      public override string ToString()
      {
        return "<Browse...>";
      }
    }
    private ToolStripLabel m_TSL_ServerUrl;
    private ToolStripComboBox m_TSCB_ServerUrl;
    private ToolStripButton m_TSB_SearchNetwork;
    private ToolStripDropDownButton m_TSDDB_Specification;
    private ToolStripButton m_TSB_ClearHistory;
    private ToolStripButton m_TSB_Add;
    private void InitializeComponent()
    {
      System.Windows.Forms.ToolStripLabel toolStripLabel2;
      System.Windows.Forms.ToolStripSeparator m_TS_Separator;
      this.m_TSL_ServerUrl = new System.Windows.Forms.ToolStripLabel();
      this.m_TSCB_ServerUrl = new System.Windows.Forms.ToolStripComboBox();
      this.m_TSB_Add = new System.Windows.Forms.ToolStripButton();
      this.m_TSB_SearchNetwork = new System.Windows.Forms.ToolStripButton();
      this.m_TSDDB_Specification = new System.Windows.Forms.ToolStripDropDownButton();
      this.m_TSB_ClearHistory = new System.Windows.Forms.ToolStripButton();
      toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
      m_TS_Separator = new System.Windows.Forms.ToolStripSeparator();
      this.SuspendLayout();
      // 
      // toolStripLabel2
      // 
      toolStripLabel2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
      toolStripLabel2.Name = "toolStripLabel2";
      toolStripLabel2.Size = new System.Drawing.Size( 37, 13 );
      toolStripLabel2.Text = "Prefer";
      toolStripLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      toolStripLabel2.ToolTipText = "Force connection using the preferred specification. ";
      // 
      // m_TS_Separator
      // 
      m_TS_Separator.Name = "m_TS_Separator";
      m_TS_Separator.Size = new System.Drawing.Size( 6, 6 );
      // 
      // m_TSL_ServerUrl
      // 
      this.m_TSL_ServerUrl.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
      this.m_TSL_ServerUrl.Name = "m_TSL_ServerUrl";
      this.m_TSL_ServerUrl.Size = new System.Drawing.Size( 39, 22 );
      this.m_TSL_ServerUrl.Text = "Server";
      this.m_TSL_ServerUrl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.m_TSL_ServerUrl.ToolTipText = "Server URL";
      // 
      // m_TSCB_ServerUrl
      // 
      this.m_TSCB_ServerUrl.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
      this.m_TSCB_ServerUrl.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.HistoryList;
      this.m_TSCB_ServerUrl.AutoToolTip = true;
      this.m_TSCB_ServerUrl.Name = "m_TSCB_ServerUrl";
      this.m_TSCB_ServerUrl.Size = new System.Drawing.Size( 500, 21 );
      this.m_TSCB_ServerUrl.ToolTipText = "Server URL";
      // 
      // m_TSB_Add
      // 
      this.m_TSB_Add.AutoToolTip = false;
      this.m_TSB_Add.Image = global::CAS.Lib.OPCClientControlsLib.ImagesResources.serwer_opc_48;
      this.m_TSB_Add.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.m_TSB_Add.Name = "m_TSB_Add";
      this.m_TSB_Add.Size = new System.Drawing.Size( 46, 20 );
      this.m_TSB_Add.Text = "Add";
      this.m_TSB_Add.ToolTipText = "Add server to the session panel";
      // 
      // m_TSB_SearchNetwork
      // 
      this.m_TSB_SearchNetwork.AutoToolTip = false;
      this.m_TSB_SearchNetwork.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.m_TSB_SearchNetwork.Image = global::CAS.Lib.OPCClientControlsLib.ImagesResources.Network_ConnectTo;
      this.m_TSB_SearchNetwork.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.m_TSB_SearchNetwork.Name = "m_TSB_SearchNetwork";
      this.m_TSB_SearchNetwork.Size = new System.Drawing.Size( 23, 20 );
      this.m_TSB_SearchNetwork.Text = "Search";
      this.m_TSB_SearchNetwork.ToolTipText = "Browse network";
      // 
      // m_TSDDB_Specification
      // 
      this.m_TSDDB_Specification.AutoSize = false;
      this.m_TSDDB_Specification.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
      this.m_TSDDB_Specification.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.m_TSDDB_Specification.Name = "m_TSDDB_Specification";
      this.m_TSDDB_Specification.Size = new System.Drawing.Size( 150, 20 );
      this.m_TSDDB_Specification.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.m_TSDDB_Specification.ToolTipText = "Force connection using the preferred specification. ";
      // 
      // m_TSB_ClearHistory
      // 
      this.m_TSB_ClearHistory.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.m_TSB_ClearHistory.Image = global::CAS.Lib.OPCClientControlsLib.ImagesResources.delete;
      this.m_TSB_ClearHistory.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.m_TSB_ClearHistory.Name = "m_TSB_ClearHistory";
      this.m_TSB_ClearHistory.Size = new System.Drawing.Size( 23, 20 );
      this.m_TSB_ClearHistory.Text = "Clear";
      this.m_TSB_ClearHistory.ToolTipText = "Clear list of known URLs";
      // 
      // SelectServerStrip
      // 
      this.Items.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.m_TSL_ServerUrl,
            this.m_TSCB_ServerUrl,
            this.m_TSB_ClearHistory,
            toolStripLabel2,
            this.m_TSDDB_Specification,
            this.m_TSB_Add,
            m_TS_Separator,
            this.m_TSB_SearchNetwork} );
      this.ResumeLayout( false );

    }
    private void AddTSDDB_Specification( Specification spec )
    {
      ToolStripMenuItem item = new ToolStripMenuItem( spec.ToString() );
      item.Tag = spec;
      item.Click += new EventHandler( item_Click );
      m_TSDDB_Specification.DropDownItems.Add( item );
    }
    /// <summary>
    /// Gets the specification.
    /// </summary>
    /// <returns></returns>
    private Specification GetSpecification()
    {
      return (Specification)m_TSDDB_Specification.Tag;
    }
    /// <summary>
    /// Adds/selects the specified server in the combo box.
    /// </summary>
    private void AddServerURL( URL url )
    {
      if ( url == null )
        throw new ArgumentNullException( "URL cannot be null" );
      // check if the server url already exists.
      int index = m_TSCB_ServerUrl.FindStringExact( url.ToString() );
      // add url if it does not exist.
      if ( index == -1 )
      {
        index = 1;
        m_TSCB_ServerUrl.Items.Insert( index, url );
      }
      // select the new url.
      m_TSCB_ServerUrl.SelectedIndex = index;
    }
    /// <summary>
    /// Shows the message.
    /// </summary>
    /// <param name="mssg">The message.</param>
    private static void ShowMessage( string mssg )
    {
      MessageBox.Show( mssg, Properties.Resources.MessageBox_ConnectStrip, MessageBoxButtons.OK, MessageBoxIcon.Error );
    }
    private void ClearURLComboBox()
    {
      // clear the existing items.
      m_TSCB_ServerUrl.Items.Clear();
      // add a 'special' item that shows the browse servers dialog.
      m_TSCB_ServerUrl.Items.Add( new EndOfList() );
      m_TSCB_ServerUrl.SelectedIndex = 0;
    }
    #endregion
    #region public
    #region events
    /// <summary>
    /// Called when the connect buton is pressed and there is valid address selected.
    /// </summary>
    public event ConnectServer_EventHandler ServerSelectedEvent;

    #endregion
    /// <summary>
    /// The label displayed in the control.
    /// Property used by development environment.
    /// </summary>
    /// <value>The label.</value>
    public string Label
    {
      get { return m_TSL_ServerUrl.Text; }
      set { m_TSL_ServerUrl.Text = value; }
    }
    /// <summary>
    /// Returns the set of known urls.
    /// </summary>
    public URL[] GetKnownURLs( out int selectedUrl )
    {
      selectedUrl = -1;
      ArrayList knownUrls = new ArrayList();
      foreach ( object url in m_TSCB_ServerUrl.Items )
      {
        if ( url.GetType() == typeof( URL ) )
        {
          if ( url.Equals( m_TSCB_ServerUrl.SelectedItem ) )
            selectedUrl = knownUrls.Count;
          knownUrls.Add( url );
        }
      }
      return (URL[])knownUrls.ToArray( typeof( URL ) );
    }
    /// <summary>
    /// Initializes the control with a set of known urls.
    /// </summary>
    /// <param name="knownUrls">The known urls.</param>
    /// <param name="selectedIndex">Index of the selected URL.</param>
    /// <param name="specification">The specification.</param>
    public void Initialize( URL[] knownUrls, int selectedIndex, Specification specification )
    {
      ClearURLComboBox();
      // add known urls.
      if ( knownUrls != null && knownUrls.Length > 0 )
        m_TSCB_ServerUrl.Items.AddRange( knownUrls );
      // update the selection.
      Debug.Assert( selectedIndex <= m_TSCB_ServerUrl.Items.Count - 1 );
      m_TSCB_ServerUrl.SelectedIndex = ( selectedIndex != -1 ) ? selectedIndex : 0;
      //add specifications
      m_TSDDB_Specification.DropDownItems.Clear();
      m_TSDDB_Specification.Text = specification.ToString();
      m_TSDDB_Specification.Tag = specification;
      foreach ( Specification spec in Specification.SpecificationsList )
        AddTSDDB_Specification( spec );
    }
    /// <summary>
    /// Gets a server.
    /// </summary>
    /// <value>The get server.</value>
    public Server GetServer
    {
      get
      {
        try
        {
          //get the url from the selection.
          object selection = m_TSCB_ServerUrl.SelectedItem;
          URL url;
          if ( selection == null )
            try
            {
              if ( m_TSCB_ServerUrl.Text.Length < 6 )
              {
                ShowMessage( Properties.Resources.MesageBox_URLError );
                return null;
              }
              url = new URL( m_TSCB_ServerUrl.Text.Trim() );
              AddServerURL( url );
            }
            catch ( Exception ex )
            {
              string mssg = String.Format( Properties.Resources.MesageBox_URLError, ex.Message );
              ShowMessage( mssg );
              return null;
            }
          else if ( selection.GetType() == typeof( EndOfList ) )
            return SearchNetwork();
          else
          {
            Debug.Assert( selection.GetType() == typeof( URL ) );
            url = (URL)selection;
          }
          // create an unconnected server object.
          return CAS.Lib.OPCClientControlsLib.Factory.GetServerForURL( url, GetSpecification() );
          // invoke the connect server callback.
        }
        catch ( Exception )
        {
          m_TSCB_ServerUrl.SelectedItem = null;
        }
        return null;
      }
    }
    /// <summary>
    /// Searches the network.
    /// </summary>
    public Server SearchNetwork()
    {
      Cursor myPreviousCursor = this.Cursor;
      this.Cursor = Cursors.WaitCursor;
      try
      {
        using ( SelectServerDlg dial = new SelectServerDlg() )
        {
          Server svr = dial.ShowDialog( GetSpecification() );
          if ( svr == null )
            return null;
          AddServerURL( svr.Url );
          return svr;
        }
      }
      catch ( Exception ex )
      {
        MessageBox.Show( this, ex.Message, "Browse Network", MessageBoxButtons.OK, MessageBoxIcon.Warning );
      }
      finally
      {
        this.Cursor = myPreviousCursor;
      }
      return null;
    }
    /// <summary>
    /// Initializes a new instance of the <see cref="SelectServerStrip"/> class.
    /// </summary>
    public SelectServerStrip()
      : base()
    {
      InitializeComponent();
      m_TSB_Add.Click += new EventHandler( TSB_Connect_Click );
      m_TSB_SearchNetwork.Click += new EventHandler( TSB_SearchNetwork_Click );
      m_TSB_ClearHistory.Click += new EventHandler( TSB_ClearHistory_Click );
    }
    #endregion
    #region private handlers
    private void RaiseServerSelectedEvent( Server server )
    {
      if ( ServerSelectedEvent == null || server == null )
        return;
      ServerSelectedEvent( server );
    }
    private void TSB_ClearHistory_Click( object sender, EventArgs e )
    {
      ClearURLComboBox();
    }
    /// <summary>
    /// Connects to the server and raises an event if successful.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    private void TSB_Connect_Click( object sender, EventArgs e )
    {
      if ( this.DesignMode )
        return;
      RaiseServerSelectedEvent( GetServer );
    }
    /// <summary>
    /// Handles the Click event of the tSBSearchNetwork control.
    /// Searches the network to select a server.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    private void TSB_SearchNetwork_Click( object sender, EventArgs e )
    {
      // signal selection of a server.
      RaiseServerSelectedEvent( SearchNetwork() );
    }
    /// <summary>
    /// Handles the Click event of the <see cref="ToolStripMenuItem"/> control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    void item_Click( object sender, EventArgs e )
    {
      ToolStripMenuItem item = sender as ToolStripMenuItem;
      m_TSDDB_Specification.Text = item.Text;
      m_TSDDB_Specification.Tag = item.Tag;
    }
    #endregion
  }
}
