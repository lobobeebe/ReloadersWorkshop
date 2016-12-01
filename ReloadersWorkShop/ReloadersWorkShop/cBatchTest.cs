//============================================================================*
// cBatchTest.cs
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
// Application Specific Using Statements
//============================================================================*

using ReloadersWorkShop.Ballistics;

//============================================================================*
// NameSpace
//============================================================================*

namespace ReloadersWorkShop
	{
	//============================================================================*
	// cBatchTest class
	//============================================================================*

	[Serializable]
	public class cBatchTest
		{
		//============================================================================*
		// Private Data Members
		//============================================================================*

		//----------------------------------------------------------------------------*
		// General Data
		//----------------------------------------------------------------------------*

		private cBatch m_Batch = null;

		//----------------------------------------------------------------------------*
		// Environmental Data
		//----------------------------------------------------------------------------*

		private int m_nAltitude = 0;
		private double m_dPressure = 29.92;
		private int m_nTemperature = 59;
		private double m_dHumidity = 0.78;                      // 0.0 to 1.0 (percentage)

		private int m_nWindSpeed = 0;                           // MPH
		private int m_nWindDirection = 0;                       // Degrees

		private DateTime m_TestDate = DateTime.Today;

		private cFirearm m_Firearm = null;

		private string m_strLocation = "";

		private bool m_fSuppressed = false;

		//----------------------------------------------------------------------------*
		// Test Data
		//----------------------------------------------------------------------------*

		private int m_nNumRounds = 0;
		private double m_dBestGroup = 0.0;
		private int m_nBestGroupRange = 0;
		private string m_strNotes = "";

		private cTestShotList m_TestShotList = new cTestShotList();

		//============================================================================*
		// cBatchTest() - Constructor
		//============================================================================*

		public cBatchTest()
			{
			}

		//============================================================================*
		// cBatchTest() - Copy Constructor
		//============================================================================*

		public cBatchTest(cBatchTest BatchTest)
			{
			Copy(BatchTest);
			}

		//============================================================================*
		// Altitude Property
		//============================================================================*

		public int Altitude
			{
			get
				{
				return (m_nAltitude);
				}
			set
				{
				m_nAltitude = value;
				}
			}

		//============================================================================*
		// BarometricPressure Property
		//============================================================================*

		public double BarometricPressure
			{
			get
				{
				return (m_dPressure);
				}
			set
				{
				m_dPressure = value;
				}
			}

		//============================================================================*
		// Batch Property
		//============================================================================*

		public cBatch Batch
			{
			get
				{
				return (m_Batch);
				}
			set
				{
				m_Batch = value;
				}
			}

		//============================================================================*
		// BestGroup Property
		//============================================================================*

		public double BestGroup
			{
			get
				{
				return (m_dBestGroup);
				}
			set
				{
				m_dBestGroup = value;
				}
			}

		//============================================================================*
		// BestGroupRange Property
		//============================================================================*

		public int BestGroupRange
			{
			get
				{
				return (m_nBestGroupRange);
				}
			set
				{
				m_nBestGroupRange = value;
				}
			}

		//============================================================================*
		// Comparer()
		//============================================================================*

		public static int Comparer(cBatchTest BatchTest1, cBatchTest BatchTest2)
			{
			if (BatchTest1 == null)
				{
				if (BatchTest2 != null)
					return (-1);
				else
					return (0);
				}
			else
				{
				if (BatchTest2 == null)
					return (1);
				}

			return (BatchTest1.CompareTo(BatchTest2));
			}

		//============================================================================*
		// CompareTo()
		//============================================================================*

		public int CompareTo(cBatchTest BatchTest)
			{
			if (BatchTest == null)
				return (1);

			//----------------------------------------------------------------------------*
			// Compare Batch
			//----------------------------------------------------------------------------*

			int rc = m_Batch.CompareTo(BatchTest.m_Batch);

			//----------------------------------------------------------------------------*
			// Firearm
			//----------------------------------------------------------------------------*

			if (rc == 0)
				{
				rc = m_Firearm.CompareTo(BatchTest.m_Firearm);

				//----------------------------------------------------------------------------*
				// NumRounds
				//----------------------------------------------------------------------------*

				if (rc == 0)
					{
					rc = m_nNumRounds.CompareTo(BatchTest.m_nNumRounds);
					}
				}

			return (rc);
			}

		//============================================================================*
		// Copy()
		//============================================================================*

		public void Copy(cBatchTest BatchTest)
			{
			m_Batch = BatchTest.m_Batch;

			m_TestDate = BatchTest.m_TestDate;
			m_strLocation = BatchTest.m_strLocation;

			m_Firearm = BatchTest.m_Firearm;

			m_nNumRounds = BatchTest.m_nNumRounds;
			m_dBestGroup = BatchTest.m_dBestGroup;
			m_nBestGroupRange = BatchTest.m_nBestGroupRange;
			m_strNotes = BatchTest.m_strNotes;

			m_TestShotList = new cTestShotList(BatchTest.TestShotList);

			m_nAltitude = BatchTest.m_nAltitude;
			m_nTemperature = BatchTest.m_nTemperature;
			m_dPressure = BatchTest.m_dPressure;
			m_dHumidity = BatchTest.m_dHumidity;

			m_nWindDirection = BatchTest.m_nWindDirection;
			m_nWindSpeed = BatchTest.m_nWindSpeed;

			m_fSuppressed = BatchTest.m_fSuppressed;
			}

		//============================================================================*
		// CrossWind Property
		//============================================================================*

		public double CrossWind
			{
			get
				{
				cAtmospherics Atmosperics = new cAtmospherics();

				Atmosperics.WindSpeed = m_nWindSpeed;
				Atmosperics.WindDirection = m_nWindDirection;

				return (Atmosperics.CrossWind);
				}
			}

		//============================================================================*
		// CSVLine Property
		//============================================================================*

		public string CSVLine
			{
			get
				{
				string strLine = ",";

				strLine += m_TestDate.ToShortDateString();
				strLine += ",";

				strLine += m_Firearm;
				strLine += ",";
				strLine += m_fSuppressed;
				strLine += ",";

				strLine += m_strLocation;
				strLine += ",";

				strLine += m_nAltitude;
				strLine += ",";
				strLine += m_dPressure;
				strLine += ",";
				strLine += m_nTemperature;
				strLine += ",";
				strLine += m_dHumidity;
				strLine += ",";

				strLine += m_nWindSpeed;
				strLine += ",";
				strLine += m_nWindDirection;
				strLine += ",";

				strLine += m_nNumRounds;
				strLine += ",";
				strLine += m_dBestGroup;
				strLine += ",";
				strLine += m_nBestGroupRange;
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
				return (",Test Date,Firearm,Suppressed,Location,Altitude,Pressure,Temperature,Humidity,Wind Speed,Wind Direction,Number of Rounds,Best Group,Best Group Range,Notes");
				}
			}

		//============================================================================*
		// DensityAltitude Property
		//============================================================================*

		public int DensityAltitude
			{
			get
				{
				cAtmospherics Atmosperics = new cAtmospherics();

				Atmosperics.Temperature = m_nTemperature;
				Atmosperics.Altitude = m_nAltitude;
				Atmosperics.Pressure = m_dPressure;
				Atmosperics.Humidity = m_dHumidity;

				return (Atmosperics.DensityAltitude);
				}
			}

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

		public void Export(XmlDocument XMLDocument, XmlElement XMLParentElement)
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
		// Firearm Property
		//============================================================================*

		public cFirearm Firearm
			{
			get
				{
				return (m_Firearm);
				}
			set
				{
				m_Firearm = value;
				}
			}

		//============================================================================*
		// Headwind Property
		//============================================================================*

		public double HeadWind
			{
			get
				{
				cAtmospherics Atmosperics = new cAtmospherics();

				Atmosperics.WindSpeed = m_nWindSpeed;
				Atmosperics.WindDirection = m_nWindDirection;

				return (Atmosperics.HeadWind);
				}
			}

		//============================================================================*
		// Humidity Property
		//============================================================================*

		public double Humidity
			{
			get
				{
				return (m_dHumidity);
				}
			set
				{
				m_dHumidity = value;

				if (m_dHumidity < 0.0)
					m_dHumidity = 0.0;

				if (m_dHumidity > 1.0)
					m_dHumidity = 1.0;
				}
			}

		//============================================================================*
		// Import()
		//============================================================================*

		public bool Import(XmlDocument XMLDocument, XmlNode XMLThisNode, cDataFiles DataFiles)
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
						m_Firearm = cDataFiles.GetFirearmByIdentity(XMLDocument, XMLThisNode,  DataFiles);
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

			return (true);
			}

		//============================================================================*
		// Location Property
		//============================================================================*

		public string Location
			{
			get
				{
				return (m_strLocation);
				}
			set
				{
				m_strLocation = value;
				}
			}

		//============================================================================*
		// MuzzleVelocity Property
		//============================================================================*

		public int MuzzleVelocity
			{
			get
				{
				if (m_TestShotList.Count == 0)
					return (0);

				int nTotal = 0;
				int nShotCount = 0;

				foreach (cTestShot TestShot in m_TestShotList)
					{
					if (!TestShot.Squib && !TestShot.Misfire && TestShot.MuzzleVelocity != 0)
						{
						nTotal += TestShot.MuzzleVelocity;

						nShotCount++;
						}
					}

				if (nShotCount > 0)
					return (nTotal / nShotCount);

				return (0);
				}
			}

		//============================================================================*
		// Notes Property
		//============================================================================*

		public string Notes
			{
			get
				{
				return (m_strNotes);
				}
			set
				{
				m_strNotes = value;
				}
			}

		//============================================================================*
		// NumRounds Property
		//============================================================================*

		public int NumRounds
			{
			get
				{
				return (m_nNumRounds);
				}
			set
				{
				m_nNumRounds = value;
				}
			}

		//============================================================================*
		// Pressure Property
		//============================================================================*

		public int Pressure
			{
			get
				{
				if (m_TestShotList.Count == 0)
					return (0);

				int nTotal = 0;

				foreach (cTestShot TestShot in m_TestShotList)
					nTotal += TestShot.Pressure;

				return (nTotal / m_TestShotList.Count);
				}
			}

		//============================================================================*
		// StationPressure Property
		//============================================================================*

		public double StationPressure
			{
			get
				{
				cAtmospherics Atmosperics = new cAtmospherics();

				Atmosperics.Temperature = m_nTemperature;
				Atmosperics.Altitude = m_nAltitude;
				Atmosperics.Pressure = m_dPressure;
				Atmosperics.Humidity = m_dHumidity;

				return (Atmosperics.StationPressure);
				}
			}

		//============================================================================*
		// Suppressed Property
		//============================================================================*

		public bool Suppressed
			{
			get
				{
				return (m_fSuppressed);
				}
			set
				{
				m_fSuppressed = value;
				}
			}

		//============================================================================*
		// Synch() - Batch
		//============================================================================*

		public bool Synch(cBatch Batch)
			{
			if (m_Batch != null && m_Batch.CompareTo(Batch) == 0)
				{
				m_Batch = Batch;

				return (true);
				}

			return (false);
			}

		//============================================================================*
		// Temperature Property
		//============================================================================*

		public int Temperature
			{
			get
				{
				return (m_nTemperature);
				}
			set
				{
				m_nTemperature = value;
				}
			}

		//============================================================================*
		// TestDate Property
		//============================================================================*

		public DateTime TestDate
			{
			get
				{
				return (m_TestDate);
				}
			set
				{
				m_TestDate = value;
				}
			}

		//============================================================================*
		// TestShotList Property
		//============================================================================*

		public cTestShotList TestShotList
			{
			get
				{
				return (m_TestShotList);
				}
			set
				{
				m_TestShotList = value;
				}
			}

		//============================================================================*
		// ToString Property
		//============================================================================*

		public override string ToString()
			{
			string strLoadString = String.Format("Load: {0}, Firearm: {1}, {2} Rounds Tested", m_Batch.ToString(), m_Firearm.ToString(), m_nNumRounds);

			return (strLoadString);
			}

		//============================================================================*
		// WindDirection Property
		//============================================================================*

		public int WindDirection
			{
			get
				{
				return (m_nWindDirection);
				}
			set
				{
				m_nWindDirection = value;
				}
			}

		//============================================================================*
		// WindSpeed Property
		//============================================================================*

		public int WindSpeed
			{
			get
				{
				return (m_nWindSpeed);
				}
			set
				{
				m_nWindSpeed = value;
				}
			}
		}
	}
