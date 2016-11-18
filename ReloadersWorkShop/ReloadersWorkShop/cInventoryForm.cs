//============================================================================*
// cInventoryForm.cs
//
// Copyright © 2013-2014, Kevin S. Beebe
// All Rights Reserved
//============================================================================*

//============================================================================*
// .Net Using Statements
//============================================================================*

using System;
using System.Drawing;
using System.Windows;
using System.Windows.Forms;

using ReloadersWorkShop.Controls;
using ReloadersWorkShop.Preferences;

//============================================================================*
// NameSpace
//============================================================================*

namespace ReloadersWorkShop
	{
	//============================================================================*
	// cInventoryForm Class
	//============================================================================*

	public partial class cInventoryForm : Form
		{
		//----------------------------------------------------------------------------*
		// Private Constant Data Members
		//----------------------------------------------------------------------------*

		//----------------------------------------------------------------------------*
		// Private Data Members
		//----------------------------------------------------------------------------*

		private cSupply m_Supply = null;
		private cDataFiles m_DataFiles = null;

		private bool m_fInitialized = false;

		private bool m_fChanged = false;
		private bool m_fViewOnly = false;
		private bool m_fReload = false;

		private cTransactionListView m_TransactionListView = null;

		//============================================================================*
		// cInventoryForm() - Constructor
		//============================================================================*

		public cInventoryForm(cSupply Supply, cDataFiles Datafiles, bool fViewOnly = false, bool fReload = false)
			{
			InitializeComponent();

			m_Supply = Supply;
			m_DataFiles = Datafiles;
			m_fViewOnly = fViewOnly;

			m_fReload = fReload;

			//----------------------------------------------------------------------------*
			// Create the Transaction List View
			//----------------------------------------------------------------------------*

			m_TransactionListView = new cTransactionListView(m_Supply.TransactionList, m_DataFiles);

			m_TransactionListView.Location = new Point(6, 20);
			m_TransactionListView.Size = new Size(TotalsGroupBox.Width - 12, AddActivityButton.Location.Y - 26);
			m_TransactionListView.TabIndex = 0;

			ActivityGroupBox.Controls.Add(m_TransactionListView);

			SetClientSizeCore(TotalsGroupBox.Location.X + TotalsGroupBox.Width + 10, CloseButton.Location.Y + CloseButton.Height + 20);

			//----------------------------------------------------------------------------*
			// Set Control Event Handlers
			//----------------------------------------------------------------------------*

			if (!m_fViewOnly)
				{
				m_TransactionListView.SelectedIndexChanged += OnActivitySelected;

				MinimumStockLevelTextBox.TextChanged += OnMinimumStockLevelChanged;

				AddActivityButton.Click += OnAddActivityClicked;
				EditActivityButton.Click += OnEditActivityClicked;
				RemoveActivityButton.Click += OnRemoveActivityClicked;

				CloseButton.Click += OnCloseButtonClicked;
				}
			else
				{
				AddActivityButton.Visible = false;
				EditActivityButton.Visible = false;
				RemoveActivityButton.Visible = false;
				}

			ShowBatchCheckBox.Click += OnShowBatchClicked;

			//----------------------------------------------------------------------------*
			// Set Dialog Title
			//----------------------------------------------------------------------------*

			if (m_fViewOnly)
				Text = "View " + Text;
			else
				Text = "Edit " + Text;

			//----------------------------------------------------------------------------*
			// Populate All Inventory Data
			//----------------------------------------------------------------------------*

			ShowBatchCheckBox.Checked = m_DataFiles.Preferences.ShowBatchTransactions;

			SetStaticToolTips();

			PopulateInventoryData();

			m_TransactionListView.Populate();

			m_fInitialized = true;

			UpdateButtons();
			}

		//============================================================================*
		// Changed Property
		//============================================================================*

		public bool Changed
			{
			get { return (m_fChanged); }
			}

		//============================================================================*
		// OnActivitySelected()
		//============================================================================*

		private void OnActivitySelected(object sender, EventArgs e)
			{
			UpdateButtons();
			}

		//============================================================================*
		// OnAddActivityClicked()
		//============================================================================*

		private void OnAddActivityClicked(object sender, EventArgs e)
			{
			cTransactionForm TransactionForm = new cTransactionForm(m_Supply, m_DataFiles);

			DialogResult rc = TransactionForm.ShowDialog();

			if (rc != DialogResult.OK)
				return;

			m_fChanged = true;

			m_Supply.TransactionList.Add(TransactionForm.Transaction);

			m_Supply.TransactionList.Sort();

			m_TransactionListView.AddTransaction(TransactionForm.Transaction, true);

			m_Supply.RecalculateInventory(m_DataFiles);

			m_DataFiles.Preferences.LastTransaction = TransactionForm.Transaction;
			m_DataFiles.Preferences.LastTransactionSelected = TransactionForm.Transaction;

			PopulateInventoryData();

			UpdateButtons();
			}

		//============================================================================*
		// OnCloseButtonClicked()
		//============================================================================*

		private void OnCloseButtonClicked(object sender, EventArgs e)
			{
			if (m_Supply.SupplyType == cSupply.eSupplyTypes.Powder)
				m_Supply.MinimumStockLevel = cDataFiles.MetricToStandard(MinimumStockLevelTextBox.Value, cDataFiles.eDataType.CanWeight) * 7000.0;
			else
				m_Supply.MinimumStockLevel = MinimumStockLevelTextBox.Value;
			}

		//============================================================================*
		// OnEditActivityClicked()
		//============================================================================*

		private void OnEditActivityClicked(object sender, EventArgs e)
			{
			cTransaction Transaction = m_TransactionListView.SelectedItems[0].Tag as cTransaction;

			cTransactionForm TransactionForm = new cTransactionForm(Transaction, m_DataFiles);

			DialogResult rc = TransactionForm.ShowDialog();

			if (rc != DialogResult.OK)
				return;

			m_fChanged = true;

			m_Supply.TransactionList.Remove(Transaction);

			m_Supply.TransactionList.Add(TransactionForm.Transaction);

			m_Supply.TransactionList.Sort();

			m_TransactionListView.Populate();

			m_Supply.RecalculateInventory(m_DataFiles);

			m_DataFiles.Preferences.LastTransaction = TransactionForm.Transaction;
			m_DataFiles.Preferences.LastTransactionSelected = TransactionForm.Transaction;

			PopulateInventoryData();

			UpdateButtons();
			}

		//============================================================================*
		// OnMinimumStockLevelChanged()
		//============================================================================*

		private void OnMinimumStockLevelChanged(object sender, EventArgs e)
			{
			if (!m_fInitialized)
				return;

			m_Supply.MinimumStockLevel = MinimumStockLevelTextBox.Value;

			m_fChanged = true;

			UpdateButtons();
			}

		//============================================================================*
		// OnRemoveActivityClicked()
		//============================================================================*

		private void OnRemoveActivityClicked(object sender, EventArgs e)
			{
			cTransaction Transaction = m_TransactionListView.SelectedItems[0].Tag as cTransaction;

			DialogResult rc = MessageBox.Show("Are you sure you wish to remove this activity from the list?", "Data Deletion Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

			if (rc != DialogResult.Yes)
				return;

			m_fChanged = true;

			m_Supply.TransactionList.Remove(Transaction);

			m_Supply.TransactionList.Sort();

			m_DataFiles.Preferences.LastTransactionSelected = null;

			m_TransactionListView.Populate();

			m_Supply.RecalculateInventory(m_DataFiles);

			PopulateInventoryData();

			UpdateButtons();
			}

		//============================================================================*
		// OnShowBatchClicked()
		//============================================================================*

		private void OnShowBatchClicked(object sender, EventArgs e)
			{
			ShowBatchCheckBox.Checked = !ShowBatchCheckBox.Checked;

			m_DataFiles.Preferences.ShowBatchTransactions = ShowBatchCheckBox.Checked;

			m_TransactionListView.Populate();

			UpdateButtons();
			}

		//============================================================================*
		// PopulateInventoryData()
		//============================================================================*

		private void PopulateInventoryData()
			{
			ComponentLabel.Text = String.Format("{0} {1}", m_Supply.ToString(), cSupply.SupplyTypeString(m_Supply));

			double dQuantityOnHand = m_Supply.QuantityOnHand;
			double dValue = m_DataFiles.SupplyCost(m_Supply);
			double dCostEach = m_DataFiles.SupplyCostEach(m_Supply);
			double dLastPurchaseQty = m_Supply.LastPurchaseQty;
			double dTotalPurchaseQty = m_Supply.TotalPurchaseQty;
			double dTotalAdjustQty = m_Supply.TotalAdjustQty;
			double dTotalUsedQty = m_Supply.TotalUsedQty;

			if (m_Supply.SupplyType == cSupply.eSupplyTypes.Powder)
				{
				dQuantityOnHand = cDataFiles.StandardToMetric(m_Supply.QuantityOnHand / 7000.0, cDataFiles.eDataType.CanWeight);
				dCostEach = cDataFiles.StandardToMetric(m_DataFiles.SupplyCostEach(m_Supply) * 7000.0, cDataFiles.eDataType.CanWeight);
				dLastPurchaseQty = cDataFiles.StandardToMetric(m_Supply.LastPurchaseQty / 7000.0, cDataFiles.eDataType.CanWeight);
				dTotalPurchaseQty = cDataFiles.StandardToMetric(m_Supply.TotalPurchaseQty / 7000.0, cDataFiles.eDataType.CanWeight);
				dTotalAdjustQty = cDataFiles.StandardToMetric(m_Supply.TotalAdjustQty / 7000.0, cDataFiles.eDataType.CanWeight);
				dTotalUsedQty = cDataFiles.StandardToMetric(m_Supply.TotalUsedQty / 7000.0, cDataFiles.eDataType.CanWeight);

				string strQtyformat = "{0:F3} {1}{2}";

				QuantityLabel.Text = String.Format(strQtyformat, dQuantityOnHand, (cPreferences.MetricCanWeights ? "kilo" : "lb"), (dQuantityOnHand != 1.0 ? "s" : ""));
				LastPurchaseQtyLabel.Text = String.Format(strQtyformat, dLastPurchaseQty, (cPreferences.MetricCanWeights ? "kilo" : "lb"), (dLastPurchaseQty != 1.0 ? "s" : ""));
				TotalPurchasedLabel.Text = String.Format(strQtyformat, dTotalPurchaseQty, (cPreferences.MetricCanWeights ? "kilo" : "lb"), (dTotalPurchaseQty != 1.0 ? "s" : ""));

				TotalAdjustLabel.Text = String.Format(strQtyformat, dTotalAdjustQty, (cPreferences.MetricCanWeights ? "kilo" : "lb"), (dTotalAdjustQty != 1.0 ? "s" : ""));
				TotalUsedLabel.Text = String.Format(strQtyformat, dTotalUsedQty, (cPreferences.MetricCanWeights ? "kilo" : "lb"), (dTotalUsedQty != 1.0 ? "s" : ""));
				}
			else
				{
				string strQtyformat = "{0:G0}";

				QuantityLabel.Text = String.Format(strQtyformat, dQuantityOnHand);
				LastPurchaseQtyLabel.Text = String.Format(strQtyformat, dLastPurchaseQty);
				TotalPurchasedLabel.Text = String.Format(strQtyformat, dTotalPurchaseQty);

				TotalAdjustLabel.Text = String.Format(strQtyformat, dTotalAdjustQty);
				TotalUsedLabel.Text = String.Format(strQtyformat, dTotalUsedQty);
				}

			ValueLabel.Text = String.Format("{0}{1:F2} *", m_DataFiles.Preferences.Currency, dValue);
			CostEachLabel.Text = String.Format("{0}{1:F2} *", m_DataFiles.Preferences.Currency, dCostEach);

			LastPurchaseDateLabel.Text = (m_Supply.LastPurchaseDate.Year > 2009 ? m_Supply.LastPurchaseDate.ToShortDateString() : "N/A");
			LastPurchaseCostLabel.Text = String.Format("{0}{1:F2}", m_DataFiles.Preferences.Currency, m_Supply.LastPurchaseCost);

			TotalCostLabel.Text = String.Format("{0}{1:F2}", m_DataFiles.Preferences.Currency, m_Supply.TotalPurchaseCost);

			if (m_Supply.SupplyType == cSupply.eSupplyTypes.Powder)
				{
				MinimumStockLevelTextBox.Value = cDataFiles.StandardToMetric(m_Supply.MinimumStockLevel, cDataFiles.eDataType.CanWeight) / (cPreferences.MetricCanWeights ? 1000.0 :  7000.0);
				MinimumStockLevelMeasurementLabel.Visible = true;
				cDataFiles.SetMetricLabel(MinimumStockLevelMeasurementLabel, cDataFiles.eDataType.CanWeight);
				}
			else
				{
				MinimumStockLevelTextBox.Value = m_Supply.MinimumStockLevel;
				MinimumStockLevelMeasurementLabel.Visible = false;
				}

			MinimumStockLevelTextBox.NumDecimals = m_Supply.SupplyType == cSupply.eSupplyTypes.Powder ? 3 : 0;

			if (m_DataFiles.Preferences.AverageCosts)
				MethodLabel.Text = "* - Values based on avg of all purchases";
			else
				MethodLabel.Text = "* - Values based on last purchase only";

			if (m_DataFiles.Preferences.IncludeTaxShipping)
				MethodLabel.Text += " including tax && shipping";
			}

		//============================================================================*
		// SetCosts()
		//============================================================================*

		private void SetCosts()
			{
			CostEachLabel.Text = String.Format("{0}{1:F2}", m_DataFiles.Preferences.Currency, m_DataFiles.SupplyCostEach(m_Supply));
			}

		//============================================================================*
		// SetPurchaseHistory()
		//============================================================================*

		private void SetPurchaseHistory()
			{
			string strQtyFormat = (m_Supply.SupplyType == cSupply.eSupplyTypes.Powder) ? "{0:F3)" : "{0:G0}";

			double dTotalPurchaseQty = m_Supply.TotalPurchaseQty;
			double dTotalAdjustQty = m_Supply.TotalAdjustQty;
			double dTotalUsedQty = m_Supply.TotalUsedQty;
			double dLastPurchaseQty = m_Supply.LastPurchaseQty;

			if (m_Supply.SupplyType == cSupply.eSupplyTypes.Powder)
				{
				dLastPurchaseQty = cDataFiles.StandardToMetric(dLastPurchaseQty / 7000.0, cDataFiles.eDataType.CanWeight);

				dTotalPurchaseQty = cDataFiles.StandardToMetric(dTotalPurchaseQty /  7000.0, cDataFiles.eDataType.CanWeight);

				dTotalAdjustQty = cDataFiles.StandardToMetric(dTotalAdjustQty / 7000.0, cDataFiles.eDataType.CanWeight);
				dTotalUsedQty = cDataFiles.StandardToMetric(dTotalUsedQty / 7000.0, cDataFiles.eDataType.CanWeight);
				}

			TotalPurchasedLabel.Text = String.Format(strQtyFormat, dTotalPurchaseQty);
			TotalCostLabel.Text = String.Format("{0}{1:F2}", m_DataFiles.Preferences.Currency, m_Supply.TotalPurchaseCost);

			TotalAdjustLabel.Text = String.Format(strQtyFormat, dTotalAdjustQty);
			TotalUsedLabel.Text = String.Format(strQtyFormat, dTotalUsedQty);

			LastPurchaseQtyLabel.Text = String.Format("{0:F0}", dLastPurchaseQty);
			LastPurchaseCostLabel.Text = String.Format("{0}{1:F2}", m_DataFiles.Preferences.Currency, m_Supply.LastPurchaseCost);
			}

		//============================================================================*
		// SetStaticToolTips()
		//============================================================================*

		private void SetStaticToolTips()
			{
			}

		//============================================================================*
		// Supply Property
		//============================================================================*

		public cSupply Supply
			{
			get { return (m_Supply); }
			}

		//============================================================================*
		// UpdateButtons()
		//============================================================================*

		private void UpdateButtons()
			{
			if (m_fViewOnly)
				return;

			cTransaction Transaction = null;

			if (m_TransactionListView.SelectedItems.Count > 0)
				Transaction = (cTransaction)m_TransactionListView.SelectedItems[0].Tag;

			if (Transaction == null)
				{
				EditActivityButton.Enabled = false;
				RemoveActivityButton.Enabled = false;
				}
			else
				{
				EditActivityButton.Enabled = (m_TransactionListView.SelectedItems.Count > 0 && Transaction.BatchID == 0);
				RemoveActivityButton.Enabled = (m_TransactionListView.SelectedItems.Count > 0 && Transaction.BatchID == 0);
				}
			}
		}
	}
