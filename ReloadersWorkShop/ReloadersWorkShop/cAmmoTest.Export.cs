using System;
using System.Xml;

namespace ReloadersWorkShop
	{
	public partial class cAmmoTest
		{
		//============================================================================*
		// CSVLine Property
		//============================================================================*

		public string CSVLine
			{
			get
				{
				string strLine = m_TestDate.ToShortDateString();
				strLine += ",";

				strLine += m_Firearm.ToString();
				strLine += ",";

				strLine += m_dBarrelLength;
				strLine += ",";
				strLine += m_dTwist;
				strLine += ",";
				strLine += m_nNumRounds;
				strLine += ",";
				strLine += m_dBestGroup;
				strLine += ",";
				strLine += m_dBestGroupRange;
				strLine += ",";
				strLine += m_nMuzzleVelocity;
				strLine += ",";
				strLine += m_strNotes;

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
				return ("Date,Firearm,Barrel Length,Twist,NumRounds,Best Group,Best Group Range,Muzzle Velocity,Notes");
				}
			}

		//============================================================================*
		// Export() - XML Document
		//============================================================================*

		public void Export(cRWXMLDocument XMLDocument, XmlElement XMLParentElement)
			{
			XmlElement XMLThisElement = XMLDocument.CreateElement(ExportName);
			XMLParentElement.AppendChild(XMLThisElement);

			// Date

			XmlElement XMLElement = XMLDocument.CreateElement("TestDate");
			XmlText XMLTextElement = XMLDocument.CreateTextNode(m_TestDate.ToShortDateString());
			XMLElement.AppendChild(XMLTextElement);

			XMLThisElement.AppendChild(XMLElement);

			// Firearm

			m_Firearm.Export(XMLDocument, XMLThisElement, true);

			// Barrel Length

			XMLElement = XMLDocument.CreateElement("BarrelLength");
			XMLTextElement = XMLDocument.CreateTextNode(m_dBarrelLength.ToString());
			XMLElement.AppendChild(XMLTextElement);

			XMLThisElement.AppendChild(XMLElement);

			// Twist

			XMLElement = XMLDocument.CreateElement("Twist");
			XMLTextElement = XMLDocument.CreateTextNode(m_dTwist.ToString());
			XMLElement.AppendChild(XMLTextElement);

			XMLThisElement.AppendChild(XMLElement);

			// NumRounds

			XMLElement = XMLDocument.CreateElement("NumRounds");
			XMLTextElement = XMLDocument.CreateTextNode(m_nNumRounds.ToString());
			XMLElement.AppendChild(XMLTextElement);

			XMLThisElement.AppendChild(XMLElement);

			// Best Group

			XMLElement = XMLDocument.CreateElement("BestGroup");
			XMLTextElement = XMLDocument.CreateTextNode(m_dBestGroup.ToString());
			XMLElement.AppendChild(XMLTextElement);

			XMLThisElement.AppendChild(XMLElement);

			// Best Group Range

			XMLElement = XMLDocument.CreateElement("BestGroupRange");
			XMLTextElement = XMLDocument.CreateTextNode(m_dBestGroupRange.ToString());
			XMLElement.AppendChild(XMLTextElement);

			XMLThisElement.AppendChild(XMLElement);

			// Muzzle Velocity

			XMLElement = XMLDocument.CreateElement("MuzzleVelocity");
			XMLTextElement = XMLDocument.CreateTextNode(m_nMuzzleVelocity.ToString());
			XMLElement.AppendChild(XMLTextElement);

			XMLThisElement.AppendChild(XMLElement);

			// Notes

			if (!String.IsNullOrEmpty(m_strNotes))
				{
				XMLElement = XMLDocument.CreateElement("Notes");
				XMLTextElement = XMLDocument.CreateTextNode(m_strNotes);
				XMLElement.AppendChild(XMLTextElement);

				XMLThisElement.AppendChild(XMLElement);
				}

			// Test List

			m_TestShotList.Export(XMLDocument, XMLThisElement);
			}

		//============================================================================*
		// ExportName Property
		//============================================================================*

		public static string ExportName
			{
			get
				{
				return ("AmmoTest");
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
					case "TestDate":
						XMLDocument.Import(XMLNode, out m_TestDate);
						break;
					case "FirearmIdentity":
						m_Firearm = cRWXMLDocument.GetFirearmByIdentity(XMLDocument, XMLNode, DataFiles);
						break;
					case "BarrelLength":
						XMLDocument.Import(XMLNode, out m_dBarrelLength);
						break;
					case "Twist":
						XMLDocument.Import(XMLNode, out m_dTwist);
						break;
					case "NumRounds":
						XMLDocument.Import(XMLNode, out m_nNumRounds);
						break;
					case "BestGroup":
						XMLDocument.Import(XMLNode, out m_dBestGroup);
						break;
					case "BestGroupRange":
						XMLDocument.Import(XMLNode, out m_dBestGroupRange);
						break;
					case "MuzzleVelocity":
						XMLDocument.Import(XMLNode, out m_nMuzzleVelocity);
						break;
					case "Notes":
						XMLDocument.Import(XMLNode, out m_strNotes);
						break;
					case "TestShots":
						m_TestShotList.Import(XMLDocument, XMLNode, DataFiles);
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
