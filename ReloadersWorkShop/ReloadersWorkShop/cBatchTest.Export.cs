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
			XmlElement XMLThisElement = XMLDocument.CreateElement(ExportName);
			XMLParentElement.AppendChild(XMLThisElement);

			// Test Date

			XmlElement XMLElement = XMLDocument.CreateElement("TestDate");
			XmlText XMLTextElement = XMLDocument.CreateTextNode(m_TestDate.ToShortDateString());
			XMLElement.AppendChild(XMLTextElement);

			XMLThisElement.AppendChild(XMLElement);

			// Firearm

			if (m_Firearm != null)
				m_Firearm.ExportIdentity(XMLDocument, XMLThisElement);

			// Suppressed

			XMLElement = XMLDocument.CreateElement("Suppressed");
			XMLTextElement = XMLDocument.CreateTextNode(m_fSuppressed ? "Yes" : "-");
			XMLElement.AppendChild(XMLTextElement);

			XMLThisElement.AppendChild(XMLElement);

			// Location

			if (!String.IsNullOrEmpty(m_strLocation))
				{
				XMLElement = XMLDocument.CreateElement("Location");
				XMLTextElement = XMLDocument.CreateTextNode(m_strLocation);
				XMLElement.AppendChild(XMLTextElement);

				XMLThisElement.AppendChild(XMLElement);
				}

			// Altitude

			XMLElement = XMLDocument.CreateElement("Altitude");
			XMLTextElement = XMLDocument.CreateTextNode(m_nAltitude.ToString());
			XMLElement.AppendChild(XMLTextElement);

			XMLThisElement.AppendChild(XMLElement);

			// Pressure

			XMLElement = XMLDocument.CreateElement("Pressure");
			XMLTextElement = XMLDocument.CreateTextNode(m_dPressure.ToString());
			XMLElement.AppendChild(XMLTextElement);

			XMLThisElement.AppendChild(XMLElement);

			// Temperature

			XMLElement = XMLDocument.CreateElement("Temperature");
			XMLTextElement = XMLDocument.CreateTextNode(m_nTemperature.ToString());
			XMLElement.AppendChild(XMLTextElement);

			XMLThisElement.AppendChild(XMLElement);

			// Humidity

			XMLElement = XMLDocument.CreateElement("Humidity");
			XMLTextElement = XMLDocument.CreateTextNode(m_dHumidity.ToString());
			XMLElement.AppendChild(XMLTextElement);

			XMLThisElement.AppendChild(XMLElement);

			// Wind Speed

			XMLElement = XMLDocument.CreateElement("WindSpeed");
			XMLTextElement = XMLDocument.CreateTextNode(m_nWindSpeed.ToString());
			XMLElement.AppendChild(XMLTextElement);

			XMLThisElement.AppendChild(XMLElement);

			// Wind Direction

			XMLElement = XMLDocument.CreateElement("WindDirection");
			XMLTextElement = XMLDocument.CreateTextNode(m_nWindDirection.ToString());
			XMLElement.AppendChild(XMLTextElement);

			XMLThisElement.AppendChild(XMLElement);

			// Num Rounds

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
			XMLTextElement = XMLDocument.CreateTextNode(m_nBestGroupRange.ToString());
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

			// Test Shots

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
