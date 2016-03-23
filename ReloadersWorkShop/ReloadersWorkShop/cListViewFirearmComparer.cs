//============================================================================*
// cListViewFirearmComparer.cs
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
	// cListViewFirearmComparer Class
	//============================================================================*

	class cListViewFirearmComparer : cListViewComparer
		{
		//============================================================================*
		// cListViewFirearmComparer() - Constructor
		//============================================================================*

		public cListViewFirearmComparer(int nSortColumn, SortOrder SortOrder)
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

			cFirearm Firearm1 = (cFirearm)(Object1 as ListViewItem).Tag;
			cFirearm Firearm2 = (cFirearm)(Object2 as ListViewItem).Tag;

			if (Firearm1 == null)
				{
				if (Firearm2 == null)
					return (0);
				else
					return (0);
				}
			else
				{
				if (Firearm2 == null)
					return(1);
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
					rc = Firearm1.Manufacturer.CompareTo(Firearm2.Manufacturer);

					if (rc == 0)
						{
						rc = Firearm1.Model.CompareTo(Firearm2.Model);

						if (rc == 0)
							rc = Firearm1.PrimaryCaliber.CompareTo(Firearm2.PrimaryCaliber);
						}

					fSpecial = true;

					break;

				//----------------------------------------------------------------------------*
				// Barrel Length
				//----------------------------------------------------------------------------*

				case 4:
					rc = Firearm1.BarrelLength.CompareTo(Firearm2.BarrelLength);

					fSpecial = true;

					break;

				//----------------------------------------------------------------------------*
				// Twist Rate
				//----------------------------------------------------------------------------*

				case 5:
					rc = Firearm1.Twist.CompareTo(Firearm2.Twist);

					fSpecial = true;

					break;

				//----------------------------------------------------------------------------*
				// Turret Click
				//----------------------------------------------------------------------------*

				case 7:
					rc = Firearm1.ScopeClick.CompareTo(Firearm2.ScopeClick);

					fSpecial = true;

					break;

				//----------------------------------------------------------------------------*
				// Zero Range
				//----------------------------------------------------------------------------*

				case 8:
					rc = Firearm1.ZeroRange.CompareTo(Firearm2.ZeroRange);

					fSpecial = true;

					break;

				//----------------------------------------------------------------------------*
				// Sight Height
				//----------------------------------------------------------------------------*

				case 9:
					rc = Firearm1.SightHeight.CompareTo(Firearm2.SightHeight);

					fSpecial = true;

					break;

				//----------------------------------------------------------------------------*
				// Head Space
				//----------------------------------------------------------------------------*

				case 10:
					rc = Firearm1.HeadSpace.CompareTo(Firearm2.HeadSpace);

					fSpecial = true;

					break;

				//----------------------------------------------------------------------------*
				// Neck Size
				//----------------------------------------------------------------------------*

				case 11:
					rc = Firearm1.Neck.CompareTo(Firearm2.Neck);

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
