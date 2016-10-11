//<summary>
//  Title   : Main form of OPC VIewer
//  System  : Microsoft Visual C# .NET 2005
//  $LastChangedDate$
//  $Rev$
//  $LastChangedBy$
//  $URL$
//  $Id$
//  Copyright (C)2008, CAS LODZ POLAND.
//  TEL: +48 (42) 686 25 47
//  mailto:techsupp@cas.eu
//  http://www.cas.eu
//</summary>

using CAS.DataPorter.Configurator.HMI.Wrappers;
using CAS.Lib.CodeProtect;
using CAS.Lib.CodeProtect.Controls;
using CAS.Lib.CodeProtect.LicenseDsc;
using CAS.Lib.ControlLibrary;
using CAS.Lib.OPCClient.Da;
using CAS.Lib.OPCClientControlsLib.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Reflection;
using System.Resources;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Windows.Forms;
using OpcDa = Opc.Da;

namespace CAS.Lib.OPCClientControlsLib
{
  /// <summary>
  /// OPCViewer startup class
  /// </summary>
  public partial class MainFormV2008 : Form
  {

    #region constructor
    /// <summary>
    /// Initializes a new instance of the <see cref="MainFormV2008"/> class.
    /// </summary>
    public MainFormV2008()
    {
      CheckLicense();
      InitializeComponent();
      if (maintenanceControlComponent.Warning != null)
        TraceEvent.Tracer.TraceInformation(62, this.GetType().Name + ".ctor", "The following warning(s) appeared during loading the license: " + maintenanceControlComponent.Warning);
      DoNotShowUnlockCodeToolStrip();
      m_SubscriptionCTRL.InitializeSession();
      serviceControlToolStrip_DataPorter.Enabled = m_SubscriptionCTRL.IsProcessingEnvironmentEnabled;
      this.m_MainTabControl.Controls.Remove(m_TabPage_ProcessingEnvironment);
      m_TSMI_Session.DropDownItems.AddRange(m_SubscriptionCTRL.ConfigurationMenu);
      m_ServerStateItems.Add(m_TSB_Disconnect);
      m_ServerStateItems.Add(m_TSB_GetServerStatus);
      m_ServerStateItems.Add(m_TSM_IDisconnect);
      m_ServerStateItems.Add(m_TSM_Status);
      SetServerStateItems = true;
      // connect the updates control to the subscriptions control.
      Subscription.SubscriptionModified += new Subscription.SubscriptionModifiedCallback(m_UpdatesCTRL.OnSubscriptionModified);
      CAS.Lib.OPCClientControlsLib.TreeNodes.Session.OPCSessionServer.SelectServer += this.m_StatusCTRL.OnSelectServer;
      TransactionRowWrapper.SelectedTransactionHasChanged +=
        new EventHandler<GenericEventArgs<TransactionRowWrapper>>(TransactionRowWrapper_SelectTransactionEventHandler);
      // register for trace/debug output from the updates control.
      m_UpdatesCTRL.UpdateEvent += new UpdateEvent_EventHandler(OnUpdateEvent);
      //#if (DEBUG)
      //      // initialize the set of known servers.
      //      URL[] knownURLs = new URL[] 
      //      {
      //        new URL("opcda://localhost/OPCSample.OpcDaServer"),
      //        new URL("opcda://localhost/OPCSample.OpcDa30Server"),
      //        new URL("opcda://localhost/OPCSample.OpcDa20Server"),
      //        new URL("opcda://localhost/CAS.CommServer.OPC.Da.Server"),
      //        new URL("http://localhost/Source/XmlDaSampleServer/Service.asmx"),
      //        new URL("http://opcfoundation.org/XmlDaSampleServer/Service.asmx"),
      //      };
      //#else
      //      // initialize the set of known servers.
      //      URL[] knownURLs = new URL[] 
      //      {
      //        new URL("opcda://localhost/CAS.CommServer.OPC.Da.Server"),
      //      };
      //#endif
      m_SelectServerStrip.Initialize(null, 0, Opc.Specification.COM_DA_30);
      SelectTargetCTRL.Initialize(null, 0, Opc.Specification.COM_DA_30);
      LoadSettings();
      // register for server connected callbacks.
      m_SelectServerStrip.ServerSelectedEvent += new ConnectServer_EventHandler(OnConnect);
      SelectTargetCTRL.ServerSelectedEvent += new ConnectServer_EventHandler(OnConnectTarget);
    }
    /// <summary>
    /// Initializes a new instance of the <see cref="MainFormV2008"/> class.
    /// </summary>
    /// <param name="SessionFileName">Name of the session file to be opened at startup.</param>
    public MainFormV2008(string SessionFileName)
      : this()
    {
      TraceEvent.Tracer.TraceInformation(104, this.GetType().Name + ".ctor", "Openning: " + SessionFileName);
      m_SubscriptionCTRL.OpenSession(SessionFileName);
    }
    /// <summary>
    /// Don't show the unlock code tool strip if it is not applicable.
    /// </summary>
    public void DoNotShowUnlockCodeToolStrip()
    {
      enterTheUnlockCodeToolStripMenuItem.Enabled = false;
      enterTheUnlockCodeToolStripMenuItem.Visible = false;
    }
    #endregion

