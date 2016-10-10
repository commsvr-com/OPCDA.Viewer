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
using System.Collections.Specialized;
using System.Deployment.Application;
using System.Security;
using System.Security.Permissions;
using System.Web;
using System.Windows.Forms;

namespace CAS.OPCViewer
{
  class Program
  {
    private readonly static string str_installic_argument = "installic";

    /// <summary>
    /// Gets the arguments from command line (if this application is tradicionaly opened),
    /// or from activation url (if it is network deployed, e.g. as clickonce)
    /// </summary>
    /// <returns></returns>
    private static string[] GetArguments()
    {
      if (ApplicationDeployment.IsNetworkDeployed &&
          ApplicationDeployment.CurrentDeployment.ActivationUri != null)
      {
        string query = HttpUtility.UrlDecode(
            ApplicationDeployment.CurrentDeployment.ActivationUri.Query);
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

    [STAThread]
    static void Main()
    {
#if DEBUG
      string m_cmmdLine = Environment.CommandLine;
      if (m_cmmdLine.ToLower().Contains("debugstop"))
        MessageBox.Show("Attach debug point");
      GetQueryStringParameters();
      if (m_cmmdLine.ToLower().Contains(str_installic_argument))
      {
        try
        {
          CAS.Lib.CodeProtect.LibInstaller.InstalLicense(true);
        }
        catch (Exception ex)
        {
          MessageBox.Show("License installation has failed, reason: " + ex.Message);
        }
      }
#endif
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
        if (args == null || args.Length < 2 || string.IsNullOrEmpty(args[1]) || args[1].Contains(str_installic_argument) || args[1].Contains("http://"))
          mainForm = new MainFormV2008();
        else
          mainForm = new MainFormV2008(args[1]); //args[ 0 ] - is application file name , args[ 1 ] - is first argument 
        if (ApplicationDeployment.IsNetworkDeployed)
          mainForm.DoNotShowUnlockCodeToolStrip();
        Application.Run(mainForm);
      }
      catch (Exception e)
      {
        MessageBox.Show("An unexpected exception occurred. Application exiting.\r\n\r\n" + e.Message,
          "OPCViewer - Data Access Client", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }
    private static void GetQueryStringParameters()
    {
      if (ApplicationDeployment.IsNetworkDeployed)
      {
        Uri m_Uri = ApplicationDeployment.CurrentDeployment.ActivationUri;
        if (m_Uri != null)
        {
          NameValueCollection m_Switches = HttpUtility.ParseQueryString(m_Uri.Query);
          //TODO: ???
          //see: http://itrserver.hq.cas.com.pl/Bugs/BugDetail.aspx?bid=2618
        }
        if (ApplicationDeployment.CurrentDeployment.IsFirstRun)
          LibInstaller.InstalLicense(Environment.UserName, Environment.MachineName, Environment.UserDomainName, true);
      }
    }

  }
}
