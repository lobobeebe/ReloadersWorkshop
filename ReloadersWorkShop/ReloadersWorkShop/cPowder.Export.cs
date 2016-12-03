using System.Xml;

namespace ReloadersWorkShop
	{
	public partial class cPowder
		{
		//============================================================================*
		// CSVLine Property
		//============================================================================*

		public override string CSVLine
			{
			get
				{
				string strLine = base.CSVLine;

				strLine += m_strType;
				strLine += ",";
				strLine += ShapeString(m_eShape);

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

				strLine += "Type,Shape";

				return (strLine);
				}
			}

		//============================================================================*
		// Export() - XML Document
		//============================================================================*

		public override void Export(cRWXMLDocument XMLDocument, XmlElement XMLParentElement, bool fIdentityOnly = false)
			{
			string strName = ExportName;

			if (fIdentityOnly)
				strName += "Identity";

			XmlElement XMLThisElement = XMLDocument.CreateElement(strName, XMLParentElement);

			base.Export(XMLDocument, XMLThisElement, fIdentityOnly);

			XMLDocument.CreateElement("Type", m_strType, XMLThisElement);

			if (fIdentityOnly)
				return;

			XMLDocument.CreateElement("Shape", m_eShape, XMLThisElement);
			}

		//============================================================================*
		// ExportName Property
		//============================================================================*

		public string ExportName
			{
			get
				{
				return ("Powder");
				}
			}

		//============================================================================*
		// Import()
		//============================================================================*

		public override bool Import(cRWXMLDocument XMLDocument, XmlNode XMLThisNode, cDataFiles DataFiles)
			{
			base.Import(XMLDocument, XMLThisNode, DataFiles);

			XmlNode XMLNode = XMLThisNode.FirstChild;

			while (XMLNode != null)
				{
				switch (XMLNode.Name)
					{
					case "Type":
						m_strType = XMLNode.FirstChild.Value;
						break;
					case "Shape":
						m_eShape = cPowder.ShapeFromString(XMLNode.FirstChild.Value);
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
