//============================================================================*
// cTransactionForm.cs
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
	// cDropDownTextBox Class
	//============================================================================*

	public class cDropDownTextBox : ComboBox
		{
		//============================================================================*
		// Private Data Members
		//============================================================================*

		private bool m_fValueOK = true;
		private bool m_fRequired = false;

		private bool m_fTextSet = false;

		private string m_strText = "";

		//============================================================================*
		// cDropDownTextBox() - Constructor
		//============================================================================*

		public cDropDownTextBox()
			{
			DropDownStyle = ComboBoxStyle.DropDown;

			Validate();
			}

		//============================================================================*
		// OnKeyDown()
		//============================================================================*

		protected override void OnKeyDown(KeyEventArgs e)
			{
			if (e.KeyCode == Keys.Delete)
				{
				string strText = Text.Substring(0, SelectionStart);

				Text = strText;

				SelectionStart = strText.Length;

				e.Handled = true;
				}

			base.OnKeyDown(e);
			}

		//============================================================================*
		// OnKeyPress()
		//============================================================================*

		protected override void OnKeyPress(KeyPressEventArgs e)
			{
			if (e.KeyChar >= 32)
				m_fTextSet = false;
			else
				m_fTextSet = true;

			if (e.KeyChar == 8)
				{
				if (SelectionStart > 0)
					{
					string strText = Text.Substring(0, SelectionStart - 1);

					Text = strText;

					SelectionStart = strText.Length;

					OnTextChanged((EventArgs)e);

					e.Handled = true;
					}
				}

			base.OnKeyPress(e);
			}
/*
		//============================================================================*
		// OnSelectedIndexChanged()
		//============================================================================*

		protected override void OnSelectedIndexChanged(EventArgs e)
			{
			if (SelectedIndex >= 0)
				{
				string strAddText = Items[SelectedIndex].ToString().Substring(SelectionStart);

				strAddText = strAddText.Substring(m_strText.Length);

				m_fTextSet = true;

				Text = m_strText + strAddText;

				SelectionStart = m_strText.Length;
				SelectionLength = Text.Length - strAddText.Length;
				}

			base.OnSelectedIndexChanged(e);
			}

		//============================================================================*
		// OnSelectedValueChanged()
		//============================================================================*

		protected override void OnSelectedValueChanged(EventArgs e)
			{
			if (SelectedValue != null)
				{
				string strAddText = (SelectedValue as string).Substring(SelectionStart);

				m_fTextSet = true;

				Text = strAddText;

				SelectionStart = m_strText.Length;
				SelectionLength = Text.Length - strAddText.Length;
				}

			base.OnSelectedValueChanged(e);
			}
*/
		//============================================================================*
		// OnTextChanged()
		//============================================================================*

		protected override void OnTextChanged(EventArgs e)
			{
			Validate();

			if (m_fTextSet)
				{
				m_fTextSet = false;

				Validate();

				base.OnTextChanged(e);

				return;
				}

			if (SelectionStart < Text.Length)
				m_strText = Text.Length > 0 ? Text.Substring(0, SelectionStart + 1) : "";
			else
				m_strText = Text;

			if (m_strText.Length > 0)
				{
				for (int i = 0; i < Items.Count; i++)
					{
					string strAddText = Items[i].ToString();

					if (m_strText.Length > 0 && m_strText.Length < strAddText.Length && m_strText.ToUpper() == strAddText.ToUpper().Substring(0, m_strText.Length))
						{
						strAddText = strAddText.Substring(m_strText.Length);

						m_fTextSet = true;

						string strFix = m_strText + strAddText;

						for(int ch =- 0;ch < strFix.Length;ch++)
							{
							if (Char.IsLetter(strFix[ch]))
								{
								if ((ch == 0 || strFix[ch-1] ==' ') && !Char.IsUpper(strFix[ch]))
									{
									if (ch == 0)
										strFix = char.ToUpper(strFix[ch]) + strFix.Substring(ch + 1);
									else
										{
										strFix = strFix.Substring(0, ch - 1) + char.ToUpper(strFix[ch]) + strFix.Substring(ch + 1);
										}
									}
								}
							}

						Text = strFix;

						SelectionStart = m_strText.Length;
						SelectionLength = strAddText.Length;
						}
					}
				}

			base.OnTextChanged(e);
			}

		//============================================================================*
		// Required Property
		//============================================================================*

		public bool Required
			{
			get { return (m_fRequired); }

			set
				{
				m_fRequired = value;

				Validate();
				}
			}

		//============================================================================*
		// Validate()
		//============================================================================*

		private void Validate()
			{
			if (m_fRequired && Text.Length == 0)
				{
				BackColor = Color.LightPink;

				m_fValueOK = false;
				}
			else
				{
				m_fValueOK = true;

				BackColor = SystemColors.Window;
				}
			}

		//============================================================================*
		// Value Property
		//============================================================================*

		public string Value
			{
			get { return (Text); }

			set
				{
				Text = value;

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
		}
	}

