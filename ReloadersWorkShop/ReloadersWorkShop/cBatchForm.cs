﻿//============================================================================*
// cBatchForm.cs
//
// Copyright © 2013-2017, Kevin S. Beebe
// All Rights Reserved
//============================================================================*

//============================================================================*
// .Net Using Statements
//============================================================================*

using System;
using System.Drawing;
using System.Windows.Forms;

using ReloadersWorkShop.Preferences;
using RWCommonLib.Registry;

//============================================================================*
// NameSpace
//============================================================================*

namespace ReloadersWorkShop
	{
	//============================================================================*
	// rOCW Structure
	//============================================================================*

	public struct rOCW
		{
		public int m_nMaxBatches;
		public int m_nNumRounds;
		public double m_dStartCharge;
		public double m_dChargeIncrement;

		public rOCW(rOCW OCW)
			{
			m_dStartCharge = 0.0;
			m_dChargeIncrement = 0.0;
			m_nMaxBatches = 0;
			m_nNumRounds = 0;

			Copy(OCW);
			}

		public void Copy(rOCW OCW)
			{
			m_dChargeIncrement = OCW.m_dChargeIncrement;
			m_dStartCharge = OCW.m_dStartCharge;
			m_nMaxBatches = OCW.m_nMaxBatches;
			m_nNumRounds = OCW.m_nNumRounds;
			}
		}

	//============================================================================*
	// cBatchForm Class
	//============================================================================*

	public partial class cBatchForm : Form
		{
		//============================================================================*
		// Private constants
		//============================================================================*

		private const string cm_strNumRoundsToolTip = "Number of rounds to be loaded.";
		private const string cm_strUserIDToolTip = "Optional user-defined, alpha-numeric ID for this batch.";
		private const string cm_strTimesFiredToolTip = "Number of times the cases in this batch have been fired previously.";
		private const string cm_strCOLToolTip = "Overall length of the cartridges loaded from the head of the case to the tip of the bullet.";
		private const string cm_strTrimLengthToolTip = "Trim length of the cases loaded.";
		private const string cm_strHeadSpaceToolTip = "Headspace of the cartridges loaded. If not known, enter 0.000.";
		private const string cm_strNeckSizeToolTip = "Neck diameter of the cartridges loaded. If not known, enter 0.000.";
		private const string cm_strNeckWallToolTip = "Neck wall thickness of the cases used for this batch. If not known, enter 0.000.";
		private const string cm_strCBTOToolTip = "Measurement of the cartridges from the case head to the Ogive of the bullet. If not known, enter 0.000.";

		//============================================================================*
		// Private Data Members
		//============================================================================*

		private cBatchLoadListView m_BatchLoadListView = null;
		private cFirearm.eFireArmType m_eFirearmType = cFirearm.eFireArmType.None;

		private bool m_fAdd = false;

		private int m_nInitalRounds = 0;

		private bool m_fViewOnly = false;
		private bool m_fUserViewOnly = false;
		private bool m_fInitialized = false;
		private bool m_fForceUpdate = false;
		private bool m_fPopulating = false;

		private cBatch m_Batch = null;

		private cDataFiles m_DataFiles = null;
		private cRWRegistry m_RWRegistry = null;

		private rOCW m_rOCW = new rOCW();

		//============================================================================*
		// cBatchForm() - Constructor
		//============================================================================*

		public cBatchForm(cBatch Batch, cDataFiles DataFiles, cRWRegistry RWRegistry, cFirearm.eFireArmType eFirearmType = cFirearm.eFireArmType.None, bool fViewOnly = false, bool fAdd = false)
			{
			Cursor = Cursors.WaitCursor;

			InitializeComponent();

			m_DataFiles = DataFiles;
			m_RWRegistry = RWRegistry;

			m_eFirearmType = eFirearmType;

			m_fViewOnly = fViewOnly;
			m_fUserViewOnly = fViewOnly;

			TestDataButton.Click += OnTestDataClicked;
			PrintButton.Click += OnPrintClicked;
			BatchCancelButton.Click += OnCancelClicked;

			//----------------------------------------------------------------------------*
			// Create the m_Batch object
			//----------------------------------------------------------------------------*

			if (Batch == null || fAdd)
				{
				if (m_fUserViewOnly)
					return;

				BatchOKButton.Text = "Add";

				m_fAdd = true;

				if (Batch != null)
					m_Batch = new cBatch(Batch);
				else
					m_Batch = new cBatch();

				m_Batch.BatchID = m_DataFiles.Preferences.NextBatchID;
				m_Batch.OCWBatchID = 0;
				m_Batch.UserID = "";
				m_Batch.DateLoaded = DateTime.Today;
				m_Batch.TrackInventory = m_DataFiles.Preferences.TrackInventory;
				m_Batch.BatchTest = null;

				m_nInitalRounds = m_Batch.NumRounds;

				m_Batch.NumRounds = 0;
				}
			else
				{
				m_Batch = new cBatch(Batch);

				m_nInitalRounds = Batch.NumRounds;
				}

			SetClientSizeCore(LoadDataGroupBox.Location.X + LoadDataGroupBox.Width + 10, BatchCancelButton.Location.Y + BatchCancelButton.Height + 20);

			//----------------------------------------------------------------------------*
			// Finish Initialization
			//----------------------------------------------------------------------------*

			Initialize();

			SetStaticToolTips();

			m_fInitialized = true;

			Cursor = Cursors.Default;
			}

		//============================================================================*
		// Batch Property
		//============================================================================*

		public cBatch Batch
			{
			get
				{
				return (m_Batch);
				}
			set
				{
				m_Batch = value;
				}
			}

		//============================================================================*
		// GetBatchData()
		//============================================================================*

		private void GetBatchData()
			{
			//----------------------------------------------------------------------------*
			// Load
			//----------------------------------------------------------------------------*

			m_Batch.Load = (cLoad)m_BatchLoadListView.SelectedItems[0].Tag;

			//----------------------------------------------------------------------------*
			// PowderWeight
			//----------------------------------------------------------------------------*

			cCharge Charge = null;

			if (ChargeCombo.SelectedIndex >= 0)
				Charge = (cCharge)ChargeCombo.SelectedItem;

			double dPowderWeight = 0.0;

			if (Charge != null)
				dPowderWeight = Charge.PowderWeight;

			m_Batch.PowderWeight = dPowderWeight;

			//----------------------------------------------------------------------------*
			// Firearm
			//----------------------------------------------------------------------------*

			if (FirearmCombo.Text != "Any Firearm")
				m_Batch.Firearm = (cFirearm)FirearmCombo.SelectedItem;
			else
				m_Batch.Firearm = null;

			//----------------------------------------------------------------------------*
			// Batch ID
			//----------------------------------------------------------------------------*

			string strBatchID = BatchIDLabel.Text;

			strBatchID = strBatchID.Trim();

			int nIndex = strBatchID.IndexOf(' ');

			if (nIndex > 0)
				strBatchID = strBatchID.Substring(0, nIndex);

			int nBatchID = 0;

			Int32.TryParse(strBatchID, out nBatchID);

			if (nBatchID == 0)
				Console.WriteLine("Here!");

			m_Batch.BatchID = nBatchID;

			//----------------------------------------------------------------------------*
			// User ID
			//----------------------------------------------------------------------------*

			m_Batch.UserID = UserIDTextBox.Value;

			//----------------------------------------------------------------------------*
			// Date Loaded
			//----------------------------------------------------------------------------*

			m_Batch.DateLoaded = BatchDateTimePicker.Value;

			//----------------------------------------------------------------------------*
			// NumRounds
			//----------------------------------------------------------------------------*

			m_Batch.NumRounds = NumRoundsTextBox.Value;

			//----------------------------------------------------------------------------*
			// Trim Length
			//----------------------------------------------------------------------------*

			m_Batch.CaseTrimLength = cDataFiles.MetricToStandard(CaseTrimLengthTextBox.Value, cDataFiles.eDataType.Dimension);

			//----------------------------------------------------------------------------*
			// COL
			//----------------------------------------------------------------------------*

			m_Batch.COL = cDataFiles.MetricToStandard(COALTextBox.Value, cDataFiles.eDataType.Dimension);

			//----------------------------------------------------------------------------*
			// CBTO
			//----------------------------------------------------------------------------*

			m_Batch.CBTO = cDataFiles.MetricToStandard(CBTOTextBox.Value, cDataFiles.eDataType.Dimension);

			//----------------------------------------------------------------------------*
			// Jump Set
			//----------------------------------------------------------------------------*

			m_Batch.JumpSet = JumpSetCheckBox.Checked;

			//----------------------------------------------------------------------------*
			// Jump
			//----------------------------------------------------------------------------*

			m_Batch.Jump = cDataFiles.MetricToStandard(JumpTextBox.Value, cDataFiles.eDataType.Dimension);

			//----------------------------------------------------------------------------*
			// Head Space
			//----------------------------------------------------------------------------*

			m_Batch.HeadSpace = cDataFiles.MetricToStandard(HeadSpaceTextBox.Value, cDataFiles.eDataType.Dimension);

			//----------------------------------------------------------------------------*
			// Bullet Diameter
			//----------------------------------------------------------------------------*

			m_Batch.BulletDiameter = cDataFiles.MetricToStandard(BulletDiameterTextBox.Value, cDataFiles.eDataType.Dimension);

			//----------------------------------------------------------------------------*
			// Neck Size
			//----------------------------------------------------------------------------*

			m_Batch.NeckSize = cDataFiles.MetricToStandard(NeckSizeTextBox.Value, cDataFiles.eDataType.Dimension);

			//----------------------------------------------------------------------------*
			// Neck wall
			//----------------------------------------------------------------------------*

			m_Batch.NeckWall = cDataFiles.MetricToStandard(NeckWallTextBox.Value, cDataFiles.eDataType.Dimension);

			//----------------------------------------------------------------------------*
			// Times Fired
			//----------------------------------------------------------------------------*

			m_Batch.TimesFired = TimesFiredTextBox.Value;

			//----------------------------------------------------------------------------*
			// Case Sizing
			//----------------------------------------------------------------------------*

			m_Batch.FullLengthSized = FullLengthSizedRadioButton.Checked;
			m_Batch.NeckSized = NeckSizedRadioButton.Checked;
			m_Batch.ExpandedNeck = ExpandedNeckRadioButton.Checked;
			m_Batch.GasCheck = GasCheckCheckBox.Checked;
			m_Batch.NeckTurned = NeckTurnedCheckBox.Checked;
			m_Batch.ModifiedBullet = ModifiedBulletCheckBox.Checked;
			m_Batch.Annealed = AnnealedCheckBox.Checked;
			}

		//============================================================================*
		// Initialize()
		//============================================================================*

		private void Initialize()
			{
			if (!m_fViewOnly && !m_fUserViewOnly)
				{
				BatchOKButton.Visible = true;

				if (m_fAdd)
					BatchOKButton.Text = "Add";
				else
					BatchOKButton.Text = "Update";

				int nButtonX = (this.Size.Width / 2) - ((BatchOKButton.Width + PrintButton.Width + BatchCancelButton.Width + 40) / 2);

				BatchOKButton.Location = new Point(nButtonX, BatchOKButton.Location.Y);
				nButtonX += BatchOKButton.Width + 20;

				PrintButton.Location = new Point(nButtonX, PrintButton.Location.Y);
				nButtonX += PrintButton.Width + 20;

				NumRoundsRangeLabel.Visible = m_Batch.TrackInventory && m_Batch.BatchTest == null;

				BatchCancelButton.Location = new Point(nButtonX, BatchCancelButton.Location.Y);

				BatchCancelButton.Text = "Cancel";
				}
			else
				{
				BatchOKButton.Visible = false;

				NumRoundsRangeLabel.Visible = false;

				int nButtonX = (this.Size.Width / 2) - ((PrintButton.Width + BatchCancelButton.Width + 20) / 2);

				PrintButton.Location = new Point(nButtonX, PrintButton.Location.Y);
				nButtonX += PrintButton.Width + 20;

				BatchCancelButton.Location = new Point(nButtonX, BatchCancelButton.Location.Y);

				BatchCancelButton.Text = "Close";
				}

			//----------------------------------------------------------------------------*
			// Create the Batch Load List View
			//----------------------------------------------------------------------------*

			m_BatchLoadListView = new cBatchLoadListView(m_DataFiles, m_Batch, !m_fAdd);

			m_BatchLoadListView.Location = new Point(6, BatchLoadLabel.Location.Y + BatchLoadLabel.Height + 6);
			m_BatchLoadListView.Size = new Size(LoadDataGroupBox.Width - 12, LoadDetailsGroup.Location.Y - BatchLoadLabel.Location.Y - BatchLoadLabel.Height - 12);

			LoadDataGroupBox.Controls.Add(m_BatchLoadListView);

			//----------------------------------------------------------------------------*
			// Set Control Event Handlers
			//----------------------------------------------------------------------------*

			if (!m_fViewOnly && !m_fUserViewOnly && !m_Batch.Archived)
				{
				BatchDateTimePicker.Enabled = m_Batch.BatchTest == null;
				NumRoundsTextBox.ReadOnly = m_Batch.BatchTest != null;

				CaseTrimLengthTextBox.ReadOnly = false;
				COALTextBox.ReadOnly = false;
				CBTOTextBox.ReadOnly = false;
				HeadSpaceTextBox.ReadOnly = false;

				TimesFiredTextBox.ReadOnly = false;
				NeckSizeTextBox.ReadOnly = false;
				NeckWallTextBox.ReadOnly = false;

				if (m_Batch.BatchTest == null)
					{
					FirearmTypeCombo.SelectedIndexChanged += OnFirearmTypeChanged;
					BulletCombo.SelectedIndexChanged += OnBulletChanged;
					CaliberCombo.SelectedIndexChanged += OnCaliberChanged;
					PowderCombo.SelectedIndexChanged += OnPowderChanged;

					ChargeCombo.SelectedIndexChanged += OnChargeChanged;
					FirearmCombo.SelectedIndexChanged += OnFirearmChanged;
					FirearmTransferButton.Click += OnFirearmTransferClicked;

					NumRoundsTextBox.TextChanged += OnNumRoundsTextChanged;

					m_BatchLoadListView.SelectedIndexChanged += OnLoadSelected;
					m_BatchLoadListView.DoubleClick += OnBatchLoadDoubleClicked;
					}

				if (m_fAdd)
					{
					OCWCheckBox.Enabled = true;

					OCWCheckBox.Click += OnOCWClicked;
					}
				else
					{
					OCWCheckBox.Checked = m_Batch.OCWBatchID != 0;
					OCWCheckBox.Enabled = false;
					}

				CaseTrimLengthTextBox.TextChanged += OnCaseTrimLengthTextChanged;
				COALTextBox.TextChanged += OnCOALTextChanged;
				CBTOTextBox.TextChanged += OnCBTOTextChanged;
				HeadSpaceTextBox.TextChanged += OnHeadSpaceTextChanged;

				BulletDiameterTextBox.TextChanged += OnBulletDiameterChanged;
				NeckSizeTextBox.TextChanged += OnNeckSizeTextChanged;
				NeckWallTextBox.TextChanged += OnNeckWallTextChanged;

				JumpSetCheckBox.Click += OnJumpSetClicked;
				JumpTextBox.TextChanged += OnJumpChanged;

				ViewChargeButton.Click += OnViewChargeClicked;

				TimesFiredTextBox.TextChanged += OnTimesFiredTextChanged;
				FullLengthSizedRadioButton.Click += OnFullLengthSizeClicked;
				NeckSizedRadioButton.Click += OnNeckSizedClicked;
				ExpandedNeckRadioButton.Click += OnExpandedNeckClicked;
				GasCheckCheckBox.Click += OnGasCheckClicked;
				NeckTurnedCheckBox.Click += OnNeckTurnedClicked;
				AnnealedCheckBox.Click += OnAnnealedClicked;
				ModifiedBulletCheckBox.Click += OnModifiedBulletClicked;

				BatchOKButton.Click += OnOKClicked;
				}
			else
				{
				FirearmTypeCombo.Enabled = false;

				BatchDateTimePicker.Enabled = false;
				NumRoundsTextBox.ReadOnly = true;

				CaseTrimLengthTextBox.ReadOnly = true;
				COALTextBox.ReadOnly = true;
				CBTOTextBox.ReadOnly = true;
				HeadSpaceTextBox.ReadOnly = true;

				BulletDiameterTextBox.ReadOnly = true;
				NeckSizeTextBox.ReadOnly = true;
				NeckWallTextBox.ReadOnly = true;

				TimesFiredTextBox.ReadOnly = true;
				FullLengthSizedRadioButton.Enabled = false;
				NeckSizedRadioButton.Enabled = false;
				ExpandedNeckRadioButton.Enabled = false;
				GasCheckCheckBox.Enabled = false;
				NeckTurnedCheckBox.Enabled = false;
				AnnealedCheckBox.Enabled = false;
				ModifiedBulletCheckBox.Enabled = false;
				}

			//----------------------------------------------------------------------------*
			// Make sure there are firearms in the database for this type and caliber
			//----------------------------------------------------------------------------*

			bool fFirearmFound = false;

			if (m_Batch != null && m_Batch.Load != null)
				{
				foreach (cFirearm CheckFirearm in m_DataFiles.FirearmList)
					{
					if (CheckFirearm.HasCaliber(m_Batch.Load.Caliber) && CheckFirearm.FirearmType == m_Batch.Load.FirearmType)
						fFirearmFound = true;
					}
				}

			if (!fFirearmFound)
				TestDataButton.Enabled = false;

			//----------------------------------------------------------------------------*
			// Populate the firearm type combo
			//----------------------------------------------------------------------------*

			if (m_Batch.Load != null && m_Batch.Load.FirearmType != cFirearm.eFireArmType.None)
				FirearmTypeCombo.Value = m_Batch.Load.FirearmType;
			else
				FirearmTypeCombo.Value = m_eFirearmType;

			//----------------------------------------------------------------------------*
			// start the chain of combo box populations
			//----------------------------------------------------------------------------*

			PopulateCaliberCombo();

			//----------------------------------------------------------------------------*
			// Set Title
			//----------------------------------------------------------------------------*

			string strTitle;

			if (m_fAdd)
				{
				strTitle = "Add";
				}
			else
				{
				if (!m_fViewOnly)
					strTitle = "Edit";
				else
					strTitle = "View";
				}

			strTitle += " Batch";

			Text = strTitle;

			//----------------------------------------------------------------------------*
			// Set Batch Data if this is a new batch
			//----------------------------------------------------------------------------*

			SetInputParameters();

			if (m_fAdd)
				SetBatchData();

			//----------------------------------------------------------------------------*
			// Update buttons and exit
			//----------------------------------------------------------------------------*

			UpdateButtons();
			}

		//============================================================================*
		// OCW Property
		//============================================================================*

		public bool OCW
			{
			get
				{
				return (OCWCheckBox.Checked);
				}
			}

		//============================================================================*
		// OCWBatchCount()
		//============================================================================*

		public static int OCWBatchCount(rOCW OCWSettings, cBatch Batch, cDataFiles DataFiles)
			{
			int nCount = 0;

			if (Batch != null && Batch.Load != null)
				{
				double dInc = Math.Round(OCWSettings.m_dChargeIncrement, DataFiles.Preferences.PowderWeightDecimals);

				if (dInc <= 0.0)
					dInc = 0.2;

				double dCharge = OCWSettings.m_dStartCharge;

				cCharge Charge = Batch.Load.ChargeList.MaxCharge;

				if (Charge != null)
					{
					while (Math.Round(dCharge, DataFiles.Preferences.PowderWeightDecimals) <= Math.Round(Charge.PowderWeight, DataFiles.Preferences.PowderWeightDecimals))
						{
						nCount++;

						dCharge = Math.Round(dCharge += dInc, DataFiles.Preferences.PowderWeightDecimals);
						}
					}
				}

			return (nCount);
			}

		//============================================================================*
		// OCWSettings Property
		//============================================================================*

		public rOCW OCWSettings
			{
			get
				{
				return (m_rOCW);
				}
			}

		//============================================================================*
		// OnAnnealedClicked()
		//============================================================================*

		private void OnAnnealedClicked(object sender, EventArgs e)
			{
			if (m_fViewOnly || m_fUserViewOnly || m_fPopulating)
				return;

			AnnealedCheckBox.Checked = !AnnealedCheckBox.Checked;

			m_Batch.Annealed = AnnealedCheckBox.Checked;

			UpdateButtons();
			}

		//============================================================================*
		// OnBatchLoadDoubleClicked()
		//============================================================================*

		protected void OnBatchLoadDoubleClicked(object sender, EventArgs args)
			{
			if (!m_fInitialized)
				return;

			if (m_BatchLoadListView.SelectedItems.Count > 0)
				{
				cLoad Load = (cLoad)m_BatchLoadListView.SelectedItems[0].Tag;

				cLoadForm LoadForm = new cLoadForm(Load, m_DataFiles, true);

				LoadForm.ShowDialog();
				}
			}

		//============================================================================*
		// OnBulletChanged()
		//============================================================================*

		private void OnBulletChanged(object sender, EventArgs e)
			{
			if (!m_fInitialized || m_fPopulating)
				return;

			if (BulletCombo.SelectedIndex > 0)
				{
				cBullet Bullet = (cBullet)BulletCombo.SelectedItem;

				m_DataFiles.Preferences.LastBatchLoadBulletSelected = Bullet;
				}

			PopulatePowderCombo();
			}

		//============================================================================*
		// OnBulletDiameterChanged()
		//============================================================================*

		private void OnBulletDiameterChanged(object sender, EventArgs e)
			{
			if (!m_fInitialized || m_fPopulating)
				return;

			m_Batch.BulletDiameter = cDataFiles.MetricToStandard(BulletDiameterTextBox.Value, cDataFiles.eDataType.Dimension);

			SetNeckTension();

			UpdateButtons();
			}

		//============================================================================*
		// OnCancelClicked()
		//============================================================================*

		private void OnCancelClicked(object sender, EventArgs e)
			{
			if (m_fForceUpdate)
				{
				OnOKClicked(sender, e);

				DialogResult = System.Windows.Forms.DialogResult.OK;
				}
			}

		//============================================================================*
		// OnCaliberChanged()
		//============================================================================*

		private void OnCaliberChanged(object sender, EventArgs e)
			{
			if (!m_fInitialized || m_fPopulating)
				return;

			if (CaliberCombo.SelectedIndex > 0)
				{
				cCaliber Caliber = (cCaliber)CaliberCombo.SelectedItem;

				m_DataFiles.Preferences.LastBatchLoadCaliberSelected = Caliber;

				if (m_Batch.Load != null && m_Batch.Load.Caliber.CompareTo(Caliber) != 0)
					m_Batch.Load = null;
				}

			PopulateBulletCombo();
			}

		//============================================================================*
		// OnCaseTrimLengthTextChanged()
		//============================================================================*

		private void OnCaseTrimLengthTextChanged(object sender, EventArgs e)
			{
			if (!m_fInitialized || m_fPopulating)
				return;

			m_Batch.CaseTrimLength = cDataFiles.MetricToStandard(CaseTrimLengthTextBox.Value, cDataFiles.eDataType.Dimension);

			UpdateButtons();
			}

		//============================================================================*
		// OnChargeChanged()
		//============================================================================*

		private void OnChargeChanged(object sender, EventArgs e)
			{
			if (!m_fInitialized || m_fPopulating)
				return;

			cCharge Charge = null;

			if (ChargeCombo.SelectedIndex >= 0)
				Charge = (cCharge)ChargeCombo.SelectedItem;

			double dPowderCharge = 0.0;

			if (Charge != null)
				dPowderCharge = Charge.PowderWeight;

			//			m_Batch.PowderWeight = cDataFiles.MetricToStandard(dPowderCharge, cDataFiles.eDataType.PowderWeight);
			m_Batch.PowderWeight = dPowderCharge;

			PopulateLoadDetails();

			UpdateButtons();
			}

		//============================================================================*
		// OnCOALTextChanged()
		//============================================================================*

		private void OnCOALTextChanged(object sender, EventArgs e)
			{
			if (!m_fInitialized || m_fPopulating)
				return;

			m_Batch.COL = cDataFiles.MetricToStandard(COALTextBox.Value, cDataFiles.eDataType.Dimension);

			UpdateButtons();
			}

		//============================================================================*
		// OnExpandedNeckClicked()
		//============================================================================*

		private void OnExpandedNeckClicked(object sender, EventArgs e)
			{
			if (m_fViewOnly || m_fUserViewOnly || m_fPopulating)
				return;

			ExpandedNeckRadioButton.Checked = !ExpandedNeckRadioButton.Checked;

			if (ExpandedNeckRadioButton.Checked)
				{
				FullLengthSizedRadioButton.Checked = false;
				NeckSizedRadioButton.Checked = false;
				}

			m_Batch.FullLengthSized = FullLengthSizedRadioButton.Checked;
			m_Batch.NeckSized = NeckSizedRadioButton.Checked;
			m_Batch.ExpandedNeck = ExpandedNeckRadioButton.Checked;

			UpdateButtons();
			}

		//============================================================================*
		// OnFirearmChanged()
		//============================================================================*

		private void OnFirearmChanged(object sender, EventArgs e)
			{
			if (!m_fInitialized || m_fPopulating)
				return;

			if (FirearmCombo.SelectedIndex > 0)
				m_Batch.Firearm = (cFirearm)FirearmCombo.SelectedItem;
			else
				m_Batch.Firearm = null;

			PopulateFirearmData();

			UpdateButtons();
			}

		//============================================================================*
		// OnFirearmTransferClicked()
		//============================================================================*

		private void OnFirearmTransferClicked(object sender, EventArgs e)
			{
			if (FirearmCombo.SelectedIndex > 0)
				{
				cFirearm Firearm = m_Batch.Firearm;

				if (Firearm != null)
					{
					if (FirearmHeadSpaceLabel.Text != "N/A")
						m_Batch.HeadSpace = Firearm.HeadSpace;

					if (FirearmNeckLabel.Text != "N/A")
						m_Batch.NeckSize = Firearm.Neck;

					//----------------------------------------------------------------------------*
					// See if this firearm has custom bullet info
					//----------------------------------------------------------------------------*

					foreach (cFirearmBullet FirearmBullet in Firearm.FirearmBulletList)
						{
						if (FirearmBullet.Bullet.CompareTo(m_Batch.Load.Bullet) == 0)
							{
							if (FirearmCOLLabel.Text != "N/A")
								{
								double dCOL = 0.0;

								Double.TryParse(FirearmCOLLabel.Text, out dCOL);

								m_Batch.COL = cDataFiles.MetricToStandard(dCOL, cDataFiles.eDataType.Dimension);
								}

							if (FirearmCBTOLabel.Text != "N/A")
								m_Batch.CBTO = FirearmBullet.CBTO;

							if (FirearmJumpLabel.Text != "N/A")
								m_Batch.Jump = FirearmBullet.Jump;

							break;
							}
						}
					}
				}

			PopulateBatchData();

			UpdateButtons();
			}

		//============================================================================*
		// OnFirearmTypeChanged()
		//============================================================================*

		private void OnFirearmTypeChanged(object sender, EventArgs e)
			{
			if (!m_fInitialized || m_fPopulating)
				return;

			if (FirearmTypeCombo.Value == cFirearm.eFireArmType.Rifle)
				{
				FullLengthSizedRadioButton.Enabled = true;
				NeckSizedRadioButton.Enabled = true;
				ExpandedNeckRadioButton.Enabled = true;

				FullLengthSizedRadioButton.Checked = m_Batch.FullLengthSized;
				NeckSizedRadioButton.Checked = m_Batch.NeckSized;
				ExpandedNeckRadioButton.Checked = m_Batch.ExpandedNeck;
				}
			else
				{
				FullLengthSizedRadioButton.Enabled = false;
				NeckSizedRadioButton.Enabled = false;
				ExpandedNeckRadioButton.Enabled = false;

				FullLengthSizedRadioButton.Checked = false;
				NeckSizedRadioButton.Checked = false;
				ExpandedNeckRadioButton.Checked = false;
				}

			if (m_Batch.Load != null && m_Batch.Load.FirearmType != FirearmTypeCombo.Value)
				m_Batch.Load = null;

			PopulateCaliberCombo();
			}

		//============================================================================*
		// OnFullLengthSizeClicked()
		//============================================================================*

		private void OnFullLengthSizeClicked(object sender, EventArgs e)
			{
			if (m_fViewOnly || m_fUserViewOnly || m_fPopulating)
				return;

			FullLengthSizedRadioButton.Checked = !FullLengthSizedRadioButton.Checked;

			if (FullLengthSizedRadioButton.Checked)
				{
				NeckSizedRadioButton.Checked = false;
				ExpandedNeckRadioButton.Checked = false;
				}

			m_Batch.FullLengthSized = FullLengthSizedRadioButton.Checked;
			m_Batch.NeckSized = NeckSizedRadioButton.Checked;
			m_Batch.ExpandedNeck = ExpandedNeckRadioButton.Checked;

			UpdateButtons();
			}

		//============================================================================*
		// OnGasCheckClicked()
		//============================================================================*

		private void OnGasCheckClicked(object sender, EventArgs e)
			{
			if (m_fViewOnly || m_fUserViewOnly || m_fPopulating)
				return;

			GasCheckCheckBox.Checked = !GasCheckCheckBox.Checked;

			m_Batch.GasCheck = GasCheckCheckBox.Checked;

			UpdateButtons();
			}

		//============================================================================*
		// OnHeadSpaceTextChanged()
		//============================================================================*

		private void OnHeadSpaceTextChanged(object sender, EventArgs e)
			{
			if (!m_fInitialized || m_fPopulating)
				return;

			m_Batch.HeadSpace = cDataFiles.MetricToStandard(HeadSpaceTextBox.Value, cDataFiles.eDataType.Dimension);

			UpdateButtons();
			}

		//============================================================================*
		// OnJumpChanged()
		//============================================================================*

		private void OnJumpChanged(object sender, EventArgs e)
			{
			if (!m_fInitialized || m_fViewOnly || m_fUserViewOnly || m_fPopulating)
				return;

			m_Batch.JumpSet = JumpSetCheckBox.Checked;
			m_Batch.Jump = cDataFiles.MetricToStandard(JumpTextBox.Value, cDataFiles.eDataType.Dimension);

			UpdateButtons();
			}

		//============================================================================*
		// OnJumpSetClicked()
		//============================================================================*

		private void OnJumpSetClicked(object sender, EventArgs e)
			{
			if (m_fViewOnly || m_fUserViewOnly || m_fPopulating)
				return;

			m_Batch.JumpSet = JumpSetCheckBox.Checked;

			UpdateButtons();
			}

		//============================================================================*
		// OnLoadSelected()
		//============================================================================*

		private void OnLoadSelected(object sender, EventArgs e)
			{
			if (m_Batch.Load != null && (!m_fInitialized || m_fPopulating || m_BatchLoadListView.Populating))
				return;

			SetBatchData();

			//----------------------------------------------------------------------------*
			// Populate the load and firearm data
			//----------------------------------------------------------------------------*

			PopulateChargeCombo();

			if (m_fAdd)
				{
				OCWCheckBox.Checked = false;

				m_rOCW.m_dStartCharge = 0.0;
				}

			UpdateButtons();
			}

		//============================================================================*
		// OnModifiedBulletClicked()
		//============================================================================*

		private void OnModifiedBulletClicked(object sender, EventArgs e)
			{
			if (m_fViewOnly || m_fUserViewOnly || m_fPopulating)
				return;

			ModifiedBulletCheckBox.Checked = !ModifiedBulletCheckBox.Checked;

			m_Batch.ModifiedBullet = ModifiedBulletCheckBox.Checked;

			UpdateButtons();
			}

		//============================================================================*
		// OnNeckSizedClicked()
		//============================================================================*

		private void OnNeckSizedClicked(object sender, EventArgs e)
			{
			if (m_fViewOnly || m_fUserViewOnly || m_fPopulating)
				return;

			NeckSizedRadioButton.Checked = !NeckSizedRadioButton.Checked;

			if (NeckSizedRadioButton.Checked)
				{
				ExpandedNeckRadioButton.Checked = false;
				FullLengthSizedRadioButton.Checked = false;
				}

			m_Batch.FullLengthSized = FullLengthSizedRadioButton.Checked;
			m_Batch.NeckSized = NeckSizedRadioButton.Checked;
			m_Batch.ExpandedNeck = ExpandedNeckRadioButton.Checked;

			UpdateButtons();
			}

		//============================================================================*
		// OnNeckSizeTextChanged()
		//============================================================================*

		private void OnNeckSizeTextChanged(object sender, EventArgs e)
			{
			if (!m_fInitialized || m_fPopulating)
				return;

			m_Batch.NeckSize = cDataFiles.MetricToStandard(NeckSizeTextBox.Value, cDataFiles.eDataType.Dimension);

			SetNeckTension();

			UpdateButtons();
			}

		//============================================================================*
		// OnNeckTurnedClicked()
		//============================================================================*

		private void OnNeckTurnedClicked(object sender, EventArgs e)
			{
			if (m_fViewOnly || m_fUserViewOnly || m_fPopulating)
				return;

			NeckTurnedCheckBox.Checked = !NeckTurnedCheckBox.Checked;

			m_Batch.NeckTurned = NeckTurnedCheckBox.Checked;

			UpdateButtons();
			}

		//============================================================================*
		// OnNeckWallTextChanged()
		//============================================================================*

		private void OnNeckWallTextChanged(object sender, EventArgs e)
			{
			if (!m_fInitialized || m_fPopulating)
				return;

			m_Batch.NeckWall = cDataFiles.MetricToStandard(NeckWallTextBox.Value, cDataFiles.eDataType.Dimension);

			SetNeckTension();

			UpdateButtons();
			}

		//============================================================================*
		// OnNumRoundsTextChanged()
		//============================================================================*

		private void OnNumRoundsTextChanged(object sender, EventArgs e)
			{
			if (!m_fInitialized || m_fPopulating)
				return;

			m_Batch.NumRounds = NumRoundsTextBox.Value;

			SetCosts();

			UpdateButtons();
			}

		//============================================================================*
		// OnOCWClicked()
		//============================================================================*

		private void OnOCWClicked(object sender, EventArgs e)
			{
			if (m_fAdd)
				{
				string strText = "Add ";

				if (OCWCheckBox.Checked)
					strText += "OCW Batches";
				else
					strText += "Batch";

				Text = strText;
				}

			UpdateButtons();
			}

		//============================================================================*
		// OnCBTOTextChanged()
		//============================================================================*

		private void OnCBTOTextChanged(object sender, EventArgs e)
			{
			if (!m_fInitialized || m_fPopulating)
				return;

			m_Batch.CBTO = cDataFiles.MetricToStandard(CBTOTextBox.Value, cDataFiles.eDataType.Dimension);

			UpdateButtons();
			}

		//============================================================================*
		// OnOKClicked()
		//============================================================================*

		private void OnOKClicked(object sender, EventArgs e)
			{
			GetBatchData();

			if (m_fAdd)
				{
				m_DataFiles.Preferences.NextBatchID++;

				m_Batch.TrackInventory = m_DataFiles.Preferences.TrackInventory;
				}
			}

		//============================================================================*
		// OnPowderChanged()
		//============================================================================*

		private void OnPowderChanged(object sender, EventArgs e)
			{
			if (!m_fInitialized || m_fPopulating)
				return;

			if (PowderCombo.SelectedIndex > 0)
				{
				cPowder Powder = (cPowder)PowderCombo.SelectedItem;

				m_DataFiles.Preferences.LastBatchLoadPowderSelected = Powder;
				}

			PopulateLoadListView();
			}

		//============================================================================*
		// OnPrintClicked()
		//============================================================================*

		private void OnPrintClicked(object sender, EventArgs e)
			{
			GetBatchData();

			Cursor = Cursors.WaitCursor;

			cBatchList BatchList = new cBatchList();

			BatchList.Add(m_Batch);

			cBatchPrintForm BatchPrintForm = new cBatchPrintForm(BatchList, m_DataFiles);

			Cursor = Cursors.Default;

			BatchPrintForm.ShowDialog();
			}

		//============================================================================*
		// OnTestDataClicked()
		//============================================================================*

		private void OnTestDataClicked(object sender, EventArgs e)
			{
			cBatchTestForm BatchTestForm = new cBatchTestForm(m_Batch, m_DataFiles, m_RWRegistry, m_fUserViewOnly);

			DialogResult rc = BatchTestForm.ShowDialog();

			if (rc == DialogResult.Ignore)
				{
				m_Batch.BatchTest = null;

				foreach (cCharge Charge in m_Batch.Load.ChargeList)
					{
					while (true)
						{
						bool fTestFound = false;

						foreach (cChargeTest ChargeTest in Charge.TestList)
							{
							if (ChargeTest.BatchTest && ChargeTest.BatchID == m_Batch.BatchID)
								{
								Charge.TestList.Remove(ChargeTest);

								fTestFound = true;

								break;
								}
							}

						if (!fTestFound)
							break;
						}
					}

				if (!m_fUserViewOnly && m_fViewOnly)
					m_fForceUpdate = true;

				m_fViewOnly = m_fUserViewOnly;

				Initialize();
				}

			if (rc == DialogResult.OK)
				{
				m_Batch.BatchTest = new cBatchTest(BatchTestForm.BatchTest);

				cChargeTest ChargeTest = null;
				cCharge Charge = null;

				foreach (cCharge CheckCharge in m_Batch.Load.ChargeList)
					{
					if (CheckCharge.PowderWeight == m_Batch.PowderWeight)
						{
						Charge = CheckCharge;

						foreach (cChargeTest CheckChargeTest in CheckCharge.TestList)
							{
							if (CheckChargeTest.BatchID == m_Batch.BatchID)
								{
								ChargeTest = CheckChargeTest;

								break;
								}
							}
						}
					}

				if (Charge != null)
					{
					if (ChargeTest == null)
						{
						ChargeTest = new cChargeTest();

						Charge.TestList.Add(ChargeTest);
						}

					ChargeTest.Copy(m_Batch.BatchTest);
					}

				if (!m_fUserViewOnly && !m_fViewOnly && m_Batch.BatchTest != null)
					m_fForceUpdate = true;

				Initialize();
				}
			}

		//============================================================================*
		// OnTimesFiredTextChanged()
		//============================================================================*

		private void OnTimesFiredTextChanged(object sender, EventArgs e)
			{
			if (!m_fInitialized || m_fPopulating)
				return;

			m_Batch.TimesFired = TimesFiredTextBox.Value;

			SetCosts();

			UpdateButtons();
			}

		//============================================================================*
		// OnViewChargeClicked()
		//============================================================================*

		private void OnViewChargeClicked(object sender, EventArgs e)
			{
			//----------------------------------------------------------------------------*
			// If OCW is not checked, view the selected charge
			//----------------------------------------------------------------------------*

			if (!m_fAdd || !OCWCheckBox.Checked)
				{
				//----------------------------------------------------------------------------*
				// Get the selected charge
				//----------------------------------------------------------------------------*

				cCharge Charge = null;

				if (ChargeCombo.SelectedIndex >= 0)
					Charge = (cCharge)ChargeCombo.SelectedItem;

				//----------------------------------------------------------------------------*
				// Start the dialog
				//----------------------------------------------------------------------------*

				if (Charge != null && m_Batch.Load != null)
					{
					cChargeForm ChargeForm = new cChargeForm(Charge, m_Batch.Load, m_DataFiles, true);

					ChargeForm.ShowDialog();
					}
				}

			//----------------------------------------------------------------------------*
			// Otherwise, edit the OCW settings
			//----------------------------------------------------------------------------*

			else
				{
				cOCWForm OCWForm = new cOCWForm(m_DataFiles, m_rOCW, m_Batch);

				DialogResult rc = OCWForm.ShowDialog();

				if (rc == DialogResult.OK)
					{
					m_rOCW.Copy(OCWForm.OCWSettings);

					UpdateButtons();
					}
				}
			}

		//============================================================================*
		// PopulateBatchData()
		//============================================================================*

		private void PopulateBatchData()
			{
			m_fPopulating = true;

			BatchIDLabel.Text = m_Batch.BatchIDString;

			UserIDTextBox.Value = String.IsNullOrEmpty(m_Batch.UserID) ? "" : m_Batch.UserID;

			BatchDateTimePicker.Value = m_Batch.DateLoaded;

			NumRoundsTextBox.Value = m_Batch.NumRounds;

			if (m_Batch.Load != null && m_Batch.Load.Caliber != null)
				{
				CaseTrimLengthTextBox.MinValue = cDataFiles.StandardToMetric(m_Batch.Load.Caliber.CaseTrimLength, cDataFiles.eDataType.Dimension);
				CaseTrimLengthTextBox.MaxValue = cDataFiles.StandardToMetric(m_Batch.Load.Caliber.MaxCaseLength, cDataFiles.eDataType.Dimension);

				COALTextBox.MinValue = cDataFiles.StandardToMetric(m_Batch.Load.Caliber.CaseTrimLength, cDataFiles.eDataType.Dimension);
				COALTextBox.MaxValue = cDataFiles.StandardToMetric(m_Batch.Load.Caliber.MaxCOL, cDataFiles.eDataType.Dimension);

				CBTOTextBox.MinValue = m_fViewOnly ? 0.0 :  COALTextBox.MinValue;
				CBTOTextBox.MaxValue = COALTextBox.MaxValue;
				}

			CaseTrimLengthTextBox.Value = cDataFiles.StandardToMetric(m_Batch.CaseTrimLength, cDataFiles.eDataType.Dimension);

			COALTextBox.Value = cDataFiles.StandardToMetric(m_Batch.COL, cDataFiles.eDataType.Dimension);

			CBTOTextBox.Value = cDataFiles.StandardToMetric(m_Batch.CBTO, cDataFiles.eDataType.Dimension);
			NeckSizeTextBox.Value = cDataFiles.StandardToMetric(m_Batch.NeckSize, cDataFiles.eDataType.Dimension);

			TimesFiredTextBox.Value = m_Batch.TimesFired;
			HeadSpaceTextBox.Value = cDataFiles.StandardToMetric(m_Batch.HeadSpace, cDataFiles.eDataType.Dimension);
			FullLengthSizedRadioButton.Checked = m_Batch.FullLengthSized;
			NeckSizedRadioButton.Checked = m_Batch.NeckSized;
			ExpandedNeckRadioButton.Checked = m_Batch.ExpandedNeck;
			GasCheckCheckBox.Checked = m_Batch.GasCheck;
			NeckTurnedCheckBox.Checked = m_Batch.NeckTurned;
			AnnealedCheckBox.Checked = m_Batch.Annealed;
			ModifiedBulletCheckBox.Checked = m_Batch.ModifiedBullet;

			JumpSetCheckBox.Checked = m_Batch.JumpSet;
			JumpTextBox.Value = cDataFiles.StandardToMetric(m_Batch.Jump, cDataFiles.eDataType.Dimension);

			if (m_Batch.BulletDiameter != 0.0)
				BulletDiameterTextBox.Value = cDataFiles.StandardToMetric(m_Batch.BulletDiameter, cDataFiles.eDataType.Dimension);
			else
				{
				if (m_Batch.Load != null && m_Batch.Load.Bullet != null)
					BulletDiameterTextBox.Value = cDataFiles.StandardToMetric(m_Batch.Load.Bullet.Diameter, cDataFiles.eDataType.Dimension);
				else
					BulletDiameterTextBox.Value = 0.0;

				m_Batch.BulletDiameter = cDataFiles.MetricToStandard(BulletDiameterTextBox.Value, cDataFiles.eDataType.Dimension);
				}

			NeckWallTextBox.Value = cDataFiles.StandardToMetric(m_Batch.NeckWall, cDataFiles.eDataType.Dimension);

			SetNeckTension();

			//----------------------------------------------------------------------------*
			// Check for inventory on hand
			//----------------------------------------------------------------------------*

			int nNumRounds = 10000;

			if (m_Batch.TrackInventory)
				{
				if (m_Batch.Load != null)
					{
					if (m_Batch.Load.Bullet != null && nNumRounds > m_Batch.Load.Bullet.QuantityOnHand + m_nInitalRounds)
						nNumRounds = (int)m_Batch.Load.Bullet.QuantityOnHand + m_nInitalRounds;

					if (m_Batch.Load.Case != null && nNumRounds > m_Batch.Load.Case.QuantityOnHand + m_nInitalRounds)
						nNumRounds = (int)m_Batch.Load.Case.QuantityOnHand + m_nInitalRounds;

					if (m_Batch.Load.Powder != null && m_Batch.PowderWeight > 0 && nNumRounds > (m_DataFiles.SupplyQuantity(m_Batch.Load.Powder) / m_Batch.PowderWeight + (m_nInitalRounds * m_Batch.PowderWeight)))
						nNumRounds = (int)((m_DataFiles.SupplyQuantity(m_Batch.Load.Powder) / m_Batch.PowderWeight) + (m_nInitalRounds * m_Batch.PowderWeight));

					if (m_Batch.Load.Primer != null && nNumRounds > m_Batch.Load.Primer.QuantityOnHand + m_nInitalRounds)
						nNumRounds = (int)m_Batch.Load.Primer.QuantityOnHand + m_nInitalRounds;
					}
				else
					nNumRounds = 0;
				}

			NumRoundsTextBox.MinValue = 1;
			NumRoundsTextBox.MaxValue = nNumRounds;

			if (nNumRounds > 0)
				NumRoundsRangeLabel.Text = String.Format("(1 to {0:G0})", nNumRounds);
			else
				NumRoundsRangeLabel.Text = "";

			//----------------------------------------------------------------------------*
			// Finish up and exit
			//----------------------------------------------------------------------------*

			SetCosts();

			UpdateButtons();

			m_fPopulating = false;
			}

		//============================================================================*
		// PopulateBulletCombo()
		//============================================================================*

		private void PopulateBulletCombo()
			{
			m_fPopulating = true;

			BulletCombo.Items.Clear();

			cCaliber Caliber = null;

			if (CaliberCombo.SelectedIndex > 0)
				Caliber = (cCaliber)CaliberCombo.SelectedItem;

			if (!m_fViewOnly && m_Batch.BatchTest == null)
				{
				BulletCombo.Items.Add("Any Bullet");

				foreach (cLoad Load in m_DataFiles.LoadList)
					{
					if (Load.FirearmType != FirearmTypeCombo.Value)
						continue;

					if (Caliber != null && Load.Caliber.CompareTo(Caliber) != 0)
						continue;

					if (Caliber != null && !Load.Bullet.HasCaliber(Caliber))
						continue;

					if (BulletCombo.Items.IndexOf(Load.Bullet) < 0)
						BulletCombo.Items.Add(Load.Bullet);
					}

				BulletCombo.SelectedIndex = 0;
				}
			else
				{
				BulletCombo.Items.Clear();

				BulletCombo.Items.Add(m_Batch.Load.Bullet);

				BulletCombo.SelectedIndex = 0;
				}

			m_fPopulating = false;

			PopulatePowderCombo();
			}

		//============================================================================*
		// PopulateCaliberCombo()
		//============================================================================*

		private void PopulateCaliberCombo()
			{
			m_fPopulating = true;

			CaliberCombo.Items.Clear();

			if (!m_fViewOnly && m_Batch.BatchTest == null)
				{
				CaliberCombo.Items.Add("Any Caliber");

				foreach (cLoad Load in m_DataFiles.LoadList)
					{
					if (Load.FirearmType != FirearmTypeCombo.Value)
						continue;

					if (CaliberCombo.Items.IndexOf(Load.Caliber) < 0)
						CaliberCombo.Items.Add(Load.Caliber);
					}

				CaliberCombo.SelectedIndex = 0;
				}
			else
				{
				CaliberCombo.Items.Clear();

				CaliberCombo.Items.Add(m_Batch.Load.Caliber);

				CaliberCombo.SelectedIndex = 0;
				}

			m_fPopulating = false;

			PopulateBulletCombo();
			}

		//============================================================================*
		// PopulateChargeCombo()
		//============================================================================*

		private void PopulateChargeCombo()
			{
			m_fPopulating = true;

			cLoad Load = null;

			if (m_BatchLoadListView.SelectedItems.Count > 0)
				Load = (cLoad)m_BatchLoadListView.SelectedItems[0].Tag;

			ChargeCombo.Items.Clear();

			cCharge SelectCharge = null;

			if (Load != null)
				{
				foreach (cCharge CheckCharge in m_Batch.Load.ChargeList)
					{
					if (((!m_fViewOnly && m_Batch.BatchTest == null) || CheckCharge.PowderWeight == m_Batch.PowderWeight) && !CheckCharge.Reject)
						{
						ChargeCombo.Items.Add(CheckCharge);

						if (CheckCharge.PowderWeight == m_Batch.PowderWeight)
							SelectCharge = CheckCharge;
						}
					}
				}

			if (SelectCharge != null)
				ChargeCombo.SelectedItem = SelectCharge;
			else
				{
				if (ChargeCombo.Items.Count > 0)
					ChargeCombo.SelectedIndex = 0;
				else
					ChargeCombo.SelectedIndex = -1;
				}

			cCharge Charge = null;

			if (ChargeCombo.SelectedIndex >= 0)
				Charge = (cCharge)ChargeCombo.SelectedItem;

			double dPowerWeight = 0.0;

			if (Charge != null)
				dPowerWeight = Charge.PowderWeight;

			m_Batch.PowderWeight = dPowerWeight;

			m_fPopulating = false;

			PopulateLoadDetails();
			}

		//============================================================================*
		// PopulateFirearmCombo()
		//============================================================================*

		private void PopulateFirearmCombo()
			{
			m_fPopulating = true;

			FirearmCombo.Items.Clear();

			if (!m_fViewOnly && m_Batch.BatchTest == null)
				{
				cFirearm SelectFirearm = null;

				FirearmCombo.Items.Add("Any Firearm");

				foreach (cFirearm CheckFirearm in m_DataFiles.FirearmList)
					{
					if (FirearmCombo.FindString(CheckFirearm.ToString()) != -1)
						continue;

					if (m_Batch.Load == null || CheckFirearm.FirearmType == m_Batch.Load.FirearmType)
						{
						if (m_Batch.Load == null || CheckFirearm.HasCaliber(m_Batch.Load.Caliber))
							{
							FirearmCombo.Items.Add(CheckFirearm);

							if (CheckFirearm.CompareTo(m_Batch.Firearm) == 0)
								SelectFirearm = CheckFirearm;
							}
						}
					}

				if (SelectFirearm != null)
					FirearmCombo.SelectedItem = SelectFirearm;
				else
					{
					if (FirearmCombo.Items.Count > 0)
						FirearmCombo.SelectedIndex = 0;
					}

				if (FirearmCombo.Items.Count > 1)
					FirearmCombo.Enabled = true;
				else
					{
					FirearmCombo.Enabled = false;
					FirearmCombo.SelectedIndex = 0;
					}

				if (m_Batch.Firearm == null)
					{
					if (FirearmCombo.SelectedIndex > 0)
						m_Batch.Firearm = (cFirearm)FirearmCombo.SelectedItem;
					}
				}
			else
				{
				if (m_Batch.Firearm == null)
					FirearmCombo.Items.Add("Any Firearm");
				else
					FirearmCombo.Items.Add(m_Batch.Firearm);

				FirearmCombo.SelectedIndex = 0;
				}

			m_fPopulating = false;

			PopulateFirearmData();
			}

		//============================================================================*
		// PopulateFirearmData()
		//============================================================================*

		private void PopulateFirearmData()
			{
			m_fPopulating = true;

			if (m_Batch.Firearm != null)
				FirearmCombo.SelectedItem = m_Batch.Firearm;
			else
				FirearmCombo.SelectedItem = 0;

			cLoad Load = null;

			if (m_BatchLoadListView.SelectedItems.Count > 0)
				Load = (cLoad)m_BatchLoadListView.SelectedItems[0].Tag;

			cFirearm Firearm = null;

			if (FirearmCombo.SelectedIndex > 0)
				Firearm = (cFirearm)FirearmCombo.SelectedItem;

			cFirearmBullet FirearmBullet = null;

			if (Load != null && Firearm != null)
				{
				foreach (cFirearmBullet CheckFirearmBullet in Firearm.FirearmBulletList)
					{
					if (CheckFirearmBullet.Bullet.CompareTo(Load.Bullet) == 0)
						{
						FirearmBullet = CheckFirearmBullet;

						break;
						}
					}
				}

			FirearmHeadSpaceLabel.Text = Firearm != null && Firearm.FirearmType == cFirearm.eFireArmType.Rifle && Firearm.HeadSpace != 0.0 ? String.Format("{0:F3}", cDataFiles.StandardToMetric(Firearm.HeadSpace, cDataFiles.eDataType.Dimension)) : "N/A";
			FirearmHeadSpaceMeasurementLabel.Visible = FirearmHeadSpaceLabel.Text != "N/A";

			FirearmNeckLabel.Text = Firearm != null && Firearm.FirearmType == cFirearm.eFireArmType.Rifle && Firearm.Neck != 0.0 ? String.Format("{0:F3}", cDataFiles.StandardToMetric(Firearm.Neck, cDataFiles.eDataType.Dimension)) : "N/A";
			FirearmNeckMeasurementLabel.Visible = FirearmNeckLabel.Text != "N/A";

			FirearmCOLLabel.Text = Firearm != null && FirearmBullet != null && FirearmBullet.COL != m_Batch.COL ? String.Format("{0:F3}", cDataFiles.StandardToMetric(FirearmBullet.COL, cDataFiles.eDataType.Dimension)) : LoadCOLLabel.Text;
			FirearmCOLMeasurementLabel.Visible = FirearmCOLLabel.Text != "N/A";

			FirearmCBTOLabel.Text = Firearm != null && FirearmBullet != null && FirearmBullet.CBTO != 0 && m_Batch.Load.FirearmType == cFirearm.eFireArmType.Rifle ? String.Format("{0:F3}", cDataFiles.StandardToMetric(FirearmBullet.CBTO, cDataFiles.eDataType.Dimension)) : "N/A";
			FirearmCBTOMeasurementLabel.Visible = FirearmCBTOLabel.Text != "N/A";

			FirearmJumpLabel.Text = Firearm != null && FirearmBullet != null && m_Batch.JumpSet && m_Batch.Load.FirearmType == cFirearm.eFireArmType.Rifle ? String.Format("{0:F3}", cDataFiles.StandardToMetric(FirearmBullet.Jump, cDataFiles.eDataType.Dimension)) : "N/A";
			FirearmJumpMeasurementLabel.Visible = FirearmJumpLabel.Text != "N/A";

			m_fPopulating = false;

			PopulateBatchData();
			}

		//============================================================================*
		// PopulateLoadDetails()
		//============================================================================*

		private void PopulateLoadDetails()
			{
			m_fPopulating = true;

			//----------------------------------------------------------------------------*
			// Set the Load COL and Batch COL Text with the recommended COL
			//----------------------------------------------------------------------------*

			if (m_Batch.Load != null && m_Batch.Load.Bullet != null)
				{
				foreach (cBulletCaliber BulletCaliber in m_Batch.Load.Bullet.BulletCaliberList)
					{
					if (BulletCaliber.Caliber.CompareTo(m_Batch.Load.Caliber) == 0)
						{
						LoadCOLLabel.Text = String.Format("{0:F3}", cDataFiles.StandardToMetric(BulletCaliber.COL, cDataFiles.eDataType.Dimension));

						break;
						}
					}
				}

			double dFillRatio = 0.0;
			int nMinVelocity = 1000000;
			int nMaxVelocity = 0;
			int nMinPressure = 1000000;
			int nMaxPressure = 0;

			//----------------------------------------------------------------------------*
			// See if the batch charge is valid for the selected load
			//----------------------------------------------------------------------------*

			bool fValidCharge = false;

			if (m_Batch.Load != null)
				{
				foreach (cCharge CheckCharge in m_Batch.Load.ChargeList)
					if (CheckCharge.PowderWeight == m_Batch.PowderWeight)
						fValidCharge = true;
				}

			//----------------------------------------------------------------------------*
			// If not, set the charge to the minimum for the load
			//----------------------------------------------------------------------------*

			if (!fValidCharge)
				{
				if (m_Batch.Load != null)
					{
					double dMinCharge = 7000.0;

					foreach (cCharge CheckCharge in m_Batch.Load.ChargeList)
						{
						if (CheckCharge.PowderWeight < dMinCharge)
							dMinCharge = CheckCharge.PowderWeight;
						}

					m_Batch.PowderWeight = dMinCharge;
					}
				else
					m_Batch.PowderWeight = 0.0;
				}


			//----------------------------------------------------------------------------*
			// Get fill ratio and muzzle velocities
			//----------------------------------------------------------------------------*

			if (m_Batch.Load != null)
				{
				foreach (cCharge CheckCharge in m_Batch.Load.ChargeList)
					{
					if (CheckCharge.PowderWeight == m_Batch.PowderWeight)
						{
						dFillRatio = CheckCharge.FillRatio;

						if (CheckCharge.TestList.Count > 0)
							{
							foreach (cChargeTest ChargeTest in CheckCharge.TestList)
								{
								if (ChargeTest.MuzzleVelocity < nMinVelocity)
									nMinVelocity = ChargeTest.MuzzleVelocity;

								if (ChargeTest.MuzzleVelocity > nMaxVelocity)
									nMaxVelocity = ChargeTest.MuzzleVelocity;

								if (ChargeTest.Pressure < nMinPressure)
									nMinPressure = ChargeTest.Pressure;

								if (ChargeTest.Pressure > nMaxPressure)
									nMaxPressure = ChargeTest.Pressure;
								}
							}
						else
							{
							nMinVelocity = 0;
							nMaxVelocity = 0;
							nMinPressure = 0;
							nMaxPressure = 0;
							}

						break;
						}
					}
				}

			//----------------------------------------------------------------------------*
			// Set fill ratio
			//----------------------------------------------------------------------------*

			if (dFillRatio != 0.0)
				FillRatioLabel.Text = String.Format("{0:F1}", dFillRatio);
			else
				FillRatioLabel.Text = "N/A";

			//----------------------------------------------------------------------------*
			// Set muzzle velocity
			//----------------------------------------------------------------------------*

			if (nMinVelocity == 0 && nMaxVelocity == 0)
				{
				MuzzleVelocityLabel.Text = "No test data available";
				}
			else
				{
				if (nMinVelocity == nMaxVelocity)
					MuzzleVelocityLabel.Text = String.Format("{0:N0} {1}", cDataFiles.StandardToMetric(nMinVelocity, cDataFiles.eDataType.Velocity), cDataFiles.MetricString(cDataFiles.eDataType.Velocity));
				else
					MuzzleVelocityLabel.Text = String.Format("{0:N0} to {1:N0} {2}", cDataFiles.StandardToMetric(nMinVelocity, cDataFiles.eDataType.Velocity), cDataFiles.StandardToMetric(nMaxVelocity, cDataFiles.eDataType.Velocity), cDataFiles.MetricString(cDataFiles.eDataType.Velocity));
				}

			//----------------------------------------------------------------------------*
			// Set Pressure
			//----------------------------------------------------------------------------*

			if (nMinPressure == 0 && nMaxPressure == 0)
				{
				PressureLabel.Text = "N/A";
				}
			else
				{
				if (nMinPressure == nMaxPressure)
					PressureLabel.Text = String.Format("{0:N0}", nMinPressure);
				else
					PressureLabel.Text = String.Format("{0:N0} to {1:N0}", nMinPressure, nMaxPressure);
				}

			m_fPopulating = false;

			PopulateFirearmCombo();
			}

		//============================================================================*
		// PopulateLoadListView()
		//============================================================================*

		private void PopulateLoadListView()
			{
			m_fPopulating = true;

			if (m_fViewOnly || m_Batch.BatchTest != null)
				{
				m_BatchLoadListView.Populate(m_Batch.Load, cFirearm.eFireArmType.None, null, null, null);
				}
			else
				{
				//----------------------------------------------------------------------------*
				// Get Filter Data
				//----------------------------------------------------------------------------*

				cCaliber Caliber = null;
				cBullet Bullet = null;
				cPowder Powder = null;

				if (CaliberCombo.SelectedIndex > 0)
					Caliber = (cCaliber)CaliberCombo.SelectedItem;

				if (BulletCombo.SelectedIndex > 0)
					Bullet = (cBullet)BulletCombo.SelectedItem;

				if (PowderCombo.SelectedIndex > 0)
					Powder = (cPowder)PowderCombo.SelectedItem;

				//----------------------------------------------------------------------------*
				// Populate Load List
				//----------------------------------------------------------------------------*

				m_BatchLoadListView.Populate(FirearmTypeCombo.Value, Caliber, Bullet, Powder);
				}

			m_fPopulating = false;

			SetBatchData();

			PopulateChargeCombo();

			UpdateButtons();
			}

		//============================================================================*
		// PopulatePowderCombo()
		//============================================================================*

		private void PopulatePowderCombo()
			{
			cCaliber.CurrentFirearmType = FirearmTypeCombo.Value;

			m_fPopulating = true;

			PowderCombo.Items.Clear();

			cCaliber Caliber = null;

			if (CaliberCombo.SelectedIndex > 0)
				Caliber = (cCaliber)CaliberCombo.SelectedItem;

			cBullet Bullet = null;

			if (BulletCombo.SelectedIndex > 0)
				Bullet = (cBullet)BulletCombo.SelectedItem;

			if (!m_fViewOnly && m_Batch.BatchTest == null)
				{
				PowderCombo.Items.Add("Any Powder");

				foreach (cLoad Load in m_DataFiles.LoadList)
					{
					if (Load.FirearmType != FirearmTypeCombo.Value)
						continue;

					if (Caliber != null && Load.Caliber.CompareTo(Caliber) != 0)
						continue;

					if (Bullet != null && Load.Bullet.CompareTo(Bullet) != 0)
						continue;

					if (PowderCombo.Items.IndexOf(Load.Powder) < 0)
						PowderCombo.Items.Add(Load.Powder);
					}

				PowderCombo.SelectedIndex = 0;
				}
			else
				{
				PowderCombo.Items.Clear();

				PowderCombo.Items.Add(m_Batch.Load.Powder);

				PowderCombo.SelectedIndex = 0;
				}

			m_fPopulating = false;

			PopulateLoadListView();
			}

		//============================================================================*
		// SetBatchData()
		//============================================================================*

		private void SetBatchData()
			{
			//----------------------------------------------------------------------------*
			// See if this is a different load
			//----------------------------------------------------------------------------*

			bool fNewLoad = false;

			if (m_BatchLoadListView.SelectedItems.Count > 0)
				{
				cLoad Load = (cLoad)m_BatchLoadListView.SelectedItems[0].Tag;

				if (Load != null)
					{
					if (m_Batch.Load == null || m_Batch.COL == 0)
						{
						m_Batch.Load = Load;

						fNewLoad = true;
						}
					else
						{
						if (m_Batch.Load.CompareTo(Load) != 0)
							{
							m_Batch.Load = Load;

							fNewLoad = true;
							}
						}
					}
				}

			//----------------------------------------------------------------------------*
			// If a new load was selected, reset the batch data
			//----------------------------------------------------------------------------*

			if (fNewLoad)
				{
				//----------------------------------------------------------------------------*
				// Set the case trim length to the load's caliber trim length
				//----------------------------------------------------------------------------*

				m_Batch.CaseTrimLength = m_Batch.Load.Caliber.CaseTrimLength;
				m_Batch.BulletDiameter = m_Batch.Load.Bullet.Diameter;
				m_Batch.HeadSpace = 0.0;
				m_Batch.NeckSize = 0.0;
				m_Batch.CBTO = 0.0;
				m_Batch.PowderWeight = 0.0;

				//----------------------------------------------------------------------------*
				// Set the batch COAL
				//----------------------------------------------------------------------------*

				m_Batch.COL = 0.0;

				m_Batch.Firearm = null;

				if (FirearmCombo.SelectedIndex > 0)
					m_Batch.Firearm = (cFirearm)FirearmCombo.SelectedItem;

				if (m_Batch.Firearm != null)
					{
					m_Batch.HeadSpace = m_Batch.Firearm.HeadSpace;
					m_Batch.NeckSize = m_Batch.Firearm.Neck;

					//----------------------------------------------------------------------------*
					// See if the firearm has a custom bullet COL
					//----------------------------------------------------------------------------*

					foreach (cFirearmBullet FirearmBullet in m_Batch.Firearm.FirearmBulletList)
						{
						if (FirearmBullet.Bullet.CompareTo(m_Batch.Load.Bullet) == 0)
							{
							m_Batch.COL = FirearmBullet.COL;
							m_Batch.CBTO = FirearmBullet.CBTO;

							break;
							}
						}
					}

				//----------------------------------------------------------------------------*
				// If no COL found, check the bullet's caliber list
				//----------------------------------------------------------------------------*

				if (m_Batch.COL == 0.0 || m_Batch.CBTO == 0.0)
					{
					foreach (cBulletCaliber BulletCaliber in m_Batch.Load.Bullet.BulletCaliberList)
						{
						if (BulletCaliber.Caliber.CompareTo(m_Batch.Load.Caliber) == 0)
							{
							if (m_Batch.COL == 0.0)
								m_Batch.COL = BulletCaliber.COL;

							if (m_Batch.CBTO == 0.0)
								m_Batch.CBTO = BulletCaliber.CBTO;

							break;
							}
						}
					}

				//----------------------------------------------------------------------------*
				// If still no COL found, use the caliber's max COL
				//----------------------------------------------------------------------------*

				if (m_Batch.COL == 0.0 && m_Batch.Load.Caliber != null)
					m_Batch.COL = m_Batch.Load.Caliber.MaxCOL;
				}

			PopulateBatchData();
			}

		//============================================================================*
		// SetCosts()
		//============================================================================*

		private void SetCosts()
			{
			TimesFiredLabel.Text = String.Format("time{0}", (TimesFiredTextBox.Value != 1 ? "s" : ""));

			CartridgeCostLabel.Text = String.Format("{0}{1:F2}", m_DataFiles.Preferences.Currency, m_DataFiles.BatchCartridgeCost(m_Batch));
			BatchCostLabel.Text = String.Format("{0}{1:F2}", m_DataFiles.Preferences.Currency, m_DataFiles.BatchCost(m_Batch));
			}

		//============================================================================*
		// SetInputParameters()
		//============================================================================*

		private void SetInputParameters()
			{
			//----------------------------------------------------------------------------*
			// Set measurement labels
			//----------------------------------------------------------------------------*

			cDataFiles.SetMetricLabel(PowderChargeMeasurementLabel, cDataFiles.eDataType.PowderWeight);
			cDataFiles.SetMetricLabel(LoadCOLMeasurementLabel, cDataFiles.eDataType.Dimension);
			cDataFiles.SetMetricLabel(FirearmCOLMeasurementLabel, cDataFiles.eDataType.Dimension);
			cDataFiles.SetMetricLabel(FirearmCBTOMeasurementLabel, cDataFiles.eDataType.Dimension);
			cDataFiles.SetMetricLabel(FirearmJumpMeasurementLabel, cDataFiles.eDataType.Dimension);
			cDataFiles.SetMetricLabel(FirearmHeadSpaceMeasurementLabel, cDataFiles.eDataType.Dimension);
			cDataFiles.SetMetricLabel(FirearmNeckMeasurementLabel, cDataFiles.eDataType.Dimension);
			cDataFiles.SetMetricLabel(TrimLengthMeasurementLabel, cDataFiles.eDataType.Dimension);
			cDataFiles.SetMetricLabel(COLMeasurementLabel, cDataFiles.eDataType.Dimension);
			cDataFiles.SetMetricLabel(CBTOMeasurementLabel, cDataFiles.eDataType.Dimension);
			cDataFiles.SetMetricLabel(HeadspaceMeasurementLabel, cDataFiles.eDataType.Dimension);
			cDataFiles.SetMetricLabel(NeckSizeMeasurementLabel, cDataFiles.eDataType.Dimension);
			cDataFiles.SetMetricLabel(NeckWallMeasurementLabel, cDataFiles.eDataType.Dimension);
			cDataFiles.SetMetricLabel(BulletDiameterMeasurementLabel, cDataFiles.eDataType.Dimension);
			cDataFiles.SetMetricLabel(JumpMeasurementLabel, cDataFiles.eDataType.Dimension);

			//----------------------------------------------------------------------------*
			// Set Text Box Parameters
			//----------------------------------------------------------------------------*

			cDataFiles.SetInputParameters(CaseTrimLengthTextBox, cDataFiles.eDataType.Dimension);
			cDataFiles.SetInputParameters(COALTextBox, cDataFiles.eDataType.Dimension);
			cDataFiles.SetInputParameters(CBTOTextBox, cDataFiles.eDataType.Dimension);
			cDataFiles.SetInputParameters(HeadSpaceTextBox, cDataFiles.eDataType.Dimension);
			cDataFiles.SetInputParameters(BulletDiameterTextBox, cDataFiles.eDataType.Dimension);
			cDataFiles.SetInputParameters(NeckSizeTextBox, cDataFiles.eDataType.Dimension);
			cDataFiles.SetInputParameters(NeckWallTextBox, cDataFiles.eDataType.Dimension);
			cDataFiles.SetInputParameters(JumpTextBox, cDataFiles.eDataType.Dimension);
			}

		//============================================================================*
		// SetNeckTension()
		//============================================================================*

		private void SetNeckTension()
			{
			double dNeckTension = 0.0;

			string strFormat = m_DataFiles.Preferences.FormatString(cDataFiles.eDataType.Dimension);
			strFormat += " ";
			strFormat += cDataFiles.MetricString(cDataFiles.eDataType.Dimension);

			NeckSizeTextBox.MinValue = 0.0;
			NeckSizeTextBox.MaxValue = 0.0;
			NeckWallTextBox.MinValue = 0.0;
			NeckWallTextBox.MaxValue = cDataFiles.StandardToMetric(0.030, cDataFiles.eDataType.Dimension);

			double dNeckWall = cDataFiles.MetricToStandard(NeckWallTextBox.Value, cDataFiles.eDataType.Dimension);
			double dNeckSize = cDataFiles.MetricToStandard(NeckSizeTextBox.Value, cDataFiles.eDataType.Dimension);
			double dBulletDiameter = cDataFiles.MetricToStandard(BulletDiameterTextBox.Value, cDataFiles.eDataType.Dimension);

			if (m_Batch.Load != null)
				{
				if (m_Batch.Load.Caliber != null && m_Batch.Load.Caliber.MaxNeckDiameter > 0.0)
					NeckSizeTextBox.MaxValue = cDataFiles.StandardToMetric(m_Batch.Load.Caliber.MaxNeckDiameter, cDataFiles.eDataType.Dimension);

				if (NeckSizeTextBox.ValueOK && dNeckSize > 0.0 && dNeckWall > 0.0)
					{
					dNeckTension = (m_Batch.BulletDiameter + (dNeckWall * 2.0)) - dNeckSize;

					if (dNeckTension < 0.0)
						{
						NeckSizeTextBox.MaxValue = cDataFiles.StandardToMetric(dBulletDiameter + (dNeckWall * 2.0), cDataFiles.eDataType.Dimension);
						NeckWallTextBox.MinValue = cDataFiles.StandardToMetric((dNeckSize - dBulletDiameter) / 2.0, cDataFiles.eDataType.Dimension);
						}
					}
				}

			NeckTensionlabel.Text = String.Format(strFormat, cDataFiles.StandardToMetric(dNeckTension, cDataFiles.eDataType.Dimension));

			UpdateButtons();
			}

		//============================================================================*
		// SetOCWString()
		//============================================================================*

		public static void SetOCWString(cDataFiles DataFiles, Label OCWLabel, ref rOCW OCWSettings, cBatch Batch)
			{
			if (OCWSettings.m_dStartCharge == 0.0)
				{
				OCWSettings.m_nMaxBatches = 3;
				OCWSettings.m_nNumRounds = 5;

				if (Batch != null && Batch.Load != null)
					{
					cCharge MinCharge = Batch.Load.ChargeList.MinCharge;
					cCharge MaxCharge = Batch.Load.ChargeList.MaxCharge;

					double dMinCharge = MinCharge != null ? MinCharge.PowderWeight : 0.0;
					double dMaxCharge = MaxCharge != null ? MaxCharge.PowderWeight : 0.0;

					double dIncrement = Math.Round((Math.Abs(dMaxCharge - dMinCharge) / 2.0) / 2.0, cPreferences.StaticPreferences.PowderWeightDecimals);

					OCWSettings.m_dStartCharge = dMinCharge;
					OCWSettings.m_dChargeIncrement = dIncrement;
					}
				else
					{
					OCWSettings.m_dStartCharge = 0.0;
					OCWSettings.m_dChargeIncrement = 0.0;
					}
				}

			OCWSettings.m_dStartCharge = Math.Round(OCWSettings.m_dStartCharge, cPreferences.StaticPreferences.PowderWeightDecimals);
			OCWSettings.m_dChargeIncrement = Math.Round(OCWSettings.m_dChargeIncrement, cPreferences.StaticPreferences.PowderWeightDecimals);

			string strPowderWeightFormat = cPreferences.StaticPreferences.FormatString(cDataFiles.eDataType.PowderWeight);

			string strStartCharge = String.Format(strPowderWeightFormat, cDataFiles.StandardToMetric(OCWSettings.m_dStartCharge, cDataFiles.eDataType.PowderWeight));
			string strIncrement = String.Format(strPowderWeightFormat, cDataFiles.StandardToMetric(OCWSettings.m_dChargeIncrement, cDataFiles.eDataType.PowderWeight));

			string strOCW = "";

			int nBatchCount = OCWBatchCount(OCWSettings, Batch, DataFiles);

			if (nBatchCount > OCWSettings.m_nMaxBatches)
				nBatchCount = OCWSettings.m_nMaxBatches;

			strOCW = String.Format("Create {0} batch{1} of {2} round{3}{4}", nBatchCount, nBatchCount != 1 ? "es" : "", OCWSettings.m_nNumRounds, OCWSettings.m_nNumRounds != 1 ? "s" : "", OCWSettings.m_nMaxBatches > 1 ? " each" : "");

			if (OCWSettings.m_dStartCharge > 0.0)
				strOCW += string.Format(", starting at {0} {1} of {2} with increments of {3} {4}.", strStartCharge, DataFiles.MetricLongString(cDataFiles.eDataType.PowderWeight), Batch.Load.Powder.ToString(), strIncrement, DataFiles.MetricLongString(cDataFiles.eDataType.PowderWeight));
			else
				strOCW += ".";

			OCWLabel.Text = strOCW;
			}

		//============================================================================*
		// SetStaticToolTips()
		//============================================================================*

		private void SetStaticToolTips()
			{
			if (!m_DataFiles.Preferences.ToolTips)
				return;

			UserIDTextBox.ToolTip = cm_strUserIDToolTip;

			NumRoundsTextBox.ToolTip = cm_strNumRoundsToolTip;
			CaseTrimLengthTextBox.ToolTip = cm_strTrimLengthToolTip;
			COALTextBox.ToolTip = cm_strCOLToolTip;
			TimesFiredTextBox.ToolTip = cm_strTimesFiredToolTip;
			HeadSpaceTextBox.ToolTip = cm_strHeadSpaceToolTip;
			NeckSizeTextBox.ToolTip = cm_strNeckSizeToolTip;
			NeckWallTextBox.ToolTip = cm_strNeckWallToolTip;
			CBTOTextBox.ToolTip = cm_strCBTOToolTip;
			}

		//============================================================================*
		// UpdateButtons()
		//============================================================================*

		private void UpdateButtons()
			{
			//----------------------------------------------------------------------------*
			// Test Data Button
			//----------------------------------------------------------------------------*

			if ((m_fUserViewOnly && m_Batch.BatchTest == null) || m_Batch.NumRounds <= 0)
				TestDataButton.Enabled = false;
			else
				TestDataButton.Enabled = true;

			if (m_fViewOnly)
				return;

			bool fEnableOK = true;

			//----------------------------------------------------------------------------*
			// Check Load
			//----------------------------------------------------------------------------*

			if (m_BatchLoadListView.SelectedItems.Count == 0)
				{
				fEnableOK = false;

				m_BatchLoadListView.BackColor = Color.LightPink;
				}
			else
				m_BatchLoadListView.BackColor = SystemColors.Window;

			//----------------------------------------------------------------------------*
			// See if the selected load supports OCW
			//----------------------------------------------------------------------------*

			bool fEnableOCW = OCWBatchCount(m_rOCW, m_Batch, m_DataFiles) >= 3;

			if (fEnableOCW)
				{
				if (m_Batch.Load != null)
					{
					double dMin = 1000.0;
					double dMax = 0.0;

					foreach (cCharge Charge in m_Batch.Load.ChargeList)
						{
						if (Charge.PowderWeight < dMin)
							dMin = Charge.PowderWeight;

						if (Charge.PowderWeight > dMax)
							dMax = Charge.PowderWeight;
						}

					if (dMax - dMin < 1.0)
						fEnableOCW = false;
					}
				else
					fEnableOCW = false;
				}

			OCWCheckBox.Visible = fEnableOCW;

			if (!fEnableOCW)
				OCWCheckBox.Checked = false;

			//----------------------------------------------------------------------------*
			// Check Powder Charge
			//----------------------------------------------------------------------------*

			if (!m_fAdd || !OCWCheckBox.Checked)
				{
				PowderChargeLabel.Visible = true;
				ChargeCombo.Visible = true;
				PowderChargeMeasurementLabel.Visible = true;
				ViewChargeButton.Text = "View";
				LoadCOALLabel.Visible = true;
				LoadCOLLabel.Visible = true;
				LoadCOLMeasurementLabel.Visible = true;
				LoadFillRatioLabel.Visible = true;
				FillRatioLabel.Visible = true;
				FillRatioPctLabel.Visible = true;
				LoadMuzzleVelocityLabel.Visible = true;
				MuzzleVelocityLabel.Visible = true;
				LoadPressureLabel.Visible = true;
				PressureLabel.Visible = true;

				OCWLabel.Visible = false;

				if (ChargeCombo.SelectedIndex < 0)
					fEnableOK = false;

				NumRoundsTextBox.Enabled = true;
				}
			else
				{
				PowderChargeLabel.Visible = false;
				ChargeCombo.Visible = false;
				PowderChargeMeasurementLabel.Visible = false;
				ViewChargeButton.Text = "Edit";
				LoadCOALLabel.Visible = false;
				LoadCOLLabel.Visible = false;
				LoadCOLMeasurementLabel.Visible = false;
				LoadFillRatioLabel.Visible = false;
				FillRatioLabel.Visible = false;
				FillRatioPctLabel.Visible = false;
				LoadMuzzleVelocityLabel.Visible = false;
				MuzzleVelocityLabel.Visible = false;
				LoadPressureLabel.Visible = false;
				PressureLabel.Visible = false;

				SetOCWString(m_DataFiles, OCWLabel, ref m_rOCW, m_Batch);

				OCWLabel.Visible = true;

				OCWLabel.Location = new Point(5, 50);
				OCWLabel.Size = new Size(LoadDetailsGroup.Width - 20, LoadDetailsGroup.Height - 60);

				int nBatchCount = OCWBatchCount(m_rOCW, Batch, m_DataFiles);

				if (nBatchCount > m_rOCW.m_nMaxBatches)
					nBatchCount = m_rOCW.m_nMaxBatches;

				NumRoundsTextBox.Enabled = false;
				NumRoundsTextBox.Value = nBatchCount * m_rOCW.m_nNumRounds;
				}

			//----------------------------------------------------------------------------*
			// Check Firearm
			//----------------------------------------------------------------------------*

			bool fEnableTransfer = true;

			if (!(FirearmCombo.SelectedIndex > 0))
				fEnableTransfer = false;

			if (fEnableTransfer &&
				FirearmCOLLabel.Text == "N/A" &&
				FirearmCOLLabel.Text == "N/A" &&
				FirearmCOLLabel.Text == "N/A" &&
				FirearmCOLLabel.Text == "N/A" &&
				FirearmCOLLabel.Text == "N/A")
				fEnableTransfer = false;

			FirearmTransferButton.Enabled = fEnableTransfer;

			//----------------------------------------------------------------------------*
			// Check NumRounds
			//----------------------------------------------------------------------------*

			if (!NumRoundsTextBox.ValueOK)
				{
				fEnableOK = false;

				TestDataButton.Enabled = false;
				}
			else
				TestDataButton.Enabled = true;

			//----------------------------------------------------------------------------*
			// Check COL
			//----------------------------------------------------------------------------*

			if (!COALTextBox.ValueOK)
				fEnableOK = false;

			//----------------------------------------------------------------------------*
			// Check Times Loaded
			//----------------------------------------------------------------------------*

			TimesFiredTextBox.MinValue = 0;
			TimesFiredTextBox.MaxValue = 50;

			if (!TimesFiredTextBox.ValueOK)
				fEnableOK = false;

			//----------------------------------------------------------------------------*
			// Check TrimLength
			//----------------------------------------------------------------------------*

			if (m_Batch.Load != null && m_Batch.Load.Caliber != null)
				{
				CaseTrimLengthTextBox.MinValue = cDataFiles.StandardToMetric(m_Batch.Load.Caliber.CaseTrimLength, cDataFiles.eDataType.Dimension);
				CaseTrimLengthTextBox.MaxValue = cDataFiles.StandardToMetric(m_Batch.Load.Caliber.MaxCaseLength, cDataFiles.eDataType.Dimension);
				}

			if (!CaseTrimLengthTextBox.ValueOK)
				fEnableOK = false;

			//----------------------------------------------------------------------------*
			// Check CBTO
			//----------------------------------------------------------------------------*

			CBTOTextBox.MinValue = 0.0;

			if (FirearmTypeCombo.Value != cFirearm.eFireArmType.Rifle || m_Batch.Load == null || m_Batch.Load.Caliber == null)
				{
				CBTOTextBox.MaxValue = 0.0;

				CBTOTextBox.Value = 0.0;

				CBTOTextBox.Enabled = false;
				}
			else
				{
				CBTOTextBox.Enabled = true;

				CBTOTextBox.MaxValue = cDataFiles.StandardToMetric(m_Batch.Load.Caliber.MaxCOL, cDataFiles.eDataType.Dimension);

				if (!CBTOTextBox.ValueOK)
					fEnableOK = false;
				}

			//----------------------------------------------------------------------------*
			// Check HeadSpace
			//----------------------------------------------------------------------------*

			HeadSpaceTextBox.MinValue = 0.0;

			if (FirearmTypeCombo.Value != cFirearm.eFireArmType.Rifle || m_Batch.Load == null || m_Batch.Load.Caliber == null)
				{
				HeadSpaceTextBox.MaxValue = 0.0;

				HeadSpaceTextBox.Value = 0.0;
				HeadSpaceTextBox.Enabled = false;
				}
			else
				{
				HeadSpaceTextBox.Enabled = true;

				HeadSpaceTextBox.MaxValue = cDataFiles.StandardToMetric(m_Batch.Load.Caliber.MaxCaseLength, cDataFiles.eDataType.Dimension);

				if (!HeadSpaceTextBox.ValueOK)
					fEnableOK = false;
				}

			//----------------------------------------------------------------------------*
			// Check Neck Size
			//----------------------------------------------------------------------------*

			NeckSizeTextBox.MinValue = 0.0;

			if (FirearmTypeCombo.Value != cFirearm.eFireArmType.Rifle || m_Batch.Load == null || m_Batch.Load.Caliber == null)
				{
				NeckSizeTextBox.MaxValue = 0.0;

				NeckSizeTextBox.Value = 0.0;
				NeckSizeTextBox.Enabled = false;
				}
			else
				{
				NeckSizeTextBox.Enabled = true;

				NeckSizeTextBox.MaxValue = cDataFiles.StandardToMetric(m_Batch.Load.Caliber.MaxBulletDiameter + cDataFiles.StandardToMetric(0.60, cDataFiles.eDataType.Dimension), cDataFiles.eDataType.Dimension);

				if (!NeckSizeTextBox.ValueOK)
					fEnableOK = false;
				}

			//----------------------------------------------------------------------------*
			// Check Jump
			//----------------------------------------------------------------------------*

			cFirearm Firearm = null;
			cFirearmBullet FirearmBullet = null;

			if (FirearmCombo.SelectedIndex > 0)
				Firearm = (cFirearm)FirearmCombo.SelectedItem;

			if (Firearm != null)
				{
				foreach (cFirearmBullet CheckFirearmBullet in Firearm.FirearmBulletList)
					{
					if (CheckFirearmBullet.Bullet.CompareTo(m_Batch.Load.Bullet) == 0)
						{
						FirearmBullet = CheckFirearmBullet;

						break;
						}
					}
				}

			JumpLabel.Visible = JumpSetCheckBox.Checked;
			JumpTextBox.Visible = JumpSetCheckBox.Checked;
			JumpMeasurementLabel.Visible = JumpSetCheckBox.Checked;

			if (JumpSetCheckBox.Checked &&
				FirearmBullet != null &&
				FirearmBullet.Jump != 0.0 &&
				FirearmBullet.COL != 0.0 &&
				COALTextBox.Value != 0.0)
				{
				double dAutoJump = FirearmBullet.Jump + (FirearmBullet.COL - cDataFiles.MetricToStandard(COALTextBox.Value, cDataFiles.eDataType.Dimension));

				m_Batch.Jump = dAutoJump;

				JumpTextBox.Value = cDataFiles.StandardToMetric(dAutoJump, cDataFiles.eDataType.Dimension);

				JumpTextBox.ReadOnly = true;
				JumpTextBox.BackColor = SystemColors.ButtonFace;
				}
			else
				{
				JumpTextBox.ReadOnly = false;
				JumpTextBox.BackColor = SystemColors.Window;
				}

			//----------------------------------------------------------------------------*
			// Check for firearms for Test Data button
			//----------------------------------------------------------------------------*

			if (TestDataButton.Enabled)
				{
				bool fFirearmFound = false;

				if (m_Batch.Load != null && m_Batch.Load.Caliber != null)
					{
					foreach (cFirearm CheckFirearm in m_DataFiles.FirearmList)
						{
						if (CheckFirearm.HasCaliber(Batch.Load.Caliber))
							{
							fFirearmFound = true;

							break;
							}
						}
					}

				if (!fFirearmFound)
					TestDataButton.Enabled = false;
				}

			//----------------------------------------------------------------------------*
			// Set Button States
			//----------------------------------------------------------------------------*

			BatchOKButton.Enabled = fEnableOK;
			PrintButton.Enabled = fEnableOK;
			}
		}
	}
