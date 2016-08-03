//<summary>
//  Title   : Name of Application
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

using CAS.Lib.ControlLibrary;

namespace CAS.Lib.OPC.AddressSpace
{
  /// <summary>
  /// Interface providing functionality to save configuration
  /// </summary>
  public interface ISave: ITreeNodeInterface
  {
    /// <summary>
    /// Saves the configuration specified in the <see cref="AddressSpaceDataBase" />.
    /// </summary>
    /// <param name="config">The configuration <see cref="AddressSpaceDataBase" />.</param>
    void Save( AddressSpaceDataBase config );
    /// <summary>
    /// Saves the object children in the specified configuration.
    /// </summary>
    /// <param name="config">The config <see cref="AddressSpaceDataBase"/>.</param>
    /// <param name="parentKey">The parent key.</param>
    /// <param name="root">if set to <c>true</c> root element.</param>
    void Save( AddressSpaceDataBase config, int parentKey, bool root );
  }
  /// <summary>
  /// Saves the configuration specified.
  /// </summary>
  /// <typeparam name="ObjectType">The type of the object type.</typeparam>
  /// <typeparam name="ParentType">The type of the parent type.</typeparam>
  public abstract class SaveableTreeNode<ObjectType, ParentType>: GenericTreeNode<ObjectType, ParentType>, ISave
    where ObjectType: class
    where ParentType: class, ISave
  {
    #region Constructors
    /// <summary>
    /// Initializes a new instance of the class.
    /// </summary>
    /// <param name="text">The label <see cref="System.Windows.Forms.TreeNode.Text"/> of the new tree node.</param>
    /// <param name="obj">The object coupled with the node.</param>
    /// <param name="node">The node to add new object.</param>
    public SaveableTreeNode( string text, ObjectType obj, ParentType node )
      : base( text, obj, node )
    { }
    /// <summary>
    /// Initializes a new instance of the  class.
    /// </summary>
    /// <param name="text">The label <see cref="System.Windows.Forms.TreeNode.Text"/> of the new tree node.</param>
    /// <param name="obj">The object coupled with the node.</param>
    public SaveableTreeNode( string text, ObjectType obj )
      : base( text, obj )
    { }
    #endregion
    #region ISave Members
    /// <summary>
    /// Saves the object children in the specified configuration.
    /// </summary>
    /// <param name="config">The config <see cref="AddressSpaceDataBase"/>.</param>
    /// <param name="parentKey">The parent key.</param>
    /// <param name="root">if set to <c>true</c> root element.</param>
    public virtual void Save( AddressSpaceDataBase config, int parentKey, bool root )
    {
      System.Diagnostics.Debug.Assert( config != null, "Configuration data set cannot be null" );
      foreach ( ISave br in Nodes )
        br.Save( config, parentKey, root );
    }
    /// <summary>
    /// Saves the configuration specified in the <see cref="AddressSpaceDataBase"/>.
    /// </summary>
    /// <param name="config">The configuration <see cref="AddressSpaceDataBase"/>.</param>
    public void Save( AddressSpaceDataBase config )
    {
      Save( config, int.MinValue, true );
    }
    #endregion
  }
}
