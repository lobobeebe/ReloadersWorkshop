//============================================================================*
// cBulletCaliberForm.cs
//
// Copyright © 2013-2017, Kevin S. Beebe
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
	// cBulletCaliberForm Class
	//============================================================================*

	public partial class cBulletCaliberForm : Form
		{
		//============================================================================*
		// Private constants
		//============================================================================*

		private const string cm_strCaliberToolTip = "Select a cartridge for which this bullet is usable.";
		private const string cm_strCOLToolTip = "The manufacturer's recommended Cartridge Overall Length for cartridges using this bullet.";
		private const string cm_strCBTOToolTip = "The length of cartridges using this bullet as measured from the case head to the ogive.";

		//============================================================================*
		// Private Data Members
		//============================================================================*

		private bool m_fInitialized = false;
		private cBullet m_Bullet;
		private cDataFiles m_DataFiles;
		private bool m_fAdd = false;

		cBulletCaliber m_BulletCaliber = null;

		private bool m_fChanged = false;

		private ToolTip m_CaliberToolTip = new ToolTip();

		//============================================================================*
		// cBulletCaliberForm() - Constructor
		//============================================================================*

		public cBulletCaliberForm(cBulletCaliber BulletCaliber, cBullet Bullet, cDataFiles DataFiles)
			{
			InitializeComponent();

			m_Bullet = Bullet;
			m_DataFiles = DataFiles;

			cCaliber.CurrentFirearmType = m_Bullet.FirearmType;

			//----------------------------------------------------------------------------*
			// Create the m_BulletCaliber object
			//----------------------------------------------------------------------------*

			if (BulletCaliber == null)
				{
				BulletCaliberOKButton.Text = "Add";

				m_fAdd = true;

				m_BulletCaliber = new cBulletCaliber();
				}
			else
				{
				m_BulletCaliber = new cBulletCaliber(BulletCaliber);

				BulletCaliberOKButton.Text = "Update";
				}

			SetClientSizeCore(SelectedCaliberLabel.Location.X + SelectedCaliberLabel.Width + 10, BulletCaliberCancelButton.Location.Y + BulletCaliberCancelButton.Height + 20);

			//----------------------------------------------------------------------------*
			// Set Control Event Handlers
			//----------------------------------------------------------------------------*

			CaliberCombo.SelectedIndexChanged += OnCaliberChanged;

			COALTextBox.TextChanged += OnCOLTextChanged;

			CBTOTextBox.TextChanged += OnCBTOTextChanged;

			BulletCaliberOKButton.Click += OnOKClicked;

			//----------------------------------------------------------------------------*
			// Fill in bullet caliber data
			//----------------------------------------------------------------------------*

			SetInputParameters();

			PopulateCaliberCombo();

			//----------------------------------------------------------------------------*
			// Set Static Tooltips
			//----------------------------------------------------------------------------*

			SetStaticToolTips();

			//----------------------------------------------------------------------------*
			// Set title and text fields
			//----------------------------------------------------------------------------*

			string strTitle;

			if (BulletCaliber == null)
				{
				strTitle = "Add";

				m_fChanged = true;
				}
			else
				{
				strTitle = "Edit";

				m_fChanged = false;
				}

			strTitle += " Cartridge Specific Data";

			Text = strTitle;

			m_fInitialized = true;

			UpdateButtons();
			}

		//============================================================================*
		// BulletCaliber Property
		//============================================================================*

		public cBulletCaliber BulletCaliber
			{
			get
				{
				return (m_BulletCaliber);
				}
			}

		//============================================================================*
		// OnCaliberChanged()
		//============================================================================*

		private void OnCaliberChanged(object sender, EventArgs e)
			{
			if (!m_fInitialized)
				return;

			cCaliber Caliber = (cCaliber) CaliberCombo.SelectedItem;

			if (m_BulletCaliber.CompareTo(Caliber) == 0)
				return;

			m_BulletCaliber.Caliber = Caliber;

			m_fChanged = true;

			if (Caliber != null)
				{
				if (m_DataFiles.Preferences.LastBulletCaliber != null && m_DataFiles.Preferences.LastBulletCaliber.CompareTo(Caliber) == 0)
					m_BulletCaliber.COL = m_DataFiles.Preferences.LastBulletCaliberCOL;
				else
					m_BulletCaliber.COL = Caliber.MaxCOL;

				m_BulletCaliber.CBTO = 0.0;

				COALTextBox.Value = cDataFiles.StandardToMetric(m_BulletCaliber.COL, cDataFiles.eDataType.Dimension);
				CBTOTextBox.Value = cDataFiles.StandardToMetric(m_BulletCaliber.CBTO, cDataFiles.eDataType.Dimension);

				SetMaxCOALLabel(Caliber);
				}

			UpdateButtons();
			}

		//============================================================================*
		// OnCOLTextChanged()
		//============================================================================*

		private void OnCOLTextChanged(object sender, EventArgs e)
			{
			if (!m_fInitialized)
				return;

			m_BulletCaliber.COL = cDataFiles.StandardToMetric(COALTextBox.Value, cDataFiles.eDataType.Dimension);

			m_fChanged = true;

			UpdateButtons();
			}

		//============================================================================*
		// OnCBTOTextChanged()
		//============================================================================*

		private void OnCBTOTextChanged(object sender, EventArgs e)
			{
			if (!m_fInitialized)
				return;

			m_BulletCaliber.CBTO = cDataFiles.StandardToMetric(CBTOTextBox.Value, cDataFiles.eDataType.Dimension);

			m_fChanged = true;

			UpdateButtons();
			}

		//============================================================================*
		// OnOKClicked()
		//============================================================================*

		private void OnOKClicked(object sender, EventArgs e)
			{
			m_BulletCaliber.Caliber = (cCaliber) CaliberCombo.SelectedItem;
			m_BulletCaliber.COL = cDataFiles.MetricToStandard(COALTextBox.Value, cDataFiles.eDataType.Dimension);
			m_BulletCaliber.CBTO = cDataFiles.MetricToStandard(CBTOTextBox.Value, cDataFiles.eDataType.Dimension);

			m_DataFiles.Preferences.LastBulletCaliber = m_BulletCaliber.Caliber;
			m_DataFiles.Preferences.LastBulletCaliberCOL = m_BulletCaliber.COL;
			}

		//============================================================================*
		// PopulateBulletCaliberData()
		//============================================================================*

		private void PopulateBulletCaliberData()
			{
			BulletLabel.Text = m_Bullet.ToString();

			cCaliber Caliber = null;

			double dCOL = 0.0;

			if (CaliberCombo.SelectedItem != null)
				Caliber = (cCaliber) CaliberCombo.SelectedItem;

			if (Caliber == null || (Caliber.CompareTo(m_DataFiles.Preferences.LastBulletCaliber) == 0 && m_DataFiles.Preferences.LastBulletCaliberCOL != 0.0))
				dCOL = m_DataFiles.Preferences.LastBulletCaliberCOL;
			else
				dCOL = Caliber.MaxCOL;

			if (m_BulletCaliber.COL == 0.0)
				m_BulletCaliber.COL = dCOL;

			COALTextBox.Value = cDataFiles.StandardToMetric(m_BulletCaliber.COL, cDataFiles.eDataType.Dimension);
			CBTOTextBox.Value = cDataFiles.StandardToMetric(m_BulletCaliber.CBTO, cDataFiles.eDataType.Dimension);

			SetMaxCOALLabel(Caliber);
			}

		//============================================================================*
		// PopulateCaliberCombo()
		//============================================================================*

		private void PopulateCaliberCombo()
			{
			cCaliber.CurrentFirearmType = m_Bullet.FirearmType;

			if (!m_fAdd)
				{
				CaliberCombo.Items.Add(m_BulletCaliber.Caliber);

				CaliberCombo.SelectedIndex = 0;

				PopulateBulletCaliberData();

				return;
				}

			foreach (cCaliber CheckCaliber in m_DataFiles.CaliberList)
				{
				if ((Math.Round(CheckCaliber.MinBulletDiameter, 3) <= Math.Round(m_Bullet.Diameter,  3) && Math.Round(CheckCaliber.MaxBulletDiameter, 3) >= Math.Round(m_Bullet.Diameter, 3)) &&
					(Math.Round(CheckCaliber.MinBulletWeight, 3) <= Math.Round(m_Bullet.Weight, 3) && Math.Round(CheckCaliber.MaxBulletWeight, 3) >= Math.Round(m_Bullet.Weight, 3)) &&
					(m_Bullet.CrossUse || CheckCaliber.FirearmType == m_Bullet.FirearmType) && !CheckCaliber.Rimfire)
					{
					bool fAlreadyAdded = false;

					foreach (cBulletCaliber BulletCaliber in m_Bullet.BulletCaliberList)
						{
						if (BulletCaliber.Caliber.CompareTo(CheckCaliber) == 0)
							{
							fAlreadyAdded = true;

							break;
							}
						}

					if (!fAlreadyAdded)
						CaliberCombo.Items.Add(CheckCaliber);
					}
				}

			if (CaliberCombo.Items.Count > 0)
				{
				CaliberCombo.SelectedItem = m_BulletCaliber;

				if (CaliberCombo.SelectedIndex < 0)
					{
					if (m_DataFiles.Preferences.LastBulletCaliber != null)
						{
						CaliberCombo.SelectedItem = m_DataFiles.Preferences.LastBulletCaliber;

						COALTextBox.Value = m_DataFiles.Preferences.LastBulletCaliberCOL;
						}

					if (CaliberCombo.SelectedIndex == -1)
						CaliberCombo.SelectedIndex = 0;
					}
				}

			PopulateBulletCaliberData();
			}

		//============================================================================*
		// SetInputParameters()
		//============================================================================*

		private void SetInputParameters()
			{
			//----------------------------------------------------------------------------*
			// Set metric/standard labels
			//----------------------------------------------------------------------------*

			cDataFiles.SetMetricLabel(COALMeasurementLabel, cDataFiles.eDataType.Dimension);
			cDataFiles.SetMetricLabel(CBTOMeasurementLabel, cDataFiles.eDataType.Dimension);

			//----------------------------------------------------------------------------*
			// Set Text Box Parameters
			//----------------------------------------------------------------------------*

			cDataFiles.SetInputParameters(COALTextBox, cDataFiles.eDataType.Dimension);
			cDataFiles.SetInputParameters(CBTOTextBox, cDataFiles.eDataType.Dimension);
			}

		//============================================================================*
		// SetMinMax()
		//============================================================================*

		private void SetMaxCOALLabel(cCaliber Caliber)
			{
			string strFormat = "{0:F";
			strFormat += String.Format("{0:G0}", m_DataFiles.Preferences.DimensionDecimals);
			strFormat += "}";

			MaxCOLLabel.Text = String.Format(strFormat, (Caliber != null) ? cDataFiles.StandardToMetric(Caliber.MaxCOL, cDataFiles.eDataType.Dimension) : 0.0);
			}

		//============================================================================*
		// SetMinMax()
		//============================================================================*

		private void SetMinMax()
			{
			cCaliber Caliber = (cCaliber) CaliberCombo.SelectedItem;

			if (Caliber != null)
				{
				COALTextBox.MinValue = cDataFiles.StandardToMetric(Caliber.CaseTrimLength, cDataFiles.eDataType.Dimension);
				COALTextBox.MaxValue = cDataFiles.StandardToMetric(Caliber.MaxCOL, cDataFiles.eDataType.Dimension);

				if (CBTOTextBox.Value > 0.0)
					CBTOTextBox.MinValue = cDataFiles.StandardToMetric(Caliber.CaseTrimLength, cDataFiles.eDataType.Dimension) + cDataFiles.StandardToMetric(0.001, cDataFiles.eDataType.Dimension);
				else
					CBTOTextBox.MinValue = 0.0;

				CBTOTextBox.MaxValue = COALTextBox.MaxValue - 0.001;
				}
			}

		//============================================================================*
		// SetStaticToolTips()
		//============================================================================*

		private void SetStaticToolTips()
			{
			if (!m_DataFiles.Preferences.ToolTips)
				return;

			m_CaliberToolTip.ShowAlways = true;
			m_CaliberToolTip.RemoveAll();
			m_CaliberToolTip.SetToolTip(CaliberCombo, cm_strCaliberToolTip);

			COALTextBox.ToolTip = cm_strCOLToolTip;
			CBTOTextBox.ToolTip = cm_strCBTOToolTip;
			}

		//============================================================================*
		// UpdateButtons()
		//============================================================================*

		private void UpdateButtons()
			{
			bool fEnableOK = m_fChanged;

			SetMinMax();

			//----------------------------------------------------------------------------*
			// Check Caliber
			//----------------------------------------------------------------------------*

			if (CaliberCombo.SelectedIndex < 0)
				fEnableOK = false;

			if (fEnableOK && CaliberCombo.SelectedItem != null && COALTextBox.Text.Length > 0)
				{
				//----------------------------------------------------------------------------*
				// Check COL
				//----------------------------------------------------------------------------*

				if (!COALTextBox.ValueOK)
					fEnableOK = false;

				//----------------------------------------------------------------------------*
				// Check CBTO
				//----------------------------------------------------------------------------*

				if (!CBTOTextBox.ValueOK)
					fEnableOK = false;
				}

			BulletCaliberOKButton.Enabled = fEnableOK;
			}
		}
	}
