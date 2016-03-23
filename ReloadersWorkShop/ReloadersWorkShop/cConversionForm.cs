//============================================================================*
// cPreferences.cs
//
// Copyright © 2013-2014, Kevin S. Beebe
// All Rights Reserved
//============================================================================*

//============================================================================*
// .Net Using Statements
//============================================================================*

using System;
using System.Windows.Forms;

//============================================================================*
// CommonLib Using Statements
//============================================================================*

using CommonLib.Conversions;

//============================================================================*
// Application Specific Using Statements
//============================================================================*

using CommonLib.Controls;

//============================================================================*
// Namespace
//============================================================================*

namespace ReloadersWorkShop
	{
	//============================================================================*
	// cConversionForm Class
	//============================================================================*

	public partial class cConversionForm : Form
		{
		//============================================================================*
		// Private Data Members
		//============================================================================*

		private cDataFiles m_DataFiles = null;

		private cDoubleValueTextBox m_LastMeasurementTextBox = null;
		private double m_dLastMeasurementValue;

		private cDoubleValueTextBox m_LastAngleTextBox = null;
		private double m_dLastAngleValue;

		private cDoubleValueTextBox m_LastWeightTextBox = null;
		private double m_dLastWeightValue;

		private cDoubleValueTextBox m_LastVelocityTextBox = null;
		private double m_dLastVelocityValue;

		//============================================================================*
		// cConversionForm() - Constructor
		//============================================================================*

		public cConversionForm(cDataFiles DataFiles)
			{
			InitializeComponent();

			SetClientSizeCore(MeasurementsGroupBox.Location.X + MeasurementsGroupBox.Width + 10, CloseButton.Location.Y + CloseButton.Height + 20);

			m_DataFiles = DataFiles;

			if (m_DataFiles.Preferences.ConversionDecimals < 1)
				m_DataFiles.Preferences.ConversionDecimals = 3;

			PrecisionTextBox.Value = m_DataFiles.Preferences.ConversionDecimals;

			SetDecimals();

			//----------------------------------------------------------------------------*
			// EventHandlers
			//----------------------------------------------------------------------------*

			PrecisionTextBox.TextChanged += OnPrecisionChanged;

			InchesTextBox.TextChanged += OnInchesChanged;
			FeetTextBox.TextChanged += OnFeetChanged;
			YardsTextBox.TextChanged += OnYardsChanged;
			MilesTextBox.TextChanged += OnMilesChanged;
			MillimetersTextBox.TextChanged += OnMillimetersChanged;
			CentimetersTextBox.TextChanged += OnCentimetersChanged;
			MetersTextBox.TextChanged += OnMetersChanged;
			KilometersTextBox.TextChanged += OnKilometersChanged;

			MOATextBox.TextChanged += OnMOAChanged;
			MilsTextBox.TextChanged += OnMilsChanged;

			GrainsTextBox.TextChanged += OnGrainsChanged;
			OuncesTextBox.TextChanged += OnOuncesChanged;
			PoundsTextBox.TextChanged += OnPoundsChanged;
			MilligramsTextBox.TextChanged += OnMilligramsChanged;
			GramsTextBox.TextChanged += OnGramsChanged;
			KilosTextBox.TextChanged += OnKilosChanged;

			FPSTextBox.TextChanged += OnFPSChanged;
			MSTextBox.TextChanged += OnMSChanged;
			MPHTextBox.TextChanged += OnMPHChanged;
			KPHTextBox.TextChanged += OnKPHChanged;

			SetMOALabels();

			//----------------------------------------------------------------------------*
			// Set focus and exit
			//----------------------------------------------------------------------------*

			InchesTextBox.Focus();
			}

		//============================================================================*
		// OnCentimetersChanged()
		//============================================================================*

		public void OnCentimetersChanged(Object sender, EventArgs e)
			{
			double dCentimeters = Math.Round(CentimetersTextBox.Value, 6);

			m_LastMeasurementTextBox = CentimetersTextBox;
			m_dLastMeasurementValue = CentimetersTextBox.Value;

			InchesTextBox.Value = Math.Round(cConversions.CentimetersToInches(dCentimeters), 6);
			FeetTextBox.Value = cConversions.CentimetersToFeet(dCentimeters, 6);
			YardsTextBox.Value = cConversions.CentimetersToYards(dCentimeters, 6);

			MilesTextBox.Value = cConversions.CentimetersToMiles(dCentimeters, 6);
			MillimetersTextBox.Value = cConversions.CentimetersToMillimeters(dCentimeters, 6);
			MetersTextBox.Value = cConversions.CentimetersToMeters(dCentimeters, 6);
			KilometersTextBox.Value = cConversions.CentimetersToKilometers(dCentimeters, 6);

			SetMOALabels();
			}

		//============================================================================*
		// OnFeetChanged()
		//============================================================================*

		public void OnFeetChanged(Object sender, EventArgs e)
			{
			double dFeet = Math.Round(FeetTextBox.Value, 6);

			m_LastMeasurementTextBox = FeetTextBox;
			m_dLastMeasurementValue = FeetTextBox.Value;

			MillimetersTextBox.Value = cConversions.FeetToMillimeters(dFeet, 6);
			InchesTextBox.Value = cConversions.FeetToInches(dFeet, 6);
			YardsTextBox.Value = cConversions.FeetToYards(dFeet, 6);
			MilesTextBox.Value = cConversions.FeetToMiles(dFeet, 6);

			CentimetersTextBox.Value = cConversions.FeetToCentimeters(dFeet, 6);
			MetersTextBox.Value = cConversions.FeetToMeters(dFeet);
			KilometersTextBox.Value = cConversions.FeetToKilometers(dFeet, 6);

			SetMOALabels();
			}

		//============================================================================*
		// OnFPSChanged()
		//============================================================================*

		public void OnFPSChanged(Object sender, EventArgs e)
			{
			double dFPS = Math.Round(FPSTextBox.Value, 6);

			m_LastVelocityTextBox = FPSTextBox;
			m_dLastVelocityValue = FPSTextBox.Value;

			MSTextBox.Value = cConversions.FPSToMS(dFPS, 6);
			MPHTextBox.Value = cConversions.FPSToMPH(dFPS, 6);
			KPHTextBox.Value = cConversions.FPSToKPH(dFPS, 6);
			}

		//============================================================================*
		// OnGrainsChanged()
		//============================================================================*

		public void OnGrainsChanged(Object sender, EventArgs e)
			{
			double dGrains = Math.Round(GrainsTextBox.Value, 6);

			m_LastWeightTextBox = GrainsTextBox;
			m_dLastWeightValue = GrainsTextBox.Value;

			MilligramsTextBox.Value = cConversions.GrainsToMilligrams(dGrains, 6);
			GramsTextBox.Value = cConversions.GrainsToGrams(dGrains, 6);
			OuncesTextBox.Value = cConversions.GrainsToOunces(dGrains, 6);
			PoundsTextBox.Value = Math.Round(cConversions.GrainsToPounds(dGrains), 6);
			KilosTextBox.Value = cConversions.GrainsToKilos(dGrains, 6);
			}

		//============================================================================*
		// OnGramsChanged()
		//============================================================================*

		public void OnGramsChanged(Object sender, EventArgs e)
			{
			double dGrams = Math.Round(GramsTextBox.Value, 6);

			m_LastWeightTextBox = GramsTextBox;
			m_dLastWeightValue = GramsTextBox.Value;

			PoundsTextBox.Value = cConversions.GramsToPounds(dGrams, 6);
			MilligramsTextBox.Value = cConversions.GramsToMilligrams(dGrams, 6);
			GrainsTextBox.Value = cConversions.GramsToGrains(dGrams, 6);
			OuncesTextBox.Value = cConversions.GramsToOunces(dGrams, 6);
			KilosTextBox.Value = Math.Round(cConversions.GramsToKilos(dGrams), 6);
			}

		//============================================================================*
		// OnInchesChanged()
		//============================================================================*

		public void OnInchesChanged(Object sender, EventArgs e)
			{
			double dInches = Math.Round(InchesTextBox.Value, 6);

			m_LastMeasurementTextBox = InchesTextBox;
			m_dLastMeasurementValue = InchesTextBox.Value;

			MillimetersTextBox.Value = cConversions.InchesToMillimeters(dInches);
			FeetTextBox.Value = cConversions.InchesToFeet(dInches, 6);
			YardsTextBox.Value = cConversions.InchesToYards(dInches);
			MilesTextBox.Value = cConversions.InchesToMiles(dInches, 6);

			CentimetersTextBox.Value = cConversions.InchesToCentimeters(dInches, 6);
			MetersTextBox.Value = cConversions.InchesToMeters(dInches, 6);
			KilometersTextBox.Value = cConversions.InchesToKilometers(dInches, 6);

			SetMOALabels();
			}

		//============================================================================*
		// OnKilometersChanged()
		//============================================================================*

		public void OnKilometersChanged(Object sender, EventArgs e)
			{
			double dKilometers = Math.Round(KilometersTextBox.Value, 6);

			m_LastMeasurementTextBox = KilometersTextBox;
			m_dLastMeasurementValue = KilometersTextBox.Value;

			InchesTextBox.Value = cConversions.KilometersToInches(dKilometers, 6);
			FeetTextBox.Value = cConversions.KilometersToFeet(dKilometers, 6);
			YardsTextBox.Value = cConversions.KilometersToYards(dKilometers, 6);

			MilesTextBox.Value = cConversions.KilometersToMiles(dKilometers);
			MillimetersTextBox.Value = cConversions.KilometersToMillimeters(dKilometers, 6);
			CentimetersTextBox.Value = cConversions.KilometersToCentimeters(dKilometers, 6);
			MetersTextBox.Value = Math.Round(cConversions.KilometersToMeters(dKilometers), 6);

			SetMOALabels();
			}

		//============================================================================*
		// OnKilosChanged()
		//============================================================================*

		public void OnKilosChanged(Object sender, EventArgs e)
			{
			double dKilos = Math.Round(KilosTextBox.Value, 6);

			m_LastWeightTextBox = KilosTextBox;
			m_dLastWeightValue = KilosTextBox.Value;

			PoundsTextBox.Value = Math.Round(cConversions.KilosToPounds(dKilos), 6);
			MilligramsTextBox.Value = cConversions.KilosToMilligrams(dKilos, 6);
			GrainsTextBox.Value = cConversions.KilosToGrains(dKilos, 6);
			OuncesTextBox.Value = cConversions.KilosToOunces(dKilos, 6);
			GramsTextBox.Value = Math.Round(cConversions.KilosToGrams(dKilos), 6);
			}

		//============================================================================*
		// OnKPHChanged()
		//============================================================================*

		public void OnKPHChanged(Object sender, EventArgs e)
			{
			double dKPH = Math.Round(KPHTextBox.Value, 6);

			m_LastVelocityTextBox = KPHTextBox;
			m_dLastVelocityValue = KPHTextBox.Value;

			FPSTextBox.Value = cConversions.MPHToFPS(dKPH, 6);
			MSTextBox.Value = cConversions.MPHToMS(dKPH, 6);
			MPHTextBox.Value = cConversions.KPHToMPH(dKPH, 6);
			}

		//============================================================================*
		// OnMetersChanged()
		//============================================================================*

		public void OnMetersChanged(Object sender, EventArgs e)
			{
			double dMeters = Math.Round(MetersTextBox.Value, 6);

			m_LastMeasurementTextBox = MetersTextBox;
			m_dLastMeasurementValue = MetersTextBox.Value;

			InchesTextBox.Value = cConversions.MetersToInches(dMeters, 6);
			FeetTextBox.Value = cConversions.MetersToFeet(dMeters);
			YardsTextBox.Value = cConversions.MetersToYards(dMeters, 6);

			MilesTextBox.Value = cConversions.MetersToMiles(dMeters, 6);
			MillimetersTextBox.Value = cConversions.MetersToMillimeters(dMeters, 6);
			CentimetersTextBox.Value = cConversions.MetersToCentimeters(dMeters, 6);
			KilometersTextBox.Value = Math.Round(cConversions.MetersToKilometers(dMeters), 6);

			SetMOALabels();
			}

		//============================================================================*
		// OnMilesChanged()
		//============================================================================*

		public void OnMilesChanged(Object sender, EventArgs e)
			{
			double dMiles = Math.Round(MilesTextBox.Value, 6);

			m_LastMeasurementTextBox = MilesTextBox;
			m_dLastMeasurementValue = MilesTextBox.Value;

			InchesTextBox.Value = cConversions.MilesToInches(dMiles, 6);
			FeetTextBox.Value = cConversions.MilesToFeet(dMiles, 6);
			YardsTextBox.Value = cConversions.MilesToYards(dMiles, 6);

			MillimetersTextBox.Value = cConversions.MilesToMillimeters(dMiles, 6);
			CentimetersTextBox.Value = cConversions.MilesToCentimeters(dMiles, 6);
			MetersTextBox.Value = cConversions.MilesToMeters(dMiles, 6);
			KilometersTextBox.Value = cConversions.MilesToKilometers(dMiles, 6);

			SetMOALabels();
			}

		//============================================================================*
		// OnMilligramsChanged()
		//============================================================================*

		public void OnMilligramsChanged(Object sender, EventArgs e)
			{
			double dMilligrams = Math.Round(MilligramsTextBox.Value, 6);

			m_LastWeightTextBox = MilligramsTextBox;
			m_dLastWeightValue = MilligramsTextBox.Value;

			PoundsTextBox.Value = cConversions.MilligramsToPounds(dMilligrams, 6);
			GramsTextBox.Value = cConversions.MilligramsToGrams(dMilligrams, 6);
			GrainsTextBox.Value = cConversions.MilligramsToGrains(dMilligrams, 6);
			OuncesTextBox.Value = cConversions.MilligramsToOunces(dMilligrams, 6);
			KilosTextBox.Value = cConversions.MilligramsToKilos(dMilligrams, 6);
			}

		//============================================================================*
		// OnMillimetersChanged()
		//============================================================================*

		public void OnMillimetersChanged(Object sender, EventArgs e)
			{
			double dMillimeters = Math.Round(MillimetersTextBox.Value, 6);

			m_LastMeasurementTextBox = MillimetersTextBox;
			m_dLastMeasurementValue = MillimetersTextBox.Value;

			InchesTextBox.Value = cConversions.MillimetersToInches(dMillimeters);
			FeetTextBox.Value = cConversions.MillimetersToFeet(dMillimeters, 6);
			YardsTextBox.Value = cConversions.MillimetersToYards(dMillimeters, 6);

			MilesTextBox.Value = cConversions.MillimetersToMiles(dMillimeters, 6);
			CentimetersTextBox.Value = cConversions.MillimetersToCentimeters(dMillimeters, 6);
			MetersTextBox.Value = Math.Round(cConversions.MillimetersToMeters(dMillimeters), 6);
			KilometersTextBox.Value = cConversions.MillimetersToKilometers(dMillimeters, 6);

			SetMOALabels();
			}

		//============================================================================*
		// OnMilsChanged()
		//============================================================================*

		public void OnMilsChanged(Object sender, EventArgs e)
			{
			double dMils = Math.Round(MilsTextBox.Value, 6);

			m_LastAngleTextBox = MilsTextBox;
			m_dLastAngleValue = MilsTextBox.Value;

			MOATextBox.Value = cConversions.MilsToMOA(dMils, 6);

			SetMOALabels();
			}

		//============================================================================*
		// OnMOAChanged()
		//============================================================================*

		public void OnMOAChanged(Object sender, EventArgs e)
			{
			double dMOA = Math.Round(MOATextBox.Value, 6);

			m_LastAngleTextBox = MOATextBox;
			m_dLastAngleValue = MOATextBox.Value;

			MilsTextBox.Value = cConversions.MOAToMils(dMOA, 6);

			SetMOALabels();
			}

		//============================================================================*
		// OnMPHChanged()
		//============================================================================*

		public void OnMPHChanged(Object sender, EventArgs e)
			{
			double dMPH = Math.Round(MPHTextBox.Value, 6);

			m_LastVelocityTextBox = MPHTextBox;
			m_dLastVelocityValue = MPHTextBox.Value;

			FPSTextBox.Value = cConversions.MPHToFPS(dMPH, 6);
			MSTextBox.Value = cConversions.MPHToMS(dMPH, 6);
			KPHTextBox.Value = cConversions.MPHToKPH(dMPH, 6);
			}

		//============================================================================*
		// OnMSChanged()
		//============================================================================*

		public void OnMSChanged(Object sender, EventArgs e)
			{
			double dMS = Math.Round(MSTextBox.Value, 6);

			m_LastVelocityTextBox = MSTextBox;
			m_dLastVelocityValue = MSTextBox.Value;

			FPSTextBox.Value = cConversions.MSToFPS(dMS, 6);
			MPHTextBox.Value = cConversions.MSToMPH(dMS, 6);
			KPHTextBox.Value = cConversions.MSToKPH(dMS, 6);
			}

		//============================================================================*
		// OnOuncesChanged()
		//============================================================================*

		public void OnOuncesChanged(Object sender, EventArgs e)
			{
			double dOunces = Math.Round(OuncesTextBox.Value, 6);

			m_LastWeightTextBox = OuncesTextBox;
			m_dLastWeightValue = OuncesTextBox.Value;

			MilligramsTextBox.Value = cConversions.OuncesToMilligrams(dOunces, 6);
			GramsTextBox.Value = cConversions.OuncesToGrams(dOunces, 6);
			GrainsTextBox.Value = cConversions.OuncesToGrains(dOunces, 6);
			PoundsTextBox.Value = cConversions.OuncesToPounds(dOunces, 6);
			KilosTextBox.Value = cConversions.OuncesToKilos(dOunces, 6);
			}

		//============================================================================*
		// OnPoundsChanged()
		//============================================================================*

		public void OnPoundsChanged(Object sender, EventArgs e)
			{
			double dPounds = Math.Round(PoundsTextBox.Value, 6);

			m_LastWeightTextBox = PoundsTextBox;
			m_dLastWeightValue = PoundsTextBox.Value;

			MilligramsTextBox.Value = cConversions.PoundsToMilligrams(dPounds, 6);
			GramsTextBox.Value = cConversions.PoundsToGrams(dPounds, 6);
			GrainsTextBox.Value = Math.Round(cConversions.PoundsToGrains(dPounds), 6);
			OuncesTextBox.Value = cConversions.PoundsToOunces(dPounds, 6);
			KilosTextBox.Value = Math.Round(cConversions.PoundsToKilos(dPounds), 6);
			}

		//============================================================================*
		// OnPrecisionChanged()
		//============================================================================*

		public void OnPrecisionChanged(Object sender, EventArgs e)
			{
			if (PrecisionTextBox.ValueOK)
				{
				m_DataFiles.Preferences.ConversionDecimals = PrecisionTextBox.Value;

				SetDecimals();
/*
				if (m_LastMeasurementTextBox != null)
					m_LastMeasurementTextBox.Value = 0.0;

				if (m_LastWeightTextBox != null)
					m_LastWeightTextBox.Value = 0.0;

				if (m_LastVelocityTextBox != null)
					m_LastVelocityTextBox.Value = 0.0;
*/				}
			}

		//============================================================================*
		// OnYardsChanged()
		//============================================================================*

		public void OnYardsChanged(Object sender, EventArgs e)
			{
			double dYards = Math.Round(YardsTextBox.Value, 6);

			m_LastMeasurementTextBox = YardsTextBox;
			m_dLastMeasurementValue = YardsTextBox.Value;

			InchesTextBox.Value = cConversions.YardsToInches(dYards, 6);
			FeetTextBox.Value = cConversions.YardsToFeet(dYards, 6);
			MilesTextBox.Value = cConversions.YardsToMiles(dYards, 6);

			MillimetersTextBox.Value = cConversions.YardsToMillimeters(dYards, 6);
			CentimetersTextBox.Value = cConversions.YardsToCentimeters(dYards, 6);
			MetersTextBox.Value = cConversions.YardsToMeters(dYards, 6);
			KilometersTextBox.Value = cConversions.YardsToKilometers(dYards, 6);

			SetMOALabels();
			}

		//============================================================================*
		// SetDecimals()
		//============================================================================*

		public void SetDecimals()
			{
			InchesTextBox.NumDecimals = m_DataFiles.Preferences.ConversionDecimals;
			InchesTextBox.MaxLength = 5 + m_DataFiles.Preferences.ConversionDecimals;

			FeetTextBox.NumDecimals = m_DataFiles.Preferences.ConversionDecimals;
			FeetTextBox.MaxLength = 5 + m_DataFiles.Preferences.ConversionDecimals;

			YardsTextBox.NumDecimals = m_DataFiles.Preferences.ConversionDecimals;
			YardsTextBox.MaxLength = 5 + m_DataFiles.Preferences.ConversionDecimals;

			MilesTextBox.NumDecimals = m_DataFiles.Preferences.ConversionDecimals;
			MilesTextBox.MaxLength = 5 + m_DataFiles.Preferences.ConversionDecimals;

			MillimetersTextBox.NumDecimals = m_DataFiles.Preferences.ConversionDecimals;
			MillimetersTextBox.MaxLength = 5 + m_DataFiles.Preferences.ConversionDecimals;

			CentimetersTextBox.NumDecimals = m_DataFiles.Preferences.ConversionDecimals;
			CentimetersTextBox.MaxLength = 5 + m_DataFiles.Preferences.ConversionDecimals;

			MetersTextBox.NumDecimals = m_DataFiles.Preferences.ConversionDecimals;
			MetersTextBox.MaxLength = 5 + m_DataFiles.Preferences.ConversionDecimals;

			KilometersTextBox.NumDecimals = m_DataFiles.Preferences.ConversionDecimals;
			KilometersTextBox.MaxLength = 5 + m_DataFiles.Preferences.ConversionDecimals;

			MOATextBox.NumDecimals = m_DataFiles.Preferences.ConversionDecimals;
			MOATextBox.MaxLength = 5 + m_DataFiles.Preferences.ConversionDecimals;

			MilsTextBox.NumDecimals = m_DataFiles.Preferences.ConversionDecimals;
			MilsTextBox.MaxLength = 5 + m_DataFiles.Preferences.ConversionDecimals;

			GrainsTextBox.NumDecimals = m_DataFiles.Preferences.ConversionDecimals;
			GrainsTextBox.MaxLength = 6 + m_DataFiles.Preferences.ConversionDecimals;

			OuncesTextBox.NumDecimals = m_DataFiles.Preferences.ConversionDecimals;
			OuncesTextBox.MaxLength = 5 + m_DataFiles.Preferences.ConversionDecimals;

			PoundsTextBox.NumDecimals = m_DataFiles.Preferences.ConversionDecimals;
			PoundsTextBox.MaxLength = 5 + m_DataFiles.Preferences.ConversionDecimals;

			GramsTextBox.NumDecimals = m_DataFiles.Preferences.ConversionDecimals;
			GramsTextBox.MaxLength = 6 + m_DataFiles.Preferences.ConversionDecimals;

			KilosTextBox.NumDecimals = m_DataFiles.Preferences.ConversionDecimals;
			KilosTextBox.MaxLength = 5 + m_DataFiles.Preferences.ConversionDecimals;

			FPSTextBox.NumDecimals = m_DataFiles.Preferences.ConversionDecimals;
			FPSTextBox.MaxLength = 6 + m_DataFiles.Preferences.ConversionDecimals;

			MSTextBox.NumDecimals = m_DataFiles.Preferences.ConversionDecimals;
			MSTextBox.MaxLength = 6 + m_DataFiles.Preferences.ConversionDecimals;

			KPHTextBox.NumDecimals = m_DataFiles.Preferences.ConversionDecimals;
			KPHTextBox.MaxLength = 5 + m_DataFiles.Preferences.ConversionDecimals;

			MPHTextBox.NumDecimals = m_DataFiles.Preferences.ConversionDecimals;
			MPHTextBox.MaxLength = 5 + m_DataFiles.Preferences.ConversionDecimals;

			SetMOALabels();
			}

		//============================================================================*
		// SetMOALabels()
		//============================================================================*

		public void SetMOALabels()
			{
			if (YardsTextBox.Value == 0.0 || MOATextBox.Value == 0.0)
				{
				AtMetersLabel.Visible = false;
				AtYardsLabel.Visible = false;

				return;
				}

			string strFormat = "{0:F";
			strFormat += String.Format("{0:G0}", PrecisionTextBox.Value);
			strFormat += "} {1} at {2:F";
			strFormat += String.Format("{0:G0}", PrecisionTextBox.Value);
			strFormat += "} {3}";

			AtYardsLabel.Text = string.Format(strFormat, cConversions.MOAToInches(MOATextBox.Value, YardsTextBox.Value, m_DataFiles.Preferences.ConversionDecimals), "in", YardsTextBox.Value, "Yards");
			AtMetersLabel.Text = string.Format(strFormat, cConversions.MOAToCentimeters(MOATextBox.Value, MetersTextBox.Value, m_DataFiles.Preferences.ConversionDecimals), "cm", MetersTextBox.Value, "Meters");

			AtMetersLabel.Visible = true;
			AtYardsLabel.Visible = true;
			}
		}
	}
