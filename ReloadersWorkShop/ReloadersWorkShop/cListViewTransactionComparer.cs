//============================================================================*
// cListViewTransactionComparer.cs
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
	// cListViewTransactionComparer Class
	//============================================================================*

	class cListViewTransactionComparer : cListViewComparer
		{
		//============================================================================*
		// Private Data Members
		//============================================================================*


		//============================================================================*
		// cListViewTransactionComparer() - Constructor
		//============================================================================*

		public cListViewTransactionComparer(int nSortColumn, SortOrder SortOrder)
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

			cTransaction Transaction1 = (cTransaction)(Object1 as ListViewItem).Tag;
			cTransaction Transaction2 = (cTransaction)(Object2 as ListViewItem).Tag;

			if (Transaction1 == null)
				{
				if (Transaction2 == null)
					return (0);
				else
					return (-1);
				}
			else
				{
				if (Transaction2 == null)
					return (1);
				}

			bool fSpecial = false;
			int rc = 0;

			switch (SortColumn)
				{
				//----------------------------------------------------------------------------*
				// Date
				//----------------------------------------------------------------------------*

				case 0:
					rc = Transaction1.Date.CompareTo(Transaction2.Date);

					if (rc == 0)
						{
						if (Transaction1.BatchID != 0)
							rc = Transaction1.BatchID.CompareTo(Transaction2.BatchID);
						else
							rc = Transaction1.Source.CompareTo(Transaction2.Source);
						}

					fSpecial = true;

					break;

				//----------------------------------------------------------------------------*
				// Location/Reason
				//----------------------------------------------------------------------------*

				case 2:
					if (Transaction1.BatchID != 0)
						rc = Transaction1.BatchID.CompareTo(Transaction2.BatchID);
					else
						rc = Transaction1.Source.CompareTo(Transaction2.Source);

					fSpecial = true;

					break;

				//----------------------------------------------------------------------------*
				// Quantity
				//----------------------------------------------------------------------------*

				case 3:
					rc = Transaction1.Quantity.CompareTo(Transaction2.Quantity);

					fSpecial = true;

					break;

				//----------------------------------------------------------------------------*
				// Cost
				//----------------------------------------------------------------------------*

				case 4:
					rc = Transaction1.Cost.CompareTo(Transaction2.Cost);

					fSpecial = true;

					break;

				//----------------------------------------------------------------------------*
				// Tax
				//----------------------------------------------------------------------------*

				case 5:
					rc = Transaction1.Tax.CompareTo(Transaction2.Tax);

					fSpecial = true;

					break;

				//----------------------------------------------------------------------------*
				// Shipping
				//----------------------------------------------------------------------------*

				case 6:
					rc = Transaction1.Shipping.CompareTo(Transaction2.Shipping);

					fSpecial = true;

					break;

				//----------------------------------------------------------------------------*
				// Total
				//----------------------------------------------------------------------------*

				case 7:
					double dTotal1 = Transaction1.Cost + Transaction1.Tax + Transaction1.Shipping;
					double dTotal2 = Transaction2.Cost + Transaction2.Tax + Transaction2.Shipping;

					rc = dTotal1.CompareTo(dTotal2);

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
