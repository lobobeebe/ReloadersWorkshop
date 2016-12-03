//============================================================================*
// cBatchTest.Export.cs
//
// Copyright © 2013-2014, Kevin S. Beebe
// All Rights Reserved
//============================================================================*

//============================================================================*
// .Net Using Statements
//============================================================================*

using System;
using System.IO;
using System.Xml;

//============================================================================*
// Namespace
//============================================================================*

namespace ReloadersWorkShop
	{
	//============================================================================*
	// cBatchTest Partial Class
	//============================================================================*

	public partial class cBatchTest
		{
		//============================================================================*
		// Export()
		//============================================================================*

		public void Export(StreamWriter Writer)
			{
			string strLine = ",";

			Writer.WriteLine(ExportName);
			Writer.WriteLine();

			Writer.WriteLine(cBatchTest.CSVLineHeader);
			Writer.WriteLine();

			strLine = Batch.BatchTest.CSVLine;

			Writer.WriteLine(strLine);

			if (m_TestShotList.Count > 0)
				{
				Writer.WriteLine();

				m_TestShotList.Export(Writer);
				}
			}

		//============================================================================*
		// Export() - XML Document
		//============================================================================*

		public void Export(cRWXMLDocument XMLDocument, XmlElement XMLParentElement)
			{
			XmlElement XMLThisElement = XMLDocument.CreateElement(ExportName, XMLParentElement);

			XMLDocument.CreateElement("TestDate", m_TestDate, XMLThisElement);

			if (m_Firearm != null)
				m_Firearm.Export(XMLDocument, XMLThisElement, true);

			XMLDocument.CreateElement("Suppressed", m_fSuppressed, XMLThisElement);
			XMLDocument.CreateElement("Location", m_strLocation, XMLThisElement);
			XMLDocument.CreateElement("Altitude", m_nAltitude, XMLThisElement);
			XMLDocument.CreateElement("Pressure", m_dPressure, XMLThisElement);
			XMLDocument.CreateElement("Temperature", m_nTemperature, XMLThisElement);
			XMLDocument.CreateElement("Humidity", m_dHumidity, XMLThisElement);
			XMLDocument.CreateElement("WindSpeed", m_nWindSpeed, XMLThisElement);
			XMLDocument.CreateElement("WindDirection", m_nWindDirection, XMLThisElement);
			XMLDocument.CreateElement("NumRounds", m_nNumRounds, XMLThisElement);
			XMLDocument.CreateElement("BestGroup", m_dBestGroup, XMLThisElement);
			XMLDocument.CreateElement("BestGroupRange", m_nBestGroupRange, XMLThisElement);
			XMLDocument.CreateElement("Notes", m_strNotes, XMLThisElement);

			m_TestShotList.Export(XMLDocument, XMLThisElement);
			}

		//============================================================================*
		// ExportName Property
		//============================================================================*

		public string ExportName
			{
			get
				{
				return ("BatchTest");
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
						DateTime.TryParse(XMLNode.FirstChild.Value, out m_TestDate);
						break;
					case "FirearmIdentity":
						m_Firearm = cRWXMLDocument.GetFirearmByIdentity(XMLDocument, XMLThisNode, DataFiles);
						break;
					case "Suppressed":
						m_fSuppressed = XMLNode.FirstChild.Value == "Yes";
						break;
					case "Location":
						m_strLocation = XMLNode.FirstChild.Value;
						break;
					case "Altitude":
						Int32.TryParse(XMLNode.FirstChild.Value, out m_nAltitude);
						break;
					case "Pressure":
						Double.TryParse(XMLNode.FirstChild.Value, out m_dPressure);
						break;
					case "Temperature":
						Int32.TryParse(XMLNode.FirstChild.Value, out m_nTemperature);
						break;
					case "Humidity":
						Double.TryParse(XMLNode.FirstChild.Value, out m_dHumidity);
						break;
					case "WindSpeed":
						Int32.TryParse(XMLNode.FirstChild.Value, out m_nWindSpeed);
						break;
					case "WindDirection":
						Int32.TryParse(XMLNode.FirstChild.Value, out m_nWindDirection);
						break;
					case "NumRounds":
						Int32.TryParse(XMLNode.FirstChild.Value, out m_nNumRounds);
						break;
					case "BestGroup":
						Double.TryParse(XMLNode.FirstChild.Value, out m_dBestGroup);
						break;
					case "BestGroupRange":
						Int32.TryParse(XMLNode.FirstChild.Value, out m_nBestGroupRange);
						break;
					case "Notes":
						m_strNotes = XMLNode.FirstChild.Value;
						break;
					case "TestShots":
					case "TestShotList":
						m_TestShotList.Import(XMLDocument, XMLNode, DataFiles);
						break;
					default:
						break;
					}

				XMLNode = XMLNode.NextSibling;
				}

			m_nNumRounds = m_TestShotList.Count;

			return (true);
			}
		}
	}
