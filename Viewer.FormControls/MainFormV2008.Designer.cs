namespace CAS.Lib.OPCClientControlsLib
{
  partial class MainFormV2008
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;
    private System.Windows.Forms.RichTextBox m_OutputCTRL;
    private CAS.Lib.OPCClientControlsLib.SelectServerStrip SelectTargetCTRL;
    private CAS.Lib.OPCClientControlsLib.ServerStatusStrip m_StatusCTRL;
    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose( bool disposing )
    {
      if ( disposing && ( components != null ) )
        components.Dispose();
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
      System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
      System.Windows.Forms.ToolStripMenuItem m_TSMI_Session_Exit;
      System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( MainFormV2008 ) );
      System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
      System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6;
      System.Windows.Forms.ToolStrip m_ToolStrip;
      this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripMenuItem();
      this.m_TSM_SessionLoad = new System.Windows.Forms.ToolStripButton();
      this.m_TSB_SessionSave = new System.Windows.Forms.ToolStripButton();
      this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
      this.toolStripButtonConnect = new System.Windows.Forms.ToolStripButton();
      this.m_TSB_Disconnect = new System.Windows.Forms.ToolStripButton();
      this.m_TSB_GetServerStatus = new System.Windows.Forms.ToolStripButton();
      this.toolStripSeparator14 = new System.Windows.Forms.ToolStripSeparator();
      this.toolStripButtonBrowse = new System.Windows.Forms.ToolStripButton();
      this.toolStripButtonReadItems = new System.Windows.Forms.ToolStripButton();
      this.toolStripButtonWriteItems = new System.Windows.Forms.ToolStripButton();
      this.toolStripSeparator13 = new System.Windows.Forms.ToolStripSeparator();
      this.toolStripButtonSupport = new System.Windows.Forms.ToolStripButton();
      this.toolStripButtonShowOnlineHelp = new System.Windows.Forms.ToolStripButton();
      this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
      this.toolStripButtonShowAboutDialog = new System.Windows.Forms.ToolStripButton();
      this.m_TSMI_Session = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
      this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
      this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
      this.m_OutputCTRL = new System.Windows.Forms.RichTextBox();
      this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
      this.splitContainer1 = new System.Windows.Forms.SplitContainer();
      this.m_MainTabControl = new System.Windows.Forms.TabControl();
      this.m_tabPage_OPC_Environment = new System.Windows.Forms.TabPage();
      this.m_TabPage_ProcessingEnvironment = new System.Windows.Forms.TabPage();
      this.m_DebugTabPage = new System.Windows.Forms.TabPage();
      this.m_MainMenu = new System.Windows.Forms.MenuStrip();
      this.m_TSMIServer = new System.Windows.Forms.ToolStripMenuItem();
      this.m_TSMI_Browse = new System.Windows.Forms.ToolStripMenuItem();
      this.m_TSMIConnect = new System.Windows.Forms.ToolStripMenuItem();
      this.m_TSM_IDisconnect = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
      this.m_TSM_Status = new System.Windows.Forms.ToolStripMenuItem();
      this.TSMIBrowse = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItem10 = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItem11 = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
      this.TSMIRead = new System.Windows.Forms.ToolStripMenuItem();
      this.TSMIWrite = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
      this.TSMITest = new System.Windows.Forms.ToolStripMenuItem();
      this.TSMIItem1 = new System.Windows.Forms.ToolStripMenuItem();
      this.TSMIClear = new System.Windows.Forms.ToolStripMenuItem();
      this.m_TSMI_DebugOn = new System.Windows.Forms.ToolStripMenuItem();
      this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.dCOMConfigurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.TSMIHelp = new System.Windows.Forms.ToolStripMenuItem();
      this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItemSupport = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
      this.TSMIAbout = new System.Windows.Forms.ToolStripMenuItem();
      this.licenseInformationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.openLogsContainingFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.enterTheUnlockCodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.TSMIOptions = new System.Windows.Forms.ToolStripMenuItem();
      this.TSMIProxyServer = new System.Windows.Forms.ToolStripMenuItem();
      this.TSMIClearHistory = new System.Windows.Forms.ToolStripMenuItem();
      this.serviceControlToolStrip_DataPorter = new CAS.Lib.ControlLibrary.ServiceControlToolStrip();
      this.m_SaveFileDialog = new System.Windows.Forms.SaveFileDialog();
      this.m_OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
      this.m_textBoxBaseTraceListener = new CAS.Lib.ControlLibrary.TextBoxBaseWithTraceListener();
      this.m_StatusCTRL = new CAS.Lib.OPCClientControlsLib.ServerStatusStrip();
      this.m_SubscriptionCTRL = new CAS.Lib.OPCClientControlsLib.SessionTreeControl();
      this.m_UpdatesCTRL = new CAS.Lib.OPCClientControlsLib.UpdatesViewCtrl();
      this.SelectTargetCTRL = new CAS.Lib.OPCClientControlsLib.SelectServerStrip();
      this.m_SelectServerStrip = new CAS.Lib.OPCClientControlsLib.SelectServerStrip();
      this.maintenanceControlComponent = new CAS.Lib.CodeProtect.MaintenanceControlComponent( this.components );
      toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
      m_TSMI_Session_Exit = new System.Windows.Forms.ToolStripMenuItem();
      toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
      toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
      toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
      m_ToolStrip = new System.Windows.Forms.ToolStrip();
      m_ToolStrip.SuspendLayout();
      this.toolStripContainer1.BottomToolStripPanel.SuspendLayout();
      this.toolStripContainer1.ContentPanel.SuspendLayout();
      this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
      this.toolStripContainer1.SuspendLayout();
      this.splitContainer1.Panel1.SuspendLayout();
      this.splitContainer1.Panel2.SuspendLayout();
      this.splitContainer1.SuspendLayout();
      this.m_MainTabControl.SuspendLayout();
      this.m_tabPage_OPC_Environment.SuspendLayout();
      this.m_DebugTabPage.SuspendLayout();
      this.m_MainMenu.SuspendLayout();
      this.SuspendLayout();
      // 
      // toolStripSeparator7
      // 
      toolStripSeparator7.Name = "toolStripSeparator7";
      toolStripSeparator7.Size = new System.Drawing.Size( 89, 6 );
      // 
      // m_TSMI_Session_Exit
      // 
      m_TSMI_Session_Exit.Name = "m_TSMI_Session_Exit";
      m_TSMI_Session_Exit.Size = new System.Drawing.Size( 92, 22 );
      m_TSMI_Session_Exit.Text = "&Exit";
      m_TSMI_Session_Exit.ToolTipText = "Exit application";
      m_TSMI_Session_Exit.Click += new System.EventHandler( this.TSMI_File_Exit_Click );
      // 
      // toolStripMenuItem1
      // 
      toolStripMenuItem1.Image = ( (System.Drawing.Image)( resources.GetObject( "toolStripMenuItem1.Image" ) ) );
      toolStripMenuItem1.Name = "toolStripMenuItem1";
      toolStripMenuItem1.Size = new System.Drawing.Size( 226, 22 );
      toolStripMenuItem1.Text = "Home";
      toolStripMenuItem1.ToolTipText = "Home website";
      toolStripMenuItem1.Click += new System.EventHandler( this.TSMI_OpenWebPage_Click );
      // 
      // toolStripMenuItem5
      // 
      toolStripMenuItem5.DropDownItems.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem7,
            toolStripMenuItem6,
            this.toolStripMenuItem8} );
      toolStripMenuItem5.Name = "toolStripMenuItem5";
      toolStripMenuItem5.Size = new System.Drawing.Size( 167, 22 );
      toolStripMenuItem5.Text = "Co&nfiguration";
      toolStripMenuItem5.ToolTipText = "Save and restore the selected server configuration in an external file";
      // 
      // toolStripMenuItem7
      // 
      this.toolStripMenuItem7.Image = ( (System.Drawing.Image)( resources.GetObject( "toolStripMenuItem7.Image" ) ) );
      this.toolStripMenuItem7.Name = "toolStripMenuItem7";
      this.toolStripMenuItem7.Size = new System.Drawing.Size( 121, 22 );
      this.toolStripMenuItem7.Text = "&Load...";
      this.toolStripMenuItem7.ToolTipText = "Restore and add the server to the current session from a selected configuration f" +
          "ile. ";
      this.toolStripMenuItem7.Click += new System.EventHandler( this.TSMI_Server_Load_Click );
      // 
      // toolStripMenuItem6
      // 
      toolStripMenuItem6.Image = ( (System.Drawing.Image)( resources.GetObject( "toolStripMenuItem6.Image" ) ) );
      toolStripMenuItem6.Name = "toolStripMenuItem6";
      toolStripMenuItem6.Size = new System.Drawing.Size( 121, 22 );
      toolStripMenuItem6.Text = "&Save";
      toolStripMenuItem6.ToolTipText = "Save the selected server in a configuration file.";
      toolStripMenuItem6.Click += new System.EventHandler( this.TSMI_Server_Save_Click );
      // 
      // toolStripMenuItem8
      // 
      this.toolStripMenuItem8.Name = "toolStripMenuItem8";
      this.toolStripMenuItem8.Size = new System.Drawing.Size( 121, 22 );
      this.toolStripMenuItem8.Text = "Save as...";
      this.toolStripMenuItem8.ToolTipText = "Save as the selected server in a configuration file.";
      this.toolStripMenuItem8.Click += new System.EventHandler( this.TSMI_Server_SaveAs_Click );
      // 
      // m_ToolStrip
      // 
      m_ToolStrip.Dock = System.Windows.Forms.DockStyle.None;
      m_ToolStrip.Items.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.m_TSM_SessionLoad,
            this.m_TSB_SessionSave,
            this.toolStripSeparator11,
            this.toolStripButtonConnect,
            this.m_TSB_Disconnect,
            this.m_TSB_GetServerStatus,
            this.toolStripSeparator14,
            this.toolStripButtonBrowse,
            this.toolStripButtonReadItems,
            this.toolStripButtonWriteItems,
            this.toolStripSeparator13,
            this.toolStripButtonSupport,
            this.toolStripButtonShowOnlineHelp,
            this.toolStripSeparator4,
            this.toolStripButtonShowAboutDialog} );
      m_ToolStrip.Location = new System.Drawing.Point( 3, 24 );
      m_ToolStrip.Name = "m_ToolStrip";
      m_ToolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
      m_ToolStrip.Size = new System.Drawing.Size( 289, 25 );
      m_ToolStrip.TabIndex = 7;
      // 
      // m_TSM_SessionLoad
      // 
      this.m_TSM_SessionLoad.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.m_TSM_SessionLoad.Image = ( (System.Drawing.Image)( resources.GetObject( "m_TSM_SessionLoad.Image" ) ) );
      this.m_TSM_SessionLoad.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.m_TSM_SessionLoad.Name = "m_TSM_SessionLoad";
      this.m_TSM_SessionLoad.Size = new System.Drawing.Size( 23, 22 );
      this.m_TSM_SessionLoad.Text = "Load";
      this.m_TSM_SessionLoad.ToolTipText = "Load and restore a session from the selected configuration file. ";
      this.m_TSM_SessionLoad.Click += new System.EventHandler( this.TSMI_Session_Open_Click );
      // 
      // m_TSB_SessionSave
      // 
      this.m_TSB_SessionSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.m_TSB_SessionSave.Image = ( (System.Drawing.Image)( resources.GetObject( "m_TSB_SessionSave.Image" ) ) );
      this.m_TSB_SessionSave.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.m_TSB_SessionSave.Name = "m_TSB_SessionSave";
      this.m_TSB_SessionSave.Size = new System.Drawing.Size( 23, 22 );
      this.m_TSB_SessionSave.Text = "&Save";
      this.m_TSB_SessionSave.ToolTipText = "Save the current session in a configuration file";
      this.m_TSB_SessionSave.Click += new System.EventHandler( this.TSMI_Session_Save_Click );
      // 
      // toolStripSeparator11
      // 
      this.toolStripSeparator11.Name = "toolStripSeparator11";
      this.toolStripSeparator11.Size = new System.Drawing.Size( 6, 25 );
      // 
      // toolStripButtonConnect
      // 
      this.toolStripButtonConnect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.toolStripButtonConnect.Image = ( (System.Drawing.Image)( resources.GetObject( "toolStripButtonConnect.Image" ) ) );
      this.toolStripButtonConnect.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.toolStripButtonConnect.Name = "toolStripButtonConnect";
      this.toolStripButtonConnect.Size = new System.Drawing.Size( 23, 22 );
      this.toolStripButtonConnect.Text = "&Connect";
      this.toolStripButtonConnect.ToolTipText = "Connect to Server";
      this.toolStripButtonConnect.Click += new System.EventHandler( this.TSMI_Server_Connect_Click );
      // 
      // m_TSB_Disconnect
      // 
      this.m_TSB_Disconnect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.m_TSB_Disconnect.Enabled = false;
      this.m_TSB_Disconnect.Image = ( (System.Drawing.Image)( resources.GetObject( "m_TSB_Disconnect.Image" ) ) );
      this.m_TSB_Disconnect.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.m_TSB_Disconnect.Name = "m_TSB_Disconnect";
      this.m_TSB_Disconnect.Size = new System.Drawing.Size( 23, 22 );
      this.m_TSB_Disconnect.Text = "Disconnect";
      this.m_TSB_Disconnect.ToolTipText = "Disconnect from Server";
      this.m_TSB_Disconnect.Click += new System.EventHandler( this.TSMI_Server_Disconnect_Click );
      // 
      // m_TSB_GetServerStatus
      // 
      this.m_TSB_GetServerStatus.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.m_TSB_GetServerStatus.Enabled = false;
      this.m_TSB_GetServerStatus.Image = ( (System.Drawing.Image)( resources.GetObject( "m_TSB_GetServerStatus.Image" ) ) );
      this.m_TSB_GetServerStatus.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.m_TSB_GetServerStatus.Name = "m_TSB_GetServerStatus";
      this.m_TSB_GetServerStatus.Size = new System.Drawing.Size( 23, 22 );
      this.m_TSB_GetServerStatus.Text = "View Status";
      this.m_TSB_GetServerStatus.ToolTipText = "View Server Status";
      this.m_TSB_GetServerStatus.Click += new System.EventHandler( this.TSMI_Server_ViewStatus_Click );
      // 
      // toolStripSeparator14
      // 
      this.toolStripSeparator14.Name = "toolStripSeparator14";
      this.toolStripSeparator14.Size = new System.Drawing.Size( 6, 25 );
      // 
      // toolStripButtonBrowse
      // 
      this.toolStripButtonBrowse.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.toolStripButtonBrowse.Image = ( (System.Drawing.Image)( resources.GetObject( "toolStripButtonBrowse.Image" ) ) );
      this.toolStripButtonBrowse.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.toolStripButtonBrowse.Name = "toolStripButtonBrowse";
      this.toolStripButtonBrowse.Size = new System.Drawing.Size( 23, 22 );
      this.toolStripButtonBrowse.Text = "Browse...";
      this.toolStripButtonBrowse.ToolTipText = "Browse Address Space";
      this.toolStripButtonBrowse.Click += new System.EventHandler( this.TSMI_Server_ExportDictionary_Click );
      // 
      // toolStripButtonReadItems
      // 
      this.toolStripButtonReadItems.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.toolStripButtonReadItems.Image = ( (System.Drawing.Image)( resources.GetObject( "toolStripButtonReadItems.Image" ) ) );
      this.toolStripButtonReadItems.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.toolStripButtonReadItems.Name = "toolStripButtonReadItems";
      this.toolStripButtonReadItems.Size = new System.Drawing.Size( 23, 22 );
      this.toolStripButtonReadItems.Text = "Read...";
      this.toolStripButtonReadItems.ToolTipText = "Read Items";
      this.toolStripButtonReadItems.Click += new System.EventHandler( this.TSMI_Server_Read_Click );
      // 
      // toolStripButtonWriteItems
      // 
      this.toolStripButtonWriteItems.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.toolStripButtonWriteItems.Image = ( (System.Drawing.Image)( resources.GetObject( "toolStripButtonWriteItems.Image" ) ) );
      this.toolStripButtonWriteItems.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.toolStripButtonWriteItems.Name = "toolStripButtonWriteItems";
      this.toolStripButtonWriteItems.Size = new System.Drawing.Size( 23, 22 );
      this.toolStripButtonWriteItems.Text = "Write...";
      this.toolStripButtonWriteItems.ToolTipText = "Write Items";
      this.toolStripButtonWriteItems.Click += new System.EventHandler( this.TSMI_Server_Write_Click );
      // 
      // toolStripSeparator13
      // 
      this.toolStripSeparator13.Name = "toolStripSeparator13";
      this.toolStripSeparator13.Size = new System.Drawing.Size( 6, 25 );
      // 
      // toolStripButtonSupport
      // 
      this.toolStripButtonSupport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.toolStripButtonSupport.Image = ( (System.Drawing.Image)( resources.GetObject( "toolStripButtonSupport.Image" ) ) );
      this.toolStripButtonSupport.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.toolStripButtonSupport.Name = "toolStripButtonSupport";
      this.toolStripButtonSupport.Size = new System.Drawing.Size( 23, 22 );
      this.toolStripButtonSupport.Text = "Support";
      this.toolStripButtonSupport.ToolTipText = "Feed back and technical support product email.";
      this.toolStripButtonSupport.Click += new System.EventHandler( this.TSMI_Support_Click );
      // 
      // toolStripButtonShowOnlineHelp
      // 
      this.toolStripButtonShowOnlineHelp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.toolStripButtonShowOnlineHelp.Image = ( (System.Drawing.Image)( resources.GetObject( "toolStripButtonShowOnlineHelp.Image" ) ) );
      this.toolStripButtonShowOnlineHelp.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.toolStripButtonShowOnlineHelp.Name = "toolStripButtonShowOnlineHelp";
      this.toolStripButtonShowOnlineHelp.Size = new System.Drawing.Size( 23, 22 );
      this.toolStripButtonShowOnlineHelp.Text = "Help";
      this.toolStripButtonShowOnlineHelp.ToolTipText = "Open Online Help";
      this.toolStripButtonShowOnlineHelp.Click += new System.EventHandler( this.TSMI_ShowOnlineHelp_Click );
      // 
      // toolStripSeparator4
      // 
      this.toolStripSeparator4.Name = "toolStripSeparator4";
      this.toolStripSeparator4.Size = new System.Drawing.Size( 6, 25 );
      // 
      // toolStripButtonShowAboutDialog
      // 
      this.toolStripButtonShowAboutDialog.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.toolStripButtonShowAboutDialog.Image = ( (System.Drawing.Image)( resources.GetObject( "toolStripButtonShowAboutDialog.Image" ) ) );
      this.toolStripButtonShowAboutDialog.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.toolStripButtonShowAboutDialog.Name = "toolStripButtonShowAboutDialog";
      this.toolStripButtonShowAboutDialog.Size = new System.Drawing.Size( 23, 22 );
      this.toolStripButtonShowAboutDialog.Text = "About...";
      this.toolStripButtonShowAboutDialog.ToolTipText = "Show About Dialog";
      this.toolStripButtonShowAboutDialog.Click += new System.EventHandler( this.AboutMI_Click );
      // 
      // m_TSMI_Session
      // 
      this.m_TSMI_Session.DropDownItems.AddRange( new System.Windows.Forms.ToolStripItem[] {
            m_TSMI_Session_Exit,
            toolStripSeparator7} );
      this.m_TSMI_Session.Name = "m_TSMI_Session";
      this.m_TSMI_Session.Size = new System.Drawing.Size( 58, 20 );
      this.m_TSMI_Session.Text = "&Session";
      this.m_TSMI_Session.ToolTipText = "Save and restore the session from external file.";
      // 
      // toolStripSeparator2
      // 
      this.toolStripSeparator2.Name = "toolStripSeparator2";
      this.toolStripSeparator2.Size = new System.Drawing.Size( 6, 27 );
      // 
      // toolStripSeparator
      // 
      this.toolStripSeparator.Name = "toolStripSeparator";
      this.toolStripSeparator.Size = new System.Drawing.Size( 6, 27 );
      // 
      // toolStripSeparator1
      // 
      this.toolStripSeparator1.Name = "toolStripSeparator1";
      this.toolStripSeparator1.Size = new System.Drawing.Size( 6, 27 );
      // 
      // m_OutputCTRL
      // 
      this.m_OutputCTRL.Dock = System.Windows.Forms.DockStyle.Fill;
      this.m_OutputCTRL.Location = new System.Drawing.Point( 3, 3 );
      this.m_OutputCTRL.Name = "m_OutputCTRL";
      this.m_OutputCTRL.Size = new System.Drawing.Size( 658, 464 );
      this.m_OutputCTRL.TabIndex = 0;
      this.m_OutputCTRL.Text = "";
      // 
      // toolStripContainer1
      // 
      // 
      // toolStripContainer1.BottomToolStripPanel
      // 
      this.toolStripContainer1.BottomToolStripPanel.Controls.Add( this.m_StatusCTRL );
      // 
      // toolStripContainer1.ContentPanel
      // 
      this.toolStripContainer1.ContentPanel.Controls.Add( this.splitContainer1 );
      this.toolStripContainer1.ContentPanel.Controls.Add( this.SelectTargetCTRL );
      this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size( 1014, 496 );
      this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.toolStripContainer1.Location = new System.Drawing.Point( 3, 0 );
      this.toolStripContainer1.Name = "toolStripContainer1";
      this.toolStripContainer1.Size = new System.Drawing.Size( 1014, 617 );
      this.toolStripContainer1.TabIndex = 1;
      this.toolStripContainer1.Text = "toolStripContainer1";
      // 
      // toolStripContainer1.TopToolStripPanel
      // 
      this.toolStripContainer1.TopToolStripPanel.Controls.Add( this.m_MainMenu );
      this.toolStripContainer1.TopToolStripPanel.Controls.Add( m_ToolStrip );
      this.toolStripContainer1.TopToolStripPanel.Controls.Add( this.serviceControlToolStrip_DataPorter );
      this.toolStripContainer1.TopToolStripPanel.Controls.Add( this.m_SelectServerStrip );
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
      // 
      // splitContainer1.Panel2
      // 
      this.splitContainer1.Panel2.Controls.Add( this.m_MainTabControl );
      this.splitContainer1.Size = new System.Drawing.Size( 1014, 496 );
      this.splitContainer1.SplitterDistance = 338;
      this.splitContainer1.TabIndex = 1;
      // 
      // m_MainTabControl
      // 
      this.m_MainTabControl.Controls.Add( this.m_tabPage_OPC_Environment );
      this.m_MainTabControl.Controls.Add( this.m_TabPage_ProcessingEnvironment );
      this.m_MainTabControl.Controls.Add( this.m_DebugTabPage );
      this.m_MainTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
      this.m_MainTabControl.Location = new System.Drawing.Point( 0, 0 );
      this.m_MainTabControl.Name = "m_MainTabControl";
      this.m_MainTabControl.SelectedIndex = 0;
      this.m_MainTabControl.Size = new System.Drawing.Size( 672, 496 );
      this.m_MainTabControl.TabIndex = 1;
      // 
      // m_tabPage_OPC_Environment
      // 
      this.m_tabPage_OPC_Environment.Controls.Add( this.m_UpdatesCTRL );
      this.m_tabPage_OPC_Environment.Location = new System.Drawing.Point( 4, 22 );
      this.m_tabPage_OPC_Environment.Name = "m_tabPage_OPC_Environment";
      this.m_tabPage_OPC_Environment.Padding = new System.Windows.Forms.Padding( 3 );
      this.m_tabPage_OPC_Environment.Size = new System.Drawing.Size( 664, 470 );
      this.m_tabPage_OPC_Environment.TabIndex = 0;
      this.m_tabPage_OPC_Environment.Text = "OPC Environment";
      this.m_tabPage_OPC_Environment.UseVisualStyleBackColor = true;
      // 
      // m_TabPage_ProcessingEnvironment
      // 
      this.m_TabPage_ProcessingEnvironment.Location = new System.Drawing.Point( 4, 22 );
      this.m_TabPage_ProcessingEnvironment.Name = "m_TabPage_ProcessingEnvironment";
      this.m_TabPage_ProcessingEnvironment.Padding = new System.Windows.Forms.Padding( 3 );
      this.m_TabPage_ProcessingEnvironment.Size = new System.Drawing.Size( 664, 470 );
      this.m_TabPage_ProcessingEnvironment.TabIndex = 1;
      this.m_TabPage_ProcessingEnvironment.Text = "Processing Environment";
      this.m_TabPage_ProcessingEnvironment.UseVisualStyleBackColor = true;
      // 
      // m_DebugTabPage
      // 
      this.m_DebugTabPage.Controls.Add( this.m_OutputCTRL );
      this.m_DebugTabPage.Location = new System.Drawing.Point( 4, 22 );
      this.m_DebugTabPage.Name = "m_DebugTabPage";
      this.m_DebugTabPage.Padding = new System.Windows.Forms.Padding( 3 );
      this.m_DebugTabPage.Size = new System.Drawing.Size( 664, 470 );
      this.m_DebugTabPage.TabIndex = 2;
      this.m_DebugTabPage.Text = "Debug";
      this.m_DebugTabPage.UseVisualStyleBackColor = true;
      // 
      // m_MainMenu
      // 
      this.m_MainMenu.Dock = System.Windows.Forms.DockStyle.None;
      this.m_MainMenu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
      this.m_MainMenu.Items.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.m_TSMI_Session,
            this.m_TSMIServer,
            this.TSMIItem1,
            this.toolsToolStripMenuItem,
            this.TSMIHelp,
            this.TSMIOptions} );
      this.m_MainMenu.Location = new System.Drawing.Point( 3, 0 );
      this.m_MainMenu.Name = "m_MainMenu";
      this.m_MainMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
      this.m_MainMenu.ShowItemToolTips = true;
      this.m_MainMenu.Size = new System.Drawing.Size( 267, 24 );
      this.m_MainMenu.Stretch = false;
      this.m_MainMenu.TabIndex = 6;
      this.m_MainMenu.Text = "menuStrip1";
      // 
      // m_TSMIServer
      // 
      this.m_TSMIServer.DropDownItems.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.m_TSMI_Browse,
            this.m_TSMIConnect,
            this.m_TSM_IDisconnect,
            this.toolStripMenuItem4,
            this.toolStripSeparator8,
            this.m_TSM_Status,
            this.TSMIBrowse,
            this.toolStripSeparator9,
            this.TSMIRead,
            this.TSMIWrite,
            this.toolStripSeparator10,
            toolStripMenuItem5,
            this.TSMITest} );
      this.m_TSMIServer.Name = "m_TSMIServer";
      this.m_TSMIServer.Size = new System.Drawing.Size( 51, 20 );
      this.m_TSMIServer.Text = "S&erver";
      this.m_TSMIServer.ToolTipText = "Manage the selected server";
      // 
      // m_TSMI_Browse
      // 
      this.m_TSMI_Browse.Image = ( (System.Drawing.Image)( resources.GetObject( "m_TSMI_Browse.Image" ) ) );
      this.m_TSMI_Browse.Name = "m_TSMI_Browse";
      this.m_TSMI_Browse.Size = new System.Drawing.Size( 167, 22 );
      this.m_TSMI_Browse.Text = "&Browse network...";
      this.m_TSMI_Browse.ToolTipText = "Browse network and add selected server to the session.";
      this.m_TSMI_Browse.Click += new System.EventHandler( this.TSMI_Server_BrowseNetwork_Click );
      // 
      // m_TSMIConnect
      // 
      this.m_TSMIConnect.Image = ( (System.Drawing.Image)( resources.GetObject( "m_TSMIConnect.Image" ) ) );
      this.m_TSMIConnect.Name = "m_TSMIConnect";
      this.m_TSMIConnect.Size = new System.Drawing.Size( 167, 22 );
      this.m_TSMIConnect.Text = "&Connect";
      this.m_TSMIConnect.ToolTipText = "Connect to Server";
      this.m_TSMIConnect.Click += new System.EventHandler( this.TSMI_Server_Connect_Click );
      // 
      // m_TSM_IDisconnect
      // 
      this.m_TSM_IDisconnect.Image = ( (System.Drawing.Image)( resources.GetObject( "m_TSM_IDisconnect.Image" ) ) );
      this.m_TSM_IDisconnect.Name = "m_TSM_IDisconnect";
      this.m_TSM_IDisconnect.Size = new System.Drawing.Size( 167, 22 );
      this.m_TSM_IDisconnect.Text = "&Disconnect";
      this.m_TSM_IDisconnect.ToolTipText = "Disconnect from Server";
      this.m_TSM_IDisconnect.Click += new System.EventHandler( this.TSMI_Server_Disconnect_Click );
      // 
      // toolStripMenuItem4
      // 
      this.toolStripMenuItem4.Image = ( (System.Drawing.Image)( resources.GetObject( "toolStripMenuItem4.Image" ) ) );
      this.toolStripMenuItem4.Name = "toolStripMenuItem4";
      this.toolStripMenuItem4.Size = new System.Drawing.Size( 167, 22 );
      this.toolStripMenuItem4.Text = "Di&sconnect all";
      this.toolStripMenuItem4.ToolTipText = "Di&sconnect from all Servers";
      this.toolStripMenuItem4.Click += new System.EventHandler( this.TSMI_Server_DisconnectAll_Click );
      // 
      // toolStripSeparator8
      // 
      this.toolStripSeparator8.Name = "toolStripSeparator8";
      this.toolStripSeparator8.Size = new System.Drawing.Size( 164, 6 );
      // 
      // m_TSM_Status
      // 
      this.m_TSM_Status.Image = ( (System.Drawing.Image)( resources.GetObject( "m_TSM_Status.Image" ) ) );
      this.m_TSM_Status.Name = "m_TSM_Status";
      this.m_TSM_Status.Size = new System.Drawing.Size( 167, 22 );
      this.m_TSM_Status.Text = "&View Status";
      this.m_TSM_Status.ToolTipText = "View Server Status";
      this.m_TSM_Status.Click += new System.EventHandler( this.TSMI_Server_ViewStatus_Click );
      // 
      // TSMIBrowse
      // 
      this.TSMIBrowse.DropDownItems.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem10,
            this.toolStripMenuItem11} );
      this.TSMIBrowse.Image = ( (System.Drawing.Image)( resources.GetObject( "TSMIBrowse.Image" ) ) );
      this.TSMIBrowse.Name = "TSMIBrowse";
      this.TSMIBrowse.Size = new System.Drawing.Size( 167, 22 );
      this.TSMIBrowse.Text = "&Browse";
      this.TSMIBrowse.ToolTipText = "Browse Address Space";
      // 
      // toolStripMenuItem10
      // 
      this.toolStripMenuItem10.Image = ( (System.Drawing.Image)( resources.GetObject( "toolStripMenuItem10.Image" ) ) );
      this.toolStripMenuItem10.Name = "toolStripMenuItem10";
      this.toolStripMenuItem10.Size = new System.Drawing.Size( 137, 22 );
      this.toolStripMenuItem10.Text = "&Server...";
      this.toolStripMenuItem10.ToolTipText = "Browse address space of the selected server and export address space to the dicti" +
          "onary XML ";
      this.toolStripMenuItem10.Click += new System.EventHandler( this.TSMI_Server_ExportDictionary_Click );
      // 
      // toolStripMenuItem11
      // 
      this.toolStripMenuItem11.Image = ( (System.Drawing.Image)( resources.GetObject( "toolStripMenuItem11.Image" ) ) );
      this.toolStripMenuItem11.Name = "toolStripMenuItem11";
      this.toolStripMenuItem11.Size = new System.Drawing.Size( 137, 22 );
      this.toolStripMenuItem11.Text = "&Dictionary...";
      this.toolStripMenuItem11.ToolTipText = "Read address space from an XML file and browse the dictionary.";
      this.toolStripMenuItem11.Click += new System.EventHandler( this.TSMI_Server_OpenDictionary_Click );
      // 
      // toolStripSeparator9
      // 
      this.toolStripSeparator9.Name = "toolStripSeparator9";
      this.toolStripSeparator9.Size = new System.Drawing.Size( 164, 6 );
      // 
      // TSMIRead
      // 
      this.TSMIRead.Image = ( (System.Drawing.Image)( resources.GetObject( "TSMIRead.Image" ) ) );
      this.TSMIRead.Name = "TSMIRead";
      this.TSMIRead.Size = new System.Drawing.Size( 167, 22 );
      this.TSMIRead.Text = "&Read...";
      this.TSMIRead.ToolTipText = "Read Items";
      this.TSMIRead.Click += new System.EventHandler( this.TSMI_Server_Read_Click );
      // 
      // TSMIWrite
      // 
      this.TSMIWrite.Image = ( (System.Drawing.Image)( resources.GetObject( "TSMIWrite.Image" ) ) );
      this.TSMIWrite.Name = "TSMIWrite";
      this.TSMIWrite.Size = new System.Drawing.Size( 167, 22 );
      this.TSMIWrite.Text = "&Write...";
      this.TSMIWrite.ToolTipText = "Write Items";
      this.TSMIWrite.Click += new System.EventHandler( this.TSMI_Server_Write_Click );
      // 
      // toolStripSeparator10
      // 
      this.toolStripSeparator10.Name = "toolStripSeparator10";
      this.toolStripSeparator10.Size = new System.Drawing.Size( 164, 6 );
      // 
      // TSMITest
      // 
      this.TSMITest.Enabled = false;
      this.TSMITest.Name = "TSMITest";
      this.TSMITest.Size = new System.Drawing.Size( 167, 22 );
      this.TSMITest.Text = "Test";
      this.TSMITest.Visible = false;
      this.TSMITest.DisplayStyleChanged += new System.EventHandler( this.TSMI_Server_Test_Click );
      // 
      // TSMIItem1
      // 
      this.TSMIItem1.DropDownItems.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.TSMIClear,
            this.m_TSMI_DebugOn} );
      this.TSMIItem1.Name = "TSMIItem1";
      this.TSMIItem1.Size = new System.Drawing.Size( 54, 20 );
      this.TSMIItem1.Text = "&Debug";
      this.TSMIItem1.ToolTipText = "Manage the debugger options";
      // 
      // TSMIClear
      // 
      this.TSMIClear.Image = ( (System.Drawing.Image)( resources.GetObject( "TSMIClear.Image" ) ) );
      this.TSMIClear.Name = "TSMIClear";
      this.TSMIClear.Size = new System.Drawing.Size( 126, 22 );
      this.TSMIClear.Text = "&Clear";
      this.TSMIClear.ToolTipText = "Clear debug window";
      this.TSMIClear.Click += new System.EventHandler( this.OutputClearMI_Click );
      // 
      // m_TSMI_DebugOn
      // 
      this.m_TSMI_DebugOn.Checked = true;
      this.m_TSMI_DebugOn.CheckOnClick = true;
      this.m_TSMI_DebugOn.CheckState = System.Windows.Forms.CheckState.Checked;
      this.m_TSMI_DebugOn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
      this.m_TSMI_DebugOn.Name = "m_TSMI_DebugOn";
      this.m_TSMI_DebugOn.Size = new System.Drawing.Size( 126, 22 );
      this.m_TSMI_DebugOn.Text = "Debug on";
      this.m_TSMI_DebugOn.ToolTipText = "Open debug window";
      this.m_TSMI_DebugOn.Click += new System.EventHandler( this.TSMI_DebugOn_Click );
      // 
      // toolsToolStripMenuItem
      // 
      this.toolsToolStripMenuItem.DropDownItems.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.dCOMConfigurationToolStripMenuItem} );
      this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
      this.toolsToolStripMenuItem.Size = new System.Drawing.Size( 48, 20 );
      this.toolsToolStripMenuItem.Text = "Tools";
      // 
      // dCOMConfigurationToolStripMenuItem
      // 
      this.dCOMConfigurationToolStripMenuItem.Name = "dCOMConfigurationToolStripMenuItem";
      this.dCOMConfigurationToolStripMenuItem.Size = new System.Drawing.Size( 187, 22 );
      this.dCOMConfigurationToolStripMenuItem.Text = "DCOM Configuration";
      this.dCOMConfigurationToolStripMenuItem.Click += new System.EventHandler( this.dCOMConfigurationToolStripMenuItem_Click );
      // 
      // TSMIHelp
      // 
      this.TSMIHelp.DropDownItems.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem,
            toolStripMenuItem1,
            this.toolStripMenuItemSupport,
            this.toolStripMenuItem3,
            this.toolStripSeparator3,
            this.TSMIAbout,
            this.licenseInformationToolStripMenuItem,
            this.openLogsContainingFolderToolStripMenuItem,
            this.enterTheUnlockCodeToolStripMenuItem} );
      this.TSMIHelp.Name = "TSMIHelp";
      this.TSMIHelp.Size = new System.Drawing.Size( 44, 20 );
      this.TSMIHelp.Text = "&Help";
      this.TSMIHelp.ToolTipText = "Show About Dialog";
      // 
      // helpToolStripMenuItem
      // 
      this.helpToolStripMenuItem.Image = ( (System.Drawing.Image)( resources.GetObject( "helpToolStripMenuItem.Image" ) ) );
      this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
      this.helpToolStripMenuItem.Size = new System.Drawing.Size( 226, 22 );
      this.helpToolStripMenuItem.Text = "Help";
      this.helpToolStripMenuItem.ToolTipText = "Open online help";
      this.helpToolStripMenuItem.Click += new System.EventHandler( this.TSMI_ShowOnlineHelp_Click );
      // 
      // toolStripMenuItemSupport
      // 
      this.toolStripMenuItemSupport.Image = ( (System.Drawing.Image)( resources.GetObject( "toolStripMenuItemSupport.Image" ) ) );
      this.toolStripMenuItemSupport.Name = "toolStripMenuItemSupport";
      this.toolStripMenuItemSupport.Size = new System.Drawing.Size( 226, 22 );
      this.toolStripMenuItemSupport.Text = "Support";
      this.toolStripMenuItemSupport.ToolTipText = "Feed back and technical support product email.";
      this.toolStripMenuItemSupport.Click += new System.EventHandler( this.TSMI_Support_Click );
      // 
      // toolStripMenuItem3
      // 
      this.toolStripMenuItem3.Image = ( (System.Drawing.Image)( resources.GetObject( "toolStripMenuItem3.Image" ) ) );
      this.toolStripMenuItem3.Name = "toolStripMenuItem3";
      this.toolStripMenuItem3.Size = new System.Drawing.Size( 226, 22 );
      this.toolStripMenuItem3.Text = "RSS Feeds";
      this.toolStripMenuItem3.ToolTipText = "ANNOUNCEMENT Subscribe to CAS RSS Feeds!";
      this.toolStripMenuItem3.Click += new System.EventHandler( this.TSMI_OpenRSS_Click );
      // 
      // toolStripSeparator3
      // 
      this.toolStripSeparator3.Name = "toolStripSeparator3";
      this.toolStripSeparator3.Size = new System.Drawing.Size( 223, 6 );
      // 
      // TSMIAbout
      // 
      this.TSMIAbout.Image = ( (System.Drawing.Image)( resources.GetObject( "TSMIAbout.Image" ) ) );
      this.TSMIAbout.Name = "TSMIAbout";
      this.TSMIAbout.Size = new System.Drawing.Size( 226, 22 );
      this.TSMIAbout.Text = "&About OPC Viewer";
      this.TSMIAbout.Click += new System.EventHandler( this.AboutMI_Click );
      // 
      // licenseInformationToolStripMenuItem
      // 
      this.licenseInformationToolStripMenuItem.Image = ( (System.Drawing.Image)( resources.GetObject( "licenseInformationToolStripMenuItem.Image" ) ) );
      this.licenseInformationToolStripMenuItem.Name = "licenseInformationToolStripMenuItem";
      this.licenseInformationToolStripMenuItem.Size = new System.Drawing.Size( 226, 22 );
      this.licenseInformationToolStripMenuItem.Text = "License information";
      this.licenseInformationToolStripMenuItem.Click += new System.EventHandler( this.licenseInformationToolStripMenuItem_Click );
      // 
      // openLogsContainingFolderToolStripMenuItem
      // 
      this.openLogsContainingFolderToolStripMenuItem.Image = ( (System.Drawing.Image)( resources.GetObject( "openLogsContainingFolderToolStripMenuItem.Image" ) ) );
      this.openLogsContainingFolderToolStripMenuItem.Name = "openLogsContainingFolderToolStripMenuItem";
      this.openLogsContainingFolderToolStripMenuItem.Size = new System.Drawing.Size( 226, 22 );
      this.openLogsContainingFolderToolStripMenuItem.Text = "Open logs containing folder";
      this.openLogsContainingFolderToolStripMenuItem.Click += new System.EventHandler( this.openLogsContainingFolderToolStripMenuItem_Click );
      // 
      // enterTheUnlockCodeToolStripMenuItem
      // 
      this.enterTheUnlockCodeToolStripMenuItem.Image = ( (System.Drawing.Image)( resources.GetObject( "enterTheUnlockCodeToolStripMenuItem.Image" ) ) );
      this.enterTheUnlockCodeToolStripMenuItem.Name = "enterTheUnlockCodeToolStripMenuItem";
      this.enterTheUnlockCodeToolStripMenuItem.ShortcutKeys = ( (System.Windows.Forms.Keys)( ( System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.K ) ) );
      this.enterTheUnlockCodeToolStripMenuItem.Size = new System.Drawing.Size( 226, 22 );
      this.enterTheUnlockCodeToolStripMenuItem.Text = "Enter the unlock code";
      this.enterTheUnlockCodeToolStripMenuItem.Click += new System.EventHandler( this.enterTheUnlockCodeToolStripMenuItem_Click );
      // 
      // TSMIOptions
      // 
      this.TSMIOptions.DropDownItems.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.TSMIProxyServer,
            this.TSMIClearHistory} );
      this.TSMIOptions.Name = "TSMIOptions";
      this.TSMIOptions.Size = new System.Drawing.Size( 61, 20 );
      this.TSMIOptions.Text = "O&ptions";
      this.TSMIOptions.ToolTipText = "Manage the program options";
      this.TSMIOptions.Visible = false;
      // 
      // TSMIProxyServer
      // 
      this.TSMIProxyServer.Name = "TSMIProxyServer";
      this.TSMIProxyServer.Size = new System.Drawing.Size( 150, 22 );
      this.TSMIProxyServer.Text = "&Proxy Server....";
      this.TSMIProxyServer.Click += new System.EventHandler( this.ProxyServerMI_Click );
      // 
      // TSMIClearHistory
      // 
      this.TSMIClearHistory.Image = ( (System.Drawing.Image)( resources.GetObject( "TSMIClearHistory.Image" ) ) );
      this.TSMIClearHistory.Name = "TSMIClearHistory";
      this.TSMIClearHistory.Size = new System.Drawing.Size( 150, 22 );
      this.TSMIClearHistory.Text = "&Clear History";
      this.TSMIClearHistory.ToolTipText = "Clear list of known URLs";
      this.TSMIClearHistory.Click += new System.EventHandler( this.ClearHistoryMI_Click );
      // 
      // serviceControlToolStrip_DataPorter
      // 
      this.serviceControlToolStrip_DataPorter.Dock = System.Windows.Forms.DockStyle.None;
      this.serviceControlToolStrip_DataPorter.Location = new System.Drawing.Point( 3, 49 );
      this.serviceControlToolStrip_DataPorter.Name = "serviceControlToolStrip_DataPorter";
      this.serviceControlToolStrip_DataPorter.ServiceName = "DataPorter";
      this.serviceControlToolStrip_DataPorter.ServiceResponseTimeout = System.TimeSpan.Parse( "00:00:10" );
      this.serviceControlToolStrip_DataPorter.Size = new System.Drawing.Size( 310, 25 );
      this.serviceControlToolStrip_DataPorter.TabIndex = 9;
      this.serviceControlToolStrip_DataPorter.Text = "DataPorter local service controller:";
      // 
      // m_SaveFileDialog
      // 
      this.m_SaveFileDialog.Title = "Save Server Configuration File";
      // 
      // m_OpenFileDialog
      // 
      this.m_OpenFileDialog.FileName = "openFileDialog1";
      this.m_OpenFileDialog.ShowHelp = true;
      this.m_OpenFileDialog.SupportMultiDottedExtensions = true;
      this.m_OpenFileDialog.Title = "Open Server Configuration File";
      // 
      // m_textBoxBaseTraceListener
      // 
      this.m_textBoxBaseTraceListener.Name = "OPCViewer.Output.TraceListener";
      this.m_textBoxBaseTraceListener.OutputTextBox = this.m_OutputCTRL;
      // 
      // m_StatusCTRL
      // 
      this.m_StatusCTRL.Dock = System.Windows.Forms.DockStyle.None;
      this.m_StatusCTRL.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
      this.m_StatusCTRL.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
      this.m_StatusCTRL.Location = new System.Drawing.Point( 3, 0 );
      this.m_StatusCTRL.Name = "m_StatusCTRL";
      this.m_StatusCTRL.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
      this.m_StatusCTRL.ShowItemToolTips = true;
      this.m_StatusCTRL.Size = new System.Drawing.Size( 46, 22 );
      this.m_StatusCTRL.Stretch = false;
      this.m_StatusCTRL.TabIndex = 8;
      this.m_StatusCTRL.Text = "Server not connected.";
      // 
      // m_SubscriptionCTRL
      // 
      this.m_SubscriptionCTRL.Dock = System.Windows.Forms.DockStyle.Fill;
      this.m_SubscriptionCTRL.Location = new System.Drawing.Point( 0, 0 );
      this.m_SubscriptionCTRL.Name = "m_SubscriptionCTRL";
      this.m_SubscriptionCTRL.Size = new System.Drawing.Size( 338, 496 );
      this.m_SubscriptionCTRL.TabIndex = 0;
      // 
      // m_UpdatesCTRL
      // 
      this.m_UpdatesCTRL.AllowDrop = true;
      this.m_UpdatesCTRL.Dock = System.Windows.Forms.DockStyle.Fill;
      this.m_UpdatesCTRL.Location = new System.Drawing.Point( 3, 3 );
      this.m_UpdatesCTRL.Name = "m_UpdatesCTRL";
      this.m_UpdatesCTRL.Padding = new System.Windows.Forms.Padding( 2 );
      this.m_UpdatesCTRL.Size = new System.Drawing.Size( 658, 464 );
      this.m_UpdatesCTRL.TabIndex = 0;
      // 
      // SelectTargetCTRL
      // 
      this.SelectTargetCTRL.Label = "Target";
      this.SelectTargetCTRL.Location = new System.Drawing.Point( 0, 0 );
      this.SelectTargetCTRL.Name = "SelectTargetCTRL";
      this.SelectTargetCTRL.Padding = new System.Windows.Forms.Padding( 4, 0, 4, 0 );
      this.SelectTargetCTRL.Size = new System.Drawing.Size( 1014, 25 );
      this.SelectTargetCTRL.TabIndex = 0;
      this.SelectTargetCTRL.Visible = false;
      // 
      // m_SelectServerStrip
      // 
      this.m_SelectServerStrip.Dock = System.Windows.Forms.DockStyle.None;
      this.m_SelectServerStrip.Label = "Server";
      this.m_SelectServerStrip.Location = new System.Drawing.Point( 3, 74 );
      this.m_SelectServerStrip.Name = "m_SelectServerStrip";
      this.m_SelectServerStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
      this.m_SelectServerStrip.Size = new System.Drawing.Size( 842, 25 );
      this.m_SelectServerStrip.TabIndex = 8;
      // 
      // MainFormV2008
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size( 1020, 617 );
      this.Controls.Add( this.toolStripContainer1 );
      this.Icon = ( (System.Drawing.Icon)( resources.GetObject( "$this.Icon" ) ) );
      this.Name = "MainFormV2008";
      this.Padding = new System.Windows.Forms.Padding( 3, 0, 3, 0 );
      this.Text = "OPC Viewer - OPC Data Access Client";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler( this.MainFormV2008_FormClosing );
      m_ToolStrip.ResumeLayout( false );
      m_ToolStrip.PerformLayout();
      this.toolStripContainer1.BottomToolStripPanel.ResumeLayout( false );
      this.toolStripContainer1.BottomToolStripPanel.PerformLayout();
      this.toolStripContainer1.ContentPanel.ResumeLayout( false );
      this.toolStripContainer1.ContentPanel.PerformLayout();
      this.toolStripContainer1.TopToolStripPanel.ResumeLayout( false );
      this.toolStripContainer1.TopToolStripPanel.PerformLayout();
      this.toolStripContainer1.ResumeLayout( false );
      this.toolStripContainer1.PerformLayout();
      this.splitContainer1.Panel1.ResumeLayout( false );
      this.splitContainer1.Panel2.ResumeLayout( false );
      this.splitContainer1.ResumeLayout( false );
      this.m_MainTabControl.ResumeLayout( false );
      this.m_tabPage_OPC_Environment.ResumeLayout( false );
      this.m_DebugTabPage.ResumeLayout( false );
      this.m_MainMenu.ResumeLayout( false );
      this.m_MainMenu.PerformLayout();
      this.ResumeLayout( false );

    }
    #endregion
    private System.Windows.Forms.ToolStripContainer toolStripContainer1;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    private System.Windows.Forms.SplitContainer splitContainer1;
    private CAS.Lib.OPCClientControlsLib.SessionTreeControl m_SubscriptionCTRL;
    private UpdatesViewCtrl m_UpdatesCTRL;
    private System.Windows.Forms.MenuStrip m_MainMenu;
    private System.Windows.Forms.ToolStripMenuItem m_TSMIServer;
    private System.Windows.Forms.ToolStripMenuItem m_TSMIConnect;
    private System.Windows.Forms.ToolStripMenuItem m_TSM_IDisconnect;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
    private System.Windows.Forms.ToolStripMenuItem m_TSM_Status;
    private System.Windows.Forms.ToolStripMenuItem TSMIBrowse;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
    private System.Windows.Forms.ToolStripMenuItem TSMIRead;
    private System.Windows.Forms.ToolStripMenuItem TSMIWrite;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
    private System.Windows.Forms.ToolStripMenuItem TSMITest;
    private System.Windows.Forms.ToolStripMenuItem TSMIItem1;
    private System.Windows.Forms.ToolStripMenuItem TSMIClear;
    private System.Windows.Forms.ToolStripMenuItem TSMIOptions;
    private System.Windows.Forms.ToolStripMenuItem TSMIProxyServer;
    private System.Windows.Forms.ToolStripMenuItem TSMIClearHistory;
    private System.Windows.Forms.ToolStripMenuItem TSMIHelp;
    private System.Windows.Forms.ToolStripMenuItem TSMIAbout;
    private System.Windows.Forms.ToolStripButton m_TSM_SessionLoad;
    private System.Windows.Forms.ToolStripButton m_TSB_SessionSave;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator11;
    private System.Windows.Forms.ToolStripButton toolStripButtonConnect;
    private System.Windows.Forms.ToolStripButton m_TSB_Disconnect;
    private System.Windows.Forms.ToolStripButton m_TSB_GetServerStatus;
    private System.Windows.Forms.ToolStripButton toolStripButtonBrowse;
    private System.Windows.Forms.ToolStripButton toolStripButtonReadItems;
    private System.Windows.Forms.ToolStripButton toolStripButtonWriteItems;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator13;
    private System.Windows.Forms.ToolStripButton toolStripButtonShowAboutDialog;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator14;
    private CAS.Lib.OPCClientControlsLib.SelectServerStrip m_SelectServerStrip;
    private System.Windows.Forms.ToolStripMenuItem m_TSMI_DebugOn;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
    private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemSupport;
    private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
    private System.Windows.Forms.ToolStripMenuItem m_TSMI_Browse;
    private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
    private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem7;
    private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem8;
    private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem10;
    private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem11;
    private System.Windows.Forms.TabControl m_MainTabControl;
    private System.Windows.Forms.TabPage m_tabPage_OPC_Environment;
    private System.Windows.Forms.TabPage m_TabPage_ProcessingEnvironment;
    private System.Windows.Forms.ToolStripMenuItem m_TSMI_Session;
    private System.Windows.Forms.SaveFileDialog m_SaveFileDialog;
    private System.Windows.Forms.OpenFileDialog m_OpenFileDialog;
    private System.Windows.Forms.TabPage m_DebugTabPage;
    private System.Windows.Forms.ToolStripButton toolStripButtonShowOnlineHelp;
    private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
    private System.Windows.Forms.ToolStripButton toolStripButtonSupport;
    private CAS.Lib.ControlLibrary.ServiceControlToolStrip serviceControlToolStrip_DataPorter;
    private CAS.Lib.ControlLibrary.TextBoxBaseWithTraceListener m_textBoxBaseTraceListener;
    private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem dCOMConfigurationToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem licenseInformationToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem openLogsContainingFolderToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem enterTheUnlockCodeToolStripMenuItem;
    private CAS.Lib.CodeProtect.MaintenanceControlComponent maintenanceControlComponent;
  }
}