//============================================================================
// TITLE: EditValueDlg.cs
//
// CONTENTS:
// 
// A dialog used to display and edit the contents of an array.
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
using System.Windows.Forms;
namespace CAS.Lib.OPCClientControlsLib
{
	/// <summary>
	/// A dialog used to display and edit the contents of an array.
	/// </summary>
	public class EditValueDlg : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Panel ButtonsPN;
		private System.Windows.Forms.Button CancelBTN;
		private System.Windows.Forms.Button OkBTN;
		private CAS.Lib.OPCClientControlsLib.ValueCtrl ValueCTRL;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public EditValueDlg()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
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
			this.ButtonsPN = new System.Windows.Forms.Panel();
			this.CancelBTN = new System.Windows.Forms.Button();
			this.OkBTN = new System.Windows.Forms.Button();
			this.ValueCTRL = new CAS.Lib.OPCClientControlsLib.ValueCtrl();
			this.ButtonsPN.SuspendLayout();
			this.SuspendLayout();
			// 
			// ButtonsPN
			// 
			this.ButtonsPN.Controls.Add(this.CancelBTN);
			this.ButtonsPN.Controls.Add(this.OkBTN);
			this.ButtonsPN.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.ButtonsPN.Location = new System.Drawing.Point(0, 26);
			this.ButtonsPN.Name = "ButtonsPN";
			this.ButtonsPN.Size = new System.Drawing.Size(296, 36);
			this.ButtonsPN.TabIndex = 0;
			// 
			// CancelBTN
			// 
			this.CancelBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.CancelBTN.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.CancelBTN.Location = new System.Drawing.Point(216, 8);
			this.CancelBTN.Name = "CancelBTN";
			this.CancelBTN.TabIndex = 0;
			this.CancelBTN.Text = "Cancel";
			// 
			// OkBTN
			// 
			this.OkBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.OkBTN.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.OkBTN.Location = new System.Drawing.Point(4, 8);
			this.OkBTN.Name = "OkBTN";
			this.OkBTN.TabIndex = 1;
			this.OkBTN.Text = "OK";
			// 
			// ValueCTRL
			// 
			this.ValueCTRL.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ValueCTRL.DockPadding.Left = 4;
			this.ValueCTRL.DockPadding.Right = 4;
			this.ValueCTRL.DockPadding.Top = 4;
			this.ValueCTRL.ItemID = null;
			this.ValueCTRL.Location = new System.Drawing.Point(0, 0);
			this.ValueCTRL.Name = "ValueCTRL";
			this.ValueCTRL.Size = new System.Drawing.Size(296, 26);
			this.ValueCTRL.TabIndex = 1;
			// 
			// EditValueDlg
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(296, 62);
			this.Controls.Add(this.ValueCTRL);
			this.Controls.Add(this.ButtonsPN);
			this.Name = "EditValueDlg";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Edit Value";
			this.ButtonsPN.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The current array object.
		/// </summary>
		private object m_value = null;

		/// <summary>
		/// The data type of the elements of the current array object.
		/// </summary>
		private System.Type m_type = null;

		/// <summary>
		/// Displays the dialog with the specified array.
		/// </summary>
		public object ShowDialog(object value, bool fixedType)
		{
			if (value == null) throw new ArgumentNullException("value");
			if (value.GetType().IsArray) throw new ArgumentException("Is an array", "value");

			m_value = global::Opc.Convert.Clone(value);
			m_type  = m_value.GetType();

			ValueCTRL.AllowChangeType = !fixedType;
			ValueCTRL.Set(value, false);

			if (ShowDialog() != DialogResult.OK)
			{
				return null;
			}

			return ValueCTRL.Get();
		}
	}
}
