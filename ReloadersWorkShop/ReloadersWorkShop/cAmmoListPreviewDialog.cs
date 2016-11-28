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

		private cAmmoList m_AmmoList = new cAmmoList();

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

		public cAmmoListPreviewDialog(cDataFiles DataFiles, ListView AmmoListView)
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
			m_AmmoColumns[7].Name += String.Format(" ({0})", m_DataFiles.Preferences.Currency);

			if (!m_DataFiles.Preferences.TrackInventory)
				m_AmmoColumns[6].Name = "Box of";

			//----------------------------------------------------------------------------*
			// Gather the list of ammo, reset flags, and exit
			//----------------------------------------------------------------------------*

			foreach (ListViewItem Item in AmmoListView.Items)
				{
				cAmmo Ammo = (cAmmo) Item.Tag;

				if (Ammo != null)
					m_AmmoList.Add(Ammo);
				}

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

			Font HeaderFont = new Font("Trebuchet MS", 8, FontStyle.Bold);
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
				cCaliber.CurrentFirearmType = Ammo.FirearmType;

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

				if (TextSize.Width > m_AmmoColumns[4].Width)
					m_AmmoColumns[4].Width = TextSize.Width;

				//----------------------------------------------------------------------------*
				// Cost
				//----------------------------------------------------------------------------*

				TextSize = e.Graphics.MeasureString("99999.99", DataFont);

				if (TextSize.Width > m_AmmoColumns[7].Width)
					m_AmmoColumns[7].Width = TextSize.Width;
				}

			float nLineWidth = 0;

			foreach (cPrintColumn PrintColumn in m_AmmoColumns)
				nLineWidth += PrintColumn.Width;

			nLineWidth += ((m_AmmoColumns.Length - 1) * 10.0f);

			float nLeftMargin = (e.PageBounds.Width / 2) - (nLineWidth / 2.0f);

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
			float nX = nLeftMargin;

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

				cCaliber.CurrentFirearmType = Ammo.FirearmType;

				//----------------------------------------------------------------------------*
				// Draw the page header if needed
				//----------------------------------------------------------------------------*

				if (!fPageHeader)
					{
					//----------------------------------------------------------------------------*
					// Draw the Title
					//----------------------------------------------------------------------------*

					nY = cPrintObject.PrintReportTitle(m_DataFiles.Preferences.AmmoMinStockFilter ? "Ammunition Shopping List" : "Ammunition List", PageRect, e.Graphics);

					if (m_DataFiles.Preferences.TrackInventory)
						{
						strText = m_DataFiles.CostText;

						TextSize = e.Graphics.MeasureString(strText, HeaderFont);

						e.Graphics.DrawString(strText, HeaderFont, Brushes.Black, e.MarginBounds.Left + (e.MarginBounds.Width / 2) - (TextSize.Width / 2), nY);

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

					nX = nLeftMargin;

					foreach (cPrintColumn PrintColumn in m_AmmoColumns)
						{
						if (PrintColumn.Name.Substring(0, 4) == "Cost")
							{
							TextSize = e.Graphics.MeasureString(PrintColumn.Name, HeaderFont);

							e.Graphics.DrawString(PrintColumn.Name, HeaderFont, Brushes.Black, nX + PrintColumn.Width - TextSize.Width, nY);
							}
						else
							e.Graphics.DrawString(PrintColumn.Name, HeaderFont, Brushes.Black, nX, nY);

						nX += (PrintColumn.Width + 10);
						}

					nX -= 10;

					TextSize = e.Graphics.MeasureString(m_AmmoColumns[0].Name, HeaderFont);

					nY += TextSize.Height;

					e.Graphics.DrawLine(Pens.Black, nLeftMargin, nY, nX, nY);

					nX = nLeftMargin;

					fHeader = true;
					}

				//----------------------------------------------------------------------------*
				// Draw the Ammo info
				//----------------------------------------------------------------------------*

				// Manufacturer

				strText = Ammo.Manufacturer.ToString();

				nX = nLeftMargin;

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

				e.Graphics.DrawString(strText, DataFont, Brushes.Black, nX, nY);

				nX += (m_AmmoColumns[4].Width + 10);

				//----------------------------------------------------------------------------*
				// Min Stock Level
				//----------------------------------------------------------------------------*

				double dQuantity = Ammo.MinimumStockLevel;

				if (m_DataFiles.Preferences.TrackInventory)
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

				if (m_DataFiles.Preferences.TrackInventory)
					{
					dQuantity = m_DataFiles.SupplyQuantity(Ammo);

					if (dQuantity != 0.0)
						strText = String.Format("{0:N0}", dQuantity);
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
					strText = String.Format("{0:F2}/{1:F0}", m_DataFiles.SupplyCostEach(Ammo) * dBoxSize, dBoxSize);
				else
					strText = "-";

				TextSize = e.Graphics.MeasureString(strText, DataFont);

				e.Graphics.DrawString(strText, DataFont, Brushes.Black, nX + m_AmmoColumns[7].Width - TextSize.Width - 10, nY);

				nX = nLeftMargin;

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
