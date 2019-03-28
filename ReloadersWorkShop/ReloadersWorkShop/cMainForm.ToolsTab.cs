//============================================================================*
// cMainForm.ToolsTab.cs
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
		// Private Static Data Members
		//============================================================================*

//		private static bool sm_fSkip = true;

		//============================================================================*
		// Private Data Members
		//============================================================================*

		private cToolListView m_ToolsListView = null;

		private bool m_fToolsTabInitialized = false;

		//============================================================================*
		// AddTool()
		//============================================================================*

		private void AddTool(cTool Tool)
			{
			//----------------------------------------------------------------------------*
			// If the Tool already exists, our job is done, just exit
			//----------------------------------------------------------------------------*

			foreach (cTool CheckTool in m_DataFiles.ToolList)
				{
				if (CheckTool.CompareTo(Tool) == 0)
					return;
				}

			//----------------------------------------------------------------------------*
			// Otherwise, add the new firearm to the list
			//----------------------------------------------------------------------------*

			m_DataFiles.ToolList.Add(Tool);

			//----------------------------------------------------------------------------*
			// And add the new Tool to the Tool ListView
			//----------------------------------------------------------------------------*

			m_ToolsListView.AddTool(Tool, true);

			AddToolButton.Focus();
			}

		//============================================================================*
		// InitializeToolTab()
		//============================================================================*

		public void InitializeToolTab()
			{
			if (!m_fToolsTabInitialized)
				{
				m_ToolsListView = new cToolListView(m_DataFiles);

				ToolsTab.Controls.Add(m_ToolsListView);

				AddToolButton.Click += OnAddTool;
				EditToolButton.Click += OnEditTool;
				ViewToolButton.Click += OnViewTool;
				RemoveToolButton.Click += OnRemoveTool;

				m_ToolsListView.SelectedIndexChanged += OnToolSelected;
				m_ToolsListView.DoubleClick += OnToolDoubleClicked;

				ToolsPressesFilterCheckBox.Click += OnToolFilterClicked;
				ToolsPressAccessoriesFilterCheckBox.Click += OnToolFilterClicked;
				ToolsDiesFilterCheckBox.Click += OnToolFilterClicked;
				ToolsDieAccessoriesFilterCheckBox.Click += OnToolFilterClicked;
				ToolsPowderToolsFilterCheckBox.Click += OnToolFilterClicked;
				ToolsCasePrepFilterCheckBox.Click += OnToolFilterClicked;
				ToolsMeasurementToolsFilterCheckBox.Click += OnToolFilterClicked;
				ToolsCastingFilterCheckBox.Click += OnToolFilterClicked;
				ToolsGunsmithingFilterCheckBox.Click += OnToolFilterClicked;
				ToolsBooksFilterCheckBox.Click += OnToolFilterClicked;
				ToolsOtherFilterCheckBox.Click += OnToolFilterClicked;

				m_fToolsTabInitialized = true;
				}

			//----------------------------------------------------------------------------*
			// Operations that are always performed
			//----------------------------------------------------------------------------*

			ToolsPressesFilterCheckBox.Checked = m_DataFiles.Preferences.ToolsPressesFilter;
			ToolsPressAccessoriesFilterCheckBox.Checked = m_DataFiles.Preferences.ToolsPressAccessoriesFilter;
			ToolsDiesFilterCheckBox.Checked = m_DataFiles.Preferences.ToolsDiesFilter;
			ToolsDieAccessoriesFilterCheckBox.Checked = m_DataFiles.Preferences.ToolsDieAccessoriesFilter;
			ToolsPowderToolsFilterCheckBox.Checked = m_DataFiles.Preferences.ToolsPowderToolsFilter;
			ToolsCasePrepFilterCheckBox.Checked = m_DataFiles.Preferences.ToolsCasePrepFilter;
			ToolsMeasurementToolsFilterCheckBox.Checked = m_DataFiles.Preferences.ToolsMeasurementToolsFilter;
			ToolsCastingFilterCheckBox.Checked = m_DataFiles.Preferences.ToolsCastingFilter;
			ToolsGunsmithingFilterCheckBox.Checked = m_DataFiles.Preferences.ToolsGunsmithingFilter;
			ToolsBooksFilterCheckBox.Checked = m_DataFiles.Preferences.ToolsBooksFilter;
			ToolsOtherFilterCheckBox.Checked = m_DataFiles.Preferences.ToolsOtherFilter;

			SetToolsCostDetails();

			UpdateToolsTabButtons();
			}

		//============================================================================*
		// OnAddTool()
		//============================================================================*

		protected void OnAddTool(object sender, EventArgs args)
			{
			//----------------------------------------------------------------------------*
			// Start the dialog
			//----------------------------------------------------------------------------*

			Cursor = Cursors.WaitCursor;

			cToolForm ToolForm = new cToolForm(null, m_DataFiles);

			Cursor = Cursors.Default;

			if (ToolForm.ShowDialog() == DialogResult.OK)
				{
				//----------------------------------------------------------------------------*
				// Get the new Tool Data
				//----------------------------------------------------------------------------*

				cTool NewTool = ToolForm.Tool;
				m_DataFiles.Preferences.LastTool = ToolForm.Tool;

				m_ToolsListView.Focus();

				//----------------------------------------------------------------------------*
				// See if the Tool already exists
				//----------------------------------------------------------------------------*

				foreach (cTool CheckTool in m_DataFiles.ToolList)
					{
					if (CheckTool.CompareTo(NewTool) == 0)
						return;
					}

				AddTool(NewTool);
				}

			UpdateToolsTabButtons();
			}

		//============================================================================*
		// OnEditTool()
		//============================================================================*

		protected void OnEditTool(object sender, EventArgs args)
			{
			//----------------------------------------------------------------------------*
			// Get the selected Firearm
			//----------------------------------------------------------------------------*

			ListViewItem Item = m_ToolsListView.SelectedItems[0];

			if (Item == null)
				return;

			cTool Tool = (cTool)Item.Tag;

			if (Tool == null)
				return;

			//----------------------------------------------------------------------------*
			// Start the dialog
			//----------------------------------------------------------------------------*

			Cursor = Cursors.WaitCursor;

			cToolForm ToolForm = new cToolForm(Tool, m_DataFiles);

			Cursor = Cursors.Default;

			if (ToolForm.ShowDialog() == DialogResult.OK)
				{
				//----------------------------------------------------------------------------*
				// Get the new Tool Data
				//----------------------------------------------------------------------------*

				cTool NewTool = ToolForm.Tool;
				m_DataFiles.Preferences.LastTool = ToolForm.Tool;

				UpdateTool(Tool, NewTool);
				}

			UpdateToolsTabButtons();

			m_ToolsListView.Focus();
			}

		//============================================================================*
		// OnToolDoubleClicked()
		//============================================================================*

		protected void OnToolDoubleClicked(object sender, EventArgs args)
			{
			if (m_ToolsListView.SelectedItems.Count > 0)
				{
				m_DataFiles.Preferences.LastToolSelected = (cTool)(sender as ListView).SelectedItems[0].Tag;

				OnEditTool(sender, args);
				}

			UpdateToolsTabButtons();
			}

		//============================================================================*
		// OnToolFilterClicked()
		//============================================================================*

		protected void OnToolFilterClicked(object sender, EventArgs args)
			{
			switch ((sender as CheckBox).Name)
				{
				case "ToolsPressesFilterCheckBox":
					m_ToolsListView.Filter(cTool.eToolTypes.Press, (sender as CheckBox).Checked);
					m_DataFiles.Preferences.ToolsPressesFilter = (sender as CheckBox).Checked;
					break;

				case "ToolsPressAccessoriesFilterCheckBox":
					m_ToolsListView.Filter(cTool.eToolTypes.PressAccessory, (sender as CheckBox).Checked);
					m_DataFiles.Preferences.ToolsPressAccessoriesFilter = (sender as CheckBox).Checked;
					break;

				case "ToolsDiesFilterCheckBox":
					m_ToolsListView.Filter(cTool.eToolTypes.Die, (sender as CheckBox).Checked);
					m_DataFiles.Preferences.ToolsDiesFilter = (sender as CheckBox).Checked;
					break;

				case "ToolsDieAccessoriesFilterCheckBox":
					m_ToolsListView.Filter(cTool.eToolTypes.DieAccessory, (sender as CheckBox).Checked);
					m_DataFiles.Preferences.ToolsDieAccessoriesFilter = (sender as CheckBox).Checked;
					break;

				case "ToolsPowderToolsFilterCheckBox":
					m_ToolsListView.Filter(cTool.eToolTypes.PowderTool, (sender as CheckBox).Checked);
					m_DataFiles.Preferences.ToolsPowderToolsFilter = (sender as CheckBox).Checked;
					break;

				case "ToolsCasePrepFilterCheckBox":
					m_ToolsListView.Filter(cTool.eToolTypes.CasePrepTool, (sender as CheckBox).Checked);
					m_DataFiles.Preferences.ToolsCasePrepFilter = (sender as CheckBox).Checked;
					break;

				case "ToolsMeasurementToolsFilterCheckBox":
					m_ToolsListView.Filter(cTool.eToolTypes.MeasurementTool, (sender as CheckBox).Checked);
					m_DataFiles.Preferences.ToolsMeasurementToolsFilter = (sender as CheckBox).Checked;
					break;

				case "ToolsCastingFilterCheckBox":
					m_ToolsListView.Filter(cTool.eToolTypes.BulletCasting, (sender as CheckBox).Checked);
					m_DataFiles.Preferences.ToolsCastingFilter = (sender as CheckBox).Checked;
					break;

				case "ToolsGunsmithingFilterCheckBox":
					m_ToolsListView.Filter(cTool.eToolTypes.Gunsmithing, (sender as CheckBox).Checked);
					m_DataFiles.Preferences.ToolsGunsmithingFilter = (sender as CheckBox).Checked;
					break;

				case "ToolsBooksFilterCheckBox":
					m_ToolsListView.Filter(cTool.eToolTypes.Book, (sender as CheckBox).Checked);
					m_DataFiles.Preferences.ToolsBooksFilter = (sender as CheckBox).Checked;
					break;

				case "ToolsOtherFilterCheckBox":
					m_ToolsListView.Filter(cTool.eToolTypes.Other, (sender as CheckBox).Checked);
					m_DataFiles.Preferences.ToolsOtherFilter = (sender as CheckBox).Checked;
					break;
				}

			SetToolsCostDetails();

			UpdateToolsTabButtons();
			}

		//============================================================================*
		// OnToolSelected()
		//============================================================================*

		protected void OnToolSelected(object sender, EventArgs args)
			{
			if (!m_fInitialized || m_ToolsListView.Populating)
				return;

			cTool Tool = null;

			if (m_ToolsListView.SelectedItems.Count > 0)
				{
				Tool = (cTool)m_ToolsListView.SelectedItems[0].Tag;

				m_DataFiles.Preferences.LastToolSelected = Tool;
				}

			UpdateToolsTabButtons();
			}

		//============================================================================*
		// OnRemoveTool()
		//============================================================================*

		protected void OnRemoveTool(object sender, EventArgs args)
			{
			cTool Tool = null;

			ListViewItem Item = m_ToolsListView.SelectedItems[0];

			if (Item != null)
				Tool = (cTool)Item.Tag;

			if (Tool == null)
				{
				m_ToolsListView.Focus();

				return;
				}

			//----------------------------------------------------------------------------*
			// Make sure the user is sure
			//----------------------------------------------------------------------------*

			if (MessageBox.Show(this, "Are you sure you wish to remove this tool/accessory?", "Data Deletion Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
				{
				m_DataFiles.DeleteTool(Tool);

				m_ToolsListView.Items.Remove(Item);
				}

			UpdateToolsTabButtons();

			m_ToolsListView.Focus();
			}

		//============================================================================*
		// OnViewTool()
		//============================================================================*

		protected void OnViewTool(object sender, EventArgs args)
			{
			//----------------------------------------------------------------------------*
			// Get the selected object
			//----------------------------------------------------------------------------*

			ListViewItem Item = m_ToolsListView.SelectedItems[0];

			if (Item == null)
				return;

			cTool Tool = (cTool)Item.Tag;

			if (Tool == null)
				return;

			//----------------------------------------------------------------------------*
			// Start the dialog
			//----------------------------------------------------------------------------*

			Cursor = Cursors.WaitCursor;

			cToolForm ToolForm = new cToolForm(Tool, m_DataFiles, true);

			Cursor = Cursors.Default;

			ToolForm.ShowDialog();

			m_ToolsListView.Focus();
			}

		//============================================================================*
		// PopulateToolsListView()
		//============================================================================*

		public void PopulateToolsListView()
			{
			m_ToolsListView.Populate();

			UpdateToolsTabButtons();
			}

		//============================================================================*
		// SetToolsCostDetails()
		//============================================================================*

		public void SetToolsCostDetails()
			{
			int nCount = 0;
			double dTotalCost = 0.0;
			double dTotalTaxes = 0.0;
			double dTotalShipping = 0.0;
			double dGrandTotal = 0.0;

			foreach (ListViewItem Item in m_ToolsListView.Items)
				{
				cTool Tool = (cTool)Item.Tag;

				if (Tool != null)
					{
					nCount++;

					dTotalTaxes += Tool.Tax;
					dTotalShipping += Tool.Shipping;

					dTotalCost += Tool.PurchasePrice;
					}
				}

			dGrandTotal = dTotalCost + dTotalTaxes + dTotalShipping;

			ToolsCountLabel.Text = String.Format("{0}", nCount);

			ToolsTotalCostLabel.Text = String.Format("{0:N2}", dTotalCost);

			ToolsTotalTaxLabel.Text = string.Format("{0:N2}", dTotalTaxes);
			ToolsTotalShippingLabel.Text = string.Format("{0:N2}", dTotalShipping);

			dGrandTotal = dTotalCost + dTotalTaxes + dTotalShipping;

			ToolsGrandTotalLabel.Text = string.Format("{0}{1:N2}", m_DataFiles.Preferences.Currency, dGrandTotal);
			}

		//============================================================================*
		// UpdateTool()
		//============================================================================*

		private void UpdateTool(cTool OldTool, cTool NewTool)
			{
			//----------------------------------------------------------------------------*
			// Find the NewFirearm
			//----------------------------------------------------------------------------*

			foreach (cTool CheckTool in m_DataFiles.ToolList)
				{
				//----------------------------------------------------------------------------*
				// See if this is the same Firearm
				//----------------------------------------------------------------------------*

				if (CheckTool.CompareTo(OldTool) == 0)
					{
					//----------------------------------------------------------------------------*
					// Update the current Tool record
					//----------------------------------------------------------------------------*

					CheckTool.Copy(NewTool);

					//----------------------------------------------------------------------------*
					// Update the Firearm on the Firearm tab
					//----------------------------------------------------------------------------*

					ListViewItem Item = null;

					foreach (ListViewItem CheckItem in m_ToolsListView.Items)
						{
						if ((CheckItem.Tag as cTool).CompareTo(CheckTool) == 0)
							{
							Item = CheckItem;

							break;
							}
						}

					if (Item != null)
						{
						try
							{
							m_ToolsListView.Items.Remove(Item);
							}
						catch
							{
							// No need to do anything here
							}

						m_ToolsListView.AddTool(CheckTool, true);
						}

					return;
					}
				}

			//----------------------------------------------------------------------------*
			// If the NewFirearm was not found, add it
			//----------------------------------------------------------------------------*

			AddTool(NewTool);
			}

		//============================================================================*
		// UpdateToolsTabButtons()
		//============================================================================*

		private void UpdateToolsTabButtons()
			{
			if (!m_fToolsTabInitialized)
				return;

			SetToolsCostDetails();

			//----------------------------------------------------------------------------*
			// Edit, View, Remove Buttons
			//----------------------------------------------------------------------------*

			EditToolButton.Enabled = m_ToolsListView.SelectedItems.Count > 0;
			ViewToolButton.Enabled = m_ToolsListView.SelectedItems.Count > 0;
			RemoveToolButton.Enabled = m_ToolsListView.SelectedItems.Count > 0;
			}
		}
	}
