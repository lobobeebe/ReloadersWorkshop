//============================================================================*
// cAmmoListPreviewDialog.cs
//
// Copyright © 2013-2014, Kevin S. Beebe
// All Rights Reserved
//============================================================================*

//============================================================================*
// .Net Using Statements
//============================================================================*

using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

using ReloadersWorkShop.Preferences;

//============================================================================*
// Namespace
//============================================================================*

namespace ReloadersWorkShop
	{
	//============================================================================*
	// cAmmoListPreviewDialog Class
	//============================================================================*

	public class cAmmoListPreviewDialog : PrintPreviewDialog
		{
		//============================================================================*
		// Private Data Members
		//============================================================================*

		private bool m_fInitialized = false;

		private cDataFiles m_DataFiles = null;

		private cAmmoList m_AmmoList = null;

		private cPrintColumn[] m_AmmoColumns = new cPrintColumn[]
			{
			new cPrintColumn("Manufacturer"),
			new cPrintColumn("Part #"),
			new cPrintColumn("Model"),
			new cPrintColumn("Reload?"),
			new cPrintColumn("Cal."),
			new cPrintColumn("Min. Qty"),
			new cPrintColumn("On Hand"),
			new cPrintColumn("Cost")
			};

		//============================================================================*
		// cAmmoListPreviewDialog() - Constructor
		//============================================================================*

		public cAmmoListPreviewDialog(cDataFiles DataFiles)
			{
			m_DataFiles = DataFiles;

			if (m_DataFiles.Preferences.AmmoListPreviewMaximized)
				{
				WindowState = FormWindowState.Maximized;
				}
			else
				{
				Location = m_DataFiles.Preferences.AmmoListPreviewLocation;
				ClientSize = m_DataFiles.Preferences.AmmoListPreviewSize;
				}

			Text = "Reloader's WorkShop Ammuniton List - Print Preview";

			PrintDocument AmmoListDocument = new PrintDocument();
			AmmoListDocument.PrintPage += OnPrintPage;

			Document = AmmoListDocument;

			UseAntiAlias = true;

			//----------------------------------------------------------------------------*
			// Add the unit of measure to the Bullet Weight column
			//----------------------------------------------------------------------------*

			m_AmmoColumns[4].Name += String.Format(" ({0})", cDataFiles.MetricString(cDataFiles.eDataType.BulletWeight));

			if (!cPreferences.TrackInventory)
				m_AmmoColumns[6].Name = "Box of";

			//----------------------------------------------------------------------------*
			// Gather the list of ammo, reset flags, and exit
			//----------------------------------------------------------------------------*

			m_AmmoList = m_DataFiles.GetAmmoList();

			ResetPrintedFlag();

			m_fInitialized = true;
			}

		//============================================================================*
		// OnMove()
		//============================================================================*

		protected override void OnMove(EventArgs e)
			{
			base.OnMove(e);

			if (!m_fInitialized)
				return;

			m_DataFiles.Preferences.ShoppingListPreviewLocation = Location;
			}

		//============================================================================*
		// OnPrintPage()
		//============================================================================*

		private void OnPrintPage(object sender, PrintPageEventArgs e)
			{
			//----------------------------------------------------------------------------*
			// Create the fonts
			//----------------------------------------------------------------------------*

//			Font TitleFont = new Font("Trebuchet MS", 16, FontStyle.Bold);
			Font HeaderFont = new Font("Trebuchet MS", 10, FontStyle.Bold);
			Font DataFont = new Font("Trebuchet MS", 8, FontStyle.Regular);

			//----------------------------------------------------------------------------*
			// Calculate Column Header Name Widths
			//----------------------------------------------------------------------------*

			string strText;
			SizeF TextSize;

			foreach (cPrintColumn PrintColumn in m_AmmoColumns)
				{
				TextSize = e.Graphics.MeasureString(PrintColumn.Name, HeaderFont);

				if (TextSize.Width > PrintColumn.Width)
					PrintColumn.Width = TextSize.Width;
				}

			//----------------------------------------------------------------------------*
			// Calculate Header Widths for Supplies
			//----------------------------------------------------------------------------*

			foreach (cAmmo Ammo in m_AmmoList)
				{
				//----------------------------------------------------------------------------*
				// Manufacturer
				//----------------------------------------------------------------------------*

				TextSize = e.Graphics.MeasureString(Ammo.Manufacturer.ToString(), DataFont);

				if (TextSize.Width > m_AmmoColumns[0].Width)
					m_AmmoColumns[0].Width = TextSize.Width;

				//----------------------------------------------------------------------------*
				// Part Number
				//----------------------------------------------------------------------------*

				TextSize = e.Graphics.MeasureString(Ammo.PartNumber, DataFont);

				if (TextSize.Width > m_AmmoColumns[1].Width)
					m_AmmoColumns[1].Width = TextSize.Width;

				//----------------------------------------------------------------------------*
				// Model/Type
				//----------------------------------------------------------------------------*

				TextSize = e.Graphics.MeasureString(Ammo.Type, DataFont);

				if (TextSize.Width > m_AmmoColumns[2].Width)
					m_AmmoColumns[2].Width = TextSize.Width;

				//----------------------------------------------------------------------------*
				// Caliber
				//----------------------------------------------------------------------------*

				TextSize = e.Graphics.MeasureString(Ammo.Caliber.ToString(), DataFont);

				if (TextSize.Width > m_AmmoColumns[3].Width)
					m_AmmoColumns[4].Width = TextSize.Width;
				}

			//----------------------------------------------------------------------------*
			// Prepare for printing
			//----------------------------------------------------------------------------*

			Rectangle PageRect = e.PageBounds;

			int nXDPI = (int)((double)PageRect.Width / 8.5);
			int nYDPI = (int)((double)PageRect.Height / 11);

			PageRect.X += (int)((double)nXDPI * 0.5);
			PageRect.Width -= ((int)((double)nXDPI * 0.5) * 2);

			PageRect.Y += (int)((double)nYDPI * 0.5);
			PageRect.Height -= ((int)((double)nYDPI * 0.5) * 2);

			float nY = PageRect.Top;
			float nX = PageRect.Left;

			bool fPageHeader = false;

			//----------------------------------------------------------------------------*
			// Loop through the ammo in the list
			//----------------------------------------------------------------------------*

			bool fHeader = false;

			foreach (cAmmo Ammo in m_AmmoList)
				{
				if (nY > PageRect.Bottom)
					{
					e.HasMorePages = true;

					return;
					}

				//----------------------------------------------------------------------------*
				// If this Ammo has already been printed, skip
				// to the next Ammo in the list
				//----------------------------------------------------------------------------*

				if (Ammo.Printed)
					continue;

				Ammo.Printed = true;

				//----------------------------------------------------------------------------*
				// Draw the page header if needed
				//----------------------------------------------------------------------------*

				if (!fPageHeader)
					{
					//----------------------------------------------------------------------------*
					// Draw the Title
					//----------------------------------------------------------------------------*

					nY = cPrintObject.PrintReportTitle(m_DataFiles.Preferences.AmmoPrintBelowStock ? "Ammunition Shopping List" : "Ammunition List", PageRect, e.Graphics);

					if (cPreferences.TrackInventory)
						{
						strText = m_DataFiles.CostText;

						TextSize = e.Graphics.MeasureString(strText, HeaderFont);

						e.Graphics.DrawString(strText, HeaderFont, Brushes.Black, (PageRect.Width / 2) - (TextSize.Width / 2), nY);

						nY += TextSize.Height;
						}

					nY += HeaderFont.Height;

					fPageHeader = true;
					fHeader = false;
					}

				//----------------------------------------------------------------------------*
				// Draw the header if needed
				//----------------------------------------------------------------------------*

				if (!fHeader)
					{
					//----------------------------------------------------------------------------*
					// Loop through the headers
					//----------------------------------------------------------------------------*

					foreach (cPrintColumn PrintColumn in m_AmmoColumns)
						{
						e.Graphics.DrawString(PrintColumn.Name, HeaderFont, Brushes.Black, nX, nY);

						nX += (PrintColumn.Width + 10);
						}

					TextSize = e.Graphics.MeasureString(m_AmmoColumns[0].Name, HeaderFont);

					nY += TextSize.Height;

					e.Graphics.DrawLine(Pens.Black, PageRect.Left, nY, nX, nY);

					nX = PageRect.Left;

					fHeader = true;
					}

				//----------------------------------------------------------------------------*
				// Draw the Ammo info
				//----------------------------------------------------------------------------*

				// Manufacturer

				strText = Ammo.Manufacturer.ToString();

				nX = PageRect.Left;

				e.Graphics.DrawString(strText, DataFont, Brushes.Black, nX, nY);

				nX += (m_AmmoColumns[0].Width + 10);

				// Part Number

				strText = String.Format("{0}", Ammo.PartNumber);

				TextSize = e.Graphics.MeasureString(strText, DataFont);

				e.Graphics.DrawString(strText, DataFont, Brushes.Black, nX, nY);

				nX += (m_AmmoColumns[1].Width + 10);

				// Model/Type

				strText = String.Format("{0}", Ammo.Type);

				TextSize = e.Graphics.MeasureString(strText, DataFont);

				e.Graphics.DrawString(strText, DataFont, Brushes.Black, nX, nY);

				nX += (m_AmmoColumns[2].Width + 10);

				// Reload?

				if (Ammo.Reload)
					{
					strText = "Yes";

					TextSize = e.Graphics.MeasureString(strText, DataFont);

					e.Graphics.DrawString(strText, DataFont, Brushes.Black, nX + (m_AmmoColumns[3].Width / 2) - (TextSize.Width / 2), nY);
					}

				nX += (m_AmmoColumns[3].Width + 10);

				// Caliber

				strText = String.Format("{0:G0}", Ammo.Caliber);

				TextSize = e.Graphics.MeasureString(strText, DataFont);

				e.Graphics.DrawString(strText, DataFont, Brushes.Black, nX + (m_AmmoColumns[4].Width / 2) - (TextSize.Width / 2), nY);

				nX += (m_AmmoColumns[4].Width + 10);

				//----------------------------------------------------------------------------*
				// Min Stock Level
				//----------------------------------------------------------------------------*

				double dQuantity = Ammo.MinimumStockLevel;

				if (cPreferences.TrackInventory)
					{
					if (dQuantity != 0.0)
						strText = String.Format("{0:G0}", dQuantity);
					else
						strText = "-";
					}
				else
					strText = "-";

				TextSize = e.Graphics.MeasureString(strText, DataFont);

				e.Graphics.DrawString(strText, DataFont, Brushes.Black, nX + (m_AmmoColumns[5].Width / 2) - (TextSize.Width / 2), nY);

				nX += (m_AmmoColumns[5].Width + 20);

				//----------------------------------------------------------------------------*
				// Qty on Hand
				//----------------------------------------------------------------------------*

				if (cPreferences.TrackInventory)
					{
					dQuantity = m_DataFiles.SupplyQuantity(Ammo);

					if (dQuantity != 0.0)
						strText = String.Format("{0:G0}", dQuantity);
					else
						strText = "-";
					}
				else
					strText = "-";

				TextSize = e.Graphics.MeasureString(strText, DataFont);

				e.Graphics.DrawString(strText, DataFont, Brushes.Black, nX + (m_AmmoColumns[6].Width / 2) - (TextSize.Width / 2), nY);

				nX += (m_AmmoColumns[6].Width + 10);

				//----------------------------------------------------------------------------*
				// Estimated Cost
				//----------------------------------------------------------------------------*

				double dBoxSize = 50;

				if (Ammo.FirearmType == cFirearm.eFireArmType.Rifle)
					dBoxSize = 20;

				double dCostEach = m_DataFiles.SupplyCostEach(Ammo);

				if (dCostEach > 0.0)
					strText = String.Format("{0}{1:F2}/{2:F0}", m_DataFiles.Preferences.Currency, m_DataFiles.SupplyCostEach(Ammo) * dBoxSize, dBoxSize);
				else
					strText = "-";

				TextSize = e.Graphics.MeasureString(strText, DataFont);

				e.Graphics.DrawString(strText, DataFont, Brushes.Black, nX + m_AmmoColumns[7].Width - TextSize.Width, nY);

				nX = PageRect.Left;

				nY += TextSize.Height;
				}

			e.HasMorePages = false;

			ResetPrintedFlag();
			}

		//============================================================================*
		// OnResize()
		//============================================================================*

		protected override void OnResize(EventArgs e)
			{
			base.OnResize(e);

			if (!m_fInitialized)
				return;

			m_DataFiles.Preferences.AmmoListPreviewMaximized = WindowState == FormWindowState.Maximized;

			if (!m_DataFiles.Preferences.AmmoListPreviewMaximized)
				{
				m_DataFiles.Preferences.AmmoListPreviewLocation = Location;
				m_DataFiles.Preferences.AmmoListPreviewSize = ClientSize;
				}
			}

		//============================================================================*
		// ResetPrintedFlag()
		//============================================================================*

		private void ResetPrintedFlag()
			{
			//----------------------------------------------------------------------------*
			// Reset the Printed flags
			//----------------------------------------------------------------------------*

			foreach (cAmmo Ammo in m_DataFiles.AmmoList)
				Ammo.Printed = false;
			}
		}
	}
