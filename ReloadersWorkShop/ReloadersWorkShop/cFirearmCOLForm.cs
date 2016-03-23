//============================================================================*
// cBulletForm.cs
//
// Copyright © 2013, Lobo Specialties LLC
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

	public partial class cFirearmCOLForm : Form
		{
		//----------------------------------------------------------------------------*
		// Private Data Members
		//----------------------------------------------------------------------------*

		private cFirearmCOL m_FirearmCOL = null;
		private cFirearm m_Firearm = null;
		private cBullet m_Bullet;
		private cBulletList m_BulletList;

		private Bitmap m_BulletBitmap = null;
		private cPreferences m_Preferences;

		//============================================================================*
		// cFirearmCOLForm() - Constructor
		//============================================================================*

		public cFirearmCOLForm(cFirearmCOL FirearmCOL, cFirearm Firearm, cBulletList BulletList, cPreferences Preferences)
			{
			InitializeComponent();

			m_Firearm = Firearm;
			m_BulletList = BulletList;
			m_Preferences = Preferences;

			if (FirearmCOL == null)
				{
				FirearmCOLOKButton.Text = "Add";

				if (m_Preferences.LastFirearmCOL == null)
					m_FirearmCOL = new cFirearmCOL();
				else
					{
					m_FirearmCOL = new cFirearmCOL(m_Preferences.LastFirearmCOL);

					m_FirearmCOL.COL = 0.0;
					m_FirearmCOL.OgiveOAL = 0.0;
					}
				}
			else
				{
				m_FirearmCOL = new cFirearmCOL(FirearmCOL);

				FirearmCOLOKButton.Text = "Update";
				}

			//----------------------------------------------------------------------------*
			// Set Control Event Handlers
			//----------------------------------------------------------------------------*

			BulletCombo.SelectedIndexChanged += OnBulletSelected;

			COLTextBox.TextChanged += OnDoubleValueTextChanged;
			COLTextBox.KeyPress += cControls.OnDoubleValueKeyPress;
			COLTextBox.LostFocus += cControls.OnDoubleValue3LostFocus;
			COLTextBox.GotFocus += cControls.OnTextBoxGotFocus;

			OgiveOALTextBox.TextChanged += OnDoubleValueTextChanged;
			OgiveOALTextBox.KeyPress += cControls.OnDoubleValueKeyPress;
			OgiveOALTextBox.LostFocus += cControls.OnDoubleValue3LostFocus;
			OgiveOALTextBox.GotFocus += cControls.OnTextBoxGotFocus;

			FirearmCOLOKButton.Click += OnOKClicked;

			//----------------------------------------------------------------------------*
			// Populate bullet Combo
			//----------------------------------------------------------------------------*

			cControls.PopulateBulletCombo(BulletCombo, m_BulletList, m_Preferences, null, m_Firearm.Caliber, (int)m_Firearm.FirearmType);

			//----------------------------------------------------------------------------*
			// Populate FirearmCOL Data
			//----------------------------------------------------------------------------*

			FirearmLabel.Text = m_Firearm.ToString();

			MaxCOLTextBox.Text = String.Format("{0:F3}", m_Firearm.Caliber.MaxCOL);

			COLTextBox.Text = String.Format("{0:F3}", m_FirearmCOL.COL);
			OgiveOALTextBox.Text = String.Format("{0:F3}", m_FirearmCOL.OgiveOAL);
			}

		//============================================================================*
		// FirearmCOL Property
		//============================================================================*

		public cFirearmCOL FirearmCOL
			{
			get { return (m_FirearmCOL); }
			}

		//============================================================================*
		// OnBulletSelected()
		//============================================================================*

		private void OnBulletSelected(object sender, EventArgs e)
			{
			m_Bullet = (cBullet) BulletCombo.SelectedItem;

			SetBulletImage();

			UpdateButtons();
			}

		//============================================================================*
		// OnDoubleValueTextChanged()
		//============================================================================*

		private void OnDoubleValueTextChanged(object sender, EventArgs e)
			{
			cControls.OnDoubleValueTextChanged(sender, e);

			UpdateButtons();
			}

		//============================================================================*
		// OnOKClicked()
		//============================================================================*

		private void OnOKClicked(object sender, EventArgs e)
			{
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
			bool fEnableOK = true;

			if (fEnableOK &&
				BulletCombo.SelectedItem != null &&
				COLTextBox.Text.Length > 0 &&
				OgiveOALTextBox.Text.Length > 0)
				{
				try
					{
					//----------------------------------------------------------------------------*
					// Check COL
					//----------------------------------------------------------------------------*

					double dCOL = Double.Parse(COLTextBox.Text);

					if (dCOL <= m_Firearm.Caliber.CaseTrimLength)
						fEnableOK = false;

					//----------------------------------------------------------------------------*
					// Check Ogive OAL
					//----------------------------------------------------------------------------*

					double dOgiveOAL = Double.Parse(OgiveOALTextBox.Text);

					if (dOgiveOAL < 0.0)
						fEnableOK = false;
					}
				catch
					{
					fEnableOK = false;
					}

				}
			else
				fEnableOK = false;

			FirearmCOLOKButton.Enabled = fEnableOK;
			}
		}
	}
