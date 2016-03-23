//============================================================================*
// cFirearmBulletListView.cs
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
	// cFirearmBulletListView Class
	//============================================================================*

	public class cFirearmBulletListView : cListView
		{
		//============================================================================*
		// Private Data Members
		//============================================================================*

		private cDataFiles m_DataFiles = null;

		private cFirearm m_Firearm = null;
		private cCaliber m_Caliber = null;

		private string m_strDimensionFormat = "{0:F3}";

		private cListViewColumn[] m_arColumns = new cListViewColumn[]
			{
			new cListViewColumn(0, "BulletHeader","Bullet", HorizontalAlignment.Left, 200),
			new cListViewColumn(1, "COALHeader", "COAL", HorizontalAlignment.Center, 100),
			new cListViewColumn(2, "CBTOHeader", "CBTO", HorizontalAlignment.Center, 120),
			};

		//============================================================================*
		// cFirearmBulletListView() - Constructor
		//============================================================================*

		public cFirearmBulletListView(cDataFiles DataFiles, cFirearm Firearm)
			: base(DataFiles, cPreferences.eApplicationListView.FirearmsBulletListView)
			{
			m_DataFiles = DataFiles;
			m_Firearm = Firearm;
			m_Caliber = m_Firearm.PrimaryCaliber;

			//----------------------------------------------------------------------------*
			// Set Properties
			//----------------------------------------------------------------------------*

			//----------------------------------------------------------------------------*
			// Set column measurements
			//----------------------------------------------------------------------------*

			m_arColumns[1].Text += String.Format(" ({0})", m_DataFiles.MetricString(cDataFiles.eDataType.Dimension));
			m_arColumns[2].Text += String.Format(" ({0})", m_DataFiles.MetricString(cDataFiles.eDataType.Dimension));

			//----------------------------------------------------------------------------*
			// Populate Columns and Groups
			//----------------------------------------------------------------------------*

			SortingOrder = m_DataFiles.Preferences.FirearmBulletSortOrder;

			SortingColumn = m_DataFiles.Preferences.FirearmBulletSortColumn;

			PopulateColumns(m_arColumns);

			//----------------------------------------------------------------------------*
			// Populate Data
			//----------------------------------------------------------------------------*

			Populate();

			Initialized = true;
			}

		//============================================================================*
		// AddFirearmBullet()
		//============================================================================*

		public ListViewItem AddFirearmBullet(cFirearmBullet FirearmBullet, bool fSelect = false)
			{
			//----------------------------------------------------------------------------*
			// Create the ListViewItem
			//----------------------------------------------------------------------------*

			ListViewItem Item = new ListViewItem(String.Format("{0:N0}", FirearmBullet.Bullet.ToString()));

			SetFirearmBulletData(Item, FirearmBullet);

			base.AddItem(Item, fSelect);

			return (Item);
			}

		//============================================================================*
		// Caliber Property
		//============================================================================*

		public cCaliber Caliber
			{
			set
				{
				m_Caliber = value;

				Populate();
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

				m_DataFiles.Preferences.FirearmBulletSortOrder = SortingOrder;

				ListViewItemSorter = new cListViewFirearmBulletComparer(SortingColumn, SortingOrder);
				}
			else
				{
				SortingColumn = args.Column;

				m_DataFiles.Preferences.FirearmBulletSortColumn = args.Column;

				ListViewItemSorter = new cListViewFirearmBulletComparer(SortingColumn, SortingOrder);
				}

			this.Invalidate(true);

			if (SelectedItems.Count > 0)
				SelectedItems[0].EnsureVisible();
			}

		//============================================================================*
		// Populate()
		//============================================================================*

		public override void Populate()
			{
			Populating = true;

			m_strDimensionFormat = "{0:F";
			m_strDimensionFormat += String.Format("{0:G0}", m_DataFiles.Preferences.DimensionDecimals);
			m_strDimensionFormat += "}";

			Items.Clear();

			if (m_Firearm == null)
				return;

			if (m_Firearm.FirearmBulletList == null)
				m_Firearm.FirearmBulletList = new cFirearmBulletList();

			ListViewItem SelectItem = null;

			foreach (cFirearmBullet Bullet in m_Firearm.FirearmBulletList)
				{
				if (Bullet.Caliber == null)
					Bullet.Caliber = m_Firearm.PrimaryCaliber;

				if (m_Caliber != null && Bullet.Caliber != null && Bullet.Caliber.CompareTo(m_Caliber) == 0)
					{
					ListViewItem Item = AddFirearmBullet(Bullet);

					if (Item != null && m_DataFiles.Preferences.LastFirearmBulletSelected != null && m_DataFiles.Preferences.LastFirearmBulletSelected.CompareTo(Bullet) == 0)
						SelectItem = Item;
					}
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

					m_DataFiles.Preferences.LastFirearmBulletSelected = (cFirearmBullet)Items[0].Tag;

					EnsureVisible(Items[0].Index);
					}
				}

			Populating = false;
			}

		//============================================================================*
		// SetFirearmBulletData()
		//============================================================================*

		public void SetFirearmBulletData(ListViewItem Item, cFirearmBullet FirearmBullet)
			{
			Item.SubItems.Clear();

			Item.Text = FirearmBullet.ToString();

			Item.Tag = FirearmBullet;

			Item.SubItems.Add(String.Format(m_strDimensionFormat, m_DataFiles.StandardToMetric(FirearmBullet.COL, cDataFiles.eDataType.Dimension)));

			if (FirearmBullet.Bullet.FirearmType != cFirearm.eFireArmType.Rifle)
				Item.SubItems.Add("N/A");
			else
				Item.SubItems.Add(String.Format(m_strDimensionFormat, m_DataFiles.StandardToMetric(FirearmBullet.CBTO, cDataFiles.eDataType.Dimension)));
			}

		//============================================================================*
		// UpdateFirearmBullet()
		//============================================================================*

		public ListViewItem UpdateFirearmBullet(cFirearmBullet FirearmBullet, bool fSelect = false)
			{
			//----------------------------------------------------------------------------*
			// Find the Item
			//----------------------------------------------------------------------------*

			ListViewItem Item = null;

			foreach (ListViewItem CheckItem in Items)
				{
				if ((CheckItem.Tag as cFirearmBullet).CompareTo(FirearmBullet) == 0)
					{
					Item = CheckItem;

					break;
					}
				}

			//----------------------------------------------------------------------------*
			// If the item was not found, add it
			//----------------------------------------------------------------------------*

			if (Item == null)
				return (AddFirearmBullet(FirearmBullet, fSelect));

			//----------------------------------------------------------------------------*
			// Otherwise, update the Item Data
			//----------------------------------------------------------------------------*

			SetFirearmBulletData(Item, FirearmBullet);

			if (fSelect)
				{
				Item.Selected = fSelect;

				Item.EnsureVisible();
				}

			Focus();

			return (Item);
			}
		}
	}
