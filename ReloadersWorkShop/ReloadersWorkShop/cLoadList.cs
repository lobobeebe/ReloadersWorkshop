//============================================================================*
// cLoadList.cs
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

namespace ReloadersWorkShop
	{
	[Serializable]
	public class cLoadList : List<cLoad>
		{
		//============================================================================*
		// AddLoad()
		//============================================================================*

		public bool AddLoad(cLoad Load)
			{
			foreach (cLoad CheckLoad in this)
				{
				if (CheckLoad.CompareTo(Load) == 0)
					return (false);
				}

			Add(Load);

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

			Writer.WriteLine(cLoad.CSVLineHeader);
			Writer.WriteLine();

			foreach (cLoad Load in this)
				{
				cCaliber.CurrentFirearmType = Load.FirearmType;

				strLine = Load.CSVLine;

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

				foreach (cLoad Load in this)
					Load.Export(XMLDocument, XMLElement);
				}
			}

		//============================================================================*
		// ExportName()
		//============================================================================*

		public static string ExportName
			{
			get
				{
				return ("LoadList");
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
					case "Load":
						cLoad Load = new cLoad();

						if (Load.Import(XMLDocument, XMLNode, DataFiles))
							AddLoad(Load);

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

			foreach (cLoad Load in this)
				fChanged = Load.ResolveIdentities(Datafiles) ? true : fChanged;

			return (fChanged);
			}
		}
	}
