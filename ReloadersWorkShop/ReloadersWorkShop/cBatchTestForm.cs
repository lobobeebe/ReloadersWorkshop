//============================================================================*
// cBatchTestForm.cs
//
// Copyright © 2013-2016, Kevin S. Beebe
// All Rights Reserved
//============================================================================*

//============================================================================*
// .Net Using Statements
//============================================================================*

using System;
using System.Drawing;
using System.Windows.Forms;

using RWCommonLib.Registry;

//============================================================================*
// NameSpace
//============================================================================*

namespace ReloadersWorkShop
	{
	//============================================================================*
	// cBatchTestForm Class
	//============================================================================*

	public partial class cBatchTestForm : Form
		{
		//----------------------------------------------------------------------------*
		// Private Const Data Members
		//----------------------------------------------------------------------------*

		private const string cm_strFirearmTypeToolTip = "Type of Firearm.";
		private const string cm_strCaliberComboToolTip = "Select the caliber of batches you wish to view.";
		private const string cm_strBatchComboToolTip = "Select the batch for which you wish to add test data.";

		private const string cm_strTestDateToolTip = "The date on which the test was conducted.";

		private const string cm_strLocationToolTip = "The location where this test was performed (name of range, my backyard, etc.).";
		private const string cm_strFirearmComboToolTip = "Select the firearm used for this test.";
		private const string cm_strNumTestShotsToolTip = "Enter the number of shots fired for this test.";
		private const string cm_strBestGroupToolTip = "Enter the best group size achieved for this test.";
		private const string cm_strBestGroupRangeToolTip = "The range at which the best group was achieved.";
		private const string cm_strTargetCalculatorToolTip = "Click to open the target calculator for precise measurement of group sizes.";
		private const string cm_strFavoriteLoadToolTip = "Check if this is one of your favorite loads.";
		private const string cm_strRejectLoadToolTip = "Check if this load should go to the reject pile.";
		private const string cm_strNotesToolTip = "Enter any notes you may have regarding this batch and/or load.";

		private const string cm_strShotListToolTip = "A list of the shots fired for this test.";

		private const string cm_strEditShotsToolTip = "Click to edit/view the shots fired for this test.";

		private const string cm_strBatchTestOKButtonToolTip = "Click to add or update the batch test with the above data.";
		private const string cm_strBatchTestDeleteButtonToolTip = "Click to delete the above batch test data from the batch.";
		private const string cm_strBatchTestCancelButtonToolTip = "Click to cancel changes and return to the main window.";

		//----------------------------------------------------------------------------*
		// Private Data Members
		//----------------------------------------------------------------------------*

		private cBatchTest m_BatchTest = null;
		private cDataFiles m_DataFiles = null;
        private cRWRegistry m_RWRegistry = null;

		private bool m_fViewOnly = false;
		private bool m_fInitialized = false;
		private bool m_fPopulating = false;

		private bool m_fChanged = false;

		private ToolTip m_TestDateToolTip = new ToolTip();
		private ToolTip m_FirearmTypeToolTip = new ToolTip();
		private ToolTip m_CaliberComboToolTip = new ToolTip();
		private ToolTip m_BatchComboToolTip = new ToolTip();

		private ToolTip m_FirearmComboToolTip = new ToolTip();
		private ToolTip m_LocationToolTip = new ToolTip();
		private ToolTip m_NumTestShotsToolTip = new ToolTip();
		private ToolTip m_BestGroupToolTip = new ToolTip();
		private ToolTip m_BestGroupRangeToolTip = new ToolTip();
		private ToolTip m_TargetCalculatorToolTip = new ToolTip();
		private ToolTip m_FavoriteLoadToolTip = new ToolTip();
		private ToolTip m_RejectLoadToolTip = new ToolTip();
		private ToolTip m_NotesToolTip = new ToolTip();
		private ToolTip m_ShotListToolTip = new ToolTip();
		private ToolTip m_EditShotsToolTip = new ToolTip();
		private ToolTip m_BatchTestOKButtonToolTip = new ToolTip();
		private ToolTip m_BatchTestCancelButtonToolTip = new ToolTip();

		//============================================================================*
		// cBatchTestForm() - Constructor
		//============================================================================*

		public cBatchTestForm(cBatch Batch, cDataFiles DataFiles, cRWRegistry RWRegistry, bool fViewOnly = false)
			{
			InitializeComponent();

			m_DataFiles = DataFiles;
            m_RWRegistry = RWRegistry;
            m_fViewOnly = fViewOnly;

			string strTitle = "";

			if (Batch.BatchTest == null)
				{
				m_BatchTest = new cBatchTest();
				m_BatchTest.Batch = Batch;
				m_BatchTest.Firearm = Batch.Firearm;
				m_BatchTest.TestDate = DateTime.Today;

				m_BatchTest.Temperature = 59;
				m_BatchTest.Altitude = 0;
				m_BatchTest.BarometricPressure = 29.92;
				m_BatchTest.Humidity = 0.78;

				strTitle = "Add";

				BatchTestOKButton.Text = "Add";
				BatchTestDeleteButton.Enabled = false;
				}
			else
				{
				m_BatchTest = new cBatchTest(Batch.BatchTest);

				if (!m_fViewOnly)
					{
					strTitle = "Edit";

					BatchTestOKButton.Text = "Update";
					}
				else
					{
					BatchTestCancelButton.Text = "Close";
					BatchTestDeleteButton.Visible = false;
					BatchTestOKButton.Visible = false;

					int nButtonX = (this.Size.Width / 2) - (BatchTestCancelButton.Width / 2);

					BatchTestCancelButton.Location = new Point(nButtonX, BatchTestCancelButton.Location.Y);

					strTitle = "View";
					}
				}

			SetClientSizeCore(BatchDataGroupBox.Location.X + BatchDataGroupBox.Width + 10, BatchTestCancelButton.Location.Y + BatchTestCancelButton.Height + 20);

			//----------------------------------------------------------------------------*
			// Set Title
			//----------------------------------------------------------------------------*

			strTitle += " Batch Test";

			Text = strTitle;

			//----------------------------------------------------------------------------*
			// Event Handlers
			//----------------------------------------------------------------------------*

			if (!m_fViewOnly && !m_BatchTest.Batch.Archived)
				{
				TestDatePicker.TextChanged += OnDateChanged;

				FirearmCombo.SelectedIndexChanged += OnFirearmChanged;

				LocationTextBox.TextChanged += OnLocationTextChanged;

				SuppressedCheckBox.Click += OnSuppressedClicked;

				TemperatureTextBox.TextChanged += OnTemperatureChanged;
				AltitudeTextBox.TextChanged += OnAltitudeChanged;
				PressureTextBox.TextChanged += OnBarometricPressureChanged;
				HumidityTextBox.TextChanged += OnHumidityChanged;

				WindSpeedTextBox.TextChanged += OnWindSpeedChanged;
				WindDirectionTextBox.TextChanged += OnWindDirectionChanged;

				NumShotsTextBox.TextChanged += OnNumShotsTextChanged;

				BestGroupTextBox.TextChanged += OnBestGroupChanged;

				NotesTextBox.TextChanged += OnNotesChanged;

				BestGroupRangeTextBox.TextChanged += OnBestGroupRangeChanged;

				TargetCalculatorButton.Click += OnTargetCalculatorClicked;

				FavoriteLoadRadioButton.Click += OnFavoriteLoadClicked;
				RejectLoadRadioButton.Click += OnRejectLoadClicked;

				BatchTestOKButton.Click += OnOKClicked;
				}
			else
				{
				NumShotsTextBox.ReadOnly = true;
				BestGroupTextBox.ReadOnly = true;
				BestGroupRangeTextBox.ReadOnly = true;

				NotesTextBox.ReadOnly = true;
				}

			EditShotsButton.Click += OnEditShotsClicked;

			//----------------------------------------------------------------------------*
			// Set Decimals
			//----------------------------------------------------------------------------*

			SetInputParameters();

			//----------------------------------------------------------------------------*
			// Populate Form Data
			//----------------------------------------------------------------------------*

			SetStaticToolTips();

			BatchIDLabel.Text = String.Format("{0:G0}", m_BatchTest.Batch.BatchID);

			if (m_BatchTest.Batch.Archived)
				BatchIDLabel.Text += " - Archived";

			DateLoadedLabel.Text = m_BatchTest.Batch.DateLoaded.ToShortDateString();
			CaliberLabel.Text = m_BatchTest.Batch.Load.Caliber.ToString();
			LoadLabel.Text = m_BatchTest.Batch.Load.ToShortString();
			ChargeLabel.Text = String.Format("{0:F1}", m_BatchTest.Batch.PowderWeight);
			NumRoundsLabel.Text = String.Format("{0:G0}", m_BatchTest.Batch.NumRounds);

			switch (m_BatchTest.Batch.Load.FirearmType)
				{
				case cFirearm.eFireArmType.Handgun:
					FirearmTypeLabel.Text = "Handgun";
					break;
				case cFirearm.eFireArmType.Rifle:
					FirearmTypeLabel.Text = "Rifle";
					break;
				case cFirearm.eFireArmType.Shotgun:
					FirearmTypeLabel.Text = "Shotgun";
					break;
				}

			PopulateBatchTestData();
			PopulateShotList();

			m_fInitialized = true;

			UpdateButtons();
			}

		//============================================================================*
		// BatchTest Property
		//============================================================================*

		public cBatchTest BatchTest
			{
			get { return (m_BatchTest); }
			}

		//============================================================================*
		// OnAltitudeChanged()
		//============================================================================*

		public void OnAltitudeChanged(object sender, EventArgs args)
			{
			if (!m_fInitialized || m_fPopulating)
				return;

			m_BatchTest.Altitude = (int) m_DataFiles.MetricToStandard(AltitudeTextBox.Value, cDataFiles.eDataType.Altitude);

			SetStationData();

			m_fChanged = true;

			UpdateButtons();
			}

		//============================================================================*
		// OnBarometricPressureChanged()
		//============================================================================*

		public void OnBarometricPressureChanged(object sender, EventArgs args)
			{
			if (!m_fInitialized || m_fPopulating)
				return;

			m_BatchTest.BarometricPressure = m_DataFiles.MetricToStandard(PressureTextBox.Value, cDataFiles.eDataType.Pressure);

			SetStationData();

			m_fChanged = true;

			UpdateButtons();
			}

		//============================================================================*
		// OnBestGroupChanged()
		//============================================================================*

		public void OnBestGroupChanged(object sender, EventArgs args)
			{
			if (!m_fInitialized || m_fPopulating)
				return;

			m_BatchTest.BestGroup = m_DataFiles.MetricToStandard(BestGroupTextBox.Value, cDataFiles.eDataType.GroupSize);

			m_fChanged = true;

			UpdateButtons();
			}

		//============================================================================*
		// OnBestGroupRangeChanged()
		//============================================================================*

		public void OnBestGroupRangeChanged(object sender, EventArgs args)
			{
			if (!m_fInitialized || m_fPopulating)
				return;

			m_BatchTest.BestGroupRange = (int) m_DataFiles.MetricToStandard(BestGroupRangeTextBox.Value, cDataFiles.eDataType.Range);

			m_fChanged = true;

			UpdateButtons();
			}

		//============================================================================*
		// OnDateChanged()
		//============================================================================*

		private void OnDateChanged(object sender, EventArgs e)
			{
			if (!m_fInitialized || m_fPopulating)
				return;

			m_BatchTest.TestDate = TestDatePicker.Value;

			m_fChanged = true;

			UpdateButtons();
			}

		//============================================================================*
		// OnEditShotsClicked()
		//============================================================================*

		public void OnEditShotsClicked(object sender, EventArgs args)
			{
            cTestShotForm TestShotform = new cTestShotForm(m_DataFiles, NumShotsTextBox.Value, m_BatchTest.TestShotList, m_BatchTest.Batch.NumRounds, m_fViewOnly);

			TestShotform.Initialize();

			if (TestShotform.ShowDialog() == DialogResult.OK)
				{
				m_BatchTest.TestShotList = new cTestShotList(TestShotform.TestShotList);

				PopulateShotList();

				m_fChanged = true;

				UpdateButtons();
				}
			}

		//============================================================================*
		// OnFavoriteLoadClicked()
		//============================================================================*

		public void OnFavoriteLoadClicked(object sender, EventArgs args)
			{
			FavoriteLoadRadioButton.Checked = FavoriteLoadRadioButton.Checked ? false : true;

			if (FavoriteLoadRadioButton.Checked)
				RejectLoadRadioButton.Checked = false;

			m_fChanged = true;

			UpdateButtons();
			}

		//============================================================================*
		// OnFirearmChanged()
		//============================================================================*

		public void OnFirearmChanged(object sender, EventArgs args)
			{
			if (!m_fInitialized || m_fPopulating)
				return;

			m_BatchTest.Firearm = (cFirearm) FirearmCombo.SelectedItem;

			PopulateBatchTestData();

			m_fChanged = true;

			UpdateButtons();
			}

		//============================================================================*
		// OnHumidityChanged()
		//============================================================================*

		public void OnHumidityChanged(object sender, EventArgs args)
			{
			if (!m_fInitialized || m_fPopulating)
				return;

			m_BatchTest.Humidity = (double)  ((double) HumidityTextBox.Value / 100.0);

			SetStationData();

			m_fChanged = true;

			UpdateButtons();
			}

		//============================================================================*
		// OnLocationTextChanged()
		//============================================================================*

		private void OnLocationTextChanged(object sender, EventArgs e)
			{
			if (!m_fInitialized || m_fPopulating)
				return;

			m_BatchTest.Location = LocationTextBox.Value;

			m_fChanged = true;

			UpdateButtons();
			}

		//============================================================================*
		// OnNotesChanged()
		//============================================================================*

		public void OnNotesChanged(object sender, EventArgs args)
			{
			if (!m_fInitialized || m_fPopulating)
				return;

			m_BatchTest.Notes = NotesTextBox.Text;

			m_fChanged = true;

			UpdateButtons();
			}

		//============================================================================*
		// OnNumShotsTextChanged()
		//============================================================================*

		private void OnNumShotsTextChanged(object sender, EventArgs e)
			{
			if (!m_fInitialized || m_fPopulating)
				return;

			int nNumShots = NumShotsTextBox.Value;

			if (nNumShots < 0)
				{
				nNumShots = 0;

				(sender as TextBox).Text = "0";
				}

			if (nNumShots != m_BatchTest.TestShotList.Count)
				{
				if (nNumShots == 0)
					m_BatchTest.TestShotList.Clear();
				else
					{

					while (nNumShots > m_BatchTest.TestShotList.Count)
						m_BatchTest.TestShotList.Add(new cTestShot());

					while (nNumShots < m_BatchTest.TestShotList.Count)
						m_BatchTest.TestShotList.RemoveAt(m_BatchTest.TestShotList.Count - 1);
					}

				PopulateShotList();
				}

			m_BatchTest.NumRounds = NumShotsTextBox.Value;

			m_fChanged = true;

			UpdateButtons();
			}

		//============================================================================*
		// OnOKClicked()
		//============================================================================*

		public void OnOKClicked(object sender, EventArgs args)
			{
			string strTestSource = String.Format("Batch #{0:G} Testing", m_BatchTest.Batch.BatchID);

			foreach (cCharge Charge in m_BatchTest.Batch.Load.ChargeList)
				{
				if (Charge.PowderWeight == m_BatchTest.Batch.PowderWeight)
					{
					Charge.Favorite = FavoriteLoadRadioButton.Checked;
					Charge.Reject = RejectLoadRadioButton.Checked;

					cChargeTest ChargeTest = null;

					foreach (cChargeTest CheckChargeTest in Charge.TestList)
						{
						if (CheckChargeTest.BatchID == m_BatchTest.Batch.BatchID)
							{
							ChargeTest = CheckChargeTest;

							break;
							}
						}

					if (ChargeTest == null)
						{
						ChargeTest = new cChargeTest();

						Charge.TestList.Add(ChargeTest);
						}

					ChargeTest.TestDate = TestDatePicker.Value;
					ChargeTest.Firearm = m_BatchTest.Firearm;

					ChargeTest.Source = strTestSource;

					ChargeTest.BarrelLength = m_BatchTest.Firearm.BarrelLength;
					ChargeTest.Twist = m_BatchTest.Firearm.Twist;

					ChargeTest.BestGroup = m_BatchTest.BestGroup;
					ChargeTest.BestGroupRange = m_BatchTest.BestGroupRange;

					ChargeTest.MuzzleVelocity = m_BatchTest.MuzzleVelocity;
					ChargeTest.Pressure = m_BatchTest.Pressure;

					ChargeTest.Notes = m_BatchTest.Notes;
					ChargeTest.BatchTest = true;
					ChargeTest.BatchID = m_BatchTest.Batch.BatchID;
					}
				}

			while (m_BatchTest.TestShotList.Count > 0 && m_BatchTest.NumRounds < m_BatchTest.TestShotList.Count)
				m_BatchTest.TestShotList.RemoveAt(m_BatchTest.TestShotList.Count - 1);
			}

		//============================================================================*
		// OnRejectLoadClicked()
		//============================================================================*

		public void OnRejectLoadClicked(object sender, EventArgs args)
			{
			RejectLoadRadioButton.Checked = RejectLoadRadioButton.Checked ? false : true;

			if (RejectLoadRadioButton.Checked)
				FavoriteLoadRadioButton.Checked = false;

			m_fChanged = true;

			UpdateButtons();
			}

		//============================================================================*
		// OnSuppressedClicked()
		//============================================================================*

		public void OnSuppressedClicked(object sender, EventArgs args)
			{
			SuppressedCheckBox.Checked = !SuppressedCheckBox.Checked;

			m_BatchTest.Suppressed = SuppressedCheckBox.Checked;

			m_fChanged = true;

			UpdateButtons();
			}

		//============================================================================*
		// OnTargetCalculatorClicked()
		//============================================================================*

		public void OnTargetCalculatorClicked(object sender, EventArgs args)
			{
			cTargetCalculatorForm TargetCalculatorForm = new cTargetCalculatorForm(m_DataFiles, m_RWRegistry, m_BatchTest);

			if (TargetCalculatorForm.ShowDialog() == DialogResult.OK)
				{
				m_BatchTest.TestDate = TargetCalculatorForm.Target.Date;
				m_BatchTest.NumRounds = TargetCalculatorForm.Target.NumShots;
				m_BatchTest.BestGroup = TargetCalculatorForm.Target.GroupSize;
				m_BatchTest.BestGroupRange = TargetCalculatorForm.Target.Range;
				m_BatchTest.Location = TargetCalculatorForm.Target.Location;
				m_BatchTest.Firearm = TargetCalculatorForm.Target.Firearm;

				TestDatePicker.Value = m_BatchTest.TestDate;
				BestGroupTextBox.Value = m_BatchTest.BestGroup;
				BestGroupRangeTextBox.Value = m_BatchTest.BestGroupRange;
				NumShotsTextBox.Value = m_BatchTest.NumRounds;
				LocationTextBox.Value = m_BatchTest.Location;

				FirearmCombo.SelectedItem = m_BatchTest.Firearm;

				OnNumShotsTextChanged(sender, args);
				}
			}

		//============================================================================*
		// OnTemperatureChanged()
		//============================================================================*

		public void OnTemperatureChanged(object sender, EventArgs args)
			{
			if (!m_fInitialized || m_fPopulating)
				return;

			m_BatchTest.Temperature = (int) m_DataFiles.MetricToStandard(TemperatureTextBox.Value, cDataFiles.eDataType.Temperature);

			SetStationData();

			m_fChanged = true;

			UpdateButtons();
			}

		//============================================================================*
		// OnWindDirectionChanged()
		//============================================================================*

		public void OnWindDirectionChanged(object sender, EventArgs args)
			{
			if (!m_fInitialized || m_fPopulating)
				return;

			m_BatchTest.WindDirection = WindDirectionTextBox.Value;

			SetStationData();

			m_fChanged = true;

			UpdateButtons();
			}

		//============================================================================*
		// OnWindSpeedChanged()
		//============================================================================*

		public void OnWindSpeedChanged(object sender, EventArgs args)
			{
			if (!m_fInitialized || m_fPopulating)
				return;

			m_BatchTest.WindSpeed = (int) m_DataFiles.MetricToStandard(WindSpeedTextBox.Value, cDataFiles.eDataType.Speed);

			SetStationData();

			m_fChanged = true;

			UpdateButtons();
			}

		//============================================================================*
		// PopulateBatchTestData()
		//============================================================================*

		public void PopulateBatchTestData()
			{
			m_fPopulating = true;

			cFirearm Firearm = m_BatchTest.Firearm;

			if (Firearm == null)
				Firearm = m_BatchTest.Batch.Firearm;

			if (m_fViewOnly)
				{
				FirearmCombo.Items.Add(Firearm);

				FirearmCombo.SelectedIndex = 0;
				}
			else
				cControls.PopulateFirearmCombo(FirearmCombo, m_DataFiles, Firearm, m_BatchTest.Batch.Load.Caliber, m_BatchTest.Batch.Load.FirearmType);

			if (m_BatchTest.Firearm == null)
				m_BatchTest.Firearm = (cFirearm) FirearmCombo.SelectedItem;

			TestDatePicker.Value = m_BatchTest.TestDate;

			if (m_BatchTest.Firearm != null)
				{
				string strFormat = "{0:F";
				strFormat += String.Format("{0:G0}", m_DataFiles.Preferences.FirearmDecimals);
				strFormat += "} {1}";

				BarrelLengthLabel.Text = String.Format(strFormat, m_BatchTest.Firearm.BarrelLength, m_DataFiles.MetricString(cDataFiles.eDataType.Firearm));

				strFormat = "1 in {0:F";
				strFormat += String.Format("{0:G0}", m_DataFiles.Preferences.FirearmDecimals);
				strFormat += "} {1}";

				TwistLabel.Text = String.Format(strFormat, m_BatchTest.Firearm.Twist, m_DataFiles.MetricString(cDataFiles.eDataType.Firearm));
				}
			else
				{
				BarrelLengthLabel.Text = "";
				TwistLabel.Text = "";
				}

			SuppressedCheckBox.Checked = m_BatchTest.Suppressed;

			LocationTextBox.Value = m_BatchTest.Location;
			TemperatureMeasurementLabel.Text = m_DataFiles.MetricString(cDataFiles.eDataType.Temperature);
			TemperatureTextBox.Value = (int) m_DataFiles.StandardToMetric(m_BatchTest.Temperature, cDataFiles.eDataType.Temperature);
			PressureMeasurementLabel.Text = m_DataFiles.MetricString(cDataFiles.eDataType.Pressure);
			PressureTextBox.Value = m_DataFiles.StandardToMetric(m_BatchTest.BarometricPressure, cDataFiles.eDataType.Pressure);
			AltitudeMeasurementLabel.Text = m_DataFiles.MetricString(cDataFiles.eDataType.Altitude);
			AltitudeTextBox.Value = (int) m_DataFiles.StandardToMetric(m_BatchTest.Altitude, cDataFiles.eDataType.Altitude);
			HumidityTextBox.Value = (int) (m_BatchTest.Humidity * 100.0);

			WindSpeedMeasurementLabel.Text = m_DataFiles.MetricString(cDataFiles.eDataType.Speed);
			WindSpeedTextBox.Value = (int) m_DataFiles.StandardToMetric(m_BatchTest.WindSpeed, cDataFiles.eDataType.Speed);

			WindDirectionTextBox.Value = m_BatchTest.WindDirection;

			SetStationData();

			NumShotsTextBox.Value = m_BatchTest.NumRounds;
			BestGroupTextBox.Value = m_DataFiles.StandardToMetric(m_BatchTest.BestGroup, cDataFiles.eDataType.GroupSize);
			BestGroupRangeTextBox.Value = (int) m_DataFiles.StandardToMetric(m_BatchTest.BestGroupRange, cDataFiles.eDataType.Range);

			BestGroupDistanceLabel.Text = m_DataFiles.MetricString(cDataFiles.eDataType.GroupSize);
			BestGroupRangeDistanceLabel.Text = m_DataFiles.MetricString(cDataFiles.eDataType.Range);

			BestGroupDistanceLabel.Text = m_DataFiles.Preferences.MetricGroups ? "cm" : "in";
			BestGroupRangeDistanceLabel.Text = m_DataFiles.Preferences.MetricRanges ? "m" : "yds";

			FavoriteLoadRadioButton.Checked = false;

			if (m_BatchTest.Batch != null && m_BatchTest.Batch.Load != null)
				{
				foreach (cCharge Charge in m_BatchTest.Batch.Load.ChargeList)
					{
					if (Charge.PowderWeight == m_BatchTest.Batch.PowderWeight)
						{
						FavoriteLoadRadioButton.Checked = Charge.Favorite;
						RejectLoadRadioButton.Checked = Charge.Reject;

						break;
						}
					}
				}

			NotesTextBox.Text = m_BatchTest.Notes;

			m_fPopulating = false;
			}

		//============================================================================*
		// PopulateShotList()
		//============================================================================*

		public void PopulateShotList()
			{
			int nShot = 1;

			int nNumShots = NumShotsTextBox.Value;

			ShotListView.Items.Clear();

			foreach (cTestShot TestShot in m_BatchTest.TestShotList)
				{
				if (nShot > nNumShots)
					break;

				ListViewItem Item = new ListViewItem(String.Format("{0:N0}", nShot++));

				Item.Tag = TestShot;

				Item.SubItems.Add(String.Format("{0:N0}", m_DataFiles.StandardToMetric(TestShot.MuzzleVelocity, cDataFiles.eDataType.Velocity)));
				Item.SubItems.Add(String.Format("{0:N0}", m_DataFiles.StandardToMetric(TestShot.Pressure, cDataFiles.eDataType.Pressure)));

				Item.SubItems.Add(TestShot.Misfire ? "Y" : "N");
				Item.SubItems.Add(TestShot.Squib ? "Y" : "N");

				ShotListView.Items.Add(Item);
				}
			}

		//============================================================================*
		// SetInputParameters()
		//============================================================================*

		private void SetInputParameters()
			{
			m_DataFiles.SetInputParameters(BestGroupTextBox, cDataFiles.eDataType.GroupSize);
			m_DataFiles.SetInputParameters(PressureTextBox, cDataFiles.eDataType.Pressure);
			}

		//============================================================================*
		// SetStaticToolTips()
		//============================================================================*

		private void SetStaticToolTips()
			{
			if (!m_DataFiles.Preferences.ToolTips)
				return;

			m_FirearmComboToolTip.ShowAlways = true;
			m_FirearmComboToolTip.RemoveAll();
			m_FirearmComboToolTip.SetToolTip(FirearmCombo, cm_strFirearmComboToolTip);

			LocationTextBox.ToolTip = cm_strLocationToolTip;
			NumShotsTextBox.ToolTip = cm_strNumTestShotsToolTip;
			BestGroupTextBox.ToolTip = cm_strBestGroupToolTip;
			BestGroupRangeTextBox.ToolTip = cm_strBestGroupRangeToolTip;

			m_TargetCalculatorToolTip.ShowAlways = true;
			m_TargetCalculatorToolTip.RemoveAll();
			m_TargetCalculatorToolTip.SetToolTip(TargetCalculatorButton, cm_strTargetCalculatorToolTip);

			m_FavoriteLoadToolTip.ShowAlways = true;
			m_FavoriteLoadToolTip.RemoveAll();
			m_FavoriteLoadToolTip.SetToolTip(FavoriteLoadRadioButton, cm_strFavoriteLoadToolTip);

			m_RejectLoadToolTip.ShowAlways = true;
			m_RejectLoadToolTip.RemoveAll();
			m_RejectLoadToolTip.SetToolTip(RejectLoadRadioButton, cm_strRejectLoadToolTip);

			m_NotesToolTip.ShowAlways = true;
			m_NotesToolTip.RemoveAll();
			m_NotesToolTip.SetToolTip(NotesTextBox, cm_strNotesToolTip);

			m_ShotListToolTip.ShowAlways = true;
			m_ShotListToolTip.RemoveAll();
			m_ShotListToolTip.SetToolTip(ShotListView, cm_strShotListToolTip);

			m_EditShotsToolTip.ShowAlways = true;
			m_EditShotsToolTip.RemoveAll();
			m_EditShotsToolTip.SetToolTip(EditShotsButton, cm_strEditShotsToolTip);

			m_BatchTestOKButtonToolTip.ShowAlways = true;
			m_BatchTestOKButtonToolTip.RemoveAll();
			m_BatchTestOKButtonToolTip.SetToolTip(BatchTestOKButton, cm_strBatchTestOKButtonToolTip);

			m_BatchTestCancelButtonToolTip.ShowAlways = true;
			m_BatchTestCancelButtonToolTip.RemoveAll();
			m_BatchTestCancelButtonToolTip.SetToolTip(BatchTestCancelButton, cm_strBatchTestCancelButtonToolTip);
			}

		//============================================================================*
		// SetStationData()
		//============================================================================*

		private void SetStationData()
			{
			HeadwindLabel.Text = String.Format("{0:F1} {1}", m_DataFiles.StandardToMetric(m_BatchTest.HeadWind, cDataFiles.eDataType.Speed), m_DataFiles.MetricString(cDataFiles.eDataType.Speed));
			CrosswindLabel.Text = String.Format("{0:F1} {1}", m_DataFiles.StandardToMetric(m_BatchTest.CrossWind, cDataFiles.eDataType.Speed), m_DataFiles.MetricString(cDataFiles.eDataType.Speed));

			DensityAltitudeLabel.Text = String.Format("{0:G0} {1}", m_DataFiles.StandardToMetric(m_BatchTest.DensityAltitude, cDataFiles.eDataType.Altitude), m_DataFiles.MetricString(cDataFiles.eDataType.Altitude));
			StationPressureLabel.Text = String.Format("{0:F2} {1}", m_DataFiles.StandardToMetric(m_BatchTest.StationPressure, cDataFiles.eDataType.Pressure), m_DataFiles.MetricString(cDataFiles.eDataType.Pressure));
			}

		//============================================================================*
		// UpdateButtons()
		//============================================================================*

		private void UpdateButtons()
			{
			if (!m_fInitialized)
				return;

			bool fOKEnabled = m_fChanged;

			//----------------------------------------------------------------------------*
			// Get Values
			//----------------------------------------------------------------------------*

			int nNumShots = NumShotsTextBox.Value;
			double dBestGroup = BestGroupTextBox.Value;
			int nBestGroupRange = BestGroupRangeTextBox.Value;

			//----------------------------------------------------------------------------*
			// Test Date
			//----------------------------------------------------------------------------*

			DateTime TestDate = m_BatchTest.TestDate;

			if (TestDate < m_BatchTest.Batch.DateLoaded)
				{
				TestDatePicker.DateBackColor = Color.LightPink;

				BadDateLabel.Visible = true;

				fOKEnabled = false;
				}
			else
				{
				TestDatePicker.DateBackColor = Control.DefaultBackColor;

				BadDateLabel.Visible = false;
				}

			//----------------------------------------------------------------------------*
			// Num Shots Fired
			//----------------------------------------------------------------------------*

			string strText = cm_strNumTestShotsToolTip;

			if (nNumShots <= 0 || (m_BatchTest.Batch == null || nNumShots > m_BatchTest.Batch.NumRounds))
				{
				fOKEnabled = false;

				strText += String.Format("\n\nValue must be between one (1) and {0}, inclusive.", m_BatchTest.Batch.NumRounds);

				NumShotsTextBox.BackColor = Color.LightPink;
				}
			else
				{
				if (dBestGroup > 0.0 && nNumShots == 0)
					{
					fOKEnabled = false;

					strText += "\n\nYou must enter the number of shots fired to achieve the best group specified.";

					NumShotsTextBox.BackColor = Color.LightPink;
					}
				else
					NumShotsTextBox.BackColor = SystemColors.Window;
				}

			if (m_DataFiles.Preferences.ToolTips)
				m_NumTestShotsToolTip.SetToolTip(NumShotsTextBox, strText);

			//----------------------------------------------------------------------------*
			// Best Group
			//----------------------------------------------------------------------------*

			strText = cm_strBestGroupToolTip;

			if (dBestGroup <= 0.0)
				{
				fOKEnabled = false;

				strText += "\n\nValue must be greater than zero (0).";

				BestGroupTextBox.BackColor = Color.LightPink;
				}
			else
				{
				if (dBestGroup == 0.0 && nNumShots > 0)
					{
					fOKEnabled = false;

					strText += String.Format("\n\nYou must enter the best group achieved with the {0} test shots specified.", nNumShots);

					BestGroupTextBox.BackColor = Color.LightPink;
					}
				else
					BestGroupTextBox.BackColor = SystemColors.Window;
				}

			if (m_DataFiles.Preferences.ToolTips)
				m_BestGroupToolTip.SetToolTip(BestGroupTextBox, strText);

			//----------------------------------------------------------------------------*
			// Best Group Range
			//----------------------------------------------------------------------------*

			strText = cm_strBestGroupRangeToolTip;

			if (nBestGroupRange <= 0)
				{
				fOKEnabled = false;

				strText += "\n\nValue must be greater than zero (0).";

				BestGroupRangeTextBox.BackColor = Color.LightPink;
				}
			else
				{
				if (nBestGroupRange == 0 && (dBestGroup > 0.0 || nNumShots > 0))
					{
					fOKEnabled = false;

					strText += "\n\nYou must enter the range, in yards, at which the best group indicated was achieved";

					BestGroupRangeTextBox.BackColor = Color.LightPink;
					}
				else
					BestGroupRangeTextBox.BackColor = SystemColors.Window;
				}

			if (m_DataFiles.Preferences.ToolTips)
				m_BestGroupRangeToolTip.SetToolTip(BestGroupRangeTextBox, strText);

			//----------------------------------------------------------------------------*
			// Shot List
			//----------------------------------------------------------------------------*

			strText = cm_strShotListToolTip;

			if (ShotListView.Items.Count == 0 || nNumShots != ShotListView.Items.Count)
				{
				fOKEnabled = false;

				strText += "\n\nList must contain a record for each test shot fired.";

				ShotListView.BackColor = Color.LightPink;

				EditShotsButton.Enabled = false;
				}
			else
				{
				ShotListView.BackColor = SystemColors.Window;

				EditShotsButton.Enabled = true;
				}

			if (m_DataFiles.Preferences.ToolTips)
				m_ShotListToolTip.SetToolTip(ShotListView, strText);

			//----------------------------------------------------------------------------*
			// Set Buttons
			//----------------------------------------------------------------------------*

			BatchTestOKButton.Enabled = fOKEnabled;
			}
		}
	}
