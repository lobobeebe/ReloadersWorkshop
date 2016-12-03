//============================================================================*
// cManufacturerList.cs
//
// Copyright © 2013-2014, Kevin S. Beebe
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
// NameSpace
//============================================================================*

namespace ReloadersWorkShop
	{
	[Serializable]
	public class cManufacturerList : List<cManufacturer>
		{
		//============================================================================*
		// AddManufacturer()
		//============================================================================*

		public bool AddManufacturer(cManufacturer Manufacturer)
			{
			foreach (cManufacturer CheckManufacturer in this)
				{
				if (CheckManufacturer.CompareTo(Manufacturer) == 0)
					return (false);
				}

			Add(Manufacturer);

			return (true);
			}

		//============================================================================*
		// Export()
		//============================================================================*

		public void Export(StreamWriter Writer)
			{
			if (Count <= 0)
				return;

			Writer.WriteLine(ExportName);
			Writer.WriteLine();

			string strLine = "";

			Writer.WriteLine(cManufacturer.CSVLineHeader);
			Writer.WriteLine();

			foreach (cManufacturer Manufacturer in this)
				{
				strLine = Manufacturer.CSVLine;

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

				foreach (cManufacturer Manufacturer in this)
					Manufacturer.Export(XMLDocument, XMLElement);
				}
			}

		//============================================================================*
		// ExportName Property
		//============================================================================*

		public static string ExportName
			{
			get
				{
				return ("ManufacturerList");
				}
			}

		//============================================================================*
		// Import()
		//============================================================================*

		public void Import(XmlDocument XMLDocument, XmlNode XMLThisNode)
			{
			XmlNode XMLNode = XMLThisNode.FirstChild;

			while (XMLNode != null)
				{
				switch (XMLNode.Name)
					{
					case "Manufacturer":
						cManufacturer Manufacturer = new cManufacturer();

						if (Manufacturer.Import(XMLDocument, XMLNode))
							{
							if (Manufacturer.Validate())
								AddManufacturer(Manufacturer);
							else
								Console.WriteLine("Invalid Manufacturer!");
							}

						break;
					}

				XMLNode = XMLNode.NextSibling;
				}
			}
		}
	}
