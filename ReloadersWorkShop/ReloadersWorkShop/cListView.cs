//============================================================================*
// cListView.cs
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
using System.Windows.Forms.VisualStyles;

using ReloadersWorkShop.Preferences;

//============================================================================*
// NameSpace
//============================================================================*

namespace ReloadersWorkShop
	{
	//============================================================================*
	// cListView Class
	//============================================================================*

	public class cListView : ListView
		{
		//============================================================================*
		// Private Static Data Members
		//============================================================================*

		private static Bitmap sm_CheckMarkImage = null;
		private static Bitmap sm_CheckMarkSelectedImage = null;

		private static Bitmap sm_SortAscendingImage = null;
		private static Bitmap sm_SortDescendingImage = null;

		//============================================================================*
		// Private Data Members
		//============================================================================*

		private cDataFiles m_DataFiles = null;
		private bool m_fPopulating = false;

		private cPreferences.eApplicationListView m_eListViewType;

		private int m_nSortColumn = 0;
		private SortOrder m_SortOrder = SortOrder.Ascending;

		private string m_strToolTip = "";
		private ToolTip m_ToolTip = null;

		private bool m_fInitialized = false;
		private bool m_fCheckFromDoubleClick = false;

		//============================================================================*
		// cListView() - Default Constructor
		//============================================================================*

		public cListView()
			{
			}

		//============================================================================*
		// cListView() - Constructor
		//============================================================================*

		public cListView(cDataFiles DataFiles, cPreferences.eApplicationListView eListViewType)
			{
			m_DataFiles = DataFiles;
			m_eListViewType = eListViewType;

			//----------------------------------------------------------------------------*
			// Set Properties
			//----------------------------------------------------------------------------*

			AllowColumnReorder = true;
			AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
			DoubleBuffered = true;
			HeaderStyle = ColumnHeaderStyle.Clickable;
			HideSelection = false;
			MultiSelect = false;
			OwnerDraw = true;
			SortingColumn = 0;
			SortingOrder = SortOrder.Ascending;
			TabStop = true;
			FullRowSelect = true;
			View = System.Windows.Forms.View.Details;
			Visible = true;

			//----------------------------------------------------------------------------*
			// Event Handlers
			//----------------------------------------------------------------------------*

			ListViewItemSorter = new cListViewComparer(0, SortOrder.Ascending);

			//----------------------------------------------------------------------------*
			// Load Images
			//----------------------------------------------------------------------------*

			if (sm_CheckMarkImage == null)
				{
				sm_CheckMarkImage = (Bitmap) Properties.Resources.ResourceManager.GetObject("CheckMark");

				sm_CheckMarkImage.MakeTransparent(Color.White);
				}

			if (sm_CheckMarkSelectedImage == null)
				{
				sm_CheckMarkSelectedImage = (Bitmap) Properties.Resources.ResourceManager.GetObject("CheckMarkSelected");
				sm_CheckMarkSelectedImage.MakeTransparent(Color.Black);
				}

			if (sm_SortAscendingImage == null)
				{
				sm_SortAscendingImage = (Bitmap) Properties.Resources.ResourceManager.GetObject("SortAscending");

				sm_SortAscendingImage.MakeTransparent(Color.White);
				}

			if (sm_SortDescendingImage == null)
				{
				sm_SortDescendingImage = (Bitmap) Properties.Resources.ResourceManager.GetObject("SortDescending");

				sm_SortDescendingImage.MakeTransparent(Color.White);
				}

			Font = SystemFonts.DefaultFont;
			}

		//============================================================================*
		// AddItem()
		//============================================================================*

		public void AddItem(ListViewItem Item, bool fSelect = false)
			{
			//----------------------------------------------------------------------------*
			// Add the Item to the ListView and Return
			//----------------------------------------------------------------------------*

			try
				{
				Items.Add(Item);

				if (fSelect)
					{
					Item.Selected = true;

					Item.EnsureVisible();
					}
				}
			catch (Exception e)
				{
				cControls.InternalErrorMessageBox(e);
				}

			Focus();
			}

		//============================================================================*
		// Datafiles Property
		//============================================================================*

		protected cDataFiles DataFiles
			{
			get
				{
				return (m_DataFiles);
				}
			}

		//============================================================================*
		// GetCaliberFromTag()
		//============================================================================*

		private cCaliber GetCaliberFromTag(ListViewItem Item)
			{
			cCaliber Caliber = null;

			if (Item.Tag is cCaliber)
				Caliber = (cCaliber) Item.Tag;

			if (Caliber == null)
				{
				if (Item.Tag is cCase)
					Caliber = (Item.Tag as cCase).Caliber;

				if (Caliber == null)
					{
					if (Item.Tag is cLoad)
						Caliber = (Item.Tag as cLoad).Caliber;

					if (Caliber == null)
						{
						if (Item.Tag is cBatch)
							Caliber = (Item.Tag as cBatch).Load.Caliber;

						if (Caliber == null)
							{
							if (Item.Tag is cFirearm)
								Caliber = (Item.Tag as cFirearm).PrimaryCaliber;

							if (Caliber == null)
								{
								if (Item.Tag is cAmmo)
									Caliber = (Item.Tag as cAmmo).Caliber;

								if (Caliber == null)
									{
									if (Item.Tag is cBulletCaliber)
										Caliber = (Item.Tag as cBulletCaliber).Caliber;
									}
								}
							}
						}
					}
				}

			return (Caliber);
			}

		//============================================================================*
		// Initialized Property
		//============================================================================*

		protected bool Initialized
			{
			get
				{
				return (m_fInitialized);
				}
			set
				{
				m_fInitialized = value;
				}
			}

		//============================================================================*
		// ListViewType Property
		//============================================================================*

		protected cPreferences.eApplicationListView ListViewType
			{
			get
				{
				return (m_eListViewType);
				}
			set
				{
				m_eListViewType = value;
				}
			}

		//============================================================================*
		// OnColumnReordered()
		//============================================================================*

		protected override void OnColumnReordered(ColumnReorderedEventArgs args)
			{
			base.OnColumnReordered(args);

			if (!m_fInitialized)
				return;

			if (args.NewDisplayIndex == args.OldDisplayIndex)
				return;

			foreach (ColumnHeader Column in Columns)
				{
				if (args.NewDisplayIndex > args.OldDisplayIndex)
					{
					if (Column.DisplayIndex > args.OldDisplayIndex && Column.DisplayIndex > 0)
						m_DataFiles.Preferences.SetColumnIndex(m_eListViewType, Column.Text, Column.DisplayIndex - 1);

					if (Column.DisplayIndex == args.NewDisplayIndex)
						break;
					}
				else
					{
					if (Column.DisplayIndex >= args.NewDisplayIndex && Column.DisplayIndex < args.OldDisplayIndex && Column.DisplayIndex < Columns.Count - 1)
						m_DataFiles.Preferences.SetColumnIndex(m_eListViewType, Column.Text, Column.DisplayIndex + 1);

					if (Column.DisplayIndex == args.OldDisplayIndex)
						break;
					}

				}

			m_DataFiles.Preferences.SetColumnIndex(m_eListViewType, args.Header.Text, args.NewDisplayIndex);
			}

		//============================================================================*
		// OnColumnWidthChanged()
		//============================================================================*

		protected override void OnColumnWidthChanged(ColumnWidthChangedEventArgs args)
			{
			base.OnColumnWidthChanged(args);

			if (!m_fInitialized)
				return;

			m_DataFiles.Preferences.SetColumnWidth(m_eListViewType, Columns[args.ColumnIndex].Text, Columns[args.ColumnIndex].Width);
			}

		//============================================================================*
		// OnDrawColumnHeader()
		//============================================================================*

		protected override void OnDrawColumnHeader(DrawListViewColumnHeaderEventArgs args)
			{
			args.DrawBackground();

			string strText = Columns[args.ColumnIndex].Text;

			Font HeaderFont = SystemFonts.DefaultFont;

			SizeF TextSize = args.Graphics.MeasureString(strText, HeaderFont);

			Bitmap SortImage = SortingOrder == SortOrder.Ascending ? sm_SortAscendingImage : sm_SortDescendingImage;

			int nImageWidth = 0;

			if (args.ColumnIndex == SortingColumn)
				nImageWidth = SortImage.Width;

			int nX = args.Bounds.X;
			int nY = (args.Bounds.Height / 2) - (HeaderFont.Height / 2);

			switch (Columns[args.ColumnIndex].TextAlign)
				{
				case HorizontalAlignment.Center:
					nX += (int) ((args.Bounds.Width / 2) - ((TextSize.Width + nImageWidth + 5) / 2));

					args.Graphics.DrawString(strText, HeaderFont, Brushes.Black, nX, nY);

					nX += (int) TextSize.Width + 5;

					break;

				case HorizontalAlignment.Right:
					nX += (args.Bounds.Width - (int) TextSize.Width);

					args.Graphics.DrawString(strText, HeaderFont, Brushes.Black, nX, nY);

					nX -= (int) (5 + nImageWidth);

					break;

				case HorizontalAlignment.Left:
					args.Graphics.DrawString(strText, HeaderFont, Brushes.Black, nX, nY);

					nX += (int) TextSize.Width + 5;

					break;
				}

			if (args.ColumnIndex == SortingColumn)
				args.Graphics.DrawImage(SortImage, nX, nY);
			}

		//============================================================================*
		// OnDrawSubItem()
		//============================================================================*

		protected override void OnDrawSubItem(DrawListViewSubItemEventArgs args)
			{
			//----------------------------------------------------------------------------*
			// Website Column
			//----------------------------------------------------------------------------*

			if (args.Header.Text == "Website")
				{
				Brush WebsiteBrush = Brushes.Blue;

				cManufacturer Manufacturer = (cManufacturer) args.Item.Tag;

				if (Manufacturer.WebSiteVisited)
					WebsiteBrush = Brushes.Maroon;

				if (args.Item.Selected)
					{
					if (Focused)
						{
						args.SubItem.BackColor = SystemColors.Highlight;

						WebsiteBrush = Brushes.White;
						}
					else
						args.SubItem.BackColor = SystemColors.ControlLight;

					args.SubItem.ForeColor = SystemColors.HighlightText;
					}
				else
					{
					args.SubItem.BackColor = SystemColors.Window;
					args.SubItem.ForeColor = SystemColors.WindowText;
					}

				args.DrawBackground();

				Font WebSiteFont = new Font(SystemFonts.DefaultFont, FontStyle.Underline);

				args.Graphics.DrawString(args.SubItem.Text, WebSiteFont, WebsiteBrush, args.Bounds);

				return;
				}

			//----------------------------------------------------------------------------*
			// Caliber Name
			//----------------------------------------------------------------------------*

			if (args.Header.Text == "Caliber" || args.Header.Text == "Primary Caliber")
				{
				cCaliber Caliber = GetCaliberFromTag(args.Item);

				if (Caliber != null && Caliber.SAAMIPDF != null && Caliber.SAAMIPDF.Length > 0)
					{
					Brush ViewBrush = Brushes.Blue;

					if (args.Item.Selected)
						{
						if (Focused)
							{
							args.SubItem.BackColor = SystemColors.Highlight;

							ViewBrush = Brushes.White;
							}
						else
							args.SubItem.BackColor = SystemColors.ControlLight;

						args.SubItem.ForeColor = SystemColors.HighlightText;
						}
					else
						{
						args.SubItem.BackColor = SystemColors.Window;
						args.SubItem.ForeColor = Color.Blue;
						}

					args.DrawBackground();

					Font ViewFont = new Font(SystemFonts.DefaultFont, FontStyle.Underline);

					SizeF TextSize = args.Graphics.MeasureString(args.SubItem.Text, ViewFont);

					Rectangle Rect = args.Bounds;

					Rect.Y += (Rect.Height / 2) - (int) (TextSize.Height / 2);

					if (args.ColumnIndex == 0 && CheckBoxes)
						{
						CheckBoxRenderer.DrawCheckBox(args.Graphics, new Point(Rect.Left + 4, Rect.Top), args.Bounds, "", ViewFont, false, (args.Item.Checked ? CheckBoxState.CheckedNormal : CheckBoxState.UncheckedNormal));

						Size BoxSize = CheckBoxRenderer.GetGlyphSize(args.Graphics, (args.Item.Checked ? CheckBoxState.CheckedNormal : CheckBoxState.UncheckedNormal));

						args.Graphics.DrawString(args.SubItem.Text, ViewFont, ViewBrush, args.Bounds.X + BoxSize.Width + 6, args.Bounds.Y);
						}
					else
						args.Graphics.DrawString(args.SubItem.Text, ViewFont, ViewBrush, args.Bounds.X + 4, args.Bounds.Y);

					return;
					}
				}

			//----------------------------------------------------------------------------*
			// Checkmark Column
			//----------------------------------------------------------------------------*

			if (args.SubItem.Text == "Y")
				{
				Bitmap CheckImage = null;

				if (args.Item.Selected)
					{
					if (Focused)
						{
						args.SubItem.BackColor = SystemColors.Highlight;

						CheckImage = sm_CheckMarkSelectedImage;
						}
					else
						{
						args.SubItem.BackColor = SystemColors.ControlLight;

						CheckImage = sm_CheckMarkImage;
						}

					args.SubItem.ForeColor = SystemColors.HighlightText;
					}
				else
					{
					CheckImage = sm_CheckMarkImage;

					args.SubItem.ForeColor = SystemColors.WindowText;
					args.SubItem.BackColor = SystemColors.Window;
					}

				args.DrawBackground();

				args.Graphics.DrawImage(CheckImage, args.Bounds.Left + (args.Bounds.Width / 2) - (CheckImage.Width / 2), args.Bounds.Top + (args.Bounds.Height / 2) - (CheckImage.Height / 2));

				return;
				}

			args.DrawDefault = true;
			}

		//============================================================================*
		// OnGotFocus()
		//============================================================================*

		protected override void OnGotFocus(EventArgs args)
			{
			if (SelectedItems.Count > 0)
				EnsureVisible(SelectedItems[0].Index);
			}

		//============================================================================*
		// OnItemCheck()
		//============================================================================*

		protected override void OnItemCheck(ItemCheckEventArgs ice)
			{
			if (this.m_fCheckFromDoubleClick)
				{
				ice.NewValue = ice.CurrentValue;
				m_fCheckFromDoubleClick = false;
				}
			else
				base.OnItemCheck(ice);
			}

		//============================================================================*
		// OnKeyDown()
		//============================================================================*

		protected override void OnKeyDown(KeyEventArgs e)
			{
			m_fCheckFromDoubleClick = false;

			base.OnKeyDown(e);
			}

		//============================================================================*
		// OnMouseClick()
		//============================================================================*

		protected override void OnMouseClick(MouseEventArgs args)
			{
			int nX = args.X;
			int nY = args.Y;

			ListViewItem Item = GetItemAt(nX, nY);

			//----------------------------------------------------------------------------*
			// Find the Column that was clicked
			//----------------------------------------------------------------------------*

			int nColumn = 0;
			int nColumnX = 0;

			bool fColumnFound = false;

			if (Item != null)
				{
				foreach (ColumnHeader Column in Columns)
					{
					if (nX >= nColumnX && nX <= nColumnX + Column.Width)
						{
						fColumnFound = true;

						break;
						}

					nColumnX += Column.Width;
					nColumn++;
					}
				}

			if (fColumnFound)
				{
				ColumnHeader Header = Columns[nColumn];

				Graphics g = Graphics.FromHwnd(this.Handle);

				SizeF TextSize = g.MeasureString(Item.SubItems[nColumn].Text, this.Font);

				//----------------------------------------------------------------------------*
				// Website Column
				//----------------------------------------------------------------------------*

				if (Header.Text == "Website")
					{
					if (Item.SubItems[nColumn].Text.Length > 0)
						{
						if (nX - nColumnX < (int) TextSize.Width)
							{
							try
								{
								System.Diagnostics.Process.Start(Item.SubItems[nColumn].Text);

								WebsiteVisited(Item);
								}
							catch
								{
								MessageBox.Show("Invalid Website URL.  Correct the URL and try again.", "Invalid URL", MessageBoxButtons.OK, MessageBoxIcon.Error);

								return;
								}
							}
						}
					}

				//----------------------------------------------------------------------------*
				// Caliber Column
				//----------------------------------------------------------------------------*

				if (Header.Text == "Caliber" || Header.Text == "Primary Caliber")
					{
					cCaliber Caliber = GetCaliberFromTag(Item);

					if (Caliber != null && Caliber.SAAMIPDF != null && Caliber.SAAMIPDF.Length > 0)
						{
						Size BoxSize = CheckBoxRenderer.GetGlyphSize(g, (Item.Checked ? CheckBoxState.CheckedNormal : CheckBoxState.UncheckedNormal));

						if ((nColumn == 0 && CheckBoxes && nX > 4 + BoxSize.Width && nX - 4 - BoxSize.Width - nColumnX < (int) TextSize.Width) ||
							(nColumn == 0 && !CheckBoxes && nX > 4 && nX - nColumnX < (int) TextSize.Width) ||
							(nColumn != 0 && nX > 4 && nX - nColumnX < (int) TextSize.Width))
							cCaliber.ShowSAAMIPDF(m_DataFiles, Caliber);
						}
					}
				}

			base.OnMouseClick(args);
			}

		//============================================================================*
		// OnMouseDown()
		//============================================================================*

		protected override void OnMouseDown(MouseEventArgs e)
			{
			if ((e.Button == MouseButtons.Left) && (e.Clicks > 1))
				m_fCheckFromDoubleClick = true;

			base.OnMouseDown(e);
			}

		//============================================================================*
		// OnMouseMove()
		//============================================================================*

		protected override void OnMouseMove(MouseEventArgs args)
			{
			int nX = args.X;
			int nY = args.Y;

			ListViewItem Item = GetItemAt(nX, nY);

			//----------------------------------------------------------------------------*
			// Find the Column that was clicked
			//----------------------------------------------------------------------------*

			int nColumn = 0;
			int nColumnX = 0;

			bool fColumnFound = false;

			if (Item != null)
				{
				foreach (ColumnHeader Column in Columns)
					{
					if (nX >= nColumnX && nX <= nColumnX + Column.Width)
						{
						fColumnFound = true;

						break;
						}

					nColumnX += Column.Width;
					nColumn++;
					}
				}

			this.Cursor = Cursors.Default;

			if (fColumnFound && nColumn < Item.SubItems.Count && nColumn < Columns.Count)
				{
				ColumnHeader Header = Columns[nColumn];

				Graphics g = Graphics.FromHwnd(this.Handle);

				SizeF TextSize = g.MeasureString(Item.SubItems[nColumn].Text, this.Font);

				//----------------------------------------------------------------------------*
				// Website Column
				//----------------------------------------------------------------------------*

				if (Header.Text == "Website")
					{
					if (Item.SubItems[nColumn].Text.Length > 0)
						{
						if (nX - nColumnX < (int) TextSize.Width)
							this.Cursor = Cursors.Hand;
						}
					}

				//----------------------------------------------------------------------------*
				// Caliber Column
				//----------------------------------------------------------------------------*

				if (Header.Text == "Caliber" || Header.Text == "Primary Caliber")
					{
					cCaliber Caliber = GetCaliberFromTag(Item);

					if (Caliber != null && Caliber.SAAMIPDF != null && Caliber.SAAMIPDF.Length > 0)
						{
						Size BoxSize = CheckBoxRenderer.GetGlyphSize(g, (Item.Checked ? CheckBoxState.CheckedNormal : CheckBoxState.UncheckedNormal));

						if ((nColumn == 0 && CheckBoxes && nX > 4 + BoxSize.Width && nX - 4 - BoxSize.Width - nColumnX < (int) TextSize.Width) ||
							(nColumn == 0 && !CheckBoxes && nX > 4 && nX - nColumnX < (int) TextSize.Width) ||
							(nColumn != 0 && nX > 4 && nX - nColumnX < (int) TextSize.Width))
							this.Cursor = Cursors.Hand;
						}
					}
				}

			base.OnMouseMove(args);
			}

		//============================================================================*
		// Populate()
		//============================================================================*

		public virtual void Populate()
			{
			}

		//============================================================================*
		// PopulateColumns()
		//============================================================================*

		protected virtual void PopulateColumns(cListViewColumn[] arColumns)
			{
			Columns.Clear();

			foreach (cListViewColumn ListViewColumn in arColumns)
				{
				ColumnHeader Column = new ColumnHeader();

				Column.Text = ListViewColumn.Text;
				Column.Name = ListViewColumn.Name;
				Column.TextAlign = ListViewColumn.TextAlign;

				int nWidth = m_DataFiles.Preferences.GetColumnWidth(m_eListViewType, ListViewColumn.Text);

				Column.Width = (nWidth > 0) ? nWidth : ListViewColumn.Width;

				Columns.Add(Column);
				}

			foreach (ColumnHeader Header in Columns)
				{
				int nDisplayIndex = m_DataFiles.Preferences.GetColumnIndex(m_eListViewType, Header.Text);

				Header.DisplayIndex = nDisplayIndex >= 0 && nDisplayIndex < Columns.Count && nDisplayIndex >= 0 ? nDisplayIndex : Header.DisplayIndex;
				}
			}

		//============================================================================*
		// PopulateGroups()
		//============================================================================*

		protected virtual void PopulateGroups()
			{
			ListViewGroup Group = new ListViewGroup("HandgunGroup", "Handgun");

			Groups.Add(Group);

			Group = new ListViewGroup("RifleGroup", "Rifle");

			Groups.Add(Group);

			Group = new ListViewGroup("ShotgunGroup", "Shotgun");

			Groups.Add(Group);
			}

		//============================================================================*
		// Populating Property
		//============================================================================*

		public bool Populating
			{
			get
				{
				return (m_fPopulating);
				}
			protected set
				{
				m_fPopulating = value;
				}
			}

		//============================================================================*
		// SortingColumn Property
		//============================================================================*

		public int SortingColumn
			{
			get
				{
				return (m_nSortColumn);
				}
			set
				{
				m_nSortColumn = value;
				}
			}

		//============================================================================*
		// SortingOrder Property
		//============================================================================*

		public SortOrder SortingOrder
			{
			get
				{
				return (m_SortOrder);
				}
			set
				{
				m_SortOrder = value;
				}
			}

		//============================================================================*
		// ToolTip Property
		//============================================================================*

		public string ToolTip
			{
			get
				{
				return (m_strToolTip);
				}
			set
				{
				m_strToolTip = value;

				if (m_ToolTip == null)
					m_ToolTip = new ToolTip();

				m_ToolTip.ShowAlways = true;
				m_ToolTip.RemoveAll();
				m_ToolTip.SetToolTip(this, m_strToolTip);
				}
			}

		//============================================================================*
		// WebsiteVisited()
		//============================================================================*

		protected virtual void WebsiteVisited(ListViewItem Item)
			{
			}
		}
	}
