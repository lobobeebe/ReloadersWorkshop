//============================================================================*
// cListViewChargeComparer.cs
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
	// cListViewChargeComparer Class
	//============================================================================*

	class cListViewChargeComparer : cListViewComparer
		{
		//============================================================================*
		// cListViewChargeComparer() - Constructor
		//============================================================================*

		public cListViewChargeComparer(int nSortColumn, SortOrder SortOrder)
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

			cCharge Charge1 = (cCharge)(Object1 as ListViewItem).Tag;
			cCharge Charge2 = (cCharge)(Object2 as ListViewItem).Tag;

			if (Charge1 == null)
				{
				if (Charge2 == null)
					return (0);
				else
					return (-1);
				}
			else
				{
				if (Charge2 == null)
					return (1);
				}

			//----------------------------------------------------------------------------*
			// Compare the SortColumns
			//----------------------------------------------------------------------------*

			bool fSpecial = false;
			int rc = 0;

			switch (SortColumn)
				{
				//----------------------------------------------------------------------------*
				// Powder Weight
				//----------------------------------------------------------------------------*

				case 0:
					rc = Charge1.PowderWeight.CompareTo(Charge2.PowderWeight);

					fSpecial = true;

					break;

				//----------------------------------------------------------------------------*
				// # Tests
				//----------------------------------------------------------------------------*

				case 1:
					rc = Charge1.TestList.Count.CompareTo(Charge2.TestList.Count);

					fSpecial = true;

					break;

				//----------------------------------------------------------------------------*
				// Fill Ratio
				//----------------------------------------------------------------------------*

				case 2:
					rc = Charge1.FillRatio.CompareTo(Charge2.FillRatio);

					fSpecial = true;

					break;

				//----------------------------------------------------------------------------*
				// Favorite
				//----------------------------------------------------------------------------*

				case 3:
					rc = Charge1.Favorite.CompareTo(Charge2.Favorite);

					fSpecial = true;

					break;

				//----------------------------------------------------------------------------*
				// Reject
				//----------------------------------------------------------------------------*

				case 4:
					rc = Charge1.Reject.CompareTo(Charge2.Reject);

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
