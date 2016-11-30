//============================================================================*
// cTestShot.cs
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
// NameSpace
//============================================================================*

namespace ReloadersWorkShop
	{
	//============================================================================*
	// cTestShot class
	//============================================================================*

	[Serializable]
	public class cTestShot
		{
		//============================================================================*
		// Private Data Members
		//============================================================================*

		private int m_nMuzzleVelocity = 0;
		private int m_nPressure = 0;
		private bool m_fMisfire = false;
		private bool m_fSquib = false;

		//============================================================================*
		// cTestShot() - Constructor
		//============================================================================*

		public cTestShot()
			{
			}

		//============================================================================*
		// cTestShot() - Copy Constructor
		//============================================================================*

		public cTestShot(cTestShot TestShot)
			{
			m_nMuzzleVelocity = TestShot.m_nMuzzleVelocity;
			m_nPressure = TestShot.m_nPressure;
			m_fMisfire = TestShot.m_fMisfire;
			m_fSquib = TestShot.m_fSquib;
			}

		//============================================================================*
		// Comparer()
		//============================================================================*

		public static int Comparer(cTestShot TestShot1, cTestShot TestShot2)
			{
			if (TestShot1 == null)
				{
				if (TestShot2 != null)
					return (-1);
				else
					return (0);
				}
			else
				{
				if (TestShot2 == null)
					return(1);
				}

			return (TestShot1.CompareTo(TestShot2));
			}

		//============================================================================*
		// CompareTo()
		//============================================================================*

		public int CompareTo(cTestShot TestShot)
			{
			if (TestShot == null)
				return (1);

			int rc = m_nMuzzleVelocity.CompareTo(TestShot.m_nMuzzleVelocity);

			if (rc == 0)
				{
				rc = m_nPressure.CompareTo(TestShot.m_nPressure);

				if (rc == 0)
					{
					rc = m_fMisfire.CompareTo(TestShot.m_fMisfire);

					if (rc == 0)
						{
						rc = m_fSquib.CompareTo(TestShot.m_fSquib);
						}
					}
				}

			return (rc);
			}

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

		public void Export(XmlDocument XMLDocument, XmlElement XMLParentElement)
			{
			XmlElement XMLThisElement = XMLDocument.CreateElement(ExportName);
			XMLParentElement.AppendChild(XMLThisElement);

			// Muzzle Velocity

			XmlElement XMLElement = XMLDocument.CreateElement("MuzzleVelocity");
			XmlText XMLTextElement = XMLDocument.CreateTextNode(String.Format("{0}", m_nMuzzleVelocity));
			XMLElement.AppendChild(XMLTextElement);

			XMLThisElement.AppendChild(XMLElement);

			// Pressure

			XMLElement = XMLDocument.CreateElement("Pressure");
			XMLTextElement = XMLDocument.CreateTextNode(String.Format("{0}", m_nPressure));
			XMLElement.AppendChild(XMLTextElement);

			XMLThisElement.AppendChild(XMLElement);

			// Misfire

			XMLElement = XMLDocument.CreateElement("Misfire");
			XMLTextElement = XMLDocument.CreateTextNode(m_fMisfire ? "Yes" : "-");
			XMLElement.AppendChild(XMLTextElement);

			XMLThisElement.AppendChild(XMLElement);

			// Squib

			XMLElement = XMLDocument.CreateElement("Squib");
			XMLTextElement = XMLDocument.CreateTextNode(m_fSquib ? "Yes" : "-");
			XMLElement.AppendChild(XMLTextElement);

			XMLThisElement.AppendChild(XMLElement);
			}

		//============================================================================*
		// ExportName Property
		//============================================================================*

		public string ExportName
			{
			get
				{
				return ("TestShot");
				}
			}

		//============================================================================*
		// Misfire Property
		//============================================================================*

		public bool Misfire
			{
			get { return (m_fMisfire); }
			set 
				{
				m_fMisfire = value;

				if (m_fMisfire)
					m_fSquib = false;
				}
			}

		//============================================================================*
		// MuzzleVelocity Property
		//============================================================================*

		public int MuzzleVelocity
			{
			get { return (m_nMuzzleVelocity); }
			set { m_nMuzzleVelocity = value; }
			}

		//============================================================================*
		// Pressure Property
		//============================================================================*

		public int Pressure
			{
			get { return (m_nPressure); }
			set { m_nPressure = value; }
			}

		//============================================================================*
		// Squib Property
		//============================================================================*

		public bool Squib
			{
			get { return (m_fSquib); }
			set
				{
				m_fSquib = value;

				if (m_fSquib)
					m_fMisfire = false;
				}
			}

		//============================================================================*
		// Synch() - Load
		//============================================================================*

		public bool Synch(cLoad Load)
			{
/*			if (m_Load != null && m_Load.CompareTo(Load) == 0)
				{
				m_Load = Load;

				return (true);
				}
*/
			return (false);
			}

		//============================================================================*
		// ToString()
		//============================================================================*

		public override string ToString()
			{
			string strLoadString = String.Format("Muzzle Velocity: {0}, Pressure: {1}, Misfire: {2}, Squib: {3}", m_nMuzzleVelocity, m_nPressure, m_fMisfire ? "Yes" : "No", m_fSquib ? "Yes" : "No");

			return (strLoadString);
			}
		}
	}