    #region private

    #region classes
    [Serializable]
    private class UserAppData
    {
      public Opc.URL[] KnownUrls = null;
      public int SelectedURL = -1;
      public string ProxyServer = null;
    }
    /// <summary>
    /// A class that DX configuration.
    /// </summary>
    [Serializable]
    private class DXConfiguration
    {
      public Server Target = null;
      public Opc.Dx.DXConnection[] DXConnections = null;
    }
    #endregion

    [LicenseProvider(typeof(CodeProtectLP))]
    [Guid("BFDDBFB8-332E-473b-9FDA-3621699BD28B")]
    private sealed class LicenseProtection : IsLicensed<LicenseProtection>
    {
      #region public
      internal static bool IsLicensed { get; private set; }
      internal static void CheckConstrain()
      {
        if (m_Checked)
          return;
        LicenseProtection sc = new LicenseProtection();
        IsLicensed = sc.Licensed;
        m_Checked = true;
      }
      internal static string TraceNoLicenseFileReason = String.Empty;
      #endregion

      #region private
      protected override void TraceNoLicenseFile(string reason)
      {
        base.TraceNoLicenseFile(reason);
        TraceNoLicenseFileReason = reason;
      }
      private LicenseProtection()
      {
        IsLicensed = this.Licensed;
      }
      static LicenseProtection()
      {
        CheckConstrain();
      }
      private static bool m_Checked = false;
      #endregion
    }
    private void CheckLicense()
    {
      LicenseProtection.CheckConstrain();
      if (string.IsNullOrEmpty(LicenseProtection.TraceNoLicenseFileReason))
        return;
      ScrollableMessageBox.Instance.Show(LicenseProtection.TraceNoLicenseFileReason, CodeProtect.Properties.Resources.Tx_LicCap, MessageBoxButtons.OK, MessageBoxIcon.Stop);
    }

    private List<ToolStripItem> m_ServerStateItems = new System.Collections.Generic.List<ToolStripItem>();
    private const string c_ServerConfigExtension = ".scnfg";
    private const string c_ServerFilterFormat = "Config Files (*{0})|*{0}|All Files (*.*)|*.*";
    private void SetSaveDialog(string extension, string defaultName, string title)
    {
      m_SaveFileDialog.DefaultExt = extension;
      m_SaveFileDialog.Filter = String.Format(c_ServerFilterFormat, extension);
      m_SaveFileDialog.FileName = defaultName;
      m_SaveFileDialog.Title = title;
    }
    private void SetOpenDialog(string extension, string defaultName, string title)
    {
      m_OpenFileDialog.DefaultExt = extension;
      m_OpenFileDialog.Filter = String.Format(c_ServerFilterFormat, extension);
      m_OpenFileDialog.FileName = defaultName;
      m_OpenFileDialog.Title = title;
    }
    private bool SetServerStateItems
    {
      set
      {
        foreach (ToolStripItem item in m_ServerStateItems)
          item.Enabled = value;
      }
    }
    /// <summary>
    /// The application configuration file path.
    /// </summary>
    private string ConfigFilePath
    {
      get { return InstallContextNames.ApplicationDataPath + "CAS.OPCViewer.vcnfg"; }
    }
    /// <summary>
    /// The default web proxy for the application - uses IE settings if null.
    /// </summary>
    private WebProxy m_proxy = null;
    private Server m_server { get { return m_SubscriptionCTRL.SelectedServer; } }
    /// <summary>
    /// The path of the current configuration file.
    /// </summary>
    private string m_configFile = null;
    /// <summary>
    /// The DX target server. 
    /// </summary>
    private Server m_target = null;
    //TODO: uncomment and implement
    ///// <summary>
    ///// The DX connections to the target server. 
    ///// </summary>
    //private Opc.Dx.DXConnection[] m_connections = null;
    //TODO allow to define filter at this global level
    private OpcDa::BrowseFilters m_filters = new OpcDa::BrowseFilters();
    private Server GetServer
    {
      get
      {
        if (m_server == null)
          return m_SelectServerStrip.GetServer as Server;
        else
          return m_server.Duplicate() as Server;
      }
    }
    #endregion

