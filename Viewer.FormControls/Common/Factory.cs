//============================================================================
// TITLE: CAS.Lib.OPCClientControlsLib.Factory.cs
//
// CONTENTS:
// 
// A interface and a class used to instantiate server objects.
//
// (c) Copyright 2003-2004 The OPC Foundation
// ALL RIGHTS RESERVED.
//
// DISCLAIMER:
//  This code is provided by the OPC Foundation solely to assist in 
//  understanding and use of the appropriate OPC Specification(s) and may be 
//  used as set forth in the License Grant section of the OPC Specification.
//  This code is provided as-is and without warranty or support of any sort
//  and is subject to the Warranty and Liability Disclaimers which appear
//  in the printed OPC Specification.
//
// MODIFICATION LOG:
//
// Date       By    Notes
// ---------- ---   -----
// 2003/08/18 RSA   Initial implementation.

using System;
using CAS.Lib.OPCClient.Da;

namespace CAS.Lib.OPCClientControlsLib
{
  /// <summary>
  /// Defines utility functions used to instantiate servers.
  /// </summary>
  public class Factory
  {
    /// <summary>
    /// Creates a server object for the specified URL.
    /// </summary>
    public static global::Opc.Server GetServerForURL( Opc.URL url, Opc.Specification preferedspecification )
    {
      if ( url == null )
        throw new ArgumentNullException( "url" );

      global::Opc.Server server = null;

      // create an unconnected server object for XML based servers.
      if ( url.Scheme == Opc.UrlScheme.HTTP )
      {
        throw new NotImplementedException("TODO - reoved dependency on OpcXml assembly.");
        //server = new Server( new OpcXml.Factory(), url, preferedspecification );
      }

      // create an unconnected server object for COM based servers.
      else
      {
        // DA
        if ( url.Scheme == Opc.UrlScheme.DA )
        {
          server = new Server( new OpcCom.Factory(), url, preferedspecification );
        }

        // AE
        else if ( url.Scheme == Opc.UrlScheme.AE )
        {
          server = new global::Opc.Ae.Server( new OpcCom.Factory(), url, preferedspecification );
        }

        // HDA
        else if ( url.Scheme == Opc.UrlScheme.HDA )
        {
          server = new global::Opc.Hda.Server( new OpcCom.Factory(), url, preferedspecification );
        }

        // DX
        else if ( url.Scheme == Opc.UrlScheme.DX )
        {
          server = new global::Opc.Dx.Server( new OpcCom.Factory(), url, preferedspecification );
        }

#if (UA)
				// UA
				else if (url.Scheme == UrlScheme.UA_TCP || url.Scheme == UrlScheme.UA_HTTP)  
				{ 
					server = new Opc.Ua.Server(new OpcXml.Factory(), url,preferedspecification); 
				}
#endif

        // Other specifications not supported yet.
        else
        {
          throw new NotSupportedException( url.Scheme );
        }
      }

      return server;
    }
  }
}
