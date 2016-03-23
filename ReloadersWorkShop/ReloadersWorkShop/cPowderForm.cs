//============================================================================*
// cPowderForm.cs
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
	// cPowderForm Class
	//============================================================================*

	public partial class cPowderForm : Form
		{
		//----------------------------------------------------------------------------*
		// Private Const Data Members
		//----------------------------------------------------------------------------*

		private const string cm_strFirearmTypeToolTip = "Type of Firearm for which this powder is used.";
		private const string cm_strManufacturerToolTip = "Manufacturer of this powder.";
		private const string cm_strModelToolTip = "Manufacturer's model or part number for this powder.";
		private const string cm_strShapeToolTip = "Shape of the kernels for this powder.";

		private const string cm_strWeightToolTip = "Weight, in pounds, that can be bought for the price specified.";
		private const string cm_strPriceToolTip = "Price for the specified weight of this powder.";

		private const string cm_strPowderOKButtonToolTip = "Click to add or update the powder with the above data.";
		private const string cm_strPowderCancelButtonToolTip = "Click to cancel changes and return to the main window.";

		//----------------------------------------------------------------------------*
		// Private Data Members
		//----------------------------------------------------------------------------*

		private cPowder m_Powder = null;
		private cDataFiles m_DataFiles;

		private bool m_fViewOnly = false;

		private bool m_fInitialized = false;

		private bool m_fAdd = false;
		private bool m_fChanged = false;

		private string m_strOriginalModel = "";

		private ToolTip m_FirearmTypeToolTip = new ToolTip();
		private ToolTip m_ManufacturerToolTip = new ToolTip();
		private ToolTip m_ModelToolTip = new ToolTip();
		private ToolTip m_ShapeToolTip = new ToolTip();
		private ToolTip m_WeightToolTip = new ToolTip();
		private ToolTip m_PriceToolTip = new ToolTip();

		private ToolTip m_PowderOKButtonToolTip = new ToolTip();
		private ToolTip m_PowderCancelButtonToolTip = new ToolTip();

		//============================================================================*
		// cPowderForm() - Constructor
		//============================================================================*

		public cPowderForm(cPowder Powder, cDataFiles DataFiles, bool fViewOnly = false)
			{
			InitializeComponent();

			m_DataFiles = DataFiles;
			m_fViewOnly = fViewOnly;

			if (Powder == null)
				{
				if (m_fViewOnly)
					return;

				m_fAdd = true;

				if (m_DataFiles.Preferences.LastPowder == null)
					m_Powder = new cPowder();
				else
					{
					if (m_DataFiles.Preferences.LastPowder != null)
						m_Powder = new cPowder(m_DataFiles.Preferences.LastPowder);

					m_Powder.Model = "";
					m_Powder.PowderType = cPowder.ePowderType.Other;
					m_Powder.Cost = 0.0;
					m_Powder.Quantity = 0;

					m_Powder.TransactionList.Clear();
					m_Powder.RecalculateInventory(m_DataFiles);
					}

				PowderOKButton.Text = "Add";
				}
			else
				{
				m_Powder = new cPowder(Powder);

				m_strOriginalModel = m_Powder.Model;

				if (m_fViewOnly)
					{
					PowderOKButton.Visible = false;

					int nButtonX = (this.Size.Width / 2) - (PowderCancelButton.Width / 2);

					PowderCancelButton.Location = new Point(nButtonX, PowderCancelButton.Location.Y);

					PowderCancelButton.Text = "Close";
					}
				else
					PowderOKButton.Text = "Update";
				}

			SetClientSizeCore(GeneralGroupBox.Location.X + GeneralGroupBox.Width + 10, PowderCancelButton.Location.Y + PowderCancelButton.Height + 20);

			//----------------------------------------------------------------------------*
			// Set Control Event Handlers
			//----------------------------------------------------------------------------*

			if (!m_fViewOnly)
				{
				FirearmTypeCombo.SelectedIndexChanged += OnFirearmTypeChanged;
				ManufacturerCombo.SelectedIndexChanged += OnManufacturerSelected;

				ModelTextBox.TextChanged += OnModelChanged;

				ShapeCombo.SelectedIndexChanged += OnShapeChanged;

				QuantityTextBox.TextChanged += OnQuantityChanged;

				CostTextBox.TextChanged += OnPriceChanged;
				}
			else
				{
				ModelTextBox.ReadOnly = true;
				QuantityTextBox.ReadOnly = true;
				CostTextBox.ReadOnly = true;
				}

			InventoryButton.Click += OnInventoryClicked;

			//----------------------------------------------------------------------------*
			// Fill in powder data
			//----------------------------------------------------------------------------*

			SetInputParameters();

			FirearmTypeCombo.Value = m_Powder.FirearmType;

			PopulateManufacturerCombo();

			ModelTextBox.Text = m_Powder.Model;
			ShapeCombo.SelectedIndex = (int) m_Powder.PowderType;

			PopulateInventoryData();

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

				CostLabel.Text = "Value:";
				}
			else
				{
				InventoryButton.Visible = false;

				CostLabel.Text = String.Format("Cost ({0}):", m_DataFiles.Preferences.Currency);
				}

			InventoryGroupBox.Text = "Inventory Info";

			//----------------------------------------------------------------------------*
			// Set title and text fields
			//----------------------------------------------------------------------------*

			string strTitle;

			if (Powder == null)
				strTitle = "Add";
			else
				{
				if (m_fViewOnly)
					strTitle = "View";
				else
					strTitle = "Edit";
				}

			strTitle += " Powder";

			Text = strTitle;

			SetStaticToolTips();

			m_fInitialized = true;

			UpdateButtons();

			if (!m_fViewOnly)
				FirearmTypeCombo.Focus();
			else
				PowderCancelButton.Focus();
			}

		//============================================================================*
		// OnFirearmTypeChanged()
		//============================================================================*

		private void OnFirearmTypeChanged(object sender, EventArgs e)
			{
			if (!m_fInitialized)
				return;

			m_Powder.FirearmType = FirearmTypeCombo.Value;

			m_fChanged = true;

			UpdateButtons();
			}

		//============================================================================*
		// OnInventoryClicked()
		//============================================================================*

		private void OnInventoryClicked(object sender, EventArgs e)
			{
			cInventoryForm InventoryForm = new cInventoryForm(m_Powder, m_DataFiles, m_fViewOnly);

			InventoryForm.ShowDialog();

			if (!m_fChanged)
				m_fChanged = InventoryForm.Changed;

			PopulateInventoryData();

			UpdateButtons();
			}

		//============================================================================*
		// OnManufacturerSelected()
		//============================================================================*

		private void OnManufacturerSelected(object sender, EventArgs e)
			{
			if (!m_fInitialized || ManufacturerCombo.SelectedIndex < 0)
				return;

			m_Powder.Manufacturer = (cManufacturer) ManufacturerCombo.SelectedItem;

			m_fChanged = true;

			UpdateButtons();
			}

		//============================================================================*
		// OnModelChanged()
		//============================================================================*

		private void OnModelChanged(object sender, EventArgs e)
			{
			if (!m_fInitialized)
				return;

			m_Powder.Model = ModelTextBox.Text;

			m_fChanged = true;

			UpdateButtons();
			}

		//============================================================================*
		// OnPriceChanged()
		//============================================================================*

		private void OnPriceChanged(object sender, EventArgs e)
			{
			if (!m_fInitialized)
				return;

			m_Powder.Cost = CostTextBox.Value;

			m_fChanged = true;

			SetCostEach();

			UpdateButtons();
			}

		//============================================================================*
		// OnQuantityChanged()
		//============================================================================*

		private void OnQuantityChanged(object sender, EventArgs e)
			{
			if (!m_fInitialized)
				return;

			double dQuantity = QuantityTextBox.Value * (m_DataFiles.Preferences.MetricCanWeights ? 1000.0 : 7000.0);

            m_Powder.Quantity = m_DataFiles.MetricToStandard(dQuantity, cDataFiles.eDataType.CanWeight);

			m_fChanged = true;

			SetCostEach();

			UpdateButtons();
			}

		//============================================================================*
		// OnShapeChanged()
		//============================================================================*

		private void OnShapeChanged(object sender, EventArgs e)
			{
			if (!m_fInitialized)
				return;

			m_Powder.PowderType = (cPowder.ePowderType) ShapeCombo.SelectedIndex;
 
			m_fChanged = true;

			UpdateButtons();
			}

		//============================================================================*
		// PopulateInventoryData()
		//============================================================================*

		private void PopulateInventoryData()
			{
			double dQuantity = m_DataFiles.StandardToMetric(m_DataFiles.SupplyQuantity(m_Powder) / 7000.0, cDataFiles.eDataType.CanWeight);

			QuantityTextBox.Value = dQuantity;

			CostTextBox.Value = m_DataFiles.SupplyCost(m_Powder);

			if (m_DataFiles.Preferences.TrackInventory)
				CostTextBox.Text = String.Format("{0}{1:F2}", m_DataFiles.Preferences.Currency, CostTextBox.Value);

			SetCostEach();
			}

		//============================================================================*
		// PopulateManufacturerCombo()
		//============================================================================*

		private void PopulateManufacturerCombo()
			{
			ManufacturerCombo.Items.Clear();

			//----------------------------------------------------------------------------*
			// Populate the manufacturer combo
			//----------------------------------------------------------------------------*

			if (!m_fViewOnly)
				{
				cManufacturer SelectManufacturer = null;

				foreach (cManufacturer Manufacturer in m_DataFiles.ManufacturerList)
					{
					if (Manufacturer.Powder)
						{
						ManufacturerCombo.Items.Add(Manufacturer);

						if (Manufacturer.CompareTo(m_Powder.Manufacturer) == 0)
							SelectManufacturer = Manufacturer;
						}
					}

				if (SelectManufacturer != null)
					ManufacturerCombo.SelectedIndex = ManufacturerCombo.Items.IndexOf(SelectManufacturer);
				else
					ManufacturerCombo.SelectedIndex = 0;
				}
			else
				{
				ManufacturerCombo.Items.Clear();

				ManufacturerCombo.Items.Add(m_Powder.Manufacturer);

				ManufacturerCombo.SelectedIndex = 0;
				}

			if (m_Powder.Manufacturer == null)
				m_Powder.Manufacturer = (cManufacturer) ManufacturerCombo.SelectedItem;
			}

		//============================================================================*
		// Powder Property
		//============================================================================*

		public cPowder Powder
			{
			get
				{
				return (m_Powder);
				}
			}

		//============================================================================*
		// SetCostEach()
		//============================================================================*

		private void SetCostEach()
			{
			double dCostEach = (QuantityTextBox.Value > 0.0 ? CostTextBox.Value / QuantityTextBox.Value : 0.0);

			if (m_DataFiles.Preferences.TrackInventory)
				dCostEach = m_DataFiles.SupplyCostEach(m_Powder) * m_DataFiles.StandardToMetric(7000.0, cDataFiles.eDataType.CanWeight);

			CostLbLabel.Text = String.Format("Cost/{0}:", m_DataFiles.MetricString(cDataFiles.eDataType.CanWeight));

			CostEachLabel.Text = String.Format("{0}{1:F2}", m_DataFiles.Preferences.Currency, dCostEach);

			CanWeightLabel.Text = String.Format("{0}{1}", m_DataFiles.MetricString(cDataFiles.eDataType.CanWeight), QuantityTextBox.Value != 1.0 ? "s" : "");
			}

		//============================================================================*
		// SetInputParameters()
		//============================================================================*

		private void SetInputParameters()
			{
			//----------------------------------------------------------------------------*
			// Powder Weight Label
			//----------------------------------------------------------------------------*


			//----------------------------------------------------------------------------*
			// Set Text Box Parameters
			//----------------------------------------------------------------------------*

			m_DataFiles.SetInputParameters(QuantityTextBox, cDataFiles.eDataType.Quantity, true);

			m_DataFiles.SetInputParameters(CostTextBox, cDataFiles.eDataType.Cost);
		}

	//============================================================================*
	// SetMinMax()
	//============================================================================*

	private void SetMinMax()
			{
			QuantityTextBox.MinValue = 0.0;
			CostTextBox.MinValue = 0.0;

			if (CostTextBox.Value > 0.0)
				QuantityTextBox.MinValue = 0.01;
			}

		//============================================================================*
		// SetStaticToolTips()
		//============================================================================*

		private void SetStaticToolTips()
			{
			if (!m_DataFiles.Preferences.ToolTips)
				return;

			m_FirearmTypeToolTip.ShowAlways = true;
			m_FirearmTypeToolTip.RemoveAll();
			m_FirearmTypeToolTip.SetToolTip(FirearmTypeCombo, cm_strFirearmTypeToolTip);

			m_ManufacturerToolTip.ShowAlways = true;
			m_ManufacturerToolTip.RemoveAll();
			m_ManufacturerToolTip.SetToolTip(ManufacturerCombo, cm_strManufacturerToolTip);

			ModelTextBox.ToolTip = cm_strModelToolTip;

			m_ShapeToolTip.ShowAlways = true;
			m_ShapeToolTip.RemoveAll();
			m_ShapeToolTip.SetToolTip(ShapeCombo, cm_strShapeToolTip);

			QuantityTextBox.ToolTip = cm_strWeightToolTip;
			CostTextBox.ToolTip = cm_strPriceToolTip;

			m_PowderOKButtonToolTip.ShowAlways = true;
			m_PowderOKButtonToolTip.RemoveAll();
			m_PowderOKButtonToolTip.SetToolTip(PowderOKButton, cm_strPowderOKButtonToolTip);

			m_PowderCancelButtonToolTip.ShowAlways = true;
			m_PowderCancelButtonToolTip.RemoveAll();
			m_PowderCancelButtonToolTip.SetToolTip(PowderCancelButton, cm_strPowderCancelButtonToolTip);
			}

		//============================================================================*
		// UpdateButtons()
		//============================================================================*

		private void UpdateButtons()
			{
			if (m_fViewOnly)
				return;

			SetMinMax();

			bool fEnableOK = m_fChanged;

			//----------------------------------------------------------------------------*
			// Check Model
			//----------------------------------------------------------------------------*

			string strText = cm_strModelToolTip;

			if (!ModelTextBox.ValueOK)
				fEnableOK = false;

			if (m_fAdd)
				{
				bool fTypeFound = false;

				foreach (cPowder Powder in m_DataFiles.PowderList)
					{
					if (m_Powder.CompareTo(Powder) == 0)
						{
						fEnableOK = false;

						strText += "\n\nThis Manufacturer/Type combination already exists.  Duplicates are not allowed.";

						fTypeFound = true;

						break;
						}
					}

				if (fTypeFound)
					ModelTextBox.BackColor = Color.LightPink;
				else
					ModelTextBox.BackColor = SystemColors.Window;
				}

			if (m_DataFiles.Preferences.ToolTips)
				m_ModelToolTip.SetToolTip(ModelTextBox, strText);

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
			// Set Buttons
			//----------------------------------------------------------------------------*

			PowderOKButton.Enabled = fEnableOK;
			}
		}
	}
