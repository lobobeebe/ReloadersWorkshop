//============================================================================*
// cListViewBatchLoadComparer.cs
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
	// cListViewBatchLoadComparer Class
	//============================================================================*

	class cListViewBatchLoadComparer : cListViewComparer
		{
		//============================================================================*
		// Private Data Members
		//============================================================================*


		//============================================================================*
		// cListViewBatchLoadComparer() - Constructor
		//============================================================================*

		public cListViewBatchLoadComparer(int nSortColumn, SortOrder SortOrder)
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
					return (-1);
				}
			else
				{
				if (Load2 == null)
					return (1);
				}

			bool fSpecial = false;
			int rc = 0;

			string strPart1 = "";
			string strPart2 = "";

			switch (SortColumn)
				{
				//----------------------------------------------------------------------------*
				// Caliber
				//----------------------------------------------------------------------------*

				case 0:
					rc = Load1.Caliber.CompareTo(Load2.Caliber);

					fSpecial = true;

					break;

				//----------------------------------------------------------------------------*
				// Bullet Manufacturer
				//----------------------------------------------------------------------------*

				case 1:
					rc = Load1.Bullet.Manufacturer.CompareTo(Load2.Bullet.Manufacturer);

					if (rc == 0)
						{
						strPart1 = Load1.Bullet.PartNumber;
						strPart2 = Load2.Bullet.PartNumber;

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
				// Powder
				//----------------------------------------------------------------------------*

				case 2:
					rc = Load1.Powder.Manufacturer.CompareTo(Load2.Powder.Manufacturer);

					if (rc == 0)
						{
						strPart1 = Load1.Powder.Type;
						strPart2 = Load2.Powder.Type;

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
				// Primer
				//----------------------------------------------------------------------------*

				case 3:
					rc = Load1.Primer.Manufacturer.CompareTo(Load2.Primer.Manufacturer);

					if (rc == 0)
						{
						strPart1 = Load1.Primer.Model;
						strPart2 = Load2.Primer.Model;

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
				// Case
				//----------------------------------------------------------------------------*

				case 4:
					rc = Load1.Case.Manufacturer.CompareTo(Load2.Case.Manufacturer);

					if (rc == 0)
						rc = Load1.Case.Caliber.CompareTo(Load2.Case.Caliber);

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
