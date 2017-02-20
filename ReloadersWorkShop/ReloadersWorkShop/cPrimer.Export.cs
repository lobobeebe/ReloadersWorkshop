using System;
using System.Xml;

namespace ReloadersWorkShop
	{
	public partial class cPrimer : cSupply
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

		public override void Export(cRWXMLDocument XMLDocument, XmlElement XMLParentElement, bool fIdentityOnly = false, bool fIncludeTransactions = true)
			{
			string strName = ExportName;

			if (fIdentityOnly)
				strName += "Identity";

			XmlElement XMLThisElement = XMLDocument.CreateElement(strName, XMLParentElement);

			base.Export(XMLDocument, XMLThisElement, fIdentityOnly, fIncludeTransactions);

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

		public static string ExportName
			{
			get
				{
				return ("Primer");
				}
			}

		//============================================================================*
		// Import()
		//============================================================================*

		public override bool Import(cRWXMLDocument XMLDocument, XmlNode XMLThisNode)
			{
			base.Import(XMLDocument, XMLThisNode);

			XmlNode XMLNode = XMLThisNode.FirstChild;

			while (XMLNode != null)
				{
				switch (XMLNode.Name)
					{
					case "Model":
						XMLDocument.Import(XMLNode, out m_strModel);
						break;
					case "Size":
						XMLDocument.Import(XMLNode, out m_eSize);
						break;
					case "Standard":
						XMLDocument.Import(XMLNode, out m_fStandard);
						break;
					case "Magnum":
						XMLDocument.Import(XMLNode, out m_fMagnum);
						break;
					case "BenchRest":
						XMLDocument.Import(XMLNode, out m_fBenchRest);
						break;
					case "Military":
						XMLDocument.Import(XMLNode, out m_fMilitary);
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
