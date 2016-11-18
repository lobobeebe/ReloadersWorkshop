//============================================================================*
// cAmmoTestForm.cs
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

using ReloadersWorkShop.Controls;

//============================================================================*
// NameSpace
//============================================================================*

namespace ReloadersWorkShop
	{
	//============================================================================*
	// cAmmoTestForm Class
	//============================================================================*

	public partial class cAmmoTestForm : Form
		{
		//----------------------------------------------------------------------------*
		// Private Const Data Members
		//----------------------------------------------------------------------------*

		private const string cm_strFirearmTypeToolTip = "Type of Firearm.";
		private const string cm_strCaliberComboToolTip = "Select the caliber of batches you wish to view.";
		private const string cm_strBatchComboToolTip = "Select the batch for which you wish to add test data.";

		private const string cm_strTestDateToolTip = "The date on which the test was conducted.  For factory test data, just use today's date.";
		private const string cm_strFirearmComboToolTip = "Select the firearm used for this test.";
		private const string cm_strNumTestShotsToolTip = "Enter the number of shots fired for this test.";
		private const string cm_strBarrelLengthToolTip = "The length, in inches, of the firearm used for this test.";
		private const string cm_strTwistToolTip = "The twist rate, in turns per inch, of the barrel on the firearm used for this test.  For factory \ntest data, if you don't know the twist rate, just leave it at zero (0).";
		private const string cm_strBestGroupToolTip = "Enter the best group size, in inches, achieved for this test.";
		private const string cm_strBestGroupRangeToolTip = "The range, in yards, at which the best group was achieved.";
		private const string cm_strFavoriteLoadToolTip = "Check if this is one of your favorite loads.";
		private const string cm_strRejectLoadToolTip = "Check if this load should go to the reject pile.";
		private const string cm_strNotesToolTip = "Enter any notes you may have regarding this batch and/or load.";
		private const string cm_strMuzzleVelocityToolTip = "Muzzle Velocity of the test shots fired.  This will be calculated based on test shots fired with \nyour own firearm or you can enter the velocity listed on the box for factory firearms.";

		private const string cm_strShotListToolTip = "A list of the shots fired for this test.";

		private const string cm_strEditShotsToolTip = "Click to edit/view the shots fired for this test.";

		private const string cm_strBatchTestOKButtonToolTip = "Click to add or update the batch test with the above data.";
		private const string cm_strBatchTestDeleteButtonToolTip = "Click to delete the above batch test data from the batch.";
		private const string cm_strBatchTestCancelButtonToolTip = "Click to cancel changes and return to the main window.";

		//----------------------------------------------------------------------------*
		// Private Data Members
		//----------------------------------------------------------------------------*

		private cAmmoTest m_AmmoTest = null;
		private cDataFiles m_DataFiles = null;

		private bool m_fViewOnly = false;
		private bool m_fInitialized = false;

		private ToolTip m_TestDateToolTip = new ToolTip();
		private ToolTip m_FirearmTypeToolTip = new ToolTip();
		private ToolTip m_CaliberComboToolTip = new ToolTip();
		private ToolTip m_BatchComboToolTip = new ToolTip();

		private ToolTip m_FirearmComboToolTip = new ToolTip();
		private ToolTip m_NumTestShotsToolTip = new ToolTip();
		private ToolTip m_BarrelLengthToolTip = new ToolTip();
		private ToolTip m_TwistToolTip = new ToolTip();
		private ToolTip m_BestGroupToolTip = new ToolTip();
		private ToolTip m_BestGroupRangeToolTip = new ToolTip();
		private ToolTip m_FavoriteLoadToolTip = new ToolTip();
		private ToolTip m_RejectLoadToolTip = new ToolTip();
		private ToolTip m_NotesToolTip = new ToolTip();
		private ToolTip m_ShotListToolTip = new ToolTip();
		private ToolTip m_MuzzleVelocityToolTip = new ToolTip();
		private ToolTip m_EditShotsToolTip = new ToolTip();
		private ToolTip m_AmmoTestOKButtonToolTip = new ToolTip();
		private ToolTip m_AmmoTestCancelButtonToolTip = new ToolTip();

		//============================================================================*
		// cAmmoTestForm() - Constructor
		//============================================================================*

		public cAmmoTestForm(cAmmo Ammo, cAmmoTest AmmoTest, cDataFiles DataFiles, bool fViewOnly = false)
			{
			InitializeComponent();

			m_DataFiles = DataFiles;
			m_fViewOnly = fViewOnly;

			string strTitle = "";

			if (AmmoTest == null)
				{
				m_AmmoTest = new cAmmoTest();
				m_AmmoTest.Ammo = Ammo;
				m_AmmoTest.TestDate = DateTime.Today;

				if (Ammo.TestList.Count == 0)
					m_AmmoTest.Firearm = null;
				else
					{
					foreach (cFirearm Firearm in m_DataFiles.FirearmList)
						{
						if (Firearm.HasCaliber(Ammo.Caliber))
							{
							m_AmmoTest.Firearm = Firearm;

							break;
							}
						}
					}

				strTitle = "Add";

				OKButton.Text = "Add";
				}
			else
				{
				m_AmmoTest = new cAmmoTest(AmmoTest);

				if (m_AmmoTest.Ammo == null)
					m_AmmoTest.Ammo = Ammo;

				if (Ammo != null && Ammo.TestList.Count == 0)
					m_AmmoTest.Firearm = null;

				if (!m_fViewOnly)
					{
					strTitle = "Edit";

					OKButton.Text = "Update";
					}
				else
					{
					AmmoTestCancelButton.Text = "Close";
					OKButton.Visible = false;

					int nButtonX = (this.Size.Width / 2) - (AmmoTestCancelButton.Width / 2);

					AmmoTestCancelButton.Location = new Point(nButtonX, AmmoTestCancelButton.Location.Y);

					strTitle = "View";
					}
				}

			SetClientSizeCore(AmmoDataGroupBox.Location.X + AmmoDataGroupBox.Width + 10, AmmoTestCancelButton.Location.Y + AmmoTestCancelButton.Height + 20);

			//----------------------------------------------------------------------------*
			// Dialog Title
			//----------------------------------------------------------------------------*

			strTitle += " Ammo Test";

			Text = strTitle;

			//----------------------------------------------------------------------------*
			// Event Handlers
			//----------------------------------------------------------------------------*

			if (!m_fViewOnly)
				{
				TestDatePicker.TextChanged += OnDateChanged;

				BarrelLengthTextBox.TextChanged += OnTextChanged;
				TwistTextBox.TextChanged += OnTextChanged;
				NumShotsTextBox.TextChanged += OnTextChanged;
				MuzzleVelocityTextBox.TextChanged += OnTextChanged;
				BestGroupTextBox.TextChanged += OnTextChanged;
				BestGroupRangeTextBox.TextChanged += OnTextChanged;

				NumShotsTextBox.TextChanged += OnNumShotsTextChanged;

				OKButton.Click += OnOKClicked;
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
			// Populate Ammo Data
			//----------------------------------------------------------------------------*

			SetStaticToolTips();

			SetInputParameters();

			ManufacturerLabel.Text = m_AmmoTest.Ammo.Manufacturer.ToString();
			CaliberLabel.Text = m_AmmoTest.Ammo.Caliber.ToString();
			PartNumberLabel.Text = m_AmmoTest.Ammo.PartNumber;
			TypeLabel.Text = m_AmmoTest.Ammo.Type;
			BulletWeightLabel.Text = String.Format("{0:G0} {1}", cDataFiles.StandardToMetric(m_AmmoTest.Ammo.BulletWeight, cDataFiles.eDataType.BulletWeight), cDataFiles.MetricString(cDataFiles.eDataType.BulletWeight));
			BulletDiameterLabel.Text = String.Format("{0:F3} {1}", cDataFiles.StandardToMetric(m_AmmoTest.Ammo.BulletDiameter, cDataFiles.eDataType.Dimension), cDataFiles.MetricString(cDataFiles.eDataType.Dimension));
			BallisticCoefficientLabel.Text = String.Format("{0:F3}", m_AmmoTest.Ammo.BallisticCoefficient);

			switch (m_AmmoTest.Ammo.FirearmType)
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

			//----------------------------------------------------------------------------*
			// Populate Firearm Combo
			//----------------------------------------------------------------------------*

			if (!m_AmmoTest.Ammo.Reload && (m_AmmoTest.Firearm == null || m_AmmoTest.Ammo.TestList.Count == 0))
				{
				FirearmCombo.Items.Add("Factory");
				FirearmCombo.SelectedIndex = 0;
				FirearmCombo.Enabled = false;
				}
			else
				{
				foreach (cFirearm Firearm in m_DataFiles.FirearmList)
					{
					if (Firearm.FirearmType == m_AmmoTest.Ammo.FirearmType &&
						Firearm.HasCaliber(m_AmmoTest.Ammo.Caliber))
						FirearmCombo.Items.Add(Firearm);
					}

				FirearmCombo.SelectedItem = m_AmmoTest.Firearm;

				if (FirearmCombo.SelectedIndex < 0 && FirearmCombo.Items.Count > 0)
					FirearmCombo.SelectedIndex = 0;

				if (FirearmCombo.SelectedIndex >= 0)
					m_AmmoTest.Firearm = (cFirearm) FirearmCombo.SelectedItem;
				else
					m_AmmoTest.Firearm = null;
				}

			//----------------------------------------------------------------------------*
			// Populate Test Data
			//----------------------------------------------------------------------------*

			TestDatePicker.Value = m_AmmoTest.TestDate;

			if (m_AmmoTest.Firearm != null)
				{
				BarrelLengthTextBox.Value = cDataFiles.StandardToMetric(m_AmmoTest.Firearm.BarrelLength, cDataFiles.eDataType.Firearm);
				TwistTextBox.Value = cDataFiles.StandardToMetric(m_AmmoTest.Firearm.Twist, cDataFiles.eDataType.Firearm);

				BarrelLengthTextBox.Enabled = false;
				TwistTextBox.Enabled = false;
				}
			else
				{
				BarrelLengthTextBox.Value = cDataFiles.StandardToMetric(m_AmmoTest.BarrelLength, cDataFiles.eDataType.Firearm);
				TwistTextBox.Value = cDataFiles.StandardToMetric(m_AmmoTest.Twist, cDataFiles.eDataType.Firearm);

				BarrelLengthTextBox.Enabled = true;
				TwistTextBox.Enabled = true;
				}

			PopulateShotList();

			NumShotsTextBox.Value = m_AmmoTest.NumRounds;
			BestGroupTextBox.Value = cDataFiles.StandardToMetric(m_AmmoTest.BestGroup, cDataFiles.eDataType.GroupSize);
            BestGroupRangeTextBox.Value = (int) cDataFiles.StandardToMetric(m_AmmoTest.BestGroupRange, cDataFiles.eDataType.Range);
			MuzzleVelocityTextBox.Value = (int) cDataFiles.StandardToMetric(m_AmmoTest.MuzzleVelocity, cDataFiles.eDataType.Velocity);

			if (m_AmmoTest.Firearm == null)
				{
				NumShotsTextBox.Enabled = false;
				BestGroupTextBox.Enabled = false;
				BestGroupRangeTextBox.Enabled = false;
				MuzzleVelocityTextBox.Enabled = true;
				}
			else
				{
				MuzzleVelocityTextBox.Enabled = true;
				NumShotsTextBox.Enabled = true;
				BestGroupTextBox.Enabled = true;
				BestGroupRangeTextBox.Enabled = true;
				MuzzleVelocityTextBox.Enabled = true;
				}

			NotesTextBox.Text = m_AmmoTest.Notes;

			PopulateShotList();

			m_fInitialized = true;

			UpdateButtons();
			}

		//============================================================================*
		// AmmoTest Property
		//============================================================================*

		public cAmmoTest AmmoTest
			{
			get { return (m_AmmoTest); }
			}

		//============================================================================*
		// OnDateChanged()
		//============================================================================*

		private void OnDateChanged(object sender, EventArgs e)
			{
			if (!m_fInitialized)
				return;

			UpdateButtons();
			}

		//============================================================================*
		// OnEditShotsClicked()
		//============================================================================*

		public void OnEditShotsClicked(object sender, EventArgs args)
			{
			cTestShotForm TestShotform = new cTestShotForm(m_DataFiles, NumShotsTextBox.Value, m_AmmoTest.TestShotList, m_AmmoTest.NumRounds, m_fViewOnly);

			TestShotform.Initialize();

			if (TestShotform.ShowDialog() == DialogResult.OK)
				{
				m_AmmoTest.TestShotList = new cTestShotList(TestShotform.TestShotList);

				PopulateShotList();

				PopulateStatistics();

				UpdateButtons();
				}
			}

		//============================================================================*
		// OnFirearmChanged()
		//============================================================================*

		public void OnFirearmChanged(object sender, EventArgs args)
			{
			if (!m_fInitialized)
				return;

			PopulateAmmoTestData();

			UpdateButtons();
			}

		//============================================================================*
		// OnNumShotsTextChanged()
		//============================================================================*

		private void OnNumShotsTextChanged(object sender, EventArgs e)
			{
			if (!m_fInitialized)
				return;

			if (NumShotsTextBox.Value != m_AmmoTest.TestShotList.Count)
				{
				if (NumShotsTextBox.Value == 0)
					m_AmmoTest.TestShotList.Clear();
				else
					{
					while (NumShotsTextBox.Value > m_AmmoTest.TestShotList.Count)
						m_AmmoTest.TestShotList.Add(new cTestShot());

					while (NumShotsTextBox.Value < m_AmmoTest.TestShotList.Count)
						m_AmmoTest.TestShotList.RemoveAt(m_AmmoTest.TestShotList.Count - 1);
					}

				PopulateShotList();
				}

			UpdateButtons();
			}

		//============================================================================*
		// OnOKClicked()
		//============================================================================*

		public void OnOKClicked(object sender, EventArgs args)
			{
			m_AmmoTest.TestDate = TestDatePicker.Value;
			m_AmmoTest.BarrelLength = cDataFiles.MetricToStandard(BarrelLengthTextBox.Value, cDataFiles.eDataType.Firearm);
			m_AmmoTest.Twist = cDataFiles.MetricToStandard(TwistTextBox.Value, cDataFiles.eDataType.Firearm);
			m_AmmoTest.NumRounds = NumShotsTextBox.Value;
			m_AmmoTest.MuzzleVelocity = (int) cDataFiles.MetricToStandard(MuzzleVelocityTextBox.Value, cDataFiles.eDataType.Velocity);
			m_AmmoTest.BestGroup = cDataFiles.MetricToStandard(BestGroupTextBox.Value, cDataFiles.eDataType.GroupSize);
			m_AmmoTest.BestGroupRange = (int) cDataFiles.MetricToStandard(BestGroupRangeTextBox.Value, cDataFiles.eDataType.Range);
			m_AmmoTest.Notes = NotesTextBox.Text;

			while (m_AmmoTest.TestShotList.Count > 0 && m_AmmoTest.NumRounds < m_AmmoTest.TestShotList.Count)
				m_AmmoTest.TestShotList.RemoveAt(m_AmmoTest.TestShotList.Count - 1);
			}

		//============================================================================*
		// OnTextChanged()
		//============================================================================*

		protected void OnTextChanged(object sender, EventArgs e)
			{
			if (!m_fInitialized)
				return;

			UpdateButtons();
			}

		//============================================================================*
		// PopulateAmmoTestData()
		//============================================================================*

		public void PopulateAmmoTestData()
			{
			TestDatePicker.Value = m_AmmoTest.TestDate;

			cFirearm Firearm = (cFirearm)FirearmCombo.SelectedItem;

			if (Firearm != null)
				{
				BarrelLengthTextBox.Value = Firearm.BarrelLength;
				BarrelLengthTextBox.Enabled = false;
				TwistTextBox.Value = Firearm.Twist;
				TwistTextBox.Enabled = false;
				}
			else
				{
				BarrelLengthTextBox.Value= 0;
				BarrelLengthTextBox.Enabled = true;
				TwistTextBox.Value = 0;
				TwistTextBox.Enabled = true;
				}

			NumShotsTextBox.Value = m_AmmoTest.NumRounds;
			BestGroupTextBox.Value = cDataFiles.StandardToMetric(m_AmmoTest.BestGroup, cDataFiles.eDataType.GroupSize);
			BestGroupRangeTextBox.Value = (int) cDataFiles.StandardToMetric(m_AmmoTest.BestGroupRange, cDataFiles.eDataType.Range);
			}

		//============================================================================*
		// PopulateShotList()
		//============================================================================*

		public void PopulateShotList()
			{
			int nShot = 1;

			ShotListView.Items.Clear();

			foreach (cTestShot TestShot in m_AmmoTest.TestShotList)
				{
				if (nShot > NumShotsTextBox.Value)
					break;

				ListViewItem Item = new ListViewItem(String.Format("{0:N0}", nShot++));

				Item.Tag = TestShot;

				Item.SubItems.Add(String.Format("{0:N0}", TestShot.MuzzleVelocity));
				Item.SubItems.Add(String.Format("{0:N0}", TestShot.Pressure));

				Item.SubItems.Add(TestShot.Misfire ? "Y" : "N");
				Item.SubItems.Add(TestShot.Squib ? "Y" : "N");

				ShotListView.Items.Add(Item);
				}
			}

		//============================================================================*
		// PopulateStatistics()
		//============================================================================*

		private void PopulateStatistics()
			{
			cTestStatistics Statistics = m_AmmoTest.TestShotList.GetStatistics(m_AmmoTest.NumRounds);

			m_AmmoTest.MuzzleVelocity = (int) Statistics.AverageVelocity;

			MuzzleVelocityTextBox.Value = (int) cDataFiles.StandardToMetric(m_AmmoTest.MuzzleVelocity, cDataFiles.eDataType.Velocity);
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

			m_FirearmComboToolTip.ShowAlways = true;
			m_FirearmComboToolTip.RemoveAll();
			m_FirearmComboToolTip.SetToolTip(FirearmCombo, cm_strFirearmComboToolTip);

			NumShotsTextBox.ToolTip = cm_strNumTestShotsToolTip;

			BarrelLengthTextBox.ToolTip = cm_strBarrelLengthToolTip;

			TwistTextBox.ToolTip = cm_strTwistToolTip;

			BestGroupTextBox.ToolTip = cm_strBestGroupToolTip;

			BestGroupRangeTextBox.ToolTip = cm_strBestGroupRangeToolTip;

			m_NotesToolTip.ShowAlways = true;
			m_NotesToolTip.RemoveAll();
			m_NotesToolTip.SetToolTip(NotesTextBox, cm_strNotesToolTip);

			m_ShotListToolTip.ShowAlways = true;
			m_ShotListToolTip.RemoveAll();
			m_ShotListToolTip.SetToolTip(ShotListView, cm_strShotListToolTip);

			MuzzleVelocityTextBox.ToolTip = cm_strMuzzleVelocityToolTip;

			m_EditShotsToolTip.ShowAlways = true;
			m_EditShotsToolTip.RemoveAll();
			m_EditShotsToolTip.SetToolTip(EditShotsButton, cm_strEditShotsToolTip);

			m_AmmoTestOKButtonToolTip.ShowAlways = true;
			m_AmmoTestOKButtonToolTip.RemoveAll();
			m_AmmoTestOKButtonToolTip.SetToolTip(OKButton, cm_strBatchTestOKButtonToolTip);

			m_AmmoTestCancelButtonToolTip.ShowAlways = true;
			m_AmmoTestCancelButtonToolTip.RemoveAll();
			m_AmmoTestCancelButtonToolTip.SetToolTip(AmmoTestCancelButton, cm_strBatchTestCancelButtonToolTip);
			}

		//============================================================================*
		// UpdateButtons()
		//============================================================================*

		private void UpdateButtons()
			{
			if (!m_fInitialized)
				return;

			bool fOKEnabled = true;

			//----------------------------------------------------------------------------*
			// Test Date
			//----------------------------------------------------------------------------*

			DateTime TestDate = m_AmmoTest.TestDate;

			if (TestDate < m_AmmoTest.TestDate)
				{
				m_AmmoTest.TestDate = DateTime.Today;

				TestDatePicker.Value = m_AmmoTest.TestDate;
				}

			//----------------------------------------------------------------------------*
			// Num Shots Fired
			//----------------------------------------------------------------------------*

			string strText = cm_strNumTestShotsToolTip;

			if (m_AmmoTest.Firearm != null)
				{
				if (!NumShotsTextBox.ValueOK)
					fOKEnabled = false;
				else
					{
					if (BestGroupTextBox.Value > 0.0 && NumShotsTextBox.Value == 0)
						{
						fOKEnabled = false;

						strText += "\n\nYou must enter the number of shots fired to achieve the best group specified.";
						}
					}
				}
			else
				NumShotsTextBox.BackColor = SystemColors.Window;

			if (m_DataFiles.Preferences.ToolTips)
				NumShotsTextBox.ToolTip = strText;

			//----------------------------------------------------------------------------*
			// Barrel Length
			//----------------------------------------------------------------------------*

			if (!BarrelLengthTextBox.ValueOK)
				fOKEnabled = false;

			//----------------------------------------------------------------------------*
			// Twist
			//----------------------------------------------------------------------------*

			if (!TwistTextBox.ValueOK)
				fOKEnabled = false;

			//----------------------------------------------------------------------------*
			// Best Group
			//----------------------------------------------------------------------------*

			strText = cm_strBestGroupToolTip;

			if (m_AmmoTest.Firearm != null)
				{
				if (!BestGroupTextBox.ValueOK)
					{
					fOKEnabled = false;

					strText += BestGroupTextBox.ToolTip;
					}
				else
					{
					if (BestGroupTextBox.Value == 0.0 && NumShotsTextBox.Value > 0)
						{
						fOKEnabled = false;

						strText += String.Format("\n\nYou must enter the best group achieved with the {0} test shots specified.", NumShotsTextBox.Value);

						BestGroupTextBox.BackColor = Color.LightPink;
						}
					else
						BestGroupTextBox.BackColor = SystemColors.Window;
					}
				}
			else
				BestGroupTextBox.BackColor = SystemColors.Window;

			if (m_DataFiles.Preferences.ToolTips)
				m_BestGroupToolTip.SetToolTip(BestGroupTextBox, strText);

			//----------------------------------------------------------------------------*
			// Best Group Range
			//----------------------------------------------------------------------------*

			strText = cm_strBestGroupRangeToolTip;

			if (m_AmmoTest.Firearm != null)
				{
				if (!BestGroupRangeTextBox.ValueOK)
					{
					fOKEnabled = false;

					strText += BestGroupRangeTextBox.ToolTip;
					}
				else
					{
					if (BestGroupRangeTextBox.Value == 0 && (BestGroupTextBox.Value > 0.0 || NumShotsTextBox.Value > 0))
						{
						fOKEnabled = false;

						strText += "\n\nYou must enter the range, in yards, at which the best group indicated was achieved";

						BestGroupRangeTextBox.BackColor = Color.LightPink;
						}
					else
						BestGroupRangeTextBox.BackColor = SystemColors.Window;
					}
				}
			else
				BestGroupRangeTextBox.BackColor = SystemColors.Window;

			if (m_DataFiles.Preferences.ToolTips)
				BestGroupRangeTextBox.ToolTip = strText;

			//----------------------------------------------------------------------------*
			// Muzzle Velocity
			//----------------------------------------------------------------------------*

			if (!MuzzleVelocityTextBox.ValueOK)
				fOKEnabled = false;

			//----------------------------------------------------------------------------*
			// Shot List
			//----------------------------------------------------------------------------*

			strText = cm_strShotListToolTip;

			if (m_AmmoTest.Firearm != null)
				{
				if (ShotListView.Items.Count == 0 || NumShotsTextBox.Value != ShotListView.Items.Count)
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
				}
			else
				{
				ShotListView.BackColor = SystemColors.Window;

				ShotListView.Enabled = false;

				EditShotsButton.Enabled = false;
				}

			if (m_DataFiles.Preferences.ToolTips)
				m_ShotListToolTip.SetToolTip(ShotListView, strText);

			//----------------------------------------------------------------------------*
			// Set Buttons
			//----------------------------------------------------------------------------*

			OKButton.Enabled = fOKEnabled;
			}
		}
	}
