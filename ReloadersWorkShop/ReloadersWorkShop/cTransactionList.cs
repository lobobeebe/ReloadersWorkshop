//============================================================================*
// cTransactionList.cs
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
	// cTransactionList Class
	//============================================================================*

	[Serializable]
	public class cTransactionList : List<cTransaction>
		{
		//============================================================================*
		// cTransactionList() - Default Constructor
		//============================================================================*

		public cTransactionList()
			{

			}

		//============================================================================*
		// cTransactionList() - Copy Constructor
		//============================================================================*

		public cTransactionList(cTransactionList TransactionList)
			{
			foreach(cTransaction Transaction in TransactionList)
				Add(new cTransaction(Transaction));
			}

		//============================================================================*
		// Export()
		//============================================================================*

		public void Export(StreamWriter Writer,  cSupply Supply)
			{
			if (Count <= 0)
				return;

			string strLine = "";

			Writer.WriteLine(cTransaction.CSVHeader);
			Writer.WriteLine();

			Writer.WriteLine(cTransaction.CSVLineHeader);
			Writer.WriteLine();

			foreach (cTransaction Transaction in Supply.TransactionList)
				{
				strLine = Transaction.CSVLine;

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
				XmlElement XMLElement = XMLDocument.CreateElement(string.Empty, "Bullets", string.Empty);
				XMLParentElement.AppendChild(XMLElement);

				foreach (cTransaction Transaction in this)
					Transaction.Export(XMLDocument, XMLElement);
				}
			}

		//============================================================================*
		// ResolveIdentities()
		//============================================================================*

		public bool ResolveIdentities(cDataFiles Datafiles)
			{
			bool fChanged = false;

			foreach (cTransaction Transaction in this)
				fChanged = Transaction.ResolveIdentities(Datafiles) ? true : fChanged;

			return (fChanged);
			}
		}
	}
