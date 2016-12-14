//============================================================================*
// cMainForm.AmmoTab.cs
//
// Copyright © 2013-2014, Kevin S. Beebe
// All Rights Reserved
//============================================================================*

//============================================================================*
// .Net Using Statements
//============================================================================*

using System;
using System.Collections.Generic;
using System.Windows.Forms;

//============================================================================*
// Application Specific Using Statements
//============================================================================*

using ReloadersWorkShop.Preferences;

//============================================================================*
// NameSpace
//============================================================================*

namespace ReloadersWorkShop
	{
	//============================================================================*
	// cMainForm Class
	//============================================================================*

	partial class cMainForm
		{
		//============================================================================*
		// Private Data Members
		//============================================================================*

		cAmmoListView m_AmmoListView = null;

		private bool m_fAmmoTabInitialized = false;
		private bool m_fAmmoPopulating = false;

		//============================================================================*
		// AddAmmo()
		//============================================================================*

		private void AddAmmo(cAmmo Ammo)
			{
			//----------------------------------------------------------------------------*
			// If the Ammo already exists, our job is done, just exit
			//----------------------------------------------------------------------------*

			foreach (cAmmo CheckAmmo in m_DataFiles.AmmoList)
				{
				if (CheckAmmo.CompareTo(Ammo) == 0)
					return;
				}

			//----------------------------------------------------------------------------*
			// Otherwise, add the new ammo to the list
			//----------------------------------------------------------------------------*

			m_DataFiles.AmmoList.Add(Ammo);

			//----------------------------------------------------------------------------*
			// And add the new Firearm to the Firearm ListView
			//----------------------------------------------------------------------------*

			m_AmmoListView.AddAmmo(Ammo, true);

			AddAmmoButton.Focus();
			}

		//============================================================================*
		// InitializeAmmoTab()
		//============================================================================*

		public void InitializeAmmoTab()
			{
			if (!m_fAmmoTabInitialized)
				{
				m_AmmoListView = new cAmmoListView(m_DataFiles);

				AmmoTab.Controls.Add(m_AmmoListView);

				AddAmmoButton.Click += OnAddAmmo;
				EditAmmoButton.Click += OnEditAmmo;
				ViewAmmoButton.Click += OnViewAmmo;
				RemoveAmmoButton.Click += OnRemoveAmmo;

				m_AmmoListView.ItemSelectionChanged += OnAmmoSelected;
				m_AmmoListView.DoubleClick += OnAmmoDoubleClicked;

				AmmunitionFirearmTypeCombo.SelectedIndexChanged += OnAmmoFirearmTypeChanged;
				AmmunitionCaliberCombo.SelectedIndexChanged += OnAmmoCaliberChanged;
				AmmunitionManufacturerCombo.SelectedIndexChanged += OnAmmoManufacturerChanged;

				AmmoPrintAllRadioButton.Click += OnAmmoPrintAllClicked;
				AmmoPrintCheckedRadioButton.Click += OnAmmoPrintCheckedClicked;
				AmmoNonZeroCheckBox.Click += OnAmmoNonZeroFilterClicked;
				AmmoMinStockCheckBox.Click += OnAmmoMinStockFilterClicked;
				AmmoFactoryCheckBox.Click += OnAmmoFactoryFilterClicked;
				AmmoFactoryReloadsCheckBox.Click += OnAmmoFactoryReloadsFilterClicked;
				AmmoMyReloadsCheckBox.Click += OnAmmoMyReloadsFilterClicked;
				AmmoListPrintButton.Click += OnPrintAmmoListClicked;

				AmmoPrintAllRadioButton.Checked = m_DataFiles.Preferences.AmmoPrintAll;
				AmmoPrintCheckedRadioButton.Checked = m_DataFiles.Preferences.AmmoPrintChecked;

				AmmoFactoryCheckBox.Checked = m_DataFiles.Preferences.AmmoFactoryFilter;
				AmmoFactoryReloadsCheckBox.Checked = m_DataFiles.Preferences.AmmoFactoryReloadFilter;
				AmmoMyReloadsCheckBox.Checked = m_DataFiles.Preferences.AmmoMyReloadFilter;

				AmmoNonZeroCheckBox.Checked = m_DataFiles.Preferences.AmmoNonZeroFilter;
				AmmoMinStockCheckBox.Checked = m_DataFiles.Preferences.AmmoMinStockFilter;

				EditAmmoInventoryButton.Click += OnEditInventoryActivity;
				ViewAmmoInventoryButton.Click += OnViewInventoryActivity;
				AmmoCostAnalysisButton.Click += OnPrintCostAnalysisClicked;

				m_AmmoListView.ItemChecked += OnAmmoItemChecked;

				PruneReloads();

				m_fAmmoTabInitialized = true;
				}
			//----------------------------------------------------------------------------*
			// Operations that are always performed
			//----------------------------------------------------------------------------*

			AmmunitionCaliberCombo.SelectedIndex = 0;
			AmmunitionManufacturerCombo.SelectedIndex = 0;

			AmmoNonZeroCheckBox.Visible = m_DataFiles.Preferences.TrackInventory;
			AmmoNonZeroCheckBox.Checked = false;

			AmmoMinStockCheckBox.Visible = m_DataFiles.Preferences.TrackInventory;
			AmmoMinStockCheckBox.Checked = false;

			AmmoInventoryGroup.Visible = m_DataFiles.Preferences.TrackInventory;

			AmmunitionFirearmTypeCombo.SelectedIndex = 0;

			PopulateAmmoCaliberCombo();

			PopulateAmmoListViewColumns();

			UpdateAmmoTabButtons();
			}

		//============================================================================*
		// OnAddAmmo()
		//============================================================================*

		protected void OnAddAmmo(object sender, EventArgs args)
			{
			//----------------------------------------------------------------------------*
			// Start the dialog
			//----------------------------------------------------------------------------*

			Cursor = Cursors.WaitCursor;

			cAmmoForm AmmoForm = new cAmmoForm(null, m_DataFiles);

			Cursor = Cursors.Default;

			if (AmmoForm.ShowDialog() == DialogResult.OK)
				{
				//----------------------------------------------------------------------------*
				// Get the new Firearm Data
				//----------------------------------------------------------------------------*

				cAmmo NewAmmo = AmmoForm.Ammo;
				m_DataFiles.Preferences.LastAmmo = AmmoForm.Ammo;

				m_AmmoListView.Focus();

				//----------------------------------------------------------------------------*
				// See if the ammo already exists
				//----------------------------------------------------------------------------*

				foreach (cAmmo CheckAmmo in m_DataFiles.AmmoList)
					{
					if (CheckAmmo.CompareTo(NewAmmo) == 0)
						return;
					}

				AddAmmo(NewAmmo);
				}
			}

		//============================================================================*
		// OnAmmoCaliberChanged()
		//============================================================================*

		protected void OnAmmoCaliberChanged(object sender, EventArgs args)
			{
			if (m_fAmmoPopulating)
				return;

			PopulateAmmoManufacturerCombo();

			UpdateAmmoTabButtons();
			}

		//============================================================================*
		// OnAmmoFirearmTypeChanged()
		//============================================================================*

		protected void OnAmmoFirearmTypeChanged(object sender, EventArgs args)
			{
			if (m_fAmmoPopulating)
				return;

			PopulateAmmoCaliberCombo();

			UpdateAmmoTabButtons();
			}

		//============================================================================*
		// OnAmmoItemChecked()
		//============================================================================*

		protected void OnAmmoItemChecked(object sender, ItemCheckedEventArgs args)
			{
			if (!m_fInitialized || m_fPopulating)
				return;

			cAmmo Ammo = (cAmmo) args.Item.Tag;

			if (Ammo != null)
				Ammo.Checked = args.Item.Checked;

			UpdateAmmoTabButtons();
			}

		//============================================================================*
		// OnAmmoManufacturerChanged()
		//============================================================================*

		protected void OnAmmoManufacturerChanged(object sender, EventArgs args)
			{
			if (m_fAmmoPopulating)
				return;

			PopulateAmmoListView();

			UpdateAmmoTabButtons();
			}

		//============================================================================*
		// OnAmmoPrintAllClicked()
		//============================================================================*

		protected void OnAmmoPrintAllClicked(object sender, EventArgs args)
			{
			AmmoPrintAllRadioButton.Checked = !AmmoPrintAllRadioButton.Checked;
			AmmoPrintCheckedRadioButton.Checked = !AmmoPrintAllRadioButton.Checked;

			m_DataFiles.Preferences.AmmoPrintAll = AmmoPrintAllRadioButton.Checked;
			m_DataFiles.Preferences.AmmoPrintChecked = AmmoPrintCheckedRadioButton.Checked;

			UpdateAmmoTabButtons();
			}

		//============================================================================*
		// OnAmmoMinStockFilterClicked()
		//============================================================================*

		protected void OnAmmoMinStockFilterClicked(object sender, EventArgs args)
			{
			m_DataFiles.Preferences.AmmoMinStockFilter = AmmoMinStockCheckBox.Checked;

			PopulateAmmoListView();

			UpdateAmmoTabButtons();
			}

		//============================================================================*
		// OnAmmoPrintCheckedClicked()
		//============================================================================*

		protected void OnAmmoPrintCheckedClicked(object sender, EventArgs args)
			{
			AmmoPrintCheckedRadioButton.Checked = !AmmoPrintCheckedRadioButton.Checked;
			AmmoPrintAllRadioButton.Checked = !AmmoPrintCheckedRadioButton.Checked;

			m_DataFiles.Preferences.AmmoPrintAll = AmmoPrintAllRadioButton.Checked;
			m_DataFiles.Preferences.AmmoPrintChecked = AmmoPrintCheckedRadioButton.Checked;

			UpdateAmmoTabButtons();
			}

		//============================================================================*
		// OnAmmoFactoryFilterClicked()
		//============================================================================*

		protected void OnAmmoFactoryFilterClicked(object sender, EventArgs args)
			{
			m_DataFiles.Preferences.AmmoFactoryFilter = AmmoFactoryCheckBox.Checked;

			PopulateAmmoListView();

			UpdateAmmoTabButtons();
			}

		//============================================================================*
		// OnAmmoFactoryReloadsFilterClicked()
		//============================================================================*

		protected void OnAmmoFactoryReloadsFilterClicked(object sender, EventArgs args)
			{
			m_DataFiles.Preferences.AmmoFactoryReloadFilter = AmmoFactoryReloadsCheckBox.Checked;

			PopulateAmmoListView();

			UpdateAmmoTabButtons();
			}

		//============================================================================*
		// OnAmmoNonZeroFilterClicked()
		//============================================================================*

		protected void OnAmmoNonZeroFilterClicked(object sender, EventArgs args)
			{
			m_DataFiles.Preferences.AmmoNonZeroFilter = AmmoNonZeroCheckBox.Checked;

			PopulateAmmoListView();

			UpdateAmmoTabButtons();
			}

		//============================================================================*
		// OnAmmoDoubleClicked()
		//============================================================================*

		protected void OnAmmoDoubleClicked(object sender, EventArgs args)
			{
			try
				{
				m_DataFiles.Preferences.LastAmmoSelected = (cAmmo) (sender as ListView).SelectedItems[0].Tag;
				}
			catch
				{
				// No need to do anything here
				}

			OnEditAmmo(sender, args);

			UpdateButtons();
			}

		//============================================================================*
		// OnAmmoSelected()
		//============================================================================*

		protected void OnAmmoSelected(object sender, EventArgs args)
			{
			if (!m_fInitialized || m_AmmoListView.Populating)
				return;

			if ((sender as cAmmoListView).SelectedItems.Count > 0)
				m_DataFiles.Preferences.LastAmmoSelected = (cAmmo) (sender as ListView).SelectedItems[0].Tag;

			UpdateAmmoTabButtons();
			}

		//============================================================================*
		// OnEditAmmo()
		//============================================================================*

		protected void OnEditAmmo(object sender, EventArgs args)
			{
			//----------------------------------------------------------------------------*
			// Get the selected Firearm
			//----------------------------------------------------------------------------*

			ListViewItem Item = m_AmmoListView.SelectedItems[0];

			if (Item == null)
				return;

			cAmmo Ammo = (cAmmo) Item.Tag;

			if (Ammo == null)
				return;

			//----------------------------------------------------------------------------*
			// Start the dialog
			//----------------------------------------------------------------------------*

			Cursor = Cursors.WaitCursor;

			cAmmoForm AmmoForm = new cAmmoForm(Ammo, m_DataFiles);

			Cursor = Cursors.Default;

			if (AmmoForm.ShowDialog() == DialogResult.OK)
				{
				//----------------------------------------------------------------------------*
				// Get the new Firearm Data
				//----------------------------------------------------------------------------*

				cAmmo NewAmmo = AmmoForm.Ammo;
				m_DataFiles.Preferences.LastAmmo = AmmoForm.Ammo;

				UpdateAmmo(Ammo, NewAmmo);
				}

			m_AmmoListView.Focus();
			}

		//============================================================================*
		// OnAmmoMyReloadsFilterClicked()
		//============================================================================*

		protected void OnAmmoMyReloadsFilterClicked(object sender, EventArgs args)
			{
			m_DataFiles.Preferences.AmmoMyReloadFilter = AmmoMyReloadsCheckBox.Checked;

			PopulateAmmoListView();

			UpdateAmmoTabButtons();
			}

		//============================================================================*
		// OnPrintAmmoListClicked()
		//============================================================================*

		protected void OnPrintAmmoListClicked(object sender, EventArgs args)
			{
			//----------------------------------------------------------------------------*
			// Show the dialog
			//----------------------------------------------------------------------------*

			cAmmoListPreviewDialog AmmoListDialog = new cAmmoListPreviewDialog(m_DataFiles, m_AmmoListView);

			AmmoListDialog.ShowDialog();
			}

		//============================================================================*
		// OnRemoveAmmo()
		//============================================================================*

		protected void OnRemoveAmmo(object sender, EventArgs args)
			{
			cAmmo Ammo = null;

			ListViewItem Item = m_AmmoListView.SelectedItems[0];

			if (Item != null)
				Ammo = (cAmmo) Item.Tag;

			if (Ammo == null)
				{
				m_AmmoListView.Focus();

				return;
				}

			//----------------------------------------------------------------------------*
			// Make sure the user is sure
			//----------------------------------------------------------------------------*

			if (MessageBox.Show(this, "Are you sure you wish to remove this ammo?", "Data Deletion Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
				{
				m_DataFiles.DeleteAmmo(Ammo);

				m_AmmoListView.Items.Remove(Item);
				}

			UpdateButtons();

			m_AmmoListView.Focus();
			}

		//============================================================================*
		// OnViewAmmo()
		//============================================================================*

		protected void OnViewAmmo(object sender, EventArgs args)
			{
			//----------------------------------------------------------------------------*
			// Get the selected object
			//----------------------------------------------------------------------------*

			ListViewItem Item = m_AmmoListView.SelectedItems[0];

			if (Item == null)
				return;

			cAmmo Ammo = (cAmmo) Item.Tag;

			if (Ammo == null)
				return;

			//----------------------------------------------------------------------------*
			// Start the dialog
			//----------------------------------------------------------------------------*

			Cursor = Cursors.WaitCursor;

			cAmmoForm AmmoForm = new cAmmoForm(Ammo, m_DataFiles, true);

			Cursor = Cursors.Default;

			AmmoForm.ShowDialog();

			m_AmmoListView.Focus();
			}

		//============================================================================*
		// PopulateAmmoCaliberCombo()
		//============================================================================*

		public void PopulateAmmoCaliberCombo()
			{
			List<string> StringList = new List<string>();

			foreach (cAmmo Ammo in m_DataFiles.AmmoList)
				{
				cCaliber.CurrentFirearmType = Ammo.FirearmType;

				if (StringList.IndexOf(Ammo.Caliber.ToString()) >= 0)
					continue;

				bool fOK = false;

				switch (AmmunitionFirearmTypeCombo.Text)
					{
					case "Handgun":
						if (Ammo.FirearmType == cFirearm.eFireArmType.Handgun)
							fOK = true;
						break;

					case "Rifle":
						if (Ammo.FirearmType == cFirearm.eFireArmType.Rifle)
							fOK = true;
						break;

					default:
						fOK = true;
						break;
					}

				if (fOK)
					StringList.Add(Ammo.Caliber.ToString());
				}

			m_fAmmoPopulating = true;

			AmmunitionCaliberCombo.Items.Clear();

			AmmunitionCaliberCombo.Items.Add("Any Caliber");

			StringList.Sort();

			foreach (string strString in StringList)
				AmmunitionCaliberCombo.Items.Add(strString);

			AmmunitionCaliberCombo.SelectedIndex = 0;

			m_fAmmoPopulating = false;

			PopulateAmmoManufacturerCombo();
			}

		//============================================================================*
		// PopulateAmmoListView()
		//============================================================================*

		public void PopulateAmmoListView()
			{
			m_fAmmoPopulating = true;

			m_AmmoListView.FirearmType = (cFirearm.eFireArmType) AmmunitionFirearmTypeCombo.SelectedIndex - 1;
			m_AmmoListView.Caliber = AmmunitionCaliberCombo.SelectedIndex > 0 ? m_DataFiles.GetCaliberByName(AmmunitionCaliberCombo.SelectedItem.ToString()) : null;
			m_AmmoListView.Manufacturer = AmmunitionManufacturerCombo.SelectedIndex > 0 ? m_DataFiles.GetManufacturerByName(AmmunitionManufacturerCombo.SelectedItem.ToString()) : null;

			m_AmmoListView.Populate();

			m_fAmmoPopulating = false;

			UpdateAmmoTabButtons();
			}

		//============================================================================*
		// PopulateAmmoListViewColumns()
		//============================================================================*

		public void PopulateAmmoListViewColumns()
			{
			m_AmmoListView.PopulateColumns();

			PopulateAmmoListView();
			}

		//============================================================================*
		// PopulateAmmoManufacturerCombo()
		//============================================================================*

		public void PopulateAmmoManufacturerCombo()
			{
			List<string> StringList = new List<string>();

			foreach (cAmmo Ammo in m_DataFiles.AmmoList)
				{
				cCaliber.CurrentFirearmType = Ammo.FirearmType;

				if (StringList.IndexOf(Ammo.Manufacturer.ToString()) >= 0)
					continue;

				bool fOK = false;

				switch (AmmunitionFirearmTypeCombo.Text)
					{
					case "Handgun":
						if (Ammo.FirearmType == cFirearm.eFireArmType.Handgun)
							fOK = true;
						break;

					case "Rifle":
						if (Ammo.FirearmType == cFirearm.eFireArmType.Rifle)
							fOK = true;
						break;

					case "Shotgun":
						if (Ammo.FirearmType == cFirearm.eFireArmType.Shotgun)
							fOK = true;
						break;

					default:
						fOK = true;
						break;
					}

				if (fOK)
					{
					if (AmmunitionCaliberCombo.Text != "Any Caliber")
						fOK = AmmunitionCaliberCombo.Text == Ammo.Caliber.ToString();
					}

				if (fOK)
					StringList.Add(Ammo.Manufacturer.ToString());
				}

			m_fAmmoPopulating = true;

			AmmunitionManufacturerCombo.Items.Clear();

			AmmunitionManufacturerCombo.Items.Add("Any Manufacturer");

			StringList.Sort();

			foreach (string strString in StringList)
				AmmunitionManufacturerCombo.Items.Add(strString);

			AmmunitionManufacturerCombo.SelectedIndex = 0;

			m_fAmmoPopulating = false;

			PopulateAmmoListView();
			}

		//============================================================================*
		// PruneReloads()
		//============================================================================*

		private void PruneReloads()
			{
			//----------------------------------------------------------------------------*
			// Prune zero quantity reloads older than 30 days
			//----------------------------------------------------------------------------*

			bool fRemoved = true;

			while (fRemoved)
				{
				fRemoved = false;

				//----------------------------------------------------------------------------*
				// Loop through the ammo list
				//----------------------------------------------------------------------------*

				foreach (cAmmo Ammo in m_DataFiles.AmmoList)
					{
					//----------------------------------------------------------------------------*
					// If the ammo is a reload, and has a zero quantity, look closer
					//----------------------------------------------------------------------------*

					if ((Ammo.Reload || Ammo.BatchID != 0) && m_DataFiles.SupplyQuantity(Ammo) == 0.0)
						{
						bool fCurrent = true;

						//----------------------------------------------------------------------------*
						// Loop through the transactions
						//----------------------------------------------------------------------------*

						foreach (cTransaction Transaction in Ammo.TransactionList)
							{
							fCurrent = false;

							//----------------------------------------------------------------------------*
							// If the transaction is less than 30 days old, mark it as current
							//----------------------------------------------------------------------------*

							TimeSpan Time = DateTime.Today - Transaction.Date;

							if (Time.Days <= m_DataFiles.Preferences.ReloadKeepDays)
								{
								fCurrent = true;

								break;
								}
							}

						//----------------------------------------------------------------------------*
						// If nothing has happened with this ammo in 30 days, remove it
						//----------------------------------------------------------------------------*

						if (!fCurrent)
							{
							m_DataFiles.AmmoList.Remove(Ammo);

							fRemoved = true;

							break;
							}
						}
					}
				}
			}

		//============================================================================*
		// UpdateAmmo()
		//============================================================================*

		private void UpdateAmmo(cAmmo OldAmmo, cAmmo NewAmmo)
			{
			//----------------------------------------------------------------------------*
			// Find the NewFirearm
			//----------------------------------------------------------------------------*

			foreach (cAmmo CheckAmmo in m_DataFiles.AmmoList)
				{
				//----------------------------------------------------------------------------*
				// See if this is the same Ammo
				//----------------------------------------------------------------------------*

				if (CheckAmmo.Equals(OldAmmo))
					{
					//----------------------------------------------------------------------------*
					// Update the current Firearm record
					//----------------------------------------------------------------------------*

					CheckAmmo.Copy(NewAmmo);

					CheckAmmo.RecalculateInventory(m_DataFiles);

					//----------------------------------------------------------------------------*
					// Update the Firearm on the Firearm tab
					//----------------------------------------------------------------------------*

					m_AmmoListView.UpdateAmmo(CheckAmmo, true);

					return;
					}
				}

			//----------------------------------------------------------------------------*
			// If the NewFirearm was not found, add it
			//----------------------------------------------------------------------------*

			AddAmmo(NewAmmo);
			}

		//============================================================================*
		// UpdateAmmoTabButtons()
		//============================================================================*

		public void UpdateAmmoTabButtons()
			{
			//----------------------------------------------------------------------------*
			// Print Buttons
			//----------------------------------------------------------------------------*

			//----------------------------------------------------------------------------*
			// Checked Only Button
			//----------------------------------------------------------------------------*

			if (m_AmmoListView.CheckedItems.Count == 0)
				{
				AmmoPrintCheckedRadioButton.Checked = false;
				AmmoPrintAllRadioButton.Checked = true;
				AmmoPrintCheckedRadioButton.Enabled = false;

				m_DataFiles.Preferences.AmmoPrintAll = true;
				m_DataFiles.Preferences.AmmoPrintChecked = false;
				}
			else
				AmmoPrintCheckedRadioButton.Enabled = true;

			//----------------------------------------------------------------------------*
			// Print Button
			//----------------------------------------------------------------------------*

			if (m_AmmoListView.Items.Count == 0)
				{
				AmmoListPrintButton.Enabled = false;

				NoAmmoListLabel.Visible = true;
				}
			else
				{
				AmmoListPrintButton.Enabled = true;

				NoAmmoListLabel.Visible = false;
				}

			//----------------------------------------------------------------------------*
			// Edit, View, Remove Buttons
			//----------------------------------------------------------------------------*

			if (m_AmmoListView.SelectedItems.Count > 0)
				{
				cAmmo Ammo = (cAmmo) m_AmmoListView.SelectedItems[0].Tag;

				EditAmmoButton.Enabled = Ammo.Manufacturer != null && Ammo.BatchID == 0;
				ViewAmmoButton.Enabled = true;
				RemoveAmmoButton.Enabled = Ammo.Manufacturer != null && Ammo.BatchID == 0;
				}
			else
				{
				EditAmmoButton.Enabled = false;
				ViewAmmoButton.Enabled = false;
				RemoveAmmoButton.Enabled = false;
				}
			}
		}
	}
