//============================================================================*
// cFirearmCOLList.cs
//
// Copyright © 2013, Lobo Specialties LLC
// All Rights Reserved
//============================================================================*

//============================================================================*
// .Net Using Statements
//============================================================================*

using System;
using System.Collections.Generic;

//============================================================================*
// Namespace
//============================================================================*

namespace ReloadersWorkShop
	{
	//============================================================================*
	// cFirearmCOLList Class
	//============================================================================*

	[Serializable]
	public class cFirearmCOLList : List<cFirearmCOL>
		{
		//============================================================================*
		// cFirearmCOLList() - Constructor
		//============================================================================*

		public cFirearmCOLList()
			{
			}

		//============================================================================*
		// cFirearmCOLList() - Copy Constructor
		//============================================================================*

		public cFirearmCOLList(cFirearmCOLList FirearmCOLList)
			{
			Clear();

			if (FirearmCOLList == null)
				return;

			foreach (cFirearmCOL CheckFirearmCOL in FirearmCOLList)
				{
				cFirearmCOL FirearmCOL = new cFirearmCOL(CheckFirearmCOL);

				Add(FirearmCOL);
				}
			}
		}
	}
