//============================================================================*
// cTargetCalculatorForm.cs
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
using System.Windows.Forms;

//============================================================================*
// NameSpace
//============================================================================*

namespace ReloadersWorkShop
	{
	//============================================================================*
	// cTargetCalculatorForm Class
	//============================================================================*

	public partial class cTargetCalculatorForm : Form
		{
		//============================================================================*
		// Private Enumerations
		//============================================================================*

		private enum eMode
			{
			LoadTarget = 0,
			Calibrate,
			MarkShots
			};

		//============================================================================*
		// Private Data Members
		//============================================================================*

		private bool m_fInitialized = false;
		private bool m_fChanged = false;

		private eMode m_eMode = eMode.LoadTarget;

		private cDataFiles m_DataFiles = null;

		private string m_strFileName = "";

		private cTarget m_Target = new cTarget();

		//============================================================================*
		// cTargetCalculatorForm()
		//============================================================================*

		public cTargetCalculatorForm(cDataFiles DataFiles)
			{
			InitializeComponent();

			m_DataFiles = DataFiles;

			Initialize();
			}

		//============================================================================*
		// cTargetCalculatorForm()
		//============================================================================*

		public cTargetCalculatorForm(cDataFiles DataFiles, int nBatchID = 0, int nNumShots = 0, int nRange = 100)
			{
			InitializeComponent();

			m_DataFiles = DataFiles;
			m_Target.BatchID = nBatchID;
			m_Target.NumShots = nNumShots;
			m_Target.Range = nRange;

			SetInputData();

			Initialize();
			}

		//============================================================================*
		// GroupSize Property
		//============================================================================*

		private double GroupSize
			{
			get
				{
				return (3.23);
				}
			}

		//============================================================================*
		// Initialize()
		//============================================================================*

		private void Initialize()
			{
			//----------------------------------------------------------------------------*
			// Event Handlers
			//----------------------------------------------------------------------------*

			OpenTargetImageMenuItem.Click += OnOpenTargetImageClicked;

			CaliberCombo.SelectedIndexChanged += OnCaliberSelected;

			TargetImageBox.Click += OnTargetClicked;

			//----------------------------------------------------------------------------*
			// Set Target Size
			//----------------------------------------------------------------------------*

			TargetImageBox.Size = new Size(990, 554);

			SetTargetImageSize();

			//----------------------------------------------------------------------------*
			// Populate Data
			//----------------------------------------------------------------------------*

			SetTitle();

			PopulateCaliberCombo();

			SetInputData();

			SetMode(eMode.LoadTarget);

			//----------------------------------------------------------------------------*
			// Clean up and exit
			//----------------------------------------------------------------------------*

			UpdateButtons();

			m_fInitialized = true;

			OnResize(null);
			}

		//============================================================================*
		// OnCaliberSelected()
		//============================================================================*

		private void OnCaliberSelected(Object sender, EventArgs e)
			{
			if (CaliberCombo.SelectedIndex > 0)
				m_Target.Caliber = (cCaliber) CaliberCombo.SelectedItem;
			else
				m_Target.Caliber = null;

			SetInputData();

			UpdateButtons();
			}

		//============================================================================*
		// OnOpenTargetImageClicked()
		//============================================================================*

		private void OnOpenTargetImageClicked(Object sender, EventArgs e)
			{
			OpenFileDialog OpenTargetDialog = new OpenFileDialog();

			OpenTargetDialog.CheckFileExists = true;
			OpenTargetDialog.CheckPathExists = true;
			OpenTargetDialog.Filter = "Image Files (*.bmp;*.jpg)|*.bmp;*.jpg";
			OpenTargetDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
			OpenTargetDialog.Multiselect = false;
			OpenTargetDialog.Title = "Open Target Image";

			DialogResult rc = OpenTargetDialog.ShowDialog();

			if (rc == DialogResult.OK)
				{
				try
					{
					m_Target.Image = new Bitmap(OpenTargetDialog.FileName);

					TargetImageBox.Image = m_Target.Image;

					SetTargetImageSize();

					SetMode(eMode.Calibrate);

					m_fChanged = true;

					SetTitle();

					UpdateButtons();

					}
				catch
					{
					MessageBox.Show("Unable to open Image File!", "Image File Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}
			}

		//============================================================================*
		// OnResize()
		//============================================================================*

		protected override void OnResize(EventArgs e)
			{
			base.OnResize(e);

			if (!m_fInitialized)
				return;

			OKButton.Location = new Point((ClientRectangle.Width / 2) - OKButton.Width - 20, ClientRectangle.Height - 20 - OKButton.Height);
			TargetCalculatorCancelButton.Location = new Point((ClientRectangle.Width / 2) + 20, ClientRectangle.Height - 20 - TargetCalculatorCancelButton.Height);

			SetTargetImageSize();

			SetMode(m_eMode);
			}

		//============================================================================*
		// OnTargetClicked()
		//============================================================================*

		private void OnTargetClicked(Object sender, EventArgs e)
			{
			switch (m_eMode)
				{
				case eMode.LoadTarget:
					OnOpenTargetImageClicked(sender, e);
					break;

				case eMode.Calibrate:
					break;

				case eMode.MarkShots:
					break;
				}
			}

		//============================================================================*
		// PopulateCaliberCombo()
		//============================================================================*

		private void PopulateCaliberCombo()
			{
			double dMinDiameter = 1.0;
			double dMaxDiameter = 0.0;

			CaliberCombo.Items.Clear();

			CaliberCombo.Items.Add("No Specific Caliber");

			foreach (cCaliber Caliber in m_DataFiles.CaliberList)
				{
				if (m_DataFiles.Preferences.HideUncheckedCalibers || Caliber.Checked)
					CaliberCombo.Items.Add(Caliber);

				if (dMinDiameter > Caliber.MinBulletDiameter)
					dMinDiameter = Caliber.MinBulletDiameter;

				if (dMaxDiameter > Caliber.MaxBulletDiameter)
					dMaxDiameter = Caliber.MaxBulletDiameter;
				}

			if (m_Target.Caliber == null)
				CaliberCombo.SelectedIndex = 0;
			else
				CaliberCombo.SelectedItem = m_Target.Caliber;

			if (CaliberCombo.SelectedIndex < 0)
				CaliberCombo.SelectedIndex = 0;

			BulletDiameterTextBox.MinValue = dMinDiameter;
			BulletDiameterTextBox.MaxValue = dMaxDiameter;
			}


		//============================================================================*
		// SetInputData()
		//============================================================================*

		private void SetInputData()
			{
			RangeTextBox.Value = m_Target.Range;
			TotalShotsLabel.Text = String.Format("{0:G0}", m_Target.NumShots);

			RangeMeasurementLabel.Text = m_DataFiles.MetricLongString(cDataFiles.eDataType.Range);

			RangeTextBox.Enabled = m_Target.BatchID == 0;

			BulletDiameterTextBox.NumDecimals = m_DataFiles.Preferences.DimensionDecimals;

			DiameterMeasurementLabel.Text = m_DataFiles.MetricLongString(cDataFiles.eDataType.Dimension);

			if (m_Target.BatchID == 0)
				{
				if (m_Target.Caliber != null)
					{
					BulletDiameterTextBox.Value = m_Target.Caliber.MinBulletDiameter;

					BulletDiameterTextBox.Enabled = m_Target.Caliber.MinBulletDiameter != m_Target.Caliber.MaxBulletDiameter;
					}
				else
					{
					BulletDiameterTextBox.Value = 0.0;

					BulletDiameterTextBox.Enabled = true;
					}
				}

			SetOutputData();
			}

		//============================================================================*
		// SetMode()
		//============================================================================*

		private void SetMode(eMode eMode)
			{
			m_eMode = eMode;

			if (m_Target.Image == null)
				{
				ModeLabel.ForeColor = Color.Red;
				ModeLabel.Text = "Load a Target Image to continue.";

				m_eMode = eMode.LoadTarget;

				Bitmap MousePointer = new Bitmap(Properties.Resources.OpenTarget);

				IntPtr ptr = MousePointer.GetHicon();

				TargetImageBox.Cursor = new Cursor(ptr);
				}
			else
				{
				ModeLabel.ForeColor = SystemColors.ControlText;
				ModeLabel.Text = "Mode: ";

				switch (m_eMode)
					{
					case eMode.Calibrate:
						ModeLabel.Text += "Calibration";

						TargetImageBox.Cursor = Cursors.Default;

						break;

					default:
						ModeLabel.Text += "Mark Shots";
						break;
					}
				}

			ModeLabel.Location = new Point((ClientRectangle.Width / 2) - (ModeLabel.Width / 2), ModeLabel.Location.Y);
			}

		//============================================================================*
		// SetOutputData()
		//============================================================================*

		private void SetOutputData()
			{
			double dGroupSize = 0.0;
			double dMOA = 0.0;

			if (RangeTextBox.ValueOK && m_Target.NumShots > 1)
				{
				dGroupSize = GroupSize;
				dMOA = GroupSize / ((m_Target.Range / 100.0) * 1.047);
				}

			GroupSizeLabel.Text = String.Format("{0:F3} {1}", dGroupSize, m_DataFiles.MetricLongString(cDataFiles.eDataType.GroupSize));
			MOALabel.Text = String.Format("{0:F3}", dMOA);
			}

		//============================================================================*
		// SetTargetImageSize()
		//============================================================================*

		private void SetTargetImageSize()
			{
			int nY = ModeLabel.Location.Y + ModeLabel.Height + 20;

			int nHeight = ClientRectangle.Height - nY - OKButton.Height - 40;
			int nWidth = (nHeight / 9) * 16;

			if (nWidth > ClientRectangle.Width - 24)
				{
				nWidth = ClientRectangle.Width - 24;
				nHeight = (nWidth / 16) * 9;
				}

			TargetImageBox.Location = new Point((ClientRectangle.Width / 2) - (nWidth / 2), nY);
			TargetImageBox.Size = new Size(nWidth, nHeight);

			double dWidth = TargetImageBox.Image != null ? TargetImageBox.Image.Width : TargetImageBox.Width;
			double dHeight = TargetImageBox.Image != null ? TargetImageBox.Image.Height : TargetImageBox.Height;

			if (dWidth > TargetImageBox.Width || dHeight > TargetImageBox.Height)
				{
				TargetImageBox.SizeMode = PictureBoxSizeMode.StretchImage;

				if (dWidth > TargetImageBox.Width)
					{
					dHeight = dHeight / dWidth;
					dWidth = TargetImageBox.Width;
					dHeight *= dWidth;

					if (dHeight > TargetImageBox.Height)
						{
						dWidth = dWidth / dHeight;
						dHeight = TargetImageBox.Height;
						dWidth *= dHeight;
						}
					}
				else
					{
					dWidth = dWidth / dHeight;
					dHeight = TargetImageBox.Height;
					dWidth *= dHeight;

					if (dWidth > TargetImageBox.Width)
						{
						dHeight = dHeight / dWidth;
						dWidth = TargetImageBox.Width;
						dHeight *= dWidth;
						}
					}

				TargetImageBox.Size = new Size((int) dWidth, (int) dHeight);

				TargetImageBox.Location = new Point((ClientRectangle.Width / 2) - (TargetImageBox.Width / 2), nY);
				}
			else
				{
				TargetImageBox.SizeMode = PictureBoxSizeMode.Normal;

				TargetImageBox.Size = new Size((int) dWidth, (int) dHeight);
				TargetImageBox.Location = new Point((ClientRectangle.Width / 2) - (TargetImageBox.Width / 2), nY + (nHeight / 2) - (TargetImageBox.Height / 2));
				}
			}

		//============================================================================*
		// SetTitle()
		//============================================================================*

		private void SetTitle()
			{
			string strTitle = "Target Calculator - ";

			if (string.IsNullOrEmpty(m_strFileName) && m_Target.BatchID != 0)
				m_strFileName = String.Format("Batch {0:G0} Target File", m_Target.BatchID);

			if (string.IsNullOrEmpty(m_strFileName))
				strTitle += "<Untitled>";
			else
				strTitle += m_strFileName;

			if (m_fChanged)
				strTitle += " *";

			Text = strTitle;
			}

		//============================================================================*
		// UpdateButtons()
		//============================================================================*

		private void UpdateButtons()
			{
			}
		}
	}
