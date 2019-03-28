//============================================================================*
// cCharge.cs
//
// Copyright © 2013-2014, Kevin S. Beebe
// All Rights Reserved
//============================================================================*

//============================================================================*
// .Net Using Statements
//============================================================================*

using System;

//============================================================================*
// Application Specific Using Statements
//============================================================================*

using ReloadersWorkShop.Preferences;

//============================================================================*
// CommonLib Using Statements
//============================================================================*

using CommonLib.Conversions;

//============================================================================*
// NameSpace
//============================================================================*

namespace ReloadersWorkShop
	{
	//============================================================================*
	// cCharge class
	//============================================================================*

	[Serializable]
	public partial class cCharge
		{
		//----------------------------------------------------------------------------*
		// Private Data Members
		//----------------------------------------------------------------------------*

		private double m_dPowderWeight = 0.0;
		private double m_dFillRatio = 0.0;
		private bool m_fFavorite = false;
		private bool m_fReject = false;

		private cChargeTestList m_TestList = new cChargeTestList();

		//============================================================================*
		// cCharge() - Constructor
		//============================================================================*

		public cCharge()
			{
			}

		//============================================================================*
		// cCharge() - Copy Constructor
		//============================================================================*

		public cCharge(cCharge Charge)
			{
			m_dPowderWeight = Charge.m_dPowderWeight;
			m_dFillRatio = Charge.m_dFillRatio;
			m_fFavorite = Charge.m_fFavorite;
			m_fReject = Charge.m_fReject;

			m_TestList = new cChargeTestList(Charge.m_TestList);
			}

		//============================================================================*
		// AddTest()
		//============================================================================*

		public void AddTest(cChargeTest NewChargeTest)
			{
			bool fFound = false;

			foreach (cChargeTest ChargeTest in m_TestList)
				{
				if (ChargeTest.CompareTo(NewChargeTest) == 0)
					{
					fFound = true;

					break;
					}
				}

			if (!fFound)
				m_TestList.Add(NewChargeTest);
			}

		//============================================================================*
		// Comparer()
		//============================================================================*

		public static int Comparer(cCharge Charge1, cCharge Charge2)
			{
			if (Charge1 == null)
				{
				if (Charge2 != null)
					return (-1);
				else
					return (0);
				}
			else
				{
				if (Charge2 == null)
					return (1);
				}

			return (Charge1.CompareTo(Charge2));
			}

		//============================================================================*
		// CompareTo()
		//============================================================================*

		public int CompareTo(cCharge Charge)
			{
			if (Charge == null)
				return (1);

			//----------------------------------------------------------------------------*
			// Charge
			//----------------------------------------------------------------------------*

			int rc = m_dPowderWeight.CompareTo(Charge.m_dPowderWeight);

			//----------------------------------------------------------------------------*
			// Return results
			//----------------------------------------------------------------------------*

			return (rc);
			}

		//============================================================================*
		// Favorite Property
		//============================================================================*

		public bool Favorite
			{
			get { return (m_fFavorite); }
			set { m_fFavorite = value; }
			}

		//============================================================================*
		// FillRatio Property
		//============================================================================*

		public double FillRatio
			{
			get { return (m_dFillRatio); }
			set
				{
				m_dFillRatio = value;

				if (m_dFillRatio < 0.0)
					m_dFillRatio = 0.0;

				if (m_dFillRatio > 150.0)
					m_dFillRatio = 150.0;
				}
			}

		//============================================================================*
		// PowderWeight Property
		//============================================================================*

		public double PowderWeight
			{
			get { return (m_dPowderWeight); }
			set { m_dPowderWeight = value; }
			}

		//============================================================================*
		// Reject Property
		//============================================================================*

		public bool Reject
			{
			get { return (m_fReject); }
			set { m_fReject = value; }
			}

		//============================================================================*
		// ResolveIdentities()
		//============================================================================*

		public bool ResolveIdentities(cDataFiles DataFiles)
			{
			return(m_TestList.ResolveIdentities(DataFiles, this));
			}

		//============================================================================*
		// SetTestData()
		//============================================================================*

		public void SetTestData()
			{
			foreach (cChargeTest ChargeTest in TestList)
				ChargeTest.PowderWeight = m_dPowderWeight;
			}

		//============================================================================*
		// Synch() - Firearm
		//============================================================================*

		public bool Synch(cFirearm Firearm)
			{
			bool fFound = false;

			foreach (cChargeTest CheckChargeTest in m_TestList)
				fFound = CheckChargeTest.Synch(Firearm);

			return(fFound);
			}

		//============================================================================*
		// TestListProperty
		//============================================================================*

		public cChargeTestList TestList
			{
			get { return (m_TestList); }
			}

		//============================================================================*
		// ToString
		//============================================================================*

		public override string ToString()
			{
			string strFormat = "{0:F";
			strFormat += String.Format("{0:G0}", cPreferences.StaticPreferences.PowderWeightDecimals);
			strFormat += "}{1}";

			string strString = String.Format(strFormat, Math.Round(cPreferences.StaticPreferences.MetricPowderWeights ? cConversions.GrainsToGrams(m_dPowderWeight) :  m_dPowderWeight, cPreferences.StaticPreferences.PowderWeightDecimals), (m_dFillRatio > 100.0 ? "C" : ""));

			return (strString);
			}

		//============================================================================*
		// Validate()
		//============================================================================*

		public bool Validate()
			{
			return (m_dPowderWeight != 0.0);
			}
		}
	}
