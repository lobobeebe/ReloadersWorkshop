//============================================================================*
// cPrimerList.cs
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
	public class cPrimerList : List<cPrimer>
		{
		//============================================================================*
		// AddPrimer()
		//============================================================================*

		public bool AddPrimer(cPrimer Primer)
			{
			foreach (cPrimer CheckPrimer in this)
				{
				if (CheckPrimer.CompareTo(Primer) == 0)
					return(false);
				}

			Add(Primer);

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

				foreach (cPrimer Primer in this)
					{
					if (Primer.FirearmType == cFirearm.eFireArmType.Handgun)
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

				foreach (cPrimer Primer in this)
					{
					if (Primer.FirearmType == cFirearm.eFireArmType.Rifle)
						nCount++;
					}

				return (nCount);
				}
			}
		}
	}
