//============================================================================*
// cLoadForm.cs
//
// Copyright © 2013-2014, Kevin S. Beebe
// All Rights Reserved
//============================================================================*

//============================================================================*
// .Net Using Statements
//============================================================================*

using System;
using System.IO;
using System.Windows.Forms;

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
		private string m_strFilePath = @"C:\Users\Public\Reloader's WorkShop\Exported Data\RWData.csv";

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

			LoadsCheckBox.Click += OnLoadsClicked;
			BatchesCheckBox.Click += OnBatchesClicked;

			ManufacturersCheckBox.Click += OnFilterClicked;
			CalibersCheckBox.Click += OnFilterClicked;
			FirearmsCheckBox.Click += OnFilterClicked;
			AmmoCheckBox.Click += OnFilterClicked;

			BulletsCheckBox.Click += OnFilterClicked;
			CasesCheckBox.Click += OnFilterClicked;
			PowdersCheckBox.Click += OnFilterClicked;
			PrimersCheckBox.Click += OnFilterClicked;

			BatchTestsCheckBox.Click += OnFilterClicked;
			ChargeDataCheckBox.Click += OnFilterClicked;

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
				MessageBox.Show("Unable to open export file!  Make sure  you have the appropriate permissions for the destination folder.", "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return;
				}

			bool fExportOK = false;

			if (Writer != null)
				{
				switch ((cDataFiles.eExportType) FileTypeCombo.SelectedIndex)
					{
					case cDataFiles.eExportType.CSV:
						fExportOK = ExportCSV(Writer);
						break;

					case cDataFiles.eExportType.XML:
						fExportOK = ExportXML(Writer);
						break;
					}

				Writer.Close();
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

					Writer.WriteLine("Reloader's WorkShop Data File Export");
					Writer.WriteLine();

					//----------------------------------------------------------------------------*
					// Export Data
					//----------------------------------------------------------------------------*

					if (ManufacturersCheckBox.Checked)
						m_DataFiles.ManufacturerList.Export(Writer, cDataFiles.eExportType.CSV);

					if (CalibersCheckBox.Checked)
						m_DataFiles.CaliberList.Export(Writer, cDataFiles.eExportType.CSV);

					if (FirearmsCheckBox.Checked)
						m_DataFiles.FirearmList.Export(Writer, cDataFiles.eExportType.CSV);

					if (AmmoCheckBox.Checked)
						m_DataFiles.AmmoList.Export(Writer, cDataFiles.eExportType.CSV);

					if (BulletsCheckBox.Checked)
						m_DataFiles.BulletList.Export(Writer, cDataFiles.eExportType.CSV);

					if (CasesCheckBox.Checked)
						m_DataFiles.CaseList.Export(Writer,  cDataFiles.eExportType.CSV);

					if (PrimersCheckBox.Checked)
						m_DataFiles.PrimerList.Export(Writer, cDataFiles.eExportType.CSV);

					if (PowdersCheckBox.Checked)
						m_DataFiles.PowderList.Export(Writer, cDataFiles.eExportType.CSV);

					if (LoadsCheckBox.Checked)
						m_DataFiles.LoadList.Export(Writer, cDataFiles.eExportType.CSV);

					if (BatchesCheckBox.Checked)
						m_DataFiles.BatchList.Export(Writer, cDataFiles.eExportType.CSV, BatchTestsCheckBox.Checked);
					}
				}
			catch
				{
				MessageBox.Show("Unable to export data!  Make sure  you have the appropriate permissions for the destination folder.", "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

				fSuccess = false;
				}

			return(fSuccess);
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

		public bool ExportXML(StreamWriter Writer)
			{
			bool fSuccess = true;

			return (fSuccess);
			}

		//============================================================================*
		// OnBatchesClicked()
		//============================================================================*

		private void OnBatchesClicked(Object sender, EventArgs e)
			{
			BatchTestsCheckBox.Enabled = BatchesCheckBox.Checked;

			UpdateButtons();
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

			FileDlg.Title = "Export Reloader's WorkShop Data Files";
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
		// OnFilterClicked()
		//============================================================================*

		private void OnFilterClicked(Object sender, EventArgs e)
			{
			UpdateButtons();
			}

		//============================================================================*
		// OnLoadsClicked()
		//============================================================================*

		private void OnLoadsClicked(Object sender, EventArgs e)
			{
			ChargeDataCheckBox.Enabled = LoadsCheckBox.Checked;

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
