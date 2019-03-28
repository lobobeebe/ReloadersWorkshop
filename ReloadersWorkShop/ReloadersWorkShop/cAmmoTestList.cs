//============================================================================*
// cFactoryAmmoTestList.cs
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

namespace ReloadersWorkShop
	{
	[Serializable]
	public class cAmmoTestList : List<cAmmoTest>
		{
		//============================================================================*
		// Private Data Members
		//============================================================================*

		private int m_nNewCount = 0;
		private int m_nUpdateCount = 0;

		//============================================================================*
		// cFactoryAmmoTestList() - Default Constructor
		//============================================================================*

		public cAmmoTestList()
			{
			}

		//============================================================================*
		// cFactoryAmmoTestList() - Copy Constructor
		//============================================================================*

		public cAmmoTestList(cAmmoTestList FactoryAmmoTestList)
			{
			if (FactoryAmmoTestList == null)
				return;

			foreach (cAmmoTest FactoryAmmoTest in FactoryAmmoTestList)
				Add(new cAmmoTest(FactoryAmmoTest));
			}

		//============================================================================*
		// AddAmmoTest()
		//============================================================================*

		public bool AddAmmoTest(cAmmoTest AmmoTest, bool fCountOnly = false)
			{
			foreach (cAmmoTest CheckAmmoTest in this)
				{
				if (CheckAmmoTest.CompareTo(AmmoTest) == 0)
					{
					m_nUpdateCount += CheckAmmoTest.Append(AmmoTest, fCountOnly);

					return (false);
					}
				}

			if (!fCountOnly)
				Add(AmmoTest);

			m_nNewCount++;

			return (true);
			}

		//============================================================================*
		// Append()
		//============================================================================*

		public bool Append(cAmmoTestList AmmoTestList, bool fCountOnly = false)
			{
			foreach (cAmmoTest CheckAmmoTest in AmmoTestList)
				{
				bool fFound = false;

				foreach (cAmmoTest AmmoTest in this)
					{
					if (CheckAmmoTest.CompareTo(AmmoTest) == 0)
						{
						AmmoTest.Append(CheckAmmoTest, fCountOnly);

						fFound = true;
						}
					}

				if (!fFound && !fCountOnly)
					Add(CheckAmmoTest);
				}

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

			foreach (cAmmoTest AmmoTest in this)
				{
				strLine = AmmoTest.CSVLine;

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

				foreach (cAmmoTest AmmoTest in this)
					AmmoTest.Export(XMLDocument, XMLElement);
				}
			}

		//============================================================================*
		// ExportName Property
		//============================================================================*

		public static string ExportName
			{
			get
				{
				return ("AmmoTestList");
				}
			}

		//============================================================================*
		// Import()
		//============================================================================*

		public void Import(cRWXMLDocument XMLDocument, XmlNode XMLThisNode, cDataFiles DataFiles, cAmmo Ammo, bool fCountOnly = false)
			{
			m_nNewCount = 0;
			m_nUpdateCount = 0;

			XmlNode XMLNode = XMLThisNode.FirstChild;

			while (XMLNode != null)
				{
				switch (XMLNode.Name)
					{
					case "AmmoTest":
						cAmmoTest AmmoTest = new cAmmoTest();
						AmmoTest.Ammo = Ammo;

						if (AmmoTest.Import(XMLDocument, XMLNode, DataFiles))
							AddAmmoTest(AmmoTest);

						break;
					}

				XMLNode = XMLNode.NextSibling;
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

		public bool ResolveIdentities(cDataFiles DataFiles)
			{
			bool fChanged = false;

			foreach (cAmmoTest AmmoTest in this)
				fChanged = AmmoTest.ResolveIdentities(DataFiles) ? true : fChanged;

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
