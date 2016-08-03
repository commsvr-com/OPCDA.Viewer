using System.Windows.Forms;
//<summary>
//  Title   : SortHandler
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
      
namespace CAS.Lib.OPCClientControlsLib
{
  /// <summary>
  /// Handler for the ColumnClick on the ListView headers
  /// </summary>
  public class SortHandler
  {
    /// <summary>
    /// Handles the ColumnClick event of the listView control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.Windows.Forms.ColumnClickEventArgs"/> instance containing the event data.</param>
    public static void listView_ColumnClick( object sender, System.Windows.Forms.ColumnClickEventArgs e )
    {
      OPVListViewSorter columnSorter = new OPVListViewSorter();
      columnSorter.column = e.Column;
      ListView lv = (ListView)sender;
      if ( lv.Sorting == SortOrder.Ascending )
      {
        columnSorter.bAscending = true;
        lv.Sorting = SortOrder.Descending;
      }
      else
      {
        columnSorter.bAscending = false;
        lv.Sorting = SortOrder.Ascending;
      }
      lv.ListViewItemSorter = (System.Collections.IComparer)columnSorter;
    }
  }
}
