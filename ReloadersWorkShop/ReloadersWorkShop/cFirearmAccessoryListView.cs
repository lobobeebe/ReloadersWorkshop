//============================================================================*
// cFirearmAccessoryListView.cs
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
	// cFirearmAccessoryListView Class
	//============================================================================*

	public class cFirearmAccessoryListView : cListView
		{
		//============================================================================*
		// Private Data Members
		//============================================================================*

		private cDataFiles m_DataFiles = null;

		private cFirearm m_Firearm = null;

		private bool[] m_afFilters = new bool[(int) cGear.eGearTypes.NumGearTypes];

		private cListViewColumn[] m_arColumns = new cListViewColumn[]
			{
			new cListViewColumn(0, "ManufacturerHeader","Manufacturer", HorizontalAlignment.Left, 200),
			new cListViewColumn(1, "PartHeader", "Part Number", HorizontalAlignment.Left, 100),
			new cListViewColumn(2, "SerialHeader", "Serial #", HorizontalAlignment.Left, 100),
			new cListViewColumn(3, "DecriptionHeader", "Description", HorizontalAlignment.Left, 200),
			new cListViewColumn(4, "FirearmHeader", "Firearm", HorizontalAlignment.Left, 200),
			new cListViewColumn(5, "SourceHeader", "Acquired from", HorizontalAlignment.Left, 200),
			new cListViewColumn(6, "DateHeader", "Date", HorizontalAlignment.Center, 100),
			new cListViewColumn(7, "PriceHeader", "Price", HorizontalAlignment.Right, 80),
			new cListViewColumn(8, "TaxHeader", "Tax", HorizontalAlignment.Right, 80),
			new cListViewColumn(9, "ShippingHeader", "Shipping", HorizontalAlignment.Right, 80),
			new cListViewColumn(10, "TotalHeader", "Total", HorizontalAlignment.Right, 80)
			};

		//============================================================================*
		// cFirearmAccessoryListView() - Constructor
		//============================================================================*

		public cFirearmAccessoryListView(cDataFiles DataFiles)
			: base(DataFiles, cPreferences.eApplicationListView.FirearmAccessoriesListView)
			{
			m_DataFiles = DataFiles;

			//----------------------------------------------------------------------------*
			// Set Properties
			//----------------------------------------------------------------------------*

			SetColumns();

			for (int i = 0; i < (int) cGear.eGearTypes.NumGearTypes; i++)
				m_afFilters[i] = true;

			//----------------------------------------------------------------------------*
			// Event Handlers
			//----------------------------------------------------------------------------*

			//----------------------------------------------------------------------------*
			// Populate Columns and Groups
			//----------------------------------------------------------------------------*

			PopulateGroups();

			SortingOrder = m_DataFiles.Preferences.FirearmSortOrder;  // TODO: Make an accessory sort order

			SortingColumn = m_DataFiles.Preferences.FirearmSortColumn;

			ListViewItemSorter = new cListViewFirearmAccessoryComparer(SortingColumn, SortingOrder);

			Populate();

			Initialized = true;
			}

		//============================================================================*
		// AddFirearmAccessory()
		//============================================================================*

		public ListViewItem AddFirearmAccessory(cGear Gear, bool fSelect = true)
			{
			//----------------------------------------------------------------------------*
			// Verify that the accessory should be added to the list
			//----------------------------------------------------------------------------*

			if (!VerifyFirearmAccessory(Gear))
				return (null);

			//----------------------------------------------------------------------------*
			// Create the ListViewItem
			//----------------------------------------------------------------------------*

			ListViewItem Item = new ListViewItem();

			SetFirearmAccessoryData(Item, Gear);

			//----------------------------------------------------------------------------*
			// Add the item to the list and exit
			//----------------------------------------------------------------------------*

			AddItem(Item, fSelect);

			return (Item);
			}

		//============================================================================*
		// Filter()
		//============================================================================*

		public void Filter(cGear.eGearTypes eType, bool fShow = true)
			{
			m_afFilters[(int) eType] = fShow;

			Populate();
			}

		//============================================================================*
		// Firearm Property
		//============================================================================*

		public cFirearm Firearm
			{
			get
				{
				return (m_Firearm);
				}
			set
				{
				if (value == null)
					{
					if (m_Firearm != null)
						{
						m_Firearm = value;

						Populate();
						}
					}
				else
					{
					if (value.CompareTo(m_Firearm) != 0)
						{
						m_Firearm = value;

						Populate();
						}
					}
				}
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

				ListViewItemSorter = new cListViewFirearmAccessoryComparer(SortingColumn, SortingOrder);
				}
			else
				{
				SortingColumn = args.Column;

				this.Invalidate(true);

				ListViewItemSorter = new cListViewFirearmAccessoryComparer(SortingColumn, SortingOrder);
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

			foreach (cGear Gear in m_DataFiles.GearList)
				{
				ListViewItem Item = AddFirearmAccessory(Gear);

				if (Item != null && m_DataFiles.Preferences.LastFirearmAccessorySelected != null && m_DataFiles.Preferences.LastFirearmAccessorySelected.CompareTo(Gear) == 0)
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

					m_DataFiles.Preferences.LastFirearmAccessorySelected = (cGear) Items[0].Tag;
					}
				}

			if (SelectedItems.Count > 0)
				SelectedItems[0].EnsureVisible();

			Populating = false;
			}

		//============================================================================*
		// PopulateGroups()
		//============================================================================*

		protected override void PopulateGroups()
			{
			Groups.Clear();

			ListViewGroup Group = new ListViewGroup("ScopeGroup", cGear.GearTypeString(cGear.eGearTypes.Scope));

			Groups.Add(Group);

			Group = new ListViewGroup("LaserGroup", cGear.GearTypeString(cGear.eGearTypes.Laser));

			Groups.Add(Group);

			Group = new ListViewGroup("RedDotGroup", cGear.GearTypeString(cGear.eGearTypes.RedDot));

			Groups.Add(Group);

			Group = new ListViewGroup("MagnifierGroup", cGear.GearTypeString(cGear.eGearTypes.Magnifier));

			Groups.Add(Group);

			Group = new ListViewGroup("LightGroup", cGear.GearTypeString(cGear.eGearTypes.Light));

			Groups.Add(Group);

			Group = new ListViewGroup("TriggerGroup", cGear.GearTypeString(cGear.eGearTypes.Trigger));

			Groups.Add(Group);

			Group = new ListViewGroup("FurnitureGroup", cGear.GearTypeString(cGear.eGearTypes.Furniture));

			Groups.Add(Group);

			Group = new ListViewGroup("BipodGroup", cGear.GearTypeString(cGear.eGearTypes.Bipod));

			Groups.Add(Group);

			Group = new ListViewGroup("PartsGroup", cGear.GearTypeString(cGear.eGearTypes.Parts));

			Groups.Add(Group);

			Group = new ListViewGroup("OtherGroup", cGear.GearTypeString(cGear.eGearTypes.Misc));

			Groups.Add(Group);
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
		// SetFirearmAccessoryData()
		//============================================================================*

		public void SetFirearmAccessoryData(ListViewItem Item, cGear Gear)
			{
			Item.SubItems.Clear();

			Item.Text = Gear.Manufacturer.ToString();

			Item.Group = Groups[(int) Gear.GearType];
			Item.Tag = Gear;

			Item.SubItems.Add(String.Format("{0}", Gear.PartNumber));
			Item.SubItems.Add(String.Format("{0}", Gear.SerialNumber));
			Item.SubItems.Add(String.Format("{0}", Gear.Description));

			Item.SubItems.Add(Gear.Parent != null ? String.Format("{0}", Gear.Parent.ToString()) : "");

			Item.SubItems.Add(String.Format("{0}", Gear.Source));
			Item.SubItems.Add(!String.IsNullOrEmpty(Gear.Source) ? String.Format("{0}", Gear.PurchaseDate.ToShortDateString()) : "");
			Item.SubItems.Add(!String.IsNullOrEmpty(Gear.Source) && Gear.PurchasePrice > 0.0 ? String.Format("{0:F2}", Gear.PurchasePrice) : "-");
			Item.SubItems.Add(!String.IsNullOrEmpty(Gear.Source) && Gear.Tax > 0.0 ? String.Format("{0:F2}", Gear.Tax) : "-");
			Item.SubItems.Add(!String.IsNullOrEmpty(Gear.Source) && Gear.Shipping > 0.0 ? String.Format("{0:F2}", Gear.Shipping) : "-");

			double dTotal = Gear.PurchasePrice + Gear.Tax + Gear.Shipping;

			Item.SubItems.Add(!String.IsNullOrEmpty(Gear.Source) && dTotal != 0.0 ? String.Format("{0:F2}", dTotal) : "-");
			}

		//============================================================================*
		// UpdateFirearmAccessory()
		//============================================================================*

		public ListViewItem UpdateFirearmAccessory(cGear Gear, bool fSelect = false)
			{
			//----------------------------------------------------------------------------*
			// Find the Item
			//----------------------------------------------------------------------------*

			ListViewItem Item = null;

			foreach (ListViewItem CheckItem in Items)
				{
				if ((CheckItem.Tag as cGear).CompareTo(Gear) == 0)
					{
					Item = CheckItem;

					break;
					}
				}

			//----------------------------------------------------------------------------*
			// If the item was not found, add it
			//----------------------------------------------------------------------------*

			if (Item == null)
				return (AddFirearmAccessory(Gear, fSelect));

			//----------------------------------------------------------------------------*
			// Otherwise, update the Item Data
			//----------------------------------------------------------------------------*

			SetFirearmAccessoryData(Item, Gear);

			if (fSelect)
				{
				Item.Selected = fSelect;

				Item.EnsureVisible();
				}

			return (Item);
			}

		//============================================================================*
		// VerifyFirearmAccessory()
		//============================================================================*

		public bool VerifyFirearmAccessory(cGear Gear)
			{
			//----------------------------------------------------------------------------*
			// Check Filters
			//----------------------------------------------------------------------------*

			if (!m_afFilters[(int) Gear.GearType])
				return (false);

			//----------------------------------------------------------------------------*
			// If firearm  is null, it's good to go
			//----------------------------------------------------------------------------*

			if (m_Firearm == null)
				return (true);

			//----------------------------------------------------------------------------*
			// Otherwise, only  gear  for the specified firearm is ok
			//----------------------------------------------------------------------------*

			cFirearm Firearm = (cFirearm) Gear.Parent;

			if (Firearm == null || Firearm.CompareTo(m_Firearm) != 0)
				return (false);

			return (true);
			}
		}
	}
