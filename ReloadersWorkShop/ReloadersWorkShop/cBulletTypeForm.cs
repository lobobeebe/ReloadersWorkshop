//============================================================================*
// cBulletTypeForm.cs
//
// Copyright © 2013-2014, Kevin S. Beebe
// All Rights Reserved
//============================================================================*

//============================================================================*
// .Net Using Statements
//============================================================================*

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

//============================================================================*
// NameSpace
//============================================================================*

namespace ReloadersWorkShop
	{
	//============================================================================*
	// cBulletTypeForm Class
	//============================================================================*

	public partial class cBulletTypeForm : Form
		{
		//----------------------------------------------------------------------------*
		// Private Data Members
		//----------------------------------------------------------------------------*

		private string m_strResultString = "";
		private cDataFiles m_DataFiles = null;

		//============================================================================*
		// cBulletTypeform() - Constructor
		//============================================================================*

		public cBulletTypeForm(string strTypeString, cDataFiles DataFiles)
			{
			InitializeComponent();

			m_DataFiles = DataFiles;

			//----------------------------------------------------------------------------*
			// Initialize Event Handlers
			//----------------------------------------------------------------------------*

			ModelTextBox.TextChanged += OnTextChanged;

			CustomTextBox.TextChanged += OnTextChanged;

			LeadRadioButton.Click += OnLeadButtonClicked;
			CastRadioButton.Click += OnCastButtonClicked;
			SwagedRadioButton.Click += OnSwagedButtonClicked;
			GasCheckRadioButton.Click += OnGasCheckButtonClicked;

			PlatedRadioButton.Click += OnPlatedButtonClicked;
			ShortJacketRadioButton.Click += OnShortJacketButtonClicked;
			JacketedRadioButton.Click += OnJacketedButtonClicked;
			FMJRadioButton.Click += OnFMJButtonClicked;
			TMJRadioButton.Click += OnTMJButtonClicked;

			RoundNoseRadioButton.Click += OnRoundNoseButtonClicked;
			HollowPointRadioButton.Click += OnHollowPointButtonClicked;
			WadCutterRadioButton.Click += OnWadCutterButtonClicked;
			SemiWadCutterRadioButton.Click += OnSemiWadCutterButtonClicked;
			FlatNoseRadioButton.Click += OnFlatNoseButtonClicked;
			FlatPointRadioButton.Click += OnFlatPointButtonClicked;
			SpirePointRadioButton.Click += OnSpirePointButtonClicked;
			TruncatedConeRadioButton.Click += OnTruncatedConeButtonClicked;

			BevelBaseRadioButton.Click += OnBevelBaseButtonClicked;
			BoatTailRadioButton.Click += OnBoatTailButtonClicked;
			FlatBaseRadioButton.Click += OnFlatBaseButtonClicked;
			HollowBaseRadioButton.Click += OnHollowBaseButtonClicked;

			MatchCheckBox.Click += OnCheckBoxClicked;
			CombatTargetCheckBox.Click += OnCheckBoxClicked;
			VarmintCheckBox.Click += OnCheckBoxClicked;
			HornetCheckBox.Click += OnCheckBoxClicked;
			CannelureCheckBox.Click += OnCheckBoxClicked;

			SetClientSizeCore(GeneralGroupBox.Location.X + GeneralGroupBox.Width + 10, BulletTypeCancelButton.Location.Y + BulletTypeCancelButton.Height + 20);

			//----------------------------------------------------------------------------*
			// Parse the strTypeString parameter
			//----------------------------------------------------------------------------*

			foreach (object Object in Controls)
				{
				if (Object is GroupBox)
					{
					foreach (object Control in (Object as GroupBox).Controls)
						{
						if (Control is RadioButton)
							{
							if (strTypeString.Contains((string)(Control as RadioButton).Tag))
								(Control as RadioButton).Checked = true;
							}
						}
					}

				if (Object is RadioButton)
					{
					if (strTypeString.Contains((string)(Object as RadioButton).Tag))
						(Object as RadioButton).Checked = true;
					}
				}

			//----------------------------------------------------------------------------*
			// Setup Starting Data
			//----------------------------------------------------------------------------*

			BuildResultString();

			SetStaticToolTips();

			//----------------------------------------------------------------------------*
			// Set Focus to the Model TextBox
			//----------------------------------------------------------------------------*

			ModelTextBox.Focus();
			}

		//============================================================================*
		// BuildResultString()
		//============================================================================*

		private void BuildResultString()
			{
			m_strResultString = "";

			//----------------------------------------------------------------------------*
			// Lead Bullet
			//----------------------------------------------------------------------------*

			if (LeadRadioButton.Checked)
				m_strResultString = (string)LeadRadioButton.Tag;

			if (CastRadioButton.Checked)
				m_strResultString = (string)CastRadioButton.Tag;

			if (SwagedRadioButton.Checked)
				m_strResultString = (string)SwagedRadioButton.Tag;

			if (GasCheckRadioButton.Checked)
				m_strResultString += (string)GasCheckRadioButton.Tag;

			//----------------------------------------------------------------------------*
			// Copper Jacketed Bullet
			//----------------------------------------------------------------------------*

			if (PlatedRadioButton.Checked)
				m_strResultString = (string)PlatedRadioButton.Tag;

			if (ShortJacketRadioButton.Checked)
				m_strResultString = (string)ShortJacketRadioButton.Tag;

			if (JacketedRadioButton.Checked)
				m_strResultString = (string)JacketedRadioButton.Tag;

			if (FMJRadioButton.Checked)
				m_strResultString = (string)FMJRadioButton.Tag;

			if (TMJRadioButton.Checked)
				m_strResultString = (string)TMJRadioButton.Tag;

			//----------------------------------------------------------------------------*
			// Shape
			//----------------------------------------------------------------------------*

			if (RoundNoseRadioButton.Checked)
				m_strResultString += (string)RoundNoseRadioButton.Tag;

			if (HollowPointRadioButton.Checked)
				m_strResultString += (string)HollowPointRadioButton.Tag;

			if (WadCutterRadioButton.Checked)
				m_strResultString += (string)WadCutterRadioButton.Tag;

			if (SemiWadCutterRadioButton.Checked)
				m_strResultString += (string)SemiWadCutterRadioButton.Tag;

			if (FlatNoseRadioButton.Checked)
				m_strResultString += (string)FlatNoseRadioButton.Tag;

			if (FlatPointRadioButton.Checked)
				m_strResultString += (string)FlatPointRadioButton.Tag;

			if (SpirePointRadioButton.Checked)
				m_strResultString += (string)SpirePointRadioButton.Tag;

			if (TruncatedConeRadioButton.Checked)
				m_strResultString += (string)TruncatedConeRadioButton.Tag;

			if (BoatTailRadioButton.Checked)
				m_strResultString += (string)BoatTailRadioButton.Tag;

			if (BevelBaseRadioButton.Checked)
				m_strResultString += (string)BevelBaseRadioButton.Tag;

			if (FlatBaseRadioButton.Checked)
				m_strResultString += (string)FlatBaseRadioButton.Tag;

			if (HollowBaseRadioButton.Checked)
				m_strResultString += (string)HollowBaseRadioButton.Tag;

			if (HornetCheckBox.Checked)
				{
				if (m_strResultString.Length > 0)
					m_strResultString += " ";

				m_strResultString += (string)HornetCheckBox.Tag;
				}

			if (MatchCheckBox.Checked)
				{
				if (m_strResultString.Length > 0)
					m_strResultString += " ";

				m_strResultString += (string)MatchCheckBox.Tag;
				}

			if (CombatTargetCheckBox.Checked)
				{
				if (m_strResultString.Length > 0)
					m_strResultString += " ";

				m_strResultString += (string)CombatTargetCheckBox.Tag;
				}

			if (VarmintCheckBox.Checked)
				{
				if (m_strResultString.Length > 0)
					m_strResultString += " ";

				m_strResultString += (string)VarmintCheckBox.Tag;
				}

			//----------------------------------------------------------------------------*
			// Add Model and Custom Text
			//----------------------------------------------------------------------------*

			if (ModelTextBox.Text.Length > 0)
				{
				if (m_strResultString.Length > 0)
					m_strResultString += " - ";

				m_strResultString += ModelTextBox.Text;
				}

			if (CustomTextBox.Text.Length > 0)
				{
				if (m_strResultString.Length > 0)
					m_strResultString += " - ";

				m_strResultString += CustomTextBox.Text;
				}

			//----------------------------------------------------------------------------*
			// Cannelure always goes at the end
			//----------------------------------------------------------------------------*

			if (CannelureCheckBox.Checked)
				{
				if (m_strResultString.Length > 0)
					m_strResultString += " ";

				m_strResultString += (string)CannelureCheckBox.Tag;
				}

			//----------------------------------------------------------------------------*
			// Set the result label and exit
			//----------------------------------------------------------------------------*

			ResultLabel.Text = m_strResultString;
			}

		//============================================================================*
		// OnBevelBaseButtonClicked()
		//============================================================================*

		private void OnBevelBaseButtonClicked(object sender, EventArgs e)
			{
			BevelBaseRadioButton.Checked = BevelBaseRadioButton.Checked ? false : true;

			if (BevelBaseRadioButton.Checked)
				{
				BoatTailRadioButton.Checked = false;
				FlatBaseRadioButton.Checked = false;
				HollowBaseRadioButton.Checked = false;
				}

			BuildResultString();
			}

		//============================================================================*
		// OnBoatTailButtonClicked()
		//============================================================================*

		private void OnBoatTailButtonClicked(object sender, EventArgs e)
			{
			BoatTailRadioButton.Checked = BoatTailRadioButton.Checked ? false : true;

			if (BoatTailRadioButton.Checked)
				{
				BevelBaseRadioButton.Checked = false;
				FlatBaseRadioButton.Checked = false;
				HollowBaseRadioButton.Checked = false;
				}

			BuildResultString();
			}

		//============================================================================*
		// OnCastButtonClicked()
		//============================================================================*

		private void OnCastButtonClicked(object sender, EventArgs e)
			{
			CastRadioButton.Checked = CastRadioButton.Checked ? false : true;

			if (CastRadioButton.Checked)
				{
				LeadRadioButton.Checked = false;
				SwagedRadioButton.Checked = false;

				PlatedRadioButton.Checked = false;
				JacketedRadioButton.Checked = false;
				FMJRadioButton.Checked = false;
				TMJRadioButton.Checked = false;
				}

			BuildResultString();
			}

		//============================================================================*
		// OnFlatBaseButtonClicked()
		//============================================================================*

		private void OnFlatBaseButtonClicked(object sender, EventArgs e)
			{
			FlatBaseRadioButton.Checked = FlatBaseRadioButton.Checked ? false : true;

			if (FlatBaseRadioButton.Checked)
				{
				BoatTailRadioButton.Checked = false;
				BevelBaseRadioButton.Checked = false;
				HollowBaseRadioButton.Checked = false;
				}

			BuildResultString();
			}

		//============================================================================*
		// OnFlatNoseButtonClicked()
		//============================================================================*

		private void OnFlatNoseButtonClicked(object sender, EventArgs e)
			{
			FlatNoseRadioButton.Checked = FlatNoseRadioButton.Checked ? false : true;

			if (FlatNoseRadioButton.Checked)
				{
				RoundNoseRadioButton.Checked = false;
				WadCutterRadioButton.Checked = false;
				SemiWadCutterRadioButton.Checked = false;
				FlatPointRadioButton.Checked = false;
				HollowPointRadioButton.Checked = false;
				SpirePointRadioButton.Checked = false;
				TruncatedConeRadioButton.Checked = false;
				}

			BuildResultString();
			}

		//============================================================================*
		// OnFlatPointButtonClicked()
		//============================================================================*

		private void OnFlatPointButtonClicked(object sender, EventArgs e)
			{
			FlatPointRadioButton.Checked = FlatPointRadioButton.Checked ? false : true;

			if (FlatPointRadioButton.Checked)
				{
				WadCutterRadioButton.Checked = false;
				SemiWadCutterRadioButton.Checked = false;
				FlatNoseRadioButton.Checked = false;
				HollowPointRadioButton.Checked = false;
				SpirePointRadioButton.Checked = false;
				TruncatedConeRadioButton.Checked = false;
				}

			BuildResultString();
			}

		//============================================================================*
		// OnFMJButtonClicked()
		//============================================================================*

		private void OnFMJButtonClicked(object sender, EventArgs e)
			{
			FMJRadioButton.Checked = FMJRadioButton.Checked ? false : true;

			if (FMJRadioButton.Checked)
				{
				LeadRadioButton.Checked = false;
				CastRadioButton.Checked = false;
				SwagedRadioButton.Checked = false;
				GasCheckRadioButton.Checked = false;

				PlatedRadioButton.Checked = false;
				ShortJacketRadioButton.Checked = false;
				JacketedRadioButton.Checked = false;
				TMJRadioButton.Checked = false;
				}

			BuildResultString();
			}

		//============================================================================*
		// OnGasCheckButtonClicked()
		//============================================================================*

		private void OnGasCheckButtonClicked(object sender, EventArgs e)
			{
			GasCheckRadioButton.Checked = GasCheckRadioButton.Checked ? false : true;

			if (GasCheckRadioButton.Checked)
				{
				PlatedRadioButton.Checked = false;
				JacketedRadioButton.Checked = false;
				FMJRadioButton.Checked = false;
				TMJRadioButton.Checked = false;

				if (!LeadRadioButton.Checked &&
					!CastRadioButton.Checked &&
					!SwagedRadioButton.Checked)
					LeadRadioButton.Checked = true;
				}

			BuildResultString();
			}

		//============================================================================*
		// OnCheckBoxClicked()
		//============================================================================*

		private void OnCheckBoxClicked(object sender, EventArgs e)
			{
			(sender as CheckBox).Checked = (sender as CheckBox).Checked ? false : true;

			BuildResultString();
			}

		//============================================================================*
		// OnHollowBaseButtonClicked()
		//============================================================================*

		private void OnHollowBaseButtonClicked(object sender, EventArgs e)
			{
			HollowBaseRadioButton.Checked = HollowBaseRadioButton.Checked ? false : true;

			if (HollowBaseRadioButton.Checked)
				{
				BoatTailRadioButton.Checked = false;
				BevelBaseRadioButton.Checked = false;
				FlatBaseRadioButton.Checked = false;
				}

			BuildResultString();
			}

		//============================================================================*
		// OnHollowPointButtonClicked()
		//============================================================================*

		private void OnHollowPointButtonClicked(object sender, EventArgs e)
			{
			HollowPointRadioButton.Checked = HollowPointRadioButton.Checked ? false : true;

			if (HollowPointRadioButton.Checked)
				{
				RoundNoseRadioButton.Checked = false;
				WadCutterRadioButton.Checked = false;
				SemiWadCutterRadioButton.Checked = false;
				FlatPointRadioButton.Checked = false;
				FlatNoseRadioButton.Checked = false;
				SpirePointRadioButton.Checked = false;
				TruncatedConeRadioButton.Checked = false;
				}

			BuildResultString();
			}

		//============================================================================*
		// OnJacketedButtonClicked()
		//============================================================================*

		private void OnJacketedButtonClicked(object sender, EventArgs e)
			{
			JacketedRadioButton.Checked = JacketedRadioButton.Checked ? false : true;

			if (JacketedRadioButton.Checked)
				{
				LeadRadioButton.Checked = false;
				CastRadioButton.Checked = false;
				SwagedRadioButton.Checked = false;
				GasCheckRadioButton.Checked = false;

				ShortJacketRadioButton.Checked = false;
				PlatedRadioButton.Checked = false;
				FMJRadioButton.Checked = false;
				TMJRadioButton.Checked = false;
				}

			BuildResultString();
			}

		//============================================================================*
		// OnLeadButtonClicked()
		//============================================================================*

		private void OnLeadButtonClicked(object sender, EventArgs e)
			{
			LeadRadioButton.Checked = LeadRadioButton.Checked ? false : true;

			if (LeadRadioButton.Checked)
				{
				CastRadioButton.Checked = false;
				SwagedRadioButton.Checked = false;

				PlatedRadioButton.Checked = false;
				JacketedRadioButton.Checked = false;
				FMJRadioButton.Checked = false;
				TMJRadioButton.Checked = false;
				}

			BuildResultString();
			}

		//============================================================================*
		// OnPlatedButtonClicked()
		//============================================================================*

		private void OnPlatedButtonClicked(object sender, EventArgs e)
			{
			PlatedRadioButton.Checked = PlatedRadioButton.Checked ? false : true;

			if (PlatedRadioButton.Checked)
				{
				LeadRadioButton.Checked = false;
				CastRadioButton.Checked = false;
				SwagedRadioButton.Checked = false;
				GasCheckRadioButton.Checked = false;

				ShortJacketRadioButton.Checked = false;
				JacketedRadioButton.Checked = false;
				FMJRadioButton.Checked = false;
				TMJRadioButton.Checked = false;
				}

			BuildResultString();
			}

		//============================================================================*
		// OnRadioButtonClicked()
		//============================================================================*

		private void OnRadioButtonClicked(object sender, EventArgs e)
			{
			(sender as RadioButton).Checked = (sender as RadioButton).Checked ? false : true;

			BuildResultString();
			}

		//============================================================================*
		// OnRoundNoseButtonClicked()
		//============================================================================*

		private void OnRoundNoseButtonClicked(object sender, EventArgs e)
			{
			RoundNoseRadioButton.Checked = RoundNoseRadioButton.Checked ? false : true;

			if (RoundNoseRadioButton.Checked)
				{
				HollowPointRadioButton.Checked = false;
				WadCutterRadioButton.Checked = false;
				SemiWadCutterRadioButton.Checked = false;
				FlatNoseRadioButton.Checked = false;
				SpirePointRadioButton.Checked = false;
				TruncatedConeRadioButton.Checked = false;
				}

			BuildResultString();
			}

		//============================================================================*
		// OnSemiWadCutterButtonClicked()
		//============================================================================*

		private void OnSemiWadCutterButtonClicked(object sender, EventArgs e)
			{
			SemiWadCutterRadioButton.Checked = SemiWadCutterRadioButton.Checked ? false : true;

			if (SemiWadCutterRadioButton.Checked)
				{
				RoundNoseRadioButton.Checked = false;
				HollowPointRadioButton.Checked = false;
				WadCutterRadioButton.Checked = false;
				FlatPointRadioButton.Checked = false;
				FlatNoseRadioButton.Checked = false;
				SpirePointRadioButton.Checked = false;
				TruncatedConeRadioButton.Checked = false;
				}

			BuildResultString();
			}

		//============================================================================*
		// OnShortJacketButtonClicked()
		//============================================================================*

		private void OnShortJacketButtonClicked(object sender, EventArgs e)
			{
			ShortJacketRadioButton.Checked = ShortJacketRadioButton.Checked ? false : true;

			if (ShortJacketRadioButton.Checked)
				{
				LeadRadioButton.Checked = false;
				CastRadioButton.Checked = false;
				SwagedRadioButton.Checked = false;
				GasCheckRadioButton.Checked = false;

				PlatedRadioButton.Checked = false;
				FMJRadioButton.Checked = false;
				JacketedRadioButton.Checked = false;
				TMJRadioButton.Checked = false;
				}

			BuildResultString();
			}

		//============================================================================*
		// OnSpirePointButtonClicked()
		//============================================================================*

		private void OnSpirePointButtonClicked(object sender, EventArgs e)
			{
			SpirePointRadioButton.Checked = SpirePointRadioButton.Checked ? false : true;

			if (SpirePointRadioButton.Checked)
				{
				RoundNoseRadioButton.Checked = false;
				HollowPointRadioButton.Checked = false;
				SemiWadCutterRadioButton.Checked = false;
				FlatPointRadioButton.Checked = false;
				FlatNoseRadioButton.Checked = false;
				WadCutterRadioButton.Checked = false;
				TruncatedConeRadioButton.Checked = false;
				}

			BuildResultString();
			}

		//============================================================================*
		// OnSwagedButtonClicked()
		//============================================================================*

		private void OnSwagedButtonClicked(object sender, EventArgs e)
			{
			SwagedRadioButton.Checked = SwagedRadioButton.Checked ? false : true;

			if (SwagedRadioButton.Checked)
				{
				LeadRadioButton.Checked = false;
				CastRadioButton.Checked = false;

				PlatedRadioButton.Checked = false;
				JacketedRadioButton.Checked = false;
				FMJRadioButton.Checked = false;
				TMJRadioButton.Checked = false;
				}

			BuildResultString();
			}

		//============================================================================*
		// OnTextChanged()
		//============================================================================*

		private void OnTextChanged(object sender, EventArgs e)
			{
			BuildResultString();
			}

		//============================================================================*
		// OnTMJButtonClicked()
		//============================================================================*

		private void OnTMJButtonClicked(object sender, EventArgs e)
			{
			TMJRadioButton.Checked = TMJRadioButton.Checked ? false : true;

			if (TMJRadioButton.Checked)
				{
				LeadRadioButton.Checked = false;
				CastRadioButton.Checked = false;
				SwagedRadioButton.Checked = false;
				GasCheckRadioButton.Checked = false;

				PlatedRadioButton.Checked = false;
				ShortJacketRadioButton.Checked = false;
				JacketedRadioButton.Checked = false;
				FMJRadioButton.Checked = false;
				}

			BuildResultString();
			}

		//============================================================================*
		// OnTruncatedConeButtonClicked()
		//============================================================================*

		private void OnTruncatedConeButtonClicked(object sender, EventArgs e)
			{
			TruncatedConeRadioButton.Checked = TruncatedConeRadioButton.Checked ? false : true;

			if (TruncatedConeRadioButton.Checked)
				{
				RoundNoseRadioButton.Checked = false;
				HollowPointRadioButton.Checked = false;
				SemiWadCutterRadioButton.Checked = false;
				FlatPointRadioButton.Checked = false;
				FlatNoseRadioButton.Checked = false;
				WadCutterRadioButton.Checked = false;
				SpirePointRadioButton.Checked = false;
				}

			BuildResultString();
			}

		//============================================================================*
		// OnWadCutterButtonClicked()
		//============================================================================*

		private void OnWadCutterButtonClicked(object sender, EventArgs e)
			{
			WadCutterRadioButton.Checked = WadCutterRadioButton.Checked ? false : true;

			if (WadCutterRadioButton.Checked)
				{
				RoundNoseRadioButton.Checked = false;
				HollowPointRadioButton.Checked = false;
				SemiWadCutterRadioButton.Checked = false;
				FlatPointRadioButton.Checked = false;
				FlatNoseRadioButton.Checked = false;
				SpirePointRadioButton.Checked = false;
				TruncatedConeRadioButton.Checked = false;
				}

			BuildResultString();
			}

		//============================================================================*
		// ResultString Property
		//============================================================================*

		public string ResultString
			{
			get { return (m_strResultString); }
			}

		//============================================================================*
		// SetStaticToolTips()
		//============================================================================*

		private void SetStaticToolTips()
			{
			if (!m_DataFiles.Preferences.ToolTips)
				return;

			ToolTip Tip;

			Tip = new ToolTip();
			Tip.ShowAlways = true;
			Tip.RemoveAll();
			Tip.SetToolTip(ModelTextBox, "Manufacturer specific model for this bullet.");

			Tip = new ToolTip();
			Tip.ShowAlways = true;
			Tip.RemoveAll();
			Tip.SetToolTip(ModelTextBox, "Any additional custom info you would like in the bullet's type description.");
			}
		}
	}
