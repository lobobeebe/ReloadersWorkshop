//============================================================================*
// cTransactionForm.cs
//
// Copyright © 2013-2014, Kevin S. Beebe
// All Rights Reserved
//============================================================================*

//============================================================================*
// .Net Using Statements
//============================================================================*

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

//============================================================================*
// Application Specific Using Statements
//============================================================================*

using ReloadersWorkShop.Controls;
using ReloadersWorkShop.Preferences;

//============================================================================*
// NameSpace
//============================================================================*

namespace ReloadersWorkShop
	{
	//============================================================================*
	// cTransactionForm Class
	//============================================================================*

	public partial class cTransactionForm : Form
		{
		//----------------------------------------------------------------------------*
		// Private Const Data Members
		//----------------------------------------------------------------------------*

		private const string cm_strDateToolTip = "Date of activity.";
		private const string cm_strTypeToolTip = "Type of activity.";
		private const string cm_strPurchaseSourceToolTip = "The store (or gun show, etc.) where you purchased the component.";
		private const string cm_strAdjustReasonToolTip = "The reason for the adjustment.";
		private const string cm_strSourceToolTip = "The source of this activity.";
		private const string cm_strQuantityToolTip = "Quantity (or weight, for powders), being purchased or adjusted.";
		private const string cm_strCostToolTip = "Cost of the quantity (or weight, for powders) of the component being purchased or adjusted.";
		private const string cm_strTaxToolTip = "Taxes paid for this purchase or stock.";
		private const string cm_strShippingToolTip = "Shipping paid for this purchase or stock.";

		private const string cm_strOKButtonToolTip = "Create or upddate the activity and exit.";
		private const string cm_strCancelButtonToolTip = "Cancel all changes and exit.";

		//----------------------------------------------------------------------------*
		// Private Data Members
		//----------------------------------------------------------------------------*

		private cTransaction m_Transaction = null;
		private cDataFiles m_DataFiles = null;
		private bool m_fReload = false;

		private bool m_fViewOnly = false;

		private bool m_fAdd = false;

		private bool m_fChanged = false;

		private double m_dRefQuantity = 0.0;

		private bool m_fInitialized = false;
		private bool m_fPopulating = false;

		private ToolTip m_DateToolTip = new ToolTip();
		private ToolTip m_TypeToolTip = new ToolTip();
		private ToolTip m_SourceToolTip = new ToolTip();

		private ToolTip m_OKButtonToolTip = new ToolTip();
		private ToolTip m_CancelButtonToolTip = new ToolTip();

		//============================================================================*
		// cTransactionForm() - Constructor - Supply
		//============================================================================*

		public cTransactionForm(cSupply Supply, cDataFiles DataFiles)
			{
			InitializeComponent();

			m_DataFiles = DataFiles;

			m_Transaction = new cTransaction();

			m_Transaction.Supply = Supply;

			m_Transaction.TransactionType = m_DataFiles.Preferences.LastActivity;

			if (Supply is cAmmo)
				m_fReload = (Supply as cAmmo).BatchID != 0;

			switch (m_Transaction.TransactionType)
				{
				case cTransaction.eTransactionType.SetStockLevel:
					m_Transaction.Source = "";
					break;

				case cTransaction.eTransactionType.Purchase:
					m_Transaction.Source = m_DataFiles.Preferences.LastPurchaseSource;
					break;

				case cTransaction.eTransactionType.AddStock:
					m_Transaction.Source = m_DataFiles.Preferences.LastAddStockReason;
					break;

				case cTransaction.eTransactionType.ReduceStock:
					m_Transaction.Source = m_DataFiles.Preferences.LastReduceStockReason;
					break;

				case cTransaction.eTransactionType.Fired:
					m_Transaction.Source = m_DataFiles.Preferences.LastFiredLocation;
					break;
				}

			Text = "Add Activity";

			m_fAdd = true;

			TransactionOKButton.Text = "Add";

			Initialize();
			}

		//============================================================================*
		// cTransactionForm() - Constructor - Transaction
		//============================================================================*

		public cTransactionForm(cTransaction Transaction, cDataFiles DataFiles, bool fReload = false)
			{
			InitializeComponent();

			m_Transaction = new cTransaction(Transaction);
			m_DataFiles = DataFiles;
			m_fReload = fReload;

			Text = "Edit Activity";

			m_fAdd = false;

			if (m_Transaction.Supply.SupplyType == cSupply.eSupplyTypes.Powder)
				m_Transaction.Quantity /= 7000.0;

			m_dRefQuantity = m_Transaction.Quantity;

			TransactionOKButton.Text = "Update";

			Initialize();
			}

		//============================================================================*
		// Initialize()
		//============================================================================*

		private void Initialize()
			{
			SetClientSizeCore(TransactionGroupBox.Location.X + TransactionGroupBox.Width + 10, TransactionCancelButton.Location.Y + TransactionCancelButton.Height + 20);

			//----------------------------------------------------------------------------*
			// Set Control Event Handlers
			//----------------------------------------------------------------------------*

			TransactionTypeCombo.SelectedIndexChanged += OnTransactionTypeChanged;
			SourceCombo.TextChanged += OnSourceChanged;

			DatePicker.ValueChanged += OnDateChanged;

			QuantityTextBox.TextChanged += OnQuantityChanged;
			CostTextBox.TextChanged += OnCostChanged;
			TaxTextBox.TextChanged += OnTaxChanged;
			ShippingTextBox.TextChanged += OnShippingChanged;

			TransactionOKButton.Click += OnOKClicked;

			//----------------------------------------------------------------------------*
			// Populate Combo Boxes and Data
			//----------------------------------------------------------------------------*

			SetInputParameters();

			SetStaticToolTips();

			PopulateTransactionTypeCombo();

			SetTransactionTypeControls();

			PopulateSourceCombo();

			PopulateTransactionData();

			SetMinMax();

			//----------------------------------------------------------------------------*
			// Finish up & exit
			//----------------------------------------------------------------------------*

			m_fInitialized = true;
			}

		//============================================================================*
		// OnCostChanged()
		//============================================================================*

		private void OnCostChanged(object sender, EventArgs e)
			{
			if (!m_fInitialized || m_fPopulating)
				return;

			double dCost = CostTextBox.Value;

			m_Transaction.Cost = dCost;

			if (m_DataFiles.Preferences.TaxRate != 0.0 && (m_Transaction.TransactionType == cTransaction.eTransactionType.Purchase || m_Transaction.TransactionType == cTransaction.eTransactionType.SetStockLevel))
				m_Transaction.Tax = m_Transaction.Cost * (m_DataFiles.Preferences.TaxRate / 100.0);

			TaxTextBox.Value = m_Transaction.Tax;

			TotalTextBox.Value = m_Transaction.Cost + m_Transaction.Tax + m_Transaction.Shipping;

			SetAvgCost();

			m_fChanged = true;

			UpdateButtons();
			}

		//============================================================================*
		// OnDateChanged()
		//============================================================================*

		private void OnDateChanged(object sender, EventArgs e)
			{
			if (!m_fInitialized || m_fPopulating)
				return;

			m_Transaction.Date = DatePicker.Value;

			m_fChanged = true;

			UpdateButtons();
			}

		//============================================================================*
		// OnOKClicked()
		//============================================================================*

		private void OnOKClicked(object sender, EventArgs e)
			{
			m_Transaction.ApplyTax = m_Transaction.Tax == 0.0 ? false : true;

			if (m_Transaction.Supply.SupplyType == cSupply.eSupplyTypes.Powder)
				m_Transaction.Quantity = m_DataFiles.MetricToStandard(m_Transaction.Quantity, cDataFiles.eDataType.CanWeight) * 7000.0;

			m_DataFiles.Preferences.LastActivity = m_Transaction.TransactionType;

			switch (m_Transaction.TransactionType)
				{
				case cTransaction.eTransactionType.AddStock:
					m_DataFiles.Preferences.LastAddStockReason = SourceCombo.Text;
					break;

				case cTransaction.eTransactionType.Purchase:
					m_DataFiles.Preferences.LastPurchaseSource = SourceCombo.Text;
					break;

				case cTransaction.eTransactionType.ReduceStock:
					m_DataFiles.Preferences.LastReduceStockReason = SourceCombo.Text;
					break;

				case cTransaction.eTransactionType.Fired:
					m_DataFiles.Preferences.LastFiredLocation = SourceCombo.Text;
					break;

				case cTransaction.eTransactionType.SetStockLevel:
					m_Transaction.Date = new DateTime(m_Transaction.Date.Year, m_Transaction.Date.Month, m_Transaction.Date.Day, 0, 0, 0);
					break;
				}
			}

		//============================================================================*
		// OnQuantityChanged()
		//============================================================================*

		private void OnQuantityChanged(object sender, EventArgs e)
			{
			if (!m_fInitialized || m_fPopulating)
				return;

			double dQuantity = QuantityTextBox.Value;

			m_Transaction.Quantity = dQuantity;

			m_fChanged = true;

			if (m_Transaction.TransactionType == cTransaction.eTransactionType.ReduceStock || m_Transaction.TransactionType == cTransaction.eTransactionType.Fired)
				{
				double dCost = m_DataFiles.SupplyCostEach(m_Transaction.Supply);

				if (m_Transaction.Supply.SupplyType == cSupply.eSupplyTypes.Powder)
					dCost = m_DataFiles.StandardToMetric(dCost * 7000.0, cDataFiles.eDataType.CanWeight);

				m_Transaction.Cost = dCost * m_Transaction.Quantity;

				CostTextBox.Value = m_Transaction.Cost;
				TotalTextBox.Value = m_Transaction.Cost;
				}

			SetAvgCost();

			UpdateButtons();
			}

		//============================================================================*
		// OnShippingChanged()
		//============================================================================*

		private void OnShippingChanged(object sender, EventArgs e)
			{
			if (!m_fInitialized || m_fPopulating)
				return;

			m_Transaction.Shipping = ShippingTextBox.Value;

			TotalTextBox.Value = m_Transaction.Cost + m_Transaction.Tax + m_Transaction.Shipping;

			m_fChanged = true;

			SetAvgCost();

			UpdateButtons();
			}

		//============================================================================*
		// OnSourceChanged()
		//============================================================================*

		private void OnSourceChanged(object sender, EventArgs e)
			{
			if (!m_fInitialized || m_fPopulating)
				return;

			m_Transaction.Source = SourceCombo.Text;

			m_fChanged = true;

			UpdateButtons();
			}

		//============================================================================*
		// OnTaxChanged()
		//============================================================================*

		private void OnTaxChanged(object sender, EventArgs e)
			{
			if (!m_fInitialized || m_fPopulating)
				return;

			m_Transaction.Tax = TaxTextBox.Value;

			TotalTextBox.Value = m_Transaction.Cost + m_Transaction.Tax + m_Transaction.Shipping;

			m_fChanged = true;

			SetAvgCost();

			UpdateButtons();
			}

		//============================================================================*
		// OnTransactionTypeChanged()
		//============================================================================*

		private void OnTransactionTypeChanged(object sender, EventArgs e)
			{
			if (!m_fInitialized || m_fPopulating)
				return;

			if (m_Transaction.TransactionType == cTransaction.TransactionTypeFromString(TransactionTypeCombo.Text))
				return;

			m_Transaction.TransactionType = cTransaction.TransactionTypeFromString(TransactionTypeCombo.Text);

			if (m_Transaction.TransactionType == cTransaction.eTransactionType.SetStockLevel)
				m_Transaction.Date = new DateTime(2010, 1, 1, 0, 0, 0);
			else
				m_Transaction.Date = DateTime.Now;

			SetTransactionTypeControls();

			m_Transaction.Source = "";

			PopulateSourceCombo();

			m_fChanged = true;

			PopulateTransactionData();

			SetMinMax();
			}

		//============================================================================*
		// PopulateSourceCombo()
		//============================================================================*

		private void PopulateSourceCombo()
			{
			m_fPopulating = true;

			//----------------------------------------------------------------------------*
			// Clear the SourceCombo items
			//----------------------------------------------------------------------------*

			SourceCombo.Items.Clear();

			//----------------------------------------------------------------------------*
			// Get the source list info & populate the Source Combo
			//----------------------------------------------------------------------------*

			List<string> SourceList = m_DataFiles.GetTransactionSourceList(m_Transaction.TransactionType);
			string strLastSource = m_DataFiles.GetLastTransactionSource(m_Transaction.TransactionType);

			int nSelectIndex = -1;

			foreach (string strSource in SourceList)
				{
				int nIndex = SourceCombo.Items.Add(strSource);

				if (m_Transaction.Source == strLastSource)
					nSelectIndex = nIndex;
				}

			//----------------------------------------------------------------------------*
			// Set the selected item
			//----------------------------------------------------------------------------*

			if (nSelectIndex == -1 && !string.IsNullOrEmpty(m_Transaction.Source) && SourceCombo.FindString(m_Transaction.Source) == -1)
				nSelectIndex = SourceCombo.Items.Add(m_Transaction.Source);

			SourceCombo.SelectedIndex = nSelectIndex;

			if (SourceCombo.SelectedIndex == -1)
				SourceCombo.SelectedItem = strLastSource;

			m_Transaction.Source = SourceCombo.Text;

			m_fPopulating = false;
			}

		//============================================================================*
		// PopulateTransactionData()
		//============================================================================*

		private void PopulateTransactionData()
			{
			//----------------------------------------------------------------------------*
			// Fill in Transaction Data
			//----------------------------------------------------------------------------*

			ComponentLabel.Text = String.Format("{0} {1}", m_Transaction.Supply.ToString(), cSupply.SupplyTypeString(m_Transaction.Supply));

			TransactionTypeCombo.SelectedItem = cTransaction.TransactionTypeString(m_Transaction.TransactionType);

			if (TransactionTypeCombo.SelectedIndex == -1)
				TransactionTypeCombo.SelectedIndex = 0;

			SourceCombo.Text = m_Transaction.Source;

			if (m_Transaction.Date < DatePicker.MinDate)
				m_Transaction.Date = DatePicker.MinDate;

			DatePicker.Value = m_Transaction.Date;

			QuantityTextBox.Value = m_Transaction.Quantity;

			CostTextBox.Value = m_Transaction.Cost;
			TaxTextBox.Value = m_Transaction.Tax;
			ShippingTextBox.Value = m_Transaction.Shipping;
			TotalTextBox.Value = m_Transaction.Cost + m_Transaction.Tax + m_Transaction.Shipping;

			SetAvgCost();
			}

		//============================================================================*
		// PopulateTransactionTypeCombo()
		//============================================================================*

		private void PopulateTransactionTypeCombo()
			{
			m_fPopulating = true;

			TransactionTypeCombo.Items.Clear();

			if (!m_fAdd)
				{
				TransactionTypeCombo.Items.Add(cTransaction.TransactionTypeString(m_Transaction.TransactionType));

				TransactionTypeCombo.SelectedIndex = 0;
				}
			else
				{
				if (!m_fReload)
					TransactionTypeCombo.Items.Add(cTransaction.TransactionTypeString(cTransaction.eTransactionType.Purchase));

				bool fSetStockOK = !m_fReload;

				if (fSetStockOK)
					{
					foreach (cTransaction CheckTransaction in m_Transaction.Supply.TransactionList)
						{
						if (CheckTransaction.TransactionType == cTransaction.eTransactionType.SetStockLevel)
							{
							fSetStockOK = false;

							break;
							}
						}
					}

				if (fSetStockOK)
					TransactionTypeCombo.Items.Add(cTransaction.TransactionTypeString(cTransaction.eTransactionType.SetStockLevel));

				if (!m_fReload && m_Transaction.Supply.TransactionList.Count > 0)
					TransactionTypeCombo.Items.Add(cTransaction.TransactionTypeString(cTransaction.eTransactionType.AddStock));

				if (m_Transaction.Supply != null && m_Transaction.Supply.QuantityOnHand > 0.0)
					TransactionTypeCombo.Items.Add(cTransaction.TransactionTypeString(cTransaction.eTransactionType.ReduceStock));

				if (m_Transaction.Supply.SupplyType == cSupply.eSupplyTypes.Ammo && m_Transaction.Supply.QuantityOnHand > 0.0)
					TransactionTypeCombo.Items.Add(cTransaction.TransactionTypeString(cTransaction.eTransactionType.Fired));

				TransactionTypeCombo.SelectedItem = cTransaction.TransactionTypeString(m_Transaction.TransactionType);

				if (TransactionTypeCombo.SelectedIndex < 0)
					{
					TransactionTypeCombo.SelectedIndex = 0;

					m_Transaction.TransactionType = cTransaction.TransactionTypeFromString(TransactionTypeCombo.Text);
					}
				}

			m_fPopulating = false;
			}

		//============================================================================*
		// SetAvgCost()
		//============================================================================*

		private void SetAvgCost()
			{
			double dCost = m_Transaction.Cost;
			double dQuantity = m_Transaction.Quantity;

			if (m_DataFiles.Preferences.IncludeTaxShipping)
				dCost += (m_Transaction.Tax + m_Transaction.Shipping);

			double dAvgCost = 0.0;

			if (dCost != 0.0 && dQuantity != 0.0)
				dAvgCost = dCost / dQuantity;

			AvgCostLabel.Text = String.Format("{0}{1:F2}", m_DataFiles.Preferences.Currency, dAvgCost);
			}

		//============================================================================*
		// SetInputParameters()
		//============================================================================*

		private void SetInputParameters()
			{
			//----------------------------------------------------------------------------*
			// Powder Weight Label
			//----------------------------------------------------------------------------*

			if (m_Transaction.Supply.SupplyType != cSupply.eSupplyTypes.Powder)
				{
				PowderWeightLabel.Visible = false;
				}
			else
				{
				PowderWeightLabel.Visible = true;

				PowderWeightLabel.Text = m_DataFiles.MetricString(cDataFiles.eDataType.CanWeight);
				}

			CostsGroup.Text = String.Format("Costs ({0})", m_DataFiles.Preferences.Currency);

			//----------------------------------------------------------------------------*
			// Set Text Box Parameters
			//----------------------------------------------------------------------------*

			m_DataFiles.SetInputParameters(QuantityTextBox, cDataFiles.eDataType.Quantity, m_Transaction.Supply.SupplyType == cSupply.eSupplyTypes.Powder);

			m_DataFiles.SetInputParameters(CostTextBox, cDataFiles.eDataType.Cost);
			m_DataFiles.SetInputParameters(TaxTextBox, cDataFiles.eDataType.Cost);
			m_DataFiles.SetInputParameters(ShippingTextBox, cDataFiles.eDataType.Cost);
			m_DataFiles.SetInputParameters(TotalTextBox, cDataFiles.eDataType.Cost);
			}

		//============================================================================*
		// SetMinMax()
		//============================================================================*

		private void SetMinMax()
			{
			if (m_fViewOnly)
				{
				UpdateButtons();

				return;
				}

			//----------------------------------------------------------------------------*
			// Set Date Minimum
			//----------------------------------------------------------------------------*

			DateTime MinDate = new DateTime(2010, 1, 1, 0, 0, 0);

			if (DatePicker.Value < MinDate)
				{
				DatePicker.Value = MinDate;

				m_Transaction.Date = DatePicker.Value;
				}

			DatePicker.MinDate = MinDate;

			//----------------------------------------------------------------------------*
			// Set quantity minimums
			//----------------------------------------------------------------------------*

			QuantityTextBox.ReadOnly = false;
			QuantityTextBox.MinValue = 1.0;
			QuantityTextBox.MaxValue = 0.0;

			double dSupplyQty = m_Transaction.Supply.QuantityOnHand + m_dRefQuantity;

			if (m_Transaction.Supply.SupplyType == cSupply.eSupplyTypes.Powder)
				dSupplyQty = m_DataFiles.StandardToMetric(dSupplyQty / 7000.0, cDataFiles.eDataType.CanWeight);

			QuantityTextBox.MinValue = m_Transaction.Supply.SupplyType == cSupply.eSupplyTypes.Powder ? 0.01 : 1.0;

			switch (m_Transaction.TransactionType)
				{
				case cTransaction.eTransactionType.AddStock:
					QuantityTextBox.MaxValue = 0.0;

					break;

				case cTransaction.eTransactionType.ReduceStock:
				case cTransaction.eTransactionType.Fired:
					QuantityTextBox.MaxValue = dSupplyQty;

					break;

				case cTransaction.eTransactionType.Purchase:
					QuantityTextBox.MaxValue = 0.0;

					break;

				case cTransaction.eTransactionType.SetStockLevel:
					QuantityTextBox.MaxValue = 0.0;

					break;
				}

			StartDateLabel.Text = String.Format("({0} or later)", DatePicker.MinDate.ToShortDateString());

			UpdateButtons();
			}

		//============================================================================*
		// SetStaticToolTips()
		//============================================================================*

		private void SetStaticToolTips()
			{
			if (!m_DataFiles.Preferences.ToolTips)
				return;

			m_DateToolTip.ShowAlways = true;
			m_DateToolTip.RemoveAll();
			m_DateToolTip.SetToolTip(DatePicker, cm_strDateToolTip);

			m_TypeToolTip.ShowAlways = true;
			m_TypeToolTip.RemoveAll();
			m_TypeToolTip.SetToolTip(TransactionTypeCombo, cm_strTypeToolTip);

			m_SourceToolTip.ShowAlways = true;
			m_SourceToolTip.RemoveAll();

			switch (m_Transaction.TransactionType)
				{
				case cTransaction.eTransactionType.Purchase:
					m_SourceToolTip.SetToolTip(SourceCombo, cm_strPurchaseSourceToolTip);
					break;

				case cTransaction.eTransactionType.AddStock:
				case cTransaction.eTransactionType.ReduceStock:
					m_SourceToolTip.SetToolTip(SourceCombo, cm_strAdjustReasonToolTip);
					break;

				case cTransaction.eTransactionType.SetStockLevel:
					m_SourceToolTip.SetToolTip(SourceCombo, cm_strSourceToolTip);
					break;
				}

			QuantityTextBox.ToolTip = cm_strQuantityToolTip;
			CostTextBox.ToolTip = cm_strCostToolTip;
			TaxTextBox.ToolTip = cm_strTaxToolTip;
			ShippingTextBox.ToolTip = cm_strShippingToolTip;

			m_OKButtonToolTip.ShowAlways = true;
			m_OKButtonToolTip.RemoveAll();
			m_OKButtonToolTip.SetToolTip(TransactionOKButton, cm_strOKButtonToolTip);

			m_CancelButtonToolTip.ShowAlways = true;
			m_CancelButtonToolTip.RemoveAll();
			m_CancelButtonToolTip.SetToolTip(TransactionCancelButton, cm_strCancelButtonToolTip);
			}

		//============================================================================*
		// SetTransactionTypeControls()
		//============================================================================*

		private void SetTransactionTypeControls()
			{
			TransactionTypeCombo.Enabled = true;

			CostTextBox.ReadOnly = (m_Transaction.TransactionType == cTransaction.eTransactionType.ReduceStock || m_Transaction.TransactionType == cTransaction.eTransactionType.Fired ? true : false);

			switch (m_Transaction.TransactionType)
				{
				case cTransaction.eTransactionType.Purchase:
					SourceLabel.Text = "Location:";
					SourceLabel.Visible = true;
					SourceCombo.Visible = true;
					SourceCombo.Enabled = true;

					DateLabel.Visible = true;
					DatePicker.Visible = true;
					StartDateLabel.Visible = true;

					CostLabel.Text = "Cost:";

					TaxLabel.Text = "Tax:";
					TaxLabel.Visible = true;
					TaxTextBox.Visible = true;

					ShippingLabel.Text = "Shipping:";
					ShippingLabel.Visible = true;
					ShippingTextBox.Visible = true;
					ShippingTextBox.ReadOnly = false;

					AvgCostEachLabel.Visible = true;
					AvgCostLabel.Visible = true;

					break;

				case cTransaction.eTransactionType.SetStockLevel:
					SourceLabel.Visible = false;
					SourceCombo.Visible = false;
					SourceCombo.Enabled = false;

					DateLabel.Visible = false;
					DatePicker.Visible = false;
					StartDateLabel.Visible = false;

					CostLabel.Text = "Est. Cost:";

					TaxLabel.Text = "Est. Tax:";
					TaxLabel.Visible = true;
					TaxTextBox.Visible = true;

					ShippingLabel.Text = "Est. Shipping:";
					ShippingLabel.Visible = true;
					ShippingTextBox.Visible = true;
					ShippingTextBox.ReadOnly = false;

					AvgCostEachLabel.Visible = true;
					AvgCostLabel.Visible = true;

					break;

				case cTransaction.eTransactionType.AddStock:
				case cTransaction.eTransactionType.ReduceStock:
				case cTransaction.eTransactionType.Fired:
					SourceLabel.Text = (m_Transaction.TransactionType == cTransaction.eTransactionType.Fired) ? "Location:" : "Reason:";
					SourceLabel.Visible = true;
					SourceCombo.Visible = true;
					SourceCombo.Enabled = true;

					DateLabel.Visible = true;
					DatePicker.Visible = true;
					StartDateLabel.Visible = true;

					CostLabel.Text = (m_Transaction.TransactionType == cTransaction.eTransactionType.AddStock ? "Est. Cost:" : "Cost:");

					TaxLabel.Visible = false;
					TaxTextBox.Visible = false;
					m_Transaction.Tax = 0.0;

					ShippingLabel.Visible = false;
					ShippingTextBox.Visible = false;
					m_Transaction.Shipping = 0.0;

					AvgCostEachLabel.Visible = false;
					AvgCostLabel.Visible = false;

					break;
				}

			UpdateButtons();
			}

		//============================================================================*
		// Transaction Property
		//============================================================================*

		public cTransaction Transaction
			{
			get
				{
				return (m_Transaction);
				}
			}

		//============================================================================*
		// UpdateButtons()
		//============================================================================*

		private void UpdateButtons()
			{
			if (m_fViewOnly)
				return;

			bool fEnableOK = m_fChanged;

			//----------------------------------------------------------------------------*
			// Source
			//----------------------------------------------------------------------------*

			string strToolTip = cm_strSourceToolTip;

			switch (m_Transaction.TransactionType)
				{
				case cTransaction.eTransactionType.Purchase:
					strToolTip = cm_strPurchaseSourceToolTip;
					break;

				case cTransaction.eTransactionType.SetStockLevel:
					strToolTip = cm_strSourceToolTip;
					break;
				}

			SourceCombo.BackColor = SystemColors.Window;

			//			if (SourceCombo.Text.Length == 0)
			if (m_Transaction.Source != null && m_Transaction.Source.Length == 0)
				{
				if (m_Transaction.Supply != null && m_Transaction.TransactionType == cTransaction.eTransactionType.Purchase)
					{
					strToolTip += String.Format("\n\nYou must enter a seller (store name, gun show, etc) where you purchased th{0} {1}.", (m_Transaction.Supply.SupplyType == cSupply.eSupplyTypes.Powder ? "is" : "ese"), cSupply.SupplyTypeString(m_Transaction.Supply));

					fEnableOK = false;

					SourceCombo.BackColor = Color.LightPink;
					}
				else
					{
					if (m_Transaction.TransactionType == cTransaction.eTransactionType.AddStock ||
						m_Transaction.TransactionType == cTransaction.eTransactionType.ReduceStock)
						{
						strToolTip += "\n\nYou must enter a reason for the adjustment activity.";

						fEnableOK = false;

						SourceCombo.BackColor = Color.LightPink;
						}
					else
						{
						if (m_Transaction.TransactionType == cTransaction.eTransactionType.Fired)
							{
							strToolTip += "\n\nYou must enter a location where you fired this ammo.";

							fEnableOK = false;

							SourceCombo.BackColor = Color.LightPink;
							}
						else
							SourceCombo.BackColor = SystemColors.Window;
						}
					}
				}
			else
				SourceCombo.BackColor = SystemColors.Window;

			if (m_DataFiles.Preferences.ToolTips)
				m_SourceToolTip.SetToolTip(SourceCombo, strToolTip);

			//----------------------------------------------------------------------------*
			// Quantity
			//----------------------------------------------------------------------------*

			if (!QuantityTextBox.ValueOK)
				fEnableOK = false;

			//----------------------------------------------------------------------------*
			// Cost
			//----------------------------------------------------------------------------*

			if (!CostTextBox.ValueOK)
				fEnableOK = false;

			//----------------------------------------------------------------------------*
			// Tax
			//----------------------------------------------------------------------------*

			if (!TaxTextBox.ValueOK)
				fEnableOK = false;

			//----------------------------------------------------------------------------*
			// Shipping
			//----------------------------------------------------------------------------*

			if (!ShippingTextBox.ValueOK)
				fEnableOK = false;

			TotalTextBox.Text = String.Format("{0:F2}", CostTextBox.Value + TaxTextBox.Value + ShippingTextBox.Value);

			//----------------------------------------------------------------------------*
			// OK Button
			//----------------------------------------------------------------------------*

			TransactionOKButton.Enabled = fEnableOK;
			}
		}
	}
