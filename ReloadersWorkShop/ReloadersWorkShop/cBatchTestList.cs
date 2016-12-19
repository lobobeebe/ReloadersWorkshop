//============================================================================*
// cBatchTestList.cs
//
// Copyright © 2013-2017, Kevin S. Beebe
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
	//============================================================================*
	// cBatchTestList Class
	//============================================================================*

	[Serializable]
	public class cBatchTestList : List<cBatchTest>
		{
		//============================================================================*
		// cBatchTestList() - Default Constructor
		//============================================================================*

		public cBatchTestList()
			{
			}

		//============================================================================*
		// cBatchTestList() - Copy Constructor
		//============================================================================*

		public cBatchTestList(cBatchTestList BatchTestList)
			{
			if (BatchTestList != null)
				{
				foreach (cBatchTest BatchTest in BatchTestList)
					Add(new cBatchTest(BatchTest));
				}
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

			foreach (cBatchTest BatchTest in this)
				Writer.WriteLine(BatchTest.CSVLine);

			Writer.WriteLine();
			}

		//============================================================================*
		// Export() - XML
		//============================================================================*

		public void Export(cRWXMLDocument XMLDocument, XmlElement XMLParentElement)
			{
			if (Count > 0)
				{
				XmlElement XMLElement = XMLDocument.CreateElement(ExportName, XMLParentElement);

				foreach (cBatchTest BatchTest in this)
					BatchTest.Export(XMLDocument, XMLElement);
				}
			}

		//============================================================================*
		// ExportName Property
		//============================================================================*

		public string ExportName
			{
			get
				{
				return ("BatchTestList");
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
					case "BatchTest":
						cBatchTest BatchTest = new cBatchTest();

						if (BatchTest.Import(XMLDocument, XMLNode, DataFiles))
							{
							if (BatchTest.Validate())
								Add(BatchTest);
							else
								Console.WriteLine("Invalid BatchTest!");
							}

						break;
					}

				XMLNode = XMLNode.NextSibling;
				}
			}
		}
	}