    #region Components event handlers
    private void TransactionRowWrapper_SelectTransactionEventHandler(object sender, GenericEventArgs<TransactionRowWrapper> e)
    {
      if (!m_MainTabControl.Contains(m_TabPage_ProcessingEnvironment))
        m_MainTabControl.Controls.Add(m_TabPage_ProcessingEnvironment);
      m_TabPage_ProcessingEnvironment.Controls.Clear();
      m_TabPage_ProcessingEnvironment.Controls.Add(e.Tag.GetUserControl().MainPanel);
      m_MainTabControl.SelectTab(m_TabPage_ProcessingEnvironment);
    }
    /// <summary>
    /// Called by the update control when something happens.
    /// </summary>
    private void OnUpdateEvent(object subscriptionHandle, object args)
    {
      // [OPV-966]: it causes unhanded exception while current server is disconnected.
      // try catch is added to protect from the exception
      // what is more the function is reviewed to and additional if (not null) are added)
      // after that the body of the function is uncommented (MZ: 20091008)
      try
      {
        if (m_server == null || m_server.Subscriptions == null)
          return;
        if (InvokeRequired)
        {
          BeginInvoke(new UpdateEvent_EventHandler(OnUpdateEvent), new object[] { subscriptionHandle, args });
          return;
        }
        if (typeof(string).IsInstanceOfType(args))
        {
          foreach (Subscription subscription in m_server.Subscriptions)
          {
            if (subscription == null || subscription.ClientHandle == null)
              continue;
            if (subscription.ClientHandle.Equals(subscriptionHandle))
            {
              m_OutputCTRL.AppendText(String.Format("{0}\t{1}\r\n", subscription.Name, (string)args));
              return;
            }
          }
        }
      }
      catch (Exception ex)
      {
        Tracer.MainTracer.TraceWarning(267, this.GetType().Name + ".OnUpdateEvent",
          Properties.Resources.MainFormUpdateEventHandlerException + ex.Message);
      }
    }
    /// <summary>
    /// Called to connect to a server.
    /// </summary>
    public void OnConnect(Opc.Server server)
    {
      m_configFile = string.Empty;
      AddServer((Server)server);
    }
    /// <summary>
    /// Called to connect to a target.
    /// </summary>
    public void OnConnectTarget(Opc.Server server)
    {
      if (m_target != null)
      {
        m_target.Disconnect();
        m_target.Dispose();
        m_target = null;
      }
      // use the specified server object directly.
      m_target = (Server)server;
      Cursor = Cursors.WaitCursor;
      try
      {
        NetworkCredential credentials = null;
        do
        {
          try
          {
            m_target.Connect(new Opc.ConnectData(credentials, m_proxy));
            break;
          }
          catch (Exception e)
          {
            MessageBox.Show(e.Message);
          }
          credentials = new NetworkCredentialsDlg().ShowDialog(credentials);
        }
        while (credentials != null);
        // select all filters by default.
        m_target.SetResultFilters((int)OpcDa::ResultFilter.All);
        // initialize controls.
        //SelectTargetCTRL.AddServerURL( m_target.Url );
      }
      catch (Exception e)
      {
        MessageBox.Show(e.Message);
        m_target = null;
      }
      Cursor = Cursors.Default;
    }
    #endregion

