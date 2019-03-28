//============================================================================*
// cMainForm.cs
//
// Copyright © 2013-2017, Kevin S. Beebe
// All Rights Reserved
//============================================================================*

//============================================================================*
// .Net Using Statements
//============================================================================*

using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;

//============================================================================*
// Application Specific Using Statements
//============================================================================*

using RWCommonLib.Registry;
using RWCommonLib.Updates;
using RWCommonLib.Forms;

//============================================================================*
// NameSpace
//============================================================================*

namespace ReloadersWorkShop
	{
	//============================================================================*
	// cMainForm Class
	//============================================================================*

	public partial class cMainForm : Form
		{
		//============================================================================*
		// Private Data Members
		//============================================================================*

		private cDataFiles m_DataFiles = null;

		private bool m_fInitialized = false;
		private bool m_fPopulating = false;

		private cRWRegistry m_RWRegistry = null;

		private Timer m_SaveTimer = new Timer();

		private bool m_fDev = false;

		//============================================================================*
		// cMainForm() - Constructor
		//============================================================================*

		public cMainForm(cRWRegistry RWRegistry, bool fDev)
			{
			InitializeComponent();

			m_RWRegistry = RWRegistry;
			m_fDev = fDev;

			//----------------------------------------------------------------------------*
			// Set the title text
			//----------------------------------------------------------------------------*

			if (RWRegistry.Trial)
				Text = String.Format("{0} Trial - v{1}", Application.ProductName, Application.ProductVersion);
			else
				Text = String.Format("{0} - v{1}", Application.ProductName, Application.ProductVersion);

			//----------------------------------------------------------------------------*
			// Load the data
			//----------------------------------------------------------------------------*

			m_DataFiles = new cDataFiles(this);

			m_DataFiles.Preferences.Dev = fDev;

			//----------------------------------------------------------------------------*
			// General Event Handlers
			//----------------------------------------------------------------------------*

			MainTabControl.SelectedIndexChanged += OnMainTabChanged;
			MainTabControl.GotFocus += OnMainTabGotFocus;

			//----------------------------------------------------------------------------*
			// Initialize Tabs
			//----------------------------------------------------------------------------*

			InitializeAllTabs();

			//----------------------------------------------------------------------------*
			// Select the last tab the user was using
			//----------------------------------------------------------------------------*

			if (m_DataFiles.Preferences.LastMainTabSelected != null)
				{
				try
					{
					MainTabControl.Focus();

					MainTabControl.SelectTab(m_DataFiles.Preferences.LastMainTabSelected);
					}
				catch
					{
					MainTabControl.SelectedIndex = 0;
					}
				}
			else
				MainTabControl.SelectedIndex = 0;

			//----------------------------------------------------------------------------*
			// Set up the auto save timer
			//----------------------------------------------------------------------------*

			m_SaveTimer.Tick += OnAutoSave;

			SetTimer();

			//----------------------------------------------------------------------------*
			// Menu Event Handlers
			//----------------------------------------------------------------------------*

			// File Menu

			FileMenuItem.DropDownOpened += OnFileClicked;

			FileBackupMenuItem.Click += OnFileBackupClicked;
			FileExitMenuItem.Click += OnFileExitClicked;
			FileExportMenuItem.Click += OnFileExportClicked;
			FileImportMenuItem.Click += OnFileImportClicked;
			FilePreferencesMenuItem.Click += OnFilePreferencesClicked;
			FilePrintAmmoListMenuItem.Click += OnPrintAmmoListClicked;
			FilePrintCostAnalysisMenuItem.Click += OnPrintCostAnalysisClicked;
			FilePrintFirearmsListMenuItem.Click += OnFirearmPrintClicked;
			FilePrintMenuItem.Click += OnFilePrintClicked;
			FilePrintMenuItem.DropDownOpened += OnFilePrintClicked;
			FilePrintLoadShoppingListMenuItem.Click += OnShoppingListClicked;
			FilePrintSupplyListMenuItem.Click += OnPrintSupplyListClicked;
			FileResetDataMenuItem.Click += OnFileResetDataClicked;
			FileRestoreBackupMenuItem.Click += OnFileRestoreBackupClicked;
			FileSaveMenuItem.Click += OnFileSaveClicked;

			// Edit Menu

			EditMenuItem.Click += OnEditClicked;
			EditMenuItem.DropDownOpened += OnEditClicked;
			EditNewMenuItem.Click += OnEditNewClicked;
			EditEditMenuItem.Click += OnEditEditClicked;
			EditRemoveMenuItem.Click += OnEditRemoveClicked;
			EditInventoryActivityMenuItem.Click += OnEditInventoryActivity;

			// View Menu

			ViewMenuItem.Click += OnViewClicked;
			ViewMenuItem.DropDownOpened += OnViewClicked;
			ViewViewMenuItem.Click += OnViewViewClicked;
			ViewCheckedMenuItem.Click += OnViewCheckedClicked;
			ViewInventoryActivityMenuItem.Click += OnViewInventoryActivity;

			ViewManufacturersMenuItem.Click += OnViewManufacturersClicked;
			ViewCalibersMenuItem.Click += OnViewCalibersClicked;
			ViewFirearmsMenuItem.Click += OnViewFirearmsClicked;
			ViewSuppliesMenuItem.Click += OnViewSuppliesClicked;
			ViewBulletsMenuItem.Click += OnViewBulletsClicked;
			ViewCasesMenuItem.Click += OnViewCasesClicked;
			ViewPowdersMenuItem.Click += OnViewPowdersClicked;
			ViewPrimersMenuItem.Click += OnViewPrimersClicked;
			ViewLoadDataMenuItem.Click += OnViewLoadDataClicked;
			ViewBatchEditorMenuItem.Click += OnViewBatchEditorClicked;
			ViewBallisticsMenuItem.Click += OnViewBallisticsClicked;
			ViewAmmoMenuItem.Click += OnViewAmmoClicked;

			// Tools Menu

			ToolsConversionCalculatorMenuItem.Click += OnToolsConversionCalculatorClicked;

			ToolsIntegrityCheckerMenuItem.Click += OnToolsIntegrityCheckerClicked;

			ToolsSAAMIWebsiteMenuItem.Click += OnToolsSAAMIWebsiteClicked;

			ToolsStabilityCalculatorMenuItem.Click += OnToolsStabilityCalculatorClicked;
			ToolsTargetCalculatorMenuItem.Click += OnToolsTargetCalculatorClicked;


			// Help Menu

			HelpMenuItem.DropDownOpened += OnHelpClicked;
			HelpAboutMenuItem.Click += OnHelpAboutClicked;
			HelpSupportForumMenuItem.Click += OnHelpContactSupportClicked;
			HelpNotesMenuItem.Click += OnHelpNotesClicked;
			HelpPurchaseMenuItem.Click += OnHelpPurchaseClicked;
			HelpProgramUpdateMenuItem.Click += OnHelpProgramUpdateClicked;
			HelpDataUpdateMenuItem.Click += OnHelpDataUpdateClicked;

			HelpVideoBulletSelectionMenuItem.Click += OnHelpVideoClicked;
			HelpVideoCrimpingMenuItem.Click += OnHelpVideoClicked;
			HelpVideoHeadspaceMenuItem.Click += OnHelpVideoClicked;
			HelpVideoRWBallisticsCalculatorMenuItem.Click += OnHelpVideoClicked;
			HelpVideoRWBatchEditorMenuItem.Click += OnHelpVideoClicked;
			HelpVideoRWCrossUseMenuItem.Click += OnHelpVideoClicked;
			HelpVideoRWExportingDataMenuItem.Click += OnHelpVideoClicked;
			HelpVideoRWInventoryMenuItem.Click += OnHelpVideoClicked;
			HelpVideoRWLoadDataMenuItem.Click += OnHelpVideoClicked;
			HelpVideoRWSettingJumpMenuItem.Click += OnHelpVideoClicked;
			HelpVideoRWTargetCalculatorMenuItem.Click += OnHelpVideoClicked;
			HelpVideoRWOperationMenuItem.Click += OnHelpVideoClicked;
			HelpVideoSDBCMenuItem.Click += OnHelpVideoClicked;

			//----------------------------------------------------------------------------*
			// Make sure we're not minimized
			//----------------------------------------------------------------------------*

			m_fInitialized = true;

			if (m_DataFiles.Preferences.Maximized)
				{
				NativeMethods.ShowWindowAsync(this.Handle, 3);

				OnResize(new EventArgs());
				}
			else
				{
				Size = m_DataFiles.Preferences.MainFormSize;
				Location = m_DataFiles.Preferences.MainFormLocation;

				NativeMethods.ShowWindowAsync(this.Handle, 1);

				OnResize(new EventArgs());
				}
			}

		//============================================================================*
		// BackupData()
		//============================================================================*

		public void BackupData()
			{
			//----------------------------------------------------------------------------*
			// Build a default backup file name
			//----------------------------------------------------------------------------*

			DateTime Date = DateTime.Now;

			string strDataFileName = String.Format("Backup {0}-{1:00}-{2:00} at {3:00}{4:00}{5:00}.rwb", Date.Year, Date.Month, Date.Day, Date.Hour, Date.Minute, Date.Second);

			//----------------------------------------------------------------------------*
			// Show the file dialog
			//----------------------------------------------------------------------------*

			SaveFileDialog FileDlg = new SaveFileDialog();

			FileDlg.Title = String.Format("Save {0} Backup File", Application.ProductName);
			FileDlg.AddExtension = true;
			FileDlg.DefaultExt = "rwb";
			FileDlg.InitialDirectory = m_DataFiles.Preferences.BackupFolder;
			FileDlg.Filter = String.Format("{0} Backup Files (*.rwb)|*.rwb", Application.ProductName);
			FileDlg.OverwritePrompt = true;
			FileDlg.FileName = strDataFileName;

			DialogResult rc = FileDlg.ShowDialog();

			if (rc == DialogResult.Cancel)
				return;

			//----------------------------------------------------------------------------*
			// Do the backup
			//----------------------------------------------------------------------------*

			string strFilePath = FileDlg.FileName;

			m_DataFiles.Preferences.BackupFolder = Path.GetDirectoryName(strFilePath);

			bool fSuccess = m_DataFiles.Save(strFilePath);

			//----------------------------------------------------------------------------*
			// Show backup results
			//----------------------------------------------------------------------------*

			string strCaption = "Backup Completed";
			string strText = "";
			MessageBoxIcon Icon = MessageBoxIcon.Information;

			if (fSuccess)
				{
				strText = String.Format("Backup completed successfully!\n\nBackup File Name: {0}\n\nBackup was saved to \"{1}\"", Path.GetFileName(strFilePath), m_DataFiles.Preferences.BackupFolder);
				}
			else
				{
				strCaption = "Backup Error!";
				Icon = MessageBoxIcon.Error;

				strText = "An error was encountered during backup operations.  Please check that the backup folder specified is valid.  If the folder is on a removable device, please ensure that the device is connected to your computer.";
				}

			MessageBox.Show(strText, strCaption, MessageBoxButtons.OK, Icon);
			}

		//============================================================================*
		// DownloadSAAMIDoc()
		//============================================================================*

		public static bool DownloadSAAMIDoc(cDataFiles DataFiles, string strDocPath, string strLocalFilePath)
			{
			string strLocalPath = Path.GetDirectoryName(strLocalFilePath);

			if (!Directory.Exists(strLocalPath))
				Directory.CreateDirectory(strLocalPath);

			if (!File.Exists(strLocalFilePath))
				{
				try
					{
					WebClient client = new WebClient();

					client.DownloadFile(strDocPath, strLocalFilePath);
					}
				catch (Exception e)
					{
					string strMessage = "Unable to download the SAAMI document for the following reason:\n\n";
					strMessage += e.Message;

					MessageBox.Show(strMessage, "Download Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

					return (false);
					}
				}

			return (true);
			}

		//============================================================================*
		// FilePreferences()
		//============================================================================*

		public void FilePreferences()
			{
			cPreferencesForm PreferencesForm = new cPreferencesForm(this, m_DataFiles);

			PreferencesForm.ShowDialog();
			}

		//============================================================================*
		// FileSave()
		//============================================================================*

		public void FileSave()
			{
			if (m_DataFiles.Save())
				MessageBox.Show("Data file saved successfully.", "Data Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
			else
				MessageBox.Show("Unable to save data file!", "Data Save Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}

		//============================================================================*
		// InitalizeAllTabs()
		//============================================================================*

		public void InitializeAllTabs()
			{
			m_DataFiles.CleanBackups();

			InitializeManufacturerTab();
			InitializeCaliberTab();
			InitializeFirearmTab();
			InitializeSuppliesTab();
			InitializeLoadDataTab();
			InitializeBatchTab();
			InitializeAmmoTab();
			InitializeToolTab();
			InitializeBallisticsTab();
			}

		//============================================================================*
		// OnAutoSave()
		//============================================================================*

		protected void OnAutoSave(object sender, EventArgs args)
			{
			m_DataFiles.Save();
			}

		//============================================================================*
		// OnEditClicked()
		//============================================================================*

		private void OnEditClicked(Object sender, EventArgs e)
			{
			EditInventoryActivityMenuItem.Visible = false;

			switch (MainTabControl.SelectedTab.Name)
				{
				case "ManufacturersTab":
					EditNewMenuItem.Text = "&New Manufacturer";
					EditNewMenuItem.Enabled = AddManufacturerButton.Enabled;
					EditEditMenuItem.Text = "&Edit Manufacturer";
					EditNewMenuItem.Enabled = EditManufacturerButton.Enabled;
					EditRemoveMenuItem.Text = "&Remove Manufacturer";
					EditNewMenuItem.Enabled = RemoveManufacturerButton.Enabled;
					break;

				case "CalibersTab":
					EditNewMenuItem.Text = "&New Caliber";
					EditNewMenuItem.Enabled = AddCaliberButton.Enabled;
					EditEditMenuItem.Text = "&Edit Caliber";
					EditEditMenuItem.Enabled = EditCaliberButton.Enabled;
					EditRemoveMenuItem.Text = "&Remove Caliber";
					EditRemoveMenuItem.Enabled = RemoveCaliberButton.Enabled;
					break;

				case "FirearmsTab":
					EditNewMenuItem.Text = "&New Firearm";
					EditNewMenuItem.Enabled = AddFirearmButton.Enabled;
					EditEditMenuItem.Text = "&Edit Firearm";
					EditEditMenuItem.Enabled = EditFirearmButton.Enabled;
					EditRemoveMenuItem.Text = "&Remove Firearm";
					EditRemoveMenuItem.Enabled = RemoveFirearmButton.Enabled;
					break;

				case "SuppliesTab":
					EditNewMenuItem.Enabled = AddSupplyButton.Enabled;
					EditEditMenuItem.Enabled = EditSupplyButton.Enabled;
					EditRemoveMenuItem.Enabled = RemoveSupplyButton.Enabled;
					EditInventoryActivityMenuItem.Visible = m_DataFiles.Preferences.TrackInventory;

					switch ((cSupply.eSupplyTypes) SupplyTypeCombo.SelectedIndex)
						{
						case cSupply.eSupplyTypes.Bullets:
							EditNewMenuItem.Text = "&New Bullet";
							EditEditMenuItem.Text = "&Edit Bullet";
							EditRemoveMenuItem.Text = "&Remove Bullet";
							break;

						case cSupply.eSupplyTypes.Cases:
							EditNewMenuItem.Text = "&New Case";
							EditEditMenuItem.Text = "&Edit Case";
							EditRemoveMenuItem.Text = "&Remove Case";
							break;

						case cSupply.eSupplyTypes.Powder:
							EditNewMenuItem.Text = "&New Powder";
							EditEditMenuItem.Text = "&Edit Powder";
							EditRemoveMenuItem.Text = "&Remove Powder";
							break;

						case cSupply.eSupplyTypes.Primers:
							EditNewMenuItem.Text = "&New Primer";
							EditEditMenuItem.Text = "&Edit Primer";
							EditRemoveMenuItem.Text = "&Remove Primer";
							break;
						}

					break;

				case "LoadDataTab":
					EditNewMenuItem.Text = "&New Load";
					EditNewMenuItem.Enabled = AddLoadButton.Enabled;
					EditEditMenuItem.Text = "&Edit Load";
					EditEditMenuItem.Enabled = EditLoadButton.Enabled;
					EditRemoveMenuItem.Text = "&Remove Load";
					EditRemoveMenuItem.Enabled = RemoveLoadButton.Enabled;
					break;

				case "BatchEditorTab":
					EditNewMenuItem.Text = "&New Batch";
					EditNewMenuItem.Enabled = AddBatchButton.Enabled;
					EditEditMenuItem.Text = "&Edit Batch";
					EditEditMenuItem.Enabled = EditBatchButton.Enabled;
					EditRemoveMenuItem.Text = "&Remove Batch";
					EditRemoveMenuItem.Enabled = RemoveBatchButton.Enabled;
					break;

				case "BallisticsTab":
					EditNewMenuItem.Text = "&New";
					EditNewMenuItem.Enabled = false;
					EditEditMenuItem.Text = "&Edit";
					EditEditMenuItem.Enabled = false;
					EditRemoveMenuItem.Text = "&Remove";
					EditRemoveMenuItem.Enabled = false;
					break;

				case "AmmoTab":
					EditNewMenuItem.Text = "&New Ammo";
					EditNewMenuItem.Enabled = AddAmmoButton.Enabled;
					EditEditMenuItem.Text = "&Edit Ammo";
					EditEditMenuItem.Enabled = EditAmmoButton.Enabled;
					EditRemoveMenuItem.Text = "&Remove Ammo";
					EditRemoveMenuItem.Enabled = RemoveAmmoButton.Enabled;
					EditInventoryActivityMenuItem.Visible = m_DataFiles.Preferences.TrackInventory;
					break;

				case "ToolsTab":
					EditNewMenuItem.Text = "&New Tool";
					EditNewMenuItem.Enabled = AddToolButton.Enabled;
					EditEditMenuItem.Text = "&Edit Tool";
					EditEditMenuItem.Enabled = EditToolButton.Enabled;
					EditRemoveMenuItem.Text = "&Remove Tool";
					EditRemoveMenuItem.Enabled = RemoveToolButton.Enabled;
					break;

				case "PreferencesTab":
					EditNewMenuItem.Text = "&New";
					EditNewMenuItem.Enabled = false;
					EditEditMenuItem.Text = "&Edit";
					EditEditMenuItem.Enabled = false;
					EditRemoveMenuItem.Text = "&Remove";
					EditRemoveMenuItem.Enabled = false;
					break;
				}
			}

		//============================================================================*
		// OnEditNewClicked()
		//============================================================================*

		private void OnEditNewClicked(Object sender, EventArgs e)
			{
			switch (MainTabControl.SelectedTab.Name)
				{
				case "ManufacturersTab":
					OnAddManufacturer(sender, e);

					break;

				case "CalibersTab":
					OnAddCaliber(sender, e);

					break;

				case "FirearmsTab":
					OnAddFirearm(sender, e);

					break;

				case "SuppliesTab":
					OnAddSupply(sender, e);

					break;

				case "LoadDataTab":
					OnAddLoad(sender, e);

					break;

				case "BatchTab":
					OnAddBatch(sender, e);

					break;

				case "AmmoTab":
					OnAddAmmo(sender, e);

					break;

				case "ToolsTab":
					OnAddTool(sender, e);

					break;
				}
			}

		//============================================================================*
		// OnEditEditClicked()
		//============================================================================*

		private void OnEditEditClicked(Object sender, EventArgs e)
			{
			switch (MainTabControl.SelectedTab.Name)
				{
				case "ManufacturersTab":
					if (EditManufacturerButton.Enabled)
						OnEditManufacturer(sender, e);

					break;

				case "CalibersTab":
					if (EditCaliberButton.Enabled)
						OnEditCaliber(sender, e);

					break;

				case "FirearmsTab":
					if (EditFirearmButton.Enabled)
						OnEditFirearm(sender, e);

					break;

				case "SuppliesTab":
					if (EditSupplyButton.Enabled)
						OnEditSupply(sender, e);

					break;

				case "LoadDataTab":
					if (EditLoadButton.Enabled)
						OnEditLoad(sender, e);

					break;

				case "BatchTab":
					if (EditBatchButton.Enabled)
						OnEditBatch(sender, e);

					break;

				case "AmmoTab":
					if (EditAmmoButton.Enabled)
						OnEditAmmo(sender, e);

					break;

				case "ToolsTab":
					if (EditToolButton.Enabled)
						OnEditTool(sender, e);

					break;
				}
			}

		//============================================================================*
		// OnEditInventoryActivity()
		//============================================================================*

		protected void OnEditInventoryActivity(object sender, EventArgs args)
			{
			ListViewItem Item = null;

			//----------------------------------------------------------------------------*
			// See which dialog we're on and get the Item object
			//----------------------------------------------------------------------------*

			switch (MainTabControl.SelectedTab.Name)
				{
				case "SuppliesTab":
					if (m_SuppliesListView.SelectedItems.Count == 0)
						return;

					Item = m_SuppliesListView.SelectedItems[0];

					break;

				case "AmmoTab":
					if (m_AmmoListView.SelectedItems.Count == 0)
						return;

					Item = m_AmmoListView.SelectedItems[0];

					break;
				}

			if (Item == null)
				return;

			//----------------------------------------------------------------------------*
			// Create the Supply object
			//----------------------------------------------------------------------------*

			cSupply Supply = (cSupply) Item.Tag;

			if (Supply == null)
				return;

			//----------------------------------------------------------------------------*
			// Start the dialog
			//----------------------------------------------------------------------------*

			cSupply OriginalSupply = Supply;

			cInventoryForm InventoryForm = new cInventoryForm(Supply, m_DataFiles, false);

			if (InventoryForm.ShowDialog() == DialogResult.OK && InventoryForm.Changed)
				{
				//----------------------------------------------------------------------------*
				// Determine which supply is being diaplayed
				//----------------------------------------------------------------------------*

				switch (Supply.SupplyType)
					{
					//----------------------------------------------------------------------------*
					// Bullets
					//----------------------------------------------------------------------------*

					case (int) cSupply.eSupplyTypes.Bullets:
						cBullet NewBullet = new cBullet((InventoryForm.Supply as cBullet));

						UpdateBullet((OriginalSupply as cBullet), NewBullet);

						UpdateSuppliesTabButtons();

						break;

					//----------------------------------------------------------------------------*
					// Cases
					//----------------------------------------------------------------------------*

					case cSupply.eSupplyTypes.Cases:
						cCase NewCase = new cCase((InventoryForm.Supply as cCase));

						UpdateCase((OriginalSupply as cCase), NewCase);

						UpdateSuppliesTabButtons();

						break;

					//----------------------------------------------------------------------------*
					// Powder
					//----------------------------------------------------------------------------*

					case cSupply.eSupplyTypes.Powder:
						cPowder NewPowder = new cPowder((InventoryForm.Supply as cPowder));

						UpdatePowder((OriginalSupply as cPowder), NewPowder);

						UpdateSuppliesTabButtons();

						break;

					//----------------------------------------------------------------------------*
					// Primers
					//----------------------------------------------------------------------------*

					case cSupply.eSupplyTypes.Primers:
						cPrimer NewPrimer = new cPrimer((InventoryForm.Supply as cPrimer));

						UpdatePrimer((OriginalSupply as cPrimer), NewPrimer);

						UpdateSuppliesTabButtons();

						break;

					//----------------------------------------------------------------------------*
					// Ammo
					//----------------------------------------------------------------------------*

					case cSupply.eSupplyTypes.Ammo:
						cAmmo NewAmmo = new cAmmo((InventoryForm.Supply as cAmmo));

						UpdateAmmo((OriginalSupply as cAmmo), NewAmmo);

						UpdateAmmoTabButtons();

						break;
					}
				}
			}

		//============================================================================*
		// OnEditRemoveClicked()
		//============================================================================*

		private void OnEditRemoveClicked(Object sender, EventArgs e)
			{
			switch (MainTabControl.SelectedTab.Name)
				{
				case "ManufacturersTab":
					if (RemoveManufacturerButton.Enabled)
						OnRemoveManufacturer(sender, e);

					break;

				case "CalibersTab":
					if (RemoveCaliberButton.Enabled)
						OnRemoveCaliber(sender, e);

					break;

				case "FirearmsTab":
					if (RemoveFirearmButton.Enabled)
						OnRemoveFirearm(sender, e);

					break;

				case "SuppliesTab":
					if (RemoveSupplyButton.Enabled)
						OnRemoveSupply(sender, e);

					break;

				case "LoadDataTab":
					if (RemoveLoadButton.Enabled)
						OnRemoveLoad(sender, e);

					break;

				case "BatchTab":
					if (RemoveBatchButton.Enabled)
						OnRemoveBatch(sender, e);

					break;

				case "AmmoTab":
					if (RemoveAmmoButton.Enabled)
						OnRemoveAmmo(sender, e);

					break;

				case "ToolsTab":
					if (RemoveToolButton.Enabled)
						OnRemoveTool(sender, e);

					break;
				}
			}

		//============================================================================*
		// OnFileClicked()
		//============================================================================*

		private void OnFileClicked(Object sender, EventArgs e)
			{
			//----------------------------------------------------------------------------*
			// If Dev flag is not set, remove the Reset Data Menu Item
			//----------------------------------------------------------------------------*

			if (FileMenuItem.DropDownItems.Contains(FileResetDataMenuItem) && !m_fDev)
				FileMenuItem.DropDownItems.Remove(FileResetDataMenuItem);
			}

		//============================================================================*
		// OnFileBackupClicked()
		//============================================================================*

		private void OnFileBackupClicked(Object sender, EventArgs e)
			{
			BackupData();
			}

		//============================================================================*
		// OnFileExitClicked()
		//============================================================================*

		private void OnFileExitClicked(Object sender, EventArgs e)
			{
			DialogResult rc = MessageBox.Show("Are you sure you wish to exit Reloader's workShop?", "Program Exit Verification", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

			if (rc == DialogResult.No)
				return;

			Close();
			}

		//============================================================================*
		// OnFileExportClicked()
		//============================================================================*

		public void OnFileExportClicked(Object sender, EventArgs e)
			{
			cExportForm ExportForm = new cExportForm(m_DataFiles, m_fDev);

			ExportForm.ShowDialog();
			}

		//============================================================================*
		// OnFileImportClicked()
		//============================================================================*

		public void OnFileImportClicked(Object sender, EventArgs args)
			{
			//----------------------------------------------------------------------------*
			// Get the file to import
			//----------------------------------------------------------------------------*

			OpenFileDialog FileDlg = new OpenFileDialog();

			FileDlg.Title = String.Format("Import {0} XML File", Application.ProductName);
			FileDlg.AddExtension = true;
			FileDlg.DefaultExt = "xml";
			FileDlg.InitialDirectory = m_DataFiles.GetDataPath();
			FileDlg.Filter = "XML Files (*.xml)|*.xml";

			DialogResult rc = FileDlg.ShowDialog();

			if (rc == DialogResult.Cancel)
				return;

			//----------------------------------------------------------------------------*
			// Load the XML document
			//----------------------------------------------------------------------------*

			string strPath = FileDlg.FileName;

			cRWXMLDocument XMLDocument = new cRWXMLDocument(m_DataFiles);

			try
				{
				XMLDocument.Load(strPath);
				}
			catch (Exception e)
				{
				MessageBox.Show(e.Message, "XML Import Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return;
				}

			//----------------------------------------------------------------------------*
			// Show the XML Document stats and data differences
			//----------------------------------------------------------------------------*

			XMLDocument.Import(true, true);

			//----------------------------------------------------------------------------*
			// Show the Summary dialog
			//----------------------------------------------------------------------------*

			cImportForm ImportForm = new ReloadersWorkShop.cImportForm(XMLDocument);

			ImportForm.ShowDialog();

			}

		//============================================================================*
		// OnFilePreferencesClicked()
		//============================================================================*

		private void OnFilePreferencesClicked(Object sender, EventArgs e)
			{
			FilePreferences();
			}

		//============================================================================*
		// OnFilePrintClicked()
		//============================================================================*

		private void OnFilePrintClicked(Object sender, EventArgs e)
			{
			FilePrintAmmoListMenuItem.Enabled = AmmoListPrintButton.Enabled;
			FilePrintAmmoShoppingListMenuItem.Enabled = m_DataFiles.Preferences.TrackInventory && AmmoListPrintButton.Enabled && AmmoMinStockCheckBox.Checked;

			FilePrintSupplyListMenuItem.Enabled = SupplyListPrintButton.Enabled;
			FilePrintSupplyShoppingListMenuItem.Enabled = m_DataFiles.Preferences.TrackInventory && SupplyListPrintButton.Enabled && SuppliesMinStockCheckBox.Checked;

			FilePrintLoadShoppingListMenuItem.Enabled = LoadShoppingListButton.Enabled;

			FilePrintFirearmsListMenuItem.Enabled = FirearmPrintButton.Enabled;
			}

		//============================================================================*
		// OnFilePrintDropDownOpened()
		//============================================================================*

		private void OnFilePrintDropDownOpened(Object sender, EventArgs e)
			{
			OnFilePrintClicked(sender, e);
			}

		//============================================================================*
		// OnFileResetDataClicked()
		//============================================================================*

		protected void OnFileResetDataClicked(object sender, EventArgs args)
			{
			if (MessageBox.Show("WARNING: ARE YOU SURE YOU WANT TO RESET ALL DATA?", "Massive Data Deletion Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
				{
				m_DataFiles.Reset();

				Size = m_DataFiles.Preferences.MainFormSize;
				Location = m_DataFiles.Preferences.MainFormLocation;

				InitializeAllTabs();
				}
			}

		//============================================================================*
		// OnFileRestoreBackupClicked()
		//============================================================================*

		protected void OnFileRestoreBackupClicked(object sender, EventArgs args)
			{
			RestoreBackup();
			}

		//============================================================================*
		// OnFileSaveClicked()
		//============================================================================*

		private void OnFileSaveClicked(Object sender, EventArgs e)
			{
			FileSave();
			}

		//============================================================================*
		// OnFormClosing()
		//============================================================================*

		protected override void OnFormClosing(FormClosingEventArgs e)
			{
			if (WindowState == FormWindowState.Normal)
				{
				m_DataFiles.Preferences.MainFormLocation = Location;
				m_DataFiles.Preferences.MainFormSize = Size;
				}

			m_DataFiles.Preferences.Maximized = WindowState == FormWindowState.Maximized;

			m_DataFiles.Save();
			m_DataFiles.ExportRecoveryFile();

			if (m_DataFiles.Preferences.BackupOK && m_DataFiles.Preferences.AutoBackup)
				{
				DateTime Date = DateTime.Now;

				string strFileName = String.Format("Backup {0}-{1:00}-{2:00} at {3:00}{4:00}{5:00}.rwb", Date.Year, Date.Month, Date.Day, Date.Hour, Date.Minute, Date.Second);

				string strFilePath = Path.Combine(m_DataFiles.Preferences.BackupFolder, strFileName);

				m_DataFiles.Save(strFilePath);
				}

			base.OnFormClosing(e);
			}

		//============================================================================*
		// OnHelpAboutClicked()
		//============================================================================*

		protected void OnHelpAboutClicked(object sender, EventArgs args)
			{
			AboutDialog AboutDlg = new AboutDialog(m_RWRegistry);

			AboutDlg.ShowDialog();
			}

		//============================================================================*
		// OnHelpClicked()
		//============================================================================*

		private void OnHelpClicked(Object sender, EventArgs e)
			{
			if (m_RWRegistry.Trial)
				HelpPurchaseMenuItem.Text = "Purchase Single-User &License";
			else
				{
				if (m_RWRegistry.ValidateKey())
					HelpPurchaseMenuItem.Text = "Purchase Additional &License";
				else
					HelpPurchaseMenuItem.Text = "Purchase Single-User &License";
				}
			}

		//============================================================================*
		// OnHelpContactSupportClicked()
		//============================================================================*

		protected void OnHelpContactSupportClicked(object sender, EventArgs args)
			{
			try
				{
				System.Diagnostics.Process.Start("mailto:Support@ReloadersWorkShop.com");
				}
			catch
				{
				MessageBox.Show(String.Format("Unable to start your email program.  Please contact Support@ReloadersWorkShop.com manually.", Application.ProductName), "Email Program Unavailable", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}

		//============================================================================*
		// OnHelpDataUpdateClicked()
		//============================================================================*

		protected void OnHelpDataUpdateClicked(object sender, EventArgs args)
			{
			bool fUpdate = true;

			//----------------------------------------------------------------------------*
			// See if there's a new update file
			//----------------------------------------------------------------------------*

			cRWUpdater RWUpdater = new cRWUpdater();

			try
				{
				string strOutputPath = m_DataFiles.GetDataPath();

				bool fSuccess = false;

//				bool fSuccess = RWUpdater.UpdateFile("RWDatabaseUpdate.xml", strOutputPath);

				if (fSuccess)
					{
					cRWXMLDocument XMLDocument = new cRWXMLDocument(m_DataFiles);

					XMLDocument.Load(Path.Combine(strOutputPath, "RWDatabaseUpdate.xml"));
					XMLDocument.Import(true, true);

					cImportForm ImportForm = new cImportForm(XMLDocument);

					DialogResult rc = ImportForm.ShowDialog();
					}
				else
					{
					fUpdate = false;
					}
				}
			catch
				{
				fUpdate = false;
				}

			//----------------------------------------------------------------------------*
			// If a problem was encountered, or no new data is available, display it
			//----------------------------------------------------------------------------*

			if (!fUpdate)
				{
				MessageBox.Show("No new data updates are available", "No Update Required", MessageBoxButtons.OK, MessageBoxIcon.Information);

				return;
				}
			}

		//============================================================================*
		// OnHelpNotesClicked()
		//============================================================================*

		protected void OnHelpNotesClicked(object sender, EventArgs args)
			{
			cReleaseNotesForm ReleaseNotesDlg = new cReleaseNotesForm();

			ReleaseNotesDlg.ShowDialog();
			}

		//============================================================================*
		// OnHelpProgramUpdateClicked()
		//============================================================================*

		protected void OnHelpProgramUpdateClicked(object sender, EventArgs args)
			{
			//----------------------------------------------------------------------------*
			// Check for updates
			//----------------------------------------------------------------------------*

			cRWUpdater RWUpdater = new cRWUpdater();

			if (RWUpdater.UpdatesAvailable)
				{
				DialogResult rc = MessageBox.Show(String.Format("A newer version of {0} is available.\n\nUpdate now? ({0} will restart)", Application.ProductName), "Update Available", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

				if (rc == DialogResult.No)
					return;

				m_DataFiles.Save();

				Process.Start("ReloadersWorkShopUpdater.exe");

				Close();
				}
			else
				{
				MessageBox.Show(String.Format("{0} is up to date", Application.ProductName), "No Update Required", MessageBoxButtons.OK, MessageBoxIcon.Information);

				return;
				}
			}

		//============================================================================*
		// OnHelpPurchaseClicked()
		//============================================================================*

		private void OnHelpPurchaseClicked(Object sender, EventArgs e)
			{
			cPurchaseKeyForm PurchaseForm = new cPurchaseKeyForm(m_RWRegistry);

			PurchaseForm.ShowDialog();
			}

		//============================================================================*
		// OnHelpVideoClicked()
		//============================================================================*

		protected void OnHelpVideoClicked(object sender, EventArgs args)
			{
			try
				{
				switch ((sender as ToolStripDropDownItem).Name)
					{
					case "HelpVideoBulletSelectionMenuItem":
						System.Diagnostics.Process.Start("https://www.youtube.com/v/bBy36tpgfTI?autoplay=1&rel=0&showinfo=0");
						break;
					case "HelpVideoCrimpingMenuItem":
						System.Diagnostics.Process.Start("https://www.youtube.com/v/MXWEfLE-tJg?autoplay=1&rel=0&showinfo=0");
						break;
					case "HelpVideoHeadspaceMenuItem":
						System.Diagnostics.Process.Start("https://www.youtube.com/v/OS5bfJ_2HNQ?autoplay=1&rel=0&showinfo=0");
						break;
					case "HelpVideoRWBallisticsCalculatorMenuItem":
						System.Diagnostics.Process.Start("https://www.youtube.com/v/6syoP-_TvZI?autoplay=1&rel=0&showinfo=0");
						break;
					case "HelpVideoRWBatchEditorMenuItem":
						System.Diagnostics.Process.Start("https://www.youtube.com/v/FO5z6Qvo-Lg?autoplay=1&rel=0&showinfo=0");
						break;
					case "HelpVideoRWCrossUseMenuItem":
						System.Diagnostics.Process.Start("https://www.youtube.com/v/xiSWuVINOf8?autoplay=1&rel=0&showinfo=0");
						break;
					case "HelpVideoRWExportingDataMenuItem":
						System.Diagnostics.Process.Start("https://www.youtube.com/v/kO0X6nvIiCg?autoplay=1&rel=0&showinfo=0");
						break;
					case "HelpVideoRWInventoryMenuItem":
						System.Diagnostics.Process.Start("https://www.youtube.com/v/xrkLTBP9jZs?autoplay=1&rel=0&showinfo=0");
						break;
					case "HelpVideoRWLoadDataMenuItem":
						System.Diagnostics.Process.Start("https://www.youtube.com/v/w2v_E3GaTbE?autoplay=1&rel=0&showinfo=0");
						break;
					case "HelpVideoRWOperationMenuItem":
						System.Diagnostics.Process.Start("https://www.youtube.com/v/MOWC-ljqo6s?autoplay=1&rel=0&showinfo=0");
						break;
					case "HelpVideoRWSettingJumpMenuItem":
						System.Diagnostics.Process.Start("https://www.youtube.com/v/qxTpO5z-Vto?autoplay=1&rel=0&showinfo=0");
						break;
					case "HelpVideoRWTargetCalculatorMenuItem":
						System.Diagnostics.Process.Start("https://www.youtube.com/v/WgaOR49oU-c?autoplay=1&rel=0&showinfo=0");
						break;
					case "HelpVideoSDBCMenuItem":
						System.Diagnostics.Process.Start("https://www.youtube.com/v/r5JdL_7saWg?autoplay=1&rel=0&showinfo=0");
						break;
					}
				}
			catch
				{
				MessageBox.Show("Unable to navigate to YouTube at this time, try again later.  Please make sure you are connected to the Internet.", "YouTube Unavailable", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}

		//============================================================================*
		// OnMainTabChanged()
		//============================================================================*

		protected void OnMainTabChanged(object sender, EventArgs args)
			{
			if (!m_fInitialized)
				return;

			if ((sender as TabControl).SelectedTab.Name == "InventoryTab" && !m_DataFiles.Preferences.TrackInventory)
				{
				MessageBox.Show("You must activate Inventory Tracking on the Preferences Tab in order to use the Inventory Tab", "Inventory Tracking Not Activated", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

				if (m_DataFiles.Preferences.LastTransactionSelected != null)
					MainTabControl.SelectTab(m_DataFiles.Preferences.LastMainTabSelected);
				else
					MainTabControl.SelectTab("ManufacturersTab");
				}

			m_DataFiles.Preferences.LastMainTabSelected = (sender as TabControl).SelectedTab.Name;

			switch ((sender as TabControl).SelectedTab.Name)
				{
				case "ManufacturersTab":
					m_ManufacturersListView.Focus();
					break;

				case "CalibersTab":
					m_CalibersListView.Focus();
					break;

				case "FirearmsTab":
					m_FirearmsListView.Focus();
					break;

				case "SuppliesTab":
					m_SuppliesListView.Focus();
					break;

				case "LoadDataTab":
					m_LoadDataListView.Focus();
					break;

				case "BatchEditorTab":
					m_BatchListView.Focus();
					break;

				case "AmmoTab":
					m_AmmoListView.Focus();
					break;
				}
			}

		//============================================================================*
		// OnMainTabGotFocus()
		//============================================================================*

		protected void OnMainTabGotFocus(object sender, EventArgs args)
			{
			switch ((sender as TabControl).SelectedTab.Name)
				{
				case "ManufacturersTab":
					m_ManufacturersListView.Focus();
					break;

				case "FirearmsTab":
					m_FirearmsListView.Focus();

					if (m_FirearmsListView.SelectedItems.Count > 0)
						m_FirearmsListView.EnsureVisible(m_FirearmsListView.SelectedItems[0].Index);

					if (m_FirearmAccessoriesListView.SelectedItems.Count > 0)
						m_FirearmAccessoriesListView.EnsureVisible(m_FirearmAccessoriesListView.SelectedItems[0].Index);

					break;

				case "CalibersTab":
					m_CalibersListView.Focus();

					if (m_CalibersListView.SelectedItems.Count > 0)
						m_CalibersListView.EnsureVisible(m_CalibersListView.SelectedItems[0].Index);

					break;

				case "SuppliesTab":
					m_SuppliesListView.Focus();

					if (m_SuppliesListView.SelectedItems.Count > 0)
						m_SuppliesListView.EnsureVisible(m_SuppliesListView.SelectedItems[0].Index);

					break;

				case "LoadDataTab":
					m_LoadDataListView.Focus();

					if (m_LoadDataListView.SelectedItems.Count > 0)
						m_LoadDataListView.EnsureVisible(m_LoadDataListView.SelectedItems[0].Index);

					break;

				case "BatchEditorTab":
					m_BatchListView.Focus();

					if (m_BatchListView.SelectedItems.Count > 0)
						m_BatchListView.EnsureVisible(m_BatchListView.SelectedItems[0].Index);

					break;
				}
			}

		//============================================================================*
		// OnMove()
		//============================================================================*

		protected override void OnMove(EventArgs e)
			{
			base.OnMove(e);

			if (!m_fInitialized)
				return;

			if (WindowState == FormWindowState.Normal && m_DataFiles != null)
				{
				if (m_DataFiles.Preferences.Maximized)
					Location = m_DataFiles.Preferences.MainFormLocation;
				else
					m_DataFiles.Preferences.MainFormLocation = this.Location;
				}
			}

		//============================================================================*
		// OnPrintCostAnalysisClicked()
		//============================================================================*

		protected void OnPrintCostAnalysisClicked(object sender, EventArgs args)
			{
			cCostAnalysisParms Parms = new cCostAnalysisParms(m_DataFiles);

			if (!(sender is ToolStripMenuItem))
				{
				if ((sender as Button).Name == "SuppliesCostAnalysisButton")
					{
					Parms.Reloads = false;
					Parms.Ammo = false;
					}

				if ((sender as Button).Name == "AmmoCostAnalysisButton")
					{
					Parms.Bullets = false;
					Parms.Cases = false;
					Parms.Powder = false;
					Parms.Primers = false;
					}
				}

			//----------------------------------------------------------------------------*
			// Show the dialog
			//----------------------------------------------------------------------------*

			cCostAnalysisForm CostAnalysisform = new cCostAnalysisForm(m_DataFiles, Parms);

			CostAnalysisform.ShowDialog();
			}

		//============================================================================*
		// OnResize()
		//============================================================================*

		protected override void OnResize(EventArgs e)
			{
			base.OnResize(e);

			if (!m_fInitialized)
				return;

			if (WindowState == FormWindowState.Normal && m_DataFiles != null)
				{
				if (m_DataFiles.Preferences.Maximized)
					Size = m_DataFiles.Preferences.MainFormSize;
				else
					m_DataFiles.Preferences.MainFormSize = this.Size;
				}

			m_DataFiles.Preferences.Maximized = (WindowState == FormWindowState.Maximized);

			MainTabControl.Location = new Point(0, MainMenu.Height);
			MainTabControl.Size = new Size(ClientRectangle.Width, ClientRectangle.Height - MainMenu.Height);

			//----------------------------------------------------------------------------*
			// Manufacturers Tab
			//----------------------------------------------------------------------------*

			int nButtonY = ClientRectangle.Height - 20 - AddManufacturerButton.Height - MainMenu.Height - ((MainTabControl.ItemSize.Height == 0) ? 21 : MainTabControl.ItemSize.Height);

			int nButtonSpacing = ((MainTabControl.Width / 4) - (AddManufacturerButton.Width + EditManufacturerButton.Width + ViewManufacturerButton.Width + RemoveManufacturerButton.Width)) / 2;

			if (nButtonSpacing <= 0)
				nButtonSpacing = 20;

			int nButtonX = (MainTabControl.Size.Width / 2) - ((AddManufacturerButton.Width + EditManufacturerButton.Width + RemoveManufacturerButton.Width + ViewManufacturerButton.Width + (nButtonSpacing * 2)) / 2);

			AddManufacturerButton.Location = new Point(nButtonX, nButtonY);
			nButtonX += AddManufacturerButton.Width + nButtonSpacing;

			EditManufacturerButton.Location = new Point(nButtonX, nButtonY);
			nButtonX += EditManufacturerButton.Width + nButtonSpacing;

			ViewManufacturerButton.Location = new Point(nButtonX, nButtonY);
			nButtonX += ViewManufacturerButton.Width + nButtonSpacing;

			RemoveManufacturerButton.Location = new Point(nButtonX, nButtonY);

			m_ManufacturersListView.Location = new Point(0, 0);
			m_ManufacturersListView.Size = new Size(MainTabControl.Width, nButtonY - 20);

			//----------------------------------------------------------------------------*
			// Calibers Tab
			//----------------------------------------------------------------------------*

			nButtonY = ClientRectangle.Height - 20 - AddCaliberButton.Height - MainMenu.Height - ((MainTabControl.ItemSize.Height == 0) ? 21 : MainTabControl.ItemSize.Height);

			nButtonSpacing = ((MainTabControl.Width / 4) - (AddCaliberButton.Width + EditCaliberButton.Width + ViewCaliberButton.Width + RemoveCaliberButton.Width)) / 2;

			if (nButtonSpacing <= 0)
				nButtonSpacing = 20;

			nButtonX = (MainTabControl.Size.Width / 2) - ((AddCaliberButton.Width + EditCaliberButton.Width + RemoveCaliberButton.Width + ViewCaliberButton.Width + (nButtonSpacing * 2)) / 2);

			AddCaliberButton.Location = new Point(nButtonX, nButtonY);
			nButtonX += AddCaliberButton.Width + nButtonSpacing;

			EditCaliberButton.Location = new Point(nButtonX, nButtonY);
			nButtonX += EditCaliberButton.Width + nButtonSpacing;

			ViewCaliberButton.Location = new Point(nButtonX, nButtonY);
			nButtonX += ViewCaliberButton.Width + nButtonSpacing;

			RemoveCaliberButton.Location = new Point(nButtonX, nButtonY);

			m_CalibersListView.Location = new Point(6, CaliberCountLabel.Location.Y + CaliberCountLabel.Height + 12);
			m_CalibersListView.Size = new Size(MainTabControl.Width - 26, nButtonY - 20 - m_CalibersListView.Location.Y);

			//----------------------------------------------------------------------------*
			// Firearms Tab
			//----------------------------------------------------------------------------*

			// Firearms Group

			FirearmCollectionGroupBox.Location = new Point(FirearmCostDetailsGroupBox.Location.X + FirearmCostDetailsGroupBox.Width + 6, FirearmCostDetailsGroupBox.Location.Y);

			Rectangle GroupRect = MainTabControl.ClientRectangle;

			GroupRect.X = 6;
			GroupRect.Y = 6;
			GroupRect.Height /= 2;
			GroupRect.Width = GroupRect.Width > FirearmCollectionGroupBox.Location.X + FirearmCollectionGroupBox.Width ? GroupRect.Width - 24 : FirearmCollectionGroupBox.Location.X + FirearmCollectionGroupBox.Width + 6;

			FirearmsGroupBox.Location = GroupRect.Location;
			FirearmsGroupBox.Size = GroupRect.Size;

			m_FirearmsListView.Location = new Point(10, FirearmCollectionGroupBox.Location.Y + FirearmCollectionGroupBox.Height + 10);
			m_FirearmsListView.Size = new Size(FirearmsGroupBox.Width - 18, FirearmsGroupBox.Height - AddFirearmButton.Height - FirearmCollectionGroupBox.Location.Y - FirearmCollectionGroupBox.Height - 30);

			nButtonY = FirearmsGroupBox.Height - AddFirearmAccessoryButton.Height - 10;

			nButtonSpacing = ((FirearmsGroupBox.Width / 4) - (AddFirearmButton.Width + EditFirearmButton.Width + ViewFirearmButton.Width + RemoveFirearmButton.Width)) / 2;

			if (nButtonSpacing <= 0)
				nButtonSpacing = 20;

			nButtonX = (FirearmsGroupBox.Size.Width / 2) - ((AddFirearmButton.Width + EditFirearmButton.Width + ViewFirearmButton.Width + RemoveFirearmButton.Width + (nButtonSpacing * 2)) / 2);

			AddFirearmButton.Location = new Point(nButtonX, nButtonY);
			nButtonX += AddFirearmButton.Width + nButtonSpacing;

			EditFirearmButton.Location = new Point(nButtonX, nButtonY);
			nButtonX += EditFirearmButton.Width + nButtonSpacing;

			ViewFirearmButton.Location = new Point(nButtonX, nButtonY);
			nButtonX += ViewFirearmButton.Width + nButtonSpacing;

			RemoveFirearmButton.Location = new Point(nButtonX, nButtonY);

			// Firearms Accessories Group

			GroupRect.Y += (GroupRect.Height + 6);
			GroupRect.Height = MainTabControl.Height - GroupRect.Y - MainTabControl.ItemSize.Height - 12;

			FirearmAccessoriesGroupBox.Location = GroupRect.Location;
			FirearmAccessoriesGroupBox.Size = GroupRect.Size;

			m_FirearmAccessoriesListView.Location = new Point(10, FirearmAccessoriesActionsGroupBox.Location.Y + FirearmAccessoriesActionsGroupBox.Height + 10);
			m_FirearmAccessoriesListView.Size = new Size(FirearmAccessoriesGroupBox.Width - 20, FirearmAccessoriesGroupBox.Height - AddFirearmAccessoryButton.Height - FirearmAccessoriesActionsGroupBox.Location.Y - FirearmAccessoriesActionsGroupBox.Height - 30);

			nButtonY = FirearmAccessoriesGroupBox.Height - AddFirearmAccessoryButton.Height - 10;

			nButtonSpacing = ((FirearmAccessoriesGroupBox.Width / 4) - (AddFirearmAccessoryButton.Width + EditFirearmAccessoryButton.Width + ViewFirearmAccessoryButton.Width + RemoveFirearmAccessoryButton.Width)) / 2;

			if (nButtonSpacing <= 0)
				nButtonSpacing = 20;

			nButtonX = (FirearmAccessoriesGroupBox.Size.Width / 2) - ((AddFirearmAccessoryButton.Width + EditFirearmAccessoryButton.Width + ViewFirearmAccessoryButton.Width + RemoveFirearmAccessoryButton.Width + (nButtonSpacing * 2)) / 2);

			AddFirearmAccessoryButton.Location = new Point(nButtonX, nButtonY);
			nButtonX += AddFirearmAccessoryButton.Width + nButtonSpacing;

			EditFirearmAccessoryButton.Location = new Point(nButtonX, nButtonY);
			nButtonX += EditFirearmAccessoryButton.Width + nButtonSpacing;

			ViewFirearmAccessoryButton.Location = new Point(nButtonX, nButtonY);
			nButtonX += ViewFirearmAccessoryButton.Width + nButtonSpacing;

			RemoveFirearmAccessoryButton.Location = new Point(nButtonX, nButtonY);

			//----------------------------------------------------------------------------*
			// Supplies Tab
			//----------------------------------------------------------------------------*

			nButtonY = ClientRectangle.Height - 20 - AddSupplyButton.Height - MainMenu.Height - ((MainTabControl.ItemSize.Height == 0) ? 21 : MainTabControl.ItemSize.Height);

			nButtonSpacing = ((MainTabControl.Width / 4) - (AddSupplyButton.Width + EditSupplyButton.Width + ViewSupplyButton.Width + RemoveSupplyButton.Width)) / 2;

			if (nButtonSpacing <= 0)
				nButtonSpacing = 20;

			nButtonX = (MainTabControl.Size.Width / 2) - ((AddSupplyButton.Width + EditSupplyButton.Width + ViewSupplyButton.Width + RemoveSupplyButton.Width + (nButtonSpacing * 2)) / 2);

			AddSupplyButton.Location = new Point(nButtonX, nButtonY);
			nButtonX += AddSupplyButton.Width + nButtonSpacing;

			EditSupplyButton.Location = new Point(nButtonX, nButtonY);
			nButtonX += EditSupplyButton.Width + nButtonSpacing;

			ViewSupplyButton.Location = new Point(nButtonX, nButtonY);
			nButtonX += ViewSupplyButton.Width + nButtonSpacing;

			RemoveSupplyButton.Location = new Point(nButtonX, nButtonY);
			nButtonX += ViewSupplyButton.Width + nButtonSpacing;

			m_SuppliesListView.Location = new Point(6, SupplyCountLabel.Location.Y + SupplyCountLabel.Height + 6);
			m_SuppliesListView.Size = new Size(MainTabControl.Width - 20, nButtonY - m_SuppliesListView.Location.Y - 20);

			//----------------------------------------------------------------------------*
			// Load Data Tab
			//----------------------------------------------------------------------------*

			nButtonY = ClientRectangle.Height - 20 - AddLoadButton.Height - MainMenu.Height - ((MainTabControl.ItemSize.Height == 0) ? 21 : MainTabControl.ItemSize.Height);

			nButtonSpacing = ((MainTabControl.Width / 4) - (AddLoadButton.Width + EditLoadButton.Width + RemoveLoadButton.Width + ViewLoadButton.Width)) / 2;

			if (nButtonSpacing <= 0)
				nButtonSpacing = 20;

			nButtonX = (MainTabControl.Size.Width / 2) - ((AddLoadButton.Width + EditLoadButton.Width + RemoveLoadButton.Width + ViewLoadButton.Width + (nButtonSpacing * 2)) / 2);

			AddLoadButton.Location = new Point(nButtonX, nButtonY);
			nButtonX += AddLoadButton.Width + nButtonSpacing;

			EditLoadButton.Location = new Point(nButtonX, nButtonY);
			nButtonX += EditLoadButton.Width + nButtonSpacing;

			ViewLoadButton.Location = new Point(nButtonX, nButtonY);
			nButtonX += ViewLoadButton.Width + nButtonSpacing;

			RemoveLoadButton.Location = new Point(nButtonX, nButtonY);

			LoadDataListViewInfoLabel.Size = new Size(ClientRectangle.Width, LoadDataListViewInfoLabel.Height);

			m_LoadDataListView.Location = new Point(6, LoadDataListViewInfoLabel.Location.Y + LoadDataListViewInfoLabel.Height + 6);
			m_LoadDataListView.Size = new Size(MainTabControl.Width - 26, nButtonY - m_LoadDataListView.Location.Y - 20);

			//----------------------------------------------------------------------------*
			// Batch Editor Tab
			//----------------------------------------------------------------------------*

			nButtonY = ClientRectangle.Height - 20 - AddBatchButton.Height - MainMenu.Height - MainTabControl.ItemSize.Height;

			nButtonSpacing = ((MainTabControl.Width / 4) - (AddBatchButton.Width + EditBatchButton.Width + RemoveBatchButton.Width + ViewBatchButton.Width)) / 2;

			if (nButtonSpacing <= 0)
				nButtonSpacing = 20;

			nButtonX = (ClientRectangle.Size.Width / 2) - ((AddBatchButton.Width + EditBatchButton.Width + RemoveBatchButton.Width + ViewBatchButton.Width + (nButtonSpacing * 2)) / 2);

			AddBatchButton.Location = new Point(nButtonX, nButtonY);
			nButtonX += AddBatchButton.Width + nButtonSpacing;

			EditBatchButton.Location = new Point(nButtonX, nButtonY);
			nButtonX += EditBatchButton.Width + nButtonSpacing;

			ViewBatchButton.Location = new Point(nButtonX, nButtonY);
			nButtonX += ViewBatchButton.Width + nButtonSpacing;

			RemoveBatchButton.Location = new Point(nButtonX, nButtonY);

			BatchNotTrackedLabel.Location = new Point(10, nButtonY);

			m_BatchListView.Location = new Point(6, BatchFiltersGroupBox.Location.Y + BatchFiltersGroupBox.Height + 6);
			m_BatchListView.Size = new Size(MainTabControl.Width - 20, nButtonY - m_BatchListView.Location.Y - 20);

			//----------------------------------------------------------------------------*
			// Ammo Tab
			//----------------------------------------------------------------------------*

			nButtonY = ClientRectangle.Height - 20 - AddAmmoButton.Height - MainMenu.Height - MainTabControl.ItemSize.Height;

			nButtonSpacing = ((ClientRectangle.Width / 4) - (AddAmmoButton.Width + EditAmmoButton.Width + RemoveAmmoButton.Width + ViewAmmoButton.Width)) / 2;

			if (nButtonSpacing <= 0)
				nButtonSpacing = 20;

			nButtonX = (ClientRectangle.Width / 2) - ((AddAmmoButton.Width + EditAmmoButton.Width + RemoveAmmoButton.Width + ViewAmmoButton.Width + (nButtonSpacing * 2)) / 2);

			AddAmmoButton.Location = new Point(nButtonX, nButtonY);
			nButtonX += AddAmmoButton.Width + nButtonSpacing;

			EditAmmoButton.Location = new Point(nButtonX, nButtonY);
			nButtonX += EditAmmoButton.Width + nButtonSpacing;

			ViewAmmoButton.Location = new Point(nButtonX, nButtonY);
			nButtonX += ViewAmmoButton.Width + nButtonSpacing;

			RemoveAmmoButton.Location = new Point(nButtonX, nButtonY);

			m_AmmoListView.Location = new Point(7, AmmoPrintOptionsGroupBox.Location.Y + AmmoPrintOptionsGroupBox.Height + 6);
			m_AmmoListView.Size = new Size(ClientRectangle.Width - 24, nButtonY - m_AmmoListView.Location.Y - 20);

			//----------------------------------------------------------------------------*
			// Tools Tab
			//----------------------------------------------------------------------------*

			nButtonY = ClientRectangle.Height - 20 - AddLoadButton.Height - MainMenu.Height - ((MainTabControl.ItemSize.Height == 0) ? 21 : MainTabControl.ItemSize.Height);

			nButtonSpacing = ((MainTabControl.Width / 4) - (AddToolButton.Width + EditToolButton.Width + RemoveToolButton.Width + ViewToolButton.Width)) / 2;

			if (nButtonSpacing <= 0)
				nButtonSpacing = 20;

			nButtonX = (MainTabControl.Size.Width / 2) - ((AddToolButton.Width + EditToolButton.Width + RemoveToolButton.Width + ViewToolButton.Width + (nButtonSpacing * 2)) / 2);

			AddToolButton.Location = new Point(nButtonX, nButtonY);
			nButtonX += AddToolButton.Width + nButtonSpacing;

			EditToolButton.Location = new Point(nButtonX, nButtonY);
			nButtonX += EditToolButton.Width + nButtonSpacing;

			ViewToolButton.Location = new Point(nButtonX, nButtonY);
			nButtonX += ViewToolButton.Width + nButtonSpacing;

			RemoveToolButton.Location = new Point(nButtonX, nButtonY);

			m_ToolsListView.Location = new Point(6, ToolsFiltersGroupBox.Location.Y + ToolsFiltersGroupBox.Height + 6);
			m_ToolsListView.Size = new Size(MainTabControl.Width - 26, nButtonY - m_ToolsListView.Location.Y - 20);
			}

		//============================================================================*
		// OnSaveTimer()
		//============================================================================*

		protected void OnSaveTimer(object sender, EventArgs args)
			{
			m_DataFiles.Save();
			}

		//============================================================================*
		// OnToolsConversionCalculatorClicked()
		//============================================================================*

		private void OnToolsConversionCalculatorClicked(Object sender, EventArgs e)
			{
			cConversionForm ConversionForm = new cConversionForm(m_DataFiles);

			ConversionForm.ShowDialog();
			}

		//============================================================================*
		// OnToolsIntegrityCheckerClicked()
		//============================================================================*

		private void OnToolsIntegrityCheckerClicked(Object sender, EventArgs e)
			{
			cDataIntegrityForm DataIntegrityForm = new cDataIntegrityForm(m_DataFiles);

			DataIntegrityForm.ShowDialog();
			}

		//============================================================================*
		// OnToolsSAAMIWebsiteClicked()
		//============================================================================*

		private void OnToolsSAAMIWebsiteClicked(Object sender, EventArgs e)
			{
			Process.Start("http://www.SAAMI.org/");
			}

		//============================================================================*
		// OnToolsStabilityCalculatorClicked()
		//============================================================================*

		private void OnToolsStabilityCalculatorClicked(Object sender, EventArgs e)
			{
			cStabilityForm StabilityForm = new cStabilityForm(m_DataFiles);

			StabilityForm.ShowDialog();
			}

		//============================================================================*
		// OnToolsTargetCalculatorClicked()
		//============================================================================*

		private void OnToolsTargetCalculatorClicked(Object sender, EventArgs e)
			{
			cTargetCalculatorForm TargetCalculatorForm = new cTargetCalculatorForm(m_DataFiles, m_RWRegistry);

			TargetCalculatorForm.ShowDialog();
			}

		//============================================================================*
		// OnViewAmmoClicked()
		//============================================================================*

		private void OnViewAmmoClicked(Object sender, EventArgs e)
			{
			MainTabControl.SelectedTab = AmmoTab;
			}

		//============================================================================*
		// OnViewBallisticsClicked()
		//============================================================================*

		private void OnViewBallisticsClicked(Object sender, EventArgs e)
			{
			MainTabControl.SelectedTab = BallisticsTab;
			}

		//============================================================================*
		// OnViewBatchEditorClicked()
		//============================================================================*

		private void OnViewBatchEditorClicked(Object sender, EventArgs e)
			{
			MainTabControl.SelectedTab = BatchEditorTab;
			}

		//============================================================================*
		// OnViewBulletsClicked()
		//============================================================================*

		private void OnViewBulletsClicked(Object sender, EventArgs e)
			{
			SupplyTypeCombo.SelectedIndex = (int) cSupply.eSupplyTypes.Bullets;
			MainTabControl.SelectedTab = SuppliesTab;
			}

		//============================================================================*
		// OnViewCalibersClicked()
		//============================================================================*

		private void OnViewCalibersClicked(Object sender, EventArgs e)
			{
			MainTabControl.SelectedTab = CalibersTab;
			}

		//============================================================================*
		// OnViewCasesClicked()
		//============================================================================*

		private void OnViewCasesClicked(Object sender, EventArgs e)
			{
			SupplyTypeCombo.SelectedIndex = (int) cSupply.eSupplyTypes.Cases;
			MainTabControl.SelectedTab = SuppliesTab;
			}

		//============================================================================*
		// OnViewCheckedClicked()
		//============================================================================*

		private void OnViewCheckedClicked(Object sender, EventArgs e)
			{
			switch (MainTabControl.SelectedTab.Name)
				{
				case "CalibersTab":
					OnHideUncheckedCalibersClicked(sender, e);

					break;

				case "SuppliesTab":
					OnHideUncheckedSuppliesClicked(sender, e);

					break;
				}
			}

		//============================================================================*
		// OnViewClicked()
		//============================================================================*

		private void OnViewClicked(Object sender, EventArgs e)
			{
			ViewInventoryActivityMenuItem.Visible = false;
			ViewCheckedMenuItem.Text = "Checked Only";

			switch (MainTabControl.SelectedTab.Name)
				{
				case "ManufacturersTab":
					ViewViewMenuItem.Text = "&View Manufacturer";
					ViewViewMenuItem.Enabled = ViewManufacturerButton.Enabled;
					ViewCheckedMenuItem.Visible = false;
					ViewCheckedMenuItem.Checked = false;

					break;

				case "CalibersTab":
					ViewViewMenuItem.Text = "&View Caliber";
					ViewViewMenuItem.Enabled = ViewCaliberButton.Enabled;
					ViewCheckedMenuItem.Text = "Checked Calibers &Only";
					ViewCheckedMenuItem.Visible = true;
					ViewCheckedMenuItem.Checked = m_DataFiles.Preferences.HideUncheckedCalibers;

					break;

				case "FirearmsTab":
					ViewViewMenuItem.Text = "&View Firearm";
					ViewViewMenuItem.Enabled = ViewFirearmButton.Enabled;
					ViewCheckedMenuItem.Visible = false;
					ViewCheckedMenuItem.Checked = false;

					break;

				case "SuppliesTab":
					ViewViewMenuItem.Enabled = ViewSupplyButton.Enabled;
					ViewViewMenuItem.Visible = true;
					ViewCheckedMenuItem.Text = "Checked Supplies &Only";
					ViewCheckedMenuItem.Checked = m_DataFiles.Preferences.HideUncheckedSupplies;
					ViewCheckedMenuItem.Visible = true;
					ViewInventoryActivityMenuItem.Visible = m_DataFiles.Preferences.TrackInventory;

					switch ((cSupply.eSupplyTypes) SupplyTypeCombo.SelectedIndex)
						{
						case cSupply.eSupplyTypes.Bullets:
							ViewViewMenuItem.Text = "&View Bullet";
							break;

						case cSupply.eSupplyTypes.Cases:
							ViewViewMenuItem.Text = "&View Case";
							break;

						case cSupply.eSupplyTypes.Powder:
							ViewViewMenuItem.Text = "&View Powder";
							break;

						case cSupply.eSupplyTypes.Primers:
							ViewViewMenuItem.Text = "&View Primer";
							break;
						}

					break;

				case "LoadDataTab":
					ViewViewMenuItem.Text = "&View Load";
					ViewViewMenuItem.Enabled = ViewLoadButton.Enabled;
					ViewCheckedMenuItem.Visible = false;
					ViewCheckedMenuItem.Checked = false;

					break;

				case "BatchEditorTab":
					ViewViewMenuItem.Text = "&View Batch";
					ViewViewMenuItem.Enabled = ViewBatchButton.Enabled;
					ViewCheckedMenuItem.Visible = false;
					ViewCheckedMenuItem.Checked = false;

					break;

				case "BallisticsTab":
					ViewViewMenuItem.Text = "&View";
					ViewViewMenuItem.Visible = false;
					ViewCheckedMenuItem.Visible = false;
					ViewCheckedMenuItem.Checked = false;

					break;

				case "AmmoTab":
					ViewViewMenuItem.Text = "&View Ammo";
					ViewViewMenuItem.Enabled = ViewAmmoButton.Enabled;
					ViewCheckedMenuItem.Text = "Checked Only";
					ViewCheckedMenuItem.Visible = false;
					ViewCheckedMenuItem.Checked = false;
					ViewInventoryActivityMenuItem.Visible = m_DataFiles.Preferences.TrackInventory;

					break;

				case "ToolsTab":
					ViewViewMenuItem.Text = "&View Tool";
					ViewViewMenuItem.Enabled = ViewToolButton.Enabled;
					ViewCheckedMenuItem.Visible = false;
					ViewCheckedMenuItem.Checked = false;

					break;
				}
			}

		//============================================================================*
		// OnViewFirearmsClicked()
		//============================================================================*

		private void OnViewFirearmsClicked(Object sender, EventArgs e)
			{
			MainTabControl.SelectedTab = FirearmsTab;
			}

		//============================================================================*
		// OnViewInventoryActivity()
		//============================================================================*

		protected void OnViewInventoryActivity(object sender, EventArgs args)
			{
			ListViewItem Item = null;

			//----------------------------------------------------------------------------*
			// See which dialog we're on and get the Item object
			//----------------------------------------------------------------------------*

			switch (MainTabControl.SelectedTab.Name)
				{
				case "SuppliesTab":
					if (m_SuppliesListView.SelectedItems.Count == 0)
						return;

					Item = m_SuppliesListView.SelectedItems[0];

					break;

				case "AmmoTab":
					if (m_AmmoListView.SelectedItems.Count == 0)
						return;

					Item = m_AmmoListView.SelectedItems[0];

					break;
				}

			if (Item == null)
				return;

			//----------------------------------------------------------------------------*
			// Create the Supply object
			//----------------------------------------------------------------------------*

			cSupply Supply = (cSupply) Item.Tag;

			if (Supply == null)
				return;

			//----------------------------------------------------------------------------*
			// Start the dialog
			//----------------------------------------------------------------------------*

			cInventoryForm InventoryForm = new cInventoryForm(Supply, m_DataFiles, true);

			InventoryForm.ShowDialog();
			}

		//============================================================================*
		// OnViewLoadDataClicked()
		//============================================================================*

		private void OnViewLoadDataClicked(Object sender, EventArgs e)
			{
			MainTabControl.SelectedTab = LoadDataTab;
			}

		//============================================================================*
		// OnViewManufacturersClicked()
		//============================================================================*

		private void OnViewManufacturersClicked(Object sender, EventArgs e)
			{
			MainTabControl.SelectedTab = ManufacturersTab;
			}

		//============================================================================*
		// OnViewPowdersClicked()
		//============================================================================*

		private void OnViewPowdersClicked(Object sender, EventArgs e)
			{
			SupplyTypeCombo.SelectedIndex = (int) cSupply.eSupplyTypes.Powder;
			MainTabControl.SelectedTab = SuppliesTab;
			}

		//============================================================================*
		// OnViewPrimersClicked()
		//============================================================================*

		private void OnViewPrimersClicked(Object sender, EventArgs e)
			{
			SupplyTypeCombo.SelectedIndex = (int) cSupply.eSupplyTypes.Primers;
			MainTabControl.SelectedTab = SuppliesTab;
			}

		//============================================================================*
		// OnViewSuppliesClicked()
		//============================================================================*

		private void OnViewSuppliesClicked(Object sender, EventArgs e)
			{
			MainTabControl.SelectedTab = SuppliesTab;
			}

		//============================================================================*
		// OnViewViewClicked()
		//============================================================================*

		private void OnViewViewClicked(Object sender, EventArgs e)
			{
			switch (MainTabControl.SelectedTab.Name)
				{
				case "ManufacturersTab":
					OnViewManufacturer(sender, e);
					break;

				case "CalibersTab":
					OnViewCaliber(sender, e);
					break;

				case "FirearmsTab":
					OnViewFirearm(sender, e);
					break;

				case "SuppliesTab":
					OnViewSupply(sender, e);
					break;

				case "LoadDataTab":
					OnViewLoad(sender, e);
					break;

				case "BatchEditorTab":
					OnViewBatch(sender, e);
					break;

				case "AmmoTab":
					OnViewAmmo(sender, e);
					break;

				case "ToolsTab":
					OnViewTool(sender, e);
					break;
				}
			}

		//============================================================================*
		// RestoreBackup()
		//============================================================================*

		public void RestoreBackup()
			{
			OpenFileDialog FileDlg = new OpenFileDialog();

			FileDlg.Title = String.Format("Restore {0} Backup File", Application.ProductName);
			FileDlg.AddExtension = true;
			FileDlg.DefaultExt = "rwb";
			FileDlg.InitialDirectory = m_DataFiles.Preferences.BackupFolder;
			FileDlg.Filter = String.Format("{0} Backup Files (*.rwb)|*.rwb", Application.ProductName);

			DialogResult rc = FileDlg.ShowDialog();

			if (rc == DialogResult.Cancel)
				return;

			string strPath = FileDlg.FileName;

			string strText = String.Format("Warning: Your current data will be replaced with the data contained in \n\n{0}\n\nAre you sure you wish to continue?", strPath);

			rc = MessageBox.Show(strText, "Data Restoration Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

			if (rc == DialogResult.Yes)
				{
				bool fLoadOK = m_DataFiles.Load(strPath, true);

				if (fLoadOK)
					InitializeAllTabs();
				}

			UpdateButtons();
			}

		//============================================================================*
		// SetTimer()
		//============================================================================*

		public void SetTimer()
			{
			if (m_SaveTimer == null)
				m_SaveTimer = new Timer();

			m_SaveTimer.Stop();
			m_SaveTimer.Interval = m_DataFiles.Preferences.AutoSaveTime;
			m_SaveTimer.Start();
			}

		//============================================================================*
		// UpdateButtons()
		//============================================================================*

		private void UpdateButtons()
			{
			UpdateManufacturerTabButtons();
			UpdateCaliberTabButtons();
			UpdateFirearmTabButtons();
			UpdateSuppliesTabButtons();
			UpdateBatchTabButtons();
			UpdateBallisticsTabButtons();
			UpdateAmmoTabButtons();
			}

		//============================================================================*
		// UpdateLauncher()
		//============================================================================*

		static private void UpdateLauncher()
			{
			cRWUpdater RWUpdater = new cRWUpdater();

			try
				{
				RWUpdater.UpdateFile("ReloadersWorkShopLauncher.exe");

				Process.Start("ReloadersWorkShopLauncher.exe");
				}
			catch (Exception e)
				{
				MessageBox.Show(e.Message);
				}
			}
		}
	}
