//============================================================================*
// cBulletForm.cs
//
// Copyright © 2013-2014, Kevin S. Beebe
// All Rights Reserved
//============================================================================*

//============================================================================*
// .Net Using Statements
//============================================================================*

using System;
using System.Drawing;
using System.Windows;
using System.Windows.Forms;

using ReloadersWorkShop.Preferences;

//============================================================================*
// NameSpace
//============================================================================*

namespace ReloadersWorkShop
	{
	//============================================================================*
	// cFirearmCOLForm Class
	//============================================================================*

	public partial class cFirearmBulletForm : Form
		{
		//============================================================================*
		// Private Constant Data Members
		//============================================================================*

		private const string cm_strCOLToolTip = "The COAL to which cartridges using this bullet for this firearm should be set.";
		private const string cm_strCBTOToolTip = "The CBTO (Cartridge Base To Ogive) to which cartridges using this bullet for this firearm should be set.";

		//============================================================================*
		// Private Data Members
		//============================================================================*

		private bool m_fInitialized = false;
		private bool m_fChanged = false;

		private cFirearmBullet m_FirearmBullet = null;
		private cFirearm m_Firearm = null;
		private cCaliber m_Caliber = null;
		private cBullet m_Bullet;

		private Bitmap m_BulletBitmap = null;

		private cDataFiles m_DataFiles;

		private bool m_fAdd = true;

		//============================================================================*
		// cFirearmCOLForm() - Constructor
		//============================================================================*

		public cFirearmBulletForm(cFirearmBullet FirearmBullet, cFirearm Firearm, cCaliber Caliber, cDataFiles DataFiles)
			{
			InitializeComponent();

			m_Firearm = Firearm;
			m_Caliber = Caliber;
			m_DataFiles = DataFiles;

			string strTitle = "";

			if (FirearmBullet == null)
				{
				FirearmBulletOKButton.Text = "Add";

				strTitle = "Add";

				m_FirearmBullet = new cFirearmBullet();

				m_FirearmBullet.Caliber = m_Caliber;
				}
			else
				{
				m_FirearmBullet = new cFirearmBullet(FirearmBullet);

				FirearmBulletOKButton.Text = "Update";

				strTitle = "Update";

				m_fAdd = false;
				}

			SetClientSizeCore(BulletDataGroupBox.Location.X + BulletDataGroupBox.Width + 10, FirearmBulletCancelButton.Location.Y + FirearmBulletCancelButton.Height + 20);

			//----------------------------------------------------------------------------*
			// Set Title
			//----------------------------------------------------------------------------*

			strTitle += " Firearm Specific Bullet Data";

			Text = strTitle;

			//----------------------------------------------------------------------------*
			// Set Control Event Handlers
			//----------------------------------------------------------------------------*

			BulletCombo.SelectedIndexChanged += OnBulletSelected;

			COALTextBox.TextChanged += OnCOLChanged;

			CBTOTextBox.TextChanged += OnCBTOChanged;

			FirearmBulletOKButton.Click += OnOKClicked;

			//----------------------------------------------------------------------------*
			// Set Min/Max Values
			//----------------------------------------------------------------------------*

			COALTextBox.MinValue = m_DataFiles.StandardToMetric(m_Caliber.CaseTrimLength, cDataFiles.eDataType.Dimension);
			COALTextBox.MaxValue = m_DataFiles.StandardToMetric(m_Caliber.MaxCOL, cDataFiles.eDataType.Dimension);
			COALTextBox.NumDecimals = m_DataFiles.Preferences.DimensionDecimals;
			COALTextBox.ToolTip = cm_strCOLToolTip;

			CBTOTextBox.MinValue = m_DataFiles.StandardToMetric(m_Caliber.CaseTrimLength, cDataFiles.eDataType.Dimension);
			CBTOTextBox.MaxValue = m_DataFiles.StandardToMetric(m_Caliber.MaxCOL, cDataFiles.eDataType.Dimension);
			CBTOTextBox.NumDecimals = m_DataFiles.Preferences.DimensionDecimals;
			CBTOTextBox.ToolTip = cm_strCBTOToolTip;

			//----------------------------------------------------------------------------*
			// Populate Bullet Combo
			//----------------------------------------------------------------------------*

			BulletCombo.Items.Clear();

			if (m_fAdd)
				{
				foreach (cBullet CheckBullet in DataFiles.BulletList)
					{
					if ((!m_DataFiles.Preferences.HideUncheckedSupplies || CheckBullet.Checked) &&
						CheckBullet.HasCaliber(m_Caliber) &&
						m_Firearm.FirearmType == CheckBullet.FirearmType &&
						!m_Firearm.HasBullet(CheckBullet, m_Caliber))
						{
						BulletCombo.Items.Add(CheckBullet);
						}
					}
				}
			else
				BulletCombo.Items.Add(m_FirearmBullet.Bullet);

			if (BulletCombo.Items.Count > 0)
				BulletCombo.SelectedIndex = 0;

			//----------------------------------------------------------------------------*
			// Set measurement labels
			//----------------------------------------------------------------------------*

			COLMeasurementLabel.Text = m_DataFiles.MetricString(cDataFiles.eDataType.Dimension);
			CBTOMeasurementLabel.Text = m_DataFiles.MetricString(cDataFiles.eDataType.Dimension);

			//----------------------------------------------------------------------------*
			// Populate FirearmCOL Data
			//----------------------------------------------------------------------------*

			FirearmLabel.Text = m_Firearm.ToString() + " - " + m_Caliber.ToString();

			string strFormat = COALTextBox.FormatString + "{1}";

			MaxCOALLabel.Text = String.Format(strFormat, m_DataFiles.StandardToMetric(m_Caliber.MaxCOL, cDataFiles.eDataType.Dimension), m_DataFiles.MetricString(cDataFiles.eDataType.Dimension));

			COALTextBox.Value = m_DataFiles.StandardToMetric(m_FirearmBullet.COL, cDataFiles.eDataType.Dimension);

			CBTOTextBox.Value = m_Firearm.FirearmType == cFirearm.eFireArmType.Rifle ? m_DataFiles.StandardToMetric(m_FirearmBullet.CBTO, cDataFiles.eDataType.Dimension) : 0.0;

			CBTOTextBox.Enabled = m_Firearm.FirearmType == cFirearm.eFireArmType.Rifle;

			m_fInitialized = true;

			UpdateButtons();
			}

		//============================================================================*
		// FirearmBullet Property
		//============================================================================*

		public cFirearmBullet FirearmBullet
			{
			get { return (m_FirearmBullet); }
			}

		//============================================================================*
		// OnBulletSelected()
		//============================================================================*

		private void OnBulletSelected(object sender, EventArgs e)
			{
			if (!m_fInitialized)
				return;

			m_Bullet = (cBullet)BulletCombo.SelectedItem;

			SetBulletImage();

			m_fChanged = true;

			UpdateButtons();
			}

		//============================================================================*
		// OnCOLChanged()
		//============================================================================*

		private void OnCOLChanged(object sender, EventArgs e)
			{
			if (!m_fInitialized)
				return;

			m_FirearmBullet.COL = m_DataFiles.MetricToStandard(COALTextBox.Value, cDataFiles.eDataType.Dimension);

			if (m_FirearmBullet.COL != 0.0)
				CBTOTextBox.MinValue = 0.0;
			else
				CBTOTextBox.MinValue = m_DataFiles.StandardToMetric(m_Caliber.CaseTrimLength, cDataFiles.eDataType.Dimension);

			CBTOTextBox.MaxValue = COALTextBox.Value;

			SetBulletImage();

			m_fChanged = true;

			UpdateButtons();
			}

		//============================================================================*
		// OnCBTOChanged()
		//============================================================================*

		private void OnCBTOChanged(object sender, EventArgs e)
			{
			if (!m_fInitialized)
				return;

			m_FirearmBullet.CBTO = m_DataFiles.MetricToStandard(CBTOTextBox.Value, cDataFiles.eDataType.Dimension);

			COALTextBox.MinValue = m_DataFiles.StandardToMetric(m_Caliber.CaseTrimLength, cDataFiles.eDataType.Dimension) <= CBTOTextBox.Value ? CBTOTextBox.Value : m_DataFiles.StandardToMetric(m_Caliber.CaseTrimLength, cDataFiles.eDataType.Dimension);

			SetBulletImage();

			m_fChanged = true;

			UpdateButtons();
			}

		//============================================================================*
		// OnOKClicked()
		//============================================================================*

		private void OnOKClicked(object sender, EventArgs e)
			{
			m_FirearmBullet.Bullet = (cBullet)BulletCombo.SelectedItem;
			m_FirearmBullet.COL = m_DataFiles.MetricToStandard(COALTextBox.Value, cDataFiles.eDataType.Dimension);
			m_FirearmBullet.CBTO = m_Firearm.FirearmType == cFirearm.eFireArmType.Rifle ? m_DataFiles.MetricToStandard(CBTOTextBox.Value, cDataFiles.eDataType.Dimension) : 0.0;
			}

		//============================================================================*
		// SetBulletImage()
		//============================================================================*

		private void SetBulletImage()
			{
			try
				{
				string strFileName = String.Format(@"Images\{0} {1} Bullet.jpg", m_Bullet.Manufacturer.Name, m_Bullet.PartNumber);

				m_BulletBitmap = new Bitmap(strFileName);
				}
			catch
				{
				m_BulletBitmap = null;
				}

			BulletImage.Image = m_BulletBitmap;
			}

		//============================================================================*
		// UpdateButtons()
		//============================================================================*

		private void UpdateButtons()
			{
			bool fEnableOK = m_fChanged;

			//----------------------------------------------------------------------------*
			// Check COL
			//----------------------------------------------------------------------------*

			if (!COALTextBox.ValueOK)
				fEnableOK = false;

			//----------------------------------------------------------------------------*
			// Check CBTO
			//----------------------------------------------------------------------------*

			CBTOTextBox.Enabled = m_Firearm.FirearmType == cFirearm.eFireArmType.Rifle;

			if (CBTOTextBox.Enabled && CBTOTextBox.Value != 0.0 && CBTOTextBox.Value <= m_DataFiles.StandardToMetric(m_Caliber.CaseTrimLength, cDataFiles.eDataType.Dimension) + m_DataFiles.StandardToMetric(0.05, cDataFiles.eDataType.Dimension))
				fEnableOK = false;

			//----------------------------------------------------------------------------*
			// At least one of them must have a non-zero value
			//----------------------------------------------------------------------------*

			if (COALTextBox.Value == 0.0 && (CBTOTextBox.Enabled && CBTOTextBox.Value == 0.0))
				fEnableOK = false;

			FirearmBulletOKButton.Enabled = fEnableOK;
			}
		}
	}
