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
using System.Collections.Generic;

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
		}
	}
