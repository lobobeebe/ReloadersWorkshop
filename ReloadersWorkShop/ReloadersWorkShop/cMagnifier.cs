//============================================================================*
// cMagnifier.cs
//
// Copyright © 2013-2017, Kevin S. Beebe
// All Rights Reserved
//============================================================================*

//============================================================================*
// .Net Using Statements
//============================================================================*

using System;

//============================================================================*
// Namespace
//============================================================================*

namespace ReloadersWorkShop
	{
	//============================================================================*
	// cMagnifier Class
	//============================================================================*

	[Serializable]
	public partial class cMagnifier : cGear
		{
		//============================================================================*
		// Private Data Members
		//============================================================================*

		private string m_strMagnification = "";
		private double m_dEyeRelief = 0.0;
		private double m_dFoV = 0.0;

		//============================================================================*
		// cMagnifier() - Constructor
		//============================================================================*

		public cMagnifier()
			: base(cGear.eGearTypes.Magnifier)
			{
			}

		//============================================================================*
		// cMagnifier() - Copy Constructor
		//============================================================================*

		public cMagnifier(cMagnifier Magnifier)
			: base(Magnifier)
			{
			Copy(Magnifier);
			}

		//============================================================================*
		// Copy()
		//============================================================================*

		public override void Copy(cGear Gear)
			{
			if (Gear.GearType != eGearTypes.Magnifier)
				return;

			base.Copy(Gear);

			cMagnifier Magnifier = (cMagnifier) Gear;

			m_strMagnification = Magnifier.m_strMagnification;
			m_dFoV = Magnifier.m_dFoV;
			m_dEyeRelief = Magnifier.m_dEyeRelief;
			}

		//============================================================================*
		// FoV Property
		//============================================================================*

		public double FoV
			{
			get
				{
				return (m_dFoV);
				}

			set
				{
				m_dFoV = value;
				}
			}

		//============================================================================*
		// Magnification Property
		//============================================================================*

		public string Magnification
			{
			get
				{
				return (m_strMagnification);
				}

			set
				{
				m_strMagnification = value;
				}
			}

		//============================================================================*
		// EyeRelief Property
		//============================================================================*

		public double EyeRelief
			{
			get
				{
				return (m_dEyeRelief);
				}

			set
				{
				m_dEyeRelief = value;
				}
			}

		//============================================================================*
		// ToString()
		//============================================================================*

		public override string ToString()
			{
			string strString = String.Format("{0} {1} {2}x Magnifier", Manufacturer.Name, PartNumber, m_strMagnification);

			if (!String.IsNullOrEmpty(SerialNumber))
				strString += String.Format(" {0}", SerialNumber);

			return (strString);
			}
		}
	}
