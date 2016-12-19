//============================================================================*
// cAmmo.cs
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
	// cAmmo class
	//============================================================================*

	[Serializable]
	public partial class cAmmo : cSupply, IComparable
		{
		//============================================================================*
		// Private Data Members
		//============================================================================*

		private string m_strPartNumber = "";
		private string m_strType = "";

		private int m_nBatchID = 0;
		private bool m_fReload = false;

		private cCaliber m_Caliber = null;

		private double m_dBallisticCoefficient = 0.0;

		private double m_dBulletDiameter = 0.0;
		private double m_dBulletWeight = 0.0;

		private cAmmoTestList m_TestList = new cAmmoTestList();

		//============================================================================*
		// cAmmo() - Constructor
		//============================================================================*

		public cAmmo(bool fIdentity = false)
			: base(cSupply.eSupplyTypes.Ammo, fIdentity)
			{
			}

		//============================================================================*
		// cAmmo() - Batch Ammo Constructor
		//============================================================================*

		public cAmmo(cManufacturer BatchManufacturer, cBatch Batch)
			: base(cSupply.eSupplyTypes.Ammo)
			{
			FirearmType = Batch.Load.FirearmType;
			Manufacturer = BatchManufacturer;
			m_strPartNumber = String.Format("Batch {0:G0}", Batch.BatchID);
			m_strType = Batch.Load.Bullet.ToShortString();
			m_nBatchID = Batch.BatchID;
			m_Caliber = Batch.Load.Caliber;
			m_dBulletDiameter = Batch.Load.Bullet.Diameter;
			m_dBulletWeight = Batch.Load.Bullet.Weight;
			m_dBallisticCoefficient = Batch.Load.Bullet.BallisticCoefficient;
			m_fReload = true;
			}

		//============================================================================*
		// cAmmo() - Copy Constructor
		//============================================================================*

		public cAmmo(cAmmo Ammo)
				: base(Ammo)
			{
			Copy(Ammo);
			}

		//============================================================================*
		// Append()
		//============================================================================*

		public int Append(cAmmo Ammo)
			{
			int nUpdateCount = 0;

			if (m_dBallisticCoefficient == 0.0)
				{
				m_dBallisticCoefficient = Ammo.m_dBallisticCoefficient;

				nUpdateCount++;
				}

			if (m_dBulletDiameter == 0.0)
				{
				m_dBulletDiameter = Ammo.m_dBulletDiameter;

				nUpdateCount++;
				}

			if (m_dBulletWeight == 0.0)
				{
				m_dBulletWeight = Ammo.m_dBulletWeight;

				nUpdateCount++;
				}

			m_TestList.Append(Ammo.m_TestList);

			return (nUpdateCount);
			}

		//============================================================================*
		// Copy()
		//============================================================================*

		public void Copy(cAmmo Ammo)
			{
			m_strPartNumber = Ammo.m_strPartNumber;
			m_strType = Ammo.m_strType;
			m_nBatchID = Ammo.m_nBatchID;
			m_fReload = Ammo.m_fReload;

			m_Caliber = Ammo.m_Caliber;

			m_dBallisticCoefficient = Ammo.m_dBallisticCoefficient;
			m_dBulletDiameter = Ammo.m_dBulletDiameter;
			m_dBulletWeight = Ammo.m_dBulletWeight;

			m_TestList = new cAmmoTestList(Ammo.m_TestList);
			}

		//============================================================================*
		// BallisticCoefficient Property
		//============================================================================*

		public double BallisticCoefficient
			{
			get
				{
				return (m_dBallisticCoefficient);
				}
			set
				{
				m_dBallisticCoefficient = value;
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

				m_fReload = m_nBatchID != 0;
				}
			}

		//============================================================================*
		// BulletDiameter Property
		//============================================================================*

		public double BulletDiameter
			{
			get
				{
				if (m_Caliber != null)
					{
					if (m_dBulletDiameter < Caliber.MinBulletDiameter || m_dBulletDiameter > Caliber.MaxBulletDiameter)
						m_dBulletDiameter = m_Caliber.MinBulletDiameter;
					}

				return (m_dBulletDiameter);
				}

			set
				{
				m_dBulletDiameter = value;
				}
			}

		//============================================================================*
		// BulletWeight Property
		//============================================================================*

		public double BulletWeight
			{
			get
				{
				if (m_Caliber != null)
					{
					if (m_dBulletWeight < Caliber.MinBulletWeight || m_dBulletWeight > Caliber.MaxBulletWeight)
						m_dBulletWeight = m_Caliber.MinBulletWeight;
					}

				return (m_dBulletWeight);
				}

			set
				{
				m_dBulletWeight = value;
				}
			}

		//============================================================================*
		// Caliber Property
		//============================================================================*

		public cCaliber Caliber
			{
			get
				{
				return (m_Caliber);
				}
			set
				{
				m_Caliber = value;
				}
			}

		//============================================================================*
		// Comparer()
		//============================================================================*

		public static int Comparer(cAmmo Ammo1, cAmmo Ammo2)
			{
			if (Ammo1 == null)
				{
				if (Ammo2 != null)
					return (-1);
				else
					return (0);
				}
			else
				{
				if (Ammo2 == null)
					return (1);
				}

			return (Ammo1.CompareTo(Ammo2));
			}

		//============================================================================*
		// CompareTo()
		//============================================================================*

		public override int CompareTo(Object obj)
			{
			if (obj == null)
				return (1);

			//----------------------------------------------------------------------------*
			// Base Class
			//----------------------------------------------------------------------------*

			cSupply Supply = (cSupply) obj;

			int rc = base.CompareTo(Supply);

			//----------------------------------------------------------------------------*
			// PartNumber
			//----------------------------------------------------------------------------*

			if (rc == 0)
				{
				cAmmo Ammo = (cAmmo) Supply;

				rc = cDataFiles.ComparePartNumbers(m_strPartNumber, Ammo.m_strPartNumber);
				}

			return (rc);
			}

		//============================================================================*
		// PartNumber Property
		//============================================================================*

		public string PartNumber
			{
			get
				{
				return (m_strPartNumber);
				}
			set
				{
				m_strPartNumber = value;
				}
			}

		//============================================================================*
		// Reload Property
		//============================================================================*

		public bool Reload
			{
			get
				{
				return (m_fReload);
				}
			set
				{
				m_fReload = value;
				}
			}

		//============================================================================*
		// ResolveIdentities()
		//============================================================================*

		public override bool ResolveIdentities(cDataFiles DataFiles)
			{
			bool fChanged = base.ResolveIdentities(DataFiles);

			if (m_Caliber.Identity)
				{
				foreach (cCaliber Caliber in DataFiles.CaliberList)
					{
					if (!Caliber.Identity && Caliber.CompareTo(m_Caliber) == 0)
						{
						m_Caliber = Caliber;

						fChanged = true;

						break;
						}
					}
				}

			fChanged = m_TestList.ResolveIdentities(DataFiles) ? true : fChanged;

			return (fChanged);
			}

		//============================================================================*
		// Synch() - Caliber
		//============================================================================*

		public bool Synch(cCaliber Caliber)
			{
			if (Caliber != null && Caliber.CompareTo(m_Caliber) == 0)
				{
				m_Caliber = Caliber;

				return (true);
				}

			return (false);
			}

		//============================================================================*
		// Synch() - Firearm
		//============================================================================*

		public void Synch(cFirearm Firearm)
			{
			if (Firearm != null)
				{
				foreach (cAmmoTest AmmoTest in m_TestList)
					{
					if (Firearm.CompareTo(AmmoTest.Firearm) == 0)
						{
						AmmoTest.Firearm = Firearm;
						}
					}
				}
			}

		//============================================================================*
		// Synch() - Manufacturer
		//============================================================================*

		public override bool Synch(cManufacturer CheckManufacturer)
			{
			if ((Manufacturer == null || BatchID != 0) && CheckManufacturer.Name == "Batch Editor")
				{
				Manufacturer = CheckManufacturer;

				return (true);
				}

			if (Manufacturer.CompareTo(CheckManufacturer) == 0)
				{
				Manufacturer = CheckManufacturer;

				return (true);
				}

			return (false);
			}

		//============================================================================*
		// TestList Property
		//============================================================================*

		public cAmmoTestList TestList
			{
			get
				{
				return (m_TestList);
				}
			set
				{
				m_TestList = value;
				}
			}

		//============================================================================*
		// Type Property
		//============================================================================*

		public string Type
			{
			get
				{
				return (m_strType);
				}
			set
				{
				m_strType = value;
				}
			}

		//============================================================================*
		// ToShortString()
		//============================================================================*

		public string ToShortString()
			{
			if (m_nBatchID != 0)
				return (String.Format("{0} - {1}", m_strPartNumber, m_Caliber.HeadStamp));

			return (String.Format("{0} {1}, {2}", Manufacturer.Name, m_strPartNumber, m_Caliber.HeadStamp));
			}

		//============================================================================*
		// ToString()
		//============================================================================*

		public override string ToString()
			{
			if (m_nBatchID != 0)
				return (String.Format("{0} - {1}", m_strPartNumber, m_Caliber.ToString()));

			return (String.Format("{0} #{1}, {2} - {3}", Manufacturer != null ? Manufacturer.Name : "Batch Editor", m_strPartNumber, m_strType, m_Caliber.ToString()));
			}

		//============================================================================*
		// Validate()
		//============================================================================*

		public override bool Validate(bool fIdentityOK = false)
			{
			if (!base.Validate(fIdentityOK))
				return (false);

			if (m_Caliber == null || String.IsNullOrEmpty(m_strPartNumber) || String.IsNullOrEmpty(m_strType))
				return (false);

			if (fIdentityOK && Identity)
				return (true);

			if (Identity)
				return (false);

			if (m_dBulletDiameter <= 0.0 || m_dBulletWeight <= 0.0)
				return (false);

			return (true);
			}
		}
	}
