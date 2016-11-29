//============================================================================*
// cCostAnalysisPreviewDialog.cs
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
	// cCostAnalysisPreviewDialog Class
	//============================================================================*

	public class cCostAnalysisPreviewDialog : PrintPreviewDialog
		{
		//============================================================================*
		// Private Data Members
		//============================================================================*

		private bool m_fInitialized = false;

		private cDataFiles m_DataFiles = null;
		private cCostAnalysisParms m_Parms = null;

		private cSupplyList m_SupplyList = null;

		private bool m_fOverviewPrinted = false;

		private cPrintColumn[] m_BulletColumns = new cPrintColumn[]
			{
			new cPrintColumn("Bullet"),
			new cPrintColumn("Purchases"),
			new cPrintColumn("Cost"),
			new cPrintColumn("Adjustments"),
			new cPrintColumn("Used"),
			new cPrintColumn("In Stock"),
			new cPrintColumn("Value")
			};

		private cPrintColumn[] m_PowderColumns = new cPrintColumn[]
			{
			new cPrintColumn("Powder"),
			new cPrintColumn("Purchases"),
			new cPrintColumn("Cost"),
			new cPrintColumn("Adjustments"),
			new cPrintColumn("Used"),
			new cPrintColumn("In Stock"),
			new cPrintColumn("Value")
			};

		private cPrintColumn[] m_PrimerColumns = new cPrintColumn[]
			{
			new cPrintColumn("Primer"),
			new cPrintColumn("Purchases"),
			new cPrintColumn("Cost"),
			new cPrintColumn("Adjustments"),
			new cPrintColumn("Used"),
			new cPrintColumn("In Stock"),
			new cPrintColumn("Value")
			};

		private cPrintColumn[] m_CaseColumns = new cPrintColumn[]
			{
			new cPrintColumn("Case"),
			new cPrintColumn("Purchases"),
			new cPrintColumn("Cost"),
			new cPrintColumn("Adjustments"),
			new cPrintColumn("Used"),
			new cPrintColumn("In Stock"),
			new cPrintColumn("Value")
			};

		private cPrintColumn[] m_AmmoColumns = new cPrintColumn[]
			{
			new cPrintColumn("Ammo"),
			new cPrintColumn("Purchases"),
			new cPrintColumn("Cost"),
			new cPrintColumn("Adjustments"),
			new cPrintColumn("Fired"),
			new cPrintColumn("In Stock"),
			new cPrintColumn("Value")
			};

		//============================================================================*
		// cCostAnalysisPreviewDialog() - Constructor
		//============================================================================*

		public cCostAnalysisPreviewDialog(cDataFiles DataFiles, cCostAnalysisParms Parms)
			{
			m_DataFiles = DataFiles;
			m_Parms = Parms;

			if (m_DataFiles.Preferences.CostAnalysisPreviewMaximized)
				{
				WindowState = FormWindowState.Maximized;
				}
			else
				{
				Location = m_DataFiles.Preferences.CostAnalysisPreviewLocation;
				ClientSize = m_DataFiles.Preferences.CostAnalysisPreviewSize;
				}

			Text = "Reloader's WorkShop Cost Analysis - Print Preview";

			PrintDocument CostAnalysisDocument = new PrintDocument();
			CostAnalysisDocument.PrintPage += OnPrintPage;

			Document = CostAnalysisDocument;

			UseAntiAlias = true;

			//----------------------------------------------------------------------------*
			// Gather the list of supplies
			//----------------------------------------------------------------------------*

			PopulateSupplyList();

			ResetPrintedFlag();

			m_fInitialized = true;
			}

		//============================================================================*
		// DrawOverview()
		//============================================================================*

		private float DrawOverview(float nStartY, Rectangle PageRect, PrintPageEventArgs e)
			{
			float nY = 0;

			int nX = e.MarginBounds.Left;

			if (m_fOverviewPrinted || !m_Parms.Overview)
				return (nY);

			Font HeaderFont = new Font("Trebuchet MS", 14, FontStyle.Bold);
			Font TypeFont = new Font("Trebuchet MS", 8, FontStyle.Bold);
			Font DataFont = new Font("Trebuchet MS", 8, FontStyle.Regular);

			string strText = "Inventory Activity Overview";

			SizeF TextSize = e.Graphics.MeasureString(strText, HeaderFont);

			nY += (TextSize.Height * (float)0.5);

			e.Graphics.DrawString(strText, HeaderFont, Brushes.Black, e.MarginBounds.Left + (e.MarginBounds.Width / 2) - (TextSize.Width / 2), nY + nStartY);

			nY += (TextSize.Height * (float)1.5);

			//----------------------------------------------------------------------------*
			// Create the Supply Total  Objects
			//----------------------------------------------------------------------------*

			cCostAnalysisSupplyTotals BulletTotals = new cCostAnalysisSupplyTotals();
			cCostAnalysisSupplyTotals CaseTotals = new cCostAnalysisSupplyTotals();
			cCostAnalysisSupplyTotals PowderTotals = new cCostAnalysisSupplyTotals();
			cCostAnalysisSupplyTotals PrimerTotals = new cCostAnalysisSupplyTotals();
			cCostAnalysisSupplyTotals AmmoTotals = new cCostAnalysisSupplyTotals();
			cCostAnalysisSupplyTotals ReloadTotals = new cCostAnalysisSupplyTotals();

			//----------------------------------------------------------------------------*
			// Loop through the supplies
			//----------------------------------------------------------------------------*

			foreach (cSupply CheckSupply in m_SupplyList)
				{
				cCostAnalysisSupplyTotals SupplyTotals = m_Parms.SupplyTotals(CheckSupply);

				if (SupplyTotals == null)
					continue;

				//----------------------------------------------------------------------------*
				// Determine the Supply Type
				//----------------------------------------------------------------------------*

				switch (CheckSupply.SupplyType)
					{
					//----------------------------------------------------------------------------*
					// Ammo
					//----------------------------------------------------------------------------*

					case cSupply.eSupplyTypes.Ammo:
						if (CheckSupply.Manufacturer.Name == "Batch Editor")
							ReloadTotals += SupplyTotals;
						else
							AmmoTotals += SupplyTotals;

						break;

					//----------------------------------------------------------------------------*
					// Bullets
					//----------------------------------------------------------------------------*

					case cSupply.eSupplyTypes.Bullets:
						BulletTotals += SupplyTotals;

						break;

					//----------------------------------------------------------------------------*
					// Cases
					//----------------------------------------------------------------------------*

					case cSupply.eSupplyTypes.Cases:
						CaseTotals += SupplyTotals;

						break;

					//----------------------------------------------------------------------------*
					// Powder
					//----------------------------------------------------------------------------*

					case cSupply.eSupplyTypes.Powder:
						PowderTotals += SupplyTotals;

						break;

					//----------------------------------------------------------------------------*
					// Primer
					//----------------------------------------------------------------------------*

					case cSupply.eSupplyTypes.Primers:
						PrimerTotals += SupplyTotals;

						break;
					}
				}

			//----------------------------------------------------------------------------*
			// Initialize column positions
			//----------------------------------------------------------------------------*

			float nCurrentY = nY;
			float nNextTotalsY = nY;
			nX = e.MarginBounds.Left;

			//----------------------------------------------------------------------------*
			// Bullet Totals
			//----------------------------------------------------------------------------*

			if (m_Parms.Bullets && BulletTotals.NumTransactions > 0)
				{
				strText = "Bullets";

				TextSize = e.Graphics.MeasureString(strText, TypeFont);

				e.Graphics.DrawString(strText, TypeFont, Brushes.Black, nX, nY + nStartY);

				nY += (TextSize.Height * (float)1.5);

				//----------------------------------------------------------------------------*
				// Number of activities
				//----------------------------------------------------------------------------*

				strText = String.Format("{0:G0} activit{1} found matching the search criteria.", BulletTotals.NumTransactions, BulletTotals.NumTransactions != 1 ? "ies" : "y");

				TextSize = e.Graphics.MeasureString(strText, DataFont);

				e.Graphics.DrawString(strText, DataFont, Brushes.Black, nX, nY + nStartY);

				nY += (TextSize.Height * (float)1.5);

				//----------------------------------------------------------------------------*
				// Initial Stock
				//----------------------------------------------------------------------------*

				if (BulletTotals.NumInitialStock > 0)
					{
					strText = String.Format("{0:G0} {1} in initial stock with a value of {2}{3:F2}.", BulletTotals.InitialStockQty, BulletTotals.InitialStockQty == 1 ? "was" : "were", m_DataFiles.Preferences.Currency, BulletTotals.InitialStockTotal);

					TextSize = e.Graphics.MeasureString(strText, DataFont);

					e.Graphics.DrawString(strText, DataFont, Brushes.Black, nX, nY + nStartY);

					nY += TextSize.Height;
					}

				//----------------------------------------------------------------------------*
				// Purchases
				//----------------------------------------------------------------------------*

				if (BulletTotals.NumPurchases > 0)
					{
					strText = String.Format("{0:G0} purchase{1} totaling {2:F0} bullets at a cost of {3}{4:F2}.", BulletTotals.NumPurchases, BulletTotals.NumPurchases != 1 ? "s" : "", BulletTotals.PurchaseQty, m_DataFiles.Preferences.Currency, BulletTotals.PurchaseTotal);

					TextSize = e.Graphics.MeasureString(strText, DataFont);

					e.Graphics.DrawString(strText, DataFont, Brushes.Black, nX, nY + nStartY);

					nY += TextSize.Height;
					}

				//----------------------------------------------------------------------------*
				// Adjustments
				//----------------------------------------------------------------------------*

				if (BulletTotals.NumAdjustments > 0)
					{
					strText = String.Format("{0} adjustment{1} ", BulletTotals.NumAdjustments, BulletTotals.NumAdjustments != 1 ? "s" : "");

					if (BulletTotals.AdjustmentsQty < 0.0)
						strText += String.Format("with a net loss of {0:F0} bullets at a cost of {1}{2:F2}.", Math.Abs(BulletTotals.AdjustmentsQty), m_DataFiles.Preferences.Currency, Math.Abs(BulletTotals.AdjustmentsTotal));
					else
						strText += String.Format("with a net gain of {0:F0} bullets valued at {1}{2:F2}.", BulletTotals.AdjustmentsQty, m_DataFiles.Preferences.Currency, BulletTotals.AdjustmentsTotal);

					TextSize = e.Graphics.MeasureString(strText, DataFont);

					e.Graphics.DrawString(strText, DataFont, Brushes.Black, nX, nY + nStartY);

					nY += TextSize.Height;
					}

				//----------------------------------------------------------------------------*
				// Used
				//----------------------------------------------------------------------------*

				if (BulletTotals.NumUsed > 0)
					{
					strText = String.Format("{0:F0} used in {1:G0} batch{2} at a cost of {3}{4:F2}.", Math.Abs(BulletTotals.UsedQty), BulletTotals.NumUsed, BulletTotals.NumUsed != 1 ? "es" : "", m_DataFiles.Preferences.Currency, Math.Abs(BulletTotals.UsedTotal));

					TextSize = e.Graphics.MeasureString(strText, DataFont);

					e.Graphics.DrawString(strText, DataFont, Brushes.Black, nX, nY + nStartY);

					nY += TextSize.Height;
					}

				//----------------------------------------------------------------------------*
				// Instock
				//----------------------------------------------------------------------------*

				nY += (TextSize.Height / (float)2.0);

				strText = String.Format("{0:F0} bullet{1} remain{2} in stock with a value of {3}{4:F2}.", BulletTotals.InStockQty, BulletTotals.InStockQty != 1.0 ? "s" : "", BulletTotals.InStockQty == 1.0 ? "s" : "", m_DataFiles.Preferences.Currency, BulletTotals.InStockTotal);

				TextSize = e.Graphics.MeasureString(strText, DataFont);

				e.Graphics.DrawString(strText, DataFont, Brushes.Black, nX, nY + nStartY);

				nY += (TextSize.Height * (float)1.5);

				//----------------------------------------------------------------------------*
				// Set the next location for report data
				//----------------------------------------------------------------------------*

				if (nY > nNextTotalsY)
					nNextTotalsY = nY;

				if (nX == e.MarginBounds.Left)
					{
					nX = PageRect.Width / 2;

					nY = nCurrentY;
					}
				else
					{
					nX = e.MarginBounds.Left;

					nY = nNextTotalsY;

					nCurrentY = nY;
					}
				}

			//----------------------------------------------------------------------------*
			// Case Totals
			//----------------------------------------------------------------------------*

			if (m_Parms.Cases && CaseTotals.NumTransactions > 0)
				{
				strText = "Cases";

				TextSize = e.Graphics.MeasureString(strText, TypeFont);

				e.Graphics.DrawString(strText, TypeFont, Brushes.Black, nX, nY + nStartY);

				nY += (TextSize.Height * (float)1.5);

				//----------------------------------------------------------------------------*
				// Number of activities
				//----------------------------------------------------------------------------*

				strText = String.Format("{0:G0} activit{1} found matching the search criteria.", CaseTotals.NumTransactions, CaseTotals.NumTransactions != 1 ? "ies" : "y");

				TextSize = e.Graphics.MeasureString(strText, DataFont);

				e.Graphics.DrawString(strText, DataFont, Brushes.Black, nX, nY + nStartY);

				nY += (TextSize.Height * (float)1.5);

				//----------------------------------------------------------------------------*
				// Initial Stock
				//----------------------------------------------------------------------------*

				if (CaseTotals.NumInitialStock > 0)
					{
					strText = String.Format("{0:G0} {1} in initial stock with a value of {2}{3:F2}.", CaseTotals.InitialStockQty, CaseTotals.InitialStockQty == 1 ? "was" : "were", m_DataFiles.Preferences.Currency, CaseTotals.InitialStockTotal);

					TextSize = e.Graphics.MeasureString(strText, DataFont);

					e.Graphics.DrawString(strText, DataFont, Brushes.Black, nX, nY + nStartY);

					nY += TextSize.Height;
					}

				//----------------------------------------------------------------------------*
				// Purchases
				//----------------------------------------------------------------------------*

				if (CaseTotals.NumPurchases > 0)
					{
					strText = String.Format("{0:G0} purchase{1} totaling {2:F0} cases at a cost of {3}{4:F2}.", CaseTotals.NumPurchases, CaseTotals.NumPurchases != 1 ? "s" : "", CaseTotals.PurchaseQty, m_DataFiles.Preferences.Currency, CaseTotals.PurchaseTotal);

					TextSize = e.Graphics.MeasureString(strText, DataFont);

					e.Graphics.DrawString(strText, DataFont, Brushes.Black, nX, nY + nStartY);

					nY += TextSize.Height;
					}

				//----------------------------------------------------------------------------*
				// Adjustments
				//----------------------------------------------------------------------------*

				if (CaseTotals.NumAdjustments > 0)
					{
					strText = String.Format("{0} adjustment{1} ", CaseTotals.NumAdjustments, CaseTotals.NumAdjustments != 1 ? "s" : "");

					if (CaseTotals.AdjustmentsQty < 0.0)
						strText += String.Format("with a net loss of {0:F0} cases at a cost of {1}{2:F2}.", Math.Abs(CaseTotals.AdjustmentsQty), m_DataFiles.Preferences.Currency, Math.Abs(CaseTotals.AdjustmentsTotal));
					else
						strText += String.Format("with a net gain of {0:F0} cases valued at {1}{2:F2}.", CaseTotals.AdjustmentsQty, m_DataFiles.Preferences.Currency, CaseTotals.AdjustmentsTotal);

					TextSize = e.Graphics.MeasureString(strText, DataFont);

					e.Graphics.DrawString(strText, DataFont, Brushes.Black, nX, nY + nStartY);

					nY += TextSize.Height;
					}

				//----------------------------------------------------------------------------*
				// Used
				//----------------------------------------------------------------------------*

				if (CaseTotals.NumUsed > 0)
					{
					strText = String.Format("{0:F0} used in {1:G0} batch{2} at a cost of {3}{4:F2}.", Math.Abs(CaseTotals.UsedQty), CaseTotals.NumUsed, CaseTotals.NumUsed != 1 ? "es" : "", m_DataFiles.Preferences.Currency, Math.Abs(CaseTotals.UsedTotal));

					TextSize = e.Graphics.MeasureString(strText, DataFont);

					e.Graphics.DrawString(strText, DataFont, Brushes.Black, nX, nY + nStartY);

					nY += TextSize.Height;
					}

				//----------------------------------------------------------------------------*
				// Instock
				//----------------------------------------------------------------------------*

				nY += (TextSize.Height / (float)2.0);

				strText = String.Format("{0:F0} case{1} remain{2} in stock with a value of {3}{4:F2}.", CaseTotals.InStockQty, CaseTotals.InStockQty != 1.0 ? "s" : "", CaseTotals.InStockQty == 1.0 ? "s" : "", m_DataFiles.Preferences.Currency, CaseTotals.InStockTotal);

				TextSize = e.Graphics.MeasureString(strText, DataFont);

				e.Graphics.DrawString(strText, DataFont, Brushes.Black, nX, nY + nStartY);

				nY += (TextSize.Height * (float)1.5);

				//----------------------------------------------------------------------------*
				// Set the next location for report data
				//----------------------------------------------------------------------------*

				if (nY > nNextTotalsY)
					nNextTotalsY = nY;

				if (nX == e.MarginBounds.Left)
					{
					nX = PageRect.Width / 2;

					nY = nCurrentY;
					}
				else
					{
					nX = e.MarginBounds.Left;

					nY = nNextTotalsY;

					nCurrentY = nY;
					}
				}

			//----------------------------------------------------------------------------*
			// Powder Totals
			//----------------------------------------------------------------------------*

			if (m_Parms.Powder && PowderTotals.NumTransactions > 0)
				{
				strText = "Powder";

				TextSize = e.Graphics.MeasureString(strText, TypeFont);

				e.Graphics.DrawString(strText, TypeFont, Brushes.Black, nX, nY + nStartY);

				nY += (TextSize.Height * (float)1.5);

				//----------------------------------------------------------------------------*
				// Number of activities
				//----------------------------------------------------------------------------*

				strText = String.Format("{0:G0} activit{1} found matching the search criteria.", PowderTotals.NumTransactions, PowderTotals.NumTransactions != 1 ? "ies" : "y");

				TextSize = e.Graphics.MeasureString(strText, DataFont);

				e.Graphics.DrawString(strText, DataFont, Brushes.Black, nX, nY + nStartY);

				nY += (TextSize.Height * (float)1.5);

				//----------------------------------------------------------------------------*
				// Initial Stock
				//----------------------------------------------------------------------------*

				if (PowderTotals.NumInitialStock > 0)
					{
					strText = String.Format("{0:F3} {1}{2} {3} in initial stock with a value of {4}{5:F2}.", PowderTotals.InitialStockQty, cDataFiles.MetricString(cDataFiles.eDataType.CanWeight), PowderTotals.InitialStockQty != 1.0 ? "s" : "", PowderTotals.InitialStockQty == 1 ? "was" : "were", m_DataFiles.Preferences.Currency, PowderTotals.InitialStockTotal);

					TextSize = e.Graphics.MeasureString(strText, DataFont);

					e.Graphics.DrawString(strText, DataFont, Brushes.Black, nX, nY + nStartY);

					nY += TextSize.Height;
					}

				//----------------------------------------------------------------------------*
				// Purchases
				//----------------------------------------------------------------------------*

				if (PowderTotals.NumPurchases > 0)
					{
					string strFormat = "{0:G0} purchase{1} totaling {2:F";
					strFormat += String.Format("{0:G0}", m_DataFiles.Preferences.CanWeightDecimals);
					strFormat += "} {3}{4} at a cost of {5}{6:F2}.";

					strText = String.Format(strFormat, PowderTotals.NumPurchases, PowderTotals.NumPurchases != 1 ? "s" : "", PowderTotals.PurchaseQty, cDataFiles.MetricString(cDataFiles.eDataType.CanWeight), PowderTotals.PurchaseQty != 1.0 ? "s" : "", m_DataFiles.Preferences.Currency, PowderTotals.PurchaseTotal);

					TextSize = e.Graphics.MeasureString(strText, DataFont);

					e.Graphics.DrawString(strText, DataFont, Brushes.Black, nX, nY + nStartY);

					nY += TextSize.Height;
					}

				//----------------------------------------------------------------------------*
				// Adjustments
				//----------------------------------------------------------------------------*

				if (PowderTotals.NumAdjustments > 0)
					{
					strText = String.Format("{0} adjustment{1} ", PowderTotals.NumAdjustments, PowderTotals.NumAdjustments != 1 ? "s" : "");

					if (CaseTotals.AdjustmentsQty < 0.0)
						strText += String.Format("with a net loss of {0:F3} {1}{2} at a cost of {3}{4:F2}.", Math.Abs(PowderTotals.AdjustmentsQty), cDataFiles.MetricString(cDataFiles.eDataType.CanWeight), PowderTotals.AdjustmentsQty != 1.0 ? "s" : "", m_DataFiles.Preferences.Currency, Math.Abs(PowderTotals.AdjustmentsTotal));
					else
						strText += String.Format("with a net gain of {0:F3} {1}{2} valued at {3}{4:F2}.", PowderTotals.AdjustmentsQty, cDataFiles.MetricString(cDataFiles.eDataType.CanWeight), PowderTotals.AdjustmentsQty != 1.0 ? "s" : "", m_DataFiles.Preferences.Currency, PowderTotals.AdjustmentsTotal);

					TextSize = e.Graphics.MeasureString(strText, DataFont);

					e.Graphics.DrawString(strText, DataFont, Brushes.Black, nX, nY + nStartY);

					nY += TextSize.Height;
					}

				//----------------------------------------------------------------------------*
				// Used
				//----------------------------------------------------------------------------*

				if (PowderTotals.NumUsed > 0)
					{
					strText = String.Format("{0:F3} {1}{2} used in {3:G0} batch{4} at a cost of {5}{6:F2}.", Math.Abs(PowderTotals.UsedQty), cDataFiles.MetricString(cDataFiles.eDataType.CanWeight), PowderTotals.UsedQty != 1.0 ? "s" : "", PowderTotals.NumUsed, PowderTotals.NumUsed != 1.0 ? "s" : "", m_DataFiles.Preferences.Currency, Math.Abs(PowderTotals.UsedTotal));

					TextSize = e.Graphics.MeasureString(strText, DataFont);

					e.Graphics.DrawString(strText, DataFont, Brushes.Black, nX, nY + nStartY);

					nY += TextSize.Height;
					}

				//----------------------------------------------------------------------------*
				// Instock
				//----------------------------------------------------------------------------*

				nY += (TextSize.Height / (float)2.0);

				strText = String.Format("{0:F3} {1}{2} remain{3} in stock with a value of {4}{5:F2}.", PowderTotals.InStockQty, cDataFiles.MetricString(cDataFiles.eDataType.CanWeight), PowderTotals.InitialStockQty != 1.0 ? "s" : "", PowderTotals.InStockQty == 1.0 ? "s" : "", m_DataFiles.Preferences.Currency, PowderTotals.InStockTotal);

				TextSize = e.Graphics.MeasureString(strText, DataFont);

				e.Graphics.DrawString(strText, DataFont, Brushes.Black, nX, nY + nStartY);

				nY += (TextSize.Height * (float)1.5);

				//----------------------------------------------------------------------------*
				// Set the next location for report data
				//----------------------------------------------------------------------------*

				if (nY > nNextTotalsY)
					nNextTotalsY = nY;

				if (nX == e.MarginBounds.Left)
					{
					nX = PageRect.Width / 2;

					nY = nCurrentY;
					}
				else
					{
					nX = e.MarginBounds.Left;

					nY = nNextTotalsY;

					nCurrentY = nY;
					}
				}

			//----------------------------------------------------------------------------*
			// Primer Totals
			//----------------------------------------------------------------------------*

			if (m_Parms.Primers && PrimerTotals.NumTransactions > 0)
				{
				strText = "Primers";

				TextSize = e.Graphics.MeasureString(strText, TypeFont);

				e.Graphics.DrawString(strText, TypeFont, Brushes.Black, nX, nY + nStartY);

				nY += (TextSize.Height * (float)1.5);

				//----------------------------------------------------------------------------*
				// Number of activities
				//----------------------------------------------------------------------------*

				strText = String.Format("{0:G0} activit{1} found matching the search criteria.", PrimerTotals.NumTransactions, PrimerTotals.NumTransactions != 1 ? "ies" : "y");

				TextSize = e.Graphics.MeasureString(strText, DataFont);

				e.Graphics.DrawString(strText, DataFont, Brushes.Black, nX, nY + nStartY);

				nY += (TextSize.Height * (float)1.5);

				//----------------------------------------------------------------------------*
				// Initial Stock
				//----------------------------------------------------------------------------*

				if (PrimerTotals.NumInitialStock > 0)
					{
					strText = String.Format("{0:G0} {1} in initial stock with a value of {2}{3:F2}.", PrimerTotals.InitialStockQty, PrimerTotals.InitialStockQty == 1 ? "was" : "were", m_DataFiles.Preferences.Currency, PrimerTotals.InitialStockTotal);

					TextSize = e.Graphics.MeasureString(strText, DataFont);

					e.Graphics.DrawString(strText, DataFont, Brushes.Black, nX, nY + nStartY);

					nY += TextSize.Height;
					}

				//----------------------------------------------------------------------------*
				// Purchases
				//----------------------------------------------------------------------------*

				if (PrimerTotals.NumPurchases > 0)
					{
					strText = String.Format("{0:G0} purchase{1} totaling {2:F0} primers at a cost of {3}{4:F2}.", PrimerTotals.NumPurchases, PrimerTotals.NumPurchases != 1 ? "s" : "", PrimerTotals.PurchaseQty, m_DataFiles.Preferences.Currency, PrimerTotals.PurchaseTotal);

					TextSize = e.Graphics.MeasureString(strText, DataFont);

					e.Graphics.DrawString(strText, DataFont, Brushes.Black, nX, nY + nStartY);

					nY += TextSize.Height;
					}

				//----------------------------------------------------------------------------*
				// Adjustments
				//----------------------------------------------------------------------------*

				if (PrimerTotals.NumAdjustments > 0)
					{
					strText = String.Format("{0} adjustment{1} ", PrimerTotals.NumAdjustments, PrimerTotals.NumAdjustments != 1 ? "s" : "");

					if (PrimerTotals.AdjustmentsQty < 0.0)
						strText += String.Format("with a net loss of {0:F0} primers at a cost of {1}{2:F2}.", Math.Abs(PrimerTotals.AdjustmentsQty), m_DataFiles.Preferences.Currency, Math.Abs(PrimerTotals.AdjustmentsTotal));
					else
						strText += String.Format("with a net gain of {0:F0} primers valued at {1}{2:F2}.", PrimerTotals.AdjustmentsQty, m_DataFiles.Preferences.Currency, PrimerTotals.AdjustmentsTotal);

					TextSize = e.Graphics.MeasureString(strText, DataFont);

					e.Graphics.DrawString(strText, DataFont, Brushes.Black, nX, nY + nStartY);

					nY += TextSize.Height;
					}

				//----------------------------------------------------------------------------*
				// Used
				//----------------------------------------------------------------------------*

				if (PrimerTotals.NumUsed > 0)
					{
					strText = String.Format("{0:F0} used in {1:G0} batch{2} at a cost of {3}{4:F2}.", Math.Abs(PrimerTotals.UsedQty), PrimerTotals.NumUsed, PrimerTotals.NumUsed != 1 ? "es" : "", m_DataFiles.Preferences.Currency, Math.Abs(PrimerTotals.UsedTotal));

					TextSize = e.Graphics.MeasureString(strText, DataFont);

					e.Graphics.DrawString(strText, DataFont, Brushes.Black, nX, nY + nStartY);

					nY += TextSize.Height;
					}

				//----------------------------------------------------------------------------*
				// Instock
				//----------------------------------------------------------------------------*

				nY += (TextSize.Height / (float)2.0);

				strText = String.Format("{0:F0} primer{1} remain{2} in stock with a value of {3}{4:F2}.", PrimerTotals.InStockQty, PrimerTotals.InStockQty != 1.0 ? "s" : "", PrimerTotals.InStockQty == 1.0 ? "s" : "", m_DataFiles.Preferences.Currency, PrimerTotals.InStockTotal);

				TextSize = e.Graphics.MeasureString(strText, DataFont);

				e.Graphics.DrawString(strText, DataFont, Brushes.Black, nX, nY + nStartY);

				nY += (TextSize.Height * (float)1.5);

				//----------------------------------------------------------------------------*
				// Set the next location for report data
				//----------------------------------------------------------------------------*

				if (nY > nNextTotalsY)
					nNextTotalsY = nY;

				if (nX == e.MarginBounds.Left)
					{
					nX = PageRect.Width / 2;

					nY = nCurrentY;
					}
				else
					{
					nX = e.MarginBounds.Left;

					nY = nNextTotalsY;

					nCurrentY = nY;
					}
				}

			//----------------------------------------------------------------------------*
			// Factory Ammo Totals
			//----------------------------------------------------------------------------*

			if (m_Parms.Ammo && AmmoTotals.NumTransactions > 0)
				{
				strText = "Factory Ammo";

				TextSize = e.Graphics.MeasureString(strText, TypeFont);

				e.Graphics.DrawString(strText, TypeFont, Brushes.Black, nX, nY + nStartY);

				nY += (TextSize.Height * (float)1.5);

				//----------------------------------------------------------------------------*
				// Number of activities
				//----------------------------------------------------------------------------*

				strText = String.Format("{0:G0} activit{1} found matching the search criteria.", AmmoTotals.NumTransactions, AmmoTotals.NumTransactions != 1 ? "ies" : "y");

				TextSize = e.Graphics.MeasureString(strText, DataFont);

				e.Graphics.DrawString(strText, DataFont, Brushes.Black, nX, nY + nStartY);

				nY += (TextSize.Height * (float)1.5);

				//----------------------------------------------------------------------------*
				// Initial Stock
				//----------------------------------------------------------------------------*

				if (AmmoTotals.NumInitialStock > 0)
					{
					strText = String.Format("{0:G0} rounds {1} in initial stock with a value of {2}{3:F2}.", AmmoTotals.InitialStockQty, AmmoTotals.InitialStockQty == 1 ? "was" : "were", m_DataFiles.Preferences.Currency, AmmoTotals.InitialStockTotal);

					TextSize = e.Graphics.MeasureString(strText, DataFont);

					e.Graphics.DrawString(strText, DataFont, Brushes.Black, nX, nY + nStartY);

					nY += TextSize.Height;
					}

				//----------------------------------------------------------------------------*
				// Purchases
				//----------------------------------------------------------------------------*

				if (AmmoTotals.NumPurchases > 0)
					{
					strText = String.Format("{0:G0} purchase{1} totaling {2:F0} rounds at a cost of {3}{4:F2}.", AmmoTotals.NumPurchases, AmmoTotals.NumPurchases != 1 ? "s" : "", AmmoTotals.PurchaseQty, m_DataFiles.Preferences.Currency, AmmoTotals.PurchaseTotal);

					TextSize = e.Graphics.MeasureString(strText, DataFont);

					e.Graphics.DrawString(strText, DataFont, Brushes.Black, nX, nY + nStartY);

					nY += TextSize.Height;
					}

				//----------------------------------------------------------------------------*
				// Adjustments
				//----------------------------------------------------------------------------*

				if (AmmoTotals.NumAdjustments > 0)
					{
					strText = String.Format("{0} adjustment{1} ", AmmoTotals.NumAdjustments, AmmoTotals.NumAdjustments != 1 ? "s" : "");

					if (AmmoTotals.AdjustmentsQty < 0.0)
						strText += String.Format("with a net loss of {0:F0} rounds at a cost of {1}{2:F2}.", Math.Abs(AmmoTotals.AdjustmentsQty), m_DataFiles.Preferences.Currency, Math.Abs(AmmoTotals.AdjustmentsTotal));
					else
						strText += String.Format("with a net gain of {0:F0} rounds valued at {1}{2:F2}.", AmmoTotals.AdjustmentsQty, m_DataFiles.Preferences.Currency, AmmoTotals.AdjustmentsTotal);

					TextSize = e.Graphics.MeasureString(strText, DataFont);

					e.Graphics.DrawString(strText, DataFont, Brushes.Black, nX, nY + nStartY);

					nY += TextSize.Height;
					}

				//----------------------------------------------------------------------------*
				// Fired
				//----------------------------------------------------------------------------*

				if (AmmoTotals.NumFired > 0)
					{
					strText = String.Format("{0:F0} round{1} fired at a cost of {2}{3:F2}.", AmmoTotals.FiredQty, AmmoTotals.FiredQty != 1 ? "s" : "", m_DataFiles.Preferences.Currency, AmmoTotals.FiredTotal);

					TextSize = e.Graphics.MeasureString(strText, DataFont);

					e.Graphics.DrawString(strText, DataFont, Brushes.Black, nX, nY + nStartY);

					nY += TextSize.Height;
					}

				//----------------------------------------------------------------------------*
				// Used
				//----------------------------------------------------------------------------*

				if (AmmoTotals.NumUsed > 0)
					{
					strText = String.Format("{0:F0} used in {1:G0} batch{2} at a cost of {3}{4:F2}.", Math.Abs(AmmoTotals.UsedQty), AmmoTotals.NumUsed, AmmoTotals.NumUsed != 1 ? "es" : "", m_DataFiles.Preferences.Currency, Math.Abs(AmmoTotals.UsedTotal));

					TextSize = e.Graphics.MeasureString(strText, DataFont);

					e.Graphics.DrawString(strText, DataFont, Brushes.Black, nX, nY + nStartY);

					nY += TextSize.Height;
					}

				//----------------------------------------------------------------------------*
				// Instock
				//----------------------------------------------------------------------------*

				nY += (TextSize.Height / (float)2.0);

				strText = String.Format("{0:F0} round{1} remain{2} in stock with a value of {3}{4:F2}.", AmmoTotals.InStockQty, AmmoTotals.InStockQty != 1.0 ? "s" : "", AmmoTotals.InStockQty == 1.0 ? "s" : "", m_DataFiles.Preferences.Currency, AmmoTotals.InStockTotal);

				TextSize = e.Graphics.MeasureString(strText, DataFont);

				e.Graphics.DrawString(strText, DataFont, Brushes.Black, nX, nY + nStartY);

				nY += (TextSize.Height * (float)1.5);

				//----------------------------------------------------------------------------*
				// Set the next location for report data
				//----------------------------------------------------------------------------*

				if (nY > nNextTotalsY)
					nNextTotalsY = nY;

				if (nX == e.MarginBounds.Left)
					{
					nX = PageRect.Width / 2;

					nY = nCurrentY;
					}
				else
					{
					nX = e.MarginBounds.Left;

					nY = nNextTotalsY;

					nCurrentY = nY;
					}
				}

			//----------------------------------------------------------------------------*
			// Reloaded Ammo Totals
			//----------------------------------------------------------------------------*

			if (m_Parms.Reloads && ReloadTotals.NumTransactions > 0)
				{
				strText = "Reloaded Ammo";

				TextSize = e.Graphics.MeasureString(strText, TypeFont);

				e.Graphics.DrawString(strText, TypeFont, Brushes.Black, nX, nY + nStartY);

				nY += (TextSize.Height * (float)1.5);

				//----------------------------------------------------------------------------*
				// Number of activities
				//----------------------------------------------------------------------------*

				strText = String.Format("{0:G0} activit{1} found matching the search criteria.", ReloadTotals.NumTransactions, ReloadTotals.NumTransactions != 1 ? "ies" : "y");

				TextSize = e.Graphics.MeasureString(strText, DataFont);

				e.Graphics.DrawString(strText, DataFont, Brushes.Black, nX, nY + nStartY);

				nY += (TextSize.Height * (float)1.5);

				//----------------------------------------------------------------------------*
				// Initial Stock (Loaded for reloads)
				//----------------------------------------------------------------------------*

				if (ReloadTotals.NumInitialStock > 0)
					{
					strText = String.Format("{0:G0} round{1} {2} loaded at a cost of {3}{4:F2}.", ReloadTotals.InitialStockQty, ReloadTotals.InitialStockQty != 0.0 ? "s" : "", ReloadTotals.InitialStockQty == 1 ? "was" : "were", m_DataFiles.Preferences.Currency, ReloadTotals.InitialStockTotal);

					TextSize = e.Graphics.MeasureString(strText, DataFont);

					e.Graphics.DrawString(strText, DataFont, Brushes.Black, nX, nY + nStartY);

					nY += TextSize.Height;
					}

				//----------------------------------------------------------------------------*
				// Purchases
				//----------------------------------------------------------------------------*

				if (ReloadTotals.NumPurchases > 0)
					{
					strText = String.Format("{0:G0} purchase{1} totaling {2:F0} rounds at a cost of {3}{4:F2}.", ReloadTotals.NumPurchases, ReloadTotals.NumPurchases != 1 ? "s" : "", ReloadTotals.PurchaseQty, m_DataFiles.Preferences.Currency, ReloadTotals.PurchaseTotal);

					TextSize = e.Graphics.MeasureString(strText, DataFont);

					e.Graphics.DrawString(strText, DataFont, Brushes.Black, nX, nY + nStartY);

					nY += TextSize.Height;
					}

				//----------------------------------------------------------------------------*
				// Adjustments
				//----------------------------------------------------------------------------*

				if (ReloadTotals.NumAdjustments > 0)
					{
					strText = String.Format("{0} adjustment{1} ", ReloadTotals.NumAdjustments, ReloadTotals.NumAdjustments != 1 ? "s" : "");

					if (ReloadTotals.AdjustmentsQty < 0.0)
						strText += String.Format("with a net loss of {0:F0} rounds at a cost of {1}{2:F2}.", Math.Abs(ReloadTotals.AdjustmentsQty), m_DataFiles.Preferences.Currency, Math.Abs(ReloadTotals.AdjustmentsTotal));
					else
						strText += String.Format("with a net gain of {0:F0} rounds valued at {1}{2:F2}.", ReloadTotals.AdjustmentsQty, m_DataFiles.Preferences.Currency, ReloadTotals.AdjustmentsTotal);

					TextSize = e.Graphics.MeasureString(strText, DataFont);

					e.Graphics.DrawString(strText, DataFont, Brushes.Black, nX, nY + nStartY);

					nY += TextSize.Height;
					}

				//----------------------------------------------------------------------------*
				// Fired
				//----------------------------------------------------------------------------*

				if (ReloadTotals.NumFired > 0)
					{
					strText = String.Format("{0:F0} round{1} fired at a cost of {2}{3:F2}.", ReloadTotals.FiredQty, ReloadTotals.FiredQty != 1 ? "s" : "", m_DataFiles.Preferences.Currency, ReloadTotals.FiredTotal);

					TextSize = e.Graphics.MeasureString(strText, DataFont);

					e.Graphics.DrawString(strText, DataFont, Brushes.Black, nX, nY + nStartY);

					nY += TextSize.Height;
					}

				//----------------------------------------------------------------------------*
				// Used
				//----------------------------------------------------------------------------*

				if (ReloadTotals.NumUsed > 0)
					{
					strText = String.Format("{0:F0} used in {1:G0} batch{2} at a cost of {3}{4:F2}.", Math.Abs(ReloadTotals.UsedQty), ReloadTotals.NumUsed, ReloadTotals.NumUsed != 1 ? "es" : "", m_DataFiles.Preferences.Currency, Math.Abs(ReloadTotals.UsedTotal));

					TextSize = e.Graphics.MeasureString(strText, DataFont);

					e.Graphics.DrawString(strText, DataFont, Brushes.Black, nX, nY + nStartY);

					nY += TextSize.Height;
					}

				//----------------------------------------------------------------------------*
				// Instock
				//----------------------------------------------------------------------------*

				nY += (TextSize.Height / (float)2.0);

				strText = String.Format("{0:F0} round{1} remain{2} in stock with a value of {3}{4:F2}.", ReloadTotals.InStockQty, ReloadTotals.InStockQty != 1.0 ? "s" : "", ReloadTotals.InStockQty == 1.0 ? "s" : "", m_DataFiles.Preferences.Currency, ReloadTotals.InStockTotal);

				TextSize = e.Graphics.MeasureString(strText, DataFont);

				e.Graphics.DrawString(strText, DataFont, Brushes.Black, nX, nY + nStartY);

				nY += (TextSize.Height * (float)1.5);

				//----------------------------------------------------------------------------*
				// Set the next location for report data
				//----------------------------------------------------------------------------*

				if (nY > nNextTotalsY)
					nNextTotalsY = nY;

				if (nX == e.MarginBounds.Left)
					{
					nX = PageRect.Width / 2;

					nY = nCurrentY;
					}
				else
					{
					nX = e.MarginBounds.Left;

					nY = nNextTotalsY;

					nCurrentY = nY;
					}
				}

			//----------------------------------------------------------------------------*
			// Set the printed flag and exit
			//----------------------------------------------------------------------------*

			nY = nNextTotalsY + (TextSize.Height / (float)2.0);

			m_fOverviewPrinted = true;

			return (nY);
			}

		//============================================================================*
		// OnMove()
		//============================================================================*

		protected override void OnMove(EventArgs e)
			{
			base.OnMove(e);

			if (!m_fInitialized)
				return;

			if (WindowState == FormWindowState.Maximized)
				m_DataFiles.Preferences.CostAnalysisPreviewMaximized = true;
			else
				{
				m_DataFiles.Preferences.CostAnalysisPreviewLocation = Location;

				m_DataFiles.Preferences.CostAnalysisPreviewMaximized = false;
				}
			}

		//============================================================================*
		// OnPrintPage()
		//============================================================================*

		private void OnPrintPage(object sender, PrintPageEventArgs e)
			{
			//----------------------------------------------------------------------------*
			// Create the fonts
			//----------------------------------------------------------------------------*

			Font SupplyTypeFont = new Font("Trebuchet MS", 10, FontStyle.Bold);
			Font HeaderFont = new Font("Trebuchet MS", 8, FontStyle.Bold);
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

			foreach (cPrintColumn PrintColumn in m_AmmoColumns)
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

						break;

					case cSupply.eSupplyTypes.Cases:
						TextSize = e.Graphics.MeasureString((Supply as cCase).ToString(), DataFont);

						if (TextSize.Width > m_CaseColumns[0].Width)
							m_CaseColumns[0].Width = TextSize.Width;

						break;

					case cSupply.eSupplyTypes.Ammo:
						TextSize = e.Graphics.MeasureString((Supply as cAmmo).ToShortString(), DataFont);

						if (TextSize.Width > m_AmmoColumns[0].Width)
							m_AmmoColumns[0].Width = TextSize.Width;

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
			float nX = e.MarginBounds.Left;

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

					cCostAnalysisSupplyTotals SupplyTotals = m_Parms.SupplyTotals(Supply);

					//----------------------------------------------------------------------------*
					// Draw the page header if needed
					//----------------------------------------------------------------------------*

					if (!fPageHeader)
						{
						//----------------------------------------------------------------------------*
						// Draw the Title
						//----------------------------------------------------------------------------*

						nY = cPrintObject.PrintReportTitle("Cost Analysis", e, PageRect);

						//----------------------------------------------------------------------------*
						// Draw the Date Range
						//----------------------------------------------------------------------------*

						strText = String.Format("From {0} through {1}", m_Parms.StartDate.ToShortDateString(), m_Parms.EndDate.ToShortDateString());

						TextSize = e.Graphics.MeasureString(strText, HeaderFont);

						e.Graphics.DrawString(strText, HeaderFont, Brushes.Black, e.MarginBounds.Left + (e.MarginBounds.Width / 2) - (TextSize.Width / 2), nY);

						nY += TextSize.Height;

						//----------------------------------------------------------------------------*
						// Draw the Manufacturer filter if needed
						//----------------------------------------------------------------------------*

						strText = "";

						if (m_Parms.Manufacturer != null)
							strText = String.Format("{0} Products Only", m_Parms.Manufacturer.Name);

						//----------------------------------------------------------------------------*
						// Draw the Purchase Location filter if needed
						//----------------------------------------------------------------------------*

						if (m_Parms.Location != null && m_Parms.Location.Length > 0)
							{
							if (strText.Length > 0)
								strText += ", ";

							strText += String.Format("Purchases from {0} Only", m_Parms.Location);
							}

						if (strText.Length > 0)
							{
							TextSize = e.Graphics.MeasureString(strText, HeaderFont);

							e.Graphics.DrawString(strText, HeaderFont, Brushes.Black, e.MarginBounds.Left + (e.MarginBounds.Width / 2) - (TextSize.Width / 2), nY);

							nY += TextSize.Height;
							}

						//----------------------------------------------------------------------------*
						// Tax/Shipping included?
						//----------------------------------------------------------------------------*

						strText = m_DataFiles.CostText;

						TextSize = e.Graphics.MeasureString(strText, HeaderFont);

						e.Graphics.DrawString(strText, HeaderFont, Brushes.Black, e.MarginBounds.Left + (e.MarginBounds.Width / 2) - (TextSize.Width / 2), nY);

						nY += TextSize.Height;

						fPageHeader = true;
						fHeader = false;
						}

					//----------------------------------------------------------------------------*
					// Draw the overview if needed
					//----------------------------------------------------------------------------*

					if (m_Parms.Overview && !m_fOverviewPrinted)
						nY += DrawOverview(nY, PageRect, e);

					//----------------------------------------------------------------------------*
					// If components are not desired, return
					//----------------------------------------------------------------------------*

					if (!m_Parms.Components)
						{
						e.HasMorePages = false;

						ResetPrintedFlag();

						return;
						}

					//----------------------------------------------------------------------------*
					// Draw the supply type header if needed
					//----------------------------------------------------------------------------*

					float nLineWidth = 0;
					float nLeftMargin = 0;

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

								nLineWidth = 0;

								foreach (cPrintColumn PrintColumn in m_BulletColumns)
									nLineWidth += PrintColumn.Width;

								nLineWidth += ((m_BulletColumns.Length - 1) * 10.0f);

								nLeftMargin = (e.PageBounds.Width / 2) - (nLineWidth / 2.0f);

								nX = nLeftMargin;

								nY += (TextSize.Height * (float)0.5);

								e.Graphics.DrawString(strText, SupplyTypeFont, Brushes.Black, nX, nY);

								nY += (TextSize.Height * (float)1.5);

								foreach (cPrintColumn PrintColumn in m_BulletColumns)
									{
									e.Graphics.DrawString(PrintColumn.Name, HeaderFont, Brushes.Black, nX, nY);

									nX += (PrintColumn.Width + 10);
									}

								TextSize = e.Graphics.MeasureString(m_BulletColumns[0].Name, HeaderFont);

								nY += TextSize.Height;

								e.Graphics.DrawLine(Pens.Black, nLeftMargin, nY, nX, nY);

								nX = nLeftMargin;

								break;

							//----------------------------------------------------------------------------*
							// Powder
							//----------------------------------------------------------------------------*

							case cSupply.eSupplyTypes.Powder:
								strText = "Powder";

								TextSize = e.Graphics.MeasureString(strText, SupplyTypeFont);

								nLineWidth = 0;

								foreach (cPrintColumn PrintColumn in m_PowderColumns)
									nLineWidth += PrintColumn.Width;

								nLineWidth += ((m_PowderColumns.Length - 1) * 10.0f);

								nLeftMargin = (e.PageBounds.Width / 2) - (nLineWidth / 2.0f);

								nX = nLeftMargin;

								nY += (TextSize.Height * (float)0.5);

								e.Graphics.DrawString(strText, SupplyTypeFont, Brushes.Black, nX, nY);

								nY += (TextSize.Height * (float)1.5);
								nX = nLeftMargin;

								foreach (cPrintColumn PrintColumn in m_PowderColumns)
									{
									e.Graphics.DrawString(PrintColumn.Name, HeaderFont, Brushes.Black, nX, nY);

									nX += (PrintColumn.Width + 10);
									}

								TextSize = e.Graphics.MeasureString(m_PowderColumns[0].Name, HeaderFont);

								nY += TextSize.Height;

								e.Graphics.DrawLine(Pens.Black, nLeftMargin, nY, nX, nY);

								nX = nLeftMargin;

								break;

							//----------------------------------------------------------------------------*
							// Primers
							//----------------------------------------------------------------------------*

							case cSupply.eSupplyTypes.Primers:
								strText = "Primers";

								TextSize = e.Graphics.MeasureString(strText, SupplyTypeFont);

								nLineWidth = 0;

								foreach (cPrintColumn PrintColumn in m_PrimerColumns)
									nLineWidth += PrintColumn.Width;

								nLineWidth += ((m_PrimerColumns.Length - 1) * 10.0f);

								nLeftMargin = (e.PageBounds.Width / 2) - (nLineWidth / 2.0f);

								nX = nLeftMargin;

								nY += (TextSize.Height * (float)0.5);

								e.Graphics.DrawString(strText, SupplyTypeFont, Brushes.Black, nX, nY);

								nY += (TextSize.Height * (float)1.5);
								nX = nLeftMargin;

								foreach (cPrintColumn PrintColumn in m_PrimerColumns)
									{
									e.Graphics.DrawString(PrintColumn.Name, HeaderFont, Brushes.Black, nX, nY);

									nX += (PrintColumn.Width + 10);
									}

								TextSize = e.Graphics.MeasureString(m_PrimerColumns[0].Name, HeaderFont);

								nY += TextSize.Height;

								e.Graphics.DrawLine(Pens.Black, nLeftMargin, nY, nX, nY);

								nX = nLeftMargin;

								break;

							//----------------------------------------------------------------------------*
							// Cases
							//----------------------------------------------------------------------------*

							case cSupply.eSupplyTypes.Cases:
								strText = "Cases";

								TextSize = e.Graphics.MeasureString(strText, SupplyTypeFont);

								nLineWidth = 0;

								foreach (cPrintColumn PrintColumn in m_CaseColumns)
									nLineWidth += PrintColumn.Width;

								nLineWidth += ((m_CaseColumns.Length - 1) * 10.0f);

								nLeftMargin = (e.PageBounds.Width / 2) - (nLineWidth / 2.0f);

								nX = nLeftMargin;

								nY += (TextSize.Height * (float)0.5);

								e.Graphics.DrawString(strText, SupplyTypeFont, Brushes.Black, nX, nY);

								nY += (TextSize.Height * (float)1.5);
								nX = nLeftMargin;

								foreach (cPrintColumn PrintColumn in m_CaseColumns)
									{
									e.Graphics.DrawString(PrintColumn.Name, HeaderFont, Brushes.Black, nX, nY);

									nX += (PrintColumn.Width + 10);
									}

								TextSize = e.Graphics.MeasureString(m_CaseColumns[0].Name, HeaderFont);

								nY += TextSize.Height;

								e.Graphics.DrawLine(Pens.Black, nLeftMargin, nY, nX, nY);

								nX = nLeftMargin;

								break;

							//----------------------------------------------------------------------------*
							// Ammo
							//----------------------------------------------------------------------------*

							case cSupply.eSupplyTypes.Ammo:
								strText = "Ammo";

								TextSize = e.Graphics.MeasureString(strText, SupplyTypeFont);

								nLineWidth = 0;

								foreach (cPrintColumn PrintColumn in m_AmmoColumns)
									nLineWidth += PrintColumn.Width;

								nLineWidth += ((m_AmmoColumns.Length - 1) * 10.0f);

								nLeftMargin = (e.PageBounds.Width / 2) - (nLineWidth / 2.0f);

								nX = nLeftMargin;
								nY += (TextSize.Height * (float)0.5);

								e.Graphics.DrawString(strText, SupplyTypeFont, Brushes.Black, nX, nY);

								nY += (TextSize.Height * (float)1.5);

								foreach (cPrintColumn PrintColumn in m_AmmoColumns)
									{
									e.Graphics.DrawString(PrintColumn.Name, HeaderFont, Brushes.Black, nX, nY);

									nX += (PrintColumn.Width + 10);
									}

								TextSize = e.Graphics.MeasureString(m_AmmoColumns[0].Name, HeaderFont);

								nY += TextSize.Height;

								e.Graphics.DrawLine(Pens.Black, nLeftMargin, nY, nX, nY);

								nX = nLeftMargin;

								break;
							}

						fHeader = true;
						}

					//----------------------------------------------------------------------------*
					// Draw the supply info
					//----------------------------------------------------------------------------*

					double dPurchases = 0.0;
					double dCosts = 0.0;
					double dAdjustments = 0.0;
					double dUsed = 0.0;
					double dQuantity = 0.0;
					double dValue = 0.0;

					switch (eSupplyType)
						{
						//----------------------------------------------------------------------------*
						// Bullets
						//----------------------------------------------------------------------------*

						case cSupply.eSupplyTypes.Bullets:
							cBullet Bullet = (cBullet)Supply;

							// Bullet Name

							strText = Bullet.ToString();

							nX = nLeftMargin;

							e.Graphics.DrawString(strText, DataFont, Brushes.Black, nX, nY);

							nX += (m_BulletColumns[0].Width + 10);

							// Purchases

							dPurchases = SupplyTotals.PurchaseQty + SupplyTotals.InitialStockQty;

							if (dPurchases == 0.0)
								strText = "-";
							else
								strText = String.Format("{0:F0}", dPurchases);

							TextSize = e.Graphics.MeasureString(strText, DataFont);

							e.Graphics.DrawString(strText, DataFont, Brushes.Black, nX + (m_BulletColumns[1].Width / 2) - (TextSize.Width / 2), nY);

							nX += (m_BulletColumns[1].Width + 10);

							// Purchase Costs

							dCosts = SupplyTotals.PurchaseTotal + SupplyTotals.InitialStockTotal;

							if (dCosts == 0.0)
								strText = "-";
							else
								strText = String.Format("{0}{1:F2}", m_DataFiles.Preferences.Currency, dCosts);

							TextSize = e.Graphics.MeasureString(strText, DataFont);

							e.Graphics.DrawString(strText, DataFont, Brushes.Black, nX + (m_BulletColumns[2].Width / 2) - (TextSize.Width / 2), nY);

							nX += (m_BulletColumns[2].Width + 10);

							// Adjustments

							dAdjustments = SupplyTotals.AdjustmentsQty;

							if (dAdjustments == 0.0)
								strText = "-";
							else
								strText = String.Format("{0:F0}", dAdjustments);

							TextSize = e.Graphics.MeasureString(strText, DataFont);

							e.Graphics.DrawString(strText, DataFont, Brushes.Black, nX + (m_BulletColumns[3].Width / 2) - (TextSize.Width / 2), nY);

							nX += (m_BulletColumns[3].Width + 10);

							// Used

							dUsed = Math.Abs(SupplyTotals.UsedQty);

							if (dUsed == 0.0)
								strText = "-";
							else
								strText = String.Format("{0:F0}", dUsed);

							TextSize = e.Graphics.MeasureString(strText, DataFont);

							e.Graphics.DrawString(strText, DataFont, Brushes.Black, nX + (m_BulletColumns[4].Width / 2) - (TextSize.Width / 2), nY);

							nX += (m_BulletColumns[4].Width + 10);

							// On Hand

							dQuantity = m_DataFiles.SupplyQuantity(Bullet);

							strText = String.Format("{0:F0}", dQuantity);

							TextSize = e.Graphics.MeasureString(strText, DataFont);

							e.Graphics.DrawString(strText, DataFont, Brushes.Black, nX + (m_BulletColumns[5].Width / 2) - (TextSize.Width / 2), nY);

							nX += (m_BulletColumns[5].Width + 10);

							// Value

							dValue = m_DataFiles.SupplyCostEach(Bullet) * m_DataFiles.SupplyQuantity(Bullet);

							if (dValue == 0.0)
								strText = "-";
							else
								strText = String.Format("{0}{1:F2}", m_DataFiles.Preferences.Currency, dValue);

							TextSize = e.Graphics.MeasureString(strText, DataFont);

							e.Graphics.DrawString(strText, DataFont, Brushes.Black, nX + m_BulletColumns[6].Width - TextSize.Width, nY);

							nX = nLeftMargin;

							nY += TextSize.Height;

							break;

						//----------------------------------------------------------------------------*
						// Powder
						//----------------------------------------------------------------------------*

						case cSupply.eSupplyTypes.Powder:
							cPowder Powder = (cPowder)Supply;

							// Powder Name

							strText = Powder.ToString();

							nX = nLeftMargin;

							e.Graphics.DrawString(strText, DataFont, Brushes.Black, nX, nY);

							nX += (m_PowderColumns[0].Width + 10);

							// Purchases

							dQuantity = SupplyTotals.PurchaseQty + SupplyTotals.InitialStockQty;

							string strFormat = "{0:F";
							strFormat += String.Format("{0:G0}", m_DataFiles.Preferences.CanWeightDecimals);
							strFormat += "} {1}{2}";

							if (dQuantity == 0.0)
								strText = "-";
							else
								strText = String.Format(strFormat, dQuantity, cDataFiles.MetricString(cDataFiles.eDataType.CanWeight), dQuantity != 1.0 ? "s" : "");

							TextSize = e.Graphics.MeasureString(strText, DataFont);

							e.Graphics.DrawString(strText, DataFont, Brushes.Black, nX + (m_PowderColumns[1].Width / 2) - (TextSize.Width / 2), nY);

							nX += (m_PowderColumns[1].Width + 10);

							// Purchase Costs

							dCosts = SupplyTotals.PurchaseTotal + SupplyTotals.InitialStockTotal;

							if (dCosts == 0.0)
								strText = "-";
							else
								strText = String.Format("{0}{1:F2}", m_DataFiles.Preferences.Currency, dCosts);

							TextSize = e.Graphics.MeasureString(strText, DataFont);

							e.Graphics.DrawString(strText, DataFont, Brushes.Black, nX + (m_PowderColumns[2].Width / 2) - (TextSize.Width / 2), nY);

							nX += (m_PowderColumns[2].Width + 10);

							// Adjustments

							dAdjustments = Math.Abs(SupplyTotals.AdjustmentsQty);

							if (dAdjustments == 0.0)
								strText = "-";
							else
								strText = String.Format("{0:F3} {1}{2}", dQuantity, cDataFiles.MetricString(cDataFiles.eDataType.CanWeight), dQuantity != 1.0 ? "s" : "");

							TextSize = e.Graphics.MeasureString(strText, DataFont);

							e.Graphics.DrawString(strText, DataFont, Brushes.Black, nX + (m_PowderColumns[3].Width / 2) - (TextSize.Width / 2), nY);

							nX += (m_PowderColumns[3].Width + 10);

							// Used

							dUsed = Math.Abs(SupplyTotals.UsedQty);

							if (dUsed == 0.0)
								strText = "-";
							else
								strText = String.Format("{0:F3} {1}{2}", dQuantity, cDataFiles.MetricString(cDataFiles.eDataType.CanWeight), dQuantity != 1.0 ? "s" : "");

							TextSize = e.Graphics.MeasureString(strText, DataFont);

							e.Graphics.DrawString(strText, DataFont, Brushes.Black, nX + (m_PowderColumns[4].Width / 2) - (TextSize.Width / 2), nY);

							nX += (m_PowderColumns[4].Width + 10);

							// On Hand

							dQuantity = cDataFiles.StandardToMetric( m_DataFiles.SupplyQuantity(Supply) / 7000.0, cDataFiles.eDataType.CanWeight);

							if (dQuantity == 0.0)
								strText = "-";
							else
								strText = String.Format("{0:F3} {1}{2}", dQuantity, cDataFiles.MetricString(cDataFiles.eDataType.CanWeight), dQuantity != 1.0 ? "s" : "");

							TextSize = e.Graphics.MeasureString(strText, DataFont);

							e.Graphics.DrawString(strText, DataFont, Brushes.Black, nX + (m_PowderColumns[5].Width / 2) - (TextSize.Width / 2), nY);

							nX += (m_PowderColumns[5].Width + 10);

							// Value

							dValue = m_DataFiles.SupplyCostEach(Supply) * m_DataFiles.SupplyQuantity(Supply);

							if (dValue == 0.0)
								strText = "-";
							else
								strText = String.Format("{0}{1:F2}", m_DataFiles.Preferences.Currency, dValue);

							TextSize = e.Graphics.MeasureString(strText, DataFont);

							e.Graphics.DrawString(strText, DataFont, Brushes.Black, nX + m_PowderColumns[6].Width - TextSize.Width, nY);

							nX = nLeftMargin;

							nY += TextSize.Height;

							break;

						//----------------------------------------------------------------------------*
						// Primers
						//----------------------------------------------------------------------------*

						case cSupply.eSupplyTypes.Primers:
							cPrimer Primer = (cPrimer)Supply;

							// Primer

							strText = Primer.ToShortString();

							nX = nLeftMargin;

							e.Graphics.DrawString(strText, DataFont, Brushes.Black, nX, nY);

							nX += (m_PrimerColumns[0].Width + 10);

							// Purchases

							dPurchases = SupplyTotals.PurchaseQty + SupplyTotals.InitialStockQty;

							if (dPurchases == 0.0)
								strText = "-";
							else
								strText = String.Format("{0:F0}", dPurchases);

							TextSize = e.Graphics.MeasureString(strText, DataFont);

							e.Graphics.DrawString(strText, DataFont, Brushes.Black, nX + (m_PrimerColumns[1].Width / 2) - (TextSize.Width / 2), nY);

							nX += (m_PrimerColumns[1].Width + 10);

							// Purchase Costs

							dCosts = SupplyTotals.PurchaseTotal + SupplyTotals.InitialStockTotal;

							if (dCosts == 0.0)
								strText = "-";
							else
								strText = String.Format("{0}{1:F2}", m_DataFiles.Preferences.Currency, dCosts);

							TextSize = e.Graphics.MeasureString(strText, DataFont);

							e.Graphics.DrawString(strText, DataFont, Brushes.Black, nX + (m_PrimerColumns[2].Width / 2) - (TextSize.Width / 2), nY);

							nX += (m_PrimerColumns[2].Width + 10);

							// Adjustments

							dAdjustments = SupplyTotals.AdjustmentsQty;

							if (dAdjustments == 0.0)
								strText = "-";
							else
								strText = String.Format("{0:F0}", dAdjustments);

							TextSize = e.Graphics.MeasureString(strText, DataFont);

							e.Graphics.DrawString(strText, DataFont, Brushes.Black, nX + (m_PrimerColumns[3].Width / 2) - (TextSize.Width / 2), nY);

							nX += (m_PrimerColumns[3].Width + 10);

							// Used

							dUsed = Math.Abs(SupplyTotals.UsedQty);

							if (dUsed == 0.0)
								strText = "-";
							else
								strText = String.Format("{0:F0}", dUsed);

							TextSize = e.Graphics.MeasureString(strText, DataFont);

							e.Graphics.DrawString(strText, DataFont, Brushes.Black, nX + (m_PrimerColumns[4].Width / 2) - (TextSize.Width / 2), nY);

							nX += (m_PrimerColumns[4].Width + 10);

							// On Hand

							dQuantity = m_DataFiles.SupplyQuantity(Supply);

							if (dQuantity == 0.0)
								strText = "-";
							else
								strText = String.Format("{0:F0}", dQuantity);

							TextSize = e.Graphics.MeasureString(strText, DataFont);

							e.Graphics.DrawString(strText, DataFont, Brushes.Black, nX + (m_PrimerColumns[5].Width / 2) - (TextSize.Width / 2), nY);

							nX += (m_BulletColumns[5].Width + 10);

							// Value

							dValue = m_DataFiles.SupplyCostEach(Supply) * m_DataFiles.SupplyQuantity(Supply);

							if (dValue == 0.0)
								strText = "-";
							else
								strText = String.Format("{0}{1:F2}", m_DataFiles.Preferences.Currency, dValue);

							TextSize = e.Graphics.MeasureString(strText, DataFont);

							e.Graphics.DrawString(strText, DataFont, Brushes.Black, nX + m_PrimerColumns[6].Width - TextSize.Width, nY);

							nX = nLeftMargin;

							nY += TextSize.Height;

							break;

						//----------------------------------------------------------------------------*
						// Cases
						//----------------------------------------------------------------------------*

						case cSupply.eSupplyTypes.Cases:
							cCase Case = (cCase)Supply;

							// Case

							strText = Case.ToString();

							nX = nLeftMargin;

							e.Graphics.DrawString(strText, DataFont, Brushes.Black, nX, nY);

							nX += (m_CaseColumns[0].Width + 10);

							// Purchases

							strText = String.Format("{0:F0}", SupplyTotals.PurchaseQty + SupplyTotals.InitialStockQty);

							TextSize = e.Graphics.MeasureString(strText, DataFont);

							e.Graphics.DrawString(strText, DataFont, Brushes.Black, nX + (m_CaseColumns[1].Width / 2) - (TextSize.Width / 2), nY);

							nX += (m_CaseColumns[1].Width + 10);

							// Purchase Costs

							strText = String.Format("{0}{1:F2}", m_DataFiles.Preferences.Currency, SupplyTotals.PurchaseTotal + SupplyTotals.InitialStockTotal);

							TextSize = e.Graphics.MeasureString(strText, DataFont);

							e.Graphics.DrawString(strText, DataFont, Brushes.Black, nX + (m_CaseColumns[2].Width / 2) - (TextSize.Width / 2), nY);

							nX += (m_CaseColumns[2].Width + 10);

							// Adjustments

							strText = String.Format("{0:F0}", SupplyTotals.AdjustmentsQty);

							TextSize = e.Graphics.MeasureString(strText, DataFont);

							e.Graphics.DrawString(strText, DataFont, Brushes.Black, nX + (m_CaseColumns[3].Width / 2) - (TextSize.Width / 2), nY);

							nX += (m_CaseColumns[3].Width + 10);

							// Used

							strText = String.Format("{0:F0}", Math.Abs(SupplyTotals.UsedQty));

							TextSize = e.Graphics.MeasureString(strText, DataFont);

							e.Graphics.DrawString(strText, DataFont, Brushes.Black, nX + (m_CaseColumns[4].Width / 2) - (TextSize.Width / 2), nY);

							nX += (m_CaseColumns[4].Width + 10);

							// On Hand

							strText = String.Format("{0:F0}", m_DataFiles.SupplyQuantity(Supply));

							TextSize = e.Graphics.MeasureString(strText, DataFont);

							e.Graphics.DrawString(strText, DataFont, Brushes.Black, nX + (m_CaseColumns[5].Width / 2) - (TextSize.Width / 2), nY);

							nX += (m_CaseColumns[5].Width + 10);

							// Value

							strText = String.Format("{0}{1:F2}", m_DataFiles.Preferences.Currency, m_DataFiles.SupplyCostEach(Supply) * m_DataFiles.SupplyQuantity(Supply));

							TextSize = e.Graphics.MeasureString(strText, DataFont);

							e.Graphics.DrawString(strText, DataFont, Brushes.Black, nX + m_CaseColumns[6].Width - TextSize.Width, nY);

							nX = nLeftMargin;

							nY += TextSize.Height;

							break;

						//----------------------------------------------------------------------------*
						// Ammo
						//----------------------------------------------------------------------------*

						case cSupply.eSupplyTypes.Ammo:
							cAmmo Ammo = (cAmmo)Supply;

							// Ammo

							strText = Ammo.ToShortString();

							nX = nLeftMargin;

							e.Graphics.DrawString(strText, DataFont, Brushes.Black, nX, nY);

							nX += (m_AmmoColumns[0].Width + 10);

							// Purchases

							strText = String.Format("{0:F0}", SupplyTotals.PurchaseQty + SupplyTotals.InitialStockQty);

							TextSize = e.Graphics.MeasureString(strText, DataFont);

							e.Graphics.DrawString(strText, DataFont, Brushes.Black, nX + (m_AmmoColumns[1].Width / 2) - (TextSize.Width / 2), nY);

							nX += (m_AmmoColumns[1].Width + 10);

							// Purchase Costs

							strText = String.Format("{0}{1:F2}", m_DataFiles.Preferences.Currency, SupplyTotals.PurchaseTotal + SupplyTotals.InitialStockTotal);

							TextSize = e.Graphics.MeasureString(strText, DataFont);

							e.Graphics.DrawString(strText, DataFont, Brushes.Black, nX + (m_AmmoColumns[2].Width / 2) - (TextSize.Width / 2), nY);

							nX += (m_AmmoColumns[2].Width + 10);

							// Adjustments

							strText = String.Format("{0:F0}", SupplyTotals.AdjustmentsQty);

							TextSize = e.Graphics.MeasureString(strText, DataFont);

							e.Graphics.DrawString(strText, DataFont, Brushes.Black, nX + (m_AmmoColumns[3].Width / 2) - (TextSize.Width / 2), nY);

							nX += (m_AmmoColumns[3].Width + 10);

							// Used

							strText = String.Format("{0:F0}", Math.Abs(SupplyTotals.FiredQty));

							TextSize = e.Graphics.MeasureString(strText, DataFont);

							e.Graphics.DrawString(strText, DataFont, Brushes.Black, nX + (m_AmmoColumns[4].Width / 2) - (TextSize.Width / 2), nY);

							nX += (m_AmmoColumns[4].Width + 10);

							// On Hand

							strText = String.Format("{0:F0}", m_DataFiles.SupplyQuantity(Supply));

							TextSize = e.Graphics.MeasureString(strText, DataFont);

							e.Graphics.DrawString(strText, DataFont, Brushes.Black, nX + (m_AmmoColumns[5].Width / 2) - (TextSize.Width / 2), nY);

							nX += (m_AmmoColumns[5].Width + 10);

							// Value

							strText = String.Format("{0}{1:F2}", m_DataFiles.Preferences.Currency, m_DataFiles.SupplyCostEach(Supply) * m_DataFiles.SupplyQuantity(Supply));

							TextSize = e.Graphics.MeasureString(strText, DataFont);

							e.Graphics.DrawString(strText, DataFont, Brushes.Black, nX + m_AmmoColumns[6].Width - TextSize.Width, nY);

							nX = nLeftMargin;

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
		// PopulateSupplyList()
		//============================================================================*

		private void PopulateSupplyList()
			{
			m_SupplyList = m_Parms.SupplyList();

			}

		//============================================================================*
		// ResetPrintedFlag()
		//============================================================================*

		private void ResetPrintedFlag()
			{
			m_fOverviewPrinted = false;

			//----------------------------------------------------------------------------*
			// Reset the Supplies
			//----------------------------------------------------------------------------*

			foreach (cBullet Bullet in m_DataFiles.BulletList)
				Bullet.Printed = false;

			foreach (cCase Case in m_DataFiles.CaseList)
				Case.Printed = false;

			foreach (cPowder Powder in m_DataFiles.PowderList)
				Powder.Printed = false;

			foreach (cPrimer Primer in m_DataFiles.PrimerList)
				Primer.Printed = false;

			foreach (cAmmo Ammo in m_DataFiles.AmmoList)
				Ammo.Printed = false;
			}
		}
	}
