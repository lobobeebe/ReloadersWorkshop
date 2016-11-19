//============================================================================*
// cMainForm.LoadDataTab.cs
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

		private cBatchListView m_BatchListView = null;

		private bool m_fBatchTabInitialized = false;

		//============================================================================*
		// AddBatch()
		//============================================================================*

		private void AddBatch(cBatch Batch)
			{
			//----------------------------------------------------------------------------*
			// If the Batch already exists, update the existing one and exit
			//----------------------------------------------------------------------------*

			foreach (cBatch CheckBatch in m_DataFiles.BatchList)
				{
				if (CheckBatch.CompareTo(Batch) == 0)
					{
					UpdateBatch(CheckBatch, Batch);

					return;
					}
				}

			//----------------------------------------------------------------------------*
			// Add the new batch to the list
			//----------------------------------------------------------------------------*

			m_DataFiles.BatchList.Add(Batch);

			if (Batch.TrackInventory)
				CreateBatchTransactions(Batch);

			//----------------------------------------------------------------------------*
			// Add the new Batch to the Batch and Ballistics tab
			//----------------------------------------------------------------------------*

			BatchFirearmTypeCombo.SelectedIndex = (int)Batch.Load.FirearmType;

			cCaliber.CurrentFirearmType = Batch.Load.FirearmType;

			if (!Batch.Archived)
				m_BatchListView.AddBatch(Batch,
										BatchFirearmTypeCombo.Value,
										BatchCaliberCombo.SelectedIndex > 0 ? (BatchCaliberCombo.SelectedItem as cCaliber) : null,
										BatchBulletCombo.SelectedIndex > 0 ? (BatchBulletCombo.SelectedItem as cBullet) : null,
										BatchPowderCombo.SelectedIndex > 0 ? (BatchPowderCombo.SelectedItem as cPowder) : null,
										true);

			PopulateBallisticsBatchCombo();
			PopulateBatchListView();

			//----------------------------------------------------------------------------*
			// Set focus to the add batch button and exit
			//----------------------------------------------------------------------------*

			AddBatchButton.Focus();
			}

		//============================================================================*
		// CreateBatchTransaction()
		//============================================================================*

		private void CreateBatchTransactions(cBatch Batch)
			{
			//----------------------------------------------------------------------------*
			// Base Transaction Data
			//----------------------------------------------------------------------------*

			cTransaction Transaction = new cTransaction();

			Transaction.AutoTrans = true;
			Transaction.BatchID = Batch.BatchID;
			Transaction.Date = Batch.DateLoaded;
			Transaction.Quantity = Batch.NumRounds;
			Transaction.Source = String.Format("Batch {0:G0}", Batch.BatchID);
			Transaction.TransactionType = cTransaction.eTransactionType.ReduceStock;

			//----------------------------------------------------------------------------*
			// Bullet
			//----------------------------------------------------------------------------*

			Transaction.Cost = m_DataFiles.SupplyCostEach(Batch.Load.Bullet) * Batch.NumRounds;
			Transaction.Supply = Batch.Load.Bullet;

			Batch.Load.Bullet.TransactionList.Add(Transaction);

			Batch.Load.Bullet.RecalculateInventory(m_DataFiles);

			//----------------------------------------------------------------------------*
			// Case
			//----------------------------------------------------------------------------*

			cTransaction CaseTransaction = new cTransaction(Transaction);

			CaseTransaction.Cost = m_DataFiles.SupplyCostEach(Batch.Load.Case) * Batch.NumRounds;
			CaseTransaction.Supply = Batch.Load.Case;

			Batch.Load.Case.TransactionList.Add(CaseTransaction);

			Batch.Load.Case.RecalculateInventory(m_DataFiles);

			//----------------------------------------------------------------------------*
			// Primer
			//----------------------------------------------------------------------------*

			cTransaction PrimerTransaction = new cTransaction(Transaction);

			PrimerTransaction.Cost = m_DataFiles.SupplyCostEach(Batch.Load.Primer) * Batch.NumRounds;
			PrimerTransaction.Supply = Batch.Load.Primer;

			Batch.Load.Primer.TransactionList.Add(PrimerTransaction);

			Batch.Load.Primer.RecalculateInventory(m_DataFiles);

			//----------------------------------------------------------------------------*
			// Powder
			//----------------------------------------------------------------------------*

			cTransaction PowderTransaction = new cTransaction(Transaction);

			PowderTransaction.Cost = m_DataFiles.SupplyCostEach(Batch.Load.Powder) * (Batch.NumRounds * Batch.PowderWeight);
			PowderTransaction.Supply = Batch.Load.Powder;
			PowderTransaction.Quantity = Batch.PowderWeight * Batch.NumRounds;

			Batch.Load.Powder.TransactionList.Add(PowderTransaction);

			Batch.Load.Powder.RecalculateInventory(m_DataFiles);

			//----------------------------------------------------------------------------*
			// Create an Ammo object if necessary
			//----------------------------------------------------------------------------*

			if (m_DataFiles.Preferences.TrackReloads)
				{
				cAmmo Ammo = new cAmmo(m_DataFiles.BatchManufacturer, Batch);

				m_DataFiles.AmmoList.Add(Ammo);

				m_DataFiles.AmmoList.Sort();

				cTransaction AmmoTransaction = new cTransaction(Transaction);

				AmmoTransaction.TransactionType = cTransaction.eTransactionType.SetStockLevel;
				AmmoTransaction.Cost = m_DataFiles.BatchCartridgeCost(Batch) * Batch.NumRounds;
				AmmoTransaction.Supply = Ammo;

				Ammo.TransactionList.Add(AmmoTransaction);

				Ammo.RecalculateInventory(m_DataFiles);
				}

			//----------------------------------------------------------------------------*
			// Redraw the affected tabs
			//----------------------------------------------------------------------------*

			InitializeAmmoTab();
			InitializeSuppliesTab();
			InitializeBatchTab();
			InitializeBallisticsTab();
			}

		//============================================================================*
		// InitializeBatchTab()
		//============================================================================*

		public void InitializeBatchTab()
			{
			if (!m_fBatchTabInitialized)
				{
				m_BatchListView = new cBatchListView(m_DataFiles);

				BatchEditorTab.Controls.Add(m_BatchListView);

				m_BatchListView.SelectedIndexChanged += OnBatchSelected;
				m_BatchListView.DoubleClick += OnBatchDoubleClicked;
				m_BatchListView.ItemChecked += OnBatchChecked;

				BatchFirearmTypeCombo.SelectedIndexChanged += OnBatchFirearmTypeSelected;
				BatchBulletCombo.SelectedIndexChanged += OnBatchBulletSelected;
				BatchCaliberCombo.SelectedIndexChanged += OnBatchCaliberSelected;
				BatchPowderCombo.SelectedIndexChanged += OnBatchPowderSelected;

				ArchiveCheckedButton.Click += OnArchiveChecked;
				UnarchiveCheckedButton.Click += OnUnarchiveChecked;

				PrintCheckedBatchLabelsButton.Click += OnPrintCheckedBatchLabelsClicked;

				ShowArchivedBatchesCheckBox.Click += OnShowArchivedBatchesClicked;

				AddBatchButton.Click += OnAddBatch;
				EditBatchButton.Click += OnEditBatch;
				RemoveBatchButton.Click += OnRemoveBatch;
				ViewBatchButton.Click += OnViewBatch;

				m_fBatchTabInitialized = true;
				}

			//----------------------------------------------------------------------------*
			// Operations that are always performed
			//----------------------------------------------------------------------------*

			PopulateBatchTab();
			}

		//============================================================================*
		// OnAddBatch()
		//============================================================================*

		protected void OnAddBatch(object sender, EventArgs args)
			{
			//----------------------------------------------------------------------------*
			// Start the dialog
			//----------------------------------------------------------------------------*

			cBatchForm BatchForm = new cBatchForm(null, m_DataFiles, m_RWRegistry, BatchFirearmTypeCombo.Value);

			if (BatchForm.ShowDialog() == DialogResult.OK)
				{
				//----------------------------------------------------------------------------*
				// Get the new Load Data
				//----------------------------------------------------------------------------*

				cBatch NewBatch = new cBatch(BatchForm.Batch);

				m_DataFiles.Preferences.LastBatch = BatchForm.Batch;

				AddBatch(NewBatch);

				InitializeBallisticsTab();

				PopulateBatchTab();
				}

			UpdateBatchTabButtons();
			}

		//============================================================================*
		// OnArchiveChecked()
		//============================================================================*

		protected void OnArchiveChecked(object sender, EventArgs args)
			{
			if (m_BatchListView.CheckedItems.Count > 0)
				{
				foreach (ListViewItem Item in m_BatchListView.CheckedItems)
					{
					cBatch Batch = (cBatch)Item.Tag;

					if (Batch != null)
						{
						Batch.Archived = true;
						}
					}
				}

			PopulateBatchListView();
			}

		//============================================================================*
		// OnBatchBulletSelected()
		//============================================================================*

		protected void OnBatchBulletSelected(Object sender, EventArgs args)
			{
			if (!m_fInitialized || m_fPopulating)
				return;

			if (BatchBulletCombo.SelectedIndex > 0)
				m_DataFiles.Preferences.LastBatchBulletSelected = (cBullet)BatchBulletCombo.SelectedItem;
			else
				m_DataFiles.Preferences.LastBatchBulletSelected = null;

			PopulateBatchPowderCombo();
			}

		//============================================================================*
		// OnBatchCaliberSelected()
		//============================================================================*

		protected void OnBatchCaliberSelected(Object sender, EventArgs args)
			{
			if (!m_fInitialized || m_fPopulating)
				return;

			if (BatchCaliberCombo.SelectedIndex > 0)
				m_DataFiles.Preferences.LastBatchCaliberSelected = (cCaliber)BatchCaliberCombo.SelectedItem;
			else
				m_DataFiles.Preferences.LastBatchCaliberSelected = null;

			PopulateBatchBulletCombo();
			}

		//============================================================================*
		// OnBatchChecked()
		//============================================================================*

		protected void OnBatchChecked(object sender, ItemCheckedEventArgs args)
			{
			if (!m_fInitialized || m_fPopulating)
				return;

			cBatch Batch = (cBatch)args.Item.Tag;

			Batch.Checked = args.Item.Checked;

			UpdateBatchTabButtons();
			}

		//============================================================================*
		// OnBatchDoubleClicked()
		//============================================================================*

		protected void OnBatchDoubleClicked(object sender, EventArgs args)
			{
			if (m_BatchListView.SelectedItems.Count > 0)
				{
				m_DataFiles.Preferences.LastBatchSelected = (cBatch)m_BatchListView.SelectedItems[0].Tag;
				}

			OnEditBatch(sender, args);

			PopulateBallisticsBatchCombo();
			}

		//============================================================================*
		// OnBatchFirearmTypeSelected()
		//============================================================================*

		protected void OnBatchFirearmTypeSelected(Object sender, EventArgs args)
			{
			if (!m_fInitialized || m_fPopulating)
				return;

			m_DataFiles.Preferences.BatchEditorFirearmType = BatchFirearmTypeCombo.Value;

			PopulateBatchCaliberCombo();
			}

		//============================================================================*
		// OnBatchPowderSelected()
		//============================================================================*

		protected void OnBatchPowderSelected(Object sender, EventArgs args)
			{
			if (!m_fInitialized || m_fPopulating)
				return;

			if (BatchPowderCombo.SelectedIndex > 0)
				m_DataFiles.Preferences.LastBatchPowderSelected = (cPowder)BatchPowderCombo.SelectedItem;
			else
				m_DataFiles.Preferences.LastBatchPowderSelected = null;

			PopulateBatchListView();
			}

		//============================================================================*
		// OnBatchSelected()
		//============================================================================*

		protected void OnBatchSelected(object sender, EventArgs args)
			{
			if (!m_fInitialized || m_fPopulating)
				return;

			if (m_BatchListView.SelectedItems.Count > 0)
				m_DataFiles.Preferences.LastBatchSelected = (cBatch)m_BatchListView.SelectedItems[0].Tag;

			UpdateBatchTabButtons();
			}

		//============================================================================*
		// OnEditBatch()
		//============================================================================*

		protected void OnEditBatch(object sender, EventArgs args)
			{
			//----------------------------------------------------------------------------*
			// Get the selected Batch
			//----------------------------------------------------------------------------*

			ListViewItem Item = m_BatchListView.SelectedItems[0];

			if (Item == null)
				return;

			cBatch Batch = (cBatch)Item.Tag;

			if (Batch == null)
				return;

			//----------------------------------------------------------------------------*
			// Start the dialog
			//----------------------------------------------------------------------------*

			cBatchForm BatchForm = new cBatchForm(Batch, m_DataFiles, m_RWRegistry);

			if (BatchForm.ShowDialog() == DialogResult.OK)
				{
				//----------------------------------------------------------------------------*
				// Get the new Batch Data
				//----------------------------------------------------------------------------*

				cBatch NewBatch = BatchForm.Batch;

				m_DataFiles.Preferences.LastBatch = BatchForm.Batch;

				UpdateBatch(Batch, NewBatch);

				InitializeBallisticsTab();
				}

			UpdateBatchTabButtons();
			}

		//============================================================================*
		// OnPrintCheckedBatchLabelsClicked()
		//============================================================================*

		protected void OnPrintCheckedBatchLabelsClicked(object sender, EventArgs args)
			{
			cBatchList BatchList = new cBatchList();

			for (int i = 0;i < m_BatchListView.CheckedItems.Count;i++)
				{
				cBatch Batch = (m_BatchListView.CheckedItems[i].Tag as cBatch);

				if (Batch != null)
					BatchList.Add(Batch);
				}

			if (BatchList.Count > 0)
				{
				cBatchPrintForm BatchPrintForm = new cBatchPrintForm(BatchList, m_DataFiles);

				BatchPrintForm.ShowDialog();
				}
			}

		//============================================================================*
		// OnRemoveBatch()
		//============================================================================*

		protected void OnRemoveBatch(object sender, EventArgs args)
			{
			cBatch Batch = null;

			ListViewItem Item = null;

			if (m_BatchListView.SelectedItems.Count > 0)
				Item = m_BatchListView.SelectedItems[0];

			if (Item != null)
				Batch = (cBatch)Item.Tag;

			if (Batch == null)
				{
				m_BatchListView.Focus();

				return;
				}

			//----------------------------------------------------------------------------*
			// Make sure the user is sure
			//----------------------------------------------------------------------------*

			if (MessageBox.Show(this, "Are you sure you wish to remove this batch?", "Data Deletion Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
				{
				RemoveBatchTransactions(Batch);

				m_DataFiles.DeleteBatch(Batch);

				m_BatchListView.Items.Remove(Item);

				m_DataFiles.SetNextBatchID();

				InitializeSuppliesTab();
				InitializeLoadDataTab();
				InitializeBatchTab();
				InitializeBallisticsTab();
				InitializeAmmoTab();

				UpdateBatchTabButtons();
				}

			UpdateBatchTabButtons();
			}

		//============================================================================*
		// OnShowArchivedBatchesClicked()
		//============================================================================*

		protected void OnShowArchivedBatchesClicked(object sender, EventArgs args)
			{
			ShowArchivedBatchesCheckBox.Checked = !ShowArchivedBatchesCheckBox.Checked;

			m_DataFiles.Preferences.ShowArchivedBatches = ShowArchivedBatchesCheckBox.Checked;

			PopulateBatchListView();
			}

		//============================================================================*
		// OnUnarchiveChecked()
		//============================================================================*

		protected void OnUnarchiveChecked(object sender, EventArgs args)
			{
			if (m_BatchListView.CheckedItems.Count > 0)
				{
				foreach (ListViewItem Item in m_BatchListView.CheckedItems)
					{
					cBatch Batch = (cBatch)Item.Tag;

					if (Batch != null)
						Batch.Archived = false;
					}

				}

			PopulateBatchListView();
			}

		//============================================================================*
		// OnViewBatch()
		//============================================================================*

		protected void OnViewBatch(object sender, EventArgs args)
			{
			//----------------------------------------------------------------------------*
			// Get the selected Batch
			//----------------------------------------------------------------------------*

			ListViewItem Item = m_BatchListView.SelectedItems[0];

			if (Item == null)
				return;

			cBatch Batch = (cBatch)Item.Tag;

			if (Batch == null)
				return;

			//----------------------------------------------------------------------------*
			// Start the dialog
			//----------------------------------------------------------------------------*

			cBatchForm BatchForm = new cBatchForm(Batch, m_DataFiles, m_RWRegistry, cFirearm.eFireArmType.None, true);

			BatchForm.ShowDialog();

			m_BatchListView.Focus();
			}

		//============================================================================*
		// PopulateBatchBulletCombo()
		//============================================================================*

		private void PopulateBatchBulletCombo()
			{
			m_fPopulating = true;

			BatchBulletCombo.Items.Clear();

			cCaliber Caliber = null;

			if (BatchCaliberCombo.SelectedIndex > 0)
				Caliber = (cCaliber)BatchCaliberCombo.SelectedItem;

			cBullet SelectBullet = null;

			BatchBulletCombo.Items.Add("Any Bullet");

			foreach (cBullet CheckBullet in m_DataFiles.BulletList)
				{
				cCaliber.CurrentFirearmType = CheckBullet.FirearmType;

				if (CheckBullet.FirearmType == BatchFirearmTypeCombo.Value)
					{
					bool fBulletUsed = false;

					foreach (cBatch Batch in m_DataFiles.BatchList)
						{
						if ((m_DataFiles.Preferences.ShowArchivedBatches || !Batch.Archived) &&
							(Caliber == null || Batch.Load.Caliber.CompareTo(Caliber) == 0) &&
							(Batch.Load.Bullet.CompareTo(CheckBullet) == 0))
							{
							fBulletUsed = true;

							break;
							}
						}

					if (fBulletUsed)
						{
						BatchBulletCombo.Items.Add(CheckBullet);

						if (CheckBullet.CompareTo(m_DataFiles.Preferences.LastBatchBulletSelected) == 0)
							SelectBullet = CheckBullet;
						}
					}
				}

			if (SelectBullet != null)
				BatchBulletCombo.SelectedItem = SelectBullet;
			else
				{
				if (BatchBulletCombo.Items.Count > 0)
					BatchBulletCombo.SelectedIndex = 0;
				}

			m_fPopulating = false;

			PopulateBatchPowderCombo();
			}

		//============================================================================*
		// PopulateBatchCaliberCombo()
		//============================================================================*

		private void PopulateBatchCaliberCombo()
			{
			m_fPopulating = true;

			BatchCaliberCombo.Items.Clear();

			BatchCaliberCombo.Items.Add("Any Caliber");

			cCaliber SelectCaliber = null;

			foreach (cCaliber CheckCaliber in m_DataFiles.CaliberList)
				{
				if (CheckCaliber.FirearmType == BatchFirearmTypeCombo.Value)
					{
					bool fCaliberUsed = false;

					foreach (cBatch Batch in m_DataFiles.BatchList)
						{
						if ((m_DataFiles.Preferences.ShowArchivedBatches || !Batch.Archived) &&
							Batch.Load.Caliber.CompareTo(CheckCaliber) == 0)
							{
							fCaliberUsed = true;

							break;
							}
						}

					if (fCaliberUsed)
						{
						cCaliber.CurrentFirearmType = CheckCaliber.FirearmType;

						BatchCaliberCombo.Items.Add(CheckCaliber);

						if (CheckCaliber.CompareTo(m_DataFiles.Preferences.LastBatchCaliberSelected) == 0)
							SelectCaliber = CheckCaliber;
						}
					}
				}

			if (SelectCaliber != null)
				BatchCaliberCombo.SelectedItem = SelectCaliber;
			else
				{
				if (BatchCaliberCombo.Items.Count > 0)
					BatchCaliberCombo.SelectedIndex = 0;
				}

			m_fPopulating = false;

			PopulateBatchBulletCombo();
			}

		//============================================================================*
		// PopulateBatchListView()
		//============================================================================*

		public void PopulateBatchListView()
			{
			m_fPopulating = true;

			m_BatchListView.Populate(BatchFirearmTypeCombo.Value,
									BatchCaliberCombo.SelectedIndex > 0 ? (BatchCaliberCombo.SelectedItem as cCaliber) : null,
									BatchBulletCombo.SelectedIndex > 0 ? (BatchBulletCombo.SelectedItem as cBullet) : null,
									BatchPowderCombo.SelectedIndex > 0 ? (BatchPowderCombo.SelectedItem as cPowder) : null);

			m_fPopulating = false;

			UpdateBatchTabButtons();
			}

		//============================================================================*
		// PopulateBatchPowderCombo()
		//============================================================================*

		private void PopulateBatchPowderCombo()
			{
			m_fPopulating = true;

			BatchPowderCombo.Items.Clear();

			cPowder SelectPowder = null;

			BatchPowderCombo.Items.Add("Any Powder");

			foreach (cPowder CheckPowder in m_DataFiles.PowderList)
				{
				if (CheckPowder.FirearmType == BatchFirearmTypeCombo.Value)
					{
					bool fPowderUsed = false;

					foreach (cBatch Batch in m_DataFiles.BatchList)
						{
						if ((m_DataFiles.Preferences.ShowArchivedBatches || !Batch.Archived) &&
							(BatchCaliberCombo.SelectedIndex <= 0 || (BatchCaliberCombo.SelectedItem as cCaliber).CompareTo(Batch.Load.Caliber) == 0) &&
							(BatchBulletCombo.SelectedIndex <= 0 || (BatchBulletCombo.SelectedItem as cBullet).CompareTo(Batch.Load.Bullet) == 0) &&
							(Batch.Load.Powder.CompareTo(CheckPowder) == 0))
							{
							fPowderUsed = true;

							break;
							}
						}

					if (fPowderUsed)
						{
						cCaliber.CurrentFirearmType = CheckPowder.FirearmType;

						BatchPowderCombo.Items.Add(CheckPowder);

						if (CheckPowder.CompareTo(m_DataFiles.Preferences.LastBatchPowderSelected) == 0)
							SelectPowder = CheckPowder;
						}
					}
				}

			if (SelectPowder != null)
				BatchPowderCombo.SelectedItem = SelectPowder;
			else
				{
				if (BatchPowderCombo.Items.Count > 0)
					BatchPowderCombo.SelectedIndex = 0;
				}

			m_fPopulating = false;

			PopulateBatchListView();
			}

		//============================================================================*
		// PopulateBatchTab()
		//============================================================================*

		private void PopulateBatchTab()
			{
			m_fPopulating = true;

			//----------------------------------------------------------------------------*
			// ShowArchivedBachesComboBox
			//----------------------------------------------------------------------------*

			ShowArchivedBatchesCheckBox.Checked = m_DataFiles.Preferences.ShowArchivedBatches;

			//----------------------------------------------------------------------------*
			// BatchFirearmTypeCombo
			//----------------------------------------------------------------------------*

			BatchFirearmTypeCombo.Value = m_DataFiles.Preferences.BatchEditorFirearmType;

			//----------------------------------------------------------------------------*
			// Start the chain of combo box population
			//----------------------------------------------------------------------------*

			m_fPopulating = false;

			PopulateBatchCaliberCombo();
			}

		//============================================================================*
		// RedrawBatchListView()
		//============================================================================*

		public void RedrawBatchListView()
			{
			m_BatchListView.RedrawItems(m_BatchListView.TopItem.Index, m_BatchListView.Items.Count - m_BatchListView.TopItem.Index - 1, false);

			UpdateBatchTabButtons();
			}

		//============================================================================*
		// RemoveBatchTransactions()
		//============================================================================*

		private void RemoveBatchTransactions(cBatch Batch)
			{
			//----------------------------------------------------------------------------*
			// Bullet Transactions
			//----------------------------------------------------------------------------*

			foreach (cTransaction Transaction in Batch.Load.Bullet.TransactionList)
				{
				if (Transaction.BatchID == Batch.BatchID)
					{
					Batch.Load.Bullet.TransactionList.Remove(Transaction);

					Batch.Load.Bullet.RecalculateInventory(m_DataFiles);

					break;
					}
				}

			//----------------------------------------------------------------------------*
			// Case Transactions
			//----------------------------------------------------------------------------*

			foreach (cTransaction Transaction in Batch.Load.Case.TransactionList)
				{
				if (Transaction.BatchID == Batch.BatchID)
					{
					Batch.Load.Case.TransactionList.Remove(Transaction);

					Batch.Load.Case.RecalculateInventory(m_DataFiles);

					break;
					}
				}

			//----------------------------------------------------------------------------*
			// Powder Transactions
			//----------------------------------------------------------------------------*

			foreach (cTransaction Transaction in Batch.Load.Powder.TransactionList)
				{
				if (Transaction.BatchID == Batch.BatchID)
					{
					Batch.Load.Powder.TransactionList.Remove(Transaction);

					Batch.Load.Powder.RecalculateInventory(m_DataFiles);

					break;
					}
				}

			//----------------------------------------------------------------------------*
			// Primer Transactions
			//----------------------------------------------------------------------------*

			foreach (cTransaction Transaction in Batch.Load.Primer.TransactionList)
				{
				if (Transaction.BatchID == Batch.BatchID)
					{
					Batch.Load.Primer.TransactionList.Remove(Transaction);

					Batch.Load.Primer.RecalculateInventory(m_DataFiles);

					break;
					}
				}

			//----------------------------------------------------------------------------*
			// Ammo Record
			//----------------------------------------------------------------------------*

			foreach (cAmmo Ammo in m_DataFiles.AmmoList)
				{
				if (Ammo.BatchID == Batch.BatchID)
					{
					m_DataFiles.AmmoList.Remove(Ammo);

					break;
					}
				}
			}

		//============================================================================*
		// UpdateBatch()
		//============================================================================*

		private void UpdateBatch(cBatch OldBatch, cBatch NewBatch)
			{
			//----------------------------------------------------------------------------*
			// Find the NewBatch
			//----------------------------------------------------------------------------*

			foreach (cBatch CheckBatch in m_DataFiles.BatchList)
				{
				//----------------------------------------------------------------------------*
				// See if this is the same Batch
				//----------------------------------------------------------------------------*

				if (CheckBatch.CompareTo(OldBatch) == 0)
					{
					//----------------------------------------------------------------------------*
					// Update the current NewBatch record
					//----------------------------------------------------------------------------*

					bool fTransactionsRemoved = false;

					if ((CheckBatch.TrackInventory && CheckBatch.Load.CompareTo(NewBatch.Load) != 0) || !NewBatch.TrackInventory)
						{
						fTransactionsRemoved = true;

						RemoveBatchTransactions(CheckBatch);
						}

					CheckBatch.Copy(NewBatch);

					//----------------------------------------------------------------------------*
					// Update or Create the new Batch Transactions
					//----------------------------------------------------------------------------*

					if (CheckBatch.TrackInventory)
						{
						if (fTransactionsRemoved)
							CreateBatchTransactions(CheckBatch);
						else
							UpdateBatchTransactions(CheckBatch);
						}

					//----------------------------------------------------------------------------*
					// Update the Batch on the Batch tab
					//----------------------------------------------------------------------------*

					m_BatchListView.UpdateBatch(CheckBatch,
												BatchFirearmTypeCombo.Value,
												BatchCaliberCombo.SelectedIndex > 0 ? (BatchCaliberCombo.SelectedItem as cCaliber) : null,
												BatchBulletCombo.SelectedIndex > 0 ? (BatchBulletCombo.SelectedItem as cBullet) : null,
												BatchPowderCombo.SelectedIndex > 0 ? (BatchPowderCombo.SelectedItem as cPowder) : null,
												true);

					//----------------------------------------------------------------------------*
					// Populate affected tabs
					//----------------------------------------------------------------------------*

					PopulateSuppliesListView();
					PopulateAmmoListView();
					PopulateBallisticsBatchCombo();

					return;
					}
				}

			//----------------------------------------------------------------------------*
			// If the NewLoad was not found, add it
			//----------------------------------------------------------------------------*

			AddBatch(NewBatch);
			}

		//============================================================================*
		// UpdateBatchTabButtons()
		//============================================================================*

		public void UpdateBatchTabButtons()
			{
			//----------------------------------------------------------------------------*
			// Archive Buttons
			//----------------------------------------------------------------------------*

			// Archive and Unarchive Checked

			ArchiveCheckedButton.Enabled = false;
			UnarchiveCheckedButton.Enabled = false;

			foreach (ListViewItem Item in m_BatchListView.CheckedItems)
				{
				cBatch Batch = (cBatch)Item.Tag;

				if (Batch != null)
					{
					if (!Batch.Archived)
						ArchiveCheckedButton.Enabled = true;
					else
						UnarchiveCheckedButton.Enabled = true;
					}

				if (ArchiveCheckedButton.Enabled && UnarchiveCheckedButton.Enabled)
					break;
				}

			// Show Archived

			ShowArchivedBatchesCheckBox.Enabled = false;

			bool fUntrackedBatches = false;

			foreach (cBatch Batch in m_DataFiles.BatchList)
				{
				if (!Batch.TrackInventory)
					fUntrackedBatches = true;

				if (Batch.Archived)
					{
					ShowArchivedBatchesCheckBox.Enabled = true;

					break;
					}
				}

			if (!ShowArchivedBatchesCheckBox.Enabled)
				ShowArchivedBatchesCheckBox.Checked = false;

			//----------------------------------------------------------------------------*
			// Print checked Batches Button
			//----------------------------------------------------------------------------*

			PrintCheckedBatchLabelsButton.Enabled = m_BatchListView.CheckedItems.Count > 0;

			//----------------------------------------------------------------------------*
			// Add Button
			//----------------------------------------------------------------------------*

			AddBatchButton.Enabled = true;

			NoInventoryWarningLabel.Text = "";

			if (cPreferences.TrackInventory)
				{
				bool fEnableAddBatch = false;

				foreach (cLoad Load in m_DataFiles.LoadList)
					{
					if (m_DataFiles.VerifyLoadQuantities(Load))
						{
						fEnableAddBatch = true;

						break;
						}
					}

				AddBatchButton.Enabled = fEnableAddBatch;

				if (!fEnableAddBatch)
					NoInventoryWarningLabel.Text = "NOTE: You do not have enough components in inventory to create a new batch of ammo.  You will need to use the Inventory Activity Editor to add components to your inventory.";
				}
			else
				{
				if (m_DataFiles.LoadList.Count == 0)
					AddBatchButton.Enabled = false;
				}

			//----------------------------------------------------------------------------*
			// Edit, View, Remove Buttons
			//----------------------------------------------------------------------------*

			EditBatchButton.Enabled = m_BatchListView.SelectedItems.Count > 0;
			ViewBatchButton.Enabled = m_BatchListView.SelectedItems.Count > 0;
			RemoveBatchButton.Enabled = m_BatchListView.SelectedItems.Count > 0;

			//----------------------------------------------------------------------------*
			// Inventory Tracking Label
			//----------------------------------------------------------------------------*

			BatchNotTrackedLabel.Visible = cPreferences.TrackInventory && fUntrackedBatches;
			}

		//============================================================================*
		// UpdateBatchTransactions()
		//============================================================================*

		private void UpdateBatchTransactions(cBatch Batch)
			{
			//----------------------------------------------------------------------------*
			// Bullet Transactions
			//----------------------------------------------------------------------------*

			foreach (cTransaction Transaction in Batch.Load.Bullet.TransactionList)
				{
				if (Transaction.BatchID == Batch.BatchID && Transaction.TransactionType == cTransaction.eTransactionType.ReduceStock)
					{
					Transaction.Quantity = Batch.NumRounds;
					Transaction.Cost = m_DataFiles.SupplyCostEach(Batch.Load.Bullet) * Batch.NumRounds;
					Transaction.Supply = Batch.Load.Bullet;

					Batch.Load.Bullet.RecalculateInventory(m_DataFiles);

					break;
					}
				}

			//----------------------------------------------------------------------------*
			// Case Transactions
			//----------------------------------------------------------------------------*

			foreach (cTransaction Transaction in Batch.Load.Case.TransactionList)
				{
				if (Transaction.BatchID == Batch.BatchID && Transaction.TransactionType == cTransaction.eTransactionType.ReduceStock)
					{
					Transaction.Quantity = Batch.NumRounds;
					Transaction.Cost = m_DataFiles.SupplyCostEach(Batch.Load.Case) * Batch.NumRounds;
					Transaction.Supply = Batch.Load.Case;

					Batch.Load.Case.RecalculateInventory(m_DataFiles);

					break;
					}
				}

			//----------------------------------------------------------------------------*
			// Powder Transactions
			//----------------------------------------------------------------------------*

			foreach (cTransaction Transaction in Batch.Load.Powder.TransactionList)
				{
				if (Transaction.BatchID == Batch.BatchID && Transaction.TransactionType == cTransaction.eTransactionType.ReduceStock)
					{
					Transaction.Quantity = Batch.NumRounds * Batch.PowderWeight;
					Transaction.Cost = m_DataFiles.SupplyCostEach(Batch.Load.Powder) * Batch.NumRounds;
					Transaction.Supply = Batch.Load.Powder;

					Batch.Load.Powder.RecalculateInventory(m_DataFiles);

					break;
					}
				}

			//----------------------------------------------------------------------------*
			// Primer Transactions
			//----------------------------------------------------------------------------*

			foreach (cTransaction Transaction in Batch.Load.Primer.TransactionList)
				{
				if (Transaction.BatchID == Batch.BatchID && Transaction.TransactionType == cTransaction.eTransactionType.ReduceStock)
					{
					Transaction.Quantity = Batch.NumRounds;
					Transaction.Cost = m_DataFiles.SupplyCostEach(Batch.Load.Primer) * Batch.NumRounds;
					Transaction.Supply = Batch.Load.Primer;

					Batch.Load.Primer.RecalculateInventory(m_DataFiles);

					break;
					}
				}

			//----------------------------------------------------------------------------*
			// Ammo Transactions
			//----------------------------------------------------------------------------*

			foreach (cAmmo Ammo in m_DataFiles.AmmoList)
				{
				bool fFound = false;

				if (Ammo.BatchID == Batch.BatchID)
					{
					fFound = true;

					Ammo.Type = Batch.Load.Bullet.ToString();

					foreach (cTransaction Transaction in Ammo.TransactionList)
						{
						if (Transaction.TransactionType == cTransaction.eTransactionType.SetStockLevel)
							{
							Transaction.Quantity = Batch.NumRounds;
							Transaction.Cost = Batch.CartridgeCost * Batch.NumRounds;

							Ammo.RecalculateInventory(m_DataFiles);

							break;
							}
						}

					if (fFound)
						break;
					}
				}
			}
		}
	}
