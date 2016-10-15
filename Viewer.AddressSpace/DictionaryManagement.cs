//<summary>
//  Title   : Class to save and restore address space data base to/from external dictionary file.
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

using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

namespace CAS.Lib.OPC.AddressSpace
{
  /// <summary>
  /// Class to save and restore address space data base to/from external dictionary file.
  /// </summary>
  public partial class DictionaryManagement: Component
  {
    #region private
    private bool m_Empty = true;
    #region menu handlers
    private void m_TSMI_SaveAs_Click( object sender, EventArgs e )
    {
      Save( true );
    }
    private void m_TSMI_Save_Click( object sender, EventArgs e )
    {
      Save( false );
    }
    private void m_TSMI_Open_Click( object sender, EventArgs e )
    {
      Open();
    }
    #endregion
    #endregion
    #region constructors
    /// <summary>
    /// Initializes a new instance of the <see cref="DictionaryManagement"/> class.
    /// </summary>
    public DictionaryManagement()
    {
      InitializeComponent();
      m_TSMI_Open.Click += new EventHandler( m_TSMI_Open_Click );
      m_TSMI_Save.Click += new EventHandler( m_TSMI_Save_Click );
      m_TSMI_SaveAs.Click += new EventHandler( m_TSMI_SaveAs_Click );
      this.m_SaveFileDialog.FileName = "Dictionary";
      m_OpenFileDialog.InitialDirectory = Environment.GetFolderPath( Environment.SpecialFolder.MyDocuments );
      m_SaveFileDialog.InitialDirectory = Environment.GetFolderPath( Environment.SpecialFolder.MyDocuments );
    }
    /// <summary>
    /// Initializes a new instance of the <see cref="DictionaryManagement" /> class.
    /// </summary>
    /// <param name="container">The container.</param>
    public DictionaryManagement( IContainer container )
      : this()
    {
      container.Add( this );
    }
    #endregion
    #region public
    /// <summary>
    /// Gets the dictionary data set.
    /// </summary>
    /// <value>The dictionary.</value>
    public AddressSpaceDataBase Dictionary { get { return m_Dictionary; } }
    /// <summary>
    /// Gets or sets the default name of the file.
    /// </summary>
    /// <value>The default name of the file.</value>
    public string DefaultFileName
    {
      set
      {
        m_OpenFileDialog.FileName = value;
        m_Empty = true;
      }
      get { return m_OpenFileDialog.FileName; }
    }
    /// <summary>
    /// Read the address space data set from an external dictionary file. 
    /// </summary>
    /// <returns><c>true</c> if success</returns>
    public bool Open()
    {
      if ( m_OpenFileDialog.ShowDialog() != DialogResult.OK )
        return false;
      try
      {
        Application.UseWaitCursor = true;
        m_Dictionary.Clear();
        m_Dictionary.EnforceConstraints = false;
        m_Dictionary.ReadXml( m_OpenFileDialog.FileName, System.Data.XmlReadMode.IgnoreSchema );
        m_Dictionary.EnforceConstraints = true;
      }
      catch ( Exception ex )
      {
        MessageBox.Show
          ( ex.Message, Properties.Resources.DictionaryFileOpenError, MessageBoxButtons.OK, MessageBoxIcon.Exclamation );
        return false;
      }
      finally
      {
        Application.UseWaitCursor = false;
      }
      m_SaveFileDialog.FileName = m_OpenFileDialog.FileName;
      m_Empty = false;
      return true;
    }
    /// <summary>
    /// Save the address space data set in an external dictionary file. 
    /// </summary>
    /// <param name="prompt">If set to <c>true</c> show prompt to enter a file name.</param>
    /// <returns></returns>
    public bool Save( bool prompt )
    {
      prompt = m_Empty || prompt;
      if ( prompt )
      {
        m_SaveFileDialog.FileName = string.IsNullOrEmpty( DefaultFileName ) ? "DictionaryFile" : DefaultFileName;
        if ( m_SaveFileDialog.ShowDialog() != DialogResult.OK )
          return false;
        m_Empty = false;
        if ( !Path.HasExtension( m_SaveFileDialog.FileName ) )
          m_SaveFileDialog.FileName += m_SaveFileDialog.DefaultExt;
      }
      try
      {
        Application.UseWaitCursor = true;
        m_Dictionary.WriteXml( m_SaveFileDialog.FileName, System.Data.XmlWriteMode.WriteSchema );
      }
      catch ( Exception ex )
      {
        MessageBox.Show
          ( ex.Message, Properties.Resources.DictionaryFileSaveError, MessageBoxButtons.OK, MessageBoxIcon.Exclamation );
      }
      finally
      {
        Application.UseWaitCursor = false;
      }
      return true;
    }
    #endregion
  }
}
