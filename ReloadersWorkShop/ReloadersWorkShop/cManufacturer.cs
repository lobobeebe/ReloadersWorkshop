//============================================================================*
// cManufacturer.cs
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
	// cManufacturer class
	//============================================================================*

	[Serializable]
	public partial class cManufacturer : IComparable
		{
		//----------------------------------------------------------------------------*
		// Private Data Members
		//----------------------------------------------------------------------------*

		// Company Info

		private string m_strName = "";
		private string m_strWebsite = "";
		private bool m_fWebsiteVisited = false;

		// Supplies

		private bool m_fBullets = false;
		private bool m_fPrimers = false;
		private bool m_fCases = false;
		private bool m_fPowder = false;
		private bool m_fAmmo = false;
		private bool m_fBulletMolds = false;

		private string m_strHeadStamp = "";

		// Firearms

		private bool m_fHandguns = false;
		private bool m_fRifles = false;
		private bool m_fShotguns = false;

		// Firearm Accessories

		private bool m_fScopes = false;
		private bool m_fLasers = false;
		private bool m_fRedDots = false;
		private bool m_fMagnifiers = false;
		private bool m_fLights = false;
		private bool m_fTriggers = false;
		private bool m_fFurniture = false;
		private bool m_fBipods = false;
		private bool m_fParts = false;
		private bool m_fMisc = false;

		// Tools & Equipment

		private bool m_fTools = false;
		private bool m_fEquipment = false;

		//============================================================================*
		// cManufacturer() - Constructor
		//============================================================================*

		public cManufacturer()
			{
			}

		//============================================================================*
		// cManufacturer() - Copy Constructor
		//============================================================================*

		public cManufacturer(cManufacturer Manufacturer)
			{
			Copy(Manufacturer);
			}

		//============================================================================*
		// Ammo Property
		//============================================================================*

		public bool Ammo
			{
			get
				{
				return (m_fAmmo);
				}
			set
				{
				m_fAmmo = value;
				}
			}

		//============================================================================*
		// Append()
		//============================================================================*

		public int Append(cManufacturer Manufacturer, bool fCountOnly = false)
			{
			int nUpdateCount = 0;

			if (String.IsNullOrEmpty(m_strWebsite) && !String.IsNullOrEmpty(Manufacturer.m_strWebsite))
				{
				if (!fCountOnly)
					{
					m_strWebsite = Manufacturer.m_strWebsite;

					m_fWebsiteVisited = false;
					}

				nUpdateCount++;
				}

			if (!m_fAmmo && Manufacturer.m_fAmmo)
				{
				if (!fCountOnly)
					m_fAmmo = Manufacturer.m_fAmmo;

				nUpdateCount++;
				}

			if (!m_fBullets && Manufacturer.m_fBullets)
				{
				if (!fCountOnly)
					m_fBullets = Manufacturer.m_fBullets;

				nUpdateCount++;
				}

			if (!m_fCases && Manufacturer.m_fCases)
				{
				if (!fCountOnly)
					m_fCases = Manufacturer.m_fCases;

				nUpdateCount++;
				}

			if (!m_fPowder && Manufacturer.m_fPowder)
				{
				if (!fCountOnly)
					m_fPowder = Manufacturer.m_fPowder;

				nUpdateCount++;
				}

			if (!m_fPrimers && Manufacturer.m_fPrimers)
				{
				if (!fCountOnly)
					m_fPrimers = Manufacturer.m_fPrimers;

				nUpdateCount++;
				}

			if (!m_fBulletMolds && Manufacturer.m_fBulletMolds)
				{
				if (!fCountOnly)
					m_fBulletMolds = Manufacturer.m_fBulletMolds;

				nUpdateCount++;
				}

			if (String.IsNullOrEmpty(m_strHeadStamp) && !String.IsNullOrEmpty(Manufacturer.m_strHeadStamp))
				{
				if (!fCountOnly)
					m_strHeadStamp = Manufacturer.m_strHeadStamp;

				nUpdateCount++;
				}

			if (!m_fHandguns && Manufacturer.m_fHandguns)
				{
				if (!fCountOnly)
					m_fHandguns = Manufacturer.m_fHandguns;

				nUpdateCount++;
				}

			if (!m_fRifles && Manufacturer.m_fRifles)
				{
				if (!fCountOnly)
					m_fRifles = Manufacturer.m_fRifles;

				nUpdateCount++;
				}

			if (!m_fShotguns && Manufacturer.m_fShotguns)
				{
				if (!fCountOnly)
					m_fShotguns = Manufacturer.m_fShotguns;

				nUpdateCount++;
				}

			if (!m_fScopes && Manufacturer.m_fScopes)
				{
				if (!fCountOnly)
					m_fScopes = Manufacturer.m_fScopes;

				nUpdateCount++;
				}

			if (!m_fLasers && Manufacturer.m_fLasers)
				{
				if (!fCountOnly)
					m_fLasers = Manufacturer.m_fLasers;

				nUpdateCount++;
				}

			if (!m_fRedDots && Manufacturer.m_fRedDots)
				{
				if (!fCountOnly)
					m_fRedDots = Manufacturer.m_fRedDots;

				nUpdateCount++;
				}

			if (!m_fMagnifiers && Manufacturer.m_fMagnifiers)
				{
				if (!fCountOnly)
					m_fMagnifiers = Manufacturer.m_fMagnifiers;

				nUpdateCount++;
				}

			if (!m_fLights && Manufacturer.m_fLights)
				{
				if (!fCountOnly)
					m_fLights = Manufacturer.m_fLights;

				nUpdateCount++;
				}

			if (!m_fTriggers && Manufacturer.m_fTriggers)
				{
				if (!fCountOnly)
					m_fTriggers = Manufacturer.m_fTriggers;

				nUpdateCount++;
				}

			if (!m_fFurniture && Manufacturer.m_fFurniture)
				{
				if (!fCountOnly)
					m_fFurniture = Manufacturer.m_fFurniture;

				nUpdateCount++;
				}

			if (!m_fBipods && Manufacturer.m_fBipods)
				{
				if (!fCountOnly)
					m_fBipods = Manufacturer.m_fBipods;

				nUpdateCount++;
				}

			if (!m_fParts && Manufacturer.m_fParts)
				{
				if (!fCountOnly)
					m_fParts = Manufacturer.m_fParts;

				nUpdateCount++;
				}

			if (!m_fMisc && Manufacturer.m_fMisc)
				{
				if (!fCountOnly)
					m_fMisc = Manufacturer.m_fMisc;

				nUpdateCount++;
				}

			return (nUpdateCount);
			}

		//============================================================================*
		// Parts Property
		//============================================================================*

		public bool Parts
			{
			get
				{
				return (m_fParts);
				}
			set
				{
				m_fParts = value;
				}
			}

		//============================================================================*
		// Bipods Property
		//============================================================================*

		public bool Bipods
			{
			get
				{
				return (m_fBipods);
				}
			set
				{
				m_fBipods = value;
				}
			}

		//============================================================================*
		// Bullets Property
		//============================================================================*

		public bool Bullets
			{
			get
				{
				return (m_fBullets);
				}
			set
				{
				m_fBullets = value;
				}
			}

		//============================================================================*
		// BulletMolds Property
		//============================================================================*

		public bool BulletMolds
			{
			get
				{
				return (m_fBulletMolds);
				}
			set
				{
				m_fBulletMolds = value;
				}
			}

		//============================================================================*
		// Cases Property
		//============================================================================*

		public bool Cases
			{
			get
				{
				return (m_fCases);
				}
			set
				{
				m_fCases = value;
				}
			}

		//============================================================================*
		// Comparer()
		//============================================================================*

		public static int Comparer(cManufacturer Manufacturer1, cManufacturer Manufacturer2)
			{
			if (Manufacturer1 == null)
				{
				if (Manufacturer2 != null)
					return (-1);
				else
					return (0);
				}

			return (Manufacturer1.CompareTo(Manufacturer2));
			}

		//============================================================================*
		// CompareTo()
		//============================================================================*

		public int CompareTo(Object obj)
			{
			if (obj == null)
				return (1);

			cManufacturer Manufacturer = (cManufacturer) obj;

			//----------------------------------------------------------------------------*
			// Name
			//----------------------------------------------------------------------------*

			return (Name.ToUpper().CompareTo(Manufacturer.Name.ToUpper()));
			}

		//============================================================================*
		// Copy()
		//============================================================================*

		public void Copy(cManufacturer Manufacturer)
			{
			m_strName = Manufacturer.m_strName;
			m_strWebsite = Manufacturer.m_strWebsite;
			m_fWebsiteVisited = Manufacturer.m_fWebsiteVisited;

			m_fAmmo = Manufacturer.m_fAmmo;
			m_fBullets = Manufacturer.m_fBullets;
			m_fCases = Manufacturer.m_fCases;
			m_fPowder = Manufacturer.m_fPowder;
			m_fPrimers = Manufacturer.m_fPrimers;
			m_fBulletMolds = Manufacturer.m_fBulletMolds;

			m_strHeadStamp = Manufacturer.m_strHeadStamp;

			m_fHandguns = Manufacturer.m_fHandguns;
			m_fRifles = Manufacturer.m_fRifles;
			m_fShotguns = Manufacturer.m_fShotguns;

			m_fTools = Manufacturer.m_fTools;

			m_fScopes = Manufacturer.m_fScopes;
			m_fLasers = Manufacturer.m_fLasers;
			m_fRedDots = Manufacturer.m_fRedDots;
			m_fMagnifiers = Manufacturer.m_fMagnifiers;
			m_fLights = Manufacturer.m_fLights;
			m_fTriggers = Manufacturer.m_fTriggers;
			m_fFurniture = Manufacturer.m_fFurniture;
			m_fBipods = Manufacturer.m_fBipods;
			m_fParts = Manufacturer.m_fParts;
			m_fMisc = Manufacturer.m_fMisc;
			}

		//============================================================================*
		// Equipment Property
		//============================================================================*

		public bool Equipment
			{
			get
				{
				return (m_fEquipment);
				}
			set
				{
				m_fEquipment = value;
				}
			}

		//============================================================================*
		// Furniture Property
		//============================================================================*

		public bool Furniture
			{
			get
				{
				return (m_fFurniture);
				}
			set
				{
				m_fFurniture = value;
				}
			}

		//============================================================================*
		// Handguns Property
		//============================================================================*

		public bool Handguns
			{
			get
				{
				return (m_fHandguns);
				}
			set
				{
				m_fHandguns = value;
				}
			}

		//============================================================================*
		// HasGear()
		//============================================================================*

		public bool HasGear(cGear.eGearTypes eType)
			{
			switch (eType)
				{
				case cGear.eGearTypes.Scope:
					return (m_fScopes);
				case cGear.eGearTypes.Laser:
					return (m_fLasers);
				case cGear.eGearTypes.RedDot:
					return (m_fRedDots);
				case cGear.eGearTypes.Magnifier:
					return (m_fMagnifiers);
				case cGear.eGearTypes.Light:
					return (m_fLights);
				case cGear.eGearTypes.Trigger:
					return (m_fTriggers);
				case cGear.eGearTypes.Furniture:
					return (m_fFurniture);
				case cGear.eGearTypes.Bipod:
					return (m_fBipods);
				case cGear.eGearTypes.Parts:
					return (m_fParts);
				}

			return (m_fMisc);
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
		// Lasers Property
		//============================================================================*

		public bool Lasers
			{
			get
				{
				return (m_fLasers);
				}
			set
				{
				m_fLasers = value;
				}
			}

		//============================================================================*
		// Lights Property
		//============================================================================*

		public bool Lights
			{
			get
				{
				return (m_fLights);
				}
			set
				{
				m_fLights = value;
				}
			}

		//============================================================================*
		// Magnifiers Property
		//============================================================================*

		public bool Magnifiers
			{
			get
				{
				return (m_fMagnifiers);
				}
			set
				{
				m_fMagnifiers = value;
				}
			}

		//============================================================================*
		// Misc Property
		//============================================================================*

		public bool Misc
			{
			get
				{
				return (m_fMisc);
				}
			set
				{
				m_fMisc = value;
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
		// Powder Property
		//============================================================================*

		public bool Powder
			{
			get
				{
				return (m_fPowder);
				}
			set
				{
				m_fPowder = value;
				}
			}

		//============================================================================*
		// Primer Property
		//============================================================================*

		public bool Primers
			{
			get
				{
				return (m_fPrimers);
				}
			set
				{
				m_fPrimers = value;
				}
			}

		//============================================================================*
		// RedDots Property
		//============================================================================*

		public bool RedDots
			{
			get
				{
				return (m_fRedDots);
				}
			set
				{
				m_fRedDots = value;
				}
			}

		//============================================================================*
		// Rifles Property
		//============================================================================*

		public bool Rifles
			{
			get
				{
				return (m_fRifles);
				}
			set
				{
				m_fRifles = value;
				}
			}

		//============================================================================*
		// Scopes Property
		//============================================================================*

		public bool Scopes
			{
			get
				{
				return (m_fScopes);
				}
			set
				{
				m_fScopes = value;
				}
			}

		//============================================================================*
		// Shotguns Property
		//============================================================================*

		public bool Shotguns
			{
			get
				{
				return (m_fShotguns);
				}
			set
				{
				m_fShotguns = value;
				}
			}

		//============================================================================*
		// Tools Property
		//============================================================================*

		public bool Tools
			{
			get
				{
				return (m_fTools);
				}
			set
				{
				m_fTools = value;
				}
			}

		//============================================================================*
		// ToString Property
		//============================================================================*

		public override string ToString()
			{
			string strString = m_strName;

			return (strString);
			}

		//============================================================================*
		// Triggers Property
		//============================================================================*

		public bool Triggers
			{
			get
				{
				return (m_fTriggers);
				}
			set
				{
				m_fTriggers = value;
				}
			}

		//============================================================================*
		// Validate()
		//============================================================================*

		public bool Validate()
			{
			if (String.IsNullOrEmpty(m_strName))
				return (false);

			if (m_fCases && String.IsNullOrEmpty(m_strHeadStamp))
				return (false);

			if (!m_fAmmo && !m_fBipods && !m_fBulletMolds && !m_fBullets && !m_fCases &&
				!m_fFurniture && !m_fHandguns && !m_fLasers && !m_fLights && !m_fMagnifiers &&
				!m_fMisc && !m_fParts && !m_fPowder && !m_fPrimers && !m_fRedDots &&
				!m_fRifles && !m_fScopes && !m_fShotguns && !m_fTriggers)
				return (false);

			return (true);
			}

		//============================================================================*
		// Website Property
		//============================================================================*

		public string Website
			{
			get
				{
				return (m_strWebsite);
				}
			set
				{
				m_strWebsite = value;
				}
			}

		//============================================================================*
		// WebSitevisited Property
		//============================================================================*

		public bool WebSiteVisited
			{
			get
				{
				return (m_fWebsiteVisited);
				}
			set
				{
				m_fWebsiteVisited = value;
				}
			}
		}
	}
