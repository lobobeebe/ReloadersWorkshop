//============================================================================*
// cToolListView.cs
//
// Copyright © 2013-2017, Kevin S. Beebe
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
	// cToolListView Class
	//============================================================================*

	public class cToolListView : cListView
		{
		//============================================================================*
		// Private Data Members
		//============================================================================*

		private cDataFiles m_DataFiles = null;

		private bool[] m_afFilters = new bool[(int)cTool.eToolTypes.NumToolTypes];

		private cListViewColumn[] m_arColumns = new cListViewColumn[]
			{
			new cListViewColumn(0, "ManufacturerHeader","Manufacturer", HorizontalAlignment.Left, 200),
			new cListViewColumn(1, "PartHeader", "Part Number", HorizontalAlignment.Left, 100),
			new cListViewColumn(2, "SerialHeader", "Serial #", HorizontalAlignment.Left, 100),
			new cListViewColumn(3, "DecriptionHeader", "Description", HorizontalAlignment.Left, 200),
			new cListViewColumn(4, "SourceHeader", "Acquired from", HorizontalAlignment.Left, 200),
			new cListViewColumn(5, "DateHeader", "Date", HorizontalAlignment.Center, 80),
			new cListViewColumn(6, "PriceHeader", "Price", HorizontalAlignment.Right, 80),
			new cListViewColumn(7, "TaxHeader", "Tax", HorizontalAlignment.Right, 80),
			new cListViewColumn(8, "ShippingHeader", "Shipping", HorizontalAlignment.Right, 80),
			new cListViewColumn(9, "TotalHeader", "Total", HorizontalAlignment.Right, 80)
			};

		//============================================================================*
		// cToolListView() - Constructor
		//============================================================================*

		public cToolListView(cDataFiles DataFiles)
			: base(DataFiles, cPreferences.eApplicationListView.ToolsListView)
			{
			m_DataFiles = DataFiles;

			//----------------------------------------------------------------------------*
			// Set Properties
			//----------------------------------------------------------------------------*

			SetColumns();

			for (int i = 0; i < (int)cGear.eGearTypes.NumGearTypes; i++)
				m_afFilters[i] = true;

			Font = new System.Drawing.Font(Font, System.Drawing.FontStyle.Bold);

			//----------------------------------------------------------------------------*
			// Event Handlers
			//----------------------------------------------------------------------------*

			//----------------------------------------------------------------------------*
			// Populate Columns and Groups
			//----------------------------------------------------------------------------*

			PopulateGroups();

			SortingOrder = m_DataFiles.Preferences.ToolsSortOrder;

			SortingColumn = m_DataFiles.Preferences.ToolsSortColumn;

			ListViewItemSorter = new cListViewToolComparer(SortingColumn, SortingOrder);

			Populate();

			Initialized = true;
			}

		//============================================================================*
		// AddTool()
		//============================================================================*

		public ListViewItem AddTool(cTool Tool, bool fSelect = true)
			{
			//----------------------------------------------------------------------------*
			// Verify that the Tool should be added to the list
			//----------------------------------------------------------------------------*

			if (!VerifyTool(Tool))
				return (null);

			//----------------------------------------------------------------------------*
			// Create the ListViewItem
			//----------------------------------------------------------------------------*

			ListViewItem Item = new ListViewItem();

			SetToolData(Item, Tool);

			//----------------------------------------------------------------------------*
			// Add the item to the list and exit
			//----------------------------------------------------------------------------*

			AddItem(Item, fSelect);

			return (Item);
			}

		//============================================================================*
		// Filter()
		//============================================================================*

		public void Filter(cTool.eToolTypes eType, bool fShow = true)
			{
			m_afFilters[(int)eType] = fShow;

			Populate();
			}

		//============================================================================*
		// OnColumnClick()
		//============================================================================*

		protected override void OnColumnClick(ColumnClickEventArgs args)
			{
			if (args.Column == SortingColumn)
				{
				SortingOrder = (SortingOrder == SortOrder.Ascending) ? SortOrder.Descending : SortOrder.Ascending;

				m_DataFiles.Preferences.ToolsSortOrder = SortingOrder;

				ListViewItemSorter = new cListViewToolComparer(SortingColumn, SortingOrder);
				}
			else
				{
				SortingColumn = args.Column;

				this.Invalidate(true);

				ListViewItemSorter = new cListViewToolComparer(SortingColumn, SortingOrder);
				}

			if (SelectedItems.Count > 0)
				SelectedItems[0].EnsureVisible();

			m_DataFiles.Preferences.ToolsSortColumn = args.Column;
			}

		//============================================================================*
		// Populate()
		//============================================================================*

		public override void Populate()
			{
			Populating = true;

			//----------------------------------------------------------------------------*
			// ToolsListView Items
			//----------------------------------------------------------------------------*

			Items.Clear();

			ListViewItem SelectItem = null;

			foreach (cTool Tool in m_DataFiles.ToolList)
				{
				ListViewItem Item = AddTool(Tool);

				if (Item != null && m_DataFiles.Preferences.LastToolSelected != null && m_DataFiles.Preferences.LastToolSelected.CompareTo(Tool) == 0)
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

					m_DataFiles.Preferences.LastToolSelected = (cTool)Items[0].Tag;
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

			ListViewGroup Group = new ListViewGroup("PressGroup", cTool.ToolTypeString(cTool.eToolTypes.Press));

			Groups.Add(Group);

			Group = new ListViewGroup("PressAccessoryGroup", cTool.ToolTypeString(cTool.eToolTypes.PressAccessory));

			Groups.Add(Group);

			Group = new ListViewGroup("DieGroup", cTool.ToolTypeString(cTool.eToolTypes.Die));

			Groups.Add(Group);

			Group = new ListViewGroup("DieAccessoryGroup", cTool.ToolTypeString(cTool.eToolTypes.DieAccessory));

			Groups.Add(Group);

			Group = new ListViewGroup("PowderToolsGroup", cTool.ToolTypeString(cTool.eToolTypes.PowderTool));

			Groups.Add(Group);

			Group = new ListViewGroup("CasePrepGroup", cTool.ToolTypeString(cTool.eToolTypes.CasePrepTool));

			Groups.Add(Group);

			Group = new ListViewGroup("MeasurementGroup", cTool.ToolTypeString(cTool.eToolTypes.MeasurementTool));

			Groups.Add(Group);

			Group = new ListViewGroup("CastingGroup", cTool.ToolTypeString(cTool.eToolTypes.BulletCasting));

			Groups.Add(Group);

			Group = new ListViewGroup("GunsmithingGroup", cTool.ToolTypeString(cTool.eToolTypes.Gunsmithing));

			Groups.Add(Group);

			Group = new ListViewGroup("BookGroup", cTool.ToolTypeString(cTool.eToolTypes.Book));

			Groups.Add(Group);

			Group = new ListViewGroup("OtherGroup", cTool.ToolTypeString(cTool.eToolTypes.Other));

			Groups.Add(Group);
			}

		//============================================================================*
		// SetColumns()
		//============================================================================*

		public void SetColumns()
			{
			m_arColumns[6].Text = String.Format("Price ({0})", m_DataFiles.Preferences.Currency);
			m_arColumns[7].Text = String.Format("Tax ({0})", m_DataFiles.Preferences.Currency);
			m_arColumns[8].Text = String.Format("Shipping ({0})", m_DataFiles.Preferences.Currency);
			m_arColumns[9].Text = String.Format("Total ({0})", m_DataFiles.Preferences.Currency);

			PopulateColumns(m_arColumns);
			}

		//============================================================================*
		// SetToolData()
		//============================================================================*

		public void SetToolData(ListViewItem Item, cTool Tool)
			{
			Item.SubItems.Clear();

			Item.Text = Tool.Manufacturer.ToString();

			Item.Group = Groups[(int)Tool.ToolType];
			Item.Tag = Tool;

			Item.SubItems.Add(String.Format("{0}", Tool.PartNumber));
			Item.SubItems.Add(String.Format("{0}", Tool.SerialNumber));
			Item.SubItems.Add(String.Format("{0}", Tool.Description));

			Item.SubItems.Add(String.Format("{0}", Tool.Source));
			Item.SubItems.Add(!String.IsNullOrEmpty(Tool.Source) ? String.Format("{0}", Tool.PurchaseDate.ToShortDateString()) : "");
			Item.SubItems.Add(!String.IsNullOrEmpty(Tool.Source) && Tool.PurchasePrice > 0.0 ? String.Format("{0:F2}", Tool.PurchasePrice) : "-");
			Item.SubItems.Add(!String.IsNullOrEmpty(Tool.Source) && Tool.Tax > 0.0 ? String.Format("{0:F2}", Tool.Tax) : "-");
			Item.SubItems.Add(!String.IsNullOrEmpty(Tool.Source) && Tool.Shipping > 0.0 ? String.Format("{0:F2}", Tool.Shipping) : "-");

			double dTotal = Tool.PurchasePrice + Tool.Tax + Tool.Shipping;

			Item.SubItems.Add(!String.IsNullOrEmpty(Tool.Source) && dTotal != 0.0 ? String.Format("{0:F2}", dTotal) : "-");
			}

		//============================================================================*
		// UpdateTool()
		//============================================================================*

		public ListViewItem UpdateTool(cTool Tool, bool fSelect = false)
			{
			//----------------------------------------------------------------------------*
			// Find the Item
			//----------------------------------------------------------------------------*

			ListViewItem Item = null;

			foreach (ListViewItem CheckItem in Items)
				{
				if ((CheckItem.Tag as cTool).CompareTo(Tool) == 0)
					{
					Item = CheckItem;

					break;
					}
				}

			//----------------------------------------------------------------------------*
			// If the item was not found, add it
			//----------------------------------------------------------------------------*

			if (Item == null)
				return (AddTool(Tool, fSelect));

			//----------------------------------------------------------------------------*
			// Otherwise, update the Item Data
			//----------------------------------------------------------------------------*

			SetToolData(Item, Tool);

			if (fSelect)
				{
				Item.Selected = fSelect;

				Item.EnsureVisible();
				}

			return (Item);
			}

		//============================================================================*
		// VerifyTool()
		//============================================================================*

		public bool VerifyTool(cTool Tool)
			{
			//----------------------------------------------------------------------------*
			// Check Filters
			//----------------------------------------------------------------------------*

			if (!m_afFilters[(int)Tool.ToolType])
				return (false);

			return (true);
			}
		}
	}
