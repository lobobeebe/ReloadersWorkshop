using System.Xml;

namespace ReloadersWorkShop
	{
	public partial class cLoad
		{
		//============================================================================*
		// CSVLine Property
		//============================================================================*

		public string CSVLine
			{
			get
				{
				string strLine = "";

				strLine += cFirearm.FirearmTypeString(FirearmType);
				strLine += ",";
				strLine += m_Caliber;
				strLine += ",";

				strLine += m_Bullet.ToString();
				strLine += ",";

				strLine += m_Powder.ToString();
				strLine += ",";

				strLine += m_Case.ToString();
				strLine += ",";

				strLine += m_Primer.ToString();
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
				return ("Firearm Type,Caliber,Bullet,Powder,Case,Primer");
				}
			}

		//============================================================================*
		// Export() - XML Document
		//============================================================================*

		public void Export(cRWXMLDocument XMLDocument, XmlElement XMLParentElement, bool fIdentityOnly = false)
			{
			string strElement = ExportName;

			if (fIdentityOnly)
				strElement += "Identity";

			XmlElement XMLThisElement = XMLDocument.CreateElement(strElement, XMLParentElement);

			XMLDocument.CreateElement("FirearmType", m_eFirearmType, XMLThisElement);

			cCaliber.CurrentFirearmType = m_eFirearmType;

			m_Caliber.Export(XMLDocument, XMLThisElement, true);

			m_Bullet.Export(XMLDocument, XMLThisElement, true);
			m_Powder.Export(XMLDocument, XMLThisElement, true);
			m_Primer.Export(XMLDocument, XMLThisElement, true);
			m_Case.Export(XMLDocument, XMLThisElement, true);

			if (fIdentityOnly)
				return;

			if (m_ChargeList.Count > 0)
				m_ChargeList.Export(XMLDocument, XMLThisElement);
			}

		//============================================================================*
		// ExportName()
		//============================================================================*

		public static string ExportName
			{
			get
				{
				return ("Load");
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
					case "BulletIdentity":
						m_Bullet = cRWXMLDocument.GetBulletByIdentity(XMLDocument, XMLNode, DataFiles);
						break;
					case "PowderIdentity":
						m_Powder = cRWXMLDocument.GetPowderByIdentity(XMLDocument, XMLNode, DataFiles);
						break;
					case "CaliberIdentity":
						m_Caliber = cRWXMLDocument.GetCaliberByIdentity(XMLDocument, XMLNode, DataFiles);
						break;
					case "FirearmType":
						XMLDocument.Import(XMLNode, out m_eFirearmType);
						break;
					case "PrimerIdentity":
						m_Primer = cRWXMLDocument.GetPrimerByIdentity(XMLDocument, XMLNode, DataFiles);
						break;
					case "CaseIdentity":
						m_Case = cRWXMLDocument.GetCaseByIdentity(XMLDocument, XMLNode, DataFiles);
						break;
					case "Charges":
					case "ChargeList":
						m_ChargeList.Import(XMLDocument, XMLNode, DataFiles);
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
