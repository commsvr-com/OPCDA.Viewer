//<summary>
//  Title   : The main (starting) point of the OPC Viewer
//  System  : Microsoft Visual C# .NET 2008
//  $LastChangedDate$
//  $Rev$
//  $LastChangedBy$
//  $URL$
//  $Id$
//
//  Copyright (C)2009, CAS LODZ POLAND.
//  TEL: +48 (42) 686 25 47
//  mailto://techsupp@cas.eu
//  http://www.cas.eu
//</summary>

using CAS.Lib.CodeProtect;
using CAS.Lib.OPCClientControlsLib;
using System;
using System.Deployment.Application;
using System.Diagnostics;
using System.Security;
using System.Security.Permissions;
using System.Web;
using System.Windows.Forms;

namespace CAS.OPCViewer
{
  /// <summary>
  /// Class Program.
  /// </summary>
  public class Program
  {

    [STAThread]
    static void Main()
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      AssemblyTraceEvent.Tracer.TraceEvent(TraceEventType.Verbose, 39, "Starting application.");
      string _commandLine = Environment.CommandLine;
#if DEBUG
      if (_commandLine.ToLower().Contains("debugstop"))
        MessageBox.Show("Attach debug point");
#endif
      bool _isDebugRun = _commandLine.ToLower().Contains(m_InstallLicenseDebugerArgument);
      if (IsFirstRun() || _isDebugRun)
      {
        try
        {
          AssemblyTraceEvent.Tracer.TraceEvent(TraceEventType.Verbose, 49, $"Installing license because IsFirstRun={IsFirstRun()} is debug={_isDebugRun}.");
          LibInstaller.InstallLicense(false);
        }
        catch (Exception ex)
        {
          string _message = $"Installing license has failed, reason: {ex.Message}.";
          AssemblyTraceEvent.Tracer.TraceEvent(TraceEventType.Error, 55, _message);
          MessageBox.Show(_message, "License Installation error", MessageBoxButtons.OK, MessageBoxIcon.Error );
        }
      }
      try
      {
        SecurityPermission permission = new SecurityPermission(SecurityPermissionFlag.UnmanagedCode);
        if (!SecurityManager.IsGranted(permission))
        {
          string msg = "";
          msg += "This application requires permission to access unmanaged code ";
          msg += "in order to connect to COM-DA servers directly.\r\n\r\n";
          msg += "Connections to XML-DA servers will not be affected.";
          MessageBox.Show(msg, "CAS OPCViewer Data Access Client");
        }
        MainFormV2008 mainForm;
        string[] args = GetArguments();
        if (args == null || args.Length < 2 || string.IsNullOrEmpty(args[1]) || args[1].Contains(m_InstallLicenseDebugerArgument) || args[1].Contains("http://"))
          mainForm = new MainFormV2008();
        else
          mainForm = new MainFormV2008(args[1]); //args[ 0 ] - is application file name , args[ 1 ] - is first argument 
        if (ApplicationDeployment.IsNetworkDeployed)
          mainForm.DoNotShowUnlockCodeToolStrip();
        Application.Run(mainForm);
      }
      catch (Exception e)
      {
        string _message = $"An unexpected exception occurred. Application exiting with error:\r\n\r\n {e.Message}";
        AssemblyTraceEvent.Tracer.TraceEvent(TraceEventType.Error, 84, _message);
        MessageBox.Show(_message, "OPCViewer - Data Access Client", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }
    private readonly static string m_InstallLicenseDebugerArgument = "installic";
    /// <summary>
    /// Gets the arguments from command line (if this application is started from the commands line)
    /// or from activation url (if it is network deployed, e.g. as ClickOnce)
    /// </summary>
    /// <returns>Array of <see cref="System.String"/> containing the arguments.</returns>
    private static string[] GetArguments()
    {
      if (ApplicationDeployment.IsNetworkDeployed && ApplicationDeployment.CurrentDeployment.ActivationUri != null)
      {
        string query = HttpUtility.UrlDecode(ApplicationDeployment.CurrentDeployment.ActivationUri.Query);
        if (!string.IsNullOrEmpty(query) && query.StartsWith("?"))
        {
          string[] arguments = query.Substring(1).Split(' ');
          string[] commandLineArgs = new string[arguments.Length + 1];
          commandLineArgs[0] = Environment.GetCommandLineArgs()[0];
          arguments.CopyTo(commandLineArgs, 1);
          return commandLineArgs;
        }
      }
      if (AppDomain.CurrentDomain.SetupInformation != null &&
          AppDomain.CurrentDomain.SetupInformation.ActivationArguments != null &&
          AppDomain.CurrentDomain.SetupInformation.ActivationArguments.ActivationData != null)
      {
        string[] arguments = AppDomain.CurrentDomain.SetupInformation.ActivationArguments.ActivationData;
        string[] commandLineArgs = new string[arguments.Length + 1];
        commandLineArgs[0] = Environment.GetCommandLineArgs()[0];
        arguments.CopyTo(commandLineArgs, 1);
        return commandLineArgs;
      }
      return Environment.GetCommandLineArgs();
    }
    private static bool IsFirstRun()
    {
      try
      {
        return ApplicationDeployment.IsNetworkDeployed && ApplicationDeployment.CurrentDeployment.IsFirstRun;
      }
      catch (DeploymentException)
      {
        return false;
      }
    }
  }
}
