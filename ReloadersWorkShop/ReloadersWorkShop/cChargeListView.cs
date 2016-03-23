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

		private string m_strFirearmFormat = "{0:F0}";
		private string m_strGroupFormat = "{0:F2}";
		private string m_strPowderWeightFormat = "{0:F1}";


		private cListViewColumn[] m_arColumns = new cListViewColumn[]
			{
			new cListViewColumn(0, "SourceHeader", "Source", HorizontalAlignment.Left, 150),
			new cListViewColumn(1, "ChargeHeader","Charge", HorizontalAlignment.Center, 110),
			new cListViewColumn(2, "FirearmHeader", "Firearm", HorizontalAlignment.Left, 120),
			new cListViewColumn(3, "BarrelHeader", "Bbl Len.", HorizontalAlignment.Center, 80),
			new cListViewColumn(4, "TwistHeader", "Twist", HorizontalAlignment.Center, 80),
			new cListViewColumn(5, "VelocityHeader", "Velocity", HorizontalAlignment.Center, 80),
			new cListViewColumn(6, "PressureHeader", "Pressure", HorizontalAlignment.Center, 80),
			new cListViewColumn(7, "GroupHeader", "BestGroup", HorizontalAlignment.Center, 80),
			new cListViewColumn(8, "RangeHeader", "Range", HorizontalAlignment.Center, 80)
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

			ImageList ChargeListImageList = new ImageList();

			Bitmap FavoriteBitmap = Properties.Resources.Favorite;
			FavoriteBitmap.MakeTransparent(Color.White);

			Bitmap RejectBitmap = Properties.Resources.Reject;
			RejectBitmap.MakeTransparent(Color.White);

			ChargeListImageList.Images.Add(FavoriteBitmap);
			ChargeListImageList.Images.Add(RejectBitmap);

			SmallImageList = ChargeListImageList;
			LargeImageList = ChargeListImageList;

			//----------------------------------------------------------------------------*
			// Populate Columns and Groups
			//----------------------------------------------------------------------------*

			SortingOrder = m_DataFiles.Preferences.ChargeSortOrder;

			SortingColumn = m_DataFiles.Preferences.ChargeSortColumn;

			m_arColumns[1].Text += String.Format(" ({0})", m_DataFiles.MetricString(cDataFiles.eDataType.PowderWeight));
			m_arColumns[3].Text += String.Format(" ({0})", m_DataFiles.MetricString(cDataFiles.eDataType.Firearm));
			m_arColumns[5].Text += String.Format(" ({0})", m_DataFiles.MetricString(cDataFiles.eDataType.Velocity));
			m_arColumns[7].Text += String.Format(" ({0})", m_DataFiles.MetricString(cDataFiles.eDataType.GroupSize));
			m_arColumns[8].Text += String.Format(" ({0})", m_DataFiles.MetricString(cDataFiles.eDataType.Range));

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
			//----------------------------------------------------------------------------*
			// Create the ListViewItem
			//----------------------------------------------------------------------------*

			ListViewItem Item = null;
			
			if (Charge.TestList.Count == 0)
				{
				Item = new ListViewItem("No test data available");

				Item.Tag = Charge;

				Item.SubItems.Add(Charge.ToString());

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
				}
			else
				{
				foreach (cChargeTest ChargeTest in Charge.TestList)
					{
					if (ChargeTest.BatchID != 0)
						continue;

					Item = new ListViewItem(ChargeTest.Source);

					Item.Tag = Charge;

//					Item.SubItems.Add(String.Format(m_strPowderWeightFormat, m_DataFiles.StandardToMetric(Charge.PowderWeight, cDataFiles.eDataType.PowderWeight)));
					Item.SubItems.Add(Charge.ToString());

					if (ChargeTest.Firearm == null)
						Item.SubItems.Add("Factory");
					else
						Item.SubItems.Add(ChargeTest.Firearm.ToString());

					Item.SubItems.Add(String.Format(m_strFirearmFormat, m_DataFiles.StandardToMetric(ChargeTest.BarrelLength, cDataFiles.eDataType.Firearm)));

					string strFormat = "1:" + m_strFirearmFormat + " {1}";

					Item.SubItems.Add(String.Format(strFormat, m_DataFiles.StandardToMetric(ChargeTest.Twist, cDataFiles.eDataType.Firearm), m_DataFiles.Preferences.MetricFirearms ? "cm" : "in"));
					Item.SubItems.Add(String.Format("{0:N0}", m_DataFiles.StandardToMetric(ChargeTest.MuzzleVelocity, cDataFiles.eDataType.Velocity)));
					Item.SubItems.Add(String.Format("{0:N0}", ChargeTest.Pressure));
					Item.SubItems.Add(String.Format(m_strGroupFormat, m_DataFiles.StandardToMetric(ChargeTest.BestGroup, cDataFiles.eDataType.GroupSize)));
					Item.SubItems.Add(String.Format("{0:N0}", m_DataFiles.StandardToMetric(ChargeTest.BestGroupRange, cDataFiles.eDataType.Range)));

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
					}
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

			m_strFirearmFormat = "{0:F";
			m_strFirearmFormat += String.Format("{0:G0}", m_DataFiles.Preferences.FirearmDecimals);
			m_strFirearmFormat += "}";

			m_strGroupFormat = "{0:F";
			m_strGroupFormat += String.Format("{0:G0}", m_DataFiles.Preferences.GroupDecimals);
			m_strGroupFormat += "}";

			m_strPowderWeightFormat = "{0:F";
			m_strPowderWeightFormat += String.Format("{0:G0}", m_DataFiles.Preferences.PowderWeightDecimals);
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

				m_DataFiles.Preferences.LastChargeSelected = (cCharge)Items[0].Tag;

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
		}
	}
