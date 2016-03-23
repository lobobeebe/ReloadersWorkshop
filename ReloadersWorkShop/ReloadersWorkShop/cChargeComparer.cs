using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReloadersWorkShop
	{
	class cChargeComparer : IComparer<cCharge>
		{
		public int Compare(cCharge Charge1, cCharge Charge2)
			{
			if (Charge1 == null)
				{
				if (Charge2 == null)
					return (0);
				else
					return (-1);
				}
			else
				{
				if (Charge2 == null)
					return (1);
				}

			return(Charge1.CompareTo(Charge2));
			}
		}
	}
