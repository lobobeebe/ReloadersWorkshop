
// cPrimerForm.cs
//
// Copyright © 2013-2014, Kevin S. Beebe
// All Rights Reserved
//============================================================================*

//============================================================================*
// .Net Using Statements
//============================================================================*

using System;
using System.Drawing;
using System.Windows.Forms;

using ReloadersWorkShop.Preferences;

//============================================================================*
// NameSpace
//============================================================================*

namespace ReloadersWorkShop
	{
	//============================================================================*
	// cPrimerForm Class
	//============================================================================*

	public partial class cPrimerForm : Form
		{
		//----------------------------------------------------------------------------*
		// Private Const Data Members
		//----------------------------------------------------------------------------*

		private const string cm_strFirearmTypeToolTip = "Type of Firearm for which this primer is designed.";
		private const string cm_strManufacturerToolTip = "Manufacturer of this primer.";
		private const string cm_strModelToolTip = "Manufacturer's model number or Type for this primer.";
		private const string cm_strPrimerSizeToolTip = "Size of this primer.";
		private const string cm_strStandardToolTip = "Indicates that this primer is designed for standard cartridges.";
		private const string cm_strMagnumToolTip = "Indicates that this primer is designed for magnum cartridges.";
		private const string cm_strMilitaryToolTip = "Indicates that this primer is designed for military cartridges.";
		private const string cm_strBenchRestToolTip = "Indicates that this primer is designed for Bench Rest cartridges.";

		private const string cm_strQuantityToolTip = "Quantity and price values used to calculate batch costs.";
		private const string cm_strPriceToolTip = "Quantity and price values used to calculate batch costs.";

		private const string cm_strPrimerOKButtonToolTip = "Click to add or update the primer with the above info.";
		private const string cm_strPrimerCancelButtonToolTip = "Click to cancel changes and return to the main window.";

		//----------------------------------------------------------------------------*
		// Private Data Members
		//----------------------------------------------------------------------------*

		private cPrimer m_Primer = null;
		private cDataFiles m_DataFiles;

		private bool m_fChanged = false;

		private bool m_fViewOnly = false;

		private bool m_fInitialized = false;
		private bool m_fPopulating = false;

		private cManufacturer m_OriginalManufacturer = null;
		private string m_strOriginalModel = "";

		private ToolTip m_ManufacturerToolTip = new ToolTip();
		private ToolTip m_PrimerSizeToolTip = new ToolTip();
		private ToolTip m_StandardToolTip = new ToolTip();
		private ToolTip m_MagnumToolTip = new ToolTip();
		private ToolTip m_MilitaryToolTip = new ToolTip();
		private ToolTip m_BenchRestToolTip = new ToolTip();

		private ToolTip m_PrimerOKButtonToolTip = new ToolTip();
		private ToolTip m_PrimerCancelButtonToolTip = new ToolTip();

		//============================================================================*
		// cPrimerForm() - Constructor
		//============================================================================*

		public cPrimerForm(cPrimer Primer, cDataFiles DataFiles, bool fViewOnly = false)
			{
			InitializeComponent();
			m_fViewOnly = fViewOnly;

			m_DataFiles = DataFiles;

			if (Primer == null)
				{
				if (m_fViewOnly)
					return;

				if (m_DataFiles.Preferences.LastPrimer != null)
					{
					m_Primer = new cPrimer(m_DataFiles.Preferences.LastPrimer);

					m_Primer.Model = "";
					m_Primer.TransactionList.Clear();
					m_Primer.RecalculateInventory(m_DataFiles);
					}
				else
					m_Primer = new cPrimer();

				PrimerOKButton.Text = "Add";
				}
			else
				{
				m_Primer = new cPrimer(Primer);

				if (m_fViewOnly)
					{
					PrimerOKButton.Visible = false;

					int nButtonX = (this.Size.Width / 2) - (PrimerCancelButton.Width / 2);

					PrimerCancelButton.Location = new Point(nButtonX, PrimerCancelButton.Location.Y);

					PrimerCancelButton.Text = "Close";
					}
				else
					PrimerOKButton.Text = "Update";
				}

			m_OriginalManufacturer = m_Primer.Manufacturer;
			m_strOriginalModel = m_Primer.Model;

			SetClientSizeCore(GeneralGroupBox.Location.X + GeneralGroupBox.Width + 10, PrimerCancelButton.Location.Y + PrimerCancelButton.Height + 20);

			//----------------------------------------------------------------------------*
			// Set Control Event Handlers
			//----------------------------------------------------------------------------*

			if (!m_fViewOnly)
				{
				FirearmTypeCombo.SelectedIndexChanged += OnFirearmTypeSelected;
				ManufacturerCombo.SelectedIndexChanged += OnManufacturerChanged;
				SizeCombo.SelectedIndexChanged += OnSizeChanged;

				StandardCheckBox.Click += OnPrimerTypeClicked;
				MagnumCheckBox.Click += OnPrimerTypeClicked;
				BenchRestCheckBox.Click += OnPrimerTypeClicked;
				MilitaryCheckBox.Click += OnPrimerTypeClicked;

				ModelTextBox.TextChanged += OnModelChanged;

				QuantityTextBox.TextChanged += OnQuantityChanged;
				CostTextBox.TextChanged += OnPriceChanged;

				PrimerOKButton.Click += OnOKClicked;
				}
			else
				{
				ModelTextBox.ReadOnly = true;
				QuantityTextBox.ReadOnly = true;
				CostTextBox.ReadOnly = true;
				}

			InventoryButton.Click += OnInventoryClicked;

			//----------------------------------------------------------------------------*
			// Populate Firearm Type Combo
			//----------------------------------------------------------------------------*

			FirearmTypeCombo.Value = m_Primer.FirearmType;

			//----------------------------------------------------------------------------*
			// Populate Primer Size Combo
			//----------------------------------------------------------------------------*

			if (!m_fViewOnly)
				cControls.PopulatePrimerSizeCombo(SizeCombo, m_Primer);
			else
				{
				SizeCombo.Items.Clear();

				SizeCombo.Items.Add(m_Primer.ShortSizeString);

				SizeCombo.SelectedIndex = 0;
				}

			//----------------------------------------------------------------------------*
			// Set Labels for inventory tracking if needed
			//----------------------------------------------------------------------------*

			if (m_DataFiles.Preferences.TrackInventory)
				{
				QuantityLabel.Text = "Qty on Hand:";

				QuantityTextBox.BorderStyle = BorderStyle.None;
				QuantityTextBox.Font = new Font(QuantityTextBox.Font, FontStyle.Bold);
				QuantityTextBox.Location = new Point(QuantityTextBox.Location.X, QuantityTextBox.Location.Y + 3);
				QuantityTextBox.Enabled = false;

				CostTextBox.BorderStyle = BorderStyle.None;
				CostTextBox.Font = new Font(CostTextBox.Font, FontStyle.Bold);
				CostTextBox.TextAlign = HorizontalAlignment.Left;
				CostTextBox.Location = new Point(CostTextBox.Location.X, CostTextBox.Location.Y + 3);
				CostTextBox.Enabled = false;

				InventoryGroupBox.Text = "Inventory Info";

				CostLabel.Text = "Value:";
				}
			else
				{
				InventoryButton.Visible = false;

				CostLabel.Text = String.Format("Cost ({0}):", m_DataFiles.Preferences.Currency);
				}

			//----------------------------------------------------------------------------*
			// Fill in Primer data
			//----------------------------------------------------------------------------*

			ModelTextBox.Text = m_Primer.Model;

			StandardCheckBox.Checked = m_Primer.Standard;
			MagnumCheckBox.Checked = m_Primer.Magnum;
			MilitaryCheckBox.Checked = m_Primer.Military;
			BenchRestCheckBox.Checked = m_Primer.BenchRest;

			PopulateInventoryData();

			//----------------------------------------------------------------------------*
			// Set title and text fields
			//----------------------------------------------------------------------------*

			string strTitle;

			if (Primer == null)
				strTitle = "Add";
			else
				if (m_fViewOnly)
					strTitle = "View";
				else
					strTitle = "Edit";

			strTitle += " Primer";

			Text = strTitle;

			PopulateManufacturerCombo();

			UpdateButtons();

			m_fInitialized = true;
			}

		//============================================================================*
		// OnFirearmTypeSelected()
		//============================================================================*

		private void OnFirearmTypeSelected(object sender, EventArgs e)
			{
			if (!m_fInitialized || m_fPopulating)
				return;

			m_Primer.FirearmType = (cFirearm.eFireArmType)FirearmTypeCombo.SelectedIndex;

			m_fChanged = true;

			UpdateButtons();
			}

		//============================================================================*
		// OnInventoryClicked()
		//============================================================================*

		private void OnInventoryClicked(object sender, EventArgs e)
			{
			cInventoryForm InventoryForm = new cInventoryForm(m_Primer, m_DataFiles, m_fViewOnly);

			InventoryForm.ShowDialog();

			if (!m_fChanged)
				m_fChanged = InventoryForm.Changed;

			PopulateInventoryData();

			UpdateButtons();
			}

		//============================================================================*
		// OnManufacturerChanged()
		//============================================================================*

		private void OnManufacturerChanged(object sender, EventArgs e)
			{
			if (!m_fInitialized || m_fPopulating)
				return;

			m_Primer.Manufacturer = (cManufacturer)ManufacturerCombo.SelectedItem;

			UpdateButtons();
			}

		//============================================================================*
		// OnModelChanged()
		//============================================================================*

		private void OnModelChanged(object sender, EventArgs e)
			{
			if (!m_fInitialized || m_fPopulating)
				return;

			m_Primer.Model = ModelTextBox.Text;

			m_fChanged = true;

			UpdateButtons();
			}

		//============================================================================*
		// OnOKClicked()
		//============================================================================*

		private void OnOKClicked(object sender, EventArgs e)
			{
			}

		//============================================================================*
		// OnPriceChanged()
		//============================================================================*

		private void OnPriceChanged(object sender, EventArgs e)
			{
			if (!m_fInitialized || m_fPopulating)
				return;

			m_Primer.Cost = CostTextBox.Value;

			SetCostEach();

			m_fChanged = true;

			UpdateButtons();
			}

		//============================================================================*
		// OnPrimerTypeClicked()
		//============================================================================*

		private void OnPrimerTypeClicked(object sender, EventArgs e)
			{
			(sender as CheckBox).Checked = ((sender as CheckBox).Checked) ? false : true;

			if ((sender as CheckBox).Equals(StandardCheckBox))
				m_Primer.Standard = (sender as CheckBox).Checked;

			if ((sender as CheckBox).Equals(MagnumCheckBox))
				m_Primer.Magnum = (sender as CheckBox).Checked;

			if ((sender as CheckBox).Equals(MilitaryCheckBox))
				m_Primer.Military = (sender as CheckBox).Checked;

			if ((sender as CheckBox).Equals(BenchRestCheckBox))
				m_Primer.BenchRest = (sender as CheckBox).Checked;

			m_fChanged = true;

			UpdateButtons();
			}

		//============================================================================*
		// OnQuantityChanged()
		//============================================================================*

		private void OnQuantityChanged(object sender, EventArgs e)
			{
			if (!m_fInitialized || m_fPopulating)
				return;

			m_Primer.Quantity = QuantityTextBox.Value;

			SetCostEach();

			m_fChanged = true;

			UpdateButtons();
			}

		//============================================================================*
		// OnSizeChanged()
		//============================================================================*

		private void OnSizeChanged(object sender, EventArgs e)
			{
			if (!m_fInitialized || m_fPopulating)
				return;

			m_Primer.Size = (cPrimer.ePrimerSize)SizeCombo.SelectedIndex;

			m_fChanged = true;

			UpdateButtons();
			}

		//============================================================================*
		// PopulateInventoryData()
		//============================================================================*

		private void PopulateInventoryData()
			{
			m_fPopulating = true;

			QuantityTextBox.Value = (int)m_DataFiles.SupplyQuantity(m_Primer);

			CostTextBox.Value = m_DataFiles.SupplyCost(m_Primer);

			if (m_DataFiles.Preferences.TrackInventory)
				CostTextBox.Text = String.Format("{0}{1:F2}", m_DataFiles.Preferences.Currency, m_DataFiles.SupplyCost(m_Primer));

			m_fPopulating = false;

			SetCostEach();
			}

		//============================================================================*
		// PopulateManufacturerCombo()
		//============================================================================*

		private void PopulateManufacturerCombo()
			{
			m_fPopulating = true;

			if (!m_fViewOnly)
				cControls.PopulateManufacturerCombo(ManufacturerCombo, m_DataFiles, m_Primer.Manufacturer, cFirearm.eFireArmType.None, (int)cSupply.eSupplyTypes.Primers);
			else
				{
				ManufacturerCombo.Items.Clear();

				ManufacturerCombo.Items.Add(m_Primer.Manufacturer);

				ManufacturerCombo.SelectedIndex = 0;
				}

			if (m_Primer.Manufacturer == null)
				m_Primer.Manufacturer = (cManufacturer) ManufacturerCombo.SelectedItem;

			m_fPopulating = false;
			}

		//============================================================================*
		// Primer Property
		//============================================================================*

		public cPrimer Primer
			{
			get { return (m_Primer); }
			}

		//============================================================================*
		// SetCostEach()
		//============================================================================*

		private void SetCostEach()
			{
			CostEachLabel.Text = String.Format("{0}{1:F2}", m_DataFiles.Preferences.Currency, m_DataFiles.SupplyCostEach(m_Primer));
			}

		//============================================================================*
		// SetStaticToolTips()
		//============================================================================*

		private void SetStaticToolTips()
			{
			if (!m_DataFiles.Preferences.ToolTips)
				return;

			FirearmTypeCombo.ToolTip = cm_strFirearmTypeToolTip;

			m_ManufacturerToolTip.ShowAlways = true;
			m_ManufacturerToolTip.RemoveAll();
			m_ManufacturerToolTip.SetToolTip(ManufacturerCombo, cm_strManufacturerToolTip);

			ModelTextBox.ToolTip = cm_strModelToolTip;

			m_PrimerSizeToolTip.ShowAlways = true;
			m_PrimerSizeToolTip.RemoveAll();
			m_PrimerSizeToolTip.SetToolTip(SizeCombo, cm_strPrimerSizeToolTip);
			m_PrimerSizeToolTip.SetToolTip(SizeCombo, cm_strPrimerSizeToolTip);

			m_StandardToolTip.ShowAlways = true;
			m_StandardToolTip.RemoveAll();
			m_StandardToolTip.SetToolTip(StandardCheckBox, cm_strStandardToolTip);

			m_MagnumToolTip.ShowAlways = true;
			m_MagnumToolTip.RemoveAll();
			m_MagnumToolTip.SetToolTip(MagnumCheckBox, cm_strMagnumToolTip);

			m_MilitaryToolTip.ShowAlways = true;
			m_MilitaryToolTip.RemoveAll();
			m_MilitaryToolTip.SetToolTip(MilitaryCheckBox, cm_strMilitaryToolTip);

			m_BenchRestToolTip.ShowAlways = true;
			m_BenchRestToolTip.RemoveAll();
			m_BenchRestToolTip.SetToolTip(BenchRestCheckBox, cm_strBenchRestToolTip);

			QuantityTextBox.ToolTip = cm_strQuantityToolTip;
			CostTextBox.ToolTip = cm_strPriceToolTip;

			m_PrimerOKButtonToolTip.ShowAlways = true;
			m_PrimerOKButtonToolTip.RemoveAll();
			m_PrimerOKButtonToolTip.SetToolTip(PrimerOKButton, cm_strPrimerOKButtonToolTip);

			m_PrimerCancelButtonToolTip.ShowAlways = true;
			m_PrimerCancelButtonToolTip.RemoveAll();
			m_PrimerCancelButtonToolTip.SetToolTip(PrimerCancelButton, cm_strPrimerCancelButtonToolTip);
			}

		//============================================================================*
		// UpdateButtons()
		//============================================================================*

		private void UpdateButtons()
			{
			if (m_fViewOnly)
				return;

			bool fEnableOK = m_fChanged;
			string strToolTip = "";

			//----------------------------------------------------------------------------*
			// Check Model
			//----------------------------------------------------------------------------*

			if (!ModelTextBox.ValueOK)
				fEnableOK = false;

			//----------------------------------------------------------------------------*
			// Check for duplicate
			//----------------------------------------------------------------------------*

			ModelTextBox.ToolTip = cm_strModelToolTip;

			bool fDuplicate = false;

			cManufacturer Manufacturer = (cManufacturer)ManufacturerCombo.SelectedItem;

			if (Manufacturer != null && m_OriginalManufacturer != null && m_strOriginalModel != null)
				{
				if (Manufacturer.CompareTo(m_OriginalManufacturer) != 0 ||
					ModelTextBox.Text.ToUpper() != m_strOriginalModel.ToUpper())
					{
					foreach (cPrimer CheckPrimer in m_DataFiles.PrimerList)
						{
						if (Manufacturer.CompareTo(CheckPrimer.Manufacturer) == 0)
							{
							if (ModelTextBox.Text.ToUpper() == CheckPrimer.Model.ToUpper())
								{
								fDuplicate = true;

								fEnableOK = false;

								ModelTextBox.BackColor = Color.LightPink;

								strToolTip += String.Format("\n\nThis primer, \"{0} {1}\", already exists.  Duplicate primers are not allowed.", (ManufacturerCombo.SelectedItem as cManufacturer).Name, ModelTextBox.Text);

								break;
								}
							}

						}

					if (!fDuplicate)
						ModelTextBox.BackColor = SystemColors.Window;
					}
				}

			if (m_DataFiles.Preferences.ToolTips)
				ModelTextBox.ToolTip += strToolTip;

			//----------------------------------------------------------------------------*
			// Check Uses
			//----------------------------------------------------------------------------*

			strToolTip = "";

			if (!StandardCheckBox.Checked && !MagnumCheckBox.Checked)
				{
				fEnableOK = false;

				StandardCheckBox.BackColor = Color.LightPink;
				MagnumCheckBox.BackColor = Color.LightPink;

				strToolTip += "\n\nYou must select either Standard, Magnum, or both.";

				}
			else
				{
				StandardCheckBox.BackColor = SystemColors.Control;
				MagnumCheckBox.BackColor = SystemColors.Control;
				}

			if (m_DataFiles.Preferences.ToolTips)
				{
				m_StandardToolTip.SetToolTip(StandardCheckBox, cm_strStandardToolTip + strToolTip);
				m_MagnumToolTip.SetToolTip(MagnumCheckBox, cm_strMagnumToolTip + strToolTip);
				}

			//----------------------------------------------------------------------------*
			// Check Quantity
			//----------------------------------------------------------------------------*

			if (!QuantityTextBox.ValueOK)
				fEnableOK = false;

			//----------------------------------------------------------------------------*
			// Check Price
			//----------------------------------------------------------------------------*

			if (!CostTextBox.ValueOK)
				fEnableOK = false;

			//----------------------------------------------------------------------------*
			// Enable or disable OK button
			//----------------------------------------------------------------------------*

			PrimerOKButton.Enabled = fEnableOK;
			}
		}
	}
