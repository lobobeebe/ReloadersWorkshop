//============================================================================*
// cCaliberForm.cs
//
// Copyright © 2013-2017, Kevin S. Beebe
// All Rights Reserved
//============================================================================*

//============================================================================*
// .Net Using Statements
//============================================================================*

using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

//============================================================================*
// Application Specific Using Statements
//============================================================================*

//============================================================================*
// NameSpace
//============================================================================*

namespace ReloadersWorkShop
	{
	//============================================================================*
	// cCaliberForm Class
	//============================================================================*

	public partial class cCaliberForm : Form
		{
		//----------------------------------------------------------------------------*
		// Private Constant Data Members
		//----------------------------------------------------------------------------*

		private const string cm_strFirearmTypeToolTip = "Type of firearm for which this caliber is designed.";
		private const string cm_strNameToolTip = "Name of this caliber.";
		private const string cm_strHeadStampToolTip = "HeadStamp description (or abbreviated name) of this caliber.";
		private const string cm_strPrimerSizeToolTip = "Size of the primer used in cartridges of this caliber.";
		private const string cm_strMagnumToolTip = "Indicates whether this is a magnum caliber.";
		private const string cm_strRimfireToolTip = "Indicates whether this is a rimfire caliber.";

		private const string cm_strPistolToolTip = "Indicates that this is a pistol caliber.";
		private const string cm_strRevolverToolTip = "Indicates that this is a revolver caliber.";

		private const string cm_strMinBulletDiameterToolTip = "Minimum bullet diameter of bullets usable for cartridges of this caliber.";
		private const string cm_strMaxBulletDiameterToolTip = "Maximum bullet diameter of bullets usable for cartridges of this caliber.";
		private const string cm_strMinBulletWeightToolTip = "Minimum bullet weight of bullets usable for cartridges of this caliber.";
		private const string cm_strMaxBulletWeightToolTip = "Maximum bullet weight of bullets usable for cartridges of this caliber.";
		private const string cm_strMinShotWeightToolTip = "Minimum shot weight for this shotgun caliber.";
		private const string cm_strMaxShotWeightToolTip = "Maximum shot weight for this shotgun caliber.";
		private const string cm_strCaseTrimLengthToolTip = "Length to which cases for cartridges of this caliber should be trimmed.";
		private const string cm_strMaxCaseLengthToolTip = "Maximum length of cases for cartridges of this caliber.";
		private const string cm_strMaxCOLToolTip = "Maximum Cartridge Overall Length (COAL) of cartridges in this caliber.";
		private const string cm_strMaxNeckDiameterToolTip = "Maximum neck diameter of cartridges of this caliber.";

		private const string cm_strSAAMIPDFToolTip = "Name of the SAAMI PDF file containg the drawing for cartridges of this caliber.\nYou do not need to specify the full URL, just the PDf file name.  You may leave the .pdf extension off as well.";

		//----------------------------------------------------------------------------*
		// Private Data Members
		//----------------------------------------------------------------------------*

		private bool m_fChanged = false;
		private bool m_fInitialized = false;

		private cCaliber m_Caliber;
		private bool m_fViewOnly = false;

		private ToolTip m_FirearmTypeToolTip = new ToolTip();

		private ToolTip m_PistolToolTip = new ToolTip();
		private ToolTip m_RevolverToolTip = new ToolTip();

		private ToolTip m_PrimerSizeToolTip = new ToolTip();
		private ToolTip m_MagnumToolTip = new ToolTip();
		private ToolTip m_RimfireToolTip = new ToolTip();

		private cDataFiles m_DataFiles = null;

		//============================================================================*
		// cCaliberForm() - Constructor
		//============================================================================*

		public cCaliberForm(cCaliber Caliber, cDataFiles DataFiles, bool fViewOnly = false)
			{
			InitializeComponent();

			m_DataFiles = DataFiles;
			m_fViewOnly = fViewOnly;

			if (Caliber == null)
				{
				if (m_fViewOnly)
					return;

				m_Caliber = new cCaliber();

				OKButton.ButtonType = CommonLib.Controls.cOKButton.eButtonTypes.Add;
				}
			else
				{
				m_Caliber = new cCaliber(Caliber);

				if (!m_fViewOnly)
					OKButton.ButtonType = CommonLib.Controls.cOKButton.eButtonTypes.Update;
				else
					FormCancelButton.ButtonType = CommonLib.Controls.cCancelButton.eButtonTypes.Close;
				}

			SetClientSizeCore(GeneralGroupBox.Location.X + GeneralGroupBox.Width + 10, FormCancelButton.Location.Y + FormCancelButton.Height + 20);

			//----------------------------------------------------------------------------*
			// Set Control Event Handlers
			//----------------------------------------------------------------------------*

			if (!m_fViewOnly)
				{
				FirearmTypeCombo.SelectedIndexChanged += OnFirearmTypeChanged;

				NameTextBox.TextChanged += OnNameChanged;
				HeadStampTextBox.TextChanged += OnHeadStampChanged;

				PistolRadioButton.Click += OnPistolClicked;
				RevolverRadioButton.Click += OnRevolverClicked;

				SmallPrimerCheckBox.Click += OnSmallPrimerClicked;
				LargePrimerCheckBox.Click += OnLargePrimerClicked;
				MagnumPrimerCheckBox.Click += OnMagnumClicked;
				RimfireCheckBox.Click += OnRimfireClicked;

				CaseTrimLengthTextBox.TextChanged += OnCaseTrimLengthChanged;
				MaxBulletDiameterTextBox.TextChanged += OnMaxBulletDiameterChanged;
				MaxBulletWeightTextBox.TextChanged += OnMaxBulletWeightChanged;
				MaxCaseLengthTextBox.TextChanged += OnMaxCaseLengthChanged;
				MaxCOLTextBox.TextChanged += OnMaxCOLChanged;
				MinBulletDiameterTextBox.TextChanged += OnMinBulletDiameterChanged;
				MinBulletWeightTextBox.TextChanged += OnMinBulletWeightChanged;
				MaxNeckDiameterTextBox.TextChanged += OnMaxNeckDiameterChanged;
				SAAMIPDFTextBox.TextChanged += OnSAAMIPDFChanged;
				TestSAAMIPDFButton.Click += OnTestSAAMIPDFClicked;
				}
			else
				{
				FirearmTypeCombo.Enabled = false;
				NameTextBox.ReadOnly = true;
				HeadStampTextBox.ReadOnly = true;
				SmallPrimerCheckBox.Enabled = false;
				LargePrimerCheckBox.Enabled = false;
				MagnumPrimerCheckBox.Enabled = false;
				MinBulletDiameterTextBox.ReadOnly = true;
				MaxBulletDiameterTextBox.ReadOnly = true;
				MinBulletWeightTextBox.ReadOnly = true;
				MaxBulletWeightTextBox.ReadOnly = true;
				CaseTrimLengthTextBox.ReadOnly = true;
				MaxCaseLengthTextBox.ReadOnly = true;
				MaxCOLTextBox.ReadOnly = true;
				MaxNeckDiameterTextBox.ReadOnly = true;
				SAAMIPDFTextBox.ReadOnly = true;

				OKButton.Visible = false;
				}

			SetInputParameters();

			//----------------------------------------------------------------------------*
			// Fill in the data fields
			//----------------------------------------------------------------------------*

			SetStaticToolTips();

			PopulateCaliberData();

			if (FirearmTypeCombo.Value != cFirearm.eFireArmType.Rifle && FirearmTypeCombo.Value != cFirearm.eFireArmType.Handgun)
				{
				MaxNeckDiameterLabel.Visible = false;
				MaxNeckDiameterTextBox.Visible = false;
				MaxNeckDiameterMeasurementLabel.Visible = false;
				}

			//----------------------------------------------------------------------------*
			// Set title and text fields
			//----------------------------------------------------------------------------*

			string strTitle;

			if (Caliber == null)
				{
				strTitle = "Add";
				}
			else
				{
				if (!m_fViewOnly)
					strTitle = "Edit";
				else
					{
					strTitle = "View";

					int nButtonX = (this.Size.Width / 2) - (FormCancelButton.Width / 2);

					FormCancelButton.Location = new Point(nButtonX, FormCancelButton.Location.Y);

					FormCancelButton.Text = "Close";
					}
				}

			strTitle += " Caliber";

			Text = strTitle;

			ConfigureFirearmType();

			if (!m_fViewOnly)
				{
				UpdateButtons();

				FirearmTypeCombo.Focus();
				}
			else
				FormCancelButton.Focus();

			m_fInitialized = true;

			UpdateButtons();
			}

		//============================================================================*
		// Caliber Property
		//============================================================================*

		public cCaliber Caliber
			{
			get { return (m_Caliber); }
			}

		//============================================================================*
		// ConfigureFirearmType()
		//============================================================================*

		private void ConfigureFirearmType()
			{
			int nX = 0;
			string strText = "";
			Graphics gr = Graphics.FromHwnd(MinBulletWeightLabel.Handle);

			switch (m_Caliber.FirearmType)
				{
				//----------------------------------------------------------------------------*
				// Rifle and Handgun
				//----------------------------------------------------------------------------*

				case cFirearm.eFireArmType.Handgun:
				case cFirearm.eFireArmType.Rifle:
					//----------------------------------------------------------------------------*
					// Show the metallic fields
					//----------------------------------------------------------------------------*

					MinBulletDiameterLabel.Visible = true;
					MinBulletDiameterTextBox.Visible = true;
					MinBulletDiameterMeasurementLabel.Visible = true;

					MaxBulletDiameterLabel.Visible = true;
					MaxBulletDiameterTextBox.Visible = true;
					MaxBulletDiameterMeasurementLabel.Visible = true;

					MaxCOLLabel.Visible = true;
					MaxCOLTextBox.Visible = true;
					MaxCOLMeasurementLabel.Visible = true;

					//----------------------------------------------------------------------------*
					// MinBulletWeight
					//----------------------------------------------------------------------------*

					MinBulletWeightTextBox.ToolTip = cm_strMinBulletWeightToolTip;
					MaxBulletWeightTextBox.ToolTip = cm_strMaxBulletWeightToolTip;

					nX = MinBulletWeightLabel.Location.X + (int)gr.MeasureString(MinBulletWeightLabel.Text, MinBulletWeightLabel.Font).Width;

					strText = "Min Bullet Weight: ";

					nX -= (int)gr.MeasureString(strText, MinBulletWeightLabel.Font).Width;

					MinBulletWeightLabel.Text = strText;
					MinBulletWeightLabel.Location = new Point(nX, MinBulletWeightLabel.Location.Y);

					//----------------------------------------------------------------------------*
					// MaxBulletWeight
					//----------------------------------------------------------------------------*

					nX = MaxBulletWeightLabel.Location.X + (int)gr.MeasureString(MaxBulletWeightLabel.Text, MaxBulletWeightLabel.Font).Width;

					strText = "Max Bullet Weight: ";

					nX -= (int)gr.MeasureString(strText, MaxBulletWeightLabel.Font).Width;

					MaxBulletWeightLabel.Text = strText;
					MaxBulletWeightLabel.Location = new Point(nX, MaxBulletWeightLabel.Location.Y);

					//----------------------------------------------------------------------------*
					// Case Trim Length
					//----------------------------------------------------------------------------*

					nX = MinCaseLengthLabel.Location.X + (int)gr.MeasureString(MinCaseLengthLabel.Text, MinCaseLengthLabel.Font).Width;

					strText = "Case Trim Length: ";

					nX -= (int)gr.MeasureString(strText, MinCaseLengthLabel.Font).Width;

					MinCaseLengthLabel.Text = strText;
					MinCaseLengthLabel.Location = new Point(nX, MinCaseLengthLabel.Location.Y);

					//----------------------------------------------------------------------------*
					// MaxBulletWeight
					//----------------------------------------------------------------------------*

					nX = MaxCaseLengthLabel.Location.X + (int)gr.MeasureString(MaxCaseLengthLabel.Text, MaxCaseLengthLabel.Font).Width;

					strText = "Max Case Length: ";

					nX -= (int)gr.MeasureString(strText, MaxCaseLengthLabel.Font).Width;

					MaxCaseLengthLabel.Text = strText;
					MaxCaseLengthLabel.Location = new Point(nX, MaxCaseLengthLabel.Location.Y);

					break;

				//----------------------------------------------------------------------------*
				// Shotgun
				//----------------------------------------------------------------------------*

				case cFirearm.eFireArmType.Shotgun:
					//----------------------------------------------------------------------------*
					// Hide the metallic fields
					//----------------------------------------------------------------------------*

					MinBulletDiameterLabel.Visible = false;
					MinBulletDiameterTextBox.Visible = false;
					MinBulletDiameterMeasurementLabel.Visible = false;

					MaxBulletDiameterLabel.Visible = false;
					MaxBulletDiameterTextBox.Visible = false;
					MaxBulletDiameterMeasurementLabel.Visible = false;

					MaxCOLLabel.Visible = false;
					MaxCOLTextBox.Visible = false;
					MaxCOLMeasurementLabel.Visible = false;

					MinBulletWeightTextBox.ToolTip = cm_strMinShotWeightToolTip;
					MaxBulletWeightTextBox.ToolTip = cm_strMaxShotWeightToolTip;

					//----------------------------------------------------------------------------*
					// Min Bullet Weight
					//----------------------------------------------------------------------------*

					nX = MinBulletWeightLabel.Location.X + (int)gr.MeasureString(MinBulletWeightLabel.Text, MinBulletWeightLabel.Font).Width;

					strText = "Min Shot Weight: ";

					nX -= (int)gr.MeasureString(strText, MinBulletWeightLabel.Font).Width;

					MinBulletWeightLabel.Text = strText;
					MinBulletWeightLabel.Location = new Point(nX, MinBulletWeightLabel.Location.Y);

					cDataFiles.SetMetricLabel(MinBulletWeightMeasurementLabel, cDataFiles.eDataType.ShotWeight);
					cDataFiles.SetInputParameters(MinBulletWeightTextBox, cDataFiles.eDataType.ShotWeight);

					//----------------------------------------------------------------------------*
					// MaxBulletWeight
					//----------------------------------------------------------------------------*

					nX = MaxBulletWeightLabel.Location.X + (int)gr.MeasureString(MaxBulletWeightLabel.Text, MaxBulletWeightLabel.Font).Width;

					strText = "Max Shot Weight: ";

					nX -= (int)gr.MeasureString(strText, MaxBulletWeightLabel.Font).Width;

					MaxBulletWeightLabel.Text = strText;
					MaxBulletWeightLabel.Location = new Point(nX, MaxBulletWeightLabel.Location.Y);

					cDataFiles.SetMetricLabel(MaxBulletWeightMeasurementLabel, cDataFiles.eDataType.ShotWeight);
					cDataFiles.SetInputParameters(MaxBulletWeightTextBox, cDataFiles.eDataType.ShotWeight);

					//----------------------------------------------------------------------------*
					// Case Trim Length
					//----------------------------------------------------------------------------*

					nX = MinCaseLengthLabel.Location.X + (int)gr.MeasureString(MinCaseLengthLabel.Text, MinCaseLengthLabel.Font).Width;

					strText = "Min Shell Length: ";

					nX -= (int)gr.MeasureString(strText, MinCaseLengthLabel.Font).Width;

					MinCaseLengthLabel.Text = strText;
					MinCaseLengthLabel.Location = new Point(nX, MinCaseLengthLabel.Location.Y);

					//----------------------------------------------------------------------------*
					// Max Case Length
					//----------------------------------------------------------------------------*

					nX = MaxCaseLengthLabel.Location.X + (int)gr.MeasureString(MaxCaseLengthLabel.Text, MaxCaseLengthLabel.Font).Width;

					strText = "Max Shell Length: ";

					nX -= (int)gr.MeasureString(strText, MaxCaseLengthLabel.Font).Width;

					MaxCaseLengthLabel.Text = strText;
					MaxCaseLengthLabel.Location = new Point(nX, MaxCaseLengthLabel.Location.Y);

					break;
				}

			switch (m_Caliber.FirearmType)
				{
				case cFirearm.eFireArmType.Handgun:
				case cFirearm.eFireArmType.Rifle:
					MinBulletDiameterLabel.Enabled = true;
					MinBulletDiameterTextBox.Enabled = true;
					MinBulletDiameterMeasurementLabel.Enabled = true;

					MaxBulletDiameterLabel.Enabled = true;
					MaxBulletDiameterTextBox.Enabled = true;
					MaxBulletDiameterMeasurementLabel.Enabled = true;

					MinBulletWeightTextBox.MinValue = cBullet.MinBulletWeight;
					MinBulletWeightTextBox.MaxValue = cBullet.MaxBulletWeight;

					break;

				case cFirearm.eFireArmType.Shotgun:
					MinBulletDiameterLabel.Enabled = false;
					MinBulletDiameterTextBox.Enabled = false;
					MinBulletDiameterMeasurementLabel.Enabled = false;

					MaxBulletDiameterLabel.Enabled = false;
					MaxBulletDiameterTextBox.Enabled = false;
					MaxBulletDiameterMeasurementLabel.Enabled = false;

					MaxCOLLabel.Enabled = false;
					MaxCOLTextBox.Enabled = false;
					MaxCOLMeasurementLabel.Enabled = false;

					MinBulletWeightTextBox.MinValue = 0.1;
					MinBulletWeightTextBox.MaxValue = 10.0;

					break;
				}

			SetInputParameters();
			}

		//============================================================================*
		// OnCaseTrimLengthChanged()
		//============================================================================*

		private void OnCaseTrimLengthChanged(object sender, EventArgs e)
			{
			if (!m_fInitialized)
				return;

			if (MaxCOLTextBox.Value < CaseTrimLengthTextBox.Value)
				MaxCOLTextBox.Value = CaseTrimLengthTextBox.Value;

			if (m_Caliber.FirearmType != cFirearm.eFireArmType.Shotgun)
				{
				if (MaxCaseLengthTextBox.Value < CaseTrimLengthTextBox.Value + cDataFiles.StandardToMetric(0.005, cDataFiles.eDataType.Dimension))
					MaxCaseLengthTextBox.Value = CaseTrimLengthTextBox.Value + cDataFiles.StandardToMetric(0.005, cDataFiles.eDataType.Dimension);

				MaxCOLTextBox.MinValue = CaseTrimLengthTextBox.Value;
				MaxCOLTextBox.MaxValue = MaxCOLTextBox.MinValue + cDataFiles.StandardToMetric(1.5, cDataFiles.eDataType.Dimension);

				m_Caliber.MaxCOL = cDataFiles.MetricToStandard(MaxCOLTextBox.Value, cDataFiles.eDataType.Dimension);
				}
			else
				{
				if (MaxCaseLengthTextBox.Value < CaseTrimLengthTextBox.Value)
					MaxCaseLengthTextBox.Value = CaseTrimLengthTextBox.Value;

				MaxCOLTextBox.MinValue = 0.0;

				m_Caliber.MaxCOL = 0.0;
				}

			MaxCaseLengthTextBox.MinValue = CaseTrimLengthTextBox.Value;
			MaxCaseLengthTextBox.MaxValue = MaxCaseLengthTextBox.MinValue + cDataFiles.StandardToMetric(0.020, cDataFiles.eDataType.Dimension);

			m_Caliber.CaseTrimLength = cDataFiles.MetricToStandard(CaseTrimLengthTextBox.Value, cDataFiles.eDataType.Dimension);
			m_Caliber.MaxCaseLength = cDataFiles.MetricToStandard(MaxCaseLengthTextBox.Value, cDataFiles.eDataType.Dimension);

			m_fChanged = true;

			UpdateButtons();
			}

		//============================================================================*
		// OnFirearmTypeChanged()
		//============================================================================*

		private void OnFirearmTypeChanged(object sender, EventArgs e)
			{
			if (!m_fInitialized)
				return;

			if (m_Caliber.FirearmType == FirearmTypeCombo.Value)
				return;

			m_Caliber.FirearmType = FirearmTypeCombo.Value;

			if (FirearmTypeCombo.Value == cFirearm.eFireArmType.Handgun)
				{
				PistolRadioButton.Checked = m_Caliber.Pistol;
				RevolverRadioButton.Checked = !m_Caliber.Pistol;
				}

			if (m_Caliber.FirearmType == cFirearm.eFireArmType.Shotgun)
				{
				MaxNeckDiameterLabel.Visible = false;
				MaxNeckDiameterTextBox.Visible = false;
				MaxNeckDiameterMeasurementLabel.Visible = false;
				}
			else
				{
				MaxNeckDiameterLabel.Visible = true;
				MaxNeckDiameterTextBox.Visible = true;
				MaxNeckDiameterMeasurementLabel.Visible = true;
				}

			ConfigureFirearmType();

			m_fChanged = true;

			UpdateButtons();
			}

		//============================================================================*
		// OnHeadStampChanged()
		//============================================================================*

		private void OnHeadStampChanged(object sender, EventArgs e)
			{
			if (!m_fInitialized)
				return;

			m_Caliber.HeadStamp = HeadStampTextBox.Text;

			m_fChanged = true;

			UpdateButtons();
			}

		//============================================================================*
		// OnLargePrimerClicked()
		//============================================================================*

		private void OnLargePrimerClicked(object sender, EventArgs e)
			{
			if (!m_fInitialized)
				return;

			LargePrimerCheckBox.Checked = (LargePrimerCheckBox.Checked ? false : true);

			m_Caliber.LargePrimer = LargePrimerCheckBox.Checked;

			m_fChanged = true;

			UpdateButtons();
			}

		//============================================================================*
		// OnMagnumClicked()
		//============================================================================*

		private void OnMagnumClicked(object sender, EventArgs e)
			{
			if (!m_fInitialized)
				return;

			MagnumPrimerCheckBox.Checked = (MagnumPrimerCheckBox.Checked ? false : true);

			m_Caliber.MagnumPrimer = MagnumPrimerCheckBox.Checked;

			m_fChanged = true;

			UpdateButtons();
			}

		//============================================================================*
		// OnMaxBulletDiameterChanged()
		//============================================================================*

		private void OnMaxBulletDiameterChanged(object sender, EventArgs e)
			{
			if (!m_fInitialized)
				return;

			m_Caliber.MaxBulletDiameter = cDataFiles.MetricToStandard(MaxBulletDiameterTextBox.Value, cDataFiles.eDataType.Dimension);

			m_fChanged = true;

			UpdateButtons();
			}

		//============================================================================*
		// OnMaxBulletWeightChanged()
		//============================================================================*

		private void OnMaxBulletWeightChanged(object sender, EventArgs e)
			{
			if (!m_fInitialized)
				return;

			m_Caliber.MaxBulletWeight = cDataFiles.MetricToStandard(MaxBulletWeightTextBox.Value, cDataFiles.eDataType.BulletWeight);

			m_fChanged = true;

			UpdateButtons();
			}

		//============================================================================*
		// OnMaxCaseLengthChanged()
		//============================================================================*

		private void OnMaxCaseLengthChanged(object sender, EventArgs e)
			{
			if (!m_fInitialized)
				return;

			MaxCOLTextBox.MinValue = MaxCaseLengthTextBox.Value;

			m_Caliber.MaxCaseLength = cDataFiles.MetricToStandard(MaxCaseLengthTextBox.Value, cDataFiles.eDataType.Dimension);

			m_fChanged = true;

			UpdateButtons();
			}

		//============================================================================*
		// OnMaxCOLChanged()
		//============================================================================*

		private void OnMaxCOLChanged(object sender, EventArgs e)
			{
			if (!m_fInitialized)
				return;

			m_Caliber.MaxCOL = cDataFiles.MetricToStandard(MaxCOLTextBox.Value, cDataFiles.eDataType.Dimension);

			m_fChanged = true;

			UpdateButtons();
			}

		//============================================================================*
		// OnMaxNeckDiameterChanged()
		//============================================================================*

		private void OnMaxNeckDiameterChanged(object sender, EventArgs e)
			{
			if (!m_fInitialized)
				return;

			m_Caliber.MaxNeckDiameter = cDataFiles.MetricToStandard(MaxNeckDiameterTextBox.Value, cDataFiles.eDataType.Dimension);

			m_fChanged = true;

			UpdateButtons();
			}

		//============================================================================*
		// OnMinBulletDiameterChanged()
		//============================================================================*

		private void OnMinBulletDiameterChanged(object sender, EventArgs e)
			{
			if (!m_fInitialized)
				return;

			MaxBulletDiameterTextBox.MinValue = MinBulletDiameterTextBox.Value;

			m_Caliber.MinBulletDiameter = cDataFiles.MetricToStandard(MinBulletDiameterTextBox.Value, cDataFiles.eDataType.Dimension);

			m_fChanged = true;

			UpdateButtons();
			}

		//============================================================================*
		// OnMinBulletWeightChanged()
		//============================================================================*

		private void OnMinBulletWeightChanged(object sender, EventArgs e)
			{
			if (!m_fInitialized)
				return;

			MaxBulletWeightTextBox.MinValue = MinBulletWeightTextBox.Value;

			m_Caliber.MinBulletWeight = cDataFiles.MetricToStandard(MinBulletWeightTextBox.Value, cDataFiles.eDataType.BulletWeight);

			m_fChanged = true;

			UpdateButtons();
			}

		//============================================================================*
		// OnNameChanged()
		//============================================================================*

		private void OnNameChanged(object sender, EventArgs e)
			{
			if (!m_fInitialized)
				return;

			m_Caliber.Name = NameTextBox.Text;

			m_fChanged = true;


			UpdateButtons();
			}

		//============================================================================*
		// OnPistolClicked()
		//============================================================================*

		private void OnPistolClicked(object sender, EventArgs e)
			{
			if (!m_fInitialized)
				return;

			PistolRadioButton.Checked = ((PistolRadioButton.Checked) ? false : true);

			RevolverRadioButton.Checked = ((PistolRadioButton.Checked) ? false : true);

			m_Caliber.Pistol = PistolRadioButton.Checked;

			m_fChanged = true;

			UpdateButtons();
			}

		//============================================================================*
		// OnRevolverClicked()
		//============================================================================*

		private void OnRevolverClicked(object sender, EventArgs e)
			{
			if (!m_fInitialized)
				return;

			RevolverRadioButton.Checked = ((RevolverRadioButton.Checked) ? false : true);

			PistolRadioButton.Checked = ((RevolverRadioButton.Checked) ? false : true);

			m_Caliber.Pistol = PistolRadioButton.Checked;

			m_fChanged = true;

			UpdateButtons();
			}

		//============================================================================*
		// OnRimfireClicked()
		//============================================================================*

		private void OnRimfireClicked(object sender, EventArgs e)
			{
			if (!m_fInitialized)
				return;

			RimfireCheckBox.Checked = (RimfireCheckBox.Checked ? false : true);

			m_Caliber.Rimfire = RimfireCheckBox.Checked;

			if (m_Caliber.Rimfire)
				{
				m_Caliber.SmallPrimer = false;
				m_Caliber.LargePrimer = false;
				m_Caliber.MagnumPrimer = false;
				}

			m_fChanged = true;

			UpdateButtons();
			}

		//============================================================================*
		// OnSAAMIPDFChanged()
		//============================================================================*

		private void OnSAAMIPDFChanged(object sender, EventArgs e)
			{
			if (!m_fInitialized)
				return;

			m_Caliber.SAAMIPDF = SAAMIPDFTextBox.Value;

			m_fChanged = true;

			UpdateButtons();
			}

		//============================================================================*
		// OnSmallPrimerClicked()
		//============================================================================*

		private void OnSmallPrimerClicked(object sender, EventArgs e)
			{
			if (!m_fInitialized)
				return;

			SmallPrimerCheckBox.Checked = ((SmallPrimerCheckBox.Checked) ? false : true);

			m_Caliber.SmallPrimer = SmallPrimerCheckBox.Checked;

			m_fChanged = true;

			UpdateButtons();
			}

		//============================================================================*
		// OnTestSAAMIPDFClicked()
		//============================================================================*

		private void OnTestSAAMIPDFClicked(object sender, EventArgs e)
			{
			if (!m_fInitialized)
				return;

			cCaliber.ShowSAAMIPDF(m_DataFiles, m_Caliber);

			UpdateButtons();
			}

		//============================================================================*
		// PopulateCaliberData()
		//============================================================================*

		private void PopulateCaliberData()
			{
			FirearmTypeCombo.Value = m_Caliber.FirearmType;

			NameTextBox.Value = m_Caliber.Name;
			HeadStampTextBox.Value = m_Caliber.HeadStamp;

			SAAMIPDFTextBox.Value = m_Caliber.SAAMIPDF;

			PistolRadioButton.Checked = m_Caliber.Pistol;
			RevolverRadioButton.Checked = !m_Caliber.Pistol;

			SmallPrimerCheckBox.Checked = m_Caliber.SmallPrimer;
			LargePrimerCheckBox.Checked = m_Caliber.LargePrimer;
			MagnumPrimerCheckBox.Checked = m_Caliber.MagnumPrimer;
			RimfireCheckBox.Checked = m_Caliber.Rimfire;

			MinBulletDiameterTextBox.Value = cDataFiles.StandardToMetric(m_Caliber.MinBulletDiameter, cDataFiles.eDataType.Dimension);
			MaxBulletDiameterTextBox.Value = cDataFiles.StandardToMetric(m_Caliber.MaxBulletDiameter, cDataFiles.eDataType.Dimension);

			MinBulletWeightTextBox.Value = cDataFiles.StandardToMetric(m_Caliber.MinBulletWeight, cDataFiles.eDataType.BulletWeight);
			MaxBulletWeightTextBox.Value = cDataFiles.StandardToMetric(m_Caliber.MaxBulletWeight, cDataFiles.eDataType.BulletWeight);

			CaseTrimLengthTextBox.Value = cDataFiles.StandardToMetric(m_Caliber.CaseTrimLength, cDataFiles.eDataType.Dimension);
			MaxCaseLengthTextBox.Value = cDataFiles.StandardToMetric(m_Caliber.MaxCaseLength, cDataFiles.eDataType.Dimension);

			MaxNeckDiameterTextBox.Value = cDataFiles.StandardToMetric(m_Caliber.MaxNeckDiameter, cDataFiles.eDataType.Dimension);

			MaxCOLTextBox.Value = cDataFiles.StandardToMetric(m_Caliber.MaxCOL, cDataFiles.eDataType.Dimension);
			}

		//============================================================================*
		// SetInputParameters()
		//============================================================================*

		private void SetInputParameters()
			{
			//----------------------------------------------------------------------------*
			// Set metric/standard labels
			//----------------------------------------------------------------------------*

			cDataFiles.SetMetricLabel(MinBulletDiameterMeasurementLabel, cDataFiles.eDataType.Dimension);
			cDataFiles.SetMetricLabel(MaxBulletDiameterMeasurementLabel, cDataFiles.eDataType.Dimension);

			cDataFiles.SetMetricLabel(MinBulletWeightMeasurementLabel, m_Caliber.FirearmType == cFirearm.eFireArmType.Shotgun ? cDataFiles.eDataType.ShotWeight : cDataFiles.eDataType.BulletWeight);
			cDataFiles.SetMetricLabel(MaxBulletWeightMeasurementLabel, m_Caliber.FirearmType == cFirearm.eFireArmType.Shotgun ? cDataFiles.eDataType.ShotWeight : cDataFiles.eDataType.BulletWeight);

			cDataFiles.SetMetricLabel(MinCaseLengthMeasurementLabel, cDataFiles.eDataType.Dimension);
			cDataFiles.SetMetricLabel(MaxCaseLengthMeasurementLabel, cDataFiles.eDataType.Dimension);

			cDataFiles.SetMetricLabel(MaxCOLMeasurementLabel, cDataFiles.eDataType.Dimension);

			cDataFiles.SetMetricLabel(MaxNeckDiameterMeasurementLabel, cDataFiles.eDataType.Dimension);

			//----------------------------------------------------------------------------*
			// Set Text Box Parameters
			//----------------------------------------------------------------------------*

			cDataFiles.SetInputParameters(MinBulletDiameterTextBox, cDataFiles.eDataType.Dimension);
			cDataFiles.SetInputParameters(MaxBulletDiameterTextBox, cDataFiles.eDataType.Dimension);

			cDataFiles.SetInputParameters(MaxBulletWeightTextBox, m_Caliber.FirearmType == cFirearm.eFireArmType.Shotgun ? cDataFiles.eDataType.ShotWeight : cDataFiles.eDataType.BulletWeight);
			cDataFiles.SetInputParameters(MinBulletWeightTextBox, m_Caliber.FirearmType == cFirearm.eFireArmType.Shotgun ? cDataFiles.eDataType.ShotWeight : cDataFiles.eDataType.BulletWeight);

			cDataFiles.SetInputParameters(CaseTrimLengthTextBox, cDataFiles.eDataType.Dimension);
			cDataFiles.SetInputParameters(MaxCOLTextBox, cDataFiles.eDataType.Dimension);
			cDataFiles.SetInputParameters(MaxCaseLengthTextBox, cDataFiles.eDataType.Dimension);

			cDataFiles.SetInputParameters(MaxNeckDiameterTextBox, cDataFiles.eDataType.Dimension);
			}

		//============================================================================*
		// SetMinMax()
		//============================================================================*

		private void SetMinMax()
			{
			MinBulletDiameterTextBox.MinValue = cDataFiles.StandardToMetric(0.17, cDataFiles.eDataType.Dimension);
			MinBulletDiameterTextBox.MaxValue = cDataFiles.StandardToMetric(0.6, cDataFiles.eDataType.Dimension);

			MaxBulletDiameterTextBox.MinValue = MinBulletDiameterTextBox.Value;
			MaxBulletDiameterTextBox.MaxValue = cDataFiles.StandardToMetric(0.6, cDataFiles.eDataType.Dimension);

			MinBulletWeightTextBox.MinValue = cDataFiles.StandardToMetric(m_Caliber.FirearmType == cFirearm.eFireArmType.Shotgun ? 0.1 : cBullet.MinBulletWeight, m_Caliber.FirearmType == cFirearm.eFireArmType.Shotgun ? cDataFiles.eDataType.ShotWeight : cDataFiles.eDataType.BulletWeight);
			MinBulletWeightTextBox.MaxValue = cDataFiles.StandardToMetric(m_Caliber.FirearmType == cFirearm.eFireArmType.Shotgun ? 10.0 : cBullet.MaxBulletWeight, m_Caliber.FirearmType == cFirearm.eFireArmType.Shotgun ? cDataFiles.eDataType.ShotWeight : cDataFiles.eDataType.BulletWeight);

			MaxBulletWeightTextBox.MinValue = MinBulletWeightTextBox.Value;
			MaxBulletWeightTextBox.MaxValue = cDataFiles.StandardToMetric(m_Caliber.FirearmType == cFirearm.eFireArmType.Shotgun ? 10.0 : cBullet.MaxBulletWeight, m_Caliber.FirearmType == cFirearm.eFireArmType.Shotgun ? cDataFiles.eDataType.ShotWeight : cDataFiles.eDataType.BulletWeight);

			CaseTrimLengthTextBox.MinValue = cDataFiles.StandardToMetric(0.5, cDataFiles.eDataType.Dimension);
			CaseTrimLengthTextBox.MaxValue = MaxCaseLengthTextBox.Value;

			MaxCaseLengthTextBox.MinValue = CaseTrimLengthTextBox.Value;
			MaxCaseLengthTextBox.MaxValue = cDataFiles.StandardToMetric(4.0, cDataFiles.eDataType.Dimension);

			MaxCOLTextBox.MinValue = CaseTrimLengthTextBox.Value;
			MaxCOLTextBox.MaxValue = cDataFiles.StandardToMetric(6.0, cDataFiles.eDataType.Dimension);

			if (MaxNeckDiameterTextBox.Value != 0.0)
				MaxNeckDiameterTextBox.MinValue = MaxBulletDiameterTextBox.Value;
			else
				MaxNeckDiameterTextBox.MinValue = 0.0;

			MaxNeckDiameterTextBox.MaxValue = MaxBulletDiameterTextBox.Value + cDataFiles.StandardToMetric(0.050, cDataFiles.eDataType.Dimension);
			}

		//============================================================================*
		// SetStaticToolTips()
		//============================================================================*

		private void SetStaticToolTips()
			{
			OKButton.ShowToolTips = m_DataFiles.Preferences.ToolTips;
			FormCancelButton.ShowToolTips = m_DataFiles.Preferences.ToolTips;

			if (!m_DataFiles.Preferences.ToolTips)
				return;

			m_FirearmTypeToolTip.RemoveAll();
			m_FirearmTypeToolTip.SetToolTip(FirearmTypeCombo, cm_strFirearmTypeToolTip);

			NameTextBox.ToolTip = m_DataFiles.Preferences.ToolTips ? cm_strNameToolTip : "";
			HeadStampTextBox.ToolTip = m_DataFiles.Preferences.ToolTips ? cm_strHeadStampToolTip : "";

			m_PistolToolTip.ShowAlways = true;
			m_PistolToolTip.RemoveAll();
			m_PistolToolTip.SetToolTip(PistolRadioButton, cm_strPistolToolTip);

			m_RevolverToolTip.ShowAlways = true;
			m_RevolverToolTip.RemoveAll();
			m_RevolverToolTip.SetToolTip(RevolverRadioButton, cm_strRevolverToolTip);

			m_PrimerSizeToolTip.ShowAlways = true;
			m_PrimerSizeToolTip.RemoveAll();
			m_PrimerSizeToolTip.SetToolTip(SmallPrimerCheckBox, cm_strPrimerSizeToolTip);
			m_PrimerSizeToolTip.SetToolTip(LargePrimerCheckBox, cm_strPrimerSizeToolTip);

			m_MagnumToolTip.ShowAlways = true;
			m_MagnumToolTip.RemoveAll();
			m_MagnumToolTip.SetToolTip(MagnumPrimerCheckBox, cm_strMagnumToolTip);

			m_RimfireToolTip.ShowAlways = true;
			m_RimfireToolTip.RemoveAll();
			m_RimfireToolTip.SetToolTip(RimfireCheckBox, cm_strRimfireToolTip);

			MinBulletDiameterTextBox.ToolTip = cm_strMinBulletDiameterToolTip;
			MaxBulletDiameterTextBox.ToolTip = cm_strMaxBulletDiameterToolTip;
			MinBulletWeightTextBox.ToolTip = cm_strMinBulletWeightToolTip;
			MaxBulletWeightTextBox.ToolTip = cm_strMaxBulletWeightToolTip;
			CaseTrimLengthTextBox.ToolTip = cm_strCaseTrimLengthToolTip;
			MaxCaseLengthTextBox.ToolTip = cm_strMaxCaseLengthToolTip;
			MaxCOLTextBox.ToolTip = cm_strMaxCOLToolTip;
			MaxNeckDiameterTextBox.ToolTip = cm_strMaxNeckDiameterToolTip;

			SAAMIPDFTextBox.ToolTip = cm_strSAAMIPDFToolTip;
			}

		//============================================================================*
		// UpdateButtons()
		//============================================================================*

		private void UpdateButtons()
			{
			if (m_fViewOnly)
				return;

			SetMinMax();

			bool fEnableOK = m_fChanged;

			//----------------------------------------------------------------------------*
			// Check Name
			//----------------------------------------------------------------------------*

			string strToolTip = cm_strNameToolTip;

			if (NameTextBox.ValueOK)
				{
				//----------------------------------------------------------------------------*
				// Check for duplicate
				//----------------------------------------------------------------------------*

				if (FirearmTypeCombo.Value != m_Caliber.FirearmType ||
					NameTextBox.Value.ToUpper() != m_Caliber.Name.ToUpper())
					{
					foreach (cCaliber CheckCaliber in m_DataFiles.CaliberList)
						{
						if (FirearmTypeCombo.Value == CheckCaliber.FirearmType)
							{
							if (NameTextBox.Value.ToUpper() == CheckCaliber.Name.ToUpper())
								{
								fEnableOK = false;

								NameTextBox.BackColor = Color.LightPink;

								strToolTip += String.Format("\n\nThis caliber, \"{0}\" for ", NameTextBox.Text);

								switch (FirearmTypeCombo.Value)
									{
									case cFirearm.eFireArmType.Handgun:
										strToolTip += "handguns";
										break;

									case cFirearm.eFireArmType.Rifle:
										strToolTip += "rifles";
										break;

									case cFirearm.eFireArmType.Shotgun:
										strToolTip += "shotguns";
										break;
									}

								strToolTip += ", already exists.  Duplicate calibers are not allowed.";

								break;
								}
							}
						}
					}
				}

			//----------------------------------------------------------------------------*
			// Check HeadStamp
			//----------------------------------------------------------------------------*

			strToolTip = cm_strHeadStampToolTip;

			if (!HeadStampTextBox.ValueOK)
				fEnableOK = false;
			else
				{
				if (HeadStampTextBox.Value.Length > NameTextBox.Value.Length)
					{
					fEnableOK = false;

					HeadStampTextBox.BackColor = Color.LightPink;

					strToolTip += "\n\nThe headstamp (or abbreviated name) must have the same or fewer characters than the caliber's name.  That's kinda the point.";
					}
				else
					HeadStampTextBox.BackColor = SystemColors.Window;
				}

			if (m_DataFiles.Preferences.ToolTips)
				HeadStampTextBox.ToolTip = strToolTip;

			//----------------------------------------------------------------------------*
			// Check SAAMI PDF
			//----------------------------------------------------------------------------*

			if (SAAMIPDFTextBox.Value != null && SAAMIPDFTextBox.Value.Length > 0)
				{
				TestSAAMIPDFButton.Enabled = true;

				string strFilePath = m_DataFiles.GetDataPath() + "\\SAAMI";
				strFilePath = Path.Combine(strFilePath, m_Caliber.SAAMIPDF);
				strFilePath = Path.ChangeExtension(strFilePath, ".pdf");

				Bitmap TestBitmap = null;

				if (File.Exists(strFilePath))
					TestBitmap = (Bitmap)Properties.Resources.ResourceManager.GetObject("CheckMark");
				else
					{
					TestBitmap = (Bitmap)Properties.Resources.ResourceManager.GetObject("Reject");

					//					fEnableOK = false;
					}

				SAAMIOKImage.Image = TestBitmap;
				}
			else
				{
				TestSAAMIPDFButton.Enabled = false;

				SAAMIOKImage.Image = null;
				}

			//----------------------------------------------------------------------------*
			// Check Pistol/Revolver
			//----------------------------------------------------------------------------*

			strToolTip = "";

			if (FirearmTypeCombo.Value == cFirearm.eFireArmType.Handgun)
				{
				PistolRadioButton.Enabled = true;
				RevolverRadioButton.Enabled = true;

				if (!PistolRadioButton.Checked && !RevolverRadioButton.Checked)
					{
					fEnableOK = false;

					PistolRadioButton.BackColor = Color.LightPink;
					RevolverRadioButton.BackColor = Color.LightPink;

					strToolTip = "\n\nYou must select either pistol or revolver.";
					}
				else
					{
					PistolRadioButton.BackColor = SystemColors.Control;
					RevolverRadioButton.BackColor = SystemColors.Control;
					}
				}
			else
				{
				PistolRadioButton.Enabled = false;
				PistolRadioButton.Checked = false;
				PistolRadioButton.BackColor = SystemColors.Control;
				RevolverRadioButton.Enabled = false;
				RevolverRadioButton.Checked = false;
				RevolverRadioButton.BackColor = SystemColors.Control;
				}

			if (m_DataFiles.Preferences.ToolTips)
				{
				m_PistolToolTip.SetToolTip(PistolRadioButton, cm_strPistolToolTip + strToolTip);
				m_RevolverToolTip.SetToolTip(RevolverRadioButton, cm_strRevolverToolTip + strToolTip);
				}

			//----------------------------------------------------------------------------*
			// Check Small and Large primer sizes
			//----------------------------------------------------------------------------*

			strToolTip = cm_strPrimerSizeToolTip;

			if (m_Caliber.Rimfire)
				{
				SmallPrimerCheckBox.Checked = false;
				LargePrimerCheckBox.Checked = false;
				MagnumPrimerCheckBox.Checked = false;

				SmallPrimerCheckBox.Enabled = false;
				LargePrimerCheckBox.Enabled = false;
				MagnumPrimerCheckBox.Enabled = false;
				}
			else
				{
				SmallPrimerCheckBox.Enabled = true;
				LargePrimerCheckBox.Enabled = true;
				MagnumPrimerCheckBox.Enabled = true;
				}

			if (!SmallPrimerCheckBox.Checked && !LargePrimerCheckBox.Checked && !RimfireCheckBox.Checked)
				{
				fEnableOK = false;

				SmallPrimerCheckBox.BackColor = Color.LightPink;
				LargePrimerCheckBox.BackColor = Color.LightPink;
				RimfireCheckBox.BackColor = Color.LightPink;

				strToolTip += "\n\nYou must select either a small or large primer size, or Rimfire.";
				}
			else
				{
				SmallPrimerCheckBox.BackColor = SystemColors.Control;
				LargePrimerCheckBox.BackColor = SystemColors.Control;
				RimfireCheckBox.BackColor = SystemColors.Control;
				}

			if (m_DataFiles.Preferences.ToolTips)
				{
				m_PrimerSizeToolTip.SetToolTip(SmallPrimerCheckBox, strToolTip);
				m_PrimerSizeToolTip.SetToolTip(LargePrimerCheckBox, strToolTip);
				}

			//----------------------------------------------------------------------------*
			// Get Bullet Data if this caliber is used in any bullets
			//----------------------------------------------------------------------------*

			double dMinBulletWeight = 1000.0;
			double dMaxBulletWeight = 0.0;

			double dMinBulletDiameter = 1.0;
			double dMaxBulletDiameter = 0.0;

			int nBulletCount = 0;

			foreach (cBullet Bullet in m_DataFiles.BulletList)
				{
				foreach (cBulletCaliber BulletCaliber in Bullet.BulletCaliberList)
					{
					if (BulletCaliber.CompareTo(m_Caliber) == 0)
						{
						nBulletCount++;

						FirearmTypeCombo.Enabled = false;

						if (Bullet.Weight < dMinBulletWeight)
							dMinBulletWeight = Bullet.Weight;

						if (Bullet.Weight > dMaxBulletWeight)
							dMaxBulletWeight = Bullet.Weight;

						if (Bullet.Diameter < dMinBulletDiameter)
							dMinBulletDiameter = Bullet.Diameter;

						if (Bullet.Diameter > dMaxBulletDiameter)
							dMaxBulletDiameter = Bullet.Diameter;
						}
					}
				}

			//----------------------------------------------------------------------------*
			// Check Min Bullet Diameter
			//----------------------------------------------------------------------------*

			if (!MinBulletDiameterTextBox.ValueOK)
				fEnableOK = false;

			//----------------------------------------------------------------------------*
			// Check Max Bullet Diameter
			//----------------------------------------------------------------------------*

			if (!MaxBulletDiameterTextBox.ValueOK)
				fEnableOK = false;

			//----------------------------------------------------------------------------*
			// Check Min Bullet Weight
			//----------------------------------------------------------------------------*

			if (!MinBulletWeightTextBox.ValueOK)
				fEnableOK = false;

			//----------------------------------------------------------------------------*
			// Check Max Bullet Weight
			//----------------------------------------------------------------------------*

			if (!MaxBulletWeightTextBox.ValueOK)
				fEnableOK = false;

			//----------------------------------------------------------------------------*
			// Check Case Trim Length
			//----------------------------------------------------------------------------*

			if (!CaseTrimLengthTextBox.ValueOK)
				fEnableOK = false;

			//----------------------------------------------------------------------------*
			// Check Max Case Length
			//----------------------------------------------------------------------------*

			if (!MaxCaseLengthTextBox.ValueOK)
				fEnableOK = false;

			//----------------------------------------------------------------------------*
			// Check Max COL
			//----------------------------------------------------------------------------*

			if (!MaxCOLTextBox.ValueOK)
				fEnableOK = false;

			//----------------------------------------------------------------------------*
			// Set Caliber OK Button
			//----------------------------------------------------------------------------*

			OKButton.Enabled = fEnableOK;
			}
		}
	}
