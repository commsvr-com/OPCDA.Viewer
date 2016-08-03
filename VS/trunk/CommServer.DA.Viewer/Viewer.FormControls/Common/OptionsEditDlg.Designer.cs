namespace CAS.Lib.OPCClientControlsLib.Common
{
  partial class OptionsEditDlg
  {
    private System.Windows.Forms.Label ItemTimeLB;
    private System.Windows.Forms.Label ItemNameLB;
    private System.Windows.Forms.Label ItemPathLB;
    private System.Windows.Forms.Label ErrorTextLB;
    private System.Windows.Forms.CheckBox ErrorTextCB;
    private System.Windows.Forms.Label DiagnosticInfoLB;
    private System.Windows.Forms.CheckBox DiagnosticInfoCB;
    private System.Windows.Forms.CheckBox ItemNameCB;
    private System.Windows.Forms.CheckBox ItemPathCB;
    private System.Windows.Forms.CheckBox ItemTimeCB;
    private System.Windows.Forms.CheckBox ClientHandleCB;
    private System.Windows.Forms.Label ClientHandleLB;
    private CAS.Lib.OPCClientControlsLib.LocaleCtrl LocaleCTRL;
    private System.Windows.Forms.Label LocaleLB;
    private System.Windows.Forms.CheckBox LocaleSpecifiedCB;
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose( bool disposing )
    {
      if ( disposing && ( components != null ) )
      {
        components.Dispose();
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
      System.Windows.Forms.ToolStrip m_ToolStrip;
      System.Windows.Forms.ToolStripButton m_TSB_OK;
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( OptionsEditDlg ) );
      this.ItemTimeLB = new System.Windows.Forms.Label();
      this.ItemNameLB = new System.Windows.Forms.Label();
      this.ItemTimeCB = new System.Windows.Forms.CheckBox();
      this.ItemPathLB = new System.Windows.Forms.Label();
      this.LocaleSpecifiedCB = new System.Windows.Forms.CheckBox();
      this.LocaleCTRL = new CAS.Lib.OPCClientControlsLib.LocaleCtrl();
      this.LocaleLB = new System.Windows.Forms.Label();
      this.ClientHandleCB = new System.Windows.Forms.CheckBox();
      this.ItemPathCB = new System.Windows.Forms.CheckBox();
      this.ItemNameCB = new System.Windows.Forms.CheckBox();
      this.DiagnosticInfoCB = new System.Windows.Forms.CheckBox();
      this.ErrorTextCB = new System.Windows.Forms.CheckBox();
      this.ClientHandleLB = new System.Windows.Forms.Label();
      this.DiagnosticInfoLB = new System.Windows.Forms.Label();
      this.ErrorTextLB = new System.Windows.Forms.Label();
      this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
      this.m_TSM_Cancel = new System.Windows.Forms.ToolStripButton();
      this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      m_ToolStrip = new System.Windows.Forms.ToolStrip();
      m_TSB_OK = new System.Windows.Forms.ToolStripButton();
      this.toolStripContainer1.BottomToolStripPanel.SuspendLayout();
      this.toolStripContainer1.ContentPanel.SuspendLayout();
      this.toolStripContainer1.SuspendLayout();
      m_ToolStrip.SuspendLayout();
      this.tableLayoutPanel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // ItemTimeLB
      // 
      this.ItemTimeLB.AutoSize = true;
      this.ItemTimeLB.Dock = System.Windows.Forms.DockStyle.Fill;
      this.ItemTimeLB.Location = new System.Drawing.Point( 30, 90 );
      this.ItemTimeLB.Name = "ItemTimeLB";
      this.ItemTimeLB.Size = new System.Drawing.Size( 128, 20 );
      this.ItemTimeLB.TabIndex = 8;
      this.ItemTimeLB.Text = "Return Timestamp";
      this.ItemTimeLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // ItemNameLB
      // 
      this.ItemNameLB.AutoSize = true;
      this.ItemNameLB.Dock = System.Windows.Forms.DockStyle.Fill;
      this.ItemNameLB.Location = new System.Drawing.Point( 30, 30 );
      this.ItemNameLB.Name = "ItemNameLB";
      this.ItemNameLB.Size = new System.Drawing.Size( 128, 20 );
      this.ItemNameLB.TabIndex = 0;
      this.ItemNameLB.Text = "Return Item Name";
      this.ItemNameLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // ItemTimeCB
      // 
      this.ItemTimeCB.AutoSize = true;
      this.ItemTimeCB.Checked = true;
      this.ItemTimeCB.CheckState = System.Windows.Forms.CheckState.Checked;
      this.ItemTimeCB.Dock = System.Windows.Forms.DockStyle.Fill;
      this.ItemTimeCB.Location = new System.Drawing.Point( 3, 93 );
      this.ItemTimeCB.Name = "ItemTimeCB";
      this.ItemTimeCB.Size = new System.Drawing.Size( 21, 14 );
      this.ItemTimeCB.TabIndex = 9;
      // 
      // ItemPathLB
      // 
      this.ItemPathLB.AutoSize = true;
      this.ItemPathLB.Dock = System.Windows.Forms.DockStyle.Fill;
      this.ItemPathLB.Location = new System.Drawing.Point( 30, 50 );
      this.ItemPathLB.Name = "ItemPathLB";
      this.ItemPathLB.Size = new System.Drawing.Size( 128, 20 );
      this.ItemPathLB.TabIndex = 2;
      this.ItemPathLB.Text = "Return Item Path";
      this.ItemPathLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // LocaleSpecifiedCB
      // 
      this.LocaleSpecifiedCB.AutoSize = true;
      this.LocaleSpecifiedCB.Dock = System.Windows.Forms.DockStyle.Fill;
      this.LocaleSpecifiedCB.Location = new System.Drawing.Point( 3, 3 );
      this.LocaleSpecifiedCB.Name = "LocaleSpecifiedCB";
      this.LocaleSpecifiedCB.Size = new System.Drawing.Size( 21, 24 );
      this.LocaleSpecifiedCB.TabIndex = 16;
      this.LocaleSpecifiedCB.CheckedChanged += new System.EventHandler( this.LocaleSpecifiedCB_CheckedChanged );
      // 
      // LocaleCTRL
      // 
      this.LocaleCTRL.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.LocaleCTRL.Dock = System.Windows.Forms.DockStyle.Fill;
      this.LocaleCTRL.Enabled = false;
      this.LocaleCTRL.Locale = "";
      this.LocaleCTRL.Location = new System.Drawing.Point( 164, 3 );
      this.LocaleCTRL.Name = "LocaleCTRL";
      this.LocaleCTRL.Size = new System.Drawing.Size( 99, 24 );
      this.LocaleCTRL.TabIndex = 15;
      // 
      // LocaleLB
      // 
      this.LocaleLB.Dock = System.Windows.Forms.DockStyle.Fill;
      this.LocaleLB.Location = new System.Drawing.Point( 30, 0 );
      this.LocaleLB.Name = "LocaleLB";
      this.LocaleLB.Size = new System.Drawing.Size( 128, 30 );
      this.LocaleLB.TabIndex = 14;
      this.LocaleLB.Text = "Locale";
      this.LocaleLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // ClientHandleCB
      // 
      this.ClientHandleCB.AutoSize = true;
      this.ClientHandleCB.Checked = true;
      this.ClientHandleCB.CheckState = System.Windows.Forms.CheckState.Checked;
      this.ClientHandleCB.Dock = System.Windows.Forms.DockStyle.Fill;
      this.ClientHandleCB.Location = new System.Drawing.Point( 3, 73 );
      this.ClientHandleCB.Name = "ClientHandleCB";
      this.ClientHandleCB.Size = new System.Drawing.Size( 21, 14 );
      this.ClientHandleCB.TabIndex = 5;
      // 
      // ItemPathCB
      // 
      this.ItemPathCB.AutoSize = true;
      this.ItemPathCB.Checked = true;
      this.ItemPathCB.CheckState = System.Windows.Forms.CheckState.Checked;
      this.ItemPathCB.Dock = System.Windows.Forms.DockStyle.Fill;
      this.ItemPathCB.Location = new System.Drawing.Point( 3, 53 );
      this.ItemPathCB.Name = "ItemPathCB";
      this.ItemPathCB.Size = new System.Drawing.Size( 21, 14 );
      this.ItemPathCB.TabIndex = 3;
      // 
      // ItemNameCB
      // 
      this.ItemNameCB.AutoSize = true;
      this.ItemNameCB.Checked = true;
      this.ItemNameCB.CheckState = System.Windows.Forms.CheckState.Checked;
      this.ItemNameCB.Dock = System.Windows.Forms.DockStyle.Fill;
      this.ItemNameCB.Location = new System.Drawing.Point( 3, 33 );
      this.ItemNameCB.Name = "ItemNameCB";
      this.ItemNameCB.Size = new System.Drawing.Size( 21, 14 );
      this.ItemNameCB.TabIndex = 1;
      // 
      // DiagnosticInfoCB
      // 
      this.DiagnosticInfoCB.AutoSize = true;
      this.DiagnosticInfoCB.Checked = true;
      this.DiagnosticInfoCB.CheckState = System.Windows.Forms.CheckState.Checked;
      this.DiagnosticInfoCB.Dock = System.Windows.Forms.DockStyle.Fill;
      this.DiagnosticInfoCB.Location = new System.Drawing.Point( 3, 133 );
      this.DiagnosticInfoCB.Name = "DiagnosticInfoCB";
      this.DiagnosticInfoCB.Size = new System.Drawing.Size( 21, 14 );
      this.DiagnosticInfoCB.TabIndex = 13;
      // 
      // ErrorTextCB
      // 
      this.ErrorTextCB.AutoSize = true;
      this.ErrorTextCB.Checked = true;
      this.ErrorTextCB.CheckState = System.Windows.Forms.CheckState.Checked;
      this.ErrorTextCB.Dock = System.Windows.Forms.DockStyle.Fill;
      this.ErrorTextCB.Location = new System.Drawing.Point( 3, 113 );
      this.ErrorTextCB.Name = "ErrorTextCB";
      this.ErrorTextCB.Size = new System.Drawing.Size( 21, 14 );
      this.ErrorTextCB.TabIndex = 11;
      // 
      // ClientHandleLB
      // 
      this.ClientHandleLB.AutoSize = true;
      this.ClientHandleLB.Dock = System.Windows.Forms.DockStyle.Fill;
      this.ClientHandleLB.Location = new System.Drawing.Point( 30, 70 );
      this.ClientHandleLB.Name = "ClientHandleLB";
      this.ClientHandleLB.Size = new System.Drawing.Size( 128, 20 );
      this.ClientHandleLB.TabIndex = 4;
      this.ClientHandleLB.Text = "Return Client Handle";
      this.ClientHandleLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // DiagnosticInfoLB
      // 
      this.DiagnosticInfoLB.AutoSize = true;
      this.DiagnosticInfoLB.Dock = System.Windows.Forms.DockStyle.Fill;
      this.DiagnosticInfoLB.Location = new System.Drawing.Point( 30, 130 );
      this.DiagnosticInfoLB.Name = "DiagnosticInfoLB";
      this.DiagnosticInfoLB.Size = new System.Drawing.Size( 128, 20 );
      this.DiagnosticInfoLB.TabIndex = 12;
      this.DiagnosticInfoLB.Text = "Return Diagnostic Info";
      this.DiagnosticInfoLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // ErrorTextLB
      // 
      this.ErrorTextLB.AutoSize = true;
      this.ErrorTextLB.Dock = System.Windows.Forms.DockStyle.Fill;
      this.ErrorTextLB.Location = new System.Drawing.Point( 30, 110 );
      this.ErrorTextLB.Name = "ErrorTextLB";
      this.ErrorTextLB.Size = new System.Drawing.Size( 128, 20 );
      this.ErrorTextLB.TabIndex = 10;
      this.ErrorTextLB.Text = "Return Error Text";
      this.ErrorTextLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // toolStripContainer1
      // 
      // 
      // toolStripContainer1.BottomToolStripPanel
      // 
      this.toolStripContainer1.BottomToolStripPanel.Controls.Add( m_ToolStrip );
      // 
      // toolStripContainer1.ContentPanel
      // 
      this.toolStripContainer1.ContentPanel.Controls.Add( this.tableLayoutPanel1 );
      this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size( 266, 179 );
      this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.toolStripContainer1.LeftToolStripPanelVisible = false;
      this.toolStripContainer1.Location = new System.Drawing.Point( 0, 0 );
      this.toolStripContainer1.Name = "toolStripContainer1";
      this.toolStripContainer1.RightToolStripPanelVisible = false;
      this.toolStripContainer1.Size = new System.Drawing.Size( 266, 204 );
      this.toolStripContainer1.TabIndex = 17;
      this.toolStripContainer1.Text = "toolStripContainer1";
      // 
      // m_ToolStrip
      // 
      m_ToolStrip.Dock = System.Windows.Forms.DockStyle.None;
      m_ToolStrip.Items.AddRange( new System.Windows.Forms.ToolStripItem[] {
            m_TSB_OK,
            this.m_TSM_Cancel} );
      m_ToolStrip.Location = new System.Drawing.Point( 3, 0 );
      m_ToolStrip.Name = "m_ToolStrip";
      m_ToolStrip.Size = new System.Drawing.Size( 243, 25 );
      m_ToolStrip.TabIndex = 0;
      // 
      // m_TSB_OK
      // 
      m_TSB_OK.AutoSize = false;
      m_TSB_OK.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
      m_TSB_OK.Image = ( (System.Drawing.Image)( resources.GetObject( "m_TSB_OK.Image" ) ) );
      m_TSB_OK.ImageTransparentColor = System.Drawing.Color.Magenta;
      m_TSB_OK.Name = "m_TSB_OK";
      m_TSB_OK.Size = new System.Drawing.Size( 100, 22 );
      m_TSB_OK.Text = "OK";
      m_TSB_OK.Click += new System.EventHandler( this.m_TSB_OK_Click );
      // 
      // m_TSM_Cancel
      // 
      this.m_TSM_Cancel.AutoSize = false;
      this.m_TSM_Cancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
      this.m_TSM_Cancel.Image = ( (System.Drawing.Image)( resources.GetObject( "m_TSM_Cancel.Image" ) ) );
      this.m_TSM_Cancel.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.m_TSM_Cancel.Name = "m_TSM_Cancel";
      this.m_TSM_Cancel.Size = new System.Drawing.Size( 100, 22 );
      this.m_TSM_Cancel.Text = "CANCEL";
      this.m_TSM_Cancel.Click += new System.EventHandler( this.m_TSM_Cancel_Click );
      // 
      // tableLayoutPanel1
      // 
      this.tableLayoutPanel1.AutoSize = true;
      this.tableLayoutPanel1.ColumnCount = 3;
      this.tableLayoutPanel1.ColumnStyles.Add( new System.Windows.Forms.ColumnStyle( System.Windows.Forms.SizeType.Absolute, 27F ) );
      this.tableLayoutPanel1.ColumnStyles.Add( new System.Windows.Forms.ColumnStyle() );
      this.tableLayoutPanel1.ColumnStyles.Add( new System.Windows.Forms.ColumnStyle() );
      this.tableLayoutPanel1.Controls.Add( this.LocaleCTRL, 2, 0 );
      this.tableLayoutPanel1.Controls.Add( this.ItemNameLB, 1, 1 );
      this.tableLayoutPanel1.Controls.Add( this.DiagnosticInfoLB, 1, 6 );
      this.tableLayoutPanel1.Controls.Add( this.ErrorTextLB, 1, 5 );
      this.tableLayoutPanel1.Controls.Add( this.ItemTimeLB, 1, 4 );
      this.tableLayoutPanel1.Controls.Add( this.ClientHandleLB, 1, 3 );
      this.tableLayoutPanel1.Controls.Add( this.LocaleLB, 1, 0 );
      this.tableLayoutPanel1.Controls.Add( this.ItemPathLB, 1, 2 );
      this.tableLayoutPanel1.Controls.Add( this.LocaleSpecifiedCB, 0, 0 );
      this.tableLayoutPanel1.Controls.Add( this.DiagnosticInfoCB, 0, 6 );
      this.tableLayoutPanel1.Controls.Add( this.ClientHandleCB, 0, 3 );
      this.tableLayoutPanel1.Controls.Add( this.ErrorTextCB, 0, 5 );
      this.tableLayoutPanel1.Controls.Add( this.ItemTimeCB, 0, 4 );
      this.tableLayoutPanel1.Controls.Add( this.ItemPathCB, 0, 2 );
      this.tableLayoutPanel1.Controls.Add( this.ItemNameCB, 0, 1 );
      this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tableLayoutPanel1.Location = new System.Drawing.Point( 0, 0 );
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 8;
      this.tableLayoutPanel1.RowStyles.Add( new System.Windows.Forms.RowStyle() );
      this.tableLayoutPanel1.RowStyles.Add( new System.Windows.Forms.RowStyle() );
      this.tableLayoutPanel1.RowStyles.Add( new System.Windows.Forms.RowStyle() );
      this.tableLayoutPanel1.RowStyles.Add( new System.Windows.Forms.RowStyle() );
      this.tableLayoutPanel1.RowStyles.Add( new System.Windows.Forms.RowStyle() );
      this.tableLayoutPanel1.RowStyles.Add( new System.Windows.Forms.RowStyle() );
      this.tableLayoutPanel1.RowStyles.Add( new System.Windows.Forms.RowStyle() );
      this.tableLayoutPanel1.RowStyles.Add( new System.Windows.Forms.RowStyle() );
      this.tableLayoutPanel1.Size = new System.Drawing.Size( 266, 179 );
      this.tableLayoutPanel1.TabIndex = 17;
      // 
      // OptionsEditDlg
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.AutoSize = true;
      this.ClientSize = new System.Drawing.Size( 266, 204 );
      this.Controls.Add( this.toolStripContainer1 );
      this.Icon = ( (System.Drawing.Icon)( resources.GetObject( "$this.Icon" ) ) );
      this.Name = "OptionsEditDlg";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Edit Options";
      this.toolStripContainer1.BottomToolStripPanel.ResumeLayout( false );
      this.toolStripContainer1.BottomToolStripPanel.PerformLayout();
      this.toolStripContainer1.ContentPanel.ResumeLayout( false );
      this.toolStripContainer1.ContentPanel.PerformLayout();
      this.toolStripContainer1.ResumeLayout( false );
      this.toolStripContainer1.PerformLayout();
      m_ToolStrip.ResumeLayout( false );
      m_ToolStrip.PerformLayout();
      this.tableLayoutPanel1.ResumeLayout( false );
      this.tableLayoutPanel1.PerformLayout();
      this.ResumeLayout( false );

   }
    #endregion

    private System.Windows.Forms.ToolStripContainer toolStripContainer1;
    private System.Windows.Forms.ToolStripButton m_TSM_Cancel;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
  }
}