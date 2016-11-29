//============================================================================*
// cFirearmDetailPreviewDialog.cs
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
	// cFirearmDetailPreviewDialog Class
	//============================================================================*

	public class cFirearmDetailPreviewDialog : PrintPreviewDialog
		{
		//============================================================================*
		// Private Data Members
		//============================================================================*

		private bool m_fInitialized = false;

		private cDataFiles m_DataFiles = null;

		private cFirearmList m_FirearmList = null;

		//============================================================================*
		// cFirearmDetailPreviewDialog() - Constructor
		//============================================================================*

		public cFirearmDetailPreviewDialog(cDataFiles DataFiles)
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

			Text = "Reloader's WorkShop Firearm Detail Report - Print Preview";

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

			Font FirearmNameFont = new Font("Trebuchet MS", 14, FontStyle.Bold);
			Font SerialNumberFont = new Font("Trebuchet MS", 10, FontStyle.Regular);
			Font HeaderFont = new Font("Trebuchet MS", 10, FontStyle.Bold);
			Font DataFont = new Font("Trebuchet MS", 9, FontStyle.Regular);
			Font SpecsFont = new Font("Trebuchet MS", 8, FontStyle.Regular);

			//----------------------------------------------------------------------------*
			// Set Rectangle Size Info
			//----------------------------------------------------------------------------*

			Rectangle PageRect = e.PageBounds;

			Rectangle PageAreaRect = e.PageBounds;
			PageAreaRect.Width = e.MarginBounds.Width;
			PageAreaRect.Height = e.MarginBounds.Height;

			int nLeftMargin = e.MarginBounds.Left;

			int nXDPI = (int) ((double) PageRect.Width / 8.5);
			int nYDPI = (int) ((double) PageRect.Height / 11);

			PageRect.X += (int) ((double) nXDPI * 0.5);
			PageRect.Width -= ((int) ((double) nXDPI * 0.5) * 2);

			PageRect.Y += (int) ((double) nYDPI * 0.5);
			PageRect.Height -= ((int) ((double) nYDPI * 0.5) * 2);

			float nY = PageRect.Top;
			float nX = PageRect.Left;

			//----------------------------------------------------------------------------*
			// Loop through the firearms
			//----------------------------------------------------------------------------*

			foreach (cFirearm Firearm in m_FirearmList)
				{
				if (Firearm.Printed)
					{
					bool fAllPrinted = true;

					if (cFirearmAccessoryListPreviewDialog.GearList != null)
						{
						foreach (cGear Gear in cFirearmAccessoryListPreviewDialog.GearList)
							{
							if (!Gear.Printed)
								{
								fAllPrinted = false;

								break;
								}
							}
						}

					if (fAllPrinted)
						continue;
					}

				cCaliber.CurrentFirearmType = Firearm.FirearmType;

				//----------------------------------------------------------------------------*
				// Draw the page header
				//----------------------------------------------------------------------------*

				nY = cPrintObject.PrintReportTitle("Firearm Detail Report", e, PageRect);

				string strText = "";
				SizeF TextSize;

				if (Firearm.Printed)
					{
					strText = "(Continued)";

					TextSize = e.Graphics.MeasureString(strText, FirearmNameFont);

					e.Graphics.DrawString(strText, FirearmNameFont, Brushes.Black, nLeftMargin + (PageAreaRect.Width / 2) - (TextSize.Width / 2), nY);

					nY += TextSize.Height;
					}

				//----------------------------------------------------------------------------*
				// Firearm Name
				//----------------------------------------------------------------------------*

				strText = Firearm.ToShortString();

				TextSize = e.Graphics.MeasureString(strText, FirearmNameFont);

				nY += TextSize.Height;

				e.Graphics.DrawString(strText, FirearmNameFont, Brushes.Black, nLeftMargin + (PageAreaRect.Width / 2) - (TextSize.Width / 2), nY);

				nY += TextSize.Height;

				//----------------------------------------------------------------------------*
				// Serial Number
				//----------------------------------------------------------------------------*

				strText = "Serial Number: ";
				strText += Firearm.SerialNumber;

				TextSize = e.Graphics.MeasureString(strText, SerialNumberFont);

				e.Graphics.DrawString(strText, SerialNumberFont, Brushes.Black, nLeftMargin + (PageAreaRect.Width / 2) - (TextSize.Width / 2), nY);

				nY += (TextSize.Height * 2);

				if (!Firearm.Printed)
					{
					//----------------------------------------------------------------------------*
					// Firearm Image
					//----------------------------------------------------------------------------*

					Bitmap FirearmImage = null;

					try
						{
						if (Firearm.ImageFile != null && Firearm.ImageFile.Length > 0)
							FirearmImage = new Bitmap(Firearm.ImageFile);
						else
							FirearmImage = Properties.Resources.No_Photo_Available;
						}
					catch
						{
						FirearmImage = Properties.Resources.No_Photo_Available;
						}


					if (FirearmImage != null)
						{
						double dWidth = FirearmImage.Width;
						double dHeight = FirearmImage.Height;

						if (FirearmImage.Width > PageRect.Width)
							{
							dHeight = dHeight / dWidth;
							dWidth = PageRect.Width;
							dHeight *= dWidth;
							}

						e.Graphics.DrawImage(FirearmImage, new Rectangle((int) (nX + (PageRect.Width / 2.0) - (dWidth / 2.0)), (int) nY, (int) dWidth, (int) dHeight));

						nY += (int) dHeight + TextSize.Height;
						}

					//----------------------------------------------------------------------------*
					// Purchase Info
					//----------------------------------------------------------------------------*

					if (Firearm.Source != null && Firearm.Source.Length > 0)
						{
						strText = "Acquired from ";
						strText += Firearm.Source;
						strText += " on ";
						strText += Firearm.PurchaseDate.ToLongDateString();

						if (Firearm.PurchasePrice > 0.0)
							{
							strText += " for ";
							strText += String.Format("{0}{1:F2}.", m_DataFiles.Preferences.Currency, Firearm.PurchasePrice);
							}
						else
							strText += " at no cost.";

						TextSize = e.Graphics.MeasureString(strText, DataFont);

						e.Graphics.DrawString(strText, DataFont, Brushes.Black, nLeftMargin + (PageAreaRect.Width / 2) - (TextSize.Width / 2), nY);

						nY += (TextSize.Height * 2);
						}

					//----------------------------------------------------------------------------*
					// Description
					//----------------------------------------------------------------------------*

					strText = "";

					switch (Firearm.Type)
						{
						case "Rifle":
							strText = String.Format("{0} {1} Chambered for {2}", Firearm.Action, Firearm.Type, Firearm.PrimaryCaliber.ToString());

							break;

						case "Shotgun":
							strText = String.Format("{0} {1} {2}", Firearm.PrimaryCaliber.ToString(), Firearm.Action, Firearm.Type);

							break;

						case "Revolver":
							strText = String.Format("{1} {2} in {0} with a {3:G0} Round Cylinder.", Firearm.PrimaryCaliber.ToString(), Firearm.Action, Firearm.Type, Firearm.Capacity);

							break;

						case "Derringer":
							strText = String.Format("{1} {2} in {0} with a {3:G0} Round Capacity.", Firearm.PrimaryCaliber.ToString(), Firearm.Action, Firearm.Type, Firearm.Capacity);

							break;

						case "Pistol":
							if (Firearm.Hammer == "Striker Fired")
								strText = String.Format("{0} {1} {2} in {3}", Firearm.Hammer, Firearm.Action, Firearm.Type, Firearm.PrimaryCaliber.ToString());
							else
								strText = String.Format("{1} {2} in {0}", Firearm.PrimaryCaliber.ToString(), Firearm.Action, Firearm.Type);

							if (Firearm.Magazine != null && Firearm.Magazine.Length > 0)
								strText += String.Format(" with a{0} {1:G0} Round {2} Magazine.", Firearm.Capacity == 8 || Firearm.Capacity == 18 ? "n" : "", Firearm.Capacity, Firearm.Magazine);
							break;
						}

					if (strText.Length > 0)
						{
						TextSize = e.Graphics.MeasureString(strText, DataFont);

						e.Graphics.DrawString(strText, DataFont, Brushes.Black, nLeftMargin + (PageAreaRect.Width / 2) - (TextSize.Width / 2), nY);

						nY += TextSize.Height;
						}

					//----------------------------------------------------------------------------*
					// Finish
					//----------------------------------------------------------------------------*

					strText = "";

					if (Firearm.ReceiverFinish != null && Firearm.ReceiverFinish.Length > 0)
						{
						strText = Firearm.ReceiverFinish;

						switch (Firearm.Type)
							{
							case "Rifle":
							case "Shotgun":
								strText += " Receiver";
								break;

							default:
								strText += " Frame";
								break;
							}
						}

					if (Firearm.BarrelFinish != null && Firearm.BarrelFinish.Length > 0)
						{
						if (strText.Length > 0)
							{
							if (Firearm.ReceiverFinish == Firearm.BarrelFinish)
								strText += " and";
							else
								{
								strText += " with a ";
								strText += Firearm.BarrelFinish;
								}
							}

						else
							strText = Firearm.BarrelFinish;

						switch (Firearm.Type)
							{
							case "Pistol":
								strText += " Slide";
								break;

							case "Revolver":
								strText += " Cylinder";
								break;

							default:
								strText += " Barrel";
								break;
							}
						}

					TextSize = e.Graphics.MeasureString(strText, DataFont);

					e.Graphics.DrawString(strText, DataFont, Brushes.Black, nLeftMargin + (PageAreaRect.Width / 2) - (TextSize.Width / 2), nY);

					nY += (TextSize.Height * 2);

					//----------------------------------------------------------------------------*
					// Magazine
					//----------------------------------------------------------------------------*

					strText = "";

					if (Firearm.Magazine != "None")
						{
						if (Firearm.Magazine == "Cylinder")
							strText = String.Format("{0:G0} Round Cylinder", Firearm.Capacity);
						else
							strText = String.Format("{0:G0} Round {1} Magazine", Firearm.Capacity, Firearm.Magazine);

						TextSize = e.Graphics.MeasureString(strText, DataFont);

						e.Graphics.DrawString(strText, DataFont, Brushes.Black, nLeftMargin + (PageAreaRect.Width / 2) - (TextSize.Width / 2), nY);

						nY += (TextSize.Height * 2);
						}

					//----------------------------------------------------------------------------*
					// Notes
					//----------------------------------------------------------------------------*

					if (Firearm.Notes != null && Firearm.Notes.Length > 0)
						{
						strText = "Notes:";

						TextSize = e.Graphics.MeasureString(strText, HeaderFont);

						e.Graphics.DrawString(strText, HeaderFont, Brushes.Black, nX, nY);

						float nOriginalX = nX;

						nX += TextSize.Width / 2;

						nY += (TextSize.Height * (float) 1.5);

						int nPrevIndex = 0;
						string strNotes = Firearm.Notes;
						strText = "";
						TextSize = e.Graphics.MeasureString(strNotes, DataFont);
						int nCharCount = 0;

						while (true)
							{
							bool fLinePrinted = false;

							for (int nIndex = 0; nIndex < strNotes.Length; nIndex++)
								{
								nCharCount++;

								if (strNotes[nIndex] == '\n')
									continue;

								if (strNotes[nIndex] == '\r')
									{
									e.Graphics.DrawString(strText, DataFont, Brushes.Black, nX, nY);

									strText = "";
									nPrevIndex = 0;
									nY += TextSize.Height;

									nCharCount++;

									strNotes = Firearm.Notes.Substring(nCharCount);

									fLinePrinted = true;

									break;
									}

								strText = strNotes.Substring(0, nIndex + 1);

								if (strNotes[nIndex] == ' ')
									{
									TextSize = e.Graphics.MeasureString(strText, DataFont);

									if (TextSize.Width > PageRect.Width - nX)
										{
										strText = strNotes.Substring(0, nPrevIndex);

										e.Graphics.DrawString(strText, DataFont, Brushes.Black, nX, nY);

										strText = "";
										nPrevIndex = 0;
										nY += TextSize.Height;

										strNotes = Firearm.Notes.Substring(nCharCount);

										fLinePrinted = true;

										break;
										}

									nPrevIndex = nIndex;
									}
								}

							if (!fLinePrinted)
								break;
							}

						if (strText.Length > 0)
							{
							e.Graphics.DrawString(strText, DataFont, Brushes.Black, nX, nY);
							nY += TextSize.Height;
							}

						nX = nOriginalX;
						}

					//----------------------------------------------------------------------------*
					// Specs
					//----------------------------------------------------------------------------*

					if (m_DataFiles.Preferences.FirearmPrintSpecs)
						{
						strText = "Additional Specifications:";

						TextSize = e.Graphics.MeasureString(strText, HeaderFont);

						nY += (TextSize.Height / (float) 2.0);

						e.Graphics.DrawString(strText, HeaderFont, Brushes.Black, nX, nY);

						float nOriginalX = nX;

						nX += TextSize.Width / 2;

						nY += (TextSize.Height * (float) 1.5);

						int nData1X = (int) e.Graphics.MeasureString("Barrel Length: ", SpecsFont).Width;
						int nData2X = (int) e.Graphics.MeasureString("Zero Range: ", SpecsFont).Width;
						int nData3X = (int) e.Graphics.MeasureString("Turret Click: ", SpecsFont).Width;

						int nColumn1 = (int) nX;
						int nColumn2 = nColumn1 + (int) e.Graphics.MeasureString("Barrel Length: 00.00", SpecsFont).Width + 20;
						int nColumn3 = nColumn2 + (int) e.Graphics.MeasureString("Zero Range: ", SpecsFont).Width + (int) e.Graphics.MeasureString("1:00.00", SpecsFont).Width + 20;

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
						}

					nX = PageRect.Left;
					}

				//----------------------------------------------------------------------------*
				// Draw Parts & Accessory List
				//----------------------------------------------------------------------------*

				if (m_DataFiles.FirearmAccessoryCount(Firearm) > 0)
					{
					strText = "Parts, Accessories, & Other Costs";

					TextSize = e.Graphics.MeasureString(strText, HeaderFont);

					e.Graphics.DrawString(strText, HeaderFont, Brushes.Black, nLeftMargin + (PageAreaRect.Width / 2) - (TextSize.Width / 2), nY);

					nY += HeaderFont.Height;

					cFirearmAccessoryListPreviewDialog.DrawHeader = false;
					cFirearmAccessoryListPreviewDialog.GearList = null;
					cFirearmAccessoryListPreviewDialog.Firearm = Firearm;

					nY = cFirearmAccessoryListPreviewDialog.DrawAccessoryList(m_DataFiles, ref e, nY);
					}

				//----------------------------------------------------------------------------*
				// Set Flag and Exit
				//----------------------------------------------------------------------------*

				Firearm.Printed = true;

				break;
				}

			//----------------------------------------------------------------------------*
			// Check for more firearms to print
			//----------------------------------------------------------------------------*

			if (!e.HasMorePages)
				{
				foreach (cFirearm Firearm in m_FirearmList)
					{
					if (!Firearm.Printed)
						{
						e.HasMorePages = true;

						break;
						}
					}
				}

			//----------------------------------------------------------------------------*
			// If not, reset the printed flag
			//----------------------------------------------------------------------------*

			if (!e.HasMorePages)
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

			cFirearmAccessoryListPreviewDialog.ResetPrintedFlag(m_DataFiles);
			}
		}
	}
