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

		private cBatch m_Batch = null;

		private bool m_fMouseDown = false;

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

			Initialize();
			}

		//============================================================================*
		// GroupSize Property
		//============================================================================*

		private double GroupSize
			{
			get
				{
				return (m_Target.GroupSize);
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
			BulletDiameterTextBox.TextChanged += OnBulletDiameterChanged;

			TargetImageBox.Click += OnTargetClicked;
			TargetImageBox.MouseDown += OnTargetMouseDown;
			TargetImageBox.MouseUp += OnTargetMouseUp;
			TargetImageBox.MouseMove += OnTargetMouseMove;

			//----------------------------------------------------------------------------*
			// Set Target Size
			//----------------------------------------------------------------------------*

			TargetImageBox.Size = new Size(990, 554);

			SetTargetImageSize();

			//----------------------------------------------------------------------------*
			// Populate Data
			//----------------------------------------------------------------------------*

			if (m_Target.BatchID != 0)
				m_Batch = m_DataFiles.GetBatchByID(m_Target.BatchID);
			else
				m_Batch = null;

			SetTitle();

			PopulateCaliberCombo();

			SetInputParameters();

			SetInputData();

			SetMode(eMode.LoadTarget);

			SetTargetImageSize();

			//----------------------------------------------------------------------------*
			// Clean up and exit
			//----------------------------------------------------------------------------*

			UpdateButtons();

			m_fInitialized = true;

			OnResize(null);
			}

		//============================================================================*
		// OnBulletDiameterChanged()
		//============================================================================*

		private void OnBulletDiameterChanged(Object sender, EventArgs e)
			{
			m_Target.BulletDiameter = BulletDiameterTextBox.Value;

			SetOutputData();

			UpdateButtons();
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

					if (m_Target.Image.Width < m_Target.MinImageWidth || m_Target.Image.Height < m_Target.MinImageHeight)
						{
						string strMessage = String.Format("Target image must be at least {0:G0} x {1:G0} pixels in size", m_Target.MinImageWidth, m_Target.MinImageHeight);

						MessageBox.Show(strMessage, "Invalid Target Image", MessageBoxButtons.OK, MessageBoxIcon.Information);

						m_Target.Image = null;

						return;
						}

					SetTargetImageSize();

					SetImage();

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
		// OnTargetMouseDown()
		//============================================================================*

		private void OnTargetMouseDown(Object sender, MouseEventArgs e)
			{
			if (m_eMode != eMode.Calibrate)
				return;

			m_fMouseDown = true;

			m_Target.CalibrationStart = e.Location;
			m_Target.CalibrationEnd = e.Location;

			SetImage();
			}

		//============================================================================*
		// OnTargetMouseMove()
		//============================================================================*

		private void OnTargetMouseMove(Object sender, MouseEventArgs e)
			{
			if (m_eMode != eMode.Calibrate || !m_fMouseDown)
				return;

			m_Target.CalibrationEnd = e.Location;

			SetImage();
			}

		//============================================================================*
		// OnTargetMouseUp()
		//============================================================================*

		private void OnTargetMouseUp(Object sender, MouseEventArgs e)
			{
			if (m_eMode != eMode.Calibrate || !m_fMouseDown)
				return;

			m_fMouseDown = false;

			m_Target.CalibrationEnd = e.Location;

			SetImage();

			//----------------------------------------------------------------------------*
			// Get Calibration Line Length
			//----------------------------------------------------------------------------*

			if (m_Target.CalibrationPixels < m_Target.MinCalibrationPixels)
				{
				string strMsg = string.Format("Your calibration line is only {0:N0} pixels long.  You must mark a line of at least {1:N0} pixels.\n\nTry again.", m_Target.CalibrationPixels, m_Target.MinCalibrationPixels);

				MessageBox.Show(strMsg, "Invalid Calibration Line", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

				m_Target.CalibrationStart = new Point(0, 0);
				m_Target.CalibrationEnd = new Point(0, 0);
				m_Target.CalibrationLength = 0.0;
				}
			else
				{
				cTargetCalibrationForm CalibrationForm = new cTargetCalibrationForm(m_DataFiles, m_Target);

				DialogResult rc = CalibrationForm.ShowDialog();

				if (rc == DialogResult.OK)
					{
					SetMode(eMode.MarkShots);
					}
				else
					{
					m_Target.CalibrationStart = new Point(0, 0);
					m_Target.CalibrationEnd = new Point(0, 0);
					m_Target.CalibrationLength = 0.0;
					}
				}

			SetImage();
			}

		//============================================================================*
		// PopulateCaliberCombo()
		//============================================================================*

		private void PopulateCaliberCombo()
			{
			double dMinDiameter = 1.0;
			double dMaxDiameter = 0.0;

			CaliberCombo.Items.Clear();

			if (m_Batch == null)
				{
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
			else
				{
				CaliberCombo.Items.Add(m_Batch.Load.Caliber);

				CaliberCombo.SelectedIndex = 0;
				}
			}

		//============================================================================*
		// SetImage()
		//============================================================================*

		private void SetImage()
			{
			if (m_Target.Image == null)
				return;

			//----------------------------------------------------------------------------*
			// Create a new bitmap for drawing
			//----------------------------------------------------------------------------*

			Bitmap TargetImage = new Bitmap(TargetImageBox.Width, TargetImageBox.Height);

			Graphics g = Graphics.FromImage(TargetImage);

			g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

			g.DrawImage(m_Target.Image, 0, 0, TargetImage.Width, TargetImage.Height);

			//----------------------------------------------------------------------------*
			// Set the image
			//----------------------------------------------------------------------------*

			TargetImageBox.Image = TargetImage;

			//----------------------------------------------------------------------------*
			// Draw Calibration Line
			//----------------------------------------------------------------------------*

			if (m_eMode == eMode.Calibrate && m_Target.CalibrationPixels > 0)
				{
				Pen LinePen = new Pen(m_Target.CalibrationPixels < m_Target.MinCalibrationPixels ? Brushes.Red : Brushes.Green, 3);

				g.DrawLine(LinePen, m_Target.CalibrationStart, m_Target.CalibrationEnd);

				g.DrawString(String.Format("{0:G0}", m_Target.CalibrationPixels), SystemFonts.DefaultFont, Brushes.White, new Point(10, 10));
				}
			}

		//============================================================================*
		// SetInputData()
		//============================================================================*

		private void SetInputData()
			{
			RangeTextBox.Value = m_Target.Range;
			TotalShotsLabel.Text = String.Format("{0:G0}", m_Target.NumShots);

			RangeMeasurementLabel.Text = m_DataFiles.MetricLongString(cDataFiles.eDataType.Range);

			RangeTextBox.Enabled = m_Batch == null;

			BulletDiameterTextBox.NumDecimals = m_DataFiles.Preferences.DimensionDecimals;

			DiameterMeasurementLabel.Text = m_DataFiles.MetricLongString(cDataFiles.eDataType.Dimension);

			if (m_Batch == null)
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
			else
				{
				BulletDiameterTextBox.Value = m_Batch.BulletDiameter;

				BulletDiameterTextBox.Enabled = false;
				}

			SetOutputData();
			}

		//============================================================================*
		// SetInputParameters()
		//============================================================================*

		private void SetInputParameters()
			{
			m_DataFiles.SetInputParameters(BulletDiameterTextBox, cDataFiles.eDataType.Dimension);
			m_DataFiles.SetInputParameters(RangeTextBox, cDataFiles.eDataType.Range);
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

			SetImage();

			UpdateButtons();
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

			string strGroupFormat = "{0:F";
			strGroupFormat += String.Format("{0:G0}", m_DataFiles.Preferences.GroupDecimals);
			strGroupFormat += "} {1}";

			GroupSizeLabel.Text = String.Format(strGroupFormat, dGroupSize, m_DataFiles.MetricLongString(cDataFiles.eDataType.GroupSize));
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
			bool fEnableOK = m_fChanged;

			if (!RangeTextBox.ValueOK || !BulletDiameterTextBox.ValueOK)
				{
				ModeLabel.Text = "Enter valid Input Data above to continue.";

				TargetImageBox.Enabled = false;
				}
			else
				{
				}

			if (fEnableOK)
				{
				if (m_Target.Image == null || !m_Target.Calibrated || m_Target.ShotList.Count < 2)
					fEnableOK = false;
				}

			OKButton.Enabled = fEnableOK;
			}
		}
	}
