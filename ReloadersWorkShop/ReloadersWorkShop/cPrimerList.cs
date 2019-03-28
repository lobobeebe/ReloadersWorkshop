//============================================================================*
// cPrimerList.cs
//
// Copyright © 2013-2014, Kevin S. Beebe
// All Rights Reserved
//============================================================================*

//============================================================================*
// .Net Using Statements
//============================================================================*

using System;
using System.IO;
using System.Collections.Generic;
using System.Xml;

//============================================================================*
// Namespace
//============================================================================*

namespace ReloadersWorkShop
	{
	[Serializable]
	public class cPrimerList : List<cPrimer>
		{
		//============================================================================*
		// Private Data Members
		//============================================================================*

		private int m_nImportCount = 0;
		private int m_nNewCount = 0;
		private int m_nUpdateCount = 0;

		//============================================================================*
		// AddPrimer()
		//============================================================================*

		public bool AddPrimer(cPrimer Primer)
			{
			foreach (cPrimer CheckPrimer in this)
				{
				if (CheckPrimer.CompareTo(Primer) == 0)
					return (false);
				}

			Add(Primer);

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

			Writer.WriteLine(cPrimer.CSVLineHeader);
			Writer.WriteLine();

			foreach (cPrimer Primer in this)
				{
				strLine = Primer.CSVLine;

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

				foreach (cPrimer Primer in this)
					Primer.Export(XMLDocument, XMLElement, false, fIncludeTransactions);
				}
			}

		//============================================================================*
		// ExportName Property
		//============================================================================*

		public string ExportName
			{
			get
				{
				return ("Primers");
				}
			}

		//============================================================================*
		// HandgunCount Property
		//============================================================================*

		public int HandgunCount
			{
			get
				{
				int nCount = 0;

				foreach (cPrimer Primer in this)
					{
					if (Primer.FirearmType == cFirearm.eFireArmType.Handgun)
						nCount++;
					}

				return (nCount);
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
					case "Primer":
						cPrimer Primer = new cPrimer();

						if (Primer.Import(XMLDocument, XMLNode, DataFiles))
							AddPrimer(Primer);

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
		// ResolveIdentities()
		//============================================================================*

		public bool ResolveIdentities(cDataFiles Datafiles)
			{
			bool fChanged = false;

			foreach (cPrimer Primer in this)
				fChanged = Primer.ResolveIdentities(Datafiles) ? true : fChanged;

			return (fChanged);
			}

		//============================================================================*
		// RifleCount Property
		//============================================================================*

		public int RifleCount
			{
			get
				{
				int nCount = 0;

				foreach (cPrimer Primer in this)
					{
					if (Primer.FirearmType == cFirearm.eFireArmType.Rifle)
						nCount++;
					}

				return (nCount);
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
		}
	}
