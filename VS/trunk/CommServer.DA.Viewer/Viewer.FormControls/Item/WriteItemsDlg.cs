//<summary>
//  Title   : A dialog used select items for a write request and then display the results.
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

//============================================================================
// TITLE: WriteItemsDlg.cs
//
// CONTENTS:
// 
// A dialog used select items for a write request and then display the results.
//
// (c) Copyright 2003 The OPC Foundation
// ALL RIGHTS RESERVED.
//
// DISCLAIMER:
//  This code is provided by the OPC Foundation solely to assist in 
//  understanding and use of the appropriate OPC Specification(s) and may be 
//  used as set forth in the License Grant section of the OPC Specification.
//  This code is provided as-is and without warranty or support of any sort
//  and is subject to the Warranty and Liability Disclaimers which appear
//  in the printed OPC Specification.
//
// MODIFICATION LOG:
//
// Date       By    Notes
// ---------- ---   -----
// 2003/06/11 RSA   Initial implementation.

using System;
using System.Collections;
using System.Windows.Forms;
using CAS.DataPorter.Configurator;
using CAS.Lib.OPCClient.Da;
using CAS.Lib.OPCClientControlsLib.Common;
using OpcDa = global::Opc.Da;

namespace CAS.Lib.OPCClientControlsLib
{
  /// <summary>
  /// A dialog used select items for a write request and then display the results.
  /// </summary>
  public class WriteItemsDlg: System.Windows.Forms.Form, IOptions
  {
    #region privte fields
    private CAS.Lib.OPCClientControlsLib.BrowseTreeCtrl BrowseCTRL;
    private CAS.Lib.OPCClientControlsLib.ResultListViewCtrl ResultsCTRL;
    private CAS.Lib.OPCClientControlsLib.ItemValueListEditCtrl ItemsCTRL;
    private System.Windows.Forms.Panel LeftPN;
    private System.Windows.Forms.Panel RightPN;
    private System.Windows.Forms.Panel ButtonsPN;
    private System.Windows.Forms.Button CancelBTN;
    private System.Windows.Forms.Button BackBTN;
    private System.Windows.Forms.Button NextBTN;
    private System.Windows.Forms.Button DoneBTN;
    private System.Windows.Forms.Splitter SplitterV;
    private CAS.Lib.OPCClientControlsLib.Subscriptions4RWControl SubscriptionCTRL;
    private System.Windows.Forms.Button OptionsBTN;
    #endregion
    private System.ComponentModel.IContainer components;
    #region constructor
    public WriteItemsDlg()
    {
      InitializeComponent();
      BrowseCTRL.ItemPicked += new ItemPicked_EventHandler( OnItemPicked );
    }
    #endregion
    #region IDisposable
    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    protected override void Dispose( bool disposing )
    {
      if ( disposing )
      {
        if ( components != null )
        {
          components.Dispose();
        }
      }

      base.Dispose( disposing );
    }
    #endregion
    #region Windows Form Designer generated code
    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( WriteItemsDlg ) );
      this.BrowseCTRL = new CAS.Lib.OPCClientControlsLib.BrowseTreeCtrl();
      this.LeftPN = new System.Windows.Forms.Panel();
      this.SubscriptionCTRL = new CAS.Lib.OPCClientControlsLib.Subscriptions4RWControl();
      this.ItemsCTRL = new CAS.Lib.OPCClientControlsLib.ItemValueListEditCtrl();
      this.RightPN = new System.Windows.Forms.Panel();
      this.ResultsCTRL = new CAS.Lib.OPCClientControlsLib.ResultListViewCtrl();
      this.ButtonsPN = new System.Windows.Forms.Panel();
      this.OptionsBTN = new System.Windows.Forms.Button();
      this.BackBTN = new System.Windows.Forms.Button();
      this.NextBTN = new System.Windows.Forms.Button();
      this.CancelBTN = new System.Windows.Forms.Button();
      this.DoneBTN = new System.Windows.Forms.Button();
      this.SplitterV = new System.Windows.Forms.Splitter();
      this.LeftPN.SuspendLayout();
      this.RightPN.SuspendLayout();
      this.ButtonsPN.SuspendLayout();
      this.SuspendLayout();
      // 
      // BrowseCTRL
      // 
      this.BrowseCTRL.Dock = System.Windows.Forms.DockStyle.Fill;
      this.BrowseCTRL.Location = new System.Drawing.Point( 4, 4 );
      this.BrowseCTRL.Name = "BrowseCTRL";
      this.BrowseCTRL.Size = new System.Drawing.Size( 246, 296 );
      this.BrowseCTRL.TabIndex = 1;
      // 
      // LeftPN
      // 
      this.LeftPN.Controls.Add( this.SubscriptionCTRL );
      this.LeftPN.Controls.Add( this.BrowseCTRL );
      this.LeftPN.Dock = System.Windows.Forms.DockStyle.Left;
      this.LeftPN.Location = new System.Drawing.Point( 0, 0 );
      this.LeftPN.Name = "LeftPN";
      this.LeftPN.Padding = new System.Windows.Forms.Padding( 4, 4, 0, 0 );
      this.LeftPN.Size = new System.Drawing.Size( 250, 300 );
      this.LeftPN.TabIndex = 6;
      // 
      // SubscriptionCTRL
      // 
      this.SubscriptionCTRL.Dock = System.Windows.Forms.DockStyle.Fill;
      this.SubscriptionCTRL.Location = new System.Drawing.Point( 4, 4 );
      this.SubscriptionCTRL.Name = "SubscriptionCTRL";
      this.SubscriptionCTRL.Size = new System.Drawing.Size( 246, 296 );
      this.SubscriptionCTRL.TabIndex = 2;
      // 
      // ItemsCTRL
      // 
      this.ItemsCTRL.Dock = System.Windows.Forms.DockStyle.Fill;
      this.ItemsCTRL.Location = new System.Drawing.Point( 0, 4 );
      this.ItemsCTRL.Name = "ItemsCTRL";
      this.ItemsCTRL.Size = new System.Drawing.Size( 534, 296 );
      this.ItemsCTRL.TabIndex = 7;
      // 
      // RightPN
      // 
      this.RightPN.Controls.Add( this.ItemsCTRL );
      this.RightPN.Controls.Add( this.ResultsCTRL );
      this.RightPN.Dock = System.Windows.Forms.DockStyle.Fill;
      this.RightPN.Location = new System.Drawing.Point( 254, 0 );
      this.RightPN.Name = "RightPN";
      this.RightPN.Padding = new System.Windows.Forms.Padding( 0, 4, 4, 0 );
      this.RightPN.Size = new System.Drawing.Size( 538, 300 );
      this.RightPN.TabIndex = 8;
      // 
      // ResultsCTRL
      // 
      this.ResultsCTRL.AllowDrop = true;
      this.ResultsCTRL.Dock = System.Windows.Forms.DockStyle.Fill;
      this.ResultsCTRL.Location = new System.Drawing.Point( 0, 4 );
      this.ResultsCTRL.Name = "ResultsCTRL";
      this.ResultsCTRL.Size = new System.Drawing.Size( 534, 296 );
      this.ResultsCTRL.TabIndex = 0;
      // 
      // ButtonsPN
      // 
      this.ButtonsPN.Controls.Add( this.OptionsBTN );
      this.ButtonsPN.Controls.Add( this.BackBTN );
      this.ButtonsPN.Controls.Add( this.NextBTN );
      this.ButtonsPN.Controls.Add( this.CancelBTN );
      this.ButtonsPN.Controls.Add( this.DoneBTN );
      this.ButtonsPN.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.ButtonsPN.Location = new System.Drawing.Point( 0, 300 );
      this.ButtonsPN.Name = "ButtonsPN";
      this.ButtonsPN.Size = new System.Drawing.Size( 792, 36 );
      this.ButtonsPN.TabIndex = 9;
      // 
      // OptionsBTN
      // 
      this.OptionsBTN.Location = new System.Drawing.Point( 5, 8 );
      this.OptionsBTN.Name = "OptionsBTN";
      this.OptionsBTN.Size = new System.Drawing.Size( 75, 23 );
      this.OptionsBTN.TabIndex = 7;
      this.OptionsBTN.Text = "Options...";
      this.OptionsBTN.Click += new System.EventHandler( this.OptionsBTN_Click );
      // 
      // BackBTN
      // 
      this.BackBTN.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
      this.BackBTN.Location = new System.Drawing.Point( 552, 8 );
      this.BackBTN.Name = "BackBTN";
      this.BackBTN.Size = new System.Drawing.Size( 75, 23 );
      this.BackBTN.TabIndex = 3;
      this.BackBTN.Text = "< Back";
      this.BackBTN.Click += new System.EventHandler( this.BackBTN_Click );
      // 
      // NextBTN
      // 
      this.NextBTN.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
      this.NextBTN.Location = new System.Drawing.Point( 632, 8 );
      this.NextBTN.Name = "NextBTN";
      this.NextBTN.Size = new System.Drawing.Size( 75, 23 );
      this.NextBTN.TabIndex = 2;
      this.NextBTN.Text = "Next >";
      this.NextBTN.Click += new System.EventHandler( this.NextBTN_Click );
      // 
      // CancelBTN
      // 
      this.CancelBTN.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
      this.CancelBTN.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.CancelBTN.Location = new System.Drawing.Point( 712, 8 );
      this.CancelBTN.Name = "CancelBTN";
      this.CancelBTN.Size = new System.Drawing.Size( 75, 23 );
      this.CancelBTN.TabIndex = 5;
      this.CancelBTN.Text = "Cancel";
      this.CancelBTN.Click += new System.EventHandler( this.DoneBTN_Click );
      // 
      // DoneBTN
      // 
      this.DoneBTN.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
      this.DoneBTN.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.DoneBTN.Location = new System.Drawing.Point( 712, 8 );
      this.DoneBTN.Name = "DoneBTN";
      this.DoneBTN.Size = new System.Drawing.Size( 75, 23 );
      this.DoneBTN.TabIndex = 0;
      this.DoneBTN.Text = "Done";
      // 
      // SplitterV
      // 
      this.SplitterV.Location = new System.Drawing.Point( 250, 0 );
      this.SplitterV.Name = "SplitterV";
      this.SplitterV.Size = new System.Drawing.Size( 4, 300 );
      this.SplitterV.TabIndex = 10;
      this.SplitterV.TabStop = false;
      // 
      // WriteItemsDlg
      // 
      this.AutoScaleBaseSize = new System.Drawing.Size( 5, 13 );
      this.ClientSize = new System.Drawing.Size( 792, 336 );
      this.Controls.Add( this.RightPN );
      this.Controls.Add( this.SplitterV );
      this.Controls.Add( this.LeftPN );
      this.Controls.Add( this.ButtonsPN );
      this.HelpButton = true;
      this.Icon = ( (System.Drawing.Icon)( resources.GetObject( "$this.Icon" ) ) );
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "WriteItemsDlg";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Write Items";
      this.HelpButtonClicked += new System.ComponentModel.CancelEventHandler( this.WriteItemsDlg_HelpButtonClicked );
      this.LeftPN.ResumeLayout( false );
      this.RightPN.ResumeLayout( false );
      this.ButtonsPN.ResumeLayout( false );
      this.ResumeLayout( false );

    }
    #endregion
    #region public
    /// <summary>
    /// Prompts the use to select items for the write request.
    /// </summary>
    /// <param name="server">The server <see cref="Server"/>.</param>
    /// <returns></returns>
    public OpcDa::ItemValueResult[] ShowDialog( Server server )
    {
      if ( server == null )
        throw new ArgumentNullException( "server" );
      m_server = server;
      m_subscription = null;
      m_synchronous = true;
      //buttons
      BackBTN.Enabled = false;
      NextBTN.Enabled = true;
      CancelBTN.Visible = true;
      DoneBTN.Visible = false;
      BrowseCTRL.Visible = true;
      SubscriptionCTRL.Visible = false;
      ItemsCTRL.Visible = true;
      ResultsCTRL.Visible = false;
      //controls
      BrowseCTRL.ShowSingleServer( m_server, null, true );
      ItemsCTRL.Initialize( m_server, null );
      ReadSupportedLocales();
      //Show dialog
      ShowDialog();
      // ensure server connection in the browse control are closed.
      BrowseCTRL.Clear();
      return m_values;
    }
    /// <summary>
    /// Prompts the use to select items for the read request.
    /// </summary>
    /// <param name="subscription">The subscription <see cref="Subscription"/>.</param>
    /// <param name="synchronous">if set to <c>true</c> for synchronous operations.</param>
    /// <returns></returns>
    public OpcDa::ItemValueResult[] ShowDialog( Subscription subscription, bool synchronous )
    {
      if ( subscription == null )
        throw new ArgumentNullException( "subscription" );
      m_server = subscription.Server;
      m_subscription = subscription;
      m_synchronous = synchronous;
      //Buttons
      BackBTN.Enabled = false;
      NextBTN.Enabled = true;
      CancelBTN.Visible = true;
      DoneBTN.Visible = false;
      OptionsBTN.Visible = true;
      BrowseCTRL.Visible = false;
      SubscriptionCTRL.Visible = true;
      ItemsCTRL.Visible = true;
      ResultsCTRL.Visible = false;
      //controls
      SubscriptionCTRL.Initialize( new OpcDa::BrowseFilters(), m_subscription );
      ItemsCTRL.Initialize( m_server, null, m_subscription.Items );
      ReadSupportedLocales();
      //Show dialog
      ShowDialog();
      return m_values;
    }
    #endregion
    #region private
    /// <summary>
    /// The server used to process write request.
    /// </summary>
    private Server m_server = null;
    /// <summary>
    /// The subscription used to process write request.
    /// </summary>
    private Subscription m_subscription = null;
    /// <summary>
    /// Whether to use asynchronous write operations. 
    /// </summary>
    private bool m_synchronous = true;
    /// <summary>
    /// The set of values written to the server.
    /// </summary>
    private OpcDa::ItemValueResult[] m_values = null;
    /// <summary>
    /// Supported locales
    /// </summary>
    private string[] m_SupportedLocales;
    private void ReadSupportedLocales()
    {
      try
      {
        m_SupportedLocales = m_server.GetSupportedLocales();
      }
      catch ( Exception ex )
      {
        MessageBox.Show( ex.Message, "GetSupportedLocales failed", MessageBoxButtons.OK, MessageBoxIcon.Warning );
      }
    }
    /// <summary>
    /// Executes a write request for the current set if items.
    /// </summary>
    private void DoWrite()
    {
      try
      {
        // get the selected items 
        OpcDa::ItemValue[] items = ItemsCTRL.GetItems();
        // write to server.
        Opc.IdentifiedResult[] results = null;
        if ( m_subscription != null )
        {
          if ( m_synchronous )
            results = m_subscription.Write( items );
          else
          {
            results = new AsyncRequestDlg().ShowDialog( m_subscription, items );
            if ( results == null )
              return;
          }
        }
        else
        {
          // add dummy client handles to test that they get returned properly.
          foreach ( OpcDa::ItemValue item in items ) { item.ClientHandle = item.ItemName; }
          results = m_server.Write( items );
        }
        // create a list of item value results.
        ArrayList values = new ArrayList();
        for ( int ii = 0; ii < items.Length; ii++ )
        {
          OpcDa::ItemValueResult value = new OpcDa::ItemValueResult( items[ ii ] );
          value.ItemName = results[ ii ].ItemName;
          value.ItemPath = results[ ii ].ItemPath;
          value.ClientHandle = results[ ii ].ClientHandle;
          value.ServerHandle = results[ ii ].ServerHandle;
          value.ResultID = results[ ii ].ResultID;
          value.DiagnosticInfo = results[ ii ].DiagnosticInfo;
          values.Add( value );
        }
        // save results.
        m_values = (OpcDa::ItemValueResult[])values.ToArray( typeof( OpcDa::ItemValueResult ) );
        BackBTN.Enabled = true;
        NextBTN.Enabled = false;
        CancelBTN.Visible = false;
        DoneBTN.Visible = true;
        OptionsBTN.Visible = false;
        ItemsCTRL.Visible = false;
        ResultsCTRL.Visible = true;
        // display results.
        ResultsCTRL.Initialize( m_server, ( m_subscription != null ) ? m_subscription.Locale : m_server.Locale, m_values );
      }
      catch ( Exception e )
      {
        MessageBox.Show( e.Message );
      }
    }
    /// <summary>
    /// Discards any results from a write request.
    /// </summary>
    private void UndoWrite()
    {
      // clear the previously read results.
      m_values = null;
      BackBTN.Enabled = false;
      NextBTN.Enabled = true;
      CancelBTN.Visible = true;
      DoneBTN.Visible = false;
      OptionsBTN.Visible = true;
      ItemsCTRL.Visible = true;
      ResultsCTRL.Visible = false;
    }
    /// <summary>
    /// Called when a server is picked in the browse control.
    /// </summary>
    private void OnItemPicked( Opc.ItemIdentifier itemID )
    {
      ItemsCTRL.AddItemWithDefaults( new OpcDa::ItemValue( itemID ) );
    }
    /// <summary>
    /// Called when the back button is clicked.
    /// </summary>
    private void BackBTN_Click( object sender, System.EventArgs e )
    {
      UndoWrite();
    }
    /// <summary>
    /// Called when the next button is clicked.
    /// </summary>
    private void NextBTN_Click( object sender, System.EventArgs e )
    {
      DoWrite();
    }
    /// <summary>
    /// Called when the close button is clicked.
    /// </summary>
    private void DoneBTN_Click( object sender, System.EventArgs e )
    {
      if ( sender == CancelBTN )
        m_values = null;
      DialogResult = DialogResult.Cancel;
      Close();
    }
    /// <summary>
    /// Updates the result filters used for the request.
    /// </summary>
    private void OptionsBTN_Click( object sender, System.EventArgs e )
    {
      using ( var dial = new OptionsEditDlg() )
        dial.ShowDialog( m_SupportedLocales, this );
    }

    /// <summary>
    /// Handles the HelpButtonClicked event of the WriteItemsDlg control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.ComponentModel.CancelEventArgs"/> instance containing the event data.</param>
    private void WriteItemsDlg_HelpButtonClicked( object sender, System.ComponentModel.CancelEventArgs e )
    {
      System.Diagnostics.Process.Start( Properties.Resources.Help_WriteTagSynchronously );
    }
    #endregion
    #region IOptions Members
    /// <summary>
    /// Gets or sets the locale. The locale is used for any error
    /// messages or results returned to the client.
    /// </summary>
    /// <value>The locale.</value>
    public string Locale
    {
      get
      {
        if ( m_subscription != null )
          return m_subscription.Locale;
        else
          return m_server.Locale;
      }
      set
      {
        try
        {
          if ( m_subscription != null )
          {
            OpcDa.SubscriptionState newStte = new global::Opc.Da.SubscriptionState() { Locale = value };
            m_subscription.ModifyState( (int)OpcDa.StateMask.Locale, newStte );
          }
          else
          {
            m_server.SetLocale( value );
          }
        }
        catch ( Exception exc )
        {
          MessageBox.Show( exc.Message, "Server ModifyState failed", MessageBoxButtons.OK, MessageBoxIcon.Warning  );
        }
      }
    }
    /// <summary>
    /// Gets or sets the filter <see cref="Opc.Da.ResultFilter"/>. Filters are
    /// applied by the server before returning item results.
    /// </summary>
    /// <value>The filter.</value>
    public global::Opc.Da.ResultFilter Filter
    {
      get
      {
        try
        {
          if ( m_subscription != null )
            return (global::Opc.Da.ResultFilter)m_subscription.GetResultFilters();
          else
            return (global::Opc.Da.ResultFilter)m_server.GetResultFilters();
        }
        catch ( Exception exc )
        {
          MessageBox.Show( exc.Message, "Server GetResultFilters failed", MessageBoxButtons.OK, MessageBoxIcon.Warning );
        }
        return global::Opc.Da.ResultFilter.All;
      }
      set
      {
        try
        {
          if ( m_subscription != null )
            m_subscription.SetResultFilters( (int)value );
          else
            m_server.SetResultFilters( (int)value );
        }
        catch ( Exception exc )
        {
          MessageBox.Show( exc.Message, "Server SetResultFilters failed", MessageBoxButtons.OK, MessageBoxIcon.Warning );
        }
      }
    }
    #endregion

    
  }
}
