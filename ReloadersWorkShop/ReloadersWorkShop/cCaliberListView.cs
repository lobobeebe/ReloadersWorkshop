//============================================================================*
// cCaliberListView.cs
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
	// cCaliberListView Class
	//============================================================================*

	public class cCaliberListView : cListView
		{
		//============================================================================*
		// Private Data Members
		//============================================================================*

		private cDataFiles m_DataFiles = null;

		private string m_strDimensionFormat = "{0:F3}";
		private string m_strBulletWeightFormat = "{0:F1}";

		private cListViewColumn[] m_arColumns = new cListViewColumn[]
			{
			new cListViewColumn(0, "NameHeader","Caliber", HorizontalAlignment.Left, 160),
			new cListViewColumn(1, "TypeHeader", "Type", HorizontalAlignment.Left, 100),
			new cListViewColumn(2, "HeadStampHeader", "Head Stamp", HorizontalAlignment.Left, 120),
			new cListViewColumn(3, "PrimerSizeHeader", "Primer Size", HorizontalAlignment.Left, 100),
			new cListViewColumn(4, "MagnumHeader", "Magnum", HorizontalAlignment.Center, 95),
			new cListViewColumn(5, "MinDiameterHeader", "Min Bullet Diameter", HorizontalAlignment.Center, 150),
			new cListViewColumn(6, "MaxDiameterHeader", "Max Bullet Diameter", HorizontalAlignment.Center, 150),
			new cListViewColumn(7, "MinWeightHeader", "Min Bullet Weight", HorizontalAlignment.Center, 150),
			new cListViewColumn(8, "MaxWeightHeader", "Max Bullet Weight", HorizontalAlignment.Center, 150),
			new cListViewColumn(9, "CaseTrimHeader", "Min Case/Shell Length", HorizontalAlignment.Center, 150),
			new cListViewColumn(10, "MaxCaseLengthHeader", "Max Case/Shell Length", HorizontalAlignment.Center, 150),
			new cListViewColumn(11, "MaxCOLHeader", "Max COAL", HorizontalAlignment.Center, 120),
			new cListViewColumn(12, "MaxneckDiameterHeader", "Max Neck Diameter", HorizontalAlignment.Center, 120)
			};

		//============================================================================*
		// cCaliberListView() - Constructor
		//============================================================================*

		public cCaliberListView(cDataFiles DataFiles)
			: base(DataFiles, cPreferences.eApplicationListView.CalibersListView)
			{
			m_DataFiles = DataFiles;

			//----------------------------------------------------------------------------*
			// Set Properties
			//----------------------------------------------------------------------------*

			CheckBoxes = true;
			GridLines = true;

			SetColumns();

			//----------------------------------------------------------------------------*
			// Event Handlers
			//----------------------------------------------------------------------------*

			//----------------------------------------------------------------------------*
			// Populate Groups and Columns
			//----------------------------------------------------------------------------*

			PopulateGroups();

			SortingOrder = m_DataFiles.Preferences.CaliberSortOrder;

			SortingColumn = m_DataFiles.Preferences.CaliberSortColumn;

			ListViewItemSorter = new cListViewCaliberComparer(SortingColumn, SortingOrder);

			Populate();

			Initialized = true;
			}

		//============================================================================*
		// AddCaliber()
		//============================================================================*

		public ListViewItem AddCaliber(cCaliber Caliber, bool fSelect = false)
			{
			//----------------------------------------------------------------------------*
			// Verify that the caliber shoudl be added
			//----------------------------------------------------------------------------*

			if (!VerifyCaliber(Caliber))
				return(null);

			//----------------------------------------------------------------------------*
			// Create the new Item
			//----------------------------------------------------------------------------*

			ListViewItem Item = new ListViewItem();

			SetCaliberData(Item,  Caliber);

			//----------------------------------------------------------------------------*
			// Add the item to the list and exit
			//----------------------------------------------------------------------------*

			AddItem(Item, fSelect);

			return (Item);
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
					cCaliber Caliber = (cCaliber)Item.Tag;

					if (Caliber.FirearmType == cFirearm.eFireArmType.Handgun)
						nCount++;
					}

				return (nCount);
				}
			}

		//============================================================================*
		// HideUnchecked Property
		//============================================================================*

		public bool HideUnchecked
			{
			set
				{
				if (m_DataFiles.Preferences.HideUncheckedCalibers != value)
					{
					m_DataFiles.Preferences.HideUncheckedCalibers = value;

					Populate();
					}
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

				m_DataFiles.Preferences.CaliberSortOrder = SortingOrder;

				ListViewItemSorter = new cListViewCaliberComparer(SortingColumn, SortingOrder);
				}
			else
				{
				SortingColumn = args.Column;

				m_DataFiles.Preferences.CaliberSortColumn = args.Column;

				ListViewItemSorter = new cListViewCaliberComparer(SortingColumn, SortingOrder);
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

			Cursor = Cursors.WaitCursor;

			m_strDimensionFormat = "{0:F";
			m_strDimensionFormat += String.Format("{0:G0}", m_DataFiles.Preferences.DimensionDecimals);
			m_strDimensionFormat += "}";

			m_strBulletWeightFormat = "{0:F";
			m_strBulletWeightFormat += String.Format("{0:G0}", m_DataFiles.Preferences.BulletWeightDecimals);
			m_strBulletWeightFormat += "}";

			Items.Clear();

			ListViewItem SelectItem = null;

			foreach (cCaliber Caliber in m_DataFiles.CaliberList)
				{
				ListViewItem Item = AddCaliber(Caliber);

				if (Item != null && m_DataFiles.Preferences.LastCaliberSelected != null && m_DataFiles.Preferences.LastCaliberSelected.CompareTo(Caliber) == 0)
					SelectItem = Item;
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

			Cursor = Cursors.Default;

			Populating = false;
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
					cCaliber Caliber = (cCaliber)Item.Tag;

					if (Caliber.FirearmType == cFirearm.eFireArmType.Rifle)
						nCount++;
					}

				return (nCount);
				}
			}

		//============================================================================*
		// SetCaliberData()
		//============================================================================*

		public void SetCaliberData(ListViewItem Item, cCaliber Caliber)
			{
			Item.SubItems.Clear();

			Item.Text = Caliber.Name;

			Item.Group = Groups[(int)Caliber.FirearmType];

			Item.Tag = Caliber;

			Item.Checked = Caliber.Checked;

			if (Caliber.FirearmType == cFirearm.eFireArmType.Handgun)
				Item.SubItems.Add(Caliber.Pistol ? "Pistol" : "Revolver");
			else
				Item.SubItems.Add("-");

			Item.SubItems.Add(Caliber.HeadStamp);

			string strPrimerSize = "";

			if (Caliber.SmallPrimer)
				strPrimerSize += "Small";

			if (Caliber.LargePrimer)
				{
				if (strPrimerSize.Length > 0)
					strPrimerSize += "/";

				strPrimerSize += "Large";
				}

			Item.SubItems.Add(strPrimerSize);
			Item.SubItems.Add(Caliber.MagnumPrimer ? "Y" : "");

			Item.SubItems.Add(String.Format(m_strDimensionFormat, cDataFiles.StandardToMetric(Caliber.MinBulletDiameter, cDataFiles.eDataType.Dimension)));
			Item.SubItems.Add(String.Format(m_strDimensionFormat, cDataFiles.StandardToMetric(Caliber.MaxBulletDiameter, cDataFiles.eDataType.Dimension)));

			if (Caliber.FirearmType != cFirearm.eFireArmType.Shotgun)
				{
				Item.SubItems.Add(String.Format(m_strBulletWeightFormat, cDataFiles.StandardToMetric(Caliber.MinBulletWeight, cDataFiles.eDataType.BulletWeight)));
				Item.SubItems.Add(String.Format(m_strBulletWeightFormat, cDataFiles.StandardToMetric(Caliber.MaxBulletWeight, cDataFiles.eDataType.BulletWeight)));
				}
			else
				{
				Item.SubItems.Add(String.Format("{0:F3}", cDataFiles.StandardToMetric(Caliber.MinBulletWeight, cDataFiles.eDataType.BulletWeight)));
				Item.SubItems.Add(String.Format("{0:F3}", cDataFiles.StandardToMetric(Caliber.MaxBulletWeight, cDataFiles.eDataType.BulletWeight)));
				}

			Item.SubItems.Add(String.Format(m_strDimensionFormat, cDataFiles.StandardToMetric(Caliber.CaseTrimLength, cDataFiles.eDataType.Dimension)));
			Item.SubItems.Add(String.Format(m_strDimensionFormat, cDataFiles.StandardToMetric(Caliber.MaxCaseLength, cDataFiles.eDataType.Dimension)));
			Item.SubItems.Add(String.Format(m_strDimensionFormat, cDataFiles.StandardToMetric(Caliber.MaxCOL, cDataFiles.eDataType.Dimension)));

			Item.SubItems.Add(Caliber.MaxNeckDiameter > 0.0 ? String.Format(m_strDimensionFormat, cDataFiles.StandardToMetric(Caliber.MaxNeckDiameter, cDataFiles.eDataType.Dimension)) : "-");
			}

		//============================================================================*
		// SetColumns()
		//============================================================================*

		public void SetColumns()
			{
			m_arColumns[5].Text = String.Format("Min Bullet Diameter ({0})", cDataFiles.MetricString(cDataFiles.eDataType.Dimension));
			m_arColumns[6].Text = String.Format("Max Bullet Diameter ({0})", cDataFiles.MetricString(cDataFiles.eDataType.Dimension));
			m_arColumns[7].Text = String.Format("Min Bullet Weight ({0})", cDataFiles.MetricString(cDataFiles.eDataType.BulletWeight));
			m_arColumns[8].Text = String.Format("Max Bullet Weight ({0})", cDataFiles.MetricString(cDataFiles.eDataType.BulletWeight));
			m_arColumns[9].Text = String.Format("Min Case Length ({0})", cDataFiles.MetricString(cDataFiles.eDataType.Dimension));
			m_arColumns[10].Text = String.Format("Max Case Length ({0})", cDataFiles.MetricString(cDataFiles.eDataType.Dimension));
			m_arColumns[11].Text = String.Format("Max COAL ({0})", cDataFiles.MetricString(cDataFiles.eDataType.Dimension));
			m_arColumns[12].Text = String.Format("Max Neck Diameter ({0})", cDataFiles.MetricString(cDataFiles.eDataType.Dimension));

			PopulateColumns(m_arColumns);
			}

		//============================================================================*
		// ShotgunCount Property
		//============================================================================*

		public int ShotgunCount
			{
			get
				{
				int nCount = 0;

				foreach (ListViewItem Item in Items)
					{
					cCaliber Caliber = (cCaliber)Item.Tag;

					if (Caliber.FirearmType == cFirearm.eFireArmType.Shotgun)
						nCount++;
					}

				return (nCount);
				}
			}

		//============================================================================*
		// UpdateCaliber()
		//============================================================================*

		public void UpdateCaliber(cCaliber Caliber, bool fSelect = false)
			{
			foreach(ListViewItem Item in Items)
				{
				if ((Item.Tag as cCaliber).Equals(Caliber))
					{
					SetCaliberData(Item, Caliber);

					Item.Selected = fSelect;

					if (SelectedItems.Count > 0)
						SelectedItems[0].EnsureVisible();

					return;
					}
				}

			AddCaliber(Caliber, fSelect);
			}

		//============================================================================*
		// VerifyCaliber()
		//============================================================================*

		public bool VerifyCaliber(cCaliber Caliber)
			{
			if (m_DataFiles.Preferences.HideUncheckedCalibers && !Caliber.Checked)
				return (false);

			return(true);
			}
		}
	}
