//============================================================================*
// cAmmo.Export.cs
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
	// cAmmo Class
	//============================================================================*

	public partial class cAmmo
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
				strLine += m_strType;
				strLine += ",";
				strLine += m_Caliber.Name;
				strLine += ",";

				strLine += m_nBatchID;
				strLine += ",";
				strLine += m_fReload ? "Yes," : "-,";

				strLine += m_dBulletDiameter;
				strLine += ",";
				strLine += m_dBulletWeight;
				strLine += ",";
				strLine += m_dBallisticCoefficient;

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
				return ("Manufacturer,Part Number,Type,Batch ID,Reload?,Caliber,Bullet Diameter,Bullet Weight,Ballistic Coefficient");
				}
			}

		//============================================================================*
		// Export() - XML Document
		//============================================================================*

		public override void Export(cRWXMLDocument XMLDocument, XmlElement XMLParentElement, string strName = null)
			{
			XmlElement XMLThisElement = XMLDocument.CreateElement(!String.IsNullOrEmpty(strName) ? strName : ExportName);
			XMLParentElement.AppendChild(XMLThisElement);

			base.Export(XMLDocument, XMLThisElement);

			XMLDocument.CreateElement("PartNumber", m_strPartNumber, XMLThisElement);
			XMLDocument.CreateElement("Type", m_strType, XMLThisElement);
			XMLDocument.CreateElement("Type", m_strType, XMLThisElement);

			m_Caliber.ExportIdentity(XMLDocument, XMLThisElement);

			XMLDocument.CreateElement("BatchID", m_nBatchID, XMLThisElement);
			XMLDocument.CreateElement("Reload", m_fReload, XMLThisElement);
			XMLDocument.CreateElement("BulletDiameter", m_dBulletDiameter, XMLThisElement);
			XMLDocument.CreateElement("BulletWeight", m_dBulletWeight, XMLThisElement);
			XMLDocument.CreateElement("BallisticCoefficient", m_dBallisticCoefficient, XMLThisElement);

			m_TestList.Export(XMLDocument, XMLThisElement);
			}

		//============================================================================*
		// ExportIdentity() - XML Document
		//============================================================================*

		public override void ExportIdentity(cRWXMLDocument XMLDocument, XmlElement XMLParentElement, string strName = null)
			{
			string strIdentityName = !String.IsNullOrEmpty(strName) ? strName : ExportName;
			strIdentityName += "Identity";

			XmlElement XMLThisElement = XMLDocument.CreateElement(strIdentityName);
			XMLParentElement.AppendChild(XMLThisElement);

			base.Export(XMLDocument, XMLThisElement);

			// PartNumber

			XmlElement XMLElement = XMLDocument.CreateElement("PartNumber");
			XmlText XMLTextElement = XMLDocument.CreateTextNode(m_strPartNumber);
			XMLElement.AppendChild(XMLTextElement);

			XMLThisElement.AppendChild(XMLElement);
			}

		//============================================================================*
		// ExportName()
		//============================================================================*

		public static string ExportName
			{
			get
				{
				return ("Ammo");
				}
			}

		//============================================================================*
		// Import()
		//============================================================================*

		public override bool Import(XmlDocument XMLDocument, XmlNode XMLThisNode, cDataFiles DataFiles)
			{
			base.Import(XMLDocument, XMLThisNode, DataFiles);

			XmlNode XMLNode = XMLThisNode.FirstChild;

			while (XMLNode != null)
				{
				switch (XMLNode.Name)
					{
					case "CaliberIdentity":
						m_Caliber = cDataFiles.GetCaliberByIdentity(XMLDocument, XMLNode, DataFiles);
						break;
					case "Caliber":
						break;
					case "PartNumber":
						m_strPartNumber = XMLNode.FirstChild.Value;
						break;
					case "Type":
						m_strType = XMLNode.FirstChild.Value;
						break;
					case "BatchID":
						Int32.TryParse(XMLNode.FirstChild.Value, out m_nBatchID);
						break;
					case "Reload":
						m_fReload = XMLNode.FirstChild.Value == "Yes";
						break;
					case "BulletDiameter":
						Double.TryParse(XMLNode.FirstChild.Value, out m_dBulletDiameter);
						break;
					case "BulletWeight":
						Double.TryParse(XMLNode.FirstChild.Value, out m_dBulletWeight);
						break;
					case "BallisticCoefficient":
						Double.TryParse(XMLNode.FirstChild.Value, out m_dBallisticCoefficient);
						break;
					case "AmmoTests":
					case "AmmoTestList":
						m_TestList.Import(XMLDocument, XMLNode, DataFiles, this);
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
