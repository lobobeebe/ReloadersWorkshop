//============================================================================*
// cFirearmAccessoryListPreviewDialog.cs
//
// Copyright © 2013-2017, Kevin S. Beebe
// All Rights Reserved
//============================================================================*

//============================================================================*
// .Net Using Statements
//============================================================================*

using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

//============================================================================*
// Namespace
//============================================================================*

namespace ReloadersWorkShop
	{
	//============================================================================*
	// cFirearmAccessoryListPreviewDialog Class
	//============================================================================*

	public class cFirearmAccessoryListPreviewDialog : PrintPreviewDialog
		{
		//============================================================================*
		// Private Static Data Members
		//============================================================================*

		private static cFirearm sm_Firearm = null;
		private static cGearList sm_GearList = null;
		private static bool sm_fDrawHeader = true;
		private static bool sm_fDrawGroups = true;

		private static cPrintColumn[] sm_Columns = new cPrintColumn[]
			{
			new cPrintColumn("Manufacturer"),
			new cPrintColumn("Part #"),
			new cPrintColumn("Description"),
			new cPrintColumn("Acquired on"),
			new cPrintColumn("Price"),
			new cPrintColumn("Tax"),
			new cPrintColumn("Shipping"),
			new cPrintColumn("Total")
			};

		//============================================================================*
		// Private Data Members
		//============================================================================*

		private bool m_fInitialized = false;

		private cDataFiles m_DataFiles = null;

		//============================================================================*
		// cFirearmAccessoryListPreviewDialog() - Constructor
		//============================================================================*

		public cFirearmAccessoryListPreviewDialog(cDataFiles DataFiles, bool fDrawHeader = true, bool fDrawGroups = true)
			{
			m_DataFiles = DataFiles;

			sm_fDrawHeader = fDrawHeader;
			sm_fDrawGroups = fDrawGroups;

			if (m_DataFiles.Preferences.FirearmListPreviewMaximized)
				{
				WindowState = FormWindowState.Maximized;
				}
			else
				{
				WindowState = FormWindowState.Normal;

				Location = m_DataFiles.Preferences.FirearmListPreviewLocation;
				ClientSize = m_DataFiles.Preferences.FirearmListPreviewSize;
				}

			Text = "Reloader's WorkShop Firearm Accessory List - Print Preview";

			sm_Columns[4].Name = String.Format("Price ({0})", m_DataFiles.Preferences.Currency);
			sm_Columns[5].Name = String.Format("Tax ({0})", m_DataFiles.Preferences.Currency);
			sm_Columns[6].Name = String.Format("Shipping ({0})", m_DataFiles.Preferences.Currency);
			sm_Columns[7].Name = String.Format("Total ({0})", m_DataFiles.Preferences.Currency);

			PrintDocument FirearmAccessoryListDocument = new PrintDocument();
			FirearmAccessoryListDocument.PrintPage += OnPrintPage;

			Document = FirearmAccessoryListDocument;

			UseAntiAlias = true;

			ResetPrintedFlag(m_DataFiles);

			m_fInitialized = true;
			}

		//============================================================================*
		// DrawAccessoryList()
		//============================================================================*

		public static float DrawAccessoryList(cDataFiles DataFiles, ref PrintPageEventArgs e, float nStartY = -1.0f, cGear.eGearTypes eType = cGear.eGearTypes.Firearm)
			{
			//----------------------------------------------------------------------------*
			// Set the currency symbol on the Price column
			//----------------------------------------------------------------------------*

			sm_Columns[4].Name = String.Format("Price ({0})", DataFiles.Preferences.Currency);

			//----------------------------------------------------------------------------*
			// Gather the list of accessories
			//----------------------------------------------------------------------------*

			if (sm_GearList == null)
				sm_GearList = DataFiles.FirearmAccessoryList(sm_Firearm, eType);

			sm_GearList.Sort(sm_fDrawGroups);

			//----------------------------------------------------------------------------*
			// Create the fonts
			//----------------------------------------------------------------------------*

			Font AccessoryTypeFont = new Font("Trebuchet MS", 10, FontStyle.Bold);
			Font HeaderFont = new Font("Trebuchet MS", 8, FontStyle.Bold);
			Font DataFont = new Font("Trebuchet MS", 8, FontStyle.Regular);

			//----------------------------------------------------------------------------*
			// Calculate Column Header Name Widths
			//----------------------------------------------------------------------------*

			string strText;
			SizeF TextSize;

			foreach (cPrintColumn PrintColumn in sm_Columns)
				{
				TextSize = e.Graphics.MeasureString(PrintColumn.Name, HeaderFont);

				if (TextSize.Width > PrintColumn.Width)
					PrintColumn.Width = TextSize.Width;
				}

			//----------------------------------------------------------------------------*
			// Calculate Header Widths
			//----------------------------------------------------------------------------*

			foreach (cGear Gear in sm_GearList)
				{
				// Manufacturer Name

				TextSize = e.Graphics.MeasureString(Gear.Manufacturer.ToString(), DataFont);

				if (TextSize.Width > sm_Columns[0].Width)
					sm_Columns[0].Width = TextSize.Width;

				// Part Number

				TextSize = e.Graphics.MeasureString(Gear.PartNumber, DataFont);

				if (TextSize.Width > sm_Columns[1].Width)
					sm_Columns[1].Width = TextSize.Width;

				// Description

				TextSize = e.Graphics.MeasureString(Gear.Description, DataFont);

				if (TextSize.Width > sm_Columns[2].Width)
					sm_Columns[2].Width = TextSize.Width;

				// Purchase Date

				TextSize = e.Graphics.MeasureString(Gear.PurchaseDate.ToShortDateString(), DataFont);

				if (TextSize.Width > sm_Columns[3].Width)
					sm_Columns[3].Width = TextSize.Width;

				// Purchase Price

				TextSize = e.Graphics.MeasureString(String.Format("{0:N2}", Gear.PurchasePrice), DataFont);

				if (TextSize.Width > sm_Columns[4].Width)
					sm_Columns[4].Width = TextSize.Width;

				// Tax

				TextSize = e.Graphics.MeasureString(String.Format("{0:N2}", Gear.Tax), DataFont);

				if (TextSize.Width > sm_Columns[5].Width)
					sm_Columns[5].Width = TextSize.Width;

				// Shipping

				TextSize = e.Graphics.MeasureString(String.Format("{0:N2}", Gear.Shipping), DataFont);

				if (TextSize.Width > sm_Columns[6].Width)
					sm_Columns[6].Width = TextSize.Width;

				// Total

				TextSize = e.Graphics.MeasureString(String.Format("{0:N2}", Gear.PurchasePrice + Gear.Tax + Gear.Shipping), DataFont);

				if (TextSize.Width > sm_Columns[7].Width)
					sm_Columns[7].Width = TextSize.Width;
				}

			float nLineWidth = 0;

			foreach (cPrintColumn PrintColumn in sm_Columns)
				nLineWidth += PrintColumn.Width;

			nLineWidth += ((sm_Columns.Length - 1) * 10.0f);

			float nLeftMargin = (e.PageBounds.Width / 2) - (nLineWidth / 2.0f);

			//----------------------------------------------------------------------------*
			// Set Rectangle Size Info
			//----------------------------------------------------------------------------*

			Rectangle PageRect = e.PageBounds;

			int nXDPI = (int) ((double) PageRect.Width / 8.5);
			int nYDPI = (int) ((double) PageRect.Height / 11);

			PageRect.X += (int) ((double) nXDPI * 0.5);
			PageRect.Width -= ((int) ((double) nXDPI * 0.5) * 2);

			PageRect.Y += (int) ((double) nYDPI * 0.5);
			PageRect.Height -= ((int) ((double) nYDPI * 0.5) * 2);

			float nY = nStartY >= 0.0f ? nStartY : PageRect.Top;
			float nX = PageRect.Left;

			bool fPageHeader = false;
			bool fTypeHeader = false;
			bool fHeader = false;
			cGear.eGearTypes eLastType = cGear.eGearTypes.Firearm;

			//----------------------------------------------------------------------------*
			// Loop through the accessories
			//----------------------------------------------------------------------------*

			if (sm_fDrawGroups)
				sm_GearList.Sort(cGear.Comparer);

			foreach (cGear Gear in sm_GearList)
				{
				if (Gear.Printed)
					continue;

				if (nY > PageRect.Height - HeaderFont.Height - (AccessoryTypeFont.Height * 2))
					{
					e.HasMorePages = true;

					return (nY);
					}

				if (Gear.GearType != (cGear.eGearTypes) eLastType)
					{
					fTypeHeader = false;

					eLastType = Gear.GearType;
					}

				//----------------------------------------------------------------------------*
				// Draw the page header if needed
				//----------------------------------------------------------------------------*

				if (!fPageHeader && sm_fDrawHeader)
					{
					//----------------------------------------------------------------------------*
					// Draw the Title
					//----------------------------------------------------------------------------*

					nY = cPrintObject.PrintReportTitle("Firearm Parts & Accessories List", e, PageRect);

					strText = "";

					if (sm_Firearm != null)
						strText = String.Format("Attached to {0} only.", sm_Firearm.ToString());

					if (!String.IsNullOrEmpty(strText))
						{
						TextSize = e.Graphics.MeasureString(strText, HeaderFont);

						e.Graphics.DrawString(strText, HeaderFont, Brushes.Black, e.MarginBounds.Left + (e.MarginBounds.Width / 2) - (TextSize.Width / 2), nY);

						nY += HeaderFont.Height;
						}

					fPageHeader = true;
					fTypeHeader = false;
					}

				//----------------------------------------------------------------------------*
				// Draw the type header if needed
				//----------------------------------------------------------------------------*

				if (!fTypeHeader && sm_fDrawGroups)
					{
					nY += AccessoryTypeFont.Height;

					strText = cGear.GearTypeString(Gear.GearType);

					TextSize = e.Graphics.MeasureString(strText, AccessoryTypeFont);

					e.Graphics.DrawString(strText, AccessoryTypeFont, Brushes.Black, nLeftMargin, nY);

					nY += TextSize.Height;

					fTypeHeader = true;
					fHeader = false;
					}

				//----------------------------------------------------------------------------*
				// Draw the column headers if needed
				//----------------------------------------------------------------------------*

				if (!fHeader)
					{
					nY += HeaderFont.Height;

					nX = nLeftMargin;

					foreach (cPrintColumn PrintColumn in sm_Columns)
						{
						e.Graphics.DrawString(PrintColumn.Name, HeaderFont, Brushes.Black, nX, nY);

						nX += (PrintColumn.Width + 10);
						}

					nY += HeaderFont.Height;

					e.Graphics.DrawLine(Pens.Black, nLeftMargin, nY, nX - 10, nY);

					nY += 4;

					fHeader = true;
					}

				//----------------------------------------------------------------------------*
				// Draw the accessory info
				//----------------------------------------------------------------------------*

				// Manufacturer Name

				strText = Gear.Manufacturer.Name;

				nX = nLeftMargin;

				e.Graphics.DrawString(strText, DataFont, Brushes.Black, nX, nY);

				nX += (sm_Columns[0].Width + 10);

				// Part #

				strText = Gear.PartNumber;

				e.Graphics.DrawString(strText, DataFont, Brushes.Black, nX, nY);

				nX += (sm_Columns[1].Width + 10);

				// Description

				strText = Gear.Description;

				e.Graphics.DrawString(strText, DataFont, Brushes.Black, nX, nY);

				nX += (sm_Columns[2].Width + 10);

				// Purchase Date

				if (Gear.PurchaseDate.Year < 1900)
					strText = "Unknown";
				else
					strText = Gear.PurchaseDate.ToShortDateString();

				TextSize = e.Graphics.MeasureString(strText, DataFont);

				e.Graphics.DrawString(strText, DataFont, Brushes.Black, nX + (sm_Columns[3].Width / 2) - (TextSize.Width / 2), nY);

				nX += (sm_Columns[3].Width + 10);

				// Purchase Price

				strText = Gear.PurchasePrice > 0.0 ? String.Format("{0:N2}", Gear.PurchasePrice) : "-";

				TextSize = e.Graphics.MeasureString(strText, DataFont);

				e.Graphics.DrawString(strText, DataFont, Brushes.Black, nX + sm_Columns[4].Width - TextSize.Width, nY);

				nX += (sm_Columns[4].Width + 10);

				// Tax

				strText = Gear.PurchasePrice > 0.0 ? String.Format("{0:N2}", Gear.Tax) : "-";

				TextSize = e.Graphics.MeasureString(strText, DataFont);

				e.Graphics.DrawString(strText, DataFont, Brushes.Black, nX + sm_Columns[5].Width - TextSize.Width, nY);

				nX += (sm_Columns[5].Width + 10);

				// Shipping

				strText = Gear.PurchasePrice > 0.0 ? String.Format("{0:N2}", Gear.Shipping) : "-";

				TextSize = e.Graphics.MeasureString(strText, DataFont);

				e.Graphics.DrawString(strText, DataFont, Brushes.Black, nX + sm_Columns[6].Width - TextSize.Width, nY);

				nX += (sm_Columns[6].Width + 10);

				// Total

				strText = Gear.PurchasePrice > 0.0 ? String.Format("{0:N2}", Gear.PurchasePrice + Gear.Tax + Gear.Shipping) : "-";

				TextSize = e.Graphics.MeasureString(strText, DataFont);

				e.Graphics.DrawString(strText, DataFont, Brushes.Black, nX + sm_Columns[7].Width - TextSize.Width, nY);

				nX += (sm_Columns[7].Width);

				nY += DataFont.Height;

				Gear.Printed = true;
				}

			e.HasMorePages = false;

			return (nY);
			}

		//============================================================================*
		// DrawColumnHeaders()
		//============================================================================*

		public static void DrawColumnHeaders(PrintPageEventArgs e, Rectangle PageRect)
			{
			}

		//============================================================================*
		// DrawGroups Property
		//============================================================================*

		public static bool DrawGroups
			{
			get
				{
				return (sm_fDrawGroups);
				}
			set
				{
				sm_fDrawGroups = value;
				}
			}

		//============================================================================*
		// DrawHeader Property
		//============================================================================*

		public static bool DrawHeader
			{
			get
				{
				return (sm_fDrawHeader);
				}
			set
				{
				sm_fDrawHeader = value;
				}
			}

		//============================================================================*
		// Firearm Property
		//============================================================================*

		public static cFirearm Firearm
			{
			get
				{
				return (sm_Firearm);
				}
			set
				{
				sm_Firearm = value;
				}
			}

		//============================================================================*
		// GearList Property
		//============================================================================*

		public static cGearList GearList
			{
			get
				{
				return (sm_GearList);
				}
			set
				{
				sm_GearList = value;
				}
			}

		//============================================================================*
		// OnMove()
		//============================================================================*

		protected override void OnMove(EventArgs e)
			{
			base.OnMove(e);

			if (!m_fInitialized)
				return;

			m_DataFiles.Preferences.FirearmListPreviewLocation = Location;
			}

		//============================================================================*
		// OnPrintPage()
		//============================================================================*

		private void OnPrintPage(object sender, PrintPageEventArgs e)
			{
			DrawAccessoryList(m_DataFiles, ref e);
			}

		//============================================================================*
		// OnResize()
		//============================================================================*

		protected override void OnResize(EventArgs e)
			{
			base.OnResize(e);

			if (!m_fInitialized)
				return;

			m_DataFiles.Preferences.FirearmListPreviewMaximized = WindowState == FormWindowState.Maximized;

			if (!m_DataFiles.Preferences.FirearmListPreviewMaximized)
				{
				m_DataFiles.Preferences.FirearmListPreviewLocation = Location;
				m_DataFiles.Preferences.FirearmListPreviewSize = ClientSize;
				}
			}

		//============================================================================*
		// ResetPrintedFlag()
		//============================================================================*

		public static void ResetPrintedFlag(cDataFiles DataFiles)
			{
			foreach (cGear Gear in DataFiles.GearList)
				Gear.Printed = false;
			}
		}
	}
