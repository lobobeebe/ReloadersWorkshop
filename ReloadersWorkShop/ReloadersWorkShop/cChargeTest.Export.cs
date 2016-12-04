//============================================================================*
// cChargeTest.Export.cs
//
// Copyright © 2013-2017, Kevin S. Beebe
// All Rights Reserved
//============================================================================*

//============================================================================*
// .Net Using Statements
//============================================================================*

using System;
using System.Xml;

namespace ReloadersWorkShop
	{
	public partial class cChargeTest
		{
		//============================================================================*
		// Export() - XML Document
		//============================================================================*

		public void Export(cRWXMLDocument XMLDocument, XmlElement XMLParentElement)
			{
			XmlElement XMLElement = XMLDocument.CreateElement(ExportName, XMLParentElement);

			XMLDocument.CreateElement("TestDate", m_TestDate, XMLElement);
			XMLDocument.CreateElement("Source", m_strSource, XMLElement);

			if (m_Firearm != null)
				m_Firearm.Export(XMLDocument, XMLElement, true);

			XMLDocument.CreateElement("BarrelLength", m_dBarrelLength, XMLElement);
			XMLDocument.CreateElement("Twist", m_dTwist, XMLElement);
			XMLDocument.CreateElement("MuzzleVelocity", m_nMuzzleVelocity, XMLElement);
			XMLDocument.CreateElement("Pressure", m_nPressure, XMLElement);
			XMLDocument.CreateElement("BestGroup", m_dBestGroup, XMLElement);
			XMLDocument.CreateElement("BestGroupRange", m_dBestGroupRange, XMLElement);
			XMLDocument.CreateElement("Notes", m_strNotes, XMLElement);
			XMLDocument.CreateElement("BatchTest", m_fBatchTest, XMLElement);
			XMLDocument.CreateElement("BatchID", m_nBatchID, XMLElement);
			}

		//============================================================================*
		// ExportName()
		//============================================================================*

		public static string ExportName
			{
			get
				{
				return ("ChargeTest");
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
					case "Charge":
						Double.TryParse(XMLNode.FirstChild.Value, out m_dPowderWeight);
						break;
					case "TestDate":
						DateTime.TryParse(XMLNode.FirstChild.Value, out m_TestDate);
						break;
					case "Source":
						m_strSource = XMLNode.FirstChild.Value;
						break;
					case "FirearmIdentity":
						m_Firearm = cRWXMLDocument.GetFirearmByIdentity(XMLDocument, XMLNode, DataFiles);
						break;
					case "BarrelLength":
						Double.TryParse(XMLNode.FirstChild.Value, out m_dBarrelLength);
						break;
					case "Twist":
						Double.TryParse(XMLNode.FirstChild.Value, out m_dTwist);
						break;
					case "MuzzleVelocity":
						Int32.TryParse(XMLNode.FirstChild.Value, out m_nMuzzleVelocity);
						break;
					case "Pressure":
						Int32.TryParse(XMLNode.FirstChild.Value, out m_nPressure);
						break;
					case "BestGroup":
						Double.TryParse(XMLNode.FirstChild.Value, out m_dBestGroup);
						break;
					case "BestGroupRange":
						Double.TryParse(XMLNode.FirstChild.Value, out m_dBestGroupRange);
						break;
					case "Notes":
						m_strNotes = XMLNode.FirstChild.Value;
						break;
					case "BatchTest":
						m_fBatchTest = XMLNode.FirstChild.Value == "Yes";
						break;
					case "BatchID":
						Int32.TryParse(XMLNode.FirstChild.Value, out m_nBatchID);
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
