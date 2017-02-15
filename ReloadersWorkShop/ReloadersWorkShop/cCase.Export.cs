//============================================================================*
// cCase.Export.cs
//
// Copyright © 2013-2017, Kevin S. Beebe
// All Rights Reserved
//============================================================================*

//============================================================================*
// .Net Using Statements
//============================================================================*

using System;
using System.Xml;

//============================================================================*
// Namespace
//============================================================================*

namespace ReloadersWorkShop
	{
	//============================================================================*
	// cCase Class - Partial
	//============================================================================*

	public partial class cCase : cSupply
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
				strLine += m_Caliber.Name;
				strLine += ",";
				strLine += m_fMatch ? "Yes," : "-,";
				strLine += ",";
				strLine += m_fMilitary ? "Yes," : "-,";
				strLine += ",";
				strLine += m_fLargePrimer ? "Yes," : "-,";
				strLine += ",";
				strLine += m_fSmallPrimer ? "Yes," : "-,";

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

				strLine += "Part Number,Caliber,Match,Military,Large Primer,Small Primer";

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

			XmlElement XMLThisElement = XMLDocument.CreateElement(strName);
			XMLParentElement.AppendChild(XMLThisElement);

			base.Export(XMLDocument, XMLThisElement, fIdentityOnly, fIncludeTransactions);

			XMLDocument.CreateElement("PartNumber", m_strPartNumber, XMLThisElement);

			m_Caliber.Export(XMLDocument, XMLThisElement, true);

			if (fIdentityOnly)
				return;

			XMLDocument.CreateElement("Match", m_fMatch, XMLThisElement);
			XMLDocument.CreateElement("Military", m_fMilitary, XMLThisElement);
			XMLDocument.CreateElement("LargePrimer", m_fLargePrimer, XMLThisElement);
			XMLDocument.CreateElement("SmallPrimer", m_fSmallPrimer, XMLThisElement);
			}

		//============================================================================*
		// ExportName Property
		//============================================================================*

		public static string ExportName
			{
			get
				{
				return ("Case");
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
				if (XMLNode.FirstChild == null)
					{
					XMLNode = XMLNode.NextSibling;

					continue;
					}

				switch (XMLNode.Name)
					{
					case "CaliberIdentity":
						m_Caliber = cRWXMLDocument.GetCaliberByIdentity(XMLDocument, XMLNode, DataFiles);
						break;
					case "PartNumber":
						XMLDocument.Import(XMLNode, out m_strPartNumber);
						break;
					case "Match":
						XMLDocument.Import(XMLNode, out m_fMatch);
						break;
					case "Military":
						XMLDocument.Import(XMLNode, out m_fMilitary);
						break;
					case "LargePrimer":
						XMLDocument.Import(XMLNode, out m_fLargePrimer);
						break;
					case "SmallPrimer":
						XMLDocument.Import(XMLNode, out m_fSmallPrimer);
						break;
					}

				XMLNode = XMLNode.NextSibling;
				}

			return (Validate());
			}
		}
	}
