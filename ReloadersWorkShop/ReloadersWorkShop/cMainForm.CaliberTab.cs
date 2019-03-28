//============================================================================*
// cMainForm.CaliberTab.cs
//
// Copyright © 2013-2017, Kevin S. Beebe
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

		private cCaliberListView m_CalibersListView = null;

		private bool m_fCaliberTabInitialized = false;

		//============================================================================*
		// AddCaliber()
		//============================================================================*

		private void AddCaliber(cCaliber Caliber)
			{
			//----------------------------------------------------------------------------*
			// If the Caliber already exists, update the existing one and exit
			//----------------------------------------------------------------------------*

			foreach (cCaliber CheckCaliber in m_DataFiles.CaliberList)
				{
				if (CheckCaliber.CompareTo(Caliber) == 0)
					{
					UpdateCaliber(CheckCaliber, Caliber);

					return;
					}
				}

			//----------------------------------------------------------------------------*
			// Add the new caliber to the list
			//----------------------------------------------------------------------------*

			m_DataFiles.CaliberList.Add(Caliber);

			//----------------------------------------------------------------------------*
			// Add the new Caliber to the Caliber tab
			//----------------------------------------------------------------------------*

			m_CalibersListView.AddCaliber(Caliber, true);

			//----------------------------------------------------------------------------*
			// Update the Load Data Tab Caliber Combo
			//----------------------------------------------------------------------------*

			PopulateLoadDataCaliberCombo();
			PopulateBatchCaliberCombo();
			PopulateBallisticsCaliberCombo();

			SetCaliberCount();
			}

		//============================================================================*
		// InitializeCaliberTab()
		//============================================================================*

		public void InitializeCaliberTab()
			{
			if (!m_fCaliberTabInitialized)
				{
				//----------------------------------------------------------------------------*
				// Caliber Tab Event Handlers
				//----------------------------------------------------------------------------*

				m_CalibersListView = new cCaliberListView(m_DataFiles);
				m_CalibersListView.ToolTip = "List of calibers in the database.";

				CalibersTab.Controls.Add(m_CalibersListView);

				AddCaliberButton.Click += OnAddCaliber;
				EditCaliberButton.Click += OnEditCaliber;
				RemoveCaliberButton.Click += OnRemoveCaliber;
				ViewCaliberButton.Click += OnViewCaliber;

				m_CalibersListView.SelectedIndexChanged += OnCaliberSelected;
				m_CalibersListView.DoubleClick += OnCaliberDoubleClicked;
				m_CalibersListView.ItemChecked += OnCaliberChecked;

				HideUncheckedCalibersCheckBox.Click += OnHideUncheckedCalibersClicked;

				m_fCaliberTabInitialized = true;
				}

			//----------------------------------------------------------------------------*
			// Operations that are always performed
			//----------------------------------------------------------------------------*

			m_CalibersListView.ShowToolTips = m_DataFiles.Preferences.ToolTips;

			HideUncheckedCalibersCheckBox.Checked = m_DataFiles.Preferences.HideUncheckedCalibers;

			PopulateCalibersListViewColumns();

			SetCaliberCount();
			}

		//============================================================================*
		// OnAddCaliber()
		//============================================================================*

		protected void OnAddCaliber(object sender, EventArgs args)
			{
			//----------------------------------------------------------------------------*
			// Start the dialog
			//----------------------------------------------------------------------------*

			cCaliberForm CaliberForm = new cCaliberForm(null, m_DataFiles);

			if (CaliberForm.ShowDialog() == DialogResult.OK)
				{
				//----------------------------------------------------------------------------*
				// Get the new Caliber Data
				//----------------------------------------------------------------------------*

				cCaliber NewCaliber = CaliberForm.Caliber;

				NewCaliber.Checked = m_DataFiles.Preferences.AutoCheck;

				VerifyUncheckedCaliber(NewCaliber);

				m_DataFiles.Preferences.LastCaliber = CaliberForm.Caliber;

				//----------------------------------------------------------------------------*
				// See if the Caliber already exists
				//----------------------------------------------------------------------------*

				cCaliber OldCaliber = NewCaliber;

				foreach (cCaliber CheckCaliber in m_DataFiles.CaliberList)
					{
					if (CheckCaliber.FirearmType == NewCaliber.FirearmType &&
						CheckCaliber.Name == NewCaliber.Name)
						{
						string strMessage = "Caliber '";
						strMessage += NewCaliber.Name;
						strMessage += "' already exists.  Update the exising data?";

						if (MessageBox.Show(strMessage, "Duplicate Caliber", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
							return;

						break;
						}
					}

				UpdateCaliber(OldCaliber, NewCaliber);
				}
			}

		//============================================================================*
		// OnCaliberChecked()
		//============================================================================*

		protected void OnCaliberChecked(object sender, ItemCheckedEventArgs args)
			{
			if (!m_fInitialized || m_fPopulating || m_CalibersListView.Populating)
				return;

			cCaliber Caliber = (cCaliber)args.Item.Tag;

			if (Caliber != null)
				Caliber.Checked = args.Item.Checked;

			if (m_DataFiles.Preferences.HideUncheckedCalibers)
				{
				PopulateFirearmsListView();
				PopulateSuppliesListView();
				PopulateLoadDataCaliberCombo();
				PopulateBatchCaliberCombo();
				}
			}

		//============================================================================*
		// OnCaliberDoubleClicked()
		//============================================================================*

		protected void OnCaliberDoubleClicked(object sender, EventArgs args)
			{
			if (!m_fInitialized)
				return;

			if (m_CalibersListView.SelectedItems.Count > 0)
				{
				m_DataFiles.Preferences.LastCaliberSelected = (cCaliber)m_CalibersListView.SelectedItems[0].Tag;

				ListViewItem Item = m_CalibersListView.SelectedItems[0];
				}

			OnEditCaliber(sender, args);

			UpdateButtons();
			}

		//============================================================================*
		// OnCaliberSelected()
		//============================================================================*

		protected void OnCaliberSelected(object sender, EventArgs args)
			{
			if (!m_fInitialized || m_fPopulating)
				return;

			if (m_CalibersListView.SelectedItems.Count > 0)
				m_DataFiles.Preferences.LastCaliberSelected = (cCaliber)m_CalibersListView.SelectedItems[0].Tag;

			UpdateButtons();
			}

		//============================================================================*
		// OnEditCaliber()
		//============================================================================*

		protected void OnEditCaliber(object sender, EventArgs args)
			{
			//----------------------------------------------------------------------------*
			// Get the selected Caliber
			//----------------------------------------------------------------------------*

			ListViewItem Item = m_CalibersListView.SelectedItems[0];

			if (Item == null)
				return;

			cCaliber Caliber = (cCaliber)Item.Tag;

			if (Caliber == null)
				return;

			//----------------------------------------------------------------------------*
			// Start the dialog
			//----------------------------------------------------------------------------*

			cCaliberForm CaliberForm = new cCaliberForm(Caliber, m_DataFiles);

			if (CaliberForm.ShowDialog() == DialogResult.OK)
				{
				//----------------------------------------------------------------------------*
				// Get the new Caliber Data
				//----------------------------------------------------------------------------*

				cCaliber NewCaliber = CaliberForm.Caliber;

				m_DataFiles.Preferences.LastCaliber = CaliberForm.Caliber;

				UpdateCaliber(Caliber, NewCaliber);
				}

			m_CalibersListView.Focus();
			}

		//============================================================================*
		// OnHideUncheckedCalibersClicked()
		//============================================================================*

		protected void OnHideUncheckedCalibersClicked(object sender, EventArgs args)
			{
			HideUncheckedCalibersCheckBox.Checked = HideUncheckedCalibersCheckBox.Checked ? false : true;

			m_CalibersListView.HideUnchecked = HideUncheckedCalibersCheckBox.Checked;

			InitializeFirearmTab();
			InitializeSuppliesTab();
			InitializeLoadDataTab();
			InitializeBatchTab();
			InitializeAmmoTab();
			InitializeBallisticsTab();

			SetSupplyCount();
			SetCaliberCount();
			}

		//============================================================================*
		// OnRemoveCaliber()
		//============================================================================*

		protected void OnRemoveCaliber(object sender, EventArgs args)
			{
			cCaliber Caliber = null;

			ListViewItem Item = m_CalibersListView.SelectedItems[0];

			if (Item != null)
				Caliber = (cCaliber)Item.Tag;

			if (Caliber == null)
				{
				m_CalibersListView.Focus();

				return;
				}

			//----------------------------------------------------------------------------*
			// See if the Caliber is being used in other records
			//----------------------------------------------------------------------------*

			string strCount = m_DataFiles.DeleteCaliber(Caliber, true);

			if (strCount.Length > 0)
				{
				string strMessage = String.Format("This caliber, {0}, is used in\n\n", Caliber.Name);
				strMessage += strCount;
				strMessage += "\nThe above component(s) must be removed in order to remove this caliber.";

				MessageBox.Show(this, strMessage, "Caliber in Use", MessageBoxButtons.OK, MessageBoxIcon.Information);

				m_CalibersListView.Focus();

				return;
				}

			//----------------------------------------------------------------------------*
			// Make sure the user is sure
			//----------------------------------------------------------------------------*

			if (MessageBox.Show(this, "Are you sure you wish to remove this caliber?", "Data Deletion Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
				{
				m_DataFiles.DeleteCaliber(Caliber);

				m_CalibersListView.Items.Remove(Item);

				UpdateButtons();
				}

			SetCaliberCount();

			m_CalibersListView.Focus();
			}

		//============================================================================*
		// OnViewCaliber()
		//============================================================================*

		protected void OnViewCaliber(object sender, EventArgs args)
			{
			//----------------------------------------------------------------------------*
			// Get the selected object
			//----------------------------------------------------------------------------*

			ListViewItem Item = m_CalibersListView.SelectedItems[0];

			if (Item == null)
				return;

			cCaliber Caliber = (cCaliber)Item.Tag;

			if (Caliber == null)
				return;

			//----------------------------------------------------------------------------*
			// Start the dialog
			//----------------------------------------------------------------------------*

			Cursor = Cursors.WaitCursor;

			cCaliberForm CaliberForm = new cCaliberForm(Caliber, m_DataFiles, true);

			Cursor = Cursors.Default;

			CaliberForm.ShowDialog();

			m_CalibersListView.Focus();
			}

		//============================================================================*
		// PopulateCalibersListView()
		//============================================================================*

		public void PopulateCalibersListView()
			{
			m_fPopulating = true;

			m_CalibersListView.Populate();

			m_fPopulating = false;

			UpdateCaliberTabButtons();
			}

		//============================================================================*
		// PopulateCalibersListViewColumns()
		//============================================================================*

		public void PopulateCalibersListViewColumns()
			{
			m_CalibersListView.SetColumns();

			PopulateCalibersListView();
			}

		//============================================================================*
		// SetCaliberCount()
		//============================================================================*

		private void SetCaliberCount()
			{
			CaliberCountLabel.Text = String.Format("{0:N0} Handgun,  {1:N0} Rifle,  {2:N0} Shotgun", m_CalibersListView.HandgunCount, m_CalibersListView.RifleCount, m_CalibersListView.ShotgunCount);

			if (m_DataFiles.Preferences.HideUncheckedCalibers)
				CaliberCountLabel.Text += "    (All checked calibers are displayed)";
			else
				CaliberCountLabel.Text += "    (All calibers are displayed)";
			}

		//============================================================================*
		// UpdateCaliber()
		//============================================================================*

		private void UpdateCaliber(cCaliber OldCaliber, cCaliber NewCaliber)
			{
			//----------------------------------------------------------------------------*
			// Find the Caliber
			//----------------------------------------------------------------------------*

			foreach (cCaliber CheckCaliber in m_DataFiles.CaliberList)
				{
				//----------------------------------------------------------------------------*
				// See if this is the same Caliber
				//----------------------------------------------------------------------------*

				if (CheckCaliber.CompareTo(OldCaliber) == 0)
					{
					//----------------------------------------------------------------------------*
					// Update the current Caliber record
					//----------------------------------------------------------------------------*

					CheckCaliber.Copy(NewCaliber);

					//----------------------------------------------------------------------------*
					// Update the Caliber on the Caliber tab
					//----------------------------------------------------------------------------*

					m_CalibersListView.UpdateCaliber(CheckCaliber, true);

					//----------------------------------------------------------------------------*
					// Update the other tabs
					//----------------------------------------------------------------------------*

					InitializeFirearmTab();
					InitializeSuppliesTab();
					InitializeLoadDataTab();
					InitializeBatchTab();
					InitializeBallisticsTab();

					return;
					}
				}

			//----------------------------------------------------------------------------*
			// If the Caliber was not found, add it
			//----------------------------------------------------------------------------*

			AddCaliber(NewCaliber);
			}

		//============================================================================*
		// UpdateCaliberTabButtons()
		//============================================================================*

		private void UpdateCaliberTabButtons()
			{
			//----------------------------------------------------------------------------*
			// Edit, View, Remove Buttons
			//----------------------------------------------------------------------------*

			EditCaliberButton.Enabled = m_CalibersListView.SelectedItems.Count > 0;
			ViewCaliberButton.Enabled = m_CalibersListView.SelectedItems.Count > 0;
			RemoveCaliberButton.Enabled = m_CalibersListView.SelectedItems.Count > 0;
			}

		//============================================================================*
		// VerifyUncheckedCaliber()
		//============================================================================*

		private void VerifyUncheckedCaliber(cCaliber Caliber)
			{
			if (m_DataFiles.Preferences.HideUncheckedCalibers && !Caliber.Checked)
				{
				string strMessage = "You are currently hiding unckecked calibers and do not have 'AutoCheck New Supplies and Calibers' turned on in Preferences.\n\n";

				strMessage += "Your new caliber will not appear on the caliber list unless it is checked.  Do you wish to check it now?";

				DialogResult rc = MessageBox.Show(strMessage, "Hidden Data Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

				if (rc == DialogResult.Yes)
					Caliber.Checked = true;
				}
			}
		}
	}
