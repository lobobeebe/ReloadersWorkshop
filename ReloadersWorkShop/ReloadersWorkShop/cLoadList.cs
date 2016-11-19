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

			Writer.WriteLine(cLoad.CSVHeader);
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

		public void Export(XmlDocument XMLDocument, XmlElement XMLParentElement, bool fIncludeCharges = true)
			{
			if (Count > 0)
				{
				XmlElement XMLElement = XMLDocument.CreateElement("Loads");
				XMLParentElement.AppendChild(XMLElement);

				foreach (cLoad Load in this)
					Load.Export(XMLDocument, XMLElement, fIncludeCharges);
				}
			}
		}
	}
