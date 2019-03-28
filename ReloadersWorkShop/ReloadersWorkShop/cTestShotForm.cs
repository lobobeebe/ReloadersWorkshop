//============================================================================*
// cMainForm.cs
//
// Copyright © 2013-2014, Kevin S. Beebe
// All Rights Reserved
//============================================================================*

//============================================================================*
// .Net Using Statements
//============================================================================*

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows;
using System.Windows.Forms;

//============================================================================*
// Namespace
//============================================================================*

namespace ReloadersWorkShop
	{
	//============================================================================*
	// cTestShotForm Class
	//============================================================================*

	public partial class cTestShotForm : Form
		{
		//----------------------------------------------------------------------------*
		// Private Const Data Members
		//----------------------------------------------------------------------------*

		private const string cm_strMuzzleVelocityToolTip = "Muzzle Velocity attained by the given load.  If unknown, leave at zero (0).";
		private const string cm_strPressureToolTip = "Pressure attained by the given load.  If unknown, leave at zero (0)";
		private const string cm_strMisfireToolTip = "Check (mouse or ALT-M) if this shot was a misfire.";
		private const string cm_strSquibToolTip = "Check (mouse or ALT-S) if this shot was a squib load";

		private const string cm_strPreviousShotToolTip = "Click (or use ALT-P) to select the previous shot data.";
		private const string cm_strNextShotToolTip = "Click (or use Alt-N) to select the next shot data.";

		private const string cm_strTestShotOKButtonToolTip = "Click (or press ENTER) to update the test shot with the above data.";
		private const string cm_strTestShotCancelButtonToolTip = "Click (or press ESC) to cancel changes and return to the main window.";

		//----------------------------------------------------------------------------*
		// Private Data Members
		//----------------------------------------------------------------------------*

		// Form data

		private int m_nShotNum = 0;
		private int m_nNumShots = 0;
        private int m_nNumRounds = 0;
		private cTestShotList m_TestShotList = null;
		private cDataFiles m_DataFiles = null;
		private bool m_fViewOnly = false;

		private bool m_fInitialized = false;

		// Tooltips

		private ToolTip m_MuzzleVelocityToolTip = new ToolTip();
		private ToolTip m_PressureToolTip = new ToolTip();
		private ToolTip m_MisfireToolTip = new ToolTip();
		private ToolTip m_SquibToolTip = new ToolTip();

		private ToolTip m_PreviousShotButtonToolTip = new ToolTip();
		private ToolTip m_NextShotButtonToolTip = new ToolTip();

		private ToolTip m_TestShotOKButtonToolTip = new ToolTip();
		private ToolTip m_TestShotCancelButtonToolTip = new ToolTip();

		//============================================================================*
		// cTestShotForm() - Constructor
		//============================================================================*

		public cTestShotForm(cDataFiles DataFiles, int nNumshots, cTestShotList TestShotList, int nNumRounds, bool fViewOnly = false)
			{
			InitializeComponent();

			m_TestShotList = TestShotList;
			m_nNumShots = nNumshots;
            m_nNumRounds = nNumRounds;
            m_DataFiles = DataFiles;

			m_fViewOnly = fViewOnly;
			
			string strTitle = "";

			if (TestShotList == null)
				{
				m_TestShotList = new cTestShotList();

				TestShotOKButton.Text = "Add";
				}
			else
				{
				m_TestShotList = new cTestShotList(TestShotList);

				TestShotOKButton.Text = "Update";
				}

			SetClientSizeCore(ShotDataGroupBox.Location.X + ShotDataGroupBox.Width + 10, TestShotCancelButton.Location.Y + TestShotCancelButton.Height + 20);

			//----------------------------------------------------------------------------*
			// Event handlers
			//----------------------------------------------------------------------------*

			PreviousShotButton.Click += OnPreviousShotClicked;
			NextShotButton.Click += OnNextShotClicked;

			if (!m_fViewOnly)
				{
				MuzzleVelocityTextBox.TextChanged += OnMuzzleVelocityChanged;

				PressureTextBox.TextChanged += OnPressureChanged;

				MisfireRadioButton.Click += OnMisfireClicked;
				SquibRadioButton.Click += OnSquibClicked;
				}
			else
				{
				MuzzleVelocityTextBox.ReadOnly = true;
				PressureTextBox.ReadOnly = true;
				}

			//----------------------------------------------------------------------------*
			// Set up the buttons and title
			//----------------------------------------------------------------------------*

			if (m_fViewOnly)
				{
				TestShotOKButton.Visible = false;
				TestShotCancelButton.Text = "Close";

				int nButtonX = (this.Size.Width / 2) - (TestShotCancelButton.Width / 2);

				TestShotCancelButton.Location = new Point(nButtonX, TestShotCancelButton.Location.Y);

				strTitle = "View";
				}
			else
				strTitle = "Edit";

			strTitle += " Test Shots";

			//----------------------------------------------------------------------------*
			// Populate data fields
			//----------------------------------------------------------------------------*

			cDataFiles.SetMetricLabel(VelocityMeasurementLabel, cDataFiles.eDataType.Velocity);

			PopulateShotData();

			SetStaticToolTips();

			PopulateStatistics();

			UpdateButtons();

			MuzzleVelocityTextBox.Focus();

			m_fInitialized = true;
			}

		//============================================================================*
		// Initialize()
		//============================================================================*

		public void Initialize()
			{
			MuzzleVelocityTextBox.Focus();
			MuzzleVelocityTextBox.Select(0, 5);
			}

		//============================================================================*
		// OnMisfireClicked()
		//============================================================================*

		private void OnMisfireClicked(object sender, EventArgs args)
			{
			if (!m_fInitialized)
				return;

			MisfireRadioButton.Checked = MisfireRadioButton.Checked ? false : true;

			if (MisfireRadioButton.Checked)
				{
				SquibRadioButton.Checked = false;

				m_TestShotList[m_nShotNum].MuzzleVelocity = 0;
				m_TestShotList[m_nShotNum].Pressure = 0;
				}
			else
				{
				MuzzleVelocityTextBox.Focus();
				}

			m_TestShotList[m_nShotNum].Misfire = MisfireRadioButton.Checked;
			m_TestShotList[m_nShotNum].Squib = SquibRadioButton.Checked;

			PopulateShotData();
			PopulateStatistics();

			UpdateButtons();
			}

		//============================================================================*
		// OnMuzzleVelocityChanged()
		//============================================================================*

		private void OnMuzzleVelocityChanged(object sender, EventArgs args)
			{
			if (!m_fInitialized)
				return;

			m_TestShotList[m_nShotNum].MuzzleVelocity = (int) cDataFiles.MetricToStandard(MuzzleVelocityTextBox.Value, cDataFiles.eDataType.Velocity);

			PopulateStatistics();

			UpdateButtons();
			}

		//============================================================================*
		// OnNextShotClicked()
		//============================================================================*

		private void OnNextShotClicked(object sender, EventArgs args)
			{
			m_nShotNum++;

			if (m_nShotNum >= m_nNumShots)
				m_nShotNum = 0;

			PopulateShotData();

			UpdateButtons();

			MuzzleVelocityTextBox.Focus();
			}

		//============================================================================*
		// OnPreviousShotClicked()
		//============================================================================*

		private void OnPreviousShotClicked(object sender, EventArgs args)
			{
			m_nShotNum--;

			if (m_nShotNum < 0)
				m_nShotNum = m_nNumShots - 1;

			PopulateShotData();

			UpdateButtons();

			MuzzleVelocityTextBox.Focus();
			}

		//============================================================================*
		// OnPressureChanged()
		//============================================================================*

		private void OnPressureChanged(object sender, EventArgs args)
			{
			if (!m_fInitialized)
				return;

			m_TestShotList[m_nShotNum].Pressure = PressureTextBox.Value;

			UpdateButtons();
			}

		//============================================================================*
		// OnSquibClicked()
		//============================================================================*

		private void OnSquibClicked(object sender, EventArgs args)
			{
			if (!m_fInitialized)
				return;

			SquibRadioButton.Checked = SquibRadioButton.Checked ? false : true;

			if (SquibRadioButton.Checked)
				{
				MisfireRadioButton.Checked = false;

				m_TestShotList[m_nShotNum].MuzzleVelocity = 0;
				m_TestShotList[m_nShotNum].Pressure = 0;
				}
			else
				{
				MuzzleVelocityTextBox.Focus();
				}

			m_TestShotList[m_nShotNum].Misfire = MisfireRadioButton.Checked;
			m_TestShotList[m_nShotNum].Squib = SquibRadioButton.Checked;

			PopulateShotData();
			PopulateStatistics();

			UpdateButtons();
			}

		//============================================================================*
		// PopulateShotData()
		//============================================================================*

		public void PopulateShotData()
			{
			ShotNumLabel.Text = string.Format("Shot {0:N0} of {1:N0}", m_nShotNum + 1, m_nNumShots);

			MisfireRadioButton.Checked = m_TestShotList[m_nShotNum].Misfire;
			SquibRadioButton.Checked = m_TestShotList[m_nShotNum].Squib;

			if (m_TestShotList[m_nShotNum].Misfire || m_TestShotList[m_nShotNum].Squib)
				{
				MuzzleVelocityTextBox.Enabled = false;
				PressureTextBox.Enabled = false;

				m_TestShotList[m_nShotNum].MuzzleVelocity = 0;
				m_TestShotList[m_nShotNum].Pressure = 0;
				}
			else
				{
				MuzzleVelocityTextBox.Enabled = true;
				PressureTextBox.Enabled = true;
				}

			MuzzleVelocityTextBox.Value = (int) Math.Round(cDataFiles.StandardToMetric(m_TestShotList[m_nShotNum].MuzzleVelocity, cDataFiles.eDataType.Velocity), 0);
			PressureTextBox.Value = m_TestShotList[m_nShotNum].Pressure;

			MuzzleVelocityTextBox.Focus();
			}

		//============================================================================*
		// PopulateStatistics()
		//============================================================================*

		private void PopulateStatistics()
			{
			cTestStatistics Statistics = new cTestStatistics(m_TestShotList);

			AvgLabel.Text = String.Format("{0:F1} {1}", cDataFiles.StandardToMetric(Statistics.AverageVelocity, cDataFiles.eDataType.Velocity), cDataFiles.MetricString(cDataFiles.eDataType.Velocity));
			MinLabel.Text = String.Format("{0:G0} {1}", cDataFiles.StandardToMetric(Statistics.MinVelocity, cDataFiles.eDataType.Velocity), cDataFiles.MetricString(cDataFiles.eDataType.Velocity));
			MaxLabel.Text = String.Format("{0:G0} {1}", cDataFiles.StandardToMetric(Statistics.MaxVelocity, cDataFiles.eDataType.Velocity), cDataFiles.MetricString(cDataFiles.eDataType.Velocity));
			DeviationLabel.Text = String.Format("{0:G0} {1}", cDataFiles.StandardToMetric(Statistics.MaxVelocity - Statistics.MinVelocity, cDataFiles.eDataType.Velocity), cDataFiles.MetricString(cDataFiles.eDataType.Velocity));
			StdDevLabel.Text = String.Format("{0:F2} {1}", cDataFiles.StandardToMetric(Statistics.StdDev, cDataFiles.eDataType.Velocity), cDataFiles.MetricString(cDataFiles.eDataType.Velocity));
			}

		//============================================================================*
		// SetStaticToolTips()
		//============================================================================*

		private void SetStaticToolTips()
			{
			if (!m_DataFiles.Preferences.ToolTips)
				return;

			m_MuzzleVelocityToolTip.ShowAlways = true;
			m_MuzzleVelocityToolTip.RemoveAll();
			m_MuzzleVelocityToolTip.SetToolTip(MuzzleVelocityTextBox, cm_strMuzzleVelocityToolTip);

			m_PressureToolTip.ShowAlways = true;
			m_PressureToolTip.RemoveAll();
			m_PressureToolTip.SetToolTip(PressureTextBox, cm_strPressureToolTip);

			m_MisfireToolTip.ShowAlways = true;
			m_MisfireToolTip.RemoveAll();
			m_MisfireToolTip.SetToolTip(MisfireRadioButton, cm_strMisfireToolTip);

			m_SquibToolTip.ShowAlways = true;
			m_SquibToolTip.RemoveAll();
			m_SquibToolTip.SetToolTip(SquibRadioButton, cm_strSquibToolTip);

			m_PreviousShotButtonToolTip.ShowAlways = true;
			m_PreviousShotButtonToolTip.RemoveAll();
			m_PreviousShotButtonToolTip.SetToolTip(PreviousShotButton, cm_strPreviousShotToolTip);

			m_NextShotButtonToolTip.ShowAlways = true;
			m_NextShotButtonToolTip.RemoveAll();
			m_NextShotButtonToolTip.SetToolTip(NextShotButton, cm_strNextShotToolTip);

			m_TestShotOKButtonToolTip.ShowAlways = true;
			m_TestShotOKButtonToolTip.RemoveAll();
			m_TestShotOKButtonToolTip.SetToolTip(TestShotOKButton, cm_strTestShotOKButtonToolTip);

			m_TestShotCancelButtonToolTip.ShowAlways = true;
			m_TestShotCancelButtonToolTip.RemoveAll();
			m_TestShotCancelButtonToolTip.SetToolTip(TestShotCancelButton, cm_strTestShotCancelButtonToolTip);
			}

		//============================================================================*
		// TestShotList Property
		//============================================================================*

		public cTestShotList TestShotList
			{
			get { return (m_TestShotList); }
			}

		//============================================================================*
		// UpdateButtons()
		//============================================================================*

		private void UpdateButtons()
			{
			//============================================================================*
			// Check MuzzleVelocty
			//============================================================================*

			bool fEnableOK = true;

			if (!MuzzleVelocityTextBox.ValueOK)
				fEnableOK = false;

			//============================================================================*
			// Check Pressure
			//============================================================================*

			if (!PressureTextBox.ValueOK)
				fEnableOK = false;

			//============================================================================*
			// Set Buttons
			//============================================================================*

			TestShotOKButton.Enabled = fEnableOK;
			PreviousShotButton.Enabled = fEnableOK;
			NextShotButton.Enabled = fEnableOK;
			}
		}
	}
