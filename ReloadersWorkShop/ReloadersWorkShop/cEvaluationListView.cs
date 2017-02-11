//============================================================================*
// cEvaluationListView.cs
//
// Copyright © 2013-2017, Kevin S. Beebe
// All Rights Reserved
//============================================================================*

//============================================================================*
// .Net Using Statements
//============================================================================*

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

using ReloadersWorkShop.Preferences;

//============================================================================*
// NameSpace
//============================================================================*

namespace ReloadersWorkShop
	{
	//============================================================================*
	// cEvaluationListView Class
	//============================================================================*

	public class cEvaluationListView : cListView
		{
		//============================================================================*
		// Private Data Members
		//============================================================================*

		private cDataFiles m_DataFiles = null;
		private cLoadList m_LoadList = null;

		//----------------------------------------------------------------------------*
		// Filters
		//----------------------------------------------------------------------------*

		bool m_fFactoryTest = false;
		bool m_fAmmo = false;

		cCaliber m_Caliber = null;
		cBullet m_Bullet = null;
		cPowder m_Powder = null;
		cPrimer m_Primer = null;
		cCase m_Case = null;

		//----------------------------------------------------------------------------*
		// Column Headers
		//----------------------------------------------------------------------------*

		private cListViewColumn[] m_arColumns = new cListViewColumn[]
			{
			new cListViewColumn(0, "SourceHeader","Source", HorizontalAlignment.Left, 100),
			new cListViewColumn(1, "CaliberHeader","Caliber", HorizontalAlignment.Left, 120),
			new cListViewColumn(2, "BulletHeader","Bullet", HorizontalAlignment.Left, 200),
			new cListViewColumn(3, "PowderHeader", "Powder", HorizontalAlignment.Left, 160),
			new cListViewColumn(4, "ChargeHeader", "Charge", HorizontalAlignment.Center, 80),
			new cListViewColumn(5, "PrimerHeader", "Primer", HorizontalAlignment.Left, 160),
			new cListViewColumn(6, "CaseHeader", "Case", HorizontalAlignment.Left, 160),
			new cListViewColumn(7, "BestGroupHeader", "Best Group", HorizontalAlignment.Center, 80),
			new cListViewColumn(8, "MOAHeader", "MOA", HorizontalAlignment.Center, 80),
			new cListViewColumn(9, "RangeHeader", "Range", HorizontalAlignment.Center, 80),
			new cListViewColumn(10, "VelocityHeader", "Muzzle Velociy", HorizontalAlignment.Center, 80),
			new cListViewColumn(11, "DeviationHeader", "Max Deviation", HorizontalAlignment.Center, 100),
			new cListViewColumn(12, "StdDeviationHeader", "Std Deviation", HorizontalAlignment.Center, 100),
			};

		//============================================================================*
		// cEvaluationListView() - Constructor
		//============================================================================*

		public cEvaluationListView(cDataFiles DataFiles, cLoadList LoadList, bool fFactoryTest = false, bool fAmmo = false)
			: base(DataFiles, cPreferences.eApplicationListView.LoadDataListView)
			{
			m_DataFiles = DataFiles;

			m_LoadList = LoadList;

			m_fFactoryTest = fFactoryTest;
			m_fAmmo = fAmmo;

			//----------------------------------------------------------------------------*
			// Set Properties
			//----------------------------------------------------------------------------*

			AllowColumnReorder = false;
			CheckBoxes = false;

			//----------------------------------------------------------------------------*
			// Event Handlers
			//----------------------------------------------------------------------------*

			ListViewItemSorter = new cListViewEvaluationComparer(m_DataFiles, m_DataFiles.Preferences.EvaluationSortColumn, m_DataFiles.Preferences.EvaluationSortOrder);

			//----------------------------------------------------------------------------*
			// Populate Columns and Groups
			//----------------------------------------------------------------------------*

			PopulateColumns(m_arColumns);

			SortingOrder = m_DataFiles.Preferences.EvaluationSortOrder;

			SortingColumn = m_DataFiles.Preferences.EvaluationSortColumn;

			Populate();

			Initialized = true;
			}

		//============================================================================*
		// AddLoad()
		//============================================================================*

		public void AddLoad(cLoad Load)
			{
			if (!VerifyLoad(Load))
				return;

			//----------------------------------------------------------------------------*
			// Add the load test item to the list and exit
			//----------------------------------------------------------------------------*

			SetLoadData(Load);
			}

		//============================================================================*
		// Bullet Property
		//============================================================================*

		public cBullet Bullet
			{
			get
				{
				return (m_Bullet);
				}

			set
				{
				m_Bullet = value;

				Populate();
				}
			}

		//============================================================================*
		// Caliber Property
		//============================================================================*

		public cCaliber Caliber
			{
			get
				{
				return (m_Caliber);
				}

			set
				{
				m_Caliber = value;

				Populate();
				}
			}

		//============================================================================*
		// Case Property
		//============================================================================*

		public cCase Case
			{
			get
				{
				return (m_Case);
				}

			set
				{
				m_Case = value;

				Populate();
				}
			}

		//============================================================================*
		// FactoryTest Property
		//============================================================================*

		public bool FactoryTest
			{
			get
				{
				return (m_fFactoryTest);
				}

			set
				{
				m_fFactoryTest = value;

				Populate();
				}
			}

		//============================================================================*
		// OnColumnClick()
		//============================================================================*

		protected override void OnColumnClick(ColumnClickEventArgs args)
			{
			if (args.Column == m_DataFiles.Preferences.EvaluationSortColumn)
				{
				SortingOrder = (SortingOrder == SortOrder.Ascending) ? SortOrder.Descending : SortOrder.Ascending;

				m_DataFiles.Preferences.EvaluationSortOrder = SortingOrder;

				ListViewItemSorter = new cListViewEvaluationComparer(m_DataFiles, m_DataFiles.Preferences.EvaluationSortColumn, m_DataFiles.Preferences.EvaluationSortOrder);
				}
			else
				{
				SortingColumn = args.Column;

				m_DataFiles.Preferences.EvaluationSortColumn = SortingColumn;

				ListViewItemSorter = new cListViewEvaluationComparer(m_DataFiles, SortingColumn, SortingOrder);
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

			Items.Clear();

			//----------------------------------------------------------------------------*
			// Add Loads to LoadsListView
			//----------------------------------------------------------------------------*

			foreach (cLoad Load in m_LoadList)
				AddLoad(Load);

			Populating = false;
			}

		//============================================================================*
		// Powder Property
		//============================================================================*

		public cPowder Powder
			{
			get
				{
				return (m_Powder);
				}

			set
				{
				m_Powder = value;

				Populate();
				}
			}

		//============================================================================*
		// Primer Property
		//============================================================================*

		public cPrimer Primer
			{
			get
				{
				return (m_Primer);
				}

			set
				{
				m_Primer = value;

				Populate();
				}
			}

		//============================================================================*
		// SetLoadData()
		//============================================================================*

		public void SetLoadData(cLoad Load)
			{
			//----------------------------------------------------------------------------*
			// Create the format strings
			//----------------------------------------------------------------------------*

			string strChargeFormat = "{0:F";
			strChargeFormat += String.Format("{0:G0}", m_DataFiles.Preferences.PowderWeightDecimals);
			strChargeFormat += "}";

			string strGroupFormat = "{0:F";
			strGroupFormat += String.Format("{0:G0}", m_DataFiles.Preferences.GroupDecimals);
			strGroupFormat += "}";

			//----------------------------------------------------------------------------*
			// Loop through the charges
			//----------------------------------------------------------------------------*

			foreach (cCharge Charge in Load.ChargeList)
				{
				//----------------------------------------------------------------------------*
				// Loop through the charge tests
				//----------------------------------------------------------------------------*

				foreach (cChargeTest ChargeTest in Charge.TestList)
					{
					if (ChargeTest.BatchID == 0 && !m_fFactoryTest)
						continue;

					//----------------------------------------------------------------------------*
					// Create the ListViewItem
					//----------------------------------------------------------------------------*

					ListViewItem Item = new ListViewItem();

					//----------------------------------------------------------------------------*
					// Set the ListViewItem Data
					//----------------------------------------------------------------------------*

					Item.Text = (ChargeTest.BatchID != 0) ? String.Format("Batch #{0:G0}", ChargeTest.BatchID) : ChargeTest.Source;

					Item.Tag = new cEvaluationItem(Load, Charge, ChargeTest);

					Item.SubItems.Add(Load.Caliber.ToString());
					Item.SubItems.Add(Load.Bullet.ToString());
					Item.SubItems.Add(Load.Powder.ToString());
					Item.SubItems.Add(String.Format(strChargeFormat, cDataFiles.StandardToMetric(Charge.PowderWeight, cDataFiles.eDataType.PowderWeight)));
					Item.SubItems.Add(Load.Primer.ToShortString());
					Item.SubItems.Add(Load.Case.ToShortString());

					if (ChargeTest.BestGroup == 0.0)
						Item.SubItems.Add("-");
					else
						Item.SubItems.Add(String.Format(strGroupFormat, cDataFiles.StandardToMetric( ChargeTest.BestGroup, cDataFiles.eDataType.GroupSize)));

					if (ChargeTest.BestGroupRange == 0.0)
						{
						Item.SubItems.Add("-");
						Item.SubItems.Add("-");
						}
					else
						{
						Item.SubItems.Add(String.Format("{0:F3}", ChargeTest.BestGroup / ((double) ((double) ChargeTest.BestGroupRange / 100.0) * 1.047)));
						Item.SubItems.Add(String.Format("{0:N0}", cDataFiles.StandardToMetric(ChargeTest.BestGroupRange, cDataFiles.eDataType.Range)));
						}

					if (ChargeTest.MuzzleVelocity == 0)
						Item.SubItems.Add("-");
					else
						Item.SubItems.Add(String.Format("{0:N0}", cDataFiles.StandardToMetric(ChargeTest.MuzzleVelocity, cDataFiles.eDataType.Velocity)));

					cBatch Batch = m_DataFiles.GetBatchByID(ChargeTest.BatchID);

					if (Batch == null || Batch.BatchTest == null || Batch.BatchTest.TestShotList == null)
						{
						Item.SubItems.Add("-");
						Item.SubItems.Add("-");
						}
					else
						{
						cTestStatistics Statistics = new cTestStatistics(Batch.BatchTest.TestShotList);

						if (Statistics.MaxDeviation == 0)
							Item.SubItems.Add("-");
						else
							Item.SubItems.Add(String.Format("{0:N0}", cDataFiles.StandardToMetric(Statistics.MaxDeviation, cDataFiles.eDataType.Velocity)));

						if (Statistics.StdDev == 0.0)
							Item.SubItems.Add("-");
						else
							Item.SubItems.Add(String.Format("{0:F2}", cDataFiles.StandardToMetric(Statistics.StdDev, cDataFiles.eDataType.Velocity)));
						}

					//----------------------------------------------------------------------------*
					// Add the item to the list
					//----------------------------------------------------------------------------*

					AddItem(Item);
					}
				}
			}

		//============================================================================*
		// VerifyLoad()
		//============================================================================*

		public bool VerifyLoad(cLoad Load)
			{
			if (m_Caliber != null && Load.Caliber.CompareTo(m_Caliber) != 0)
				return (false);

			if (m_Bullet != null && Load.Bullet.CompareTo(m_Bullet) != 0)
				return (false);

			if (m_Powder != null && Load.Powder.CompareTo(m_Powder) != 0)
				return (false);

			if (m_Primer != null && Load.Primer.CompareTo(m_Primer) != 0)
				return (false);

			if (m_Case != null && Load.Case.CompareTo(m_Case) != 0)
				return (false);

			return (true);
			}
		}
	}
