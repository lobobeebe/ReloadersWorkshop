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
	public class cAmmoList : cSupplyList
		{
		//============================================================================*
		// AddAmmo()
		//============================================================================*

		public override bool AddSupply(cSupply Supply)
			{
			if (Supply.SupplyType != cSupply.eSupplyTypes.Ammo)
				return (false);

			cAmmo Ammo = (cAmmo) Supply;

			foreach (cAmmo CheckAmmo in this)
				{
				if (CheckAmmo.CompareTo(Ammo) == 0)
					{
					CheckAmmo.Append(Ammo);

					return (false);
					}
				}

			base.AddSupply(Ammo);

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

		public void Import(cRWXMLDocument XMLDocument, XmlNode XMLThisNode, cDataFiles DataFiles)
			{
			XmlNode XMLNode = XMLThisNode.FirstChild;

			while (XMLNode != null)
				{
				switch (XMLNode.Name)
					{
					case "Ammo":
						cAmmo Ammo = new cAmmo();

						if (Ammo.Import(XMLDocument, XMLNode, DataFiles))
							AddSupply(Ammo);

						break;
					}

				XMLNode = XMLNode.NextSibling;
				}
			}
		}
	}
