//============================================================================*
// cButton.cs
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
	// cButton Class
	//============================================================================*

	public class cButton : Button
		{
		//============================================================================*
		// Private Data Members
		//============================================================================*

		private bool m_fShowToolTips = true;
		private ToolTip m_ToolTip = null;

		private string m_strToolTip = "";

		//============================================================================*
		// cButton() - Default Constructor
		//============================================================================*

		public cButton()
			{
			}

		//============================================================================*
		// ShowToolTips Property
		//============================================================================*

		public bool ShowToolTips
			{
			get
				{
				return (m_fShowToolTips);
				}
			set
				{
				m_fShowToolTips = value;

				ToolTip = m_fShowToolTips ? m_strToolTip : "";
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

				if (m_fShowToolTips)
					{
					if (m_ToolTip == null)
						m_ToolTip = new ToolTip();

					m_ToolTip.ShowAlways = true;
					m_ToolTip.RemoveAll();
					m_ToolTip.SetToolTip(this, m_strToolTip);
					}
				else
					{
					if (m_ToolTip != null)
						{
						m_ToolTip.ShowAlways = false;
						m_ToolTip.RemoveAll();
						}
					}
				}
			}
		}
	}
