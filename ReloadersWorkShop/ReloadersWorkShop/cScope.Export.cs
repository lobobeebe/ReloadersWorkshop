//============================================================================*
// cScope.Export.cs
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
	// cScope Class
	//============================================================================*

	public partial class cScope
		{
		//============================================================================*
		// CSVHeaderExtension Property
		//============================================================================*

		public override string CSVLineHeaderExtension
			{
			get
				{
				return (",Power,Objective,Tube Size,Turret Click,Turret Type");
				}
			}

		//============================================================================*
		// CSVLineExtension Property
		//============================================================================*

		public override string CSVLineExtension
			{
			get
				{
				string strLine = ",";
				strLine += (this as cScope).Power;
				strLine += ",";
				strLine += (this as cScope).Objective;
				strLine += ",";
				strLine += cScope.TubeSizeString((this as cScope).TubeSize);
				strLine += ",";
				strLine += (this as cScope).TurretClick;
				strLine += ",";
				strLine += cFirearm.TurretTypeString((this as cScope).TurretType);

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

			XmlElement XMLThisElement = XMLDocument.CreateElement(ExportName, XMLParentElement);

			base.Export(XMLDocument, XMLThisElement, fIdentityOnly);

			if (fIdentityOnly)
				return;

			XMLDocument.CreateElement("Power", m_strPower, XMLThisElement);
			XMLDocument.CreateElement("Objective", m_strObjective, XMLThisElement);
			XMLDocument.CreateElement("TubeSize", m_eTubeSize, XMLThisElement);
			XMLDocument.CreateElement("TurretClick", m_dTurretClick, XMLThisElement);
			XMLDocument.CreateElement("TurretType", m_eTurretType, XMLThisElement);
			}

		//============================================================================*
		// ExportName()
		//============================================================================*

		public static string ExportName
			{
			get
				{
				return ("Scope");
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
					case "Power":
						XMLDocument.Import(XMLNode, out m_strPower);
						break;
					case "Objective":
						XMLDocument.Import(XMLNode, out m_strObjective);
						break;
					case "TubeSize":
						XMLDocument.Import(XMLNode, out m_eTubeSize);
						break;
					case "TurretClick":
						XMLDocument.Import(XMLNode, out m_dTurretClick);
						break;
					case "TurretType":
						XMLDocument.Import(XMLNode, out m_eTurretType);
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
