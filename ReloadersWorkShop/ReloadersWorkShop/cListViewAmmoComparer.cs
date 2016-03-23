//============================================================================*
// cListViewFactoryAmmoComparer.cs
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
	// cListViewFactoryAmmoComparer Class
	//============================================================================*

	class cListViewAmmoComparer : cListViewComparer
		{
		//============================================================================*
		// cListViewFactoryAmmoComparer() - Constructor
		//============================================================================*

		public cListViewAmmoComparer(int nSortColumn, SortOrder SortOrder)
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

			cAmmo FactoryAmmo1 = (cAmmo)(Object1 as ListViewItem).Tag;
			cAmmo FactoryAmmo2 = (cAmmo)(Object2 as ListViewItem).Tag;

			if (FactoryAmmo1 == null)
				{
				if (FactoryAmmo2 == null)
					return (0);
				else
					return (0);
				}
			else
				{
				if (FactoryAmmo2 == null)
					return (1);
				}

			//----------------------------------------------------------------------------*
			// Do Special Compares
			//----------------------------------------------------------------------------*

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
					if (FactoryAmmo1.Manufacturer == null)
						{
						if (FactoryAmmo2.Manufacturer == null)
							rc = 0;
						else
							rc = "Reload".CompareTo(FactoryAmmo2.Manufacturer.Name);
						}
					else
						{
						if (FactoryAmmo2.Manufacturer == null)
							rc = FactoryAmmo1.Manufacturer.Name.CompareTo("Reload");
						else
							rc = FactoryAmmo1.Manufacturer.CompareTo(FactoryAmmo2.Manufacturer);
						}

					if (rc == 0)
						{
						strPart1 = FactoryAmmo1.PartNumber;
						strPart2 = FactoryAmmo2.PartNumber;

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
					strPart1 = FactoryAmmo1.PartNumber;
					strPart2 = FactoryAmmo2.PartNumber;

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

					fSpecial = true;

					break;

				//----------------------------------------------------------------------------*
				// Bullet Weight
				//----------------------------------------------------------------------------*

				case 6:
					rc = FactoryAmmo1.BulletWeight.CompareTo(FactoryAmmo2.BulletWeight);

					fSpecial = true;

					break;

				//----------------------------------------------------------------------------*
				// Ballistic Coefficient
				//----------------------------------------------------------------------------*

				case 8:
					rc = FactoryAmmo1.BallisticCoefficient.CompareTo(FactoryAmmo2.BallisticCoefficient);

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
