//============================================================================*
// cMainForm.SuppliesTab.cs
//
// Copyright © 2013-2014, Kevin S. Beebe
// All Rights Reserved
//============================================================================*

//============================================================================*
// .Net Using Statements
//============================================================================*

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
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

		private cSuppliesListView m_SuppliesListView = null;

		private bool m_fSuppliesTabInitialized = false;

		//============================================================================*
		// AddBullet()
		//============================================================================*

		private void AddBullet(cBullet Bullet)
			{
			//----------------------------------------------------------------------------*
			// If the Bullet already exists, update the existing one and exit
			//----------------------------------------------------------------------------*

			foreach (cBullet CheckBullet in m_DataFiles.BulletList)
				{
				if (CheckBullet.CompareTo(Bullet) == 0)
					{
					UpdateBullet(CheckBullet, Bullet);

					return;
					}
				}

			//----------------------------------------------------------------------------*
			// Add the new bullet to the list
			//----------------------------------------------------------------------------*

			m_DataFiles.BulletList.Add(Bullet);
			m_DataFiles.BulletList.Sort();

			SetCommonBulletInfo(Bullet);

			//----------------------------------------------------------------------------*
			// Add the new Bullet to the Supplies tab
			//----------------------------------------------------------------------------*

			ListViewItem Item = m_SuppliesListView.AddBullet(Bullet, true);

			if (Item == null)
				MessageBox.Show("This bullet has been added to the database, but it will not appear on the list of bullets because it is not usable with any of the calibers you have checked on the Calibers tab.", "Bullet Added", MessageBoxButtons.OK, MessageBoxIcon.Information);

			//----------------------------------------------------------------------------*
			// Update supply count and exit
			//----------------------------------------------------------------------------*

			SetSupplyCount();
			}

		//============================================================================*
		// AddCase()
		//============================================================================*

		private void AddCase(cCase Case)
			{
			//----------------------------------------------------------------------------*
			// If the Case already exists, update the existing one and exit
			//----------------------------------------------------------------------------*

			foreach (cCase CheckCase in m_DataFiles.CaseList)
				{
				if (CheckCase.CompareTo(Case) == 0)
					{
					UpdateCase(CheckCase, Case);

					return;
					}
				}

			//----------------------------------------------------------------------------*
			// Add the new case to the list
			//----------------------------------------------------------------------------*

			m_DataFiles.CaseList.Add(Case);
			m_DataFiles.CaseList.Sort();

			//----------------------------------------------------------------------------*
			// Add the new case to the supplies tab
			//----------------------------------------------------------------------------*

			m_SuppliesListView.AddCase(Case, true);

			m_SuppliesListView.Focus();

			//----------------------------------------------------------------------------*
			// Update supply count and exit
			//----------------------------------------------------------------------------*

			SetSupplyCount();
			}

		//============================================================================*
		// AddPowder()
		//============================================================================*

		private void AddPowder(cPowder Powder)
			{
			//----------------------------------------------------------------------------*
			// If the Powder already exists, update the existing one and exit
			//----------------------------------------------------------------------------*

			foreach (cPowder CheckPowder in m_DataFiles.PowderList)
				{
				if (CheckPowder.CompareTo(Powder) == 0)
					{
					UpdatePowder(CheckPowder, Powder);

					return;
					}
				}

			//----------------------------------------------------------------------------*
			// Add the new Powder to the list
			//----------------------------------------------------------------------------*

			m_DataFiles.PowderList.Add(Powder);
			m_DataFiles.PowderList.Sort();

			//----------------------------------------------------------------------------*
			// Add the new Powder to the Supply tab
			//----------------------------------------------------------------------------*

			m_SuppliesListView.AddPowder(Powder, true);

			//----------------------------------------------------------------------------*
			// Update the Load Data Tab Powder Combo
			//----------------------------------------------------------------------------*

			PopulateLoadDataPowderCombo();
			PopulateBatchPowderCombo();

			//----------------------------------------------------------------------------*
			// Update supply count and exit
			//----------------------------------------------------------------------------*

			SetSupplyCount();
			}

		//============================================================================*
		// AddPrimer()
		//============================================================================*

		private void AddPrimer(cPrimer Primer)
			{
			//----------------------------------------------------------------------------*
			// If the Primer already exists, update the existing one and exit
			//----------------------------------------------------------------------------*

			foreach (cPrimer CheckPrimer in m_DataFiles.PrimerList)
				{
				if (CheckPrimer.CompareTo(Primer) == 0)
					{
					UpdatePrimer(CheckPrimer, Primer);

					return;
					}
				}

			//----------------------------------------------------------------------------*
			// Add the new Primer to the list
			//----------------------------------------------------------------------------*

			m_DataFiles.PrimerList.Add(Primer);
			m_DataFiles.PrimerList.Sort();

			//----------------------------------------------------------------------------*
			// Add the new Primer to the Caliber tab
			//----------------------------------------------------------------------------*

			m_SuppliesListView.AddPrimer(Primer, true);

			//----------------------------------------------------------------------------*
			// Update supply count and exit
			//----------------------------------------------------------------------------*

			SetSupplyCount();
			}

		//============================================================================*
		// InitializeSuppliesTab()
		//============================================================================*

		public void InitializeSuppliesTab()
			{
			if (!m_fSuppliesTabInitialized)
				{
				//----------------------------------------------------------------------------*
				// Supply Tab Event Handlers
				//----------------------------------------------------------------------------*

				m_SuppliesListView = new cSuppliesListView(m_DataFiles);
				m_SuppliesListView.TabIndex = 1;

				SuppliesTab.Controls.Add(m_SuppliesListView);

				AddSupplyButton.Click += OnAddSupply;
				EditSupplyButton.Click += OnEditSupply;
				ViewSupplyButton.Click += OnViewSupply;
				RemoveSupplyButton.Click += OnRemoveSupply;

				SupplyTypeCombo.SelectedIndexChanged += OnSupplyTypeSelected;

				m_SuppliesListView.SelectedIndexChanged += OnSupplySelected;
				m_SuppliesListView.DoubleClick += OnSupplyDoubleClicked;
				m_SuppliesListView.ItemChecked += OnSupplyChecked;

				SelectAllSuppliesButton.Click += OnSelectAllSuppliesClicked;
				DeselectAllSuppliesButton.Click += OnDeselectAllSuppliesClicked;

				SuppliesPrintAllRadioButton.Click += OnSuppliesPrintAllClicked;
				SuppliesPrintCheckedRadioButton.Click += OnSuppliesPrintCheckedClicked;
				SuppliesPrintNonZeroCheckBox.Click += OnSuppliesPrintNonZeroClicked;
				SuppliesPrintBelowStockCheckBox.Click += OnSuppliesPrintBelowStockClicked;
				SupplyListPrintButton.Click += OnPrintSupplyListClicked;

				EditInventoryButton.Click += OnEditInventoryActivity;
				ViewInventoryButton.Click += OnViewInventoryActivity;
				SuppliesCostAnalysisButton.Click += OnPrintCostAnalysisClicked;

				HideUncheckedSuppliesCheckBox.Click += OnHideUncheckedSuppliesClicked;

				m_fSuppliesTabInitialized = true;
				}

			//----------------------------------------------------------------------------*
			// Operations that are always performed
			//----------------------------------------------------------------------------*

			SuppliesInventoryGroup.Visible = m_DataFiles.Preferences.TrackInventory;

			PopulateSupplyTab();

			UpdateSuppliesTabButtons();
			}

		//============================================================================*
		// OnAddSupply()
		//============================================================================*

		protected void OnAddSupply(object sender, EventArgs args)
			{
			switch ((cSupply.eSupplyTypes) SupplyTypeCombo.SelectedIndex)
				{
				//----------------------------------------------------------------------------*
				// Bullets
				//----------------------------------------------------------------------------*

				case cSupply.eSupplyTypes.Bullets:
					//----------------------------------------------------------------------------*
					// Create and show the Bullet Form
					//----------------------------------------------------------------------------*

					cBulletForm BulletForm = new cBulletForm(null, m_DataFiles);

					if (BulletForm.ShowDialog() == DialogResult.OK)
						{
						//----------------------------------------------------------------------------*
						// Create the new Bullet
						//----------------------------------------------------------------------------*

						cBullet Bullet = BulletForm.Bullet;

						if (Bullet != null)
							{
							Bullet.Checked = Bullet.Checked || m_DataFiles.Preferences.AutoCheck || (m_DataFiles.Preferences.AutoCheckNonZero && m_DataFiles.SupplyQuantity(Bullet) > 0.0);

							foreach (cBullet CheckBullet in m_DataFiles.BulletList)
								{
								if (CheckBullet.CompareTo(Bullet) == 0)
									CheckBullet.Checked = Bullet.Checked;
								}

							VerifyUncheckedSupply(Bullet);

							//----------------------------------------------------------------------------*
							// Add the New Bullet
							//----------------------------------------------------------------------------*

							m_DataFiles.Preferences.LastBullet = Bullet;

							AddBullet(Bullet);
							}
						}

					break;

				//----------------------------------------------------------------------------*
				// Cases
				//----------------------------------------------------------------------------*

				case cSupply.eSupplyTypes.Cases:
					//----------------------------------------------------------------------------*
					// Create and Show the Case Form
					//----------------------------------------------------------------------------*

					cCaseForm CaseForm = new cCaseForm(null, m_DataFiles);

					if (CaseForm.ShowDialog() == DialogResult.OK)
						{
						//----------------------------------------------------------------------------*
						// Create the New Case
						//----------------------------------------------------------------------------*

						cCase Case = CaseForm.Case;

						if (Case != null)
							{
							Case.Checked = m_DataFiles.Preferences.AutoCheck || (m_DataFiles.Preferences.AutoCheckNonZero && m_DataFiles.SupplyQuantity(Case) > 0.0);

							VerifyUncheckedSupply(Case);

							//----------------------------------------------------------------------------*
							// Add the New Case
							//----------------------------------------------------------------------------*

							m_DataFiles.Preferences.LastCase = CaseForm.Case;

							AddCase(Case);
							}
						}

					break;

				//----------------------------------------------------------------------------*
				// Powder
				//----------------------------------------------------------------------------*

				case cSupply.eSupplyTypes.Powder:
					//----------------------------------------------------------------------------*
					// Create and show the Powder Form
					//----------------------------------------------------------------------------*

					cPowderForm PowderForm = new cPowderForm(null, m_DataFiles);

					if (PowderForm.ShowDialog() == DialogResult.OK)
						{
						//----------------------------------------------------------------------------*
						// Create the New Powder
						//----------------------------------------------------------------------------*

						cPowder Powder = PowderForm.Powder;

						if (Powder != null)
							{
							Powder.Checked = m_DataFiles.Preferences.AutoCheck || (m_DataFiles.Preferences.AutoCheckNonZero && m_DataFiles.SupplyQuantity(Powder) > 0.0);

							VerifyUncheckedSupply(Powder);

							//----------------------------------------------------------------------------*
							// Add the New Powder
							//----------------------------------------------------------------------------*

							m_DataFiles.Preferences.LastPowder = PowderForm.Powder;

							AddPowder(Powder);
							}
						}

					break;

				//----------------------------------------------------------------------------*
				// Primers
				//----------------------------------------------------------------------------*

				case cSupply.eSupplyTypes.Primers:
					//----------------------------------------------------------------------------*
					// Create and show the Primer Form
					//----------------------------------------------------------------------------*

					cPrimerForm PrimerForm = new cPrimerForm(null, m_DataFiles);

					if (PrimerForm.ShowDialog() == DialogResult.OK)
						{
						//----------------------------------------------------------------------------*
						// Create the new Primer
						//----------------------------------------------------------------------------*

						cPrimer Primer = PrimerForm.Primer;

						if (Primer != null)
							{
							Primer.Checked = m_DataFiles.Preferences.AutoCheck || (m_DataFiles.Preferences.AutoCheckNonZero && m_DataFiles.SupplyQuantity(Primer) > 0.0);

							VerifyUncheckedSupply(Primer);

							//----------------------------------------------------------------------------*
							// Add the New Primer
							//----------------------------------------------------------------------------*

							m_DataFiles.Preferences.LastPrimer = PrimerForm.Primer;

							AddPrimer(Primer);
							}
						}

					break;
				}

			m_SuppliesListView.Focus();
			}

		//============================================================================*
		// OnDeselectAllSuppliesClicked()
		//============================================================================*

		protected void OnDeselectAllSuppliesClicked(object sender, EventArgs args)
			{
			switch ((cSupply.eSupplyTypes) SupplyTypeCombo.SelectedIndex)
				{
				case cSupply.eSupplyTypes.Bullets:
					foreach (cBullet Bullet in m_DataFiles.BulletList)
						Bullet.Checked = false;

					break;

				case cSupply.eSupplyTypes.Cases:
					foreach (cCase Case in m_DataFiles.CaseList)
						Case.Checked = false;

					break;

				case cSupply.eSupplyTypes.Primers:
					foreach (cPrimer Primer in m_DataFiles.PrimerList)
						Primer.Checked = false;

					break;

				case cSupply.eSupplyTypes.Powder:
					foreach (cPowder Powder in m_DataFiles.PowderList)
						Powder.Checked = false;

					break;
				}

			PopulateSuppliesListView();
			}

		//============================================================================*
		// OnEditSupply()
		//============================================================================*

		protected void OnEditSupply(object sender, EventArgs args)
			{
			ListViewItem Item = null;

			if (m_SuppliesListView.SelectedItems.Count == 0)
				return;

			//----------------------------------------------------------------------------*
			// Determine which supply is being diaplayed
			//----------------------------------------------------------------------------*

			switch (SupplyTypeCombo.SelectedIndex)
				{
				//----------------------------------------------------------------------------*
				// Bullets
				//----------------------------------------------------------------------------*

				case (int) cSupply.eSupplyTypes.Bullets:
					Item = m_SuppliesListView.SelectedItems[0];

					if (Item == null)
						return;

					cBullet Bullet = (cBullet) Item.Tag;

					if (Bullet == null)
						return;

					//----------------------------------------------------------------------------*
					// Start the dialog
					//----------------------------------------------------------------------------*

					cBullet OriginalBullet = Bullet;

					cBulletForm BulletForm = new cBulletForm(Bullet, m_DataFiles);

					if (BulletForm.ShowDialog() == DialogResult.OK)
						{
						//----------------------------------------------------------------------------*
						// Get the new Bullet Data
						//----------------------------------------------------------------------------*

						cBullet NewBullet = new cBullet(BulletForm.Bullet);
						m_DataFiles.Preferences.LastBullet = BulletForm.Bullet;

						UpdateBullet(OriginalBullet, NewBullet);
						}

					break;

				//----------------------------------------------------------------------------*
				// Cases
				//----------------------------------------------------------------------------*

				case (int) cSupply.eSupplyTypes.Cases:
					Item = m_SuppliesListView.SelectedItems[0];

					if (Item == null)
						return;

					cCase Case = (cCase) Item.Tag;

					if (Case == null)
						return;

					//----------------------------------------------------------------------------*
					// Start the dialog
					//----------------------------------------------------------------------------*

					cCase OriginalCase = new cCase(Case);

					cCaseForm CaseForm = new cCaseForm(Case, m_DataFiles);

					if (CaseForm.ShowDialog() == DialogResult.OK)
						{
						//----------------------------------------------------------------------------*
						// Get the new Case Data
						//----------------------------------------------------------------------------*

						cCase NewCase = CaseForm.Case;
						m_DataFiles.Preferences.LastCase = CaseForm.Case;

						UpdateCase(OriginalCase, NewCase);
						}

					break;

				//----------------------------------------------------------------------------*
				// Powder
				//----------------------------------------------------------------------------*

				case (int) cSupply.eSupplyTypes.Powder:
					Item = m_SuppliesListView.SelectedItems[0];

					if (Item == null)
						return;

					cPowder Powder = (cPowder) Item.Tag;

					if (Powder == null)
						return;

					//----------------------------------------------------------------------------*
					// Start the dialog
					//----------------------------------------------------------------------------*

					cPowder OriginalPowder = Powder;

					cPowderForm PowderForm = new cPowderForm(Powder, m_DataFiles);

					if (PowderForm.ShowDialog() == DialogResult.OK)
						{
						//----------------------------------------------------------------------------*
						// Get the new Powder Data
						//----------------------------------------------------------------------------*

						cPowder NewPowder = PowderForm.Powder;
						m_DataFiles.Preferences.LastPowder = PowderForm.Powder;

						UpdatePowder(OriginalPowder, NewPowder);
						}

					break;

				//----------------------------------------------------------------------------*
				// Primers
				//----------------------------------------------------------------------------*

				case (int) cSupply.eSupplyTypes.Primers:
					Item = m_SuppliesListView.SelectedItems[0];

					if (Item == null)
						return;

					cPrimer Primer = (cPrimer) Item.Tag;

					if (Primer == null)
						return;

					//----------------------------------------------------------------------------*
					// Start the dialog
					//----------------------------------------------------------------------------*

					cPrimer OriginalPrimer = Primer;

					cPrimerForm PrimerForm = new cPrimerForm(Primer, m_DataFiles);

					if (PrimerForm.ShowDialog() == DialogResult.OK)
						{
						//----------------------------------------------------------------------------*
						// Get the new Primer Data
						//----------------------------------------------------------------------------*

						cPrimer NewPrimer = PrimerForm.Primer;
						m_DataFiles.Preferences.LastPrimer = PrimerForm.Primer;

						UpdatePrimer(OriginalPrimer, NewPrimer);
						}

					break;
				}

			m_SuppliesListView.Focus();
			}

		//============================================================================*
		// OnHideUncheckedSuppliesClicked()
		//============================================================================*

		protected void OnHideUncheckedSuppliesClicked(object sender, EventArgs args)
			{
			HideUncheckedSuppliesCheckBox.Checked = !HideUncheckedSuppliesCheckBox.Checked;

			m_DataFiles.Preferences.HideUncheckedSupplies = HideUncheckedSuppliesCheckBox.Checked;

			PopulateSuppliesListView();

			SetSupplyCount();

			InitializeLoadDataTab();
			InitializeBallisticsTab();
			}

		//============================================================================*
		// OnPrintSupplyListClicked()
		//============================================================================*

		protected void OnPrintSupplyListClicked(object sender, EventArgs args)
			{
			//----------------------------------------------------------------------------*
			// Show the dialog
			//----------------------------------------------------------------------------*

			cSupplyListPreviewDialog SupplyListDialog = new cSupplyListPreviewDialog(m_DataFiles);

			SupplyListDialog.ShowDialog();
			}

		//============================================================================*
		// OnRemoveSupply()
		//============================================================================*

		protected void OnRemoveSupply(object sender, EventArgs args)
			{
			//----------------------------------------------------------------------------*
			// Determine which type of supply is being displayed
			//----------------------------------------------------------------------------*

			switch ((cSupply.eSupplyTypes) SupplyTypeCombo.SelectedIndex)
				{
				//----------------------------------------------------------------------------*
				// Bullets
				//----------------------------------------------------------------------------*

				case cSupply.eSupplyTypes.Bullets:
						{
						cBullet Bullet = null;

						ListViewItem Item = m_SuppliesListView.SelectedItems[0];

						if (Item != null)
							Bullet = (cBullet) Item.Tag;

						if (Bullet == null)
							break;

						//----------------------------------------------------------------------------*
						// See if the Bullet is being used in other records
						//----------------------------------------------------------------------------*

						string strCount = m_DataFiles.DeleteBullet(Bullet, true);

						if (strCount.Length > 0)
							{
							string strMessage = String.Format("This bullet, {0}, is used in\n\n", Bullet.ToString());
							strMessage += strCount;
							strMessage += "\nThe above item(s) must be removed in order to remove this bullet.";

							MessageBox.Show(this, strMessage, "Bullet in Use", MessageBoxButtons.OK, MessageBoxIcon.Information);

							break;
							}

						//----------------------------------------------------------------------------*
						// Make sure the user is sure
						//----------------------------------------------------------------------------*

						if (MessageBox.Show(this, "Are you sure you wish to remove this bullet?", "Data Deletion Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
							{
							m_DataFiles.DeleteBullet(Bullet);

							m_SuppliesListView.Items.Remove(Item);
							}
						}

					break;

				//----------------------------------------------------------------------------*
				// Cases
				//----------------------------------------------------------------------------*

				case cSupply.eSupplyTypes.Cases:
						{
						cCase Case = null;

						ListViewItem Item = m_SuppliesListView.SelectedItems[0];

						if (Item != null)
							Case = (cCase) Item.Tag;

						if (Case == null)
							break;

						//----------------------------------------------------------------------------*
						// See if the Case is being used in other records
						//----------------------------------------------------------------------------*

						string strCount = m_DataFiles.DeleteCase(Case, true);

						if (strCount.Length > 0)
							{
							string strMessage = String.Format("This case, {0}, is used in\n\n", Case.ToString());
							strMessage += strCount;
							strMessage += "\nThe above item(s) must be removed in order to remove this case.";

							MessageBox.Show(this, strMessage, "Case in Use", MessageBoxButtons.OK, MessageBoxIcon.Information);

							break;
							}

						//----------------------------------------------------------------------------*
						// Make sure the user is sure
						//----------------------------------------------------------------------------*

						if (MessageBox.Show(this, "Are you sure you wish to remove this case?", "Data Deletion Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
							{
							m_DataFiles.DeleteCase(Case);

							m_SuppliesListView.Items.Remove(Item);
							}
						}

					break;

				//----------------------------------------------------------------------------*
				// Powder
				//----------------------------------------------------------------------------*

				case cBullet.eSupplyTypes.Powder:
						{
						cPowder Powder = null;

						ListViewItem Item = m_SuppliesListView.SelectedItems[0];

						if (Item != null)
							Powder = (cPowder) Item.Tag;

						if (Powder == null)
							break;

						//----------------------------------------------------------------------------*
						// See if the Powder is being used in other records
						//----------------------------------------------------------------------------*

						string strCount = m_DataFiles.DeletePowder(Powder, true);

						if (strCount.Length > 0)
							{
							string strMessage = String.Format("This powder, {0}, is used in\n\n", Powder.ToString());
							strMessage += strCount;
							strMessage += "\nThe above item(s) must be removed in order to remove this powder.";

							MessageBox.Show(this, strMessage, "Powder in Use", MessageBoxButtons.OK, MessageBoxIcon.Information);

							break;
							}

						//----------------------------------------------------------------------------*
						// Make sure the user is sure
						//----------------------------------------------------------------------------*

						if (MessageBox.Show(this, "Are you sure you wish to remove this powder?", "Data Deletion Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
							{
							m_DataFiles.DeletePowder(Powder);

							m_SuppliesListView.Items.Remove(Item);
							}
						}

					break;

				//----------------------------------------------------------------------------*
				// Primers
				//----------------------------------------------------------------------------*

				case cSupply.eSupplyTypes.Primers:
						{
						cPrimer Primer = null;

						ListViewItem Item = m_SuppliesListView.SelectedItems[0];

						if (Item != null)
							Primer = (cPrimer) Item.Tag;

						if (Primer == null)
							break;

						//----------------------------------------------------------------------------*
						// See if the Primer is being used in other records
						//----------------------------------------------------------------------------*

						string strCount = m_DataFiles.DeletePrimer(Primer, true);

						if (strCount.Length > 0)
							{
							string strMessage = String.Format("This primer, {0}, is used in\n\n", Primer.ToString());
							strMessage += strCount;
							strMessage += "\nThe above item(s) must be removed in order to remove this primer.";

							MessageBox.Show(this, strMessage, "Primer in Use", MessageBoxButtons.OK, MessageBoxIcon.Information);

							break;
							}

						//----------------------------------------------------------------------------*
						// Make sure the user is sure
						//----------------------------------------------------------------------------*

						if (MessageBox.Show(this, "Are you sure you wish to remove this primer?", "Data Deletion Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
							{
							m_DataFiles.DeletePrimer(Primer);

							m_SuppliesListView.Items.Remove(Item);
							}
						}

					break;
				}

			SetSupplyCount();

			UpdateSuppliesTabButtons();

			m_SuppliesListView.Focus();
			}

		//============================================================================*
		// OnSelectAllSuppliesClicked()
		//============================================================================*

		protected void OnSelectAllSuppliesClicked(object sender, EventArgs args)
			{
			switch ((cSupply.eSupplyTypes) SupplyTypeCombo.SelectedIndex)
				{
				case cSupply.eSupplyTypes.Bullets:
					foreach (cBullet Bullet in m_DataFiles.BulletList)
						Bullet.Checked = true;

					break;

				case cSupply.eSupplyTypes.Cases:
					foreach (cCase Case in m_DataFiles.CaseList)
						Case.Checked = true;

					break;

				case cSupply.eSupplyTypes.Primers:
					foreach (cPrimer Primer in m_DataFiles.PrimerList)
						Primer.Checked = true;

					break;

				case cSupply.eSupplyTypes.Powder:
					foreach (cPowder Powder in m_DataFiles.PowderList)
						Powder.Checked = true;

					break;
				}

			PopulateSuppliesListView();
			}

		//============================================================================*
		// OnSuppliesPrintAllClicked()
		//============================================================================*

		protected void OnSuppliesPrintAllClicked(object sender, EventArgs args)
			{
			SuppliesPrintAllRadioButton.Checked = !SuppliesPrintAllRadioButton.Checked;
			SuppliesPrintCheckedRadioButton.Checked = !SuppliesPrintAllRadioButton.Checked;

			m_DataFiles.Preferences.SupplyPrintAll = SuppliesPrintAllRadioButton.Checked;
			m_DataFiles.Preferences.SupplyPrintChecked = SuppliesPrintCheckedRadioButton.Checked;

			UpdateSuppliesTabButtons();
			}

		//============================================================================*
		// OnSuppliesPrintBelowStockClicked()
		//============================================================================*

		protected void OnSuppliesPrintBelowStockClicked(object sender, EventArgs args)
			{
			SuppliesPrintBelowStockCheckBox.Checked = !SuppliesPrintBelowStockCheckBox.Checked;

			m_DataFiles.Preferences.SupplyPrintBelowStock = SuppliesPrintBelowStockCheckBox.Checked;

			UpdateSuppliesTabButtons();
			}

		//============================================================================*
		// OnSuppliesPrintCheckedClicked()
		//============================================================================*

		protected void OnSuppliesPrintCheckedClicked(object sender, EventArgs args)
			{
			SuppliesPrintCheckedRadioButton.Checked = !SuppliesPrintCheckedRadioButton.Checked;
			SuppliesPrintAllRadioButton.Checked = !SuppliesPrintCheckedRadioButton.Checked;

			m_DataFiles.Preferences.SupplyPrintAll = SuppliesPrintAllRadioButton.Checked;
			m_DataFiles.Preferences.SupplyPrintChecked = SuppliesPrintCheckedRadioButton.Checked;

			UpdateSuppliesTabButtons();
			}

		//============================================================================*
		// OnSuppliesPrintNonZeroClicked()
		//============================================================================*

		protected void OnSuppliesPrintNonZeroClicked(object sender, EventArgs args)
			{
			SuppliesPrintNonZeroCheckBox.Checked = !SuppliesPrintNonZeroCheckBox.Checked;

			m_DataFiles.Preferences.SupplyPrintNonZero = SuppliesPrintNonZeroCheckBox.Checked;

			UpdateSuppliesTabButtons();
			}

		//============================================================================*
		// OnSupplyChecked()
		//============================================================================*

		protected void OnSupplyChecked(object sender, ItemCheckedEventArgs args)
			{
			if (!m_fInitialized || m_SuppliesListView.Populating)
				return;

			cSupply Supply = (cSupply) args.Item.Tag;

			if (Supply != null)
				Supply.Checked = args.Item.Checked;

			PopulateBallisticsCaliberCombo();
			PopulateBallisticsBulletCombo();

			UpdateSuppliesTabButtons();
			}

		//============================================================================*
		// OnSupplyDoubleClicked()
		//============================================================================*

		protected void OnSupplyDoubleClicked(object sender, EventArgs args)
			{
			if (!m_fInitialized)
				return;

			if (m_SuppliesListView.SelectedItems.Count > 0)
				{
				switch ((cSupply.eSupplyTypes) SupplyTypeCombo.SelectedIndex)
					{
					case cSupply.eSupplyTypes.Bullets:
						m_DataFiles.Preferences.LastBulletSelected = (cBullet) m_SuppliesListView.SelectedItems[0].Tag;
						break;

					case cSupply.eSupplyTypes.Cases:
						m_DataFiles.Preferences.LastCaseSelected = (cCase) m_SuppliesListView.SelectedItems[0].Tag;
						break;

					case cSupply.eSupplyTypes.Primers:
						m_DataFiles.Preferences.LastPrimerSelected = (cPrimer) m_SuppliesListView.SelectedItems[0].Tag;
						break;

					case cSupply.eSupplyTypes.Powder:
						m_DataFiles.Preferences.LastPowderSelected = (cPowder) m_SuppliesListView.SelectedItems[0].Tag;
						break;
					}

				OnEditSupply(sender, args);
				}

			UpdateSuppliesTabButtons();
			}

		//============================================================================*
		// OnSupplySelected()
		//============================================================================*

		protected void OnSupplySelected(object sender, EventArgs args)
			{
			if (!m_fInitialized || m_fPopulating)
				return;

			if (m_SuppliesListView.SelectedItems.Count > 0)
				{
				cSupply Supply = (cSupply) m_SuppliesListView.SelectedItems[0].Tag;

				if (Supply != null)
					{
					switch (Supply.SupplyType)
						{
						case cSupply.eSupplyTypes.Bullets:
							m_DataFiles.Preferences.LastBulletSelected = (cBullet) Supply;
							break;

						case cSupply.eSupplyTypes.Cases:
							m_DataFiles.Preferences.LastCaseSelected = (cCase) Supply;
							break;

						case cSupply.eSupplyTypes.Primers:
							m_DataFiles.Preferences.LastPrimerSelected = (cPrimer) Supply;
							break;

						case cSupply.eSupplyTypes.Powder:
							m_DataFiles.Preferences.LastPowderSelected = (cPowder) Supply;
							break;
						}
					}
				}

			UpdateSuppliesTabButtons();
			}

		//============================================================================*
		// OnSupplyTypeSelected()
		//============================================================================*

		protected void OnSupplyTypeSelected(object sender, EventArgs args)
			{
			if (!m_fInitialized || m_fPopulating)
				return;

			if (m_SuppliesListView.SupplyType == (cSupply.eSupplyTypes) SupplyTypeCombo.SelectedIndex)
				return;

			m_DataFiles.Preferences.LastSupplyTypeSelected = (cSupply.eSupplyTypes) SupplyTypeCombo.SelectedIndex;

			m_SuppliesListView.SupplyType = (cSupply.eSupplyTypes) SupplyTypeCombo.SelectedIndex;

			SetSupplyCount();

			UpdateSuppliesTabButtons();
			}

		//============================================================================*
		// OnViewSupply()
		//============================================================================*

		protected void OnViewSupply(object sender, EventArgs args)
			{
			ListViewItem Item = null;

			//----------------------------------------------------------------------------*
			// Determine which supply is being diaplayed
			//----------------------------------------------------------------------------*

			switch (SupplyTypeCombo.SelectedIndex)
				{
				//----------------------------------------------------------------------------*
				// Bullets
				//----------------------------------------------------------------------------*

				case (int) cSupply.eSupplyTypes.Bullets:
					Item = m_SuppliesListView.SelectedItems[0];

					if (Item == null)
						return;

					cBullet Bullet = (cBullet) Item.Tag;

					if (Bullet == null)
						return;

					//----------------------------------------------------------------------------*
					// Start the dialog
					//----------------------------------------------------------------------------*

					cBulletForm BulletForm = new cBulletForm(Bullet, m_DataFiles, true);

					BulletForm.ShowDialog();

					break;

				//----------------------------------------------------------------------------*
				// Cases
				//----------------------------------------------------------------------------*

				case (int) cSupply.eSupplyTypes.Cases:
					Item = m_SuppliesListView.SelectedItems[0];

					if (Item == null)
						return;

					cCase Case = (cCase) Item.Tag;

					if (Case == null)
						return;

					//----------------------------------------------------------------------------*
					// Start the dialog
					//----------------------------------------------------------------------------*

					cCaseForm CaseForm = new cCaseForm(Case, m_DataFiles, true);

					CaseForm.ShowDialog();

					break;

				//----------------------------------------------------------------------------*
				// Powder
				//----------------------------------------------------------------------------*

				case (int) cSupply.eSupplyTypes.Powder:
					Item = m_SuppliesListView.SelectedItems[0];

					if (Item == null)
						return;

					cPowder Powder = (cPowder) Item.Tag;

					if (Powder == null)
						return;

					//----------------------------------------------------------------------------*
					// Start the dialog
					//----------------------------------------------------------------------------*

					cPowderForm PowderForm = new cPowderForm(Powder, m_DataFiles, true);

					PowderForm.ShowDialog();

					break;

				//----------------------------------------------------------------------------*
				// Primers
				//----------------------------------------------------------------------------*

				case (int) cSupply.eSupplyTypes.Primers:
					Item = m_SuppliesListView.SelectedItems[0];

					if (Item == null)
						return;

					cPrimer Primer = (cPrimer) Item.Tag;

					if (Primer == null)
						return;

					//----------------------------------------------------------------------------*
					// Start the dialog
					//----------------------------------------------------------------------------*

					cPrimerForm PrimerForm = new cPrimerForm(Primer, m_DataFiles, true);

					PrimerForm.ShowDialog();

					break;
				}

			m_SuppliesListView.Focus();
			}

		//============================================================================*
		// PopulateSuppliesListView()
		//============================================================================*

		public void PopulateSuppliesListView()
			{
			m_SuppliesListView.Populate();

			UpdateSuppliesTabButtons();
			}

		//============================================================================*
		// PopulateSuppliesListViewColumns()
		//============================================================================*

		public void PopulateSuppliesListViewColumns(bool fPopulate = true)
			{
			m_SuppliesListView.PopulateColumns(fPopulate);
			}

		//============================================================================*
		// PopulateSupplyTab()
		//============================================================================*

		private void PopulateSupplyTab()
			{
			m_fPopulating = true;

			//----------------------------------------------------------------------------*
			// SupplyTypeCombo
			//----------------------------------------------------------------------------*

			SupplyTypeCombo.Items.Clear();

			SupplyTypeCombo.Items.Add("Bullets");
			SupplyTypeCombo.Items.Add("Cases");
			SupplyTypeCombo.Items.Add("Powder");
			SupplyTypeCombo.Items.Add("Primers");

			SupplyTypeCombo.SelectedIndex = (int) m_DataFiles.Preferences.LastSupplyTypeSelected;

			if (SupplyTypeCombo.SelectedIndex < 0)
				SupplyTypeCombo.SelectedIndex = 0;

			HideUncheckedSuppliesCheckBox.Checked = m_DataFiles.Preferences.HideUncheckedSupplies;

			SuppliesPrintAllRadioButton.Checked = m_DataFiles.Preferences.SupplyPrintAll;
			SuppliesPrintCheckedRadioButton.Checked = m_DataFiles.Preferences.SupplyPrintChecked;
			SuppliesPrintNonZeroCheckBox.Checked = m_DataFiles.Preferences.SupplyPrintNonZero;
			SuppliesPrintBelowStockCheckBox.Checked = m_DataFiles.Preferences.SupplyPrintBelowStock;

			m_SuppliesListView.SupplyType = (cSupply.eSupplyTypes) SupplyTypeCombo.SelectedIndex;

			SetSupplyCount();

			m_fPopulating = false;
			}

		//============================================================================*
		// SetCommonBulletInfo()
		//============================================================================*

		private void SetCommonBulletInfo(cBullet Bullet)
			{
			foreach (cBullet CheckBullet in m_DataFiles.BulletList)
				{
				if (Bullet.CompareTo(CheckBullet) == 0)
					continue;

				if (Bullet.Manufacturer.CompareTo(CheckBullet.Manufacturer) == 0 &&
					Bullet.PartNumber == CheckBullet.PartNumber)
					{
					CheckBullet.Type = Bullet.Type;
					CheckBullet.Diameter = Bullet.Diameter;
					CheckBullet.Length = Bullet.Length;
					CheckBullet.Weight = Bullet.Weight;
					CheckBullet.BallisticCoefficient = Bullet.BallisticCoefficient;
					CheckBullet.SelfCast = Bullet.SelfCast;
					CheckBullet.TopPunch = Bullet.TopPunch;

					CheckBullet.MinimumStockLevel = Bullet.MinimumStockLevel;
					CheckBullet.Checked = Bullet.Checked;

					if (!m_DataFiles.Preferences.TrackInventory)
						{
						CheckBullet.Quantity = Bullet.Quantity;
						CheckBullet.Cost = Bullet.Cost;
						}

					m_SuppliesListView.UpdateBullet(CheckBullet);
					}
				}
			}

		//============================================================================*
		// SetSupplyCount()
		//============================================================================*

		private void SetSupplyCount()
			{
			SupplyCountLabel.Text = String.Format("{0:N0} Handgun, {1:N0} Rifle", m_SuppliesListView.HandgunCount, m_SuppliesListView.RifleCount);

			string strSupply = "";

			switch ((cSupply.eSupplyTypes) SupplyTypeCombo.SelectedIndex)
				{
				case cSupply.eSupplyTypes.Bullets:
					strSupply = "bullets";
					break;

				case cSupply.eSupplyTypes.Cases:
					strSupply = "cases";
					break;

				case cSupply.eSupplyTypes.Powder:
					strSupply = "powders";
					break;

				case cSupply.eSupplyTypes.Primers:
					strSupply = "primers";
					break;
				}

			if (strSupply.Length > 0)
				{
				if (m_DataFiles.Preferences.HideUncheckedCalibers)
					{
					if (SupplyTypeCombo.SelectedIndex == (int) cSupply.eSupplyTypes.Powder || SupplyTypeCombo.SelectedIndex == (int) cSupply.eSupplyTypes.Primers)
						{
						SupplyCountLabel.ForeColor = SystemColors.WindowText;

						SupplyCountLabel.Text += "    (All ";
						}
					else
						{
						SupplyCountLabel.ForeColor = Color.DarkRed;

						SupplyCountLabel.Text += "    (Only ";
						}

					if (m_DataFiles.Preferences.HideUncheckedSupplies)
						SupplyCountLabel.Text += "checked ";

					SupplyCountLabel.Text += strSupply;

					if (SupplyTypeCombo.SelectedIndex == (int) cSupply.eSupplyTypes.Powder || SupplyTypeCombo.SelectedIndex == (int) cSupply.eSupplyTypes.Primers)
						SupplyCountLabel.Text += " are displayed)";
					else
						SupplyCountLabel.Text += " usable in the selected calibers are displayed)";
					}
				else
					{
					SupplyCountLabel.ForeColor = SystemColors.ControlText;

					SupplyCountLabel.Text += "    (All ";

					if (m_DataFiles.Preferences.HideUncheckedSupplies)
						SupplyCountLabel.Text += "checked ";

					SupplyCountLabel.Text += strSupply;

					SupplyCountLabel.Text += " are displayed)";
					}
				}
			}

		//============================================================================*
		// UpdateBullet()
		//============================================================================*

		private void UpdateBullet(cBullet OldBullet, cBullet NewBullet)
			{
			//----------------------------------------------------------------------------*
			// Find the Bullet
			//----------------------------------------------------------------------------*

			foreach (cBullet CheckBullet in m_DataFiles.BulletList)
				{
				//----------------------------------------------------------------------------*
				// See if this is the same Bullet
				//----------------------------------------------------------------------------*

				if (CheckBullet.CompareTo(OldBullet) == 0)
					{
					//----------------------------------------------------------------------------*
					// Update the current Bullet record
					//----------------------------------------------------------------------------*

					CheckBullet.Copy(NewBullet);

					CheckBullet.RecalculateInventory(m_DataFiles);

					if (m_DataFiles.Preferences.AutoCheckNonZero)
						CheckBullet.Checked = CheckBullet.Checked || m_DataFiles.SupplyQuantity(CheckBullet) > 0.0;

					//----------------------------------------------------------------------------*
					// Update All Versions of this bullet
					//----------------------------------------------------------------------------*

					SetCommonBulletInfo(CheckBullet);

					//----------------------------------------------------------------------------*
					// Update the Bullet on the Supplies tab
					//----------------------------------------------------------------------------*

					m_SuppliesListView.UpdateBullet(CheckBullet, true);

					//----------------------------------------------------------------------------*
					// Update the tab data
					//----------------------------------------------------------------------------*

					InitializeLoadDataTab();
					InitializeBatchTab();
					InitializeBallisticsTab();

					return;
					}
				}

			//----------------------------------------------------------------------------*
			// If the Bullet was not found, add it
			//----------------------------------------------------------------------------*

			AddBullet(NewBullet);
			}

		//============================================================================*
		// UpdateCase()
		//============================================================================*

		private void UpdateCase(cCase OldCase, cCase NewCase)
			{
			//----------------------------------------------------------------------------*
			// Find the Case
			//----------------------------------------------------------------------------*

			foreach (cCase CheckCase in m_DataFiles.CaseList)
				{
				//----------------------------------------------------------------------------*
				// See if this is the same Case
				//----------------------------------------------------------------------------*

				if (CheckCase.CompareTo(OldCase) == 0)
					{
					//----------------------------------------------------------------------------*
					// Update the current Case record
					//----------------------------------------------------------------------------*

					CheckCase.Copy(NewCase);

					CheckCase.RecalculateInventory(m_DataFiles);

					if (m_DataFiles.Preferences.AutoCheckNonZero)
						CheckCase.Checked = CheckCase.Checked || m_DataFiles.SupplyQuantity(CheckCase) > 0.0;

					//----------------------------------------------------------------------------*
					// Update the Case on the Supplies tab
					//----------------------------------------------------------------------------*

					m_SuppliesListView.UpdateCase(CheckCase, true);

					//----------------------------------------------------------------------------*
					// Update the tab data
					//----------------------------------------------------------------------------*

					InitializeLoadDataTab();
					InitializeBatchTab();

					return;
					}
				}

			//----------------------------------------------------------------------------*
			// If the Case was not found, add it
			//----------------------------------------------------------------------------*

			AddCase(NewCase);
			}

		//============================================================================*
		// UpdatePowder()
		//============================================================================*

		private void UpdatePowder(cPowder OldPowder, cPowder NewPowder)
			{
			//----------------------------------------------------------------------------*
			// Find the Powder
			//----------------------------------------------------------------------------*

			foreach (cPowder CheckPowder in m_DataFiles.PowderList)
				{
				//----------------------------------------------------------------------------*
				// See if this is the same Powder
				//----------------------------------------------------------------------------*

				if (CheckPowder.Equals(OldPowder))
					{
					//----------------------------------------------------------------------------*
					// Update the current Powder record
					//----------------------------------------------------------------------------*

					CheckPowder.FirearmType = NewPowder.FirearmType;
					CheckPowder.Manufacturer = NewPowder.Manufacturer;

					CheckPowder.Model = NewPowder.Model;
					CheckPowder.PowderType = NewPowder.PowderType;

					CheckPowder.TransactionList = new cTransactionList(NewPowder.TransactionList);

					CheckPowder.RecalculateInventory(m_DataFiles);

					//----------------------------------------------------------------------------*
					// Set the quantities, costs, etc.
					//----------------------------------------------------------------------------*

					if (!m_DataFiles.Preferences.TrackInventory)
						{
						CheckPowder.Quantity = NewPowder.Quantity;
						CheckPowder.Cost = NewPowder.Cost;
						}

					//----------------------------------------------------------------------------*
					// Update the Powder on the Supplies tab
					//----------------------------------------------------------------------------*

					if (m_DataFiles.Preferences.AutoCheckNonZero)
						CheckPowder.Checked = CheckPowder.Checked || m_DataFiles.SupplyQuantity(CheckPowder) > 0.0;

					m_SuppliesListView.UpdatePowder(CheckPowder, true);

					//----------------------------------------------------------------------------*
					// Update the tab data
					//----------------------------------------------------------------------------*

					PopulateLoadDataPowderCombo();
					PopulateBatchPowderCombo();

					m_SuppliesListView.Focus();

					return;
					}
				}

			//----------------------------------------------------------------------------*
			// If the Powder was not found, add it
			//----------------------------------------------------------------------------*

			AddPowder(NewPowder);

			m_SuppliesListView.Focus();
			}

		//============================================================================*
		// UpdatePrimer()
		//============================================================================*

		private void UpdatePrimer(cPrimer OldPrimer, cPrimer NewPrimer)
			{
			//----------------------------------------------------------------------------*
			// Find the Primer
			//----------------------------------------------------------------------------*

			foreach (cPrimer CheckPrimer in m_DataFiles.PrimerList)
				{
				//----------------------------------------------------------------------------*
				// See if this is the same Primer
				//----------------------------------------------------------------------------*

				if (CheckPrimer.CompareTo(OldPrimer) == 0)
					{
					//----------------------------------------------------------------------------*
					// Update the current Primer record
					//----------------------------------------------------------------------------*

					CheckPrimer.Copy(NewPrimer);

					CheckPrimer.RecalculateInventory(m_DataFiles);

					if (m_DataFiles.Preferences.AutoCheckNonZero)
						CheckPrimer.Checked = CheckPrimer.Checked || m_DataFiles.SupplyQuantity(CheckPrimer) > 0.0;

					//----------------------------------------------------------------------------*
					// Update the Primer on the Supplies tab
					//----------------------------------------------------------------------------*

					m_SuppliesListView.UpdatePrimer(CheckPrimer, true);

					//----------------------------------------------------------------------------*
					// Update the tab data
					//----------------------------------------------------------------------------*

					InitializeLoadDataTab();
					InitializeBatchTab();

					m_SuppliesListView.Focus();

					return;
					}
				}

			//----------------------------------------------------------------------------*
			// If the Primer was not found, add it
			//----------------------------------------------------------------------------*

			AddPrimer(NewPrimer);

			m_SuppliesListView.Focus();
			}

		//============================================================================*
		// UpdateSuppliesTabButtons()
		//============================================================================*

		public void UpdateSuppliesTabButtons()
			{
			//----------------------------------------------------------------------------*
			// Checked Only Button
			//----------------------------------------------------------------------------*

			if (m_SuppliesListView.CheckedItems.Count == 0)
				{
				SuppliesPrintCheckedRadioButton.Checked = false;
				SuppliesPrintAllRadioButton.Checked = true;
				SuppliesPrintCheckedRadioButton.Enabled = false;

				m_DataFiles.Preferences.SupplyPrintAll = true;
				m_DataFiles.Preferences.SupplyPrintChecked = false;
				}
			else
				SuppliesPrintCheckedRadioButton.Enabled = true;

			//----------------------------------------------------------------------------*
			// Print Button
			//----------------------------------------------------------------------------*

			if (m_DataFiles.GetSupplyList().Count == 0)
				{
				SupplyListPrintButton.Enabled = false;

				NoSupplyListLabel.Visible = true;
				}
			else
				{
				SupplyListPrintButton.Enabled = true;

				NoSupplyListLabel.Visible = false;

				}

			//----------------------------------------------------------------------------*
			// Edit, View, Remove Buttons
			//----------------------------------------------------------------------------*

			EditInventoryButton.Enabled = m_SuppliesListView.SelectedItems.Count > 0;
			ViewInventoryButton.Enabled = m_SuppliesListView.SelectedItems.Count > 0;
			EditSupplyButton.Enabled = m_SuppliesListView.SelectedItems.Count > 0;
			ViewSupplyButton.Enabled = m_SuppliesListView.SelectedItems.Count > 0;
			RemoveSupplyButton.Enabled = m_SuppliesListView.SelectedItems.Count > 0;
			}

		//============================================================================*
		// VerifyUncheckedSupply()
		//============================================================================*

		private void VerifyUncheckedSupply(cSupply Supply)
			{
			if (m_DataFiles.Preferences.HideUncheckedSupplies && !Supply.Checked)
				{
				string strMessage = "You are currently hiding unckecked supplies, and do not have an applicable 'AutoCheck' option selected in Preferences.\n\n";

				strMessage += String.Format("Your new {0} will not appear on the supplies list unless it is checked.  Do you wish to check it now?", cSupply.SupplyTypeString(Supply.SupplyType));

				DialogResult rc = MessageBox.Show(strMessage, "Hidden Data Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

				if (rc == DialogResult.Yes)
					Supply.Checked = true;
				}
			}
		}
	}
