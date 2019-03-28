//============================================================================*
// cFirearmAccessoryForm.cs
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
	// cFirearmAccessoryForm Class
	//============================================================================*

	public partial class cFirearmAccessoryForm : Form
		{
		//============================================================================*
		// Private Constant Data Members
		//============================================================================*

		private const string cm_strTypeToolTip = "The general type of this part or accessory.";
		private const string cm_strManufacturerToolTip = "Select the manufacturer of this part or accessory.";
		private const string cm_strPartNumberToolTip = "Enter the manufacturer's part number for this part or accessory.";
		private const string cm_strSerialNumberToolTip = "Enter this part or accessory's serial number, if any.";
		private const string cm_strDescriptionToolTip = "Enter a description of this part or accessory.";
		private const string cm_strNotesToolTip = "Enter any notes you might have for this part or accessory.";

		private const string cm_strSourceToolTip = "Enter where you obtained this part or accessory.";
		private const string cm_strPriceToolTip = "Enter what you paid for this part or accessory.";
		private const string cm_strPurchaseDateToolTip = "Enter the date when you obtained this part or accessory.";

		private const string cm_strMagnifierPowerToolTip = "Enter this Magnifier's magnification, leaving off the trailing 'x'. Example: 6, 3-9, 6-24, etc.";
		private const string cm_strMagnifierEyeReliefToolTip = "Enter this Magnifier's eye relief distance.";
		private const string cm_strMagnifierFoVToolTip = "Enter this Magnifier's Field of View in Degrees.";

		private const string cm_strScopePowerToolTip = "Enter this scope's power, leaving off the trailing 'x'. Example: 6, 3-9, 6-24, etc.";
		private const string cm_strScopeObjectiveToolTip = "Enter this scope's Objective in millimeters.";
		private const string cm_strScopeTubeSizeToolTip = "Enter this scope's tube diameter.";
		private const string cm_strScopeTubeToolTip = "Select this scope's tube diameter measurement.";
		private const string cm_strScopeClickToolTip = "Enter this scope's turret click increment.";
		private const string cm_strScopeTypeToolTip = "Select this scope's turret type.";
		private const string cm_strScopeBatteryToolTip = "Enter the battery information for this scope.  (2x2032, CR200, etc...)";
		private const string cm_strScopeEyeReliefToolTip = "Enter this Scope's eye relief distance.";

		private const string cm_strRedDotMOAToolTip = "Enter the MOA of this sight's dot.";
		private const string cm_strRedDotCowitnessHeightToolTip = "Enter the height at which this sight will line up with iron sights.";
		private const string cm_strRedDotTubeDiameterToolTip = "Enter this sight's tube diameter.";
		private const string cm_strRedDotBatteryToolTip = "Enter the battery information for this sight.  (2x2032, CR200, etc...)";

		private const string cm_strLightLumensToolTip = "Enter the lumen value for this light.";
		private const string cm_strLightBatteryToolTip = "Enter the battery information for this light.  (2x2032, CR200, etc...)";

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

		private bool m_fUserTax = false;

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

					case cGear.eGearTypes.Light:
						m_Gear = new cLight((Gear as cLight));
						break;

					case cGear.eGearTypes.RedDot:
						m_Gear = new cRedDot((Gear as cRedDot));
						break;

					case cGear.eGearTypes.Magnifier:
						m_Gear = new cMagnifier((Gear as cMagnifier));
						break;

					default:
						m_Gear = new cGear(Gear);
						break;
					}
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

				// Light Details

				LightBatteryTextBox.TextChanged += OnLightBatteryChanged;
				LightLumensTextBox.TextChanged += OnLightLumensChanged;

				// Magnifier Details

				MagnifierPowerTextBox.TextChanged += OnMagnifierPowerChanged;
				MagnifierEyeReliefTextBox.TextChanged += OnMagnifierEyeReliefChanged;
				MagnifierFoVTextBox.TextChanged += OnMagnifierFoVChanged;

				// Scope Details

				ScopePowerTextBox.TextChanged += OnScopePowerChanged;
				ScopeObjectiveTextBox.TextChanged += OnScopeObjectiveChanged;
				ScopeTubeSizeTextBox.TextChanged += OnScopeTubeSizeChanged;
				ScopeTubeSizeCombo.SelectedIndexChanged += OnScopeTubeSizeChanged;
				ScopeClickTextBox.TextChanged += OnScopeClickChanged;
				ScopeTurretTypeCombo.SelectedIndexChanged += OnScopeTurretTypeChanged;
				ScopeBatteryTextBox.TextChanged += OnScopeBatteryChanged;
				ScopeEyeReliefTextBox.TextChanged += OnScopeEyeReliefChanged;

				// Red Dot Details

				RedDotMOATextBox.TextChanged += OnRedDotMOAChanged;
				RedDotCowitnessTextBox.TextChanged += OnRedDotCowitnessChanged;
				RedDotTubeDiameterTextBox.TextChanged += OnRedDotTubeSizeChanged;
				RedDotBatteryTextBox.TextChanged += OnRedDotBatteryChanged;
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

				// Light Details

				LightBatteryTextBox.ReadOnly = true;
				LightLumensTextBox.ReadOnly = true;

				// Magnifier Details

				MagnifierPowerTextBox.ReadOnly = true;
				MagnifierEyeReliefTextBox.ReadOnly = true;
				MagnifierFoVTextBox.ReadOnly = true;

				// Red Dot Details

				RedDotMOATextBox.ReadOnly = true;
				RedDotCowitnessTextBox.ReadOnly = true;
				RedDotTubeDiameterTextBox.ReadOnly = true;
				RedDotBatteryTextBox.ReadOnly = true;

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

