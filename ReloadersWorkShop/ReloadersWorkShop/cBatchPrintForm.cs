//============================================================================*
// cBatchPrintForm.cs
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
using System.Windows;
using System.Windows.Forms;

using ReloadersWorkShop.Preferences;

//============================================================================*
// NameSpace
//============================================================================*

namespace ReloadersWorkShop
	{
	//============================================================================*
	// cBatchForm Class
	//============================================================================*

	public partial class cBatchPrintForm : Form
		{
		//----------------------------------------------------------------------------*
		// Paper Enumeration
		//----------------------------------------------------------------------------*

		enum ePaper
			{
			Letter = 0,
			Avery5444,
			Avery5453,
			Avery6464,
			Avery6482
			}

		//----------------------------------------------------------------------------*
		// Private Data Members
		//----------------------------------------------------------------------------*

		private bool m_fInitialized = false;

		private cBatchList m_BatchList = new cBatchList();

		private cDataFiles m_DataFiles = null;

		private PrintDocument m_PrintDocument = new PrintDocument();

		private int m_nStartLabel = 0;
		private int m_nNumCopies = 0;

		//============================================================================*
		// cBatchPrintForm() - Constructor
		//============================================================================*

		public cBatchPrintForm(cBatchList BatchList, cDataFiles DataFiles)
			{
			InitializeComponent();

			m_BatchList = BatchList;

			m_DataFiles = DataFiles;

			SetClientSizeCore(LabelFormatGroupBox.Location.X + LabelFormatGroupBox.Width + 10, BatchPrintCancelButton.Location.Y + BatchPrintCancelButton.Height + 20);

			//----------------------------------------------------------------------------*
			// Set Title
			//----------------------------------------------------------------------------*

			if (m_BatchList.Count == 1)
				{
				Text = String.Format("Print Batch #{0:G0} Labels", (m_BatchList[0] as cBatch).BatchID);

				PerBatchLabel.Visible = false;
				}
			else
				Text = String.Format("Print Checked Batch Labels ({0:G0})", m_BatchList.Count);

			//----------------------------------------------------------------------------*
			// Event Handlers
			//----------------------------------------------------------------------------*

			NumLabelsTextBox.TextChanged += OnNumLabelsTextChanged;

			BatchPrintButton.Click += PrintButtonClicked;
			PaperComboBox.SelectedIndexChanged += OnPaperChanged;
			PageImageBox.MouseClick += OnPageImageClicked;
			m_PrintDocument.PrintPage += OnPrintPage;

			TestShotBlanksRadioButton.Click += OnTestShotBlanksClicked;
			LoadDataTestRadioButton.Click += OnLoadDataTestClicked;
			BatchTestRadioButton.Click += OnBatchTestClicked;

			//----------------------------------------------------------------------------*
			// Set defaults
			//----------------------------------------------------------------------------*

			PaperComboBox.SelectedIndex = m_DataFiles.Preferences.BatchPrintPaper;
			m_nStartLabel = m_DataFiles.Preferences.BatchPrintStartLabel;

			NumLabelsTextBox.Value = 1;

			if (m_DataFiles.Preferences.BatchPrintPaper != 1)
				TestShotBlanksRadioButton.Checked = true;
			else
				TestShotBlanksRadioButton.Checked = false;

			LoadDataTestRadioButton.Checked = false;
			BatchTestRadioButton.Checked = false;

			//----------------------------------------------------------------------------*
			// Create Page Image
			//----------------------------------------------------------------------------*

			CreatePageImage();

			m_fInitialized = true;

			UpdateButtons();

			DrawLabelImage(m_BatchList[0], LabelRectangle());

			NumLabelsTextBox.Focus();
			}

		//============================================================================*
		// CreatePageImage()
		//============================================================================*

		private void CreatePageImage()
			{
			Size PageSize = PageImageBox.Size;

			Bitmap PageImage = new Bitmap(PageSize.Width, PageSize.Height);

			Graphics Graphics = Graphics.FromImage(PageImage);

			Graphics.FillRectangle(Brushes.White, 0, 0, PageSize.Width, PageSize.Height);

			//----------------------------------------------------------------------------*
			// Draw gridlines for the selected paper
			//----------------------------------------------------------------------------*

			switch ((ePaper) PaperComboBox.SelectedIndex)
				{
				//----------------------------------------------------------------------------*
				// Letter, Avery 6464, & Avery 6482
				//----------------------------------------------------------------------------*

				case ePaper.Letter:
				case ePaper.Avery6464:
				case ePaper.Avery6482:
					Graphics.DrawLine(Pens.Black, PageSize.Width / 2, 0, PageSize.Width / 2, PageSize.Height);

					for (int i = 0; i < PageSize.Height / 3; i++)
						Graphics.DrawLine(Pens.Black, 0, (i + 1) * PageSize.Height / 3, PageSize.Width, (i + 1) * PageSize.Height / 3);

					break;

				//----------------------------------------------------------------------------*
				// Avery 5444 & 5453
				//----------------------------------------------------------------------------*

				case ePaper.Avery5444:
				case ePaper.Avery5453:
					Graphics.DrawLine(Pens.Black, 0, PageSize.Height / 2, PageSize.Width, PageSize.Height / 2);

					break;
				}

			//----------------------------------------------------------------------------*
			// fill in the label numbers and fill in the startng label with gray
			//----------------------------------------------------------------------------*

			Rectangle LabelRect = new Rectangle(0, 0, 0, 0);

			Font LabelFont = new Font("Trebuchet MS", (float) 8.0, FontStyle.Regular);

			for (int nLabelNum = 0; nLabelNum < 6; nLabelNum++)
				{
				switch ((ePaper) PaperComboBox.SelectedIndex)
					{
					//----------------------------------------------------------------------------*
					// Letter
					//----------------------------------------------------------------------------*

					case ePaper.Letter:
					case ePaper.Avery6464:
					case ePaper.Avery6482:
						if (m_nStartLabel > 5)
							{
							m_nStartLabel = 0;
							m_DataFiles.Preferences.BatchPrintStartLabel = m_nStartLabel;
							}

						//----------------------------------------------------------------------------*
						// Get the label rectangle
						//----------------------------------------------------------------------------*

						LabelRect.X = (nLabelNum % 2) * (PageSize.Width / 2) + 1;
						LabelRect.Y = (nLabelNum / 2) * (PageSize.Height / 3) + 1;
						LabelRect.Width = (PageSize.Width / 2) - 2;
						LabelRect.Height = (PageSize.Height / 3) - 2;

						//----------------------------------------------------------------------------*
						// Fill nthe rectangle if this is the starting label
						//----------------------------------------------------------------------------*

						if (nLabelNum == m_nStartLabel)
							Graphics.FillRectangle(Brushes.LightGray, LabelRect);

						//----------------------------------------------------------------------------*
						// Draw the label number
						//----------------------------------------------------------------------------*

						string strNum = String.Format("{0:G0}", nLabelNum + 1);

						SizeF NumSize = Graphics.MeasureString(strNum, LabelFont);

						float dX = LabelRect.X + (float) ((float) LabelRect.Width / 2.0) - ((float) NumSize.Width / (float) 2.0);
						float dY = LabelRect.Y + (float) ((float) LabelRect.Height / 2.0) - ((float) NumSize.Height / (float) 2.0);

						Graphics.DrawString(strNum, LabelFont, Brushes.Black, dX, dY);

						break;

					//----------------------------------------------------------------------------*
					// Avery 5444 & 5453
					//----------------------------------------------------------------------------*

					case ePaper.Avery5444:
					case ePaper.Avery5453:
						if (nLabelNum > 1)
							break;

						if (m_nStartLabel > 1)
							{
							m_nStartLabel = 0;
							m_DataFiles.Preferences.BatchPrintStartLabel = m_nStartLabel;
							}

						LabelRect.X = 1;
						LabelRect.Y = nLabelNum * (PageSize.Height / 2) + 1;
						LabelRect.Width = PageSize.Width;
						LabelRect.Height = (PageSize.Height / 2) - 2;

						//----------------------------------------------------------------------------*
						// Fill in the rectangle if this is the starting label
						//----------------------------------------------------------------------------*

						if (nLabelNum == m_nStartLabel)
							Graphics.FillRectangle(Brushes.LightGray, LabelRect);

						//----------------------------------------------------------------------------*
						// Draw the label number
						//----------------------------------------------------------------------------*

						strNum = String.Format("{0:G0}", nLabelNum + 1);

						NumSize = Graphics.MeasureString(strNum, LabelFont);

						dX = LabelRect.X + (float) ((float) LabelRect.Width / 2.0) - ((float) NumSize.Width / (float) 2.0);
						dY = LabelRect.Y + (float) ((float) LabelRect.Height / 2.0) - ((float) NumSize.Height / (float) 2.0);

						Graphics.DrawString(strNum, LabelFont, Brushes.Black, dX, dY);

						break;
					}
				}

			PageImageBox.Image = PageImage;
			}

		//============================================================================*
		// DrawLabel()
		//============================================================================*

		private void DrawLabel(cBatch Batch, Rectangle LabelRect, Graphics Graphics)
			{
			cCaliber.CurrentFirearmType = Batch.Load.FirearmType;

			//----------------------------------------------------------------------------*
			// Print the label header
			//----------------------------------------------------------------------------*

			Font LabelHeaderFont = new Font("Trebuchet MS", (float) 10.0, FontStyle.Bold);
			Font LabelFont = new Font("Trebuchet MS", (float) 8.0, FontStyle.Regular);
			Font LabelBoldFont = new Font("Trebuchet MS", (float) 8.0, FontStyle.Bold);

			// Don't fill in a colored header for Avery 6482 since it's a colored paper

			if (PaperComboBox.SelectedIndex != (int) ePaper.Avery6482)
				Graphics.FillRectangle(Brushes.LightBlue, LabelRect.X, LabelRect.Y, LabelRect.Width, (int) ((double) LabelHeaderFont.Height * 4.5));

			Graphics.DrawLine(Pens.Black, LabelRect.X, LabelRect.Y + (int) ((double) LabelHeaderFont.Height * 4.5) + 1, LabelRect.X + LabelRect.Width, LabelRect.Y + (int) ((double) LabelHeaderFont.Height * 4.5) + 1);

			float dX = LabelRect.X;
			float dY = LabelRect.Y;

			// Batch # and Date

			Graphics.DrawString(String.Format("Batch #{0:G0} - {1}", Batch.BatchID, String.IsNullOrEmpty(Batch.UserID) ? "" : Batch.UserID), LabelHeaderFont, Brushes.Black, dX, dY);

			String strString = String.Format("Date Loaded: {0}", Batch.DateLoaded.ToShortDateString());

			SizeF StringSize = Graphics.MeasureString(strString, LabelHeaderFont);

			dX = LabelRect.X + LabelRect.Width - StringSize.Width;

			Graphics.DrawString(strString, LabelHeaderFont, Brushes.Black, dX, dY);

			dX = LabelRect.X;

			dY += ((float) LabelHeaderFont.Height * (float) 2.0);

			// Firearm, if any

			Graphics.DrawString(String.Format("For {0}", Batch.Firearm != null ? Batch.Firearm.ToString() : "Any Firearm"), LabelHeaderFont, Brushes.Black, dX, dY);

			dY += (float) LabelHeaderFont.Height;

			// Caliber and Number of Rounds

			Graphics.DrawString(String.Format("Caliber: {0}", Batch.Load.Caliber.ToString()), LabelHeaderFont, Brushes.Black, dX, dY);

			strString = String.Format("{0:G0} Rounds", Batch.NumRounds);

			StringSize = Graphics.MeasureString(strString, LabelHeaderFont);

			dX = LabelRect.X + (LabelRect.Width - StringSize.Width);

			Graphics.DrawString(strString, LabelHeaderFont, Brushes.Black, dX, dY);

			dX = LabelRect.X;

			dY += ((float) LabelHeaderFont.Height * (float) 2.0);

			//----------------------------------------------------------------------------*
			// Print Load Data
			//----------------------------------------------------------------------------*

			// Bullet

			SizeF LabelSize = Graphics.MeasureString("Powder: ", LabelFont);

			dX += (int) LabelSize.Width;

			float dDataX = dX;

			LabelSize = Graphics.MeasureString("Bullet: ", LabelFont);

			dX = dDataX - LabelSize.Width;

			Graphics.DrawString("Bullet:", LabelFont, Brushes.Black, dX, dY);

			SizeF BoldSize = Graphics.MeasureString("Bullet: ", LabelBoldFont);

			dY -= (int) (BoldSize.Height - LabelSize.Height);

			strString = Batch.Load.Bullet.ToWeightString();

			if (Batch.ModifiedBullet)
				strString += " (Modified)";

			Graphics.DrawString(strString, LabelBoldFont, Brushes.Black, dDataX, dY);

			dY += LabelBoldFont.Height;

			// Powder

			LabelSize = Graphics.MeasureString("Powder: ", LabelFont);

			dX = dDataX - LabelSize.Width;

			Graphics.DrawString("Powder:", LabelFont, Brushes.Black, dX, dY);

			BoldSize = Graphics.MeasureString("Powder: ", LabelBoldFont);

			dY -= (int) (BoldSize.Height - LabelSize.Height);

			Graphics.DrawString(String.Format("{0:F1} gr of {1}", Batch.PowderWeight, Batch.Load.Powder.ToString()), LabelBoldFont, Brushes.Black, dDataX, dY);

			dY += LabelBoldFont.Height;

			// Primer

			LabelSize = Graphics.MeasureString("Primer: ", LabelFont);

			dX = dDataX - LabelSize.Width;

			Graphics.DrawString("Primer:", LabelFont, Brushes.Black, dX, dY);

			BoldSize = Graphics.MeasureString("Primer: ", LabelBoldFont);

			dY -= (int) (BoldSize.Height - LabelSize.Height);

			Graphics.DrawString(Batch.Load.Primer.ToString(), LabelBoldFont, Brushes.Black, dDataX, dY);

			dY += LabelBoldFont.Height;

			// Case Sizing

			LabelSize = Graphics.MeasureString("Case: ", LabelFont);

			dX = dDataX - LabelSize.Width;

			Graphics.DrawString("Case:", LabelFont, Brushes.Black, dX, dY);

			BoldSize = Graphics.MeasureString("Case: ", LabelBoldFont);

			dY -= (int) (BoldSize.Height - LabelSize.Height);

			strString = Batch.Load.Case.HeadStamp; // .ToShortString();

			Graphics.DrawString(strString, LabelBoldFont, Brushes.Black, dDataX, dY);

			if (Batch.Load.FirearmType == cFirearm.eFireArmType.Rifle && (Batch.FullLengthSized || Batch.NeckSized || Batch.ExpandedNeck || Batch.NeckTurned || Batch.Annealed))
				{
				BoldSize = Graphics.MeasureString(strString, LabelBoldFont);

				dX = dDataX + BoldSize.Width;

				strString = "- ";

				if (Batch.NeckTurned)
					strString += "Neck Turned";

				if (Batch.Annealed)
					{
					if (strString.Length > 2)
						strString += ", ";

					strString += "Annealed";
					}

				if (Batch.FullLengthSized)
					{
					if (strString.Length > 2)
						strString += ", ";

					strString += "FL Sized";
					}
				else
					{
					if (Batch.NeckSized)
						{
						if (strString.Length > 2)
							strString += ", ";

						strString += "Neck Sized";
						}
					else
						{
						if (Batch.ExpandedNeck)
							{
							if (strString.Length > 2)
								strString += ", ";

							strString += "Neck Exp";
							}
						}
					}

				Graphics.DrawString(strString, LabelBoldFont, Brushes.Black, dX, dY);
				}

			dY += (LabelBoldFont.Height * (float) 1.5);

			//----------------------------------------------------------------------------*
			// Print Measurements
			//----------------------------------------------------------------------------*

			float dColumn3X = (float) 0.0;

			// Case Length

			dX = LabelRect.X;

			Graphics.DrawString("Case Length:", LabelFont, Brushes.Black, dX, dY);
			LabelSize = Graphics.MeasureString("Case Length: ", LabelFont);

			dX += (int) LabelSize.Width;

			dDataX = dX;

			BoldSize = Graphics.MeasureString("Case Length: ", LabelBoldFont);

			dY -= (int) (BoldSize.Height - LabelSize.Height);

			strString = String.Format(" {0:F3} {1}", cDataFiles.StandardToMetric(Batch.CaseTrimLength, cDataFiles.eDataType.Dimension), cDataFiles.MetricString(cDataFiles.eDataType.Dimension));

			Graphics.DrawString(strString, LabelBoldFont, Brushes.Black, dX, dY);

			strString += "   ";

			StringSize = Graphics.MeasureString(strString, LabelBoldFont);

			dX += StringSize.Width;

			dY += (int) (BoldSize.Height - LabelSize.Height);

			// Cartridge Length

			LabelSize = Graphics.MeasureString("CBTO: ", LabelFont);

			float dData1X = dX + LabelSize.Width;

			LabelSize = Graphics.MeasureString("COAL: ", LabelFont);

			dX = dData1X - LabelSize.Width;

			Graphics.DrawString("COAL:", LabelFont, Brushes.Black, dX, dY);

			BoldSize = Graphics.MeasureString("COAL: ", LabelBoldFont);

			dY -= (int) (BoldSize.Height - LabelSize.Height);

			strString = Batch.COL > 0.0 ? String.Format(" {0:F3} {1}", cDataFiles.StandardToMetric(Batch.COL, cDataFiles.eDataType.Dimension), cDataFiles.MetricString(cDataFiles.eDataType.Dimension)) : "N/A";

			Graphics.DrawString(strString, LabelBoldFont, Brushes.Black, dData1X, dY);

			strString += "   ";

			BoldSize = Graphics.MeasureString(strString, LabelBoldFont);

			dX = dData1X + BoldSize.Width;

			if (dX > dColumn3X)
				dColumn3X = dX;

			// Times fired

			dX = dColumn3X;

			LabelSize = Graphics.MeasureString("Neck sized to: ", LabelFont);

			float dData2X = dX + LabelSize.Width;

			LabelSize = Graphics.MeasureString("Fired: ", LabelFont);

			dX = dData2X - LabelSize.Width;

			Graphics.DrawString("Fired:", LabelFont, Brushes.Black, dX, dY);

			dX += (int) LabelSize.Width;

			BoldSize = Graphics.MeasureString("Fired: ", LabelBoldFont);

			dY -= (int) (BoldSize.Height - LabelSize.Height);

			strString = String.Format(" {0:N0} time{1}", Batch.TimesFired, Batch.TimesFired != 1 ? "s" : "");

			Graphics.DrawString(strString, LabelBoldFont, Brushes.Black, dX, dY);

			dX = LabelRect.X;
			dY += LabelBoldFont.Height;

			//----------------------------------------------------------------------------*
			// Rifle Measurements
			//----------------------------------------------------------------------------*

			if (Batch.Load.FirearmType == cFirearm.eFireArmType.Rifle)
				{
				// Headspace

				dY += (int) (BoldSize.Height - LabelSize.Height);

				LabelSize = Graphics.MeasureString("Headspace: ", LabelFont);

				dX = dDataX - LabelSize.Width;

				Graphics.DrawString("Headspace:", LabelFont, Brushes.Black, dX, dY);

				dX = dDataX;

				BoldSize = Graphics.MeasureString("Headspace: ", LabelBoldFont);

				dY -= (int) (BoldSize.Height - LabelSize.Height);

				Graphics.DrawString(Batch.HeadSpace > 0.0 ? String.Format(" {0:F3} {1}", cDataFiles.StandardToMetric(Batch.HeadSpace, cDataFiles.eDataType.Dimension), cDataFiles.MetricString(cDataFiles.eDataType.Dimension)) : "N/A", LabelBoldFont, Brushes.Black, dX, dY);

				dY += (int) (BoldSize.Height - LabelSize.Height);

				// CBTO

				LabelSize = Graphics.MeasureString("CBTO: ", LabelFont);

				dX = dData1X - LabelSize.Width;

				Graphics.DrawString("CBTO:", LabelFont, Brushes.Black, dX, dY);

				dX = dData1X;

				BoldSize = Graphics.MeasureString("CBTO: ", LabelBoldFont);

				dY -= (int) (BoldSize.Height - LabelSize.Height);

				strString = Batch.CBTO > 0.0 ? String.Format(" {0:F3} {1}", cDataFiles.StandardToMetric(Batch.CBTO, cDataFiles.eDataType.Dimension), cDataFiles.MetricString(cDataFiles.eDataType.Dimension)) : "N/A";

				Graphics.DrawString(strString, LabelBoldFont, Brushes.Black, dX, dY);

				dY += (int) (BoldSize.Height - LabelSize.Height);

				strString += "   ";

				BoldSize = Graphics.MeasureString(strString, LabelBoldFont);

				dX += BoldSize.Width;

				if (dX > dColumn3X)
					dColumn3X = dX;

				// Neck

				dX = dColumn3X;

				LabelSize = Graphics.MeasureString("Neck sized to: ", LabelFont);

				dX = dData2X - LabelSize.Width;

				Graphics.DrawString("Neck sized to:", LabelFont, Brushes.Black, dX, dY);

				dX = dData2X;

				BoldSize = Graphics.MeasureString("Neck sized to: ", LabelBoldFont);

				dY -= (int) (BoldSize.Height - LabelSize.Height);

				strString = Batch.NeckSize > 0.0 ? String.Format(" {0:F3} {1}", cDataFiles.StandardToMetric(Batch.NeckSize, cDataFiles.eDataType.Dimension), cDataFiles.MetricString(cDataFiles.eDataType.Dimension)) : "N/A";

				Graphics.DrawString(strString, LabelBoldFont, Brushes.Black, dX, dY);

				dY += LabelBoldFont.Height;
				}

			dX = LabelRect.X;

			//----------------------------------------------------------------------------*
			// Additional Rifle Measurements
			//----------------------------------------------------------------------------*

			if (Batch.Load.FirearmType == cFirearm.eFireArmType.Rifle)
				{
				if (Batch.JumpSet)
					{
					// Jump

					LabelSize = Graphics.MeasureString("Jump: ", LabelFont);

					dX = dDataX - LabelSize.Width;

					Graphics.DrawString("Jump:", LabelFont, Brushes.Black, dX, dY);

					dX = dDataX;

					BoldSize = Graphics.MeasureString("Jump: ", LabelBoldFont);

					dY -= (int)(BoldSize.Height - LabelSize.Height);

					Graphics.DrawString(String.Format(" {0:F3}", cDataFiles.StandardToMetric(Batch.Jump, cDataFiles.eDataType.Dimension)), LabelBoldFont, Brushes.Black, dX, dY);

					dY += (int)(BoldSize.Height - LabelSize.Height);
					}

				dY += LabelBoldFont.Height;
				}

			dX = LabelRect.X;
			dY += LabelBoldFont.Height;

			//----------------------------------------------------------------------------*
			// Notes
			//----------------------------------------------------------------------------*

			if (PaperComboBox.SelectedIndex != (int) ePaper.Avery5444 && ((!TestShotBlanksRadioButton.Checked && !LoadDataTestRadioButton.Checked && !BatchTestRadioButton.Checked) || (BatchTestRadioButton.Checked && Batch.BatchTest == null)))
				Graphics.DrawString("Notes:", LabelFont, Brushes.Black, dX, dY);

			//----------------------------------------------------------------------------*
			// Test Shot Blanks
			//----------------------------------------------------------------------------*

			if (TestShotBlanksRadioButton.Checked)
				{
				Graphics.DrawString("Test Shots (Muzzle Vel.)", LabelFont, Brushes.Black, dX, dY);

				String strBlank = "____________";

				strString = "Best Group: " + strBlank;

				LabelSize = Graphics.MeasureString(strString, LabelFont);

				dX = LabelRect.X + LabelRect.Width - LabelSize.Width - 10;

				Graphics.DrawString(strString, LabelFont, Brushes.Black, dX, dY);

				dX = LabelRect.X;
				dY += ((float) LabelFont.Height * (float) 1.5);

				float dTestShotTop = dY;
				int nShotNum = 1;

				strString = String.Format("{0:G0} {1}  ", nShotNum, strBlank);

				StringSize = Graphics.MeasureString(strString, LabelFont);

				while (dX + StringSize.Width < LabelRect.X + LabelRect.Width && nShotNum <= Batch.NumRounds)
					{
					if (dY + StringSize.Height > LabelRect.Y + LabelRect.Height)
						{
						dY = dTestShotTop;

						dX += StringSize.Width;

						continue;
						}

					strString = String.Format("{0:G0} {1}  ", nShotNum++, strBlank);

					StringSize = Graphics.MeasureString(strString, LabelFont);

					Graphics.DrawString(strString, LabelFont, Brushes.Black, dX, dY);

					dY += ((float) LabelFont.Height * (float) 1.5);
					}
				}

			//----------------------------------------------------------------------------*
			// Batch Test Data
			//----------------------------------------------------------------------------*

			if (BatchTestRadioButton.Checked && Batch.BatchTest != null)
				{
				strString = String.Format("Batch {0:G0} Test Data", Batch.BatchID);

				Graphics.DrawString(strString, LabelFont, Brushes.Black, dX, dY);

				dY += ((float) LabelFont.Height * (float) 1.5);

				cTestStatistics Statistics = new cTestStatistics(Batch.BatchTest.TestShotList);

				// Num Shots

				strString = "Num Shots: ";

				Graphics.DrawString(strString, LabelFont, Brushes.Black, dX, dY);

				LabelSize = Graphics.MeasureString(strString, LabelFont);
				BoldSize = Graphics.MeasureString(strString, LabelBoldFont);

				dX += LabelSize.Width;
				dY -= (BoldSize.Height - LabelSize.Height);

				strString = String.Format("{0:G0}, ", Statistics.NumShots);

				Graphics.DrawString(strString, LabelBoldFont, Brushes.Black, dX, dY);

				BoldSize = Graphics.MeasureString(strString, LabelBoldFont);

				dX += BoldSize.Width;
				dY += (BoldSize.Height - LabelSize.Height);

				// Muzzle Velocity

				strString = "Muzzle Vel.: ";

				Graphics.DrawString(strString, LabelFont, Brushes.Black, dX, dY);

				LabelSize = Graphics.MeasureString(strString, LabelFont);
				BoldSize = Graphics.MeasureString(strString, LabelBoldFont);

				dX += LabelSize.Width;
				dY -= (BoldSize.Height - LabelSize.Height);

				strString = String.Format("{0:F1}, ", Statistics.AverageVelocity);

				Graphics.DrawString(strString, LabelBoldFont, Brushes.Black, dX, dY);

				BoldSize = Graphics.MeasureString(strString, LabelBoldFont);

				dX += BoldSize.Width;
				dY += (BoldSize.Height - LabelSize.Height);

				// Min Velocity

				strString = "Min Vel.: ";

				Graphics.DrawString(strString, LabelFont, Brushes.Black, dX, dY);

				LabelSize = Graphics.MeasureString(strString, LabelFont);
				BoldSize = Graphics.MeasureString(strString, LabelBoldFont);

				dX += LabelSize.Width;
				dY -= (BoldSize.Height - LabelSize.Height);

				strString = String.Format("{0:G0}, ", Statistics.MinVelocity);

				Graphics.DrawString(strString, LabelBoldFont, Brushes.Black, dX, dY);

				BoldSize = Graphics.MeasureString(strString, LabelBoldFont);

				dX += BoldSize.Width;
				dY += (BoldSize.Height - LabelSize.Height);

				// Max Velocity

				strString = "Max Vel.: ";

				Graphics.DrawString(strString, LabelFont, Brushes.Black, dX, dY);

				LabelSize = Graphics.MeasureString(strString, LabelFont);
				BoldSize = Graphics.MeasureString(strString, LabelBoldFont);

				dX += LabelSize.Width;
				dY -= (BoldSize.Height - LabelSize.Height);

				strString = String.Format("{0:G0}, ", Statistics.MaxVelocity);

				Graphics.DrawString(strString, LabelBoldFont, Brushes.Black, dX, dY);

				BoldSize = Graphics.MeasureString(strString, LabelBoldFont);

				dX = LabelRect.X;
				dY += BoldSize.Height;

				// Deviation

				strString = "Deviation: ";

				Graphics.DrawString(strString, LabelFont, Brushes.Black, dX, dY);

				LabelSize = Graphics.MeasureString(strString, LabelFont);
				BoldSize = Graphics.MeasureString(strString, LabelBoldFont);

				dX += LabelSize.Width;
				dY -= (BoldSize.Height - LabelSize.Height);

				strString = String.Format("{0:G0}, ", Statistics.MaxVelocity - Statistics.MinVelocity);

				Graphics.DrawString(strString, LabelBoldFont, Brushes.Black, dX, dY);

				BoldSize = Graphics.MeasureString(strString, LabelBoldFont);

				dX += BoldSize.Width;
				dY += (BoldSize.Height - LabelSize.Height);

				// Std Deviation

				strString = "Std Deviation: ";

				Graphics.DrawString(strString, LabelFont, Brushes.Black, dX, dY);

				LabelSize = Graphics.MeasureString(strString, LabelFont);
				BoldSize = Graphics.MeasureString(strString, LabelBoldFont);

				dX += LabelSize.Width;
				dY -= (BoldSize.Height - LabelSize.Height);

				strString = String.Format("{0:F2}", Statistics.StdDev);

				Graphics.DrawString(strString, LabelBoldFont, Brushes.Black, dX, dY);

				BoldSize = Graphics.MeasureString(strString, LabelBoldFont);

				dX = LabelRect.X;
				dY += BoldSize.Height;
				}

			//----------------------------------------------------------------------------*
			// Load Test Data
			//----------------------------------------------------------------------------*

			if (LoadDataTestRadioButton.Checked)
				{
				strString = "Load Test Data";

				Graphics.DrawString(strString, LabelFont, Brushes.Black, dX, dY);

				LabelSize = Graphics.MeasureString(strString, LabelFont);

				dY += (LabelSize.Height * (float) 1.5);

				foreach (cCharge CheckCharge in Batch.Load.ChargeList)
					{
					if (dY > LabelRect.Height)
						break;

					if (CheckCharge.PowderWeight == Batch.PowderWeight)
						{
						CheckCharge.TestList.Sort(new cChargeTestComparer());

						foreach (cChargeTest ChargeTest in CheckCharge.TestList)
							{
							if (dY > LabelRect.Height)
								break;

							//----------------------------------------------------------------------------*
							// Test Date
							//----------------------------------------------------------------------------*

							dX = LabelRect.X;

							strString = String.Format("{0} - ", ChargeTest.TestDate.ToShortDateString());

							Graphics.DrawString(strString, LabelFont, Brushes.Black, dX, dY);

							LabelSize = Graphics.MeasureString(strString, LabelFont);

							dX += LabelSize.Width;

							//----------------------------------------------------------------------------*
							// Source
							//----------------------------------------------------------------------------*

							Graphics.DrawString(ChargeTest.Source, LabelFont, Brushes.Black, dX, dY);

							LabelSize = Graphics.MeasureString(ChargeTest.Source, LabelFont);

							dX += LabelSize.Width;

							//----------------------------------------------------------------------------*
							// Muzzle Velocity
							//----------------------------------------------------------------------------*

							if (ChargeTest.MuzzleVelocity > 0)
								{
								strString = String.Format(", {0:G0} {1}", ChargeTest.MuzzleVelocity, cDataFiles.MetricString(cDataFiles.eDataType.Velocity));

								Graphics.DrawString(strString, LabelFont, Brushes.Black, dX, dY);

								LabelSize = Graphics.MeasureString(strString, LabelFont);

								dX += LabelSize.Width;
								}

							//----------------------------------------------------------------------------*
							// Pressure
							//----------------------------------------------------------------------------*

							if (ChargeTest.Pressure > 0)
								{
								strString = String.Format(", Press: {0:G0}", ChargeTest.Pressure);

								Graphics.DrawString(strString, LabelFont, Brushes.Black, dX, dY);

								LabelSize = Graphics.MeasureString(strString, LabelFont);

								dX += LabelSize.Width;
								}

							//----------------------------------------------------------------------------*
							// Best Group
							//----------------------------------------------------------------------------*

							if (ChargeTest.BestGroup > 0.0)
								{
								strString = String.Format(", {0:F2} {1} Group", ChargeTest.BestGroup, cDataFiles.MetricString(cDataFiles.eDataType.GroupSize));

								Graphics.DrawString(strString, LabelFont, Brushes.Black, dX, dY);

								LabelSize = Graphics.MeasureString(strString, LabelFont);

								dX += LabelSize.Width;
								}

							dY += LabelSize.Height;
							}
						}
					}
				}
			}

		//============================================================================*
		// DrawLabelImage()
		//============================================================================*

		private void DrawLabelImage(cBatch Batch, Rectangle LabelRect)
			{
			Bitmap PageImage = new Bitmap(LabelRect.Width, LabelRect.Height);

			Graphics Graphics = Graphics.FromImage(PageImage);

			Graphics.FillRectangle(Brushes.White, LabelRect);

			DrawLabel(Batch, LabelRect, Graphics);

			LabelImage.Image = PageImage;
			}

		//============================================================================*
		// LabelRectangle()
		//============================================================================*

		private Rectangle LabelRectangle()
			{
			Rectangle LabelRect = new Rectangle(0, 0, 0, 0);

			if (LabelImage.Image == null)
				LabelImage.Image = new Bitmap(1920, 1080);

			Graphics Graphics = Graphics.FromImage(LabelImage.Image);

			switch ((ePaper) PaperComboBox.SelectedIndex)
				{
				//----------------------------------------------------------------------------*
				// Letter, Avery 6464, & Avery 6482
				//----------------------------------------------------------------------------*

				case ePaper.Letter:
				case ePaper.Avery6464:
				case ePaper.Avery6482:
					LabelRect.Width = (int) (Graphics.DpiX * 4.0);
					LabelRect.Height = (int) (Graphics.DpiY * (float) 3.25);

					break;

				//----------------------------------------------------------------------------*
				// Avery 5444
				//----------------------------------------------------------------------------*

				case ePaper.Avery5444:
					LabelRect.Width = (int) (Graphics.DpiX * 3.625);
					LabelRect.Height = (int) (Graphics.DpiY * 2.0);

					break;

				//----------------------------------------------------------------------------*
				// Avery 5453
				//----------------------------------------------------------------------------*

				case ePaper.Avery5453:
					LabelRect.Width = (int) (Graphics.DpiX * 3.97);
					LabelRect.Height = (int) (Graphics.DpiY * 2.97);

					break;
				}

			return (LabelRect);
			}

		//============================================================================*
		// OnBatchTestClicked()
		//============================================================================*

		private void OnBatchTestClicked(object sender, EventArgs e)
			{
			BatchTestRadioButton.Checked = BatchTestRadioButton.Checked ? false : true;

			if (BatchTestRadioButton.Checked)
				{
				TestShotBlanksRadioButton.Checked = false;
				LoadDataTestRadioButton.Checked = false;
				}

			DrawLabelImage(m_BatchList[0], LabelRectangle());

			UpdateButtons();
			}

		//============================================================================*
		// OnLoadDataTestClicked()
		//============================================================================*

		private void OnLoadDataTestClicked(object sender, EventArgs e)
			{
			LoadDataTestRadioButton.Checked = LoadDataTestRadioButton.Checked ? false : true;

			if (LoadDataTestRadioButton.Checked)
				{
				TestShotBlanksRadioButton.Checked = false;
				BatchTestRadioButton.Checked = false;
				}

			DrawLabelImage(m_BatchList[0], LabelRectangle());

			UpdateButtons();
			}

		//============================================================================*
		// OnNumLabelsTextChanged()
		//============================================================================*

		private void OnNumLabelsTextChanged(object sender, EventArgs e)
			{
			m_nNumCopies = NumLabelsTextBox.Value;

			UpdateButtons();
			}

		//============================================================================*
		// OnPageImageClicked()
		//============================================================================*

		private void OnPageImageClicked(object sender, MouseEventArgs e)
			{
			m_nStartLabel = 0;

			switch ((ePaper) PaperComboBox.SelectedIndex)
				{
				//----------------------------------------------------------------------------*
				// Letter, Avery 6464, & Avery 6482
				//----------------------------------------------------------------------------*

				case ePaper.Letter:
				case ePaper.Avery6464:
				case ePaper.Avery6482:
					m_nStartLabel += ((e.Y / (PageImageBox.Height / 3)) * 2);
					m_nStartLabel += (e.X / (PageImageBox.Width / 2));

					break;

				//----------------------------------------------------------------------------*
				// Avery 5444 & 5453
				//----------------------------------------------------------------------------*

				case ePaper.Avery5444:
				case ePaper.Avery5453:
					m_nStartLabel += (e.Y / (PageImageBox.Height / 2));

					break;
				}

			m_DataFiles.Preferences.BatchPrintStartLabel = m_nStartLabel;

			CreatePageImage();
			}

		//============================================================================*
		// OnPaperChanged()
		//============================================================================*

		private void OnPaperChanged(object sender, EventArgs e)
			{
			if (m_fInitialized)
				{
				m_DataFiles.Preferences.BatchPrintPaper = PaperComboBox.SelectedIndex;

				m_nStartLabel = 0;

				m_DataFiles.Preferences.BatchPrintStartLabel = m_nStartLabel;
				}

			if (PaperComboBox.SelectedIndex == (int) ePaper.Avery5444)
				{
				LoadDataTestRadioButton.Checked = false;
				BatchTestRadioButton.Checked = false;
				TestShotBlanksRadioButton.Checked = false;
				}

			CreatePageImage();

			//----------------------------------------------------------------------------*
			// Resize the screen to fit the Label Image
			//----------------------------------------------------------------------------*

			Rectangle LabelRect = LabelRectangle();

			int nWindowWidth = LabelRect.Width;

			if (LabelRect.Width < LabelFormatGroupBox.Width)
				nWindowWidth = LabelFormatGroupBox.Width + 24;
			else
				nWindowWidth = LabelRect.Width + 24;

			LabelImage.Size = LabelRect.Size;

			LabelImage.Location = new Point((ClientSize.Width / 2) - (LabelImage.Size.Width / 2), LabelImage.Location.Y);

			LabelFormatGroupBox.Location = new Point(12, LabelImage.Location.Y + LabelImage.Height + 6);

			BatchPrintButton.Location = new Point(BatchPrintButton.Location.X, LabelFormatGroupBox.Location.Y + LabelFormatGroupBox.Height + 20);
			BatchPrintCancelButton.Location = new Point(BatchPrintCancelButton.Location.X, LabelFormatGroupBox.Location.Y + LabelFormatGroupBox.Height + 20);

			this.ClientSize = new Size(nWindowWidth, BatchPrintButton.Location.Y + BatchPrintButton.Size.Height + 20);

			DrawLabelImage(m_BatchList[0], LabelRect);

			UpdateButtons();
			}

		//============================================================================*
		// OnPrintPage()
		//============================================================================*

		private void OnPrintPage(object sender, PrintPageEventArgs e)
			{
			int nMaxLabels = 6;

			foreach (cBatch Batch in m_BatchList)
				{
				if (Batch.NumPrinted >= m_nNumCopies)
					continue;

				//----------------------------------------------------------------------------*
				// Determine the number of labels to be printed on this page
				//----------------------------------------------------------------------------*

				int nRepeat = 0;

				switch ((ePaper) PaperComboBox.SelectedIndex)
					{
					//----------------------------------------------------------------------------*
					// Letter, Avery 6464, & Avery 6482
					//----------------------------------------------------------------------------*

					case ePaper.Letter:
					case ePaper.Avery6464:
					case ePaper.Avery6482:
						nMaxLabels = 6;

						if (m_nStartLabel > 5)
							{
							m_nStartLabel = 0;
							m_DataFiles.Preferences.BatchPrintStartLabel = m_nStartLabel;
							}

						nRepeat = 6 - m_nStartLabel;

						break;

					//----------------------------------------------------------------------------*
					// Avery 5444 & 5453
					//----------------------------------------------------------------------------*

					case ePaper.Avery5444:
					case ePaper.Avery5453:
						nMaxLabels = 2;

						if (m_nStartLabel > 1)
							{
							m_nStartLabel = 0;
							m_DataFiles.Preferences.BatchPrintStartLabel = m_nStartLabel;
							}

						nRepeat = 2 - m_nStartLabel;

						break;
					}

				if (nRepeat > m_nNumCopies - Batch.NumPrinted)
					nRepeat = m_nNumCopies - Batch.NumPrinted;

				//----------------------------------------------------------------------------*
				// Loop around for each label
				//----------------------------------------------------------------------------*

				Rectangle PrinterBounds = e.PageBounds;

				double dPageWidth = 8.5;
				double dPageHeight = 11.0;

				if (PaperComboBox.SelectedIndex == 1 || PaperComboBox.SelectedIndex == 2)
					{
					dPageWidth = 4.0;
					dPageHeight = 6.0;
					}

				int nXDPI = (int) ((double) PrinterBounds.Width / dPageWidth);
				int nYDPI = (int) ((double) PrinterBounds.Height / dPageHeight);

				PrinterBounds.Width -= (int) (e.PageSettings.HardMarginX * 2.0);
				PrinterBounds.Height -= (int) (e.PageSettings.HardMarginY * 2.0);

				while (nRepeat > 0)
					{
					//----------------------------------------------------------------------------*
					// Determine the rectangle for this label
					//----------------------------------------------------------------------------*

					Rectangle LabelRect = new Rectangle(0, 0, e.PageBounds.Width, e.PageBounds.Height);

					switch ((ePaper) PaperComboBox.SelectedIndex)
						{
						//----------------------------------------------------------------------------*
						// Letter, Avery 6464, & Avery 6482
						//----------------------------------------------------------------------------*

						case ePaper.Letter:
						case ePaper.Avery6464:
						case ePaper.Avery6482:
							if (m_nStartLabel > 5)
								{
								m_nStartLabel = 0;
								m_DataFiles.Preferences.BatchPrintStartLabel = m_nStartLabel;
								}

							LabelRect.X = ((int) ((float) nXDPI * (float) 4.15) * (m_nStartLabel % 2)) + (int) ((float) 0.2 * (float) nXDPI);
							LabelRect.Y = ((int) ((float) nYDPI * (float) 3.375) * (m_nStartLabel / 2)) + (int) ((float) 0.5 * (float) nYDPI);
							LabelRect.Width = (nXDPI * 4) - (int) (e.PageSettings.HardMarginX * 2.0);
							LabelRect.Height = (int) ((float) nYDPI * (float) 3.25) - (int) (e.PageSettings.HardMarginY * 2.0);

							break;

						//----------------------------------------------------------------------------*
						// Avery 5444
						//----------------------------------------------------------------------------*

						case ePaper.Avery5444:
							if (m_nStartLabel > 1)
								{
								m_nStartLabel = 0;
								m_DataFiles.Preferences.BatchPrintStartLabel = m_nStartLabel;
								}

							LabelRect.X = (int) (((float) nXDPI * (float) 0.25) - e.PageSettings.HardMarginX);
							LabelRect.Y = (int) ((float) 0.625 * (float) nYDPI) + ((int) ((float) nYDPI * (float) 2.750) * m_nStartLabel);
							LabelRect.Width = (int) ((float) nXDPI * 3.625) - (int) (e.PageSettings.HardMarginX * 2.0);
							LabelRect.Height = (nYDPI * 2) - (int) e.PageSettings.HardMarginY;

							break;

						//----------------------------------------------------------------------------*
						// Avery 5453
						//----------------------------------------------------------------------------*

						case ePaper.Avery5453:
							if (m_nStartLabel > 1)
								{
								m_nStartLabel = 0;
								m_DataFiles.Preferences.BatchPrintStartLabel = m_nStartLabel;
								}

							LabelRect.X = 0;
							LabelRect.Y = (nYDPI * 3) * m_nStartLabel;
							LabelRect.Width = (int) ((nXDPI * 3.97) - (e.PageSettings.HardMarginX * 2.0));
							LabelRect.Height = (int) ((nYDPI * 2.97) - (e.PageSettings.HardMarginY * 2.0));

							break;
						}

					//----------------------------------------------------------------------------*
					// Draw Border
					//----------------------------------------------------------------------------*

					e.Graphics.DrawRectangle(Pens.Black, LabelRect.X, LabelRect.Y, LabelRect.Width, LabelRect.Height);

					LabelRect.X++;
					LabelRect.Y++;
					LabelRect.Width -= 2;
					LabelRect.Height -= 2;

					DrawLabel(Batch, LabelRect, e.Graphics);

					//----------------------------------------------------------------------------*
					// Decrement copy count
					//----------------------------------------------------------------------------*

					m_nStartLabel++;

					m_DataFiles.Preferences.BatchPrintStartLabel = m_nStartLabel;

					Batch.NumPrinted++;

					nRepeat--;
					}

				if (m_nStartLabel > nMaxLabels - 1)
					break;
				}

			e.HasMorePages = false;

			foreach (cBatch CheckBatch in m_BatchList)
				{
				if (CheckBatch.NumPrinted < m_nNumCopies)
					{
					e.HasMorePages = true;

					break;
					}
				}
			}

		//============================================================================*
		// OnTestShotBlanksClicked()
		//============================================================================*

		private void OnTestShotBlanksClicked(object sender, EventArgs e)
			{
			TestShotBlanksRadioButton.Checked = !TestShotBlanksRadioButton.Checked;

			if (TestShotBlanksRadioButton.Checked)
				{
				BatchTestRadioButton.Checked = false;
				LoadDataTestRadioButton.Checked = false;
				}

			DrawLabelImage(m_BatchList[0], LabelRectangle());

			UpdateButtons();
			}

		//============================================================================*
		// PrintButtonClicked()
		//============================================================================*

		private void PrintButtonClicked(object sender, EventArgs e)
			{
			PrintDialog PrintDialog = new PrintDialog();

			PrintDialog.Document = m_PrintDocument;

			PrintDialog.AllowPrintToFile = false;
			PrintDialog.AllowSomePages = false;
			PrintDialog.AllowCurrentPage = false;
			PrintDialog.AllowSelection = false;

			if (PrintDialog.ShowDialog() == DialogResult.OK)
				{
				m_nNumCopies = NumLabelsTextBox.Value;

				if (m_nNumCopies <= 0)
					{
					MessageBox.Show("Invalid Number of Labels Entered", "Input Data Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

					return;
					}

				foreach (cBatch Batch in m_BatchList)
					Batch.NumPrinted = 0;

				m_PrintDocument.Print();

				CreatePageImage();
				}
			}

		//============================================================================*
		// UpdateButtons()
		//============================================================================*

		private void UpdateButtons()
			{
			if (!m_fInitialized)
				return;

			//----------------------------------------------------------------------------*
			// Num Labels
			//----------------------------------------------------------------------------*

			if (!NumLabelsTextBox.ValueOK)
				{
				BatchPrintButton.Enabled = false;
				}
			else
				{
				BatchPrintButton.Enabled = true;
				}

			//----------------------------------------------------------------------------*
			// Avery 5444 Paper?
			//----------------------------------------------------------------------------*

			if (PaperComboBox.SelectedIndex == (int) ePaper.Avery5444)
				{
				TestShotBlanksRadioButton.Enabled = false;
				TestShotBlanksRadioButton.Checked = false;
				LoadDataTestRadioButton.Enabled = false;
				LoadDataTestRadioButton.Checked = false;
				BatchTestRadioButton.Enabled = false;
				BatchTestRadioButton.Checked = false;
				}
			else
				{
				TestShotBlanksRadioButton.Enabled = true;
				LoadDataTestRadioButton.Enabled = true;
				BatchTestRadioButton.Enabled = true;
				}

			//----------------------------------------------------------------------------*
			// Load Test Data
			//----------------------------------------------------------------------------*

			bool fOK = false;

			if (PaperComboBox.SelectedIndex != (int) ePaper.Avery5444)
				{
				foreach (cBatch Batch in m_BatchList)
					{
					foreach (cCharge CheckCharge in Batch.Load.ChargeList)
						{
						if (CheckCharge.PowderWeight == Batch.PowderWeight)
							{
							if (CheckCharge.TestList.Count > 0)
								fOK = true;

							break;
							}
						}
					}
				}

			LoadDataTestRadioButton.Enabled = fOK;

			//----------------------------------------------------------------------------*
			// Batch Test Data
			//----------------------------------------------------------------------------*

			if (PaperComboBox.SelectedIndex != (int) ePaper.Avery5444)
				{
				bool fBatchTestFound = false;

				foreach (cBatch Batch in m_BatchList)
					{
					if (Batch.BatchTest != null)
						{
						fBatchTestFound = true;

						break;
						}
					}

				BatchTestRadioButton.Enabled = fBatchTestFound;
				}
			else
				BatchTestRadioButton.Enabled = false;
			}
		}
	}
