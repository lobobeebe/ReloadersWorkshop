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
		// Private Static Data Members
		//============================================================================*

		private static bool sm_fSkip = true;

		//============================================================================*
		// Private Data Members
		//============================================================================*

		private cFirearmListView m_FirearmsListView = null;
		private cFirearmAccessoryListView m_FirearmAccessoriesListView = null;

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
		// AddFirearmAccessory()
		//============================================================================*

		private void AddFirearmAccessory(cGear Gear)
			{
			//----------------------------------------------------------------------------*
			// If the Gear already exists, our job is done, just exit
			//----------------------------------------------------------------------------*

			foreach (cGear CheckGear in m_DataFiles.GearList)
				{
				if (CheckGear.CompareTo(Gear) == 0)
					return;
				}

			//----------------------------------------------------------------------------*
			// Otherwise, add the new firearm to the list
			//----------------------------------------------------------------------------*

			m_DataFiles.GearList.Add(Gear);

			//----------------------------------------------------------------------------*
			// And add the new Firearm to the Firearm ListView
			//----------------------------------------------------------------------------*

			m_FirearmAccessoriesListView.AddFirearmAccessory(Gear, true);

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

				FirearmsGroupBox.Controls.Add(m_FirearmsListView);

				m_FirearmAccessoriesListView = new cFirearmAccessoryListView(m_DataFiles);

				FirearmAccessoriesGroupBox.Controls.Add(m_FirearmAccessoriesListView);

				AddFirearmButton.Click += OnAddFirearm;
				EditFirearmButton.Click += OnEditFirearm;
				ViewFirearmButton.Click += OnViewFirearm;
				RemoveFirearmButton.Click += OnRemoveFirearm;

				AddFirearmAccessoryButton.Click += OnAddFirearmAccessory;
				EditFirearmAccessoryButton.Click += OnEditFirearmAccessory;
				ViewFirearmAccessoryButton.Click += OnViewFirearmAccessory;
				RemoveFirearmAccessoryButton.Click += OnRemoveFirearmAccessory;

				FirearmPrintButton.Click += OnFirearmPrintClicked;

				FirearmPrintAllRadioButton.Click += OnFirearmPrintAllClicked;
				FirearmPrintCheckedRadioButton.Click += OnFirearmPrintCheckedClicked;
				FirearmPrintDetailCheckBox.Click += OnFirearmPrintDetailClicked;
				FirearmPrintSpecsCheckBox.Click += OnFirearmPrintSpecsClicked;

				m_FirearmsListView.SelectedIndexChanged += OnFirearmSelected;
				m_FirearmsListView.DoubleClick += OnFirearmDoubleClicked;

				m_FirearmsListView.ItemChecked += OnFirearmChecked;

				m_FirearmAccessoriesListView.SelectedIndexChanged += OnFirearmAccessorySelected;
				m_FirearmAccessoriesListView.DoubleClick += OnFirearmAccessoryDoubleClicked;

				FirearmAccessoriesShowAllCheckBox.Click += OnFirearmAccessoriesShowAllClicked;

				FirearmAccessoriesShowGroupsCheckBox.Click += OnFirearmAccessoriesShowGroupsClicked;

				FirearmAccessoryAttachButton.Click += OnFirearmAccessoryAttachClicked;
				FirearmAccessoriesPrintButton.Click += OnFirearmAccessoriesPrintClicked;

				FirearmsScopeFilterCheckBox.Click += OnFirearmFilterClicked;
				FirearmsLaserFilterCheckBox.Click += OnFirearmFilterClicked;
				FirearmsRedDotFilterCheckBox.Click += OnFirearmFilterClicked;
				FirearmsMagnifierFilterCheckBox.Click += OnFirearmFilterClicked;
				FirearmsLightFilterCheckBox.Click += OnFirearmFilterClicked;
				FirearmsTriggerFilterCheckBox.Click += OnFirearmFilterClicked;
				FirearmsFurnitureFilterCheckBox.Click += OnFirearmFilterClicked;
				FirearmsBipodFilterCheckBox.Click += OnFirearmFilterClicked;
				FirearmsPartsFilterCheckBox.Click += OnFirearmFilterClicked;
				FirearmsOtherFilterCheckBox.Click += OnFirearmFilterClicked;

				m_fFirearmTabInitialized = true;
				}

			//----------------------------------------------------------------------------*
			// Operations that are always performed
			//----------------------------------------------------------------------------*

			FirearmPrintAllRadioButton.Checked = m_DataFiles.Preferences.FirearmPrintAll;
			FirearmPrintCheckedRadioButton.Checked = !m_DataFiles.Preferences.FirearmPrintAll;
			FirearmPrintDetailCheckBox.Checked = m_DataFiles.Preferences.FirearmPrintDetail;
			FirearmPrintSpecsCheckBox.Checked = m_DataFiles.Preferences.FirearmPrintSpecs;

			FirearmCostDetailsGroupBox.Text = String.Format("{0} ({1})", FirearmCostDetailsGroupBox.Text, m_DataFiles.Preferences.Currency);
			FirearmCollectionGroupBox.Text = String.Format("{0} ({1})", FirearmCollectionGroupBox.Text, m_DataFiles.Preferences.Currency);
			FirearmAccessoriesCostDetailsGroupBox.Text = String.Format("{0} ({1})", FirearmAccessoriesCostDetailsGroupBox.Text, m_DataFiles.Preferences.Currency);

			FirearmAccessoriesShowAllCheckBox.Checked = m_DataFiles.Preferences.FirearmAccessoryShowAll;
			FirearmAccessoriesShowGroupsCheckBox.Checked = m_DataFiles.Preferences.FirearmAccessoryShowGroups;

			FirearmsScopeFilterCheckBox.Checked = m_DataFiles.Preferences.FirearmAccessoryScopeFilter;
			FirearmsLaserFilterCheckBox.Checked = m_DataFiles.Preferences.FirearmAccessoryLaserFilter;
			FirearmsRedDotFilterCheckBox.Checked = m_DataFiles.Preferences.FirearmAccessoryRedDotFilter;
			FirearmsMagnifierFilterCheckBox.Checked = m_DataFiles.Preferences.FirearmAccessoryMagnifierFilter;
			FirearmsLightFilterCheckBox.Checked = m_DataFiles.Preferences.FirearmAccessoryLightFilter;
			FirearmsTriggerFilterCheckBox.Checked = m_DataFiles.Preferences.FirearmAccessoryTriggerFilter;
			FirearmsFurnitureFilterCheckBox.Checked = m_DataFiles.Preferences.FirearmAccessoryFurnitureFilter;
			FirearmsBipodFilterCheckBox.Checked = m_DataFiles.Preferences.FirearmAccessoryBipodFilter;
			FirearmsPartsFilterCheckBox.Checked = m_DataFiles.Preferences.FirearmAccessoryPartsFilter;
			FirearmsOtherFilterCheckBox.Checked = m_DataFiles.Preferences.FirearmAccessoryOtherFilter;

			cFirearm Firearm = null;

			if (m_FirearmsListView.SelectedItems.Count > 0 && !FirearmAccessoriesShowAllCheckBox.Checked)
				Firearm = (cFirearm) m_FirearmsListView.SelectedItems[0].Tag;

			m_FirearmAccessoriesListView.Firearm = Firearm;

			m_FirearmAccessoriesListView.ShowGroups = m_DataFiles.Preferences.FirearmAccessoryShowGroups;

			SetAccessoriesGroupText(Firearm);
			SetFirearmAttachButton();

			SetFirearmCostDetails();

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
		// OnAddFirearmAccessory()
		//============================================================================*

		protected void OnAddFirearmAccessory(object sender, EventArgs args)
			{
			//----------------------------------------------------------------------------*
			// Start the dialog
			//----------------------------------------------------------------------------*

			cFirearmAccessoryForm FirearmAccessoryForm = new cFirearmAccessoryForm(null, m_DataFiles);

			if (FirearmAccessoryForm.ShowDialog() == DialogResult.OK)
				{
				//----------------------------------------------------------------------------*
				// Get the new Firearm Data
				//----------------------------------------------------------------------------*

				cGear NewGear = FirearmAccessoryForm.Gear;

				//----------------------------------------------------------------------------*
				// See if the Firearm Accessory already exists
				//----------------------------------------------------------------------------*

				foreach (cGear CheckGear in m_DataFiles.GearList)
					{
					if (CheckGear.CompareTo(NewGear) == 0)
						return;
					}

				AddFirearmAccessory(NewGear);
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

			cFirearm Firearm = (cFirearm) Item.Tag;

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
		// OnEditFirearmAccessory()
		//============================================================================*

		protected void OnEditFirearmAccessory(object sender, EventArgs args)
			{
			if (m_FirearmAccessoriesListView.SelectedItems.Count == 0)
				return;

			//----------------------------------------------------------------------------*
			// Get the selected Firearm
			//----------------------------------------------------------------------------*

			ListViewItem Item = m_FirearmAccessoriesListView.SelectedItems[0];

			if (Item == null)
				return;

			cGear Gear = (cGear) Item.Tag;

			if (Gear == null)
				return;

			//----------------------------------------------------------------------------*
			// Start the dialog
			//----------------------------------------------------------------------------*

			cFirearmAccessoryForm FirearmAccessoryForm = new cFirearmAccessoryForm(Gear, m_DataFiles);

			if (FirearmAccessoryForm.ShowDialog() == DialogResult.OK)
				{
				//----------------------------------------------------------------------------*
				// Get the new Firearm Data
				//----------------------------------------------------------------------------*

				cGear NewGear = FirearmAccessoryForm.Gear;

				UpdateFirearmAccessory(Gear, NewGear);
				}

			UpdateFirearmTabButtons();
			}

		//============================================================================*
		// OnFirearmAccessoriesPrintClicked()
		//============================================================================*

		protected void OnFirearmAccessoriesPrintClicked(object sender, EventArgs args)
			{
			cGearList GearList = new cGearList();

			cFirearm Firearm = null;

			if (!FirearmAccessoriesShowAllCheckBox.Checked && m_FirearmsListView.SelectedItems.Count > 0)
				Firearm = (cFirearm) m_FirearmsListView.SelectedItems[0].Tag;

			foreach (ListViewItem Item in m_FirearmAccessoriesListView.Items)
				{
				cGear Gear = (cGear) Item.Tag;

				if (Gear != null)
					GearList.Add(Gear);
				}

			cFirearmAccessoryListPreviewDialog FirearmAccessoryListDialog = new cFirearmAccessoryListPreviewDialog(m_DataFiles, true, FirearmAccessoriesShowGroupsCheckBox.Checked);

			cFirearmAccessoryListPreviewDialog.Firearm = Firearm;
			cFirearmAccessoryListPreviewDialog.GearList = GearList;

			FirearmAccessoryListDialog.ShowDialog();
			}

		//============================================================================*
		// OnFirearmAccessoriesShowAllClicked()
		//============================================================================*

		protected void OnFirearmAccessoriesShowAllClicked(object sender, EventArgs args)
			{
			cFirearm Firearm = null;

			if (!FirearmAccessoriesShowAllCheckBox.Checked)
				{
				if (m_FirearmsListView.SelectedItems.Count > 0)
					Firearm = (cFirearm) m_FirearmsListView.SelectedItems[0].Tag;
				}

			m_FirearmAccessoriesListView.Firearm = Firearm;

			m_DataFiles.Preferences.FirearmAccessoryShowAll = FirearmAccessoriesShowAllCheckBox.Checked;

			SetAccessoriesGroupText(Firearm);
			SetFirearmAccessoriesCostDetails();

			UpdateFirearmTabButtons();
			}

		//============================================================================*
		// OnFirearmAccessoriesShowGroupsClicked()
		//============================================================================*

		protected void OnFirearmAccessoriesShowGroupsClicked(object sender, EventArgs args)
			{
			m_FirearmAccessoriesListView.ShowGroups = FirearmAccessoriesShowGroupsCheckBox.Checked;
			m_FirearmAccessoriesListView.Populate();
			SetFirearmAttachButton();
			SetFirearmAccessoriesCostDetails();

			m_DataFiles.Preferences.FirearmAccessoryShowGroups = FirearmAccessoriesShowGroupsCheckBox.Checked;

			UpdateFirearmTabButtons();
			}

		//============================================================================*
		// OnFirearmAccessoryAttachClicked()
		//============================================================================*

		protected void OnFirearmAccessoryAttachClicked(object sender, EventArgs args)
			{
			cFirearm Firearm = null;

			if (m_FirearmsListView.SelectedItems.Count > 0)
				Firearm = (cFirearm) m_FirearmsListView.SelectedItems[0].Tag;

			if (m_FirearmAccessoriesListView.SelectedItems.Count > 0)
				{
				cGear Gear = (cGear) m_FirearmAccessoriesListView.SelectedItems[0].Tag;

				if (Gear.Parent != null)
					Gear.Parent = null;
				else
					Gear.Parent = Firearm;

				if (FirearmAccessoriesShowAllCheckBox.Checked)
					m_FirearmAccessoriesListView.UpdateFirearmAccessory(Gear, true);
				else
					{
					m_FirearmAccessoriesListView.Populate();

					SetFirearmAccessoriesCostDetails();
					}

				UpdateFirearmTabButtons();
				}
			}

		//============================================================================*
		// OnFirearmAccessorySelected()
		//============================================================================*

		protected void OnFirearmAccessorySelected(object sender, EventArgs args)
			{
			if (!m_fInitialized || m_FirearmAccessoriesListView.Populating)
				return;

			cGear Gear = null;

			if (m_FirearmAccessoriesListView.SelectedItems.Count > 0)
				{
				Gear = (cGear) m_FirearmAccessoriesListView.SelectedItems[0].Tag;

				m_DataFiles.Preferences.LastFirearmAccessorySelected = Gear;
				}

			UpdateFirearmTabButtons();
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
				m_DataFiles.Preferences.LastFirearmSelected = (cFirearm) (sender as ListView).SelectedItems[0].Tag;

				OnEditFirearm(sender, args);
				}

			UpdateFirearmTabButtons();
			}

		//============================================================================*
		// OnFirearmAccessoryDoubleClicked()
		//============================================================================*

		protected void OnFirearmAccessoryDoubleClicked(object sender, EventArgs args)
			{
			if (m_FirearmAccessoriesListView.SelectedItems.Count > 0)
				{
				OnEditFirearmAccessory(sender, args);
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

			cFirearmAccessoryListPreviewDialog.DrawGroups = false; // FirearmAccessoriesShowGroupsCheckBox.Checked;

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
		// OnFirearmFilterClicked()
		//============================================================================*

		protected void OnFirearmFilterClicked(object sender, EventArgs args)
			{
			switch ((sender as CheckBox).Name)
				{
				case "FirearmsScopeFilterCheckBox":
					m_FirearmAccessoriesListView.Filter(cGear.eGearTypes.Scope, (sender as CheckBox).Checked);
					m_DataFiles.Preferences.FirearmAccessoryScopeFilter = (sender as CheckBox).Checked;
					break;

				case "FirearmsLaserFilterCheckBox":
					m_FirearmAccessoriesListView.Filter(cGear.eGearTypes.Laser, (sender as CheckBox).Checked);
					m_DataFiles.Preferences.FirearmAccessoryLaserFilter = (sender as CheckBox).Checked;
					break;

				case "FirearmsRedDotFilterCheckBox":
					m_FirearmAccessoriesListView.Filter(cGear.eGearTypes.RedDot, (sender as CheckBox).Checked);
					m_DataFiles.Preferences.FirearmAccessoryRedDotFilter = (sender as CheckBox).Checked;
					break;

				case "FirearmsMagnifierFilterCheckBox":
					m_FirearmAccessoriesListView.Filter(cGear.eGearTypes.Magnifier, (sender as CheckBox).Checked);
					m_DataFiles.Preferences.FirearmAccessoryMagnifierFilter = (sender as CheckBox).Checked;
					break;

				case "FirearmsLightFilterCheckBox":
					m_FirearmAccessoriesListView.Filter(cGear.eGearTypes.Light, (sender as CheckBox).Checked);
					m_DataFiles.Preferences.FirearmAccessoryLightFilter = (sender as CheckBox).Checked;
					break;

				case "FirearmsTriggerFilterCheckBox":
					m_FirearmAccessoriesListView.Filter(cGear.eGearTypes.Trigger, (sender as CheckBox).Checked);
					m_DataFiles.Preferences.FirearmAccessoryTriggerFilter = (sender as CheckBox).Checked;
					break;

				case "FirearmsFurnitureFilterCheckBox":
					m_FirearmAccessoriesListView.Filter(cGear.eGearTypes.Furniture, (sender as CheckBox).Checked);
					m_DataFiles.Preferences.FirearmAccessoryFurnitureFilter = (sender as CheckBox).Checked;
					break;

				case "FirearmsBipodFilterCheckBox":
					m_FirearmAccessoriesListView.Filter(cGear.eGearTypes.Bipod, (sender as CheckBox).Checked);
					m_DataFiles.Preferences.FirearmAccessoryBipodFilter = (sender as CheckBox).Checked;
					break;

				case "FirearmsPartsFilterCheckBox":
					m_FirearmAccessoriesListView.Filter(cGear.eGearTypes.Parts, (sender as CheckBox).Checked);
					m_DataFiles.Preferences.FirearmAccessoryPartsFilter = (sender as CheckBox).Checked;
					break;

				case "FirearmsOtherFilterCheckBox":
					m_FirearmAccessoriesListView.Filter(cGear.eGearTypes.Misc, (sender as CheckBox).Checked);
					m_DataFiles.Preferences.FirearmAccessoryOtherFilter = (sender as CheckBox).Checked;
					break;
				}

			SetFirearmAccessoriesCostDetails();

			UpdateFirearmTabButtons();
			}

		//============================================================================*
		// OnFirearmSelected()
		//============================================================================*

		protected void OnFirearmSelected(object sender, EventArgs args)
			{
			if (!m_fInitialized || m_FirearmsListView.Populating)
				return;

			if (sm_fSkip)
				{
				sm_fSkip = false;

				return;
				}
			else
				sm_fSkip = true;

			cFirearm Firearm = null;

			if (m_FirearmsListView.SelectedItems.Count > 0)
				{
				Firearm = (cFirearm) m_FirearmsListView.SelectedItems[0].Tag;

				m_DataFiles.Preferences.LastFirearmSelected = Firearm;

				m_FirearmAccessoriesListView.Firearm = !FirearmAccessoriesShowAllCheckBox.Checked ? Firearm : null;
				}
			else
				{
				m_FirearmAccessoriesListView.Firearm = null;
				}

			SetAccessoriesGroupText(m_FirearmAccessoriesListView.Firearm);

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
				Firearm = (cFirearm) Item.Tag;

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
		// OnRemoveFirearmAccessory()
		//============================================================================*

		protected void OnRemoveFirearmAccessory(object sender, EventArgs args)
			{
			if (m_FirearmAccessoriesListView.SelectedItems.Count == 0)
				return;

			cGear Gear = null;

			ListViewItem Item = m_FirearmAccessoriesListView.SelectedItems[0];

			if (Item != null)
				Gear = (cGear) Item.Tag;

			if (Gear == null || Gear.Parent != null)
				{
				//				m_FirearmAccessoriesListView.Focus();

				return;
				}

			//----------------------------------------------------------------------------*
			// Make sure the user is sure
			//----------------------------------------------------------------------------*

			string strText = String.Format("Are you sure you wish to remove this {0}?", cGear.GearTypeString(Gear.GearType));

			if (MessageBox.Show(this, strText, "Data Deletion Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
				{
				m_DataFiles.DeleteFirearmAccessory(Gear);

				m_FirearmAccessoriesListView.Items.Remove(Item);
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

			cFirearm Firearm = (cFirearm) Item.Tag;

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
		// OnViewFirearmAccessory()
		//============================================================================*

		protected void OnViewFirearmAccessory(object sender, EventArgs args)
			{
			//----------------------------------------------------------------------------*
			// Get the selected object
			//----------------------------------------------------------------------------*

			if (m_FirearmAccessoriesListView.SelectedItems.Count == 0)
				return;

			ListViewItem Item = m_FirearmAccessoriesListView.SelectedItems[0];

			if (Item == null)
				return;

			cGear Gear = (cGear) Item.Tag;

			if (Gear == null)
				return;

			//----------------------------------------------------------------------------*
			// Start the dialog
			//----------------------------------------------------------------------------*

			cFirearmAccessoryForm FirearmAccessoryForm = new cFirearmAccessoryForm(Gear, m_DataFiles, true);

			FirearmAccessoryForm.ShowDialog();

			//			m_FirearmAccessoriesListView.Focus();
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
		// SetAccessoriesGroupText()
		//============================================================================*

		public void SetAccessoriesGroupText(cFirearm Firearm)
			{
			string strText = "Parts && Accessories";

			if (Firearm != null)
				{
				strText += " for ";

				string strFirearm = @Firearm.ToString();

				strFirearm = strFirearm.Replace("&", "&&");

				strText += strFirearm;
				}
			else
				strText = "All " + strText;

			FirearmAccessoriesGroupBox.Text = strText;
			}

		//============================================================================*
		// SetFirearmAttachButton()
		//============================================================================*

		public void SetFirearmAttachButton()
			{
			string strText = "Attach";

			FirearmAccessoryAttachButton.Enabled = false;

			cGear Gear = null;

			if (m_FirearmAccessoriesListView.SelectedItems.Count > 0)
				{
				Gear = (cGear) m_FirearmAccessoriesListView.SelectedItems[0].Tag;

				if (Gear != null)
					{
					if (Gear.Parent != null)
						{
						strText = "Detach";
						FirearmAccessoryAttachButton.Enabled = true;

						RemoveFirearmAccessoryButton.Enabled = false;
						}
					else
						{
						strText = "Attach";
						FirearmAccessoryAttachButton.Enabled = m_FirearmsListView.SelectedItems.Count > 0;
						}
					}
				}

			FirearmAccessoryAttachButton.Text = strText;
			}

		//============================================================================*
		// SetFirearmCostDetails()
		//============================================================================*

		public void SetFirearmCostDetails()
			{
			cFirearm Firearm = null;

			if (m_FirearmsListView.SelectedItems.Count > 0)
				Firearm = (cFirearm) m_FirearmsListView.SelectedItems[0].Tag;

			double dFirearmCost = 0.0;
			double dTotalCost = 0.0;
			double dTotalTaxes = 0.0;
			double dTotalShipping = 0.0;
			double dAccessoryTotalCost = 0.0;
			double dGrandTotal = 0.0;
			double dTransferFees = 0.0;
			double dOtherFees = 0.0;

			if (Firearm != null)
				{
				dFirearmCost = Firearm.PurchasePrice;
				dTotalTaxes = Firearm.Tax;
				dTotalShipping = Firearm.Shipping;
				dTransferFees = Firearm.TransferFees;
				dOtherFees = Firearm.OtherFees;

				dTotalCost = dFirearmCost + dTransferFees + dOtherFees;

				foreach (cGear Gear in m_DataFiles.GearList)
					{
					if (Gear.Parent != null && Gear.Parent.CompareTo(Firearm) == 0)
						{
						dAccessoryTotalCost += Gear.PurchasePrice;

						dTotalTaxes += Gear.Tax;
						dTotalShipping += Gear.Shipping;
						}
					}

				dTotalCost += dAccessoryTotalCost;
				}

			FirearmCostLabel.Text = String.Format("{0:N2}", dFirearmCost);
			FirearmAccessoryCostLabel.Text = String.Format("{0:N2}", dAccessoryTotalCost);

			FirearmTotalCostsLabel.Text = string.Format("{0:N2}", dTotalCost);
			FirearmTotalTaxesLabel.Text = string.Format("{0:N2}", dTotalTaxes);
			FirearmTotalShippingLabel.Text = string.Format("{0:N2}", dTotalShipping);
			FirearmTransferFeesLabel.Text = string.Format("{0:N2}", dTransferFees);
			FirearmOtherFeesLabel.Text = string.Format("{0:N2}", dOtherFees);

			dGrandTotal += dTotalCost + dTotalTaxes + dTotalShipping + dTransferFees + dOtherFees;

			FirearmGrandTotalLabel.Text = string.Format("{0}{1:N2}", m_DataFiles.Preferences.Currency, dGrandTotal);

			SetFirearmCollectionCostDetails();
			}

		//============================================================================*
		// SetFirearmAccessoriesCostDetails()
		//============================================================================*

		public void SetFirearmAccessoriesCostDetails()
			{
			int nCount = 0;
			double dTotalCost = 0.0;
			double dTotalTaxes = 0.0;
			double dTotalShipping = 0.0;
			double dGrandTotal = 0.0;

			foreach (ListViewItem Item in m_FirearmAccessoriesListView.Items)
				{
				cGear Gear = (cGear) Item.Tag;

				if (Gear != null)
					{
					nCount++;

					dTotalTaxes += Gear.Tax;
					dTotalShipping += Gear.Shipping;

					dTotalCost += Gear.PurchasePrice;
					}
				}

			dGrandTotal = dTotalCost + dTotalTaxes + dTotalShipping;

			FirearmAccessoriesCountLabel.Text = String.Format("{0}", nCount);

			FirearmAccessoriesTotalCostLabel.Text = String.Format("{0:N2}", dTotalCost);

			FirearmAccessoriesTotalTaxLabel.Text = string.Format("{0:N2}", dTotalTaxes);
			FirearmAccessoriesTotalShippingLabel.Text = string.Format("{0:N2}", dTotalShipping);

			dGrandTotal = dTotalCost + dTotalTaxes + dTotalShipping;

			FirearmAccessoriesGrandTotalLabel.Text = string.Format("{0}{1:N2}", m_DataFiles.Preferences.Currency, dGrandTotal);
			}

		//============================================================================*
		// SetFirearmCollectionCostDetails()
		//============================================================================*

		public void SetFirearmCollectionCostDetails()
			{
			double dFirearmCost = 0.0;
			double dTotalCost = 0.0;
			double dTotalTaxes = 0.0;
			double dTotalShipping = 0.0;
			double dAccessoryTotalCost = 0.0;
			double dGrandTotal = 0.0;
			double dTransferFees = 0.0;
			double dOtherFees = 0.0;

			foreach (cFirearm Firearm in m_DataFiles.FirearmList)
				{
				if (Firearm != null)
					{
					dFirearmCost += Firearm.PurchasePrice;
					dTotalTaxes += Firearm.Tax;
					dTotalShipping += Firearm.Shipping;
					dTransferFees += Firearm.TransferFees;
					dOtherFees += Firearm.OtherFees;

					dTotalCost += Firearm.PurchasePrice + Firearm.TransferFees + Firearm.OtherFees;

					foreach (cGear Gear in m_DataFiles.GearList)
						{
						if (Gear.Parent != null && Gear.Parent.CompareTo(Firearm) == 0)
							{
							dAccessoryTotalCost += Gear.PurchasePrice;

							dTotalTaxes += Gear.Tax;
							dTotalShipping += Gear.Shipping;
							}
						}

					dTotalCost += dAccessoryTotalCost;
					}
				}

			FirearmCollectionCostLabel.Text = String.Format("{0:N2}", dFirearmCost);
			FirearmCollectionAccessoryCostLabel.Text = String.Format("{0:N2}", dAccessoryTotalCost);

			FirearmCollectionTotalCostLabel.Text = string.Format("{0:N2}", dTotalCost);
			FirearmCollectionTotalTaxLabel.Text = string.Format("{0:N2}", dTotalTaxes);
			FirearmCollectionTotalShippingLabel.Text = string.Format("{0:N2}", dTotalShipping);
			FirearmCollectionTransferFeesLabel.Text = string.Format("{0:N2}", dTransferFees);
			FirearmCollectionOtherFeesLabel.Text = string.Format("{0:N2}", dOtherFees);

			dGrandTotal += dTotalCost + dTotalTaxes + dTotalShipping + dTransferFees + dOtherFees;

			FirearmCollectionGrandTotalLabel.Text = string.Format("{0}{1:N2}", m_DataFiles.Preferences.Currency, dGrandTotal);

			SetFirearmAccessoriesCostDetails();
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
		// UpdateFirearmAccessory()
		//============================================================================*

		private void UpdateFirearmAccessory(cGear OldGear, cGear NewGear)
			{
			//----------------------------------------------------------------------------*
			// Find the NewGear
			//----------------------------------------------------------------------------*

			foreach (cGear CheckGear in m_DataFiles.GearList)
				{
				//----------------------------------------------------------------------------*
				// See if this is the same Gear
				//----------------------------------------------------------------------------*

				if (CheckGear.CompareTo(OldGear) == 0)
					{
					//----------------------------------------------------------------------------*
					// Update the current Firearm record
					//----------------------------------------------------------------------------*

					CheckGear.Copy(NewGear);

					//----------------------------------------------------------------------------*
					// Update the Gear on the Gear tab
					//----------------------------------------------------------------------------*

					ListViewItem Item = null;

					foreach (ListViewItem CheckItem in m_FirearmAccessoriesListView.Items)
						{
						if ((CheckItem.Tag as cGear).CompareTo(CheckGear) == 0)
							{
							Item = CheckItem;

							break;
							}
						}

					if (Item != null)
						{
						try
							{
							m_FirearmAccessoriesListView.Items.Remove(Item);
							}
						catch
							{
							// No need to do anything here
							}

						m_FirearmAccessoriesListView.AddFirearmAccessory(CheckGear, true);
						}

					return;
					}
				}

			//----------------------------------------------------------------------------*
			// If the NewFirearm was not found, add it
			//----------------------------------------------------------------------------*

			AddFirearmAccessory(NewGear);
			}

		//============================================================================*
		// UpdateFirearmTabButtons()
		//============================================================================*

		private void UpdateFirearmTabButtons()
			{
			if (!m_fInitialized)
				return;

			SetFirearmCostDetails();

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

			FirearmAccessoriesShowAllCheckBox.Checked = m_FirearmsListView.SelectedItems.Count > 0 ? FirearmAccessoriesShowAllCheckBox.Checked : true;
			FirearmAccessoriesShowAllCheckBox.Enabled = m_FirearmsListView.SelectedItems.Count > 0;

			FirearmAccessoriesPrintButton.Enabled = m_FirearmAccessoriesListView.Items.Count > 0;

			//----------------------------------------------------------------------------*
			// Edit, View, Remove Buttons
			//----------------------------------------------------------------------------*

			EditFirearmButton.Enabled = m_FirearmsListView.SelectedItems.Count > 0;
			ViewFirearmButton.Enabled = m_FirearmsListView.SelectedItems.Count > 0;
			RemoveFirearmButton.Enabled = m_FirearmsListView.SelectedItems.Count > 0;

			EditFirearmAccessoryButton.Enabled = m_FirearmAccessoriesListView.SelectedItems.Count > 0;
			ViewFirearmAccessoryButton.Enabled = m_FirearmAccessoriesListView.SelectedItems.Count > 0;
			RemoveFirearmAccessoryButton.Enabled = m_FirearmAccessoriesListView.SelectedItems.Count > 0;

			SetFirearmAttachButton();
			}
		}
	}
