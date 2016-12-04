//============================================================================*
// cChargeTest.cs
//
// Copyright © 2013-2017, Kevin S. Beebe
// All Rights Reserved
//============================================================================*

//============================================================================*
// .Net Using Statements
//============================================================================*

using System;
using System.Xml;

//============================================================================*
// NameSpace
//============================================================================*

namespace ReloadersWorkShop
	{
	//============================================================================*
	// cChargeTest class
	//============================================================================*

	[Serializable]
	public partial class cChargeTest
		{
		//----------------------------------------------------------------------------*
		// Private Data Members
		//----------------------------------------------------------------------------*

		private DateTime m_TestDate = DateTime.Today;
		private string m_strSource = "";
		private cFirearm m_Firearm = null;
		private double m_dBarrelLength = 0.0;
		private double m_dTwist = 0.0;
		private int m_nMuzzleVelocity = 0;
		private int m_nPressure = 0;
		private double m_dBestGroup = 0.0;
		private double m_dBestGroupRange = 0;
		private string m_strNotes = "";
		private bool m_fBatchTest = false;
		private int m_nBatchID = 0;
		private double m_dPowderWeight = 0.0;

		//============================================================================*
		// cChargeTest() - Constructor
		//============================================================================*

		public cChargeTest()
			{
			}

		//============================================================================*
		// cChargeTest() - Copy Constructor
		//============================================================================*

		public cChargeTest(cChargeTest ChargeTest)
			{
			Copy(ChargeTest);
			}

		//============================================================================*
		// BarrelLength Property
		//============================================================================*

		public double BarrelLength
			{
			get
				{
				if (m_Firearm != null)
					return (m_Firearm.BarrelLength);

				return (m_dBarrelLength);
				}

			set
				{
				if (m_Firearm == null)
					m_dBarrelLength = value;
				}
			}

		//============================================================================*
		// BatchID Property
		//============================================================================*

		public int BatchID
			{
			get
				{
				return (m_nBatchID);
				}
			set
				{
				m_nBatchID = value;
				}
			}

		//============================================================================*
		// BatchTest Property
		//============================================================================*

		public bool BatchTest
			{
			get
				{
				return (m_fBatchTest);
				}
			set
				{
				m_fBatchTest = value;
				}
			}

		//============================================================================*
		// BestGroup Property
		//============================================================================*

		public double BestGroup
			{
			get
				{
				return (m_dBestGroup);
				}
			set
				{
				m_dBestGroup = value;
				}
			}

		//============================================================================*
		// BestGroupRange Property
		//============================================================================*

		public double BestGroupRange
			{
			get
				{
				return (m_dBestGroupRange);
				}
			set
				{
				m_dBestGroupRange = value;
				}
			}

		//============================================================================*
		// Comparer()
		//============================================================================*

		public static int Comparer(cChargeTest Test1, cChargeTest Test2)
			{
			if (Test1 == null)
				{
				if (Test2 != null)
					return (-1);
				else
					return (0);
				}
			else
				{
				if (Test2 == null)
					return (1);
				}

			return (Test1.CompareTo(Test2));
			}

		//============================================================================*
		// CompareTo()
		//============================================================================*

		public int CompareTo(cChargeTest ChargeTest)
			{
			if (ChargeTest == null)
				return (1);

			//----------------------------------------------------------------------------*
			// Date
			//----------------------------------------------------------------------------*

			int rc = m_TestDate.CompareTo(ChargeTest.m_TestDate);

			// Sort Latest to Oldest

			if (rc != 0)
				{
				return (rc < 0 ? 1 : -1);
				}

			//----------------------------------------------------------------------------*
			// Source
			//----------------------------------------------------------------------------*

			if (rc == 0)
				{
				rc = m_strSource.ToUpper().CompareTo(ChargeTest.m_strSource.ToUpper());

				//----------------------------------------------------------------------------*
				// Firearm
				//----------------------------------------------------------------------------*

				if (rc == 0)
					{
					if (m_Firearm != null)
						rc = m_Firearm.CompareTo(ChargeTest.m_Firearm);

					//----------------------------------------------------------------------------*
					// Barrel Length
					//----------------------------------------------------------------------------*

					if (rc == 0)
						{
						rc = m_dBarrelLength.CompareTo(ChargeTest.m_dBarrelLength);

						//----------------------------------------------------------------------------*
						// Twist
						//----------------------------------------------------------------------------*

						if (rc == 0)
							{
							rc = m_dTwist.CompareTo(ChargeTest.m_dTwist);

							//----------------------------------------------------------------------------*
							// Muzzle Velocity
							//----------------------------------------------------------------------------*

							if (rc == 0)
								{
								rc = m_nMuzzleVelocity.CompareTo(ChargeTest.m_nMuzzleVelocity);

								//----------------------------------------------------------------------------*
								// Pressure
								//----------------------------------------------------------------------------*

								if (rc == 0)
									{
									rc = m_nPressure.CompareTo(ChargeTest.m_nPressure);
									}
								}
							}
						}
					}
				}

			//----------------------------------------------------------------------------*
			// Return results
			//----------------------------------------------------------------------------*

			return (rc);
			}

		//============================================================================*
		// Copy() - BatchTest
		//============================================================================*

		public void Copy(cBatchTest BatchTest)
			{
			if (BatchTest != null)
				return;

			foreach (cCharge Charge in BatchTest.Batch.Load.ChargeList)
				{
				if (Charge.PowderWeight == BatchTest.Batch.PowderWeight)
					break;
				}

			m_dBarrelLength = BatchTest.Firearm.BarrelLength;
			m_dBestGroup = BatchTest.BestGroup;
			m_dBestGroupRange = BatchTest.BestGroupRange;
			m_Firearm = BatchTest.Firearm;
			m_nMuzzleVelocity = BatchTest.MuzzleVelocity;
			m_strNotes = BatchTest.Notes;
			m_nPressure = BatchTest.Pressure;
			m_TestDate = BatchTest.TestDate;
			m_dTwist = BatchTest.Firearm.Twist;
			m_dPowderWeight = BatchTest.Batch.PowderWeight;

			m_fBatchTest = true;

			if (BatchTest.Batch != null)
				{
				m_nBatchID = BatchTest.Batch.BatchID;

				m_strSource = String.Format("Batch #{0:G0} Testing", BatchTest.Batch.BatchID);
				}
			}

		//============================================================================*
		// Copy() - ChargeTest
		//============================================================================*

		public void Copy(cChargeTest ChargeTest)
			{
			m_TestDate = ChargeTest.m_TestDate;
			m_strSource = ChargeTest.m_strSource;

			m_Firearm = ChargeTest.m_Firearm;
			m_dBarrelLength = ChargeTest.m_dBarrelLength;
			m_dTwist = ChargeTest.m_dTwist;

			m_nMuzzleVelocity = ChargeTest.m_nMuzzleVelocity;
			m_nPressure = ChargeTest.m_nPressure;

			m_dBestGroup = ChargeTest.m_dBestGroup;
			m_dBestGroupRange = ChargeTest.m_dBestGroupRange;
			m_strNotes = ChargeTest.m_strNotes;

			m_fBatchTest = ChargeTest.m_fBatchTest;
			m_nBatchID = ChargeTest.m_nBatchID;

			m_dPowderWeight = ChargeTest.m_dPowderWeight;
			}

		//============================================================================*
		// Firearm Property
		//============================================================================*

		public cFirearm Firearm
			{
			get
				{
				return (m_Firearm);
				}

			set
				{
				m_Firearm = value;

				if (m_Firearm != null)
					{
					m_dBarrelLength = Firearm.BarrelLength;
					m_dTwist = Firearm.Twist;
					}
				}
			}

		//============================================================================*
		// MuzzleVelocity Property
		//============================================================================*

		public int MuzzleVelocity
			{
			get
				{
				return (m_nMuzzleVelocity);
				}
			set
				{
				m_nMuzzleVelocity = value;
				}
			}

		//============================================================================*
		// Notes Property
		//============================================================================*

		public string Notes
			{
			get
				{
				return (m_strNotes);
				}
			set
				{
				m_strNotes = value;
				}
			}

		//============================================================================*
		// PowderWeight Property
		//============================================================================*

		public double PowderWeight
			{
			get
				{
				return (m_dPowderWeight);
				}
			set
				{
				m_dPowderWeight = value;
				}
			}

		//============================================================================*
		// Pressure Property
		//============================================================================*

		public int Pressure
			{
			get
				{
				return (m_nPressure);
				}
			set
				{
				m_nPressure = value;
				}
			}

		//============================================================================*
		// ResolveIdentities()
		//============================================================================*

		public bool ResolveIdentities(cDataFiles DataFiles)
			{
			bool fChanged = false;

			if (m_Firearm.Identity)
				{
				foreach (cFirearm Firearm in DataFiles.FirearmList)
					{
					if (!Firearm.Identity && Firearm.CompareTo(m_Firearm) == 0)
						{
						m_Firearm = Firearm;

						fChanged = true;

						break;
						}
					}
				}

			return (fChanged);
			}

		//============================================================================*
		// Source Property
		//============================================================================*

		public string Source
			{
			get
				{
				return (m_strSource);
				}
			set
				{
				m_strSource = value;
				}
			}

		//============================================================================*
		// Synch() - Firearm
		//============================================================================*

		public bool Synch(cFirearm Firearm)
			{
			if (m_Firearm != null && m_Firearm.CompareTo(Firearm) == 0)
				{
				m_Firearm = Firearm;

				return (true);
				}

			return (false);
			}

		//============================================================================*
		// TestDate Property
		//============================================================================*

		public DateTime TestDate
			{
			get
				{
				return (m_TestDate);
				}
			set
				{
				m_TestDate = value;
				}
			}

		//============================================================================*
		// ToString
		//============================================================================*

		public override string ToString()
			{
			string strString = m_strSource;

			if (m_Firearm != null)
				strString += String.Format(", Bbl: {0:f1} Twist: {1:f1}", m_Firearm.BarrelLength, m_Firearm.Twist);
			else
				strString += String.Format(", Bbl: {0:f1} Twist: {1:f1}", m_dBarrelLength, m_dTwist);

			if (m_nMuzzleVelocity > 0)
				strString += String.Format(", Muzzle Vel.: {0:N0}", m_nMuzzleVelocity);

			if (m_nPressure > 0)
				strString += String.Format(", Pressure: {0:N0}", m_nPressure);

			return (strString);
			}

		//============================================================================*
		// Twist Property
		//============================================================================*

		public double Twist
			{
			get
				{
				if (m_Firearm != null)
					return (m_Firearm.Twist);

				return (m_dTwist);
				}

			set
				{
				if (m_Firearm == null)
					m_dTwist = value;
				}
			}

		//============================================================================*
		// Validate()
		//============================================================================*

		public bool Validate()
			{
			bool fOK = !String.IsNullOrEmpty(m_strSource);

			return (fOK);
			}
		}
	}
