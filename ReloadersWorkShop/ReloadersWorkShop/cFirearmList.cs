//============================================================================*
// cFirearmList.cs
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

//============================================================================*
// NameSpace
//============================================================================*

namespace ReloadersWorkShop
	{
	//============================================================================*
	// cFirearmList Class
	//============================================================================*

	[Serializable]
	public class cFirearmList : List<cFirearm>
		{
		//============================================================================*
		// Export()
		//============================================================================*

		public void Export(StreamWriter Writer)
			{
			if (Count <= 0)
				return;

			string strLine = "";

			Writer.WriteLine("Firearms");
			Writer.WriteLine();

			Writer.WriteLine(cFirearm.CSVLineHeader);
			Writer.WriteLine();

			foreach (cFirearm Firearm in this)
				{
				strLine = Firearm.CSVLine;

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
				XmlElement XMLElement = XMLDocument.CreateElement("Firearms");
				XMLParentElement.AppendChild(XMLElement);

				foreach (cFirearm Firearm in this)
					{
					Firearm.Export(XMLDocument, XMLElement);
					}
				}
			}

		//============================================================================*
		// Validate()
		//============================================================================*

		public bool Validate()
			{
			bool fOK = true;

			while (true)
				{
				bool fDeleted = false;

				foreach (cFirearm Firearm in this)
					{
					if (!Firearm.Validate())
						{
						fOK = false;

						Remove(Firearm);

						fDeleted = true;

						break;
						}
					}

				if (!fDeleted)
					break;
				}

			return (fOK);
			}
		}
	}
