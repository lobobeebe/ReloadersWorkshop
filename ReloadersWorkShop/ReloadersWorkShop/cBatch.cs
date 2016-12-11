//============================================================================*
// cBatch.cs
//
// Copyright © 2013-2014, Kevin S. Beebe
// All Rights Reserved
//============================================================================*

//============================================================================*
// .Net Using Statements
//============================================================================*

using System;
using System.IO;
using System.Xml;

//============================================================================*
// Application Specific Using Statements
//============================================================================*

using ReloadersWorkShop.Preferences;

//============================================================================*
// NameSpace
//============================================================================*

namespace ReloadersWorkShop
	{
	//============================================================================*
	// cBatch class
	//============================================================================*

	[Serializable]
	public partial class cBatch : IComparable
		{
		//============================================================================*
		// Private Data Members
		//============================================================================*

		//----------------------------------------------------------------------------*
		// General Data
		//----------------------------------------------------------------------------*

		private int m_nBatchID = 0;
		private string m_strUserID = "";

		private DateTime m_DateLoaded = DateTime.Today;

		private cLoad m_Load = null;
		private cFirearm m_Firearm = null;
		private double m_dPowderWeight = 0.0;

		private bool m_fTrackInventory = false;

		//----------------------------------------------------------------------------*
		// Batch Details
		//----------------------------------------------------------------------------*

		private int m_nNumRounds = 0;
		private int m_nTimesFired = 0;

		private double m_dCOL = 0.0;
		private double m_dCBTO = 0.0;
		private double m_dHeadSpace = 0.0;
		private double m_dNeckSize = 0.0;
		private double m_dNeckWall = 0.0;
		private double m_dCaseTrimLength = 0.0;
		private double m_dBulletDiameter = 0.0;

		private bool m_fFullLengthSized = false;
		private bool m_fNeckSized = false;
		private bool m_fExpandedNeck = false;

		private bool m_fNeckTurned = false;
		private bool m_fAnnealed = false;
		private bool m_fModifiedBullet = false;

		private bool m_fJumpSet = false;
		private double m_dJump = 0.0;

		private cBatchTestList m_BatchTestList = new cBatchTestList();

		//----------------------------------------------------------------------------*
		// Miscellaneous
		//----------------------------------------------------------------------------*

		private bool m_fArchive = false;
		private bool m_fChecked = false;
		private int m_nNumPrinted = 0;

		//============================================================================*
		// cBatch() - Constructor
		//============================================================================*

		public cBatch()
			{
			}

		//============================================================================*
		// cBatch() - Copy Constructor
		//============================================================================*

		public cBatch(cBatch Batch)
			{
			Copy(Batch);
			}

		//============================================================================*
		// Annealed Property
		//============================================================================*

		public bool Annealed
			{
			get
				{
				return (m_fAnnealed);
				}
			set
				{
				m_fAnnealed = value;
				}
			}

		//============================================================================*
		// Archived Property
		//============================================================================*

		public bool Archived
			{
			get
				{
				return (m_fArchive);
				}
			set
				{
				m_fArchive = value;
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
		// BatchCost Property
		//============================================================================*

		public double BatchCost
			{
			get
				{
				double dCost = 0.0;

				if (Load != null)
					{
					dCost += (Load.Bullet.CostEach * m_nNumRounds);
					dCost += (Load.Case.CostEach * m_nNumRounds);
					dCost += (Load.Primer.CostEach * m_nNumRounds);
					dCost += ((m_dPowderWeight * Load.Powder.CostEach) * m_nNumRounds);
					}

				return (dCost);
				}
			}

		//============================================================================*
		// BatchTest Property
		//============================================================================*

		public cBatchTest BatchTest
			{
			get
				{
				if (m_BatchTestList != null && m_BatchTestList.Count > 0)
					return (m_BatchTestList[0]);

				return (null);
				}
			set
				{
				if (m_BatchTestList == null)
					m_BatchTestList = new cBatchTestList();

				m_BatchTestList.Clear();

				if (value != null)
					m_BatchTestList.Add(value);
				}
			}

		//============================================================================*
		// BatchTestList Property
		//============================================================================*

		public cBatchTestList BatchTestList
			{
			get
				{
				if (m_BatchTestList == null)
					m_BatchTestList = new cBatchTestList();

				return (m_BatchTestList);
				}
			}

		//============================================================================*
		// BulletDiameter Property
		//============================================================================*

		public double BulletDiameter
			{
			get
				{
				return (m_dBulletDiameter);
				}
			set
				{
				m_dBulletDiameter = value;
				}
			}

		//============================================================================*
		// CartridgeCost Property
		//============================================================================*

		public double CartridgeCost
			{
			get
				{
				double dBulletCost = 0.0;
				double dCaseCost = 0.0;
				double dPowderCost = 0.0;
				double dPrimerCost = 0.0;

				if (Load != null && Load.Bullet != null)
					{
					dBulletCost = Load.Bullet.CostEach;

					dCaseCost = Load.Case.CostEach;

					if (m_nTimesFired > 0)
						dCaseCost = dCaseCost / (double) ((double) m_nTimesFired + 1.0);

					dPowderCost = Load.Powder.CostEach * (m_dPowderWeight / (cPreferences.StaticPreferences.MetricCanWeights ? 1000.0 : 7000.0));

					dPrimerCost = Load.Primer.CostEach;
					}

				return (dBulletCost + dCaseCost + dPowderCost + dPrimerCost);
				}
			}

		//============================================================================*
		// CaseTrimLength Property
		//============================================================================*

		public double CaseTrimLength
			{
			get
				{
				return (m_dCaseTrimLength);
				}
			set
				{
				m_dCaseTrimLength = value;
				}
			}

		//============================================================================*
		// CBTO Property
		//============================================================================*

		public double CBTO
			{
			get
				{
				return (m_dCBTO);
				}
			set
				{
				m_dCBTO = value;
				}
			}

		//============================================================================*
		// Checked Property
		//============================================================================*

		public bool Checked
			{
			get
				{
				return (m_fChecked);
				}
			set
				{
				m_fChecked = value;
				}
			}

		//============================================================================*
		// COL Property
		//============================================================================*

		public double COL
			{
			get
				{
				return (m_dCOL);
				}
			set
				{
				m_dCOL = value;
				}
			}

		//============================================================================*
		// Comparer()
		//============================================================================*

		public static int Comparer(cBatch Batch1, cBatch Batch2)
			{
			if (Batch1 == null)
				{
				if (Batch2 != null)
					return (-1);
				else
					return (0);
				}
			else
				{
				if (Batch2 == null)
					return (1);
				}

			return (Batch1.CompareTo(Batch2));
			}

		//============================================================================*
		// CompareTo()
		//============================================================================*

		public int CompareTo(Object obj)
			{
			if (obj == null)
				return (1);

			cBatch Batch = (cBatch) obj;

			//----------------------------------------------------------------------------*
			// Batch ID
			//----------------------------------------------------------------------------*

			return (m_nBatchID.CompareTo(Batch.m_nBatchID));
			}

		//============================================================================*
		// Copy()
		//============================================================================*

		public void Copy(cBatch Batch)
			{
			m_nBatchID = Batch.m_nBatchID;
			m_strUserID = Batch.m_strUserID;
			m_DateLoaded = new DateTime(Batch.DateLoaded.Ticks);
			m_dPowderWeight = Batch.m_dPowderWeight;
			m_nNumRounds = Batch.m_nNumRounds;
			m_nTimesFired = Batch.m_nTimesFired;
			m_dCOL = Batch.m_dCOL;
			m_dCBTO = Batch.m_dCBTO;
			m_dHeadSpace = Batch.m_dHeadSpace;
			m_dNeckSize = Batch.m_dNeckSize;
			m_dNeckWall = Batch.m_dNeckWall;
			m_dCaseTrimLength = Batch.m_dCaseTrimLength;
			m_dBulletDiameter = Batch.m_dBulletDiameter;

			m_fFullLengthSized = Batch.m_fFullLengthSized;
			m_fNeckSized = Batch.m_fNeckSized;
			m_fExpandedNeck = Batch.m_fExpandedNeck;

			m_fNeckTurned = Batch.m_fNeckTurned;
			m_fAnnealed = Batch.m_fAnnealed;
			m_fModifiedBullet = Batch.m_fModifiedBullet;

			m_fJumpSet = Batch.m_fJumpSet;
			m_dJump = Batch.m_dJump;

			m_Firearm = Batch.m_Firearm;

			m_Load = Batch.m_Load;

			m_BatchTestList = new cBatchTestList(Batch.BatchTestList);

			m_fArchive = Batch.m_fArchive;

			m_fTrackInventory = Batch.m_fTrackInventory;
			}

		//============================================================================*
		// Cost Property
		//============================================================================*

		public double Cost
			{
			get
				{
				return (CartridgeCost * m_nNumRounds);
				}
			}

		//============================================================================*
		// CSVLine Property
		//============================================================================*

		public string CSVLine
			{
			get
				{
				string strLine = "";

				strLine += m_nBatchID;
				strLine += ",";
				strLine += m_strUserID;
				strLine += ",";

				strLine += m_DateLoaded.ToShortDateString();
				strLine += ",";

				strLine += m_Load.Bullet.ToString();
				strLine += ",";
				strLine += m_Load.Powder.ToString();
				strLine += ",";
				strLine += m_Load.Primer.ToString();
				strLine += ",";
				strLine += m_Load.Case.ToString();
				strLine += ",";
				strLine += m_Firearm;
				strLine += ",";
				strLine += m_dPowderWeight;
				strLine += ",";

				strLine += m_nNumRounds;
				strLine += ",";
				strLine += m_nTimesFired;
				strLine += ",";

				strLine += m_dCOL;
				strLine += ",";
				strLine += m_dCBTO;
				strLine += ",";
				strLine += m_dHeadSpace;
				strLine += ",";
				strLine += m_dNeckSize;
				strLine += ",";
				strLine += m_dNeckWall;
				strLine += ",";
				strLine += m_dCaseTrimLength;
				strLine += ",";
				strLine += m_dBulletDiameter;
				strLine += ",";

				strLine += m_fFullLengthSized ? "Yes," : "-,";
				strLine += m_fNeckSized ? "Yes," : "-,";
				strLine += m_fExpandedNeck ? "Yes," : "-,";
				strLine += m_fNeckTurned ? "Yes," : "-,";
				strLine += m_fAnnealed ? "Yes," : "-,";
				strLine += m_fModifiedBullet ? "Yes," : "-,";

				strLine += m_fJumpSet ? "Yes," : "-,";
				strLine += m_dJump;
				strLine += ",";

				strLine += m_fArchive ? "Yes" : "-";

				return (strLine);
				}
			}

		//============================================================================*
		// CSVLineHeader Property
		//============================================================================*

		public static string CSVLineHeader
			{
			get
				{
				string strLine = "Batch ID,User Batch ID,Date Loaded,Bullet,Powder,Primer,Case,Firearm,Powder Weight,Num Rounds,Times Case Fired,COAL,CBTO,Headspace,Neck Size,Neck Wall,";
				strLine += "Case Trim Length,Bullet Diameter,Full-Length Sized,Neck Sized,Expanded Neck,Nect Turned,Annealed,Modified Bullet,Jumpset,Jump,Archived";

				return (strLine);
				}
			}

		//============================================================================*
		// DateLoaded Property
		//============================================================================*

		public DateTime DateLoaded
			{
			get
				{
				return (m_DateLoaded);
				}
			set
				{
				m_DateLoaded = value;
				}
			}

		//============================================================================*
		// ExpandedNeck Property
		//============================================================================*

		public bool ExpandedNeck
			{
			get
				{
				return (m_fExpandedNeck);
				}
			set
				{
				m_fExpandedNeck = value;
				}
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
				}
			}

		//============================================================================*
		// FullLengthSized Property
		//============================================================================*

		public bool FullLengthSized
			{
			get
				{
				return (m_fFullLengthSized);
				}
			set
				{
				m_fFullLengthSized = value;
				}
			}

		//============================================================================*
		// HeadSpace Property
		//============================================================================*

		public double HeadSpace
			{
			get
				{
				return (m_dHeadSpace);
				}
			set
				{
				m_dHeadSpace = value;
				}
			}

		//============================================================================*
		// Jump Property
		//============================================================================*

		public double Jump
			{
			get
				{
				return (m_dJump);
				}
			set
				{
				m_dJump = value;
				}
			}

		//============================================================================*
		// JumpSet Property
		//============================================================================*

		public bool JumpSet
			{
			get
				{
				return (m_fJumpSet);
				}
			set
				{
				m_fJumpSet = value;
				}
			}

		//============================================================================*
		// Load Property
		//============================================================================*

		public cLoad Load
			{
			get
				{
				return (m_Load);
				}
			set
				{
				m_Load = value;
				}
			}

		//============================================================================*
		// ModifiedBullet Property
		//============================================================================*

		public bool ModifiedBullet
			{
			get
				{
				return (m_fModifiedBullet);
				}
			set
				{
				m_fModifiedBullet = value;
				}
			}

		//============================================================================*
		// NeckSize Property
		//============================================================================*

		public double NeckSize
			{
			get
				{
				return (m_dNeckSize);
				}
			set
				{
				m_dNeckSize = value;
				}
			}

		//============================================================================*
		// NeckSized Property
		//============================================================================*

		public bool NeckSized
			{
			get
				{
				return (m_fNeckSized);
				}
			set
				{
				m_fNeckSized = value;
				}
			}

		//============================================================================*
		// NeckTurned Property
		//============================================================================*

		public bool NeckTurned
			{
			get
				{
				return (m_fNeckTurned);
				}
			set
				{
				m_fNeckTurned = value;
				}
			}

		//============================================================================*
		// NeckWall Property
		//============================================================================*

		public double NeckWall
			{
			get
				{
				return (m_dNeckWall);
				}
			set
				{
				m_dNeckWall = value;
				}
			}

		//============================================================================*
		// NumPrinted Property
		//============================================================================*

		public int NumPrinted
			{
			get
				{
				return (m_nNumPrinted);
				}
			set
				{
				m_nNumPrinted = value;
				}
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
		// ResolveIdentities()
		//============================================================================*

		public bool ResolveIdentities(cDataFiles DataFiles)
			{
			bool fChanged = false;

			if (m_Firearm != null && m_Firearm.Identity)
				{
				foreach (cFirearm Firearm in DataFiles.FirearmList)
					{
					if (!Firearm.Identity && m_Firearm.CompareTo(Firearm) == 0)
						{
						m_Firearm = Firearm;

						fChanged = true;

						break;
						}
					}
				}

			if (m_Load != null && m_Load.Identity)
				{
				foreach (cLoad Load in DataFiles.LoadList)
					{
					if (!Load.Identity && m_Load.CompareTo(Load) == 0)
						{
						m_Load = Load;

						fChanged = true;

						break;
						}
					}
				}

			return (fChanged);
			}

		//============================================================================*
		// Synch() - Batch
		//============================================================================*

		public bool Synch()
			{
			foreach(cBatchTest BatchTest in m_BatchTestList)
				BatchTest.Batch = this;

			return (true);
			}

		//============================================================================*
		// Synch() - Load
		//============================================================================*

		public bool Synch(cLoad Load)
			{
			if (m_Load != null && m_Load.CompareTo(Load) == 0)
				{
				m_Load = Load;

				return (true);
				}

			return (false);
			}

		//============================================================================*
		// TimesFired Property
		//============================================================================*

		public int TimesFired
			{
			get
				{
				return (m_nTimesFired);
				}
			set
				{
				m_nTimesFired = value;
				}
			}

		//============================================================================*
		// ToString()
		//============================================================================*

		public override string ToString()
			{
			string strLoadString = String.Format("Batch #{0:N0} - {1} Bullet with {2:F1} grs of {3} Powder", m_nBatchID, m_Load.Bullet.ToString(), m_dPowderWeight, m_Load.Powder.ToString());

			return (strLoadString);
			}

		//============================================================================*
		// TrackInventory Property
		//============================================================================*

		public bool TrackInventory
			{
			get
				{
				return (m_fTrackInventory);
				}
			set
				{
				m_fTrackInventory = value;
				}
			}

		//============================================================================*
		// UserID Property
		//============================================================================*

		public string UserID
			{
			get
				{
				return (m_strUserID);
				}
			set
				{
				m_strUserID = value;
				}
			}

		//============================================================================*
		// Validate()
		//============================================================================*

		public bool Validate()
			{
			bool fOK = m_Load != null && m_Load.Validate();

			fOK = m_dPowderWeight > 0.0;

			return (fOK);
			}
		}
	}
