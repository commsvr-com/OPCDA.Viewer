//<summary>
//  Title   : Tracer in CAS.Lib.OPCClientControlsLib related assemblies
//  System  : Microsoft Visual C# .NET 
//  $LastChangedDate$
//  $Rev$
//  $LastChangedBy$
//  $URL$
//  $Id$
//  History :
//    20091008: mbzrzezny: created based on: CAS.Lib.ControlLibrary.TraceEvent
//    20090715: mzbrzezny: created
//
//  Copyright (C)2009, CAS LODZ POLAND.
//  TEL: +48 (42) 686 25 47
//  mailto:techsupp@cas.eu
//  http://www.cas.eu
//</summary>

using CAS.Lib.RTLib.Processes;

namespace CAS.Lib.OPCClientControlsLib
{
  /// <summary>
  /// class responsible for tracing inside CAS.Lib.OPCClientControlsLib related assemblies - 
  /// please use TraceSource:
  /// "CAS.Lib.OPCClientControlsLib"
  /// </summary>  
  internal class Tracer
  {
    private static TraceEvent m_traceevent_internal =
      new TraceEvent( typeof( Tracer ).Namespace.ToString() );
    /// <summary>
    /// Gets the tracer.
    /// </summary>
    /// <value>The tracer.</value>
    internal static TraceEvent MainTracer
    {
      get
      {
        return m_traceevent_internal;
      }
    }
  }
}

