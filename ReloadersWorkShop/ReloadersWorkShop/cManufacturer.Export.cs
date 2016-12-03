using System;
using System.Xml;

namespace ReloadersWorkShop
	{
	public partial class cManufacturer
		{
		//============================================================================*
		// CSVLine Property
		//============================================================================*

		public string CSVLine
			{
			get
				{
				string strLine = String.Format("{0},{1}", m_strName, m_strWebsite);

				strLine += m_fBullets ? ",Yes" : ",-";
				strLine += m_fPowder ? ",Yes" : ",-";
				strLine += m_fPrimers ? ",Yes" : ",-";
				strLine += m_fCases ? ",Yes" : ",-";
				strLine += m_fAmmo ? ",Yes" : ",-";
				strLine += m_fBulletMolds ? ",Yes" : ",-";

				strLine += ",";
				strLine += m_strHeadStamp;

				// Firearms

				strLine += m_fHandguns ? ",Yes" : ",-";
				strLine += m_fRifles ? ",Yes" : ",-";
				strLine += m_fShotguns ? ",Yes" : ",-";

				// Firearms Parts

				strLine += m_fScopes ? ",Yes" : ",-";
				strLine += m_fLasers ? ",Yes" : ",-";
				strLine += m_fRedDots ? ",Yes" : ",-";
				strLine += m_fMagnifiers ? ",Yes" : ",-";
				strLine += m_fLights ? ",Yes" : ",-";
				strLine += m_fTriggers ? ",Yes" : ",-";
				strLine += m_fFurniture ? ",Yes" : ",-";
				strLine += m_fBipods ? ",Yes" : ",-";
				strLine += m_fParts ? ",Yes" : ",-";
				strLine += m_fMisc ? ",Yes" : ",-";

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
				string strLine = "Name,Website,Bullets,Powder,Primers,Cases,Ammo,Bullet Molds,Head Stamp,Handguns,Rifles,Shotguns, Scopes,Lasers,Red Dots,Magnifiers,Lights,Triggers,Furniture,Bipods,Firearm Parts,Other";

				return (strLine);
				}
			}

		//============================================================================*
		// Export() - XML Document
		//============================================================================*

		public void Export(cRWXMLDocument XMLDocument, XmlElement XMLParentElement)
			{
			XmlElement XMLThisElement = XMLDocument.CreateElement(ExportName, XMLParentElement);

			XMLDocument.CreateElement("Name", m_strName, XMLThisElement);
			XMLDocument.CreateElement("Website", m_strWebsite, XMLThisElement);
			XMLDocument.CreateElement("HeadStamp", m_strHeadStamp, XMLThisElement);

			XMLDocument.CreateElement("Ammo", m_fAmmo, XMLThisElement);
			XMLDocument.CreateElement("Bipods", m_fBipods, XMLThisElement);
			XMLDocument.CreateElement("Bullets", m_fBullets, XMLThisElement);
			XMLDocument.CreateElement("BulletMolds", m_fBulletMolds, XMLThisElement);
			XMLDocument.CreateElement("Cases", m_fCases, XMLThisElement);
			XMLDocument.CreateElement("FirearmParts", m_fParts, XMLThisElement);
			XMLDocument.CreateElement("Furniture", m_fFurniture, XMLThisElement);
			XMLDocument.CreateElement("Handguns", m_fHandguns, XMLThisElement);
			XMLDocument.CreateElement("Lasers", m_fLasers, XMLThisElement);
			XMLDocument.CreateElement("Lights", m_fLights, XMLThisElement);
			XMLDocument.CreateElement("Magnifiers", m_fMagnifiers, XMLThisElement);
			XMLDocument.CreateElement("Other", m_fMisc, XMLThisElement);
			XMLDocument.CreateElement("Powders", m_fPowder, XMLThisElement);
			XMLDocument.CreateElement("Primers", m_fPrimers, XMLThisElement);
			XMLDocument.CreateElement("RedDots", m_fRedDots, XMLThisElement);
			XMLDocument.CreateElement("Rifles", m_fRifles, XMLThisElement);
			XMLDocument.CreateElement("Scopes", m_fScopes, XMLThisElement);
			XMLDocument.CreateElement("Shotguns", m_fShotguns, XMLThisElement);
			XMLDocument.CreateElement("Triggers", m_fTriggers, XMLThisElement);
			}

		//============================================================================*
		// ExportName Property
		//============================================================================*

		public static string ExportName
			{
			get
				{
				return ("Manufacturer");
				}
			}

		}
	}
