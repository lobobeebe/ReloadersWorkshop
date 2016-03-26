//============================================================================*
// cBallistics.cs
//
// Copyright © 2013-2014, Kevin S. Beebe
// All Rights Reserved
//============================================================================*

//============================================================================*
// .Net Using Statements
//============================================================================*

using System;

//============================================================================*
// CommonLib Using Statements
//============================================================================*

using CommonLib.Conversions;

//============================================================================*
// Application Specific Using Statements
//============================================================================*

using ReloadersWorkShop.Preferences;

//============================================================================*
// NameSpace
//============================================================================*

namespace ReloadersWorkShop.Ballistics
	{
	//============================================================================*
	// cBallistics class
	//============================================================================*

	[Serializable]
	public class cBallistics : cStability, IComparable
		{
		//============================================================================*
		// Public Enumerations
		//============================================================================*

		//----------------------------------------------------------------------------*
		// Drag Function
		//----------------------------------------------------------------------------*

		public enum eDragFunction
			{
			Basic = 0,
			G1,
			G2,
			G5,
			G6,
			G7,
			G8
			};

		//============================================================================*
		// Private Constants
		//============================================================================*

		private const double cm_dGravity = -32.194;

		private const double cm_dStandardPressure = 29.53;

		//============================================================================*
		// Private Data Members
		//============================================================================*

		//----------------------------------------------------------------------------*
		// Bullet Data
		//----------------------------------------------------------------------------*

		private eDragFunction m_eDragFunction = eDragFunction.G1;

		private int m_nMuzzleHeight = 60;

		//----------------------------------------------------------------------------*
		// Firearm Data
		//----------------------------------------------------------------------------*

		private double m_dZeroRange = 200;                         // Yards
		private double m_dSightHeight = 1.5;                    // Inches
		private double m_dScopeClick = 0.250;                   // MOA/Mils

		private cFirearm.eTurretType m_eTurretType = cFirearm.eTurretType.MOA;

		//----------------------------------------------------------------------------*
		// Range Data
		//----------------------------------------------------------------------------*

		private double m_dRange = 200;
		private double m_dMinRange = 0;
		private double m_dMaxRange = 500;
		private double m_dTargetRange = 300;
		private double m_dIncrement = 50;
		private double m_dSlope = 0;

		//----------------------------------------------------------------------------*
		// Miscellaneous
		//----------------------------------------------------------------------------*

		private bool m_fActive = false;

		//----------------------------------------------------------------------------*
		// Intermediate Values
		//----------------------------------------------------------------------------*

		private double m_dDK = 0.0;
		private double m_dElevation0 = 0.0;

		//----------------------------------------------------------------------------*
		// Output Values
		//----------------------------------------------------------------------------*

		private double m_dRemainingVelocity = 0.0;
		private double m_dTimeOfFlight = 0.0;

		private double m_dWindDrift = 0.0;
		private double m_dWindDriftMOA = 0.0;

		private double m_dBulletPath = 0.0;
		private double m_dBulletPathMOA = 0.0;

		private string m_strScopeClicks = "";

		//============================================================================*
		// cBallistics() - Constructor
		//============================================================================*

		public cBallistics()
			{
			}

		//============================================================================*
		// cBallistics() - Copy Constructor
		//============================================================================*

		public cBallistics(cBallistics Ballistics)
				: base(Ballistics)
			{
			m_eDragFunction = Ballistics.m_eDragFunction;

			m_nMuzzleHeight = Ballistics.m_nMuzzleHeight;

			m_dZeroRange = Ballistics.m_dZeroRange;
			m_dSightHeight = Ballistics.m_dSightHeight;
			m_dScopeClick = Ballistics.m_dScopeClick;

			m_eTurretType = Ballistics.m_eTurretType;

			m_dRange = Ballistics.m_dRange;
			m_dMinRange = Ballistics.m_dMinRange;
			m_dMaxRange = Ballistics.m_dMaxRange;
			m_dTargetRange = Ballistics.m_dTargetRange;
			m_dIncrement = Ballistics.m_dIncrement;
			m_dSlope = Ballistics.m_dSlope;

			m_fActive = Ballistics.m_fActive;

			m_dDK = Ballistics.m_dDK;
			m_dElevation0 = Ballistics.m_dElevation0;

			m_dRemainingVelocity = Ballistics.m_dRemainingVelocity;
			m_dTimeOfFlight = Ballistics.m_dTimeOfFlight;

			m_dWindDrift = Ballistics.m_dWindDrift;
			m_dWindDriftMOA = Ballistics.m_dWindDriftMOA;

			m_dBulletPath = Ballistics.m_dBulletPath;
			m_dBulletPathMOA = Ballistics.m_dBulletPathMOA;

			m_strScopeClicks = Ballistics.m_strScopeClicks;
			}

		//============================================================================*
		// Active Property
		//============================================================================*

		public bool Active
			{
			get
				{
				return (m_fActive);
				}

			set
				{
				m_fActive = value;

				if (m_fActive)
					Recalculate();
				}
			}

		//============================================================================*
		// Altitude Property
		//============================================================================*

		public override int Altitude
			{
			set
				{
				base.Altitude = value;

				if (m_fActive)
					Recalculate();
				else
					CalculateZeroRange();
				}
			}

		//============================================================================*
		// AltitudeCorrectionFactor Property
		//============================================================================*

		private double AltitudeCorrectionFactor
			{
			get
				{
				double dAltitude = UseDensityAltitude ? DensityAltitude : Altitude;

				return (1.0 / (-4e-15 * Math.Pow(dAltitude, 3.0) + 4e-10 * Math.Pow(dAltitude, 2.0) - 3e-5 * dAltitude + 1.0));
				}
			}

		//============================================================================*
		// AtmosphericBCCorrection Property
		//============================================================================*

		private double AtmosphericBCCorrection
			{
			get
				{
				return (BallisticCoefficient * (AltitudeCorrectionFactor * (1.0 + TemperatureCorrectionFactor - PressureCorrectionFactor) * HumidityCorrectionFactor));
				}
			}

		//============================================================================*
		// BulletPath Property
		//============================================================================*

		public double BulletPath
			{
			get
				{
				return (m_dBulletPath);
				}
			}

		//============================================================================*
		// BulletPathMOA Property
		//============================================================================*

		public double BulletPathMOA
			{
			get
				{
				return (m_dBulletPathMOA);
				}
			}

		//============================================================================*
		// Calculate()
		//============================================================================*

		private void Calculate()
			{
			if (BallisticCoefficient <= 0.0)
				return;

			//----------------------------------------------------------------------------*
			// Calculate gravity and velocities
			//----------------------------------------------------------------------------*

			double Gy = cm_dGravity * Math.Cos(cConversions.DegreesToRadians((m_dSlope + ZeroAngle)));
			double Gx = cm_dGravity * Math.Sin(cConversions.DegreesToRadians((m_dSlope + ZeroAngle)));

			double vx = (double) MuzzleVelocity * Math.Cos(cConversions.DegreesToRadians(0.0));
			double vy = (double) MuzzleVelocity * Math.Sin(cConversions.DegreesToRadians(0.0));

			double vx1 = vx;
			double vy1 = vy;

			//----------------------------------------------------------------------------*
			// Correct BC for atmospheric conditions and calculate remaining velocity
			//----------------------------------------------------------------------------*

			double dBC = AtmosphericBCCorrection;

			m_dRemainingVelocity = Math.Pow(Math.Sqrt(MuzzleVelocity) - 0.00863 * m_dRange / (dBC != 0.0 ? dBC : 1.0), 2.0);

			//----------------------------------------------------------------------------*
			// Calculate time of flight
			//----------------------------------------------------------------------------*

			double dLastTime = m_dRange > 0.0 ? m_dTimeOfFlight : 0.0;

			m_dTimeOfFlight = 3 * (double) m_dRange / ((double) MuzzleVelocity * (1 - 0.003 * m_dRange * m_dDK));

			double dDeltaTime = m_dTimeOfFlight - dLastTime;

			//----------------------------------------------------------------------------*
			// More stuff to try and add to the results
			//----------------------------------------------------------------------------*

			double dv = DragRetardation(m_dRemainingVelocity + HeadWind);
			double dvx = -(vx / m_dRemainingVelocity) * dv;
			double dvy = -(vy / m_dRemainingVelocity) * dv;

			// Compute velocity, including the resolved gravity vectors.	

			vx = vx + dDeltaTime * dvx + dDeltaTime * Gx;
			vy = vy + dDeltaTime * dvy + dDeltaTime * Gy;

			double x = dDeltaTime * (vx + vx1) / 2.0;

			double y = m_dSightHeight / 12;
			y += dDeltaTime * (vy + vy1) / 2.0;

			y *= 12;

			//----------------------------------------------------------------------------*
			// Calculate Bullet Drop
			//----------------------------------------------------------------------------*

			double dF = 193.0 * (1.0 - (0.37 * ((double) MuzzleVelocity - m_dRemainingVelocity)) / (double) MuzzleVelocity);

			double dDrop = dF * (Math.Pow(m_dTimeOfFlight, 2));

			double dMaxHeight = 48.6 * Math.Pow(m_dTimeOfFlight, 2) - 0.4 * m_dSightHeight;

			double dElevation1 = 100 * (dDrop + m_dSightHeight) / m_dRange;

			m_dBulletPath = (m_dRange > 0.0) ? (m_dElevation0 - dElevation1) * m_dRange / 100.0 : 0.0 - m_dSightHeight;
			m_dBulletPathMOA = m_dBulletPath != 0.0 && m_dRange > 0.0 ? m_dBulletPath / ((m_dRange / 100.0) * 1.047) : 0.0;

			if (m_eTurretType == cFirearm.eTurretType.MilDot)
				m_dBulletPathMOA /= 3.44;

			//----------------------------------------------------------------------------*
			// Calculate wind Drift
			//----------------------------------------------------------------------------*

			m_dWindDrift = (CrossWind * 17.60) * (m_dTimeOfFlight - (double) ((3.0 * m_dRange) / (double) MuzzleVelocity));

			m_dWindDriftMOA = m_dWindDrift != 0.0 && m_dRange > 0.0 ? m_dWindDrift / ((m_dRange / 100.0) * 1.047) : 0.0;

			if (m_eTurretType == cFirearm.eTurretType.MilDot)
				m_dWindDriftMOA /= 3.44;

			//----------------------------------------------------------------------------*
			// Set the Scope Clicks String
			//----------------------------------------------------------------------------*

			m_strScopeClicks = "";

			if (m_dRange > 0.0 && m_dScopeClick != 0.0)
				{
				if (m_dBulletPathMOA > 0.0)
					m_strScopeClicks += String.Format("D{0:F0}", m_dBulletPathMOA / m_dScopeClick);
				else
					{
					if (m_dBulletPathMOA < 0.0)
						m_strScopeClicks += String.Format("U{0:F0}", (0.0 - m_dBulletPathMOA) / m_dScopeClick);
					}

				if (m_dWindDriftMOA > 0.0)
					m_strScopeClicks += String.Format("  L{0:F0}", m_dWindDriftMOA / m_dScopeClick);
				else
					{
					if (m_dWindDriftMOA < 0.0)
						m_strScopeClicks += String.Format("  R{0:F0}", (0.0 - m_dWindDriftMOA) / m_dScopeClick);
					}
				}
			else
				m_strScopeClicks += "---";

			if (m_strScopeClicks.Length == 0)
				m_strScopeClicks = "---";
			}

		//============================================================================*
		// CalculateZeroRange()
		//============================================================================*

		private void CalculateZeroRange()
			{
			//----------------------------------------------------------------------------*
			// Get elevation for the zero range
			//----------------------------------------------------------------------------*

			double dBC = AtmosphericBCCorrection;

			m_dRemainingVelocity = Math.Pow(Math.Sqrt((double) MuzzleVelocity) - 0.00863 * m_dZeroRange / (dBC != 0.0 ? dBC : 1.0), 2);

			m_dDK = 2.878 / (dBC * Math.Sqrt((double) MuzzleVelocity));

			m_dTimeOfFlight = 3.0 * m_dZeroRange / ((double) MuzzleVelocity * (1 - 0.003 * m_dZeroRange * m_dDK));

			double dF = 193.0 * (1.0 - (0.37 * ((double) MuzzleVelocity - m_dRemainingVelocity)) / (double) MuzzleVelocity);

			double dDrop = dF * (Math.Pow(m_dTimeOfFlight, 2));

			m_dElevation0 = 100.0 * (dDrop + m_dSightHeight) / m_dZeroRange;
			}

		//============================================================================*
		// CompareAtmospherics()
		//============================================================================*

		public int CompareAtmospherics(cBallistics Ballistics)
			{
			int rc = WindDirection.CompareTo(Ballistics.WindDirection);

			if (rc == 0)
				{
				rc = WindSpeed.CompareTo(Ballistics.WindSpeed);
				}

			return (rc);
			}

		//============================================================================*
		// CompareBasics()
		//============================================================================*

		public int CompareBasics(cBallistics Ballistics)
			{
			if (Ballistics == null)
				return (1);

			int rc = BallisticCoefficient.CompareTo(Ballistics.BallisticCoefficient);

			if (rc == 0)
				{
				rc = BulletDiameter.CompareTo(Ballistics.BulletDiameter);

				if (rc == 0)
					{
					rc = BulletWeight.CompareTo(Ballistics.BulletWeight);

					if (rc == 0)
						{
						rc = BulletLength.CompareTo(Ballistics.BulletLength);

						if (rc == 0)
							{
							rc = MuzzleVelocity.CompareTo(Ballistics.MuzzleVelocity);
							}
						}
					}
				}

			return (rc);
			}

		//============================================================================*
		// Comparer()
		//============================================================================*

		public static int Comparer(Object Data1, Object Data2)
			{
			if (Data1 == null)
				{
				if (Data2 != null)
					return (-1);
				else
					return (0);
				}

			cBallistics Ballistics1 = (cBallistics) Data1;

			return (Ballistics1.CompareTo(Data2));
			}

		//============================================================================*
		// CompareTo()
		//============================================================================*

		public int CompareTo(Object BallisticsObject)
			{
			cBallistics Ballistics = (cBallistics) BallisticsObject;

			if (Ballistics == null)
				return (1);

			int rc = CompareBasics(Ballistics);

			if (rc == 0)
				rc = CompareAtmospherics(Ballistics);

			return (rc);
			}

		//============================================================================*
		// DragRetardation()
		//============================================================================*

		private double DragRetardation(double dVelocity)
			{
			double dValue = -1.0;

			double vp = dVelocity;
			double A = -1.0;
			double M = -1.0;

			//----------------------------------------------------------------------------*
			// Determine the Drag Function
			//----------------------------------------------------------------------------*

			switch (m_eDragFunction)
				{
				//----------------------------------------------------------------------------*
				// G1
				//----------------------------------------------------------------------------*

				case eDragFunction.G1:
					if (vp > 4230)
						{
						A = 1.477404177730177e-04;
						M = 1.9565;
						}
					else if (vp > 3680)
						{
						A = 1.920339268755614e-04;
						M = 1.925;
						}
					else if (vp > 3450)
						{
						A = 2.894751026819746e-04;
						M = 1.875;
						}
					else if (vp > 3295)
						{
						A = 4.349905111115636e-04;
						M = 1.825;
						}
					else if (vp > 3130)
						{
						A = 6.520421871892662e-04;
						M = 1.775;
						}
					else if (vp > 2960)
						{
						A = 9.748073694078696e-04;
						M = 1.725;
						}
					else if (vp > 2830)
						{
						A = 1.453721560187286e-03;
						M = 1.675;
						}
					else if (vp > 2680)
						{
						A = 2.162887202930376e-03;
						M = 1.625;
						}
					else if (vp > 2460)
						{
						A = 3.209559783129881e-03;
						M = 1.575;
						}
					else if (vp > 2225)
						{
						A = 3.904368218691249e-03;
						M = 1.55;
						}
					else if (vp > 2015)
						{
						A = 3.222942271262336e-03;
						M = 1.575;
						}
					else if (vp > 1890)
						{
						A = 2.203329542297809e-03;
						M = 1.625;
						}
					else if (vp > 1810)
						{
						A = 1.511001028891904e-03;
						M = 1.675;
						}
					else if (vp > 1730)
						{
						A = 8.609957592468259e-04;
						M = 1.75;
						}
					else if (vp > 1595)
						{
						A = 4.086146797305117e-04;
						M = 1.85;
						}
					else if (vp > 1520)
						{
						A = 1.954473210037398e-04;
						M = 1.95;
						}
					else if (vp > 1420)
						{
						A = 5.431896266462351e-05;
						M = 2.125;
						}
					else if (vp > 1360)
						{
						A = 8.847742581674416e-06;
						M = 2.375;
						}
					else if (vp > 1315)
						{
						A = 1.456922328720298e-06;
						M = 2.625;
						}
					else if (vp > 1280)
						{
						A = 2.419485191895565e-07;
						M = 2.875;
						}
					else if (vp > 1220)
						{
						A = 1.657956321067612e-08;
						M = 3.25;
						}
					else if (vp > 1185)
						{
						A = 4.745469537157371e-10;
						M = 3.75;
						}
					else if (vp > 1150)
						{
						A = 1.379746590025088e-11;
						M = 4.25;
						}
					else if (vp > 1100)
						{
						A = 4.070157961147882e-13;
						M = 4.75;
						}
					else if (vp > 1060)
						{
						A = 2.938236954847331e-14;
						M = 5.125;
						}
					else if (vp > 1025)
						{
						A = 1.228597370774746e-14;
						M = 5.25;
						}
					else if (vp > 980)
						{
						A = 2.916938264100495e-14;
						M = 5.125;
						}
					else if (vp > 945)
						{
						A = 3.855099424807451e-13;
						M = 4.75;
						}
					else if (vp > 905)
						{
						A = 1.185097045689854e-11;
						M = 4.25;
						}
					else if (vp > 860)
						{
						A = 3.566129470974951e-10;
						M = 3.75;
						}
					else if (vp > 810)
						{
						A = 1.045513263966272e-08;
						M = 3.25;
						}
					else if (vp > 780)
						{
						A = 1.291159200846216e-07;
						M = 2.875;
						}
					else if (vp > 750)
						{
						A = 6.824429329105383e-07;
						M = 2.625;
						}
					else if (vp > 700)
						{
						A = 3.569169672385163e-06;
						M = 2.375;
						}
					else if (vp > 640)
						{
						A = 1.839015095899579e-05;
						M = 2.125;
						}
					else if (vp > 600)
						{
						A = 5.71117468873424e-05;
						M = 1.950;
						}
					else if (vp > 550)
						{
						A = 9.226557091973427e-05;
						M = 1.875;
						}
					else if (vp > 250)
						{
						A = 9.337991957131389e-05;
						M = 1.875;
						}
					else if (vp > 100)
						{
						A = 7.225247327590413e-05;
						M = 1.925;
						}
					else if (vp > 65)
						{
						A = 5.792684957074546e-05;
						M = 1.975;
						}
					else if (vp > 0)
						{
						A = 5.206214107320588e-05;
						M = 2.000;
						}
					break;

				//----------------------------------------------------------------------------*
				// G2
				//----------------------------------------------------------------------------*

				case eDragFunction.G2:
					if (vp > 1674)
						{
						A = .0079470052136733;
						M = 1.36999902851493;
						}
					else if (vp > 1172)
						{
						A = 1.00419763721974e-03;
						M = 1.65392237010294;
						}
					else if (vp > 1060)
						{
						A = 7.15571228255369e-23;
						M = 7.91913562392361;
						}
					else if (vp > 949)
						{
						A = 1.39589807205091e-10;
						M = 3.81439537623717;
						}
					else if (vp > 670)
						{
						A = 2.34364342818625e-04;
						M = 1.71869536324748;
						}
					else if (vp > 335)
						{
						A = 1.77962438921838e-04;
						M = 1.76877550388679;
						}
					else if (vp > 0)
						{
						A = 5.18033561289704e-05;
						M = 1.98160270524632;
						}
					break;

				//----------------------------------------------------------------------------*
				// G5
				//----------------------------------------------------------------------------*

				case eDragFunction.G5:
					if (vp > 1730)
						{
						A = 7.24854775171929e-03;
						M = 1.41538574492812;
						}
					else if (vp > 1228)
						{
						A = 3.50563361516117e-05;
						M = 2.13077307854948;
						}
					else if (vp > 1116)
						{
						A = 1.84029481181151e-13;
						M = 4.81927320350395;
						}
					else if (vp > 1004)
						{
						A = 1.34713064017409e-22;
						M = 7.8100555281422;
						}
					else if (vp > 837)
						{
						A = 1.03965974081168e-07;
						M = 2.84204791809926;
						}
					else if (vp > 335)
						{
						A = 1.09301593869823e-04;
						M = 1.81096361579504;
						}
					else if (vp > 0)
						{
						A = 3.51963178524273e-05;
						M = 2.00477856801111;
						}
					break;

				//----------------------------------------------------------------------------*
				// G6
				//----------------------------------------------------------------------------*

				case eDragFunction.G6:
					if (vp > 3236)
						{
						A = 0.0455384883480781;
						M = 1.15997674041274;
						}
					else if (vp > 2065)
						{
						A = 7.167261849653769e-02;
						M = 1.10704436538885;
						}
					else if (vp > 1311)
						{
						A = 1.66676386084348e-03;
						M = 1.60085100195952;
						}
					else if (vp > 1144)
						{
						A = 1.01482730119215e-07;
						M = 2.9569674731838;
						}
					else if (vp > 1004)
						{
						A = 4.31542773103552e-18;
						M = 6.34106317069757;
						}
					else if (vp > 670)
						{
						A = 2.04835650496866e-05;
						M = 2.11688446325998;
						}
					else if (vp > 0)
						{
						A = 7.50912466084823e-05;
						M = 1.92031057847052;
						}
					break;

				//----------------------------------------------------------------------------*
				// G7
				//----------------------------------------------------------------------------*

				case eDragFunction.G7:
					if (vp > 4200)
						{
						A = 1.29081656775919e-09;
						M = 3.24121295355962;
						}
					else if (vp > 3000)
						{
						A = 0.0171422231434847;
						M = 1.27907168025204;
						}
					else if (vp > 1470)
						{
						A = 2.33355948302505e-03;
						M = 1.52693913274526;
						}
					else if (vp > 1260)
						{
						A = 7.97592111627665e-04;
						M = 1.67688974440324;
						}
					else if (vp > 1110)
						{
						A = 5.71086414289273e-12;
						M = 4.3212826264889;
						}
					else if (vp > 960)
						{
						A = 3.02865108244904e-17;
						M = 5.99074203776707;
						}
					else if (vp > 670)
						{
						A = 7.52285155782535e-06;
						M = 2.1738019851075;
						}
					else if (vp > 540)
						{
						A = 1.31766281225189e-05;
						M = 2.08774690257991;
						}
					else if (vp > 0)
						{
						A = 1.34504843776525e-05;
						M = 2.08702306738884;
						}
					break;

				//----------------------------------------------------------------------------*
				// G8
				//----------------------------------------------------------------------------*

				case eDragFunction.G8:
					if (vp > 3571)
						{
						A = .0112263766252305;
						M = 1.33207346655961;
						}
					else if (vp > 1841)
						{
						A = .0167252613732636;
						M = 1.28662041261785;
						}
					else if (vp > 1120)
						{
						A = 2.20172456619625e-03;
						M = 1.55636358091189;
						}
					else if (vp > 1088)
						{
						A = 2.0538037167098e-16;
						M = 5.80410776994789;
						}
					else if (vp > 976)
						{
						A = 5.92182174254121e-12;
						M = 4.29275576134191;
						}
					else if (vp > 0)
						{
						A = 4.3917343795117e-05;
						M = 1.99978116283334;
						}
					break;

				default:
					break;

				}

			if (A != -1.0 && M != -1.0 && vp > 0.0 && vp < 10000.0)
				{
				dValue = (A * Math.Pow(vp, M)) / BallisticCoefficient;

				return (dValue);
				}

			return (-1.0);
			}

		//============================================================================*
		// DragFunction Property
		//============================================================================*

		public eDragFunction DragFunction
			{
			get
				{
				return (m_eDragFunction);
				}
			set
				{
				m_eDragFunction = value;
				}
			}

		//============================================================================*
		// Energy Property
		//============================================================================*

		public double Energy
			{
			get
				{
				return ((BulletWeight * Math.Pow(m_dRemainingVelocity, 2) / 450282.0));
				}
			}

		//============================================================================*
		// Humidity Property
		//============================================================================*

		public override double Humidity
			{
			set
				{
				base.Humidity = value;

				if (m_fActive)
					Recalculate();
				else
					CalculateZeroRange();
				}
			}

		//============================================================================*
		// HumidityCorrectionFactor Property
		//============================================================================*

		private double HumidityCorrectionFactor
			{
			get
				{
				double dVPw = 4e-6 * Math.Pow(Temperature, 3) - 0.0004 * Math.Pow(Temperature, 2) + 0.0234 * Temperature - 0.2517;

				return (0.995 * (Pressure / (Pressure - (0.3783) * (Humidity) * dVPw)));
				}
			}

		//============================================================================*
		// Increment Property
		//============================================================================*

		public double Increment
			{
			get
				{
				return (m_dIncrement);
				}
			set
				{
				m_dIncrement = value;
				}
			}

		//============================================================================*
		// MaxRange Property
		//============================================================================*

		public double MaxRange
			{
			get
				{
				return (m_dMaxRange);
				}
			set
				{
				m_dMaxRange = value;
				}
			}

		//============================================================================*
		// MinRange Property
		//============================================================================*

		public double MinRange
			{
			get
				{
				return (m_dMinRange);
				}
			set
				{
				m_dMinRange = value;
				}
			}

		//============================================================================*
		// MuzzleHeight Property
		//============================================================================*

		public int MuzzleHeight
			{
			get
				{
				return (m_nMuzzleHeight);
				}
			set
				{
				m_nMuzzleHeight = value;
				}
			}

		//============================================================================*
		// MuzzleVelocity Property
		//============================================================================*

		public override int MuzzleVelocity
			{
			set
				{
				base.MuzzleVelocity = value;

				if (m_fActive)
					Recalculate();
				else
					CalculateZeroRange();
				}
			}

		//============================================================================*
		// Pressure Property
		//============================================================================*

		public override double Pressure
			{
			set
				{
				base.Pressure = value;

				if (m_fActive)
					Recalculate();
				else
					CalculateZeroRange();
				}
			}

		//============================================================================*
		// PressureCorrectionFactor Property
		//============================================================================*

		private double PressureCorrectionFactor
			{
			get
				{
				return (((UseStationPressure ? StationPressure : Pressure) - cm_dStandardPressure) / cm_dStandardPressure);
				}
			}

		//============================================================================*
		// Range Property
		//============================================================================*

		public double Range
			{
			get
				{
				return (m_dRange);
				}
			set
				{
				m_dRange = value;

				if (m_fActive)
					Calculate();
				else
					CalculateZeroRange();
				}
			}

		//============================================================================*
		// Recalculate()
		//============================================================================*

		public void Recalculate()
			{
			CalculateZeroRange();

			Calculate();
			}

		//============================================================================*
		// RemainingVelocity Property
		//============================================================================*

		public double RemainingVelocity
			{
			get
				{
				return (m_dRemainingVelocity);
				}
			}

		//============================================================================*
		// ScopeClick Property
		//============================================================================*

		public double ScopeClick
			{
			get
				{
				return (m_dScopeClick);
				}
			set
				{
				m_dScopeClick = value;
				}
			}

		//============================================================================*
		// ScopeClicks Property
		//============================================================================*

		public string ScopeClicks
			{
			get
				{
				return (m_strScopeClicks);
				}
			}

		//============================================================================*
		// SightHeight Property
		//============================================================================*

		public double SightHeight
			{
			get
				{
				return (m_dSightHeight);
				}
			set
				{
				m_dSightHeight = value;

				if (m_fActive)
					Recalculate();
				else
					CalculateZeroRange();
				}
			}

		//============================================================================*
		// Slope Property
		//============================================================================*

		public double Slope
			{
			get
				{
				return (m_dSlope);
				}
			set
				{
				m_dSlope = value;
				}
			}

		//============================================================================*
		// SpeedOfSoundInFPS Property
		//============================================================================*

		public double SpeedOfSoundInFPS
			{
			get
				{
				return (cConversions.MSToFPS(SpeedOfSoundInMS));
				}
			}

		//============================================================================*
		// SpeedOfSoundInMS Property
		//============================================================================*

		public double SpeedOfSoundInMS
			{
			get
				{
				return (331.3 + (0.6 * (double) cConversions.FahrenheitToCelsius(Temperature)));
				}
			}

		//============================================================================*
		// TargetRange Property
		//============================================================================*

		public double TargetRange
			{
			get
				{
				return (m_dTargetRange);
				}
			set
				{
				m_dTargetRange = value;
				}
			}

		//============================================================================*
		// Temperature Property
		//============================================================================*

		public override int Temperature
			{
			set
				{
				base.Temperature = value;

				if (m_fActive)
					Recalculate();
				else
					CalculateZeroRange();
				}
			}

		//============================================================================*
		// TemperatureCorrectionFactor Property
		//============================================================================*

		private double TemperatureCorrectionFactor
			{
			get
				{
				double dAltitude = UseDensityAltitude ? DensityAltitude : Altitude;

				double dStandardTemperature = -0.0036 * dAltitude + 59.0;

				return (((double) Temperature - dStandardTemperature) / (459.6 + dStandardTemperature));
				}
			}

		//============================================================================*
		// TimeOfFlight Property
		//============================================================================*

		public double TimeOfFlight
			{
			get
				{
				return (m_dTimeOfFlight);
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

		//============================================================================*
		// TurretTypeString Property
		//============================================================================*

		public string TurretTypeString
			{
			get
				{
				string strString = "MOA:";

				if (m_eTurretType == cFirearm.eTurretType.MilDot)
					strString = "Mils";

				return (strString);
				}
			}

		//============================================================================*
		// WindDrift Property
		//============================================================================*

		public double WindDrift
			{
			get
				{
				return (m_dWindDrift);
				}
			}

		//============================================================================*
		// WindDriftMOA Property
		//============================================================================*

		public double WindDriftMOA
			{
			get
				{
				return (m_dWindDriftMOA);
				}
			}

		//============================================================================*
		// WindSpeed Property
		//============================================================================*

		public override int WindSpeed
			{
			set
				{
				base.WindSpeed = value;

				if (m_fActive)
					Recalculate();
				}
			}

		//============================================================================*
		// ZeroAngle Property
		//============================================================================*

		public double ZeroAngle
			{
			get
				{
				double dAngle = Math.Atan(m_dSightHeight / (m_dRange * 36.0));

				return (dAngle);
				}
			}

		//============================================================================*
		// ZeroRange Property
		//============================================================================*

		public double ZeroRange
			{
			get
				{
				return (m_dZeroRange);
				}
			set
				{
				m_dZeroRange = value;

				if (m_fActive)
					Recalculate();
				else
					CalculateZeroRange();
				}
			}
		}
	}
