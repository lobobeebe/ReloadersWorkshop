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
	// cMainForm Class
	//============================================================================*

	partial class cMainForm
		{
		//============================================================================*
		// Private Data Members
		//============================================================================*

		cAmmoListView m_AmmoListView = null;

		private bool m_fAmmoTabInitialized = false;

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

				AmmoPrintAllRadioButton.Click += OnAmmoPrintAllClicked;
				AmmoPrintCheckedRadioButton.Click += OnAmmoPrintCheckedClicked;
				AmmoPrintNonZeroCheckBox.Click += OnAmmoPrintNonZeroClicked;
				AmmoPrintBelowStockCheckBox.Click += OnAmmoPrintBelowStockClicked;
				AmmoPrintFactoryOnlyCheckBox.Click += OnAmmoPrintFactoryOnlyClicked;
				AmmoListPrintButton.Click += OnPrintAmmoListClicked;

				AmmoPrintAllRadioButton.Checked = m_DataFiles.Preferences.AmmoPrintAll;
				AmmoPrintCheckedRadioButton.Checked = m_DataFiles.Preferences.AmmoPrintChecked;
				AmmoPrintNonZeroCheckBox.Checked = m_DataFiles.Preferences.AmmoPrintNonZero;
				AmmoPrintBelowStockCheckBox.Checked = m_DataFiles.Preferences.AmmoPrintBelowStock;
				AmmoPrintFactoryOnlyCheckBox.Checked = m_DataFiles.Preferences.AmmoPrintFactoryOnly;

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

			AmmoInventoryGroup.Visible = m_DataFiles.Preferences.TrackInventory;

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
		// OnAmmoPrintBelowStockClicked()
		//============================================================================*

		protected void OnAmmoPrintBelowStockClicked(object sender, EventArgs args)
			{
			AmmoPrintBelowStockCheckBox.Checked = !AmmoPrintBelowStockCheckBox.Checked;

			m_DataFiles.Preferences.AmmoPrintBelowStock = AmmoPrintBelowStockCheckBox.Checked;

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
		// OnAmmoPrintFactoryOnlyClicked()
		//============================================================================*

		protected void OnAmmoPrintFactoryOnlyClicked(object sender, EventArgs args)
			{
			AmmoPrintFactoryOnlyCheckBox.Checked = !AmmoPrintFactoryOnlyCheckBox.Checked;

			m_DataFiles.Preferences.AmmoPrintFactoryOnly = AmmoPrintFactoryOnlyCheckBox.Checked;

			UpdateAmmoTabButtons();
			}

		//============================================================================*
		// OnAmmoPrintNonZeroClicked()
		//============================================================================*

		protected void OnAmmoPrintNonZeroClicked(object sender, EventArgs args)
			{
			AmmoPrintNonZeroCheckBox.Checked = !AmmoPrintNonZeroCheckBox.Checked;

			m_DataFiles.Preferences.AmmoPrintNonZero = AmmoPrintNonZeroCheckBox.Checked;

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
		// OnPrintAmmoListClicked()
		//============================================================================*

		protected void OnPrintAmmoListClicked(object sender, EventArgs args)
			{
			//----------------------------------------------------------------------------*
			// Show the dialog
			//----------------------------------------------------------------------------*

			cAmmoListPreviewDialog AmmoListDialog = new cAmmoListPreviewDialog(m_DataFiles);

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
		// PopulateAmmoListView()
		//============================================================================*

		public void PopulateAmmoListView()
			{
			m_AmmoListView.Populate();

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
		// PruneReloads()
		//============================================================================*

		private void PruneReloads()
			{
			//----------------------------------------------------------------------------*
			// Prune zero quantity reloads older than 30 days
			//----------------------------------------------------------------------------*

			while (true)
				{
				bool fRemoved = false;

				//----------------------------------------------------------------------------*
				// Loop through the ammo list
				//----------------------------------------------------------------------------*

				foreach (cAmmo Ammo in m_DataFiles.AmmoList)
					{
					//----------------------------------------------------------------------------*
					// If the ammo is a reload, and has a zero quantity, look closer
					//----------------------------------------------------------------------------*

					if (Ammo.BatchID != 0 && m_DataFiles.SupplyQuantity(Ammo) == 0.0)
						{
						bool fCurrent = false;

						//----------------------------------------------------------------------------*
						// Loop through the transactions
						//----------------------------------------------------------------------------*

						foreach (cTransaction Transaction in Ammo.TransactionList)
							{
							//----------------------------------------------------------------------------*
							// If the transaction is less than 30 days old, mark it as current
							//----------------------------------------------------------------------------*

							TimeSpan Time = DateTime.Today - Transaction.Date;

							if (Time.Days < 30)
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

				if (!fRemoved)
					break;
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

					CheckAmmo.FirearmType = NewAmmo.FirearmType;
					CheckAmmo.Manufacturer = NewAmmo.Manufacturer;
					CheckAmmo.BatchID = NewAmmo.BatchID;
					CheckAmmo.PartNumber = NewAmmo.PartNumber;
					CheckAmmo.Type = NewAmmo.Type;
					CheckAmmo.Caliber = NewAmmo.Caliber;
					CheckAmmo.BallisticCoefficient = NewAmmo.BallisticCoefficient;
					CheckAmmo.BulletDiameter = NewAmmo.BulletDiameter;
					CheckAmmo.BulletWeight = NewAmmo.BulletWeight;
                    CheckAmmo.Reload = NewAmmo.Reload;
                    CheckAmmo.TestList = NewAmmo.TestList;

					CheckAmmo.TransactionList = new cTransactionList(NewAmmo.TransactionList);

					CheckAmmo.RecalculateInventory(m_DataFiles);

					//----------------------------------------------------------------------------*
					// Set the quantities, costs, etc.
					//----------------------------------------------------------------------------*

					if (m_DataFiles.Preferences.TrackInventory)
						{
						CheckAmmo.QuantityOnHand = NewAmmo.QuantityOnHand;
						CheckAmmo.Quantity = CheckAmmo.QuantityOnHand;
						}
					else
						{
						CheckAmmo.Quantity = NewAmmo.Quantity;
						CheckAmmo.QuantityOnHand = CheckAmmo.Quantity;
						}

					CheckAmmo.Cost = NewAmmo.Cost;

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

			if (m_DataFiles.GetAmmoList().Count == 0)
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
