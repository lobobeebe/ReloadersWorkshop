using System;
using System.Xml;

namespace ReloadersWorkShop
	{
	public partial class cFirearmBullet
		{
		//============================================================================*
		// Export() - XML Document
		//============================================================================*

		public void Export(cRWXMLDocument XMLDocument, XmlElement XMLParentElement)
			{
			XmlElement XMLThisElement = XMLDocument.CreateElement(ExportName, XMLParentElement);

			m_Caliber.Export(XMLDocument, XMLThisElement, true);

			m_Bullet.Export(XMLDocument, XMLThisElement, true);

			XMLDocument.CreateElement("COAL", m_dCOL, XMLThisElement);
			XMLDocument.CreateElement("CBTO", m_dCBTO, XMLThisElement);
			XMLDocument.CreateElement("Jump", m_dJump, XMLThisElement);
			}

		//============================================================================*
		// ExportName Property
		//============================================================================*

		public static string ExportName
			{
			get
				{
				return ("FirearmBullet");
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
					case "CaliberIdentity":
						m_Caliber = cRWXMLDocument.GetCaliberByIdentity(XMLDocument, XMLNode, DataFiles);
						break;
					case "BulletIdentity":
						m_Bullet = cRWXMLDocument.GetBulletByIdentity(XMLDocument, XMLNode, DataFiles);
						break;
					case "COAL":
						XMLDocument.Import(XMLNode, out m_dCOL);
						break;
					case "CBTO":
						XMLDocument.Import(XMLNode, out m_dCBTO);
						break;
					case "Jump":
						XMLDocument.Import(XMLNode, out m_dJump);
						break;
					default:
						break;
					}

				XMLNode = XMLNode.NextSibling;
				}

			return (Validate(true));
			}

		}
	}
