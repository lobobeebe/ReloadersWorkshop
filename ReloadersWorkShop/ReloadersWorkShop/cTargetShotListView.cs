//============================================================================*
// cTargetShotListView.cs
//
// Copyright © 2013-2014, Kevin S. Beebe
// All Rights Reserved
//============================================================================*

//============================================================================*
// .Net Using Statements
//============================================================================*

using System;
using System.Drawing;
using System.Windows.Forms;

using ReloadersWorkShop.Preferences;

//============================================================================*
// NameSpace
//============================================================================*

namespace ReloadersWorkShop
	{
	//============================================================================*
	// cTargetShotListView Class
	//============================================================================*

	public class cTargetShotListView : cListView
		{
		//============================================================================*
		// Private Data Members
		//============================================================================*

		private cDataFiles m_DataFiles = null;
		private cTarget m_Target = null;

		private string m_strGroupFormat = "{0:F2}";

		private cListViewColumn[] m_arColumns = new cListViewColumn[]
			{
			new cListViewColumn(0, "ShotHeader","Shot #", HorizontalAlignment.Center, 100),
			new cListViewColumn(1, "OffsetHeader","Offset", HorizontalAlignment.Left, 200),
			new cListViewColumn(2, "InchesHeader", "Offset", HorizontalAlignment.Center, 100),
			new cListViewColumn(3, "MOAHeader", "Offset MOA", HorizontalAlignment.Center, 100),
			new cListViewColumn(4, "MilsHeader", "Offset Mils", HorizontalAlignment.Center, 100)
			};

		//============================================================================*
		// cTargetShotListView() - Constructor
		//============================================================================*

		public cTargetShotListView(cDataFiles DataFiles, cTarget Target)
			: base(DataFiles, cPreferences.eApplicationListView.AmmoTestListView)
			{
			m_DataFiles = DataFiles;
			m_Target = Target;

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

			m_arColumns[2].Text += String.Format(" ({0})", cDataFiles.MetricString(cDataFiles.eDataType.GroupSize));

			PopulateColumns(m_arColumns);

			//----------------------------------------------------------------------------*
			// Populate Data
			//----------------------------------------------------------------------------*

			Populate();

			Initialized = true;
			}

		//============================================================================*
		// AddShot()
		//============================================================================*

		public ListViewItem AddShot(Point Shot, bool fSelect = false)
			{
			//----------------------------------------------------------------------------*
			// Create the new Item
			//----------------------------------------------------------------------------*

			ListViewItem Item = new ListViewItem();

			SetShotData(Item, Shot);

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

		public override void Populate()
			{
			Populating = true;

			//----------------------------------------------------------------------------*
			// Create the format strings
			//----------------------------------------------------------------------------*

			m_strGroupFormat = "{0:F";
			m_strGroupFormat += String.Format("{0:G0}", cPreferences.GroupDecimals);
			m_strGroupFormat += "}";

			//----------------------------------------------------------------------------*
			// Reset the list view
			//----------------------------------------------------------------------------*

			Items.Clear();

			foreach (Point Shot in m_Target.ShotList)
				{
				ListViewItem Item = AddShot(Shot);
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
		// SetShotData()
		//============================================================================*

		public void SetShotData(ListViewItem Item, Point Shot)
			{
			Item.SubItems.Clear();

			Item.Text = String.Format("{0:G0}", Items.Count + 1);

			Item.SubItems.Add(m_Target.OffsetString(Shot));
			Item.SubItems.Add(String.Format(m_strGroupFormat, cDataFiles.StandardToMetric(m_Target.OffsetLength(Shot), cDataFiles.eDataType.GroupSize)));
			Item.SubItems.Add(String.Format("{0:F3}", m_Target.OffsetMOA(Shot)));
			Item.SubItems.Add(String.Format("{0:F3}", m_Target.OffsetMils(Shot)));
			}
		}
	}
