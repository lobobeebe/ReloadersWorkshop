//============================================================================*
// cFirearmBulletList.cs
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
// Namespace
//============================================================================*

namespace ReloadersWorkShop
	{
	//============================================================================*
	// cFirearmBulletList Class
	//============================================================================*

	[Serializable]
	public class cFirearmBulletList : List<cFirearmBullet>
		{
		//============================================================================*
		// cFirearmBulletList() - Constructor
		//============================================================================*

		public cFirearmBulletList()
			{
			}

		//============================================================================*
		// cFirearmBulletList() - Copy Constructor
		//============================================================================*

		public cFirearmBulletList(cFirearmBulletList FirearmBulletList)
			{
			Clear();

			if (FirearmBulletList == null)
				return;

			foreach (cFirearmBullet CheckFirearmBullet in FirearmBulletList)
				{
				cFirearmBullet FirearmBullet = new cFirearmBullet(CheckFirearmBullet);

				Add(FirearmBullet);
				}
			}
		}
	}
