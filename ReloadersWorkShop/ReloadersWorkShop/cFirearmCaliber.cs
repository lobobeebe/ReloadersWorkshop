//============================================================================*
// cFirearmCaliber.cs
//
// Copyright © 2013-2014, Kevin S. Beebe
// All Rights Reserved
//============================================================================*

//============================================================================*
// .Net Using Statements
//============================================================================*

using System;
using System.Xml;

//============================================================================*
// NameSpace
//============================================================================*

namespace ReloadersWorkShop
	{
	//============================================================================*
	// cFirearmCOL class
	//============================================================================*

	[Serializable]
	public class cFirearmCaliber
		{
		//----------------------------------------------------------------------------*
		// Private Data Members
		//----------------------------------------------------------------------------*

		private cCaliber m_Caliber = new cCaliber();

		private bool m_fPrimary = false;

		//============================================================================*
		// cFirearmCaliber() - Constructor
		//============================================================================*

		public cFirearmCaliber()
			{
			}

		//============================================================================*
		// cFirearmCaliber() - Copy Constructor
		//============================================================================*

		public cFirearmCaliber(cFirearmCaliber FirearmCaliber)
			{
			m_Caliber = FirearmCaliber.m_Caliber;

			m_fPrimary = FirearmCaliber.m_fPrimary;
			}

		//============================================================================*
		// Caliber Property
		//============================================================================*

		public cCaliber Caliber
			{
			get
				{
				return (m_Caliber);
				}
			set
				{
				m_Caliber = value;
				}
			}

		//============================================================================*
		// Comparer()
		//============================================================================*

		public static int Comparer(cFirearmCaliber FirearmCaliber1, cFirearmCaliber FirearmCaliber2)
			{
			if (FirearmCaliber1 == null)
				{
				if (FirearmCaliber2 != null)
					return (-1);
				else
					return (0);
				}

			return (FirearmCaliber1.CompareTo(FirearmCaliber2));
			}

		//============================================================================*
		// CompareTo()
		//============================================================================*

		public int CompareTo(Object obj)
			{
			if (obj == null)
				return (1);

			cFirearmCaliber FirearmCaliber = (cFirearmCaliber) obj;

			//----------------------------------------------------------------------------*
			// Compare Caliber
			//----------------------------------------------------------------------------*

			return (m_Caliber.CompareTo(FirearmCaliber.m_Caliber));
			}

		//============================================================================*
		// CSVLine Property
		//============================================================================*

		public string CSVLine
			{
			get
				{
				string strLine = "";

				//----------------------------------------------------------------------------*
				// General
				//----------------------------------------------------------------------------*

				strLine += m_Caliber.ToString();
				strLine += ",";
				strLine += m_fPrimary ? "Yes" : "";
				strLine += ",";

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
				return ("Caliber,Primary");
				}
			}

		//============================================================================*
		// Export() - XML Document
		//============================================================================*

		public void Export(XmlDocument XMLDocument, XmlElement XMLParentElement)
			{
			XmlElement XMLThisElement = XMLDocument.CreateElement("FirearmCaliber");
			XMLParentElement.AppendChild(XMLThisElement);

			// Caliber

			m_Caliber.ExportIdentity(XMLDocument,  XMLThisElement);

			// Primary

			XmlElement XMLElement = XMLDocument.CreateElement("Primary");
			XmlText XMLTextElement = XMLDocument.CreateTextNode(m_fPrimary ? "Yes" : "-");
			XMLElement.AppendChild(XMLTextElement);

			XMLThisElement.AppendChild(XMLElement);
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
					case "Primary":
						m_fPrimary = XMLNode.FirstChild.Value == "Yes";
						break;
					case "CaliberIdentity":
						m_Caliber = cDataFiles.GetCaliberByIdentity(XMLDocument, XMLNode, DataFiles);
						break;
					default:
						break;
					}

				XMLNode = XMLNode.NextSibling;
				}

			return (Validate());
			}

		//============================================================================*
		// Primary Property
		//============================================================================*

		public bool Primary
			{
			get
				{
				return (m_fPrimary);
				}
			set
				{
				m_fPrimary = value;
				}
			}

		//============================================================================*
		// ResolveIdentities()
		//============================================================================*

		public bool ResolveIdentities(cDataFiles Datafiles)
			{
			return (false);
			}

		//============================================================================*
		// Synch() - Caliber
		//============================================================================*

		public bool Synch(cCaliber Caliber)
			{
			if (m_Caliber != null && m_Caliber.CompareTo(Caliber) == 0)
				{
				m_Caliber = Caliber;

				return (true);
				}

			return (false);
			}

		//============================================================================*
		// ToString
		//============================================================================*

		public override string ToString()
			{
			string strString = String.Format("{0}", m_Caliber.ToString());

			if (m_fPrimary)
				strString += " - Primary";

			return (strString);
			}

		//============================================================================*
		// Validate()
		//============================================================================*

		public bool Validate()
			{
			bool fOK = m_Caliber != null;

			return (fOK);
			}
		}
	}
