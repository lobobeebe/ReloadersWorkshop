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
using System.Collections.Generic;

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
		}
	}
