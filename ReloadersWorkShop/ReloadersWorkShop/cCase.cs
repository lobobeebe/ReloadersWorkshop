//============================================================================*
// cCase.cs
//
// Copyright © 2013-2014, Kevin S. Beebe
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
	// cCase class
	//============================================================================*

	[Serializable]
	public partial class cCase : cSupply
		{
		//============================================================================*
		// Private Data Members
		//============================================================================*

		private string m_strPartNumber = "";
		private cCaliber m_Caliber = null;
		private bool m_fMatch = false;
		private bool m_fMilitary = false;
		private bool m_fLargePrimer = false;
		private bool m_fSmallPrimer = false;

		//============================================================================*
		// cCase() - Constructor
		//============================================================================*

		public cCase(bool fIdentity = false)
			: base(cSupply.eSupplyTypes.Cases, fIdentity)
			{
			}

		//============================================================================*
		// cCase() - Copy Constructor
		//============================================================================*

		public cCase(cCase Case)
			: base(Case)
			{
			Copy(Case, false);
			}

		//============================================================================*
		// Append()
		//============================================================================*

		public int Append(cCase Case, bool fCountOnly = false)
			{
			int nUpdateCount = base.Append(Case, fCountOnly);

			if (!m_fMatch && Case.m_fMatch)
				{
				if (fCountOnly)
					m_fMatch = Case.m_fMatch;

				nUpdateCount++;
				}

			if (!m_fMilitary && Case.m_fMilitary)
				{
				if (fCountOnly)
					m_fMilitary = Case.m_fMilitary;

				nUpdateCount++;
				}

			if (!m_fLargePrimer && Case.m_fLargePrimer)
				{
				if (fCountOnly)
					m_fLargePrimer = Case.m_fLargePrimer;

				nUpdateCount++;
				}

			if (!m_fSmallPrimer && Case.m_fSmallPrimer)
				{
				if (fCountOnly)
					m_fSmallPrimer = Case.m_fSmallPrimer;

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

		public static int Comparer(cCase Case1, cCase Case2)
			{
			if (Case1 == null)
				{
				if (Case2 != null)
					return (-1);
				else
					return (0);
				}
			else
				{
				if (Case2 == null)
					return (1);
				}

			return (Case1.CompareTo(Case2));
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
			// Part Number
			//----------------------------------------------------------------------------*

			if (rc == 0)
				{
				cCase Case = (cCase) Supply;

				rc = cDataFiles.ComparePartNumbers(m_strPartNumber, Case.m_strPartNumber);

				//----------------------------------------------------------------------------*
				// Caliber
				//----------------------------------------------------------------------------*

				if (rc == 0)
					{
					if (m_Caliber == null)
						{
						if (Case.m_Caliber == null)
							rc = 0;
						else
							rc = -1;
						}
					else
						{
						if (Case.m_Caliber == null)
							rc = 1;
						else
							rc = m_Caliber.CompareTo(Case.m_Caliber);
						}
					}
				}

			return (rc);
			}

		//============================================================================*
		// Copy()
		//============================================================================*

		public void Copy(cCase Case, bool fCopyBase = true)
			{
			if (fCopyBase)
				base.Copy(Case);

			m_strPartNumber = Case.m_strPartNumber;
			m_Caliber = Case.m_Caliber;
			m_fMatch = Case.m_fMatch;
			m_fMilitary = Case.m_fMilitary;
			m_fLargePrimer = Case.m_fLargePrimer;
			m_fSmallPrimer = Case.m_fSmallPrimer;
			}

		//============================================================================*
		// HeadStamp Property
		//============================================================================*

		public string HeadStamp
			{
			get
				{
				string strHeadStamp = "";

				if (Manufacturer != null && !String.IsNullOrEmpty( Manufacturer.HeadStamp))
					strHeadStamp += Manufacturer.HeadStamp;

				if (m_fMatch)
					strHeadStamp += " Match";

				if (m_Caliber != null)
					{
					strHeadStamp += " - ";
					strHeadStamp += m_Caliber.HeadStamp;
					}

				return (strHeadStamp);
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

				m_fSmallPrimer = !m_fLargePrimer;
				}
			}

		//============================================================================*
		// Military Property
		//============================================================================*

		public bool Military
			{
			get
				{
				return (m_fMilitary);
				}
			set
				{
				m_fMilitary = value;
				}
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

			return (fChanged);
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

				m_fLargePrimer = !m_fSmallPrimer;
				}
			}

		//============================================================================*
		// Synch() - Caliber
		//============================================================================*

		public bool Synch(cCaliber Caliber)
			{
			if (m_Caliber.CompareTo(Caliber) == 0)
				{
				m_Caliber = Caliber;

				return (true);
				}

			return (false);
			}

		//============================================================================*
		// Match Property
		//============================================================================*

		public bool Match
			{
			get
				{
				return (m_fMatch);
				}
			set
				{
				m_fMatch = value;
				}
			}

		//============================================================================*
		// ToShortString
		//============================================================================*

		public string ToShortString()
			{
			string strString = String.Format("{0}", Manufacturer.Name);

			strString += (" " + m_strPartNumber);

			if (!string.IsNullOrEmpty(Manufacturer.HeadStamp) && Manufacturer.HeadStamp != Manufacturer.Name)
				strString += String.Format(" ({0})", Manufacturer.HeadStamp);

			if (m_fMatch)
				strString += " Match";

			strString = ToCrossUseString(strString);

			return (strString);
			}

		//============================================================================*
		// ToString
		//============================================================================*

		public override string ToString()
			{
			string strString = "";

			if (Manufacturer != null)
				strString = Manufacturer.Name;

			string strHeadStamp = "";

			if (!String.IsNullOrEmpty(Manufacturer.HeadStamp) && Manufacturer.HeadStamp != Manufacturer.Name)
				strHeadStamp += String.Format("({0}", (Manufacturer != null) ? Manufacturer.HeadStamp : "");

			if (!String.IsNullOrEmpty(m_strPartNumber))
				strString += " " + m_strPartNumber;

			if (m_fMatch)
				strString += " Match";

			if (m_Caliber != null && !String.IsNullOrEmpty(m_Caliber.HeadStamp))
				{
				if (strHeadStamp.Length == 0)
					strHeadStamp = "(";
				else
					strHeadStamp += " - ";

				strHeadStamp += String.Format("{0})", m_Caliber.HeadStamp);
				}
			else
				{
				if (strHeadStamp.Length != 0)
					strHeadStamp += ")";
				}

			strString += (" " + strHeadStamp);

			strString = ToCrossUseString(strString);

			return (strString);
			}

		//============================================================================*
		// Validate()
		//============================================================================*

		public override bool Validate(bool fIdentityOK = false)
			{
			if (!base.Validate(fIdentityOK))
				return (false);

			if (m_Caliber == null)
				return (false);

			return (true);
			}
		}
	}
