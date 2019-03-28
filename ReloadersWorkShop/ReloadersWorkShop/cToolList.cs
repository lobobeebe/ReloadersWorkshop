//============================================================================*
// cToolList.cs
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

//============================================================================*
// NameSpace
//============================================================================*

namespace ReloadersWorkShop
	{
	//============================================================================*
	// cToolList Class
	//============================================================================*

	[Serializable]
	public class cToolList : List<cTool>
		{
		//============================================================================*
		// Private Data Members
		//============================================================================*

		private int m_nImportCount = 0;
		private int m_nNewCount = 0;
		private int m_nUpdateCount = 0;

		//============================================================================*
		// AddTool()
		//============================================================================*

		public bool AddTool(cTool Tool, bool fCountOnly = false)
			{
			m_nImportCount++;

			foreach (cTool CheckTool in this)
				{
				if (CheckTool.CompareTo(Tool) == 0)
					{
					m_nUpdateCount += CheckTool.Append(Tool, fCountOnly);

					return (false);
					}
				}

			if (!fCountOnly)
				Add(Tool);

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

			for (int i = 0; i < (int)cTool.eToolTypes.NumToolTypes; i++)
				{
				cTool.eToolTypes eType = (cTool.eToolTypes)i;

				Writer.WriteLine(cTool.ToolTypeString(eType));
				Writer.WriteLine();

				bool fHeader = false;

				foreach (cTool Tool in this)
					{
					if (Tool.ToolType != eType)
						continue;

					if (!fHeader)
						{
						Writer.WriteLine(Tool.CSVToolLineHeader);
						Writer.WriteLine();

						fHeader = true;
						}

					strLine = Tool.CSVLine;

					Writer.WriteLine(strLine);
					}

				Writer.WriteLine();
				}
			}

		//============================================================================*
		// Export()
		//============================================================================*

		public void Export(cRWXMLDocument XMLDocument, XmlElement XMLParentElement)
			{
			if (Count > 0)
				{
				XmlElement XMLElement = XMLDocument.CreateElement(ExportName, XMLParentElement);

				foreach (cTool Tool in this)
					Tool.Export(XMLDocument, XMLElement);
				}
			}

		//============================================================================*
		// ExportName()
		//============================================================================*

		public static string ExportName
			{
			get
				{
				return ("ToolList");
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
					case "Tool":
						cTool Tool = new cTool(cTool.eToolTypes.Other);

						if (Tool.Import(XMLDocument, XMLNode, DataFiles))
							AddTool(Tool, fCountOnly);

						break;
					}

				XMLNode = XMLNode.NextSibling;
				}
			}

		//============================================================================*
		// ImportCount Property
		//============================================================================*

		public virtual int ImportCount
			{
			get
				{
				return (m_nImportCount);
				}
			}

		//============================================================================*
		// NewCount Property
		//============================================================================*

		public virtual int NewCount
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

			foreach (cTool Tool in this)
				fChanged = Tool.ResolveIdentities(Datafiles) ? true : fChanged;

			return (fChanged);
			}

		//============================================================================*
		// Sort()
		//============================================================================*

		public void Sort(bool fSortByType = true)
			{
			cTool.SortByType = fSortByType;

			Sort(cTool.Comparer);
			}

		//============================================================================*
		// UpdateCount Property
		//============================================================================*

		public virtual int UpdateCount
			{
			get
				{
				return (m_nUpdateCount);
				}
			}
		}
	}
