//============================================================================*
// cTarget.cs
//
// Copyright © 2013-2016, Kevin S. Beebe
// All Rights Reserved
//============================================================================*

//============================================================================*
// .Net Using Statements
//============================================================================*

using System;
using System.Collections.Generic;
using System.Drawing;

using CommonLib.Conversions;

//============================================================================*
// NameSpace
//============================================================================*

namespace ReloadersWorkShop
	{
	//============================================================================*
	// cTarget Class
	//============================================================================*

	[Serializable]
	public class cTarget
		{
		//============================================================================*
		// Private Constant Data Members
		//============================================================================*

		private const int cm_nMinImageWidth = 640;
		private const int cm_nMinImageHeight = 480;

		private const double cm_dMinCalibrationLength = 3.0;
		private const int cm_nMinCalibrationPixels = 300;

		//============================================================================*
		// Public Static Data Members
		//============================================================================*

		private static Color sm_DefaultAimPointColor = Color.FromName("LightGreen");
		private static Color sm_DefaultOffsetColor = Color.FromName("Red");
		private static Color sm_DefaultShotColor = Color.FromName("White");
		private static Color sm_DefaultShotForecolor = Color.FromName("Black");
		private static Color sm_DefaultReticleColor = Color.FromName("Black");
		private static Color sm_DefaultScaleForecolor = Color.FromName("Black");
		private static Color sm_DefaultScaleBackcolor = Color.FromName("Yellow");
		private static Color sm_DefaultExtremesColor = Color.FromName("White");
		private static Color sm_DefaultGroupBoxColor = Color.FromName("LightGray");

		//============================================================================*
		// Private Data Members
		//============================================================================*

		private int m_nBatchID = 0;
		private int m_nRange = 100;

		private double m_dBulletDiameter = 0.0;
		private cCaliber m_Caliber = null;

		private double m_dCalibrationLength = 0.0;
		private Point m_CalibrationStart = new Point(0, 0);
		private Point m_CalibrationEnd = new Point(0, 0);

		private double m_dGroupSize = 0.0;

		private Bitmap m_TargetImage = null;

		private Point m_AimPoint = new Point(0, 0);

		private List<Point> m_ShotList = new List<Point>();

		private DateTime m_Date = DateTime.Today;
		private string m_strShooter = "";
		private string m_strLocation = "";
		private cFirearm m_Firearm = null;
		private string m_strEvent = "";
		private string m_strNotes = "";

		public Color m_AimPointColor = sm_DefaultAimPointColor;
		public Color m_OffsetColor = sm_DefaultOffsetColor;
		public Color m_ShotColor = sm_DefaultShotColor;
		public Color m_ShotForecolor = sm_DefaultShotForecolor;
		public Color m_ReticleColor = sm_DefaultReticleColor;
		public Color m_ScaleForecolor = sm_DefaultScaleForecolor;
		public Color m_ScaleBackcolor = sm_DefaultScaleBackcolor;
		public Color m_ExtremesColor = sm_DefaultExtremesColor;
		public Color m_GroupBoxColor = sm_DefaultGroupBoxColor;

		//============================================================================*
		// cTarget() - Default Constructor
		//============================================================================*

		public cTarget()
			{
			}

		//============================================================================*
		// cTarget() - Constructor
		//============================================================================*

		public cTarget(cDataFiles DataFiles)
			{
			m_AimPointColor = DataFiles.Preferences.TargetAimPointColor;
			m_OffsetColor = DataFiles.Preferences.TargetOffsetColor;
			m_ShotColor = DataFiles.Preferences.TargetShotColor;
			m_ShotForecolor = DataFiles.Preferences.TargetShotForecolor;
			m_ReticleColor = DataFiles.Preferences.TargetReticleColor;
			m_ScaleForecolor = DataFiles.Preferences.TargetScaleForecolor;
			m_ScaleBackcolor = DataFiles.Preferences.TargetScaleBackcolor;
			m_ExtremesColor = DataFiles.Preferences.TargetExtremesColor;
			m_GroupBoxColor = DataFiles.Preferences.TargetGroupBoxColor;
			}

		//============================================================================*
		// cTarget() - Copy Constructor
		//============================================================================*

		public cTarget(cTarget Target)
			{
			m_nBatchID = Target.m_nBatchID;
			m_nRange = Target.m_nRange;

			m_dBulletDiameter = Target.m_dBulletDiameter;
			m_Caliber = Target.m_Caliber;

			m_dCalibrationLength = Target.m_dCalibrationLength;
			m_CalibrationStart = new Point(Target.m_CalibrationStart.X, Target.m_CalibrationStart.Y);
			m_CalibrationEnd = new Point(Target.m_CalibrationEnd.X, Target.m_CalibrationEnd.Y);

			m_dGroupSize = Target.m_dGroupSize;

			if (Target.m_TargetImage != null)
				m_TargetImage = new Bitmap(Target.m_TargetImage);

			m_AimPoint = new Point(Target.m_AimPoint.X, Target.m_AimPoint.Y);

			m_ShotList = new List<Point>(Target.m_ShotList);

			m_Date = Target.m_Date;
			m_strShooter = Target.m_strShooter;
			m_strLocation = Target.m_strLocation;
			m_strEvent = Target.m_strEvent;
			m_strNotes = Target.m_strNotes;
			m_Firearm = Target.Firearm;

			m_AimPointColor = Target.m_AimPointColor;
			m_OffsetColor = Target.m_OffsetColor;
			m_ShotColor = Target.m_ShotColor;
			m_ShotForecolor = Target.m_ShotForecolor;
			m_ReticleColor = Target.m_ReticleColor;
			m_ScaleForecolor = Target.m_ScaleForecolor;
			m_ScaleBackcolor = Target.m_ScaleBackcolor;
			m_ExtremesColor = Target.m_ExtremesColor;
			m_GroupBoxColor = Target.m_GroupBoxColor;
			}

		//============================================================================*
		// AddShot()
		//============================================================================*

		public bool AddShot(Point Shot)
			{
			m_ShotList.Add(Shot);

			return (true);
			}

		//============================================================================*
		// AimPoint Property
		//============================================================================*

		public Point AimPoint
			{
			get
				{
				return (m_AimPoint);
				}
			set
				{
				m_AimPoint = value;
				}
			}

		//============================================================================*
		// AimPointColor Property
		//============================================================================*

		public Color AimPointColor
			{
			get
				{
				return (m_AimPointColor);
				}
			set
				{
				m_AimPointColor = value;
				}
			}

		//============================================================================*
		// BatchID Property
		//============================================================================*

		public int BatchID
			{
			get
				{
				return (m_nBatchID);
				}
			set
				{
				m_nBatchID = value;
				}
			}

		//============================================================================*
		// BulletDiameter Property
		//============================================================================*

		public double BulletDiameter
			{
			get
				{
				return (m_dBulletDiameter);
				}
			set
				{
				m_dBulletDiameter = value;
				}
			}

		//============================================================================*
		// BulletPixels Property
		//============================================================================*

		public int BulletPixels
			{
			get
				{
				int nPixels = 0;

				if (Calibrated && PixelsPerInch > 0 && m_dBulletDiameter > 0.0)
					{
					nPixels = (int) ((double) PixelsPerInch * m_dBulletDiameter);
					}

				return (nPixels);
				}
			}

		//============================================================================*
		// Caliber Property
		//============================================================================*

		public cCaliber Caliber
			{
			get
				{
				return (m_Caliber);
				}
			set
				{
				m_Caliber = value;

				if (m_Caliber != null)
					m_dBulletDiameter = m_Caliber.MinBulletDiameter;
				else
					m_dBulletDiameter = 0.0;
				}
			}

		//============================================================================*
		// Calibrated Property
		//============================================================================*

		public bool Calibrated
			{
			get
				{
				return (CalibrationPixels >= cm_nMinCalibrationPixels && CalibrationLength >= cm_dMinCalibrationLength);
				}
			}

		//============================================================================*
		// CalibrationDPC Property
		//============================================================================*

		public int CalibrationDPC
			{
			get
				{
				int nDPC = 0;

				if (m_dCalibrationLength != 0.0 && CalibrationPixels != 0)
					nDPC = (int) ((double) CalibrationPixels / cConversions.InchesToCentimeters(m_dCalibrationLength));

				return (nDPC);
				}
			}

		//============================================================================*
		// CalibrationDPI Property
		//============================================================================*

		public int CalibrationDPI
			{
			get
				{
				int nDPI = 0;

				if (m_dCalibrationLength != 0.0 && CalibrationPixels != 0)
					nDPI = (int) ((double) CalibrationPixels / m_dCalibrationLength);

				return (nDPI);
				}
			}

		//============================================================================*
		// CalibrationEnd Property
		//============================================================================*

		public Point CalibrationEnd
			{
			get
				{
				return (m_CalibrationEnd);
				}
			set
				{
				m_CalibrationEnd = value;
				}
			}

		//============================================================================*
		// CalibrationLength Property
		//============================================================================*

		public double CalibrationLength
			{
			get
				{
				return (m_dCalibrationLength);
				}
			set
				{
				m_dCalibrationLength = value;
				}
			}

		//============================================================================*
		// CalibrationPixels Property
		//============================================================================*

		public int CalibrationPixels
			{
			get
				{
				Size CalibrationSize = new Size(Math.Abs(m_CalibrationStart.X - m_CalibrationEnd.X), Math.Abs(m_CalibrationStart.Y - m_CalibrationEnd.Y));

				int nPixels = (int) Math.Sqrt(Math.Pow(CalibrationSize.Width, 2) + Math.Pow(CalibrationSize.Height, 2));

				return (nPixels);
				}
			}

		//============================================================================*
		// CalibrationStart Property
		//============================================================================*

		public Point CalibrationStart
			{
			get
				{
				return (m_CalibrationStart);
				}
			set
				{
				m_CalibrationStart = value;
				}
			}

		//============================================================================*
		// Date Property
		//============================================================================*

		public DateTime Date
			{
			get
				{
				return (m_Date);
				}
			set
				{
				m_Date = value;
				}
			}

		//============================================================================*
		// DefaultAimPointColor Property
		//============================================================================*

		public static Color DefaultAimPointColor
			{
			get
				{
				return (sm_DefaultAimPointColor);
				}
			}

		//============================================================================*
		// DefaultScaleBackcolor Property
		//============================================================================*

		public static Color DefaultScaleBackcolor
			{
			get
				{
				return (sm_DefaultScaleBackcolor);
				}
			}

		//============================================================================*
		// DefaultScaleForecolor Property
		//============================================================================*

		public static Color DefaultScaleForecolor
			{
			get
				{
				return (sm_DefaultScaleForecolor);
				}
			}

		//============================================================================*
		// DefaultExtremesColor Property
		//============================================================================*

		public static Color DefaultExtremesColor
			{
			get
				{
				return (sm_DefaultExtremesColor);
				}
			}

		//============================================================================*
		// DefaultGroupBoxColor Property
		//============================================================================*

		public static Color DefaultGroupBoxColor
			{
			get
				{
				return (sm_DefaultGroupBoxColor);
				}
			}

		//============================================================================*
		// DefaultOffsetColor Property
		//============================================================================*

		public static Color DefaultOffsetColor
			{
			get
				{
				return (sm_DefaultOffsetColor);
				}
			}

		//============================================================================*
		// DefaultReticleColor Property
		//============================================================================*

		public static Color DefaultReticleColor
			{
			get
				{
				return (sm_DefaultReticleColor);
				}
			}

		//============================================================================*
		// DefaultShotColor Property
		//============================================================================*

		public static Color DefaultShotColor
			{
			get
				{
				return (sm_DefaultShotColor);
				}
			}

		//============================================================================*
		// DefaultShotForecolor Property
		//============================================================================*

		public static Color DefaultShotForecolor
			{
			get
				{
				return (sm_DefaultShotForecolor);
				}
			}

		//============================================================================*
		// Event Property
		//============================================================================*

		public string Event
			{
			get
				{
				return (m_strEvent);
				}
			set
				{
				m_strEvent = value;
				}
			}

		//============================================================================*
		// ExtremesColor Property
		//============================================================================*

		public Color ExtremesColor
			{
			get
				{
				return (m_ExtremesColor);
				}
			set
				{
				m_ExtremesColor = value;
				}
			}

		//============================================================================*
		// Firearm Property
		//============================================================================*

		public cFirearm Firearm
			{
			get
				{
				return (m_Firearm);
				}
			set
				{
				m_Firearm = value;
				}
			}

		//============================================================================*
		// GroupBox Property
		//============================================================================*

		public Rectangle GroupBox
			{
			get
				{
				Point UpperLeft = new Point(1080, 768);
				Point LowerRight = new Point();

				Rectangle GroupBoxRect = new Rectangle();

				if (Calibrated)
					{
					foreach (Point Shot in m_ShotList)
						{
						if (Shot.X < UpperLeft.X)
							UpperLeft.X = Shot.X;

						if (Shot.X > LowerRight.X)
							LowerRight.X = Shot.X;

						if (Shot.Y < UpperLeft.Y)
							UpperLeft.Y = Shot.Y;

						if (Shot.Y > LowerRight.Y)
							LowerRight.Y = Shot.Y;
						}

					GroupBoxRect.X = UpperLeft.X;
					GroupBoxRect.Y = UpperLeft.Y;
					GroupBoxRect.Width = LowerRight.X - GroupBoxRect.X;
					GroupBoxRect.Height = LowerRight.Y - GroupBoxRect.Y;
					}

				return (GroupBoxRect);
				}
			}

		//============================================================================*
		// GroupBoxColor Property
		//============================================================================*

		public Color GroupBoxColor
			{
			get
				{
				return (m_GroupBoxColor);
				}
			set
				{
				m_GroupBoxColor = value;
				}
			}

		//============================================================================*
		// GroupBoxString Property
		//============================================================================*

		public string GroupBoxString(cDataFiles DataFiles)
			{
			string strGroupFormat = "{0:F";
			strGroupFormat += String.Format("{0:G0}", DataFiles.Preferences.GroupDecimals);
			strGroupFormat += "} {1}";

			Rectangle GroupBoxRect = GroupBox;

			double dWidth = 0.0;
			double dHeight = 0.0;

			if (DataFiles.Preferences.MetricGroups)
				{
				if (PixelsPerCentimeter > 0.0)
					{
					dWidth = (double) ((double) GroupBoxRect.Width / (double) PixelsPerCentimeter);
					dHeight = (double) ((double) GroupBoxRect.Height / (double) PixelsPerCentimeter);
					}
				}
			else
				{
				if (PixelsPerInch > 0.0)
					{
					dWidth = (double) ((double) GroupBoxRect.Width / (double) PixelsPerInch);
					dHeight = (double) ((double) GroupBoxRect.Height / (double) PixelsPerInch);
					}
				}

			string strGroupBox = String.Format(strGroupFormat, dWidth, DataFiles.MetricString(cDataFiles.eDataType.GroupSize));
			strGroupBox += " x ";
			strGroupBox += String.Format(strGroupFormat, dHeight, DataFiles.MetricString(cDataFiles.eDataType.GroupSize));

			return (strGroupBox);
			}

		//============================================================================*
		// GroupExtremes()
		//============================================================================*

		public void GroupExtremes(out Point Extremes1, out Point Extremes2)
			{
			Extremes1 = Point.Empty;
			Extremes2 = Point.Empty;

			double dCheckGroupSize = 0.0;

			int nShotNum = 0;

			if (Calibrated)
				{
				foreach (Point Shot in m_ShotList)
					{
					for (int i = 0; i < m_ShotList.Count; i++)
						{
						if (i == nShotNum)
							continue;

						Point CheckShotShot = m_ShotList[i];

						double dGroupSize = Math.Sqrt(Math.Pow(Math.Abs(Shot.X - CheckShotShot.X), 2) + Math.Pow(Math.Abs(Shot.Y - CheckShotShot.Y), 2));

						if (dGroupSize > dCheckGroupSize)
							{
							Extremes1 = Shot;
							Extremes2 = CheckShotShot;

							dCheckGroupSize = dGroupSize;
							}
						}

					nShotNum++;
					}
				}
			}

		//============================================================================*
		// GroupMils Property
		//============================================================================*

		public double GroupMils
			{
			get
				{
				return (cConversions.MOAToMils(GroupMOA));
				}
			}

		//============================================================================*
		// GroupMOA Property
		//============================================================================*

		public double GroupMOA
			{
			get
				{
				double dMOA = 0.0;

				if (m_nRange > 0)
					dMOA = GroupSize / ((m_nRange / 100.0) * 1.047);

				return (dMOA);
				}
			}

		//============================================================================*
		// GroupSize Property
		//============================================================================*

		public double GroupSize
			{
			get
				{
				m_dGroupSize = 0.0;

				int nShotNum = 0;

				if (Calibrated)
					{
					foreach (Point Shot in m_ShotList)
						{
						for (int i = 0; i < m_ShotList.Count; i++)
							{
							if (i == nShotNum)
								continue;

							Point CheckShotShot = m_ShotList[i];

							double dGroupSize = Math.Sqrt(Math.Pow(Math.Abs(Shot.X - CheckShotShot.X), 2) + Math.Pow(Math.Abs(Shot.Y - CheckShotShot.Y), 2));

							if (dGroupSize > m_dGroupSize)
								m_dGroupSize = dGroupSize;
							}

						nShotNum++;
						}

					m_dGroupSize /= PixelsPerInch;
					}

				return (m_dGroupSize);
				}
			}

		//============================================================================*
		// Image Property
		//============================================================================*

		public Bitmap Image
			{
			get
				{
				return (m_TargetImage);
				}
			set
				{
				m_TargetImage = value;

				m_dCalibrationLength = 0.0;
				m_CalibrationStart = Point.Empty;
				m_CalibrationEnd = Point.Empty;

				m_ShotList.Clear();
				}
			}

		//============================================================================*
		// Location Property
		//============================================================================*

		public string Location
			{
			get
				{
				return (m_strLocation);
				}
			set
				{
				m_strLocation = value;
				}
			}

		//============================================================================*
		// MeanOffset Property
		//============================================================================*

		public PointF MeanOffset
			{
			get
				{
				PointF OffsetPoint = new PointF(0.0f, 0.0f);

				if (m_AimPoint.X != 0 && AimPoint.Y != 0 && m_ShotList.Count != 0 && PixelsPerInch != 0)
					{
					foreach (Point Shot in m_ShotList)
						{
						OffsetPoint.X += (Shot.X - m_AimPoint.X);
						OffsetPoint.Y += (m_AimPoint.Y - Shot.Y);
						}

					OffsetPoint.X /= (float) m_ShotList.Count;
					OffsetPoint.Y /= (float) m_ShotList.Count;

					OffsetPoint.X /= (float) PixelsPerInch;
					OffsetPoint.Y /= (float) PixelsPerInch;
					}

				return (OffsetPoint);
				}
			}

		//============================================================================*
		// MeanOffsetString()
		//============================================================================*

		public string MeanOffsetString(cDataFiles DataFiles)
			{
			string strGroupFormat = "{0:F";
			strGroupFormat += String.Format("{0:G0}", DataFiles.Preferences.GroupDecimals);
			strGroupFormat += "} {1}";

			string strOffset = String.Format(strGroupFormat, Math.Abs(DataFiles.StandardToMetric(MeanOffset.X, cDataFiles.eDataType.GroupSize)), DataFiles.MetricString(cDataFiles.eDataType.GroupSize));

			if (Math.Round(MeanOffset.X, DataFiles.Preferences.DimensionDecimals) == 0.0)
				strOffset += " Horiz.";
			else
				{
				if (MeanOffset.X < 0)
					strOffset += " Left";
				else
					strOffset += " Right";
				}

			strOffset += " x ";

			strOffset += String.Format(strGroupFormat, Math.Abs(DataFiles.StandardToMetric(MeanOffset.Y, cDataFiles.eDataType.GroupSize)), DataFiles.MetricString(cDataFiles.eDataType.GroupSize));

			if (Math.Round(MeanOffset.Y, DataFiles.Preferences.DimensionDecimals) == 0.0)
				strOffset += " Vert.";
			else
				{
				if (MeanOffset.Y > 0)
					strOffset += " High";
				else
					strOffset += " Low";
				}

			return (strOffset);
			}

		//============================================================================*
		// MinCalibrationLength Property
		//============================================================================*

		public double MinCalibrationLength
			{
			get
				{
				return (cm_dMinCalibrationLength);
				}
			}

		//============================================================================*
		// MinCalibrationPixels Property
		//============================================================================*

		public int MinCalibrationPixels
			{
			get
				{
				return (cm_nMinCalibrationPixels);
				}
			}

		//============================================================================*
		// MinImageHeight Property
		//============================================================================*

		public int MinImageHeight
			{
			get
				{
				return (cm_nMinImageHeight);
				}
			}

		//============================================================================*
		// MinImageWidth Property
		//============================================================================*

		public int MinImageWidth
			{
			get
				{
				return (cm_nMinImageWidth);
				}
			}

		//============================================================================*
		// Notes Property
		//============================================================================*

		public string Notes
			{
			get
				{
				return (m_strNotes);
				}
			set
				{
				m_strNotes = value;
				}
			}

		//============================================================================*
		// NumShots Property
		//============================================================================*

		public int NumShots
			{
			get
				{
				return (m_ShotList.Count);
				}
			}

		//============================================================================*
		// OffsetColor Property
		//============================================================================*

		public Color OffsetColor
			{
			get
				{
				return (m_OffsetColor);
				}
			set
				{
				m_OffsetColor = value;
				}
			}

		//============================================================================*
		// OffsetLength()
		//============================================================================*

		public double OffsetLength(Point Shot)
			{
			double dLength = Math.Sqrt(Math.Pow(Math.Abs(m_AimPoint.X - Shot.X), 2) + Math.Pow(Math.Abs(m_AimPoint.Y - Shot.Y), 2));

			dLength /= PixelsPerInch;

			return (dLength);
			}

		//============================================================================*
		// OffsetMils()
		//============================================================================*

		public double OffsetMils(Point Shot)
			{
			double dMils = cConversions.MOAToMils(OffsetMOA(Shot));

			return (dMils);
			}

		//============================================================================*
		// OffsetMOA()
		//============================================================================*

		public double OffsetMOA(Point Shot)
			{
            double dMOA = 0.0;

            if (m_nRange > 0)
                dMOA = OffsetLength(Shot) / ((m_nRange / 100.0) * 1.047);

            return (dMOA);
			}

		//============================================================================*
		// OffsetString()
		//============================================================================*

		public string OffsetString(cDataFiles DataFiles, Point Shot)
			{
			string strOffset = "";

			double dXOffset = OffsetX(Shot);
			double dYOffset = OffsetY(Shot);

			string strGroupFormat = "{0:F";
			strGroupFormat += String.Format("{0:G0}", DataFiles.Preferences.GroupDecimals);
			strGroupFormat += "}";

			strOffset = String.Format(strGroupFormat, Math.Abs(DataFiles.StandardToMetric(dXOffset, cDataFiles.eDataType.GroupSize)));
			strOffset += " ";
			strOffset += DataFiles.MetricString(cDataFiles.eDataType.GroupSize);

			if (dXOffset == 0.0)
				strOffset += "Horiz.";
			else
				{
				if (dXOffset > 0.0)
					strOffset += "Right";
				else
					strOffset += "Left";
				}

			strOffset += " x ";
			strOffset += String.Format(strGroupFormat, Math.Abs(DataFiles.StandardToMetric(dYOffset, cDataFiles.eDataType.GroupSize)));
			strOffset += " ";
			strOffset += DataFiles.MetricString(cDataFiles.eDataType.GroupSize);

			if (dYOffset == 0.0)
				strOffset += "Vert.";
			else
				{
				if (dYOffset < 0.0)
					strOffset += "High";
				else
					strOffset += "Low";
				}

			return (strOffset);
			}

		//============================================================================*
		// OffsetX()
		//============================================================================*

		public double OffsetX(Point Shot)
			{
			return ((double) (Shot.X - m_AimPoint.X) / (double) PixelsPerInch);
			}

		//============================================================================*
		// OffsetY()
		//============================================================================*

		public double OffsetY(Point Shot)
			{
			return ((double) (Shot.Y - m_AimPoint.Y) / (double) PixelsPerInch);
			}

		//============================================================================*
		// PixelsPerCentimeter Property
		//============================================================================*

		public int PixelsPerCentimeter
			{
			get
				{
				double dCalibrationLength = cConversions.InchesToCentimeters(m_dCalibrationLength);

				int nPixelsPerCentimeter = (m_dCalibrationLength != 0.0) ? (int) ((double) CalibrationPixels / dCalibrationLength) : 0;

				return (nPixelsPerCentimeter);
				}
			}

		//============================================================================*
		// PixelsPerInch Property
		//============================================================================*

		public int PixelsPerInch
			{
			get
				{
				int nPixelsPerInch = (m_dCalibrationLength != 0.0) ? (int) ((double) CalibrationPixels / m_dCalibrationLength) : 0;

				return (nPixelsPerInch);
				}
			}

		//============================================================================*
		// Range Property
		//============================================================================*

		public int Range
			{
			get
				{
				return (m_nRange);
				}
			set
				{
				m_nRange = value;
				}
			}

		//============================================================================*
		// ReticleColor Property
		//============================================================================*

		public Color ReticleColor
			{
			get
				{
				return (m_ReticleColor);
				}
			set
				{
				m_ReticleColor = value;
				}
			}

		//============================================================================*
		// ScaleBackcolor Property
		//============================================================================*

		public Color ScaleBackcolor
			{
			get
				{
				return (m_ScaleBackcolor);
				}
			set
				{
				m_ScaleBackcolor = value;
				}
			}

		//============================================================================*
		// ScaleForecolor Property
		//============================================================================*

		public Color ScaleForecolor
			{
			get
				{
				return (m_ScaleForecolor);
				}
			set
				{
				m_ScaleForecolor = value;
				}
			}

		//============================================================================*
		// SetDefaultColors Property
		//============================================================================*

		public void SetDefaultColors()
			{
			m_AimPointColor = sm_DefaultAimPointColor;
			m_OffsetColor = sm_DefaultOffsetColor;
			m_ShotColor = sm_DefaultShotColor;
			m_ShotForecolor = sm_DefaultShotForecolor;
			m_ReticleColor = sm_DefaultReticleColor;
			m_ScaleForecolor = sm_DefaultScaleForecolor;
			m_ScaleBackcolor = sm_DefaultScaleBackcolor;
			m_ExtremesColor = sm_DefaultExtremesColor;
			m_GroupBoxColor = sm_DefaultGroupBoxColor;
			}

		//============================================================================*
		// SetPreferencesColors Property
		//============================================================================*

		public void SetPreferencesColors(cDataFiles Datafiles)
			{
			m_AimPointColor = Datafiles.Preferences.TargetAimPointColor;
			m_OffsetColor = Datafiles.Preferences.TargetOffsetColor;
			m_ShotColor = Datafiles.Preferences.TargetShotColor;
			m_ShotForecolor = Datafiles.Preferences.TargetShotForecolor;
			m_ReticleColor = Datafiles.Preferences.TargetReticleColor;
			m_ScaleForecolor = Datafiles.Preferences.TargetScaleForecolor;
			m_ScaleBackcolor = Datafiles.Preferences.TargetScaleBackcolor;
			m_ExtremesColor = Datafiles.Preferences.TargetExtremesColor;
			m_GroupBoxColor = Datafiles.Preferences.TargetGroupBoxColor;
			}

		//============================================================================*
		// Shooter Property
		//============================================================================*

		public string Shooter
			{
			get
				{
				return (m_strShooter);
				}
			set
				{
				m_strShooter = value;
				}
			}

		//============================================================================*
		// ShotColor Property
		//============================================================================*

		public Color ShotColor
			{
			get
				{
				return (m_ShotColor);
				}
			set
				{
				m_ShotColor = value;
				}
			}

		//============================================================================*
		// ShotForecolor Property
		//============================================================================*

		public Color ShotForecolor
			{
			get
				{
				return (m_ShotForecolor);
				}
			set
				{
				m_ShotForecolor = value;
				}
			}

		//============================================================================*
		// ShotList Property
		//============================================================================*

		public List<Point> ShotList
			{
			get
				{
				return (m_ShotList);
				}
			}

		//============================================================================*
		// SuggestedFileName Property
		//============================================================================*

		public string SuggestedFileName
			{
			get
				{
				string strFileName = String.Format("{0:D4}{1:D2}{2:D2}", m_Date.Year, m_Date.Month, m_Date.Day);

				if (!String.IsNullOrEmpty(m_strShooter))
					{
					strFileName += " - ";
					strFileName += m_strShooter;
					}

				if (!String.IsNullOrEmpty(m_strEvent))
					{
					strFileName += " - ";
					strFileName += m_strEvent;
					}

				if (m_Firearm != null)
					{
					if (!String.IsNullOrEmpty(m_strEvent))
						strFileName += " with ";
					else
						strFileName += " - ";

					strFileName += m_Firearm.ToString();
					}
				else
					{
					if (m_Caliber != null)
						{
						strFileName += " - ";
						strFileName += m_Caliber.ToString();
						}
					}

				if (!String.IsNullOrEmpty(m_strLocation))
					{
					strFileName += " at ";
					strFileName += m_strLocation;
					}

				strFileName += ".rwt";

				return (strFileName);
				}
			}

		//============================================================================*
		// Synch() - All
		//============================================================================*

		public void Synch(cDataFiles Datafiles)
			{
			foreach (cFirearm Firearm in Datafiles.FirearmList)
				{
				if (Synch(Firearm))
					break;
				}

			foreach (cCaliber Caliber in Datafiles.CaliberList)
				{
				if (Synch(Caliber))
					break;
				}
			}

		//============================================================================*
		// Synch() - Firearm
		//============================================================================*

		public bool Synch(cFirearm Firearm)
			{
			if (Firearm != null && Firearm.CompareTo(m_Firearm) == 0)
				{
				m_Firearm = Firearm;

				return (true);
				}

			return (false);
			}

		//============================================================================*
		// Synch() - Caliber
		//============================================================================*

		public bool Synch(cCaliber Caliber)
			{
			if (Caliber != null && Caliber.CompareTo(m_Caliber) == 0)
				{
				m_Caliber = Caliber;

				return (true);
				}

			return (false);
			}
		}
	}
