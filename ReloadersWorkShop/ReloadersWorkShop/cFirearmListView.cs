//============================================================================*
// cFirearmListView.cs
//
// Copyright © 2013-2014, Kevin S. Beebe
// All Rights Reserved
//============================================================================*

//============================================================================*
// .Net Using Statements
//============================================================================*

using System;
using System.Windows.Forms;

using ReloadersWorkShop.Preferences;

//============================================================================*
// NameSpace
//============================================================================*

namespace ReloadersWorkShop
	{
	//============================================================================*
	// cFirearmListView Class
	//============================================================================*

	public class cFirearmListView : cListView
		{
		//============================================================================*
		// Private Data Members
		//============================================================================*

		private cDataFiles m_DataFiles = null;

		private cListViewColumn[] m_arColumns = new cListViewColumn[]
			{
			new cListViewColumn(0, "ManufacturerHeader","Manufacturer", HorizontalAlignment.Left, 140),
			new cListViewColumn(1, "ModelHeader", "Model", HorizontalAlignment.Left, 140),
			new cListViewColumn(2, "SerialHeader", "Serial #", HorizontalAlignment.Left, 140),
			new cListViewColumn(3, "DescriptionHeader", "Description", HorizontalAlignment.Left, 160),
			new cListViewColumn(4, "CaliberHeader", "Primary Caliber", HorizontalAlignment.Left, 160),
			new cListViewColumn(5, "SourceHeader", "Acquired from", HorizontalAlignment.Left, 200),
			new cListViewColumn(6, "DateHeader", "Date", HorizontalAlignment.Left, 100),
			new cListViewColumn(7, "PriceHeader", "Price", HorizontalAlignment.Right, 80),
			new cListViewColumn(8, "TaxHeader", "Tax", HorizontalAlignment.Right, 80),
			new cListViewColumn(9, "ShippingHeader", "Shipping", HorizontalAlignment.Right, 80),
			new cListViewColumn(10, "TotalHeader", "Total", HorizontalAlignment.Right, 80)
			};

		//============================================================================*
		// cFirearmListView() - Constructor
		//============================================================================*

		public cFirearmListView(cDataFiles DataFiles)
			: base(DataFiles, cPreferences.eApplicationListView.FirearmsListView)
			{
			m_DataFiles = DataFiles;

			//----------------------------------------------------------------------------*
			// Set Properties
			//----------------------------------------------------------------------------*

			SetColumns();

			CheckBoxes = true;

			//----------------------------------------------------------------------------*
			// Event Handlers
			//----------------------------------------------------------------------------*

			//----------------------------------------------------------------------------*
			// Populate Columns and Groups
			//----------------------------------------------------------------------------*

			PopulateGroups();

			SortingOrder = m_DataFiles.Preferences.FirearmSortOrder;

			SortingColumn = m_DataFiles.Preferences.FirearmSortColumn;

			ListViewItemSorter = new cListViewFirearmComparer(SortingColumn, SortingOrder);

			Populate();

			Initialized = true;
			}

		//============================================================================*
		// AddFirearm()
		//============================================================================*

		public ListViewItem AddFirearm(cFirearm Firearm, bool fSelect = false)
			{
			//----------------------------------------------------------------------------*
			// Verify that the firearm should be added to the list
			//----------------------------------------------------------------------------*

			if (!VerifyFirearm(Firearm))
				return (null);

			//----------------------------------------------------------------------------*
			// Create the ListViewItem
			//----------------------------------------------------------------------------*

			ListViewItem Item = new ListViewItem();

			SetFirearmData(Item, Firearm);

			//----------------------------------------------------------------------------*
			// Add the item to the list and exit
			//----------------------------------------------------------------------------*

			AddItem(Item, fSelect);

			return (Item);
			}

		//============================================================================*
		// OnColumnClick()
		//============================================================================*

		protected override void OnColumnClick(ColumnClickEventArgs args)
			{
			if (args.Column == SortingColumn)
				{
				SortingOrder = (SortingOrder == SortOrder.Ascending) ? SortOrder.Descending : SortOrder.Ascending;

				m_DataFiles.Preferences.FirearmSortOrder = SortingOrder;

				ListViewItemSorter = new cListViewFirearmComparer(SortingColumn, SortingOrder);
				}
			else
				{
				SortingColumn = args.Column;

				this.Invalidate(true);

				ListViewItemSorter = new cListViewFirearmComparer(SortingColumn, SortingOrder);
				}

			if (SelectedItems.Count > 0)
				SelectedItems[0].EnsureVisible();

			m_DataFiles.Preferences.FirearmSortColumn = args.Column;
			}

		//============================================================================*
		// Populate()
		//============================================================================*

		public override void Populate()
			{
			Populating = true;

			//----------------------------------------------------------------------------*
			// FirearmListView Items
			//----------------------------------------------------------------------------*

			Items.Clear();

			ListViewItem SelectItem = null;

			foreach (cFirearm Firearm in m_DataFiles.FirearmList)
				{
				ListViewItem Item = AddFirearm(Firearm);

				if (Item != null && m_DataFiles.Preferences.LastFirearmSelected != null && m_DataFiles.Preferences.LastFirearmSelected.CompareTo(Firearm) == 0)
					SelectItem = Item;
				}

			if (SelectItem != null)
				{
				SelectItem.Selected = true;
				}
			else
				{
				if (Items.Count > 0)
					{
					Items[0].Selected = true;

					m_DataFiles.Preferences.LastFirearmSelected = (cFirearm)Items[0].Tag;
					}
				}

			if (SelectedItems.Count > 0)
				SelectedItems[0].EnsureVisible();

			Populating = false;
			}

		//============================================================================*
		// SetColumns()
		//============================================================================*

		public void SetColumns()
			{
			m_arColumns[7].Text = String.Format("Price ({0})", m_DataFiles.Preferences.Currency);
			m_arColumns[8].Text = String.Format("Tax ({0})", m_DataFiles.Preferences.Currency);
			m_arColumns[9].Text = String.Format("Shipping ({0})", m_DataFiles.Preferences.Currency);
			m_arColumns[10].Text = String.Format("Total ({0})", m_DataFiles.Preferences.Currency);

			PopulateColumns(m_arColumns);
			}

		//============================================================================*
		// SetFirearmData()
		//============================================================================*

		public void SetFirearmData(ListViewItem Item, cFirearm Firearm)
			{
			Item.SubItems.Clear();

			cCaliber.CurrentFirearmType = Firearm.FirearmType;

			Item.Text = Firearm.Manufacturer.ToString();

			Item.Group = Groups[(int)Firearm.FirearmType];
			Item.Tag = Firearm;

			Item.Checked = Firearm.Checked;

			string strLengthFormat = "{0:F";
			strLengthFormat += String.Format("{0:G0}", m_DataFiles.Preferences.FirearmDecimals);
			strLengthFormat += "}";

			string strDimensionFormat = "{0:F";
			strDimensionFormat += String.Format("{0:G0}", m_DataFiles.Preferences.DimensionDecimals);
			strDimensionFormat += "}";

			string strTwistFormat = "1 in {0:F";
			strTwistFormat += String.Format("{0:G0}", m_DataFiles.Preferences.FirearmDecimals);
			strTwistFormat += "} {1}";

			Item.SubItems.Add(String.Format("{0}", Firearm.PartNumber));
			Item.SubItems.Add(String.Format("{0}", Firearm.SerialNumber));
			Item.SubItems.Add(String.Format("{0}", Firearm.Description));
			Item.SubItems.Add(String.Format("{0}", Firearm.PrimaryCaliber));
			Item.SubItems.Add(String.Format("{0}", Firearm.Source));
			Item.SubItems.Add(!String.IsNullOrEmpty(Firearm.Source) ? String.Format("{0}", Firearm.PurchaseDate.ToShortDateString()) : "");
			Item.SubItems.Add(!String.IsNullOrEmpty(Firearm.Source) && Firearm.PurchasePrice !=  0.0 ? String.Format("{0:F2}", Firearm.PurchasePrice) : "-");
			Item.SubItems.Add(!String.IsNullOrEmpty(Firearm.Source) && Firearm.Tax != 0.0 ? String.Format("{0:F2}", Firearm.Tax) : "-");
			Item.SubItems.Add(!String.IsNullOrEmpty(Firearm.Source) && Firearm.Shipping != 0.0 ? String.Format("{0:F2}", Firearm.Shipping) : "-");

			double dTotal = Firearm.PurchasePrice + Firearm.Tax + Firearm.Shipping;

			Item.SubItems.Add(!String.IsNullOrEmpty(Firearm.Source) && dTotal != 0.0 ? String.Format("{0:F2}", dTotal) : "-");
			}

		//============================================================================*
		// UpdateFirearm()
		//============================================================================*

		public ListViewItem UpdateFirearm(cFirearm Firearm, bool fSelect = false)
			{
			//----------------------------------------------------------------------------*
			// Find the Item
			//----------------------------------------------------------------------------*

			ListViewItem Item = null;

			foreach (ListViewItem CheckItem in Items)
				{
				if ((CheckItem.Tag as cFirearm).CompareTo(Firearm) == 0)
					{
					Item = CheckItem;

					break;
					}
				}

			//----------------------------------------------------------------------------*
			// If the item was not found, add it
			//----------------------------------------------------------------------------*

			if (Item == null)
				return (AddFirearm(Firearm, fSelect));

			//----------------------------------------------------------------------------*
			// Otherwise, update the Item Data
			//----------------------------------------------------------------------------*

			SetFirearmData(Item, Firearm);

			if (fSelect)
				{
				Item.Selected = fSelect;

				Item.EnsureVisible();
				}

			Focus();

			return (Item);
			}

		//============================================================================*
		// VerifyFirearm()
		//============================================================================*

		public bool VerifyFirearm(cFirearm Firearm)
			{
			//----------------------------------------------------------------------------*
			// In this version, all firearms are verified OK
			//----------------------------------------------------------------------------*

			return (true);
			}
		}
	}
