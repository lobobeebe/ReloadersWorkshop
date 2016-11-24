//============================================================================*
// cListViewCaseComparer.cs
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

using ReloadersWorkShop.Preferences;

//============================================================================*
// Namespace
//============================================================================*

namespace ReloadersWorkShop
	{
	//============================================================================*
	// cListViewCaseComparer Class
	//============================================================================*

	class cListViewCaseComparer : cListViewComparer
		{
		//============================================================================*
		// Private Data Members
		//============================================================================*

		private cDataFiles m_DataFiles = null;

		//============================================================================*
		// cListViewCaseComparer() - Constructor
		//============================================================================*

		public cListViewCaseComparer(cDataFiles DataFiles, int nSortColumn, SortOrder SortOrder)
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

			cCase Case1 = (cCase) (Object1 as ListViewItem).Tag;
			cCase Case2 = (cCase) (Object2 as ListViewItem).Tag;

			if (Case1 == null)
				{
				if (Case2 == null)
					return (0);
				else
					return (-1);
				}
			else
				{
				if (Case2 == null)
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
					rc = Case1.Manufacturer.CompareTo(Case2.Manufacturer);

					if (rc == 0)
						{
						strPart1 = Case1.PartNumber;
						strPart2 = Case2.PartNumber;

						if (strPart1.Length != strPart2.Length)
							{
							string strPad = "";

							if (strPart1.Length < strPart2.Length)
								{
								while (strPart1.Length + strPad.Length < strPart2.Length)
									strPad += " ";

								strPart1 = strPad + strPart1;
								}
							else
								{
								while (strPart2.Length + strPad.Length < strPart1.Length)
									strPad += " ";

								strPart2 = strPad + strPart2;
								}
							}

						rc = strPart1.CompareTo(strPart2);
						}

					fSpecial = true;

					break;

				//----------------------------------------------------------------------------*
				// Part Number
				//----------------------------------------------------------------------------*

				case 1:
					rc = Case1.PartNumber.CompareTo(Case2.PartNumber);

					if (rc == 0)
						rc = Case1.Manufacturer.CompareTo(Case2.Manufacturer);

					if (rc == 0)
						{
						rc = cDataFiles.ComparePartNumbers(Case1.PartNumber, Case2.PartNumber);
						}

					fSpecial = true;

					break;

				//----------------------------------------------------------------------------*
				// Caliber
				//----------------------------------------------------------------------------*

				case 2:
					rc = Case1.Caliber.CompareTo(Case2.Caliber);

					if (rc == 0)
						{
						rc = Case1.Manufacturer.CompareTo(Case2.Manufacturer);

						if (rc == 0)
							{
							rc = cDataFiles.ComparePartNumbers(Case1.PartNumber, Case2.PartNumber);
							}
						}

					fSpecial = true;

					break;

				//----------------------------------------------------------------------------*
				// Match
				//----------------------------------------------------------------------------*

				case 5:
					rc = Case1.Match.CompareTo(Case2.Match);

					if (rc == 0)
						{
						rc = Case1.Manufacturer.CompareTo(Case2.Manufacturer);

						if (rc == 0)
							{
							rc = cDataFiles.ComparePartNumbers(Case1.PartNumber, Case2.PartNumber);
							}
						}

					fSpecial = true;

					break;

				//----------------------------------------------------------------------------*
				// Military
				//----------------------------------------------------------------------------*

				case 6:
					rc = Case1.Military.CompareTo(Case2.Military);

					if (rc == 0)
						{
						rc = Case1.Manufacturer.CompareTo(Case2.Manufacturer);

						if (rc == 0)
							{
							rc = cDataFiles.ComparePartNumbers(Case1.PartNumber, Case2.PartNumber);
							}
						}

					fSpecial = true;

					break;

				//----------------------------------------------------------------------------*
				// Quantity
				//----------------------------------------------------------------------------*

				case 7:
					double dQuantity1 = Case1.Quantity;
					double dQuantity2 = Case2.Quantity;

					if (m_DataFiles.Preferences.TrackInventory)
						{
						dQuantity1 = Case1.QuantityOnHand;
						dQuantity2 = Case2.QuantityOnHand;
						}

					rc = dQuantity1.CompareTo(dQuantity2);

					fSpecial = true;

					break;

				//----------------------------------------------------------------------------*
				// Cost
				//----------------------------------------------------------------------------*

				case 8:
					double dCost1 = m_DataFiles.SupplyCostEach(Case1);
					double dCost2 = m_DataFiles.SupplyCostEach(Case2);

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
