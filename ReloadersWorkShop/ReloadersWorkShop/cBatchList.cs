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
		// Export()
		//============================================================================*

		public void Export(StreamWriter Writer, bool fBatchTests)
			{
			if (Count <= 0)
				return;

			Writer.WriteLine("Batches");
			Writer.WriteLine();

			Writer.WriteLine(cBatch.CSVLineHeader);
			Writer.WriteLine();

			foreach (cBatch Batch in this)
				Batch.Export(Writer, fBatchTests);

			Writer.WriteLine();
			}

		//============================================================================*
		// Export()
		//============================================================================*

		public void Export(XmlDocument XMLDocument, XmlElement XMLParentElement, bool fIncludeTests = true)
			{
			if (Count > 0)
				{
				XmlElement XMLElement = XMLDocument.CreateElement("Batches");
				XMLParentElement.AppendChild(XMLElement);

				foreach (cBatch Batch in this)
					Batch.Export(XMLDocument, XMLElement, fIncludeTests);
				}
			}
		}
	}
