//============================================================================
// TITLE: ItemListEditDlg.cs
//
// CONTENTS:
// 
// A dialog used to display and edit a list of ItemValue objects.
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
  /// A dialog used to display and edit a list of ItemValue objects.
  /// </summary>
  public class ItemValueListEditDlg: EditObjectListDlg<OpcDa::ItemValue>
  {
    private CAS.Lib.OPCClientControlsLib.ItemValueEditCtrl ObjectCTRL;
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.Container components = null;

    public ItemValueListEditDlg()
    {
      //
      // Required for Windows Form Designer support
      //
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
      this.ObjectCTRL = new CAS.Lib.OPCClientControlsLib.ItemValueEditCtrl();
      this.SuspendLayout();
      // 
      // ObjectCTRL
      // 
      this.ObjectCTRL.Anchor = ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left )
        | System.Windows.Forms.AnchorStyles.Right );
      this.ObjectCTRL.Location = new System.Drawing.Point( 4, 4 );
      this.ObjectCTRL.Name = "ObjectCTRL";
      this.ObjectCTRL.Size = new System.Drawing.Size( 356, 168 );
      this.ObjectCTRL.TabIndex = 2;
      // 
      // ItemValueListEditDlg
      // 
      this.AutoScaleBaseSize = new System.Drawing.Size( 5, 13 );
      this.ClientSize = new System.Drawing.Size( 448, 190 );
      this.Controls.AddRange( new System.Windows.Forms.Control[] {
																		  this.ObjectCTRL} );
      this.Name = "ItemValueListEditDlg";
      this.Text = "Edit Item Values";
      this.ResumeLayout( false );

    }
    #endregion

    /// <summary>
    /// Prompts the user to edit the item list parameters.
    /// </summary>
    public new OpcDa::ItemValue[] ShowDialog( OpcDa::ItemValue[] items, bool allowEditItemID )
    {
      ObjectCTRL.AllowEditItemID = allowEditItemID;

      if ( items == null )
        items = new OpcDa::ItemValue[] { (OpcDa::ItemValue)ObjectCTRL.Create() };

      ArrayList results = base.ShowDialog( (OpcDa::ItemValue[])items, !allowEditItemID );

      if ( results != null && results.Count > 0 )
      {
        return (OpcDa::ItemValue[])results.ToArray( typeof( OpcDa::ItemValue ) );
      }

      return null;
    }
  }
}
