namespace CAS.Lib.OPCClientControlsLib
{
  partial class SubscriptionManagementDlg
  {
    private System.Windows.Forms.Panel ButtonsPN;/// <summary>
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
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( SubscriptionManagementDlg ) );
      this.m_ItemsCTRL = new CAS.Lib.OPCClientControlsLib.ItemListEditCtrl();
      this.m_ResultsCTRL = new CAS.Lib.OPCClientControlsLib.ResultListViewCtrl();
      this.m_SubscriptionCTRL = new CAS.Lib.OPCClientControlsLib.SubscriptionEditCtrl();
      this.m_BrowseCTRL = new CAS.Lib.OPCClientControlsLib.BrowseTreeCtrl();
      this.ButtonsPN = new System.Windows.Forms.Panel();
      this.OptionsBTN = new System.Windows.Forms.Button();
      this.BackBTN = new System.Windows.Forms.Button();
      this.NextBTN = new System.Windows.Forms.Button();
      this.CancelBTN = new System.Windows.Forms.Button();
      this.DoneBTN = new System.Windows.Forms.Button();
      this.splitContainer1 = new System.Windows.Forms.SplitContainer();
      this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
      this.m_Dictionary = new CAS.Lib.OPC.AddressSpace.DictionaryManagement( this.components );
      this.ButtonsPN.SuspendLayout();
      this.splitContainer1.Panel1.SuspendLayout();
      this.splitContainer1.Panel2.SuspendLayout();
      this.splitContainer1.SuspendLayout();
      this.toolStripContainer1.ContentPanel.SuspendLayout();
      this.toolStripContainer1.SuspendLayout();
      this.SuspendLayout();
      // 
      // m_ItemsCTRL
      // 
      this.m_ItemsCTRL.Dock = System.Windows.Forms.DockStyle.Fill;
      this.m_ItemsCTRL.Location = new System.Drawing.Point( 0, 0 );
      this.m_ItemsCTRL.Name = "m_ItemsCTRL";
      this.m_ItemsCTRL.Size = new System.Drawing.Size( 524, 247 );
      this.m_ItemsCTRL.TabIndex = 1;
      // 
      // m_ResultsCTRL
      // 
      this.m_ResultsCTRL.AllowDrop = true;
      this.m_ResultsCTRL.Dock = System.Windows.Forms.DockStyle.Fill;
      this.m_ResultsCTRL.Location = new System.Drawing.Point( 0, 0 );
      this.m_ResultsCTRL.Name = "m_ResultsCTRL";
      this.m_ResultsCTRL.Size = new System.Drawing.Size( 524, 247 );
      this.m_ResultsCTRL.TabIndex = 0;
      // 
      // m_SubscriptionCTRL
      // 
      this.m_SubscriptionCTRL.Dock = System.Windows.Forms.DockStyle.Fill;
      this.m_SubscriptionCTRL.Location = new System.Drawing.Point( 0, 0 );
      this.m_SubscriptionCTRL.Name = "m_SubscriptionCTRL";
      this.m_SubscriptionCTRL.Size = new System.Drawing.Size( 264, 247 );
      this.m_SubscriptionCTRL.TabIndex = 1;
      // 
      // m_BrowseCTRL
      // 
      this.m_BrowseCTRL.Dock = System.Windows.Forms.DockStyle.Fill;
      this.m_BrowseCTRL.Location = new System.Drawing.Point( 0, 0 );
      this.m_BrowseCTRL.Name = "m_BrowseCTRL";
      this.m_BrowseCTRL.Size = new System.Drawing.Size( 264, 247 );
      this.m_BrowseCTRL.TabIndex = 0;
      // 
      // ButtonsPN
      // 
      this.ButtonsPN.Controls.Add( this.OptionsBTN );
      this.ButtonsPN.Controls.Add( this.BackBTN );
      this.ButtonsPN.Controls.Add( this.NextBTN );
      this.ButtonsPN.Controls.Add( this.CancelBTN );
      this.ButtonsPN.Controls.Add( this.DoneBTN );
      this.ButtonsPN.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.ButtonsPN.Location = new System.Drawing.Point( 0, 272 );
      this.ButtonsPN.Name = "ButtonsPN";
      this.ButtonsPN.Size = new System.Drawing.Size( 792, 36 );
      this.ButtonsPN.TabIndex = 0;
      // 
      // OptionsBTN
      // 
      this.OptionsBTN.Location = new System.Drawing.Point( 5, 8 );
      this.OptionsBTN.Name = "OptionsBTN";
      this.OptionsBTN.Size = new System.Drawing.Size( 75, 23 );
      this.OptionsBTN.TabIndex = 8;
      this.OptionsBTN.Text = "Options...";
      this.OptionsBTN.Click += new System.EventHandler( this.BTN_Options_Click );
      // 
      // BackBTN
      // 
      this.BackBTN.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
      this.BackBTN.Location = new System.Drawing.Point( 552, 8 );
      this.BackBTN.Name = "BackBTN";
      this.BackBTN.Size = new System.Drawing.Size( 75, 23 );
      this.BackBTN.TabIndex = 3;
      this.BackBTN.Text = "< Back";
      this.BackBTN.Click += new System.EventHandler( this.BTN_Back_Click );
      // 
      // NextBTN
      // 
      this.NextBTN.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
      this.NextBTN.Location = new System.Drawing.Point( 632, 8 );
      this.NextBTN.Name = "NextBTN";
      this.NextBTN.Size = new System.Drawing.Size( 75, 23 );
      this.NextBTN.TabIndex = 2;
      this.NextBTN.Text = "Next >";
      this.NextBTN.Click += new System.EventHandler( this.BTN_Next_Click );
      // 
      // CancelBTN
      // 
      this.CancelBTN.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
      this.CancelBTN.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.CancelBTN.Location = new System.Drawing.Point( 712, 8 );
      this.CancelBTN.Name = "CancelBTN";
      this.CancelBTN.Size = new System.Drawing.Size( 75, 23 );
      this.CancelBTN.TabIndex = 4;
      this.CancelBTN.Text = "Cancel";
      this.CancelBTN.Click += new System.EventHandler( this.CancelBTN_Click );
      // 
      // DoneBTN
      // 
      this.DoneBTN.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
      this.DoneBTN.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.DoneBTN.Location = new System.Drawing.Point( 632, 8 );
      this.DoneBTN.Name = "DoneBTN";
      this.DoneBTN.Size = new System.Drawing.Size( 75, 23 );
      this.DoneBTN.TabIndex = 0;
      this.DoneBTN.Text = "Done";
      this.DoneBTN.Click += new System.EventHandler( this.BTN_Done_Click );
      // 
      // splitContainer1
      // 
      this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.splitContainer1.Location = new System.Drawing.Point( 0, 0 );
      this.splitContainer1.Name = "splitContainer1";
      // 
      // splitContainer1.Panel1
      // 
      this.splitContainer1.Panel1.Controls.Add( this.m_SubscriptionCTRL );
      this.splitContainer1.Panel1.Controls.Add( this.m_BrowseCTRL );
      // 
      // splitContainer1.Panel2
      // 
      this.splitContainer1.Panel2.Controls.Add( this.m_ItemsCTRL );
      this.splitContainer1.Panel2.Controls.Add( this.m_ResultsCTRL );
      this.splitContainer1.Size = new System.Drawing.Size( 792, 247 );
      this.splitContainer1.SplitterDistance = 264;
      this.splitContainer1.TabIndex = 2;
      // 
      // toolStripContainer1
      // 
      // 
      // toolStripContainer1.ContentPanel
      // 
      this.toolStripContainer1.ContentPanel.Controls.Add( this.splitContainer1 );
      this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size( 792, 247 );
      this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.toolStripContainer1.Location = new System.Drawing.Point( 0, 0 );
      this.toolStripContainer1.Name = "toolStripContainer1";
      this.toolStripContainer1.Size = new System.Drawing.Size( 792, 272 );
      this.toolStripContainer1.TabIndex = 2;
      this.toolStripContainer1.Text = "toolStripContainer1";
      // 
      // m_Dictionary
      // 
      this.m_Dictionary.DefaultFileName = "Dictionary";
      // 
      // SubscriptionManagementDlg
      // 
      this.AcceptButton = this.DoneBTN;
      this.AutoScaleBaseSize = new System.Drawing.Size( 5, 13 );
      this.CancelButton = this.CancelBTN;
      this.ClientSize = new System.Drawing.Size( 792, 308 );
      this.Controls.Add( this.toolStripContainer1 );
      this.Controls.Add( this.ButtonsPN );
      this.HelpButton = true;
      this.Icon = ( (System.Drawing.Icon)( resources.GetObject( "$this.Icon" ) ) );
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "SubscriptionManagementDlg";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Create Subscription";
      this.HelpButtonClicked += new System.ComponentModel.CancelEventHandler( this.SubscriptionManagementDlg_HelpButtonClicked );
      this.ButtonsPN.ResumeLayout( false );
      this.splitContainer1.Panel1.ResumeLayout( false );
      this.splitContainer1.Panel2.ResumeLayout( false );
      this.splitContainer1.ResumeLayout( false );
      this.toolStripContainer1.ContentPanel.ResumeLayout( false );
      this.toolStripContainer1.ResumeLayout( false );
      this.toolStripContainer1.PerformLayout();
      this.ResumeLayout( false );

    }

    #endregion

    private System.Windows.Forms.SplitContainer splitContainer1;
    private System.Windows.Forms.ToolStripContainer toolStripContainer1;
    protected SubscriptionEditCtrl m_SubscriptionCTRL;
    protected BrowseTreeCtrl m_BrowseCTRL;
    protected CAS.Lib.OPC.AddressSpace.DictionaryManagement m_Dictionary;
    protected internal System.Windows.Forms.Button BackBTN;
    protected internal System.Windows.Forms.Button DoneBTN;
    protected internal System.Windows.Forms.Button CancelBTN;
    protected internal System.Windows.Forms.Button OptionsBTN;
    protected internal System.Windows.Forms.Button NextBTN;
    protected internal ResultListViewCtrl m_ResultsCTRL;
    protected internal ItemListEditCtrl m_ItemsCTRL;
  }
}