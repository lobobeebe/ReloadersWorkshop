//============================================================================*
// cListViewPowderComparer.cs
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

using ReloadersWorkShop.Preferences;

//============================================================================*
// Namespace
//============================================================================*

namespace ReloadersWorkShop
	{
	//============================================================================*
	// cListViewPowderComparer Class
	//============================================================================*

	class cListViewPowderComparer : cListViewComparer
		{
		//============================================================================*
		// Private Data Members
		//============================================================================*

		private cDataFiles m_DataFiles = null;

		//============================================================================*
		// cListViewPowderComparer() - Constructor
		//============================================================================*

		public cListViewPowderComparer(cDataFiles DataFiles, int nSortColumn, SortOrder SortOrder)
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

			cPowder Powder1 = (cPowder)(Object1 as ListViewItem).Tag;
			cPowder Powder2 = (cPowder)(Object2 as ListViewItem).Tag;

			if (Powder1 == null)
				{
				if (Powder2 == null)
					return (0);
				else
					return (-1);
				}
			else
				{
				if (Powder2 == null)
					return (1);
				}

			bool fSpecial = false;
			int rc = 0;

			switch (SortColumn)
				{
				//----------------------------------------------------------------------------*
				// Manufacturer
				//----------------------------------------------------------------------------*

				case 0:
					rc = Powder1.Manufacturer.CompareTo(Powder2.Manufacturer);

					if (rc == 0)
						{
						string strPart1 = Powder1.Model;
						string strPart2 = Powder2.Model;

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
				// Model
				//----------------------------------------------------------------------------*

				case 1:
					if (rc == 0)
						{
						string strPart1 = Powder1.Model;
						string strPart2 = Powder2.Model;

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

					if (rc == 0)
						rc = Powder1.Manufacturer.CompareTo(Powder2.Manufacturer);

					fSpecial = true;

					break;

				//----------------------------------------------------------------------------*
				// Quantity
				//----------------------------------------------------------------------------*

				case 4:
					double dQuantity1 = Powder1.Quantity;
					double dQuantity2 = Powder2.Quantity;

					if (m_DataFiles.Preferences.TrackInventory)
						{
						dQuantity1 = Powder1.QuantityOnHand;
						dQuantity2 = Powder2.QuantityOnHand;
						}

					rc = dQuantity1.CompareTo(dQuantity2);

					fSpecial = true;

					break;

				//----------------------------------------------------------------------------*
				// Cost
				//----------------------------------------------------------------------------*

				case 5:
					double dCost1 = 0.0;

					if ((Object1 as ListViewItem).Text != "-")
						Double.TryParse((Object1 as ListViewItem).SubItems[5].Text, out dCost1);

					double dCost2 = 0.0;

					if ((Object2 as ListViewItem).Text != "-")
						Double.TryParse((Object2 as ListViewItem).SubItems[5].Text, out dCost2);

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
