//============================================================================*
// cBatchForm.cs
//
// Copyright © 2013-2014, Kevin S. Beebe
// All Rights Reserved
//============================================================================*

//============================================================================*
// .Net Using Statements
//============================================================================*

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

//============================================================================*
// Application Specific Using Statements
//============================================================================*

using ReloadersWorkShop.Controls;
using ReloadersWorkShop.Preferences;

//============================================================================*
// NameSpace
//============================================================================*

namespace ReloadersWorkShop
	{
	//============================================================================*
	// cCostAnalysisForm Class
	//============================================================================*

	public partial class cCostAnalysisForm : Form
		{
		//============================================================================*
		// Private Data Members
		//============================================================================*

		private cDataFiles m_DataFiles = null;
		private cCostAnalysisParms m_Parms = null;

		private bool m_fInitialized = false;
		private bool m_fPopulating = false;

		//============================================================================*
		// cCostAnalysisForm() - Constructor
		//============================================================================*

		public cCostAnalysisForm(cDataFiles DataFiles, cCostAnalysisParms Parms)
			{
			InitializeComponent();

			m_DataFiles = DataFiles;
			m_Parms = Parms;

			SetClientSizeCore(FiltersGroupBox.Location.X + FiltersGroupBox.Width + 10, AnalysisCancelButton.Location.Y + AnalysisCancelButton.Height + 20);

			Initialize();

			UpdateButtons();

			m_fInitialized = true;
			}

		//============================================================================*
		// Initialize()
		//============================================================================*

		private void Initialize()
			{
			//----------------------------------------------------------------------------*
			// Event Handlers
			//----------------------------------------------------------------------------*

			StartDatePicker.ValueChanged += OnStartDateChanged;
			EndDatePicker.ValueChanged += OnEndDateChanged;

			ComponentsCheckBox.Click += OnCheckBoxClicked;
			OverviewCheckBox.Click += OnCheckBoxClicked;

			AdjustmentsCheckBox.Click += OnCheckBoxClicked;
			InitialStockCheckBox.Click += OnCheckBoxClicked;
			PurchasesCheckBox.Click += OnCheckBoxClicked;
			FiredCheckBox.Click += OnCheckBoxClicked;

			BulletsCheckBox.Click += OnCheckBoxClicked;
			CasesCheckBox.Click += OnCheckBoxClicked;
			PrimersCheckBox.Click += OnCheckBoxClicked;
			PowderCheckBox.Click += OnCheckBoxClicked;
			ReloadsCheckBox.Click += OnCheckBoxClicked;
			FactoryAmmoCheckBox.Click += OnCheckBoxClicked;

			ManufacturerCombo.SelectedIndexChanged += OnManufacturerSelected;
			PurchaseLocationCombo.SelectedIndexChanged += OnLocationSelected;

			PrintButton.Click += OnPrintClicked;

			//----------------------------------------------------------------------------*
			// Set the starting and ending date info
			//----------------------------------------------------------------------------*

			m_Parms.StartDate = m_DataFiles.FirstTransactionDate;
			m_Parms.EndDate = m_DataFiles.LastTransactionDate;

			//----------------------------------------------------------------------------*
			// Populate the dialog and exit
			//----------------------------------------------------------------------------*

			Populate();

			PopulateLocationCombo();
			}

		//============================================================================*
		// OnCheckBoxClicked()
		//============================================================================*

		private void OnCheckBoxClicked(Object sender, EventArgs args)
			{
			if (!m_fInitialized || m_fPopulating)
				return;

			(sender as CheckBox).Checked = !(sender as CheckBox).Checked;

			switch ((sender as CheckBox).Name)
				{
				case "ActivityCheckBox":
					m_Parms.Activity = (sender as CheckBox).Checked;
					break;

				case "AdjustmentsCheckBox":
					m_Parms.Adjustments = (sender as CheckBox).Checked;
					break;

				case "BulletsCheckBox":
					m_Parms.Bullets = (sender as CheckBox).Checked;
					break;

				case "CasesCheckBox":
					m_Parms.Cases = (sender as CheckBox).Checked;
					break;

				case "ComponentsCheckBox":
					m_Parms.Components = (sender as CheckBox).Checked;
					break;

				case "FactoryAmmoCheckBox":
					m_Parms.Ammo = (sender as CheckBox).Checked;
					break;

				case "FiredCheckBox":
					m_Parms.Fired = (sender as CheckBox).Checked;
					break;

				case "InitialStockCheckBox":
					m_Parms.InitialStock = (sender as CheckBox).Checked;
					break;

				case "OverviewCheckBox":
					m_Parms.Overview = (sender as CheckBox).Checked;
					break;

				case "PowderCheckBox":
					m_Parms.Powder = (sender as CheckBox).Checked;
					break;

				case "PrimersCheckBox":
					m_Parms.Primers = (sender as CheckBox).Checked;
					break;

				case "PurchasesCheckBox":
					m_Parms.Purchases = (sender as CheckBox).Checked;
					break;

				case "ReloadsCheckBox":
					m_Parms.Reloads = (sender as CheckBox).Checked;
					break;
				}

			UpdateButtons();
			}

		//============================================================================*
		// OnEndDateChanged()
		//============================================================================*

		private void OnEndDateChanged(Object sender, EventArgs args)
			{
			if (!m_fInitialized || m_fPopulating)
				return;

			m_Parms.EndDate = EndDatePicker.Value;

			UpdateButtons();
			}

		//============================================================================*
		// OnLocationSelected()
		//============================================================================*

		private void OnLocationSelected(Object sender, EventArgs args)
			{
			if (!m_fInitialized || m_fPopulating)
				return;

			if (PurchaseLocationCombo.SelectedIndex > 0)
				m_Parms.Location = (string) PurchaseLocationCombo.SelectedItem;
			else
				m_Parms.Location = "";

			UpdateButtons();
			}

		//============================================================================*
		// OnManufacturerSelected()
		//============================================================================*

		private void OnManufacturerSelected(Object sender, EventArgs args)
			{
			if (!m_fInitialized || m_fPopulating)
				return;

			if (ManufacturerCombo.SelectedIndex > 0)
				m_Parms.Manufacturer = (ManufacturerCombo.SelectedItem as cManufacturer);
			else
				m_Parms.Manufacturer = null;

			Populate();
			}

		//============================================================================*
		// OnPrintClicked()
		//============================================================================*

		private void OnPrintClicked(Object sender, EventArgs args)
			{
			cCostAnalysisPreviewDialog CostAnalysisPreviewDlg = new cCostAnalysisPreviewDialog(m_DataFiles, m_Parms);

			CostAnalysisPreviewDlg.ShowDialog();
			}

		//============================================================================*
		// OnStartDateChanged()
		//============================================================================*

		private void OnStartDateChanged(Object sender, EventArgs args)
			{
			if (!m_fInitialized || m_fPopulating)
				return;

			m_Parms.StartDate = StartDatePicker.Value;

			UpdateButtons();
			}

		//============================================================================*
		// Populate()
		//============================================================================*

		private void Populate()
			{
			m_fPopulating = true;

			BulletsCheckBox.Checked = m_Parms.Bullets;
			CasesCheckBox.Checked = m_Parms.Cases;
			PowderCheckBox.Checked = m_Parms.Powder;
			PrimersCheckBox.Checked = m_Parms.Primers;
			ReloadsCheckBox.Checked = m_Parms.Reloads;
			FactoryAmmoCheckBox.Checked = m_Parms.Ammo;

			PurchasesCheckBox.Checked = m_Parms.Purchases;
			InitialStockCheckBox.Checked = m_Parms.InitialStock;
			AdjustmentsCheckBox.Checked = m_Parms.Adjustments;
			FiredCheckBox.Checked = m_Parms.Fired;

			OverviewCheckBox.Checked = m_Parms.Overview;
			ComponentsCheckBox.Checked = m_Parms.Components;

			m_fPopulating = false;

			PopulateManufacturersCombo();

			PopulateDates();

			UpdateButtons();
			}

		//============================================================================*
		// PopulateDates()
		//============================================================================*

		private void PopulateDates()
			{
			m_fPopulating = true;

			StartDatePicker.Value = m_Parms.StartDate;
			EndDatePicker.Value = m_Parms.EndDate;

			m_fPopulating = false;
			}

		//============================================================================*
		// PopulateLocationCombo()
		//============================================================================*

		private void PopulateLocationCombo()
			{
			PurchaseLocationCombo.Items.Clear();

			PurchaseLocationCombo.Items.Add("All Purchase Locations");

			List<string> LocationList = m_DataFiles.GetTransactionSourceList(cTransaction.eTransactionType.Purchase);

			foreach(string strString in LocationList)
				PurchaseLocationCombo.Items.Add(strString);

			PurchaseLocationCombo.SelectedIndex = 0;
			}

		//============================================================================*
		// PopulateManufacturersCombo()
		//============================================================================*

		private void PopulateManufacturersCombo()
			{
			m_fPopulating = true;

			//----------------------------------------------------------------------------*
			// Get the Manufacturer List
			//----------------------------------------------------------------------------*

			cManufacturerList ManufacturerList = m_Parms.ManufacturerList;

			//----------------------------------------------------------------------------*
			// Reset the manufacturer combo
			//----------------------------------------------------------------------------*

			ManufacturerCombo.Items.Clear();

			ManufacturerCombo.Items.Add("All Manufacturers");

			//----------------------------------------------------------------------------*
			// Add the Manufacturer List
			//----------------------------------------------------------------------------*

			foreach (cManufacturer Manufacturer in ManufacturerList)
				ManufacturerCombo.Items.Add(Manufacturer);

			if (m_Parms.Manufacturer == null)
				ManufacturerCombo.SelectedIndex = 0;
			else
				ManufacturerCombo.SelectedItem = m_Parms.Manufacturer;

			if (ManufacturerCombo.SelectedIndex < 0)
				ManufacturerCombo.SelectedIndex = 0;

			m_fPopulating = false;
			}

		//============================================================================*
		// SetChecks()
		//============================================================================*

		private void SetChecks()
			{
			}

		//============================================================================*
		// UpdateButtons()
		//============================================================================*

		private void UpdateButtons()
			{
			bool fEnableOK = true;

			//----------------------------------------------------------------------------*
			// Check the manufacturer and the components it supplys
			//----------------------------------------------------------------------------*

			if (ManufacturerCombo.SelectedIndex <= 0)
				{
				BulletsCheckBox.Enabled = true;
				CasesCheckBox.Enabled = true;
				PowderCheckBox.Enabled = true;
				PrimersCheckBox.Enabled = true;
				FactoryAmmoCheckBox.Enabled = true;
				ReloadsCheckBox.Enabled = true;
				}
			else
				{
				cManufacturer Manufacturer = ManufacturerCombo.SelectedItem as cManufacturer;

				if (Manufacturer != null)
					{
					BulletsCheckBox.Enabled = Manufacturer.Bullets;
					CasesCheckBox.Enabled = Manufacturer.Cases;
					PowderCheckBox.Enabled = Manufacturer.Powder;
					PrimersCheckBox.Enabled = Manufacturer.Primers;
					FactoryAmmoCheckBox.Enabled = Manufacturer.Ammo;
					ReloadsCheckBox.Enabled = Manufacturer.Name == "Batch Editor";

					BulletsCheckBox.Checked = (!Manufacturer.Bullets ? false : BulletsCheckBox.Checked);
					CasesCheckBox.Checked = (!Manufacturer.Cases ? false : CasesCheckBox.Checked);
					PowderCheckBox.Checked = (!Manufacturer.Powder ? false : PowderCheckBox.Checked);
					PrimersCheckBox.Checked = (!Manufacturer.Primers ? false : PrimersCheckBox.Checked);
					FactoryAmmoCheckBox.Checked = (!Manufacturer.Ammo ? false : FactoryAmmoCheckBox.Checked);
					ReloadsCheckBox.Checked = ((Manufacturer.Name != "Batch Editor") ? false : ReloadsCheckBox.Checked);
					}
				}

			//----------------------------------------------------------------------------*
			// Make sure there are transactions to print
			//----------------------------------------------------------------------------*

			if (!m_Parms.TransactionsExist())
				{
				fEnableOK = false;

				ParmsOKLabel.Text = "No inventory activity found for the above search criteria.";
				}
			else
				ParmsOKLabel.Text = "";

			PrintButton.Enabled = fEnableOK;
			}
		}
	}
