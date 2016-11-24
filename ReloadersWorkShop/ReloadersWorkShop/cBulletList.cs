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

			Writer.WriteLine(cBullet.CSVHeader);
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

		public void Export(XmlDocument XMLDocument, XmlElement XMLParentElement)
			{
			if (Count > 0)
				{
				XmlElement XMLElement = XMLDocument.CreateElement(string.Empty, "Bullets", string.Empty);
				XMLParentElement.AppendChild(XMLElement);

				foreach (cBullet Bullet in this)
					{
					Bullet.Export(XMLDocument, XMLElement);
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

				foreach (cBullet Bullet in this)
					{
					if (Bullet.FirearmType == cFirearm.eFireArmType.Handgun)
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
