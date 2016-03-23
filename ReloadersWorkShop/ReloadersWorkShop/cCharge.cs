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
	public class cCharge
		{
		//----------------------------------------------------------------------------*
		// Private Static Data Members
		//----------------------------------------------------------------------------*

		private static bool sm_fMetricPowderWeights = false;
		private static int sm_nPowderWeightDecimals = 1;

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
		// RemoveTest()
		//============================================================================*

		public void RemoveTest(cChargeTest ChargeTest)
			{
			m_TestList.Remove(ChargeTest);
			}

		//============================================================================*
		// MetricPowderWeights Property
		//============================================================================*

		public static bool MetricPowderWeights
			{
			get
				{
				return (sm_fMetricPowderWeights);
				}
			set
				{
				sm_fMetricPowderWeights = value;
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
		// PowderWeightDecimals Property
		//============================================================================*

		public static int PowderWeightDecimals
			{
			get
				{
				return (sm_nPowderWeightDecimals);
				}
			set
				{
				sm_nPowderWeightDecimals = value;
				}
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
			strFormat += String.Format("{0:G0}", sm_nPowderWeightDecimals);
			strFormat += "}{1}";

			string strString = String.Format(strFormat, Math.Round(sm_fMetricPowderWeights ? cConversions.GrainsToGrams(m_dPowderWeight) :  m_dPowderWeight, sm_nPowderWeightDecimals), (m_dFillRatio > 100.0 ? "C" : ""));

			return (strString);
			}
		}
	}
