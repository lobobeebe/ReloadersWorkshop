//============================================================================*
// cMainForm.BallisticsTab.cs
//
// Copyright © 2013-2014, Kevin S. Beebe
// All Rights Reserved
//============================================================================*

//============================================================================*
// .Net Using Statements
//============================================================================*

using System;
using System.Drawing;
using System.Windows.Forms;

//============================================================================*
// CommonLib Using Statements
//============================================================================*

using CommonLib.Conversions;

//============================================================================*
// RWCommonLib Using Statements
//============================================================================*

//using RWCommonLib.Kestrel;

//============================================================================*
// Application Specific Using Statements
//============================================================================*

using ReloadersWorkShop.Ballistics;
using ReloadersWorkShop.Preferences;

//============================================================================*
// NameSpace
//============================================================================*

namespace ReloadersWorkShop
	{
	//============================================================================*
	// cMainForm Class
	//============================================================================*

	partial class cMainForm
		{
		//============================================================================*
		// Private Constant Data Members
		//============================================================================*

		private const string cm_strBallisticsFirearmToolTip = "Select a Firearm in order to set Firearm specific data.";
		private const string cm_strBallisticsBatchToolTip = "Select a Batch in order to set Bullet and Muzzle Velocity data.\n\nOnly Batches containing test data with non-zero muzzle velocities are listed.";
		private const string cm_strBallisticsLoadToolTip = "Select a Load in order to set Bullet and Muzzle Velocity data.";
		private const string cm_strBallisticsChargeToolTip = "Select a Powder Weight in order to set Muzzle Velocity data.";
		private const string cm_strBallisticsCaliberToolTip = "Select a Caliber in order to limit the Bullets listed in the Bullet drop-down.";
		private const string cm_strBallisticsBulletToolTip = "Select a Bullet in order to set Bullet specific data.";

		private const string cm_strBallisticsBatchVelocityToolTip = "Check this if you wish to use the Muzzle Velocity from the selected Batch's test data.";
		private const string cm_strBallisticsLoadVelocityToolTip = "Check this if you wish to use the Muzzle Velocity from the selected Load's test data.";

		private const string cm_strBallisticsBCToolTip = "The Ballistic Coefficient of the bullet to be analyzed.";
		private const string cm_strBallisticsBulletDiameterToolTip = "The diameter of the bullet to be analyzed.";
		private const string cm_strBallisticsBulletWeightToolTip = "The weight of the bullet to be analyzed.";
		private const string cm_strBallisticsMuzzleVelocityToolTip = "The muzzle velocity of the bullet to be analyzed.";

		private const string cm_strBallisticsZeroRangeToolTip = "The range at which the firearm's sights have been zeroed.";
		private const string cm_strBallisticsSightHeightToolTip = "The distance between the center of the bore and the crosshair or the top of the sight of the firearm to used in the analysis.";
		private const string cm_strBallisticsScopeClickToolTip = "The fraction of MOA or Mils that each click of the scope will move the impact point.";
		private const string cm_strBallisticsTurretTypeToolTip = "Select whether the Scope Click value represents MOA or Mils.";

		private const string cm_strBallisticsWindDirectionToolTip = "The direction, in degrees, from which the wind is blowing.";
		private const string cm_strBallisticsWindSpeedToolTip = "The windspeed desired to calculate wind drift.";
		private const string cm_strBallisticsAltitudeToolTip = "The altitude above Mean Sea Level (MSL) at your location.";
		private const string cm_strBallisticsTemperatureToolTip = "The current temperature at your location.";
		private const string cm_strBallisticsPressureToolTip = "The barometric pressure at sea level.  This is the pressure reported by weather radio and news reports.";

		private const string cm_strBallisticsKestrelToolTip = "Click to retrive atmospheric data from a bluetooth equipped Kestrel device.";

		private const string cm_strBallisticsMinRangeToolTip = "The first range you would like to appear on the Bullet Drop Table.";
		private const string cm_strBallisticsMaxRangeToolTip = "The last range you would like to appear on the Bullet Drop Table.";
		private const string cm_strBallisticsIncrementToolTip = "The increments to be calculated between the minimum and maximum ranges.";
		private const string cm_strBallisticsTargetRangeToolTip = "The range at which you would like to place the target on the charts below.";

		private const string cm_strSaveReferenceBulletToolTip = "Click to save the above data as the reference data for ballistics comparisons.";
		private const string cm_strRestoreReferenceBulletToolTip = "Click to restore the reference data used for ballistics comparisons.";
		private const string cm_strCompareReferenceBulletToolTip = "Check this if you wish to compare the ballistics data to the  left with the saved reference data.";

		//============================================================================*
		// Private Data Members
		//============================================================================*

		private bool m_fBallisticsTabInitialized = false;

		private cBallistics m_BallisticsData = null;

		private Bitmap m_DropChartStandingShooter = null;
		private Bitmap m_DropChartTarget = null;

		private Bitmap m_DriftChartShooter = null;

		private Bitmap m_GroundStrike = null;

		private int m_nChartStartX = 0;
		private int m_nChartStartY = 0;
		private int m_nChartEndY = 0;
		private int m_nGroundY = 0;

		private int m_nDriftChartStartY = 0;

		private double m_dPixelsPerXUnit = 0.0;
		private double m_dPixelsPerYUnit = 0.0;

		private bool m_fCalculateOK = false;

		private int m_nDropChartHeight = 210;
		private int m_nDropChartWidth = 1426;

		//		private cRWKestrel m_RWKestrel = new cRWKestrel();
		private Timer m_KestrelTimer = new Timer();

		private ToolTip m_BallisticsBatchToolTip = new ToolTip();
		private ToolTip m_BallisticsLoadToolTip = new ToolTip();
		private ToolTip m_BallisticsFirearmToolTip = new ToolTip();
		private ToolTip m_BallisticsChargeToolTip = new ToolTip();
		private ToolTip m_BallisticsCaliberToolTip = new ToolTip();
		private ToolTip m_BallisticsBulletToolTip = new ToolTip();
		private ToolTip m_BallisticsBatchVelocityToolTip = new ToolTip();
		private ToolTip m_BallisticsLoadVelocityToolTip = new ToolTip();
		private ToolTip m_BallisticsTurretTypeToolTip = new ToolTip();

		private ToolTip m_BallisticsKestrelToolTip = new ToolTip();

		private ToolTip m_SaveReferenceBulletToolTip = new ToolTip();
		private ToolTip m_RestoreReferenceBulletToolTip = new ToolTip();
		private ToolTip m_CompareReferenceBulletToolTip = new ToolTip();

		//============================================================================*
		// ClearBallisticsDatabaseInfo()
		//============================================================================*

		private void ClearBallisticsDatabaseInfo()
			{
			m_DataFiles.Preferences.BallisticsFirearm = null;
			m_DataFiles.Preferences.BallisticsBatch = null;
			m_DataFiles.Preferences.BallisticsLoad = null;
			m_DataFiles.Preferences.BallisticsCharge = 0.0;
			m_DataFiles.Preferences.BallisticsCaliber = null;
			m_DataFiles.Preferences.BallisticsBullet = null;

			PopulateBallisticsFirearmCombo();
			}

		//============================================================================*
		// ClearBallisticsResults()
		//============================================================================*

		private void ClearBallisticsResults()
			{
			BallisticsListView.Items.Clear();

			SetChartBackgrounds();
			}

		//============================================================================*
		// InitializeBallisticsTab()
		//============================================================================*

		public void InitializeBallisticsTab()
			{
			if (!m_fBallisticsTabInitialized)
				{
				//----------------------------------------------------------------------------*
				// Event Handlers
				//----------------------------------------------------------------------------*

				BallisticsBCTextBox.TextChanged += OnBallisticsBCChanged;
				BallisticsBulletDiameterTextBox.TextChanged += OnBallisticsBulletDiameterChanged;
				BallisticsBulletWeightTextBox.TextChanged += OnBallisticsBulletWeightChanged;
				BallisticsBulletLengthTextBox.TextChanged += OnBallisticsBulletLengthChanged;
				BallisticsMuzzleVelocityTextBox.TextChanged += OnBallisticsMuzzleVelocityChanged;

				BallisticsZeroRangeTextBox.TextChanged += OnBallisticsZeroRangeChanged;
				BallisticsSightHeightTextBox.TextChanged += OnBallisticsSightHeightChanged;
				BallisticsScopeClickTextBox.TextChanged += OnBallisticsScopeClickChanged;
				BallisticsTurretTypeComboBox.SelectedIndexChanged += OnBallisticsTurretTypeSelected;
				BallisticsTwistTextBox.TextChanged += OnBallisticsTwistChanged;

				BallisticsTemperatureTextBox.TextChanged += OnBallisticsTemperatureChanged;
				BallisticsWindSpeedTextBox.TextChanged += OnBallisticsWindSpeedChanged;
				BallisticsWindDirectionTextBox.TextChanged += OnBallisticsWindDirectionChanged;
				BallisticsAltitudeTextBox.TextChanged += OnBallisticsAltitudeChanged;
				BallisticsUseDensityAltitudeCheckBox.Click += OnBallisticsUseDensityAltitudeClicked;
				BallisticsUseStationPressureCheckBox.Click += OnBallisticsUseStationPressureClicked;

				BallisticsPressureTextBox.TextChanged += OnBallisticsPressureChanged;
				BallisticsHumidityTextBox.TextChanged += OnBallisticsHumidityChanged;

				BallisticsMinRangeTextBox.TextChanged += OnBallisticsMinRangeChanged;
				BallisticsMaxRangeTextBox.TextChanged += OnBallisticsMaxRangeChanged;
				BallisticsIncrementTextBox.TextChanged += OnBallisticsIncrementChanged;
				BallisticsTargetRangeTextBox.TextChanged += OnBallisticsTargetRangeChanged;

				BallisticsBatchCombo.SelectedIndexChanged += OnBallisticsBatchSelected;
				BallisticsBulletCombo.SelectedIndexChanged += OnBallisticsBulletSelected;
				BallisticsCaliberCombo.SelectedIndexChanged += OnBallisticsCaliberSelected;
				BallisticsChargeCombo.SelectedIndexChanged += OnBallisticsChargeSelected;
				BallisticsFirearmCombo.SelectedIndexChanged += OnBallisticsFirearmSelected;
				BallisticsFirearmTypeCombo.SelectedIndexChanged += OnBallisticsFirearmTypeSelected;
				BallisticsLoadCombo.SelectedIndexChanged += OnBallisticsLoadSelected;

				BallisticsBatchTestVelocityRadioButton.Click += OnBallisticsBatchTestVelocityClicked;
				BallisticsLoadDataVelocityRadioButton.Click += OnBallisticsLoadDataVelocityClicked;

				//				BallisticsKestrelButton.Click += OnBallisticsKestrelButtonClicked;

				BallisticsResetButton.Click += OnBallisticsResetClicked;

				SaveReferenceBulletButton.Click += OnSaveReferenceBulletClicked;
				RestoreReferenceBulletButton.Click += OnRestoreReferenceBulletClicked;

				CompareToReferenceBulletCheckBox.Click += OnCompareToReferenceBulletClicked;
				BallisticsUseSFCheckBox.Click += OnUseSFClicked;

				ElevationTurretUpDown.ValueChanged += OnBallisticsElevationTurretChanged;
				WindageTurretUpDown.ValueChanged += OnBallisticsWindageTurretChanged;

				ResetElevationTurretButton.Click += OnBallisticsResetElevationTurretClicked;
				ResetWindageTurretButton.Click += OnBallisticsResetWindageTurretClicked;

				ShowApexMarkerCheckBox.Click += OnShowApexMarkersClicked;
				ShowDropChartRangeMarkersCheckBox.Click += OnShowDropChartRangeMarkersClicked;
				ShowGroundStrikeMarkerCheckBox.Click += OnShowGroundStrikeMarkersClicked;
				ShowReferenceDataCheckBox.Click += OnShowReferenceDataClicked;
				ShowTransonicMarkersCheckBox.Click += OnShowTransonicMarkersClicked;
				ShowWindDriftRangeMarkersCheckBox.Click += OnShowWindDriftRangeMarkersClicked;

				BallisticsPrintButton.Click += OnBallisticsPrintClicked;

				m_nDropChartHeight = BulletDropChart.Height;
				m_nDropChartWidth = BulletDropChart.Width;

				//----------------------------------------------------------------------------*
				// Populate Turret Type
				//----------------------------------------------------------------------------*

				PopulateBallisticsTurretTypeCombo();

				//----------------------------------------------------------------------------*
				// Set reference bullet
				//----------------------------------------------------------------------------*

				if (m_DataFiles.Preferences.BallisticsData == null)
					m_DataFiles.Preferences.BallisticsData = new cBallistics();

				m_BallisticsData = new cBallistics(m_DataFiles.Preferences.BallisticsData);

				//----------------------------------------------------------------------------*
				// Set up chart graphics
				//----------------------------------------------------------------------------*

				m_DropChartTarget = Properties.Resources.DropChartTarget;

				m_DropChartStandingShooter = Properties.Resources.DropChartStandingShooter;
				m_DriftChartShooter = Properties.Resources.DriftChartShooter;

				m_GroundStrike = Properties.Resources.GroundStrike;

				SetChartBackgrounds();

				//----------------------------------------------------------------------------*
				// Set up the Kestrel timer
				//----------------------------------------------------------------------------*

				if (m_KestrelTimer == null)
					m_KestrelTimer = new Timer();

				m_KestrelTimer.Interval = 1000;

				//				m_KestrelTimer.Tick += OnKestrelTimer;

				//----------------------------------------------------------------------------*
				// Set tooltips and Initialized Flag
				//----------------------------------------------------------------------------*

				SetStaticToolTips();

				m_fBallisticsTabInitialized = true;
				}

			//----------------------------------------------------------------------------*
			// Operations that are always performed
			//----------------------------------------------------------------------------*

			m_BallisticsData = new cBallistics(m_DataFiles.Preferences.BallisticsData);

			PopulateBallisticsTab();
			}

		//============================================================================*
		// OnBallisticsAltitudeChanged()
		//============================================================================*

		protected void OnBallisticsAltitudeChanged(Object sender, EventArgs args)
			{
			if (!m_fInitialized || m_fPopulating)
				return;

			SetBallisticsAltitude();

			SetDensityAltitude();

			UpdateBallisticsTabButtons();

			if (m_fCalculateOK)
				PopulateBallisticsData(true);
			}

		//============================================================================*
		// OnBallisticsBatchSelected()
		//============================================================================*

		protected void OnBallisticsBatchSelected(Object sender, EventArgs args)
			{
			if (!m_fBallisticsTabInitialized || m_fPopulating)
				return;

			PopulateBallisticsLoadCombo();
			}

		//============================================================================*
		// OnBallisticsBatchTestVelocityClicked()
		//============================================================================*

		protected void OnBallisticsBatchTestVelocityClicked(Object sender, EventArgs args)
			{
			BallisticsBatchTestVelocityRadioButton.Checked = !BallisticsBatchTestVelocityRadioButton.Checked;

			if (BallisticsBatchTestVelocityRadioButton.Checked && BallisticsLoadDataVelocityRadioButton.Checked)
				BallisticsLoadDataVelocityRadioButton.Checked = false;

			SetBallisticsData();
			}

		//============================================================================*
		// OnBallisticsBulletSelected()
		//============================================================================*

		protected void OnBallisticsBulletSelected(Object sender, EventArgs args)
			{
			if (!m_fBallisticsTabInitialized || m_fPopulating)
				return;

			SetBallisticsData();
			}

		//============================================================================*
		// OnBallisticsCaliberSelected()
		//============================================================================*

		protected void OnBallisticsCaliberSelected(Object sender, EventArgs args)
			{
			if (!m_fBallisticsTabInitialized || m_fPopulating)
				return;

			PopulateBallisticsBulletCombo();
			}

		//============================================================================*
		// OnBallisticsChargeSelected()
		//============================================================================*

		protected void OnBallisticsChargeSelected(Object sender, EventArgs args)
			{
			if (!m_fBallisticsTabInitialized || m_fPopulating)
				return;

			PopulateBallisticsCaliberCombo();
			}

		//============================================================================*
		// OnBallisticsBCChanged()
		//============================================================================*

		protected void OnBallisticsBCChanged(Object sender, EventArgs args)
			{
			if (!m_fBallisticsTabInitialized || m_fPopulating)
				return;

			m_BallisticsData.BallisticCoefficient = BallisticsBCTextBox.Value;

			UpdateBallisticsTabButtons();

			if (m_fCalculateOK)
				PopulateBallisticsData(true);
			}

		//============================================================================*
		// OnBallisticsBulletDiameterChanged()
		//============================================================================*

		protected void OnBallisticsBulletDiameterChanged(Object sender, EventArgs args)
			{
			if (!m_fBallisticsTabInitialized || m_fPopulating)
				return;

			m_BallisticsData.BulletDiameter = cDataFiles.MetricToStandard(BallisticsBulletDiameterTextBox.Value, cDataFiles.eDataType.Dimension);

			UpdateBallisticsTabButtons();

			if (m_fCalculateOK)
				PopulateBallisticsData(true);
			}

		//============================================================================*
		// OnBallisticsBulletLengthChanged()
		//============================================================================*

		protected void OnBallisticsBulletLengthChanged(Object sender, EventArgs args)
			{
			if (!m_fInitialized || m_fPopulating)
				return;

			m_BallisticsData.BulletLength = cDataFiles.MetricToStandard(BallisticsBulletLengthTextBox.Value, cDataFiles.eDataType.Dimension);

			UpdateBallisticsTabButtons();

			if (m_fCalculateOK)
				PopulateBallisticsData(true);
			}

		//============================================================================*
		// OnBallisticsBulletWeightChanged()
		//============================================================================*

		protected void OnBallisticsBulletWeightChanged(Object sender, EventArgs args)
			{
			if (!m_fInitialized || m_fPopulating)
				return;

			m_BallisticsData.BulletWeight = cDataFiles.MetricToStandard(BallisticsBulletWeightTextBox.Value, cDataFiles.eDataType.BulletWeight);

			UpdateBallisticsTabButtons();

			if (m_fCalculateOK)
				PopulateBallisticsData(true);
			}

		//============================================================================*
		// OnBallisticsElevationTurretChanged()
		//============================================================================*

		protected void OnBallisticsElevationTurretChanged(Object sender, EventArgs args)
			{
			if (!m_fInitialized || m_fPopulating)
				return;

			UpdateBallisticsTabButtons();

			if (m_fCalculateOK)
				PopulateBallisticsData(false);
			}

		//============================================================================*
		// OnBallisticsFirearmSelected()
		//============================================================================*

		protected void OnBallisticsFirearmSelected(Object sender, EventArgs args)
			{
			if (!m_fInitialized || m_fPopulating)
				return;

			PopulateBallisticsBatchCombo();
			}

		//============================================================================*
		// OnBallisticsFirearmTypeSelected()
		//============================================================================*

		protected void OnBallisticsFirearmTypeSelected(Object sender, EventArgs args)
			{
			if (!m_fInitialized || m_fPopulating)
				return;

			PopulateBallisticsFirearmCombo();
			}

		//============================================================================*
		// OnBallisticsHumidityChanged()
		//============================================================================*

		protected void OnBallisticsHumidityChanged(Object sender, EventArgs args)
			{
			if (!m_fInitialized || m_fPopulating)
				return;

			SetBallisticsHumidity();

			UpdateBallisticsTabButtons();

			if (m_fCalculateOK)
				PopulateBallisticsData(true);
			}

		//============================================================================*
		// OnBallisticsIncrementChanged()
		//============================================================================*

		protected void OnBallisticsIncrementChanged(Object sender, EventArgs args)
			{
			if (!m_fInitialized || m_fPopulating)
				return;

			m_BallisticsData.Increment = cDataFiles.MetricToStandard(BallisticsIncrementTextBox.Value, cDataFiles.eDataType.Range);
			m_DataFiles.Preferences.BallisticsData.Increment = cDataFiles.MetricToStandard(BallisticsIncrementTextBox.Value, cDataFiles.eDataType.Range);

			SetBallisticsMinMax();

			UpdateBallisticsTabButtons();

			if (m_fCalculateOK)
				PopulateBallisticsData(true);
			}

		//============================================================================*
		// OnBallisticsKestrelButtonClicked()
		//============================================================================*
		/*
				protected void OnBallisticsKestrelButtonClicked(Object sender, EventArgs args)
					{
					if (m_RWKestrel.Connected)
						{
						m_KestrelTimer.Stop();

						m_RWKestrel.Disconnect();
						}
					else
						{
						if (m_RWKestrel.Connect())
							{
							PopulateBallisticsAtmosphericData();

							m_KestrelTimer.Start();
							}
						}

					UpdateBallisticsTabButtons();
					}
		*/
		//============================================================================*
		// OnBallisticsLoadSelected()
		//============================================================================*

		protected void OnBallisticsLoadSelected(Object sender, EventArgs args)
			{
			if (!m_fInitialized || m_fPopulating)
				return;

			PopulateBallisticsChargeCombo();
			}

		//============================================================================*
		// OnBallisticsLoadDataVelocityClicked()
		//============================================================================*

		protected void OnBallisticsLoadDataVelocityClicked(Object sender, EventArgs args)
			{
			BallisticsLoadDataVelocityRadioButton.Checked = !BallisticsLoadDataVelocityRadioButton.Checked;

			if (BallisticsLoadDataVelocityRadioButton.Checked && BallisticsBatchTestVelocityRadioButton.Checked)
				BallisticsBatchTestVelocityRadioButton.Checked = false;

			SetBallisticsData();
			}

		//============================================================================*
		// OnBallisticsMaxRangeChanged()
		//============================================================================*

		protected void OnBallisticsMaxRangeChanged(Object sender, EventArgs args)
			{
			if (!m_fInitialized || m_fPopulating)
				return;

			m_BallisticsData.MaxRange = cDataFiles.MetricToStandard(BallisticsMaxRangeTextBox.Value, cDataFiles.eDataType.Range);
			m_DataFiles.Preferences.BallisticsData.MaxRange = (int) cDataFiles.MetricToStandard(BallisticsMaxRangeTextBox.Value, cDataFiles.eDataType.Range);

			SetBallisticsMinMax();

			UpdateBallisticsTabButtons();

			if (m_fCalculateOK)
				PopulateBallisticsData(true);
			}

		//============================================================================*
		// OnBallisticsMinRangeChanged()
		//============================================================================*

		protected void OnBallisticsMinRangeChanged(Object sender, EventArgs args)
			{
			if (!m_fInitialized || m_fPopulating)
				return;

			m_BallisticsData.MinRange = (int) cDataFiles.MetricToStandard(BallisticsMinRangeTextBox.Value, cDataFiles.eDataType.Range);
			m_DataFiles.Preferences.BallisticsData.MinRange = (int) cDataFiles.MetricToStandard(BallisticsMinRangeTextBox.Value, cDataFiles.eDataType.Range);

			SetBallisticsMinMax();

			UpdateBallisticsTabButtons();

			if (m_fCalculateOK)
				PopulateBallisticsData(true);
			}

		//============================================================================*
		// OnBallisticsMuzzleVelocityChanged()
		//============================================================================*

		protected void OnBallisticsMuzzleVelocityChanged(Object sender, EventArgs args)
			{
			if (!m_fInitialized || m_fPopulating)
				return;

			m_BallisticsData.MuzzleVelocity = (int) cDataFiles.MetricToStandard(BallisticsMuzzleVelocityTextBox.Value, cDataFiles.eDataType.Velocity);

			UpdateBallisticsTabButtons();

			if (m_fCalculateOK)
				PopulateBallisticsData(true);
			}

		//============================================================================*
		// OnBallisticsPressureChanged()
		//============================================================================*

		protected void OnBallisticsPressureChanged(Object sender, EventArgs args)
			{
			if (!m_fInitialized || m_fPopulating)
				return;

			SetBallisticsPressure();

			SetDensityAltitude();

			UpdateBallisticsTabButtons();

			if (m_fCalculateOK)
				PopulateBallisticsData(true);
			}

		//============================================================================*
		// OnBallisticsPrintClicked()
		//============================================================================*

		protected void OnBallisticsPrintClicked(Object sender, EventArgs args)
			{
			cBallisticsPreviewDialog BallisticsPreviewDialog = new cBallisticsPreviewDialog(m_DataFiles, BallisticsListView, m_BallisticsData, BulletDropChart.Image, WindDriftChart.Image);

			BallisticsPreviewDialog.ShowDialog();
			}

		//============================================================================*
		// OnBallisticsResetClicked()
		//============================================================================*

		protected void OnBallisticsResetClicked(Object sender, EventArgs args)
			{
			ClearBallisticsDatabaseInfo();

			SetBallisticsMinMax();

			UpdateBallisticsTabButtons();

			if (m_fCalculateOK)
				PopulateBallisticsData(true);
			}

		//============================================================================*
		// OnBallisticsResetElevationTurretClicked()
		//============================================================================*

		protected void OnBallisticsResetElevationTurretClicked(Object sender, EventArgs args)
			{
			ElevationTurretUpDown.Value = 0;

			UpdateBallisticsTabButtons();

			if (m_fCalculateOK)
				PopulateBallisticsData(true);
			}

		//============================================================================*
		// OnBallisticsResetWindageTurretClicked()
		//============================================================================*

		protected void OnBallisticsResetWindageTurretClicked(Object sender, EventArgs args)
			{
			WindageTurretUpDown.Value = 0;

			UpdateBallisticsTabButtons();

			if (m_fCalculateOK)
				PopulateBallisticsData(true);
			}

		//============================================================================*
		// OnBallisticsScopeClickChanged()
		//============================================================================*

		protected void OnBallisticsScopeClickChanged(Object sender, EventArgs args)
			{
			if (!m_fInitialized || m_fPopulating)
				return;

			m_BallisticsData.ScopeClick = BallisticsScopeClickTextBox.Value;
			m_DataFiles.Preferences.BallisticsData.ScopeClick = BallisticsScopeClickTextBox.Value;

			UpdateBallisticsTabButtons();

			if (m_fCalculateOK)
				PopulateBallisticsData(true);
			}

		//============================================================================*
		// OnBallisticsSightHeightChanged()
		//============================================================================*

		protected void OnBallisticsSightHeightChanged(Object sender, EventArgs args)
			{
			if (!m_fInitialized || m_fPopulating)
				return;

			m_BallisticsData.SightHeight = cDataFiles.MetricToStandard(BallisticsSightHeightTextBox.Value, cDataFiles.eDataType.Firearm);
			m_DataFiles.Preferences.BallisticsData.SightHeight = cDataFiles.MetricToStandard(BallisticsSightHeightTextBox.Value, cDataFiles.eDataType.Firearm);

			UpdateBallisticsTabButtons();

			if (m_fCalculateOK)
				PopulateBallisticsData(true);
			}

		//============================================================================*
		// OnBallisticsTargetRangeChanged()
		//============================================================================*

		protected void OnBallisticsTargetRangeChanged(Object sender, EventArgs args)
			{
			if (!m_fInitialized || m_fPopulating)
				return;

			m_BallisticsData.TargetRange = (int) cDataFiles.MetricToStandard(BallisticsTargetRangeTextBox.Value, cDataFiles.eDataType.Range);
			m_DataFiles.Preferences.BallisticsData.TargetRange = (int) cDataFiles.MetricToStandard(BallisticsTargetRangeTextBox.Value, cDataFiles.eDataType.Range);

			SetBallisticsMinMax();

			UpdateBallisticsTabButtons();

			if (m_fCalculateOK)
				PopulateBallisticsData(false);
			}

		//============================================================================*
		// OnBallisticsTemperatureChanged()
		//============================================================================*

		protected void OnBallisticsTemperatureChanged(Object sender, EventArgs args)
			{
			if (!m_fInitialized || m_fPopulating)
				return;

			SetBallisticsTemperature();

			SetDensityAltitude();

			UpdateBallisticsTabButtons();

			if (m_fCalculateOK)
				PopulateBallisticsData(true);
			}

		//============================================================================*
		// OnBallisticsTurretTypeSelected()
		//============================================================================*

		protected void OnBallisticsTurretTypeSelected(Object sender, EventArgs args)
			{
			if (!m_fInitialized || m_fPopulating)
				return;

			m_BallisticsData.TurretType = (cFirearm.eTurretType) BallisticsTurretTypeComboBox.SelectedIndex;
			m_DataFiles.Preferences.BallisticsData.TurretType = (cFirearm.eTurretType) BallisticsTurretTypeComboBox.SelectedIndex;

			TurretTypeLabel.Text = m_BallisticsData.TurretTypeString;
			DriftTurretTypeLabel.Text = m_BallisticsData.TurretTypeString;

			UpdateBallisticsTabButtons();

			if (m_fCalculateOK)
				PopulateBallisticsData(true);
			}

		//============================================================================*
		// OnBallisticsTwistChanged()
		//============================================================================*

		protected void OnBallisticsTwistChanged(Object sender, EventArgs args)
			{
			if (!m_fInitialized || m_fPopulating)
				return;

			m_BallisticsData.Twist = cDataFiles.MetricToStandard(BallisticsTwistTextBox.Value, cDataFiles.eDataType.Firearm);
			m_DataFiles.Preferences.BallisticsData.Twist = cDataFiles.MetricToStandard(BallisticsTwistTextBox.Value, cDataFiles.eDataType.Firearm);

			UpdateBallisticsTabButtons();

			if (m_fCalculateOK)
				PopulateBallisticsData(true);
			}

		//============================================================================*
		// OnBallisticsUseDensityAltitudeClicked()
		//============================================================================*

		protected void OnBallisticsUseDensityAltitudeClicked(Object sender, EventArgs args)
			{
			if (!m_fInitialized || m_fPopulating)
				return;

			m_BallisticsData.UseDensityAltitude = BallisticsUseDensityAltitudeCheckBox.Checked;
			m_DataFiles.Preferences.BallisticsData.UseDensityAltitude = BallisticsUseDensityAltitudeCheckBox.Checked;

			UpdateBallisticsTabButtons();

			if (m_fCalculateOK)
				PopulateBallisticsData(true);
			}

		//============================================================================*
		// OnBallisticsUseStationPressureClicked()
		//============================================================================*

		protected void OnBallisticsUseStationPressureClicked(Object sender, EventArgs args)
			{
			if (!m_fInitialized || m_fPopulating)
				return;

			m_BallisticsData.UseStationPressure = BallisticsUseStationPressureCheckBox.Checked;
			m_DataFiles.Preferences.BallisticsData.UseStationPressure = BallisticsUseStationPressureCheckBox.Checked;

			UpdateBallisticsTabButtons();

			if (m_fCalculateOK)
				PopulateBallisticsData(true);
			}

		//============================================================================*
		// OnBallisticsWindageTurretChanged()
		//============================================================================*

		protected void OnBallisticsWindageTurretChanged(Object sender, EventArgs args)
			{
			if (!m_fInitialized || m_fPopulating)
				return;

			UpdateBallisticsTabButtons();

			if (m_fCalculateOK)
				PopulateBallisticsData(false);
			}

		//============================================================================*
		// OnBallisticsWindDirectionChanged()
		//============================================================================*

		protected void OnBallisticsWindDirectionChanged(Object sender, EventArgs args)
			{
			if (!m_fInitialized || m_fPopulating)
				return;

			SetBallisticsWindDirection();

			SetWindage();

			UpdateBallisticsTabButtons();

			if (m_fCalculateOK)
				PopulateBallisticsData(true);
			}

		//============================================================================*
		// OnBallisticsWindSpeedChanged()
		//============================================================================*

		protected void OnBallisticsWindSpeedChanged(Object sender, EventArgs args)
			{
			if (!m_fInitialized || m_fPopulating)
				return;

			SetBallisticsWindSpeed();

			SetWindage();

			UpdateBallisticsTabButtons();

			if (m_fCalculateOK)
				PopulateBallisticsData(true);
			}

		//============================================================================*
		// OnBallisticsZeroRangeChanged()
		//============================================================================*

		protected void OnBallisticsZeroRangeChanged(Object sender, EventArgs args)
			{
			if (!m_fInitialized || m_fPopulating)
				return;

			m_BallisticsData.ZeroRange = (int) cDataFiles.MetricToStandard(BallisticsZeroRangeTextBox.Value, cDataFiles.eDataType.Range);
			m_DataFiles.Preferences.BallisticsData.ZeroRange = (int) cDataFiles.MetricToStandard(BallisticsZeroRangeTextBox.Value, cDataFiles.eDataType.Range);

			UpdateBallisticsTabButtons();

			if (m_fCalculateOK)
				PopulateBallisticsData(true);
			}

		//============================================================================*
		// OnCompareToReferenceBulletClicked()
		//============================================================================*

		protected void OnCompareToReferenceBulletClicked(Object sender, EventArgs args)
			{
			PopulateBallisticsData();

			UpdateBallisticsTabButtons();
			}

		//============================================================================*
		// OnKestrelTimer()
		//============================================================================*
		/*
				protected void OnKestrelTimer(Object sender, EventArgs args)
					{
					if (!m_RWKestrel.Connected)
						{
						m_KestrelTimer.Stop();

						m_RWKestrel.Disconnect();

						UpdateBallisticsTabButtons();
						}
					else
						{
						m_RWKestrel.SnapShot();

						PopulateBallisticsAtmosphericData();
						}
					}
		*/
		//============================================================================*
		// OnRestoreReferenceBulletClicked()
		//============================================================================*

		protected void OnRestoreReferenceBulletClicked(Object sender, EventArgs args)
			{
			ClearBallisticsDatabaseInfo();

			m_BallisticsData = new cBallistics(m_DataFiles.Preferences.BallisticsData);

			PopulateBallisticsFirearmCombo();
			}

		//============================================================================*
		// OnSaveReferenceBulletClicked()
		//============================================================================*

		protected void OnSaveReferenceBulletClicked(Object sender, EventArgs args)
			{
			ClearBallisticsDatabaseInfo();

			m_DataFiles.Preferences.BallisticsData = new cBallistics(m_BallisticsData);

			PopulateBallisticsFirearmCombo();
			}

		//============================================================================*
		// OnShowApexMarkersClicked()
		//============================================================================*

		protected void OnShowApexMarkersClicked(Object sender, EventArgs args)
			{
			m_DataFiles.Preferences.ShowApexMarker = ShowApexMarkerCheckBox.Checked;

			PopulateBallisticsData(false);

			UpdateBallisticsTabButtons();

			if (m_fCalculateOK)
				PopulateBallisticsData(false);
			}

		//============================================================================*
		// OnShowDropChartRangeMarkersClicked()
		//============================================================================*

		protected void OnShowDropChartRangeMarkersClicked(Object sender, EventArgs args)
			{
			m_DataFiles.Preferences.ShowDropChartRangeMarkers = ShowDropChartRangeMarkersCheckBox.Checked;

			PopulateBallisticsData(false);

			UpdateBallisticsTabButtons();

			if (m_fCalculateOK)
				PopulateBallisticsData(false);
			}

		//============================================================================*
		// OnShowGroundStrikeMarkersClicked()
		//============================================================================*

		protected void OnShowGroundStrikeMarkersClicked(Object sender, EventArgs args)
			{
			m_DataFiles.Preferences.ShowGroundStrikeMarkers = ShowGroundStrikeMarkerCheckBox.Checked;

			PopulateBallisticsData(false);

			UpdateBallisticsTabButtons();

			if (m_fCalculateOK)
				PopulateBallisticsData(false);
			}

		//============================================================================*
		// OnShowReferenceDataClicked()
		//============================================================================*

		protected void OnShowReferenceDataClicked(Object sender, EventArgs args)
			{
			PopulateBallisticsInputData();

			UpdateBallisticsTabButtons();
			}

		//============================================================================*
		// OnShowTransonicMarkersClicked()
		//============================================================================*

		protected void OnShowTransonicMarkersClicked(Object sender, EventArgs args)
			{
			m_DataFiles.Preferences.ShowTransonicMarkers = ShowTransonicMarkersCheckBox.Checked;

			PopulateBallisticsData(false);

			UpdateBallisticsTabButtons();

			if (m_fCalculateOK)
				PopulateBallisticsData(false);
			}

		//============================================================================*
		// OnShowWindDriftRangeMarkersClicked()
		//============================================================================*

		protected void OnShowWindDriftRangeMarkersClicked(Object sender, EventArgs args)
			{
			m_DataFiles.Preferences.ShowWindDriftRangeMarkers = ShowWindDriftRangeMarkersCheckBox.Checked;

			PopulateBallisticsData(false);

			UpdateBallisticsTabButtons();

			if (m_fCalculateOK)
				PopulateBallisticsData(false);
			}

		//============================================================================*
		// OnUseSFClicked()
		//============================================================================*

		protected void OnUseSFClicked(Object sender, EventArgs args)
			{
			if (!m_fInitialized || m_fPopulating)
				return;

			m_DataFiles.Preferences.BallisticsUseSF = BallisticsUseSFCheckBox.Checked;

			UpdateBallisticsTabButtons();

			if (m_fCalculateOK)
				PopulateBallisticsData(true);
			}

		//============================================================================*
		// PopulateBallisticsAtmosphericData()
		//============================================================================*

		private void PopulateBallisticsAtmosphericData()
			{
			BallisticsAltitudeTextBox.Value = (int) cDataFiles.StandardToMetric(m_BallisticsData.Altitude, cDataFiles.eDataType.Altitude);
			SetBallisticsAltitude();

			BallisticsHumidityTextBox.Value = (int) (m_BallisticsData.Humidity * 100.0);
			SetBallisticsHumidity();

			BallisticsPressureTextBox.Value = cDataFiles.StandardToMetric(m_BallisticsData.Pressure, cDataFiles.eDataType.Pressure);
			SetBallisticsPressure();

			BallisticsTemperatureTextBox.Value = (int) (cDataFiles.StandardToMetric(m_BallisticsData.Temperature, cDataFiles.eDataType.Temperature));
			SetBallisticsTemperature();

			BallisticsWindDirectionTextBox.Value = m_BallisticsData.WindDirection;
			SetBallisticsWindDirection();

			BallisticsWindSpeedTextBox.Value = (int) (cDataFiles.StandardToMetric(m_BallisticsData.WindSpeed, cDataFiles.eDataType.Speed));
			SetBallisticsWindSpeed();

			/*
						BallisticsAltitudeTextBox.Value = (int) (m_RWKestrel.UseAltitude ? m_RWKestrel.Altitude : cDataFiles.StandardToMetric(m_BallisticsData.Altitude, cDataFiles.eDataType.Altitude));
						SetBallisticsAltitude();

						BallisticsHumidityTextBox.Value = (int) (m_RWKestrel.UseHumidity ? m_RWKestrel.RelativeHumidity : m_BallisticsData.Humidity * 100.0);
						SetBallisticsHumidity();

						BallisticsPressureTextBox.Value = m_RWKestrel.UseBarometricPressure ? m_RWKestrel.BarometricPressure : cDataFiles.StandardToMetric(m_BallisticsData.Pressure, cDataFiles.eDataType.Pressure);
						SetBallisticsPressure();

						BallisticsTemperatureTextBox.Value = (int) (m_RWKestrel.UseTemperature ? m_RWKestrel.Temperature : cDataFiles.StandardToMetric(m_BallisticsData.Temperature, cDataFiles.eDataType.Temperature));
						SetBallisticsTemperature();

						BallisticsWindDirectionTextBox.Value = m_RWKestrel.UseWindDirection ? m_RWKestrel.TrueCompass : m_BallisticsData.WindDirection;
						SetBallisticsWindDirection();

						BallisticsWindSpeedTextBox.Value = (int) (m_RWKestrel.UseWindSpeed ? m_RWKestrel.WindSpeed : cDataFiles.StandardToMetric(m_BallisticsData.WindSpeed, cDataFiles.eDataType.Speed));
						SetBallisticsWindSpeed();
			*/
			SetDensityAltitude();
			SetWindage();

			UpdateBallisticsTabButtons();

			if (m_fCalculateOK)
				PopulateBallisticsData(true);
			}

		//============================================================================*
		// PopulateBallisticsBatchCombo()
		//============================================================================*

		private void PopulateBallisticsBatchCombo()
			{
			m_fPopulating = true;

			//----------------------------------------------------------------------------*
			// Get Filter Data
			//----------------------------------------------------------------------------*

			cFirearm.eFireArmType eFirearmType = BallisticsFirearmTypeCombo.Value;

			cFirearm Firearm = null;

			if (BallisticsFirearmCombo.SelectedIndex > 0)
				Firearm = (cFirearm) BallisticsFirearmCombo.SelectedItem;

			//----------------------------------------------------------------------------*
			// Populate the Batch Combo
			//----------------------------------------------------------------------------*

			BallisticsBatchCombo.Items.Clear();

			BallisticsBatchCombo.Items.Add("No Specific Batch");

			cBatch SelectBatch = null;

			foreach (cBatch CheckBatch in m_DataFiles.BatchList)
				{
				if (CheckBatch.Load.FirearmType == eFirearmType &&
					(Firearm == null || (CheckBatch.Firearm != null && CheckBatch.Firearm.CompareTo(Firearm) == 0)) &&
					(Firearm == null || Firearm.HasCaliber(CheckBatch.Load.Caliber)) &&
					(CheckBatch.BatchTest != null && CheckBatch.BatchTest.MuzzleVelocity > 0) &&
					(!CheckBatch.Archived || m_DataFiles.Preferences.ShowArchivedBatches))
					{
					BallisticsBatchCombo.Items.Add(CheckBatch);

					if (CheckBatch.CompareTo(m_DataFiles.Preferences.BallisticsBatch) == 0)
						SelectBatch = CheckBatch;
					}
				}

			//----------------------------------------------------------------------------*
			// Select a Batch
			//----------------------------------------------------------------------------*

			if (SelectBatch != null)
				BallisticsBatchCombo.SelectedItem = SelectBatch;
			else
				BallisticsBatchCombo.SelectedIndex = 0;

			m_fPopulating = false;

			PopulateBallisticsLoadCombo();
			}

		//============================================================================*
		// PopulateBallisticsBulletCombo()
		//============================================================================*

		private void PopulateBallisticsBulletCombo()
			{
			m_fPopulating = true;

			//----------------------------------------------------------------------------*
			// Get Filter Data
			//----------------------------------------------------------------------------*

			cFirearm.eFireArmType eFirearmType = BallisticsFirearmTypeCombo.Value;

			cFirearm Firearm = null;

			if (BallisticsFirearmCombo.SelectedIndex > 0)
				Firearm = (cFirearm) BallisticsFirearmCombo.SelectedItem;

			cBatch Batch = null;

			if (BallisticsBatchCombo.SelectedIndex > 0)
				Batch = (cBatch) BallisticsBatchCombo.SelectedItem;

			cLoad Load = null;

			if (BallisticsLoadCombo.SelectedIndex > 0)
				Load = (cLoad) BallisticsLoadCombo.SelectedItem;

			cCaliber Caliber = null;

			if (Batch != null)
				Caliber = Batch.Load.Caliber;
			else
				{
				if (Load != null)
					{
					Caliber = Load.Caliber;
					}
				else
					{
					if (BallisticsCaliberCombo.SelectedIndex > 0)
						Caliber = (cCaliber) BallisticsCaliberCombo.SelectedItem;
					}
				}

			//----------------------------------------------------------------------------*
			// Populate Bullet Combo
			//----------------------------------------------------------------------------*

			BallisticsBulletCombo.Items.Clear();

			cBullet SelectBullet = null;

			if (Batch != null && Batch.Load != null)
				{
				BallisticsBulletCombo.Items.Add(Batch.Load.Bullet);
				}
			else
				{
				if (Load != null)
					{
					BallisticsBulletCombo.Items.Add(Load.Bullet);
					}
				else
					{
					BallisticsBulletCombo.Items.Add("No Specific Bullet");

					foreach (cBullet CheckBullet in m_DataFiles.BulletList)
						{
						if ((!m_DataFiles.Preferences.HideUncheckedSupplies || CheckBullet.Checked) &&
							CheckBullet.FirearmType == eFirearmType &&
							(Caliber == null || CheckBullet.HasCaliber(Caliber)))
							{
							bool fBulletOK = false;

							if (Firearm == null)
								fBulletOK = true;
							else
								{
								foreach (cFirearmCaliber FirearmCaliber in Firearm.CaliberList)
									{
									fBulletOK = CheckBullet.HasCaliber(FirearmCaliber.Caliber);

									if (fBulletOK)
										break;
									}
								}

							if (fBulletOK)
								{
								BallisticsBulletCombo.Items.Add(CheckBullet);

								if (CheckBullet.CompareTo(m_DataFiles.Preferences.BallisticsBullet) == 0)
									SelectBullet = CheckBullet;
								}
							}
						}
					}
				}

			if (SelectBullet != null)
				BallisticsBulletCombo.SelectedItem = SelectBullet;
			else
				{
				if (BallisticsBulletCombo.Items.Count > 0)
					BallisticsBulletCombo.SelectedIndex = 0;
				}

			m_fPopulating = false;

			SetBallisticsData();
			}

		//============================================================================*
		// PopulateBallisticsCaliberCombo()
		//============================================================================*

		private void PopulateBallisticsCaliberCombo()
			{
			m_fPopulating = true;

			//----------------------------------------------------------------------------*
			// Get Filter Data
			//----------------------------------------------------------------------------*

			cFirearm.eFireArmType eFirearmType = BallisticsFirearmTypeCombo.Value;

			cFirearm Firearm = null;

			if (BallisticsFirearmCombo.SelectedIndex > 0)
				Firearm = (cFirearm) BallisticsFirearmCombo.SelectedItem;

			cBatch Batch = null;

			if (BallisticsBatchCombo.SelectedIndex > 0)
				Batch = (cBatch) BallisticsBatchCombo.SelectedItem;

			cLoad Load = null;

			if (Batch != null)
				Load = Batch.Load;
			else
				{
				if (BallisticsLoadCombo.SelectedIndex > 0)
					Load = (cLoad) BallisticsLoadCombo.SelectedItem;
				}

			//----------------------------------------------------------------------------*
			// Populate the Caliber Combo
			//----------------------------------------------------------------------------*

			BallisticsCaliberCombo.Items.Clear();

			cCaliber SelectCaliber = null;

			if (Batch != null && Batch.Load != null)
				{
				BallisticsCaliberCombo.Items.Add(Batch.Load.Caliber);

				SelectCaliber = Batch.Load.Caliber;
				}
			else
				{
				if (Load != null)
					{
					BallisticsCaliberCombo.Items.Add(Load.Caliber);

					SelectCaliber = Load.Caliber;
					}
				else
					{
					if (Firearm != null)
						{
						foreach (cFirearmCaliber FirearmCaliber in Firearm.CaliberList)
							{
							BallisticsCaliberCombo.Items.Add(FirearmCaliber.Caliber);

							if (FirearmCaliber.Primary)
								SelectCaliber = FirearmCaliber.Caliber;
							}
						}
					else
						{
						BallisticsCaliberCombo.Items.Add("No Specific Caliber");

						foreach (cCaliber CheckCaliber in m_DataFiles.CaliberList)
							{
							if ((!m_DataFiles.Preferences.HideUncheckedCalibers || CheckCaliber.Checked) &&
								CheckCaliber.FirearmType == eFirearmType)
								{
								bool fFoundBullets = false;

								foreach (cBullet CheckBullet in m_DataFiles.BulletList)
									{
									fFoundBullets = CheckBullet.HasCaliber(CheckCaliber, m_DataFiles.Preferences.HideUncheckedCalibers);

									if (fFoundBullets)
										break;
									}

								if (fFoundBullets)
									{
									BallisticsCaliberCombo.Items.Add(CheckCaliber);

									if (CheckCaliber.CompareTo(m_DataFiles.Preferences.BallisticsCaliber) == 0)
										SelectCaliber = CheckCaliber;
									}
								}
							}
						}
					}
				}

			if (SelectCaliber != null)
				BallisticsCaliberCombo.SelectedItem = SelectCaliber;
			else
				{
				if (BallisticsCaliberCombo.Items.Count > 0)
					BallisticsCaliberCombo.SelectedIndex = 0;
				}

			m_fPopulating = false;

			PopulateBallisticsBulletCombo();
			}

		//============================================================================*
		// PopulateBallisticsChargeCombo()
		//============================================================================*

		private void PopulateBallisticsChargeCombo()
			{
			m_fPopulating = true;

			//----------------------------------------------------------------------------*
			// Get Filter Data
			//----------------------------------------------------------------------------*

			cBatch Batch = null;

			if (BallisticsBatchCombo.SelectedIndex > 0)
				Batch = (cBatch) BallisticsBatchCombo.SelectedItem;

			cLoad Load = null;

			if (Batch != null)
				Load = Batch.Load;
			else
				{
				if (BallisticsLoadCombo.SelectedIndex > 0)
					Load = (cLoad) BallisticsLoadCombo.SelectedItem;
				}

			//----------------------------------------------------------------------------*
			// Create format strings
			//----------------------------------------------------------------------------*

			string strPowderWeightFormat = "{0:F";
			strPowderWeightFormat += String.Format("{0:G0}", m_DataFiles.Preferences.PowderWeightDecimals);
			strPowderWeightFormat += "}";

			//----------------------------------------------------------------------------*
			// Reset the list view
			//----------------------------------------------------------------------------*

			BallisticsChargeCombo.Items.Clear();

			double SelectCharge = 0.0;

			//----------------------------------------------------------------------------*
			// If no batch & load selected, no need for charge weights
			//----------------------------------------------------------------------------*

			if (Batch == null && Load == null)
				{
				BallisticsChargeCombo.Items.Add("N/A");
				}
			else
				{
				//----------------------------------------------------------------------------*
				// If a batch is selected, set the charge to that powder weight
				//----------------------------------------------------------------------------*

				if (BallisticsBatchCombo.SelectedIndex != 0)
					{
					BallisticsChargeCombo.Items.Add(String.Format(strPowderWeightFormat, (BallisticsBatchCombo.SelectedItem as cBatch).PowderWeight));
					}
				else
					{
					//----------------------------------------------------------------------------*
					// Otherwise, set the load's charge weights
					//----------------------------------------------------------------------------*

					foreach (cCharge CheckCharge in Load.ChargeList)
						{
						if (CheckCharge.TestList.Count > 0)
							{
							BallisticsChargeCombo.Items.Add(String.Format(strPowderWeightFormat, CheckCharge.PowderWeight));

							if (CheckCharge.PowderWeight == m_DataFiles.Preferences.BallisticsCharge)
								SelectCharge = CheckCharge.PowderWeight;
							}
						}
					}
				}

			if (SelectCharge != 0.0)
				BallisticsChargeCombo.SelectedItem = String.Format(strPowderWeightFormat, SelectCharge);

			if (BallisticsChargeCombo.SelectedIndex < 0 && BallisticsChargeCombo.Items.Count > 0)
				BallisticsChargeCombo.SelectedIndex = 0;

			m_fPopulating = false;

			PopulateBallisticsCaliberCombo();
			}

		//============================================================================*
		// PopulateBallisticsData()
		//============================================================================*

		private void PopulateBallisticsData(bool fCalculateTable = true)
			{
			//----------------------------------------------------------------------------*
			// BallisticsListView Columns
			//----------------------------------------------------------------------------*

			if (fCalculateTable)
				{
				ClearBallisticsResults();

				foreach (ColumnHeader CheckHeader in BallisticsListView.Columns)
					{
					int nWidth = m_DataFiles.Preferences.GetColumnWidth(cPreferences.eApplicationListView.BallisticsListView, CheckHeader.Text);

					if (nWidth != 0)
						CheckHeader.Width = nWidth;
					}

				ColumnHeader Header = BallisticsListView.Columns[0];

				if (Header != null)
					Header.Text = String.Format("Range ({0})", cDataFiles.MetricString(cDataFiles.eDataType.Range));

				Header = BallisticsListView.Columns[1];

				if (Header != null)
					Header.Text = String.Format("Drop ( {0})", cDataFiles.MetricString(cDataFiles.eDataType.GroupSize));

				Header = BallisticsListView.Columns[2];

				if (Header != null)
					Header.Text = "Drop " + (m_BallisticsData.TurretType == cFirearm.eTurretType.MOA ? "(MOA)" : "(Mils)");

				Header = BallisticsListView.Columns[3];

				if (Header != null)
					Header.Text = String.Format("Wind Drift ( {0})", cDataFiles.MetricString(cDataFiles.eDataType.GroupSize));

				Header = BallisticsListView.Columns[4];

				if (Header != null)
					Header.Text = "Wind Drift " + (m_BallisticsData.TurretType == cFirearm.eTurretType.MOA ? "(MOA)" : "(Mils)");

				Header = BallisticsListView.Columns[5];

				if (Header != null)
					Header.Text = "Velocity " + String.Format("({0})", cDataFiles.MetricString(cDataFiles.eDataType.Velocity));
				}
			else
				SetChartBackgrounds();

			//----------------------------------------------------------------------------*
			// Clear Ballistics Results and set up images
			//----------------------------------------------------------------------------*

			Font RangeFont = new Font(this.Font.FontFamily, this.Font.SizeInPoints / 1.75f, FontStyle.Bold);

			Pen ReferencePen = new Pen(Color.Red, 2.0f);
			Pen ReferenceMarkerPen = new Pen(Color.Red, 1.0f);
			Brush ReferenceBrush = Brushes.Red;

			Pen DataPen = new Pen(Color.Black, 2.0f);
			Pen DataMarkerPen = new Pen(Color.Black, 1.0f);
			Brush DataBrush = Brushes.Black;

			Pen RangePen = new Pen(Color.Black, 1.0f);

			Bitmap DropChartImage = (Bitmap) BulletDropChart.Image;
			Bitmap DriftChartImage = (Bitmap) WindDriftChart.Image;

			Graphics g = Graphics.FromImage(DropChartImage);
			Graphics g1 = Graphics.FromImage(DriftChartImage);

			//----------------------------------------------------------------------------*
			// Actvate the Ballistics engines
			//----------------------------------------------------------------------------*

			bool fCompare = CompareToReferenceBulletCheckBox.Checked;

			bool fShowReferenceData = fCompare;
			bool fShowCurrentData = true;

			if (m_DataFiles.Preferences.BallisticsData.CompareTo(m_BallisticsData) == 0)
				{
				fShowReferenceData = true;
				fShowCurrentData = false;
				}

			m_BallisticsData.Active = true;
			m_DataFiles.Preferences.BallisticsData.Active = fShowReferenceData;

			bool fShowGroundStrikeMarker = ShowGroundStrikeMarkerCheckBox.Checked;
			bool fShowTransonicMarker = ShowTransonicMarkersCheckBox.Checked;

			CurrentDataLegendLabel.Visible = fShowCurrentData;
			CurrentDataDriftLegendLabel.Visible = fShowCurrentData;

			ReferenceDataLegendLabel.Visible = fShowReferenceData;
			ReferenceDataDriftLegendLabel.Visible = fShowReferenceData;

			//----------------------------------------------------------------------------*
			// Initialize Point Data
			//----------------------------------------------------------------------------*

			Point LastDataPoint = new Point(m_nChartStartX, m_nChartStartY);
			Point NextDataPoint = new Point(m_nChartStartX, m_nChartStartY);
			Point LastReferencePoint = new Point(m_nChartStartX, m_nChartStartY);
			Point NextReferencePoint = new Point(m_nChartStartX, m_nChartStartY);

			Point LastWindageDataPoint = new Point(m_nChartStartX, m_nDriftChartStartY);
			Point NextWindageDataPoint = new Point(m_nChartStartX, m_nDriftChartStartY);
			Point LastWindageReferencePoint = new Point(m_nChartStartX, m_nDriftChartStartY);
			Point NextWindageReferencePoint = new Point(m_nChartStartX, m_nDriftChartStartY);

			int nNextX = 0;
			int nNextY = 0;

			int nNextRange = (int) cDataFiles.StandardToMetric(m_BallisticsData.MinRange, cDataFiles.eDataType.Range);

			//----------------------------------------------------------------------------*
			// Initialize Chart Data
			//----------------------------------------------------------------------------*

			string strBullseyeFormat = " - {0:F";
			strBullseyeFormat += String.Format("{0:G0}", m_DataFiles.Preferences.GroupDecimals);
			strBullseyeFormat += "} ";
			strBullseyeFormat += cDataFiles.MetricString(cDataFiles.eDataType.GroupSize);

			bool fGroundStrike = false;
			int nGroundStrikeRange = 0;

			bool fReferenceGroundStrike = false;
			int nReferenceGroundStrikeRange = 0;

			int nReferenceDriftGroundStrikeY = 0;
			int nDriftGroundStrikeY = 0;

			int nApexRange = 0;
			double dApex = -10000.0;

			int nReferenceApexRange = 0;
			double dReferenceApex = -10000.0;

			int nTransonicRange = -1;
			double dTransonicPath = 0.0;

			int nReferenceTransonicRange = -1;
			double dReferenceTransonicPath = 0.0;

			decimal nElevationTurretClicks = ElevationTurretUpDown.Value;
			decimal nWindageTurretClicks = WindageTurretUpDown.Value;

			//----------------------------------------------------------------------------*
			// Show Speed of Sound Label
			//----------------------------------------------------------------------------*

			double dSpeedOfSound = m_DataFiles.Preferences.MetricVelocities ? m_BallisticsData.SpeedOfSoundInMS : m_BallisticsData.SpeedOfSoundInFPS;

			BallisticsSoundSpeedLabel.Text = String.Format("{0:F1} {1}", dSpeedOfSound, cDataFiles.MetricString(cDataFiles.eDataType.Velocity));

			//----------------------------------------------------------------------------*
			// Initialize Chart Legend Data
			//----------------------------------------------------------------------------*

			CurrentDataLegendLabel.Text = "Current Data";
			ReferenceDataLegendLabel.Text = "Reference Data";

			CurrentDataDriftLegendLabel.Text = "Current Data";
			ReferenceDataDriftLegendLabel.Text = "Reference Data";

			if (!fShowCurrentData)
				{
				ReferenceDataLegendLabel.Location = new Point(ReferenceDataLegendLabel.Location.X, 247);
				ReferenceDataDriftLegendLabel.Location = new Point(ReferenceDataLegendLabel.Location.X, 247);
				}
			else
				{
				ReferenceDataLegendLabel.Location = new Point(ReferenceDataLegendLabel.Location.X, 269);
				ReferenceDataDriftLegendLabel.Location = new Point(ReferenceDataLegendLabel.Location.X, 269);
				}

			//----------------------------------------------------------------------------*
			// Now loop thru the range increments
			//----------------------------------------------------------------------------*

			for (int nRange = 0; nRange <= m_BallisticsData.MaxRange; nRange++)
				{
				double dRange = cDataFiles.MetricToStandard(nRange, cDataFiles.eDataType.Range);

				nNextX = m_nChartStartX + (int) (dRange * m_dPixelsPerXUnit);

				//============================================================================*
				// Bullet Drop Chart
				//============================================================================*

				//----------------------------------------------------------------------------*
				// Draw Reference Trajectory if needed
				//----------------------------------------------------------------------------*

				if (fShowReferenceData && nNextX <= BulletDropChart.Width - 50)
					{
					//----------------------------------------------------------------------------*
					// Calculate next point
					//----------------------------------------------------------------------------*

					m_DataFiles.Preferences.BallisticsData.Range = dRange;

					//----------------------------------------------------------------------------*
					// Adjust for Turret Clicks
					//----------------------------------------------------------------------------*

					double dPath = m_DataFiles.Preferences.BallisticsData.BulletPath;
					double dMOA = 0.0;

					if (nElevationTurretClicks != 0)
						{
						double dTurretClick = dRange > 0.0 ? ((dRange / 100.0) * 1.047) * m_BallisticsData.ScopeClick : 0.0;

						if (m_BallisticsData.TurretType == cFirearm.eTurretType.MilDot)
							dTurretClick *= 3.44;

						dMOA = (double) ((double) nElevationTurretClicks * dTurretClick);

						if (!Double.IsInfinity(dMOA))
							dPath += dMOA;
						}

					//----------------------------------------------------------------------------*
					// Have we gone transonic?
					//----------------------------------------------------------------------------*

					if (nReferenceTransonicRange < 0 && m_DataFiles.Preferences.BallisticsData.RemainingVelocity < dSpeedOfSound)
						{
						nReferenceTransonicRange = nRange;
						dReferenceTransonicPath = dPath;
						}

					//----------------------------------------------------------------------------*
					// Calculate the next points
					//----------------------------------------------------------------------------*

					if (nRange > 0 && !fReferenceGroundStrike)
						{
						nNextY = m_nChartStartY - (int) (dPath * m_dPixelsPerYUnit);

						NextReferencePoint.X = nNextX;
						NextReferencePoint.Y = nNextY;

						//----------------------------------------------------------------------------*
						// Check Apogee
						//----------------------------------------------------------------------------*

						if (dPath > dReferenceApex)
							{
							dReferenceApex = dPath;
							nReferenceApexRange = nRange;
							}

						//----------------------------------------------------------------------------*
						// Bullet at Target?
						//----------------------------------------------------------------------------*

						if (nRange == (int) cDataFiles.StandardToMetric(m_DataFiles.Preferences.BallisticsData.TargetRange, cDataFiles.eDataType.Range))
							{
							string strPath = (dPath == 0.0) ? " - Bullseye!" : String.Format(strBullseyeFormat, Math.Abs(cDataFiles.StandardToMetric(dPath, cDataFiles.eDataType.GroupSize)));

							if (dPath != 0.0)
								strPath += (dPath < 0.0 ? " low" : " high");

							ReferenceDataLegendLabel.Text += strPath;
							}

						//----------------------------------------------------------------------------*
						// GroundStrike?
						//----------------------------------------------------------------------------*

						if ((double) m_DataFiles.Preferences.BallisticsData.MuzzleHeight + dPath <= 0.0)
							{
							fReferenceGroundStrike = true;

							nReferenceGroundStrikeRange = nRange;

							double dDriftPath = 0.0 - m_DataFiles.Preferences.BallisticsData.WindDrift;
							double dDriftMOA = 0.0;

							if (nWindageTurretClicks != 0)
								{
								double dTurretClick = dRange > 0.0 ? ((dRange / 100.0) * 1.047) * m_BallisticsData.ScopeClick : 0.0;

								if (m_BallisticsData.TurretType == cFirearm.eTurretType.MilDot)
									dTurretClick *= 3.44;

								dDriftMOA = (double) ((double) nWindageTurretClicks * dTurretClick);

								if (!Double.IsInfinity(dDriftMOA))
									dDriftPath += (m_dPixelsPerYUnit * dDriftMOA);
								}

							nReferenceDriftGroundStrikeY = m_nDriftChartStartY - (int) (dDriftPath * m_dPixelsPerYUnit);
							}

						//----------------------------------------------------------------------------*
						// Draw the bullet path line
						//----------------------------------------------------------------------------*

						g.DrawLine(ReferencePen, LastReferencePoint, NextReferencePoint);

						LastReferencePoint = NextReferencePoint;
						}
					}

				//----------------------------------------------------------------------------*
				// Draw Current Data Trajectory
				//----------------------------------------------------------------------------*

				m_BallisticsData.Range = dRange;

				if (fShowCurrentData && nNextX <= BulletDropChart.Width - 50)
					{
					//----------------------------------------------------------------------------*
					// Adjust for Turret Clicks
					//----------------------------------------------------------------------------*

					double dPath = m_BallisticsData.BulletPath;

					if (nElevationTurretClicks != 0)
						{
						double dTurretClick = dRange > 0.0 ? ((dRange / 100.0) * 1.047) * m_BallisticsData.ScopeClick : 0.0;

						if (m_BallisticsData.TurretType == cFirearm.eTurretType.MilDot)
							dTurretClick *= 3.44;

						double dMOA = (double) ((double) nElevationTurretClicks * dTurretClick);

						if (!Double.IsInfinity(dMOA))
							dPath += dMOA;
						}

					//----------------------------------------------------------------------------*
					// Have we gone transonic?
					//----------------------------------------------------------------------------*

					if (nTransonicRange < 0 && m_BallisticsData.RemainingVelocity < dSpeedOfSound)
						{
						nTransonicRange = nRange;
						dTransonicPath = dPath;
						}

					//----------------------------------------------------------------------------*
					// Calculate the next points
					//----------------------------------------------------------------------------*

					if (dRange > 0.0 && !fGroundStrike)
						{
						nNextY = m_nChartStartY - (int) (dPath * m_dPixelsPerYUnit);

						NextDataPoint.X = nNextX;
						NextDataPoint.Y = nNextY;

						//----------------------------------------------------------------------------*
						// Check Apogee
						//----------------------------------------------------------------------------*

						if (dPath > dApex)
							{
							dApex = dPath;
							nApexRange = nRange;
							}

						//----------------------------------------------------------------------------*
						// Bullet at Target?
						//----------------------------------------------------------------------------*

						if (nRange == (int) cDataFiles.StandardToMetric(m_BallisticsData.TargetRange, cDataFiles.eDataType.Range))
							{
							double dTargetPath = cDataFiles.StandardToMetric(dPath, cDataFiles.eDataType.GroupSize);

							string strPath = (dTargetPath == 0.0) ? " - Bullseye!" : String.Format(strBullseyeFormat, Math.Abs(dTargetPath));

							if (dTargetPath != 0.0)
								strPath += (dPath < 0.0 ? " low" : " high");

							CurrentDataLegendLabel.Text += strPath;
							}

						//----------------------------------------------------------------------------*
						// GroundStrike?
						//----------------------------------------------------------------------------*

						if ((double) m_BallisticsData.MuzzleHeight + dPath <= 0.0)
							{
							fGroundStrike = true;

							nGroundStrikeRange = nRange;

							double dDriftPath = 0.0 - m_BallisticsData.WindDrift;
							double dDriftMOA = 0.0;

							if (nWindageTurretClicks != 0)
								{
								double dTurretClick = dRange > 0.0 ? ((dRange / 100.0) * 1.047) * m_BallisticsData.ScopeClick : 0.0;

								if (m_BallisticsData.TurretType == cFirearm.eTurretType.MilDot)
									dTurretClick *= 3.44;

								dDriftMOA = (double) ((double) nWindageTurretClicks * dTurretClick);

								if (!Double.IsInfinity(dDriftMOA))
									dDriftPath += (m_dPixelsPerYUnit * dDriftMOA);
								}

							nDriftGroundStrikeY = m_nDriftChartStartY - (int) (dDriftPath * m_dPixelsPerYUnit);
							}

						//----------------------------------------------------------------------------*
						// Draw the bullet path line
						//----------------------------------------------------------------------------*

						g.DrawLine(DataPen, LastDataPoint, NextDataPoint);

						LastDataPoint = NextDataPoint;
						}
					}

				//============================================================================*
				// Wind Drift Chart
				//============================================================================*

				//----------------------------------------------------------------------------*
				// Draw Reference Trajectory if needed
				//----------------------------------------------------------------------------*

				if (fShowReferenceData)
					{
					//----------------------------------------------------------------------------*
					// Calculate next point
					//----------------------------------------------------------------------------*

					//----------------------------------------------------------------------------*
					// Adjust for Turret Clicks
					//----------------------------------------------------------------------------*

					double dPath = 0.0 - m_DataFiles.Preferences.BallisticsData.WindDrift;
					double dMOA = 0.0;

					if (nWindageTurretClicks != 0)
						{
						double dTurretClick = dRange > 0.0 ? ((dRange / 100.0) * 1.047) * m_BallisticsData.ScopeClick : 0.0;

						if (m_BallisticsData.TurretType == cFirearm.eTurretType.MilDot)
							dTurretClick *= 3.44;

						dMOA = (double) ((double) nWindageTurretClicks * dTurretClick);

						if (!Double.IsInfinity(dMOA))
							dPath += dMOA;
						}

					//----------------------------------------------------------------------------*
					// Calculate the next points
					//----------------------------------------------------------------------------*

					if (nRange > 0 && !fReferenceGroundStrike)
						{
						nNextY = m_nDriftChartStartY - (int) ((dPath * m_dPixelsPerYUnit));

						NextWindageReferencePoint.X = nNextX;
						NextWindageReferencePoint.Y = nNextY;

						if (nNextX <= BulletDropChart.Width - 50)
							{
							//----------------------------------------------------------------------------*
							// Bullet at Target?
							//----------------------------------------------------------------------------*

							if (nRange == (int) cDataFiles.StandardToMetric(m_DataFiles.Preferences.BallisticsData.TargetRange, cDataFiles.eDataType.Range))
								{
								double dDriftPath = cDataFiles.StandardToMetric(dPath, cDataFiles.eDataType.GroupSize);

								string strPath = (dDriftPath == 0.0) ? " - Bullseye!" : String.Format(strBullseyeFormat, Math.Abs(dDriftPath));

								if (dDriftPath != 0.0)
									strPath += (dPath < 0.0 ? " right" : " left");

								ReferenceDataDriftLegendLabel.Text += strPath;
								}

							//----------------------------------------------------------------------------*
							// Draw the bullet path line
							//----------------------------------------------------------------------------*

							g1.DrawLine(ReferencePen, LastWindageReferencePoint, NextWindageReferencePoint);

							LastWindageReferencePoint = NextWindageReferencePoint;
							}
						}
					}

				//----------------------------------------------------------------------------*
				// Draw Current Data Trajectory
				//----------------------------------------------------------------------------*

				if (fShowCurrentData)
					{
					//----------------------------------------------------------------------------*
					// Adjust for Turret Clicks
					//----------------------------------------------------------------------------*

					double dPath = 0.0 - m_BallisticsData.WindDrift;

					if (nWindageTurretClicks != 0)
						{
						double dTurretClick = nRange > 0 ? ((dRange / 100.0) * 1.047) * m_BallisticsData.ScopeClick : 0.0;

						if (m_BallisticsData.TurretType == cFirearm.eTurretType.MilDot)
							dTurretClick *= 3.44;

						double dMOA = (double) ((double) nWindageTurretClicks * dTurretClick);

						if (!Double.IsInfinity(dMOA))
							dPath += (m_dPixelsPerYUnit * dMOA);
						}

					//----------------------------------------------------------------------------*
					// Calculate the next points
					//----------------------------------------------------------------------------*

					if (nRange > 0 && !fGroundStrike)
						{
						nNextY = (int) ((double) m_nDriftChartStartY - (dPath * m_dPixelsPerYUnit));

						NextWindageDataPoint.X = nNextX;
						NextWindageDataPoint.Y = nNextY;

						if (nNextX <= BulletDropChart.Width - 50)
							{
							//----------------------------------------------------------------------------*
							// Bullet at Target?
							//----------------------------------------------------------------------------*

							if (nRange == (int) cDataFiles.StandardToMetric(m_BallisticsData.TargetRange, cDataFiles.eDataType.Range))
								{
								double dTargetPath = cDataFiles.StandardToMetric(dPath, cDataFiles.eDataType.GroupSize);

								string strPath = (dTargetPath == 0.0) ? " - Bullseye!" : String.Format(strBullseyeFormat, Math.Abs(dTargetPath));

								if (dTargetPath != 0.0)
									strPath += (dPath < 0.0 ? " right" : " left");

								CurrentDataDriftLegendLabel.Text += strPath;
								}

							//----------------------------------------------------------------------------*
							// Draw the bullet path line
							//----------------------------------------------------------------------------*

							g1.DrawLine(DataPen, LastWindageDataPoint, NextWindageDataPoint);

							LastWindageDataPoint = NextWindageDataPoint;
							}
						}
					}

				//----------------------------------------------------------------------------*
				// Draw Range Markers if needed
				//----------------------------------------------------------------------------*

				if (nRange == nNextRange)
					{
					nNextX = m_nChartStartX + (int) (m_dPixelsPerXUnit * cDataFiles.MetricToStandard(nRange, cDataFiles.eDataType.Range));

					//----------------------------------------------------------------------------*
					// Draw Bullet Drop Range Marker if needed
					//----------------------------------------------------------------------------*

					if (ShowDropChartRangeMarkersCheckBox.Checked)
						{
						string strRange = String.Format("{0:G0}", nRange);

						SizeF TextSize = g.MeasureString(strRange, RangeFont);

						g.DrawString(strRange, RangeFont, Brushes.Black, nNextX - (int) (TextSize.Width / 2.0), m_nDropChartHeight - 5 - (int) TextSize.Height);

						g.DrawLine(RangePen, new Point(nNextX, m_nDropChartHeight - 10 - (int) TextSize.Height), new Point(nNextX, 0));
						}

					//----------------------------------------------------------------------------*
					// Draw Wind Drift Range Marker if needed
					//----------------------------------------------------------------------------*

					if (ShowWindDriftRangeMarkersCheckBox.Checked)
						{
						string strRange = String.Format("{0:G0}", nRange);

						SizeF TextSize = g.MeasureString(strRange, RangeFont);

						g1.DrawString(strRange, RangeFont, Brushes.Black, nNextX - (int) (TextSize.Width / 2.0), m_nDropChartHeight - 5 - (int) TextSize.Height);

						g1.DrawLine(RangePen, new Point(nNextX, m_nDropChartHeight - 10 - (int) TextSize.Height), new Point(nNextX, 0));
						}
					}

				//----------------------------------------------------------------------------*
				// Add table item if needed
				//----------------------------------------------------------------------------*

				if (nRange == (int) nNextRange)
					{
					if (fCalculateTable)
						{
						ListViewItem Item = new ListViewItem(String.Format("{0:N0}", nRange));

						string strGroupFormat = "{0:F";
						strGroupFormat += String.Format("{0:G0}", m_DataFiles.Preferences.GroupDecimals);
						strGroupFormat += "}";

						Item.SubItems.Add(String.Format(strGroupFormat, cDataFiles.StandardToMetric(m_BallisticsData.BulletPath, cDataFiles.eDataType.GroupSize)));
						Item.SubItems.Add(nRange > 0 && !Double.IsInfinity(m_BallisticsData.BulletPathMOA) ? String.Format(strGroupFormat, m_BallisticsData.BulletPathMOA) : "---");
						Item.SubItems.Add(String.Format(strGroupFormat, cDataFiles.StandardToMetric(m_BallisticsData.WindDrift, cDataFiles.eDataType.GroupSize)));
						Item.SubItems.Add(nRange > 0 && !Double.IsInfinity(m_BallisticsData.WindDriftMOA) ? String.Format(strGroupFormat, m_BallisticsData.WindDriftMOA) : "---");
						Item.SubItems.Add(String.Format("{0:F1}", cDataFiles.StandardToMetric(m_BallisticsData.RemainingVelocity, cDataFiles.eDataType.Velocity)));
						Item.SubItems.Add(String.Format("{0:F1}", m_BallisticsData.Energy));
						Item.SubItems.Add(String.Format("{0:F3}", m_BallisticsData.TimeOfFlight));
						Item.SubItems.Add(m_BallisticsData.ScopeClicks);

						if (BallisticsUseSFCheckBox.Checked)
							{
							cBallistics Ballistics = new cBallistics(m_BallisticsData);

							Ballistics.MuzzleVelocity = (int) m_BallisticsData.RemainingVelocity;

							Item.SubItems.Add(String.Format("{0:F2}", Ballistics.StabilityFactor));
							Item.SubItems.Add(String.Format("{0:F3}", Ballistics.AdjustedBC));
							}
						else
							{
							Item.SubItems.Add("-");
							Item.SubItems.Add("-");
							}

						BallisticsListView.Items.Add(Item);
						}

					nNextRange += (int) cDataFiles.StandardToMetric(m_BallisticsData.Increment, cDataFiles.eDataType.Range);
					}
				}

			//----------------------------------------------------------------------------*
			// Draw GroundStrike Markers if Needed
			//----------------------------------------------------------------------------*

			//----------------------------------------------------------------------------*
			// Reference Data
			//----------------------------------------------------------------------------*

			if (fReferenceGroundStrike)
				{
				int nGroundStrikeX = m_nChartStartX + (int) (cDataFiles.MetricToStandard(nReferenceGroundStrikeRange, cDataFiles.eDataType.Range) * m_dPixelsPerXUnit);

				Brush SkyBrush = new SolidBrush(Color.FromArgb(127, 255, 254));

				g.DrawImage(m_GroundStrike, new Point(nGroundStrikeX - (m_GroundStrike.Width / 2), m_nGroundY - (m_GroundStrike.Height)));

				g1.DrawImage(m_GroundStrike, new Point(nGroundStrikeX - (m_GroundStrike.Width / 2), nReferenceDriftGroundStrikeY - (m_GroundStrike.Height / 2)));

				if (nReferenceGroundStrikeRange < cDataFiles.StandardToMetric(m_BallisticsData.TargetRange, cDataFiles.eDataType.Range))
					ReferenceDataLegendLabel.Text += String.Format(" - {0:G0} {1} short!", cDataFiles.StandardToMetric(m_BallisticsData.TargetRange, cDataFiles.eDataType.Range) - nReferenceGroundStrikeRange, cDataFiles.MetricString(cDataFiles.eDataType.Range));

				if (fShowGroundStrikeMarker)
					{
					string strGroundStrike = "Ground Strike";

					SizeF TextSize1 = g.MeasureString(strGroundStrike, RangeFont);

					g.DrawLine(ReferenceMarkerPen, nGroundStrikeX, m_nGroundY, nGroundStrikeX, 10 + (TextSize1.Height / 2));

					int nX = (nGroundStrikeRange > nReferenceGroundStrikeRange) ? nGroundStrikeX - 5 - (int) TextSize1.Width : nGroundStrikeX + 5;

					g.FillRectangle(SkyBrush, nX, 10, TextSize1.Width, TextSize1.Height);
					g.DrawString(strGroundStrike, RangeFont, ReferenceBrush, nX, 10);

					strGroundStrike = String.Format("{0:G0} {1}", nReferenceGroundStrikeRange, cDataFiles.MetricString(cDataFiles.eDataType.Range));

					SizeF TextSize2 = g.MeasureString(strGroundStrike, RangeFont);

					nX = (nGroundStrikeRange > nReferenceGroundStrikeRange) ? nGroundStrikeX - 5 - (int) (TextSize1.Width / 2.0) - (int) (TextSize2.Width / 2.0) : nGroundStrikeX + 5 + (int) (TextSize1.Width / 2.0) - (int) (TextSize2.Width / 2.0);

					g.FillRectangle(SkyBrush, nX, 10 + TextSize2.Height, TextSize2.Width, TextSize2.Height);
					g.DrawString(strGroundStrike, RangeFont, ReferenceBrush, nX, 10 + TextSize2.Height);
					}

				SkyBrush.Dispose();
				}

			//----------------------------------------------------------------------------*
			// Current Data
			//----------------------------------------------------------------------------*

			if (fGroundStrike)
				{
				int nGroundStrikeX = m_nChartStartX + (int) (cDataFiles.MetricToStandard(nGroundStrikeRange, cDataFiles.eDataType.Range) * m_dPixelsPerXUnit);

				Brush SkyBrush = new SolidBrush(Color.FromArgb(127, 255, 254));

				g.DrawImage(m_GroundStrike, new Point(nGroundStrikeX - (m_GroundStrike.Width / 2), m_nGroundY - (m_GroundStrike.Height)));

				g1.DrawImage(m_GroundStrike, new Point(nGroundStrikeX - (m_GroundStrike.Width / 2), nDriftGroundStrikeY - (m_GroundStrike.Height / 2)));

				if (nGroundStrikeRange < cDataFiles.StandardToMetric(m_BallisticsData.TargetRange, cDataFiles.eDataType.Range))
					CurrentDataLegendLabel.Text += String.Format(" - {0:G0} {1} short!", cDataFiles.StandardToMetric(m_BallisticsData.TargetRange, cDataFiles.eDataType.Range) - nGroundStrikeRange, cDataFiles.MetricString(cDataFiles.eDataType.Range));

				if (fShowGroundStrikeMarker)
					{
					string strGroundStrike = "Ground Strike";

					SizeF TextSize1 = g.MeasureString(strGroundStrike, RangeFont);

					g.DrawLine(DataMarkerPen, nGroundStrikeX, m_nGroundY, nGroundStrikeX, 10 + (TextSize1.Height / 2));

					int nX = (nGroundStrikeRange < nReferenceGroundStrikeRange) ? nGroundStrikeX - 5 - (int) TextSize1.Width : nGroundStrikeX + 5;

					g.FillRectangle(SkyBrush, nX, 10, TextSize1.Width, TextSize1.Height);
					g.DrawString(strGroundStrike, RangeFont, DataBrush, nX, 10);

					strGroundStrike = String.Format("{0:G0} {1}", nGroundStrikeRange, cDataFiles.MetricString(cDataFiles.eDataType.Range));

					SizeF TextSize2 = g.MeasureString(strGroundStrike, RangeFont);

					nX = (nGroundStrikeRange < nReferenceGroundStrikeRange) ? nGroundStrikeX - 5 - (int) (TextSize1.Width / 2.0) - (int) (TextSize2.Width / 2.0) : nGroundStrikeX + 5 + (int) (TextSize1.Width / 2.0) - (int) (TextSize2.Width / 2.0);

					g.FillRectangle(SkyBrush, nX, 10 + TextSize2.Height, TextSize2.Width, TextSize2.Height);
					g.DrawString(strGroundStrike, RangeFont, DataBrush, nX, 10 + TextSize2.Height);
					}

				SkyBrush.Dispose();
				}

			//----------------------------------------------------------------------------*
			// Draw Apogee Markers if needed
			//----------------------------------------------------------------------------*

			if (ShowApexMarkerCheckBox.Checked)
				{
				Brush GroundBrush = new SolidBrush(Color.FromArgb(85, 254, 1));

				//----------------------------------------------------------------------------*
				// Reference Data
				//----------------------------------------------------------------------------*

				if (fShowReferenceData)
					{
					int nX = m_nChartStartX + (int) (cDataFiles.MetricToStandard(nReferenceApexRange, cDataFiles.eDataType.Range) * m_dPixelsPerXUnit);

					string strApogee1 = "Apogee";

					string strApogee2 = String.Format("{0:F2} {1} ({2:G0} {3})", cDataFiles.StandardToMetric(dReferenceApex, cDataFiles.eDataType.GroupSize), cDataFiles.MetricString(cDataFiles.eDataType.GroupSize), nReferenceApexRange, cDataFiles.MetricString(cDataFiles.eDataType.Range));

					SizeF TextSize1 = g.MeasureString(strApogee1, RangeFont);
					SizeF TextSize2 = g.MeasureString(strApogee2, RangeFont);

					int nApexX = nX + 3;
					int nY = 130 + (int) (TextSize1.Height / 2.0);

					g.DrawLine(ReferenceMarkerPen, nX, nY, nX, m_nChartStartY - (int) dReferenceApex);

					if (nReferenceApexRange <= nApexRange)
						nApexX = nX - 3 - (int) TextSize1.Width;

					nY = 130;

					g.FillRectangle(GroundBrush, nApexX, nY, TextSize1.Width, TextSize1.Height);
					g.DrawString(strApogee1, RangeFont, ReferenceBrush, nApexX, nY);

					nApexX = nX + 3;
					nY += (int) TextSize2.Height;

					if (nReferenceApexRange <= nApexRange)
						nApexX = nX - 3 - (int) TextSize2.Width;

					g.FillRectangle(GroundBrush, nApexX, nY, TextSize2.Width, TextSize2.Height);
					g.DrawString(strApogee2, RangeFont, ReferenceBrush, nApexX, nY);
					}

				//----------------------------------------------------------------------------*
				// Current Data
				//----------------------------------------------------------------------------*

				if (fShowCurrentData)
					{
					int nX = m_nChartStartX + (int) (cDataFiles.MetricToStandard(nApexRange, cDataFiles.eDataType.Range) * m_dPixelsPerXUnit);

					string strApogee1 = "Apogee";

					string strApogee2 = String.Format("{0:F2} {1} ({2:G0} {3})", dApex, cDataFiles.MetricString(cDataFiles.eDataType.GroupSize), nApexRange, cDataFiles.MetricString(cDataFiles.eDataType.Range));

					SizeF TextSize1 = g.MeasureString(strApogee1, RangeFont);
					SizeF TextSize2 = g.MeasureString(strApogee2, RangeFont);

					int nApexX = nX + 3;
					int nY = 130 + (int) (TextSize1.Height / 2.0);

					g.DrawLine(DataMarkerPen, nX, nY, nX, m_nChartStartY - (int) dApex);

					if (nApexRange < nReferenceApexRange)
						nApexX = nX - 3 - (int) TextSize1.Width;

					nY = 130;

					g.FillRectangle(GroundBrush, nApexX, nY, TextSize1.Width, TextSize1.Height);
					g.DrawString(strApogee1, RangeFont, DataBrush, nApexX, nY);

					nApexX = nX + 3;
					nY += (int) TextSize2.Height;

					if (nApexRange < nReferenceApexRange)
						nApexX = nX - 3 - (int) TextSize2.Width;

					g.FillRectangle(GroundBrush, nApexX, nY, TextSize2.Width, TextSize2.Height);
					g.DrawString(strApogee2, RangeFont, DataBrush, nApexX, nY);
					}

				GroundBrush.Dispose();
				}

			//----------------------------------------------------------------------------*
			// Draw Transonic Markers if Needed
			//----------------------------------------------------------------------------*

			//----------------------------------------------------------------------------*
			// Reference Data
			//----------------------------------------------------------------------------*

			if (fShowTransonicMarker && fShowReferenceData && nReferenceTransonicRange >= 0 && nReferenceTransonicRange < nReferenceGroundStrikeRange)
				{
				int nTransonicX = m_nChartStartX + (int) (cDataFiles.MetricToStandard(nReferenceTransonicRange, cDataFiles.eDataType.Range) * m_dPixelsPerXUnit);
				int nTransonicY = m_nChartStartY - (int) (dReferenceTransonicPath * m_dPixelsPerYUnit);

				Brush SkyBrush = new SolidBrush(Color.FromArgb(127, 255, 254));

				string strTransonic = (nReferenceTransonicRange == 0 ? "SubSonic" : "Transonic");

				SizeF TextSize1 = g.MeasureString(strTransonic, RangeFont);

				int nX = (nReferenceTransonicRange <= nTransonicRange) ? nTransonicX - 5 - (int) TextSize1.Width : nTransonicX + 5;

				g.FillRectangle(SkyBrush, nX, 10 + (TextSize1.Height * 2), TextSize1.Width, TextSize1.Height);
				g.DrawString(strTransonic, RangeFont, ReferenceBrush, nX, 10 + (TextSize1.Height * 2));

				if (nReferenceTransonicRange > 0)
					{
					strTransonic = String.Format("{0:G0} {1}", nReferenceTransonicRange, cDataFiles.MetricString(cDataFiles.eDataType.Range));

					SizeF TextSize2 = g.MeasureString(strTransonic, RangeFont);

					nX = (nReferenceTransonicRange <= nTransonicRange) ? nTransonicX - 5 - (int) (TextSize1.Width / 2.0) - (int) (TextSize2.Width / 2.0) : nTransonicX + 5 + (int) (TextSize1.Width / 2.0) - (int) (TextSize2.Width / 2.0);

					g.FillRectangle(SkyBrush, nX, 10 + (TextSize1.Height * 3), TextSize2.Width, TextSize2.Height);
					g.DrawString(strTransonic, RangeFont, ReferenceBrush, nX, 10 + (TextSize1.Height * 3));

					g.DrawLine(ReferenceMarkerPen, nTransonicX, nTransonicY, nTransonicX, 10 + (TextSize1.Height * 2) + (TextSize1.Height / 2));
					}

				SkyBrush.Dispose();
				}

			//----------------------------------------------------------------------------*
			// Current Data
			//----------------------------------------------------------------------------*

			if (fShowTransonicMarker && fShowCurrentData && nTransonicRange >= 0 && nTransonicRange < nGroundStrikeRange)
				{
				int nTransonicX = m_nChartStartX + (int) (cDataFiles.MetricToStandard(nTransonicRange, cDataFiles.eDataType.Range) * m_dPixelsPerXUnit);
				int nTransonicY = m_nChartStartY - (int) (dTransonicPath * m_dPixelsPerYUnit);

				Brush SkyBrush = new SolidBrush(Color.FromArgb(127, 255, 254));

				string strTransonic = nTransonicRange == 0 ? "SubSonic" : "Transonic";

				SizeF TextSize1 = g.MeasureString(strTransonic, RangeFont);

				int nX = (nTransonicRange < nReferenceTransonicRange) ? nTransonicX - 5 - (int) TextSize1.Width : nTransonicX + 5;

				g.FillRectangle(SkyBrush, nX, 10 + (TextSize1.Height * 2), TextSize1.Width, TextSize1.Height);
				g.DrawString(strTransonic, RangeFont, DataBrush, nX, 10 + (TextSize1.Height * 2));

				if (nTransonicRange > 0)
					{
					strTransonic = String.Format("{0:G0} {1}", nTransonicRange, cDataFiles.MetricString(cDataFiles.eDataType.Range));

					SizeF TextSize2 = g.MeasureString(strTransonic, RangeFont);

					nX = (nTransonicRange < nReferenceTransonicRange) ? nTransonicX - 5 - (int) (TextSize1.Width / 2.0) - (int) (TextSize2.Width / 2.0) : nTransonicX + 5 + (int) (TextSize1.Width / 2.0) - (int) (TextSize2.Width / 2.0);

					g.FillRectangle(SkyBrush, nX, 10 + (TextSize1.Height * 3), TextSize2.Width, TextSize2.Height);
					g.DrawString(strTransonic, RangeFont, DataBrush, nX, 10 + (TextSize1.Height * 3));

					g.DrawLine(DataMarkerPen, nTransonicX, nTransonicY, nTransonicX, 10 + (TextSize1.Height * 2) + (TextSize1.Height / 2));
					}

				SkyBrush.Dispose();
				}

			string strText = String.Format("Apogee: {0:F2} {1} at {2:G0} {3}", dReferenceApex, cDataFiles.MetricString(cDataFiles.eDataType.GroupSize), nReferenceApexRange, cDataFiles.MetricString(cDataFiles.eDataType.Range));

			ReferenceDataLegendLabel.Text += " - " + strText;

			strText = String.Format("Apogee: {0:F2} {1} at {2:G0} {3}", dApex, cDataFiles.MetricString(cDataFiles.eDataType.GroupSize), nApexRange, cDataFiles.MetricString(cDataFiles.eDataType.Range));

			CurrentDataLegendLabel.Text += " - " + strText;

			m_BallisticsData.Active = false;

			m_DataFiles.Preferences.BallisticsData.Active = false;

			BulletDropChart.Image = DropChartImage;

			UpdateBallisticsTabButtons();
			}

		//============================================================================*
		// PopulateBallisticsFirearmCombo()
		//============================================================================*

		private void PopulateBallisticsFirearmCombo()
			{
			m_fPopulating = true;

			BallisticsFirearmCombo.Items.Clear();

			cFirearm.eFireArmType eFirearmType = (cFirearm.eFireArmType) BallisticsFirearmTypeCombo.SelectedIndex;

			BallisticsFirearmCombo.Items.Add("Any Firearm");

			cFirearm SelectFirearm = null;

			foreach (cFirearm CheckFirearm in m_DataFiles.FirearmList)
				{
				if (CheckFirearm.FirearmType == eFirearmType)
					{
					BallisticsFirearmCombo.Items.Add(CheckFirearm);

					if (CheckFirearm.CompareTo(m_DataFiles.Preferences.BallisticsFirearm) == 0)
						SelectFirearm = CheckFirearm;
					}
				}

			//----------------------------------------------------------------------------*
			// Select a firearm so the combo isn't blank
			//----------------------------------------------------------------------------*

			if (SelectFirearm != null)
				BallisticsFirearmCombo.SelectedItem = SelectFirearm;
			else
				{
				if (BallisticsFirearmCombo.Items.Count > 0)
					BallisticsFirearmCombo.SelectedIndex = 0;
				}

			m_fPopulating = false;

			PopulateBallisticsBatchCombo();
			}

		//============================================================================*
		// PopulateBallisticsInputData()
		//============================================================================*

		private void PopulateBallisticsInputData()
			{
			m_fPopulating = true;

			cBallistics BallisticsData = (ShowReferenceDataCheckBox.Checked ? m_DataFiles.Preferences.BallisticsData : m_BallisticsData);

			//------------------------------------------------------------------------*
			// Bullet Data
			//------------------------------------------------------------------------*

			BallisticsBCTextBox.Value = BallisticsData.BallisticCoefficient;
			BallisticsBulletDiameterTextBox.Value = cDataFiles.StandardToMetric(BallisticsData.BulletDiameter, cDataFiles.eDataType.Dimension);
			BallisticsBulletWeightTextBox.Value = cDataFiles.StandardToMetric(BallisticsData.BulletWeight, cDataFiles.eDataType.BulletWeight);
			BallisticsBulletLengthTextBox.Value = cDataFiles.StandardToMetric(BallisticsData.BulletLength, cDataFiles.eDataType.Dimension);

			//------------------------------------------------------------------------*
			// Muzzle Data
			//------------------------------------------------------------------------*

			BallisticsMuzzleVelocityTextBox.Value = (int) cDataFiles.StandardToMetric(BallisticsData.MuzzleVelocity, cDataFiles.eDataType.Velocity);
			BallisticsMuzzleHeightLabel.Text = String.Format("{0:G0} {1}", cDataFiles.StandardToMetric(BallisticsData.MuzzleHeight, cDataFiles.eDataType.GroupSize), cDataFiles.MetricString(cDataFiles.eDataType.GroupSize));

			//------------------------------------------------------------------------*
			// Firearm Data
			//------------------------------------------------------------------------*

			BallisticsZeroRangeTextBox.Value = (int) cDataFiles.StandardToMetric(BallisticsData.ZeroRange, cDataFiles.eDataType.Range);
			BallisticsSightHeightTextBox.Value = cDataFiles.StandardToMetric(BallisticsData.SightHeight, cDataFiles.eDataType.Firearm);
			BallisticsScopeClickTextBox.Value = BallisticsData.ScopeClick;
			BallisticsTurretTypeComboBox.SelectedIndex = (int) BallisticsData.TurretType;
			BallisticsTwistTextBox.Value = cDataFiles.StandardToMetric(BallisticsData.Twist, cDataFiles.eDataType.Firearm);

			//------------------------------------------------------------------------*
			// Range Data
			//------------------------------------------------------------------------*

			BallisticsMaxRangeTextBox.Value = (int) cDataFiles.StandardToMetric(BallisticsData.MaxRange, cDataFiles.eDataType.Range);
			BallisticsMinRangeTextBox.Value = (int) cDataFiles.StandardToMetric(BallisticsData.MinRange, cDataFiles.eDataType.Range);
			BallisticsIncrementTextBox.Value = (int) cDataFiles.StandardToMetric(BallisticsData.Increment, cDataFiles.eDataType.Range);
			BallisticsTargetRangeTextBox.Value = (int) cDataFiles.StandardToMetric(BallisticsData.TargetRange, cDataFiles.eDataType.Range);

			//------------------------------------------------------------------------*
			// Environmental Data
			//------------------------------------------------------------------------*

			PopulateBallisticsAtmosphericData();

			BallisticsUseDensityAltitudeCheckBox.Checked = BallisticsData.UseDensityAltitude;
			BallisticsUseStationPressureCheckBox.Checked = m_DataFiles.Preferences.BallisticsData.UseStationPressure;
			BallisticsUseSFCheckBox.Checked = m_DataFiles.Preferences.BallisticsUseSF;

			//------------------------------------------------------------------------*
			// Update buttons and exit
			//------------------------------------------------------------------------*

			m_fPopulating = false;

			UpdateBallisticsTabButtons();

			if (m_fCalculateOK)
				PopulateBallisticsData();
			}

		//============================================================================*
		// PopulateBallisticsLoadCombo()
		//============================================================================*

		private void PopulateBallisticsLoadCombo()
			{
			m_fPopulating = true;

			//----------------------------------------------------------------------------*
			// Get Filter Data
			//----------------------------------------------------------------------------*

			cFirearm.eFireArmType efirearmType = BallisticsFirearmTypeCombo.Value;

			cFirearm Firearm = null;

			if (BallisticsFirearmCombo.SelectedIndex > 0)
				Firearm = (cFirearm) BallisticsFirearmCombo.SelectedItem;

			cBatch Batch = null;

			if (BallisticsBatchCombo.SelectedIndex > 0)
				Batch = (cBatch) BallisticsBatchCombo.SelectedItem;

			//----------------------------------------------------------------------------*
			// Populate Load Combo
			//----------------------------------------------------------------------------*

			BallisticsLoadCombo.Items.Clear();

			cLoad SelectLoad = null;

			if (Batch != null && Batch.Load != null)
				{
				BallisticsLoadCombo.Items.Add(Batch.Load);
				}
			else
				{
				BallisticsLoadCombo.Items.Add("No Specific Load");

				foreach (cLoad CheckLoad in m_DataFiles.LoadList)
					{
					if (CheckLoad.FirearmType == efirearmType &&
						(Firearm == null || Firearm.HasCaliber(CheckLoad.Caliber)))
						{
						BallisticsLoadCombo.Items.Add(CheckLoad);

						if (CheckLoad.CompareTo(m_DataFiles.Preferences.BallisticsLoad) == 0)
							SelectLoad = CheckLoad;
						}
					}
				}

			if (SelectLoad != null)
				BallisticsLoadCombo.SelectedItem = SelectLoad;
			else
				{
				if (BallisticsLoadCombo.Items.Count > 0)
					BallisticsLoadCombo.SelectedIndex = 0;
				}

			m_fPopulating = false;

			PopulateBallisticsChargeCombo();
			}

		//============================================================================*
		// PopulateBallisticsTab()
		//============================================================================*

		private void PopulateBallisticsTab()
			{
			m_fPopulating = true;

			SetInputParameters();

			//----------------------------------------------------------------------------*
			// BallisticsFirearmTypeCombo
			//----------------------------------------------------------------------------*

			BallisticsFirearmTypeCombo.Value = m_DataFiles.Preferences.BallisticsFirearmType;

			//----------------------------------------------------------------------------*
			// BallisticsFirearmCombo
			//----------------------------------------------------------------------------*

			m_fPopulating = false;

			PopulateBallisticsFirearmCombo();
			}

		//============================================================================*
		// PopulateBallisticsTurretTypeCombo()
		//============================================================================*

		private void PopulateBallisticsTurretTypeCombo()
			{
			BallisticsTurretTypeComboBox.Items.Clear();

			BallisticsTurretTypeComboBox.Items.Add("MOA");
			BallisticsTurretTypeComboBox.Items.Add("Mils");
			}

		//============================================================================*
		// SetBallisticsAltitude()
		//============================================================================*

		private void SetBallisticsAltitude()
			{
			m_BallisticsData.Altitude = (int) cDataFiles.MetricToStandard(BallisticsAltitudeTextBox.Value, cDataFiles.eDataType.Altitude);
			m_DataFiles.Preferences.BallisticsData.Altitude = (int) cDataFiles.MetricToStandard(BallisticsAltitudeTextBox.Value, cDataFiles.eDataType.Altitude);
			}

		//============================================================================*
		// SetBallisticsData()
		//============================================================================*

		private void SetBallisticsData()
			{
			m_fPopulating = true;

			//----------------------------------------------------------------------------*
			// Get Database Selections
			//----------------------------------------------------------------------------*

			cFirearm Firearm = null;

			if (BallisticsFirearmCombo.SelectedIndex > 0)
				Firearm = (cFirearm) BallisticsFirearmCombo.SelectedItem;

			cBatch Batch = null;

			if (BallisticsBatchCombo.SelectedIndex > 0)
				Batch = (cBatch) BallisticsBatchCombo.SelectedItem;

			cLoad Load = null;

			if (Batch != null)
				{
				Load = Batch.Load;

				if (Batch.BatchTest != null && Batch.BatchTest.MuzzleVelocity > 0)
					BallisticsBatchTestVelocityRadioButton.Enabled = true;
				else
					BallisticsBatchTestVelocityRadioButton.Enabled = false;
				}
			else
				{
				if (BallisticsLoadCombo.SelectedIndex > 0)
					Load = (cLoad) BallisticsLoadCombo.SelectedItem;
				}

			double dCharge = 0.0;

			if (Load != null)
				Double.TryParse(BallisticsChargeCombo.Text, out dCharge);
			else
				{
				BallisticsBatchTestVelocityRadioButton.Enabled = false;
				BallisticsBatchTestVelocityRadioButton.Checked = false;
				BallisticsLoadDataVelocityRadioButton.Enabled = false;
				BallisticsLoadDataVelocityRadioButton.Checked = false;
				}

			cCaliber Caliber = null;
			cBullet Bullet = null;

			if (Load != null)
				{
				Caliber = Load.Caliber;
				Bullet = Load.Bullet;
				}
			else
				{
				if (Firearm != null || BallisticsCaliberCombo.SelectedIndex > 0)
					Caliber = (cCaliber) BallisticsCaliberCombo.SelectedItem;
				}

			if (Bullet == null && BallisticsBulletCombo.SelectedIndex > 0)
				Bullet = (cBullet) BallisticsBulletCombo.SelectedItem;

			//----------------------------------------------------------------------------*
			// Set Preferences
			//----------------------------------------------------------------------------*

			m_DataFiles.Preferences.BallisticsFirearmType = BallisticsFirearmTypeCombo.Value;
			m_DataFiles.Preferences.BallisticsFirearm = Firearm;
			m_DataFiles.Preferences.BallisticsBatch = Batch;
			m_DataFiles.Preferences.BallisticsLoad = Load;
			m_DataFiles.Preferences.BallisticsCharge = dCharge;
			m_DataFiles.Preferences.BallisticsCaliber = Caliber;
			m_DataFiles.Preferences.BallisticsBullet = Bullet;

			//----------------------------------------------------------------------------*
			// Set Bullet Data
			//----------------------------------------------------------------------------*

			if (Bullet != null)
				{
				m_BallisticsData.BallisticCoefficient = Bullet.BallisticCoefficient;
				m_BallisticsData.BulletDiameter = Bullet.Diameter;
				m_BallisticsData.BulletWeight = Bullet.Weight;
				m_BallisticsData.BulletLength = Bullet.Length;
				}

			if (Caliber != null)
				{
				if (m_BallisticsData.BulletDiameter < Caliber.MinBulletDiameter)
					m_BallisticsData.BulletDiameter = Caliber.MinBulletDiameter;

				if (m_BallisticsData.BulletDiameter > Caliber.MaxBulletDiameter)
					m_BallisticsData.BulletDiameter = Caliber.MaxBulletDiameter;

				if (m_BallisticsData.BulletWeight < Caliber.MinBulletWeight)
					m_BallisticsData.BulletWeight = Caliber.MinBulletWeight;

				if (m_BallisticsData.BulletWeight > Caliber.MaxBulletWeight)
					m_BallisticsData.BulletWeight = Caliber.MaxBulletWeight;
				}

			//----------------------------------------------------------------------------*
			// Set Muzzle Velocity
			//----------------------------------------------------------------------------*

			int nMin = 10000;
			int nMax = 0;

			bool fLoadTest = false;
			bool fBatchTest = false;

			if (Load != null && dCharge != 0.0)
				{
				foreach (cCharge Charge in Load.ChargeList)
					{
					if (dCharge == Charge.PowderWeight)
						{
						foreach (cChargeTest ChargeTest in Charge.TestList)
							{
							if (ChargeTest.MuzzleVelocity != 0)
								{
								if (ChargeTest.BatchID == 0)
									fLoadTest = true;
								else
									fBatchTest = true;

								if ((!BallisticsBatchTestVelocityRadioButton.Checked && !BallisticsLoadDataVelocityRadioButton.Checked) ||
									(BallisticsBatchTestVelocityRadioButton.Checked && ChargeTest.BatchID != 0) ||
									(BallisticsLoadDataVelocityRadioButton.Checked && ChargeTest.BatchID == 0))
									{
									if (ChargeTest.MuzzleVelocity < nMin)
										nMin = ChargeTest.MuzzleVelocity;

									if (ChargeTest.MuzzleVelocity > nMax)
										nMax = ChargeTest.MuzzleVelocity;
									}
								}
							}
						}
					}

				if (m_BallisticsData.MuzzleVelocity < nMin)
					m_BallisticsData.MuzzleVelocity = nMin;

				if (m_BallisticsData.MuzzleVelocity > nMax)
					m_BallisticsData.MuzzleVelocity = nMax;

				BallisticsBatchTestVelocityRadioButton.Enabled = fBatchTest;

				if (!fBatchTest)
					BallisticsBatchTestVelocityRadioButton.Checked = false;

				BallisticsLoadDataVelocityRadioButton.Enabled = fLoadTest;

				if (!fLoadTest)
					BallisticsLoadDataVelocityRadioButton.Checked = false;
				}

			//----------------------------------------------------------------------------*
			// Set Firearm Data
			//----------------------------------------------------------------------------*

			if (Firearm != null)
				{
				m_BallisticsData.ZeroRange = Firearm.ZeroRange;
				m_BallisticsData.SightHeight = Firearm.SightHeight;
				m_BallisticsData.TurretType = Firearm.TurretType;
				m_BallisticsData.ScopeClick = Firearm.ScopeClick;
				m_BallisticsData.Twist = Firearm.Twist;

				m_DataFiles.Preferences.BallisticsData.ZeroRange = Firearm.ZeroRange;
				m_DataFiles.Preferences.BallisticsData.SightHeight = Firearm.SightHeight;
				m_DataFiles.Preferences.BallisticsData.TurretType = Firearm.TurretType;
				m_DataFiles.Preferences.BallisticsData.ScopeClick = Firearm.ScopeClick;
				m_DataFiles.Preferences.BallisticsData.Twist = Firearm.Twist;
				}

			//----------------------------------------------------------------------------*
			// Set Chart Data
			//----------------------------------------------------------------------------*

			ReferenceDataLegendLabel.Visible = CompareToReferenceBulletCheckBox.Checked;
			ReferenceDataDriftLegendLabel.Visible = CompareToReferenceBulletCheckBox.Checked;

			ShowApexMarkerCheckBox.Checked = m_DataFiles.Preferences.ShowApexMarker;
			ShowDropChartRangeMarkersCheckBox.Checked = m_DataFiles.Preferences.ShowDropChartRangeMarkers;
			ShowGroundStrikeMarkerCheckBox.Checked = m_DataFiles.Preferences.ShowGroundStrikeMarkers;
			ShowWindDriftRangeMarkersCheckBox.Checked = m_DataFiles.Preferences.ShowWindDriftRangeMarkers;

			TurretTypeLabel.Text = m_BallisticsData.TurretTypeString;
			DriftTurretTypeLabel.Text = m_BallisticsData.TurretTypeString;

			m_fPopulating = false;

			SetBallisticsMinMax();

			PopulateBallisticsInputData();
			}

		//============================================================================*
		// SetBallisticsHumidity()
		//============================================================================*

		private void SetBallisticsHumidity()
			{
			m_BallisticsData.Humidity = (double) BallisticsHumidityTextBox.Value / 100.0;
			m_DataFiles.Preferences.BallisticsData.Humidity = (double) BallisticsHumidityTextBox.Value / 100.0;
			}

		//============================================================================*
		// SetBallisticsMinMax()
		//============================================================================*

		private void SetBallisticsMinMax()
			{
			//----------------------------------------------------------------------------*
			// Get Database Selections
			//----------------------------------------------------------------------------*

			cFirearm Firearm = null;

			if (BallisticsFirearmCombo.SelectedIndex > 0)
				Firearm = (cFirearm) BallisticsFirearmCombo.SelectedItem;

			cBatch Batch = null;

			if (BallisticsBatchCombo.SelectedIndex > 0)
				Batch = (cBatch) BallisticsBatchCombo.SelectedItem;

			cLoad Load = null;

			if (Batch != null)
				Load = Batch.Load;
			else
				{
				if (BallisticsLoadCombo.SelectedIndex > 0)
					Load = (cLoad) BallisticsLoadCombo.SelectedItem;
				}

			double dCharge = 0.0;

			if (Load != null)
				Double.TryParse(BallisticsChargeCombo.Text, out dCharge);

			cCaliber Caliber = null;
			cBullet Bullet = null;

			if (Load != null)
				{
				Caliber = Load.Caliber;
				Bullet = Load.Bullet;
				}
			else
				{
				if (Firearm != null || BallisticsCaliberCombo.SelectedIndex > 0)
					Caliber = (cCaliber) BallisticsCaliberCombo.SelectedItem;
				}

			if (Bullet == null && BallisticsBulletCombo.SelectedIndex > 0)
				Bullet = (cBullet) BallisticsBulletCombo.SelectedItem;

			//----------------------------------------------------------------------------*
			// Set Bullet Data Min/Max
			//----------------------------------------------------------------------------*

			double dBCMin = 0.001;
			double dBCMax = 1.2;
			double dDiameterMin = 1000.0;
			double dDiameterMax = 0.0;
			double dWeightMin = 0.0;
			double dWeightMax = 1000.0;

			if (Bullet != null)
				{
				BallisticsBCTextBox.Enabled = Bullet.BallisticCoefficient == 0.0;
				BallisticsBulletDiameterTextBox.Enabled = Bullet.Diameter == 0.0;
				BallisticsBulletWeightTextBox.Enabled = Bullet.Weight == 0.0;
				BallisticsBulletLengthTextBox.Enabled = Bullet.Length == 0.0;

				dDiameterMin = 0.170;
				dDiameterMax = 0.650;
				dWeightMin = cBullet.MinBulletWeight;
				dWeightMax = cBullet.MaxBulletWeight;
				}
			else
				{
				BallisticsBCTextBox.Enabled = true;
				BallisticsBulletDiameterTextBox.Enabled = true;
				BallisticsBulletWeightTextBox.Enabled = true;
				BallisticsBulletLengthTextBox.Enabled = true;

				if (Caliber != null)
					{
					if (Caliber.MinBulletDiameter < dDiameterMin)
						dDiameterMin = Caliber.MinBulletDiameter;

					if (Caliber.MaxBulletDiameter > dDiameterMax)
						dDiameterMax = Caliber.MaxBulletDiameter;

					if (Caliber.MinBulletWeight < dWeightMin)
						dWeightMin = Caliber.MinBulletWeight;

					if (Caliber.MaxBulletWeight < dWeightMax)
						dWeightMax = Caliber.MaxBulletWeight;
					}
				else
					{
					dBCMin = 2.0;
					dBCMax = 0.0;

					foreach (cBullet CheckBullet in m_DataFiles.BulletList)
						{
						if (CheckBullet.BallisticCoefficient != 0.0 && CheckBullet.BallisticCoefficient < dBCMin)
							dBCMin = CheckBullet.BallisticCoefficient;

						if (CheckBullet.BallisticCoefficient != 0.0 && CheckBullet.BallisticCoefficient > dBCMax)
							dBCMax = CheckBullet.BallisticCoefficient;

						if (CheckBullet.Weight < dWeightMin)
							dWeightMin = CheckBullet.Weight;

						if (CheckBullet.Weight > dWeightMax)
							dWeightMax = CheckBullet.Weight;

						if (CheckBullet.Diameter < dDiameterMin)
							dDiameterMin = CheckBullet.Diameter;

						if (CheckBullet.Diameter > dDiameterMax)
							dDiameterMax = CheckBullet.Diameter;
						}
					}
				}

			BallisticsBCTextBox.MinValue = dBCMin;
			BallisticsBCTextBox.MaxValue = dBCMax;
			BallisticsBulletDiameterTextBox.MinValue = cDataFiles.StandardToMetric(dDiameterMin, cDataFiles.eDataType.Dimension);
			BallisticsBulletDiameterTextBox.MaxValue = cDataFiles.StandardToMetric(dDiameterMax, cDataFiles.eDataType.Dimension);
			BallisticsBulletWeightTextBox.MinValue = cDataFiles.StandardToMetric(dWeightMin,  cDataFiles.eDataType.BulletWeight);
			BallisticsBulletWeightTextBox.MaxValue = cDataFiles.StandardToMetric(dWeightMax,  cDataFiles.eDataType.BulletWeight);
            BallisticsBulletLengthTextBox.MinValue = 0.0;
			BallisticsBulletLengthTextBox.MaxValue = m_DataFiles.Preferences.MetricDimensions ? cConversions.InchesToMillimeters(3.0) : 3.0;

			//----------------------------------------------------------------------------*
			// Set Muzzle Velocity Min/Max
			//----------------------------------------------------------------------------*

			int nMin = 500;
			int nMax = 5000;
			bool fEnableVelocity = true;

			if (Load != null && dCharge != 0.0)
				{
				nMin = 5000;
				nMax = 0;

				foreach (cCharge Charge in Load.ChargeList)
					{
					foreach (cChargeTest ChargeTest in Charge.TestList)
						{
						if (ChargeTest.MuzzleVelocity != 0)
							{
							if ((!BallisticsBatchTestVelocityRadioButton.Checked || ChargeTest.BatchID != 0) &&
								(!BallisticsLoadDataVelocityRadioButton.Checked || ChargeTest.BatchID == 0))
								{
								if (ChargeTest.MuzzleVelocity < nMin)
									nMin = ChargeTest.MuzzleVelocity;

								if (ChargeTest.MuzzleVelocity > nMax)
									nMax = ChargeTest.MuzzleVelocity;

								fEnableVelocity = false;
								}
							}
						}
					}

				if (nMin > nMax)
					{
					nMin = 500;
					nMax = 5000;
					}
				}

			BallisticsMuzzleVelocityTextBox.Enabled = fEnableVelocity || (!BallisticsBatchTestVelocityRadioButton.Checked && !BallisticsLoadDataVelocityRadioButton.Checked);
			BallisticsMuzzleVelocityTextBox.MinValue = (int) Math.Round(cDataFiles.StandardToMetric(nMin, cDataFiles.eDataType.Velocity), 0);
			BallisticsMuzzleVelocityTextBox.MaxValue = (int) Math.Round(cDataFiles.StandardToMetric(nMax, cDataFiles.eDataType.Velocity), 0);

			//----------------------------------------------------------------------------*
			// Set Firearm Data Min/Max
			//----------------------------------------------------------------------------*

			int nHandgunMin = 25;
			int nHandgunMax = 100;
			int nRifleMin = 100;
			int nRifleMax = 2000;

			if (Firearm != null)
				{
				BallisticsZeroRangeTextBox.Enabled = false;
				BallisticsSightHeightTextBox.Enabled = false;
				BallisticsTurretTypeComboBox.Enabled = false;
				BallisticsScopeClickTextBox.Enabled = false;
				BallisticsTwistTextBox.Enabled = false;
				}
			else
				{
				BallisticsZeroRangeTextBox.MinValue = BallisticsFirearmTypeCombo.Value == cFirearm.eFireArmType.Handgun ? nHandgunMin : nRifleMin;
				BallisticsZeroRangeTextBox.MaxValue = BallisticsFirearmTypeCombo.Value == cFirearm.eFireArmType.Handgun ? nHandgunMax : nRifleMax;
				BallisticsZeroRangeTextBox.Enabled = true;

				BallisticsSightHeightTextBox.MinValue = 0.0;
				BallisticsSightHeightTextBox.MaxValue = m_DataFiles.Preferences.MetricFirearms ? cConversions.InchesToCentimeters(5.0) : 5.0;

				BallisticsSightHeightTextBox.Enabled = true;

				BallisticsTurretTypeComboBox.Enabled = true;

				BallisticsScopeClickTextBox.MinValue = 0.0;
				BallisticsScopeClickTextBox.MaxValue = 1.0;
				BallisticsScopeClickTextBox.Enabled = true;

				BallisticsTwistTextBox.MinValue = m_DataFiles.Preferences.MetricFirearms ? cConversions.InchesToCentimeters(5.0) : 5.0;
				BallisticsTwistTextBox.MaxValue = m_DataFiles.Preferences.MetricFirearms ? cConversions.InchesToCentimeters(78.0) : 78.0;
				BallisticsTwistTextBox.Enabled = true;
				}

			ElevationTurretUpDown.Minimum = -300;
			ElevationTurretUpDown.Maximum = 300;

			WindageTurretUpDown.Minimum = -300;
			WindageTurretUpDown.Maximum = 300;

			//----------------------------------------------------------------------------*
			// Set Environmental Data Min/Max
			//----------------------------------------------------------------------------*

			BallisticsTemperatureTextBox.MinValue = m_DataFiles.Preferences.MetricTemperatures ? cConversions.FahrenheitToCelsius(0) : 0;
			BallisticsTemperatureTextBox.MaxValue = m_DataFiles.Preferences.MetricTemperatures ? cConversions.FahrenheitToCelsius(120) : 120;

			BallisticsAltitudeTextBox.MinValue = 0;
			BallisticsAltitudeTextBox.MaxValue = m_DataFiles.Preferences.MetricAltitudes ? (int) cConversions.FeetToMeters(15000) : 15000;

			BallisticsHumidityTextBox.MinValue = 0;
			BallisticsHumidityTextBox.MaxValue = 100;

			BallisticsWindSpeedTextBox.MinValue = 0;
			BallisticsWindSpeedTextBox.MaxValue = m_DataFiles.Preferences.MetricVelocities ? (int) cConversions.MPHToKPH(30) : 30;

			BallisticsWindDirectionTextBox.MinValue = 0;
			BallisticsWindDirectionTextBox.MaxValue = 359;

			BallisticsPressureTextBox.MinValue = m_DataFiles.Preferences.MetricPressures ? cConversions.InHgToMillibars(25) : 25;
			BallisticsPressureTextBox.MaxValue = m_DataFiles.Preferences.MetricPressures ? cConversions.InHgToMillibars(33) : 33;

			//----------------------------------------------------------------------------*
			// Set Range Data Min/Max
			//----------------------------------------------------------------------------*

			BallisticsMinRangeTextBox.MinValue = 0;
			BallisticsMinRangeTextBox.MaxValue = BallisticsFirearmTypeCombo.Value == cFirearm.eFireArmType.Handgun ? nHandgunMin : nRifleMin;

			BallisticsMaxRangeTextBox.MinValue = (int) (m_BallisticsData.MinRange == 0.0 ? BallisticsFirearmTypeCombo.Value == cFirearm.eFireArmType.Handgun ? 25 : 100 : BallisticsFirearmTypeCombo.Value == cFirearm.eFireArmType.Handgun ? m_BallisticsData.MinRange + nHandgunMin : m_BallisticsData.MinRange + nRifleMin);
			BallisticsMaxRangeTextBox.MaxValue = BallisticsFirearmTypeCombo.Value == cFirearm.eFireArmType.Handgun ? nHandgunMax : nRifleMax;

			BallisticsIncrementTextBox.MinValue = (int) ((BallisticsMaxRangeTextBox.Value - BallisticsMinRangeTextBox.Value) / 20);
			BallisticsIncrementTextBox.MaxValue = (int) ((BallisticsMaxRangeTextBox.Value - BallisticsMinRangeTextBox.Value) / 5);

			BallisticsTargetRangeTextBox.MinValue = (int) (m_BallisticsData.MinRange < m_BallisticsData.Increment ? m_BallisticsData.Increment : m_BallisticsData.MinRange);
			BallisticsTargetRangeTextBox.MaxValue = (int) (m_BallisticsData.MaxRange);
			}

		//============================================================================*
		// SetBallisticsPressure()
		//============================================================================*

		private void SetBallisticsPressure()
			{
			m_BallisticsData.Pressure = cDataFiles.MetricToStandard(BallisticsPressureTextBox.Value, cDataFiles.eDataType.Pressure);
			m_DataFiles.Preferences.BallisticsData.Pressure = cDataFiles.MetricToStandard(BallisticsPressureTextBox.Value, cDataFiles.eDataType.Pressure);
			}

		//============================================================================*
		// SetBallisticsTemperature()
		//============================================================================*

		private void SetBallisticsTemperature()
			{
			m_BallisticsData.Temperature = (int) cDataFiles.MetricToStandard(BallisticsTemperatureTextBox.Value, cDataFiles.eDataType.Temperature);
			m_DataFiles.Preferences.BallisticsData.Temperature = (int) cDataFiles.MetricToStandard(BallisticsTemperatureTextBox.Value, cDataFiles.eDataType.Temperature);
			}

		//============================================================================*
		// SetBallisticsWindDirection()
		//============================================================================*

		private void SetBallisticsWindDirection()
			{
			m_BallisticsData.WindDirection = BallisticsWindDirectionTextBox.Value;
			m_DataFiles.Preferences.BallisticsData.WindDirection = BallisticsWindDirectionTextBox.Value;
			}

		//============================================================================*
		// SetBallisticsWindSpeed()
		//============================================================================*

		private void SetBallisticsWindSpeed()
			{
			m_BallisticsData.WindSpeed = (int) cDataFiles.MetricToStandard(BallisticsWindSpeedTextBox.Value, cDataFiles.eDataType.Speed);
			m_DataFiles.Preferences.BallisticsData.WindSpeed = (int) cDataFiles.MetricToStandard(BallisticsWindSpeedTextBox.Value, cDataFiles.eDataType.Speed);
			}

		//============================================================================*
		// SetChartBackgrounds()
		//============================================================================*

		private void SetChartBackgrounds()
			{
			SetDropChartBackground();

			SetDriftChartBackground();
			}

		//============================================================================*
		// SetDensityAltitude()
		//============================================================================*

		private void SetDensityAltitude()
			{
			double dDensityAltitude = cDataFiles.StandardToMetric(m_BallisticsData.DensityAltitude, cDataFiles.eDataType.Altitude);
			/*
						if (m_RWKestrel.Connected)
							dDensityAltitude = m_RWKestrel.DensityAltitude;
			*/
			BallisticsDensityAltitudeLabel.Text = String.Format("{0:F0} {1}", dDensityAltitude, cDataFiles.MetricString(cDataFiles.eDataType.Altitude));

			SetStationPressure();
			}

		//============================================================================*
		// SetDropChartBackground()
		//============================================================================*

		private void SetDropChartBackground()
			{
			//----------------------------------------------------------------------------*
			// Get Background Image
			//----------------------------------------------------------------------------*

			Bitmap DropChartBackground = new Bitmap(BulletDropChart.Width, BulletDropChart.Height, System.Drawing.Imaging.PixelFormat.Format16bppRgb555);
			DropChartBackground.SetResolution(200.0f, 200.0f);

			Graphics g = Graphics.FromImage(DropChartBackground);

			Brush GrassBrush = new SolidBrush(Color.FromArgb(85, 254, 1));
			Brush SkyBrush = new SolidBrush(Color.FromArgb(127, 255, 254));

			g.FillRectangle(SkyBrush, 0, 0, DropChartBackground.Width, DropChartBackground.Height / 2);
			g.FillRectangle(GrassBrush, 0, DropChartBackground.Height / 2, DropChartBackground.Width, DropChartBackground.Height / 2);

			//----------------------------------------------------------------------------*
			// Calculate Pixel Dimensions
			//----------------------------------------------------------------------------*

			int nChartLeft = 50;
			int nChartRight = BulletDropChart.Width - 50;

			double dNumPixelsX = nChartRight - nChartLeft;

			if (m_BallisticsData.MaxRange == 0)
				return;

			m_dPixelsPerXUnit = (dNumPixelsX / m_BallisticsData.MaxRange);

			m_dPixelsPerYUnit = (double) ((double) m_DropChartStandingShooter.Height / 72.0);

			//----------------------------------------------------------------------------*
			// Draw Shooter
			//----------------------------------------------------------------------------*

			int nX = nChartLeft - m_DropChartStandingShooter.Width;
			int nY = (int) ((DropChartBackground.Height / 2.0) - (m_DropChartStandingShooter.Height / 3.0));

			m_nGroundY = nY + m_DropChartStandingShooter.Height;

			g.DrawImage(m_DropChartStandingShooter, nX, nY);

			m_nChartStartX = nX + m_DropChartStandingShooter.Width;
			m_nChartStartY = nY + 8; // - (int) Math.Round(m_BallisticsData.SightHeight, 0);

			//----------------------------------------------------------------------------*
			// Draw Target Stand
			//----------------------------------------------------------------------------*

			nX = m_nChartStartX + (int) ((m_dPixelsPerXUnit * m_BallisticsData.TargetRange) - (m_DropChartTarget.Width / 2.0));
			nY = m_nChartStartY - (m_DropChartTarget.Height / 2);

			m_nChartEndY = nY + (m_DropChartTarget.Height / 2);

			Pen StandPen = new Pen(Color.Brown, 10);

			g.DrawLine(StandPen, nX + 3 + (m_DropChartTarget.Width / 2), m_nGroundY, nX + 3 + (m_DropChartTarget.Width / 2), m_nChartEndY);

			//----------------------------------------------------------------------------*
			// Draw Target
			//----------------------------------------------------------------------------*

			g.DrawImage(m_DropChartTarget, nX, nY);

			//----------------------------------------------------------------------------*
			// Set Background Image
			//----------------------------------------------------------------------------*

			BulletDropChart.Image = DropChartBackground;

			GrassBrush.Dispose();
			SkyBrush.Dispose();
			}

		//============================================================================*
		// SetDriftChartBackground()
		//============================================================================*

		private void SetDriftChartBackground()
			{
			//----------------------------------------------------------------------------*
			// Get Background Image
			//----------------------------------------------------------------------------*

			Bitmap DriftChartBackground = new Bitmap(WindDriftChart.Width, WindDriftChart.Height, System.Drawing.Imaging.PixelFormat.Format16bppRgb555);
			DriftChartBackground.SetResolution(200.0f, 200.0f);

			Graphics g = Graphics.FromImage(DriftChartBackground);

			Brush GrassBrush = new SolidBrush(Color.FromArgb(85, 254, 1));

			g.FillRectangle(GrassBrush, 0, 0, DriftChartBackground.Width, DriftChartBackground.Height);

			//----------------------------------------------------------------------------*
			// Draw Shooter
			//----------------------------------------------------------------------------*

			m_nDriftChartStartY = DriftChartBackground.Height / 2;

			int nX = m_nChartStartX - m_DriftChartShooter.Width;
			int nY = m_nDriftChartStartY - (m_DriftChartShooter.Height / 2);

			g.DrawImage(m_DriftChartShooter, nX, nY);

			//----------------------------------------------------------------------------*
			// Draw Target
			//----------------------------------------------------------------------------*

			nX = m_nChartStartX + (int) ((m_dPixelsPerXUnit * m_BallisticsData.TargetRange) - (m_DropChartTarget.Width / 2.0));
			nY = m_nDriftChartStartY - (m_DropChartTarget.Height / 2);

			g.DrawImage(m_DropChartTarget, nX, nY);

			//----------------------------------------------------------------------------*
			// Set Background Image
			//----------------------------------------------------------------------------*

			WindDriftChart.Image = DriftChartBackground;

			GrassBrush.Dispose();
			}

		//============================================================================*
		// SetInputParameters()
		//============================================================================*

		private void SetInputParameters()
			{
			//----------------------------------------------------------------------------*
			// Bullet Data
			//----------------------------------------------------------------------------*

			BallisticsBCTextBox.NumDecimals = 3;
			BallisticsBCTextBox.MaxLength = 5;

			cDataFiles.SetInputParameters(BallisticsBulletDiameterTextBox, cDataFiles.eDataType.Dimension);
			cDataFiles.SetMetricLabel(BulletDiameterMeasurementLabel, cDataFiles.eDataType.Dimension);

			cDataFiles.SetInputParameters(BallisticsBulletWeightTextBox, cDataFiles.eDataType.BulletWeight);
			cDataFiles.SetMetricLabel(BulletWeightMeasurementLabel, cDataFiles.eDataType.Dimension);

			cDataFiles.SetInputParameters(BallisticsBulletLengthTextBox, cDataFiles.eDataType.Dimension);
			cDataFiles.SetMetricLabel(BulletLengthMeasurementLabel, cDataFiles.eDataType.Dimension);

			//----------------------------------------------------------------------------*
			// Firearm Data
			//----------------------------------------------------------------------------*

			cDataFiles.SetInputParameters(BallisticsZeroRangeTextBox, cDataFiles.eDataType.Range);
			cDataFiles.SetMetricLabel(ZeroRangeMeasurementLabel,cDataFiles.eDataType.Range);

			cDataFiles.SetInputParameters(BallisticsSightHeightTextBox, cDataFiles.eDataType.Firearm);
			cDataFiles.SetMetricLabel(SightHeightMeasurementLabel,cDataFiles.eDataType.Firearm);

			BallisticsScopeClickTextBox.NumDecimals = m_DataFiles.Preferences.FirearmDecimals;
			BallisticsScopeClickTextBox.MaxLength = 2 + m_DataFiles.Preferences.FirearmDecimals;

			BallisticsTwistTextBox.NumDecimals = m_DataFiles.Preferences.FirearmDecimals;
			BallisticsTwistTextBox.MaxLength = 3 + m_DataFiles.Preferences.FirearmDecimals;
			cDataFiles.SetMetricLabel(TwistMeasurementLabel,cDataFiles.eDataType.Firearm);

			//----------------------------------------------------------------------------*
			// Atmospheric Data
			//----------------------------------------------------------------------------*

			cDataFiles.SetInputParameters(BallisticsWindSpeedTextBox, cDataFiles.eDataType.Speed);
			cDataFiles.SetMetricLabel(WindSpeedMeasurementLabel,cDataFiles.eDataType.Speed);

			BallisticsWindDirectionTextBox.MaxLength = 3;
			BallisticsWindDirectionTextBox.MaxValue = 359;

			cDataFiles.SetInputParameters(BallisticsTemperatureTextBox, cDataFiles.eDataType.Temperature);
			cDataFiles.SetMetricLabel(TemperatureMeasurementLabel, cDataFiles.eDataType.Temperature);

			cDataFiles.SetInputParameters(BallisticsAltitudeTextBox, cDataFiles.eDataType.Altitude);
			cDataFiles.SetMetricLabel(AltitudeMeasurementLabel, cDataFiles.eDataType.Altitude);

			cDataFiles.SetInputParameters(BallisticsPressureTextBox, cDataFiles.eDataType.Pressure);
			cDataFiles.SetMetricLabel(BallisticsPressureMeasurementLabel, cDataFiles.eDataType.Pressure);

			BallisticsHumidityTextBox.MaxLength = 3;
			BallisticsHumidityTextBox.MaxValue = 100;

			//----------------------------------------------------------------------------*
			// Range Data
			//----------------------------------------------------------------------------*

			cDataFiles.SetInputParameters(BallisticsMinRangeTextBox, cDataFiles.eDataType.Range);
			cDataFiles.SetMetricLabel(MinRangeMeasurementLabel, cDataFiles.eDataType.Range);

			cDataFiles.SetInputParameters(BallisticsMaxRangeTextBox, cDataFiles.eDataType.Range);
			cDataFiles.SetMetricLabel(MaxRangeMeasurementLabel, cDataFiles.eDataType.Range);

			cDataFiles.SetInputParameters(BallisticsIncrementTextBox, cDataFiles.eDataType.Range);
			cDataFiles.SetMetricLabel(IncrementMeasurementLabel,cDataFiles.eDataType.Range);

			cDataFiles.SetInputParameters(BallisticsTargetRangeTextBox, cDataFiles.eDataType.Range);
			cDataFiles.SetMetricLabel(TargetRangeMeasurementLabel, cDataFiles.eDataType.Range);

			//----------------------------------------------------------------------------*
			// Muzzle Velocity
			//----------------------------------------------------------------------------*

			cDataFiles.SetInputParameters(BallisticsMuzzleVelocityTextBox, cDataFiles.eDataType.Velocity);
			cDataFiles.SetMetricLabel(MuzzleVelocityMeasurementLabel, cDataFiles.eDataType.Velocity);
			}

		//============================================================================*
		// SetStaticToolTips()
		//============================================================================*

		private void SetStaticToolTips()
			{
			m_BallisticsBatchToolTip.ShowAlways = true;
			m_BallisticsBatchToolTip.RemoveAll();
			m_BallisticsBatchToolTip.SetToolTip(BallisticsBatchCombo, cm_strBallisticsBatchToolTip);

			m_BallisticsLoadToolTip.ShowAlways = true;
			m_BallisticsLoadToolTip.RemoveAll();
			m_BallisticsLoadToolTip.SetToolTip(BallisticsLoadCombo, cm_strBallisticsLoadToolTip);

			m_BallisticsFirearmToolTip.ShowAlways = true;
			m_BallisticsFirearmToolTip.RemoveAll();
			m_BallisticsFirearmToolTip.SetToolTip(BallisticsFirearmCombo, cm_strBallisticsFirearmToolTip);

			m_BallisticsChargeToolTip.ShowAlways = true;
			m_BallisticsChargeToolTip.RemoveAll();
			m_BallisticsChargeToolTip.SetToolTip(BallisticsChargeCombo, cm_strBallisticsChargeToolTip);

			m_BallisticsCaliberToolTip.ShowAlways = true;
			m_BallisticsCaliberToolTip.RemoveAll();
			m_BallisticsCaliberToolTip.SetToolTip(BallisticsCaliberCombo, cm_strBallisticsCaliberToolTip);

			m_BallisticsBulletToolTip.ShowAlways = true;
			m_BallisticsBulletToolTip.RemoveAll();
			m_BallisticsBulletToolTip.SetToolTip(BallisticsBulletCombo, cm_strBallisticsBulletToolTip);

			m_BallisticsTurretTypeToolTip.ShowAlways = true;
			m_BallisticsTurretTypeToolTip.RemoveAll();
			m_BallisticsTurretTypeToolTip.SetToolTip(BallisticsTurretTypeComboBox, cm_strBallisticsTurretTypeToolTip);

			m_SaveReferenceBulletToolTip.ShowAlways = true;
			m_SaveReferenceBulletToolTip.RemoveAll();
			m_SaveReferenceBulletToolTip.SetToolTip(SaveReferenceBulletButton, cm_strSaveReferenceBulletToolTip);

			m_RestoreReferenceBulletToolTip.ShowAlways = true;
			m_RestoreReferenceBulletToolTip.RemoveAll();
			m_RestoreReferenceBulletToolTip.SetToolTip(RestoreReferenceBulletButton, cm_strRestoreReferenceBulletToolTip);

			m_BallisticsKestrelToolTip.ShowAlways = true;
			m_BallisticsKestrelToolTip.RemoveAll();
			m_BallisticsKestrelToolTip.SetToolTip(BallisticsKestrelButton, cm_strBallisticsKestrelToolTip);

			m_CompareReferenceBulletToolTip.ShowAlways = true;
			m_CompareReferenceBulletToolTip.RemoveAll();
			m_CompareReferenceBulletToolTip.SetToolTip(RestoreReferenceBulletButton, cm_strCompareReferenceBulletToolTip);

			BallisticsBCTextBox.ToolTip = cm_strBallisticsBCToolTip;
			BallisticsBulletDiameterTextBox.ToolTip = cm_strBallisticsBulletDiameterToolTip;
			BallisticsBulletWeightTextBox.ToolTip = cm_strBallisticsBulletWeightToolTip;
			BallisticsMuzzleVelocityTextBox.ToolTip = cm_strBallisticsMuzzleVelocityToolTip;

			BallisticsZeroRangeTextBox.ToolTip = cm_strBallisticsZeroRangeToolTip;
			BallisticsSightHeightTextBox.ToolTip = cm_strBallisticsSightHeightToolTip;
			BallisticsScopeClickTextBox.ToolTip = cm_strBallisticsScopeClickToolTip;
			BallisticsSightHeightTextBox.ToolTip = cm_strBallisticsSightHeightToolTip;

			BallisticsAltitudeTextBox.ToolTip = cm_strBallisticsAltitudeToolTip;
			BallisticsTemperatureTextBox.ToolTip = cm_strBallisticsTemperatureToolTip;
			BallisticsPressureTextBox.ToolTip = cm_strBallisticsPressureToolTip;

			BallisticsWindSpeedTextBox.ToolTip = cm_strBallisticsWindSpeedToolTip;
			BallisticsWindDirectionTextBox.ToolTip = cm_strBallisticsWindDirectionToolTip;

			BallisticsMinRangeTextBox.ToolTip = cm_strBallisticsMinRangeToolTip;
			BallisticsMaxRangeTextBox.ToolTip = cm_strBallisticsMaxRangeToolTip;
			BallisticsIncrementTextBox.ToolTip = cm_strBallisticsIncrementToolTip;
			BallisticsTargetRangeTextBox.ToolTip = cm_strBallisticsTargetRangeToolTip;
			}

		//============================================================================*
		// SetStationPressure()
		//============================================================================*

		private void SetStationPressure()
			{
			BallisticsStationPressureLabel.Text = String.Format("{0:F2} {1}", cDataFiles.StandardToMetric(m_BallisticsData.StationPressure, cDataFiles.eDataType.Pressure), cDataFiles.MetricString(cDataFiles.eDataType.Pressure));
			}

		//============================================================================*
		// SetWindage()
		//============================================================================*

		private void SetWindage()
			{
			HeadWindLabel.Text = String.Format("{0:F1}", m_BallisticsData.HeadWind);
			CrossWindLabel.Text = String.Format("{0:F1}", m_BallisticsData.CrossWind);
			}

		//============================================================================*
		// UpdateBallisticsTabButtons()
		//============================================================================*

		private void UpdateBallisticsTabButtons()
			{
			bool fEnable = true;

			//----------------------------------------------------------------------------*
			// Ballistics Coefficient
			//----------------------------------------------------------------------------*

			if (!BallisticsBCTextBox.ValueOK)
				fEnable = false;

			//----------------------------------------------------------------------------*
			// Bullet Data
			//----------------------------------------------------------------------------*

			if (!BallisticsBulletDiameterTextBox.ValueOK)
				fEnable = false;

			if (!BallisticsBulletWeightTextBox.ValueOK)
				fEnable = false;

			//----------------------------------------------------------------------------*
			// Firearm Info
			//----------------------------------------------------------------------------*

			if (!BallisticsZeroRangeTextBox.ValueOK)
				fEnable = false;

			if (!BallisticsScopeClickTextBox.ValueOK)
				fEnable = false;

			if (!BallisticsSightHeightTextBox.ValueOK)
				fEnable = false;

			if (!BallisticsTwistTextBox.ValueOK)
				fEnable = false;

			//----------------------------------------------------------------------------*
			// Muzzle Info
			//----------------------------------------------------------------------------*

			if (!BallisticsMuzzleVelocityTextBox.ValueOK)
				fEnable = false;

			//----------------------------------------------------------------------------*
			// Zero Range
			//----------------------------------------------------------------------------*

			if (!BallisticsZeroRangeTextBox.ValueOK)
				fEnable = false;

			//----------------------------------------------------------------------------*
			// Wind Speed and Direction
			//----------------------------------------------------------------------------*

			if (!BallisticsWindSpeedTextBox.ValueOK)
				fEnable = false;

			if (!BallisticsWindDirectionTextBox.ValueOK)
				fEnable = false;

			//----------------------------------------------------------------------------*
			// Range Data
			//----------------------------------------------------------------------------*

			if (!BallisticsMinRangeTextBox.ValueOK)
				fEnable = false;

			if (!BallisticsMaxRangeTextBox.ValueOK)
				fEnable = false;

			if (!BallisticsIncrementTextBox.ValueOK)
				fEnable = false;

			if (!BallisticsTargetRangeTextBox.ValueOK)
				fEnable = false;

			//----------------------------------------------------------------------------*
			// Atmospheric Data
			//----------------------------------------------------------------------------*

			if (!BallisticsAltitudeTextBox.ValueOK)
				fEnable = false;

			if (!BallisticsTemperatureTextBox.ValueOK)
				fEnable = false;

			if (!BallisticsPressureTextBox.ValueOK)
				fEnable = false;

			if (!BallisticsPressureTextBox.ValueOK)
				fEnable = false;

			//----------------------------------------------------------------------------*
			// Kestrel Button
			//----------------------------------------------------------------------------*
			/*
						if (m_RWKestrel.Connected)
							{
							BallisticsKestrelButton.Text = "Kestrel Stop";

							BallisticsKestrelButton.BackColor = Color.Red;
							}
						else
							{
							BallisticsKestrelButton.Text = "Kestrel Start";

							BallisticsKestrelButton.BackColor = Color.Green;
							}

						BallisticsAltitudeTextBox.Enabled = !m_RWKestrel.UseAltitude;
						BallisticsHumidityTextBox.Enabled = !m_RWKestrel.UseHumidity;
						BallisticsPressureTextBox.Enabled = !m_RWKestrel.UseBarometricPressure;
						BallisticsTemperatureTextBox.Enabled = !m_RWKestrel.UseTemperature;
						BallisticsWindSpeedTextBox.Enabled = !m_RWKestrel.UseWindSpeed;
						BallisticsWindDirectionTextBox.Enabled = !m_RWKestrel.UseWindDirection;
			*/
			//----------------------------------------------------------------------------*
			// Enable Buttons
			//----------------------------------------------------------------------------*

			m_fCalculateOK = fEnable;
			SaveReferenceBulletButton.Enabled = fEnable;

			RestoreReferenceBulletButton.Enabled = true;
			CompareToReferenceBulletCheckBox.Enabled = fEnable;

			BallisticsUseSFCheckBox.Enabled = fEnable && BallisticsBulletLengthTextBox.Value != 0.0;

			if (!fEnable || !BallisticsUseSFCheckBox.Enabled)
				{
				BallisticsUseSFCheckBox.Checked = false;

				m_DataFiles.Preferences.BallisticsUseSF = false;
				}

			bool fReferenceData = m_DataFiles.Preferences.BallisticsData.CompareTo(m_BallisticsData) == 0;

			if (fReferenceData || ShowReferenceDataCheckBox.Checked)
				BallisticsInputDataGroupBox.Text = "Input Parameters (Reference Data)";
			else
				BallisticsInputDataGroupBox.Text = "Input Parameters";

			if (fEnable)
				{
				if (fReferenceData)
					{
					SaveReferenceBulletButton.Enabled = false;
					ShowReferenceDataCheckBox.Enabled = ShowReferenceDataCheckBox.Checked;
					ShowReferenceDataCheckBox.Checked = false;
					RestoreReferenceBulletButton.Enabled = false;
					CompareToReferenceBulletCheckBox.Enabled = false;
					CompareToReferenceBulletCheckBox.Checked = false;
					}
				else
					{
					ShowReferenceDataCheckBox.Enabled = true;
					}
				}

			if (CompareToReferenceBulletCheckBox.Enabled)
				{
				if (m_DataFiles.Preferences.BallisticsData.CompareAtmospherics(m_BallisticsData) != 0)
					{
					CompareToReferenceBulletCheckBox.Enabled = false;
					CompareToReferenceBulletCheckBox.Checked = false;
					}
				}
			}
		}
	}