//			SetInputParameters();

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
				case cGear.eGearTypes.Light:
					return (new cLight());

				case cGear.eGearTypes.Magnifier:
					return (new cMagnifier());

				case cGear.eGearTypes.RedDot:
					return (new cRedDot());

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

			m_Gear.Description = @DescriptionTextBox.Value;

			m_fChanged = true;

			UpdateButtons();
			}

		//============================================================================*
		// OnLightBatteryChanged()
		//============================================================================*

		public void OnLightBatteryChanged(Object sender, EventArgs args)
			{
			if (!m_fInitialized || m_fPopulating)
				return;

			(m_Gear as cLight).Battery = LightBatteryTextBox.Text;

			m_fChanged = true;

			UpdateButtons();
			}

		//============================================================================*
		// OnLightLumensChanged()
		//============================================================================*

		public void OnLightLumensChanged(Object sender, EventArgs args)
			{
			if (!m_fInitialized || m_fPopulating)
				return;

			(m_Gear as cLight).Lumens = LightLumensTextBox.Value;

			m_fChanged = true;

			UpdateButtons();
			}

		//============================================================================*
		// OnMagnifierFoVChanged()
		//============================================================================*

		public void OnMagnifierFoVChanged(Object sender, EventArgs args)
			{
			if (!m_fInitialized || m_fPopulating)
				return;

			(m_Gear as cMagnifier).FoV = MagnifierFoVTextBox.Value;

			m_fChanged = true;

			UpdateButtons();
			}

		//============================================================================*
		// OnMagnifierPowerChanged()
		//============================================================================*

		public void OnMagnifierPowerChanged(Object sender, EventArgs args)
			{
			if (!m_fInitialized || m_fPopulating)
				return;

			(m_Gear as cMagnifier).Magnification = MagnifierPowerTextBox.Value;

			m_fChanged = true;

			UpdateButtons();
			}

		//============================================================================*
		// OnMagnifierEyeReliefChanged()
		//============================================================================*

		public void OnMagnifierEyeReliefChanged(Object sender, EventArgs args)
			{
			if (!m_fInitialized || m_fPopulating)
				return;

			(m_Gear as cMagnifier).EyeRelief = MagnifierEyeReliefTextBox.Value;

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
		// OnNotesChanged()
		//============================================================================*

		public void OnNotesChanged(Object sender, EventArgs args)
			{
			if (!m_fInitialized || m_fPopulating)
				return;

			m_Gear.Notes = @NotesTextBox.Value;

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

			m_Gear.PartNumber = @PartNumberTextBox.Value;

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

			if (m_DataFiles.Preferences.TaxRate != 0.0 && !m_fUserTax)
				{
				m_Gear.Tax = Math.Round(m_Gear.PurchasePrice * (m_DataFiles.Preferences.TaxRate / 100.0), 2);

				TaxTextBox.Value = m_Gear.Tax;
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
				m_Gear.PurchaseDate = PurchaseDatePicker.Value;
				}
			catch
				{
				m_Gear.PurchaseDate = DateTime.Today;
				}

			m_fChanged = true;

			UpdateButtons();
			}

		//============================================================================*
		// OnRedDotBatteryChanged()
		//============================================================================*

		public void OnRedDotBatteryChanged(Object sender, EventArgs args)
			{
			if (!m_fInitialized || m_fPopulating)
				return;

			(m_Gear as cRedDot).Battery = @RedDotBatteryTextBox.Value;

			m_fChanged = true;

			UpdateButtons();
			}

		//============================================================================*
		// OnRedDotCowitnessChanged()
		//============================================================================*

		public void OnRedDotCowitnessChanged(Object sender, EventArgs args)
			{
			if (!m_fInitialized || m_fPopulating)
				return;

			(m_Gear as cRedDot).CowitnessHeight = RedDotCowitnessTextBox.Value;

			m_fChanged = true;

			UpdateButtons();
			}

		//============================================================================*
		// OnRedDotMOAChanged()
		//============================================================================*

		public void OnRedDotMOAChanged(Object sender, EventArgs args)
			{
			if (!m_fInitialized || m_fPopulating)
				return;

			(m_Gear as cRedDot).DotMOA = RedDotMOATextBox.Value;

			m_fChanged = true;

			UpdateButtons();
			}

		//============================================================================*
		// OnRedDotTubeSizeChanged()
		//============================================================================*

		public void OnRedDotTubeSizeChanged(Object sender, EventArgs args)
			{
			if (!m_fInitialized || m_fPopulating)
				return;

			(m_Gear as cRedDot).TubeDiameter = RedDotTubeDiameterTextBox.Value;

			m_fChanged = true;

			UpdateButtons();
			}

		//============================================================================*
		// OnScopeBatteryChanged()
		//============================================================================*

		public void OnScopeBatteryChanged(Object sender, EventArgs args)
			{
			if (!m_fInitialized || m_fPopulating)
				return;

			(m_Gear as cScope).Battery = ScopeBatteryTextBox.Text;

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
		// OnScopeEyeReliefChanged()
		//============================================================================*

		public void OnScopeEyeReliefChanged(Object sender, EventArgs args)
			{
			if (!m_fInitialized || m_fPopulating)
				return;

			(m_Gear as cScope).EyeRelief = cDataFiles.MetricToStandard(ScopeEyeReliefTextBox.Value, cDataFiles.eDataType.Firearm);

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

			int nTubeSize = 1;
			Int32.TryParse(ScopeTubeSizeTextBox.Text, out nTubeSize);

			(m_Gear as cScope).TubeSize = nTubeSize;
			(m_Gear as cScope).TubeMeasurement = (cScope.eTubeMeasurements) ScopeTubeSizeCombo.SelectedIndex;

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

			(m_Gear as cScope).TurretType = (cFirearm.eTurretType) ScopeTurretTypeCombo.SelectedIndex;

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

			m_Gear.SerialNumber = @SerialNumberTextBox.Value;

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

			m_Gear.Shipping = ShippingTextBox.Value;

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

			m_Gear.Source = SourceCombo.Text;

			if (String.IsNullOrEmpty(m_Gear.Source))
				{
				m_Gear.PurchasePrice = 0.0;
				m_Gear.Tax = 0.0;
				m_Gear.Shipping = 0.0;

				PopulateGearData();
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

			m_Gear.Tax = TaxTextBox.Value;

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
			NotesTextBox.Value = m_Gear.Notes;

			//----------------------------------------------------------------------------*
			// Acquisition Details
			//----------------------------------------------------------------------------*

			SourceCombo.Text = m_Gear.Source;

			try
				{
				PurchaseDatePicker.Value = m_Gear.PurchaseDate;
				}
			catch
				{
				PurchaseDatePicker.Value = DateTime.Today;

				m_Gear.PurchaseDate = PurchaseDatePicker.Value;

				m_fChanged = true;
				}

			PriceTextBox.Value = m_Gear.PurchasePrice;
			TaxTextBox.Value = m_Gear.Tax;
			ShippingTextBox.Value = m_Gear.Shipping;

			SetTotal();

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
					ScopeBatteryTextBox.Value = (m_Gear as cScope).Battery;
					ScopeEyeReliefTextBox.Value = (m_Gear as cScope).EyeRelief;

					//----------------------------------------------------------------------------*
					// Turret Tube Size info
					//----------------------------------------------------------------------------*

					ScopeTubeSizeTextBox.Text = (m_Gear as cScope).TubeSize.ToString();

					if (m_fViewOnly)
						{
						ScopeTubeSizeCombo.Items.Clear();

						ScopeTubeSizeCombo.Items.Add(cScope.TubeMeasurementString((m_Gear as cScope).TubeMeasurement));

						ScopeTubeSizeCombo.SelectedIndex = 0;
						}
					else
						{
						ScopeTubeSizeCombo.SelectedIndex = (int) (m_Gear as cScope).TubeMeasurement;

						if (ScopeTubeSizeCombo.SelectedIndex < 0 && ScopeTubeSizeCombo.Items.Count > 0)
							{
							ScopeTubeSizeCombo.SelectedIndex = 0;

							(m_Gear as cScope).TubeMeasurement = (cScope.eTubeMeasurements) ScopeTubeSizeCombo.SelectedIndex;
							}
						}

					//----------------------------------------------------------------------------*
					// Turret Type Combo
					//----------------------------------------------------------------------------*

					if (m_fViewOnly)
						{
						ScopeTurretTypeCombo.Items.Clear();

						ScopeTurretTypeCombo.Items.Add(cFirearm.TurretTypeString((m_Gear as cScope).TurretType));

						ScopeTurretTypeCombo.SelectedIndex = 0;
						}
					else
						{
						ScopeTurretTypeCombo.SelectedIndex = (int) (m_Gear as cScope).TurretType;

						if (ScopeTurretTypeCombo.SelectedIndex < 0 && ScopeTurretTypeCombo.Items.Count > 0)
							{
							ScopeTurretTypeCombo.SelectedIndex = 0;

							(m_Gear as cScope).TurretType = (cFirearm.eTurretType) ScopeTurretTypeCombo.SelectedIndex;
							}
						}

					break;

				//----------------------------------------------------------------------------*
				// Light Details
				//----------------------------------------------------------------------------*

				case cGear.eGearTypes.Light:
					LightLumensTextBox.Value = (m_Gear as cLight).Lumens;
					LightBatteryTextBox.Value = (m_Gear as cLight).Battery;
					break;

				//----------------------------------------------------------------------------*
				// Magnifier Details
				//----------------------------------------------------------------------------*

				case cGear.eGearTypes.Magnifier:
					MagnifierPowerTextBox.Value = (m_Gear as cMagnifier).Magnification;
					MagnifierEyeReliefTextBox.Value = (m_Gear as cMagnifier).EyeRelief;
					MagnifierFoVTextBox.Value = (m_Gear as cMagnifier).FoV;
					break;

				//----------------------------------------------------------------------------*
				// Red Dot Details
				//----------------------------------------------------------------------------*

				case cGear.eGearTypes.RedDot:
					RedDotMOATextBox.Value = (m_Gear as cRedDot).DotMOA;
					RedDotCowitnessTextBox.Value = (m_Gear as cRedDot).CowitnessHeight;
					RedDotTubeDiameterTextBox.Value = (m_Gear as cRedDot).TubeDiameter;
					RedDotBatteryTextBox.Value = (m_Gear as cRedDot).Battery;
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
				bool fLasers = false;
				bool fRedDots = false;
				bool fMagnifiers = false;
				bool fLights = false;
				bool fTriggers = false;
				bool fFurniture = false;
				bool fBipods = false;
				bool fParts = false;
				bool fMisc = false;

				foreach (cManufacturer Manufacturer in m_DataFiles.ManufacturerList)
					{
					fScopes = !fScopes ? Manufacturer.Scopes : fScopes;
					fLasers = !fLasers ? Manufacturer.Lasers : fLasers;
					fRedDots = !fRedDots ? Manufacturer.RedDots : fRedDots;
					fMagnifiers = !fMagnifiers ? Manufacturer.Magnifiers : fMagnifiers;
					fLights = !fLights ? Manufacturer.Lights : fLights;
					fTriggers = !fTriggers ? Manufacturer.Triggers : fTriggers;
					fFurniture = !fFurniture ? Manufacturer.Furniture : fFurniture;
					fBipods = !fBipods ? Manufacturer.Bipods : fBipods;
					fParts = !fParts ? Manufacturer.Parts : fParts;
					fMisc = !fMisc ? Manufacturer.Misc : fMisc;
					}

				if (fScopes)
					TypeCombo.Items.Add(cGear.GearTypeString(cGear.eGearTypes.Scope));

				if (fLasers)
					TypeCombo.Items.Add(cGear.GearTypeString(cGear.eGearTypes.Laser));

				if (fRedDots)
					TypeCombo.Items.Add(cGear.GearTypeString(cGear.eGearTypes.RedDot));

				if (fMagnifiers)
					TypeCombo.Items.Add(cGear.GearTypeString(cGear.eGearTypes.Magnifier));

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
			MagnifierDetailsGroupBox.Visible = m_Gear.GearType == cGear.eGearTypes.Magnifier;
			LightDetailsGroupBox.Visible = m_Gear.GearType == cGear.eGearTypes.Light;

			GroupBox DetailsGroup = null;

			switch (m_Gear.GearType)
				{
				case cGear.eGearTypes.Scope:
					DetailsGroup = ScopeDetailsGroupBox;
					break;

				case cGear.eGearTypes.RedDot:
					DetailsGroup = RedDotDetailsGroupBox;
					break;

				case cGear.eGearTypes.Light:
					DetailsGroup = LightDetailsGroupBox;
					break;

				case cGear.eGearTypes.Magnifier:
					DetailsGroup = MagnifierDetailsGroupBox;
					break;
				}

			if (DetailsGroup != null)
				{
				DetailsGroup.Location = new Point(12, GeneralGroupBox.Location.Y + GeneralGroupBox.Height + 6);

				AcquisitionGroupBox.Location = new Point(12, DetailsGroup.Location.Y + DetailsGroup.Height + 6);
				}
			else
				{
				AcquisitionGroupBox.Location = new Point(12, GeneralGroupBox.Location.Y + GeneralGroupBox.Height + 6);
				}

			NotesGroup.Location = new Point(12, AcquisitionGroupBox.Location.Y + AcquisitionGroupBox.Height + 6);

			OKButton.Location = new Point(OKButton.Location.X, NotesGroup.Location.Y + NotesGroup.Size.Height + 10);
			FormCancelButton.Location = new Point(FormCancelButton.Location.X, NotesGroup.Location.Y + NotesGroup.Size.Height + 10);

			SetClientSizeCore(GeneralGroupBox.Location.X + GeneralGroupBox.Width + 10, FormCancelButton.Location.Y + FormCancelButton.Height + 20);
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

			LightBatteryTextBox.MaxLength = 30;
			LightLumensTextBox.MaxLength = 5;

			MagnifierPowerTextBox.MaxLength = 10;
			MagnifierPowerTextBox.ValidChars = "0123456789-.";

			MagnifierEyeReliefTextBox.NumDecimals = m_DataFiles.Preferences.FirearmDecimals;
			MagnifierEyeReliefTextBox.MaxLength = m_DataFiles.Preferences.FirearmDecimals + 3;

			MagnifierFoVTextBox.NumDecimals = m_DataFiles.Preferences.FirearmDecimals;
			MagnifierFoVTextBox.MaxLength = m_DataFiles.Preferences.FirearmDecimals + 4;

			ScopePowerTextBox.MaxLength = 10;
			ScopePowerTextBox.ValidChars = "0123456789-.";

			ScopeObjectiveTextBox.MaxLength = 3;
			ScopeObjectiveTextBox.ValidChars = "0123456789.";

			RedDotMOATextBox.NumDecimals = m_DataFiles.Preferences.FirearmDecimals;
			RedDotMOATextBox.MaxLength = RedDotMOATextBox.NumDecimals + 2;

			RedDotCowitnessTextBox.NumDecimals = m_DataFiles.Preferences.FirearmDecimals;
			RedDotCowitnessTextBox.MaxLength = RedDotCowitnessTextBox.NumDecimals + 2;
			RedDotCowitnessMeasurementLabel.Text = cDataFiles.MetricString(cDataFiles.eDataType.Firearm);

			RedDotTubeDiameterTextBox.NumDecimals = m_DataFiles.Preferences.FirearmDecimals;
			RedDotTubeDiameterTextBox.MaxLength = RedDotTubeDiameterTextBox.NumDecimals + 3;
			RedDotTubeDiameterMeasurementLabel.Text = cDataFiles.MetricString(cDataFiles.eDataType.Firearm);

			RedDotBatteryTextBox.MaxLength = 30;

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

			// Light

			LightBatteryTextBox.ToolTip = cm_strLightBatteryToolTip;
			LightLumensTextBox.ToolTip = cm_strLightLumensToolTip;

			// Magnifier

			MagnifierPowerTextBox.ToolTip = cm_strMagnifierPowerToolTip;
			MagnifierEyeReliefTextBox.ToolTip = cm_strMagnifierEyeReliefToolTip;
			MagnifierFoVTextBox.ToolTip = cm_strMagnifierFoVToolTip;

			// Scope

			ScopePowerTextBox.ToolTip = cm_strScopePowerToolTip;
			ScopeObjectiveTextBox.ToolTip = cm_strScopeObjectiveToolTip;

			ScopeTubeSizeTextBox.ToolTip = cm_strScopeTubeSizeToolTip;

			m_ScopeTubeToolTip.ShowAlways = true;
			m_ScopeTubeToolTip.RemoveAll();
			m_ScopeTubeToolTip.SetToolTip(ScopeTubeSizeCombo, cm_strScopeTubeToolTip);

			ScopeClickTextBox.ToolTip = cm_strScopeClickToolTip;

			m_ScopeTypeToolTip.ShowAlways = true;
			m_ScopeTypeToolTip.RemoveAll();
			m_ScopeTypeToolTip.SetToolTip(ScopeTurretTypeCombo, cm_strScopeTypeToolTip);

			ScopeBatteryTextBox.ToolTip = cm_strScopeBatteryToolTip;
			ScopeEyeReliefTextBox.ToolTip = cm_strScopeEyeReliefToolTip;

			// Red Dot

			RedDotMOATextBox.ToolTip = cm_strRedDotMOAToolTip;
			RedDotCowitnessTextBox.ToolTip = cm_strRedDotCowitnessHeightToolTip;
			RedDotTubeDiameterTextBox.ToolTip = cm_strRedDotTubeDiameterToolTip;
			RedDotBatteryTextBox.ToolTip = cm_strRedDotBatteryToolTip;
			}

		//============================================================================*
		// SetTotal()
		//============================================================================*

		private void SetTotal()
			{
			TotalLabel.Text = String.Format("{0:F2}", m_Gear.PurchasePrice + m_Gear.Tax + m_Gear.Shipping);
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
			// Check Gear Details
			//----------------------------------------------------------------------------*

			switch (m_Gear.GearType)
				{
				case cGear.eGearTypes.Light:
					if (!LightBatteryTextBox.ValueOK || !LightLumensTextBox.ValueOK)
						fEnableOK = false;
					break;

				case cGear.eGearTypes.Magnifier:
					if (!MagnifierPowerTextBox.ValueOK || !MagnifierEyeReliefTextBox.ValueOK || !MagnifierFoVTextBox.ValueOK)
						fEnableOK = false;
					break;

				case cGear.eGearTypes.Scope:
					if (!ScopePowerTextBox.ValueOK || !ScopeObjectiveTextBox.ValueOK || !ScopeClickTextBox.ValueOK)
						fEnableOK = false;
					break;

				case cGear.eGearTypes.RedDot:
					if (!RedDotMOATextBox.ValueOK || !RedDotCowitnessTextBox.ValueOK || !RedDotTubeDiameterTextBox.ValueOK || !RedDotBatteryTextBox.ValueOK)
						fEnableOK = false;
					break;
				}

			//----------------------------------------------------------------------------*
			// Set Button States
			//----------------------------------------------------------------------------*

			OKButton.Enabled = fEnableOK;
			}
		}
	}
