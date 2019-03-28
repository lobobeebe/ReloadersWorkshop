//============================================================================*
// cTransactionListView.cs
//
// Copyright © 2013-2017, Kevin S. Beebe
// All Rights Reserved
//============================================================================*

//============================================================================*
// .Net Using Statements
//============================================================================*

using System;
using System.Windows.Forms;

using ReloadersWorkShop.Preferences;

//============================================================================*
// NameSpace
//============================================================================*

namespace ReloadersWorkShop
	{
	//============================================================================*
	// cTransactionListView Class
	//============================================================================*

	public class cTransactionListView : cListView
		{
		//============================================================================*
		// Private Data Members
		//============================================================================*

		cTransactionList m_TransactionList = null;
		cDataFiles m_DataFiles = null;
		cSupply m_Supply = null;

		private cListViewColumn[] m_arColumns = new cListViewColumn[]
			{
			new cListViewColumn(0, "DateHeader", "Date", HorizontalAlignment.Left, 150),
			new cListViewColumn(1, "TypeHeader", "Type", HorizontalAlignment.Left, 100),
			new cListViewColumn(2, "SourceHeader", "Location/Reason", HorizontalAlignment.Left, 100),
			new cListViewColumn(3, "QuantityHeader", "Quantity", HorizontalAlignment.Center, 80),
			new cListViewColumn(4, "CostHeader", "Cost", HorizontalAlignment.Right, 80),
			new cListViewColumn(5, "TaxHeader", "Tax", HorizontalAlignment.Right, 80),
			new cListViewColumn(6, "ShippingHeader", "Shipping", HorizontalAlignment.Right, 80),
			new cListViewColumn(7, "TotalHeader", "Total", HorizontalAlignment.Right, 80),
			new cListViewColumn(8, "CostEachHeader", "Cost Each", HorizontalAlignment.Right, 80)
			};

		//============================================================================*
		// cTransactionListView() - Constructor
		//============================================================================*

		public cTransactionListView(cTransactionList TransactionList, cDataFiles DataFiles, cSupply Supply = null)
			: base(DataFiles, cPreferences.eApplicationListView.TransactionsListView)
			{
			m_TransactionList = TransactionList;
			m_DataFiles = DataFiles;
			m_Supply = Supply;

			//----------------------------------------------------------------------------*
			// Set Properties
			//----------------------------------------------------------------------------*

			DoubleBuffered = true;
			CheckBoxes = true;

			Font = new System.Drawing.Font(Font, System.Drawing.FontStyle.Bold);

			//----------------------------------------------------------------------------*
			// Event Handlers
			//----------------------------------------------------------------------------*

			ListViewItemSorter = new cListViewTransactionComparer(m_DataFiles.Preferences.TransactionSortColumn, m_DataFiles.Preferences.TransactionSortOrder);

			//----------------------------------------------------------------------------*
			// Populate Columns and Groups
			//----------------------------------------------------------------------------*

			SortingOrder = m_DataFiles.Preferences.TransactionSortOrder;

			SortingColumn = m_DataFiles.Preferences.TransactionSortColumn;

			if (m_Supply != null && m_Supply.SupplyType == cSupply.eSupplyTypes.Powder)
				m_arColumns[3].Text += String.Format(" ({0}s)", cDataFiles.MetricString(cDataFiles.eDataType.CanWeight));

			m_arColumns[4].Text += String.Format(" ({0})", m_DataFiles.Preferences.Currency);
			m_arColumns[5].Text += String.Format(" ({0})", m_DataFiles.Preferences.Currency);
			m_arColumns[6].Text += String.Format(" ({0})", m_DataFiles.Preferences.Currency);
			m_arColumns[7].Text += String.Format(" ({0})", m_DataFiles.Preferences.Currency);
			m_arColumns[8].Text += String.Format(" ({0})", m_DataFiles.Preferences.Currency);

			PopulateColumns(m_arColumns);

			//----------------------------------------------------------------------------*
			// Populate Data
			//----------------------------------------------------------------------------*

			Populate();

			Initialized = true;
			}

		//============================================================================*
		// AddTransaction()
		//============================================================================*

		public ListViewItem AddTransaction(cTransaction Transaction, bool fSelect = false)
			{
			if (!Verify(Transaction))
				return (null);

			//----------------------------------------------------------------------------*
			// Create and Add the Item
			//----------------------------------------------------------------------------*

			ListViewItem Item = new ListViewItem();

			SetTransactionData(Item, Transaction);

			AddItem(Item, fSelect);

			if (Transaction.CompareTo(m_DataFiles.Preferences.LastTransactionSelected) == 0)
				Item.Selected = true;

			return (Item);
			}

		//============================================================================*
		// OnColumnClick()
		//============================================================================*

		protected override void OnColumnClick(ColumnClickEventArgs args)
			{
			if (args.Column == SortingColumn)
				{
				SortingOrder = (SortingOrder == SortOrder.Ascending) ? SortOrder.Descending : SortOrder.Ascending;

				m_DataFiles.Preferences.TransactionSortOrder = SortingOrder;

				ListViewItemSorter = new cListViewTransactionComparer(SortingColumn, SortingOrder);
				}
			else
				{
				SortingColumn = args.Column;

				m_DataFiles.Preferences.TransactionSortColumn = args.Column;

				ListViewItemSorter = new cListViewTransactionComparer(SortingColumn, SortingOrder);

				this.Invalidate(true);
				}

			if (SelectedItems.Count > 0)
				SelectedItems[0].EnsureVisible();
			}

		//============================================================================*
		// Populate()
		//============================================================================*

		public override void Populate()
			{
			Populating = true;

			Items.Clear();

			foreach (cTransaction Transaction in m_TransactionList)
				AddTransaction(Transaction);

			if (Items.Count > 0 && SelectedItems.Count == 0)
				{
				Items[0].Selected = true;

				EnsureVisible(Items[0].Index);
				}

			Focus();

			Populating = false;
			}

		//============================================================================*
		// SetTransactionData()
		//============================================================================*

		public void SetTransactionData(ListViewItem Item, cTransaction Transaction)
			{
			Item.SubItems.Clear();

			if (Transaction.TransactionType == cTransaction.eTransactionType.SetStockLevel)
				Item.Text = "";
			else
				Item.Text = Transaction.Date.ToShortDateString();

			if (Transaction.Archived)
				Item.Text += " - Archived";

			Item.Checked = Transaction.Checked;

			Item.Tag = Transaction;

			if (Transaction.TransactionType == cTransaction.eTransactionType.SetStockLevel)
				Transaction.Source = "";

			if (Transaction.BatchID != 0)
				Transaction.Source = String.Format("Batch {0:G0}", Transaction.BatchID);

			Item.SubItems.Add(cTransaction.TransactionDescriptionString(Transaction.TransactionType));
			Item.SubItems.Add(Transaction.Source);

			double dQuantity = Transaction.Quantity;

			switch (Transaction.Supply.SupplyType)
				{
				case cSupply.eSupplyTypes.Ammo:
				case cSupply.eSupplyTypes.Bullets:
				case cSupply.eSupplyTypes.Cases:
				case cSupply.eSupplyTypes.Primers:
					Item.SubItems.Add(String.Format("{0:N0}", dQuantity));
					break;

				case cSupply.eSupplyTypes.Powder:
					dQuantity = cDataFiles.StandardToMetric(dQuantity / 7000.0, cDataFiles.eDataType.CanWeight);

					Item.SubItems.Add(String.Format("{0:F3}", dQuantity));

					break;
				}

			double dCostEach = m_DataFiles.SupplyCostEach(Transaction.Supply);

			double dCost = 0.0;

			if (Transaction.BatchID != 0)
				{
				if (Transaction.Supply.SupplyType == cSupply.eSupplyTypes.Ammo)
					dCost = m_DataFiles.BatchCost(Transaction.BatchID);
				else
					dCost = Transaction.Quantity * dCostEach;
				}
			else
				{
				dCost = Transaction.Cost;
				}

			Item.SubItems.Add(String.Format("{0:F2}", dCost));

			if (Transaction.BatchID == 0 &&
				(Transaction.TransactionType == cTransaction.eTransactionType.Purchase ||
				Transaction.TransactionType == cTransaction.eTransactionType.SetStockLevel))
				{
				Item.SubItems.Add(Transaction.Tax != 0.0 ? String.Format("{0:F2}", Transaction.Tax) : "-");
				Item.SubItems.Add(Transaction.Shipping != 0.0 ? String.Format("{0:F2}", Transaction.Shipping) : "-");
				}
			else
				{
				Item.SubItems.Add("-");
				Item.SubItems.Add("-");
				}

			Item.SubItems.Add(String.Format("{0:F2}", dCost + Transaction.Tax + Transaction.Shipping));

			if (Transaction.TransactionType == cTransaction.eTransactionType.Purchase ||
				Transaction.TransactionType == cTransaction.eTransactionType.SetStockLevel)
				{
				if (m_DataFiles.Preferences.IncludeTaxShipping)
					dCost += (Transaction.Tax + Transaction.Shipping);

				dCostEach = 0.0;

				if (dQuantity > 0.0)
					dCostEach = dCost / dQuantity;

				Item.SubItems.Add(String.Format("{0:F2}", dCostEach));
				}
			else
				Item.SubItems.Add("-");
			}

		//============================================================================*
		// UpdateTransaction()
		//============================================================================*

		public ListViewItem UpdateTransaction(cTransaction Transaction, bool fSelect = false)
			{
			//----------------------------------------------------------------------------*
			// Find the Item
			//----------------------------------------------------------------------------*

			ListViewItem Item = null;

			foreach (ListViewItem CheckItem in Items)
				{
				if ((CheckItem.Tag as cTransaction).CompareTo(Transaction) == 0)
					{
					Item = CheckItem;

					break;
					}
				}

			//----------------------------------------------------------------------------*
			// If the item was not found, add it
			//----------------------------------------------------------------------------*

			if (Item == null)
				return (AddTransaction(Transaction, fSelect));

			//----------------------------------------------------------------------------*
			// Otherwise, update the Item Data
			//----------------------------------------------------------------------------*

			SetTransactionData(Item, Transaction);

			Item.Selected = fSelect;

			Focus();

			return (Item);
			}

		//============================================================================*
		// Verify()
		//============================================================================*

		public bool Verify(cTransaction Transaction)
			{
			if (!m_DataFiles.Preferences.ShowBatchTransactions && Transaction.BatchID != 0)
				return (false);

			return (true);
			}
		}
	}
