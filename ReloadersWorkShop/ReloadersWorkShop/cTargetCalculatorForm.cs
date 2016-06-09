//============================================================================*
// cTargetCalculatorForm.cs
//
// Copyright © 2016, Kevin S. Beebe
// All Rights Reserved
//============================================================================*

//============================================================================*
// .Net Using Statements
//============================================================================*

using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using WIA;

using RWCommonLib.Registry;

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
        private bool m_fBatchTest = false;

        private eMode m_eMode = eMode.LoadTarget;

        private cDataFiles m_DataFiles = null;
        private cRWRegistry m_RWRegistry = null;
        private cBatchTest m_BatchTest = null;

        private string m_strFileName = "";

        private cTarget m_Target = null;

        private bool m_fMouseDown = false;

        private Bitmap m_TargetImage = null;
        private Bitmap m_ScaleBar = null;
        private Bitmap m_AimPoint = null;
        private Bitmap m_AimPointOffset = null;

        private string m_strFolder = null;

        private Bitmap m_MousePointer = null;

        //============================================================================*
        // cTargetCalculatorForm()
        //============================================================================*

        public cTargetCalculatorForm(cDataFiles DataFiles, cRWRegistry RWRegistry)
            {
            InitializeComponent();

            m_DataFiles = DataFiles;
            m_RWRegistry = RWRegistry;

            m_fBatchTest = false;

            Initialize();
            }

        //============================================================================*
        // cTargetCalculatorForm()
        //============================================================================*

        public cTargetCalculatorForm(cDataFiles DataFiles, cRWRegistry RWRegistry, cBatchTest BatchTest = null)
            {
            InitializeComponent();

            m_DataFiles = DataFiles;
            m_RWRegistry = RWRegistry;

            m_BatchTest = BatchTest;

            Initialize();
            }

        //============================================================================*
        // CreateAimPointBitmap()
        //============================================================================*

        private Bitmap CreateAimPointBitmap()
            {
            return (CreateAimPointBitmap(m_Target.AimPointColor));
            }

        //============================================================================*
        // CreateAimPointOffsetBitmap()
        //============================================================================*

        private Bitmap CreateAimPointOffsetBitmap()
            {
            return (CreateAimPointBitmap(m_Target.OffsetColor));
            }

        //============================================================================*
        // CreateAimPointBitmap()
        //============================================================================*

        private Bitmap CreateAimPointBitmap(Color AimPointColor)
            {
            if (m_Target.AimPoint == Point.Empty)
                return (null);

            Bitmap AimPoint = new Bitmap((int) (m_Target.PixelsPerInch * 0.75), (int) (m_Target.PixelsPerInch * 0.75));

            Pen AimPointPen = new Pen(AimPointColor, 3.0f);

            Graphics g = Graphics.FromImage(AimPoint);

            int nX = AimPoint.Width / 2;
            int nX1 = nX;
            int nY = m_Target.PixelsPerInch / 8;
            int nY1 = nY + m_Target.PixelsPerInch / 8;

            g.DrawLine(AimPointPen, nX, nY, nX1, nY1);

            nY = nY1 + m_Target.PixelsPerInch / 4;
            nY1 = nY + m_Target.PixelsPerInch / 8;

            g.DrawLine(AimPointPen, nX, nY, nX1, nY1);

            nX = m_Target.PixelsPerInch / 8;
            nX1 = nX + m_Target.PixelsPerInch / 8;
            nY = AimPoint.Height / 2;
            nY1 = nY;

            g.DrawLine(AimPointPen, nX, nY, nX1, nY1);

            nX = nX1 + m_Target.PixelsPerInch / 4;
            nX1 = nX + m_Target.PixelsPerInch / 8;

            g.DrawLine(AimPointPen, nX, nY, nX1, nY1);

            g.DrawLine(AimPointPen, (AimPoint.Width / 2) - (m_Target.PixelsPerInch / 16), (AimPoint.Height / 2), (AimPoint.Width / 2) + (m_Target.PixelsPerInch / 16), (AimPoint.Height / 2));
            g.DrawLine(AimPointPen, (AimPoint.Width / 2), (AimPoint.Height / 2) - (m_Target.PixelsPerInch / 16), (AimPoint.Width / 2), (AimPoint.Height / 2) + (m_Target.PixelsPerInch / 16));

            return (AimPoint);
            }

        //============================================================================*
        // CreateReticleBitmap()
        //============================================================================*

        private Bitmap CreateReticleBitmap()
            {
            if (m_Target.PixelsPerInch < 7)
                return (null);

            Bitmap ReticleBitmap = new Bitmap(m_Target.PixelsPerInch, m_Target.PixelsPerInch, PixelFormat.Format32bppArgb);

            Graphics g = Graphics.FromImage(ReticleBitmap);

            g.FillRectangle(Brushes.AliceBlue, 0, 0, m_Target.PixelsPerInch, m_Target.PixelsPerInch);

            GraphicsUnit eGraphicsUnit = GraphicsUnit.Pixel;
            RectangleF ShotRect = ReticleBitmap.GetBounds(ref eGraphicsUnit);
            ShotRect.Width -= 3;
            ShotRect.Height -= 3;

            Pen ReticlePen = new Pen(m_Target.m_ReticleColor, 2);

            g.DrawEllipse(ReticlePen, ShotRect);

            int x = ReticleBitmap.Width / 2;
            int y = 0;
            int x1 = x;
            int y1 = ReticleBitmap.Height;

            Pen CrosshairPen = new Pen(m_Target.m_ReticleColor, 1);

            g.DrawLine(CrosshairPen, x, y, x1, y1);

            y1 = y + (int) (m_Target.PixelsPerInch * 0.35);

            g.DrawLine(ReticlePen, x, y, x1, y1);

            y = y1 + (int) (m_Target.PixelsPerInch * 0.3);
            y1 = ReticleBitmap.Height;

            g.DrawLine(ReticlePen, x, y, x1, y1);

            x = 3;
            y = ReticleBitmap.Height / 2;
            x1 = x + ReticleBitmap.Width;
            y1 = y;

            g.DrawLine(CrosshairPen, x, y, x1, y1);

            x1 = (int) (m_Target.PixelsPerInch * 0.35);

            g.DrawLine(ReticlePen, x, y, x1, y1);

            x = x1 + (int) (m_Target.PixelsPerInch * 0.3);
            x1 = ReticleBitmap.Width;

            g.DrawLine(ReticlePen, x, y, x1, y1);

            ReticleBitmap.MakeTransparent(Color.AliceBlue);

            return (ReticleBitmap);
            }

        //============================================================================*
        // CreateScaleBar()
        //============================================================================*

        private Bitmap CreateScaleBar()
            {
            if (!m_Target.Calibrated)
                return (null);

            Font BarFont = new Font(SystemFonts.DefaultFont, FontStyle.Bold);

            Bitmap CalibrationBar = new Bitmap(m_TargetImage.Width, (int) ((double) BarFont.Height * 4.5));

            Graphics g = Graphics.FromImage(CalibrationBar);

            SolidBrush BarBrush = new SolidBrush(m_Target.ScaleBackcolor);
            SolidBrush BarForeBrush = new SolidBrush(m_Target.ScaleForecolor);

            g.FillRectangle(BarBrush, 0, 0, CalibrationBar.Width, CalibrationBar.Height);

            int nY = CalibrationBar.Height;

            string strMeasurement = m_DataFiles.MetricString(cDataFiles.eDataType.GroupSize);

            SizeF StartSizeF = g.MeasureString("MMM", BarFont);
            SizeF CharSizeF = g.MeasureString(m_DataFiles.MetricString(cDataFiles.eDataType.GroupSize), BarFont);

            g.DrawString(m_DataFiles.MetricString(cDataFiles.eDataType.GroupSize), BarFont, BarForeBrush, (int) (StartSizeF.Width / 2) - (int) (CharSizeF.Width / 2), CalibrationBar.Height / 2);
            /*
						CharSizeF = g.MeasureString(new string(strMeasurement[1], 1), BarFont);

						g.DrawString(new string(strMeasurement[1], 1), BarFont, BarForeBrush, (int) (StartSizeF.Width / 2) - (int) (CharSizeF.Width / 2), CalibrationBar.Height / 2);
			*/
            //----------------------------------------------------------------------------*
            // Metric Scale Bar
            //----------------------------------------------------------------------------*

            if (m_DataFiles.Preferences.MetricGroups)
                {
                int nIncrements = CalibrationBar.Width / (m_Target.PixelsPerCentimeter / 10);

                for (int i = 0; i <= nIncrements; i++)
                    {
                    int nX = (int) StartSizeF.Width + (i * (m_Target.PixelsPerCentimeter / 10));
                    int nY1 = nY - BarFont.Height;

                    if (i % 10 == 0)
                        {
                        nY1 -= (BarFont.Height * 2);

                        g.DrawLine(Pens.Black, nX, nY, nX, nY1);

                        nY1 -= BarFont.Height;

                        string strText = String.Format("{0:G0}", i / 10);

                        SizeF FontSize = g.MeasureString(strText, BarFont);

                        g.DrawString(strText, BarFont, BarForeBrush, nX - (FontSize.Width / 2), nY1);
                        }
                    else
                        {
                        g.DrawLine(Pens.Black, nX, nY, nX, nY1);
                        }
                    }
                }

            //----------------------------------------------------------------------------*
            // Standard Scale Bar
            //----------------------------------------------------------------------------*

            else
                {
                int nIncrements = CalibrationBar.Width / (m_Target.PixelsPerInch / 4);

                for (int i = 0; i <= nIncrements; i++)
                    {
                    int nX = (int) StartSizeF.Width + (i * (m_Target.PixelsPerInch / 4));
                    int nY1 = nY - BarFont.Height;

                    if (i % 4 == 0)
                        {
                        nY1 -= (BarFont.Height * 2);

                        g.DrawLine(Pens.Black, nX, nY, nX, nY1);

                        nY1 -= BarFont.Height;

                        string strText = String.Format("{0:G0}", i / 4);

                        SizeF FontSize = g.MeasureString(strText, BarFont);

                        g.DrawString(strText, BarFont, BarForeBrush, nX - (FontSize.Width / 2), nY1);
                        }
                    else
                        {
                        if (i % 2 == 0)
                            {
                            nY1 -= BarFont.Height;

                            g.DrawLine(Pens.Black, nX, nY, nX, nY1);
                            }
                        else
                            {
                            g.DrawLine(Pens.Black, nX, nY, nX, nY1);
                            }
                        }
                    }
                }

            return (CalibrationBar);
            }

        //============================================================================*
        // CreateShotBitmap()
        //============================================================================*

        private Bitmap CreateShotBitmap(bool fPointer = false)
            {
            if (m_Target.AimPoint == Point.Empty)
                return (null);

            if (m_Target.BulletPixels == 0 || m_Target.BulletDiameter < 0.017)
                return (null);

            Bitmap ShotBitmap = new Bitmap(m_Target.BulletPixels, m_Target.BulletPixels);

            Graphics g = Graphics.FromImage(ShotBitmap);

            GraphicsUnit eGraphicsUnit = GraphicsUnit.Pixel;
            RectangleF ShotRect = ShotBitmap.GetBounds(ref eGraphicsUnit);
            ShotRect.Width--;
            ShotRect.Height--;

            if (!fPointer && ShowShotNumCheckBox.Checked)
                {
                SolidBrush ShotBrush = new SolidBrush(m_Target.ShotColor);
                Pen ShotPen = new Pen(m_Target.ShotForecolor, 2.0f);

                g.FillEllipse(ShotBrush, ShotRect);
                g.DrawEllipse(ShotPen, ShotRect);
                }
            else
                {
                Pen ShotPen = new Pen(m_Target.ShotColor, 1.0f);
                Pen ShotPen2 = new Pen(m_Target.ShotColor, 2.0f);

                g.DrawEllipse(ShotPen2, ShotRect);

                int x = ShotBitmap.Width / 2;
                int y = ShotBitmap.Height / 4;
                int x1 = x;
                int y1 = y + ShotBitmap.Height / 2;

                g.DrawLine(ShotPen, x, y, x1, y1);

                x = ShotBitmap.Width / 4;
                y = ShotBitmap.Height / 2;
                x1 = x + ShotBitmap.Width / 2;
                y1 = y;

                g.DrawLine(ShotPen, x, y, x1, y1);
                }

            return (ShotBitmap);
            }

        //============================================================================*
        // FitImage()
        //============================================================================*

        private void FitImage()
            {
            int nY = ModeLabel.Location.Y + ModeLabel.Height + 20;

            double dMaxHeight = ClientRectangle.Height - nY - OKButton.Height - 40;
            double dMaxWidth = (dMaxHeight / 9.0) * 16.0;

            double dHeight = dMaxHeight;
            double dWidth = dMaxWidth;

            if (dWidth > ClientRectangle.Width - 24)
                {
                dWidth = ClientRectangle.Width - 24;
                dHeight = (dWidth / 16.0) * 9.0;
                }

            if (m_Target.Image != null)
                {
                dWidth = m_Target.Image.Width;
                dHeight = m_Target.Image.Height;

                if (dWidth > 984 || dHeight > 519)
                    {
                    TargetImageBox.SizeMode = PictureBoxSizeMode.StretchImage;

                    if (dWidth > 984)
                        {
                        dHeight = dHeight / dWidth;
                        dWidth = 984;
                        dHeight *= dWidth;

                        if (dHeight > 519)
                            {
                            dWidth = dWidth / dHeight;
                            dHeight = 519;
                            dWidth *= dHeight;
                            }
                        }
                    else
                        {
                        dWidth = dWidth / dHeight;
                        dHeight = 519;
                        dWidth *= dHeight;

                        if (dWidth > 984)
                            {
                            dHeight = dHeight / dWidth;
                            dWidth = 984;
                            dHeight *= dWidth;
                            }
                        }
                    }
                else
                    {
                    TargetImageBox.SizeMode = PictureBoxSizeMode.Normal;
                    }
                }

            TargetImageBox.Size = new Size((int) dWidth, (int) dHeight);
            TargetImageBox.Location = new Point((ClientRectangle.Width / 2) - (TargetImageBox.Width / 2), nY + (int) (dMaxHeight / 2) - (TargetImageBox.Height / 2));

            m_TargetImage = new Bitmap((int) dWidth, (int) dHeight);

            if (m_Target.Image != null)
                {
                Graphics g = Graphics.FromImage(m_TargetImage);

                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

                g.DrawImage(m_Target.Image, 0, 0, m_TargetImage.Width, m_TargetImage.Height);
                }
            }

        //============================================================================*
        // GetUniqueFileName()
        //============================================================================*

        private string GetUniqueFileName()
            {
            string strFileName = m_Target.SuggestedFileName;

            int nIndex = 1;

            while (File.Exists(Path.Combine(m_strFolder, strFileName)))
                {
                strFileName = string.Format("{0} ({1})", m_Target.SuggestedFileName, nIndex);

                nIndex++;
                }

            return (strFileName);
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
            VerifyTargetFolder();

            m_Target = new cTarget(m_DataFiles);

            if (m_BatchTest != null)
                SetBatchTestInfo();

            m_fBatchTest = m_BatchTest != null;

            //----------------------------------------------------------------------------*
            // Event Handlers
            //----------------------------------------------------------------------------*

            if (!m_fInitialized)
                {
                FileNewMenuItem.Click += OnFileNew;
                FileOpenMenuItem.Click += OnFileOpen;
                FileOpenTargetImageMenuItem.Click += OnFileOpenTargetImage;
                FilePrintMenuItem.Click += OnFilePrint;
                FileSaveAsMenuItem.Click += OnFileSaveAs;
                FileSaveMenuItem.Click += OnFileSave;
                FileSaveTargetImageMenuItem.Click += OnFileSaveTargetImage;
                FileScanTargetImageMenuItem.Click += OnFileScanTargetImage;

                EditDetailsMenuItem.Click += OnEditDetails;
                EditPreferencesMenuItem.Click += OnEditPreferences;
                EditUndoMenuItem.Click += OnEditUndo;

                ImageRotateRightMenuItem.Click += OnRotateRight;
                ImageRotateLeftMenuItem.Click += OnRotateLeft;
                ImageFlipMenuItem.Click += OnFlip;

                HelpAboutMenuItem.Click += OnHelpAboutClicked;
                HelpVideoTargetCalculatorMenuItem.Click += OnHelpVideoClicked;
                HelpVideoScanningTargetsMenuItem.Click += OnHelpVideoClicked;

                CaliberCombo.SelectedIndexChanged += OnCaliberSelected;
                RangeTextBox.TextChanged += OnRangeChanged;

                TargetImageBox.MouseDown += OnTargetMouseDown;
                TargetImageBox.MouseUp += OnTargetMouseUp;
                TargetImageBox.MouseMove += OnTargetMouseMove;

                ShowAimPointCheckBox.Click += OnShowButtonClicked;
                ShowOffsetCheckBox.Click += OnShowButtonClicked;
                ShowScaleCheckBox.Click += OnShowButtonClicked;
                ShowExtremesCheckBox.Click += OnShowButtonClicked;
                ShowGroupBoxCheckBox.Click += OnShowButtonClicked;
                ShowShotNumCheckBox.Click += OnShowButtonClicked;

                OKButton.Click += OnOKClicked;
                FormClosing += OnFormClosing;

                SetClientSizeCore(OutputGroupBox.Location.X + OutputGroupBox.Width + 10, FormCancelButton.Location.Y + FormCancelButton.Height + 20);
                }

            //----------------------------------------------------------------------------*
            // Populate Option Check Boxes
            //----------------------------------------------------------------------------*

            ShowAimPointCheckBox.Checked = m_DataFiles.Preferences.TargetShowAimPoint;
            ShowExtremesCheckBox.Checked = m_DataFiles.Preferences.TargetShowExtremes;
            ShowGroupBoxCheckBox.Checked = m_DataFiles.Preferences.TargetShowGroupBox;
            ShowOffsetCheckBox.Checked = m_DataFiles.Preferences.TargetShowOffset;
            ShowScaleCheckBox.Checked = m_DataFiles.Preferences.TargetShowScale;
            ShowShotNumCheckBox.Checked = m_DataFiles.Preferences.TargetShowShotNum;

            //----------------------------------------------------------------------------*
            // Set Target Size
            //----------------------------------------------------------------------------*

            Reset();

            FitImage();

            //----------------------------------------------------------------------------*
            // Populate Data
            //----------------------------------------------------------------------------*

            bool fFileOpened = false;

            if (m_BatchTest != null)
                {
                m_strFileName = string.Format("Batch {0:G0} Target File.rwt", m_Target.BatchID);

                m_strFolder = Path.Combine(m_DataFiles.GetDataPath(), "Target Files");

                if (File.Exists(Path.Combine(m_strFolder, m_strFileName)))
                    {
                    Open(m_strFolder, m_strFileName);

                    SetBatchTestInfo();

                    fFileOpened = true;
                    }
                }

            if (!fFileOpened)
                {
                PopulateCaliberCombo();

                SetInputParameters();

                SetInputData();

                SetMode(m_Target.BatchID == 0 ? eMode.LoadTarget : eMode.MarkShots);

                FitImage();

                m_strFileName = "";

                SetTitle();
                }

            //----------------------------------------------------------------------------*
            // Clean up and exit
            //----------------------------------------------------------------------------*

            m_fInitialized = true;

            OnResize(null);

            UpdateButtons();
            }

        //============================================================================*
        // OnCaliberSelected()
        //============================================================================*

        private void OnCaliberSelected(Object sender, EventArgs e)
            {
            if (!m_fInitialized)
                return;

            if (CaliberCombo.SelectedIndex >= 0)
                m_Target.Caliber = (cCaliber) CaliberCombo.SelectedItem;
            else
                m_Target.Caliber = null;

            SetInputData();

            SetImage();

            SetTargetCursor();

            m_fChanged = true;

            SetTitle();
            }

        //============================================================================*
        // OnEditDetails()
        //============================================================================*

        private void OnEditDetails(Object sender, EventArgs e)
            {
            cTargetDetailsForm DetailsForm = new cTargetDetailsForm(m_DataFiles, m_Target);

            DialogResult rc = DetailsForm.ShowDialog();

            if (rc == DialogResult.OK)
                {
                cTarget Target = DetailsForm.Target;

                m_Target.Date = Target.Date;
                m_Target.Firearm = Target.Firearm;
                m_Target.Location = Target.Location;
                m_Target.Shooter = Target.Shooter;
                m_Target.Event = Target.Event;
                m_Target.Notes = Target.Notes;

                m_fChanged = true;

                SetTitle();

                UpdateButtons();
                }
            }

        //============================================================================*
        // OnEditPreferences()
        //============================================================================*

        private void OnEditPreferences(Object sender, EventArgs e)
            {
            cTargetPreferencesForm PreferencesForm = new cTargetPreferencesForm(m_DataFiles, m_Target, this);

            PreferencesForm.ShowDialog();
            }

        //============================================================================*
        // OnEditUndo()
        //============================================================================*

        private void OnEditUndo(Object sender, EventArgs e)
            {
            if (m_eMode == eMode.MarkShots)
                {
                if (m_Target.ShotList.Count > 0)
                    m_Target.ShotList.RemoveAt(m_Target.ShotList.Count - 1);

                if (m_Target.ShotList.Count == 0)
                    SetMode(eMode.AimPoint);
                else
                    {
                    SetImage();

                    SetNumShotsLabel();

                    SetOutputData();
                    }

                m_fChanged = true;

                SetTitle();

                return;
                }

            if (m_eMode == eMode.AimPoint)
                {
                SetMode(eMode.Calibrate);

                m_fChanged = true;

                SetTitle();

                return;
                }

            if (m_eMode == eMode.Calibrate)
                {
                OnFileNew(sender, e);

                m_fChanged = true;

                SetTitle();

                return;
                }
            }

        //============================================================================*
        // OnFileNew()
        //============================================================================*

        private void OnFileNew(Object sender, EventArgs e)
            {
            if (!VerifyDiscardChanges())
                return;

            m_strFileName = null;

            m_Target = new cTarget(m_DataFiles);
            m_Target.Caliber = (cCaliber) CaliberCombo.SelectedItem;

            m_TargetImage = null;

            FitImage();

            m_AimPoint = null;
            m_AimPointOffset = null;

            SetImage();

            SetMode(eMode.LoadTarget);

            SetOutputData();

            m_fChanged = false;

            SetTitle();
            }

        //============================================================================*
        // OnFileOpen()
        //============================================================================*

        private void OnFileOpen(Object sender, EventArgs e)
            {
            if (!VerifyDiscardChanges())
                return;

            OpenFileDialog OpenFileDialog = new OpenFileDialog();

            OpenFileDialog.Title = "Open Target File";
            OpenFileDialog.DefaultExt = "rwt";
            OpenFileDialog.CheckFileExists = true;
            OpenFileDialog.CheckPathExists = true;
            OpenFileDialog.Filter = "Target Files (*.rwt)|*.rwt";
            OpenFileDialog.InitialDirectory = m_strFolder;

            if (OpenFileDialog.ShowDialog() == DialogResult.OK)
                {
                string strFileName = Path.GetFileName(OpenFileDialog.FileName);
                string strFolder = Path.GetDirectoryName(OpenFileDialog.FileName);

                Open(strFolder, strFileName);

                m_fChanged = false;

                SetTitle();
                }
            }

        //============================================================================*
        // OnFileOpenTargetImage()
        //============================================================================*

        private void OnFileOpenTargetImage(Object sender, EventArgs e)
            {
            OpenFileDialog OpenTargetDialog = new OpenFileDialog();

            OpenTargetDialog.CheckFileExists = true;
            OpenTargetDialog.CheckPathExists = true;
            OpenTargetDialog.Filter = "Image Files (*.bmp, *.jpg, *.jpeg)|*.bmp;*.jpg;*.jpeg";

            if (!String.IsNullOrEmpty(m_DataFiles.Preferences.TargetFolder))
                OpenTargetDialog.InitialDirectory = m_DataFiles.Preferences.TargetFolder;
            else
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

                    Bitmap NewBitmap = new Bitmap(984, 519);

                    if (m_Target.Image != null)
                        {
                        Graphics g = Graphics.FromImage(NewBitmap);

                        g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

                        g.DrawImage(m_Target.Image, 0, 0, m_TargetImage.Width, m_TargetImage.Height);
                        }

                    m_Target.Image = NewBitmap;

                    m_DataFiles.Preferences.TargetFolder = Path.GetDirectoryName(OpenTargetDialog.FileName);

                    FitImage();

                    SetImage();

                    SetMode(eMode.Calibrate);

                    m_fChanged = true;

                    SetTitle();
                    }
                catch
                    {
                    MessageBox.Show("Unable to open Image File!", "Image File Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

        //============================================================================*
        // OnFilePrint()
        //============================================================================*

        private void OnFilePrint(Object sender, EventArgs e)
            {
            cTargetPrintPreviewDialog PrintDialog = new cTargetPrintPreviewDialog(m_DataFiles, m_Target, TargetImageBox.Image);

            PrintDialog.ShowDialog();
            }

        //============================================================================*
        // OnFileSave()
        //============================================================================*

        private void OnFileSave(Object sender, EventArgs e)
            {
            if (String.IsNullOrEmpty(m_strFileName))
                {
                SaveFileDialog SaveFileDialog = new SaveFileDialog();

                SaveFileDialog.Title = "Save Target File";
                SaveFileDialog.DefaultExt = "rwt";
                SaveFileDialog.CheckFileExists = false;
                SaveFileDialog.CheckPathExists = false;
                SaveFileDialog.FileName = GetUniqueFileName();
                SaveFileDialog.Filter = "Target Files (*.rwt)|*.rwt";
                SaveFileDialog.InitialDirectory = m_strFolder;

                if (SaveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                    m_strFileName = Path.GetFileName(SaveFileDialog.FileName);

                    m_fChanged = true;
                    }
                }

            if (m_fChanged && !String.IsNullOrEmpty(m_strFileName))
                {
                Save();

                m_fChanged = false;

                SetTitle();
                }
            }

        //============================================================================*
        // OnFileSaveAs()
        //============================================================================*

        private void OnFileSaveAs(Object sender, EventArgs e)
            {
            SaveFileDialog SaveFileDialog = new SaveFileDialog();

            SaveFileDialog.Title = "Save Target File As";
            SaveFileDialog.DefaultExt = "rwt";
            SaveFileDialog.CheckFileExists = false;
            SaveFileDialog.CheckPathExists = true;
            SaveFileDialog.OverwritePrompt = true;
            SaveFileDialog.Filter = "Target Files (*.rwt)|*.rwt";
            SaveFileDialog.InitialDirectory = m_strFolder;
            SaveFileDialog.FileName = GetUniqueFileName();

            if (SaveFileDialog.ShowDialog() == DialogResult.OK)
                {
                m_strFileName = Path.GetFileName(SaveFileDialog.FileName);

                Save();

                m_fChanged = false;

                SetTitle();
                }
            }

        //============================================================================*
        // OnFileSaveTargetImage()
        //============================================================================*

        private void OnFileSaveTargetImage(Object sender, EventArgs e)
            {
            SaveFileDialog SaveTargetDialog = new SaveFileDialog();

            string strFileName = m_Target.SuggestedFileName;

            strFileName = Path.ChangeExtension(strFileName, "jpg");

            SaveTargetDialog.CheckFileExists = false;
            SaveTargetDialog.CheckPathExists = false;
            SaveTargetDialog.FileName = strFileName;
            SaveTargetDialog.Filter = "Image Files (*.bmp, *.jpg, *.jpeg)|*.bmp;*.jpg;*.jpeg";
            SaveTargetDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            SaveTargetDialog.Title = "Save Target Image";

            DialogResult rc = SaveTargetDialog.ShowDialog();

            if (rc == DialogResult.OK)
                {
                strFileName = SaveTargetDialog.FileName;

                TargetImageBox.Image.Save(strFileName, ImageFormat.Jpeg);
                }
            }

        //============================================================================*
        // OnFileScanTargetImage()
        //============================================================================*

        private void OnFileScanTargetImage(Object sender, EventArgs e)
            {
            try
                {
                WIA.CommonDialog Dlg = new WIA.CommonDialog();

                ImageFile ScannedFile = Dlg.ShowAcquireImage(WiaDeviceType.ScannerDeviceType, WiaImageIntent.UnspecifiedIntent, WiaImageBias.MaximizeQuality, FormatID.wiaFormatJPEG, true, true, false);

                if (ScannedFile == null)
                    return;

                byte[] imageBytes = (byte[]) ScannedFile.FileData.get_BinaryData();

                MemoryStream ms = new MemoryStream(imageBytes);

                TargetImageBox.Image = Image.FromStream(ms);

                try
                    {
                    m_Target.Image = new Bitmap(TargetImageBox.Image);

                    FitImage();

                    SetImage();

                    SetMode(eMode.Calibrate);

                    m_fChanged = true;

                    SetTitle();
                    }
                catch
                    {
                    MessageBox.Show("Unable to open scanned image file!", "Scanned Image File Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            catch
                {
                string strMsg = "Unable to scan Image File!\n\nMake sure your scanner is connected and ready to use.";

                MessageBox.Show(strMsg, "Image File Scan  Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        //============================================================================*
        // OnFlip()
        //============================================================================*

        private void OnFlip(Object sender, EventArgs e)
            {
            Reset();

            RotateRight(false);
            RotateRight(false);
            }

        //============================================================================*
        // OnFormClosing()
        //============================================================================*

        private void OnFormClosing(Object sender, FormClosingEventArgs e)
            {
            if (!VerifyDiscardChanges())
                e.Cancel = true;
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
        // OnHelpVideoClicked()
        //============================================================================*

        private void OnHelpVideoClicked(Object sender, EventArgs e)
            {
            try
                {
                switch ((sender as ToolStripDropDownItem).Name)
                    {
                    case "HelpVideoTargetCalculatorMenuItem":
                        System.Diagnostics.Process.Start("https://www.youtube.com/v/WgaOR49oU-c?autoplay=1&rel=0&showinfo=0");
                        break;
                    case "HelpVideoScanningTargetsMenuItem":
                        System.Diagnostics.Process.Start("https://www.youtube.com/v/wQmP49edQBo?autoplay=1&rel=0&showinfo=0");
                        break;
                    }
                }
            catch
                {
                MessageBox.Show("Unable to navigate to YouTube at this time, try again later.  Please make sure you are connected to the Internet.", "YouTube Unavailable", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        //============================================================================*
        // OnRotateLeft()
        //============================================================================*

        private void OnRotateLeft(Object sender, EventArgs e)
            {
            Reset();

            RotateLeft();
            }

        //============================================================================*
        // RotateLeft()
        //============================================================================*

        private void RotateLeft(bool fRotateOnly = false)
            {
            Bitmap NewBitmap = new Bitmap(m_Target.Image.Height, m_Target.Image.Width);

            for (int nInCol = 0; nInCol < m_Target.Image.Width; nInCol++)
                {
                for (int nInRow = 0; nInRow < m_Target.Image.Height; nInRow++)
                    {
                    Color PixelColor = (m_Target.Image as Bitmap).GetPixel(nInCol, nInRow);

                    NewBitmap.SetPixel(nInRow, m_Target.Image.Width - 1 - nInCol, PixelColor);
                    }
                }

            m_Target.Image = NewBitmap;

            TargetImageBox.Image = NewBitmap;

            if (!fRotateOnly)
                FitImage();
            }

        //============================================================================*
        // OnRotateRight()
        //============================================================================*

        private void OnRotateRight(Object sender, EventArgs e)
            {
            Reset();

            RotateRight();
            }

        //============================================================================*
        // RotateRight()
        //============================================================================*

        private void RotateRight(bool fRotateOnly = false)
            {
            Bitmap NewBitmap = new Bitmap(m_Target.Image.Height, m_Target.Image.Width);

            for (int nInCol = 0; nInCol < m_Target.Image.Width; nInCol++)
                {
                for (int nInRow = 0; nInRow < m_Target.Image.Height; nInRow++)
                    {
                    Color PixelColor = (m_Target.Image as Bitmap).GetPixel(nInCol, nInRow);

                    NewBitmap.SetPixel(NewBitmap.Width - 1 - nInRow, nInCol, PixelColor);
                    }
                }

            m_Target.Image = NewBitmap;

            TargetImageBox.Image = NewBitmap;

            if (!fRotateOnly)
                FitImage();
            }

        //============================================================================*
        // OnOKClicked()
        //============================================================================*

        private void OnOKClicked(Object sender, EventArgs e)
            {
            OnFileSave(sender, e);
            }

        //============================================================================*
        // OnRangeChanged()
        //============================================================================*

        private void OnRangeChanged(Object sender, EventArgs e)
            {
            if (!m_fInitialized)
                return;

            m_Target.Range = (int) m_DataFiles.MetricToStandard(RangeTextBox.Value, cDataFiles.eDataType.Range);

            SetOutputData();

            m_fChanged = true;

            SetTitle();
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
            FormCancelButton.Location = new Point((ClientRectangle.Width / 2) + 20, ClientRectangle.Height - 20 - FormCancelButton.Height);

            FitImage();

            SetImage();

            SetMode(m_eMode);
            }

        //============================================================================*
        // OnShowButtonClicked()
        //============================================================================*

        private void OnShowButtonClicked(Object sender, EventArgs e)
            {
            SetImage();

            switch ((sender as CheckBox).Name)
                {
                case "ShowAimPointCheckBox":
                    m_DataFiles.Preferences.TargetShowAimPoint = ShowAimPointCheckBox.Checked;
                    break;
                case "ShowExtremesCheckBox":
                    m_DataFiles.Preferences.TargetShowExtremes = ShowExtremesCheckBox.Checked;
                    break;
                case "ShowGroupBoxCheckBox":
                    m_DataFiles.Preferences.TargetShowGroupBox = ShowGroupBoxCheckBox.Checked;
                    break;
                case "ShowOffsetCheckBox":
                    m_DataFiles.Preferences.TargetShowOffset = ShowOffsetCheckBox.Checked;
                    break;
                case "ShowScaleCheckBox":
                    m_DataFiles.Preferences.TargetShowScale = ShowScaleCheckBox.Checked;
                    break;
                case "ShowShotNumCheckBox":
                    m_DataFiles.Preferences.TargetShowShotNum = ShowShotNumCheckBox.Checked;
                    break;
                }

            UpdateButtons();
            }

        //============================================================================*
        // OnTargetMouseDown()
        //============================================================================*

        private void OnTargetMouseDown(Object sender, MouseEventArgs e)
            {
            switch (m_eMode)
                {
                case eMode.LoadTarget:
                    OnFileOpenTargetImage(sender, e);

                    m_fChanged = true;

                    break;

                case eMode.Calibrate:
                    m_fMouseDown = true;

                    m_Target.CalibrationStart = e.Location;
                    m_Target.CalibrationEnd = e.Location;

                    SetImage();

                    m_fChanged = true;

                    break;

                case eMode.AimPoint:
                    Point AimPoint = new Point(e.X, e.Y);
                    m_Target.AimPoint = AimPoint;

                    m_AimPoint = CreateAimPointBitmap();
                    m_AimPointOffset = CreateAimPointOffsetBitmap();

                    SetMode(eMode.MarkShots);

                    m_fChanged = true;

                    break;

                case eMode.MarkShots:
                    Point Shot = new Point(e.X, e.Y);

                    if (!m_Target.AddShot(Shot))
                        {
                        Console.Beep(1000, 100);
                        }
                    else
                        {
                        SetImage();

                        SetNumShotsLabel();

                        SetOutputData();

                        m_fChanged = true;
                        }

                    break;
                }

            SetTitle();
            }

        //============================================================================*
        // OnTargetMouseMove()
        //============================================================================*

        private void OnTargetMouseMove(Object sender, MouseEventArgs e)
            {
            if (m_eMode != eMode.Calibrate || !m_fMouseDown)
                return;

            if (m_eMode == eMode.Calibrate && m_fMouseDown)
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
                string strMsg = string.Format("Your scale line is only {0:N0} pixels long.  You must mark a line of at least {1:N0} pixels.\n\nTry again.", m_Target.CalibrationPixels, m_Target.MinCalibrationPixels);

                MessageBox.Show(strMsg, "Invalid Scale Line", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                m_Target.CalibrationStart = new Point(0, 0);
                m_Target.CalibrationEnd = new Point(0, 0);
                m_Target.CalibrationLength = 0.0;

                m_ScaleBar = null;
                }
            else
                {
                cTargetCalibrationForm CalibrationForm = new cTargetCalibrationForm(m_DataFiles, m_Target);

                DialogResult rc = CalibrationForm.ShowDialog();

                if (rc == DialogResult.OK)
                    {
                    SetMode(eMode.AimPoint);

                    m_ScaleBar = CreateScaleBar();
                    }
                else
                    {
                    m_Target.CalibrationStart = new Point(0, 0);
                    m_Target.CalibrationEnd = new Point(0, 0);
                    m_Target.CalibrationLength = 0.0;

                    m_ScaleBar = null;
                    }

                m_fChanged = true;

                SetTitle();
                }

            SetImage();
            }

        //============================================================================*
        // Open()
        //============================================================================*

        private void Open(string strFolder, string strFileName)
            {
            Stream Stream = null;

            string strFilePath = Path.Combine(strFolder, strFileName);

            //----------------------------------------------------------------------------*
            // Open Target Data File
            //----------------------------------------------------------------------------*

            try
                {
                //----------------------------------------------------------------------------*
                // Open target file and create formatter
                //----------------------------------------------------------------------------*

                Stream = File.Open(strFilePath, FileMode.Open);

                BinaryFormatter Formatter = new BinaryFormatter();

                //----------------------------------------------------------------------------*
                // Deserialize the cTarget object
                //----------------------------------------------------------------------------*

                cTarget LoadTarget = new cTarget();

                LoadTarget = (cTarget) Formatter.Deserialize(Stream);

                if (!m_fBatchTest && LoadTarget.BatchID != 0)
                    {
                    string strText = String.Format("This Target file is associated with Batch {0:G0} Test Data.  Target data may only be changed via the Batch {0:G0} Test Data Editor.", LoadTarget.BatchID);

                    MessageBox.Show(strText, "Changes Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                else
                    {
                    m_Target = new cTarget(LoadTarget);

                    m_strFolder = strFolder;
                    m_strFileName = strFileName;

                    //----------------------------------------------------------------------------*
                    // Set the target data
                    //----------------------------------------------------------------------------*

                    FitImage();

                    m_AimPoint = CreateAimPointBitmap();
                    m_AimPointOffset = CreateAimPointOffsetBitmap();
                    m_ScaleBar = CreateScaleBar();

                    m_Target.Synch(m_DataFiles);

                    PopulateCaliberCombo();

                    SetInputData();
                    SetOutputData();
                    SetImage();

                    //----------------------------------------------------------------------------*
                    // Determine what mode to set
                    //----------------------------------------------------------------------------*

                    if (m_Target.ShotList.Count > 0 && m_Target.AimPoint != Point.Empty)
                        {
                        SetMode(eMode.MarkShots);
                        }
                    else
                        {
                        if (m_Target.Calibrated)
                            SetMode(eMode.AimPoint);
                        else
                            {
                            if (m_Target.Image != null)
                                SetMode(eMode.Calibrate);
                            else
                                SetMode(eMode.LoadTarget);
                            }
                        }

                    m_fChanged = false;

                    SetTitle();
                    }
                }

            //----------------------------------------------------------------------------*
            // Oops, couldn't open or deserialize the file
            //----------------------------------------------------------------------------*

            catch (Exception e1)
                {
                MessageBox.Show(e1.Message);
                }

            //----------------------------------------------------------------------------*
            // Close the stream if one was created
            //----------------------------------------------------------------------------*

            finally
                {
                if (Stream != null)
                    Stream.Close();
                }
            }

        //============================================================================*
        // PopulateCaliberCombo()
        //============================================================================*

        private void PopulateCaliberCombo()
            {
            CaliberCombo.Items.Clear();

            if (m_BatchTest == null)
                {
                foreach (cCaliber Caliber in m_DataFiles.CaliberList)
                    {
                    if (!m_DataFiles.Preferences.HideUncheckedCalibers || Caliber.Checked)
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
                CaliberCombo.Items.Add(m_BatchTest.Batch.Load.Caliber);

                CaliberCombo.SelectedIndex = 0;
                }

            if (CaliberCombo.SelectedIndex >= 0 && (m_Target.Caliber == null || m_Target.Caliber.CompareTo((cCaliber) CaliberCombo.SelectedItem) != 0))
                {
                cCaliber Caliber = (cCaliber) CaliberCombo.SelectedItem;

                if (Caliber != null)
                    m_Target.Caliber = Caliber;
                }
            }

        //============================================================================*
        // Reset()
        //============================================================================*

        public void Reset()
            {
            m_Target.AimPoint = new Point(0, 0);
            m_Target.CalibrationStart = new Point(0, 0);
            m_Target.CalibrationEnd = new Point(0, 0);

            while (m_Target.ShotList.Count > 0)
                m_Target.ShotList.RemoveAt(0);

            if (m_Target.Image == null)
                SetMode(eMode.LoadTarget);
            else
                SetMode(eMode.Calibrate);

            m_fChanged = false;
            }

        //============================================================================*
        // ResetBitmaps()
        //============================================================================*

        public void ResetBitmaps()
            {
            m_AimPoint = CreateAimPointBitmap();
            m_AimPointOffset = CreateAimPointOffsetBitmap();
            m_ScaleBar = CreateScaleBar();

            SetTargetCursor();

            SetImage();

            m_fChanged = true;

            SetTitle();
            UpdateButtons();
            }

        //============================================================================*
        // Save()
        //============================================================================*

        private void Save()
            {
            Stream Stream = null;

            string strFilePath = Path.Combine(m_strFolder, m_strFileName);

            //----------------------------------------------------------------------------*
            // Save Target Data
            //----------------------------------------------------------------------------*

            try
                {
                //----------------------------------------------------------------------------*
                // Open target file and create formatter
                //----------------------------------------------------------------------------*

                Stream = File.Open(strFilePath, FileMode.Create);

                BinaryFormatter Formatter = new BinaryFormatter();

                //----------------------------------------------------------------------------*
                // Serialize the cTarget object
                //----------------------------------------------------------------------------*

                Formatter.Serialize(Stream, m_Target);
                }
            catch (Exception e1)
                {
                MessageBox.Show(e1.Message);
                }
            finally
                {
                if (Stream != null)
                    Stream.Close();
                }
            }

        //============================================================================*
        // SetBatchTestInfo()
        //============================================================================*

        private void SetBatchTestInfo()
            {
            m_Target.BatchID = m_BatchTest.Batch.BatchID;

            if (m_BatchTest.BestGroupRange != 0)
                m_Target.Range = m_BatchTest.BestGroupRange;

            m_Target.Date = m_BatchTest.TestDate;
            m_Target.Location = m_BatchTest.Location;
            m_Target.Firearm = m_BatchTest.Firearm;
            m_Target.Caliber = m_BatchTest.Batch.Load.Caliber;

            if (m_Target.Range == 0)
                m_Target.Range = m_BatchTest.Batch.Load.FirearmType == cFirearm.eFireArmType.Rifle ? 100 : 25;
            }

        //============================================================================*
        // SetImage()
        //============================================================================*

        public void SetImage()
            {
            if (m_TargetImage == null)
                {
                TargetImageBox.Image = null;

                TargetImageBox.Width = 984;
                TargetImageBox.Height = 519;

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

            if (m_Target.CalibrationPixels > 0 && m_eMode == eMode.Calibrate)
                {
                Pen LinePen = new Pen(m_Target.CalibrationPixels < m_Target.MinCalibrationPixels ? Brushes.Red : Brushes.Green, 3);

                g.DrawLine(LinePen, m_Target.CalibrationStart, m_Target.CalibrationEnd);
                }

            //----------------------------------------------------------------------------*
            // Draw Scale Bar
            //----------------------------------------------------------------------------*

            if (m_Target.Calibrated && m_ScaleBar != null && ShowScaleCheckBox.Checked)
                {
                g.DrawImage(m_ScaleBar, 0, TargetImage.Height - m_ScaleBar.Height);
                }

            //----------------------------------------------------------------------------*
            // Draw Group Box
            //----------------------------------------------------------------------------*

            if (m_Target.Calibrated && m_Target.ShotList.Count > 2 && ShowGroupBoxCheckBox.Checked)
                {
                Pen GroupBoxPen = new Pen(m_Target.GroupBoxColor, 2);

                g.DrawRectangle(GroupBoxPen, m_Target.GroupBox);
                }

            //----------------------------------------------------------------------------*
            // Draw AimPoint
            //----------------------------------------------------------------------------*

            if (m_AimPoint != null && ShowAimPointCheckBox.Checked && m_Target.Calibrated)
                {
                int x = m_Target.AimPoint.X - m_AimPoint.Width / 2;
                int y = m_Target.AimPoint.Y - m_AimPoint.Height / 2;

                g.DrawImage(m_AimPoint, x, y);
                }

            //----------------------------------------------------------------------------*
            // Draw AimPointOffset
            //----------------------------------------------------------------------------*

            if (m_AimPointOffset != null && ShowOffsetCheckBox.Checked && m_Target.ShotList.Count > 1)
                {
                int x = m_Target.AimPoint.X + (int) (m_Target.MeanOffset.X * m_Target.PixelsPerInch) - (m_AimPointOffset.Width / 2);
                int y = m_Target.AimPoint.Y - (int) (m_Target.MeanOffset.Y * m_Target.PixelsPerInch) - (m_AimPointOffset.Height / 2);

                g.DrawImage(m_AimPointOffset, x, y);
                }

            //----------------------------------------------------------------------------*
            // Draw Group Extremes Line
            //----------------------------------------------------------------------------*

            if (m_Target.ShotList.Count > 0 && ShowExtremesCheckBox.Checked)
                {
                Point Extremes1;
                Point Extremes2;

                Pen ExtremesPen = new Pen(m_Target.ExtremesColor, 1);

                m_Target.GroupExtremes(out Extremes1, out Extremes2);

                if (Extremes1 != Point.Empty && Extremes2 != Point.Empty)
                    g.DrawLine(ExtremesPen, Extremes1, Extremes2);
                }

            //----------------------------------------------------------------------------*
            // Draw Shots
            //----------------------------------------------------------------------------*

            if (m_Target.ShotList.Count > 0)
                {
                Bitmap ShotBitmap = CreateShotBitmap();

                int nShotNum = 1;

                SolidBrush ShotForeBrush = new SolidBrush(m_Target.ShotForecolor);

                foreach (Point Shot in m_Target.ShotList)
                    {
                    int x = Shot.X - ShotBitmap.Width / 2;
                    int y = Shot.Y - ShotBitmap.Height / 2;

                    g.DrawImage(ShotBitmap, x, y);

                    if (ShowShotNumCheckBox.Checked)
                        {
                        string strShot = String.Format("{0:G0}", nShotNum);

                        SizeF ShotSize = g.MeasureString(strShot, SystemFonts.DefaultFont);

                        g.DrawString(strShot, SystemFonts.DefaultFont, ShotForeBrush, Shot.X - (ShotSize.Width / 2), Shot.Y - (ShotSize.Height / 2));
                        }

                    nShotNum++;
                    }
                }

            //----------------------------------------------------------------------------*
            // Draw MousePointer - TODO: Remove this
            //----------------------------------------------------------------------------*
            /*
                        if (m_MousePointer != null)
                            g.DrawImage(m_MousePointer, m_nMouseX - (m_MousePointer.Width / 2), m_nMouseY - (m_MousePointer.Height / 2));
            */
            }

        //============================================================================*
        // SetInputData()
        //============================================================================*

        private void SetInputData()
            {
            RangeTextBox.Value = (int) m_DataFiles.StandardToMetric(m_Target.Range, cDataFiles.eDataType.Range);
            RangeMeasurementLabel.Text = m_DataFiles.MetricLongString(cDataFiles.eDataType.Range);

            double dBulletDiameter = 0.0;

            if (m_BatchTest == null)
                {
                if (m_Target.Caliber != null)
                    dBulletDiameter = m_Target.Caliber.MinBulletDiameter;
                }
            else
                dBulletDiameter = m_BatchTest.Batch.BulletDiameter;

            string strDimensionFormat = "{0:F";
            strDimensionFormat += String.Format("{0:G0}", m_DataFiles.Preferences.DimensionDecimals);
            strDimensionFormat += "} ";
            strDimensionFormat += m_DataFiles.MetricString(cDataFiles.eDataType.Dimension);

            BulletDiameterLabel.Text = String.Format(strDimensionFormat, m_DataFiles.StandardToMetric(dBulletDiameter, cDataFiles.eDataType.Dimension));

            SetNumShotsLabel();

            CaliberCombo.SelectedItem = m_Target.Caliber;

            if (CaliberCombo.SelectedIndex < 0)
                {
                if (CaliberCombo.Items.Count > 0)
                    CaliberCombo.SelectedIndex = 0;
                }

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

            if (m_eMode == eMode.AimPoint)
                {
                m_Target.AimPoint = new Point(0, 0);
                m_AimPoint = null;
                m_AimPointOffset = null;
                }

            if (m_eMode == eMode.Calibrate)
                {
                m_Target.CalibrationStart = new Point(0, 0);
                m_Target.CalibrationEnd = new Point(0, 0);
                m_Target.CalibrationLength = 0.0;
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
                    ModeLabel.Text += "Set Scale";

                    break;

                case eMode.AimPoint:
                    ModeLabel.Text += "Mark Aim Point";

                    break;

                default:
                    ModeLabel.Text += "Mark Shots";
                    break;
                }
            }

        //============================================================================*
        // SetNumShotsLabel()
        //============================================================================*

        private void SetNumShotsLabel()
            {
            TotalShotsLabel.Text = String.Format("{0:G0}", m_Target.ShotList.Count);
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
                dMOA = m_Target.GroupMOA;
                dMils = m_Target.GroupMils;
                }

            string strGroupFormat = "{0:F";
            strGroupFormat += String.Format("{0:G0}", m_DataFiles.Preferences.GroupDecimals);
            strGroupFormat += "} {1}";

            GroupSizeLabel.Text = String.Format(strGroupFormat, m_DataFiles.StandardToMetric(dGroupSize, cDataFiles.eDataType.GroupSize), m_DataFiles.MetricString(cDataFiles.eDataType.GroupSize));
            MOALabel.Text = String.Format("{0:F3}", dMOA);
            MilsLabel.Text = String.Format("{0:F3}", dMils);

            OffsetLabel.Text = m_Target.MeanOffsetString(m_DataFiles);
            GroupBoxLabel.Text = m_Target.GroupBoxString(m_DataFiles);
            }

        //============================================================================*
        // SetTargetCursor()
        //============================================================================*

        private void SetTargetCursor()
            {
            m_MousePointer = null;
            IntPtr ptr;

            switch (m_eMode)
                {
                case eMode.LoadTarget:
                    m_MousePointer = new Bitmap(Properties.Resources.OpenTarget);

                    ptr = m_MousePointer.GetHicon();

                    TargetImageBox.Cursor = new Cursor(ptr);

                    break;

                case eMode.AimPoint:
                    m_MousePointer = CreateReticleBitmap();

                    ptr = m_MousePointer.GetHicon();

                    TargetImageBox.Cursor = new Cursor(ptr);

                    break;

                case eMode.MarkShots:
                    m_MousePointer = CreateShotBitmap(true);

                    if (m_MousePointer != null)
                        {
                        ptr = m_MousePointer.GetHicon();

                        TargetImageBox.Cursor = new Cursor(ptr);
                        }

                    break;

                default:
                    TargetImageBox.Cursor = Cursors.Default;
                    break;
                }
            }

        //============================================================================*
        // SetTitle()
        //============================================================================*

        private void SetTitle()
            {
            string strTitle = "Target Calculator - ";

            if (string.IsNullOrEmpty(m_strFileName) && m_Target.BatchID != 0)
                m_strFileName = String.Format("Batch {0:G0} Target File.rwt", m_Target.BatchID);

            if (string.IsNullOrEmpty(m_strFileName))
                strTitle += "<Untitled>";
            else
                strTitle += Path.GetFileNameWithoutExtension(m_strFileName);

            if (m_fChanged)
                strTitle += " *";

            Text = strTitle;

            UpdateButtons();
            }

        //============================================================================*
        // Target Property
        //============================================================================*

        public cTarget Target
            {
            get
                {
                return (m_Target);
                }
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

                ModeLabel.Text = "Mode: Fix Input Data";

                TargetImageBox.Enabled = false;

                fEnableOK = false;
                }
            else
                {
                SetModeLabel();

                TargetImageBox.Enabled = true;
                }

            FileNewMenuItem.Enabled = m_Target.Image != null && m_Target.BatchID == 0;
            FileOpenMenuItem.Enabled = !m_fBatchTest;
            FileSaveTargetImageMenuItem.Enabled = m_TargetImage != null;
            EditUndoMenuItem.Enabled = m_Target.Image != null && !m_fBatchTest;

            if (m_Target.ShotList.Count > 0)
                {
                FileSaveMenuItem.Enabled = m_fChanged && !m_fBatchTest;
                FileSaveAsMenuItem.Enabled = !m_fBatchTest;
                FilePrintMenuItem.Enabled = true;
                }
            else
                {
                FilePrintMenuItem.Enabled = false;
                FileSaveMenuItem.Enabled = false;
                FileSaveAsMenuItem.Enabled = false;
                }

            if (fEnableOK)
                {
                if (m_Target.Image == null || !m_Target.Calibrated || m_Target.ShotList.Count < 2)
                    fEnableOK = false;
                }

            OKButton.Enabled = fEnableOK;
            }

        //============================================================================*
        // VerifyDiscardChanges()
        //============================================================================*

        private bool VerifyDiscardChanges()
            {
            if (!m_fChanged || m_Target.ShotList.Count == 0)
                return (true);

            DialogResult rc = MessageBox.Show("You have made changes to this Target File that have not been saved.\n\nDo you wish to save changes?", "Discard Changes?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3);

            if (rc == DialogResult.Yes)
                {
                OnFileSave(null, new EventArgs());

                return (true);
                }

            if (rc == DialogResult.No)
                return (true);

            return (false);
            }

        //============================================================================*
        // VerifyTargetFolder()
        //============================================================================*

        private void VerifyTargetFolder()
            {
            m_strFolder = Path.Combine(m_DataFiles.GetDataPath(), "Target Files");

            try
                {
                if (!Directory.Exists(m_strFolder))
                    Directory.CreateDirectory(m_strFolder);
                }
            catch
                {
                MessageBox.Show("Unable to create Target File Directory!  You will not be able to save Target Files!", "Direcotry Creation Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                m_strFolder = null;
                }
            }
        }
    }
