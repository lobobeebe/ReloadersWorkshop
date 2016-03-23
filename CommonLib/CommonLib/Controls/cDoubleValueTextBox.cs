//============================================================================*
// cDoubleValueTextBox.cs
//
// Copyright © 2013-2014, Kevin S. Beebe
// All Rights Reserved
//============================================================================*

//============================================================================*
// .Net Using Statements
//============================================================================*

using System;
using System.Drawing;
using System.Windows.Forms;

//============================================================================*
// NameSpace
//============================================================================*

namespace CommonLib.Controls
	{
	//============================================================================*
	// cDoubleValueTextBox Class
	//============================================================================*

	public class cDoubleValueTextBox : TextBox
		{
		//============================================================================*
		// Private Data Members
		//============================================================================*

		private double m_dValue = 0.0;
		private double m_dMinValue = 0.0;
		private double m_dMaxValue = 0.0;

		private int m_nNumDecimals = 0;
		private bool m_fPopulating = false;

		private bool m_fValueOK = true;

		private bool m_fZeroAllowed = true;

		private string m_strToolTip = "";

		private ToolTip m_ToolTip = new ToolTip();

		//============================================================================*
		// cDoubleValueTextBox() - Constructor
		//============================================================================*

		public cDoubleValueTextBox()
			{
			Populate();

			}

		//============================================================================*
		// FormatString Property
		//============================================================================*

		public virtual string FormatString
			{
			get
				{
				string strFormat = "{0:F";
				strFormat += String.Format("{0:G0}", m_nNumDecimals);
				strFormat += "}";

				return (strFormat);
				}
			}

		//============================================================================*
		// MaxValue Property
		//============================================================================*

		public double MaxValue
			{
			get { return (m_dMaxValue); }

			set
				{
				m_dMaxValue = Math.Round(value, m_nNumDecimals);

				Validate();
				}
			}

		//============================================================================*
		// MinValue Property
		//============================================================================*

		public double MinValue
			{
			get { return (m_dMinValue); }

			set
				{
				m_dMinValue = Math.Round(value, m_nNumDecimals);

				Validate();
				}
			}

		//============================================================================*
		// NumDecimals Property
		//============================================================================*

		public int NumDecimals
			{
			get { return (m_nNumDecimals); }

			set
				{
				m_nNumDecimals = value;

				MaxValue = Math.Round(m_dMaxValue, m_nNumDecimals);
				MinValue = Math.Round(m_dMinValue, m_nNumDecimals);

				Populate();
				}
			}

		//============================================================================*
		// OnEnabledChanged()
		//============================================================================*

		protected override void OnEnabledChanged(EventArgs e)
			{
			base.OnEnabledChanged(e);

			Validate();
			}

		//============================================================================*
		// OnGotFocus()
		//============================================================================*

		protected override void OnGotFocus(EventArgs e)
			{
			base.OnGotFocus(e);

			Select(0, Text.Length);
			}

		//============================================================================*
		// OnKeyPress()
		//============================================================================*

		protected override void OnKeyPress(KeyPressEventArgs e)
			{
			//----------------------------------------------------------------------------*
			// See if it's a paste
			//----------------------------------------------------------------------------*

			if (e.KeyChar == 22)
				{
				base.OnKeyPress(e);

				return;
				}

			//----------------------------------------------------------------------------*
			// Make sure it's a number or decimal point
			//----------------------------------------------------------------------------*

			if (e.KeyChar != 8 && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != '-')
				{
				Console.Beep(1000, 100);

				e.Handled = true;
				}

			//----------------------------------------------------------------------------*
			// Only allow one decimal point
			//----------------------------------------------------------------------------*

			if (e.KeyChar == '.')
				{
				/*				if (Text[SelectionStart - (Text.Length > 0 ? 1 : 0)] == '.')
									{
									SelectionStart++;

									e.Handled = true;
									}
								else*/
					{
					if (m_nNumDecimals == 0 || (Text.IndexOf('.') > -1 && SelectionLength != Text.Length))
						{
						Console.Beep(1000, 100);

						e.Handled = true;
						}
					}
				}

			//----------------------------------------------------------------------------*
			// Only allow NumDecimals digits after the decimal
			//----------------------------------------------------------------------------*

			if (char.IsDigit(e.KeyChar))
				{
				int nDecimal = Text.IndexOf('.');

				if (nDecimal > -1)
					{
					if (SelectionStart > nDecimal + m_nNumDecimals)
						{
						Console.Beep(1000, 100);

						e.Handled = true;
						}
					}
				else
					{
					if (Text.Length - SelectionLength == MaxLength - m_nNumDecimals - ((m_nNumDecimals > 0) ? 1 : 0))
						{
						Console.Beep(1000, 100);

						e.Handled = true;
						}
					}
				}

			base.OnKeyPress(e);
			}

		//============================================================================*
		// OnLostFocus()
		//============================================================================*

		protected override void OnLostFocus(EventArgs e)
			{
			base.OnLostFocus(e);

			Populate();
			}

		//============================================================================*
		// OnMouseClick()
		//============================================================================*

		protected override void OnMouseClick(MouseEventArgs e)
			{
			base.OnMouseClick(e);

			Select(0, Text.Length);
			}

		//============================================================================*
		// OnTextChanged()
		//============================================================================*

		protected override void OnTextChanged(EventArgs e)
			{
			if (!m_fPopulating)
				{
				int Start = SelectionStart;

				if (Text.Length == 0)
					{
					Value = 0.0;

					SelectAll();
					}

				if (Text[0] == '.')
					{
					if (Text.Length == 1)
						{
						Text = "0.";

						Select(2, 0);
						}
					else
						{
						Text = "0" + Text;

						Select(Start + 1, 0);
						}
					}

				Double.TryParse(Text, out m_dValue);

				Validate();

				Start = SelectionStart;

				SelectionStart = Start;

				base.OnTextChanged(e);
				}
			}

		//============================================================================*
		// Populate()
		//============================================================================*

		private void Populate()
			{
			m_fPopulating = true;

			Text = String.Format(FormatString, m_dValue);

			m_fPopulating = false;

			Validate();
			}

		//============================================================================*
		// Populating Property
		//============================================================================*

		protected bool Populating
			{
			get { return (m_fPopulating); }
			set { m_fPopulating = value; }
			}

		//============================================================================*
		// ToolTip Property
		//============================================================================*

		public string ToolTip
			{
			get { return (m_strToolTip); }

			set
				{
				m_strToolTip = value;

				m_ToolTip.ShowAlways = true;
				m_ToolTip.RemoveAll();
				m_ToolTip.SetToolTip(this, m_strToolTip);

				Validate();
				}
			}

		//============================================================================*
		// Value Property
		//============================================================================*

		public Double Value
			{
			get { return (Math.Round(m_dValue, m_nNumDecimals)); }

			set
				{
				m_dValue = value;

				Populate();
				}
			}

		//============================================================================*
		// ValueOK Property
		//============================================================================*

		public bool ValueOK
			{
			get { return (m_fValueOK); }
			protected set { m_fValueOK = value; }
			}

		//============================================================================*
		// Validate()
		//============================================================================*

		private bool Validate()
			{
			string strToolTip = m_strToolTip;
			double dValue = Math.Round(m_dValue, m_nNumDecimals);
			m_fValueOK = true;
			
			if (Enabled && (dValue < m_dMinValue || (m_dMaxValue > 0.0 && dValue > m_dMaxValue)))
				{
				m_fValueOK = false;

				if (strToolTip.Length > 0)
					{
					if (m_dMaxValue > 0.0)
						{
						if (m_dMaxValue == m_dMinValue)
							{
							string strFormat = "\n\nValue must be ";
							strFormat += FormatString;

							strToolTip += String.Format(strFormat, m_dMinValue);
							}
						else
							{
							string strFormat = "\n\nValue must be between ";
							strFormat += FormatString;

							strToolTip += String.Format(strFormat, m_dMinValue);

							strToolTip += " and ";
							strToolTip += String.Format(FormatString, m_dMaxValue);
							strToolTip += " inclusive.";
							}
						}
					else
						{
						string strFormat = "\n\nValue must be ";

						if (m_dMinValue > 0.0)
							strFormat += "at least ";
						else
							strFormat += "greater than ";

						strFormat += FormatString;
						strFormat += ".";

						strToolTip += String.Format(strFormat, m_dMinValue);
						}
					}
				}

			if (m_strToolTip.Length > 0)
				m_ToolTip.SetToolTip(this, strToolTip);

			if (Enabled && !m_fValueOK)
				BackColor = Color.LightPink;
			else
				BackColor = SystemColors.Window;

			return (m_fValueOK);
			}

		//============================================================================*
		// ZeroAllowed Property
		//============================================================================*

		public bool ZeroAllowed
			{
			get { return (m_fZeroAllowed); }
			set { m_fZeroAllowed = value; }
			}
		}
	}
