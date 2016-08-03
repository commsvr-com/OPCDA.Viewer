//<summary>
//  Title   : A control that periodically gets the server status and shows the results.
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
using OpcDa = Opc.Da;

namespace CAS.Lib.OPCClientControlsLib
{
  using ControlLibrary;
  using OPCClient.Da;

  /// <summary>
  /// A control that periodically gets the server status and shows the results.
  /// </summary>
  public class ServerStatusStrip: System.Windows.Forms.StatusStrip
  {
    private System.Windows.Forms.Timer UpdateTimer;
    private ToolStripStatusLabel TSSLlInfoPN;
    private ToolStripStatusLabel TSSLConn;
    private ToolStripStatusLabel TSSLDidconn;
    private ToolStripStatusLabel TSSLStatePN;
    private ToolStripStatusLabel TSSLTimePN;
    private System.ComponentModel.IContainer components = null;
    public ServerStatusStrip()
    {
      // This call is required by the Windows Form Designer.
      InitializeComponent();
    }
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
    #region Designer generated code
    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      this.UpdateTimer = new System.Windows.Forms.Timer( this.components );
      this.TSSLlInfoPN = new System.Windows.Forms.ToolStripStatusLabel();
      this.TSSLConn = new System.Windows.Forms.ToolStripStatusLabel();
      this.TSSLDidconn = new System.Windows.Forms.ToolStripStatusLabel();
      this.TSSLStatePN = new System.Windows.Forms.ToolStripStatusLabel();
      this.TSSLTimePN = new System.Windows.Forms.ToolStripStatusLabel();
      this.SuspendLayout();
      // 
      // UpdateTimer
      // 
      this.UpdateTimer.Interval = 30000;
      this.UpdateTimer.Tick += new System.EventHandler( this.UpdateTimer_Tick );
      // 
      // TSSLlInfoPN
      // 
      this.TSSLlInfoPN.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
      this.TSSLlInfoPN.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.TSSLlInfoPN.Name = "TSSLlInfoPN";
      this.TSSLlInfoPN.Size = new System.Drawing.Size( 0, 0 );
      this.TSSLlInfoPN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.TSSLlInfoPN.ToolTipText = "Vendor Info";
      // 
      // TSSLConn
      // 
      this.TSSLConn.BackColor = System.Drawing.SystemColors.Control;
      this.TSSLConn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.TSSLConn.Image = global::CAS.Lib.OPCClientControlsLib.ImagesResources.serwer_opc_connect_48;
      this.TSSLConn.Margin = new System.Windows.Forms.Padding( 2 );
      this.TSSLConn.Name = "TSSLConn";
      this.TSSLConn.Size = new System.Drawing.Size( 16, 16 );
      this.TSSLConn.Text = "Server Connected";
      this.TSSLConn.ToolTipText = "Server Connected";
      this.TSSLConn.Visible = false;
      // 
      // TSSLDidconn
      // 
      this.TSSLDidconn.BackColor = System.Drawing.SystemColors.Control;
      this.TSSLDidconn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.TSSLDidconn.Image = global::CAS.Lib.OPCClientControlsLib.ImagesResources.serwer_opc_disconnect_48;
      this.TSSLDidconn.Margin = new System.Windows.Forms.Padding( 2 );
      this.TSSLDidconn.Name = "TSSLDidconn";
      this.TSSLDidconn.Size = new System.Drawing.Size( 16, 16 );
      this.TSSLDidconn.Text = "Server Disconnected";
      this.TSSLDidconn.ToolTipText = "Server Disconnected";
      // 
      // TSSLStatePN
      // 
      this.TSSLStatePN.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
      this.TSSLStatePN.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.TSSLStatePN.Name = "TSSLStatePN";
      this.TSSLStatePN.Size = new System.Drawing.Size( 0, 0 );
      this.TSSLStatePN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.TSSLStatePN.ToolTipText = "Server State";
      // 
      // TSSLTimePN
      // 
      this.TSSLTimePN.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
      this.TSSLTimePN.Name = "TSSLTimePN";
      this.TSSLTimePN.Size = new System.Drawing.Size( 0, 0 );
      this.TSSLTimePN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.TSSLTimePN.ToolTipText = "Current Time";
      // 
      // ServerStatusStrip
      // 
      this.Dock = System.Windows.Forms.DockStyle.None;
      this.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
      this.Items.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.TSSLConn,
            this.TSSLDidconn,
            this.TSSLlInfoPN,
            this.TSSLStatePN,
            this.TSSLTimePN} );
      this.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
      this.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
      this.ShowItemToolTips = true;
      this.Size = new System.Drawing.Size( 40, 30 );
      this.Stretch = false;
      this.Text = "Server Status";
      this.ResumeLayout( false );
    }
    #endregion
    #region public
    /// <summary>
    /// Is called when a server is selected or current server status is changed.
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The <see cref="CAS.Lib.OPCClientControlsLib.ServerEventArgs"/> instance containing the event data.</param>
    public void OnSelectServer( object sender, GenericEventArgs<Server> e )
    {
      if ( e.Tag == null )
      {
        Clear();
        return;
      }
      Clear();
      m_server = e.Tag;
      m_server.DeleteServer += new EventHandler( m_server_DeleteServer );
      if ( !m_server.IsConnected )
      {
        Text = "Server not connected.";
        TSSLlInfoPN.Text = m_server.Url.ToString();
        TSSLStatePN.Text = "Disconnected";
        TSSLTimePN.Text = "";
        Connected = false;
      }
      else
      {
        UpdateTimer.Enabled = true;
        UpdateTimer_Tick( this, null );
        Connected = true;
      }
    }
    #endregion
    #region private
    /// <summary>
    /// Clears this instance.
    /// </summary>
    private void Clear()
    {
      if ( m_server != null )
        m_server.DeleteServer -= new EventHandler( m_server_DeleteServer );
      m_server = null;
      UpdateTimer.Enabled = false;
      Text = "Server not connected.";
      TSSLlInfoPN.Text = "";
      TSSLStatePN.Text = "";
      TSSLTimePN.Text = "";
      Connected = false;
    }
    private void m_server_DeleteServer( object sender, EventArgs e ) { Clear(); }
    private bool Connected
    {
      set
      {
        TSSLConn.Visible = value;
        TSSLDidconn.Visible = !value;
      }
    }
    /// <summary>
    /// The server being polled for its current status.
    /// </summary>
    private Server m_server = null;
    private OpcDa::ServerStatus MyGetStatus()
    {
      try
      {
        return m_server.GetStatus();
      }
      catch ( Exception exception )
      {
        OpcDa::ServerStatus status = new OpcDa::ServerStatus();
        status.CurrentTime = DateTime.Now;
        status.LastUpdateTime = DateTime.Now;
        status.ProductVersion = "";
        status.ServerState = OpcDa::serverState.failed;
        status.StartTime = DateTime.Now;
        status.StatusInfo = exception.Message;
        status.VendorInfo = "Not connected";
        return status;
      }
    }
    /// <summary>
    /// Called when the update timer expires - begins a get status request.
    /// </summary>
    private void UpdateTimer_Tick( object sender, System.EventArgs e )
    {
      try
      {
        OpcDa::GetStatusAsyncDelegate callback = new OpcDa::GetStatusAsyncDelegate( MyGetStatus );
        callback.BeginInvoke( new AsyncCallback( OnGetStatus ), callback );
      }
      catch ( Exception exception )
      {
        Text = exception.Message;
      }
    }
    /// <summary>
    /// Completes an asynchronous get status request and updates the control.
    /// </summary>
    private void OnGetStatus( IAsyncResult result )
    {
      if ( InvokeRequired )
      {
        Invoke( new AsyncCallback( OnGetStatus ), result );
        return;
      }
      try
      {
        OpcDa::GetStatusAsyncDelegate callback = (OpcDa::GetStatusAsyncDelegate)result.AsyncState;
        OpcDa::ServerStatus status = callback.EndInvoke( result );
        if ( status.ServerState != OpcDa::serverState.running )
          Connected = false;
        TSSLlInfoPN.Text = status.VendorInfo;
        TSSLStatePN.Text = ( status.StatusInfo == null ) ? status.ServerState.ToString() : status.StatusInfo;
        TSSLTimePN.Text = status.CurrentTime.ToString();
      }
      catch ( Exception e )
      {
        Text = e.Message;
      }
    }
    #endregion
  }
}

