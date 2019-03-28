//============================================================================*
// cCaliberList.cs
//
// Copyright © 2013-2014, Kevin S. Beebe
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
// NameSpace
//============================================================================*

namespace ReloadersWorkShop
	{
	//============================================================================*
	// cCaliberList Class
	//============================================================================*

	[Serializable]
	public class cCaliberList : List<cCaliber>
		{
		//============================================================================*
		// Private Data Members
		//============================================================================*

		private int m_nImportCount = 0;
		private int m_nNewCount = 0;
		private int m_nUpdateCount = 0;

		//============================================================================*
		// CaliberList() - Default Constructor
		//============================================================================*

		public cCaliberList()
			{
			Clear();
			}

		//============================================================================*
		// CaliberList() - Copy Constructor
		//============================================================================*

		public cCaliberList(cCaliberList CaliberList)
			{
			Clear();

			foreach (cCaliber Caliber in CaliberList)
				Add(Caliber);
			}

		//============================================================================*
		// AddCaliber()
		//============================================================================*

		public bool AddCaliber(cCaliber Caliber, bool fCountOnly = false)
			{
			m_nImportCount++;

			foreach (cCaliber CheckCaliber in this)
				{
				if (CheckCaliber.CompareTo(Caliber) == 0)
					{
					m_nUpdateCount += CheckCaliber.Append(Caliber, fCountOnly);

					return (false);
					}
				}

			if (!fCountOnly)
				Add(Caliber);

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

			Writer.WriteLine(cCaliber.CSVLineHeader);
			Writer.WriteLine();

			foreach (cCaliber Caliber in this)
				{
				strLine = Caliber.CSVLine;

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

				foreach (cCaliber Caliber in this)
					Caliber.Export(XMLDocument, XMLElement);
				}
			}

		//============================================================================*
		// ExportName Property
		//============================================================================*

		public string ExportName
			{
			get
				{
				return ("CaliberList");
				}
			}

		//============================================================================*
		// Import()
		//============================================================================*

		public void Import(cRWXMLDocument XMLDocument, XmlNode XMLThisNode, bool fCountOnly = false)
			{
			m_nImportCount = 0;
			m_nNewCount = 0;
			m_nUpdateCount = 0;

			XmlNode XMLNode = XMLThisNode.FirstChild;

			while (XMLNode != null)
				{
				switch (XMLNode.Name)
					{
					case "Caliber":
						cCaliber Caliber = new cCaliber();

						if (Caliber.Import(XMLDocument, XMLNode))
							AddCaliber(Caliber, fCountOnly);

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
		// UpdateCount Property
		//============================================================================*

		public int UpdateCount
			{
			get
				{
				return (m_nUpdateCount);
				}
			}

		//============================================================================*
		// ResolveIdentities()
		//============================================================================*

		public bool ResolveIdentities(cDataFiles Datafiles)
			{
			bool fChanged = false;

			foreach (cCaliber Caliber in this)
				fChanged = Caliber.ResolveIdentities(Datafiles) ? true : fChanged;

			return (fChanged);
			}
		}
	}

