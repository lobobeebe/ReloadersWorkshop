//============================================================================*
// cCopyChargeListView.cs
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
	// cCopyChargeListView Class
	//============================================================================*

	public class cCopyChargeListView : cListView
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
			new cListViewColumn(0, "BulletHeader","Bullet", HorizontalAlignment.Left, 300),
			new cListViewColumn(1, "PrimerHeader", "Primer", HorizontalAlignment.Left, 160),
			new cListViewColumn(2, "CaseHeader", "Case", HorizontalAlignment.Left, 160)
			};

		//============================================================================*
		// cCopyChargeListView() - Constructor
		//============================================================================*

		public cCopyChargeListView(cDataFiles DataFiles)
			: base(DataFiles, cPreferences.eApplicationListView.LoadDataListView)
			{
			m_DataFiles = DataFiles;

			//----------------------------------------------------------------------------*
			// Set Properties
			//----------------------------------------------------------------------------*

			AllowColumnReorder = false;

			//----------------------------------------------------------------------------*
			// Event Handlers
			//----------------------------------------------------------------------------*

			ListViewItemSorter = new cListViewCopyChargeComparer(m_DataFiles.Preferences.CopyChargeSortColumn, m_DataFiles.Preferences.CopyChargeSortOrder);

			//----------------------------------------------------------------------------*
			// Populate Columns and Groups
			//----------------------------------------------------------------------------*

			PopulateColumns(m_arColumns);

			SortingOrder = m_DataFiles.Preferences.CopyChargeSortOrder;

			SortingColumn = m_DataFiles.Preferences.CopyChargeSortColumn;

			Initialized = true;
			}

		//============================================================================*
		// AddLoad()
		//============================================================================*

		public ListViewItem AddLoad(cLoad Load, bool fSelect = false)
			{
			//----------------------------------------------------------------------------*
			// Make sure the caliber is not hidden
			//----------------------------------------------------------------------------*

			if (m_DataFiles.Preferences.HideUncheckedCalibers && !Load.Caliber.Checked)
				return (null);

			//----------------------------------------------------------------------------*
			// Make sure the bullet is not hidden
			//----------------------------------------------------------------------------*

			if (m_DataFiles.Preferences.HideUncheckedSupplies && !Load.Bullet.Checked)
				return (null);

			//----------------------------------------------------------------------------*
			// Make sure the primer is not hidden
			//----------------------------------------------------------------------------*

			if (m_DataFiles.Preferences.HideUncheckedSupplies && !Load.Primer.Checked)
				return (null);

			//----------------------------------------------------------------------------*
			// Make sure the case is not hidden
			//----------------------------------------------------------------------------*

			if (m_DataFiles.Preferences.HideUncheckedSupplies && !Load.Case.Checked)
				return (null);

			//----------------------------------------------------------------------------*
			// Create the ListViewItem
			//----------------------------------------------------------------------------*

			ListViewItem Item = new ListViewItem(Load.Bullet.ToString());

			Item.Tag = Load;
			Item.Checked = Load.Checked;

			Item.SubItems.Add(Load.Primer.ToShortString());
			Item.SubItems.Add(Load.Case.ToShortString());

			int nColumnCount = 4;

			foreach (cCharge Charge in Load.ChargeList)
				{
				if (Columns.Count < nColumnCount)
					{
					ColumnHeader Column = Columns.Add(String.Format("Charge {0:G}", nColumnCount - 3));
					Column.TextAlign = HorizontalAlignment.Center;
					Column.Width = 100;
					}

				Item.SubItems.Add(String.Format("{0:F1}", Charge.PowderWeight));

				nColumnCount++;
				}

			try
				{
				Items.Add(Item);

				if (fSelect)
					{
					Focus();

					Item.Selected = true;
					}
				}
			catch (Exception e)
				{
				cControls.InternalErrorMessageBox(e);
				}

			return (Item);
			}

		//============================================================================*
		// OnColumnClick()
		//============================================================================*

		protected override void OnColumnClick(ColumnClickEventArgs args)
			{
			if (args.Column > 3)
				{
				Console.Beep(1000, 100);

				return;
				}

			if (args.Column == SortingColumn)
				{
				SortingOrder = (SortingOrder == SortOrder.Ascending) ? SortOrder.Descending : SortOrder.Ascending;

				m_DataFiles.Preferences.LoadDataSortOrder = SortingOrder;

				ListViewItemSorter = new cListViewCopyChargeComparer(SortingColumn, SortingOrder);
				}
			else
				{
				SortingColumn = args.Column;

				m_DataFiles.Preferences.LoadDataSortColumn = args.Column;

				ListViewItemSorter = new cListViewCopyChargeComparer(SortingColumn, SortingOrder);
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
			if (args.ColumnIndex < 3)
				{
				args.DrawDefault = true;

				return;
				}

			cLoad Load = (cLoad)args.Item.Tag;
			cChargeList ChargeList = Load.ChargeList;
			cCharge Charge = ChargeList[args.ColumnIndex - 3];

			Color StartColor = cm_StartColor;
			Color EndColor = cm_EndColor;

			if (args.ColumnIndex == 3)
				{
				if (ChargeList.Count > 1)
					EndColor = cm_MidColor;
				}
			else
				{
				StartColor = cm_MidColor;

				if (ChargeList.Count > args.ColumnIndex - 2)
					EndColor = cm_MidColor;
				}

			LinearGradientBrush brush = new LinearGradientBrush(args.Bounds, StartColor, EndColor, LinearGradientMode.Horizontal);
			args.Graphics.FillRectangle(brush, args.Bounds);

			SizeF TextSize = args.Graphics.MeasureString(args.SubItem.Text, SystemFonts.DefaultFont, args.Bounds.Width);

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

			Font TextFont;

			if (Charge.Reject)
				TextFont = new Font(SystemFonts.DefaultFont, FontStyle.Strikeout);
			else
				{
				if (Charge.Favorite)
					TextFont = new Font(SystemFonts.DefaultFont, FontStyle.Bold);
				else
					TextFont = new Font(SystemFonts.DefaultFont, FontStyle.Regular);
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

		public void Populate(cFirearm.eFireArmType eFirearmType, cCaliber Caliber, cBullet Bullet, double dBulletWeight, cPowder Powder, cPrimer Primer, cCase Case)
			{
			Populating = true;

			//----------------------------------------------------------------------------*
			// LoadsListView Items
			//----------------------------------------------------------------------------*

			Items.Clear();

			while (Columns.Count > 3)
				Columns.RemoveAt(3);

			ListViewItem SelectItem = null;

			foreach (cLoad Load in m_DataFiles.LoadList)
				{
				if (Load.FirearmType == eFirearmType &&
					(Caliber == null || Load.Caliber.CompareTo(Caliber) == 0) &&
					(Bullet == null || Load.Bullet.CompareTo(Bullet) == 0) &&
					(Load.Bullet.Weight == dBulletWeight) &&
					(Powder == null || Load.Powder.CompareTo(Powder) == 0) &&
					(Case == null || Load.Case.CompareTo(Case) == 0) &&
					(Primer == null || Load.Primer.CompareTo(Primer) == 0))
					{
					ListViewItem Item = AddLoad(Load);

					if (Item != null && Load.CompareTo(m_DataFiles.Preferences.LastCopyLoadSelected) == 0)
						SelectItem = Item;
					}
				}

			if (SelectItem != null)
				SelectItem.Selected = true;
			else
				{
				if (Items.Count > 0)
					{
					Items[0].Selected = true;

					m_DataFiles.Preferences.LastCopyLoadSelected = (cLoad)Items[0].Tag;

					Items[0].EnsureVisible();
					}
				}

			Populating = false;
			}
		}
	}
