using System;
using System.Xml;

namespace ReloadersWorkShop
	{
	public partial class cBullet
		{
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
		// Export() - XML Document
		//============================================================================*

		public override void Export(cRWXMLDocument XMLDocument, XmlElement XMLParentElement,  bool fIdentityOnly = false)
			{
			string strName = ExportName;

			if (fIdentityOnly)
				strName += "Identity";

			XmlElement XMLThisElement = XMLDocument.CreateElement(strName);
			XMLParentElement.AppendChild(XMLThisElement);

			base.Export(XMLDocument, XMLThisElement, fIdentityOnly);

			XMLDocument.CreateElement("PartNumber", m_strPartNumber, XMLThisElement);

			if (fIdentityOnly)
				return;

			XMLDocument.CreateElement("Type", m_strType, XMLThisElement);
			XMLDocument.CreateElement("SelfCast", m_fSelfCast, XMLThisElement);
			XMLDocument.CreateElement("TopPunch", m_nTopPunch, XMLThisElement);
			XMLDocument.CreateElement("Diameter", m_dDiameter, XMLThisElement);
			XMLDocument.CreateElement("Length", m_dLength, XMLThisElement);
			XMLDocument.CreateElement("Weight", m_dWeight, XMLThisElement);
			XMLDocument.CreateElement("BallisticCoefficient", m_dBallisticCoefficient, XMLThisElement);

			m_BulletCaliberList.Export(XMLDocument, XMLThisElement);
			}

		//============================================================================*
		// ExportName Property
		//============================================================================*

		public static string ExportName
			{
			get
				{
				return ("Bullet");
				}
			}

		//============================================================================*
		// Import()
		//============================================================================*

		public override bool Import(cRWXMLDocument XMLDocument, XmlNode XMLThisNode, cDataFiles DataFiles)
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
					case "BulletCalibers":
					case "BulletCaliberList":
						m_BulletCaliberList.Import(XMLDocument, XMLNode, DataFiles);
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
