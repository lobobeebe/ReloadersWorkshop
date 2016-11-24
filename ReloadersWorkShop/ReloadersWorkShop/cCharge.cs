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
using System.Xml;

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
	public class cCharge
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
		// CSVHeader Property
		//============================================================================*

		public static string CSVHeader
			{
			get
				{
				return ("Charges");
				}
			}

		//============================================================================*
		// CSVLine Property
		//============================================================================*

		public string CSVLine
			{
			get
				{
				string strLine = ",";

				strLine += m_dPowderWeight;
				strLine += ",";
				strLine += m_dFillRatio;
				strLine += ",";
				strLine += m_fFavorite ? "Yes" : "-";
				strLine += ",";
				strLine += m_fReject ? "Yes" : "-";

				return (strLine);
				}
			}

		//============================================================================*
		// CSVLineHeader Property
		//============================================================================*

		public static string CSVLineHeader
			{
			get
				{
				return ("Powder Weight,Fill Ratio,Favorite,Reject");
				}
			}

		//============================================================================*
		// Export() - XML Document
		//============================================================================*

		public void Export(XmlDocument XMLDocument, XmlElement XMLParentElement)
			{
			XmlElement XMLThisElement = XMLDocument.CreateElement("Charge");
			XMLParentElement.AppendChild(XMLThisElement);

			// PowderWeight

			XmlElement XMLElement = XMLDocument.CreateElement("PowderWeight");
			XmlText XMLTextElement = XMLDocument.CreateTextNode(String.Format("{0}", m_dPowderWeight));
			XMLElement.AppendChild(XMLTextElement);

			XMLThisElement.AppendChild(XMLElement);

			// Fill Ratio

			XMLElement = XMLDocument.CreateElement("FillRatio");
			XMLTextElement = XMLDocument.CreateTextNode(String.Format("{0}", m_dFillRatio));
			XMLElement.AppendChild(XMLTextElement);

			XMLThisElement.AppendChild(XMLElement);

			// Favorite

			XMLElement = XMLDocument.CreateElement("Favorite");
			XMLTextElement = XMLDocument.CreateTextNode(m_fFavorite ? "Yes" : "-");
			XMLElement.AppendChild(XMLTextElement);

			XMLThisElement.AppendChild(XMLElement);

			// Reject

			XMLElement = XMLDocument.CreateElement("Reject");
			XMLTextElement = XMLDocument.CreateTextNode(m_fReject ? "Yes" : "-");
			XMLElement.AppendChild(XMLTextElement);

			XMLThisElement.AppendChild(XMLElement);

			TestList.Export(XMLDocument, XMLThisElement);
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
		// SetTestData()
		//============================================================================*

		public void SetTestData()
			{
			foreach (cChargeTest ChargeTest in TestList)
				{
				ChargeTest.Charge = this;
				ChargeTest.PowderWeight = m_dPowderWeight;
				}
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
		}
	}
