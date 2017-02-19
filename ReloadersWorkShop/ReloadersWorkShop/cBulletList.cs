//============================================================================*
// cBulletList.cs
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
// Namespace
//============================================================================*

namespace ReloadersWorkShop
	{
	//============================================================================*
	// cBulletList Class
	//============================================================================*

	[Serializable]
	public class cBulletList : List<cBullet>
		{
		//============================================================================*
		// Private Data Members
		//============================================================================*

		private int m_nImportCount = 0;
		private int m_nNewCount = 0;
		private int m_nUpdateCount = 0;

		//============================================================================*
		// AddBullet()
		//============================================================================*

		public bool AddBullet(cBullet Bullet, bool fCountOnly = false)
			{
			m_nImportCount++;

			foreach (cBullet CheckBullet in this)
				{
				if (CheckBullet.CompareTo(Bullet) == 0)
					{
					m_nUpdateCount += CheckBullet.Append(Bullet, fCountOnly);

					return (false);
					}
				}

			if (!fCountOnly)
				Add(Bullet);

			m_nNewCount++;

			Sort();

			return (true);
			}

		//============================================================================*
		// BulletCaliberCount Property
		//============================================================================*

		public int BulletCaliberCount
			{
			get
				{
				int nCount = 0;

				foreach (cBullet CheckBullet in this)
					nCount += CheckBullet.BulletCaliberList.Count;

				return (nCount);
				}
			}

		//============================================================================*
		// BulletCaliberImportCount Property
		//============================================================================*

		public int BulletCaliberImportCount
			{
			get
				{
				int nCount = 0;

				foreach (cBullet CheckBullet in this)
					nCount += CheckBullet.BulletCaliberList.ImportCount;

				return (nCount);
				}
			}

		//============================================================================*
		// BulletCaliberNewCount Property
		//============================================================================*

		public int BulletCaliberNewCount
			{
			get
				{
				int nCount = 0;

				foreach (cBullet CheckBullet in this)
					nCount += CheckBullet.BulletCaliberList.NewCount;

				return (nCount);
				}
			}

		//============================================================================*
		// BulletCaliberUpdateCount Property
		//============================================================================*

		public int BulletCaliberUpdateCount
			{
			get
				{
				int nCount = 0;

				foreach (cBullet CheckBullet in this)
					nCount += CheckBullet.BulletCaliberList.UpdateCount;

				return (nCount);
				}
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

			Writer.WriteLine(cBullet.CSVLineHeader);
			Writer.WriteLine();

			foreach (cBullet Bullet in this)
				{
				strLine = Bullet.CSVLine;

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
				XmlElement XMLElement = XMLDocument.CreateElement(ExportName, XMLParentElement);

				foreach (cBullet Bullet in this)
					{
					Bullet.Export(XMLDocument, XMLElement, false, fIncludeTransactions);
					}
				}
			}

		//============================================================================*
		// ExportName Property
		//============================================================================*

		public static string ExportName
			{
			get
				{
				return ("BulletList");
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

				foreach (cBullet Bullet in this)
					{
					if (Bullet.FirearmType == cFirearm.eFireArmType.Handgun)
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
					case "Bullet":
						cBullet Bullet = new cBullet();

						if (Bullet.Import(XMLDocument, XMLNode, DataFiles))
							AddBullet(Bullet, fCountOnly);

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

			foreach (cBullet Bullet in this)
				fChanged = Bullet.ResolveIdentities(Datafiles) ? true : fChanged;

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

				foreach (cBullet Bullet in this)
					{
					if (Bullet.FirearmType == cFirearm.eFireArmType.Rifle)
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
