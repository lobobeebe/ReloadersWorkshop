//============================================================================*
// cCaseList.cs
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
	public class cCaseList : List<cCase>
		{
		//============================================================================*
		// AddCase()
		//============================================================================*

		public bool AddCase(cCase Case)
			{
			foreach (cCase CheckCase in this)
				{
				if (CheckCase.CompareTo(Case) == 0)
					return (false);
				}

			Add(Case);

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

			Writer.WriteLine(cCase.CSVLineHeader);
			Writer.WriteLine();

			foreach (cCase Case in this)
				{
				strLine = Case.CSVLine;

				Writer.WriteLine(strLine);
				}

			Writer.WriteLine();
			}

		//============================================================================*
		// Export()
		//============================================================================*

		public void Export(XmlDocument XMLDocument, XmlElement XMLParentElement)
			{
			if (Count > 0)
				{
				XmlElement XMLElement = XMLDocument.CreateElement(ExportName);
				XMLParentElement.AppendChild(XMLElement);

				foreach (cCase Case in this)
					Case.Export(XMLDocument, XMLElement);
				}
			}

		//============================================================================*
		// ExportName Property
		//============================================================================*

		public string ExportName
			{
			get
				{
				return ("Cases");
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

				foreach (cCase Case in this)
					{
					if (Case.FirearmType == cFirearm.eFireArmType.Handgun)
						nCount++;
					}

				return (nCount);
				}
			}

		//============================================================================*
		// Import()
		//============================================================================*

		public void Import(XmlDocument XMLDocument, XmlNode XMLThisNode, cDataFiles DataFiles)
			{
			XmlNode XMLNode = XMLThisNode.FirstChild;

			while (XMLNode != null)
				{
				switch (XMLNode.Name)
					{
					case "Case":
						cCase Case = new cCase();

						if (Case.Import(XMLDocument, XMLNode, DataFiles))
							AddCase(Case);

						break;
					}

				XMLNode = XMLNode.NextSibling;
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

			foreach (cCase Case in this)
				fChanged = Case.ResolveIdentities(Datafiles) ? true : fChanged;

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

				foreach (cCase Case in this)
					{
					if (Case.FirearmType == cFirearm.eFireArmType.Rifle)
						nCount++;
					}

				return (nCount);
				}
			}
		}
	}
