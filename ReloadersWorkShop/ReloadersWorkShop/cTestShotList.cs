//============================================================================*
// cTestShotList.cs
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
// NameSpace
//============================================================================*

namespace ReloadersWorkShop
	{
	//============================================================================*
	// cTestShotList Class
	//============================================================================*

	[Serializable]
	public class cTestShotList : List<cTestShot>
		{
		//============================================================================*
		// cTestShotList() - Constructor
		//============================================================================*

		public cTestShotList()
			{
			}

		//============================================================================*
		// cTestShotList() - Copy Constructor
		//============================================================================*

		public cTestShotList(cTestShotList TestShotList)
			{
			foreach (cTestShot TestShot in TestShotList)
				Add(new cTestShot(TestShot));
			}

		//============================================================================*
		// GetStatistics()
		//============================================================================*

		public cTestStatistics GetStatistics()
			{
			cTestStatistics Statistics = new cTestStatistics();

			int nTotalVelocity = 0;

			foreach (cTestShot TestShot in this)
				{
				if (TestShot.MuzzleVelocity > 0 && !TestShot.Misfire && !TestShot.Squib)
					{
					Statistics.NumShots++;
					nTotalVelocity += TestShot.MuzzleVelocity;

					if (Statistics.MinVelocity == 0 || TestShot.MuzzleVelocity < Statistics.MinVelocity)
						Statistics.MinVelocity = TestShot.MuzzleVelocity;

					if (Statistics.MaxVelocity == 0 || TestShot.MuzzleVelocity > Statistics.MaxVelocity)
						Statistics.MaxVelocity = TestShot.MuzzleVelocity;
					}
				}


			if (Statistics.NumShots > 0 && nTotalVelocity > 0)
				{
				Statistics.AverageVelocity = (double)nTotalVelocity / (double)Statistics.NumShots;

				foreach (cTestShot TestShot in this)
					{
					if (TestShot.MuzzleVelocity > 0 && !TestShot.Misfire && !TestShot.Squib)
						Statistics.Variance += (((double)TestShot.MuzzleVelocity - Statistics.AverageVelocity) * ((double)TestShot.MuzzleVelocity - Statistics.AverageVelocity));
					}

				Statistics.Variance /= (double)Statistics.NumShots;

				Statistics.StdDev = Math.Sqrt(Statistics.Variance);
				}

			return (Statistics);
			}
		}
	}
