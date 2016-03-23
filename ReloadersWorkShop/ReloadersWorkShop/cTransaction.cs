//============================================================================*
// cTransaction.cs
//
// Copyright © 2013-2014, Kevin S. Beebe
// All Rights Reserved
//============================================================================*

//============================================================================*
// .Net Using Statements
//============================================================================*

using System;
using System.Collections;

//============================================================================*
// NameSpace
//============================================================================*

namespace ReloadersWorkShop
	{
	//============================================================================*
	// cTransaction class
	//============================================================================*

	[Serializable]
	public class cTransaction : IComparable
		{
		//============================================================================*
		// Public Enumerations
		//============================================================================*

		public enum eTransactionType
			{
			Purchase = 0,
			SetStockLevel,
			AddStock,
			ReduceStock,
			Fired
			}

		//============================================================================*
		// Private Data Members
		//============================================================================*

		private cSupply m_Supply = null;

		private eTransactionType m_eTransactionType = eTransactionType.Purchase;
		private string m_strSource = "";
		private DateTime m_Date = DateTime.Now;

		private double m_dQuantity = 0.0;
		private double m_dCost = 0.0;
		private double m_dTax = 0.0;
		private double m_dShipping = 0.0;

		private int m_nBatchID = 0;

		private bool m_fArchived = false;

		private bool m_fChecked = false;

		private bool m_fApplyTax = true;

		private bool m_fAutoTrans = false;

		//============================================================================*
		// cTransaction() - Constructor
		//============================================================================*

		public cTransaction()
			{
			}

		//============================================================================*
		// cTransaction() - Copy Constructor
		//============================================================================*

		public cTransaction(cTransaction Transaction)
			{
			m_fAutoTrans = Transaction.m_fAutoTrans;

			m_Date = Transaction.m_Date;
			m_eTransactionType = Transaction.m_eTransactionType;
			m_strSource = Transaction.m_strSource;

			m_Supply = Transaction.m_Supply;

			m_nBatchID = Transaction.m_nBatchID;

			m_dQuantity = Transaction.m_dQuantity;
			m_dCost = Transaction.m_dCost;
			m_dTax = Transaction.m_dTax;
			m_dShipping = Transaction.m_dShipping;
			m_fApplyTax = Transaction.m_fApplyTax;

			m_fChecked = Transaction.m_fChecked;
			}

		//============================================================================*
		// ApplyTax Property
		//============================================================================*

		public bool ApplyTax
			{
			get { return (m_fApplyTax); }
			set { m_fApplyTax = value; }
			}

		//============================================================================*
		// Archived Property
		//============================================================================*

		public bool Archived
			{
			get { return (m_fArchived); }
			set { m_fArchived = value; }
			}

		//============================================================================*
		// AutoTrans Property
		//============================================================================*

		public bool AutoTrans
			{
			get { return (m_fAutoTrans); }
			set { m_fAutoTrans = value; }
			}

		//============================================================================*
		// BatchID Property
		//============================================================================*

		public int BatchID
			{
			get { return (m_nBatchID); }
			set { m_nBatchID = value; }
			}

		//============================================================================*
		// Checked Property
		//============================================================================*

		public bool Checked
			{
			get { return (m_fChecked); }
			set { m_fChecked = value; }
			}

		//============================================================================*
		// Comparer()
		//============================================================================*

		public static int Comparer(cTransaction Transaction1, cTransaction Transaction2)
			{
			if (Transaction1 == null)
				{
				if (Transaction2 != null)
					return (-1);
				else
					return (0);
				}
			else
				{
				if (Transaction2 == null)
					return (1);
				}

			return (Transaction1.CompareTo(Transaction2));
			}

		//============================================================================*
		// CompareTo()
		//============================================================================*

		public int CompareTo(Object obj)
			{
			if (obj == null)
				return (1);

			cTransaction Transaction = (cTransaction)obj;

			//----------------------------------------------------------------------------*
			// Details
			//----------------------------------------------------------------------------*

			int rc = CompareDetailsTo(Transaction);

			//----------------------------------------------------------------------------*
			// Quantity
			//----------------------------------------------------------------------------*

			if (rc == 0)
				{
				rc = m_dQuantity.CompareTo(Transaction.m_dQuantity);

				//----------------------------------------------------------------------------*
				// Cost
				//----------------------------------------------------------------------------*

				if (rc == 0)
					{
					rc = m_dCost.CompareTo(Transaction.m_dCost);
					}
				}

			return (rc);
			}

		//============================================================================*
		// CompareDetailsTo()
		//============================================================================*

		public int CompareDetailsTo(cTransaction Transaction)
			{
			if (Transaction == null)
				return (1);

			//----------------------------------------------------------------------------*
			// Date
			//----------------------------------------------------------------------------*

			int rc = m_Date.CompareTo(Transaction.m_Date);

			//----------------------------------------------------------------------------*
			// AutoTrans
			//----------------------------------------------------------------------------*

			if (rc == 0)
				{
				rc = m_fAutoTrans.CompareTo(Transaction.m_fAutoTrans);

				//----------------------------------------------------------------------------*
				// TransactionType
				//----------------------------------------------------------------------------*

				if (rc == 0)
					{
					rc = m_eTransactionType.CompareTo(Transaction.m_eTransactionType);

					//----------------------------------------------------------------------------*
					// Source
					//----------------------------------------------------------------------------*

					if (rc == 0)
						{
						if (m_strSource != null)
							rc = m_strSource.CompareTo(Transaction.m_strSource);

						//----------------------------------------------------------------------------*
						// BatchID
						//----------------------------------------------------------------------------*

						if (rc == 0)
							{
							rc = m_nBatchID.CompareTo(Transaction.m_nBatchID);

							//----------------------------------------------------------------------------*
							// Supply
							//----------------------------------------------------------------------------*

							if (rc == 0)
								{
								switch (m_Supply.SupplyType)
									{
									case cSupply.eSupplyTypes.Bullets:
										rc = (m_Supply as cBullet).CompareTo((Transaction.m_Supply as cBullet));
										break;

									case cSupply.eSupplyTypes.Cases:
										rc = (m_Supply as cCase).CompareTo((Transaction.m_Supply as cCase));
										break;

									case cSupply.eSupplyTypes.Powder:
										rc = (m_Supply as cPowder).CompareTo((Transaction.m_Supply as cPowder));
										break;

									case cSupply.eSupplyTypes.Primers:
										rc = (m_Supply as cPrimer).CompareTo((Transaction.m_Supply as cPrimer));
										break;

									case cSupply.eSupplyTypes.Ammo:
										rc = (m_Supply as cAmmo).CompareTo((Transaction.m_Supply as cAmmo));
										break;
									}
								}
							}
						}
					}
				}

			return (rc);
			}

		//============================================================================*
		// Cost Property
		//============================================================================*

		public double Cost
			{
			get { return (m_dCost); }
			set { m_dCost = value; }
			}

		//============================================================================*
		// Date Property
		//============================================================================*

		public DateTime Date
			{
			get { return (m_Date); }
			set { m_Date = value; }
			}

		//============================================================================*
		// Quantity Property
		//============================================================================*

		public double Quantity
			{
			get { return (m_dQuantity); }
			set { m_dQuantity = value; }
			}

		//============================================================================*
		// Shipping Property
		//============================================================================*

		public double Shipping
			{
			get { return (m_dShipping); }
			set { m_dShipping = value; }
			}

		//============================================================================*
		// Source Property
		//============================================================================*

		public string Source
			{
			get { return (m_strSource); }
			set { m_strSource = value; }
			}

		//============================================================================*
		// Supply Property
		//============================================================================*

		public cSupply Supply
			{
			get { return (m_Supply); }
			set { m_Supply = value; }
			}

		//============================================================================*
		// Synch() - Bullet
		//============================================================================*

		public bool Synch(cBullet Bullet)
			{
			if (m_Supply.SupplyType != cSupply.eSupplyTypes.Bullets)
				return (false);

			if ((m_Supply as cBullet).CompareTo(Bullet) == 0)
				{
				m_Supply = Bullet;

				return (true);
				}

			return (false);
			}

		//============================================================================*
		// Synch() - Case
		//============================================================================*

		public bool Synch(cCase Case)
			{
			if (m_Supply.SupplyType != cSupply.eSupplyTypes.Cases)
				return (false);

			if ((m_Supply as cCase).CompareTo(Case) == 0)
				{
				m_Supply = Case;

				return (true);
				}

			return (false);
			}

		//============================================================================*
		// Synch() - Ammo
		//============================================================================*

		public bool Synch(cAmmo Ammo)
			{
			if (m_Supply.SupplyType != cSupply.eSupplyTypes.Ammo)
				return (false);

			if ((m_Supply as cAmmo).CompareTo(Ammo) == 0)
				{
				m_Supply = Ammo;

				return (true);
				}

			return (false);
			}

		//============================================================================*
		// Synch() - Powder
		//============================================================================*

		public bool Synch(cPowder Powder)
			{
			if (m_Supply.SupplyType != cSupply.eSupplyTypes.Powder)
				return (false);

			if ((m_Supply as cPowder).CompareTo(Powder) == 0)
				{
				m_Supply = Powder;

				return (true);
				}

			return (false);
			}

		//============================================================================*
		// Synch() - Primer
		//============================================================================*

		public bool Synch(cPrimer Primer)
			{
			if (m_Supply.SupplyType != cSupply.eSupplyTypes.Primers)
				return (false);

			if ((m_Supply as cPrimer).CompareTo(Primer) == 0)
				{
				m_Supply = Primer;

				return (true);
				}

			return (false);
			}

		//============================================================================*
		// Tax Property
		//============================================================================*

		public double Tax
			{
			get { return (m_dTax); }
			set { m_dTax = value; }
			}

		//============================================================================*
		// ToString()
		//============================================================================*

		public override string ToString()
			{
			return (TransactionTypeString(m_eTransactionType));
			}

		//============================================================================*
		// TransactionDescriptionString()
		//============================================================================*

		public static string TransactionDescriptionString(eTransactionType eTransactionType)
			{
			switch (eTransactionType)
				{
				case eTransactionType.Purchase:
					return ("Purchase");

				case eTransactionType.AddStock:
					return ("Increase Stock");

				case eTransactionType.Fired:
					return ("Fired Ammo");

				case eTransactionType.ReduceStock:
					return ("Reduce Stock");

				case eTransactionType.SetStockLevel:
					return ("Initial Stock");
				}

			return ("** Unknown **");
			}

		//============================================================================*
		// TransactionType Property
		//============================================================================*

		public eTransactionType TransactionType
			{
			get { return (m_eTransactionType); }

			set
				{
				if (m_eTransactionType != value)
					{
					m_eTransactionType = value;

					m_strSource = "";
					}
				}
			}

		//============================================================================*
		// TransactionTypeFromString()
		//============================================================================*

		public static cTransaction.eTransactionType TransactionTypeFromString(string strString)
			{
			switch (strString)
				{
				case "Add Purchase":
					return (eTransactionType.Purchase);

				case "Increase Stock":
					return (eTransactionType.AddStock);

				case "Record Fired Ammo":
					return (eTransactionType.Fired);

				case "Reduce Stock":
					return (eTransactionType.ReduceStock);

				case "Add Initial Stock":
					return (eTransactionType.SetStockLevel);
				}

			return (eTransactionType.Purchase);
			}

		//============================================================================*
		// TransactionTypeString()
		//============================================================================*

		public static string TransactionTypeString(eTransactionType eTransactionType)
			{
			switch (eTransactionType)
				{
				case eTransactionType.Purchase:
					return ("Add Purchase");

				case eTransactionType.AddStock:
					return ("Increase Stock");

				case eTransactionType.Fired:
					return ("Record Fired Ammo");

				case eTransactionType.ReduceStock:
					return ("Reduce Stock");

				case eTransactionType.SetStockLevel:
					return ("Add Initial Stock");
				}

			return ("** Unknown **");
			}
		}
	}
