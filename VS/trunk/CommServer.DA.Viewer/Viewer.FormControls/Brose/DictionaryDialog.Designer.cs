namespace CAS.Lib.OPCClientControlsLib
{
  partial class DictionaryDialog
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
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
      System.Windows.Forms.ToolStripContainer toolStripContainer1;
      System.Windows.Forms.TabControl m_TC_Property;
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( DictionaryDialog ) );
      this.m_SC_Main = new System.Windows.Forms.SplitContainer();
      this.m_BrowseTreeCtrl = new CAS.Lib.OPCClientControlsLib.BrowseTreeCtrl();
      this.ServerTags = new System.Windows.Forms.TabPage();
      this.m_PropertiesCTRL = new CAS.Lib.OPCClientControlsLib.PropertyListViewCtrl();
      this.m_ToolStrip = new System.Windows.Forms.ToolStrip();
      this.m_TSB_Save = new System.Windows.Forms.ToolStripButton();
      this.m_TSB_SaveAs = new System.Windows.Forms.ToolStripButton();
      this.m_TSB_OpenDictionary = new System.Windows.Forms.ToolStripButton();
      this.m_TSB_Connect = new System.Windows.Forms.ToolStripButton();
      this.m_TSB_Cancel = new System.Windows.Forms.ToolStripButton();
      this.m_Dictionary = new CAS.Lib.OPC.AddressSpace.DictionaryManagement( this.components );
      toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
      m_TC_Property = new System.Windows.Forms.TabControl();
      toolStripContainer1.ContentPanel.SuspendLayout();
      toolStripContainer1.TopToolStripPanel.SuspendLayout();
      toolStripContainer1.SuspendLayout();
      this.m_SC_Main.Panel1.SuspendLayout();
      this.m_SC_Main.Panel2.SuspendLayout();
      this.m_SC_Main.SuspendLayout();
      m_TC_Property.SuspendLayout();
      this.ServerTags.SuspendLayout();
      this.m_ToolStrip.SuspendLayout();
      this.SuspendLayout();
      // 
      // toolStripContainer1
      // 
      // 
      // toolStripContainer1.ContentPanel
      // 
      toolStripContainer1.ContentPanel.Controls.Add( this.m_SC_Main );
      toolStripContainer1.ContentPanel.Size = new System.Drawing.Size( 1009, 432 );
      toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
      // 
      // toolStripContainer1.LeftToolStripPanel
      // 
      toolStripContainer1.LeftToolStripPanel.Enabled = false;
      toolStripContainer1.LeftToolStripPanelVisible = false;
      toolStripContainer1.Location = new System.Drawing.Point( 0, 0 );
      toolStripContainer1.Name = "toolStripContainer1";
      // 
      // toolStripContainer1.RightToolStripPanel
      // 
      toolStripContainer1.RightToolStripPanel.Enabled = false;
      toolStripContainer1.RightToolStripPanelVisible = false;
      toolStripContainer1.Size = new System.Drawing.Size( 1009, 457 );
      toolStripContainer1.TabIndex = 1;
      toolStripContainer1.Text = "toolStripContainer1";
      // 
      // toolStripContainer1.TopToolStripPanel
      // 
      toolStripContainer1.TopToolStripPanel.Controls.Add( this.m_ToolStrip );
      // 
      // m_SC_Main
      // 
      this.m_SC_Main.Dock = System.Windows.Forms.DockStyle.Fill;
      this.m_SC_Main.Location = new System.Drawing.Point( 0, 0 );
      this.m_SC_Main.Name = "m_SC_Main";
      // 
      // m_SC_Main.Panel1
      // 
      this.m_SC_Main.Panel1.Controls.Add( this.m_BrowseTreeCtrl );
      // 
      // m_SC_Main.Panel2
      // 
      this.m_SC_Main.Panel2.Controls.Add( m_TC_Property );
      this.m_SC_Main.Size = new System.Drawing.Size( 1009, 432 );
      this.m_SC_Main.SplitterDistance = 335;
      this.m_SC_Main.TabIndex = 0;
      // 
      // m_BrowseTreeCtrl
      // 
      this.m_BrowseTreeCtrl.Dock = System.Windows.Forms.DockStyle.Fill;
      this.m_BrowseTreeCtrl.Location = new System.Drawing.Point( 0, 0 );
      this.m_BrowseTreeCtrl.Name = "m_BrowseTreeCtrl";
      this.m_BrowseTreeCtrl.Size = new System.Drawing.Size( 335, 432 );
      this.m_BrowseTreeCtrl.TabIndex = 0;
      // 
      // m_TC_Property
      // 
      m_TC_Property.Controls.Add( this.ServerTags );
      m_TC_Property.Dock = System.Windows.Forms.DockStyle.Fill;
      m_TC_Property.Location = new System.Drawing.Point( 0, 0 );
      m_TC_Property.Name = "m_TC_Property";
      m_TC_Property.SelectedIndex = 0;
      m_TC_Property.ShowToolTips = true;
      m_TC_Property.Size = new System.Drawing.Size( 670, 432 );
      m_TC_Property.TabIndex = 0;
      // 
      // ServerTags
      // 
      this.ServerTags.Controls.Add( this.m_PropertiesCTRL );
      this.ServerTags.Location = new System.Drawing.Point( 4, 22 );
      this.ServerTags.Name = "ServerTags";
      this.ServerTags.Padding = new System.Windows.Forms.Padding( 3 );
      this.ServerTags.Size = new System.Drawing.Size( 662, 406 );
      this.ServerTags.TabIndex = 0;
      this.ServerTags.Text = "Properties";
      this.ServerTags.ToolTipText = "Tab displaying selected item properties details";
      this.ServerTags.UseVisualStyleBackColor = true;
      // 
      // m_PropertiesCTRL
      // 
      this.m_PropertiesCTRL.AllowDrop = true;
      this.m_PropertiesCTRL.Dock = System.Windows.Forms.DockStyle.Fill;
      this.m_PropertiesCTRL.Location = new System.Drawing.Point( 3, 3 );
      this.m_PropertiesCTRL.Name = "m_PropertiesCTRL";
      this.m_PropertiesCTRL.Size = new System.Drawing.Size( 656, 400 );
      this.m_PropertiesCTRL.TabIndex = 0;
      // 
      // m_ToolStrip
      // 
      this.m_ToolStrip.Dock = System.Windows.Forms.DockStyle.None;
      this.m_ToolStrip.Items.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.m_TSB_Save,
            this.m_TSB_SaveAs,
            this.m_TSB_OpenDictionary,
            this.m_TSB_Connect,
            this.m_TSB_Cancel} );
      this.m_ToolStrip.Location = new System.Drawing.Point( 3, 0 );
      this.m_ToolStrip.Name = "m_ToolStrip";
      this.m_ToolStrip.Size = new System.Drawing.Size( 512, 25 );
      this.m_ToolStrip.TabIndex = 0;
      // 
      // m_TSB_Save
      // 
      this.m_TSB_Save.AutoSize = false;
      this.m_TSB_Save.Image = global::CAS.Lib.OPCClientControlsLib.ImagesResources.export;
      this.m_TSB_Save.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.m_TSB_Save.Name = "m_TSB_Save";
      this.m_TSB_Save.Size = new System.Drawing.Size( 100, 22 );
      this.m_TSB_Save.Text = "&Save";
      this.m_TSB_Save.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.m_TSB_Save.ToolTipText = "Save address space dictionary to an XML file";
      this.m_TSB_Save.Click += new System.EventHandler( this.m_TSB_Save_Click );
      // 
      // m_TSB_SaveAs
      // 
      this.m_TSB_SaveAs.AutoSize = false;
      this.m_TSB_SaveAs.Image = global::CAS.Lib.OPCClientControlsLib.ImagesResources.export;
      this.m_TSB_SaveAs.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.m_TSB_SaveAs.Name = "m_TSB_SaveAs";
      this.m_TSB_SaveAs.Size = new System.Drawing.Size( 100, 22 );
      this.m_TSB_SaveAs.Text = "&Save As";
      this.m_TSB_SaveAs.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.m_TSB_SaveAs.ToolTipText = "Save as address space dictionary to an XML file";
      this.m_TSB_SaveAs.Click += new System.EventHandler( this.m_TSB_SaveAs_Click );
      // 
      // m_TSB_OpenDictionary
      // 
      this.m_TSB_OpenDictionary.AutoSize = false;
      this.m_TSB_OpenDictionary.Image = global::CAS.Lib.OPCClientControlsLib.ImagesResources.OpenXml;
      this.m_TSB_OpenDictionary.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.m_TSB_OpenDictionary.Name = "m_TSB_OpenDictionary";
      this.m_TSB_OpenDictionary.Size = new System.Drawing.Size( 100, 22 );
      this.m_TSB_OpenDictionary.Text = "&Open";
      this.m_TSB_OpenDictionary.ToolTipText = "Open an address space dictionary XML file";
      this.m_TSB_OpenDictionary.Click += new System.EventHandler( this.m_TSB_OpenDictionary_Click );
      // 
      // m_TSB_Connect
      // 
      this.m_TSB_Connect.AutoSize = false;
      this.m_TSB_Connect.Image = global::CAS.Lib.OPCClientControlsLib.ImagesResources.Network_ConnectTo;
      this.m_TSB_Connect.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.m_TSB_Connect.Name = "m_TSB_Connect";
      this.m_TSB_Connect.Size = new System.Drawing.Size( 100, 22 );
      this.m_TSB_Connect.Text = "&Connect";
      this.m_TSB_Connect.ToolTipText = "Browse network and connect to selected server.";
      this.m_TSB_Connect.Click += new System.EventHandler( this.m_TSB_Connect_Click );
      // 
      // m_TSB_Cancel
      // 
      this.m_TSB_Cancel.AutoSize = false;
      this.m_TSB_Cancel.Image = global::CAS.Lib.OPCClientControlsLib.ImagesResources.delete;
      this.m_TSB_Cancel.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.m_TSB_Cancel.Name = "m_TSB_Cancel";
      this.m_TSB_Cancel.Size = new System.Drawing.Size( 100, 22 );
      this.m_TSB_Cancel.Text = "Done";
      this.m_TSB_Cancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.m_TSB_Cancel.ToolTipText = "Cancel operation and return to previous dialog";
      this.m_TSB_Cancel.Click += new System.EventHandler( this.m_TSB_Cancel_Click );
      // 
      // m_Dictionary
      // 
      this.m_Dictionary.DefaultFileName = "Dictionary";
      // 
      // DictionaryDialog
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size( 1009, 457 );
      this.Controls.Add( toolStripContainer1 );
      this.HelpButton = true;
      this.Icon = ( (System.Drawing.Icon)( resources.GetObject( "$this.Icon" ) ) );
      this.ImeMode = System.Windows.Forms.ImeMode.Off;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "DictionaryDialog";
      this.Text = "Address Space Dictionary Management";
      this.HelpButtonClicked += new System.ComponentModel.CancelEventHandler( this.DictionaryDialog_HelpButtonClicked );
      toolStripContainer1.ContentPanel.ResumeLayout( false );
      toolStripContainer1.TopToolStripPanel.ResumeLayout( false );
      toolStripContainer1.TopToolStripPanel.PerformLayout();
      toolStripContainer1.ResumeLayout( false );
      toolStripContainer1.PerformLayout();
      this.m_SC_Main.Panel1.ResumeLayout( false );
      this.m_SC_Main.Panel2.ResumeLayout( false );
      this.m_SC_Main.ResumeLayout( false );
      m_TC_Property.ResumeLayout( false );
      this.ServerTags.ResumeLayout( false );
      this.m_ToolStrip.ResumeLayout( false );
      this.m_ToolStrip.PerformLayout();
      this.ResumeLayout( false );

    }

    #endregion

    private BrowseTreeCtrl m_BrowseTreeCtrl;
    private System.Windows.Forms.TabPage ServerTags;
    private System.Windows.Forms.ToolStrip m_ToolStrip;
    private System.Windows.Forms.ToolStripButton m_TSB_Save;
    private System.Windows.Forms.ToolStripButton m_TSB_Cancel;
    private System.Windows.Forms.ToolStripButton m_TSB_OpenDictionary;
    private System.Windows.Forms.SplitContainer m_SC_Main;
    private PropertyListViewCtrl m_PropertiesCTRL;
    private System.Windows.Forms.ToolStripButton m_TSB_Connect;
    private CAS.Lib.OPC.AddressSpace.DictionaryManagement m_Dictionary;
    private System.Windows.Forms.ToolStripButton m_TSB_SaveAs;

  }
}