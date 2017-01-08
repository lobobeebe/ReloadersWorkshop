//============================================================================*
// cFirearm.cs
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
	// cFirearm class
	//============================================================================*

	[Serializable]
	public partial class cFirearm : cGear, IComparable
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
		// Private Constant Data Members
		//============================================================================*

		private const string cm_strHandgun = "Handgun";
		private const string cm_strRifle = "Rifle";
		private const string cm_strShotgun = "Shotgun";

		//============================================================================*
		// Private Data Members
		//============================================================================*

		//----------------------------------------------------------------------------*
		// General
		//----------------------------------------------------------------------------*

		private eFireArmType m_eFirearmType = eFireArmType.Handgun;

		//----------------------------------------------------------------------------*
		// Specs
		//----------------------------------------------------------------------------*

		private double m_dZeroRange = 25.0;
		private double m_dBarrelLength = 0.0;
		private double m_dTwist = 1.0;
		private double m_dSightHeight = 0.8;

		private bool m_fScoped = false;
		private double m_dScopeClick = 0.25;
		private eTurretType m_eTurretType = eTurretType.MOA;

		private double m_dHeadSpace = 0.0;
		private double m_dNeck = 0.0;

		private double m_dTransferFees = 0.0;
		private double m_dOtherFees = 0.0;

		private cFirearmCaliberList m_FirearmCaliberList = new cFirearmCaliberList();

		private cFirearmBulletList m_FirearmBulletList = new cFirearmBulletList();

		//----------------------------------------------------------------------------*
		// Details
		//----------------------------------------------------------------------------*

		private string m_strImageFile = "";

		private string m_strReceiverFinish = "";
		private String m_strBarrelFinish = "";

		private string m_strType = "";
		private string m_strAction = "";
		private string m_strHammer = "";

		private string m_strMagazine = "";
		private int m_nCapacity = 1;

		//----------------------------------------------------------------------------*
		// Miscellaneous
		//----------------------------------------------------------------------------*

		private bool m_fChecked = false;

		//============================================================================*
		// cFirearm() - Constructor
		//============================================================================*

		public cFirearm(bool fIdentity = false)
			: base(cGear.eGearTypes.Firearm, fIdentity)
			{
			}

		//============================================================================*
		// cFirearm() - Copy Constructor
		//============================================================================*

		public cFirearm(cFirearm Firearm)
			: base(Firearm)
			{
			Copy(Firearm);
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
		// Append()
		//============================================================================*

		public int Append(cFirearm Firearm, bool fCountOnly = false)
			{
			int nUpdateCount = base.Append(Firearm);

			if (m_dBarrelLength == 0.0 && Firearm.m_dBarrelLength != 0.0)
				{
				if (!fCountOnly)
					m_dBarrelLength = Firearm.m_dBarrelLength;

				nUpdateCount++;
				}

			if (!m_fScoped && Firearm.m_fScoped)
				{
				if (!fCountOnly)
					m_fScoped = Firearm.m_fScoped;

				nUpdateCount++;
				}

			if (m_dTwist == 0.0 && Firearm.m_dTwist != 0.0)
				{
				if (!fCountOnly)
					m_dTwist = Firearm.m_dTwist;

				nUpdateCount++;
				}

			if (m_dSightHeight == 0.0 && Firearm.m_dSightHeight != 0.0)
				{
				if (!fCountOnly)
					m_dSightHeight = Firearm.m_dSightHeight;

				nUpdateCount++;
				}

			if (m_dScopeClick == 0.0 && Firearm.m_dScopeClick != 0.0)
				{
				if (!fCountOnly)
					m_dScopeClick = Firearm.m_dScopeClick;

				nUpdateCount++;
				}

			if (m_dZeroRange == 0.0 && Firearm.m_dZeroRange != 0.0)
				{
				if (!fCountOnly)
					m_dZeroRange = Firearm.m_dZeroRange;

				nUpdateCount++;
				}

			if (m_dHeadSpace == 0.0 && Firearm.m_dHeadSpace != 0.0)
				{
				if (!fCountOnly)
					m_dHeadSpace = Firearm.m_dHeadSpace;

				nUpdateCount++;
				}

			if (m_dNeck == 0.0 && Firearm.m_dNeck != 0.0)
				{
				if (!fCountOnly)
					m_dNeck = Firearm.m_dNeck;

				nUpdateCount++;
				}

			//----------------------------------------------------------------------------*
			// Details
			//----------------------------------------------------------------------------*

			if (String.IsNullOrEmpty(m_strImageFile) && !String.IsNullOrEmpty(Firearm.m_strImageFile))
				{
				if (!fCountOnly)
					m_strImageFile = Firearm.m_strImageFile;

				nUpdateCount++;
				}

			if (m_dTransferFees == 0.0 && Firearm.m_dTransferFees != 0.0)
				{
				if (!fCountOnly)
					m_dTransferFees = Firearm.m_dTransferFees;

				nUpdateCount++;
				}

			if (m_dOtherFees == 0.0 && Firearm.m_dOtherFees != 0.0)
				{
				if (!fCountOnly)
					m_dOtherFees = Firearm.m_dOtherFees;

				nUpdateCount++;
				}

			if (String.IsNullOrEmpty(m_strReceiverFinish) && !String.IsNullOrEmpty(Firearm.m_strReceiverFinish))
				{
				if (!fCountOnly)
					m_strReceiverFinish = Firearm.m_strReceiverFinish;

				nUpdateCount++;
				}

			if (String.IsNullOrEmpty(m_strBarrelFinish) && !String.IsNullOrEmpty(Firearm.m_strBarrelFinish))
				{
				if (!fCountOnly)
					m_strBarrelFinish = Firearm.m_strBarrelFinish;

				nUpdateCount++;
				}

			if (String.IsNullOrEmpty(m_strType) && !String.IsNullOrEmpty(Firearm.m_strType))
				{
				if (!fCountOnly)
					m_strType = Firearm.m_strType;

				nUpdateCount++;
				}

			if (String.IsNullOrEmpty(m_strAction) && !String.IsNullOrEmpty(Firearm.m_strAction))
				{
				if (!fCountOnly)
					m_strAction = Firearm.m_strAction;

				nUpdateCount++;
				}

			if (String.IsNullOrEmpty(m_strHammer) && !String.IsNullOrEmpty(Firearm.m_strHammer))
				{
				if (!fCountOnly)
					m_strHammer = Firearm.m_strHammer;

				nUpdateCount++;
				}

			if (String.IsNullOrEmpty(m_strMagazine) && !String.IsNullOrEmpty(Firearm.m_strMagazine))
				{
				if (!fCountOnly)
					m_strMagazine = Firearm.m_strMagazine;

				nUpdateCount++;
				}

			if (m_nCapacity == 0 && Firearm.m_nCapacity != 0)
				{
				if (!fCountOnly)
					m_nCapacity = Firearm.m_nCapacity;

				nUpdateCount++;
				}

			return (nUpdateCount);
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

		public override int CompareTo(Object obj)
			{
			if (obj == null)
				return (1);

			cFirearm Firearm = (cFirearm) obj;

			int rc = base.CompareTo(Firearm);

			//----------------------------------------------------------------------------*
			// Firearm Type
			//----------------------------------------------------------------------------*

			if (rc == 0)
				rc = m_eFirearmType.CompareTo(Firearm.m_eFirearmType);

			return (rc);
			}

		//============================================================================*
		// Copy()
		//============================================================================*

		public void Copy(cFirearm Firearm)
			{
			base.Copy(Firearm);

			//----------------------------------------------------------------------------*
			// General
			//----------------------------------------------------------------------------*

			m_eFirearmType = Firearm.m_eFirearmType;

			//----------------------------------------------------------------------------*
			// Specs
			//----------------------------------------------------------------------------*

			m_dBarrelLength = Firearm.m_dBarrelLength;

			m_fScoped = Firearm.m_fScoped;
			m_dTwist = Firearm.m_dTwist;
			m_eTurretType = Firearm.m_eTurretType;

			m_dSightHeight = Firearm.m_dSightHeight;
			m_dScopeClick = Firearm.m_dScopeClick;

			m_dZeroRange = Firearm.m_dZeroRange;

			m_dHeadSpace = Firearm.m_dHeadSpace;
			m_dNeck = Firearm.m_dNeck;

			m_FirearmCaliberList = new cFirearmCaliberList(Firearm.m_FirearmCaliberList);

			m_FirearmBulletList = new cFirearmBulletList(Firearm.m_FirearmBulletList);

			//----------------------------------------------------------------------------*
			// Details
			//----------------------------------------------------------------------------*

			m_strImageFile = Firearm.m_strImageFile;

			m_dTransferFees = Firearm.m_dTransferFees;
			m_dOtherFees = Firearm.m_dOtherFees;

			m_strReceiverFinish = Firearm.m_strReceiverFinish;
			m_strBarrelFinish = Firearm.m_strBarrelFinish;

			m_strType = Firearm.m_strType;
			m_strAction = Firearm.m_strAction;
			m_strHammer = Firearm.m_strHammer;

			m_strMagazine = Firearm.m_strMagazine;
			m_nCapacity = Firearm.m_nCapacity;
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

				SetDefaultDescription();
				}
			}

		//============================================================================*
		// FirearmTypeFromString()
		//============================================================================*

		public static cFirearm.eFireArmType FirearmTypeFromString(string strFirearmType)
			{
			switch (strFirearmType)
				{
				case cm_strHandgun:
					return (cFirearm.eFireArmType.Handgun);

				case cm_strRifle:
					return (cFirearm.eFireArmType.Rifle);

				case cm_strShotgun:
					return (cFirearm.eFireArmType.Shotgun);
				}

			return (cFirearm.eFireArmType.None);
			}

		//============================================================================*
		// FirearmTypeString()
		//============================================================================*

		public static string FirearmTypeString(cFirearm.eFireArmType eFirearmType)
			{
			switch (eFirearmType)
				{
				case cFirearm.eFireArmType.Handgun:
					return (cm_strHandgun);

				case cFirearm.eFireArmType.Rifle:
					return (cm_strRifle);

				case cFirearm.eFireArmType.Shotgun:
					return (cm_strShotgun);
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
				if (Manufacturer == null || String.IsNullOrEmpty(PartNumber) || String.IsNullOrEmpty(SerialNumber))
					return ("");

				string strFileName = String.Format("{0} {1} ({2})", Manufacturer.ToString(), PartNumber, SerialNumber);

				strFileName = strFileName.Replace('/', '-');
				strFileName = strFileName.Replace('\\', '-');
				strFileName = strFileName.Replace(':', '-');
				strFileName = strFileName.Replace('*', '-');
				strFileName = strFileName.Replace('?', '-');
				strFileName = strFileName.Replace('\"', '-');
				strFileName = strFileName.Replace('<', '-');
				strFileName = strFileName.Replace('>', '-');
				strFileName = strFileName.Replace('|', '-');
				strFileName = strFileName.Replace('.', ' ');

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
		// OtherFees Property
		//============================================================================*

		public double OtherFees
			{
			get
				{
				return (m_dOtherFees);
				}
			set
				{
				m_dOtherFees = value;
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
		// ResolveIdentities()
		//============================================================================*

		public override bool ResolveIdentities(cDataFiles Datafiles)
			{
			return (false);
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
		// SetDefaultDescription()
		//============================================================================*

		public override void SetDefaultDescription()
			{
			if (!String.IsNullOrEmpty(Description) &&
				Description != "Handgun" &&
				Description != "Pistol" &&
				Description != "Revolver" &&
				Description != "Rifle" &&
				Description != "Shotgun" &&
				Description != "Other Firearm Type")
				return;

			switch (m_eFirearmType)
				{
				case eFireArmType.Handgun:
					Description = "Handgun";

					if (PrimaryCaliber != null)
						Description = PrimaryCaliber.Pistol ? "Pistol" : "Revolver";

					break;

				case eFireArmType.Rifle:
					Description = "Rifle";
					break;

				case eFireArmType.Shotgun:
					Description = "Shotgun";
					break;

				default:
					Description = "Other Firearm Type";
					break;
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
		// ToShortString()
		//============================================================================*

		public string ToShortString()
			{
			return (String.Format("{0} {1}", (Manufacturer != null) ? Manufacturer.Name : "", PartNumber));
			}

		//============================================================================*
		// ToString()
		//============================================================================*

		public override string ToString()
			{
			return (String.Format("{0} {1} ({2})", (Manufacturer != null) ? @Manufacturer.Name : "", @PartNumber, @SerialNumber));
			}

		//============================================================================*
		// ToLongString()
		//============================================================================*

		public string ToLongString()
			{
			return (ToString() + String.Format(" - {0}", PrimaryCaliber.ToString()));
			}

		//============================================================================*
		// TransferFees Property
		//============================================================================*

		public double TransferFees
			{
			get
				{
				return (m_dTransferFees);
				}
			set
				{
				m_dTransferFees = value;
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
		// TurretTypeFromString Property
		//============================================================================*

		public static cFirearm.eTurretType TurretTypeFromString(string strType)
			{
			return ((strType == "MOA" ? cFirearm.eTurretType.MOA : cFirearm.eTurretType.MilDot));
			}

		//============================================================================*
		// TurretTypeString Property
		//============================================================================*

		public static string TurretTypeString(cFirearm.eTurretType eType)
			{
			return (eType == cFirearm.eTurretType.MOA ? "MOA" : "Mil");
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
		// Validate()
		//============================================================================*

		public override bool Validate(bool fIdentityOK = false)
			{
			if (!base.Validate(fIdentityOK))
				return (false);

			if (m_eFirearmType == cFirearm.eFireArmType.None)
				return (false);

			if (fIdentityOK && Identity)
				return (true);

			if (Identity)
				return (false);

			if (m_dBarrelLength <= 0.0)
				return (false);

			if (m_dTwist <= 0.0 && m_eFirearmType != eFireArmType.Shotgun)
				return (false);

			if (m_FirearmCaliberList.Count == 0)
				return (false);

			return (true);
			}

		//============================================================================*
		// ZeroRange Property
		//============================================================================*

		public double ZeroRange
			{
			get
				{
				return (m_dZeroRange);
				}
			set
				{
				m_dZeroRange = value;
				}
			}
		}
	}
