//============================================================================*
// cOCWForm.cs
//
// Copyright © 2013-2017, Kevin S. Beebe
// All Rights Reserved
//============================================================================*

//============================================================================*
// .Net Using Statements
//============================================================================*

using System;
using System.Windows.Forms;

//============================================================================*
// Namespace
//============================================================================*

namespace ReloadersWorkShop
	{
	//============================================================================*
	// cOCWForm Class
	//============================================================================*

	public partial class cOCWForm : Form
		{
		//============================================================================*
		// Private Constant Data Members
		//============================================================================*

		private const string cm_strMaxBatchesToolTip = "Maximum number of batches to be created.";
		private const string cm_strNumRoundsToolTip = "Number of rounds per batch.";
		private const string cm_strStartWeightToolTip = "Starting powder weight.";
		private const string cm_strIncrementToolTip = "Powder weight increment per batch.";

		//============================================================================*
		// Private Data Members
		//============================================================================*

		private bool m_fInitialized = false;
		private bool m_fPopulating = false;

		private bool m_fChanged = false;

		private cDataFiles m_DataFiles = null;
		private rOCW m_rOCW = new rOCW();
		private cBatch m_Batch = null;

		//============================================================================*
		// cOCWForm() - Constructor
		//============================================================================*

		public cOCWForm(cDataFiles DataFiles, rOCW OCW, cBatch Batch)
			{
			InitializeComponent();

			m_DataFiles = DataFiles;
			m_rOCW.Copy(OCW);
			m_Batch = Batch;

			SetClientSizeCore(SettingsGroupBox.Location.X + SettingsGroupBox.Width + 10, FormCancelButton.Location.Y + FormCancelButton.Height + 20);

			MaxNumBatchesTextBox.TextChanged += OnMaxNumChanged;
			NumRoundsTextBox.TextChanged += OnNumRoundsChanged;
			StartingWeightTextBox.TextChanged += OnStartWeightChanged;
			IncrementTextBox.TextChanged += OnIncrementChanged;

			SetStaticToolTips();

			SetInputParameters();

			cBatchForm.SetOCWString(m_DataFiles, OCWLabel, ref m_rOCW, m_Batch);

			PopulateOCWSettings();

			UpdateButtons();

			m_fInitialized = true;
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
		// OnIncrementChanged()
		//============================================================================*

		private void OnIncrementChanged(Object sender, EventArgs Args)
			{
			if (!m_fInitialized || m_fPopulating)
				return;

			m_rOCW.m_dChargeIncrement = IncrementTextBox.Value;

			cBatchForm.SetOCWString(m_DataFiles, OCWLabel, ref m_rOCW, m_Batch);

			m_fChanged = true;

			UpdateButtons();
			}

		//============================================================================*
		// OnMaxNumChanged()
		//============================================================================*

		private void OnMaxNumChanged(Object sender, EventArgs Args)
			{
			if (!m_fInitialized || m_fPopulating)
				return;

			m_rOCW.m_nMaxBatches = MaxNumBatchesTextBox.Value;

			cBatchForm.SetOCWString(m_DataFiles, OCWLabel, ref m_rOCW, m_Batch);

			m_fChanged = true;

			UpdateButtons();
			}

		//============================================================================*
		// OnNumRoundsChanged()
		//============================================================================*

		private void OnNumRoundsChanged(Object sender, EventArgs Args)
			{
			if (!m_fInitialized || m_fPopulating)
				return;

			m_rOCW.m_nNumRounds = NumRoundsTextBox.Value;

			cBatchForm.SetOCWString(m_DataFiles, OCWLabel, ref m_rOCW, m_Batch);

			m_fChanged = true;

			UpdateButtons();
			}

		//============================================================================*
		// OnStartWeightChanged()
		//============================================================================*

		private void OnStartWeightChanged(Object sender, EventArgs Args)
			{
			if (!m_fInitialized || m_fPopulating)
				return;

			m_rOCW.m_dStartCharge = StartingWeightTextBox.Value;

			cBatchForm.SetOCWString(m_DataFiles, OCWLabel, ref m_rOCW, m_Batch);

			m_fChanged = true;

			UpdateButtons();
			}

		//============================================================================*
		// PopulateOCWSettings()
		//============================================================================*

		private void PopulateOCWSettings()
			{
			m_fPopulating = true;

			MaxNumBatchesTextBox.Value = m_rOCW.m_nMaxBatches;
			NumRoundsTextBox.Value = m_rOCW.m_nNumRounds;
			StartingWeightTextBox.Value = m_rOCW.m_dStartCharge;
			IncrementTextBox.Value = m_rOCW.m_dChargeIncrement;

			m_fPopulating = false;
			}

		//============================================================================*
		// SetInputParameters()
		//============================================================================*

		private void SetInputParameters()
			{
			cDataFiles.SetInputParameters(StartingWeightTextBox, cDataFiles.eDataType.PowderWeight);

			double dMinWeight = 0.0;
			double dMaxWeight = 0.0;

			if (m_Batch != null && m_Batch.Load != null)
				{
				cCharge MinCharge = m_Batch.Load.ChargeList.MinCharge;
				cCharge MaxCharge = m_Batch.Load.ChargeList.MaxCharge;

				if (MinCharge != null)
					dMinWeight = MinCharge.PowderWeight;

				if (MaxCharge != null)
					dMaxWeight = MaxCharge.PowderWeight;
				}

			StartingWeightTextBox.MinValue = dMinWeight;
			StartingWeightTextBox.MaxValue = dMaxWeight;

			IncrementTextBox.MinValue = 0.1;

			cDataFiles.SetInputParameters(IncrementTextBox, cDataFiles.eDataType.PowderWeight);

			cDataFiles.SetMetricLabel(StartingWeightMeasurementLabel, cDataFiles.eDataType.PowderWeight);
			cDataFiles.SetMetricLabel(IncrementMeasurementLabel, cDataFiles.eDataType.PowderWeight);
			}

		//============================================================================*
		// UpdateButtons()
		//============================================================================*

		private void SetStaticToolTips()
			{
			if (!m_DataFiles.Preferences.ToolTips)
				return;

			MaxNumBatchesTextBox.ToolTip = cm_strMaxBatchesToolTip;
			NumRoundsTextBox.ToolTip = cm_strNumRoundsToolTip;
			StartingWeightTextBox.ToolTip = cm_strStartWeightToolTip;
			IncrementTextBox.ToolTip = cm_strIncrementToolTip;
			}

		//============================================================================*
		// UpdateButtons()
		//============================================================================*

		private void UpdateButtons()
			{
			bool fEnableOK = m_fChanged;

			cBatchForm.SetOCWString(m_DataFiles, OCWLabel, ref m_rOCW, m_Batch);

			if (!MaxNumBatchesTextBox.ValueOK)
				fEnableOK = false;

			if (!NumRoundsTextBox.ValueOK)
				fEnableOK = false;

			if (!StartingWeightTextBox.ValueOK)
				fEnableOK = false;

			if (!IncrementTextBox.ValueOK)
				fEnableOK = false;

			OKButton.Enabled = fEnableOK;
			}
		}
	}
