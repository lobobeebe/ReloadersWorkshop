//============================================================================*
// cListViewManufacturerComparer.cs
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
	// cListViewManufacturerComparer Class
	//============================================================================*

	class cListViewManufacturerComparer : cListViewComparer
		{
		//============================================================================*
		// cListViewManufacturerComparer() - Constructor
		//============================================================================*

		public cListViewManufacturerComparer(int nSortColumn, SortOrder SortOrder)
			: base(nSortColumn, SortOrder)
			{
			}
		}
	}
