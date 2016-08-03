//<summary>
//  Title   : A control used yo browse and select a single OPC server.
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
//============================================================================
// TITLE: SelectServerCtrl.cs
//
// CONTENTS:
// 
// A control used browse and select a single OPC server. 
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

using System.Windows.Forms;
using Opc;

namespace CAS.Lib.OPCClientControlsLib
{
  /// <summary>
  /// A control used yo browse and select a single OPC server. 
  /// </summary>
  public class SelectServerDlg: System.Windows.Forms.Form
  {
    #region private
    private System.Windows.Forms.Button CancelBTN;
    private System.Windows.Forms.Button OkBTN;
    private CAS.Lib.OPCClientControlsLib.BrowseTreeCtrl ServersCTRL;
    private System.Windows.Forms.ComboBox SpecificationCB;
    private TableLayoutPanel tableLayoutPanel1;
    private TableLayoutPanel tableLayoutPanel2;
    private System.ComponentModel.IContainer components;
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
    #region creator
    public SelectServerDlg()
    {
      InitializeComponent();
      SpecificationCB.Items.Add( Specification.COM_DA_20 );
      SpecificationCB.Items.Add( Specification.COM_DA_30 );
      SpecificationCB.SelectedItem = null;
      ServersCTRL.ServerPicked += new ServerPicked_EventHandler( OnServerPicked );
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
      System.Windows.Forms.Label SpecificationLB;
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( SelectServerDlg ) );
      this.CancelBTN = new System.Windows.Forms.Button();
      this.OkBTN = new System.Windows.Forms.Button();
      this.SpecificationCB = new System.Windows.Forms.ComboBox();
      this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
      this.ServersCTRL = new CAS.Lib.OPCClientControlsLib.BrowseTreeCtrl();
      SpecificationLB = new System.Windows.Forms.Label();
      this.tableLayoutPanel1.SuspendLayout();
      this.tableLayoutPanel2.SuspendLayout();
      this.SuspendLayout();
      // 
      // SpecificationLB
      // 
      SpecificationLB.AutoSize = true;
      SpecificationLB.Dock = System.Windows.Forms.DockStyle.Fill;
      SpecificationLB.Location = new System.Drawing.Point( 3, 0 );
      SpecificationLB.Name = "SpecificationLB";
      SpecificationLB.Size = new System.Drawing.Size( 68, 27 );
      SpecificationLB.TabIndex = 2;
      SpecificationLB.Text = "Specification";
      SpecificationLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // CancelBTN
      // 
      this.CancelBTN.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
      this.CancelBTN.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.CancelBTN.Location = new System.Drawing.Point( 214, 240 );
      this.CancelBTN.Name = "CancelBTN";
      this.CancelBTN.Size = new System.Drawing.Size( 75, 23 );
      this.CancelBTN.TabIndex = 0;
      this.CancelBTN.Text = "Cancel";
      // 
      // OkBTN
      // 
      this.OkBTN.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left ) ) );
      this.OkBTN.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.OkBTN.Location = new System.Drawing.Point( 3, 240 );
      this.OkBTN.Name = "OkBTN";
      this.OkBTN.Size = new System.Drawing.Size( 75, 23 );
      this.OkBTN.TabIndex = 1;
      this.OkBTN.Text = "OK";
      // 
      // SpecificationCB
      // 
      this.SpecificationCB.Dock = System.Windows.Forms.DockStyle.Fill;
      this.SpecificationCB.Location = new System.Drawing.Point( 77, 3 );
      this.SpecificationCB.Name = "SpecificationCB";
      this.SpecificationCB.Size = new System.Drawing.Size( 206, 21 );
      this.SpecificationCB.TabIndex = 3;
      this.SpecificationCB.SelectedIndexChanged += new System.EventHandler( this.SpecificationCB_SelectedIndexChanged );
      // 
      // tableLayoutPanel1
      // 
      this.tableLayoutPanel1.AutoSize = true;
      this.tableLayoutPanel1.ColumnCount = 2;
      this.tableLayoutPanel2.SetColumnSpan( this.tableLayoutPanel1, 2 );
      this.tableLayoutPanel1.ColumnStyles.Add( new System.Windows.Forms.ColumnStyle() );
      this.tableLayoutPanel1.ColumnStyles.Add( new System.Windows.Forms.ColumnStyle( System.Windows.Forms.SizeType.Percent, 100F ) );
      this.tableLayoutPanel1.Controls.Add( this.SpecificationCB, 1, 0 );
      this.tableLayoutPanel1.Controls.Add( SpecificationLB, 0, 0 );
      this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tableLayoutPanel1.Location = new System.Drawing.Point( 3, 3 );
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 1;
      this.tableLayoutPanel1.RowStyles.Add( new System.Windows.Forms.RowStyle() );
      this.tableLayoutPanel1.Size = new System.Drawing.Size( 286, 27 );
      this.tableLayoutPanel1.TabIndex = 4;
      // 
      // tableLayoutPanel2
      // 
      this.tableLayoutPanel2.ColumnCount = 2;
      this.tableLayoutPanel2.ColumnStyles.Add( new System.Windows.Forms.ColumnStyle( System.Windows.Forms.SizeType.Percent, 50F ) );
      this.tableLayoutPanel2.ColumnStyles.Add( new System.Windows.Forms.ColumnStyle( System.Windows.Forms.SizeType.Percent, 50F ) );
      this.tableLayoutPanel2.Controls.Add( this.ServersCTRL, 0, 1 );
      this.tableLayoutPanel2.Controls.Add( this.tableLayoutPanel1, 0, 0 );
      this.tableLayoutPanel2.Controls.Add( this.CancelBTN, 1, 2 );
      this.tableLayoutPanel2.Controls.Add( this.OkBTN, 0, 2 );
      this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tableLayoutPanel2.Location = new System.Drawing.Point( 0, 0 );
      this.tableLayoutPanel2.Name = "tableLayoutPanel2";
      this.tableLayoutPanel2.RowCount = 2;
      this.tableLayoutPanel2.RowStyles.Add( new System.Windows.Forms.RowStyle() );
      this.tableLayoutPanel2.RowStyles.Add( new System.Windows.Forms.RowStyle( System.Windows.Forms.SizeType.Percent, 100F ) );
      this.tableLayoutPanel2.RowStyles.Add( new System.Windows.Forms.RowStyle() );
      this.tableLayoutPanel2.RowStyles.Add( new System.Windows.Forms.RowStyle( System.Windows.Forms.SizeType.Absolute, 20F ) );
      this.tableLayoutPanel2.Size = new System.Drawing.Size( 292, 266 );
      this.tableLayoutPanel2.TabIndex = 6;
      // 
      // ServersCTRL
      // 
      this.tableLayoutPanel2.SetColumnSpan( this.ServersCTRL, 2 );
      this.ServersCTRL.Dock = System.Windows.Forms.DockStyle.Fill;
      this.ServersCTRL.Location = new System.Drawing.Point( 3, 36 );
      this.ServersCTRL.Name = "ServersCTRL";
      this.ServersCTRL.Padding = new System.Windows.Forms.Padding( 4, 0, 4, 0 );
      this.ServersCTRL.Size = new System.Drawing.Size( 286, 198 );
      this.ServersCTRL.TabIndex = 4;
      // 
      // SelectServerDlg
      // 
      this.AutoScaleBaseSize = new System.Drawing.Size( 5, 13 );
      this.CancelButton = this.CancelBTN;
      this.ClientSize = new System.Drawing.Size( 292, 266 );
      this.Controls.Add( this.tableLayoutPanel2 );
      this.HelpButton = true;
      this.Icon = ( (System.Drawing.Icon)( resources.GetObject( "$this.Icon" ) ) );
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.MinimumSize = new System.Drawing.Size( 300, 300 );
      this.Name = "SelectServerDlg";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Select Server";
      this.HelpButtonClicked += new System.ComponentModel.CancelEventHandler( this.SelectServerDlg_HelpButtonClicked );
      this.tableLayoutPanel1.ResumeLayout( false );
      this.tableLayoutPanel1.PerformLayout();
      this.tableLayoutPanel2.ResumeLayout( false );
      this.tableLayoutPanel2.PerformLayout();
      this.ResumeLayout( false );

    }
    #endregion
    #region public
    /// <summary>
    /// Prompts the use to select a server with the specified specification.
    /// </summary>
    public Server ShowDialog( Specification specification )
    {
      SpecificationCB.SelectedItem = specification;
      if ( ShowDialog() != DialogResult.OK )
      {
        ServersCTRL.Clear();
        return null;
      }
      Server server = ServersCTRL.SelectedServer;
      ServersCTRL.Clear();
      return server;
    }
    #endregion
    #region Events handlers
    /// <summary>
    /// Called when a server is picked in the browse control.
    /// </summary>
    private void OnServerPicked( Server server )
    {
      if ( server != null )
        DialogResult = DialogResult.OK;
    }
    /// <summary>
    /// Updates the specification of servers displayed in the browse control.
    /// </summary>
    private void SpecificationCB_SelectedIndexChanged( object sender, System.EventArgs e )
    {
      Cursor = Cursors.WaitCursor;
      ServersCTRL.ShowAllServers( new OpcCom.ServerEnumerator(), (Specification)SpecificationCB.SelectedItem, null, false );
      Cursor = Cursors.Default;
    }

    /// <summary>
    /// Handles the HelpButtonClicked event of the SelectServerDlg control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.ComponentModel.CancelEventArgs"/> instance containing the event data.</param>
    private void SelectServerDlg_HelpButtonClicked( object sender, System.ComponentModel.CancelEventArgs e )
    {
      System.Diagnostics.Process.Start(Properties.Resources.Help_SelectServerForm );
    }
    #endregion

   
  }
}
