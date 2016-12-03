using System;
using System.Xml;

namespace ReloadersWorkShop
	{
	public partial class cBulletCaliber
		{
		//============================================================================*
		// CSVLine Property
		//============================================================================*

		public string CSVLine
			{
			get
				{
				string strLine = m_Caliber.ToString();
				;
				strLine += ",";

				strLine += m_dCOL.ToString();
				strLine += ",";
				strLine += m_dCBTO.ToString();
				strLine += ",";

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
				return ("Caliber,COAL,CBTO");
				}
			}

		//============================================================================*
		// Export() - XML Document
		//============================================================================*

		public void Export(cRWXMLDocument XMLDocument, XmlElement XMLParentElement, bool fIdentityOnly = false)
			{
			string strName = ExportName;

			if (fIdentityOnly)
				strName += "Identity";

			XmlElement XMLThisElement = XMLDocument.CreateElement(strName, XMLParentElement);

			m_Caliber.Export(XMLDocument, XMLThisElement, true);

			XMLDocument.CreateElement("COAL", m_dCOL, XMLThisElement);
			XMLDocument.CreateElement("CBTO", m_dCBTO, XMLThisElement);
			}

		//============================================================================*
		// ExportName Property
		//============================================================================*

		public string ExportName
			{
			get
				{
				return ("BulletCaliber");
				}
			}

		//============================================================================*
		// Import()
		//============================================================================*

		public bool Import(cRWXMLDocument XMLDocument, XmlNode XMLThisNode, cDataFiles DataFiles)
			{
			XmlNode XMLNode = XMLThisNode.FirstChild;

			while (XMLNode != null)
				{
				switch (XMLNode.Name)
					{
					case "CaliberIdentity":
						m_Caliber = cRWXMLDocument.GetCaliberByIdentity(XMLNode, DataFiles);
						break;
					case "COAL":
						Double.TryParse(XMLNode.FirstChild.Value, out m_dCOL);
						break;
					case "CBTO":
						Double.TryParse(XMLNode.FirstChild.Value, out m_dCBTO);
						break;
					default:
						break;
					}

				XMLNode = XMLNode.NextSibling;
				}

			return (Validate());
			}
		}
	}
