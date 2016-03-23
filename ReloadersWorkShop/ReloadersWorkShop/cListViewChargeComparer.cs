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
			// Get the ChargeTest Data
			//----------------------------------------------------------------------------*

			cChargeTest ChargeTest1 = null;
			cChargeTest ChargeTest2 = null;

			if (SortColumn != 1)
				{
				foreach(cChargeTest CheckTest in Charge1.TestList)
					{
					if (CheckTest.Source == (Object1 as ListViewItem).SubItems[0].Text)
						{
						ChargeTest1 = CheckTest;

						break;
						}
					}

				foreach (cChargeTest CheckTest in Charge2.TestList)
					{
					if (CheckTest.Source == (Object2 as ListViewItem).SubItems[0].Text)
						{
						ChargeTest2 = CheckTest;

						break;
						}
					}

				if (ChargeTest1 == null)
					{
					if (ChargeTest2 == null)
						return (0);
					else
						return (-1);
					}
				else
					{
					if (ChargeTest2 == null)
						return (1);
					}
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

				case 1:
					rc = Charge1.PowderWeight.CompareTo(Charge2.PowderWeight);

					fSpecial = true;

					break;

				//----------------------------------------------------------------------------*
				// Barrel Length
				//----------------------------------------------------------------------------*

				case 3:
					rc = ChargeTest1.BarrelLength.CompareTo(ChargeTest2.BarrelLength);

					fSpecial = true;

					break;

				//----------------------------------------------------------------------------*
				// Twist
				//----------------------------------------------------------------------------*

				case 4:
					rc = ChargeTest1.Twist.CompareTo(ChargeTest2.Twist);

					fSpecial = true;

					break;

				//----------------------------------------------------------------------------*
				// Velocity
				//----------------------------------------------------------------------------*

				case 5:
					rc = ChargeTest1.MuzzleVelocity.CompareTo(ChargeTest2.MuzzleVelocity);

					fSpecial = true;

					break;

				//----------------------------------------------------------------------------*
				// Pressure
				//----------------------------------------------------------------------------*

				case 6:
					rc = ChargeTest1.Pressure.CompareTo(ChargeTest2.Pressure);

					fSpecial = true;

					break;

				//----------------------------------------------------------------------------*
				// Best Group
				//----------------------------------------------------------------------------*

				case 7:
					rc = ChargeTest1.BestGroup.CompareTo(ChargeTest2.BestGroup);

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
