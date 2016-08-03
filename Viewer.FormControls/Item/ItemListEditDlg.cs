//============================================================================
// TITLE: ItemListEditDlg.cs
//
// CONTENTS:
// 
// A dialog used to display and edit a list of Item objects.
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
using CAS.Lib.OPCClientControlsLib.Properties;

namespace CAS.Lib.OPCClientControlsLib
{
  /// <summary>
  /// A dialog used to display and edit a list of Item objects.
  /// </summary>
  public class ItemListEditDlg: EditObjectListDlg<OpcDa::Item>
  {
    private CAS.Lib.OPCClientControlsLib.ItemEditCtrl ObjectCTRL;
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.Container components = null;

    public ItemListEditDlg()
    {
      InitializeComponent();
      m_control = ObjectCTRL;
      
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

    #region Windows Form Designer generated code
    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.ObjectCTRL = new CAS.Lib.OPCClientControlsLib.ItemEditCtrl();
      this.SuspendLayout();
      // 
      // ObjectCTRL
      // 
      this.ObjectCTRL.AllowEditItemID = false;
      this.ObjectCTRL.Anchor = ( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom )
        | System.Windows.Forms.AnchorStyles.Left )
        | System.Windows.Forms.AnchorStyles.Right );
      this.ObjectCTRL.DockPadding.Left = 4;
      this.ObjectCTRL.DockPadding.Right = 4;
      this.ObjectCTRL.DockPadding.Top = 4;
      this.ObjectCTRL.IsReadItem = false;
      this.ObjectCTRL.Name = "ObjectCTRL";
      this.ObjectCTRL.Size = new System.Drawing.Size( 296, 174 );
      this.ObjectCTRL.TabIndex = 2;
      // 
      // ItemListEditDlg
      // 
      this.AutoScaleBaseSize = new System.Drawing.Size( 5, 13 );
      this.ClientSize = new System.Drawing.Size( 384, 190 );
      this.Controls.AddRange( new System.Windows.Forms.Control[] {
																		  this.ObjectCTRL} );
      this.Name = "ItemListEditDlg";
      this.Text = "Edit Items";
      this.ResumeLayout( false );
      
    }
    #endregion

    /// <summary>
    /// Prompts the user to edit the item list parameters.
    /// </summary>
    public OpcDa::Item[] ShowDialog( OpcDa::Item[] items, bool isReadItems, bool allowEditItemID )
    {
      ObjectCTRL.IsReadItem = isReadItems;
      ObjectCTRL.AllowEditItemID = allowEditItemID;

      if ( items == null )
        items = new OpcDa::Item[] { (OpcDa::Item)ObjectCTRL.Create() };

      ArrayList results = base.ShowDialog( items, !allowEditItemID );

      if ( results != null && results.Count > 0 )
      {
        return (OpcDa::Item[])results.ToArray( typeof( OpcDa::Item ) );
      }

      return null;
    }
  }
}
