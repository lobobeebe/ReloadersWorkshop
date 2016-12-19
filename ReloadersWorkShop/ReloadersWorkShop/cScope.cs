//============================================================================*
// cScope.cs
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
	// cScope Class
	//============================================================================*

	[Serializable]
	public partial class cScope : cGear
		{
		//============================================================================*
		// Public Enumerations
		//============================================================================*

		public enum eTurretTubeSizes
			{
			Small = 0,
			Large
			}

		//============================================================================*
		// Private Data Members
		//============================================================================*

		private string m_strPower = "";
		private string m_strObjective = "";

		private eTurretTubeSizes m_eTubeSize = eTurretTubeSizes.Small;
		private cFirearm.eTurretType m_eTurretType = cFirearm.eTurretType.MOA;

		private double m_dTurretClick = 0.0;

		//============================================================================*
		// cScope() - Constructor
		//============================================================================*

		public cScope()
			: base(cGear.eGearTypes.Scope)
			{
			}

		//============================================================================*
		// cScope() - Copy Constructor
		//============================================================================*

		public cScope(cScope Scope)
			: base(Scope)
			{
			Copy(Scope);
			}

		//============================================================================*
		// Copy()
		//============================================================================*

		public override void Copy(cGear Gear)
			{
			if (Gear.GearType != eGearTypes.Scope)
				return;

			base.Copy(Gear);

			cScope Scope = (cScope) Gear;

			m_strPower = Scope.m_strPower;
			m_strObjective = Scope.m_strObjective;

			m_eTubeSize = Scope.m_eTubeSize;
			m_eTurretType = Scope.m_eTurretType;

			m_dTurretClick = Scope.m_dTurretClick;
			}

		//============================================================================*
		// Objective Property
		//============================================================================*

		public string Objective
			{
			get
				{
				return (m_strObjective);
				}

			set
				{
				m_strObjective = value;
				}
			}

		//============================================================================*
		// Power Property
		//============================================================================*

		public string Power
			{
			get
				{
				return (m_strPower);
				}

			set
				{
				m_strPower = value;
				}
			}

		//============================================================================*
		// ToString()
		//============================================================================*

		public override string ToString()
			{
			string strString = String.Format("{0} {1} {2}x{3}mm Scope", Manufacturer.Name, PartNumber, m_strPower, m_strObjective);

			if (!String.IsNullOrEmpty(SerialNumber))
				strString += String.Format(" {0}", SerialNumber);

			return (strString);
			}

		//============================================================================*
		// TubeSize Property
		//============================================================================*

		public eTurretTubeSizes TubeSize
			{
			get
				{
				return (m_eTubeSize);
				}

			set
				{
				m_eTubeSize = value;
				}
			}

		//============================================================================*
		// TubeSizeFromString()
		//============================================================================*

		public static cScope.eTurretTubeSizes TubeSizeFromString(string strType)
			{
			return (strType == "1 in" ? eTurretTubeSizes.Small : eTurretTubeSizes.Large);
			}

		//============================================================================*
		// TubeSizeString()
		//============================================================================*

		public static string TubeSizeString(eTurretTubeSizes eTubeSize)
			{
			return (eTubeSize == eTurretTubeSizes.Small ? "1 in" : "30 mm");
			}

		//============================================================================*
		// TurretClick Property
		//============================================================================*

		public double TurretClick
			{
			get
				{
				return (m_dTurretClick);
				}

			set
				{
				m_dTurretClick = value;
				}
			}

		//============================================================================*
		// TurretType Property
		//============================================================================*

		public cFirearm.eTurretType TurretType
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
		}
	}
