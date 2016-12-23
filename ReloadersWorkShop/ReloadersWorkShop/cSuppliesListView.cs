//============================================================================*
// cSuppliesListView.cs
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
	// cSuppliesListView Class
	//============================================================================*

	public class cSuppliesListView : cListView
		{
		//============================================================================*
		// Private Data Members
		//============================================================================*

		private cDataFiles m_DataFiles = null;

		private cSupply.eSupplyTypes m_eSupplyType = cSupply.eSupplyTypes.Bullets;
		private cFirearm.eFireArmType m_eFirearmTypeFilter = cFirearm.eFireArmType.None;
		private cManufacturer m_ManufacturerFilter = null;
		private bool m_fNonZeroFilter = false;
		private bool m_fMinStockFilter = false;
		private bool m_fCheckedFilter = false;

		private string m_strDimensionFormat = "{0:F3}";
		private string m_strBulletWeightFormat = "{0:F1}";
		private string m_strCanWeightFormat = "{0:F0}";

		//============================================================================*
		// cSuppliesListView() - Constructor
		//============================================================================*

		public cSuppliesListView(cDataFiles DataFiles)
			: base(DataFiles, cPreferences.eApplicationListView.BulletSuppliesListView)
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
			// Populate Groups
			//----------------------------------------------------------------------------*

			PopulateGroups();

			//----------------------------------------------------------------------------*
			// Set Supply Type
			//----------------------------------------------------------------------------*

			SupplyType = m_DataFiles.Preferences.LastSupplyTypeSelected;

			Initialized = true;
			}

		//============================================================================*
		// AddBullet()
		//============================================================================*

		public ListViewItem AddBullet(cBullet Bullet, bool fSelect = false)
			{
			//----------------------------------------------------------------------------*
			// Input Verification
			//----------------------------------------------------------------------------*

			if (m_eSupplyType != cSupply.eSupplyTypes.Bullets)
				return (null);

			if (!VerifyBullet(Bullet))
				return (null);

			//----------------------------------------------------------------------------*
			// Create and Add the Item
			//----------------------------------------------------------------------------*

			ListViewItem Item = new ListViewItem();

			SetBulletData(Item, Bullet);

			AddItem(Item, fSelect);

			return (Item);
			}

		//============================================================================*
		// AddCase()
		//============================================================================*

		public ListViewItem AddCase(cCase Case, bool fSelect = false)
			{
			//----------------------------------------------------------------------------*
			// Input Verification
			//----------------------------------------------------------------------------*

			if (m_eSupplyType != cSupply.eSupplyTypes.Cases)
				return (null);

			if (!VerifyCase(Case))
				return (null);

			//----------------------------------------------------------------------------*
			// Create the ListViewItem
			//----------------------------------------------------------------------------*

			ListViewItem Item = new ListViewItem();

			SetCaseData(Item, Case);

			AddItem(Item, fSelect);

			return (Item);
			}

		//============================================================================*
		// AddPowder()
		//============================================================================*

		public ListViewItem AddPowder(cPowder Powder, bool fSelect = false)
			{
			if (m_eSupplyType != cSupply.eSupplyTypes.Powder)
				return (null);

			if (!VerifyPowder(Powder))
				return (null);

			//----------------------------------------------------------------------------*
			// Create the ListViewItem
			//----------------------------------------------------------------------------*

			ListViewItem Item = new ListViewItem();

			SetPowderData(Item, Powder);

			AddItem(Item, fSelect);

			return (Item);
			}

		//============================================================================*
		// AddPrimer()
		//============================================================================*

		public ListViewItem AddPrimer(cPrimer Primer, bool fSelect = false)
			{
			if (m_eSupplyType != cSupply.eSupplyTypes.Primers)
				return (null);

			if (!VerifyPrimer(Primer))
				return (null);

			//----------------------------------------------------------------------------*
			// Create the ListViewItem
			//----------------------------------------------------------------------------*

			ListViewItem Item = new ListViewItem();

			SetPrimerData(Item, Primer);

			AddItem(Item, fSelect);

			return (Item);
			}

		//============================================================================*
		// CheckedFilter Property
		//============================================================================*

		public bool CheckedFilter
			{
			get
				{
				return (m_fCheckedFilter);
				}
			set
				{
				m_fCheckedFilter = value;
				}
			}

		//============================================================================*
		// FirearmTypeFilter Property
		//============================================================================*

		public cFirearm.eFireArmType FirearmTypeFilter
			{
			get
				{
				return (m_eFirearmTypeFilter);
				}
			set
				{
				m_eFirearmTypeFilter = value;
				}
			}

		//============================================================================*
		// HandgunCount Property
		//============================================================================*

		public int HandgunCount
			{
			get
				{
				int nCount = 0;

				foreach (ListViewItem Item in Items)
					{
					cSupply Supply = (cSupply) Item.Tag;

					if (Supply != null && Supply.FirearmType == cFirearm.eFireArmType.Handgun)
						nCount++;
					}

				return (nCount);
				}
			}

		//============================================================================*
		// ManufacturerFilter Property
		//============================================================================*

		public cManufacturer ManufacturerFilter
			{
			get
				{
				return (m_ManufacturerFilter);
				}
			set
				{
				m_ManufacturerFilter = value;
				}
			}

		//============================================================================*
		// MinStockFilter Property
		//============================================================================*

		public bool MinStockFilter
			{
			get
				{
				return (m_fMinStockFilter);
				}
			set
				{
				m_fMinStockFilter = value;
				}
			}

		//============================================================================*
		// NonZeroFilter Property
		//============================================================================*

		public bool NonZeroFilter
			{
			get
				{
				return (m_fNonZeroFilter);
				}
			set
				{
				m_fNonZeroFilter = value;
				}
			}

		//============================================================================*
		// OnColumnClick()
		//============================================================================*

		protected override void OnColumnClick(ColumnClickEventArgs args)
			{
			switch (m_eSupplyType)
				{
				case cSupply.eSupplyTypes.Bullets:
					if (args.Column == SortingColumn)
						{
						SortingOrder = (SortingOrder == SortOrder.Ascending) ? SortOrder.Descending : SortOrder.Ascending;

						m_DataFiles.Preferences.BulletSortOrder = SortingOrder;
						}
					else
						{
						SortingColumn = args.Column;

						m_DataFiles.Preferences.BulletSortColumn = args.Column;

						this.Invalidate(true);
						}

					ListViewItemSorter = new cListViewBulletComparer(m_DataFiles, SortingColumn, SortingOrder);

					break;

				case cSupply.eSupplyTypes.Cases:
					if (args.Column == SortingColumn)
						{
						SortingOrder = (SortingOrder == SortOrder.Ascending) ? SortOrder.Descending : SortOrder.Ascending;

						m_DataFiles.Preferences.CaseSortOrder = SortingOrder;
						}
					else
						{
						SortingColumn = args.Column;

						m_DataFiles.Preferences.CaseSortColumn = args.Column;

						this.Invalidate(true);
						}

					ListViewItemSorter = new cListViewCaseComparer(m_DataFiles, SortingColumn, SortingOrder);

					break;

				case cSupply.eSupplyTypes.Powder:
					if (args.Column == SortingColumn)
						{
						SortingOrder = (SortingOrder == SortOrder.Ascending) ? SortOrder.Descending : SortOrder.Ascending;

						m_DataFiles.Preferences.PowderSortOrder = SortingOrder;
						}
					else
						{
						SortingColumn = args.Column;

						m_DataFiles.Preferences.PowderSortColumn = args.Column;

						this.Invalidate(true);
						}

					ListViewItemSorter = new cListViewPowderComparer(m_DataFiles, SortingColumn, SortingOrder);

					break;

				case cSupply.eSupplyTypes.Primers:
					if (args.Column == SortingColumn)
						{
						SortingOrder = (SortingOrder == SortOrder.Ascending) ? SortOrder.Descending : SortOrder.Ascending;

						m_DataFiles.Preferences.PrimerSortOrder = SortingOrder;
						}
					else
						{
						SortingColumn = args.Column;

						m_DataFiles.Preferences.PrimerSortColumn = args.Column;

						this.Invalidate(true);
						}

					ListViewItemSorter = new cListViewPrimerComparer(m_DataFiles, SortingColumn, SortingOrder);

					break;
				}

			if (SelectedItems.Count > 0)
				SelectedItems[0].EnsureVisible();
			}

		//============================================================================*
		// Populate()
		//============================================================================*

		public override void Populate()
			{
			m_strCanWeightFormat = "{0:F";
			m_strCanWeightFormat += String.Format("{0:G0}", m_DataFiles.Preferences.CanWeightDecimals);
			m_strCanWeightFormat += "}";

			m_strDimensionFormat = "{0:F";
			m_strDimensionFormat += String.Format("{0:G0}", m_DataFiles.Preferences.DimensionDecimals);
			m_strDimensionFormat += "}";

			m_strBulletWeightFormat = "{0:F";
			m_strBulletWeightFormat += String.Format("{0:G0}", m_DataFiles.Preferences.BulletWeightDecimals);
			m_strBulletWeightFormat += "}";

			Populating = true;

			Items.Clear();

			ListViewItem SelectItem = null;
			ListViewItem Item = null;

			switch (m_eSupplyType)
				{
				//----------------------------------------------------------------------------*
				// Bullets
				//----------------------------------------------------------------------------*

				case cSupply.eSupplyTypes.Bullets:
					foreach (cSupply Supply in m_DataFiles.BulletList)
						{
						if ((Supply.CrossUse || m_eFirearmTypeFilter == cFirearm.eFireArmType.None || Supply.FirearmType == m_eFirearmTypeFilter) &&
							(m_ManufacturerFilter == null || Supply.Manufacturer.CompareTo(m_ManufacturerFilter) == 0) &&
							(!m_fNonZeroFilter || m_DataFiles.SupplyQuantity(Supply) > 0.0) &&
							(!m_fMinStockFilter || m_DataFiles.SupplyQuantity(Supply) < Supply.MinimumStockLevel) &&
							(!m_fCheckedFilter || Supply.Checked))
							{
							Item = AddBullet(Supply as cBullet);

							if (Item != null)
								{
								if (m_DataFiles.Preferences.LastBulletSelected != null && m_DataFiles.Preferences.LastBulletSelected.CompareTo(Supply as cBullet) == 0)
									SelectItem = Item;
								}
							}
						}

					break;

				//----------------------------------------------------------------------------*
				// Cases
				//----------------------------------------------------------------------------*

				case cSupply.eSupplyTypes.Cases:
					foreach (cSupply Supply in m_DataFiles.CaseList)
						{
						if ((Supply.CrossUse || m_eFirearmTypeFilter == cFirearm.eFireArmType.None || Supply.FirearmType == m_eFirearmTypeFilter) &&
							(m_ManufacturerFilter == null || Supply.Manufacturer.CompareTo(m_ManufacturerFilter) == 0) &&
							(!m_fNonZeroFilter || m_DataFiles.SupplyQuantity(Supply) > 0.0) &&
							(!m_fMinStockFilter || m_DataFiles.SupplyQuantity(Supply) < Supply.MinimumStockLevel) &&
							(!m_fCheckedFilter || Supply.Checked))
							{
							Item = AddCase(Supply as cCase);

							if (Item != null)
								{
								if (m_DataFiles.Preferences.LastCaseSelected != null && m_DataFiles.Preferences.LastCaseSelected.CompareTo(Supply as cCase) == 0)
									SelectItem = Item;
								}
							}
						}

					break;

				//----------------------------------------------------------------------------*
				// Powder
				//----------------------------------------------------------------------------*

				case cSupply.eSupplyTypes.Powder:
					foreach (cSupply Supply in m_DataFiles.PowderList)
						{
						if ((Supply.CrossUse || m_eFirearmTypeFilter == cFirearm.eFireArmType.None || Supply.FirearmType == m_eFirearmTypeFilter) &&
							(m_ManufacturerFilter == null || Supply.Manufacturer.CompareTo(m_ManufacturerFilter) == 0) &&
							(!m_fNonZeroFilter || m_DataFiles.SupplyQuantity(Supply) > 0.0) &&
							(!m_fMinStockFilter || m_DataFiles.SupplyQuantity(Supply) < Supply.MinimumStockLevel) &&
							(!m_fCheckedFilter || Supply.Checked))
							{
							Item = AddPowder(Supply as cPowder);

							if (Item != null)
								{
								if (m_DataFiles.Preferences.LastPowderSelected != null && m_DataFiles.Preferences.LastPowderSelected.CompareTo(Supply as cPowder) == 0)
									SelectItem = Item;
								}
							}
						}

					break;

				//----------------------------------------------------------------------------*
				// Primers
				//----------------------------------------------------------------------------*

				case cSupply.eSupplyTypes.Primers:
					foreach (cSupply Supply in m_DataFiles.PrimerList)
						{
						if ((Supply.CrossUse || m_eFirearmTypeFilter == cFirearm.eFireArmType.None || Supply.FirearmType == m_eFirearmTypeFilter) &&
							(m_ManufacturerFilter == null || Supply.Manufacturer.CompareTo(m_ManufacturerFilter) == 0) &&
							(!m_fNonZeroFilter || m_DataFiles.SupplyQuantity(Supply) > 0.0) &&
							(!m_fMinStockFilter || m_DataFiles.SupplyQuantity(Supply) < Supply.MinimumStockLevel) &&
							(!m_fCheckedFilter || Supply.Checked))
							{
							Item = AddPrimer(Supply as cPrimer);

							if (Item != null)
								{
								if (m_DataFiles.Preferences.LastPrimerSelected != null && m_DataFiles.Preferences.LastPrimerSelected.CompareTo(Supply as cPrimer) == 0)
									SelectItem = Item;
								}
							}
						}

					break;
				}

			if (SelectItem != null)
				{
				Focus();

				SelectItem.Selected = true;

				EnsureVisible(SelectItem.Index);
				}
			else
				{
				if (Items.Count > 0)
					{
					Items[0].Selected = true;

					EnsureVisible(0);
					}
				}

			Populating = false;
			}

		//============================================================================*
		// PopulateColumns()
		//============================================================================*

		public void PopulateColumns(bool fPopulate = true)
			{
			Populating = true;

			//----------------------------------------------------------------------------*
			// Columns
			//----------------------------------------------------------------------------*

			cListViewColumn[] arColumns = null;

			switch (m_eSupplyType)
				{
				//----------------------------------------------------------------------------*
				// Bullets
				//----------------------------------------------------------------------------*

				case cSupply.eSupplyTypes.Bullets:
					arColumns = new cListViewColumn[]
						{
						new cListViewColumn(0, "ManufacturerHeader","Manufacturer", HorizontalAlignment.Left, 140),
						new cListViewColumn(1, "PartHeader","Part #", HorizontalAlignment.Left, 90),
						new cListViewColumn(2, "TypeHeader","Type", HorizontalAlignment.Left, 160),
						new cListViewColumn(3, "CrossHeader","Cross Use?", HorizontalAlignment.Center, 110),
						new cListViewColumn(4, "DiameterHeader", String.Format("Diameter ({0})", cDataFiles.MetricString(cDataFiles.eDataType.Dimension)), HorizontalAlignment.Center, 120),
						new cListViewColumn(5, "WeightHeader", String.Format("Weight ({0})", cDataFiles.MetricString(cDataFiles.eDataType.BulletWeight)), HorizontalAlignment.Center, 120),
						new cListViewColumn(6, "LengthHeader", String.Format("Length ({0})", cDataFiles.MetricString(cDataFiles.eDataType.Dimension)), HorizontalAlignment.Center, 120),
						new cListViewColumn(7, "BCHeader", "B.C.", HorizontalAlignment.Center, 70),
						new cListViewColumn(8, "SDHeader", "S.D.", HorizontalAlignment.Center, 70),
						new cListViewColumn(9, "NumCalibersHeader", "# Calibers", HorizontalAlignment.Center, 100),
						new cListViewColumn(10, "SelfCastHeader", "Self Cast", HorizontalAlignment.Center, 100),
						new cListViewColumn(11, "TopPunchHeader", "Top Punch", HorizontalAlignment.Center, 80),
						new cListViewColumn(12, "QtyHeader", (m_DataFiles.Preferences.TrackInventory) ? "Qty on Hand" : "Box of", HorizontalAlignment.Center, 80),
						new cListViewColumn(13, "CostHeader", (m_DataFiles.Preferences.TrackInventory) ? String.Format("Value ({0})", m_DataFiles.Preferences.Currency) : String.Format("Cost ({0})", m_DataFiles.Preferences.Currency), HorizontalAlignment.Right, 80)
						};

					base.PopulateColumns(arColumns);

					break;

				//----------------------------------------------------------------------------*
				// Cases
				//----------------------------------------------------------------------------*

				case cSupply.eSupplyTypes.Cases:
					arColumns = new cListViewColumn[]
						{
						new cListViewColumn(0, "ManufacturerHeader","Manufacturer", HorizontalAlignment.Left, 140),
						new cListViewColumn(1, "PartNumberHeader","Part Number", HorizontalAlignment.Left, 140),
						new cListViewColumn(2, "CaliberHeader","Caliber", HorizontalAlignment.Left, 140),
						new cListViewColumn(3, "PrimerHeader","Primer", HorizontalAlignment.Left, 100),
						new cListViewColumn(4, "HeadStampHeader","HeadStamp", HorizontalAlignment.Left, 140),
						new cListViewColumn(5, "CrossHeader","Cross Use?", HorizontalAlignment.Center, 110),
						new cListViewColumn(6, "MatchHeader","Match", HorizontalAlignment.Left, 70),
						new cListViewColumn(7, "MilitaryHeader","Military", HorizontalAlignment.Left, 70),
						new cListViewColumn(8, "QtyHeader", (m_DataFiles.Preferences.TrackInventory) ? "Qty on Hand" : "Box of", HorizontalAlignment.Center, 80),
						new cListViewColumn(9, "CostHeader", (m_DataFiles.Preferences.TrackInventory) ? String.Format("Value ({0})", m_DataFiles.Preferences.Currency) : String.Format("Cost ({0})", m_DataFiles.Preferences.Currency), HorizontalAlignment.Right, 80)
						};

					base.PopulateColumns(arColumns);

					break;

				//----------------------------------------------------------------------------*
				// Powder
				//----------------------------------------------------------------------------*

				case cSupply.eSupplyTypes.Powder:
					string strQuantity = (m_DataFiles.Preferences.TrackInventory) ? "Qty on Hand" : "Can of";
					strQuantity += String.Format(" ({0}s)", cDataFiles.MetricString(cDataFiles.eDataType.CanWeight));

					arColumns = new cListViewColumn[]
						{
						new cListViewColumn(0, "ManufacturerHeader","Manufacturer", HorizontalAlignment.Left, 140),
						new cListViewColumn(1, "TypeHeader","Type", HorizontalAlignment.Left, 120),
						new cListViewColumn(2, "ShapeHeader","Shape", HorizontalAlignment.Center, 100),
						new cListViewColumn(3, "CrossHeader","Cross Use?", HorizontalAlignment.Center, 110),
						new cListViewColumn(4, "QtyHeader", strQuantity, HorizontalAlignment.Center, 80),
						new cListViewColumn(5, "CostHeader", (m_DataFiles.Preferences.TrackInventory) ? String.Format("Value ({0})", m_DataFiles.Preferences.Currency) : String.Format("Cost ({0})", m_DataFiles.Preferences.Currency), HorizontalAlignment.Right, 80)
						};

					base.PopulateColumns(arColumns);

					break;

				//----------------------------------------------------------------------------*
				// Primers
				//----------------------------------------------------------------------------*

				case cSupply.eSupplyTypes.Primers:
					arColumns = new cListViewColumn[]
						{
						new cListViewColumn(0, "ManufacturerHeader","Manufacturer", HorizontalAlignment.Left, 140),
						new cListViewColumn(1, "ModelHeader", "Model", HorizontalAlignment.Left, 140),
						new cListViewColumn(2, "SizeHeader", "Size", HorizontalAlignment.Left, 120),
						new cListViewColumn(3, "CrossHeader","Cross Use?", HorizontalAlignment.Center, 110),
						new cListViewColumn(4, "StandardHeader", "Standard", HorizontalAlignment.Center, 120),
						new cListViewColumn(5, "MagnumHeader", "Magnum", HorizontalAlignment.Center, 120),
						new cListViewColumn(6, "BenchRestHeader", "Bench Rest", HorizontalAlignment.Center, 120),
						new cListViewColumn(7, "MilitaryHeader", "Military", HorizontalAlignment.Center, 120),
						new cListViewColumn(8, "QtyHeader", (m_DataFiles.Preferences.TrackInventory) ? "Qty on Hand" : "Box of", HorizontalAlignment.Center, 80),
						new cListViewColumn(9, "CostHeader", (m_DataFiles.Preferences.TrackInventory) ? String.Format("Value ({0})", m_DataFiles.Preferences.Currency) : String.Format("Cost ({0})", m_DataFiles.Preferences.Currency), HorizontalAlignment.Right, 80)
						};

					base.PopulateColumns(arColumns);

					break;
				}

			//----------------------------------------------------------------------------*
			// m_SuppliesListView Columns
			//----------------------------------------------------------------------------*

			foreach (ColumnHeader Header in Columns)
				{
				cColumn Column = m_DataFiles.Preferences.GetColumn(ListViewType, Header.Text);

				if (Column != null)
					{
					if (Column.Width != -1)
						Header.Width = Column.Width;

					if (Column.DisplayIndex != -1)
						Header.DisplayIndex = Column.DisplayIndex;
					}
				}

			//----------------------------------------------------------------------------*
			// Populate the Data
			//----------------------------------------------------------------------------*

			Populating = false;

			if (fPopulate)
				Populate();
			}

		//============================================================================*
		// RifleCount Property
		//============================================================================*

		public int RifleCount
			{
			get
				{
				int nCount = 0;

				foreach (ListViewItem Item in Items)
					{
					cSupply Supply = (cSupply) Item.Tag;

					if (Supply != null && Supply.FirearmType == cFirearm.eFireArmType.Rifle)
						nCount++;
					}

				return (nCount);
				}
			}

		//============================================================================*
		// SetBulletData()
		//============================================================================*

		public void SetBulletData(ListViewItem Item, cBullet Bullet)
			{
			Item.SubItems.Clear();

			Item.Text = Bullet.Manufacturer.Name;

			Item.Group = Groups[(int) Bullet.FirearmType];
			Item.Tag = Bullet;

			if (Bullet.Checked)
				Item.Checked = true;

			Item.SubItems.Add(Bullet.PartNumber);
			Item.SubItems.Add(Bullet.Type);
			Item.SubItems.Add(Bullet.CrossUse ? "Y" : "");
			Item.SubItems.Add(String.Format(m_strDimensionFormat, cDataFiles.StandardToMetric(Bullet.Diameter, cDataFiles.eDataType.Dimension)));

			Item.SubItems.Add(String.Format(m_strBulletWeightFormat, cDataFiles.StandardToMetric(Bullet.Weight, cDataFiles.eDataType.BulletWeight)));

			if (Bullet.Length <= 0.0)
				Item.SubItems.Add("-");
			else
				Item.SubItems.Add(String.Format(m_strDimensionFormat, cDataFiles.StandardToMetric(Bullet.Length, cDataFiles.eDataType.Dimension)));

			Item.SubItems.Add(String.Format("{0:F3}", Bullet.BallisticCoefficient));
			Item.SubItems.Add(String.Format("{0:F3}", Bullet.SectionalDensity));
			Item.SubItems.Add(String.Format("{0:N0}", (Bullet.BulletCaliberList != null) ? Bullet.BulletCaliberList.Count : 0));
			Item.SubItems.Add(Bullet.SelfCast ? "Y" : "");
			Item.SubItems.Add(Bullet.SelfCast ? String.Format("{0:G}", Bullet.TopPunch) : "-");

			double dQuantity = m_DataFiles.SupplyQuantity(Bullet);
			double dCost = m_DataFiles.SupplyCost(Bullet);

			if (dQuantity == 0.0)
				{
				Item.SubItems.Add("-");
				Item.SubItems.Add("-");
				}
			else
				{
				Item.SubItems.Add(String.Format("{0:G0}", dQuantity));

				if (dCost == 0.0)
					Item.SubItems.Add("-");
				else
					Item.SubItems.Add(String.Format("{0:F2}", dCost));
				}
			}

		//============================================================================*
		// SetCaseData()
		//============================================================================*

		public void SetCaseData(ListViewItem Item, cCase Case)
			{
			Item.SubItems.Clear();

			cCaliber.CurrentFirearmType = Case.FirearmType;

			if (Case.Manufacturer == null)
				return;

			if (!Case.LargePrimer && !Case.SmallPrimer)
				{
				if (Case.Caliber.LargePrimer && Case.Caliber.SmallPrimer)
					Case.LargePrimer = true;
				else
					{
					Case.LargePrimer = Case.Caliber.LargePrimer;
					Case.SmallPrimer = Case.Caliber.SmallPrimer;
					}
				}

			Item.Text = Case.Manufacturer.Name;

			Item.Checked = Case.Checked;

			Item.Tag = Case;
			Item.Group = Groups[(int) Case.FirearmType];

			Item.SubItems.Add(Case.PartNumber);

			cCaliber.CurrentFirearmType = Case.Caliber.FirearmType;
			Item.SubItems.Add(Case.Caliber.ToString());

			Item.SubItems.Add(Case.SmallPrimer ? "Small" : "Large");
			Item.SubItems.Add(Case.HeadStamp);
			Item.SubItems.Add(Case.CrossUse ? "Y" : "");
			Item.SubItems.Add(Case.Match ? "Y" : "");
			Item.SubItems.Add(Case.Military ? "Y" : "");

			double dQuantity = m_DataFiles.SupplyQuantity(Case);
			double dCost = m_DataFiles.SupplyCost(Case);

			if (dQuantity == 0.0)
				{
				Item.SubItems.Add("-");
				Item.SubItems.Add("-");
				}
			else
				{
				Item.SubItems.Add(String.Format("{0:G0}", dQuantity));

				if (dCost == 0.0)
					Item.SubItems.Add("-");
				else
					Item.SubItems.Add(String.Format("{0:F2}", dCost));
				}
			}

		//============================================================================*
		// SetPowderData()
		//============================================================================*

		public void SetPowderData(ListViewItem Item, cPowder Powder)
			{
			Item.SubItems.Clear();

			Item.Text = Powder.Manufacturer.Name;

			Item.Checked = Powder.Checked;

			Item.Group = Groups[(int) Powder.FirearmType];
			Item.Tag = Powder;

			Item.SubItems.Add(Powder.Model);
			Item.SubItems.Add(cPowder.ShapeString(Powder.Shape));
			Item.SubItems.Add(Powder.CrossUse ? "Y" : "");

			double dQuantity = m_DataFiles.SupplyQuantity(Powder);

			dQuantity = cDataFiles.StandardToMetric(dQuantity / 7000.0, cDataFiles.eDataType.CanWeight);

			double dCost = m_DataFiles.SupplyCost(Powder);

			if (dQuantity == 0)
				{
				Item.SubItems.Add("-");
				Item.SubItems.Add("-");
				}
			else
				{
				Item.SubItems.Add(String.Format(m_strCanWeightFormat, dQuantity));

				if (dCost == 0.0)
					Item.SubItems.Add("-");
				else
					Item.SubItems.Add(String.Format("{0:F2}", dCost));
				}
			}

		//============================================================================*
		// SetPrimerData()
		//============================================================================*

		public void SetPrimerData(ListViewItem Item, cPrimer Primer)
			{
			Item.SubItems.Clear();

			Item.Text = Primer.Manufacturer.Name;

			Item.Checked = Primer.Checked;

			Item.Group = Groups[(int) Primer.FirearmType];
			Item.Tag = Primer;

			Item.SubItems.Add(Primer.Model);
			Item.SubItems.Add(Primer.SizeString);
			Item.SubItems.Add(Primer.CrossUse ? "Y" : "");
			Item.SubItems.Add((Primer.Standard) ? "Y" : "");
			Item.SubItems.Add((Primer.Magnum) ? "Y" : "");
			Item.SubItems.Add((Primer.BenchRest) ? "Y" : "");
			Item.SubItems.Add((Primer.Military) ? "Y" : "");

			double dQuantity = m_DataFiles.SupplyQuantity(Primer);
			double dCost = m_DataFiles.SupplyCost(Primer);

			if (dQuantity == 0.0)
				{
				Item.SubItems.Add("-");
				Item.SubItems.Add("-");
				}
			else
				{
				Item.SubItems.Add(String.Format("{0:G0}", dQuantity));

				if (dCost == 0.0)
					Item.SubItems.Add("-");
				else
					Item.SubItems.Add(String.Format("{0:F2}", dCost));
				}
			}

		//============================================================================*
		// SupplyType Property
		//============================================================================*

		public cSupply.eSupplyTypes SupplyType
			{
			get
				{
				return (m_eSupplyType);
				}
			set
				{
				Items.Clear();

				m_eSupplyType = value;

				m_DataFiles.Preferences.LastSupplyTypeSelected = m_eSupplyType;

				switch (m_eSupplyType)
					{
					case cSupply.eSupplyTypes.Bullets:
						ListViewType = cPreferences.eApplicationListView.BulletSuppliesListView;

						GridLines = false;
						SortingOrder = m_DataFiles.Preferences.BulletSortOrder;
						SortingColumn = m_DataFiles.Preferences.BulletSortColumn;

						ListViewItemSorter = new cListViewBulletComparer(m_DataFiles, SortingColumn, SortingOrder);

						break;

					case cSupply.eSupplyTypes.Cases:
						ListViewType = cPreferences.eApplicationListView.CaseSuppliesListView;

						GridLines = false;
						SortingOrder = m_DataFiles.Preferences.CaseSortOrder;
						SortingColumn = m_DataFiles.Preferences.CaseSortColumn;

						ListViewItemSorter = new cListViewCaseComparer(m_DataFiles, SortingColumn, SortingOrder);

						break;

					case cSupply.eSupplyTypes.Powder:
						ListViewType = cPreferences.eApplicationListView.PowderSuppliesListView;

						GridLines = false;
						SortingOrder = m_DataFiles.Preferences.PowderSortOrder;
						SortingColumn = m_DataFiles.Preferences.PowderSortColumn;

						ListViewItemSorter = new cListViewPowderComparer(m_DataFiles, SortingColumn, SortingOrder);

						break;

					case cSupply.eSupplyTypes.Primers:
						ListViewType = cPreferences.eApplicationListView.PrimerSuppliesListView;

						GridLines = true;
						SortingOrder = m_DataFiles.Preferences.PrimerSortOrder;
						SortingColumn = m_DataFiles.Preferences.PrimerSortColumn;

						ListViewItemSorter = new cListViewPrimerComparer(m_DataFiles, SortingColumn, SortingOrder);

						break;
					}
				}
			}

		//============================================================================*
		// UpdateBullet()
		//============================================================================*

		public ListViewItem UpdateBullet(cBullet Bullet, bool fSelect = false)
			{
			//----------------------------------------------------------------------------*
			// Verify the ListView Type
			//----------------------------------------------------------------------------*

			if (m_eSupplyType != cSupply.eSupplyTypes.Bullets)
				return (null);

			//----------------------------------------------------------------------------*
			// Find the Item
			//----------------------------------------------------------------------------*

			ListViewItem Item = null;

			foreach (ListViewItem CheckItem in Items)
				{
				if ((CheckItem.Tag as cBullet).CompareTo(Bullet) == 0)
					{
					Item = CheckItem;

					break;
					}
				}

			//----------------------------------------------------------------------------*
			// If the item was not found, add it
			//----------------------------------------------------------------------------*

			if (Item == null)
				return (AddBullet(Bullet, fSelect));

			//----------------------------------------------------------------------------*
			// Otherwise, update the Item Data
			//----------------------------------------------------------------------------*

			SetBulletData(Item, Bullet);

			Item.Selected = fSelect;

			Focus();

			return (Item);
			}

		//============================================================================*
		// UpdateCase()
		//============================================================================*

		public ListViewItem UpdateCase(cCase Case, bool fSelect = false)
			{
			//----------------------------------------------------------------------------*
			// Verify the ListView Type
			//----------------------------------------------------------------------------*

			if (m_eSupplyType != cSupply.eSupplyTypes.Cases)
				return (null);

			//----------------------------------------------------------------------------*
			// Find the Item
			//----------------------------------------------------------------------------*

			ListViewItem Item = null;

			foreach (ListViewItem CheckItem in Items)
				{
				if ((CheckItem.Tag as cCase).CompareTo(Case) == 0)
					{
					Item = CheckItem;

					break;
					}
				}

			//----------------------------------------------------------------------------*
			// If the item was not found, add it
			//----------------------------------------------------------------------------*

			if (Item == null)
				return (AddCase(Case, fSelect));

			//----------------------------------------------------------------------------*
			// Otherwise, update the Item Data
			//----------------------------------------------------------------------------*

			SetCaseData(Item, Case);

			Item.Selected = fSelect;

			Focus();

			return (Item);
			}

		//============================================================================*
		// UpdatePowder()
		//============================================================================*

		public ListViewItem UpdatePowder(cPowder Powder, bool fSelect = false)
			{
			//----------------------------------------------------------------------------*
			// Verify the ListView Type
			//----------------------------------------------------------------------------*

			if (m_eSupplyType != cSupply.eSupplyTypes.Powder)
				return (null);

			//----------------------------------------------------------------------------*
			// Find the Item
			//----------------------------------------------------------------------------*

			ListViewItem Item = null;

			foreach (ListViewItem CheckItem in Items)
				{
				if ((CheckItem.Tag as cPowder).CompareTo(Powder) == 0)
					{
					Item = CheckItem;

					break;
					}
				}

			//----------------------------------------------------------------------------*
			// If the item was not found, add it
			//----------------------------------------------------------------------------*

			if (Item == null)
				return (AddPowder(Powder, fSelect));

			//----------------------------------------------------------------------------*
			// Otherwise, update the Item Data
			//----------------------------------------------------------------------------*

			SetPowderData(Item, Powder);

			Item.Selected = fSelect;

			Focus();

			return (Item);
			}

		//============================================================================*
		// UpdatePrimer()
		//============================================================================*

		public ListViewItem UpdatePrimer(cPrimer Primer, bool fSelect = false)
			{
			//----------------------------------------------------------------------------*
			// Verify the input data
			//----------------------------------------------------------------------------*

			if (Primer == null)
				return (null);

			//----------------------------------------------------------------------------*
			// Verify the ListView Type
			//----------------------------------------------------------------------------*

			if (m_eSupplyType != cSupply.eSupplyTypes.Primers)
				return (null);

			//----------------------------------------------------------------------------*
			// Find the Item
			//----------------------------------------------------------------------------*

			ListViewItem Item = null;

			foreach (ListViewItem CheckItem in Items)
				{
				if ((CheckItem.Tag as cPrimer).CompareTo(Primer) == 0)
					{
					Item = CheckItem;

					break;
					}
				}

			//----------------------------------------------------------------------------*
			// If the item was not found, add it
			//----------------------------------------------------------------------------*

			if (Item == null)
				return (AddPrimer(Primer, fSelect));

			//----------------------------------------------------------------------------*
			// Otherwise, update the Item Data
			//----------------------------------------------------------------------------*

			SetPrimerData(Item, Primer);

			Item.Selected = fSelect;

			Focus();

			return (Item);
			}

		//============================================================================*
		// VerifyBullet()
		//============================================================================*

		public bool VerifyBullet(cBullet Bullet)
			{
			//----------------------------------------------------------------------------*
			// Make sure the bullet is not hidden
			//----------------------------------------------------------------------------*

			if (m_DataFiles.Preferences.HideUncheckedSupplies && !Bullet.Checked)
				return (false);

			//----------------------------------------------------------------------------*
			// Make sure the bullet has at least one unhidden caliber
			//----------------------------------------------------------------------------*

			bool fOK = true;

			if (m_DataFiles.Preferences.HideUncheckedCalibers)
				{
				bool fCaliberFound = false;

				foreach (cBulletCaliber BulletCaliber in Bullet.BulletCaliberList)
					{
					if (BulletCaliber.Caliber.Checked)
						{
						fCaliberFound = true;

						break;
						}
					}

				fOK = fCaliberFound;
				}

			return (fOK);
			}

		//============================================================================*
		// VerifyCase()
		//============================================================================*

		public bool VerifyCase(cCase Case)
			{
			//----------------------------------------------------------------------------*
			// Make sure the case or caliber is not hidden
			//----------------------------------------------------------------------------*

			if (m_DataFiles.Preferences.HideUncheckedSupplies && !Case.Checked)
				return (false);

			if (m_DataFiles.Preferences.HideUncheckedCalibers && !Case.Caliber.Checked)
				return (false);

			return (true);
			}

		//============================================================================*
		// VerifyPowder()
		//============================================================================*

		public bool VerifyPowder(cPowder Powder)
			{
			//----------------------------------------------------------------------------*
			// Make sure the powder is not hidden
			//----------------------------------------------------------------------------*

			if (m_DataFiles.Preferences.HideUncheckedSupplies && !Powder.Checked)
				return (false);

			return (true);
			}

		//============================================================================*
		// VerifyPrimer()
		//============================================================================*

		public bool VerifyPrimer(cPrimer Primer)
			{
			if (m_DataFiles.Preferences.HideUncheckedSupplies && !Primer.Checked)
				return (false);

			return (true);
			}
		}
	}
