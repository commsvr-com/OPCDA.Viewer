//<summary>
//  Title   : Intrface represents browse functionality of the tree nodes used as nodes for browse tree
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
using System.Collections.Generic;
using System.Text;
using OpcDa = global::Opc.Da;

namespace CAS.Lib.OPCClientControlsLib.TreeNodes.Browse
{
  using OPC.AddressSpace;
  /// <summary>
  ///Type of the node;
  /// </summary>
  public enum NodeType { OPCServer, Computer, Network, BrowseElement, Item, Property, PropertyValue, DummyNode }
  /// <summary>
  /// Intrface represents browse functionality of the tree nodes used as nodes for browse tree.
  /// </summary>
  public interface IBrowse: ISave, ITreeNodeCommon
  {
    /// <summary>
    /// Get the type of the node.
    /// </summary>
    /// <value>The type of the Node.</value>
    NodeType GetNodeType { get; }
    /// <summary>
    /// Refreshes this instance.
    /// </summary>
    void Refresh();
    /// <summary>
    /// Browses the address space.
    /// </summary>
    /// <param name="shallow">if set to <c>true</c> shallow stop at this level, otherwise browse up to the bottom..</param>
    void Browse( bool shallow );
  }
}
