//============================================================================*
// cManufacturer.cs
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
	// cManufacturer class
	//============================================================================*

	[Serializable]
	public class cManufacturer : IComparable
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

		// Firearms Parts

		private bool m_fScopes = false;
		private bool m_fTriggers = false;
		private bool m_fStocks = false;

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
			get { return (m_fAmmo); }
			set { m_fAmmo = value; }
			}

		//============================================================================*
		// Bullets Property
		//============================================================================*

		public bool Bullets
			{
			get { return (m_fBullets); }
			set { m_fBullets = value; }
			}

		//============================================================================*
		// BulletMolds Property
		//============================================================================*

		public bool BulletMolds
			{
			get { return (m_fBulletMolds); }
			set { m_fBulletMolds = value; }
			}

		//============================================================================*
		// Cases Property
		//============================================================================*

		public bool Cases
			{
			get { return (m_fCases); }
			set { m_fCases = value; }
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

			return(Name.ToUpper().CompareTo(Manufacturer.Name.ToUpper()));
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

			m_fScopes = Manufacturer.m_fScopes;
			m_fTriggers = Manufacturer.m_fTriggers;
			m_fStocks = Manufacturer.m_fStocks;
			}

		//============================================================================*
		// Handguns Property
		//============================================================================*

		public bool Handguns
			{
			get { return (m_fHandguns); }
			set { m_fHandguns = value; }
			}

		//============================================================================*
		// HeadStamp Property
		//============================================================================*

		public string HeadStamp
			{
			get { return (m_strHeadStamp); }
			set { m_strHeadStamp = value; }
			}

		//============================================================================*
		// Name Property
		//============================================================================*

		public string Name
			{
			get { return (m_strName); }
			set { m_strName = value; }
			}

		//============================================================================*
		// Powder Property
		//============================================================================*

		public bool Powder
			{
			get { return (m_fPowder); }
			set { m_fPowder = value; }
			}

		//============================================================================*
		// Primer Property
		//============================================================================*

		public bool Primers
			{
			get { return (m_fPrimers); }
			set { m_fPrimers = value; }
			}

		//============================================================================*
		// Rifles Property
		//============================================================================*

		public bool Rifles
			{
			get { return (m_fRifles); }
			set { m_fRifles = value; }
			}

		//============================================================================*
		// Scopes Property
		//============================================================================*

		public bool Scopes
			{
			get { return (m_fScopes); }
			set { m_fScopes = value; }
			}

		//============================================================================*
		// Shotguns Property
		//============================================================================*

		public bool Shotguns
			{
			get { return (m_fShotguns); }
			set { m_fShotguns = value; }
			}

		//============================================================================*
		// Stocks Property
		//============================================================================*

		public bool Stocks
			{
			get { return (m_fStocks); }
			set { m_fStocks = value; }
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
			get { return (m_fTriggers); }
			set { m_fTriggers = value; }
			}

		//============================================================================*
		// Website Property
		//============================================================================*

		public string Website
			{
			get { return (m_strWebsite); }
			set { m_strWebsite = value; }
			}

		//============================================================================*
		// WebSitevisited Property
		//============================================================================*

		public bool WebSiteVisited
			{
			get { return (m_fWebsiteVisited); }
			set { m_fWebsiteVisited = value; }
			}
		}
	}
