//============================================================================*
// cBatchList.cs
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
	// cBatchList Class
	//============================================================================*

	[Serializable]
	public class cBatchList : List<cBatch>
		{
		//============================================================================*
		// AddBatch()
		//============================================================================*

		public bool AddBatch(cBatch Batch)
			{
			foreach (cBatch CheckBatch in this)
				{
				if (CheckBatch.CompareTo(Batch) == 0)
					return (false);
				}

			Add(Batch);

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

			Writer.WriteLine(ExportName);
			Writer.WriteLine();

			Writer.WriteLine(cBatch.CSVLineHeader);
			Writer.WriteLine();

			foreach (cBatch Batch in this)
				{
				strLine = Batch.CSVLine;

				Writer.WriteLine(strLine);
				}

			Writer.WriteLine();
			}

		//============================================================================*
		// Export()
		//============================================================================*

		public void Export(cRWXMLDocument XMLDocument, XmlElement XMLParentElement, bool fIncludeTests = true)
			{
			if (Count > 0)
				{
				XmlElement XMLElement = XMLDocument.CreateElement(ExportName);
				XMLParentElement.AppendChild(XMLElement);

				foreach (cBatch Batch in this)
					Batch.Export(XMLDocument, XMLElement);
				}
			}

		//============================================================================*
		// ExportName()
		//============================================================================*

		public string ExportName
			{
			get
				{
				return ("BatchList");
				}
			}


		//============================================================================*
		// Import()
		//============================================================================*

		public void Import(cRWXMLDocument XMLDocument, XmlNode XMLThisNode,  cDataFiles  DataFiles)
			{
			XmlNode XMLNode = XMLThisNode.FirstChild;

			while (XMLNode != null)
				{
				switch (XMLNode.Name)
					{
					case "Batch":
						cBatch Batch = new cBatch();

						if (Batch.Import(XMLDocument, XMLNode, DataFiles))
							{
							if (Batch.Validate())
								AddBatch(Batch);
							else
								Console.WriteLine("Invalid Batch!");
							}

						break;
					}

				XMLNode = XMLNode.NextSibling;
				}
			}

		//============================================================================*
		// ResolveIdentities()
		//============================================================================*

		public bool ResolveIdentities(cDataFiles Datafiles)
			{
			bool fChanged = false;

			foreach (cBatch Batch in this)
				fChanged = Batch.ResolveIdentities(Datafiles) ? true : fChanged;

			return (fChanged);
			}
		}
	}
