//============================================================================*
// cListViewTransactionComparer.cs
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

					fSpecial = true;

					break;

				//----------------------------------------------------------------------------*
				// Quantity
				//----------------------------------------------------------------------------*

				case 5:
					rc = Transaction1.Quantity.CompareTo(Transaction2.Quantity);

					fSpecial = true;

					break;

				//----------------------------------------------------------------------------*
				// Cost
				//----------------------------------------------------------------------------*

				case 6:
					rc = Transaction1.Cost.CompareTo(Transaction2.Cost);

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
