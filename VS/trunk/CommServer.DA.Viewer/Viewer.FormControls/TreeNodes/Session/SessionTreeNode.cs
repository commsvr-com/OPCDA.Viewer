//<summary>
//  Title   : Session Tree Node
//  System  : Microsoft Visual C# .NET 2008
//  $LastChangedDate$
//  $Rev$
//  $LastChangedBy$
//  $URL$
//  $Id$
//
//    20080515: mzbrzezny: event EventHandler<ServerEventArgs> SelectServer is added
//    2008: mpostol: created
//
//  Copyright (C)2008, CAS LODZ POLAND.
//  TEL: +48 (42) 686 25 47
//  mailto://techsupp@cas.eu
//  http://www.cas.eu
//</summary>

using CAS.DataPorter.Configurator;
using CAS.Lib.OPCClient.Da;

namespace CAS.Lib.OPCClientControlsLib.TreeNodes.Session
{
  /// <summary>
  /// Session Tree Node
  /// </summary>
  /// <typeparam name="ObjectType">The type of the bject type.</typeparam>
  /// <typeparam name="ParentType">The type of the parent type.</typeparam>
  public abstract class SessionTreeNode<ObjectType, ParentType>: SaveableTreeNode<ObjectType, ParentType>, ISession
    where ObjectType: class
    where ParentType: class, ISession
  {
    #region private
    private global::Opc.Da.BrowseFilters m_BrowseFilters = null;

    #endregion
    #region constructors
    /// <summary>
    /// Initializes a new instance of the <see cref="SessionTreeNode&lt;ObjectType, ParentType&gt;"/> class.
    /// </summary>
    /// <param name="text">The label <see cref="System.Windows.Forms.TreeNode.Text"/> of the new tree node.</param>
    /// <param name="obj">The object coupled with the node.</param>
    /// <param name="node">The node to add new object.</param>
    public SessionTreeNode( string text, ObjectType obj, ParentType node )
      : base( text, obj, node )
    { }
    /// <summary>
    /// Initializes a new instance of the  class.
    /// </summary>
    /// <param name="text">The label <see cref="System.Windows.Forms.TreeNode.Text"/> of the new tree node.</param>
    /// <param name="obj">The object coupled with the node.</param>
    public SessionTreeNode( string text, ObjectType obj )
      : base( text, obj )
    { }
    #endregion constructors
    #region ITreeNodeCommon Members
    public virtual global::Opc.Da.BrowseFilters DefaultBrowseFilters
    {
      get
      {
        if ( m_BrowseFilters != null )
          return m_BrowseFilters;
        if ( Parent == null )
          return new global::Opc.Da.BrowseFilters();
        return Parent.DefaultBrowseFilters;
      }
      set
      {
        m_BrowseFilters = value;
      }
    }
    public virtual Server FindServer()
    {
      return Parent == null ? null : Parent.FindServer();
    }
    #endregion ITreeNodeCommon Members
  }
}
