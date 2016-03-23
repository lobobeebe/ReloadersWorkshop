//============================================================================*
// cPowderList.cs
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
	public class cPowderList : List<cPowder>
		{
		//============================================================================*
		// AddPowder()
		//============================================================================*

		public bool AddPowder(cPowder Powder)
			{
			foreach (cPowder CheckPowder in this)
				{
				if (CheckPowder.CompareTo(Powder) == 0)
					return(false);
				}

			Add(Powder);

			return(true);
			}

		//============================================================================*
		// HandgunCount Property
		//============================================================================*

		public int HandgunCount
			{
			get
				{
				int nCount = 0;

				foreach (cPowder Powder in this)
					{
					if (Powder.FirearmType == cFirearm.eFireArmType.Handgun)
						nCount++;
					}

				return (nCount);
				}
			}

		//============================================================================*
		// RecalulateInventory()
		//============================================================================*

		public void RecalulateInventory(cDataFiles DataFiles)
			{
			foreach (cSupply Supply in this)
				Supply.RecalculateInventory(DataFiles);
			}

		//============================================================================*
		// RifleCount Property
		//============================================================================*

		public int RifleCount
			{
			get
				{
				int nCount = 0;

				foreach (cPowder Powder in this)
					{
					if (Powder.FirearmType == cFirearm.eFireArmType.Rifle)
						nCount++;
					}

				return (nCount);
				}
			}
		}
	}
