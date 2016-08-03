//<summary>
//  Title   : Tracer in CAS.OPCViewer related assemblies
//  System  : Microsoft Visual C# .NET 
//  $LastChangedDate$
//  $Rev$
//  $LastChangedBy$
//  $URL$
//  $Id$
//  History :
//    20090924: mbzrzezny: created based on: CAS.Lib.ControlLibrary.TraceEvent
//    20090715: mzbrzezny: created
//
//  Copyright (C)2009, CAS LODZ POLAND.
//  TEL: +48 (42) 686 25 47
//  mailto:techsupp@cas.eu
//  http://www.cas.eu
//</summary>

using CAS.Lib.RTLib.Processes;

namespace CAS.OPCViewer
{
  /// <summary>
  /// class responsible for tracing inside CAS.OPCViewer related assemblies - 
  /// please use TraceSource:
  /// "CAS.OPCViewer"
  /// </summary>  
  internal class Tracer
  {
    private static TraceEvent m_traceevent_internal =
      new TraceEvent( typeof( Tracer ).Namespace );
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

