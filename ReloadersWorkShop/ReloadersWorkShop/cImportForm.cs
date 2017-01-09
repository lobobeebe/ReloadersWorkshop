//============================================================================*
// cImportForm.cs
//
// Copyright © 2013-2017, Kevin S. Beebe
// All Rights Reserved
//============================================================================*

//============================================================================*
// .Net Using Statements
//============================================================================*

using System;
using System.IO;
using System.Windows.Forms;

//============================================================================*
// Namespace
//============================================================================*

namespace ReloadersWorkShop
	{
	//============================================================================*
	// cImportForm Class
	//============================================================================*

	public partial class cImportForm : Form
		{
		//============================================================================*
		// Private Data Members
		//============================================================================*

		private cRWXMLDocument m_XMLDocument = null;

		//============================================================================*
		// cImportForm() - Constructor
		//============================================================================*

		public cImportForm(cRWXMLDocument XMLDocument)
			{
			InitializeComponent();

			m_XMLDocument = XMLDocument;

			SetClientSizeCore(FileNameLabel.Location.X + FileNameLabel.Width + 10, FormCancelButton.Location.Y + FormCancelButton.Height + 20);

			DifferencesOnlyCheckBox.Click += OnOptionClicked;
			ImportAllCheckBox.Click += OnOptionClicked;
			ResetAllDataCheckBox.Click += OnOptionClicked;

			PopulateDataFileContents();

			UpdateButtons();
			}

		//============================================================================*
		// OnOptionClicked()
		//============================================================================*

		private void OnOptionClicked(Object sender, EventArgs args)
			{
			PopulateDataFileContents();

			UpdateButtons();
			}

		//============================================================================*
		// PopulateDataFileContents()
		//============================================================================*

		private void PopulateDataFileContents()
			{
			if (m_XMLDocument.ContainsPreferences)
				{
				ResetAllDataCheckBox.Enabled = true;
				}
			else
				{
				ResetAllDataCheckBox.Enabled = false;
				ResetAllDataCheckBox.Checked = false;
				}

			FileNameLabel.Text = Path.GetFileName(m_XMLDocument.FilePath);
			FileContentsLabel.Text = "(" + m_XMLDocument.FileDescription + ")";

			SetContentLabel(AmmoCountCheckBox, "Ammo Record", m_XMLDocument.AmmoCount, m_XMLDocument.AmmoNewCount, m_XMLDocument.AmmoUpdateCount);
			SetContentLabel(AmmoTestCountCheckBox, "Ammo Test", m_XMLDocument.AmmoTestCount, m_XMLDocument.AmmoTestNewCount, m_XMLDocument.AmmoTestUpdateCount);

			SetContentLabel(CaliberCountCheckBox, "Caliber", m_XMLDocument.CaliberCount, m_XMLDocument.CaliberNewCount, m_XMLDocument.CaliberUpdateCount);

			SetContentLabel(ManufacturerCountCheckBox, "Manufacturer", m_XMLDocument.ManufacturerCount, m_XMLDocument.ManufacturerNewCount, m_XMLDocument.ManufacturerUpdateCount);

			SetContentLabel(BulletCountCheckBox, "Bullet", m_XMLDocument.BulletCount, m_XMLDocument.BulletNewCount, m_XMLDocument.BulletUpdateCount);
			SetContentLabel(BulletCaliberCountCheckBox, "Bullet Caliber", m_XMLDocument.BulletCaliberCount, m_XMLDocument.BulletCaliberNewCount, m_XMLDocument.BulletCaliberUpdateCount);
			SetContentLabel(CaseCountCheckBox, "Case", m_XMLDocument.CaseCount, m_XMLDocument.CaseNewCount, m_XMLDocument.CaseUpdateCount);
			SetContentLabel(PowderCountCheckBox, "Powder", m_XMLDocument.PowderCount, m_XMLDocument.PowderNewCount, m_XMLDocument.PowderUpdateCount);
			SetContentLabel(PrimerCountCheckBox, "Primer", m_XMLDocument.PrimerCount, m_XMLDocument.PrimerNewCount, m_XMLDocument.PrimerUpdateCount);

			SetContentLabel(FirearmCountCheckBox, "Firearm", m_XMLDocument.FirearmCount, m_XMLDocument.FirearmNewCount, m_XMLDocument.FirearmUpdateCount);
			SetContentLabel(FirearmCaliberCountCheckBox, "Firearm Caliber", m_XMLDocument.FirearmCaliberCount, m_XMLDocument.FirearmCaliberNewCount, m_XMLDocument.FirearmCaliberUpdateCount);
			SetContentLabel(FirearmBulletCountCheckBox, "Firearm Bullet", m_XMLDocument.FirearmBulletCount, m_XMLDocument.FirearmBulletNewCount, m_XMLDocument.FirearmBulletUpdateCount);

			SetContentLabel(AccessoryCountCheckBox, "Firearm Accessory", m_XMLDocument.AccessoryCount, m_XMLDocument.AccessoryNewCount, m_XMLDocument.AccessoryUpdateCount);
			}

		//============================================================================*
		// SetContentLabel()
		//============================================================================*

		private void SetContentLabel(CheckBox CountCheckBox, string strData, int nCount, int nNewCount, int nUpdateCount)
			{
			string strDataType = strData;

			if (nNewCount != 1)
				{
				if (strDataType[strDataType.Length - 1] == 'y')
					strDataType = strDataType.Substring(0, strDataType.Length - 1) + "ies";
				else
					strDataType += "s";
				}

			string strText = String.Format("{0} new {1}", (nNewCount > 0 ? String.Format("{0:N0}", nNewCount) : "No"), strDataType);

			if (!DifferencesOnlyCheckBox.Checked)
				{
				if (nCount > 0)
					strText += String.Format(" (out of {0:N0})", nCount);
				else
					strText += " (None in File)";
				}

			if (nUpdateCount > 0)
				{
				if (nNewCount > 0)
					strText += " with";
				else
					strText += " but there are";

				strDataType = strData;

				if (nUpdateCount != 1)
					{
					if (strDataType[strDataType.Length - 1] == 'y')
						strDataType = strDataType.Substring(0, strDataType.Length - 1) + "ies";
					else
						strDataType += "s";
					}

				strText += String.Format(" {0:N0} update{1} to {2}existing {3}.", nUpdateCount, nUpdateCount != 1 ? "s" : "", nUpdateCount == 1 ? "an " : "", strDataType);
				}

			CountCheckBox.Text = strText;

			CountCheckBox.Enabled = (nNewCount != 0 || nUpdateCount != 0) && (!ResetAllDataCheckBox.Checked && !ImportAllCheckBox.Checked);

			if (ResetAllDataCheckBox.Checked || ImportAllCheckBox.Checked)
				CountCheckBox.Checked = nNewCount != 0 || nUpdateCount != 0;

			if (nNewCount == 0 && nUpdateCount == 0)
				{
				CountCheckBox.Checked = false;
				}
			}

		//============================================================================*
		// UpdateButtons()
		//============================================================================*

		private void UpdateButtons()
			{
			bool fEnableOK = true;

			//----------------------------------------------------------------------------*
			// Ammo Group
			//----------------------------------------------------------------------------*

			if (ResetAllDataCheckBox.Checked || ImportAllCheckBox.Checked)
				{
				AmmoCountCheckBox.Checked = m_XMLDocument.AmmoUpdateCount > 0 || m_XMLDocument.AmmoNewCount > 0;
				AmmoCountCheckBox.Enabled = false;
				AmmoTestCountCheckBox.Checked = m_XMLDocument.AmmoTestUpdateCount > 0 || m_XMLDocument.AmmoTestNewCount > 0;
				AmmoTestCountCheckBox.Enabled = false;
				}
			else
				{
				AmmoCountCheckBox.Enabled = m_XMLDocument.AmmoUpdateCount > 0 || m_XMLDocument.AmmoNewCount > 0;
				AmmoTestCountCheckBox.Enabled = m_XMLDocument.AmmoTestUpdateCount > 0 || m_XMLDocument.AmmoTestNewCount > 0;
				}

			//----------------------------------------------------------------------------*
			// Firearms Group
			//----------------------------------------------------------------------------*

			if (ResetAllDataCheckBox.Checked || ImportAllCheckBox.Checked)
				{
				FirearmCountCheckBox.Checked = m_XMLDocument.FirearmUpdateCount > 0 || m_XMLDocument.FirearmNewCount > 0;
				FirearmCountCheckBox.Enabled = false;
				FirearmCaliberCountCheckBox.Checked = m_XMLDocument.FirearmCaliberUpdateCount > 0 || m_XMLDocument.FirearmCaliberNewCount > 0;
				FirearmCaliberCountCheckBox.Enabled = false;
				FirearmBulletCountCheckBox.Checked = m_XMLDocument.FirearmBulletUpdateCount > 0 || m_XMLDocument.FirearmBulletNewCount > 0;
				FirearmBulletCountCheckBox.Enabled = false;
				}
			else
				{
				FirearmCountCheckBox.Enabled = m_XMLDocument.FirearmCount != 0 || m_XMLDocument.FirearmUpdateCount != 0;
				FirearmCaliberCountCheckBox.Enabled = m_XMLDocument.FirearmCaliberCount != 0 || m_XMLDocument.FirearmCaliberUpdateCount != 0;
				FirearmBulletCountCheckBox.Enabled = m_XMLDocument.FirearmBulletCount != 0 || m_XMLDocument.FirearmBulletUpdateCount != 0;
				}

			//----------------------------------------------------------------------------*
			// Reloading Components Group
			//----------------------------------------------------------------------------*

			if (ResetAllDataCheckBox.Checked || ImportAllCheckBox.Checked)
				{
				BulletCountCheckBox.Checked = m_XMLDocument.BulletUpdateCount > 0 || m_XMLDocument.BulletNewCount > 0;
				BulletCountCheckBox.Enabled = false;
				BulletCaliberCountCheckBox.Checked = m_XMLDocument.BulletCaliberUpdateCount > 0 || m_XMLDocument.BulletCaliberNewCount > 0;
				BulletCaliberCountCheckBox.Enabled = false;
				CaseCountCheckBox.Checked = m_XMLDocument.CaseUpdateCount > 0 || m_XMLDocument.CaseNewCount > 0;
				CaseCountCheckBox.Enabled = false;
				PowderCountCheckBox.Checked = m_XMLDocument.PowderUpdateCount > 0 || m_XMLDocument.PowderNewCount > 0;
				PowderCountCheckBox.Enabled = false;
				PrimerCountCheckBox.Checked = m_XMLDocument.PrimerUpdateCount > 0 || m_XMLDocument.PrimerNewCount > 0;
				PrimerCountCheckBox.Enabled = false;
				}
			else
				{
				BulletCountCheckBox.Enabled = m_XMLDocument.BulletCount != 0 || m_XMLDocument.BulletUpdateCount != 0;
				BulletCaliberCountCheckBox.Enabled = m_XMLDocument.BulletCaliberCount != 0 || m_XMLDocument.BulletCaliberUpdateCount != 0;
				CaseCountCheckBox.Enabled = m_XMLDocument.CaseCount != 0 || m_XMLDocument.CaseUpdateCount != 0;
				PowderCountCheckBox.Enabled = m_XMLDocument.PowderCount != 0 || m_XMLDocument.PowderUpdateCount != 0;
				PrimerCountCheckBox.Enabled = m_XMLDocument.PrimerCount != 0 || m_XMLDocument.PrimerUpdateCount != 0;
				}

			//----------------------------------------------------------------------------*
			// Preferences Group
			//----------------------------------------------------------------------------*

			if (m_XMLDocument.ContainsPreferences)
				{
				PreferencesWarningLabel.Text = "Warning! This Data File Contains Preferences Options";
				PreferencesWarningLabel.ForeColor = System.Drawing.Color.Red;

				ResetPreferencesCheckBox.Enabled = true;

				if (ResetAllDataCheckBox.Checked)
					{
					UpdatePreferencesCheckBox.Enabled = false;
					UpdatePreferencesCheckBox.Checked = false;

					ResetPreferencesCheckBox.Enabled = false;
					ResetPreferencesCheckBox.Checked = true;

					ImportAllCheckBox.Enabled = false;
					ImportAllCheckBox.Checked = false;
					}
				else
					{
					if (ImportAllCheckBox.Checked)
						{
						UpdatePreferencesCheckBox.Enabled = false;
						UpdatePreferencesCheckBox.Checked = true;

						ResetPreferencesCheckBox.Enabled = false;
						ResetPreferencesCheckBox.Checked = false;
						}
					else
						{
						UpdatePreferencesCheckBox.Enabled = m_XMLDocument.ContainsPreferences;
						ResetPreferencesCheckBox.Enabled = m_XMLDocument.ContainsPreferences;
						}
					}
				}
			else
				{
				PreferencesWarningLabel.Text = "This Data File Contains No Preferences";
				PreferencesWarningLabel.ForeColor = System.Drawing.Color.Black;

				ResetPreferencesCheckBox.Enabled = false;
				ResetPreferencesCheckBox.Checked = false;

				UpdatePreferencesCheckBox.Enabled = false;
				UpdatePreferencesCheckBox.Checked = false;
				}

			//----------------------------------------------------------------------------*
			// Make sure at least one item is checked
			//----------------------------------------------------------------------------*

			if (!AmmoCountCheckBox.Checked &&
				!AmmoTestCountCheckBox.Checked &&
				!BulletCountCheckBox.Checked &&
				!BulletCaliberCountCheckBox.Checked &&
				!CaseCountCheckBox.Checked &&
				!PowderCountCheckBox.Checked &&
				!PrimerCountCheckBox.Checked &&
				!ManufacturerCountCheckBox.Checked &&
				!CaliberCountCheckBox.Checked &&
				!FirearmBulletCountCheckBox.Checked &&
				!FirearmCaliberCountCheckBox.Checked &&
				!FirearmBulletCountCheckBox.Checked &&
				!AccessoryCountCheckBox.Checked)
				fEnableOK = false;

			//----------------------------------------------------------------------------*
			// Set OK Button State
			//----------------------------------------------------------------------------*

			OKButton.Enabled = fEnableOK;
			}
		}
	}
