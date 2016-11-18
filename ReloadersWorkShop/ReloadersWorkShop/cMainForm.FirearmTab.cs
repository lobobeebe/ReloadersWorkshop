//============================================================================*
// cMainForm.FirearmTab.cs
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

		private cFirearmListView m_FirearmsListView = null;

		private bool m_fFirearmTabInitialized = false;

		//============================================================================*
		// AddFirearm()
		//============================================================================*

		private void AddFirearm(cFirearm Firearm)
			{
			//----------------------------------------------------------------------------*
			// If the Firearm already exists, our job is done, just exit
			//----------------------------------------------------------------------------*

			foreach (cFirearm CheckFirearm in m_DataFiles.FirearmList)
				{
				if (CheckFirearm.CompareTo(Firearm) == 0)
					return;
				}

			//----------------------------------------------------------------------------*
			// Otherwise, add the new firearm to the list
			//----------------------------------------------------------------------------*

			m_DataFiles.FirearmList.Add(Firearm);

			//----------------------------------------------------------------------------*
			// And add the new Firearm to the Firearm ListView
			//----------------------------------------------------------------------------*

			m_FirearmsListView.AddFirearm(Firearm, true);

			AddFirearmButton.Focus();
			}

		//============================================================================*
		// InitializeFirearmTab()
		//============================================================================*

		public void InitializeFirearmTab()
			{
			if (!m_fFirearmTabInitialized)
				{
				m_FirearmsListView = new cFirearmListView(m_DataFiles);

				FirearmsTab.Controls.Add(m_FirearmsListView);

				AddFirearmButton.Click += OnAddFirearm;
				EditFirearmButton.Click += OnEditFirearm;
				ViewFirearmButton.Click += OnViewFirearm;
				RemoveFirearmButton.Click += OnRemoveFirearm;

				FirearmPrintButton.Click += OnFirearmPrintClicked;

				FirearmPrintAllRadioButton.Click += OnFirearmPrintAllClicked;
				FirearmPrintCheckedRadioButton.Click += OnFirearmPrintCheckedClicked;
				FirearmPrintDetailCheckBox.Click += OnFirearmPrintDetailClicked;
				FirearmPrintSpecsCheckBox.Click += OnFirearmPrintSpecsClicked;

				m_FirearmsListView.SelectedIndexChanged += OnFirearmSelected;
				m_FirearmsListView.DoubleClick += OnFirearmDoubleClicked;

				m_FirearmsListView.ItemChecked += OnFirearmChecked;

				m_fFirearmTabInitialized = true;
				}

			//----------------------------------------------------------------------------*
			// Operations that are always performed
			//----------------------------------------------------------------------------*

			FirearmPrintAllRadioButton.Checked = m_DataFiles.Preferences.FirearmPrintAll;
			FirearmPrintCheckedRadioButton.Checked = !m_DataFiles.Preferences.FirearmPrintAll;
			FirearmPrintDetailCheckBox.Checked = m_DataFiles.Preferences.FirearmPrintDetail;
			FirearmPrintSpecsCheckBox.Checked = m_DataFiles.Preferences.FirearmPrintSpecs;

			PopulateFirearmsListViewColumns();

			UpdateFirearmTabButtons();
			}

		//============================================================================*
		// OnAddFirearm()
		//============================================================================*

		protected void OnAddFirearm(object sender, EventArgs args)
			{
			//----------------------------------------------------------------------------*
			// Start the dialog
			//----------------------------------------------------------------------------*

			Cursor = Cursors.WaitCursor;

			cFirearmForm FirearmForm = new cFirearmForm(null, m_DataFiles);

			Cursor = Cursors.Default;

			if (FirearmForm.ShowDialog() == DialogResult.OK)
				{
				//----------------------------------------------------------------------------*
				// Get the new Firearm Data
				//----------------------------------------------------------------------------*

				cFirearm NewFirearm = FirearmForm.Firearm;
				m_DataFiles.Preferences.LastFirearm = FirearmForm.Firearm;

				m_FirearmsListView.Focus();

				//----------------------------------------------------------------------------*
				// See if the Firearm already exists
				//----------------------------------------------------------------------------*

				foreach (cFirearm CheckFirearm in m_DataFiles.FirearmList)
					{
					if (CheckFirearm.CompareTo(NewFirearm) == 0)
						return;
					}

				AddFirearm(NewFirearm);
				}

			UpdateFirearmTabButtons();
			}

		//============================================================================*
		// OnEditFirearm()
		//============================================================================*

		protected void OnEditFirearm(object sender, EventArgs args)
			{
			//----------------------------------------------------------------------------*
			// Get the selected Firearm
			//----------------------------------------------------------------------------*

			ListViewItem Item = m_FirearmsListView.SelectedItems[0];

			if (Item == null)
				return;

			cFirearm Firearm = (cFirearm)Item.Tag;

			if (Firearm == null)
				return;

			//----------------------------------------------------------------------------*
			// Start the dialog
			//----------------------------------------------------------------------------*

			Cursor = Cursors.WaitCursor;

			cFirearmForm FirearmForm = new cFirearmForm(Firearm, m_DataFiles);

			Cursor = Cursors.Default;

			if (FirearmForm.ShowDialog() == DialogResult.OK)
				{
				//----------------------------------------------------------------------------*
				// Get the new Firearm Data
				//----------------------------------------------------------------------------*

				cFirearm NewFirearm = FirearmForm.Firearm;
				m_DataFiles.Preferences.LastFirearm = FirearmForm.Firearm;

				UpdateFirearm(Firearm, NewFirearm);
				}

			UpdateFirearmTabButtons();

			m_FirearmsListView.Focus();
			}

		//============================================================================*
		// OnFirearmChecked()
		//============================================================================*

		protected void OnFirearmChecked(object sender, ItemCheckedEventArgs args)
			{
			if (!m_fInitialized || m_fPopulating)
				return;

			(args.Item.Tag as cFirearm).Checked = args.Item.Checked;

			UpdateFirearmTabButtons();
			}

		//============================================================================*
		// OnFirearmDoubleClicked()
		//============================================================================*

		protected void OnFirearmDoubleClicked(object sender, EventArgs args)
			{
			if (m_FirearmsListView.SelectedItems.Count > 0)
				{
				m_DataFiles.Preferences.LastFirearmSelected = (cFirearm)(sender as ListView).SelectedItems[0].Tag;

				OnEditFirearm(sender, args);
				}

			UpdateFirearmTabButtons();
			}

		//============================================================================*
		// OnFirearmPrintAllClicked()
		//============================================================================*

		protected void OnFirearmPrintAllClicked(object sender, EventArgs args)
			{
			FirearmPrintAllRadioButton.Checked = !FirearmPrintAllRadioButton.Checked;
			FirearmPrintCheckedRadioButton.Checked = !FirearmPrintAllRadioButton.Checked;

			m_DataFiles.Preferences.FirearmPrintAll = FirearmPrintAllRadioButton.Checked;

			UpdateFirearmTabButtons();
			}

		//============================================================================*
		// OnFirearmPrintCheckedClicked()
		//============================================================================*

		protected void OnFirearmPrintCheckedClicked(object sender, EventArgs args)
			{
			FirearmPrintCheckedRadioButton.Checked = !FirearmPrintCheckedRadioButton.Checked;
			FirearmPrintAllRadioButton.Checked = !FirearmPrintCheckedRadioButton.Checked;

			m_DataFiles.Preferences.FirearmPrintAll = FirearmPrintAllRadioButton.Checked;

			UpdateFirearmTabButtons();
			}

		//============================================================================*
		// OnFirearmPrintClicked()
		//============================================================================*

		protected void OnFirearmPrintClicked(object sender, EventArgs args)
			{
			//----------------------------------------------------------------------------*
			// Reset Printed Flags
			//----------------------------------------------------------------------------*

			foreach (cFirearm Firearm in m_DataFiles.FirearmList)
				Firearm.Printed = false;

			//----------------------------------------------------------------------------*
			// Create and show the dialog
			//----------------------------------------------------------------------------*

			if (!FirearmPrintDetailCheckBox.Checked)
				{
				cFirearmListPreviewDialog FirearmListDialog = new cFirearmListPreviewDialog(m_DataFiles);

				FirearmListDialog.ShowDialog();
				}
			else
				{
				cFirearmDetailPreviewDialog FirearmDetailDialog = new cFirearmDetailPreviewDialog(m_DataFiles);

				FirearmDetailDialog.ShowDialog();
				}
			}

		//============================================================================*
		// OnFirearmPrintDetailClicked()
		//============================================================================*

		protected void OnFirearmPrintDetailClicked(object sender, EventArgs args)
			{
			FirearmPrintDetailCheckBox.Checked = !FirearmPrintDetailCheckBox.Checked;

			m_DataFiles.Preferences.FirearmPrintDetail = FirearmPrintDetailCheckBox.Checked;

			UpdateFirearmTabButtons();
			}

		//============================================================================*
		// OnFirearmPrintSpecsClicked()
		//============================================================================*

		protected void OnFirearmPrintSpecsClicked(object sender, EventArgs args)
			{
			FirearmPrintSpecsCheckBox.Checked = !FirearmPrintSpecsCheckBox.Checked;

			m_DataFiles.Preferences.FirearmPrintSpecs = FirearmPrintSpecsCheckBox.Checked;

			UpdateFirearmTabButtons();
			}

		//============================================================================*
		// OnFirearmSelected()
		//============================================================================*

		protected void OnFirearmSelected(object sender, EventArgs args)
			{
			if (!m_fInitialized || m_FirearmsListView.Populating)
				return;

			if (m_FirearmsListView.SelectedItems.Count > 0)
				m_DataFiles.Preferences.LastFirearmSelected = (cFirearm)m_FirearmsListView.SelectedItems[0].Tag;

			UpdateFirearmTabButtons();
			}

		//============================================================================*
		// OnRemoveFirearm()
		//============================================================================*

		protected void OnRemoveFirearm(object sender, EventArgs args)
			{
			cFirearm Firearm = null;

			ListViewItem Item = m_FirearmsListView.SelectedItems[0];

			if (Item != null)
				Firearm = (cFirearm)Item.Tag;

			if (Firearm == null)
				{
				m_FirearmsListView.Focus();

				return;
				}

			//----------------------------------------------------------------------------*
			// See if the Firearm is being used in other records
			//----------------------------------------------------------------------------*

			string strCount = m_DataFiles.DeleteFirearm(Firearm, true);

			if (strCount.Length > 0)
				{
				string strMessage = String.Format("This firearm, {0}, is used in\n\n", Firearm.ToString());
				strMessage += strCount;
				strMessage += "\nThe above component(s) must be removed in order to remove this firearm.";

				MessageBox.Show(this, strMessage, "Firearm in Use", MessageBoxButtons.OK, MessageBoxIcon.Information);

				m_FirearmsListView.Focus();

				return;
				}

			//----------------------------------------------------------------------------*
			// Make sure the user is sure
			//----------------------------------------------------------------------------*

			if (MessageBox.Show(this, "Are you sure you wish to remove this firearm?", "Data Deletion Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
				{
				m_DataFiles.DeleteFirearm(Firearm);

				m_FirearmsListView.Items.Remove(Item);
				}

			UpdateFirearmTabButtons();

			m_FirearmsListView.Focus();
			}

		//============================================================================*
		// OnViewFirearm()
		//============================================================================*

		protected void OnViewFirearm(object sender, EventArgs args)
			{
			//----------------------------------------------------------------------------*
			// Get the selected object
			//----------------------------------------------------------------------------*

			ListViewItem Item = m_FirearmsListView.SelectedItems[0];

			if (Item == null)
				return;

			cFirearm Firearm = (cFirearm)Item.Tag;

			if (Firearm == null)
				return;

			//----------------------------------------------------------------------------*
			// Start the dialog
			//----------------------------------------------------------------------------*

			Cursor = Cursors.WaitCursor;

			cFirearmForm FirearmForm = new cFirearmForm(Firearm, m_DataFiles, true);

			Cursor = Cursors.Default;

			FirearmForm.ShowDialog();

			m_FirearmsListView.Focus();
			}

		//============================================================================*
		// PopulateFirearmsListView()
		//============================================================================*

		public void PopulateFirearmsListView()
			{
			m_FirearmsListView.Populate();

			UpdateFirearmTabButtons();
			}

		//============================================================================*
		// PopulateFirearmsListViewColumns()
		//============================================================================*

		public void PopulateFirearmsListViewColumns()
			{
			m_FirearmsListView.SetColumns();

			PopulateFirearmsListView();
			}

		//============================================================================*
		// UpdateFirearm()
		//============================================================================*

		private void UpdateFirearm(cFirearm OldFirearm, cFirearm NewFirearm)
			{
			//----------------------------------------------------------------------------*
			// Find the NewFirearm
			//----------------------------------------------------------------------------*

			foreach (cFirearm CheckFirearm in m_DataFiles.FirearmList)
				{
				//----------------------------------------------------------------------------*
				// See if this is the same Firearm
				//----------------------------------------------------------------------------*

				if (CheckFirearm.CompareTo(OldFirearm) == 0)
					{
					//----------------------------------------------------------------------------*
					// Update the current Firearm record
					//----------------------------------------------------------------------------*

					CheckFirearm.Copy(NewFirearm);

					//----------------------------------------------------------------------------*
					// Update the Firearm on the Firearm tab
					//----------------------------------------------------------------------------*

					ListViewItem Item = null;

					foreach (ListViewItem CheckItem in m_FirearmsListView.Items)
						{
						if ((CheckItem.Tag as cFirearm).CompareTo(CheckFirearm) == 0)
							{
							Item = CheckItem;

							break;
							}
						}

					if (Item != null)
						{
						try
							{
							m_FirearmsListView.Items.Remove(Item);
							}
						catch
							{
							// No need to do anything here
							}

						m_FirearmsListView.AddFirearm(CheckFirearm, true);
						}

					return;
					}
				}

			//----------------------------------------------------------------------------*
			// If the NewFirearm was not found, add it
			//----------------------------------------------------------------------------*

			AddFirearm(NewFirearm);
			}

		//============================================================================*
		// UpdateFirearmTabButtons()
		//============================================================================*

		private void UpdateFirearmTabButtons()
			{
			if (!m_fInitialized)
				return;

			//----------------------------------------------------------------------------*
			// Print  Options
			//----------------------------------------------------------------------------*

			if (m_FirearmsListView.Items.Count > 0)
				{
				FirearmPrintButton.Enabled = true;

				if (m_FirearmsListView.CheckedItems.Count == 0 && FirearmPrintCheckedRadioButton.Checked)
					FirearmPrintButton.Enabled = false;
				}
			else
				FirearmPrintButton.Enabled = false;

			//----------------------------------------------------------------------------*
			// Edit, View, Remove Buttons
			//----------------------------------------------------------------------------*

			EditFirearmButton.Enabled = m_FirearmsListView.SelectedItems.Count > 0;
			ViewFirearmButton.Enabled = m_FirearmsListView.SelectedItems.Count > 0;
			RemoveFirearmButton.Enabled = m_FirearmsListView.SelectedItems.Count > 0;
			}
		}
	}