    #region private methodods

    private bool GetSaveFileName(bool prompt, string defaultName, string extension, string title, ref string name)
    {
      if (string.IsNullOrEmpty(name))
      {
        prompt = true;
        SetSaveDialog(extension, defaultName, title);
      }
      else
        SetSaveDialog(extension, name, title);
      if (prompt)
      {
        if (m_SaveFileDialog.ShowDialog() != DialogResult.OK)
          return false;
        // save the new config file name.
        name = m_SaveFileDialog.FileName;
      }
      return true;
    }
    private bool GetOpenFileName(string defaultName, string extension, string title, ref string name)
    {
      if (string.IsNullOrEmpty(name))
        SetOpenDialog(extension, defaultName, title);
      else
        SetOpenDialog(extension, name, title);
      if (m_OpenFileDialog.ShowDialog() != DialogResult.OK)
        return false;
      // save the new config file name.
      name = m_OpenFileDialog.FileName;
      return true;
    }
    /// <summary>
    /// Called to connect to a server.
    /// </summary>
    /// <param name="server">The server <see cref="Opc.Server"/>.</param>
    private void AddServer(Server server)
    {
      System.Diagnostics.Debug.Assert(!server.IsConnected);
      m_SubscriptionCTRL.AddServer(server, m_filters);
      SaveSettings();
      //ComplexTypeCache.Server = m_server = server;
    }
    /// <summary>
    /// Loads the configuration for the current server.
    /// </summary>
    private void LoadServer()
    {
      Stream stream = null;
      if (GetOpenFileName("", c_ServerConfigExtension, Properties.Resources.OpenDialogServeTitle, ref m_configFile))
        try
        {
          Cursor = Cursors.WaitCursor;
          // open configuration file.
          stream = new FileStream(m_configFile, FileMode.Open, FileAccess.Read, FileShare.Read);
          // deserialize the server object.
          Server server = (Server)new BinaryFormatter().Deserialize(stream);
          AddServer(server);
          // load DX configuration.
          //LoadDXConfiguration();
          // load succeeded.
        }
        catch (Exception e)
        {
          MessageBox.Show(e.Message);
        }
        finally
        {
          // close the stream.
          if (stream != null)
            stream.Close();
          Cursor = Cursors.Default;
        }
    }
    //private void NewSession()
    //{

    //  if ( GetSaveFileName( true, c_SessionDefaultFileName, c_SessionConfigExtension, Properties.Resources.SaveDialogSessionTitle, ref m_SessionFileName ) )
    //  {
    //    try
    //    {
    //      Cursor = Cursors.WaitCursor;

