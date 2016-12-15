using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CommonLib.Controls
	{
	public class cCancelButton : cButton
		{
		public cCancelButton()
			{
			ToolTip = "Click to cancel changes and exit.";

			Text = "Cancel";
			DialogResult = DialogResult.Cancel;
			}
		}
	}
