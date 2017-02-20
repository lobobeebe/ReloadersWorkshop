//============================================================================*
// cSupply.Export.cs
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
	// cSupply Class
	//============================================================================*

	public partial class cSupply
		{
		//============================================================================*
		// CSVLine Property
		//============================================================================*

		public virtual string CSVLine
			{
			get
				{
				string strLine = "";

				strLine += SupplyTypeString(m_eType);
				strLine += ",";

				strLine += cFirearm.FirearmTypeString(m_eFirearmType);
				strLine += ",";
				strLine += m_Manufacturer.Name;
				strLine += ",";

				strLine += m_dMinimumStockLevel;
				strLine += ",";

				strLine += m_fCrossUse ? "Yes" : "";
				strLine += ",";

				strLine += m_dQuantity;
				strLine += ",";

				strLine += m_dCost;
				strLine += ",";

				strLine += m_fChecked ? "Yes" : "";

				return (strLine);
				}
			}

		//============================================================================*
		// CSVSupplyLineHeader Property
		//============================================================================*

		public static string CSVSupplyLineHeader
			{
			get
				{
				return ("Supply Type,Firearm Type,Manufacturer,Min Stock Level,Cross Use,Quantity,Cost,Checked");
				}
			}

		//============================================================================*
		// Export() - XML Document
		//============================================================================*

		public virtual void Export(cRWXMLDocument XMLDocument, XmlElement XMLParentElement, bool fIdentityOnly = false, bool fIncludeTransactions = true)
			{
			XMLDocument.CreateElement("SupplyType", m_eType, XMLParentElement);
			XMLDocument.CreateElement("FirearmType", m_eFirearmType, XMLParentElement);
			XMLDocument.CreateElement("Manufacturer", m_Manufacturer.Name, XMLParentElement);

			if (fIdentityOnly)
				return;

			XMLDocument.CreateElement("CrossUse", m_fCrossUse, XMLParentElement);
			XMLDocument.CreateElement("MinStockLevel", m_dMinimumStockLevel, XMLParentElement);
			XMLDocument.CreateElement("Quantity", m_dQuantity, XMLParentElement);
			XMLDocument.CreateElement("Cost", m_dCost, XMLParentElement);
			XMLDocument.CreateElement("Checked", m_fChecked, XMLParentElement);

			if (fIncludeTransactions)
				TransactionList.Export(XMLDocument, XMLParentElement);
			}

		//============================================================================*
		// Import()
		//============================================================================*

		public virtual bool Import(cRWXMLDocument XMLDocument, XmlNode XMLThisNode)
			{
			XmlNode XMLNode = XMLThisNode.FirstChild;

			while (XMLNode != null)
				{
				switch (XMLNode.Name)
					{
					case "SupplyType":
						XMLDocument.Import(XMLNode, out m_eType);
						break;
					case "FirearmType":
						XMLDocument.Import(XMLNode, out m_eFirearmType);
						break;
					case "Manufacturer":
						XMLDocument.Import(XMLDocument, XMLNode, out m_Manufacturer);
						break;
					case "CrossUse":
						XMLDocument.Import(XMLNode, out m_fCrossUse);
						break;
					case "MinStockLevel":
						XMLDocument.Import(XMLNode, out m_dMinimumStockLevel);
						break;
					case "Quantity":
						XMLDocument.Import(XMLNode, out m_dQuantity);
						break;
					case "Cost":
						XMLDocument.Import(XMLNode, out m_dCost);
						break;
					case "Checked":
						XMLDocument.Import(XMLNode, out m_fChecked);
						break;
					case "Transactions":
					case "TransactionList":
						m_TransactionList.Import(XMLDocument, XMLNode, DataFiles, this);
						break;
					default:
						break;
					}

				XMLNode = XMLNode.NextSibling;
				}

			return (true);
			}
		}
	}
