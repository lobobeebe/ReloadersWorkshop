//============================================================================*
// cListViewBulletCaliberComparer.cs
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
	// cListViewBulletCaliberComparer Class
	//============================================================================*

	class cListViewBulletCaliberComparer : cListViewComparer
		{
		//============================================================================*
		// cListViewBulletCaliberComparer() - Constructor
		//============================================================================*

		public cListViewBulletCaliberComparer(int nSortColumn, SortOrder SortOrder)
			: base(nSortColumn, SortOrder)
			{
			}

		//============================================================================*
		// Compare()
		//============================================================================*

		public override int Compare(Object Object1, Object Object2)
			{
			if (Object1 == null)
				{
				if (Object2 == null)
					return (0);
				else
					return (-1);
				}
			else
				{
				if (Object2 == null)
					return (1);
				}

			cBulletCaliber BulletCaliber1 = (cBulletCaliber)(Object1 as ListViewItem).Tag;
			cBulletCaliber BulletCaliber2 = (cBulletCaliber)(Object2 as ListViewItem).Tag;

			if (BulletCaliber1 == null)
				{
				if (BulletCaliber2 == null)
					return (0);
				else
					return (-1);
				}
			else
				{
				if (BulletCaliber2 == null)
					return (1);
				}

			bool fSpecial = false;
			int rc = 0;

			switch (SortColumn)
				{
				//----------------------------------------------------------------------------*
				// COL
				//----------------------------------------------------------------------------*

				case 1:
					rc = BulletCaliber1.COL.CompareTo(BulletCaliber2.COL);

					fSpecial = true;

					break;
				}

			if (fSpecial)
				{
				if (SortingOrder == SortOrder.Descending)
					return (0 - rc);

				return (rc);
				}

			return (base.Compare(Object1, Object2));
			}
		}
	}
