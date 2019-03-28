﻿//============================================================================*
// cAboutDlg.cs
//
// Copyright © 2013-2014, Kevin S. Beebe
// All Rights Reserved
//============================================================================*

//============================================================================*
// .Net Using Statements
//============================================================================*

using System.Reflection;

using System.Windows.Forms;

using RWCommonLib.Registry;

//============================================================================*
// NameSpace
//============================================================================*

namespace ReloadersWorkShop
	{
	//============================================================================*
	// cAbout Class
	//============================================================================*

	public partial class AboutDialog : Form
		{
		public AboutDialog(cRWRegistry RWRegistry)
			{
			InitializeComponent();

			VersionLabel.Text = ProductName + " - v" + ProductVersion;

			Assembly Assembly = typeof(AboutDialog).Assembly;

			object[] Attribs = Assembly.GetCustomAttributes(typeof(AssemblyCopyrightAttribute), true);

			if (Attribs.Length > 0)
				CopyrightLabel.Text = ((AssemblyCopyrightAttribute) Attribs[0]).Copyright;

			if (RWRegistry != null)
				RegistrationLabel.Text = RWRegistry.ActivationStatusString;
			}
		}
	}
