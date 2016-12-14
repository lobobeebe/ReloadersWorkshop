using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace RWCommonLib
	{
	public class cViewButton : Button
		{
		public cViewButton()
			{
			Image = Properties.Resources.ViewButton;
			Text = "";

			Size = new System.Drawing.Size(Image.Width, Image.Height);

			BackgroundImageLayout = ImageLayout.None;

			FlatStyle = FlatStyle.Flat;
			FlatAppearance.BorderSize = 0;
			}
		}
	}
