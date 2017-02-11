//============================================================================*
// cBulletCaliberList.cs
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
	[Serializable]
	//============================================================================*
	// cBulletCaliberList Class
	//============================================================================*

	public class cBulletCaliberList : List<cBulletCaliber>
		{
		//============================================================================*
		// Private Data Members
		//============================================================================*

		private int m_nImportCount = 0;
		private int m_nNewCount = 0;
		private int m_nUpdateCount = 0;

		//============================================================================*
		// cBulletCaliberList() - Constructor
		//============================================================================*

		public cBulletCaliberList()
			{
			}

		//============================================================================*
		// cBulletCaliberList() - Copy Constructor
		//============================================================================*

		public cBulletCaliberList(cBulletCaliberList CaliberList)
			{
			if (CaliberList != null)
				{
				foreach (cBulletCaliber Caliber in CaliberList)
					{
					cBulletCaliber NewCaliber = new cBulletCaliber(Caliber);

					Add(NewCaliber);
					}
				}

			Sort(cBulletCaliber.Comparer);
			}

		//============================================================================*
		// AddBulletCaliber()
		//============================================================================*

		public bool AddBulletCaliber(cBulletCaliber BulletCaliber, bool fCountOnly = false)
			{
			m_nImportCount++;

			foreach (cBulletCaliber CheckBulletCaliber in this)
				{
				if (CheckBulletCaliber.CompareTo(BulletCaliber) == 0)
					{
					m_nUpdateCount += CheckBulletCaliber.Append(BulletCaliber, fCountOnly);

					return (false);
					}
				}

			if (!fCountOnly)
				Add(BulletCaliber);

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

			Writer.WriteLine(cPowder.CSVLineHeader);
			Writer.WriteLine();

			foreach (cBulletCaliber BulletCaliber in this)
				{
				strLine = BulletCaliber.CSVLine;

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

				foreach (cBulletCaliber BulletCaliber in this)
					BulletCaliber.Export(XMLDocument, XMLElement);
				}
			}

		//============================================================================*
		// ExportName Property
		//============================================================================*

		public string ExportName
			{
			get
				{
				return ("BulletCaliberList");
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
					case "BulletCaliber":
						cBulletCaliber BulletCaliber = new cBulletCaliber();

						if (BulletCaliber.Import(XMLDocument, XMLNode, DataFiles))
							AddBulletCaliber(BulletCaliber, fCountOnly);

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

			foreach (cBulletCaliber BulletCaliber in this)
				fChanged = BulletCaliber.ResolveIdentities(Datafiles) ? true : fChanged;

			return (fChanged);
			}
		}
	}