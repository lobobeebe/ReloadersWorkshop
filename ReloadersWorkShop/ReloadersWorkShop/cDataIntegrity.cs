//============================================================================*
// cDataIntegrity.cs
//
// Copyright © 2017, Kevin S. Beebe
// All Rights Reserved
//============================================================================*

//============================================================================*
// .Net Using Statements
//============================================================================*

using System.Linq;

//============================================================================*
// Namespace
//============================================================================*

namespace ReloadersWorkShop
	{
	//============================================================================*
	// cDataIntegrity Class
	//============================================================================*

	public class cDataIntegrity
		{
		//============================================================================*
		// Private Data Members
		//============================================================================*

		private cDataFiles m_DataFiles = null;

		private int m_nNumBadManufacturers = 0;

		private int m_nNumBadCalibers = 0;

		private int m_nNumBadFirearms = 0;
		private int m_nNumFirearmCalibers = 0;
		private int m_nNumBadFirearmCalibers = 0;
		private int m_nNumFirearmBullets = 0;
		private int m_nNumBadFirearmBullets = 0;

		private int m_nNumBadAmmo = 0;
		private int m_nNumAmmoTests = 0;
		private int m_nNumBadAmmoTests = 0;

		private int m_nNumBadBullets = 0;
		private int m_nNumBulletCalibers = 0;
		private int m_nNumBadBulletCalibers = 0;

		private int m_nNumBadCases = 0;

		private int m_nNumBadPrimers = 0;

		private int m_nNumBadPowders = 0;

		private int m_nNumBadLoads = 0;
		private int m_nNumCharges = 0;
		private int m_nNumBadCharges = 0;
		private int m_nNumChargeTests = 0;
		private int m_nNumBadChargeTests = 0;

		private int m_nNumBadBatches = 0;
		private int m_nNumBatchTests = 0;
		private int m_nNumBadBatchTests = 0;

		private int m_nNumTestShots = 0;
		private int m_nNumBadTestShots = 0;

		private int m_nNumTransactions = 0;
		private int m_nNumBadTransactions = 0;

		//============================================================================*
		// cDataIntegrity() - Constructor
		//============================================================================*

		public cDataIntegrity(cDataFiles DataFiles)
			{
			m_DataFiles = DataFiles;

			ProcessAll();
			}

		//============================================================================*
		// NumBadAmmo Property
		//============================================================================*

		public int NumBadAmmo
			{
			get
				{
				return (m_nNumBadAmmo);
				}
			}

		//============================================================================*
		// NumBadAmmoTests Property
		//============================================================================*

		public int NumBadAmmoTests
			{
			get
				{
				return (m_nNumBadAmmoTests);
				}
			}

		//============================================================================*
		// NumBadBatches Property
		//============================================================================*

		public int NumBadBatches
			{
			get
				{
				return (m_nNumBadBatches);
				}
			}

		//============================================================================*
		// NumBadBatchTests Property
		//============================================================================*

		public int NumBadBatchTests
			{
			get
				{
				return (m_nNumBadBatchTests);
				}
			}

		//============================================================================*
		// NumBadBullets Property
		//============================================================================*

		public int NumBadBullets
			{
			get
				{
				return (m_nNumBadBullets);
				}
			}

		//============================================================================*
		// NumBadBulletCalibers Property
		//============================================================================*

		public int NumBadBulletCalibers
			{
			get
				{
				return (m_nNumBadBulletCalibers);
				}
			}

		//============================================================================*
		// NumBadCalibers Property
		//============================================================================*

		public int NumBadCalibers
			{
			get
				{
				return (m_nNumBadCalibers);
				}
			}

		//============================================================================*
		// NumBadCases Property
		//============================================================================*

		public int NumBadCases
			{
			get
				{
				return (m_nNumBadCases);
				}
			}

		//============================================================================*
		// NumBadCharges Property
		//============================================================================*

		public int NumBadCharges
			{
			get
				{
				return (m_nNumBadCharges);
				}
			}

		//============================================================================*
		// NumBadChargeTests Property
		//============================================================================*

		public int NumBadChargeTests
			{
			get
				{
				return (m_nNumBadChargeTests);
				}
			}

		//============================================================================*
		// NumBadFirearms Property
		//============================================================================*

		public int NumBadFirearms
			{
			get
				{
				return (m_nNumBadFirearms);
				}
			}

		//============================================================================*
		// NumBadFirearmBullets Property
		//============================================================================*

		public int NumBadFirearmBullets
			{
			get
				{
				return (m_nNumBadFirearmBullets);
				}
			}

		//============================================================================*
		// NumBadFirearmCalibers Property
		//============================================================================*

		public int NumBadFirearmCalibers
			{
			get
				{
				return (m_nNumBadFirearmCalibers);
				}
			}

		//============================================================================*
		// NumBadLoads Property
		//============================================================================*

		public int NumBadLoads
			{
			get
				{
				return (m_nNumBadLoads);
				}
			}

		//============================================================================*
		// NumBadManufacturers Property
		//============================================================================*

		public int NumBadManufacturers
			{
			get
				{
				return (m_nNumBadManufacturers);
				}
			}

		//============================================================================*
		// NumBadPowders Property
		//============================================================================*

		public int NumBadPowders
			{
			get
				{
				return (m_nNumBadPowders);
				}
			}

		//============================================================================*
		// NumBadPrimers Property
		//============================================================================*

		public int NumBadPrimers
			{
			get
				{
				return (m_nNumBadPrimers);
				}
			}

		//============================================================================*
		// NumBadTestShots Property
		//============================================================================*

		public int NumBadTestShots
			{
			get
				{
				return (m_nNumBadTestShots);
				}
			}

		//============================================================================*
		// NumBadTransactions Property
		//============================================================================*

		public int NumBadTransactions
			{
			get
				{
				return (m_nNumBadTransactions);
				}
			}

		//============================================================================*
		// NumAmmo Property
		//============================================================================*

		public int NumAmmo
			{
			get
				{
				return (m_DataFiles.AmmoList.Count);
				}
			}

		//============================================================================*
		// NumAmmoTests Property
		//============================================================================*

		public int NumAmmoTests
			{
			get
				{
				return (m_nNumAmmoTests);
				}
			}

		//============================================================================*
		// NumBatches Property
		//============================================================================*

		public int NumBatches
			{
			get
				{
				return (m_DataFiles.BatchList.Count);
				}
			}

		//============================================================================*
		// NumBatchTests Property
		//============================================================================*

		public int NumBatchTests
			{
			get
				{
				return (m_nNumBatchTests);
				}
			}

		//============================================================================*
		// NumBullets Property
		//============================================================================*

		public int NumBullets
			{
			get
				{
				return (m_DataFiles.BulletList.Count);
				}
			}

		//============================================================================*
		// NumBulletCalibers Property
		//============================================================================*

		public int NumBulletCalibers
			{
			get
				{
				return (m_nNumBulletCalibers);
				}
			}

		//============================================================================*
		// NumCalibers Property
		//============================================================================*

		public int NumCalibers
			{
			get
				{
				return (m_DataFiles.CaliberList.Count);
				}
			}

		//============================================================================*
		// NumCases Property
		//============================================================================*

		public int NumCases
			{
			get
				{
				return (m_DataFiles.CaseList.Count);
				}
			}

		//============================================================================*
		// NumCharges Property
		//============================================================================*

		public int NumCharges
			{
			get
				{
				return (m_nNumCharges);
				}
			}

		//============================================================================*
		// NumChargeTests Property
		//============================================================================*

		public int NumChargeTests
			{
			get
				{
				return (m_nNumChargeTests);
				}
			}

		//============================================================================*
		// NumFirearms Property
		//============================================================================*

		public int NumFirearms
			{
			get
				{
				return (m_DataFiles.FirearmList.Count);
				}
			}

		//============================================================================*
		// NumFirearmBullets Property
		//============================================================================*

		public int NumFirearmBullets
			{
			get
				{
				return (m_nNumFirearmBullets);
				}
			}

		//============================================================================*
		// NumFirearmCalibers Property
		//============================================================================*

		public int NumFirearmCalibers
			{
			get
				{
				return (m_nNumFirearmCalibers);
				}
			}

		//============================================================================*
		// NumLoads Property
		//============================================================================*

		public int NumLoads
			{
			get
				{
				return (m_DataFiles.LoadList.Count);
				}
			}

		//============================================================================*
		// NumManufacturers Property
		//============================================================================*

		public int NumManufacturers
			{
			get
				{
				return (m_DataFiles.ManufacturerList.Count);
				}
			}

		//============================================================================*
		// NumPowders Property
		//============================================================================*

		public int NumPowders
			{
			get
				{
				return (m_DataFiles.PowderList.Count);
				}
			}

		//============================================================================*
		// NumPrimers Property
		//============================================================================*

		public int NumPrimers
			{
			get
				{
				return (m_DataFiles.PrimerList.Count);
				}
			}

		//============================================================================*
		// NumTestShots Property
		//============================================================================*

		public int NumTestShots
			{
			get
				{
				return (m_nNumTestShots);
				}
			}

		//============================================================================*
		// NumTransactions Property
		//============================================================================*

		public int NumTransactions
			{
			get
				{
				return (m_nNumTransactions);
				}
			}

		//============================================================================*
		// ProcessAll()
		//============================================================================*

		public void ProcessAll()
			{
			ProcessManufacturers();
			ProcessCalibers();
			ProcessFirearms();
			ProcessAmmo();
			ProcessBullets();
			ProcessCases();
			ProcessPowders();
			ProcessPrimers();
			ProcessLoads();
			ProcessBatches();
			}

		//============================================================================*
		// ProcessAmmo()
		//============================================================================*

		public void ProcessAmmo()
			{
			m_nNumBadAmmo = 0;
			m_nNumAmmoTests = 0;
			m_nNumBadAmmoTests = 0;

			foreach (cAmmo Ammo in m_DataFiles.AmmoList)
				{
				if (!Ammo.Validate())
					m_nNumBadAmmo++;

				ProcessTransactionList(Ammo);

				m_nNumAmmoTests += Ammo.TestList.Count();

				bool fFirearmFound = false;

				foreach (cAmmoTest AmmoTest in Ammo.TestList)
					{
					if (!AmmoTest.Validate())
						m_nNumBadAmmoTests++;

					if (Ammo.CompareTo(AmmoTest.Ammo) != 0)
						m_nNumBadAmmoTests++;

					if (AmmoTest.Firearm != null)
						{
						foreach (cFirearm firearm in m_DataFiles.FirearmList)
							{
							if (firearm.CompareTo(AmmoTest.Firearm) == 0)
								{
								fFirearmFound = true;

								break;
								}
							}

						if (!fFirearmFound)
							m_nNumBadAmmoTests++;
						}

					m_nNumTestShots += AmmoTest.TestShotList.Count;

					foreach (cTestShot TestShot in AmmoTest.TestShotList)
						{
						if (!TestShot.Validate())
							m_nNumBadTestShots++;
						}
					}
				}
			}

		//============================================================================*
		// ProcessBatches()
		//============================================================================*

		public void ProcessBatches()
			{
			m_nNumBadBatches = 0;
			m_nNumBatchTests = 0;
			m_nNumBadBatchTests = 0;

			foreach (cBatch Batch in m_DataFiles.BatchList)
				{
				if (!Batch.Validate())
					m_nNumBadBatches++;

				if (Batch.BatchTest != null)
					{
					m_nNumBatchTests++;

					if (!Batch.BatchTest.Validate())
						m_nNumBadBatchTests++;

					m_nNumTestShots += Batch.BatchTest.TestShotList.Count;

					foreach (cTestShot TestShot in Batch.BatchTest.TestShotList)
						{
						if (!TestShot.Validate())
							m_nNumBadTestShots++;
						}
					}
				}
			}

		//============================================================================*
		// ProcessBullets()
		//============================================================================*

		public void ProcessBullets()
			{
			m_nNumBadBullets = 0;
			m_nNumBulletCalibers = 0;
			m_nNumBadBulletCalibers = 0;

			foreach (cBullet Bullet in m_DataFiles.BulletList)
				{
				if (!Bullet.Validate())
					m_nNumBadBullets++;

				m_nNumBulletCalibers += Bullet.BulletCaliberList.Count;

				foreach (cBulletCaliber BulletCaliber in Bullet.BulletCaliberList)
					{
					if (!BulletCaliber.Validate())
						m_nNumBadBulletCalibers++;
					}

				ProcessTransactionList(Bullet);
				}
			}

		//============================================================================*
		// ProcessCalibers()
		//============================================================================*

		public void ProcessCalibers()
			{
			m_nNumBadCalibers = 0;

			foreach (cCaliber Caliber in m_DataFiles.CaliberList)
				{
				if (!Caliber.Validate())
					m_nNumBadCalibers++;
				}
			}

		//============================================================================*
		// ProcessCases()
		//============================================================================*

		public void ProcessCases()
			{
			m_nNumBadCases = 0;

			foreach (cCase Case in m_DataFiles.CaseList)
				{
				if (!Case.Validate())
					m_nNumBadCases++;

				ProcessTransactionList(Case);

				ProcessTransactionList(Case);
				}
			}

		//============================================================================*
		// ProcessFirearms()
		//============================================================================*

		public void ProcessFirearms()
			{
			m_nNumBadFirearms = 0;
			m_nNumFirearmCalibers = 0;
			m_nNumBadFirearmCalibers = 0;
			m_nNumFirearmBullets = 0;
			m_nNumBadFirearmBullets = 0;

			foreach (cFirearm Firearm in m_DataFiles.FirearmList)
				{
				if (!Firearm.Validate())
					m_nNumBadFirearms++;

				m_nNumFirearmCalibers += Firearm.CaliberList.Count;

				foreach (cFirearmCaliber FirearmCaliber in Firearm.CaliberList)
					{
					if (!FirearmCaliber.Validate())
						m_nNumBadFirearmCalibers++;
					}

				m_nNumFirearmBullets += Firearm.FirearmBulletList.Count;

				foreach (cFirearmBullet FirearmBullet in Firearm.FirearmBulletList)
					{
					if (!FirearmBullet.Validate())
						m_nNumBadFirearmBullets++;
					}
				}
			}

		//============================================================================*
		// ProcessLoads()
		//============================================================================*

		public void ProcessLoads()
			{
			m_nNumBadLoads = 0;
			m_nNumCharges = 0;
			m_nNumBadCharges = 0;
			m_nNumChargeTests = 0;
			m_nNumBadChargeTests = 0;

			foreach (cLoad Load in m_DataFiles.LoadList)
				{
				if (!Load.Validate())
					m_nNumBadLoads++;

				m_nNumCharges += Load.ChargeList.Count;

				foreach (cCharge Charge in Load.ChargeList)
					{
					if (!Charge.Validate())
						m_nNumBadCharges++;

					m_nNumChargeTests += Charge.TestList.Count;

					foreach (cChargeTest ChargeTest in Charge.TestList)
						{
						if (!ChargeTest.Validate())
							m_nNumBadChargeTests++;
						}
					}
				}
			}

		//============================================================================*
		// ProcessManufacturers()
		//============================================================================*

		public void ProcessManufacturers()
			{
			m_nNumBadManufacturers = 0;

			foreach (cManufacturer Manufacturer in m_DataFiles.ManufacturerList)
				{
				if (!Manufacturer.Validate())
					m_nNumBadManufacturers++;
				}
			}

		//============================================================================*
		// ProcessPowders()
		//============================================================================*

		public void ProcessPowders()
			{
			m_nNumBadPowders = 0;

			foreach (cPowder Powder in m_DataFiles.PowderList)
				{
				if (!Powder.Validate())
					m_nNumBadPowders++;

				ProcessTransactionList(Powder);
				}
			}

		//============================================================================*
		// ProcessPrimers()
		//============================================================================*

		public void ProcessPrimers()
			{
			m_nNumBadPrimers = 0;

			foreach (cPrimer Primer in m_DataFiles.PrimerList)
				{
				if (!Primer.Validate())
					m_nNumBadPrimers++;

				ProcessTransactionList(Primer);
				}
			}

		//============================================================================*
		// ProcessTransactionList()
		//============================================================================*

		public void ProcessTransactionList(cSupply Supply)
			{
			m_nNumTransactions += Supply.TransactionList.Count();

			foreach (cTransaction Transaction in Supply.TransactionList)
				{
				if (!Transaction.Validate())
					m_nNumBadTransactions++;

				if (Transaction.Supply != null && Transaction.Supply.CompareTo(Supply) != 0)
					m_nNumBadTransactions++;
				}
			}
		}
	}
