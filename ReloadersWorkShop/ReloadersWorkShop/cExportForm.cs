//============================================================================*
// cExportForm.cs
//
// Copyright © 2013-2017, Kevin S. Beebe
// All Rights Reserved
//============================================================================*

//============================================================================*
// .Net Using Statements
//============================================================================*

using System;
using System.IO;
using System.Windows.Forms;
using System.Xml;

//============================================================================*
// Namespace
//============================================================================*

namespace ReloadersWorkShop
	{
	//============================================================================*
	// ExportForm Class
	//============================================================================*

	public partial class cExportForm : Form
		{
		//============================================================================*
		// Private Data Members
		//============================================================================*

		private cDataFiles m_DataFiles = null;
		private string m_strFilePath = String.Format(@"C:\Users\Public\{0}\Exported Data\RWData.csv", Application.ProductName);

		//============================================================================*
		// cExportForm() - Constructor
		//============================================================================*

		public cExportForm(cDataFiles DataFiles)
			{
			InitializeComponent();

			if (!Directory.Exists(Path.GetDirectoryName(m_strFilePath)))
				Directory.CreateDirectory(Path.GetDirectoryName(m_strFilePath));

			m_DataFiles = DataFiles;

			SetClientSizeCore(ExportFileGroupBox.Location.X + ExportFileGroupBox.Width + 10, CancelFormButton.Location.Y + CancelFormButton.Height + 20);

			//----------------------------------------------------------------------------*
			// Event Handlers
			//----------------------------------------------------------------------------*

			BrowseButton.Click += OnBrowseClicked;
			ExportButton.Click += OnExportClicked;

			FullDataDumpCheckBox.Click += OnFilterClicked;
			LoadsCheckBox.Click += OnFilterClicked;
			BatchesCheckBox.Click += OnFilterClicked;

			ManufacturersCheckBox.Click += OnFilterClicked;
			CalibersCheckBox.Click += OnFilterClicked;
			FirearmsCheckBox.Click += OnFilterClicked;
			PartsCheckBox.Click += OnFilterClicked;

			BulletsCheckBox.Click += OnFilterClicked;
			CasesCheckBox.Click += OnFilterClicked;
			PowdersCheckBox.Click += OnFilterClicked;
			PrimersCheckBox.Click += OnFilterClicked;

			AmmoCheckBox.Click += OnFilterClicked;
			FileTypeCombo.SelectedIndexChanged += OnFileTypeSelected;

			//----------------------------------------------------------------------------*
			// Set Data Fields
			//----------------------------------------------------------------------------*

			FileTypeCombo.SelectedIndex = 0;

			SetFileName();

			UpdateButtons();
			}

		//============================================================================*
		// Export()
		//============================================================================*

		public void Export()
			{
			bool fExportOK = false;

			switch ((cDataFiles.eExportType) FileTypeCombo.SelectedIndex)
				{
				case cDataFiles.eExportType.CSV:
					StreamWriter Writer = null;

					try
						{
						//----------------------------------------------------------------------------*
						// Create the StreamWriter
						//----------------------------------------------------------------------------*

						Writer = new StreamWriter(m_strFilePath);
						}
					catch
						{
						MessageBox.Show("Unable to open export file!  Make sure  you have the appropriate permissions for the destination folder.", "CSV Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

						return;
						}

					if (Writer != null)
						{
						fExportOK = ExportCSV(Writer);

						Writer.Close();
						}

					break;

				case cDataFiles.eExportType.XML:
					XmlDocument XMLDocument = ExportXML();

					if (XMLDocument != null)
						{
						try
							{
							XmlTextWriter XMLTextWriter = new XmlTextWriter(m_strFilePath, System.Text.Encoding.ASCII);
							XMLTextWriter.Formatting = Formatting.Indented;
							XMLTextWriter.Indentation = 4;
							XMLTextWriter.IndentChar = '\t';

							XMLDocument.PreserveWhitespace = true;

							XMLDocument.Save(XMLTextWriter);

							XMLTextWriter.Close();

							fExportOK = true;
							}
						catch
							{
							MessageBox.Show("Unable to export XML file!  Make sure  you have the appropriate permissions for the destination folder.", "XML Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

							return;
							}
						}

					break;
				}

			if (fExportOK)
				MessageBox.Show("Data Exported Successfully!", "Export Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}

		//============================================================================*
		// ExportCSV()
		//============================================================================*

		public bool ExportCSV(StreamWriter Writer)
			{
			bool fSuccess = true;

			try
				{
				//----------------------------------------------------------------------------*
				// Check the StreamWriter
				//----------------------------------------------------------------------------*

				if (Writer != null)
					{
					//----------------------------------------------------------------------------*
					// Store the header
					//----------------------------------------------------------------------------*

					Writer.WriteLine(String.Format("{0} Data File Export", Application.ProductName));
					Writer.WriteLine();

					//----------------------------------------------------------------------------*
					// Export Data
					//----------------------------------------------------------------------------*

					if (ManufacturersCheckBox.Checked)
						m_DataFiles.ManufacturerList.Export(Writer);

					if (CalibersCheckBox.Checked)
						m_DataFiles.CaliberList.Export(Writer);

					if (FirearmsCheckBox.Checked)
						m_DataFiles.FirearmList.Export(Writer);

					if (AmmoCheckBox.Checked)
						m_DataFiles.AmmoList.Export(Writer);

					if (BulletsCheckBox.Checked)
						m_DataFiles.BulletList.Export(Writer);

					if (PowdersCheckBox.Checked)
						m_DataFiles.PowderList.Export(Writer);

					if (PrimersCheckBox.Checked)
						m_DataFiles.PrimerList.Export(Writer);

					if (CasesCheckBox.Checked)
						m_DataFiles.CaseList.Export(Writer);

					if (LoadsCheckBox.Checked)
						m_DataFiles.LoadList.Export(Writer);

					if (BatchesCheckBox.Checked)
						m_DataFiles.BatchList.Export(Writer);
					}
				}
			catch
				{
				MessageBox.Show("Unable to export data!  Make sure  you have the appropriate permissions for the destination folder.", "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

				fSuccess = false;
				}

			return (fSuccess);
			}

		//============================================================================*
		// ExportFilter Property
		//============================================================================*

		private string ExportFilter
			{
			get
				{
				switch ((cDataFiles.eExportType) FileTypeCombo.SelectedIndex)
					{
					case cDataFiles.eExportType.XML:
						return ("XML Files (*.xml)|*.xml");
					}

				FileTypeCombo.SelectedIndex = 0;

				return ("Comma Delimited Text Files (*.csv)|*.csv");
				}
			}

		//============================================================================*
		// ExportXML()
		//============================================================================*

		public cRWXMLDocument ExportXML()
			{
			cRWXMLDocument XMLDocument = new cRWXMLDocument(m_DataFiles);

			XMLDocument.FullDataDump = FullDataDumpCheckBox.Checked;

			XMLDocument.IncludeAmmo = AmmoCheckBox.Checked;
			XMLDocument.IncludeBatches = BatchesCheckBox.Checked;
			XMLDocument.IncludeBullets = BulletsCheckBox.Checked;
			XMLDocument.IncludeCalibers = CalibersCheckBox.Checked;
			XMLDocument.IncludeCases = CasesCheckBox.Checked;
			XMLDocument.IncludeFirearms = FirearmsCheckBox.Checked;
			XMLDocument.IncludeLoads = LoadsCheckBox.Checked;
			XMLDocument.IncludeManufacturers = ManufacturersCheckBox.Checked;
			XMLDocument.IncludePowders = PowdersCheckBox.Checked;
			XMLDocument.IncludePrimers = PrimersCheckBox.Checked;

			XMLDocument.Export(FullDataDumpCheckBox.Checked);

			return (XMLDocument);
			}

		//============================================================================*
		// OnBrowseClicked()
		//============================================================================*

		private void OnBrowseClicked(Object sender, EventArgs e)
			{
			//----------------------------------------------------------------------------*
			// Show the file dialog
			//----------------------------------------------------------------------------*

			SaveFileDialog FileDlg = new SaveFileDialog();

			FileDlg.Title = String.Format("Export {0} Data Files", Application.ProductName);
			FileDlg.AddExtension = true;
			FileDlg.DefaultExt = Path.GetExtension(m_strFilePath);
			FileDlg.InitialDirectory = Path.GetDirectoryName(m_strFilePath);
			FileDlg.Filter = ExportFilter;
			FileDlg.OverwritePrompt = true;
			FileDlg.FileName = Path.GetFileName(m_strFilePath);

			DialogResult rc = FileDlg.ShowDialog();

			if (rc == DialogResult.Cancel)
				return;

			m_strFilePath = FileDlg.FileName;

			FileNameTextBox.Value = m_strFilePath;
			FileNameLabel.Text = Path.GetFileName(m_strFilePath);

			UpdateButtons();
			}

		//============================================================================*
		// OnExportClicked()
		//============================================================================*

		private void OnExportClicked(Object sender, EventArgs e)
			{
			Export();

			UpdateButtons();
			}

		//============================================================================*
		// OnFileTypeSelected()
		//============================================================================*

		private void OnFileTypeSelected(Object sender, EventArgs e)
			{
			switch ((cDataFiles.eExportType) FileTypeCombo.SelectedIndex)
				{
				case cDataFiles.eExportType.CSV:
					m_strFilePath = Path.ChangeExtension(m_strFilePath, "csv");
					break;

				case cDataFiles.eExportType.XML:
					m_strFilePath = Path.ChangeExtension(m_strFilePath, "xml");
					break;
				}

			SetFileName();

			UpdateButtons();
			}

		//============================================================================*
		// OnFilterClicked()
		//============================================================================*

		private void OnFilterClicked(Object sender, EventArgs e)
			{
			UpdateButtons();
			}

		//============================================================================*
		// SetFileName()
		//============================================================================*

		private void SetFileName()
			{
			FileNameLabel.Text = Path.GetFileName(m_strFilePath);
			FileNameTextBox.Value = m_strFilePath;
			}

		//============================================================================*
		// UpdateButtons()
		//============================================================================*

		private void UpdateButtons()
			{
			bool fOK = true;

			//----------------------------------------------------------------------------*
			// Check File Type
			//----------------------------------------------------------------------------*

			if (FileTypeCombo.SelectedIndex < 0)
				fOK = false;

			//----------------------------------------------------------------------------*
			// Check Full Data Dump Button
			//----------------------------------------------------------------------------*

			XMLPreferencesLabel.Visible = FileTypeCombo.SelectedIndex == 1;
			FullDataDumpCheckBox.Checked = FileTypeCombo.SelectedIndex == 1 ? FullDataDumpCheckBox.Checked : false;
			FullDataDumpCheckBox.Enabled = FileTypeCombo.SelectedIndex == 1;

			if (FullDataDumpCheckBox.Checked)
				{
				ManufacturersCheckBox.Checked = true;
				CalibersCheckBox.Checked = true;
				FirearmsCheckBox.Checked = true;
				PartsCheckBox.Checked = true;

				BulletsCheckBox.Checked = true;
				CasesCheckBox.Checked = true;
				PrimersCheckBox.Checked = true;
				PowdersCheckBox.Checked = true;

				AmmoCheckBox.Checked = true;
				LoadsCheckBox.Checked = true;
				BatchesCheckBox.Checked = true;

				ManufacturersCheckBox.Enabled = false;
				CalibersCheckBox.Enabled = false;
				FirearmsCheckBox.Enabled = false;
				PartsCheckBox.Enabled = false;

				BulletsCheckBox.Enabled = false;
				CasesCheckBox.Enabled = false;
				PrimersCheckBox.Enabled = false;
				PowdersCheckBox.Enabled = false;

				AmmoCheckBox.Enabled = false;
				LoadsCheckBox.Enabled = false;
				BatchesCheckBox.Enabled = false;
				}
			else
				{
				ManufacturersCheckBox.Enabled = true;
				CalibersCheckBox.Enabled = true;
				FirearmsCheckBox.Enabled = true;
				PartsCheckBox.Enabled = true;

				BulletsCheckBox.Enabled = true;
				CasesCheckBox.Enabled = true;
				PrimersCheckBox.Enabled = true;
				PowdersCheckBox.Enabled = true;

				AmmoCheckBox.Enabled = true;
				LoadsCheckBox.Enabled = true;
				BatchesCheckBox.Enabled = true;
				}

			//----------------------------------------------------------------------------*
			// Check Directory
			//----------------------------------------------------------------------------*

			if (fOK)
				{
				if (FileNameTextBox.Value.Length == 0 || !Directory.Exists(Path.GetDirectoryName(m_strFilePath)))
					fOK = false;
				}

			//----------------------------------------------------------------------------*
			// Check Filters
			//----------------------------------------------------------------------------*

			if (!ManufacturersCheckBox.Checked && !CalibersCheckBox.Checked && !FirearmsCheckBox.Checked && !AmmoCheckBox.Checked &&
				!BulletsCheckBox.Checked && !CasesCheckBox.Checked && !PowdersCheckBox.Checked && !PrimersCheckBox.Checked &&
				!LoadsCheckBox.Checked && !BatchesCheckBox.Checked)
				fOK = false;

			//----------------------------------------------------------------------------*
			// Set Button States
			//----------------------------------------------------------------------------*

			ExportButton.Enabled = fOK;
			}
		}
	}
