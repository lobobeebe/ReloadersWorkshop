//============================================================================*
// cAmmoTest.cs
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
	// cAmmoTest class
	//============================================================================*

	[Serializable]
	public class cAmmoTest
		{
		//----------------------------------------------------------------------------*
		// Private Data Members
		//----------------------------------------------------------------------------*

		// General Data

		private cAmmo m_Ammo = null;

		private DateTime m_TestDate = new DateTime(DateTime.Today.Ticks);

		private cFirearm m_Firearm = null;

		private double m_dBarrelLength = 0.0;
		private double m_dTwist = 0;
		private int m_nNumRounds = 0;
		private double m_dBestGroup = 0.0;
		private int m_nBestGroupRange = 0;
		private string m_strNotes;

		private int m_nMuzzleVelocity = 0;

		private cTestShotList m_TestShotList = new cTestShotList();

		//============================================================================*
		// cAmmoTest() - Constructor
		//============================================================================*

		public cAmmoTest()
			{
			}

		//============================================================================*
		// cAmmoTest() - Copy Constructor
		//============================================================================*

		public cAmmoTest(cAmmoTest AmmoTest)
			{
			m_Ammo = AmmoTest.m_Ammo;
			m_Firearm = AmmoTest.m_Firearm;

			m_TestDate = AmmoTest.m_TestDate;
			m_dBarrelLength = AmmoTest.m_dBarrelLength;
			m_dTwist = AmmoTest.m_dTwist;
			m_nNumRounds = AmmoTest.m_nNumRounds;
			m_nMuzzleVelocity = AmmoTest.m_nMuzzleVelocity;
			m_dBestGroup = AmmoTest.m_dBestGroup;
			m_nBestGroupRange = AmmoTest.m_nBestGroupRange;
			m_strNotes = AmmoTest.m_strNotes;

			m_TestShotList = new cTestShotList(AmmoTest.TestShotList);
			}

		//============================================================================*
		// Ammo Property
		//============================================================================*

		public cAmmo Ammo
			{
			get
				{
				return (m_Ammo);
				}
			set
				{
				m_Ammo = value;
				}
			}

		//============================================================================*
		// BarrelLength Property
		//============================================================================*

		public double BarrelLength
			{
			get { return (m_dBarrelLength); }
			set { m_dBarrelLength = value; }
			}

		//============================================================================*
		// BestGroup Property
		//============================================================================*

		public double BestGroup
			{
			get { return (m_dBestGroup); }
			set { m_dBestGroup = value; }
			}

		//============================================================================*
		// BestGroupRange Property
		//============================================================================*

		public int BestGroupRange
			{
			get { return (m_nBestGroupRange); }
			set { m_nBestGroupRange = value; }
			}

		//============================================================================*
		// Comparer()
		//============================================================================*

		public static int Comparer(cAmmoTest AmmoTest1, cAmmoTest AmmoTest2)
			{
			if (AmmoTest1 == null)
				{
				if (AmmoTest2 != null)
					return (-1);
				else
					return (0);
				}
			else
				{
				if (AmmoTest2 == null)
					return (1);
				}

			return (AmmoTest1.CompareTo(AmmoTest2));
			}

		//============================================================================*
		// CompareTo()
		//============================================================================*

		public int CompareTo(cAmmoTest AmmoTest)
			{
			if (AmmoTest == null)
				return (1);

			//----------------------------------------------------------------------------*
			// Firearm
			//----------------------------------------------------------------------------*

			int rc = 0;
			
			if (m_Firearm == null)
				{
				if (AmmoTest.Firearm != null)
					return(-1);
				else
					return(0);
				}
			else
				{
				if (AmmoTest.Firearm == null)
					return(1);
				else
					rc = m_Firearm.CompareTo(AmmoTest.m_Firearm);
				}

			//----------------------------------------------------------------------------*
			// NumRounds
			//----------------------------------------------------------------------------*

			if (rc == 0)
				{
				rc = m_nNumRounds.CompareTo(AmmoTest.m_nNumRounds);
				}

			return (rc);
			}

		//============================================================================*
		// Firearm Property
		//============================================================================*

		public cFirearm Firearm
			{
			get { return (m_Firearm); }
			set { m_Firearm = value; }
			}

		//============================================================================*
		// GetStatistics()
		//============================================================================*

		static public cTestStatistics GetStatistics(cTestShotList TestShotList)
			{
			cTestStatistics Statistics = new cTestStatistics();

			if (TestShotList == null)
				return (Statistics);

			int nTotalVelocity = 0;

			foreach (cTestShot TestShot in TestShotList)
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

				foreach (cTestShot TestShot in TestShotList)
					{
					if (TestShot.MuzzleVelocity > 0 && !TestShot.Misfire && !TestShot.Squib)
						Statistics.Variance += (((double)TestShot.MuzzleVelocity - Statistics.AverageVelocity) * ((double)TestShot.MuzzleVelocity - Statistics.AverageVelocity));
					}

				Statistics.Variance /= (double)Statistics.NumShots;

				Statistics.StdDev = Math.Sqrt(Statistics.Variance);
				}

			return (Statistics);
			}

		//============================================================================*
		// MuzzleVelocity Property
		//============================================================================*

		public int MuzzleVelocity
			{
			get
				{
				if (m_TestShotList.Count == 0)
					return (m_nMuzzleVelocity);

				int nTotal = 0;

				foreach (cTestShot TestShot in m_TestShotList)
					nTotal += TestShot.MuzzleVelocity;

				m_nMuzzleVelocity = nTotal / m_TestShotList.Count;

				return (m_nMuzzleVelocity);
				}

			set { m_nMuzzleVelocity = value; }
			}

		//============================================================================*
		// Notes Property
		//============================================================================*

		public string Notes
			{
			get { return (m_strNotes); }
			set { m_strNotes = value; }
			}

		//============================================================================*
		// NumRounds Property
		//============================================================================*

		public int NumRounds
			{
			get { return (m_nNumRounds); }
			set { m_nNumRounds = value; }
			}

		//============================================================================*
		// Pressure Property
		//============================================================================*

		public int Pressure
			{
			get
				{
				if (m_TestShotList.Count == 0)
					return (0);

				int nTotal = 0;

				foreach (cTestShot TestShot in m_TestShotList)
					nTotal += TestShot.Pressure;

				return (nTotal / m_TestShotList.Count);
				}
			}

		//============================================================================*
		// Synch() - AmmoTest
		//============================================================================*

		public void Synch(cAmmo CheckFactoryAmmo)
			{
			if (CheckFactoryAmmo != null && CheckFactoryAmmo.CompareTo(m_Ammo) == 0)
				m_Ammo = CheckFactoryAmmo;
			}

		//============================================================================*
		// TestDate Property
		//============================================================================*

		public DateTime TestDate
			{
			get { return (m_TestDate); }
			set { m_TestDate = value; }
			}

		//============================================================================*
		// TestShotList Property
		//============================================================================*

		public cTestShotList TestShotList
			{
			get { return (m_TestShotList); }
			set { m_TestShotList = value; }
			}

		//============================================================================*
		// ToString Property
		//============================================================================*

		public override string ToString()
			{
			string strString = String.Format("Firearm: {0}, {1} Rounds Tested", m_Firearm.ToString(), m_nNumRounds);

			return (strString);
			}

		//============================================================================*
		// Twist Property
		//============================================================================*

		public double Twist
			{
			get { return (m_dTwist); }
			set { m_dTwist = value; }
			}
		}
	}
