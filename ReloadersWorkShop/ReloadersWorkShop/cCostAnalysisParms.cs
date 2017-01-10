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
	// cCostAnalysisParms class
	//============================================================================*

	public class cCostAnalysisParms
		{
		//============================================================================*
		// Private Data Members
		//============================================================================*

		private cDataFiles m_DataFiles = null;

		private cManufacturer m_Manufacturer = null;

		private bool m_fOverview = true;
		private bool m_fComponents = true;
		private bool m_fActivity = true;

		private bool m_fPurchases = true;
		private bool m_fInitialStock = true;
		private bool m_fAdjustments = true;
		private bool m_fFired = true;

		private string m_strLocation = "";

		private bool m_fBullets = true;
		private bool m_fCases = true;
		private bool m_fPowder = true;
		private bool m_fPrimers = true;
		private bool m_fAmmo = true;
		private bool m_fReloads = true;

		private DateTime m_StartDate = new DateTime(2010, 1, 1);
		private DateTime m_EndDate = DateTime.Now;

		//============================================================================*
		// cCostAnalysisParms() - Constructor
		//============================================================================*

		public cCostAnalysisParms(cDataFiles Datafiles)
			{
			m_DataFiles = Datafiles;
			}

		//============================================================================*
		// cCostAnalysisParms() - Copy Constructor
		//============================================================================*

		public cCostAnalysisParms(cCostAnalysisParms Parms)
			{
			m_DataFiles = Parms.m_DataFiles;

			m_Manufacturer = Parms.m_Manufacturer;

			m_fOverview = Parms.m_fOverview;
			m_fComponents = Parms.m_fComponents;
			m_fActivity = Parms.m_fActivity;

			m_fPurchases = Parms.m_fPurchases;
			m_fInitialStock = Parms.m_fInitialStock;
			m_fAdjustments = Parms.m_fAdjustments;
			m_fFired = Parms.m_fFired;

			m_strLocation = Parms.m_strLocation;

			m_fAmmo = Parms.m_fAmmo;
			m_fBullets = Parms.m_fBullets;
			m_fCases = Parms.m_fCases;
			m_fPowder = Parms.m_fPowder;
			m_fPrimers = Parms.m_fPrimers;
			m_fReloads = Parms.m_fReloads;

			m_StartDate = Parms.StartDate;
			m_EndDate = Parms.m_EndDate;
			}

		//============================================================================*
		// Activity Property
		//============================================================================*

		public bool Activity
			{
			get { return (m_fActivity); }
			set	{ m_fActivity = value; }
			}

		//============================================================================*
		// Adjustments Property
		//============================================================================*

		public bool Adjustments
			{
			get { return (m_fAdjustments); }

			set
				{
				m_fAdjustments = value;

				CheckTransactions();
				}
			}

		//============================================================================*
		// Ammo Property
		//============================================================================*

		public bool Ammo
			{
			get { return (m_fAmmo); }

			set
				{
				m_fAmmo = value;

				if (m_fAmmo && m_Manufacturer != null && (!Manufacturer.Ammo || Manufacturer.Name == "Batch Editor"))
					m_Manufacturer = null;
				}
			}

		//============================================================================*
		// Bullets Property
		//============================================================================*

		public bool Bullets
			{
			get { return (m_fBullets); }
			set
				{
				m_fBullets = value;

				if (m_Manufacturer != null && !Manufacturer.Bullets)
					m_Manufacturer = null;
				}
			}

		//============================================================================*
		// Cases Property
		//============================================================================*

		public bool Cases
			{
			get { return (m_fCases); }
			set
				{
				m_fCases = value;

				if (m_Manufacturer != null && !Manufacturer.Cases)
					m_Manufacturer = null;
				}
			}

		//============================================================================*
		// CheckTransactions()
		//============================================================================*

		private void CheckTransactions()
			{
			if (!m_fPurchases && !m_fInitialStock && !m_fAdjustments && !m_fFired)
				m_fPurchases = true;
			}

		//============================================================================*
		// Components Property
		//============================================================================*

		public bool Components
			{
			get { return (m_fComponents); }

			set
				{
				m_fComponents = value;

				if (!m_fComponents)
					{
					m_fActivity = false;

					m_fOverview = true;
					}
				}
			}

		//============================================================================*
		// EndDate Property
		//============================================================================*

		public DateTime EndDate
			{
			get { return (m_EndDate); }

			set
				{
				m_EndDate = new DateTime(value.Year, value.Month, value.Day, 23, 59, 59);

				if (m_EndDate < m_StartDate)
					m_EndDate = new DateTime(m_StartDate.Year, m_StartDate.Month, m_StartDate.Day, 23, 59, 59);
				}
			}

		//============================================================================*
		// Fired Property
		//============================================================================*

		public bool Fired
			{
			get { return (m_fFired); }

			set
				{
				m_fFired = value;

				CheckTransactions();
				}
			}

		//============================================================================*
		// IncludeTransaction()
		//============================================================================*

		private bool IncludeTransaction(cTransaction Transaction)
			{
			//----------------------------------------------------------------------------*
			// Check Date Filters
			//----------------------------------------------------------------------------*

			if (Transaction.Date < m_StartDate || Transaction.Date > m_EndDate)
				return (false);

			//----------------------------------------------------------------------------*
			// Check Manufacturer if one is set
			//----------------------------------------------------------------------------*

			if (m_Manufacturer != null)
				{
				if (Transaction.Supply.Manufacturer.CompareTo(m_Manufacturer) != 0)
					return (false);
				}

			//----------------------------------------------------------------------------*
			// Check Transaction Types
			//----------------------------------------------------------------------------*

			switch (Transaction.TransactionType)
				{
				//----------------------------------------------------------------------------*
				// Set Stock Level
				//----------------------------------------------------------------------------*

				case cTransaction.eTransactionType.SetStockLevel:
					if (!m_fInitialStock)
						return (false);

					break;

				//----------------------------------------------------------------------------*
				// Check Purchase
				//----------------------------------------------------------------------------*

				case cTransaction.eTransactionType.Purchase:
					if (!m_fPurchases)
						return (false);

					//----------------------------------------------------------------------------*
					// Check Purchase Location
					//----------------------------------------------------------------------------*

					if (!String.IsNullOrEmpty(m_strLocation))
						{
						if (m_strLocation.ToUpper() != Transaction.Source.ToUpper())
							return(false);
						}

					break;

				//----------------------------------------------------------------------------*
				// Check Adjustments
				//----------------------------------------------------------------------------*

				case cTransaction.eTransactionType.AddStock:
				case cTransaction.eTransactionType.ReduceStock:
					if (!m_fAdjustments)
						return (false);

					break;

				//----------------------------------------------------------------------------*
				// Check Fired
				//----------------------------------------------------------------------------*

				case cTransaction.eTransactionType.Fired:
					if (!m_fFired)
						return (false);

					break;

				//----------------------------------------------------------------------------*
				// Unknown Transaction Type, return false
				//----------------------------------------------------------------------------*

				default:
					return (false);
				}

			//----------------------------------------------------------------------------*
			// If we get to here, it must be ok
			//----------------------------------------------------------------------------*

			return (true);
			}

		//============================================================================*
		// InitialStock Property
		//============================================================================*

		public bool InitialStock
			{
			get { return (m_fInitialStock); }

			set
				{
				m_fInitialStock = value;

				CheckTransactions();
				}
			}

		//============================================================================*
		// Location Property
		//============================================================================*

		public string Location
			{
			get { return (m_strLocation); }
			set { m_strLocation = value; }
			}

		//============================================================================*
		// Manufacturer Property
		//============================================================================*

		public cManufacturer Manufacturer
			{
			get { return (m_Manufacturer); }

			set
				{
				m_Manufacturer = value;

				if (m_Manufacturer == null)
					return;

				if (m_Manufacturer.Name == "Batch Editor")
					{
					m_fReloads = true;

					m_fAmmo = false;
					m_fBullets = false;
					m_fCases = false;
					m_fPowder = false;
					m_fPrimers = false;

					return;
					}
				else
					m_fReloads = false;

				if (!Manufacturer.Ammo)
					{
					m_fReloads = false;
					m_fAmmo = false;
					}

				if (!m_Manufacturer.Bullets && !m_Manufacturer.BulletMolds)
					m_fBullets = false;

				if (!Manufacturer.Cases)
					m_fCases = false;

				if (!m_Manufacturer.Powder)
					m_fPowder = false;

				if (!m_Manufacturer.Primers)
					m_fPrimers = false;
				}
			}

		//============================================================================*
		// ManufacturerList Property
		//============================================================================*

		public cManufacturerList ManufacturerList
			{
			get
				{
				cManufacturerList ManufacturerList = new cManufacturerList();

				//----------------------------------------------------------------------------*
				// Loop through the manufacturers
				//----------------------------------------------------------------------------*

				foreach (cManufacturer Manufacturer in m_DataFiles.ManufacturerList)
					{
					bool fInclude = false;

					//----------------------------------------------------------------------------*
					// Bullets?
					//----------------------------------------------------------------------------*

					if (m_fBullets && (Manufacturer.Bullets || Manufacturer.BulletMolds))
						{
						foreach (cBullet Bullet in m_DataFiles.BulletList)
							{
							if ((!m_DataFiles.Preferences.HideUncheckedSupplies || Bullet.Checked) &&
								Bullet.Manufacturer.CompareTo(Manufacturer) == 0)
								{
								fInclude = true;

								break;
								}
							}
						}

					//----------------------------------------------------------------------------*
					// Cases?
					//----------------------------------------------------------------------------*

					if (m_fCases && Manufacturer.Cases)
						{
						foreach (cCase Case in m_DataFiles.CaseList)
							{
							if ((!m_DataFiles.Preferences.HideUncheckedSupplies || Case.Checked) &&
								Case.Manufacturer.CompareTo(Manufacturer) == 0)
								{
								fInclude = true;

								break;
								}
							}
						}

					//----------------------------------------------------------------------------*
					// Powder?
					//----------------------------------------------------------------------------*

					if (m_fPowder && Manufacturer.Powder)
						{
						foreach (cPowder Powder in m_DataFiles.PowderList)
							{
							if ((!m_DataFiles.Preferences.HideUncheckedSupplies || Powder.Checked) &&
								Powder.Manufacturer.CompareTo(Manufacturer) == 0)
								{
								fInclude = true;

								break;
								}
							}
						}

					//----------------------------------------------------------------------------*
					// Primers?
					//----------------------------------------------------------------------------*

					if (m_fPrimers && Manufacturer.Primers)
						{
						foreach (cPrimer Primer in m_DataFiles.PrimerList)
							{
							if ((!m_DataFiles.Preferences.HideUncheckedSupplies || Primer.Checked) &&
								Primer.Manufacturer.CompareTo(Manufacturer) == 0)
								{
								fInclude = true;

								break;
								}
							}
						}


					//----------------------------------------------------------------------------*
					// Reloaded Ammo?
					//----------------------------------------------------------------------------*

					if (m_fReloads && Manufacturer.Name == "Batch Editor")
						fInclude = true;

					//----------------------------------------------------------------------------*
					// Ammo?
					//----------------------------------------------------------------------------*

					if (m_fAmmo && Manufacturer.Ammo && Manufacturer.Name != "Batch Editor")
						fInclude = true;

					//----------------------------------------------------------------------------*
					// Include the manufacturer if it supplies one of the checked components
					//----------------------------------------------------------------------------*

					if (fInclude)
						ManufacturerList.Add(Manufacturer);
					}

				return (ManufacturerList);
				}
			}

		//============================================================================*
		// Overview Property
		//============================================================================*

		public bool Overview
			{
			get { return (m_fOverview); }

			set
				{
				m_fOverview = value;

				if (!m_fOverview)
					m_fComponents = true;
				}
			}

		//============================================================================*
		// ParmsOK Property
		//============================================================================*

		public bool ParmsOK
			{
			get
				{
				if (!TransactionsExist())
					return (false);

				return (true);
				}
			}

		//============================================================================*
		// Powder Property
		//============================================================================*

		public bool Powder
			{
			get { return (m_fPowder); }
			set
				{
				m_fPowder = value;

				if (m_Manufacturer != null && !Manufacturer.Powder)
					m_Manufacturer = null;
				}
			}

		//============================================================================*
		// Primers Property
		//============================================================================*

		public bool Primers
			{
			get { return (m_fPrimers); }

			set
				{
				m_fPrimers = value;

				if (m_Manufacturer != null && !Manufacturer.Primers)
					m_Manufacturer = null;
				}
			}

		//============================================================================*
		// Purchases Property
		//============================================================================*

		public bool Purchases
			{
			get { return (m_fPurchases); }

			set
				{
				m_fPurchases = value;

				CheckTransactions();
				}
			}

		//============================================================================*
		// Reloads Property
		//============================================================================*

		public bool Reloads
			{
			get { return (m_fReloads); }
			set
				{
				m_fReloads = value;

				if (m_Manufacturer != null && (!Manufacturer.Ammo || Manufacturer.Name != "Batch Editor"))
					m_Manufacturer = null;
				}
			}

		//============================================================================*
		// StartDate Property
		//============================================================================*

		public DateTime StartDate
			{
			get { return (m_StartDate); }

			set
				{
				m_StartDate = new DateTime(value.Year, value.Month, value.Day, 0, 0, 0);

				if (m_StartDate > m_EndDate)
					m_StartDate = new DateTime(m_EndDate.Year, m_EndDate.Month, m_EndDate.Day, 0, 0, 0);
				}
			}

		//============================================================================*
		// SupplyList()
		//============================================================================*

		public cSupplyList SupplyList()
			{
			cSupplyList SupplyList = new cSupplyList();

			// Bullets

			if (m_fBullets)
				{
				foreach (cSupply Supply in m_DataFiles.BulletList)
					{
					if (Supply.TransactionList.Count == 0)
						continue;

					bool fTransactionFound = false;

					foreach (cTransaction Transaction in Supply.TransactionList)
						{
						if (IncludeTransaction(Transaction))
							{
							fTransactionFound = true;

							break;
							}
						}

					if (fTransactionFound)
						{
						if (!SupplyList.Contains(Supply))
							SupplyList.AddSupply(Supply);
						}
					}
				}

			// Cases

			if (m_fCases)
				{
				foreach (cSupply Supply in m_DataFiles.CaseList)
					{
					if (Supply.TransactionList.Count == 0)
						continue;

					bool fTransactionFound = false;

					foreach (cTransaction Transaction in Supply.TransactionList)
						{
						if (IncludeTransaction(Transaction))
							{
							fTransactionFound = true;

							break;
							}
						}

					if (fTransactionFound)
						{
						if (!SupplyList.Contains(Supply))
							SupplyList.AddSupply(Supply);
						}
					}
				}

			// Powder

			if (m_fPowder)
				{
				foreach (cSupply Supply in m_DataFiles.PowderList)
					{
					if (Supply.TransactionList.Count == 0)
						continue;

					bool fTransactionFound = false;

					foreach (cTransaction Transaction in Supply.TransactionList)
						{
						if (IncludeTransaction(Transaction))
							{
							fTransactionFound = true;

							break;
							}
						}

					if (fTransactionFound)
						{
						if (!SupplyList.Contains(Supply))
							SupplyList.AddSupply(Supply);
						}
					}
				}

			// Primers

			if (m_fPrimers)
				{
				foreach (cSupply Supply in m_DataFiles.PrimerList)
					{
					if (Supply.TransactionList.Count == 0)
						continue;

					bool fTransactionFound = false;

					foreach (cTransaction Transaction in Supply.TransactionList)
						{
						if (IncludeTransaction(Transaction))
							{
							fTransactionFound = true;

							break;
							}
						}

					if (fTransactionFound)
						{
						if (!SupplyList.Contains(Supply))
							SupplyList.AddSupply(Supply);
						}
					}
				}

			// Ammo

			if (m_fReloads || m_fAmmo)
				{
				foreach (cSupply Supply in m_DataFiles.AmmoList)
					{
					if (Supply.TransactionList.Count == 0)
						continue;

					bool fTransactionFound = false;

					foreach (cTransaction Transaction in Supply.TransactionList)
						{
						if (IncludeTransaction(Transaction))
							{
							fTransactionFound = true;

							break;
							}
						}

					if (fTransactionFound)
						{
						if (!SupplyList.Contains(Supply))
							SupplyList.AddSupply(Supply);
						}
					}
				}

			return (SupplyList);
			}

		//============================================================================*
		// SupplyTotals()
		//============================================================================*

		public cCostAnalysisSupplyTotals SupplyTotals(cSupply Supply)
			{
			cCostAnalysisSupplyTotals SupplyTotals = new cCostAnalysisSupplyTotals();

			SupplyTotals.InStockQty += m_DataFiles.SupplyQuantity(Supply);
			SupplyTotals.InStockTotal += m_DataFiles.SupplyCost(Supply);

			//----------------------------------------------------------------------------*
			// Loop through the supply transactions
			//----------------------------------------------------------------------------*

			foreach (cTransaction Transaction in Supply.TransactionList)
				{
				//----------------------------------------------------------------------------*
				// See if this transaction meets the filter criteria
				//----------------------------------------------------------------------------*

				if (IncludeTransaction(Transaction))
					{
					//----------------------------------------------------------------------------*
					// Add to the overall totals
					//----------------------------------------------------------------------------*

					SupplyTotals.NumTransactions++;

					//----------------------------------------------------------------------------*
					// Determine the Transaction type
					//----------------------------------------------------------------------------*

					switch (Transaction.TransactionType)
						{
						//----------------------------------------------------------------------------*
						// Purchase
						//----------------------------------------------------------------------------*

						case cTransaction.eTransactionType.Purchase:
							SupplyTotals.NumPurchases++;
							SupplyTotals.PurchaseQty += Transaction.Quantity;
							SupplyTotals.PurchaseTotal += Transaction.Cost;

							if (m_DataFiles.Preferences.IncludeTaxShipping)
								SupplyTotals.PurchaseTotal += (Transaction.Tax + Transaction.Shipping);

							break;

						//----------------------------------------------------------------------------*
						// SetStockLevel
						//----------------------------------------------------------------------------*

						case cTransaction.eTransactionType.SetStockLevel:
							if (Supply.SupplyType != cSupply.eSupplyTypes.Ammo || Transaction.BatchID == 0)
								{
								SupplyTotals.NumInitialStock++;
								SupplyTotals.InitialStockQty += Transaction.Quantity;
								SupplyTotals.InitialStockTotal += Transaction.Cost;

								if (m_DataFiles.Preferences.IncludeTaxShipping)
									SupplyTotals.InitialStockTotal += (Transaction.Tax + Transaction.Shipping);
								}
							else
								{
								SupplyTotals.NumInitialStock++;
								SupplyTotals.InitialStockQty += Transaction.Quantity;
								SupplyTotals.InitialStockTotal += m_DataFiles.BatchCost(Transaction.BatchID);
								}

							break;

						//----------------------------------------------------------------------------*
						// AddStock
						//----------------------------------------------------------------------------*

						case cTransaction.eTransactionType.AddStock:
							SupplyTotals.NumAdjustments++;
							SupplyTotals.AdjustmentsQty += Transaction.Quantity;
							SupplyTotals.AdjustmentsTotal += Transaction.Cost;

							if (m_DataFiles.Preferences.IncludeTaxShipping)
								SupplyTotals.AdjustmentsTotal += (Transaction.Tax + Transaction.Shipping);

							break;

						//----------------------------------------------------------------------------*
						// ReduceStock
						//----------------------------------------------------------------------------*

						case cTransaction.eTransactionType.ReduceStock:
							if (Supply.SupplyType == cSupply.eSupplyTypes.Ammo)
								{
								SupplyTotals.NumAdjustments++;
								SupplyTotals.AdjustmentsQty -= Transaction.Quantity;
								SupplyTotals.AdjustmentsTotal -= Transaction.Cost;
								}
							else
								{
								if (Transaction.BatchID == 0)
									{
									SupplyTotals.NumAdjustments++;
									SupplyTotals.AdjustmentsQty -= Transaction.Quantity;
									SupplyTotals.AdjustmentsTotal -= Transaction.Cost;
									}
								else
									{
									SupplyTotals.NumUsed++;

									switch (Supply.SupplyType)
										{
										case cSupply.eSupplyTypes.Bullets:
											SupplyTotals.UsedQty -= Transaction.Quantity;
											SupplyTotals.UsedTotal -= m_DataFiles.BatchBulletCost(Transaction.BatchID);
											break;

										case cSupply.eSupplyTypes.Cases:
											SupplyTotals.UsedQty -= Transaction.Quantity;
											SupplyTotals.UsedTotal -= m_DataFiles.BatchCaseCost(Transaction.BatchID);
											break;

										case cSupply.eSupplyTypes.Powder:
											SupplyTotals.UsedQty -= Transaction.Quantity;
											SupplyTotals.UsedTotal -= m_DataFiles.BatchPowderCost(Transaction.BatchID);
											break;

										case cSupply.eSupplyTypes.Primers:
											SupplyTotals.UsedQty -= Transaction.Quantity;
											SupplyTotals.UsedTotal -= m_DataFiles.BatchPrimerCost(Transaction.BatchID);
											break;
										}
									}
								}

							break;

						//----------------------------------------------------------------------------*
						// Fired
						//----------------------------------------------------------------------------*

						case cTransaction.eTransactionType.Fired:
							SupplyTotals.NumFired++;

							SupplyTotals.FiredQty += Transaction.Quantity;
							SupplyTotals.FiredTotal += Transaction.Cost;

							break;
						}
					}
				}

			if (Supply.SupplyType == cSupply.eSupplyTypes.Powder)
				{
				SupplyTotals.AdjustmentsQty /= 7000.0;
				SupplyTotals.FiredQty /= 7000.0;
				SupplyTotals.InitialStockQty /= 7000.0;
				SupplyTotals.InStockQty /= 7000.0;
				SupplyTotals.PurchaseQty /= 7000.0;
				SupplyTotals.UsedQty /= 7000.0;

				SupplyTotals.AdjustmentsQty = cDataFiles.StandardToMetric(SupplyTotals.AdjustmentsQty, cDataFiles.eDataType.CanWeight);
				SupplyTotals.FiredQty = cDataFiles.StandardToMetric(SupplyTotals.FiredQty, cDataFiles.eDataType.CanWeight);
				SupplyTotals.InitialStockQty = cDataFiles.StandardToMetric(SupplyTotals.InitialStockQty, cDataFiles.eDataType.CanWeight);
				SupplyTotals.InStockQty = cDataFiles.StandardToMetric(SupplyTotals.InStockQty, cDataFiles.eDataType.CanWeight);
				SupplyTotals.PurchaseQty = cDataFiles.StandardToMetric(SupplyTotals.PurchaseQty, cDataFiles.eDataType.CanWeight);
				SupplyTotals.UsedQty = cDataFiles.StandardToMetric(SupplyTotals.UsedQty, cDataFiles.eDataType.CanWeight);
				}

			return (SupplyTotals);
			}

		//============================================================================*
		// TransactionsExist()
		//============================================================================*

		public bool TransactionsExist()
			{
			//----------------------------------------------------------------------------*
			// Check Ammo
			//----------------------------------------------------------------------------*

			if (m_fAmmo || m_fReloads)
				{
				foreach (cAmmo Supply in m_DataFiles.AmmoList)
					{
					foreach (cTransaction Transaction in Supply.TransactionList)
						{
						if (IncludeTransaction(Transaction))
							return (true);
						}
					}
				}

			//----------------------------------------------------------------------------*
			// Check Bullets
			//----------------------------------------------------------------------------*

			if (m_fBullets)
				{
				foreach (cBullet Supply in m_DataFiles.BulletList)
					{
					foreach (cTransaction Transaction in Supply.TransactionList)
						{
						if (IncludeTransaction(Transaction))
							return (true);
						}
					}
				}

			//----------------------------------------------------------------------------*
			// Check Cases
			//----------------------------------------------------------------------------*

			if (m_fCases)
				{
				foreach (cCase Supply in m_DataFiles.CaseList)
					{
					foreach (cTransaction Transaction in Supply.TransactionList)
						{
						if (IncludeTransaction(Transaction))
							return (true);
						}
					}
				}

			//----------------------------------------------------------------------------*
			// Check Powder
			//----------------------------------------------------------------------------*

			if (m_fPowder)
				{
				foreach (cPowder Supply in m_DataFiles.PowderList)
					{
					foreach (cTransaction Transaction in Supply.TransactionList)
						{
						if (IncludeTransaction(Transaction))
							return (true);
						}
					}
				}

			//----------------------------------------------------------------------------*
			// Check Primers
			//----------------------------------------------------------------------------*

			if (m_fPrimers)
				{
				foreach (cPrimer Supply in m_DataFiles.PrimerList)
					{
					foreach (cTransaction Transaction in Supply.TransactionList)
						{
						if (IncludeTransaction(Transaction))
							return (true);
						}
					}
				}

			return (false);
			}
		}
	}
