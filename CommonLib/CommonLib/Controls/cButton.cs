using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonLib.Controls
	{
	public class cButton : Button
		{
		private ToolTip m_ToolTip = null;

		private string m_strToolTip = "";

		public cButton()
			{
			}

		public string ToolTip
			{
			get
				{
				return (m_strToolTip);
				}
			set
				{
				m_strToolTip = value;

				if (m_ToolTip == null)
					m_ToolTip = new ToolTip();

				m_ToolTip.ShowAlways = true;
				m_ToolTip.RemoveAll();
				m_ToolTip.SetToolTip(this, m_strToolTip);
				}
			}
		}
	}
