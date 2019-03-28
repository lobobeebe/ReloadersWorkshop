//============================================================================*
// cBallisticsPreviewDialog.cs
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

using ReloadersWorkShop.Ballistics;
using ReloadersWorkShop.Preferences;

//============================================================================*
// Namespace
//============================================================================*

namespace ReloadersWorkShop
	{
	//============================================================================*
	// cBallisticsPreviewDialog.cs Class
	//============================================================================*

	public class cBallisticsPreviewDialog : PrintPreviewDialog
		{
		//============================================================================*
		// Private Data Members
		//============================================================================*

		private bool m_fInitialized = false;

		private cDataFiles m_DataFiles = null;

		private ListView m_DropTable = null;

		private cBallistics m_Ballistics = null;

		private Image m_DropChartBitmap = null;
		private Image m_WindDriftChartBitmap = null;

		private cPrintColumn[] m_BallisticsColumns = new cPrintColumn[]
			{
			new cPrintColumn("Range"),
			new cPrintColumn("Drop"),
			new cPrintColumn("Drop"),
			new cPrintColumn("Wind Drift"),
			new cPrintColumn("Wind Drift"),
			new cPrintColumn("Velocity"),
			new cPrintColumn("Energy (ft. lbs)"),
			new cPrintColumn("Time (sec)"),
			new cPrintColumn("Turret Clicks")
			};

		//============================================================================*
		// cBallisticsPreviewDialog.cs() - Constructor
		//============================================================================*

		public cBallisticsPreviewDialog(cDataFiles DataFiles, ListView DropTable, cBallistics Ballistics, Image DropChartBitmap, Image WindDriftChartBitmap)
			{
			m_DataFiles = DataFiles;
			m_DropTable = DropTable;
			m_Ballistics = Ballistics;
			m_DropChartBitmap = DropChartBitmap;
			m_WindDriftChartBitmap = WindDriftChartBitmap;

			if (m_DataFiles.Preferences.BallisticsPreviewMaximized)
				{
				WindowState = FormWindowState.Maximized;
				}
			else
				{
				Location = m_DataFiles.Preferences.BallisticsPreviewLocation;
				ClientSize = m_DataFiles.Preferences.BallisticsPreviewSize;
				}

			Text = String.Format("{0} Ballistics Table - Print Preview", Application.ProductName);

			PrintDocument BallisticsDocument = new PrintDocument();
			BallisticsDocument.PrintPage += OnPrintPage;

			Document = BallisticsDocument;

			UseAntiAlias = true;

			//----------------------------------------------------------------------------*
			// Set header names
			//----------------------------------------------------------------------------*

			for (int i = 0; i < DropTable.Columns.Count - 2; i++)
				m_BallisticsColumns[i].Name = DropTable.Columns[i].Text;

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

			m_DataFiles.Preferences.BallisticsPreviewLocation = Location;
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
			Font SectionFont = new Font("Trebuchet MS", 12, FontStyle.Bold);
			Font HeaderFont = new Font("Trebuchet MS", 8, FontStyle.Bold);
			Font DataFont = new Font("Trebuchet MS", 8, FontStyle.Regular);

			//----------------------------------------------------------------------------*
			// Calculate Column Header Name Widths
			//----------------------------------------------------------------------------*

			string strText;
			SizeF TextSize = new SizeF();

			foreach (cPrintColumn PrintColumn in m_BallisticsColumns)
				{
				TextSize = e.Graphics.MeasureString(PrintColumn.Name, HeaderFont);

				if (TextSize.Width > PrintColumn.Width)
					PrintColumn.Width = TextSize.Width;
				}

			//----------------------------------------------------------------------------*
			// Calculate Header Widths by Data
			//----------------------------------------------------------------------------*

			ListViewItem FirstItem = m_DropTable.Items[0];

			for (int i = 0; i < FirstItem.SubItems.Count - 2; i++)
				{
				TextSize = e.Graphics.MeasureString(FirstItem.SubItems[i].Text, DataFont);

				if (TextSize.Width > m_BallisticsColumns[i].Width)
					m_BallisticsColumns[i].Width = TextSize.Width;
				}

			//----------------------------------------------------------------------------*
			// Initialize the page info
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

			string strDimensionFormat = "{0:F";
			strDimensionFormat += String.Format("{0:G0}", m_DataFiles.Preferences.DimensionDecimals);
			strDimensionFormat += "} ";
			strDimensionFormat += cDataFiles.MetricString(cDataFiles.eDataType.Dimension);

			string strFirearmFormat = "{0:F";
			strFirearmFormat += String.Format("{0:G0}", m_DataFiles.Preferences.FirearmDecimals);
			strFirearmFormat += "} ";
			strFirearmFormat += cDataFiles.MetricString(cDataFiles.eDataType.Firearm);

			string strBulletWeightFormat = "{0:F";
			strBulletWeightFormat += String.Format("{0:G0}", m_DataFiles.Preferences.BulletWeightDecimals);
			strBulletWeightFormat += "} ";
			strBulletWeightFormat += cDataFiles.MetricString(cDataFiles.eDataType.BulletWeight);

			//----------------------------------------------------------------------------*
			// Draw the page header
			//----------------------------------------------------------------------------*

			nY = cPrintObject.PrintReportTitle("Ballistics Table", e, PageRect);

			//----------------------------------------------------------------------------*
			// Draw the input data section header if needed
			//----------------------------------------------------------------------------*

			nX = PageRect.Left;

			TextSize = e.Graphics.MeasureString("Input Data", SectionFont);

			e.Graphics.DrawString("Input Data", SectionFont, Brushes.Black, nX, nY);

			nY += (TextSize.Height * 1.5f);

			nX = PageRect.Left;

			//----------------------------------------------------------------------------*
			// Set up the input data columns
			//----------------------------------------------------------------------------*

			int[] anInputColumns = new int[4];

			TextSize = e.Graphics.MeasureString("Ballistic Coefficient: ", HeaderFont);

			anInputColumns[0] = (int) TextSize.Width;

			TextSize = e.Graphics.MeasureString("Density Altitude: ", HeaderFont);

			anInputColumns[1] = (int) TextSize.Width;

			TextSize = e.Graphics.MeasureString("Barometric Pressure: ", HeaderFont);

			anInputColumns[2] = (int) TextSize.Width;

			TextSize = e.Graphics.MeasureString("Bullet Length: ", HeaderFont);

			anInputColumns[3] = (int) TextSize.Width;

			//----------------------------------------------------------------------------*
			// Draw the input data
			//----------------------------------------------------------------------------*

			nX = PageRect.Left;

			float nInputY = nY;
			float nNextInputX = anInputColumns[0];
			float nInputX = nX + nNextInputX;

			// Ballistic Coefficient

			strText = "Ballistic Coefficient: ";

			TextSize = e.Graphics.MeasureString(strText, HeaderFont);

			e.Graphics.DrawString(strText, HeaderFont, Brushes.Black, nInputX - TextSize.Width, nInputY);

			strText = String.Format("{0:F3}", m_Ballistics.BallisticCoefficient);

			TextSize = e.Graphics.MeasureString(strText, DataFont);

			e.Graphics.DrawString(strText, DataFont, Brushes.Black, nInputX, nInputY);

			if (nInputX + TextSize.Width > nNextInputX)
				nNextInputX = nInputX + TextSize.Width;

			nInputY += (TextSize.Height * 1.5f);

			// Zero Range

			strText = "Zero Range: ";

			TextSize = e.Graphics.MeasureString(strText, HeaderFont);

			e.Graphics.DrawString(strText, HeaderFont, Brushes.Black, nInputX - TextSize.Width, nInputY);

			strText = String.Format("{0:F0} {1}", cDataFiles.StandardToMetric(m_Ballistics.ZeroRange, cDataFiles.eDataType.Range), cDataFiles.MetricString(cDataFiles.eDataType.Range));

			TextSize = e.Graphics.MeasureString(strText, DataFont);

			e.Graphics.DrawString(strText, DataFont, Brushes.Black, nInputX, nInputY);

			if (nInputX + TextSize.Width > nNextInputX)
				nNextInputX = nInputX + TextSize.Width;

			nInputY += (TextSize.Height * 1.5f);

			// Wind Speed

			strText = "Wind Speed: ";

			TextSize = e.Graphics.MeasureString(strText, HeaderFont);

			e.Graphics.DrawString(strText, HeaderFont, Brushes.Black, nInputX - TextSize.Width, nInputY);

			strText = String.Format("{0:G0} {1}", cDataFiles.StandardToMetric(m_Ballistics.WindSpeed, cDataFiles.eDataType.Speed), cDataFiles.MetricString(cDataFiles.eDataType.Speed));

			TextSize = e.Graphics.MeasureString(strText, DataFont);

			e.Graphics.DrawString(strText, DataFont, Brushes.Black, nInputX, nInputY);

			if (nInputX + TextSize.Width > nNextInputX)
				nNextInputX = nInputX + TextSize.Width;

			nInputY += (TextSize.Height * 1.5f);

			// Temperature

			strText = "Temperature: ";

			TextSize = e.Graphics.MeasureString(strText, HeaderFont);

			e.Graphics.DrawString(strText, HeaderFont, Brushes.Black, nInputX - TextSize.Width, nInputY);

			strText = String.Format("{0:G0} {1}", cDataFiles.StandardToMetric(m_Ballistics.Temperature, cDataFiles.eDataType.Temperature), cDataFiles.MetricString(cDataFiles.eDataType.Temperature));

			TextSize = e.Graphics.MeasureString(strText, DataFont);

			e.Graphics.DrawString(strText, DataFont, Brushes.Black, nInputX, nInputY);

			if (nInputX + TextSize.Width > nNextInputX)
				nNextInputX = nInputX + TextSize.Width;

			nInputY += (TextSize.Height * 1.5f);

			// Min Range

			strText = "Min Range: ";

			TextSize = e.Graphics.MeasureString(strText, HeaderFont);

			e.Graphics.DrawString(strText, HeaderFont, Brushes.Black, nInputX - TextSize.Width, nInputY);

			strText = String.Format("{0:G0} {1}", cDataFiles.StandardToMetric(m_Ballistics.MinRange, cDataFiles.eDataType.Range), cDataFiles.MetricString(cDataFiles.eDataType.Range));

			TextSize = e.Graphics.MeasureString(strText, DataFont);

			e.Graphics.DrawString(strText, DataFont, Brushes.Black, nInputX, nInputY);

			if (nInputX + TextSize.Width > nNextInputX)
				nNextInputX = nInputX + TextSize.Width;

			nInputY = nY;
			nInputX = nNextInputX + 20 + anInputColumns[1];

			// Bullet Diameter

			strText = "Bullet Diameter: ";

			TextSize = e.Graphics.MeasureString(strText, HeaderFont);

			e.Graphics.DrawString(strText, HeaderFont, Brushes.Black, nInputX - TextSize.Width, nInputY);

			strText = String.Format(strDimensionFormat, cDataFiles.StandardToMetric(m_Ballistics.BulletDiameter, cDataFiles.eDataType.Dimension));

			TextSize = e.Graphics.MeasureString(strText, DataFont);

			e.Graphics.DrawString(strText, DataFont, Brushes.Black, nInputX, nInputY);

			if (nInputX + TextSize.Width > nNextInputX)
				nNextInputX = nInputX + TextSize.Width;

			nInputY += (TextSize.Height * 1.5f);

			// Sight Height

			strText = "Sight Height: ";

			TextSize = e.Graphics.MeasureString(strText, HeaderFont);

			e.Graphics.DrawString(strText, HeaderFont, Brushes.Black, nInputX - TextSize.Width, nInputY);

			strText = String.Format(strFirearmFormat, cDataFiles.StandardToMetric(m_Ballistics.SightHeight, cDataFiles.eDataType.Firearm));

			TextSize = e.Graphics.MeasureString(strText, DataFont);

			e.Graphics.DrawString(strText, DataFont, Brushes.Black, nInputX, nInputY);

			if (nInputX + TextSize.Width > nNextInputX)
				nNextInputX = nInputX + TextSize.Width;

			nInputY += (TextSize.Height * 1.5f);

			// Wind Direction

			strText = "Wind Direction: ";

			TextSize = e.Graphics.MeasureString(strText, HeaderFont);

			e.Graphics.DrawString(strText, HeaderFont, Brushes.Black, nInputX - TextSize.Width, nInputY);

			strText = String.Format("{0:G0} deg.", m_Ballistics.WindDirection);

			TextSize = e.Graphics.MeasureString(strText, DataFont);

			e.Graphics.DrawString(strText, DataFont, Brushes.Black, nInputX, nInputY);

			if (nInputX + TextSize.Width > nNextInputX)
				nNextInputX = nInputX + TextSize.Width;

			nInputY += (TextSize.Height * 1.5f);

			// Altitude

			strText = m_Ballistics.UseDensityAltitude ? "Density Altitude:" : "Altitude: ";

			TextSize = e.Graphics.MeasureString(strText, HeaderFont);

			e.Graphics.DrawString(strText, HeaderFont, Brushes.Black, nInputX - TextSize.Width, nInputY);

			strText = String.Format("{0:G0} {1}", cDataFiles.StandardToMetric((m_Ballistics.UseDensityAltitude ? m_Ballistics.DensityAltitude : m_Ballistics.Altitude), cDataFiles.eDataType.Altitude), cDataFiles.MetricString(cDataFiles.eDataType.Altitude));

			TextSize = e.Graphics.MeasureString(strText, DataFont);

			e.Graphics.DrawString(strText, DataFont, Brushes.Black, nInputX, nInputY);

			if (nInputX + TextSize.Width > nNextInputX)
				nNextInputX = nInputX + TextSize.Width;

			nInputY += (TextSize.Height * 1.5f);

			// Max Range

			strText = "Max Range:";

			TextSize = e.Graphics.MeasureString(strText, HeaderFont);

			e.Graphics.DrawString(strText, HeaderFont, Brushes.Black, nInputX - TextSize.Width, nInputY);

			strText = String.Format("{0:G0} {1}", cDataFiles.StandardToMetric(m_Ballistics.MaxRange, cDataFiles.eDataType.Range), cDataFiles.MetricString(cDataFiles.eDataType.Range));

			TextSize = e.Graphics.MeasureString(strText, DataFont);

			e.Graphics.DrawString(strText, DataFont, Brushes.Black, nInputX, nInputY);

			if (nInputX + TextSize.Width > nNextInputX)
				nNextInputX = nInputX + TextSize.Width;

			nInputY = nY;
			nInputX = nNextInputX + 20 + anInputColumns[2];

			// Bullet Weight

			strText = "Bullet Weight: ";

			TextSize = e.Graphics.MeasureString(strText, HeaderFont);

			e.Graphics.DrawString(strText, HeaderFont, Brushes.Black, nInputX - TextSize.Width, nInputY);

			strText = String.Format(strBulletWeightFormat, cDataFiles.StandardToMetric(m_Ballistics.BulletWeight, cDataFiles.eDataType.BulletWeight));

			TextSize = e.Graphics.MeasureString(strText, DataFont);

			e.Graphics.DrawString(strText, DataFont, Brushes.Black, nInputX, nInputY);

			if (nInputX + TextSize.Width > nNextInputX)
				nNextInputX = nInputX + TextSize.Width;

			nInputY += (TextSize.Height * 1.5f);

			// Turret Click Inc

			strText = "Turret Click Inc.: ";

			TextSize = e.Graphics.MeasureString(strText, HeaderFont);

			e.Graphics.DrawString(strText, HeaderFont, Brushes.Black, nInputX - TextSize.Width, nInputY);

			strText = String.Format("{0:F3} {1}", m_Ballistics.ScopeClick, m_Ballistics.TurretType == cFirearm.eTurretType.MOA ? "MOA" : "Mils");

			TextSize = e.Graphics.MeasureString(strText, DataFont);

			e.Graphics.DrawString(strText, DataFont, Brushes.Black, nInputX, nInputY);

			if (nInputX + TextSize.Width > nNextInputX)
				nNextInputX = nInputX + TextSize.Width;

			nInputY += (TextSize.Height * 1.5f);

			// Headwind

			strText = "Headwind: ";

			TextSize = e.Graphics.MeasureString(strText, HeaderFont);

			e.Graphics.DrawString(strText, HeaderFont, Brushes.Black, nInputX - TextSize.Width, nInputY);

			strText = String.Format("{0:F0} {1}", cDataFiles.StandardToMetric(m_Ballistics.HeadWind, cDataFiles.eDataType.Speed), cDataFiles.MetricString(cDataFiles.eDataType.Speed));

			TextSize = e.Graphics.MeasureString(strText, DataFont);

			e.Graphics.DrawString(strText, DataFont, Brushes.Black, nInputX, nInputY);

			if (nInputX + TextSize.Width > nNextInputX)
				nNextInputX = nInputX + TextSize.Width;

			nInputY += (TextSize.Height * 1.5f);

			// Barometric Pressure

			strText = "Barometric Pressure:";

			TextSize = e.Graphics.MeasureString(strText, HeaderFont);

			e.Graphics.DrawString(strText, HeaderFont, Brushes.Black, nInputX - TextSize.Width, nInputY);

			strText = String.Format("{0:F2} {1}", cDataFiles.StandardToMetric(m_Ballistics.Pressure, cDataFiles.eDataType.Pressure), cDataFiles.MetricString(cDataFiles.eDataType.Pressure));

			TextSize = e.Graphics.MeasureString(strText, DataFont);

			e.Graphics.DrawString(strText, DataFont, Brushes.Black, nInputX, nInputY);

			if (nInputX + TextSize.Width > nNextInputX)
				nNextInputX = nInputX + TextSize.Width;

			nInputY += (TextSize.Height * 1.5f);

			// Increment

			strText = "Increment:";

			TextSize = e.Graphics.MeasureString(strText, HeaderFont);

			e.Graphics.DrawString(strText, HeaderFont, Brushes.Black, nInputX - TextSize.Width, nInputY);

			strText = String.Format("{0:G0} {1}", cDataFiles.StandardToMetric(m_Ballistics.Increment, cDataFiles.eDataType.Range), cDataFiles.MetricString(cDataFiles.eDataType.Range));

			TextSize = e.Graphics.MeasureString(strText, DataFont);

			e.Graphics.DrawString(strText, DataFont, Brushes.Black, nInputX, nInputY);

			if (nInputX + TextSize.Width > nNextInputX)
				nNextInputX = nInputX + TextSize.Width;

			nInputY = nY;
			nInputX = nNextInputX + 20 + anInputColumns[3];

			// Bullet Length

			strText = "Bullet Length: ";

			TextSize = e.Graphics.MeasureString(strText, HeaderFont);

			e.Graphics.DrawString(strText, HeaderFont, Brushes.Black, nInputX - TextSize.Width, nInputY);

			strText = String.Format(strDimensionFormat, cDataFiles.StandardToMetric(m_Ballistics.BulletLength, cDataFiles.eDataType.Dimension));

			TextSize = e.Graphics.MeasureString(strText, DataFont);

			e.Graphics.DrawString(strText, DataFont, Brushes.Black, nInputX, nInputY);

			if (nInputX + TextSize.Width > nNextInputX)
				nNextInputX = nInputX + TextSize.Width;

			nInputY += (TextSize.Height * 1.5f);

			// Twist

			strText = "Twist: ";

			TextSize = e.Graphics.MeasureString(strText, HeaderFont);

			e.Graphics.DrawString(strText, HeaderFont, Brushes.Black, nInputX - TextSize.Width, nInputY);

			strText = String.Format(strFirearmFormat, cDataFiles.StandardToMetric(m_Ballistics.Twist, cDataFiles.eDataType.Firearm));

			TextSize = e.Graphics.MeasureString(strText, DataFont);

			e.Graphics.DrawString(strText, DataFont, Brushes.Black, nInputX, nInputY);

			if (nInputX + TextSize.Width > nNextInputX)
				nNextInputX = nInputX + TextSize.Width;

			nInputY += (TextSize.Height * 1.5f);

			// Crosswind

			strText = "Crosswind: ";

			TextSize = e.Graphics.MeasureString(strText, HeaderFont);

			e.Graphics.DrawString(strText, HeaderFont, Brushes.Black, nInputX - TextSize.Width, nInputY);

			strText = String.Format("{0:F0} {1}", cDataFiles.StandardToMetric(m_Ballistics.CrossWind, cDataFiles.eDataType.Speed), cDataFiles.MetricString(cDataFiles.eDataType.Speed));

			TextSize = e.Graphics.MeasureString(strText, DataFont);

			e.Graphics.DrawString(strText, DataFont, Brushes.Black, nInputX, nInputY);

			if (nInputX + TextSize.Width > nNextInputX)
				nNextInputX = nInputX + TextSize.Width;

			nInputY += (TextSize.Height * 1.5f);

			// Humidity

			strText = "Humidity:";

			TextSize = e.Graphics.MeasureString(strText, HeaderFont);

			e.Graphics.DrawString(strText, HeaderFont, Brushes.Black, nInputX - TextSize.Width, nInputY);

			strText = String.Format("{0:G0}%", m_Ballistics.Humidity * 100.0);

			TextSize = e.Graphics.MeasureString(strText, DataFont);

			e.Graphics.DrawString(strText, DataFont, Brushes.Black, nInputX, nInputY);

			if (nInputX + TextSize.Width > nNextInputX)
				nNextInputX = nInputX + TextSize.Width;

			nInputY += (TextSize.Height * 1.5f);

			// Target Range

			strText = "Target Range:";

			TextSize = e.Graphics.MeasureString(strText, HeaderFont);

			e.Graphics.DrawString(strText, HeaderFont, Brushes.Black, nInputX - TextSize.Width, nInputY);

			strText = String.Format("{0:G0} {1}", cDataFiles.StandardToMetric(m_Ballistics.TargetRange, cDataFiles.eDataType.Range), cDataFiles.MetricString(cDataFiles.eDataType.Range));

			TextSize = e.Graphics.MeasureString(strText, DataFont);

			e.Graphics.DrawString(strText, DataFont, Brushes.Black, nInputX, nInputY);

			if (nInputX + TextSize.Width > nNextInputX)
				nNextInputX = nInputX + TextSize.Width;

			nInputY += TextSize.Height;

			//----------------------------------------------------------------------------*
			// Draw the ballistics table section header
			//----------------------------------------------------------------------------*

			nY = nInputY + TextSize.Height;

			nX = PageRect.Left;

			strText = "Ballistics Table ";

			TextSize = e.Graphics.MeasureString(strText, SectionFont);

			e.Graphics.DrawString(strText, SectionFont, Brushes.Black, nX, nY);

			strText = String.Format("(Muzzle Velocity: {0:G0} {1})", m_Ballistics.MuzzleVelocity, cDataFiles.MetricString(cDataFiles.eDataType.Velocity));

			SizeF TextSize1 = e.Graphics.MeasureString(strText, HeaderFont);

			nX += TextSize.Width;

			e.Graphics.DrawString(strText, HeaderFont, Brushes.Black, nX, nY + (TextSize.Height / 2.0f) - (TextSize1.Height / 2.0f));

			nY += (TextSize.Height * 1.5f);

			nX = PageRect.Left;

			//----------------------------------------------------------------------------*
			// Draw the ballistics table header
			//----------------------------------------------------------------------------*

			nX = PageRect.Left;

			foreach (cPrintColumn PrintColumn in m_BallisticsColumns)
				{
				e.Graphics.DrawString(PrintColumn.Name, HeaderFont, Brushes.Black, nX, nY);

				nX += (PrintColumn.Width + 10);
				}

			TextSize = e.Graphics.MeasureString(m_BallisticsColumns[0].Name, HeaderFont);

			nY += TextSize.Height;

			e.Graphics.DrawLine(Pens.Black, PageRect.Left, nY, nX, nY);

			nX = PageRect.Left;

			//----------------------------------------------------------------------------*
			// Loop through the items
			//----------------------------------------------------------------------------*

			for (int nItem = 0; nItem < m_DropTable.Items.Count; nItem++)
				{
				if (nY > PageRect.Bottom)
					{
					e.HasMorePages = true;

					return;
					}

				//----------------------------------------------------------------------------*
				// Draw the table data
				//----------------------------------------------------------------------------*

				ListViewItem Item = m_DropTable.Items[nItem];

				nX = PageRect.Left;

				for (int i = 0; i < Item.SubItems.Count - 2; i++)
					{
					strText = Item.SubItems[i].Text;

					TextSize = e.Graphics.MeasureString(strText, DataFont);

					e.Graphics.DrawString(strText, DataFont, Brushes.Black, nX + (m_BallisticsColumns[i].Width / 2) - (TextSize.Width / 2), nY);

					nX += (m_BallisticsColumns[i].Width + 10);
					}

				nY += TextSize.Height;
				}

			//----------------------------------------------------------------------------*
			// Draw the Bullet Drop Chart section header
			//----------------------------------------------------------------------------*

			nY += TextSize.Height;

			nX = PageRect.Left;

			TextSize = e.Graphics.MeasureString("Bullet Drop Chart", SectionFont);

			e.Graphics.DrawString("Bullet Drop Chart", SectionFont, Brushes.Black, nX, nY);

			nY += (TextSize.Height * 1.5f);

			e.Graphics.DrawImage(m_DropChartBitmap, nX, nY);

			e.Graphics.DrawRectangle(Pens.Black, nX, nY, (m_DropChartBitmap.Width / m_DropChartBitmap.HorizontalResolution) * 100, (m_DropChartBitmap.Height / m_DropChartBitmap.VerticalResolution) * 100);

			nY += ((m_DropChartBitmap.Height / m_DropChartBitmap.VerticalResolution) * 100) + (TextSize.Height * 1.5f);

			//----------------------------------------------------------------------------*
			// Draw the Wind Drift Chart section header
			//----------------------------------------------------------------------------*

			TextSize = e.Graphics.MeasureString("Wind Drift Chart", SectionFont);

			e.Graphics.DrawString("Wind Drift Chart", SectionFont, Brushes.Black, nX, nY);

			nY += (TextSize.Height * 1.5f);

			e.Graphics.DrawImage(m_WindDriftChartBitmap, nX, nY);

			e.Graphics.DrawRectangle(Pens.Black, nX, nY, (m_DropChartBitmap.Width / m_DropChartBitmap.HorizontalResolution) * 100, (m_DropChartBitmap.Height / m_DropChartBitmap.VerticalResolution) * 100);

			nY += ((m_DropChartBitmap.Height / m_DropChartBitmap.VerticalResolution) * 100) + (TextSize.Height * 1.5f);

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

			m_DataFiles.Preferences.BallisticsPreviewMaximized = WindowState == FormWindowState.Maximized;

			if (!m_DataFiles.Preferences.BallisticsPreviewMaximized)
				{
				m_DataFiles.Preferences.BallisticsPreviewLocation = Location;
				m_DataFiles.Preferences.BallisticsPreviewSize = ClientSize;
				}
			}
		}
	}
