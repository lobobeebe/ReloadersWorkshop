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
		// AddTransaction()
		//============================================================================*

		public bool AddTransaction(cTransaction Transaction)
			{
			foreach (cTransaction CheckTransaction in this)
				{
				if (CheckTransaction.CompareTo(Transaction) == 0)
					return (false);
				}

			Add(Transaction);

			return (true);
			}

		//============================================================================*
		// Export()
		//============================================================================*

		public void Export(StreamWriter Writer,  cSupply Supply)
			{
			if (Count <= 0)
				return;

			string strLine = "";

			Writer.WriteLine("TransactionList");
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

		public void Export(cRWXMLDocument XMLDocument, XmlElement XMLParentElement)
			{
			if (Count > 0)
				{
				XmlElement XMLElement = XMLDocument.CreateElement(ExportName);
				XMLParentElement.AppendChild(XMLElement);

				foreach (cTransaction Transaction in this)
					Transaction.Export(XMLDocument, XMLElement);
				}
			}

		//============================================================================*
		// ExportName()
		//============================================================================*

		public static string ExportName
			{
			get
				{
				return ("TransactionList");
				}
			}

		//============================================================================*
		// Import()
		//============================================================================*

		public void Import(cRWXMLDocument XMLDocument, XmlNode XMLThisNode, cDataFiles DataFiles, cSupply Supply)
			{
			XmlNode XMLNode = XMLThisNode.FirstChild;

			while (XMLNode != null)
				{
				switch (XMLNode.Name)
					{
					case "Transaction":
						cTransaction Transaction = new cTransaction();

						Transaction.Import(XMLDocument, XMLNode, DataFiles);
						Transaction.Supply = Supply;

						AddTransaction(Transaction);

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

			foreach (cTransaction Transaction in this)
				fChanged = Transaction.ResolveIdentities(Datafiles) ? true : fChanged;

			return (fChanged);
			}
		}
	}
