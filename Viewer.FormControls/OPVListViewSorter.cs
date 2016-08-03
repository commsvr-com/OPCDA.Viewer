using System;
using System.Windows.Forms;
using System.Collections;
//<summary>
//  Title   : OPVListViewSorter
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
  /// The comparer for the columns in the ListView
  /// </summary>
  public class OPVListViewSorter: IComparer
  {
    // Initialize the variables to default
    public int column = 0;
    public bool bAscending = true;

    // Using the Compare function of IComparer
    public int Compare( object x, object y )
    {
      // Cast the objects to ListViewItems
      ListViewItem lvi1 = (ListViewItem)x;
      ListViewItem lvi2 = (ListViewItem)y;
      // If the column is the string columns
      if ( column != 2 )
      {
        string lvi1String = lvi1.SubItems[ column ].ToString();
        string lvi2String = lvi2.SubItems[ column ].ToString();
        // Return the normal or negated Compare
        if ( bAscending )
          return String.Compare( lvi1String, lvi2String );
        else
          return -String.Compare( lvi1String, lvi2String );
      }
      // The column is the Age column
      bool lvi1Int_result, lvi2Int_result;
      double lvi1Int = ParseListItemString( lvi1.SubItems[ column ].ToString(), out lvi1Int_result );
      double lvi2Int = ParseListItemString( lvi2.SubItems[ column ].ToString(), out lvi2Int_result );
      // Return the normal compare.. if x < y then return -1
      if ( bAscending )
      {
        if ( lvi1Int < lvi2Int )
          return -1;
        else if ( lvi1Int == lvi2Int )
          return 0;
        else
          return 1;
      }
      // Return the opposites for descending
      if ( lvi1Int > lvi2Int )
        return -1;
      else if ( lvi1Int == lvi2Int )
        return 0;
      else
        return 1;
    }

    private double ParseListItemString( string x, out bool result )
    {
      //ListViewItems are returned like this: "ListViewSubItem: {19}"
      int counter = 0;
      for ( int i = x.Length - 1; i >= 0; i--, counter++ )
      {
        if ( x[ i ] == '{' )
          break;
      }
      double parseresult;
      result = double.TryParse( x.Substring( x.Length - counter, counter - 1 ), out parseresult );
      return parseresult;
    }

  }
}
