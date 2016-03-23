//============================================================================*
// cListViewCopyChargeComparer.cs
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
	// cListViewCopyChargeComparer Class
	//============================================================================*

	class cListViewCopyChargeComparer : cListViewComparer
		{
		//============================================================================*
		// Private Data Members
		//============================================================================*

		//============================================================================*
		// cListViewCopyChargeComparer() - Constructor
		//============================================================================*

		public cListViewCopyChargeComparer(int nSortColumn, SortOrder SortOrder)
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

			cLoad Load1 = (cLoad)(Object1 as ListViewItem).Tag;
			cLoad Load2 = (cLoad)(Object2 as ListViewItem).Tag;

			if (Load1 == null)
				{
				if (Load2 == null)
					return (0);
				else
					return (0);
				}
			else
				{
				if (Load2 == null)
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
				// Bullet
				//----------------------------------------------------------------------------*

				case 0:
					rc = Load1.Bullet.Manufacturer.CompareTo(Load2.Bullet.Manufacturer);

					if (rc == 0)
						{
						string strPart1 = Load1.Bullet.PartNumber;
						string strPart2 = Load2.Bullet.PartNumber;

						if (strPart1.Length != strPart2.Length)
							{
							if (strPart1.Length > strPart2.Length)
								{
								string strPad = "";

								while (strPart1.Length > strPart2.Length + strPad.Length)
									strPad += " ";

								strPart2 = strPad + strPart2;
								}
							else
								{
								string strPad = "";

								while (strPart2.Length > strPart1.Length + strPad.Length)
									strPad += " ";

								strPart1 = strPad + strPart1;
								}
							}


						rc = strPart1.CompareTo(strPart2);

						if (rc == 0)
							{
							rc = Load1.Powder.CompareTo(Load2.Powder);
							}
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
