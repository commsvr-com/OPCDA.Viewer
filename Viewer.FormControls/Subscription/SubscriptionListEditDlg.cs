//<summary>
//  Title   : A dialog used to edit the state of a list of subscriptions.
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
// TITLE: SubscriptionListEditDlg.cs
//
// CONTENTS:
// 
// A dialog used to edit the state of a list of subscriptions.
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
using System.Collections;
using OpcDa = Opc.Da;
namespace CAS.Lib.OPCClientControlsLib
{
  /// <summary>
  /// A dialog used to edit the state of a list of subscriptions.
  /// </summary>
  public class SubscriptionListEditDlg: EditObjectListDlg<OpcDa::SubscriptionState>
  {
    #region private
    private CAS.Lib.OPCClientControlsLib.SubscriptionEditCtrl ObjectCTRL;
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.Container components = null;
    #endregion
    #region constructor
    /// <summary>
    /// Initializes a new instance of the <see cref="SubscriptionListEditDlg"/> class.
    /// </summary>
    /// <remarks>A dialog used to edit the state of a subscriptions.</remarks>
    public SubscriptionListEditDlg()
    {
      InitializeComponent();
      m_control = ObjectCTRL;
    }
    #endregion
    #region System.IDisposable
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( SubscriptionListEditDlg ) );
      this.ObjectCTRL = new CAS.Lib.OPCClientControlsLib.SubscriptionEditCtrl();
      this.SuspendLayout();
      // 
      // ObjectCTRL
      // 
      this.ObjectCTRL.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left )
                  | System.Windows.Forms.AnchorStyles.Right ) ) );
      this.ObjectCTRL.Location = new System.Drawing.Point( 4, 4 );
      this.ObjectCTRL.Name = "ObjectCTRL";
      this.ObjectCTRL.Size = new System.Drawing.Size( 228, 148 );
      this.ObjectCTRL.TabIndex = 2;
      // 
      // SubscriptionListEditDlg
      // 
      this.AutoScaleBaseSize = new System.Drawing.Size( 5, 13 );
      this.ClientSize = new System.Drawing.Size( 320, 166 );
      this.Controls.Add( this.ObjectCTRL );
      this.Icon = ( (System.Drawing.Icon)( resources.GetObject( "$this.Icon" ) ) );
      this.Name = "SubscriptionListEditDlg";
      this.Text = "Edit Subscription";
      this.Controls.SetChildIndex( this.ObjectCTRL, 0 );
      this.ResumeLayout( false );

    }
    #endregion
    #region public
    /// <summary>
    /// Prompts the user to modify the subscription state parameters.
    /// </summary>
    public OpcDa::SubscriptionState ShowDialog( string[] supportedLocales, string locale, OpcDa::SubscriptionState state )
    {
      ObjectCTRL.Initialize( supportedLocales, locale );
      if ( state == null )
        state = (OpcDa::SubscriptionState)ObjectCTRL.Create();
      ArrayList results = ShowDialog( new OpcDa::SubscriptionState[] { state } );
      if ( results != null && results.Count == 1 )
        return (OpcDa::SubscriptionState)results[ 0 ];
      return null;
    }
    #endregion
  }
}
