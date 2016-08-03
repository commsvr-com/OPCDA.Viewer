//<summary>
//  Title   : Browse Server dedicate helper
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
using System.Windows.Forms;
using CAS.Lib.OPC.AddressSpace;
using CAS.Lib.OPCClient.Da;
using OpcDa = Opc.Da;

namespace CAS.Lib.OPCClientControlsLib.TreeNodes.Browse
{
  /// <summary>
  /// Browse Server dedicate helper
  /// </summary>
  internal abstract class BrowseServer
  {
    #region private
    private Server m_Server;
    /// <summary>
    /// While implemented adds the browse element to parent collection.
    /// </summary>
    /// <param name="element">The element.</param>
    protected abstract void AddBrowseElement( OpcDa::BrowseElement element );
    /// <summary>
    /// Browses for children of the element at the current node.
    /// </summary>
    protected void Browse( Opc.ItemIdentifier itemID, OpcDa::BrowseFilters filters )
    {
      try
      {
        // begin a browse.
        OpcDa::BrowsePosition position = null;
        OpcDa.BrowseElement[] children = m_Server.Browse( itemID, filters, out position );
        if ( children == null )
          return;
        foreach ( var element in m_Server.Browse( itemID, filters, out position ) )
          AddBrowseElement( element );
        // loop until all elements have been fetched.
        while ( position != null )
        {
          DialogResult result = MessageBox.Show(
            "More items meeting search criteria exist. Continue browse?",
            "Browse Items",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question
            );
          if ( result != DialogResult.Yes )
            break;
          // fetch next batch of elements add children.
          foreach ( OpcDa::BrowseElement element in m_Server.BrowseNext( ref position ) )
            AddBrowseElement( element );
        }
      }
      catch ( Exception e )
      {
        MessageBox.Show( e.Message );
      }
    }
    /// <summary>
    /// Initializes a new instance of the <see cref="BrowseServer"/> class.
    /// </summary>
    /// <param name="server">The server <see cref="Server"/> to browse.</param>
    /// <param name="itemID">The <see cref="ItemIdentifier"/> node to browse.</param>
    /// <param name="filters">The filters.</param>
    #endregion
    #region constructor
    internal BrowseServer( Server server )
    {
      m_Server = server;
    }
    #endregion
  }
  internal abstract class BrowseDictionary
  {
    #region private
    private AddressSpaceDataBase m_Dictionary;
    /// <summary>
    /// While implemented adds the browse element to parent collection.
    /// </summary>
    /// <param name="element">The element to add.</param>
    protected abstract void AddBrowseElement( AddressSpaceDataBase.TagsTableRow element );
    /// <summary>
    /// Browses for children of the element at the current node.
    /// </summary>
    protected void Browse( AddressSpaceDataBase.TagsTableRow itemID, OpcDa::BrowseFilters filters )
    {
      try
      {
        // begin a browse.
        OpcDa::BrowsePosition position = null;
        foreach ( var element in m_Dictionary.Browse( itemID, filters, out position ) )
          AddBrowseElement( element );
        // loop until all elements have been fetched.
        while ( position != null )
        {
          DialogResult result = MessageBox.Show(
            "More items meeting search criteria exist. Continue browse?",
            "Browse Items",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question
            );
          if ( result != DialogResult.Yes )
            break;
          // fetch next batch of elements, add children.
          foreach ( var element in m_Dictionary.BrowseNext( ref position ) )
            AddBrowseElement( element );
        }
      }
      catch ( Exception e )
      {
        MessageBox.Show( e.Message );
      }
    }
    /// <summary>
    /// Initializes a new instance of the <see cref="BrowseServer"/> class.
    /// </summary>
    /// <param name="server">The server <see cref="Server"/> to browse.</param>
    /// <param name="itemID">The <see cref="ItemIdentifier"/> node to browse.</param>
    /// <param name="filters">The filters.</param>
    #endregion
    #region constructor
    internal BrowseDictionary( AddressSpaceDataBase dictionary )
    {
      m_Dictionary = dictionary;
    }
    #endregion
  }
}
