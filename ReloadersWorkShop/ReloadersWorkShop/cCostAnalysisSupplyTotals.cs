//============================================================================*
// cCostAnalysisParms.cs
//
// Copyright © 2013-2014, Kevin S. Beebe
// All Rights Reserved
//============================================================================*

//============================================================================*
// .Net Using Statements
//============================================================================*

using System;

//============================================================================*
// NameSpace
//============================================================================*

namespace ReloadersWorkShop
	{
	//============================================================================*
	// cCostAnalysisSupplyTotals class
	//============================================================================*

	public class cCostAnalysisSupplyTotals
		{
		//============================================================================*
		// Private Data Members
		//============================================================================*

		private int m_nNumTransactions = 0;

		private int m_nNumPurchases = 0;
		private double m_dPurchaseQty = 0.0;
		private double m_dPurchaseTotal = 0.0;

		private int m_nNumInitialStock = 0;
		private double m_dInitialStockQty = 0.0;
		private double m_dInitialStockTotal = 0.0;

		private int m_nNumAdjustments = 0;
		private double m_dAdjustmentQty = 0.0;
		private double m_dAdjustmentTotal = 0.0;

		private int m_nNumFired = 0;
		private double m_dFiredQty = 0.0;
		private double m_dFiredTotal = 0.0;

		private int m_nNumUsed = 0;
		private double m_dUsedQty = 0.0;
		private double m_dUsedTotal = 0.0;

		private double m_dInStockQty = 0.0;
		private double m_dInStockTotal = 0.0;

		//============================================================================*
		// cCostAnalysisSupplyTotals()
		//============================================================================*

		public cCostAnalysisSupplyTotals()
			{
			}

		//============================================================================*
		// operator +()
		//============================================================================*

		public static cCostAnalysisSupplyTotals operator +(cCostAnalysisSupplyTotals Totals1, cCostAnalysisSupplyTotals Totals2)
			{
			Totals1.m_dAdjustmentQty += Totals2.m_dAdjustmentQty;
			Totals1.m_dAdjustmentTotal += Totals2.m_dAdjustmentTotal;
			Totals1.m_dFiredQty += Totals2.m_dFiredQty;
			Totals1.m_dFiredTotal += Totals2.m_dFiredTotal;
			Totals1.m_dInitialStockQty += Totals2.m_dInitialStockQty;
			Totals1.m_dInitialStockTotal += Totals2.m_dInitialStockTotal;
			Totals1.InStockQty += Totals2.InStockQty;
			Totals1.InStockTotal += Totals2.InStockTotal;
			Totals1.m_dPurchaseQty += Totals2.m_dPurchaseQty;
			Totals1.m_dPurchaseTotal += Totals2.m_dPurchaseTotal;
			Totals1.m_dUsedQty += Totals2.m_dUsedQty;
			Totals1.m_dUsedTotal += Totals2.m_dUsedTotal;
			Totals1.m_nNumAdjustments += Totals2.m_nNumAdjustments;
			Totals1.m_nNumFired += Totals2.m_nNumFired;
			Totals1.m_nNumInitialStock += Totals2.m_nNumInitialStock;
			Totals1.m_nNumPurchases += Totals2.m_nNumPurchases;
			Totals1.m_nNumTransactions += Totals2.m_nNumTransactions;
			Totals1.m_nNumUsed += Totals2.m_nNumUsed;

			return(Totals1);
			}

		//============================================================================*
		// AdjustmentsQty Property
		//============================================================================*

		public double AdjustmentsQty
			{
			get { return (m_dAdjustmentQty); }
			set { m_dAdjustmentQty = value; }
			}

		//============================================================================*
		// AdjustmentsTotal Property
		//============================================================================*

		public double AdjustmentsTotal
			{
			get { return (m_dAdjustmentTotal); }
			set { m_dAdjustmentTotal = value; }
			}

		//============================================================================*
		// FiredQty Property
		//============================================================================*

		public double FiredQty
			{
			get { return (m_dFiredQty); }
			set { m_dFiredQty = value; }
			}

		//============================================================================*
		// FiredTotal Property
		//============================================================================*

		public double FiredTotal
			{
			get { return (m_dFiredTotal); }
			set { m_dFiredTotal = value; }
			}

		//============================================================================*
		// InitialStockQty Property
		//============================================================================*

		public double InitialStockQty
			{
			get { return (m_dInitialStockQty); }
			set { m_dInitialStockQty = value; }
			}

		//============================================================================*
		// InitialStockTotal Property
		//============================================================================*

		public double InitialStockTotal
			{
			get { return (m_dInitialStockTotal); }
			set { m_dInitialStockTotal = value; }
			}

		//============================================================================*
		// InStockQty Property
		//============================================================================*

		public double InStockQty
			{
			get { return (m_dInStockQty); }
			set { m_dInStockQty = value; }
			}

		//============================================================================*
		// InStockTotal Property
		//============================================================================*

		public double InStockTotal
			{
			get { return (m_dInStockTotal); }
			set { m_dInStockTotal = value; }
			}

		//============================================================================*
		// NumAdjustments Property
		//============================================================================*

		public int NumAdjustments
			{
			get { return (m_nNumAdjustments); }
			set { m_nNumAdjustments = value; }
			}

		//============================================================================*
		// NumFired Property
		//============================================================================*

		public int NumFired
			{
			get { return (m_nNumFired); }
			set { m_nNumFired = value; }
			}

		//============================================================================*
		// NumInitialStock Property
		//============================================================================*

		public int NumInitialStock
			{
			get { return (m_nNumInitialStock); }
			set { m_nNumInitialStock = value; }
			}

		//============================================================================*
		// NumPurchases Property
		//============================================================================*

		public int NumPurchases
			{
			get { return(m_nNumPurchases); }
			set { m_nNumPurchases = value; }
			}

		//============================================================================*
		// NumTransactions Property
		//============================================================================*

		public int NumTransactions
			{
			get { return (m_nNumTransactions); }
			set { m_nNumTransactions = value; }
			}

		//============================================================================*
		// NumUsed Property
		//============================================================================*

		public int NumUsed
			{
			get { return (m_nNumUsed); }
			set { m_nNumUsed = value; }
			}

		//============================================================================*
		// PurchaseQty Property
		//============================================================================*

		public double PurchaseQty
			{
			get { return (m_dPurchaseQty); }
			set { m_dPurchaseQty = value; }
			}

		//============================================================================*
		// PurchaseTotal Property
		//============================================================================*

		public double PurchaseTotal
			{
			get { return (m_dPurchaseTotal); }
			set { m_dPurchaseTotal = value; }
			}

		//============================================================================*
		// UsedQty Property
		//============================================================================*

		public double UsedQty
			{
			get { return (m_dUsedQty); }
			set { m_dUsedQty = value; }
			}

		//============================================================================*
		// UsedTotal Property
		//============================================================================*

		public double UsedTotal
			{
			get { return (m_dUsedTotal); }
			set { m_dUsedTotal = value; }
			}
		}
	}
