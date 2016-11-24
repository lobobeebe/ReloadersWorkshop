//============================================================================*
// cListViewFirearmAccessoryComparer.cs
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
	// cListViewFirearmAccessoryComparer Class
	//============================================================================*

	class cListViewFirearmAccessoryComparer : cListViewComparer
		{
		//============================================================================*
		// cListViewFirearmAccessoryComparer() - Constructor
		//============================================================================*

		public cListViewFirearmAccessoryComparer(int nSortColumn, SortOrder SortOrder)
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

			cGear Gear1 = (cGear) (Object1 as ListViewItem).Tag;
			cGear Gear2 = (cGear) (Object2 as ListViewItem).Tag;

			if (Gear1 == null)
				{
				if (Gear2 == null)
					return (0);
				else
					return (0);
				}
			else
				{
				if (Gear2 == null)
					return (1);
				}

			//----------------------------------------------------------------------------*
			// Do Special Compares
			//----------------------------------------------------------------------------*

			bool fSpecial = false;
			int rc = 0;

			switch (SortColumn)
				{
				//----------------------------------------------------------------------------*
				// Manufacturer
				//----------------------------------------------------------------------------*

				case 0:
					rc = Gear1.Manufacturer.CompareTo(Gear2.Manufacturer);

					if (rc == 0)
						rc = Gear1.PartNumber.CompareTo(Gear2.PartNumber);

					fSpecial = true;

					break;

				//----------------------------------------------------------------------------*
				// Part Number
				//----------------------------------------------------------------------------*

				case 1:
					rc = cDataFiles.ComparePartNumbers(Gear1.PartNumber, Gear2.PartNumber);

					fSpecial = true;

					break;

				//----------------------------------------------------------------------------*
				// Serial  Number
				//----------------------------------------------------------------------------*

				case 2:
					rc = cDataFiles.ComparePartNumbers(Gear1.SerialNumber, Gear2.SerialNumber);

					fSpecial = true;

					break;

				//----------------------------------------------------------------------------*
				// Description
				//----------------------------------------------------------------------------*

				case 3:
					rc = Gear1.Description.CompareTo(Gear2.Description);
					;

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
