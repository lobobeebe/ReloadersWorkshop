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

		public enum eTubeMeasurements
			{
			Inch = 0,
			Millimeter
			}

		//============================================================================*
		// Private Data Members
		//============================================================================*

		private string m_strPower = "";
		private string m_strObjective = "";

		private eTurretTubeSizes m_eTubeSize = eTurretTubeSizes.Small;
		private cFirearm.eTurretType m_eTurretType = cFirearm.eTurretType.MOA;

		private double m_dTurretClick = 0.0;

		private string m_strBattery = "";

		private double m_dEyeRelief = 0.0;

		private int m_nTubeSize = 0;
		private eTubeMeasurements m_eTubeMeasurement = eTubeMeasurements.Inch;

		//============================================================================*
		// cScope() - Constructor
		//============================================================================*

		public cScope()
			: base(cGear.eGearTypes.Scope)
			{
			FixTubeSize();
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
		// Battery Property
		//============================================================================*

		public string Battery
			{
			get
				{
				return (m_strBattery);
				}

			set
				{
				m_strBattery = value;
				}
			}

		//============================================================================*
		// Copy()
		//============================================================================*

		public override void Copy(cGear Gear)
			{
			if (Gear.GearType != eGearTypes.Scope)
				return;

			base.Copy(Gear);

			cScope Scope = (cScope)Gear;

			m_strPower = Scope.m_strPower;
			m_strObjective = Scope.m_strObjective;

			m_nTubeSize = Scope.m_nTubeSize;
			m_eTubeMeasurement = Scope.m_eTubeMeasurement;
			m_eTurretType = Scope.m_eTurretType;

			m_dTurretClick = Scope.m_dTurretClick;

			m_strBattery = Scope.m_strBattery;
			m_dEyeRelief = Scope.m_dEyeRelief;

			FixTubeSize();
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
		// FixTubeSize()
		//============================================================================*

		public void FixTubeSize()
			{
			if (m_nTubeSize == 0)
				{
				if (m_eTubeSize == 0)
					{
					m_nTubeSize = 1;
					m_eTubeMeasurement = eTubeMeasurements.Inch;
					}
				else
					{
					m_nTubeSize = 30;
					m_eTubeMeasurement = eTubeMeasurements.Millimeter;
					}
				}
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

		public int TubeSize
			{
			get
				{
				return (m_nTubeSize);
				}

			set
				{
				m_nTubeSize = value;
				}
			}

		//============================================================================*
		// TubeMeasurement Property
		//============================================================================*

		public eTubeMeasurements TubeMeasurement
			{
			get
				{
				return (m_eTubeMeasurement);
				}

			set
				{
				m_eTubeMeasurement = value;
				}
			}

		//============================================================================*
		// TubeMeasurementFromString()
		//============================================================================*

		public static cScope.eTubeMeasurements TubeMeasurementFromString(string strMeasurement)
			{
			switch (strMeasurement)
				{
				case "in":
				case "Inch":
					return (cScope.eTubeMeasurements.Inch);

				case "mm":
				case "Millimeter":
					return (cScope.eTubeMeasurements.Millimeter);
				}

			return (cScope.eTubeMeasurements.Inch);
			}

		//============================================================================*
		// TubeMeasurementString Property
		//============================================================================*

		public static string TubeMeasurementString(eTubeMeasurements eTubeMeasurement)
			{
			switch (eTubeMeasurement)
				{
				case eTubeMeasurements.Inch:
					return ("in");

				case eTubeMeasurements.Millimeter:
					return ("mm");
				}

			return ("");
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
