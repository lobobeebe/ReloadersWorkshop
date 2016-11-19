//============================================================================*
// cTestStatistics.cs
//
// Copyright © 2013-2014, Kevin S. Beebe
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
        private int m_nNumRounds;
        private double m_dAvg = 0.0;
		private int m_nMin = 0;
		private int m_nMax = 0;
		private double m_dVariance = 0.0;
		private double m_dStdDev = 0.0;

		//============================================================================*
		// cTestStatistics() - Constructor
		//============================================================================*

		public cTestStatistics()
			{
			}

		//============================================================================*
		// cTestStatistics() - Copy Constructor
		//============================================================================*

		public cTestStatistics(cTestStatistics TestStatistics)
			{
			m_nNumShots = TestStatistics.m_nNumShots;
            m_nNumRounds = TestStatistics.m_nNumRounds;
            m_dAvg = TestStatistics.m_dAvg;
			m_nMin = TestStatistics.m_nMin;
			m_nMax = TestStatistics.m_nMax;
			m_dVariance = TestStatistics.m_dVariance;
			m_dStdDev = TestStatistics.m_dStdDev;
			}

		//============================================================================*
		// AverageVelocity Property
		//============================================================================*

		public double AverageVelocity
			{
			get { return (m_dAvg); }
			set { m_dAvg = value; }
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
				return (m_nMax - m_nMin);
				}
			}

		//============================================================================*
		// MaxVelocity Property
		//============================================================================*

		public int MaxVelocity
			{
			get { return (m_nMax); }
			set { m_nMax = value; }
			}

		//============================================================================*
		// MinVelocity Property
		//============================================================================*

		public int MinVelocity
			{
			get { return (m_nMin); }
			set { m_nMin = value; }
			}

        //============================================================================*
        // NumRounds Property
        //============================================================================*

        public int NumRounds
            {
            get
                {
                return (m_nNumRounds);
                }
            set
                {
                m_nNumRounds = value;
                }
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
        // Population Property
        //============================================================================*

        public bool  Population
            {
            get
                {
                if (m_nNumShots == m_nNumRounds)
                    return (true);

                return (false);
                }
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
        // Summary Property
        //============================================================================*

        public bool Summary
            {
            get
                {
                if (m_nNumShots == m_nNumRounds)
                    return (false);

                return (true);
                }
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
