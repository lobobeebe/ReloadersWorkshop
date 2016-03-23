//============================================================================*
// cConversions.cs
//
// Copyright © 2013-2016, Kevin S. Beebe
// All Rights Reserved
//============================================================================*

//============================================================================*
// .Net Using Statements
//============================================================================*

using System;

//============================================================================*
// Namespace
//============================================================================*

namespace CommonLib.Conversions
	{
	//============================================================================*
	// cConversions Class
	//============================================================================*

	public static class cConversions
		{
		//============================================================================*
		// CelsiusToFahrenheit()
		//============================================================================*

		static public double CelsiusToFahrenheit(double dCelsius)
			{
			return ((dCelsius * 1.8) + 32.0);
			}

		//============================================================================*
		// CentimetersToInches()
		//============================================================================*

		static public double CentimetersToInches(double dCentimeters)
			{
			return (dCentimeters * Math.Round(0.39370, 5));
			}

		//============================================================================*
		// CentimetersToFeet()
		//============================================================================*

		static public double CentimetersToFeet(double dCentimeters, int nNumDecimals = 3)
			{
			return (Math.Round(dCentimeters * Math.Round(0.032808, 6), nNumDecimals));
			}

		//============================================================================*
		// CentimetersToKilometers()
		//============================================================================*

		static public double CentimetersToKilometers(double dCentimeters, int nNumDecimals = 3)
			{
			return (Math.Round(dCentimeters / Math.Round(100000.0, 1), nNumDecimals));
			}

		//============================================================================*
		// CentimetersToMeters()
		//============================================================================*

		static public double CentimetersToMeters(double dCentimeters, int nNumDecimals = 3)
			{
			return (Math.Round(dCentimeters / Math.Round(100.0, 1), nNumDecimals));
			}

		//============================================================================*
		// CentimetersToMiles()
		//============================================================================*

		static public double CentimetersToMiles(double dCentimeters, int nNumDecimals = 3)
			{
			return (Math.Round(FeetToMiles(CentimetersToFeet(dCentimeters, nNumDecimals), nNumDecimals), nNumDecimals));
			}

		//============================================================================*
		// CentimetersToMillimeters()
		//============================================================================*

		static public double CentimetersToMillimeters(double dCentimeters, int nNumDecimals = 3)
			{
			return (Math.Round(dCentimeters / Math.Round(0.1, 1), nNumDecimals));
			}

		//============================================================================*
		// CentimetersToYards()
		//============================================================================*

		static public double CentimetersToYards(double dCentimeters, int nNumDecimals = 3)
			{
			return (Math.Round(dCentimeters * Math.Round(0.010936, 6), nNumDecimals));
			}

		//============================================================================*
		// DegreesToMOA()
		//============================================================================*

		static public double DegreesToMOA(double dDegrees, int nNumDecimals = 3)
			{
			return (Math.Round(dDegrees * 60.0, nNumDecimals));
			}

		//============================================================================*
		// DegreesToRadians()
		//============================================================================*

		static public double DegreesToRadians(double dDegrees, int nNumDecimals = 3)
			{
			return (Math.Round(dDegrees * (Math.PI / 180.0), nNumDecimals));
			}

		//============================================================================*
		// FahrenheitToCelsius() - int
		//============================================================================*

		static public int FahrenheitToCelsius(int nFahrenheit)
			{
			return ((int) Math.Round(((double) nFahrenheit - 32.0) / 1.8, 0));
			}

		//============================================================================*
		// FahrenheitToCelsius() - double
		//============================================================================*

		static public double FahrenheitToCelsius(double dFahrenheit)
			{
			return ((dFahrenheit - 32.0) / 1.8);
			}

		//============================================================================*
		// FeetToCentimeters()
		//============================================================================*

		static public double FeetToCentimeters(double dFeet, int nNumDecimals = 3)
			{
			return (Math.Round(dFeet / Math.Round(0.032808, 6), nNumDecimals));
			}

		//============================================================================*
		// FeetToInches()
		//============================================================================*

		static public double FeetToInches(double dFeet, int nNumDecimals = 3)
			{
			return (Math.Round(dFeet * Math.Round(12.0, 1), nNumDecimals));
			}

		//============================================================================*
		// FeetToKilometers()
		//============================================================================*

		static public double FeetToKilometers(double dFeet, int nNumDecimals = 3)
			{
			return (Math.Round(dFeet / Math.Round(3280.8, 1), nNumDecimals));
			}

		//============================================================================*
		// FeetToMeters()
		//============================================================================*

		static public double FeetToMeters(double dFeet)
			{
			return (dFeet / Math.Round(3.2808, 4));
			}

		//============================================================================*
		// FeetToMiles()
		//============================================================================*

		static public double FeetToMiles(double dFeet, int nNumDecimals = 3)
			{
			return (Math.Round(dFeet / 5280, nNumDecimals));
			}

		//============================================================================*
		// FeetToMillimeters()
		//============================================================================*

		static public double FeetToMillimeters(double dFeet, int nNumDecimals = 3)
			{
			return (Math.Round(dFeet / Math.Round(0.0032808, 7), nNumDecimals));
			}

		//============================================================================*
		// FeetToYards()
		//============================================================================*

		static public double FeetToYards(double dFeet, int nNumDecimals = 3)
			{
			return (Math.Round(dFeet / Math.Round(3.0, 1), nNumDecimals));
			}

		//============================================================================*
		// FPSToKPH() - Double
		//============================================================================*

		static public double FPSToKPH(double nFPS, int nNumDecimals = 3)
			{
			return (Math.Round(nFPS * Math.Round(1.09728, 5), nNumDecimals));
			}

		//============================================================================*
		// FPSToMPH() - Double
		//============================================================================*

		static public double FPSToMPH(double nFPS, int nNumDecimals = 3)
			{
			return (Math.Round(nFPS * Math.Round(0.681818182, 9), nNumDecimals));
			}

		//============================================================================*
		// FPSToMS() - Double
		//============================================================================*

		static public double FPSToMS(double nFPS, int nNumDecimals = 3)
			{
			return (Math.Round(nFPS * Math.Round(0.30480, 5), nNumDecimals));
			}

		//============================================================================*
		// FPSToMS() - Int
		//============================================================================*

		static public int FPSToMS(int nFPS, int nNumDecimals = 3)
			{
			return ((int)Math.Round(((double)nFPS * Math.Round(0.30480, 5)), nNumDecimals));
			}

		//============================================================================*
		// GrainsToGrams()
		//============================================================================*

		static public double GrainsToGrams(double dGrains, int nNumDecimals = 3)
			{
			return (Math.Round(dGrains * Math.Round(0.06479891, 8), nNumDecimals));
			}

		//============================================================================*
		// GrainsToMilligrams()
		//============================================================================*

		static public double GrainsToMilligrams(double dGrains, int nNumDecimals = 3)
			{
			return (Math.Round(dGrains / Math.Round(0.015432, 6), nNumDecimals));
			}

		//============================================================================*
		// GrainsToKilos()
		//============================================================================*

		static public double GrainsToKilos(double dGrains, int nNumDecimals = 3)
			{
			return (Math.Round(PoundsToKilos(GrainsToPounds(dGrains)), nNumDecimals));
			}

		//============================================================================*
		// GrainsToOunces()
		//============================================================================*

		static public double GrainsToOunces(double dGrains, int nNumDecimals = 3)
			{
			return (Math.Round(dGrains * Math.Round(0.0022857, 7), nNumDecimals));
			}

		//============================================================================*
		// GrainsToPounds()
		//============================================================================*

		static public double GrainsToPounds(double dGrains)
			{
			return (dGrains / Math.Round(7000.0, 1));
			}

		//============================================================================*
		// GramsToGrains()
		//============================================================================*

		static public double GramsToGrains(double dGrams, int nNumDecimals = 3)
			{
			return (Math.Round(dGrams * Math.Round(15.432, 3), nNumDecimals));
			}

		//============================================================================*
		// GramsToKilos()
		//============================================================================*

		static public double GramsToKilos(double dGrams)
			{
			return (dGrams / Math.Round(1000.0, 1));
			}

		//============================================================================*
		// GramsToMilligrams()
		//============================================================================*

		static public double GramsToMilligrams(double dGrams, int nNumDecimals = 3)
			{
			return (Math.Round(dGrams / Math.Round(0.001, 3), nNumDecimals));
			}

		//============================================================================*
		// GramsToOunces()
		//============================================================================*

		static public double GramsToOunces(double dGrams, int nNumDecimals = 3)
			{
			return (Math.Round(dGrams * Math.Round(0.035274, 6), nNumDecimals));
			}

		//============================================================================*
		// GramsToPounds()
		//============================================================================*

		static public double GramsToPounds(double dGrams, int nNumDecimals = 3)
			{
			return (Math.Round(KilosToPounds(GramsToKilos(dGrams)), nNumDecimals));
			}

		//============================================================================*
		// InchesToCentimeters()
		//============================================================================*

		static public double InchesToCentimeters(double dInches, int nNumDecimals = 3)
			{
			return (Math.Round(dInches / Math.Round(0.39370, 5), nNumDecimals));
			}

		//============================================================================*
		// InchesToFeet()
		//============================================================================*

		static public double InchesToFeet(double dInches, int nNumDecimals = 3)
			{
			return (Math.Round(dInches / Math.Round(12.0, 1), nNumDecimals));
			}

		//============================================================================*
		// InchesToKilometers()
		//============================================================================*

		static public double InchesToKilometers(double dInches, int nNumDecimals = 3)
			{
			return (Math.Round(dInches / Math.Round(39370.0, 1), nNumDecimals));
			}

		//============================================================================*
		// InchesToMeters()
		//============================================================================*

		static public double InchesToMeters(double dInches, int nNumDecimals = 3)
			{
			return (Math.Round(dInches / Math.Round(39.370, 3), nNumDecimals));
			}

		//============================================================================*
		// InchesToMiles()
		//============================================================================*

		static public double InchesToMiles(double dInches, int nNumDecimals = 3)
			{
			return (Math.Round(FeetToMiles(InchesToFeet(dInches)), nNumDecimals));
			}

		//============================================================================*
		// InchesToMillimeters()
		//============================================================================*

		static public double InchesToMillimeters(double dInches)
			{
			return (dInches / Math.Round(0.039370, 6));
			}

		//============================================================================*
		// InchesToYards()
		//============================================================================*

		static public double InchesToYards(double dInches)
			{
			return (dInches / Math.Round(36.0, 1));
			}

		//============================================================================*
		// InHgToMillibars()
		//============================================================================*

		static public double InHgToMillibars(double dInHg)
			{
			return (dInHg * Math.Round(33.8638866667, 10));
			}

		//============================================================================*
		// KilometersToCentimeters()
		//============================================================================*

		static public double KilometersToCentimeters(double dKilometers, int nNumDecimals = 3)
			{
			return (Math.Round(dKilometers * Math.Round(100000.0, 1), nNumDecimals));
			}

		//============================================================================*
		// KilometersToFeet()
		//============================================================================*

		static public double KilometersToFeet(double dKilometers, int nNumDecimals = 3)
			{
			return (Math.Round(dKilometers * Math.Round(3280.8, 1), nNumDecimals));
			}

		//============================================================================*
		// KilometersToInches()
		//============================================================================*

		static public double KilometersToInches(double dKilometers, int nNumDecimals = 3)
			{
			return (Math.Round(dKilometers * Math.Round(39370.0, 1), nNumDecimals));
			}

		//============================================================================*
		// KilometersToMeters()
		//============================================================================*

		static public double KilometersToMeters(double dKilometers)
			{
			return (dKilometers * Math.Round(1000.0, 1));
			}

		//============================================================================*
		// KilometersToMiles()
		//============================================================================*

		static public double KilometersToMiles(double dKilometers)
			{
			return (dKilometers * Math.Round(0.62137, 5));
			}

		//============================================================================*
		// KilometersToMillimeters()
		//============================================================================*

		static public double KilometersToMillimeters(double dKilometers, int nNumDecimals = 3)
			{
			return (Math.Round(dKilometers * Math.Round(1000000.0, 1), nNumDecimals));
			}

		//============================================================================*
		// KilometersToYards()
		//============================================================================*

		static public double KilometersToYards(double dKilometers, int nNumDecimals = 3)
			{
			return (Math.Round(dKilometers * Math.Round(1093.6, 1), nNumDecimals));
			}

		//============================================================================*
		// KilosToGrains()
		//============================================================================*

		static public double KilosToGrains(double dKilos, int nNumDecimals = 3)
			{
			return (Math.Round(PoundsToGrains(KilosToPounds(dKilos)), nNumDecimals));
			}

		//============================================================================*
		// KilosToGrams()
		//============================================================================*

		static public double KilosToGrams(double dKilos)
			{
			return (dKilos * Math.Round(1000.0, 1));
			}

		//============================================================================*
		// KilosToMilligrams()
		//============================================================================*

		static public double KilosToMilligrams(double dKilos, int nNumDecimals = 3)
			{
			return (Math.Round(dKilos * Math.Round(1000000.0, 1), nNumDecimals));
			}

		//============================================================================*
		// KilosToOunces()
		//============================================================================*

		static public double KilosToOunces(double dKilos, int nNumDecimals = 3)
			{
			return (Math.Round(dKilos * Math.Round(35.274, 3), nNumDecimals));
			}

		//============================================================================*
		// KilosToPounds()
		//============================================================================*

		static public double KilosToPounds(double dKilos)
			{
			return (dKilos * Math.Round(2.2046, 4));
			}

		//============================================================================*
		// KPHToMPH() - Double
		//============================================================================*

		static public double KPHToMPH(double dKPH, int nNumDecimals = 3)
			{
			return (Math.Round((dKPH * Math.Round(0.62137119, 8)), nNumDecimals));
			}

		//============================================================================*
		// MetersToCentimeters()
		//============================================================================*

		static public double MetersToCentimeters(double dMeters, int nDecimals = 3)
			{
			return (Math.Round((dMeters / Math.Round(0.01, 2)), nDecimals));
			}

		//============================================================================*
		// MetersToFeet()
		//============================================================================*

		static public double MetersToFeet(double dMeters)
			{
			return (dMeters * Math.Round(3.2808, 4));
			}

		//============================================================================*
		// MetersToInches()
		//============================================================================*

		static public double MetersToInches(double dMeters, int nNumDecimals = 3)
			{
			return (Math.Round(dMeters * Math.Round(39.370, 3), nNumDecimals));
			}

		//============================================================================*
		// MetersToKilometers()
		//============================================================================*

		static public double MetersToKilometers(double dMeters)
			{
			return (dMeters / Math.Round(1000.0, 1));
			}

		//============================================================================*
		// MetersToMiles()
		//============================================================================*

		static public double MetersToMiles(double dMeters, int nDecimals = 3)
			{
			return (Math.Round((dMeters * Math.Round(0.00062137, 8)), nDecimals));
			}

		//============================================================================*
		// MetersToMillimeters()
		//============================================================================*

		static public double MetersToMillimeters(double dMeters, int nDecimals = 3)
			{
			return (Math.Round((dMeters / Math.Round(0.001, 3)), nDecimals));
			}

		//============================================================================*
		// MetersToYards() - Double
		//============================================================================*

		static public double MetersToYards(double dMeters, int nDecimals = 3)
			{
			return (Math.Round((dMeters * Math.Round(1.0936, 4)), nDecimals));
			}

		//============================================================================*
		// MilesToCentimeters()
		//============================================================================*

		static public double MilesToCentimeters(double dMiles, int nNumDecimals = 3)
			{
			return (Math.Round(dMiles * YardsToCentimeters(MilesToYards(dMiles, nNumDecimals), nNumDecimals), nNumDecimals));
			}

		//============================================================================*
		// MilesToFeet()
		//============================================================================*

		static public double MilesToFeet(double dMiles, int nNumDecimals = 3)
			{
			return (Math.Round(dMiles * Math.Round(5280.0, 1), nNumDecimals));
			}

		//============================================================================*
		// MilesToInches()
		//============================================================================*

		static public double MilesToInches(double dMiles, int nNumDecimals = 3)
			{
			return (Math.Round(dMiles * Math.Round(63360.0, 1), nNumDecimals));
			}

		//============================================================================*
		// MilesToKilometers()
		//============================================================================*

		static public double MilesToKilometers(double dMiles, int nNumDecimals = 3)
			{
			return (Math.Round(dMiles / Math.Round(0.62137, 5), nNumDecimals));
			}

		//============================================================================*
		// MilesToMeters()
		//============================================================================*

		static public double MilesToMeters(double dMiles, int nNumDecimals = 3)
			{
			return (Math.Round(dMiles / Math.Round(0.00062137, 8), nNumDecimals));
			}

		//============================================================================*
		// MilesToMillimeters()
		//============================================================================*

		static public double MilesToMillimeters(double dMiles, int nNumDecimals = 3)
			{
			return (Math.Round(dMiles * YardsToMillimeters(MilesToYards(dMiles, nNumDecimals), nNumDecimals), nNumDecimals));
			}

		//============================================================================*
		// MilesToYards()
		//============================================================================*

		static public double MilesToYards(double dMiles, int nNumDecimals = 3)
			{
			return (Math.Round(dMiles * Math.Round(1760.0, 1), nNumDecimals));
			}

		//============================================================================*
		// MillibarsToInHg()
		//============================================================================*

		static public double MillibarsToInHg(double dMillibars)
			{
			return (dMillibars * Math.Round(0.0295301, 7));
			}

		//============================================================================*
		// MilligramsToGrains()
		//============================================================================*

		static public double MilligramsToGrains(double dMilligrams, int nNumDecimals = 3)
			{
			return (Math.Round(dMilligrams * Math.Round(0.0154323584, 10), nNumDecimals));
			}

		//============================================================================*
		// MilligramsToGrams()
		//============================================================================*

		static public double MilligramsToGrams(double dMilligrams, int nNumDecimals = 3)
			{
			return (Math.Round(dMilligrams * Math.Round(0.001, 3), nNumDecimals));
			}

		//============================================================================*
		// MilligramsToKilos()
		//============================================================================*

		static public double MilligramsToKilos(double dMilligrams, int nNumDecimals = 3)
			{
			return (Math.Round(dMilligrams * Math.Round(0.000001, 6), nNumDecimals));
			}

		//============================================================================*
		// MilligramsToOunces()
		//============================================================================*

		static public double MilligramsToOunces(double dMilligrams, int nNumDecimals = 3)
			{
			return (Math.Round(dMilligrams * Math.Round(0.000035274, 9), nNumDecimals));
			}

		//============================================================================*
		// MilligramsToPounds()
		//============================================================================*

		static public double MilligramsToPounds(double dMilligrams, int nNumDecimals = 3)
			{
			return (Math.Round(MilligramsToOunces(dMilligrams, nNumDecimals) * Math.Round(16.0, 1), nNumDecimals));
			}

		//============================================================================*
		// MillimetersToCentimeters()
		//============================================================================*

		static public double MillimetersToCentimeters(double dMillimeters, int nNumDecimals = 3)
			{
			return (Math.Round(dMillimeters / Math.Round(10.0, 1), nNumDecimals));
			}

		//============================================================================*
		// MillimetersToFeet()
		//============================================================================*

		static public double MillimetersToFeet(double dMillimeters, int nNumDecimals = 3)
			{
			return (Math.Round(dMillimeters * Math.Round(0.0032808, 7), nNumDecimals));
			}

		//============================================================================*
		// MillimetersToInches()
		//============================================================================*

		static public double MillimetersToInches(double dMillimeters)
			{
			return (dMillimeters * Math.Round(0.039370, 6));
			}

		//============================================================================*
		// MillimetersToKilometers()
		//============================================================================*

		static public double MillimetersToKilometers(double dMillimeters, int nNumDecimals = 3)
			{
			return (Math.Round(dMillimeters / Math.Round(1000000.0, 1), nNumDecimals));
			}

		//============================================================================*
		// MillimetersToMeters()
		//============================================================================*

		static public double MillimetersToMeters(double dMillimeters)
			{
			return (dMillimeters / Math.Round(1000.0, 1));
			}

		//============================================================================*
		// MillimetersToMiles()
		//============================================================================*

		static public double MillimetersToMiles(double dMillimeters, int nNumDecimals = 3)
			{
			return (Math.Round(FeetToMiles(MillimetersToFeet(dMillimeters, nNumDecimals), nNumDecimals), nNumDecimals));
			}

		//============================================================================*
		// MillimetersToYards()
		//============================================================================*

		static public double MillimetersToYards(double dMillimeters, int nNumDecimals = 3)
			{
			return (Math.Round(dMillimeters * Math.Round(0.0010936, 7), nNumDecimals));
			}

		//============================================================================*
		// MilsToMOA()
		//============================================================================*

		static public double MilsToMOA(double dMils, int nNumDecimals = 3)
			{
			return (Math.Round(dMils * Math.Round(3.438395, 6), nNumDecimals));
			}

		//============================================================================*
		// MOAToCentimeters()
		//============================================================================*

		static public double MOAToCentimeters(double dMOA, double dMeters, int nNumDecimals = 3)
			{
			return (InchesToCentimeters(MOAToInches(dMOA, MetersToYards(dMeters, nNumDecimals), nNumDecimals)));
			}

		//============================================================================*
		// MOAToDegrees()
		//============================================================================*

		static public double MOAToDegrees(double dMOA, int nNumDecimals = 3)
			{
			return (Math.Round(dMOA / 60.0, nNumDecimals));
			}

		//============================================================================*
		// MOAToInches()
		//============================================================================*

		static public double MOAToInches(double dMOA, double dYards, int nNumDecimals = 3)
			{
			return (Math.Round((Math.Round(dMOA, nNumDecimals) * Math.Round(1.047, 3)) * (dYards / 100.0), nNumDecimals));
			}

		//============================================================================*
		// MOAToMils()
		//============================================================================*

		static public double MOAToMils(double dMOA, int nNumDecimals = 3)
			{
			return (Math.Round(dMOA / Math.Round(3.438395, 6), nNumDecimals));
			}

		//============================================================================*
		// MOAToRadians()
		//============================================================================*

		static public double MOAToRadians(double dMOA, int nNumDecimals = 3)
			{
			return (Math.Round((dMOA / 60.0) * (180 / Math.PI), nNumDecimals));
			}

		//============================================================================*
		// MPHToFPS() - Double
		//============================================================================*

		static public double MPHToFPS(double dMPH, int nNumDecimals = 3)
			{
			return (Math.Round((dMPH * Math.Round(1.4666667, 7)), nNumDecimals));
			}

		//============================================================================*
		// MPHToKPH() - Double
		//============================================================================*

		static public double MPHToKPH(double dMPH, int nNumDecimals = 3)
			{
			return (Math.Round((dMPH * Math.Round(1.609344, 6)), nNumDecimals));
			}

		//============================================================================*
		// MPHToMS() - Double
		//============================================================================*

		static public double MPHToMS(double dMPH, int nNumDecimals = 3)
			{
			return (Math.Round((dMPH * Math.Round(0.44704, 5)), nNumDecimals));
			}

		//============================================================================*
		// MSToFPS() - Double
		//============================================================================*

		static public double MSToFPS(double dMS, int nNumDecimals = 3)
			{
			return (Math.Round((dMS * Math.Round(3.28083989501, 11)), nNumDecimals));
			}

		//============================================================================*
		// MSToFPS() - Int
		//============================================================================*

		static public int MSToFPS(int dMS, int nNumDecimals = 3)
			{
			return ((int)Math.Round(((double)dMS * Math.Round(0.30480, 5)), nNumDecimals));
			}

		//============================================================================*
		// MSToKPH() - Double
		//============================================================================*

		static public double MSToKPH(double dMS, int nNumDecimals = 3)
			{
			return (Math.Round((dMS * Math.Round(3.6, 1)), nNumDecimals));
			}

		//============================================================================*
		// MSToMPH() - Double
		//============================================================================*

		static public double MSToMPH(double dMS, int nNumDecimals = 3)
			{
			return (Math.Round((dMS * Math.Round(2.2369363, 7)), nNumDecimals));
			}

		//============================================================================*
		// OuncesToGrains()
		//============================================================================*

		static public double OuncesToGrains(double dOunces, int nNumDecimals = 3)
			{
			return (Math.Round(dOunces * Math.Round(437.5, 1), nNumDecimals));
			}

		//============================================================================*
		// OuncesToGrams()
		//============================================================================*

		static public double OuncesToGrams(double dOunces, int nNumDecimals = 3)
			{
			return (Math.Round(dOunces / Math.Round(0.035274, 6), nNumDecimals));
			}

		//============================================================================*
		// OuncesToKilos()
		//============================================================================*

		static public double OuncesToKilos(double dOunces, int nNumDecimals = 3)
			{
			return (Math.Round(dOunces / Math.Round(35.274, 3), nNumDecimals));
			}

		//============================================================================*
		// OuncesToMilligrams()
		//============================================================================*

		static public double OuncesToMilligrams(double dOunces, int nNumDecimals = 3)
			{
			return (GramsToMilligrams(OuncesToGrams(dOunces, nNumDecimals), nNumDecimals));
			}

		//============================================================================*
		// OuncesToPounds()
		//============================================================================*

		static public double OuncesToPounds(double dOunces, int nNumDecimals = 3)
			{
			return (dOunces * Math.Round(0.0625, 4));
			}

		//============================================================================*
		// PoundsToGrams()
		//============================================================================*

		static public double PoundsToGrams(double dPounds, int nNumDecimals = 3)
			{
			return (Math.Round(dPounds * Math.Round(453.59237, 5), nNumDecimals));
			}

		//============================================================================*
		// PoundsToGrains()
		//============================================================================*

		static public double PoundsToGrains(double dPounds)
			{
			return (dPounds * Math.Round(7000.0, 1));
			}

		//============================================================================*
		// PoundsToKilos()
		//============================================================================*

		static public double PoundsToKilos(double dPounds)
			{
			return (dPounds * Math.Round(0.45359237, 8));
			}

		//============================================================================*
		// PoundsToMilligrams()
		//============================================================================*

		static public double PoundsToMilligrams(double dPounds, int nNumDecimals = 3)
			{
			return (Math.Round(dPounds * Math.Round(453592.37, 2), nNumDecimals));
			}

		//============================================================================*
		// PoundsToOunces()
		//============================================================================*

		static public double PoundsToOunces(double dPounds, int nNumDecimals = 3)
			{
			return (Math.Round(dPounds * Math.Round(16.0, 1), nNumDecimals));
			}

		//============================================================================*
		// RadiansToDegress()
		//============================================================================*

		static public double RadiansToDegrees(double dRadians, int nNumDecimals = 3)
			{
			return (Math.Round(dRadians * (180.0 / Math.PI), nNumDecimals));
			}

		//============================================================================*
		// RadiansToMOA()
		//============================================================================*

		static public double RadiansToMOA(double dRadians, int nNumDecimals = 3)
			{
			return (Math.Round(dRadians * 60.0 * (180.0 / Math.PI), nNumDecimals));
			}

		//============================================================================*
		// YardsToCentimeters()
		//============================================================================*

		static public double YardsToCentimeters(double dYards, int nNumDecimals = 3)
			{
			return (Math.Round(dYards / Math.Round(0.010936, 6), nNumDecimals));
			}

		//============================================================================*
		// YardsToFeet()
		//============================================================================*

		static public double YardsToFeet(double dYards, int nNumDecimals = 3)
			{
			return (Math.Round(dYards * Math.Round(3.0, 1), nNumDecimals));
			}

		//============================================================================*
		// YardsToInches()
		//============================================================================*

		static public double YardsToInches(double dYards, int nNumDecimals = 3)
			{
			return (Math.Round(dYards * Math.Round(36.0, 1), nNumDecimals));
			}

		//============================================================================*
		// YardsToKilometers()
		//============================================================================*

		static public double YardsToKilometers(double dYards, int nNumDecimals = 3)
			{
			return (Math.Round(dYards / Math.Round(1093.6, 1), nNumDecimals));
			}

		//============================================================================*
		// YardsToMeters() - Double
		//============================================================================*

		static public double YardsToMeters(double dYards, int nDecimals = 3)
			{
			return (Math.Round(dYards / Math.Round(1.0936, 4), nDecimals));
			}

		//============================================================================*
		// YardsToMiles()
		//============================================================================*

		static public double YardsToMiles(double dYards, int nDecimals = 3)
			{
			return (Math.Round(dYards * Math.Round(0.00056818, 8), nDecimals));
			}

		//============================================================================*
		// YardsToMillimeters()
		//============================================================================*

		static public double YardsToMillimeters(double dYards, int nNumDecimals = 3)
			{
			return (Math.Round(dYards / Math.Round(0.0010936, 7), nNumDecimals));
			}
		}
	}
