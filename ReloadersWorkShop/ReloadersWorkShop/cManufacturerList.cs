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

		public void Export(StreamWriter Writer, cDataFiles.eExportType eType)
			{
			Writer.WriteLine(cManufacturer.CSVHeader);
			Writer.WriteLine();

			string strLine = "";

			switch (eType)
				{
				case cDataFiles.eExportType.CSV:
					Writer.WriteLine(cManufacturer.CSVLineHeader);
					Writer.WriteLine();

					foreach (cManufacturer Manufacturer in this)
						{
						strLine = Manufacturer.CSVLine;

						Writer.WriteLine(strLine);
						}

					break;
				}

			Writer.WriteLine();
			}

		//============================================================================*
		// Export()
		//============================================================================*

		public void Export(XmlDocument XMLDocument, XmlElement XMLParentElement)
			{
			XmlElement XMLElement = XMLDocument.CreateElement(string.Empty, "Manufacturers", string.Empty);
			XMLParentElement.AppendChild(XMLElement);

			foreach (cManufacturer Manufacturer in this)
				{
				Manufacturer.Export(XMLDocument, XMLElement);
				}
			}
		}
	}
