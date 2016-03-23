//============================================================================*
// cBulletCaliberList.cs
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
	public class cBulletCaliberList : List<cBulletCaliber>
		{
		//============================================================================*
		// cBulletCaliberList() - Constructor
		//============================================================================*

		public cBulletCaliberList()
			{
			}

		//============================================================================*
		// cBulletCaliberList() - Copy Constructor
		//============================================================================*

		public cBulletCaliberList(cBulletCaliberList CaliberList)
			{
			if (CaliberList != null)
				{
				foreach (cBulletCaliber Caliber in CaliberList)
					{
					cBulletCaliber NewCaliber = new cBulletCaliber(Caliber);

					Add(NewCaliber);
					}
				}

			Sort(cBulletCaliber.Comparer);
			}
		}
	}
