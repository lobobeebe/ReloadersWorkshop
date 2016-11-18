//============================================================================*
// cChargeListView.cs
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
	// cChargeListView Class
	//============================================================================*

	public class cChargeListView : cListView
		{
		//============================================================================*
		// Private Data Members
		//============================================================================*

		cDataFiles m_DataFiles = null;
		cLoad m_Load = null;

		private string m_strPowderWeightFormat = "{0:F1}";

		private cListViewColumn[] m_arColumns = new cListViewColumn[]
			{
			new cListViewColumn(0, "ChargeHeader","Charge", HorizontalAlignment.Center, 110),
			new cListViewColumn(1, "TestsHeader","# Tests", HorizontalAlignment.Center, 110),
			new cListViewColumn(2, "RatioHeader","Fill Ratio (%)", HorizontalAlignment.Center, 110),
			new cListViewColumn(3, "FavoriteHeader","Favorite?", HorizontalAlignment.Center, 110),
			new cListViewColumn(4, "RejectHeader","Reject?", HorizontalAlignment.Center, 110)
			};

		//============================================================================*
		// cChargeListView() - Constructor
		//============================================================================*

		public cChargeListView(cDataFiles DataFiles, cLoad Load)
			: base(DataFiles, cPreferences.eApplicationListView.ChargeListView)
			{
			m_DataFiles = DataFiles;
			m_Load = Load;

			//----------------------------------------------------------------------------*
			// Set Properties
			//----------------------------------------------------------------------------*

			//----------------------------------------------------------------------------*
			// Event Handlers
			//----------------------------------------------------------------------------*

			//----------------------------------------------------------------------------*
			// Load Images
			//----------------------------------------------------------------------------*

			//----------------------------------------------------------------------------*
			// Populate Columns and Groups
			//----------------------------------------------------------------------------*

			SortingOrder = m_DataFiles.Preferences.ChargeSortOrder;

			SortingColumn = m_DataFiles.Preferences.ChargeSortColumn;

			m_arColumns[0].Text += String.Format(" ({0})", cDataFiles.MetricString(cDataFiles.eDataType.PowderWeight));

			PopulateColumns(m_arColumns);

			//----------------------------------------------------------------------------*
			// Populate Data
			//----------------------------------------------------------------------------*

			Populate(m_Load, null);

			Initialized = true;
			}

		//============================================================================*
		// AddCharge()
		//============================================================================*

		public ListViewItem AddCharge(cCharge Charge, bool fSelect = false)
			{
			ListViewItem Item = null;

			Item = new ListViewItem(Charge.ToString());

			SetChargeData(Item, Charge);

			try
				{
				Items.Add(Item);
				}
			catch (Exception e)
				{
				cControls.InternalErrorMessageBox(e);
				}

			if (Charge.Favorite)
				Item.ImageIndex = 0;
			else
				{
				if (Charge.Reject)
					Item.ImageIndex = 1;
				else
					Item.ImageIndex = -1;
				}

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

				m_DataFiles.Preferences.ChargeSortOrder = SortingOrder;

				ListViewItemSorter = new cListViewChargeComparer(SortingColumn, SortingOrder);
				}
			else
				{
				SortingColumn = args.Column;

				m_DataFiles.Preferences.ChargeSortColumn = args.Column;

				ListViewItemSorter = new cListViewChargeComparer(SortingColumn, SortingOrder);
				}

			this.Invalidate(true);

			if (SelectedItems.Count > 0)
				SelectedItems[0].EnsureVisible();
			}

		//============================================================================*
		// Populate()
		//============================================================================*

		public void Populate(cLoad Load, cCharge SelectCharge)
			{
			Populating = true;

			//----------------------------------------------------------------------------*
			// Create the format strings
			//----------------------------------------------------------------------------*

			m_strPowderWeightFormat = "{0:F";
			m_strPowderWeightFormat += String.Format("{0:G0}", cPreferences.PowderWeightDecimals);
			m_strPowderWeightFormat += "}";

			//----------------------------------------------------------------------------*
			// Reset the list view
			//----------------------------------------------------------------------------*

			Items.Clear();

			ListViewItem SelectItem = null;

			//----------------------------------------------------------------------------*
			// Loop through the charges
			//----------------------------------------------------------------------------*

			foreach (cCharge Charge in Load.ChargeList)
				{
				ListViewItem Item = AddCharge(Charge);

				if (Item != null && SelectCharge != null && SelectCharge.CompareTo(Charge) == 0)
					SelectItem = Item;
				}

			Focus();

			//----------------------------------------------------------------------------*
			// Select a charge
			//----------------------------------------------------------------------------*

			if (SelectItem != null)
				{
				SelectItem.Selected = true;

				m_DataFiles.Preferences.LastChargeSelected = (cCharge) Items[0].Tag;

				EnsureVisible(SelectItem.Index);
				}
			else
				{
				if (Items.Count > 0)
					{
					Items[0].Selected = true;

					EnsureVisible(Items[0].Index);
					}
				}

			Populating = false;
			}

		//============================================================================*
		// SetChargeData()
		//============================================================================*

		public void SetChargeData(ListViewItem Item, cCharge Charge)
			{
			Item.SubItems.Clear();

			Item.Text = String.Format(Charge.ToString());

			Item.Tag = Charge;

			Item.SubItems.Add(Charge.TestList.Count > 0 ? String.Format("{0:G}", Charge.TestList.Count) : "-");
			Item.SubItems.Add(Charge.FillRatio != 0.0 ? String.Format("{0:F2}", Charge.FillRatio) : "-");
			Item.SubItems.Add(Charge.Favorite ? "Y" : "");
			Item.SubItems.Add(Charge.Reject ? "Y" : "");
			}
		}
	}
