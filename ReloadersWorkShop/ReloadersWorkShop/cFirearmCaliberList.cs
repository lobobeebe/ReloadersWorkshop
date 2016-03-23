//============================================================================*
// cFirearmCaliberList.cs
//
// Copyright © 2013-2015, Kevin S. Beebe
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
	// cFirearmCaliberList Class
	//============================================================================*

	[Serializable]
	public class cFirearmCaliberList : List<cFirearmCaliber>
		{
		//============================================================================*
		// cFirearmCaliberList() - Constructor
		//============================================================================*

		public cFirearmCaliberList()
			{
			}

		//============================================================================*
		// cFirearmCaliberList() - Copy Constructor
		//============================================================================*

		public cFirearmCaliberList(cFirearmCaliberList FirearmCaliberList)
			{
			Clear();

			if (FirearmCaliberList == null)
				return;

			foreach (cFirearmCaliber CheckFirearmCaliber in FirearmCaliberList)
				{
				cFirearmCaliber FirearmCaliber = new cFirearmCaliber(CheckFirearmCaliber);

				Add(FirearmCaliber);
				}
			}
		}
	}
