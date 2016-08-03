//<summary>
//  Title   : Dictionary Test Dialog
//  System  : Microsoft Visual C# .NET 2008
//  $LastChangedDate$
//  $Rev$
//  $LastChangedBy$
//  $URL$
//  $Id$
//
//  20080814: mzbrzezny: namespace cleanup
//
//  Copyright (C)2008, CAS LODZ POLAND.
//  TEL: +48 (42) 686 25 47
//  mailto://techsupp@cas.eu
//  http://www.cas.eu
//</summary>

using CAS.Lib.OPCClient.Da;
using CAS.Lib.OPCClientControlsLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpcDa = global::Opc.Da;

namespace CAS.Lib.UnitTests
{


  /// <summary>
  ///This is a test class for DictionaryDialogTest and is intended
  ///to contain all DictionaryDialogTest Unit Tests
  ///</summary>
  [TestClass()]
  public class DictionaryDialogTest
  {


    private TestContext testContextInstance;

    /// <summary>
    ///Gets or sets the test context which provides
    ///information about and functionality for the current test run.
    ///</summary>
    public TestContext TestContext
    {
      get
      {
        return testContextInstance;
      }
      set
      {
        testContextInstance = value;
      }
    }

    #region Additional test attributes
    // 
    //You can use the following additional attributes as you write your tests:
    //
    //Use ClassInitialize to run code before running the first test in the class
    //[ClassInitialize()]
    //public static void MyClassInitialize(TestContext testContext)
    //{
    //}
    //
    //Use ClassCleanup to run code after all tests in a class have run
    //[ClassCleanup()]
    //public static void MyClassCleanup()
    //{
    //}
    //
    //Use TestInitialize to run code before running each test
    //[TestInitialize()]
    //public void MyTestInitialize()
    //{
    //}
    //
    //Use TestCleanup to run code after each test has run
    //[TestCleanup()]
    //public void MyTestCleanup()
    //{
    //}
    //
    #endregion

    /// <summary>
    ///A test for ExportDictionary
    ///</summary>
    [TestMethod()]
    public void ExportDictionaryTest()
    {
      Server server = null; // TODO: Initialize to an appropriate value
      OpcDa::BrowseFilters filters = new OpcDa::BrowseFilters();
      DictionaryDialog.OpenDioctionaryDialog( server, filters );
      Assert.IsTrue( true );
    }
    /// <summary>
    ///A test for OpenDioctionary
    ///</summary>
    [TestMethod()]
    public void OpenDioctionaryTest()
    {
      DictionaryDialog.OpenDioctionaryDialog();
      Assert.IsTrue( true );
    }
  }
}
