//============================================================================*
// cBulletCaliber.cs
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
	// cBulletCaliber class
	//============================================================================*

	[Serializable]
	public partial class cBulletCaliber
		{
		//============================================================================*
		// Private Data Members
		//============================================================================*

		private cCaliber m_Caliber = new cCaliber();

		private double m_dCOL = 0.0;
		private double m_dCBTO = 0.0;

		//============================================================================*
		// cBulletCaliber() - Constructor
		//============================================================================*

		public cBulletCaliber()
			{
			}

		//============================================================================*
		// cBulletCaliber() - Copy Constructor
		//============================================================================*

		public cBulletCaliber(cBulletCaliber BulletCaliber)
			{
			m_Caliber = BulletCaliber.m_Caliber;

			m_dCOL = BulletCaliber.m_dCOL;
			m_dCBTO = BulletCaliber.m_dCBTO;
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

		public static int Comparer(cBulletCaliber Caliber1, cBulletCaliber Caliber2)
			{
			if (Caliber1 == null)
				{
				if (Caliber2 != null)
					return (-1);
				else
					return (0);
				}

			return (Caliber1.CompareTo(Caliber2));
			}

		//============================================================================*
		// CompareTo() - BulletCaliber
		//============================================================================*

		public int CompareTo(cBulletCaliber BulletCaliber)
			{
			if (BulletCaliber == null)
				return (1);

			int rc = m_Caliber.CompareTo(BulletCaliber.m_Caliber);

			return (rc);
			}

		//============================================================================*
		// CompareTo() - Caliber
		//============================================================================*

		public int CompareTo(cCaliber Caliber)
			{
			if (Caliber == null)
				return (1);

			if (m_Caliber == null)
				return (-1);

			int rc = m_Caliber.CompareTo(Caliber);

			return (rc);
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
		// ResolveIdentities()
		//============================================================================*

		public bool ResolveIdentities(cDataFiles Datafiles)
			{
			bool fChanged = false;

			if (m_Caliber.Identity)
				{
				foreach (cCaliber Caliber in Datafiles.CaliberList)
					{
					if (!Caliber.Identity && Caliber.CompareTo(m_Caliber) == 0)
						{
						m_Caliber = Caliber;

						fChanged = true;

						break;
						}
					}
				}

			return (fChanged);
			}

		//============================================================================*
		// Synch() - Caliber
		//============================================================================*

		public bool Synch(cCaliber Caliber)
			{
			if (m_Caliber != null && m_Caliber.CompareTo(Caliber) == 0)
				{
				m_Caliber = Caliber;

				return (true);
				}

			return (false);
			}

		//============================================================================*
		// ToString Property
		//============================================================================*

		public override string ToString()
			{
			return (m_Caliber.Name);
			}

		//============================================================================*
		// Validate()
		//============================================================================*

		public bool Validate()
			{
			bool fOK = m_Caliber != null;

			return (fOK);
			}
		}
	}
