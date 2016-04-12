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
using System.Windows.Forms;

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
		private static Color sm_DefaultReticleColor = Color.FromName("Black");
		private static Color sm_DefaultCalibrationForecolor = Color.FromName("Black");
		private static Color sm_DefaultCalibrationBackcolor = Color.FromName("Yellow");
		private static Color sm_DefaultExtremesColor = Color.FromName("White");

		//============================================================================*
		// Private Data Members
		//============================================================================*

		private int m_nBatchID = 0;
		private int m_nNumShots = 0;
		private int m_nRange = 100;

		private double m_dBulletDiameter = 0.0;
		private cCaliber m_Caliber = null;

		private double m_dCalibrationLength = cm_dMinCalibrationLength;
		private Point m_CalibrationStart = new Point(0, 0);
		private Point m_CalibrationEnd = new Point(0, 0);

		private double m_dGroupSize = 0.0;

		private Bitmap m_TargetImage = null;

		private Point m_AimPoint = new Point(0, 0);

		private List<Point> m_ShotList = new List<Point>();

		public Color m_AimPointColor = sm_DefaultAimPointColor;
		public Color m_OffsetColor = sm_DefaultOffsetColor;
		public Color m_ShotColor = sm_DefaultShotColor;
		public Color m_ReticleColor = sm_DefaultReticleColor;
		public Color m_CalibrationForecolor = sm_DefaultCalibrationForecolor;
		public Color m_CalibrationBackcolor = sm_DefaultCalibrationBackcolor;
		public Color m_ExtremesColor = sm_DefaultExtremesColor;

		//============================================================================*
		// cTarget() - Default Constructor
		//============================================================================*

		public cTarget()
			{
			}

		//============================================================================*
		// cTarget() - Copy Constructor
		//============================================================================*

		public cTarget(cTarget Target)
			{
			m_nBatchID = Target.m_nBatchID;
			m_nNumShots = Target.m_nNumShots;
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

			m_AimPointColor = Target.m_AimPointColor;
			m_OffsetColor = Target.m_OffsetColor;
			m_ShotColor = Target.m_ShotColor;
			m_ReticleColor = Target.m_ReticleColor;
			m_CalibrationForecolor = Target.m_CalibrationForecolor;
			m_CalibrationBackcolor = Target.m_CalibrationBackcolor;
			m_ExtremesColor = Target.m_ExtremesColor;
			}

		//============================================================================*
		// AddShot()
		//============================================================================*

		public bool AddShot(Point Shot)
			{
			if (m_nBatchID == 0 || (m_nBatchID != 0 && m_ShotList.Count < m_nNumShots))
				{
				m_ShotList.Add(Shot);

				return (true);
				}

			return (false);
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
		// CalibrationBackcolor Property
		//============================================================================*

		public Color CalibrationBackcolor
			{
			get
				{
				return (m_CalibrationBackcolor);
				}
			set
				{
				m_CalibrationBackcolor = value;
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
		// CalibrationForecolor Property
		//============================================================================*

		public Color CalibrationForecolor
			{
			get
				{
				return (m_CalibrationForecolor);
				}
			set
				{
				m_CalibrationForecolor = value;
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
		// DefaultCalibrationBackcolor Property
		//============================================================================*

		public static Color DefaultCalibrationBackcolor
			{
			get
				{
				return (sm_DefaultCalibrationBackcolor);
				}
			}

		//============================================================================*
		// DefaultCalibrationForecolor Property
		//============================================================================*

		public static Color DefaultCalibrationForecolor
			{
			get
				{
				return (sm_DefaultCalibrationForecolor);
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
		// NumShots Property
		//============================================================================*

		public int NumShots
			{
			get
				{
				return (m_nNumShots);
				}
			set
				{
				m_nNumShots = value;
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
