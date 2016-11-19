//============================================================================*
// cChargeTestForm.cs
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

using ReloadersWorkShop.Preferences;

//============================================================================*
// NameSpace
//============================================================================*

namespace ReloadersWorkShop
	{
	//============================================================================*
	// cChargeTestForm Class
	//============================================================================*

	public partial class cChargeTestForm : Form
		{
		//----------------------------------------------------------------------------*
		// Private Constant Data Members
		//----------------------------------------------------------------------------*

		private const string cm_strTestDateToolTip = "Date test was conducted.  If this is factory data, just use today's date.";

		private const string cm_strSourceToolTip = "Source for this charge test data.";
		private const string cm_strFirearmToolTip = "Firearm used for this charge test.  If source is factory load data, select 'Factory'.";

		private const string cm_strBarrelLengthToolTip = "Barrel length of test firearm.";
		private const string cm_strTwistToolTip = "Twist rate of test firearm's bore.";

		private const string cm_strMuzzleVelocityToolTip = "Muzzle Velocity produced by this charge (if unknown, leave at zero (0)).";
		private const string cm_strPressureToolTip = "Pressure produced by this charge (if unknown leave at zero (0)).";

		private const string cm_strBestGroupToolTip = "Best grouping, in inches, achieved with this charge.";
		private const string cm_strBestGroupRangeToolTip = "Range, in yards, at which the indicated best group was achieved.";

		private const string cm_strNotesToolTip = "Notes regarding this charge test.";

		private const string cm_strChargeTestOKButtonToolTip = "Click to add or update the charge test with the above data.";
		private const string cm_strChargeTestCancelButtonToolTip = "Click to cancel changes and return to the main window.";

		//----------------------------------------------------------------------------*
		// Private Data Members
		//----------------------------------------------------------------------------*

		private cChargeTest m_ChargeTest;
		private cDataFiles m_DataFiles;

		private cLoad m_Load;

		private ToolTip m_TestDateToolTip = new ToolTip();
		private ToolTip m_SourceToolTip = new ToolTip();
		private ToolTip m_FirearmToolTip = new ToolTip();
		private ToolTip m_BarrelLengthToolTip = new ToolTip();
		private ToolTip m_TwistToolTip = new ToolTip();

		private ToolTip m_MuzzleVelocityToolTip = new ToolTip();
		private ToolTip m_PressureToolTip = new ToolTip();
		private ToolTip m_BestGroupToolTip = new ToolTip();
		private ToolTip m_BestGroupRangeToolTip = new ToolTip();

		private ToolTip m_NotesToolTip = new ToolTip();

		private ToolTip m_ChargeTestOKButtonToolTip = new ToolTip();
		private ToolTip m_ChargeTestCancelButtonToolTip = new ToolTip();

		//============================================================================*
		// cChargeTestForm() - Constructor
		//============================================================================*

		public cChargeTestForm(cChargeTest ChargeTest, cLoad Load, cDataFiles DataFiles)
			{
			InitializeComponent();

			m_Load = Load;
			m_DataFiles = DataFiles;

			if (ChargeTest == null)
				{
				if (m_DataFiles.Preferences.LastChargeTest != null)
					{
					m_ChargeTest = new cChargeTest(m_DataFiles.Preferences.LastChargeTest);

					m_ChargeTest.TestDate = DateTime.Today;
					m_ChargeTest.MuzzleVelocity = 0;
					m_ChargeTest.Pressure = 0;
					m_ChargeTest.BestGroup = 0.0;
					m_ChargeTest.BestGroupRange = 0;
					m_ChargeTest.Notes = "";
					}
				else
					m_ChargeTest = new cChargeTest();

				ChargeTestOKButton.Text = "Add";
				}
			else
				{
				m_ChargeTest = new cChargeTest(ChargeTest);

				ChargeTestOKButton.Text = "Update";
				}

			SetClientSizeCore(TestGroupBox.Location.X + TestGroupBox.Width + 10, ChargeTestCancelButton.Location.Y + ChargeTestCancelButton.Height + 20);

			//----------------------------------------------------------------------------*
			// Set Control Event Handlers
			//----------------------------------------------------------------------------*

			SourceComboBox.TextChanged += OnSourceChanged;
			FirearmCombo.SelectedIndexChanged += OnFirearmSelected;

			BarrelLengthTextBox.TextChanged += OnBarrelLengthChanged;
			TwistTextBox.TextChanged += OnTwistChanged;
			MuzzleVelocityTextBox.TextChanged += OnMuzzleVelocityChanged;
			PressureTextBox.TextChanged += OnPressureChanged;
			BestGroupTextBox.TextChanged += OnBestGroupChanged;
			BestGroupRangeTextBox.TextChanged += OnBestGroupRangeChanged;
			NotesTextBox.TextChanged += OnNotesChanged;

			ChargeTestOKButton.Click += OnOKClicked;

			//----------------------------------------------------------------------------*
			// Populate the firearm combo
			//----------------------------------------------------------------------------*

			cControls.PopulateFirearmCombo(FirearmCombo, m_DataFiles, m_ChargeTest.Firearm, m_Load.Caliber, m_Load.FirearmType, true);

			PopulateSourceComboBox();

			//----------------------------------------------------------------------------*
			// Fill in the firearm data
			//----------------------------------------------------------------------------*

			SetInputParameters();

			PopulateChargeTestData();

			//----------------------------------------------------------------------------*
			// Set title and text fields
			//----------------------------------------------------------------------------*

			string strTitle;

			if (ChargeTest == null)
				strTitle = "Add";
			else
				strTitle = "Edit";

			strTitle += " Basic Charge Test";

			Text = strTitle;

			SetStaticToolTips();

			UpdateButtons();

			SetInitialFocus();
			}

		//============================================================================*
		// ChargeTest Property
		//============================================================================*

		public cChargeTest ChargeTest
			{
			get { return (m_ChargeTest); }
			}

		//============================================================================*
		// OnBarrelLengthChanged()
		//============================================================================*

		private void OnBarrelLengthChanged(object sender, EventArgs e)
			{
			m_ChargeTest.BarrelLength = cDataFiles.MetricToStandard(BarrelLengthTextBox.Value, cDataFiles.eDataType.Firearm);

			UpdateButtons();
			}

		//============================================================================*
		// OnBestGroupChanged()
		//============================================================================*

		private void OnBestGroupChanged(object sender, EventArgs e)
			{
			m_ChargeTest.BestGroup = cDataFiles.MetricToStandard(BestGroupTextBox.Value, cDataFiles.eDataType.GroupSize);

			UpdateButtons();
			}

		//============================================================================*
		// OnBestGroupRangeChanged()
		//============================================================================*

		private void OnBestGroupRangeChanged(object sender, EventArgs e)
			{
			m_ChargeTest.BestGroupRange = (int) cDataFiles.MetricToStandard(BestGroupRangeTextBox.Value, cDataFiles.eDataType.Range);

			UpdateButtons();
			}

		//============================================================================*
		// OnFirearmSelected()
		//============================================================================*

		private void OnFirearmSelected(object sender, EventArgs e)
			{
			if (FirearmCombo.SelectedIndex == 0)
				{
				m_ChargeTest.Firearm = null;

				BarrelLengthTextBox.Enabled = true;
				TwistTextBox.Enabled = true;
				}
			else
				{
				cFirearm Firearm = (cFirearm) FirearmCombo.SelectedItem;

				m_ChargeTest.Firearm = Firearm;

				m_ChargeTest.BarrelLength = Firearm.BarrelLength;
				m_ChargeTest.Twist = Firearm.Twist;

				BarrelLengthTextBox.Value = cDataFiles.StandardToMetric(m_ChargeTest.BarrelLength, cDataFiles.eDataType.Firearm);
				TwistTextBox.Value = cDataFiles.StandardToMetric(m_ChargeTest.Twist, cDataFiles.eDataType.Firearm);

				BarrelLengthTextBox.Enabled = false;
				TwistTextBox.Enabled = false;
				}

			UpdateButtons();
			}

		//============================================================================*
		// OnMuzzleVelocityChanged()
		//============================================================================*

		private void OnMuzzleVelocityChanged(object sender, EventArgs e)
			{
			m_ChargeTest.MuzzleVelocity = (int) cDataFiles.MetricToStandard(MuzzleVelocityTextBox.Value, cDataFiles.eDataType.Velocity);

			UpdateButtons();
			}

		//============================================================================*
		// OnNotesChanged()
		//============================================================================*

		private void OnNotesChanged(object sender, EventArgs e)
			{
			m_ChargeTest.Notes = NotesTextBox.Text;

			UpdateButtons();
			}

		//============================================================================*
		// OnOKClicked()
		//============================================================================*

		private void OnOKClicked(object sender, EventArgs e)
			{
			}

		//============================================================================*
		// OnPressureChanged()
		//============================================================================*

		private void OnPressureChanged(object sender, EventArgs e)
			{
			m_ChargeTest.Pressure = PressureTextBox.Value;

			UpdateButtons();
			}

		//============================================================================*
		// OnSourceChanged()
		//============================================================================*

		private void OnSourceChanged(object sender, EventArgs e)
			{
			m_ChargeTest.Source = SourceComboBox.Text;

			UpdateButtons();
			}

		//============================================================================*
		// OnTwistChanged()
		//============================================================================*

		private void OnTwistChanged(object sender, EventArgs e)
			{
			m_ChargeTest.Twist = cDataFiles.MetricToStandard(TwistTextBox.Value, cDataFiles.eDataType.Firearm);

			UpdateButtons();
			}

		//============================================================================*
		// PopulateChargeTestData()
		//============================================================================*

		private void PopulateChargeTestData()
			{
			TestDatePicker.Value = m_ChargeTest.TestDate;
			SourceComboBox.Text = m_ChargeTest.Source;
			BarrelLengthTextBox.Value = cDataFiles.StandardToMetric(m_ChargeTest.BarrelLength, cDataFiles.eDataType.Firearm);
			TwistTextBox.Value = cDataFiles.StandardToMetric(m_ChargeTest.Twist, cDataFiles.eDataType.Firearm);

			MuzzleVelocityTextBox.Value = (int) cDataFiles.StandardToMetric(m_ChargeTest.MuzzleVelocity, cDataFiles.eDataType.Velocity);
			PressureTextBox.Value = m_ChargeTest.Pressure;
			BestGroupTextBox.Value = cDataFiles.StandardToMetric(m_ChargeTest.BestGroup, cDataFiles.eDataType.GroupSize);
			BestGroupRangeTextBox.Value = (int) cDataFiles.StandardToMetric(m_ChargeTest.BestGroupRange, cDataFiles.eDataType.Range);
			NotesTextBox.Text = m_ChargeTest.Notes;
			}

		//============================================================================*
		// PopulateSourceComboBox()
		//============================================================================*

		private void PopulateSourceComboBox()
			{
			SourceComboBox.Items.Clear();

			foreach (cLoad Load in m_DataFiles.LoadList)
				{
				foreach (cCharge Charge in Load.ChargeList)
					{
					foreach (cChargeTest ChargeTest in Charge.TestList)
						{
						if (ChargeTest.BatchID != 0)
							continue;

						bool fFound = false;

						for (int i = 0; i < SourceComboBox.Items.Count; i++)
							{
							if (SourceComboBox.Items[i].ToString() == ChargeTest.Source)
								{
								fFound = true;

								break;
								}
							}

						if (!fFound)
							SourceComboBox.Items.Add(ChargeTest.Source);
						}
					}
				}

			SourceComboBox.SelectedIndex = -1;

			UpdateButtons();
			}

		//============================================================================*
		// SetInitialFocus()
		//============================================================================*

		private void SetInitialFocus()
			{
			if (SourceComboBox.BackColor == Color.LightPink)
				SourceComboBox.Focus();
			else
				{
				if (BarrelLengthTextBox.BackColor == Color.LightPink)
					BarrelLengthTextBox.Focus();
				else
					{
					if (TwistTextBox.BackColor == Color.LightPink)
						TwistTextBox.Focus();
					else
						{
						if (MuzzleVelocityTextBox.BackColor == Color.LightPink)
							MuzzleVelocityTextBox.Focus();
						else
							{
							if (PressureTextBox.BackColor == Color.LightPink)
								PressureTextBox.Focus();
							else
								{
								if (BestGroupTextBox.BackColor == Color.LightPink)
									BestGroupTextBox.Focus();
								else
									{
									if (BestGroupRangeTextBox.BackColor == Color.LightPink)
										BestGroupRangeTextBox.Focus();
									else
										{
										TestDatePicker.Focus();
										}
									}
								}
							}
						}
					}
				}
			}

		//============================================================================*
		// SetInputParameters()
		//============================================================================*

		private void SetInputParameters()
			{
			//----------------------------------------------------------------------------*
			// Set metric/standard labels
			//----------------------------------------------------------------------------*

			cDataFiles.SetMetricLabel(BarrelLengthMeasurementLabel, cDataFiles.eDataType.Firearm);
			cDataFiles.SetMetricLabel(TwistMeasurementLabel, cDataFiles.eDataType.Firearm);

			cDataFiles.SetMetricLabel(MuzzleVelocityMeasurementLabel, cDataFiles.eDataType.Velocity);
			cDataFiles.SetMetricLabel(GroupMeasurementLabel, cDataFiles.eDataType.GroupSize);

			cDataFiles.SetMetricLabel(RangeMeasurementLabel, cDataFiles.eDataType.Range);

			//----------------------------------------------------------------------------*
			// Set Text Box Parameters
			//----------------------------------------------------------------------------*

			cDataFiles.SetInputParameters(BarrelLengthTextBox, cDataFiles.eDataType.Firearm);
			cDataFiles.SetInputParameters(TwistTextBox, cDataFiles.eDataType.Firearm);

			cDataFiles.SetInputParameters(MuzzleVelocityTextBox, cDataFiles.eDataType.Velocity);
			cDataFiles.SetInputParameters(BestGroupTextBox, cDataFiles.eDataType.GroupSize);

			cDataFiles.SetInputParameters(BestGroupRangeTextBox, cDataFiles.eDataType.Range);
			}

		//============================================================================*
		// SetStaticToolTips()
		//============================================================================*

		private void SetStaticToolTips()
			{
			if (!m_DataFiles.Preferences.ToolTips)
				return;

			m_TestDateToolTip.ShowAlways = true;
			m_TestDateToolTip.RemoveAll();
			m_TestDateToolTip.SetToolTip(TestDatePicker, cm_strTestDateToolTip);

			m_SourceToolTip.ShowAlways = true;
			m_SourceToolTip.RemoveAll();
			m_SourceToolTip.SetToolTip(SourceComboBox, cm_strSourceToolTip);

			m_FirearmToolTip.ShowAlways = true;
			m_FirearmToolTip.RemoveAll();
			m_FirearmToolTip.SetToolTip(FirearmCombo, cm_strFirearmToolTip);

			BarrelLengthTextBox.ToolTip = cm_strBarrelLengthToolTip;
			TwistTextBox.ToolTip = cm_strTwistToolTip;
			MuzzleVelocityTextBox.ToolTip = cm_strMuzzleVelocityToolTip;
			PressureTextBox.ToolTip = cm_strPressureToolTip;
			BestGroupTextBox.ToolTip = cm_strBestGroupToolTip;
			BestGroupRangeTextBox.ToolTip = cm_strBestGroupRangeToolTip;

			m_NotesToolTip.ShowAlways = true;
			m_NotesToolTip.RemoveAll();
			m_NotesToolTip.SetToolTip(NotesTextBox, cm_strNotesToolTip);

			m_ChargeTestOKButtonToolTip.ShowAlways = true;
			m_ChargeTestOKButtonToolTip.RemoveAll();
			m_ChargeTestOKButtonToolTip.SetToolTip(ChargeTestOKButton, cm_strChargeTestOKButtonToolTip);

			m_ChargeTestCancelButtonToolTip.ShowAlways = true;
			m_ChargeTestCancelButtonToolTip.RemoveAll();
			m_ChargeTestCancelButtonToolTip.SetToolTip(ChargeTestCancelButton, cm_strChargeTestCancelButtonToolTip);
			}

		//============================================================================*
		// UpdateButtons()
		//============================================================================*

		private void UpdateButtons()
			{
			bool fEnableOK = true;

			//----------------------------------------------------------------------------*
			// Check Source
			//----------------------------------------------------------------------------*

			string strToolTip = cm_strSourceToolTip;

			if (SourceComboBox.Text.Length == 0)
				{
				fEnableOK = false;

				strToolTip += "\n\nA source for this test data must be specified.";

				SourceComboBox.BackColor = Color.LightPink;
				}
			else
				SourceComboBox.BackColor = SystemColors.Window;

			if (m_DataFiles.Preferences.ToolTips)
				m_SourceToolTip.SetToolTip(SourceComboBox, strToolTip);

			//----------------------------------------------------------------------------*
			// Check Barrel Length
			//----------------------------------------------------------------------------*

			if (!BarrelLengthTextBox.ValueOK)
				fEnableOK = false;

			//----------------------------------------------------------------------------*
			// Check Twist
			//----------------------------------------------------------------------------*

			if (!TwistTextBox.ValueOK)
				fEnableOK = false;

			//----------------------------------------------------------------------------*
			// Check MuzzleVelocity
			//----------------------------------------------------------------------------*

			if (!MuzzleVelocityTextBox.ValueOK)
				fEnableOK = false;

			//----------------------------------------------------------------------------*
			// Check Pressure
			//----------------------------------------------------------------------------*

			if (!PressureTextBox.ValueOK)
				fEnableOK = false;

			//----------------------------------------------------------------------------*
			// Check Best Group
			//----------------------------------------------------------------------------*

			if (!BestGroupTextBox.ValueOK)
				fEnableOK = false;

			//----------------------------------------------------------------------------*
			// Check Best Group Range
			//----------------------------------------------------------------------------*

			if (!BestGroupRangeTextBox.ValueOK)
				fEnableOK = false;

			//----------------------------------------------------------------------------*
			// Set Buttons
			//----------------------------------------------------------------------------*

			ChargeTestOKButton.Enabled = fEnableOK;
			}
		}
	}
