//============================================================================*
// cFirearmList.cs
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
// NameSpace
//============================================================================*

namespace ReloadersWorkShop
	{
	//============================================================================*
	// cFirearmList Class
	//============================================================================*

	[Serializable]
	public class cFirearmList : List<cFirearm>
		{
		//============================================================================*
		// AddFirearm()
		//============================================================================*

		public bool AddFirearm(cFirearm Firearm)
			{
			foreach (cFirearm CheckFirearm in this)
				{
				if (CheckFirearm.CompareTo(Firearm) == 0)
					return (false);
				}

			Add(Firearm);

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

			Writer.WriteLine(cFirearm.CSVLineHeader);
			Writer.WriteLine();

			foreach (cFirearm Firearm in this)
				{
				strLine = Firearm.CSVLine;

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

				foreach (cFirearm Firearm in this)
					{
					Firearm.Export(XMLDocument, XMLElement);
					}
				}
			}

		//============================================================================*
		// ExportName()
		//============================================================================*

		public static string ExportName
			{
			get
				{
				return ("FirearmList");
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
					case "Firearm":
						cFirearm Firearm = new cFirearm();

						if (Firearm.Import(XMLDocument, XMLNode, DataFiles))
							AddFirearm(Firearm);

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

			foreach (cFirearm Firearm in this)
				fChanged = Firearm.ResolveIdentities(Datafiles) ? true : fChanged;

			return (fChanged);
			}

		//============================================================================*
		// Validate()
		//============================================================================*

		public bool Validate()
			{
			bool fOK = true;

			while (true)
				{
				bool fDeleted = false;

				foreach (cFirearm Firearm in this)
					{
					if (!Firearm.Validate())
						{
						fOK = false;

						Remove(Firearm);

						fDeleted = true;

						break;
						}
					}

				if (!fDeleted)
					break;
				}

			return (fOK);
			}
		}
	}
