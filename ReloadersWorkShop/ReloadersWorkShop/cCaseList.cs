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

			Writer.WriteLine(cCase.CSVHeader);
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
				XmlElement XMLElement = XMLDocument.CreateElement(string.Empty, "Cases", string.Empty);
				XMLParentElement.AppendChild(XMLElement);

				foreach (cCase Case in this)
					{
					Case.Export(XMLDocument, XMLElement);
					}
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
		// RecalulateInventory()
		//============================================================================*

		public void RecalulateInventory(cDataFiles DataFiles)
			{
			foreach (cSupply Supply in this)
				Supply.RecalculateInventory(DataFiles);
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
