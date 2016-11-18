//============================================================================*
// cListViewPrimerComparer.cs
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
	// cListViewPrimerComparer Class
	//============================================================================*

	class cListViewPrimerComparer : cListViewComparer
		{
		//============================================================================*
		// Private Data Members
		//============================================================================*

		private cDataFiles m_DataFiles = null;

		//============================================================================*
		// cListViewPrimerComparer() - Constructor
		//============================================================================*

		public cListViewPrimerComparer(cDataFiles DataFiles, int nSortColumn, SortOrder SortOrder)
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

			cPrimer Primer1 = (cPrimer)(Object1 as ListViewItem).Tag;
			cPrimer Primer2 = (cPrimer)(Object2 as ListViewItem).Tag;

			if (Primer1 == null)
				{
				if (Primer2 == null)
					return (0);
				else
					return (-1);
				}
			else
				{
				if (Primer2 == null)
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
					rc = Primer1.Manufacturer.CompareTo(Primer2.Manufacturer);

					if (rc == 0)
						rc = Primer1.Model.CompareTo(Primer2.Model);

					fSpecial = true;

					break;

				//----------------------------------------------------------------------------*
				// Quantity
				//----------------------------------------------------------------------------*

				case 10:
					double dQuantity1 = Primer1.Quantity;
					double dQuantity2 = Primer2.Quantity;

					if (cPreferences.TrackInventory)
						{
						dQuantity1 = Primer1.QuantityOnHand;
						dQuantity2 = Primer2.QuantityOnHand;
						}

					rc = dQuantity1.CompareTo(dQuantity2);

					fSpecial = true;

					break;

				//----------------------------------------------------------------------------*
				// Cost
				//----------------------------------------------------------------------------*

				case 11:
					double dCost1 = m_DataFiles.SupplyCostEach(Primer1);
					double dCost2 = m_DataFiles.SupplyCostEach(Primer2);

					rc = dCost1.CompareTo(dCost2);

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
