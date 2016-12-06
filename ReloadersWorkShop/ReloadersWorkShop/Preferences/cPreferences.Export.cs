using System;
using System.Drawing;
using System.Xml;
using System.Windows.Forms;

namespace ReloadersWorkShop.Preferences
	{
	public partial class cPreferences
		{
		//============================================================================*
		// Export()
		//============================================================================*

		public void Export(cRWXMLDocument XMLDocument, XmlElement XMLParentElement)
			{
			XmlElement XMLThisElement = XMLDocument.CreateElement("Preferences");
			XMLParentElement.AppendChild(XMLThisElement);

			//----------------------------------------------------------------------------*
			// Measurements Settings
			//----------------------------------------------------------------------------*

			XMLDocument.CreateElement("MetricBulletWeights", m_fMetricBulletWeights, XMLThisElement);
			XMLDocument.CreateElement("MetricCanWeights", m_fMetricCanWeights, XMLThisElement);
			XMLDocument.CreateElement("MetricDimensions", m_fMetricDimensions, XMLThisElement);
			XMLDocument.CreateElement("MetricFirearms", m_fMetricFirearms, XMLThisElement);
			XMLDocument.CreateElement("MetricGroups", m_fMetricGroups, XMLThisElement);
			XMLDocument.CreateElement("MetricPowderWeights", m_fMetricPowderWeights, XMLThisElement);
			XMLDocument.CreateElement("MetricRanges", m_fMetricRanges, XMLThisElement);
			XMLDocument.CreateElement("MetricShotWeights", m_fMetricShotWeights, XMLThisElement);
			XMLDocument.CreateElement("MetricVelocities", m_fMetricVelocities, XMLThisElement);

			//----------------------------------------------------------------------------*
			// Inventory system
			//----------------------------------------------------------------------------*

			XMLDocument.CreateElement("TrackInventory", m_fTrackInventory, XMLThisElement);

			XMLDocument.CreateElement("strCurrency", m_strCurrency, XMLThisElement);
			XMLDocument.CreateElement("TrackReloads", m_fTrackReloads, XMLThisElement);
			XMLDocument.CreateElement("UseLastPurchase", m_fUseLastPurchase, XMLThisElement);
			XMLDocument.CreateElement("IncludeTaxShipping", m_fIncludeTaxShipping, XMLThisElement);
			XMLDocument.CreateElement("TaxRate", m_dTaxRate, XMLThisElement);

			//----------------------------------------------------------------------------*
			// Atmospheric Settings
			//----------------------------------------------------------------------------*

			XMLDocument.CreateElement("MetricAltitudes", m_fMetricAltitudes, XMLThisElement);
			XMLDocument.CreateElement("MetricPressures", m_fMetricPressures, XMLThisElement);
			XMLDocument.CreateElement("MetricTemperatures", m_fMetricTemperatures, XMLThisElement);

			//----------------------------------------------------------------------------*
			// Decimals
			//----------------------------------------------------------------------------*

			XMLDocument.CreateElement("BulletWeightDecimals", m_nBulletWeightDecimals, XMLThisElement);
			XMLDocument.CreateElement("CanWeightDecimals", m_nCanWeightDecimals, XMLThisElement);
			XMLDocument.CreateElement("DimensionDecimals", m_nDimensionDecimals, XMLThisElement);
			XMLDocument.CreateElement("FirearmDecimals", m_nFirearmDecimals, XMLThisElement);
			XMLDocument.CreateElement("GroupDecimals", m_nGroupDecimals, XMLThisElement);
			XMLDocument.CreateElement("PowderWeightDecimals", m_nPowderWeightDecimals, XMLThisElement);
			XMLDocument.CreateElement("ShotWeightDecimals", m_nShotWeightDecimals, XMLThisElement);

			//----------------------------------------------------------------------------*
			// Window sizes and locations
			//----------------------------------------------------------------------------*

			XMLDocument.CreateElement("Maximized", m_fMaximized, XMLThisElement);

			XMLDocument.CreateElement("MainFormLocation", m_MainFormLocation, XMLThisElement);
			XMLDocument.CreateElement("MainFormSize", m_MainFormSize, XMLThisElement);

			XMLDocument.CreateElement("LastMainTabSelected", m_strLastMainTabSelected, XMLThisElement);

			//----------------------------------------------------------------------------*
			// Ammo Tab Settings
			//----------------------------------------------------------------------------*

			XMLDocument.CreateElement("AmmoNonZeroFilter", m_fAmmoNonZeroFilter, XMLThisElement);
			XMLDocument.CreateElement("AmmoMinStockFilter", m_fAmmoMinStockFilter, XMLThisElement);
			XMLDocument.CreateElement("AmmoFactoryFilter", m_fAmmoFactoryFilter, XMLThisElement);
			XMLDocument.CreateElement("AmmoFactoryReloadFilter", m_fAmmoFactoryReloadFilter, XMLThisElement);
			XMLDocument.CreateElement("AmmoMyReloadFilter", m_fAmmoMyReloadFilter, XMLThisElement);

			XMLDocument.CreateElement("AmmoSortColumn", m_nAmmoSortColumn, XMLThisElement);
			XMLDocument.CreateElement("AmmoSortOrder", m_AmmoSortOrder, XMLThisElement);

			//----------------------------------------------------------------------------*
			// Backup Settings
			//----------------------------------------------------------------------------*

			XMLDocument.CreateElement("BackupOK", m_fBackupOK, XMLThisElement);
			XMLDocument.CreateElement("AutoBackup", m_fAutoBackup, XMLThisElement);
			XMLDocument.CreateElement("BackupFolder", m_strBackupFolder, XMLThisElement);
			XMLDocument.CreateElement("AutoSaveTime", m_nAutoSaveTime, XMLThisElement);
			XMLDocument.CreateElement("BackupKeepDays", m_nBackupKeepDays, XMLThisElement);

			//----------------------------------------------------------------------------*
			// Ballistics Tab Settings
			//----------------------------------------------------------------------------*

			XMLDocument.CreateElement("ShowApexMarker", m_fShowApexMarker, XMLThisElement);
			XMLDocument.CreateElement("ShowDropChartRangeMarkers", m_fShowDropChartRangeMarkers, XMLThisElement);
			XMLDocument.CreateElement("ShowGroundStrikeMarkers", m_fShowGroundStrikeMarkers, XMLThisElement);
			XMLDocument.CreateElement("ShowTransonicMarkers", m_fShowTransonicMarkers, XMLThisElement);
			XMLDocument.CreateElement("ShowWindDriftRangeMarkers", m_fShowWindDriftRangeMarkers, XMLThisElement);
			XMLDocument.CreateElement("BallisticsUseSF", m_fBallisticsUseSF, XMLThisElement);

			//----------------------------------------------------------------------------*
			// Batch Load List
			//----------------------------------------------------------------------------*

			XMLDocument.CreateElement("BatchLoadSortColumn", m_nBatchLoadSortColumn, XMLThisElement);
			XMLDocument.CreateElement("BatchLoadSortOrder", m_BatchLoadSortOrder, XMLThisElement);

			//----------------------------------------------------------------------------*
			// Batch Print Form Settings
			//----------------------------------------------------------------------------*

			XMLDocument.CreateElement("BatchPrintPaper", m_nBatchPrintPaper, XMLThisElement);
			XMLDocument.CreateElement("BatchPrintStartLabel", m_nBatchPrintStartLabel, XMLThisElement);

			//----------------------------------------------------------------------------*
			// Bullet Caliber List settings
			//----------------------------------------------------------------------------*

			XMLDocument.CreateElement("BulletCaliberSortColumn", m_nBulletCaliberSortColumn, XMLThisElement);
			XMLDocument.CreateElement("BulletCaliberSortOrder", m_BulletCaliberSortOrder, XMLThisElement);

			//----------------------------------------------------------------------------*
			// Bullet Supply List settings
			//----------------------------------------------------------------------------*

			XMLDocument.CreateElement("BulletSortColumn", m_nBulletSortColumn, XMLThisElement);
			XMLDocument.CreateElement("BulletSortOrder", m_BulletSortOrder, XMLThisElement);

			//----------------------------------------------------------------------------*
			// Caliber List Settings
			//----------------------------------------------------------------------------*

			XMLDocument.CreateElement("CaliberSortColumn", m_nCaliberSortColumn, XMLThisElement);
			XMLDocument.CreateElement("CaliberSortOrder", m_CaliberSortOrder, XMLThisElement);

			//----------------------------------------------------------------------------*
			// Case Supply List Settings
			//----------------------------------------------------------------------------*

			XMLDocument.CreateElement("CaseSortColumn", m_nCaseSortColumn, XMLThisElement);
			XMLDocument.CreateElement("CaseSortOrder", m_CaseSortOrder, XMLThisElement);

			//----------------------------------------------------------------------------*
			// Charge List Settings
			//----------------------------------------------------------------------------*

			XMLDocument.CreateElement("ChargeSortColumn", m_nChargeSortColumn, XMLThisElement);
			XMLDocument.CreateElement("ChargeSortOrder", m_ChargeSortOrder, XMLThisElement);

			//----------------------------------------------------------------------------*
			// Charge Test List Settings
			//----------------------------------------------------------------------------*

			XMLDocument.CreateElement("ChargeTestSortColumn", m_nChargeTestSortColumn, XMLThisElement);
			XMLDocument.CreateElement("ChargeTestSortOrder", m_ChargeTestSortOrder, XMLThisElement);

			//----------------------------------------------------------------------------*
			// Conversion Calculator
			//----------------------------------------------------------------------------*

			XMLDocument.CreateElement("ConversionDecimals", m_nConversionDecimals, XMLThisElement);

			//----------------------------------------------------------------------------*
			// Copy Charge Form Settings
			//----------------------------------------------------------------------------*

			XMLDocument.CreateElement("CopyChargeSortColumn", m_nCopyChargeSortColumn, XMLThisElement);
			XMLDocument.CreateElement("CopyChargeSortOrder", m_CopyChargeSortOrder, XMLThisElement);

			//----------------------------------------------------------------------------*
			// Data Entry settings
			//----------------------------------------------------------------------------*

			XMLDocument.CreateElement("AutoCheck", m_fAutoCheck, XMLThisElement);
			XMLDocument.CreateElement("AutoCheckNonZero", m_fAutoCheckNonZero, XMLThisElement);
			XMLDocument.CreateElement("ToolTips", m_fToolTips, XMLThisElement);
			XMLDocument.CreateElement("ShowArchivedBatches", m_fShowArchivedBatches, XMLThisElement);

			//----------------------------------------------------------------------------*
			// Evaluation List Settings
			//----------------------------------------------------------------------------*

			XMLDocument.CreateElement("EvaluationSortColumn", m_nEvaluationSortColumn, XMLThisElement);
			XMLDocument.CreateElement("EvaluationSortOrder", m_EvaluationSortOrder, XMLThisElement);

			//----------------------------------------------------------------------------*
			// Firearm Form Settings
			//----------------------------------------------------------------------------*

			XMLDocument.CreateElement("FirearmBulletSortColumn", m_nFirearmBulletSortColumn, XMLThisElement);
			XMLDocument.CreateElement("FirearmBulletSortOrder", m_FirearmBulletSortOrder, XMLThisElement);

			//----------------------------------------------------------------------------*
			// Firearm Image Settings
			//----------------------------------------------------------------------------*

			XMLDocument.CreateElement("FirearmImagePath", m_strFirearmImagePath, XMLThisElement);

			//----------------------------------------------------------------------------*
			// Firearm List Settings
			//----------------------------------------------------------------------------*

			XMLDocument.CreateElement("FirearmPrintAll", m_fFirearmPrintAll, XMLThisElement);
			XMLDocument.CreateElement("FirearmPrintDetail", m_fFirearmPrintDetail, XMLThisElement);
			XMLDocument.CreateElement("FirearmPrintSpecs", m_fFirearmPrintSpecs, XMLThisElement);
			XMLDocument.CreateElement("FirearmSortColumn", m_nFirearmSortColumn, XMLThisElement);
			XMLDocument.CreateElement("FirearmSortOrder", m_FirearmSortOrder, XMLThisElement);

			//----------------------------------------------------------------------------*
			// Hide Unchecked Button States
			//----------------------------------------------------------------------------*

			XMLDocument.CreateElement("HideUncheckedCalibers", m_fHideUncheckedCalibers, XMLThisElement);
			XMLDocument.CreateElement("HideUncheckedSupplies", m_fHideUncheckedSupplies, XMLThisElement);

			//----------------------------------------------------------------------------*
			// Inventory Activity Settings
			//----------------------------------------------------------------------------*

			XMLDocument.CreateElement("LastActivityType", m_eLastActivityType, XMLThisElement);
			XMLDocument.CreateElement("LastPurchaseSource", m_strLastPurchaseSource, XMLThisElement);
			XMLDocument.CreateElement("LastAddStockReason", m_strLastAddStockReason, XMLThisElement);
			XMLDocument.CreateElement("LastReduceStockReason", m_strLastReduceStockReason, XMLThisElement);
			XMLDocument.CreateElement("LastFiredLocation", m_strLastFiredLocation, XMLThisElement);
			XMLDocument.CreateElement("ShowBatchTransactions", m_fShowBatchTransactions, XMLThisElement);
			XMLDocument.CreateElement("ShowArchivedTransactions", m_fShowArchivedTransactions, XMLThisElement);

			//----------------------------------------------------------------------------*
			// Inventory Group Settings
			//----------------------------------------------------------------------------*

			XMLDocument.CreateElement("Currency", m_strCurrency, XMLThisElement);
			XMLDocument.CreateElement("TrackReloads", m_fTrackReloads, XMLThisElement);
			XMLDocument.CreateElement("UseLastPurchase", m_fUseLastPurchase, XMLThisElement);
			XMLDocument.CreateElement("IncludeTaxShipping", m_fIncludeTaxShipping, XMLThisElement);
			XMLDocument.CreateElement("TaxRate", m_dTaxRate, XMLThisElement);

			//----------------------------------------------------------------------------*
			// Load Data List Settings
			//----------------------------------------------------------------------------*

			XMLDocument.CreateElement("LoadDataSortColumn", m_nLoadDataSortColumn, XMLThisElement);
			XMLDocument.CreateElement("LoadDataSortOrder", m_LoadDataSortOrder, XMLThisElement);

			//----------------------------------------------------------------------------*
			// Manufcturer List Settings
			//----------------------------------------------------------------------------*

			XMLDocument.CreateElement("ManufacturerSortColumn", m_nManufacturerSortColumn, XMLThisElement);
			XMLDocument.CreateElement("ManufacturerSortOrder", m_ManufacturerSortOrder, XMLThisElement);

			//----------------------------------------------------------------------------*
			// Powder Supply List Settings
			//----------------------------------------------------------------------------*

			XMLDocument.CreateElement("PowderSortColumn", m_nPowderSortColumn, XMLThisElement);
			XMLDocument.CreateElement("PowderSortOrder", m_PowderSortOrder, XMLThisElement);

			//----------------------------------------------------------------------------*
			// Primer Supply List Settings
			//----------------------------------------------------------------------------*

			XMLDocument.CreateElement("PrimerSortColumn", m_nPrimerSortColumn, XMLThisElement);
			XMLDocument.CreateElement("PrimerSortOrder", m_PrimerSortOrder, XMLThisElement);

			//----------------------------------------------------------------------------*
			// Supply Tab Settings
			//----------------------------------------------------------------------------*

			XMLDocument.CreateElement("LastSupplyTypeSelected", m_eLastSupplyTypeSelected, XMLThisElement);
			XMLDocument.CreateElement("SupplyPrintAll", m_fSupplyPrintAll, XMLThisElement);
			XMLDocument.CreateElement("SupplyPrintChecked", m_fSupplyPrintChecked, XMLThisElement);
			XMLDocument.CreateElement("SupplyPrintNonZero", m_fSupplyPrintNonZero, XMLThisElement);
			XMLDocument.CreateElement("SupplyPrintBelowStock", m_fSupplyPrintBelowStock, XMLThisElement);

			//----------------------------------------------------------------------------*
			// Target Calculator Colors
			//----------------------------------------------------------------------------*

			XMLDocument.CreateElement("TargetAimPointColor", m_TargetAimPointColor, XMLThisElement);
			XMLDocument.CreateElement("TargetExtremesColor", m_TargetExtremesColor, XMLThisElement);
			XMLDocument.CreateElement("TargetGroupBoxColor", m_TargetGroupBoxColor, XMLThisElement);
			XMLDocument.CreateElement("TargetOffsetColor", m_TargetOffsetColor, XMLThisElement);
			XMLDocument.CreateElement("TargetReticleColor", m_TargetReticleColor, XMLThisElement);
			XMLDocument.CreateElement("TargetScaleBackcolor", m_TargetScaleBackcolor, XMLThisElement);
			XMLDocument.CreateElement("TargetScaleForecolor", m_TargetScaleForecolor, XMLThisElement);
			XMLDocument.CreateElement("TargetShotColor", m_TargetShotColor, XMLThisElement);
			XMLDocument.CreateElement("TargetShotForecolor", m_TargetShotForecolor, XMLThisElement);

			//----------------------------------------------------------------------------*
			// Target Calculator Settings
			//----------------------------------------------------------------------------*

			XMLDocument.CreateElement("TargetShowBoxesSet", m_fTargetShowBoxesSet, XMLThisElement);
			XMLDocument.CreateElement("TargetShowAimPoint", m_fTargetShowAimPoint, XMLThisElement);
			XMLDocument.CreateElement("TargetShowExtremes", m_fTargetShowExtremes, XMLThisElement);
			XMLDocument.CreateElement("TargetShowGroupBox", m_fTargetShowGroupBox, XMLThisElement);
			XMLDocument.CreateElement("TargetShowOffset", m_fTargetShowOffset, XMLThisElement);
			XMLDocument.CreateElement("TargetShowScale", m_fTargetShowScale, XMLThisElement);
			XMLDocument.CreateElement("TargetShowShotNum", m_fTargetShowShotNum, XMLThisElement);

			//----------------------------------------------------------------------------*
			// Transaction List Settings
			//----------------------------------------------------------------------------*

			XMLDocument.CreateElement("TransactionSortColumn", m_nTransactionSortColumn, XMLThisElement);
			XMLDocument.CreateElement("TransactionSortOrder", m_TransactionSortOrder, XMLThisElement);
			}

		//============================================================================*
		// Import()
		//============================================================================*

		public bool Import(cRWXMLDocument XMLDocument, XmlNode XMLThisNode)
			{
			XmlNode XMLNode = XMLThisNode.FirstChild;

			while (XMLNode != null)
				{
				switch (XMLNode.Name)
					{
					//----------------------------------------------------------------------------*
					// Measurements Settings
					//----------------------------------------------------------------------------*

					case "MetricBulletWeights":
						XMLDocument.Import(XMLNode, out m_fMetricBulletWeights);
						break;
					case "MetricCanWeights":
						XMLDocument.Import(XMLNode, out m_fMetricCanWeights);
						break;
					case "MetricDimensions":
						XMLDocument.Import(XMLNode, out m_fMetricDimensions);
						break;
					case "MetricFirearms":
						XMLDocument.Import(XMLNode, out m_fMetricFirearms);
						break;
					case "MetricGroups":
						XMLDocument.Import(XMLNode, out m_fMetricGroups);
						break;
					case "MetricPowderWeights":
						XMLDocument.Import(XMLNode, out m_fMetricPowderWeights);
						break;
					case "MetricRanges":
						XMLDocument.Import(XMLNode, out m_fMetricRanges);
						break;
					case "MetricShotWeights":
						XMLDocument.Import(XMLNode, out m_fMetricShotWeights);
						break;
					case "MetricVelocities":
						XMLDocument.Import(XMLNode, out m_fMetricVelocities);
						break;

					//----------------------------------------------------------------------------*
					// Inventory system
					//----------------------------------------------------------------------------*

					case "TrackInventory":
						XMLDocument.Import(XMLNode, out m_fTrackInventory);
						break;
					case "Currency":
						XMLDocument.Import(XMLNode, out m_strCurrency);
						break;
					case "TrackReloads":
						XMLDocument.Import(XMLNode, out m_fTrackReloads);
						break;
					case "UseLastPurchase":
						XMLDocument.Import(XMLNode, out m_fUseLastPurchase);
						break;
					case "IncludeTaxShipping":
						XMLDocument.Import(XMLNode, out m_fIncludeTaxShipping);
						break;
					case "TaxRate":
						XMLDocument.Import(XMLNode, out m_dTaxRate);
						break;

					//----------------------------------------------------------------------------*
					// Atmospheric Settings
					//----------------------------------------------------------------------------*

					case "MetricAltitudes":
						XMLDocument.Import(XMLNode, out m_fMetricAltitudes);
						break;
					case "MetricPressures":
						XMLDocument.Import(XMLNode, out m_fMetricPressures);
						break;
					case "MetricTemperatures":
						XMLDocument.Import(XMLNode, out m_fMetricTemperatures);
						break;

					//----------------------------------------------------------------------------*
					// Decimals
					//----------------------------------------------------------------------------*

					case "BulletWeightDecimals":
						XMLDocument.Import(XMLNode, out m_nBulletWeightDecimals);
						break;
					case "CanWeightDecimals":
						XMLDocument.Import(XMLNode, out m_nCanWeightDecimals);
						break;
					case "DimensionDecimals":
						XMLDocument.Import(XMLNode, out m_nDimensionDecimals);
						break;
					case "FirearmDecimals":
						XMLDocument.Import(XMLNode, out m_nFirearmDecimals);
						break;
					case "GroupDecimals":
						XMLDocument.Import(XMLNode, out m_nGroupDecimals);
						break;
					case "PowderWeightDecimals":
						XMLDocument.Import(XMLNode, out m_nPowderWeightDecimals);
						break;
					case "ShotWeightDecimals":
						XMLDocument.Import(XMLNode, out m_nShotWeightDecimals);
						break;

					//----------------------------------------------------------------------------*
					// Window sizes and locations
					//----------------------------------------------------------------------------*

					case "Maximized":
						XMLDocument.Import(XMLNode, out m_fMaximized);
						break;
					case "MainFormLocation":
						XMLDocument.Import(XMLNode, out m_MainFormLocation);
						break;
					case "MainFormSize":
						XMLDocument.Import(XMLNode, out m_MainFormSize);
						break;
					case "LastMainTabSelected":
						XMLDocument.Import(XMLNode, out m_strLastMainTabSelected);
						break;

					//----------------------------------------------------------------------------*
					// Ammo Tab Settings
					//----------------------------------------------------------------------------*

					case "AmmoPrintAll":
						XMLDocument.Import(XMLNode, out m_fAmmoPrintAll);
						break;
					case "AmmoPrintChecked":
						XMLDocument.Import(XMLNode, out m_fAmmoPrintChecked);
						break;
					case "AmmoPrintNonZero":
						XMLDocument.Import(XMLNode, out m_fAmmoNonZeroFilter);
						break;
					case "AmmoMinStockFilter":
						XMLDocument.Import(XMLNode, out m_fAmmoMinStockFilter);
						break;
					case "AmmoFactoryFilter":
						XMLDocument.Import(XMLNode, out m_fAmmoFactoryFilter);
						break;
					case "AmmoFactoryReloadFilter":
						XMLDocument.Import(XMLNode, out m_fAmmoFactoryReloadFilter);
						break;
					case "AmmoMyReloadFilter":
						XMLDocument.Import(XMLNode, out m_fAmmoFactoryReloadFilter);
						break;
					case "AmmoSortColumn":
						XMLDocument.Import(XMLNode, out m_nAmmoSortColumn);
						break;
					case "AmmoSortOrder":
						XMLDocument.Import(XMLNode, out m_AmmoSortOrder);
						break;

					//----------------------------------------------------------------------------*
					// Backup Settings
					//----------------------------------------------------------------------------*

					case "BackupOK":
						m_fBackupOK = XMLNode.FirstChild.Value == "Yes";
						break;
					case "AutoBackup":
						m_fAutoBackup = XMLNode.FirstChild.Value == "Yes";
						break;
					case "BackupFolder":
						m_strBackupFolder = XMLNode.FirstChild.Value;
						break;
					case "AutoSaveTime":
						Int32.TryParse(XMLNode.FirstChild.Value, out m_nAutoSaveTime);
						break;
					case "BackupKeepDays":
						Int32.TryParse(XMLNode.FirstChild.Value, out m_nBackupKeepDays);
						break;

					//----------------------------------------------------------------------------*
					// Ballistics Tab Settings
					//----------------------------------------------------------------------------*

					case "ShowApexMarker":
						m_fShowApexMarker = XMLNode.FirstChild.Value == "Yes";
						break;
					case "ShowDropChartRangeMarkers":
						m_fShowDropChartRangeMarkers = XMLNode.FirstChild.Value == "Yes";
						break;
					case "ShowGroundStrikeMarkers":
						m_fShowGroundStrikeMarkers = XMLNode.FirstChild.Value == "Yes";
						break;
					case "ShowTransonicMarkers":
						m_fShowTransonicMarkers = XMLNode.FirstChild.Value == "Yes";
						break;
					case "ShowWindDriftRangeMarkers":
						m_fShowWindDriftRangeMarkers = XMLNode.FirstChild.Value == "Yes";
						break;
					case "BallisticsUseSF":
						m_fBallisticsUseSF = XMLNode.FirstChild.Value == "Yes";
						break;

					//----------------------------------------------------------------------------*
					// Batch Load List
					//----------------------------------------------------------------------------*

					case "BatchLoadSortColumn":
						Int32.TryParse(XMLNode.FirstChild.Value, out m_nBatchLoadSortColumn);
						break;
					case "BatchLoadSortOrder":
						SortOrder.TryParse(XMLNode.FirstChild.Value, out m_BatchLoadSortOrder);
						break;

					//----------------------------------------------------------------------------*
					// Batch Print Form Settings
					//----------------------------------------------------------------------------*

					case "BatchPrintPaper":
						Int32.TryParse(XMLNode.FirstChild.Value, out m_nBatchPrintPaper);
						break;
					case "BatchPrintStartLabel":
						Int32.TryParse(XMLNode.FirstChild.Value, out m_nBatchPrintStartLabel);
						break;

					//----------------------------------------------------------------------------*
					// Bullet Caliber List settings
					//----------------------------------------------------------------------------*

					case "BulletCaliberSortColumn":
						Int32.TryParse(XMLNode.FirstChild.Value, out m_nBulletCaliberSortColumn);
						break;
					case "BulletCaliberSortOrder":
						SortOrder.TryParse(XMLNode.FirstChild.Value, out m_BulletCaliberSortOrder);
						break;

					//----------------------------------------------------------------------------*
					// Bullet Supply List settings
					//----------------------------------------------------------------------------*

					case "BulletSortColumn":
						Int32.TryParse(XMLNode.FirstChild.Value, out m_nBulletSortColumn);
						break;
					case "BulletSortOrder":
						SortOrder.TryParse(XMLNode.FirstChild.Value, out m_BulletSortOrder);
						break;

					//----------------------------------------------------------------------------*
					// Caliber List Settings
					//----------------------------------------------------------------------------*

					case "CaliberSortColumn":
						Int32.TryParse(XMLNode.FirstChild.Value, out m_nCaliberSortColumn);
						break;
					case "CaliberSortOrder":
						SortOrder.TryParse(XMLNode.FirstChild.Value, out m_CaliberSortOrder);
						break;

					//----------------------------------------------------------------------------*
					// Case Supply List Settings
					//----------------------------------------------------------------------------*

					case "CaseSortColumn":
						Int32.TryParse(XMLNode.FirstChild.Value, out m_nCaseSortColumn);
						break;
					case "CaseSortOrder":
						SortOrder.TryParse(XMLNode.FirstChild.Value, out m_CaseSortOrder);
						break;

					//----------------------------------------------------------------------------*
					// Charge List Settings
					//----------------------------------------------------------------------------*

					case "ChargeSortColumn":
						Int32.TryParse(XMLNode.FirstChild.Value, out m_nChargeSortColumn);
						break;
					case "ChargeSortOrder":
						SortOrder.TryParse(XMLNode.FirstChild.Value, out m_ChargeSortOrder);
						break;

					//----------------------------------------------------------------------------*
					// Charge Test List Settings
					//----------------------------------------------------------------------------*

					case "ChargeTestSortColumn":
						Int32.TryParse(XMLNode.FirstChild.Value, out m_nChargeTestSortColumn);
						break;
					case "ChargeTestSortOrder":
						SortOrder.TryParse(XMLNode.FirstChild.Value, out m_ChargeTestSortOrder);
						break;

					//----------------------------------------------------------------------------*
					// Conversion Calculator
					//----------------------------------------------------------------------------*

					case "ConversionDecimals":
						Int32.TryParse(XMLNode.FirstChild.Value, out m_nConversionDecimals);
						break;

					//----------------------------------------------------------------------------*
					// Copy Charge Form Settings
					//----------------------------------------------------------------------------*

					case "CopyChargeSortColumn":
						Int32.TryParse(XMLNode.FirstChild.Value, out m_nCopyChargeSortColumn);
						break;
					case "CopyChargeSortOrder":
						SortOrder.TryParse(XMLNode.FirstChild.Value, out m_CopyChargeSortOrder);
						break;

					//----------------------------------------------------------------------------*
					// Data Entry settings
					//----------------------------------------------------------------------------*

					case "AutoCheck":
						m_fAutoCheck = XMLNode.FirstChild.Value == "Yes";
						break;
					case "AutoCheckNonZero":
						m_fAutoCheckNonZero = XMLNode.FirstChild.Value == "Yes";
						break;
					case "ToolTips":
						m_fToolTips = XMLNode.FirstChild.Value == "Yes";
						break;
					case "ShowArchivedBatches":
						m_fShowArchivedBatches = XMLNode.FirstChild.Value == "Yes";
						break;

					//----------------------------------------------------------------------------*
					// Evaluation List Settings
					//----------------------------------------------------------------------------*

					case "EvaluationSortColumn":
						Int32.TryParse(XMLNode.FirstChild.Value, out m_nEvaluationSortColumn);
						break;
					case "EvaluationSortOrder":
						SortOrder.TryParse(XMLNode.FirstChild.Value, out m_EvaluationSortOrder);
						break;

					//----------------------------------------------------------------------------*
					// Firearm Form Settings
					//----------------------------------------------------------------------------*

					case "FirearmBulletSortColumn":
						Int32.TryParse(XMLNode.FirstChild.Value, out m_nFirearmBulletSortColumn);
						break;
					case "FirearmBulletSortOrder":
						SortOrder.TryParse(XMLNode.FirstChild.Value, out m_FirearmBulletSortOrder);
						break;

					//----------------------------------------------------------------------------*
					// Firearm Image Settings
					//----------------------------------------------------------------------------*

					case "FirearmImagePath":
						m_strFirearmImagePath = XMLNode.FirstChild.Value;
						break;

					//----------------------------------------------------------------------------*
					// Firearm List Settings
					//----------------------------------------------------------------------------*

					case "FirearmPrintAll":
						m_fFirearmPrintAll = XMLNode.FirstChild.Value == "Yes";
						break;
					case "FirearmPrintDetail":
						m_fFirearmPrintDetail = XMLNode.FirstChild.Value == "Yes";
						break;
					case "FirearmPrintSpecs":
						m_fFirearmPrintSpecs = XMLNode.FirstChild.Value == "Yes";
						break;
					case "FirearmSortColumn":
						Int32.TryParse(XMLNode.FirstChild.Value, out m_nFirearmSortColumn);
						break;
					case "FirearmSortOrder":
						SortOrder.TryParse(XMLNode.FirstChild.Value, out m_FirearmSortOrder);
						break;

					//----------------------------------------------------------------------------*
					// Hide Unchecked Button States
					//----------------------------------------------------------------------------*

					case "HideUncheckedCalibers":
						m_fHideUncheckedCalibers = XMLNode.FirstChild.Value == "Yes";
						break;
					case "HideUncheckedSupplies":
						m_fHideUncheckedSupplies = XMLNode.FirstChild.Value == "Yes";
						break;

					//----------------------------------------------------------------------------*
					// Inventory Activity Settings
					//----------------------------------------------------------------------------*

					case "LastActivityType":
						m_eLastActivityType = cTransaction.TransactionTypeFromString(XMLNode.FirstChild.Value);
						break;
					case "LastPurchaseSource":
						m_strLastPurchaseSource = XMLNode.FirstChild.Value;
						break;
					case "LastAddStockReason":
						m_strLastAddStockReason = XMLNode.FirstChild.Value;
						break;
					case "LastReduceStockReason":
						m_strLastReduceStockReason = XMLNode.FirstChild.Value;
						break;
					case "LastFiredLocation":
						m_strLastFiredLocation = XMLNode.FirstChild.Value;
						break;
					case "ShowBatchTransactions":
						m_fShowBatchTransactions = XMLNode.FirstChild.Value == "Yes";
						break;
					case "ShowArchivedTransactions":
						m_fShowArchivedTransactions = XMLNode.FirstChild.Value == "Yes";
						break;

					//----------------------------------------------------------------------------*
					// Load Data List Settings
					//----------------------------------------------------------------------------*

					case "LoadDataSortColumn":
						XMLDocument.Import(XMLNode, out m_nLoadDataSortColumn);
						break;
					case "LoadDataSortOrder":
						XMLDocument.Import(XMLNode, out m_LoadDataSortOrder);
						break;

					//----------------------------------------------------------------------------*
					// Manufcturer List Settings
					//----------------------------------------------------------------------------*

					case "ManufacturerSortColumn":
						XMLDocument.Import(XMLNode, out m_nManufacturerSortColumn);
						break;
					case "ManufacturerSortOrder":
						XMLDocument.Import(XMLNode, out m_ManufacturerSortOrder);
						break;

					//----------------------------------------------------------------------------*
					// Powder Supply List Settings
					//----------------------------------------------------------------------------*

					case "PowderSortColumn":
						XMLDocument.Import(XMLNode, out m_nPowderSortColumn);
						break;
					case "PowderSortOrder":
						XMLDocument.Import(XMLNode, out m_PowderSortOrder);
						break;

					//----------------------------------------------------------------------------*
					// Primer Supply List Settings
					//----------------------------------------------------------------------------*

					case "PrimerSortColumn":
						XMLDocument.Import(XMLNode, out m_nPrimerSortColumn);
						break;
					case "PrimerSortOrder":
						XMLDocument.Import(XMLNode, out m_PrimerSortOrder);
						break;

					//----------------------------------------------------------------------------*
					// Supply Tab Settings
					//----------------------------------------------------------------------------*

					case "LastSupplyTypeSelected":
						m_eLastSupplyTypeSelected = cSupply.SupplyTypeFromString(XMLNode.FirstChild.Value);
						break;
					case "SupplyPrintAll":
						m_fSupplyPrintAll = XMLNode.FirstChild.Value == "Yes";
						break;
					case "SupplyPrintChecked":
						m_fSupplyPrintChecked = XMLNode.FirstChild.Value == "Yes";
						break;
					case "SupplyPrintNonZero":
						m_fSupplyPrintNonZero = XMLNode.FirstChild.Value == "Yes";
						break;
					case "SupplyPrintBelowStock":
						m_fSupplyPrintBelowStock = XMLNode.FirstChild.Value == "Yes";
						break;

					//----------------------------------------------------------------------------*
					// Target Calculator Colors
					//----------------------------------------------------------------------------*

					case "TargetAimPointColor":
						XMLDocument.Import(XMLNode, out m_TargetAimPointColor);
						break;
					case "TargetExtremesColor":
						XMLDocument.Import(XMLNode, out m_TargetExtremesColor);
						break;
					case "TargetGroupBoxColor":
						XMLDocument.Import(XMLNode, out m_TargetGroupBoxColor);
						break;
					case "TargetOffsetColor":
						XMLDocument.Import(XMLNode, out m_TargetOffsetColor);
						break;
					case "TargetReticleColor":
						XMLDocument.Import(XMLNode, out m_TargetReticleColor);
						break;
					case "TargetScaleBackcolor":
						XMLDocument.Import(XMLNode, out m_TargetScaleBackcolor);
						break;
					case "TargetScaleForecolor":
						XMLDocument.Import(XMLNode, out m_TargetScaleForecolor);
						break;
					case "TargetShotColor":
						XMLDocument.Import(XMLNode, out m_TargetShotColor);
						break;
					case "TargetShotForecolor":
						XMLDocument.Import(XMLNode, out m_TargetShotForecolor);
						break;

					//----------------------------------------------------------------------------*
					// Target Calculator Settings
					//----------------------------------------------------------------------------*

					case "TargetShowBoxesSet":
						XMLDocument.Import(XMLNode, out m_fTargetShowBoxesSet);
						break;
					case "TargetShowAimPoint":
						XMLDocument.Import(XMLNode, out m_fTargetShowAimPoint);
						break;
					case "TargetShowExtremes":
						XMLDocument.Import(XMLNode, out m_fTargetShowExtremes);
						break;
					case "TargetShowGroupBox":
						XMLDocument.Import(XMLNode, out m_fTargetShowGroupBox);
						break;
					case "TargetShowOffset":
						XMLDocument.Import(XMLNode, out m_fTargetShowOffset);
						break;
					case "TargetShowScale":
						XMLDocument.Import(XMLNode, out m_fTargetShowScale);
						break;
					case "TargetShowShotNum":
						XMLDocument.Import(XMLNode, out m_fTargetShowShotNum);
						break;

					//----------------------------------------------------------------------------*
					// Transaction List Settings
					//----------------------------------------------------------------------------*

					case "TransactionSortColumn":
						XMLDocument.Import(XMLNode, out m_nTransactionSortColumn);
						break;
					case "TransactionSortOrder":
						XMLDocument.Import(XMLNode, out m_TransactionSortOrder);
						break;
					default:
						break;
					}

				XMLNode = XMLNode.NextSibling;
				}

			return (true);
			}
		}
	}
