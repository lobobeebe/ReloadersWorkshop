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
			XmlElement XMLThisElement = XMLDocument.CreateElement(ExportName, XMLParentElement);

			XMLDocument.CreateElement("TestDate", m_TestDate, XMLThisElement);

			m_Firearm.Export(XMLDocument, XMLThisElement, true);

			XMLDocument.CreateElement("BarrelLength", m_dBarrelLength, XMLThisElement);
			XMLDocument.CreateElement("Twist", m_dTwist, XMLThisElement);
			XMLDocument.CreateElement("NumRounds", m_nNumRounds, XMLThisElement);
			XMLDocument.CreateElement("BestGroup", m_dBestGroup, XMLThisElement);
			XMLDocument.CreateElement("BestGroupRange", m_dBestGroupRange, XMLThisElement);
			XMLDocument.CreateElement("MuzzleVelocity", m_nMuzzleVelocity, XMLThisElement);

			if (!String.IsNullOrEmpty(m_strNotes))
				XMLDocument.CreateElement("Notes", m_strNotes, XMLThisElement);

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
					case "TestShotList":
						m_TestShotList.Import(XMLDocument, XMLNode, DataFiles);

						if (m_nNumRounds != m_TestShotList.Count)
							m_nNumRounds = m_TestShotList.Count;

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
