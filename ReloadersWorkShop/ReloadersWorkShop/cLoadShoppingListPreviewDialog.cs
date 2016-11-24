//============================================================================*
// cShoppingListPreviewDialog.cs
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
	// cShoppingListPreviewDialog Class
	//============================================================================*

	public class cLoadShoppingListPreviewDialog : PrintPreviewDialog
		{
		//============================================================================*
		// Private Data Members
		//============================================================================*

		private bool m_fInitialized = false;

		private cDataFiles m_DataFiles = null;

		private cSupplyList m_SupplyList = null;

		private cPrintColumn[] m_BulletColumns = new cPrintColumn[]
			{
			new cPrintColumn("Bullet"),
			new cPrintColumn("Diameter"),
			new cPrintColumn("Weight"),
			new cPrintColumn("Qty on Hand"),
			new cPrintColumn("Est. Cost")
			};

		private cPrintColumn[] m_PowderColumns = new cPrintColumn[]
			{
			new cPrintColumn("Powder"),
			new cPrintColumn("Type"),
			new cPrintColumn("Shape"),
			new cPrintColumn("Qty on Hand"),
			new cPrintColumn("Est. Cost")
			};

		private cPrintColumn[] m_PrimerColumns = new cPrintColumn[]
			{
			new cPrintColumn("Primer"),
			new cPrintColumn("Size"),
			new cPrintColumn("Magnum"),
			new cPrintColumn("Qty on Hand"),
			new cPrintColumn("Est. Cost")
			};

		private cPrintColumn[] m_CaseColumns = new cPrintColumn[]
			{
			new cPrintColumn("Manufacturer"),
			new cPrintColumn("Match"),
			new cPrintColumn("Caliber"),
			new cPrintColumn("Qty on Hand"),
			new cPrintColumn("Est. Cost")
			};

		//============================================================================*
		// cShoppingListPreviewDialog() - Constructor
		//============================================================================*

		public cLoadShoppingListPreviewDialog(cDataFiles DataFiles)
			{
			m_DataFiles = DataFiles;

			if (m_DataFiles.Preferences.ShoppingListPreviewMaximized)
				{
				WindowState = FormWindowState.Maximized;
				}
			else
				{
				Location = m_DataFiles.Preferences.ShoppingListPreviewLocation;
				ClientSize = m_DataFiles.Preferences.ShoppingListPreviewSize;
				}

			Text = "Reloader's WorkShop Load Shopping List - Print Preview";

			PrintDocument ShoppingListDocument = new PrintDocument();
			ShoppingListDocument.PrintPage += OnPrintPage;

			Document = ShoppingListDocument;

			UseAntiAlias = true;

			//----------------------------------------------------------------------------*
			// Set can weight for powder list header
			//----------------------------------------------------------------------------*

			m_PowderColumns[3].Name += String.Format(" ({0}s)", cDataFiles.MetricString(cDataFiles.eDataType.CanWeight));

			//----------------------------------------------------------------------------*
			// Gather the list of supplies needed for the checked loads
			//----------------------------------------------------------------------------*

			m_SupplyList = new cSupplyList();

			foreach (cLoad Load in m_DataFiles.LoadList)
				{
				if (Load.Checked)
					{
					if (!m_SupplyList.Contains(Load.Bullet))
						m_SupplyList.AddSupply(Load.Bullet);

					if (!m_SupplyList.Contains(Load.Powder))
						m_SupplyList.AddSupply(Load.Powder);

					if (!m_SupplyList.Contains(Load.Primer))
						m_SupplyList.AddSupply(Load.Primer);

					if (!m_SupplyList.Contains(Load.Case))
						m_SupplyList.AddSupply(Load.Case);
					}
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

//			Font TitleFont = new Font("Trebuchet MS", 16, FontStyle.Bold);
			Font SupplyTypeFont = new Font("Trebuchet MS", 14, FontStyle.Bold);
			Font HeaderFont = new Font("Trebuchet MS", 10, FontStyle.Bold);
			Font DataFont = new Font("Trebuchet MS", 8, FontStyle.Regular);

			//----------------------------------------------------------------------------*
			// Calculate Column Header Name Widths
			//----------------------------------------------------------------------------*

			string strText;
			SizeF TextSize;

			foreach (cPrintColumn PrintColumn in m_BulletColumns)
				{
				TextSize = e.Graphics.MeasureString(PrintColumn.Name, HeaderFont);

				if (TextSize.Width > PrintColumn.Width)
					PrintColumn.Width = TextSize.Width;
				}

			foreach (cPrintColumn PrintColumn in m_PowderColumns)
				{
				TextSize = e.Graphics.MeasureString(PrintColumn.Name, HeaderFont);

				if (TextSize.Width > PrintColumn.Width)
					PrintColumn.Width = TextSize.Width;
				}

			foreach (cPrintColumn PrintColumn in m_CaseColumns)
				{
				TextSize = e.Graphics.MeasureString(PrintColumn.Name, HeaderFont);

				if (TextSize.Width > PrintColumn.Width)
					PrintColumn.Width = TextSize.Width;
				}

			foreach (cPrintColumn PrintColumn in m_PrimerColumns)
				{
				TextSize = e.Graphics.MeasureString(PrintColumn.Name, HeaderFont);

				if (TextSize.Width > PrintColumn.Width)
					PrintColumn.Width = TextSize.Width;
				}

			//----------------------------------------------------------------------------*
			// Calculate Header Widths for Supplies
			//----------------------------------------------------------------------------*

			foreach (cSupply Supply in m_SupplyList)
				{
				switch (Supply.SupplyType)
					{
					case cSupply.eSupplyTypes.Bullets:
						TextSize = e.Graphics.MeasureString((Supply as cBullet).ToString(), DataFont);

						if (TextSize.Width > m_BulletColumns[0].Width)
							m_BulletColumns[0].Width = TextSize.Width;

						break;

					case cSupply.eSupplyTypes.Powder:
						TextSize = e.Graphics.MeasureString((Supply as cPowder).ToString(), DataFont);

						if (TextSize.Width > m_PowderColumns[0].Width)
							m_PowderColumns[0].Width = TextSize.Width;

						break;

					case cSupply.eSupplyTypes.Primers:
						TextSize = e.Graphics.MeasureString((Supply as cPrimer).ToShortString(), DataFont);

						if (TextSize.Width > m_PrimerColumns[0].Width)
							m_PrimerColumns[0].Width = TextSize.Width;

						TextSize = e.Graphics.MeasureString((Supply as cPrimer).SizeString, DataFont);

						if (TextSize.Width > m_PrimerColumns[1].Width)
							m_PrimerColumns[1].Width = TextSize.Width;

						TextSize = e.Graphics.MeasureString("0.00/1000", DataFont);

						if (TextSize.Width > m_PrimerColumns[3].Width)
							m_PrimerColumns[3].Width = TextSize.Width;
						break;

					case cSupply.eSupplyTypes.Cases:
						TextSize = e.Graphics.MeasureString((Supply as cCase).Manufacturer.Name, DataFont);

						if (TextSize.Width > m_CaseColumns[0].Width)
							m_CaseColumns[0].Width = TextSize.Width;

						TextSize = e.Graphics.MeasureString((Supply as cCase).Caliber.ToString(), DataFont);

						if (TextSize.Width > m_CaseColumns[2].Width)
							m_CaseColumns[2].Width = TextSize.Width;

						break;
					}
				}

			//----------------------------------------------------------------------------*
			// Loop through the supply types
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

			for (int nSupplyType = 0; nSupplyType < (int)cSupply.eSupplyTypes.NumSupplyTypes; nSupplyType++)
				{
				cSupply.eSupplyTypes eSupplyType = (cSupply.eSupplyTypes)nSupplyType;

				//----------------------------------------------------------------------------*
				// Loop through the supplies in the list
				//----------------------------------------------------------------------------*

				bool fHeader = false;

				foreach (cSupply Supply in m_SupplyList)
					{
					if (nY > PageRect.Bottom)
						{
						e.HasMorePages = true;

						return;
						}

					//----------------------------------------------------------------------------*
					// If this supply is not the right type, or has already been printed, skip
					// to the next supply in the list
					//----------------------------------------------------------------------------*

					if (Supply.Printed || Supply.SupplyType != eSupplyType)
						continue;

					Supply.Printed = true;

					//----------------------------------------------------------------------------*
					// Draw the page header if needed
					//----------------------------------------------------------------------------*

					if (!fPageHeader)
						{
						//----------------------------------------------------------------------------*
						// Draw the Title
						//----------------------------------------------------------------------------*

						nY = cPrintObject.PrintReportTitle("Load Shopping List", PageRect, e.Graphics);
/*
						strText = "Reloader's WorkShop";
						TextSize = e.Graphics.MeasureString(strText, TitleFont);

						e.Graphics.DrawString(strText, TitleFont, Brushes.Black, (PageRect.Width / 2) - (TextSize.Width / 2), nY);

						nY += TextSize.Height;

						strText = "Shopping List";
						TextSize = e.Graphics.MeasureString(strText, TitleFont);

						e.Graphics.DrawString(strText, TitleFont, Brushes.Black, (PageRect.Width / 2) - (TextSize.Width / 2), nY);

						nY += TextSize.Height;
*/
						if (m_DataFiles.Preferences.TrackInventory)
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
					// Draw the supply type header if needed
					//----------------------------------------------------------------------------*

					if (!fHeader)
						{
						//----------------------------------------------------------------------------*
						// Draw the supply type
						//----------------------------------------------------------------------------*

						switch (eSupplyType)
							{
							//----------------------------------------------------------------------------*
							// Bullets
							//----------------------------------------------------------------------------*

							case cSupply.eSupplyTypes.Bullets:
								strText = "Bullets";

								TextSize = e.Graphics.MeasureString(strText, SupplyTypeFont);

								nY += (TextSize.Height * (float)0.5);

								e.Graphics.DrawString(strText, SupplyTypeFont, Brushes.Black, nX, nY);

								nY += (TextSize.Height * (float)1.5);
								nX = PageRect.Left;

								foreach (cPrintColumn PrintColumn in m_BulletColumns)
									{
									e.Graphics.DrawString(PrintColumn.Name, HeaderFont, Brushes.Black, nX, nY);

									nX += (PrintColumn.Width + 20);
									}

								TextSize = e.Graphics.MeasureString(m_BulletColumns[0].Name, HeaderFont);

								nY += TextSize.Height;

								e.Graphics.DrawLine(Pens.Black, PageRect.Left, nY, nX, nY);

								nX = PageRect.Left;

								break;

							//----------------------------------------------------------------------------*
							// Powder
							//----------------------------------------------------------------------------*

							case cSupply.eSupplyTypes.Powder:
								strText = "Powder";

								TextSize = e.Graphics.MeasureString(strText, SupplyTypeFont);

								nY += (TextSize.Height * (float)0.5);

								e.Graphics.DrawString(strText, SupplyTypeFont, Brushes.Black, nX, nY);

								nY += (TextSize.Height * (float)1.5);
								nX = PageRect.Left;

								foreach (cPrintColumn PrintColumn in m_PowderColumns)
									{
									e.Graphics.DrawString(PrintColumn.Name, HeaderFont, Brushes.Black, nX, nY);

									nX += (PrintColumn.Width + 20);
									}

								TextSize = e.Graphics.MeasureString(m_PowderColumns[0].Name, HeaderFont);

								nY += TextSize.Height;

								e.Graphics.DrawLine(Pens.Black, PageRect.Left, nY, nX, nY);

								nX = PageRect.Left;

								break;

							//----------------------------------------------------------------------------*
							// Primers
							//----------------------------------------------------------------------------*

							case cSupply.eSupplyTypes.Primers:
								strText = "Primers";

								TextSize = e.Graphics.MeasureString(strText, SupplyTypeFont);

								nY += (TextSize.Height * (float)0.5);

								e.Graphics.DrawString(strText, SupplyTypeFont, Brushes.Black, nX, nY);

								nY += (TextSize.Height * (float)1.5);
								nX = PageRect.Left;

								foreach (cPrintColumn PrintColumn in m_PrimerColumns)
									{
									e.Graphics.DrawString(PrintColumn.Name, HeaderFont, Brushes.Black, nX, nY);

									nX += (PrintColumn.Width + 20);
									}

								TextSize = e.Graphics.MeasureString(m_PrimerColumns[0].Name, HeaderFont);

								nY += TextSize.Height;

								e.Graphics.DrawLine(Pens.Black, PageRect.Left, nY, nX, nY);

								nX = PageRect.Left;


								break;

							//----------------------------------------------------------------------------*
							// Cases
							//----------------------------------------------------------------------------*

							case cSupply.eSupplyTypes.Cases:
								strText = "Cases";

								TextSize = e.Graphics.MeasureString(strText, SupplyTypeFont);

								nY += (TextSize.Height * (float)0.5);

								e.Graphics.DrawString(strText, SupplyTypeFont, Brushes.Black, nX, nY);

								nY += (TextSize.Height * (float)1.5);
								nX = PageRect.Left;

								foreach (cPrintColumn PrintColumn in m_CaseColumns)
									{
									e.Graphics.DrawString(PrintColumn.Name, HeaderFont, Brushes.Black, nX, nY);

									nX += (PrintColumn.Width + 20);
									}

								TextSize = e.Graphics.MeasureString(m_CaseColumns[0].Name, HeaderFont);

								nY += TextSize.Height;

								e.Graphics.DrawLine(Pens.Black, PageRect.Left, nY, nX, nY);

								nX = PageRect.Left;

								break;
							}

						fHeader = true;
						}

					//----------------------------------------------------------------------------*
					// Draw the supply info
					//----------------------------------------------------------------------------*

					switch (eSupplyType)
						{
						//----------------------------------------------------------------------------*
						// Bullets
						//----------------------------------------------------------------------------*

						case cSupply.eSupplyTypes.Bullets:
							cBullet Bullet = (cBullet)Supply;

							//----------------------------------------------------------------------------*
							// Bullet Name
							//----------------------------------------------------------------------------*

							strText = Bullet.ToString();

							nX = PageRect.Left;

							e.Graphics.DrawString(strText, DataFont, Brushes.Black, nX, nY);

							nX += (m_BulletColumns[0].Width + 20);

							//----------------------------------------------------------------------------*
							// Bullet Diameter
							//----------------------------------------------------------------------------*

							strText = String.Format("{0:F3}", Bullet.Diameter);

							TextSize = e.Graphics.MeasureString(strText, DataFont);

							e.Graphics.DrawString(strText, DataFont, Brushes.Black, nX + (m_BulletColumns[1].Width / 2) - (TextSize.Width / 2), nY);

							nX += (m_BulletColumns[1].Width + 20);

							//----------------------------------------------------------------------------*
							// Bullet Weight
							//----------------------------------------------------------------------------*

							strText = String.Format("{0:G0}", Bullet.Weight);

							TextSize = e.Graphics.MeasureString(strText, DataFont);

							e.Graphics.DrawString(strText, DataFont, Brushes.Black, nX + (m_BulletColumns[2].Width / 2) - (TextSize.Width / 2), nY);

							nX += (m_BulletColumns[2].Width + 20);

							//----------------------------------------------------------------------------*
							// Qty on Hand
							//----------------------------------------------------------------------------*

							double dQuantity = m_DataFiles.SupplyQuantity(Supply);

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

							e.Graphics.DrawString(strText, DataFont, Brushes.Black, nX + (m_BulletColumns[3].Width / 2) - (TextSize.Width / 2), nY);

							nX += (m_BulletColumns[3].Width + 20);

							//----------------------------------------------------------------------------*
							// Estimated Cost
							//----------------------------------------------------------------------------*

							if (dQuantity != 0.0)
								strText = String.Format("{0}{1:F2}/100", m_DataFiles.Preferences.Currency, m_DataFiles.SupplyCostEach(Supply) * 100.0);
							else
								strText = "-";

							TextSize = e.Graphics.MeasureString(strText, DataFont);

							e.Graphics.DrawString(strText, DataFont, Brushes.Black, nX + m_BulletColumns[4].Width - TextSize.Width, nY);

							nX = PageRect.Left;

							nY += TextSize.Height;

							break;

						//----------------------------------------------------------------------------*
						// Powder
						//----------------------------------------------------------------------------*

						case cSupply.eSupplyTypes.Powder:
							cPowder Powder = (cPowder)Supply;

							//----------------------------------------------------------------------------*
							// Powder Name
							//----------------------------------------------------------------------------*

							strText = Powder.ToString();

							nX = PageRect.Left;

							e.Graphics.DrawString(strText, DataFont, Brushes.Black, nX, nY);

							nX += (m_PowderColumns[0].Width + 20);

							//----------------------------------------------------------------------------*
							// Powder Type
							//----------------------------------------------------------------------------*

							strText = Powder.FirearmType.ToString();

							e.Graphics.DrawString(strText, DataFont, Brushes.Black, nX, nY);

							nX += (m_PowderColumns[1].Width + 20);

							//----------------------------------------------------------------------------*
							// Powder shape
							//----------------------------------------------------------------------------*

							strText = Powder.PowderType.ToString();

							e.Graphics.DrawString(strText, DataFont, Brushes.Black, nX, nY);

							nX += (m_PowderColumns[2].Width + 20);

							//----------------------------------------------------------------------------*
							// Qty on Hand
							//----------------------------------------------------------------------------*

							dQuantity = cDataFiles.StandardToMetric(m_DataFiles.SupplyQuantity(Powder) / 7000.0, cDataFiles.eDataType.CanWeight);

							if (m_DataFiles.Preferences.TrackInventory)
								{
								if (dQuantity != 0.0)
									strText = String.Format("{0:F3}", dQuantity);
								else
									strText = "-";
								}
							else
								strText = "-";

							TextSize = e.Graphics.MeasureString(strText, DataFont);

							e.Graphics.DrawString(strText, DataFont, Brushes.Black, nX + (m_PowderColumns[3].Width / 2) - (TextSize.Width / 2), nY);

							nX += (m_PowderColumns[3].Width + 20);

							//----------------------------------------------------------------------------*
							// Estimated Cost
							//----------------------------------------------------------------------------*

							if (dQuantity != 0.0)
								strText = String.Format("{0}{1:F2}/{2}", m_DataFiles.Preferences.Currency, cDataFiles.StandardToMetric(m_DataFiles.SupplyCostEach(Powder) * 7000.0, cDataFiles.eDataType.CanWeight), cDataFiles.MetricString(cDataFiles.eDataType.CanWeight));
							else
								strText = "-";

							TextSize = e.Graphics.MeasureString(strText, DataFont);

							e.Graphics.DrawString(strText, DataFont, Brushes.Black, nX + m_PowderColumns[4].Width - TextSize.Width, nY);

							nX = PageRect.Left;

							nY += TextSize.Height;

							break;

						//----------------------------------------------------------------------------*
						// Primers
						//----------------------------------------------------------------------------*

						case cSupply.eSupplyTypes.Primers:
							cPrimer Primer = (cPrimer)Supply;

							//----------------------------------------------------------------------------*
							// Primer
							//----------------------------------------------------------------------------*

							strText = Primer.ToShortString();

							nX = PageRect.Left;

							e.Graphics.DrawString(strText, DataFont, Brushes.Black, nX, nY);

							nX += (m_PrimerColumns[0].Width + 20);

							//----------------------------------------------------------------------------*
							// Size
							//----------------------------------------------------------------------------*

							strText = Primer.Size.ToString();

							TextSize = e.Graphics.MeasureString(strText, DataFont);

							e.Graphics.DrawString(strText, DataFont, Brushes.Black, nX, nY);

							nX += (m_PrimerColumns[1].Width + 20);

							//----------------------------------------------------------------------------*
							// Magnum
							//----------------------------------------------------------------------------*

							strText = Primer.Magnum ? "Yes" : "No";

							TextSize = e.Graphics.MeasureString(strText, DataFont);

							e.Graphics.DrawString(strText, DataFont, Brushes.Black, nX + (m_PrimerColumns[2].Width / 2) - (TextSize.Width / 2), nY);

							nX += (m_PrimerColumns[2].Width + 20);

							//----------------------------------------------------------------------------*
							// Qty on Hand
							//----------------------------------------------------------------------------*

							dQuantity = m_DataFiles.SupplyQuantity(Supply);

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

							e.Graphics.DrawString(strText, DataFont, Brushes.Black, nX + (m_PrimerColumns[3].Width / 2) - (TextSize.Width / 2), nY);

							nX += (m_PrimerColumns[3].Width + 20);

							//----------------------------------------------------------------------------*
							// Estimated Cost
							//----------------------------------------------------------------------------*

							if (dQuantity != 0.0)
								strText = String.Format("{0}{1:F2}/1000", m_DataFiles.Preferences.Currency, m_DataFiles.SupplyCostEach(Supply) * 1000);
							else
								strText = "-";

							TextSize = e.Graphics.MeasureString(strText, DataFont);

							e.Graphics.DrawString(strText, DataFont, Brushes.Black, nX + m_PrimerColumns[4].Width - TextSize.Width, nY);

							nX = PageRect.Left;

							nY += TextSize.Height;

							break;

						//----------------------------------------------------------------------------*
						// Cases
						//----------------------------------------------------------------------------*

						case cSupply.eSupplyTypes.Cases:
							cCase Case = (cCase)Supply;

							//----------------------------------------------------------------------------*
							// Manufacturer
							//----------------------------------------------------------------------------*

							strText = Case.Manufacturer.ToString();

							nX = PageRect.Left;

							e.Graphics.DrawString(strText, DataFont, Brushes.Black, nX, nY);

							nX += (m_CaseColumns[0].Width + 20);

							//----------------------------------------------------------------------------*
							// Match
							//----------------------------------------------------------------------------*

							strText = "Y";

							TextSize = e.Graphics.MeasureString(strText, DataFont);

							if (Case.Match)
								e.Graphics.DrawString(strText, DataFont, Brushes.Black, nX + (m_CaseColumns[1].Width / 2) - (TextSize.Width / 2), nY);

							nX += (m_CaseColumns[1].Width + 20);

							//----------------------------------------------------------------------------*
							// Caliber
							//----------------------------------------------------------------------------*

							strText = Case.Caliber.ToString();

							TextSize = e.Graphics.MeasureString(strText, DataFont);

							e.Graphics.DrawString(strText, DataFont, Brushes.Black, nX, nY);

							nX += (m_CaseColumns[2].Width + 20);

							//----------------------------------------------------------------------------*
							// Qty on Hand
							//----------------------------------------------------------------------------*

							dQuantity = m_DataFiles.SupplyQuantity(Supply);

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

							e.Graphics.DrawString(strText, DataFont, Brushes.Black, nX + (m_CaseColumns[3].Width / 2) - (TextSize.Width / 2), nY);

							nX += (m_CaseColumns[3].Width + 20);

							//----------------------------------------------------------------------------*
							// Estimated Cost
							//----------------------------------------------------------------------------*

							if (dQuantity != 0.0)
								strText = String.Format("{0}{1:F2}/100", m_DataFiles.Preferences.Currency, m_DataFiles.SupplyCostEach(Supply) * 100);
							else
								strText = "-";

							TextSize = e.Graphics.MeasureString(strText, DataFont);

							e.Graphics.DrawString(strText, DataFont, Brushes.Black, nX + m_CaseColumns[4].Width - TextSize.Width, nY);

							nX = PageRect.Left;

							nY += TextSize.Height;

							break;
						}
					}
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

			m_DataFiles.Preferences.ShoppingListPreviewMaximized = WindowState == FormWindowState.Maximized;

			if (!m_DataFiles.Preferences.ShoppingListPreviewMaximized)
				{
				m_DataFiles.Preferences.ShoppingListPreviewLocation = Location;
				m_DataFiles.Preferences.ShoppingListPreviewSize = ClientSize;
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

			foreach (cBullet Bullet in m_DataFiles.BulletList)
				Bullet.Printed = false;

			foreach (cCase Case in m_DataFiles.CaseList)
				Case.Printed = false;

			foreach (cPowder Powder in m_DataFiles.PowderList)
				Powder.Printed = false;

			foreach (cPrimer Primer in m_DataFiles.PrimerList)
				Primer.Printed = false;
			}
		}
	}
