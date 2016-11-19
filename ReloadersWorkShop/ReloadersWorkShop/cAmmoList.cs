//============================================================================*
// cFactoryAmmoList.cs
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
	// cFactoryAmmoList Class
	//============================================================================*

	[Serializable]
	public class cAmmoList : List<cAmmo>
		{
		//============================================================================*
		// Export()
		//============================================================================*

		public void Export(StreamWriter Writer)
			{
			if (Count <= 0)
				return;

			string strLine = "";

			Writer.WriteLine(cAmmo.CSVHeader);
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

		public void Export(XmlDocument XMLDocument, XmlElement XMLParentElement)
			{
			if (Count > 0)
				{
				XmlElement XMLElement = XMLDocument.CreateElement(string.Empty, "Ammunition", string.Empty);
				XMLParentElement.AppendChild(XMLElement);

				foreach (cAmmo Ammo in this)
					Ammo.Export(XMLDocument, XMLElement);
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
		}
	}
