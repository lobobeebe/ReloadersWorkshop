//============================================================================*
// cBulletForm.cs
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

using ReloadersWorkShop.Preferences;

//============================================================================*
// NameSpace
//============================================================================*

namespace ReloadersWorkShop
    {
    //============================================================================*
    // cBulletForm Class
    //============================================================================*

    public partial class cBulletForm : Form
        {
        //----------------------------------------------------------------------------*
        // Private Constant Data Members
        //----------------------------------------------------------------------------*

        private const string cm_strFirearmTypeToolTip = "Type of firearm for which this bullet is used.";
        private const string cm_strManufacturerToolTip = "Manufacturer of this bullet.";
        private const string cm_strBulletWeightToolTip = "Bullet weight.";
        private const string cm_strPartNumberToolTip = "Manufacturer's part or mold number.";
        private const string cm_strSelfCastToolTip = "Indicates whether you cast this bullet yourself.";
        private const string cm_strTopPunchToolTip = "The top punch you use for sizing and lubing this cast bullet.";
        private const string cm_strBulletTypeToolTip = "Short description of the bullet.";
        private const string cm_strBulletDiameterToolTip = "Bullet diameter.";
        private const string cm_strBulletLengthToolTip = "Bullet length.";
        private const string cm_strBallisticCoefficientToolTip = "Ballistic Coefficient for this bullet.";
        private const string cm_strCaliberListToolTip = "List of cartridges for which this bullet is appropriate.";
        private const string cm_strQuantityAndPriceToolTip = "Optional quantity and price figures are used to calculate the cost per cartridge loaded.";
        private const string cm_strBulletOKButtonToolTip = "Click to add or update the bullet with the above data.";
        private const string cm_strBulletCancelButtonToolTip = "Click to cancel changes and return to the main window.";

        private const string cm_strAddCaliberButtonToolTip = "Click to add a cartridge for which this bullet would be appropriate.";
        private const string cm_strEditCaliberButtonToolTip = "Click to edit the selected cartridge.";
        private const string cm_strRemoveCaliberButtonToolTip = "Click to remove the selected cartridge.";

        //----------------------------------------------------------------------------*
        // Private Data Members
        //----------------------------------------------------------------------------*

        private bool m_fChanged = false;
        private bool m_fViewOnly = false;
        private bool m_fAdd = false;

        private string m_strOriginalPartNumber = "";
        private double m_dOriginalQuantityOnHand = 0.0;
        private double m_dOriginalCost = 0.0;

        private cBullet m_Bullet;

        private Bitmap m_BulletBitmap = null;

        private cDataFiles m_DataFiles;

        private bool m_fInitialized = false;

        private cBulletCaliberListView m_BulletCalibersListView = null;

        private ToolTip m_FirearmTypeToolTip = new ToolTip();
        private ToolTip m_ManufacturerToolTip = new ToolTip();
        private ToolTip m_BulletWeightToolTip = new ToolTip();
        private ToolTip m_PartNumberToolTip = new ToolTip();
        private ToolTip m_SelfCastToolTip = new ToolTip();
        private ToolTip m_TopPunchToolTip = new ToolTip();
        private ToolTip m_BulletTypeToolTip = new ToolTip();
        private ToolTip m_BulletDiameterToolTip = new ToolTip();
        private ToolTip m_BulletLengthToolTip = new ToolTip();
        private ToolTip m_BallisticCoefficientToolTip = new ToolTip();
        private ToolTip m_CaliberListToolTip = new ToolTip();
        private ToolTip m_QuantityAndPriceToolTip = new ToolTip();
        private ToolTip m_BulletOKButtonToolTip = new ToolTip();
        private ToolTip m_BulletCancelButtonToolTip = new ToolTip();

        private ToolTip m_AddCaliberToolTip = new ToolTip();
        private ToolTip m_EditCaliberToolTip = new ToolTip();
        private ToolTip m_RemoveCaliberToolTip = new ToolTip();

        //============================================================================*
        // cBulletForm() - Constructor
        //============================================================================*

        public cBulletForm(cBullet Bullet, cDataFiles Datafiles, bool fViewOnly = false)
            {
            InitializeComponent();

            m_DataFiles = Datafiles;
            m_fViewOnly = fViewOnly;

            //----------------------------------------------------------------------------*
            // Create the Bullet Calibers List View
            //----------------------------------------------------------------------------*

            m_BulletCalibersListView = new cBulletCaliberListView(m_DataFiles);

            m_BulletCalibersListView.Location = new Point(6, 20);

            if (!m_fViewOnly)
                m_BulletCalibersListView.Size = new Size(CaliberDataGroupBox.Width - 12, AddCaliberButton.Location.Y - m_BulletCalibersListView.Location.Y - 6);
            else
                m_BulletCalibersListView.Size = new Size(CaliberDataGroupBox.Width - 12, CaliberDataGroupBox.Height - m_BulletCalibersListView.Location.Y - 6);

            m_BulletCalibersListView.TabIndex = 0;

            CaliberDataGroupBox.Controls.Add(m_BulletCalibersListView);

            //----------------------------------------------------------------------------*
            // Create the m_Bullet object
            //----------------------------------------------------------------------------*

            if (Bullet == null)
                {
                if (fViewOnly)
                    return;

                m_fAdd = true;

                BulletOKButton.Text = "Add";

                if (m_DataFiles.Preferences.LastBullet == null)
                    m_Bullet = new cBullet();
                else
                    {
                    m_Bullet = new cBullet(m_DataFiles.Preferences.LastBullet);

                    m_Bullet.PartNumber = "";
                    m_Bullet.Type = "";
                    m_Bullet.BallisticCoefficient = 0.0;

                    m_Bullet.ResetAllInventoryData();

                    m_Bullet.BulletCaliberList.Clear();
                    }
                }
            else
                {
                m_Bullet = new cBullet(Bullet);

                if (fViewOnly)
                    {
                    BulletOKButton.Visible = false;

                    int nButtonX = (this.Size.Width / 2) - (BulletCancelButton.Width / 2);

                    BulletCancelButton.Location = new Point(nButtonX, BulletCancelButton.Location.Y);

                    BulletCancelButton.Text = "Close";
                    }
                else
                    BulletOKButton.Text = "Update";
                }

			cCaliber.CurrentFirearmType = m_Bullet.FirearmType;

            SetClientSizeCore(GeneralGroupBox.Location.X + GeneralGroupBox.Width + 10, BulletCancelButton.Location.Y + BulletCancelButton.Height + 20);

            //----------------------------------------------------------------------------*
            // Record Original Data
            //----------------------------------------------------------------------------*

            m_strOriginalPartNumber = m_Bullet.PartNumber;
            m_dOriginalCost = m_Bullet.Cost;
            m_dOriginalQuantityOnHand = m_Bullet.QuantityOnHand;

            //----------------------------------------------------------------------------*
            // Set Control Event Handlers
            //----------------------------------------------------------------------------*

            if (!fViewOnly)
                {
                FirearmTypeCombo.SelectedIndexChanged += OnFirearmTypeSelected;
				CrossUseCheckBox.Click += OnCrossUseClicked;
				ManufacturerCombo.SelectedIndexChanged += OnManufacturerSelected;

                SelfCastRadioButton.Click += OnSelfCastClicked;

                PartNumberTextBox.TextChanged += OnPartNumberTextChanged;
                TopPunchTextBox.TextChanged += OnTopPunchTextChanged;
                TypeTextBox.TextChanged += OnTypeTextChanged;
                BallisticCoefficientTextBox.TextChanged += OnBallisticCoefficientChanged;
                BulletDiameterTextBox.TextChanged += OnDiameterChanged;
                LengthTextBox.TextChanged += OnLengthChanged;
                BulletWeightTextBox.TextChanged += OnWeightTextChanged;
                QuantityTextBox.TextChanged += OnQuantityTextChanged;
                CostTextBox.TextChanged += OnPriceChanged;

                TypeWizardButton.Click += OnTypeWizardButtonClicked;

                m_BulletCalibersListView.SelectedIndexChanged += OnCaliberSelected;

                AddCaliberButton.Click += OnAddCaliber;
                EditCaliberButton.Click += OnEditCaliber;
                RemoveCaliberButton.Click += OnRemoveCaliber;

                BulletOKButton.Click += OnOKClicked;
                }
            else
                {
                PartNumberTextBox.ReadOnly = true;
                TopPunchTextBox.ReadOnly = true;
                TypeTextBox.ReadOnly = true;
                BallisticCoefficientTextBox.ReadOnly = true;
                BulletDiameterTextBox.ReadOnly = true;
                LengthTextBox.ReadOnly = true;
                BulletWeightTextBox.ReadOnly = true;
                QuantityTextBox.ReadOnly = true;
                CostTextBox.ReadOnly = true;
                TypeWizardButton.Enabled = false;

                AddCaliberButton.Visible = false;
                EditCaliberButton.Visible = false;
                RemoveCaliberButton.Visible = false;
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
            // Populate All Bullet Data
            //----------------------------------------------------------------------------*

            SetInputParameters();

            PopulateComboBoxes();

            PopulateBulletData();

            SetBulletMinMax();
            SetBulletImage();

            SetStaticToolTips();

            SetCastBulletFields();

            m_BulletCalibersListView.Populate(m_Bullet);

            //----------------------------------------------------------------------------*
            // Set title and text fields
            //----------------------------------------------------------------------------*

            string strTitle;

            if (Bullet == null)
                {
                strTitle = "Add";

                m_fChanged = true;
                }
            else
                {
                if (fViewOnly)
                    strTitle = "View";
                else
                    strTitle = "Edit";
                }

            strTitle += " Bullet";

            Text = strTitle;

            if (!fViewOnly)
                UpdateButtons();

            m_fInitialized = true;

            if (!fViewOnly)
                FirearmTypeCombo.Focus();
            else
                BulletCancelButton.Focus();
            }

        //============================================================================*
        // AddCaliber()
        //============================================================================*

        private void AddCaliber(cBulletCaliber BulletCaliber)
            {
            //----------------------------------------------------------------------------*
            // If the Caliber already exists, update the existing one and exit
            //----------------------------------------------------------------------------*

            foreach (cBulletCaliber CheckBulletCaliber in m_Bullet.BulletCaliberList)
                {
                if (CheckBulletCaliber.CompareTo(BulletCaliber) == 0)
                    {
                    UpdateBulletCaliber(CheckBulletCaliber, BulletCaliber);

                    m_fChanged = true;

                    return;
                    }
                }

            //----------------------------------------------------------------------------*
            // Add the new caliber to the list
            //----------------------------------------------------------------------------*

            m_Bullet.BulletCaliberList.Add(BulletCaliber);

            SetBulletMinMax();

            //----------------------------------------------------------------------------*
            // Add the new Caliber to the Caliber tab
            //----------------------------------------------------------------------------*

            m_fChanged = true;

            m_BulletCalibersListView.AddBulletCaliber(BulletCaliber, true);
            }

        //============================================================================*
        // Bullet Property
        //============================================================================*

        public cBullet Bullet
            {
            get
                {
                return (m_Bullet);
                }
            }

        //============================================================================*
        // OnAddCaliber()
        //============================================================================*

        private void OnAddCaliber(object sender, EventArgs e)
            {
            if (m_Bullet.Manufacturer == null)
                m_Bullet.Manufacturer = (cManufacturer) ManufacturerCombo.SelectedItem;

            //----------------------------------------------------------------------------*
            // Start the dialog
            //----------------------------------------------------------------------------*

            m_Bullet.FirearmType = (cFirearm.eFireArmType) FirearmTypeCombo.SelectedIndex;

            m_Bullet.Weight = cDataFiles.MetricToStandard(BulletWeightTextBox.Value, cDataFiles.eDataType.BulletWeight);
            m_Bullet.Diameter = cDataFiles.MetricToStandard(BulletDiameterTextBox.Value, cDataFiles.eDataType.Dimension);

            cBulletCaliberForm BulletCaliberForm = new cBulletCaliberForm(null, m_Bullet, m_DataFiles);

            if (BulletCaliberForm.ShowDialog() == DialogResult.OK)
                {
                //----------------------------------------------------------------------------*
                // Get the new Caliber Data
                //----------------------------------------------------------------------------*

                cBulletCaliber NewBulletCaliber = BulletCaliberForm.BulletCaliber;

                m_fChanged = true;

                AddCaliber(NewBulletCaliber);

                UpdateButtons();
                }
            }

        //============================================================================*
        // OnBallisticCoefficientChanged()
        //============================================================================*

        private void OnBallisticCoefficientChanged(object sender, EventArgs e)
            {
            if (!m_fInitialized)
                return;

            m_Bullet.BallisticCoefficient = BallisticCoefficientTextBox.Value;

            m_fChanged = true;

            UpdateButtons();
            }

        //============================================================================*
        // OnBulletCalibersListViewColumnWidthChanged()
        //============================================================================*

        protected void OnBulletCalibersListViewColumnWidthChanged(object sender, ColumnWidthChangedEventArgs args)
            {
            cControls.OnColumnWidthChanged(sender, args, m_DataFiles, cPreferences.eApplicationListView.BulletCalibersListView);
            }

        //============================================================================*
        // OnCaliberSelected()
        //============================================================================*

        private void OnCaliberSelected(object sender, EventArgs e)
            {
            if (!m_fInitialized)
                return;

            SetSectionalDensity();

            UpdateButtons();
            }

		//============================================================================*
		// OnCrossUseClicked()
		//============================================================================*

		private void OnCrossUseClicked(object sender, EventArgs e)
			{
			m_Bullet.CrossUse = CrossUseCheckBox.Checked;

			m_fChanged = true;

			UpdateButtons();
			}

		//============================================================================*
		// OnDiameterChanged()
		//============================================================================*

		private void OnDiameterChanged(object sender, EventArgs e)
            {
            if (!m_fInitialized)
                return;

            m_Bullet.Diameter = cDataFiles.MetricToStandard(BulletDiameterTextBox.Value, cDataFiles.eDataType.Dimension);

            m_fChanged = true;

            SetSectionalDensity();

            UpdateButtons();
            }

        //============================================================================*
        // OnEditCaliber()
        //============================================================================*

        private void OnEditCaliber(object sender, EventArgs e)
            {
            //----------------------------------------------------------------------------*
            // Start the dialog
            //----------------------------------------------------------------------------*

            cBulletCaliber OldBulletCaliber = (cBulletCaliber) m_BulletCalibersListView.SelectedItems[0].Tag;

            cBulletCaliberForm BulletCaliberForm = new cBulletCaliberForm(OldBulletCaliber, m_Bullet, m_DataFiles);

            if (BulletCaliberForm.ShowDialog(this) == DialogResult.OK)
                {
                //----------------------------------------------------------------------------*
                // Get the new Caliber Data
                //----------------------------------------------------------------------------*

                cBulletCaliber NewBulletCaliber = BulletCaliberForm.BulletCaliber;

                //----------------------------------------------------------------------------*
                // Update the caliber
                //----------------------------------------------------------------------------*

                UpdateBulletCaliber(OldBulletCaliber, NewBulletCaliber);

                m_fChanged = true;

                UpdateButtons();

                BulletOKButton.Focus();
                }
            }

        //============================================================================*
        // OnFirearmTypeSelected()
        //============================================================================*

        private void OnFirearmTypeSelected(object sender, EventArgs e)
            {
            if (!m_fInitialized)
                return;

            if (m_Bullet.FirearmType != FirearmTypeCombo.Value)
                {
                m_Bullet.FirearmType = FirearmTypeCombo.Value;

				cCaliber.CurrentFirearmType = m_Bullet.FirearmType;

                m_Bullet.Diameter = 0.0;
                m_Bullet.Weight = 0.0;
                m_Bullet.BallisticCoefficient = 0.0;
                m_Bullet.Length = 0.0;

                PopulateBulletData();

                SetBulletMinMax();

                m_fChanged = true;

                SetBulletImage();

                UpdateButtons();
                }
            }

        //============================================================================*
        // OnInventoryClicked()
        //============================================================================*

        private void OnInventoryClicked(object sender, EventArgs e)
            {
            cInventoryForm InventoryForm = new cInventoryForm(m_Bullet, m_DataFiles, m_fViewOnly);

            InventoryForm.ShowDialog();

            if (!m_fChanged)
                m_fChanged = InventoryForm.Changed;

            PopulateInventoryData();

            UpdateButtons();
            }

        //============================================================================*
        // OnLengthChanged()
        //============================================================================*

        private void OnLengthChanged(object sender, EventArgs e)
            {
            if (!m_fInitialized)
                return;

            m_Bullet.Length = cDataFiles.MetricToStandard(LengthTextBox.Value, cDataFiles.eDataType.Dimension);

            m_fChanged = true;

            UpdateButtons();
            }

        //============================================================================*
        // OnManufacturerSelected()
        //============================================================================*

        private void OnManufacturerSelected(object sender, EventArgs e)
            {
            if (!m_fInitialized)
                return;

            m_fChanged = true;

            m_Bullet.Manufacturer = (cManufacturer) ManufacturerCombo.SelectedItem;

            SetCastBulletFields();

            SetBulletImage();

            UpdateButtons();
            }

        //============================================================================*
        // OnOKClicked()
        //============================================================================*

        private void OnOKClicked(object sender, EventArgs e)
            {
            }

        //============================================================================*
        // OnPartNumberTextChanged()
        //============================================================================*

        private void OnPartNumberTextChanged(object sender, EventArgs e)
            {
            if (!m_fInitialized)
                return;

            m_Bullet.PartNumber = PartNumberTextBox.Value;

            m_fChanged = true;

            SetBulletImage();

            UpdateButtons();
            }

        //============================================================================*
        // OnPriceChanged()
        //============================================================================*

        private void OnPriceChanged(object sender, EventArgs e)
            {
            if (!m_fInitialized)
                return;

            m_Bullet.Cost = CostTextBox.Value;

            m_fChanged = true;

            SetCostEach();

            UpdateButtons();
            }

        //============================================================================*
        // OnQuantityTextChanged()
        //============================================================================*

        private void OnQuantityTextChanged(object sender, EventArgs e)
            {
            if (!m_fInitialized)
                return;

            m_Bullet.Quantity = QuantityTextBox.Value;

            m_fChanged = true;

            SetCostEach();

            UpdateButtons();
            }

        //============================================================================*
        // OnRemoveCaliber()
        //============================================================================*

        private void OnRemoveCaliber(object sender, EventArgs e)
            {
            //----------------------------------------------------------------------------*
            // Warn user of impending doom
            //----------------------------------------------------------------------------*

            if (MessageBox.Show(this, "Warning, removing a caliber from a bullet's caliber list will result in all loads with this bullet/caliber combination being deleted as well.\n\nAre you SURE you wish to delete this caliber?", "Data Deletion Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                cBulletCaliber Caliber = (cBulletCaliber) m_BulletCalibersListView.SelectedItems[0].Tag;

                m_BulletCalibersListView.Items.Remove(m_BulletCalibersListView.SelectedItems[0]);

                m_Bullet.BulletCaliberList.Remove(Caliber);

                m_fChanged = true;

                UpdateButtons();
                }
            }

        //============================================================================*
        // OnSelfCastClicked()
        //============================================================================*

        private void OnSelfCastClicked(object sender, EventArgs e)
            {
            if (!m_fInitialized)
                return;

            SelfCastRadioButton.Checked = !SelfCastRadioButton.Checked;

            SetCastBulletFields();

            if (SelfCastRadioButton.Checked)
                TopPunchTextBox.Focus();

            m_Bullet.SelfCast = SelfCastRadioButton.Checked;

            if (!m_Bullet.SelfCast)
                m_Bullet.TopPunch = 0;

            m_fChanged = true;

            UpdateButtons();
            }

        //============================================================================*
        // OnTopPunchTextChanged()
        //============================================================================*

        private void OnTopPunchTextChanged(object sender, EventArgs e)
            {
            if (!m_fInitialized)
                return;

            m_Bullet.TopPunch = TopPunchTextBox.Value;

            m_fChanged = true;

            UpdateButtons();
            }

        //============================================================================*
        // OnTypeTextChanged()
        //============================================================================*

        private void OnTypeTextChanged(object sender, EventArgs e)
            {
            if (!m_fInitialized)
                return;

            m_Bullet.Type = TypeTextBox.Value;

            m_fChanged = true;

            UpdateButtons();
            }

        //============================================================================*
        // OnTypeWizardButtonClicked()
        //============================================================================*

        private void OnTypeWizardButtonClicked(object sender, EventArgs e)
            {
            cBulletTypeForm BulletTypeForm = new cBulletTypeForm(TypeTextBox.Value, m_DataFiles);

            if (BulletTypeForm.ShowDialog() == DialogResult.OK)
                {
                if (BulletTypeForm.ResultString != TypeTextBox.Value)
                    {
                    TypeTextBox.Value = BulletTypeForm.ResultString;

                    m_Bullet.Type = BulletTypeForm.ResultString;

                    m_fChanged = true;

                    UpdateButtons();
                    }
                }
            }

        //============================================================================*
        // OnWeightTextChanged()
        //============================================================================*

        private void OnWeightTextChanged(object sender, EventArgs e)
            {
            if (!m_fInitialized)
                return;

            m_Bullet.Weight = cDataFiles.MetricToStandard(BulletWeightTextBox.Value, cDataFiles.eDataType.BulletWeight);

            SetSectionalDensity();

            m_fChanged = true;

            UpdateButtons();
            }

        //============================================================================*
        // PopulateBulletData()
        //============================================================================*

        private void PopulateBulletData()
            {
            //----------------------------------------------------------------------------*
            // Combo Boxes
            //----------------------------------------------------------------------------*

            PopulateComboBoxes();

			//----------------------------------------------------------------------------*
			// Data Text Boxes
			//----------------------------------------------------------------------------*

			CrossUseCheckBox.Checked = m_Bullet.CrossUse;

			PartNumberTextBox.Value = m_Bullet.PartNumber;
            TypeTextBox.Value = m_Bullet.Type;
            BulletDiameterTextBox.Value = cDataFiles.StandardToMetric(m_Bullet.Diameter, cDataFiles.eDataType.Dimension);
            BulletWeightTextBox.Value = cDataFiles.StandardToMetric(m_Bullet.Weight, cDataFiles.eDataType.BulletWeight);
            BallisticCoefficientTextBox.Value = m_Bullet.BallisticCoefficient;
            LengthTextBox.Value = cDataFiles.StandardToMetric(m_Bullet.Length, cDataFiles.eDataType.Dimension);

            if (m_Bullet.Manufacturer == null || !m_Bullet.Manufacturer.BulletMolds)
                m_Bullet.SelfCast = false;

            SelfCastRadioButton.Checked = m_Bullet.SelfCast;

            TopPunchTextBox.Text = (m_Bullet.SelfCast) ? String.Format("{0:G}", m_Bullet.TopPunch) : "";

            //----------------------------------------------------------------------------*
            // Set Other parameters
            //----------------------------------------------------------------------------*

            PopulateInventoryData();

            SetBulletMinMax();

            SetSectionalDensity();

            m_BulletCalibersListView.Populate();
            }

        //============================================================================*
        // PopulateComboBoxes()
        //============================================================================*

        private void PopulateComboBoxes()
            {
            if (!m_fViewOnly)
                {
                PopulateManufacturerCombo();
                }
            else
                {
                ManufacturerCombo.Items.Clear();
                ManufacturerCombo.Items.Add(m_Bullet.Manufacturer);
                ManufacturerCombo.SelectedIndex = 0;
                }

            FirearmTypeCombo.Value = m_Bullet.FirearmType;
            }

        //============================================================================*
        // PopulateInventoryData()
        //============================================================================*

        private void PopulateInventoryData()
            {
            QuantityTextBox.Value = (int) m_DataFiles.SupplyQuantity(m_Bullet);

            CostTextBox.Value = m_DataFiles.SupplyCost(m_Bullet);

            if (m_DataFiles.Preferences.TrackInventory)
                CostTextBox.Text = String.Format("{0}{1:F2}", m_DataFiles.Preferences.Currency, m_DataFiles.SupplyCost(m_Bullet));

            SetCostEach();
            }

        //============================================================================*
        // PopulateManufacturerCombo()
        //============================================================================*

        private void PopulateManufacturerCombo()
            {
            cControls.PopulateManufacturerCombo(ManufacturerCombo, m_DataFiles, m_Bullet.Manufacturer, cFirearm.eFireArmType.None, (int) cSupply.eSupplyTypes.Bullets);
            }

        //============================================================================*
        // SetBulletImage()
        //============================================================================*

        private void SetBulletImage()
            {
            if (ManufacturerCombo.Text.Length > 0 && PartNumberTextBox.Text.Length > 0)
                {
                try
                    {
                    string strFileName = String.Format(@"Images\{0} {1} Bullet.jpg", ManufacturerCombo.Text, PartNumberTextBox.Value);

                    m_BulletBitmap = new Bitmap(strFileName);
                    }
                catch
                    {
                    m_BulletBitmap = null;
                    }
                }
            else
                m_BulletBitmap = null;

            BulletImage.Image = m_BulletBitmap;
            }

        //============================================================================*
        // SetBulletMinMax()
        //============================================================================*

        private void SetBulletMinMax()
            {
            double dMinDiameter = 1.0;
            double dMaxDiameter = 0.0;
            double dMinWeight = 1000.0;
            double dMaxWeight = 0;

            //----------------------------------------------------------------------------*
            // Get bullet caliber min/max values
            //----------------------------------------------------------------------------*

            if (m_Bullet.BulletCaliberList.Count > 0)
                {
                foreach (cBulletCaliber BulletCaliber in m_Bullet.BulletCaliberList)
                    {
                    if (dMinWeight > BulletCaliber.Caliber.MinBulletWeight)
                        dMinWeight = BulletCaliber.Caliber.MinBulletWeight;

                    if (dMaxWeight < BulletCaliber.Caliber.MaxBulletWeight)
                        dMaxWeight = BulletCaliber.Caliber.MaxBulletWeight;

                    if (dMinDiameter > BulletCaliber.Caliber.MinBulletDiameter)
                        dMinDiameter = BulletCaliber.Caliber.MinBulletDiameter;

                    if (dMaxDiameter < BulletCaliber.Caliber.MaxBulletDiameter)
                        dMaxDiameter = BulletCaliber.Caliber.MaxBulletDiameter;

                    }
                }
            else
                {
                //----------------------------------------------------------------------------*
                // Get caliber min/max values
                //----------------------------------------------------------------------------*

                if (m_DataFiles.CaliberList.Count > 0)
                    {
                    foreach (cCaliber Caliber in m_DataFiles.CaliberList)
                        {
                        if (dMinWeight > Caliber.MinBulletWeight)
                            dMinWeight = Caliber.MinBulletWeight;

                        if (dMaxWeight < Caliber.MaxBulletWeight)
                            dMaxWeight = Caliber.MaxBulletWeight;

                        if (dMinDiameter > Caliber.MinBulletDiameter)
                            dMinDiameter = Caliber.MinBulletDiameter;

                        if (dMaxDiameter < Caliber.MaxBulletDiameter)
                            dMaxDiameter = Caliber.MaxBulletDiameter;
                        }
                    }
                else
                    {
                    dMinDiameter = 0.0;
                    dMaxDiameter = 1.0;
                    dMinWeight = cBullet.MinBulletWeight;
                    dMaxWeight = cBullet.MaxBulletWeight;
                    }
                }

            //----------------------------------------------------------------------------*
            // Set Weight Values
            //----------------------------------------------------------------------------*

            BulletWeightTextBox.MinValue = cDataFiles.StandardToMetric(dMinWeight, cDataFiles.eDataType.BulletWeight);
            BulletWeightTextBox.MaxValue = cDataFiles.StandardToMetric(dMaxWeight, cDataFiles.eDataType.BulletWeight);

            if (!BulletWeightTextBox.ValueOK)
                BulletWeightTextBox.Value = cDataFiles.StandardToMetric(dMinWeight, cDataFiles.eDataType.BulletWeight);

            if (Bullet.Weight == 0.0)
                {
                Bullet.Weight = cDataFiles.MetricToStandard(BulletWeightTextBox.Value, cDataFiles.eDataType.BulletWeight);

                m_fChanged = true;

                UpdateButtons();
                }

            //----------------------------------------------------------------------------*
            // Set Diameter Values
            //----------------------------------------------------------------------------*

            BulletDiameterTextBox.MinValue = cDataFiles.StandardToMetric(dMinDiameter, cDataFiles.eDataType.Dimension);
            BulletDiameterTextBox.MaxValue = cDataFiles.StandardToMetric(dMaxDiameter, cDataFiles.eDataType.Dimension);

            if (!BulletDiameterTextBox.ValueOK)
                BulletDiameterTextBox.Value = cDataFiles.StandardToMetric(dMinDiameter, cDataFiles.eDataType.Dimension);

            if (Bullet.Diameter == 0.0)
                {
                Bullet.Diameter = cDataFiles.MetricToStandard(BulletDiameterTextBox.Value, cDataFiles.eDataType.Dimension);

                m_fChanged = true;

                UpdateButtons();
                }
            }

        //============================================================================*
        // SetCastBulletFields()
        //============================================================================*

        private void SetCastBulletFields()
            {
            cManufacturer Manufacturer = (cManufacturer) ManufacturerCombo.SelectedItem;

            string strText = "Part #:";

            if (Manufacturer.Bullets)
                {
                if (!Manufacturer.BulletMolds)
                    {
                    SelfCastRadioButton.Enabled = false;
                    SelfCastRadioButton.Checked = false;

                    TopPunchLabel.Enabled = false;
                    TopPunchTextBox.Enabled = false;
                    TopPunchTextBox.Text = "";
                    }
                else
                    {
                    SelfCastRadioButton.Enabled = true;

                    TopPunchLabel.Enabled = SelfCastRadioButton.Checked;
                    TopPunchTextBox.Enabled = SelfCastRadioButton.Checked;

                    if (SelfCastRadioButton.Checked)
                        strText = "Mold #:";
                    }
                }
            else
                {
                strText = "Mold #:";

                if (!TypeTextBox.Value.Contains("(LC)"))
                    {
                    TypeTextBox.Value = "(LC) " + TypeTextBox.Value;
                    }

                SelfCastRadioButton.Enabled = true;

                TopPunchLabel.Enabled = SelfCastRadioButton.Checked;
                TopPunchTextBox.Enabled = SelfCastRadioButton.Checked;
                }

            if (!TopPunchTextBox.Enabled)
                TopPunchTextBox.Text = "0";

            Point Location = PartNumberLabel.Location;
            Size Size = PartNumberLabel.Size;

            PartNumberLabel.Text = strText;

            Location.X = Location.X + Size.Width - PartNumberLabel.Size.Width;

            PartNumberLabel.Location = Location;
            }

        //============================================================================*
        // SetCostEach()
        //============================================================================*

        private void SetCostEach()
            {
            CostEachLabel.Text = String.Format("{0}{1:F2}", m_DataFiles.Preferences.Currency, m_DataFiles.SupplyCostEach(m_Bullet));
            }

        //============================================================================*
        // SetInputParameters()
        //============================================================================*

        private void SetInputParameters()
            {
			//----------------------------------------------------------------------------*
			// Set Labels for dimensions and weights
			//----------------------------------------------------------------------------*

			cDataFiles.SetMetricLabel(DiameterMeasurementLabel, cDataFiles.eDataType.Dimension);
			cDataFiles.SetMetricLabel(BulletWeightMeasurementLabel, cDataFiles.eDataType.BulletWeight);
			cDataFiles.SetMetricLabel(LengthMeasurementLabel, cDataFiles.eDataType.Dimension);

            //----------------------------------------------------------------------------*
            // Set Decimal Places
            //----------------------------------------------------------------------------*

            cDataFiles.SetInputParameters(BulletDiameterTextBox, cDataFiles.eDataType.Dimension);
            cDataFiles.SetInputParameters(BulletWeightTextBox, cDataFiles.eDataType.BulletWeight);
            cDataFiles.SetInputParameters(LengthTextBox, cDataFiles.eDataType.Dimension);
            }

        //============================================================================*
        // SetSectionalDensity()
        //============================================================================*

        private void SetSectionalDensity()
            {
//            double dBulletDiameter = cDataFiles.MetricToStandard(BulletDiameterTextBox.Value, cDataFiles.eDataType.Dimension);

//            double dBulletWeight = cDataFiles.MetricToStandard(BulletWeightTextBox.Value, cDataFiles.eDataType.BulletWeight);

            SectionalDensityLabel.Text = String.Format("{0:F3}", m_Bullet.SectionalDensity);
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

            PartNumberTextBox.ToolTip = cm_strPartNumberToolTip;

            m_SelfCastToolTip.ShowAlways = true;
            m_SelfCastToolTip.RemoveAll();
            m_SelfCastToolTip.SetToolTip(SelfCastRadioButton, cm_strSelfCastToolTip);

            TopPunchTextBox.ToolTip = cm_strTopPunchToolTip;

            TypeTextBox.ToolTip = cm_strBulletTypeToolTip;
            TypeTextBox.Required = true;

            BulletDiameterTextBox.ToolTip = cm_strBulletDiameterToolTip;
            BulletWeightTextBox.ToolTip = cm_strBulletWeightToolTip;
            BallisticCoefficientTextBox.ToolTip = cm_strBallisticCoefficientToolTip;
            LengthTextBox.ToolTip = cm_strBulletLengthToolTip;

            m_CaliberListToolTip.ShowAlways = true;
            m_CaliberListToolTip.RemoveAll();
            m_CaliberListToolTip.SetToolTip(m_BulletCalibersListView, cm_strCaliberListToolTip);

            QuantityTextBox.ToolTip = cm_strQuantityAndPriceToolTip;

            m_BulletOKButtonToolTip.ShowAlways = true;
            m_BulletOKButtonToolTip.RemoveAll();
            m_BulletOKButtonToolTip.SetToolTip(BulletOKButton, cm_strBulletOKButtonToolTip);

            m_BulletCancelButtonToolTip.ShowAlways = true;
            m_BulletCancelButtonToolTip.RemoveAll();
            m_BulletCancelButtonToolTip.SetToolTip(BulletCancelButton, cm_strBulletCancelButtonToolTip);

            m_AddCaliberToolTip.ShowAlways = true;
            m_AddCaliberToolTip.RemoveAll();
            m_AddCaliberToolTip.SetToolTip(AddCaliberButton, cm_strAddCaliberButtonToolTip);

            m_EditCaliberToolTip.ShowAlways = true;
            m_EditCaliberToolTip.RemoveAll();
            m_EditCaliberToolTip.SetToolTip(EditCaliberButton, cm_strEditCaliberButtonToolTip);

            m_RemoveCaliberToolTip.ShowAlways = true;
            m_RemoveCaliberToolTip.RemoveAll();
            m_RemoveCaliberToolTip.SetToolTip(RemoveCaliberButton, cm_strRemoveCaliberButtonToolTip);
            }

        //============================================================================*
        // UpdateBulletCaliber()
        //============================================================================*

        private void UpdateBulletCaliber(cBulletCaliber OldBulletCaliber, cBulletCaliber NewBulletCaliber)
            {
            //----------------------------------------------------------------------------*
            // Find the Bullet Caliber
            //----------------------------------------------------------------------------*

            foreach (cBulletCaliber CheckBulletCaliber in m_Bullet.BulletCaliberList)
                {
                //----------------------------------------------------------------------------*
                // See if this is the same Caliber
                //----------------------------------------------------------------------------*

                if (CheckBulletCaliber.CompareTo(OldBulletCaliber) == 0)
                    {
					//----------------------------------------------------------------------------*
					// Update the current Caliber record
					//----------------------------------------------------------------------------*

					CheckBulletCaliber.Copy(NewBulletCaliber);

                    //----------------------------------------------------------------------------*
                    // Update the Caliber on the Caliber tab
                    //----------------------------------------------------------------------------*

                    m_BulletCalibersListView.UpdateBulletCaliber(CheckBulletCaliber, true);

                    return;
                    }
                }

            //----------------------------------------------------------------------------*
            // If the Caliber was not found, add it
            //----------------------------------------------------------------------------*

            AddCaliber(NewBulletCaliber);
            }

        //============================================================================*
        // UpdateButtons()
        //============================================================================*

        private void UpdateButtons()
            {
            if (m_fViewOnly)
                return;

            bool fEnableOK = m_fChanged;
            string strToolTip;

            //----------------------------------------------------------------------------*
            // Get Values
            //----------------------------------------------------------------------------*

            int nQuantity = QuantityTextBox.Value;

            double dPrice = CostTextBox.Value;

            //----------------------------------------------------------------------------*
            // Check FirearmType
            //----------------------------------------------------------------------------*

            if (m_Bullet.BulletCaliberList.Count > 0)
                FirearmTypeCombo.Enabled = false;

            //----------------------------------------------------------------------------*
            // Check Manufacturer
            //----------------------------------------------------------------------------*

            strToolTip = cm_strManufacturerToolTip;

            if (ManufacturerCombo.SelectedIndex == -1)
                {
                fEnableOK = false;

                ManufacturerCombo.BackColor = Color.LightPink;

                strToolTip += "\n\nYou must select a manufacturer.";
                }
            else
                ManufacturerCombo.BackColor = SystemColors.Window;

            if (m_DataFiles.Preferences.ToolTips)
                m_ManufacturerToolTip.SetToolTip(ManufacturerCombo, strToolTip);

            //----------------------------------------------------------------------------*
            // Check Part Number
            //----------------------------------------------------------------------------*

            strToolTip = cm_strPartNumberToolTip;

            if ((m_Bullet != null && m_fAdd || m_Bullet.PartNumber != m_strOriginalPartNumber) && ManufacturerCombo.SelectedIndex != -1)
                {
                cManufacturer Manufacturer = (cManufacturer) ManufacturerCombo.SelectedItem;

                bool fDuplicate = false;

                foreach (cBullet Bullet in m_DataFiles.BulletList)
                    {
                    if (m_Bullet.CompareTo(Bullet) == 0)
                        {
                        fDuplicate = true;

                        break;
                        }
                    }

                if (fDuplicate || string.IsNullOrEmpty(m_Bullet.PartNumber))
                    {
                    if (fDuplicate)
                        {
                        strToolTip += String.Format("\n\nThis Manufacturer/Part Number combination for {0} already exists.  Duplicates are not allowed.", m_Bullet.FirearmType == cFirearm.eFireArmType.Handgun ? "Handguns" : "Rifles");

                        DuplicateLabel.Text = "Duplicate Bullet!";

                        fEnableOK = false;
                        }

                    if (string.IsNullOrEmpty(m_Bullet.PartNumber))
                        {
                        strToolTip += String.Format("\n\nYou must enter the {0} part number for this bullet.", Manufacturer.ToString());
                        }
                    }
                else
                    {
                    DuplicateLabel.Text = "";
                    }
                }

            if (m_DataFiles.Preferences.ToolTips)
                m_PartNumberToolTip.SetToolTip(PartNumberTextBox, strToolTip);

            //----------------------------------------------------------------------------*
            // Check Top Punch
            //----------------------------------------------------------------------------*

            strToolTip = cm_strTopPunchToolTip;

            int nTopPunch = TopPunchTextBox.Value;

            if (nTopPunch < 0 || (SelfCastRadioButton.Checked && nTopPunch == 0))
                {
                fEnableOK = false;

                TopPunchTextBox.BackColor = Color.LightPink;

                strToolTip += "\n\nMust be set to a non-zero value when the \"Self Cast\" Button is checked.";
                }
            else
                {
                TopPunchTextBox.BackColor = SystemColors.Window;
                }

            if (m_DataFiles.Preferences.ToolTips)
                m_TopPunchToolTip.SetToolTip(TopPunchTextBox, strToolTip);

            //----------------------------------------------------------------------------*
            // Check Type
            //----------------------------------------------------------------------------*

            strToolTip = cm_strBulletTypeToolTip;

            string strType = TypeTextBox.Value;

            if (strType.Length == 0)
                {
                fEnableOK = false;

                strToolTip += "\n\nUse the \"Wizard\" button to the right to create a standardized description.";
                }

            if (m_DataFiles.Preferences.ToolTips)
                m_BulletTypeToolTip.SetToolTip(TypeTextBox, strToolTip);

            //----------------------------------------------------------------------------*
            // Check Bullet Diameter
            //----------------------------------------------------------------------------*

            double dBulletDiameter = Math.Round(cDataFiles.MetricToStandard(BulletDiameterTextBox.Value, cDataFiles.eDataType.Dimension), 4);

            double dMinAllowedDiameter = 1.0;
            double dMaxAllowedDiameter = 0.0;
            double dMinWeight = 1000.0;
            double dMaxWeight = 0.0;

            cFirearm.eFireArmType eFirearmType = FirearmTypeCombo.Value;

            strToolTip = cm_strBulletDiameterToolTip;

            bool fFound = false;

            if (m_BulletCalibersListView.SelectedItems.Count == 0)
                {
                BulletDiameterTextBox.Enabled = true;

                foreach (cCaliber CheckCaliber in m_DataFiles.CaliberList)
                    {
                    if (CheckCaliber.FirearmType == eFirearmType)
                        {
                        fFound = true;

                        if (CheckCaliber.MinBulletDiameter < dMinAllowedDiameter)
                            dMinAllowedDiameter = CheckCaliber.MinBulletDiameter;

                        if (CheckCaliber.MaxBulletDiameter > dMaxAllowedDiameter)
                            dMaxAllowedDiameter = CheckCaliber.MaxBulletDiameter;

                        if (CheckCaliber.MinBulletWeight < dMinWeight)
                            dMinWeight = CheckCaliber.MinBulletWeight;

                        if (CheckCaliber.MaxBulletWeight > dMaxWeight)
                            dMaxWeight = CheckCaliber.MaxBulletWeight;
                        }
                    }

                if (!fFound)
                    {
                    strToolTip += "There are no usable calibers in the database that match the firearm type selected.";
                    }
                else
                    {
                    strToolTip += "\n\nBased on the ";

                    strToolTip += (eFirearmType == cFirearm.eFireArmType.Handgun) ? "Handgun" : "Rifle";

                    strToolTip += " calibers in the database,\nbullet diameter must be between ";
                    strToolTip += String.Format("{0:F3} and {1:F3} inches, inclusive.", dMinAllowedDiameter, dMaxAllowedDiameter);
                    }
                }
            else
                {
                foreach (cBulletCaliber CheckBulletCaliber in m_Bullet.BulletCaliberList)
                    {
                    if (CheckBulletCaliber.Caliber.MinBulletDiameter < dMinAllowedDiameter)
                        dMinAllowedDiameter = CheckBulletCaliber.Caliber.MinBulletDiameter;

                    if (CheckBulletCaliber.Caliber.MaxBulletDiameter > dMaxAllowedDiameter)
                        dMaxAllowedDiameter = CheckBulletCaliber.Caliber.MaxBulletDiameter;

                    if (CheckBulletCaliber.Caliber.MinBulletWeight < dMinWeight)
                        dMinWeight = CheckBulletCaliber.Caliber.MinBulletWeight;

                    if (CheckBulletCaliber.Caliber.MaxBulletWeight > dMaxWeight)
                        dMaxWeight = CheckBulletCaliber.Caliber.MaxBulletWeight;
                    }

                if (dMinAllowedDiameter == dMaxAllowedDiameter)
                    {
                    BulletDiameterTextBox.Enabled = false;

                    strToolTip += String.Format("\n\nBased on the calibers in the list below,\nbullet diameter must be {0:F3} inches.", dMinAllowedDiameter);
                    }
                else
                    {
                    strToolTip += "\n\nBased on the calibers in the list below,\nbullet diameter must be between ";
                    strToolTip += String.Format("{0:F3} and {1:F3} inches, inclusive.", dMinAllowedDiameter, dMaxAllowedDiameter);

                    BulletDiameterTextBox.Enabled = true;
                    }
                }

            BulletDiameterTextBox.MinValue = cDataFiles.StandardToMetric(dMinAllowedDiameter, cDataFiles.eDataType.Dimension);
            BulletDiameterTextBox.MaxValue = cDataFiles.StandardToMetric(dMaxAllowedDiameter, cDataFiles.eDataType.Dimension);
            BulletWeightTextBox.MinValue = cDataFiles.StandardToMetric(dMinWeight, cDataFiles.eDataType.BulletWeight);
            BulletWeightTextBox.MaxValue = cDataFiles.StandardToMetric(dMaxWeight, cDataFiles.eDataType.BulletWeight);

            if (m_DataFiles.Preferences.ToolTips)
                BulletDiameterTextBox.ToolTip = strToolTip;

            if (!BulletDiameterTextBox.ValueOK)
                fEnableOK = false;

            //----------------------------------------------------------------------------*
            // Check BallisticCoefficient
            //----------------------------------------------------------------------------*

            if (!BallisticCoefficientTextBox.ValueOK)
                fEnableOK = false;

            //----------------------------------------------------------------------------*
            // Check Weight
            //----------------------------------------------------------------------------*

            double dWeight = cDataFiles.MetricToStandard(BulletWeightTextBox.Value, cDataFiles.eDataType.BulletWeight);

            if (!BulletWeightTextBox.ValueOK)
                fEnableOK = false;

            //----------------------------------------------------------------------------*
            // Check Quantity
            //----------------------------------------------------------------------------*

            strToolTip = cm_strQuantityAndPriceToolTip;

            if (!QuantityTextBox.ValueOK)
                {
                fEnableOK = false;

                strToolTip += QuantityTextBox.ToolTip;
                }
            else
                {
                if (nQuantity == 0 && dPrice > 0.0)
                    {
                    fEnableOK = false;

                    QuantityTextBox.BackColor = Color.LightPink;

                    strToolTip += "\n\nSince the price is not zero (0.00), quantity must be greater than zero.";
                    }
                else
                    QuantityTextBox.BackColor = SystemColors.Window;
                }

            if (m_DataFiles.Preferences.ToolTips)
                QuantityTextBox.ToolTip = strToolTip;

            //----------------------------------------------------------------------------*
            // Check Price
            //----------------------------------------------------------------------------*

            if (!CostTextBox.ValueOK)
                fEnableOK = false;

            //----------------------------------------------------------------------------*
            // Check Calibers
            //----------------------------------------------------------------------------*

            strToolTip = cm_strCaliberListToolTip;

            if (m_Bullet.BulletCaliberList.Count == 0)
                {
                fEnableOK = false;

                m_BulletCalibersListView.BackColor = Color.LightPink;

                strToolTip += "\n\nAt least one caliber must be selected.";
                }
            else
                {
                m_BulletCalibersListView.BackColor = SystemColors.Window;
                }

            if (m_DataFiles.Preferences.ToolTips)
                m_CaliberListToolTip.SetToolTip(m_BulletCalibersListView, strToolTip);

            BulletOKButton.Enabled = fEnableOK;

            if (m_DataFiles.Preferences.ToolTips)
                {
                if (fEnableOK)
                    m_BulletOKButtonToolTip.SetToolTip(BulletOKButton, cm_strBulletOKButtonToolTip);
                else
                    m_BulletOKButtonToolTip.SetToolTip(BulletOKButton, "You must fix the data highlighted in red above in order to add or update this bullet.");
                }

            //----------------------------------------------------------------------------*
            // Add, Edit, and Remove Caliber Buttons
            //----------------------------------------------------------------------------*

            int nCaliberCount = 0;

            if (ManufacturerCombo.SelectedIndex != -1)
                {
                foreach (cCaliber CheckCaliber in m_DataFiles.CaliberList)
                    {
                    if (CheckCaliber.FirearmType != m_Bullet.FirearmType || CheckCaliber.Rimfire)
                        continue;

                    bool fAdd = true;

                    if (dBulletDiameter >= CheckCaliber.MinBulletDiameter &&
                        dBulletDiameter <= CheckCaliber.MaxBulletDiameter &&
                        dWeight >= CheckCaliber.MinBulletWeight &&
                        dWeight <= CheckCaliber.MaxBulletWeight)
                        {
                        foreach (cBulletCaliber BulletCaliber in m_Bullet.BulletCaliberList)
                            {
                            if (BulletCaliber.Caliber.CompareTo(CheckCaliber) == 0)
                                {
                                fAdd = false;

                                break;
                                }
                            }

                        if (fAdd)
                            nCaliberCount++;
                        }
                    }
                }

            strToolTip = cm_strAddCaliberButtonToolTip;

            if (nCaliberCount == 0)
                {
                string strCaliberToolTip = cm_strCaliberListToolTip;
                strCaliberToolTip += "\n\nThere are no calibers that can accomodate a bullet with this firearm Type, Diameter, and Weight.";

                m_CaliberListToolTip.SetToolTip(m_BulletCalibersListView, strCaliberToolTip);

                AddCaliberButton.Enabled = false;

                strToolTip += "\n\nThis button has been disabled because there are currently\nno unselected calibers appropriate for the bullet diameter specifed above.";
                }
            else
                {
                AddCaliberButton.Enabled = true;
                }

            if (m_DataFiles.Preferences.ToolTips)
                m_AddCaliberToolTip.SetToolTip(AddCaliberButton, strToolTip);

            string strEditToolTip = cm_strEditCaliberButtonToolTip;
            ;
            string strRemoveToolTip = cm_strRemoveCaliberButtonToolTip;

            if (m_BulletCalibersListView.SelectedItems.Count > 0)
                {
                EditCaliberButton.Enabled = true;
                RemoveCaliberButton.Enabled = true;
                }
            else
                {
                EditCaliberButton.Enabled = false;
                RemoveCaliberButton.Enabled = false;

                strEditToolTip += "\n\nThis button has been disabled because no caliber has been selected in the list above.";

                strRemoveToolTip += "\n\nThis button has been disabled because no caliber has been selected in the list above.";
                }

            if (m_DataFiles.Preferences.ToolTips)
                {
                m_EditCaliberToolTip.SetToolTip(EditCaliberButton, strEditToolTip);
                m_RemoveCaliberToolTip.SetToolTip(RemoveCaliberButton, strRemoveToolTip);
                }
            }
        }
    }
