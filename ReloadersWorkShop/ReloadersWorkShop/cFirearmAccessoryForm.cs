//============================================================================*
// cFirearmAccessoryForm.cs
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

//============================================================================*
// NameSpace
//============================================================================*

namespace ReloadersWorkShop
	{
	//============================================================================*
	// cFirearmAccessoryForm Class
	//============================================================================*

	public partial class cFirearmAccessoryForm : Form
		{
		//============================================================================*
		// Private Constant Data Members
		//============================================================================*

		private const string cm_strTypeToolTip = "Select the type of this part or accessory.";
		private const string cm_strManufacturerToolTip = "Select the manufacturer of this part or accessory.";
		private const string cm_strPartNumberToolTip = "Enter the manufacturer's part number for this part or accessory.";
		private const string cm_strSerialNumberToolTip = "Enter this part or accessory's serial number, if any.";
		private const string cm_strDescriptionToolTip = "Enter a description of this part or accessory.";

		private const string cm_strSourceToolTip = "Enter where you obtained this part or accessory.";
		private const string cm_strPriceToolTip = "Enter what you paid for this part or accessory.";
		private const string cm_strPurchaseDateToolTip = "Enter the date when you obtained this part or accessory.";

		private const string cm_strScopePowerToolTip = "Enter this scope's power, leaving off the trailing 'x'. Example: 6, 3-9, 6-24, etc.";
		private const string cm_strScopeObjectiveToolTip = "Enter this scope's Objective in millimeters.";
		private const string cm_strScopeTubeToolTip = "Select this scope's tube diameter.";
		private const string cm_strScopeClickToolTip = "Enter this scope's turret click increment.";
		private const string cm_strScopeTypeToolTip = "Select this scope's turret type.";

		private const string cm_strOKButtonToolTip = "Click to add or update this part or accessory with the above data.";
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

		private cDataFiles m_DataFiles = null;
		private cGear m_Gear = null;

		private ToolTip m_TypeToolTip = new ToolTip();
		private ToolTip m_ManufacturerToolTip = new ToolTip();
		private ToolTip m_SourceToolTip = new ToolTip();
		private ToolTip m_PurchaseDateToolTip = new ToolTip();

		private ToolTip m_ScopeTubeToolTip = new ToolTip();
		private ToolTip m_ScopeTypeToolTip = new ToolTip();

		private ToolTip m_OKButtonToolTip = new ToolTip();
		private ToolTip m_CancelButtonToolTip = new ToolTip();

		//============================================================================*
		// cFirearmAccessoryForm()
		//============================================================================*

		public cFirearmAccessoryForm(cGear Gear, cDataFiles DataFiles, bool fViewOnly = false)
			{
			InitializeComponent();

			m_DataFiles = DataFiles;

			m_fViewOnly = fViewOnly;

			if (Gear == null)
				{
				m_Gear = CreateGearObject(cGear.eGearTypes.Misc);
				}
			else
				{
				switch (Gear.GearType)
					{
					case cGear.eGearTypes.Scope:
						m_Gear = new cScope((Gear as cScope));
						break;

					default:
						m_Gear = new cGear(Gear);
						break;
					}
				}

			SetClientSizeCore(GeneralGroup.Location.X + GeneralGroup.Width + 10, FormCancelButton.Location.Y + FormCancelButton.Height + 20);

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

				// Acquisition Details

				SourceCombo.TextChanged += OnSourceChanged;
				PurchaseDatePicker.ValueChanged += OnPurchaseDateChanged;
				PriceTextBox.TextChanged += OnPriceChanged;

				// Scope Details

				ScopePowerTextBox.TextChanged += OnScopePowerChanged;
				ScopeObjectiveTextBox.TextChanged += OnScopeObjectiveChanged;
				ScopeTubeCombo.SelectedIndexChanged += OnScopeTubeSizeChanged;
				ScopeClickTextBox.TextChanged += OnScopeClickChanged;
				ScopeTurretTypeCombo.SelectedIndexChanged += OnScopeTurretTypeChanged;
				}
			else
				{
				// General

				PartNumberTextBox.ReadOnly = true;
				SerialNumberTextBox.ReadOnly = true;
				DescriptionTextBox.ReadOnly = true;

				// Acquisition Details

				SourceCombo.Enabled = false;
				PurchaseDatePicker.Enabled = false;
				PriceTextBox.ReadOnly = true;

				// Scope Details

				ScopePowerTextBox.ReadOnly = true;
				ScopeObjectiveTextBox.ReadOnly = true;
				ScopeClickTextBox.ReadOnly = true;
				}

			//----------------------------------------------------------------------------*
			// Set Title
			//----------------------------------------------------------------------------*

			string strTitle = "Add Firearm Part or Accessory";

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
				if (Gear != null)
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

			SetStaticToolTips();

			SetInputParameters();

			PopulateTypeCombo();

			PopulateSourceCombo();

			PopulateGearData();

			SetDialogFormat();

			m_fInitialized = true;

			UpdateButtons();
			}

		//============================================================================*
		// CreateGearObject()
		//============================================================================*

		public cGear CreateGearObject(cGear.eGearTypes eType)
			{
			switch (eType)
				{
				case cGear.eGearTypes.Scope:
					return (new cScope());
				}

			return (new cGear(eType));
			}

		//============================================================================*
		// Gear Property
		//============================================================================*

		public cGear Gear
			{
			get
				{
				return (m_Gear);
				}
			}

		//============================================================================*
		// OnDescriptionChanged()
		//============================================================================*

		public void OnDescriptionChanged(Object sender, EventArgs args)
			{
			if (!m_fInitialized || m_fPopulating)
				return;

			m_Gear.Description = DescriptionTextBox.Value;

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

			m_Gear.Manufacturer = (cManufacturer) ManufacturerCombo.SelectedItem;

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

			m_Gear.PartNumber = PartNumberTextBox.Value;

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

			m_Gear.PurchasePrice = PriceTextBox.Value;

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

			m_Gear.PurchaseDate = PurchaseDatePicker.Value;

			m_fChanged = true;

			UpdateButtons();
			}

		//============================================================================*
		// OnScopeClickChanged()
		//============================================================================*

		public void OnScopeClickChanged(Object sender, EventArgs args)
			{
			if (!m_fInitialized || m_fPopulating)
				return;

			(m_Gear as cScope).TurretClick = ScopeClickTextBox.Value;

			m_fChanged = true;

			UpdateButtons();
			}

		//============================================================================*
		// OnScopeObjectiveChanged()
		//============================================================================*

		public void OnScopeObjectiveChanged(Object sender, EventArgs args)
			{
			if (!m_fInitialized || m_fPopulating)
				return;

			(m_Gear as cScope).Objective = ScopeObjectiveTextBox.Value;

			m_fChanged = true;

			UpdateButtons();
			}

		//============================================================================*
		// OnScopePowerChanged()
		//============================================================================*

		public void OnScopePowerChanged(Object sender, EventArgs args)
			{
			if (!m_fInitialized || m_fPopulating)
				return;

			(m_Gear as cScope).Power = ScopePowerTextBox.Value;

			m_fChanged = true;

			UpdateButtons();
			}

		//============================================================================*
		// OnScopeTubeSizeChanged()
		//============================================================================*

		public void OnScopeTubeSizeChanged(Object sender, EventArgs args)
			{
			if (!m_fInitialized || m_fPopulating)
				return;

			(m_Gear as cScope).TubeSize = (cScope.eTurretTubeSizes) ScopeTubeCombo.SelectedIndex;

			m_fChanged = true;

			UpdateButtons();
			}

		//============================================================================*
		// OnScopeTurretTypeChanged()
		//============================================================================*

		public void OnScopeTurretTypeChanged(Object sender, EventArgs args)
			{
			if (!m_fInitialized || m_fPopulating)
				return;

			(m_Gear as cScope).TurretType = (cScope.eTurretTypes) ScopeTurretTypeCombo.SelectedIndex;

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

			m_Gear.SerialNumber = SerialNumberTextBox.Value;

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

			m_Gear.Source = SourceCombo.Text;

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

			m_Gear = CreateGearObject(cGear.GearTypeFromString(TypeCombo.SelectedItem.ToString()));

			PopulateManufacturerCombo();

			SetDialogFormat();

			PopulateGearData();

			m_fChanged = true;

			UpdateButtons();
			}

		//============================================================================*
		// PopulateGearData()
		//============================================================================*

		public void PopulateGearData()
			{
			m_fPopulating = true;

			//----------------------------------------------------------------------------*
			// Type Combo
			//----------------------------------------------------------------------------*

			TypeCombo.SelectedItem = cGear.GearTypeString(m_Gear.GearType);

			if (TypeCombo.SelectedIndex < 0 && TypeCombo.Items.Count > 0)
				{
				TypeCombo.SelectedIndex = 0;

				m_Gear.GearType = cGear.GearTypeFromString(TypeCombo.Text);
				}

			//----------------------------------------------------------------------------*
			// Manufacturer Combo
			//----------------------------------------------------------------------------*

			ManufacturerCombo.SelectedItem = m_Gear.Manufacturer;

			if (ManufacturerCombo.SelectedIndex < 0 && ManufacturerCombo.Items.Count > 0)
				{
				ManufacturerCombo.SelectedIndex = 0;

				m_Gear.Manufacturer = (cManufacturer) ManufacturerCombo.SelectedItem;
				}

			//----------------------------------------------------------------------------*
			// General Info
			//----------------------------------------------------------------------------*

			PartNumberTextBox.Value = m_Gear.PartNumber;
			SerialNumberTextBox.Value = m_Gear.SerialNumber;
			DescriptionTextBox.Value = m_Gear.Description;

			//----------------------------------------------------------------------------*
			// Acquisition Details
			//----------------------------------------------------------------------------*

			SourceCombo.Text = m_Gear.Source;
			PurchaseDatePicker.Value = m_Gear.PurchaseDate;
			PriceTextBox.Value = m_Gear.PurchasePrice;

			//----------------------------------------------------------------------------*
			// Gear Specific Details
			//----------------------------------------------------------------------------*

			switch (m_Gear.GearType)
				{
				//----------------------------------------------------------------------------*
				// Scope Details
				//----------------------------------------------------------------------------*

				case cGear.eGearTypes.Scope:
					ScopePowerTextBox.Value = (m_Gear as cScope).Power;
					ScopeObjectiveTextBox.Value = (m_Gear as cScope).Objective;
					ScopeClickTextBox.Value = (m_Gear as cScope).TurretClick;

					//----------------------------------------------------------------------------*
					// Turret Tube Size Combo
					//----------------------------------------------------------------------------*

					if (m_fViewOnly)
						{
						ScopeTubeCombo.Items.Clear();

						ScopeTubeCombo.Items.Add(cScope.TubeSizeString((m_Gear as cScope).TubeSize));

						ScopeTubeCombo.SelectedIndex = 0;
						}
					else
						{
						ScopeTubeCombo.SelectedIndex = (int) (m_Gear as cScope).TubeSize;

						if (ScopeTubeCombo.SelectedIndex < 0 && ScopeTubeCombo.Items.Count > 0)
							{
							ScopeTubeCombo.SelectedIndex = 0;

							(m_Gear as cScope).TubeSize = (cScope.eTurretTubeSizes) ScopeTubeCombo.SelectedIndex;
							}
						}

					//----------------------------------------------------------------------------*
					// Turret Type Combo
					//----------------------------------------------------------------------------*

					if (m_fViewOnly)
						{
						ScopeTurretTypeCombo.Items.Clear();

						ScopeTurretTypeCombo.Items.Add(cScope.TurretTypeString((m_Gear as cScope).TurretType));

						ScopeTurretTypeCombo.SelectedIndex = 0;
						}
					else
						{
						ScopeTurretTypeCombo.SelectedItem = (m_Gear as cScope).TurretType;

						if (ScopeTurretTypeCombo.SelectedIndex < 0 && ScopeTurretTypeCombo.Items.Count > 0)
							{
							ScopeTurretTypeCombo.SelectedIndex = 0;

							(m_Gear as cScope).TurretType = (cScope.eTurretTypes) ScopeTurretTypeCombo.SelectedIndex;
							}
						}

					break;
				}

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
				ManufacturerCombo.Items.Add(m_Gear.Manufacturer);

				ManufacturerCombo.SelectedIndex = 0;
				}
			else
				{
				foreach (cManufacturer Manufacturer in m_DataFiles.ManufacturerList)
					{
					if (Manufacturer.HasGear(m_Gear.GearType))
						ManufacturerCombo.Items.Add(Manufacturer);
					}

				ManufacturerCombo.SelectedItem = m_Gear.Manufacturer;

				if (ManufacturerCombo.SelectedIndex < 0 && ManufacturerCombo.Items.Count > 0)
					{
					ManufacturerCombo.SelectedIndex = 0;

					m_Gear.Manufacturer = (cManufacturer) ManufacturerCombo.SelectedItem;
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

			foreach (cGear Gear in m_DataFiles.GearList)
				{
				if (!String.IsNullOrEmpty(Gear.Source))
					{
					if (SourceCombo.FindStringExact(Gear.Source) < 0)
						SourceCombo.Items.Add(Gear.Source);
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
				TypeCombo.Items.Add(cGear.GearTypeString(m_Gear.GearType));

				TypeCombo.SelectedIndex = 0;
				}
			else
				{
				bool fScopes = false;
				bool fRedDots = false;
				bool fLights = false;
				bool fTriggers = false;
				bool fFurniture = false;
				bool fBipods = false;
				bool fParts = false;
				bool fMisc = false;

				foreach (cManufacturer Manufacturer in m_DataFiles.ManufacturerList)
					{
					fScopes = !fScopes ? Manufacturer.Scopes : fScopes;
					fRedDots = !fRedDots ? Manufacturer.RedDots : fRedDots;
					fLights = !fLights ? Manufacturer.Lights : fLights;
					fTriggers = !fTriggers ? Manufacturer.Triggers : fTriggers;
					fFurniture = !fFurniture ? Manufacturer.Furniture : fFurniture;
					fBipods = !fBipods ? Manufacturer.Bipods : fBipods;
					fParts = !fParts ? Manufacturer.Parts : fParts;
					fMisc = !fMisc ? Manufacturer.Misc : fMisc;
					}

				if (fScopes)
					TypeCombo.Items.Add(cGear.GearTypeString(cGear.eGearTypes.Scope));

				if (fRedDots)
					TypeCombo.Items.Add(cGear.GearTypeString(cGear.eGearTypes.RedDot));

				if (fLights)
					TypeCombo.Items.Add(cGear.GearTypeString(cGear.eGearTypes.Light));

				if (fTriggers)
					TypeCombo.Items.Add(cGear.GearTypeString(cGear.eGearTypes.Trigger));

				if (fFurniture)
					TypeCombo.Items.Add(cGear.GearTypeString(cGear.eGearTypes.Furniture));

				if (fBipods)
					TypeCombo.Items.Add(cGear.GearTypeString(cGear.eGearTypes.Bipod));

				if (fParts)
					TypeCombo.Items.Add(cGear.GearTypeString(cGear.eGearTypes.Parts));

				if (fMisc)
					TypeCombo.Items.Add(cGear.GearTypeString(cGear.eGearTypes.Misc));

				TypeCombo.SelectedItem = cGear.GearTypeString(m_Gear.GearType);

				if (TypeCombo.SelectedIndex < 0 && TypeCombo.Items.Count > 0)
					{
					TypeCombo.SelectedIndex = 0;

					if (m_Gear.GearType != cGear.GearTypeFromString(TypeCombo.Text))
						m_Gear = CreateGearObject(cGear.GearTypeFromString(TypeCombo.Text));
					}
				}

			m_fPopulating = false;

			PopulateManufacturerCombo();

			PopulateGearData();
			}

		//============================================================================*
		// SetDialogFormat()
		//============================================================================*

		public void SetDialogFormat()
			{
			ScopeDetailsGroupBox.Visible = m_Gear.GearType == cGear.eGearTypes.Scope;
			RedDotDetailsGroupBox.Visible = m_Gear.GearType == cGear.eGearTypes.RedDot;

			GroupBox DetailsGroup = m_Gear.GearType == cGear.eGearTypes.Scope ? ScopeDetailsGroupBox : null;

			if (DetailsGroup == null)
				DetailsGroup = m_Gear.GearType == cGear.eGearTypes.RedDot ? RedDotDetailsGroupBox : null;

			if (DetailsGroup != null)
				{
				DetailsGroup.Location = new Point(12, AcquisitionGroupBox.Location.Y + AcquisitionGroupBox.Height + 6);

				OKButton.Location = new Point(OKButton.Location.X, DetailsGroup.Location.Y + DetailsGroup.Size.Height + 10);
				FormCancelButton.Location = new Point(FormCancelButton.Location.X, DetailsGroup.Location.Y + DetailsGroup.Size.Height + 10);
				}
			else
				{
				OKButton.Location = new Point(OKButton.Location.X, AcquisitionGroupBox.Location.Y + AcquisitionGroupBox.Size.Height + 10);
				FormCancelButton.Location = new Point(FormCancelButton.Location.X, AcquisitionGroupBox.Location.Y + AcquisitionGroupBox.Size.Height + 10);
				}

			ScopePowerTextBox.Required = m_Gear.GearType == cGear.eGearTypes.Scope;
			ScopeObjectiveTextBox.Required = m_Gear.GearType == cGear.eGearTypes.Scope;
			ScopeClickTextBox.MinValue = m_Gear.GearType == cGear.eGearTypes.Scope ? 0.001 : 0.000;

			// TODO: Add Red Dot Settings here

			SetClientSizeCore(GeneralGroup.Location.X + GeneralGroup.Width + 10, FormCancelButton.Location.Y + FormCancelButton.Height + 20);
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

			SourceCombo.MaxLength = 35;

			ScopePowerTextBox.MaxLength = 10;
			ScopePowerTextBox.ValidChars = "0123456789-.";

			ScopeObjectiveTextBox.MaxLength = 5;
			ScopeObjectiveTextBox.ValidChars = "0123456789.";

			PriceLabel.Text = String.Format("Price ({0}):", m_DataFiles.Preferences.Currency);

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

			// Scope

			ScopePowerTextBox.ToolTip = cm_strScopePowerToolTip;
			ScopeObjectiveTextBox.ToolTip = cm_strScopeObjectiveToolTip;

			m_ScopeTubeToolTip.ShowAlways = true;
			m_ScopeTubeToolTip.RemoveAll();
			m_ScopeTubeToolTip.SetToolTip(ScopeTubeCombo, cm_strScopeTubeToolTip);

			ScopeClickTextBox.ToolTip = cm_strScopeClickToolTip;

			m_ScopeTypeToolTip.ShowAlways = true;
			m_ScopeTypeToolTip.RemoveAll();
			m_ScopeTypeToolTip.SetToolTip(ScopeTurretTypeCombo, cm_strScopeTypeToolTip);

			// Buttons

			m_OKButtonToolTip.ShowAlways = true;
			m_OKButtonToolTip.RemoveAll();
			m_OKButtonToolTip.SetToolTip(OKButton, cm_strOKButtonToolTip);

			m_CancelButtonToolTip.ShowAlways = true;
			m_CancelButtonToolTip.RemoveAll();
			m_CancelButtonToolTip.SetToolTip(FormCancelButton, m_fViewOnly ? cm_strCloseButtonToolTip : cm_strCancelButtonToolTip);
			}

		//============================================================================*
		// UpdateButtons()
		//============================================================================*

		public void UpdateButtons()
			{
			bool fEnableOK = m_fChanged;

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
			PriceTextBox.Enabled = !String.IsNullOrEmpty(SourceCombo.Text);

			//----------------------------------------------------------------------------*
			// Check Scope Details
			//----------------------------------------------------------------------------*

			if (m_Gear.GearType == cGear.eGearTypes.Scope)
				{
				if (!ScopePowerTextBox.ValueOK || !ScopeObjectiveTextBox.ValueOK || !ScopeClickTextBox.ValueOK)
					fEnableOK = false;
				}

			//----------------------------------------------------------------------------*
			// Set Button States
			//----------------------------------------------------------------------------*

			OKButton.Enabled = fEnableOK;
			}
		}
	}
