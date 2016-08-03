//<summary>
//  Title   : TreeNode representing a computer
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
using OpcDa = Opc.Da;

namespace CAS.Lib.OPCClientControlsLib.TreeNodes.Browse
{
  using ControlLibrary;
  using OPCClient.Da;

  /// <summary>
  /// TreeNode representing a computer
  /// </summary>
  internal abstract class ComputerTreeNodes: DiscoveryNode<object, IConnectDataNode>
  {
    #region private
    /// <summary>
    /// Assigns the index of the image.
    /// </summary>
    protected override void AssignImageIndex()
    {
      this.ImageIndex = this.SelectedImageIndex = (int)ImageListLibrary.Icons.IMAGE_MYCOMPUTER;
      this.ToolTipText = Properties.Resources.ComputerTreeNodesToolTip;
    }
    /// <summary>
    ///Browses for servers a computer.
    /// </summary>
    /// <param name="shallowBrowse">if set to <c>true</c> stop browsing at this level, go to leaves otherwise.</param>
    protected override void BranchBrowse()
    {
      try
      {
        // find the servers.
        global::Opc.Server[] servers = DiscoveryObject.GetAvailableServers( this.DefaultSpecification, this.Text, this.ConnectDataObject );
        // add children.
        if ( servers == null )
          return;
        foreach ( global::Opc.Server server in servers )
        {
          new OPCBrowseServer( (Server)Factory.GetServerForURL( server.Url, DefaultSpecification ), this );
          server.Dispose();
        }
      }
      catch ( Exception e ) { MessageBox.Show( e.Message ); }
    }
    #endregion
    #region constructor
    /// <summary>
    /// Initializes a new instance of the <see cref="ComputerTreeNodes"/> class with the specified label text.
    /// </summary>
    /// <param name="computerName">Name of the computer.</param>
    /// <param name="filters">The filters.</param>
    /// <param name="specification">The specification.</param>
    internal ComputerTreeNodes( string computerName, OpcDa::BrowseFilters filters, Opc.Specification specification )
      : base( computerName, null, filters, specification )
    {
      AssignImageIndex();
      AddDummyNode();
    }
    /// <summary>
    /// Initializes a new instance of the <see cref="ComputerTreeNodes"/> class.
    /// </summary>
    /// <param name="computerName">Name of the computer.</param>
    /// <param name="networkTreeNode">The network tree node.</param>
    internal ComputerTreeNodes( string computerName, NetworkTreeNode networkTreeNode )
      : base( computerName, null, networkTreeNode )
    {
      AssignImageIndex();
      AddDummyNode();
    }
    #endregion
    #region IBrowse
    /// <summary>
    /// Gets the type of the node.
    /// </summary>
    /// <value>The type of the gnode.</value>
    public override NodeType GetNodeType { get { return NodeType.Computer; } }
    #endregion
  }
}
