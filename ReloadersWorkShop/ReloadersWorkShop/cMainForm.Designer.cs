//============================================================================*
// cMainForm.Designer.cs
//
// Copyright © 2013-2014, Kevin S. Beebe
// All Rights Reserved
//============================================================================*

//============================================================================*
// .Net Using Statements
//============================================================================*

using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

using ReloadersWorkShop;

//============================================================================*
// NameSpace
//============================================================================*

namespace ReloadersWorkShop
	{
	//============================================================================*
	// cMainForm Class
	//============================================================================*

	partial class cMainForm
		{
		private System.ComponentModel.IContainer components = null;

		//============================================================================*
		// Dispose()
		//============================================================================*

		protected override void Dispose(bool disposing)
			{
			if (disposing && (components != null))
				{
				components.Dispose();
				}
			
			base.Dispose(disposing);
			}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
			{
			System.Windows.Forms.Label label54;
			System.Windows.Forms.Label label56;
			System.Windows.Forms.Label LoadDataFiltersFirearmTypeLabel;
			System.Windows.Forms.Label LoadDataFiltersCaliberlabel;
			System.Windows.Forms.Label label40;
			System.Windows.Forms.Label BatchPowderLabel;
			System.Windows.Forms.Label BatchCaliberLabel;
			System.Windows.Forms.Label LoadDataFiltersBulletLabel;
			System.Windows.Forms.Label BatchFirearmTypeLabel;
			System.Windows.Forms.Label LoadDataFiltersPowderLabel;
			System.Windows.Forms.Label label1;
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(cMainForm));
			this.MainMenu = new System.Windows.Forms.MenuStrip();
			this.FileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.FileSaveMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.FileBackupMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.FileRestoreBackupMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.FilePrintMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.FilePrintAmmoListMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.FilePrintAmmoShoppingListMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.FilePrintFirearmsListMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.FilePrintLoadShoppingListMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.FilePrintSupplyListMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.FilePrintSupplyShoppingListMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.FilePrintCostAnalysisMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.FilePreferencesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
			this.FileResetDataMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.FileExitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.EditMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.EditNewMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.EditEditMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.EditRemoveMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.EditInventoryActivityMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ViewMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ViewViewMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ViewCheckedMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ViewInventoryActivityMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.ViewManufacturersMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ViewCalibersMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ViewFirearmsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ViewSuppliesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ViewBulletsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ViewCasesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ViewPowdersMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ViewPrimersMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ViewLoadDataMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ViewBatchEditorMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ViewAmmoMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ViewBallisticsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ToolsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ToolsStabilityCalculatorMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ToolsConversionCalculatorMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.SAAMIDocumentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ToolsSAAMIPistolMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ToolsSAAMIPistolSpecsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ToolsSAAMIPistolVelocityDataMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ToolsSAAMIRifleMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ToolsSAAMIRifleSpecsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ToolsSAAMIRifleVelocityDataMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ToolsSAAMIRimfireMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ToolsSAAMIRimfireSpecsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ToolsSAAMIShotshellMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ToolsSAAMIShotshellSpecsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
			this.ToolsSAAMIBrochuresMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ToolsSAAMIFactsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ToolsSAAMIAmmoFiresMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ToolsSAAMIPrimersMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ToolsSAAMISafeAmmoStorageMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ToolsSAAMISmokelessPowderMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ToolsSAAMISportingFirearmsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ToolsSAAMIUnsafeArmsAmmoMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.HelpMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.HelpSupportForumMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.HelpVideoMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.HelpVideoBulletSelectionMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.HelpVideoCrimpingMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.HelpVideoSDBCMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.HelpVideoHeadspaceMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
			this.HelpVideoRWMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.HelpVideoRWOperationMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.HelpVideoRWLoadDataMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.HelpVideoRWBatchEditorMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.HelpVideoRWInventoryMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.HelpVideoRWBallisticsCalculatorMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.HelpNotesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
			this.HelpPurchaseMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.HelpProgramUpdateMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.HelpDataUpdateMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
			this.HelpAboutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.BallisticsTab = new System.Windows.Forms.TabPage();
			this.WindDriftChartGroup = new System.Windows.Forms.GroupBox();
			this.label6 = new System.Windows.Forms.Label();
			this.ResetWindageTurretButton = new System.Windows.Forms.Button();
			this.DriftTurretTypeLabel = new System.Windows.Forms.Label();
			this.label23 = new System.Windows.Forms.Label();
			this.WindageTurretUpDown = new System.Windows.Forms.NumericUpDown();
			this.ReferenceDataDriftLegendLabel = new System.Windows.Forms.Label();
			this.CurrentDataDriftLegendLabel = new System.Windows.Forms.Label();
			this.ShowWindDriftRangeMarkersCheckBox = new System.Windows.Forms.CheckBox();
			this.WindDriftChart = new System.Windows.Forms.PictureBox();
			this.BulletDropChartGroup = new System.Windows.Forms.GroupBox();
			this.BallisticsSoundSpeedLabel = new System.Windows.Forms.Label();
			this.label35 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.ResetElevationTurretButton = new System.Windows.Forms.Button();
			this.TurretTypeLabel = new System.Windows.Forms.Label();
			this.BallisticsMuzzleHeightLabel = new System.Windows.Forms.Label();
			this.label21 = new System.Windows.Forms.Label();
			this.ElevationTurretUpDown = new System.Windows.Forms.NumericUpDown();
			this.ShowTransonicMarkersCheckBox = new System.Windows.Forms.CheckBox();
			this.ShowApexMarkerCheckBox = new System.Windows.Forms.CheckBox();
			this.ReferenceDataLegendLabel = new System.Windows.Forms.Label();
			this.CurrentDataLegendLabel = new System.Windows.Forms.Label();
			this.ShowGroundStrikeMarkerCheckBox = new System.Windows.Forms.CheckBox();
			this.ShowDropChartRangeMarkersCheckBox = new System.Windows.Forms.CheckBox();
			this.BulletDropChart = new System.Windows.Forms.PictureBox();
			this.label4 = new System.Windows.Forms.Label();
			this.DropTableGroup = new System.Windows.Forms.GroupBox();
			this.BallisticsPrintButton = new System.Windows.Forms.Button();
			this.BallisticsUseSFCheckBox = new System.Windows.Forms.CheckBox();
			this.CompareToReferenceBulletCheckBox = new System.Windows.Forms.CheckBox();
			this.BallisticsListView = new System.Windows.Forms.ListView();
			this.RangeHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.DropHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.DropMOAHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.WindDriftHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.WindDriftMOAHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.VelocityHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.EnergyHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.TimeOfFlightHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.ScopeClickHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.SFHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.AdjBCHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.label17 = new System.Windows.Forms.Label();
			this.MuzzleVelocityMeasurementLabel = new System.Windows.Forms.Label();
			this.BallisticsMuzzleVelocityTextBox = new CommonLib.Controls.cIntegerValueTextBox();
			this.BallisticsDatabaseGroupBox = new System.Windows.Forms.GroupBox();
			this.label2 = new System.Windows.Forms.Label();
			this.BallisticsFirearmTypeCombo = new ReloadersWorkShop.Controls.cFirearmTypeCombo();
			this.BallisticsResetButton = new System.Windows.Forms.Button();
			this.BallisticsLoadDataVelocityRadioButton = new System.Windows.Forms.RadioButton();
			this.BallisticsBatchTestVelocityRadioButton = new System.Windows.Forms.RadioButton();
			this.BallisticsBulletCombo = new System.Windows.Forms.ComboBox();
			this.BallisticsCaliberCombo = new System.Windows.Forms.ComboBox();
			this.label11 = new System.Windows.Forms.Label();
			this.BallisticsChargeCombo = new System.Windows.Forms.ComboBox();
			this.label12 = new System.Windows.Forms.Label();
			this.BallisticsFirearmCombo = new System.Windows.Forms.ComboBox();
			this.label10 = new System.Windows.Forms.Label();
			this.BallisticsLoadCombo = new System.Windows.Forms.ComboBox();
			this.label13 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.BallisticsBatchCombo = new System.Windows.Forms.ComboBox();
			this.label8 = new System.Windows.Forms.Label();
			this.BallisticsInputDataGroupBox = new System.Windows.Forms.GroupBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.BallisticsKestrelButton = new System.Windows.Forms.Button();
			this.BallisticsUseStationPressureCheckBox = new System.Windows.Forms.CheckBox();
			this.BallisticsStationPressureLabel = new System.Windows.Forms.Label();
			this.TemperatureMeasurementLabel = new System.Windows.Forms.Label();
			this.label14 = new System.Windows.Forms.Label();
			this.BallisticsUseDensityAltitudeCheckBox = new System.Windows.Forms.CheckBox();
			this.BallisticsTemperatureTextBox = new CommonLib.Controls.cIntegerValueTextBox();
			this.BallisticsDensityAltitudeLabel = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.BallisticsHumidityTextBox = new CommonLib.Controls.cIntegerValueTextBox();
			this.BallisticsAltitudeTextBox = new CommonLib.Controls.cIntegerValueTextBox();
			this.label22 = new System.Windows.Forms.Label();
			this.AltitudeMeasurementLabel = new System.Windows.Forms.Label();
			this.label32 = new System.Windows.Forms.Label();
			this.BallisticsPressureMeasurementLabel = new System.Windows.Forms.Label();
			this.label25 = new System.Windows.Forms.Label();
			this.label30 = new System.Windows.Forms.Label();
			this.label19 = new System.Windows.Forms.Label();
			this.label31 = new System.Windows.Forms.Label();
			this.BallisticsPressureTextBox = new CommonLib.Controls.cDoubleValueTextBox();
			this.WindSpeedMeasurementLabel = new System.Windows.Forms.Label();
			this.BallisticsWindSpeedTextBox = new CommonLib.Controls.cIntegerValueTextBox();
			this.CrossWindLabel = new System.Windows.Forms.Label();
			this.HeadWindLabel = new System.Windows.Forms.Label();
			this.BallisticsWindDirectionTextBox = new CommonLib.Controls.cIntegerValueTextBox();
			this.BallisticsTwistTextBox = new CommonLib.Controls.cDoubleValueTextBox();
			this.TwistMeasurementLabel = new System.Windows.Forms.Label();
			this.label33 = new System.Windows.Forms.Label();
			this.BallisticsBulletLengthTextBox = new CommonLib.Controls.cDoubleValueTextBox();
			this.BulletLengthMeasurementLabel = new System.Windows.Forms.Label();
			this.label29 = new System.Windows.Forms.Label();
			this.ShowReferenceDataCheckBox = new System.Windows.Forms.CheckBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.MaxRangeMeasurementLabel = new System.Windows.Forms.Label();
			this.label34 = new System.Windows.Forms.Label();
			this.label36 = new System.Windows.Forms.Label();
			this.label38 = new System.Windows.Forms.Label();
			this.IncrementMeasurementLabel = new System.Windows.Forms.Label();
			this.BallisticsIncrementTextBox = new CommonLib.Controls.cIntegerValueTextBox();
			this.MinRangeMeasurementLabel = new System.Windows.Forms.Label();
			this.BallisticsMinRangeTextBox = new CommonLib.Controls.cIntegerValueTextBox();
			this.BallisticsMaxRangeTextBox = new CommonLib.Controls.cIntegerValueTextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.BallisticsTargetRangeTextBox = new CommonLib.Controls.cIntegerValueTextBox();
			this.TargetRangeMeasurementLabel = new System.Windows.Forms.Label();
			this.BallisticsTurretTypeComboBox = new System.Windows.Forms.ComboBox();
			this.BallisticsSightHeightTextBox = new CommonLib.Controls.cDoubleValueTextBox();
			this.SightHeightMeasurementLabel = new System.Windows.Forms.Label();
			this.BallisticsScopeClickTextBox = new CommonLib.Controls.cDoubleValueTextBox();
			this.BallisticsBCTextBox = new CommonLib.Controls.cDoubleValueTextBox();
			this.BallisticsZeroRangeTextBox = new CommonLib.Controls.cIntegerValueTextBox();
			this.ZeroRangeMeasurementLabel = new System.Windows.Forms.Label();
			this.BallisticsBulletDiameterTextBox = new CommonLib.Controls.cDoubleValueTextBox();
			this.BulletDiameterMeasurementLabel = new System.Windows.Forms.Label();
			this.BallisticsBulletWeightTextBox = new CommonLib.Controls.cDoubleValueTextBox();
			this.BulletWeightMeasurementLabel = new System.Windows.Forms.Label();
			this.SaveReferenceBulletButton = new System.Windows.Forms.Button();
			this.RestoreReferenceBulletButton = new System.Windows.Forms.Button();
			this.label28 = new System.Windows.Forms.Label();
			this.label26 = new System.Windows.Forms.Label();
			this.label24 = new System.Windows.Forms.Label();
			this.label18 = new System.Windows.Forms.Label();
			this.label16 = new System.Windows.Forms.Label();
			this.label15 = new System.Windows.Forms.Label();
			this.BatchBulletLabel = new System.Windows.Forms.Label();
			this.AmmoTab = new System.Windows.Forms.TabPage();
			this.AmmoInventoryGroup = new System.Windows.Forms.GroupBox();
			this.AmmoCostAnalysisButton = new System.Windows.Forms.Button();
			this.ViewAmmoInventoryButton = new System.Windows.Forms.Button();
			this.EditAmmoInventoryButton = new System.Windows.Forms.Button();
			this.AmmoPrintOptionsGroupBox = new System.Windows.Forms.GroupBox();
			this.AmmoPrintBelowStockCheckBox = new System.Windows.Forms.CheckBox();
			this.NoAmmoListLabel = new System.Windows.Forms.Label();
			this.AmmoPrintFactoryOnlyCheckBox = new System.Windows.Forms.CheckBox();
			this.AmmoPrintNonZeroCheckBox = new System.Windows.Forms.CheckBox();
			this.AmmoPrintCheckedRadioButton = new System.Windows.Forms.RadioButton();
			this.AmmoPrintAllRadioButton = new System.Windows.Forms.RadioButton();
			this.AmmoListPrintButton = new System.Windows.Forms.Button();
			this.ViewAmmoButton = new System.Windows.Forms.Button();
			this.RemoveAmmoButton = new System.Windows.Forms.Button();
			this.EditAmmoButton = new System.Windows.Forms.Button();
			this.AddAmmoButton = new System.Windows.Forms.Button();
			this.BatchEditorTab = new System.Windows.Forms.TabPage();
			this.BatchNotTrackedLabel = new System.Windows.Forms.Label();
			this.NoInventoryWarningLabel = new System.Windows.Forms.Label();
			this.BatchEditorActionsGroupBox = new System.Windows.Forms.GroupBox();
			this.PrintCheckedBatchLabelsButton = new System.Windows.Forms.Button();
			this.ShowArchivedBatchesCheckBox = new System.Windows.Forms.CheckBox();
			this.UnarchiveCheckedButton = new System.Windows.Forms.Button();
			this.ArchiveCheckedButton = new System.Windows.Forms.Button();
			this.ViewBatchButton = new System.Windows.Forms.Button();
			this.RemoveBatchButton = new System.Windows.Forms.Button();
			this.EditBatchButton = new System.Windows.Forms.Button();
			this.AddBatchButton = new System.Windows.Forms.Button();
			this.BatchFiltersGroupBox = new System.Windows.Forms.GroupBox();
			this.BatchFirearmTypeCombo = new ReloadersWorkShop.Controls.cFirearmTypeCombo();
			this.BatchCaliberCombo = new System.Windows.Forms.ComboBox();
			this.BatchBulletCombo = new System.Windows.Forms.ComboBox();
			this.BatchPowderCombo = new System.Windows.Forms.ComboBox();
			this.LoadDataTab = new System.Windows.Forms.TabPage();
			this.LoadDataListViewInfoLabel = new System.Windows.Forms.Label();
			this.LoadDataDeselectAllButton = new System.Windows.Forms.Button();
			this.LoadDataSelectAllButton = new System.Windows.Forms.Button();
			this.ViewLoadButton = new System.Windows.Forms.Button();
			this.RemoveLoadButton = new System.Windows.Forms.Button();
			this.EditLoadButton = new System.Windows.Forms.Button();
			this.AddLoadButton = new System.Windows.Forms.Button();
			this.LoadDataFiltersGroupBox = new System.Windows.Forms.GroupBox();
			this.LoadDataFirearmTypeCombo = new ReloadersWorkShop.Controls.cFirearmTypeCombo();
			this.LoadDataCaliberCombo = new System.Windows.Forms.ComboBox();
			this.LoadDataBulletCombo = new System.Windows.Forms.ComboBox();
			this.LoadDataPowderCombo = new System.Windows.Forms.ComboBox();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.ImportShareFileButton = new System.Windows.Forms.Button();
			this.ShareFileButton = new System.Windows.Forms.Button();
			this.LoadShoppingListButton = new System.Windows.Forms.Button();
			this.EvaluateLoadButton = new System.Windows.Forms.Button();
			this.SuppliesTab = new System.Windows.Forms.TabPage();
			this.SuppliesInventoryGroup = new System.Windows.Forms.GroupBox();
			this.SuppliesCostAnalysisButton = new System.Windows.Forms.Button();
			this.ViewInventoryButton = new System.Windows.Forms.Button();
			this.EditInventoryButton = new System.Windows.Forms.Button();
			this.HideUncheckedSuppliesCheckBox = new System.Windows.Forms.CheckBox();
			this.SuppliesPrintOptionsGroupBox = new System.Windows.Forms.GroupBox();
			this.SuppliesPrintBelowStockCheckBox = new System.Windows.Forms.CheckBox();
			this.NoSupplyListLabel = new System.Windows.Forms.Label();
			this.SuppliesPrintNonZeroCheckBox = new System.Windows.Forms.CheckBox();
			this.SuppliesPrintCheckedRadioButton = new System.Windows.Forms.RadioButton();
			this.SuppliesPrintAllRadioButton = new System.Windows.Forms.RadioButton();
			this.SupplyListPrintButton = new System.Windows.Forms.Button();
			this.DeselectAllSuppliesButton = new System.Windows.Forms.Button();
			this.SelectAllSuppliesButton = new System.Windows.Forms.Button();
			this.SupplyCountLabel = new System.Windows.Forms.Label();
			this.ViewSupplyButton = new System.Windows.Forms.Button();
			this.SupplyTypeCombo = new System.Windows.Forms.ComboBox();
			this.RemoveSupplyButton = new System.Windows.Forms.Button();
			this.EditSupplyButton = new System.Windows.Forms.Button();
			this.AddSupplyButton = new System.Windows.Forms.Button();
			this.FirearmsTab = new System.Windows.Forms.TabPage();
			this.FirearmPrintOptionsGroupBox = new System.Windows.Forms.GroupBox();
			this.FirearmPrintSpecsCheckBox = new System.Windows.Forms.CheckBox();
			this.FirearmPrintDetailCheckBox = new System.Windows.Forms.CheckBox();
			this.FirearmPrintAllRadioButton = new System.Windows.Forms.RadioButton();
			this.FirearmPrintCheckedRadioButton = new System.Windows.Forms.RadioButton();
			this.FirearmPrintButton = new System.Windows.Forms.Button();
			this.ViewFirearmButton = new System.Windows.Forms.Button();
			this.RemoveFirearmButton = new System.Windows.Forms.Button();
			this.EditFirearmButton = new System.Windows.Forms.Button();
			this.AddFirearmButton = new System.Windows.Forms.Button();
			this.CalibersTab = new System.Windows.Forms.TabPage();
			this.HideUncheckedCalibersCheckBox = new System.Windows.Forms.CheckBox();
			this.CaliberCountLabel = new System.Windows.Forms.Label();
			this.ViewCaliberButton = new System.Windows.Forms.Button();
			this.RemoveCaliberButton = new System.Windows.Forms.Button();
			this.EditCaliberButton = new System.Windows.Forms.Button();
			this.AddCaliberButton = new System.Windows.Forms.Button();
			this.ManufacturersTab = new System.Windows.Forms.TabPage();
			this.ViewManufacturerButton = new System.Windows.Forms.Button();
			this.RemoveManufacturerButton = new System.Windows.Forms.Button();
			this.EditManufacturerButton = new System.Windows.Forms.Button();
			this.AddManufacturerButton = new System.Windows.Forms.Button();
			this.MainTabControl = new System.Windows.Forms.TabControl();
			this.ToolsTargetCalculatorMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			label54 = new System.Windows.Forms.Label();
			label56 = new System.Windows.Forms.Label();
			LoadDataFiltersFirearmTypeLabel = new System.Windows.Forms.Label();
			LoadDataFiltersCaliberlabel = new System.Windows.Forms.Label();
			label40 = new System.Windows.Forms.Label();
			BatchPowderLabel = new System.Windows.Forms.Label();
			BatchCaliberLabel = new System.Windows.Forms.Label();
			LoadDataFiltersBulletLabel = new System.Windows.Forms.Label();
			BatchFirearmTypeLabel = new System.Windows.Forms.Label();
			LoadDataFiltersPowderLabel = new System.Windows.Forms.Label();
			label1 = new System.Windows.Forms.Label();
			this.MainMenu.SuspendLayout();
			this.BallisticsTab.SuspendLayout();
			this.WindDriftChartGroup.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.WindageTurretUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.WindDriftChart)).BeginInit();
			this.BulletDropChartGroup.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.ElevationTurretUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.BulletDropChart)).BeginInit();
			this.DropTableGroup.SuspendLayout();
			this.BallisticsDatabaseGroupBox.SuspendLayout();
			this.BallisticsInputDataGroupBox.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.AmmoTab.SuspendLayout();
			this.AmmoInventoryGroup.SuspendLayout();
			this.AmmoPrintOptionsGroupBox.SuspendLayout();
			this.BatchEditorTab.SuspendLayout();
			this.BatchEditorActionsGroupBox.SuspendLayout();
			this.BatchFiltersGroupBox.SuspendLayout();
			this.LoadDataTab.SuspendLayout();
			this.LoadDataFiltersGroupBox.SuspendLayout();
			this.groupBox5.SuspendLayout();
			this.SuppliesTab.SuspendLayout();
			this.SuppliesInventoryGroup.SuspendLayout();
			this.SuppliesPrintOptionsGroupBox.SuspendLayout();
			this.FirearmsTab.SuspendLayout();
			this.FirearmPrintOptionsGroupBox.SuspendLayout();
			this.CalibersTab.SuspendLayout();
			this.ManufacturersTab.SuspendLayout();
			this.MainTabControl.SuspendLayout();
			this.SuspendLayout();
			// 
			// label54
			// 
			label54.AutoSize = true;
			label54.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			label54.ForeColor = System.Drawing.SystemColors.ControlText;
			label54.Location = new System.Drawing.Point(472, 24);
			label54.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			label54.Name = "label54";
			label54.Size = new System.Drawing.Size(58, 13);
			label54.TabIndex = 9;
			label54.Text = "Crosswind:";
			// 
			// label56
			// 
			label56.AutoSize = true;
			label56.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			label56.ForeColor = System.Drawing.SystemColors.ControlText;
			label56.Location = new System.Drawing.Point(372, 24);
			label56.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			label56.Name = "label56";
			label56.Size = new System.Drawing.Size(61, 13);
			label56.TabIndex = 44;
			label56.Text = "HeadWind:";
			// 
			// LoadDataFiltersFirearmTypeLabel
			// 
			LoadDataFiltersFirearmTypeLabel.AutoSize = true;
			LoadDataFiltersFirearmTypeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			LoadDataFiltersFirearmTypeLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(1)))));
			LoadDataFiltersFirearmTypeLabel.Location = new System.Drawing.Point(6, 24);
			LoadDataFiltersFirearmTypeLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			LoadDataFiltersFirearmTypeLabel.Name = "LoadDataFiltersFirearmTypeLabel";
			LoadDataFiltersFirearmTypeLabel.Size = new System.Drawing.Size(71, 13);
			LoadDataFiltersFirearmTypeLabel.TabIndex = 5;
			LoadDataFiltersFirearmTypeLabel.Text = "Firearm Type:";
			// 
			// LoadDataFiltersCaliberlabel
			// 
			LoadDataFiltersCaliberlabel.AutoSize = true;
			LoadDataFiltersCaliberlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			LoadDataFiltersCaliberlabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(1)))));
			LoadDataFiltersCaliberlabel.Location = new System.Drawing.Point(36, 49);
			LoadDataFiltersCaliberlabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			LoadDataFiltersCaliberlabel.Name = "LoadDataFiltersCaliberlabel";
			LoadDataFiltersCaliberlabel.Size = new System.Drawing.Size(42, 13);
			LoadDataFiltersCaliberlabel.TabIndex = 7;
			LoadDataFiltersCaliberlabel.Text = "Caliber:";
			// 
			// label40
			// 
			label40.AutoSize = true;
			label40.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			label40.ForeColor = System.Drawing.SystemColors.ControlText;
			label40.Location = new System.Drawing.Point(307, 24);
			label40.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			label40.Name = "label40";
			label40.Size = new System.Drawing.Size(36, 13);
			label40.TabIndex = 11;
			label40.Text = "Bullet:";
			// 
			// BatchPowderLabel
			// 
			BatchPowderLabel.AutoSize = true;
			BatchPowderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			BatchPowderLabel.ForeColor = System.Drawing.SystemColors.ControlText;
			BatchPowderLabel.Location = new System.Drawing.Point(294, 49);
			BatchPowderLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			BatchPowderLabel.Name = "BatchPowderLabel";
			BatchPowderLabel.Size = new System.Drawing.Size(46, 13);
			BatchPowderLabel.TabIndex = 14;
			BatchPowderLabel.Text = "Powder:";
			// 
			// BatchCaliberLabel
			// 
			BatchCaliberLabel.AutoSize = true;
			BatchCaliberLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			BatchCaliberLabel.ForeColor = System.Drawing.SystemColors.ControlText;
			BatchCaliberLabel.Location = new System.Drawing.Point(36, 49);
			BatchCaliberLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			BatchCaliberLabel.Name = "BatchCaliberLabel";
			BatchCaliberLabel.Size = new System.Drawing.Size(42, 13);
			BatchCaliberLabel.TabIndex = 3;
			BatchCaliberLabel.Text = "Caliber:";
			// 
			// LoadDataFiltersBulletLabel
			// 
			LoadDataFiltersBulletLabel.AutoSize = true;
			LoadDataFiltersBulletLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			LoadDataFiltersBulletLabel.ForeColor = System.Drawing.SystemColors.ControlText;
			LoadDataFiltersBulletLabel.Location = new System.Drawing.Point(302, 24);
			LoadDataFiltersBulletLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			LoadDataFiltersBulletLabel.Name = "LoadDataFiltersBulletLabel";
			LoadDataFiltersBulletLabel.Size = new System.Drawing.Size(36, 13);
			LoadDataFiltersBulletLabel.TabIndex = 1;
			LoadDataFiltersBulletLabel.Text = "Bullet:";
			// 
			// BatchFirearmTypeLabel
			// 
			BatchFirearmTypeLabel.AutoSize = true;
			BatchFirearmTypeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			BatchFirearmTypeLabel.ForeColor = System.Drawing.SystemColors.ControlText;
			BatchFirearmTypeLabel.Location = new System.Drawing.Point(6, 24);
			BatchFirearmTypeLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			BatchFirearmTypeLabel.Name = "BatchFirearmTypeLabel";
			BatchFirearmTypeLabel.Size = new System.Drawing.Size(71, 13);
			BatchFirearmTypeLabel.TabIndex = 8;
			BatchFirearmTypeLabel.Text = "Firearm Type:";
			// 
			// LoadDataFiltersPowderLabel
			// 
			LoadDataFiltersPowderLabel.AutoSize = true;
			LoadDataFiltersPowderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			LoadDataFiltersPowderLabel.ForeColor = System.Drawing.SystemColors.ControlText;
			LoadDataFiltersPowderLabel.Location = new System.Drawing.Point(294, 49);
			LoadDataFiltersPowderLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			LoadDataFiltersPowderLabel.Name = "LoadDataFiltersPowderLabel";
			LoadDataFiltersPowderLabel.Size = new System.Drawing.Size(46, 13);
			LoadDataFiltersPowderLabel.TabIndex = 10;
			LoadDataFiltersPowderLabel.Text = "Powder:";
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(13, 45);
			label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(34, 13);
			label1.TabIndex = 6;
			label1.Text = "Type:";
			// 
			// MainMenu
			// 
			this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileMenuItem,
            this.EditMenuItem,
            this.ViewMenuItem,
            this.ToolsMenuItem,
            this.HelpMenuItem});
			this.MainMenu.Location = new System.Drawing.Point(0, 0);
			this.MainMenu.Name = "MainMenu";
			this.MainMenu.Size = new System.Drawing.Size(1484, 24);
			this.MainMenu.TabIndex = 1;
			this.MainMenu.Text = "menuStrip1";
			// 
			// FileMenuItem
			// 
			this.FileMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileSaveMenuItem,
            this.toolStripSeparator1,
            this.FileBackupMenuItem,
            this.FileRestoreBackupMenuItem,
            this.toolStripSeparator3,
            this.FilePrintMenuItem,
            this.toolStripSeparator2,
            this.FilePreferencesMenuItem,
            this.toolStripSeparator6,
            this.FileResetDataMenuItem,
            this.FileExitMenuItem});
			this.FileMenuItem.Name = "FileMenuItem";
			this.FileMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F)));
			this.FileMenuItem.Size = new System.Drawing.Size(37, 20);
			this.FileMenuItem.Text = "&File";
			// 
			// FileSaveMenuItem
			// 
			this.FileSaveMenuItem.Name = "FileSaveMenuItem";
			this.FileSaveMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
			this.FileSaveMenuItem.Size = new System.Drawing.Size(208, 22);
			this.FileSaveMenuItem.Text = "&Save";
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(205, 6);
			// 
			// FileBackupMenuItem
			// 
			this.FileBackupMenuItem.Name = "FileBackupMenuItem";
			this.FileBackupMenuItem.Size = new System.Drawing.Size(208, 22);
			this.FileBackupMenuItem.Text = "&Backup";
			// 
			// FileRestoreBackupMenuItem
			// 
			this.FileRestoreBackupMenuItem.Name = "FileRestoreBackupMenuItem";
			this.FileRestoreBackupMenuItem.Size = new System.Drawing.Size(208, 22);
			this.FileRestoreBackupMenuItem.Text = "&Restore Backup";
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(205, 6);
			// 
			// FilePrintMenuItem
			// 
			this.FilePrintMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FilePrintAmmoListMenuItem,
            this.FilePrintAmmoShoppingListMenuItem,
            this.FilePrintFirearmsListMenuItem,
            this.FilePrintLoadShoppingListMenuItem,
            this.FilePrintSupplyListMenuItem,
            this.FilePrintSupplyShoppingListMenuItem,
            this.toolStripMenuItem1,
            this.FilePrintCostAnalysisMenuItem});
			this.FilePrintMenuItem.Name = "FilePrintMenuItem";
			this.FilePrintMenuItem.Size = new System.Drawing.Size(208, 22);
			this.FilePrintMenuItem.Text = "&Print";
			// 
			// FilePrintAmmoListMenuItem
			// 
			this.FilePrintAmmoListMenuItem.Name = "FilePrintAmmoListMenuItem";
			this.FilePrintAmmoListMenuItem.Size = new System.Drawing.Size(186, 22);
			this.FilePrintAmmoListMenuItem.Text = "Ammo List";
			// 
			// FilePrintAmmoShoppingListMenuItem
			// 
			this.FilePrintAmmoShoppingListMenuItem.Name = "FilePrintAmmoShoppingListMenuItem";
			this.FilePrintAmmoShoppingListMenuItem.Size = new System.Drawing.Size(186, 22);
			this.FilePrintAmmoShoppingListMenuItem.Text = "Ammo Shopping List";
			// 
			// FilePrintFirearmsListMenuItem
			// 
			this.FilePrintFirearmsListMenuItem.Name = "FilePrintFirearmsListMenuItem";
			this.FilePrintFirearmsListMenuItem.Size = new System.Drawing.Size(186, 22);
			this.FilePrintFirearmsListMenuItem.Text = "Firearms List";
			// 
			// FilePrintLoadShoppingListMenuItem
			// 
			this.FilePrintLoadShoppingListMenuItem.Name = "FilePrintLoadShoppingListMenuItem";
			this.FilePrintLoadShoppingListMenuItem.Size = new System.Drawing.Size(186, 22);
			this.FilePrintLoadShoppingListMenuItem.Text = "Load Shopping List";
			// 
			// FilePrintSupplyListMenuItem
			// 
			this.FilePrintSupplyListMenuItem.Name = "FilePrintSupplyListMenuItem";
			this.FilePrintSupplyListMenuItem.Size = new System.Drawing.Size(186, 22);
			this.FilePrintSupplyListMenuItem.Text = "Supply List";
			// 
			// FilePrintSupplyShoppingListMenuItem
			// 
			this.FilePrintSupplyShoppingListMenuItem.Name = "FilePrintSupplyShoppingListMenuItem";
			this.FilePrintSupplyShoppingListMenuItem.Size = new System.Drawing.Size(186, 22);
			this.FilePrintSupplyShoppingListMenuItem.Text = "Supply Shopping List";
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(183, 6);
			// 
			// FilePrintCostAnalysisMenuItem
			// 
			this.FilePrintCostAnalysisMenuItem.Name = "FilePrintCostAnalysisMenuItem";
			this.FilePrintCostAnalysisMenuItem.Size = new System.Drawing.Size(186, 22);
			this.FilePrintCostAnalysisMenuItem.Text = "Cost Analysis";
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(205, 6);
			// 
			// FilePreferencesMenuItem
			// 
			this.FilePreferencesMenuItem.Name = "FilePreferencesMenuItem";
			this.FilePreferencesMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.P)));
			this.FilePreferencesMenuItem.Size = new System.Drawing.Size(208, 22);
			this.FilePreferencesMenuItem.Text = "P&references";
			// 
			// toolStripSeparator6
			// 
			this.toolStripSeparator6.Name = "toolStripSeparator6";
			this.toolStripSeparator6.Size = new System.Drawing.Size(205, 6);
			// 
			// FileResetDataMenuItem
			// 
			this.FileResetDataMenuItem.Name = "FileResetDataMenuItem";
			this.FileResetDataMenuItem.Size = new System.Drawing.Size(208, 22);
			this.FileResetDataMenuItem.Text = "Reset Data";
			// 
			// FileExitMenuItem
			// 
			this.FileExitMenuItem.Name = "FileExitMenuItem";
			this.FileExitMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
			this.FileExitMenuItem.Size = new System.Drawing.Size(208, 22);
			this.FileExitMenuItem.Text = "E&xit";
			// 
			// EditMenuItem
			// 
			this.EditMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.EditNewMenuItem,
            this.EditEditMenuItem,
            this.EditRemoveMenuItem,
            this.EditInventoryActivityMenuItem});
			this.EditMenuItem.Name = "EditMenuItem";
			this.EditMenuItem.Size = new System.Drawing.Size(39, 20);
			this.EditMenuItem.Text = "&Edit";
			// 
			// EditNewMenuItem
			// 
			this.EditNewMenuItem.Name = "EditNewMenuItem";
			this.EditNewMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
			this.EditNewMenuItem.Size = new System.Drawing.Size(204, 22);
			this.EditNewMenuItem.Text = "New xxx";
			// 
			// EditEditMenuItem
			// 
			this.EditEditMenuItem.Name = "EditEditMenuItem";
			this.EditEditMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
			this.EditEditMenuItem.Size = new System.Drawing.Size(204, 22);
			this.EditEditMenuItem.Text = "Edit xxx";
			// 
			// EditRemoveMenuItem
			// 
			this.EditRemoveMenuItem.Name = "EditRemoveMenuItem";
			this.EditRemoveMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
			this.EditRemoveMenuItem.Size = new System.Drawing.Size(204, 22);
			this.EditRemoveMenuItem.Text = "&Remove xxx";
			// 
			// EditInventoryActivityMenuItem
			// 
			this.EditInventoryActivityMenuItem.Name = "EditInventoryActivityMenuItem";
			this.EditInventoryActivityMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I)));
			this.EditInventoryActivityMenuItem.Size = new System.Drawing.Size(204, 22);
			this.EditInventoryActivityMenuItem.Text = "Inventory Activity";
			// 
			// ViewMenuItem
			// 
			this.ViewMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ViewViewMenuItem,
            this.ViewCheckedMenuItem,
            this.ViewInventoryActivityMenuItem,
            this.toolStripSeparator4,
            this.ViewManufacturersMenuItem,
            this.ViewCalibersMenuItem,
            this.ViewFirearmsMenuItem,
            this.ViewSuppliesMenuItem,
            this.ViewLoadDataMenuItem,
            this.ViewBatchEditorMenuItem,
            this.ViewAmmoMenuItem,
            this.ViewBallisticsMenuItem});
			this.ViewMenuItem.Name = "ViewMenuItem";
			this.ViewMenuItem.Size = new System.Drawing.Size(44, 20);
			this.ViewMenuItem.Text = "&View";
			// 
			// ViewViewMenuItem
			// 
			this.ViewViewMenuItem.Name = "ViewViewMenuItem";
			this.ViewViewMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
			this.ViewViewMenuItem.Size = new System.Drawing.Size(204, 22);
			this.ViewViewMenuItem.Text = "View xxx";
			// 
			// ViewCheckedMenuItem
			// 
			this.ViewCheckedMenuItem.Name = "ViewCheckedMenuItem";
			this.ViewCheckedMenuItem.Size = new System.Drawing.Size(204, 22);
			this.ViewCheckedMenuItem.Text = "Checked xxx &Only";
			// 
			// ViewInventoryActivityMenuItem
			// 
			this.ViewInventoryActivityMenuItem.Name = "ViewInventoryActivityMenuItem";
			this.ViewInventoryActivityMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.V)));
			this.ViewInventoryActivityMenuItem.Size = new System.Drawing.Size(204, 22);
			this.ViewInventoryActivityMenuItem.Text = "Inventory Activity";
			// 
			// toolStripSeparator4
			// 
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new System.Drawing.Size(201, 6);
			// 
			// ViewManufacturersMenuItem
			// 
			this.ViewManufacturersMenuItem.Name = "ViewManufacturersMenuItem";
			this.ViewManufacturersMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2;
			this.ViewManufacturersMenuItem.Size = new System.Drawing.Size(204, 22);
			this.ViewManufacturersMenuItem.Text = "&Manufacturers";
			// 
			// ViewCalibersMenuItem
			// 
			this.ViewCalibersMenuItem.Name = "ViewCalibersMenuItem";
			this.ViewCalibersMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F3;
			this.ViewCalibersMenuItem.Size = new System.Drawing.Size(204, 22);
			this.ViewCalibersMenuItem.Text = "&Calibers";
			// 
			// ViewFirearmsMenuItem
			// 
			this.ViewFirearmsMenuItem.Name = "ViewFirearmsMenuItem";
			this.ViewFirearmsMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F4;
			this.ViewFirearmsMenuItem.Size = new System.Drawing.Size(204, 22);
			this.ViewFirearmsMenuItem.Text = "&Firearms";
			// 
			// ViewSuppliesMenuItem
			// 
			this.ViewSuppliesMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ViewBulletsMenuItem,
            this.ViewCasesMenuItem,
            this.ViewPowdersMenuItem,
            this.ViewPrimersMenuItem});
			this.ViewSuppliesMenuItem.Name = "ViewSuppliesMenuItem";
			this.ViewSuppliesMenuItem.Size = new System.Drawing.Size(204, 22);
			this.ViewSuppliesMenuItem.Text = "Supplies";
			// 
			// ViewBulletsMenuItem
			// 
			this.ViewBulletsMenuItem.Name = "ViewBulletsMenuItem";
			this.ViewBulletsMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
			this.ViewBulletsMenuItem.Size = new System.Drawing.Size(170, 22);
			this.ViewBulletsMenuItem.Text = "&Bullets";
			// 
			// ViewCasesMenuItem
			// 
			this.ViewCasesMenuItem.Name = "ViewCasesMenuItem";
			this.ViewCasesMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F5)));
			this.ViewCasesMenuItem.Size = new System.Drawing.Size(170, 22);
			this.ViewCasesMenuItem.Text = "&Cases";
			// 
			// ViewPowdersMenuItem
			// 
			this.ViewPowdersMenuItem.Name = "ViewPowdersMenuItem";
			this.ViewPowdersMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.F5)));
			this.ViewPowdersMenuItem.Size = new System.Drawing.Size(170, 22);
			this.ViewPowdersMenuItem.Text = "&Powders";
			// 
			// ViewPrimersMenuItem
			// 
			this.ViewPrimersMenuItem.Name = "ViewPrimersMenuItem";
			this.ViewPrimersMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F5)));
			this.ViewPrimersMenuItem.Size = new System.Drawing.Size(170, 22);
			this.ViewPrimersMenuItem.Text = "P&rimers";
			// 
			// ViewLoadDataMenuItem
			// 
			this.ViewLoadDataMenuItem.Name = "ViewLoadDataMenuItem";
			this.ViewLoadDataMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F6;
			this.ViewLoadDataMenuItem.Size = new System.Drawing.Size(204, 22);
			this.ViewLoadDataMenuItem.Text = "&Loads";
			// 
			// ViewBatchEditorMenuItem
			// 
			this.ViewBatchEditorMenuItem.Name = "ViewBatchEditorMenuItem";
			this.ViewBatchEditorMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F7;
			this.ViewBatchEditorMenuItem.Size = new System.Drawing.Size(204, 22);
			this.ViewBatchEditorMenuItem.Text = "&Batches";
			// 
			// ViewAmmoMenuItem
			// 
			this.ViewAmmoMenuItem.Name = "ViewAmmoMenuItem";
			this.ViewAmmoMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F8;
			this.ViewAmmoMenuItem.Size = new System.Drawing.Size(204, 22);
			this.ViewAmmoMenuItem.Text = "&Ammo";
			// 
			// ViewBallisticsMenuItem
			// 
			this.ViewBallisticsMenuItem.Name = "ViewBallisticsMenuItem";
			this.ViewBallisticsMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F9;
			this.ViewBallisticsMenuItem.Size = new System.Drawing.Size(204, 22);
			this.ViewBallisticsMenuItem.Text = "Ba&llistics";
			// 
			// ToolsMenuItem
			// 
			this.ToolsMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolsStabilityCalculatorMenuItem,
            this.ToolsConversionCalculatorMenuItem,
            this.SAAMIDocumentsToolStripMenuItem,
            this.ToolsTargetCalculatorMenuItem});
			this.ToolsMenuItem.Name = "ToolsMenuItem";
			this.ToolsMenuItem.Size = new System.Drawing.Size(48, 20);
			this.ToolsMenuItem.Text = "&Tools";
			// 
			// ToolsStabilityCalculatorMenuItem
			// 
			this.ToolsStabilityCalculatorMenuItem.Name = "ToolsStabilityCalculatorMenuItem";
			this.ToolsStabilityCalculatorMenuItem.Size = new System.Drawing.Size(216, 22);
			this.ToolsStabilityCalculatorMenuItem.Text = "Bullet &Stability Calculator";
			// 
			// ToolsConversionCalculatorMenuItem
			// 
			this.ToolsConversionCalculatorMenuItem.Name = "ToolsConversionCalculatorMenuItem";
			this.ToolsConversionCalculatorMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F12;
			this.ToolsConversionCalculatorMenuItem.Size = new System.Drawing.Size(216, 22);
			this.ToolsConversionCalculatorMenuItem.Text = "Conversion &Calculator";
			// 
			// SAAMIDocumentsToolStripMenuItem
			// 
			this.SAAMIDocumentsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolsSAAMIPistolMenuItem,
            this.ToolsSAAMIRifleMenuItem,
            this.ToolsSAAMIRimfireMenuItem,
            this.ToolsSAAMIShotshellMenuItem,
            this.toolStripSeparator7,
            this.ToolsSAAMIBrochuresMenuItem});
			this.SAAMIDocumentsToolStripMenuItem.Name = "SAAMIDocumentsToolStripMenuItem";
			this.SAAMIDocumentsToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
			this.SAAMIDocumentsToolStripMenuItem.Text = "SAAMI Documents";
			// 
			// ToolsSAAMIPistolMenuItem
			// 
			this.ToolsSAAMIPistolMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolsSAAMIPistolSpecsMenuItem,
            this.ToolsSAAMIPistolVelocityDataMenuItem});
			this.ToolsSAAMIPistolMenuItem.Name = "ToolsSAAMIPistolMenuItem";
			this.ToolsSAAMIPistolMenuItem.Size = new System.Drawing.Size(219, 22);
			this.ToolsSAAMIPistolMenuItem.Text = "Centerfire Pistol && Revolver";
			// 
			// ToolsSAAMIPistolSpecsMenuItem
			// 
			this.ToolsSAAMIPistolSpecsMenuItem.Name = "ToolsSAAMIPistolSpecsMenuItem";
			this.ToolsSAAMIPistolSpecsMenuItem.Size = new System.Drawing.Size(203, 22);
			this.ToolsSAAMIPistolSpecsMenuItem.Text = "Standards && Drawings";
			// 
			// ToolsSAAMIPistolVelocityDataMenuItem
			// 
			this.ToolsSAAMIPistolVelocityDataMenuItem.Name = "ToolsSAAMIPistolVelocityDataMenuItem";
			this.ToolsSAAMIPistolVelocityDataMenuItem.Size = new System.Drawing.Size(203, 22);
			this.ToolsSAAMIPistolVelocityDataMenuItem.Text = "Velocity && Pressure Data";
			// 
			// ToolsSAAMIRifleMenuItem
			// 
			this.ToolsSAAMIRifleMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolsSAAMIRifleSpecsMenuItem,
            this.ToolsSAAMIRifleVelocityDataMenuItem});
			this.ToolsSAAMIRifleMenuItem.Name = "ToolsSAAMIRifleMenuItem";
			this.ToolsSAAMIRifleMenuItem.Size = new System.Drawing.Size(219, 22);
			this.ToolsSAAMIRifleMenuItem.Text = "Centerfire Rifle";
			// 
			// ToolsSAAMIRifleSpecsMenuItem
			// 
			this.ToolsSAAMIRifleSpecsMenuItem.Name = "ToolsSAAMIRifleSpecsMenuItem";
			this.ToolsSAAMIRifleSpecsMenuItem.Size = new System.Drawing.Size(203, 22);
			this.ToolsSAAMIRifleSpecsMenuItem.Text = "Standards && Drawings";
			// 
			// ToolsSAAMIRifleVelocityDataMenuItem
			// 
			this.ToolsSAAMIRifleVelocityDataMenuItem.Name = "ToolsSAAMIRifleVelocityDataMenuItem";
			this.ToolsSAAMIRifleVelocityDataMenuItem.Size = new System.Drawing.Size(203, 22);
			this.ToolsSAAMIRifleVelocityDataMenuItem.Text = "Velocity && Pressure Data";
			// 
			// ToolsSAAMIRimfireMenuItem
			// 
			this.ToolsSAAMIRimfireMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolsSAAMIRimfireSpecsMenuItem});
			this.ToolsSAAMIRimfireMenuItem.Name = "ToolsSAAMIRimfireMenuItem";
			this.ToolsSAAMIRimfireMenuItem.Size = new System.Drawing.Size(219, 22);
			this.ToolsSAAMIRimfireMenuItem.Text = "Rimfire";
			// 
			// ToolsSAAMIRimfireSpecsMenuItem
			// 
			this.ToolsSAAMIRimfireSpecsMenuItem.Name = "ToolsSAAMIRimfireSpecsMenuItem";
			this.ToolsSAAMIRimfireSpecsMenuItem.Size = new System.Drawing.Size(191, 22);
			this.ToolsSAAMIRimfireSpecsMenuItem.Text = "Standards && Drawings";
			// 
			// ToolsSAAMIShotshellMenuItem
			// 
			this.ToolsSAAMIShotshellMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolsSAAMIShotshellSpecsMenuItem});
			this.ToolsSAAMIShotshellMenuItem.Name = "ToolsSAAMIShotshellMenuItem";
			this.ToolsSAAMIShotshellMenuItem.Size = new System.Drawing.Size(219, 22);
			this.ToolsSAAMIShotshellMenuItem.Text = "Shotshell";
			// 
			// ToolsSAAMIShotshellSpecsMenuItem
			// 
			this.ToolsSAAMIShotshellSpecsMenuItem.Name = "ToolsSAAMIShotshellSpecsMenuItem";
			this.ToolsSAAMIShotshellSpecsMenuItem.Size = new System.Drawing.Size(191, 22);
			this.ToolsSAAMIShotshellSpecsMenuItem.Text = "Standards && Drawings";
			// 
			// toolStripSeparator7
			// 
			this.toolStripSeparator7.Name = "toolStripSeparator7";
			this.toolStripSeparator7.Size = new System.Drawing.Size(216, 6);
			// 
			// ToolsSAAMIBrochuresMenuItem
			// 
			this.ToolsSAAMIBrochuresMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolsSAAMIFactsMenuItem,
            this.ToolsSAAMIAmmoFiresMenuItem,
            this.ToolsSAAMIPrimersMenuItem,
            this.ToolsSAAMISafeAmmoStorageMenuItem,
            this.ToolsSAAMISmokelessPowderMenuItem,
            this.ToolsSAAMISportingFirearmsMenuItem,
            this.ToolsSAAMIUnsafeArmsAmmoMenuItem});
			this.ToolsSAAMIBrochuresMenuItem.Name = "ToolsSAAMIBrochuresMenuItem";
			this.ToolsSAAMIBrochuresMenuItem.Size = new System.Drawing.Size(219, 22);
			this.ToolsSAAMIBrochuresMenuItem.Text = "Informational Brochures";
			// 
			// ToolsSAAMIFactsMenuItem
			// 
			this.ToolsSAAMIFactsMenuItem.Name = "ToolsSAAMIFactsMenuItem";
			this.ToolsSAAMIFactsMenuItem.Size = new System.Drawing.Size(281, 22);
			this.ToolsSAAMIFactsMenuItem.Text = "About SAAMI";
			// 
			// ToolsSAAMIAmmoFiresMenuItem
			// 
			this.ToolsSAAMIAmmoFiresMenuItem.Name = "ToolsSAAMIAmmoFiresMenuItem";
			this.ToolsSAAMIAmmoFiresMenuItem.Size = new System.Drawing.Size(281, 22);
			this.ToolsSAAMIAmmoFiresMenuItem.Text = "Facts about Sporting Ammunition Fires";
			// 
			// ToolsSAAMIPrimersMenuItem
			// 
			this.ToolsSAAMIPrimersMenuItem.Name = "ToolsSAAMIPrimersMenuItem";
			this.ToolsSAAMIPrimersMenuItem.Size = new System.Drawing.Size(281, 22);
			this.ToolsSAAMIPrimersMenuItem.Text = "Primers";
			// 
			// ToolsSAAMISafeAmmoStorageMenuItem
			// 
			this.ToolsSAAMISafeAmmoStorageMenuItem.Name = "ToolsSAAMISafeAmmoStorageMenuItem";
			this.ToolsSAAMISafeAmmoStorageMenuItem.Size = new System.Drawing.Size(281, 22);
			this.ToolsSAAMISafeAmmoStorageMenuItem.Text = "Safe Ammo Storage && Handlinig";
			// 
			// ToolsSAAMISmokelessPowderMenuItem
			// 
			this.ToolsSAAMISmokelessPowderMenuItem.Name = "ToolsSAAMISmokelessPowderMenuItem";
			this.ToolsSAAMISmokelessPowderMenuItem.Size = new System.Drawing.Size(281, 22);
			this.ToolsSAAMISmokelessPowderMenuItem.Text = "Smokeless Powder";
			// 
			// ToolsSAAMISportingFirearmsMenuItem
			// 
			this.ToolsSAAMISportingFirearmsMenuItem.Name = "ToolsSAAMISportingFirearmsMenuItem";
			this.ToolsSAAMISportingFirearmsMenuItem.Size = new System.Drawing.Size(281, 22);
			this.ToolsSAAMISportingFirearmsMenuItem.Text = "Sporting Firearms";
			// 
			// ToolsSAAMIUnsafeArmsAmmoMenuItem
			// 
			this.ToolsSAAMIUnsafeArmsAmmoMenuItem.Name = "ToolsSAAMIUnsafeArmsAmmoMenuItem";
			this.ToolsSAAMIUnsafeArmsAmmoMenuItem.Size = new System.Drawing.Size(281, 22);
			this.ToolsSAAMIUnsafeArmsAmmoMenuItem.Text = "Unsafe Arms/Ammo Combinations";
			// 
			// HelpMenuItem
			// 
			this.HelpMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.HelpSupportForumMenuItem,
            this.HelpVideoMenuItem,
            this.HelpNotesMenuItem,
            this.toolStripSeparator8,
            this.HelpPurchaseMenuItem,
            this.HelpProgramUpdateMenuItem,
            this.HelpDataUpdateMenuItem,
            this.toolStripSeparator5,
            this.HelpAboutMenuItem});
			this.HelpMenuItem.Name = "HelpMenuItem";
			this.HelpMenuItem.Size = new System.Drawing.Size(44, 20);
			this.HelpMenuItem.Text = "&Help";
			// 
			// HelpSupportForumMenuItem
			// 
			this.HelpSupportForumMenuItem.Name = "HelpSupportForumMenuItem";
			this.HelpSupportForumMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F1)));
			this.HelpSupportForumMenuItem.Size = new System.Drawing.Size(264, 22);
			this.HelpSupportForumMenuItem.Text = "&Support Forum";
			// 
			// HelpVideoMenuItem
			// 
			this.HelpVideoMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.HelpVideoBulletSelectionMenuItem,
            this.HelpVideoCrimpingMenuItem,
            this.HelpVideoSDBCMenuItem,
            this.HelpVideoHeadspaceMenuItem,
            this.toolStripSeparator9,
            this.HelpVideoRWMenuItem});
			this.HelpVideoMenuItem.Name = "HelpVideoMenuItem";
			this.HelpVideoMenuItem.Size = new System.Drawing.Size(264, 22);
			this.HelpVideoMenuItem.Text = "&Video Tutorials";
			// 
			// HelpVideoBulletSelectionMenuItem
			// 
			this.HelpVideoBulletSelectionMenuItem.Name = "HelpVideoBulletSelectionMenuItem";
			this.HelpVideoBulletSelectionMenuItem.Size = new System.Drawing.Size(283, 22);
			this.HelpVideoBulletSelectionMenuItem.Text = "Bullet Selection";
			// 
			// HelpVideoCrimpingMenuItem
			// 
			this.HelpVideoCrimpingMenuItem.Name = "HelpVideoCrimpingMenuItem";
			this.HelpVideoCrimpingMenuItem.Size = new System.Drawing.Size(283, 22);
			this.HelpVideoCrimpingMenuItem.Text = "Crimping Handgun and Rifle Cartridges";
			// 
			// HelpVideoSDBCMenuItem
			// 
			this.HelpVideoSDBCMenuItem.Name = "HelpVideoSDBCMenuItem";
			this.HelpVideoSDBCMenuItem.Size = new System.Drawing.Size(283, 22);
			this.HelpVideoSDBCMenuItem.Text = "Sectional Density && Ballistic Coefficient";
			// 
			// HelpVideoHeadspaceMenuItem
			// 
			this.HelpVideoHeadspaceMenuItem.Name = "HelpVideoHeadspaceMenuItem";
			this.HelpVideoHeadspaceMenuItem.Size = new System.Drawing.Size(283, 22);
			this.HelpVideoHeadspaceMenuItem.Text = "Understanding Headspace";
			// 
			// toolStripSeparator9
			// 
			this.toolStripSeparator9.Name = "toolStripSeparator9";
			this.toolStripSeparator9.Size = new System.Drawing.Size(280, 6);
			// 
			// HelpVideoRWMenuItem
			// 
			this.HelpVideoRWMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.HelpVideoRWOperationMenuItem,
            this.HelpVideoRWLoadDataMenuItem,
            this.HelpVideoRWBatchEditorMenuItem,
            this.HelpVideoRWInventoryMenuItem,
            this.HelpVideoRWBallisticsCalculatorMenuItem});
			this.HelpVideoRWMenuItem.Name = "HelpVideoRWMenuItem";
			this.HelpVideoRWMenuItem.Size = new System.Drawing.Size(283, 22);
			this.HelpVideoRWMenuItem.Text = "Reloader\'s WorkShop";
			// 
			// HelpVideoRWOperationMenuItem
			// 
			this.HelpVideoRWOperationMenuItem.Name = "HelpVideoRWOperationMenuItem";
			this.HelpVideoRWOperationMenuItem.Size = new System.Drawing.Size(217, 22);
			this.HelpVideoRWOperationMenuItem.Text = "Part 1 - General Operation";
			// 
			// HelpVideoRWLoadDataMenuItem
			// 
			this.HelpVideoRWLoadDataMenuItem.Name = "HelpVideoRWLoadDataMenuItem";
			this.HelpVideoRWLoadDataMenuItem.Size = new System.Drawing.Size(217, 22);
			this.HelpVideoRWLoadDataMenuItem.Text = "Part 2 - Load Data";
			// 
			// HelpVideoRWBatchEditorMenuItem
			// 
			this.HelpVideoRWBatchEditorMenuItem.Name = "HelpVideoRWBatchEditorMenuItem";
			this.HelpVideoRWBatchEditorMenuItem.Size = new System.Drawing.Size(217, 22);
			this.HelpVideoRWBatchEditorMenuItem.Text = "Part 2a - Batch Editor";
			// 
			// HelpVideoRWInventoryMenuItem
			// 
			this.HelpVideoRWInventoryMenuItem.Name = "HelpVideoRWInventoryMenuItem";
			this.HelpVideoRWInventoryMenuItem.Size = new System.Drawing.Size(217, 22);
			this.HelpVideoRWInventoryMenuItem.Text = "Part 3 - Inventory Control";
			// 
			// HelpVideoRWBallisticsCalculatorMenuItem
			// 
			this.HelpVideoRWBallisticsCalculatorMenuItem.Name = "HelpVideoRWBallisticsCalculatorMenuItem";
			this.HelpVideoRWBallisticsCalculatorMenuItem.Size = new System.Drawing.Size(217, 22);
			this.HelpVideoRWBallisticsCalculatorMenuItem.Text = "Part 4 - Ballistics Calculator";
			// 
			// HelpNotesMenuItem
			// 
			this.HelpNotesMenuItem.Name = "HelpNotesMenuItem";
			this.HelpNotesMenuItem.Size = new System.Drawing.Size(264, 22);
			this.HelpNotesMenuItem.Text = "Show Release &Notes";
			// 
			// toolStripSeparator8
			// 
			this.toolStripSeparator8.Name = "toolStripSeparator8";
			this.toolStripSeparator8.Size = new System.Drawing.Size(261, 6);
			// 
			// HelpPurchaseMenuItem
			// 
			this.HelpPurchaseMenuItem.Name = "HelpPurchaseMenuItem";
			this.HelpPurchaseMenuItem.Size = new System.Drawing.Size(264, 22);
			this.HelpPurchaseMenuItem.Text = "Purchase a Single-User License";
			// 
			// HelpProgramUpdateMenuItem
			// 
			this.HelpProgramUpdateMenuItem.Name = "HelpProgramUpdateMenuItem";
			this.HelpProgramUpdateMenuItem.Size = new System.Drawing.Size(264, 22);
			this.HelpProgramUpdateMenuItem.Text = "Check for &Program Updates";
			// 
			// HelpDataUpdateMenuItem
			// 
			this.HelpDataUpdateMenuItem.Name = "HelpDataUpdateMenuItem";
			this.HelpDataUpdateMenuItem.Size = new System.Drawing.Size(264, 22);
			this.HelpDataUpdateMenuItem.Text = "Check for &Data Updates";
			// 
			// toolStripSeparator5
			// 
			this.toolStripSeparator5.Name = "toolStripSeparator5";
			this.toolStripSeparator5.Size = new System.Drawing.Size(261, 6);
			// 
			// HelpAboutMenuItem
			// 
			this.HelpAboutMenuItem.Name = "HelpAboutMenuItem";
			this.HelpAboutMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
			this.HelpAboutMenuItem.Size = new System.Drawing.Size(264, 22);
			this.HelpAboutMenuItem.Text = "&About Reloader\'s WorkShop";
			// 
			// BallisticsTab
			// 
			this.BallisticsTab.AutoScroll = true;
			this.BallisticsTab.Controls.Add(this.WindDriftChartGroup);
			this.BallisticsTab.Controls.Add(this.BulletDropChartGroup);
			this.BallisticsTab.Controls.Add(this.DropTableGroup);
			this.BallisticsTab.Controls.Add(this.BallisticsDatabaseGroupBox);
			this.BallisticsTab.Controls.Add(this.BallisticsInputDataGroupBox);
			this.BallisticsTab.Location = new System.Drawing.Point(4, 22);
			this.BallisticsTab.Margin = new System.Windows.Forms.Padding(2);
			this.BallisticsTab.Name = "BallisticsTab";
			this.BallisticsTab.Size = new System.Drawing.Size(1465, 1025);
			this.BallisticsTab.TabIndex = 7;
			this.BallisticsTab.Text = "Ballistics";
			this.BallisticsTab.ToolTipText = "Get ballistics data (drop charts) for your loads.";
			this.BallisticsTab.UseVisualStyleBackColor = true;
			// 
			// WindDriftChartGroup
			// 
			this.WindDriftChartGroup.BackColor = System.Drawing.SystemColors.Control;
			this.WindDriftChartGroup.Controls.Add(this.label6);
			this.WindDriftChartGroup.Controls.Add(this.ResetWindageTurretButton);
			this.WindDriftChartGroup.Controls.Add(this.DriftTurretTypeLabel);
			this.WindDriftChartGroup.Controls.Add(this.label23);
			this.WindDriftChartGroup.Controls.Add(this.WindageTurretUpDown);
			this.WindDriftChartGroup.Controls.Add(this.ReferenceDataDriftLegendLabel);
			this.WindDriftChartGroup.Controls.Add(this.CurrentDataDriftLegendLabel);
			this.WindDriftChartGroup.Controls.Add(this.ShowWindDriftRangeMarkersCheckBox);
			this.WindDriftChartGroup.Controls.Add(this.WindDriftChart);
			this.WindDriftChartGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.WindDriftChartGroup.ForeColor = System.Drawing.SystemColors.HotTrack;
			this.WindDriftChartGroup.Location = new System.Drawing.Point(7, 780);
			this.WindDriftChartGroup.Name = "WindDriftChartGroup";
			this.WindDriftChartGroup.Size = new System.Drawing.Size(1444, 315);
			this.WindDriftChartGroup.TabIndex = 4;
			this.WindDriftChartGroup.TabStop = false;
			this.WindDriftChartGroup.Text = "Wind Drift Chart";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label6.Location = new System.Drawing.Point(604, 264);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(124, 13);
			this.label6.TabIndex = 55;
			this.label6.Text = "(Pos = Left, Neg = Right)";
			// 
			// ResetWindageTurretButton
			// 
			this.ResetWindageTurretButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ResetWindageTurretButton.ForeColor = System.Drawing.SystemColors.ControlText;
			this.ResetWindageTurretButton.Location = new System.Drawing.Point(736, 269);
			this.ResetWindageTurretButton.Name = "ResetWindageTurretButton";
			this.ResetWindageTurretButton.Size = new System.Drawing.Size(75, 23);
			this.ResetWindageTurretButton.TabIndex = 19;
			this.ResetWindageTurretButton.Text = "Reset";
			this.ResetWindageTurretButton.UseVisualStyleBackColor = true;
			// 
			// DriftTurretTypeLabel
			// 
			this.DriftTurretTypeLabel.AutoSize = true;
			this.DriftTurretTypeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.DriftTurretTypeLabel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.DriftTurretTypeLabel.Location = new System.Drawing.Point(799, 247);
			this.DriftTurretTypeLabel.Name = "DriftTurretTypeLabel";
			this.DriftTurretTypeLabel.Size = new System.Drawing.Size(31, 13);
			this.DriftTurretTypeLabel.TabIndex = 18;
			this.DriftTurretTypeLabel.Text = "MOA";
			// 
			// label23
			// 
			this.label23.AutoSize = true;
			this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label23.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label23.Location = new System.Drawing.Point(615, 247);
			this.label23.Name = "label23";
			this.label23.Size = new System.Drawing.Size(115, 13);
			this.label23.TabIndex = 17;
			this.label23.Text = "Windage Turret Clicks:";
			// 
			// WindageTurretUpDown
			// 
			this.WindageTurretUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.WindageTurretUpDown.Location = new System.Drawing.Point(736, 245);
			this.WindageTurretUpDown.Name = "WindageTurretUpDown";
			this.WindageTurretUpDown.Size = new System.Drawing.Size(57, 20);
			this.WindageTurretUpDown.TabIndex = 0;
			// 
			// ReferenceDataDriftLegendLabel
			// 
			this.ReferenceDataDriftLegendLabel.AutoSize = true;
			this.ReferenceDataDriftLegendLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ReferenceDataDriftLegendLabel.ForeColor = System.Drawing.Color.Red;
			this.ReferenceDataDriftLegendLabel.Location = new System.Drawing.Point(13, 269);
			this.ReferenceDataDriftLegendLabel.Name = "ReferenceDataDriftLegendLabel";
			this.ReferenceDataDriftLegendLabel.Size = new System.Drawing.Size(97, 13);
			this.ReferenceDataDriftLegendLabel.TabIndex = 10;
			this.ReferenceDataDriftLegendLabel.Text = "Reference Data";
			// 
			// CurrentDataDriftLegendLabel
			// 
			this.CurrentDataDriftLegendLabel.AutoSize = true;
			this.CurrentDataDriftLegendLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.CurrentDataDriftLegendLabel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.CurrentDataDriftLegendLabel.Location = new System.Drawing.Point(31, 247);
			this.CurrentDataDriftLegendLabel.Name = "CurrentDataDriftLegendLabel";
			this.CurrentDataDriftLegendLabel.Size = new System.Drawing.Size(79, 13);
			this.CurrentDataDriftLegendLabel.TabIndex = 8;
			this.CurrentDataDriftLegendLabel.Text = "Current Data";
			// 
			// ShowWindDriftRangeMarkersCheckBox
			// 
			this.ShowWindDriftRangeMarkersCheckBox.AutoSize = true;
			this.ShowWindDriftRangeMarkersCheckBox.Checked = true;
			this.ShowWindDriftRangeMarkersCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.ShowWindDriftRangeMarkersCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ShowWindDriftRangeMarkersCheckBox.ForeColor = System.Drawing.SystemColors.ControlText;
			this.ShowWindDriftRangeMarkersCheckBox.Location = new System.Drawing.Point(1107, 246);
			this.ShowWindDriftRangeMarkersCheckBox.Name = "ShowWindDriftRangeMarkersCheckBox";
			this.ShowWindDriftRangeMarkersCheckBox.Size = new System.Drawing.Size(129, 17);
			this.ShowWindDriftRangeMarkersCheckBox.TabIndex = 1;
			this.ShowWindDriftRangeMarkersCheckBox.Text = "Show Range Markers";
			this.ShowWindDriftRangeMarkersCheckBox.UseVisualStyleBackColor = true;
			// 
			// WindDriftChart
			// 
			this.WindDriftChart.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.WindDriftChart.Location = new System.Drawing.Point(6, 30);
			this.WindDriftChart.Name = "WindDriftChart";
			this.WindDriftChart.Size = new System.Drawing.Size(1426, 210);
			this.WindDriftChart.TabIndex = 0;
			this.WindDriftChart.TabStop = false;
			// 
			// BulletDropChartGroup
			// 
			this.BulletDropChartGroup.BackColor = System.Drawing.SystemColors.Control;
			this.BulletDropChartGroup.Controls.Add(this.BallisticsSoundSpeedLabel);
			this.BulletDropChartGroup.Controls.Add(this.label35);
			this.BulletDropChartGroup.Controls.Add(this.label5);
			this.BulletDropChartGroup.Controls.Add(this.ResetElevationTurretButton);
			this.BulletDropChartGroup.Controls.Add(this.TurretTypeLabel);
			this.BulletDropChartGroup.Controls.Add(this.BallisticsMuzzleHeightLabel);
			this.BulletDropChartGroup.Controls.Add(this.label21);
			this.BulletDropChartGroup.Controls.Add(this.ElevationTurretUpDown);
			this.BulletDropChartGroup.Controls.Add(this.ShowTransonicMarkersCheckBox);
			this.BulletDropChartGroup.Controls.Add(this.ShowApexMarkerCheckBox);
			this.BulletDropChartGroup.Controls.Add(this.ReferenceDataLegendLabel);
			this.BulletDropChartGroup.Controls.Add(this.CurrentDataLegendLabel);
			this.BulletDropChartGroup.Controls.Add(this.ShowGroundStrikeMarkerCheckBox);
			this.BulletDropChartGroup.Controls.Add(this.ShowDropChartRangeMarkersCheckBox);
			this.BulletDropChartGroup.Controls.Add(this.BulletDropChart);
			this.BulletDropChartGroup.Controls.Add(this.label4);
			this.BulletDropChartGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BulletDropChartGroup.ForeColor = System.Drawing.SystemColors.HotTrack;
			this.BulletDropChartGroup.Location = new System.Drawing.Point(7, 475);
			this.BulletDropChartGroup.Name = "BulletDropChartGroup";
			this.BulletDropChartGroup.Size = new System.Drawing.Size(1444, 299);
			this.BulletDropChartGroup.TabIndex = 3;
			this.BulletDropChartGroup.TabStop = false;
			this.BulletDropChartGroup.Text = "Bullet Drop Chart";
			// 
			// BallisticsSoundSpeedLabel
			// 
			this.BallisticsSoundSpeedLabel.AutoSize = true;
			this.BallisticsSoundSpeedLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BallisticsSoundSpeedLabel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.BallisticsSoundSpeedLabel.Location = new System.Drawing.Point(983, 269);
			this.BallisticsSoundSpeedLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.BallisticsSoundSpeedLabel.Name = "BallisticsSoundSpeedLabel";
			this.BallisticsSoundSpeedLabel.Size = new System.Drawing.Size(74, 13);
			this.BallisticsSoundSpeedLabel.TabIndex = 56;
			this.BallisticsSoundSpeedLabel.Text = "1132.22 fps";
			// 
			// label35
			// 
			this.label35.AutoSize = true;
			this.label35.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label35.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label35.Location = new System.Drawing.Point(892, 269);
			this.label35.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label35.Name = "label35";
			this.label35.Size = new System.Drawing.Size(87, 13);
			this.label35.TabIndex = 55;
			this.label35.Text = "Speed of Sound:";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label5.Location = new System.Drawing.Point(607, 264);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(123, 13);
			this.label5.TabIndex = 54;
			this.label5.Text = "(Pos = Up, Neg = Down)";
			// 
			// ResetElevationTurretButton
			// 
			this.ResetElevationTurretButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ResetElevationTurretButton.ForeColor = System.Drawing.SystemColors.ControlText;
			this.ResetElevationTurretButton.Location = new System.Drawing.Point(736, 269);
			this.ResetElevationTurretButton.Name = "ResetElevationTurretButton";
			this.ResetElevationTurretButton.Size = new System.Drawing.Size(75, 23);
			this.ResetElevationTurretButton.TabIndex = 1;
			this.ResetElevationTurretButton.Text = "Reset";
			this.ResetElevationTurretButton.UseVisualStyleBackColor = true;
			// 
			// TurretTypeLabel
			// 
			this.TurretTypeLabel.AutoSize = true;
			this.TurretTypeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.TurretTypeLabel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.TurretTypeLabel.Location = new System.Drawing.Point(799, 247);
			this.TurretTypeLabel.Name = "TurretTypeLabel";
			this.TurretTypeLabel.Size = new System.Drawing.Size(31, 13);
			this.TurretTypeLabel.TabIndex = 14;
			this.TurretTypeLabel.Text = "MOA";
			// 
			// BallisticsMuzzleHeightLabel
			// 
			this.BallisticsMuzzleHeightLabel.AutoSize = true;
			this.BallisticsMuzzleHeightLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BallisticsMuzzleHeightLabel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.BallisticsMuzzleHeightLabel.Location = new System.Drawing.Point(983, 247);
			this.BallisticsMuzzleHeightLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.BallisticsMuzzleHeightLabel.Name = "BallisticsMuzzleHeightLabel";
			this.BallisticsMuzzleHeightLabel.Size = new System.Drawing.Size(39, 13);
			this.BallisticsMuzzleHeightLabel.TabIndex = 53;
			this.BallisticsMuzzleHeightLabel.Text = "60 in.";
			// 
			// label21
			// 
			this.label21.AutoSize = true;
			this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label21.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label21.Location = new System.Drawing.Point(614, 247);
			this.label21.Name = "label21";
			this.label21.Size = new System.Drawing.Size(116, 13);
			this.label21.TabIndex = 13;
			this.label21.Text = "Elevation Turret Clicks:";
			// 
			// ElevationTurretUpDown
			// 
			this.ElevationTurretUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ElevationTurretUpDown.Location = new System.Drawing.Point(736, 245);
			this.ElevationTurretUpDown.Name = "ElevationTurretUpDown";
			this.ElevationTurretUpDown.Size = new System.Drawing.Size(57, 20);
			this.ElevationTurretUpDown.TabIndex = 0;
			// 
			// ShowTransonicMarkersCheckBox
			// 
			this.ShowTransonicMarkersCheckBox.AutoSize = true;
			this.ShowTransonicMarkersCheckBox.Checked = true;
			this.ShowTransonicMarkersCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.ShowTransonicMarkersCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ShowTransonicMarkersCheckBox.ForeColor = System.Drawing.SystemColors.ControlText;
			this.ShowTransonicMarkersCheckBox.Location = new System.Drawing.Point(1285, 269);
			this.ShowTransonicMarkersCheckBox.Name = "ShowTransonicMarkersCheckBox";
			this.ShowTransonicMarkersCheckBox.Size = new System.Drawing.Size(144, 17);
			this.ShowTransonicMarkersCheckBox.TabIndex = 5;
			this.ShowTransonicMarkersCheckBox.Text = "Show Transonic Markers";
			this.ShowTransonicMarkersCheckBox.UseVisualStyleBackColor = true;
			// 
			// ShowApexMarkerCheckBox
			// 
			this.ShowApexMarkerCheckBox.AutoSize = true;
			this.ShowApexMarkerCheckBox.Checked = true;
			this.ShowApexMarkerCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.ShowApexMarkerCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ShowApexMarkerCheckBox.ForeColor = System.Drawing.SystemColors.ControlText;
			this.ShowApexMarkerCheckBox.Location = new System.Drawing.Point(1285, 246);
			this.ShowApexMarkerCheckBox.Name = "ShowApexMarkerCheckBox";
			this.ShowApexMarkerCheckBox.Size = new System.Drawing.Size(129, 17);
			this.ShowApexMarkerCheckBox.TabIndex = 4;
			this.ShowApexMarkerCheckBox.Text = "Show Apogee Marker";
			this.ShowApexMarkerCheckBox.UseVisualStyleBackColor = true;
			// 
			// ReferenceDataLegendLabel
			// 
			this.ReferenceDataLegendLabel.AutoSize = true;
			this.ReferenceDataLegendLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ReferenceDataLegendLabel.ForeColor = System.Drawing.Color.Red;
			this.ReferenceDataLegendLabel.Location = new System.Drawing.Point(13, 269);
			this.ReferenceDataLegendLabel.Name = "ReferenceDataLegendLabel";
			this.ReferenceDataLegendLabel.Size = new System.Drawing.Size(97, 13);
			this.ReferenceDataLegendLabel.TabIndex = 7;
			this.ReferenceDataLegendLabel.Text = "Reference Data";
			// 
			// CurrentDataLegendLabel
			// 
			this.CurrentDataLegendLabel.AutoSize = true;
			this.CurrentDataLegendLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.CurrentDataLegendLabel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.CurrentDataLegendLabel.Location = new System.Drawing.Point(31, 247);
			this.CurrentDataLegendLabel.Name = "CurrentDataLegendLabel";
			this.CurrentDataLegendLabel.Size = new System.Drawing.Size(79, 13);
			this.CurrentDataLegendLabel.TabIndex = 5;
			this.CurrentDataLegendLabel.Text = "Current Data";
			// 
			// ShowGroundStrikeMarkerCheckBox
			// 
			this.ShowGroundStrikeMarkerCheckBox.AutoSize = true;
			this.ShowGroundStrikeMarkerCheckBox.Checked = true;
			this.ShowGroundStrikeMarkerCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.ShowGroundStrikeMarkerCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ShowGroundStrikeMarkerCheckBox.ForeColor = System.Drawing.SystemColors.ControlText;
			this.ShowGroundStrikeMarkerCheckBox.Location = new System.Drawing.Point(1105, 269);
			this.ShowGroundStrikeMarkerCheckBox.Name = "ShowGroundStrikeMarkerCheckBox";
			this.ShowGroundStrikeMarkerCheckBox.Size = new System.Drawing.Size(157, 17);
			this.ShowGroundStrikeMarkerCheckBox.TabIndex = 3;
			this.ShowGroundStrikeMarkerCheckBox.Text = "Show Ground Strike Marker";
			this.ShowGroundStrikeMarkerCheckBox.UseVisualStyleBackColor = true;
			// 
			// ShowDropChartRangeMarkersCheckBox
			// 
			this.ShowDropChartRangeMarkersCheckBox.AutoSize = true;
			this.ShowDropChartRangeMarkersCheckBox.Checked = true;
			this.ShowDropChartRangeMarkersCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.ShowDropChartRangeMarkersCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ShowDropChartRangeMarkersCheckBox.ForeColor = System.Drawing.SystemColors.ControlText;
			this.ShowDropChartRangeMarkersCheckBox.Location = new System.Drawing.Point(1107, 246);
			this.ShowDropChartRangeMarkersCheckBox.Name = "ShowDropChartRangeMarkersCheckBox";
			this.ShowDropChartRangeMarkersCheckBox.Size = new System.Drawing.Size(129, 17);
			this.ShowDropChartRangeMarkersCheckBox.TabIndex = 2;
			this.ShowDropChartRangeMarkersCheckBox.Text = "Show Range Markers";
			this.ShowDropChartRangeMarkersCheckBox.UseVisualStyleBackColor = true;
			// 
			// BulletDropChart
			// 
			this.BulletDropChart.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.BulletDropChart.Location = new System.Drawing.Point(6, 30);
			this.BulletDropChart.Name = "BulletDropChart";
			this.BulletDropChart.Size = new System.Drawing.Size(1426, 210);
			this.BulletDropChart.TabIndex = 0;
			this.BulletDropChart.TabStop = false;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label4.Location = new System.Drawing.Point(902, 247);
			this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(77, 13);
			this.label4.TabIndex = 49;
			this.label4.Text = "Muzzle Height:";
			// 
			// DropTableGroup
			// 
			this.DropTableGroup.BackColor = System.Drawing.SystemColors.Control;
			this.DropTableGroup.Controls.Add(this.BallisticsPrintButton);
			this.DropTableGroup.Controls.Add(this.BallisticsUseSFCheckBox);
			this.DropTableGroup.Controls.Add(this.CompareToReferenceBulletCheckBox);
			this.DropTableGroup.Controls.Add(this.BallisticsListView);
			this.DropTableGroup.Controls.Add(this.label17);
			this.DropTableGroup.Controls.Add(this.MuzzleVelocityMeasurementLabel);
			this.DropTableGroup.Controls.Add(this.BallisticsMuzzleVelocityTextBox);
			this.DropTableGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.DropTableGroup.ForeColor = System.Drawing.SystemColors.HotTrack;
			this.DropTableGroup.Location = new System.Drawing.Point(711, 0);
			this.DropTableGroup.Name = "DropTableGroup";
			this.DropTableGroup.Size = new System.Drawing.Size(740, 469);
			this.DropTableGroup.TabIndex = 2;
			this.DropTableGroup.TabStop = false;
			this.DropTableGroup.Text = "Bullet Trajectory Table";
			// 
			// BallisticsPrintButton
			// 
			this.BallisticsPrintButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BallisticsPrintButton.ForeColor = System.Drawing.SystemColors.ControlText;
			this.BallisticsPrintButton.Location = new System.Drawing.Point(333, 414);
			this.BallisticsPrintButton.Name = "BallisticsPrintButton";
			this.BallisticsPrintButton.Size = new System.Drawing.Size(75, 23);
			this.BallisticsPrintButton.TabIndex = 11;
			this.BallisticsPrintButton.Text = "Print";
			this.BallisticsPrintButton.UseVisualStyleBackColor = true;
			// 
			// BallisticsUseSFCheckBox
			// 
			this.BallisticsUseSFCheckBox.AutoSize = true;
			this.BallisticsUseSFCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BallisticsUseSFCheckBox.ForeColor = System.Drawing.SystemColors.ControlText;
			this.BallisticsUseSFCheckBox.Location = new System.Drawing.Point(538, 443);
			this.BallisticsUseSFCheckBox.Name = "BallisticsUseSFCheckBox";
			this.BallisticsUseSFCheckBox.Size = new System.Drawing.Size(142, 17);
			this.BallisticsUseSFCheckBox.TabIndex = 1;
			this.BallisticsUseSFCheckBox.Text = "Calculate Stability Factor";
			this.BallisticsUseSFCheckBox.UseVisualStyleBackColor = true;
			// 
			// CompareToReferenceBulletCheckBox
			// 
			this.CompareToReferenceBulletCheckBox.AutoSize = true;
			this.CompareToReferenceBulletCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.CompareToReferenceBulletCheckBox.ForeColor = System.Drawing.SystemColors.ControlText;
			this.CompareToReferenceBulletCheckBox.Location = new System.Drawing.Point(538, 418);
			this.CompareToReferenceBulletCheckBox.Name = "CompareToReferenceBulletCheckBox";
			this.CompareToReferenceBulletCheckBox.Size = new System.Drawing.Size(163, 17);
			this.CompareToReferenceBulletCheckBox.TabIndex = 2;
			this.CompareToReferenceBulletCheckBox.Text = "Compare To Reference Data";
			this.CompareToReferenceBulletCheckBox.UseVisualStyleBackColor = true;
			// 
			// BallisticsListView
			// 
			this.BallisticsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.RangeHeader,
            this.DropHeader,
            this.DropMOAHeader,
            this.WindDriftHeader,
            this.WindDriftMOAHeader,
            this.VelocityHeader,
            this.EnergyHeader,
            this.TimeOfFlightHeader,
            this.ScopeClickHeader,
            this.SFHeader,
            this.AdjBCHeader});
			this.BallisticsListView.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BallisticsListView.FullRowSelect = true;
			this.BallisticsListView.GridLines = true;
			this.BallisticsListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.BallisticsListView.Location = new System.Drawing.Point(6, 27);
			this.BallisticsListView.Margin = new System.Windows.Forms.Padding(2);
			this.BallisticsListView.MultiSelect = false;
			this.BallisticsListView.Name = "BallisticsListView";
			this.BallisticsListView.Size = new System.Drawing.Size(720, 377);
			this.BallisticsListView.TabIndex = 2;
			this.BallisticsListView.UseCompatibleStateImageBehavior = false;
			this.BallisticsListView.View = System.Windows.Forms.View.Details;
			// 
			// RangeHeader
			// 
			this.RangeHeader.Text = "Range";
			this.RangeHeader.Width = 75;
			// 
			// DropHeader
			// 
			this.DropHeader.Text = "Drop (in)";
			this.DropHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.DropHeader.Width = 70;
			// 
			// DropMOAHeader
			// 
			this.DropMOAHeader.Text = "Drop";
			this.DropMOAHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.DropMOAHeader.Width = 85;
			// 
			// WindDriftHeader
			// 
			this.WindDriftHeader.Text = "Wind Drift (in)";
			this.WindDriftHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.WindDriftHeader.Width = 90;
			// 
			// WindDriftMOAHeader
			// 
			this.WindDriftMOAHeader.Text = "Wind Drift";
			this.WindDriftMOAHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.WindDriftMOAHeader.Width = 110;
			// 
			// VelocityHeader
			// 
			this.VelocityHeader.Text = "Velocity (fps)";
			this.VelocityHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.VelocityHeader.Width = 90;
			// 
			// EnergyHeader
			// 
			this.EnergyHeader.Text = "Energy (ft. lbs)";
			this.EnergyHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.EnergyHeader.Width = 90;
			// 
			// TimeOfFlightHeader
			// 
			this.TimeOfFlightHeader.Text = "Time (sec)";
			this.TimeOfFlightHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.TimeOfFlightHeader.Width = 75;
			// 
			// ScopeClickHeader
			// 
			this.ScopeClickHeader.Text = "Turret Clicks";
			this.ScopeClickHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.ScopeClickHeader.Width = 120;
			// 
			// SFHeader
			// 
			this.SFHeader.Text = "Sg";
			this.SFHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// AdjBCHeader
			// 
			this.AdjBCHeader.Text = "Adj. BC";
			this.AdjBCHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label17
			// 
			this.label17.AutoSize = true;
			this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label17.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label17.Location = new System.Drawing.Point(43, 419);
			this.label17.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(83, 13);
			this.label17.TabIndex = 10;
			this.label17.Text = "Muzzle Velocity:";
			// 
			// MuzzleVelocityMeasurementLabel
			// 
			this.MuzzleVelocityMeasurementLabel.AutoSize = true;
			this.MuzzleVelocityMeasurementLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.MuzzleVelocityMeasurementLabel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.MuzzleVelocityMeasurementLabel.Location = new System.Drawing.Point(178, 418);
			this.MuzzleVelocityMeasurementLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.MuzzleVelocityMeasurementLabel.Name = "MuzzleVelocityMeasurementLabel";
			this.MuzzleVelocityMeasurementLabel.Size = new System.Drawing.Size(21, 13);
			this.MuzzleVelocityMeasurementLabel.TabIndex = 3;
			this.MuzzleVelocityMeasurementLabel.Text = "fps";
			// 
			// BallisticsMuzzleVelocityTextBox
			// 
			this.BallisticsMuzzleVelocityTextBox.BackColor = System.Drawing.SystemColors.Window;
			this.BallisticsMuzzleVelocityTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BallisticsMuzzleVelocityTextBox.Location = new System.Drawing.Point(131, 415);
			this.BallisticsMuzzleVelocityTextBox.MaxLength = 4;
			this.BallisticsMuzzleVelocityTextBox.MaxValue = 0;
			this.BallisticsMuzzleVelocityTextBox.MinValue = 0;
			this.BallisticsMuzzleVelocityTextBox.Name = "BallisticsMuzzleVelocityTextBox";
			this.BallisticsMuzzleVelocityTextBox.Required = false;
			this.BallisticsMuzzleVelocityTextBox.Size = new System.Drawing.Size(42, 20);
			this.BallisticsMuzzleVelocityTextBox.TabIndex = 0;
			this.BallisticsMuzzleVelocityTextBox.Text = "0";
			this.BallisticsMuzzleVelocityTextBox.ToolTip = "";
			this.BallisticsMuzzleVelocityTextBox.Value = 0;
			// 
			// BallisticsDatabaseGroupBox
			// 
			this.BallisticsDatabaseGroupBox.BackColor = System.Drawing.SystemColors.Control;
			this.BallisticsDatabaseGroupBox.Controls.Add(this.label2);
			this.BallisticsDatabaseGroupBox.Controls.Add(this.BallisticsFirearmTypeCombo);
			this.BallisticsDatabaseGroupBox.Controls.Add(this.BallisticsResetButton);
			this.BallisticsDatabaseGroupBox.Controls.Add(this.BallisticsLoadDataVelocityRadioButton);
			this.BallisticsDatabaseGroupBox.Controls.Add(this.BallisticsBatchTestVelocityRadioButton);
			this.BallisticsDatabaseGroupBox.Controls.Add(this.BallisticsBulletCombo);
			this.BallisticsDatabaseGroupBox.Controls.Add(this.BallisticsCaliberCombo);
			this.BallisticsDatabaseGroupBox.Controls.Add(this.label11);
			this.BallisticsDatabaseGroupBox.Controls.Add(this.BallisticsChargeCombo);
			this.BallisticsDatabaseGroupBox.Controls.Add(this.label12);
			this.BallisticsDatabaseGroupBox.Controls.Add(this.BallisticsFirearmCombo);
			this.BallisticsDatabaseGroupBox.Controls.Add(this.label10);
			this.BallisticsDatabaseGroupBox.Controls.Add(this.BallisticsLoadCombo);
			this.BallisticsDatabaseGroupBox.Controls.Add(this.label13);
			this.BallisticsDatabaseGroupBox.Controls.Add(this.label9);
			this.BallisticsDatabaseGroupBox.Controls.Add(this.BallisticsBatchCombo);
			this.BallisticsDatabaseGroupBox.Controls.Add(this.label8);
			this.BallisticsDatabaseGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BallisticsDatabaseGroupBox.ForeColor = System.Drawing.SystemColors.HotTrack;
			this.BallisticsDatabaseGroupBox.Location = new System.Drawing.Point(7, 2);
			this.BallisticsDatabaseGroupBox.Margin = new System.Windows.Forms.Padding(2);
			this.BallisticsDatabaseGroupBox.Name = "BallisticsDatabaseGroupBox";
			this.BallisticsDatabaseGroupBox.Padding = new System.Windows.Forms.Padding(2);
			this.BallisticsDatabaseGroupBox.Size = new System.Drawing.Size(697, 176);
			this.BallisticsDatabaseGroupBox.TabIndex = 0;
			this.BallisticsDatabaseGroupBox.TabStop = false;
			this.BallisticsDatabaseGroupBox.Text = "Workshop Database";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label2.Location = new System.Drawing.Point(51, 126);
			this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(36, 13);
			this.label2.TabIndex = 10;
			this.label2.Text = "Bullet:";
			// 
			// BallisticsFirearmTypeCombo
			// 
			this.BallisticsFirearmTypeCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.BallisticsFirearmTypeCombo.DropDownWidth = 115;
			this.BallisticsFirearmTypeCombo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BallisticsFirearmTypeCombo.FormattingEnabled = true;
			this.BallisticsFirearmTypeCombo.IncludeShotgun = false;
			this.BallisticsFirearmTypeCombo.Items.AddRange(new object[] {
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle"});
			this.BallisticsFirearmTypeCombo.Location = new System.Drawing.Point(94, 22);
			this.BallisticsFirearmTypeCombo.Name = "BallisticsFirearmTypeCombo";
			this.BallisticsFirearmTypeCombo.Size = new System.Drawing.Size(98, 21);
			this.BallisticsFirearmTypeCombo.TabIndex = 0;
			this.BallisticsFirearmTypeCombo.ToolTip = "";
			this.BallisticsFirearmTypeCombo.Value = ReloadersWorkShop.cFirearm.eFireArmType.Handgun;
			// 
			// BallisticsResetButton
			// 
			this.BallisticsResetButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BallisticsResetButton.ForeColor = System.Drawing.SystemColors.ControlText;
			this.BallisticsResetButton.Location = new System.Drawing.Point(320, 148);
			this.BallisticsResetButton.Margin = new System.Windows.Forms.Padding(2);
			this.BallisticsResetButton.Name = "BallisticsResetButton";
			this.BallisticsResetButton.Size = new System.Drawing.Size(56, 19);
			this.BallisticsResetButton.TabIndex = 9;
			this.BallisticsResetButton.Text = "Reset";
			this.BallisticsResetButton.UseVisualStyleBackColor = true;
			// 
			// BallisticsLoadDataVelocityRadioButton
			// 
			this.BallisticsLoadDataVelocityRadioButton.AutoCheck = false;
			this.BallisticsLoadDataVelocityRadioButton.AutoSize = true;
			this.BallisticsLoadDataVelocityRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BallisticsLoadDataVelocityRadioButton.ForeColor = System.Drawing.SystemColors.ControlText;
			this.BallisticsLoadDataVelocityRadioButton.Location = new System.Drawing.Point(450, 126);
			this.BallisticsLoadDataVelocityRadioButton.Margin = new System.Windows.Forms.Padding(2);
			this.BallisticsLoadDataVelocityRadioButton.Name = "BallisticsLoadDataVelocityRadioButton";
			this.BallisticsLoadDataVelocityRadioButton.Size = new System.Drawing.Size(140, 17);
			this.BallisticsLoadDataVelocityRadioButton.TabIndex = 8;
			this.BallisticsLoadDataVelocityRadioButton.TabStop = true;
			this.BallisticsLoadDataVelocityRadioButton.Text = "Use Load Data Velocity:";
			this.BallisticsLoadDataVelocityRadioButton.UseVisualStyleBackColor = true;
			// 
			// BallisticsBatchTestVelocityRadioButton
			// 
			this.BallisticsBatchTestVelocityRadioButton.AutoCheck = false;
			this.BallisticsBatchTestVelocityRadioButton.AutoSize = true;
			this.BallisticsBatchTestVelocityRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BallisticsBatchTestVelocityRadioButton.ForeColor = System.Drawing.SystemColors.ControlText;
			this.BallisticsBatchTestVelocityRadioButton.Location = new System.Drawing.Point(450, 100);
			this.BallisticsBatchTestVelocityRadioButton.Margin = new System.Windows.Forms.Padding(2);
			this.BallisticsBatchTestVelocityRadioButton.Name = "BallisticsBatchTestVelocityRadioButton";
			this.BallisticsBatchTestVelocityRadioButton.Size = new System.Drawing.Size(142, 17);
			this.BallisticsBatchTestVelocityRadioButton.TabIndex = 7;
			this.BallisticsBatchTestVelocityRadioButton.TabStop = true;
			this.BallisticsBatchTestVelocityRadioButton.Text = "Use Batch Test Velocity:";
			this.BallisticsBatchTestVelocityRadioButton.UseVisualStyleBackColor = true;
			// 
			// BallisticsBulletCombo
			// 
			this.BallisticsBulletCombo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
			this.BallisticsBulletCombo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.BallisticsBulletCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.BallisticsBulletCombo.DropDownWidth = 300;
			this.BallisticsBulletCombo.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BallisticsBulletCombo.FormattingEnabled = true;
			this.BallisticsBulletCombo.Location = new System.Drawing.Point(94, 123);
			this.BallisticsBulletCombo.Margin = new System.Windows.Forms.Padding(2);
			this.BallisticsBulletCombo.Name = "BallisticsBulletCombo";
			this.BallisticsBulletCombo.Size = new System.Drawing.Size(250, 21);
			this.BallisticsBulletCombo.TabIndex = 6;
			// 
			// BallisticsCaliberCombo
			// 
			this.BallisticsCaliberCombo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
			this.BallisticsCaliberCombo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.BallisticsCaliberCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.BallisticsCaliberCombo.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BallisticsCaliberCombo.FormattingEnabled = true;
			this.BallisticsCaliberCombo.Location = new System.Drawing.Point(207, 98);
			this.BallisticsCaliberCombo.Margin = new System.Windows.Forms.Padding(2);
			this.BallisticsCaliberCombo.Name = "BallisticsCaliberCombo";
			this.BallisticsCaliberCombo.Size = new System.Drawing.Size(200, 21);
			this.BallisticsCaliberCombo.TabIndex = 5;
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label11.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label11.Location = new System.Drawing.Point(159, 100);
			this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(42, 13);
			this.label11.TabIndex = 4;
			this.label11.Text = "Caliber:";
			// 
			// BallisticsChargeCombo
			// 
			this.BallisticsChargeCombo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
			this.BallisticsChargeCombo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.BallisticsChargeCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.BallisticsChargeCombo.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BallisticsChargeCombo.FormattingEnabled = true;
			this.BallisticsChargeCombo.Location = new System.Drawing.Point(94, 99);
			this.BallisticsChargeCombo.Margin = new System.Windows.Forms.Padding(2);
			this.BallisticsChargeCombo.Name = "BallisticsChargeCombo";
			this.BallisticsChargeCombo.Size = new System.Drawing.Size(56, 21);
			this.BallisticsChargeCombo.TabIndex = 4;
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label12.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label12.Location = new System.Drawing.Point(46, 100);
			this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(44, 13);
			this.label12.TabIndex = 2;
			this.label12.Text = "Charge:";
			// 
			// BallisticsFirearmCombo
			// 
			this.BallisticsFirearmCombo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
			this.BallisticsFirearmCombo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.BallisticsFirearmCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.BallisticsFirearmCombo.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BallisticsFirearmCombo.FormattingEnabled = true;
			this.BallisticsFirearmCombo.Location = new System.Drawing.Point(254, 22);
			this.BallisticsFirearmCombo.Margin = new System.Windows.Forms.Padding(2);
			this.BallisticsFirearmCombo.Name = "BallisticsFirearmCombo";
			this.BallisticsFirearmCombo.Size = new System.Drawing.Size(250, 21);
			this.BallisticsFirearmCombo.TabIndex = 1;
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label10.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label10.Location = new System.Drawing.Point(206, 25);
			this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(44, 13);
			this.label10.TabIndex = 4;
			this.label10.Text = "Firearm:";
			// 
			// BallisticsLoadCombo
			// 
			this.BallisticsLoadCombo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
			this.BallisticsLoadCombo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.BallisticsLoadCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.BallisticsLoadCombo.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BallisticsLoadCombo.FormattingEnabled = true;
			this.BallisticsLoadCombo.Location = new System.Drawing.Point(94, 73);
			this.BallisticsLoadCombo.Margin = new System.Windows.Forms.Padding(2);
			this.BallisticsLoadCombo.Name = "BallisticsLoadCombo";
			this.BallisticsLoadCombo.Size = new System.Drawing.Size(580, 21);
			this.BallisticsLoadCombo.TabIndex = 3;
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label13.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label13.Location = new System.Drawing.Point(55, 74);
			this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(34, 13);
			this.label13.TabIndex = 0;
			this.label13.Text = "Load:";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label9.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label9.Location = new System.Drawing.Point(19, 25);
			this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(71, 13);
			this.label9.TabIndex = 2;
			this.label9.Text = "Firearm Type:";
			// 
			// BallisticsBatchCombo
			// 
			this.BallisticsBatchCombo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
			this.BallisticsBatchCombo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.BallisticsBatchCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.BallisticsBatchCombo.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BallisticsBatchCombo.FormattingEnabled = true;
			this.BallisticsBatchCombo.Location = new System.Drawing.Point(94, 47);
			this.BallisticsBatchCombo.Margin = new System.Windows.Forms.Padding(2);
			this.BallisticsBatchCombo.Name = "BallisticsBatchCombo";
			this.BallisticsBatchCombo.Size = new System.Drawing.Size(580, 21);
			this.BallisticsBatchCombo.TabIndex = 2;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label8.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label8.Location = new System.Drawing.Point(52, 49);
			this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(38, 13);
			this.label8.TabIndex = 0;
			this.label8.Text = "Batch:";
			// 
			// BallisticsInputDataGroupBox
			// 
			this.BallisticsInputDataGroupBox.BackColor = System.Drawing.SystemColors.Control;
			this.BallisticsInputDataGroupBox.Controls.Add(this.groupBox2);
			this.BallisticsInputDataGroupBox.Controls.Add(this.BallisticsTwistTextBox);
			this.BallisticsInputDataGroupBox.Controls.Add(this.TwistMeasurementLabel);
			this.BallisticsInputDataGroupBox.Controls.Add(this.label33);
			this.BallisticsInputDataGroupBox.Controls.Add(this.BallisticsBulletLengthTextBox);
			this.BallisticsInputDataGroupBox.Controls.Add(this.BulletLengthMeasurementLabel);
			this.BallisticsInputDataGroupBox.Controls.Add(this.label29);
			this.BallisticsInputDataGroupBox.Controls.Add(this.ShowReferenceDataCheckBox);
			this.BallisticsInputDataGroupBox.Controls.Add(this.groupBox1);
			this.BallisticsInputDataGroupBox.Controls.Add(this.BallisticsTurretTypeComboBox);
			this.BallisticsInputDataGroupBox.Controls.Add(this.BallisticsSightHeightTextBox);
			this.BallisticsInputDataGroupBox.Controls.Add(this.SightHeightMeasurementLabel);
			this.BallisticsInputDataGroupBox.Controls.Add(this.BallisticsScopeClickTextBox);
			this.BallisticsInputDataGroupBox.Controls.Add(this.BallisticsBCTextBox);
			this.BallisticsInputDataGroupBox.Controls.Add(this.BallisticsZeroRangeTextBox);
			this.BallisticsInputDataGroupBox.Controls.Add(this.ZeroRangeMeasurementLabel);
			this.BallisticsInputDataGroupBox.Controls.Add(this.BallisticsBulletDiameterTextBox);
			this.BallisticsInputDataGroupBox.Controls.Add(this.BulletDiameterMeasurementLabel);
			this.BallisticsInputDataGroupBox.Controls.Add(this.BallisticsBulletWeightTextBox);
			this.BallisticsInputDataGroupBox.Controls.Add(this.BulletWeightMeasurementLabel);
			this.BallisticsInputDataGroupBox.Controls.Add(this.SaveReferenceBulletButton);
			this.BallisticsInputDataGroupBox.Controls.Add(this.RestoreReferenceBulletButton);
			this.BallisticsInputDataGroupBox.Controls.Add(this.label28);
			this.BallisticsInputDataGroupBox.Controls.Add(this.label26);
			this.BallisticsInputDataGroupBox.Controls.Add(this.label24);
			this.BallisticsInputDataGroupBox.Controls.Add(this.label18);
			this.BallisticsInputDataGroupBox.Controls.Add(this.label16);
			this.BallisticsInputDataGroupBox.Controls.Add(this.label15);
			this.BallisticsInputDataGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BallisticsInputDataGroupBox.ForeColor = System.Drawing.SystemColors.HotTrack;
			this.BallisticsInputDataGroupBox.Location = new System.Drawing.Point(7, 182);
			this.BallisticsInputDataGroupBox.Margin = new System.Windows.Forms.Padding(2);
			this.BallisticsInputDataGroupBox.Name = "BallisticsInputDataGroupBox";
			this.BallisticsInputDataGroupBox.Padding = new System.Windows.Forms.Padding(2);
			this.BallisticsInputDataGroupBox.Size = new System.Drawing.Size(697, 288);
			this.BallisticsInputDataGroupBox.TabIndex = 1;
			this.BallisticsInputDataGroupBox.TabStop = false;
			this.BallisticsInputDataGroupBox.Text = "Input Parameters";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.BallisticsKestrelButton);
			this.groupBox2.Controls.Add(this.BallisticsUseStationPressureCheckBox);
			this.groupBox2.Controls.Add(this.BallisticsStationPressureLabel);
			this.groupBox2.Controls.Add(this.TemperatureMeasurementLabel);
			this.groupBox2.Controls.Add(this.label14);
			this.groupBox2.Controls.Add(this.BallisticsUseDensityAltitudeCheckBox);
			this.groupBox2.Controls.Add(this.BallisticsTemperatureTextBox);
			this.groupBox2.Controls.Add(this.BallisticsDensityAltitudeLabel);
			this.groupBox2.Controls.Add(this.label7);
			this.groupBox2.Controls.Add(this.BallisticsHumidityTextBox);
			this.groupBox2.Controls.Add(this.BallisticsAltitudeTextBox);
			this.groupBox2.Controls.Add(this.label22);
			this.groupBox2.Controls.Add(this.AltitudeMeasurementLabel);
			this.groupBox2.Controls.Add(this.label32);
			this.groupBox2.Controls.Add(this.BallisticsPressureMeasurementLabel);
			this.groupBox2.Controls.Add(this.label25);
			this.groupBox2.Controls.Add(this.label30);
			this.groupBox2.Controls.Add(this.label19);
			this.groupBox2.Controls.Add(this.label31);
			this.groupBox2.Controls.Add(this.BallisticsPressureTextBox);
			this.groupBox2.Controls.Add(label54);
			this.groupBox2.Controls.Add(this.WindSpeedMeasurementLabel);
			this.groupBox2.Controls.Add(this.BallisticsWindSpeedTextBox);
			this.groupBox2.Controls.Add(this.CrossWindLabel);
			this.groupBox2.Controls.Add(this.HeadWindLabel);
			this.groupBox2.Controls.Add(this.BallisticsWindDirectionTextBox);
			this.groupBox2.Controls.Add(label56);
			this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox2.ForeColor = System.Drawing.SystemColors.HotTrack;
			this.groupBox2.Location = new System.Drawing.Point(7, 75);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(686, 100);
			this.groupBox2.TabIndex = 53;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Atmospheric Conditions";
			// 
			// BallisticsKestrelButton
			// 
			this.BallisticsKestrelButton.AutoSize = true;
			this.BallisticsKestrelButton.BackColor = System.Drawing.Color.Green;
			this.BallisticsKestrelButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.BallisticsKestrelButton.FlatAppearance.BorderSize = 0;
			this.BallisticsKestrelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BallisticsKestrelButton.ForeColor = System.Drawing.Color.White;
			this.BallisticsKestrelButton.Location = new System.Drawing.Point(567, 70);
			this.BallisticsKestrelButton.Margin = new System.Windows.Forms.Padding(2);
			this.BallisticsKestrelButton.Name = "BallisticsKestrelButton";
			this.BallisticsKestrelButton.Size = new System.Drawing.Size(92, 23);
			this.BallisticsKestrelButton.TabIndex = 62;
			this.BallisticsKestrelButton.Text = "Kestrel Start";
			this.BallisticsKestrelButton.UseVisualStyleBackColor = false;
			this.BallisticsKestrelButton.Visible = false;
			// 
			// BallisticsUseStationPressureCheckBox
			// 
			this.BallisticsUseStationPressureCheckBox.AutoSize = true;
			this.BallisticsUseStationPressureCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BallisticsUseStationPressureCheckBox.ForeColor = System.Drawing.SystemColors.ControlText;
			this.BallisticsUseStationPressureCheckBox.Location = new System.Drawing.Point(340, 74);
			this.BallisticsUseStationPressureCheckBox.Name = "BallisticsUseStationPressureCheckBox";
			this.BallisticsUseStationPressureCheckBox.Size = new System.Drawing.Size(128, 17);
			this.BallisticsUseStationPressureCheckBox.TabIndex = 65;
			this.BallisticsUseStationPressureCheckBox.Text = "Use Station Pressure:";
			this.BallisticsUseStationPressureCheckBox.UseVisualStyleBackColor = true;
			// 
			// BallisticsStationPressureLabel
			// 
			this.BallisticsStationPressureLabel.AutoSize = true;
			this.BallisticsStationPressureLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BallisticsStationPressureLabel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.BallisticsStationPressureLabel.Location = new System.Drawing.Point(468, 75);
			this.BallisticsStationPressureLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.BallisticsStationPressureLabel.Name = "BallisticsStationPressureLabel";
			this.BallisticsStationPressureLabel.Size = new System.Drawing.Size(77, 13);
			this.BallisticsStationPressureLabel.TabIndex = 66;
			this.BallisticsStationPressureLabel.Text = "29.92 in. Hg";
			// 
			// TemperatureMeasurementLabel
			// 
			this.TemperatureMeasurementLabel.AutoSize = true;
			this.TemperatureMeasurementLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.TemperatureMeasurementLabel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.TemperatureMeasurementLabel.Location = new System.Drawing.Point(161, 50);
			this.TemperatureMeasurementLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.TemperatureMeasurementLabel.Name = "TemperatureMeasurementLabel";
			this.TemperatureMeasurementLabel.Size = new System.Drawing.Size(13, 13);
			this.TemperatureMeasurementLabel.TabIndex = 64;
			this.TemperatureMeasurementLabel.Text = "F";
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label14.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label14.Location = new System.Drawing.Point(225, 50);
			this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(45, 13);
			this.label14.TabIndex = 50;
			this.label14.Text = "Altitude:";
			// 
			// BallisticsUseDensityAltitudeCheckBox
			// 
			this.BallisticsUseDensityAltitudeCheckBox.AutoSize = true;
			this.BallisticsUseDensityAltitudeCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BallisticsUseDensityAltitudeCheckBox.ForeColor = System.Drawing.SystemColors.ControlText;
			this.BallisticsUseDensityAltitudeCheckBox.Location = new System.Drawing.Point(148, 74);
			this.BallisticsUseDensityAltitudeCheckBox.Name = "BallisticsUseDensityAltitudeCheckBox";
			this.BallisticsUseDensityAltitudeCheckBox.Size = new System.Drawing.Size(124, 17);
			this.BallisticsUseDensityAltitudeCheckBox.TabIndex = 12;
			this.BallisticsUseDensityAltitudeCheckBox.Text = "Use Density Altitude:";
			this.BallisticsUseDensityAltitudeCheckBox.UseVisualStyleBackColor = true;
			// 
			// BallisticsTemperatureTextBox
			// 
			this.BallisticsTemperatureTextBox.BackColor = System.Drawing.SystemColors.Window;
			this.BallisticsTemperatureTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BallisticsTemperatureTextBox.Location = new System.Drawing.Point(118, 47);
			this.BallisticsTemperatureTextBox.MaxLength = 3;
			this.BallisticsTemperatureTextBox.MaxValue = 120;
			this.BallisticsTemperatureTextBox.MinValue = 0;
			this.BallisticsTemperatureTextBox.Name = "BallisticsTemperatureTextBox";
			this.BallisticsTemperatureTextBox.Required = false;
			this.BallisticsTemperatureTextBox.Size = new System.Drawing.Size(38, 20);
			this.BallisticsTemperatureTextBox.TabIndex = 11;
			this.BallisticsTemperatureTextBox.Text = "59";
			this.BallisticsTemperatureTextBox.ToolTip = "";
			this.BallisticsTemperatureTextBox.Value = 59;
			// 
			// BallisticsDensityAltitudeLabel
			// 
			this.BallisticsDensityAltitudeLabel.AutoSize = true;
			this.BallisticsDensityAltitudeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BallisticsDensityAltitudeLabel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.BallisticsDensityAltitudeLabel.Location = new System.Drawing.Point(275, 75);
			this.BallisticsDensityAltitudeLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.BallisticsDensityAltitudeLabel.Name = "BallisticsDensityAltitudeLabel";
			this.BallisticsDensityAltitudeLabel.Size = new System.Drawing.Size(54, 13);
			this.BallisticsDensityAltitudeLabel.TabIndex = 63;
			this.BallisticsDensityAltitudeLabel.Text = "10000 ft";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label7.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label7.Location = new System.Drawing.Point(42, 50);
			this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(70, 13);
			this.label7.TabIndex = 47;
			this.label7.Text = "Temperature:";
			// 
			// BallisticsHumidityTextBox
			// 
			this.BallisticsHumidityTextBox.BackColor = System.Drawing.SystemColors.Window;
			this.BallisticsHumidityTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BallisticsHumidityTextBox.Location = new System.Drawing.Point(615, 47);
			this.BallisticsHumidityTextBox.MaxLength = 3;
			this.BallisticsHumidityTextBox.MaxValue = 100;
			this.BallisticsHumidityTextBox.MinValue = 0;
			this.BallisticsHumidityTextBox.Name = "BallisticsHumidityTextBox";
			this.BallisticsHumidityTextBox.Required = false;
			this.BallisticsHumidityTextBox.Size = new System.Drawing.Size(38, 20);
			this.BallisticsHumidityTextBox.TabIndex = 14;
			this.BallisticsHumidityTextBox.Text = "0";
			this.BallisticsHumidityTextBox.ToolTip = "";
			this.BallisticsHumidityTextBox.Value = 0;
			// 
			// BallisticsAltitudeTextBox
			// 
			this.BallisticsAltitudeTextBox.BackColor = System.Drawing.SystemColors.Window;
			this.BallisticsAltitudeTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BallisticsAltitudeTextBox.Location = new System.Drawing.Point(275, 47);
			this.BallisticsAltitudeTextBox.MaxLength = 5;
			this.BallisticsAltitudeTextBox.MaxValue = 15000;
			this.BallisticsAltitudeTextBox.MinValue = 0;
			this.BallisticsAltitudeTextBox.Name = "BallisticsAltitudeTextBox";
			this.BallisticsAltitudeTextBox.Required = false;
			this.BallisticsAltitudeTextBox.Size = new System.Drawing.Size(38, 20);
			this.BallisticsAltitudeTextBox.TabIndex = 12;
			this.BallisticsAltitudeTextBox.Text = "0";
			this.BallisticsAltitudeTextBox.ToolTip = "";
			this.BallisticsAltitudeTextBox.Value = 0;
			// 
			// label22
			// 
			this.label22.AutoSize = true;
			this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label22.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label22.Location = new System.Drawing.Point(564, 50);
			this.label22.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(50, 13);
			this.label22.TabIndex = 56;
			this.label22.Text = "Humidity:";
			// 
			// AltitudeMeasurementLabel
			// 
			this.AltitudeMeasurementLabel.AutoSize = true;
			this.AltitudeMeasurementLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.AltitudeMeasurementLabel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.AltitudeMeasurementLabel.Location = new System.Drawing.Point(318, 50);
			this.AltitudeMeasurementLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.AltitudeMeasurementLabel.Name = "AltitudeMeasurementLabel";
			this.AltitudeMeasurementLabel.Size = new System.Drawing.Size(13, 13);
			this.AltitudeMeasurementLabel.TabIndex = 49;
			this.AltitudeMeasurementLabel.Text = "ft";
			// 
			// label32
			// 
			this.label32.AutoSize = true;
			this.label32.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label32.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label32.Location = new System.Drawing.Point(193, 24);
			this.label32.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label32.Name = "label32";
			this.label32.Size = new System.Drawing.Size(80, 13);
			this.label32.TabIndex = 10;
			this.label32.Text = "Wind Direction:";
			// 
			// BallisticsPressureMeasurementLabel
			// 
			this.BallisticsPressureMeasurementLabel.AutoSize = true;
			this.BallisticsPressureMeasurementLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BallisticsPressureMeasurementLabel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.BallisticsPressureMeasurementLabel.Location = new System.Drawing.Point(520, 50);
			this.BallisticsPressureMeasurementLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.BallisticsPressureMeasurementLabel.Name = "BallisticsPressureMeasurementLabel";
			this.BallisticsPressureMeasurementLabel.Size = new System.Drawing.Size(35, 13);
			this.BallisticsPressureMeasurementLabel.TabIndex = 52;
			this.BallisticsPressureMeasurementLabel.Text = "in. Hg";
			// 
			// label25
			// 
			this.label25.AutoSize = true;
			this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label25.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label25.Location = new System.Drawing.Point(658, 50);
			this.label25.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label25.Name = "label25";
			this.label25.Size = new System.Drawing.Size(15, 13);
			this.label25.TabIndex = 55;
			this.label25.Text = "%";
			// 
			// label30
			// 
			this.label30.AutoSize = true;
			this.label30.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label30.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label30.Location = new System.Drawing.Point(44, 25);
			this.label30.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label30.Name = "label30";
			this.label30.Size = new System.Drawing.Size(69, 13);
			this.label30.TabIndex = 28;
			this.label30.Text = "Wind Speed:";
			// 
			// label19
			// 
			this.label19.AutoSize = true;
			this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label19.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label19.Location = new System.Drawing.Point(361, 50);
			this.label19.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(104, 13);
			this.label19.TabIndex = 53;
			this.label19.Text = "Barometric Pressure:";
			// 
			// label31
			// 
			this.label31.AutoSize = true;
			this.label31.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label31.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label31.Location = new System.Drawing.Point(319, 25);
			this.label31.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label31.Name = "label31";
			this.label31.Size = new System.Drawing.Size(28, 13);
			this.label31.TabIndex = 9;
			this.label31.Text = "deg.";
			// 
			// BallisticsPressureTextBox
			// 
			this.BallisticsPressureTextBox.BackColor = System.Drawing.Color.LightPink;
			this.BallisticsPressureTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BallisticsPressureTextBox.Location = new System.Drawing.Point(471, 47);
			this.BallisticsPressureTextBox.MaxLength = 5;
			this.BallisticsPressureTextBox.MaxValue = 33D;
			this.BallisticsPressureTextBox.MinValue = 25D;
			this.BallisticsPressureTextBox.Name = "BallisticsPressureTextBox";
			this.BallisticsPressureTextBox.NumDecimals = 2;
			this.BallisticsPressureTextBox.Size = new System.Drawing.Size(42, 20);
			this.BallisticsPressureTextBox.TabIndex = 13;
			this.BallisticsPressureTextBox.Text = "0.00";
			this.BallisticsPressureTextBox.ToolTip = "";
			this.BallisticsPressureTextBox.Value = 0D;
			this.BallisticsPressureTextBox.ZeroAllowed = true;
			// 
			// WindSpeedMeasurementLabel
			// 
			this.WindSpeedMeasurementLabel.AutoSize = true;
			this.WindSpeedMeasurementLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.WindSpeedMeasurementLabel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.WindSpeedMeasurementLabel.Location = new System.Drawing.Point(159, 24);
			this.WindSpeedMeasurementLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.WindSpeedMeasurementLabel.Name = "WindSpeedMeasurementLabel";
			this.WindSpeedMeasurementLabel.Size = new System.Drawing.Size(27, 13);
			this.WindSpeedMeasurementLabel.TabIndex = 29;
			this.WindSpeedMeasurementLabel.Text = "mph";
			// 
			// BallisticsWindSpeedTextBox
			// 
			this.BallisticsWindSpeedTextBox.BackColor = System.Drawing.SystemColors.Window;
			this.BallisticsWindSpeedTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BallisticsWindSpeedTextBox.Location = new System.Drawing.Point(118, 21);
			this.BallisticsWindSpeedTextBox.MaxLength = 2;
			this.BallisticsWindSpeedTextBox.MaxValue = 0;
			this.BallisticsWindSpeedTextBox.MinValue = 0;
			this.BallisticsWindSpeedTextBox.Name = "BallisticsWindSpeedTextBox";
			this.BallisticsWindSpeedTextBox.Required = false;
			this.BallisticsWindSpeedTextBox.Size = new System.Drawing.Size(38, 20);
			this.BallisticsWindSpeedTextBox.TabIndex = 9;
			this.BallisticsWindSpeedTextBox.Text = "0";
			this.BallisticsWindSpeedTextBox.ToolTip = "";
			this.BallisticsWindSpeedTextBox.Value = 0;
			// 
			// CrossWindLabel
			// 
			this.CrossWindLabel.AutoSize = true;
			this.CrossWindLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.CrossWindLabel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.CrossWindLabel.Location = new System.Drawing.Point(534, 24);
			this.CrossWindLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.CrossWindLabel.Name = "CrossWindLabel";
			this.CrossWindLabel.Size = new System.Drawing.Size(14, 13);
			this.CrossWindLabel.TabIndex = 43;
			this.CrossWindLabel.Text = "0";
			// 
			// HeadWindLabel
			// 
			this.HeadWindLabel.AutoSize = true;
			this.HeadWindLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.HeadWindLabel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.HeadWindLabel.Location = new System.Drawing.Point(434, 24);
			this.HeadWindLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.HeadWindLabel.Name = "HeadWindLabel";
			this.HeadWindLabel.Size = new System.Drawing.Size(14, 13);
			this.HeadWindLabel.TabIndex = 45;
			this.HeadWindLabel.Text = "0";
			// 
			// BallisticsWindDirectionTextBox
			// 
			this.BallisticsWindDirectionTextBox.BackColor = System.Drawing.SystemColors.Window;
			this.BallisticsWindDirectionTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BallisticsWindDirectionTextBox.Location = new System.Drawing.Point(276, 22);
			this.BallisticsWindDirectionTextBox.MaxLength = 3;
			this.BallisticsWindDirectionTextBox.MaxValue = 0;
			this.BallisticsWindDirectionTextBox.MinValue = 0;
			this.BallisticsWindDirectionTextBox.Name = "BallisticsWindDirectionTextBox";
			this.BallisticsWindDirectionTextBox.Required = false;
			this.BallisticsWindDirectionTextBox.Size = new System.Drawing.Size(38, 20);
			this.BallisticsWindDirectionTextBox.TabIndex = 10;
			this.BallisticsWindDirectionTextBox.Text = "0";
			this.BallisticsWindDirectionTextBox.ToolTip = "";
			this.BallisticsWindDirectionTextBox.Value = 0;
			// 
			// BallisticsTwistTextBox
			// 
			this.BallisticsTwistTextBox.BackColor = System.Drawing.Color.LightPink;
			this.BallisticsTwistTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BallisticsTwistTextBox.Location = new System.Drawing.Point(612, 47);
			this.BallisticsTwistTextBox.MaxLength = 5;
			this.BallisticsTwistTextBox.MaxValue = 78D;
			this.BallisticsTwistTextBox.MinValue = 5D;
			this.BallisticsTwistTextBox.Name = "BallisticsTwistTextBox";
			this.BallisticsTwistTextBox.NumDecimals = 1;
			this.BallisticsTwistTextBox.Size = new System.Drawing.Size(42, 20);
			this.BallisticsTwistTextBox.TabIndex = 8;
			this.BallisticsTwistTextBox.Text = "0.0";
			this.BallisticsTwistTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.BallisticsTwistTextBox.ToolTip = "";
			this.BallisticsTwistTextBox.Value = 0D;
			this.BallisticsTwistTextBox.ZeroAllowed = true;
			// 
			// TwistMeasurementLabel
			// 
			this.TwistMeasurementLabel.AutoSize = true;
			this.TwistMeasurementLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.TwistMeasurementLabel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.TwistMeasurementLabel.Location = new System.Drawing.Point(659, 51);
			this.TwistMeasurementLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.TwistMeasurementLabel.Name = "TwistMeasurementLabel";
			this.TwistMeasurementLabel.Size = new System.Drawing.Size(15, 13);
			this.TwistMeasurementLabel.TabIndex = 61;
			this.TwistMeasurementLabel.Text = "in";
			// 
			// label33
			// 
			this.label33.AutoSize = true;
			this.label33.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label33.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label33.Location = new System.Drawing.Point(552, 51);
			this.label33.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label33.Name = "label33";
			this.label33.Size = new System.Drawing.Size(55, 13);
			this.label33.TabIndex = 60;
			this.label33.Text = "Twist: 1 in";
			// 
			// BallisticsBulletLengthTextBox
			// 
			this.BallisticsBulletLengthTextBox.BackColor = System.Drawing.SystemColors.Window;
			this.BallisticsBulletLengthTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BallisticsBulletLengthTextBox.Location = new System.Drawing.Point(613, 22);
			this.BallisticsBulletLengthTextBox.MaxLength = 5;
			this.BallisticsBulletLengthTextBox.MaxValue = 0D;
			this.BallisticsBulletLengthTextBox.MinValue = 0D;
			this.BallisticsBulletLengthTextBox.Name = "BallisticsBulletLengthTextBox";
			this.BallisticsBulletLengthTextBox.NumDecimals = 1;
			this.BallisticsBulletLengthTextBox.Size = new System.Drawing.Size(42, 20);
			this.BallisticsBulletLengthTextBox.TabIndex = 3;
			this.BallisticsBulletLengthTextBox.Text = "0.0";
			this.BallisticsBulletLengthTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.BallisticsBulletLengthTextBox.ToolTip = "";
			this.BallisticsBulletLengthTextBox.Value = 0D;
			this.BallisticsBulletLengthTextBox.ZeroAllowed = true;
			// 
			// BulletLengthMeasurementLabel
			// 
			this.BulletLengthMeasurementLabel.AutoSize = true;
			this.BulletLengthMeasurementLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BulletLengthMeasurementLabel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.BulletLengthMeasurementLabel.Location = new System.Drawing.Point(660, 24);
			this.BulletLengthMeasurementLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.BulletLengthMeasurementLabel.Name = "BulletLengthMeasurementLabel";
			this.BulletLengthMeasurementLabel.Size = new System.Drawing.Size(16, 13);
			this.BulletLengthMeasurementLabel.TabIndex = 57;
			this.BulletLengthMeasurementLabel.Text = "gr";
			// 
			// label29
			// 
			this.label29.AutoSize = true;
			this.label29.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label29.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label29.Location = new System.Drawing.Point(535, 25);
			this.label29.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label29.Name = "label29";
			this.label29.Size = new System.Drawing.Size(72, 13);
			this.label29.TabIndex = 58;
			this.label29.Text = "Bullet Length:";
			// 
			// ShowReferenceDataCheckBox
			// 
			this.ShowReferenceDataCheckBox.AutoSize = true;
			this.ShowReferenceDataCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ShowReferenceDataCheckBox.ForeColor = System.Drawing.SystemColors.ControlText;
			this.ShowReferenceDataCheckBox.Location = new System.Drawing.Point(109, 252);
			this.ShowReferenceDataCheckBox.Name = "ShowReferenceDataCheckBox";
			this.ShowReferenceDataCheckBox.Size = new System.Drawing.Size(132, 17);
			this.ShowReferenceDataCheckBox.TabIndex = 1;
			this.ShowReferenceDataCheckBox.Text = "Show Reference Data";
			this.ShowReferenceDataCheckBox.UseVisualStyleBackColor = true;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.MaxRangeMeasurementLabel);
			this.groupBox1.Controls.Add(this.label34);
			this.groupBox1.Controls.Add(this.label36);
			this.groupBox1.Controls.Add(this.label38);
			this.groupBox1.Controls.Add(this.IncrementMeasurementLabel);
			this.groupBox1.Controls.Add(this.BallisticsIncrementTextBox);
			this.groupBox1.Controls.Add(this.MinRangeMeasurementLabel);
			this.groupBox1.Controls.Add(this.BallisticsMinRangeTextBox);
			this.groupBox1.Controls.Add(this.BallisticsMaxRangeTextBox);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.BallisticsTargetRangeTextBox);
			this.groupBox1.Controls.Add(this.TargetRangeMeasurementLabel);
			this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox1.ForeColor = System.Drawing.SystemColors.HotTrack;
			this.groupBox1.Location = new System.Drawing.Point(5, 185);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(686, 50);
			this.groupBox1.TabIndex = 14;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Output Options";
			// 
			// MaxRangeMeasurementLabel
			// 
			this.MaxRangeMeasurementLabel.AutoSize = true;
			this.MaxRangeMeasurementLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.MaxRangeMeasurementLabel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.MaxRangeMeasurementLabel.Location = new System.Drawing.Point(314, 24);
			this.MaxRangeMeasurementLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.MaxRangeMeasurementLabel.Name = "MaxRangeMeasurementLabel";
			this.MaxRangeMeasurementLabel.Size = new System.Drawing.Size(23, 13);
			this.MaxRangeMeasurementLabel.TabIndex = 10;
			this.MaxRangeMeasurementLabel.Text = "yds";
			// 
			// label34
			// 
			this.label34.AutoSize = true;
			this.label34.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label34.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label34.Location = new System.Drawing.Point(44, 25);
			this.label34.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label34.Name = "label34";
			this.label34.Size = new System.Drawing.Size(62, 13);
			this.label34.TabIndex = 34;
			this.label34.Text = "Min Range:";
			// 
			// label36
			// 
			this.label36.AutoSize = true;
			this.label36.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label36.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label36.Location = new System.Drawing.Point(200, 24);
			this.label36.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label36.Name = "label36";
			this.label36.Size = new System.Drawing.Size(65, 13);
			this.label36.TabIndex = 37;
			this.label36.Text = "Max Range:";
			// 
			// label38
			// 
			this.label38.AutoSize = true;
			this.label38.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label38.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label38.Location = new System.Drawing.Point(352, 24);
			this.label38.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label38.Name = "label38";
			this.label38.Size = new System.Drawing.Size(57, 13);
			this.label38.TabIndex = 40;
			this.label38.Text = "Increment:";
			// 
			// IncrementMeasurementLabel
			// 
			this.IncrementMeasurementLabel.AutoSize = true;
			this.IncrementMeasurementLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.IncrementMeasurementLabel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.IncrementMeasurementLabel.Location = new System.Drawing.Point(456, 24);
			this.IncrementMeasurementLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.IncrementMeasurementLabel.Name = "IncrementMeasurementLabel";
			this.IncrementMeasurementLabel.Size = new System.Drawing.Size(23, 13);
			this.IncrementMeasurementLabel.TabIndex = 12;
			this.IncrementMeasurementLabel.Text = "yds";
			// 
			// BallisticsIncrementTextBox
			// 
			this.BallisticsIncrementTextBox.BackColor = System.Drawing.SystemColors.Window;
			this.BallisticsIncrementTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BallisticsIncrementTextBox.Location = new System.Drawing.Point(414, 22);
			this.BallisticsIncrementTextBox.MaxLength = 3;
			this.BallisticsIncrementTextBox.MaxValue = 0;
			this.BallisticsIncrementTextBox.MinValue = 0;
			this.BallisticsIncrementTextBox.Name = "BallisticsIncrementTextBox";
			this.BallisticsIncrementTextBox.Required = false;
			this.BallisticsIncrementTextBox.Size = new System.Drawing.Size(38, 20);
			this.BallisticsIncrementTextBox.TabIndex = 2;
			this.BallisticsIncrementTextBox.Text = "0";
			this.BallisticsIncrementTextBox.ToolTip = "";
			this.BallisticsIncrementTextBox.Value = 0;
			// 
			// MinRangeMeasurementLabel
			// 
			this.MinRangeMeasurementLabel.AutoSize = true;
			this.MinRangeMeasurementLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.MinRangeMeasurementLabel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.MinRangeMeasurementLabel.Location = new System.Drawing.Point(158, 24);
			this.MinRangeMeasurementLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.MinRangeMeasurementLabel.Name = "MinRangeMeasurementLabel";
			this.MinRangeMeasurementLabel.Size = new System.Drawing.Size(23, 13);
			this.MinRangeMeasurementLabel.TabIndex = 11;
			this.MinRangeMeasurementLabel.Text = "yds";
			// 
			// BallisticsMinRangeTextBox
			// 
			this.BallisticsMinRangeTextBox.BackColor = System.Drawing.SystemColors.Window;
			this.BallisticsMinRangeTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BallisticsMinRangeTextBox.Location = new System.Drawing.Point(111, 21);
			this.BallisticsMinRangeTextBox.MaxLength = 4;
			this.BallisticsMinRangeTextBox.MaxValue = 0;
			this.BallisticsMinRangeTextBox.MinValue = 0;
			this.BallisticsMinRangeTextBox.Name = "BallisticsMinRangeTextBox";
			this.BallisticsMinRangeTextBox.Required = false;
			this.BallisticsMinRangeTextBox.Size = new System.Drawing.Size(42, 20);
			this.BallisticsMinRangeTextBox.TabIndex = 0;
			this.BallisticsMinRangeTextBox.Text = "0";
			this.BallisticsMinRangeTextBox.ToolTip = "";
			this.BallisticsMinRangeTextBox.Value = 0;
			// 
			// BallisticsMaxRangeTextBox
			// 
			this.BallisticsMaxRangeTextBox.BackColor = System.Drawing.SystemColors.Window;
			this.BallisticsMaxRangeTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BallisticsMaxRangeTextBox.Location = new System.Drawing.Point(268, 22);
			this.BallisticsMaxRangeTextBox.MaxLength = 4;
			this.BallisticsMaxRangeTextBox.MaxValue = 0;
			this.BallisticsMaxRangeTextBox.MinValue = 0;
			this.BallisticsMaxRangeTextBox.Name = "BallisticsMaxRangeTextBox";
			this.BallisticsMaxRangeTextBox.Required = false;
			this.BallisticsMaxRangeTextBox.Size = new System.Drawing.Size(42, 20);
			this.BallisticsMaxRangeTextBox.TabIndex = 1;
			this.BallisticsMaxRangeTextBox.Text = "0";
			this.BallisticsMaxRangeTextBox.ToolTip = "";
			this.BallisticsMaxRangeTextBox.Value = 0;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label3.Location = new System.Drawing.Point(527, 25);
			this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(76, 13);
			this.label3.TabIndex = 51;
			this.label3.Text = "Target Range:";
			// 
			// BallisticsTargetRangeTextBox
			// 
			this.BallisticsTargetRangeTextBox.BackColor = System.Drawing.SystemColors.Window;
			this.BallisticsTargetRangeTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BallisticsTargetRangeTextBox.Location = new System.Drawing.Point(608, 22);
			this.BallisticsTargetRangeTextBox.MaxLength = 4;
			this.BallisticsTargetRangeTextBox.MaxValue = 0;
			this.BallisticsTargetRangeTextBox.MinValue = 0;
			this.BallisticsTargetRangeTextBox.Name = "BallisticsTargetRangeTextBox";
			this.BallisticsTargetRangeTextBox.Required = false;
			this.BallisticsTargetRangeTextBox.Size = new System.Drawing.Size(42, 20);
			this.BallisticsTargetRangeTextBox.TabIndex = 3;
			this.BallisticsTargetRangeTextBox.Text = "0";
			this.BallisticsTargetRangeTextBox.ToolTip = "";
			this.BallisticsTargetRangeTextBox.Value = 0;
			// 
			// TargetRangeMeasurementLabel
			// 
			this.TargetRangeMeasurementLabel.AutoSize = true;
			this.TargetRangeMeasurementLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.TargetRangeMeasurementLabel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.TargetRangeMeasurementLabel.Location = new System.Drawing.Point(655, 25);
			this.TargetRangeMeasurementLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.TargetRangeMeasurementLabel.Name = "TargetRangeMeasurementLabel";
			this.TargetRangeMeasurementLabel.Size = new System.Drawing.Size(23, 13);
			this.TargetRangeMeasurementLabel.TabIndex = 52;
			this.TargetRangeMeasurementLabel.Text = "yds";
			// 
			// BallisticsTurretTypeComboBox
			// 
			this.BallisticsTurretTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.BallisticsTurretTypeComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BallisticsTurretTypeComboBox.FormattingEnabled = true;
			this.BallisticsTurretTypeComboBox.Location = new System.Drawing.Point(463, 48);
			this.BallisticsTurretTypeComboBox.Name = "BallisticsTurretTypeComboBox";
			this.BallisticsTurretTypeComboBox.Size = new System.Drawing.Size(50, 21);
			this.BallisticsTurretTypeComboBox.TabIndex = 7;
			// 
			// BallisticsSightHeightTextBox
			// 
			this.BallisticsSightHeightTextBox.BackColor = System.Drawing.SystemColors.Window;
			this.BallisticsSightHeightTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BallisticsSightHeightTextBox.Location = new System.Drawing.Point(274, 48);
			this.BallisticsSightHeightTextBox.MaxLength = 5;
			this.BallisticsSightHeightTextBox.MaxValue = 0D;
			this.BallisticsSightHeightTextBox.MinValue = 0D;
			this.BallisticsSightHeightTextBox.Name = "BallisticsSightHeightTextBox";
			this.BallisticsSightHeightTextBox.NumDecimals = 2;
			this.BallisticsSightHeightTextBox.Size = new System.Drawing.Size(34, 20);
			this.BallisticsSightHeightTextBox.TabIndex = 5;
			this.BallisticsSightHeightTextBox.Text = "0.00";
			this.BallisticsSightHeightTextBox.ToolTip = "";
			this.BallisticsSightHeightTextBox.Value = 0D;
			this.BallisticsSightHeightTextBox.ZeroAllowed = true;
			// 
			// SightHeightMeasurementLabel
			// 
			this.SightHeightMeasurementLabel.AutoSize = true;
			this.SightHeightMeasurementLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.SightHeightMeasurementLabel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.SightHeightMeasurementLabel.Location = new System.Drawing.Point(308, 50);
			this.SightHeightMeasurementLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.SightHeightMeasurementLabel.Name = "SightHeightMeasurementLabel";
			this.SightHeightMeasurementLabel.Size = new System.Drawing.Size(18, 13);
			this.SightHeightMeasurementLabel.TabIndex = 6;
			this.SightHeightMeasurementLabel.Text = "in.";
			// 
			// BallisticsScopeClickTextBox
			// 
			this.BallisticsScopeClickTextBox.BackColor = System.Drawing.SystemColors.Window;
			this.BallisticsScopeClickTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BallisticsScopeClickTextBox.Location = new System.Drawing.Point(419, 48);
			this.BallisticsScopeClickTextBox.MaxLength = 5;
			this.BallisticsScopeClickTextBox.MaxValue = 0D;
			this.BallisticsScopeClickTextBox.MinValue = 0D;
			this.BallisticsScopeClickTextBox.Name = "BallisticsScopeClickTextBox";
			this.BallisticsScopeClickTextBox.NumDecimals = 3;
			this.BallisticsScopeClickTextBox.Size = new System.Drawing.Size(38, 20);
			this.BallisticsScopeClickTextBox.TabIndex = 6;
			this.BallisticsScopeClickTextBox.Text = "0.000";
			this.BallisticsScopeClickTextBox.ToolTip = "";
			this.BallisticsScopeClickTextBox.Value = 0D;
			this.BallisticsScopeClickTextBox.ZeroAllowed = true;
			// 
			// BallisticsBCTextBox
			// 
			this.BallisticsBCTextBox.BackColor = System.Drawing.SystemColors.Window;
			this.BallisticsBCTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BallisticsBCTextBox.Location = new System.Drawing.Point(116, 21);
			this.BallisticsBCTextBox.MaxLength = 5;
			this.BallisticsBCTextBox.MaxValue = 0D;
			this.BallisticsBCTextBox.MinValue = 0D;
			this.BallisticsBCTextBox.Name = "BallisticsBCTextBox";
			this.BallisticsBCTextBox.NumDecimals = 3;
			this.BallisticsBCTextBox.Size = new System.Drawing.Size(38, 20);
			this.BallisticsBCTextBox.TabIndex = 0;
			this.BallisticsBCTextBox.Text = "0.000";
			this.BallisticsBCTextBox.ToolTip = "";
			this.BallisticsBCTextBox.Value = 0D;
			this.BallisticsBCTextBox.ZeroAllowed = true;
			// 
			// BallisticsZeroRangeTextBox
			// 
			this.BallisticsZeroRangeTextBox.BackColor = System.Drawing.SystemColors.Window;
			this.BallisticsZeroRangeTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BallisticsZeroRangeTextBox.Location = new System.Drawing.Point(116, 48);
			this.BallisticsZeroRangeTextBox.MaxLength = 4;
			this.BallisticsZeroRangeTextBox.MaxValue = 0;
			this.BallisticsZeroRangeTextBox.MinValue = 0;
			this.BallisticsZeroRangeTextBox.Name = "BallisticsZeroRangeTextBox";
			this.BallisticsZeroRangeTextBox.Required = false;
			this.BallisticsZeroRangeTextBox.Size = new System.Drawing.Size(42, 20);
			this.BallisticsZeroRangeTextBox.TabIndex = 4;
			this.BallisticsZeroRangeTextBox.Text = "0";
			this.BallisticsZeroRangeTextBox.ToolTip = "";
			this.BallisticsZeroRangeTextBox.Value = 0;
			// 
			// ZeroRangeMeasurementLabel
			// 
			this.ZeroRangeMeasurementLabel.AutoSize = true;
			this.ZeroRangeMeasurementLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ZeroRangeMeasurementLabel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.ZeroRangeMeasurementLabel.Location = new System.Drawing.Point(162, 50);
			this.ZeroRangeMeasurementLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.ZeroRangeMeasurementLabel.Name = "ZeroRangeMeasurementLabel";
			this.ZeroRangeMeasurementLabel.Size = new System.Drawing.Size(23, 13);
			this.ZeroRangeMeasurementLabel.TabIndex = 20;
			this.ZeroRangeMeasurementLabel.Text = "yds";
			// 
			// BallisticsBulletDiameterTextBox
			// 
			this.BallisticsBulletDiameterTextBox.BackColor = System.Drawing.SystemColors.Window;
			this.BallisticsBulletDiameterTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BallisticsBulletDiameterTextBox.Location = new System.Drawing.Point(274, 22);
			this.BallisticsBulletDiameterTextBox.MaxLength = 5;
			this.BallisticsBulletDiameterTextBox.MaxValue = 0D;
			this.BallisticsBulletDiameterTextBox.MinValue = 0D;
			this.BallisticsBulletDiameterTextBox.Name = "BallisticsBulletDiameterTextBox";
			this.BallisticsBulletDiameterTextBox.NumDecimals = 3;
			this.BallisticsBulletDiameterTextBox.Size = new System.Drawing.Size(42, 20);
			this.BallisticsBulletDiameterTextBox.TabIndex = 1;
			this.BallisticsBulletDiameterTextBox.Text = "0.000";
			this.BallisticsBulletDiameterTextBox.ToolTip = "";
			this.BallisticsBulletDiameterTextBox.Value = 0D;
			this.BallisticsBulletDiameterTextBox.ZeroAllowed = true;
			// 
			// BulletDiameterMeasurementLabel
			// 
			this.BulletDiameterMeasurementLabel.AutoSize = true;
			this.BulletDiameterMeasurementLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BulletDiameterMeasurementLabel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.BulletDiameterMeasurementLabel.Location = new System.Drawing.Point(321, 25);
			this.BulletDiameterMeasurementLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.BulletDiameterMeasurementLabel.Name = "BulletDiameterMeasurementLabel";
			this.BulletDiameterMeasurementLabel.Size = new System.Drawing.Size(18, 13);
			this.BulletDiameterMeasurementLabel.TabIndex = 1;
			this.BulletDiameterMeasurementLabel.Text = "in.";
			// 
			// BallisticsBulletWeightTextBox
			// 
			this.BallisticsBulletWeightTextBox.BackColor = System.Drawing.SystemColors.Window;
			this.BallisticsBulletWeightTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BallisticsBulletWeightTextBox.Location = new System.Drawing.Point(449, 22);
			this.BallisticsBulletWeightTextBox.MaxLength = 5;
			this.BallisticsBulletWeightTextBox.MaxValue = 0D;
			this.BallisticsBulletWeightTextBox.MinValue = 0D;
			this.BallisticsBulletWeightTextBox.Name = "BallisticsBulletWeightTextBox";
			this.BallisticsBulletWeightTextBox.NumDecimals = 1;
			this.BallisticsBulletWeightTextBox.Size = new System.Drawing.Size(46, 20);
			this.BallisticsBulletWeightTextBox.TabIndex = 2;
			this.BallisticsBulletWeightTextBox.Text = "0.0";
			this.BallisticsBulletWeightTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.BallisticsBulletWeightTextBox.ToolTip = "";
			this.BallisticsBulletWeightTextBox.Value = 0D;
			this.BallisticsBulletWeightTextBox.ZeroAllowed = true;
			// 
			// BulletWeightMeasurementLabel
			// 
			this.BulletWeightMeasurementLabel.AutoSize = true;
			this.BulletWeightMeasurementLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BulletWeightMeasurementLabel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.BulletWeightMeasurementLabel.Location = new System.Drawing.Point(500, 25);
			this.BulletWeightMeasurementLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.BulletWeightMeasurementLabel.Name = "BulletWeightMeasurementLabel";
			this.BulletWeightMeasurementLabel.Size = new System.Drawing.Size(16, 13);
			this.BulletWeightMeasurementLabel.TabIndex = 2;
			this.BulletWeightMeasurementLabel.Text = "gr";
			// 
			// SaveReferenceBulletButton
			// 
			this.SaveReferenceBulletButton.AutoSize = true;
			this.SaveReferenceBulletButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.SaveReferenceBulletButton.ForeColor = System.Drawing.SystemColors.ControlText;
			this.SaveReferenceBulletButton.Location = new System.Drawing.Point(277, 248);
			this.SaveReferenceBulletButton.Margin = new System.Windows.Forms.Padding(2);
			this.SaveReferenceBulletButton.Name = "SaveReferenceBulletButton";
			this.SaveReferenceBulletButton.Size = new System.Drawing.Size(138, 23);
			this.SaveReferenceBulletButton.TabIndex = 2;
			this.SaveReferenceBulletButton.Text = "Save as Reference Data";
			this.SaveReferenceBulletButton.UseVisualStyleBackColor = true;
			// 
			// RestoreReferenceBulletButton
			// 
			this.RestoreReferenceBulletButton.AutoSize = true;
			this.RestoreReferenceBulletButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.RestoreReferenceBulletButton.ForeColor = System.Drawing.SystemColors.ControlText;
			this.RestoreReferenceBulletButton.Location = new System.Drawing.Point(450, 248);
			this.RestoreReferenceBulletButton.Margin = new System.Windows.Forms.Padding(2);
			this.RestoreReferenceBulletButton.Name = "RestoreReferenceBulletButton";
			this.RestoreReferenceBulletButton.Size = new System.Drawing.Size(138, 23);
			this.RestoreReferenceBulletButton.TabIndex = 3;
			this.RestoreReferenceBulletButton.Text = "Restore Reference Data";
			this.RestoreReferenceBulletButton.UseVisualStyleBackColor = true;
			// 
			// label28
			// 
			this.label28.AutoSize = true;
			this.label28.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label28.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label28.Location = new System.Drawing.Point(329, 51);
			this.label28.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label28.Name = "label28";
			this.label28.Size = new System.Drawing.Size(85, 13);
			this.label28.TabIndex = 5;
			this.label28.Text = "Turret Click Inc.:";
			// 
			// label26
			// 
			this.label26.AutoSize = true;
			this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label26.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label26.Location = new System.Drawing.Point(202, 50);
			this.label26.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label26.Name = "label26";
			this.label26.Size = new System.Drawing.Size(68, 13);
			this.label26.TabIndex = 6;
			this.label26.Text = "Sight Height:";
			// 
			// label24
			// 
			this.label24.AutoSize = true;
			this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label24.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label24.Location = new System.Drawing.Point(44, 50);
			this.label24.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label24.Name = "label24";
			this.label24.Size = new System.Drawing.Size(67, 13);
			this.label24.TabIndex = 19;
			this.label24.Text = "Zero Range:";
			// 
			// label18
			// 
			this.label18.AutoSize = true;
			this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label18.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label18.Location = new System.Drawing.Point(188, 25);
			this.label18.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(81, 13);
			this.label18.TabIndex = 1;
			this.label18.Text = "Bullet Diameter:";
			// 
			// label16
			// 
			this.label16.AutoSize = true;
			this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label16.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label16.Location = new System.Drawing.Point(371, 25);
			this.label16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(73, 13);
			this.label16.TabIndex = 8;
			this.label16.Text = "Bullet Weight:";
			// 
			// label15
			// 
			this.label15.AutoSize = true;
			this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label15.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label15.Location = new System.Drawing.Point(13, 25);
			this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(98, 13);
			this.label15.TabIndex = 6;
			this.label15.Text = "Ballistic Coefficient:";
			// 
			// BatchBulletLabel
			// 
			this.BatchBulletLabel.AutoSize = true;
			this.BatchBulletLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BatchBulletLabel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.BatchBulletLabel.Location = new System.Drawing.Point(302, 24);
			this.BatchBulletLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.BatchBulletLabel.Name = "BatchBulletLabel";
			this.BatchBulletLabel.Size = new System.Drawing.Size(36, 13);
			this.BatchBulletLabel.TabIndex = 4;
			this.BatchBulletLabel.Text = "Bullet:";
			// 
			// AmmoTab
			// 
			this.AmmoTab.Controls.Add(this.AmmoInventoryGroup);
			this.AmmoTab.Controls.Add(this.AmmoPrintOptionsGroupBox);
			this.AmmoTab.Controls.Add(this.ViewAmmoButton);
			this.AmmoTab.Controls.Add(this.RemoveAmmoButton);
			this.AmmoTab.Controls.Add(this.EditAmmoButton);
			this.AmmoTab.Controls.Add(this.AddAmmoButton);
			this.AmmoTab.Location = new System.Drawing.Point(4, 22);
			this.AmmoTab.Name = "AmmoTab";
			this.AmmoTab.Padding = new System.Windows.Forms.Padding(3);
			this.AmmoTab.Size = new System.Drawing.Size(1465, 1025);
			this.AmmoTab.TabIndex = 10;
			this.AmmoTab.Text = "Ammunition";
			this.AmmoTab.UseVisualStyleBackColor = true;
			// 
			// AmmoInventoryGroup
			// 
			this.AmmoInventoryGroup.Controls.Add(this.AmmoCostAnalysisButton);
			this.AmmoInventoryGroup.Controls.Add(this.ViewAmmoInventoryButton);
			this.AmmoInventoryGroup.Controls.Add(this.EditAmmoInventoryButton);
			this.AmmoInventoryGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.AmmoInventoryGroup.ForeColor = System.Drawing.SystemColors.HotTrack;
			this.AmmoInventoryGroup.Location = new System.Drawing.Point(587, 6);
			this.AmmoInventoryGroup.Name = "AmmoInventoryGroup";
			this.AmmoInventoryGroup.Size = new System.Drawing.Size(315, 94);
			this.AmmoInventoryGroup.TabIndex = 15;
			this.AmmoInventoryGroup.TabStop = false;
			this.AmmoInventoryGroup.Text = "Inventory";
			// 
			// AmmoCostAnalysisButton
			// 
			this.AmmoCostAnalysisButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.AmmoCostAnalysisButton.ForeColor = System.Drawing.SystemColors.ControlText;
			this.AmmoCostAnalysisButton.Location = new System.Drawing.Point(215, 36);
			this.AmmoCostAnalysisButton.Margin = new System.Windows.Forms.Padding(2);
			this.AmmoCostAnalysisButton.Name = "AmmoCostAnalysisButton";
			this.AmmoCostAnalysisButton.Size = new System.Drawing.Size(79, 23);
			this.AmmoCostAnalysisButton.TabIndex = 22;
			this.AmmoCostAnalysisButton.Text = "Cost Analysis";
			this.AmmoCostAnalysisButton.UseVisualStyleBackColor = true;
			// 
			// ViewAmmoInventoryButton
			// 
			this.ViewAmmoInventoryButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ViewAmmoInventoryButton.ForeColor = System.Drawing.SystemColors.ControlText;
			this.ViewAmmoInventoryButton.Location = new System.Drawing.Point(119, 36);
			this.ViewAmmoInventoryButton.Margin = new System.Windows.Forms.Padding(2);
			this.ViewAmmoInventoryButton.Name = "ViewAmmoInventoryButton";
			this.ViewAmmoInventoryButton.Size = new System.Drawing.Size(79, 23);
			this.ViewAmmoInventoryButton.TabIndex = 21;
			this.ViewAmmoInventoryButton.Text = "View Activity";
			this.ViewAmmoInventoryButton.UseVisualStyleBackColor = true;
			// 
			// EditAmmoInventoryButton
			// 
			this.EditAmmoInventoryButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.EditAmmoInventoryButton.ForeColor = System.Drawing.SystemColors.ControlText;
			this.EditAmmoInventoryButton.Location = new System.Drawing.Point(23, 36);
			this.EditAmmoInventoryButton.Margin = new System.Windows.Forms.Padding(2);
			this.EditAmmoInventoryButton.Name = "EditAmmoInventoryButton";
			this.EditAmmoInventoryButton.Size = new System.Drawing.Size(79, 23);
			this.EditAmmoInventoryButton.TabIndex = 20;
			this.EditAmmoInventoryButton.Text = "Edit Activity";
			this.EditAmmoInventoryButton.UseVisualStyleBackColor = true;
			// 
			// AmmoPrintOptionsGroupBox
			// 
			this.AmmoPrintOptionsGroupBox.Controls.Add(this.AmmoPrintBelowStockCheckBox);
			this.AmmoPrintOptionsGroupBox.Controls.Add(this.NoAmmoListLabel);
			this.AmmoPrintOptionsGroupBox.Controls.Add(this.AmmoPrintFactoryOnlyCheckBox);
			this.AmmoPrintOptionsGroupBox.Controls.Add(this.AmmoPrintNonZeroCheckBox);
			this.AmmoPrintOptionsGroupBox.Controls.Add(this.AmmoPrintCheckedRadioButton);
			this.AmmoPrintOptionsGroupBox.Controls.Add(this.AmmoPrintAllRadioButton);
			this.AmmoPrintOptionsGroupBox.Controls.Add(this.AmmoListPrintButton);
			this.AmmoPrintOptionsGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.AmmoPrintOptionsGroupBox.ForeColor = System.Drawing.SystemColors.HotTrack;
			this.AmmoPrintOptionsGroupBox.Location = new System.Drawing.Point(8, 6);
			this.AmmoPrintOptionsGroupBox.Name = "AmmoPrintOptionsGroupBox";
			this.AmmoPrintOptionsGroupBox.Size = new System.Drawing.Size(573, 94);
			this.AmmoPrintOptionsGroupBox.TabIndex = 9;
			this.AmmoPrintOptionsGroupBox.TabStop = false;
			this.AmmoPrintOptionsGroupBox.Text = "Print Options";
			// 
			// AmmoPrintBelowStockCheckBox
			// 
			this.AmmoPrintBelowStockCheckBox.AutoCheck = false;
			this.AmmoPrintBelowStockCheckBox.AutoSize = true;
			this.AmmoPrintBelowStockCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.AmmoPrintBelowStockCheckBox.ForeColor = System.Drawing.SystemColors.ControlText;
			this.AmmoPrintBelowStockCheckBox.Location = new System.Drawing.Point(139, 47);
			this.AmmoPrintBelowStockCheckBox.Name = "AmmoPrintBelowStockCheckBox";
			this.AmmoPrintBelowStockCheckBox.Size = new System.Drawing.Size(183, 17);
			this.AmmoPrintBelowStockCheckBox.TabIndex = 17;
			this.AmmoPrintBelowStockCheckBox.Text = "Below Minimum Stock Level Only";
			this.AmmoPrintBelowStockCheckBox.UseVisualStyleBackColor = true;
			// 
			// NoAmmoListLabel
			// 
			this.NoAmmoListLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.NoAmmoListLabel.ForeColor = System.Drawing.Color.Maroon;
			this.NoAmmoListLabel.Location = new System.Drawing.Point(12, 70);
			this.NoAmmoListLabel.Name = "NoAmmoListLabel";
			this.NoAmmoListLabel.Size = new System.Drawing.Size(443, 13);
			this.NoAmmoListLabel.TabIndex = 16;
			this.NoAmmoListLabel.Text = "No Ammo meets the above criteria";
			this.NoAmmoListLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// AmmoPrintFactoryOnlyCheckBox
			// 
			this.AmmoPrintFactoryOnlyCheckBox.AutoCheck = false;
			this.AmmoPrintFactoryOnlyCheckBox.AutoSize = true;
			this.AmmoPrintFactoryOnlyCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.AmmoPrintFactoryOnlyCheckBox.ForeColor = System.Drawing.SystemColors.ControlText;
			this.AmmoPrintFactoryOnlyCheckBox.Location = new System.Drawing.Point(338, 24);
			this.AmmoPrintFactoryOnlyCheckBox.Name = "AmmoPrintFactoryOnlyCheckBox";
			this.AmmoPrintFactoryOnlyCheckBox.Size = new System.Drawing.Size(117, 17);
			this.AmmoPrintFactoryOnlyCheckBox.TabIndex = 8;
			this.AmmoPrintFactoryOnlyCheckBox.Text = "Factory Ammo Only";
			this.AmmoPrintFactoryOnlyCheckBox.UseVisualStyleBackColor = true;
			// 
			// AmmoPrintNonZeroCheckBox
			// 
			this.AmmoPrintNonZeroCheckBox.AutoCheck = false;
			this.AmmoPrintNonZeroCheckBox.AutoSize = true;
			this.AmmoPrintNonZeroCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.AmmoPrintNonZeroCheckBox.ForeColor = System.Drawing.SystemColors.ControlText;
			this.AmmoPrintNonZeroCheckBox.Location = new System.Drawing.Point(139, 24);
			this.AmmoPrintNonZeroCheckBox.Name = "AmmoPrintNonZeroCheckBox";
			this.AmmoPrintNonZeroCheckBox.Size = new System.Drawing.Size(145, 17);
			this.AmmoPrintNonZeroCheckBox.TabIndex = 7;
			this.AmmoPrintNonZeroCheckBox.Text = "Non-Zero Quantities Only";
			this.AmmoPrintNonZeroCheckBox.UseVisualStyleBackColor = true;
			// 
			// AmmoPrintCheckedRadioButton
			// 
			this.AmmoPrintCheckedRadioButton.AutoCheck = false;
			this.AmmoPrintCheckedRadioButton.AutoSize = true;
			this.AmmoPrintCheckedRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.AmmoPrintCheckedRadioButton.ForeColor = System.Drawing.SystemColors.ControlText;
			this.AmmoPrintCheckedRadioButton.Location = new System.Drawing.Point(15, 46);
			this.AmmoPrintCheckedRadioButton.Name = "AmmoPrintCheckedRadioButton";
			this.AmmoPrintCheckedRadioButton.Size = new System.Drawing.Size(92, 17);
			this.AmmoPrintCheckedRadioButton.TabIndex = 6;
			this.AmmoPrintCheckedRadioButton.TabStop = true;
			this.AmmoPrintCheckedRadioButton.Text = "Checked Only";
			this.AmmoPrintCheckedRadioButton.UseVisualStyleBackColor = true;
			// 
			// AmmoPrintAllRadioButton
			// 
			this.AmmoPrintAllRadioButton.AutoCheck = false;
			this.AmmoPrintAllRadioButton.AutoSize = true;
			this.AmmoPrintAllRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.AmmoPrintAllRadioButton.ForeColor = System.Drawing.SystemColors.ControlText;
			this.AmmoPrintAllRadioButton.Location = new System.Drawing.Point(15, 23);
			this.AmmoPrintAllRadioButton.Name = "AmmoPrintAllRadioButton";
			this.AmmoPrintAllRadioButton.Size = new System.Drawing.Size(68, 17);
			this.AmmoPrintAllRadioButton.TabIndex = 5;
			this.AmmoPrintAllRadioButton.TabStop = true;
			this.AmmoPrintAllRadioButton.Text = "All Ammo";
			this.AmmoPrintAllRadioButton.UseVisualStyleBackColor = true;
			// 
			// AmmoListPrintButton
			// 
			this.AmmoListPrintButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.AmmoListPrintButton.ForeColor = System.Drawing.SystemColors.ControlText;
			this.AmmoListPrintButton.Location = new System.Drawing.Point(484, 36);
			this.AmmoListPrintButton.Name = "AmmoListPrintButton";
			this.AmmoListPrintButton.Size = new System.Drawing.Size(75, 23);
			this.AmmoListPrintButton.TabIndex = 4;
			this.AmmoListPrintButton.Text = "Print";
			this.AmmoListPrintButton.UseVisualStyleBackColor = true;
			// 
			// ViewAmmoButton
			// 
			this.ViewAmmoButton.Location = new System.Drawing.Point(511, 443);
			this.ViewAmmoButton.Margin = new System.Windows.Forms.Padding(2);
			this.ViewAmmoButton.Name = "ViewAmmoButton";
			this.ViewAmmoButton.Size = new System.Drawing.Size(56, 19);
			this.ViewAmmoButton.TabIndex = 7;
			this.ViewAmmoButton.Text = "View";
			this.ViewAmmoButton.UseVisualStyleBackColor = true;
			// 
			// RemoveAmmoButton
			// 
			this.RemoveAmmoButton.Location = new System.Drawing.Point(583, 443);
			this.RemoveAmmoButton.Margin = new System.Windows.Forms.Padding(2);
			this.RemoveAmmoButton.Name = "RemoveAmmoButton";
			this.RemoveAmmoButton.Size = new System.Drawing.Size(56, 19);
			this.RemoveAmmoButton.TabIndex = 8;
			this.RemoveAmmoButton.Text = "Remove";
			this.RemoveAmmoButton.UseVisualStyleBackColor = true;
			// 
			// EditAmmoButton
			// 
			this.EditAmmoButton.Location = new System.Drawing.Point(438, 443);
			this.EditAmmoButton.Margin = new System.Windows.Forms.Padding(2);
			this.EditAmmoButton.Name = "EditAmmoButton";
			this.EditAmmoButton.Size = new System.Drawing.Size(56, 19);
			this.EditAmmoButton.TabIndex = 6;
			this.EditAmmoButton.Text = "Edit";
			this.EditAmmoButton.UseVisualStyleBackColor = true;
			// 
			// AddAmmoButton
			// 
			this.AddAmmoButton.Location = new System.Drawing.Point(357, 443);
			this.AddAmmoButton.Margin = new System.Windows.Forms.Padding(2);
			this.AddAmmoButton.Name = "AddAmmoButton";
			this.AddAmmoButton.Size = new System.Drawing.Size(56, 19);
			this.AddAmmoButton.TabIndex = 5;
			this.AddAmmoButton.Text = "Add";
			this.AddAmmoButton.UseVisualStyleBackColor = true;
			// 
			// BatchEditorTab
			// 
			this.BatchEditorTab.Controls.Add(this.BatchNotTrackedLabel);
			this.BatchEditorTab.Controls.Add(this.NoInventoryWarningLabel);
			this.BatchEditorTab.Controls.Add(this.BatchEditorActionsGroupBox);
			this.BatchEditorTab.Controls.Add(this.ViewBatchButton);
			this.BatchEditorTab.Controls.Add(this.RemoveBatchButton);
			this.BatchEditorTab.Controls.Add(this.EditBatchButton);
			this.BatchEditorTab.Controls.Add(this.AddBatchButton);
			this.BatchEditorTab.Controls.Add(this.BatchFiltersGroupBox);
			this.BatchEditorTab.Location = new System.Drawing.Point(4, 22);
			this.BatchEditorTab.Margin = new System.Windows.Forms.Padding(2);
			this.BatchEditorTab.Name = "BatchEditorTab";
			this.BatchEditorTab.Size = new System.Drawing.Size(1465, 1025);
			this.BatchEditorTab.TabIndex = 2;
			this.BatchEditorTab.Text = "Batch Editor";
			this.BatchEditorTab.ToolTipText = "Manage batches of cartridges that you create.";
			this.BatchEditorTab.UseVisualStyleBackColor = true;
			// 
			// BatchNotTrackedLabel
			// 
			this.BatchNotTrackedLabel.AutoSize = true;
			this.BatchNotTrackedLabel.Location = new System.Drawing.Point(14, 444);
			this.BatchNotTrackedLabel.Name = "BatchNotTrackedLabel";
			this.BatchNotTrackedLabel.Size = new System.Drawing.Size(136, 13);
			this.BatchNotTrackedLabel.TabIndex = 17;
			this.BatchNotTrackedLabel.Text = "* = Not tracked in inventory";
			// 
			// NoInventoryWarningLabel
			// 
			this.NoInventoryWarningLabel.ForeColor = System.Drawing.Color.DarkRed;
			this.NoInventoryWarningLabel.Location = new System.Drawing.Point(998, 29);
			this.NoInventoryWarningLabel.Name = "NoInventoryWarningLabel";
			this.NoInventoryWarningLabel.Size = new System.Drawing.Size(270, 70);
			this.NoInventoryWarningLabel.TabIndex = 16;
			this.NoInventoryWarningLabel.Text = "No Inventory Warning Label";
			// 
			// BatchEditorActionsGroupBox
			// 
			this.BatchEditorActionsGroupBox.Controls.Add(this.PrintCheckedBatchLabelsButton);
			this.BatchEditorActionsGroupBox.Controls.Add(this.ShowArchivedBatchesCheckBox);
			this.BatchEditorActionsGroupBox.Controls.Add(this.UnarchiveCheckedButton);
			this.BatchEditorActionsGroupBox.Controls.Add(this.ArchiveCheckedButton);
			this.BatchEditorActionsGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BatchEditorActionsGroupBox.ForeColor = System.Drawing.SystemColors.HotTrack;
			this.BatchEditorActionsGroupBox.Location = new System.Drawing.Point(619, 16);
			this.BatchEditorActionsGroupBox.Margin = new System.Windows.Forms.Padding(2);
			this.BatchEditorActionsGroupBox.Name = "BatchEditorActionsGroupBox";
			this.BatchEditorActionsGroupBox.Padding = new System.Windows.Forms.Padding(2);
			this.BatchEditorActionsGroupBox.Size = new System.Drawing.Size(347, 83);
			this.BatchEditorActionsGroupBox.TabIndex = 15;
			this.BatchEditorActionsGroupBox.TabStop = false;
			this.BatchEditorActionsGroupBox.Text = "Additional Actions";
			// 
			// PrintCheckedBatchLabelsButton
			// 
			this.PrintCheckedBatchLabelsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.PrintCheckedBatchLabelsButton.ForeColor = System.Drawing.SystemColors.ControlText;
			this.PrintCheckedBatchLabelsButton.Location = new System.Drawing.Point(174, 51);
			this.PrintCheckedBatchLabelsButton.Margin = new System.Windows.Forms.Padding(2);
			this.PrintCheckedBatchLabelsButton.Name = "PrintCheckedBatchLabelsButton";
			this.PrintCheckedBatchLabelsButton.Size = new System.Drawing.Size(157, 19);
			this.PrintCheckedBatchLabelsButton.TabIndex = 9;
			this.PrintCheckedBatchLabelsButton.Text = "Print Checked Batch Labels";
			this.PrintCheckedBatchLabelsButton.UseVisualStyleBackColor = true;
			// 
			// ShowArchivedBatchesCheckBox
			// 
			this.ShowArchivedBatchesCheckBox.AutoCheck = false;
			this.ShowArchivedBatchesCheckBox.AutoSize = true;
			this.ShowArchivedBatchesCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ShowArchivedBatchesCheckBox.ForeColor = System.Drawing.SystemColors.ControlText;
			this.ShowArchivedBatchesCheckBox.Location = new System.Drawing.Point(174, 24);
			this.ShowArchivedBatchesCheckBox.Name = "ShowArchivedBatchesCheckBox";
			this.ShowArchivedBatchesCheckBox.Size = new System.Drawing.Size(140, 17);
			this.ShowArchivedBatchesCheckBox.TabIndex = 8;
			this.ShowArchivedBatchesCheckBox.Text = "Show Archived Batches";
			this.ShowArchivedBatchesCheckBox.UseVisualStyleBackColor = true;
			// 
			// UnarchiveCheckedButton
			// 
			this.UnarchiveCheckedButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.UnarchiveCheckedButton.ForeColor = System.Drawing.SystemColors.ControlText;
			this.UnarchiveCheckedButton.Location = new System.Drawing.Point(21, 51);
			this.UnarchiveCheckedButton.Margin = new System.Windows.Forms.Padding(2);
			this.UnarchiveCheckedButton.Name = "UnarchiveCheckedButton";
			this.UnarchiveCheckedButton.Size = new System.Drawing.Size(115, 19);
			this.UnarchiveCheckedButton.TabIndex = 7;
			this.UnarchiveCheckedButton.Text = "Unarchive Checked";
			this.UnarchiveCheckedButton.UseVisualStyleBackColor = true;
			// 
			// ArchiveCheckedButton
			// 
			this.ArchiveCheckedButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ArchiveCheckedButton.ForeColor = System.Drawing.SystemColors.ControlText;
			this.ArchiveCheckedButton.Location = new System.Drawing.Point(21, 24);
			this.ArchiveCheckedButton.Margin = new System.Windows.Forms.Padding(2);
			this.ArchiveCheckedButton.Name = "ArchiveCheckedButton";
			this.ArchiveCheckedButton.Size = new System.Drawing.Size(115, 19);
			this.ArchiveCheckedButton.TabIndex = 5;
			this.ArchiveCheckedButton.Text = "Archive Checked";
			this.ArchiveCheckedButton.UseVisualStyleBackColor = true;
			// 
			// ViewBatchButton
			// 
			this.ViewBatchButton.Location = new System.Drawing.Point(487, 444);
			this.ViewBatchButton.Margin = new System.Windows.Forms.Padding(2);
			this.ViewBatchButton.Name = "ViewBatchButton";
			this.ViewBatchButton.Size = new System.Drawing.Size(56, 19);
			this.ViewBatchButton.TabIndex = 3;
			this.ViewBatchButton.Text = "View";
			this.ViewBatchButton.UseVisualStyleBackColor = true;
			// 
			// RemoveBatchButton
			// 
			this.RemoveBatchButton.Location = new System.Drawing.Point(559, 444);
			this.RemoveBatchButton.Margin = new System.Windows.Forms.Padding(2);
			this.RemoveBatchButton.Name = "RemoveBatchButton";
			this.RemoveBatchButton.Size = new System.Drawing.Size(56, 19);
			this.RemoveBatchButton.TabIndex = 4;
			this.RemoveBatchButton.Text = "Remove";
			this.RemoveBatchButton.UseVisualStyleBackColor = true;
			// 
			// EditBatchButton
			// 
			this.EditBatchButton.Location = new System.Drawing.Point(414, 444);
			this.EditBatchButton.Margin = new System.Windows.Forms.Padding(2);
			this.EditBatchButton.Name = "EditBatchButton";
			this.EditBatchButton.Size = new System.Drawing.Size(56, 19);
			this.EditBatchButton.TabIndex = 2;
			this.EditBatchButton.Text = "Edit";
			this.EditBatchButton.UseVisualStyleBackColor = true;
			// 
			// AddBatchButton
			// 
			this.AddBatchButton.Location = new System.Drawing.Point(333, 444);
			this.AddBatchButton.Margin = new System.Windows.Forms.Padding(2);
			this.AddBatchButton.Name = "AddBatchButton";
			this.AddBatchButton.Size = new System.Drawing.Size(56, 19);
			this.AddBatchButton.TabIndex = 1;
			this.AddBatchButton.Text = "Add";
			this.AddBatchButton.UseVisualStyleBackColor = true;
			// 
			// BatchFiltersGroupBox
			// 
			this.BatchFiltersGroupBox.Controls.Add(BatchFirearmTypeLabel);
			this.BatchFiltersGroupBox.Controls.Add(this.BatchFirearmTypeCombo);
			this.BatchFiltersGroupBox.Controls.Add(BatchCaliberLabel);
			this.BatchFiltersGroupBox.Controls.Add(this.BatchCaliberCombo);
			this.BatchFiltersGroupBox.Controls.Add(this.BatchBulletLabel);
			this.BatchFiltersGroupBox.Controls.Add(this.BatchBulletCombo);
			this.BatchFiltersGroupBox.Controls.Add(BatchPowderLabel);
			this.BatchFiltersGroupBox.Controls.Add(this.BatchPowderCombo);
			this.BatchFiltersGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BatchFiltersGroupBox.ForeColor = System.Drawing.SystemColors.HotTrack;
			this.BatchFiltersGroupBox.Location = new System.Drawing.Point(12, 16);
			this.BatchFiltersGroupBox.Margin = new System.Windows.Forms.Padding(2);
			this.BatchFiltersGroupBox.Name = "BatchFiltersGroupBox";
			this.BatchFiltersGroupBox.Padding = new System.Windows.Forms.Padding(2);
			this.BatchFiltersGroupBox.Size = new System.Drawing.Size(603, 83);
			this.BatchFiltersGroupBox.TabIndex = 0;
			this.BatchFiltersGroupBox.TabStop = false;
			this.BatchFiltersGroupBox.Text = "Filters";
			// 
			// BatchFirearmTypeCombo
			// 
			this.BatchFirearmTypeCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.BatchFirearmTypeCombo.DropDownWidth = 115;
			this.BatchFirearmTypeCombo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BatchFirearmTypeCombo.FormattingEnabled = true;
			this.BatchFirearmTypeCombo.IncludeShotgun = false;
			this.BatchFirearmTypeCombo.Items.AddRange(new object[] {
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle"});
			this.BatchFirearmTypeCombo.Location = new System.Drawing.Point(83, 22);
			this.BatchFirearmTypeCombo.Name = "BatchFirearmTypeCombo";
			this.BatchFirearmTypeCombo.Size = new System.Drawing.Size(100, 21);
			this.BatchFirearmTypeCombo.TabIndex = 15;
			this.BatchFirearmTypeCombo.ToolTip = "";
			this.BatchFirearmTypeCombo.Value = ReloadersWorkShop.cFirearm.eFireArmType.Handgun;
			// 
			// BatchCaliberCombo
			// 
			this.BatchCaliberCombo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
			this.BatchCaliberCombo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.BatchCaliberCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.BatchCaliberCombo.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BatchCaliberCombo.FormattingEnabled = true;
			this.BatchCaliberCombo.Location = new System.Drawing.Point(83, 47);
			this.BatchCaliberCombo.Margin = new System.Windows.Forms.Padding(2);
			this.BatchCaliberCombo.Name = "BatchCaliberCombo";
			this.BatchCaliberCombo.Size = new System.Drawing.Size(200, 21);
			this.BatchCaliberCombo.TabIndex = 1;
			// 
			// BatchBulletCombo
			// 
			this.BatchBulletCombo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
			this.BatchBulletCombo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.BatchBulletCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.BatchBulletCombo.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BatchBulletCombo.FormattingEnabled = true;
			this.BatchBulletCombo.Location = new System.Drawing.Point(343, 22);
			this.BatchBulletCombo.Margin = new System.Windows.Forms.Padding(2);
			this.BatchBulletCombo.MaxDropDownItems = 15;
			this.BatchBulletCombo.Name = "BatchBulletCombo";
			this.BatchBulletCombo.Size = new System.Drawing.Size(250, 21);
			this.BatchBulletCombo.TabIndex = 2;
			// 
			// BatchPowderCombo
			// 
			this.BatchPowderCombo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
			this.BatchPowderCombo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.BatchPowderCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.BatchPowderCombo.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BatchPowderCombo.FormattingEnabled = true;
			this.BatchPowderCombo.Location = new System.Drawing.Point(343, 46);
			this.BatchPowderCombo.Margin = new System.Windows.Forms.Padding(2);
			this.BatchPowderCombo.Name = "BatchPowderCombo";
			this.BatchPowderCombo.Size = new System.Drawing.Size(200, 21);
			this.BatchPowderCombo.TabIndex = 3;
			// 
			// LoadDataTab
			// 
			this.LoadDataTab.Controls.Add(this.LoadDataListViewInfoLabel);
			this.LoadDataTab.Controls.Add(this.LoadDataDeselectAllButton);
			this.LoadDataTab.Controls.Add(this.LoadDataSelectAllButton);
			this.LoadDataTab.Controls.Add(this.ViewLoadButton);
			this.LoadDataTab.Controls.Add(this.RemoveLoadButton);
			this.LoadDataTab.Controls.Add(this.EditLoadButton);
			this.LoadDataTab.Controls.Add(this.AddLoadButton);
			this.LoadDataTab.Controls.Add(this.LoadDataFiltersGroupBox);
			this.LoadDataTab.Controls.Add(this.groupBox5);
			this.LoadDataTab.Location = new System.Drawing.Point(4, 22);
			this.LoadDataTab.Margin = new System.Windows.Forms.Padding(2);
			this.LoadDataTab.Name = "LoadDataTab";
			this.LoadDataTab.Padding = new System.Windows.Forms.Padding(2);
			this.LoadDataTab.Size = new System.Drawing.Size(1465, 1025);
			this.LoadDataTab.TabIndex = 1;
			this.LoadDataTab.Text = "Load Data";
			this.LoadDataTab.ToolTipText = "Manage list of loads.";
			this.LoadDataTab.UseVisualStyleBackColor = true;
			// 
			// LoadDataListViewInfoLabel
			// 
			this.LoadDataListViewInfoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LoadDataListViewInfoLabel.Location = new System.Drawing.Point(22, 105);
			this.LoadDataListViewInfoLabel.Name = "LoadDataListViewInfoLabel";
			this.LoadDataListViewInfoLabel.Size = new System.Drawing.Size(967, 13);
			this.LoadDataListViewInfoLabel.TabIndex = 13;
			this.LoadDataListViewInfoLabel.Text = "NOTE: Charge weights listed in bold have been used in one or more batches.";
			this.LoadDataListViewInfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// LoadDataDeselectAllButton
			// 
			this.LoadDataDeselectAllButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.LoadDataDeselectAllButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LoadDataDeselectAllButton.ForeColor = System.Drawing.SystemColors.ControlText;
			this.LoadDataDeselectAllButton.Location = new System.Drawing.Point(22, 376);
			this.LoadDataDeselectAllButton.Margin = new System.Windows.Forms.Padding(2);
			this.LoadDataDeselectAllButton.Name = "LoadDataDeselectAllButton";
			this.LoadDataDeselectAllButton.Size = new System.Drawing.Size(80, 20);
			this.LoadDataDeselectAllButton.TabIndex = 12;
			this.LoadDataDeselectAllButton.Text = "Uncheck All";
			this.LoadDataDeselectAllButton.UseVisualStyleBackColor = true;
			// 
			// LoadDataSelectAllButton
			// 
			this.LoadDataSelectAllButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.LoadDataSelectAllButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LoadDataSelectAllButton.ForeColor = System.Drawing.SystemColors.ControlText;
			this.LoadDataSelectAllButton.Location = new System.Drawing.Point(22, 352);
			this.LoadDataSelectAllButton.Margin = new System.Windows.Forms.Padding(2);
			this.LoadDataSelectAllButton.Name = "LoadDataSelectAllButton";
			this.LoadDataSelectAllButton.Size = new System.Drawing.Size(80, 20);
			this.LoadDataSelectAllButton.TabIndex = 10;
			this.LoadDataSelectAllButton.Text = "Check All";
			this.LoadDataSelectAllButton.UseVisualStyleBackColor = true;
			// 
			// ViewLoadButton
			// 
			this.ViewLoadButton.Location = new System.Drawing.Point(519, 352);
			this.ViewLoadButton.Margin = new System.Windows.Forms.Padding(2);
			this.ViewLoadButton.Name = "ViewLoadButton";
			this.ViewLoadButton.Size = new System.Drawing.Size(56, 19);
			this.ViewLoadButton.TabIndex = 3;
			this.ViewLoadButton.Text = "View";
			this.ViewLoadButton.UseVisualStyleBackColor = true;
			// 
			// RemoveLoadButton
			// 
			this.RemoveLoadButton.Location = new System.Drawing.Point(604, 352);
			this.RemoveLoadButton.Margin = new System.Windows.Forms.Padding(2);
			this.RemoveLoadButton.Name = "RemoveLoadButton";
			this.RemoveLoadButton.Size = new System.Drawing.Size(56, 20);
			this.RemoveLoadButton.TabIndex = 4;
			this.RemoveLoadButton.Text = "Remove";
			this.RemoveLoadButton.UseVisualStyleBackColor = true;
			// 
			// EditLoadButton
			// 
			this.EditLoadButton.Location = new System.Drawing.Point(438, 352);
			this.EditLoadButton.Margin = new System.Windows.Forms.Padding(2);
			this.EditLoadButton.Name = "EditLoadButton";
			this.EditLoadButton.Size = new System.Drawing.Size(56, 20);
			this.EditLoadButton.TabIndex = 2;
			this.EditLoadButton.Text = "Edit";
			this.EditLoadButton.UseVisualStyleBackColor = true;
			// 
			// AddLoadButton
			// 
			this.AddLoadButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.AddLoadButton.Location = new System.Drawing.Point(358, 352);
			this.AddLoadButton.Margin = new System.Windows.Forms.Padding(2);
			this.AddLoadButton.Name = "AddLoadButton";
			this.AddLoadButton.Size = new System.Drawing.Size(56, 20);
			this.AddLoadButton.TabIndex = 1;
			this.AddLoadButton.Text = "Add";
			this.AddLoadButton.UseVisualStyleBackColor = true;
			// 
			// LoadDataFiltersGroupBox
			// 
			this.LoadDataFiltersGroupBox.Controls.Add(LoadDataFiltersFirearmTypeLabel);
			this.LoadDataFiltersGroupBox.Controls.Add(this.LoadDataFirearmTypeCombo);
			this.LoadDataFiltersGroupBox.Controls.Add(LoadDataFiltersCaliberlabel);
			this.LoadDataFiltersGroupBox.Controls.Add(this.LoadDataCaliberCombo);
			this.LoadDataFiltersGroupBox.Controls.Add(LoadDataFiltersBulletLabel);
			this.LoadDataFiltersGroupBox.Controls.Add(this.LoadDataBulletCombo);
			this.LoadDataFiltersGroupBox.Controls.Add(LoadDataFiltersPowderLabel);
			this.LoadDataFiltersGroupBox.Controls.Add(this.LoadDataPowderCombo);
			this.LoadDataFiltersGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LoadDataFiltersGroupBox.ForeColor = System.Drawing.SystemColors.HotTrack;
			this.LoadDataFiltersGroupBox.Location = new System.Drawing.Point(12, 16);
			this.LoadDataFiltersGroupBox.Margin = new System.Windows.Forms.Padding(2);
			this.LoadDataFiltersGroupBox.Name = "LoadDataFiltersGroupBox";
			this.LoadDataFiltersGroupBox.Padding = new System.Windows.Forms.Padding(2);
			this.LoadDataFiltersGroupBox.Size = new System.Drawing.Size(603, 83);
			this.LoadDataFiltersGroupBox.TabIndex = 0;
			this.LoadDataFiltersGroupBox.TabStop = false;
			this.LoadDataFiltersGroupBox.Text = "Filters";
			// 
			// LoadDataFirearmTypeCombo
			// 
			this.LoadDataFirearmTypeCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.LoadDataFirearmTypeCombo.DropDownWidth = 115;
			this.LoadDataFirearmTypeCombo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LoadDataFirearmTypeCombo.FormattingEnabled = true;
			this.LoadDataFirearmTypeCombo.IncludeShotgun = false;
			this.LoadDataFirearmTypeCombo.Items.AddRange(new object[] {
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle",
            "Handgun",
            "Rifle"});
			this.LoadDataFirearmTypeCombo.Location = new System.Drawing.Point(83, 22);
			this.LoadDataFirearmTypeCombo.Name = "LoadDataFirearmTypeCombo";
			this.LoadDataFirearmTypeCombo.Size = new System.Drawing.Size(100, 21);
			this.LoadDataFirearmTypeCombo.TabIndex = 11;
			this.LoadDataFirearmTypeCombo.ToolTip = "";
			this.LoadDataFirearmTypeCombo.Value = ReloadersWorkShop.cFirearm.eFireArmType.Handgun;
			// 
			// LoadDataCaliberCombo
			// 
			this.LoadDataCaliberCombo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
			this.LoadDataCaliberCombo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.LoadDataCaliberCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.LoadDataCaliberCombo.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LoadDataCaliberCombo.FormattingEnabled = true;
			this.LoadDataCaliberCombo.Location = new System.Drawing.Point(83, 47);
			this.LoadDataCaliberCombo.Margin = new System.Windows.Forms.Padding(2);
			this.LoadDataCaliberCombo.Name = "LoadDataCaliberCombo";
			this.LoadDataCaliberCombo.Size = new System.Drawing.Size(200, 21);
			this.LoadDataCaliberCombo.TabIndex = 1;
			// 
			// LoadDataBulletCombo
			// 
			this.LoadDataBulletCombo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
			this.LoadDataBulletCombo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.LoadDataBulletCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.LoadDataBulletCombo.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LoadDataBulletCombo.FormattingEnabled = true;
			this.LoadDataBulletCombo.Location = new System.Drawing.Point(343, 22);
			this.LoadDataBulletCombo.Margin = new System.Windows.Forms.Padding(2);
			this.LoadDataBulletCombo.MaxDropDownItems = 15;
			this.LoadDataBulletCombo.Name = "LoadDataBulletCombo";
			this.LoadDataBulletCombo.Size = new System.Drawing.Size(250, 21);
			this.LoadDataBulletCombo.TabIndex = 2;
			// 
			// LoadDataPowderCombo
			// 
			this.LoadDataPowderCombo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
			this.LoadDataPowderCombo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.LoadDataPowderCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.LoadDataPowderCombo.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LoadDataPowderCombo.FormattingEnabled = true;
			this.LoadDataPowderCombo.Location = new System.Drawing.Point(343, 46);
			this.LoadDataPowderCombo.Margin = new System.Windows.Forms.Padding(2);
			this.LoadDataPowderCombo.Name = "LoadDataPowderCombo";
			this.LoadDataPowderCombo.Size = new System.Drawing.Size(200, 21);
			this.LoadDataPowderCombo.TabIndex = 3;
			// 
			// groupBox5
			// 
			this.groupBox5.Controls.Add(this.ImportShareFileButton);
			this.groupBox5.Controls.Add(this.ShareFileButton);
			this.groupBox5.Controls.Add(this.LoadShoppingListButton);
			this.groupBox5.Controls.Add(this.EvaluateLoadButton);
			this.groupBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox5.ForeColor = System.Drawing.SystemColors.HotTrack;
			this.groupBox5.Location = new System.Drawing.Point(619, 16);
			this.groupBox5.Margin = new System.Windows.Forms.Padding(2);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Padding = new System.Windows.Forms.Padding(2);
			this.groupBox5.Size = new System.Drawing.Size(263, 83);
			this.groupBox5.TabIndex = 11;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "Additional Actions";
			// 
			// ImportShareFileButton
			// 
			this.ImportShareFileButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.ImportShareFileButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ImportShareFileButton.ForeColor = System.Drawing.SystemColors.ControlText;
			this.ImportShareFileButton.Location = new System.Drawing.Point(132, 49);
			this.ImportShareFileButton.Margin = new System.Windows.Forms.Padding(2);
			this.ImportShareFileButton.Name = "ImportShareFileButton";
			this.ImportShareFileButton.Size = new System.Drawing.Size(109, 20);
			this.ImportShareFileButton.TabIndex = 9;
			this.ImportShareFileButton.Text = "Import Share File";
			this.ImportShareFileButton.UseVisualStyleBackColor = true;
			// 
			// ShareFileButton
			// 
			this.ShareFileButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.ShareFileButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ShareFileButton.ForeColor = System.Drawing.SystemColors.ControlText;
			this.ShareFileButton.Location = new System.Drawing.Point(132, 23);
			this.ShareFileButton.Margin = new System.Windows.Forms.Padding(2);
			this.ShareFileButton.Name = "ShareFileButton";
			this.ShareFileButton.Size = new System.Drawing.Size(109, 20);
			this.ShareFileButton.TabIndex = 6;
			this.ShareFileButton.Text = "Create Share File";
			this.ShareFileButton.UseVisualStyleBackColor = true;
			// 
			// LoadShoppingListButton
			// 
			this.LoadShoppingListButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.LoadShoppingListButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LoadShoppingListButton.ForeColor = System.Drawing.SystemColors.ControlText;
			this.LoadShoppingListButton.Location = new System.Drawing.Point(13, 49);
			this.LoadShoppingListButton.Margin = new System.Windows.Forms.Padding(2);
			this.LoadShoppingListButton.Name = "LoadShoppingListButton";
			this.LoadShoppingListButton.Size = new System.Drawing.Size(109, 20);
			this.LoadShoppingListButton.TabIndex = 8;
			this.LoadShoppingListButton.Text = "Shopping List";
			this.LoadShoppingListButton.UseVisualStyleBackColor = true;
			// 
			// EvaluateLoadButton
			// 
			this.EvaluateLoadButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.EvaluateLoadButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.EvaluateLoadButton.ForeColor = System.Drawing.SystemColors.ControlText;
			this.EvaluateLoadButton.Location = new System.Drawing.Point(13, 23);
			this.EvaluateLoadButton.Margin = new System.Windows.Forms.Padding(2);
			this.EvaluateLoadButton.Name = "EvaluateLoadButton";
			this.EvaluateLoadButton.Size = new System.Drawing.Size(109, 20);
			this.EvaluateLoadButton.TabIndex = 7;
			this.EvaluateLoadButton.Text = "Evaluate";
			this.EvaluateLoadButton.UseVisualStyleBackColor = true;
			// 
			// SuppliesTab
			// 
			this.SuppliesTab.Controls.Add(this.SuppliesInventoryGroup);
			this.SuppliesTab.Controls.Add(this.HideUncheckedSuppliesCheckBox);
			this.SuppliesTab.Controls.Add(this.SuppliesPrintOptionsGroupBox);
			this.SuppliesTab.Controls.Add(this.DeselectAllSuppliesButton);
			this.SuppliesTab.Controls.Add(this.SelectAllSuppliesButton);
			this.SuppliesTab.Controls.Add(this.SupplyCountLabel);
			this.SuppliesTab.Controls.Add(this.ViewSupplyButton);
			this.SuppliesTab.Controls.Add(this.SupplyTypeCombo);
			this.SuppliesTab.Controls.Add(label1);
			this.SuppliesTab.Controls.Add(this.RemoveSupplyButton);
			this.SuppliesTab.Controls.Add(this.EditSupplyButton);
			this.SuppliesTab.Controls.Add(this.AddSupplyButton);
			this.SuppliesTab.Location = new System.Drawing.Point(4, 22);
			this.SuppliesTab.Margin = new System.Windows.Forms.Padding(2);
			this.SuppliesTab.Name = "SuppliesTab";
			this.SuppliesTab.Padding = new System.Windows.Forms.Padding(2);
			this.SuppliesTab.Size = new System.Drawing.Size(1465, 1025);
			this.SuppliesTab.TabIndex = 0;
			this.SuppliesTab.Text = "Supplies";
			this.SuppliesTab.ToolTipText = "Manage list of reloading supplies that you use.";
			this.SuppliesTab.UseVisualStyleBackColor = true;
			// 
			// SuppliesInventoryGroup
			// 
			this.SuppliesInventoryGroup.Controls.Add(this.SuppliesCostAnalysisButton);
			this.SuppliesInventoryGroup.Controls.Add(this.ViewInventoryButton);
			this.SuppliesInventoryGroup.Controls.Add(this.EditInventoryButton);
			this.SuppliesInventoryGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.SuppliesInventoryGroup.ForeColor = System.Drawing.SystemColors.HotTrack;
			this.SuppliesInventoryGroup.Location = new System.Drawing.Point(649, 6);
			this.SuppliesInventoryGroup.Name = "SuppliesInventoryGroup";
			this.SuppliesInventoryGroup.Size = new System.Drawing.Size(315, 94);
			this.SuppliesInventoryGroup.TabIndex = 14;
			this.SuppliesInventoryGroup.TabStop = false;
			this.SuppliesInventoryGroup.Text = "Inventory";
			// 
			// SuppliesCostAnalysisButton
			// 
			this.SuppliesCostAnalysisButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.SuppliesCostAnalysisButton.ForeColor = System.Drawing.SystemColors.ControlText;
			this.SuppliesCostAnalysisButton.Location = new System.Drawing.Point(215, 36);
			this.SuppliesCostAnalysisButton.Margin = new System.Windows.Forms.Padding(2);
			this.SuppliesCostAnalysisButton.Name = "SuppliesCostAnalysisButton";
			this.SuppliesCostAnalysisButton.Size = new System.Drawing.Size(79, 23);
			this.SuppliesCostAnalysisButton.TabIndex = 22;
			this.SuppliesCostAnalysisButton.Text = "Cost Analysis";
			this.SuppliesCostAnalysisButton.UseVisualStyleBackColor = true;
			// 
			// ViewInventoryButton
			// 
			this.ViewInventoryButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ViewInventoryButton.ForeColor = System.Drawing.SystemColors.ControlText;
			this.ViewInventoryButton.Location = new System.Drawing.Point(119, 36);
			this.ViewInventoryButton.Margin = new System.Windows.Forms.Padding(2);
			this.ViewInventoryButton.Name = "ViewInventoryButton";
			this.ViewInventoryButton.Size = new System.Drawing.Size(79, 23);
			this.ViewInventoryButton.TabIndex = 21;
			this.ViewInventoryButton.Text = "View Activity";
			this.ViewInventoryButton.UseVisualStyleBackColor = true;
			// 
			// EditInventoryButton
			// 
			this.EditInventoryButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.EditInventoryButton.ForeColor = System.Drawing.SystemColors.ControlText;
			this.EditInventoryButton.Location = new System.Drawing.Point(23, 36);
			this.EditInventoryButton.Margin = new System.Windows.Forms.Padding(2);
			this.EditInventoryButton.Name = "EditInventoryButton";
			this.EditInventoryButton.Size = new System.Drawing.Size(79, 23);
			this.EditInventoryButton.TabIndex = 20;
			this.EditInventoryButton.Text = "Edit Activity";
			this.EditInventoryButton.UseVisualStyleBackColor = true;
			// 
			// HideUncheckedSuppliesCheckBox
			// 
			this.HideUncheckedSuppliesCheckBox.AutoCheck = false;
			this.HideUncheckedSuppliesCheckBox.AutoSize = true;
			this.HideUncheckedSuppliesCheckBox.Location = new System.Drawing.Point(17, 414);
			this.HideUncheckedSuppliesCheckBox.Name = "HideUncheckedSuppliesCheckBox";
			this.HideUncheckedSuppliesCheckBox.Size = new System.Drawing.Size(107, 17);
			this.HideUncheckedSuppliesCheckBox.TabIndex = 14;
			this.HideUncheckedSuppliesCheckBox.Text = "Hide Unchecked";
			this.HideUncheckedSuppliesCheckBox.UseVisualStyleBackColor = true;
			// 
			// SuppliesPrintOptionsGroupBox
			// 
			this.SuppliesPrintOptionsGroupBox.Controls.Add(this.SuppliesPrintBelowStockCheckBox);
			this.SuppliesPrintOptionsGroupBox.Controls.Add(this.NoSupplyListLabel);
			this.SuppliesPrintOptionsGroupBox.Controls.Add(this.SuppliesPrintNonZeroCheckBox);
			this.SuppliesPrintOptionsGroupBox.Controls.Add(this.SuppliesPrintCheckedRadioButton);
			this.SuppliesPrintOptionsGroupBox.Controls.Add(this.SuppliesPrintAllRadioButton);
			this.SuppliesPrintOptionsGroupBox.Controls.Add(this.SupplyListPrintButton);
			this.SuppliesPrintOptionsGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.SuppliesPrintOptionsGroupBox.ForeColor = System.Drawing.SystemColors.HotTrack;
			this.SuppliesPrintOptionsGroupBox.Location = new System.Drawing.Point(170, 6);
			this.SuppliesPrintOptionsGroupBox.Name = "SuppliesPrintOptionsGroupBox";
			this.SuppliesPrintOptionsGroupBox.Size = new System.Drawing.Size(473, 94);
			this.SuppliesPrintOptionsGroupBox.TabIndex = 13;
			this.SuppliesPrintOptionsGroupBox.TabStop = false;
			this.SuppliesPrintOptionsGroupBox.Text = "Print Options";
			// 
			// SuppliesPrintBelowStockCheckBox
			// 
			this.SuppliesPrintBelowStockCheckBox.AutoCheck = false;
			this.SuppliesPrintBelowStockCheckBox.AutoSize = true;
			this.SuppliesPrintBelowStockCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.SuppliesPrintBelowStockCheckBox.ForeColor = System.Drawing.SystemColors.ControlText;
			this.SuppliesPrintBelowStockCheckBox.Location = new System.Drawing.Point(156, 45);
			this.SuppliesPrintBelowStockCheckBox.Name = "SuppliesPrintBelowStockCheckBox";
			this.SuppliesPrintBelowStockCheckBox.Size = new System.Drawing.Size(183, 17);
			this.SuppliesPrintBelowStockCheckBox.TabIndex = 16;
			this.SuppliesPrintBelowStockCheckBox.Text = "Below Minimum Stock Level Only";
			this.SuppliesPrintBelowStockCheckBox.UseVisualStyleBackColor = true;
			// 
			// NoSupplyListLabel
			// 
			this.NoSupplyListLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.NoSupplyListLabel.ForeColor = System.Drawing.Color.Maroon;
			this.NoSupplyListLabel.Location = new System.Drawing.Point(18, 70);
			this.NoSupplyListLabel.Name = "NoSupplyListLabel";
			this.NoSupplyListLabel.Size = new System.Drawing.Size(321, 13);
			this.NoSupplyListLabel.TabIndex = 15;
			this.NoSupplyListLabel.Text = "No supplies meet the above criteria";
			this.NoSupplyListLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// SuppliesPrintNonZeroCheckBox
			// 
			this.SuppliesPrintNonZeroCheckBox.AutoCheck = false;
			this.SuppliesPrintNonZeroCheckBox.AutoSize = true;
			this.SuppliesPrintNonZeroCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.SuppliesPrintNonZeroCheckBox.ForeColor = System.Drawing.SystemColors.ControlText;
			this.SuppliesPrintNonZeroCheckBox.Location = new System.Drawing.Point(156, 22);
			this.SuppliesPrintNonZeroCheckBox.Name = "SuppliesPrintNonZeroCheckBox";
			this.SuppliesPrintNonZeroCheckBox.Size = new System.Drawing.Size(145, 17);
			this.SuppliesPrintNonZeroCheckBox.TabIndex = 3;
			this.SuppliesPrintNonZeroCheckBox.Text = "Non-Zero Quantities Only";
			this.SuppliesPrintNonZeroCheckBox.UseVisualStyleBackColor = true;
			// 
			// SuppliesPrintCheckedRadioButton
			// 
			this.SuppliesPrintCheckedRadioButton.AutoCheck = false;
			this.SuppliesPrintCheckedRadioButton.AutoSize = true;
			this.SuppliesPrintCheckedRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.SuppliesPrintCheckedRadioButton.ForeColor = System.Drawing.SystemColors.ControlText;
			this.SuppliesPrintCheckedRadioButton.Location = new System.Drawing.Point(18, 44);
			this.SuppliesPrintCheckedRadioButton.Name = "SuppliesPrintCheckedRadioButton";
			this.SuppliesPrintCheckedRadioButton.Size = new System.Drawing.Size(92, 17);
			this.SuppliesPrintCheckedRadioButton.TabIndex = 2;
			this.SuppliesPrintCheckedRadioButton.TabStop = true;
			this.SuppliesPrintCheckedRadioButton.Text = "Checked Only";
			this.SuppliesPrintCheckedRadioButton.UseVisualStyleBackColor = true;
			// 
			// SuppliesPrintAllRadioButton
			// 
			this.SuppliesPrintAllRadioButton.AutoCheck = false;
			this.SuppliesPrintAllRadioButton.AutoSize = true;
			this.SuppliesPrintAllRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.SuppliesPrintAllRadioButton.ForeColor = System.Drawing.SystemColors.ControlText;
			this.SuppliesPrintAllRadioButton.Location = new System.Drawing.Point(18, 21);
			this.SuppliesPrintAllRadioButton.Name = "SuppliesPrintAllRadioButton";
			this.SuppliesPrintAllRadioButton.Size = new System.Drawing.Size(79, 17);
			this.SuppliesPrintAllRadioButton.TabIndex = 1;
			this.SuppliesPrintAllRadioButton.TabStop = true;
			this.SuppliesPrintAllRadioButton.Text = "All Supplies";
			this.SuppliesPrintAllRadioButton.UseVisualStyleBackColor = true;
			// 
			// SupplyListPrintButton
			// 
			this.SupplyListPrintButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.SupplyListPrintButton.ForeColor = System.Drawing.SystemColors.ControlText;
			this.SupplyListPrintButton.Location = new System.Drawing.Point(385, 36);
			this.SupplyListPrintButton.Name = "SupplyListPrintButton";
			this.SupplyListPrintButton.Size = new System.Drawing.Size(75, 23);
			this.SupplyListPrintButton.TabIndex = 0;
			this.SupplyListPrintButton.Text = "Print";
			this.SupplyListPrintButton.UseVisualStyleBackColor = true;
			// 
			// DeselectAllSuppliesButton
			// 
			this.DeselectAllSuppliesButton.Location = new System.Drawing.Point(138, 447);
			this.DeselectAllSuppliesButton.Margin = new System.Windows.Forms.Padding(2);
			this.DeselectAllSuppliesButton.Name = "DeselectAllSuppliesButton";
			this.DeselectAllSuppliesButton.Size = new System.Drawing.Size(83, 19);
			this.DeselectAllSuppliesButton.TabIndex = 12;
			this.DeselectAllSuppliesButton.Text = "Uncheck All";
			this.DeselectAllSuppliesButton.UseVisualStyleBackColor = true;
			// 
			// SelectAllSuppliesButton
			// 
			this.SelectAllSuppliesButton.Location = new System.Drawing.Point(138, 424);
			this.SelectAllSuppliesButton.Margin = new System.Windows.Forms.Padding(2);
			this.SelectAllSuppliesButton.Name = "SelectAllSuppliesButton";
			this.SelectAllSuppliesButton.Size = new System.Drawing.Size(83, 19);
			this.SelectAllSuppliesButton.TabIndex = 11;
			this.SelectAllSuppliesButton.Text = "Check All";
			this.SelectAllSuppliesButton.UseVisualStyleBackColor = true;
			// 
			// SupplyCountLabel
			// 
			this.SupplyCountLabel.AutoSize = true;
			this.SupplyCountLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.SupplyCountLabel.Location = new System.Drawing.Point(5, 107);
			this.SupplyCountLabel.Name = "SupplyCountLabel";
			this.SupplyCountLabel.Size = new System.Drawing.Size(114, 13);
			this.SupplyCountLabel.TabIndex = 10;
			this.SupplyCountLabel.Text = "0 Handgun, 0 Rifle";
			this.SupplyCountLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// ViewSupplyButton
			// 
			this.ViewSupplyButton.Location = new System.Drawing.Point(463, 436);
			this.ViewSupplyButton.Margin = new System.Windows.Forms.Padding(2);
			this.ViewSupplyButton.Name = "ViewSupplyButton";
			this.ViewSupplyButton.Size = new System.Drawing.Size(56, 19);
			this.ViewSupplyButton.TabIndex = 3;
			this.ViewSupplyButton.Text = "View";
			this.ViewSupplyButton.UseVisualStyleBackColor = true;
			// 
			// SupplyTypeCombo
			// 
			this.SupplyTypeCombo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
			this.SupplyTypeCombo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.SupplyTypeCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.SupplyTypeCombo.FormattingEnabled = true;
			this.SupplyTypeCombo.Location = new System.Drawing.Point(51, 42);
			this.SupplyTypeCombo.Margin = new System.Windows.Forms.Padding(2);
			this.SupplyTypeCombo.Name = "SupplyTypeCombo";
			this.SupplyTypeCombo.Size = new System.Drawing.Size(92, 21);
			this.SupplyTypeCombo.TabIndex = 0;
			// 
			// RemoveSupplyButton
			// 
			this.RemoveSupplyButton.Location = new System.Drawing.Point(536, 436);
			this.RemoveSupplyButton.Margin = new System.Windows.Forms.Padding(2);
			this.RemoveSupplyButton.Name = "RemoveSupplyButton";
			this.RemoveSupplyButton.Size = new System.Drawing.Size(56, 19);
			this.RemoveSupplyButton.TabIndex = 4;
			this.RemoveSupplyButton.Text = "Remove";
			this.RemoveSupplyButton.UseVisualStyleBackColor = true;
			// 
			// EditSupplyButton
			// 
			this.EditSupplyButton.Location = new System.Drawing.Point(389, 436);
			this.EditSupplyButton.Margin = new System.Windows.Forms.Padding(2);
			this.EditSupplyButton.Name = "EditSupplyButton";
			this.EditSupplyButton.Size = new System.Drawing.Size(56, 19);
			this.EditSupplyButton.TabIndex = 2;
			this.EditSupplyButton.Text = "Edit";
			this.EditSupplyButton.UseVisualStyleBackColor = true;
			// 
			// AddSupplyButton
			// 
			this.AddSupplyButton.Location = new System.Drawing.Point(316, 436);
			this.AddSupplyButton.Margin = new System.Windows.Forms.Padding(2);
			this.AddSupplyButton.Name = "AddSupplyButton";
			this.AddSupplyButton.Size = new System.Drawing.Size(56, 19);
			this.AddSupplyButton.TabIndex = 1;
			this.AddSupplyButton.Text = "Add";
			this.AddSupplyButton.UseVisualStyleBackColor = true;
			// 
			// FirearmsTab
			// 
			this.FirearmsTab.Controls.Add(this.FirearmPrintOptionsGroupBox);
			this.FirearmsTab.Controls.Add(this.ViewFirearmButton);
			this.FirearmsTab.Controls.Add(this.RemoveFirearmButton);
			this.FirearmsTab.Controls.Add(this.EditFirearmButton);
			this.FirearmsTab.Controls.Add(this.AddFirearmButton);
			this.FirearmsTab.Location = new System.Drawing.Point(4, 22);
			this.FirearmsTab.Margin = new System.Windows.Forms.Padding(2);
			this.FirearmsTab.Name = "FirearmsTab";
			this.FirearmsTab.Padding = new System.Windows.Forms.Padding(2);
			this.FirearmsTab.Size = new System.Drawing.Size(1465, 1025);
			this.FirearmsTab.TabIndex = 6;
			this.FirearmsTab.Text = "Firearms";
			this.FirearmsTab.ToolTipText = "Manage firearms that you own and/or use for testing loads.";
			this.FirearmsTab.UseVisualStyleBackColor = true;
			// 
			// FirearmPrintOptionsGroupBox
			// 
			this.FirearmPrintOptionsGroupBox.Controls.Add(this.FirearmPrintSpecsCheckBox);
			this.FirearmPrintOptionsGroupBox.Controls.Add(this.FirearmPrintDetailCheckBox);
			this.FirearmPrintOptionsGroupBox.Controls.Add(this.FirearmPrintAllRadioButton);
			this.FirearmPrintOptionsGroupBox.Controls.Add(this.FirearmPrintCheckedRadioButton);
			this.FirearmPrintOptionsGroupBox.Controls.Add(this.FirearmPrintButton);
			this.FirearmPrintOptionsGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FirearmPrintOptionsGroupBox.ForeColor = System.Drawing.SystemColors.HotTrack;
			this.FirearmPrintOptionsGroupBox.Location = new System.Drawing.Point(8, 5);
			this.FirearmPrintOptionsGroupBox.Name = "FirearmPrintOptionsGroupBox";
			this.FirearmPrintOptionsGroupBox.Size = new System.Drawing.Size(383, 81);
			this.FirearmPrintOptionsGroupBox.TabIndex = 4;
			this.FirearmPrintOptionsGroupBox.TabStop = false;
			this.FirearmPrintOptionsGroupBox.Text = "Print Options";
			// 
			// FirearmPrintSpecsCheckBox
			// 
			this.FirearmPrintSpecsCheckBox.AutoCheck = false;
			this.FirearmPrintSpecsCheckBox.AutoSize = true;
			this.FirearmPrintSpecsCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FirearmPrintSpecsCheckBox.ForeColor = System.Drawing.SystemColors.ControlText;
			this.FirearmPrintSpecsCheckBox.Location = new System.Drawing.Point(138, 51);
			this.FirearmPrintSpecsCheckBox.Name = "FirearmPrintSpecsCheckBox";
			this.FirearmPrintSpecsCheckBox.Size = new System.Drawing.Size(80, 17);
			this.FirearmPrintSpecsCheckBox.TabIndex = 6;
			this.FirearmPrintSpecsCheckBox.Text = "Print Specs";
			this.FirearmPrintSpecsCheckBox.UseVisualStyleBackColor = true;
			// 
			// FirearmPrintDetailCheckBox
			// 
			this.FirearmPrintDetailCheckBox.AutoCheck = false;
			this.FirearmPrintDetailCheckBox.AutoSize = true;
			this.FirearmPrintDetailCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FirearmPrintDetailCheckBox.ForeColor = System.Drawing.SystemColors.ControlText;
			this.FirearmPrintDetailCheckBox.Location = new System.Drawing.Point(138, 28);
			this.FirearmPrintDetailCheckBox.Name = "FirearmPrintDetailCheckBox";
			this.FirearmPrintDetailCheckBox.Size = new System.Drawing.Size(137, 17);
			this.FirearmPrintDetailCheckBox.TabIndex = 5;
			this.FirearmPrintDetailCheckBox.Text = "Print Detail (1 per page)";
			this.FirearmPrintDetailCheckBox.UseVisualStyleBackColor = true;
			// 
			// FirearmPrintAllRadioButton
			// 
			this.FirearmPrintAllRadioButton.AutoCheck = false;
			this.FirearmPrintAllRadioButton.AutoSize = true;
			this.FirearmPrintAllRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FirearmPrintAllRadioButton.ForeColor = System.Drawing.SystemColors.ControlText;
			this.FirearmPrintAllRadioButton.Location = new System.Drawing.Point(23, 27);
			this.FirearmPrintAllRadioButton.Name = "FirearmPrintAllRadioButton";
			this.FirearmPrintAllRadioButton.Size = new System.Drawing.Size(60, 17);
			this.FirearmPrintAllRadioButton.TabIndex = 2;
			this.FirearmPrintAllRadioButton.TabStop = true;
			this.FirearmPrintAllRadioButton.Text = "Print All";
			this.FirearmPrintAllRadioButton.UseVisualStyleBackColor = true;
			// 
			// FirearmPrintCheckedRadioButton
			// 
			this.FirearmPrintCheckedRadioButton.AutoCheck = false;
			this.FirearmPrintCheckedRadioButton.AutoSize = true;
			this.FirearmPrintCheckedRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FirearmPrintCheckedRadioButton.ForeColor = System.Drawing.SystemColors.ControlText;
			this.FirearmPrintCheckedRadioButton.Location = new System.Drawing.Point(23, 50);
			this.FirearmPrintCheckedRadioButton.Name = "FirearmPrintCheckedRadioButton";
			this.FirearmPrintCheckedRadioButton.Size = new System.Drawing.Size(92, 17);
			this.FirearmPrintCheckedRadioButton.TabIndex = 1;
			this.FirearmPrintCheckedRadioButton.TabStop = true;
			this.FirearmPrintCheckedRadioButton.Text = "Print Checked";
			this.FirearmPrintCheckedRadioButton.UseVisualStyleBackColor = true;
			// 
			// FirearmPrintButton
			// 
			this.FirearmPrintButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FirearmPrintButton.ForeColor = System.Drawing.SystemColors.ControlText;
			this.FirearmPrintButton.Location = new System.Drawing.Point(291, 35);
			this.FirearmPrintButton.Name = "FirearmPrintButton";
			this.FirearmPrintButton.Size = new System.Drawing.Size(75, 23);
			this.FirearmPrintButton.TabIndex = 0;
			this.FirearmPrintButton.Text = "Print";
			this.FirearmPrintButton.UseVisualStyleBackColor = true;
			// 
			// ViewFirearmButton
			// 
			this.ViewFirearmButton.Location = new System.Drawing.Point(470, 434);
			this.ViewFirearmButton.Margin = new System.Windows.Forms.Padding(2);
			this.ViewFirearmButton.Name = "ViewFirearmButton";
			this.ViewFirearmButton.Size = new System.Drawing.Size(56, 19);
			this.ViewFirearmButton.TabIndex = 2;
			this.ViewFirearmButton.Text = "View";
			this.ViewFirearmButton.UseVisualStyleBackColor = true;
			// 
			// RemoveFirearmButton
			// 
			this.RemoveFirearmButton.Location = new System.Drawing.Point(556, 434);
			this.RemoveFirearmButton.Margin = new System.Windows.Forms.Padding(2);
			this.RemoveFirearmButton.Name = "RemoveFirearmButton";
			this.RemoveFirearmButton.Size = new System.Drawing.Size(56, 19);
			this.RemoveFirearmButton.TabIndex = 3;
			this.RemoveFirearmButton.Text = "Remove";
			this.RemoveFirearmButton.UseVisualStyleBackColor = true;
			// 
			// EditFirearmButton
			// 
			this.EditFirearmButton.Location = new System.Drawing.Point(392, 434);
			this.EditFirearmButton.Margin = new System.Windows.Forms.Padding(2);
			this.EditFirearmButton.Name = "EditFirearmButton";
			this.EditFirearmButton.Size = new System.Drawing.Size(56, 19);
			this.EditFirearmButton.TabIndex = 1;
			this.EditFirearmButton.Text = "Edit";
			this.EditFirearmButton.UseVisualStyleBackColor = true;
			// 
			// AddFirearmButton
			// 
			this.AddFirearmButton.Location = new System.Drawing.Point(318, 434);
			this.AddFirearmButton.Margin = new System.Windows.Forms.Padding(2);
			this.AddFirearmButton.Name = "AddFirearmButton";
			this.AddFirearmButton.Size = new System.Drawing.Size(56, 19);
			this.AddFirearmButton.TabIndex = 0;
			this.AddFirearmButton.Text = "Add";
			this.AddFirearmButton.UseVisualStyleBackColor = true;
			// 
			// CalibersTab
			// 
			this.CalibersTab.Controls.Add(this.HideUncheckedCalibersCheckBox);
			this.CalibersTab.Controls.Add(this.CaliberCountLabel);
			this.CalibersTab.Controls.Add(this.ViewCaliberButton);
			this.CalibersTab.Controls.Add(this.RemoveCaliberButton);
			this.CalibersTab.Controls.Add(this.EditCaliberButton);
			this.CalibersTab.Controls.Add(this.AddCaliberButton);
			this.CalibersTab.Location = new System.Drawing.Point(4, 22);
			this.CalibersTab.Margin = new System.Windows.Forms.Padding(2);
			this.CalibersTab.Name = "CalibersTab";
			this.CalibersTab.Size = new System.Drawing.Size(1465, 1025);
			this.CalibersTab.TabIndex = 4;
			this.CalibersTab.Text = "Calibers";
			this.CalibersTab.ToolTipText = "Manage list of calibers that you reload";
			this.CalibersTab.UseVisualStyleBackColor = true;
			// 
			// HideUncheckedCalibersCheckBox
			// 
			this.HideUncheckedCalibersCheckBox.AutoCheck = false;
			this.HideUncheckedCalibersCheckBox.AutoSize = true;
			this.HideUncheckedCalibersCheckBox.Location = new System.Drawing.Point(42, 363);
			this.HideUncheckedCalibersCheckBox.Name = "HideUncheckedCalibersCheckBox";
			this.HideUncheckedCalibersCheckBox.Size = new System.Drawing.Size(107, 17);
			this.HideUncheckedCalibersCheckBox.TabIndex = 6;
			this.HideUncheckedCalibersCheckBox.Text = "Hide Unchecked";
			this.HideUncheckedCalibersCheckBox.UseVisualStyleBackColor = true;
			// 
			// CaliberCountLabel
			// 
			this.CaliberCountLabel.AutoSize = true;
			this.CaliberCountLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.CaliberCountLabel.Location = new System.Drawing.Point(155, 22);
			this.CaliberCountLabel.Name = "CaliberCountLabel";
			this.CaliberCountLabel.Size = new System.Drawing.Size(118, 13);
			this.CaliberCountLabel.TabIndex = 5;
			this.CaliberCountLabel.Text = "Caliber Count Label";
			// 
			// ViewCaliberButton
			// 
			this.ViewCaliberButton.Location = new System.Drawing.Point(392, 361);
			this.ViewCaliberButton.Margin = new System.Windows.Forms.Padding(2);
			this.ViewCaliberButton.Name = "ViewCaliberButton";
			this.ViewCaliberButton.Size = new System.Drawing.Size(56, 19);
			this.ViewCaliberButton.TabIndex = 2;
			this.ViewCaliberButton.Text = "View";
			this.ViewCaliberButton.UseVisualStyleBackColor = true;
			// 
			// RemoveCaliberButton
			// 
			this.RemoveCaliberButton.Location = new System.Drawing.Point(467, 361);
			this.RemoveCaliberButton.Margin = new System.Windows.Forms.Padding(2);
			this.RemoveCaliberButton.Name = "RemoveCaliberButton";
			this.RemoveCaliberButton.Size = new System.Drawing.Size(56, 19);
			this.RemoveCaliberButton.TabIndex = 3;
			this.RemoveCaliberButton.Text = "Remove";
			this.RemoveCaliberButton.UseVisualStyleBackColor = true;
			// 
			// EditCaliberButton
			// 
			this.EditCaliberButton.Location = new System.Drawing.Point(306, 361);
			this.EditCaliberButton.Margin = new System.Windows.Forms.Padding(2);
			this.EditCaliberButton.Name = "EditCaliberButton";
			this.EditCaliberButton.Size = new System.Drawing.Size(56, 19);
			this.EditCaliberButton.TabIndex = 1;
			this.EditCaliberButton.Text = "Edit";
			this.EditCaliberButton.UseVisualStyleBackColor = true;
			// 
			// AddCaliberButton
			// 
			this.AddCaliberButton.Location = new System.Drawing.Point(212, 361);
			this.AddCaliberButton.Margin = new System.Windows.Forms.Padding(2);
			this.AddCaliberButton.Name = "AddCaliberButton";
			this.AddCaliberButton.Size = new System.Drawing.Size(56, 19);
			this.AddCaliberButton.TabIndex = 0;
			this.AddCaliberButton.Text = "Add";
			this.AddCaliberButton.UseVisualStyleBackColor = true;
			// 
			// ManufacturersTab
			// 
			this.ManufacturersTab.Controls.Add(this.ViewManufacturerButton);
			this.ManufacturersTab.Controls.Add(this.RemoveManufacturerButton);
			this.ManufacturersTab.Controls.Add(this.EditManufacturerButton);
			this.ManufacturersTab.Controls.Add(this.AddManufacturerButton);
			this.ManufacturersTab.Location = new System.Drawing.Point(4, 22);
			this.ManufacturersTab.Margin = new System.Windows.Forms.Padding(2);
			this.ManufacturersTab.Name = "ManufacturersTab";
			this.ManufacturersTab.Padding = new System.Windows.Forms.Padding(2);
			this.ManufacturersTab.Size = new System.Drawing.Size(1465, 1025);
			this.ManufacturersTab.TabIndex = 3;
			this.ManufacturersTab.Text = "Manufacturers";
			this.ManufacturersTab.ToolTipText = "Manage list of manufacturers that supply firearms and reloading materials";
			this.ManufacturersTab.UseVisualStyleBackColor = true;
			// 
			// ViewManufacturerButton
			// 
			this.ViewManufacturerButton.Location = new System.Drawing.Point(343, 361);
			this.ViewManufacturerButton.Margin = new System.Windows.Forms.Padding(2);
			this.ViewManufacturerButton.Name = "ViewManufacturerButton";
			this.ViewManufacturerButton.Size = new System.Drawing.Size(56, 19);
			this.ViewManufacturerButton.TabIndex = 2;
			this.ViewManufacturerButton.Text = "View";
			this.ViewManufacturerButton.UseVisualStyleBackColor = true;
			// 
			// RemoveManufacturerButton
			// 
			this.RemoveManufacturerButton.Location = new System.Drawing.Point(416, 361);
			this.RemoveManufacturerButton.Margin = new System.Windows.Forms.Padding(2);
			this.RemoveManufacturerButton.Name = "RemoveManufacturerButton";
			this.RemoveManufacturerButton.Size = new System.Drawing.Size(56, 19);
			this.RemoveManufacturerButton.TabIndex = 3;
			this.RemoveManufacturerButton.Text = "Remove";
			this.RemoveManufacturerButton.UseVisualStyleBackColor = true;
			// 
			// EditManufacturerButton
			// 
			this.EditManufacturerButton.Location = new System.Drawing.Point(269, 361);
			this.EditManufacturerButton.Margin = new System.Windows.Forms.Padding(2);
			this.EditManufacturerButton.Name = "EditManufacturerButton";
			this.EditManufacturerButton.Size = new System.Drawing.Size(56, 19);
			this.EditManufacturerButton.TabIndex = 1;
			this.EditManufacturerButton.Text = "Edit";
			this.EditManufacturerButton.UseVisualStyleBackColor = true;
			// 
			// AddManufacturerButton
			// 
			this.AddManufacturerButton.Location = new System.Drawing.Point(200, 361);
			this.AddManufacturerButton.Margin = new System.Windows.Forms.Padding(2);
			this.AddManufacturerButton.Name = "AddManufacturerButton";
			this.AddManufacturerButton.Size = new System.Drawing.Size(56, 19);
			this.AddManufacturerButton.TabIndex = 0;
			this.AddManufacturerButton.Text = "Add";
			this.AddManufacturerButton.UseVisualStyleBackColor = true;
			// 
			// MainTabControl
			// 
			this.MainTabControl.Controls.Add(this.ManufacturersTab);
			this.MainTabControl.Controls.Add(this.CalibersTab);
			this.MainTabControl.Controls.Add(this.FirearmsTab);
			this.MainTabControl.Controls.Add(this.SuppliesTab);
			this.MainTabControl.Controls.Add(this.LoadDataTab);
			this.MainTabControl.Controls.Add(this.BatchEditorTab);
			this.MainTabControl.Controls.Add(this.AmmoTab);
			this.MainTabControl.Controls.Add(this.BallisticsTab);
			this.MainTabControl.Location = new System.Drawing.Point(0, 26);
			this.MainTabControl.Margin = new System.Windows.Forms.Padding(2);
			this.MainTabControl.Name = "MainTabControl";
			this.MainTabControl.SelectedIndex = 0;
			this.MainTabControl.Size = new System.Drawing.Size(1473, 1051);
			this.MainTabControl.TabIndex = 0;
			// 
			// ToolsTargetCalculatorMenuItem
			// 
			this.ToolsTargetCalculatorMenuItem.Name = "ToolsTargetCalculatorMenuItem";
			this.ToolsTargetCalculatorMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F11;
			this.ToolsTargetCalculatorMenuItem.Size = new System.Drawing.Size(216, 22);
			this.ToolsTargetCalculatorMenuItem.Text = "&Target Calculator";
			// 
			// cMainForm
			// 
			this.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1484, 1045);
			this.Controls.Add(this.MainTabControl);
			this.Controls.Add(this.MainMenu);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.MainMenu;
			this.Margin = new System.Windows.Forms.Padding(2);
			this.MinimumSize = new System.Drawing.Size(750, 400);
			this.Name = "cMainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Reloader\'s WorkShop";
			this.MainMenu.ResumeLayout(false);
			this.MainMenu.PerformLayout();
			this.BallisticsTab.ResumeLayout(false);
			this.WindDriftChartGroup.ResumeLayout(false);
			this.WindDriftChartGroup.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.WindageTurretUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.WindDriftChart)).EndInit();
			this.BulletDropChartGroup.ResumeLayout(false);
			this.BulletDropChartGroup.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.ElevationTurretUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.BulletDropChart)).EndInit();
			this.DropTableGroup.ResumeLayout(false);
			this.DropTableGroup.PerformLayout();
			this.BallisticsDatabaseGroupBox.ResumeLayout(false);
			this.BallisticsDatabaseGroupBox.PerformLayout();
			this.BallisticsInputDataGroupBox.ResumeLayout(false);
			this.BallisticsInputDataGroupBox.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.AmmoTab.ResumeLayout(false);
			this.AmmoInventoryGroup.ResumeLayout(false);
			this.AmmoPrintOptionsGroupBox.ResumeLayout(false);
			this.AmmoPrintOptionsGroupBox.PerformLayout();
			this.BatchEditorTab.ResumeLayout(false);
			this.BatchEditorTab.PerformLayout();
			this.BatchEditorActionsGroupBox.ResumeLayout(false);
			this.BatchEditorActionsGroupBox.PerformLayout();
			this.BatchFiltersGroupBox.ResumeLayout(false);
			this.BatchFiltersGroupBox.PerformLayout();
			this.LoadDataTab.ResumeLayout(false);
			this.LoadDataFiltersGroupBox.ResumeLayout(false);
			this.LoadDataFiltersGroupBox.PerformLayout();
			this.groupBox5.ResumeLayout(false);
			this.SuppliesTab.ResumeLayout(false);
			this.SuppliesTab.PerformLayout();
			this.SuppliesInventoryGroup.ResumeLayout(false);
			this.SuppliesPrintOptionsGroupBox.ResumeLayout(false);
			this.SuppliesPrintOptionsGroupBox.PerformLayout();
			this.FirearmsTab.ResumeLayout(false);
			this.FirearmPrintOptionsGroupBox.ResumeLayout(false);
			this.FirearmPrintOptionsGroupBox.PerformLayout();
			this.CalibersTab.ResumeLayout(false);
			this.CalibersTab.PerformLayout();
			this.ManufacturersTab.ResumeLayout(false);
			this.MainTabControl.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

			}

		#endregion

		private System.Windows.Forms.MenuStrip MainMenu;
		private System.Windows.Forms.ToolStripMenuItem FileMenuItem;
		private System.Windows.Forms.ToolStripMenuItem FileSaveMenuItem;
		private System.Windows.Forms.ToolStripMenuItem FileBackupMenuItem;
		private System.Windows.Forms.ToolStripMenuItem FileRestoreBackupMenuItem;
		private System.Windows.Forms.ToolStripMenuItem EditMenuItem;
		private System.Windows.Forms.ToolStripMenuItem EditRemoveMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripMenuItem FilePrintMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripMenuItem FileExitMenuItem;
		private System.Windows.Forms.ToolStripMenuItem EditNewMenuItem;
		private System.Windows.Forms.ToolStripMenuItem ViewMenuItem;
		private System.Windows.Forms.ToolStripMenuItem ViewViewMenuItem;
		private System.Windows.Forms.ToolStripMenuItem ViewCheckedMenuItem;
		private System.Windows.Forms.ToolStripMenuItem HelpMenuItem;
		private System.Windows.Forms.ToolStripMenuItem HelpSupportForumMenuItem;
		private System.Windows.Forms.ToolStripMenuItem HelpAboutMenuItem;
		private System.Windows.Forms.ToolStripMenuItem ViewManufacturersMenuItem;
		private System.Windows.Forms.ToolStripMenuItem ViewCalibersMenuItem;
		private System.Windows.Forms.ToolStripMenuItem ViewFirearmsMenuItem;
		private System.Windows.Forms.ToolStripMenuItem ViewSuppliesMenuItem;
		private System.Windows.Forms.ToolStripMenuItem ViewBulletsMenuItem;
		private System.Windows.Forms.ToolStripMenuItem ViewCasesMenuItem;
		private System.Windows.Forms.ToolStripMenuItem ViewPowdersMenuItem;
		private System.Windows.Forms.ToolStripMenuItem ViewPrimersMenuItem;
		private System.Windows.Forms.ToolStripMenuItem ViewLoadDataMenuItem;
		private System.Windows.Forms.ToolStripMenuItem ViewBatchEditorMenuItem;
		private System.Windows.Forms.ToolStripMenuItem ViewBallisticsMenuItem;
		private System.Windows.Forms.ToolStripMenuItem ViewAmmoMenuItem;
		private System.Windows.Forms.ToolStripMenuItem FilePrintFirearmsListMenuItem;
		private System.Windows.Forms.ToolStripMenuItem FilePrintLoadShoppingListMenuItem;
		private System.Windows.Forms.ToolStripMenuItem EditEditMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
		private System.Windows.Forms.ToolStripMenuItem HelpProgramUpdateMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
		private System.Windows.Forms.ToolStripMenuItem FilePreferencesMenuItem;
		private System.Windows.Forms.ToolStripMenuItem ToolsMenuItem;
		private System.Windows.Forms.ToolStripMenuItem ToolsConversionCalculatorMenuItem;
		private System.Windows.Forms.ToolStripMenuItem FilePrintSupplyListMenuItem;
		private System.Windows.Forms.ToolStripMenuItem FilePrintAmmoListMenuItem;
		private System.Windows.Forms.ToolStripMenuItem HelpNotesMenuItem;
		private System.Windows.Forms.ToolStripMenuItem SAAMIDocumentsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem ToolsSAAMIRifleMenuItem;
		private System.Windows.Forms.ToolStripMenuItem ToolsSAAMIPistolMenuItem;
		private System.Windows.Forms.ToolStripMenuItem ToolsSAAMIRimfireMenuItem;
		private System.Windows.Forms.ToolStripMenuItem ToolsSAAMIShotshellMenuItem;
		private System.Windows.Forms.ToolStripMenuItem ToolsSAAMIPistolSpecsMenuItem;
		private System.Windows.Forms.ToolStripMenuItem ToolsSAAMIPistolVelocityDataMenuItem;
		private System.Windows.Forms.ToolStripMenuItem ToolsSAAMIRifleSpecsMenuItem;
		private System.Windows.Forms.ToolStripMenuItem ToolsSAAMIRifleVelocityDataMenuItem;
		private System.Windows.Forms.ToolStripMenuItem ToolsSAAMIRimfireSpecsMenuItem;
		private System.Windows.Forms.ToolStripMenuItem ToolsSAAMIShotshellSpecsMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
		private System.Windows.Forms.ToolStripMenuItem FileResetDataMenuItem;
		private System.Windows.Forms.ToolStripMenuItem ToolsSAAMIBrochuresMenuItem;
		private System.Windows.Forms.ToolStripMenuItem ToolsSAAMISafeAmmoStorageMenuItem;
		private System.Windows.Forms.ToolStripMenuItem ToolsSAAMISmokelessPowderMenuItem;
		private System.Windows.Forms.ToolStripMenuItem ToolsSAAMIUnsafeArmsAmmoMenuItem;
		private System.Windows.Forms.ToolStripMenuItem ToolsSAAMIPrimersMenuItem;
		private System.Windows.Forms.ToolStripMenuItem ToolsSAAMIFactsMenuItem;
		private System.Windows.Forms.ToolStripMenuItem ToolsSAAMIAmmoFiresMenuItem;
		private System.Windows.Forms.ToolStripMenuItem ToolsSAAMISportingFirearmsMenuItem;
		private System.Windows.Forms.TabPage BallisticsTab;
		private System.Windows.Forms.GroupBox BallisticsInputDataGroupBox;
		private System.Windows.Forms.ComboBox BallisticsTurretTypeComboBox;
		private CommonLib.Controls.cIntegerValueTextBox BallisticsWindDirectionTextBox;
		private CommonLib.Controls.cIntegerValueTextBox BallisticsWindSpeedTextBox;
		private CommonLib.Controls.cDoubleValueTextBox BallisticsSightHeightTextBox;
		private CommonLib.Controls.cDoubleValueTextBox BallisticsScopeClickTextBox;
		private CommonLib.Controls.cIntegerValueTextBox BallisticsMuzzleVelocityTextBox;
		private CommonLib.Controls.cDoubleValueTextBox BallisticsBCTextBox;
		private CommonLib.Controls.cIntegerValueTextBox BallisticsMaxRangeTextBox;
		private CommonLib.Controls.cIntegerValueTextBox BallisticsMinRangeTextBox;
		private CommonLib.Controls.cIntegerValueTextBox BallisticsZeroRangeTextBox;
		private CommonLib.Controls.cIntegerValueTextBox BallisticsIncrementTextBox;
		private CommonLib.Controls.cDoubleValueTextBox BallisticsBulletDiameterTextBox;
		private CommonLib.Controls.cDoubleValueTextBox BallisticsBulletWeightTextBox;
		private System.Windows.Forms.Label HeadWindLabel;
		private System.Windows.Forms.Label CrossWindLabel;
		private System.Windows.Forms.Label IncrementMeasurementLabel;
		private System.Windows.Forms.Label label38;
		private System.Windows.Forms.Label MaxRangeMeasurementLabel;
		private System.Windows.Forms.Label label36;
		private System.Windows.Forms.Label MinRangeMeasurementLabel;
		private System.Windows.Forms.Label label34;
		private System.Windows.Forms.Label label31;
		private System.Windows.Forms.Label label32;
		private System.Windows.Forms.Label WindSpeedMeasurementLabel;
		private System.Windows.Forms.Label label30;
		private System.Windows.Forms.Label label28;
		private System.Windows.Forms.Label SightHeightMeasurementLabel;
		private System.Windows.Forms.Label label26;
		private System.Windows.Forms.Label ZeroRangeMeasurementLabel;
		private System.Windows.Forms.Label label24;
		private System.Windows.Forms.Label MuzzleVelocityMeasurementLabel;
		private System.Windows.Forms.Label BulletWeightMeasurementLabel;
		private System.Windows.Forms.Label BulletDiameterMeasurementLabel;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.GroupBox BallisticsDatabaseGroupBox;
		private Controls.cFirearmTypeCombo BallisticsFirearmTypeCombo;
		private System.Windows.Forms.Button BallisticsResetButton;
		private System.Windows.Forms.RadioButton BallisticsLoadDataVelocityRadioButton;
		private System.Windows.Forms.RadioButton BallisticsBatchTestVelocityRadioButton;
		private System.Windows.Forms.ComboBox BallisticsBulletCombo;
		private System.Windows.Forms.Label BatchBulletLabel;
		private System.Windows.Forms.ComboBox BallisticsCaliberCombo;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.ComboBox BallisticsChargeCombo;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.ComboBox BallisticsFirearmCombo;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.ComboBox BallisticsLoadCombo;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.ComboBox BallisticsBatchCombo;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TabPage AmmoTab;
		private System.Windows.Forms.GroupBox AmmoPrintOptionsGroupBox;
		private System.Windows.Forms.CheckBox AmmoPrintFactoryOnlyCheckBox;
		private System.Windows.Forms.CheckBox AmmoPrintNonZeroCheckBox;
		private System.Windows.Forms.RadioButton AmmoPrintCheckedRadioButton;
		private System.Windows.Forms.RadioButton AmmoPrintAllRadioButton;
		private System.Windows.Forms.Button AmmoListPrintButton;
		private System.Windows.Forms.Button ViewAmmoButton;
		private System.Windows.Forms.Button RemoveAmmoButton;
		private System.Windows.Forms.Button EditAmmoButton;
		private System.Windows.Forms.Button AddAmmoButton;
		private System.Windows.Forms.TabPage BatchEditorTab;
		private System.Windows.Forms.Label BatchNotTrackedLabel;
		private System.Windows.Forms.Label NoInventoryWarningLabel;
		private System.Windows.Forms.GroupBox BatchEditorActionsGroupBox;
		private System.Windows.Forms.Button PrintCheckedBatchLabelsButton;
		private System.Windows.Forms.CheckBox ShowArchivedBatchesCheckBox;
		private System.Windows.Forms.Button UnarchiveCheckedButton;
		private System.Windows.Forms.Button ArchiveCheckedButton;
		private System.Windows.Forms.Button ViewBatchButton;
		private System.Windows.Forms.Button RemoveBatchButton;
		private System.Windows.Forms.Button EditBatchButton;
		private System.Windows.Forms.Button AddBatchButton;
		private System.Windows.Forms.GroupBox BatchFiltersGroupBox;
		private Controls.cFirearmTypeCombo BatchFirearmTypeCombo;
		private System.Windows.Forms.ComboBox BatchPowderCombo;
		private System.Windows.Forms.ComboBox BatchBulletCombo;
		private System.Windows.Forms.ComboBox BatchCaliberCombo;
		private System.Windows.Forms.TabPage LoadDataTab;
		private System.Windows.Forms.Label LoadDataListViewInfoLabel;
		private System.Windows.Forms.Button LoadDataDeselectAllButton;
		private System.Windows.Forms.Button LoadDataSelectAllButton;
		private System.Windows.Forms.GroupBox groupBox5;
		private System.Windows.Forms.Button ImportShareFileButton;
		private System.Windows.Forms.Button ShareFileButton;
		private System.Windows.Forms.Button LoadShoppingListButton;
		private System.Windows.Forms.Button EvaluateLoadButton;
		private System.Windows.Forms.Button ViewLoadButton;
		private System.Windows.Forms.Button RemoveLoadButton;
		private System.Windows.Forms.Button EditLoadButton;
		private System.Windows.Forms.Button AddLoadButton;
		private System.Windows.Forms.GroupBox LoadDataFiltersGroupBox;
		private Controls.cFirearmTypeCombo LoadDataFirearmTypeCombo;
		private System.Windows.Forms.ComboBox LoadDataPowderCombo;
		private System.Windows.Forms.ComboBox LoadDataBulletCombo;
		private System.Windows.Forms.ComboBox LoadDataCaliberCombo;
		private System.Windows.Forms.TabPage SuppliesTab;
		private System.Windows.Forms.CheckBox HideUncheckedSuppliesCheckBox;
		private System.Windows.Forms.GroupBox SuppliesPrintOptionsGroupBox;
		private System.Windows.Forms.CheckBox SuppliesPrintNonZeroCheckBox;
		private System.Windows.Forms.RadioButton SuppliesPrintCheckedRadioButton;
		private System.Windows.Forms.RadioButton SuppliesPrintAllRadioButton;
		private System.Windows.Forms.Button SupplyListPrintButton;
		private System.Windows.Forms.Button DeselectAllSuppliesButton;
		private System.Windows.Forms.Button SelectAllSuppliesButton;
		private System.Windows.Forms.Label SupplyCountLabel;
		private System.Windows.Forms.Button ViewSupplyButton;
		private System.Windows.Forms.ComboBox SupplyTypeCombo;
		private System.Windows.Forms.Button RemoveSupplyButton;
		private System.Windows.Forms.Button EditSupplyButton;
		private System.Windows.Forms.Button AddSupplyButton;
		private System.Windows.Forms.TabPage FirearmsTab;
		private System.Windows.Forms.GroupBox FirearmPrintOptionsGroupBox;
		private System.Windows.Forms.CheckBox FirearmPrintSpecsCheckBox;
		private System.Windows.Forms.CheckBox FirearmPrintDetailCheckBox;
		private System.Windows.Forms.RadioButton FirearmPrintAllRadioButton;
		private System.Windows.Forms.RadioButton FirearmPrintCheckedRadioButton;
		private System.Windows.Forms.Button FirearmPrintButton;
		private System.Windows.Forms.Button ViewFirearmButton;
		private System.Windows.Forms.Button RemoveFirearmButton;
		private System.Windows.Forms.Button EditFirearmButton;
		private System.Windows.Forms.Button AddFirearmButton;
		private System.Windows.Forms.TabPage CalibersTab;
		private System.Windows.Forms.CheckBox HideUncheckedCalibersCheckBox;
		private System.Windows.Forms.Label CaliberCountLabel;
		private System.Windows.Forms.Button ViewCaliberButton;
		private System.Windows.Forms.Button RemoveCaliberButton;
		private System.Windows.Forms.Button EditCaliberButton;
		private System.Windows.Forms.Button AddCaliberButton;
		private System.Windows.Forms.TabPage ManufacturersTab;
		private System.Windows.Forms.Button ViewManufacturerButton;
		private System.Windows.Forms.Button RemoveManufacturerButton;
		private System.Windows.Forms.Button EditManufacturerButton;
		private System.Windows.Forms.Button AddManufacturerButton;
		private System.Windows.Forms.TabControl MainTabControl;
		private System.Windows.Forms.GroupBox SuppliesInventoryGroup;
		private System.Windows.Forms.ToolStripMenuItem EditInventoryActivityMenuItem;
		private System.Windows.Forms.Button EditInventoryButton;
		private System.Windows.Forms.ToolStripMenuItem ViewInventoryActivityMenuItem;
		private System.Windows.Forms.Button ViewInventoryButton;
		private System.Windows.Forms.GroupBox AmmoInventoryGroup;
		private System.Windows.Forms.Button ViewAmmoInventoryButton;
		private System.Windows.Forms.Button EditAmmoInventoryButton;
		private System.Windows.Forms.Button AmmoCostAnalysisButton;
		private System.Windows.Forms.Button SuppliesCostAnalysisButton;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem FilePrintCostAnalysisMenuItem;
		private System.Windows.Forms.Label NoSupplyListLabel;
		private System.Windows.Forms.Label NoAmmoListLabel;
		private System.Windows.Forms.ToolStripMenuItem HelpVideoMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
		private System.Windows.Forms.ToolStripMenuItem ToolsStabilityCalculatorMenuItem;
		private System.Windows.Forms.ToolStripMenuItem HelpDataUpdateMenuItem;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ToolStripMenuItem HelpVideoCrimpingMenuItem;
		private System.Windows.Forms.ToolStripMenuItem HelpVideoHeadspaceMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
		private System.Windows.Forms.ToolStripMenuItem HelpVideoRWMenuItem;
		private System.Windows.Forms.ToolStripMenuItem HelpVideoRWInventoryMenuItem;
		private System.Windows.Forms.ToolStripMenuItem HelpVideoRWOperationMenuItem;
		private System.Windows.Forms.ToolStripMenuItem HelpVideoBulletSelectionMenuItem;
		private System.Windows.Forms.ToolStripMenuItem HelpVideoSDBCMenuItem;
		private System.Windows.Forms.ToolStripMenuItem HelpVideoRWLoadDataMenuItem;
		private System.Windows.Forms.ToolStripMenuItem HelpVideoRWBatchEditorMenuItem;
		private System.Windows.Forms.GroupBox DropTableGroup;
		private System.Windows.Forms.ListView BallisticsListView;
		private System.Windows.Forms.ColumnHeader RangeHeader;
		private System.Windows.Forms.ColumnHeader DropHeader;
		private System.Windows.Forms.ColumnHeader DropMOAHeader;
		private System.Windows.Forms.ColumnHeader WindDriftHeader;
		private System.Windows.Forms.ColumnHeader WindDriftMOAHeader;
		private System.Windows.Forms.ColumnHeader VelocityHeader;
		private System.Windows.Forms.ColumnHeader TimeOfFlightHeader;
		private System.Windows.Forms.ColumnHeader ScopeClickHeader;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.GroupBox BulletDropChartGroup;
		private System.Windows.Forms.PictureBox BulletDropChart;
		private System.Windows.Forms.CheckBox CompareToReferenceBulletCheckBox;
		private System.Windows.Forms.Button SaveReferenceBulletButton;
		private System.Windows.Forms.Button RestoreReferenceBulletButton;
		private System.Windows.Forms.GroupBox WindDriftChartGroup;
		private System.Windows.Forms.PictureBox WindDriftChart;
		private System.Windows.Forms.CheckBox ShowWindDriftRangeMarkersCheckBox;
		private System.Windows.Forms.CheckBox ShowDropChartRangeMarkersCheckBox;
		private System.Windows.Forms.Label ReferenceDataLegendLabel;
		private System.Windows.Forms.Label CurrentDataLegendLabel;
		private System.Windows.Forms.CheckBox ShowGroundStrikeMarkerCheckBox;
		private System.Windows.Forms.Label ReferenceDataDriftLegendLabel;
		private System.Windows.Forms.Label CurrentDataDriftLegendLabel;
		private CommonLib.Controls.cIntegerValueTextBox BallisticsTargetRangeTextBox;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.CheckBox ShowApexMarkerCheckBox;
		private System.Windows.Forms.Label TargetRangeMeasurementLabel;
		private System.Windows.Forms.Label BallisticsMuzzleHeightLabel;
		private System.Windows.Forms.GroupBox groupBox1;
		private CommonLib.Controls.cDoubleValueTextBox BallisticsPressureTextBox;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.Label BallisticsPressureMeasurementLabel;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label AltitudeMeasurementLabel;
		private CommonLib.Controls.cIntegerValueTextBox BallisticsAltitudeTextBox;
		private System.Windows.Forms.Label label7;
		private CommonLib.Controls.cIntegerValueTextBox BallisticsTemperatureTextBox;
		private System.Windows.Forms.CheckBox ShowTransonicMarkersCheckBox;
		private System.Windows.Forms.Label TurretTypeLabel;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.NumericUpDown ElevationTurretUpDown;
		private System.Windows.Forms.Button ResetElevationTurretButton;
		private System.Windows.Forms.Button ResetWindageTurretButton;
		private System.Windows.Forms.Label DriftTurretTypeLabel;
		private System.Windows.Forms.Label label23;
		private System.Windows.Forms.NumericUpDown WindageTurretUpDown;
		private System.Windows.Forms.CheckBox ShowReferenceDataCheckBox;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label5;
		private CommonLib.Controls.cIntegerValueTextBox BallisticsHumidityTextBox;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.Label label25;
		private CommonLib.Controls.cDoubleValueTextBox BallisticsBulletLengthTextBox;
		private System.Windows.Forms.Label BulletLengthMeasurementLabel;
		private System.Windows.Forms.Label label29;
		private System.Windows.Forms.ColumnHeader SFHeader;
		private System.Windows.Forms.ColumnHeader AdjBCHeader;
		private System.Windows.Forms.CheckBox BallisticsUseSFCheckBox;
		private System.Windows.Forms.Label TwistMeasurementLabel;
		private System.Windows.Forms.Label label33;
		private CommonLib.Controls.cDoubleValueTextBox BallisticsTwistTextBox;
		private System.Windows.Forms.Label BallisticsSoundSpeedLabel;
		private System.Windows.Forms.Label label35;
		private System.Windows.Forms.Button BallisticsPrintButton;
		private System.Windows.Forms.ToolStripMenuItem HelpVideoRWBallisticsCalculatorMenuItem;
		private System.Windows.Forms.ColumnHeader EnergyHeader;
		private System.Windows.Forms.CheckBox BallisticsUseDensityAltitudeCheckBox;
		private System.Windows.Forms.Label BallisticsDensityAltitudeLabel;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label TemperatureMeasurementLabel;
		private System.Windows.Forms.CheckBox BallisticsUseStationPressureCheckBox;
		private System.Windows.Forms.Label BallisticsStationPressureLabel;
		private System.Windows.Forms.ToolStripMenuItem HelpPurchaseMenuItem;
		private System.Windows.Forms.ToolStripMenuItem FilePrintSupplyShoppingListMenuItem;
		private System.Windows.Forms.CheckBox SuppliesPrintBelowStockCheckBox;
		private System.Windows.Forms.CheckBox AmmoPrintBelowStockCheckBox;
		private System.Windows.Forms.ToolStripMenuItem FilePrintAmmoShoppingListMenuItem;
		private System.Windows.Forms.Button BallisticsKestrelButton;
		private System.Windows.Forms.ToolStripMenuItem ToolsTargetCalculatorMenuItem;
		}
	}

