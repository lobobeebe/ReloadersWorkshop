using System;
using System.Xml;

namespace ReloadersWorkShop
	{
	public partial class cCaliber
		{
		//============================================================================*
		// CSVLine Property
		//============================================================================*

		public string CSVLine
			{
			get
				{
				string strLine = "";

				strLine += m_strName;
				strLine += ",";

				strLine += cFirearm.FirearmTypeString(m_eFirearmType);
				strLine += ",";

				strLine += m_strHeadStamp;

				if (m_eFirearmType == cFirearm.eFireArmType.Handgun)
					strLine += m_fPistol ? ",Pistol" : ",Revolver";
				else
					strLine += ",N/A";

				strLine += m_fSmallPrimer ? ",Yes" : ",-";
				strLine += m_fLargePrimer ? ",Yes" : ",-";
				strLine += m_fMagnumPrimer ? ",Yes" : ",-";

				//----------------------------------------------------------------------------*
				// Dimensions
				//----------------------------------------------------------------------------*

				strLine += ",";
				strLine += m_dMinBulletDiameter;
				strLine += ",";
				strLine += m_dMaxBulletDiameter;

				strLine += ",";
				strLine += m_dMinBulletWeight;
				strLine += ",";
				strLine += m_dMaxBulletWeight;

				strLine += ",";
				strLine += m_dCaseTrimLength;
				strLine += ",";
				strLine += m_dMaxCaseLength;

				strLine += ",";
				strLine += m_dMaxCOL;

				strLine += ",";
				strLine += m_dMaxNeckDiameter;

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
				string strLine = "Name,Firearm Type,Headstamp,Handgun Type,Small Primer,Large Primer,Magnum Primer,Min Bullet Dia.,Max Bullet Dia.,Min Bullet Weight,Max Bullet Weight,Case Trim Length,Max Case Length,Max COAL,Max Neck Dia";

				return (strLine);
				}
			}

		//============================================================================*
		// Export() - XML Document
		//============================================================================*

		public void Export(cRWXMLDocument XMLDocument, XmlNode XMLParentNode, bool fIdentityOnly = false)
			{
			string strName = ExportName;

			if (fIdentityOnly)
				strName += "Identity";

			XmlElement XMLThisElement = XMLDocument.CreateElement(strName, XMLParentNode);

			XMLDocument.CreateElement("FirearmType", m_eFirearmType, XMLThisElement);
			XMLDocument.CreateElement("Name", m_strName, XMLThisElement);

			if (fIdentityOnly)
				return;

			XMLDocument.CreateElement("HeadStamp", m_strHeadStamp, XMLThisElement);
			XMLDocument.CreateElement("Pistol", m_fPistol, XMLThisElement);

			string strHandgunType = "N/A";

			if (m_eFirearmType == cFirearm.eFireArmType.Handgun)
				{
				if (m_eFirearmType == cFirearm.eFireArmType.Handgun)
					strHandgunType = m_fPistol ? "Pistol" : "Revolver";
				}

			XMLDocument.CreateElement("HandgunType", strHandgunType, XMLThisElement);
			XMLDocument.CreateElement("SAAMIPDF", m_strSAAMIPDF, XMLThisElement);
			XMLDocument.CreateElement("SmallPrimer", m_fSmallPrimer, XMLThisElement);
			XMLDocument.CreateElement("LargePrimer", m_fLargePrimer, XMLThisElement);
			XMLDocument.CreateElement("MagnumPrimer", m_fMagnumPrimer, XMLThisElement);

			//----------------------------------------------------------------------------*
			// Dimensions
			//----------------------------------------------------------------------------*

			XMLDocument.CreateElement("MinBulletDiameter", m_dMinBulletDiameter, XMLThisElement);
			XMLDocument.CreateElement("MaxBulletDiameter", m_dMaxBulletDiameter, XMLThisElement);
			XMLDocument.CreateElement("MinBulletWeight", m_dMinBulletWeight, XMLThisElement);
			XMLDocument.CreateElement("MaxBulletWeight", m_dMaxBulletWeight, XMLThisElement);
			XMLDocument.CreateElement("CaseTrimLength", m_dCaseTrimLength, XMLThisElement);
			XMLDocument.CreateElement("MaxCaseLength", m_dMaxCaseLength, XMLThisElement);
			XMLDocument.CreateElement("MaxCOAL", m_dMaxCOL, XMLThisElement);
			XMLDocument.CreateElement("MaxNeckDiameter", m_dMaxNeckDiameter, XMLThisElement);
			XMLDocument.CreateElement("Checked", m_fChecked, XMLThisElement);
			}

		//============================================================================*
		// ExportName Property
		//============================================================================*

		public static string ExportName
			{
			get
				{
				return ("Caliber");
				}
			}

		//============================================================================*
		// Import()
		//============================================================================*

		public bool Import(cRWXMLDocument XMLDocument, XmlNode XMLThisNode)
			{
			XmlNode XMLNode = XMLThisNode.FirstChild;

			while (XMLNode != null)
				{
				switch (XMLNode.Name)
					{
					case "FirearmType":
						m_eFirearmType = cFirearm.FirearmTypeFromString(XMLNode.FirstChild.Value);
						break;
					case "Name":
						m_strName = XMLNode.FirstChild.Value;
						break;
					case "HeadStamp":
						m_strHeadStamp = XMLNode.FirstChild.Value;
						break;
					case "HandgunType":
						m_fPistol = XMLNode.FirstChild.Value == "Pistol";
						break;
					case "SmallPrimer":
						m_fSmallPrimer = XMLNode.FirstChild.Value == "Yes";
						break;
					case "LargePrimer":
						m_fLargePrimer = XMLNode.FirstChild.Value == "Yes";
						break;
					case "MagnumPrimer":
						m_fMagnumPrimer = XMLNode.FirstChild.Value == "Yes";
						break;
					case "MinBulletDiameter":
						Double.TryParse(XMLNode.FirstChild.Value, out m_dMinBulletDiameter);
						break;
					case "MaxBulletDiameter":
						Double.TryParse(XMLNode.FirstChild.Value, out m_dMaxBulletDiameter);
						break;
					case "MinBulletWeight":
						Double.TryParse(XMLNode.FirstChild.Value, out m_dMinBulletWeight);
						break;
					case "MaxBulletWeight":
						Double.TryParse(XMLNode.FirstChild.Value, out m_dMaxBulletWeight);
						break;
					case "CaseTrimLength":
						Double.TryParse(XMLNode.FirstChild.Value, out m_dCaseTrimLength);
						break;
					case "MaxCaseLength":
						Double.TryParse(XMLNode.FirstChild.Value, out m_dMaxCaseLength);
						break;
					case "MaxCOAL":
						Double.TryParse(XMLNode.FirstChild.Value, out m_dMaxCOL);
						break;
					case "MaxNeckDiameter":
						Double.TryParse(XMLNode.FirstChild.Value, out m_dMaxNeckDiameter);
						break;
					case "SAAMIPDF":
						m_strSAAMIPDF = XMLNode.FirstChild.Value;
						break;
					case "Checked":
						m_fChecked = XMLNode.FirstChild.Value == "Yes";
						break;
					default:
						break;
					}

				XMLNode = XMLNode.NextSibling;
				}

			return (Validate(Identity));
			}
		}
	}
