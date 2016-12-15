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

		public override void Export(cRWXMLDocument XMLDocument, XmlElement XMLParentElement, bool  fIdentityOnly = false)
			{
			string strName = ExportName;

			if (fIdentityOnly)
				strName += "Identity";

			XmlElement XMLThisElement = XMLDocument.CreateElement(strName, XMLParentElement);

			base.Export(XMLDocument, XMLThisElement);

			XMLDocument.CreateElement("PartNumber", m_strPartNumber, XMLThisElement);

			if (fIdentityOnly)
				return;

			XMLDocument.CreateElement("Type", m_strType, XMLThisElement);

			m_Caliber.Export(XMLDocument, XMLThisElement,true);

			XMLDocument.CreateElement("BatchID", m_nBatchID, XMLThisElement);
			XMLDocument.CreateElement("Reload", m_fReload, XMLThisElement);
			XMLDocument.CreateElement("BulletDiameter", m_dBulletDiameter, XMLThisElement);
			XMLDocument.CreateElement("BulletWeight", m_dBulletWeight, XMLThisElement);
			XMLDocument.CreateElement("BallisticCoefficient", m_dBallisticCoefficient, XMLThisElement);

			m_TestList.Export(XMLDocument, XMLThisElement);
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

		public override bool Import(cRWXMLDocument XMLDocument, XmlNode XMLThisNode, cDataFiles DataFiles)
			{
			base.Import(XMLDocument, XMLThisNode, DataFiles);

			XmlNode XMLNode = XMLThisNode.FirstChild;

			while (XMLNode != null)
				{
				switch (XMLNode.Name)
					{
					case "CaliberIdentity":
						m_Caliber = cRWXMLDocument.GetCaliberByIdentity(XMLDocument, XMLNode, DataFiles);
						break;
					case "PartNumber":
						XMLDocument.Import(XMLNode, out m_strPartNumber);
						break;
					case "Type":
						XMLDocument.Import(XMLNode, out m_strType);
						break;
					case "BatchID":
						XMLDocument.Import(XMLNode, out m_nBatchID);
						break;
					case "Reload":
						XMLDocument.Import(XMLNode, out m_fReload);
						break;
					case "BulletDiameter":
						XMLDocument.Import(XMLNode, out m_dBulletDiameter);
						break;
					case "BulletWeight":
						XMLDocument.Import(XMLNode, out m_dBulletWeight);
						break;
					case "BallisticCoefficient":
						XMLDocument.Import(XMLNode, out m_dBallisticCoefficient);
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
