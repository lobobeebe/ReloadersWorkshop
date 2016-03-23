//============================================================================*
// cManufacturerListView.cs
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
	// cManufacturerListView Class
	//============================================================================*

	public class cManufacturerListView : cListView
		{
		//============================================================================*
		// Private Data Members
		//============================================================================*

		private cDataFiles m_DataFiles = null;

		private cListViewColumn[] m_arColumns = new cListViewColumn[]
			{
			new cListViewColumn(0, "NameHeader","Name", HorizontalAlignment.Left, 140),
			new cListViewColumn(1, "WebsiteHeader", "Website", HorizontalAlignment.Left, 160),
			new cListViewColumn(2, "HeadStampHeader", "Headstamp", HorizontalAlignment.Left, 100),
			new cListViewColumn(3, "AmmoHeader", "Ammo", HorizontalAlignment.Center, 70),
			new cListViewColumn(4, "BulletsHeader", "Bullets", HorizontalAlignment.Center, 70),
			new cListViewColumn(5, "PowderHeader", "Powder", HorizontalAlignment.Center, 70),
			new cListViewColumn(6, "PrimersHeader", "Primers", HorizontalAlignment.Center, 70),
			new cListViewColumn(7, "CasesHeader", "Cases", HorizontalAlignment.Center, 70),
			new cListViewColumn(8, "BulletMoldsHeader", "BulletMolds", HorizontalAlignment.Center, 70),

			new cListViewColumn(9, "HandgunsHeader", "Handguns", HorizontalAlignment.Center, 70),
			new cListViewColumn(10, "RiflesHeader", "Rifles", HorizontalAlignment.Center, 70),
			new cListViewColumn(11, "ShotgunsHeader", "Shotguns", HorizontalAlignment.Center, 70),

			new cListViewColumn(12, "ScopesHeader", "Scopes", HorizontalAlignment.Center, 70),
			new cListViewColumn(13, "TriggersHeader", "Triggers", HorizontalAlignment.Center, 70),
			new cListViewColumn(14, "StocksHeader", "Stocks/Grips", HorizontalAlignment.Center, 70)
			};

		//============================================================================*
		// cManufacturerListView() - Constructor
		//============================================================================*

		public cManufacturerListView(cDataFiles DataFiles)
			: base(DataFiles, cPreferences.eApplicationListView.ManufacturersListView)
			{
			m_DataFiles = DataFiles;

			//----------------------------------------------------------------------------*
			// Set Properties
			//----------------------------------------------------------------------------*

			GridLines = true;

			//----------------------------------------------------------------------------*
			// Event Handlers
			//----------------------------------------------------------------------------*

			//----------------------------------------------------------------------------*
			// Populate Columns and Data
			//----------------------------------------------------------------------------*

			PopulateColumns(m_arColumns);

			SortingOrder = m_DataFiles.Preferences.ManufacturerSortOrder;

			SortingColumn = m_DataFiles.Preferences.ManufacturerSortColumn;

			ListViewItemSorter = new cListViewManufacturerComparer(SortingColumn, SortingOrder);

			Populate();

			Initialized = true;
			}

		//============================================================================*
		// AddManufacturer()
		//============================================================================*

		public ListViewItem AddManufacturer(cManufacturer Manufacturer, bool fSelect = false)
			{
			//----------------------------------------------------------------------------*
			// Verify that the manufacturer should be added to the list
			//----------------------------------------------------------------------------*

			if (!VerifyManufacturer(Manufacturer))
				return(null);

			//----------------------------------------------------------------------------*
			// Create the Item
			//----------------------------------------------------------------------------*

			ListViewItem Item = new ListViewItem();

			SetManufacturerData(Item, Manufacturer);

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

				m_DataFiles.Preferences.ManufacturerSortOrder = SortingOrder;

				ListViewItemSorter = new cListViewManufacturerComparer(SortingColumn, SortingOrder);
				}
			else
				{
				SortingColumn = args.Column;

				this.Invalidate(true);

				ListViewItemSorter = new cListViewManufacturerComparer(SortingColumn, SortingOrder);
				}

			if (SelectedItems.Count > 0)
				SelectedItems[0].EnsureVisible();

			m_DataFiles.Preferences.ManufacturerSortColumn = args.Column;
			}

		//============================================================================*
		// Populate()
		//============================================================================*

		public override void Populate()
			{
			Populating = true;

			//----------------------------------------------------------------------------*
			// ManufacturerListView Items
			//----------------------------------------------------------------------------*

			Items.Clear();

			ListViewItem SelectItem = null;

			foreach (cManufacturer Manufacturer in DataFiles.ManufacturerList)
				{
				if (Manufacturer.Name == "Batch Editor")
					continue;

				ListViewItem Item = AddManufacturer(Manufacturer);

				if (DataFiles.Preferences.LastManufacturerSelected != null && DataFiles.Preferences.LastManufacturerSelected.CompareTo(Manufacturer) == 0)
					SelectItem = Item;
				}

			if (SelectItem != null)
				{
				Focus();

				SelectItem.Selected = true;

				SelectItem.EnsureVisible();
				}

			Populating = false;
			}

		//============================================================================*
		// SetManufacturerData()
		//============================================================================*

		public void SetManufacturerData(ListViewItem Item, cManufacturer Manufacturer)
			{
			Item.SubItems.Clear();

			Item.Text = Manufacturer.Name;

			Item.Tag = Manufacturer;

			Item.SubItems.Add(Manufacturer.Website);
			Item.SubItems.Add(Manufacturer.Cases ? Manufacturer.HeadStamp : "-");
			Item.SubItems.Add((Manufacturer.Ammo ? "Y" : ""));
			Item.SubItems.Add((Manufacturer.Bullets ? "Y" : ""));
			Item.SubItems.Add((Manufacturer.Powder ? "Y" : ""));
			Item.SubItems.Add((Manufacturer.Primers ? "Y" : ""));
			Item.SubItems.Add((Manufacturer.Cases ? "Y" : ""));
			Item.SubItems.Add((Manufacturer.BulletMolds ? "Y" : ""));

			Item.SubItems.Add((Manufacturer.Handguns ? "Y" : ""));
			Item.SubItems.Add((Manufacturer.Rifles ? "Y" : ""));
			Item.SubItems.Add((Manufacturer.Shotguns ? "Y" : ""));

			Item.SubItems.Add((Manufacturer.Scopes ? "Y" : ""));
			Item.SubItems.Add((Manufacturer.Triggers ? "Y" : ""));
			Item.SubItems.Add((Manufacturer.Stocks ? "Y" : ""));
			}

		//============================================================================*
		// UpdateManufacturer()
		//============================================================================*

		public ListViewItem UpdateManufacturer(cManufacturer OldManufacturer, cManufacturer Manufacturer, bool fSelect = false)
			{
			//----------------------------------------------------------------------------*
			// Find the Item
			//----------------------------------------------------------------------------*

			ListViewItem Item = null;

			foreach (ListViewItem CheckItem in Items)
				{
				if ((CheckItem.Tag as cManufacturer).CompareTo(OldManufacturer) == 0)
					{
					Item = CheckItem;

					break;
					}
				}

			//----------------------------------------------------------------------------*
			// If the item was not found, add it
			//----------------------------------------------------------------------------*

			if (Item == null)
				return (AddManufacturer(Manufacturer, fSelect));

			//----------------------------------------------------------------------------*
			// Otherwise, update the Item Data
			//----------------------------------------------------------------------------*

			SetManufacturerData(Item, Manufacturer);

			Item.Selected = fSelect;

			Focus();

			return (Item);
			}

		//============================================================================*
		// VerifyManufacturer()
		//============================================================================*

		public bool VerifyManufacturer(cManufacturer Manufacturer)
			{
			return(true);
			}

		//============================================================================*
		// WebsiteVisited()
		//============================================================================*

		protected override void WebsiteVisited(ListViewItem Item)
			{
			if  (Item.Tag is cManufacturer)
				{
				(Item.Tag as cManufacturer).WebSiteVisited = true;
				}
			}
		}
	}
