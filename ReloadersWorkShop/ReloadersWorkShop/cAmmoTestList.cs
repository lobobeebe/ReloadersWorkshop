//============================================================================*
// cFactoryAmmoTestList.cs
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
	public class cAmmoTestList : List<cAmmoTest>
		{
		//============================================================================*
		// cFactoryAmmoTestList() - Default Constructor
		//============================================================================*

		public cAmmoTestList()
			{
			}

		//============================================================================*
		// cFactoryAmmoTestList() - Copy Constructor
		//============================================================================*

		public cAmmoTestList(cAmmoTestList FactoryAmmoTestList)
			{
			if (FactoryAmmoTestList == null)
				return;

			foreach (cAmmoTest FactoryAmmoTest in FactoryAmmoTestList)
				Add(new cAmmoTest(FactoryAmmoTest));
			}
		}
	}
