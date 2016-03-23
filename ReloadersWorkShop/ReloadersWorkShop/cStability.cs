//============================================================================*
// cStability.cs
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

namespace ReloadersWorkShop.Ballistics
	{
	//============================================================================*
	// cStabilityData class
	//============================================================================*

	[Serializable]
	public class cStability : cAtmospherics
		{
		//============================================================================*
		// Private Data Members
		//============================================================================*

		private double m_dBallisticCoefficient = 0.338;

		private double m_dBulletDiameter = 0.308;
		private double m_dBulletLength = 1.089;
		private double m_dBulletWeight = 150.0;

		private double m_dTwist = 10.0;

		private int m_nMuzzleVelocity = 2400;

		private double m_dAdjustedBC = 0.338;

		private bool m_fUseAltitude = true;
		private bool m_fUseDensityAltitude = true;
		private bool m_fUseStationPressure = true;

		//============================================================================*
		// cStability() - Default Constructor
		//============================================================================*

		public cStability()
			{
			}

		//============================================================================*
		// cStability() - Copy Constructor
		//============================================================================*

		public cStability(cStability Stability)
				: base(Stability)
			{
			m_fUseDensityAltitude = Stability.m_fUseDensityAltitude;

			m_dBallisticCoefficient = Stability.m_dBallisticCoefficient;
			m_dBulletDiameter = Stability.m_dBulletDiameter;
			m_dBulletLength = Stability.m_dBulletLength;
			m_dBulletWeight = Stability.m_dBulletWeight;

			m_dTwist = Stability.m_dTwist;
			m_nMuzzleVelocity = Stability.m_nMuzzleVelocity;

			m_dAdjustedBC = Stability.m_dAdjustedBC;

			m_fUseAltitude = Stability.m_fUseAltitude;
			m_fUseStationPressure = Stability.m_fUseStationPressure;
			}

		//============================================================================*
		// AdjustedBC Property
		//============================================================================*

		public double AdjustedBC
			{
			get
				{
				return (m_dAdjustedBC);
				}
			}

		//============================================================================*
		// BallisticCoefficient Property
		//============================================================================*

		public double BallisticCoefficient
			{
			get
				{
				return (m_dBallisticCoefficient);
				}
			set
				{
				m_dBallisticCoefficient = value;
				}
			}

		//============================================================================*
		// Bullet Property
		//============================================================================*
		public cBullet Bullet
			{
			set
				{
				m_dBulletDiameter = value.Diameter;
				m_dBallisticCoefficient = value.BallisticCoefficient;
				m_dBulletWeight = value.Weight;
				m_dBulletLength = value.Length;
				}
			}

		//============================================================================*
		// BulletDiameter Property
		//============================================================================*

		public double BulletDiameter
			{
			get
				{
				return (m_dBulletDiameter);
				}
			set
				{
				m_dBulletDiameter = value;
				}
			}

		//============================================================================*
		// BulletLength Property
		//============================================================================*

		public double BulletLength
			{
			get
				{
				return (m_dBulletLength);
				}
			set
				{
				m_dBulletLength = value;
				}
			}

		//============================================================================*
		// BulletWeight Property
		//============================================================================*

		public double BulletWeight
			{
			get
				{
				return (m_dBulletWeight);
				}
			set
				{
				m_dBulletWeight = value;
				}
			}

		//============================================================================*
		// MuzzleVelocity Property
		//============================================================================*

		public virtual int MuzzleVelocity
			{
			get
				{
				return (m_nMuzzleVelocity);
				}
			set
				{
				m_nMuzzleVelocity = value;
				}
			}

		//============================================================================*
		// RecommendedTwist Property
		//============================================================================*

		public double RecommendedTwist
			{
			get
				{
				double dTwist = 0.0;

				double dNumerator = 30.0 * m_dBulletWeight;

				double dLengthInCalibers = m_dBulletLength / m_dBulletDiameter;

				double dStabilityFactor = 2.0;

				double dDenominator = dStabilityFactor * m_dBulletDiameter * dLengthInCalibers * (1 + Math.Pow(dLengthInCalibers, 2.0));

				dTwist = Math.Sqrt(dNumerator / dDenominator);

				return (dTwist);
				}
			}

		//============================================================================*
		// StabilityFactor Property
		//============================================================================*

		public double StabilityFactor
			{
			get
				{
				// = (30 * C5) / ((C7 / C4) ^ 2 * C4 ^ 3 * C6 / C4 * (1 + (C6 / C4) ^ 2)) * (C8 / 2800) ^ (1 / 3) * ((C9 + 460) / (59 + 460) * 29.92 / C10)

				double dNumerator = 30.0 * m_dBulletWeight;

				double dTwistInCalibers = m_dTwist / m_dBulletDiameter;
				double dLengthInCalibers = m_dBulletLength / m_dBulletDiameter;

				double dStability = Math.Pow(dTwistInCalibers, 2.0) * Math.Pow(m_dBulletDiameter, 3) * dLengthInCalibers * (1.0 + Math.Pow(dLengthInCalibers, 2.0));

				double dVelocityModifier = Math.Pow((double) m_nMuzzleVelocity / 2800.0, 1.0 / 3.0);

				double dAtmosphericModifier = ((double) Temperature + 460.0) / (59.0 + 460.0) * 29.92 / Pressure;
				double dAltitudeModifier = Math.Exp(0.00003158 * (double) (m_fUseDensityAltitude ? DensityAltitude : Altitude));

				double dEnvironmentModifier = m_fUseAltitude ? dAltitudeModifier : dAtmosphericModifier;

				double dStabilityFactor = dNumerator / (Math.Pow(dTwistInCalibers, 2.0) * Math.Pow(m_dBulletDiameter, 3.0) * dLengthInCalibers * (1.0 + Math.Pow(dLengthInCalibers, 2.0))) * dVelocityModifier * dEnvironmentModifier;

				m_dAdjustedBC = m_dBallisticCoefficient;

				if (dStabilityFactor < 1.5)
					m_dAdjustedBC *= (dStabilityFactor / 1.5);

				return (dStabilityFactor);
				}
			}

		//============================================================================*
		// Twist Property
		//============================================================================*

		public double Twist
			{
			get
				{
				return (m_dTwist);
				}
			set
				{
				m_dTwist = value;
				}
			}

		//============================================================================*
		// UseAltitude Property
		//============================================================================*

		public bool UseAltitude
			{
			get
				{
				return (m_fUseAltitude);
				}
			set
				{
				m_fUseAltitude = value;
				}
			}

		//============================================================================*
		// UseDensityAltitude Property
		//============================================================================*

		public bool UseDensityAltitude
			{
			get
				{
				return (m_fUseDensityAltitude);
				}
			set
				{
				m_fUseDensityAltitude = value;
				}
			}

		//============================================================================*
		// UseStationPressure Property
		//============================================================================*

		public bool UseStationPressure
			{
			get
				{
				return (m_fUseStationPressure);
				}
			set
				{
				m_fUseStationPressure = value;
				}
			}
		}
	}
