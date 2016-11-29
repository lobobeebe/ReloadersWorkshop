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
using System.Drawing.Printing;

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
		// cPrintObject() - Copy Constructor
		//============================================================================*

		public cPrintObject(cPrintObject PrintObj)
			{
			Copy(PrintObj);
			}

		//============================================================================*
		// Copy()
		//============================================================================*

		public void Copy(cPrintObject PrintObj)
			{
			m_fPrinted = PrintObj.m_fPrinted;
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
		// PrintReportTitle()
		//============================================================================*

		public static float PrintReportTitle(string strReportTitle, PrintPageEventArgs e,  Rectangle PageRect)
			{
			Font TitleFont = new Font("Trebuchet MS", 16, FontStyle.Bold);
			Font DataFont = new Font("Trebuchet MS", 8, FontStyle.Regular);

			float nY = PageRect.Top;

			string strText = DateTime.Now.ToShortDateString();

			e.Graphics.DrawString(strText, DataFont, Brushes.Black, PageRect.Left, nY);

			strText = DateTime.Now.ToShortTimeString();

			SizeF TextSize = e.Graphics.MeasureString(strText, DataFont);

			e.Graphics.DrawString(strText, DataFont, Brushes.Black, PageRect.Right - TextSize.Width, nY);

			strText = "Reloader's WorkShop";

			TextSize = e.Graphics.MeasureString(strText, TitleFont);

			e.Graphics.DrawString(strText, TitleFont, Brushes.Black, e.MarginBounds.Left + (e.MarginBounds.Width / 2) - (TextSize.Width / 2), nY);

			nY += TextSize.Height;

			strText = strReportTitle;

			TextSize = e.Graphics.MeasureString(strText, TitleFont);

			e.Graphics.DrawString(strText, TitleFont, Brushes.Black, e.MarginBounds.Left + (e.MarginBounds.Width / 2) - (TextSize.Width / 2), nY);

			nY += (int) TextSize.Height;

			return (nY);
			}
		}
	}