    //      m_SubscriptionCTRL.Sesion = null;
    //      FileInfo fi = new FileInfo( m_SessionFileName );
    //      if ( fi.Exists )
    //        fi.Delete();
    //    }
    //    catch ( Exception e )
    //    {
    //      MessageBox.Show( e.Message );
    //    }
    //    finally
    //    {
    //      Cursor = Cursors.Default;
    //    }
    //  }
    //}
    //private void LoadSession()
    //{
    //  if ( GetOpenFileName( c_SessionDefaultFileName, c_SessionConfigExtension, Properties.Resources.OpenDialogSessionTitle, ref m_SessionFileName ) )
    //    try
    //    {
    //      m_ConfigurationManagement.OnOpen_Click;
    //      m_SubscriptionCTRL.Sesion = m_ConfigurationManagement.Configuration;
    //    }
    //    catch ( Exception e )
    //    {
    //      MessageBox.Show( e.Message );
    //    }
    //    finally
    //    {
    //      Cursor = Cursors.Default;
    //    }
    //}
    /// <summary>
    /// Saves the configuration for the current server.
    /// </summary>
    private void SaveServer(bool prompt)
    {
      if (m_server == null)
        return;
      Stream stream = null;
      if (GetSaveFileName(prompt, m_server.Name, c_ServerConfigExtension, Properties.Resources.SaveDialogServerTitle, ref m_configFile))
        try
        {
          Cursor = Cursors.WaitCursor;
          // create the configuration file.
          stream = new FileStream(m_configFile, FileMode.Create, FileAccess.Write, FileShare.None);
          // serialize the server object.
          new BinaryFormatter().Serialize(stream, m_server);
        }
        catch (Exception e) { MessageBox.Show(e.Message); }
        finally
        {
          // close the stream.
          if (stream != null)
            stream.Close();
          Cursor = Cursors.Default;
        }
    }
    ///// <summary>
    ///// Saves the session.
    ///// </summary>
    ///// <param name="prompt">if set to <c>true</c> show <see cref="SaveFileDialog"/>.</param>
    //private void SaveSession( bool prompt )
    //{
    //  if ( GetSaveFileName( prompt, c_SessionDefaultFileName, c_SessionConfigExtension, Properties.Resources.SaveDialogSessionTitle, ref m_SessionFileName ) )
    //    try
    //    {
    //      Cursor = Cursors.WaitCursor;
    //      OPCCliConfiguration config = m_SubscriptionCTRL.Sesion;
    //      // create the configuartion file.
    //      config.WriteXml( m_SessionFileName, System.Data.XmlWriteMode.IgnoreSchema );
    //    }
    //    catch ( Exception e ) { MessageBox.Show( e.Message ); }
    //    finally { Cursor = Cursors.Default; }
    //}
    //TODO uncomment and make usefull
    ///// <summary>
    ///// Saves the current DXConfiguration
    ///// </summary>
    //private void SaveDXConfiguration()
    //{
    //  if ( m_server == null )
    //    return;
    //  Stream stream = null;
    //  try
    //  {
    //    Cursor = Cursors.WaitCursor;
    //    string configFile = m_server.Name + ".dxconfig";
    //    // create the configuartion file.
    //    stream = new FileStream( configFile, FileMode.Create, FileAccess.Write, FileShare.None );
    //    // populate the user settings object.
    //    DXConfiguration configuration = new DXConfiguration();
    //    configuration.Target = m_target;
    //    configuration.DXConnections = m_connections;
    //    // serialize the user settings object.
    //    new BinaryFormatter().Serialize( stream, configuration );
    //  }
    //  catch
    //  {
    //    // ignore errors.
    //  }
    //  finally
    //  {
    //    // close the stream.
    //    if ( stream != null )
    //      stream.Close();
    //    Cursor = Cursors.Default;
    //  }
    //}
    ///// <summary>
    ///// Loads the configuration for the current server.
    ///// </summary>
    //private bool LoadDXConfiguration()
    //{
    //  Stream stream = null;
    //  try
    //  {
    //    Cursor = Cursors.WaitCursor;
    //    string configFile = m_server.Name + ".dxconfig";
    //    // open configuration file.
    //    stream = new FileStream( configFile, FileMode.Open, FileAccess.Read, FileShare.Read );
    //    // deserialize the server object.
    //    DXConfiguration configuration = (DXConfiguration)new BinaryFormatter().Deserialize( stream );
    //    // overrided the current settings.
    //    if ( configuration != null )
    //    {
    //      configuration.Target.Connect();
    //      m_target = configuration.Target;
    //      m_connections = configuration.DXConnections;
    //      SelectTargetCTRL.Initialize( new Opc.URL[] { m_target.Url }, 0, Opc.Specification.COM_DA_30 );
    //    }
    //    // load succeeded.
    //    return true;
    //  }
    //  catch ( Exception )
    //  {
    //    // ignore errors.
    //    return false;
    //  }
    //  finally
    //  {
    //    // close the stream.
    //    if ( stream != null )
    //      stream.Close();
    //    Cursor = Cursors.Default;
    //  }
    //}
    /// <summary>
    /// Saves the user's application settings.
    /// </summary>
    private void SaveSettings()
    {
      Stream stream = null;
      try
      {
        Settings.Default.Save();
        Cursor = Cursors.WaitCursor;
        // create the configuration file.
        stream = new FileStream(ConfigFilePath, FileMode.Create, FileAccess.Write, FileShare.None);
        // populate the user settings object.
        UserAppData settings = new UserAppData();
        settings.KnownUrls = m_SelectServerStrip.GetKnownURLs(out settings.SelectedURL);
        if (m_proxy != null)
          settings.ProxyServer = m_proxy.Address.ToString();
        // serialize the user settings object.
        new BinaryFormatter().Serialize(stream, settings);
      }
      catch
      {
        // ignore errors.
      }
      finally
      {
        // close the stream.
        if (stream != null)
          stream.Close();
        Cursor = Cursors.Default;
      }
    }
    /// <summary>
    /// Loads the user's application settings.
    /// </summary>
    private void LoadSettings()
    {
      Stream stream = null;

      try
      {
        Cursor = Cursors.WaitCursor;

        // open configuration file.
        stream = new FileStream(ConfigFilePath, FileMode.Open, FileAccess.Read, FileShare.Read);

        // deserialize the server object.
        UserAppData settings = (UserAppData)new BinaryFormatter().Deserialize(stream);

        // overrided the current settings.
        if (settings != null)
        {
          // known urls.
          m_SelectServerStrip.Initialize(settings.KnownUrls, settings.SelectedURL, Opc.Specification.COM_DA_30);

          // proxy server.
          if (settings.ProxyServer != null)
          {
            m_proxy = new WebProxy(settings.ProxyServer);
          }
        }
      }
      catch
      {
        // ignore errors.
      }
      finally
      {
        // close the stream.
        if (stream != null)
          stream.Close();
        Cursor = Cursors.Default;
      }
    }
    #endregion

