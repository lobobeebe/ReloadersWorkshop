//============================================================================*
// cListViewFactoryAmmoTestComparer.cs
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
	// cListViewFactoryAmmoTestComparer Class
	//============================================================================*

	class cListViewAmmoTestComparer : cListViewComparer
		{
		//============================================================================*
		// cListViewBatchComparer() - Constructor
		//============================================================================*

		public cListViewAmmoTestComparer(int nSortColumn, SortOrder SortOrder)
			: base(nSortColumn, SortOrder)
			{
			}
		}
	}
