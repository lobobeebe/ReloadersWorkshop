
// cLoadDataListView.cs
//
// Copyright © 2013-2014, Kevin S. Beebe
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
	// cLoadDataListView Class
	//============================================================================*

	public class cLoadDataListView : cListView
		{
		//----------------------------------------------------------------------------*
		// Private Static Data Members
		//----------------------------------------------------------------------------*

		private static Color cm_StartColor = Color.DarkGreen;
		private static Color cm_MidColor = Color.Yellow;
		private static Color cm_EndColor = Color.DarkRed;

		//============================================================================*
		// Private Data Members
		//============================================================================*

		private cDataFiles m_DataFiles = null;

		private cListViewColumn[] m_arColumns = new cListViewColumn[]
			{
			new cListViewColumn(0, "CaliberHeader","Caliber", HorizontalAlignment.Left, 200),
			new cListViewColumn(1, "BulletHeader","Bullet", HorizontalAlignment.Left, 200),
			new cListViewColumn(2, "PowderHeader", "Powder", HorizontalAlignment.Left, 160),
			new cListViewColumn(3, "PrimerHeader", "Primer", HorizontalAlignment.Left, 160),
			new cListViewColumn(4, "CaseHeader", "Case", HorizontalAlignment.Left, 160)
			};

		//============================================================================*
		// cLoadDataListView() - Constructor
		//============================================================================*

		public cLoadDataListView(cDataFiles DataFiles)
			: base(DataFiles, cPreferences.eApplicationListView.LoadDataListView)
			{
			m_DataFiles = DataFiles;

			//----------------------------------------------------------------------------*
			// Set Properties
			//----------------------------------------------------------------------------*

			AllowColumnReorder = false;
			CheckBoxes = true;

			//----------------------------------------------------------------------------*
			// Event Handlers
			//----------------------------------------------------------------------------*

			ListViewItemSorter = new cListViewLoadComparer(m_DataFiles.Preferences.LoadDataSortColumn, m_DataFiles.Preferences.LoadDataSortOrder);

			//----------------------------------------------------------------------------*
			// Populate Columns and Groups
			//----------------------------------------------------------------------------*

			SortingOrder = m_DataFiles.Preferences.LoadDataSortOrder;

			SortingColumn = m_DataFiles.Preferences.LoadDataSortColumn;

			PopulateColumns(m_arColumns);

			Populate();

			Initialized = true;
			}

		//============================================================================*
		// AddLoad()
		//============================================================================*

		public ListViewItem AddLoad(cLoad Load, cFirearm.eFireArmType eFirearmType, cCaliber Caliber, cBullet Bullet, cPowder Powder, bool fSelect = false)
			{
			if (!VerifyLoad(Load, eFirearmType, Caliber, Bullet, Powder))
				return (null);

			//----------------------------------------------------------------------------*
			// Create the ListViewItem
			//----------------------------------------------------------------------------*

			ListViewItem Item = new ListViewItem();

			SetLoadData(Item, Load);

			//----------------------------------------------------------------------------*
			// Add the item to the list and exit
			//----------------------------------------------------------------------------*

			AddItem(Item, fSelect);

			return (Item);
			}

		//============================================================================*
		// CheckedCount Property
		//============================================================================*

		public int CheckedCount
			{
			get
				{
				int nCount = 0;

				for (int i = 0; i < Items.Count; i++)
					{
					try
						{
						if (Items[i].Checked)
							nCount++;
						}
					catch
						{
						// No need to do anything here
						}
					}

				return (nCount);
				}
			}

		//============================================================================*
		// OnColumnClick()
		//============================================================================*

		protected override void OnColumnClick(ColumnClickEventArgs args)
			{
			if (args.Column > 4)
				{
				Console.Beep(1000, 100);

				return;
				}

			if (args.Column == m_DataFiles.Preferences.LoadDataSortColumn)
				{
				SortingOrder = (SortingOrder == SortOrder.Ascending) ? SortOrder.Descending : SortOrder.Ascending;

				m_DataFiles.Preferences.LoadDataSortOrder = SortingOrder;

				ListViewItemSorter = new cListViewLoadComparer(m_DataFiles.Preferences.LoadDataSortColumn, m_DataFiles.Preferences.LoadDataSortOrder);
				}
			else
				{
				SortingColumn = args.Column;

				m_DataFiles.Preferences.LoadDataSortColumn = SortingColumn;

				ListViewItemSorter = new cListViewLoadComparer(SortingColumn, SortingOrder);
				}

			this.Invalidate(true);

			if (SelectedItems.Count > 0)
				SelectedItems[0].EnsureVisible();
			}

		//============================================================================*
		// OnDrawSubItem()
		//============================================================================*

		protected override void OnDrawSubItem(DrawListViewSubItemEventArgs args)
			{
			//----------------------------------------------------------------------------*
			// If it's not a charge item, just draw it normally
			//----------------------------------------------------------------------------*

			if (args.ColumnIndex < 5)
				{
				base.OnDrawSubItem(args);

				return;
				}

			//----------------------------------------------------------------------------*
			// Get the load and charge data
			//----------------------------------------------------------------------------*

			cLoad Load = (cLoad)args.Item.Tag;
			cCharge Charge = Load.ChargeList[args.ColumnIndex - 5];

			//----------------------------------------------------------------------------*
			// Set up the background color for the item
			//----------------------------------------------------------------------------*

			Color StartColor = cm_StartColor;
			Color EndColor = cm_EndColor;

			if (args.ColumnIndex == 5)
				{
				if (Load.ChargeList.Count > 1)
					EndColor = cm_MidColor;
				}
			else
				{
				StartColor = cm_MidColor;

				if (Load.ChargeList.Count > args.ColumnIndex - 4)
					EndColor = cm_MidColor;
				}

			LinearGradientBrush brush = new LinearGradientBrush(args.Bounds, StartColor, EndColor, LinearGradientMode.Horizontal);
			args.Graphics.FillRectangle(brush, args.Bounds);

			//----------------------------------------------------------------------------*
			// Set up the font for the item
			//----------------------------------------------------------------------------*

			Font ChargeFont = SystemFonts.DefaultFont;

			SizeF TextSize = args.Graphics.MeasureString(args.SubItem.Text, ChargeFont, args.Bounds.Width);

			float x = args.Bounds.Left + (args.Bounds.Width / 2) - (TextSize.Width / 2) - (Charge.Favorite ? (Properties.Resources.Favorite.Width / 2) : 0);
			float y = args.Bounds.Top + (args.Bounds.Height / 2) - (TextSize.Height / 2);

			if (StartColor == cm_StartColor && EndColor == cm_MidColor)
				x = args.Bounds.Left;

			if (StartColor == cm_MidColor && EndColor == cm_EndColor)
				{
				x = args.Bounds.Left + args.Bounds.Width - TextSize.Width;

				if (Charge.Favorite && EndColor != cm_EndColor)
					x -= Properties.Resources.Favorite.Width;

				if (Charge.Reject && EndColor != cm_EndColor)
					x -= Properties.Resources.Reject.Width;
				}

			Brush ItemBrush = SystemBrushes.WindowText;

			if (StartColor == cm_StartColor || EndColor == cm_EndColor)
				ItemBrush = SystemBrushes.HighlightText;

			//----------------------------------------------------------------------------*
			// See if this charge has been used in a batch
			//----------------------------------------------------------------------------*

			bool fUsed = false;

			foreach (cBatch Batch in m_DataFiles.BatchList)
				{
				if (Batch.Load.CompareTo(Load) == 0)
					{
					if (Batch.PowderWeight == Charge.PowderWeight)
						{
						fUsed = true;

						break;
						}
					}
				}

			//----------------------------------------------------------------------------*
			// Make any modifications needed to the font
			//----------------------------------------------------------------------------*

			Font TextFont;

			if (Charge.Reject)
				TextFont = new Font(SystemFonts.DefaultFont, FontStyle.Strikeout | (fUsed ? FontStyle.Bold : FontStyle.Strikeout));
			else
				{
				if (Charge.Favorite)
					TextFont = new Font(SystemFonts.DefaultFont, FontStyle.Bold);
				else
					TextFont = new Font(SystemFonts.DefaultFont, (fUsed) ? FontStyle.Bold : FontStyle.Regular);
				}

			args.Graphics.DrawString(args.SubItem.Text, TextFont, ItemBrush, x, y);

			if (Charge.Favorite)
				{
				Bitmap FavoriteBitmap = Properties.Resources.Favorite;
				FavoriteBitmap.MakeTransparent(Color.White);

				if (EndColor == cm_EndColor)
					args.Graphics.DrawImage(FavoriteBitmap, x - FavoriteBitmap.Width, y, FavoriteBitmap.Width, FavoriteBitmap.Height);
				else
					args.Graphics.DrawImage(FavoriteBitmap, x + TextSize.Width, y, FavoriteBitmap.Width, FavoriteBitmap.Height);
				}

			if (Charge.Reject)
				{
				Bitmap RejectBitmap = Properties.Resources.Reject;
				RejectBitmap.MakeTransparent(Color.White);

				if (EndColor == cm_EndColor)
					args.Graphics.DrawImage(RejectBitmap, x - RejectBitmap.Width, y, RejectBitmap.Width, RejectBitmap.Height);
				else
					args.Graphics.DrawImage(RejectBitmap, x + TextSize.Width, y, RejectBitmap.Width, RejectBitmap.Height);
				}
			}

		//============================================================================*
		// Populate()
		//============================================================================*

		public void Populate(cFirearm.eFireArmType eFirearmType, cCaliber Caliber, cBullet Bullet, cPowder Powder)
			{
			Populating = true;

			//----------------------------------------------------------------------------*
			// LoadsListView Items
			//----------------------------------------------------------------------------*

			Items.Clear();

			while (Columns.Count > 5)
				Columns.RemoveAt(5);

			ListViewItem SelectItem = null;

			foreach (cLoad Load in m_DataFiles.LoadList)
				{
				ListViewItem Item = AddLoad(Load, eFirearmType, Caliber, Bullet, Powder);

				if (Item != null && Load.CompareTo(m_DataFiles.Preferences.LastLoadSelected) == 0)
					SelectItem = Item;
				}

			if (SelectItem != null)
				SelectItem.Selected = true;
			else
				{
				if (Items.Count > 0)
					{
					Items[0].Selected = true;

					m_DataFiles.Preferences.LastLoadSelected = (cLoad)Items[0].Tag;
					}
				}

			if (SelectedItems.Count > 0)
				SelectedItems[0].EnsureVisible();

			Populating = false;
			}

		//============================================================================*
		// SetColumns()
		//============================================================================*

		public void SetColumns()
			{
			foreach (ColumnHeader Header in this.Columns)
				{
				if (Header.Index > 4)
					Header.Text = String.Format("Charge {0} ({1})", Header.Index - 4, m_DataFiles.MetricString(cDataFiles.eDataType.PowderWeight));
				}
			}

		//============================================================================*
		// SetLoadData()
		//============================================================================*

		public void SetLoadData(ListViewItem Item, cLoad Load)
			{
			Item.SubItems.Clear();

			Item.Text = Load.Caliber.ToString();

			Item.Tag = Load;
			Item.Checked = Load.Checked;

			Item.SubItems.Add(Load.Bullet.ToWeightString());
			Item.SubItems.Add(Load.Powder.ToString());
			Item.SubItems.Add(Load.Primer.ToShortString());
			Item.SubItems.Add(Load.Case.ToShortString());

			int nColumnCount = 6;

			foreach (cCharge Charge in Load.ChargeList)
				{
				if (Columns.Count < nColumnCount)
					{
					ColumnHeader Column = Columns.Add(String.Format("Charge {0:G} ({1})", nColumnCount - 5, m_DataFiles.MetricString(cDataFiles.eDataType.PowderWeight)));
					Column.TextAlign = nColumnCount == 6 ? HorizontalAlignment.Left : HorizontalAlignment.Center;
					Column.Width = 100;
					}

//				string strPowderWeightFormat = "{0:F";
//				strPowderWeightFormat += String.Format("{0:G0}", m_DataFiles.Preferences.PowderWeightDecimals);
//				strPowderWeightFormat += "}";

//				Item.SubItems.Add(String.Format(strPowderWeightFormat, m_DataFiles.StandardToMetric(Charge.PowderWeight, cDataFiles.eDataType.PowderWeight)));
				Item.SubItems.Add(String.Format(Charge.ToString()));

				nColumnCount++;
				}
			}

		//============================================================================*
		// UpdateLoad()
		//============================================================================*

		public ListViewItem UpdateLoad(cLoad Load, cFirearm.eFireArmType eFirearmType, cCaliber Caliber, cBullet Bullet, cPowder Powder, bool fSelect = false)
			{
			//----------------------------------------------------------------------------*
			// Find the Item
			//----------------------------------------------------------------------------*

			ListViewItem Item = null;

			foreach (ListViewItem CheckItem in Items)
				{
				if ((CheckItem.Tag as cLoad).Equals(Load))
					{
					Item = CheckItem;

					break;
					}
				}

			//----------------------------------------------------------------------------*
			// If the item was not found, add it
			//----------------------------------------------------------------------------*

			if (Item == null)
				return (AddLoad(Load, eFirearmType, Caliber, Bullet, Powder, fSelect));

			//----------------------------------------------------------------------------*
			// Otherwise, update the Item Data
			//----------------------------------------------------------------------------*

			SetLoadData(Item, Load);

			Item.Selected = fSelect;

			if (SelectedItems.Count > 0)
				SelectedItems[0].EnsureVisible();

			Focus();

			return (Item);
			}

		//============================================================================*
		// VerifyLoad()
		//============================================================================*

		public bool VerifyLoad(cLoad Load, cFirearm.eFireArmType eFirearmType, cCaliber Caliber, cBullet Bullet, cPowder Powder)
			{
			//----------------------------------------------------------------------------*
			// Check the filters
			//----------------------------------------------------------------------------*

			if (eFirearmType != cFirearm.eFireArmType.None && Load.FirearmType != eFirearmType ||
				(Caliber != null && Load.Caliber.CompareTo(Caliber) != 0) ||
				(Bullet != null && Load.Bullet.CompareTo(Bullet) != 0) ||
				(Powder != null && Load.Powder.CompareTo(Powder) != 0))
				return (false);

			//----------------------------------------------------------------------------*
			// Make sure the components aren't hidden
			//----------------------------------------------------------------------------*

			if ((m_DataFiles.Preferences.HideUncheckedCalibers && !Load.Caliber.Checked))
				return (false);
				
			if (m_DataFiles.Preferences.HideUncheckedSupplies &&
				(!Load.Bullet.Checked || !Load.Powder.Checked || !Load.Primer.Checked || !Load.Case.Checked))
				return (false);

			//----------------------------------------------------------------------------*
			// Good to go!
			//----------------------------------------------------------------------------*

			return (true);
			}
		}
	}
