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
			get { return (m_fPopulating); }
			set { m_fPopulating = value; }
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
		// Value Property
		//============================================================================*

		public string Value
			{
			get { return (m_strValue); }

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
			get { return (m_fValueOK); }
			protected set { m_fValueOK = value; }
			}

		//============================================================================*
		// Verify()
		//============================================================================*

		protected virtual bool Verify()
			{
			string strToolTip = m_strToolTip;

			m_fValueOK = true;

			if (Enabled && m_fRequired && m_strValue.Length == 0)
				{
				BackColor = Color.LightPink;

				m_fValueOK = false;

				strToolTip += "\n\nThis field must not be left blank.";
				}
			else
				BackColor = SystemColors.Window;

			if (m_strToolTip.Length > 0)
				m_ToolTip.SetToolTip(this, strToolTip);

			return (m_fValueOK);
			}
		}
	}
