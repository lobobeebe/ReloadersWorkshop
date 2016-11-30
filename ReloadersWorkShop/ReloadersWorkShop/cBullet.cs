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

		private cBulletCaliberList m_BulletCaliberList = new cBulletCaliberList();

		//============================================================================*
		// cBullet() - Constructor
		//============================================================================*

		public cBullet(bool fIdentity = false)
			: base(cSupply.eSupplyTypes.Bullets,fIdentity)
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

			foreach (cBulletCaliber CheckBulletCaliber in m_BulletCaliberList)
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
		// BulletCaliberList Property
		//============================================================================*

		public cBulletCaliberList BulletCaliberList
			{
			get
				{
				return (m_BulletCaliberList);
				}
			set
				{
				m_BulletCaliberList = value;
				}
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

			if (Bullet.BulletCaliberList != null)
				m_BulletCaliberList = new cBulletCaliberList(Bullet.BulletCaliberList);
			else
				m_BulletCaliberList = new cBulletCaliberList();
			}

		//============================================================================*
		// CSVLine Property
		//============================================================================*

		public override string CSVLine
			{
			get
				{
				string strLine = base.CSVLine;

				strLine += m_strPartNumber;
				strLine += ",";
				strLine += m_strType;
				strLine += ",";
				strLine += m_fSelfCast ? "Yes" : "";
				strLine += ",";
				strLine += m_nTopPunch;
				strLine += ",";

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
				string strLine = cSupply.CSVSupplyLineHeader;

				strLine += "Part Number,Type,Self Cast,Top Punch,Diameter,Length,Weight,Ballistic Coefficient";

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

		public override void Export(XmlDocument XMLDocument, XmlElement XMLParentElement)
			{
			XmlElement XMLThisElement = XMLDocument.CreateElement("Bullet");
			XMLParentElement.AppendChild(XMLThisElement);

			base.Export(XMLDocument, XMLThisElement);

			// Part Number

			XmlElement XMLElement = XMLDocument.CreateElement("PartNumber");
			XmlText XMLTextElement = XMLDocument.CreateTextNode(m_strPartNumber);
			XMLElement.AppendChild(XMLTextElement);

			XMLThisElement.AppendChild(XMLElement);

			// Type

			XMLElement = XMLDocument.CreateElement("Type");
			XMLTextElement = XMLDocument.CreateTextNode(m_strType);
			XMLElement.AppendChild(XMLTextElement);

			XMLThisElement.AppendChild(XMLElement);

			// Self Cast

			XMLElement = XMLDocument.CreateElement("SelfCast");
			XMLTextElement = XMLDocument.CreateTextNode(m_fSelfCast ? "Yes" : "-");
			XMLElement.AppendChild(XMLTextElement);

			XMLThisElement.AppendChild(XMLElement);

			// Top Punch

			XMLElement = XMLDocument.CreateElement("TopPunch");
			XMLTextElement = XMLDocument.CreateTextNode(m_nTopPunch.ToString());
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

			m_BulletCaliberList.Export(XMLDocument, XMLThisElement);
			}

		//============================================================================*
		// ExportIdentity() - XML Document
		//============================================================================*

		public override void ExportIdentity(XmlDocument XMLDocument, XmlElement XMLParentElement)
			{
			XmlElement XMLThisElement = XMLDocument.CreateElement("BulletIdentity");
			XMLParentElement.AppendChild(XMLThisElement);

			base.Export(XMLDocument, XMLThisElement);

			// Part Number

			XmlElement XMLElement = XMLDocument.CreateElement("PartNumber");
			XmlText XMLTextElement = XMLDocument.CreateTextNode(m_strPartNumber);
			XMLElement.AppendChild(XMLTextElement);

			XMLThisElement.AppendChild(XMLElement);
			}

		//============================================================================*
		// HasCaliber()
		//============================================================================*

		public bool HasCaliber(cCaliber Caliber, bool fHideCalibers = false)
			{
			foreach (cBulletCaliber CheckCaliber in m_BulletCaliberList)
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
		// Import()
		//============================================================================*

		public override bool Import(XmlDocument XMLDocument, XmlNode XMLThisNode, cDataFiles DataFiles)
			{
			XmlNode XMLNode = XMLThisNode.FirstChild;

			base.Import(XMLDocument, XMLThisNode, DataFiles);

			while (XMLNode != null)
				{
				switch (XMLNode.Name)
					{
					case "PartNumber":
						m_strPartNumber = XMLNode.FirstChild.Value;
						break;
					case "Type":
						m_strType = XMLNode.FirstChild.Value;
						break;
					case "SelfCast":
						m_fSelfCast = XMLNode.FirstChild.Value == "Yes";
						break;
					case "TopPunch":
						m_fSelfCast = XMLNode.FirstChild.Value == "Yes";
						break;
					case "Diameter":
						Double.TryParse(XMLNode.FirstChild.Value, out m_dDiameter);
						break;
					case "Length":
						Double.TryParse(XMLNode.FirstChild.Value, out m_dLength);
						break;
					case "Weight":
						Double.TryParse(XMLNode.FirstChild.Value, out m_dWeight);
						break;
					case "BallisticCoefficient":
						Double.TryParse(XMLNode.FirstChild.Value, out m_dBallisticCoefficient);
						break;
					case "Calibers":
					case "CaliberList":
						m_BulletCaliberList.Import(XMLDocument, XMLNode, DataFiles);
						break;

					default:
						break;
					}

				XMLNode = XMLNode.NextSibling;
				}

			return (true);
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
		// ResolveIdentities()
		//============================================================================*

		public override bool ResolveIdentities(cDataFiles DataFiles)
			{
			bool fChanged = base.ResolveIdentities(DataFiles);

			if (m_BulletCaliberList == null)
				m_BulletCaliberList = new cBulletCaliberList();

			fChanged = m_BulletCaliberList.ResolveIdentities(DataFiles) ? true : fChanged;

			return (fChanged);
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

			foreach (cBulletCaliber CheckBulletCaliber in m_BulletCaliberList)
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
			strDiameterFormat += String.Format("{0:G0}", cPreferences.StaticPreferences.DimensionDecimals);
			strDiameterFormat += "}";

			string strWeightFormat = " {0:F";
			strWeightFormat += String.Format("{0:G0}", cPreferences.StaticPreferences.BulletWeightDecimals);
			strWeightFormat += "}";

			bool fType = false;

			if (m_strPartNumber != null && m_strPartNumber.Length > 0)
				strString += String.Format(" {0}", m_strPartNumber);
			else
				{
				strString += String.Format(" {0}", m_strType);

				fType = true;
				}

			strString += String.Format(strDiameterFormat, cPreferences.StaticPreferences.MetricDimensions ? cConversions.InchesToMillimeters(m_dDiameter) : m_dDiameter);

			strString += cDataFiles.MetricString(cDataFiles.eDataType.Dimension);

			strString += String.Format(strWeightFormat, cPreferences.StaticPreferences.MetricBulletWeights ? cConversions.GrainsToGrams(m_dWeight) : m_dWeight);

			strString += cPreferences.StaticPreferences.MetricBulletWeights ? "g" : "gr";

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
			strWeightFormat += String.Format("{0:G0}", cPreferences.StaticPreferences.BulletWeightDecimals);
			strWeightFormat += "}";

			bool fType = false;

			if (m_strPartNumber != null && m_strPartNumber.Length > 0)
				strString += String.Format(" {0}", m_strPartNumber);
			else
				{
				strString += String.Format(", {0}", m_strType);

				fType = true;
				}

			strString += String.Format(strWeightFormat, cPreferences.StaticPreferences.MetricBulletWeights ? cConversions.GrainsToGrams(m_dWeight) : m_dWeight);

			strString += cPreferences.StaticPreferences.MetricBulletWeights ? " g" : " gr";

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
		// Validate()
		//============================================================================*

		public override bool Validate()
			{
			//----------------------------------------------------------------------------*
			// Check the basic identity info
			//----------------------------------------------------------------------------*

			bool fOK = base.Validate();

			if (fOK)
				fOK = !String.IsNullOrEmpty(m_strPartNumber);

			//----------------------------------------------------------------------------*
			// If this is an identity, return now
			//----------------------------------------------------------------------------*

			if (Identity)
				return (fOK);

			//----------------------------------------------------------------------------*
			// Otherwise, check the full monte for this bullet
			//----------------------------------------------------------------------------*

			if (m_dDiameter == 0.0 || m_dWeight == 0.0)
				fOK = false;

			return (fOK);
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
		}
	}

