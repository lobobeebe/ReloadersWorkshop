//============================================================================*
// cOKButton.cs
//
// Copyright © 2013-2017, Kevin S. Beebe
// All Rights Reserved
//============================================================================*

//============================================================================*
// .Net Using Statements
//============================================================================*

using System.Windows.Forms;

//============================================================================*
// Namespace
//============================================================================*

namespace CommonLib.Controls
	{
	//============================================================================*
	// cOKButton Class
	//============================================================================*

	public class cOKButton : cButton
		{
		//============================================================================*
		// Public Enumerations
		//============================================================================*

		public enum eButtonTypes
			{
			OK = 0,
			Add,
			Update
			}

		//============================================================================*
		// Private Data Members
		//============================================================================*

		private eButtonTypes m_eType = eButtonTypes.OK;

		//============================================================================*
		// cOKButton() - Constructor
		//============================================================================*

		public cOKButton()
			{
			ButtonType = eButtonTypes.OK;

			DialogResult = DialogResult.OK;
			}

		//============================================================================*
		// ButtonType Property
		//============================================================================*

		public eButtonTypes ButtonType
			{
			get
				{
				return (m_eType);
				}
			set
				{
				m_eType = value;

				SetText();
				}
			}

		//============================================================================*
		// SetText()
		//============================================================================*

		public void SetText()
			{
			switch (ButtonType)
				{
				case eButtonTypes.OK:
					Text = "OK";

					ToolTip = "Click to accept changes and exit.";

					break;
				case eButtonTypes.Add:
					Text = "Add";

					ToolTip = "Click to add displayed data and exit.";

					break;
				case eButtonTypes.Update:
					Text = "Update";

					ToolTip = "Click to update with displayed data and exit.";

					break;
				}
			}
		}
	}
