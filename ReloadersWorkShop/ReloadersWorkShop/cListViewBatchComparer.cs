//============================================================================*
// cListViewBatchComparer.cs
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
	// cListViewBatchComparer Class
	//============================================================================*

	class cListViewBatchComparer : cListViewComparer
		{
		//============================================================================*
		// Private Data Members
		//============================================================================*


		//============================================================================*
		// cListViewBatchComparer() - Constructor
		//============================================================================*

		public cListViewBatchComparer(int nSortColumn, SortOrder SortOrder)
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

			cBatch Batch1 = (cBatch)(Object1 as ListViewItem).Tag;
			cBatch Batch2 = (cBatch)(Object2 as ListViewItem).Tag;

			if (Batch1 == null)
				{
				if (Batch2 == null)
					return (0);
				else
					return (-1);
				}
			else
				{
				if (Batch2 == null)
					return (1);
				}

			bool fSpecial = false;
			int rc = 0;

			switch (SortColumn)
				{
				//----------------------------------------------------------------------------*
				// Batch ID
				//----------------------------------------------------------------------------*

				case 0:
					rc = Batch1.BatchID.CompareTo(Batch2.BatchID);

					fSpecial = true;

					break;

				//----------------------------------------------------------------------------*
				// Date
				//----------------------------------------------------------------------------*

				case 1:
					rc = Batch1.DateLoaded.CompareTo(Batch2.DateLoaded);

					if (rc == 0)
						rc = Batch1.BatchID.CompareTo(Batch2.BatchID);

					fSpecial = true;

					break;

				//----------------------------------------------------------------------------*
				// test Data
				//----------------------------------------------------------------------------*

				case 2:
					rc = 0;

					if (Batch1.BatchTest != null)
						{
						if (Batch2.BatchTest == null)
							rc = 1;
						}
					else
						{
						if (Batch2.BatchTest != null)
							rc = -1;

						}

					if (rc == 0)
						rc = Batch1.BatchID.CompareTo(Batch2.BatchID);

					fSpecial = true;

					break;

				//----------------------------------------------------------------------------*
				// Num Rounds
				//----------------------------------------------------------------------------*

				case 4:
					rc = Batch1.NumRounds.CompareTo(Batch2.NumRounds);

					if (rc == 0)
						rc = Batch1.BatchID.CompareTo(Batch2.BatchID);

					fSpecial = true;

					break;

				//----------------------------------------------------------------------------*
				// Bullet
				//----------------------------------------------------------------------------*

				case 5:
					rc = Batch1.Load.Bullet.CompareTo(Batch2.Load.Bullet);

					if (rc == 0)
						rc = Batch1.BatchID.CompareTo(Batch2.BatchID);

					fSpecial = true;

					break;

				//----------------------------------------------------------------------------*
				// Powder
				//----------------------------------------------------------------------------*

				case 6:
					rc = Batch1.Load.Powder.CompareTo(Batch2.Load.Powder);

					if (rc == 0)
						{
						rc = Batch1.PowderWeight.CompareTo(Batch2.PowderWeight);

						if (rc == 0)
							rc = Batch1.BatchID.CompareTo(Batch2.BatchID);
						}

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
