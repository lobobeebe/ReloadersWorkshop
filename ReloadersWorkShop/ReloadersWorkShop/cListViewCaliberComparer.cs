//============================================================================*
// cListViewCaliberComparer.cs
//
// Copyright © 2013-2017, Kevin S. Beebe
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
	// cListViewCaliberComparer Class
	//============================================================================*

	class cListViewCaliberComparer : cListViewComparer
		{
		//============================================================================*
		// Private Data Members
		//============================================================================*

		//============================================================================*
		// cListViewCaliberComparer() - Constructor
		//============================================================================*

		public cListViewCaliberComparer(int nSortColumn, SortOrder SortOrder)
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

			cCaliber Caliber1 = (cCaliber)(Object1 as ListViewItem).Tag;
			cCaliber Caliber2 = (cCaliber)(Object2 as ListViewItem).Tag;

			if (Caliber1 == null)
				{
				if (Caliber2 == null)
					return (0);
				else
					return (-1);
				}
			else
				{
				if (Caliber2 == null)
					return (1);
				}

			bool fSpecial = false;
			int rc = 0;

			switch(SortColumn)
				{
				//----------------------------------------------------------------------------*
				// Min Diameter
				//----------------------------------------------------------------------------*

				case 5:
					rc = Caliber1.MinBulletDiameter.CompareTo(Caliber2.MinBulletDiameter);

					fSpecial = true;

					break;

				//----------------------------------------------------------------------------*
				// Max Weight
				//----------------------------------------------------------------------------*

				case 6:
					rc = Caliber1.MaxBulletDiameter.CompareTo(Caliber2.MaxBulletDiameter);

					fSpecial = true;

					break;

				//----------------------------------------------------------------------------*
				// Min Weight
				//----------------------------------------------------------------------------*

				case 7:
					rc = Caliber1.MinBulletWeight.CompareTo(Caliber2.MinBulletWeight);

					fSpecial = true;

					break;

				//----------------------------------------------------------------------------*
				// Max Weight
				//----------------------------------------------------------------------------*

				case 8:
					rc = Caliber1.MaxBulletWeight.CompareTo(Caliber2.MaxBulletWeight);

					fSpecial = true;

					break;

				//----------------------------------------------------------------------------*
				// Case Trim Length
				//----------------------------------------------------------------------------*

				case 9:
					rc = Caliber1.CaseTrimLength.CompareTo(Caliber2.CaseTrimLength);

					fSpecial = true;

					break;

				//----------------------------------------------------------------------------*
				// Max Case Length
				//----------------------------------------------------------------------------*

				case 10:
					rc = Caliber1.MaxCaseLength.CompareTo(Caliber2.MaxCaseLength);

					fSpecial = true;

					break;

				//----------------------------------------------------------------------------*
				// Max COL
				//----------------------------------------------------------------------------*

				case 11:
					rc = Caliber1.MaxCOL.CompareTo(Caliber2.MaxCOL);

					fSpecial = true;

					break;

				//----------------------------------------------------------------------------*
				// Max Neick Diameter
				//----------------------------------------------------------------------------*

				case 12:
					rc = Caliber1.MaxNeckDiameter.CompareTo(Caliber2.MaxNeckDiameter);

					fSpecial = true;

					break;
				}

			if (fSpecial)
				{
				if (SortingOrder == SortOrder.Descending)
					return(0 - rc);

				return(rc);
				}

			return (base.Compare(Object1, Object2));
			}
		}
	}
