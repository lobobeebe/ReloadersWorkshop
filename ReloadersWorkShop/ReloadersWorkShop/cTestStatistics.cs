//============================================================================*
// cTestStatistics.cs
//
// Copyright © 2013-2017, Kevin S. Beebe
// All Rights Reserved
//============================================================================*

//============================================================================*
// .Net Using Statements
//============================================================================*

using System;

//============================================================================*
// NameSpace
//============================================================================*

namespace ReloadersWorkShop
	{
	//============================================================================*
	// cTestStatistics class
	//============================================================================*

	[Serializable]
	public class cTestStatistics
		{
		//----------------------------------------------------------------------------*
		// Private Data Members
		//----------------------------------------------------------------------------*

		private int m_nNumShots;
        private double m_dAverageVelocity = 0.0;
		private int m_nMinVelocity = 0;
		private int m_nMaxVelocity = 0;
		private double m_dVariance = 0.0;
		private double m_dStdDev = 0.0;

		//============================================================================*
		// cTestStatistics() - Default Constructor
		//============================================================================*

		public cTestStatistics()
			{
			}

		//============================================================================*
		// cTestStatistics() - From cTestShotList
		//============================================================================*

		public cTestStatistics(cTestShotList TestShotList)
			{
			Reset();

			if (TestShotList == null)
				return;

			int nTotalVelocity = 0;

			foreach (cTestShot TestShot in TestShotList)
				{
				if (TestShot.MuzzleVelocity > 0 && !TestShot.Misfire && !TestShot.Squib)
					{
					m_nNumShots++;
					nTotalVelocity += TestShot.MuzzleVelocity;

					if (m_nMinVelocity == 0 || TestShot.MuzzleVelocity < m_nMinVelocity)
						m_nMinVelocity = TestShot.MuzzleVelocity;

					if (m_nMaxVelocity == 0 || TestShot.MuzzleVelocity > m_nMaxVelocity)
						m_nMaxVelocity = TestShot.MuzzleVelocity;
					}
				}

			if (m_nNumShots > 0 && nTotalVelocity > 0)
				{
				m_dAverageVelocity = (double) nTotalVelocity / (double) m_nNumShots;

				foreach (cTestShot TestShot in TestShotList)
					{
					if (TestShot.MuzzleVelocity > 0 && !TestShot.Misfire && !TestShot.Squib)
						m_dVariance += (((double) TestShot.MuzzleVelocity - m_dAverageVelocity) * ((double) TestShot.MuzzleVelocity - m_dAverageVelocity));
					}

				m_dVariance /= (double) (m_nNumShots - 1);

				m_dStdDev = Math.Sqrt(m_dVariance);
				}
			}

		//============================================================================*
		// cTestStatistics() - Copy Constructor
		//============================================================================*

		public cTestStatistics(cTestStatistics TestStatistics)
			{
			m_nNumShots = TestStatistics.m_nNumShots;
            m_dAverageVelocity = TestStatistics.m_dAverageVelocity;
			m_nMinVelocity = TestStatistics.m_nMinVelocity;
			m_nMaxVelocity = TestStatistics.m_nMaxVelocity;
			m_dVariance = TestStatistics.m_dVariance;
			m_dStdDev = TestStatistics.m_dStdDev;
			}

		//============================================================================*
		// AverageVelocity Property
		//============================================================================*

		public double AverageVelocity
			{
			get { return (m_dAverageVelocity); }
			set { m_dAverageVelocity = value; }
			}

		//============================================================================*
		// Comparer()
		//============================================================================*

		public static int Comparer(cTestStatistics Test1, cTestStatistics Test2)
			{
			if (Test1 == null)
				{
				if (Test2 != null)
					return (-1);
				else
					return (0);
				}

			return (Test1.CompareTo(Test2));
			}

		//============================================================================*
		// CompareTo()
		//============================================================================*

		public int CompareTo(cTestStatistics TestStatistics)
			{
			if (TestStatistics == null)
				return (1);

			// TODO: finish this up

			return (0);
			}

		//============================================================================*
		// MaxDeviation Property
		//============================================================================*

		public int MaxDeviation
			{
			get
				{
				return (m_nMaxVelocity - m_nMinVelocity);
				}
			}

		//============================================================================*
		// MaxVelocity Property
		//============================================================================*

		public int MaxVelocity
			{
			get { return (m_nMaxVelocity); }
			set { m_nMaxVelocity = value; }
			}

		//============================================================================*
		// MinVelocity Property
		//============================================================================*

		public int MinVelocity
			{
			get { return (m_nMinVelocity); }
			set { m_nMinVelocity = value; }
			}

        //============================================================================*
        // NumShots Property
        //============================================================================*

        public int NumShots
			{
			get { return (m_nNumShots); }
			set { m_nNumShots = value; }
			}

		//============================================================================*
		// Reset()
		//============================================================================*

		public void Reset()
			{
			m_nNumShots = 0;
			m_dAverageVelocity = 0.0;
			m_nMinVelocity = 0;
			m_nMaxVelocity = 0;
			m_dVariance = 0.0;
			m_dStdDev = 0.0;
			}

		//============================================================================*
		// StdDev Property
		//============================================================================*

		public double StdDev
			{
			get { return (m_dStdDev); }
			set { m_dStdDev = value; }
			}

        //============================================================================*
        // Variance Property
        //============================================================================*

        public double Variance
			{
			get { return (m_dVariance); }
			set { m_dVariance = value; }
			}
		}
	}
