//============================================================================*
// cGearList.cs
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
// NameSpace
//============================================================================*

namespace ReloadersWorkShop
	{
	//============================================================================*
	// cGearList Class
	//============================================================================*

	[Serializable]
	public class cGearList : List<cGear>
		{
		//============================================================================*
		// Private Data Members
		//============================================================================*

		private int m_nImportCount = 0;
		private int m_nNewCount = 0;
		private int m_nUpdateCount = 0;

		//============================================================================*
		// AddGear()
		//============================================================================*

		public bool AddGear(cGear Gear, bool fCountOnly = false)
			{
			m_nImportCount++;

			foreach (cGear CheckGear in this)
				{
				if (CheckGear.CompareTo(Gear) == 0)
					{
					m_nUpdateCount += CheckGear.Append(Gear, fCountOnly);

					return (false);
					}
				}

			if (!fCountOnly)
				Add(Gear);

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

			for (int i = 0; i < (int) cGear.eGearTypes.NumGearTypes; i++)
				{
				cGear.eGearTypes eType = (cGear.eGearTypes) i;

				Writer.WriteLine(cGear.GearTypeString(eType));
				Writer.WriteLine();

				bool fHeader = false;

				foreach (cGear Gear in this)
					{
					if (Gear.GearType != eType)
						continue;

					if (!fHeader)
						{
						Writer.WriteLine(Gear.CSVGearLineHeader);
						Writer.WriteLine();

						fHeader = true;
						}

					strLine = Gear.CSVLine;

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

				foreach (cGear Gear in this)
					Gear.Export(XMLDocument, XMLElement);
				}
			}

		//============================================================================*
		// ExportName()
		//============================================================================*

		public static string ExportName
			{
			get
				{
				return ("GearList");
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
					case "Gear":
						cGear Gear = new cGear(cGear.eGearTypes.Misc);

						if (Gear.Import(XMLDocument, XMLNode, DataFiles))
							AddGear(Gear, fCountOnly);

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

			foreach (cGear Gear in this)
				fChanged = Gear.ResolveIdentities(Datafiles) ? true : fChanged;

			return (fChanged);
			}

		//============================================================================*
		// Sort()
		//============================================================================*

		public void Sort(bool fSortByType = true)
			{
			cGear.SortByType = fSortByType;

			Sort(cGear.Comparer);
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
