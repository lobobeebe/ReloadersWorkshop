//============================================================================*
// cBulletCaliberListView.cs
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
	// cBulletCaliberListView Class
	//============================================================================*

	public class cBulletCaliberListView : cListView
		{
		//============================================================================*
		// Private Data Members
		//============================================================================*

		cDataFiles m_DataFiles = null;

		private string m_strDimensionFormat = "";

		private cListViewColumn[] m_arColumns = new cListViewColumn[]
			{
			new cListViewColumn(0, "CaliberHeader","Caliber", HorizontalAlignment.Left, 240),
			new cListViewColumn(1, "COALHeader", "COAL", HorizontalAlignment.Center, 120),
			new cListViewColumn(2, "CBTOHeader", "CBTO", HorizontalAlignment.Center, 120)
			};

		//============================================================================*
		// cBulletCaliberListView() - Constructor
		//============================================================================*

		public cBulletCaliberListView(cDataFiles DataFiles)
			: base(DataFiles, cPreferences.eApplicationListView.BulletCalibersListView)
			{
			m_DataFiles = DataFiles;

			//----------------------------------------------------------------------------*
			// Set Properties
			//----------------------------------------------------------------------------*

			m_arColumns[1].Text += String.Format(" ({0})", cDataFiles.MetricString(cDataFiles.eDataType.Dimension));
			m_arColumns[2].Text += String.Format(" ({0})", cDataFiles.MetricString(cDataFiles.eDataType.Dimension));

			//----------------------------------------------------------------------------*
			// Event Handlers
			//----------------------------------------------------------------------------*

			//----------------------------------------------------------------------------*
			// Populate Columns and Groups
			//----------------------------------------------------------------------------*

			SortingOrder = m_DataFiles.Preferences.BulletCaliberSortOrder;

			SortingColumn = m_DataFiles.Preferences.BulletCaliberSortColumn;

			PopulateColumns(m_arColumns);

			//----------------------------------------------------------------------------*
			// Populate Data
			//----------------------------------------------------------------------------*

			Populate();

			Initialized = true;
			}

		//============================================================================*
		// AddBulletCaliber()
		//============================================================================*

		public ListViewItem AddBulletCaliber(cBulletCaliber BulletCaliber, bool fSelect = false)
			{
			//----------------------------------------------------------------------------*
			// Verify that the caliber shoudl be added
			//----------------------------------------------------------------------------*

			if (!VerifyBulletCaliber(BulletCaliber))
				return (null);

			//----------------------------------------------------------------------------*
			// Create the new Item
			//----------------------------------------------------------------------------*

			ListViewItem Item = new ListViewItem();

			SetBulletCaliberData(Item, BulletCaliber);

			base.AddItem(Item, fSelect);

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

				m_DataFiles.Preferences.BulletCaliberSortOrder = SortingOrder;

				ListViewItemSorter = new cListViewBulletCaliberComparer(SortingColumn, SortingOrder);
				}
			else
				{
				SortingColumn = args.Column;

				ListViewItemSorter = new cListViewBulletCaliberComparer(SortingColumn, SortingOrder);
				}

			this.Invalidate(true);

			if (SelectedItems.Count > 0)
				SelectedItems[0].EnsureVisible();

			m_DataFiles.Preferences.BulletCaliberSortColumn = args.Column;
			}

		//============================================================================*
		// Populate()
		//============================================================================*

		public void Populate(cBullet Bullet)
			{
			Populating = true;

			m_strDimensionFormat = "{0:F";
			m_strDimensionFormat += String.Format("{0:G0}", m_DataFiles.Preferences.DimensionDecimals);
			m_strDimensionFormat += "}";

			Items.Clear();

			ListViewItem SelectItem = null;

			foreach (cBulletCaliber BulletCaliber in Bullet.BulletCaliberList)
				{
				ListViewItem Item = AddBulletCaliber(BulletCaliber);

				if (Item != null && m_DataFiles.Preferences.LastBulletCaliberSelected != null && m_DataFiles.Preferences.LastBulletCaliberSelected.CompareTo(BulletCaliber) == 0)
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

					m_DataFiles.Preferences.LastBulletCaliberSelected = (cBulletCaliber)Items[0].Tag;

					EnsureVisible(Items[0].Index);
					}
				}

			Populating = false;
			}

		//============================================================================*
		// SetBulletCaliberData()
		//============================================================================*

		public void SetBulletCaliberData(ListViewItem Item, cBulletCaliber BulletCaliber)
			{
			Item.SubItems.Clear();

			Item.Text = BulletCaliber.Caliber.ToString();

			Item.Tag = BulletCaliber;

			Item.SubItems.Add(String.Format(m_strDimensionFormat, cDataFiles.StandardToMetric(BulletCaliber.COL, cDataFiles.eDataType.Dimension)));
			Item.SubItems.Add(String.Format(m_strDimensionFormat, cDataFiles.StandardToMetric(BulletCaliber.CBTO, cDataFiles.eDataType.Dimension)));
			}

		//============================================================================*
		// UpdateBulletCaliber()
		//============================================================================*

		public void UpdateBulletCaliber(cBulletCaliber BulletCaliber, bool fSelect = false)
			{
			foreach (ListViewItem Item in Items)
				{
				if ((Item.Tag as cBulletCaliber).Equals(BulletCaliber))
					{
					SetBulletCaliberData(Item, BulletCaliber);

					Item.Selected = fSelect;

					if (SelectedItems.Count > 0)
						SelectedItems[0].EnsureVisible();

					return;
					}
				}

			AddBulletCaliber(BulletCaliber, fSelect);
			}

		//============================================================================*
		// VerifyBulletCaliber()
		//============================================================================*

		public bool VerifyBulletCaliber(cBulletCaliber BulletCaliber)
			{

			return (true);
			}
		}
	}
