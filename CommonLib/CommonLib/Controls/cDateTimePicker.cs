using System.Drawing;
using System.Windows.Forms;

namespace CommonLib.Controls
	{
	public class cDateTimePicker : DateTimePicker
		{
		private Color m_BackColor = Control.DefaultBackColor;

		public cDateTimePicker()
			{
			m_BackColor = BackColor;
			}

		public Color DateBackColor
			{
			get
				{
				return base.BackColor;
				}
			set
				{
				base.BackColor = value;

				if (m_BackColor != value)
					{
					m_BackColor = value;

					Invalidate();
					}
				}
			}
		protected override void WndProc(ref Message m)
			{
			if (m.Msg == 0x14)
				{
				Graphics g = Graphics.FromHdc(m.WParam);

				g.FillRectangle(new SolidBrush(m_BackColor), ClientRectangle);

				g.Dispose();

				return;
				}

			base.WndProc(ref m);
			}
		}
	}
