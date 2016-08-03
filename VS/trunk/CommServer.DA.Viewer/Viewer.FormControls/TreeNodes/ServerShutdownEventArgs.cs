//<summary>
//  Title   : is the class containing event data for ServerShutdown event.
//  System  : Microsoft Visual C# .NET 2008
//  $LastChangedDate:$
//  $Rev:$
//  $LastChangedBy:$
//  $URL:$
//  $Id:$
//
//  Copyright (C)2008, CAS LODZ POLAND.
//  TEL: +48 (42) 686 25 47
//  mailto://techsupp@cas.eu
//  http://www.cas.eu
//</summary>
using System;
namespace CAS.Lib.OPCClientControlsLib.TreeNodes
{
  /// <summary>
  /// <see cref="ServerShutdownEventArgs"/> is the class containing event data for ServerShutdown event.
  /// </summary>
  internal class ServerShutdownEventArgs: EventArgs
  {
    internal string reason;
    internal ServerShutdownEventArgs( string rsn )
    {
      reason = rsn;
    }
  }
}

