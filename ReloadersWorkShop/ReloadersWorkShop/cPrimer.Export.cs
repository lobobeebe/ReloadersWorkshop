using System;
using System.Xml;

namespace ReloadersWorkShop
	{
	public partial class cPrimer
		{
		//============================================================================*
		// CSVLine Property
		//============================================================================*

		public override string CSVLine
			{
			get
				{
				string strLine = base.CSVLine;

				strLine += m_strModel;
				strLine += ",";

				strLine += m_eSize == ePrimerSize.Small ? "Small" : "Large";
				strLine += ",";

				strLine += m_fStandard ? "Yes," : "-,";
				strLine += m_fMagnum ? "Yes," : "-,";
				strLine += m_fBenchRest ? "Yes," : "-,";
				strLine += m_fMilitary ? "Yes," : "-";

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

				strLine += "Model,Size,Standard,Magnum,Bench Rest,Military";

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

			XMLDocument.CreateElement("Model", m_strModel, XMLThisElement);

			if (fIdentityOnly)
				return;

			XMLDocument.CreateElement("Size", m_eSize, XMLThisElement);
			XMLDocument.CreateElement("Standard", m_fStandard, XMLThisElement);
			XMLDocument.CreateElement("Magnum", m_fMagnum, XMLThisElement);
			XMLDocument.CreateElement("BenchRest", m_fBenchRest, XMLThisElement);
			XMLDocument.CreateElement("Military", m_fMilitary, XMLThisElement);
			}

		//============================================================================*
		// ExportName Property
		//============================================================================*

		public string ExportName
			{
			get
				{
				return ("Primer");
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
					case "Model":
						m_strModel = XMLNode.FirstChild.Value;
						break;
					case "Size":
						m_eSize = XMLNode.FirstChild.Value == "Small" ? ePrimerSize.Small : ePrimerSize.Large;
						break;
					case "Standard":
						m_fStandard = XMLNode.FirstChild.Value == "Yes";
						break;
					case "Magnum":
						m_fMagnum = XMLNode.FirstChild.Value == "Yes";
						break;
					case "BenchRest":
						m_fBenchRest = XMLNode.FirstChild.Value == "Yes";
						break;
					case "Military":
						m_fMilitary = XMLNode.FirstChild.Value == "Yes";
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
