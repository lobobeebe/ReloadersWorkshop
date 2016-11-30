//============================================================================*
// cFactoryAmmoTestList.cs
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

namespace ReloadersWorkShop
	{
	[Serializable]
	public class cAmmoTestList : List<cAmmoTest>
		{
		//============================================================================*
		// cFactoryAmmoTestList() - Default Constructor
		//============================================================================*

		public cAmmoTestList()
			{
			}

		//============================================================================*
		// cFactoryAmmoTestList() - Copy Constructor
		//============================================================================*

		public cAmmoTestList(cAmmoTestList FactoryAmmoTestList)
			{
			if (FactoryAmmoTestList == null)
				return;

			foreach (cAmmoTest FactoryAmmoTest in FactoryAmmoTestList)
				Add(new cAmmoTest(FactoryAmmoTest));
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

			foreach (cAmmoTest AmmoTest in this)
				{
				strLine = AmmoTest.CSVLine;

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

				foreach (cAmmoTest AmmoTest in this)
					AmmoTest.Export(XMLDocument, XMLElement);
				}
			}

		//============================================================================*
		// ExportName Property
		//============================================================================*

		public static string ExportName
			{
			get
				{
				return ("AmmoTests");
				}
			}
		}
	}
