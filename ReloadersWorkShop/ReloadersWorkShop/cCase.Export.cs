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

	public partial class cCase
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

		public override void Export(cRWXMLDocument XMLDocument, XmlElement XMLParentElement, bool fIdentityOnly = false)
			{
			string strName = ExportName;

			if (fIdentityOnly)
				strName += "Identity";

			XmlElement XMLThisElement = XMLDocument.CreateElement(strName);
			XMLParentElement.AppendChild(XMLThisElement);

			base.Export(XMLDocument, XMLThisElement, fIdentityOnly);

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

		public string ExportName
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
						if (!String.IsNullOrEmpty(XMLNode.FirstChild.Value))
							m_strPartNumber = XMLNode.FirstChild.Value;
						else
							Console.WriteLine("cCase - Empty Part Number!");
						break;
					case "Match":
						m_fMatch = XMLNode.FirstChild.Value == "Yes";
						break;
					case "Military":
						m_fMilitary = XMLNode.FirstChild.Value == "Yes";
						break;
					case "LargePrimer":
						m_fLargePrimer = XMLNode.FirstChild.Value == "Yes";
						break;
					case "SmallPrimer":
						m_fSmallPrimer = XMLNode.FirstChild.Value == "Yes";
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
