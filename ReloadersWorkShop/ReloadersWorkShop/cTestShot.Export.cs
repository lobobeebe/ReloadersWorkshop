using System.Xml;

namespace ReloadersWorkShop
	{
	public partial class cTestShot
		{
		//============================================================================*
		// CSVLine Property
		//============================================================================*

		public string CSVLine
			{
			get
				{
				string strLine = ",,";

				strLine += m_nMuzzleVelocity;
				strLine += ",";
				strLine += m_nPressure;
				strLine += ",";
				strLine += m_fMisfire ? "Yes" : "-";
				strLine += ",";
				strLine += m_fSquib ? "Yes" : "-";

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
				return ("Muzzle Velocity,Pressure,Misfire,Squib");
				}
			}

		//============================================================================*
		// Export() - XML Document
		//============================================================================*

		public void Export(cRWXMLDocument XMLDocument, XmlElement XMLParentElement)
			{
			XmlElement XMLThisElement = XMLDocument.CreateElement(ExportName, XMLParentElement);

			XMLDocument.CreateElement("MuzzleVelocity", m_nMuzzleVelocity, XMLThisElement);
			XMLDocument.CreateElement("Pressure", m_nPressure, XMLThisElement);
			XMLDocument.CreateElement("Misfire", m_fMisfire, XMLThisElement);
			XMLDocument.CreateElement("Squib", m_fSquib, XMLThisElement);
			}

		//============================================================================*
		// ExportName Property
		//============================================================================*

		public static string ExportName
			{
			get
				{
				return ("TestShot");
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
					case "MuzzleVelocity":
						XMLDocument.Import(XMLNode, out m_nMuzzleVelocity);
						break;
					case "Pressure":
						XMLDocument.Import(XMLNode, out m_nPressure);
						break;
					case "Misfire":
						XMLDocument.Import(XMLNode, out m_fMisfire);
						break;
					case "Squib":
						XMLDocument.Import(XMLNode, out m_fSquib);
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
