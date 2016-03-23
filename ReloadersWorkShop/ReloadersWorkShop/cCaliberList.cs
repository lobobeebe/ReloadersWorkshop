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
using System.Runtime.Serialization.Formatters.Binary;

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
					return(false);
				}

			Add(Caliber);

			return(true);
			}
		}
	}

