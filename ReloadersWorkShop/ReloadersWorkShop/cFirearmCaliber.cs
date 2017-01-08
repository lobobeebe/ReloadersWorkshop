//============================================================================*
// cFirearmCaliber.cs
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
	// cFirearmCOL class
	//============================================================================*

	[Serializable]
	public partial class cFirearmCaliber
		{
		//----------------------------------------------------------------------------*
		// Private Data Members
		//----------------------------------------------------------------------------*

		private cCaliber m_Caliber = new cCaliber();

		private bool m_fPrimary = false;

		//============================================================================*
		// cFirearmCaliber() - Constructor
		//============================================================================*

		public cFirearmCaliber()
			{
			}

		//============================================================================*
		// cFirearmCaliber() - Copy Constructor
		//============================================================================*

		public cFirearmCaliber(cFirearmCaliber FirearmCaliber)
			{
			Copy(FirearmCaliber);
			}

		//============================================================================*
		// Append()
		//============================================================================*

		public int Append(cFirearmCaliber FirearmCaliber, bool fCountOnly = false)
			{
			int nUpdateCount = 0;

			if (!m_fPrimary && FirearmCaliber.m_fPrimary)
				{
				if (!fCountOnly)
					m_fPrimary = FirearmCaliber.m_fPrimary;

				nUpdateCount++;
				}

			return (nUpdateCount);
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

		public static int Comparer(cFirearmCaliber FirearmCaliber1, cFirearmCaliber FirearmCaliber2)
			{
			if (FirearmCaliber1 == null)
				{
				if (FirearmCaliber2 != null)
					return (-1);
				else
					return (0);
				}

			return (FirearmCaliber1.CompareTo(FirearmCaliber2));
			}

		//============================================================================*
		// CompareTo()
		//============================================================================*

		public int CompareTo(Object obj)
			{
			if (obj == null)
				return (1);

			cFirearmCaliber FirearmCaliber = (cFirearmCaliber) obj;

			//----------------------------------------------------------------------------*
			// Compare Caliber
			//----------------------------------------------------------------------------*

			return (m_Caliber.CompareTo(FirearmCaliber.m_Caliber));
			}

		//============================================================================*
		// Copy()
		//============================================================================*

		public void Copy(cFirearmCaliber FirearmCaliber)
			{
			m_Caliber = FirearmCaliber.m_Caliber;

			m_fPrimary = FirearmCaliber.m_fPrimary;
			}

		//============================================================================*
		// Primary Property
		//============================================================================*

		public bool Primary
			{
			get
				{
				return (m_fPrimary);
				}
			set
				{
				m_fPrimary = value;
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
		// ToString
		//============================================================================*

		public override string ToString()
			{
			string strString = String.Format("{0}", m_Caliber.ToString());

			if (m_fPrimary)
				strString += " - Primary";

			return (strString);
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
