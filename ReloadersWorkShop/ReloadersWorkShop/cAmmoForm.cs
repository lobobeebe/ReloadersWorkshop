﻿//============================================================================*
// cAmmoForm.cs
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

using ReloadersWorkShop.Controls;
using ReloadersWorkShop.Preferences;

//============================================================================*
// NameSpace
//============================================================================*

namespace ReloadersWorkShop
	{
	//============================================================================*
	// cFactoryAmmoForm Class
	//============================================================================*

	public partial class cAmmoForm : Form
		{
		//----------------------------------------------------------------------------*
		// Private Constant Data Members
		//----------------------------------------------------------------------------*

		private const string cm_strFirearmTypeToolTip = "Type of firearm for which this ammo is used.";
		private const string cm_strManufacturerToolTip = "Manufacturer of this ammo.";
		private const string cm_strCaliberToolTip = "Caliber of this ammo.";
		private const string cm_strBulletWeightToolTip = "Bullet weight in grains.";
		private const string cm_strBulletDiameterToolTip = "Bullet diameter in inches.";
		private const string cm_strPartNumberToolTip = "Manufacturer's part number.";
		private const string cm_strBulletTypeToolTip = "Manufacturer's Brand name for the ammo.";
		private const string cm_strBallisticCoefficientToolTip = "Ballistic Coefficient for this ammo.";
		private const string cm_strTestListToolTip = "List of tests for this ammo.";
		private const string cm_strOKButtonToolTip = "Click to add or update the ammo with the above data.";
		private const string cm_strCancelButtonToolTip = "Click to cancel changes and return to the main window.";

		private const string cm_strAddTestButtonToolTip = "Click to add a test for this ammo.";
		private const string cm_strEditTestButtonToolTip = "Click to edit the selected test.";
		private const string cm_strRemoveTestButtonToolTip = "Click to remove the selected test.";

		//----------------------------------------------------------------------------*
		// Private Data Members
		//----------------------------------------------------------------------------*

		private bool m_fChanged = false;
		private bool m_fViewOnly = false;
		private bool m_fAdd = false;

		private string m_strOriginalPartNumber = "";
		private double m_dOriginalQuantityOnHand = 0.0;
		private double m_dOriginalCost = 0.0;

		private cAmmo m_Ammo;

		private cDataFiles m_DataFiles;

		private cAmmoTestListView m_TestListView = null;

		private bool m_fInitialized = false;
		private bool m_fPopulating = false;

		//		private cBulletCaliberListView m_BulletCalibersListView = null;

		private ToolTip m_FirearmTypeToolTip = new ToolTip();
		private ToolTip m_ManufacturerToolTip = new ToolTip();
		private ToolTip m_TestListToolTip = new ToolTip();
		private ToolTip m_OKButtonToolTip = new ToolTip();
		private ToolTip m_CancelButtonToolTip = new ToolTip();

		private ToolTip m_AddTestToolTip = new ToolTip();
		private ToolTip m_EditTestToolTip = new ToolTip();
		private ToolTip m_RemoveTestToolTip = new ToolTip();

		//============================================================================*
		// cFactoryAmmoForm() - Constructor
		//============================================================================*

		public cAmmoForm(cAmmo Ammo, cDataFiles Datafiles, bool fViewOnly = false)
			{
			InitializeComponent();

			m_DataFiles = Datafiles;
			m_fViewOnly = fViewOnly;

			//----------------------------------------------------------------------------*
			// Create the m_Ammo object
			//----------------------------------------------------------------------------*

			if (Ammo == null)
				{
				if (fViewOnly)
					return;

				m_fAdd = true;

				if (m_DataFiles.Preferences.LastAmmo == null)
					m_Ammo = new cAmmo();
				else
					{
					m_Ammo = new cAmmo(m_DataFiles.Preferences.LastAmmo);

					m_Ammo.PartNumber = "";
					m_Ammo.Type = "";
					m_Ammo.BallisticCoefficient = 0.0;

					m_Ammo.ResetAllInventoryData();

					m_Ammo.TestList.Clear();

					OKButton.Text = "Add";
					}
				}
			else
				{
				m_Ammo = new cAmmo(Ammo);
				}

			SetClientSizeCore(GeneralGroupBox.Location.X + GeneralGroupBox.Width + 10, CancelAmmoButton.Location.Y + CancelAmmoButton.Height + 20);

			//----------------------------------------------------------------------------*
			// Record Original Data
			//----------------------------------------------------------------------------*

			m_strOriginalPartNumber = m_Ammo.PartNumber;
			m_dOriginalCost = m_Ammo.Cost;
			m_dOriginalQuantityOnHand = m_Ammo.QuantityOnHand;

			Initialize();

			//----------------------------------------------------------------------------*
			// Populate All Bullet Data
			//----------------------------------------------------------------------------*

			SetInputParameters();

			PopulateComboBoxes();

			PopulateAmmoData();

			UpdateButtons();

			m_fInitialized = true;
			}

		//============================================================================*
		// AddTest()
		//============================================================================*

		private void AddTest(cAmmoTest AmmoTest)
			{
			//----------------------------------------------------------------------------*
			// Add the new test to the database
			//----------------------------------------------------------------------------*

			m_Ammo.TestList.Add(AmmoTest);

			//----------------------------------------------------------------------------*
			// Add the new test to the Caliber tab
			//----------------------------------------------------------------------------*

			m_fChanged = true;

			m_TestListView.AddAmmoTest(AmmoTest, true);
			}

		//============================================================================*
		// Ammo Property
		//============================================================================*

		public cAmmo Ammo
			{
			get { return (m_Ammo); }
			}

		//============================================================================*
		// Initialize()
		//============================================================================*

		private void Initialize()
			{
			if (!m_fViewOnly)
				{
				OKButton.Visible = true;

				if (m_fAdd)
					OKButton.Text = "Add";
				else
					OKButton.Text = "Update";

				int nButtonX = (this.Size.Width / 2) - ((OKButton.Width + PrintButton.Width + CancelAmmoButton.Width + 40) / 2);

				OKButton.Location = new Point(nButtonX, OKButton.Location.Y);
				nButtonX += OKButton.Width + 20;

				PrintButton.Location = new Point(nButtonX, PrintButton.Location.Y);
				nButtonX += PrintButton.Width + 20;

				CancelAmmoButton.Location = new Point(nButtonX, CancelAmmoButton.Location.Y);

				CancelAmmoButton.Text = "Cancel";
				}
			else
				{
				OKButton.Visible = false;

				int nButtonX = (this.Size.Width / 2) - ((PrintButton.Width + CancelAmmoButton.Width + 20) / 2);

				PrintButton.Location = new Point(nButtonX, PrintButton.Location.Y);
				nButtonX += PrintButton.Width + 20;

				CancelAmmoButton.Location = new Point(nButtonX, CancelAmmoButton.Location.Y);

				CancelAmmoButton.Text = "Close";
				}

			//----------------------------------------------------------------------------*
			// Create the Ammo's Test List View
			//----------------------------------------------------------------------------*

			m_TestListView = new cAmmoTestListView(m_DataFiles, m_Ammo);

			m_TestListView.Location = new Point(6, 20);
			m_TestListView.Size = new Size(TestDataGroupBox.Width - 12, AddTestButton.Location.Y - m_TestListView.Location.Y - 6);
			m_TestListView.TabIndex = 0;

			TestDataGroupBox.Controls.Add(m_TestListView);

			//----------------------------------------------------------------------------*
			// Set Control Event Handlers
			//----------------------------------------------------------------------------*

			if (!m_fViewOnly)
				{
				if (m_Ammo.TestList.Count > 0)
					{
					FirearmTypeCombo.Enabled = false;
					ManufacturerCombo.Enabled = false;
					CaliberCombo.Enabled = false;
					BulletDiameterTextBox.Enabled = false;
					BulletWeightTextBox.Enabled = false;
					}
				else
					{
					FirearmTypeCombo.SelectedIndexChanged += OnFirearmTypeSelected;
					ManufacturerCombo.SelectedIndexChanged += OnManufacturerSelected;
					CaliberCombo.SelectedIndexChanged += OnCaliberSelected;
					BulletDiameterTextBox.TextChanged += OnBulletDiameterChanged;
					BulletWeightTextBox.TextChanged += OnWeightChanged;
					}

				PartNumberTextBox.TextChanged += OnPartNumberChanged;

				ReloadCheckBox.Click += OnReloadClicked;

				TypeTextBox.TextChanged += OnTypeChanged;

				BallisticCoefficientTextBox.TextChanged += OnBallisticCoefficientChanged;

				QuantityTextBox.TextChanged += OnQuantityChanged;

				CostTextBox.TextChanged += OnPriceChanged;

				m_TestListView.SelectedIndexChanged += OnTestSelected;

				AddTestButton.Click += OnAddTest;
				EditTestButton.Click += OnEditTest;
				RemoveTestButton.Click += OnRemoveTest;

				OKButton.Click += OnOKClicked;
				}
			else
				{
				PartNumberTextBox.ReadOnly = true;
				TypeTextBox.ReadOnly = true;
				BallisticCoefficientTextBox.ReadOnly = true;
				BulletWeightTextBox.ReadOnly = true;
				QuantityTextBox.ReadOnly = true;
				CostTextBox.ReadOnly = true;

				AddTestButton.Enabled = false;
				EditTestButton.Enabled = false;
				RemoveTestButton.Enabled = false;
				}

			PrintButton.Click += OnPrintClicked;

			InventoryButton.Click += OnInventoryClicked;

			//----------------------------------------------------------------------------*
			// Set Labels for inventory tracking if needed
			//----------------------------------------------------------------------------*

			if (m_DataFiles.Preferences.TrackInventory)
				{
				QuantityLabel.Text = "Qty on Hand:";

				QuantityTextBox.BorderStyle = BorderStyle.None;
				QuantityTextBox.Font = new Font(QuantityTextBox.Font, FontStyle.Bold);
				QuantityTextBox.Location = new Point(QuantityTextBox.Location.X, QuantityTextBox.Location.Y + 3);
				QuantityTextBox.Enabled = false;

				CostTextBox.BorderStyle = BorderStyle.None;
				CostTextBox.Font = new Font(CostTextBox.Font, FontStyle.Bold);
				CostTextBox.TextAlign = HorizontalAlignment.Left;
				CostTextBox.Location = new Point(CostTextBox.Location.X, CostTextBox.Location.Y + 3);
				CostTextBox.Enabled = false;

				InventoryGroupBox.Text = "Inventory Info";

				CostLabel.Text = "Value:";
				}
			else
				{
				InventoryButton.Visible = false;

				CostLabel.Text = String.Format("Cost ({0}):", m_DataFiles.Preferences.Currency);
				}

			//----------------------------------------------------------------------------*
			// Set Title
			//----------------------------------------------------------------------------*

			string strTitle;

			if (m_fAdd)
				{
				strTitle = "Add";

				m_fChanged = true;
				}
			else
				{
				if (m_fViewOnly)
					strTitle = "View";
				else
					strTitle = "Edit";

				m_fChanged = false;
				}

			strTitle += " Ammo";

			Text = strTitle;

			SetStaticToolTips();
			}

		//============================================================================*
		// OnAddTest()
		//============================================================================*

		private void OnAddTest(object sender, EventArgs e)
			{
			//----------------------------------------------------------------------------*
			// Start the dialog
			//----------------------------------------------------------------------------*

			cAmmoTestForm AmmoTestForm = new cAmmoTestForm(m_Ammo, null, m_DataFiles);

			if (AmmoTestForm.ShowDialog() == DialogResult.OK)
				{
				//----------------------------------------------------------------------------*
				// Get the new Caliber Data
				//----------------------------------------------------------------------------*

				cAmmoTest NewAmmoTest = AmmoTestForm.AmmoTest;

				m_fChanged = true;

				AddTest(NewAmmoTest);

				UpdateButtons();
				}
			}

		//============================================================================*
		// OnBallisticCoefficientChanged()
		//============================================================================*

		private void OnBallisticCoefficientChanged(object sender, EventArgs e)
			{
			if (!m_fInitialized || m_fPopulating)
				return;

			m_Ammo.BallisticCoefficient = BallisticCoefficientTextBox.Value;

			m_fChanged = true;

			UpdateButtons();
			}

		//============================================================================*
		// OnBulletDiameterChanged()
		//============================================================================*

		private void OnBulletDiameterChanged(object sender, EventArgs e)
			{
			if (!m_fInitialized || m_fPopulating)
				return;

			m_Ammo.BulletDiameter = m_DataFiles.MetricToStandard(BulletDiameterTextBox.Value, cDataFiles.eDataType.Dimension);

			SetSectionalDensity();

			m_fChanged = true;

			UpdateButtons();
			}

		//============================================================================*
		// OnCaliberSelected()
		//============================================================================*

		private void OnCaliberSelected(object sender, EventArgs e)
			{
			if (!m_fInitialized || m_fPopulating)
				return;

			cCaliber Caliber = (cCaliber)CaliberCombo.SelectedItem;

			if (Caliber.CompareTo(m_Ammo.Caliber) == 0)
				return;

			m_fChanged = true;

			m_Ammo.Caliber = Caliber;

			m_Ammo.PartNumber = "";
			m_Ammo.Type = "";
			m_Ammo.BallisticCoefficient = 0.0;

			PopulateAmmoData();

			m_DataFiles.Preferences.LastAmmoCaliber = m_Ammo.Caliber;

			m_fChanged = true;

			UpdateButtons();
			}

		//============================================================================*
		// OnEditTest()
		//============================================================================*

		private void OnEditTest(object sender, EventArgs e)
			{
			//----------------------------------------------------------------------------*
			// Start the dialog
			//----------------------------------------------------------------------------*

			cAmmoTest OldAmmoTest = (cAmmoTest)m_TestListView.SelectedItems[0].Tag;

			cAmmoTestForm AmmoTestForm = new cAmmoTestForm(m_Ammo, OldAmmoTest, m_DataFiles);

			if (AmmoTestForm.ShowDialog(this) == DialogResult.OK)
				{
				//----------------------------------------------------------------------------*
				// Get the new Test Data
				//----------------------------------------------------------------------------*

				cAmmoTest NewAmmoTest = AmmoTestForm.AmmoTest;

				//----------------------------------------------------------------------------*
				// Update the test
				//----------------------------------------------------------------------------*

				UpdateTest(OldAmmoTest, NewAmmoTest);

				m_fChanged = true;

				UpdateButtons();
				}
			}

		//============================================================================*
		// OnFirearmTypeSelected()
		//============================================================================*

		private void OnFirearmTypeSelected(object sender, EventArgs e)
			{
			if (!m_fInitialized || m_fPopulating)
				return;

			if (m_Ammo.FirearmType == FirearmTypeCombo.Value)
				return;

			m_Ammo.FirearmType = FirearmTypeCombo.Value;

			m_fChanged = true;

			PopulateCaliberCombo();

			m_Ammo.Caliber = (cCaliber) CaliberCombo.SelectedItem;
			m_Ammo.Manufacturer = (cManufacturer) ManufacturerCombo.SelectedItem;

			PopulateBulletData();

			m_fChanged = true;

			UpdateButtons();
			}

		//============================================================================*
		// OnInventoryClicked()
		//============================================================================*

		private void OnInventoryClicked(object sender, EventArgs e)
			{
			cInventoryForm InventoryForm = new cInventoryForm(m_Ammo, m_DataFiles, m_fViewOnly);

			InventoryForm.ShowDialog();

			if (!m_fChanged)
				m_fChanged = InventoryForm.Changed;

			PopulateInventoryData();

			UpdateButtons();
			}

		//============================================================================*
		// OnManufacturerSelected()
		//============================================================================*

		private void OnManufacturerSelected(object sender, EventArgs e)
			{
			if (!m_fInitialized || m_fPopulating)
				return;

			cManufacturer Manufacturer = (cManufacturer)ManufacturerCombo.SelectedItem;

			if (Manufacturer == null || Manufacturer.CompareTo(m_Ammo.Manufacturer) == 0)
				return;

			m_fChanged = true;

			m_Ammo.Manufacturer = Manufacturer;

			PartNumberTextBox.Value = "";
			TypeTextBox.Value = "";

			m_DataFiles.Preferences.LastAmmoManufacturer = m_Ammo.Manufacturer;

			m_fChanged = true;

			UpdateButtons();
			}

		//============================================================================*
		// OnOKClicked()
		//============================================================================*

		private void OnOKClicked(object sender, EventArgs e)
			{
			m_DataFiles.Preferences.LastAmmoCaliber = m_Ammo.Caliber;
			m_DataFiles.Preferences.LastAmmoManufacturer = m_Ammo.Manufacturer;
			}

		//============================================================================*
		// OnPartNumberChanged()
		//============================================================================*

		private void OnPartNumberChanged(object sender, EventArgs e)
			{
			if (!m_fInitialized || m_fPopulating)
				return;

			m_Ammo.PartNumber = PartNumberTextBox.Value;

			m_fChanged = true;

			UpdateButtons();
			}

		//============================================================================*
		// OnPriceChanged()
		//============================================================================*

		private void OnPriceChanged(object sender, EventArgs e)
			{
			if (!m_fInitialized || m_fPopulating)
				return;

			m_Ammo.Cost = CostTextBox.Value;

			SetCostEach();

			m_fChanged = true;

			UpdateButtons();
			}

		//============================================================================*
		// OnPrintClicked()
		//============================================================================*

		private void OnPrintClicked(object sender, EventArgs e)
			{
			Cursor = Cursors.WaitCursor;

			cAmmoPrintForm AmmoPrintForm = new cAmmoPrintForm(m_Ammo, m_DataFiles);

			Cursor = Cursors.Default;

			AmmoPrintForm.ShowDialog();
			}

		//============================================================================*
		// OnReloadClicked()
		//============================================================================*

		private void OnReloadClicked(object sender, EventArgs e)
			{
			m_Ammo.Reload = ReloadCheckBox.Checked;

			m_fChanged = true;

			UpdateButtons();
			}

		//============================================================================*
		// OnQuantityChanged()
		//============================================================================*

		private void OnQuantityChanged(object sender, EventArgs e)
			{
			if (!m_fInitialized || m_fPopulating)
				return;

			m_Ammo.Quantity = QuantityTextBox.Value;

			m_fChanged = true;

			SetCostEach();

			UpdateButtons();
			}

		//============================================================================*
		// OnRemoveTest()
		//============================================================================*

		private void OnRemoveTest(object sender, EventArgs e)
			{
			//----------------------------------------------------------------------------*
			// Warn user of impending doom
			//----------------------------------------------------------------------------*

			if (MessageBox.Show(this, "Are you SURE you wish to delete this test?", "Data Deletion Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
				{
				cAmmoTest Test = (cAmmoTest)m_TestListView.SelectedItems[0].Tag;

				m_TestListView.Items.Remove(m_TestListView.SelectedItems[0]);

				m_Ammo.TestList.Remove(Test);

				m_fChanged = true;

				UpdateButtons();
				}
			}

		//============================================================================*
		// OnTestSelected()
		//============================================================================*

		private void OnTestSelected(object sender, EventArgs e)
			{
			if (!m_fInitialized || m_fPopulating)
				return;

			UpdateButtons();
			}

		//============================================================================*
		// OnTypeChanged()
		//============================================================================*

		private void OnTypeChanged(object sender, EventArgs e)
			{
			if (!m_fInitialized || m_fPopulating)
				return;

			m_Ammo.Type = TypeTextBox.Value;

			m_fChanged = true;

			UpdateButtons();
			}

		//============================================================================*
		// OnWeightChanged()
		//============================================================================*

		private void OnWeightChanged(object sender, EventArgs e)
			{
			if (!m_fInitialized || m_fPopulating)
				return;

			m_Ammo.BulletWeight = m_DataFiles.MetricToStandard(BulletWeightTextBox.Value, cDataFiles.eDataType.BulletWeight);

			SetSectionalDensity();

			m_fChanged = true;

			UpdateButtons();
			}

		//============================================================================*
		// PopulateAmmoData()
		//============================================================================*

		private void PopulateAmmoData()
			{
			//----------------------------------------------------------------------------*
			// Data Text Boxes
			//----------------------------------------------------------------------------*

			PopulateBulletData();

			//----------------------------------------------------------------------------*
			// Set Cost Data
			//----------------------------------------------------------------------------*

			SetCosts();

			m_TestListView.Populate();
			}

		//============================================================================*
		// PopulateBulletData()
		//============================================================================*

		private void PopulateBulletData()
			{
			m_fPopulating = true;

			if (m_Ammo.Manufacturer == null)
				m_Ammo.Manufacturer = (cManufacturer)ManufacturerCombo.SelectedItem;

			if (m_Ammo.Caliber == null)
				m_Ammo.Caliber = (cCaliber)CaliberCombo.SelectedItem;

			//----------------------------------------------------------------------------*
			// Bullet Text Boxes
			//----------------------------------------------------------------------------*

			PartNumberTextBox.Value = m_Ammo.PartNumber;
			TypeTextBox.Value = m_Ammo.Type;
			ReloadCheckBox.Checked = m_Ammo.Reload;

			if (m_Ammo.BulletDiameter == 0.0 && m_Ammo.Caliber != null)
				m_Ammo.BulletDiameter = m_Ammo.Caliber.MinBulletDiameter;

			BulletDiameterTextBox.Value = m_DataFiles.StandardToMetric(m_Ammo.BulletDiameter, cDataFiles.eDataType.Dimension);
			BulletWeightTextBox.Value = m_DataFiles.StandardToMetric(m_Ammo.BulletWeight, cDataFiles.eDataType.BulletWeight);
			BallisticCoefficientTextBox.Value = m_Ammo.BallisticCoefficient;

			SetSectionalDensity();

			m_fPopulating = false;
			}

		//============================================================================*
		// PopulateCaliberCombo()
		//============================================================================*

		private void PopulateCaliberCombo()
			{
			m_fPopulating = true;

			CaliberCombo.Items.Clear();

			cCaliber SelectCaliber = null;

			if (m_fViewOnly)
				{
				if (m_Ammo.Caliber != null)
					CaliberCombo.Items.Add(m_Ammo.Caliber);
				}
			else
				{
				foreach (cCaliber Caliber in m_DataFiles.CaliberList)
					{
					if ((!m_DataFiles.Preferences.HideUncheckedCalibers || Caliber.Checked) &&
						Caliber.FirearmType == FirearmTypeCombo.Value)
						{
						CaliberCombo.Items.Add(Caliber);

						if (Caliber.CompareTo(m_Ammo.Caliber) == 0)
							SelectCaliber = Caliber;
						}
					}
				}

			if (SelectCaliber != null)
				CaliberCombo.SelectedItem = SelectCaliber;
			else
				{
				if (m_DataFiles.Preferences.LastAmmoCaliber != null)
					CaliberCombo.SelectedItem = m_DataFiles.Preferences.LastAmmoCaliber;
				}

			if (CaliberCombo.SelectedIndex == -1 && CaliberCombo.Items.Count > 0)
				CaliberCombo.SelectedIndex = 0;

			m_fPopulating = false;

			PopulateManufacturerCombo();
			}

		//============================================================================*
		// PopulateComboBoxes()
		//============================================================================*

		private void PopulateComboBoxes()
			{
			m_fPopulating = true;

			FirearmTypeCombo.Value = m_Ammo.FirearmType;

			m_fPopulating = false;

			PopulateCaliberCombo();
			}

		//============================================================================*
		// PopulateInventoryData()
		//============================================================================*

		private void PopulateInventoryData()
			{
			QuantityTextBox.Value = (int)m_DataFiles.SupplyQuantity(m_Ammo);

			CostTextBox.Value = m_DataFiles.SupplyCost(m_Ammo);

			if (m_DataFiles.Preferences.TrackInventory)
				CostTextBox.Text = String.Format("{0}{1:F2}", m_DataFiles.Preferences.Currency, m_DataFiles.SupplyCost(m_Ammo));

			SetCostEach();
			}

		//============================================================================*
		// PopulateManufacturerCombo()
		//============================================================================*

		private void PopulateManufacturerCombo()
			{
			m_fPopulating = true;

			ManufacturerCombo.Items.Clear();

			cManufacturer SelectManufacturer = null;

			if (m_fViewOnly)
				{
				if (m_Ammo.Manufacturer != null)
					ManufacturerCombo.Items.Add(m_Ammo.Manufacturer);

				if (ManufacturerCombo.Items.Count > 0)
					ManufacturerCombo.SelectedIndex = 0;
				}
			else
				{
				foreach (cManufacturer Manufacturer in m_DataFiles.ManufacturerList)
					{
					if (m_fAdd && Manufacturer.Name == "Batch Editor")
						continue;

					if (Manufacturer.Ammo)
						ManufacturerCombo.Items.Add(Manufacturer);

					if (Manufacturer.CompareTo(m_Ammo.Manufacturer) == 0)
						SelectManufacturer = Manufacturer;
					}

				if (SelectManufacturer == null)
					{
					if (m_DataFiles.Preferences.LastAmmoManufacturer != null)
						ManufacturerCombo.SelectedItem = m_DataFiles.Preferences.LastAmmoManufacturer;
					}
				else
					ManufacturerCombo.SelectedItem = SelectManufacturer;

				if (ManufacturerCombo.SelectedIndex < 0 && ManufacturerCombo.Items.Count > 0)
					{
					ManufacturerCombo.SelectedIndex = 0;

					m_Ammo.Manufacturer = (cManufacturer)ManufacturerCombo.SelectedItem;
					}
				}

			m_fPopulating = false;
			}

		//============================================================================*
		// SetCostEach()
		//============================================================================*

		private void SetCostEach()
			{
			CostEachLabel.Text = String.Format("{0}{1:F2}", m_DataFiles.Preferences.Currency, m_DataFiles.SupplyCostEach(m_Ammo));
			}

		//============================================================================*
		// SetCosts()
		//============================================================================*

		private void SetCosts()
			{
			m_fPopulating = true;

			QuantityTextBox.Value = (int)m_DataFiles.SupplyQuantity(m_Ammo);

			CostTextBox.Value = m_DataFiles.SupplyCost(m_Ammo);

			CostEachLabel.Text = String.Format("{0}{1:F2}", m_DataFiles.Preferences.Currency, m_DataFiles.SupplyCostEach(m_Ammo));

			m_fPopulating = false;
			}

		//============================================================================*
		// SetInputParameters()
		//============================================================================*

		private void SetInputParameters()
			{
			//----------------------------------------------------------------------------*
			// Set metric/standard labels
			//----------------------------------------------------------------------------*

			m_DataFiles.SetMetricLabel(BulletWeightMeasurementLabel, cDataFiles.eDataType.BulletWeight);

			m_DataFiles.SetMetricLabel(BulletDiameterMeasurementLabel, cDataFiles.eDataType.Dimension);

			//----------------------------------------------------------------------------*
			// Set Text Box Parameters
			//----------------------------------------------------------------------------*

			m_DataFiles.SetInputParameters(BulletDiameterTextBox, cDataFiles.eDataType.Dimension);

			m_DataFiles.SetInputParameters(BulletWeightTextBox, cDataFiles.eDataType.BulletWeight);
			}

		//============================================================================*
		// SetMinMax()
		//============================================================================*

		private void SetMinMax()
			{
			if (m_Ammo.Caliber == null)
				m_Ammo.Caliber = (cCaliber)CaliberCombo.SelectedItem;

			if (m_Ammo.Caliber != null)
				{
				BulletWeightTextBox.MinValue = m_DataFiles.StandardToMetric(m_Ammo.Caliber.MinBulletWeight, cDataFiles.eDataType.BulletWeight);
				BulletWeightTextBox.MaxValue = m_DataFiles.StandardToMetric(m_Ammo.Caliber.MaxBulletWeight, cDataFiles.eDataType.BulletWeight);

				BulletDiameterTextBox.MinValue = m_DataFiles.StandardToMetric(m_Ammo.Caliber.MinBulletDiameter, cDataFiles.eDataType.Dimension);
				BulletDiameterTextBox.MaxValue = m_DataFiles.StandardToMetric(m_Ammo.Caliber.MaxBulletDiameter, cDataFiles.eDataType.Dimension);
				}
			}

		//============================================================================*
		// SetSectionalDensity()
		//============================================================================*

		private void SetSectionalDensity()
			{
			SectionalDensityLabel.Text = String.Format("{0:F3}", cBullet.CalculateSectionalDensity(m_Ammo.BulletDiameter, m_Ammo.BulletWeight));
			}

		//============================================================================*
		// SetStaticToolTips()
		//============================================================================*

		private void SetStaticToolTips()
			{
			if (!m_DataFiles.Preferences.ToolTips)
				return;

			m_FirearmTypeToolTip.ShowAlways = true;
			m_FirearmTypeToolTip.RemoveAll();
			m_FirearmTypeToolTip.SetToolTip(FirearmTypeCombo, cm_strFirearmTypeToolTip);

			m_ManufacturerToolTip.ShowAlways = true;
			m_ManufacturerToolTip.RemoveAll();
			m_ManufacturerToolTip.SetToolTip(ManufacturerCombo, cm_strManufacturerToolTip);

			BulletDiameterTextBox.ToolTip = cm_strBulletDiameterToolTip;

			BulletWeightTextBox.ToolTip = cm_strBulletWeightToolTip;

			PartNumberTextBox.ToolTip = cm_strPartNumberToolTip;

			TypeTextBox.ToolTip = cm_strBulletTypeToolTip;

			BallisticCoefficientTextBox.ToolTip = cm_strBallisticCoefficientToolTip;

			m_TestListToolTip.ShowAlways = true;
			m_TestListToolTip.RemoveAll();
			m_TestListToolTip.SetToolTip(m_TestListView, cm_strTestListToolTip);

			m_OKButtonToolTip.ShowAlways = true;
			m_OKButtonToolTip.RemoveAll();
			m_OKButtonToolTip.SetToolTip(OKButton, cm_strOKButtonToolTip);

			m_CancelButtonToolTip.ShowAlways = true;
			m_CancelButtonToolTip.RemoveAll();
			m_CancelButtonToolTip.SetToolTip(CancelAmmoButton, cm_strCancelButtonToolTip);

			m_AddTestToolTip.ShowAlways = true;
			m_AddTestToolTip.RemoveAll();
			m_AddTestToolTip.SetToolTip(AddTestButton, cm_strAddTestButtonToolTip);

			m_EditTestToolTip.ShowAlways = true;
			m_EditTestToolTip.RemoveAll();
			m_EditTestToolTip.SetToolTip(EditTestButton, cm_strEditTestButtonToolTip);

			m_RemoveTestToolTip.ShowAlways = true;
			m_RemoveTestToolTip.RemoveAll();
			m_RemoveTestToolTip.SetToolTip(RemoveTestButton, cm_strRemoveTestButtonToolTip);
			}

		//============================================================================*
		// UpdateButtons()
		//============================================================================*

		private void UpdateButtons()
			{
			if (m_fViewOnly)
				return;

			bool fEnableOK = m_fChanged;
			string strToolTip;

			SetMinMax();

			//----------------------------------------------------------------------------*
			// Get Values
			//----------------------------------------------------------------------------*

			int nQuantity = QuantityTextBox.Value;

			double dPrice = CostTextBox.Value;

			//----------------------------------------------------------------------------*
			// Check Manufacturer
			//----------------------------------------------------------------------------*

			strToolTip = cm_strManufacturerToolTip;

			if (ManufacturerCombo.SelectedIndex == -1)
				{
				fEnableOK = false;

				ManufacturerCombo.BackColor = Color.LightPink;

				strToolTip += "\n\nYou must select a manufacturer.";
				}
			else
				ManufacturerCombo.BackColor = SystemColors.Window;

			if (m_DataFiles.Preferences.ToolTips)
				m_ManufacturerToolTip.SetToolTip(ManufacturerCombo, strToolTip);

			//----------------------------------------------------------------------------*
			// Check Part Number
			//----------------------------------------------------------------------------*

			cManufacturer Manufacturer = (cManufacturer)ManufacturerCombo.SelectedItem;

			strToolTip = cm_strPartNumberToolTip;

			bool fDuplicate = false;

			if ((m_fAdd || m_Ammo.PartNumber != m_strOriginalPartNumber) && ManufacturerCombo.SelectedIndex != -1)
				{
				foreach (cAmmo FactoryAmmo in m_DataFiles.AmmoList)
					{
					if (m_Ammo.CompareTo(FactoryAmmo) == 0)
						{
						fDuplicate = true;

						break;
						}
					}
				}

			DuplicateLabel.Visible = fDuplicate;

			//----------------------------------------------------------------------------*
			// Check Type
			//----------------------------------------------------------------------------*

			if (!TypeTextBox.ValueOK)
				fEnableOK = false;

			//----------------------------------------------------------------------------*
			// Check Bullet Diameter
			//----------------------------------------------------------------------------*

			if (!BulletDiameterTextBox.ValueOK)
				fEnableOK = false;

			//----------------------------------------------------------------------------*
			// Check BallisticCoefficient
			//----------------------------------------------------------------------------*

			if (!BallisticCoefficientTextBox.ValueOK)
				fEnableOK = false;

			//----------------------------------------------------------------------------*
			// Check Weight
			//----------------------------------------------------------------------------*

			if (!BulletWeightTextBox.ValueOK)
				fEnableOK = false;

			//----------------------------------------------------------------------------*
			// Add, Edit, Remove Test Buttons
			//----------------------------------------------------------------------------*

			AddTestButton.Enabled = !m_fViewOnly;

			EditTestButton.Enabled = m_TestListView.SelectedItems.Count > 0;

			if (m_TestListView.SelectedItems.Count > 0)
				{
				cAmmoTest AmmoTest = (cAmmoTest)m_TestListView.SelectedItems[0].Tag;

				if (AmmoTest != null)
					{
					if (AmmoTest.Firearm == null)
						RemoveTestButton.Enabled = false;
					else
						RemoveTestButton.Enabled = true;

					foreach (cFirearm Firearm in m_DataFiles.FirearmList)
						{
						if (Firearm.HasCaliber(m_Ammo.Caliber))
							{
							AddTestButton.Enabled = !m_fViewOnly;

							break;
							}
						}
					}
				else
					RemoveTestButton.Enabled = false;
				}
			else
				{
				RemoveTestButton.Enabled = false;
				}

			//----------------------------------------------------------------------------*
			// Set button state and exit
			//----------------------------------------------------------------------------*

			OKButton.Enabled = fEnableOK;
			}

		//============================================================================*
		// UpdateTest()
		//============================================================================*

		private void UpdateTest(cAmmoTest OldAmmoTest, cAmmoTest NewAmmoTest)
			{
			//----------------------------------------------------------------------------*
			// Find the test
			//----------------------------------------------------------------------------*

			foreach (cAmmoTest CheckAmmoTest in m_Ammo.TestList)
				{
				//----------------------------------------------------------------------------*
				// See if this is the same Test
				//----------------------------------------------------------------------------*

				if (CheckAmmoTest.CompareTo(OldAmmoTest) == 0)
					{
					//----------------------------------------------------------------------------*
					// Update the current Test record
					//----------------------------------------------------------------------------*

					CheckAmmoTest.Ammo = NewAmmoTest.Ammo;
					CheckAmmoTest.Firearm = NewAmmoTest.Firearm;
					CheckAmmoTest.TestDate = NewAmmoTest.TestDate;
					CheckAmmoTest.BarrelLength = NewAmmoTest.BarrelLength;
					CheckAmmoTest.Twist = NewAmmoTest.Twist;
					CheckAmmoTest.NumRounds = NewAmmoTest.NumRounds;
					CheckAmmoTest.MuzzleVelocity = NewAmmoTest.MuzzleVelocity;
					CheckAmmoTest.BestGroup = NewAmmoTest.BestGroup;
					CheckAmmoTest.BestGroupRange = NewAmmoTest.BestGroupRange;
					CheckAmmoTest.Notes = NewAmmoTest.Notes;
					CheckAmmoTest.TestShotList = NewAmmoTest.TestShotList;

					//----------------------------------------------------------------------------*
					// Update the test on the test list
					//----------------------------------------------------------------------------*

					m_TestListView.UpdateAmmoTest(CheckAmmoTest, true);

					return;
					}
				}

			//----------------------------------------------------------------------------*
			// If the Caliber was not found, add it
			//----------------------------------------------------------------------------*

			AddTest(NewAmmoTest);
			}
		}
	}
