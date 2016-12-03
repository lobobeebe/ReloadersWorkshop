//============================================================================*
// cFirearm.cs
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
	// cFirearm Class
	//============================================================================*

	public partial class cFirearm
		{
		//============================================================================*
		// CSVLine Property
		//============================================================================*

		public override string CSVLine
			{
			get
				{
				string strLine = "";

				//----------------------------------------------------------------------------*
				// General
				//----------------------------------------------------------------------------*

				strLine += base.CSVLine;
				strLine += ",";

				strLine += cFirearm.FirearmTypeString(m_eFirearmType);
				strLine += ",";

				strLine += m_dBarrelLength;
				strLine += ",";
				strLine += m_dTwist;
				strLine += ",";
				strLine += m_dSightHeight;

				strLine += m_fScoped ? ",Yes," : ",,";
				strLine += m_dScopeClick;
				strLine += ",";
				strLine += m_eTurretType == eTurretType.MOA ? "MOA," : "Mils,";

				strLine += m_nZeroRange;
				strLine += ",";
				strLine += m_dHeadSpace;
				strLine += ",";
				strLine += m_dNeck;
				strLine += ",";

				strLine += m_strReceiverFinish;
				strLine += ",";
				strLine += m_strBarrelFinish;
				strLine += ",";

				strLine += m_strType;
				strLine += ",";
				strLine += m_strAction;
				strLine += ",";
				strLine += m_strHammer;
				strLine += ",";
				strLine += m_strMagazine;
				strLine += ",";
				strLine += m_nCapacity;
				strLine += ",";
				strLine += m_fChecked ? "Yes" : "";

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
				return ("Manufacturer,Model,Serial Number,Firearm Type,Barrel Length,Twist,Sight Height,Scoped,Scope Click, Turret Type,Zero Range,HeadSpace,Neck,Source,Purchase Date,Price,Receiver Finish,Barrel Finish,Type,Action,Hammer,Magazine,Capacity,Checked,Notes");
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

			XmlElement XMLThisElement = XMLDocument.CreateElement(ExportName, XMLParentElement);

			base.Export(XMLDocument, XMLThisElement, fIdentityOnly);

			XMLDocument.CreateElement("FirearmType", m_eFirearmType, XMLThisElement);

			if (fIdentityOnly)
				return;

			XMLDocument.CreateElement("BarrelLength", m_dBarrelLength, XMLThisElement);
			XMLDocument.CreateElement("Twist", m_dTwist, XMLThisElement);
			XMLDocument.CreateElement("SightHeight", m_dSightHeight, XMLThisElement);
			XMLDocument.CreateElement("Scoped", m_fScoped, XMLThisElement);
			XMLDocument.CreateElement("ScopeClick", m_dScopeClick, XMLThisElement);
			XMLDocument.CreateElement("TurretType", m_eTurretType, XMLThisElement);
			XMLDocument.CreateElement("ZeroRange", m_nZeroRange, XMLThisElement);
			XMLDocument.CreateElement("HeadSpace", m_dHeadSpace, XMLThisElement);
			XMLDocument.CreateElement("NeckSize", m_dNeck, XMLThisElement);
			XMLDocument.CreateElement("ReceiverFinish", m_strReceiverFinish, XMLThisElement);
			XMLDocument.CreateElement("BarrelFinish", m_strBarrelFinish, XMLThisElement);
			XMLDocument.CreateElement("Type", m_strType, XMLThisElement);
			XMLDocument.CreateElement("Action", m_strAction, XMLThisElement);
			XMLDocument.CreateElement("Hammer", m_strHammer, XMLThisElement);
			XMLDocument.CreateElement("Magazine", m_strMagazine, XMLThisElement);
			XMLDocument.CreateElement("Capacity", m_nCapacity, XMLThisElement);
			XMLDocument.CreateElement("TransferFees", m_dTransferFees, XMLThisElement);
			XMLDocument.CreateElement("OtherFees", m_dOtherFees, XMLThisElement);
			XMLDocument.CreateElement("Checked", m_fChecked, XMLThisElement);

			m_FirearmCaliberList.Export(XMLDocument, XMLThisElement);

			m_FirearmBulletList.Export(XMLDocument, XMLThisElement);
			}

		//============================================================================*
		// ExportName()
		//============================================================================*

		public static string ExportName
			{
			get
				{
				return ("Firearm");
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
					case "FirearmType":
						m_eFirearmType = cFirearm.FirearmTypeFromString(XMLNode.FirstChild.Value);

						SetDefaultDescription();

						break;
					case "BarrelLength":
						Double.TryParse(XMLNode.FirstChild.Value, out m_dBarrelLength);
						break;
					case "Twist":
						Double.TryParse(XMLNode.FirstChild.Value, out m_dTwist);
						break;
					case "SightHeight":
						Double.TryParse(XMLNode.FirstChild.Value, out m_dSightHeight);
						break;
					case "Scoped":
						m_fScoped = XMLNode.FirstChild.Value == "Yes";
						break;
					case "ScopeClick":
						Double.TryParse(XMLNode.FirstChild.Value, out m_dScopeClick);
						break;
					case "TurretType":
						m_eTurretType = XMLNode.FirstChild.Value == "MOA" ? eTurretType.MOA : eTurretType.MilDot;
						break;
					case "ZeroRange":
						Int32.TryParse(XMLNode.FirstChild.Value, out m_nZeroRange);
						break;
					case "Headspace":
						Double.TryParse(XMLNode.FirstChild.Value, out m_dHeadSpace);
						break;
					case "NeckSize":
						Double.TryParse(XMLNode.FirstChild.Value, out m_dNeck);
						break;
					case "ReceiverFinish":
						m_strReceiverFinish = XMLNode.FirstChild.Value;
						break;
					case "BarrelFinish":
						m_strBarrelFinish = XMLNode.FirstChild.Value;
						break;
					case "Type":
						m_strType = XMLNode.FirstChild.Value;
						break;
					case "Action":
						m_strAction = XMLNode.FirstChild.Value;
						break;
					case "Hammer":
						m_strHammer = XMLNode.FirstChild.Value;
						break;
					case "Magazine":
						m_strMagazine = XMLNode.FirstChild.Value;
						break;
					case "Capacity":
						Int32.TryParse(XMLNode.FirstChild.Value, out m_nCapacity);
						break;
					case "TransferFees":
						Double.TryParse(XMLNode.FirstChild.Value, out m_dTransferFees);
						break;
					case "OtherFees":
						Double.TryParse(XMLNode.FirstChild.Value, out m_dOtherFees);
						break;
					case "Checked":
						m_fChecked = XMLNode.FirstChild.Value == "Yes";
						break;
					case "FirearmCalibers":
					case "FirearmCaliberList":
						m_FirearmCaliberList.Import(XMLDocument, XMLNode, DataFiles);

						SetDefaultDescription();

						break;
					case "FirearmBullets":
					case "FirearmBulletList":
						m_FirearmBulletList.Import(XMLDocument, XMLNode, DataFiles);
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
