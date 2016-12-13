//============================================================================*
// cCaliber.cs
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
// NameSpace
//============================================================================*

namespace ReloadersWorkShop
	{
	//============================================================================*
	// cCaliber class
	//============================================================================*

	[Serializable]
	public partial class cCaliber : IComparable
		{
		//============================================================================*
		// Public Static Data Members
		//============================================================================*

		public static cFirearm.eFireArmType sm_eCurrentFirearmType = cFirearm.eFireArmType.Handgun;

		//============================================================================*
		// Private Data Members
		//============================================================================*

		//----------------------------------------------------------------------------*
		// General
		//----------------------------------------------------------------------------*

		private cFirearm.eFireArmType m_eFirearmType = cFirearm.eFireArmType.Handgun;
		private string m_strName = "";
		private string m_strHeadStamp = "";

		private bool m_fPistol = true;

		//----------------------------------------------------------------------------*
		// Primer
		//----------------------------------------------------------------------------*

		private bool m_fSmallPrimer = false;
		private bool m_fLargePrimer = true;
		private bool m_fMagnumPrimer = false;

		//----------------------------------------------------------------------------*
		// Dimensions
		//----------------------------------------------------------------------------*

		private double m_dMinBulletDiameter = 0.0;
		private double m_dMaxBulletDiameter = 0.0;

		private double m_dMinBulletWeight = 0.0;
		private double m_dMaxBulletWeight = 0.0;

		private double m_dCaseTrimLength = 0.0;
		private double m_dMaxCaseLength = 0.0;

		private double m_dMaxCOL = 0.0;

		private double m_dMaxNeckDiameter = 0.0;

		//----------------------------------------------------------------------------*
		// Miscellaneous
		//----------------------------------------------------------------------------*

		private string m_strSAAMIPDF = "";

		private bool m_fChecked = false;

		//----------------------------------------------------------------------------*
		// Temporary - No need to save
		//----------------------------------------------------------------------------*

		private bool m_fIdentity = false;

		//============================================================================*
		// cCaliber() - Constructor
		//============================================================================*

		public cCaliber(bool fidentity = false)
			{
			m_fIdentity = fidentity;
			}

		//============================================================================*
		// cCaliber() - Copy Constructor
		//============================================================================*

		public cCaliber(cCaliber Caliber)
			{
			m_eFirearmType = Caliber.m_eFirearmType;
			m_strName = Caliber.m_strName;
			m_strHeadStamp = Caliber.m_strHeadStamp;
			m_fPistol = Caliber.m_fPistol;
			m_fSmallPrimer = Caliber.m_fSmallPrimer;
			m_fLargePrimer = Caliber.m_fLargePrimer;
			m_fMagnumPrimer = Caliber.m_fMagnumPrimer;
			m_dMinBulletDiameter = Caliber.m_dMinBulletDiameter;
			m_dMaxBulletDiameter = Caliber.m_dMaxBulletDiameter;
			m_dMinBulletWeight = Caliber.m_dMinBulletWeight;
			m_dMaxBulletWeight = Caliber.m_dMaxBulletWeight;
			m_dCaseTrimLength = Caliber.m_dCaseTrimLength;
			m_dMaxCaseLength = Caliber.m_dMaxCaseLength;
			m_dMaxCOL = Caliber.m_dMaxCOL;
			m_dMaxNeckDiameter = Caliber.m_dMaxNeckDiameter;
			m_strSAAMIPDF = Caliber.m_strSAAMIPDF;

			m_fChecked = Caliber.m_fChecked;

			m_fIdentity = Caliber.m_fIdentity;
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
		// Comparer()
		//============================================================================*

		public static int Comparer(cCaliber Caliber1, cCaliber Caliber2)
			{
			if (Caliber1 == null)
				{
				if (Caliber2 != null)
					return (-1);
				else
					return (0);
				}
			else
				{
				if (Caliber2 == null)
					return (1);
				}

			return (Caliber1.CompareTo(Caliber2));
			}

		//============================================================================*
		// CompareTo()
		//============================================================================*

		public int CompareTo(Object obj)
			{
			if (obj == null)
				return (1);

			cCaliber Caliber = (cCaliber) obj;

			cCaliber.CurrentFirearmType = FirearmType;

			int rc = FirearmType.CompareTo(Caliber.FirearmType);

			if (rc == 0)
				rc = Name.ToUpper().CompareTo(Caliber.Name.ToUpper());

			return (rc);
			}

		//============================================================================*
		// CurrentFirearmType Property
		//============================================================================*

		public static cFirearm.eFireArmType CurrentFirearmType
			{
			get
				{
				return (sm_eCurrentFirearmType);
				}
			set
				{
				sm_eCurrentFirearmType = value;
				}
			}

		//============================================================================*
		// FirearmType Property
		//============================================================================*

		public cFirearm.eFireArmType FirearmType
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
		// HeadStamp Property
		//============================================================================*

		public string HeadStamp
			{
			get
				{
				return (m_strHeadStamp);
				}
			set
				{
				m_strHeadStamp = value;
				}
			}

		//============================================================================*
		// Identity Property
		//============================================================================*

		public bool Identity
			{
			get
				{
				return (m_fIdentity);
				}
			}

		//============================================================================*
		// LargePrimer Property
		//============================================================================*

		public bool LargePrimer
			{
			get
				{
				return (m_fLargePrimer);
				}
			set
				{
				m_fLargePrimer = value;
				}
			}

		//============================================================================*
		// MagnumPrimer Property
		//============================================================================*

		public bool MagnumPrimer
			{
			get
				{
				return (m_fMagnumPrimer);
				}
			set
				{
				m_fMagnumPrimer = value;
				}
			}

		//============================================================================*
		// MaxBulletDiameter Property
		//============================================================================*

		public double MaxBulletDiameter
			{
			get
				{
				return (m_dMaxBulletDiameter);
				}
			set
				{
				m_dMaxBulletDiameter = value;
				}
			}

		//============================================================================*
		// MaxBulletWeight Property
		//============================================================================*

		public double MaxBulletWeight
			{
			get
				{
				return (m_dMaxBulletWeight);
				}
			set
				{
				m_dMaxBulletWeight = value;
				}
			}

		//============================================================================*
		// MaxCaseLength Property
		//============================================================================*

		public double MaxCaseLength
			{
			get
				{
				return (m_dMaxCaseLength);
				}
			set
				{
				m_dMaxCaseLength = value;
				}
			}

		//============================================================================*
		// MaxCOL Property
		//============================================================================*

		public double MaxCOL
			{
			get
				{
				return (m_dMaxCOL);
				}
			set
				{
				m_dMaxCOL = value;
				}
			}

		//============================================================================*
		// MaxNeckDiameter Property
		//============================================================================*

		public double MaxNeckDiameter
			{
			get
				{
				return (m_dMaxNeckDiameter);
				}
			set
				{
				m_dMaxNeckDiameter = value;
				}
			}

		//============================================================================*
		// MinBulletDiameter Property
		//============================================================================*

		public double MinBulletDiameter
			{
			get
				{
				return (m_dMinBulletDiameter);
				}
			set
				{
				m_dMinBulletDiameter = value;
				}
			}

		//============================================================================*
		// MinBulletWeight Property
		//============================================================================*

		public double MinBulletWeight
			{
			get
				{
				return (m_dMinBulletWeight);
				}
			set
				{
				m_dMinBulletWeight = value;
				}
			}

		//============================================================================*
		// Name Property
		//============================================================================*

		public string Name
			{
			get
				{
				return (m_strName);
				}
			set
				{
				m_strName = value;
				}
			}

		//============================================================================*
		// Pistol Property
		//============================================================================*

		public bool Pistol
			{
			get
				{
				return (m_fPistol);
				}
			set
				{
				m_fPistol = value;
				}
			}

		//============================================================================*
		// ResolveIdentities()
		//============================================================================*

		public bool ResolveIdentities(cDataFiles Datafiles)
			{
			return (false);
			}

		//============================================================================*
		// SAAMIPDF Property
		//============================================================================*

		public string SAAMIPDF
			{
			get
				{
				return (m_strSAAMIPDF);
				}
			set
				{
				m_strSAAMIPDF = value;
				}
			}

		//============================================================================*
		// ShowSAAMIPDF()
		//============================================================================*

		public static bool ShowSAAMIPDF(cDataFiles DataFiles, cCaliber Caliber)
			{
			string strDocPath = "http://www.saami.org/PubResources/CC_Drawings/";

			switch (Caliber.FirearmType)
				{
				case cFirearm.eFireArmType.Handgun:
					strDocPath += "Pistol/";
					break;

				case cFirearm.eFireArmType.Rifle:
					strDocPath += "Rifle/";
					break;

				case cFirearm.eFireArmType.Shotgun:
					strDocPath += "Shotgun/";
					break;
				}

			strDocPath += Caliber.SAAMIPDF;

			strDocPath = Path.ChangeExtension(strDocPath, ".pdf");

			return (cMainForm.DownloadSAAMIDoc(DataFiles, strDocPath));
			}

		//============================================================================*
		// SmallPrimer Property
		//============================================================================*

		public bool SmallPrimer
			{
			get
				{
				return (m_fSmallPrimer);
				}
			set
				{
				m_fSmallPrimer = value;
				}
			}

		//============================================================================*
		// SmallPrimer Property
		//============================================================================*

		public void Synch(cBullet Bullet)
			{
			}

		//============================================================================*
		// ToString()
		//============================================================================*

		public override string ToString()
			{
			string strString = m_strName;

			if (sm_eCurrentFirearmType != m_eFirearmType)
				{
				switch (m_eFirearmType)
					{
					case cFirearm.eFireArmType.Handgun:
						strString += " (Handgun)";
						break;
					case cFirearm.eFireArmType.Rifle:
						strString += " (Rifle)";
						break;
					case cFirearm.eFireArmType.Shotgun:
						strString += " (Shotgun)";
						break;
					}
				}

			return (strString);
			}

		//============================================================================*
		// Validate()
		//============================================================================*

		public bool Validate(bool fIdentityOK = false)
			{
			if (m_eFirearmType == cFirearm.eFireArmType.None || String.IsNullOrEmpty(m_strName))
				return (false);

			if (fIdentityOK && Identity)
				return (true);

			if (Identity)
				return (false);

			if (String.IsNullOrEmpty(m_strHeadStamp) || m_strHeadStamp.Length > m_strName.Length)
				return (false);

			if (!m_fSmallPrimer && !m_fLargePrimer && !m_fMagnumPrimer)
				return (false);

			if (m_eFirearmType != cFirearm.eFireArmType.Shotgun)
				{
				if (m_dMinBulletDiameter <= 0.0)
					return (false);

				if (m_dMaxBulletDiameter < m_dMinBulletDiameter)
					return (false);

				if (m_dMaxCOL < m_dCaseTrimLength)
					return (false);
				}

			if (m_dMinBulletWeight > m_dMaxBulletWeight)
				return (false);

			if (m_dCaseTrimLength > m_dMaxCaseLength)
				return (false);

			return (true);
			}
		}
	}
