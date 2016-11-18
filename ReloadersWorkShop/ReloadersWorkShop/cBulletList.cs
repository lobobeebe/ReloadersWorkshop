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
					return(false);
				}

			Add(Bullet);
			Sort();

			return(true);
			}

		//============================================================================*
		// Export()
		//============================================================================*

		public void Export(StreamWriter Writer,  cDataFiles.eExportType eType)
			{
			string strLine = "";

			switch (eType)
				{
				case cDataFiles.eExportType.CSV:
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

					break;

				case cDataFiles.eExportType.XML:
					Writer.WriteLine(cFirearm.XMLHeader);
					Writer.WriteLine(cFirearm.XMLLineHeader);

					foreach (cBullet Bullet in this)
						{
						strLine = Bullet.XMLLine;

						Writer.WriteLine(strLine);
						}

					break;
				}
			}

		//============================================================================*
		// Export()
		//============================================================================*

		public void Export(XmlDocument XMLDocument, XmlElement XMLParentElement)
			{
			XmlElement XMLElement = XMLDocument.CreateElement(string.Empty, "Calibers", string.Empty);
			XMLParentElement.AppendChild(XMLElement);

			foreach (cBullet Bullet in this)
				{
				Bullet.Export(XMLDocument, XMLElement);
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
