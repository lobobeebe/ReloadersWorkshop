//============================================================================*
// cBatchListView.cs
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
	// cBatchListView Class
	//============================================================================*

	public class cBatchListView : cListView
		{
		//============================================================================*
		// Private Data Members
		//============================================================================*

		cDataFiles m_DataFiles = null;

		private cListViewColumn[] m_arColumns = new cListViewColumn[]
			{
			new cListViewColumn(0, "BatchIDHeader","Batch ID", HorizontalAlignment.Left, 100),
			new cListViewColumn(1, "DateHeader", "Date", HorizontalAlignment.Left, 80),
			new cListViewColumn(2, "TestHeader", "Test Data?", HorizontalAlignment.Center, 80),
			new cListViewColumn(3, "CaliberHeader", "Caliber", HorizontalAlignment.Left, 150),
			new cListViewColumn(4, "NumRoundsHeader", "# Rounds", HorizontalAlignment.Center, 80),
			new cListViewColumn(5, "BulletHeader", "Bullet", HorizontalAlignment.Left, 150),
			new cListViewColumn(6, "PowderHeader", "Powder", HorizontalAlignment.Left, 150),
			new cListViewColumn(7, "PrimerHeader", "Primer", HorizontalAlignment.Left, 150),
			new cListViewColumn(8, "CaseHeader", "Case", HorizontalAlignment.Left, 150),
			new cListViewColumn(9, "FirearmHeader", "Firearm", HorizontalAlignment.Left, 200)
			};

		//============================================================================*
		// cBatchListView() - Constructor
		//============================================================================*

		public cBatchListView(cDataFiles DataFiles)
			: base(DataFiles, cPreferences.eApplicationListView.BatchListView)
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

			SortingOrder = m_DataFiles.Preferences.BatchSortOrder;
			SortingColumn = m_DataFiles.Preferences.BatchSortColumn;

			ListViewItemSorter = new cListViewBatchComparer(SortingColumn, SortingOrder);

			PopulateColumns(m_arColumns);
			PopulateGroups();

			//----------------------------------------------------------------------------*
			// Populate Data
			//----------------------------------------------------------------------------*

			Initialized = true;
			}

		//============================================================================*
		// AddBatch()
		//============================================================================*

		public ListViewItem AddBatch(cBatch Batch, cFirearm.eFireArmType eFireArmType, cCaliber Caliber, cBullet Bullet, cPowder Powder, bool fSelect = false)
			{
			if (!VerifyBatch(Batch, eFireArmType, Caliber, Bullet, Powder))
				return (null);

			//----------------------------------------------------------------------------*
			// Create the ListViewItem
			//----------------------------------------------------------------------------*

			ListViewItem Item = new ListViewItem();

			SetBatchData(Item, Batch);

			//----------------------------------------------------------------------------*
			// Add the item and exit
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
				SortingOrder = (SortingOrder == SortOrder.Ascending) ? SortOrder.Descending : SortOrder.Ascending;
			else
				SortingColumn = args.Column;

			ListViewItemSorter = new cListViewBatchComparer(SortingColumn, SortingOrder);

			if (SelectedItems.Count > 0)
				SelectedItems[0].EnsureVisible();

			m_DataFiles.Preferences.BatchSortColumn = args.Column;
			m_DataFiles.Preferences.BatchSortOrder = SortingOrder;
			}

		//============================================================================*
		// Populate()
		//============================================================================*

		public void Populate(cFirearm.eFireArmType eFireArmType, cCaliber Caliber, cBullet Bullet, cPowder Powder)
			{
			if (Populating)
				return;

			Populating = true;

			Items.Clear();

			ListViewItem SelectItem = null;

			foreach (cBatch Batch in m_DataFiles.BatchList)
				{
				if (Batch.Archived && !m_DataFiles.Preferences.ShowArchivedBatches)
					continue;

				ListViewItem Item = AddBatch(Batch, eFireArmType, Caliber, Bullet, Powder);

				if (Item != null && m_DataFiles.Preferences.LastBatchSelected != null && m_DataFiles.Preferences.LastBatchSelected.CompareTo(Batch) == 0)
					SelectItem = Item;
				}

			Focus();

			if (SelectItem != null && SelectItem.Index >= 0)
				{
				SelectItem.Selected = true;

				EnsureVisible(SelectItem.Index);
				}
			else
				{
				if (Items.Count > 0)
					{
					Items[0].Selected = true;

					m_DataFiles.Preferences.LastBatchSelected = (cBatch)Items[0].Tag;

					EnsureVisible(Items[0].Index);
					}
				}

			Populating = false;
			}

		//============================================================================*
		// SetBatchData()
		//============================================================================*

		public void SetBatchData(ListViewItem Item, cBatch Batch)
			{
			Item.SubItems.Clear();

			Item.Text = String.Format("{0:N0}", Batch.BatchID);

			if (Batch.Archived)
				Item.Text += " - Archived";

			if (m_DataFiles.Preferences.TrackInventory && !Batch.TrackInventory)
				Item.Text += " *";

			Item.Checked = Batch.Checked;

			Item.Group = Groups[(int)Batch.Load.FirearmType];
			Item.Tag = Batch;

			Item.SubItems.Add(Batch.DateLoaded.ToShortDateString());
			Item.SubItems.Add(Batch.BatchTest != null ? "Y" : "");
			Item.SubItems.Add(Batch.Load.Caliber.ToString());
			Item.SubItems.Add(String.Format("{0:N0}", Batch.NumRounds));
			Item.SubItems.Add(Batch.Load.Bullet.ToWeightString());

			bool fCompressed = false;

			foreach (cCharge Charge in Batch.Load.ChargeList)
				{
				if (Charge.PowderWeight == Batch.PowderWeight)
					{
					if (Charge.FillRatio > 100.0)
						fCompressed = true;

					break;
					}
				}

			string strPowderWeightFormat = "{0:F";
			strPowderWeightFormat += String.Format("{0:G0}", m_DataFiles.Preferences.PowderWeightDecimals);
			strPowderWeightFormat += "}";

			if (fCompressed)
				strPowderWeightFormat += "C";
			 
			strPowderWeightFormat += " {1} of {2}";

			Item.SubItems.Add(String.Format(strPowderWeightFormat, m_DataFiles.StandardToMetric(Batch.PowderWeight, cDataFiles.eDataType.PowderWeight), m_DataFiles.MetricString(cDataFiles.eDataType.PowderWeight), Batch.Load.Powder.ToString()));
			Item.SubItems.Add(Batch.Load.Primer.ToString());
			Item.SubItems.Add(Batch.Load.Case.ToShortString());

			if (Batch.Firearm != null)
				Item.SubItems.Add(Batch.Firearm.ToString());
			else
				Item.SubItems.Add("Any Firearm");
			}

		//============================================================================*
		// UpdateBatch()
		//============================================================================*

		public ListViewItem UpdateBatch(cBatch Batch, cFirearm.eFireArmType eFirearmType, cCaliber Caliber, cBullet Bullet, cPowder Powder, bool fSelect = false)
			{
			//----------------------------------------------------------------------------*
			// Find the Item
			//----------------------------------------------------------------------------*

			ListViewItem Item = null;

			foreach (ListViewItem CheckItem in Items)
				{
				if ((CheckItem.Tag as cBatch).CompareTo(Batch) == 0)
					{
					Item = CheckItem;

					break;
					}
				}

			//----------------------------------------------------------------------------*
			// If the item was not found, add it
			//----------------------------------------------------------------------------*

			if (Item == null)
				return(null);

			//----------------------------------------------------------------------------*
			// Otherwise, update the Item Data
			//----------------------------------------------------------------------------*

			SetBatchData(Item, Batch);

			Item.Selected = fSelect;

			if (SelectedItems.Count > 0)
				SelectedItems[0].EnsureVisible();

			Focus();

			return (Item);
			}

		//============================================================================*
		// VerifyBatch()
		//============================================================================*

		public bool VerifyBatch(cBatch Batch, cFirearm.eFireArmType eFirearmType, cCaliber Caliber, cBullet Bullet, cPowder Powder)
			{
			//----------------------------------------------------------------------------*
			// Make sure the batch shouldn't be hidden
			//----------------------------------------------------------------------------*
			/*
						if ((m_DataFiles.Preferences.HideUncheckedCalibers && !Batch.Load.Caliber.Checked) ||
							(m_DataFiles.Preferences.HideUncheckedSupplies && !Batch.Load.Bullet.Checked) ||
							(m_DataFiles.Preferences.HideUncheckedSupplies && !Batch.Load.Powder.Checked) ||
							(m_DataFiles.Preferences.HideUncheckedSupplies && !Batch.Load.Primer.Checked) ||
							(m_DataFiles.Preferences.HideUncheckedSupplies && !Batch.Load.Case.Checked) ||
							Batch.Archived)
							return (false);
			*/
			//----------------------------------------------------------------------------*
			// Check the filters
			//----------------------------------------------------------------------------*

			if (Batch.Load.FirearmType != eFirearmType)
				return (false);

			if (Caliber != null && Batch.Load.Caliber != Caliber)
				return (false);

			if (Bullet != null && Batch.Load.Bullet != Bullet)
				return (false);

			if (Powder != null && Batch.Load.Powder != Powder)
				return (false);

			return (true);
			}
		}
	}
