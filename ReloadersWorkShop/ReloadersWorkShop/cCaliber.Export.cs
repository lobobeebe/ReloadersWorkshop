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
				strLine += m_fRimfire ? ",Yes" : ",-";

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
				string strLine = "Name,Firearm Type,Headstamp,Handgun Type,Small Primer,Large Primer,Magnum Primer,Rimfire,Min Bullet Dia.,Max Bullet Dia.,Min Bullet Weight,Max Bullet Weight,Case Trim Length,Max Case Length,Max COAL,Max Neck Dia";

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

			//----------------------------------------------------------------------------*
			// General Data
			//----------------------------------------------------------------------------*

			XMLDocument.CreateElement("HeadStamp", m_strHeadStamp, XMLThisElement);
			XMLDocument.CreateElement("Pistol", m_fPistol, XMLThisElement);
			XMLDocument.CreateElement("SAAMIPDF", m_strSAAMIPDF, XMLThisElement);
			XMLDocument.CreateElement("SmallPrimer", m_fSmallPrimer, XMLThisElement);
			XMLDocument.CreateElement("LargePrimer", m_fLargePrimer, XMLThisElement);
			XMLDocument.CreateElement("MagnumPrimer", m_fMagnumPrimer, XMLThisElement);
			XMLDocument.CreateElement("Rimfire", m_fRimfire, XMLThisElement);

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
						XMLDocument.Import(XMLNode, out m_eFirearmType);
						break;
					case "Name":
						XMLDocument.Import(XMLNode, out m_strName);
						break;
					case "HeadStamp":
						XMLDocument.Import(XMLNode, out m_strHeadStamp);
						break;
					case "HandgunType":
						string strHandgunType = "Pistol";
						XMLDocument.Import(XMLNode, out strHandgunType);
						m_fPistol = (strHandgunType == "Pistol");
						break;
					case "SmallPrimer":
						XMLDocument.Import(XMLNode, out m_fSmallPrimer);
						break;
					case "LargePrimer":
						XMLDocument.Import(XMLNode, out m_fLargePrimer);
						break;
					case "MagnumPrimer":
						XMLDocument.Import(XMLNode, out m_fMagnumPrimer);
						break;
					case "Rimfire":
						XMLDocument.Import(XMLNode, out m_fRimfire);
						break;
					case "MinBulletDiameter":
						XMLDocument.Import(XMLNode, out m_dMinBulletDiameter);
						break;
					case "MaxBulletDiameter":
						XMLDocument.Import(XMLNode, out m_dMaxBulletDiameter);
						break;
					case "MinBulletWeight":
						XMLDocument.Import(XMLNode, out m_dMinBulletWeight);
						break;
					case "MaxBulletWeight":
						XMLDocument.Import(XMLNode, out m_dMaxBulletWeight);
						break;
					case "CaseTrimLength":
						XMLDocument.Import(XMLNode, out m_dCaseTrimLength);
						break;
					case "MaxCaseLength":
						XMLDocument.Import(XMLNode, out m_dMaxCaseLength);
						break;
					case "MaxCOAL":
					case "MaxCOL":
						XMLDocument.Import(XMLNode, out m_dMaxCOL);
						break;
					case "MaxNeckDiameter":
						XMLDocument.Import(XMLNode, out m_dMaxNeckDiameter);
						break;
					case "Pistol":
						XMLDocument.Import(XMLNode, out m_fPistol);
						break;
					case "SAAMIPDF":
						XMLDocument.Import(XMLNode, out m_strSAAMIPDF);
						break;
					case "Checked":
						XMLDocument.Import(XMLNode, out m_fChecked);
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
