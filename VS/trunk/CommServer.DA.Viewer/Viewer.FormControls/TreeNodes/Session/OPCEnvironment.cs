//<summary>
//  Title   : Class representing the most top tree node of OPC environment in the session panel.
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

using CAS.DataPorter.Configurator;
using CAS.Lib.ControlLibrary;
using System.Windows.Forms;

namespace CAS.Lib.OPCClientControlsLib.TreeNodes.Session
{
  using Properties;
  /// <summary>
  /// Class representing the most top tree node of OPC environment in the session panel.
  /// </summary>
  public class OPCEnvironment: SessionTreeNode<object, ISession>
  {
    #region private
    protected override void AssignImageIndex()
    {
      this.ImageIndex = SelectedImageIndex = (int)ImageListLibrary.Icons.IMAGE_OPC_ENVIRONMENT;
      this.ToolTipText = this.ToolTipText = Resources.TreeNodeOPCEnvironmentToolTip;
    }
    #endregion
    #region constructor
    /// <summary>
    /// Initializes a new instance of the <see cref="OPCEnvironment"/> class.
    /// </summary>
    public OPCEnvironment()
      : base( Resources.TreeNodeOPCEnvironmentText, null )
    {
      AssignImageIndex();
    }
    #endregion
    #region public
    /// <summary>
    /// Disconnect all servers in the session.
    /// </summary>
    public void DisconnectAll()
    {
      foreach ( OPCSessionServer svr in this.Nodes )
        svr.Disconnect();
    }
    internal void CreateChildren( OPCCliConfiguration configuration )
    {
      foreach ( OPCCliConfiguration.ServersRow svr in configuration.Servers )
      {
        var node = new OPCSessionServer( svr, null, this );
        if ( svr.IsConnected )
          node.Connect();
      }
    }
    #endregion
    #region ITreeNodeInterface
    /// <summary>
    /// Gets the tree current context menu.
    /// </summary>
    /// <value>The menu <see cref="ContextMenuStrip"/>.</value>
    /// <remarks>Implements <see cref="ITreeNodeInterface"/>.</remarks>
    public override ContextMenuStrip Menu
    {
      get { return null; }
    }
    #endregion
  }
}
