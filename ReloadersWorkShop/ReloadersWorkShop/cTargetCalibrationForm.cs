//============================================================================*
// cTarget.cs
//
// Copyright © 2013-2016, Kevin S. Beebe
// All Rights Reserved
//============================================================================*

//============================================================================*
// .Net Using Statements
//============================================================================*

using System;
using System.Windows.Forms;

//============================================================================*
// NameSpace
//============================================================================*

namespace ReloadersWorkShop
	{
	//============================================================================*
	// cTargetCalibrationForm Class
	//============================================================================*

	public partial class cTargetCalibrationForm : Form
		{
		//============================================================================*
		// Private Data Members
		//============================================================================*

		private cDataFiles m_DataFiles = null;
		private cTarget m_Target = null;

		//============================================================================*
		// cTargetCalibrationForm() - Constructor
		//============================================================================*

		public cTargetCalibrationForm(cDataFiles DataFiles, cTarget Target)
			{
			InitializeComponent();

			m_DataFiles = DataFiles;
			m_Target = Target;

			//----------------------------------------------------------------------------*
			// Event Handlers
			//----------------------------------------------------------------------------*

			CalibrationLengthTextBox.TextChanged += OnLengthChanged;

			//----------------------------------------------------------------------------*
			// Input Parameters
			//----------------------------------------------------------------------------*

			m_DataFiles.SetInputParameters(CalibrationLengthTextBox, cDataFiles.eDataType.GroupSize);
			CalibrationLengthTextBox.MinValue = m_Target.MinCalibrationLength;

			//----------------------------------------------------------------------------*
			// Populate Form
			//----------------------------------------------------------------------------*

			CalibrationLengthTextBox.Value = m_DataFiles.StandardToMetric(m_Target.CalibrationLength, cDataFiles.eDataType.GroupSize);
			LengthMeasurementLabel.Text = m_DataFiles.MetricString(cDataFiles.eDataType.GroupSize);

			SetDPILabel();

			UpdateButtons();
			}

		//============================================================================*
		// OnLengthChanged()
		//============================================================================*

		protected void OnLengthChanged(object sender, EventArgs e)
			{
			m_Target.CalibrationLength = m_DataFiles.MetricToStandard(CalibrationLengthTextBox.Value, cDataFiles.eDataType.GroupSize);

			SetDPILabel();

			UpdateButtons();
			}

		//============================================================================*
		// SetDPILabel()
		//============================================================================*

		private void SetDPILabel()
			{
			string strDPI = string.Format("{0:N0} pixels in Scale Line = {1:F3} {2} ({3:N0} DP{4})", m_Target.CalibrationPixels, m_DataFiles.StandardToMetric(m_Target.CalibrationLength, cDataFiles.eDataType.GroupSize), m_DataFiles.MetricLongString(cDataFiles.eDataType.GroupSize), m_Target.CalibrationDPC, m_DataFiles.Preferences.MetricGroups ? "C" : "I");

			DPILabel.Text = strDPI;
			}

		//============================================================================*
		// UpdateButtons()
		//============================================================================*

		private void UpdateButtons()
			{
			bool fEnableOK = true;

			if (m_Target.CalibrationLength < m_Target.MinCalibrationLength)
				fEnableOK = false;

			OKButton.Enabled = fEnableOK;
			}
		}
	}
