//============================================================================*
// cTargetPreferencesForm.cs
//
// Copyright © 2013-2014, Kevin S. Beebe
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
	// cTargetCalculatorForm Class
	//============================================================================*

	public partial class cTargetPreferencesForm : Form
		{
		//============================================================================*
		// Private Data Members
		//============================================================================*

		private cDataFiles m_DataFiles = null;
		private cTarget m_Target = null;
		private cTargetCalculatorForm m_TargetForm = null;

		//============================================================================*
		// cTargetPreferencesForm()
		//============================================================================*

		public cTargetPreferencesForm(cDataFiles DataFiles, cTarget Target, cTargetCalculatorForm TargetForm)
			{
			InitializeComponent();

			m_DataFiles = DataFiles;
			m_Target = Target;
			m_TargetForm = TargetForm;

			//----------------------------------------------------------------------------*
			// Event Handlers
			//----------------------------------------------------------------------------*

			AimPointColorButton.Click += OnColorButtonClicked;
			OffsetColorButton.Click += OnColorButtonClicked;
			ShotColorButton.Click += OnColorButtonClicked;
			ReticleColorButton.Click += OnColorButtonClicked;
			CalibrationForecolorButton.Click += OnColorButtonClicked;
			CalibrationBackcolorButton.Click += OnColorButtonClicked;

			ResetButton.Click += OnResetDefaultsClicked;

			//----------------------------------------------------------------------------*
			// Populate Colors
			//----------------------------------------------------------------------------*

			AimPointColorButton.BackColor = m_Target.AimPointColor;
			OffsetColorButton.BackColor = m_Target.OffsetColor;
			ShotColorButton.BackColor = m_Target.ShotColor;
			ReticleColorButton.BackColor = m_Target.ReticleColor;
			CalibrationForecolorButton.BackColor = m_Target.CalibrationForecolor;
			CalibrationBackcolorButton.BackColor = m_Target.CalibrationBackcolor;

			CalibrationBackcolorButton.ForeColor = m_Target.CalibrationForecolor;
			}

		//============================================================================*
		// OnColorButtonClicked()
		//============================================================================*

		private void OnColorButtonClicked(Object sender, EventArgs e)
			{
			Button ColorButton = (Button) sender;

			ColorDialog ColorDialog = new ColorDialog();

			ColorDialog.SolidColorOnly = true;
			ColorDialog.Color = ColorButton.BackColor;
			ColorDialog.AnyColor = true;

			DialogResult rc = ColorDialog.ShowDialog();

			if (rc == DialogResult.OK)
				{
				if (ColorButton.BackColor != ColorDialog.Color)
					{
					//----------------------------------------------------------------------------*
					// Aim Point Color
					//----------------------------------------------------------------------------*

					if (ColorButton.Name == "AimPointColorButton")
						{
						m_Target.AimPointColor = ColorDialog.Color;

						if (!TargetOnlyCheckBox.Checked)
							m_DataFiles.Preferences.AimPointColor = ColorDialog.Color;

						ColorButton.BackColor = ColorDialog.Color;
						}

					//----------------------------------------------------------------------------*
					// Aim Point Offset Color
					//----------------------------------------------------------------------------*

					if (ColorButton.Name == "OffsetColorButton")
						{
						m_Target.OffsetColor = ColorDialog.Color;

						if (!TargetOnlyCheckBox.Checked)
							m_DataFiles.Preferences.OffsetColor = ColorDialog.Color;

						ColorButton.BackColor = ColorDialog.Color;
						}

					//----------------------------------------------------------------------------*
					// Reticle Color
					//----------------------------------------------------------------------------*

					if (ColorButton.Name == "ReticleColorButton")
						{
						m_Target.ReticleColor = ColorDialog.Color;

						if (!TargetOnlyCheckBox.Checked)
							m_DataFiles.Preferences.ReticleColor = ColorDialog.Color;

						ColorButton.BackColor = ColorDialog.Color;
						}

					//----------------------------------------------------------------------------*
					// Shot Color
					//----------------------------------------------------------------------------*

					if (ColorButton.Name == "ShotColorButton")
						{
						m_Target.ShotColor = ColorDialog.Color;

						if (!TargetOnlyCheckBox.Checked)
							m_DataFiles.Preferences.ShotColor = ColorDialog.Color;

						ColorButton.BackColor = ColorDialog.Color;
						}

					//----------------------------------------------------------------------------*
					// Calibration Fore Color
					//----------------------------------------------------------------------------*

					if (ColorButton.Name == "CalibrationForecolorButton")
						{
						m_Target.CalibrationForecolor = ColorDialog.Color;

						if (!TargetOnlyCheckBox.Checked)
							m_DataFiles.Preferences.CalibrationForecolor = ColorDialog.Color;

						ColorButton.BackColor = ColorDialog.Color;
						CalibrationBackcolorButton.ForeColor = ColorDialog.Color;
						}

					//----------------------------------------------------------------------------*
					// Calibration Back Color
					//----------------------------------------------------------------------------*

					if (ColorButton.Name == "CalibrationBackcolorButton")
						{
						m_Target.CalibrationBackcolor = ColorDialog.Color;

						if (!TargetOnlyCheckBox.Checked)
							m_DataFiles.Preferences.CalibrationBackcolor = ColorDialog.Color;

						ColorButton.BackColor = ColorDialog.Color;
						}

					//----------------------------------------------------------------------------*
					// Redraw Target Calculator image with new colors
					//----------------------------------------------------------------------------*

					m_TargetForm.ResetBitmaps();
					}
				}
			}

		//============================================================================*
		// OnResetDefaultsClicked()
		//============================================================================*

		private void OnResetDefaultsClicked(Object sender, EventArgs e)
			{
			m_Target.AimPointColor = cTarget.DefaultAimPointColor;
			m_Target.OffsetColor = cTarget.DefaultOffsetColor;
			m_Target.ShotColor = cTarget.DefaultShotColor;
			m_Target.ReticleColor = cTarget.DefaultReticleColor;
			m_Target.CalibrationBackcolor = cTarget.DefaultCalibrationBackcolor;
			m_Target.CalibrationForecolor = cTarget.DefaultCalibrationForecolor;

			if (!TargetOnlyCheckBox.Checked)
				{
				m_DataFiles.Preferences.AimPointColor = cTarget.DefaultAimPointColor;
				m_DataFiles.Preferences.OffsetColor = cTarget.DefaultOffsetColor;
				m_DataFiles.Preferences.ShotColor = cTarget.DefaultShotColor;
				m_DataFiles.Preferences.ReticleColor = cTarget.DefaultReticleColor;
				m_DataFiles.Preferences.CalibrationBackcolor = cTarget.DefaultCalibrationBackcolor;
				m_DataFiles.Preferences.CalibrationForecolor = cTarget.DefaultCalibrationForecolor;
				}

			AimPointColorButton.BackColor = cTarget.DefaultAimPointColor;
			OffsetColorButton.BackColor = cTarget.DefaultOffsetColor;
			ShotColorButton.BackColor = cTarget.DefaultShotColor;
			ReticleColorButton.BackColor = cTarget.DefaultReticleColor;
			CalibrationForecolorButton.BackColor = cTarget.DefaultCalibrationForecolor;
			CalibrationBackcolorButton.BackColor = cTarget.DefaultCalibrationBackcolor;
			CalibrationBackcolorButton.ForeColor = cTarget.DefaultCalibrationForecolor;

			m_TargetForm.ResetBitmaps();
			}
		}
	}
