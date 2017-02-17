//============================================================================*
// cAmmoTestListView.cs
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
	// cAmmoTestListView Class
	//============================================================================*

	public class cAmmoTestListView : cListView
		{
		//============================================================================*
		// Private Data Members
		//============================================================================*

		private cDataFiles m_DataFiles = null;
		private cAmmo m_Ammo = null;

		private string m_strGroupFormat = "{0:F2}";

		private cListViewColumn[] m_arColumns = new cListViewColumn[]
			{
			new cListViewColumn(0, "DateHeader","Test Date", HorizontalAlignment.Left, 120),
			new cListViewColumn(1, "FirearmHeader","Firearm", HorizontalAlignment.Left, 200),
			new cListViewColumn(2, "MuzzleVelocityHeader", "Muzzle Vel.", HorizontalAlignment.Center, 100),
			new cListViewColumn(3, "BestGroupHeader", "Best Group", HorizontalAlignment.Center, 100),
			new cListViewColumn(4, "MOAHeader", "MOA", HorizontalAlignment.Center, 100),
			new cListViewColumn(5, "RangeHeader", "Range", HorizontalAlignment.Center, 100)
			};

		//============================================================================*
		// cAmmoTestListView() - Constructor
		//============================================================================*

		public cAmmoTestListView(cDataFiles DataFiles, cAmmo Ammo)
			: base(DataFiles, cPreferences.eApplicationListView.AmmoTestListView)
			{
			m_DataFiles = DataFiles;
			m_Ammo = Ammo;

			//----------------------------------------------------------------------------*
			// Set Properties
			//----------------------------------------------------------------------------*

			//----------------------------------------------------------------------------*
			// Event Handlers
			//----------------------------------------------------------------------------*

			//----------------------------------------------------------------------------*
			// Populate Columns and Groups
			//----------------------------------------------------------------------------*

			SortingOrder = m_DataFiles.Preferences.AmmoTestSortOrder;

			SortingColumn = m_DataFiles.Preferences.AmmoTestSortColumn;

			m_arColumns[2].Text += String.Format(" ({0})",  cDataFiles.MetricString(cDataFiles.eDataType.Velocity));
			m_arColumns[3].Text += String.Format(" ({0})", cDataFiles.MetricString(cDataFiles.eDataType.GroupSize));
			m_arColumns[5].Text += String.Format(" ({0})", cDataFiles.MetricString(cDataFiles.eDataType.Range));

			PopulateColumns(m_arColumns);

			//----------------------------------------------------------------------------*
			// Populate Data
			//----------------------------------------------------------------------------*

			Populate(m_Ammo);

			Initialized = true;
			}

		//============================================================================*
		// AddAmmoTest()
		//============================================================================*

		public ListViewItem AddAmmoTest(cAmmoTest AmmoTest, bool fSelect = false)
			{
			//----------------------------------------------------------------------------*
			// Verify that the test shoudl be added
			//----------------------------------------------------------------------------*

			if (!VerifyAmmoTest(AmmoTest))
				return (null);

			//----------------------------------------------------------------------------*
			// Create the new Item
			//----------------------------------------------------------------------------*

			ListViewItem Item = new ListViewItem();

			SetAmmoTestData(Item, AmmoTest);

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

				m_DataFiles.Preferences.AmmoTestSortOrder = SortingOrder;

				ListViewItemSorter = new cListViewAmmoTestComparer(SortingColumn, SortingOrder);
				}
			else
				{
				SortingColumn = args.Column;

				ListViewItemSorter = new cListViewAmmoTestComparer(SortingColumn, SortingOrder);
				}

			this.Invalidate(true);

			if (SelectedItems.Count > 0)
				SelectedItems[0].EnsureVisible();

			m_DataFiles.Preferences.AmmoTestSortColumn = args.Column;
			}

		//============================================================================*
		// Populate()
		//============================================================================*

		public void Populate(cAmmo Ammo)
			{
			Populating = true;

			//----------------------------------------------------------------------------*
			// Create the format strings
			//----------------------------------------------------------------------------*

			m_strGroupFormat = m_DataFiles.Preferences.FormatString(cDataFiles.eDataType.GroupSize);

			//----------------------------------------------------------------------------*
			// Reset the list view
			//----------------------------------------------------------------------------*

			Items.Clear();

			foreach (cAmmoTest AmmoTest in Ammo.TestList)
				{
				ListViewItem Item = AddAmmoTest(AmmoTest);
				}

			Focus();

			if (Items.Count > 0)
				{
				Items[0].Selected = true;

				EnsureVisible(Items[0].Index);
				}

			Populating = false;
			}

		//============================================================================*
		// SetAmmoTestData()
		//============================================================================*

		public void SetAmmoTestData(ListViewItem Item, cAmmoTest AmmoTest)
			{
			Item.SubItems.Clear();

			Item.Text = AmmoTest.TestDate.ToShortDateString();

			Item.Tag = AmmoTest;

			Item.SubItems.Add(AmmoTest.Firearm != null ? AmmoTest.Firearm.ToString() : "Factory");
			Item.SubItems.Add(String.Format("{0:G0}", cDataFiles.StandardToMetric(AmmoTest.MuzzleVelocity, cDataFiles.eDataType.Velocity)));
			Item.SubItems.Add(String.Format(m_strGroupFormat, cDataFiles.StandardToMetric(AmmoTest.BestGroup, cDataFiles.eDataType.GroupSize)));

			double dBestGroup = AmmoTest.BestGroup;
			double  dBestGroupRange = AmmoTest.BestGroupRange;

			double dMOA = (dBestGroup != 0.0 && dBestGroupRange != 0.0) ? dBestGroup / ((dBestGroupRange / 100.0) * 1.047) : 0.0;

			Item.SubItems.Add(String.Format("{0:F3}", dMOA));

			Item.SubItems.Add(String.Format("{0:N0}", cDataFiles.StandardToMetric(AmmoTest.BestGroupRange, cDataFiles.eDataType.Range)));
 			}

		//============================================================================*
		// UpdateAmmoTest()
		//============================================================================*

		public void UpdateAmmoTest(cAmmoTest AmmoTest, bool fSelect = false)
			{
			foreach (ListViewItem Item in Items)
				{
				if ((Item.Tag as cAmmoTest).Equals(AmmoTest))
					{
					SetAmmoTestData(Item, AmmoTest);

					Item.Selected = fSelect;

					if (SelectedItems.Count > 0)
						SelectedItems[0].EnsureVisible();

					return;
					}
				}

			AddAmmoTest(AmmoTest, fSelect);
			}

		//============================================================================*
		// VerifyAmmoTest()
		//============================================================================*

		public bool VerifyAmmoTest(cAmmoTest AmmoTest)
			{
			// All tests are verified

			return (true);
			}
		}
	}
