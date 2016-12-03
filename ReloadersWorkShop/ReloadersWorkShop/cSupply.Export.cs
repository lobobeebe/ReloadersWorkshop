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

		public virtual void Export(cRWXMLDocument XMLDocument, XmlElement XMLParentElement, bool fIdentityOnly = false)
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
			}

		//============================================================================*
		// Import()
		//============================================================================*

		public virtual bool Import(cRWXMLDocument XMLDocument, XmlNode XMLThisNode, cDataFiles DataFiles)
			{
			XmlNode XMLNode = XMLThisNode.FirstChild;

			while (XMLNode != null)
				{
				switch (XMLNode.Name)
					{
					case "FirearmType":
						m_eFirearmType = cFirearm.FirearmTypeFromString(XMLNode.FirstChild.Value);
						break;
					case "Manufacturer":
						m_Manufacturer = DataFiles.GetManufacturerByName(XMLNode.FirstChild.Value);
						break;
					case "CrossUse":
						m_fCrossUse = XMLNode.FirstChild.Value == "Yes";
						break;
					case "MinStockLevel":
						Double.TryParse(XMLNode.FirstChild.Value, out m_dMinimumStockLevel);
						break;
					case "Quantity":
						Double.TryParse(XMLNode.FirstChild.Value, out m_dQuantity);
						break;
					case "Cost":
						Double.TryParse(XMLNode.FirstChild.Value, out m_dCost);
						break;
					case "Checked":
						m_fChecked = XMLNode.FirstChild.Value == "Yes";
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
