//============================================================================*
// cCharge.Export.cs
//
// Copyright © 2013-2014, Kevin S. Beebe
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
	// cCharge Class
	//============================================================================*

	public partial class cCharge
		{
		//============================================================================*
		// CSVLine Property
		//============================================================================*

		public string CSVLine
			{
			get
				{
				string strLine = ",";

				strLine += m_dPowderWeight;
				strLine += ",";
				strLine += m_dFillRatio;
				strLine += ",";
				strLine += m_fFavorite ? "Yes" : "-";
				strLine += ",";
				strLine += m_fReject ? "Yes" : "-";

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
				return ("Powder Weight,Fill Ratio,Favorite,Reject");
				}
			}

		//============================================================================*
		// Export() - XML Document
		//============================================================================*

		public void Export(cRWXMLDocument XMLDocument, XmlElement XMLParentElement)
			{
			XmlElement XMLThisElement = XMLDocument.CreateElement("Charge");
			XMLParentElement.AppendChild(XMLThisElement);

			// PowderWeight

			XmlElement XMLElement = XMLDocument.CreateElement("PowderWeight");
			XmlText XMLTextElement = XMLDocument.CreateTextNode(String.Format("{0}", m_dPowderWeight));
			XMLElement.AppendChild(XMLTextElement);

			XMLThisElement.AppendChild(XMLElement);

			// Fill Ratio

			XMLElement = XMLDocument.CreateElement("FillRatio");
			XMLTextElement = XMLDocument.CreateTextNode(String.Format("{0}", m_dFillRatio));
			XMLElement.AppendChild(XMLTextElement);

			XMLThisElement.AppendChild(XMLElement);

			// Favorite

			XMLElement = XMLDocument.CreateElement("Favorite");
			XMLTextElement = XMLDocument.CreateTextNode(m_fFavorite ? "Yes" : "-");
			XMLElement.AppendChild(XMLTextElement);

			XMLThisElement.AppendChild(XMLElement);

			// Reject

			XMLElement = XMLDocument.CreateElement("Reject");
			XMLTextElement = XMLDocument.CreateTextNode(m_fReject ? "Yes" : "-");
			XMLElement.AppendChild(XMLTextElement);

			XMLThisElement.AppendChild(XMLElement);

			TestList.Export(XMLDocument, XMLThisElement);
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
					case "PowderWeight":
						Double.TryParse(XMLNode.FirstChild.Value, out m_dPowderWeight);
						break;
					case "FillRatio":
						Double.TryParse(XMLNode.FirstChild.Value, out m_dFillRatio);
						break;
					case "Favorite":
						m_fFavorite = XMLNode.FirstChild.Value == "Yes";
						break;
					case "Reject":
						m_fReject = XMLNode.FirstChild.Value == "Yes";
						break;
					case "ChargeTestList":
						m_TestList.Import(XMLDocument, XMLNode, DataFiles);
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
