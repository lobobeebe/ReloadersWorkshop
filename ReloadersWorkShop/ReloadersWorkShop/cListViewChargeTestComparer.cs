//============================================================================*
// cListViewChargeTestComparer.cs
//
// Copyright © 2013-2014, Kevin S. Beebe
// All Rights Reserved
//============================================================================*

//============================================================================*
// .Net Using Statements
//============================================================================*

using System;
using System.Collections;
using System.Windows.Forms;

//============================================================================*
// Namespace
//============================================================================*

namespace ReloadersWorkShop
	{
	//============================================================================*
	// cListViewChargeTestComparer Class
	//============================================================================*

	class cListViewChargeTestComparer : cListViewComparer
		{
		//============================================================================*
		// cListViewChargeTestComparer() - Constructor
		//============================================================================*

		public cListViewChargeTestComparer(int nSortColumn, SortOrder SortOrder)
			: base(nSortColumn, SortOrder)
			{
			}
		}
	}
