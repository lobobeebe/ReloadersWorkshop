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

					OffsetPoint.X /= PixelsPerInch;
					OffsetPoint.Y /= PixelsPerInch;

					OffsetPoint.X /= m_ShotList.Count;
					OffsetPoint.Y /= m_ShotList.Count;
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
		// ShotList Property
		//============================================================================*

		public List<Point> ShotList
			{
			get
				{
				return (m_ShotList);
				}
			}
		}
	}
