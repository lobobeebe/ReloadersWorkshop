//============================================================================*
// cListViewBulletComparer.cs
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
	// cListViewBulletComparer Class
	//============================================================================*

	class cListViewBulletComparer : cListViewComparer
		{
		//============================================================================*
		// Private Data Members
		//============================================================================*

		cDataFiles m_DataFiles = null;

		//============================================================================*
		// cListViewBulletComparer() - Constructor
		//============================================================================*

		public cListViewBulletComparer(cDataFiles DataFiles, int nSortColumn, SortOrder SortOrder)
			: base(nSortColumn, SortOrder)
			{
			m_DataFiles = DataFiles;
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

			cBullet Bullet1 = (cBullet)(Object1 as ListViewItem).Tag;
			cBullet Bullet2 = (cBullet)(Object2 as ListViewItem).Tag;

			if (Bullet1 == null)
				{
				if (Bullet2 == null)
					return (0);
				else
					return (-1);
				}
			else
				{
				if (Bullet2 == null)
					return (1);
				}

			bool fSpecial = false;
			int rc = 0;

			string strPart1 = "";
			string strPart2 = "";

			switch (SortColumn)
				{
				//----------------------------------------------------------------------------*
				// Manufacturer
				//----------------------------------------------------------------------------*

				case 0:
					rc = Bullet1.Manufacturer.CompareTo(Bullet2.Manufacturer);

					if (rc == 0)
						{
						rc = cDataFiles.ComparePartNumbers(Bullet1.PartNumber, Bullet2.PartNumber);
						}

					fSpecial = true;

					break;

				//----------------------------------------------------------------------------*
				// Part Number
				//----------------------------------------------------------------------------*

				case 1:
					strPart1 = Bullet1.PartNumber;
					strPart2 = Bullet2.PartNumber;

					rc = cDataFiles.ComparePartNumbers(Bullet1.PartNumber, Bullet2.PartNumber);

					if (rc == 0)
						{
						rc = Bullet1.Manufacturer.CompareTo(Bullet2.Manufacturer);
						}

					fSpecial = true;

					break;

				//----------------------------------------------------------------------------*
				// Diameter
				//----------------------------------------------------------------------------*

				case 3:
					double dDiameter1 = Bullet1.Diameter;
					double dDiameter2 = Bullet2.Diameter;

					rc = dDiameter1.CompareTo(dDiameter2);

					if (rc == 0)
						{
						rc = Bullet1.Manufacturer.CompareTo(Bullet2.Manufacturer);

						if (rc == 0)
							{
							rc = cDataFiles.ComparePartNumbers(Bullet1.PartNumber, Bullet2.PartNumber);
							}
						}

					fSpecial = true;

					break;

				//----------------------------------------------------------------------------*
				// Weight
				//----------------------------------------------------------------------------*

				case 4:
					double nWeight1 = Bullet1.Weight;
					double nWeight2 = Bullet2.Weight;

					rc = nWeight1.CompareTo(nWeight2);

					if (rc == 0)
						{
						rc = Bullet1.Manufacturer.CompareTo(Bullet2.Manufacturer);

						if (rc == 0)
							{
							rc = cDataFiles.ComparePartNumbers(Bullet1.PartNumber, Bullet2.PartNumber);
							}
						}

					fSpecial = true;

					break;

				//----------------------------------------------------------------------------*
				// Top Punch
				//----------------------------------------------------------------------------*

				case 9:
					int nPunch1 = Bullet1.TopPunch;
					int nPunch2 = Bullet2.TopPunch;

					rc = nPunch1.CompareTo(nPunch2);

					fSpecial = true;

					break;

				//----------------------------------------------------------------------------*
				// Quantity
				//----------------------------------------------------------------------------*

				case 10:
					double dQuantity1 = Bullet1.Quantity;
					double dQuantity2 = Bullet2.Quantity;

					if (m_DataFiles.Preferences.TrackInventory)
						{
						dQuantity1 = Bullet1.QuantityOnHand;
						dQuantity2 = Bullet2.QuantityOnHand;
						}

					rc = dQuantity1.CompareTo(dQuantity2);

					fSpecial = true;

					break;

				//----------------------------------------------------------------------------*
				// Cost
				//----------------------------------------------------------------------------*

				case 11:
					double dCost1 = m_DataFiles.SupplyCostEach(Bullet1);
					double dCost2 = m_DataFiles.SupplyCostEach(Bullet2);

					rc = dCost1.CompareTo(dCost2);

					fSpecial = true;

					break;
				}

			//----------------------------------------------------------------------------*
			// Return results
			//----------------------------------------------------------------------------*

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
