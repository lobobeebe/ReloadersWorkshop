//============================================================================*
// cToolForm.cs
//
// Copyright © 2013-2017, Kevin S. Beebe
// All Rights Reserved
//============================================================================*

//============================================================================*
// .Net Using Statements
//============================================================================*

using System;
using System.Drawing;
using System.Windows.Forms;

//============================================================================*
// NameSpace
//============================================================================*

namespace ReloadersWorkShop
	{
	//============================================================================*
	// cToolForm Class
	//============================================================================*

	public partial class cToolForm : Form
		{
		//============================================================================*
		// Private Constant Data Members
		//============================================================================*

		private const string cm_strTypeToolTip = "The general type of this tool or equipment.";
		private const string cm_strManufacturerToolTip = "Select the manufacturer of this tool or equipment.";
		private const string cm_strPartNumberToolTip = "Enter the manufacturer's part number for this tool or equipment.";
		private const string cm_strSerialNumberToolTip = "Enter this tool or equipment's serial number, if any.";
		private const string cm_strDescriptionToolTip = "Enter a description of this tool or equipment.";
		private const string cm_strNotesToolTip = "Enter any notes you might have for this tool or equipment.";

		private const string cm_strSourceToolTip = "Enter where you obtained this tool or equipment.";
		private const string cm_strPriceToolTip = "Enter what you paid for this tool or equipment.";
		private const string cm_strPurchaseDateToolTip = "Enter the date when you obtained this tool or equipment.";

		private const string cm_strOKButtonToolTip = "Click to add or update this tool or equipment with the above data.";
		private const string cm_strCancelButtonToolTip = "Click to cancel changes and return to the main window.";
		private const string cm_strCloseButtonToolTip = "Click to close this dialog and return to the main window.";

		//============================================================================*
		// Private Data Members
		//============================================================================*

		private bool m_fAdd = false;
		private bool m_fViewOnly = false;
		private bool m_fChanged = false;

		private bool m_fInitialized = false;
		private bool m_fPopulating = false;

		private bool m_fUserTax = false;

		private cDataFiles m_DataFiles = null;
		private cTool m_Tool = null;

		private ToolTip m_TypeToolTip = new ToolTip();
		private ToolTip m_ManufacturerToolTip = new ToolTip();
		private ToolTip m_SourceToolTip = new ToolTip();
		private ToolTip m_PurchaseDateToolTip = new ToolTip();

		private ToolTip m_OKButtonToolTip = new ToolTip();
		private ToolTip m_CancelButtonToolTip = new ToolTip();

		//============================================================================*
		// cToolForm()
		//============================================================================*

		public cToolForm(cTool Tool, cDataFiles DataFiles, bool fViewOnly = false)
			{
			InitializeComponent();

			m_DataFiles = DataFiles;

			m_fViewOnly = fViewOnly;

			if (Tool == null)
				{
				m_Tool = new cTool(cTool.eToolTypes.Other);
				}
			else
				{
				m_Tool = new cTool(Tool);
				}

			SetClientSizeCore(GeneralGroupBox.Location.X + GeneralGroupBox.Width + 10, FormCancelButton.Location.Y + FormCancelButton.Height + 20);

			//----------------------------------------------------------------------------*
			// Event Handlers
			//----------------------------------------------------------------------------*

			if (!m_fViewOnly)
				{
				// General

				TypeCombo.SelectedIndexChanged += OnTypeChanged;
				ManufacturerCombo.SelectedIndexChanged += OnManufacturerChanged;
				PartNumberTextBox.TextChanged += OnPartNumberChanged;
				SerialNumberTextBox.TextChanged += OnSerialNumberChanged;
				DescriptionTextBox.TextChanged += OnDescriptionChanged;
				NotesTextBox.TextChanged += OnNotesChanged;

				// Acquisition Details

				SourceCombo.TextChanged += OnSourceChanged;
				PurchaseDatePicker.ValueChanged += OnPurchaseDateChanged;
				PriceTextBox.TextChanged += OnPriceChanged;
				TaxTextBox.TextChanged += OnTaxChanged;
				ShippingTextBox.TextChanged += OnShippingChanged;
				}
			else
				{
				// General

				PartNumberTextBox.ReadOnly = true;
				SerialNumberTextBox.ReadOnly = true;
				DescriptionTextBox.ReadOnly = true;
				NotesTextBox.ReadOnly = true;

				// Acquisition Details

				SourceCombo.Enabled = false;
				PurchaseDatePicker.Enabled = false;
				PriceTextBox.ReadOnly = true;
				TaxTextBox.ReadOnly = true;
				ShippingTextBox.ReadOnly = true;
				}

			//----------------------------------------------------------------------------*
			// Set Title
			//----------------------------------------------------------------------------*

			string strTitle = "Add Tool or Equipment";

			if (m_fViewOnly)
				{
				strTitle = strTitle.Replace("Add", "View");

				OKButton.Visible = false;

				FormCancelButton.Text = "Close";

				FormCancelButton.Location = new Point((ClientRectangle.Width / 2) - (FormCancelButton.Width / 2), FormCancelButton.Location.Y);

				m_fAdd = false;
				}
			else
				{
				if (Tool != null)
					{
					strTitle = strTitle.Replace("Add", "Edit");

					OKButton.Text = "Update";

					m_fAdd = false;
					}
				else
					{
					OKButton.Text = "Add";

					m_fAdd = true;
					}
				}

			Text = strTitle;

			//----------------------------------------------------------------------------*
			// Set Gear Data Fields
			//----------------------------------------------------------------------------*

			//			SetInputParameters();

			SetStaticToolTips();

			SetInputParameters();

			PopulateTypeCombo();

			PopulateSourceCombo();

			PopulateToolData();

			m_fInitialized = true;

			UpdateButtons();
			}

		//============================================================================*
		// Tool Property
		//============================================================================*

		public cTool Tool
			{
			get
				{
				return (m_Tool);
				}
			}

		//============================================================================*
		// OnDescriptionChanged()
		//============================================================================*

		public void OnDescriptionChanged(Object sender, EventArgs args)
			{
			if (!m_fInitialized || m_fPopulating)
				return;

			m_Tool.Description = @DescriptionTextBox.Value;

			m_fChanged = true;

			UpdateButtons();
			}

		//============================================================================*
		// OnManufacturerChanged()
		//============================================================================*

		public void OnManufacturerChanged(Object sender, EventArgs args)
			{
			if (!m_fInitialized || m_fPopulating)
				return;

			m_Tool.Manufacturer = (cManufacturer)ManufacturerCombo.SelectedItem;

			m_fChanged = true;

			UpdateButtons();
			}

		//============================================================================*
		// OnNotesChanged()
		//============================================================================*

		public void OnNotesChanged(Object sender, EventArgs args)
			{
			if (!m_fInitialized || m_fPopulating)
				return;

			m_Tool.Notes = @NotesTextBox.Value;

			m_fChanged = true;

			UpdateButtons();
			}

		//============================================================================*
		// OnPartNumberChanged()
		//============================================================================*

		public void OnPartNumberChanged(Object sender, EventArgs args)
			{
			if (!m_fInitialized || m_fPopulating)
				return;

			m_Tool.PartNumber = @PartNumberTextBox.Value;

			m_fChanged = true;

			UpdateButtons();
			}

		//============================================================================*
		// OnPriceChanged()
		//============================================================================*

		public void OnPriceChanged(Object sender, EventArgs args)
			{
			if (!m_fInitialized || m_fPopulating)
				return;

			m_Tool.PurchasePrice = PriceTextBox.Value;

			if (m_DataFiles.Preferences.TaxRate != 0.0 && !m_fUserTax)
				{
				m_Tool.Tax = Math.Round(m_Tool.PurchasePrice * (m_DataFiles.Preferences.TaxRate / 100.0), 2);

				TaxTextBox.Value = m_Tool.Tax;
				}

			SetTotal();

			m_fChanged = true;

			UpdateButtons();
			}

		//============================================================================*
		// OnPurchaseDateChanged()
		//============================================================================*

		public void OnPurchaseDateChanged(Object sender, EventArgs args)
			{
			if (!m_fInitialized || m_fPopulating)
				return;

			try
				{
				m_Tool.PurchaseDate = PurchaseDatePicker.Value;
				}
			catch
				{
				m_Tool.PurchaseDate = DateTime.Today;
				}

			m_fChanged = true;

			UpdateButtons();
			}

		//============================================================================*
		// OnSerialNumberChanged()
		//============================================================================*

		public void OnSerialNumberChanged(Object sender, EventArgs args)
			{
			if (!m_fInitialized || m_fPopulating)
				return;

			m_Tool.SerialNumber = @SerialNumberTextBox.Value;

			m_fChanged = true;

			UpdateButtons();
			}

		//============================================================================*
		// OnShippingChanged()
		//============================================================================*

		public void OnShippingChanged(Object sender, EventArgs args)
			{
			if (!m_fInitialized || m_fPopulating)
				return;

			m_Tool.Shipping = ShippingTextBox.Value;

			SetTotal();

			m_fChanged = true;

			UpdateButtons();
			}

		//============================================================================*
		// OnSourceChanged()
		//============================================================================*

		public void OnSourceChanged(Object sender, EventArgs args)
			{
			if (!m_fInitialized || m_fPopulating)
				return;

			m_Tool.Source = SourceCombo.Text;

			if (String.IsNullOrEmpty(m_Tool.Source))
				{
				m_Tool.PurchasePrice = 0.0;
				m_Tool.Tax = 0.0;
				m_Tool.Shipping = 0.0;

				PopulateToolData();
				}

			m_fChanged = true;

			UpdateButtons();
			}

		//============================================================================*
		// OnTaxChanged()
		//============================================================================*

		public void OnTaxChanged(Object sender, EventArgs args)
			{
			if (!m_fInitialized || m_fPopulating)
				return;

			m_Tool.Tax = TaxTextBox.Value;

			m_fUserTax = true;

			SetTotal();

			m_fChanged = true;

			UpdateButtons();
			}

		//============================================================================*
		// OnTypeChanged()
		//============================================================================*

		public void OnTypeChanged(Object sender, EventArgs args)
			{
			if (!m_fInitialized || m_fPopulating)
				return;

			m_Tool.ToolType = (cTool.eToolTypes) TypeCombo.SelectedIndex;

			PopulateManufacturerCombo();

			PopulateToolData();

			m_fChanged = true;

			UpdateButtons();
			}

		//============================================================================*
		// PopulateToolData()
		//============================================================================*

		public void PopulateToolData()
			{
			m_fPopulating = true;

			//----------------------------------------------------------------------------*
			// Type Combo
			//----------------------------------------------------------------------------*

			TypeCombo.SelectedItem = cTool.ToolTypeString(m_Tool.ToolType);

			if (TypeCombo.SelectedIndex < 0 && TypeCombo.Items.Count > 0)
				{
				TypeCombo.SelectedIndex = 0;

				m_Tool.ToolType = cTool.ToolTypeFromString(TypeCombo.Text);
				}

			//----------------------------------------------------------------------------*
			// Manufacturer Combo
			//----------------------------------------------------------------------------*

			ManufacturerCombo.SelectedItem = m_Tool.Manufacturer;

			if (ManufacturerCombo.SelectedIndex < 0 && ManufacturerCombo.Items.Count > 0)
				{
				ManufacturerCombo.SelectedIndex = 0;

				m_Tool.Manufacturer = (cManufacturer)ManufacturerCombo.SelectedItem;
				}

			//----------------------------------------------------------------------------*
			// General Info
			//----------------------------------------------------------------------------*

			PartNumberTextBox.Value = m_Tool.PartNumber;
			SerialNumberTextBox.Value = m_Tool.SerialNumber;
			DescriptionTextBox.Value = m_Tool.Description;
			NotesTextBox.Value = m_Tool.Notes;

			//----------------------------------------------------------------------------*
			// Acquisition Details
			//----------------------------------------------------------------------------*

			SourceCombo.Text = m_Tool.Source;

			try
				{
				PurchaseDatePicker.Value = m_Tool.PurchaseDate;
				}
			catch
				{
				PurchaseDatePicker.Value = DateTime.Today;

				m_Tool.PurchaseDate = PurchaseDatePicker.Value;

				m_fChanged = true;
				}

			PriceTextBox.Value = m_Tool.PurchasePrice;
			TaxTextBox.Value = m_Tool.Tax;
			ShippingTextBox.Value = m_Tool.Shipping;

			SetTotal();

			m_fPopulating = false;
			}

		//============================================================================*
		// PopulateManufacturerCombo()
		//============================================================================*

		public void PopulateManufacturerCombo()
			{
			m_fPopulating = true;

			ManufacturerCombo.Items.Clear();

			if (m_fViewOnly)
				{
				ManufacturerCombo.Items.Add(m_Tool.Manufacturer);

				ManufacturerCombo.SelectedIndex = 0;
				}
			else
				{
				foreach (cManufacturer Manufacturer in m_DataFiles.ManufacturerList)
					{
					if (Manufacturer.Tools)
						ManufacturerCombo.Items.Add(Manufacturer);
					}

				ManufacturerCombo.SelectedItem = m_Tool.Manufacturer;

				if (ManufacturerCombo.SelectedIndex < 0 && ManufacturerCombo.Items.Count > 0)
					{
					ManufacturerCombo.SelectedIndex = 0;

					m_Tool.Manufacturer = (cManufacturer)ManufacturerCombo.SelectedItem;
					}
				}

			m_fPopulating = false;
			}

		//============================================================================*
		// PopulateSourceCombo()
		//============================================================================*

		public void PopulateSourceCombo()
			{
			m_fPopulating = true;

			SourceCombo.Items.Clear();

			foreach (cTool Tool in m_DataFiles.ToolList)
				{
				if (!String.IsNullOrEmpty(Tool.Source))
					{
					if (SourceCombo.FindStringExact(Tool.Source) < 0)
						SourceCombo.Items.Add(Tool.Source);
					}
				}

			m_fPopulating = false;
			}

		//============================================================================*
		// PopulateTypeCombo()
		//============================================================================*

		public void PopulateTypeCombo()
			{
			m_fPopulating = true;

			TypeCombo.Items.Clear();

			if (m_fViewOnly || !m_fAdd)
				{
				TypeCombo.Items.Add(cTool.ToolTypeString(m_Tool.ToolType));

				TypeCombo.SelectedIndex = 0;
				}
			else
				{
				for (int i = 0; i < (int) cTool.eToolTypes.NumToolTypes;i++)
					TypeCombo.Items.Add(cTool.ToolTypeString((cTool.eToolTypes) i));

				TypeCombo.SelectedItem = "Other";

				if (TypeCombo.SelectedIndex < 0 && TypeCombo.Items.Count > 0)
					TypeCombo.SelectedIndex = 0;
				}

			m_fPopulating = false;

			PopulateManufacturerCombo();

			PopulateToolData();
			}

		//============================================================================*
		// SetInputParameters()
		//============================================================================*

		public void SetInputParameters()
			{
			PartNumberTextBox.Required = true;
			PartNumberTextBox.MaxLength = 35;

			SerialNumberTextBox.Required = false;
			SerialNumberTextBox.MaxLength = 35;

			DescriptionTextBox.Required = true;
			DescriptionTextBox.MaxLength = 60;

			NotesTextBox.MaxLength = 1000;

			SourceCombo.MaxLength = 35;

			cDataFiles.SetInputParameters(PriceTextBox, cDataFiles.eDataType.Cost);
			cDataFiles.SetInputParameters(TaxTextBox, cDataFiles.eDataType.Cost);
			cDataFiles.SetInputParameters(ShippingTextBox, cDataFiles.eDataType.Cost);

			PriceLabel.Text = String.Format("Price ({0}):", m_DataFiles.Preferences.Currency);
			TaxLabel.Text = String.Format("Tax ({0}):", m_DataFiles.Preferences.Currency);
			ShippingLabel.Text = String.Format("Shipping ({0}):", m_DataFiles.Preferences.Currency);

			cDataFiles.SetInputParameters(PriceTextBox, cDataFiles.eDataType.Cost);
			}

		//============================================================================*
		// SetStaticToolTips()
		//============================================================================*

		private void SetStaticToolTips()
			{
			if (!m_DataFiles.Preferences.ToolTips)
				return;

			// General

			PartNumberTextBox.ToolTip = cm_strPartNumberToolTip;
			SerialNumberTextBox.ToolTip = cm_strSerialNumberToolTip;
			DescriptionTextBox.ToolTip = cm_strDescriptionToolTip;
			NotesTextBox.ToolTip = cm_strNotesToolTip;

			// Acquisition Details

			m_SourceToolTip.ShowAlways = true;
			m_SourceToolTip.RemoveAll();
			m_SourceToolTip.SetToolTip(SourceCombo, cm_strSourceToolTip);

			PriceTextBox.ToolTip = cm_strPriceToolTip;

			m_TypeToolTip.ShowAlways = true;
			m_TypeToolTip.RemoveAll();
			m_TypeToolTip.SetToolTip(TypeCombo, cm_strTypeToolTip);

			m_ManufacturerToolTip.ShowAlways = true;
			m_ManufacturerToolTip.RemoveAll();
			m_ManufacturerToolTip.SetToolTip(ManufacturerCombo, cm_strManufacturerToolTip);

			m_PurchaseDateToolTip.ShowAlways = true;
			m_PurchaseDateToolTip.RemoveAll();
			m_PurchaseDateToolTip.SetToolTip(PurchaseDatePicker, cm_strPurchaseDateToolTip);
			}

		//============================================================================*
		// SetTotal()
		//============================================================================*

		private void SetTotal()
			{
			TotalLabel.Text = String.Format("{0:F2}", m_Tool.PurchasePrice + m_Tool.Tax + m_Tool.Shipping);
			}

		//============================================================================*
		// UpdateButtons()
		//============================================================================*

		public void UpdateButtons()
			{
			bool fEnableOK = m_fChanged;

			//----------------------------------------------------------------------------*
			// Set Type ToolTip
			//----------------------------------------------------------------------------*

			string strToolTip = cm_strTypeToolTip;

			if (m_fViewOnly || !m_fAdd)
				strToolTip += "\n\nThe type may not be changed when editing or viewing accessories.";

			m_TypeToolTip.SetToolTip(TypeCombo, strToolTip);

			//----------------------------------------------------------------------------*
			// Check Type and Manufacturer
			//----------------------------------------------------------------------------*

			if (TypeCombo.SelectedIndex < 0 || ManufacturerCombo.SelectedIndex < 0)
				fEnableOK = false;

			//----------------------------------------------------------------------------*
			// Check  Part Number
			//----------------------------------------------------------------------------*

			if (!PartNumberTextBox.ValueOK)
				fEnableOK = false;

			//----------------------------------------------------------------------------*
			// Check Description
			//----------------------------------------------------------------------------*

			if (!DescriptionTextBox.ValueOK)
				fEnableOK = false;

			//----------------------------------------------------------------------------*
			// Check Acquisition Details
			//----------------------------------------------------------------------------*

			PurchaseDatePicker.Enabled = !String.IsNullOrEmpty(SourceCombo.Text);
			PriceTextBox.ReadOnly = String.IsNullOrEmpty(SourceCombo.Text);
			TaxTextBox.ReadOnly = String.IsNullOrEmpty(SourceCombo.Text);
			ShippingTextBox.ReadOnly = String.IsNullOrEmpty(SourceCombo.Text);

			//----------------------------------------------------------------------------*
			// Set Button States
			//----------------------------------------------------------------------------*

			OKButton.Enabled = fEnableOK;
			}
		}
	}
