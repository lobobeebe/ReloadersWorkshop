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
		// AddAmmo()
		//============================================================================*

		public bool AddAmmo(cAmmo Ammo)
			{
			foreach (cAmmo CheckAmmo in this)
				{
				if (CheckAmmo.CompareTo(Ammo) == 0)
					return (false);
				}

			Add(Ammo);

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

		public void Export(XmlDocument XMLDocument, XmlElement XMLParentElement)
			{
			if (Count > 0)
				{
				XmlElement XMLElement = XMLDocument.CreateElement(ExportName);
				XMLParentElement.AppendChild(XMLElement);

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

		public void Import(XmlDocument XMLDocument, XmlNode XMLThisNode,  cDataFiles DataFiles)
			{
			XmlNode XMLNode = XMLThisNode.FirstChild;

			while (XMLNode != null)
				{
				switch (XMLNode.Name)
					{
					case "Ammo":
						cAmmo Ammo = new cAmmo();

						if (Ammo.Import(XMLDocument, XMLNode, DataFiles))
							{
							if (Ammo.Validate())
								AddAmmo(Ammo);
							else
								Console.WriteLine("Invalid Ammo!");
							}

						break;
					}

				XMLNode = XMLNode.NextSibling;
				}
			}

		//============================================================================*
		// RecalculateInventory()
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

			foreach (cAmmo Ammo in this)
				fChanged = Ammo.ResolveIdentities(Datafiles) ? true : fChanged;
				
			return (fChanged);
			}
		}
	}
