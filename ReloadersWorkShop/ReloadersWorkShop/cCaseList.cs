//============================================================================*
// cCaseList.cs
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
	public class cCaseList : List<cCase>
		{
		//============================================================================*
		// AddCase()
		//============================================================================*

		public bool AddCase(cCase Case)
			{
			foreach (cCase CheckCase in this)
				{
				if (CheckCase.CompareTo(Case) == 0)
					return(false);
				}

			Add(Case);

			return (true);
			}

		//============================================================================*
		// HandgunCount Property
		//============================================================================*

		public int HandgunCount
			{
			get
				{
				int nCount = 0;

				foreach (cCase Case in this)
					{
					if (Case.FirearmType == cFirearm.eFireArmType.Handgun)
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

				foreach (cCase Case in this)
					{
					if (Case.FirearmType == cFirearm.eFireArmType.Rifle)
						nCount++;
					}

				return (nCount);
				}
			}
		}
	}
