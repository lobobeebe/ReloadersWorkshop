//============================================================================*
// cFirearmListPreviewDialog.cs
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

//============================================================================*
// Namespace
//============================================================================*

namespace ReloadersWorkShop
	{
	//============================================================================*
	// cFirearmListPreviewDialog Class
	//============================================================================*

	public class cFirearmListPreviewDialog : PrintPreviewDialog
		{
		//============================================================================*
		// Private Data Members
		//============================================================================*

		private bool m_fInitialized = false;

		private cDataFiles m_DataFiles = null;

		private cFirearmList m_FirearmList = null;

		private cPrintColumn[] m_Columns = new cPrintColumn[]
			{
			new cPrintColumn("Firearm"),
			new cPrintColumn("Caliber"),
			new cPrintColumn("Serial #"),
			new cPrintColumn("Purchase Date"),
			new cPrintColumn("Purchase Price")
			};

		//============================================================================*
		// cFirearmListPreviewDialog() - Constructor
		//============================================================================*

		public cFirearmListPreviewDialog(cDataFiles DataFiles)
			{
			m_DataFiles = DataFiles;

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

			Text = "Reloader's WorkShop Firearm List - Print Preview";

			PrintDocument FirearmListDocument = new PrintDocument();
			FirearmListDocument.PrintPage += OnPrintPage;

			Document = FirearmListDocument;

			UseAntiAlias = true;

			//----------------------------------------------------------------------------*
			// Gather the list of firearms
			//----------------------------------------------------------------------------*

			m_FirearmList = new cFirearmList();

			foreach (cFirearm Firearm in m_DataFiles.FirearmList)
				{
				if (m_DataFiles.Preferences.FirearmPrintAll || Firearm.Checked)
					m_FirearmList.Add(Firearm);
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

			m_DataFiles.Preferences.FirearmListPreviewLocation = Location;
			}

		//============================================================================*
		// OnPrintPage()
		//============================================================================*

		private void OnPrintPage(object sender, PrintPageEventArgs e)
			{
			//----------------------------------------------------------------------------*
			// Create the fonts
			//----------------------------------------------------------------------------*

			Font FirearmTypeFont = new Font("Trebuchet MS", 14, FontStyle.Bold);
			Font HeaderFont = new Font("Trebuchet MS", 10, FontStyle.Bold);
			Font DataFont = new Font("Trebuchet MS", 9, FontStyle.Regular);
			Font SpecsFont = new Font("Trebuchet MS", 8, FontStyle.Regular);

			//----------------------------------------------------------------------------*
			// Calculate Column Header Name Widths
			//----------------------------------------------------------------------------*

			string strText;
			SizeF TextSize;

			foreach (cPrintColumn PrintColumn in m_Columns)
				{
				TextSize = e.Graphics.MeasureString(PrintColumn.Name, HeaderFont);

				if (TextSize.Width > PrintColumn.Width)
					PrintColumn.Width = TextSize.Width;
				}

			//----------------------------------------------------------------------------*
			// Calculate Header Widths
			//----------------------------------------------------------------------------*

			foreach (cFirearm Firearm in m_FirearmList)
				{
				// Name

				TextSize = e.Graphics.MeasureString(Firearm.ToShortString(), DataFont);

				if (TextSize.Width > m_Columns[0].Width)
					m_Columns[0].Width = TextSize.Width;

				// Caliber

				cCaliber.CurrentFirearmType = Firearm.PrimaryCaliber.FirearmType;

				TextSize = e.Graphics.MeasureString(Firearm.PrimaryCaliber.ToString(), DataFont);

				if (TextSize.Width > m_Columns[1].Width)
					m_Columns[1].Width = TextSize.Width;

				// Serial #

				TextSize = e.Graphics.MeasureString(Firearm.SerialNumber, DataFont);

				if (TextSize.Width > m_Columns[2].Width)
					m_Columns[2].Width = TextSize.Width;

				// Purchase Date

				TextSize = e.Graphics.MeasureString(Firearm.PurchaseDate.ToShortDateString(), DataFont);

				if (TextSize.Width > m_Columns[3].Width)
					m_Columns[3].Width = TextSize.Width;

				// Purchase Price

				TextSize = e.Graphics.MeasureString(String.Format("{0:F2}", Firearm.PurchasePrice), DataFont);

				if (TextSize.Width > m_Columns[4].Width)
					m_Columns[4].Width = TextSize.Width;
				}

			//----------------------------------------------------------------------------*
			// Set Rectangle Size Info
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
			bool fTypeHeader = false;
			bool fHeader = false;

			//----------------------------------------------------------------------------*
			// Loop through the firearm types
			//----------------------------------------------------------------------------*

			for (int nFirearmType = 0; nFirearmType < 3; nFirearmType++)
				{
				fTypeHeader = false;

				//----------------------------------------------------------------------------*
				// Loop through the firearms
				//----------------------------------------------------------------------------*

				foreach (cFirearm Firearm in m_FirearmList)
					{
					if (Firearm.Printed || Firearm.FirearmType != (cFirearm.eFireArmType)nFirearmType)
						continue;

					//----------------------------------------------------------------------------*
					// Make sure we have room on the page to print this firearm
					//----------------------------------------------------------------------------*

					int nLines = DataFont.Height;

					if (m_DataFiles.Preferences.FirearmPrintSpecs)
						nLines += (4 * DataFont.Height);

					if (nY + nLines > PageRect.Bottom)
						{
						e.HasMorePages = true;

						return;
						}

					//----------------------------------------------------------------------------*
					// Draw the page header if needed
					//----------------------------------------------------------------------------*

					if (!fPageHeader)
						{
						//----------------------------------------------------------------------------*
						// Draw the Title
						//----------------------------------------------------------------------------*

						nY = cPrintObject.PrintReportTitle("Firearm List", PageRect, e.Graphics);

						fPageHeader = true;
						fTypeHeader = false;
						}

					//----------------------------------------------------------------------------*
					// Draw the type header if needed
					//----------------------------------------------------------------------------*

					if (!fTypeHeader)
						{
						nY += FirearmTypeFont.Height;

						strText = "Unknown!!!";

						switch ((cFirearm.eFireArmType)nFirearmType)
							{
							case cFirearm.eFireArmType.Handgun:
								strText = "Handguns";
								cCaliber.CurrentFirearmType = cFirearm.eFireArmType.Handgun;
								break;

							case cFirearm.eFireArmType.Rifle:
								strText = "Rifles";
								cCaliber.CurrentFirearmType = cFirearm.eFireArmType.Rifle;
								break;

							case cFirearm.eFireArmType.Shotgun:
								strText = "Shotguns";
								cCaliber.CurrentFirearmType = cFirearm.eFireArmType.Shotgun;
								break;
							}

						TextSize = e.Graphics.MeasureString(strText, FirearmTypeFont);

						e.Graphics.DrawString(strText, FirearmTypeFont, Brushes.Black, PageRect.Left, nY);

						nY += TextSize.Height;

						fTypeHeader = true;
						fHeader = false;
						}

					//----------------------------------------------------------------------------*
					// Draw the header if needed
					//----------------------------------------------------------------------------*

					if (!fHeader)
						{
						nX = PageRect.Left;

						foreach (cPrintColumn PrintColumn in m_Columns)
							{
							e.Graphics.DrawString(PrintColumn.Name, HeaderFont, Brushes.Black, nX, nY);

							nX += (PrintColumn.Width + 20);
							}

						nY += HeaderFont.Height;

						e.Graphics.DrawLine(Pens.Black, PageRect.Left, nY, nX - 20, nY);

						nX = PageRect.Left;
						nY += 4;

						fHeader = true;
						}

					//----------------------------------------------------------------------------*
					// Draw the firearm info
					//----------------------------------------------------------------------------*

					// Name

					strText = Firearm.ToShortString();

					nX = PageRect.Left;

					e.Graphics.DrawString(strText, DataFont, Brushes.Black, nX, nY);

					nX += (m_Columns[0].Width + 20);

					// Caliber

					strText = Firearm.PrimaryCaliber.ToString();

					e.Graphics.DrawString(strText, DataFont, Brushes.Black, nX, nY);

					nX += (m_Columns[1].Width + 20);

					// Serial #

					strText = Firearm.SerialNumber;

					e.Graphics.DrawString(strText, DataFont, Brushes.Black, nX, nY);

					nX += (m_Columns[2].Width + 20);

					// Purchase Date

					if (Firearm.PurchaseDate.Year < 1900)
						strText = "Unknown";
					else
						strText = Firearm.PurchaseDate.ToShortDateString();

					TextSize = e.Graphics.MeasureString(strText, DataFont);

					e.Graphics.DrawString(strText, DataFont, Brushes.Black, nX + (m_Columns[3].Width / 2) - (TextSize.Width / 2), nY);

					nX += (m_Columns[3].Width + 20);

					// Purchase Price

					strText = String.Format("{0}{1:F2}", m_DataFiles.Preferences.Currency, Firearm.PurchasePrice);

					TextSize = e.Graphics.MeasureString(strText, DataFont);

					e.Graphics.DrawString(strText, DataFont, Brushes.Black, nX + m_Columns[4].Width - TextSize.Width, nY);

					nX += (m_Columns[4].Width + 20);

					nY += DataFont.Height;

					//----------------------------------------------------------------------------*
					// Draw the specs if needed
					//----------------------------------------------------------------------------*

					if (m_DataFiles.Preferences.FirearmPrintSpecs)
						{
						int nData1X = (int)e.Graphics.MeasureString("Barrel Length: ", SpecsFont).Width;
						int nData2X = (int)e.Graphics.MeasureString("Zero Range: ", SpecsFont).Width;
						int nData3X = (int)e.Graphics.MeasureString("Turret Click: ", SpecsFont).Width;

						int nColumn1 = PageRect.Left + (int)(m_Columns[0].Width / 2);
						int nColumn2 = nColumn1 + (int)e.Graphics.MeasureString("Barrel Length: 00.00", SpecsFont).Width + 20;
						int nColumn3 = nColumn2 + (int)e.Graphics.MeasureString("Zero Range: ", SpecsFont).Width + (int)e.Graphics.MeasureString("1:00.00", SpecsFont).Width + 20;

						nY += (SpecsFont.Height / 2);

						// Barrel Length

						nX = nColumn1;

						strText = String.Format("Barrel Length: {0:F2}", Firearm.BarrelLength);

						e.Graphics.DrawString(strText, SpecsFont, Brushes.Black, nX, nY);

						// Twist

						if (Firearm.Twist > 0.0)
							{
							strText = "Twist: ";

							nX = nColumn2 + nData2X - e.Graphics.MeasureString(strText, SpecsFont).Width;

							e.Graphics.DrawString("Twist: ", SpecsFont, Brushes.Black, nX, nY);

							nX += e.Graphics.MeasureString(strText, SpecsFont).Width;

							strText = String.Format("1:{0:F2}", Firearm.Twist);

							e.Graphics.DrawString(strText, SpecsFont, Brushes.Black, nX, nY);
							}

						nY += SpecsFont.Height;

						//----------------------------------------------------------------------------*
						// Draw zero range and scope click MOA
						//----------------------------------------------------------------------------*

						// Sight Height

						strText = "Sight Height: ";

						nX = nColumn1 + nData1X - e.Graphics.MeasureString(strText, SpecsFont).Width;

						e.Graphics.DrawString(strText, SpecsFont, Brushes.Black, nX, nY);

						nX += e.Graphics.MeasureString(strText, SpecsFont).Width;

						strText = String.Format("{0:F1}", Firearm.SightHeight);

						e.Graphics.DrawString(strText, SpecsFont, Brushes.Black, nX, nY);

						// Zero Range

						if (Firearm.ZeroRange != 0)
							{
							strText = "Zero Range: ";

							nX = nColumn2 + nData2X - e.Graphics.MeasureString(strText, SpecsFont).Width;

							e.Graphics.DrawString(strText, SpecsFont, Brushes.Black, nX, nY);

							nX += e.Graphics.MeasureString(strText, SpecsFont).Width;

							strText = String.Format("{0:N0}", Firearm.ZeroRange);

							e.Graphics.DrawString(strText, SpecsFont, Brushes.Black, nX, nY);
							}

						// Scope Click MOA

						if (Firearm.Scoped)
							{
							strText = "Turret Click: ";

							nX = nColumn3 + nData3X - e.Graphics.MeasureString(strText, SpecsFont).Width;

							e.Graphics.DrawString(strText, SpecsFont, Brushes.Black, nX, nY);

							nX += e.Graphics.MeasureString(strText, SpecsFont).Width;

							strText = String.Format("{0:F3} {1}", Firearm.ScopeClick, Firearm.TurretTypeString);

							e.Graphics.DrawString(strText, SpecsFont, Brushes.Black, nX, nY);
							}

						nY += SpecsFont.Height;

						//----------------------------------------------------------------------------*
						// Draw headspace and neck size for rifles
						//----------------------------------------------------------------------------*

						if (Firearm.FirearmType == cFirearm.eFireArmType.Rifle)
							{
							// Headspace

							if (Firearm.HeadSpace != 0.0)
								{
								strText = "Headspace: ";

								nX = nColumn1 + nData1X - e.Graphics.MeasureString(strText, SpecsFont).Width;

								e.Graphics.DrawString(strText, SpecsFont, Brushes.Black, nX, nY);

								nX += e.Graphics.MeasureString(strText, SpecsFont).Width;

								strText = String.Format("{0:F3}", Firearm.HeadSpace);

								e.Graphics.DrawString(strText, SpecsFont, Brushes.Black, nX, nY);
								}

							// Neck

							if (Firearm.Neck != 0.0)
								{
								strText = "Neck Size: ";

								nX = nColumn2 + nData2X - e.Graphics.MeasureString(strText, SpecsFont).Width;

								e.Graphics.DrawString(strText, SpecsFont, Brushes.Black, nX, nY);

								nX += e.Graphics.MeasureString(strText, SpecsFont).Width;

								strText = String.Format("{0:F3}", Firearm.Neck);

								e.Graphics.DrawString(strText, SpecsFont, Brushes.Black, nX, nY);
								}

							if (Firearm.HeadSpace != 0.0 || Firearm.Neck != 0.0)
								nY += SpecsFont.Height;
							}

						nY += (SpecsFont.Height / 2);

						e.Graphics.DrawLine(Pens.Black, PageRect.Left, nY, PageRect.Left + nColumn3 + nData3X, nY);

						nY += (SpecsFont.Height / 2);
						}

					Firearm.Printed = true;
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

		private void ResetPrintedFlag()
			{
			foreach (cFirearm Firearm in m_DataFiles.FirearmList)
				Firearm.Printed = false;
			}
		}
	}
