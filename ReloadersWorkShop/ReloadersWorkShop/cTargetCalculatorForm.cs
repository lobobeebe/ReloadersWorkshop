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

using CommonLib.Conversions;

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
			AimPoint,
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

		private Bitmap m_TargetImage = null;

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
		// CreateReticleBitmap()
		//============================================================================*

		private Bitmap CreateReticleBitmap()
			{
			if (m_Target.PixelsPerInch < 7)
				return (null);

			Bitmap ReticleBitmap = new Bitmap(m_Target.PixelsPerInch, m_Target.PixelsPerInch);

			Graphics g = Graphics.FromImage(ReticleBitmap);

			GraphicsUnit eGraphicsUnit = GraphicsUnit.Pixel;
			RectangleF ShotRect = ReticleBitmap.GetBounds(ref eGraphicsUnit);
			ShotRect.Width -= 3;
			ShotRect.Height -= 3;

			Pen ReticlePen = new Pen(Brushes.Black, 3);

			g.DrawEllipse(ReticlePen, ShotRect);

			int x = ReticleBitmap.Width / 2;
			int y = 3;
			int x1 = x;
			int y1 = y + ReticleBitmap.Height - 6;

			g.DrawLine(Pens.Black, x, y, x1, y1);

			x = 3;
			y = ReticleBitmap.Height / 2;
			x1 = x + ReticleBitmap.Width - 6;
			y1 = y;

			g.DrawLine(Pens.Black, x, y, x1, y1);

			return (ReticleBitmap);
			}

		//============================================================================*
		// CreateShotBitmap()
		//============================================================================*

		private Bitmap CreateShotBitmap()
			{
			if (m_Target.BulletPixels == 0 || m_Target.BulletDiameter < 0.017)
				return (null);

			Bitmap ShotBitmap = new Bitmap(m_Target.BulletPixels, m_Target.BulletPixels);

			Graphics g = Graphics.FromImage(ShotBitmap);

			GraphicsUnit eGraphicsUnit = GraphicsUnit.Pixel;
			RectangleF ShotRect = ShotBitmap.GetBounds(ref eGraphicsUnit);
			ShotRect.Width--;
			ShotRect.Height--;

			g.DrawEllipse(Pens.White, ShotRect);

			int x = ShotBitmap.Width / 2;
			int y = ShotBitmap.Height / 4;
			int x1 = x;
			int y1 = y + ShotBitmap.Height / 2;

			g.DrawLine(Pens.White, x, y, x1, y1);

			x = ShotBitmap.Width / 4;
			y = ShotBitmap.Height / 2;
			x1 = x + ShotBitmap.Width / 2;
			y1 = y;

			g.DrawLine(Pens.White, x, y, x1, y1);

			return (ShotBitmap);
			}

		//============================================================================*
		// CreateTargetImage()
		//============================================================================*

		private void CreateTargetImage()
			{
			if (m_Target.Image == null)
				{
				m_TargetImage = null;

				return;
				}

			m_TargetImage = new Bitmap(TargetImageBox.Width, TargetImageBox.Height);

			Graphics g = Graphics.FromImage(m_TargetImage);

			g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

			g.DrawImage(m_Target.Image, 0, 0, m_TargetImage.Width, m_TargetImage.Height);
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

			FileNewMenuItem.Click += OnFileNew;
			FileOpenTargetImageMenuItem.Click += OnFileOpenTargetImage;

			CaliberCombo.SelectedIndexChanged += OnCaliberSelected;
			RangeTextBox.TextChanged += OnRangeChanged;

			//			TargetImageBox.Click += OnTargetClicked;
			TargetImageBox.MouseClick += OnTargetMouseClick;
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
		// OnCaliberSelected()
		//============================================================================*

		private void OnCaliberSelected(Object sender, EventArgs e)
			{
			if (CaliberCombo.SelectedIndex >= 0)
				m_Target.Caliber = (cCaliber) CaliberCombo.SelectedItem;
			else
				m_Target.Caliber = null;

			SetInputData();

			SetImage();

			SetTargetCursor();

			UpdateButtons();
			}

		//============================================================================*
		// OnFileNew()
		//============================================================================*

		private void OnFileNew(Object sender, EventArgs e)
			{
			m_Target.Image = null;
			m_Target.CalibrationStart = new Point(0, 0);
			m_Target.CalibrationEnd = new Point(0, 0);
			m_Target.CalibrationLength = 0.0;

			SetImage();

			SetMode(eMode.LoadTarget);

			SetOutputData();
			}

		//============================================================================*
		// OnFileOpenTargetImage()
		//============================================================================*

		private void OnFileOpenTargetImage(Object sender, EventArgs e)
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

					CreateTargetImage();

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
		// OnRangeChanged()
		//============================================================================*

		private void OnRangeChanged(Object sender, EventArgs e)
			{
			m_Target.Range = (int) m_DataFiles.MetricToStandard(RangeTextBox.Value, cDataFiles.eDataType.Range);

			SetOutputData();

			UpdateButtons();
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

			CreateTargetImage();

			SetImage();

			SetMode(m_eMode);
			}

		//============================================================================*
		// OnTargetMouseClick()
		//============================================================================*

		private void OnTargetMouseClick(Object sender, MouseEventArgs e)
			{
			switch (m_eMode)
				{
				case eMode.LoadTarget:
					OnFileOpenTargetImage(sender, e);
					break;

				case eMode.Calibrate:
					break;

				case eMode.AimPoint:
					Point AimPoint = new Point(e.X, e.Y);
					AimPoint.X -= TargetImageBox.Cursor.HotSpot.X;
					AimPoint.Y -= TargetImageBox.Cursor.HotSpot.Y;

					m_Target.AimPoint = AimPoint;

					SetMode(eMode.MarkShots);

					break;

				case eMode.MarkShots:
					Point Shot = new Point(e.X, e.Y);

					if (!m_Target.AddShot(Shot))
						{
						Console.Beep(1000, 1000);
						}
					else
						{
						SetImage();

						SetNumShotsLabel();

						SetOutputData();
						}

					break;
				}

			UpdateButtons();
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
					SetMode(eMode.AimPoint);
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
			CaliberCombo.Items.Clear();

			if (m_Batch == null)
				{
				foreach (cCaliber Caliber in m_DataFiles.CaliberList)
					{
					if (m_DataFiles.Preferences.HideUncheckedCalibers || Caliber.Checked)
						CaliberCombo.Items.Add(Caliber);
					}

				if (CaliberCombo.Items.Count > 0)
					{
					if (m_Target.Caliber == null)
						CaliberCombo.SelectedIndex = 0;
					else
						CaliberCombo.SelectedItem = m_Target.Caliber;

					if (CaliberCombo.SelectedIndex < 0)
						CaliberCombo.SelectedIndex = 0;
					}
				}
			else
				{
				CaliberCombo.Items.Add(m_Batch.Load.Caliber);

				CaliberCombo.SelectedIndex = 0;
				}

			if (CaliberCombo.SelectedIndex >= 0)
				{
				cCaliber Caliber = (cCaliber) CaliberCombo.SelectedItem;

				if (Caliber != null)
					m_Target.Caliber = Caliber;
				}
			}

		//============================================================================*
		// SetImage()
		//============================================================================*

		private void SetImage()
			{
			if (m_TargetImage == null)
				{
				TargetImageBox.Image = null;

				return;
				}

			//----------------------------------------------------------------------------*
			// Set the image
			//----------------------------------------------------------------------------*

			Bitmap TargetImage = new Bitmap(m_TargetImage);

			TargetImageBox.Image = TargetImage;

			Graphics g = Graphics.FromImage(TargetImage);

			//----------------------------------------------------------------------------*
			// Draw Calibration Line
			//----------------------------------------------------------------------------*

			if (m_Target.CalibrationPixels > 0)
				{
				Pen LinePen = null;

				switch (m_eMode)
					{
					case eMode.Calibrate:
						LinePen = new Pen(m_Target.CalibrationPixels < m_Target.MinCalibrationPixels ? Brushes.Red : Brushes.Green, 3);

						g.DrawLine(LinePen, m_Target.CalibrationStart, m_Target.CalibrationEnd);

						break;

					default:
						break;
					}
				}

			//----------------------------------------------------------------------------*
			// Draw Shots
			//----------------------------------------------------------------------------*

			if (m_Target.ShotList.Count > 0)
				{
				Bitmap ShotBitmap = CreateShotBitmap();

				foreach (Point Shot in m_Target.ShotList)
					{
					int x = Shot.X - ShotBitmap.Width / 2;
					int y = Shot.Y - ShotBitmap.Height / 2;

					g.DrawImage(ShotBitmap, x, y);
					}
				}
			}

		//============================================================================*
		// SetInputData()
		//============================================================================*

		private void SetInputData()
			{
			RangeTextBox.Value = m_Target.Range;
			RangeMeasurementLabel.Text = m_DataFiles.MetricLongString(cDataFiles.eDataType.Range);

			RangeTextBox.Enabled = m_Batch == null;

			double dBulletDiameter = 0.0;

			if (m_Batch == null)
				{
				if (m_Target.Caliber != null)
					dBulletDiameter = m_Target.Caliber.MinBulletDiameter;
				}
			else
				dBulletDiameter = m_Batch.BulletDiameter;

			string strDimensionFormat = "{0:F";
			strDimensionFormat += String.Format("{0:G0}", m_DataFiles.Preferences.DimensionDecimals);
			strDimensionFormat += "} ";
			strDimensionFormat += m_DataFiles.MetricString(cDataFiles.eDataType.Dimension);

			BulletDiameterLabel.Text = String.Format(strDimensionFormat, dBulletDiameter);

			SetNumShotsLabel();

			SetOutputData();
			}

		//============================================================================*
		// SetInputParameters()
		//============================================================================*

		private void SetInputParameters()
			{
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
				m_eMode = eMode.LoadTarget;
				}

			SetImage();

			SetModeLabel();

			SetTargetCursor();

			UpdateButtons();
			}

		//============================================================================*
		// SetModeLabel()
		//============================================================================*

		private void SetModeLabel()
			{
			ModeLabel.ForeColor = SystemColors.ControlText;
			ModeLabel.Text = "Mode: ";

			switch (m_eMode)
				{
				case eMode.LoadTarget:
					ModeLabel.Text += "Load Target Image";

					break;

				case eMode.Calibrate:
					ModeLabel.Text += "Calibration";

					TargetImageBox.Cursor = Cursors.Default;

					break;

				case eMode.AimPoint:
					ModeLabel.Text += "Mark Aim Point";

					break;

				default:
					ModeLabel.Text += "Mark Shots";
					break;
				}

//			ModeLabel.Location = new Point((ClientRectangle.Width / 2) - (ModeLabel.Width / 2), ModeLabel.Location.Y);
			}

		//============================================================================*
		// SetNumShotsLabel()
		//============================================================================*

		private void SetNumShotsLabel()
			{
			string strText = String.Format("{0:G0}", m_Target.ShotList.Count);

			if (m_Target.BatchID != 0)
				strText += String.Format(" of {0:G0}", m_Target.NumShots);

			TotalShotsLabel.Text = strText;
			}

		//============================================================================*
		// SetOutputData()
		//============================================================================*

		private void SetOutputData()
			{
			double dGroupSize = 0.0;
			double dMOA = 0.0;
			double dMils = 0.0;

			//----------------------------------------------------------------------------*
			// Group Size
			//----------------------------------------------------------------------------*

			if (RangeTextBox.ValueOK)
				{
				dGroupSize = m_Target.GroupSize;
				dMOA = dGroupSize / ((m_Target.Range / 100.0) * 1.047);
				dMils = cConversions.MOAToMils(dMOA);
				}

			string strGroupFormat = "{0:F";
			strGroupFormat += String.Format("{0:G0}", m_DataFiles.Preferences.GroupDecimals);
			strGroupFormat += "} {1}";

			GroupSizeLabel.Text = String.Format(strGroupFormat, dGroupSize, m_DataFiles.MetricString(cDataFiles.eDataType.GroupSize));
			MOALabel.Text = String.Format("{0:F3}", dMOA);
			MilsLabel.Text = String.Format("{0:F3}", dMils);

			string strOffset = String.Format(strGroupFormat, Math.Abs(m_Target.MeanOffset.X), m_DataFiles.MetricString(cDataFiles.eDataType.GroupSize));

			if (m_Target.MeanOffset.X == 0)
				strOffset += " Horizontal";
			else
				{
				if (m_Target.MeanOffset.X < 0)
					strOffset += " Left";
				else
					strOffset += " Right";
				}

			strOffset += " - ";

			strOffset += String.Format(strGroupFormat, Math.Abs(m_Target.MeanOffset.Y), m_DataFiles.MetricString(cDataFiles.eDataType.GroupSize));

			if (m_Target.MeanOffset.Y == 0)
				strOffset += " Vertical";
			else
				{
				if (m_Target.MeanOffset.Y > 0)
					strOffset += " High";
				else
					strOffset += " Low";
				}

			OffsetLabel.Text = strOffset;
			}

		//============================================================================*
		// SetTargetCursor()
		//============================================================================*

		private void SetTargetCursor()
			{
			Bitmap MousePointer = null;
			IntPtr ptr;

			switch (m_eMode)
				{
				case eMode.LoadTarget:
					MousePointer = new Bitmap(Properties.Resources.OpenTarget);

					ptr = MousePointer.GetHicon();

					TargetImageBox.Cursor = new Cursor(ptr);

					break;

				case eMode.AimPoint:
					MousePointer = CreateReticleBitmap();

					ptr = MousePointer.GetHicon();

					TargetImageBox.Cursor = new Cursor(ptr);

					break;

				case eMode.MarkShots:
					MousePointer = CreateShotBitmap();

					ptr = MousePointer.GetHicon();

					TargetImageBox.Cursor = new Cursor(ptr);

					break;

				default:
					TargetImageBox.Cursor = Cursors.Default;
					break;
				}
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

			if (!RangeTextBox.ValueOK || CaliberCombo.SelectedIndex < 0)
				{
				ModeLabel.ForeColor = Color.Red;

				ModeLabel.Text = "Enter valid Input Data above to continue.";

				TargetImageBox.Enabled = false;
				}
			else
				{
				SetModeLabel();

				TargetImageBox.Enabled = true;
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
