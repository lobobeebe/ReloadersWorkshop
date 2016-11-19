//============================================================================*
// cCaliberList.cs
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
	//============================================================================*
	// cCaliberList Class
	//============================================================================*

	[Serializable]
	public class cCaliberList : List<cCaliber>
		{
		//============================================================================*
		// CaliberList() - Default Constructor
		//============================================================================*

		public cCaliberList()
			{
			Clear();
			}

		//============================================================================*
		// CaliberList() - Copy Constructor
		//============================================================================*

		public cCaliberList(cCaliberList CaliberList)
			{
			Clear();

			foreach (cCaliber Caliber in CaliberList)
				Add(Caliber);
			}

		//============================================================================*
		// AddCaliber()
		//============================================================================*

		public bool AddCaliber(cCaliber Caliber)
			{
			foreach (cCaliber CheckCaliber in this)
				{
				if (CheckCaliber.CompareTo(Caliber) == 0)
					return (false);
				}

			Add(Caliber);

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

			Writer.WriteLine(cCaliber.CSVHeader);
			Writer.WriteLine();

			Writer.WriteLine(cCaliber.CSVLineHeader);
			Writer.WriteLine();

			foreach (cCaliber Caliber in this)
				{
				strLine = Caliber.CSVLine;

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
				XmlElement XMLElement = XMLDocument.CreateElement(string.Empty, "Calibers", string.Empty);
				XMLParentElement.AppendChild(XMLElement);

				foreach (cCaliber Caliber in this)
					{
					Caliber.Export(XMLDocument, XMLElement);
					}
				}
			}
		}
	}

