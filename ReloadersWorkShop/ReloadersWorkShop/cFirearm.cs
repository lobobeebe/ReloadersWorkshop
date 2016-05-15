//============================================================================*
// cFirearm.cs
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
	// cFirearm class
	//============================================================================*

	[Serializable]
	public class cFirearm : IComparable
		{
		//============================================================================*
		// Public Enumerations
		//============================================================================*

		public enum eFireArmType
			{
			None = -1,
			Handgun = 0,
			Rifle,
			Shotgun
			}

		public enum eTurretType
			{
			MOA = 0,
			MilDot
			}

		//============================================================================*
		// Private Data Members
		//============================================================================*

		//----------------------------------------------------------------------------*
		// General
		//----------------------------------------------------------------------------*

		private eFireArmType m_eFirearmType = eFireArmType.Handgun;
		private cManufacturer m_Manufacturer = null;
		private string m_strModel = "";
		private string m_strSerialNumber = "";

		//----------------------------------------------------------------------------*
		// Specs
		//----------------------------------------------------------------------------*

		private int m_nZeroRange = 25;
		private double m_dBarrelLength = 0.0;
		private double m_dTwist = 1.0;
		private double m_dSightHeight = 0.8;

		private bool m_fScoped = false;
		private double m_dScopeClick = 0.25;
		private eTurretType m_eTurretType = eTurretType.MOA;

		private double m_dHeadSpace = 0.0;
		private double m_dNeck = 0.0;

		private cFirearmCaliberList m_FirearmCaliberList = new cFirearmCaliberList();

		private cFirearmBulletList m_FirearmBulletList = new cFirearmBulletList();

		//----------------------------------------------------------------------------*
		// Details
		//----------------------------------------------------------------------------*

		private string m_strImageFile = "";

		private string m_strSource = "";
		private DateTime m_PurchaseDate;
		private double m_dPrice;

		private string m_strReceiverFinish = "";
		private String m_strBarrelFinish = "";

		private string m_strType = "";
		private string m_strAction = "";
		private string m_strHammer = "";

		private cManufacturer m_ScopeManufacturer = null;
		private string m_strScopeModel = "";
		private string m_strScopePower = "";
		private int m_nScopeObjective = 0;

		private cManufacturer m_StockManufacturer = null;
		private string m_strStockModel = "";
		private string m_strStockFinish = "";

		private string m_strMagazine = "";
		private int m_nCapacity = 1;

		private cManufacturer m_TriggerManufacturer = null;
		private string m_strTriggerModel = "";
		private double m_dTriggerPull = 0.0;

		private string m_strNotes = "";

		//----------------------------------------------------------------------------*
		// Miscellaneous
		//----------------------------------------------------------------------------*

		private bool m_fChecked = false;

		private bool m_fPrinted = false;


		//============================================================================*
		// cFirearm() - Constructor
		//============================================================================*

		public cFirearm()
			{
			}

		//============================================================================*
		// cFirearm() - Copy Constructor
		//============================================================================*

		public cFirearm(cFirearm Firearm)
			{
			//----------------------------------------------------------------------------*
			// General
			//----------------------------------------------------------------------------*

			m_eFirearmType = Firearm.m_eFirearmType;
			m_Manufacturer = Firearm.m_Manufacturer;
			m_strModel = Firearm.m_strModel;
			m_strSerialNumber = Firearm.m_strSerialNumber;

			//----------------------------------------------------------------------------*
			// Specs
			//----------------------------------------------------------------------------*

			m_dBarrelLength = Firearm.m_dBarrelLength;

			m_fScoped = Firearm.m_fScoped;
			m_dTwist = Firearm.m_dTwist;
			m_eTurretType = Firearm.m_eTurretType;

			m_dSightHeight = Firearm.m_dSightHeight;
			m_dScopeClick = Firearm.m_dScopeClick;

			m_nZeroRange = Firearm.m_nZeroRange;

			m_dHeadSpace = Firearm.m_dHeadSpace;
			m_dNeck = Firearm.m_dNeck;

			m_FirearmCaliberList = new cFirearmCaliberList(Firearm.m_FirearmCaliberList);

			m_FirearmBulletList = new cFirearmBulletList(Firearm.m_FirearmBulletList);

			//----------------------------------------------------------------------------*
			// Details
			//----------------------------------------------------------------------------*

			m_strImageFile = Firearm.m_strImageFile;

			m_strSource = Firearm.m_strSource;

			m_PurchaseDate = Firearm.m_PurchaseDate;
			m_dPrice = Firearm.m_dPrice;

			m_strReceiverFinish = Firearm.m_strReceiverFinish;
			m_strBarrelFinish = Firearm.m_strBarrelFinish;

			m_strType = Firearm.m_strType;
			m_strAction = Firearm.m_strAction;
			m_strHammer = Firearm.m_strHammer;

			m_ScopeManufacturer = Firearm.m_ScopeManufacturer;
			m_strScopeModel = Firearm.m_strScopeModel;
			m_strScopePower = Firearm.m_strScopePower;
			m_nScopeObjective = Firearm.m_nScopeObjective;

			m_StockManufacturer = Firearm.m_StockManufacturer;
			m_strStockModel = Firearm.m_strStockModel;
			m_strStockFinish = Firearm.m_strStockFinish;

			m_strMagazine = Firearm.m_strMagazine;
			m_nCapacity = Firearm.m_nCapacity;

			m_TriggerManufacturer = Firearm.m_TriggerManufacturer;
			m_strTriggerModel = Firearm.m_strTriggerModel;
			m_dTriggerPull = Firearm.m_dTriggerPull;

			m_strNotes = Firearm.m_strNotes;
			}

		//============================================================================*
		// Action Property
		//============================================================================*

		public string Action
			{
			get
				{
				return (m_strAction);
				}
			set
				{
				m_strAction = value;
				}
			}

		//============================================================================*
		// AddCaliber()
		//============================================================================*

		public bool AddCaliber(cCaliber Caliber)
			{
			if (Caliber == null)
				return (false);

			bool fFound = false;

			foreach (cFirearmCaliber FirearmCaliber in m_FirearmCaliberList)
				{
				if (FirearmCaliber.Caliber.CompareTo(Caliber) == 0)
					{
					fFound = true;

					break;
					}
				}

			if (!fFound)
				{
				cFirearmCaliber FirearmCaliber = new cFirearmCaliber();

				FirearmCaliber.Caliber = Caliber;

				if (m_FirearmCaliberList.Count == 0)
					FirearmCaliber.Primary = true;

				m_FirearmCaliberList.Add(FirearmCaliber);

				return (true);
				}

			return (false);
			}

		//============================================================================*
		// BarrelFinish Property
		//============================================================================*

		public string BarrelFinish
			{
			get
				{
				return (m_strBarrelFinish);
				}
			set
				{
				m_strBarrelFinish = value;
				}
			}

		//============================================================================*
		// BarrelLength Property
		//============================================================================*

		public double BarrelLength
			{
			get
				{
				return (m_dBarrelLength);
				}
			set
				{
				m_dBarrelLength = value;
				}
			}

		//============================================================================*
		// CaliberList Property
		//============================================================================*

		public cFirearmCaliberList CaliberList
			{
			get
				{
				return (m_FirearmCaliberList);
				}

			set
				{
				m_FirearmCaliberList = value;
				}
			}

		//============================================================================*
		// CanUseBullet()
		//============================================================================*

		public bool CanUseBullet(cBullet Bullet)
			{
			if (Bullet != null)
				{
				foreach (cFirearmCaliber FirearmCaliber in m_FirearmCaliberList)
					{
					if (Bullet.HasCaliber(FirearmCaliber.Caliber))
						return (true);
					}
				}

			return (false);
			}

		//============================================================================*
		// Capacity Property
		//============================================================================*

		public int Capacity
			{
			get
				{
				return (m_nCapacity);
				}
			set
				{
				m_nCapacity = value;
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
		// Comparer()
		//============================================================================*

		public static int Comparer(cFirearm Firearm1, cFirearm Firearm2)
			{
			if (Firearm1 == null)
				{
				if (Firearm2 != null)
					return (-1);
				else
					return (0);
				}
			else
				{
				if (Firearm2 == null)
					return (1);
				}

			return (Firearm1.CompareTo(Firearm2));
			}

		//============================================================================*
		// CompareTo()
		//============================================================================*

		public int CompareTo(Object obj)
			{
			if (obj == null)
				return (1);

			cFirearm Firearm = (cFirearm) obj;

			//----------------------------------------------------------------------------*
			// Firearm Type
			//----------------------------------------------------------------------------*

			int rc = m_eFirearmType.CompareTo(Firearm.m_eFirearmType);

			//----------------------------------------------------------------------------*
			// Manufacturer
			//----------------------------------------------------------------------------*

			if (rc == 0)
				{
				rc = m_Manufacturer.CompareTo(Firearm.m_Manufacturer);

				//----------------------------------------------------------------------------*
				// Model
				//----------------------------------------------------------------------------*

				if (rc == 0)
					{
					rc = m_strModel.ToUpper().CompareTo(Firearm.m_strModel.ToUpper());

					//----------------------------------------------------------------------------*
					// Serial Number
					//----------------------------------------------------------------------------*

					if (rc == 0)
						{
						if (m_strSerialNumber != null)
							rc = m_strSerialNumber.CompareTo(Firearm.m_strSerialNumber);
						}
					}
				}

			return (rc);
			}

		//============================================================================*
		// FirearmBulletList Property
		//============================================================================*

		public cFirearmBulletList FirearmBulletList
			{
			get
				{
				return (m_FirearmBulletList);
				}
			set
				{
				m_FirearmBulletList = value;
				}
			}

		//============================================================================*
		// FirearmType Property
		//============================================================================*

		public eFireArmType FirearmType
			{
			get
				{
				return (m_eFirearmType);
				}
			set
				{
				m_eFirearmType = value;
				}
			}

		//============================================================================*
		// FirearmTypeString()
		//============================================================================*

		public static string FirearmTypeString(cFirearm.eFireArmType eFirearmType)
			{
			switch (eFirearmType)
				{
				case cFirearm.eFireArmType.Handgun:
					return ("Handgun");

				case cFirearm.eFireArmType.Rifle:
					return ("Rifle");

				case cFirearm.eFireArmType.Shotgun:
					return ("Shotgun");
				}

			return ("Unknown");
			}

		//============================================================================*
		// Hammer Property
		//============================================================================*

		public string Hammer
			{
			get
				{
				return (m_strHammer);
				}
			set
				{
				m_strHammer = value;
				}
			}

		//============================================================================*
		// HasBullet()
		//============================================================================*

		public bool HasBullet(cBullet Bullet, cCaliber Caliber)
			{
			if (Bullet == null || Caliber == null)
				return (false);

			foreach (cFirearmBullet CheckBullet in m_FirearmBulletList)
				{
				if (CheckBullet.Bullet.CompareTo(Bullet) == 0 && CheckBullet.Caliber.CompareTo(Caliber) == 0)
					return (true);
				}

			return (false);
			}

		//============================================================================*
		// HasCaliber()
		//============================================================================*

		public bool HasCaliber(cCaliber Caliber)
			{
			if (Caliber == null)
				return (false);

			if (m_FirearmCaliberList == null)
				m_FirearmCaliberList = new cFirearmCaliberList();

			foreach (cFirearmCaliber CheckFirearmCaliber in m_FirearmCaliberList)
				{
				if (CheckFirearmCaliber.Caliber.CompareTo(Caliber) == 0)
					return (true);
				}

			return (false);
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
				if (value >= 0.00)
					m_dHeadSpace = value;
				}
			}

		//============================================================================*
		// ImageFile Property
		//============================================================================*

		public string ImageFile
			{
			get
				{
				return (m_strImageFile);
				}
			set
				{
				m_strImageFile = value;
				}
			}

		//============================================================================*
		// ImageFilename Property
		//============================================================================*

		public string ImageFileName
			{
			get
				{
				if (Manufacturer == null || String.IsNullOrEmpty(m_strModel) || String.IsNullOrEmpty(m_strSerialNumber))
					return ("");

				string strFileName = String.Format("{0} {1} ({2})", Manufacturer.ToString(), m_strModel, m_strSerialNumber);

				return (strFileName);
				}
			}

		//============================================================================*
		// Magazine Property
		//============================================================================*

		public string Magazine
			{
			get
				{
				return (m_strMagazine);
				}
			set
				{
				m_strMagazine = value;
				}
			}

		//============================================================================*
		// MagazineCapacity Property
		//============================================================================*

		public int MagazineCapacity
			{
			get
				{
				return (m_nCapacity);
				}
			set
				{
				m_nCapacity = value;
				}
			}

		//============================================================================*
		// Manufacturer Property
		//============================================================================*

		public cManufacturer Manufacturer
			{
			get
				{
				return (m_Manufacturer);
				}
			set
				{
				m_Manufacturer = value;
				}
			}

		//============================================================================*
		// Model Property
		//============================================================================*

		public string Model
			{
			get
				{
				return (m_strModel);
				}
			set
				{
				m_strModel = value;
				}
			}

		//============================================================================*
		// Name()
		//============================================================================*

		public static string Name(eFireArmType FirearmType)
			{
			switch (FirearmType)
				{
				case eFireArmType.Handgun:
					return ("Handgun");

				case eFireArmType.Rifle:
					return ("Rifle");

				case eFireArmType.Shotgun:
					return ("Shotgun");
				}

			return ("Unknown");
			}

		//============================================================================*
		// Neck Property
		//============================================================================*

		public double Neck
			{
			get
				{
				return (m_dNeck);
				}

			set
				{
				if (value >= 0.00)
					m_dNeck = value;
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
		// Price Property
		//============================================================================*

		public double Price
			{
			get
				{
				return (m_dPrice);
				}

			set
				{
				if (value >= 0.00)
					m_dPrice = value;
				}
			}

		//============================================================================*
		// PrimaryCaliber Property
		//============================================================================*

		public cCaliber PrimaryCaliber
			{
			get
				{
				cCaliber Caliber = null;

				if (m_FirearmCaliberList == null)
					m_FirearmCaliberList = new cFirearmCaliberList();

				foreach (cFirearmCaliber FirearmCaliber in m_FirearmCaliberList)
					{
					if (FirearmCaliber.Primary)
						{
						Caliber = FirearmCaliber.Caliber;

						break;
						}
					}

				return (Caliber);
				}

			set
				{
				cCaliber Caliber = value;

				foreach (cFirearmCaliber FirearmCaliber in m_FirearmCaliberList)
					{
					if (FirearmCaliber.Caliber.CompareTo(Caliber) == 0)
						FirearmCaliber.Primary = true;
					else
						FirearmCaliber.Primary = false;
					}
				}
			}

		//============================================================================*
		// Printed Property
		//============================================================================*

		public bool Printed
			{
			get
				{
				return (m_fPrinted);
				}
			set
				{
				m_fPrinted = value;
				}
			}

		//============================================================================*
		// PurchaseDate Property
		//============================================================================*

		public DateTime PurchaseDate
			{
			get
				{
				return (m_PurchaseDate);
				}

			set
				{
				m_PurchaseDate = value;
				}
			}

		//============================================================================*
		// ReceiverFinish Property
		//============================================================================*

		public string ReceiverFinish
			{
			get
				{
				return (m_strReceiverFinish);
				}
			set
				{
				m_strReceiverFinish = value;
				}
			}

		//============================================================================*
		// RemoveCaliber()
		//============================================================================*

		public void RemoveCaliber(cFirearmCaliber FirearmCaliber)
			{
			if (FirearmCaliber == null)
				return;

			cCaliber Caliber = FirearmCaliber.Caliber;

			//----------------------------------------------------------------------------*
			// Remove the caliber
			//----------------------------------------------------------------------------*

			m_FirearmCaliberList.Remove(FirearmCaliber);

			//----------------------------------------------------------------------------*
			// If it was the primary, pick a new one
			//----------------------------------------------------------------------------*

			bool fPrimaryFound = false;

			foreach (cFirearmCaliber CheckCaliber in m_FirearmCaliberList)
				{
				if (CheckCaliber.Primary)
					{
					fPrimaryFound = true;

					break;
					}
				}

			if (!fPrimaryFound)
				{
				if (m_FirearmCaliberList.Count > 0)
					m_FirearmCaliberList[0].Primary = true;
				}

			//----------------------------------------------------------------------------*
			// Remove firearm bullets that match the removed caliber
			//----------------------------------------------------------------------------*

			while (true)
				{
				bool fRemoved = false;

				foreach (cFirearmBullet CheckBullet in m_FirearmBulletList)
					{
					if (CheckBullet.Caliber.CompareTo(Caliber) == 0)
						{
						m_FirearmBulletList.Remove(CheckBullet);

						fRemoved = true;

						break;
						}
					}

				if (!fRemoved)
					break;
				}
			}

		//============================================================================*
		// ScopeClick Property
		//============================================================================*

		public double ScopeClick
			{
			get
				{
				return (m_dScopeClick);
				}
			set
				{
				m_dScopeClick = value;
				}
			}

		//============================================================================*
		// ScopeManufacturer Property
		//============================================================================*

		public cManufacturer ScopeManufacturer
			{
			get
				{
				return (m_ScopeManufacturer);
				}
			set
				{
				m_ScopeManufacturer = value;
				}
			}

		//============================================================================*
		// ScopeModel Property
		//============================================================================*

		public string ScopeModel
			{
			get
				{
				return (m_strScopeModel);
				}
			set
				{
				m_strScopeModel = value;
				}
			}

		//============================================================================*
		// ScopeObjective Property
		//============================================================================*

		public int ScopeObjective
			{
			get
				{
				return (m_nScopeObjective);
				}
			set
				{
				m_nScopeObjective = value;
				}
			}

		//============================================================================*
		// ScopePower Property
		//============================================================================*

		public string ScopePower
			{
			get
				{
				return (m_strScopePower);
				}
			set
				{
				m_strScopePower = value;
				}
			}

		//============================================================================*
		// Scoped Property
		//============================================================================*

		public bool Scoped
			{
			get
				{
				return (m_fScoped);
				}
			set
				{
				m_fScoped = value;
				}
			}

		//============================================================================*
		// SerialNumber Property
		//============================================================================*

		public string SerialNumber
			{
			get
				{
				return (m_strSerialNumber);
				}
			set
				{
				m_strSerialNumber = value;
				}
			}

		//============================================================================*
		// SightHeight Property
		//============================================================================*

		public double SightHeight
			{
			get
				{
				return (m_dSightHeight);
				}
			set
				{
				m_dSightHeight = value;
				}
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
		// StockFinish Property
		//============================================================================*

		public string StockFinish
			{
			get
				{
				return (m_strStockFinish);
				}
			set
				{
				m_strStockFinish = value;
				}
			}

		//============================================================================*
		// StockManufacturer Property
		//============================================================================*

		public cManufacturer StockManufacturer
			{
			get
				{
				return (m_StockManufacturer);
				}
			set
				{
				m_StockManufacturer = value;
				}
			}

		//============================================================================*
		// StockModel Property
		//============================================================================*

		public string StockModel
			{
			get
				{
				return (m_strStockModel);
				}
			set
				{
				m_strStockModel = value;
				}
			}

		//============================================================================*
		// Synch() - Bullet
		//============================================================================*

		public bool Synch(cBullet Bullet)
			{
			bool fFound = false;

			foreach (cFirearmBullet CheckFirearmBullet in m_FirearmBulletList)
				fFound = CheckFirearmBullet.Synch(Bullet);

			return (fFound);
			}

		//============================================================================*
		// Synch() - Caliber
		//============================================================================*

		public bool Synch(cCaliber Caliber)
			{
			if (m_FirearmCaliberList == null)
				m_FirearmCaliberList = new cFirearmCaliberList();

			foreach (cFirearmCaliber FirearmCaliber in m_FirearmCaliberList)
				{
				if (FirearmCaliber.Caliber != null && FirearmCaliber.Caliber.CompareTo(Caliber) == 0)
					{
					FirearmCaliber.Caliber = Caliber;

					return (true);
					}
				}

			return (false);
			}

		//============================================================================*
		// Synch() - Manufacturer
		//============================================================================*

		public bool Synch(cManufacturer Manufacturer)
			{
			bool fSynched = false;

			if (m_Manufacturer != null)
				{
				if (m_Manufacturer.CompareTo(Manufacturer) == 0)
					{
					m_Manufacturer = Manufacturer;

					fSynched = true;
					}

				if (m_ScopeManufacturer != null && m_ScopeManufacturer.CompareTo(Manufacturer) == 0)
					{
					m_ScopeManufacturer = Manufacturer;

					fSynched = true;
					}

				if (m_StockManufacturer != null && m_StockManufacturer.CompareTo(Manufacturer) == 0)
					{
					m_StockManufacturer = Manufacturer;

					fSynched = true;
					}


				if (m_TriggerManufacturer != null && m_TriggerManufacturer.CompareTo(Manufacturer) == 0)
					{
					m_TriggerManufacturer = Manufacturer;

					fSynched = true;
					}
				}

			return (fSynched);
			}

		//============================================================================*
		// ToString()
		//============================================================================*

		public override string ToString()
			{
			return (String.Format("{0} {1}", (m_Manufacturer != null) ? m_Manufacturer.Name : "", m_strModel));
			}

		//============================================================================*
		// ToLongString()
		//============================================================================*

		public string ToLongString()
			{
			return (String.Format("{0} {1} - {2}", m_Manufacturer.Name, m_strModel, PrimaryCaliber.ToString()));
			}

		//============================================================================*
		// TriggerManufacturer Property
		//============================================================================*

		public cManufacturer TriggerManufacturer
			{
			get
				{
				return (m_TriggerManufacturer);
				}
			set
				{
				m_TriggerManufacturer = value;
				}
			}

		//============================================================================*
		// TriggerModel Property
		//============================================================================*

		public string TriggerModel
			{
			get
				{
				return (m_strTriggerModel);
				}
			set
				{
				m_strTriggerModel = value;
				}
			}

		//============================================================================*
		// TriggerPull Property
		//============================================================================*

		public double TriggerPull
			{
			get
				{
				return (m_dTriggerPull);
				}
			set
				{
				m_dTriggerPull = value;
				}
			}

		//============================================================================*
		// TurretClickString Property
		//============================================================================*

		public string TurretClickString
			{
			get
				{
				if (m_fScoped)
					{
					switch (m_eTurretType)
						{
						case eTurretType.MOA:
							return (String.Format("{0:F3} MOA", m_dScopeClick));

						case eTurretType.MilDot:
							return (String.Format("{0:F3} Mil", m_dScopeClick));
						}
					}

				return ("-");
				}
			}

		//============================================================================*
		// TurretType Property
		//============================================================================*

		public eTurretType TurretType
			{
			get
				{
				return (m_eTurretType);
				}
			set
				{
				m_eTurretType = value;
				}
			}

		//============================================================================*
		// TurretTypeString Property
		//============================================================================*

		public string TurretTypeString
			{
			get
				{
				if (m_fScoped)
					{
					switch (m_eTurretType)
						{
						case eTurretType.MOA:
							return ("MOA");

						case eTurretType.MilDot:
							return ("Mil");
						}
					}

				return ("-");
				}
			}

		//============================================================================*
		// Twist Property
		//============================================================================*

		public double Twist
			{
			get
				{
				return (m_dTwist);
				}
			set
				{
				m_dTwist = value;
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
		// ZeroRange Property
		//============================================================================*

		public int ZeroRange
			{
			get
				{
				return (m_nZeroRange);
				}
			set
				{
				m_nZeroRange = value;
				}
			}
		}
	}
