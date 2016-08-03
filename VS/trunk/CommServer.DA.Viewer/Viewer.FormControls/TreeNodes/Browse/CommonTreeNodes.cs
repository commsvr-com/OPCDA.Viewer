//<summary>
//  Title   : Common TreeNode's
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

using System.Windows.Forms;
using OpcDa = Opc.Da;

namespace CAS.Lib.OPCClientControlsLib.TreeNodes.Browse
{
  /// <summary>
  /// Interface representing a functionality to manage data used while connecting a server.
  /// </summary>
  public interface IConnectDataNode: IBrowse
  {
    /// <summary>
    /// Gets or sets the connect data object <see cref="ConnectData"/>.
    /// </summary>
    /// <value>The connect data object.</value>
    Opc.ConnectData ConnectDataObject { get; set; }
    /// <summary>
    /// Gets or sets the default specification.
    /// </summary>
    /// <value>The default specification.</value>
    Opc.Specification DefaultSpecification { get; set; }
  }
  /// <summary>
  /// Connect Data Node
  /// </summary>
  /// <typeparam name="BrowseNodeType">The actuacl type for <see cref="GenericTreeNode"/> .</typeparam>
  internal abstract class ConnectDataNode<ObjectType, ParentType>: BrowseTreeNode<ObjectType, ParentType>, IConnectDataNode
    where ObjectType: class
    where ParentType: class, IConnectDataNode
  {
    #region private
    private Opc.ConnectData m_CD = null;
    private Opc.Specification m_Spcification;
    #endregion
    #region constructors
    /// <summary>
    /// Initializes a new instance of the <see cref="OPCServerTreeNodes"/> class with the specified label text.
    /// </summary>
    /// <param name="server">The server to add.</param>
    /// <param name="view">The <see cref="TreeView"/> to add new object..</param>
    internal ConnectDataNode( string text, ObjectType obj, ParentType node )
      : base( text, obj, node )
    { }
    /// <summary>
    /// Initializes a new instance of the <see cref="ConnectDataNode&lt;OPCType&gt;"/> class.
    /// </summary>
    /// <param name="text">The text.</param>
    /// <param name="obj">The obj.</param>
    /// <param name="filters">The filters.</param>
    /// <param name="specification">The preferred specification.</param>
    /// <param name="view">The view.</param>
    internal ConnectDataNode( string text, ObjectType obj, OpcDa::BrowseFilters filters, Opc.Specification specification )
      : base( text, obj, filters )
    {
      m_Spcification = specification;
    }
    #endregion
    #region IConnectDataNode
    internal bool ConnectionDataIsSet { get { return m_CD != null; } }
    public Opc.ConnectData ConnectDataObject
    {
      get
      {
        if ( m_CD != null )
          return m_CD;
        ParentType parentCN = this.Parent;
        return ( parentCN == null ) ? new Opc.ConnectData( null ) : parentCN.ConnectDataObject;
      }
      set { m_CD = value; }
    }
    #endregion
    #region IConnectDataNode Members
    /// <summary>
    /// Gets or sets the default specification of the servers being displayed in the control.
    /// </summary>
    /// <value>The default specification.</value>
    public virtual Opc.Specification DefaultSpecification
    {
      get
      {
        if ( !string.IsNullOrEmpty( m_Spcification.ID ) )
          return m_Spcification;
        return ( Parent == null ) ? Opc.Specification.COM_DA_30 : Parent.DefaultSpecification;
      }
      set { m_Spcification = value; }
    }
    #endregion
  }
  /// <summary>
  /// Discovery tree node
  /// </summary>
  /// <typeparam name="ObjectType">The type of the bject type.</typeparam>
  /// <typeparam name="ParentType">The type of the parent type.</typeparam>
  internal abstract class DiscoveryNode<ObjectType, ParentType>: ConnectDataNode<ObjectType, ParentType>
    where ObjectType: class
    where ParentType: class, IConnectDataNode
  {
    #region private
    protected abstract Opc.IDiscovery DiscoveryObject { get; } 
    #endregion
    #region constructors
    /// <summary>
    /// Initializes a new instance of the <see cref="OPCServerTreeNodes"/> class with the specified label text.
    /// </summary>
    /// <param name="server">The server to add.</param>
    /// <param name="view">The <see cref="TreeView"/> to add new object..</param>
    internal DiscoveryNode( string text, ObjectType obj, ParentType node )
      : base( text, obj, node )
    { }
    /// <summary>
    /// Initializes a new instance of the <see cref="DiscoveryNode&lt;ObjectType, ParentType&gt;"/> class.
    /// </summary>
    /// <param name="text">The text.</param>
    /// <param name="obj">The server to add.</param>
    /// <param name="filters">The filters.</param>
    /// <param name="specification">The specification.</param>
    internal DiscoveryNode( string text, ObjectType obj, OpcDa::BrowseFilters filters, Opc.Specification specification )
      : base( text, obj, filters, specification )
    { } 
    #endregion
  }
}
