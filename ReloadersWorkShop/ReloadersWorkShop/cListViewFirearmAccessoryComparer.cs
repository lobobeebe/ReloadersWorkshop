//============================================================================*
// cListViewFirearmAccessoryComparer.cs
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
	// cListViewFirearmAccessoryComparer Class
	//============================================================================*

	class cListViewFirearmAccessoryComparer : cListViewComparer
		{
		//============================================================================*
		// cListViewFirearmAccessoryComparer() - Constructor
		//============================================================================*

		public cListViewFirearmAccessoryComparer(int nSortColumn, SortOrder SortOrder)
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

			cGear Gear1 = (cGear) (Object1 as ListViewItem).Tag;
			cGear Gear2 = (cGear) (Object2 as ListViewItem).Tag;

			if (Gear1 == null)
				{
				if (Gear2 == null)
					return (0);
				else
					return (0);
				}
			else
				{
				if (Gear2 == null)
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
				// Manufacturer
				//----------------------------------------------------------------------------*

				case 0:
					rc = CompareGear(Gear1, Gear2);

					fSpecial = true;

					break;

				//----------------------------------------------------------------------------*
				// Model
				//----------------------------------------------------------------------------*

				case 1:
					rc = cDataFiles.ComparePartNumbers(Gear1.PartNumber, Gear2.PartNumber);

					if (rc == 0)
						{
						rc = Gear1.Manufacturer.CompareTo(Gear2.Manufacturer);

						if (rc == 0)
							rc = cDataFiles.ComparePartNumbers(Gear1.SerialNumber, Gear2.SerialNumber);
						}

					fSpecial = true;

					break;

				//----------------------------------------------------------------------------*
				// Serial  Number
				//----------------------------------------------------------------------------*

				case 2:
					rc = cDataFiles.ComparePartNumbers(Gear1.SerialNumber, Gear2.SerialNumber);

					if (rc == 0)
						{
						rc = Gear1.Manufacturer.CompareTo(Gear2.Manufacturer);

						if (rc == 0)
							rc = cDataFiles.ComparePartNumbers(Gear1.PartNumber, Gear2.PartNumber);
						}

					fSpecial = true;

					break;

				//----------------------------------------------------------------------------*
				// Description
				//----------------------------------------------------------------------------*

				case 3:
					rc = Gear1.Description.CompareTo(Gear2.Description);

					if (rc == 0)
						{
						rc = Gear1.Manufacturer.CompareTo(Gear2.Manufacturer);

						if (rc == 0)
							{
							rc = cDataFiles.ComparePartNumbers(Gear1.PartNumber, Gear2.PartNumber);

							if (rc == 0)
								rc = cDataFiles.ComparePartNumbers(Gear1.SerialNumber, Gear2.SerialNumber);
							}
						}

					fSpecial = true;

					break;

				//----------------------------------------------------------------------------*
				// Firearm
				//----------------------------------------------------------------------------*

				case 4:
					rc = (Object1 as ListViewItem).SubItems[4].Text.CompareTo((Object2 as ListViewItem).SubItems[4].Text);

					if (rc == 0)
						CompareGear(Gear1, Gear2);

					fSpecial = true;

					break;

				//----------------------------------------------------------------------------*
				// Source
				//----------------------------------------------------------------------------*

				case 5:
					rc = Gear1.Source.CompareTo(Gear2.Source);

					if (rc == 0)
						{
						rc = Gear1.Manufacturer.CompareTo(Gear2.Manufacturer);

						if (rc == 0)
							{
							rc = cDataFiles.ComparePartNumbers(Gear1.PartNumber, Gear2.PartNumber);

							if (rc == 0)
								{
								rc = cDataFiles.ComparePartNumbers(Gear1.SerialNumber, Gear2.SerialNumber);

								if (rc == 0)
									rc = Gear1.Description.CompareTo(Gear2.Description);
								}
							}
						}

					fSpecial = true;

					break;

				//----------------------------------------------------------------------------*
				// Date
				//----------------------------------------------------------------------------*

				case 6:
					rc = Gear1.PurchaseDate.CompareTo(Gear2.PurchaseDate);

					if (rc == 0)
						rc = CompareGear(Gear1, Gear2);

					fSpecial = true;

					break;

				//----------------------------------------------------------------------------*
				// Price
				//----------------------------------------------------------------------------*

				case 7:
					rc = Gear1.PurchasePrice.CompareTo(Gear2.PurchasePrice);

					if (rc == 0)
						{
						rc = Gear1.Manufacturer.CompareTo(Gear2.Manufacturer);

						if (rc == 0)
							{
							rc = cDataFiles.ComparePartNumbers(Gear1.PartNumber, Gear2.PartNumber);

							if (rc == 0)
								{
								rc = Gear1.Description.CompareTo(Gear2.Description);

								if (rc == 0)
									{
									rc = cDataFiles.ComparePartNumbers(Gear1.SerialNumber, Gear2.SerialNumber);

									if (rc == 0)
										rc = Gear1.Source.CompareTo(Gear2.Source);
									}
								}
							}
						}

					fSpecial = true;

					break;

				//----------------------------------------------------------------------------*
				// Tax
				//----------------------------------------------------------------------------*

				case 8:
					rc = Gear1.Tax.CompareTo(Gear2.Tax);

					if (rc == 0)
						{
						rc = Gear1.Manufacturer.CompareTo(Gear2.Manufacturer);

						if (rc == 0)
							{
							rc = cDataFiles.ComparePartNumbers(Gear1.PartNumber, Gear2.PartNumber);

							if (rc == 0)
								{
								rc = Gear1.Description.CompareTo(Gear2.Description);

								if (rc == 0)
									{
									rc = cDataFiles.ComparePartNumbers(Gear1.SerialNumber, Gear2.SerialNumber);

									if (rc == 0)
										rc = Gear1.Source.CompareTo(Gear2.Source);
									}
								}
							}
						}

					fSpecial = true;

					break;

				//----------------------------------------------------------------------------*
				// Shipping
				//----------------------------------------------------------------------------*

				case 9:
					rc = Gear1.Shipping.CompareTo(Gear2.Shipping);

					if (rc == 0)
						{
						rc = Gear1.Manufacturer.CompareTo(Gear2.Manufacturer);

						if (rc == 0)
							{
							rc = cDataFiles.ComparePartNumbers(Gear1.PartNumber, Gear2.PartNumber);

							if (rc == 0)
								{
								rc = Gear1.Description.CompareTo(Gear2.Description);

								if (rc == 0)
									{
									rc = cDataFiles.ComparePartNumbers(Gear1.SerialNumber, Gear2.SerialNumber);

									if (rc == 0)
										rc = Gear1.Source.CompareTo(Gear2.Source);
									}
								}
							}
						}

					fSpecial = true;

					break;

				//----------------------------------------------------------------------------*
				// Total
				//----------------------------------------------------------------------------*

				case 10:
					double dTotal1 = 0.0;

					if ((Object1 as ListViewItem).Text != "-")
						Double.TryParse((Object1 as ListViewItem).SubItems[10].Text, out dTotal1);

					double dTotal2 = 0.0;

					if ((Object2 as ListViewItem).Text != "-")
						Double.TryParse((Object2 as ListViewItem).SubItems[10].Text, out dTotal2);

					rc = dTotal1.CompareTo(dTotal2);

					if (rc == 0)
						{
						rc = Gear1.Manufacturer.CompareTo(Gear2.Manufacturer);

						if (rc == 0)
							{
							rc = cDataFiles.ComparePartNumbers(Gear1.PartNumber, Gear2.PartNumber);

							if (rc == 0)
								{
								rc = Gear1.Description.CompareTo(Gear2.Description);

								if (rc == 0)
									{
									rc = cDataFiles.ComparePartNumbers(Gear1.SerialNumber, Gear2.SerialNumber);

									if (rc == 0)
										rc = Gear1.Source.CompareTo(Gear2.Source);
									}
								}
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

		//============================================================================*
		// CompareGear()
		//============================================================================*

		public int CompareGear(cGear Gear1, cGear Gear2)
			{
			int rc = Gear1.Manufacturer.CompareTo(Gear2.Manufacturer);

			if (rc == 0)
				{
				rc = cDataFiles.ComparePartNumbers(Gear1.PartNumber, Gear2.PartNumber);

				if (rc == 0)
					{
					rc = Gear1.Description.CompareTo(Gear2.Description);

					if (rc == 0)
						rc = cDataFiles.ComparePartNumbers(Gear1.SerialNumber, Gear2.SerialNumber);
					}
				}

			return (rc);
			}
		}
	}
