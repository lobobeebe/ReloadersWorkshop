using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReloadersWorkShop
	{
	class cChargeTestComparer : IComparer<cChargeTest>
		{
		public int Compare(cChargeTest ChargeTest1, cChargeTest ChargeTest2)
			{
			if (ChargeTest1 == null)
				{
				if (ChargeTest2 == null)
					return (0);
				else
					return (-1);
				}
			else
				{
				if (ChargeTest2 == null)
					return (1);
				}

			return (ChargeTest1.CompareTo(ChargeTest2));
			}
		}
	}
