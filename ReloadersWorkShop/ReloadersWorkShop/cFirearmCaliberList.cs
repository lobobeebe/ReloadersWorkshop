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
				return ("FirearmCalibers");
				}
			}
		}
	}
