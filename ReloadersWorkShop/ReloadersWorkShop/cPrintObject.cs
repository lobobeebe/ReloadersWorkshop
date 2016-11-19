//============================================================================*
// cPrintObject.cs
//
// Copyright © 2013-2014, Kevin S. Beebe
// All Rights Reserved
//============================================================================*

//============================================================================*
// .Net Using Statements
//============================================================================*

using System;
using System.Drawing;

//============================================================================*
// Namespace
//============================================================================*

namespace ReloadersWorkShop
	{
	//============================================================================*
	// cPrintObject Class
	//============================================================================*

	[Serializable]
	public class cPrintObject
		{
		//============================================================================*
		// Private Data Members
		//============================================================================*

		private bool m_fPrinted = false;

		//============================================================================*
		// cPrintObject() - Constructor
		//============================================================================*

		public cPrintObject()
			{
			}

		//============================================================================*
		// Printed Property
		//============================================================================*

		public bool Printed
			{
			get { return(m_fPrinted); }
			set { m_fPrinted = value; }
			}

		//============================================================================*
		// Printed Property
		//============================================================================*

		public static float PrintReportTitle(string strReportTitle, Rectangle PageRect, Graphics g)
			{
			Font TitleFont = new Font("Trebuchet MS", 16, FontStyle.Bold);
			Font DataFont = new Font("Trebuchet MS", 8, FontStyle.Regular);

			float nY = PageRect.Top;

			string strText = DateTime.Now.ToShortDateString();

			g.DrawString(strText, DataFont, Brushes.Black, PageRect.Left, nY);

			strText = DateTime.Now.ToLongTimeString();

			SizeF TextSize = g.MeasureString(strText, DataFont);

			g.DrawString(strText, DataFont, Brushes.Black, PageRect.Right - TextSize.Width, nY);

			strText = "Reloader's WorkShop";

			TextSize = g.MeasureString(strText, TitleFont);

			g.DrawString(strText, TitleFont, Brushes.Black, PageRect.Left + (PageRect.Width / 2) - (TextSize.Width / 2), nY);

			nY += TextSize.Height;

			strText = strReportTitle;

			TextSize = g.MeasureString(strText, TitleFont);

			g.DrawString(strText, TitleFont, Brushes.Black, PageRect.Left + (PageRect.Width / 2) - (TextSize.Width / 2), nY);

			nY += (int) (TextSize.Height * 1.5);

			return (nY);
			}
		}
	}
