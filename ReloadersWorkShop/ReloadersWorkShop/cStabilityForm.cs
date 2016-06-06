//============================================================================*
// cStabilityForm.cs
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

using ReloadersWorkShop.Ballistics;

//============================================================================*
// NameSpace
//============================================================================*

namespace ReloadersWorkShop
	{
	//============================================================================*
	// cStabilityForm Class
	//============================================================================*

	public partial class cStabilityForm : Form
		{
		//============================================================================*
		// Private Constant Data Members
		//============================================================================*

		private int cm_nMinVelocity = 500;

		private const string cm_strLoadToolTip = "Select the load containing the bullet to be analyzed (optional).";
		private const string cm_strBulletToolTip = "Select the specific bullet to be analyzed (optional).";
		private const string cm_strFirearmToolTip = "Select the firearm that will fire the bullet (optional).";

		private const string cm_strLengthToolTip = "Length of the bullet to be analyzed.";
		private const string cm_strCaliberToolTip = "Caliber (diameter) of the bullet to be analyzed.";
		private const string cm_strWeightToolTip = "Weight of the bullet to be analyzed.";

		private const string cm_strTwistToolTip = "Twist rate of the firearm that will fire the bullet to be analyzed.";
		private const string cm_strVelocityToolTip = "Muzzle velocity of the bullet to be analyzed.";

		private const string cm_strTemperatureToolTip = "Anticipated temperature where the bullet will be fired.";
		private const string cm_strPressureToolTip = "Anticipated barometric Pressure where the bullet will be fired.";

		//============================================================================*
		// Private Data Members
		//============================================================================*

		private bool m_fInitialized = false;
		private bool m_fPopulating = false;

		private cDataFiles m_DataFiles = null;

		private cStability m_StabilityData = new cStability();

		private Bitmap m_ArrowBitmap = null;
		private Bitmap m_ArrowRightBitmap = null;

		private bool m_fCalculateOK = false;

		private ToolTip m_LoadToolTip = new ToolTip();
		private ToolTip m_BulletToolTip = new ToolTip();
		private ToolTip m_FirearmToolTip = new ToolTip();

		//============================================================================*
		// cStabilityForm() - Constructor
		//============================================================================*

		public cStabilityForm(cDataFiles DataFiles)
			{
			InitializeComponent();

			m_DataFiles = DataFiles;

			SetClientSizeCore(FirearmGroup.Location.X + FirearmGroup.Width + 10, CloseButton.Location.Y + CloseButton.Height + 20);

			//----------------------------------------------------------------------------*
			// Event Handlers
			//----------------------------------------------------------------------------*

			LoadCombo.SelectedIndexChanged += OnLoadSelected;
			BulletCombo.SelectedIndexChanged += OnBulletSelected;
			FirearmCombo.SelectedIndexChanged += OnFirearmSelected;

			CaliberTextBox.TextChanged += OnCaliberChanged;
			LengthTextBox.TextChanged += OnLengthChanged;
			WeightTextBox.TextChanged += OnBulletWeightChanged;

			TwistTextBox.TextChanged += OnTwistChanged;
			VelocityTextBox.TextChanged += OnVelocityChanged;

			TemperatureTextBox.TextChanged += OnTemperatureChanged;
			PressureTextBox.TextChanged += OnPressureChanged;
			AltitudeTextBox.TextChanged += OnAltitudeChanged;

			PressureRadioButton.Click += OnPressureClicked;
			AltitudeRadioButton.Click += OnAltitudeClicked;

			//----------------------------------------------------------------------------*
			// Populate Combos and setup data fields
			//----------------------------------------------------------------------------*

			SetStaticToolTips();

			SetDataParameters();

			PopulateLoadCombo();
			PopulateBulletCombo();
			PopulateFirearmCombo();

			PopulateData();

			SetMinMax();

			m_fInitialized = true;

			UpdateButtons();

			SetStabilityFactor();
			}

		//============================================================================*
		// OnAltitudeChanged()
		//============================================================================*

		private void OnAltitudeChanged(Object sender, EventArgs e)
			{
			if (!m_fInitialized || m_fPopulating)
				return;

			m_StabilityData.Altitude = (int) m_DataFiles.MetricToStandard(AltitudeTextBox.Value, cDataFiles.eDataType.Altitude);

			UpdateButtons();

			SetStabilityFactor();
			}

		//============================================================================*
		// OnAltitudeClicked()
		//============================================================================*

		private void OnAltitudeClicked(Object sender, EventArgs e)
			{
			AltitudeRadioButton.Checked = !AltitudeRadioButton.Checked;

			PressureRadioButton.Checked = !AltitudeRadioButton.Checked;

			m_StabilityData.UseAltitude = AltitudeRadioButton.Checked;

			UpdateButtons();

			SetStabilityFactor();
			}

		//============================================================================*
		// OnBulletSelected()
		//============================================================================*

		private void OnBulletSelected(Object sender, EventArgs e)
			{
			if (!m_fInitialized || m_fPopulating)
				return;

			if (BulletCombo.SelectedIndex > 0 || BulletCombo.SelectedItem is cBullet)
				{
				cBullet Bullet = (cBullet) BulletCombo.SelectedItem;

				m_StabilityData.Bullet = Bullet;
				}

			PopulateLoadCombo();
			PopulateFirearmCombo();

			PopulateData();

			SetMinMax();

			UpdateButtons();

			SetStabilityFactor();
			}

		//============================================================================*
		// OnCaliberChanged()
		//============================================================================*

		private void OnCaliberChanged(Object sender, EventArgs e)
			{
			if (!m_fInitialized || m_fPopulating)
				return;

			m_StabilityData.BulletDiameter = m_DataFiles.MetricToStandard(CaliberTextBox.Value, cDataFiles.eDataType.Dimension);

			UpdateButtons();

			SetStabilityFactor();
			}

		//============================================================================*
		// OnFirearmSelected()
		//============================================================================*

		private void OnFirearmSelected(Object sender, EventArgs e)
			{
			if (!m_fInitialized || m_fPopulating)
				return;

			cFirearm Firearm = null;

			if (FirearmCombo.SelectedIndex > 0)
				Firearm = (cFirearm) FirearmCombo.SelectedItem;

			if (Firearm != null)
				m_StabilityData.Twist = Firearm.Twist;

			PopulateLoadCombo();
			PopulateBulletCombo();

			PopulateData();

			SetMinMax();

			UpdateButtons();

			SetStabilityFactor();
			}

		//============================================================================*
		// OnLengthChanged()
		//============================================================================*

		private void OnLengthChanged(Object sender, EventArgs e)
			{
			if (!m_fInitialized || m_fPopulating)
				return;

			m_StabilityData.BulletLength = m_DataFiles.MetricToStandard(LengthTextBox.Value, cDataFiles.eDataType.Dimension);

			UpdateButtons();

			SetStabilityFactor();
			}

		//============================================================================*
		// OnLoadSelected()
		//============================================================================*

		private void OnLoadSelected(Object sender, EventArgs e)
			{
			if (!m_fInitialized || m_fPopulating)
				return;

			PopulateBulletCombo();
			PopulateFirearmCombo();

			PopulateData();

			SetMinMax();

			UpdateButtons();

			SetStabilityFactor();
			}

		//============================================================================*
		// OnPressureChanged()
		//============================================================================*

		private void OnPressureChanged(Object sender, EventArgs e)
			{
			if (!m_fInitialized || m_fPopulating)
				return;

			m_StabilityData.Pressure = m_DataFiles.MetricToStandard(PressureTextBox.Value, cDataFiles.eDataType.Pressure);

			UpdateButtons();

			SetStabilityFactor();
			}

		//============================================================================*
		// OnPressureClicked()
		//============================================================================*

		private void OnPressureClicked(Object sender, EventArgs e)
			{
			PressureRadioButton.Checked = !PressureRadioButton.Checked;

			AltitudeRadioButton.Checked = !PressureRadioButton.Checked;

			m_StabilityData.UseAltitude = AltitudeRadioButton.Checked;

			UpdateButtons();

			SetStabilityFactor();
			}

		//============================================================================*
		// OnTemperatureChanged()
		//============================================================================*

		private void OnTemperatureChanged(Object sender, EventArgs e)
			{
			if (!m_fInitialized || m_fPopulating)
				return;

			m_StabilityData.Temperature = (int) m_DataFiles.MetricToStandard(TemperatureTextBox.Value, cDataFiles.eDataType.Temperature);

			UpdateButtons();

			SetStabilityFactor();
			}

		//============================================================================*
		// OnTwistChanged()
		//============================================================================*

		private void OnTwistChanged(Object sender, EventArgs e)
			{
			if (!m_fInitialized || m_fPopulating)
				return;

			m_StabilityData.Twist = m_DataFiles.MetricToStandard(TwistTextBox.Value, cDataFiles.eDataType.Firearm);

			UpdateButtons();

			SetStabilityFactor();
			}

		//============================================================================*
		// OnVelocityChanged()
		//============================================================================*

		private void OnVelocityChanged(Object sender, EventArgs e)
			{
			if (!m_fInitialized || m_fPopulating)
				return;

			m_StabilityData.MuzzleVelocity = (int) m_DataFiles.MetricToStandard(VelocityTextBox.Value, cDataFiles.eDataType.Velocity);

			UpdateButtons();

			SetStabilityFactor();
			}

		//============================================================================*
		// OnBulletWeightChanged()
		//============================================================================*

		private void OnBulletWeightChanged(Object sender, EventArgs e)
			{
			if (!m_fInitialized || m_fPopulating)
				return;

			m_StabilityData.BulletWeight = m_DataFiles.MetricToStandard(WeightTextBox.Value, cDataFiles.eDataType.BulletWeight);

			UpdateButtons();

			SetStabilityFactor();
			}

		//============================================================================*
		// PopulateBulletCombo()
		//============================================================================*

		private void PopulateBulletCombo()
			{
			m_fPopulating = true;

			//----------------------------------------------------------------------------*
			// Get the currently selected Bullet
			//----------------------------------------------------------------------------*

			cBullet SelectedBullet = null;

			if (BulletCombo.SelectedIndex > 0 || BulletCombo.SelectedItem is cBullet)
				SelectedBullet = (cBullet) BulletCombo.SelectedItem;

			//----------------------------------------------------------------------------*
			// Reset the bullet combo
			//----------------------------------------------------------------------------*

			BulletCombo.Items.Clear();

			//----------------------------------------------------------------------------*
			// Get the selected load
			//----------------------------------------------------------------------------*

			cLoad Load = null;

			if (LoadCombo.SelectedIndex > 0)
				Load = (cLoad) LoadCombo.SelectedItem;

			//----------------------------------------------------------------------------*
			// Ge tthe selected firearm
			//----------------------------------------------------------------------------*

			cFirearm Firearm = null;

			if (FirearmCombo.SelectedIndex > 0)
				Firearm = (cFirearm) FirearmCombo.SelectedItem;

			//----------------------------------------------------------------------------*
			// If the load is not null, just add that bullet
			//----------------------------------------------------------------------------*

			if (Load != null)
				{
				BulletCombo.Items.Add(Load.Bullet);

				m_StabilityData.Bullet = Load.Bullet;
				}

			//----------------------------------------------------------------------------*
			// Otherwise, loop through the bullets
			//----------------------------------------------------------------------------*

			else
				{
				BulletCombo.Items.Add("No Specific Bullet");

				foreach (cBullet Bullet in m_DataFiles.BulletList)
					{
					//----------------------------------------------------------------------------*
					// Only include visible bullets
					//----------------------------------------------------------------------------*

					if ((!m_DataFiles.Preferences.HideUncheckedSupplies || Bullet.Checked) &&
						(Firearm == null || Firearm.CanUseBullet(Bullet)) &&
						Bullet.FirearmType == cFirearm.eFireArmType.Rifle)
						{
						BulletCombo.Items.Add(Bullet);
						}
					}
				}

			if (SelectedBullet != null)
				BulletCombo.SelectedItem = SelectedBullet;

			if (BulletCombo.SelectedIndex == -1)
				BulletCombo.SelectedIndex = 0;

			if (BulletCombo.SelectedIndex > 0 || BulletCombo.SelectedItem is cBullet)
				m_StabilityData.Bullet = BulletCombo.SelectedItem as cBullet;

			m_fPopulating = false;
			}

		//============================================================================*
		// PopulateData()
		//============================================================================*

		private void PopulateData()
			{
			m_fPopulating = true;

			CaliberTextBox.Value = m_DataFiles.StandardToMetric(m_StabilityData.BulletDiameter, cDataFiles.eDataType.Dimension);
			BallisticCoefficientTextBox.Value = m_StabilityData.BallisticCoefficient;
			LengthTextBox.Value = m_DataFiles.StandardToMetric(m_StabilityData.BulletLength, cDataFiles.eDataType.Dimension);
			WeightTextBox.Value = m_DataFiles.StandardToMetric(m_StabilityData.BulletWeight, cDataFiles.eDataType.BulletWeight);

			TwistTextBox.Value = m_DataFiles.StandardToMetric(m_StabilityData.Twist, cDataFiles.eDataType.Firearm);
			VelocityTextBox.Value = (int) m_DataFiles.StandardToMetric(m_StabilityData.MuzzleVelocity, cDataFiles.eDataType.Velocity);

			TemperatureTextBox.Value = (int) m_DataFiles.StandardToMetric(m_StabilityData.Temperature, cDataFiles.eDataType.Temperature);
			PressureTextBox.Value = m_DataFiles.StandardToMetric(m_StabilityData.Pressure, cDataFiles.eDataType.Pressure);
			AltitudeTextBox.Value = (int) m_DataFiles.StandardToMetric(m_StabilityData.Altitude, cDataFiles.eDataType.Altitude);

			AltitudeRadioButton.Checked = m_StabilityData.UseAltitude;
			PressureRadioButton.Checked = !m_StabilityData.UseAltitude;

			m_fPopulating = false;
			}

		//============================================================================*
		// PopulateFirearmCombo()
		//============================================================================*

		private void PopulateFirearmCombo()
			{
			m_fPopulating = true;

			//----------------------------------------------------------------------------*
			// Get the currently selected firearm
			//----------------------------------------------------------------------------*

			cFirearm SelectedFirearm = null;

			if (FirearmCombo.SelectedIndex > 0 || FirearmCombo.SelectedItem is cFirearm)
				SelectedFirearm = (cFirearm) FirearmCombo.SelectedItem;

			//----------------------------------------------------------------------------*
			// Reset the firearm combo
			//----------------------------------------------------------------------------*

			FirearmCombo.Items.Clear();

			//----------------------------------------------------------------------------*
			// Get the selected Bullet
			//----------------------------------------------------------------------------*

			cBullet Bullet = null;

			if (BulletCombo.SelectedIndex > 0 || BulletCombo.SelectedItem is cBullet)
				Bullet = (cBullet) BulletCombo.SelectedItem;

			//----------------------------------------------------------------------------*
			// Populate the firearm combo
			//----------------------------------------------------------------------------*

			FirearmCombo.Items.Add("No Specific Firearm");

			foreach (cFirearm Firearm in m_DataFiles.FirearmList)
				{
				if (Firearm.FirearmType == cFirearm.eFireArmType.Rifle &&
					(Bullet == null || Firearm.CanUseBullet(Bullet)))
					FirearmCombo.Items.Add(Firearm);
				}

			if (SelectedFirearm != null)
				FirearmCombo.SelectedItem = SelectedFirearm;

			if (FirearmCombo.SelectedIndex == -1)
				FirearmCombo.SelectedIndex = 0;

			m_fPopulating = false;
			}

		//============================================================================*
		// PopulateLoadCombo()
		//============================================================================*

		private void PopulateLoadCombo()
			{
			m_fPopulating = true;

			//----------------------------------------------------------------------------*
			// Get the currently selected load
			//----------------------------------------------------------------------------*

			cLoad SelectedLoad = null;

			if (LoadCombo.SelectedIndex > 0 || LoadCombo.SelectedItem is cFirearm)
				SelectedLoad = (cLoad) LoadCombo.SelectedItem;

			//----------------------------------------------------------------------------*
			// Get the selected firearm
			//----------------------------------------------------------------------------*

			cFirearm Firearm = null;

			if (FirearmCombo.SelectedIndex > 0)
				Firearm = (cFirearm) FirearmCombo.SelectedItem;

			//----------------------------------------------------------------------------*
			// Get the selected bullet
			//----------------------------------------------------------------------------*

			cBullet Bullet = null;

			if (BulletCombo.SelectedIndex > 0)
				Bullet = (cBullet) BulletCombo.SelectedItem;

			//----------------------------------------------------------------------------*
			// Reset the Load Combo
			//----------------------------------------------------------------------------*

			LoadCombo.Items.Clear();

			LoadCombo.Items.Add("No Specific Load");

			//----------------------------------------------------------------------------*
			// Loop through the Loads
			//----------------------------------------------------------------------------*

			foreach (cLoad Load in m_DataFiles.LoadList)
				{
				//----------------------------------------------------------------------------*
				// Only include loads with visible bullets
				//----------------------------------------------------------------------------*

				if (Load.FirearmType == cFirearm.eFireArmType.Rifle &&
					(Bullet == null || Load.Bullet.CompareTo(Bullet) == 0) &&
					(Firearm == null || Firearm.HasCaliber(Load.Caliber)) &&
					(!m_DataFiles.Preferences.HideUncheckedCalibers || Load.Caliber.Checked) &&
					(!m_DataFiles.Preferences.HideUncheckedSupplies || Load.Bullet.Checked) &&
					(!m_DataFiles.Preferences.HideUncheckedSupplies || Load.Case.Checked) &&
					(!m_DataFiles.Preferences.HideUncheckedSupplies || Load.Primer.Checked) &&
					(!m_DataFiles.Preferences.HideUncheckedSupplies || Load.Powder.Checked))
					{
					LoadCombo.Items.Add(Load);
					}
				}

			if (SelectedLoad != null)
				LoadCombo.SelectedItem = SelectedLoad;

			if (LoadCombo.SelectedIndex == -1)
				LoadCombo.SelectedIndex = 0;

			m_fPopulating = false;
			}

		//============================================================================*
		// SetDataParameters()
		//============================================================================*

		private void SetDataParameters()
			{
			//----------------------------------------------------------------------------*
			// Set number of decimal places
			//----------------------------------------------------------------------------*

			LengthTextBox.NumDecimals = m_DataFiles.Preferences.DimensionDecimals;
			LengthTextBox.MaxLength = 2 + m_DataFiles.Preferences.DimensionDecimals;

			CaliberTextBox.NumDecimals = m_DataFiles.Preferences.DimensionDecimals;
			CaliberTextBox.MaxLength = 2 + m_DataFiles.Preferences.DimensionDecimals;

			WeightTextBox.NumDecimals = m_DataFiles.Preferences.BulletWeightDecimals;
			WeightTextBox.MaxLength = 4 + m_DataFiles.Preferences.DimensionDecimals;

			TwistTextBox.NumDecimals = m_DataFiles.Preferences.FirearmDecimals;
			TwistTextBox.MaxLength = 3 + m_DataFiles.Preferences.DimensionDecimals;

			//----------------------------------------------------------------------------*
			// Set measurement labels
			//----------------------------------------------------------------------------*

			CaliberMeasurementLabel.Text = m_DataFiles.MetricString(cDataFiles.eDataType.Dimension);
			LengthMeasurementLabel.Text = m_DataFiles.MetricString(cDataFiles.eDataType.Dimension);
			WeightMeasurementLabel.Text = m_DataFiles.MetricString(cDataFiles.eDataType.BulletWeight);

			TwistMeasurementLabel.Text = m_DataFiles.MetricString(cDataFiles.eDataType.Firearm);
			VelocityMeasurementLabel.Text = m_DataFiles.MetricString(cDataFiles.eDataType.Velocity);

			TemperatureMeasurementLabel.Text = m_DataFiles.MetricString(cDataFiles.eDataType.Temperature);

			//----------------------------------------------------------------------------*
			// Set stability chart image
			//----------------------------------------------------------------------------*

			Bitmap ChartBitmap = Properties.Resources.StabilityChart;
			m_ArrowBitmap = Properties.Resources.StabilityArrow;
			m_ArrowRightBitmap = Properties.Resources.StabilityArrowRight;

			StabilityPictureBox.Image = ChartBitmap;
			ArrowPictureBox.Image = m_ArrowBitmap;
			}

		//============================================================================*
		// SetMinMax()
		//============================================================================*

		private void SetMinMax()
			{
			//----------------------------------------------------------------------------*
			// Get Load
			//----------------------------------------------------------------------------*

			cLoad Load = null;

			if (LoadCombo.SelectedIndex > 0)
				Load = (cLoad) LoadCombo.SelectedItem;

			//----------------------------------------------------------------------------*
			// Get Bullet
			//----------------------------------------------------------------------------*

			cBullet Bullet = null;

			if (BulletCombo.SelectedIndex > 0 || BulletCombo.SelectedItem is cBullet)
				Bullet = (cBullet) BulletCombo.SelectedItem;

			//----------------------------------------------------------------------------*
			// Get Firearm
			//----------------------------------------------------------------------------*

			cFirearm Firearm = null;

			if (FirearmCombo.SelectedIndex > 0)
				Firearm = (cFirearm) FirearmCombo.SelectedItem;

			//----------------------------------------------------------------------------*
			// Get caliber list depending on the firearm or bullet selected
			//----------------------------------------------------------------------------*

			cCaliberList CaliberList = m_DataFiles.CaliberList;

			if (Bullet != null)
				{
				CaliberList = new cCaliberList();

				foreach (cBulletCaliber BulletCaliber in Bullet.CaliberList)
					CaliberList.Add(BulletCaliber.Caliber);
				}
			else
				{
				if (Firearm != null)
					{
					CaliberList = new cCaliberList();

					foreach (cFirearmCaliber FirearmCaliber in Firearm.CaliberList)
						CaliberList.Add(FirearmCaliber.Caliber);
					}
				}

			//----------------------------------------------------------------------------*
			// Set Caliber Min/Max
			//----------------------------------------------------------------------------*

			double dMinDiameter = m_DataFiles.StandardToMetric(1000.0, cDataFiles.eDataType.Dimension);
			double dMaxDiameter = m_DataFiles.StandardToMetric(0.0, cDataFiles.eDataType.Dimension);

			double dMinWeight = m_DataFiles.StandardToMetric(cBullet.MaxBulletWeight, cDataFiles.eDataType.BulletWeight);
			double dMaxWeight = m_DataFiles.StandardToMetric(0.0, cDataFiles.eDataType.BulletWeight);

			foreach (cCaliber Caliber in CaliberList)
				{
				if ((Load == null || Load.Caliber.CompareTo(Caliber) == 0) &&
					(Firearm == null || Firearm.HasCaliber(Caliber)) &&
					(Bullet == null || Bullet.HasCaliber(Caliber)))
					{
					if (Caliber.MinBulletDiameter < dMinDiameter)
						dMinDiameter = Caliber.MinBulletDiameter;

					if (Caliber.MaxBulletDiameter > dMaxDiameter)
						dMaxDiameter = Caliber.MaxBulletDiameter;

					if (Caliber.MinBulletWeight < dMinWeight)
						dMinWeight = Caliber.MinBulletWeight;

					if (Caliber.MaxBulletWeight > dMaxWeight)
						dMaxWeight = Caliber.MaxBulletWeight;
					}
				}

			CaliberTextBox.MinValue = dMinDiameter;
			CaliberTextBox.MaxValue = dMaxDiameter;

			if (!CaliberTextBox.ValueOK)
				{
				CaliberTextBox.Value = CaliberTextBox.MinValue;

				m_StabilityData.BulletDiameter = m_DataFiles.MetricToStandard(CaliberTextBox.MinValue, cDataFiles.eDataType.Dimension);
				}

			if (CaliberTextBox.MinValue == CaliberTextBox.MaxValue)
				{
				CaliberTextBox.Enabled = false;

				m_StabilityData.BulletDiameter = m_DataFiles.MetricToStandard(CaliberTextBox.MinValue, cDataFiles.eDataType.Dimension);
				}
			else
				CaliberTextBox.Enabled = true;

			//----------------------------------------------------------------------------*
			// Set Weight Min/Max
			//----------------------------------------------------------------------------*

			if (Bullet != null)
				{
				WeightTextBox.MinValue = Bullet.Weight;
				WeightTextBox.MaxValue = Bullet.Weight;

				WeightTextBox.Enabled = false;
				}
			else
				{
				WeightTextBox.MinValue = dMinWeight;
				WeightTextBox.MaxValue = dMaxWeight;

				WeightTextBox.Enabled = true;
				}

			if (!WeightTextBox.ValueOK)
				{
				WeightTextBox.Value = WeightTextBox.MinValue;

				m_StabilityData.BulletWeight = m_DataFiles.MetricToStandard(WeightTextBox.Value, cDataFiles.eDataType.BulletWeight);
				}

			//----------------------------------------------------------------------------*
			// Set Length Min/Max
			//----------------------------------------------------------------------------*

			LengthTextBox.MinValue = m_DataFiles.StandardToMetric(0.050, cDataFiles.eDataType.Dimension);
			LengthTextBox.MaxValue = m_DataFiles.StandardToMetric(3.0, cDataFiles.eDataType.Dimension);

			LengthTextBox.Enabled = Bullet == null || Bullet.Length == 0.0;

			//----------------------------------------------------------------------------*
			// Set Ballistic Coefficient Min/Max
			//----------------------------------------------------------------------------*

			BallisticCoefficientTextBox.Enabled = (Bullet != null) ? false : true;

			//----------------------------------------------------------------------------*
			// Set Muzzle Velocity Min/Max
			//----------------------------------------------------------------------------*

			if (Load != null)
				{
				int nMinValue = (int) m_DataFiles.StandardToMetric(5000, cDataFiles.eDataType.Velocity);
				int nMaxValue = (int) m_DataFiles.StandardToMetric(500, cDataFiles.eDataType.Velocity);

				bool fTestFound = false;

				foreach (cCharge Charge in Load.ChargeList)
					{
					foreach (cChargeTest ChargeTest in Charge.TestList)
						{
						fTestFound = true;

						if (ChargeTest.MuzzleVelocity < nMinValue)
							nMinValue = ChargeTest.MuzzleVelocity;

						if (ChargeTest.MuzzleVelocity > nMaxValue)
							nMaxValue = ChargeTest.MuzzleVelocity;
						}
					}

				if (fTestFound)
					{
					VelocityTextBox.MinValue = nMinValue;
					VelocityTextBox.MaxValue = nMaxValue;
					}
				else
					{
					VelocityTextBox.MinValue = cm_nMinVelocity;
					VelocityTextBox.MaxValue = (int) m_DataFiles.StandardToMetric(5000, cDataFiles.eDataType.Velocity);
					}
				}
			else
				{
				VelocityTextBox.MinValue = (int) m_DataFiles.StandardToMetric(cm_nMinVelocity, cDataFiles.eDataType.Velocity);
				VelocityTextBox.MaxValue = (int) m_DataFiles.StandardToMetric(5000, cDataFiles.eDataType.Velocity);
				}

			if (!VelocityTextBox.ValueOK)
				{
				VelocityTextBox.Value = VelocityTextBox.MinValue;

				m_StabilityData.MuzzleVelocity = (int) m_DataFiles.MetricToStandard(VelocityTextBox.Value, cDataFiles.eDataType.Velocity);
				}

			//----------------------------------------------------------------------------*
			// Set Twist Min/Max
			//----------------------------------------------------------------------------*

			if (Firearm != null)
				{
				TwistTextBox.Enabled = false;
				}
			else
				{
				TwistTextBox.MinValue = m_DataFiles.StandardToMetric(5, cDataFiles.eDataType.Firearm);
				TwistTextBox.MaxValue = m_DataFiles.StandardToMetric(78, cDataFiles.eDataType.Firearm);

				TwistTextBox.Enabled = true;
				}
			}

		//============================================================================*
		// SetStabilityFactor()
		//============================================================================*

		private void SetStabilityFactor()
			{
			//----------------------------------------------------------------------------*
			// Set Stability Text
			//----------------------------------------------------------------------------*

			double dStabilityFactor = m_fCalculateOK ? m_StabilityData.StabilityFactor : 0.0;

			StabilityFactorLabel.Text = String.Format("Stability Factor (Sg) = {0:F2}", dStabilityFactor);

			BulletStabilityLabel.Visible = (Math.Round(dStabilityFactor, 2) > 0.0);

			if (dStabilityFactor < 1.0)
				{
				BulletStabilityLabel.Text = "This bullet is unstable!";
				}
			else
				{
				if (dStabilityFactor < 1.5)
					BulletStabilityLabel.Text = "This bullet is marginally stable.";
				else
					BulletStabilityLabel.Text = "This bullet is stable.";
				}

			//----------------------------------------------------------------------------*
			// Set Recommended Twist
			//----------------------------------------------------------------------------*

			if ((dStabilityFactor > 0.0 && dStabilityFactor < 1.5) || dStabilityFactor > 4.0)
				{
				RecommendedTwistLabel.Visible = true;

				string strFormat = "Recommended Twist: 1:{0:F";
				strFormat += String.Format("{0:G0}", m_DataFiles.Preferences.FirearmDecimals);
				strFormat += "} ";
				strFormat += m_DataFiles.MetricString(cDataFiles.eDataType.Firearm);

				RecommendedTwistLabel.Text = String.Format(strFormat, m_StabilityData.RecommendedTwist);
				}
			else
				RecommendedTwistLabel.Visible = false;

			//----------------------------------------------------------------------------*
			// Set BC Impact Info
			//----------------------------------------------------------------------------*

			if (dStabilityFactor > 0.0 && dStabilityFactor < 1.5)
				{
				ImpactGroup.Visible = true;

				BulletBCLabel.Text = String.Format("{0:F3}", m_StabilityData.BallisticCoefficient);

				CalculatedBCLabel.Text = String.Format("{0:F3}", m_StabilityData.AdjustedBC);

				DegradationLabel.Text = String.Format("{0:F0}%", m_StabilityData.BallisticCoefficient != 0.0 ? (1.0 - (m_StabilityData.AdjustedBC / m_StabilityData.BallisticCoefficient)) * 100.0 : 0.0);
				}
			else
				ImpactGroup.Visible = false;

			//----------------------------------------------------------------------------*
			// Set Arrow Position
			//----------------------------------------------------------------------------*

			if (dStabilityFactor > 4.0)
				ArrowPictureBox.Image = Properties.Resources.StabilityArrowRight;
			else
				ArrowPictureBox.Image = Properties.Resources.StabilityArrow;

			int nArrowStartX = StabilityPictureBox.Location.X - (ArrowPictureBox.Width / 2);

			int nY = StabilityPictureBox.Location.Y - ArrowPictureBox.Height;

			int nX = (int) (nArrowStartX + (dStabilityFactor * (StabilityPictureBox.Width / 4)));

			if (nX < nArrowStartX)
				nX = nArrowStartX;

			if (nX > nArrowStartX + StabilityPictureBox.Width)
				nX = nArrowStartX + StabilityPictureBox.Width;

			ArrowPictureBox.Location = new Point(nX, nY);
			}

		//============================================================================*
		// SetStaticToolTips()
		//============================================================================*

		private void SetStaticToolTips()
			{
			if (!m_DataFiles.Preferences.ToolTips)
				return;

			m_LoadToolTip.ShowAlways = true;
			m_LoadToolTip.RemoveAll();
			m_LoadToolTip.SetToolTip(LoadCombo, cm_strLoadToolTip);

			m_BulletToolTip.ShowAlways = true;
			m_BulletToolTip.RemoveAll();
			m_BulletToolTip.SetToolTip(BulletCombo, cm_strBulletToolTip);

			m_FirearmToolTip.ShowAlways = true;
			m_FirearmToolTip.RemoveAll();
			m_FirearmToolTip.SetToolTip(FirearmCombo, cm_strFirearmToolTip);

			LengthTextBox.ToolTip = cm_strLengthToolTip;
			CaliberTextBox.ToolTip = cm_strCaliberToolTip;
			WeightTextBox.ToolTip = cm_strWeightToolTip;

			TwistTextBox.ToolTip = cm_strTwistToolTip;
			VelocityTextBox.ToolTip = cm_strVelocityToolTip;

			TemperatureTextBox.ToolTip = cm_strTemperatureToolTip;
			PressureTextBox.ToolTip = cm_strPressureToolTip;
			}

		//============================================================================*
		// UpdateButtons()
		//============================================================================*

		private void UpdateButtons()
			{
			m_fCalculateOK = true;

			//----------------------------------------------------------------------------*
			// enable/disable Pressure/Altude TextBoxes
			//----------------------------------------------------------------------------*

			PressureTextBox.Enabled = !m_StabilityData.UseAltitude;
			TemperatureTextBox.Enabled = !m_StabilityData.UseAltitude;
			AltitudeTextBox.Enabled = m_StabilityData.UseAltitude;

			//----------------------------------------------------------------------------*
			// Check Text Box Data
			//----------------------------------------------------------------------------*

			if (!CaliberTextBox.ValueOK)
				m_fCalculateOK = false;

			if (!LengthTextBox.ValueOK)
				m_fCalculateOK = false;

			if (!WeightTextBox.ValueOK)
				m_fCalculateOK = false;

			if (!TwistTextBox.ValueOK)
				m_fCalculateOK = false;

			if (!VelocityTextBox.ValueOK)
				m_fCalculateOK = false;

			if (!TemperatureTextBox.ValueOK)
				m_fCalculateOK = false;

			if (!PressureTextBox.ValueOK)
				m_fCalculateOK = false;

			}
		}
	}
