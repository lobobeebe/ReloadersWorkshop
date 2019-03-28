//============================================================================*
// cTransaction.Export.cs
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
	// cTransaction Class
	//============================================================================*

	public partial class cTransaction
		{
		//============================================================================*
		// CSVLine Property
		//============================================================================*

		public string CSVLine
			{
			get
				{
				string strLine = "";

				strLine += cTransaction.TransactionTypeString(m_eTransactionType);

				strLine += m_strSource;
				strLine += m_Date.ToShortDateString();

				strLine += m_dQuantity;
				strLine += m_dCost;
				strLine += m_dTax;
				strLine += m_dShipping;

				strLine += m_nBatchID;

				strLine += m_fArchived ? "Yes" : "-";
				strLine += m_fChecked ? "Yes" : "-";
				strLine += m_fApplyTax ? "Yes" : "-";
				strLine += m_fAutoTrans ? "Yes" : "-";

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
				string strLine = "Transaction Type,Source,Date,Quantity,Cost,Tax,Shipping,Batch ID,Archived,Checked,Apply Tax,Auto Trans";

				return (strLine);
				}
			}

		//============================================================================*
		// Export()
		//============================================================================*

		public void Export(cRWXMLDocument XMLDocument, XmlElement XMLParentElement)
			{
			XmlElement XMLThisElement = XMLDocument.CreateElement(ExportName, XMLParentElement);

			XMLDocument.CreateElement("TransactionType", m_eTransactionType, XMLThisElement);

			m_Supply.Export(XMLDocument, XMLThisElement, true);

			XMLDocument.CreateElement("Source", m_strSource, XMLThisElement);
			XMLDocument.CreateElement("Date", m_Date, XMLThisElement);
			XMLDocument.CreateElement("Quantity", m_dQuantity, XMLThisElement);
			XMLDocument.CreateElement("Cost", m_dCost, XMLThisElement);
			XMLDocument.CreateElement("Tax", m_dTax, XMLThisElement);
			XMLDocument.CreateElement("Shipping", m_dShipping, XMLThisElement);
			XMLDocument.CreateElement("BatchID", m_nBatchID, XMLThisElement);
			XMLDocument.CreateElement("Archived", m_fArchived, XMLThisElement);
			XMLDocument.CreateElement("ApplyTax", m_fApplyTax, XMLThisElement);
			XMLDocument.CreateElement("AutoTrans", m_fAutoTrans, XMLThisElement);
			XMLDocument.CreateElement("Checked", m_fChecked, XMLThisElement);
			}

		//============================================================================*
		// ExportName()
		//============================================================================*

		public static string ExportName
			{
			get
				{
				return ("Transaction");
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
					case "TransactionType":
						m_eTransactionType = cTransaction.TransactionDescriptionFromString(XMLNode.FirstChild.Value);
						break;
					case "Source":
						m_strSource = XMLNode.FirstChild.Value;
						break;
					case "Date":
						DateTime.TryParse(XMLNode.FirstChild.Value, out m_Date);
						break;
					case "Quantity":
						Double.TryParse(XMLNode.FirstChild.Value, out m_dQuantity);
						break;
					case "Cost":
						Double.TryParse(XMLNode.FirstChild.Value, out m_dCost);
						break;
					case "Tax":
						Double.TryParse(XMLNode.FirstChild.Value, out m_dTax);
						break;
					case "Shipping":
						Double.TryParse(XMLNode.FirstChild.Value, out m_dShipping);
						break;
					case "BatchID":
						Int32.TryParse(XMLNode.FirstChild.Value, out m_nBatchID);
						break;
					case "Archived":
						m_fArchived = XMLNode.FirstChild.Value == "Yes";
						break;
					case "ApplyTax":
						m_fApplyTax = XMLNode.FirstChild.Value == "Yes";
						break;
					case "AutoTrans":
						m_fAutoTrans = XMLNode.FirstChild.Value == "Yes";
						break;
					case "Checked":
						m_fChecked = XMLNode.FirstChild.Value == "Yes";
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
