//<summary>
//  Title   : Subscriptions for Read and Write Operations Control
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
using CAS.Lib.OPCClient.Da;
using CAS.Lib.OPCClientControlsLib.TreeNodes.Session;
using OpcDa = global::Opc.Da;

namespace CAS.Lib.OPCClientControlsLib
{
  /// <summary>
  /// Subscriptions for Read and Write Operations Control
  /// </summary>
  public class Subscriptions4RWControl: SessionTreeControlBase
  {
    #region constructor
    /// <summary>
    /// Initializes a new instance of the <see cref="SubscriptionsReadWriteControl"/> class.
    /// </summary>
    public Subscriptions4RWControl()
    { }
    #endregion
    #region public
    /// <summary>
    /// Initializes the control with the specified server.
    /// </summary>
    public void Initialize( OpcDa::BrowseFilters filters, Subscription subscription )
    {
      // Add the subscription at the root of the tree
      if ( subscription == null )
        throw new ArgumentNullException( "subscription" );
      m_SubscriptionTreeView.Nodes.Add( new SubscriptionTreeNode4RW( subscription ) );
    }
    #endregion
  }
}
