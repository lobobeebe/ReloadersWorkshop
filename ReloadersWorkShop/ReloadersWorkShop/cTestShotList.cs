//============================================================================*
// cTestShotList.cs
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
	// cTestShotList Class
	//============================================================================*

	[Serializable]
	public class cTestShotList : List<cTestShot>
		{
		//============================================================================*
		// cTestShotList() - Constructor
		//============================================================================*

		public cTestShotList()
			{
			}

		//============================================================================*
		// cTestShotList() - Copy Constructor
		//============================================================================*

		public cTestShotList(cTestShotList TestShotList)
			{
			foreach (cTestShot TestShot in TestShotList)
				Add(new cTestShot(TestShot));
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

			Writer.WriteLine(cTestShot.CSVLineHeader);
			Writer.WriteLine();

			foreach (cTestShot TestShot in this)
				Writer.WriteLine(TestShot.CSVLine);

			Writer.WriteLine();
			}

		//============================================================================*
		// Export() - XML
		//============================================================================*

		public void Export(cRWXMLDocument XMLDocument, XmlElement XMLParentElement)
			{
			if (Count > 0)
				{
				XmlElement XMLElement = XMLDocument.CreateElement(ExportName);
				XMLParentElement.AppendChild(XMLElement);

				foreach (cTestShot TestShot in this)
					TestShot.Export(XMLDocument, XMLElement);
				}
			}

		//============================================================================*
		// ExportName Property
		//============================================================================*

		public static string ExportName
			{
			get
				{
				return ("TestShotList");
				}
			}

		//============================================================================*
		// Import()
		//============================================================================*

		public void Import(cRWXMLDocument XMLDocument, XmlNode XMLThisNode, cDataFiles DataFiles)
			{
			Clear();

			XmlNode XMLNode = XMLThisNode.FirstChild;

			while (XMLNode != null)
				{
				switch (XMLNode.Name)
					{
					case "TestShot":
						cTestShot TestShot = new cTestShot();

						if (TestShot.Import(XMLDocument, XMLNode, DataFiles))
							{
							if (TestShot.Validate())
								Add(TestShot);
							}

						break;
					}

				XMLNode = XMLNode.NextSibling;
				}
			}

		//============================================================================*
		// Statistics Property
		//============================================================================*

		public cTestStatistics Statistics
			{
			get
				{
				return (new cTestStatistics(this));
				}
			}
		}
	}
