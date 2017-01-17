//============================================================================*
// cSupply.cs
//
// Copyright © 2013-2017, Kevin S. Beebe
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
	// cSupply class
	//============================================================================*

	[Serializable]
	public partial class cSupply : cPrintObject, IComparable
		{
		//----------------------------------------------------------------------------*
		// Public Enumerations
		//----------------------------------------------------------------------------*

		public enum eSupplyTypes
			{
			Unknown = -1,
			Bullets = 0,
			Cases,
			Powder,
			Primers,
			Ammo,
			NumSupplyTypes
			};

		//----------------------------------------------------------------------------*
		// Private Data Members
		//----------------------------------------------------------------------------*

		private eSupplyTypes m_eType;

		private cFirearm.eFireArmType m_eFirearmType = cFirearm.eFireArmType.Handgun;
		private cManufacturer m_Manufacturer = null;

		private double m_dQuantityOnHand = 0.0;
		private double m_dQuantity = 0.0;

		private DateTime m_LastPurchaseDate = new DateTime(2010, 1, 1);
		private double m_dLastPurchaseQty = 0.0;
		private double m_dLastPurchaseCost = 0.0;

		private double m_dTotalPurchaseQty = 0.0;
		private double m_dTotalPurchaseCost = 0.0;

		private double m_dTotalAdjustQty = 0.0;
		private double m_dTotalUsedQty = 0.0;

		private double m_dCost = 0.0;
		private double m_dCostEach = 0.0;

		private double m_dMinimumStockLevel = 0.0;

		private bool m_fCrossUse = false;

		private bool m_fChecked = false;

		private cTransactionList m_TransactionList = new cTransactionList();

		//----------------------------------------------------------------------------*
		// Temp Variables - No need to export or import
		//----------------------------------------------------------------------------*

		private bool m_fIdentity = false;

		//============================================================================*
		// cSupply() - Constructor
		//============================================================================*

		public cSupply(eSupplyTypes eType, bool fIdentity = false)
			{
			m_eType = eType;
			m_fIdentity = fIdentity;

			m_TransactionList = new cTransactionList();
			}

		//============================================================================*
		// cSupply() - Copy Constructor
		//============================================================================*

		public cSupply(cSupply Supply)
			{
			Copy(Supply);
			}

		//============================================================================*
		// Append()
		//============================================================================*

		public int Append(cSupply Supply, bool fCountOnly = false)
			{
			int nUpdateCount = 0;

			if (m_dQuantity == 0.0 && Supply.m_dQuantity != 0.0)
				{
				if (!fCountOnly)
					m_dQuantity = Supply.m_dQuantity;

				nUpdateCount++;
				}

			if (m_dCost == 0.0 && Supply.m_dCost != 0.0)
				{
				if (!fCountOnly)
					m_dCost = Supply.m_dCost;

				nUpdateCount++;
				}

			if (m_dQuantityOnHand == 0.0 && Supply.m_dQuantityOnHand != 0.0)
				{
				if (!fCountOnly)
					m_dQuantityOnHand = Supply.m_dQuantityOnHand;

				nUpdateCount++;
				}

			if (m_dCostEach == 0.0 && Supply.m_dCostEach != 0.0)
				{
				if (!fCountOnly)
					m_dCostEach = Supply.m_dCostEach;

				nUpdateCount++;
				}

			if (m_dTotalPurchaseQty == 0.0 && Supply.m_dTotalPurchaseQty != 0.0)
				{
				if (!fCountOnly)
					m_dTotalPurchaseQty = Supply.m_dTotalPurchaseQty;

				nUpdateCount++;
				}

			if (m_dTotalPurchaseCost == 0.0 && Supply.m_dTotalPurchaseCost != 0.0)
				{
				if (!fCountOnly)
					m_dTotalPurchaseCost = Supply.m_dTotalPurchaseCost;

				nUpdateCount++;
				}

			if (m_dTotalAdjustQty == 0.0 && Supply.m_dTotalAdjustQty != 0.0)
				{
				if (!fCountOnly)
					m_dTotalAdjustQty = Supply.m_dTotalAdjustQty;

				nUpdateCount++;
				}

			if (m_dTotalUsedQty == 0.0 && Supply.m_dTotalUsedQty != 0.0)
				{
				if (!fCountOnly)
					m_dTotalUsedQty = Supply.m_dTotalUsedQty;

				nUpdateCount++;
				}

			if (m_dLastPurchaseQty == 0.0 && Supply.m_dLastPurchaseQty != 0.0)
				{
				if (!fCountOnly)
					m_dLastPurchaseQty = Supply.m_dLastPurchaseQty;

				nUpdateCount++;
				}

			if (m_dLastPurchaseCost == 0.0 && Supply.m_dLastPurchaseCost != 0.0)
				{
				if (!fCountOnly)
					m_dLastPurchaseCost = Supply.m_dLastPurchaseCost;

				nUpdateCount++;
				}

			if (m_dMinimumStockLevel == 0.0 && Supply.m_dMinimumStockLevel != 0.0)
				{
				if (!fCountOnly)
					m_dMinimumStockLevel = Supply.m_dMinimumStockLevel;

				nUpdateCount++;
				}

			if (!m_fCrossUse && Supply.m_fCrossUse)
				{
				if (!fCountOnly)
					m_fCrossUse = Supply.m_fCrossUse;

				nUpdateCount++;
				}

			if (!m_fChecked && Supply.m_fChecked)
				{
				if (!fCountOnly)
					m_fChecked = Supply.m_fChecked;

				nUpdateCount++;
				}

			return (nUpdateCount);
			}

		//============================================================================*
		// Checked Property
		//============================================================================*

		public bool Checked
			{
			get
				{
				return (m_fChecked);
				}
			set
				{
				m_fChecked = value;
				}
			}

		//============================================================================*
		// Comparer()
		//============================================================================*

		public static int Comparer(cSupply Supply1, cSupply Supply2)
			{
			if (Supply1 == null)
				{
				if (Supply2 != null)
					return (-1);
				else
					return (0);
				}
			else
				{
				if (Supply2 == null)
					return (1);
				}

			return (Supply1.CompareTo(Supply2));
			}

		//============================================================================*
		// CompareTo()
		//============================================================================*

		public virtual int CompareTo(Object obj)
			{
			if (obj == null)
				return (1);

			//----------------------------------------------------------------------------*
			// Supply Type
			//----------------------------------------------------------------------------*

			cSupply Supply = (cSupply)obj;

			int rc = m_eType.CompareTo(Supply.m_eType);

			//----------------------------------------------------------------------------*
			// Manufacturer
			//----------------------------------------------------------------------------*

			if (rc == 0)
				{
				if (m_Manufacturer != null)
					{
					rc = m_Manufacturer.CompareTo(Supply.m_Manufacturer);
					}
				else
					{
					if (Supply.m_Manufacturer != null)
						rc = -1;
					else
						rc = 0;
					}

				//----------------------------------------------------------------------------*
				// Firearm Type
				//----------------------------------------------------------------------------*

				if (rc == 0)
					{
					rc = m_eFirearmType.CompareTo(Supply.m_eFirearmType);
					}
				}

			return (rc);
			}

		//============================================================================*
		// Copy()
		//============================================================================*

		public void Copy(cSupply Supply)
			{
			m_eType = Supply.m_eType;
			m_eFirearmType = Supply.m_eFirearmType;
			m_Manufacturer = Supply.m_Manufacturer;

			m_dQuantity = Supply.m_dQuantity;
			m_dCost = Supply.m_dCost;

			m_dQuantityOnHand = Supply.m_dQuantityOnHand;
			m_dCostEach = Supply.m_dCostEach;

			m_dTotalPurchaseQty = Supply.m_dTotalPurchaseQty;
			m_dTotalPurchaseCost = Supply.m_dTotalPurchaseCost;

			m_dTotalAdjustQty = Supply.m_dTotalAdjustQty;
			m_dTotalUsedQty = Supply.m_dTotalUsedQty;

			m_dLastPurchaseQty = Supply.m_dLastPurchaseQty;
			m_dLastPurchaseCost = Supply.m_dLastPurchaseCost;
			m_LastPurchaseDate = Supply.m_LastPurchaseDate;

			m_dMinimumStockLevel = Supply.m_dMinimumStockLevel;

			m_fCrossUse = Supply.m_fCrossUse;

			m_fChecked = Supply.m_fChecked;

			if (Supply.m_TransactionList != null)
				m_TransactionList = new cTransactionList(Supply.m_TransactionList);
			else
				m_TransactionList = new cTransactionList();

			m_fIdentity = Supply.m_fIdentity;
			}

		//============================================================================*
		// Cost Property
		//============================================================================*

		public double Cost
			{
			get
				{
				return (m_dCost);
				}
			set
				{
				m_dCost = value;

				if (m_dQuantity > 0.0)
					m_dCostEach = m_dCost / m_dQuantity;
				}
			}

		//============================================================================*
		// CostEach Property
		//============================================================================*

		public double CostEach
			{
			get
				{
				return (m_dCostEach);
				}
			}

		//============================================================================*
		// CrossUse Property
		//============================================================================*

		public bool CrossUse
			{
			get
				{
				return (m_fCrossUse);
				}
			set
				{
				m_fCrossUse = value;
				}
			}

		//============================================================================*
		// FirearmType Property
		//============================================================================*

		public cFirearm.eFireArmType FirearmType
			{
			get
				{
				return (m_eFirearmType);
				}
			set
				{
				m_eFirearmType = value;
				}
			}

		//============================================================================*
		// Identity Property
		//============================================================================*

		public bool Identity
			{
			get
				{
				return (m_fIdentity);
				}
			}

		//============================================================================*
		// LastPurchaseCost Property
		//============================================================================*

		public double LastPurchaseCost
			{
			get
				{
				return (m_dLastPurchaseCost);
				}
			set
				{
				m_dLastPurchaseCost = value;
				}
			}

		//============================================================================*
		// LastPurchaseDate Property
		//============================================================================*

		public DateTime LastPurchaseDate
			{
			get
				{
				return (m_LastPurchaseDate);
				}
			set
				{
				m_LastPurchaseDate = value;
				}
			}

		//============================================================================*
		// LastPurchaseQty Property
		//============================================================================*

		public double LastPurchaseQty
			{
			get
				{
				return (m_dLastPurchaseQty);
				}
			set
				{
				m_dLastPurchaseQty = value;
				}
			}


		//============================================================================*
		// Manufacturer Property
		//============================================================================*

		public cManufacturer Manufacturer
			{
			get
				{
				return (m_Manufacturer);
				}
			set
				{
				m_Manufacturer = value;
				}
			}

		//============================================================================*
		// MinimumStockLevel Property
		//============================================================================*

		public double MinimumStockLevel
			{
			get
				{
				return (m_dMinimumStockLevel);
				}
			set
				{
				m_dMinimumStockLevel = value;
				}
			}

		//============================================================================*
		// Normalize()
		//============================================================================*

		public void Normalize()
			{
			if (m_dQuantity <= 0.0 || m_dCost <= 0.0)
				{
				m_dQuantity = 0.0;
				m_dCost = 0.0;

				return;
				}

			double dCostEach = 0.0;

			dCostEach = m_dCost / m_dQuantity;

			switch (SupplyType)
				{
				//----------------------------------------------------------------------------*
				// Bullets and Cases - Set to 50 or 100
				//----------------------------------------------------------------------------*

				case cSupply.eSupplyTypes.Bullets:
				case cSupply.eSupplyTypes.Cases:
					if (m_dQuantity >= 100.0)
						m_dQuantity = 100.0;
					else
						m_dQuantity = 50.0;

					break;

				//----------------------------------------------------------------------------*
				// Primers - Set to 100 or 1000
				//----------------------------------------------------------------------------*

				case cSupply.eSupplyTypes.Primers:
					if (m_dQuantity >= 1000.0)
						m_dQuantity = 1000.0;
					else
						m_dQuantity = 100.0;

					break;

				//----------------------------------------------------------------------------*
				// Powder - Set to 1 or 8
				//----------------------------------------------------------------------------*

				case cSupply.eSupplyTypes.Powder:
					if (m_dQuantity >= 8.0 * 7000.0)
						m_dQuantity = 8.0 * 7000.0;
					else
						m_dQuantity = 7000.0;

					break;

				//----------------------------------------------------------------------------*
				// Ammo - Set to 20 or 50
				//----------------------------------------------------------------------------*

				case cSupply.eSupplyTypes.Ammo:
					if (m_eFirearmType == cFirearm.eFireArmType.Handgun)
						m_dQuantity = 50.0;
					else
						m_dQuantity = 20.0;

					break;
				}

			m_dCost = m_dQuantity * dCostEach;
			}

		//============================================================================*
		// Quantity Property
		//============================================================================*

		public double Quantity
			{
			get
				{
				return (m_dQuantity);
				}
			set
				{
				m_dQuantity = value;

				if (m_dQuantity > 0.0)
					m_dCostEach = m_dCost / m_dQuantity;
				}
			}

		//============================================================================*
		// QuantityOnHand Property
		//============================================================================*

		public double QuantityOnHand
			{
			get
				{
				return (m_dQuantityOnHand);
				}
			set
				{
				m_dQuantityOnHand = value;
				}
			}

		//============================================================================*
		// RecalculateInventory()
		//============================================================================*

		public void RecalculateInventory(cDataFiles DataFiles)
			{
			ResetInventoryTotals();

			double dLastQty = 0.0;
			double dLastCost = 0.0;
			DateTime LastDate = new DateTime(1899, 1, 1);

			//----------------------------------------------------------------------------*
			// Loop through the transactions
			//----------------------------------------------------------------------------*

			foreach (cTransaction Transaction in m_TransactionList)
				{
				Transaction.Cost = Math.Round(Transaction.Cost, 4);
				Transaction.Quantity = Math.Round(Transaction.Quantity, 4);
				Transaction.Shipping = Math.Round(Transaction.Shipping, 4);
				Transaction.Tax = Math.Round(Transaction.Tax, 4);

				//----------------------------------------------------------------------------*
				// If this is a batch transaction, recalculate the current costs
				//----------------------------------------------------------------------------*

				if (Transaction.BatchID != 0)
					{
					switch (Transaction.Supply.SupplyType)
						{
						case eSupplyTypes.Ammo:
							if (Transaction.TransactionType == cTransaction.eTransactionType.SetStockLevel)
								Transaction.Cost = DataFiles.BatchCost(Transaction.BatchID);
							else
								Transaction.Cost = DataFiles.BatchCartridgeCost(Transaction.BatchID) * Transaction.Quantity;

							break;

						case eSupplyTypes.Bullets:
							Transaction.Cost = DataFiles.BatchBulletCost(Transaction.BatchID);
							break;

						case eSupplyTypes.Cases:
							Transaction.Cost = DataFiles.BatchCaseCost(Transaction.BatchID);
							break;

						case eSupplyTypes.Powder:
							Transaction.Cost = DataFiles.BatchPowderCost(Transaction.BatchID);
							break;

						case eSupplyTypes.Primers:
							Transaction.Cost = DataFiles.BatchPrimerCost(Transaction.BatchID);
							break;
						}
					}

				//----------------------------------------------------------------------------*
				// Determine the Transaction Type
				//----------------------------------------------------------------------------*

				switch (Transaction.TransactionType)
					{
					//----------------------------------------------------------------------------*
					// Add Stock
					//----------------------------------------------------------------------------*

					case cTransaction.eTransactionType.AddStock:
						m_dQuantityOnHand += Transaction.Quantity;

						if (Transaction.Cost > 0.0)
							{
							m_dTotalPurchaseQty += Transaction.Quantity;
							m_dTotalPurchaseCost += Transaction.Cost;

							if (DataFiles.Preferences.IncludeTaxShipping)
								m_dTotalPurchaseCost += (Transaction.Tax + Transaction.Shipping);
							}

						m_dTotalAdjustQty += Transaction.Quantity;

						break;

					//----------------------------------------------------------------------------*
					// Purchase
					//----------------------------------------------------------------------------*

					case cTransaction.eTransactionType.Purchase:
						m_dQuantityOnHand += Transaction.Quantity;

						if (Transaction.Date > LastDate)
							{
							LastDate = Transaction.Date;
							dLastQty = Transaction.Quantity;
							dLastCost = Transaction.Cost;

							if (DataFiles.Preferences.IncludeTaxShipping)
								dLastCost += (Transaction.Tax + Transaction.Shipping);
							}

						m_dTotalPurchaseQty += Transaction.Quantity;
						m_dTotalPurchaseCost += Transaction.Cost;

						if (DataFiles.Preferences.IncludeTaxShipping)
							m_dTotalPurchaseCost += (Transaction.Tax + Transaction.Shipping);

						break;

					//----------------------------------------------------------------------------*
					// Reduce Stock
					//----------------------------------------------------------------------------*

					case cTransaction.eTransactionType.ReduceStock:
						m_dQuantityOnHand -= Transaction.Quantity;

						if (Transaction.BatchID == 0)
							m_dTotalAdjustQty -= Transaction.Quantity;
						else
							m_dTotalUsedQty += Transaction.Quantity;

						break;

					//----------------------------------------------------------------------------*
					// SetStockLevel
					//----------------------------------------------------------------------------*

					case cTransaction.eTransactionType.SetStockLevel:
						m_dQuantityOnHand += Transaction.Quantity;

						Transaction.Date = new DateTime(2010, 1, 1, 0, 0, 0);

						if (Transaction.Date > LastDate)
							{
							LastDate = Transaction.Date;
							dLastQty = Transaction.Quantity;
							dLastCost = Transaction.Cost;

							if (DataFiles.Preferences.IncludeTaxShipping)
								dLastCost += (Transaction.Tax + Transaction.Shipping);
							}

						m_dTotalPurchaseQty += Transaction.Quantity;
						m_dTotalPurchaseCost += Transaction.Cost;

						if (DataFiles.Preferences.IncludeTaxShipping)
							{
							m_dTotalPurchaseCost += (Transaction.Tax + Transaction.Shipping);
							m_dLastPurchaseCost += Transaction.Cost;
							}

						break;

					//----------------------------------------------------------------------------*
					// Fired
					//----------------------------------------------------------------------------*

					case cTransaction.eTransactionType.Fired:
						m_dQuantityOnHand -= Transaction.Quantity;

						m_dTotalUsedQty += Transaction.Quantity;

						break;
					}
				}

			//----------------------------------------------------------------------------*
			// Set the last purchase data
			//----------------------------------------------------------------------------*

			m_dLastPurchaseCost = dLastCost;
			m_dLastPurchaseQty = dLastQty;
			m_LastPurchaseDate = LastDate;

			//----------------------------------------------------------------------------*
			// Calculate Cost Each
			//----------------------------------------------------------------------------*

			double dQuantity = 0.0;
			double dCost = 0.0;

			if (DataFiles.Preferences.AverageCosts)
				{
				dQuantity = m_dTotalPurchaseQty;
				dCost = m_dTotalPurchaseCost;
				}
			else
				{
				dQuantity = m_dLastPurchaseQty;
				dCost = m_dLastPurchaseCost;
				}

			if (dQuantity > 0.0)
				m_dCostEach = dCost / dQuantity;
			else
				m_dCostEach = 0.0;
			}

		//============================================================================*
		// ResetAllInventoryData()
		//============================================================================*

		public void ResetAllInventoryData()
			{
			m_dQuantity = 0.0;
			m_dCost = 0.0;

			ResetInventoryData();
			}

		//============================================================================*
		// ResetInventoryData()
		//============================================================================*

		public void ResetInventoryData()
			{
			//----------------------------------------------------------------------------*
			// Clear the data from the inventory system
			//----------------------------------------------------------------------------*

			m_TransactionList.Clear();

			ResetInventoryTotals();
			}

		//============================================================================*
		// ResetInventoryTotals()
		//============================================================================*

		public void ResetInventoryTotals()
			{
			m_dLastPurchaseCost = 0.0;
			m_dLastPurchaseQty = 0.0;

			m_dTotalPurchaseCost = 0;
			m_dTotalPurchaseQty = 0;

			m_dQuantityOnHand = 0.0;

			m_dTotalUsedQty = 0;
			m_dTotalAdjustQty = 0;

			//----------------------------------------------------------------------------*
			// Reset Cost Each for a non inventory tracking system
			//----------------------------------------------------------------------------*

			if (m_dQuantity > 0.0)
				m_dCostEach = m_dCost / m_dQuantity;
			}

		//============================================================================*
		// ResolveIdentities()
		//============================================================================*

		public virtual bool ResolveIdentities(cDataFiles DataFiles)
			{
			bool fChanged = m_TransactionList.ResolveIdentities(DataFiles);

			return (fChanged);
			}

		//============================================================================*
		// SupplyType Property
		//============================================================================*

		public eSupplyTypes SupplyType
			{
			get
				{
				return (m_eType);
				}
			set
				{
				m_eType = value;
				}
			}

		//============================================================================*
		// SupplyTypeString() - eSupplyType
		//============================================================================*

		public static string SupplyTypeString(cSupply Supply)
			{
			return (SupplyTypeString(Supply.FirearmType, Supply.SupplyType));
			}

		//============================================================================*
		// SupplyTypeFromString()
		//============================================================================*

		public static cSupply.eSupplyTypes SupplyTypeFromString(string strType)
			{
			switch (strType)
				{
				case "Bullets":
					return (cSupply.eSupplyTypes.Bullets);
				case "Cases":
					return (cSupply.eSupplyTypes.Cases);
				case "Powder":
					return (cSupply.eSupplyTypes.Powder);
				case "Primers":
					return (cSupply.eSupplyTypes.Primers);
				case "Ammo":
					return (cSupply.eSupplyTypes.Ammo);
				}

			return (cSupply.eSupplyTypes.Unknown);
			}

		//============================================================================*
		// SupplyTypeString() - eSupplyType
		//============================================================================*

		public static string SupplyTypeString(eSupplyTypes eSupplyType, bool fPlural = true)
			{
			string strTypeString = "";

			switch (eSupplyType)
				{
				case cSupply.eSupplyTypes.Bullets:
					strTypeString = "Bullet";
					break;

				case cSupply.eSupplyTypes.Cases:
					strTypeString = "Case";
					break;

				case cSupply.eSupplyTypes.Powder:
					strTypeString = "Powder";
					break;

				case cSupply.eSupplyTypes.Primers:
					strTypeString = "Primer";
					break;

				case cSupply.eSupplyTypes.Ammo:
					strTypeString = "Ammo";
					break;

				default:
					strTypeString = "Unknown!";
					break;
				}

			if (fPlural && (eSupplyType == eSupplyTypes.Bullets || eSupplyType == eSupplyTypes.Cases || eSupplyType == eSupplyTypes.Primers))
				strTypeString += "s";

			return (strTypeString);
			}

		//============================================================================*
		// SupplyTypeString() - cFirearm.eFirearmType + eSupplyType
		//============================================================================*

		public static string SupplyTypeString(cFirearm.eFireArmType eFirearmType, eSupplyTypes eSupplyType)
			{
			return (String.Format("{0} {1}", cFirearm.FirearmTypeString(eFirearmType), SupplyTypeString(eSupplyType)));
			}

		//============================================================================*
		// SupplyTypeString() - cTransaction
		//============================================================================*

		public static string SupplyTypeString(cTransaction Transaction)
			{
			return (String.Format("{0} {1}", cFirearm.FirearmTypeString(Transaction.Supply.FirearmType), Transaction.Supply.SupplyType));
			}

		//============================================================================*
		// Synch() - Manufacturer
		//============================================================================*

		public virtual bool Synch(cManufacturer Manufacturer)
			{
			if (m_Manufacturer == null)
				return (false);

			if (m_Manufacturer.CompareTo(Manufacturer) == 0)
				{
				m_Manufacturer = Manufacturer;

				return (true);
				}

			return (false);
			}

		//============================================================================*
		// ToCrossUseString()
		//============================================================================*

		public string ToCrossUseString(string strString)
			{
			if (m_fCrossUse && cCaliber.CurrentFirearmType != FirearmType)
				{
				strString += " (";

				strString += cFirearm.FirearmTypeString(FirearmType);

				strString += ")";
				}

			return (strString);
			}

		//============================================================================*
		// TotalAdjustQty Property
		//============================================================================*

		public double TotalAdjustQty
			{
			get
				{
				return (m_dTotalAdjustQty);
				}
			set
				{
				m_dTotalAdjustQty = value;
				}
			}

		//============================================================================*
		// TotalPurchaseCost Property
		//============================================================================*

		public double TotalPurchaseCost
			{
			get
				{
				return (m_dTotalPurchaseCost);
				}
			set
				{
				m_dTotalPurchaseCost = value;
				}
			}

		//============================================================================*
		// TotalPurchaseQty Property
		//============================================================================*

		public double TotalPurchaseQty
			{
			get
				{
				return (m_dTotalPurchaseQty);
				}
			set
				{
				m_dTotalPurchaseQty = value;
				}
			}

		//============================================================================*
		// TotalUsedQty Property
		//============================================================================*

		public double TotalUsedQty
			{
			get
				{
				return (m_dTotalUsedQty);
				}
			set
				{
				m_dTotalUsedQty = value;
				}
			}

		//============================================================================*
		// TransactionList Property
		//============================================================================*

		public cTransactionList TransactionList
			{
			get
				{
				return (m_TransactionList);
				}
			set
				{
				m_TransactionList = value;
				}
			}

		//============================================================================*
		// Validate()
		//============================================================================*

		public virtual bool Validate(bool fIdentityOK = false)
			{
			if (m_Manufacturer == null)
				return (false);

			return (true);
			}
		}
	}
