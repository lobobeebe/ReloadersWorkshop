//============================================================================*
// cTargetPrintPreviewDialog.cs
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
	// cTargetPrintPreviewDialog Class
	//============================================================================*

	public class cTargetPrintPreviewDialog : PrintPreviewDialog
		{
		//============================================================================*
		// Private Data Members
		//============================================================================*

		private bool m_fInitialized = false;

		private cDataFiles m_DataFiles = null;
		private cTarget m_Target = null;
		private Image m_Image = null;

		//============================================================================*
		// cTargetPrintPreviewDialog() - Constructor
		//============================================================================*

		public cTargetPrintPreviewDialog(cDataFiles DataFiles, cTarget Target, Image TargetImage)
			{
			m_DataFiles = DataFiles;
			m_Target = Target;
			m_Image = TargetImage;

			if (m_DataFiles.Preferences.TargetPrintMaximized)
				{
				WindowState = FormWindowState.Maximized;
				}
			else
				{
				WindowState = FormWindowState.Normal;

				Location = m_DataFiles.Preferences.TargetPrintLocation;
				ClientSize = m_DataFiles.Preferences.TargetPrintSize;
				}

			Text = String.Format("{0} Target Calculator - Print Preview", Application.ProductName);

			PrintDocument TargetPrintDocument = new PrintDocument();
			TargetPrintDocument.PrintPage += OnPrintPage;

			Document = TargetPrintDocument;

			UseAntiAlias = true;

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

			m_DataFiles.Preferences.TargetPrintLocation = Location;
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
			Font TargetNameFont = new Font("Trebuchet MS", 14, FontStyle.Bold);
			Font ShooterFont = new Font("Trebuchet MS", 12, FontStyle.Bold);
			Font HeaderFont = new Font("Trebuchet MS", 10, FontStyle.Bold);
			Font DataFont = new Font("Trebuchet MS", 9, FontStyle.Regular);
			Font ShotFont = new Font("Trebuchet MS", 8, FontStyle.Regular);

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

			float nY = PageRect.Top;
			float nX = PageRect.Left;

			//----------------------------------------------------------------------------*
			// Draw the page header
			//----------------------------------------------------------------------------*

			nY = cPrintObject.PrintReportTitle("Target Detail", e, PageRect);

			//----------------------------------------------------------------------------*
			// Event
			//----------------------------------------------------------------------------*

			string strText = "Event: ";
			SizeF TextSize = e.Graphics.MeasureString(strText, ShooterFont);

			if (!String.IsNullOrEmpty(m_Target.Event))
				{
				strText += String.Format("{0}", m_Target.Event);

				TextSize = e.Graphics.MeasureString(strText, ShooterFont);

				e.Graphics.DrawString(strText, ShooterFont, Brushes.Black, nX + (PageRect.Width / 2) - (TextSize.Width / 2), nY);

				nY += TextSize.Height;
				}

			nY += (int) (TextSize.Height * 1.5);

			//----------------------------------------------------------------------------*
			// Shot by and where
			//----------------------------------------------------------------------------*

			strText = "Shot ";

			if (!String.IsNullOrEmpty(m_Target.Shooter))
				{
				strText += "by ";
				strText += m_Target.Shooter;
				strText += " ";
				}

			if (!String.IsNullOrEmpty(m_Target.Location))
				{
				strText += "at ";
				strText += m_Target.Location;
				}

			if (strText.Length > 5)
				{
				TextSize = e.Graphics.MeasureString(strText, ShooterFont);

				e.Graphics.DrawString(strText, ShooterFont, Brushes.Black, nX + (PageRect.Width / 2) - (TextSize.Width / 2), nY);

				strText = "";

				nY += TextSize.Height;
				}

			//----------------------------------------------------------------------------*
			// Date & Firearm
			//----------------------------------------------------------------------------*

			strText += String.Format("on {0} with a ", m_Target.Date.ToShortDateString());

			if (m_Target.Firearm != null)
				strText += m_Target.Firearm.ToString();
			else
				strText += m_Target.Caliber.ToString();

			strText += " ";

			switch (m_Target.Caliber.FirearmType)
				{
				case cFirearm.eFireArmType.Handgun:
					strText += "Handgun";
					break;
				case cFirearm.eFireArmType.Rifle:
					strText += "Rifle";
					break;
				case cFirearm.eFireArmType.Shotgun:
					strText += "Shotgun";
					break;
				}

			TextSize = e.Graphics.MeasureString(strText, ShooterFont);

			e.Graphics.DrawString(strText, ShooterFont, Brushes.Black, nX + (PageRect.Width / 2) - (TextSize.Width / 2), nY);

			nY += TextSize.Height;

			if (m_Target.Firearm != null)
				{
				strText = String.Format("Chambered for {0}", m_Target.Caliber.ToString());

				TextSize = e.Graphics.MeasureString(strText, ShooterFont);

				e.Graphics.DrawString(strText, ShooterFont, Brushes.Black, nX + (PageRect.Width / 2) - (TextSize.Width / 2), nY);

				nY += TextSize.Height;
				}

			nY += TextSize.Height;

			//----------------------------------------------------------------------------*
			// Firearm Image
			//----------------------------------------------------------------------------*

			if (m_Image != null)
				{
				double dWidth = m_Image.Width;
				double dHeight = m_Image.Height;

				if (m_Image.Width > PageRect.Width)
					{
					dHeight = dHeight / dWidth;
					dWidth = PageRect.Width;
					dHeight *= dWidth;
					}

				e.Graphics.DrawImage(m_Image, new Rectangle((int) (nX + (PageRect.Width / 2.0) - (dWidth / 2.0)), (int) nY, (int) dWidth, (int) dHeight));

				nY += (int) dHeight + TextSize.Height;
				}

			nY += TextSize.Height;

			//----------------------------------------------------------------------------*
			// Range Info
			//----------------------------------------------------------------------------*

			strText = String.Format("{0:D0} Shot{1} at ", m_Target.NumShots, m_Target.NumShots > 1 ? "s" : "");

			strText += String.Format("{0:N0} {1}", m_Target.Range, m_DataFiles.MetricLongString(cDataFiles.eDataType.Range));

			TextSize = e.Graphics.MeasureString(strText, HeaderFont);

			e.Graphics.DrawString(strText, HeaderFont, Brushes.Black, nX + (PageRect.Width / 2) - (TextSize.Width / 2), nY);

			nY += (int) (TextSize.Height * 1.5);

			//----------------------------------------------------------------------------*
			// Group Size Info
			//----------------------------------------------------------------------------*

			strText = "Group Size: ";

			string strGroupFormat = "{0:F";
			strGroupFormat += String.Format("{0:G0}", m_DataFiles.Preferences.GroupDecimals);
			strGroupFormat += "}";

			strText += String.Format(strGroupFormat, m_Target.GroupSize);

			strText += String.Format(" {0}   MOA: {1:F3}   Mils: {2:F3}", cDataFiles.MetricString(cDataFiles.eDataType.GroupSize), m_Target.GroupMOA, m_Target.GroupMils);

			TextSize = e.Graphics.MeasureString(strText, DataFont);

			e.Graphics.DrawString(strText, DataFont, Brushes.Black, nX + (PageRect.Width / 2) - (TextSize.Width / 2), nY);

			nY += (int) (TextSize.Height * 1.5);

			//----------------------------------------------------------------------------*
			// Group Box
			//----------------------------------------------------------------------------*

			strText = String.Format("Group Box: {0}", m_Target.GroupBoxString());

			TextSize = e.Graphics.MeasureString(strText, DataFont);

			e.Graphics.DrawString(strText, DataFont, Brushes.Black, nX + (PageRect.Width / 2) - (TextSize.Width / 2), nY);

			nY += (int) (TextSize.Height * 1.5);

			//----------------------------------------------------------------------------*
			// Mean Offset Info
			//----------------------------------------------------------------------------*

			strText = String.Format("Mean Offset from Aim Point: {0}", m_Target.MeanOffsetString());

			TextSize = e.Graphics.MeasureString(strText, DataFont);

			e.Graphics.DrawString(strText, DataFont, Brushes.Black, nX + (PageRect.Width / 2) - (TextSize.Width / 2), nY);

			nY += (int) (TextSize.Height * 1.5);

			//----------------------------------------------------------------------------*
			// Notes
			//----------------------------------------------------------------------------*

			if (!String.IsNullOrEmpty(m_Target.Notes))
				{
				strText = "Notes:";

				TextSize = e.Graphics.MeasureString(strText, DataFont);

				e.Graphics.DrawString(strText, DataFont, Brushes.Black, nX, nY);

				nY += (int) (TextSize.Height * 1.5);

				float nOriginalX = nX;

				nX += TextSize.Width;

				int nPrevIndex = 0;
				string strNotes = m_Target.Notes;
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

							strNotes = m_Target.Notes.Substring(nCharCount);

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

								strNotes = m_Target.Notes.Substring(nCharCount);

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
			// Finish up
			//----------------------------------------------------------------------------*

			e.HasMorePages = false;
			}

		//============================================================================*
		// OnResize()
		//============================================================================*

		protected override void OnResize(EventArgs e)
			{
			base.OnResize(e);

			if (!m_fInitialized)
				return;

			m_DataFiles.Preferences.TargetPrintMaximized = WindowState == FormWindowState.Maximized;

			if (!m_DataFiles.Preferences.TargetPrintMaximized)
				{
				m_DataFiles.Preferences.TargetPrintLocation = Location;
				m_DataFiles.Preferences.TargetPrintSize = ClientSize;
				}
			}
		}
	}
