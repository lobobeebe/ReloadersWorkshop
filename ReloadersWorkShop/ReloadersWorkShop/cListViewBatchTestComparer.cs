//============================================================================*
// cListViewBatchTestComparer.cs
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
	// cListViewBatchTestComparer Class
	//============================================================================*

	class cListViewBatchTestComparer : cListViewComparer
		{
		//============================================================================*
		// cListViewBatchComparer() - Constructor
		//============================================================================*

		public cListViewBatchTestComparer(int nSortColumn, SortOrder SortOrder)
			: base(nSortColumn, SortOrder)
			{
			}
		}
	}
