//============================================================================*
// cBulletList.cs
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
	//============================================================================*
	// cBulletList Class
	//============================================================================*

	[Serializable]
	public class cBulletList : List<cBullet>
		{
		//============================================================================*
		// AddBullet()
		//============================================================================*

		public bool AddBullet(cBullet Bullet)
			{
			foreach (cBullet CheckBullet in this)
				{
				if (CheckBullet.CompareTo(Bullet) == 0)
					return (false);
				}

			Add(Bullet);
			Sort();

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

		public void Import(cRWXMLDocument XMLDocument, XmlNode XMLThisNode, cDataFiles DataFiles)
			{
			XmlNode XMLNode = XMLThisNode.FirstChild;

			while (XMLNode != null)
				{
				switch (XMLNode.Name)
					{
					case "Bullet":
						cBullet Bullet = new cBullet();

						if (Bullet.Import(XMLDocument, XMLNode, DataFiles))
							AddBullet(Bullet);

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
		}
	}
