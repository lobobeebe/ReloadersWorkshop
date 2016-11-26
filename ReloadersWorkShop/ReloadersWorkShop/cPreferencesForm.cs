//============================================================================*
// cPreferencesForm.cs
//
// Copyright © 2013-2014, Kevin S. Beebe
// All Rights Reserved
//============================================================================*

//============================================================================*
// .Net Using Statements
//============================================================================*

using System;
using System.Drawing;
using System.IO;
using System.Windows;
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
	// cFactoryAmmoForm Class
	//============================================================================*

	public partial class cPreferencesForm : Form
		{
		//----------------------------------------------------------------------------*
		// Private Constant Data Members
		//----------------------------------------------------------------------------*

		//----------------------------------------------------------------------------*
		// Private Data Members
		//----------------------------------------------------------------------------*

		private cMainForm m_MainForm = null;
		private cDataFiles m_DataFiles = null;

		private bool m_fInitialized = false;

		//============================================================================*
		// cFactoryAmmoForm() - Constructor
		//============================================================================*

		public cPreferencesForm(cMainForm MainForm, cDataFiles Datafiles)
			{
			InitializeComponent();

			m_DataFiles = Datafiles;
			m_MainForm = MainForm;

			SetClientSizeCore(InventoryGroupBox.Location.X + InventoryGroupBox.Width + 10, CloseButton.Location.Y + CloseButton.Height + 20);

			//----------------------------------------------------------------------------*
			// EventHandlers
			//----------------------------------------------------------------------------*

			AutoCheckCheckBox.Click += OnAutoCheckClicked;
			AutoCheckNonZeroCheckBox.Click += OnAutoCheckNonZeroClicked;
			ToolTipsCheckBox.Click += OnToolTipsClicked;

			StandardAltitudesRadioButton.Click += OnStandardAltitudesClicked;
			StandardBulletWeightsRadioButton.Click += OnStandardBulletWeightClicked;
			StandardDimensionsRadioButton.Click += OnStandardDimensionsClicked;
			StandardPowderWeightsRadioButton.Click += OnStandardPowderWeightsClicked;
			StandardCanWeightsRadioButton.Click += OnStandardCanClicked;
			StandardFirearmsRadioButton.Click += OnStandardFirearmsClicked;
			StandardRangesRadioButton.Click += OnStandardRangesClicked;
			StandardGroupsRadioButton.Click += OnStandardGroupsClicked;
			StandardPressuresRadioButton.Click += OnStandardPressuresClicked;
			StandardShotWeightsRadioButton.Click += OnStandardShotWeightsClicked;
			StandardTemperaturesRadioButton.Click += OnStandardTemperaturesClicked;
			StandardVelocitiesRadioButton.Click += OnStandardVelocitiesClicked;

			MetricAltitudesRadioButton.Click += OnMetricAltitudesClicked;
			MetricBulletWeightsRadioButton.Click += OnMetricBulletWeightClicked;
			MetricDimensionsRadioButton.Click += OnMetricDimensionsClicked;
			MetricPowderWeightsRadioButton.Click += OnMetricPowderWeightsClicked;
			MetricCanWeightsRadioButton.Click += OnMetricCanClicked;
			MetricFirearmsRadioButton.Click += OnMetricFirearmsClicked;
			MetricRangesRadioButton.Click += OnMetricRangesClicked;
			MetricGroupsRadioButton.Click += OnMetricGroupsClicked;
			MetricPressuresRadioButton.Click += OnMetricPressuresClicked;
			MetricShotWeightsRadioButton.Click += OnMetricShotWeightsClicked;
			MetricTemperaturesRadioButton.Click += OnMetricTemperaturesClicked;
			MetricVelocitiesRadioButton.Click += OnMetricVelocitiesClicked;

			BulletWeightOneDecimalRadioButton.Click += OnBulletWeightOneDecimalClicked;
			BulletWeightTwoDecimalsRadioButton.Click += OnBulletWeightTwoDecimalsClicked;

			CanWeightZeroDecimalsRadioButton.Click += OnCanWeightZeroDecimalsClicked;
			CanWeightOneDecimalRadioButton.Click += OnCanWeightOneDecimalClicked;
			CanWeightTwoDecimalsRadioButton.Click += OnCanWeightTwoDecimalsClicked;
			CanWeightThreeDecimalsRadioButton.Click += OnCanWeightThreeDecimalsClicked;

			DimensionOneDecimalRadioButton.Click += OnDimensionOneDecimalRadioButtonClicked;
			DimensionTwoDecimalsRadioButton.Click += OnDimensionTwoDecimalsRadioButtonClicked;
			DimensionThreeDecimalsRadioButton.Click += OnDimensionThreeDecimalsRadioButtonClicked;
			DimensionFourDecimalsRadioButton.Click += OnDimensionFourDecimalsRadioButtonClicked;

			FirearmZeroDecimalsRadioButton.Click += OnFirearmZeroDecimalsClicked;
			FirearmOneDecimalRadioButton.Click += OnFirearmOneDecimalClicked;
			FirearmTwoDecimalsRadioButton.Click += OnFirearmTwoDecimalsClicked;

			GroupOneDecimalRadioButton.Click += OnGroupOneDecimalClicked;
			GroupTwoDecimalsRadioButton.Click += OnGroupTwoDecimalsClicked;
			GroupThreeDecimalsRadioButton.Click += OnGroupThreeDecimalsClicked;

			PowderWeightOneDecimalRadioButton.Click += OnPowderWeightOneDecimalRadioButtonClicked;
			PowderWeightTwoDecimalsRadioButton.Click += OnPowderWeightTwoDecimalsRadioButtonClicked;
			PowderWeightThreeDecimalsRadioButton.Click += OnPowderWeightThreeDecimalsRadioButtonClicked;

			ShotWeightOneDecimalRadioButton.Click += OnShotWeightOneDecimalRadioButtonClicked;
			ShotWeightTwoDecimalsRadioButton.Click += OnShotWeightTwoDecimalsRadioButtonClicked;
			ShotWeightThreeDecimalsRadioButton.Click += OnShotWeightThreeDecimalsRadioButtonClicked;

			TrackInventoryCheckBox.Click += OnTrackInventoryClicked;
			TrackReloadsCheckBox.Click += OnTrackReloadsClicked;
			UseLastPurchaseRadioButton.Click += OnUseLastPurchaseClicked;
			AverageCostsRadioButton.Click += OnAverageCostsClicked;
			IncludeTaxShippingCheckBox.Click += OnIncludeTaxShippingClicked;

			TaxRateTextBox.TextChanged += OnTaxRateChanged;
			CurrencyTextBox.TextChanged += OnCurrencyChanged;

			AutoSaveTextBox.TextChanged += OnAutoSaveChanged;

			AutoBackupCheckBox.Click += OnAutoBackupClicked;
			BackupKeepDaysTextBox.TextChanged += OnBackupKeepDaysChanged;
			BackupFolderTextBox.TextChanged += OnBackupFolderChanged;
			BackupFolderButton.Click += OnBackupFolderClicked;
			BackupButton.Click += OnBackupNowClicked;
			RestoreBackupButton.Click += OnRestoreBackupClicked;

			//----------------------------------------------------------------------------*
			// Populate Preferences Data
			//----------------------------------------------------------------------------*

			PopulatePreferences();

			//----------------------------------------------------------------------------*
			// Update Buttons and exit
			//----------------------------------------------------------------------------*

			UpdateButtons();

			m_fInitialized = true;
			}

		//============================================================================*
		// OnAutoBackupClicked()
		//============================================================================*

		private void OnAutoBackupClicked(object sender, EventArgs args)
			{
			AutoBackupCheckBox.Checked = AutoBackupCheckBox.Checked ? false : true;

			m_DataFiles.Preferences.AutoBackup = AutoBackupCheckBox.Checked;
			}

		//============================================================================*
		// OnAutoCheckClicked()
		//============================================================================*

		private void OnAutoCheckClicked(object sender, EventArgs args)
			{
			AutoCheckCheckBox.Checked = AutoCheckCheckBox.Checked ? false : true;

			m_DataFiles.Preferences.AutoCheck = AutoCheckCheckBox.Checked;
			}

		//============================================================================*
		// OnAutoCheckNonZeroClicked()
		//============================================================================*

		private void OnAutoCheckNonZeroClicked(object sender, EventArgs args)
			{
			AutoCheckNonZeroCheckBox.Checked = !AutoCheckNonZeroCheckBox.Checked;

			m_DataFiles.Preferences.AutoCheckNonZero = AutoCheckNonZeroCheckBox.Checked;

			m_DataFiles.CheckNonZero();

			m_MainForm.InitializeSuppliesTab();
			m_MainForm.InitializeAmmoTab();

			UpdateButtons();
			}

		//============================================================================*
		// OnAutoSaveChanged()
		//============================================================================*

		protected void OnAutoSaveChanged(object sender, EventArgs args)
			{
			if (!m_fInitialized)
				return;

			if (AutoSaveTextBox.ValueOK)
				{
				m_DataFiles.Preferences.AutoSaveTime = AutoSaveTextBox.Value * 60000;

				m_MainForm.SetTimer();
				}

			UpdateButtons();
			}

		//============================================================================*
		// OnAverageCostsClicked()
		//============================================================================*

		protected void OnAverageCostsClicked(object sender, EventArgs args)
			{
			if (AverageCostsRadioButton.Checked)
				return;

			UseLastPurchaseRadioButton.Checked = false;

			m_DataFiles.Preferences.UseLastPurchase = false;

			m_MainForm.InitializeSuppliesTab();
			m_MainForm.InitializeAmmoTab();

			UpdateButtons();
			}

		//============================================================================*
		// OnBackupFolderClicked()
		//============================================================================*

		protected void OnBackupFolderClicked(object sender, EventArgs args)
			{
			FolderBrowserDialog FolderBrowser = new FolderBrowserDialog();

			FolderBrowser.Description = "Select Backup Folder";
			FolderBrowser.ShowNewFolderButton = true;

			if (m_DataFiles.Preferences.BackupFolder == null)
				m_DataFiles.Preferences.BackupFolder = @".\Backup";

			FolderBrowser.SelectedPath = System.IO.Path.GetFullPath(m_DataFiles.Preferences.BackupFolder);

			if (FolderBrowser.ShowDialog() == System.Windows.Forms.DialogResult.OK)
				{
				m_DataFiles.Preferences.BackupFolder = FolderBrowser.SelectedPath;

				BackupFolderTextBox.Text = m_DataFiles.Preferences.BackupFolder;
				}
			}

		//============================================================================*
		// OnBackupFolderChanged()
		//============================================================================*

		protected void OnBackupFolderChanged(object sender, EventArgs args)
			{
			if (!m_fInitialized)
				return;

			m_DataFiles.Preferences.BackupFolder = BackupFolderTextBox.Text;

			UpdateButtons();
			}

		//============================================================================*
		// OnBackupKeepDaysChanged()
		//============================================================================*

		protected void OnBackupKeepDaysChanged(object sender, EventArgs args)
			{
			if (!m_fInitialized)
				return;

			int nKeepDays = 0;

			Int32.TryParse(BackupKeepDaysTextBox.Text, out nKeepDays);

			m_DataFiles.Preferences.BackupKeepDays = nKeepDays;

			UpdateButtons();
			}

		//============================================================================*
		// OnBackupNowClicked()
		//============================================================================*

		protected void OnBackupNowClicked(object sender, EventArgs args)
			{
			m_MainForm.BackupData();
			}

		//============================================================================*
		// OnBulletWeightOneDecimalClicked()
		//============================================================================*

		protected void OnBulletWeightOneDecimalClicked(object sender, EventArgs args)
			{
			if (BulletWeightOneDecimalRadioButton.Checked)
				return;

			m_DataFiles.Preferences.BulletWeightDecimals = 1;

			SetDecimalData();
			}

		//============================================================================*
		// OnBulletWeightTwoDecimalsClicked()
		//============================================================================*

		protected void OnBulletWeightTwoDecimalsClicked(object sender, EventArgs args)
			{
			if (BulletWeightTwoDecimalsRadioButton.Checked)
				return;

			m_DataFiles.Preferences.BulletWeightDecimals = 2;

			SetDecimalData();
			}

		//============================================================================*
		// OnCanWeightOneDecimalClicked()
		//============================================================================*

		protected void OnCanWeightOneDecimalClicked(object sender, EventArgs args)
			{
			if (CanWeightOneDecimalRadioButton.Checked)
				return;

			m_DataFiles.Preferences.CanWeightDecimals = 1;

			SetDecimalData();
			}

		//============================================================================*
		// OnCanWeightThreeDecimalsClicked()
		//============================================================================*

		protected void OnCanWeightThreeDecimalsClicked(object sender, EventArgs args)
			{
			if (CanWeightThreeDecimalsRadioButton.Checked)
				return;

			m_DataFiles.Preferences.CanWeightDecimals = 3;

			SetDecimalData();
			}

		//============================================================================*
		// OnCanWeightTwoDecimalsClicked()
		//============================================================================*

		protected void OnCanWeightTwoDecimalsClicked(object sender, EventArgs args)
			{
			if (CanWeightTwoDecimalsRadioButton.Checked)
				return;

			m_DataFiles.Preferences.CanWeightDecimals = 2;

			SetDecimalData();
			}

		//============================================================================*
		// OnCanWeightZeroDecimalsClicked()
		//============================================================================*

		protected void OnCanWeightZeroDecimalsClicked(object sender, EventArgs args)
			{
			if (CanWeightZeroDecimalsRadioButton.Checked)
				return;

			m_DataFiles.Preferences.CanWeightDecimals = 0;

			SetDecimalData();
			}

		//============================================================================*
		// OnCurrencyChanged()
		//============================================================================*

		protected void OnCurrencyChanged(object sender, EventArgs args)
			{
			if (CurrencyTextBox.Text.Length < 1)
				{
				CurrencyTextBox.Text = "$";

				CurrencyTextBox.Select(0, 1);
				}

			m_DataFiles.Preferences.Currency = CurrencyTextBox.Text;

			m_MainForm.PopulateSuppliesListViewColumns(false);

			UpdateButtons();
			}

		//============================================================================*
		// OnDimensionFourDecimalsRadioButtonClicked()
		//============================================================================*

		protected void OnDimensionFourDecimalsRadioButtonClicked(object sender, EventArgs args)
			{
			if (DimensionFourDecimalsRadioButton.Checked)
				return;

			m_DataFiles.Preferences.DimensionDecimals = 4;

			SetDecimalData();
			}

		//============================================================================*
		// OnDimensionOneDecimalRadioButtonClicked()
		//============================================================================*

		protected void OnDimensionOneDecimalRadioButtonClicked(object sender, EventArgs args)
			{
			if (DimensionOneDecimalRadioButton.Checked)
				return;

			m_DataFiles.Preferences.DimensionDecimals = 1;

			SetDecimalData();
			}

		//============================================================================*
		// OnDimensionThreeDecimalsRadioButtonClicked()
		//============================================================================*

		protected void OnDimensionThreeDecimalsRadioButtonClicked(object sender, EventArgs args)
			{
			if (DimensionThreeDecimalsRadioButton.Checked)
				return;

			m_DataFiles.Preferences.DimensionDecimals = 3;

			SetDecimalData();
			}

		//============================================================================*
		// OnDimensionTwoDecimalsRadioButtonClicked()
		//============================================================================*

		protected void OnDimensionTwoDecimalsRadioButtonClicked(object sender, EventArgs args)
			{
			if (DimensionTwoDecimalsRadioButton.Checked)
				return;

			m_DataFiles.Preferences.DimensionDecimals = 2;

			SetDecimalData();
			}

		//============================================================================*
		// OnFirearmOneDecimalClicked()
		//============================================================================*

		protected void OnFirearmOneDecimalClicked(object sender, EventArgs args)
			{
			if (!FirearmOneDecimalRadioButton.Checked)
				m_DataFiles.Preferences.FirearmDecimals = 1;

			SetDecimalData();
			}

		//============================================================================*
		// OnFirearmTwoDecimalsClicked()
		//============================================================================*

		protected void OnFirearmTwoDecimalsClicked(object sender, EventArgs args)
			{
			if (!FirearmTwoDecimalsRadioButton.Checked)
				m_DataFiles.Preferences.FirearmDecimals = 2;

			SetDecimalData();
			}

		//============================================================================*
		// OnFirearmZeroDecimalsClicked()
		//============================================================================*

		protected void OnFirearmZeroDecimalsClicked(object sender, EventArgs args)
			{
			if (!FirearmZeroDecimalsRadioButton.Checked)
				m_DataFiles.Preferences.FirearmDecimals = 0;

			SetDecimalData();
			}

		//============================================================================*
		// OnGroupOneDecimalClicked()
		//============================================================================*

		protected void OnGroupOneDecimalClicked(object sender, EventArgs args)
			{
			if (GroupOneDecimalRadioButton.Checked)
				return;

			m_DataFiles.Preferences.GroupDecimals = 1;

			SetDecimalData();
			}

		//============================================================================*
		// OnGroupThreeDecimalsClicked()
		//============================================================================*

		protected void OnGroupThreeDecimalsClicked(object sender, EventArgs args)
			{
			if (GroupThreeDecimalsRadioButton.Checked)
				return;

			m_DataFiles.Preferences.GroupDecimals = 3;

			SetDecimalData();
			}

		//============================================================================*
		// OnGroupTwoDecimalsClicked()
		//============================================================================*

		protected void OnGroupTwoDecimalsClicked(object sender, EventArgs args)
			{
			if (GroupTwoDecimalsRadioButton.Checked)
				return;

			m_DataFiles.Preferences.GroupDecimals = 2;

			SetDecimalData();
			}

		//============================================================================*
		// OnIncludeTaxShippingClicked()
		//============================================================================*

		protected void OnIncludeTaxShippingClicked(object sender, EventArgs args)
			{
			IncludeTaxShippingCheckBox.Checked = IncludeTaxShippingCheckBox.Checked ? false : true;

			m_DataFiles.Preferences.IncludeTaxShipping = IncludeTaxShippingCheckBox.Checked;

			m_DataFiles.RecalculateInventory();

			m_MainForm.InitializeSuppliesTab();
			m_MainForm.InitializeAmmoTab();

			UpdateButtons();
			}

		//============================================================================*
		// OnMetricAltitudesClicked()
		//============================================================================*

		protected void OnMetricAltitudesClicked(object sender, EventArgs args)
			{
			if (MetricAltitudesRadioButton.Checked)
				return;

			StandardAltitudesRadioButton.Checked = false;
			MetricAltitudesRadioButton.Checked = true;

			m_DataFiles.Preferences.MetricAltitudes = true;

			m_MainForm.InitializeBallisticsTab();
			}

		//============================================================================*
		// OnMetricBulletWeightClicked()
		//============================================================================*

		protected void OnMetricBulletWeightClicked(object sender, EventArgs args)
			{
			if (MetricBulletWeightsRadioButton.Checked)
				return;

			StandardBulletWeightsRadioButton.Checked = false;
			MetricBulletWeightsRadioButton.Checked = true;

			m_DataFiles.Preferences.MetricBulletWeights = MetricBulletWeightsRadioButton.Checked;

			SetDecimalData();

			m_MainForm.InitializeAllTabs();
			}

		//============================================================================*
		// OnMetricCanClicked()
		//============================================================================*

		protected void OnMetricCanClicked(object sender, EventArgs args)
			{
			if (MetricCanWeightsRadioButton.Checked)
				return;

			StandardCanWeightsRadioButton.Checked = false;
			MetricCanWeightsRadioButton.Checked = true;

			m_DataFiles.Preferences.MetricCanWeights = true;

			SetDecimalData();
			}

		//============================================================================*
		// OnMetricDimensionsClicked()
		//============================================================================*

		protected void OnMetricDimensionsClicked(object sender, EventArgs args)
			{
			if (MetricDimensionsRadioButton.Checked)
				return;

			StandardDimensionsRadioButton.Checked = false;
			MetricDimensionsRadioButton.Checked = true;

			m_DataFiles.Preferences.MetricDimensions = true;

			SetDecimalData();
			}

		//============================================================================*
		// OnMetricFirearmsClicked()
		//============================================================================*

		protected void OnMetricFirearmsClicked(object sender, EventArgs args)
			{
			if (MetricFirearmsRadioButton.Checked)
				return;

			StandardFirearmsRadioButton.Checked = false;
			MetricFirearmsRadioButton.Checked = true;

			m_DataFiles.Preferences.MetricFirearms = true;

			SetDecimalData();
			}

		//============================================================================*
		// OnMetricGroupsClicked()
		//============================================================================*

		protected void OnMetricGroupsClicked(object sender, EventArgs args)
			{
			if (MetricGroupsRadioButton.Checked)
				return;

			StandardGroupsRadioButton.Checked = false;
			MetricGroupsRadioButton.Checked = true;

			m_DataFiles.Preferences.MetricGroups = true;

			SetDecimalData();
			}

		//============================================================================*
		// OnMetricPowderWeightsClicked()
		//============================================================================*

		protected void OnMetricPowderWeightsClicked(object sender, EventArgs args)
			{
			if (MetricPowderWeightsRadioButton.Checked)
				return;

			StandardPowderWeightsRadioButton.Checked = false;
			MetricPowderWeightsRadioButton.Checked = true;

			m_DataFiles.Preferences.MetricPowderWeights = true;

			SetDecimalData();
			}

		//============================================================================*
		// OnMetricPressuresClicked()
		//============================================================================*

		protected void OnMetricPressuresClicked(object sender, EventArgs args)
			{
			if (MetricPressuresRadioButton.Checked)
				return;

			StandardPressuresRadioButton.Checked = false;
			MetricPressuresRadioButton.Checked = true;

			m_DataFiles.Preferences.MetricPressures = true;

			m_MainForm.InitializeBallisticsTab();
			}

		//============================================================================*
		// OnMetricRangesClicked()
		//============================================================================*

		protected void OnMetricRangesClicked(object sender, EventArgs args)
			{
			if (MetricRangesRadioButton.Checked)
				return;

			StandardRangesRadioButton.Checked = false;
			MetricRangesRadioButton.Checked = true;

			m_DataFiles.Preferences.MetricRanges = true;

			SetDecimalData();
			}

		//============================================================================*
		// OnMetricShotWeightsClicked()
		//============================================================================*

		protected void OnMetricShotWeightsClicked(object sender, EventArgs args)
			{
			if (MetricShotWeightsRadioButton.Checked)
				return;

			StandardShotWeightsRadioButton.Checked = false;
			MetricShotWeightsRadioButton.Checked = true;

			m_DataFiles.Preferences.MetricShotWeights = true;

			SetDecimalData();
			}

		//============================================================================*
		// OnMetricTemperaturesClicked()
		//============================================================================*

		protected void OnMetricTemperaturesClicked(object sender, EventArgs args)
			{
			if (MetricTemperaturesRadioButton.Checked)
				return;

			StandardTemperaturesRadioButton.Checked = false;
			MetricTemperaturesRadioButton.Checked = true;

			m_DataFiles.Preferences.MetricTemperatures = true;

			m_MainForm.InitializeBallisticsTab();
			}

		//============================================================================*
		// OnMetricVelocitiesClicked()
		//============================================================================*

		protected void OnMetricVelocitiesClicked(object sender, EventArgs args)
			{
			if (MetricVelocitiesRadioButton.Checked)
				return;

			StandardVelocitiesRadioButton.Checked = false;
			MetricVelocitiesRadioButton.Checked = true;

			m_DataFiles.Preferences.MetricVelocities = true;

			SetDecimalData();
			}

		//============================================================================*
		// OnMetricWeightsClicked()
		//============================================================================*

		protected void OnMetricWeightsClicked(object sender, EventArgs args)
			{
			if (MetricPowderWeightsRadioButton.Checked)
				return;

			StandardPowderWeightsRadioButton.Checked = false;
			MetricPowderWeightsRadioButton.Checked = true;

			m_DataFiles.Preferences.MetricBulletWeights = true;

			SetDecimalData();
			}

		//============================================================================*
		// OnPowderWeightOneDecimalRadioButtonClicked()
		//============================================================================*

		protected void OnPowderWeightOneDecimalRadioButtonClicked(object sender, EventArgs args)
			{
			if (!PowderWeightOneDecimalRadioButton.Checked)
				m_DataFiles.Preferences.PowderWeightDecimals = 1;

			SetDecimalData();
			}

		//============================================================================*
		// OnPowderWeightThreeDecimalsRadioButtonClicked()
		//============================================================================*

		protected void OnPowderWeightThreeDecimalsRadioButtonClicked(object sender, EventArgs args)
			{
			if (!PowderWeightThreeDecimalsRadioButton.Checked)
				m_DataFiles.Preferences.PowderWeightDecimals = 3;

			SetDecimalData();
			}

		//============================================================================*
		// OnPowderWeightTwoDecimalsRadioButtonClicked()
		//============================================================================*

		protected void OnPowderWeightTwoDecimalsRadioButtonClicked(object sender, EventArgs args)
			{
			if (!PowderWeightTwoDecimalsRadioButton.Checked)
				m_DataFiles.Preferences.PowderWeightDecimals = 2;

			SetDecimalData();
			}

		//============================================================================*
		// OnRestoreBackupClicked()
		//============================================================================*

		protected void OnRestoreBackupClicked(object sender, EventArgs args)
			{
			m_MainForm.RestoreBackup();
			}

		//============================================================================*
		// OnShotWeightOneDecimalRadioButtonClicked()
		//============================================================================*

		protected void OnShotWeightOneDecimalRadioButtonClicked(object sender, EventArgs args)
			{
			if (!ShotWeightOneDecimalRadioButton.Checked)
				m_DataFiles.Preferences.ShotWeightDecimals = 1;

			SetDecimalData();
			}

		//============================================================================*
		// OnShotWeightThreeDecimalsRadioButtonClicked()
		//============================================================================*

		protected void OnShotWeightThreeDecimalsRadioButtonClicked(object sender, EventArgs args)
			{
			if (!ShotWeightThreeDecimalsRadioButton.Checked)
				m_DataFiles.Preferences.ShotWeightDecimals = 3;

			SetDecimalData();
			}

		//============================================================================*
		// OnShotWeightTwoDecimalsRadioButtonClicked()
		//============================================================================*

		protected void OnShotWeightTwoDecimalsRadioButtonClicked(object sender, EventArgs args)
			{
			if (!ShotWeightTwoDecimalsRadioButton.Checked)
				m_DataFiles.Preferences.ShotWeightDecimals = 2;

			SetDecimalData();
			}

		//============================================================================*
		// OnStandardAltitudesClicked()
		//============================================================================*

		protected void OnStandardAltitudesClicked(object sender, EventArgs args)
			{
			if (StandardAltitudesRadioButton.Checked)
				return;

			StandardAltitudesRadioButton.Checked = true;
			MetricAltitudesRadioButton.Checked = false;

			m_DataFiles.Preferences.MetricAltitudes = false;

			m_MainForm.InitializeBallisticsTab();
			}

		//============================================================================*
		// OnStandardBulletWeightClicked()
		//============================================================================*

		protected void OnStandardBulletWeightClicked(object sender, EventArgs args)
			{
			if (StandardBulletWeightsRadioButton.Checked)
				return;

			StandardBulletWeightsRadioButton.Checked = true;
			MetricBulletWeightsRadioButton.Checked = false;

			m_DataFiles.Preferences.MetricBulletWeights = MetricBulletWeightsRadioButton.Checked;

			SetDecimalData();

			m_MainForm.InitializeAllTabs();
			}

		//============================================================================*
		// OnStandardCanClicked()
		//============================================================================*

		protected void OnStandardCanClicked(object sender, EventArgs args)
			{
			if (StandardCanWeightsRadioButton.Checked)
				return;

			StandardCanWeightsRadioButton.Checked = true;
			MetricCanWeightsRadioButton.Checked = false;

			m_DataFiles.Preferences.MetricCanWeights = false;

			SetDecimalData();
			}

		//============================================================================*
		// OnStandardDimensionsClicked()
		//============================================================================*

		protected void OnStandardDimensionsClicked(object sender, EventArgs args)
			{
			if (StandardDimensionsRadioButton.Checked)
				return;

			StandardDimensionsRadioButton.Checked = true;
			MetricDimensionsRadioButton.Checked = false;

			m_DataFiles.Preferences.MetricDimensions = false;

			SetDecimalData();
			}

		//============================================================================*
		// OnStandardFirearmsClicked()
		//============================================================================*

		protected void OnStandardFirearmsClicked(object sender, EventArgs args)
			{
			if (StandardFirearmsRadioButton.Checked)
				return;

			StandardFirearmsRadioButton.Checked = true;
			MetricFirearmsRadioButton.Checked = false;

			m_DataFiles.Preferences.MetricFirearms = false;

			SetDecimalData();
			}

		//============================================================================*
		// OnStandardGroupsClicked()
		//============================================================================*

		protected void OnStandardGroupsClicked(object sender, EventArgs args)
			{
			if (StandardGroupsRadioButton.Checked)
				return;

			StandardGroupsRadioButton.Checked = true;
			MetricGroupsRadioButton.Checked = false;

			m_DataFiles.Preferences.MetricGroups = false;

			SetDecimalData();
			}

		//============================================================================*
		// OnStandardPowderWeightsClicked()
		//============================================================================*

		protected void OnStandardPowderWeightsClicked(object sender, EventArgs args)
			{
			if (StandardPowderWeightsRadioButton.Checked)
				return;

			StandardPowderWeightsRadioButton.Checked = true;
			MetricPowderWeightsRadioButton.Checked = false;

			m_DataFiles.Preferences.MetricPowderWeights = false;

			SetDecimalData();
			}

		//============================================================================*
		// OnStandardPressuresClicked()
		//============================================================================*

		protected void OnStandardPressuresClicked(object sender, EventArgs args)
			{
			if (StandardPressuresRadioButton.Checked)
				return;

			StandardPressuresRadioButton.Checked = true;
			MetricPressuresRadioButton.Checked = false;

			m_DataFiles.Preferences.MetricPressures = false;

			m_MainForm.InitializeBallisticsTab();
			}

		//============================================================================*
		// OnStandardRangesClicked()
		//============================================================================*

		protected void OnStandardRangesClicked(object sender, EventArgs args)
			{
			if (StandardRangesRadioButton.Checked)
				return;

			StandardRangesRadioButton.Checked = true;
			MetricRangesRadioButton.Checked = false;

			m_DataFiles.Preferences.MetricRanges = false;

			SetDecimalData();
			}

		//============================================================================*
		// OnStandardShotWeightsClicked()
		//============================================================================*

		protected void OnStandardShotWeightsClicked(object sender, EventArgs args)
			{
			if (StandardShotWeightsRadioButton.Checked)
				return;

			StandardShotWeightsRadioButton.Checked = true;
			MetricShotWeightsRadioButton.Checked = false;

			m_DataFiles.Preferences.MetricShotWeights = false;

			SetDecimalData();
			}

		//============================================================================*
		// OnStandardTemperaturesClicked()
		//============================================================================*

		protected void OnStandardTemperaturesClicked(object sender, EventArgs args)
			{
			if (StandardTemperaturesRadioButton.Checked)
				return;

			StandardTemperaturesRadioButton.Checked = true;
			MetricTemperaturesRadioButton.Checked = false;

			m_DataFiles.Preferences.MetricTemperatures = false;

			m_MainForm.InitializeBallisticsTab();
			}

		//============================================================================*
		// OnStandardVelocitiesClicked()
		//============================================================================*

		protected void OnStandardVelocitiesClicked(object sender, EventArgs args)
			{
			if (StandardVelocitiesRadioButton.Checked)
				return;

			StandardVelocitiesRadioButton.Checked = true;
			MetricVelocitiesRadioButton.Checked = false;

			m_DataFiles.Preferences.MetricVelocities = false;

			SetDecimalData();
			}

		//============================================================================*
		// OnTaxRateChanged()
		//============================================================================*

		protected void OnTaxRateChanged(object sender, EventArgs args)
			{
			m_DataFiles.Preferences.TaxRate = TaxRateTextBox.Value;

			UpdateButtons();
			}

		//============================================================================*
		// OnToolTipsClicked()
		//============================================================================*

		protected void OnToolTipsClicked(object sender, EventArgs args)
			{
			ToolTipsCheckBox.Checked = ToolTipsCheckBox.Checked ? false : true;

			m_DataFiles.Preferences.ToolTips = ToolTipsCheckBox.Checked;

			UpdateButtons();
			}

		//============================================================================*
		// OnTrackInventoryClicked()
		//============================================================================*

		protected void OnTrackInventoryClicked(object sender, EventArgs args)
			{
			if (TrackInventoryCheckBox.Checked)
				{
				int nCount = m_DataFiles.ActivityCount;

				if (nCount > 0)
					{
					string strText = String.Format("WARNING: There {0} been {1:G0} activity entr{2} applied to your inventory.\n\n", (nCount != 1 ? "have" : "has"), nCount, (nCount != 1 ? "ies" : "y"));

					strText += String.Format("Turning Inventory Tracking off will result in the deletion of th{0} entr{1}.\n\nAre you sure you want to turn Inventory Tracking off?", (nCount != 1 ? "ese" : "is"), (nCount != 1 ? "ies" : "y"));

					DialogResult rc = MessageBox.Show(strText,
														"Data Deletion Warning",
														MessageBoxButtons.YesNo,
														MessageBoxIcon.Warning,
														MessageBoxDefaultButton.Button2);

					if (rc == DialogResult.No)
						return;
					}

				//----------------------------------------------------------------------------*
				// Remove all transactions and ammo created by the inventory system
				//----------------------------------------------------------------------------*

				m_DataFiles.ResetTransactions();

				while (true)
					{
					bool fRemoved = false;

					foreach (cAmmo Ammo in m_DataFiles.AmmoList)
						{
						if (Ammo.BatchID != 0)
							{
							m_DataFiles.AmmoList.Remove(Ammo);

							fRemoved = true;

							break;
							}
						}

					if (!fRemoved)
						break;
					}

				//----------------------------------------------------------------------------*
				// Remove the TrackInventory flag from all current batches
				//----------------------------------------------------------------------------*

				foreach (cBatch Batch in m_DataFiles.BatchList)
					Batch.TrackInventory = false;

				//----------------------------------------------------------------------------*
				// Reset Transaction Form Preferences
				//----------------------------------------------------------------------------*

				m_DataFiles.Preferences.LastTransaction = null;
				m_DataFiles.Preferences.LastAddStockReason = "";
				m_DataFiles.Preferences.LastActivity = cTransaction.eTransactionType.SetStockLevel;
				m_DataFiles.Preferences.LastFiredLocation = "";
				m_DataFiles.Preferences.LastPurchaseSource = "";
				m_DataFiles.Preferences.LastReduceStockReason = "";
				m_DataFiles.Preferences.LastTransactionSelected = null;

				m_DataFiles.Save();
				}
			else
				{
				string strMessage = "WARNING: Turning Inventory Tracking on will dramatically change the way Reloader's WorkShop operates.  You may want to view the Reloader's WorkShop Tutorial on Inventory Control before turning it on.";

				if (m_DataFiles.BatchList.Count > 0)
					{
					strMessage += String.Format("\n\nNOTE: You currently have {0:G0} batch{1} in your database.  ", m_DataFiles.BatchList.Count, (m_DataFiles.BatchList.Count != 1 ? "es" : ""));

					strMessage += String.Format("Th{0} batch{1} will not be tracked in inventory.  ", (m_DataFiles.BatchList.Count != 1 ? "ese" : "is"), (m_DataFiles.BatchList.Count != 1 ? "es" : ""));

					strMessage += "Only batches entered from this point forward will increase or decrease costs and on-hand quantities of supplies and reloaded ammo.";
					}

				strMessage += "\n\nAre you sure you want to turn Inventory Tracking on?";

				DialogResult rc = MessageBox.Show(strMessage, "Application Change Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

				if (rc == DialogResult.No)
					return;
				}

			TrackInventoryCheckBox.Checked = TrackInventoryCheckBox.Checked ? false : true;

			m_DataFiles.Preferences.TrackInventory = TrackInventoryCheckBox.Checked;

			m_MainForm.InitializeAllTabs();

			UpdateButtons();
			}

		//============================================================================*
		// OnTrackReloadsClicked()
		//============================================================================*

		protected void OnTrackReloadsClicked(object sender, EventArgs args)
			{
			TrackReloadsCheckBox.Checked = TrackReloadsCheckBox.Checked ? false : true;

			m_DataFiles.Preferences.TrackReloads = TrackReloadsCheckBox.Checked;

			m_MainForm.PopulateAmmoListView();

			UpdateButtons();
			}

		//============================================================================*
		// OnUseLastPurchaseClicked()
		//============================================================================*

		protected void OnUseLastPurchaseClicked(object sender, EventArgs args)
			{
			UseLastPurchaseRadioButton.Checked = UseLastPurchaseRadioButton.Checked ? false : true;
			AverageCostsRadioButton.Checked = UseLastPurchaseRadioButton.Checked ? false : true;

			m_DataFiles.Preferences.UseLastPurchase = UseLastPurchaseRadioButton.Checked;

			m_MainForm.InitializeSuppliesTab();
			m_MainForm.InitializeAmmoTab();

			UpdateButtons();
			}

		//============================================================================*
		// PopulateBackupGroup()
		//============================================================================*

		private void PopulateBackupGroup()
			{
			if (m_DataFiles.Preferences.AutoSaveTime < 300000)
				m_DataFiles.Preferences.AutoSaveTime = 300000;

			AutoSaveTextBox.Text = String.Format("{0:G0}", m_DataFiles.Preferences.AutoSaveTime / 60000);

			AutoBackupCheckBox.Checked = m_DataFiles.Preferences.AutoBackup;

			BackupKeepDaysTextBox.Text = String.Format("{0:G0}", m_DataFiles.Preferences.BackupKeepDays);

			if (m_DataFiles.Preferences.BackupFolder == null)
				m_DataFiles.Preferences.BackupFolder = Environment.SystemDirectory;

			BackupFolderTextBox.Text = System.IO.Path.GetFullPath(m_DataFiles.Preferences.BackupFolder);

			PopulateDataEntryDecimals();
			}

		//============================================================================*
		// PopulateDataEntryGroup()
		//============================================================================*

		private void PopulateDataEntryGroup()
			{
			AutoCheckCheckBox.Checked = m_DataFiles.Preferences.AutoCheck;
			AutoCheckNonZeroCheckBox.Checked = m_DataFiles.Preferences.AutoCheckNonZero;

			ToolTipsCheckBox.Checked = m_DataFiles.Preferences.ToolTips;

			StandardAltitudesRadioButton.Checked = !m_DataFiles.Preferences.MetricAltitudes;
			MetricAltitudesRadioButton.Checked = !StandardAltitudesRadioButton.Checked;

			StandardBulletWeightsRadioButton.Checked = !m_DataFiles.Preferences.MetricBulletWeights;
			MetricBulletWeightsRadioButton.Checked = !StandardBulletWeightsRadioButton.Checked;

			StandardCanWeightsRadioButton.Checked = !m_DataFiles.Preferences.MetricCanWeights;
			MetricCanWeightsRadioButton.Checked = !StandardCanWeightsRadioButton.Checked;

			StandardDimensionsRadioButton.Checked = !m_DataFiles.Preferences.MetricDimensions;
			MetricDimensionsRadioButton.Checked = !StandardDimensionsRadioButton.Checked;

			StandardFirearmsRadioButton.Checked = !m_DataFiles.Preferences.MetricFirearms;
			MetricFirearmsRadioButton.Checked = !StandardFirearmsRadioButton.Checked;

			StandardGroupsRadioButton.Checked = !m_DataFiles.Preferences.MetricGroups;
			MetricGroupsRadioButton.Checked = !StandardGroupsRadioButton.Checked;

			StandardPowderWeightsRadioButton.Checked = !m_DataFiles.Preferences.MetricPowderWeights;
			MetricPowderWeightsRadioButton.Checked = !StandardPowderWeightsRadioButton.Checked;

			StandardPressuresRadioButton.Checked = !m_DataFiles.Preferences.MetricPressures;
			MetricPressuresRadioButton.Checked = !StandardPressuresRadioButton.Checked;

			StandardRangesRadioButton.Checked = !m_DataFiles.Preferences.MetricRanges;
			MetricRangesRadioButton.Checked = !StandardRangesRadioButton.Checked;

			StandardShotWeightsRadioButton.Checked = !m_DataFiles.Preferences.MetricShotWeights;
			MetricShotWeightsRadioButton.Checked = !StandardShotWeightsRadioButton.Checked;

			StandardTemperaturesRadioButton.Checked = !m_DataFiles.Preferences.MetricTemperatures;
			MetricTemperaturesRadioButton.Checked = !StandardTemperaturesRadioButton.Checked;

			StandardVelocitiesRadioButton.Checked = !m_DataFiles.Preferences.MetricVelocities;
			MetricVelocitiesRadioButton.Checked = !StandardVelocitiesRadioButton.Checked;
			}

		//============================================================================*
		// PopulateDataEntryDecimals()
		//============================================================================*

		private void PopulateDataEntryDecimals()
			{
			//----------------------------------------------------------------------------*
			// Limit Metric and Standard Diameter Selections
			//----------------------------------------------------------------------------*

			if (m_DataFiles.Preferences.MetricDimensions)
				{
				DimensionOneDecimalRadioButton.Enabled = true;
				DimensionTwoDecimalsRadioButton.Enabled = true;
				DimensionThreeDecimalsRadioButton.Enabled = false;
				DimensionFourDecimalsRadioButton.Enabled = false;

				if (m_DataFiles.Preferences.DimensionDecimals > 2)
					m_DataFiles.Preferences.DimensionDecimals = 2;
				}
			else
				{
				DimensionOneDecimalRadioButton.Enabled = false;
				DimensionTwoDecimalsRadioButton.Enabled = false;
				DimensionThreeDecimalsRadioButton.Enabled = true;
				DimensionFourDecimalsRadioButton.Enabled = true;

				if (m_DataFiles.Preferences.DimensionDecimals < 3)
					m_DataFiles.Preferences.DimensionDecimals = 3;
				}

			//----------------------------------------------------------------------------*
			// Diameter Decimals
			//----------------------------------------------------------------------------*

			switch (m_DataFiles.Preferences.DimensionDecimals)
				{
				case 1:
					DimensionOneDecimalRadioButton.Checked = true;
					DimensionTwoDecimalsRadioButton.Checked = false;
					DimensionThreeDecimalsRadioButton.Checked = false;
					DimensionFourDecimalsRadioButton.Checked = false;

					break;

				case 2:
					DimensionOneDecimalRadioButton.Checked = false;
					DimensionTwoDecimalsRadioButton.Checked = true;
					DimensionThreeDecimalsRadioButton.Checked = false;
					DimensionFourDecimalsRadioButton.Checked = false;

					break;

				case 3:
					DimensionOneDecimalRadioButton.Checked = false;
					DimensionTwoDecimalsRadioButton.Checked = false;
					DimensionThreeDecimalsRadioButton.Checked = true;
					DimensionFourDecimalsRadioButton.Checked = false;

					break;

				case 4:
					DimensionOneDecimalRadioButton.Checked = false;
					DimensionTwoDecimalsRadioButton.Checked = false;
					DimensionThreeDecimalsRadioButton.Checked = false;
					DimensionFourDecimalsRadioButton.Checked = true;

					break;

				default:
					if (m_DataFiles.Preferences.MetricDimensions)
						{
						m_DataFiles.Preferences.DimensionDecimals = 2;

						DimensionOneDecimalRadioButton.Checked = false;
						DimensionTwoDecimalsRadioButton.Checked = true;
						DimensionThreeDecimalsRadioButton.Checked = false;
						DimensionFourDecimalsRadioButton.Checked = false;
						}
					else
						{
						m_DataFiles.Preferences.DimensionDecimals = 3;

						DimensionOneDecimalRadioButton.Checked = false;
						DimensionTwoDecimalsRadioButton.Checked = false;
						DimensionThreeDecimalsRadioButton.Checked = true;
						DimensionFourDecimalsRadioButton.Checked = false;
						}

					break;
				}

			//----------------------------------------------------------------------------*
			// Bullet Weight Decimals
			//----------------------------------------------------------------------------*

			switch (m_DataFiles.Preferences.BulletWeightDecimals)
				{
				case 2:
					BulletWeightOneDecimalRadioButton.Checked = false;
					BulletWeightTwoDecimalsRadioButton.Checked = true;

					break;

				default:
					m_DataFiles.Preferences.BulletWeightDecimals = 1;

					BulletWeightOneDecimalRadioButton.Checked = true;
					BulletWeightTwoDecimalsRadioButton.Checked = false;

					break;
				}

			//----------------------------------------------------------------------------*
			// Powder Weight Decimals
			//----------------------------------------------------------------------------*

			switch (m_DataFiles.Preferences.PowderWeightDecimals)
				{
				case 2:
					PowderWeightOneDecimalRadioButton.Checked = false;
					PowderWeightTwoDecimalsRadioButton.Checked = true;
					PowderWeightThreeDecimalsRadioButton.Checked = false;

					break;

				case 3:
					PowderWeightOneDecimalRadioButton.Checked = false;
					PowderWeightTwoDecimalsRadioButton.Checked = false;
					PowderWeightThreeDecimalsRadioButton.Checked = true;

					break;

				default:
					m_DataFiles.Preferences.PowderWeightDecimals = 1;

					PowderWeightOneDecimalRadioButton.Checked = true;
					PowderWeightTwoDecimalsRadioButton.Checked = false;
					PowderWeightThreeDecimalsRadioButton.Checked = false;

					break;
				}

			//----------------------------------------------------------------------------*
			// Can Weight Decimals
			//----------------------------------------------------------------------------*

			switch (m_DataFiles.Preferences.CanWeightDecimals)
				{
				case 1:
					CanWeightZeroDecimalsRadioButton.Checked = false;
					CanWeightOneDecimalRadioButton.Checked = true;
					CanWeightTwoDecimalsRadioButton.Checked = false;
					CanWeightThreeDecimalsRadioButton.Checked = false;

					break;

				case 2:
					CanWeightZeroDecimalsRadioButton.Checked = false;
					CanWeightOneDecimalRadioButton.Checked = false;
					CanWeightTwoDecimalsRadioButton.Checked = true;
					CanWeightThreeDecimalsRadioButton.Checked = false;

					break;

				case 3:
					CanWeightZeroDecimalsRadioButton.Checked = false;
					CanWeightOneDecimalRadioButton.Checked = false;
					CanWeightTwoDecimalsRadioButton.Checked = false;
					CanWeightThreeDecimalsRadioButton.Checked = true;

					break;

				default:
					m_DataFiles.Preferences.CanWeightDecimals = 0;

					CanWeightZeroDecimalsRadioButton.Checked = true;
					CanWeightOneDecimalRadioButton.Checked = false;
					CanWeightTwoDecimalsRadioButton.Checked = false;
					CanWeightThreeDecimalsRadioButton.Checked = false;

					break;
				}

			//----------------------------------------------------------------------------*
			// Shot Weight Decimals
			//----------------------------------------------------------------------------*

			switch (m_DataFiles.Preferences.ShotWeightDecimals)
				{
				case 2:
					ShotWeightOneDecimalRadioButton.Checked = false;
					ShotWeightTwoDecimalsRadioButton.Checked = true;
					ShotWeightThreeDecimalsRadioButton.Checked = false;

					break;

				case 3:
					ShotWeightOneDecimalRadioButton.Checked = false;
					ShotWeightTwoDecimalsRadioButton.Checked = false;
					ShotWeightThreeDecimalsRadioButton.Checked = true;

					break;

				default:
					m_DataFiles.Preferences.ShotWeightDecimals = 1;

					ShotWeightOneDecimalRadioButton.Checked = true;
					ShotWeightTwoDecimalsRadioButton.Checked = false;
					ShotWeightThreeDecimalsRadioButton.Checked = false;

					break;
				}

			//----------------------------------------------------------------------------*
			// Firearm Decimals
			//----------------------------------------------------------------------------*

			switch (m_DataFiles.Preferences.FirearmDecimals)
				{
				case 1:
					FirearmZeroDecimalsRadioButton.Checked = false;
					FirearmOneDecimalRadioButton.Checked = true;
					FirearmTwoDecimalsRadioButton.Checked = false;

					break;

				case 2:
					FirearmZeroDecimalsRadioButton.Checked = false;
					FirearmOneDecimalRadioButton.Checked = false;
					FirearmTwoDecimalsRadioButton.Checked = true;

					break;

				default:
					m_DataFiles.Preferences.FirearmDecimals = 0;

					FirearmZeroDecimalsRadioButton.Checked = true;
					FirearmOneDecimalRadioButton.Checked = false;
					FirearmTwoDecimalsRadioButton.Checked = false;

					break;
				}

			//----------------------------------------------------------------------------*
			// Group Decimals
			//----------------------------------------------------------------------------*

			switch (m_DataFiles.Preferences.GroupDecimals)
				{
				case 2:
					GroupOneDecimalRadioButton.Checked = false;
					GroupTwoDecimalsRadioButton.Checked = true;
					GroupThreeDecimalsRadioButton.Checked = false;

					break;

				case 3:
					GroupOneDecimalRadioButton.Checked = false;
					GroupTwoDecimalsRadioButton.Checked = false;
					GroupThreeDecimalsRadioButton.Checked = true;

					break;

				default:
					m_DataFiles.Preferences.GroupDecimals = 1;

					GroupOneDecimalRadioButton.Checked = true;
					GroupTwoDecimalsRadioButton.Checked = false;
					GroupThreeDecimalsRadioButton.Checked = false;

					break;
				}
			}

		//============================================================================*
		// PopulateInventoryGroup()
		//============================================================================*

		private void PopulateInventoryGroup()
			{
			TrackInventoryCheckBox.Checked = m_DataFiles.Preferences.TrackInventory;

			UseLastPurchaseRadioButton.Checked = m_DataFiles.Preferences.UseLastPurchase;
			AverageCostsRadioButton.Checked = !m_DataFiles.Preferences.UseLastPurchase;
			IncludeTaxShippingCheckBox.Checked = m_DataFiles.Preferences.IncludeTaxShipping;

			TaxRateTextBox.Value = m_DataFiles.Preferences.TaxRate;

			CurrencyTextBox.Text = m_DataFiles.Preferences.Currency;
			}

		//============================================================================*
		// PopulatePreferences()
		//============================================================================*

		private void PopulatePreferences()
			{
			PopulateDataEntryGroup();

			PopulateInventoryGroup();

			PopulateBackupGroup();

			UpdateButtons();
			}

		//============================================================================*
		// SetDecimalData()
		//============================================================================*

		private void SetDecimalData()
			{
			PopulateDataEntryDecimals();

			m_MainForm.InitializeAllTabs();
			}

		//============================================================================*
		// SetStaticToolTips()
		//============================================================================*

		private void SetStaticToolTips()
			{
			if (!m_DataFiles.Preferences.ToolTips)
				return;
			}

		//============================================================================*
		// UpdateButtons()
		//============================================================================*

		private void UpdateButtons()
			{
			//----------------------------------------------------------------------------*
			// Track Inventory Radio Button
			//----------------------------------------------------------------------------*

			if (TrackInventoryCheckBox.Checked)
				{
				TrackReloadsCheckBox.Checked = m_DataFiles.Preferences.TrackReloads;
				TrackReloadsCheckBox.Enabled = true;

				UseLastPurchaseRadioButton.Checked = m_DataFiles.Preferences.UseLastPurchase;
				UseLastPurchaseRadioButton.Enabled = true;

				AverageCostsRadioButton.Checked = m_DataFiles.Preferences.AverageCosts;
				AverageCostsRadioButton.Enabled = true;

				IncludeTaxShippingCheckBox.Checked = m_DataFiles.Preferences.IncludeTaxShipping;
				IncludeTaxShippingCheckBox.Enabled = true;

				CostCalculationsLabel.Enabled = true;
				}
			else
				{
				TrackReloadsCheckBox.Checked = false;
				TrackReloadsCheckBox.Enabled = false;

				UseLastPurchaseRadioButton.Checked = false;
				UseLastPurchaseRadioButton.Enabled = false;

				AverageCostsRadioButton.Checked = false;
				AverageCostsRadioButton.Enabled = false;

				IncludeTaxShippingCheckBox.Checked = false;
				IncludeTaxShippingCheckBox.Enabled = false;

				CostCalculationsLabel.Enabled = false;
				}

			//----------------------------------------------------------------------------*
			// Check Inventory Info
			//----------------------------------------------------------------------------*

			if (CurrencyTextBox.Text.Length < 1)
				{
				if (m_DataFiles.Preferences.Currency == null || m_DataFiles.Preferences.Currency.Length < 1)
					m_DataFiles.Preferences.Currency = "$";

				CurrencyTextBox.Text = m_DataFiles.Preferences.Currency;
				}

			//----------------------------------------------------------------------------*
			// Check Backup Info
			//----------------------------------------------------------------------------*

			m_DataFiles.Preferences.BackupOK = true;

			//----------------------------------------------------------------------------*
			// Backup Folder
			//----------------------------------------------------------------------------*

			if (!VerifyFolder(m_DataFiles.Preferences.BackupFolder))
				{
				BackupFolderTextBox.BackColor = Color.LightPink;

				m_DataFiles.Preferences.BackupOK = false;
				}
			else
				{
				BackupFolderTextBox.BackColor = SystemColors.Window;
				}

			//----------------------------------------------------------------------------*
			// Backup KeepDays
			//----------------------------------------------------------------------------*

			int nKeepDays = 0;

			Int32.TryParse(BackupKeepDaysTextBox.Text, out nKeepDays);

			if (nKeepDays == 0)
				{
				BackupKeepDaysTextBox.BackColor = Color.LightPink;

				m_DataFiles.Preferences.BackupOK = false;
				}
			else
				{
				BackupKeepDaysTextBox.BackColor = SystemColors.Window;
				}

			if (!m_DataFiles.Preferences.BackupOK)
				{
				AutoBackupCheckBox.Checked = false;

				AutoBackupCheckBox.Enabled = false;
				}
			else
				{
				AutoBackupCheckBox.Checked = m_DataFiles.Preferences.AutoBackup;

				AutoBackupCheckBox.Enabled = true;
				}

			BackupButton.Enabled = m_DataFiles.Preferences.BackupOK;
			RestoreBackupButton.Enabled = m_DataFiles.Preferences.BackupOK;
			}

		//============================================================================*
		// VerifyFolder()
		//============================================================================*

		private bool VerifyFolder(string strFolder)
			{
			if (strFolder.Length == 0)
				return (false);

			System.IO.DirectoryInfo FolderInfo = new System.IO.DirectoryInfo(m_DataFiles.Preferences.BackupFolder);

			if (!FolderInfo.Exists)
				return (false);

			return (true);
			}
		}
	}
