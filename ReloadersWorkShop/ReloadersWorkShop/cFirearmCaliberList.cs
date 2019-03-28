//============================================================================*
// cFirearmCaliberList.cs
//
// Copyright © 2013-2017, Kevin S. Beebe
// All Rights Reserved
//============================================================================*

//============================================================================*
// .Net Using Statements
//============================================================================*

using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

//============================================================================*
// Namespace
//============================================================================*

namespace ReloadersWorkShop
	{
	//============================================================================*
	// cFirearmCaliberList Class
	//============================================================================*

	[Serializable]
	public class cFirearmCaliberList : List<cFirearmCaliber>
		{
		//============================================================================*
		// Private Data Members
		//============================================================================*

		private int m_nImportCount = 0;
		private int m_nNewCount = 0;
		private int m_nUpdateCount = 0;

		//============================================================================*
		// cFirearmCaliberList() - Constructor
		//============================================================================*

		public cFirearmCaliberList()
			{
			}

		//============================================================================*
		// cFirearmCaliberList() - Copy Constructor
		//============================================================================*

		public cFirearmCaliberList(cFirearmCaliberList FirearmCaliberList)
			{
			Clear();

			if (FirearmCaliberList == null)
				return;

			foreach (cFirearmCaliber CheckFirearmCaliber in FirearmCaliberList)
				{
				cFirearmCaliber FirearmCaliber = new cFirearmCaliber(CheckFirearmCaliber);

				Add(FirearmCaliber);
				}
			}

		//============================================================================*
		// AddFirearmCaliber()
		//============================================================================*

		public bool AddFirearmCaliber(cFirearmCaliber FirearmCaliber, bool fCountOnly = false)
			{
			m_nImportCount++;

			foreach (cFirearmCaliber CheckFirearmCaliber in this)
				{
				if (CheckFirearmCaliber.CompareTo(FirearmCaliber) == 0)
					{
					m_nUpdateCount += CheckFirearmCaliber.Append(FirearmCaliber, fCountOnly);

					return (false);
					}
				}

			if (!fCountOnly)
				Add(FirearmCaliber);

			m_nNewCount++;

			return (true);
			}

		//============================================================================*
		// Export()
		//============================================================================*

		public void Export(StreamWriter Writer)
			{
			if (Count <= 0)
				return;

			string strLine = "";

			Writer.WriteLine(ExportName);
			Writer.WriteLine();

			Writer.WriteLine(cAmmo.CSVLineHeader);
			Writer.WriteLine();

			foreach (cFirearmCaliber FirearmCaliber in this)
				{
				strLine = FirearmCaliber.CSVLine;

				Writer.WriteLine(strLine);
				}

			Writer.WriteLine();
			}

		//============================================================================*
		// Export()
		//============================================================================*

		public void Export(cRWXMLDocument XMLDocument, XmlElement XMLParentElement)
			{
			if (Count > 0)
				{
				XmlElement XMLElement = XMLDocument.CreateElement(ExportName);
				XMLParentElement.AppendChild(XMLElement);

				foreach (cFirearmCaliber FirearmCaliber in this)
					FirearmCaliber.Export(XMLDocument, XMLElement);
				}
			}

		//============================================================================*
		// ExportName Property
		//============================================================================*

		public static string ExportName
			{
			get
				{
				return ("FirearmCaliberList");
				}
			}

		//============================================================================*
		// Import()
		//============================================================================*

		public void Import(cRWXMLDocument XMLDocument, XmlNode XMLThisNode, cDataFiles DataFiles, bool fCountOnly = false)
			{
			m_nImportCount = 0;
			m_nNewCount = 0;
			m_nUpdateCount = 0;

			XmlNode XMLNode = XMLThisNode.FirstChild;

			while (XMLNode != null)
				{
				switch (XMLNode.Name)
					{
					case "FirearmCaliber":
						cFirearmCaliber FirearmCaliber = new cFirearmCaliber();

						if (FirearmCaliber.Import(XMLDocument, XMLNode, DataFiles))
							AddFirearmCaliber(FirearmCaliber, fCountOnly);

						break;
					}

				XMLNode = XMLNode.NextSibling;
				}
			}

		//============================================================================*
		// ImportCount Property
		//============================================================================*

		public int ImportCount
			{
			get
				{
				return (m_nImportCount);
				}
			}

		//============================================================================*
		// NewCount Property
		//============================================================================*

		public int NewCount
			{
			get
				{
				return (m_nNewCount);
				}
			}

		//============================================================================*
		// ResolveIdentities()
		//============================================================================*

		public bool ResolveIdentities(cDataFiles Datafiles)
			{
			bool fChanged = false;

			foreach (cFirearmCaliber FirearmCaliber in this)
				fChanged = FirearmCaliber.ResolveIdentities(Datafiles) ? true : fChanged;

			return (fChanged);
			}

		//============================================================================*
		// UpdateCount Property
		//============================================================================*

		public int UpdateCount
			{
			get
				{
				return (m_nUpdateCount);
				}
			}
		}
	}
