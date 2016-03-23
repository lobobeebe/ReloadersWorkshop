//============================================================================*
// cFirearmBullet.cs
//
// Copyright © 2013-2014, Kevin S. Beebe
// All Rights Reserved
//============================================================================*

//============================================================================*
// .Net Using Statements
//============================================================================*

using System;

using System.Windows.Forms;

using ReloadersWorkShop.Preferences;

//============================================================================*
// NameSpace
//============================================================================*

namespace ReloadersWorkShop
	{
	//============================================================================*
	// cFirearmBullet class
	//============================================================================*

	[Serializable]
	public class cFirearmBullet
		{
		//============================================================================*
		// Private Data Members
		//============================================================================*

		private cCaliber m_Caliber = new cCaliber();

		private cBullet m_Bullet = null;
		private double m_dCOL = 0.0;
		private double m_dCBTO = 0.0;

		//============================================================================*
		// cFirearmBullet() - Constructor
		//============================================================================*

		public cFirearmBullet()
			{
			}

		//============================================================================*
		// cFirearmBullet() - Copy Constructor
		//============================================================================*

		public cFirearmBullet(cFirearmBullet FirearmBullet)
			{
			m_Caliber = FirearmBullet.m_Caliber;

			m_Bullet = new cBullet(FirearmBullet.m_Bullet);
			m_dCOL = FirearmBullet.m_dCOL;
			m_dCBTO = FirearmBullet.m_dCBTO;
			}

		//============================================================================*
		// Bullet Property
		//============================================================================*

		public cBullet Bullet
			{
			get { return (m_Bullet); }
			set { m_Bullet = value; }
			}

		//============================================================================*
		// Caliber Property
		//============================================================================*

		public cCaliber Caliber
			{
			get { return (m_Caliber); }
			set {m_Caliber = value; }
			}

		//============================================================================*
		// COL Property
		//============================================================================*

		public double COL
			{
			get { return (m_dCOL); }
			set { m_dCOL = value; }
			}

		//============================================================================*
		// Comparer()
		//============================================================================*

		public static int Comparer(cFirearmBullet FirearmBullet1, cFirearmBullet FirearmBullet2)
			{
			if (FirearmBullet1 == null)
				{
				if (FirearmBullet2 != null)
					return (-1);
				else
					return (0);
				}

			return (FirearmBullet1.CompareTo(FirearmBullet2));
			}

		//============================================================================*
		// CompareTo()
		//============================================================================*

		public int CompareTo(cFirearmBullet FirearmBullet)
			{
			if (FirearmBullet == null)
				return (1);

			//----------------------------------------------------------------------------*
			// Compare Caliber
			//----------------------------------------------------------------------------*

			int rc = m_Caliber.CompareTo(FirearmBullet.m_Caliber);

			//----------------------------------------------------------------------------*
			// Compare Bullet
			//----------------------------------------------------------------------------*

			if (rc == 0)
				rc = m_Bullet.CompareTo(FirearmBullet.m_Bullet);

            return(rc);
			}

		//============================================================================*
		// CBTO Property
		//============================================================================*

		public double CBTO
			{
			get { return (m_dCBTO); }
			set { m_dCBTO = value; }
			}

		//============================================================================*
		// Synch() - Bullet
		//============================================================================*

		public bool Synch(cBullet Bullet)
			{
			if (m_Bullet != null && m_Bullet.CompareTo(Bullet) == 0)
				{
				m_Bullet = Bullet;

				return (true);
				}

			return (false);
			}

		//============================================================================*
		// ToString
		//============================================================================*

		public override string ToString()
			{
			string strString = String.Format("{0}", m_Bullet.ToWeightString());

			return (strString);
			}
		}
	}
