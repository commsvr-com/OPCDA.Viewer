//<summary>
//  Title   : OPC DA AddressSpaceDataBase DataSet
//  System  : Microsoft Visual C# .NET 2008
//  $LastChangedDate$
//  $Rev$
//  $LastChangedBy$
//  $URL$
//  $Id$
//
//  Copyright (C)2008, CAS LODZ POLAND.
//  TEL: +48 (42) 686 25 47
//  mailto//:techsupp@cas.eu
//  http://www.cas.eu
//</summary>

using Opc;
using Opc.Da;
using System;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Soap;
using System.Text;
using OpcDa = global::Opc.Da;

namespace CAS.Lib.OPC.AddressSpace
{
  /// <summary>
  /// Dictionary representing a server address space.
  /// </summary>
  public partial class AddressSpaceDataBase
  {
    partial class LocalesTableRow
    {
    }
    partial class LocalesTableDataTable
    {
      internal void AddRow(int serverID, string loc)
      {
        LocalesTableRow mRow = this.NewLocalesTableRow();
        mRow.Locale = loc;
        mRow.ServerID = serverID;
        this.AddLocalesTableRow(mRow);
      }
    }
    /// <summary>
    /// Table representing server
    /// </summary>
    partial class ServersTableDataTable
    {
      /// <summary>
      /// Adds the row.
      /// </summary>
      /// <param name="credential">The credential.</param>
      /// <param name="server">The server.</param>
      /// <returns>ServersTableRow.</returns>
      public ServersTableRow AddRow(ConnectData credential, Opc.Da.Server server)
      {
        ServersTableRow mRow = this.NewServersTableRow();
        mRow.LicenseKey = credential.LicenseKey;
        if (credential.Credentials != null)
        {
          mRow.Domain = credential.Credentials.Domain;
          mRow.Password = credential.Credentials.Password;
          mRow.UserName = credential.Credentials.UserName;
        }
        ServerStatus status = server.GetStatus();
        mRow.CurrentTime = status.CurrentTime;
        mRow.ProductVersion = status.ProductVersion;
        mRow.SpecificationDescription = server.PreferedSpecyfication.Description;
        mRow.SpecificationID = server.PreferedSpecyfication.ID;
        mRow.URLString = server.Url.ToString();
        mRow.VendorInfo = status.VendorInfo;
        this.AddServersTableRow(mRow);
        foreach (var loc in server.SupportedLocales)
          ((AddressSpaceDataBase)this.DataSet).LocalesTable.AddRow(mRow.ID, loc);
        return mRow;
      }
      /// <summary>
      /// Adds the row.
      /// </summary>
      /// <param name="credential">The credential.</param>
      /// <param name="status">The status.</param>
      /// <param name="preferedSpecyfication">The prefered specyfication.</param>
      /// <param name="url">The URL.</param>
      /// <param name="SupportedLocales">The supported locales.</param>
      /// <returns>ServersTableRow.</returns>
      public ServersTableRow AddRow
        (ConnectData credential, OpcDa.ServerStatus status, Specification preferedSpecyfication, URL url, string[] SupportedLocales)
      {
        ServersTableRow mRow = this.NewServersTableRow();
        mRow.LicenseKey = credential.LicenseKey;
        if (credential.Credentials != null)
        {
          mRow.Domain = credential.Credentials.Domain;
          mRow.Password = credential.Credentials.Password;
          mRow.UserName = credential.Credentials.UserName;
        }
        mRow.CurrentTime = status.CurrentTime;
        mRow.ProductVersion = status.ProductVersion;
        mRow.SpecificationDescription = preferedSpecyfication.Description;
        mRow.SpecificationID = preferedSpecyfication.ID;
        mRow.URLString = url.ToString();
        mRow.VendorInfo = status.VendorInfo;
        this.AddServersTableRow(mRow);
        foreach (var loc in SupportedLocales)
          ((AddressSpaceDataBase)this.DataSet).LocalesTable.AddRow(mRow.ID, loc);
        return mRow;
      }
    }
    partial class ServersTableRow
    {
      /// <summary>
      /// Gets the server status.
      /// </summary>
      /// <value>The status.</value>
      public ServerStatus Status
      {
        get
        {
          ServerStatus output =
            new ServerStatus() { CurrentTime = CurrentTime, LastUpdateTime = CurrentTime, StartTime = CurrentTime };
          output.ProductVersion = IsProductVersionNull() ? null : ProductVersion;
          output.ServerState = serverState.unknown;
          output.StatusInfo = "Not available";
          output.VendorInfo = IsVendorInfoNull() ? null : VendorInfo;
          return output;
        }
      }
      /// <summary>
      /// Gets the server URL.
      /// </summary>
      /// <value>The URL.</value>
      public URL URL { get { return new URL(URLString); } }
      /// <summary>
      /// Gets the default specification.
      /// </summary>
      /// <value>The specification.</value>
      public Specification Specification
      {
        get { return new Specification() { ID = SpecificationID, Description = SpecificationDescription }; }
      }
      /// <summary>
      /// Gets the locales.
      /// </summary>
      /// <value>The locales.</value>
      public string[] Locales
      {
        get
        {
          string[] ot = new string[this.GetLocalesTableRows().Length];
          for (int ix = 0; ix < ot.Length; ix++)
            ot[ix] = this.GetLocalesTableRows()[ix].Locale;
          return ot;
        }
      }
    }
    /// <summary>
    /// Table of item properties
    /// </summary>
    partial class ItemPropertiesTableDataTable
    {
      /// <summary>
      /// Adds the row.
      /// </summary>
      /// <param name="item">The item.</param>
      /// <param name="tagID">The tag identifier.</param>
      /// <returns>System.Int32.</returns>
      /// <exception cref="System.ArgumentException">Item result is not ok</exception>
      public int AddRow(ItemProperty item, int tagID)
      {
        if (item.ResultID != ResultID.S_OK)
          throw new ArgumentException("Item result is not ok");
        ItemPropertiesTableRow mRow = this.NewItemPropertiesTableRow();
        mRow.TagID = tagID;
        mRow.Description = item.Description;
        mRow.ItemName = item.ItemName;
        mRow.ItemPath = item.ItemPath;
        if (item.ID.Name != null && !item.ID.Name.IsEmpty)
        {
          mRow.ID_Name_Name = item.ID.Name.Name;
          mRow.ID_Name_Namespace = item.ID.Name.Namespace;
        }
        mRow.ID_Code = item.ID.Code;
        mRow.SOAPValue = item.Value;
        this.AddItemPropertiesTableRow(mRow);
        return mRow.ID;
      }
    }
    /// <summary>
    /// Row representing item property
    /// </summary>
    partial class ItemPropertiesTableRow
    {
      #region private
      private object GetValue()
      {
        if (IsValueNull())
          return null;
        SoapFormatter frmtr = new SoapFormatter();
        frmtr.FilterLevel = System.Runtime.Serialization.Formatters.TypeFilterLevel.Low;
        frmtr.TypeFormat = System.Runtime.Serialization.Formatters.FormatterTypeStyle.XsdString;
        object val = null;
        using (MemoryStream reader = new MemoryStream(new UTF8Encoding().GetBytes(Value)))
          val = frmtr.Deserialize(reader);
        return val;
      }
      #endregion
      #region internal
      internal ItemProperty GetItemPropery()
      {
        ItemProperty property =
          new ItemProperty();
        property.Description = IsDescriptionNull() ? null : Description;
        property.ItemName = IsItemNameNull() ? null : ItemName;
        property.ItemPath = IsItemPathNull() ? null : ItemPath;
        if (IsID_Name_NameNull())
          property.ID = new PropertyID(ID_Code);
        else
          property.ID = new PropertyID(ID_Name_Name, ID_Code, ID_Name_Namespace);
        try
        {
          property.Value = GetValue();
          property.DataType = property.Value == null ? null : property.Value.GetType();
          property.ResultID = ResultID.S_OK;
        }
        catch (Exception)
        {
          property.DataType = null;
          property.Value = null;
          property.ResultID = ResultID.E_FAIL;
        }
        return property;
      }
      internal object SOAPValue
      {
        set
        {
          try
          {
            if (value == null)
              return;
            using (MemoryStream str = new MemoryStream())
            {
              SoapFormatter frmtr = new SoapFormatter();
              frmtr.TypeFormat = System.Runtime.Serialization.Formatters.FormatterTypeStyle.XsdString;
              frmtr.Serialize(str, value);
              Encoding enc = new UTF8Encoding();
              Value = enc.GetString(str.GetBuffer(), 0, (int)str.Length - 1);
            }
          }
          catch (Exception)
          {
            //TODO Add trace 
          }
        }
      }
      #endregion
    }
    /// <summary>
    /// Table of tags
    /// </summary>
    partial class TagsTableDataTable
    {
      /// <summary>
      /// Adds the row.
      /// </summary>
      /// <param name="item">The item.</param>
      /// <param name="parentID">The parent identifier.</param>
      /// <param name="serverRelated">if set to <c>true</c> [server related].</param>
      /// <returns>TagsTableRow.</returns>
      public TagsTableRow AddRow(BrowseElement item, int parentID, bool serverRelated)
      {
        TagsTableRow mRow = this.NewTagsTableRow();
        mRow.HasChildren = item.HasChildren;
        mRow.IsItem = item.IsItem;
        mRow.ItemName = item.ItemName;
        mRow.ItemPath = item.ItemPath;
        mRow.Name = item.Name;
        if (serverRelated)
          mRow.ServerID = parentID;
        else
          mRow.TagID = parentID;
        this.AddTagsTableRow(mRow);
        return mRow;
      }
    }
    /// <summary>
    /// Row representing a tag.
    /// </summary>
    partial class TagsTableRow
    {
      /// <summary>
      /// Gets the browse element.
      /// </summary>
      /// <returns>BrowseElement.</returns>
      public BrowseElement GetBrowseElement()
      {
        BrowseElement el =
          new BrowseElement() { HasChildren = this.HasChildren, IsItem = IsItem, ItemName = ItemName, Name = Name };
        if (!IsItemPathNull())
          el.ItemPath = ItemPath;
        if (GetItemPropertiesTableRows().Length == 0)
          return el;
        ArrayList prprts = new ArrayList();
        prprts.AddRange(GetItemPropertiesTableRows());
        el.Properties = new ItemProperty[prprts.Count];
        for (int ix = 0; ix < el.Properties.Length; ix++)
          el.Properties[ix] = ((ItemPropertiesTableRow)prprts[ix]).GetItemPropery();
        return el;
      }
      internal BrowsePosition GetBrowsePosition()
      {
        return null;
      }
    }
    #region public methods
    /// <summary>
    /// Browses the address spase starting with selected <see cref="TagsTableRow"/>.
    /// </summary>
    /// <param name="itemID">The item to start with.</param>
    /// <param name="filters">The filters to applay while browsing.</param>
    /// <param name="position">The position to start next time.</param>
    /// <returns></returns>
    public TagsTableRow[] Browse(TagsTableRow itemID, BrowseFilters filters, out BrowsePosition position)
    {
      position = null;
      if (itemID == null)
        return ServersTable[0].GetTagsTableRows();
      else
        return itemID.GetTagsTableRows();
    }
    /// <summary>
    /// Incremental browsing.
    /// </summary>
    /// <remarks>Nnot implemented yet</remarks>
    /// <param name="position">The position.</param>
    /// <returns></returns>
    public TagsTableRow[] BrowseNext(ref BrowsePosition position)
    {
      throw new NotImplementedException();
    }
    /// <summary>
    /// Gets the default name of the file.
    /// </summary>
    /// <value>The default name of the file.</value>
    public string DefaultFileName
    {
      get
      {
        if (this.ServersTable.Count == 0)
          return "EmptyDictionary";
        return ServersTable[0].URL.Path;
      }
    }
    #endregion
  }
}
