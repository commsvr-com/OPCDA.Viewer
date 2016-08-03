//<summary>
//  Title   : Common interface to be implemented by all tree nodes used with the session components.
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

using CAS.Lib.OPCClient.Da;

namespace CAS.Lib.OPCClientControlsLib.TreeNodes
{
  /// <summary>
  /// Common interface to be implemented by all tree nodes used with the session components.
  /// </summary>
  public interface ITreeNodeCommon
  {
    /// <summary>
    /// Finds the server.
    /// </summary>
    /// <returns>The server at the top of this tree</returns>
    global::Opc.Da.BrowseFilters DefaultBrowseFilters { get; set; }
    /// <summary>
    /// Gets or sets the default browse filters.
    /// </summary>
    /// <value>The default browse filters.</value>
    Server FindServer();
  }
}
