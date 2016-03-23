//============================================================================*
// cMainForm.ManufacturerTab.cs
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

		private cManufacturerListView m_ManufacturersListView = null;

		private bool m_fManufacturerTabInitialized = false;

		//============================================================================*
		// InitializeManufacturerTab()
		//============================================================================*

		public void InitializeManufacturerTab()
			{
			if (!m_fManufacturerTabInitialized)
				{
				m_ManufacturersListView = new cManufacturerListView(m_DataFiles);

				ManufacturersTab.Controls.Add(m_ManufacturersListView);

				AddManufacturerButton.Click += OnAddManufacturer;
				EditManufacturerButton.Click += OnEditManufacturer;
				ViewManufacturerButton.Click += OnViewManufacturer;
				RemoveManufacturerButton.Click += OnRemoveManufacturer;

				m_ManufacturersListView.SelectedIndexChanged += OnManufacturerSelected;
				m_ManufacturersListView.DoubleClick += OnManufacturerDoubleClicked;

				m_fManufacturerTabInitialized = true;
				}

			//----------------------------------------------------------------------------*
			// Operations that are always performed
			//----------------------------------------------------------------------------*

			PopulateManufacturersListView();

			UpdateManufacturerTabButtons();
			}

		//============================================================================*
		// OnAddManufacturer()
		//============================================================================*

		protected void OnAddManufacturer(object sender, EventArgs args)
			{
			//----------------------------------------------------------------------------*
			// Start the dialog
			//----------------------------------------------------------------------------*

			cManufacturerForm ManufacturerForm = new cManufacturerForm(null, ref m_DataFiles);

			if (ManufacturerForm.ShowDialog() == DialogResult.OK)
				{
				m_ManufacturersListView.AddManufacturer(ManufacturerForm.Manufacturer, true);

				UpdateManufacturers();
				}

			AddManufacturerButton.Focus();
			}

		//============================================================================*
		// OnEditManufacturer()
		//============================================================================*

		protected void OnEditManufacturer(object sender, EventArgs args)
			{
			//----------------------------------------------------------------------------*
			// Get the selected manufacturer
			//----------------------------------------------------------------------------*

			ListViewItem Item = m_ManufacturersListView.SelectedItems[0];

			if (Item == null)
				return;

			cManufacturer Manufacturer = (cManufacturer) Item.Tag;

			if (Manufacturer == null)
				return;

			//----------------------------------------------------------------------------*
			// Start the dialog
			//----------------------------------------------------------------------------*

			cManufacturerForm ManufacturerForm = new cManufacturerForm(Manufacturer, ref m_DataFiles);

			if (ManufacturerForm.ShowDialog() == DialogResult.OK)
				{
				m_ManufacturersListView.UpdateManufacturer(Manufacturer, ManufacturerForm.Manufacturer, true);

				UpdateManufacturers();
				}

			EditManufacturerButton.Focus();
			}

		//============================================================================*
		// OnManufacturerDoubleClicked()
		//============================================================================*

		protected void OnManufacturerDoubleClicked(object sender, EventArgs args)
			{
			if (!m_fInitialized)
				return;

			if (m_ManufacturersListView.SelectedItems.Count > 0)
				m_DataFiles.Preferences.LastManufacturerSelected = (cManufacturer) (sender as ListView).SelectedItems[0].Tag;

			OnEditManufacturer(sender, args);

			UpdateButtons();
			}

		//============================================================================*
		// OnManufacturerSelected()
		//============================================================================*

		protected void OnManufacturerSelected(object sender, EventArgs args)
			{
			if (!m_fInitialized || m_ManufacturersListView.Populating)
				return;

			if (m_ManufacturersListView.SelectedItems.Count > 0)
				m_DataFiles.Preferences.LastManufacturerSelected = (cManufacturer) (sender as ListView).SelectedItems[0].Tag;

			UpdateButtons();
			}

		//============================================================================*
		// OnRemoveManufacturer()
		//============================================================================*

		protected void OnRemoveManufacturer(object sender, EventArgs args)
			{
			cManufacturer Manufacturer = null;

			ListViewItem Item = m_ManufacturersListView.SelectedItems[0];

			if (Item != null)
				Manufacturer = (cManufacturer) Item.Tag;

			if (Manufacturer == null)
				{
				m_ManufacturersListView.Focus();

				return;
				}

			//----------------------------------------------------------------------------*
			// See if the manufacturer is being used in other records
			//----------------------------------------------------------------------------*

			string strCount = m_DataFiles.DeleteManufacturer(Manufacturer, true);

			if (strCount.Length > 0)
				{
				string strMessage = String.Format("This manufacturer, {0}, is used in\n\n", Manufacturer.Name);
				strMessage += strCount;
				strMessage += "\nThe above item(s) must be removed in order to remove this manufacturer.";

				MessageBox.Show(this, strMessage, "Manufacturer in Use", MessageBoxButtons.OK, MessageBoxIcon.Information);

				m_ManufacturersListView.Focus();

				return;
				}

			//----------------------------------------------------------------------------*
			// Make sure the user is sure
			//----------------------------------------------------------------------------*

			if (MessageBox.Show(this, "Are you sure you wish to remove this manufacturer?", "Data Deletion Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
				{
				m_DataFiles.DeleteManufacturer(Manufacturer);

				m_ManufacturersListView.Items.Remove(Item);

				UpdateButtons();
				}

			m_ManufacturersListView.Focus();
			}

		//============================================================================*
		// OnViewManufacturer()
		//============================================================================*

		protected void OnViewManufacturer(object sender, EventArgs args)
			{
			//----------------------------------------------------------------------------*
			// Get the selected manufacturer
			//----------------------------------------------------------------------------*

			ListViewItem Item = m_ManufacturersListView.SelectedItems[0];

			if (Item == null)
				return;

			cManufacturer Manufacturer = (cManufacturer) Item.Tag;

			if (Manufacturer == null)
				return;

			//----------------------------------------------------------------------------*
			// Start the dialog
			//----------------------------------------------------------------------------*

			cManufacturerForm ManufacturerForm = new cManufacturerForm(Manufacturer, ref m_DataFiles, true);

			ManufacturerForm.ShowDialog();

			ViewManufacturerButton.Focus();
			}

		//============================================================================*
		// PopulateManufacturersListView()
		//============================================================================*

		public void PopulateManufacturersListView()
			{
			m_ManufacturersListView.Populate();
			}

		//============================================================================*
		// UpdateManufacturer()
		//============================================================================*

		private void UpdateManufacturers()
			{
			//----------------------------------------------------------------------------*
			// Update the other tab data
			//----------------------------------------------------------------------------*

			InitializeFirearmTab();
			InitializeSuppliesTab();
			InitializeLoadDataTab();
			InitializeBatchTab();
			InitializeAmmoTab();
			InitializeBallisticsTab();
			}

		//============================================================================*
		// UpdateManufacturerTabButtons()
		//============================================================================*

		private void UpdateManufacturerTabButtons()
			{
			//----------------------------------------------------------------------------*
			// Edit, View, Remove Buttons
			//----------------------------------------------------------------------------*

			EditManufacturerButton.Enabled = m_ManufacturersListView.SelectedItems.Count > 0;
			ViewManufacturerButton.Enabled = m_ManufacturersListView.SelectedItems.Count > 0;
			RemoveManufacturerButton.Enabled = m_ManufacturersListView.SelectedItems.Count > 0;
			}
		}
	}
