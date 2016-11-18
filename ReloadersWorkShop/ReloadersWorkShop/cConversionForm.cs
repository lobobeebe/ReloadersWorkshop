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
			double dCentimeters = Math.Round(CentimetersTextBox.Value);

			m_LastMeasurementTextBox = CentimetersTextBox;
			m_dLastMeasurementValue = CentimetersTextBox.Value;

			InchesTextBox.Value = Math.Round(cConversions.CentimetersToInches(dCentimeters));
			FeetTextBox.Value = cConversions.CentimetersToFeet(dCentimeters);
			YardsTextBox.Value = cConversions.CentimetersToYards(dCentimeters);

			MilesTextBox.Value = cConversions.CentimetersToMiles(dCentimeters);
			MillimetersTextBox.Value = cConversions.CentimetersToMillimeters(dCentimeters);
			MetersTextBox.Value = cConversions.CentimetersToMeters(dCentimeters);
			KilometersTextBox.Value = cConversions.CentimetersToKilometers(dCentimeters);

			SetMOALabels();
			}

		//============================================================================*
		// OnFeetChanged()
		//============================================================================*

		public void OnFeetChanged(Object sender, EventArgs e)
			{
			double dFeet = Math.Round(FeetTextBox.Value);

			m_LastMeasurementTextBox = FeetTextBox;
			m_dLastMeasurementValue = FeetTextBox.Value;

			MillimetersTextBox.Value = cConversions.FeetToMillimeters(dFeet);
			InchesTextBox.Value = cConversions.FeetToInches(dFeet);
			YardsTextBox.Value = cConversions.FeetToYards(dFeet);
			MilesTextBox.Value = cConversions.FeetToMiles(dFeet);

			CentimetersTextBox.Value = cConversions.FeetToCentimeters(dFeet);
			MetersTextBox.Value = cConversions.FeetToMeters(dFeet);
			KilometersTextBox.Value = cConversions.FeetToKilometers(dFeet);

			SetMOALabels();
			}

		//============================================================================*
		// OnFPSChanged()
		//============================================================================*

		public void OnFPSChanged(Object sender, EventArgs e)
			{
			double dFPS = Math.Round(FPSTextBox.Value);

			m_LastVelocityTextBox = FPSTextBox;
			m_dLastVelocityValue = FPSTextBox.Value;

			MSTextBox.Value = cConversions.FPSToMS(dFPS);
			MPHTextBox.Value = cConversions.FPSToMPH(dFPS);
			KPHTextBox.Value = cConversions.FPSToKPH(dFPS);
			}

		//============================================================================*
		// OnGrainsChanged()
		//============================================================================*

		public void OnGrainsChanged(Object sender, EventArgs e)
			{
			double dGrains = Math.Round(GrainsTextBox.Value);

			m_LastWeightTextBox = GrainsTextBox;
			m_dLastWeightValue = GrainsTextBox.Value;

			MilligramsTextBox.Value = cConversions.GrainsToMilligrams(dGrains);
			GramsTextBox.Value = cConversions.GrainsToGrams(dGrains);
			OuncesTextBox.Value = cConversions.GrainsToOunces(dGrains);
			PoundsTextBox.Value = Math.Round(cConversions.GrainsToPounds(dGrains));
			KilosTextBox.Value = cConversions.GrainsToKilos(dGrains);
			}

		//============================================================================*
		// OnGramsChanged()
		//============================================================================*

		public void OnGramsChanged(Object sender, EventArgs e)
			{
			double dGrams = Math.Round(GramsTextBox.Value);

			m_LastWeightTextBox = GramsTextBox;
			m_dLastWeightValue = GramsTextBox.Value;

			PoundsTextBox.Value = cConversions.GramsToPounds(dGrams);
			MilligramsTextBox.Value = cConversions.GramsToMilligrams(dGrams);
			GrainsTextBox.Value = cConversions.GramsToGrains(dGrams);
			OuncesTextBox.Value = cConversions.GramsToOunces(dGrams);
			KilosTextBox.Value = Math.Round(cConversions.GramsToKilos(dGrams));
			}

		//============================================================================*
		// OnInchesChanged()
		//============================================================================*

		public void OnInchesChanged(Object sender, EventArgs e)
			{
			double dInches = Math.Round(InchesTextBox.Value);

			m_LastMeasurementTextBox = InchesTextBox;
			m_dLastMeasurementValue = InchesTextBox.Value;

			MillimetersTextBox.Value = cConversions.InchesToMillimeters(dInches);
			FeetTextBox.Value = cConversions.InchesToFeet(dInches);
			YardsTextBox.Value = cConversions.InchesToYards(dInches);
			MilesTextBox.Value = cConversions.InchesToMiles(dInches);

			CentimetersTextBox.Value = cConversions.InchesToCentimeters(dInches);
			MetersTextBox.Value = cConversions.InchesToMeters(dInches);
			KilometersTextBox.Value = cConversions.InchesToKilometers(dInches);

			SetMOALabels();
			}

		//============================================================================*
		// OnKilometersChanged()
		//============================================================================*

		public void OnKilometersChanged(Object sender, EventArgs e)
			{
			double dKilometers = Math.Round(KilometersTextBox.Value);

			m_LastMeasurementTextBox = KilometersTextBox;
			m_dLastMeasurementValue = KilometersTextBox.Value;

			InchesTextBox.Value = cConversions.KilometersToInches(dKilometers);
			FeetTextBox.Value = cConversions.KilometersToFeet(dKilometers);
			YardsTextBox.Value = cConversions.KilometersToYards(dKilometers);

			MilesTextBox.Value = cConversions.KilometersToMiles(dKilometers);
			MillimetersTextBox.Value = cConversions.KilometersToMillimeters(dKilometers);
			CentimetersTextBox.Value = cConversions.KilometersToCentimeters(dKilometers);
			MetersTextBox.Value = Math.Round(cConversions.KilometersToMeters(dKilometers));

			SetMOALabels();
			}

		//============================================================================*
		// OnKilosChanged()
		//============================================================================*

		public void OnKilosChanged(Object sender, EventArgs e)
			{
			double dKilos = Math.Round(KilosTextBox.Value);

			m_LastWeightTextBox = KilosTextBox;
			m_dLastWeightValue = KilosTextBox.Value;

			PoundsTextBox.Value = Math.Round(cConversions.KilosToPounds(dKilos));
			MilligramsTextBox.Value = cConversions.KilosToMilligrams(dKilos);
			GrainsTextBox.Value = cConversions.KilosToGrains(dKilos);
			OuncesTextBox.Value = cConversions.KilosToOunces(dKilos);
			GramsTextBox.Value = Math.Round(cConversions.KilosToGrams(dKilos));
			}

		//============================================================================*
		// OnKPHChanged()
		//============================================================================*

		public void OnKPHChanged(Object sender, EventArgs e)
			{
			double dKPH = Math.Round(KPHTextBox.Value);

			m_LastVelocityTextBox = KPHTextBox;
			m_dLastVelocityValue = KPHTextBox.Value;

			FPSTextBox.Value = cConversions.MPHToFPS(dKPH);
			MSTextBox.Value = cConversions.MPHToMS(dKPH);
			MPHTextBox.Value = cConversions.KPHToMPH(dKPH);
			}

		//============================================================================*
		// OnMetersChanged()
		//============================================================================*

		public void OnMetersChanged(Object sender, EventArgs e)
			{
			double dMeters = Math.Round(MetersTextBox.Value);

			m_LastMeasurementTextBox = MetersTextBox;
			m_dLastMeasurementValue = MetersTextBox.Value;

			InchesTextBox.Value = cConversions.MetersToInches(dMeters);
			FeetTextBox.Value = cConversions.MetersToFeet(dMeters);
			YardsTextBox.Value = cConversions.MetersToYards(dMeters);

			MilesTextBox.Value = cConversions.MetersToMiles(dMeters);
			MillimetersTextBox.Value = cConversions.MetersToMillimeters(dMeters);
			CentimetersTextBox.Value = cConversions.MetersToCentimeters(dMeters);
			KilometersTextBox.Value = Math.Round(cConversions.MetersToKilometers(dMeters));

			SetMOALabels();
			}

		//============================================================================*
		// OnMilesChanged()
		//============================================================================*

		public void OnMilesChanged(Object sender, EventArgs e)
			{
			double dMiles = Math.Round(MilesTextBox.Value);

			m_LastMeasurementTextBox = MilesTextBox;
			m_dLastMeasurementValue = MilesTextBox.Value;

			InchesTextBox.Value = cConversions.MilesToInches(dMiles);
			FeetTextBox.Value = cConversions.MilesToFeet(dMiles);
			YardsTextBox.Value = cConversions.MilesToYards(dMiles);

			MillimetersTextBox.Value = cConversions.MilesToMillimeters(dMiles);
			CentimetersTextBox.Value = cConversions.MilesToCentimeters(dMiles);
			MetersTextBox.Value = cConversions.MilesToMeters(dMiles);
			KilometersTextBox.Value = cConversions.MilesToKilometers(dMiles);

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

			PoundsTextBox.Value = cConversions.MilligramsToPounds(dMilligrams);
			GramsTextBox.Value = cConversions.MilligramsToGrams(dMilligrams);
			GrainsTextBox.Value = cConversions.MilligramsToGrains(dMilligrams);
			OuncesTextBox.Value = cConversions.MilligramsToOunces(dMilligrams);
			KilosTextBox.Value = cConversions.MilligramsToKilos(dMilligrams);
			}

		//============================================================================*
		// OnMillimetersChanged()
		//============================================================================*

		public void OnMillimetersChanged(Object sender, EventArgs e)
			{
			double dMillimeters = Math.Round(MillimetersTextBox.Value);

			m_LastMeasurementTextBox = MillimetersTextBox;
			m_dLastMeasurementValue = MillimetersTextBox.Value;

			InchesTextBox.Value = cConversions.MillimetersToInches(dMillimeters);
			FeetTextBox.Value = cConversions.MillimetersToFeet(dMillimeters);
			YardsTextBox.Value = cConversions.MillimetersToYards(dMillimeters);

			MilesTextBox.Value = cConversions.MillimetersToMiles(dMillimeters);
			CentimetersTextBox.Value = cConversions.MillimetersToCentimeters(dMillimeters);
			MetersTextBox.Value = Math.Round(cConversions.MillimetersToMeters(dMillimeters));
			KilometersTextBox.Value = cConversions.MillimetersToKilometers(dMillimeters);

			SetMOALabels();
			}

		//============================================================================*
		// OnMilsChanged()
		//============================================================================*

		public void OnMilsChanged(Object sender, EventArgs e)
			{
			double dMils = Math.Round(MilsTextBox.Value);

			m_LastAngleTextBox = MilsTextBox;
			m_dLastAngleValue = MilsTextBox.Value;

			MOATextBox.Value = cConversions.MilsToMOA(dMils);

			SetMOALabels();
			}

		//============================================================================*
		// OnMOAChanged()
		//============================================================================*

		public void OnMOAChanged(Object sender, EventArgs e)
			{
			double dMOA = Math.Round(MOATextBox.Value);

			m_LastAngleTextBox = MOATextBox;
			m_dLastAngleValue = MOATextBox.Value;

			MilsTextBox.Value = cConversions.MOAToMils(dMOA);

			SetMOALabels();
			}

		//============================================================================*
		// OnMPHChanged()
		//============================================================================*

		public void OnMPHChanged(Object sender, EventArgs e)
			{
			double dMPH = Math.Round(MPHTextBox.Value);

			m_LastVelocityTextBox = MPHTextBox;
			m_dLastVelocityValue = MPHTextBox.Value;

			FPSTextBox.Value = cConversions.MPHToFPS(dMPH);
			MSTextBox.Value = cConversions.MPHToMS(dMPH);
			KPHTextBox.Value = cConversions.MPHToKPH(dMPH);
			}

		//============================================================================*
		// OnMSChanged()
		//============================================================================*

		public void OnMSChanged(Object sender, EventArgs e)
			{
			double dMS = Math.Round(MSTextBox.Value);

			m_LastVelocityTextBox = MSTextBox;
			m_dLastVelocityValue = MSTextBox.Value;

			FPSTextBox.Value = cConversions.MSToFPS(dMS);
			MPHTextBox.Value = cConversions.MSToMPH(dMS);
			KPHTextBox.Value = cConversions.MSToKPH(dMS);
			}

		//============================================================================*
		// OnOuncesChanged()
		//============================================================================*

		public void OnOuncesChanged(Object sender, EventArgs e)
			{
			double dOunces = Math.Round(OuncesTextBox.Value);

			m_LastWeightTextBox = OuncesTextBox;
			m_dLastWeightValue = OuncesTextBox.Value;

			MilligramsTextBox.Value = cConversions.OuncesToMilligrams(dOunces);
			GramsTextBox.Value = cConversions.OuncesToGrams(dOunces);
			GrainsTextBox.Value = cConversions.OuncesToGrains(dOunces);
			PoundsTextBox.Value = cConversions.OuncesToPounds(dOunces);
			KilosTextBox.Value = cConversions.OuncesToKilos(dOunces);
			}

		//============================================================================*
		// OnPoundsChanged()
		//============================================================================*

		public void OnPoundsChanged(Object sender, EventArgs e)
			{
			double dPounds = Math.Round(PoundsTextBox.Value);

			m_LastWeightTextBox = PoundsTextBox;
			m_dLastWeightValue = PoundsTextBox.Value;

			MilligramsTextBox.Value = cConversions.PoundsToMilligrams(dPounds);
			GramsTextBox.Value = cConversions.PoundsToGrams(dPounds);
			GrainsTextBox.Value = Math.Round(cConversions.PoundsToGrains(dPounds));
			OuncesTextBox.Value = cConversions.PoundsToOunces(dPounds);
			KilosTextBox.Value = Math.Round(cConversions.PoundsToKilos(dPounds));
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
			double dYards = Math.Round(YardsTextBox.Value);

			m_LastMeasurementTextBox = YardsTextBox;
			m_dLastMeasurementValue = YardsTextBox.Value;

			InchesTextBox.Value = cConversions.YardsToInches(dYards);
			FeetTextBox.Value = cConversions.YardsToFeet(dYards);
			MilesTextBox.Value = cConversions.YardsToMiles(dYards);

			MillimetersTextBox.Value = cConversions.YardsToMillimeters(dYards);
			CentimetersTextBox.Value = cConversions.YardsToCentimeters(dYards);
			MetersTextBox.Value = cConversions.YardsToMeters(dYards);
			KilometersTextBox.Value = cConversions.YardsToKilometers(dYards);

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

			AtYardsLabel.Text = string.Format(strFormat, cConversions.MOAToInches(MOATextBox.Value, YardsTextBox.Value), "in", YardsTextBox.Value, "Yards");
			AtMetersLabel.Text = string.Format(strFormat, cConversions.MOAToCentimeters(MOATextBox.Value, MetersTextBox.Value), "cm", MetersTextBox.Value, "Meters");

			AtMetersLabel.Visible = true;
			AtYardsLabel.Visible = true;
			}
		}
	}
