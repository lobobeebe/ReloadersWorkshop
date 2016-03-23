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
			new cListViewColumn(3, "CaliberHeader", "Primary Caliber", HorizontalAlignment.Left, 160),
			new cListViewColumn(4, "BarrelLengthHeader", "Barrel Length", HorizontalAlignment.Center, 115),
			new cListViewColumn(5, "TwistHeader", "Twist", HorizontalAlignment.Center, 115),
			new cListViewColumn(6, "ScopedHeader", "Scoped", HorizontalAlignment.Center, 60),
			new cListViewColumn(7, "TurretClickHeader", "Turret Click", HorizontalAlignment.Center, 120),
			new cListViewColumn(8, "ZeroRangeHeader", "Zero Range", HorizontalAlignment.Center, 115),
			new cListViewColumn(9, "SightHeightHeader", "Sight Height", HorizontalAlignment.Center, 115),
			new cListViewColumn(10, "HeadspaceHeader", "Headspace", HorizontalAlignment.Center, 115),
			new cListViewColumn(11, "NeckSizeHeader", "Neck Size", HorizontalAlignment.Center, 115)
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
			m_arColumns[4].Text = String.Format("Barrel Length ({0})", m_DataFiles.MetricString(cDataFiles.eDataType.Firearm));
			m_arColumns[8].Text = String.Format("Zero Range ({0})", m_DataFiles.MetricString(cDataFiles.eDataType.Range));
			m_arColumns[9].Text = String.Format("Sight Height ({0})", m_DataFiles.MetricString(cDataFiles.eDataType.Firearm));
			m_arColumns[10].Text = String.Format("Headspace ({0})", m_DataFiles.MetricString(cDataFiles.eDataType.Dimension));
			m_arColumns[11].Text = String.Format("Neck Size ({0})", m_DataFiles.MetricString(cDataFiles.eDataType.Dimension));

			PopulateColumns(m_arColumns);
			}

		//============================================================================*
		// SetFirearmData()
		//============================================================================*

		public void SetFirearmData(ListViewItem Item, cFirearm Firearm)
			{
			Item.SubItems.Clear();

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

			Item.SubItems.Add(String.Format("{0}", Firearm.Model));
			Item.SubItems.Add(String.Format("{0}", Firearm.SerialNumber));
			Item.SubItems.Add(String.Format("{0}", Firearm.PrimaryCaliber));
			Item.SubItems.Add(String.Format(strLengthFormat, m_DataFiles.StandardToMetric(Firearm.BarrelLength, cDataFiles.eDataType.Firearm)));
			Item.SubItems.Add(Firearm.Twist == 0.0 ? "N/A" : String.Format(strTwistFormat, m_DataFiles.StandardToMetric(Firearm.Twist, cDataFiles.eDataType.Firearm), m_DataFiles.MetricString(cDataFiles.eDataType.Firearm)));
			Item.SubItems.Add(Firearm.Scoped ? "Y" : "");
			Item.SubItems.Add(Firearm.TurretClickString);
			Item.SubItems.Add(String.Format("{0:N0}", m_DataFiles.StandardToMetric(Firearm.ZeroRange, cDataFiles.eDataType.Range)));
			Item.SubItems.Add(String.Format(strLengthFormat, m_DataFiles.StandardToMetric(Firearm.SightHeight, cDataFiles.eDataType.Firearm)));
			Item.SubItems.Add(Firearm.FirearmType == cFirearm.eFireArmType.Rifle ? String.Format(strDimensionFormat, m_DataFiles.StandardToMetric(Firearm.HeadSpace, cDataFiles.eDataType.Dimension)) : "-");
			Item.SubItems.Add(Firearm.FirearmType == cFirearm.eFireArmType.Rifle ? String.Format(strDimensionFormat, m_DataFiles.StandardToMetric(Firearm.Neck, cDataFiles.eDataType.Dimension)) : "-");
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
