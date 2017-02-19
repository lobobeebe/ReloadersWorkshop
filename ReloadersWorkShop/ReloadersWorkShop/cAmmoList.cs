//============================================================================*
// cAmmoList.cs
//
// Copyright © 2013-2017, Kevin S. Beebe
// All Rights Reserved
//============================================================================*

//============================================================================*
// .Net Using Statements
//============================================================================*

using System;
using System.IO;
using System.Xml;

//============================================================================*
// NameSpace
//============================================================================*

namespace ReloadersWorkShop
	{
	//============================================================================*
	// cFactoryAmmoList Class
	//============================================================================*

	[Serializable]
	public class cAmmoList : cSupplyList
		{
		//============================================================================*
		// Private Data Members
		//============================================================================*

		private int m_nImportCount = 0;
		private int m_nNewCount = 0;
		private int m_nUpdateCount = 0;

		//============================================================================*
		// AddSupply()
		//============================================================================*

		public override bool AddSupply(cSupply Supply, bool fCountOnly = false)
			{
			if (Supply.SupplyType != cSupply.eSupplyTypes.Ammo)
				return (false);

			m_nImportCount++;

			cAmmo Ammo = (cAmmo) Supply;

			foreach (cAmmo CheckAmmo in this)
				{
				if (CheckAmmo.CompareTo(Ammo) == 0)
					{
					m_nUpdateCount += CheckAmmo.Append(Ammo, fCountOnly);

					return (false);
					}
				}

			base.AddSupply(Ammo, fCountOnly);

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

			foreach (cAmmo Ammo in this)
				{
				strLine = Ammo.CSVLine;

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
				XmlElement XMLElement = XMLDocument.CreateElement(ExportName, XMLParentElement);

				foreach (cAmmo Ammo in this)
					Ammo.Export(XMLDocument, XMLElement);
				}
			}

		//============================================================================*
		// ExportName Property
		//============================================================================*

		public static string ExportName
			{
			get
				{
				return ("AmmoList");
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
					case "Ammo":
						cAmmo Ammo = new cAmmo();

						if (Ammo.Import(XMLDocument, XMLNode, DataFiles))
							AddSupply(Ammo, fCountOnly);

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
		// NewAmmoTestCount Property
		//============================================================================*

		public int NewAmmoTestCount
			{
			get
				{
				int nNewAmmoTestCount = 0;

				foreach (cAmmo Ammo in this)
					nNewAmmoTestCount += Ammo.TestList.NewCount;

				return (nNewAmmoTestCount);
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
		// UpdatedAmmoTestCount Property
		//============================================================================*

		public int UpdatedAmmoTestCount
			{
			get
				{
				int nUpdatedAmmoTestCount = 0;

				foreach (cAmmo Ammo in this)
					nUpdatedAmmoTestCount += Ammo.TestList.UpdateCount;

				return (nUpdatedAmmoTestCount);
				}
			}
		}
	}
