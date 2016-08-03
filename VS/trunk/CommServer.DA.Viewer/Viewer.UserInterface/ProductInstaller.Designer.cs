namespace CAS.OPCViewer
{
  /// <summary>
  /// Product Installer class
  /// </summary>
  partial class ProductInstaller
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
      CAS.Lib.CodeProtect.LibInstaller m_CodeProtectInstaller;
      m_CodeProtectInstaller = new CAS.Lib.CodeProtect.LibInstaller();
      // 
      // ProductInstaller
      // 
      this.Installers.AddRange( new System.Configuration.Install.Installer[] {
            m_CodeProtectInstaller} );

    }

    #endregion
  }
}