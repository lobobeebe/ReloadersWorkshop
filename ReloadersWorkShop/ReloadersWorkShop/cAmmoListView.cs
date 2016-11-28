//============================================================================*
// cAmmoListView.cs
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
	// cAmmoListView Class
	//============================================================================*

	public class cAmmoListView : cListView
		{
		//============================================================================*
		// Private Data Members
		//============================================================================*

		private cDataFiles m_DataFiles = null;

		private string m_strDimensionFormat = "{0:F3}";
		private string m_strBulletWeightFormat = "{0:F1}";

		private cFirearm.eFireArmType m_eFirearmType = cFirearm.eFireArmType.None;
		private cCaliber m_Caliber = null;
		private cManufacturer m_Manufacturer = null;

		private cListViewColumn[] m_arColumns = new cListViewColumn[]
			{
			new cListViewColumn(0, "ManufacturerHeader","Manufacturer", HorizontalAlignment.Left, 140),
			new cListViewColumn(1, "PartNumHeader", "Part Number", HorizontalAlignment.Left, 140),
			new cListViewColumn(2, "TypeHeader", "Model/Type", HorizontalAlignment.Left, 160),
			new cListViewColumn(3, "ReloadHeader", "Reloads?", HorizontalAlignment.Center, 100),
			new cListViewColumn(4, "TestDataHeader", "Test Data?", HorizontalAlignment.Center, 100),
			new cListViewColumn(5, "CaliberHeader", "Caliber", HorizontalAlignment.Left, 160),
			new cListViewColumn(6, "BulletWeightHeader", "Bullet Weight", HorizontalAlignment.Center, 115),
			new cListViewColumn(7, "BulletDiameterHeader", "Bullet Diameter", HorizontalAlignment.Center, 115),
			new cListViewColumn(8, "BCHeader", "B.C.", HorizontalAlignment.Center, 80),
			new cListViewColumn(9, "SDHeader", "S.D.", HorizontalAlignment.Center, 80),
			new cListViewColumn(10, "MinStockHeader", "Min Stock Lvl", HorizontalAlignment.Center, 80),
			new cListViewColumn(11, "QuantityHeader", "Box of", HorizontalAlignment.Center, 80),
			new cListViewColumn(12, "CostHeader", "Costs", HorizontalAlignment.Right, 80),
			};

		//============================================================================*
		// cAmmoListView() - Constructor
		//============================================================================*

		public cAmmoListView(cDataFiles DataFiles)
			: base(DataFiles, cPreferences.eApplicationListView.AmmoListView)
			{
			m_DataFiles = DataFiles;

			//----------------------------------------------------------------------------*
			// Set Properties
			//----------------------------------------------------------------------------*

			CheckBoxes = true;

			//----------------------------------------------------------------------------*
			// Event Handlers
			//----------------------------------------------------------------------------*

			//----------------------------------------------------------------------------*
			// Populate Columns and Groups
			//----------------------------------------------------------------------------*

			PopulateGroups();
			PopulateColumns(m_arColumns);

			SortingOrder = m_DataFiles.Preferences.AmmoSortOrder;

			SortingColumn = m_DataFiles.Preferences.AmmoSortColumn;

			ListViewItemSorter = new cListViewAmmoComparer(SortingColumn, SortingOrder);

			Populate();

			Initialized = true;
			}

		//============================================================================*
		// AddAmmo()
		//============================================================================*

		public ListViewItem AddAmmo(cAmmo Ammo, bool fSelect = false)
			{
			//----------------------------------------------------------------------------*
			// Verify that the firearm should be added to the list
			//----------------------------------------------------------------------------*

			if (!VerifyAmmo(Ammo))
				return (null);

			//----------------------------------------------------------------------------*
			// Create the ListViewItem
			//----------------------------------------------------------------------------*

			ListViewItem Item = new ListViewItem();

			SetAmmoData(Item, Ammo);

			//----------------------------------------------------------------------------*
			// Add the item to the list and exit
			//----------------------------------------------------------------------------*

			AddItem(Item, fSelect);

			return (Item);
			}

		//============================================================================*
		// Caliber Property
		//============================================================================*

		public cCaliber Caliber
			{
			get
				{
				return (m_Caliber);
				}
			set
				{
				m_Caliber = value;
				}
			}

		//============================================================================*
		// FirearmType Property
		//============================================================================*

		public cFirearm.eFireArmType FirearmType
			{
			get
				{
				return (m_eFirearmType);
				}
			set
				{
				m_eFirearmType = value;
				}
			}

		//============================================================================*
		// Manufacturer Property
		//============================================================================*

		public cManufacturer Manufacturer
			{
			get
				{
				return (m_Manufacturer);
				}
			set
				{
				m_Manufacturer = value;
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

				m_DataFiles.Preferences.AmmoSortOrder = SortingOrder;

				ListViewItemSorter = new cListViewAmmoComparer(SortingColumn, SortingOrder);
				}
			else
				{
				SortingColumn = args.Column;

				this.Invalidate(true);

				ListViewItemSorter = new cListViewAmmoComparer(SortingColumn, SortingOrder);
				}

			if (SelectedItems.Count > 0)
				SelectedItems[0].EnsureVisible();

			m_DataFiles.Preferences.AmmoSortColumn = args.Column;
			}

		//============================================================================*
		// Populate()
		//============================================================================*

		public override void Populate()
			{
			Populating = true;

			//----------------------------------------------------------------------------*
			// Create the format strings
			//----------------------------------------------------------------------------*

			m_strDimensionFormat = "{0:F";
			m_strDimensionFormat += String.Format("{0:G0}", m_DataFiles.Preferences.DimensionDecimals);
			m_strDimensionFormat += "}";

			m_strBulletWeightFormat = "{0:F";
			m_strBulletWeightFormat += String.Format("{0:G0}", m_DataFiles.Preferences.BulletWeightDecimals);
			m_strBulletWeightFormat += "}";

			//----------------------------------------------------------------------------*
			// AmmoListView Items
			//----------------------------------------------------------------------------*

			Items.Clear();

			ListViewItem SelectItem = null;

			foreach (cAmmo Ammo in m_DataFiles.AmmoList)
				{
				ListViewItem Item = AddAmmo(Ammo);

				if (Item != null && m_DataFiles.Preferences.LastAmmoSelected != null && m_DataFiles.Preferences.LastAmmoSelected.CompareTo(Ammo) == 0)
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

					m_DataFiles.Preferences.LastAmmoSelected = (cAmmo)Items[0].Tag;
					}
				}

			if (SelectedItems.Count > 0)
				SelectedItems[0].EnsureVisible();

			Populating = false;
			}

		//============================================================================*
		// PopulateColumns()
		//============================================================================*

		public void PopulateColumns()
			{
			PopulateColumns(m_arColumns);
			}

		//============================================================================*
		// PopulateColumns()
		//============================================================================*

		protected override void PopulateColumns(cListViewColumn[] arColumns)
			{
			base.PopulateColumns(arColumns);

			Columns[6].Text += String.Format(" ({0})", cDataFiles.MetricString(cDataFiles.eDataType.BulletWeight));
			Columns[7].Text += String.Format(" ({0})", cDataFiles.MetricString(cDataFiles.eDataType.Dimension));

			if (m_DataFiles.Preferences.TrackInventory)
				{
				Columns[11].Text = "Qty on Hand";
				Columns[12].Text = String.Format("Value ({0})", m_DataFiles.Preferences.Currency);
				}
			else
				{
				Columns[11].Text = "Box of";
				Columns[12].Text = String.Format("Costs ({0})", m_DataFiles.Preferences.Currency);
				}
			}

		//============================================================================*
		// SetAmmoData()
		//============================================================================*

		public void SetAmmoData(ListViewItem Item, cAmmo Ammo)
			{
			Item.SubItems.Clear();

			Item.Text = Ammo.Manufacturer != null ? Ammo.Manufacturer.ToString() : "Reloads";

			Item.Group = Groups[(int)Ammo.FirearmType];
			Item.Tag = Ammo;

			Item.SubItems.Add(Ammo.PartNumber);
			Item.SubItems.Add(Ammo.Type);
			Item.SubItems.Add(Ammo.Reload ? "Y" : "");
			Item.SubItems.Add(Ammo.TestList.Count > 0 ? "Y" : "");
			Item.SubItems.Add(Ammo.Caliber.ToString());
			Item.SubItems.Add(String.Format(m_strBulletWeightFormat, cDataFiles.StandardToMetric(Ammo.BulletWeight, cDataFiles.eDataType.BulletWeight)));
			Item.SubItems.Add(String.Format(m_strDimensionFormat, cDataFiles.StandardToMetric(Ammo.BulletDiameter, cDataFiles.eDataType.Dimension)));
			Item.SubItems.Add(Ammo.BallisticCoefficient > 0.0 ? String.Format("{0:F3}", Ammo.BallisticCoefficient) : "-");
			Item.SubItems.Add(String.Format("{0:F3}", cBullet.CalculateSectionalDensity(Ammo.BulletDiameter, Ammo.BulletWeight)));

			Item.SubItems.Add(Ammo.MinimumStockLevel != 0 ? String.Format("{0:N0}", Ammo.MinimumStockLevel) : "-");

			double dCost = 0.0;

			if (m_DataFiles.Preferences.TrackInventory)
				{
				Item.SubItems.Add(Ammo.QuantityOnHand != 0.0 ? String.Format("{0:N0}", Ammo.QuantityOnHand) : "-");

				dCost = Ammo.QuantityOnHand * m_DataFiles.SupplyCostEach(Ammo);
				}
			else
				{
				Item.SubItems.Add(String.Format("{0:N0}", Ammo.Quantity));

				dCost = Ammo.Cost;
				}

			Item.SubItems.Add(dCost != 0.0 ? String.Format("{0:F2}", dCost) : "-");
			}

		//============================================================================*
		// UpdateAmmo()
		//============================================================================*

		public ListViewItem UpdateAmmo(cAmmo Ammo, bool fSelect = false)
			{
			//----------------------------------------------------------------------------*
			// Find the Item
			//----------------------------------------------------------------------------*

			ListViewItem Item = null;

			foreach (ListViewItem CheckItem in Items)
				{
				if ((CheckItem.Tag as cAmmo).CompareTo(Ammo) == 0)
					{
					Item = CheckItem;

					break;
					}
				}

			//----------------------------------------------------------------------------*
			// If the item was not found, add it
			//----------------------------------------------------------------------------*

			if (Item == null)
				return (AddAmmo(Ammo, fSelect));

			//----------------------------------------------------------------------------*
			// Otherwise, update the Item Data
			//----------------------------------------------------------------------------*

			SetAmmoData(Item, Ammo);

			Item.Selected = fSelect;

			Focus();

			return (Item);
			}

		//============================================================================*
		// VerifyAmmo()
		//============================================================================*

		public bool VerifyAmmo(cAmmo Ammo)
			{
			//----------------------------------------------------------------------------*
			// Make sure we're tracking reloads if this is a reload
			//----------------------------------------------------------------------------*


			//----------------------------------------------------------------------------*
			// Check the internal filters
			//----------------------------------------------------------------------------*

			if (m_eFirearmType != cFirearm.eFireArmType.None && Ammo.FirearmType != m_eFirearmType)
				return (false);

			if (m_Caliber != null && m_Caliber.CompareTo(Ammo.Caliber) != 0)
				return (false);

			if (m_Manufacturer != null && m_Manufacturer.CompareTo(Ammo.Manufacturer) != 0)
				return (false);

			//----------------------------------------------------------------------------*
			// Check the external filters
			//----------------------------------------------------------------------------*

			if (Ammo.Reload)
				{
				if (Ammo.BatchID != 0)
					{
					if (!m_DataFiles.Preferences.AmmoMyReloadFilter)
						return (false);
					}
				else
					{
					if (!m_DataFiles.Preferences.AmmoFactoryReloadFilter)
						return (false);
					}
				}
			else
				{
				if (!m_DataFiles.Preferences.AmmoFactoryFilter)
					return (false);
				}

			//----------------------------------------------------------------------------*
			// Check the inventory control filters
			//----------------------------------------------------------------------------*

			if (m_DataFiles.Preferences.TrackInventory)
				{
				if (!m_DataFiles.Preferences.TrackReloads && Ammo.Reload && Ammo.BatchID != 0)
					return (false);

				if (Ammo.QuantityOnHand <= 0.0 && m_DataFiles.Preferences.AmmoNonZeroFilter)
					return (false);

				if (Ammo.QuantityOnHand >= Ammo.MinimumStockLevel && m_DataFiles.Preferences.AmmoMinStockFilter)
					return (false);
				}

			return (true);
			}
		}
	}
