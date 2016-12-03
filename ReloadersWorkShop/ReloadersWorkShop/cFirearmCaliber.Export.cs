using System.Xml;

namespace ReloadersWorkShop
	{
	public partial class cFirearmCaliber
		{
		//============================================================================*
		// CSVLine Property
		//============================================================================*

		public string CSVLine
			{
			get
				{
				string strLine = "";

				//----------------------------------------------------------------------------*
				// General
				//----------------------------------------------------------------------------*

				strLine += m_Caliber.ToString();
				strLine += ",";
				strLine += m_fPrimary ? "Yes" : "";
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
				return ("Caliber,Primary");
				}
			}

		//============================================================================*
		// Export() - XML Document
		//============================================================================*

		public void Export(cRWXMLDocument XMLDocument, XmlNode XMLParentNode)
			{
			XmlElement XMLThisElement = XMLDocument.CreateElement(ExportName, XMLParentNode);

			// Caliber Identity

			m_Caliber.Export(XMLDocument, XMLThisElement, true);

			// Primary

			XMLDocument.CreateElement("Primary", m_fPrimary, XMLThisElement);
			}

		//============================================================================*
		// ExportName()
		//============================================================================*

		public static string ExportName
			{
			get
				{
				return ("FirearmCaliber");
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
					case "Primary":
						m_fPrimary = XMLNode.FirstChild.Value == "Yes";
						break;
					case "CaliberIdentity":
						m_Caliber = cRWXMLDocument.GetCaliberByIdentity(XMLNode, DataFiles);
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
