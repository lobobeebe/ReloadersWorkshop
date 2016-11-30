//============================================================================*
// cFirearmCaliberList.cs
//
// Copyright © 2013-2015, Kevin S. Beebe
// All Rights Reserved
//============================================================================*

//============================================================================*
// .Net Using Statements
//============================================================================*

using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

//============================================================================*
// Namespace
//============================================================================*

namespace ReloadersWorkShop
	{
	//============================================================================*
	// cFirearmCaliberList Class
	//============================================================================*

	[Serializable]
	public class cFirearmCaliberList : List<cFirearmCaliber>
		{
		//============================================================================*
		// cFirearmCaliberList() - Constructor
		//============================================================================*

		public cFirearmCaliberList()
			{
			}

		//============================================================================*
		// cFirearmCaliberList() - Copy Constructor
		//============================================================================*

		public cFirearmCaliberList(cFirearmCaliberList FirearmCaliberList)
			{
			Clear();

			if (FirearmCaliberList == null)
				return;

			foreach (cFirearmCaliber CheckFirearmCaliber in FirearmCaliberList)
				{
				cFirearmCaliber FirearmCaliber = new cFirearmCaliber(CheckFirearmCaliber);

				Add(FirearmCaliber);
				}
			}

		//============================================================================*
		// AddFirearmCaliber()
		//============================================================================*

		public bool AddFirearmCaliber(cFirearmCaliber FirearmCaliber)
			{
			foreach (cFirearmCaliber CheckFirearmCaliber in this)
				{
				if (CheckFirearmCaliber.CompareTo(FirearmCaliber) == 0)
					return (false);
				}

			Add(FirearmCaliber);

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

			foreach (cFirearmCaliber FirearmCaliber in this)
				{
				strLine = FirearmCaliber.CSVLine;

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

				foreach (cFirearmCaliber FirearmCaliber in this)
					FirearmCaliber.Export(XMLDocument, XMLElement);
				}
			}

		//============================================================================*
		// ExportName Property
		//============================================================================*

		public static string ExportName
			{
			get
				{
				return ("FirearmCaliberList");
				}
			}

		//============================================================================*
		// Import()
		//============================================================================*

		public void Import(XmlDocument XMLDocument, XmlNode XMLThisNode, cDataFiles DataFiles)
			{
			XmlNode XMLNode = XMLThisNode.FirstChild;

			while (XMLNode != null)
				{
				switch (XMLNode.Name)
					{
					case "FirearmCaliber":
						cFirearmCaliber FirearmCaliber = new cFirearmCaliber();

						if (FirearmCaliber.Import(XMLDocument, XMLNode, DataFiles))
							AddFirearmCaliber(FirearmCaliber);

						break;
					}

				XMLNode = XMLNode.NextSibling;
				}
			}

		//============================================================================*
		// ResolveIdentities()
		//============================================================================*

		public bool ResolveIdentities(cDataFiles Datafiles)
			{
			bool fChanged = false;

			foreach (cFirearmCaliber FirearmCaliber in this)
				fChanged = FirearmCaliber.ResolveIdentities(Datafiles) ? true : fChanged;

			return (fChanged);
			}
		}
	}