    #region Form events handlers
    private void MainFormV2008_FormClosing(object sender, FormClosingEventArgs e)
    {
      SaveSettings();
      m_SubscriptionCTRL.Clear();
    }
    #endregion

    #region Menu Handlers
    #region menu session
    private void TSMI_Session_Save_Click(object sender, EventArgs e)
    {
      m_SubscriptionCTRL.SaveSession();
    }
    private void TSMI_Session_Open_Click(object sender, EventArgs e)
    {
      m_SubscriptionCTRL.OpenSession();
    }
    /// <summary>
    /// Called when the File | Exit menu item is clicked.
    /// </summary>
    private void TSMI_File_Exit_Click(object sender, System.EventArgs e)
    {
      Close();
    }
    #endregion
    #region menu server
    private void TSMI_Server_BrowseNetwork_Click(object sender, EventArgs e)
    {
      Server svr = m_SelectServerStrip.SearchNetwork() as Server;
      if (svr == null)
        return;
      m_SubscriptionCTRL.AddServer(svr, m_filters);
    }
    /// <summary>
    /// Called when the Server | Connect menu item is clicked.
    /// </summary>
    private void TSMI_Server_Connect_Click(object sender, System.EventArgs e)
    {
      m_SubscriptionCTRL.Connect();
    }
    /// <summary>
    /// Called when the Server | Disconnect menu item is clicked.
    /// </summary>
    private void TSMI_Server_Disconnect_Click(object sender, System.EventArgs e)
    {
      m_SubscriptionCTRL.Disconnect();
      //ComplexTypeCache.Server = m_server = null;
      //SetServerStateItems = false;
    }
    private void TSMI_Server_DisconnectAll_Click(object sender, EventArgs e)
    {
      m_SubscriptionCTRL.DisconnectAll();
    }
    /// <summary>
    /// Called when the Server | Browse menu item is clicked.
    /// </summary>
    private void TSMI_Server_ViewStatus_Click(object sender, System.EventArgs e)
    {
      if ((m_server != null) && m_server.IsConnected)
        using (ServerStatusDlg dial = new ServerStatusDlg()) { dial.ShowDialog(m_server); }
    }
    /// <summary>
    /// Called when the Server | Read menu item is clicked.
    /// </summary>
    private void TSMI_Server_Read_Click(object sender, System.EventArgs e)
    {
      Server server = GetServer;
      if (server == null)
        return;
      using (ReadItemsDlg dial = new ReadItemsDlg()) { dial.ShowDialog(server); }
    }
    /// <summary>
    /// Called when the Server | Write menu item is clicked.
    /// </summary>
    private void TSMI_Server_Write_Click(object sender, System.EventArgs e)
    {
      Server server = GetServer;
      if (server == null)
        return;
      using (WriteItemsDlg dial = new WriteItemsDlg()) { dial.ShowDialog(server); }
    }
    private void TSMI_Server_ExportDictionary_Click(object sender, EventArgs e)
    {
      DictionaryDialog.OpenDioctionaryDialog(GetServer, m_filters);
    }
    private void TSMI_Server_OpenDictionary_Click(object sender, EventArgs e)
    {
      DictionaryDialog.OpenDioctionaryDialog();
    }
    /// <summary>
    /// Called when the File | Load menu item is clicked.
    /// </summary>
    private void TSMI_Server_Load_Click(object sender, System.EventArgs e) { LoadServer(); }
    /// <summary>
    /// Called when the File | Save menu item is clicked.
    /// </summary>
    private void TSMI_Server_Save_Click(object sender, System.EventArgs e) { SaveServer(false); }
    /// <summary>
    /// Handles the Click event of the m_TSM_SaveAs control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    private void TSMI_Server_SaveAs_Click(object sender, EventArgs e) { SaveServer(true); }
    /// <summary>
    /// Handles the Click event of the TestMI control.
    /// Currently the button is disable - remove it?
    /// Seems like stress test for a server.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    private void TSMI_Server_Test_Click(object sender, System.EventArgs e)
    {
      if (m_server == null)
        return;
      try
      {
        Server server = m_server;
        OpcDa::Item[] items = new OpcDa::Item[100];
        for (int ii = 0; ii < items.Length; ii++)
        {
          items[ii] = new OpcDa::Item();
          items[ii].ItemName = "Static/ArrayTypes/Object[]";
          items[ii].ItemPath = "DA30";
          items[ii].ClientHandle = ii;
        }
        OpcDa::SubscriptionState state = new Opc.Da.SubscriptionState();
        state.Active = true;
        state.UpdateRate = 1000;
        OpcDa::ISubscription subscription = server.CreateSubscription(state);
        Thread.Sleep(100);
        OpcDa::ItemResult[] results = subscription.AddItems(items);
        Thread.Sleep(100);
        for (int ii = 0; ii < 100000; ii++)
        {
          server.GetStatus();
          //ItemValueResult[] values = server.Read(items);
          //ItemPropertyCollection[] properties = server.GetProperties(items, null, true);
          //if (properties != null) {}
        }
        subscription.RemoveItems(results);
        Thread.Sleep(100);
        server.CancelSubscription(subscription);
        Thread.Sleep(100);
      }
      catch (Exception exception)
      {
        MessageBox.Show(exception.Message);
      }
    }
    #endregion
    #region menu debug
    /// <summary>
    /// Handles the Click event of the TSMI_DebugOn control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    private void TSMI_DebugOn_Click(object sender, EventArgs e)
    {
      if (m_TSMI_DebugOn.Checked)
      {
        m_MainTabControl.Controls.Add(m_DebugTabPage);
        m_DebugTabPage.Select();
      }
      else
        m_MainTabControl.Controls.Remove(m_DebugTabPage);
    }
    /// <summary>
    /// Called when the Output | Clear menu item is clicked.
    /// </summary>
    private void OutputClearMI_Click(object sender, System.EventArgs e)
    {
      m_OutputCTRL.Text = "";
    }
    #endregion
    #region options
    /// <summary>
    /// Handles changes to the proxy server settings.
    /// </summary>
    /// <summary>
    /// Clears the URL history in the drop down menu.
    /// </summary>
    private void ClearHistoryMI_Click(object sender, System.EventArgs e)
    {
      m_SelectServerStrip.Initialize(null, 0, Opc.Specification.COM_DA_30);
      SaveSettings();
    }
    private void ProxyServerMI_Click(object sender, System.EventArgs e)
    {
      WebProxy proxy = new ProxyServerDlg().ShowDialog(m_proxy);
      if (proxy != m_proxy)
      {
        m_proxy = proxy;
        SaveSettings();
      }
    }
    #endregion
    #region help
    /// <summary>
    /// Called when the Help | About menu item is clicked.
    /// </summary>
    private void AboutMI_Click(object sender, System.EventArgs e)
    {
      using (AboutForm dial = new AboutForm
        (Properties.Resources.Przegl_48, "Freeware", Assembly.GetEntryAssembly()))
      {
        dial.ShowDialog();
      }
    }
    /// <summary>
    /// Handles the Click event of the TSMI_OpenWebPage control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    private void TSMI_OpenWebPage_Click(object sender, EventArgs e)
    {
      try
      {
        Process.Start(Resources.Home);
      }
      catch (Win32Exception ex)
      {
        MessageBox.Show(String.Format(Resources.MainForm_DefaultAppMissing, Resources.Home, ex.Message));
      }
    }
    /// <summary>
    /// Handles the Click event of the TSMI_OpenRSS control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    private void TSMI_OpenRSS_Click(object sender, EventArgs e)
    {
      try
      {
        Process.Start(Resources.RSS);
      }
      catch (Win32Exception ex)
      {
        MessageBox.Show(String.Format(Resources.MainForm_DefaultAppMissing, Resources.RSS, ex.Message));
      }
    }

