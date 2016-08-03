//<summary>
//  Title   : TreeNode representing the network
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
using CAS.Lib.ControlLibrary;
using OpcDa = Opc.Da;

namespace CAS.Lib.OPCClientControlsLib.TreeNodes.Browse
{
  /// <summary>
  /// TreeNode representing the network
  /// </summary>
  internal abstract class NetworkTreeNode: DiscoveryNode<object, IConnectDataNode>
  {
    #region private
    private class Computer: ComputerTreeNodes
    {
      private NetworkTreeNode m_Parent;
      internal Computer( NetworkTreeNode parent, string computerName )
        : base( computerName, parent )
      {
        m_Parent = parent;
      }
      protected override Opc.IDiscovery DiscoveryObject
      {
        get { return m_Parent.DiscoveryObject; }
      }

      public override ContextMenuStrip Menu
      {
        get { throw new NotImplementedException(); }
      }
    }
    /// <summary>
    /// Browses for computers on the network.
    /// </summary>
    protected override void BranchBrowse()
    {
      try
      {
        string[] hosts = DiscoveryObject.EnumerateHosts();
        if ( hosts == null )
          return;
        // add children.
        foreach ( string host in hosts )
          new Computer( this, host );
      }
      catch ( Exception e ) { MessageBox.Show( e.Message ); }
    }
    protected override void AssignImageIndex()
    {
      this.ImageIndex = this.SelectedImageIndex = (int)ImageListLibrary.Icons.IMAGE_NETWORK;
      this.ToolTipText = Properties.Resources.NetworkTreeNodeToolTip;
    }
    #endregion
    #region constructor
    /// <summary>
    /// Initializes a new instance of the <see cref="NetworkTreeNode"/> class with the specified label text.
    /// </summary>
    /// <param name="text">The text.</param>
    /// <param name="filters">The filters.</param>
    /// <param name="specification">The specification.</param>
    internal NetworkTreeNode( string text, OpcDa::BrowseFilters filters, Opc.Specification specification )
      : base( text, null, filters, specification )
    {
      AssignImageIndex();
    }
    #endregion
    #region IBrowse
    /// <summary>
    /// Gets the type of the get node.
    /// </summary>
    /// <value>The type of the get node.</value>
    public override NodeType GetNodeType { get { return NodeType.Network; } }
    #endregion
  }
}
