//============================================================================*
// cFactoryAmmoPrintForm.cs
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

using ReloadersWorkShop.Controls;
using ReloadersWorkShop.Preferences;

//============================================================================*
// NameSpace
//============================================================================*

namespace ReloadersWorkShop
	{
	//============================================================================*
	// cBatchForm Class
	//============================================================================*

	public partial class cAmmoPrintForm : Form
		{
		//----------------------------------------------------------------------------*
		// Private Data Members
		//----------------------------------------------------------------------------*

		private bool m_fInitialized = false;

		private cAmmo m_Ammo = null;

		private cDataFiles m_DataFiles = null;

		private PrintDocument m_PrintDocument = new PrintDocument();

		private int m_nStartLabel = 0;
		private int m_nNumCopies = 0;

		//============================================================================*
		// cFactoryAmmoPrintForm() - Constructor
		//============================================================================*

		public cAmmoPrintForm(cAmmo FactoryAmmo, cDataFiles DataFiles)
			{
			InitializeComponent();

			m_Ammo = FactoryAmmo;
			m_DataFiles = DataFiles;

			//----------------------------------------------------------------------------*
			// Event Handlers
			//----------------------------------------------------------------------------*

			NumLabelsTextBox.TextChanged += OnNumLabelsTextChanged;

			PrintButton.Click += PrintButtonClicked;
			PaperComboBox.SelectedIndexChanged += OnPaperChanged;
			PageImageBox.MouseClick += OnPageImageClicked;
			m_PrintDocument.PrintPage += OnPrintPage;

			TestShotBlanksRadioButton.Click += OnTestShotBlanksClicked;
			TestDataRadioButton.Click += OnTestDataClicked;

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

			TestDataRadioButton.Checked = false;

			SetClientSizeCore(LabelFormatGroup.Location.X + LabelFormatGroup.Width + 10, CancelPrintButton.Location.Y + CancelPrintButton.Height + 20);

			//----------------------------------------------------------------------------*
			// Create Page Image
			//----------------------------------------------------------------------------*

			CreatePageImage();

			m_fInitialized = true;

			UpdateButtons();

			DrawLabelImage(LabelRectangle());

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

			switch (PaperComboBox.SelectedIndex)
				{
				//----------------------------------------------------------------------------*
				// 8.5 x 11 Letter
				//----------------------------------------------------------------------------*

				case 0:
				case 3:
					Graphics.DrawLine(Pens.Black, PageSize.Width / 2, 0, PageSize.Width / 2, PageSize.Height);

					for (int i = 0; i < PageSize.Height / 3; i++)
						Graphics.DrawLine(Pens.Black, 0, (i + 1) * PageSize.Height / 3, PageSize.Width, (i + 1) * PageSize.Height / 3);

					break;

				//----------------------------------------------------------------------------*
				// Avery 5444 & 5453
				//----------------------------------------------------------------------------*

				case 1:
				case 2:
					Graphics.DrawLine(Pens.Black, 0, PageSize.Height / 2, PageSize.Width, PageSize.Height / 2);

					break;
				}

			//----------------------------------------------------------------------------*
			// Fill i the label numbers and fill in the startng label with gray
			//----------------------------------------------------------------------------*

			Rectangle LabelRect = new Rectangle(0, 0, 0, 0);

			Font LabelFont = new Font("Trebuchet MS", (float)8.0, FontStyle.Regular);

			for (int nLabelNum = 0; nLabelNum < 6; nLabelNum++)
				{
				switch (PaperComboBox.SelectedIndex)
					{
					//----------------------------------------------------------------------------*
					// 8.5 x 11 Letter
					//----------------------------------------------------------------------------*

					case 0:
					case 3:
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

						float dX = LabelRect.X + (float)((float)LabelRect.Width / 2.0) - ((float)NumSize.Width / (float)2.0);
						float dY = LabelRect.Y + (float)((float)LabelRect.Height / 2.0) - ((float)NumSize.Height / (float)2.0);

						Graphics.DrawString(strNum, LabelFont, Brushes.Black, dX, dY);

						break;

					//----------------------------------------------------------------------------*
					// Avery 5444 & 5453
					//----------------------------------------------------------------------------*

					case 1:
					case 2:
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
						// Fill nthe rectangle if this is the starting label
						//----------------------------------------------------------------------------*

						if (nLabelNum == m_nStartLabel)
							Graphics.FillRectangle(Brushes.LightGray, LabelRect);

						//----------------------------------------------------------------------------*
						// Draw the label number
						//----------------------------------------------------------------------------*

						strNum = String.Format("{0:G0}", nLabelNum + 1);

						NumSize = Graphics.MeasureString(strNum, LabelFont);

						dX = LabelRect.X + (float)((float)LabelRect.Width / 2.0) - ((float)NumSize.Width / (float)2.0);
						dY = LabelRect.Y + (float)((float)LabelRect.Height / 2.0) - ((float)NumSize.Height / (float)2.0);

						Graphics.DrawString(strNum, LabelFont, Brushes.Black, dX, dY);

						break;
					}
				}

			PageImageBox.Image = PageImage;
			}

		//============================================================================*
		// DrawLabel()
		//============================================================================*

		private void DrawLabel(Rectangle LabelRect, Graphics Graphics)
			{
			cCaliber.CurrentFirearmType = m_Ammo.FirearmType;

			//----------------------------------------------------------------------------*
			// Print the label header
			//----------------------------------------------------------------------------*

			Font LabelHeaderFont = new Font("Trebuchet MS", (float)10.0, FontStyle.Bold);
			Font LabelFont = new Font("Trebuchet MS", (float)8.0, FontStyle.Regular);
			Font LabelUnderlineFont = new Font("Trebuchet MS", (float)8.0, FontStyle.Underline);
			Font LabelBoldFont = new Font("Trebuchet MS", (float)8.0, FontStyle.Bold);

			// Don't fill in a colored header for Avery 6482 since it's a colored paper

			if (PaperComboBox.SelectedIndex != 3)
				Graphics.FillRectangle(Brushes.LightBlue, LabelRect.X, LabelRect.Y, LabelRect.Width, (int)((double)LabelHeaderFont.Height * 4.5));

			Graphics.DrawLine(Pens.Black, LabelRect.X, LabelRect.Y + (int)((double)LabelHeaderFont.Height * 4.5) + 1, LabelRect.X + LabelRect.Width, LabelRect.Y + (int)((double)LabelHeaderFont.Height * 4.5) + 1);

			float dX = LabelRect.X;
			float dY = LabelRect.Y;

			// Manufacturer and Type

			Graphics.DrawString(String.Format("{0}", m_Ammo.ToShortString()), LabelHeaderFont, Brushes.Black, dX, dY);

			dY += ((float)LabelHeaderFont.Height * (float)2.0);

			// Caliber

			Graphics.DrawString(String.Format("{0}", m_Ammo.Caliber.ToString()), LabelHeaderFont, Brushes.Black, dX, dY);

			dY = LabelRect.Y + (float)(LabelHeaderFont.Height * 5.0);

			//----------------------------------------------------------------------------*
			// Print Ammo Data
			//----------------------------------------------------------------------------*

			// Bullet Weight

			SizeF LabelSize = Graphics.MeasureString("Ballistic Coefficient: ", LabelFont);

			dX += (int)LabelSize.Width;

			float dDataX = dX + 10;

			LabelSize = Graphics.MeasureString("Bullet Weight: ", LabelFont);

			dX = dDataX - LabelSize.Width;

			Graphics.DrawString("Bullet Weight:", LabelFont, Brushes.Black, dX, dY);

			SizeF BoldSize = Graphics.MeasureString("Bullet Weight: ", LabelBoldFont);

			dY -= (int)(BoldSize.Height - LabelSize.Height);

			string strString = String.Format("{0:G0} {1}", cDataFiles.StandardToMetric(m_Ammo.BulletWeight, cDataFiles.eDataType.BulletWeight), cDataFiles.MetricString(cDataFiles.eDataType.BulletWeight));

			Graphics.DrawString(strString, LabelBoldFont, Brushes.Black, dDataX, dY);

			BoldSize = Graphics.MeasureString(strString, LabelBoldFont);

			float dDiameterX = dDataX + BoldSize.Width + 15;

			// Bullet Diameter

			strString = "Bullet Diameter: ";

			Graphics.DrawString(strString, LabelFont, Brushes.Black, dDiameterX, dY);

			BoldSize = Graphics.MeasureString(strString, LabelBoldFont);

			dX = dDiameterX + BoldSize.Width;

			dY -= (int)(BoldSize.Height - LabelSize.Height);

			strString = String.Format("{0:F3} {1}", cDataFiles.StandardToMetric(m_Ammo.BulletDiameter, cDataFiles.eDataType.Dimension), cDataFiles.MetricString(cDataFiles.eDataType.Dimension));

			Graphics.DrawString(strString, LabelBoldFont, Brushes.Black, dX, dY);

			dX = LabelRect.X;

			dY += LabelBoldFont.Height;

			// Ballistic Coefficient

			LabelSize = Graphics.MeasureString("Ballistic Coefficient: ", LabelFont);

			dX = dDataX - LabelSize.Width;

			Graphics.DrawString("Ballistic Coefficient:", LabelFont, Brushes.Black, dX, dY);

			BoldSize = Graphics.MeasureString("Ballistic Coefficient: ", LabelBoldFont);

			dY -= (int)(BoldSize.Height - LabelSize.Height);

			Graphics.DrawString(String.Format("{0:F3}", m_Ammo.BallisticCoefficient), LabelBoldFont, Brushes.Black, dDataX, dY);

			dY += (float)(LabelBoldFont.Height * 1.5);

			//----------------------------------------------------------------------------*
			// Test Shot Blanks
			//----------------------------------------------------------------------------*

			if (TestShotBlanksRadioButton.Checked)
				{
				dX = LabelRect.X;

				Graphics.DrawString("Test Shots (Muzzle Vel.)", LabelBoldFont, Brushes.Black, dX, dY);

				string strBlank = "____________";

				strString = "Best Group: " + strBlank;

				BoldSize = Graphics.MeasureString(strString, LabelBoldFont);

				dX = LabelRect.X + LabelRect.Width - LabelSize.Width - 10;

				Graphics.DrawString(strString, LabelBoldFont, Brushes.Black, dX, dY);

				dX = LabelRect.X;
				dY += ((float)LabelBoldFont.Height * (float)1.5);

				float dTestShotTop = dY;
				int nShotNum = 1;

				strString = String.Format("{0:G0} {1}  ", nShotNum, strBlank);

				SizeF StringSize = Graphics.MeasureString(strString, LabelFont);

				while (dX + StringSize.Width < LabelRect.X + LabelRect.Width)
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

					dY += ((float)LabelFont.Height * (float)1.5);
					}
				}

			//----------------------------------------------------------------------------*
			// Ammo Test Data
			//----------------------------------------------------------------------------*

			if (TestDataRadioButton.Checked)
				{
				dX = LabelRect.X;

				strString = "Test Data";

				Graphics.DrawString(strString, LabelBoldFont, Brushes.Black, dX, dY);

				dY += (float)(LabelBoldFont.Height * 1.25);

				//----------------------------------------------------------------------------*
				// Loop through the tests
				//----------------------------------------------------------------------------*

				foreach (cAmmoTest AmmoTest in m_Ammo.TestList)
					{
					cTestStatistics Statistics = AmmoTest.TestShotList.GetStatistics(AmmoTest.NumRounds);

					dX = LabelRect.X;

					// Test Date

					strString = "Date: ";

					Graphics.DrawString(strString, LabelFont, Brushes.Black, dX, dY);

					LabelSize = Graphics.MeasureString(strString, LabelFont);
					BoldSize = Graphics.MeasureString(strString, LabelBoldFont);

					dX += LabelSize.Width;
					dY -= (BoldSize.Height - LabelSize.Height);

					strString = String.Format("{0}   ", AmmoTest.TestDate.ToShortDateString());

					Graphics.DrawString(strString, LabelBoldFont, Brushes.Black, dX, dY);

					BoldSize = Graphics.MeasureString(strString, LabelBoldFont);

					dX += BoldSize.Width;

					float dDataHeaderX = dX;

					dY += (BoldSize.Height - LabelSize.Height);

					// Firearm

					strString = "Muzzel Vel.: ";

					LabelSize = Graphics.MeasureString(strString, LabelFont);

					dDataX = dX + LabelSize.Width;

					strString = "Firearm: ";

					LabelSize = Graphics.MeasureString(strString, LabelFont);

					Graphics.DrawString(strString, LabelFont, Brushes.Black, dDataX - LabelSize.Width, dY);

					LabelSize = Graphics.MeasureString(strString, LabelFont);
					BoldSize = Graphics.MeasureString(strString, LabelBoldFont);

					dX = dDataX;

					dY -= (BoldSize.Height - LabelSize.Height);

					strString = String.Format("{0}", AmmoTest.Firearm != null ? AmmoTest.Firearm.ToString() : "Factory");

					Graphics.DrawString(strString, LabelBoldFont, Brushes.Black, dX, dY);

					BoldSize = Graphics.MeasureString(strString, LabelBoldFont);

					dX += BoldSize.Width;
					dY += BoldSize.Height;

					// Muzzle Velocity

					strString = "Muzzle Vel.: ";

					LabelSize = Graphics.MeasureString(strString, LabelFont);

					dX = dDataX - LabelSize.Width;

					Graphics.DrawString(strString, LabelFont, Brushes.Black, dX, dY);

					BoldSize = Graphics.MeasureString(strString, LabelBoldFont);

					dX += LabelSize.Width;
					dY -= (BoldSize.Height - LabelSize.Height);

					strString = String.Format("{0:F0} {1}", AmmoTest.Firearm != null ? cDataFiles.StandardToMetric(Statistics.AverageVelocity, cDataFiles.eDataType.Velocity) : cDataFiles.StandardToMetric(AmmoTest.MuzzleVelocity, cDataFiles.eDataType.Velocity), cDataFiles.MetricString(cDataFiles.eDataType.Velocity));

					Graphics.DrawString(strString, LabelBoldFont, Brushes.Black, dX, dY);

					BoldSize = Graphics.MeasureString(strString, LabelBoldFont);

					dY += (BoldSize.Height * (float) 1.25);

					if (dY > LabelRect.Y + LabelRect.Height)
						break;
					}
				}
			}

		//============================================================================*
		// DrawLabelImage()
		//============================================================================*

		private void DrawLabelImage(Rectangle LabelRect)
			{
			Bitmap PageImage = new Bitmap(LabelRect.Width, LabelRect.Height);

			Graphics Graphics = Graphics.FromImage(PageImage);

			Graphics.FillRectangle(Brushes.White, LabelRect);

			DrawLabel(LabelRect, Graphics);

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

			switch (PaperComboBox.SelectedIndex)
				{
				//----------------------------------------------------------------------------*
				// 8.5 x 11 Letter & Avery 6482
				//----------------------------------------------------------------------------*

				case 0:
				case 3:
					LabelRect.Width = (int)(Graphics.DpiX * 4.0);
					LabelRect.Height = (int)(Graphics.DpiY * (float)3.25);

					break;

				//----------------------------------------------------------------------------*
				// Avery 5444
				//----------------------------------------------------------------------------*

				case 1:
					LabelRect.Width = (int)(Graphics.DpiX * 3.625);
					LabelRect.Height = (int)(Graphics.DpiY * 2.0);

					break;

				//----------------------------------------------------------------------------*
				// Avery 5453
				//----------------------------------------------------------------------------*

				case 2:
					LabelRect.Width = (int)(Graphics.DpiX * 4.0);
					LabelRect.Height = (int)(Graphics.DpiY * 3.0);

					break;
				}

			return (LabelRect);
			}

		//============================================================================*
		// OnTestDataClicked()
		//============================================================================*

		private void OnTestDataClicked(object sender, EventArgs e)
			{
			TestDataRadioButton.Checked = TestDataRadioButton.Checked ? false : true;

			if (TestDataRadioButton.Checked)
				TestShotBlanksRadioButton.Checked = false;

			DrawLabelImage(LabelRectangle());

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

			switch (PaperComboBox.SelectedIndex)
				{
				//----------------------------------------------------------------------------*
				// 8.5 x 11 Letter
				//----------------------------------------------------------------------------*

				case 0:
				case 3:
					m_nStartLabel += ((e.Y / (PageImageBox.Height / 3)) * 2);
					m_nStartLabel += (e.X / (PageImageBox.Width / 2));

					break;

				//----------------------------------------------------------------------------*
				// Avery 5444 & 5453
				//----------------------------------------------------------------------------*

				case 1:
				case 2:
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

			if (PaperComboBox.SelectedIndex == 1)
				{
				TestDataRadioButton.Checked = false;
				TestShotBlanksRadioButton.Checked = false;
				}

			CreatePageImage();

			//----------------------------------------------------------------------------*
			// Resize the screen to fit the Label Image
			//----------------------------------------------------------------------------*

			Rectangle LabelRect = LabelRectangle();

			int nWindowWidth = LabelRect.Width;

			if (LabelRect.Width < LabelFormatGroup.Width)
				nWindowWidth = LabelFormatGroup.Width + 24;
			else
				nWindowWidth = LabelRect.Width + 24;

			LabelImage.Size = LabelRect.Size;

			LabelImage.Location = new Point((ClientSize.Width / 2) - (LabelImage.Size.Width / 2), LabelImage.Location.Y);

			LabelFormatGroup.Location = new Point(12, LabelImage.Location.Y + LabelImage.Height + 6);

			PrintButton.Location = new Point(PrintButton.Location.X, LabelFormatGroup.Location.Y + LabelFormatGroup.Height + 20);
			CancelPrintButton.Location = new Point(CancelPrintButton.Location.X, LabelFormatGroup.Location.Y + LabelFormatGroup.Height + 20);

			this.ClientSize = new Size(nWindowWidth, PrintButton.Location.Y + PrintButton.Size.Height + 20);

			DrawLabelImage(LabelRect);

			UpdateButtons();
			}

		//============================================================================*
		// OnPrintPage()
		//============================================================================*

		private void OnPrintPage(object sender, PrintPageEventArgs e)
			{
			//----------------------------------------------------------------------------*
			// Determine the number of labels to be printed on this page
			//----------------------------------------------------------------------------*

			int nRepeat = 0;

			switch (PaperComboBox.SelectedIndex)
				{
				//----------------------------------------------------------------------------*
				// 8.5 x 11 Letter & Avery 6482
				//----------------------------------------------------------------------------*

				case 0:
				case 3:
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

				case 1:
				case 2:
					if (m_nStartLabel > 1)
						{
						m_nStartLabel = 0;
						m_DataFiles.Preferences.BatchPrintStartLabel = m_nStartLabel;
						}

					nRepeat = 2 - m_nStartLabel;

					break;
				}

			if (nRepeat > m_nNumCopies)
				nRepeat = m_nNumCopies;

			//----------------------------------------------------------------------------*
			// Loop around for each label
			//----------------------------------------------------------------------------*

			Rectangle PrinterBounds = e.PageBounds;

			int nXDPI = (int)((double)PrinterBounds.Width / 8.5);
			int nYDPI = (int)((double)PrinterBounds.Height / 11);

			PrinterBounds.Width -= (int)(e.PageSettings.HardMarginX * 2.0);
			PrinterBounds.Height -= (int)(e.PageSettings.HardMarginY * 2.0);

			while (nRepeat > 0)
				{
				//----------------------------------------------------------------------------*
				// Determine the rectangle for this label
				//----------------------------------------------------------------------------*

				Rectangle LabelRect = new Rectangle(0, 0, e.PageBounds.Width, e.PageBounds.Height);

				switch (PaperComboBox.SelectedIndex)
					{
					//----------------------------------------------------------------------------*
					// 8.5 x 11 Letter & Avery 6482
					//----------------------------------------------------------------------------*

					case 0:
					case 3:
						if (m_nStartLabel > 5)
							{
							m_nStartLabel = 0;
							m_DataFiles.Preferences.BatchPrintStartLabel = m_nStartLabel;
							}

						LabelRect.X = ((int)((float)nXDPI * (float)4.15) * (m_nStartLabel % 2)) + (int)((float)0.2 * (float)nXDPI);
						LabelRect.Y = ((int)((float)nYDPI * (float)3.375) * (m_nStartLabel / 2)) + (int)((float)0.5 * (float)nYDPI);
						LabelRect.Width = (nXDPI * 4) - (int)(e.PageSettings.HardMarginX * 2.0);
						LabelRect.Height = (int)((float)nYDPI * (float)3.25) - (int)(e.PageSettings.HardMarginY * 2.0);

						break;

					//----------------------------------------------------------------------------*
					// Avery 5444
					//----------------------------------------------------------------------------*

					case 1:
						if (m_nStartLabel > 1)
							{
							m_nStartLabel = 0;
							m_DataFiles.Preferences.BatchPrintStartLabel = m_nStartLabel;
							}

						LabelRect.X = (int)(((float)nXDPI * (float)0.25) - e.PageSettings.HardMarginX);
						LabelRect.Y = (int)((float)0.625 * (float)nYDPI) + ((int)((float)nYDPI * (float)2.750) * m_nStartLabel);
						LabelRect.Width = (int)((float)nXDPI * 3.625) - (int)(e.PageSettings.HardMarginX * 2.0);
						LabelRect.Height = (nYDPI * 2) - (int)e.PageSettings.HardMarginY;

						break;

					//----------------------------------------------------------------------------*
					// Avery 5453
					//----------------------------------------------------------------------------*

					case 2:
						if (m_nStartLabel > 1)
							{
							m_nStartLabel = 0;
							m_DataFiles.Preferences.BatchPrintStartLabel = m_nStartLabel;
							}

						LabelRect.X = 0;
						LabelRect.Y = (nYDPI * 3) * m_nStartLabel;
						LabelRect.Width = (nXDPI * 4) - (int)(e.PageSettings.HardMarginX * 2.0);
						LabelRect.Height = (nYDPI * 3) - (int)(e.PageSettings.HardMarginY * 2.0);

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

				DrawLabel(LabelRect, e.Graphics);

				//----------------------------------------------------------------------------*
				// Decrement copy count
				//----------------------------------------------------------------------------*

				m_nStartLabel++;

				m_DataFiles.Preferences.BatchPrintStartLabel = m_nStartLabel;

				nRepeat--;
				m_nNumCopies--;
				}

			if (m_nNumCopies > 0)
				e.HasMorePages = true;
			else
				e.HasMorePages = false;
			}

		//============================================================================*
		// OnTestShotBlanksClicked()
		//============================================================================*

		private void OnTestShotBlanksClicked(object sender, EventArgs e)
			{
			TestShotBlanksRadioButton.Checked = TestShotBlanksRadioButton.Checked ? false : true;

			if (TestShotBlanksRadioButton.Checked)
				TestDataRadioButton.Checked = false;

			DrawLabelImage(LabelRectangle());

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

				if (!NumLabelsTextBox.ValueOK)
					{
					MessageBox.Show("Invalid Number of Labels Entered", "Input Data Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

					return;
					}

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

			int nNumLabels = NumLabelsTextBox.Value;

			if (!NumLabelsTextBox.ValueOK)
				{
				PrintButton.Enabled = false;
				}
			else
				{
				PrintButton.Enabled = true;
				}

			//----------------------------------------------------------------------------*
			// Test Shot Blank Data
			//----------------------------------------------------------------------------*

			if (PaperComboBox.SelectedIndex != 1)
				{
				TestShotBlanksRadioButton.Enabled = true;
				TestDataRadioButton.Enabled = true;
				}
			else
				{
				TestShotBlanksRadioButton.Enabled = false;
				TestDataRadioButton.Enabled = false;
				}
			}
		}
	}
