//============================================================================*
// cIntegerValueTextBox.cs
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
	// cIntegerValueTextBox Class
	//============================================================================*

	public class cIntegerValueTextBox : TextBox
		{
		//============================================================================*
		// Private Data Members
		//============================================================================*

		private int m_nValue = 0;
		private int m_nMinValue = 0;
		private int m_nMaxValue = 0;

		private bool m_fRequired = false;

		private bool m_fPopulating = false;

		private bool m_fValueOK = true;

		private string m_strToolTip = "";

		private ToolTip m_ToolTip = new ToolTip();

		//============================================================================*
		// cIntegerValueTextBox() - Constructor
		//============================================================================*

		public cIntegerValueTextBox()
			{
			Populate();
			}

		//============================================================================*
		// FormatString Property
		//============================================================================*

		public string FormatString
			{
			get
				{
				string strFormat = "{0:G0}";

				return (strFormat);
				}
			}

		//============================================================================*
		// MaxValue Property
		//============================================================================*

		public int MaxValue
			{
			get { return (m_nMaxValue); }

			set
				{
				m_nMaxValue = value;

				Validate();
				}
			}

		//============================================================================*
		// MinValue Property
		//============================================================================*

		public int MinValue
			{
			get { return (m_nMinValue); }

			set
				{
				m_nMinValue = value;

				Validate();
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
			// Make sure it's a number
			//----------------------------------------------------------------------------*

			if (e.KeyChar != 8 && !char.IsDigit(e.KeyChar))
				{
				Console.Beep(1000, 100);

				e.Handled = true;
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
			if (m_fPopulating)
				return;

			if (Text.Length == 0)
				{
				Value = 0;

				SelectAll();
				}

			if (Text.Length == 2)
				{
				if (Text[0] == '0')
					{
					Text = Text.Substring(1);

					Select(1, 0);
					}
				}

			Int32.TryParse(Text, out m_nValue);

			Validate();

			base.OnTextChanged(e);
			}

		//============================================================================*
		// Populate()
		//============================================================================*

		private void Populate()
			{
			m_fPopulating = true;

			Text = String.Format(FormatString, m_nValue);

			m_fPopulating = false;

			Validate();
			}

		//============================================================================*
		// Required Property
		//============================================================================*

		public bool Required
			{
			get { return (m_fRequired); }

			set { m_fRequired = value; }
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

		public int Value
			{
			get { return (m_nValue); }

			set
				{
				m_nValue = value;

				Populate();

				Validate();
				}
			}

		//============================================================================*
		// ValueOK Property
		//============================================================================*

		public bool ValueOK
			{
			get { return (m_fValueOK); }
			}

		//============================================================================*
		// Validate()
		//============================================================================*

		private bool Validate()
			{
			string strToolTip = m_strToolTip;
			m_fValueOK = true;

			if (Enabled && (m_nValue < m_nMinValue || (m_nMaxValue > 0 && m_nValue > m_nMaxValue)))
				{
				BackColor = Color.LightPink;

				m_fValueOK = false;

				if (strToolTip.Length > 0)
					{
					if (m_nMaxValue > 0)
						{
						string strFormat = "\n\nValue MUST be between ";
						strFormat += FormatString;

						strToolTip += String.Format(strFormat, m_nMinValue);

						strToolTip += " and ";
						strToolTip += String.Format(FormatString, m_nMaxValue);

						strToolTip += " inclusive.";
						}
					else
						{
						string strFormat = "\n\nValue MUST be ";

						if (m_nMinValue > 0.0)
							strFormat += "at least ";
						else
							strFormat += "greater than ";

						strFormat += FormatString;

						strToolTip += String.Format(strFormat, m_nMinValue);

						strToolTip += " .";
						}

					m_ToolTip.SetToolTip(this, strToolTip);
					}
				}
			else
				{
				BackColor = SystemColors.Window;

				m_ToolTip.SetToolTip(this, m_strToolTip);
				}

			return (m_fValueOK);
			}
		}
	}
