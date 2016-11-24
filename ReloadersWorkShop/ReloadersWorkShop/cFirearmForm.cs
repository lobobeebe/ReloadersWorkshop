//============================================================================*
// cFirearmForm.cs
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

using ReloadersWorkShop.Controls;
using ReloadersWorkShop.Preferences;

//============================================================================*
// NameSpace
//============================================================================*

namespace ReloadersWorkShop
	{
	//============================================================================*
	// cFirearmForm Class
	//============================================================================*

	public partial class cFirearmForm : Form
		{
		//----------------------------------------------------------------------------*
		// Private Const Data Members
		//----------------------------------------------------------------------------*

		private const string cm_strFirearmTypeToolTip = "Type of Firearm.";
		private const string cm_strManufacturerToolTip = "Manufacturer of this firearm.";
		private const string cm_strModelToolTip = "Manufacturer's model number for this firearm.";
		private const string cm_strSerialNumberToolTip = "Serial #, or ID, of this firearm.";
		private const string cm_strDescriptionToolTip = "A brief description of this firearm.";
		private const string cm_strPurchaseDateToolTip = "The date you purchsed or acquired this firearm.";
		private const string cm_strPriceToolTip = "The amount you paid for this firearm.";

		private const string cm_strCaliberToolTip = "Select a cartridge to add to this firearm's usable cartridge list.";
		private const string cm_strCaliberListToolTip = "List of usable cartridges for this firearm.";
		private const string cm_strBarrelLengthToolTip = "The length of this firearm's barrel.";
		private const string cm_strTwistToolTip = "The twist rate of the rifling in this firearm's barrel.";
		private const string cm_strZeroRangeToolTip = "The range at which this firearm's sights have been zeroed.";
		private const string cm_strSightHeightToolTip = "The height of the sight above the bore.";

		private const string cm_strScopedToolTip = "Check if this firearm has a scope.";
		private const string cm_strScopeClickToolTip = "The distance, in MOA or Mils, that each click of the scope turrets will move the impact point.";
		private const string cm_strTurretTypeToolTip = "The type of adjustment of the turrets on this firearm's scope.";

		private const string cm_strHeadSpaceToolTip = "The headspace to which ammo for this firearm should be sized.";
		private const string cm_strNeckToolTip = "The neck size to which ammo for this firearm should be sized.";
		private const string cm_strHeadToolTip = "The distance that this firearm's sights are above the muzzle.";
		private const string cm_strBulletListToolTip = "List of bullets for which you have specific COAL or CBTO (Cartridge Base To Ogive) data.";

		private const string cm_strAddBulletButtonToolTip = "Click to add new bullet specific data for this firearm.";
		private const string cm_strRemoveBulletButtonToolTip = "Click to remove bullet specific data from the list.";
		private const string cm_strEditBulletButtonToolTip = "Click to edit the selected bullet specific data.";

		private const string cm_strFirearmOKButtonToolTip = "Click to add or update the firearm with the above data.";
		private const string cm_strFirearmCancelButtonToolTip = "Click to cancel changes and return to the main window.";

		//----------------------------------------------------------------------------*
		// Private Data Members
		//----------------------------------------------------------------------------*

		private bool m_fInitialized = false;
		private bool m_fChanged = false;

		private cFirearm m_Firearm = null;

		private cDataFiles m_DataFiles;
		private bool m_fViewOnly = false;

		private cFirearmBulletListView m_BulletListView = null;

		private ToolTip m_FirearmTypeToolTip = new ToolTip();
		private ToolTip m_ManufacturerToolTip = new ToolTip();
		private ToolTip m_PurchaseDateToolTip = new ToolTip();

		private ToolTip m_CaliberListToolTip = new ToolTip();
		private ToolTip m_CaliberToolTip = new ToolTip();
		private ToolTip m_ScopedToolTip = new ToolTip();
		private ToolTip m_TurretTypeToolTip = new ToolTip();
		private ToolTip m_BulletListToolTip = new ToolTip();

		private ToolTip m_AddBulletButtonToolTip = new ToolTip();
		private ToolTip m_RemoveBulletButtonToolTip = new ToolTip();
		private ToolTip m_EditBulletButtonToolTip = new ToolTip();

		private ToolTip m_FirearmOKButtonToolTip = new ToolTip();
		private ToolTip m_FirearmCancelButtonToolTip = new ToolTip();

		//============================================================================*
		// cFirearmForm() - Constructor
		//============================================================================*

		public cFirearmForm(cFirearm Firearm, cDataFiles DataFiles, bool fViewOnly = false)
			{
			InitializeComponent();

			m_DataFiles = DataFiles;
			m_fViewOnly = fViewOnly;

			//----------------------------------------------------------------------------*
			// Setup the buttons
			//----------------------------------------------------------------------------*

			if (Firearm == null)
				{
				if (m_fViewOnly)
					return;

				m_Firearm = new cFirearm();

				OKButton.Text = "Add";
				}
			else
				{
				m_Firearm = new cFirearm(Firearm);

				if (!m_fViewOnly)
					OKButton.Text = "Update";
				else
					{
					OKButton.Visible = false;

					FirearmCancelButton.Text = "Close";

					int nButtonX = (this.Size.Width / 2) - (FirearmCancelButton.Width / 2);

					FirearmCancelButton.Location = new Point(nButtonX, FirearmCancelButton.Location.Y);
					}

				FirearmTypeCombo.Enabled = false;
				}

			SetClientSizeCore(CartridgeSpecsGroupBox.Location.X + CartridgeSpecsGroupBox.Width + 10, FirearmCancelButton.Location.Y + FirearmCancelButton.Height + 20);

			//----------------------------------------------------------------------------*
			// Create the Firearm Bullet ListView
			//----------------------------------------------------------------------------*

			m_BulletListView = new cFirearmBulletListView(m_DataFiles, m_Firearm);

			m_BulletListView.Location = new Point(6, 20);
			m_BulletListView.Size = new Size(CartridgeSpecsGroupBox.Width - 12, AddBulletButton.Location.Y - m_BulletListView.Location.Y - 6);

			CartridgeSpecsGroupBox.Controls.Add(m_BulletListView);

			//----------------------------------------------------------------------------*
			// Set Control Event Handlers
			//----------------------------------------------------------------------------*

			if (!m_fViewOnly)
				{
				FirearmTypeCombo.SelectedIndexChanged += OnFirearmTypeSelected;
				ManufacturerCombo.SelectedIndexChanged += OnManufacturerSelected;
				CaliberCombo.SelectedIndexChanged += OnCaliberSelected;

				ModelTextBox.TextChanged += OnModelChanged;

				SerialNumberTextBox.TextChanged += OnSerialNumberChanged;
				DescriptionTextBox.TextChanged += OnDescriptionChanged;

				BarrelLengthTextBox.TextChanged += OnBarrelLengthChanged;
				TwistTextBox.TextChanged += OnTwistChanged;
				ZeroRangeTextBox.TextChanged += OnZeroRangeChanged;
				SightHeightTextBox.TextChanged += OnSightHeightChanged;

				ScopedCheckBox.Click += OnScopedClicked;
				TurretTypeComboBox.SelectedIndexChanged += OnTurretTypeSelected;
				ScopeClickTextBox.TextChanged += OnScopeClickChanged;

				HeadSpaceTextBox.TextChanged += OnHeadSpaceChanged;
				NeckTextBox.TextChanged += OnNeckChanged;

				m_BulletListView.SelectedIndexChanged += OnBulletSelected;

				CaliberListBox.SelectedIndexChanged += OnFirearmCaliberSelected;

				AddCartridgeButton.Click += OnAddCartridge;
				RemoveCartridgeButton.Click += OnRemoveCartridge;
				MakePrimaryButton.Click += OnMakePrimaryClicked;

				AddBulletButton.Click += OnAddBullet;
				EditBulletButton.Click += OnEditBullet;
				RemoveBulletButton.Click += OnRemoveBullet;
				}
			else
				{
				ModelTextBox.ReadOnly = true;
				SerialNumberTextBox.ReadOnly = true;
				DescriptionTextBox.ReadOnly = true;
				BarrelLengthTextBox.ReadOnly = true;
				TwistTextBox.ReadOnly = true;
				ZeroRangeTextBox.ReadOnly = true;
				SightHeightTextBox.ReadOnly = true;
				ScopeClickTextBox.ReadOnly = true;
				TurretTypeComboBox.Enabled = false;
				HeadSpaceTextBox.ReadOnly = true;
				NeckTextBox.ReadOnly = true;

				AddBulletButton.Enabled = false;
				EditBulletButton.Enabled = false;
				RemoveBulletButton.Enabled = false;
				}

			FirearmDetailsButton.Click += OnFirearmDetailsClicked;

			//----------------------------------------------------------------------------*
			// Set input parameters
			//----------------------------------------------------------------------------*

			SetInputParameters();

			//----------------------------------------------------------------------------*
			// Fill in the firearm data
			//----------------------------------------------------------------------------*

			FirearmTypeCombo.Value = m_Firearm.FirearmType;

			cCaliber.CurrentFirearmType = m_Firearm.FirearmType;

			PopulateComboBoxes();

			//----------------------------------------------------------------------------*
			// Set title and text fields
			//----------------------------------------------------------------------------*

			string strTitle;

			if (Firearm == null)
				strTitle = "Add";
			else
				{
				if (!m_fViewOnly)
					strTitle = "Edit";
				else
					strTitle = "View";
				}

			//----------------------------------------------------------------------------*
			// Set Title
			//----------------------------------------------------------------------------*

			strTitle += " Firearm";

			Text = strTitle;

			FirearmDetailsButton.Text = strTitle + " Details";

			SetStaticToolTips();

			if (!m_fViewOnly)
				{
				UpdateButtons();

				ManufacturerCombo.Focus();
				}
			else
				FirearmCancelButton.Focus();

			m_fInitialized = true;
			}

		//============================================================================*
		// AddBullet()
		//============================================================================*

		private void AddBullet(cFirearmBullet FirearmBullet)
			{
			//----------------------------------------------------------------------------*
			// If the Caliber already exists, update the existing one and exit
			//----------------------------------------------------------------------------*

			foreach (cFirearmBullet CheckFirearmBullet in m_Firearm.FirearmBulletList)
				{
				if (CheckFirearmBullet.CompareTo(FirearmBullet) == 0)
					{
					UpdateBullet(CheckFirearmBullet, FirearmBullet);

					return;
					}
				}

			//----------------------------------------------------------------------------*
			// Add the new caliber to the list
			//----------------------------------------------------------------------------*

			m_Firearm.FirearmBulletList.Add(FirearmBullet);

			//----------------------------------------------------------------------------*
			// Add the new bullet to the list
			//----------------------------------------------------------------------------*

			m_BulletListView.AddFirearmBullet(FirearmBullet, true);

			m_fChanged = true;

			UpdateButtons();
			}

		//============================================================================*
		// Firearm Property
		//============================================================================*

		public cFirearm Firearm
			{
			get
				{
				return (m_Firearm);
				}
			}

		//============================================================================*
		// OnAddBullet()
		//============================================================================*

		private void OnAddBullet(object sender, EventArgs e)
			{
			//----------------------------------------------------------------------------*
			// Start the dialog
			//----------------------------------------------------------------------------*

			cCaliber Caliber = null;

			if (CaliberListBox.SelectedItems.Count > 0)
				Caliber = (CaliberListBox.SelectedItem as cFirearmCaliber).Caliber;

			cFirearmBulletForm FirearmBulletForm = new cFirearmBulletForm(null, m_Firearm, Caliber, m_DataFiles);

			if (FirearmBulletForm.ShowDialog() == DialogResult.OK)
				{
				//----------------------------------------------------------------------------*
				// Get the new Bullet Data
				//----------------------------------------------------------------------------*

				cFirearmBullet NewFirearmBullet = FirearmBulletForm.FirearmBullet;

				//----------------------------------------------------------------------------*
				// See if the Bullet already exists
				//----------------------------------------------------------------------------*

				cFirearmBullet OldFirearmBullet = NewFirearmBullet;

				foreach (cFirearmBullet CheckFirearmBullet in Firearm.FirearmBulletList)
					{
					if (CheckFirearmBullet.CompareTo(NewFirearmBullet) == 0)
						{
						UpdateBullet(CheckFirearmBullet, NewFirearmBullet);

						m_fChanged = true;

						return;
						}
					}

				AddBullet(NewFirearmBullet);
				}
			}

		//============================================================================*
		// OnAddCartridge()
		//============================================================================*

		private void OnAddCartridge(object sender, EventArgs e)
			{
			if (CaliberCombo.SelectedIndex < 1)
				return;

			cCaliber Caliber = (cCaliber) CaliberCombo.SelectedItem;

			if (m_Firearm.AddCaliber(Caliber))
				{
				PopulateCaliberList();

				PopulateCaliberCombo();

				m_fChanged = true;

				UpdateButtons();
				}
			}

		//============================================================================*
		// OnBarrelLengthChanged()
		//============================================================================*

		protected void OnBarrelLengthChanged(object sender, EventArgs e)
			{
			if (!m_fInitialized)
				return;

			m_Firearm.BarrelLength = cDataFiles.MetricToStandard(BarrelLengthTextBox.Value, cDataFiles.eDataType.Firearm);

			m_fChanged = true;

			UpdateButtons();
			}

		//============================================================================*
		// OnBulletSelected()
		//============================================================================*

		protected void OnBulletSelected(object sender, EventArgs e)
			{
			if (!m_fInitialized)
				return;

			m_fChanged = true;

			UpdateButtons();
			}

		//============================================================================*
		// OnCaliberSelected()
		//============================================================================*

		protected void OnCaliberSelected(object sender, EventArgs e)
			{
			if (!m_fInitialized)
				return;

			UpdateButtons();
			}

		//============================================================================*
		// OnDescriptionChanged()
		//============================================================================*

		protected void OnDescriptionChanged(object sender, EventArgs e)
			{
			if (!m_fInitialized)
				return;

			m_Firearm.Description = DescriptionTextBox.Value;

			m_fChanged = true;

			UpdateButtons();
			}

		//============================================================================*
		// OnEditBullet()
		//============================================================================*

		private void OnEditBullet(object sender, EventArgs e)
			{
			//----------------------------------------------------------------------------*
			// Get the selected bullet
			//----------------------------------------------------------------------------*

			ListViewItem Item = m_BulletListView.SelectedItems[0];

			if (Item == null)
				return;

			cFirearmBullet FirearmBullet = (cFirearmBullet) Item.Tag;

			if (FirearmBullet == null)
				return;

			//----------------------------------------------------------------------------*
			// Start the dialog
			//----------------------------------------------------------------------------*

			cCaliber Caliber = null;

			if (CaliberListBox.SelectedItems.Count > 0)
				Caliber = (CaliberListBox.SelectedItem as cFirearmCaliber).Caliber;

			cFirearmBulletForm FirearmBulletForm = new cFirearmBulletForm(FirearmBullet, m_Firearm, Caliber, m_DataFiles);

			if (FirearmBulletForm.ShowDialog() == DialogResult.OK)
				{
				//----------------------------------------------------------------------------*
				// Get the new Bullet Data
				//----------------------------------------------------------------------------*

				cFirearmBullet NewFirearmBullet = FirearmBulletForm.FirearmBullet;

				m_Firearm.FirearmBulletList.Remove(FirearmBullet);

				m_Firearm.FirearmBulletList.Add(NewFirearmBullet);

				m_BulletListView.Populate();

				m_fChanged = true;
				}
			}

		//============================================================================*
		// OnFirearmCaliberSelected()
		//============================================================================*

		protected void OnFirearmCaliberSelected(object sender, EventArgs e)
			{
			if (!m_fInitialized)
				return;

			cCaliber Caliber = null;

			if (CaliberListBox.SelectedItems.Count > 0)
				Caliber = (CaliberListBox.SelectedItem as cFirearmCaliber).Caliber;

			m_BulletListView.Caliber = Caliber;

			UpdateButtons();
			}

		//============================================================================*
		// OnFirearmDetailsClicked()
		//============================================================================*

		private void OnFirearmDetailsClicked(object sender, EventArgs e)
			{
			cFirearmDetailForm DetailForm = new cFirearmDetailForm(ref m_Firearm, m_DataFiles, m_fViewOnly);

			DialogResult rc = DetailForm.ShowDialog();

			if (rc == DialogResult.OK)
				{
				m_Firearm = DetailForm.Firearm;

				m_fChanged = true;
				}

			PopulateFirearmData();

			UpdateButtons();
			}

		//============================================================================*
		// OnFirearmTypeSelected()
		//============================================================================*

		private void OnFirearmTypeSelected(object sender, EventArgs e)
			{
			if (!m_fInitialized)
				return;

			if (m_Firearm.FirearmType != FirearmTypeCombo.Value)
				m_Firearm.FirearmBulletList.Clear();

			m_Firearm.FirearmType = FirearmTypeCombo.Value;

			cCaliber.CurrentFirearmType = m_Firearm.FirearmType;

			if (m_Firearm.FirearmType == cFirearm.eFireArmType.Shotgun)
				UsableCartridgeGroup.Text = "Usable ShotShells";
			else
				UsableCartridgeGroup.Text = "Usable Cartridges";

			PopulateComboBoxes();

			m_fChanged = true;

			UpdateButtons();
			}

		//============================================================================*
		// OnHeadSpaceChanged()
		//============================================================================*

		protected void OnHeadSpaceChanged(object sender, EventArgs e)
			{
			if (!m_fInitialized)
				return;

			m_Firearm.HeadSpace = cDataFiles.MetricToStandard(HeadSpaceTextBox.Value, cDataFiles.eDataType.Dimension);

			m_fChanged = true;

			UpdateButtons();
			}

		//============================================================================*
		// OnMakePrimaryClicked()
		//============================================================================*

		private void OnMakePrimaryClicked(object sender, EventArgs e)
			{
			cFirearmCaliber FirearmCaliber = null;

			if (CaliberListBox.SelectedItems.Count > 0)
				FirearmCaliber = (cFirearmCaliber) CaliberListBox.SelectedItems[0];

			if (FirearmCaliber == null)
				return;

			m_Firearm.PrimaryCaliber = FirearmCaliber.Caliber;

			PopulateCaliberList();

			m_fChanged = true;

			UpdateButtons();
			}

		//============================================================================*
		// OnManufacturerSelected()
		//============================================================================*

		protected void OnManufacturerSelected(object sender, EventArgs e)
			{
			if (!m_fInitialized && m_Firearm.Manufacturer != null)
				return;

			m_Firearm.Manufacturer = (cManufacturer) ManufacturerCombo.SelectedItem;

			m_fChanged = true;

			UpdateButtons();
			}

		//============================================================================*
		// OnModelChanged()
		//============================================================================*

		protected void OnModelChanged(object sender, EventArgs e)
			{
			if (!m_fInitialized)
				return;

			m_Firearm.PartNumber = ModelTextBox.Value;

			m_fChanged = true;

			UpdateButtons();
			}

		//============================================================================*
		// OnNeckChanged()
		//============================================================================*

		protected void OnNeckChanged(object sender, EventArgs e)
			{
			if (!m_fInitialized)
				return;

			m_Firearm.Neck = cDataFiles.MetricToStandard(NeckTextBox.Value, cDataFiles.eDataType.Dimension);

			m_fChanged = true;

			UpdateButtons();
			}

		//============================================================================*
		// OnRemoveBullet()
		//============================================================================*

		private void OnRemoveBullet(object sender, EventArgs e)
			{
			//----------------------------------------------------------------------------*
			// Warn user of impending doom
			//----------------------------------------------------------------------------*

			if (MessageBox.Show(this, "Are you sure you wish to delete this bullet?", "Data Deletion Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
				{
				cFirearmBullet FirearmBullet = (cFirearmBullet) m_BulletListView.SelectedItems[0].Tag;

				m_BulletListView.Items.Remove(m_BulletListView.SelectedItems[0]);

				m_Firearm.FirearmBulletList.Remove(FirearmBullet);

				m_fChanged = true;

				UpdateButtons();
				}
			}

		//============================================================================*
		// OnRemoveCartridge()
		//============================================================================*

		private void OnRemoveCartridge(object sender, EventArgs e)
			{
			cFirearmCaliber FirearmCaliber = null;
			
			if (CaliberListBox.SelectedItems.Count > 0)
				FirearmCaliber = (cFirearmCaliber) CaliberListBox.SelectedItems[0];

			if (FirearmCaliber == null)
				return;

			m_Firearm.RemoveCaliber(FirearmCaliber);

			PopulateCaliberList();
			PopulateCaliberCombo();

			m_BulletListView.Populate();

			cCaliber Caliber = null;

			if (CaliberListBox.SelectedItems.Count > 0)
				Caliber = (CaliberListBox.SelectedItem as cFirearmCaliber).Caliber;

			m_BulletListView.Caliber = Caliber;

			PopulateCaliberList();

			UpdateButtons();
			}

		//============================================================================*
		// OnScopedClicked()
		//============================================================================*

		protected void OnScopedClicked(object sender, EventArgs e)
			{
			if (!m_fInitialized)
				return;

			ScopedCheckBox.Checked = ScopedCheckBox.Checked ? false : true;

			ScopeClickTextBox.Enabled = ScopedCheckBox.Checked;
			TurretTypeComboBox.Enabled = ScopedCheckBox.Checked;

			m_Firearm.Scoped = ScopedCheckBox.Checked;

			m_fChanged = true;

			UpdateButtons();
			}

		//============================================================================*
		// OnScopeClickChanged()
		//============================================================================*

		protected void OnScopeClickChanged(object sender, EventArgs e)
			{
			if (!m_fInitialized)
				return;

			m_Firearm.ScopeClick = ScopeClickTextBox.Value;

			m_fChanged = true;

			UpdateButtons();
			}

		//============================================================================*
		// OnSerialNumberChanged()
		//============================================================================*

		protected void OnSerialNumberChanged(object sender, EventArgs e)
			{
			if (!m_fInitialized)
				return;

			m_Firearm.SerialNumber = SerialNumberTextBox.Value;

			m_fChanged = true;

			UpdateButtons();
			}

		//============================================================================*
		// OnSightHeightChanged()
		//============================================================================*

		protected void OnSightHeightChanged(object sender, EventArgs e)
			{
			if (!m_fInitialized)
				return;

			m_Firearm.SightHeight = cDataFiles.MetricToStandard(SightHeightTextBox.Value, cDataFiles.eDataType.Firearm);

			m_fChanged = true;

			UpdateButtons();
			}

		//============================================================================*
		// OnTurretTypeSelected()
		//============================================================================*

		private void OnTurretTypeSelected(object sender, EventArgs e)
			{
			if (!m_fInitialized)
				return;

			m_Firearm.TurretType = (cFirearm.eTurretType) TurretTypeComboBox.SelectedIndex;

			m_fChanged = true;

			UpdateButtons();
			}

		//============================================================================*
		// OnTwistChanged()
		//============================================================================*

		protected void OnTwistChanged(object sender, EventArgs e)
			{
			if (!m_fInitialized)
				return;

			m_Firearm.Twist = cDataFiles.MetricToStandard(TwistTextBox.Value, cDataFiles.eDataType.Firearm);

			m_fChanged = true;

			UpdateButtons();
			}

		//============================================================================*
		// OnZeroRangeChanged()
		//============================================================================*

		protected void OnZeroRangeChanged(object sender, EventArgs e)
			{
			if (!m_fInitialized)
				return;

			m_Firearm.ZeroRange = (int) cDataFiles.MetricToStandard(ZeroRangeTextBox.Value, cDataFiles.eDataType.Range);

			m_fChanged = true;

			UpdateButtons();
			}

		//============================================================================*
		// PopulateComboBoxes()
		//============================================================================*

		private void PopulateComboBoxes()
			{
			PopulateManufacturerCombo();
			PopulateCaliberCombo();

			PopulateFirearmData();
			}

		//============================================================================*
		// PopulateCaliberCombo()
		//============================================================================*

		private void PopulateCaliberCombo()
			{
			cCaliber PrimaryCaliber = m_Firearm.PrimaryCaliber;

			CaliberCombo.Items.Clear();

			CaliberCombo.Items.Add("Select Cartridge");

			foreach (cCaliber Caliber in m_DataFiles.CaliberList)
				{
				if (Caliber.FirearmType == FirearmTypeCombo.Value &&
					(!m_DataFiles.Preferences.HideUncheckedCalibers || Caliber.Checked) &&
					!m_Firearm.HasCaliber(Caliber))
					{
					if (PrimaryCaliber != null)
						{
						if (Caliber.MinBulletDiameter >= PrimaryCaliber.MaxBulletDiameter && Caliber.MaxBulletDiameter <= PrimaryCaliber.MaxBulletDiameter)
							CaliberCombo.Items.Add(Caliber);
						}
					else
						CaliberCombo.Items.Add(Caliber);
					}
				}

			CaliberCombo.SelectedIndex = 0;
			}

		//============================================================================*
		// PopulateCaliberList()
		//============================================================================*

		private void PopulateCaliberList()
			{
			CaliberListBox.Items.Clear();

			cFirearmCaliber SelectFirearmCaliber = null;

			foreach (cFirearmCaliber FirearmCaliber in m_Firearm.CaliberList)
				{
				int nIndex = CaliberListBox.Items.Add(FirearmCaliber);

				if (FirearmCaliber.Primary)
					SelectFirearmCaliber = FirearmCaliber;
				}

			if (CaliberListBox.Items.Count > 0)
				{
				if (SelectFirearmCaliber != null)
					CaliberListBox.SelectedItem = SelectFirearmCaliber;

				if (CaliberListBox.SelectedIndex < 0)
					CaliberListBox.SelectedIndex = 0;
				}
			}

		//============================================================================*
		// PopulateFirearmData()
		//============================================================================*

		private void PopulateFirearmData()
			{
			ModelTextBox.Value = m_Firearm.PartNumber;
			SerialNumberTextBox.Value = m_Firearm.SerialNumber;
			DescriptionTextBox.Value = m_Firearm.Description;

			BarrelLengthTextBox.Value = cDataFiles.StandardToMetric(m_Firearm.BarrelLength, cDataFiles.eDataType.Firearm);
			TwistTextBox.Value = cDataFiles.StandardToMetric(m_Firearm.Twist, cDataFiles.eDataType.Firearm);
			SightHeightTextBox.Value = cDataFiles.StandardToMetric(m_Firearm.SightHeight, cDataFiles.eDataType.Firearm);

			ScopedCheckBox.Checked = m_Firearm.Scoped;
			ScopeClickTextBox.Value = m_Firearm.ScopeClick;
			ScopeClickTextBox.Enabled = m_Firearm.Scoped;

			TurretTypeComboBox.SelectedIndex = (int) m_Firearm.TurretType;
			TurretTypeComboBox.Enabled = m_Firearm.Scoped;

			HeadSpaceTextBox.Value = cDataFiles.StandardToMetric(m_Firearm.HeadSpace, cDataFiles.eDataType.Dimension);
			HeadSpaceTextBox.Enabled = FirearmTypeCombo.Value == cFirearm.eFireArmType.Rifle;

			NeckTextBox.Value = cDataFiles.StandardToMetric(m_Firearm.Neck, cDataFiles.eDataType.Dimension);
			NeckTextBox.Enabled = FirearmTypeCombo.Value == cFirearm.eFireArmType.Rifle;

			ZeroRangeTextBox.Value = (int) cDataFiles.StandardToMetric(m_Firearm.ZeroRange, cDataFiles.eDataType.Range);

			m_BulletListView.Populate();

			PopulateCaliberList();

			UpdateButtons();
			}

		//============================================================================*
		// PopulateManufacturerCombo()
		//============================================================================*

		private void PopulateManufacturerCombo()
			{
			if (!m_fViewOnly)
				cControls.PopulateManufacturerCombo(ManufacturerCombo, m_DataFiles, m_Firearm.Manufacturer, FirearmTypeCombo.Value);
			else
				{
				ManufacturerCombo.Items.Clear();

				ManufacturerCombo.Items.Add(m_Firearm.Manufacturer);

				ManufacturerCombo.SelectedIndex = 0;
				}
			}

		//============================================================================*
		// SetInputParameters()
		//============================================================================*

		private void SetInputParameters()
			{
			//----------------------------------------------------------------------------*
			// Set Measurement Labels
			//----------------------------------------------------------------------------*

			cDataFiles.SetMetricLabel(BarrelMeasurementLabel, cDataFiles.eDataType.Firearm);
			cDataFiles.SetMetricLabel(TwistMeasurementLabel, cDataFiles.eDataType.Firearm);
			cDataFiles.SetMetricLabel(SightHeightMeasurementLabel, cDataFiles.eDataType.Firearm);

			cDataFiles.SetMetricLabel(HeadspaceMeasurementLabel, cDataFiles.eDataType.Dimension);
			cDataFiles.SetMetricLabel(NeckSizeMeasurementLabel, cDataFiles.eDataType.Dimension);

			cDataFiles.SetMetricLabel(ZeroRangeDistancelabel, cDataFiles.eDataType.Range);

			//----------------------------------------------------------------------------*
			// Set Text Box Input Parameters
			//----------------------------------------------------------------------------*

			cDataFiles.SetInputParameters(BarrelLengthTextBox, cDataFiles.eDataType.Firearm);
			cDataFiles.SetInputParameters(TwistTextBox, cDataFiles.eDataType.Firearm);
			cDataFiles.SetInputParameters(SightHeightTextBox, cDataFiles.eDataType.Firearm);

			cDataFiles.SetInputParameters(HeadSpaceTextBox, cDataFiles.eDataType.Dimension);
			cDataFiles.SetInputParameters(NeckTextBox, cDataFiles.eDataType.Dimension);

			cDataFiles.SetInputParameters(ZeroRangeTextBox, cDataFiles.eDataType.Range);
            }

		//============================================================================*
		// SetMinMax()
		//============================================================================*

		private void SetMinMax()
			{
			//----------------------------------------------------------------------------*
			// Set firearm specific Min/Max values
			//----------------------------------------------------------------------------*

			BarrelLengthTextBox.MinValue = cDataFiles.StandardToMetric(1.0, cDataFiles.eDataType.Firearm);
			BarrelLengthTextBox.MaxValue = cDataFiles.StandardToMetric(99.0, cDataFiles.eDataType.Firearm);

			TwistTextBox.MinValue = cDataFiles.StandardToMetric(5.0, cDataFiles.eDataType.Firearm);
			TwistTextBox.MaxValue = cDataFiles.StandardToMetric(78.0, cDataFiles.eDataType.Firearm);

			SightHeightTextBox.MinValue = 0.0;
			SightHeightTextBox.MaxValue = cDataFiles.StandardToMetric(10.0, cDataFiles.eDataType.Firearm);

			//----------------------------------------------------------------------------*
			// Set Range Min/Max values
			//----------------------------------------------------------------------------*

			ZeroRangeTextBox.MinValue = 0;
			ZeroRangeTextBox.MaxValue = 2000;

			//----------------------------------------------------------------------------*
			// Set Headspace and Neck Min/Max Values
			//----------------------------------------------------------------------------*

			HeadSpaceTextBox.MinValue = 0.0;
			HeadSpaceTextBox.MaxValue = 0.0;
			NeckTextBox.MinValue = 0.0;
			NeckTextBox.MaxValue = 0.0;

			if (m_Firearm.PrimaryCaliber != null)
				{
				HeadSpaceTextBox.MinValue = 0.0;
				HeadSpaceTextBox.MaxValue = cDataFiles.StandardToMetric(m_Firearm.PrimaryCaliber.MaxCaseLength, cDataFiles.eDataType.Dimension);

				NeckTextBox.MinValue = 0.0;

				if (m_Firearm.PrimaryCaliber.MaxNeckDiameter != 0.0)
					NeckTextBox.MaxValue = cDataFiles.StandardToMetric(m_Firearm.PrimaryCaliber.MaxNeckDiameter, cDataFiles.eDataType.Dimension);
				else
					NeckTextBox.MaxValue = 0.0;
				}
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

			SerialNumberTextBox.ToolTip = cm_strSerialNumberToolTip;
			DescriptionTextBox.ToolTip = cm_strDescriptionToolTip;

			m_CaliberListToolTip.ShowAlways = true;
			m_CaliberListToolTip.RemoveAll();
			m_CaliberListToolTip.SetToolTip(CaliberListBox, cm_strCaliberListToolTip);

			m_CaliberToolTip.ShowAlways = true;
			m_CaliberToolTip.RemoveAll();
			m_CaliberToolTip.SetToolTip(CaliberCombo, cm_strCaliberToolTip);

			BarrelLengthTextBox.ToolTip = cm_strBarrelLengthToolTip;
			TwistTextBox.ToolTip = cm_strTwistToolTip;
			ZeroRangeTextBox.ToolTip = cm_strZeroRangeToolTip;
			SightHeightTextBox.ToolTip = cm_strSightHeightToolTip;

			m_ScopedToolTip.ShowAlways = true;
			m_ScopedToolTip.RemoveAll();
			m_ScopedToolTip.SetToolTip(ScopedCheckBox, cm_strScopedToolTip);

			ScopeClickTextBox.ToolTip = cm_strScopeClickToolTip;

			m_TurretTypeToolTip.ShowAlways = true;
			m_TurretTypeToolTip.RemoveAll();
			m_TurretTypeToolTip.SetToolTip(TurretTypeComboBox, cm_strTurretTypeToolTip);

			HeadSpaceTextBox.ToolTip = cm_strHeadSpaceToolTip;
			NeckTextBox.ToolTip = cm_strNeckToolTip;

			m_BulletListToolTip.ShowAlways = true;
			m_BulletListToolTip.RemoveAll();
			m_BulletListToolTip.SetToolTip(m_BulletListView, cm_strBulletListToolTip);

			m_AddBulletButtonToolTip.ShowAlways = true;
			m_AddBulletButtonToolTip.RemoveAll();
			m_AddBulletButtonToolTip.SetToolTip(AddBulletButton, cm_strAddBulletButtonToolTip);

			m_EditBulletButtonToolTip.ShowAlways = true;
			m_EditBulletButtonToolTip.RemoveAll();
			m_EditBulletButtonToolTip.SetToolTip(EditBulletButton, cm_strEditBulletButtonToolTip);

			m_RemoveBulletButtonToolTip.ShowAlways = true;
			m_RemoveBulletButtonToolTip.RemoveAll();
			m_RemoveBulletButtonToolTip.SetToolTip(RemoveBulletButton, cm_strRemoveBulletButtonToolTip);

			m_FirearmOKButtonToolTip.ShowAlways = true;
			m_FirearmOKButtonToolTip.RemoveAll();
			m_FirearmOKButtonToolTip.SetToolTip(OKButton, cm_strFirearmOKButtonToolTip);

			m_FirearmCancelButtonToolTip.ShowAlways = true;
			m_FirearmCancelButtonToolTip.RemoveAll();
			m_FirearmCancelButtonToolTip.SetToolTip(FirearmCancelButton, cm_strFirearmCancelButtonToolTip);
			}

		//============================================================================*
		// UpdateBullet()
		//============================================================================*

		private void UpdateBullet(cFirearmBullet OldFirearmBullet, cFirearmBullet NewFirearmBullet)
			{
			if (m_fViewOnly)
				return;

			//----------------------------------------------------------------------------*
			// Find the Bullet Caliber
			//----------------------------------------------------------------------------*

			foreach (cFirearmBullet CheckFirearmBullet in m_Firearm.FirearmBulletList)
				{
				//----------------------------------------------------------------------------*
				// See if this is the same FirearmBullet
				//----------------------------------------------------------------------------*

				if (CheckFirearmBullet.Equals(OldFirearmBullet))
					{
					//----------------------------------------------------------------------------*
					// Update the current FirearmBullet record
					//----------------------------------------------------------------------------*

					CheckFirearmBullet.COL = NewFirearmBullet.COL;
					CheckFirearmBullet.CBTO = NewFirearmBullet.CBTO;

					//----------------------------------------------------------------------------*
					// Update the FirearmBullet on the FirearmBullet tab
					//----------------------------------------------------------------------------*

					ListViewItem Item = m_BulletListView.SelectedItems[0];

					if (Item != null)
						{
						try
							{
							m_BulletListView.Items.Remove(Item);
							}
						catch
							{
							}

						m_BulletListView.AddFirearmBullet(CheckFirearmBullet, true);
						}

					m_fChanged = true;

					return;
					}
				}

			//----------------------------------------------------------------------------*
			// If the Caliber was not found, add it
			//----------------------------------------------------------------------------*

			AddBullet(NewFirearmBullet);
			}

		//============================================================================*
		// UpdateButtons()
		//============================================================================*

		private void UpdateButtons()
			{
			if (m_fViewOnly)
				return;

			bool fEnableOK = m_fChanged;

			SetMinMax();

			//----------------------------------------------------------------------------*
			// Check Manufacturer
			//----------------------------------------------------------------------------*

			string strToolTip = cm_strManufacturerToolTip;

			if (ManufacturerCombo.SelectedIndex < 0)
				{
				fEnableOK = false;

				ManufacturerCombo.BackColor = Color.LightPink;

				strToolTip += "\n\nYou must select a manufacturer.";

				}
			else
				{
				ManufacturerCombo.BackColor = SystemColors.Window;
				}

			if (m_DataFiles.Preferences.ToolTips)
				m_ManufacturerToolTip.SetToolTip(ManufacturerCombo, strToolTip);

			//----------------------------------------------------------------------------*
			// Check Model
			//----------------------------------------------------------------------------*

			if (!ModelTextBox.ValueOK)
				fEnableOK = false;

			//----------------------------------------------------------------------------*
			// Check Serial Number
			//----------------------------------------------------------------------------*

			if (!SerialNumberTextBox.ValueOK)
				fEnableOK = false;

			//----------------------------------------------------------------------------*
			// Check Description
			//----------------------------------------------------------------------------*

			if (!DescriptionTextBox.ValueOK)
				fEnableOK = false;

			//----------------------------------------------------------------------------*
			// Check for duplicates
			//----------------------------------------------------------------------------*

			if (fEnableOK)
				{
				bool fDuplicate = false;

				foreach (cFirearm CheckFirearm in m_DataFiles.FirearmList)
					{
					if ((CheckFirearm.Manufacturer.Equals((cManufacturer) ManufacturerCombo.SelectedItem)) &&
						(CheckFirearm.FirearmType == (cFirearm.eFireArmType) FirearmTypeCombo.SelectedIndex) &&
						(CheckFirearm.PartNumber != m_Firearm.PartNumber && CheckFirearm.PartNumber.ToUpper() == ModelTextBox.Value.ToUpper()) &&
						(CheckFirearm.SerialNumber != m_Firearm.SerialNumber && CheckFirearm.SerialNumber.ToUpper() == SerialNumberTextBox.Value.ToUpper()))
						{
						fDuplicate = true;

						fEnableOK = false;

						ModelTextBox.BackColor = Color.LightPink;
						SerialNumberTextBox.BackColor = Color.LightPink;

						if (m_DataFiles.Preferences.ToolTips)
							{
							strToolTip = String.Format("{0}\n\nThis firearm already exists.  Duplicate firearms are not allowed.", cm_strModelToolTip);

							ModelTextBox.ToolTip = strToolTip;

							strToolTip = String.Format("{0}\n\nThis firearm already exists.  Duplicate firearms are not allowed.", cm_strSerialNumberToolTip);

							SerialNumberTextBox.ToolTip = strToolTip;
							}

						break;
						}
					}

				if (!fDuplicate)
					{
					ModelTextBox.BackColor = SystemColors.Window;
					SerialNumberTextBox.BackColor = SystemColors.Window;

					if (m_DataFiles.Preferences.ToolTips)
						{
						ModelTextBox.ToolTip = cm_strModelToolTip;

						SerialNumberTextBox.ToolTip = cm_strSerialNumberToolTip;
						}
					}
				}

			//----------------------------------------------------------------------------*
			// Check Barrel Length
			//----------------------------------------------------------------------------*

			strToolTip = cm_strBarrelLengthToolTip;

			if (!BarrelLengthTextBox.ValueOK)
				fEnableOK = false;

			//----------------------------------------------------------------------------*
			// Check Twist
			//----------------------------------------------------------------------------*

			if (m_Firearm.FirearmType == cFirearm.eFireArmType.Shotgun)
				TwistTextBox.MinValue = 0.0;

			if (!TwistTextBox.ValueOK)
				fEnableOK = false;

			//----------------------------------------------------------------------------*
			// Check Sight Height
			//----------------------------------------------------------------------------*

			if (!SightHeightTextBox.ValueOK)
				fEnableOK = false;

			//----------------------------------------------------------------------------*
			// Check Scope Data
			//----------------------------------------------------------------------------*

			if (ScopedCheckBox.Checked)
				ScopeClickTextBox.MinValue = 0.001;
			else
				{
				ScopeClickTextBox.Value = 0.0;
				ScopeClickTextBox.MinValue = 0.0;

				m_Firearm.ScopeClick = 0.0;
				}

			if (!ScopeClickTextBox.ValueOK)
				fEnableOK = false;

			//----------------------------------------------------------------------------*
			// Check HeadSpace
			//----------------------------------------------------------------------------*

			if (m_Firearm.FirearmType == cFirearm.eFireArmType.Shotgun)
				HeadSpaceTextBox.Enabled = false;
			else
				{
				if (!HeadSpaceTextBox.ValueOK)
					fEnableOK = false;
				}

			//----------------------------------------------------------------------------*
			// Check Neck
			//----------------------------------------------------------------------------*

			if (m_Firearm.FirearmType == cFirearm.eFireArmType.Shotgun)
				{
				NeckTextBox.Enabled = false;
				}
			else
				{
				if (!NeckTextBox.ValueOK)
					fEnableOK = false;
				}

			//----------------------------------------------------------------------------*
			// Check Zero Range
			//----------------------------------------------------------------------------*

			if (!ZeroRangeTextBox.ValueOK)
				fEnableOK = false;

			//----------------------------------------------------------------------------*
			// Add, Edit, MakePrimary Caliber Buttons
			//----------------------------------------------------------------------------*

			AddCartridgeButton.Enabled = CaliberCombo.SelectedIndex != 0;

			RemoveCartridgeButton.Enabled = (CaliberListBox.SelectedItems.Count > 0);

			cFirearmCaliber FirearmCaliber = null;
			
			if (CaliberListBox.SelectedItems.Count > 0)
				FirearmCaliber = (cFirearmCaliber) CaliberListBox.SelectedItem;

			MakePrimaryButton.Enabled = FirearmCaliber != null && !FirearmCaliber.Primary;

			//----------------------------------------------------------------------------*
			// Check Calibers
			//----------------------------------------------------------------------------*

			if (m_Firearm.CaliberList.Count == 0)
				{
				fEnableOK = false;

				CaliberListBox.BackColor = Color.LightPink;
				}
			else
				CaliberListBox.BackColor = SystemColors.Window;

			//----------------------------------------------------------------------------*
			// Set Buttons
			//----------------------------------------------------------------------------*

			OKButton.Enabled = fEnableOK;

			//----------------------------------------------------------------------------*
			// FirearmDetailButton
			//----------------------------------------------------------------------------*

			if (m_Firearm.Manufacturer != null && !String.IsNullOrEmpty(m_Firearm.PartNumber) && !String.IsNullOrEmpty(m_Firearm.SerialNumber))
				FirearmDetailsButton.Enabled = true;
			else
				FirearmDetailsButton.Enabled = false;

			//----------------------------------------------------------------------------*
			// Add, Edit, Remove Bullet Buttons
			//----------------------------------------------------------------------------*

			if (m_Firearm.FirearmType == cFirearm.eFireArmType.Shotgun)
				{
				AddBulletButton.Enabled = false;
				EditBulletButton.Enabled = false;
				RemoveBulletButton.Enabled = false;

				m_BulletListView.Enabled = false;
				}
			else
				{
				m_BulletListView.Enabled = true;

				bool fBulletsAvailable = false;

				foreach (cBullet CheckBullet in m_DataFiles.BulletList)
					{
					if ((!m_DataFiles.Preferences.HideUncheckedSupplies || CheckBullet.Checked) &&
						CheckBullet.FirearmType == m_Firearm.FirearmType &&
						FirearmCaliber != null && CheckBullet.HasCaliber(FirearmCaliber.Caliber))
						{
						bool fBulletInList = false;

						foreach (cFirearmBullet CheckFirearmBullet in m_Firearm.FirearmBulletList)
							{
							if (CheckBullet.CompareTo(CheckFirearmBullet.Bullet) == 0)
								{
								fBulletInList = true;

								break;
								}
							}

						if (!fBulletInList)
							{
							fBulletsAvailable = true;

							break;
							}
						}

					if (fBulletsAvailable)
						break;
					}

				strToolTip = cm_strSightHeightToolTip;

				if (fBulletsAvailable)
					{
					AddBulletButton.Enabled = true;
					}
				else
					{
					AddBulletButton.Enabled = false;

					strToolTip = "This button has been disabled because there are no more bullets available to select.";
					}

				if (m_DataFiles.Preferences.ToolTips)
					m_AddBulletButtonToolTip.SetToolTip(AddBulletButton, strToolTip);

				if (m_BulletListView.SelectedItems.Count > 0)
					{
					EditBulletButton.Enabled = true;
					RemoveBulletButton.Enabled = true;

					m_EditBulletButtonToolTip.SetToolTip(AddBulletButton, cm_strEditBulletButtonToolTip);
					m_RemoveBulletButtonToolTip.SetToolTip(AddBulletButton, cm_strRemoveBulletButtonToolTip);
					}
				else
					{
					EditBulletButton.Enabled = false;
					RemoveBulletButton.Enabled = false;

					strToolTip = "You must select a bullet from the list above that you wish to edit or remove.";

					if (m_DataFiles.Preferences.ToolTips)
						{
						m_EditBulletButtonToolTip.SetToolTip(AddBulletButton, strToolTip);
						m_RemoveBulletButtonToolTip.SetToolTip(AddBulletButton, strToolTip);
						}
					}
				}
			}
		}
	}
