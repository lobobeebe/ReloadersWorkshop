using System;
using System.Xml;

namespace ReloadersWorkShop
	{
	public partial class cGear
		{
		//============================================================================*
		// CSVLineHeaderExtension Property
		//============================================================================*

		public virtual string CSVLineHeaderExtension
			{
			get
				{
				return ("");
				}
			}

		//============================================================================*
		// CSVLine Property
		//============================================================================*

		public virtual string CSVLine
			{
			get
				{
				string strLine = cGear.GearTypeString(m_eType);
				strLine += ",";
				strLine += m_Manufacturer.ToString();
				strLine += ",";
				strLine += m_strPartNumber;
				strLine += ",";
				strLine += m_strSerialNumber;
				strLine += ",";
				strLine += m_strDescription;
				strLine += ",";
				strLine += m_strSource;
				strLine += ",";
				strLine += m_Date.ToShortDateString();
				strLine += ",";
				strLine += m_dPrice;
				strLine += ",";
				strLine += m_dTax;
				strLine += ",";
				strLine += m_dShipping;

				switch (m_eType)
					{
					case eGearTypes.Scope:
						strLine += (this as cScope).CSVLineExtension;
						break;
					}

				strLine += ",";
				strLine += m_strNotes;

				return (strLine);
				}
			}

		//============================================================================*
		// CSVLineExtension Property
		//============================================================================*

		public virtual string CSVLineExtension
			{
			get
				{
				return ("");
				}
			}

		//============================================================================*
		// CSVGearLineHeader Property
		//============================================================================*

		public virtual string CSVGearLineHeader
			{
			get
				{
				string strLine = "Gear Type,Manufacturer,Part Number,Serial Number,Description,Acquired From,Purchase Date,Purchase Price,Tax,Shipping";

				switch (m_eType)
					{
					case eGearTypes.Scope:
						strLine += (this as cScope).CSVLineHeaderExtension;
						break;
					}

				strLine += ",Notes";

				return (strLine);
				}
			}

		//============================================================================*
		// Export() - XML Document
		//============================================================================*

		public virtual void Export(cRWXMLDocument XMLDocument, XmlElement XMLThisElement, bool fIdentityOnly = false)
			{
			XMLDocument.CreateElement("GearType", cGear.GearTypeString(m_eType), XMLThisElement);
			XMLDocument.CreateElement("Manufacturer", m_Manufacturer.Name, XMLThisElement);
			XMLDocument.CreateElement("PartNumber", m_strPartNumber, XMLThisElement);
			XMLDocument.CreateElement("SerialNumber", m_strSerialNumber, XMLThisElement);

			if (fIdentityOnly)
				return;

			XMLDocument.CreateElement("Description", m_strDescription, XMLThisElement);
			XMLDocument.CreateElement("AcquiredFrom", m_strSource, XMLThisElement);
			XMLDocument.CreateElement("PurchaseDate", m_Date, XMLThisElement);
			XMLDocument.CreateElement("Price", m_dPrice, XMLThisElement);
			XMLDocument.CreateElement("Tax", m_dTax, XMLThisElement);
			XMLDocument.CreateElement("Shipping", m_dTax, XMLThisElement);

			//----------------------------------------------------------------------------*
			// Notes
			//----------------------------------------------------------------------------*

			XMLDocument.CreateElement("Notes", m_strNotes, XMLThisElement);
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
					case "Manufacturer":
						Manufacturer = DataFiles.GetManufacturerByName(XMLNode.FirstChild.Value);
						break;
					case "PartNumber":
					case "Model":
						m_strPartNumber = XMLNode.FirstChild.Value;
						break;
					case "SerialNumber":
						m_strSerialNumber = XMLNode.FirstChild.Value;
						break;
					case "Description":
						m_strDescription = XMLNode.FirstChild.Value;
						break;
					case "AcquiredFrom":
					case "Source":
						m_strSource = XMLNode.FirstChild.Value;
						break;
					case "PurchaseDate":
					case "DatePurchased":
						DateTime.TryParse(XMLNode.FirstChild.Value, out m_Date);
						break;
					case "PurchasePrice":
					case "Price":
					case "Cost":
						Double.TryParse(XMLNode.FirstChild.Value, out m_dPrice);
						break;
					case "Notes":
						m_strNotes = XMLNode.FirstChild.Value;
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
