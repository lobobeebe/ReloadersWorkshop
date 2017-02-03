//============================================================================*
// cListViewFirearmComparer.cs
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
	// cListViewFirearmComparer Class
	//============================================================================*

	class cListViewFirearmComparer : cListViewComparer
		{
		//============================================================================*
		// cListViewFirearmComparer() - Constructor
		//============================================================================*

		public cListViewFirearmComparer(int nSortColumn, SortOrder SortOrder)
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

			cFirearm Firearm1 = (cFirearm) (Object1 as ListViewItem).Tag;
			cFirearm Firearm2 = (cFirearm) (Object2 as ListViewItem).Tag;

			if (Firearm1 == null)
				{
				if (Firearm2 == null)
					return (0);
				else
					return (0);
				}
			else
				{
				if (Firearm2 == null)
					return (1);
				}

			//----------------------------------------------------------------------------*
			// Do Special Compares
			//----------------------------------------------------------------------------*

			bool fSpecial = false;
			int rc = 0;

			double dTotal1 = 0.0;
			double dTotal2 = 0.0;

			switch (SortColumn)
				{
				//----------------------------------------------------------------------------*
				// Manufacturer
				//----------------------------------------------------------------------------*

				case 0:
					rc = CompareGear(Firearm1, Firearm2);

					if (rc == 0)
						rc = Firearm1.PrimaryCaliber.CompareTo(Firearm2.PrimaryCaliber);

					fSpecial = true;

					break;

				//----------------------------------------------------------------------------*
				// Model
				//----------------------------------------------------------------------------*

				case 1:
					rc = cDataFiles.ComparePartNumbers(Firearm1.PartNumber, Firearm2.PartNumber);

					if (rc == 0)
						{
						rc = Firearm1.Manufacturer.CompareTo(Firearm2.Manufacturer);

						if (rc == 0)
							rc = cDataFiles.ComparePartNumbers(Firearm1.SerialNumber, Firearm2.SerialNumber);
						}

					fSpecial = true;

					break;

				//----------------------------------------------------------------------------*
				// Serial  Number
				//----------------------------------------------------------------------------*

				case 2:
					rc = cDataFiles.ComparePartNumbers(Firearm1.SerialNumber, Firearm2.SerialNumber);

					if (rc == 0)
						{
						rc = Firearm1.Manufacturer.CompareTo(Firearm2.Manufacturer);

						if (rc == 0)
							rc = cDataFiles.ComparePartNumbers(Firearm1.PartNumber, Firearm2.PartNumber);
						}

					fSpecial = true;

					break;

				//----------------------------------------------------------------------------*
				// Description
				//----------------------------------------------------------------------------*

				case 3:
					rc = Firearm1.Description.CompareTo(Firearm2.Description);

					if (rc == 0)
						{
						rc = Firearm1.Manufacturer.CompareTo(Firearm2.Manufacturer);

						if (rc == 0)
							{
							rc = cDataFiles.ComparePartNumbers(Firearm1.PartNumber, Firearm2.PartNumber);

							if (rc == 0)
								rc = cDataFiles.ComparePartNumbers(Firearm1.SerialNumber, Firearm2.SerialNumber);
							}
						}

					fSpecial = true;

					break;

				//----------------------------------------------------------------------------*
				// Caliber
				//----------------------------------------------------------------------------*

				case 4:
					rc = Firearm1.PrimaryCaliber.CompareTo(Firearm2.PrimaryCaliber);

					if (rc == 0)
						CompareGear(Firearm1, Firearm2);

					fSpecial = true;

					break;

				//----------------------------------------------------------------------------*
				// Source
				//----------------------------------------------------------------------------*

				case 5:
					rc = Firearm1.Source.CompareTo(Firearm2.Source);

					if (rc == 0)
						{
						rc = Firearm1.Manufacturer.CompareTo(Firearm2.Manufacturer);

						if (rc == 0)
							{
							rc = cDataFiles.ComparePartNumbers(Firearm1.PartNumber, Firearm2.PartNumber);

							if (rc == 0)
								{
								rc = cDataFiles.ComparePartNumbers(Firearm1.SerialNumber, Firearm2.SerialNumber);

								if (rc == 0)
									rc = Firearm1.Description.CompareTo(Firearm2.Description);
								}
							}
						}

					fSpecial = true;

					break;

				//----------------------------------------------------------------------------*
				// Date
				//----------------------------------------------------------------------------*

				case 6:
					rc = Firearm1.PurchaseDate.CompareTo(Firearm2.PurchaseDate);

					if (rc == 0)
						rc = CompareGear(Firearm1,Firearm2);

					fSpecial = true;

					break;

				//----------------------------------------------------------------------------*
				// Price
				//----------------------------------------------------------------------------*

				case 7:
					rc = Firearm1.PurchasePrice.CompareTo(Firearm2.PurchasePrice);

					if (rc == 0)
						{
						rc = Firearm1.Manufacturer.CompareTo(Firearm2.Manufacturer);

						if (rc == 0)
							{
							rc = cDataFiles.ComparePartNumbers(Firearm1.PartNumber, Firearm2.PartNumber);

							if (rc == 0)
								{
								rc = Firearm1.Description.CompareTo(Firearm2.Description);

								if (rc == 0)
									{
									rc = cDataFiles.ComparePartNumbers(Firearm1.SerialNumber, Firearm2.SerialNumber);

									if (rc == 0)
										rc = Firearm1.Source.CompareTo(Firearm2.Source);
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
					rc = Firearm1.Tax.CompareTo(Firearm2.Tax);

					if (rc == 0)
						{
						rc = Firearm1.Manufacturer.CompareTo(Firearm2.Manufacturer);

						if (rc == 0)
							{
							rc = cDataFiles.ComparePartNumbers(Firearm1.PartNumber, Firearm2.PartNumber);

							if (rc == 0)
								{
								rc = Firearm1.Description.CompareTo(Firearm2.Description);

								if (rc == 0)
									{
									rc = cDataFiles.ComparePartNumbers(Firearm1.SerialNumber, Firearm2.SerialNumber);

									if (rc == 0)
										rc = Firearm1.Source.CompareTo(Firearm2.Source);
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
					rc = Firearm1.Shipping.CompareTo(Firearm2.Shipping);

					if (rc == 0)
						{
						rc = Firearm1.Manufacturer.CompareTo(Firearm2.Manufacturer);

						if (rc == 0)
							{
							rc = cDataFiles.ComparePartNumbers(Firearm1.PartNumber, Firearm2.PartNumber);

							if (rc == 0)
								{
								rc = Firearm1.Description.CompareTo(Firearm2.Description);

								if (rc == 0)
									{
									rc = cDataFiles.ComparePartNumbers(Firearm1.SerialNumber, Firearm2.SerialNumber);

									if (rc == 0)
										rc = Firearm1.Source.CompareTo(Firearm2.Source);
									}
								}
							}
						}

					fSpecial = true;

					break;


				//----------------------------------------------------------------------------*
				// Transfer Fees
				//----------------------------------------------------------------------------*

				case 10:
					dTotal1 = 0.0;

					if ((Object1 as ListViewItem).Text != "-")
						Double.TryParse((Object1 as ListViewItem).SubItems[10].Text, out dTotal1);

					dTotal2 = 0.0;

					if ((Object2 as ListViewItem).Text != "-")
						Double.TryParse((Object2 as ListViewItem).SubItems[10].Text, out dTotal2);

					rc = dTotal1.CompareTo(dTotal2);

					if (rc == 0)
						{
						rc = Firearm1.Manufacturer.CompareTo(Firearm2.Manufacturer);

						if (rc == 0)
							{
							rc = cDataFiles.ComparePartNumbers(Firearm1.PartNumber, Firearm2.PartNumber);

							if (rc == 0)
								{
								rc = Firearm1.Description.CompareTo(Firearm2.Description);

								if (rc == 0)
									{
									rc = cDataFiles.ComparePartNumbers(Firearm1.SerialNumber, Firearm2.SerialNumber);

									if (rc == 0)
										rc = Firearm1.Source.CompareTo(Firearm2.Source);
									}
								}
							}
						}

					fSpecial = true;

					break;

				//----------------------------------------------------------------------------*
				// Other Fees
				//----------------------------------------------------------------------------*

				case 11:
					dTotal1 = 0.0;

					if ((Object1 as ListViewItem).Text != "-")
						Double.TryParse((Object1 as ListViewItem).SubItems[11].Text, out dTotal1);

					dTotal2 = 0.0;

					if ((Object2 as ListViewItem).Text != "-")
						Double.TryParse((Object2 as ListViewItem).SubItems[11].Text, out dTotal2);

					rc = dTotal1.CompareTo(dTotal2);

					if (rc == 0)
						{
						rc = Firearm1.Manufacturer.CompareTo(Firearm2.Manufacturer);

						if (rc == 0)
							{
							rc = cDataFiles.ComparePartNumbers(Firearm1.PartNumber, Firearm2.PartNumber);

							if (rc == 0)
								{
								rc = Firearm1.Description.CompareTo(Firearm2.Description);

								if (rc == 0)
									{
									rc = cDataFiles.ComparePartNumbers(Firearm1.SerialNumber, Firearm2.SerialNumber);

									if (rc == 0)
										rc = Firearm1.Source.CompareTo(Firearm2.Source);
									}
								}
							}
						}

					fSpecial = true;

					break;

				//----------------------------------------------------------------------------*
				// Total
				//----------------------------------------------------------------------------*

				case 12:
					dTotal1 = 0.0;

					if ((Object1 as ListViewItem).Text != "-")
						Double.TryParse((Object1 as ListViewItem).SubItems[12].Text, out dTotal1);

					dTotal2 = 0.0;

					if ((Object2 as ListViewItem).Text != "-")
						Double.TryParse((Object2 as ListViewItem).SubItems[12].Text, out dTotal2);

					rc = dTotal1.CompareTo(dTotal2);

					if (rc == 0)
						{
						rc = Firearm1.Manufacturer.CompareTo(Firearm2.Manufacturer);

						if (rc == 0)
							{
							rc = cDataFiles.ComparePartNumbers(Firearm1.PartNumber, Firearm2.PartNumber);

							if (rc == 0)
								{
								rc = Firearm1.Description.CompareTo(Firearm2.Description);

								if (rc == 0)
									{
									rc = cDataFiles.ComparePartNumbers(Firearm1.SerialNumber, Firearm2.SerialNumber);

									if (rc == 0)
										rc = Firearm1.Source.CompareTo(Firearm2.Source);
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

