//============================================================================*
// Program.cs
//
// Copyright © 2013-2017, Kevin S. Beebe
// All Rights Reserved
//============================================================================*

//============================================================================*
// .Net Using Statements
//============================================================================*

using System;
using System.Diagnostics;
using System.Windows.Forms;

//============================================================================*
// Application Specific Using Statements
//============================================================================*

using RWCommonLib.Updates;

//============================================================================*
// NameSpace
//============================================================================*

namespace ReloadersWorkShopUpdater
	{
	//============================================================================*
	// Program Class
	//============================================================================*

	static class Program
		{
		//============================================================================*
		// Main() - Entry Point for app
		//============================================================================*

		[STAThread]
		static void Main(string[] args)
			{
			bool fInstall = false;

			foreach (string strArg in args)
				{
				if (strArg.ToUpper() == "/INSTALL")
					fInstall = true;
				}
			
			if (fInstall)
				{
				//----------------------------------------------------------------------------*
				// Start the launcher and exit
				//----------------------------------------------------------------------------*

				Process.Start("ReloadersWorkShopLauncher.exe");

				return;
				}

			//----------------------------------------------------------------------------*
			// Check for updates
			//----------------------------------------------------------------------------*

			cRWUpdater RWUpdater = new cRWUpdater();

			if (!RWUpdater.UpdateFiles())
				Process.Start("ReloadersWorkShopLauncher.exe");

			//----------------------------------------------------------------------------*
			// If updates were successful, show the release notes
			//----------------------------------------------------------------------------*

			else
				{
				Application.EnableVisualStyles();
				Application.SetCompatibleTextRenderingDefault(false);
				Application.Run(new MainForm());
				}
			}
		}
	}
