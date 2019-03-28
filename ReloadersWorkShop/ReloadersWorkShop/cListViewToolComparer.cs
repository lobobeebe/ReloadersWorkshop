//============================================================================*
// cListViewToolComparer.cs
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
	// cListViewToolComparer Class
	//============================================================================*

	class cListViewToolComparer : cListViewComparer
		{
		//============================================================================*
		// cListViewToolComparer() - Constructor
		//============================================================================*

		public cListViewToolComparer(int nSortColumn, SortOrder SortOrder)
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

			cTool Tool1 = (cTool)(Object1 as ListViewItem).Tag;
			cTool Tool2 = (cTool)(Object2 as ListViewItem).Tag;

			if (Tool1 == null)
				{
				if (Tool2 == null)
					return (0);
				else
					return (0);
				}
			else
				{
				if (Tool2 == null)
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
					rc = CompareTool(Tool1, Tool2);

					fSpecial = true;

					break;

				//----------------------------------------------------------------------------*
				// Model
				//----------------------------------------------------------------------------*

				case 1:
					rc = cDataFiles.ComparePartNumbers(Tool1.PartNumber, Tool2.PartNumber);

					if (rc == 0)
						{
						rc = Tool1.Manufacturer.CompareTo(Tool2.Manufacturer);

						if (rc == 0)
							rc = cDataFiles.ComparePartNumbers(Tool1.SerialNumber, Tool2.SerialNumber);
						}

					fSpecial = true;

					break;

				//----------------------------------------------------------------------------*
				// Serial  Number
				//----------------------------------------------------------------------------*

				case 2:
					rc = cDataFiles.ComparePartNumbers(Tool1.SerialNumber, Tool2.SerialNumber);

					if (rc == 0)
						{
						rc = Tool1.Manufacturer.CompareTo(Tool2.Manufacturer);

						if (rc == 0)
							rc = cDataFiles.ComparePartNumbers(Tool1.PartNumber, Tool2.PartNumber);
						}

					fSpecial = true;

					break;

				//----------------------------------------------------------------------------*
				// Description
				//----------------------------------------------------------------------------*

				case 3:
					rc = Tool1.Description.CompareTo(Tool2.Description);

					if (rc == 0)
						{
						rc = Tool1.Manufacturer.CompareTo(Tool2.Manufacturer);

						if (rc == 0)
							{
							rc = cDataFiles.ComparePartNumbers(Tool1.PartNumber, Tool2.PartNumber);

							if (rc == 0)
								rc = cDataFiles.ComparePartNumbers(Tool1.SerialNumber, Tool2.SerialNumber);
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
						CompareTool(Tool1, Tool2);

					fSpecial = true;

					break;

				//----------------------------------------------------------------------------*
				// Source
				//----------------------------------------------------------------------------*

				case 5:
					rc = Tool1.Source.CompareTo(Tool2.Source);

					if (rc == 0)
						{
						rc = Tool1.Manufacturer.CompareTo(Tool2.Manufacturer);

						if (rc == 0)
							{
							rc = cDataFiles.ComparePartNumbers(Tool1.PartNumber, Tool2.PartNumber);

							if (rc == 0)
								{
								rc = cDataFiles.ComparePartNumbers(Tool1.SerialNumber, Tool2.SerialNumber);

								if (rc == 0)
									rc = Tool1.Description.CompareTo(Tool2.Description);
								}
							}
						}

					fSpecial = true;

					break;

				//----------------------------------------------------------------------------*
				// Date
				//----------------------------------------------------------------------------*

				case 6:
					rc = Tool1.PurchaseDate.CompareTo(Tool2.PurchaseDate);

					if (rc == 0)
						rc = CompareTool(Tool1, Tool2);

					fSpecial = true;

					break;

				//----------------------------------------------------------------------------*
				// Price
				//----------------------------------------------------------------------------*

				case 7:
					rc = Tool1.PurchasePrice.CompareTo(Tool2.PurchasePrice);

					if (rc == 0)
						{
						rc = Tool1.Manufacturer.CompareTo(Tool2.Manufacturer);

						if (rc == 0)
							{
							rc = cDataFiles.ComparePartNumbers(Tool1.PartNumber, Tool2.PartNumber);

							if (rc == 0)
								{
								rc = Tool1.Description.CompareTo(Tool2.Description);

								if (rc == 0)
									{
									rc = cDataFiles.ComparePartNumbers(Tool1.SerialNumber, Tool2.SerialNumber);

									if (rc == 0)
										rc = Tool1.Source.CompareTo(Tool2.Source);
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
					rc = Tool1.Tax.CompareTo(Tool2.Tax);

					if (rc == 0)
						{
						rc = Tool1.Manufacturer.CompareTo(Tool2.Manufacturer);

						if (rc == 0)
							{
							rc = cDataFiles.ComparePartNumbers(Tool1.PartNumber, Tool2.PartNumber);

							if (rc == 0)
								{
								rc = Tool1.Description.CompareTo(Tool2.Description);

								if (rc == 0)
									{
									rc = cDataFiles.ComparePartNumbers(Tool1.SerialNumber, Tool2.SerialNumber);

									if (rc == 0)
										rc = Tool1.Source.CompareTo(Tool2.Source);
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
					rc = Tool1.Shipping.CompareTo(Tool2.Shipping);

					if (rc == 0)
						{
						rc = Tool1.Manufacturer.CompareTo(Tool2.Manufacturer);

						if (rc == 0)
							{
							rc = cDataFiles.ComparePartNumbers(Tool1.PartNumber, Tool2.PartNumber);

							if (rc == 0)
								{
								rc = Tool1.Description.CompareTo(Tool2.Description);

								if (rc == 0)
									{
									rc = cDataFiles.ComparePartNumbers(Tool1.SerialNumber, Tool2.SerialNumber);

									if (rc == 0)
										rc = Tool1.Source.CompareTo(Tool2.Source);
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
						rc = Tool1.Manufacturer.CompareTo(Tool2.Manufacturer);

						if (rc == 0)
							{
							rc = cDataFiles.ComparePartNumbers(Tool1.PartNumber, Tool2.PartNumber);

							if (rc == 0)
								{
								rc = Tool1.Description.CompareTo(Tool2.Description);

								if (rc == 0)
									{
									rc = cDataFiles.ComparePartNumbers(Tool1.SerialNumber, Tool2.SerialNumber);

									if (rc == 0)
										rc = Tool1.Source.CompareTo(Tool2.Source);
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
		// CompareTool()
		//============================================================================*

		public int CompareTool(cTool Tool1, cTool Tool2)
			{
			int rc = Tool1.Manufacturer.CompareTo(Tool2.Manufacturer);

			if (rc == 0)
				{
				rc = cDataFiles.ComparePartNumbers(Tool1.PartNumber, Tool2.PartNumber);

				if (rc == 0)
					{
					rc = Tool1.Description.CompareTo(Tool2.Description);

					if (rc == 0)
						rc = cDataFiles.ComparePartNumbers(Tool1.SerialNumber, Tool2.SerialNumber);
					}
				}

			return (rc);
			}
		}
	}
