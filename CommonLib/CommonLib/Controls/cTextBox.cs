//============================================================================*
// cTextBox.cs
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
	// cTextBox Class
	//============================================================================*

	public class cTextBox : TextBox
		{
		//============================================================================*
		// Private Data Members
		//============================================================================*

		private string m_strValue = "";

		private string m_strToolTip = "";

		private bool m_fRequired = false;

		private bool m_fPopulating = false;

		private bool m_fValueOK = true;

		private ToolTip m_ToolTip = null;

		private string m_strValidChars = "";

		//============================================================================*
		// cTextBox() - Constructor
		//============================================================================*

		public cTextBox()
			{
			Populate();
			}

		//============================================================================*
		// OnEnabledChanged()
		//============================================================================*

		protected override void OnEnabledChanged(EventArgs e)
			{
			base.OnEnabledChanged(e);

			Verify();
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
			// Make sure it's a valid character
			//----------------------------------------------------------------------------*

			if (e.KeyChar != 8)
				{
				if (!String.IsNullOrEmpty(m_strValidChars) && m_strValidChars.IndexOf(e.KeyChar) < 0)
					{
					Console.Beep(1000, 100);

					e.Handled = true;
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
		// OnTextChanged()
		//============================================================================*

		protected override void OnTextChanged(EventArgs e)
			{
			if (m_fPopulating)
				return;

			m_strValue = Text;

			Verify();

			base.OnTextChanged(e);
			}

		//============================================================================*
		// Populate()
		//============================================================================*

		protected virtual void Populate()
			{
			m_fPopulating = true;

			Text = m_strValue;

			m_fPopulating = false;

			Verify();
			}

		//============================================================================*
		// Populating Property
		//============================================================================*

		protected bool Populating
			{
			get
				{
				return (m_fPopulating);
				}
			set
				{
				m_fPopulating = value;
				}
			}

		//============================================================================*
		// Required Property
		//============================================================================*

		public bool Required
			{
			get
				{
				return (m_fRequired);
				}
			set
				{
				m_fRequired = value;
				Verify();
				}
			}

		//============================================================================*
		// ToolTip Property
		//============================================================================*

		public string ToolTip
			{
			get
				{
				return (m_strToolTip);
				}

			set
				{
				m_strToolTip = value;

				if (m_strToolTip != null && m_strToolTip.Length > 0)
					{
					if (m_ToolTip == null)
						{
						m_ToolTip = new ToolTip();

						m_ToolTip.ShowAlways = true;
						m_ToolTip.RemoveAll();
						}

					m_ToolTip.SetToolTip(this, m_strToolTip);
					}
				}
			}

		//============================================================================*
		// ValidChars Property
		//============================================================================*

		public string ValidChars
			{
			get
				{
				return (m_strValidChars);
				}

			set
				{
				m_strValidChars = value;
				}
			}

		//============================================================================*
		// Value Property
		//============================================================================*

		public string Value
			{
			get
				{
				return (m_strValue);
				}

			set
				{
				m_strValue = value;

				Verify();

				Populate();
				}
			}

		//============================================================================*
		// ValueOK Property
		//============================================================================*

		public bool ValueOK
			{
			get
				{
				return (m_fValueOK);
				}
			protected set
				{
				m_fValueOK = value;
				}
			}

		//============================================================================*
		// Verify()
		//============================================================================*

		protected virtual bool Verify()
			{
			string strToolTip = m_strToolTip;

			m_fValueOK = true;

			if (Enabled && m_fRequired && String.IsNullOrEmpty(m_strValue))
				{
				m_fValueOK = false;

				strToolTip += "\n\nThis field must not be left blank.";
				}
			else
				{
				if (!String.IsNullOrEmpty(m_strValidChars))
					{
					foreach (char chChar in m_strValue)
						{
						if (m_strValidChars.IndexOf(chChar) < 0)
							{
							m_fValueOK = false;

							strToolTip += "\n\nThis field contains invalid characters. Valid characters are ";
							strToolTip += m_strValidChars;
							}
						}
					}
				}

			if (!m_fValueOK)
				BackColor = Color.LightPink;
			else
				BackColor = SystemColors.Window;

			if (m_strToolTip.Length > 0)
				m_ToolTip.SetToolTip(this, strToolTip);

			return (m_fValueOK);
			}
		}
	}