    /// <summary>
    /// Handles the Click event of the TSMI_ShowOnlineHelp control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    private void TSMI_ShowOnlineHelp_Click(object sender, EventArgs e)
    {
      try
      {
        Process.Start(Resources.Help_Main);
      }
      catch (Win32Exception ex)
      {
        MessageBox.Show(String.Format(Resources.MainForm_DefaultAppMissing, Resources.Help_Main, ex.Message));
      }

    }
    #endregion

    /// <summary>
    /// Handles the Click event of the TSMI_Support control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    private void TSMI_Support_Click(object sender, EventArgs e)
    {
      string MessageToBeShown = Resources.Support_MessageToBeShown;
      string MessageCaption = Resources.Support_MessageCaption;
      string emailAddress = Resources.Support_emailAddress;
      string messageSubject = Resources.Support_messageSubject;
      string MessageBody = Resources.Support_MessageBody;

      MessageBoxSentEmail.ShowMessageAndOpenEmailClient(MessageToBeShown, MessageCaption, DialogResult.OK, MessageBoxButtons.OKCancel, emailAddress, messageSubject, MessageBody);
    }
    private void dCOMConfigurationToolStripMenuItem_Click(object sender, EventArgs e)
    {
      //dcomcnfg
      CAS.Lib.RTLib.Processes.RunMethodAsynchronously runasync = new CAS.Lib.RTLib.Processes.RunMethodAsynchronously(delegate (object[] o)
     {
       try
       {
         Process.Start("dcomcnfg");
       }
       catch (Exception ex)
       {
         MessageBox.Show("dcomcnfg", "Cannot start the DCOM configuration console:" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Warning);
       };
     }
      );
      runasync.RunAsync();
    }
    private void licenseInformationToolStripMenuItem_Click(object sender, EventArgs e)
    {
      using (LicenseForm dial = new LicenseForm
             (null, null, Assembly.GetEntryAssembly()))
      {
        Licences cLicDial = new Licences();
        dial.SetAdditionalControl = cLicDial;
        dial.LicenceRequestMessageProvider
          = new LicenseForm.LicenceRequestMessageProviderDelegate(
            delegate () { return cLicDial.GetLicenseMessageRequest(); });
        dial.ShowDialog(this);
      }

    }
    private void openLogsContainingFolderToolStripMenuItem_Click(object sender, EventArgs e)
    {
      string path = CAS.Lib.CodeProtect.InstallContextNames.ApplicationDataPath + "\\log";
      try
      {
        using (Process process = Process.Start(@path)) { }
      }
      catch (Win32Exception)
      {
        MessageBox.Show("No Log folder exists under this link: " + path + " You can create this folder yourself.", "No Log folder !", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
      }
      catch (Exception)
      {
        MessageBox.Show("An error during opening a log folder occurs and the log folder cannot be open", "Problem with log folder !", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
      }
    }
    private void enterTheUnlockCodeToolStripMenuItem_Click(object sender, EventArgs e)
    {
      using (UlockKeyDialog dialog = new UlockKeyDialog())
      {
        dialog.ShowDialog();
      }
    }
    #endregion

    private ResourceManager Getter()
    {
      return Resources.ResourceManager;
    }
  }
}
