//============================================================================*
// cChargeForm.cs
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
using System.Windows.Forms;

using ReloadersWorkShop.Preferences;

//============================================================================*
// NameSpace
//============================================================================*

namespace ReloadersWorkShop
	{
	//============================================================================*
	// cChargeForm Class
	//============================================================================*

	public partial class cChargeForm : Form
		{
		//----------------------------------------------------------------------------*
		// Private Constant Data Members
		//----------------------------------------------------------------------------*

		private const string cm_strPowderWeightToolTip = "Weight of the powder charge for this load.";
		private const string cm_strFillRatioToolTip = "Percentage of the case that will be filled by this powder charge.  Vaules higher than 100% indicate a compressed load.";
		private const string cm_strFavoriteToolTip = "Check if this load, with this powder charge, is one of your favorites.";
		private const string cm_strRejectToolTip = "Check if this load, with this powder charge, has been rejected for whatever reason.";
		private const string cm_strTestListToolTip = "List of tests performed using cartridges loaded with this power charge.";

		private const string cm_strAddTestToolTip = "Add a new test record for this powder charge.";
		private const string cm_strEditTestToolTip = "Edit the selected test record.";
		private const string cm_strRemoveTestToolTip = "Remove the selected test record.";

		private const string cm_strChargeOKButtonToolTip = "Click to add or update the charge with the above data.";
		private const string cm_strChargeCancelButtonToolTip = "Click to cancel changes and return to the main window.";

		//----------------------------------------------------------------------------*
		// Private Data Members
		//----------------------------------------------------------------------------*

		private bool m_fViewOnly = false;
		private bool m_fEditCharge = false;
		private bool m_fAdd = false;

		private bool m_fInitialized = false;

		private cCharge m_Charge = null;

		private double m_dOriginalCharge = 0.0;

		private cLoad m_Load = null;

		private cDataFiles m_DataFiles;

		private ToolTip m_FavoriteToolTip = new ToolTip();
		private ToolTip m_RejectToolTip = new ToolTip();

		private ToolTip m_TestListToolTip = new ToolTip();

		private ToolTip m_AddTestToolTip = new ToolTip();
		private ToolTip m_EditTestToolTip = new ToolTip();
		private ToolTip m_RemoveTestToolTip = new ToolTip();

		private ToolTip m_ChargeOKButtonToolTip = new ToolTip();
		private ToolTip m_ChargeCancelButtonToolTip = new ToolTip();

		//============================================================================*
		// cChargeForm() - Constructor
		//============================================================================*

		public cChargeForm(cCharge Charge, cLoad Load, cDataFiles DataFiles, bool fViewOnly = false)
			{
			InitializeComponent();

			m_Load = Load;
			m_DataFiles = DataFiles;

			m_fViewOnly = fViewOnly;
			m_fEditCharge = !m_fViewOnly;

			//----------------------------------------------------------------------------*
			// Get starting load info
			//----------------------------------------------------------------------------*

			if (Charge == null)
				{
				Text = "Add Charge";

				ChargeOKButton.Text = "Add";

				if (m_DataFiles.Preferences.LastCharge == null)
					m_Charge = new cCharge();
				else
					{
					m_Charge = new cCharge(m_DataFiles.Preferences.LastCharge);

					m_Charge.PowderWeight = 0.0;
					m_Charge.Favorite = false;
					m_Charge.Reject = false;
					m_Charge.TestList.Clear();
					}

				m_fAdd = true;
				m_fEditCharge = true;
				}
			else
				{
				m_Charge = new cCharge(Charge);

				if (!m_fViewOnly)
					{
					Text = "Edit Charge";

					ChargeOKButton.Text = "Update";
					}
				else
					{
					Text = "View Charge";

					ChargeOKButton.Visible = false;

					int nButtonX = (this.Size.Width / 2) - (ChargeCancelButton.Width / 2);

					ChargeCancelButton.Location = new Point(nButtonX, ChargeCancelButton.Location.Y);

					ChargeCancelButton.Text = "Close";
					}
				}

			SetClientSizeCore(LoadDataGroupBox.Location.X + LoadDataGroupBox.Width + 10, ChargeCancelButton.Location.Y + ChargeCancelButton.Height + 20);

			m_dOriginalCharge = m_Charge.PowderWeight;

			//----------------------------------------------------------------------------*
			// Set Control Event Handlers
			//----------------------------------------------------------------------------*

			ChargeTestListView.ListViewItemSorter = new cListViewChargeTestComparer(m_DataFiles.Preferences.ChargeTestSortColumn, m_DataFiles.Preferences.ChargeTestSortOrder);
			ChargeTestListView.ColumnWidthChanged += OnChargeTestListViewColumnWidthChanged;
			ChargeTestListView.SelectedIndexChanged += OnTestSelected;
			ChargeTestListView.ColumnWidthChanged += OnChargeTestListViewColumnWidthChanged;

			if (!m_fViewOnly)
				{
				PowderWeightTextBox.TextChanged += OnPowderWeightChanged;
				FillRatioTextBox.TextChanged += OnFillRatioChanged;

				AddChargeTestButton.Click += OnAddChargeTest;
				EditChargeTestButton.Click += OnEditChargeTest;
				RemoveChargeTestButton.Click += OnRemoveChargeTest;

				FavoriteRadioButton.Click += OnFavoriteClicked;
				RejectRadioButton.Click += OnRejectClicked;

				PowderWeightTextBox.ReadOnly = false;
				FillRatioTextBox.ReadOnly = false;

				AddChargeTestButton.Enabled = true;
				EditChargeTestButton.Enabled = true;
				RemoveChargeTestButton.Enabled = true;
				}
			else
				{
				PowderWeightTextBox.ReadOnly = true;
				FillRatioTextBox.ReadOnly = true;

				AddChargeTestButton.Enabled = false;
				EditChargeTestButton.Enabled = false;
				RemoveChargeTestButton.Enabled = false;
				}

			//----------------------------------------------------------------------------*
			// Set Column Headers
			//----------------------------------------------------------------------------*

			ChargeTestListView.Columns[1].Text += String.Format(" ({0})", cDataFiles.MetricString(cDataFiles.eDataType.Firearm));
			ChargeTestListView.Columns[3].Text += String.Format(" ({0})", cDataFiles.MetricString(cDataFiles.eDataType.Velocity));
			ChargeTestListView.Columns[5].Text += String.Format(" ({0})", cDataFiles.MetricString(cDataFiles.eDataType.GroupSize));
			ChargeTestListView.Columns[6].Text += String.Format(" ({0})", cDataFiles.MetricString(cDataFiles.eDataType.Range));

			//----------------------------------------------------------------------------*
			// Fill in load data
			//----------------------------------------------------------------------------*

			FirearmTypeLabel.Text = cFirearm.FirearmTypeString(m_Load.FirearmType);

			if (m_Load != null)
				{
				if (m_Load.Caliber != null)
					CaliberLabel.Text = m_Load.Caliber.ToString();

				if (m_Load.Bullet != null)
					BulletLabel.Text = m_Load.Bullet.ToString();

				if (m_Load.Powder != null)
					PowderLabel.Text = m_Load.Powder.ToString();

				if (m_Load.Primer != null)
					PrimerLabel.Text = m_Load.Primer.ToString();

				if (m_Load.Case != null)
					CaseLabel.Text = m_Load.Case.ToString();
				}

			SetStaticToolTips();

			SetInputParameters();

			PopulateChargeData();

			if (!m_fViewOnly)
				PowderWeightTextBox.Focus();
			else
				ChargeCancelButton.Focus();

			UpdateButtons();

			m_fInitialized = true;
			}

		//============================================================================*
		// Charge Property
		//============================================================================*

		public cCharge Charge
			{
			get
				{
				return (m_Charge);
				}
			}

		//============================================================================*
		// EnableChanges()
		//============================================================================*

		private void EnableChanges()
			{
			if (!m_fViewOnly)
				{
				PowderWeightTextBox.Enabled = m_fEditCharge || m_fAdd;

				FillRatioTextBox.Enabled = true;
				FavoriteRadioButton.Enabled = true;
				RejectRadioButton.Enabled = true;
				}
			else
				{
				PowderWeightTextBox.Enabled = false;
				FillRatioTextBox.Enabled = false;
				FavoriteRadioButton.Enabled = false;
				RejectRadioButton.Enabled = false;
				}
			}

		//============================================================================*
		// OnAddChargeTest()
		//============================================================================*

		private void OnAddChargeTest(object sender, EventArgs e)
			{
			//----------------------------------------------------------------------------*
			// Start the dialog
			//----------------------------------------------------------------------------*

			cChargeTestForm ChargeTestForm = new cChargeTestForm(null, m_Load, m_DataFiles);

			if (ChargeTestForm.ShowDialog() == DialogResult.OK)
				{
				//----------------------------------------------------------------------------*
				// Get the new Manufacturer Data
				//----------------------------------------------------------------------------*

				cChargeTest ChargeTest = ChargeTestForm.ChargeTest;

				m_DataFiles.Preferences.LastChargeTest = ChargeTestForm.ChargeTest;

				//----------------------------------------------------------------------------*
				// See if the Charge already exists
				//----------------------------------------------------------------------------*

				m_Charge.TestList.Add(ChargeTest);

				PopulateChargeTestListView();
				}
			}

		//============================================================================*
		// OnChargeTestListViewColumnWidthChanged()
		//============================================================================*

		protected void OnChargeTestListViewColumnWidthChanged(object sender, ColumnWidthChangedEventArgs args)
			{
			cControls.OnColumnWidthChanged(sender, args, m_DataFiles, cPreferences.eApplicationListView.ChargeTestListView);
			}

		//============================================================================*
		// OnEditChargeTest()
		//============================================================================*

		private void OnEditChargeTest(object sender, EventArgs e)
			{
			//----------------------------------------------------------------------------*
			// Get the selected charge test
			//----------------------------------------------------------------------------*

			cChargeTest OldChargeTest = (cChargeTest) ChargeTestListView.SelectedItems[0].Tag;

			//----------------------------------------------------------------------------*
			// Start the dialog
			//----------------------------------------------------------------------------*

			cChargeTestForm ChargeTestForm = new cChargeTestForm(OldChargeTest, m_Load, m_DataFiles);

			if (ChargeTestForm.ShowDialog() == DialogResult.OK)
				{
				//----------------------------------------------------------------------------*
				// Get the new Manufacturer Data
				//----------------------------------------------------------------------------*

				cChargeTest ChargeTest = ChargeTestForm.ChargeTest;

				//----------------------------------------------------------------------------*
				// Remove the old charge test and insert the new
				//----------------------------------------------------------------------------*

				m_Charge.TestList.Remove(OldChargeTest);

				m_Charge.TestList.Add(ChargeTest);

				PopulateChargeTestListView();
				}
			}

		//============================================================================*
		// OnFavoriteClicked()
		//============================================================================*

		private void OnFavoriteClicked(object sender, EventArgs e)
			{
			if (!m_fInitialized)
				return;

			FavoriteRadioButton.Checked = FavoriteRadioButton.Checked ? false : true;

			//----------------------------------------------------------------------------*
			// If it's a favorite, see if it's the max charge
			//----------------------------------------------------------------------------*

			if (FavoriteRadioButton.Checked)
				{
				double dPowderWeight = PowderWeightTextBox.Value;

				bool fMax = true;

				foreach (cCharge Charge in m_Load.ChargeList)
					{
					if (dPowderWeight < Charge.PowderWeight)
						{
						fMax = false;
						break;
						}
					}

				//----------------------------------------------------------------------------*
				// It's the max charege, verify that the user wants to make it a fave
				//----------------------------------------------------------------------------*

				if (fMax)
					{
					string strMessage = String.Format("{0:F1} grains is currently the maximum powder weight for this load.  Are you sure you want to mark it as a favorite?", dPowderWeight);

					if (MessageBox.Show(strMessage, "Verify Selection", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1) != DialogResult.Yes)
						{
						FavoriteRadioButton.Checked = false;
						}
					}
				}

			//----------------------------------------------------------------------------*
			// If favorite, uncheck reject
			//----------------------------------------------------------------------------*

			if (FavoriteRadioButton.Checked)
				RejectRadioButton.Checked = false;

			//----------------------------------------------------------------------------*
			// Record the selections
			//----------------------------------------------------------------------------*

			m_Charge.Favorite = FavoriteRadioButton.Checked;
			m_Charge.Reject = RejectRadioButton.Checked;

			UpdateButtons();
			}

		//============================================================================*
		// OnFillRatioChanged()
		//============================================================================*

		private void OnFillRatioChanged(object sender, EventArgs e)
			{
			if (!m_fInitialized)
				return;

			m_Charge.FillRatio = FillRatioTextBox.Value;

			UpdateButtons();
			}

		//============================================================================*
		// OnPowderWeightChanged()
		//============================================================================*

		private void OnPowderWeightChanged(object sender, EventArgs e)
			{
			if (!m_fInitialized)
				return;

			m_Charge.PowderWeight = cDataFiles.MetricToStandard(PowderWeightTextBox.Value, cDataFiles.eDataType.PowderWeight);

			UpdateButtons();
			}

		//============================================================================*
		// OnRejectClicked()
		//============================================================================*

		private void OnRejectClicked(object sender, EventArgs e)
			{
			if (!m_fInitialized)
				return;

			RejectRadioButton.Checked = RejectRadioButton.Checked ? false : true;

			if (RejectRadioButton.Checked)
				FavoriteRadioButton.Checked = false;

			m_Charge.Favorite = FavoriteRadioButton.Checked;
			m_Charge.Reject = RejectRadioButton.Checked;

			UpdateButtons();
			}

		//============================================================================*
		// OnRemoveChargeTest()
		//============================================================================*

		private void OnRemoveChargeTest(object sender, EventArgs e)
			{
			//----------------------------------------------------------------------------*
			// Get the selected charge test
			//----------------------------------------------------------------------------*

			if (ChargeTestListView.SelectedItems.Count > 0)
				{
				cChargeTest ChargeTest = (cChargeTest) ChargeTestListView.SelectedItems[0].Tag;

				if (ChargeTest != null)
					{
					if (MessageBox.Show("Are you sure you wish to delete the selected test data?", "Deletion Verification", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
						{
						m_Charge.TestList.Remove(ChargeTest);

						PopulateChargeTestListView();
						}
					}
				}
			}

		//============================================================================*
		// OnTestSelected()
		//============================================================================*

		private void OnTestSelected(object sender, EventArgs e)
			{
			UpdateButtons();
			}

		//============================================================================*
		// PopulateChargeData()
		//============================================================================*

		private void PopulateChargeData()
			{
			PowderWeightTextBox.Value = cDataFiles.StandardToMetric(m_Charge.PowderWeight, cDataFiles.eDataType.PowderWeight);
			FillRatioTextBox.Value = m_Charge.FillRatio;

			FavoriteRadioButton.Checked = m_Charge.Favorite;
			RejectRadioButton.Checked = m_Charge.Reject;

			PopulateChargeTestListView();
			}

		//============================================================================*
		// PopulateChargeTestListView()
		//============================================================================*

		private void PopulateChargeTestListView()
			{
			//----------------------------------------------------------------------------*
			// Create the format strings
			//----------------------------------------------------------------------------*

			string strFirearmFormat = "{0:F";
			strFirearmFormat += String.Format("{0:G0}", m_DataFiles.Preferences.FirearmDecimals);
			strFirearmFormat += "}";

			string strGroupFormat = "{0:F";
			strGroupFormat += String.Format("{0:G0}", m_DataFiles.Preferences.GroupDecimals);
			strGroupFormat += "}";

			//----------------------------------------------------------------------------*
			// ChargeTestListView Columns
			//----------------------------------------------------------------------------*

			foreach (ColumnHeader Header in ChargeTestListView.Columns)
				{
				int nWidth = m_DataFiles.Preferences.GetColumnWidth(cPreferences.eApplicationListView.ChargeTestListView, Header.Text);

				if (nWidth != 0)
					Header.Width = nWidth;
				}

			//----------------------------------------------------------------------------*
			// ChargeTestListView Data
			//----------------------------------------------------------------------------*

			ChargeTestListView.Items.Clear();

			foreach (cChargeTest ChargeTest in m_Charge.TestList)
				{
				ListViewItem Item = new ListViewItem(ChargeTest.Source);

				Item.Tag = ChargeTest;

				Item.SubItems.Add(String.Format(strFirearmFormat, ChargeTest.BarrelLength));

				string strFormat = "1 in " + strFirearmFormat + " {1}";

				Item.SubItems.Add(String.Format(strFormat, cDataFiles.StandardToMetric(ChargeTest.Twist, cDataFiles.eDataType.Firearm), cDataFiles.MetricString(cDataFiles.eDataType.Firearm)));
				Item.SubItems.Add(String.Format("{0:N0}", cDataFiles.StandardToMetric(ChargeTest.MuzzleVelocity, cDataFiles.eDataType.Velocity)));
				Item.SubItems.Add(String.Format("{0:N0}", ChargeTest.Pressure));
				Item.SubItems.Add(String.Format(strGroupFormat, cDataFiles.StandardToMetric(ChargeTest.BestGroup, cDataFiles.eDataType.GroupSize)));
				Item.SubItems.Add(String.Format("{0:N0}", cDataFiles.StandardToMetric(ChargeTest.BestGroupRange, cDataFiles.eDataType.Range)));

				try
					{
					ChargeTestListView.Items.Add(Item);
					}
				catch
					{
					}

				UpdateButtons();
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

			cDataFiles.SetMetricLabel(ChargeMeasurementLabel, cDataFiles.eDataType.PowderWeight);

			//----------------------------------------------------------------------------*
			// Set Text Box Parameters
			//----------------------------------------------------------------------------*

			cDataFiles.SetInputParameters(PowderWeightTextBox, cDataFiles.eDataType.PowderWeight);
			}

		//============================================================================*
		// SetStaticToolTips()
		//============================================================================*

		private void SetStaticToolTips()
			{
			if (!m_DataFiles.Preferences.ToolTips)
				return;

			PowderWeightTextBox.ToolTip = cm_strPowderWeightToolTip;
			FillRatioTextBox.ToolTip = cm_strFillRatioToolTip;

			m_FavoriteToolTip.ShowAlways = true;
			m_FavoriteToolTip.RemoveAll();
			m_FavoriteToolTip.SetToolTip(FavoriteRadioButton, cm_strFavoriteToolTip);

			m_RejectToolTip.ShowAlways = true;
			m_RejectToolTip.RemoveAll();
			m_RejectToolTip.SetToolTip(RejectRadioButton, cm_strRejectToolTip);

			m_TestListToolTip.ShowAlways = true;
			m_TestListToolTip.RemoveAll();
			m_TestListToolTip.SetToolTip(ChargeTestListView, cm_strTestListToolTip);

			m_ChargeOKButtonToolTip.ShowAlways = true;
			m_ChargeOKButtonToolTip.RemoveAll();
			m_ChargeOKButtonToolTip.SetToolTip(ChargeOKButton, cm_strChargeOKButtonToolTip);

			m_ChargeCancelButtonToolTip.ShowAlways = true;
			m_ChargeCancelButtonToolTip.RemoveAll();
			m_ChargeCancelButtonToolTip.SetToolTip(ChargeCancelButton, cm_strChargeCancelButtonToolTip);
			}

		//============================================================================*
		// UpdateButtons()
		//============================================================================*

		private void UpdateButtons()
			{
			if (m_fViewOnly)
				return;

			bool fEnableOK = true;
			string strToolTip = "";
			bool fDuplicate = false;

			//----------------------------------------------------------------------------*
			// Check PowderWeight
			//----------------------------------------------------------------------------*

			if (!PowderWeightTextBox.ValueOK || m_Charge.PowderWeight == 0.0)
				{
				fEnableOK = false;

				AddChargeTestButton.Enabled = false;
				}
			else
				{
				//----------------------------------------------------------------------------*
				// Check for Duplicate
				//----------------------------------------------------------------------------*

				fDuplicate = false;

				if (PowderWeightTextBox.Value != cDataFiles.StandardToMetric(m_dOriginalCharge, cDataFiles.eDataType.PowderWeight))
					{
					foreach (cCharge CheckCharge in m_Load.ChargeList)
						{
						if (cDataFiles.StandardToMetric(CheckCharge.PowderWeight, cDataFiles.eDataType.PowderWeight) == PowderWeightTextBox.Value)
							{
							fDuplicate = true;

							fEnableOK = false;

							PowderWeightTextBox.BackColor = Color.LightPink;

							string strErrorMessage = String.Format("This powder weight, \"{0:F1} {1}\", already exists for this load.  Duplicate charges are not allowed.", PowderWeightTextBox.Value, cDataFiles.MetricString(cDataFiles.eDataType.PowderWeight));

							strToolTip += strErrorMessage;

							ErrorMessageLabel.Text = strErrorMessage;

							break;
							}
						}
					}

				if (!fDuplicate)
					{
					AddChargeTestButton.Enabled = fEnableOK;

					PowderWeightTextBox.BackColor = SystemColors.Window;

					//----------------------------------------------------------------------------*
					// Check if this powder weight can be modified
					//----------------------------------------------------------------------------

					if (m_fEditCharge)
						{
						int nNumBatches = 0;

						foreach (cBatch Batch in m_DataFiles.BatchList)
							{
							if (Batch.Load.CompareTo(m_Load) == 0)
								{
								if (Batch.PowderWeight == Charge.PowderWeight)
									nNumBatches++;
								}
							}

						if (nNumBatches > 0)
							{
							ErrorMessageLabel.Text = String.Format("This powder weight for this load has been used in {0:N0} batch{1} and may not be changed.  Fill Ratio, Favorite, and Reject selections may be changed.", nNumBatches, nNumBatches > 1 ? "es" : "");

							m_fEditCharge = false;
							}
						else
							ErrorMessageLabel.Text = "";
						}

					EnableChanges();
					}
				}

			//----------------------------------------------------------------------------*
			// Check Fill Ratio
			//----------------------------------------------------------------------------*

			if (!FillRatioTextBox.ValueOK)
				fEnableOK = false;

			//----------------------------------------------------------------------------*
			// Check ChargeTestListView
			//----------------------------------------------------------------------------

			AddChargeTestButton.Enabled = fEnableOK;

			if (!fEnableOK || fDuplicate || ChargeTestListView.SelectedItems.Count == 0)
				{
				EditChargeTestButton.Enabled = false;
				RemoveChargeTestButton.Enabled = false;
				}
			else
				{
				if (ChargeTestListView.SelectedItems.Count > 0)
					{
					cChargeTest ChargeTest = (cChargeTest) ChargeTestListView.SelectedItems[0].Tag;

					if (!ChargeTest.BatchTest)
						{
						EditChargeTestButton.Enabled = true;
						RemoveChargeTestButton.Enabled = true;
						}
					else
						{
						EditChargeTestButton.Enabled = false;
						RemoveChargeTestButton.Enabled = false;
						}
					}
				}

			ChargeOKButton.Enabled = fEnableOK;
			}
		}
	}
