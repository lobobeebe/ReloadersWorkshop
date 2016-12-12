//============================================================================*
// cBullet.cs
//
// Copyright © 2013-2014, Kevin S. Beebe
// All Rights Reserved
//============================================================================*

//============================================================================*
// .Net Using Statements
//============================================================================*

using System;
using System.Xml;

using ReloadersWorkShop.Preferences;

//============================================================================*
// CommonLib Using Statements
//============================================================================*

using CommonLib.Conversions;

//============================================================================*
// NameSpace
//============================================================================*

namespace ReloadersWorkShop
	{
	//============================================================================*
	// cBullet class
	//============================================================================*

	[Serializable]
	public partial class cBullet : cSupply
		{
		//============================================================================*
		// Private Static Data Members
		//============================================================================*

		private static double sm_dMinBulletWeight = cBullet.MinBulletWeight;
		private static double sm_dMaxBulletWeight = cBullet.MaxBulletWeight;

		//============================================================================*
		// Private Data Members
		//============================================================================*

		private string m_strPartNumber = "";
		private string m_strType = "";
		private Double m_dDiameter = 0.0;
		private double m_dLength = 0.0;
		private double m_dWeight = 0.0;
		private double m_dBallisticCoefficient = 0.0;

		private bool m_fSelfCast = false;
		private int m_nTopPunch = 0;

		private cBulletCaliberList m_BulletCaliberList = new cBulletCaliberList();

		//============================================================================*
		// cBullet() - Constructor
		//============================================================================*

		public cBullet(bool fIdentity = false)
			: base(cSupply.eSupplyTypes.Bullets,fIdentity)
			{
			}

		//============================================================================*
		// cBullet() - Copy Constructor
		//============================================================================*

		public cBullet(cBullet Bullet)
			: base(Bullet)
			{
			Copy(Bullet, false);
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
		// BulletCaliber()
		//============================================================================*

		public cBulletCaliber BulletCaliber(cCaliber Caliber)
			{
			if (m_BulletCaliberList == null)
				m_BulletCaliberList = new cBulletCaliberList();

			cBulletCaliber BulletCaliber = null;

			foreach (cBulletCaliber CheckBulletCaliber in m_BulletCaliberList)
				{
				if (CheckBulletCaliber.Caliber.CompareTo(Caliber) == 0)
					{
					BulletCaliber = CheckBulletCaliber;

					break;
					}
				}

			return (BulletCaliber);
			}

		//============================================================================*
		// BulletCaliberList Property
		//============================================================================*

		public cBulletCaliberList BulletCaliberList
			{
			get
				{
				return (m_BulletCaliberList);
				}
			set
				{
				m_BulletCaliberList = value;
				}
			}

		//============================================================================*
		// CalculateSectionalDensity()
		//============================================================================*

		public static double CalculateSectionalDensity(double dDiameter, double dWeight)
			{
			double dSectionalDensity = 0.0;

			try
				{
				dSectionalDensity = dWeight / (7000.0 * (dDiameter * dDiameter));
				}
			catch
				{
				dSectionalDensity = 0.0;
				}

			return (dSectionalDensity);
			}

		//============================================================================*
		// CanBeCaliber()
		//============================================================================*

		public bool CanBeCaliber(cCaliber Caliber)
			{
			if (FirearmType == Caliber.FirearmType && m_dDiameter >= Caliber.MinBulletDiameter && m_dDiameter <= Caliber.MaxBulletDiameter)
				return (true);

			return (false);
			}

		//============================================================================*
		// Comparer()
		//============================================================================*

		public static int Comparer(cBullet Bullet1, cBullet Bullet2)
			{
			if (Bullet1 == null)
				{
				if (Bullet2 != null)
					return (-1);
				else
					return (0);
				}
			else
				{
				if (Bullet2 == null)
					return (1);
				}

			return (Bullet1.CompareTo(Bullet2));
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
			// Compare Part Numbers
			//----------------------------------------------------------------------------*

			if (rc == 0)
				{
				cBullet Bullet = (cBullet) Supply;

				if (string.IsNullOrEmpty(m_strPartNumber))
					{
					if (!string.IsNullOrEmpty(Bullet.m_strPartNumber))
						rc = -1;
					else
						rc = 0;
					}
				else
					{
					if (string.IsNullOrEmpty(Bullet.m_strPartNumber))
						rc = 1;
					else
						rc = cDataFiles.ComparePartNumbers(m_strPartNumber, Bullet.m_strPartNumber);
					}
				}

			return (rc);
			}

		//============================================================================*
		// Copy()
		//============================================================================*

		public void Copy(cBullet Bullet, bool fCopyBase = true)
			{
			if (fCopyBase)
				base.Copy(Bullet);

			m_strPartNumber = Bullet.m_strPartNumber;
			m_strType = Bullet.m_strType;
			m_dDiameter = Bullet.m_dDiameter;
			m_dLength = Bullet.m_dLength;
			m_dWeight = Bullet.m_dWeight;
			m_dBallisticCoefficient = Bullet.m_dBallisticCoefficient;

			m_fSelfCast = Bullet.m_fSelfCast;
			m_nTopPunch = Bullet.m_nTopPunch;

			if (Bullet.BulletCaliberList != null)
				m_BulletCaliberList = new cBulletCaliberList(Bullet.BulletCaliberList);
			else
				m_BulletCaliberList = new cBulletCaliberList();
			}

		//============================================================================*
		// Diameter Property
		//============================================================================*

		public double Diameter
			{
			get
				{
				return (m_dDiameter);
				}
			set
				{
				m_dDiameter = value;
				}
			}

		//============================================================================*
		// HasCaliber()
		//============================================================================*

		public bool HasCaliber(cCaliber Caliber, bool fHideCalibers = false)
			{
			if (m_BulletCaliberList == null)
				m_BulletCaliberList = new cBulletCaliberList();

			foreach (cBulletCaliber CheckCaliber in m_BulletCaliberList)
				{
				if (CheckCaliber.CompareTo(Caliber) == 0)
					{
					if (!fHideCalibers || CheckCaliber.Caliber.Checked)
						return (true);
					}
				}

			return (false);
			}

		//============================================================================*
		// Length Property
		//============================================================================*

		public double Length
			{
			get
				{
				return (m_dLength);
				}
			set
				{
				m_dLength = value;
				}
			}

		//============================================================================*
		// MaxBulletWeight Property
		//============================================================================*

		public static double MaxBulletWeight
			{
			get
				{
				return (sm_dMinBulletWeight);
				}
			}

		//============================================================================*
		// MinBulletWeight Property
		//============================================================================*

		public static double MinBulletWeight
			{
			get
				{
				return (sm_dMinBulletWeight);
				}
			}

		//============================================================================*
		// PartNumber Property
		//============================================================================*

		public string PartNumber
			{
			get
				{
				if (m_strPartNumber == null)
					m_strPartNumber = "";

				return (m_strPartNumber);
				}

			set
				{
				m_strPartNumber = value;
				}
			}

		//============================================================================*
		// ResolveIdentities()
		//============================================================================*

		public override bool ResolveIdentities(cDataFiles DataFiles)
			{
			bool fChanged = base.ResolveIdentities(DataFiles);

			if (m_BulletCaliberList == null)
				m_BulletCaliberList = new cBulletCaliberList();

			fChanged = m_BulletCaliberList.ResolveIdentities(DataFiles) ? true : fChanged;

			return (fChanged);
			}

		//============================================================================*
		// SectionalDensity Property
		//============================================================================*

		public double SectionalDensity
			{
			get
				{
				return (CalculateSectionalDensity(m_dDiameter, m_dWeight));
				}
			}

		//============================================================================*
		// SelfCast Property
		//============================================================================*

		public bool SelfCast
			{
			get
				{
				return (m_fSelfCast);
				}
			set
				{
				m_fSelfCast = value;
				}
			}

		//============================================================================*
		// Synch() - Caliber
		//============================================================================*

		public bool Synch(cCaliber Caliber)
			{
			bool fFound = false;

			if (m_BulletCaliberList == null)
				m_BulletCaliberList = new ReloadersWorkShop.cBulletCaliberList();

			foreach (cBulletCaliber CheckBulletCaliber in m_BulletCaliberList)
				fFound = CheckBulletCaliber.Synch(Caliber);

			return (fFound);
			}

		//============================================================================*
		// TopPunch Property
		//============================================================================*

		public int TopPunch
			{
			get
				{
				return (m_nTopPunch);
				}
			set
				{
				m_nTopPunch = value;
				}
			}

		//============================================================================*
		// ToShortString()
		//============================================================================*

		public string ToShortString()
			{
			string strString = "";

			if (Manufacturer != null)
				strString = Manufacturer.Name;

			if (m_strPartNumber != null && m_strPartNumber.Length > 0)
				strString += String.Format(" {0}, {1}", m_strPartNumber, m_strType);
			else
				strString += String.Format(", {0}", m_strType);

			return (strString);
			}

		//============================================================================*
		// ToString()
		//============================================================================*

		public override string ToString()
			{

			string strString = "";

			if (Manufacturer != null)
				strString = Manufacturer.Name;

			string strDiameterFormat = " {0:F";
			strDiameterFormat += String.Format("{0:G0}", cPreferences.StaticPreferences.DimensionDecimals);
			strDiameterFormat += "}";

			string strWeightFormat = " {0:F";
			strWeightFormat += String.Format("{0:G0}", cPreferences.StaticPreferences.BulletWeightDecimals);
			strWeightFormat += "}";

			bool fType = false;

			if (m_strPartNumber != null && m_strPartNumber.Length > 0)
				strString += String.Format(" {0}", m_strPartNumber);
			else
				{
				strString += String.Format(" {0}", m_strType);

				fType = true;
				}

			strString += String.Format(strDiameterFormat, cPreferences.StaticPreferences.MetricDimensions ? cConversions.InchesToMillimeters(m_dDiameter) : m_dDiameter);

			strString += cDataFiles.MetricString(cDataFiles.eDataType.Dimension);

			strString += String.Format(strWeightFormat, cPreferences.StaticPreferences.MetricBulletWeights ? cConversions.GrainsToGrams(m_dWeight) : m_dWeight);

			strString += cPreferences.StaticPreferences.MetricBulletWeights ? "g" : "gr";

			if (!fType)
				strString += String.Format(" {0}", m_strType);

			strString = ToCrossUseString(strString);

			return (strString);
			}

		//============================================================================*
		// ToWeightString()
		//============================================================================*

		public string ToWeightString()
			{
			string strString = "";

			if (Manufacturer != null)
				strString = Manufacturer.Name;

			string strWeightFormat = ", {0:F";
			strWeightFormat += String.Format("{0:G0}", cPreferences.StaticPreferences.BulletWeightDecimals);
			strWeightFormat += "}";

			bool fType = false;

			if (m_strPartNumber != null && m_strPartNumber.Length > 0)
				strString += String.Format(" {0}", m_strPartNumber);
			else
				{
				strString += String.Format(", {0}", m_strType);

				fType = true;
				}

			strString += String.Format(strWeightFormat, cPreferences.StaticPreferences.MetricBulletWeights ? cConversions.GrainsToGrams(m_dWeight) : m_dWeight);

			strString += cPreferences.StaticPreferences.MetricBulletWeights ? " g" : " gr";

			if (!fType)
				strString += String.Format(", {0}", m_strType);

			return (strString);
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
			//----------------------------------------------------------------------------*
			// Check the basic identity info
			//----------------------------------------------------------------------------*

			if (!base.Validate(fIdentityOK))
				return (false);

			if (String.IsNullOrEmpty(m_strPartNumber))
				return (false);

			//----------------------------------------------------------------------------*
			// If this is an identity, return now
			//----------------------------------------------------------------------------*

			if (fIdentityOK && Identity)
				return (true);

			if (Identity)
				return (false);

			//----------------------------------------------------------------------------*
			// Otherwise, check the full monte for this item
			//----------------------------------------------------------------------------*

			if (m_dDiameter == 0.0 || m_dWeight == 0.0)
				return(false);

			return (true);
			}

		//============================================================================*
		// Weight Property
		//============================================================================*

		public double Weight
			{
			get
				{
				return (m_dWeight);
				}
			set
				{
				m_dWeight = value;
				}
			}
		}
	}

