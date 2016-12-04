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

		static public double CentimetersToFeet(double dCentimeters)
			{
			return (dCentimeters * Math.Round(0.032808, 6));
			}

		//============================================================================*
		// CentimetersToKilometers()
		//============================================================================*

		static public double CentimetersToKilometers(double dCentimeters)
			{
			return (dCentimeters / Math.Round(100000.0, 1));
			}

		//============================================================================*
		// CentimetersToMeters()
		//============================================================================*

		static public double CentimetersToMeters(double dCentimeters)
			{
			return (dCentimeters / Math.Round(100.0, 1));
			}

		//============================================================================*
		// CentimetersToMiles()
		//============================================================================*

		static public double CentimetersToMiles(double dCentimeters)
			{
			return (Math.Round(FeetToMiles(CentimetersToFeet(dCentimeters))));
			}

		//============================================================================*
		// CentimetersToMillimeters()
		//============================================================================*

		static public double CentimetersToMillimeters(double dCentimeters)
			{
			return (dCentimeters / Math.Round(0.1, 1));
			}

		//============================================================================*
		// CentimetersToYards()
		//============================================================================*

		static public double CentimetersToYards(double dCentimeters)
			{
			return (dCentimeters * Math.Round(0.010936, 6));
			}

		//============================================================================*
		// DegreesToMOA()
		//============================================================================*

		static public double DegreesToMOA(double dDegrees)
			{
			return (dDegrees * 60.0);
			}

		//============================================================================*
		// DegreesToRadians()
		//============================================================================*

		static public double DegreesToRadians(double dDegrees)
			{
			return (dDegrees * (Math.PI / 180.0));
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

		static public double FeetToCentimeters(double dFeet)
			{
			return (dFeet / Math.Round(0.032808, 6));
			}

		//============================================================================*
		// FeetToInches()
		//============================================================================*

		static public double FeetToInches(double dFeet)
			{
			return (dFeet * Math.Round(12.0, 1));
			}

		//============================================================================*
		// FeetToKilometers()
		//============================================================================*

		static public double FeetToKilometers(double dFeet)
			{
			return (dFeet / Math.Round(3280.8, 1));
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

		static public double FeetToMiles(double dFeet)
			{
			return (dFeet / 5280.0);
			}

		//============================================================================*
		// FeetToMillimeters()
		//============================================================================*

		static public double FeetToMillimeters(double dFeet)
			{
			return (dFeet / Math.Round(0.0032808, 7));
			}

		//============================================================================*
		// FeetToYards()
		//============================================================================*

		static public double FeetToYards(double dFeet)
			{
			return (dFeet / Math.Round(3.0, 1));
			}

		//============================================================================*
		// FPSToKPH() - Double
		//============================================================================*

		static public double FPSToKPH(double nFPS)
			{
			return (nFPS * Math.Round(1.09728, 5));
			}

		//============================================================================*
		// FPSToMPH() - Double
		//============================================================================*

		static public double FPSToMPH(double nFPS)
			{
			return (nFPS * Math.Round(0.681818182, 9));
			}

		//============================================================================*
		// FPSToMS() - Double
		//============================================================================*

		static public double FPSToMS(double dFPS)
			{
			return (dFPS * Math.Round(0.30480, 5));
			}

		//============================================================================*
		// FPSToMS() - Int
		//============================================================================*

		static public int FPSToMS(int nFPS)
			{
			return ((int)((double)nFPS * Math.Round(0.30480, 5)));
			}

		//============================================================================*
		// GrainsToGrams()
		//============================================================================*

		static public double GrainsToGrams(double dGrains)
			{
			return (dGrains * Math.Round(0.06479891, 8));
			}

		//============================================================================*
		// GrainsToMilligrams()
		//============================================================================*

		static public double GrainsToMilligrams(double dGrains)
			{
			return (dGrains / Math.Round(0.015432, 6));
			}

		//============================================================================*
		// GrainsToKilos()
		//============================================================================*

		static public double GrainsToKilos(double dGrains)
			{
			return (PoundsToKilos(GrainsToPounds(dGrains)));
			}

		//============================================================================*
		// GrainsToOunces()
		//============================================================================*

		static public double GrainsToOunces(double dGrains)
			{
			return (dGrains * Math.Round(0.0022857, 7));
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

		static public double GramsToGrains(double dGrams)
			{
			return (dGrams * Math.Round(15.432, 3));
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

		static public double GramsToMilligrams(double dGrams)
			{
			return (dGrams / Math.Round(0.001, 3));
			}

		//============================================================================*
		// GramsToOunces()
		//============================================================================*

		static public double GramsToOunces(double dGrams)
			{
			return (dGrams * Math.Round(0.035274, 6));
			}

		//============================================================================*
		// GramsToPounds()
		//============================================================================*

		static public double GramsToPounds(double dGrams)
			{
			return (KilosToPounds(GramsToKilos(dGrams)));
			}

		//============================================================================*
		// InchesToCentimeters()
		//============================================================================*

		static public double InchesToCentimeters(double dInches)
			{
			return (dInches / Math.Round(0.39370, 5));
			}

		//============================================================================*
		// InchesToFeet()
		//============================================================================*

		static public double InchesToFeet(double dInches)
			{
			return (dInches / Math.Round(12.0, 1));
			}

		//============================================================================*
		// InchesToKilometers()
		//============================================================================*

		static public double InchesToKilometers(double dInches)
			{
			return (dInches / Math.Round(39370.0, 1));
			}

		//============================================================================*
		// InchesToMeters()
		//============================================================================*

		static public double InchesToMeters(double dInches)
			{
			return (dInches / Math.Round(39.370, 3));
			}

		//============================================================================*
		// InchesToMiles()
		//============================================================================*

		static public double InchesToMiles(double dInches)
			{
			return (FeetToMiles(InchesToFeet(dInches)));
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

		static public double KilometersToCentimeters(double dKilometers)
			{
			return (dKilometers * Math.Round(100000.0, 1));
			}

		//============================================================================*
		// KilometersToFeet()
		//============================================================================*

		static public double KilometersToFeet(double dKilometers)
			{
			return (dKilometers * Math.Round(3280.8, 1));
			}

		//============================================================================*
		// KilometersToInches()
		//============================================================================*

		static public double KilometersToInches(double dKilometers)
			{
			return (dKilometers * Math.Round(39370.0, 1));
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

		static public double KilometersToMillimeters(double dKilometers)
			{
			return (dKilometers * Math.Round(1000000.0, 1));
			}

		//============================================================================*
		// KilometersToYards()
		//============================================================================*

		static public double KilometersToYards(double dKilometers)
			{
			return (dKilometers * Math.Round(1093.6, 1));
			}

		//============================================================================*
		// KilosToGrains()
		//============================================================================*

		static public double KilosToGrains(double dKilos)
			{
			return (PoundsToGrains(KilosToPounds(dKilos)));
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

		static public double KilosToMilligrams(double dKilos)
			{
			return (dKilos * Math.Round(1000000.0, 1));
			}

		//============================================================================*
		// KilosToOunces()
		//============================================================================*

		static public double KilosToOunces(double dKilos)
			{
			return (dKilos * Math.Round(35.274, 3));
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

		static public double KPHToMPH(double dKPH)
			{
			return ((dKPH * Math.Round(0.62137119, 8)));
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

		static public double MetersToInches(double dMeters)
			{
			return (dMeters * Math.Round(39.370, 3));
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

		static public double MetersToMiles(double dMeters)
			{
			return (dMeters * Math.Round(0.00062137, 8));
			}

		//============================================================================*
		// MetersToMillimeters()
		//============================================================================*

		static public double MetersToMillimeters(double dMeters)
			{
			return (dMeters / Math.Round(0.001, 3));
			}

		//============================================================================*
		// MetersToYards() - Double
		//============================================================================*

		static public double MetersToYards(double dMeters)
			{
			return (dMeters * Math.Round(1.0936, 4));
			}

		//============================================================================*
		// MilesToCentimeters()
		//============================================================================*

		static public double MilesToCentimeters(double dMiles)
			{
			return (dMiles * YardsToCentimeters(MilesToYards(dMiles)));
			}

		//============================================================================*
		// MilesToFeet()
		//============================================================================*

		static public double MilesToFeet(double dMiles)
			{
			return (dMiles * Math.Round(5280.0, 1));
			}

		//============================================================================*
		// MilesToInches()
		//============================================================================*

		static public double MilesToInches(double dMiles)
			{
			return (dMiles * Math.Round(63360.0, 1));
			}

		//============================================================================*
		// MilesToKilometers()
		//============================================================================*

		static public double MilesToKilometers(double dMiles)
			{
			return (dMiles / Math.Round(0.62137, 5));
			}

		//============================================================================*
		// MilesToMeters()
		//============================================================================*

		static public double MilesToMeters(double dMiles)
			{
			return (dMiles / Math.Round(0.00062137, 8));
			}

		//============================================================================*
		// MilesToMillimeters()
		//============================================================================*

		static public double MilesToMillimeters(double dMiles)
			{
			return (dMiles * YardsToMillimeters(MilesToYards(dMiles)));
			}

		//============================================================================*
		// MilesToYards()
		//============================================================================*

		static public double MilesToYards(double dMiles)
			{
			return (dMiles * Math.Round(1760.0, 1));
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

		static public double MilligramsToGrains(double dMilligrams)
			{
			return (dMilligrams * Math.Round(0.0154323584, 10));
			}

		//============================================================================*
		// MilligramsToGrams()
		//============================================================================*

		static public double MilligramsToGrams(double dMilligrams)
			{
			return (dMilligrams * Math.Round(0.001, 3));
			}

		//============================================================================*
		// MilligramsToKilos()
		//============================================================================*

		static public double MilligramsToKilos(double dMilligrams)
			{
			return (dMilligrams * Math.Round(0.000001, 6));
			}

		//============================================================================*
		// MilligramsToOunces()
		//============================================================================*

		static public double MilligramsToOunces(double dMilligrams)
			{
			return (dMilligrams * Math.Round(0.000035274, 9));
			}

		//============================================================================*
		// MilligramsToPounds()
		//============================================================================*

		static public double MilligramsToPounds(double dMilligrams)
			{
			return (MilligramsToOunces(dMilligrams) * Math.Round(16.0, 1));
			}

		//============================================================================*
		// MillimetersToCentimeters()
		//============================================================================*

		static public double MillimetersToCentimeters(double dMillimeters)
			{
			return (dMillimeters / Math.Round(10.0, 1));
			}

		//============================================================================*
		// MillimetersToFeet()
		//============================================================================*

		static public double MillimetersToFeet(double dMillimeters)
			{
			return (dMillimeters * Math.Round(0.0032808, 7));
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

		static public double MillimetersToKilometers(double dMillimeters)
			{
			return (dMillimeters / Math.Round(1000000.0, 1));
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

		static public double MillimetersToMiles(double dMillimeters)
			{
			return (FeetToMiles(MillimetersToFeet(dMillimeters)));
			}

		//============================================================================*
		// MillimetersToYards()
		//============================================================================*

		static public double MillimetersToYards(double dMillimeters)
			{
			return (dMillimeters * Math.Round(0.0010936, 7));
			}

		//============================================================================*
		// MilsToMOA()
		//============================================================================*

		static public double MilsToMOA(double dMils)
			{
			return (dMils * Math.Round(3.438395, 6));
			}

		//============================================================================*
		// MOAToCentimeters()
		//============================================================================*

		static public double MOAToCentimeters(double dMOA, double dMeters)
			{
			return (InchesToCentimeters(MOAToInches(dMOA, MetersToYards(dMeters))));
			}

		//============================================================================*
		// MOAToDegrees()
		//============================================================================*

		static public double MOAToDegrees(double dMOA)
			{
			return (dMOA / 60.0);
			}

		//============================================================================*
		// MOAToInches()
		//============================================================================*

		static public double MOAToInches(double dMOA, double dYards)
			{
			return ((dMOA * Math.Round(1.047, 3)) * (dYards / 100.0));
			}

		//============================================================================*
		// MOAToMils()
		//============================================================================*

		static public double MOAToMils(double dMOA)
			{
			return (dMOA / Math.Round(3.438395, 6));
			}

		//============================================================================*
		// MOAToRadians()
		//============================================================================*

		static public double MOAToRadians(double dMOA)
			{
			return ((dMOA / 60.0) * (180 / Math.PI));
			}

		//============================================================================*
		// MPHToFPS() - Double
		//============================================================================*

		static public double MPHToFPS(double dMPH)
			{
			return ((dMPH * Math.Round(1.4666667, 7)));
			}

		//============================================================================*
		// MPHToKPH() - Double
		//============================================================================*

		static public double MPHToKPH(double dMPH)
			{
			return ((dMPH * Math.Round(1.609344, 6)));
			}

		//============================================================================*
		// MPHToMS() - Double
		//============================================================================*

		static public double MPHToMS(double dMPH)
			{
			return ((dMPH * Math.Round(0.44704, 5)));
			}

		//============================================================================*
		// MSToFPS() - Double
		//============================================================================*

		static public double MSToFPS(double dMS)
			{
			return ((dMS * Math.Round(3.28083989501, 11)));
			}

		//============================================================================*
		// MSToFPS() - Int
		//============================================================================*

		static public int MSToFPS(int dMS)
			{
			return ((int)((double)dMS * Math.Round(0.30480, 5)));
			}

		//============================================================================*
		// MSToKPH() - Double
		//============================================================================*

		static public double MSToKPH(double dMS)
			{
			return ((dMS * Math.Round(3.6, 1)));
			}

		//============================================================================*
		// MSToMPH() - Double
		//============================================================================*

		static public double MSToMPH(double dMS)
			{
			return ((dMS * Math.Round(2.2369363, 7)));
			}

		//============================================================================*
		// OuncesToGrains()
		//============================================================================*

		static public double OuncesToGrains(double dOunces)
			{
			return (dOunces * Math.Round(437.5, 1));
			}

		//============================================================================*
		// OuncesToGrams()
		//============================================================================*

		static public double OuncesToGrams(double dOunces)
			{
			return (dOunces / Math.Round(0.035274, 6));
			}

		//============================================================================*
		// OuncesToKilos()
		//============================================================================*

		static public double OuncesToKilos(double dOunces)
			{
			return (dOunces / Math.Round(35.274, 3));
			}

		//============================================================================*
		// OuncesToMilligrams()
		//============================================================================*

		static public double OuncesToMilligrams(double dOunces)
			{
			return (GramsToMilligrams(OuncesToGrams(dOunces)));
			}

		//============================================================================*
		// OuncesToPounds()
		//============================================================================*

		static public double OuncesToPounds(double dOunces)
			{
			return (dOunces * Math.Round(0.0625, 4));
			}

		//============================================================================*
		// PoundsToGrams()
		//============================================================================*

		static public double PoundsToGrams(double dPounds)
			{
			return (dPounds * Math.Round(453.59237, 5));
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

		static public double PoundsToMilligrams(double dPounds)
			{
			return (dPounds * Math.Round(453592.37, 2));
			}

		//============================================================================*
		// PoundsToOunces()
		//============================================================================*

		static public double PoundsToOunces(double dPounds)
			{
			return (dPounds * Math.Round(16.0, 1));
			}

		//============================================================================*
		// RadiansToDegress()
		//============================================================================*

		static public double RadiansToDegrees(double dRadians)
			{
			return (dRadians * (180.0 / Math.PI));
			}

		//============================================================================*
		// RadiansToMOA()
		//============================================================================*

		static public double RadiansToMOA(double dRadians)
			{
			return (dRadians * 60.0 * (180.0 / Math.PI));
			}

		//============================================================================*
		// YardsToCentimeters()
		//============================================================================*

		static public double YardsToCentimeters(double dYards)
			{
			return (dYards / Math.Round(0.010936, 6));
			}

		//============================================================================*
		// YardsToFeet()
		//============================================================================*

		static public double YardsToFeet(double dYards)
			{
			return (dYards * Math.Round(3.0, 1));
			}

		//============================================================================*
		// YardsToInches()
		//============================================================================*

		static public double YardsToInches(double dYards)
			{
			return (dYards * Math.Round(36.0, 1));
			}

		//============================================================================*
		// YardsToKilometers()
		//============================================================================*

		static public double YardsToKilometers(double dYards)
			{
			return (dYards / Math.Round(1093.6, 1));
			}

		//============================================================================*
		// YardsToMeters() - Double
		//============================================================================*

		static public double YardsToMeters(double dYards)
			{
			return (dYards / Math.Round(1.0936, 4));
			}

		//============================================================================*
		// YardsToMiles()
		//============================================================================*

		static public double YardsToMiles(double dYards)
			{
			return (dYards * Math.Round(0.00056818, 8));
			}

		//============================================================================*
		// YardsToMillimeters()
		//============================================================================*

		static public double YardsToMillimeters(double dYards)
			{
			return (dYards / Math.Round(0.0010936, 7));
			}
		}
	}
