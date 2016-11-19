//============================================================================*
// cBullet.cs
//
// Copyright © 2013-2014, Kevin S. Beebe
// All Rights Reserved
//============================================================================*

//============================================================================*
// .Net Using Statements
//============================================================================*

using System;
using System.Xml;

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
	// cBullet class
	//============================================================================*

	[Serializable]
	public class cBullet : cSupply
		{
		//============================================================================*
		// Private Static Data Members
		//============================================================================*

        private static double sm_dMinBulletWeight = cBullet.MinBulletWeight;
        private static double sm_dMaxBulletWeight = cBullet.MaxBulletWeight;

        //============================================================================*
        // Private Data Members
        //============================================================================*

        private string m_strPartNumber = "";
		private string m_strType = "";
		private Double m_dDiameter = 0.0;
		private double m_dLength = 0.0;
		private double m_dWeight = 0.0;
		private double m_dBallisticCoefficient = 0.0;

		private bool m_fSelfCast = false;
		private int m_nTopPunch = 0;

		private cBulletCaliberList m_CaliberList = new cBulletCaliberList();

		//============================================================================*
		// cBullet() - Constructor
		//============================================================================*

		public cBullet()
			: base(cSupply.eSupplyTypes.Bullets)
			{
			}

		//============================================================================*
		// cBullet() - Copy Constructor
		//============================================================================*

		public cBullet(cBullet Bullet)
			: base(Bullet)
			{
			Copy(Bullet, false);
			}

		//============================================================================*
		// BallisticCoefficient Property
		//============================================================================*

		public double BallisticCoefficient
			{
			get
				{
				return (m_dBallisticCoefficient);
				}
			set
				{
				m_dBallisticCoefficient = value;
				}
			}

		//============================================================================*
		// BulletCaliber()
		//============================================================================*

		public cBulletCaliber BulletCaliber(cCaliber Caliber)
			{
			cBulletCaliber BulletCaliber = null;

			foreach (cBulletCaliber CheckBulletCaliber in CaliberList)
				{
				if (CheckBulletCaliber.Caliber.CompareTo(Caliber) == 0)
					{
					BulletCaliber = CheckBulletCaliber;

					break;
					}
				}

			return (BulletCaliber);
			}

		//============================================================================*
		// CalculateSectionalDensity()
		//============================================================================*

		public static double CalculateSectionalDensity(double dDiameter, double dWeight)
			{
			double dSectionalDensity = 0.0;

			try
				{
				dSectionalDensity = dWeight / (7000.0 * (dDiameter * dDiameter));
				}
			catch
				{
				dSectionalDensity = 0.0;
				}

			return (dSectionalDensity);
			}

		//============================================================================*
		// CaliberList Property
		//============================================================================*

		public cBulletCaliberList CaliberList
			{
			get
				{
				return (m_CaliberList);
				}
			set
				{
				m_CaliberList = value;
				}
			}

		//============================================================================*
		// CanBeCaliber()
		//============================================================================*

		public bool CanBeCaliber(cCaliber Caliber)
			{
			if (FirearmType == Caliber.FirearmType && m_dDiameter >= Caliber.MinBulletDiameter && m_dDiameter <= Caliber.MaxBulletDiameter)
				return (true);

			return (false);
			}

		//============================================================================*
		// Comparer()
		//============================================================================*

		public static int Comparer(cBullet Bullet1, cBullet Bullet2)
			{
			if (Bullet1 == null)
				{
				if (Bullet2 != null)
					return (-1);
				else
					return (0);
				}
			else
				{
				if (Bullet2 == null)
					return (1);
				}

			return (Bullet1.CompareTo(Bullet2));
			}

		//============================================================================*
		// CompareTo()
		//============================================================================*

		public override int CompareTo(Object obj)
			{
			if (obj == null)
				return (1);

			//----------------------------------------------------------------------------*
			// Base Class
			//----------------------------------------------------------------------------*

			cSupply Supply = (cSupply) obj;

			int rc = base.CompareTo(Supply);

			//----------------------------------------------------------------------------*
			// Compare Part Numbers
			//----------------------------------------------------------------------------*

			if (rc == 0)
				{
				cBullet Bullet = (cBullet) Supply;

				if (string.IsNullOrEmpty(m_strPartNumber))
					{
					if (!string.IsNullOrEmpty(Bullet.m_strPartNumber))
						rc = -1;
					else
						rc = 0;
					}
				else
					{
					if (string.IsNullOrEmpty(Bullet.m_strPartNumber))
						rc = 1;
					else
						rc = cDataFiles.ComparePartNumbers(m_strPartNumber, Bullet.m_strPartNumber);
					}
				}

			return (rc);
			}

		//============================================================================*
		// Copy()
		//============================================================================*

		public void Copy(cBullet Bullet, bool fCopyBase = true)
			{
			if (fCopyBase)
				base.Copy(Bullet);

			m_strPartNumber = Bullet.m_strPartNumber;
			m_strType = Bullet.m_strType;
			m_dDiameter = Bullet.m_dDiameter;
			m_dLength = Bullet.m_dLength;
			m_dWeight = Bullet.m_dWeight;
			m_dBallisticCoefficient = Bullet.m_dBallisticCoefficient;

			m_fSelfCast = Bullet.m_fSelfCast;
			m_nTopPunch = Bullet.m_nTopPunch;

			if (Bullet.CaliberList != null)
				m_CaliberList = new cBulletCaliberList(Bullet.CaliberList);
			else
				m_CaliberList = new cBulletCaliberList();
			}

		//============================================================================*
		// CSVHeader Property
		//============================================================================*

		public static string CSVHeader
			{
			get
				{
				return ("Bullets");
				}
			}

		//============================================================================*
		// CSVLine Property
		//============================================================================*

		public string CSVLine
			{
			get
				{
				string strLine = "";

				strLine += Manufacturer.Name;
				strLine += ",";
				strLine += m_strPartNumber;
				strLine += ",";
				strLine += m_strType;
				strLine += ",";

				switch (FirearmType)
					{
					case cFirearm.eFireArmType.Handgun:
						strLine += "Handgun,";
						break;
					case cFirearm.eFireArmType.Rifle:
						strLine += "Rifle,";
						break;
					case cFirearm.eFireArmType.Shotgun:
						strLine += "Shotgun,";
						break;
					default:
						strLine += ",";
						break;
					}

				strLine += CrossUse ? "Yes," : "-,";

				strLine += m_dDiameter;
				strLine += ",";
				strLine += m_dLength;
				strLine += ",";
				strLine += m_dWeight;
				strLine += ",";
				strLine += m_dBallisticCoefficient;

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
				string strLine = "Manufacturer,Part Number,Type,Firearm Type,Cross Use,Diameter,Length,Weight,Ballistic Coefficient";

				return (strLine);
				}
			}

		//============================================================================*
		// Diameter Property
		//============================================================================*

		public double Diameter
			{
			get
				{
				return (m_dDiameter);
				}
			set
				{
				m_dDiameter = value;
				}
			}

		//============================================================================*
		// Export() - XML Document
		//============================================================================*

		public void Export(XmlDocument XMLDocument, XmlElement XMLParentElement)
			{
			XmlElement XMLThisElement = XMLDocument.CreateElement("Bullet");
			XMLParentElement.AppendChild(XMLThisElement);

			// Manufacturer

			XmlElement XMLElement = XMLDocument.CreateElement("Manufacturer");
			XmlText XMLTextElement = XMLDocument.CreateTextNode(Manufacturer.Name);
			XMLElement.AppendChild(XMLTextElement);

			XMLThisElement.AppendChild(XMLElement);

			// Part Number

			XMLElement = XMLDocument.CreateElement("PartNumber");
			XMLTextElement = XMLDocument.CreateTextNode(m_strPartNumber);
			XMLElement.AppendChild(XMLTextElement);

			XMLThisElement.AppendChild(XMLElement);

			// Type

			XMLElement = XMLDocument.CreateElement("Type");
			XMLTextElement = XMLDocument.CreateTextNode(m_strType);
			XMLElement.AppendChild(XMLTextElement);

			XMLThisElement.AppendChild(XMLElement);

			// Firearm Type

			XMLElement = XMLDocument.CreateElement("FirearmType");
			XMLTextElement = XMLDocument.CreateTextNode(cFirearm.FirearmTypeString(FirearmType));
			XMLElement.AppendChild(XMLTextElement);

			XMLThisElement.AppendChild(XMLElement);

			// Cross Use

			XMLElement = XMLDocument.CreateElement("CrossUse");
			XMLTextElement = XMLDocument.CreateTextNode(CrossUse ? "Yes," : "-,");
			XMLElement.AppendChild(XMLTextElement);

			XMLThisElement.AppendChild(XMLElement);

			// Diameter

			XMLElement = XMLDocument.CreateElement("Diameter");
			XMLTextElement = XMLDocument.CreateTextNode(String.Format("{0}", m_dDiameter));
			XMLElement.AppendChild(XMLTextElement);

			XMLThisElement.AppendChild(XMLElement);

			// Length

			XMLElement = XMLDocument.CreateElement("Length");
			XMLTextElement = XMLDocument.CreateTextNode(String.Format("{0}", m_dLength));
			XMLElement.AppendChild(XMLTextElement);

			XMLThisElement.AppendChild(XMLElement);

			// Weight

			XMLElement = XMLDocument.CreateElement("Weight");
			XMLTextElement = XMLDocument.CreateTextNode(String.Format("{0}", m_dWeight));
			XMLElement.AppendChild(XMLTextElement);

			XMLThisElement.AppendChild(XMLElement);

			// Ballistic Coefficient

			XMLElement = XMLDocument.CreateElement("BallisticCoefficient");
			XMLTextElement = XMLDocument.CreateTextNode(String.Format("{0}", m_dBallisticCoefficient));
			XMLElement.AppendChild(XMLTextElement);

			XMLThisElement.AppendChild(XMLElement);
			}

		//============================================================================*
		// HasCaliber()
		//============================================================================*

		public bool HasCaliber(cCaliber Caliber, bool fHideCalibers = false)
			{
			foreach (cBulletCaliber CheckCaliber in m_CaliberList)
				{
				if (CheckCaliber.CompareTo(Caliber) == 0)
					{
					if (!fHideCalibers || CheckCaliber.Caliber.Checked)
						return (true);
					}
				}

			return (false);
			}

		//============================================================================*
		// Length Property
		//============================================================================*

		public double Length
			{
			get
				{
				return (m_dLength);
				}
			set
				{
				m_dLength = value;
				}
			}

        //============================================================================*
        // MaxBulletWeight Property
        //============================================================================*

        public static double MaxBulletWeight
            {
            get
                {
                return (sm_dMinBulletWeight);
                }
            }

        //============================================================================*
        // MinBulletWeight Property
        //============================================================================*

        public static double MinBulletWeight
            {
            get
                {
                return (sm_dMinBulletWeight);
                }
            }

		//============================================================================*
		// PartNumber Property
		//============================================================================*

		public string PartNumber
			{
			get
				{
				if (m_strPartNumber == null)
					m_strPartNumber = "";

				return (m_strPartNumber);
				}

			set
				{
				m_strPartNumber = value;
				}
			}

		//============================================================================*
		// SectionalDensity Property
		//============================================================================*

		public double SectionalDensity
			{
			get
				{
				return (CalculateSectionalDensity(m_dDiameter, m_dWeight));
				}
			}

		//============================================================================*
		// SelfCast Property
		//============================================================================*

		public bool SelfCast
			{
			get
				{
				return (m_fSelfCast);
				}
			set
				{
				m_fSelfCast = value;
				}
			}

		//============================================================================*
		// Synch() - Caliber
		//============================================================================*

		public bool Synch(cCaliber Caliber)
			{
			bool fFound = false;

			foreach (cBulletCaliber CheckBulletCaliber in m_CaliberList)
				fFound = CheckBulletCaliber.Synch(Caliber);

			return (fFound);
			}

		//============================================================================*
		// TopPunch Property
		//============================================================================*

		public int TopPunch
			{
			get
				{
				return (m_nTopPunch);
				}
			set
				{
				m_nTopPunch = value;
				}
			}

		//============================================================================*
		// ToShortString()
		//============================================================================*

		public string ToShortString()
			{
			string strString = "";

			if (Manufacturer != null)
				strString = Manufacturer.Name;

			if (m_strPartNumber != null && m_strPartNumber.Length > 0)
				strString += String.Format(" {0}, {1}", m_strPartNumber, m_strType);
			else
				strString += String.Format(", {0}", m_strType);

			return (strString);
			}

		//============================================================================*
		// ToString()
		//============================================================================*

		public override string ToString()
			{
			string strString = "";

			if (Manufacturer != null)
				strString = Manufacturer.Name;

			string strDiameterFormat = " {0:F";
			strDiameterFormat += String.Format("{0:G0}", cPreferences.DimensionDecimals);
			strDiameterFormat += "}";

			string strWeightFormat = " {0:F";
			strWeightFormat += String.Format("{0:G0}", cPreferences.BulletWeightDecimals);
			strWeightFormat += "}";

			bool fType = false;

			if (m_strPartNumber != null && m_strPartNumber.Length > 0)
				strString += String.Format(" {0}", m_strPartNumber);
			else
				{
				strString += String.Format(" {0}", m_strType);

				fType = true;
				}

			strString += String.Format(strDiameterFormat, cPreferences.MetricDimensions ?  cConversions.InchesToMillimeters(m_dDiameter) : m_dDiameter);

			strString += cDataFiles.MetricString(cDataFiles.eDataType.Dimension);

			strString += String.Format(strWeightFormat, cPreferences.MetricBulletWeights ? cConversions.GrainsToGrams(m_dWeight) : m_dWeight);

			strString += cPreferences.MetricBulletWeights ? "g" : "gr";

			if (!fType)
				strString += String.Format(" {0}", m_strType);

			strString = ToCrossUseString(strString);

			return (strString);
			}

		//============================================================================*
		// ToWeightString()
		//============================================================================*

		public string ToWeightString()
			{
			string strString = "";

			if (Manufacturer != null)
				strString = Manufacturer.Name;

			string strWeightFormat = ", {0:F";
			strWeightFormat += String.Format("{0:G0}", cPreferences.BulletWeightDecimals);
			strWeightFormat += "}";

			bool fType = false;

			if (m_strPartNumber != null && m_strPartNumber.Length > 0)
				strString += String.Format(" {0}", m_strPartNumber);
			else
				{
				strString += String.Format(", {0}", m_strType);

				fType = true;
				}

			strString += String.Format(strWeightFormat, cPreferences.MetricBulletWeights ? cConversions.GrainsToGrams(m_dWeight) : m_dWeight);

			strString += cPreferences.MetricBulletWeights ? " g" : " gr";

			if (!fType)
				strString += String.Format(", {0}", m_strType);

			return (strString);
			}

		//============================================================================*
		// Type Property
		//============================================================================*

		public string Type
			{
			get
				{
				return (m_strType);
				}
			set
				{
				m_strType = value;
				}
			}

		//============================================================================*
		// Weight Property
		//============================================================================*

		public double Weight
			{
			get
				{
				return (m_dWeight);
				}
			set
				{
				m_dWeight = value;
				}
			}

		//============================================================================*
		// XMLLine Property
		//============================================================================*

		public string XMLLine
			{
			get
				{
				string strLine = "";

				return (strLine);
				}
			}

		//============================================================================*
		// XMLLineHeader Property
		//============================================================================*

		public static string XMLLineHeader
			{
			get
				{
				string strLine = "Firearm Type,Name,Headstamp,Handgun Type,Small Primer,Large Primer,Magnum Primer,Min Bullet Dia.,Max Bullet Dia.,Min Bullet Weight,Max Bullet Weight,Case Trim Length,Max Case Length,Max COAL,Max Neck Dia";

				return (strLine);
				}
			}
		}
	}
