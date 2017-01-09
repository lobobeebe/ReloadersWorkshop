//============================================================================*
// cPowderList.cs
//
// Copyright © 2013-2017, Kevin S. Beebe
// All Rights Reserved
//============================================================================*

//============================================================================*
// .Net Using Statements
//============================================================================*

using System;
using System.IO;
using System.Collections.Generic;
using System.Xml;

namespace ReloadersWorkShop
	{
	[Serializable]
	public class cPowderList : List<cPowder>
		{
		//============================================================================*
		// Private Data Members
		//============================================================================*

		private int m_nImportCount = 0;
		private int m_nNewCount = 0;
		private int m_nUpdateCount = 0;

		//============================================================================*
		// AddPowder()
		//============================================================================*

		public bool AddPowder(cPowder Powder, bool fCountOnly = false)
			{
			m_nImportCount++;

			foreach (cPowder CheckPowder in this)
				{
				if (CheckPowder.CompareTo(Powder) == 0)
					m_nUpdateCount += CheckPowder.Append(Powder, fCountOnly);
				}

			if (!fCountOnly)
				Add(Powder);

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

			foreach (cPowder Powder in this)
				{
				strLine = Powder.CSVLine;

				Writer.WriteLine(strLine);
				}

			Writer.WriteLine();
			}

		//============================================================================*
		// Export()
		//============================================================================*

		public void Export(cRWXMLDocument XMLDocument, XmlElement XMLParentElement, bool fIncludeTransactions = true)
			{
			if (Count > 0)
				{
				XmlElement XMLElement = XMLDocument.CreateElement(ExportName);
				XMLParentElement.AppendChild(XMLElement);

				foreach (cPowder Powder in this)
					Powder.Export(XMLDocument, XMLElement, false, fIncludeTransactions);
				}
			}

		//============================================================================*
		// ExportName Property
		//============================================================================*

		public string ExportName
			{
			get
				{
				return ("Powders");
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
					case "Powder":
						cPowder Powder = new cPowder();

						if (Powder.Import(XMLDocument, XMLNode, DataFiles))
							AddPowder(Powder, fCountOnly);

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
		// RecalulateInventory()
		//============================================================================*

		public void RecalulateInventory(cDataFiles DataFiles)
			{
			foreach (cSupply Supply in this)
				Supply.RecalculateInventory(DataFiles);
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
