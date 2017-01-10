//============================================================================*
// cBatchLoadListView.cs
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
	// cBatchLoadListView Class
	//============================================================================*

	public class cBatchLoadListView : cListView
		{
		//============================================================================*
		// Private Data Members
		//============================================================================*

		private cDataFiles m_DataFiles = null;
		private cBatch m_Batch = null;

		private bool m_fShowBatchLoad = false;

		private cListViewColumn[] m_arColumns = new cListViewColumn[]
			{
			new cListViewColumn(0, "CaliberHeader", "Caliber", HorizontalAlignment.Left, 200),
			new cListViewColumn(1, "BulletHeader", "Bullet", HorizontalAlignment.Left, 200),
			new cListViewColumn(2, "PowderHeader","Powder", HorizontalAlignment.Left, 100),
			new cListViewColumn(3, "PrimerHeader", "Primer", HorizontalAlignment.Left, 100),
			new cListViewColumn(4, "CaseHeader", "Case", HorizontalAlignment.Left, 100)
			};

		//============================================================================*
		// cBatchLoadListView() - Constructor
		//============================================================================*

		public cBatchLoadListView(cDataFiles DataFiles, cBatch Batch, bool fShowBatchLoad)
			: base(DataFiles, cPreferences.eApplicationListView.BatchLoadListView)
			{
			m_DataFiles = DataFiles;
			m_Batch = Batch;
			m_fShowBatchLoad = fShowBatchLoad;

			//----------------------------------------------------------------------------*
			// Set Properties
			//----------------------------------------------------------------------------*

			//----------------------------------------------------------------------------*
			// Event Handlers
			//----------------------------------------------------------------------------*

			//----------------------------------------------------------------------------*
			// Populate Columns and Groups
			//----------------------------------------------------------------------------*

			SortingOrder = m_DataFiles.Preferences.BatchLoadSortOrder;

			SortingColumn = m_DataFiles.Preferences.BatchLoadSortColumn;

			PopulateColumns(m_arColumns);

			//----------------------------------------------------------------------------*
			// Populate Data
			//----------------------------------------------------------------------------*

			Initialized = true;
			}

		//============================================================================*
		// AddLoad()
		//============================================================================*

		public ListViewItem AddLoad(cLoad Load, cFirearm.eFireArmType eFirearmType, cCaliber Caliber, cBullet Bullet, cPowder Powder)
			{
			//----------------------------------------------------------------------------*
			// Verify that the load should be added
			//----------------------------------------------------------------------------*

			if (!VerifyLoad(Load, eFirearmType, Caliber, Bullet, Powder))
				return (null);

			//----------------------------------------------------------------------------*
			// Create the Item
			//----------------------------------------------------------------------------*

			ListViewItem Item = new ListViewItem();

			SetLoadData(Item, Load);

			//----------------------------------------------------------------------------*
			// Add the item and exit
			//----------------------------------------------------------------------------*

			AddItem(Item);

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

				m_DataFiles.Preferences.BatchLoadSortOrder = SortingOrder;
				}
			else
				{
				SortingColumn = args.Column;

				this.Invalidate(true);
				}

			ListViewItemSorter = new cListViewBatchLoadComparer(SortingColumn, SortingOrder);

			this.Invalidate(true);

			if (SelectedItems.Count > 0)
				SelectedItems[0].EnsureVisible();

			m_DataFiles.Preferences.BatchLoadSortColumn = args.Column;
			}

		//============================================================================*
		// Populate()
		//============================================================================*

		public void Populate(cFirearm.eFireArmType eFirearmType, cCaliber Caliber, cBullet Bullet, cPowder Powder)
			{
			Populating = true;

			Items.Clear();

			ListViewItem SelectItem = null;

			foreach (cLoad CheckLoad in m_DataFiles.LoadList)
				{
				ListViewItem Item = AddLoad(CheckLoad, eFirearmType, Caliber, Bullet, Powder);

				if (Item != null && m_Batch.Load != null && m_Batch.Load.CompareTo(CheckLoad) == 0)
					SelectItem = Item;
				}

			Focus();

			if (SelectItem != null)
				{
				SelectItem.Selected = true;

				EnsureVisible(SelectItem.Index);
				}
			else
				{
				if (Items.Count > 0)
					{
					Items[0].Selected = true;

					m_DataFiles.Preferences.LastBatchLoadSelected = (cLoad)Items[0].Tag;

					EnsureVisible(Items[0].Index);
					}
				}

			Populating = false;
			}

		//============================================================================*
		// Populate()
		//============================================================================*

		public void Populate(cLoad Load, cFirearm.eFireArmType eFirearmType, cCaliber Caliber, cBullet Bullet, cPowder Powder)
			{
			Populating = true;

			Items.Clear();

			ListViewItem SelectItem = null;

			foreach (cLoad CheckLoad in m_DataFiles.LoadList)
				{
				if (CheckLoad.CompareTo(Load) == 0)
					{
					ListViewItem Item = AddLoad(CheckLoad, eFirearmType, Caliber, Bullet, Powder);

					SelectItem = Item;
					}
				}

			if (SelectItem != null)
				{
				SelectItem.Selected = true;

				EnsureVisible(SelectItem.Index);
				}
			else
				{
				if (Items.Count > 0)
					{
					Items[0].Selected = true;

					m_DataFiles.Preferences.LastBatchLoadSelected = (cLoad)Items[0].Tag;

					EnsureVisible(Items[0].Index);
					}
				}

			Populating = false;
			}

		//============================================================================*
		// SetLoadData()
		//============================================================================*

		public void SetLoadData(ListViewItem Item, cLoad Load)
			{
			Item.SubItems.Clear();

			Item.Text = Load.Caliber.ToString();

			Item.Tag = Load;
			Item.Checked = Load.Checked;

			Item.SubItems.Add(Load.Bullet.ToWeightString());
			Item.SubItems.Add(Load.Powder.ToString());
			Item.SubItems.Add(Load.Primer.ToShortString());
			Item.SubItems.Add(Load.Case.ToShortString());
			}

		//============================================================================*
		// VerifyLoad()
		//============================================================================*

		public bool VerifyLoad(cLoad Load, cFirearm.eFireArmType eFirearmType, cCaliber Caliber, cBullet Bullet, cPowder Powder)
			{
			if (Load == null)
				return (false);

			//----------------------------------------------------------------------------*
			// See if we need to show this load regardless of other considerations
			//----------------------------------------------------------------------------*

			if (m_fShowBatchLoad && m_Batch.Load.CompareTo(Load) == 0)
				return(true);

			//----------------------------------------------------------------------------*
			// Check Filters
			//----------------------------------------------------------------------------*

			if ((eFirearmType != cFirearm.eFireArmType.None && Load.FirearmType != eFirearmType) ||
				(Caliber != null && Load.Caliber.CompareTo(Caliber) != 0) ||
				(Bullet != null && Load.Bullet.CompareTo(Bullet) != 0) ||
				(Powder != null && Load.Powder.CompareTo(Powder) != 0))
				return (false);

			//----------------------------------------------------------------------------*
			// Check Inventory
			//----------------------------------------------------------------------------*

			if (!m_DataFiles.VerifyLoadQuantities(m_Batch, Load))
				return (false);

			//----------------------------------------------------------------------------*
			// Make sure the caliber is not hidden
			//----------------------------------------------------------------------------*

			if (m_DataFiles.Preferences.HideUncheckedCalibers && !Load.Caliber.Checked)
				return (false);

			//----------------------------------------------------------------------------*
			// Make sure the supplies are not hidden
			//----------------------------------------------------------------------------*

			if (m_DataFiles.Preferences.HideUncheckedSupplies)
				{
				if (!Load.Bullet.Checked || !Load.Powder.Checked || !Load.Primer.Checked || !Load.Case.Checked)
					return (false);
				}

			return (true);
			}
		}
	}
