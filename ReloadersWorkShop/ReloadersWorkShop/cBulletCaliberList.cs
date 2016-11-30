//============================================================================*
// cBulletCaliberList.cs
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
	public class cBulletCaliberList : List<cBulletCaliber>
		{
		//============================================================================*
		// cBulletCaliberList() - Constructor
		//============================================================================*

		public cBulletCaliberList()
			{
			}

		//============================================================================*
		// cBulletCaliberList() - Copy Constructor
		//============================================================================*

		public cBulletCaliberList(cBulletCaliberList CaliberList)
			{
			if (CaliberList != null)
				{
				foreach (cBulletCaliber Caliber in CaliberList)
					{
					cBulletCaliber NewCaliber = new cBulletCaliber(Caliber);

					Add(NewCaliber);
					}
				}

			Sort(cBulletCaliber.Comparer);
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

			Writer.WriteLine(cPowder.CSVLineHeader);
			Writer.WriteLine();

			foreach (cBulletCaliber BulletCaliber in this)
				{
				strLine = BulletCaliber.CSVLine;

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

				foreach (cBulletCaliber BulletCaliber in this)
					BulletCaliber.Export(XMLDocument, XMLElement);
				}
			}

		//============================================================================*
		// ExportName Property
		//============================================================================*

		public string ExportName
			{
			get
				{
				return ("BulletCalibers");
				}
			}
		}
	}
