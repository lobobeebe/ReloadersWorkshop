//============================================================================*
// cCaseForm.cs
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
	// cCaseForm Class
	//============================================================================*

	public partial class cCaseForm : Form
		{
		//----------------------------------------------------------------------------*
		// Private Const Data Members
		//----------------------------------------------------------------------------*

		private const string cm_strFirearmTypeToolTip = "Type of Firearm for which this case is used.";
		private const string cm_strManufacturerToolTip = "Manufacturer of this case.";
		private const string cm_strPartNumberToolTip = "Manufacturer's part number for this case.";
		private const string cm_strCaliberToolTip = "Caliber for which this case is used.";

		private const string cm_strQuantityToolTip = "Quantity that can be bought for the price specified.";
		private const string cm_strPriceToolTip = "Price for the specified quantity of this case.";

		private const string cm_strCaseOKButtonToolTip = "Click to add or update the case with the above data.";
		private const string cm_strCaseCancelButtonToolTip = "Click to cancel changes and return to the main window.";

		//----------------------------------------------------------------------------*
		// Private Data Members
		//----------------------------------------------------------------------------*

		private bool m_fInitialized = false;

		private bool m_fAdd = false;
		private bool m_fChanged = false;

		private cCase m_Case = null;
		private cCase m_OriginalCase = null;

		private cDataFiles m_DataFiles;

		private Bitmap m_CaseBitmap = null;

		private bool m_fViewOnly = false;

		private ToolTip m_FirearmTypeToolTip = new ToolTip();
		private ToolTip m_ManufacturerToolTip = new ToolTip();
		private ToolTip m_PartNumberToolTip = new ToolTip();
		private ToolTip m_CaliberToolTip = new ToolTip();
		private ToolTip m_QuantityToolTip = new ToolTip();
		private ToolTip m_PriceToolTip = new ToolTip();

		private ToolTip m_CaseOKButtonToolTip = new ToolTip();
		private ToolTip m_CaseCancelButtonToolTip = new ToolTip();

		//============================================================================*
		// cCaseForm() - Constructor
		//============================================================================*

		public cCaseForm(cCase Case, cDataFiles DataFiles, bool fViewOnly = false)
			{
			InitializeComponent();

			m_DataFiles = DataFiles;
			m_fViewOnly = fViewOnly;

			if (Case == null)
				{
				if (m_fViewOnly)
					return;

				m_fAdd = true;

				if (m_DataFiles.Preferences.LastCase == null)
					m_Case = new cCase();
				else
					m_Case = new cCase(m_DataFiles.Preferences.LastCase);

				m_Case.Military = false;

				m_Case.PartNumber = "";
				m_Case.Quantity = 0.0;
				m_Case.QuantityOnHand = 0.0;
				m_Case.Cost = 0.0;

				m_Case.TotalAdjustQty = 0.0;
				m_Case.TotalPurchaseCost = 0.0;
				m_Case.TotalPurchaseQty = 0.0;
				m_Case.TotalUsedQty = 0.0;

				m_Case.TransactionList.Clear();
				m_Case.RecalculateInventory(m_DataFiles);

				CaseOKButton.Text = "Add";
				}
			else
				{
				m_Case = new cCase(Case);

				m_OriginalCase = new cCase(m_Case);

				if (m_fViewOnly)
					{
					CaseOKButton.Visible = false;

					int nButtonX = (this.Size.Width / 2) - (CaseCancelButton.Width / 2);

					CaseCancelButton.Location = new Point(nButtonX, CaseCancelButton.Location.Y);

					CaseCancelButton.Text = "Close";
					}
				else
					CaseOKButton.Text = "Update";
				}

			SetClientSizeCore(GeneralGroupBox.Location.X + GeneralGroupBox.Width + 10, CaseCancelButton.Location.Y + CaseCancelButton.Height + 20);

			//----------------------------------------------------------------------------*
			// Set Control Event Handlers
			//----------------------------------------------------------------------------*

			if (!m_fViewOnly)
				{
				FirearmTypeCombo.SelectedIndexChanged += OnFirearmTypeSelectedChanged;
				ManufacturerCombo.SelectedIndexChanged += OnManufacturerSelectedChanged;
				PartNumberTextBox.TextChanged += OnPartNumberChanged;
				CaliberCombo.SelectedIndexChanged += OnCaliberChanged;
				SmallPrimerRadioButton.Click += OnSmallPrimerClicked;
				LargePrimerRadioButton.Click += OnLargePrimerClicked;
				MatchCheckBox.Click += OnMatchClicked;
				MilitaryCheckBox.Click += OnMilitaryClicked;

				QuantityTextBox.TextChanged += OnQuantityChanged;
				CostTextBox.TextChanged += OnPriceChanged;
				}
			else
				{
				QuantityTextBox.ReadOnly = true;

				CostTextBox.ReadOnly = true;
				}

			InventoryButton.Click += OnInventoryClicked;

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
			// Populate Combo Boxes
			//----------------------------------------------------------------------------*

			FirearmTypeCombo.Value = m_Case.FirearmType;

			PopulateCaliberCombo();

			if (!m_fViewOnly)
				cControls.PopulateManufacturerCombo(ManufacturerCombo, m_DataFiles, m_Case.Manufacturer, cFirearm.eFireArmType.None, (int) cSupply.eSupplyTypes.Cases);
			else
				{
				ManufacturerCombo.Items.Add(m_Case.Manufacturer);

				ManufacturerCombo.SelectedIndex = 0;
				}

			if (m_Case.Manufacturer == null)
				m_Case.Manufacturer = (cManufacturer) ManufacturerCombo.SelectedItem;

			//----------------------------------------------------------------------------*
			// Fill in Case data
			//----------------------------------------------------------------------------*

			PartNumberTextBox.Text = m_Case.PartNumber;
			MatchCheckBox.Checked = m_Case.Match;
			MilitaryCheckBox.Checked = m_Case.Military;

			HeadStampLabel.Text = m_Case.HeadStamp;

			if (!m_Case.LargePrimer && !m_Case.SmallPrimer)
				{
				if (m_Case.Caliber != null)
					{
					if (m_Case.Caliber.LargePrimer && m_Case.Caliber.SmallPrimer)
						m_Case.LargePrimer = true;
					else
						{
						m_Case.LargePrimer = m_Case.Caliber.LargePrimer;
						m_Case.SmallPrimer = m_Case.Caliber.SmallPrimer;
						}
					}
				}

			SmallPrimerRadioButton.Checked = m_Case.SmallPrimer;
			LargePrimerRadioButton.Checked = m_Case.LargePrimer;

			SetCaseImage();

			PopulateInventoryData();

			//----------------------------------------------------------------------------*
			// Set title and text fields
			//----------------------------------------------------------------------------*

			string strTitle;

			if (m_fAdd)
				strTitle = "Add";
			else
				{
				if (m_fViewOnly)
					strTitle = "View";
				else
					strTitle = "Edit";
				}

			strTitle += " Case";

			Text = strTitle;

			SetStaticToolTips();

			UpdateButtons();

			if (!m_fViewOnly)
				FirearmTypeCombo.Focus();
			else
				CaseCancelButton.Focus();

			m_fInitialized = true;
			}

		//============================================================================*
		// Case Property
		//============================================================================*

		public cCase Case
			{
			get
				{
				return (m_Case);
				}
			}

		//============================================================================*
		// OnCaliberChanged()
		//============================================================================*

		private void OnCaliberChanged(object sender, EventArgs e)
			{
			if (!m_fInitialized)
				return;

			if (CaliberCombo.SelectedIndex >= 0)
				{
				cCaliber Caliber = (cCaliber) CaliberCombo.SelectedItem;

				if (m_Case.Caliber == null || m_Case.Caliber.CompareTo(Caliber) != 0)
					{
					m_Case.Caliber = Caliber;

					HeadStampLabel.Text = m_Case.HeadStamp;

					SetCaseImage();

					m_fChanged = true;
					}
				}

			UpdateButtons();
			}

		//============================================================================*
		// OnFirearmTypeSelectedChanged()
		//============================================================================*

		private void OnFirearmTypeSelectedChanged(object sender, EventArgs e)
			{
			if (!m_fInitialized)
				return;

			if (FirearmTypeCombo.SelectedIndex != (int) m_Case.FirearmType)
				{
				PopulateCaliberCombo();

				m_Case.FirearmType = FirearmTypeCombo.Value;

				m_Case.Caliber = (cCaliber) CaliberCombo.SelectedItem;

				m_fChanged = true;

				HeadStampLabel.Text = m_Case.HeadStamp;
				}

			UpdateButtons();
			}

		//============================================================================*
		// OnInventoryClicked()
		//============================================================================*

		private void OnInventoryClicked(object sender, EventArgs e)
			{
			cInventoryForm InventoryForm = new cInventoryForm(m_Case, m_DataFiles, m_fViewOnly);

			InventoryForm.ShowDialog();

			if (!m_fChanged)
				m_fChanged = InventoryForm.Changed;

			PopulateInventoryData();

			UpdateButtons();
			}

		//============================================================================*
		// OnLargePrimerClicked()
		//============================================================================*

		private void OnLargePrimerClicked(object sender, EventArgs e)
			{
			if (!m_fInitialized)
				return;

			LargePrimerRadioButton.Checked = !LargePrimerRadioButton.Checked;
			SmallPrimerRadioButton.Checked = !LargePrimerRadioButton.Checked;

			m_Case.LargePrimer = LargePrimerRadioButton.Checked;
			m_Case.SmallPrimer = SmallPrimerRadioButton.Checked;

			m_fChanged = true;

			UpdateButtons();
			}

		//============================================================================*
		// OnManufacturerSelectedChanged()
		//============================================================================*

		private void OnManufacturerSelectedChanged(object sender, EventArgs e)
			{
			if (!m_fInitialized)
				return;

			if (ManufacturerCombo.SelectedIndex >= 0)
				{
				m_Case.Manufacturer = (cManufacturer) ManufacturerCombo.SelectedItem;

				m_fChanged = true;

				HeadStampLabel.Text = m_Case.HeadStamp;
				}

			UpdateButtons();
			}

		//============================================================================*
		// OnMatchClicked()
		//============================================================================*

		private void OnMatchClicked(object sender, EventArgs e)
			{
			if (!m_fInitialized)
				return;

			MatchCheckBox.Checked = !MatchCheckBox.Checked;

			m_Case.Match = MatchCheckBox.Checked;

			m_fChanged = true;

			HeadStampLabel.Text = m_Case.HeadStamp;

			UpdateButtons();
			}

		//============================================================================*
		// OnMilitaryClicked()
		//============================================================================*

		private void OnMilitaryClicked(object sender, EventArgs e)
			{
			if (!m_fInitialized)
				return;

			MilitaryCheckBox.Checked = !MilitaryCheckBox.Checked;

			m_Case.Military = MilitaryCheckBox.Checked;

			m_fChanged = true;

			UpdateButtons();
			}

		//============================================================================*
		// OnOKClicked()
		//============================================================================*

		private void OnOKClicked(Object sender, EventArgs e)
			{
			if (m_Case.Manufacturer == null)
				m_Case.Manufacturer = (cManufacturer) ManufacturerCombo.SelectedItem;

			if (m_Case.Caliber == null)
				m_Case.Caliber = (cCaliber) CaliberCombo.SelectedItem;
			}

		//============================================================================*
		// OnPartNumberChanged()
		//============================================================================*

		private void OnPartNumberChanged(object sender, EventArgs e)
			{
			if (!m_fInitialized)
				return;

			m_Case.PartNumber = PartNumberTextBox.Text;

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

			m_Case.Cost = CostTextBox.Value;

			SetCostEach();

			m_fChanged = true;

			UpdateButtons();
			}

		//============================================================================*
		// OnQuantityChanged()
		//============================================================================*

		private void OnQuantityChanged(object sender, EventArgs e)
			{
			if (!m_fInitialized)
				return;

			m_Case.Quantity = QuantityTextBox.Value;

			SetCostEach();

			m_fChanged = true;

			UpdateButtons();
			}

		//============================================================================*
		// OnSmallPrimerClicked()
		//============================================================================*

		private void OnSmallPrimerClicked(object sender, EventArgs e)
			{
			if (!m_fInitialized)
				return;

			SmallPrimerRadioButton.Checked = !SmallPrimerRadioButton.Checked;
			LargePrimerRadioButton.Checked = !SmallPrimerRadioButton.Checked;

			m_Case.LargePrimer = LargePrimerRadioButton.Checked;
			m_Case.SmallPrimer = SmallPrimerRadioButton.Checked;

			m_fChanged = true;

			UpdateButtons();
			}

		//============================================================================*
		// PopulateCaliberCombo()
		//============================================================================*

		private void PopulateCaliberCombo()
			{
			if (!m_fViewOnly)
				{
				cControls.PopulateCaliberCombo(CaliberCombo, m_DataFiles, m_fAdd ? null : m_Case, FirearmTypeCombo.Value);

				if (m_DataFiles.Preferences.HideUncheckedCalibers)
					CaliberScopeLabel.Text = "(Only selected calibers listed)";
				else
					CaliberScopeLabel.Text = "(All calibers listed)";
				}
			else
				{
				CaliberCombo.Items.Clear();

				CaliberCombo.Items.Add(m_Case.Caliber);

				CaliberCombo.SelectedIndex = 0;

				CaliberScopeLabel.Text = "";
				}

			if (CaliberCombo.Items.Count > 0)
				{
				if (m_fAdd || m_Case.Caliber == null)
					m_Case.Caliber = (cCaliber) CaliberCombo.SelectedItem;
				}
			else
				m_Case.Caliber = null;
			}

		//============================================================================*
		// PopulateInventoryData()
		//============================================================================*

		private void PopulateInventoryData()
			{
			QuantityTextBox.Value = (int) m_DataFiles.SupplyQuantity(m_Case);

			CostTextBox.Value = m_DataFiles.SupplyCost(m_Case);

			if (m_DataFiles.Preferences.TrackInventory)
				CostTextBox.Text = String.Format("{0}{1:F2}", m_DataFiles.Preferences.Currency, m_DataFiles.SupplyCost(m_Case));

			SetCostEach();
			}

		//============================================================================*
		// SetCaseImage()
		//============================================================================*

		private void SetCaseImage()
			{
			if (CaliberCombo.Text.Length > 0)
				{
				try
					{
					string strFileName = String.Format(@"Images\{0} Case.jpg", CaliberCombo.Text);

					m_CaseBitmap = new Bitmap(strFileName);

					m_CaseBitmap.MakeTransparent(Color.White);
					}
				catch
					{
					m_CaseBitmap = null;
					}
				}
			else
				m_CaseBitmap = null;

			CaseImage.Image = m_CaseBitmap;
			}

		//============================================================================*
		// SetCostEach()
		//============================================================================*

		private void SetCostEach()
			{
			CostEachLabel.Text = String.Format("{0}{1:F2}", m_DataFiles.Preferences.Currency, m_DataFiles.SupplyCostEach(m_Case));
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

			m_PartNumberToolTip.ShowAlways = true;
			m_PartNumberToolTip.RemoveAll();
			m_PartNumberToolTip.SetToolTip(PartNumberTextBox, cm_strPartNumberToolTip);

			m_CaliberToolTip.ShowAlways = true;
			m_CaliberToolTip.RemoveAll();
			m_CaliberToolTip.SetToolTip(CaliberCombo, cm_strCaliberToolTip);

			m_QuantityToolTip.ShowAlways = true;
			m_QuantityToolTip.RemoveAll();
			m_QuantityToolTip.SetToolTip(QuantityTextBox, cm_strQuantityToolTip);

			m_PriceToolTip.ShowAlways = true;
			m_PriceToolTip.RemoveAll();
			m_PriceToolTip.SetToolTip(CostTextBox, cm_strPriceToolTip);

			m_CaseOKButtonToolTip.ShowAlways = true;
			m_CaseOKButtonToolTip.RemoveAll();
			m_CaseOKButtonToolTip.SetToolTip(CaseOKButton, cm_strCaseOKButtonToolTip);

			m_CaseCancelButtonToolTip.ShowAlways = true;
			m_CaseCancelButtonToolTip.RemoveAll();
			m_CaseCancelButtonToolTip.SetToolTip(CaseCancelButton, cm_strCaseCancelButtonToolTip);
			}

		//============================================================================*
		// UpdateButtons()
		//============================================================================*

		private void UpdateButtons()
			{
			bool fEnableOK = m_fChanged;

			if (m_fViewOnly)
				{
				DuplicateCaseLabel.Visible = false;

				return;
				}

			//----------------------------------------------------------------------------*
			// Check for duplicate
			//----------------------------------------------------------------------------*

			bool fOK = true;

			foreach (cCase Case in m_DataFiles.CaseList)
				{
				if ((m_OriginalCase == null || Case.CompareTo(m_OriginalCase) != 0) &&
					Case.CompareTo(m_Case) == 0)
					{
					fEnableOK = false;
					fOK = false;

					break;
					}
				}

			DuplicateCaseLabel.Visible = !fOK;

			//----------------------------------------------------------------------------*
			// Check Caliber
			//----------------------------------------------------------------------------*

			if (CaliberCombo.SelectedIndex < 0)
				fEnableOK = false;
			else
				{
				if (Case.Caliber == null)
					{
					cCaliber Caliber = (cCaliber) CaliberCombo.SelectedItem;

					if (Caliber != null)
						Case.Caliber = Caliber;
					}
				}

			//----------------------------------------------------------------------------*
			// Check Primer Size
			//----------------------------------------------------------------------------*

			if (!LargePrimerRadioButton.Checked && !SmallPrimerRadioButton.Checked)
				{
				fEnableOK = false;

				LargePrimerRadioButton.BackColor = Color.LightPink;
				SmallPrimerRadioButton.BackColor = Color.LightPink;
				}
			else
				{
				LargePrimerRadioButton.BackColor = SystemColors.Control;
				SmallPrimerRadioButton.BackColor = SystemColors.Control;
				}

			if (Case.Caliber != null)
				{
				if (Case.Caliber.LargePrimer && Case.Caliber.SmallPrimer)
					{
					if (!Case.LargePrimer && !Case.SmallPrimer)
						Case.LargePrimer = true;

					LargePrimerRadioButton.Enabled = true;
					SmallPrimerRadioButton.Enabled = true;
					}
				else
					{
					Case.LargePrimer = Case.Caliber.LargePrimer;
					Case.SmallPrimer = Case.Caliber.SmallPrimer;

					LargePrimerRadioButton.Enabled = false;
					SmallPrimerRadioButton.Enabled = false;
					}
				}

			//----------------------------------------------------------------------------*
			// Get Values
			//----------------------------------------------------------------------------*

			int nQuantity = QuantityTextBox.Value;

			double dPrice = CostTextBox.Value;

			//----------------------------------------------------------------------------*
			// Check Quantity
			//----------------------------------------------------------------------------*

			string strToolTip = cm_strQuantityToolTip;

			if (nQuantity < 0)
				{
				fEnableOK = false;

				strToolTip += "\n\nValue must be greater than or equal to zero (0).";

				QuantityTextBox.BackColor = Color.LightPink;
				}
			else
				{
				if (nQuantity == 0 && dPrice > 0.0)
					{
					fEnableOK = false;

					strToolTip += "\n\nSince the price is not zero (0.00), quantity must be greater than zero (0).";

					QuantityTextBox.BackColor = Color.LightPink;
					}
				else
					QuantityTextBox.BackColor = SystemColors.Window;
				}

			if (m_DataFiles.Preferences.ToolTips)
				m_QuantityToolTip.SetToolTip(QuantityTextBox, strToolTip);

			//----------------------------------------------------------------------------*
			// Check Price
			//----------------------------------------------------------------------------*

			strToolTip = cm_strPriceToolTip;

			if (dPrice < 0.0)
				{
				fEnableOK = false;

				strToolTip += "\n\nValue must be greater than or equal to zero (0.00).";

				CostTextBox.BackColor = Color.LightPink;
				}
			else
				{
				CostTextBox.BackColor = SystemColors.Window;
				}

			if (m_DataFiles.Preferences.ToolTips)
				m_PriceToolTip.SetToolTip(CostTextBox, strToolTip);

			//----------------------------------------------------------------------------*
			// Set Buttons
			//----------------------------------------------------------------------------*

			CaseOKButton.Enabled = fEnableOK;
			}
		}
	}
