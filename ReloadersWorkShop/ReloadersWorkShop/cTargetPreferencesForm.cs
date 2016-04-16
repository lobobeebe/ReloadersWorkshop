//============================================================================*
// cTargetPreferencesForm.cs
//
// Copyright © 2016, Kevin S. Beebe
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
			ExtremesColorButton.Click += OnColorButtonClicked;
			GroupBoxColorButton.Click += OnColorButtonClicked;

			ResetButton.Click += OnResetDefaultsClicked;

			SetClientSizeCore(ColorsGroupBox.Location.X + ColorsGroupBox.Width + 10, CloseButton.Location.Y + CloseButton.Height + 20);

			//----------------------------------------------------------------------------*
			// Populate Colors
			//----------------------------------------------------------------------------*

			AimPointColorButton.BackColor = m_Target.AimPointColor;
			OffsetColorButton.BackColor = m_Target.OffsetColor;
			ShotColorButton.BackColor = m_Target.ShotColor;
			ReticleColorButton.BackColor = m_Target.ReticleColor;
			CalibrationForecolorButton.BackColor = m_Target.ScaleForecolor;
			CalibrationBackcolorButton.BackColor = m_Target.ScaleBackcolor;
			ExtremesColorButton.BackColor = m_Target.ExtremesColor;
			GroupBoxColorButton.BackColor = m_Target.GroupBoxColor;

			CalibrationBackcolorButton.ForeColor = m_Target.ScaleForecolor;
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
							m_DataFiles.Preferences.TargetAimPointColor = ColorDialog.Color;

						ColorButton.BackColor = ColorDialog.Color;
						}

					//----------------------------------------------------------------------------*
					// Aim Point Offset Color
					//----------------------------------------------------------------------------*

					if (ColorButton.Name == "OffsetColorButton")
						{
						m_Target.OffsetColor = ColorDialog.Color;

						if (!TargetOnlyCheckBox.Checked)
							m_DataFiles.Preferences.TargetOffsetColor = ColorDialog.Color;

						ColorButton.BackColor = ColorDialog.Color;
						}

					//----------------------------------------------------------------------------*
					// Extremes Color
					//----------------------------------------------------------------------------*

					if (ColorButton.Name == "ExtremesColorButton")
						{
						m_Target.ExtremesColor = ColorDialog.Color;

						if (!TargetOnlyCheckBox.Checked)
							m_DataFiles.Preferences.TargetExtremesColor = ColorDialog.Color;

						ColorButton.BackColor = ColorDialog.Color;
						}

					//----------------------------------------------------------------------------*
					// GroupBox Color
					//----------------------------------------------------------------------------*

					if (ColorButton.Name == "GroupBoxColorButton")
						{
						m_Target.GroupBoxColor = ColorDialog.Color;

						if (!TargetOnlyCheckBox.Checked)
							m_DataFiles.Preferences.TargetGroupBoxColor = ColorDialog.Color;

						ColorButton.BackColor = ColorDialog.Color;
						}

					//----------------------------------------------------------------------------*
					// Reticle Color
					//----------------------------------------------------------------------------*

					if (ColorButton.Name == "ReticleColorButton")
						{
						m_Target.ReticleColor = ColorDialog.Color;

						if (!TargetOnlyCheckBox.Checked)
							m_DataFiles.Preferences.TargetReticleColor = ColorDialog.Color;

						ColorButton.BackColor = ColorDialog.Color;
						}

					//----------------------------------------------------------------------------*
					// Shot Color
					//----------------------------------------------------------------------------*

					if (ColorButton.Name == "ShotColorButton")
						{
						m_Target.ShotColor = ColorDialog.Color;

						if (!TargetOnlyCheckBox.Checked)
							m_DataFiles.Preferences.TargetShotColor = ColorDialog.Color;

						ColorButton.BackColor = ColorDialog.Color;
						}

					//----------------------------------------------------------------------------*
					// Calibration Fore Color
					//----------------------------------------------------------------------------*

					if (ColorButton.Name == "CalibrationForecolorButton")
						{
						m_Target.ScaleForecolor = ColorDialog.Color;

						if (!TargetOnlyCheckBox.Checked)
							m_DataFiles.Preferences.TargetScaleForecolor = ColorDialog.Color;

						ColorButton.BackColor = ColorDialog.Color;
						CalibrationBackcolorButton.ForeColor = ColorDialog.Color;
						}

					//----------------------------------------------------------------------------*
					// Calibration Back Color
					//----------------------------------------------------------------------------*

					if (ColorButton.Name == "CalibrationBackcolorButton")
						{
						m_Target.ScaleBackcolor = ColorDialog.Color;

						if (!TargetOnlyCheckBox.Checked)
							m_DataFiles.Preferences.TargetScaleBackcolor = ColorDialog.Color;

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
			m_Target.SetDefaultColors();

			if (!TargetOnlyCheckBox.Checked)
				{
				m_DataFiles.Preferences.TargetAimPointColor = cTarget.DefaultAimPointColor;
				m_DataFiles.Preferences.TargetOffsetColor = cTarget.DefaultOffsetColor;
				m_DataFiles.Preferences.TargetShotColor = cTarget.DefaultShotColor;
				m_DataFiles.Preferences.TargetReticleColor = cTarget.DefaultReticleColor;
				m_DataFiles.Preferences.TargetScaleBackcolor = cTarget.DefaultScaleBackcolor;
				m_DataFiles.Preferences.TargetScaleForecolor = cTarget.DefaultScaleForecolor;
				m_DataFiles.Preferences.TargetExtremesColor = cTarget.DefaultExtremesColor;
				m_DataFiles.Preferences.TargetGroupBoxColor = cTarget.DefaultGroupBoxColor;
				}

			AimPointColorButton.BackColor = cTarget.DefaultAimPointColor;
			OffsetColorButton.BackColor = cTarget.DefaultOffsetColor;
			ShotColorButton.BackColor = cTarget.DefaultShotColor;
			ReticleColorButton.BackColor = cTarget.DefaultReticleColor;
			CalibrationForecolorButton.BackColor = cTarget.DefaultScaleForecolor;
			CalibrationBackcolorButton.BackColor = cTarget.DefaultScaleBackcolor;
			CalibrationBackcolorButton.ForeColor = cTarget.DefaultScaleForecolor;
			ExtremesColorButton.ForeColor = cTarget.DefaultExtremesColor;
			GroupBoxColorButton.BackColor = cTarget.DefaultGroupBoxColor;

			m_TargetForm.ResetBitmaps();
			}
		}
	}
