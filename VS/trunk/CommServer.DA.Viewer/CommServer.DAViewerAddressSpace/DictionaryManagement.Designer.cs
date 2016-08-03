namespace CAS.Lib.OPC.AddressSpace
{
  partial class DictionaryManagement
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

    #region Component Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      this.m_Dictionary = new CAS.Lib.OPC.AddressSpace.AddressSpaceDataBase();
      this.m_OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
      this.m_SaveFileDialog = new System.Windows.Forms.SaveFileDialog();
      this.ContextMenuStrip = new System.Windows.Forms.ContextMenuStrip( this.components );
      this.m_TSMI_Open = new System.Windows.Forms.ToolStripMenuItem();
      this.m_TSMI_Save = new System.Windows.Forms.ToolStripMenuItem();
      this.m_TSMI_SaveAs = new System.Windows.Forms.ToolStripMenuItem();
      ( (System.ComponentModel.ISupportInitialize)( this.m_Dictionary ) ).BeginInit();
      this.ContextMenuStrip.SuspendLayout();
      // 
      // m_Dictionary
      // 
      this.m_Dictionary.CaseSensitive = true;
      this.m_Dictionary.DataSetName = "AddressSpaceDataBase";
      this.m_Dictionary.Locale = new System.Globalization.CultureInfo( "" );
      this.m_Dictionary.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
      // 
      // m_OpenFileDialog
      // 
      this.m_OpenFileDialog.DefaultExt = "odic";
      this.m_OpenFileDialog.FileName = "OPCViewerDictionary";
      this.m_OpenFileDialog.Filter = "Dictionary files(*.odic)|*.odic|All files(*.*)|*.*";
      this.m_OpenFileDialog.Title = "Open Address Space Dictionary  File";
      // 
      // m_SaveFileDialog
      // 
      this.m_SaveFileDialog.DefaultExt = "odic";
      this.m_SaveFileDialog.FileName = "OPCViewerDictionary";
      this.m_SaveFileDialog.Filter = "Dictionary files(*.odic)|*.odic|All files(*.*)|*.*";
      this.m_SaveFileDialog.SupportMultiDottedExtensions = true;
      this.m_SaveFileDialog.Title = "Save Address Space Dictionary  File";
      // 
      // ContextMenuStrip
      // 
      this.ContextMenuStrip.Items.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.m_TSMI_Open,
            this.m_TSMI_Save,
            this.m_TSMI_SaveAs} );
      this.ContextMenuStrip.Name = "ContextMenuStrip";
      this.ContextMenuStrip.Size = new System.Drawing.Size( 137, 70 );
      this.ContextMenuStrip.Text = "Dictionary ";
      // 
      // m_TSMI_Open
      // 
      this.m_TSMI_Open.Name = "m_TSMI_Open";
      this.m_TSMI_Open.Size = new System.Drawing.Size( 136, 22 );
      this.m_TSMI_Open.Text = "&Open...";
      this.m_TSMI_Open.ToolTipText = "Read address space from an XML file and browse the dictionary.";
      // 
      // m_TSMI_Save
      // 
      this.m_TSMI_Save.Name = "m_TSMI_Save";
      this.m_TSMI_Save.Size = new System.Drawing.Size( 136, 22 );
      this.m_TSMI_Save.Text = "&Save";
      this.m_TSMI_Save.ToolTipText = "Save address space dictionary to an XML file.";
      // 
      // m_TSMI_SaveAs
      // 
      this.m_TSMI_SaveAs.Name = "m_TSMI_SaveAs";
      this.m_TSMI_SaveAs.Size = new System.Drawing.Size( 136, 22 );
      this.m_TSMI_SaveAs.Text = "Save &As...";
      this.m_TSMI_SaveAs.ToolTipText = "Open a prompt file name dialog and save address space dictionary to an XML in a s" +
          "pecified location and specified file name.";
      ( (System.ComponentModel.ISupportInitialize)( this.m_Dictionary ) ).EndInit();
      this.ContextMenuStrip.ResumeLayout( false );

    }

    #endregion
    private AddressSpaceDataBase m_Dictionary;
    private System.Windows.Forms.OpenFileDialog m_OpenFileDialog;
    private System.Windows.Forms.SaveFileDialog m_SaveFileDialog;
    private System.Windows.Forms.ToolStripMenuItem m_TSMI_Open;
    private System.Windows.Forms.ToolStripMenuItem m_TSMI_Save;
    private System.Windows.Forms.ToolStripMenuItem m_TSMI_SaveAs;
    /// <summary>
    /// The context menu strip
    /// </summary>
    public System.Windows.Forms.ContextMenuStrip ContextMenuStrip;
  }
}
