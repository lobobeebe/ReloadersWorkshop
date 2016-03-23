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
// CommonLib Using Statements
//============================================================================*

using CommonLib.Conversions;

//============================================================================*
// Namespace
//============================================================================*

namespace ReloadersWorkShop.Ballistics
	{
	//============================================================================*
	// cAtmospherics Class
	//============================================================================*

	[Serializable]
	public class cAtmospherics
		{
		//============================================================================*
		// Public Enumerations
		//============================================================================*

		//----------------------------------------------------------------------------*
		// Temperature
		//----------------------------------------------------------------------------*

		public enum eTemperature
			{
			Fahrenheit = 0,
			Celcius
			}

		//============================================================================*
		// Private Data Members
		//============================================================================*

		private int m_nAltitude = 0;
		private double m_dPressure = 29.92;
		private int m_nTemperature = 59;
		private double m_dHumidity = 0.78;                      // 0.0 to 1.0 (percentage)

		private int m_nWindSpeed = 0;                           // MPH
		private int m_nWindDirection = 0;                       // Degrees

		//============================================================================*
		// cAtmospherics() - Default Constructor
		//============================================================================*

		public cAtmospherics()
			{
			}

		//============================================================================*
		// cAtmospherics() - Copy Constructor
		//============================================================================*

		public cAtmospherics(cAtmospherics Atmospherics)
			{
			m_nAltitude = Atmospherics.m_nAltitude;
			m_dPressure = Atmospherics.m_dPressure;
			m_nTemperature = Atmospherics.m_nTemperature;
			m_dHumidity = Atmospherics.m_dHumidity;

			m_nWindDirection = Atmospherics.m_nWindDirection;
			m_nWindSpeed = Atmospherics.m_nWindSpeed;
			}

		//============================================================================*
		// Altitude Property
		//============================================================================*

		public virtual int Altitude
			{
			get
				{
				return (m_nAltitude);
				}
			set
				{
				m_nAltitude = value;
				}
			}

		//============================================================================*
		// CrossWind Property
		//============================================================================*

		public double CrossWind
			{
			get
				{
				return (0.0 - Math.Sin(cConversions.DegreesToRadians((double) m_nWindDirection)) * (double) m_nWindSpeed);
				}
			}

		//============================================================================*
		// Density Altitude Property
		//============================================================================*

		public int DensityAltitude
			{
			get
				{
				double dDensityAltitude = 145442.16 * (1.0 - Math.Pow((m_dPressure * 17.326) / (459.67 + m_nTemperature), 0.235));

				return ((int) dDensityAltitude + m_nAltitude);
				}
			}

		//============================================================================*
		// HeadWind Property
		//============================================================================*

		public double HeadWind
			{
			get
				{
				return (Math.Cos(cConversions.DegreesToRadians(m_nWindDirection)) * m_nWindSpeed);
				}
			}

		//============================================================================*
		// Humidity Property
		//============================================================================*

		public virtual double Humidity
			{
			get
				{
				return (m_dHumidity);
				}
			set
				{
				m_dHumidity = value;
				}
			}

		//============================================================================*
		// Pressure Property
		//============================================================================*

		public virtual double Pressure
			{
			get
				{
				return (m_dPressure);
				}
			set
				{
				m_dPressure = value;
				}
			}

		//============================================================================*
		// StationPressure Property
		//============================================================================*

		public double StationPressure
			{
			get
				{
				double dMillibars = cConversions.InHgToMillibars(m_dPressure);
				double dKelvin = cConversions.FahrenheitToCelsius(m_nTemperature) + 273.15;
				double dMeters = cConversions.FeetToMeters(m_nAltitude);

				double dStationPressure = dMillibars * Math.Exp((0.0 - dMeters) / (dKelvin * 29.263));

				return (cConversions.MillibarsToInHg(dStationPressure));
				}
			}

		//============================================================================*
		// Temperature Property
		//============================================================================*

		public virtual int Temperature
			{
			get
				{
				return (m_nTemperature);
				}
			set
				{
				m_nTemperature = value;
				}
			}

		//============================================================================*
		// WindDirection Property
		//============================================================================*

		public virtual int WindDirection
			{
			get
				{
				return (m_nWindDirection);
				}
			set
				{
				m_nWindDirection = value;
				}
			}

		//============================================================================*
		// WindSpeed Property
		//============================================================================*

		public virtual int WindSpeed
			{
			get
				{
				return (m_nWindSpeed);
				}
			set
				{
				m_nWindSpeed = value;
				}
			}
		}
	}
