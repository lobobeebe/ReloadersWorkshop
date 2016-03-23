//============================================================================*
// cListViewFirearmBulletComparer.cs
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
	// cListViewFirearmBulletComparer Class
	//============================================================================*

	class cListViewFirearmBulletComparer : cListViewComparer
		{
		//============================================================================*
		// Private Data Members
		//============================================================================*

		//============================================================================*
		// cListViewFirearmBulletComparer() - Constructor
		//============================================================================*

		public cListViewFirearmBulletComparer(int nSortColumn, SortOrder SortOrder)
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

			cFirearmBullet Bullet1 = (cFirearmBullet)(Object1 as ListViewItem).Tag;
			cFirearmBullet Bullet2 = (cFirearmBullet)(Object2 as ListViewItem).Tag;

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

			switch (SortColumn)
				{
				//----------------------------------------------------------------------------*
				// Manufacturer
				//----------------------------------------------------------------------------*

				case 0:
					rc = Bullet1.Bullet.Manufacturer.CompareTo(Bullet2.Bullet.Manufacturer);

					if (rc == 0)
						{
						string strPart1 = Bullet1.Bullet.PartNumber;
						string strPart2 = Bullet2.Bullet.PartNumber;

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
				// COL
				//----------------------------------------------------------------------------*

				case 1:
					rc = Bullet1.COL.CompareTo(Bullet2.COL);

					fSpecial = true;

					break;

				//----------------------------------------------------------------------------*
				// CBTO
				//----------------------------------------------------------------------------*

				case 2:
					rc = Bullet1.CBTO.CompareTo(Bullet2.CBTO);

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

